<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['counter_id'])) {
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$counter_id = $_SESSION['counter_id'];
$data = json_decode(file_get_contents('php://input'), true);
$action = $data['action'] ?? '';

$conn->begin_transaction();
try {
    if ($action == 'next') {
        $check_stmt = $conn->prepare("SELECT queue_id FROM queues WHERE counter_id = ? AND status = 'serving'");
        $check_stmt->bind_param("i", $counter_id);
        $check_stmt->execute();
        if ($check_stmt->get_result()->num_rows > 0) {
            throw new Exception('A student is already being served.');
        }
        $check_stmt->close();

        $next_stmt = $conn->prepare("UPDATE queues SET status = 'serving', called_at = NOW() WHERE counter_id = ? AND status = 'waiting' ORDER BY is_priority DESC, created_at ASC LIMIT 1");
        $next_stmt->bind_param("i", $counter_id);
        $next_stmt->execute();
        if ($next_stmt->affected_rows == 0) {
            throw new Exception('No students are waiting.');
        }
        $next_stmt->close();

    } elseif (in_array($action, ['complete', 'no-show'])) {
        $queue_id = $data['queue_id'] ?? null;
        if (!$queue_id) throw new Exception('Invalid request.');

        $new_status = ($action == 'complete') ? 'completed' : 'no-show';
        
        $update_stmt = $conn->prepare("UPDATE queues SET status = ? WHERE queue_id = ? AND counter_id = ? AND status = 'serving'");
        $update_stmt->bind_param("sii", $new_status, $queue_id, $counter_id);
        $update_stmt->execute();
        if ($update_stmt->affected_rows == 0) {
             throw new Exception('Could not update ticket. It may have already been processed.');
        }
        $update_stmt->close();
    } else {
        throw new Exception('Invalid action.');
    }

    $conn->commit();
    echo json_encode(['success' => true]);

} catch (Exception $e) {
    $conn->rollback();
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => $e->getMessage()]);
}

$conn->close();
?>