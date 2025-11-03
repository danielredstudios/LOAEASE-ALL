<?php
require_once '../includes/db_connect.php';
header('Content-Type: application/json');

// This query joins counters with their schedules to get their live status
$sql = "
    SELECT
        c.counter_id,
        c.counter_name,
        cs.is_open,
        cs.status
    FROM
        counters c
    LEFT JOIN
        counter_schedules cs ON c.counter_id = cs.counter_id
    ORDER BY
        c.counter_name ASC
";

$result = $conn->query($sql);

$counters = [];
if ($result) {
    while ($row = $result->fetch_assoc()) {
        $counters[] = $row;
    }
}

$conn->close();

echo json_encode(['success' => true, 'counters' => $counters]);
?>