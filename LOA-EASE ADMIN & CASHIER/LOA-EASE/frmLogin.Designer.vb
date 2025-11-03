<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        pnlBranding = New Panel()
        pnlFloatingCard = New Panel()
        lblCardText = New Label()
        lblCardIcon = New Label()
        pnlGradientOverlay = New Panel()
        lblBrandSubtitle = New Label()
        lblBrandTitle = New Label()
        pnlLogin = New Panel()
        pnlLoginContainer = New Panel()
        pnlAttempts = New Panel()
        lblAttemptsInfo = New Label()
        chkShowPassword = New CheckBox()
        btnLogin = New Button()
        pnlPasswordContainer = New Panel()
        lblPasswordIcon = New Label()
        txtPassword = New TextBox()
        pnlUsernameContainer = New Panel()
        lblUserIcon = New Label()
        txtUsername = New TextBox()
        lblSubtitle = New Label()
        lblLogin = New Label()
        pnlStatusBar = New Panel()
        lblVersion = New Label()
        FadeTimer = New Timer(components)
        pnlBranding.SuspendLayout()
        pnlFloatingCard.SuspendLayout()
        pnlGradientOverlay.SuspendLayout()
        pnlLogin.SuspendLayout()
        pnlLoginContainer.SuspendLayout()
        pnlAttempts.SuspendLayout()
        pnlPasswordContainer.SuspendLayout()
        pnlUsernameContainer.SuspendLayout()
        pnlStatusBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBranding
        ' 
        pnlBranding.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        pnlBranding.Controls.Add(pnlFloatingCard)
        pnlBranding.Controls.Add(pnlGradientOverlay)
        pnlBranding.Dock = DockStyle.Left
        pnlBranding.Location = New Point(0, 0)
        pnlBranding.Name = "pnlBranding"
        pnlBranding.Size = New Size(450, 680)
        pnlBranding.TabIndex = 0
        ' 
        ' pnlFloatingCard
        ' 
        pnlFloatingCard.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlFloatingCard.BackColor = Color.FromArgb(CByte(200), CByte(255), CByte(255), CByte(255))
        pnlFloatingCard.Controls.Add(lblCardText)
        pnlFloatingCard.Controls.Add(lblCardIcon)
        pnlFloatingCard.Location = New Point(60, 450)
        pnlFloatingCard.Name = "pnlFloatingCard"
        pnlFloatingCard.Size = New Size(330, 120)
        pnlFloatingCard.TabIndex = 1
        ' 
        ' lblCardText
        ' 
        lblCardText.BackColor = Color.Transparent
        lblCardText.Font = New Font("Poppins", 9.75F)
        lblCardText.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblCardText.Location = New Point(20, 60)
        lblCardText.Name = "lblCardText"
        lblCardText.Size = New Size(290, 50)
        lblCardText.TabIndex = 1
        lblCardText.Text = "Access the student and staff queueing portal for faster service."
        ' 
        ' lblCardIcon
        ' 
        lblCardIcon.AutoSize = True
        lblCardIcon.BackColor = Color.Transparent
        lblCardIcon.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblCardIcon.ForeColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        lblCardIcon.Location = New Point(15, 15)
        lblCardIcon.Name = "lblCardIcon"
        lblCardIcon.Size = New Size(65, 45)
        lblCardIcon.TabIndex = 0
        lblCardIcon.Text = "👥"
        ' 
        ' pnlGradientOverlay
        ' 
        pnlGradientOverlay.BackColor = Color.Transparent
        pnlGradientOverlay.Controls.Add(lblBrandSubtitle)
        pnlGradientOverlay.Controls.Add(lblBrandTitle)
        pnlGradientOverlay.Location = New Point(0, 0)
        pnlGradientOverlay.Name = "pnlGradientOverlay"
        pnlGradientOverlay.Size = New Size(450, 400)
        pnlGradientOverlay.TabIndex = 0
        ' 
        ' lblBrandSubtitle
        ' 
        lblBrandSubtitle.Font = New Font("Poppins", 12.75F)
        lblBrandSubtitle.ForeColor = Color.FromArgb(CByte(200), CByte(220), CByte(240))
        lblBrandSubtitle.Location = New Point(40, 290)
        lblBrandSubtitle.Name = "lblBrandSubtitle"
        lblBrandSubtitle.Size = New Size(370, 80)
        lblBrandSubtitle.TabIndex = 1
        lblBrandSubtitle.Text = "Queueing System for Lyceum of Alabang"
        lblBrandSubtitle.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblBrandTitle
        ' 
        lblBrandTitle.AutoSize = True
        lblBrandTitle.Font = New Font("Poppins", 48F, FontStyle.Bold)
        lblBrandTitle.ForeColor = Color.White
        lblBrandTitle.Location = New Point(60, 180)
        lblBrandTitle.Name = "lblBrandTitle"
        lblBrandTitle.Size = New Size(346, 113)
        lblBrandTitle.TabIndex = 0
        lblBrandTitle.Text = "LOA EASE"
        ' 
        ' pnlLogin
        ' 
        pnlLogin.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlLogin.Controls.Add(pnlLoginContainer)
        pnlLogin.Dock = DockStyle.Fill
        pnlLogin.Location = New Point(450, 0)
        pnlLogin.Name = "pnlLogin"
        pnlLogin.Size = New Size(500, 680)
        pnlLogin.TabIndex = 1
        ' 
        ' pnlLoginContainer
        ' 
        pnlLoginContainer.Anchor = AnchorStyles.None
        pnlLoginContainer.BackColor = Color.White
        pnlLoginContainer.Controls.Add(pnlAttempts)
        pnlLoginContainer.Controls.Add(chkShowPassword)
        pnlLoginContainer.Controls.Add(btnLogin)
        pnlLoginContainer.Controls.Add(pnlPasswordContainer)
        pnlLoginContainer.Controls.Add(pnlUsernameContainer)
        pnlLoginContainer.Controls.Add(lblSubtitle)
        pnlLoginContainer.Controls.Add(lblLogin)
        pnlLoginContainer.Location = New Point(71, 115)
        pnlLoginContainer.Name = "pnlLoginContainer"
        pnlLoginContainer.Size = New Size(360, 500)
        pnlLoginContainer.TabIndex = 0
        ' 
        ' pnlAttempts
        ' 
        pnlAttempts.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        pnlAttempts.Controls.Add(lblAttemptsInfo)
        pnlAttempts.Location = New Point(30, 340)
        pnlAttempts.Name = "pnlAttempts"
        pnlAttempts.Size = New Size(300, 45)
        pnlAttempts.TabIndex = 7
        pnlAttempts.Visible = False
        ' 
        ' lblAttemptsInfo
        ' 
        lblAttemptsInfo.Dock = DockStyle.Fill
        lblAttemptsInfo.Font = New Font("Poppins", 8.25F)
        lblAttemptsInfo.ForeColor = Color.FromArgb(CByte(133), CByte(100), CByte(4))
        lblAttemptsInfo.Location = New Point(0, 0)
        lblAttemptsInfo.Name = "lblAttemptsInfo"
        lblAttemptsInfo.Size = New Size(300, 45)
        lblAttemptsInfo.TabIndex = 0
        lblAttemptsInfo.Text = "⚠ 2 attempts remaining"
        lblAttemptsInfo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Poppins", 8.25F)
        chkShowPassword.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        chkShowPassword.Location = New Point(30, 270)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(112, 23)
        chkShowPassword.TabIndex = 5
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(30, 405)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(300, 55)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Sign In"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' pnlPasswordContainer
        ' 
        pnlPasswordContainer.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlPasswordContainer.Controls.Add(lblPasswordIcon)
        pnlPasswordContainer.Controls.Add(txtPassword)
        pnlPasswordContainer.Location = New Point(30, 205)
        pnlPasswordContainer.Name = "pnlPasswordContainer"
        pnlPasswordContainer.Size = New Size(300, 50)
        pnlPasswordContainer.TabIndex = 3
        ' 
        ' lblPasswordIcon
        ' 
        lblPasswordIcon.AutoSize = True
        lblPasswordIcon.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblPasswordIcon.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblPasswordIcon.Location = New Point(12, 12)
        lblPasswordIcon.Name = "lblPasswordIcon"
        lblPasswordIcon.Size = New Size(34, 25)
        lblPasswordIcon.TabIndex = 2
        lblPasswordIcon.Text = "🔒"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Poppins", 11.25F)
        txtPassword.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        txtPassword.Location = New Point(50, 13)
        txtPassword.Name = "txtPassword"
        txtPassword.PlaceholderText = "Password"
        txtPassword.Size = New Size(235, 23)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' pnlUsernameContainer
        ' 
        pnlUsernameContainer.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        pnlUsernameContainer.Controls.Add(lblUserIcon)
        pnlUsernameContainer.Controls.Add(txtUsername)
        pnlUsernameContainer.Location = New Point(30, 140)
        pnlUsernameContainer.Name = "pnlUsernameContainer"
        pnlUsernameContainer.Size = New Size(300, 50)
        pnlUsernameContainer.TabIndex = 2
        ' 
        ' lblUserIcon
        ' 
        lblUserIcon.AutoSize = True
        lblUserIcon.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblUserIcon.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblUserIcon.Location = New Point(12, 12)
        lblUserIcon.Name = "lblUserIcon"
        lblUserIcon.Size = New Size(34, 25)
        lblUserIcon.TabIndex = 2
        lblUserIcon.Text = "👤"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(245), CByte(247), CByte(250))
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Poppins", 11.25F)
        txtUsername.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        txtUsername.Location = New Point(50, 13)
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Username"
        txtUsername.Size = New Size(235, 23)
        txtUsername.TabIndex = 1
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Poppins", 9F)
        lblSubtitle.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblSubtitle.Location = New Point(30, 95)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(208, 22)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Sign in to access your dashboard"
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Font = New Font("Poppins", 26F, FontStyle.Bold)
        lblLogin.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblLogin.Location = New Point(20, 35)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(295, 62)
        lblLogin.TabIndex = 0
        lblLogin.Text = "Welcome Back"
        ' 
        ' pnlStatusBar
        ' 
        pnlStatusBar.BackColor = Color.FromArgb(CByte(13), CByte(71), CByte(161))
        pnlStatusBar.Controls.Add(lblVersion)
        pnlStatusBar.Dock = DockStyle.Bottom
        pnlStatusBar.Location = New Point(450, 650)
        pnlStatusBar.Name = "pnlStatusBar"
        pnlStatusBar.Size = New Size(500, 30)
        pnlStatusBar.TabIndex = 2
        ' 
        ' lblVersion
        ' 
        lblVersion.Dock = DockStyle.Fill
        lblVersion.Font = New Font("Poppins", 8F)
        lblVersion.ForeColor = Color.White
        lblVersion.Location = New Point(0, 0)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(500, 30)
        lblVersion.TabIndex = 0
        lblVersion.Text = "LOA EASE v1.0 | © 2025 Queueing Management System"
        lblVersion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' FadeTimer
        ' 
        FadeTimer.Interval = 50
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(950, 680)
        Controls.Add(pnlStatusBar)
        Controls.Add(pnlLogin)
        Controls.Add(pnlBranding)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Secure Login"
        pnlBranding.ResumeLayout(False)
        pnlFloatingCard.ResumeLayout(False)
        pnlFloatingCard.PerformLayout()
        pnlGradientOverlay.ResumeLayout(False)
        pnlGradientOverlay.PerformLayout()
        pnlLogin.ResumeLayout(False)
        pnlLoginContainer.ResumeLayout(False)
        pnlLoginContainer.PerformLayout()
        pnlAttempts.ResumeLayout(False)
        pnlPasswordContainer.ResumeLayout(False)
        pnlPasswordContainer.PerformLayout()
        pnlUsernameContainer.ResumeLayout(False)
        pnlUsernameContainer.PerformLayout()
        pnlStatusBar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBranding As Panel
    Friend WithEvents pnlGradientOverlay As Panel
    Friend WithEvents lblBrandTitle As Label
    Friend WithEvents lblBrandSubtitle As Label
    Friend WithEvents pnlFloatingCard As Panel
    Friend WithEvents lblCardIcon As Label
    Friend WithEvents lblCardText As Label
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents pnlLoginContainer As Panel
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlUsernameContainer As Panel
    Friend WithEvents lblUserIcon As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents pnlPasswordContainer As Panel
    Friend WithEvents lblPasswordIcon As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents pnlAttempts As Panel
    Friend WithEvents lblAttemptsInfo As Label
    Friend WithEvents pnlStatusBar As Panel
    Friend WithEvents lblVersion As Label
    Friend WithEvents FadeTimer As Timer

End Class