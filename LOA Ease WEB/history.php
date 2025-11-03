<?php
session_start();
if (!isset($_SESSION['user_id'])) {
    header('Location: login.php');
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Transaction History - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css"> 
    <style>
       .history-item { 
           border-bottom: 1px solid var(--hr-color); 
           background-color: transparent !important; 
        } 
       .history-item:last-child { border-bottom: none; }

       .list-group-item {
            transition: background-color 0.3s ease; 
       }

       @media (max-width: 768px) {
            .fw-bold {
                font-size: 1.25rem;
            }
            .history-item h5 {
                font-size: 1rem;
            }
            .history-item p, .history-item small {
                font-size: 0.9rem;
            }
       }
    </style>
</head>
<body>
    <div class="container py-5">
    <div class="styled-card" style="max-width: 800px; margin: auto;">
        <div class="card-content">
            
            <div class="theme-toggle" id="theme-toggle" title="Toggle theme">
                <i data-lucide="moon" class="icon-moon"></i>
                <i data-lucide="sun" class="icon-sun"></i>
            </div>

            <div class="d-flex justify-content-between align-items-center mb-4">
                <h3 class="mb-0 fw-bold">Transaction History</h3>
                <a href="dashboard.php" class="btn btn-outline-secondary btn-sm me-5">
                    <i data-lucide="arrow-left" style="width:16px; height:16px;"></i> Back to Dashboard
                </a>
            </div>
            
            <div id="history-list" class="list-group list-group-flush"> 
                <div class="text-center p-5">
                    <div class="spinner-border text-primary" role="status"></div>
                    <p class="mt-3 text-muted">Loading your history...</p> 
                </div>
            </div>
        </div>
    </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function() {
            
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
            

            const historyList = document.getElementById('history-list');

            fetch('api/get_history.php')
                .then(response => response.json())
                .then(data => {
                    historyList.innerHTML = '';
                    if (data.success && data.history.length > 0) {
                        data.history.forEach(ticket => {
                            const statusBadges = {
                                'waiting': { bg: 'secondary', text: 'Waiting' },
                                'scheduled': { bg: 'info', text: 'Scheduled' },
                                'serving': { bg: 'primary', text: 'Serving' },
                                'completed': { bg: 'success', text: 'Completed' },
                                'cancelled': { bg: 'danger', text: 'Cancelled' },
                                'no-show': { bg: 'warning', text: 'No-Show' },
                                'expired': { bg: 'danger', text: 'Expired' } 
                            };  
                            const statusInfo = statusBadges[ticket.status] || { bg: 'dark', text: 'Unknown' };

                            const item = document.createElement('div');
                            
                            item.className = 'list-group-item flex-column align-items-start p-3 history-item'; 
                            
                            const schedule = new Date(ticket.schedule_datetime);
                            const formattedSchedule = schedule.toLocaleString('en-US', { month: 'long', day: 'numeric', year: 'numeric' }); 

                            
                            const createdAt = new Date(ticket.created_at);
                            const formattedCreatedAt = createdAt.toLocaleString('en-US', { hour: 'numeric', minute: '2-digit', hour12: true });


                            
                            let displayPurpose = ticket.purpose.split(',').map(p => p.trim());
                            let mainPurpose = displayPurpose.find(p => !p.startsWith('doc_req:')) || displayPurpose[0] || 'N/A';
                            mainPurpose = mainPurpose.replace('doc_req:', 'Doc Request: '); 
                            let additionalPurposes = displayPurpose.length > 1 ? ` (+${displayPurpose.length - 1} more)` : '';


                            item.innerHTML = `
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-1 fw-bold text-primary">${ticket.queue_number}</h5>
                                    <span class="badge bg-${statusInfo.bg}">${statusInfo.text}</span>
                                </div>
                                <div class="mb-1 text-muted"><small><strong>Purpose:</strong> ${mainPurpose}${additionalPurposes}</small></div>
                                <div class="mb-1 text-muted"><small><strong>Counter:</strong> ${ticket.counter_name}</small></div>
                                <small class="text-muted"><strong>Date:</strong> ${formattedSchedule} at ${formattedCreatedAt}</small> 
                            `;
                            historyList.appendChild(item);
                        });
                    } else {
                        historyList.innerHTML = `
                            <div class="text-center p-5">
                                <i data-lucide="folder-x" class="text-muted" style="width:64px; height:64px;"></i>
                                <h4 class="mt-3">No History Found</h4>
                                <p class="text-muted">You haven't created any queue tickets yet.</p>
                            </div>
                        `;
                    }
                    lucide.createIcons(); 
                })
                .catch(error => {
                    console.error('Error fetching history:', error);
                    historyList.innerHTML = '<div class="alert alert-danger">Could not load your transaction history.</div>';
                    lucide.createIcons(); 
                });
        });
        lucide.createIcons(); 
    </script>
</body>
</html>

