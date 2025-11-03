<?php
require_once '../includes/db_connect.php';

header('Content-Type: application/json');

$student_number_input = $_GET['student_number'] ?? '';

if (empty($student_number_input)) {
    http_response_code(400);
    echo json_encode(['success' => false, 'message' => 'Student number is required.']);
    exit();
}

// Prepare both versions of the student number
$number_with_c = $student_number_input;
$number_without_c = $student_number_input;

if (strtoupper(substr($student_number_input, 0, 1)) === 'C') {
    $number_without_c = substr($student_number_input, 1);
} else {
    $number_with_c = 'C' . $student_number_input;
}

// Find a student who is not yet registered, checking both number formats
$stmt = $conn->prepare("
    SELECT s.last_name, s.first_name, s.middle_initial, s.course, s.email
    FROM students s
    LEFT JOIN users u ON s.student_id = u.student_id
    WHERE (s.student_number = ? OR s.student_number = ?) AND u.user_id IS NULL
");
$stmt->bind_param("ss", $number_with_c, $number_without_c);
$stmt->execute();
$result = $stmt->get_result();

if ($student = $result->fetch_assoc()) {
    echo json_encode(['success' => true, 'data' => $student]);
} else {
    $check_stmt = $conn->prepare("SELECT student_id FROM students WHERE student_number = ? OR student_number = ?");
    $check_stmt->bind_param("ss", $number_with_c, $number_without_c);
    $check_stmt->execute();
    if ($check_stmt->get_result()->num_rows > 0) {
        echo json_encode(['success' => false, 'message' => 'This student is already registered.']);
    } else {
        echo json_encode(['success' => false, 'message' => 'Student number not found in the pre-loaded records.']);
    }
    $check_stmt->close();
}

$stmt->close();
$conn->close();
?>