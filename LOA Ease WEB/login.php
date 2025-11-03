<?php
require_once 'includes/db_connect.php';
session_start();

if (isset($_SESSION['user_id'])) {
    header("Location: dashboard.php");
    exit();
}

$message = '';
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $student_number_input = trim($_POST['student_number']);
    $password = $_POST['password'];

    if (empty($student_number_input) || empty($password)) {
        $message = '<div class="alert alert-warning d-flex align-items-center"><i data-lucide="alert-triangle" class="me-2"></i>Student Number and password are required.</div>';
    } else {
        $number_with_c = $student_number_input;
        $number_without_c = $student_number_input;
        if (strtoupper(substr($student_number_input, 0, 1)) === 'C') {
            $number_without_c = substr($student_number_input, 1);
        } else {
            $number_with_c = 'C' . $student_number_input;
        }

        $stmt = $conn->prepare("
            SELECT u.user_id, u.student_id, u.password_hash, s.first_name, s.middle_initial, s.last_name, s.student_number
            FROM users u
            JOIN students s ON u.student_id = s.student_id
            WHERE (s.student_number = ? OR s.student_number = ?)
            LIMIT 1
        ");
        $stmt->bind_param("ss", $number_with_c, $number_without_c);
        $stmt->execute();
        $stmt->store_result();

        if ($stmt->num_rows == 1) {
            $stmt->bind_result($user_id, $student_id, $password_hash, $first_name, $middle_initial, $last_name, $student_number);
            $stmt->fetch();

            if (password_verify($password, $password_hash)) {
                session_regenerate_id(true);

                $_SESSION['user_id'] = $user_id;
                $_SESSION['student_id'] = $student_id;
                $_SESSION['full_name'] = trim($first_name . ' ' . $middle_initial . ' ' . $last_name);
                $_SESSION['student_number'] = $student_number;
                $_SESSION['csrf_token'] = bin2hex(random_bytes(32));

                $update_stmt = $conn->prepare("UPDATE users SET last_login = CURRENT_TIMESTAMP WHERE user_id = ?");
                $update_stmt->bind_param("i", $user_id);
                $update_stmt->execute();
                $update_stmt->close();

                header("Location: dashboard.php");
                exit();
            } else {
                $message = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="x-circle" class="me-2"></i>Invalid password. Please try again.</div>';
            }
        } else {
            $message = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="user-x" class="me-2"></i>No user found with that Student Number.</div>';
        }
        $stmt->close();
    }
}
$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <!-- Link to the stylesheet -->
    <link rel="stylesheet" href="styles.css">
    <style>
        /* Styles from original file */
        :root {
            --loa-blue: #003366; --loa-yellow: #FFC72C; --loa-blue-light: #0055a4;
            /* These are now fallbacks, main values are in styles.css */
            --light-bg: #eef2f7; --dark-text: #212529; --card-bg: rgba(255, 255, 255, 0.7);
            --card-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); --font-family: 'Poppins', sans-serif;
        }
        body {
            /* font-family: var(--font-family); background: linear-gradient(-45deg, var(--light-bg), var(--loa-blue-light), var(--light-bg), var(--loa-blue));
            background-size: 400% 400%; animation: gradientBG 15s ease infinite;  -- REMOVED, handled by styles.css */
            display: flex;
            justify-content: center; align-items: center; min-height: 100vh; padding: 1rem; perspective: 1000px;
        }
        /* @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } } -- REMOVED */
        
        /* .styled-card { -- MOVED to styles.css
            background: var(--card-bg); border-radius: 1.5rem; border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: var(--card-shadow); backdrop-filter: blur(25px); -webkit-backdrop-filter: blur(25px);
            width: 100%; max-width: 500px; overflow: hidden; animation: fadeInFromBottom 1s ease-out; transition: transform 0.1s ease;
        } */
        /* @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } } -- MOVED */
        
        .styled-card .card-content { padding: 3rem; } /* Override default padding */

        /* .btn-primary-modern { -- MOVED to styles.css
            background: var(--loa-blue); border: none; border-radius: 50px; padding: 0.8rem 2rem;
            font-size: 1.1rem; font-weight: 600; color: white; transition: all 0.3s ease;
            box-shadow: 0 4px 15px rgba(0, 51, 102, 0.3);
        }
        .btn-primary-modern:hover { -- MOVED to styles.css
            background-color: var(--loa-yellow); color: var(--loa-blue); transform: translateY(-4px) scale(1.05);
            box-shadow: 0 8px 25px rgba(255, 199, 44, 0.5);
        } */
        @media (max-width: 576px) {
            .styled-card .card-content {
                padding: 2rem;
            }
        }
    </style>
</head>
<body>

    <!-- Dark Mode Toggle Button -->
    <div class="theme-toggle" id="theme-toggle" title="Toggle theme">
        <i data-lucide="moon" class="icon-moon"></i>
        <i data-lucide="sun" class="icon-sun"></i>
    </div>

    <div class="styled-card">
        <div class="card-content">
            <div class="text-center mb-4">
                <h2 class="fw-bold">Welcome Back!</h2>
                <p class="text-muted">Please sign in to continue.</p>
            </div>

            <?php if($message) echo $message; ?>

            <form action="login.php" method="POST">
                <div class="mb-3">
                    <label for="student_number" class="form-label">Student Number</label>
                    <div class="input-group">
                        <span class="input-group-text"><i data-lucide="user"></i></span>
                        <input type="text" class="form-control" id="student_number" name="student_number" placeholder="Your student number" required>
                    </div>
                </div>
                <div class="mb-4">
                    <label for="password" class="form-label">Password</label>
                     <div class="input-group">
                        <span class="input-group-text"><i data-lucide="lock"></i></span>
                        <input type="password" class="form-control" id="password" name="password" placeholder="Your password" required
                               pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}"
                               title="Must contain at least one number, one uppercase and lowercase letter, one special character, and at least 8 or more characters">
                        <button class="btn btn-outline-secondary" type="button" id="togglePassword">
                            <i data-lucide="eye"></i>
                        </button>
                    </div>
                    <div class="text-end mt-2">
                        <a href="forgot_password.php" class="text-decoration-none small">Forgot password?</a>
                    </div>
                </div>
                <div class="d-grid">
                    <button type="submit" class="btn-primary-modern">
                        <i data-lucide="log-in" class="me-2"></i>Sign In
                    </button>
                </div>
            </form>
            <hr class="my-4">
            <p class="text-center text-muted">Don't have an account? <a href="register.php">Register now</a></p>
        </div>
    </div>
    <script>
        lucide.createIcons();

        // Password Toggle
        const togglePassword = document.querySelector('#togglePassword');
        const password = document.querySelector('#password');
        const eyeIcon = togglePassword.querySelector('i');

        togglePassword.addEventListener('click', function () {
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            
            if (type === 'password') {
                eyeIcon.setAttribute('data-lucide', 'eye');
            } else {
                eyeIcon.setAttribute('data-lucide', 'eye-off');
            }
            lucide.createIcons();
        });

        // Dark Mode Toggle
        (function() {
            const themeToggle = document.getElementById('theme-toggle');
            const currentTheme = localStorage.getItem('theme') || 'light';

            if (currentTheme === 'dark') {
                document.body.classList.add('dark-mode');
            }

            themeToggle.addEventListener('click', function() {
                document.body.classList.toggle('dark-mode');
                let theme = 'light';
                if (document.body.classList.contains('dark-mode')) {
                    theme = 'dark';
                }
                localStorage.setItem('theme', theme);
                lucide.createIcons(); // Re-render icons if needed
            });
        })();
    </script>
</body>
</html>
