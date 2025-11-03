<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "loa_ease_queuing_experiemental";
$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
?>