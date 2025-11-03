<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['counter_id'])) {
    http_response_code(401);
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$counter_id = $_SESSION['counter_id'];
$data = json_decode(file_get_contents('php://input'), true);
$action = $data['action'] ?? 'get_status';

$stmt = $conn->prepare("SELECT is_open, status FROM counter_schedules WHERE counter_id = ?");
$stmt->bind_param("i", $counter_id);
$stmt->execute();
$current_status = $stmt->get_result()->fetch_assoc();
$stmt->close();

if ($action === 'get_status') {
    echo json_encode(['success' => true, 'status' => $current_status]);
    exit();
}

if ($action === 'toggle_break') {
    $new_status = ($current_status['status'] === 'open') ? 'break' : 'open';
    $update_stmt = $conn->prepare("UPDATE counter_schedules SET status = ? WHERE counter_id = ?");
    $update_stmt->bind_param("si", $new_status, $counter_id);
    $update_stmt->execute();
    $update_stmt->close();
} elseif ($action === 'toggle_offline') {
    $new_is_open = ($current_status['is_open'] == 1) ? 0 : 1;
    $update_stmt = $conn->prepare("UPDATE counter_schedules SET is_open = ? WHERE counter_id = ?");
    $update_stmt->bind_param("ii", $new_is_open, $counter_id);
    $update_stmt->execute();
    $update_stmt->close();

    if ($new_is_open == 0) {
        $expire_stmt = $conn->prepare("UPDATE queues SET status = 'expired' WHERE counter_id = ? AND status IN ('waiting', 'serving')");
        $expire_stmt->bind_param("i", $counter_id);
        $expire_stmt->execute();
        $expire_stmt->close();
    }
}

$stmt = $conn->prepare("SELECT is_open, status FROM counter_schedules WHERE counter_id = ?");
$stmt->bind_param("i", $counter_id);
$stmt->execute();
$new_status_data = $stmt->get_result()->fetch_assoc();
$stmt->close();

echo json_encode(['success' => true, 'new_status' => $new_status_data]);
$conn->close();
?>