<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Live Queue - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
        :root {
            --loa-blue: #003366; --loa-yellow: #FFC72C; --loa-blue-light: #0055a4;
            --light-bg: #eef2f7; --dark-text: #212529; --card-bg: rgba(255, 255, 255, 0.85);
            --card-shadow: 0 8px 32px 0 rgba(0, 51, 102, 0.2); --font-family: 'Poppins', sans-serif;
        }
        body {
            font-family: var(--font-family); background: linear-gradient(-45deg, var(--light-bg), var(--loa-blue-light), var(--light-bg), var(--loa-blue));
            background-size: 400% 400%; animation: gradientBG 15s ease infinite; 
            min-height: 100vh; padding: 2rem;
        }
        @keyframes gradientBG { 0% { background-position: 0% 50%; } 50% { background-position: 100% 50%; } 100% { background-position: 0% 50%; } }
        .styled-card {
            background: var(--card-bg); border-radius: 1.5rem; border: 1px solid rgba(255, 255, 255, 0.2);
            box-shadow: var(--card-shadow); backdrop-filter: blur(15px); -webkit-backdrop-filter: blur(15px);
            width: 100%; overflow: hidden; animation: fadeInFromBottom 1s ease-out;
        }
        @keyframes fadeInFromBottom { from { opacity: 0; transform: translateY(40px) scale(0.95); } to { opacity: 1; transform: translateY(0) scale(1); } }
        .card-serving { border: 2px solid #28a745; box-shadow: 0 0 25px rgba(40, 167, 69, 0.4); }
        .page-title { color: #fff; text-shadow: 0 2px 4px rgba(0,0,0,0.3); }
    </style>
</head>
<body>
<div class="container-fluid">
    <div class="text-center mb-5">
        <h1 class="fw-bold page-title">Live University Queue</h1>
        <p class="fs-5" style="color: #eee;">Now Serving at Lyceum of Alabang</p>
        <p style="color: #eee;"><i data-lucide="refresh-cw" class="me-2" style="width:16px;height:16px;"></i>Status updates automatically</p>
    </div>

    <div id="live-status-board" class="row justify-content-center">
        <div class="col-12 text-center p-5">
            <div class="spinner-border text-light" style="width: 3rem; height: 3rem;" role="status"></div>
            <p class="mt-3 text-light">Fetching live queue status...</p>
        </div>
    </div>
</div>

<script>
function fetchLiveStatus() {
    fetch('api/get_live_status.php')
        .then(response => response.json())
        .then(data => {
            const board = document.getElementById('live-status-board');
            board.innerHTML = ''; 

            if (data.counters && data.counters.length > 0) {
                data.counters.forEach(counter => {
                    const isServing = counter.serving_number;
                    const cardClass = isServing ? 'card-serving' : '';
                    const servingNumber = isServing || '---';
                    const statusText = isServing ? 'Now Serving' : 'Idle';

                    const cardHtml = `
                        <div class="col-lg-4 col-md-6 mb-4">
                            <div class="styled-card text-center h-100 ${cardClass}" style="transition: all 0.3s ease;">
                                <div class="card-header bg-transparent border-bottom-0 pt-4">
                                    <h4 class="mb-0 fw-bold">${counter.counter_name}</h4>
                                </div>
                                <div class="card-body p-4">
                                    <p class="text-uppercase fw-bold ${isServing ? 'text-success' : 'text-muted'}">${statusText}</p>
                                    <h1 class="display-2 fw-bolder my-3" style="font-size: 5rem;">${servingNumber}</h1>
                                </div>
                                <div class="card-footer bg-transparent border-top-0 pb-3">
                                    <span class="badge bg-secondary-subtle text-secondary-emphasis rounded-pill fs-6">
                                        <i data-lucide="users" style="width:16px;height:16px;" class="me-1"></i>
                                        ${counter.waiting_count} Waiting
                                    </span>
                                </div>
                            </div>
                        </div>
                    `;
                    board.innerHTML += cardHtml;
                });
            } else {
                board.innerHTML = '<div class="col-12 text-center"><p class="fs-4 text-light">No counters are currently active.</p></div>';
            }
            lucide.createIcons();
        })
        .catch(error => {
            console.error('Error fetching status:', error);
            document.getElementById('live-status-board').innerHTML = '<div class="col-12 text-center alert alert-danger">Could not load live status.</div>';
        });
}

document.addEventListener('DOMContentLoaded', () => {
    fetchLiveStatus();
    setInterval(fetchLiveStatus, 5000);
    lucide.createIcons();
});
</script>

</body>
</html>