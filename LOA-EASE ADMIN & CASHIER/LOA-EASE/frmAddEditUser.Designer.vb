<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddEditUser
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

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlMain As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents pnlFullNameUnderline As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents pnlUsernameUnderline As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents pnlPasswordUnderline As Panel
    Friend WithEvents lblPasswordHint As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents pnlRoleUnderline As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim _bgColor As Color = Color.FromArgb(248, 249, 250)
        Dim _panelColor As Color = Color.White
        Dim _textColor As Color = Color.FromArgb(33, 37, 41)
        Dim _textSecondary As Color = Color.FromArgb(108, 117, 125)
        Dim _successColor As Color = Color.FromArgb(40, 167, 69)
        Dim _lightGray As Color = Color.FromArgb(233, 236, 239)
        Dim _cancelColor As Color = Color.FromArgb(108, 117, 125)

        Dim titleFont As New Font("Segoe UI", 14.0F, FontStyle.Bold)
        Dim labelFont As New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Dim inputFont As New Font("Segoe UI", 10.5F, FontStyle.Regular)
        Dim buttonFont As New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        Dim hintFont As New Font("Segoe UI", 8.5F, FontStyle.Italic)

        Dim inputSize As New Size(480, 36)
        Dim yPos As Integer = 25
        Dim spacing As Integer = 70

        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.pnlFullNameUnderline = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.pnlUsernameUnderline = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.pnlPasswordUnderline = New System.Windows.Forms.Panel()
        Me.lblPasswordHint = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.pnlRoleUnderline = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()

        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()

        Me.pnlHeader.BackColor = _panelColor
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 70
        Me.pnlHeader.Location = New Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New Padding(30, 0, 10, 0)

        Me.lblTitle.Text = "Add/Edit User"
        Me.lblTitle.Font = titleFont
        Me.lblTitle.ForeColor = _textColor
        Me.lblTitle.Location = New Point(30, 24)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Name = "lblTitle"

        Me.btnClose.Text = "✕"
        Me.btnClose.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular)
        Me.btnClose.Size = New Size(45, 45)
        Me.btnClose.Location = New Point(515, 12)
        Me.btnClose.BackColor = Color.Transparent
        Me.btnClose.ForeColor = _textSecondary
        Me.btnClose.FlatStyle = FlatStyle.Flat
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = _lightGray
        Me.btnClose.Cursor = Cursors.Hand
        Me.btnClose.Name = "btnClose"

        Me.pnlMain.BackColor = _bgColor
        Me.pnlMain.Dock = DockStyle.Fill
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New Padding(0, 10, 0, 10)

        Me.Label1.Text = "Full Name *"
        Me.Label1.Font = labelFont
        Me.Label1.ForeColor = _textSecondary
        Me.Label1.Location = New Point(40, yPos)
        Me.Label1.AutoSize = True
        Me.Label1.Name = "Label1"
        Me.pnlMain.Controls.Add(Me.Label1)

        Me.txtFullName.Location = New Point(40, yPos + 24)
        Me.txtFullName.Size = inputSize
        Me.txtFullName.Font = inputFont
        Me.txtFullName.BorderStyle = BorderStyle.None
        Me.txtFullName.BackColor = _panelColor
        Me.txtFullName.ForeColor = _textColor
        Me.txtFullName.PlaceholderText = "Enter full name"
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Tag = Me.pnlFullNameUnderline
        Me.pnlMain.Controls.Add(Me.txtFullName)

        Me.pnlFullNameUnderline.Location = New Point(Me.txtFullName.Left, Me.txtFullName.Bottom + 4)
        Me.pnlFullNameUnderline.Size = New Size(Me.txtFullName.Width, 2)
        Me.pnlFullNameUnderline.BackColor = _lightGray
        Me.pnlFullNameUnderline.Name = "pnlFullNameUnderline"
        Me.pnlMain.Controls.Add(Me.pnlFullNameUnderline)

        yPos += spacing

        Me.Label2.Text = "Username *"
        Me.Label2.Font = labelFont
        Me.Label2.ForeColor = _textSecondary
        Me.Label2.Location = New Point(40, yPos)
        Me.Label2.AutoSize = True
        Me.Label2.Name = "Label2"
        Me.pnlMain.Controls.Add(Me.Label2)

        Me.txtUsername.Location = New Point(40, yPos + 24)
        Me.txtUsername.Size = inputSize
        Me.txtUsername.Font = inputFont
        Me.txtUsername.BorderStyle = BorderStyle.None
        Me.txtUsername.BackColor = _panelColor
        Me.txtUsername.ForeColor = _textColor
        Me.txtUsername.PlaceholderText = "Enter username"
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Tag = Me.pnlUsernameUnderline
        Me.pnlMain.Controls.Add(Me.txtUsername)

        Me.pnlUsernameUnderline.Location = New Point(Me.txtUsername.Left, Me.txtUsername.Bottom + 4)
        Me.pnlUsernameUnderline.Size = New Size(Me.txtUsername.Width, 2)
        Me.pnlUsernameUnderline.BackColor = _lightGray
        Me.pnlUsernameUnderline.Name = "pnlUsernameUnderline"
        Me.pnlMain.Controls.Add(Me.pnlUsernameUnderline)

        yPos += spacing

        Me.Label3.Text = "Password"
        Me.Label3.Font = labelFont
        Me.Label3.ForeColor = _textSecondary
        Me.Label3.Location = New Point(40, yPos)
        Me.Label3.AutoSize = True
        Me.Label3.Name = "Label3"
        Me.pnlMain.Controls.Add(Me.Label3)

        Me.txtPassword.Location = New Point(40, yPos + 24)
        Me.txtPassword.Size = inputSize
        Me.txtPassword.Font = inputFont
        Me.txtPassword.BorderStyle = BorderStyle.None
        Me.txtPassword.BackColor = _panelColor
        Me.txtPassword.ForeColor = _textColor
        Me.txtPassword.PasswordChar = "●"c
        Me.txtPassword.PlaceholderText = "Enter password"
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Tag = Me.pnlPasswordUnderline
        Me.pnlMain.Controls.Add(Me.txtPassword)

        Me.pnlPasswordUnderline.Location = New Point(Me.txtPassword.Left, Me.txtPassword.Bottom + 4)
        Me.pnlPasswordUnderline.Size = New Size(Me.txtPassword.Width, 2)
        Me.pnlPasswordUnderline.BackColor = _lightGray
        Me.pnlPasswordUnderline.Name = "pnlPasswordUnderline"
        Me.pnlMain.Controls.Add(Me.pnlPasswordUnderline)

        Me.lblPasswordHint.Text = "Leave blank to keep current password"
        Me.lblPasswordHint.Font = hintFont
        Me.lblPasswordHint.ForeColor = _textSecondary
        Me.lblPasswordHint.Location = New Point(40, Me.pnlPasswordUnderline.Bottom + 5)
        Me.lblPasswordHint.AutoSize = True
        Me.lblPasswordHint.Name = "lblPasswordHint"
        Me.pnlMain.Controls.Add(Me.lblPasswordHint)

        Me.Label4.Text = "Role *"
        Me.Label4.Font = labelFont
        Me.Label4.ForeColor = _textSecondary
        Me.Label4.Location = New Point(40, yPos + spacing)
        Me.Label4.AutoSize = True
        Me.Label4.Name = "Label4"
        Me.Label4.Visible = False
        Me.pnlMain.Controls.Add(Me.Label4)

        Me.cboRole.Location = New Point(40, yPos + spacing + 24)
        Me.cboRole.Size = inputSize
        Me.cboRole.Font = inputFont
        Me.cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboRole.FlatStyle = FlatStyle.Flat
        Me.cboRole.BackColor = _panelColor
        Me.cboRole.ForeColor = _textColor
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Tag = Me.pnlRoleUnderline
        Me.cboRole.Items.AddRange(New Object() {"Admin", "Cashier"})
        Me.cboRole.Visible = False
        Me.pnlMain.Controls.Add(Me.cboRole)

        Me.pnlRoleUnderline.Location = New Point(Me.cboRole.Left, Me.cboRole.Bottom + 4)
        Me.pnlRoleUnderline.Size = New Size(Me.cboRole.Width, 2)
        Me.pnlRoleUnderline.BackColor = _lightGray
        Me.pnlRoleUnderline.Name = "pnlRoleUnderline"
        Me.pnlRoleUnderline.Visible = False
        Me.pnlMain.Controls.Add(Me.pnlRoleUnderline)

        Me.pnlFooter.BackColor = _panelColor
        Me.pnlFooter.Dock = DockStyle.Bottom
        Me.pnlFooter.Height = 75
        Me.pnlFooter.Location = New Point(0, 385)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Padding = New Padding(30, 15, 30, 15)

        Me.btnSave.Text = "💾 Save"
        Me.btnSave.Location = New Point(330, 18)
        Me.btnSave.Size = New Size(110, 38)
        Me.btnSave.Font = buttonFont
        Me.btnSave.BackColor = _successColor
        Me.btnSave.ForeColor = Color.White
        Me.btnSave.FlatStyle = FlatStyle.Flat
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.Cursor = Cursors.Hand
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 4
        Me.pnlFooter.Controls.Add(Me.btnSave)

        Me.btnCancel.Text = "❌ Cancel"
        Me.btnCancel.Location = New Point(450, 18)
        Me.btnCancel.Size = New Size(90, 38)
        Me.btnCancel.Font = buttonFont
        Me.btnCancel.BackColor = _cancelColor
        Me.btnCancel.ForeColor = Color.White
        Me.btnCancel.FlatStyle = FlatStyle.Flat
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.Cursor = Cursors.Hand
        Me.btnCancel.DialogResult = DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 5
        Me.pnlFooter.Controls.Add(Me.btnCancel)

        Me.Text = "Add/Edit User"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(570, 460)
        Me.BackColor = _bgColor
        Me.Padding = New Padding(0)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmAddEditUser"
        Me.AcceptButton = Me.btnSave
        Me.CancelButton = Me.btnCancel

        AddHandler Me.btnClose.Click, AddressOf btnCancel_Click
        AddHandler Me.txtFullName.TextChanged, AddressOf txtFullName_TextChanged
        AddHandler Me.txtFullName.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtFullName.Leave, AddressOf Input_FocusLeave
        AddHandler Me.txtUsername.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtUsername.Leave, AddressOf Input_FocusLeave
        AddHandler Me.txtPassword.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtPassword.Leave, AddressOf Input_FocusLeave
        AddHandler Me.cboRole.Enter, AddressOf Input_FocusEnter
        AddHandler Me.cboRole.Leave, AddressOf Input_FocusLeave

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Private Sub Input_FocusEnter(sender As Object, e As EventArgs)
        Dim primaryColor As Color = Color.FromArgb(0, 123, 255)
        If TypeOf sender Is TextBox Then
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Tag IsNot Nothing AndAlso TypeOf txt.Tag Is Panel Then
                CType(txt.Tag, Panel).BackColor = primaryColor
            End If
        ElseIf TypeOf sender Is ComboBox Then
            Dim cbo As ComboBox = CType(sender, ComboBox)
            If cbo.Tag IsNot Nothing AndAlso TypeOf cbo.Tag Is Panel Then
                CType(cbo.Tag, Panel).BackColor = primaryColor
            End If
        End If
    End Sub

    Private Sub Input_FocusLeave(sender As Object, e As EventArgs)
        Dim lightGray As Color = Color.FromArgb(233, 236, 239)
        If TypeOf sender Is TextBox Then
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Tag IsNot Nothing AndAlso TypeOf txt.Tag Is Panel Then
                CType(txt.Tag, Panel).BackColor = lightGray
            End If
        ElseIf TypeOf sender Is ComboBox Then
            Dim cbo As ComboBox = CType(sender, ComboBox)
            If cbo.Tag IsNot Nothing AndAlso TypeOf cbo.Tag Is Panel Then
                CType(cbo.Tag, Panel).BackColor = lightGray
            End If
        End If
    End Sub

    Private Sub txtFullName_TextChanged(sender As Object, e As EventArgs)
        If Not _isEditMode AndAlso Not String.IsNullOrWhiteSpace(txtFullName.Text) Then
            txtUsername.Text = GenerateUsername(txtFullName.Text)
        End If
    End Sub

    Private Function GenerateUsername(fullName As String) As String
        Dim cleanName As String = System.Text.RegularExpressions.Regex.Replace(fullName.Trim(), "\s+", " ")
        Dim parts As String() = cleanName.Split(" "c)

        If parts.Length >= 2 Then
            Return String.Join(".", parts).ToLower()
        Else
            Return cleanName.ToLower()
        End If
    End Function

End Class