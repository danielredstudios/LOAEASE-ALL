<?php
require_once 'includes/db_connect.php';
session_start();

if (isset($_SESSION['user_id'])) {
    header("Location: dashboard.php");
    exit();
}

$token = $_GET['token'] ?? '';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Reset Password - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        body {
            display: flex;
            justify-content: center; 
            align-items: center; 
            min-height: 100vh; 
            padding: 1rem;
        }
        .styled-card .card-content { 
            padding: 3rem; 
        }
         .btn-primary-modern {
             padding: 0.8rem 2rem;
        }
        @media (max-width: 576px) {
            .styled-card .card-content {
                padding: 2rem;
            }
        }
    </style>
</head>
<body>
    <div class="theme-toggle" id="theme-toggle" title="Toggle theme">
        <i data-lucide="moon" class="icon-moon"></i>
        <i data-lucide="sun" class="icon-sun"></i>
    </div>

    <div class="styled-card" style="max-width: 500px;">
        <div class="card-content">
        
            <?php if (empty($token)): ?>
                <div class="text-center">
                    <i data-lucide="alert-triangle" class="text-danger" style="width: 64px; height: 64px;"></i>
                    <h2 class="fw-bold mt-3">Invalid Link</h2>
                    <p class="text-muted">This password reset link appears to be missing or invalid. Please request a new link from the "Forgot Password" page.</p>
                    <div id="message"></div>
                    <a href="forgot_password.php" class="btn btn-primary-modern mt-3">
                        <i data-lucide="arrow-left" class="me-2"></i>Back to Forgot Password
                    </a>
                </div>

            <?php else: ?>
                <div class="text-center mb-4">
                    <h2 class="fw-bold">Reset Your Password</h2>
                    <p class="text-muted">Enter and confirm your new password below.</p>
                </div>
                <div id="message"></div>
                <form id="resetPasswordForm">
                    <input type="hidden" name="token" value="<?php echo htmlspecialchars($token); ?>">
                    <div class="mb-3">
                        <label for="password" class="form-label">New Password</label>
                        <div class="input-group">
                            <span class="input-group-text"><i data-lucide="lock"></i></span>
                            <input type="password" class="form-control" id="password" name="password" placeholder="New password" required
                                   pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}"
                                   title="Must contain at least one number, one uppercase and lowercase letter, one special character, and at least 8 or more characters">
                            <button class="btn btn-outline-secondary" type="button" id="togglePassword">
                                <i data-lucide="eye"></i>
                            </button>
                        </div>
                    </div>
                    <div class="mb-4">
                        <label for="confirm_password" class="form-label">Confirm New Password</label>
                         <div class="input-group">
                            <span class="input-group-text"><i data-lucide="lock"></i></span>
                            <input type="password" class="form-control" id="confirm_password" name="confirm_password" placeholder="Confirm new password" required>
                            <button class="btn btn-outline-secondary" type="button" id="toggleConfirmPassword">
                                <i data-lucide="eye"></i>
                            </button>
                        </div>
                    </div>
                    <div class="d-grid">
                        <button type="submit" class="btn-primary-modern">
                            <i data-lucide="save" class="me-2"></i>Reset Password
                        </button>
                    </div>
                </form>
            <?php endif; ?>

        </div>
    </div>
    <script>
        lucide.createIcons();
        
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
            lucide.createIcons();
        });

        function setupPasswordToggle(toggleId, passwordId) {
            const toggleButton = document.getElementById(toggleId);
            const passwordInput = document.getElementById(passwordId);
            const eyeIcon = toggleButton.querySelector('i');

            if (toggleButton && passwordInput) {
                toggleButton.addEventListener('click', function () {
                    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
                    passwordInput.setAttribute('type', type);
                    
                    if (type === 'password') {
                        eyeIcon.setAttribute('data-lucide', 'eye');
                    } else {
                        eyeIcon.setAttribute('data-lucide', 'eye-off');
                    }
                    lucide.createIcons();
                });
            }
        }

        setupPasswordToggle('togglePassword', 'password');
        setupPasswordToggle('toggleConfirmPassword', 'confirm_password');
        
        const resetPasswordForm = document.getElementById('resetPasswordForm');
        if (resetPasswordForm) {
            resetPasswordForm.addEventListener('submit', function(e) {
                e.preventDefault();
                const form = e.target;
                const formData = new FormData(form);
                const messageDiv = document.getElementById('message');
                const password = formData.get('password');
                const confirm_password = formData.get('confirm_password');
                const submitButton = form.querySelector('button[type="submit"]');

                if (password !== confirm_password) {
                    messageDiv.innerHTML = `<div class="alert alert-warning">Passwords do not match.</div>`;
                    return;
                }
                
                submitButton.disabled = true;
                submitButton.innerHTML = '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>Resetting...';

                fetch('api/password_reset.php', {
                    method: 'POST',
                    body: formData
                })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        messageDiv.innerHTML = `<div class="alert alert-success">${data.message} You can now <a href="login.php" class="alert-link">login</a>.</div>`;
                        form.reset();
                        form.style.display = 'none';
                    } else {
                        messageDiv.innerHTML = `<div class="alert alert-danger">${data.message}</div>`;
                        submitButton.disabled = false;
                        submitButton.innerHTML = '<i data-lucide="save" class="me-2"></i>Reset Password';
                        lucide.createIcons();
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    messageDiv.innerHTML = `<div class="alert alert-danger">An unexpected network error occurred.</div>`;
                    submitButton.disabled = false;
                    submitButton.innerHTML = '<i data-lucide="save" class="me-2"></i>Reset Password';
                    lucide.createIcons();
                });
            });
        }
    </script>
</body>
</html>
