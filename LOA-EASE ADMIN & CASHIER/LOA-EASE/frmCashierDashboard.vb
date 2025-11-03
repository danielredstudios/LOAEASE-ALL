Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Media

Public Class frmCashierDashboard
    Private ReadOnly _cashierId As Integer
    Private ReadOnly _counterId As Integer
    Private ReadOnly _cashierFullName As String
    Private _currentServingQueueId As Integer? = Nothing
    Private _servingStartTime As DateTime? = Nothing
    Private _isBreak As Boolean = False

    Private WithEvents QueueNotifyIcon As New NotifyIcon()
    Private _soundPlayer As SoundPlayer
    Private _lastQueueCount As Integer = 0

    Public Sub New(cashierId As Integer, counterId As Integer, cashierFullName As String)
        InitializeComponent()
        _cashierId = cashierId
        _counterId = counterId
        _cashierFullName = cashierFullName
    End Sub

    Private Sub frmCashierDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCashierName.Text = $"Welcome, {_cashierFullName}"

        dgvWaitingList.AutoGenerateColumns = False
        dgvWaitingList.Columns.Clear()

        Dim queueNumberColumn As New DataGridViewTextBoxColumn() With {
            .Name = "QueueNumber",
            .HeaderText = "Queue Number",
            .DataPropertyName = "QueueNumber",
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Font = New Font("Poppins", 10, FontStyle.Bold)
            }
        }

        Dim purposeColumn As New DataGridViewTextBoxColumn() With {
            .Name = "Purpose",
            .HeaderText = "Purpose",
            .DataPropertyName = "Purpose"
        }

        dgvWaitingList.Columns.Add(queueNumberColumn)
        dgvWaitingList.Columns.Add(purposeColumn)

        AddHandler Me.FormClosing, AddressOf frmCashierDashboard_FormClosing

        Try
            _soundPlayer = New SoundPlayer(Application.StartupPath & "\Notification-Sound.wav")
            _soundPlayer.Load()
        Catch ex As Exception
            MessageBox.Show($"Could not load notification sound: {ex.Message}. " &
                            "Ensure 'NotificationSound.wav' is in the application folder.",
                            "Sound Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        QueueNotifyIcon.Icon = Me.Icon
        QueueNotifyIcon.Text = "LOA-EASE Queuing"
        QueueNotifyIcon.Visible = True

        RefreshQueueData()
        tmrQueueRefresh.Start()
    End Sub

#Region "Data Fetching and UI Refreshing"

    Private Sub tmrQueueRefresh_Tick(sender As Object, e As EventArgs) Handles tmrQueueRefresh.Tick
        RefreshQueueData()
    End Sub

    Private Sub tmrServingTime_Tick(sender As Object, e As EventArgs) Handles tmrServingTime.Tick
        If _servingStartTime.HasValue Then
            Dim elapsed As TimeSpan = DateTime.Now - _servingStartTime.Value
            Dim minutes As Integer = CInt(Math.Floor(elapsed.TotalMinutes))
            Dim seconds As Integer = elapsed.Seconds
            lblServingTime.Text = $"Serving Time: {minutes:D2}:{seconds:D2}"
        End If
    End Sub

    Private Sub RefreshQueueData()
        FetchNowServing()
        FetchWaitingList()
    End Sub

    Private Sub FetchNowServing()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                    SELECT q.queue_id, q.queue_number, q.purpose, q.visitor_id, q.called_at,
                           s.student_number, s.first_name, s.last_name, s.course,
                           v.full_name AS visitor_name
                    FROM queues q
                    LEFT JOIN students s ON q.student_id = s.student_id
                     LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                    WHERE q.counter_id = @counterId AND q.status = 'serving' AND DATE(q.schedule_datetime) = CURDATE()
                    LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@counterId", _counterId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            UpdateNowServingUI(reader)
                        Else
                            ResetNowServingDisplay()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                HandleDbError("fetching 'Now Serving' data", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchWaitingList()
        Dim waitingList As New BindingList(Of QueueItem)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                    SELECT queue_number, purpose, is_priority
                    FROM queues
                     WHERE counter_id = @counterId AND status = 'waiting' AND DATE(schedule_datetime) = CURDATE()
                    ORDER BY is_priority DESC, created_at ASC"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@counterId", _counterId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            waitingList.Add(New QueueItem With {
                                .QueueNumber = reader("queue_number").ToString(),
                                .Purpose = reader("purpose").ToString(),
                                .IsPriority = Convert.ToBoolean(reader("is_priority"))
                            })
                        End While
                    End Using
                End Using
                dgvWaitingList.DataSource = waitingList

                Dim currentQueueCount As Integer = waitingList.Count
                If currentQueueCount > _lastQueueCount Then
                    PlayNotificationSound()
                    ShowNotification(currentQueueCount)
                End If
                _lastQueueCount = currentQueueCount

            Catch ex As Exception
                HandleDbError("fetching waiting list", ex)
            End Try
        End Using
    End Sub

    Private Sub PlayNotificationSound()
        Try
            If _soundPlayer IsNot Nothing Then
                _soundPlayer.Play()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ShowNotification(queueCount As Integer)
        Dim title As String = "New Queue"
        Dim message As String = $"A new person has joined your queue. You now have {queueCount} waiting."
        QueueNotifyIcon.ShowBalloonTip(3000, title, message, ToolTipIcon.Info)
    End Sub

    Private Sub UpdateNowServingUI(reader As MySqlDataReader)
        _currentServingQueueId = Convert.ToInt32(reader("queue_id"))
        lblServingNumber.Text = reader("queue_number").ToString()
        lblPurpose.Text = $"Purpose of Visit: {reader("purpose")}"

        ' Get and store the serving start time
        If Not IsDBNull(reader("called_at")) Then
            _servingStartTime = Convert.ToDateTime(reader("called_at"))
            lblServingTime.Visible = True
            If Not tmrServingTime.Enabled Then
                tmrServingTime.Start()
            End If
        End If

        If Not IsDBNull(reader("visitor_id")) Then
            lblName.Text = $"Name: {reader("visitor_name")}"
            lblStudentNumber.Text = "Student Number: VISITOR"
            lblCourse.Text = "Course: N/A"
        ElseIf Not IsDBNull(reader("student_number")) Then
            lblName.Text = $"Name: {reader("first_name")} {reader("last_name")}"
            lblStudentNumber.Text = $"Student Number: {reader("student_number")}"
            lblCourse.Text = $"Course: {reader("course")}"
        Else
            lblName.Text = "Name: N/A"
            lblStudentNumber.Text = "Student Number: N/A"
            lblCourse.Text = "Course: N/A"
        End If

        btnComplete.Enabled = True
        btnNoShow.Enabled = True
    End Sub

    Private Sub ResetNowServingDisplay()
        _currentServingQueueId = Nothing
        _servingStartTime = Nothing
        tmrServingTime.Stop()
        lblServingTime.Visible = False
        lblServingNumber.Text = "---"
        lblName.Text = "Name: ---"
        lblStudentNumber.Text = "Student Number: ---"
        lblCourse.Text = "Course: ---"
        lblPurpose.Text = "Purpose of Visit: ---"
        btnComplete.Enabled = False
        btnNoShow.Enabled = False
    End Sub

#End Region

#Region "Button Click Handlers"

    Private Sub btnCallNext_Click(sender As Object, e As EventArgs) Handles btnCallNext.Click
        If _currentServingQueueId.HasValue Then
            MessageBox.Show("Please complete the current transaction before calling the next person.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ExecuteNonQuery("UPDATE queues SET status = 'serving', called_at = NOW() WHERE counter_id = @counterId AND status = 'waiting' ORDER BY is_priority DESC, created_at ASC LIMIT 1",
                        AddressOf OnCallNextSuccess,
                        New MySqlParameter("@counterId", _counterId))
    End Sub
    Private Sub btnRecall_Click(sender As Object, e As EventArgs) Handles btnRecall.Click
        If _currentServingQueueId.HasValue Then
            MessageBox.Show("Please complete the current transaction before recalling another person.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using recallForm As New Form()
            recallForm.Text = "Recall a Queue"
            recallForm.StartPosition = FormStartPosition.CenterParent
            recallForm.FormBorderStyle = FormBorderStyle.FixedDialog
            recallForm.ClientSize = New Size(300, 250)

            Dim lblTitle As New Label()
            lblTitle.Text = "Select a 'No-Show' ticket to recall:"
            lblTitle.Dock = DockStyle.Top
            lblTitle.Padding = New Padding(5)
            lblTitle.Font = New Font(Me.Font, FontStyle.Bold)
            recallForm.Controls.Add(lblTitle)

            Dim lstNoShow As New ListBox()
            lstNoShow.Dock = DockStyle.Fill
            recallForm.Controls.Add(lstNoShow)
            lstNoShow.BringToFront()

            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Try
                    conn.Open()
                    Dim query As String = "SELECT queue_id, queue_number FROM queues WHERE counter_id = @counterId AND status = 'no-show' AND DATE(schedule_datetime) = CURDATE() ORDER BY called_at DESC LIMIT 10"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@counterId", _counterId)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                lstNoShow.Items.Add(New With {.QueueId = reader.GetInt32("queue_id"), .QueueNumber = reader.GetString("queue_number")})
                            End While
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error fetching 'no-show' list: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

            lstNoShow.DisplayMember = "QueueNumber"
            lstNoShow.ValueMember = "QueueId"

            Dim btnOk As New Button()
            btnOk.Text = "Recall Selected"
            btnOk.DialogResult = DialogResult.OK
            btnOk.Dock = DockStyle.Bottom
            recallForm.Controls.Add(btnOk)

            If lstNoShow.Items.Count = 0 Then
                MessageBox.Show("There are no recent 'no-show' tickets to recall.", "Recall List Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If recallForm.ShowDialog() = DialogResult.OK AndAlso lstNoShow.SelectedItem IsNot Nothing Then
                Dim selectedQueue = lstNoShow.SelectedItem
                Dim queueIdToRecall = CType(selectedQueue, Object).QueueId

                ExecuteNonQuery("UPDATE queues SET status = 'serving', called_at = NOW() WHERE queue_id = @queueId",
                                AddressOf RefreshQueueData,
                                New MySqlParameter("@queueId", queueIdToRecall))
            End If
        End Using
    End Sub
    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        UpdateQueueStatus("completed")
    End Sub

    Private Sub btnNoShow_Click(sender As Object, e As EventArgs) Handles btnNoShow.Click
        UpdateQueueStatus("no-show")
    End Sub

    Private Sub btnToggleBreak_Click(sender As Object, e As EventArgs) Handles btnToggleBreak.Click
        _isBreak = Not _isBreak
        Dim newStatus As String = If(_isBreak, "break", "open")
        ExecuteNonQuery("UPDATE counter_schedules SET status = @status WHERE counter_id = @counterId",
                        Sub()
                            If _isBreak Then
                                btnToggleBreak.Text = "End Break"
                                btnToggleBreak.BackColor = Color.Teal
                            Else
                                btnToggleBreak.Text = "Go on Break"
                                btnToggleBreak.BackColor = Color.Goldenrod
                            End If
                        End Sub,
                        New MySqlParameter("@status", newStatus),
                        New MySqlParameter("@counterId", _counterId))
    End Sub

    Private Sub btnSetClosingTime_Click(sender As Object, e As EventArgs) Handles btnSetClosingTime.Click
        Dim closingTime As String = dtpClosingTime.Value.ToString("HH:mm:ss")
        ExecuteNonQuery("UPDATE counter_schedules SET end_time = @endTime WHERE counter_id = @counterId",
                        Sub() MessageBox.Show($"Closing time updated to {dtpClosingTime.Value:hh:mm tt}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information),
                        New MySqlParameter("@endTime", closingTime),
                        New MySqlParameter("@counterId", _counterId))
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub UpdateQueueStatus(newStatus As String)
        If Not _currentServingQueueId.HasValue Then Return

        Dim query As String = If(newStatus = "completed", 
                                 "UPDATE queues SET status = @newStatus, completed_at = NOW() WHERE queue_id = @queueId AND counter_id = @counterId",
                                 "UPDATE queues SET status = @newStatus WHERE queue_id = @queueId AND counter_id = @counterId")
        
        ExecuteNonQuery(query,
                        AddressOf RefreshQueueData,
                        New MySqlParameter("@newStatus", newStatus),
                        New MySqlParameter("@queueId", _currentServingQueueId.Value),
                        New MySqlParameter("@counterId", _counterId))
    End Sub

    Private Sub OnCallNextSuccess()
        RefreshQueueData()
    End Sub

    Private Sub ExecuteNonQuery(query As String, onSuccess As Action, ParamArray parameters As MySqlParameter())
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        onSuccess?.Invoke()
                    Else
                        If query.Contains("status = 'serving'") Then
                            MessageBox.Show("There are no students in the waiting list.", "Queue Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End Using
            Catch ex As Exception
                HandleDbError("performing an update", ex)
            End Try
        End Using
    End Sub

    Private Sub frmCashierDashboard_FormClosing(sender As Object, e As FormClosingEventArgs)
        tmrQueueRefresh.Stop()
        If QueueNotifyIcon IsNot Nothing Then
            QueueNotifyIcon.Dispose()
        End If
        If _soundPlayer IsNot Nothing Then
            _soundPlayer.Dispose()
        End If

        ExecuteNonQuery("UPDATE counter_schedules SET is_open = 0 WHERE counter_id = @counterId", Nothing, New MySqlParameter("@counterId", _counterId))
        Application.OpenForms("frmLogin").Show()
    End Sub

    Private Sub HandleDbError(action As String, ex As Exception)
        tmrQueueRefresh.Stop()
        MessageBox.Show($"Error {action}: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Class QueueItem
        Public Property QueueNumber As String
        Public Property Purpose As String
        Public Property IsPriority As Boolean
    End Class

    Private Sub dgvWaitingList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWaitingList.CellContentClick

    End Sub
#End Region

End Class