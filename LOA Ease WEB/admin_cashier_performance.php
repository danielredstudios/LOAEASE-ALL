<?php
require_once 'includes/db_connect.php';
session_start();

// Simple check for admin or cashier role - adjust based on your auth system
// For now, we'll allow access if user is logged in as cashier with admin role
if (!isset($_SESSION['cashier_id'])) {
    // If you have a separate admin session, use that instead
    header("Location: cashier_login.php");
    exit();
}

$today = date("Y-m-d");

// Get total daily KPIs across all cashiers
$kpi_query = "
    SELECT 
        COUNT(CASE WHEN status = 'completed' THEN 1 END) as total_completed,
        COUNT(CASE WHEN status = 'no-show' THEN 1 END) as total_no_show,
        COUNT(CASE WHEN status = 'waiting' THEN 1 END) as total_waiting,
        COUNT(CASE WHEN status = 'serving' THEN 1 END) as total_serving
    FROM queues 
    WHERE DATE(schedule_datetime) = ?
";

$stmt = $conn->prepare($kpi_query);
$stmt->bind_param("s", $today);
$stmt->execute();
$result = $stmt->get_result();
$kpis = $result->fetch_assoc();
$stmt->close();

// Get per-counter breakdown
$counter_query = "
    SELECT 
        c.counter_name,
        COUNT(CASE WHEN q.status = 'completed' THEN 1 END) as completed,
        COUNT(CASE WHEN q.status = 'no-show' THEN 1 END) as no_show,
        COUNT(CASE WHEN q.status = 'waiting' THEN 1 END) as waiting,
        COUNT(CASE WHEN q.status = 'serving' THEN 1 END) as serving
    FROM counters c
    LEFT JOIN queues q ON c.counter_id = q.counter_id AND DATE(q.schedule_datetime) = ?
    WHERE c.counter_id IN (1, 2, 3, 4)
    GROUP BY c.counter_id, c.counter_name
    ORDER BY c.counter_id
";

$stmt = $conn->prepare($counter_query);
$stmt->bind_param("s", $today);
$stmt->execute();
$counter_result = $stmt->get_result();
$counters = [];
while ($row = $counter_result->fetch_assoc()) {
    $counters[] = $row;
}
$stmt->close();

$conn->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin Performance Dashboard - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700&display=swap" rel="stylesheet">
    <script src="https://unpkg.com/lucide@latest"></script>
    <style>
        body { 
            font-family: 'Poppins', sans-serif; 
            background-color: #f4f7f9; 
        }
        .card { 
            border-radius: 1rem; 
            box-shadow: 0 4px 12px rgba(0,0,0,0.05); 
        }
        .stat-card {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
        }
        .stat-card.success {
            background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%);
        }
        .stat-card.warning {
            background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%);
        }
        .stat-card.info {
            background: linear-gradient(135deg, #4facfe 0%, #00f2fe 100%);
        }
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#">LOA EASE - Admin Dashboard</a>
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item"><a href="cashier_dashboard.php" class="btn btn-sm btn-outline-light">Back to Cashier</a></li>
                    <li class="nav-item ms-2"><a href="api/cashier_logout.php" class="btn btn-sm btn-outline-light">Log Out</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container mt-4">
        <div class="row mb-4">
            <div class="col-12">
                <h2 class="fw-bold">Daily Performance Overview</h2>
                <p class="text-muted">Today's statistics across all cashier counters - <?php echo date('F j, Y'); ?></p>
            </div>
        </div>

        <!-- KPI Cards -->
        <div class="row mb-4">
            <div class="col-md-3">
                <div class="card stat-card success">
                    <div class="card-body text-center">
                        <h5 class="card-title">✅ Completed</h5>
                        <h2 class="display-3 fw-bold"><?php echo $kpis['total_completed'] ?? 0; ?></h2>
                        <p class="mb-0">Transactions completed today</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card warning">
                    <div class="card-body text-center">
                        <h5 class="card-title">⚠️ No-Show</h5>
                        <h2 class="display-3 fw-bold"><?php echo $kpis['total_no_show'] ?? 0; ?></h2>
                        <p class="mb-0">Students who didn't show up</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card info">
                    <div class="card-body text-center">
                        <h5 class="card-title">⏳ Waiting</h5>
                        <h2 class="display-3 fw-bold"><?php echo $kpis['total_waiting'] ?? 0; ?></h2>
                        <p class="mb-0">Currently in queue</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card">
                    <div class="card-body text-center">
                        <h5 class="card-title">👥 Serving</h5>
                        <h2 class="display-3 fw-bold"><?php echo $kpis['total_serving'] ?? 0; ?></h2>
                        <p class="mb-0">Currently being served</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Per-Counter Breakdown -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header bg-dark text-white">
                        <h5 class="mb-0">📊 Per-Counter Performance</h5>
                    </div>
                    <div class="card-body">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Counter</th>
                                    <th class="text-center">✅ Completed</th>
                                    <th class="text-center">⚠️ No-Show</th>
                                    <th class="text-center">⏳ Waiting</th>
                                    <th class="text-center">👥 Serving</th>
                                    <th class="text-center">Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <?php foreach ($counters as $counter): ?>
                                    <?php 
                                        $total = ($counter['completed'] ?? 0) + ($counter['no_show'] ?? 0) + 
                                                ($counter['waiting'] ?? 0) + ($counter['serving'] ?? 0);
                                    ?>
                                    <tr>
                                        <td><strong><?php echo htmlspecialchars($counter['counter_name']); ?></strong></td>
                                        <td class="text-center"><span class="badge bg-success"><?php echo $counter['completed'] ?? 0; ?></span></td>
                                        <td class="text-center"><span class="badge bg-warning"><?php echo $counter['no_show'] ?? 0; ?></span></td>
                                        <td class="text-center"><span class="badge bg-info"><?php echo $counter['waiting'] ?? 0; ?></span></td>
                                        <td class="text-center"><span class="badge bg-primary"><?php echo $counter['serving'] ?? 0; ?></span></td>
                                        <td class="text-center"><strong><?php echo $total; ?></strong></td>
                                    </tr>
                                <?php endforeach; ?>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        lucide.createIcons();
        
        // Auto-refresh every 30 seconds
        setInterval(function() {
            location.reload();
        }, 30000);
    </script>
</body>
</html>
