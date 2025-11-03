<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin Check-In - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
        body {
            font-family: 'Poppins', sans-serif;
            background-color: #f4f7f9;
        }
        #qr-reader {
            width: 100%;
            max-width: 500px;
            margin: auto;
            border: 2px dashed #003366;
            border-radius: 1rem;
            display: none;
        }
        .styled-card {
            background: #ffffff;
            border-radius: 1.5rem;
            box-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.1);
            animation: fadeInFromBottom 1s ease-out;
        }
        @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px); } to { opacity: 1; transform: translateY(0); } }
    </style>
</head>
<body>

<div class="container py-5">
    <div class="styled-card" style="max-width: 600px; margin: auto;">
        <div class="card-body p-4 p-md-5">
            <div class="text-center mb-4">
                <h2 class="fw-bold">Kiosk Check-In</h2>
                <p class="text-muted">Scan a QR code or enter a queue number to check in a student.</p>
            </div>

            <div id="message-container" class="mb-3"></div>

            <div class="text-center">
                <div id="qr-reader" class="mb-3"></div>
                <button id="start-scan-btn" class="btn btn-primary w-100 mb-2">
                    <i data-lucide="scan-line" class="me-2"></i>Start QR Scanner
                </button>
                <button id="stop-scan-btn" class="btn btn-secondary w-100 mb-3" style="display: none;">
                    <i data-lucide="camera-off" class="me-2"></i>Stop Scanner
                </button>
            </div>

            <hr>

            <form id="checkin-form">
                <div class="mb-3">
                    <label for="queue_number_input" class="form-label fw-bold">Or Enter Queue Number Manually</label>
                    <div class="input-group">
                        <input type="text" class="form-control" id="queue_number_input" placeholder="e.g., CCS-0916-001" required>
                        <button class="btn btn-success" type="submit">
                            <i data-lucide="log-in" class="me-1"></i> Check In
                        </button>
                    </div>
                </div>
            </form>

        </div>
    </div>
</div>

<script src="https://unpkg.com/html5-qrcode" type="text/javascript"></script>
<script>
    lucide.createIcons();
    const messageContainer = document.getElementById('message-container');
    const qrReaderDiv = document.getElementById('qr-reader');
    const startScanBtn = document.getElementById('start-scan-btn');
    const stopScanBtn = document.getElementById('stop-scan-btn');
    const checkinForm = document.getElementById('checkin-form');
    const queueNumberInput = document.getElementById('queue_number_input');

    let html5QrCode;

    // --- Function to handle the check-in API call ---
    function checkInStudent(queueNumber) {
        messageContainer.innerHTML = `<div class="alert alert-info">Checking in ${queueNumber}...</div>`;
        
        fetch('api/check_in.php', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ queue_number: queueNumber })
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                messageContainer.innerHTML = `<div class="alert alert-success">${data.message}</div>`;
                queueNumberInput.value = '';
            } else {
                messageContainer.innerHTML = `<div class="alert alert-danger">${data.message}</div>`;
            }
        })
        .catch(error => {
            console.error('Error:', error);
            messageContainer.innerHTML = `<div class="alert alert-danger">An network error occurred.</div>`;
        });
    }

    // --- QR Code Scanner Logic ---
    function onScanSuccess(decodedText, decodedResult) {
        console.log(`Code matched = ${decodedText}`, decodedResult);
        checkInStudent(decodedText);
        stopScanner(); // Stop scanning after a successful scan
    }

    function onScanFailure(error) {
        // console.warn(`Code scan error = ${error}`);
    }

    function startScanner() {
        html5QrCode = new Html5Qrcode("qr-reader");
        qrReaderDiv.style.display = 'block';
        startScanBtn.style.display = 'none';
        stopScanBtn.style.display = 'inline-block';
        
        html5QrCode.start(
            { facingMode: "environment" },
            { fps: 10, qrbox: { width: 250, height: 250 } },
            onScanSuccess,
            onScanFailure
        ).catch(err => {
            messageContainer.innerHTML = `<div class="alert alert-danger">Could not start scanner. Please grant camera permissions.</div>`;
            stopScanner();
        });
    }

    function stopScanner() {
        if (html5QrCode && html5QrCode.isScanning) {
            html5QrCode.stop().then(() => {
                console.log("QR Code scanning stopped.");
            }).catch(err => {
                console.error("Failed to stop scanning.", err);
            });
        }
        qrReaderDiv.style.display = 'none';
        startScanBtn.style.display = 'inline-block';
        stopScanBtn.style.display = 'none';
    }

    startScanBtn.addEventListener('click', startScanner);
    stopScanBtn.addEventListener('click', stopScanner);

    // --- Manual Form Logic ---
    checkinForm.addEventListener('submit', function(e) {
        e.preventDefault();
        const queueNumber = queueNumberInput.value.trim();
        if (queueNumber) {
            checkInStudent(queueNumber);
        }
    });

</script>
</body>
</html>