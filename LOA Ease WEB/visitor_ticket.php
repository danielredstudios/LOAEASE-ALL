<?php
session_start();
if (!isset($_SESSION['visitor_queue_number'])) {
    header('Location: visitor_login.php');
    exit();
}
$queue_number = $_SESSION['visitor_queue_number'];
unset($_SESSION['visitor_queue_number']);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Your Visitor Ticket - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="container my-5">
        <div class="modern-card text-center" style="max-width: 500px; margin: auto;">
            <div class="card-content">
                <h2 class="fw-bold mb-3">Your Visitor Queue Ticket</h2>
                <div class="bg-light p-4 rounded-3 mb-4 border">
                    <h1 class="display-1 fw-bolder text-primary mb-0"><?php echo htmlspecialchars($queue_number); ?></h1>
                    <p class="text-muted mb-0">Present this number or the QR code</p>
                </div>

                <img src="https://api.qrserver.com/v1/create-qr-code/?size=180x180&data=<?php echo urlencode($queue_number); ?>&qzone=1" alt="QR Code" class="img-fluid rounded-3 mb-4">

                <p class="text-muted">If you are enrolling, please present this number during registration.</p>
                <a href="index.php" class="btn btn-secondary mt-3">Back to Home</a>
            </div>
        </div>
    </div>
    <script>
        lucide.createIcons();
    </script>
</body>
</html>