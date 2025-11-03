<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddStudent
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
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents pnlLastNameUnderline As Panel
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents pnlFirstNameUnderline As Panel
    Friend WithEvents lblStudentNo As Label
    Friend WithEvents txtStudentNo As TextBox
    Friend WithEvents pnlStudentNoUnderline As Panel
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents pnlEmailUnderline As Panel
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents pnlDepartmentUnderline As Panel
    Friend WithEvents lblCourse As Label
    Friend WithEvents cboCourse As ComboBox
    Friend WithEvents pnlCourseUnderline As Panel
    Friend WithEvents lblYearLevel As Label
    Friend WithEvents cboYearLevel As ComboBox
    Friend WithEvents pnlYearLevelUnderline As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblRequired As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ' Modern Color Palette
        Dim _bgColor As Color = Color.FromArgb(248, 249, 250)
        Dim _panelColor As Color = Color.White
        Dim _primaryColor As Color = Color.FromArgb(0, 123, 255)
        Dim _textColor As Color = Color.FromArgb(33, 37, 41)
        Dim _textSecondary As Color = Color.FromArgb(108, 117, 125)
        Dim _successColor As Color = Color.FromArgb(40, 167, 69)
        Dim _dangerColor As Color = Color.FromArgb(220, 53, 69)
        Dim _lightGray As Color = Color.FromArgb(233, 236, 239)
        Dim _cancelColor As Color = Color.FromArgb(108, 117, 125)

        ' Modern Typography - Enhanced Title Font
        Dim titleFont As New Font("Segoe UI", 14.0F, FontStyle.Bold)
        Dim labelFont As New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Dim inputFont As New Font("Segoe UI", 10.5F, FontStyle.Regular)
        Dim buttonFont As New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)

        Dim inputSize As New Size(480, 36)
        Dim yPos As Integer = 25
        Dim spacing As Integer = 70

        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.pnlLastNameUnderline = New System.Windows.Forms.Panel()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.pnlFirstNameUnderline = New System.Windows.Forms.Panel()
        Me.lblStudentNo = New System.Windows.Forms.Label()
        Me.txtStudentNo = New System.Windows.Forms.TextBox()
        Me.pnlStudentNoUnderline = New System.Windows.Forms.Panel()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.pnlEmailUnderline = New System.Windows.Forms.Panel()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.pnlDepartmentUnderline = New System.Windows.Forms.Panel()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.cboCourse = New System.Windows.Forms.ComboBox()
        Me.pnlCourseUnderline = New System.Windows.Forms.Panel()
        Me.lblYearLevel = New System.Windows.Forms.Label()
        Me.cboYearLevel = New System.Windows.Forms.ComboBox()
        Me.pnlYearLevelUnderline = New System.Windows.Forms.Panel()
        Me.lblRequired = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()

        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()

        ' 
        ' pnlHeader - Modern Header with Shadow Effect
        ' 
        Me.pnlHeader.BackColor = _panelColor
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 70
        Me.pnlHeader.Location = New Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New Padding(30, 0, 10, 0)

        ' 
        ' lblTitle - Bold Modern Title
        ' 
        Me.lblTitle.Text = "ADD NEW STUDENT"
        Me.lblTitle.Font = titleFont
        Me.lblTitle.ForeColor = _textColor
        Me.lblTitle.Location = New Point(30, 24)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Name = "lblTitle"

        ' 
        ' btnClose - Modern Close Button
        ' 
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

        ' 
        ' pnlFooter - Modern Footer
        ' 
        Me.pnlFooter.BackColor = _panelColor
        Me.pnlFooter.Controls.Add(Me.lblRequired)
        Me.pnlFooter.Controls.Add(Me.btnSave)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Dock = DockStyle.Bottom
        Me.pnlFooter.Height = 75
        Me.pnlFooter.Location = New Point(0, 615)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Padding = New Padding(30, 15, 30, 15)

        ' 
        ' pnlMain - Modern Scrollable Content Area
        ' 
        Me.pnlMain.BackColor = _bgColor
        Me.pnlMain.Dock = DockStyle.Fill
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New Padding(0, 10, 0, 10)

        ' 
        ' lblLastName
        ' 
        Me.lblLastName.Text = "Last Name *"
        Me.lblLastName.Font = labelFont
        Me.lblLastName.ForeColor = _textSecondary
        Me.lblLastName.Location = New Point(40, yPos)
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Name = "lblLastName"
        Me.pnlMain.Controls.Add(Me.lblLastName)

        ' 
        ' txtLastName - Modern Input
        ' 
        Me.txtLastName.Location = New Point(40, yPos + 24)
        Me.txtLastName.Size = inputSize
        Me.txtLastName.Font = inputFont
        Me.txtLastName.BorderStyle = BorderStyle.None
        Me.txtLastName.BackColor = _panelColor
        Me.txtLastName.ForeColor = _textColor
        Me.txtLastName.PlaceholderText = "Enter student's last name"
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Tag = Me.pnlLastNameUnderline
        Me.pnlMain.Controls.Add(Me.txtLastName)

        ' 
        ' pnlLastNameUnderline - Modern Underline
        ' 
        Me.pnlLastNameUnderline.Location = New Point(Me.txtLastName.Left, Me.txtLastName.Bottom + 4)
        Me.pnlLastNameUnderline.Size = New Size(Me.txtLastName.Width, 2)
        Me.pnlLastNameUnderline.BackColor = _lightGray
        Me.pnlLastNameUnderline.Name = "pnlLastNameUnderline"
        Me.pnlMain.Controls.Add(Me.pnlLastNameUnderline)

        yPos += spacing

        ' 
        ' lblFirstName
        ' 
        Me.lblFirstName.Text = "First Name *"
        Me.lblFirstName.Font = labelFont
        Me.lblFirstName.ForeColor = _textSecondary
        Me.lblFirstName.Location = New Point(40, yPos)
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Name = "lblFirstName"
        Me.pnlMain.Controls.Add(Me.lblFirstName)

        ' 
        ' txtFirstName
        ' 
        Me.txtFirstName.Location = New Point(40, yPos + 24)
        Me.txtFirstName.Size = inputSize
        Me.txtFirstName.Font = inputFont
        Me.txtFirstName.BorderStyle = BorderStyle.None
        Me.txtFirstName.BackColor = _panelColor
        Me.txtFirstName.ForeColor = _textColor
        Me.txtFirstName.PlaceholderText = "Enter student's first name"
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Tag = Me.pnlFirstNameUnderline
        Me.pnlMain.Controls.Add(Me.txtFirstName)

        ' 
        ' pnlFirstNameUnderline
        ' 
        Me.pnlFirstNameUnderline.Location = New Point(Me.txtFirstName.Left, Me.txtFirstName.Bottom + 4)
        Me.pnlFirstNameUnderline.Size = New Size(Me.txtFirstName.Width, 2)
        Me.pnlFirstNameUnderline.BackColor = _lightGray
        Me.pnlFirstNameUnderline.Name = "pnlFirstNameUnderline"
        Me.pnlMain.Controls.Add(Me.pnlFirstNameUnderline)

        yPos += spacing

        ' 
        ' lblStudentNo
        ' 
        Me.lblStudentNo.Text = "Student Number *"
        Me.lblStudentNo.Font = labelFont
        Me.lblStudentNo.ForeColor = _textSecondary
        Me.lblStudentNo.Location = New Point(40, yPos)
        Me.lblStudentNo.AutoSize = True
        Me.lblStudentNo.Name = "lblStudentNo"
        Me.pnlMain.Controls.Add(Me.lblStudentNo)

        ' 
        ' txtStudentNo
        ' 
        Me.txtStudentNo.Location = New Point(40, yPos + 24)
        Me.txtStudentNo.Size = inputSize
        Me.txtStudentNo.Font = inputFont
        Me.txtStudentNo.BorderStyle = BorderStyle.None
        Me.txtStudentNo.BackColor = _panelColor
        Me.txtStudentNo.ForeColor = _textColor
        Me.txtStudentNo.PlaceholderText = "e.g., 2024-00123"
        Me.txtStudentNo.Name = "txtStudentNo"
        Me.txtStudentNo.Tag = Me.pnlStudentNoUnderline
        Me.pnlMain.Controls.Add(Me.txtStudentNo)

        ' 
        ' pnlStudentNoUnderline
        ' 
        Me.pnlStudentNoUnderline.Location = New Point(Me.txtStudentNo.Left, Me.txtStudentNo.Bottom + 4)
        Me.pnlStudentNoUnderline.Size = New Size(Me.txtStudentNo.Width, 2)
        Me.pnlStudentNoUnderline.BackColor = _lightGray
        Me.pnlStudentNoUnderline.Name = "pnlStudentNoUnderline"
        Me.pnlMain.Controls.Add(Me.pnlStudentNoUnderline)

        yPos += spacing

        ' 
        ' lblEmail
        ' 
        Me.lblEmail.Text = "Email Address *"
        Me.lblEmail.Font = labelFont
        Me.lblEmail.ForeColor = _textSecondary
        Me.lblEmail.Location = New Point(40, yPos)
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Name = "lblEmail"
        Me.pnlMain.Controls.Add(Me.lblEmail)

        ' 
        ' txtEmail
        ' 
        Me.txtEmail.Location = New Point(40, yPos + 24)
        Me.txtEmail.Size = inputSize
        Me.txtEmail.Font = inputFont
        Me.txtEmail.BorderStyle = BorderStyle.None
        Me.txtEmail.BackColor = _panelColor
        Me.txtEmail.ForeColor = _textColor
        Me.txtEmail.PlaceholderText = "example@email.com"
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Tag = Me.pnlEmailUnderline
        Me.pnlMain.Controls.Add(Me.txtEmail)

        ' 
        ' pnlEmailUnderline
        ' 
        Me.pnlEmailUnderline.Location = New Point(Me.txtEmail.Left, Me.txtEmail.Bottom + 4)
        Me.pnlEmailUnderline.Size = New Size(Me.txtEmail.Width, 2)
        Me.pnlEmailUnderline.BackColor = _lightGray
        Me.pnlEmailUnderline.Name = "pnlEmailUnderline"
        Me.pnlMain.Controls.Add(Me.pnlEmailUnderline)

        yPos += spacing

        ' 
        ' lblDepartment
        ' 
        Me.lblDepartment.Text = "Department/College *"
        Me.lblDepartment.Font = labelFont
        Me.lblDepartment.ForeColor = _textSecondary
        Me.lblDepartment.Location = New Point(40, yPos)
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Name = "lblDepartment"
        Me.pnlMain.Controls.Add(Me.lblDepartment)

        ' 
        ' cboDepartment - Modern Dropdown
        ' 
        Me.cboDepartment.Location = New Point(40, yPos + 24)
        Me.cboDepartment.Size = inputSize
        Me.cboDepartment.Font = inputFont
        Me.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboDepartment.FlatStyle = FlatStyle.Flat
        Me.cboDepartment.BackColor = _panelColor
        Me.cboDepartment.ForeColor = _textColor
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Tag = Me.pnlDepartmentUnderline
        Me.cboDepartment.Items.Add("-- Select Department --")
        Me.cboDepartment.SelectedIndex = 0
        Me.pnlMain.Controls.Add(Me.cboDepartment)

        ' 
        ' pnlDepartmentUnderline
        ' 
        Me.pnlDepartmentUnderline.Location = New Point(Me.cboDepartment.Left, Me.cboDepartment.Bottom + 4)
        Me.pnlDepartmentUnderline.Size = New Size(Me.cboDepartment.Width, 2)
        Me.pnlDepartmentUnderline.BackColor = _lightGray
        Me.pnlDepartmentUnderline.Name = "pnlDepartmentUnderline"
        Me.pnlMain.Controls.Add(Me.pnlDepartmentUnderline)

        yPos += spacing

        ' 
        ' lblCourse
        ' 
        Me.lblCourse.Text = "Course *"
        Me.lblCourse.Font = labelFont
        Me.lblCourse.ForeColor = _textSecondary
        Me.lblCourse.Location = New Point(40, yPos)
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Name = "lblCourse"
        Me.pnlMain.Controls.Add(Me.lblCourse)

        ' 
        ' cboCourse
        ' 
        Me.cboCourse.Location = New Point(40, yPos + 24)
        Me.cboCourse.Size = inputSize
        Me.cboCourse.Font = inputFont
        Me.cboCourse.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboCourse.FlatStyle = FlatStyle.Flat
        Me.cboCourse.BackColor = _panelColor
        Me.cboCourse.ForeColor = _textColor
        Me.cboCourse.Name = "cboCourse"
        Me.cboCourse.Tag = Me.pnlCourseUnderline
        Me.cboCourse.Enabled = False
        Me.cboCourse.Items.Add("-- Select Department First --")
        Me.cboCourse.SelectedIndex = 0
        Me.pnlMain.Controls.Add(Me.cboCourse)

        ' 
        ' pnlCourseUnderline
        ' 
        Me.pnlCourseUnderline.Location = New Point(Me.cboCourse.Left, Me.cboCourse.Bottom + 4)
        Me.pnlCourseUnderline.Size = New Size(Me.cboCourse.Width, 2)
        Me.pnlCourseUnderline.BackColor = _lightGray
        Me.pnlCourseUnderline.Name = "pnlCourseUnderline"
        Me.pnlMain.Controls.Add(Me.pnlCourseUnderline)

        yPos += spacing

        ' 
        ' lblYearLevel
        ' 
        Me.lblYearLevel.Text = "Year Level *"
        Me.lblYearLevel.Font = labelFont
        Me.lblYearLevel.ForeColor = _textSecondary
        Me.lblYearLevel.Location = New Point(40, yPos)
        Me.lblYearLevel.AutoSize = True
        Me.lblYearLevel.Name = "lblYearLevel"
        Me.pnlMain.Controls.Add(Me.lblYearLevel)

        ' 
        ' cboYearLevel
        ' 
        Me.cboYearLevel.Location = New Point(40, yPos + 24)
        Me.cboYearLevel.Size = inputSize
        Me.cboYearLevel.Font = inputFont
        Me.cboYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboYearLevel.FlatStyle = FlatStyle.Flat
        Me.cboYearLevel.BackColor = _panelColor
        Me.cboYearLevel.ForeColor = _textColor
        Me.cboYearLevel.Name = "cboYearLevel"
        Me.cboYearLevel.Tag = Me.pnlYearLevelUnderline
        Me.cboYearLevel.Items.AddRange(New String() {"-- Select Year Level --", "1st Year", "2nd Year", "3rd Year", "4th Year", "Irregular"})
        Me.cboYearLevel.SelectedIndex = 0
        Me.pnlMain.Controls.Add(Me.cboYearLevel)

        ' 
        ' pnlYearLevelUnderline
        ' 
        Me.pnlYearLevelUnderline.Location = New Point(Me.cboYearLevel.Left, Me.cboYearLevel.Bottom + 4)
        Me.pnlYearLevelUnderline.Size = New Size(Me.cboYearLevel.Width, 2)
        Me.pnlYearLevelUnderline.BackColor = _lightGray
        Me.pnlYearLevelUnderline.Name = "pnlYearLevelUnderline"
        Me.pnlMain.Controls.Add(Me.pnlYearLevelUnderline)

        ' 
        ' lblRequired - Modern Helper Text
        ' 
        Me.lblRequired.Text = "* Required fields"
        Me.lblRequired.Font = New Font("Segoe UI", 8.5F, FontStyle.Italic)
        Me.lblRequired.ForeColor = _textSecondary
        Me.lblRequired.Location = New Point(30, 25)
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Name = "lblRequired"

        ' 
        ' btnSave - Modern Primary Button
        ' 
        Me.btnSave.Text = "Save Student"
        Me.btnSave.Location = New Point(305, 20)
        Me.btnSave.Size = New Size(130, 38)
        Me.btnSave.Font = buttonFont
        Me.btnSave.BackColor = _successColor
        Me.btnSave.ForeColor = Color.White
        Me.btnSave.FlatStyle = FlatStyle.Flat
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.Cursor = Cursors.Hand
        Me.btnSave.Name = "btnSave"

        ' 
        ' btnCancel - Modern Secondary Button
        ' 
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Location = New Point(445, 20)
        Me.btnCancel.Size = New Size(95, 38)
        Me.btnCancel.Font = buttonFont
        Me.btnCancel.BackColor = _cancelColor
        Me.btnCancel.ForeColor = Color.White
        Me.btnCancel.FlatStyle = FlatStyle.Flat
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.Cursor = Cursors.Hand
        Me.btnCancel.DialogResult = DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"

        ' 
        ' frmAddStudent
        ' 
        Me.Text = "Add New Student"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(570, 690)
        Me.BackColor = _bgColor
        Me.Padding = New Padding(0)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmAddStudent"

        ' 
        ' Add Handlers
        ' 
        AddHandler Me.btnClose.Click, AddressOf btnClose_Click
        AddHandler Me.txtLastName.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtLastName.Leave, AddressOf Input_FocusLeave
        AddHandler Me.txtFirstName.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtFirstName.Leave, AddressOf Input_FocusLeave
        AddHandler Me.txtStudentNo.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtStudentNo.Leave, AddressOf Input_FocusLeave
        AddHandler Me.txtEmail.Enter, AddressOf Input_FocusEnter
        AddHandler Me.txtEmail.Leave, AddressOf Input_FocusLeave
        AddHandler Me.cboDepartment.Enter, AddressOf Input_FocusEnter
        AddHandler Me.cboDepartment.Leave, AddressOf Input_FocusLeave
        AddHandler Me.cboDepartment.SelectedIndexChanged, AddressOf cboDepartment_SelectedIndexChanged
        AddHandler Me.cboCourse.Enter, AddressOf Input_FocusEnter
        AddHandler Me.cboCourse.Leave, AddressOf Input_FocusLeave
        AddHandler Me.cboYearLevel.Enter, AddressOf Input_FocusEnter
        AddHandler Me.cboYearLevel.Leave, AddressOf Input_FocusLeave
        AddHandler Me.btnSave.Click, AddressOf btnSave_Click

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
End Class