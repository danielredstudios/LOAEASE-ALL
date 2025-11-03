<?php
require_once '../includes/db_connect.php';
header('Content-Type: application/json');

// --- Security Note ---
// In a real-world application, you MUST protect this endpoint.
// Anyone could open/close your counters.
// Add an API key, admin login session check, or IP restriction.

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

$data = json_decode(file_get_contents('php://input'), true);

$counter_id = $data['counter_id'] ?? null;
$is_open = $data['is_open'] ?? null;

// Validate input
if ($counter_id === null || $is_open === null || !is_numeric($counter_id) || !is_numeric($is_open)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Invalid input. Both counter_id and is_open status are required.']);
    exit();
}

// Convert is_open to a boolean (0 or 1)
$status = (int)$is_open === 1 ? 1 : 0;

// Prepare and execute the update
$stmt = $conn->prepare("UPDATE counter_schedules SET is_open = ? WHERE counter_id = ?");
if (!$stmt) {
    http_response_code(500);
    echo json_encode(['success' => false, 'message' => 'Failed to prepare statement.']);
    exit();
}

$stmt->bind_param("ii", $status, $counter_id);

if ($stmt->execute()) {
    if ($stmt->affected_rows > 0) {
        $action = $status === 1 ? 'opened' : 'closed';
        echo json_encode(['success' => true, 'message' => "Counter ID {$counter_id} has been {$action}."]);
    } else {
        echo json_encode(['success' => false, 'message' => "No counter found with ID {$counter_id} or status is already set."]);
    }
} else {
    http_response_code(500);
    echo json_encode(['success' => false, 'message' => 'Failed to update counter status.']);
}

$stmt->close();
$conn->close();
?>