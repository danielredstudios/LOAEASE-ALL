<?php
require_once '../includes/db_connect.php';
date_default_timezone_set('Asia/Manila');

// The no-show threshold in seconds (e.g., 5 minutes = 300 seconds)
$no_show_threshold = 300; 

$expiry_time_check = date('Y-m-d H:i:s', time() - $no_show_threshold);

$stmt = $conn->prepare("UPDATE queues SET status = 'expired' WHERE status = 'serving' AND called_at < ?");
$stmt->bind_param("s", $expiry_time_check);
$stmt->execute();

$expired_count = $stmt->affected_rows;
$stmt->close();

// Optional: Log the action
if ($expired_count > 0) {
    // In a real application, you might log this to a file or another database table.
    error_log("$expired_count ticket(s) expired due to no-show.");
}

$conn->close();
?>