<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['counter_id'])) {
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$counter_id = $_SESSION['counter_id'];
$today = date("Y-m-d");

$serving_stmt = $conn->prepare("
    SELECT 
        q.queue_id, 
        q.queue_number, 
        q.purpose, 
        s.student_number, 
        s.first_name, 
        s.last_name, 
        s.course,
        v.full_name as visitor_name
    FROM queues q
    LEFT JOIN students s ON q.student_id = s.student_id
    LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
    WHERE q.counter_id = ? AND q.status = 'serving' AND DATE(q.schedule_datetime) = ?
    ORDER BY q.created_at LIMIT 1
");
$serving_stmt->bind_param("is", $counter_id, $today);
$serving_stmt->execute();
$serving_result = $serving_stmt->get_result();
$serving = $serving_result->fetch_assoc();
$serving_stmt->close();

$waiting_stmt = $conn->prepare("SELECT queue_number, purpose, is_priority FROM queues WHERE counter_id = ? AND status = 'waiting' AND DATE(schedule_datetime) = ? ORDER BY is_priority DESC, created_at ASC");
$waiting_stmt->bind_param("is", $counter_id, $today);
$waiting_stmt->execute();
$result = $waiting_stmt->get_result();
$waiting = [];
while ($row = $result->fetch_assoc()) {
    $waiting[] = $row;
}
$waiting_stmt->close();

echo json_encode(['success' => true, 'serving' => $serving, 'waiting' => $waiting]);
$conn->close();
?>