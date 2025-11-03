<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

// Security: Ensure a cashier is logged in
if (!isset($_SESSION['counter_id'])) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

$data = json_decode(file_get_contents('php://input'), true);
$new_end_time = $data['end_time'] ?? '';

// Validate the time format (HH:MM)
if (!preg_match('/^([01]?[0-9]|2[0-3]):[0-5][0-9]$/', $new_end_time)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Invalid time format. Please use HH:MM.']);
    exit();
}

$counter_id = $_SESSION['counter_id'];

// Update the end_time for the logged-in cashier's counter
$stmt = $conn->prepare("UPDATE counter_schedules SET end_time = ? WHERE counter_id = ?");
$stmt->bind_param("si", $new_end_time, $counter_id);

if ($stmt->execute()) {
    echo json_encode(['success' => true, 'message' => 'Closing time updated successfully to ' . date("g:i A", strtotime($new_end_time)) . '.']);
} else {
    http_response_code(500);
    echo json_encode(['success' => false, 'message' => 'Failed to update closing time.']);
}

$stmt->close();
$conn->close();
?>