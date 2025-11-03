<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddEditCounter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblCounterName = New Label()
        txtCounterName = New TextBox()
        lblCashierFullName = New Label()
        txtCashierFullName = New TextBox()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        chkShowPassword = New CheckBox()
        btnSave = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(23, 22)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(218, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Add/Edit Counter"
        ' 
        ' lblCounterName
        ' 
        lblCounterName.AutoSize = True
        lblCounterName.Font = New Font("Poppins", 9.75F)
        lblCounterName.Location = New Point(29, 80)
        lblCounterName.Name = "lblCounterName"
        lblCounterName.Size = New Size(106, 23)
        lblCounterName.TabIndex = 1
        lblCounterName.Text = "Counter Name"
        ' 
        ' txtCounterName
        ' 
        txtCounterName.Font = New Font("Poppins", 9.75F)
        txtCounterName.Location = New Point(31, 106)
        txtCounterName.Name = "txtCounterName"
        txtCounterName.Size = New Size(354, 27)
        txtCounterName.TabIndex = 2
        ' 
        ' lblCashierFullName
        ' 
        lblCashierFullName.AutoSize = True
        lblCashierFullName.Font = New Font("Poppins", 9.75F)
        lblCashierFullName.Location = New Point(29, 153)
        lblCashierFullName.Name = "lblCashierFullName"
        lblCashierFullName.Size = New Size(125, 23)
        lblCashierFullName.TabIndex = 3
        lblCashierFullName.Text = "Cashier Full Name"
        ' 
        ' txtCashierFullName
        ' 
        txtCashierFullName.Font = New Font("Poppins", 9.75F)
        txtCashierFullName.Location = New Point(31, 179)
        txtCashierFullName.Name = "txtCashierFullName"
        txtCashierFullName.Size = New Size(354, 27)
        txtCashierFullName.TabIndex = 4
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Poppins", 9.75F)
        lblUsername.Location = New Point(29, 226)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(77, 23)
        lblUsername.TabIndex = 5
        lblUsername.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Poppins", 9.75F)
        txtUsername.Location = New Point(31, 252)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(354, 27)
        txtUsername.TabIndex = 6
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Poppins", 9.75F)
        lblPassword.Location = New Point(29, 299)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(74, 23)
        lblPassword.TabIndex = 7
        lblPassword.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Poppins", 9.75F)
        txtPassword.Location = New Point(31, 325)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(354, 27)
        txtPassword.TabIndex = 8
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Poppins", 8.25F)
        chkShowPassword.Location = New Point(270, 358)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(115, 23)
        chkShowPassword.TabIndex = 9
        chkShowPassword.Text = "Show Password"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(265, 400)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 36)
        btnSave.TabIndex = 10
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(139, 400)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(120, 36)
        btnCancel.TabIndex = 11
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' frmAddEditCounter
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(417, 461)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(chkShowPassword)
        Controls.Add(txtPassword)
        Controls.Add(lblPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblUsername)
        Controls.Add(txtCashierFullName)
        Controls.Add(lblCashierFullName)
        Controls.Add(txtCounterName)
        Controls.Add(lblCounterName)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddEditCounter"
        StartPosition = FormStartPosition.CenterParent
        Text = "Add/Edit Counter"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblCounterName As Label
    Friend WithEvents txtCounterName As TextBox
    Friend WithEvents lblCashierFullName As Label
    Friend WithEvents txtCashierFullName As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class