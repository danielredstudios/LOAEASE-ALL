<?php
session_start();
// If the user is already logged in, redirect them to the dashboard
if (isset($_SESSION['user_id'])) {
    header("Location: dashboard.php");
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Forgot Password - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css"> <!-- Link to your main stylesheet -->
    <style>
        /* Styles to center the card, matching the login page */
        body {
            display: flex;
            justify-content: center; 
            align-items: center; 
            min-height: 100vh; 
            padding: 1rem;
        }
        /* Use styled-card to match the new design */
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

    <div class="styled-card" style="max-width: 500px;"> <!-- Use styled-card -->
        <div class="card-content">
            <div class="text-center mb-4">
                <h2 class="fw-bold">Forgot Password?</h2>
                <p class="text-muted">Enter your school email to receive a password reset link.</p>
            </div>

            <div id="message"></div>

            <form id="forgotPasswordForm">
                <div class="mb-4">
                    <label for="email" class="form-label">Email Address</label>
                    <div class="input-group">
                        <span class="input-group-text"><i data-lucide="mail"></i></span>
                        <input type="email" class="form-control" id="email" name="email" placeholder="e.g., CXXXX-XX@itmlyceum.onmicrosoft.com" required>
                    </div>
                </div>
                <div class="d-grid">
                    <button type="submit" class="btn-primary-modern">
                        <i data-lucide="send" class="me-2"></i>Send Reset Link
                    </button>
                </div>
            </form>
            <hr class="my-4">
            <p class="text-center text-muted">Remembered your password? <a href="login.php">Login here</a></p>
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

        document.getElementById('forgotPasswordForm').addEventListener('submit', function(e) {
            e.preventDefault();
            const form = e.target;
            const formData = new FormData(form);
            const messageDiv = document.getElementById('message');
            const submitButton = form.querySelector('button[type="submit"]');


            submitButton.disabled = true;
            submitButton.innerHTML = '<span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>Sending...';

            fetch('api/password_reset.php', {
                method: 'POST',
                body: formData
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    messageDiv.innerHTML = `<div class="alert alert-success">${data.message}</div>`;
                    form.reset();
                } else {
                    messageDiv.innerHTML = `<div class="alert alert-danger">${data.message}</div>`;
                }
            })
            .catch(error => {
                console.error('Error:', error);
                messageDiv.innerHTML = `<div class="alert alert-danger">An unexpected network error occurred.</div>`;
            })
            .finally(() => {
 
                submitButton.disabled = false;
                submitButton.innerHTML = '<i data-lucide="send" class="me-2"></i>Send Reset Link';
                lucide.createIcons();
            });
        });
    </script>
</body>
</html>

