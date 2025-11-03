<?php
require_once '../includes/db_connect.php';
session_start();

header('Content-Type: application/json');

if (!isset($_SESSION['student_id'])) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$student_id = $_SESSION['student_id'];

// Find all tickets for the student, ordered by the most recent
$stmt = $conn->prepare("
    SELECT 
        q.queue_number, 
        q.purpose, 
        q.schedule_datetime, 
        q.status, 
        c.counter_name,
        q.created_at
    FROM queues q 
    JOIN counters c ON q.counter_id = c.counter_id
    WHERE q.student_id = ?
    ORDER BY q.created_at DESC
");
$stmt->bind_param("i", $student_id);
$stmt->execute();
$result = $stmt->get_result();

$history = [];
while ($row = $result->fetch_assoc()) {
    $history[] = $row;
}

echo json_encode(['success' => true, 'history' => $history]);

$stmt->close();
$conn->close();
?>