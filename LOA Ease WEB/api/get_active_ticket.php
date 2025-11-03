<?php
require_once '../includes/db_connect.php';
session_start();

header('Content-Type: application/json');

if (!isset($_SESSION['student_id'])) {
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$student_id = $_SESSION['student_id'];

// --- FIX: Formats the date as YYYY-MM-DD for the date input field ---
$stmt = $conn->prepare("
    SELECT queue_id, counter_id, purpose, DATE_FORMAT(schedule_datetime, '%Y-%m-%d') as schedule_datetime
    FROM queues
    WHERE student_id = ? AND status IN ('waiting', 'serving', 'scheduled')
    ORDER BY created_at DESC
    LIMIT 1
");
$stmt->bind_param("i", $student_id);
$stmt->execute();
$result = $stmt->get_result();

if ($ticket = $result->fetch_assoc()) {
    // Found an active ticket, return its details
    echo json_encode(['success' => true, 'ticket' => $ticket]);
} else {
    // No active ticket was found
    echo json_encode(['success' => false, 'message' => 'No active ticket found.']);
}

$stmt->close();
$conn->close();
?>