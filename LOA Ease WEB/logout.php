<?php
session_start(); // Start the session to access session variables

// Unset all of the session variables.
$_SESSION = array();

// Finally, destroy the session.
session_destroy();

// Redirect to login page
header("location: login.php");
exit;
?>