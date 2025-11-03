<?php
require_once '../includes/db_connect.php';
header('Content-Type: application/json');

date_default_timezone_set('Asia/Manila');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

$data = json_decode(file_get_contents('php://input'), true);
$queue_number = $data['queue_number'] ?? '';

if (empty($queue_number)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Queue number is required.']);
    exit();
}

$stmt = $conn->prepare("SELECT queue_id, status, schedule_datetime FROM queues WHERE queue_number = ?");
$stmt->bind_param("s", $queue_number);
$stmt->execute();
$ticket = $stmt->get_result()->fetch_assoc();
$stmt->close();

if (!$ticket) {
    http_response_code(404);
    echo json_encode(['success' => false, 'message' => 'Ticket not found.']);
    exit();
}

$schedule_date = date('Y-m-d', strtotime($ticket['schedule_datetime']));
$today_date = date('Y-m-d');

if ($ticket['status'] !== 'scheduled') {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'This ticket is not scheduled for check-in. It may already be active or completed.']);
    exit();
}

if ($schedule_date !== $today_date) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Check-in is not available today. Please come back on your scheduled date: ' . $schedule_date]);
    exit();
}

$update_stmt = $conn->prepare("UPDATE queues SET status = 'waiting', is_priority = 1 WHERE queue_id = ?");
$update_stmt->bind_param("i", $ticket['queue_id']);

if ($update_stmt->execute()) {
    echo json_encode(['success' => true, 'message' => 'Check-in successful! You have been placed in the priority queue.']);
} else {
    http_response_code(500);
    echo json_encode(['success' => false, 'message' => 'Failed to update ticket status.']);
}
$update_stmt->close();
$conn->close();
?>