<?php
session_start();
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
    <title>Welcome to LOA-EASE Queuing</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
        :root {
            --loa-blue: #003366; --loa-yellow: #FFC72C; --loa-blue-light: #0055a4;
            --light-bg: #eef2f7; --dark-text: #212529; --card-bg: rgba(255, 255, 255, 0.7);
            --card-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); --font-family: 'Poppins', sans-serif;
        }
        body {
            font-family: var(--font-family);
            background: linear-gradient(-45deg, var(--light-bg), var(--loa-blue-light), var(--light-bg), var(--loa-blue));
            background-size: 400% 400%;
            animation: gradientBG 15s ease infinite;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 1rem;
        }
        @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } }
        .landing-card {
            background: var(--card-bg);
            border-radius: 1.5rem;
            border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: var(--card-shadow);
            backdrop-filter: blur(25px);
            -webkit-backdrop-filter: blur(25px);
            max-width: 950px;
            width: 100%;
            overflow: hidden;
            animation: fadeInFromBottom 1s ease-out;
        }
        @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } }
        .card-content { padding: 4rem; }
        .logo-text {
            font-weight: 700; font-size: 1.75rem; color: var(--loa-blue);
        }
        .logo-text i { color: var(--loa-yellow); }
        h1 {
            font-weight: 800; font-size: 3.5rem; color: var(--dark-text); margin-top: 1rem;
        }
        .lead { font-size: 1.25rem; color: #495057; }
        .btn-group-modern {
            border-radius: 50px;
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 1rem;
        }
        .btn-primary-modern {
            background: var(--loa-blue); border: none;
            font-weight: 600; color: white; transition: all 0.3s ease;
            width: 100%;
        }
        .btn-primary-modern:hover {
            background-color: var(--loa-yellow); color: var(--loa-blue);
        }
        .btn-visitor {
            border: none;
            background: transparent;
            color: #6c757d;
            font-weight: 500;
            width: 100%;
        }
        .btn-visitor:hover {
            background: #e9ecef;
        }
        .illustration-pane {
            display: flex; align-items: center; justify-content: center;
            background: linear-gradient(160deg, var(--loa-blue) 0%, var(--loa-blue-light) 100%);
            padding: 2rem;
        }
        .illustration-pane img { max-width: 100%; height: auto; }
        
        @media (min-width: 576px) {
            .btn-group-modern {
                flex-direction: row;
                border: 1px solid #dee2e6;
                display: inline-flex;
                overflow: hidden;
            }
            .btn-primary-modern, .btn-visitor {
                width: auto;
            }
        }

        @media (max-width: 768px) {
            .illustration-pane { display: none; }
            .card-content { padding: 2rem; }
            h1 { font-size: 2.2rem; }
            .lead { font-size: 1rem; }
        }
    </style>
</head>
<body>
    <div class="landing-card">
        <div class="row g-0">
            <div class="col-md-7">
                <div class="card-content text-center text-md-start">
                    <p class="logo-text d-flex align-items-center justify-content-center justify-content-md-start">
                        <i data-lucide="shield-check" class="me-2"></i>LOA-EASE
                    </p>
                    <h1 class="display-4 my-3">Your Time Matters.</h1>
                    <p class="lead mb-4">
                        Lyceum of Alabang's official smart queuing system. Schedule your appointments online and step into efficiency.
                    </p>
                    <div class="btn-group-modern">
                        <a href="login.php" class="btn btn-primary-modern d-inline-flex align-items-center justify-content-center px-4 py-2">
                            Proceed to Queueing
                            <i data-lucide="arrow-right" class="ms-2"></i>
                        </a>
                    </div>
                </div>
            </div>
            <div class="col-md-5 illustration-pane">
                 <img src="images/QueuingManagementIllustration.png" alt="Queue Management Illustration">
            </div>
        </div>
    </div>
    <script>
        lucide.createIcons();
    </script>
</body>
</html>