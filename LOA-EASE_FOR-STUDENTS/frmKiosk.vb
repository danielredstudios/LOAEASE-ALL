Imports System.Drawing.Drawing2D
Imports System.Media
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient


Public Class frmKiosk

    Private selectedCounterId As Integer = -1
    Private selectedTimeSlot As String = ""
    Private selectedCounterName As String = ""
    Private selectedCashierName As String = ""
    Private selectedDateTime As DateTime
    Private studentId As Integer = -1
    Private isVisitorMode As Boolean = False
    Private WithEvents tmrResetView As New Timer()
    Private resetStep As Integer = 0
    Private soundPlayer As New SoundPlayer()
    Private WithEvents tmrStudentSearch As New Timer()

    Private chkDocRequestOriginalLocation As Point
    Private chkClearanceOriginalLocation As Point
    Private chkPromissoryOriginalLocation As Point

    Private _scheduledQueueId As Integer? = Nothing
    Private _scheduledTime As DateTime? = Nothing

    <DllImport("dwmapi.dll")>
    Private Shared Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Integer, ByRef attrValue As Integer, attrSize As Integer) As Integer
    End Function

    Private Const DWMWA_USE_IMMERSIVE_DARK_MODE As Integer = 20

    Private Sub frmKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGetTicket.Enabled = False
        btnCheckIn.Enabled = False
        gbDocumentRequest.Visible = False
        tcKiosk.Appearance = TabAppearance.FlatButtons
        tcKiosk.ItemSize = New Size(0, 1)
        tcKiosk.SizeMode = TabSizeMode.Fixed
        Me.ResizeRedraw = True
        
        tcKiosk.SelectedTab = tpMain
        tcKiosk.SelectedIndex = 0
        
        lblCheckInPrompt.Visible = False
        lblInstructions.Visible = True
        lblInstructions.BringToFront()
        
        ApplyRoundedCorners()
        SetRoundedCorners(lblInstructions, 5)
        
        LoadSoundFile()
        InitializeResponsive()
        tmrStudentSearch.Interval = 500
        
        pnlMainInput.Refresh()
        lblInstructions.Refresh()

        chkDocRequestOriginalLocation = chkDocRequest.Location
        chkClearanceOriginalLocation = chkClearance.Location
        chkPromissoryOriginalLocation = chkPromissory.Location
    End Sub

    Private Sub frmKiosk_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If soundPlayer IsNot Nothing Then
            soundPlayer.Dispose()
        End If
    End Sub

    Private Sub LoadSoundFile()
        Try
            Dim soundPath As String = System.IO.Path.Combine(Application.StartupPath, "Notification-Kiosk.wav")
            If System.IO.File.Exists(soundPath) Then
                soundPlayer.SoundLocation = soundPath
                soundPlayer.Load()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PlayNotificationSound()
        Try
            If Not String.IsNullOrEmpty(soundPlayer.SoundLocation) Then
                soundPlayer.Play()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ApplyRoundedCorners()
        SetRoundedCorners(pnlMainInput, 15)
        SetRoundedCorners(pnlTicketCard, 15)
        SetRoundedCorners(btnGetTicket, 10)
        SetRoundedCorners(btnNewVisitor, 10)
        SetRoundedCorners(btnCheckIn, 10)

        SetRoundedCorners(gbStudentInfo, 10)
        SetRoundedCorners(gbPurpose, 10)
        SetRoundedCorners(gbDocumentRequest, 10)
    End Sub

    Private Sub btnNewVisitor_Click(sender As Object, e As EventArgs) Handles btnNewVisitor.Click
        If isVisitorMode Then
            ResetForm()
        Else
            isVisitorMode = True
            ResetForm()
            isVisitorMode = True

            gbStudentInfo.Text = "Visitor Information"
            btnNewVisitor.Text = "I am a Student"
            btnNewVisitor.BackColor = Color.FromArgb(220, 53, 69)
            btnCheckIn.Visible = False

            txtStudentID.Visible = False
            Label1.Visible = False
            txtCourse.Visible = False
            Label4.Visible = False
            txtYearLevel.Visible = False
            Label5.Visible = False

            chkPromissory.Visible = False
            chkDocRequest.Location = chkPromissoryOriginalLocation
            chkClearance.Location = chkDocRequestOriginalLocation

            txtLastName.ReadOnly = False
            txtFirstName.ReadOnly = False

            txtLastName.Location = New Point(155, 42)
            Label2.Location = New Point(20, 44)
            txtFirstName.Location = New Point(155, 79)
            Label3.Location = New Point(20, 81)
        End If
    End Sub

    Private Sub SetRoundedCorners(ctrl As Control, radius As Integer)
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, ctrl.Width, ctrl.Height)

        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ctrl.Region = New Region(path)
    End Sub

    Private Sub frmKiosk_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ApplyResponsiveLayout()
    End Sub

    Private Sub InitializeResponsive()
        ApplyResponsiveLayout()
    End Sub

    Private Sub ApplyResponsiveLayout()
        If tpMain Is Nothing OrElse pnlMainInput Is Nothing Then Return
        
        Dim screenWidth As Integer = tpMain.ClientSize.Width
        Dim screenHeight As Integer = tpMain.ClientSize.Height
        
        Dim panelWidth As Integer = 1150
        Dim panelHeight As Integer = 880
        
        If screenWidth < panelWidth + 100 Then panelWidth = screenWidth - 100
        If screenHeight < panelHeight + 100 Then panelHeight = screenHeight - 100
        
        If panelWidth < 1000 Then panelWidth = Math.Max(1000, screenWidth - 100)
        If panelHeight < 800 Then panelHeight = Math.Max(800, screenHeight - 100)
        
        pnlMainInput.SuspendLayout()
        pnlMainInput.Size = New Size(panelWidth, panelHeight)
        pnlMainInput.Location = New Point((screenWidth - panelWidth) \ 2, (screenHeight - panelHeight) \ 2)
        
        PositionButtons(panelWidth, panelHeight)
        
        If pnlTicketResult IsNot Nothing Then
            Dim ticketWidth As Integer = Math.Min(950, screenWidth - 80)
            Dim ticketHeight As Integer = Math.Min(700, screenHeight - 80)
            pnlTicketResult.Size = New Size(ticketWidth, ticketHeight)
            If tpTicket IsNot Nothing Then
                pnlTicketResult.Location = New Point((tpTicket.ClientSize.Width - ticketWidth) \ 2, (tpTicket.ClientSize.Height - ticketHeight) \ 2)
            End If
        End If
        
        pnlMainInput.ResumeLayout()
    End Sub

    Private Sub PositionButtons(panelWidth As Integer, panelHeight As Integer)
        Dim margin As Integer = 35
        Dim buttonHeight As Integer = 65
        Dim bottomMargin As Integer = 35
        Dim buttonSpacing As Integer = 25
        
        If btnNewVisitor IsNot Nothing Then
            Dim btnWidth As Integer = 160
            Dim btnHeight As Integer = 50
            btnNewVisitor.Size = New Size(btnWidth, btnHeight)
            btnNewVisitor.Location = New Point(panelWidth - btnWidth - margin, margin)
        End If
        
        If btnCheckIn IsNot Nothing AndAlso btnCheckIn.Visible Then
            Dim totalBottomWidth As Integer = panelWidth - (2 * margin)
            Dim singleButtonWidth As Integer = (totalBottomWidth - buttonSpacing) \ 2
            
            btnCheckIn.Size = New Size(singleButtonWidth, buttonHeight)
            btnCheckIn.Location = New Point(margin, panelHeight - buttonHeight - bottomMargin)
        End If
        
        If btnGetTicket IsNot Nothing Then
            Dim leftOffset As Integer = margin
            Dim btnWidth As Integer = 0
            
            If btnCheckIn IsNot Nothing AndAlso btnCheckIn.Visible Then
                leftOffset = btnCheckIn.Right + buttonSpacing
                Dim totalBottomWidth As Integer = panelWidth - (2 * margin)
                btnWidth = (totalBottomWidth - buttonSpacing) \ 2
            Else
                btnWidth = panelWidth - (2 * margin)
            End If
            
            btnGetTicket.Size = New Size(btnWidth, buttonHeight)
            btnGetTicket.Location = New Point(leftOffset, panelHeight - buttonHeight - bottomMargin)
        End If
    End Sub

    Private Sub MakeResponsive()
        ApplyResponsiveLayout()
    End Sub

    Private Sub ScaleFontsRecursive(parent As Control, scale As Double)
        UpdateFontsWithScale(parent, scale)
    End Sub

    Private Sub CenterPanel()
        pnlMainInput.Left = (tpMain.ClientSize.Width - pnlMainInput.Width) / 2
        pnlMainInput.Top = (tpMain.ClientSize.Height - pnlMainInput.Height) / 2
        pnlTicketResult.Left = (tpTicket.ClientSize.Width - pnlTicketResult.Width) / 2
        pnlTicketResult.Top = (tpTicket.ClientSize.Height - pnlTicketResult.Height) / 2
    End Sub

    Private Sub btnGetTicket_MouseEnter(sender As Object, e As EventArgs) Handles btnGetTicket.MouseEnter
        btnGetTicket.BackColor = Color.FromArgb(230, 179, 24)
        btnGetTicket.Font = New Font("Poppins", 18.5F, FontStyle.Bold)
    End Sub

    Private Sub btnGetTicket_MouseLeave(sender As Object, e As EventArgs) Handles btnGetTicket.MouseLeave
        btnGetTicket.BackColor = Color.FromArgb(255, 199, 44)
        btnGetTicket.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
    End Sub

    Private Sub AdjustLabelFont(lbl As Label)
        If String.IsNullOrEmpty(lbl.Text) Then Return
        Dim maxSize As Size = New Size(lbl.Width - 60, Integer.MaxValue)
        Dim initialFontSize As Single = 56.0F
        Dim currentFontSize As Single = initialFontSize
        Dim measuredSize As SizeF
        Do
            Dim currentFont As New Font(lbl.Font.FontFamily, currentFontSize, lbl.Font.Style)
            measuredSize = TextRenderer.MeasureText(lbl.Text, currentFont, maxSize)
            If measuredSize.Width > lbl.Width - 60 Then
                currentFontSize -= 1.0F
            Else
                lbl.Font = currentFont
                Exit Do
            End If
            currentFont.Dispose()
        Loop While currentFontSize > 20
        If lbl.Font.Size < 20 Then
            lbl.Font = New Font(lbl.Font.FontFamily, 20.0F, lbl.Font.Style)
        End If
    End Sub

    Private Sub ResetForm()
        txtStudentID.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtCourse.Clear()
        txtYearLevel.Clear()
        chkIsPriority.Checked = False
        chkTuition.Checked = False
        chkEnrollment.Checked = False
        chkPromissory.Checked = False
        chkDocRequest.Checked = False
        chkClearance.Checked = False
        chkDiploma.Checked = False
        chkTOR.Checked = False
        chkGMC.Checked = False
        studentId = -1
        selectedCounterId = -1
        selectedTimeSlot = ""
        selectedCounterName = ""
        selectedCashierName = ""
        btnGetTicket.Enabled = False
        btnCheckIn.Enabled = False
        btnCheckIn.Visible = True
        btnCheckIn.Text = "Check-In for Appointment"
        gbPurpose.Enabled = True
        _scheduledQueueId = Nothing
        _scheduledTime = Nothing
        tcKiosk.SelectedTab = tpMain

        lblCheckInPrompt.Visible = False
        lblCheckInPrompt.Text = ""

        isVisitorMode = False
        gbStudentInfo.Text = "Student Information"
        If btnNewVisitor IsNot Nothing Then
            btnNewVisitor.Text = "Visitor"
            btnNewVisitor.BackColor = Color.FromArgb(0, 123, 255)
        End If

        txtStudentID.Visible = True
        Label1.Visible = True
        txtCourse.Visible = True
        Label4.Visible = True
        txtYearLevel.Visible = True
        Label5.Visible = True

        chkTuition.Visible = True
        chkEnrollment.Visible = True
        chkPromissory.Visible = True
        chkDocRequest.Visible = True
        chkClearance.Visible = True

        chkDocRequest.Location = chkDocRequestOriginalLocation
        chkClearance.Location = chkClearanceOriginalLocation
        chkPromissory.Location = chkPromissoryOriginalLocation

        txtLastName.ReadOnly = True
        txtFirstName.ReadOnly = True

        txtStudentID.Location = New Point(155, 42)
        Label1.Location = New Point(20, 44)
        txtLastName.Location = New Point(155, 79)
        Label2.Location = New Point(20, 81)
        txtFirstName.Location = New Point(155, 116)
        Label3.Location = New Point(20, 118)
        txtCourse.Location = New Point(155, 153)
        Label4.Location = New Point(20, 155)
        txtYearLevel.Location = New Point(155, 190)
        Label5.Location = New Point(20, 192)
    End Sub

    Private Sub FindBestCounterAndTimeSlot()
        Dim purpose As String = GetPurposeString()
        Dim isPriority As Boolean = chkIsPriority.Checked
        selectedCounterId = FindAvailableCounter(purpose, isPriority)
        If selectedCounterId <> -1 Then
            FetchCounterDetails(selectedCounterId)
            Dim selectedDate As DateTime = DateTime.Today
            Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
                Try
                    conn.Open()
                    FindEarliestAvailableTimeSlot(conn, selectedDate, selectedCounterId)
                Catch ex As Exception
                    MessageBox.Show("Unable to find available time. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        Else
            selectedTimeSlot = "No available slots"
        End If
        UpdateUIWithSelection()
    End Sub

    Private Function FindAvailableCounter(purpose As String, isPriority As Boolean) As Integer
        Dim counterStatuses As New Dictionary(Of Integer, Tuple(Of Boolean, String))
        Dim query As String = "SELECT counter_id, is_open, status FROM counter_schedules WHERE counter_id IN (1, 2, 3, 4)"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            counterStatuses(reader.GetInt32("counter_id")) = New Tuple(Of Boolean, String)(reader.GetBoolean("is_open"), reader.GetString("status"))
                        End While
                    End Using
                End Using
                If purpose.Contains("Document Request") Or purpose.Contains("Clearance Signing") Then
                    If counterStatuses.ContainsKey(4) AndAlso counterStatuses(4).Item1 AndAlso counterStatuses(4).Item2 = "open" Then
                        Return 4
                    Else
                        Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2, 3})
                    End If
                End If
                If isPriority Then
                    If counterStatuses.ContainsKey(3) AndAlso counterStatuses(3).Item1 AndAlso counterStatuses(3).Item2 = "open" Then
                        Return 3
                    Else
                        Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2})
                    End If
                End If
                Return FindAvailableLeastBusyCounter(conn, counterStatuses, New List(Of Integer) From {1, 2})
            Catch ex As Exception
                MessageBox.Show("Unable to check counters. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -1
            End Try
        End Using
    End Function

    Private Function FindAvailableLeastBusyCounter(conn As MySqlConnection, statuses As Dictionary(Of Integer, Tuple(Of Boolean, String)), countersToCheck As List(Of Integer)) As Integer
        Dim availableCounters As New List(Of Integer)
        For Each counterId In countersToCheck
            If statuses.ContainsKey(counterId) AndAlso statuses(counterId).Item1 AndAlso statuses(counterId).Item2 = "open" Then
                availableCounters.Add(counterId)
            End If
        Next
        If availableCounters.Count = 0 Then
            Return -1
        ElseIf availableCounters.Count = 1 Then
            Return availableCounters(0)
        Else
            Dim counterAppointments As New Dictionary(Of Integer, Integer)
            Dim query As String = $"SELECT counter_id, COUNT(*) as appointment_count FROM queues WHERE DATE(schedule_datetime) = CURDATE() AND counter_id IN ({String.Join(",", availableCounters)}) GROUP BY counter_id"
            For Each counterId In availableCounters
                counterAppointments.Add(counterId, 0)
            Next
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        counterAppointments(reader.GetInt32("counter_id")) = reader.GetInt32("appointment_count")
                    End While
                End Using
            End Using
            Dim leastBusyCounter As Integer = -1
            Dim minAppointments As Integer = Integer.MaxValue
            For Each counterId In availableCounters
                If counterAppointments(counterId) < minAppointments Then
                    minAppointments = counterAppointments(counterId)
                    leastBusyCounter = counterId
                End If
            Next
            Return leastBusyCounter
        End If
    End Function

    Private Sub FetchCounterDetails(counterId As Integer)
        Dim counterQuery As String = "SELECT counter_name FROM counters WHERE counter_id = @counter_id"
        Dim cashierQuery As String = "SELECT full_name FROM cashiers WHERE counter_id = @counter_id"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(counterQuery, conn)
                    cmd.Parameters.AddWithValue("@counter_id", counterId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        selectedCounterName = result.ToString()
                    Else
                        selectedCounterName = "N/A"
                    End If
                End Using
                Using cmd As New MySqlCommand(cashierQuery, conn)
                    cmd.Parameters.AddWithValue("@counter_id", counterId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        selectedCashierName = result.ToString()
                    Else
                        selectedCashierName = "Not Assigned"
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Unable to get counter information. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                selectedCounterName = "Error"
                selectedCashierName = "Error"
            End Try
        End Using
    End Sub

    Private Sub FindEarliestAvailableTimeSlot(conn As MySqlConnection, selectedDate As DateTime, counterId As Integer)
        Dim bookedSlots As New List(Of TimeSpan)
        Dim query As String = "SELECT TIME(schedule_datetime) FROM queues WHERE counter_id = @counter_id AND DATE(schedule_datetime) = @schedule_date"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@counter_id", counterId)
            cmd.Parameters.AddWithValue("@schedule_date", selectedDate.ToString("yyyy-MM-dd"))
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    bookedSlots.Add(reader.GetTimeSpan(0))
                End While
            End Using
        End Using
        Dim startTime As DateTime = DateTime.Today.AddHours(8)
        Dim endTime As DateTime = DateTime.Today.AddHours(17)
        Dim interval As TimeSpan = TimeSpan.FromMinutes(30)
        Dim currentTime As DateTime = startTime
        While currentTime < endTime
            If Not bookedSlots.Contains(currentTime.TimeOfDay) Then
                selectedTimeSlot = currentTime.ToString("hh:mm tt")
                selectedDateTime = currentTime
                Exit Sub
            End If
            currentTime = currentTime.Add(interval)
        End While
        selectedTimeSlot = "No available slots"
    End Sub

    Private Sub UpdateUIWithSelection()
        Dim purposeSelected As Boolean = chkTuition.Checked Or chkEnrollment.Checked Or chkPromissory.Checked Or chkDocRequest.Checked Or chkClearance.Checked
        Dim hasSlot As Boolean = (selectedCounterId <> -1 AndAlso Not String.IsNullOrEmpty(selectedTimeSlot) AndAlso selectedTimeSlot <> "No available slots")
        Dim validVisitor As Boolean = False

        If isVisitorMode Then
            validVisitor = (Not String.IsNullOrWhiteSpace(txtLastName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtFirstName.Text))
        End If

        Dim validStudent As Boolean = (Not isVisitorMode AndAlso studentId <> -1)

        If _scheduledQueueId.HasValue Then
            btnGetTicket.Enabled = False
        Else
            btnGetTicket.Enabled = (validStudent Or validVisitor) AndAlso purposeSelected AndAlso hasSlot
            If Not hasSlot AndAlso (validStudent Or validVisitor) AndAlso purposeSelected Then
                MessageBox.Show("All counters for your purpose are currently unavailable or fully booked. Please try again later.", "No Slots Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Function GetCoursePrefix(studentId As Integer, conn As MySqlConnection, transaction As MySqlTransaction, isVisitor As Boolean) As String
        If isVisitor Then
            Return "VIS"
        End If

        Dim course As String = ""
        Dim query As String = "SELECT course FROM students WHERE student_id = @student_id"
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@student_id", studentId)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                course = result.ToString()
            Else
                course = "GEN"
            End If
        End Using

        Select Case course
            Case "Visitor"
                Return "VIS"
            Case "Bachelor of Science in Psychology"
                Return "CAS"
            Case "Bachelor of Science in Accountancy", "Bachelor of Science in Customs Administration", "Bachelor of Science in Business Administration", "Major in Marketing Management", "Major in Financial Management", "Major in Human Resource Development Management"
                Return "CBME"
            Case "Bachelor of Science in Criminology"
                Return "CCJ"
            Case "Bachelor of Science in Computer Science"
                Return "CCS"
            Case "Bachelor of Science in Information Technology"
                Return "BSIT"
            Case "Bachelor of Elementary Education", "Bachelor of Secondary Education", "Major in English", "Major in Filipino", "Major in Mathematics", "Bachelor of Technical Vocational for Teacher Education", "Major in Automotive Technology", "Major in Computer Programming", "Major in Food Service Management", "Major in Electronics Technology", "Major in Welding and Fabrication"
                Return "COE"
            Case "Bachelor of Science in Industrial Engineering", "Bachelor of Science in Computer Engineering"
                Return "CEN"
            Case "Juris Doctor Program"
                Return "COL"
            Case "Bachelor of Science in Real Estate Management"
                Return "CREM"
            Case "Bachelor of Science in Tourism Management", "Bachelor of Science in Hospitality Management"
                Return "CTHM"
            Case Else
                Return "GEN"
        End Select
    End Function

    Private Function HasActiveTicket(currentStudentId As Integer) As Boolean
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM queues WHERE student_id = @student_id AND status IN ('waiting', 'serving') AND DATE(schedule_datetime) = CURDATE()"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Unable to check your ticket status. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End Try
        End Using
    End Function

    Private Sub btnGetTicket_Click(sender As Object, e As EventArgs) Handles btnGetTicket.Click
        Dim purpose As String = GetPurposeString()
        If String.IsNullOrWhiteSpace(purpose) Then
            MessageBox.Show("Please select a purpose for your visit.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If chkDocRequest.Checked AndAlso Not (chkDiploma.Checked Or chkTOR.Checked Or chkGMC.Checked) Then
            MessageBox.Show("Please select at least one type of document to request.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If isVisitorMode Then
            If String.IsNullOrWhiteSpace(txtLastName.Text) Or String.IsNullOrWhiteSpace(txtFirstName.Text) Then
                MessageBox.Show("Please enter your First and Last Name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            If studentId = -1 Then
                MessageBox.Show("Please enter a valid Student ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If HasActiveTicket(studentId) Then
                MessageBox.Show("You already have an active transaction." & vbCrLf & "Please complete your current transaction before getting a new ticket.", "Active Transaction Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        FindBestCounterAndTimeSlot()
        If selectedCounterId = -1 OrElse selectedTimeSlot = "No available slots" Then
            MessageBox.Show("No available slots. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim queueNumber As String = ""
        Dim isPriority As Integer = If(chkIsPriority.Checked, 1, 0)

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                If isVisitorMode Then
                    Dim fullName As String = txtFirstName.Text.Trim() & " " & txtLastName.Text.Trim()
                    Dim insertVisitorQuery = "INSERT INTO visitors (full_name, created_at) VALUES (@full_name, NOW())"
                    Using visitorCmd As New MySqlCommand(insertVisitorQuery, conn, transaction)
                        visitorCmd.Parameters.AddWithValue("@full_name", fullName)
                        visitorCmd.ExecuteNonQuery()
                        studentId = CInt(visitorCmd.LastInsertedId)
                    End Using
                End If

                Dim prefix As String = GetCoursePrefix(studentId, conn, transaction, isVisitorMode)
                If isPriority = 1 Then
                    prefix = "P-" & prefix
                End If
                Dim datePart As String = DateTime.Now.ToString("MMdd")
                Dim countQuery As String = "SELECT COUNT(*) FROM queues WHERE DATE(created_at) = CURDATE()"
                Dim countCmd As New MySqlCommand(countQuery, conn, transaction)
                Dim nextNum As Integer = Convert.ToInt32(countCmd.ExecuteScalar()) + 1
                queueNumber = $"{prefix}-{datePart}-{nextNum:D3}"
                Dim status As String = "waiting"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                cmd.Transaction = transaction
                cmd.CommandText = "INSERT INTO queues (student_id, counter_id, queue_number, purpose, is_priority, status, schedule_datetime, created_at, is_visitor) " &
                                  "VALUES (@student_id, @counter_id, @queue_number, @purpose, @is_priority, @status, @schedule_datetime, NOW(), @is_visitor)"
                cmd.Parameters.AddWithValue("@student_id", studentId)
                cmd.Parameters.AddWithValue("@counter_id", selectedCounterId)
                cmd.Parameters.AddWithValue("@queue_number", queueNumber)
                cmd.Parameters.AddWithValue("@purpose", purpose)
                cmd.Parameters.AddWithValue("@is_priority", isPriority)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@schedule_datetime", selectedDateTime)
                cmd.Parameters.AddWithValue("@is_visitor", If(isVisitorMode, 1, 0))
                cmd.ExecuteNonQuery()
                transaction.Commit()

                ShowTicket(queueNumber)
            Catch ex As MySqlException When ex.Number = 1054
                transaction.Rollback()
                MessageBox.Show("Database table needs updating. Please contact staff - missing is_visitor column.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Unable to create your ticket. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function GetPurposeString() As String
        Dim purposes As New List(Of String)
        If chkTuition.Checked Then purposes.Add("Tuition Payment")
        If chkEnrollment.Checked Then purposes.Add("Enrollment Concern")
        If chkPromissory.Checked Then purposes.Add("Promissory Note")
        If chkClearance.Checked Then purposes.Add("Clearance Signing")
        Dim docRequests As New List(Of String)
        If chkDocRequest.Checked Then
            purposes.Add("Document Request")
            If chkDiploma.Checked Then docRequests.Add("Diploma")
            If chkTOR.Checked Then docRequests.Add("Transcript of Records (TOR)")
            If chkGMC.Checked Then docRequests.Add("Good Moral Certificate")
            If docRequests.Count > 0 Then
                purposes.Add("doc_req:" & String.Join(", ", docRequests))
            End If
        End If
        Return String.Join(", ", purposes)
    End Function

    Private Sub btnNewTransaction_Click(sender As Object, e As EventArgs)
        ResetForm()
    End Sub

    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged
        If isVisitorMode Then Return

        txtLastName.Clear()
        txtFirstName.Clear()
        txtCourse.Clear()
        txtYearLevel.Clear()

        chkIsPriority.Checked = False
        chkTuition.Checked = False
        chkEnrollment.Checked = False
        chkPromissory.Checked = False
        chkDocRequest.Checked = False
        chkClearance.Checked = False
        studentId = -1
        selectedCounterId = -1
        selectedTimeSlot = ""
        btnGetTicket.Enabled = False
        btnCheckIn.Enabled = False
        btnCheckIn.Text = "Check-In for Appointment"
        gbPurpose.Enabled = True

        txtLastName.ReadOnly = True
        txtFirstName.ReadOnly = True

        tmrStudentSearch.Stop()

        If txtStudentID.Text.Length > 4 Then
            tmrStudentSearch.Start()
        Else
            UpdateUIWithSelection()
        End If
    End Sub

    Private Sub tmrStudentSearch_Tick(sender As Object, e As EventArgs) Handles tmrStudentSearch.Tick
        tmrStudentSearch.Stop()

        If Not isVisitorMode AndAlso txtStudentID.Text.Length > 4 Then
            FetchStudentDetails(txtStudentID.Text.Trim())
        End If
    End Sub

    Private Sub FetchStudentDetails(studentNumber As String)
        Dim queryNumber As String = studentNumber
        If Not studentNumber.StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
            queryNumber = "C" & studentNumber
        End If
        Dim query As String = "SELECT student_id, last_name, first_name, course, year_level FROM students WHERE student_number = @student_number"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_number", queryNumber)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            studentId = reader.GetInt32("student_id")
                            txtLastName.Text = reader.GetString("last_name")
                            txtFirstName.Text = reader.GetString("first_name")
                            txtCourse.Text = reader.GetString("course")
                            If Not reader.IsDBNull(reader.GetOrdinal("year_level")) Then
                                txtYearLevel.Text = reader.GetString("year_level")
                            Else
                                txtYearLevel.Text = "N/A"
                            End If

                            CheckForScheduledAppointment(studentId)
                            FindBestCounterAndTimeSlot()
                        Else
                            studentId = -1
                            txtLastName.Text = "Student Not Found"
                            txtFirstName.Text = "Check ID or tap 'Visitor'"
                            btnCheckIn.Enabled = False
                            UpdateUIWithSelection()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Unable to look up student. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub SetPurposeCheckBoxes(purposeString As String)
        If String.IsNullOrWhiteSpace(purposeString) Then Return

        Dim purposes = purposeString.Split(New String() {", "}, StringSplitOptions.RemoveEmptyEntries)
        For Each purpose In purposes
            Select Case True
                Case purpose.Equals("Tuition Payment", StringComparison.OrdinalIgnoreCase)
                    chkTuition.Checked = True
                Case purpose.Equals("Enrollment Concern", StringComparison.OrdinalIgnoreCase)
                    chkEnrollment.Checked = True
                Case purpose.Equals("Promissory Note", StringComparison.OrdinalIgnoreCase)
                    chkPromissory.Checked = True
                Case purpose.Equals("Clearance Signing", StringComparison.OrdinalIgnoreCase)
                    chkClearance.Checked = True
                Case purpose.Equals("Document Request", StringComparison.OrdinalIgnoreCase)
                    chkDocRequest.Checked = True
                Case purpose.StartsWith("doc_req:", StringComparison.OrdinalIgnoreCase)
                    Dim docTypes = purpose.Substring(8)
                    If docTypes.Contains("Diploma") Then chkDiploma.Checked = True
                    If docTypes.Contains("Transcript of Records (TOR)") Then chkTOR.Checked = True
                    If docTypes.Contains("Good Moral Certificate") Then chkGMC.Checked = True
            End Select
        Next
    End Sub

    Private Sub CheckForScheduledAppointment(currentStudentId As Integer)
        _scheduledQueueId = Nothing
        _scheduledTime = Nothing
        btnCheckIn.Enabled = False
        gbPurpose.Enabled = True

        Dim query As String = "SELECT queue_id, schedule_datetime, purpose FROM queues WHERE student_id = @student_id AND status = 'scheduled' AND DATE(schedule_datetime) = CURDATE() LIMIT 1"
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            _scheduledQueueId = reader.GetInt32("queue_id")
                            _scheduledTime = reader.GetDateTime("schedule_datetime")
                            Dim purposeString As String = reader.GetString("purpose")
                            SetPurposeCheckBoxes(purposeString)

                            Dim officeStartTime As DateTime = DateTime.Today.AddHours(8)
                            Dim officeEndTime As DateTime = DateTime.Today.AddHours(17)
                            Dim now As DateTime = DateTime.Now

                            If now >= officeStartTime AndAlso now <= officeEndTime Then
                                btnCheckIn.Enabled = True
                                btnCheckIn.Text = "Check-In"
                                gbPurpose.Enabled = False
                                btnGetTicket.Enabled = False

                                lblCheckInPrompt.Text = "Your appointment is today! Please tap to check-in."
                                lblCheckInPrompt.ForeColor = Color.FromArgb(40, 167, 69)
                                lblCheckInPrompt.Visible = True

                            ElseIf now < officeStartTime Then
                                btnCheckIn.Enabled = False
                                btnCheckIn.Text = "Check-In Opens Soon"
                                gbPurpose.Enabled = False
                                btnGetTicket.Enabled = False

                                lblCheckInPrompt.Text = $"Check-in opens at {officeStartTime.ToString("hh:mm tt")}."
                                lblCheckInPrompt.ForeColor = Color.FromArgb(0, 123, 255)
                                lblCheckInPrompt.Visible = True
                            Else
                                btnCheckIn.Enabled = False
                                btnCheckIn.Text = "Office Closed"
                                gbPurpose.Enabled = False
                                btnGetTicket.Enabled = False

                                lblCheckInPrompt.Text = "Check-in is closed for the day. Please see staff."
                                lblCheckInPrompt.ForeColor = Color.FromArgb(220, 53, 69)
                                lblCheckInPrompt.Visible = True
                            End If
                        Else
                            btnCheckIn.Text = "Check-In for Appointment"
                            lblCheckInPrompt.Visible = False
                        End If
                    End Using
                End Using
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Function IsCounterOpen(counterId As Integer) As Boolean
        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Dim query As String = "SELECT is_open, status FROM counter_schedules WHERE counter_id = @counter_id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@counter_id", counterId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim isOpen As Boolean = reader.GetBoolean("is_open")
                            Dim status As String = reader.GetString("status")
                            Return isOpen AndAlso status.Equals("open", StringComparison.OrdinalIgnoreCase)
                        Else
                            Return False
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Private Sub btnCheckIn_Click(sender As Object, e As EventArgs) Handles btnCheckIn.Click
        If Not _scheduledQueueId.HasValue Then
            MessageBox.Show("No scheduled appointment found to check in.", "Check-In Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim officeStartTime As DateTime = DateTime.Today.AddHours(8)
        Dim officeEndTime As DateTime = DateTime.Today.AddHours(17)
        Dim now As DateTime = DateTime.Now

        If now < officeStartTime Then
            MessageBox.Show($"Check-in is not yet open. The office opens at {officeStartTime.ToString("hh:mm tt")}.", "Check-In Not Open", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If now > officeEndTime Then
            MessageBox.Show("The office is now closed. Check-in is no longer available.", "Check-In Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim assignedCounterId As Integer = -1
        Dim queueNumber As String = ""

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()

                Dim selectQuery As String = "SELECT queue_number, counter_id FROM queues WHERE queue_id = @queue_id AND status = 'scheduled'"
                Using cmdSelect As New MySqlCommand(selectQuery, conn)
                    cmdSelect.Parameters.AddWithValue("@queue_id", _scheduledQueueId.Value)
                    Using reader As MySqlDataReader = cmdSelect.ExecuteReader()
                        If reader.Read() Then
                            queueNumber = reader.GetString("queue_number")
                            assignedCounterId = reader.GetInt32("counter_id")
                        Else
                            MessageBox.Show("Could not check in. Your appointment may have already been processed or cancelled.", "Check-In Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using

                If Not IsCounterOpen(assignedCounterId) Then
                    MessageBox.Show("Your assigned counter is currently closed. Please see staff for assistance.", "Counter Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim updateQuery As String = "UPDATE queues SET status = 'waiting', created_at = NOW() WHERE queue_id = @queue_id AND status = 'scheduled'"
                Using cmdUpdate As New MySqlCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@queue_id", _scheduledQueueId.Value)
                    Dim rowsAffected = cmdUpdate.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        FetchCounterDetails(assignedCounterId)
                        ShowTicket(queueNumber)
                    Else
                        MessageBox.Show("Could not check in. Your appointment may have already been processed or cancelled.", "Check-In Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Unable to check in. Please try again or ask staff for help.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub chkDocRequest_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocRequest.CheckedChanged
        gbDocumentRequest.Visible = chkDocRequest.Checked
        FindBestCounterAndTimeSlot()
    End Sub

    Private Sub Purpose_CheckedChanged(sender As Object, e As EventArgs) Handles chkTuition.CheckedChanged, chkEnrollment.CheckedChanged, chkPromissory.CheckedChanged, chkIsPriority.CheckedChanged, txtLastName.TextChanged, txtFirstName.TextChanged, chkDiploma.CheckedChanged, chkTOR.CheckedChanged, chkGMC.CheckedChanged, chkClearance.CheckedChanged
        If TypeOf sender Is CheckBox AndAlso DirectCast(sender, CheckBox).Name = "chkIsPriority" AndAlso chkIsPriority.Checked Then
            MessageBox.Show("Priority lane is intended for pregnant, PWD, and senior citizens.", "Priority Lane", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        FindBestCounterAndTimeSlot()
    End Sub

    Private Sub ShowTicket(queueNumber As String)
        lblQueueNumber.Text = queueNumber
        lblAssignedCounter.Text = $"Counter: {selectedCounterName}"
        lblAssignedCashier.Text = $"Cashier: {selectedCashierName}"
        tcKiosk.SelectedTab = tpTicket

        PlayNotificationSound()

        resetStep = 1
        tmrResetView.Interval = 5000
        tmrResetView.Start()
    End Sub

    Private Sub tmrResetView_Tick(sender As Object, e As EventArgs) Handles tmrResetView.Tick
        tmrResetView.Stop()
        If resetStep = 1 Then
            lblQueueNumber.Text = "Thank You!"
            lblAssignedCounter.Text = ""
            lblAssignedCashier.Text = ""

            PlayNotificationSound()

            resetStep = 2
            tmrResetView.Interval = 2000
            tmrResetView.Start()
        ElseIf resetStep = 2 Then
            resetStep = 0
            ResetForm()
        End If
    End Sub

End Class

