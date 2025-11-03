<?php
require_once '../includes/db_connect.php';
session_start();

if (!isset($_SESSION['visitor_data'])) {
    header("Location: ../visitor_login.php");
    exit();
}

$visitor_data = $_SESSION['visitor_data'];
unset($_SESSION['visitor_data']);

$full_name = $visitor_data['full_name'];
$email = $visitor_data['email'];
$purpose = $visitor_data['purpose'];

$conn->begin_transaction();

try {
    $stmt = $conn->prepare("INSERT INTO visitors (full_name, email) VALUES (?, ?)");
    $stmt->bind_param("ss", $full_name, $email);
    $stmt->execute();
    $visitor_id = $stmt->insert_id;
    $stmt->close();

    $prefix = "VISITOR-" . date("Ymd");
    $count_stmt = $conn->prepare("SELECT COUNT(*) as count FROM queues WHERE queue_number LIKE ?");
    $like_prefix = $prefix . "%";
    $count_stmt->bind_param("s", $like_prefix);
    $count_stmt->execute();
    $count = $count_stmt->get_result()->fetch_assoc()['count'] + 1;
    $count_stmt->close();
    $queue_number = $prefix . "-" . str_pad($count, 3, '0', STR_PAD_LEFT);

    $counter_id = 1;
    $schedule_datetime = date("Y-m-d H:i:s");
    $status = 'waiting';

    $stmt_insert = $conn->prepare("INSERT INTO queues (visitor_id, counter_id, queue_number, purpose, schedule_datetime, status) VALUES (?, ?, ?, ?, ?, ?)");
    $stmt_insert->bind_param("iissss", $visitor_id, $counter_id, $queue_number, $purpose, $schedule_datetime, $status);
    $stmt_insert->execute();
    $stmt_insert->close();

    $conn->commit();

    $_SESSION['visitor_queue_number'] = $queue_number;
    header("Location: ../visitor_ticket.php");
    exit();

} catch (Exception $e) {
    $conn->rollback();
    $_SESSION['error_message'] = "Could not generate a ticket. Please try again.";
    header("Location: ../visitor_login.php");
    exit();
}

$conn->close();
?>