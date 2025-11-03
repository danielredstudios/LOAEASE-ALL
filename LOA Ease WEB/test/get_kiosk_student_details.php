<?php
require_once '../includes/db_connect.php';

header('Content-Type: application/json');

$student_number_input = $_GET['student_number'] ?? '';

if (empty($student_number_input)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Student number is required.']);
    exit();
}

// Prepare both versions of the student number (e.g., with and without 'C')
$number_with_c = $student_number_input;
$number_without_c = $student_number_input;

if (strtoupper(substr($student_number_input, 0, 1)) === 'C') {
    $number_without_c = substr($student_number_input, 1);
} else {
    $number_with_c = 'C' . $student_number_input;
}
$stmt = $conn->prepare("
    SELECT s.last_name, s.first_name, s.middle_initial, s.course, s.email
    FROM students s
    WHERE (s.student_number = ? OR s.student_number = ?)
");
$stmt->bind_param("ss", $number_with_c, $number_without_c);
$stmt->execute();
$result = $stmt->get_result();

if ($student = $result->fetch_assoc()) {
    echo json_encode(['success' => true, 'data' => $student]);
} else {
    echo json_encode(['success' => false, 'message' => 'Student number not found in the records.']);
}

$stmt->close();
$conn->close();
?>