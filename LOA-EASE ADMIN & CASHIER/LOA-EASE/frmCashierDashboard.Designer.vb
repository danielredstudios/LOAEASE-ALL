<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCashierDashboard
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblCashierName = New Label()
        btnToggleBreak = New Button()
        dtpClosingTime = New DateTimePicker()
        btnSetClosingTime = New Button()
        btnLogout = New Button()
        pnlNowServing = New Panel()
        pnlServingDetails = New Panel()
        btnRecall = New Button()
        btnComplete = New Button()
        btnNoShow = New Button()
        lblPurpose = New Label()
        lblCourse = New Label()
        lblStudentNumber = New Label()
        lblName = New Label()
        lblServingNumber = New Label()
        lblNowServingTitle = New Label()
        pnlWaitingList = New Panel()
        dgvWaitingList = New DataGridView()
        pnlWaitingListHeader = New Panel()
        btnCallNext = New Button()
        lblWaitingListTitle = New Label()
        tmrQueueRefresh = New Timer(components)
        pnlHeader.SuspendLayout()
        pnlNowServing.SuspendLayout()
        pnlServingDetails.SuspendLayout()
        pnlWaitingList.SuspendLayout()
        CType(dgvWaitingList, ComponentModel.ISupportInitialize).BeginInit()
        pnlWaitingListHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblCashierName)
        pnlHeader.Controls.Add(btnToggleBreak)
        pnlHeader.Controls.Add(dtpClosingTime)
        pnlHeader.Controls.Add(btnSetClosingTime)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1264, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' lblCashierName
        ' 
        lblCashierName.AutoSize = True
        lblCashierName.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblCashierName.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCashierName.Location = New Point(25, 23)
        lblCashierName.Name = "lblCashierName"
        lblCashierName.Size = New Size(278, 34)
        lblCashierName.TabIndex = 0
        lblCashierName.Text = "Welcome, [Cashier Name]"
        ' 
        ' btnToggleBreak
        ' 
        btnToggleBreak.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnToggleBreak.BackColor = Color.Goldenrod
        btnToggleBreak.FlatAppearance.BorderSize = 0
        btnToggleBreak.FlatStyle = FlatStyle.Flat
        btnToggleBreak.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnToggleBreak.ForeColor = Color.White
        btnToggleBreak.Location = New Point(720, 22)
        btnToggleBreak.Name = "btnToggleBreak"
        btnToggleBreak.Size = New Size(120, 36)
        btnToggleBreak.TabIndex = 1
        btnToggleBreak.Text = "Go on Break"
        btnToggleBreak.UseVisualStyleBackColor = False
        ' 
        ' dtpClosingTime
        ' 
        dtpClosingTime.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        dtpClosingTime.CustomFormat = "hh:mm tt"
        dtpClosingTime.Font = New Font("Poppins", 9.75F)
        dtpClosingTime.Format = DateTimePickerFormat.Custom
        dtpClosingTime.Location = New Point(855, 26)
        dtpClosingTime.Name = "dtpClosingTime"
        dtpClosingTime.ShowUpDown = True
        dtpClosingTime.Size = New Size(110, 27)
        dtpClosingTime.TabIndex = 2
        ' 
        ' btnSetClosingTime
        ' 
        btnSetClosingTime.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSetClosingTime.BackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        btnSetClosingTime.FlatAppearance.BorderSize = 0
        btnSetClosingTime.FlatStyle = FlatStyle.Flat
        btnSetClosingTime.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnSetClosingTime.ForeColor = Color.White
        btnSetClosingTime.Location = New Point(980, 22)
        btnSetClosingTime.Name = "btnSetClosingTime"
        btnSetClosingTime.Size = New Size(120, 36)
        btnSetClosingTime.TabIndex = 3
        btnSetClosingTime.Text = "Set Time"
        btnSetClosingTime.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1115, 22)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(120, 36)
        btnLogout.TabIndex = 4
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlNowServing
        ' 
        pnlNowServing.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        pnlNowServing.Controls.Add(pnlServingDetails)
        pnlNowServing.Controls.Add(lblServingNumber)
        pnlNowServing.Controls.Add(lblNowServingTitle)
        pnlNowServing.Location = New Point(30, 107)
        pnlNowServing.Name = "pnlNowServing"
        pnlNowServing.Size = New Size(400, 543)
        pnlNowServing.TabIndex = 1
        ' 
        ' pnlServingDetails
        ' 
        pnlServingDetails.BackColor = Color.White
        pnlServingDetails.Controls.Add(btnRecall)
        pnlServingDetails.Controls.Add(btnComplete)
        pnlServingDetails.Controls.Add(btnNoShow)
        pnlServingDetails.Controls.Add(lblPurpose)
        pnlServingDetails.Controls.Add(lblCourse)
        pnlServingDetails.Controls.Add(lblStudentNumber)
        pnlServingDetails.Controls.Add(lblName)
        pnlServingDetails.Dock = DockStyle.Bottom
        pnlServingDetails.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        pnlServingDetails.Location = New Point(0, 260)
        pnlServingDetails.Name = "pnlServingDetails"
        pnlServingDetails.Size = New Size(400, 283)
        pnlServingDetails.TabIndex = 2
        '
        ' btnRecall
        '
        btnRecall.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnRecall.FlatAppearance.BorderSize = 0
        btnRecall.FlatStyle = FlatStyle.Flat
        btnRecall.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        btnRecall.ForeColor = Color.White
        btnRecall.Location = New Point(25, 175)
        btnRecall.Name = "btnRecall"
        btnRecall.Size = New Size(350, 40)
        btnRecall.TabIndex = 6
        btnRecall.Text = "Recall"
        btnRecall.UseVisualStyleBackColor = False
        ' 
        ' btnComplete
        ' 
        btnComplete.BackColor = Color.FromArgb(CByte(25), CByte(135), CByte(84))
        btnComplete.FlatAppearance.BorderSize = 0
        btnComplete.FlatStyle = FlatStyle.Flat
        btnComplete.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        btnComplete.ForeColor = Color.White
        btnComplete.Location = New Point(25, 220)
        btnComplete.Name = "btnComplete"
        btnComplete.Size = New Size(165, 40)
        btnComplete.TabIndex = 4
        btnComplete.Text = "Complete"
        btnComplete.UseVisualStyleBackColor = False
        ' 
        ' btnNoShow
        ' 
        btnNoShow.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnNoShow.FlatAppearance.BorderSize = 0
        btnNoShow.FlatStyle = FlatStyle.Flat
        btnNoShow.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        btnNoShow.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        btnNoShow.Location = New Point(210, 220)
        btnNoShow.Name = "btnNoShow"
        btnNoShow.Size = New Size(165, 40)
        btnNoShow.TabIndex = 5
        btnNoShow.Text = "No-Show"
        btnNoShow.UseVisualStyleBackColor = False
        ' 
        ' lblPurpose
        ' 
        lblPurpose.AutoSize = True
        lblPurpose.Font = New Font("Poppins", 10.2F)
        lblPurpose.Location = New Point(25, 145)
        lblPurpose.Name = "lblPurpose"
        lblPurpose.Size = New Size(148, 25)
        lblPurpose.TabIndex = 3
        lblPurpose.Text = "Purpose of Visit: ---"
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.Font = New Font("Poppins", 10.2F)
        lblCourse.Location = New Point(25, 110)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(93, 25)
        lblCourse.TabIndex = 2
        lblCourse.Text = "Course: ---"
        ' 
        ' lblStudentNumber
        ' 
        lblStudentNumber.AutoSize = True
        lblStudentNumber.Font = New Font("Poppins", 10.2F)
        lblStudentNumber.Location = New Point(25, 75)
        lblStudentNumber.Name = "lblStudentNumber"
        lblStudentNumber.Size = New Size(157, 25)
        lblStudentNumber.TabIndex = 1
        lblStudentNumber.Text = "Student Number: ---"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        lblName.Location = New Point(25, 40)
        lblName.Name = "lblName"
        lblName.Size = New Size(88, 25)
        lblName.TabIndex = 0
        lblName.Text = "Name: ---"
        ' 
        ' lblServingNumber
        ' 
        lblServingNumber.Font = New Font("Poppins ExtraBold", 30.0F, FontStyle.Bold)
        lblServingNumber.ForeColor = Color.White
        lblServingNumber.Location = New Point(0, 100)
        lblServingNumber.Name = "lblServingNumber"
        lblServingNumber.Size = New Size(400, 100)
        lblServingNumber.TabIndex = 1
        lblServingNumber.Text = "---"
        lblServingNumber.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblNowServingTitle
        ' 
        lblNowServingTitle.Dock = DockStyle.Top
        lblNowServingTitle.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblNowServingTitle.ForeColor = Color.White
        lblNowServingTitle.Location = New Point(0, 0)
        lblNowServingTitle.Name = "lblNowServingTitle"
        lblNowServingTitle.Size = New Size(400, 60)
        lblNowServingTitle.TabIndex = 0
        lblNowServingTitle.Text = "NOW SERVING"
        lblNowServingTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlWaitingList
        ' 
        pnlWaitingList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlWaitingList.BackColor = Color.White
        pnlWaitingList.Controls.Add(dgvWaitingList)
        pnlWaitingList.Controls.Add(pnlWaitingListHeader)
        pnlWaitingList.Location = New Point(455, 107)
        pnlWaitingList.Name = "pnlWaitingList"
        pnlWaitingList.Size = New Size(785, 543)
        pnlWaitingList.TabIndex = 2
        ' 
        ' dgvWaitingList
        ' 
        dgvWaitingList.AllowUserToAddRows = False
        dgvWaitingList.AllowUserToDeleteRows = False
        dgvWaitingList.AllowUserToResizeRows = False
        dgvWaitingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvWaitingList.BackgroundColor = Color.White
        dgvWaitingList.BorderStyle = BorderStyle.None
        dgvWaitingList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvWaitingList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Poppins", 11.25F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvWaitingList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvWaitingList.ColumnHeadersHeight = 40
        dgvWaitingList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Poppins", 10.2F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvWaitingList.DefaultCellStyle = DataGridViewCellStyle2
        dgvWaitingList.Dock = DockStyle.Fill
        dgvWaitingList.EnableHeadersVisualStyles = False
        dgvWaitingList.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvWaitingList.Location = New Point(0, 60)
        dgvWaitingList.MultiSelect = False
        dgvWaitingList.Name = "dgvWaitingList"
        dgvWaitingList.ReadOnly = True
        dgvWaitingList.RowHeadersVisible = False
        DataGridViewCellStyle3.Padding = New Padding(10, 0, 0, 0)
        dgvWaitingList.RowsDefaultCellStyle = DataGridViewCellStyle3
        dgvWaitingList.RowTemplate.Height = 45
        dgvWaitingList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvWaitingList.Size = New Size(785, 483)
        dgvWaitingList.TabIndex = 1
        ' 
        ' pnlWaitingListHeader
        ' 
        pnlWaitingListHeader.Controls.Add(btnCallNext)
        pnlWaitingListHeader.Controls.Add(lblWaitingListTitle)
        pnlWaitingListHeader.Dock = DockStyle.Top
        pnlWaitingListHeader.Location = New Point(0, 0)
        pnlWaitingListHeader.Name = "pnlWaitingListHeader"
        pnlWaitingListHeader.Size = New Size(785, 60)
        pnlWaitingListHeader.TabIndex = 0
        ' 
        ' btnCallNext
        ' 
        btnCallNext.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnCallNext.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        btnCallNext.FlatAppearance.BorderSize = 0
        btnCallNext.FlatStyle = FlatStyle.Flat
        btnCallNext.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        btnCallNext.ForeColor = Color.White
        btnCallNext.Location = New Point(635, 12)
        btnCallNext.Name = "btnCallNext"
        btnCallNext.Size = New Size(130, 40)
        btnCallNext.TabIndex = 1
        btnCallNext.Text = "Call Next"
        btnCallNext.UseVisualStyleBackColor = False
        ' 
        ' lblWaitingListTitle
        ' 
        lblWaitingListTitle.AutoSize = True
        lblWaitingListTitle.Font = New Font("Poppins", 15.75F, FontStyle.Bold)
        lblWaitingListTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblWaitingListTitle.Location = New Point(20, 13)
        lblWaitingListTitle.Name = "lblWaitingListTitle"
        lblWaitingListTitle.Size = New Size(150, 37)
        lblWaitingListTitle.TabIndex = 0
        lblWaitingListTitle.Text = "Waiting List"
        ' 
        ' tmrQueueRefresh
        ' 
        tmrQueueRefresh.Interval = 5000
        ' 
        ' frmCashierDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(1264, 681)
        Controls.Add(pnlWaitingList)
        Controls.Add(pnlNowServing)
        Controls.Add(pnlHeader)
        MinimumSize = New Size(964, 460)
        Name = "frmCashierDashboard"
        Text = "Cashier Dashboard - LOA-EASE"
        WindowState = FormWindowState.Maximized
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlNowServing.ResumeLayout(False)
        pnlServingDetails.ResumeLayout(False)
        pnlServingDetails.PerformLayout()
        pnlWaitingList.ResumeLayout(False)
        CType(dgvWaitingList, ComponentModel.ISupportInitialize).EndInit()
        pnlWaitingListHeader.ResumeLayout(False)
        pnlWaitingListHeader.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblCashierName As Label
    Friend WithEvents btnToggleBreak As Button
    Friend WithEvents dtpClosingTime As DateTimePicker
    Friend WithEvents btnSetClosingTime As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlNowServing As Panel
    Friend WithEvents lblNowServingTitle As Label
    Friend WithEvents lblServingNumber As Label
    Friend WithEvents pnlServingDetails As Panel
    Friend WithEvents lblName As Label
    Friend WithEvents lblStudentNumber As Label
    Friend WithEvents lblCourse As Label
    Friend WithEvents lblPurpose As Label
    Friend WithEvents btnComplete As Button
    Friend WithEvents btnNoShow As Button
    Friend WithEvents pnlWaitingList As Panel
    Friend WithEvents dgvWaitingList As DataGridView
    Friend WithEvents pnlWaitingListHeader As Panel
    Friend WithEvents lblWaitingListTitle As Label
    Friend WithEvents btnCallNext As Button
    Friend WithEvents tmrQueueRefresh As Timer
    Friend WithEvents btnRecall As Button
End Class