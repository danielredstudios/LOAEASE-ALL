<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

if (!isset($_SESSION['student_id']) || !isset($_POST['student_id']) || $_SESSION['student_id'] != $_POST['student_id']) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Authentication error. Please log in again.']);
    exit();
}

if (empty($_POST['purpose']) || empty($_POST['schedule_datetime']) || empty($_POST['queue_id'])) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'All fields are required. Please fill out the form completely.']);
    exit();
}

$student_id = $_SESSION['student_id'];
$queue_id = $_POST['queue_id'];
$purpose = $_POST['purpose'];
$schedule_datetime = $_POST['schedule_datetime'];
$is_priority = isset($_POST['is_priority']) ? 1 : 0;

$conn->begin_transaction();
try {
    $stmt_check = $conn->prepare("SELECT queue_id FROM queues WHERE queue_id = ? AND student_id = ? AND status IN ('waiting', 'serving', 'scheduled')");
    $stmt_check->bind_param("ii", $queue_id, $student_id);
    $stmt_check->execute();
    $result = $stmt_check->get_result();
    if ($result->num_rows == 0) {
        throw new Exception("Ticket not found or you do not have permission to edit it. It might have been processed already.");
    }
    $stmt_check->close();

    $schedule_date = new DateTime($schedule_datetime);
    $now = new DateTime();
    $status = $schedule_date->format('Y-m-d') > $now->format('Y-m-d') ? 'scheduled' : 'waiting';

    $stmt_update = $conn->prepare("UPDATE queues SET purpose = ?, schedule_datetime = ?, is_priority = ?, status = ? WHERE queue_id = ?");
    $stmt_update->bind_param("ssisi", $purpose, $schedule_datetime, $is_priority, $status, $queue_id);
    if(!$stmt_update->execute()){
        throw new Exception("Could not update your ticket. Please try again.");
    }
    $stmt_update->close();

    $conn->commit();
    echo json_encode(['success' => true, 'message' => 'Ticket updated successfully.']);

} catch (Exception $e) {
    $conn->rollback();
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => $e->getMessage()]);
}

$conn->close();
?>