Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Const MAX_ATTEMPTS As Integer = 3
    Private Const LOCKOUT_DURATION_MINUTES As Integer = 5
    Private Const PROGRESSIVE_LOCKOUT_ENABLED As Boolean = True

    Private isAccountLocked As Boolean = False
    Private lockoutEndTime As DateTime = DateTime.MinValue
    Private currentLockedUsername As String = ""
    Private lockoutTimer As Timer

    Private cardOpacity As Integer = 200
    Private fadeDirection As Integer = -5

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pnlAttempts.Visible = False

        AddRoundedCorners(pnlLoginContainer, 15)
        AddRoundedCorners(pnlUsernameContainer, 8)
        AddRoundedCorners(pnlPasswordContainer, 8)
        AddRoundedCorners(btnLogin, 8)
        AddRoundedCorners(pnlFloatingCard, 12)
        AddRoundedCorners(pnlAttempts, 8)

        FadeTimer.Start()

        lockoutTimer = New Timer()
        lockoutTimer.Interval = 1000
        AddHandler lockoutTimer.Tick, AddressOf LockoutTimer_Tick

    End Sub

    Private Sub AddRoundedCorners(ctrl As Control, radius As Integer)
        ctrl.Region = New Region(GetRoundedRectangle(ctrl.ClientRectangle, radius))
    End Sub

    Private Function GetRoundedRectangle(bounds As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90)
        path.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90)
        path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub CheckAndDisplayLockout(username As String)
        Dim lockoutData As DataRow = DatabaseHelper.CheckActiveLockout(username)

        If lockoutData IsNot Nothing Then
            lockoutEndTime = Convert.ToDateTime(lockoutData("lockout_until"))
            isAccountLocked = True
            currentLockedUsername = username

            Dim remainingSeconds As Integer = Convert.ToInt32(lockoutData("seconds_remaining"))
            If remainingSeconds > 0 Then
                ShowLockoutPanel(remainingSeconds)
            Else
                HideLockoutPanel(username)
            End If
        Else
            HideLockoutPanel(username)
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.",
                          "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If CheckUsernameLockout(username) Then
            Return
        End If

        HideLockoutPanel(username)

        btnLogin.Enabled = False
        btnLogin.Text = "Signing In..."
        Application.DoEvents()

        Dim authenticationAttempted As Boolean = False
        Try
            Dim userRow As DataRow = DatabaseHelper.AuthenticateWithStoredProcedure(username, password)
            authenticationAttempted = True

            If userRow IsNot Nothing Then
                Dim userId As Integer = Convert.ToInt32(userRow("id"))
                Dim userType As String = userRow("role").ToString()

                DatabaseHelper.RecordLoginAttempt(username, userType, userId, True, GetLocalIPAddress(), Environment.OSVersion.ToString(), "Successful login")
                DatabaseHelper.UpdateLastLogin(username, userType, GetLocalIPAddress())

                ResetLocalLoginState()

                Dim role As String = userRow("role").ToString()
                Dim fullName As String = userRow("full_name").ToString()

                If role = "admin" Then
                    Dim adminDashboard As New frmAdminDashboard(fullName)
                    adminDashboard.Show()
                    Me.Hide()
                ElseIf role = "cashier" Then
                    HandleCashierLogin(userRow, fullName)
                End If
            Else

                Dim existingUserData As DataRow = DatabaseHelper.GetUserDetails(username)

                If existingUserData IsNot Nothing Then
                    Dim isActive As Boolean = False
                    Dim dbIsLocked As Boolean = True

                    If existingUserData.Table.Columns.Contains("is_active") AndAlso Not IsDBNull(existingUserData("is_active")) Then
                        Dim activeValue = existingUserData("is_active")
                        If TypeOf activeValue Is Boolean Then
                            isActive = CBool(activeValue)
                        ElseIf IsNumeric(activeValue) Then
                            isActive = (CInt(activeValue) <> 0)
                        ElseIf TypeOf activeValue Is String Then
                            Boolean.TryParse(activeValue.ToString(), isActive)
                        End If
                    End If

                    If existingUserData.Table.Columns.Contains("is_locked") AndAlso Not IsDBNull(existingUserData("is_locked")) Then
                        Dim lockedValue = existingUserData("is_locked")
                        If TypeOf lockedValue Is Boolean Then
                            dbIsLocked = CBool(lockedValue)
                        ElseIf IsNumeric(lockedValue) Then
                            dbIsLocked = (CInt(lockedValue) <> 0)
                        ElseIf TypeOf lockedValue Is String Then
                            Boolean.TryParse(lockedValue.ToString(), dbIsLocked)
                        End If
                    End If

                    If Not isActive Then
                        MessageBox.Show("Your account is inactive. Please contact the administrator.",
                                      "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        DatabaseHelper.RecordLoginAttempt(username, existingUserData("role").ToString(), CInt(existingUserData("id")), False, GetLocalIPAddress(), Environment.OSVersion.ToString(), "Login attempt on inactive account")
                        txtPassword.Clear()
                        txtPassword.Focus()
                    ElseIf dbIsLocked Then
                        MessageBox.Show("Your account is currently locked. Please try again later or contact support.",
                                       "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        DatabaseHelper.RecordLoginAttempt(username, existingUserData("role").ToString(), CInt(existingUserData("id")), False, GetLocalIPAddress(), Environment.OSVersion.ToString(), "Login attempt on locked account")
                        txtPassword.Clear()
                        txtPassword.Focus()
                        CheckAndDisplayLockout(username)
                    Else
                        HandleFailedLogin(username)
                    End If
                Else
                    MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DatabaseHelper.RecordLoginAttempt(username, "unknown", Nothing, False, GetLocalIPAddress(), Environment.OSVersion.ToString(), "Login attempt with non-existent username")
                    txtPassword.Clear()
                    txtPassword.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during login: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Dim finalLockCheck As DataRow = DatabaseHelper.CheckActiveLockout(username)
            If finalLockCheck Is Nothing Then
                btnLogin.Enabled = True
                btnLogin.Text = "Sign In"
            Else
                CheckAndDisplayLockout(username)
            End If
        End Try
    End Sub


    Private Function UserExists(username As String) As Boolean
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                Dim query As String = "SELECT COUNT(*) FROM admins WHERE username = @username " &
                                     "UNION ALL SELECT COUNT(*) FROM cashiers WHERE username = @username"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If Convert.ToInt32(reader(0)) > 0 Then
                                Return True
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error checking if user exists: " & ex.Message)
        End Try

        Return False
    End Function

    Private Function CheckUsernameLockout(username As String) As Boolean
        Dim lockoutData As DataRow = DatabaseHelper.CheckActiveLockout(username)

        If lockoutData IsNot Nothing Then
            lockoutEndTime = Convert.ToDateTime(lockoutData("lockout_until"))
            isAccountLocked = True
            currentLockedUsername = username

            Dim remainingSeconds As Integer = Convert.ToInt32(lockoutData("seconds_remaining"))
            If remainingSeconds > 0 Then
                ShowLockoutPanel(remainingSeconds)
                Dim minutes As Integer = Math.Ceiling(remainingSeconds / 60.0)
                MessageBox.Show($"Account '{username}' is temporarily locked due to multiple failed login attempts.{vbCrLf}{vbCrLf}" &
                              $"Please try again in {minutes} minute(s).",
                              "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return True
            Else
                HideLockoutPanel(username)
                DatabaseHelper.ClearLockout(username)
                isAccountLocked = False
                currentLockedUsername = ""
                Return False
            End If
        End If
        HideLockoutPanel(username)
        isAccountLocked = False
        currentLockedUsername = ""
        Return False
    End Function


    Private Sub HandleCashierLogin(userRow As DataRow, fullName As String)
        If userRow("counter_id") IsNot DBNull.Value Then
            Dim counterId As Integer = Convert.ToInt32(userRow("counter_id"))
            Dim cashierId As Integer = Convert.ToInt32(userRow("cashier_id"))

            Try
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    conn.Open()
                    Dim query As String = "UPDATE counter_schedules SET is_open = 1, status = 'open' WHERE counter_id = @counterId"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@counterId", counterId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Could not update cashier status: " & ex.Message,
                              "Status Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim cashierDashboard As New frmCashierDashboard(cashierId, counterId, fullName)
            cashierDashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("No counter assigned to this cashier account.",
                           "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HandleFailedLogin(username As String)
        Dim userType As String = DatabaseHelper.GetUserType(username)
        Dim userId As Integer? = DatabaseHelper.GetUserId(username, userType)

        Dim currentFailedAttempts As Integer = DatabaseHelper.GetFailedAttempts(username, userType)
        Dim newFailedAttempts As Integer = currentFailedAttempts + 1
        Dim remainingAttempts As Integer = MAX_ATTEMPTS - newFailedAttempts

        DatabaseHelper.RecordLoginAttempt(username, userType, userId, False, GetLocalIPAddress(), Environment.OSVersion.ToString(), $"Failed attempt {newFailedAttempts} of {MAX_ATTEMPTS} (Password Incorrect)")

        If newFailedAttempts >= MAX_ATTEMPTS Then
            LockAccount(username)
        Else
            DatabaseHelper.UpdateFailedAttempts(username, userType, newFailedAttempts)
            ShowAttemptsWarning(remainingAttempts)
            txtPassword.Clear()
            txtPassword.Focus()

            Dim message As String = $"Invalid username or password.{vbCrLf}{vbCrLf}" &
                                   $"You have {remainingAttempts} attempt(s) remaining."
            If remainingAttempts = 1 Then
                Dim nextLockoutDuration As Integer = LOCKOUT_DURATION_MINUTES
                If PROGRESSIVE_LOCKOUT_ENABLED Then
                    nextLockoutDuration = DatabaseHelper.GetProgressiveLockoutDuration(username, True)
                End If
                message &= $"{vbCrLf}{vbCrLf}⚠ Warning: Your account will be locked for {nextLockoutDuration} minutes after the next failed attempt."
            End If

            MessageBox.Show(message, "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LockAccount(username As String)
        Dim lockoutDuration As Integer = LOCKOUT_DURATION_MINUTES

        If PROGRESSIVE_LOCKOUT_ENABLED Then
            lockoutDuration = DatabaseHelper.GetProgressiveLockoutDuration(username)
        End If

        Dim userType As String = DatabaseHelper.GetUserType(username)
        Dim userId As Integer? = DatabaseHelper.GetUserId(username, userType)

        DatabaseHelper.UpdateFailedAttempts(username, userType, MAX_ATTEMPTS)
        DatabaseHelper.CreateLockout(username, userType, userId, MAX_ATTEMPTS, lockoutDuration, GetLocalIPAddress())
        DatabaseHelper.RecordLoginAttempt(username, userType, userId, False, GetLocalIPAddress(), Environment.OSVersion.ToString(), $"Account locked for {lockoutDuration} minutes due to {MAX_ATTEMPTS} failed attempts")

        isAccountLocked = True
        lockoutEndTime = DateTime.Now.AddMinutes(lockoutDuration)
        currentLockedUsername = username

        ShowLockoutPanel(lockoutDuration * 60)

        MessageBox.Show($"Account '{username}' has been temporarily locked for {lockoutDuration} minute(s) due to too many failed login attempts.{vbCrLf}{vbCrLf}" &
                       $"Please contact your administrator if you need immediate assistance.",
                      "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Private Sub ShowLockoutPanel(seconds As Integer)
        pnlAttempts.BackColor = Color.FromArgb(CByte(248), CByte(215), CByte(218))
        lblAttemptsInfo.ForeColor = Color.FromArgb(CByte(114), CByte(28), CByte(36))

        UpdateLockoutDisplay(seconds)
        pnlAttempts.Visible = True

        lockoutTimer.Tag = seconds
        If Not lockoutTimer.Enabled Then lockoutTimer.Start()
    End Sub

    Private Sub HideLockoutPanel(Optional specificUsername As String = "")
        If pnlAttempts.Visible Then
            lockoutTimer.Stop()
            pnlAttempts.Visible = False
        End If
        isAccountLocked = False
        currentLockedUsername = ""
    End Sub


    Private Sub UpdateLockoutDisplay(remainingSeconds As Integer)
        Dim minutes As Integer = remainingSeconds \ 60
        Dim seconds As Integer = remainingSeconds Mod 60

        If minutes > 0 Then
            lblAttemptsInfo.Text = $"🔒 Account '{currentLockedUsername}' locked. Try again in {minutes}:{seconds:D2}"
        Else
            lblAttemptsInfo.Text = $"🔒 Account '{currentLockedUsername}' locked. Try again in {seconds} second(s)"
        End If
    End Sub

    Private Sub LockoutTimer_Tick(sender As Object, e As EventArgs)
        If Not IsNumeric(lockoutTimer.Tag) Then
            lockoutTimer.Stop()
            HideLockoutPanel()
            Return
        End If

        Dim remaining As Integer = CInt(lockoutTimer.Tag) - 1
        lockoutTimer.Tag = remaining

        If remaining > 0 Then
            UpdateLockoutDisplay(remaining)
        Else
            lockoutTimer.Stop()
            Dim userThatWasLocked As String = currentLockedUsername
            HideLockoutPanel()

            If Not String.IsNullOrEmpty(userThatWasLocked) Then
                DatabaseHelper.ClearLockout(userThatWasLocked)
                MessageBox.Show($"Lockout period for '{userThatWasLocked}' has expired. You may now attempt to log in again.",
                              "Lockout Expired", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            btnLogin.Enabled = True
            btnLogin.Text = "Sign In"
        End If
    End Sub


    Private Sub ShowAttemptsWarning(remainingAttempts As Integer)
        pnlAttempts.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        lblAttemptsInfo.ForeColor = Color.FromArgb(CByte(133), CByte(100), CByte(4))

        If remainingAttempts = 1 Then
            lblAttemptsInfo.Text = "⚠ FINAL WARNING: 1 attempt remaining before lockout!"
        Else
            lblAttemptsInfo.Text = $"⚠ {remainingAttempts} attempt(s) remaining"
        End If

        pnlAttempts.Visible = True
    End Sub

    Private Sub ResetLocalLoginState()
        isAccountLocked = False
        lockoutEndTime = DateTime.MinValue
        currentLockedUsername = ""
        If lockoutTimer.Enabled Then lockoutTimer.Stop()
        pnlAttempts.Visible = False
        txtPassword.Clear()
    End Sub


    Private Function GetLocalIPAddress() As String
        Try
            Dim host As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            For Each ip As Net.IPAddress In host.AddressList
                If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
        Catch ex As Exception
            Return "Unknown"
        End Try
        Return "Unknown"
    End Function

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If btnLogin.Enabled Then
                btnLogin.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs) Handles btnLogin.MouseEnter
        If btnLogin.Enabled Then
            btnLogin.BackColor = Color.FromArgb(CByte(10), CByte(60), CByte(140))
        End If
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        FadeTimer.Stop()
        If lockoutTimer IsNot Nothing Then
            lockoutTimer.Stop()
            lockoutTimer.Dispose()
        End If
    End Sub



    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        Dim usernameToCheck As String = txtUsername.Text.Trim()
        If Not String.IsNullOrEmpty(usernameToCheck) Then
            CheckAndDisplayLockout(usernameToCheck)
        Else
            HideLockoutPanel()
        End If
    End Sub
End Class