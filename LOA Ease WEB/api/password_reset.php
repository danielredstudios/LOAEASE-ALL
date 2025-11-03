<?php
require_once '../includes/db_connect.php';

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;

require '../vendor/autoload.php';

header('Content-Type: application/json');
date_default_timezone_set('Asia/Manila');

if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(['success' => false, 'message' => 'Invalid request method.']);
    exit();
}

if (isset($_POST['email'])) {
    $email = trim($_POST['email']);

    $stmt = $conn->prepare("
        SELECT s.student_id, u.username 
        FROM students s 
        JOIN users u ON s.student_id = u.student_id 
        WHERE s.email = ?
    ");
    $stmt->bind_param("s", $email);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($user = $result->fetch_assoc()) {
        $username = $user['username'];
        $token = bin2hex(random_bytes(50));
        $expires_at = date('Y-m-d H:i:s', time() + 1800);
        $user_type = 'student';

        $delete_stmt = $conn->prepare("
            DELETE FROM password_reset_token
            WHERE email = ? AND is_used = 0
        ");
        $delete_stmt->bind_param("s", $email);
        $delete_stmt->execute();
        $delete_stmt->close();

        $insert_stmt = $conn->prepare("
            INSERT INTO password_reset_token (username, user_type, email, token, expires_at) 
            VALUES (?, ?, ?, ?, ?)
        ");
        $insert_stmt->bind_param("sssss", $username, $user_type, $email, $token, $expires_at);
        $insert_stmt->execute();
        $insert_stmt->close();

        $reset_link = "https://loaease.tech/reset_password.php?token=" . $token;
        
        $to = $email;
        $subject = "Password Reset Request for LOA-EASE";
        $message_html = "
        <html>
        <head>
          <title>Password Reset Request</title>
          <style>
            body { font-family: Arial, sans-serif; line-height: 1.6; }
            .container { padding: 20px; border: 1px solid #ddd; border-radius: 5px; max-width: 600px; margin: 20px auto; }
            .button { background-color: #003366; color: #ffffff; padding: 10px 20px; text-decoration: none; border-radius: 5px; display: inline-block; }
            .button:hover { background-color: #0055a4; }
          </style>
        </head>
        <body>
          <div class='container'>
            <h2 style='color: #003366;'>Password Reset Request</h2>
            <p>Hello,</p>
            <p>We received a request to reset your password for your LOA-EASE account.</p>
            <p>Please click the button below to set a new password. This link is valid for 30 minutes.</p>
            <p style='text-align: center; margin: 25px 0;'>
              <a href='" . $reset_link . "' class='button' style='color: #ffffff;'>Reset Your Password</a>
            </p>
            <p>If the button doesn't work, copy and paste this link into your browser:</p>
            <p><a href='" . $reset_link . "'>" . $reset_link . "</a></p>
            <p>If you did not request a password reset, please ignore this email.</p>
            <p>Thank you,<br>The LOA-EASE Team</p>
          </div>
        </body>
        </html>
        ";
        
        $mail = new PHPMailer(true);

        try {
            $mail->isSMTP();
            $mail->Host       = 'smtp-relay.brevo.com';
            $mail->SMTPAuth   = true;
            $mail->Username   = '9a3063001@smtp-brevo.com';
            $mail->Password   = 'xsmtpsib-90cd5d3562a9bbd92e285012843b42f884f5a8f56b40d81390a8060bff7c4732-jpPKM0thGBiOoJQZ';
            $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
            $mail->Port       = 587;

            $mail->setFrom('no-reply@loaease.tech', 'LOA-EASE Admin');
            $mail->addAddress($to);

            $mail->isHTML(true);
            $mail->Subject = $subject;
            $mail->Body    = $message_html;
            $mail->AltBody = "To reset your password, please visit this link: " . $reset_link;

            $mail->send();
            
        } catch (Exception $e) {
            error_log("PHPMailer Error: {$mail->ErrorInfo}");
        }
        
        echo json_encode(['success' => true, 'message' => 'If an account with that email exists, a password reset link has been sent.']);
    } else {
        echo json_encode(['success' => true, 'message' => 'If an account with that email exists, a password reset link has been sent.']);
    }
    $stmt->close();
    $conn->close();
    exit();
}

if (isset($_POST['token']) && isset($_POST['password'])) {
    $token = trim($_POST['token']);
    $password = $_POST['password'];

    $current_time = date('Y-m-d H:i:s');

    $stmt = $conn->prepare("
        SELECT token_id, username, expires_at, is_used 
        FROM password_reset_token 
        WHERE token = ? AND is_used = 0
    ");
    $stmt->bind_param("s", $token);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($row = $result->fetch_assoc()) {
        $expires_at = strtotime($row['expires_at']);
        $current_timestamp = strtotime($current_time);
        
        if ($expires_at < $current_timestamp) {
            echo json_encode(['success' => false, 'message' => 'The password reset link has expired.']);
            $stmt->close();
            $conn->close();
            exit();
        }
        
        if (strlen($password) < 8 || 
            !preg_match('/[A-Z]/', $password) || 
            !preg_match('/[a-z]/', $password) || 
            !preg_match('/[0-9]/', $password) || 
            !preg_match('/[\W_]/', $password)) {
            echo json_encode(['success' => false, 'message' => 'Password must be at least 8 characters and contain uppercase, lowercase, number, and special character.']);
            $stmt->close();
            $conn->close();
            exit();
        }
        
        $password_hash = password_hash($password, PASSWORD_BCRYPT);
        $username = $row['username'];
        $token_id = $row['token_id'];

        $update_stmt = $conn->prepare("UPDATE users SET password_hash = ? WHERE username = ?");
        $update_stmt->bind_param("ss", $password_hash, $username);
        
        if ($update_stmt->execute()) {
            $used_at = date('Y-m-d H:i:s');
            $used_stmt = $conn->prepare("
                UPDATE password_reset_token 
                SET is_used = 1, used_at = ? 
                WHERE token_id = ?
            ");
            $used_stmt->bind_param("si", $used_at, $token_id);
            $used_stmt->execute();
            $used_stmt->close();

            echo json_encode(['success' => true, 'message' => 'Your password has been updated successfully.']);
        } else {
            echo json_encode(['success' => false, 'message' => 'Could not update password.']);
        }
        $update_stmt->close();

    } else {
        echo json_encode(['success' => false, 'message' => 'Invalid or already used password reset token.']);
    }
    $stmt->close();
    $conn->close();
    exit();
}

echo json_encode(['success' => false, 'message' => 'Invalid request.']);
?>


