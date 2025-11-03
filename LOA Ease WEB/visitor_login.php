<?php
require_once 'includes/db_connect.php';
session_start();

$message = '';
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $full_name = trim($_POST['full_name']);
    $email = trim($_POST['email']);
    $purpose = trim($_POST['purpose']);

    if (empty($full_name) || empty($email) || empty($purpose)) {
        $message = '<div class="alert alert-warning">All fields are required.</div>';
    } else {
        $_SESSION['visitor_data'] = $_POST;
        header("Location: api/create_visitor_ticket.php");
        exit();
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Visitor Registration - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <link rel="stylesheet" href="styles.css">
    <style>
        .purpose-badge { font-size: 0.9em; padding: 0.5em 0.75em; }
    </style>
</head>
<body>
    <div class="container my-5">
        <div class="modern-card" style="max-width: 500px; margin: auto;">
            <div class="card-content">
                <div class="text-center mb-4">
                    <h2 class="fw-bold">Visitor Queuing</h2>
                    <p class="text-muted">Please provide your details to get a queue number.</p>
                </div>
                <?php if($message) echo $message; ?>
                <form action="visitor_login.php" method="POST">
                    <div class="mb-3">
                        <label for="full_name" class="form-label">Full Name</label>
                        <input type="text" class="form-control" id="full_name" name="full_name" required>
                    </div>
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="email" class="form-control" id="email" name="email" required>
                    </div>
                    
                    <div class="mb-2">
                        <label for="purpose_select" class="form-label">Purpose of Visit</label>
                        <select class="form-select" id="purpose_select">
                            <option value="" disabled selected>-- Choose a purpose to add --</option>
                            <option value="Tuition Payment">Tuition Payment</option>
                            <option value="Document Request">Document Request</option>
                            <option value="Enrollment Concern">Enrollment Concern</option>
                            <option value="Others">Others</option>
                        </select>
                    </div>

                    <div id="selected_purposes_container" class="mb-3 border rounded p-2" style="min-height: 50px;"></div>
                    <input type="hidden" name="purpose" id="purpose_hidden">

                    <div class="d-grid">
                        <button type="submit" class="btn-primary-modern">Get Queue Number</button>
                    </div>
                </form>
                 <hr class="my-4">
                <p class="text-center text-muted">Are you a student? <a href="login.php">Login here</a></p>
            </div>
        </div>
    </div>

    <div class="modal fade" id="docuRequestModal" tabindex="-1" aria-labelledby="docuRequestModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="docuRequestModalLabel">Select Documents to Request</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div id="document_checklist">
                <div class="form-check"><input class="form-check-input" type="checkbox" value="Diploma" id="doc_diploma"><label class="form-check-label" for="doc_diploma">Diploma</label></div>
                <div class="form-check"><input class="form-check-input" type="checkbox" value="Transcript of Records (TOR)" id="doc_tor"><label class="form-check-label" for="doc_tor">Transcript of Records (TOR)</label></div>
                <div class="form-check"><input class="form-check-input" type="checkbox" value="Good Moral Certificate" id="doc_gmc"><label class="form-check-label" for="doc_gmc">Good Moral Certificate</label></div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            <button type="button" class="btn btn-primary" id="add_documents_btn">Add Selected</button>
          </div>
        </div>
      </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        lucide.createIcons();
        
        document.addEventListener('DOMContentLoaded', function() {
            const purposeSelect = document.getElementById('purpose_select');
            const selectedContainer = document.getElementById('selected_purposes_container');
            const hiddenInput = document.getElementById('purpose_hidden');
            const docuRequestModal = new bootstrap.Modal(document.getElementById('docuRequestModal'));
            
            let selectedPurposes = [];

            function updateSelectedPurposesDisplay() {
                selectedContainer.innerHTML = '';
                if (selectedPurposes.length === 0) {
                    selectedContainer.innerHTML = '<p class="text-muted small mb-0 p-2">Selected purposes will appear here.</p>';
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
                let isFirstDocReq = !selectedPurposes.some(p => p === 'Document Request');

                checkboxes.forEach(cb => {
                    const docPurpose = `doc_req:${cb.value}`;
                    if (!selectedPurposes.includes(docPurpose)) {
                        selectedPurposes.push(docPurpose);
                    }
                });

                if (isFirstDocReq && checkboxes.length > 0) {
                    selectedPurposes.unshift('Document Request');
                }
                
                updateSelectedPurposesDisplay();
                docuRequestModal.hide();
            });

            updateSelectedPurposesDisplay();
        });
    </script>
</body>
</html>