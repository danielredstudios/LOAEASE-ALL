<?php
require_once '../includes/db_connect.php';
session_start();

if (isset($_SESSION['counter_id'])) {
    $counter_id = $_SESSION['counter_id'];
    
    $conn->prepare("UPDATE counter_schedules SET is_open = 0 WHERE counter_id = ?")
         ->execute([$counter_id]);

    $expire_stmt = $conn->prepare("UPDATE queues SET status = 'expired' WHERE counter_id = ? AND status IN ('waiting', 'serving')");
    $expire_stmt->bind_param("i", $counter_id);
    $expire_stmt->execute();
    $expire_stmt->close();
}

session_unset();
session_destroy();

header("Location: ../cashier_login.php");
exit();
?>