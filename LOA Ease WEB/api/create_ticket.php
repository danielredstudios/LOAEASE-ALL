<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');
date_default_timezone_set('Asia/Manila');
if (!isset($_SESSION['student_id']) || empty($_POST['student_id']) || $_SESSION['student_id'] != $_POST['student_id']) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Authentication error. Please log in again.']);
    exit();
}
if (empty($_POST['purpose']) || empty($_POST['schedule_datetime'])) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'All fields are required. Please fill out the form completely.']);
    exit();
}
$student_id = $_SESSION['student_id'];
$purpose = $_POST['purpose'];
$schedule_datetime = $_POST['schedule_datetime'];
$is_priority = isset($_POST['is_priority']) ? 1 : 0;
$counter_id = 1;
$conn->begin_transaction();
try {
    $schedule_date = date('Y-m-d', strtotime($schedule_datetime));
    $today_date = date('Y-m-d');
    if ($schedule_date <= $today_date) {
        throw new Exception("You can only schedule for a future date.");
    }
    $check_student_stmt = $conn->prepare("SELECT student_id FROM students WHERE student_id = ?");
    $check_student_stmt->bind_param("i", $student_id);
    $check_student_stmt->execute();
    if ($check_student_stmt->get_result()->num_rows === 0) {
        throw new Exception("Your user session is invalid. Please log out and log back in.");
    }
    $check_student_stmt->close();
    $stmt_check = $conn->prepare("SELECT queue_id FROM queues WHERE student_id = ? AND status IN ('waiting', 'serving', 'scheduled')");
    $stmt_check->bind_param("i", $student_id);
    $stmt_check->execute();
    if ($stmt_check->get_result()->num_rows > 0) {
        throw new Exception("You already have an active appointment. You can edit it from the dashboard.");
    }
    $stmt_check->close();
    $status = 'scheduled';
    $prefix_stmt = $conn->prepare("SELECT course FROM students WHERE student_id = ?");
    $prefix_stmt->bind_param("i", $student_id);
    $prefix_stmt->execute();
    $student_data = $prefix_stmt->get_result()->fetch_assoc();
    $prefix_stmt->close();
    $course = $student_data['course'] ?? '';
    if ($course == 'BS Information Technology') {
        $prefix = 'BSIT';
    } else {
        $prefix = 'GEN';
    }
    if ($is_priority) {
        $prefix = "P-" . $prefix;
    }
    $count_stmt = $conn->prepare("SELECT COUNT(*) as count FROM queues WHERE DATE(created_at) = ?");
    $count_stmt->bind_param("s", $today_date);
    $count_stmt->execute();
    $count = $count_stmt->get_result()->fetch_assoc()['count'] + 1;
    $count_stmt->close();
    $queue_number = $prefix . "-" . date("md") . "-" . str_pad($count, 3, '0', STR_PAD_LEFT);
    $stmt_insert = $conn->prepare("INSERT INTO queues (student_id, counter_id, queue_number, purpose, schedule_datetime, status, is_priority) VALUES (?, ?, ?, ?, ?, ?, ?)");
    $stmt_insert->bind_param("iissssi", $student_id, $counter_id, $queue_number, $purpose, $schedule_datetime, $status, $is_priority);
    if (!$stmt_insert->execute()) {
        throw new Exception("Could not create your ticket. Please try again.");
    }
    $stmt_insert->close();
    $conn->commit();
    echo json_encode(['success' => true]);
} catch (Exception $e) {
    $conn->rollback();
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => $e->getMessage()]);
}
$conn->close();
?>