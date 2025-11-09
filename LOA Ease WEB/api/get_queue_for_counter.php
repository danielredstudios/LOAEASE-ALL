<?php
require_once '../includes/db_connect.php';
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['counter_id'])) {
    echo json_encode(['success' => false, 'message' => 'Not authenticated.']);
    exit();
}

$counter_id = $_SESSION['counter_id'];
$cashier_id = $_SESSION['cashier_id'] ?? null;
$today = date("Y-m-d");

$serving_stmt = $conn->prepare("
    SELECT 
        q.queue_id, 
        q.queue_number, 
        q.purpose, 
        q.is_visitor,
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

// Add unified display_name field
if ($serving) {
    if ($serving['is_visitor'] == 1 && !empty($serving['visitor_name'])) {
        $serving['display_name'] = $serving['visitor_name'];
    } else if (!empty($serving['first_name']) && !empty($serving['last_name'])) {
        $serving['display_name'] = $serving['first_name'] . ' ' . $serving['last_name'];
    } else {
        $serving['display_name'] = 'N/A';
    }
}
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

// Get today's KPIs for the current cashier
$completed_count = 0;
$no_show_count = 0;

if ($cashier_id) {
    $kpi_stmt = $conn->prepare("
        SELECT 
            SUM(CASE WHEN status = 'completed' THEN 1 ELSE 0 END) as completed,
            SUM(CASE WHEN status = 'no-show' THEN 1 ELSE 0 END) as no_show
        FROM queues 
        WHERE counter_id = ? AND DATE(schedule_datetime) = ?
    ");
    $kpi_stmt->bind_param("is", $counter_id, $today);
    $kpi_stmt->execute();
    $kpi_result = $kpi_stmt->get_result();
    $kpi_data = $kpi_result->fetch_assoc();
    $completed_count = $kpi_data['completed'] ?? 0;
    $no_show_count = $kpi_data['no_show'] ?? 0;
    $kpi_stmt->close();
}

echo json_encode([
    'success' => true, 
    'serving' => $serving, 
    'waiting' => $waiting,
    'completed_count' => $completed_count,
    'no_show_count' => $no_show_count
]);
$conn->close();
?>