<?php
$password = 'Password123!';

$hash = password_hash($password, PASSWORD_BCRYPT);
echo "Password: " . htmlspecialchars($password) . "<br>";
echo "Generated Hash: " . htmlspecialchars($hash);

?>