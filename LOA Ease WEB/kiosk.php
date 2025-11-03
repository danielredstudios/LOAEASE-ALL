<?php
session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Kiosk - On-Site Queuing</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        .purpose-badge { font-size: 1rem; padding: 0.75em 1em; }
        .btn-kiosk {
            padding: 1rem 2rem;
            font-size: 1.25rem;
            font-weight: 600;
        }
        .form-control[readonly] {
            background-color: #e9ecef;
        }
        @media (max-width: 768px) {
            .card-content {
                padding: 1.5rem;
            }
            .fw-bold {
                font-size: 1.5rem;
            }
            .fs-5 {
                font-size: 1rem !important;
            }
            .btn-kiosk {
                padding: 0.8rem 1.5rem;
                font-size: 1rem;
            }
            #lane-status-graph {
                flex-wrap: wrap;
                gap: 1rem;
            }
            #lane-status-graph .text-center {
                flex-basis: 45%;
            }
            #lane-status-graph .progress {
                width: 80px;
                height: 15px;
            }
            #lane-status-graph .small {
                font-size: 0.8rem;
            }
        }
    </style>
</head>
<body>
    <div class="container py-5">
        <div class="modern-card" style="max-width: 800px; margin: auto;">
            <div class="card-content">
                <div class="text-center mb-4">
                    <h1 class="fw-bold">On-Site Queuing</h1>
                    <p class="fs-5 text-muted">Enter your student number to begin.</p>
                </div>
                <div id="message"></div>

                <div class="modern-card mb-4">
                    <div class="card-content py-3">
                        <h3 class="fw-bold text-center mb-3 fs-5">Live Lane Status</h3>
                        <div id="lane-status-graph" class="d-flex justify-content-around p-2 rounded" style="background-color: #f8f9fa;">
                        </div>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="student_number" class="form-label fs-5">Student Number</label>
                    <div class="input-group input-group-lg">
                         <input type="text" class="form-control" id="student_number" name="student_number" required>
                         <span class="input-group-text" id="student_number_status"></span>
                    </div>
                </div>

                <form id="queueForm" style="display: none;">
                    <input type="hidden" name="student_number_hidden" id="student_number_hidden">
                    
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Name</label>
                            <input type="text" class="form-control form-control-lg" id="student_name" readonly>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Course</label>
                            <input type="text" class="form-control form-control-lg" id="student_course" readonly>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="purpose_select" class="form-label fs-5">Purpose of Visit</label>
                        <div class="input-group input-group-lg">
                             <span class="input-group-text"><i data-lucide="edit"></i></span>
                            <select class="form-select" id="purpose_select">
                                <option value="" disabled selected>-- Choose a purpose to add --</option>
                                <option value="Tuition Payment">Tuition Payment</option>
                                <option value="Document Request">Document Request</option>
                                <option value="Promissory Note">Promissory Note</option>
                                <option value="Enrollment Concern">Enrollment Concern</option>
                                <option value="Others">Others</option>
                            </select>
                        </div>
                    </div>

                    <div id="selected_purposes_container" class="mb-3 border rounded p-3" style="min-height: 60px;"></div>
                    <input type="hidden" name="purpose" id="purpose_hidden">
                    
                     <div class="mb-4 form-check">
                         <input type="checkbox" class="form-check-input" id="is_priority" name="is_priority" value="1" style="width: 1.5em; height: 1.5em;">
                         <label class="form-check-label fs-5 ms-2" for="is_priority">Priority Lane (For PWD, Senior Citizens, Pregnant Women)</label>
                     </div>

                    <div class="d-grid">
                        <button type="submit" class="btn-primary-modern btn-kiosk" id="submit_button">
                            <i data-lucide="ticket" class="me-2"></i>Get My Ticket
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    
    <div class="modal fade" id="docuRequestModal" tabindex="-1" aria-labelledby="docuRequestModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="docuRequestModalLabel">Select Documents to Request</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body fs-5">
            <div id="document_checklist">
                <div class="form-check mb-3"><input class="form-check-input" type="checkbox" value="Diploma" id="doc_diploma" style="width: 1.5em; height: 1.5em;"><label class="form-check-label ms-2" for="doc_diploma">Diploma</label></div>
                <div class="form-check mb-3"><input class="form-check-input" type="checkbox" value="Transcript of Records (TOR)" id="doc_tor" style="width: 1.5em; height: 1.5em;"><label class="form-check-label ms-2" for="doc_tor">Transcript of Records (TOR)</label></div>
                 <div class="form-check mb-3"><input class="form-check-input" type="checkbox" value="Good Moral Certificate" id="doc_gmc" style="width: 1.5em; height: 1.5em;"><label class="form-check-label ms-2" for="doc_gmc">Good Moral Certificate</label></div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary btn-lg" data-bs-dismiss="modal">Cancel</button>
            <button type="button" class="btn btn-primary btn-lg" id="add_documents_btn">Add Selected</button>
          </div>
        </div>
      </div>
    </div>

    <div class="modal fade" id="priorityWarningModal" tabindex="-1" aria-labelledby="priorityWarningModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="priorityWarningModalLabel">Priority Lane Confirmation</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Are you sure you want to use the Priority Lane? This is reserved for PWDs, Senior Citizens, and Pregnant Women.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" id="cancel_priority">Cancel</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal" id="confirm_priority">Confirm</button>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        lucide.createIcons();
        
        document.addEventListener('DOMContentLoaded', function() {
            const studentNumberInput = document.getElementById('student_number');
            const studentNumberStatus = document.getElementById('student_number_status');
            const queueForm = document.getElementById('queueForm');
            const messageDiv = document.getElementById('message');
            
            const purposeSelect = document.getElementById('purpose_select');
            const selectedContainer = document.getElementById('selected_purposes_container');
            const hiddenInput = document.getElementById('purpose_hidden');
            const docuRequestModal = new bootstrap.Modal(document.getElementById('docuRequestModal'));
            const priorityCheckbox = document.getElementById('is_priority');
            const priorityWarningModal = new bootstrap.Modal(document.getElementById('priorityWarningModal'));
            
            let selectedPurposes = [];
            let debounceTimer;

            function loadLaneStatus() {
                fetch('api/get_live_status.php')
                    .then(response => response.json())
                    .then(data => {
                        const graphContainer = document.getElementById('lane-status-graph');
                        graphContainer.innerHTML = '';
                        if (data.counters) {
                            data.counters.forEach(counter => {
                                let color = '#6c757d';
                                let statusText = 'Offline';
                                let waitTimeText = '';

                                if (counter.is_open == '1' && counter.status !== 'break') {
                                    const count = counter.waiting_count;
                                    waitTimeText = `<div class="small text-muted">~${counter.estimated_wait_time} min wait</div>`;
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

                                const laneHtml = `
                                    <div class="text-center">
                                        <div class="progress" style="height: 20px; width: 100px; margin: auto; background-color: #e9ecef;">
                                            <div class="progress-bar" role="progressbar" style="width: 100%; background-color: ${color};"></div>
                                        </div>
                                        <div class="mt-2 small">${counter.counter_name}</div>
                                        <div class="small fw-bold">${statusText}</div>
                                        ${waitTimeText}
                                    </div>
                                `;
                                graphContainer.innerHTML += laneHtml;
                            });
                        }
                    })
                    .catch(error => console.error('Error fetching lane status:', error));
            }

            studentNumberInput.addEventListener('input', function() {
                clearTimeout(debounceTimer);
                const studentNumber = this.value.trim();
                queueForm.style.display = 'none';
                studentNumberStatus.innerHTML = '<div class="spinner-border spinner-border-sm" role="status"></div>';

                debounceTimer = setTimeout(() => {
                    if (studentNumber) {
                        fetch(`test/get_kiosk_student_details.php?student_number=${studentNumber}`)
                            .then(response => response.json())
                            .then(result => {
                                if (result.success) {
                                    const data = result.data;
                                    document.getElementById('student_name').value = `${data.first_name} ${data.last_name}`;
                                    document.getElementById('student_course').value = data.course;
                                    document.getElementById('student_number_hidden').value = studentNumber;
                                    queueForm.style.display = 'block';
                                    studentNumberStatus.innerHTML = '<i data-lucide="check" class="text-success"></i>';
                                    messageDiv.innerHTML = '';
                                } else {
                                    messageDiv.innerHTML = `<div class="alert alert-danger">${result.message}</div>`;
                                    studentNumberStatus.innerHTML = '<i data-lucide="x" class="text-danger"></i>';
                                }
                                lucide.createIcons();
                            });
                    } else {
                        studentNumberStatus.innerHTML = '';
                    }
                }, 500);
            });

            function updateSelectedPurposesDisplay() {
                selectedContainer.innerHTML = '';
                if (selectedPurposes.length === 0) {
                    selectedContainer.innerHTML = '<p class="text-muted fs-5 mb-0 p-2">Selected purposes will appear here.</p>';
                } else {
                    selectedPurposes.forEach(purpose => {
                        const badge = document.createElement('span');
                        badge.className = 'badge purpose-badge bg-primary d-inline-flex align-items-center me-2 mb-2';
                        const displayName = purpose.startsWith('doc_req:') ? `Doc Req: ${purpose.substring(8)}` : purpose;
                        badge.innerHTML = `<span>${displayName}</span><button type="button" class="btn-close btn-close-white ms-2" style="transform: scale(0.8);" onclick="removePurpose('${purpose}')"></button>`;
                        selectedContainer.appendChild(badge);
                    });
                }
                hiddenInput.value = selectedPurposes.join(', ');
            }

            window.removePurpose = function(purpose) {
                selectedPurposes = selectedPurposes.filter(p => p !== purpose);
                updateSelectedPurposesDisplay();
            }

            purposeSelect.addEventListener('change', function() {
                const selectedValue = this.value;
                if (!selectedValue) return;

                if (selectedValue === 'Document Request') {
                    docuRequestModal.show();
                } else if (!selectedPurposes.includes(selectedValue)) {
                    selectedPurposes.push(selectedValue);
                    updateSelectedPurposesDisplay();
                }
                this.value = '';
            });

            document.getElementById('add_documents_btn').addEventListener('click', function() {
                const checkboxes = document.querySelectorAll('#document_checklist .form-check-input:checked');
                let isFirstDocReq = !selectedPurposes.some(p => p.startsWith('doc_req:'));

                checkboxes.forEach(cb => {
                    const docPurpose = `doc_req:${cb.value}`;
                    if (!selectedPurposes.includes(docPurpose)) {
                        selectedPurposes.push(docPurpose);
                    }
                });

                if (isFirstDocReq && checkboxes.length > 0 && !selectedPurposes.includes('Document Request')) {
                    selectedPurposes.unshift('Document Request');
                }
                
                updateSelectedPurposesDisplay();
                docuRequestModal.hide();
            });
            
            priorityCheckbox.addEventListener('change', function() {
                if (this.checked) {
                    priorityWarningModal.show();
                }
            });

            document.getElementById('cancel_priority').addEventListener('click', function() {
                priorityCheckbox.checked = false;
            });

            queueForm.addEventListener('submit', function(e) {
                e.preventDefault();
                
                if (selectedPurposes.length === 0) {
                    messageDiv.innerHTML = `<div class="alert alert-warning fs-5">Please select at least one purpose.</div>`;
                    return;
                }
                
                const formData = new FormData(queueForm);
                formData.set('student_number', document.getElementById('student_number_hidden').value);
                fetch('test/create_kiosk_ticket.php', { method: 'POST', body: formData })
                .then(response => response.json())
                .then(data => {
                    if (data.success && data.redirect_url) {
                        window.location.href = data.redirect_url;
                    } else {
                        messageDiv.innerHTML = `<div class="alert alert-danger d-flex align-items-center fs-5"><i data-lucide="x-circle" class="me-2"></i>${data.message}</div>`;
                        lucide.createIcons();
                    }
                });
            });

            loadLaneStatus();
            setInterval(loadLaneStatus, 10000);
            updateSelectedPurposesDisplay();
        });
    </script>
</body>
</html>