<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');
date_default_timezone_set('Asia/Manila');
if (empty($_POST['student_number'])) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Student number is required.']);
    exit();
}
if (empty($_POST['purpose'])) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Please select a purpose for your visit.']);
    exit();
}
$student_number_input = trim($_POST['student_number']);
$purpose = $_POST['purpose'];
$is_priority = isset($_POST['is_priority']) ? 1 : 0;
$conn->begin_transaction();
try {
    $number_with_c = $student_number_input;
    $number_without_c = $student_number_input;
    if (strtoupper(substr($student_number_input, 0, 1)) === 'C') {
        $number_without_c = substr($student_number_input, 1);
    } else {
        $number_with_c = 'C' . $student_number_input;
    }
    $student_stmt = $conn->prepare("SELECT student_id, course FROM students WHERE student_number = ? OR student_number = ?");
    $student_stmt->bind_param("ss", $number_with_c, $number_without_c);
    $student_stmt->execute();
    $student_result = $student_stmt->get_result();
    if ($student_result->num_rows === 0) {
        throw new Exception("Student number not found.");
    }
    $student_data = $student_result->fetch_assoc();
    $student_id = $student_data['student_id'];
    $student_stmt->close();
    $stmt_check = $conn->prepare("SELECT queue_id FROM queues WHERE student_id = ? AND status IN ('waiting', 'serving', 'scheduled')");
    $stmt_check->bind_param("i", $student_id);
    $stmt_check->execute();
    if ($stmt_check->get_result()->num_rows > 0) {
        throw new Exception("You already have an active ticket or appointment.");
    }
    $stmt_check->close();
    $sql = "SELECT c.counter_id, c.counter_name, cs.is_open, cs.status, (SELECT COUNT(*) FROM queues q WHERE q.counter_id = c.counter_id AND q.status = 'waiting') as waiting_count FROM counters c JOIN counter_schedules cs ON c.counter_id = cs.counter_id";
    $counters_result = $conn->query($sql);
    $available_counters = [];
    $doc_req_counter = null;
    while ($row = $counters_result->fetch_assoc()) {
        if ($row['is_open'] == 1 && $row['status'] == 'open') {
            $available_counters[] = $row;
            if ($row['counter_name'] == 'Cashier 4') {
                $doc_req_counter = $row;
            }
        }
    }
    if (empty($available_counters)) {
        throw new Exception("All cashiers are currently offline. Please try again later.");
    }
    $assigned_counter_id = null;
    if (strpos($purpose, 'Document Request') !== false && $doc_req_counter) {
        $assigned_counter_id = $doc_req_counter['counter_id'];
    } else {
        $min_waiting = -1;
        foreach ($available_counters as $counter) {
            if ($min_waiting == -1 || $counter['waiting_count'] < $min_waiting) {
                $min_waiting = $counter['waiting_count'];
                $assigned_counter_id = $counter['counter_id'];
            }
        }
    }
    if ($assigned_counter_id === null) {
        throw new Exception("Could not assign a cashier. Please try again.");
    }
    $status = 'waiting';
    $schedule_datetime = date("Y-m-d H:i:s");
    $course = $student_data['course'] ?? '';
    if ($course == 'BS Information Technology') {
        $prefix = 'BSIT';
    } else {
        $prefix = 'GEN';
    }
    if ($is_priority) {
        $prefix = "P-" . $prefix;
    }
    $today_date = date('Y-m-d');
    $count_stmt = $conn->prepare("SELECT COUNT(*) as count FROM queues WHERE DATE(created_at) = ?");
    $count_stmt->bind_param("s", $today_date);
    $count_stmt->execute();
    $count = $count_stmt->get_result()->fetch_assoc()['count'] + 1;
    $count_stmt->close();
    $queue_number = $prefix . "-" . date("md") . "-" . str_pad($count, 3, '0', STR_PAD_LEFT);
    $stmt_insert = $conn->prepare("INSERT INTO queues (student_id, counter_id, queue_number, purpose, schedule_datetime, status, is_priority) VALUES (?, ?, ?, ?, ?, ?, ?)");
    $stmt_insert->bind_param("iissssi", $student_id, $assigned_counter_id, $queue_number, $purpose, $schedule_datetime, $status, $is_priority);
    if (!$stmt_insert->execute()) {
        throw new Exception("Could not create your ticket. Please try again.");
    }
    $stmt_insert->close();
    $conn->commit();
    $_SESSION['kiosk_queue_number'] = $queue_number;
    echo json_encode(['success' => true, 'redirect_url' => 'kiosk_ticket.php']);
} catch (Exception $e) {
    $conn->rollback();
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => $e->getMessage()]);
}
$conn->close();
?>