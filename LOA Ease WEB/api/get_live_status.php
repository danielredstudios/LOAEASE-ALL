<?php
require_once '../includes/db_connect.php';
date_default_timezone_set('Asia/Manila');
header('Content-Type: application/json');

const AVERAGE_SERVICE_TIME = 5;

$today = date("Y-m-d");

$sql = "
    SELECT
        c.counter_id,
        c.counter_name,
        cs.is_open,
        cs.status,
        (SELECT q_serving.queue_number 
         FROM queues q_serving 
         WHERE q_serving.counter_id = c.counter_id 
           AND q_serving.status = 'serving') AS serving_number,
        (SELECT COUNT(*)
         FROM queues q_waiting
         WHERE q_waiting.counter_id = c.counter_id
           AND q_waiting.status = 'waiting'
           AND DATE(q_waiting.schedule_datetime) = CURDATE()) AS waiting_count
    FROM
        counters c
    JOIN counter_schedules cs ON c.counter_id = cs.counter_id
";
$result = $conn->query($sql);
$counters_status = [];
while ($row = $result->fetch_assoc()) {
    $row['estimated_wait_time'] = $row['waiting_count'] * AVERAGE_SERVICE_TIME;
    $counters_status[] = $row;
}

$waiting_sql = "
    SELECT queue_number 
    FROM queues 
    WHERE status = 'waiting' 
      AND DATE(schedule_datetime) = ?
      AND counter_id IN (SELECT counter_id FROM counter_schedules WHERE is_open = 1 AND status = 'open')
    ORDER BY is_priority DESC, created_at ASC
    LIMIT 5
";
$stmt = $conn->prepare($waiting_sql);
$stmt->bind_param("s", $today);
$stmt->execute();
$waiting_result = $stmt->get_result();
$waiting_list = [];
while ($row = $waiting_result->fetch_assoc()) {
    $waiting_list[] = $row['queue_number'];
}
$stmt->close();

$conn->close();

echo json_encode(['counters' => $counters_status, 'waiting_list' => $waiting_list]);
?>