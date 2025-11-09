<?php
session_start();
if (!isset($_SESSION['cashier_id'])) {
    header("Location: cashier_login.php");
    exit();
}
$counter_name = $_SESSION['counter_name'];
$full_name = $_SESSION['full_name'];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard - <?php echo htmlspecialchars($counter_name); ?></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
        body { font-family: 'Poppins', sans-serif; background-color: #f4f7f9; }
        .card { border-radius: 1rem; box-shadow: 0 4px 12px rgba(0,0,0,0.05); }
        .serving-card { background-color: #003366; color: white; }
        .student-details { list-style: none; padding-left: 0; }
        .student-details li { margin-bottom: 0.5rem; }
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#">LOA EASE - Cashier</a>
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav ms-auto d-flex align-items-center">
                    <li class="nav-item"><span class="navbar-text me-3"><?php echo htmlspecialchars($full_name); ?></span></li>
                    <li class="nav-item me-2">
                        <button id="break-btn" class="btn btn-sm btn-warning" onclick="updateStatus('toggle_break')">Go on Break</button>
                    </li>
                    <li class="nav-item me-3">
                         <button id="offline-btn" class="btn btn-sm btn-danger" onclick="updateStatus('toggle_offline')">Go Offline</button>
                    </li>
                    <li class="nav-item"><a href="api/cashier_logout.php" class="btn btn-sm btn-outline-light">Log Out</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container mt-4">
        <div class="row mb-3">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title text-success">✅ Completed Today</h5>
                        <h2 class="display-4 fw-bold" id="kpi_completed">0</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body text-center">
                        <h5 class="card-title text-warning">⚠️ No-Show Today</h5>
                        <h2 class="display-4 fw-bold" id="kpi_no_show">0</h2>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-5">
                <div class="card serving-card text-center">
                    <div class="card-header">Currently Serving</div>
                    <div class="card-body p-4">
                        <h1 class="display-1 fw-bold" id="serving_number">---</h1>
                        <div id="details-container" class="mt-3 text-start" style="display: none;">
                            <ul class="student-details">
                                <li><strong>Name:</strong> <span id="serving_name"></span></li>
                                <li id="serving_student_no_li"><strong>Student No:</strong> <span id="serving_student_no"></span></li>
                                <li id="serving_course_li"><strong>Course:</strong> <span id="serving_course"></span></li>
                                <li><strong>Purpose:</strong> <span id="serving_purpose"></span></li>
                            </ul>
                        </div>
                        <p id="no-serving-message">No one is currently being served.</p>
                    </div>
                    <div class="card-footer" id="serving_actions" style="display: none;">
                        <button class="btn btn-success" onclick="manageQueue('complete')">Complete</button>
                        <button class="btn btn-warning" onclick="manageQueue('no-show')">No-Show</button>
                    </div>
                </div>

                <div class="card mt-4">
                    <div class="card-header">
                        <h5 class="mb-0">Manage Office Hours</h5>
                    </div>
                    <div class="card-body">
                         <div id="closing-time-message"></div>
                         <p class="text-muted small">Set the closing time for your counter today. This will prevent students from queuing for today after this time.</p>
                         <div class="input-group">
                            <input type="time" id="closing-time-input" class="form-control">
                            <button class="btn btn-info" onclick="setClosingTime()">Set Time</button>
                         </div>
                    </div>
                </div>

            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">Waiting List for <?php echo htmlspecialchars($counter_name); ?></h5>
                        <button class="btn btn-primary" onclick="manageQueue('next')">Call Next Student</button>
                    </div>
                    <div class="card-body">
                        <ul class="list-group" id="waiting_list">
                            <li class="list-group-item text-center text-muted">No students waiting.</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        lucide.createIcons();
        let currentServingId = null;
        let waitingQueueNumbers = new Set();
        let initialLoad = true;

        if (Notification.permission !== "granted") {
            Notification.requestPermission();
        }

        function showNotification(title, body) {
            if (Notification.permission === "granted") {
                new Notification(title, { body: body });
            }
        }

        function setClosingTime() {
            const timeInput = document.getElementById('closing-time-input');
            const newTime = timeInput.value;
            const messageDiv = document.getElementById('closing-time-message');

            if (!newTime) {
                messageDiv.innerHTML = `<div class="alert alert-warning py-2">Please select a time.</div>`;
                return;
            }

            fetch('api/update_closing_time.php', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ end_time: newTime })
            })
            .then(res => res.json())
            .then(data => {
                if (data.success) {
                    messageDiv.innerHTML = `<div class="alert alert-success py-2">${data.message}</div>`;
                } else {
                     messageDiv.innerHTML = `<div class="alert alert-danger py-2">${data.message}</div>`;
                }
            });
        }

        function updateStatus(action) {
            fetch('api/update_cashier_status.php', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ action: action })
            })
            .then(response => response.json())
            .then(data => {
                if(data.success) {
                    updateButtonStates(data.new_status);
                } else {
                    alert('Error updating status: ' + data.message);
                }
            });
        }

        function updateButtonStates(status) {
            const breakBtn = document.getElementById('break-btn');
            const offlineBtn = document.getElementById('offline-btn');

            if(status.status === 'break') {
                breakBtn.textContent = 'End Break';
                breakBtn.classList.replace('btn-warning', 'btn-info');
            } else {
                breakBtn.textContent = 'Go on Break';
                breakBtn.classList.replace('btn-info', 'btn-warning');
            }

            if(status.is_open == '0') {
                offlineBtn.textContent = 'Go Online';
                offlineBtn.classList.replace('btn-danger', 'btn-success');
            } else {
                offlineBtn.textContent = 'Go Offline';
                offlineBtn.classList.replace('btn-success', 'btn-danger');
            }
        }
        
        fetch('api/update_cashier_status.php').then(res => res.json()).then(data => {
            if(data.success) updateButtonStates(data.status);
        });

        function fetchQueue() {
            fetch('api/get_queue_for_counter.php')
                .then(response => response.json())
                .then(data => {
                    const waitingList = document.getElementById('waiting_list');
                    const servingNumber = document.getElementById('serving_number');
                    const servingActions = document.getElementById('serving_actions');
                    const detailsContainer = document.getElementById('details-container');
                    const noServingMessage = document.getElementById('no-serving-message');
                    
                    waitingList.innerHTML = '';
                    
                    if (data.success) {
                        // Update KPIs
                        document.getElementById('kpi_completed').textContent = data.completed_count || 0;
                        document.getElementById('kpi_no_show').textContent = data.no_show_count || 0;
                        
                        const newWaitingQueueNumbers = new Set(data.waiting.map(item => item.queue_number));

                        if (!initialLoad) {
                            for (const queueNumber of newWaitingQueueNumbers) {
                                if (!waitingQueueNumbers.has(queueNumber)) {
                                    showNotification('New Student in Queue', `Ticket ${queueNumber} has joined your waiting list.`);
                                }
                            }
                        }

                        waitingQueueNumbers = newWaitingQueueNumbers;
                        if (initialLoad) initialLoad = false;

                        if (data.serving) {
                            servingNumber.textContent = data.serving.queue_number;
                            document.getElementById('serving_purpose').textContent = data.serving.purpose;
                            
                            // Use display_name if available, otherwise fall back to original logic
                            if (data.serving.display_name) {
                                document.getElementById('serving_name').textContent = data.serving.display_name;
                            } else if (data.serving.student_number) {
                                document.getElementById('serving_name').textContent = `${data.serving.first_name} ${data.serving.last_name}`;
                            } else {
                                document.getElementById('serving_name').textContent = data.serving.visitor_name || 'N/A';
                            }
                            
                            // Show/hide student-specific fields based on is_visitor flag
                            if (data.serving.is_visitor == 1) {
                                document.getElementById('serving_student_no_li').style.display = 'none';
                                document.getElementById('serving_course_li').style.display = 'none';
                            } else if (data.serving.student_number) {
                                document.getElementById('serving_student_no').textContent = data.serving.student_number;
                                document.getElementById('serving_course').textContent = data.serving.course;
                                document.getElementById('serving_student_no_li').style.display = 'block';
                                document.getElementById('serving_course_li').style.display = 'block';
                            } else {
                                document.getElementById('serving_student_no_li').style.display = 'none';
                                document.getElementById('serving_course_li').style.display = 'none';
                            }
                            
                            detailsContainer.style.display = 'block';
                            noServingMessage.style.display = 'none';
                            servingActions.style.display = 'block';
                            currentServingId = data.serving.queue_id;
                        } else {
                            servingNumber.textContent = '---';
                            detailsContainer.style.display = 'none';
                            noServingMessage.style.display = 'block';
                            servingActions.style.display = 'none';
                            currentServingId = null;
                        }

                        if (data.waiting.length > 0) {
                            data.waiting.forEach(item => {
                                const li = document.createElement('li');
                                li.className = 'list-group-item d-flex justify-content-between align-items-center';
                                li.innerHTML = `
                                    <div>
                                        <strong class="fs-5 ${item.is_priority ? 'text-danger' : ''}">${item.queue_number}</strong>
                                        <small class="d-block text-muted">${item.purpose}</small>
                                    </div>
                                    ${item.is_priority ? '<span class="badge bg-danger rounded-pill">Priority</span>' : ''}
                                `;
                                waitingList.appendChild(li);
                            });
                        } else {
                             waitingList.innerHTML = '<li class="list-group-item text-center text-muted">No students waiting.</li>';
                        }
                    }
                });
        }

        function manageQueue(action) {
            fetch('api/manage_queue.php', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ action: action, queue_id: currentServingId })
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    fetchQueue();
                } else {
                    alert('Error: ' + data.message);
                }
            });
        }

        document.addEventListener('DOMContentLoaded', function() {
            fetchQueue();
            setInterval(fetchQueue, 5000);
        });
    </script>
</body>
</html>