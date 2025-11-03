Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Media
Imports System.IO

Public Class frmQueueDisplay
    ' Sound player for notification sounds
    Private notificationPlayer As SoundPlayer
    Private callQueuePlayer As SoundPlayer

    ' Track previous queue state for change detection
    Private previousServingQueues As New List(Of String)
    Private previousWaitingCount As Integer = 0

    ' Sound file paths (relative to application directory)
    Private Const SOUND_NEW_QUEUE As String = "Sounds\notification.wav"
    Private Const SOUND_CALL_QUEUE As String = "Sounds\call_queue.wav"

    ' Enable/disable sound effects
    Public Property SoundEffectsEnabled As Boolean = True

    Private Sub frmQueueDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize sound players
            InitializeSoundPlayers()

            ' Initial update
            UpdateQueueDisplay()

            ' Start the refresh timer
            RefreshTimer.Start()
        Catch ex As Exception
            MessageBox.Show($"Error loading queue display: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeSoundPlayers()
        Try
            ' Create Sounds directory if it doesn't exist
            Dim soundsPath As String = Path.Combine(Application.StartupPath, "Sounds")
            If Not Directory.Exists(soundsPath) Then
                Directory.CreateDirectory(soundsPath)
            End If

            ' Initialize notification sound player
            Dim notificationPath As String = Path.Combine(Application.StartupPath, SOUND_NEW_QUEUE)
            If File.Exists(notificationPath) Then
                notificationPlayer = New SoundPlayer(notificationPath)
                notificationPlayer.Load()
            End If

            ' Initialize call queue sound player
            Dim callQueuePath As String = Path.Combine(Application.StartupPath, SOUND_CALL_QUEUE)
            If File.Exists(callQueuePath) Then
                callQueuePlayer = New SoundPlayer(callQueuePath)
                callQueuePlayer.Load()
            End If

        Catch ex As Exception
            Debug.WriteLine($"Sound initialization error: {ex.Message}")
            ' Continue without sound if there's an error
        End Try
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        UpdateQueueDisplay()
    End Sub

    Public Sub UpdateQueueDisplay()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf UpdateQueueDisplay))
        Else
            ' Track current state before clearing
            Dim currentServingQueues As New List(Of String)
            Dim currentWaitingCount As Integer = 0

            ' Clear panels
            flpNowServing.Controls.Clear()
            flpWaiting.Controls.Clear()

            ' Populate panels and get current state
            currentServingQueues = PopulateNowServingPanel()
            currentWaitingCount = PopulateWaitingPanel()

            ' Update queue count display
            UpdateQueueCountLabel(currentWaitingCount)

            ' Detect changes and play sounds
            DetectChangesAndPlaySounds(currentServingQueues, currentWaitingCount)

            ' Update previous state
            previousServingQueues = New List(Of String)(currentServingQueues)
            previousWaitingCount = currentWaitingCount
        End If
    End Sub

    Private Function PopulateNowServingPanel() As List(Of String)
        Dim servingQueues As New List(Of String)
        Dim query As String = "SELECT q.queue_number, c.counter_name " &
                              "FROM queues q " &
                              "JOIN counters c ON q.counter_id = c.counter_id " &
                              "WHERE q.status = 'serving' AND DATE(q.schedule_datetime) = CURDATE() " &
                              "ORDER BY c.counter_id ASC"

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.HasRows Then
                            ShowEmptyMessage(flpNowServing, "No one is currently being served.")
                        Else
                            While reader.Read()
                                Dim queueNumber As String = reader("queue_number").ToString()
                                Dim counterName As String = reader("counter_name").ToString()

                                ' Add to tracking list
                                servingQueues.Add(queueNumber)

                                ' Create and add counter control
                                Dim counterControl As New ucCounter()
                                counterControl.QueueNumber = queueNumber
                                counterControl.CounterName = counterName
                                flpNowServing.Controls.Add(counterControl)
                            End While
                        End If
                    End Using
                End Using
            Catch ex As Exception
                RefreshTimer.Stop()
                MessageBox.Show("Failed to load 'Now Serving' data. Please check the database connection." & vbCrLf & "Error: " & ex.Message,
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return servingQueues
    End Function

    Private Function PopulateWaitingPanel() As Integer
        Dim waitingCount As Integer = 0
        Dim query As String = "SELECT queue_number FROM queues WHERE status = 'waiting' AND DATE(schedule_datetime) = CURDATE() ORDER BY is_priority DESC, created_at ASC"

        Using conn As New MySqlConnection(DatabaseHelper.GetConnectionString())
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Dim waitingList As New List(Of String)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            waitingList.Add(reader("queue_number").ToString())
                        End While
                    End Using

                    waitingCount = waitingList.Count

                    If waitingList.Count > 0 Then
                        For Each queueNumber As String In waitingList
                            Dim lblQueueItem As New Label()
                            lblQueueItem.Text = queueNumber
                            lblQueueItem.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point)
                            lblQueueItem.ForeColor = Color.White
                            lblQueueItem.BackColor = Color.FromArgb(255, 13, 110, 253)
                            lblQueueItem.TextAlign = ContentAlignment.MiddleCenter
                            lblQueueItem.Size = New Size(flpWaiting.ClientSize.Width - 40, 60)
                            lblQueueItem.Margin = New Padding(8)
                            lblQueueItem.AutoSize = False
                            lblQueueItem.UseMnemonic = False
                            lblQueueItem.UseCompatibleTextRendering = False

                            ' Add smooth corners effect
                            lblQueueItem.Padding = New Padding(10)

                            flpWaiting.Controls.Add(lblQueueItem)
                        Next
                    Else
                        ShowEmptyMessage(flpWaiting, "No students are currently waiting.")
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine("Failed to load waiting list: " & ex.Message)
                Debug.WriteLine($"Waiting list error: {ex.Message}")
            End Try
        End Using

        Return waitingCount
    End Function

    Private Sub ShowEmptyMessage(ByVal panel As FlowLayoutPanel, ByVal message As String)
        Dim lblEmpty As New Label()
        lblEmpty.Text = message
        lblEmpty.Font = New Font("Segoe UI", 14.0F, FontStyle.Italic, GraphicsUnit.Point)
        lblEmpty.ForeColor = Color.FromArgb(184, 212, 241) ' Lighter shade to match theme
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter
        lblEmpty.Size = New Size(panel.ClientSize.Width - 40, 100)
        lblEmpty.AutoSize = False
        lblEmpty.UseMnemonic = False
        lblEmpty.UseCompatibleTextRendering = False
        panel.Controls.Add(lblEmpty)
    End Sub

    Private Sub UpdateQueueCountLabel(waitingCount As Integer)
        Try
            ' Update the queue count label with proper grammar
            Dim countText As String = If(waitingCount = 1,
                                        "1 student waiting",
                                        $"{waitingCount} students waiting")

            lblQueueCount.Text = countText

        Catch ex As Exception
            Debug.WriteLine($"Error updating queue count: {ex.Message}")
        End Try
    End Sub

    Private Sub DetectChangesAndPlaySounds(currentServingQueues As List(Of String), currentWaitingCount As Integer)
        If Not SoundEffectsEnabled Then Return

        Try
            ' Detect new queue being called (newly added to serving)
            Dim newQueuesCalled = currentServingQueues.Except(previousServingQueues).ToList()
            If newQueuesCalled.Count > 0 Then
                PlayCallQueueSound()
                Debug.WriteLine($"New queue called: {String.Join(", ", newQueuesCalled)}")
            End If

            ' Detect new customer added to waiting queue
            If currentWaitingCount > previousWaitingCount Then
                PlayNotificationSound()
                Debug.WriteLine($"New customer added. Count: {currentWaitingCount}")
            End If

        Catch ex As Exception
            Debug.WriteLine($"Error detecting changes: {ex.Message}")
        End Try
    End Sub

    Private Sub PlayNotificationSound()
        Try
            If notificationPlayer IsNot Nothing Then
                ' Play asynchronously to not block UI
                Task.Run(Sub()
                             Try
                                 notificationPlayer.Play()
                             Catch ex As Exception
                                 Debug.WriteLine($"Error playing notification: {ex.Message}")
                             End Try
                         End Sub)
            Else
                ' Fallback to system beep
                SystemSounds.Beep.Play()
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error playing notification sound: {ex.Message}")
        End Try
    End Sub

    Private Sub PlayCallQueueSound()
        Try
            If callQueuePlayer IsNot Nothing Then
                ' Play asynchronously to not block UI
                Task.Run(Sub()
                             Try
                                 callQueuePlayer.Play()
                             Catch ex As Exception
                                 Debug.WriteLine($"Error playing call queue: {ex.Message}")
                             End Try
                         End Sub)
            Else
                ' Fallback to system exclamation
                SystemSounds.Exclamation.Play()
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error playing call queue sound: {ex.Message}")
        End Try
    End Sub

    ' Optional: Add method to toggle sound effects (can be called from settings or right-click menu)
    Public Sub ToggleSoundEffects()
        SoundEffectsEnabled = Not SoundEffectsEnabled

        Dim status As String = If(SoundEffectsEnabled, "enabled", "disabled")
        Debug.WriteLine($"Sound effects {status}")

        ' Optional: Show a brief notification
        ' You can add a toast notification here if desired
    End Sub

    ' Handle keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                ' Exit fullscreen
                Me.Close()
                Return True

            Case Keys.F5
                ' Manual refresh
                UpdateQueueDisplay()
                Return True

            Case Keys.F11
                ' Toggle sound effects
                ToggleSoundEffects()
                Return True

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    Private Sub lblQueueHeader_Click(sender As Object, e As EventArgs) Handles lblQueueHeader.Click
        ' Optional: Add functionality like opening settings or toggling sound
        ' For now, we can use it to toggle sound effects
        ToggleSoundEffects()

        ' Visual feedback
        lblQueueHeader.ForeColor = If(SoundEffectsEnabled,
                                      Color.FromArgb(255, 199, 44),
                                      Color.FromArgb(150, 150, 150))
    End Sub

    Private Sub frmQueueDisplay_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Stop timer
            RefreshTimer.Stop()

            ' Dispose sound players
            If notificationPlayer IsNot Nothing Then
                notificationPlayer.Dispose()
                notificationPlayer = Nothing
            End If

            If callQueuePlayer IsNot Nothing Then
                callQueuePlayer.Dispose()
                callQueuePlayer = Nothing
            End If

        Catch ex As Exception
            Debug.WriteLine($"Error during form closing: {ex.Message}")
        End Try
    End Sub

    ' Optional: Add double-click to toggle fullscreen
    Private Sub frmQueueDisplay_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
End Class