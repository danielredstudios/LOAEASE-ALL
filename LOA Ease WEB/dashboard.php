<?php
require_once 'includes/db_connect.php';
session_start();
if (!isset($_SESSION['user_id'])) {
    header('Location: login.php');
    exit();
}

if (!isset($_SESSION['full_name']) || !isset($_SESSION['student_number'])) {
    $stmt = $conn->prepare("SELECT CONCAT(first_name, ' ', last_name) as full_name, student_number FROM students WHERE student_id = ?");
    $stmt->bind_param("i", $_SESSION['student_id']);
    $stmt->execute();
    $result = $stmt->get_result()->fetch_assoc();
    if ($result) {
        $_SESSION['full_name'] = $result['full_name'];
        $_SESSION['student_number'] = $result['student_number'];
    }
    $stmt->close();
}

date_default_timezone_set('Asia/Manila');
$current_hour = date('G');
$greeting = 'Good evening';
if ($current_hour < 12) {
    $greeting = "Good morning";
} elseif ($current_hour < 18) {
    $greeting = "Good afternoon";
}
$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fetch/3.6.2/fetch.min.js"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        .purpose-badge { font-size: 0.9em; padding: 0.5em 0.75em; }
        #active_ticket_notification { display: none; animation: fadeInFromBottom 0.8s ease-out; }
        
        .lane-status-compact {
            background: linear-gradient(135deg, var(--input-bg) 0%, rgba(255,255,255,0.1) 100%);
            border-radius: 1rem;
            padding: 1rem 1.5rem;
            margin-bottom: 1.5rem;
            border: 1px solid rgba(255,255,255,0.1);
        }
        
        .lane-status-header {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 1rem;
        }
        
        .lane-status-title {
            font-size: 1rem;
            font-weight: 600;
            color: var(--text-color);
            margin: 0;
            display: flex;
            align-items: center;
            gap: 0.5rem;
        }
        
        .lane-status-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(140px, 1fr));
            gap: 0.75rem;
        }
        
        .lane-status-item {
            background: rgba(255,255,255,0.05);
            border-radius: 0.75rem;
            padding: 0.75rem;
            text-align: center;
            transition: transform 0.2s ease;
        }
        
        .lane-status-item:hover {
            transform: translateY(-2px);
        }
        
        .lane-status-indicator {
            width: 100%;
            height: 8px;
            border-radius: 4px;
            margin-bottom: 0.5rem;
            background-color: #e9ecef;
        }
        
        .lane-name {
            font-weight: 600;
            font-size: 0.85rem;
            margin-bottom: 0.25rem;
            color: var(--text-color);
        }
        
        .lane-status-text {
            font-size: 0.75rem;
            color: var(--text-muted);
            opacity: 0.8;
        }

        .btn-link {
            text-decoration: none;
            color: var(--link-color);
        }
        .btn-link:hover {
            color: var(--link-hover);
        }
        
        @media (max-width: 576px) {
            .lane-status-compact {
                padding: 0.75rem 1rem;
                margin-bottom: 1rem;
            }
            
            .lane-status-grid {
                grid-template-columns: repeat(2, 1fr);
                gap: 0.5rem;
            }
            
            .lane-status-item {
                padding: 0.5rem;
            }
            
            .lane-status-indicator {
                height: 6px;
            }
            
            .lane-name {
                font-size: 0.75rem;
            }
            
            .lane-status-text {
                font-size: 0.7rem;
            }
        }
    </style>
