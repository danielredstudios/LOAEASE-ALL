<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

$data = json_decode(file_get_contents('php://input'), true);
$username = $data['username'] ?? '';
$password = $data['password'] ?? '';

if (empty($username) || empty($password)) {
    echo json_encode(['success' => false, 'message' => 'Username and password are required.']);
    exit();
}

$stmt = $conn->prepare("
    SELECT c.cashier_id, c.password_hash, co.counter_id, co.counter_name, c.full_name
    FROM cashiers c
    JOIN counters co ON c.counter_id = co.counter_id
    WHERE c.username = ?
");
$stmt->bind_param("s", $username);
$stmt->execute();
$result = $stmt->get_result();

if ($cashier = $result->fetch_assoc()) {
    if (password_verify($password, $cashier['password_hash'])) {
        $_SESSION['cashier_id'] = $cashier['cashier_id'];
        $_SESSION['counter_id'] = $cashier['counter_id'];
        $_SESSION['counter_name'] = $cashier['counter_name'];
        $_SESSION['full_name'] = $cashier['full_name'];

        // --- FIX: Set the counter to online upon successful login ---
        $update_stmt = $conn->prepare("UPDATE counter_schedules SET is_open = 1, status = 'open' WHERE counter_id = ?");
        $update_stmt->bind_param("i", $cashier['counter_id']);
        $update_stmt->execute();
        $update_stmt->close();
        // --- END FIX ---
        
        echo json_encode(['success' => true]);
    } else {
        echo json_encode(['success' => false, 'message' => 'Invalid credentials.']);
    }
} else {
    echo json_encode(['success' => false, 'message' => 'Invalid credentials.']);
}
$stmt->close();
$conn->close();
?>