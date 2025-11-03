<?php
session_start();

if (!isset($_SESSION['kiosk_queue_number'])) {
    header('Location: kiosk.php');
    exit();
}

$queue_number = $_SESSION['kiosk_queue_number'];
unset($_SESSION['kiosk_queue_number']);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Your Kiosk Ticket - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        .card-content {
            transition: opacity 0.5s ease-in-out;
        }
    </style>
</head>
<body>
    <div class="container my-5">
        <div class="modern-card text-center" style="max-width: 500px; margin: auto;">
            <div class="card-content" id="card-content">
                <div id="ticket-view">
                    <h2 class="fw-bold mb-3">Your Queue Ticket</h2>
                    <p class="text-muted fs-5">Please wait for your number to be called on the display screen.</p>
                    
                    <div class="bg-light p-4 rounded-3 mb-4 border">
                        <h1 class="display-1 fw-bolder text-primary mb-0"><?php echo htmlspecialchars($queue_number); ?></h1>
                    </div>

                    <img src="https://api.qrserver.com/v1/create-qr-code/?size=180x180&data=<?php echo urlencode($queue_number); ?>&qzone=1" alt="QR Code" class="img-fluid rounded-3">
                </div>

                <div id="thank-you-view" style="display: none;">
                    <i data-lucide="check-circle" class="text-success" style="width: 100px; height: 100px;"></i>
                    <h1 class="display-4 fw-bold mt-3">Thank You!</h1>
                    <p class="fs-4 text-muted">Redirecting back to the home screen...</p>
                </div>

            </div>
        </div>
    </div>
    <script>
        lucide.createIcons();

        document.addEventListener('DOMContentLoaded', function() {
            const cardContent = document.getElementById('card-content');
            const ticketView = document.getElementById('ticket-view');
            const thankYouView = document.getElementById('thank-you-view');


            setTimeout(function() {
                

                cardContent.style.opacity = '0';


                setTimeout(function() {

                    ticketView.style.display = 'none';
                    thankYouView.style.display = 'block';


                    cardContent.style.opacity = '1';
                    lucide.createIcons();

                    setTimeout(function() {
                        

                        window.location.href = 'kiosk.php';

                    }, 3000); 

                }, 500); 

            }, 5000); 
        });
    </script>
</body>
</html>