</head>
<body>
    <div class="container py-5">
    <div class="styled-card" style="max-width: 700px; margin: auto;">
        <div class="card-content">
            
            <div class="theme-toggle" id="theme-toggle" title="Toggle theme">
                <i data-lucide="moon" class="icon-moon"></i>
                <i data-lucide="sun" class="icon-sun"></i>
            </div>

            <div class="text-center mb-4">
                <h2 class="fw-bold"><?php echo $greeting . ", " . htmlspecialchars(explode(' ', $_SESSION['full_name'])[0]); ?>!</h2>
                <p class="text-muted mb-0">Student Number: <?php echo htmlspecialchars($_SESSION['student_number']); ?></p>
            </div>
            
            <div class="lane-status-compact">
                <div class="lane-status-header">
                    <h3 class="lane-status-title">
                        <i data-lucide="activity" style="width: 16px; height: 16px;"></i>
                        Cashier Status
                    </h3>
                    <span class="badge bg-secondary" style="font-size: 0.7rem;">Live</span>
                </div>
                <div id="lane-status-graph" class="lane-status-grid">
                    <p class="text-muted text-center">Loading service status...</p>
                </div>
            </div>

            <div id="active_ticket_notification" class="text-center">
                <div class="alert alert-info d-flex flex-column align-items-center p-4">
                    <i data-lucide="ticket" class="mb-3" style="width:48px; height:48px;"></i>
                    <h4 class="alert-heading fw-bold">You Have an Active Ticket!</h4>
                    <p>You can view your ticket details or make changes to your appointment.</p>
                    <hr>
                    <div class="d-flex flex-wrap justify-content-center gap-2">
                        <button id="view_edit_button" class="btn btn-primary"><i data-lucide="edit-3" class="me-2"></i>View / Edit Your Ticket</button>
                         <a href="ticket.php" class="btn btn-outline-secondary"><i data-lucide="eye" class="me-2"></i>View QR Code</a>
                    </div>
                </div>
            </div>
            
            <div id="queue_form_container">
                <div class="text-center mb-4">
                    <div class="d-flex align-items-center justify-content-center">
                        <h3 class="mb-0 fw-bold" id="form_title">Get a Queue Ticket</h3>
                        <button type="button" class="btn btn-link btn-sm p-0 ms-2" data-bs-toggle="modal" data-bs-target="#howToQueueModal" title="How to queue?">
                            <i data-lucide="help-circle" style="width:20px; height:20px;"></i>
                        </button>
                    </div>
                    <p class="mb-0 text-muted">Schedule your visit easily</p>
                </div>
                <div id="message"></div>
                <div id="notification_permission_alert" class="alert alert-warning p-2 small" style="display: none; font-size: 0.8rem;"></div>
                <form id="queueForm">
                    <input type="hidden" name="student_id" value="<?php echo htmlspecialchars($_SESSION['student_id']); ?>">
                    <input type="hidden" name="queue_id" id="queue_id">

                    <div class="mb-2">
                        <label for="purpose_select" class="form-label">Purpose of Visit (Select one or more)</label>
                        <div class="input-group">
                             <span class="input-group-text"><i data-lucide="edit"></i></span>
                            <select class="form-select" id="purpose_select">
                                <option value="" disabled selected>-- Choose a purpose to add --</option>
                                <option value="Tuition Payment">Tuition Payment</option>
                                <option value="Document Request">Document Request</option>
                                <option value="Promissory Note">Promissory Note</option>
                                <option value="Enrollment Concern">Enrollment Concern</option>
                                <option value="Clearance Signing">Clearance Signing</option>
                                <option value="Others">Others</option>
                            </select>
                        </div>
                    </div>

                    <div id="selected_purposes_container" class="mb-3 border rounded p-2" style="min-height: 50px;"></div>
                    <input type="hidden" name="purpose" id="purpose_hidden">

                    <div class="mb-4">
                        <label for="schedule_datetime" class="form-label">Schedule Date</label>
                        <div class="input-group">
                             <span class="input-group-text"><i data-lucide="calendar-check"></i></span>
                            <input type="date" class="form-control" id="schedule_datetime" name="schedule_datetime" required>
                        </div>
                    </div>
                     <div class="mb-3 form-check">
                         <input type="checkbox" class="form-check-input" id="is_priority" name="is_priority" value="1">
                         <label class="form-check-label" for="is_priority">Priority Lane (For PWD, Senior Citizens, Pregnant Women)</label>
                     </div>
                    <div class="d-grid">
                        <button type="submit" class="btn-primary-modern" id="submit_button" style="padding: 0.8rem 2rem;"> 
                            <i data-lucide="ticket" class="me-2"></i><span id="button_text">Get My Ticket</span>
                        </button>
                    </div>
                </form>
            </div>
             <div class="text-center mt-4">
                <a href="logout.php" class="text-decoration-none">
                    <i data-lucide="log-out" style="width:16px; height:16px;"></i> Log Out
                </a>
                <span class="mx-2 text-muted">|</span>
                <a href="history.php" class="text-decoration-none">
                    <i data-lucide="history" style="width:16px; height:16px;"></i> View History
                </a>
            </div>
        </div>
    </div>
    </div>
    
    <div class="modal fade" id="docuRequestModal" tabindex="-1" aria-labelledby="docuRequestModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color: var(--card-bg); backdrop-filter: blur(10px);">
          <div class="modal-header" style="border-bottom-color: var(--input-border);">
            <h5 class="modal-title" id="docuRequestModalLabel">Select Documents to Request</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div id="document_checklist">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Diploma" id="doc_diploma">
                    <label class="form-check-label" for="doc_diploma">Diploma</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Transcript of Records (TOR)" id="doc_tor">
                    <label class="form-check-label" for="doc_tor">Transcript of Records (TOR)</label>
                </div>
                 <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="Good Moral Certificate" id="doc_gmc">
                    <label class="form-check-label" for="doc_gmc">Good Moral Certificate</label>
                </div>
            </div>
          </div>
          <div class="modal-footer" style="border-top-color: var(--input-border);">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            <button type="button" class="btn btn-primary" id="add_documents_btn">Add Selected</button>
          </div>
        </div>
      </div>
    </div>

    <div class="modal fade" id="notificationModal" tabindex="-1" aria-labelledby="notificationModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content border-0 shadow-lg" style="background: var(--card-bg);">
          <div class="modal-body text-center p-5">
            <i data-lucide="bell-ring" class="text-success mb-3" style="width: 80px; height: 80px;"></i>
            <h2 class="modal-title fw-bold" id="notificationModalLabel">It's Your Turn!</h2>
            <h1 class="display-2 fw-bolder text-primary my-3" id="modal_queue_number">---</h1>
            <p class="fs-5">Please proceed to <strong id="modal_counter_name">---</strong>.</p>
            <button type="button" class="btn btn-success mt-3" data-bs-dismiss="modal">Okay, I'm Going</button>
          </div>
        </div>
      </div>
    </div>

    <div class="modal fade" id="howToQueueModal" tabindex="-1" aria-labelledby="howToQueueModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content" style="background-color: var(--card-bg); backdrop-filter: blur(10px);">
          <div class="modal-header" style="border-bottom-color: var(--input-border);">
            <h5 class="modal-title d-flex align-items-center fw-bold" id="howToQueueModalLabel">
                <i data-lucide="info" class="me-2"></i>How to Queue
            </h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body" style="padding: 1.5rem 2rem;">
            <div class="d-flex align-items-start p-2">
                <strong class="fs-4 me-3 text-primary" style="color: var(--link-color) !important;">1.</strong>
                <div>
                    <h6 class="fw-bold">Schedule Your Appointment</h6>
                    <p class="text-muted small">Select your purpose(s) and choose a future date to get your ticket.</p>
                </div>
            </div>
            <hr style="margin: 1rem 0; color: var(--hr-color);">
            <div class="d-flex align-items-start p-2">
                <strong class="fs-4 me-3 text-primary" style="color: var(--link-color) !important;">2.</strong>
                <div>
                    <h6 class="fw-bold">Check-In On-Site</h6>
                    <p class="text-muted small mb-0">On your scheduled date, go to an on-site kiosk and scan your ticket's QR code (or enter the queue number) to enter the priority queue.</p>
                </div>
            </div>
          </div>
          <div class="modal-footer" style="border-top-color: var(--input-border);">
            <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Got it!</button>
          </div>
        </div>
      </div>
    </div>

    <audio id="notification-sound" src="/Music/CLICKONQUEUING.mp3" preload="auto"></audio>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        lucide.createIcons();
        
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

            const purposeSelect = document.getElementById('purpose_select');
            const selectedContainer = document.getElementById('selected_purposes_container');
            const hiddenInput = document.getElementById('purpose_hidden');
            const docuRequestModal = new bootstrap.Modal(document.getElementById('docuRequestModal'));
            const scheduleInput = document.getElementById('schedule_datetime');
            const queueForm = document.getElementById('queueForm');
            const messageDiv = document.getElementById('message');
            const queueIdInput = document.getElementById('queue_id');
            const notificationDiv = document.getElementById('active_ticket_notification');
            const formContainerDiv = document.getElementById('queue_form_container');
            const viewEditButton = document.getElementById('view_edit_button');
            const priorityCheckbox = document.getElementById('is_priority');
            
            const notificationModal = new bootstrap.Modal(document.getElementById('notificationModal'));
            const notificationSound = document.getElementById('notification-sound');
            const notificationPermissionAlert = document.getElementById('notification_permission_alert');
            
            let selectedPurposes = [];
            let currentTicketStatus = null;
            let statusCheckInterval = null;
            let currentLaneStatus = {};

            
            function primeAudio() {
                notificationSound.play().then(() => {
                    notificationSound.pause();
                    notificationSound.currentTime = 0;
                }).catch(e => {});
                
                document.removeEventListener('click', primeAudio);
                document.removeEventListener('touchstart', primeAudio);
            }
            document.addEventListener('click', primeAudio, { once: true });
            document.addEventListener('touchstart', primeAudio, { once: true });


            if ('Notification' in window) {
                if (Notification.permission === 'granted') {
                
                } else if (Notification.permission === 'denied') {
                    notificationPermissionAlert.innerHTML = '<i data-lucide="bell-off" style="width:14px; height: 14px; margin-right: 8px;"></i>Browser notifications are blocked. Please enable them in your browser settings to get alerts.';
                    notificationPermissionAlert.style.display = 'block';
                    lucide.createIcons();
                } else {
                    
                    Notification.requestPermission().then(permission => {
                        if (permission === 'denied') {
                            notificationPermissionAlert.innerHTML = '<i data-lucide="bell-off" style="width:14px; height: 14px; margin-right: 8px;"></i>Browser notifications are blocked. Please enable them in your browser settings to get alerts.';
                            notificationPermissionAlert.style.display = 'block';
                            lucide.createIcons();
                        }
                    });
                }
            }

            function showNotification(title, body) {
                if ('Notification' in window && Notification.permission === "granted") {
                    const notification = new Notification(title, { 
                        body: body,
                        icon: 'images/QueuingManagementIllustration.png' 
                    });
                }
            }

            function setMinimumDate() {
                const scheduleInput = document.getElementById('schedule_datetime');
                const now = new Date();
                
                now.setDate(now.getDate() + 1);
                const year = now.getFullYear();
                const month = (now.getMonth() + 1).toString().padStart(2, '0');
                const day = now.getDate().toString().padStart(2, '0');
                
                const minDateString = year + '-' + month + '-' + day;
                scheduleInput.setAttribute('min', minDateString);
            }

            function loadLaneStatus() {
                fetch('api/get_live_status.php')
                    .then(function(response) {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(function(data) {
                        const graphContainer = document.getElementById('lane-status-graph');
                        graphContainer.innerHTML = '';
                        
                        if (data.counters && data.counters.length > 0) {
                            data.counters.forEach(function(counter) {
                                const oldStatus = currentLaneStatus[counter.counter_id];
                                if (oldStatus) {
                                    if (oldStatus.is_open == '1' && counter.is_open == '0') {
                                        showNotification('Counter Update', counter.counter_name + ' has gone offline.');
                                    } else if (oldStatus.is_open == '0' && counter.is_open == '1') {
                                        showNotification('Counter Update', counter.counter_name + ' is now online.');
                                    } else if (oldStatus.status === 'open' && counter.status === 'break') {
                                        showNotification('Counter Update', counter.counter_name + ' is now on a break.');
                                    } else if (oldStatus.status === 'break' && counter.status === 'open') {
                                        showNotification('Counter Update', counter.counter_name + ' is back from break.');
                                    }
                                }
                                currentLaneStatus[counter.counter_id] = { is_open: counter.is_open, status: counter.status };

                                let color = '#6c757d';
                                let statusText = 'Offline';

                                if (counter.is_open == '1' && counter.status !== 'break') {
                                    const count = counter.waiting_count;
                                    if (count === 0) {
                                        color = '#28a745';
                                        statusText = 'Available';
                                    } else if (count <= 4) {
                                        color = '#0d6efd';
                                        statusText = 'Light';
                                    } else if (count <= 10) {
                                        color = '#ffc107';
                                        statusText = 'Moderate';
                                    } else {
                                        color = '#dc3545';
                                        statusText = 'Heavy';
                                    }
                                } else if (counter.status === 'break') {
                                    color = '#0dcaf0';
                                    statusText = 'On Break';
                                }

                                const laneItem = document.createElement('div');
                                laneItem.className = 'lane-status-item';
                                laneItem.innerHTML = 
                                    '<div class="lane-status-indicator" style="background-color: ' + color + ';"></div>' +
                                    '<div class="lane-name">' + counter.counter_name + '</div>' +
                                    '<div class="lane-status-text">' + statusText + '</div>';
                                
                                graphContainer.appendChild(laneItem);
                            });
                        } else {
                            graphContainer.innerHTML = '<p class="text-muted text-center">No service status available.</p>';
                        }
                    })
                    .catch(function(error) {
                        console.error('Error fetching lane status:', error);
                        const graphContainer = document.getElementById('lane-status-graph');
                        graphContainer.innerHTML = '<p class="text-danger text-center">Failed to load service status.</p>';
                    });
            }
            
            function checkMyTicketStatus() {
                fetch('api/get_my_ticket_status.php')
                    .then(function(response) {
                        return response.json();
                    })
                    .then(function(data) {
                        if (data.success && data.ticket) {
                            const newStatus = data.ticket.status;
                            if (currentTicketStatus === 'waiting' && newStatus === 'serving') {
                                document.getElementById('modal_queue_number').textContent = data.ticket.queue_number;
                                document.getElementById('modal_counter_name').textContent = data.ticket.counter_name;
                                notificationModal.show();
                                
                                notificationSound.play().catch(function(e) { 
                                    console.error("Audio play failed. User may not have interacted with the page yet.", e); 
                                });
                                
                                showNotification("It's your turn!", "Please proceed to " + data.ticket.counter_name + ". Your queue number is " + data.ticket.queue_number + ".");
                                
                                if (statusCheckInterval) clearInterval(statusCheckInterval);
                            }
                            currentTicketStatus = newStatus;
                        } else {
                            if (statusCheckInterval) clearInterval(statusCheckInterval);
                        }
                    })
                    .catch(function(error) {
                        console.error('Error checking ticket status:', error);
                    });
            }

            function updateSelectedPurposesDisplay() {
                selectedContainer.innerHTML = '';
                if (selectedPurposes.length === 0) {
                    selectedContainer.innerHTML = '<p class="text-muted small mb-0 p-2">Selected purposes will appear here.</p>';
                } else {
                    selectedPurposes.forEach(function(purpose) {
                        const badge = document.createElement('span');
                        badge.className = 'badge purpose-badge bg-primary d-inline-flex align-items-center me-2 mb-2';
                        const displayName = purpose.startsWith('doc_req:') ? 'Doc Req: ' + purpose.substring(8) : purpose;
                        badge.innerHTML = '<span>' + displayName + '</span><button type="button" class="btn-close btn-close-white ms-2" style="transform: scale(0.8);" onclick="removePurpose(\'' + purpose + '\')"></button>';
                        selectedContainer.appendChild(badge);
                    });
                }
                hiddenInput.value = selectedPurposes.join(', ');
            }

            window.removePurpose = function(purpose) {
                selectedPurposes = selectedPurposes.filter(function(p) { return p !== purpose; });
                updateSelectedPurposesDisplay();
            }

            purposeSelect.addEventListener('change', function() {
                const selectedValue = this.value;
                if (!selectedValue) return;

                if (selectedValue === 'Document Request') {
                    docuRequestModal.show();
                } else if (selectedPurposes.indexOf(selectedValue) === -1) {
                    selectedPurposes.push(selectedValue);
                    updateSelectedPurposesDisplay();
                }
                this.value = '';
            });

            document.getElementById('add_documents_btn').addEventListener('click', function() {
                const checkboxes = document.querySelectorAll('#document_checklist .form-check-input:checked');
                let isFirstDocReq = selectedPurposes.indexOf('Document Request') === -1;

                checkboxes.forEach(function(cb) {
                    const docPurpose = 'doc_req:' + cb.value;
                    if (selectedPurposes.indexOf(docPurpose) === -1) {
                        selectedPurposes.push(docPurpose);
                    }
                });

                if (isFirstDocReq && checkboxes.length > 0) {
                    selectedPurposes.unshift('Document Request');
                }
                
                updateSelectedPurposesDisplay();
                docuRequestModal.hide();
            });
            
            fetch('api/get_active_ticket.php')
                .then(function(response) { return response.json(); })
                .then(function(data) {
                    if (data.success && data.ticket) {
                        notificationDiv.style.display = 'block';
                        formContainerDiv.style.display = 'none';
                        const ticket = data.ticket;
                        document.getElementById('form_title').textContent = 'Edit Your Active Ticket';
                        document.getElementById('button_text').textContent = 'Update My Ticket';
                        queueIdInput.value = ticket.queue_id;
                        scheduleInput.value = ticket.schedule_datetime;
                        selectedPurposes = ticket.purpose.split(',').map(function(p) { return p.trim(); }).filter(function(p) { return p; });
                        updateSelectedPurposesDisplay();
                        
                        const parts = ticket.schedule_datetime.split('-');
                        const scheduleDate = new Date(parts[0], parts[1] - 1, parts[2]); 
                        const today = new Date();
                        today.setHours(0,0,0,0);

                        if(scheduleDate.getTime() === today.getTime()){
                            showNotification("Appointment Today!", "You have an appointment scheduled for today. Please check in at the kiosk.");
                        }

                        checkMyTicketStatus();
                        statusCheckInterval = setInterval(checkMyTicketStatus, 5000);
                    } else {
                        formContainerDiv.style.display = 'block';
                    }
                    lucide.createIcons();
                })
                .catch(function(error) {
                    console.error('Error fetching active ticket:', error);
                });
            
            viewEditButton.addEventListener('click', function() {
                notificationDiv.style.display = 'none';
                formContainerDiv.style.display = 'block';
            });
            
            queueForm.addEventListener('submit', function(e) {
                e.preventDefault();
                
                if (selectedPurposes.length === 0) {
                    messageDiv.innerHTML = '<div class="alert alert-warning">Please select at least one purpose.</div>';
                    return;
                }
                
                const formData = new FormData(queueForm);
                
                let apiEndpoint = queueIdInput.value ? 'api/update_ticket.php' : 'api/create_ticket.php';
                
                fetch(apiEndpoint, { method: 'POST', body: formData })
                    .then(function(response) { return response.json(); })
                    .then(function(data) {
                        if (data.success) {
                            window.location.href = 'ticket.php';
                        } else {
                            messageDiv.innerHTML = '<div class="alert alert-danger d-flex align-items-center"><i data-lucide="x-circle" class="me-2"></i>' + data.message + '</div>';
                            lucide.createIcons();
                        }
                    })
                    .catch(function(error) {
                        console.error('Error submitting form:', error);
                        messageDiv.innerHTML = '<div class="alert alert-danger">An error occurred. Please try again.</div>';
                    });
            });

            updateSelectedPurposesDisplay();
            setMinimumDate();
            loadLaneStatus();
            setInterval(loadLaneStatus, 10000);
        });
    </script>
</body>
</html>

