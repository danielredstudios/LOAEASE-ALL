<?php
require_once '../includes/db_connect.php';
date_default_timezone_set('Asia/Manila');

$stmt = $conn->prepare("DELETE FROM password_reset_token WHERE is_used = 1 OR expires_at < NOW()");

if ($stmt) {
    $stmt->execute();
    $deleted_count = $stmt->affected_rows;
    $stmt->close();
    
    $log_message = date('Y-m-d H:i:s') . " - Auto-expire tokens: $deleted_count old/used tokens were deleted.\n";
    
    echo $log_message;
    
} else {
    $log_message = date('Y-m-d H:i:s') . " - ERROR: Failed to prepare token expiry statement.\n";
    echo $log_message;
}

$conn->close();
?>