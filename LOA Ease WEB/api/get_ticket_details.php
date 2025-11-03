<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['student_id'])) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

const AVERAGE_SERVICE_TIME = 5; 

$queue_number = $_GET['queue_number'] ?? '';
$student_id = $_SESSION['student_id'];

if (empty($queue_number)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Queue number is required.']);
    exit();
}

$stmt = $conn->prepare("
    SELECT q.queue_id, q.queue_number, q.purpose, q.schedule_datetime, q.status, c.counter_name, q.counter_id, q.created_at
    FROM queues q 
    JOIN counters c ON q.counter_id = c.counter_id
    WHERE q.student_id = ? AND q.queue_number = ?
    LIMIT 1
");
$stmt->bind_param("is", $student_id, $queue_number);
$stmt->execute();
$result = $stmt->get_result();

if ($ticket = $result->fetch_assoc()) {
    if ($ticket['status'] == 'waiting') {
        $wait_stmt = $conn->prepare("SELECT COUNT(*) as position FROM queues WHERE counter_id = ? AND status = 'waiting' AND created_at < ?");
        $wait_stmt->bind_param("is", $ticket['counter_id'], $ticket['created_at']);
        $wait_stmt->execute();
        $position = $wait_stmt->get_result()->fetch_assoc()['position'];
        $wait_stmt->close();
        $ticket['estimated_wait_time'] = ($position + 1) * AVERAGE_SERVICE_TIME;
    } else {
         $ticket['estimated_wait_time'] = 0; 
    }
    echo json_encode(['success' => true, 'ticket' => $ticket]);
} else {
    echo json_encode(['success' => false, 'message' => 'Ticket not found.']);
}

$stmt->close();
$conn->close();
?>