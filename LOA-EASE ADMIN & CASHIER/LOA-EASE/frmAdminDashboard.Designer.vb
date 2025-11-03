<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdminDashboard
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblWelcome = New Label()
        lblTitle = New Label()
        btnLogout = New Button()
        pnlSidebar = New Panel()
        btnQueueLogs = New Button()
        btnReports = New Button()
        btnCounterManagement = New Button()
        btnAdminManagement = New Button()
        btnUserManagement = New Button()
        btnDashboard = New Button()
        pnlMainContent = New Panel()
        pnlAdminManagement = New Panel()
        dgvAdmins = New DataGridView()
        pnlAdminControls = New Panel()
        flpAdminControls = New FlowLayoutPanel()
        btnDeleteAdmin = New Button()
        btnEditAdmin = New Button()
        btnAddAdmin = New Button()
        txtSearchAdmins = New TextBox()
        lblSearchAdmins = New Label()
        pnlAdminHeader = New Panel()
        lblAdminsTotal = New Label()
        lblAdminManagement = New Label()
        pnlUserManagement = New Panel()
        tabUserManagement = New TabControl()
        tpWithAccount = New TabPage()
        dgvUsersWithAccount = New DataGridView()
        tpWithoutAccount = New TabPage()
        dgvUsersWithoutAccount = New DataGridView()
        pnlUserControls = New Panel()
        flpUserControls = New FlowLayoutPanel()
        btnDeleteUser = New Button()
        btnEditUser = New Button()
        btnAddUser = New Button()
        txtSearchUsers = New TextBox()
        lblSearchUsers = New Label()
        pnlUserHeader = New Panel()
        lblUsersTotal = New Label()
        lblUserManagement = New Label()
        pnlQueueLogs = New Panel()
        dgvQueueLogs = New DataGridView()
        pnlQueueLogsControls = New Panel()
        flpQueueLogControls = New FlowLayoutPanel()
        btnChangeStatus = New Button()
        txtSearchQueueLogs = New TextBox()
        lblSearchQueueLogs = New Label()
        cboSortQueueLogs = New ComboBox()
        lblSortQueueLogs = New Label()
        pnlQueueLogsHeader = New Panel()
        lblQueueLogsTotal = New Label()
        lblQueueLogs = New Label()
        pnlReports = New Panel()
        tabReports = New TabControl()
        tpQueueLogsReport = New TabPage()
        pnlQueueLogsReport = New Panel()
        dgvReports = New DataGridView()
        pnlReportControls = New Panel()
        lblReportTotal = New Label()
        btnGenerateReport = New Button()
        dtpEndDate = New DateTimePicker()
        lblEndDate = New Label()
        dtpStartDate = New DateTimePicker()
        lblStartDate = New Label()
        cboReportType = New ComboBox()
        lblReportType = New Label()
        lblReports = New Label()
        pnlCashierManagement = New Panel()
        dgvCashiers = New DataGridView()
        pnlCashierControls = New Panel()
        flpCashierControls = New FlowLayoutPanel()
        btnDeleteCashier = New Button()
        btnEditCashier = New Button()
        btnAddCashier = New Button()
        txtSearchCashiers = New TextBox()
        lblSearchCashiers = New Label()
        lblCashiersTotal = New Label()
        pnlCashierHeader = New Panel()
        lblCashierManagement = New Label()
        pnlDashboard = New Panel()
        pnlQueues = New Panel()
        dgvAllQueues = New DataGridView()
        pnlQueuesControls = New Panel()
        txtSearchAllQueues = New TextBox()
        lblSearchAllQueues = New Label()
        pnlQueuesHeader = New Panel()
        lblQueueTotal = New Label()
        lblQueueTitle = New Label()
        pnlCashiersPanel = New Panel()
        dgvCashierStatus = New DataGridView()
        pnlCashiersHeader = New Panel()
        lblActiveCashiers = New Label()
        lblCashierTitle = New Label()
        tmrRefresh = New Timer(components)
        pnlHeader.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlAdminManagement.SuspendLayout()
        CType(dgvAdmins, ComponentModel.ISupportInitialize).BeginInit()
        pnlAdminControls.SuspendLayout()
        flpAdminControls.SuspendLayout()
        pnlAdminHeader.SuspendLayout()
        pnlUserManagement.SuspendLayout()
        tabUserManagement.SuspendLayout()
        tpWithAccount.SuspendLayout()
        CType(dgvUsersWithAccount, ComponentModel.ISupportInitialize).BeginInit()
        tpWithoutAccount.SuspendLayout()
        CType(dgvUsersWithoutAccount, ComponentModel.ISupportInitialize).BeginInit()
        pnlUserControls.SuspendLayout()
        flpUserControls.SuspendLayout()
        pnlUserHeader.SuspendLayout()
        pnlQueueLogs.SuspendLayout()
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).BeginInit()
        pnlQueueLogsControls.SuspendLayout()
        flpQueueLogControls.SuspendLayout()
        pnlQueueLogsHeader.SuspendLayout()
        pnlReports.SuspendLayout()
        tabReports.SuspendLayout()
        tpQueueLogsReport.SuspendLayout()
        pnlQueueLogsReport.SuspendLayout()
        CType(dgvReports, ComponentModel.ISupportInitialize).BeginInit()
        pnlReportControls.SuspendLayout()
        pnlCashierManagement.SuspendLayout()
        CType(dgvCashiers, ComponentModel.ISupportInitialize).BeginInit()
        pnlCashierControls.SuspendLayout()
        flpCashierControls.SuspendLayout()
        pnlCashierHeader.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlQueues.SuspendLayout()
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).BeginInit()
        pnlQueuesControls.SuspendLayout()
        pnlQueuesHeader.SuspendLayout()
        pnlCashiersPanel.SuspendLayout()
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).BeginInit()
        pnlCashiersHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        pnlHeader.Controls.Add(lblWelcome)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(btnLogout)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(25, 15, 25, 15)
        pnlHeader.Size = New Size(1280, 85)
        pnlHeader.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Poppins", 9.75F)
        lblWelcome.ForeColor = Color.WhiteSmoke
        lblWelcome.Location = New Point(28, 48)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(74, 23)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome,"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Poppins SemiBold", 15.75F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(25, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(332, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "LOA EASE - Admin Dashboard"
        ' 
        ' btnLogout
        ' 
        btnLogout.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogout.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnLogout.Cursor = Cursors.Hand
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Poppins", 9.75F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1135, 23)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(120, 40)
        btnLogout.TabIndex = 2
        btnLogout.Text = "🚪 Log Out"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(45), CByte(52), CByte(54))
        pnlSidebar.Controls.Add(btnQueueLogs)
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(btnCounterManagement)
        pnlSidebar.Controls.Add(btnAdminManagement)
        pnlSidebar.Controls.Add(btnUserManagement)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 85)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Padding = New Padding(0, 10, 0, 0)
        pnlSidebar.Size = New Size(220, 615)
        pnlSidebar.TabIndex = 1
        ' 
        ' btnQueueLogs
        ' 
        btnQueueLogs.Cursor = Cursors.Hand
        btnQueueLogs.Dock = DockStyle.Top
        btnQueueLogs.FlatAppearance.BorderSize = 0
        btnQueueLogs.FlatStyle = FlatStyle.Flat
        btnQueueLogs.Font = New Font("Poppins", 10.5F)
        btnQueueLogs.ForeColor = Color.White
        btnQueueLogs.Location = New Point(0, 275)
        btnQueueLogs.Margin = New Padding(0)
        btnQueueLogs.Name = "btnQueueLogs"
        btnQueueLogs.Padding = New Padding(25, 0, 0, 0)
        btnQueueLogs.Size = New Size(220, 53)
        btnQueueLogs.TabIndex = 5
        btnQueueLogs.Text = "📋 Queue Logs"
        btnQueueLogs.TextAlign = ContentAlignment.MiddleLeft
        btnQueueLogs.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Cursor = Cursors.Hand
        btnReports.Dock = DockStyle.Top
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Poppins", 10.5F)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(0, 222)
        btnReports.Margin = New Padding(0)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(25, 0, 0, 0)
        btnReports.Size = New Size(220, 53)
        btnReports.TabIndex = 4
        btnReports.Text = "📊 Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' btnCounterManagement
        ' 
        btnCounterManagement.Cursor = Cursors.Hand
        btnCounterManagement.Dock = DockStyle.Top
        btnCounterManagement.FlatAppearance.BorderSize = 0
        btnCounterManagement.FlatStyle = FlatStyle.Flat
        btnCounterManagement.Font = New Font("Poppins", 10.5F)
        btnCounterManagement.ForeColor = Color.White
        btnCounterManagement.Location = New Point(0, 169)
        btnCounterManagement.Margin = New Padding(0)
        btnCounterManagement.Name = "btnCounterManagement"
        btnCounterManagement.Padding = New Padding(25, 0, 0, 0)
        btnCounterManagement.Size = New Size(220, 53)
        btnCounterManagement.TabIndex = 3
        btnCounterManagement.Text = "👤 Cashiers"
        btnCounterManagement.TextAlign = ContentAlignment.MiddleLeft
        btnCounterManagement.UseVisualStyleBackColor = True
        ' 
        ' btnAdminManagement
        ' 
        btnAdminManagement.Cursor = Cursors.Hand
        btnAdminManagement.Dock = DockStyle.Top
        btnAdminManagement.FlatAppearance.BorderSize = 0
        btnAdminManagement.FlatStyle = FlatStyle.Flat
        btnAdminManagement.Font = New Font("Poppins", 10.5F)
        btnAdminManagement.ForeColor = Color.White
        btnAdminManagement.Location = New Point(0, 116)
        btnAdminManagement.Margin = New Padding(0)
        btnAdminManagement.Name = "btnAdminManagement"
        btnAdminManagement.Padding = New Padding(25, 0, 0, 0)
        btnAdminManagement.Size = New Size(220, 53)
        btnAdminManagement.TabIndex = 2
        btnAdminManagement.Text = "⚙️ Admins"
        btnAdminManagement.TextAlign = ContentAlignment.MiddleLeft
        btnAdminManagement.UseVisualStyleBackColor = True
        ' 
        ' btnUserManagement
        ' 
        btnUserManagement.Cursor = Cursors.Hand
        btnUserManagement.Dock = DockStyle.Top
        btnUserManagement.FlatAppearance.BorderSize = 0
        btnUserManagement.FlatStyle = FlatStyle.Flat
        btnUserManagement.Font = New Font("Poppins", 10.5F)
        btnUserManagement.ForeColor = Color.White
        btnUserManagement.Location = New Point(0, 63)
        btnUserManagement.Margin = New Padding(0)
        btnUserManagement.Name = "btnUserManagement"
        btnUserManagement.Padding = New Padding(25, 0, 0, 0)
        btnUserManagement.Size = New Size(220, 53)
        btnUserManagement.TabIndex = 1
        btnUserManagement.Text = "👥 Students"
        btnUserManagement.TextAlign = ContentAlignment.MiddleLeft
        btnUserManagement.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        btnDashboard.Cursor = Cursors.Hand
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Poppins", 10.5F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 10)
        btnDashboard.Margin = New Padding(0)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(25, 0, 0, 0)
        btnDashboard.Size = New Size(220, 53)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "🏠 Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.Controls.Add(pnlAdminManagement)
        pnlMainContent.Controls.Add(pnlUserManagement)
        pnlMainContent.Controls.Add(pnlQueueLogs)
        pnlMainContent.Controls.Add(pnlReports)
        pnlMainContent.Controls.Add(pnlCashierManagement)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 85)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Padding = New Padding(25)
        pnlMainContent.Size = New Size(1060, 615)
        pnlMainContent.TabIndex = 2
        ' 
        ' pnlAdminManagement
        ' 
        pnlAdminManagement.Controls.Add(dgvAdmins)
        pnlAdminManagement.Controls.Add(pnlAdminControls)
        pnlAdminManagement.Controls.Add(pnlAdminHeader)
        pnlAdminManagement.Dock = DockStyle.Fill
        pnlAdminManagement.Location = New Point(25, 25)
        pnlAdminManagement.Name = "pnlAdminManagement"
        pnlAdminManagement.Size = New Size(1010, 565)
        pnlAdminManagement.TabIndex = 9
        pnlAdminManagement.Visible = False
        ' 
        ' dgvAdmins
        ' 
        dgvAdmins.AllowUserToAddRows = False
        dgvAdmins.AllowUserToDeleteRows = False
        dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAdmins.BackgroundColor = Color.White
        dgvAdmins.BorderStyle = BorderStyle.None
        dgvAdmins.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAdmins.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvAdmins.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvAdmins.ColumnHeadersHeight = 40
        dgvAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvAdmins.DefaultCellStyle = DataGridViewCellStyle2
        dgvAdmins.Dock = DockStyle.Fill
        dgvAdmins.EnableHeadersVisualStyles = False
        dgvAdmins.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvAdmins.Location = New Point(0, 120)
        dgvAdmins.MultiSelect = False
        dgvAdmins.Name = "dgvAdmins"
        dgvAdmins.ReadOnly = True
        dgvAdmins.RowHeadersVisible = False
        dgvAdmins.RowHeadersWidth = 51
        DataGridViewCellStyle3.Padding = New Padding(10, 0, 0, 0)
        dgvAdmins.RowsDefaultCellStyle = DataGridViewCellStyle3
        dgvAdmins.RowTemplate.Height = 45
        dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAdmins.Size = New Size(1010, 445)
        dgvAdmins.TabIndex = 11
        ' 
        ' pnlAdminControls
        ' 
        pnlAdminControls.Controls.Add(flpAdminControls)
        pnlAdminControls.Dock = DockStyle.Top
        pnlAdminControls.Location = New Point(0, 60)
        pnlAdminControls.Name = "pnlAdminControls"
        pnlAdminControls.Padding = New Padding(0, 5, 0, 5)
        pnlAdminControls.Size = New Size(1010, 60)
        pnlAdminControls.TabIndex = 10
        ' 
        ' flpAdminControls
        ' 
        flpAdminControls.Controls.Add(btnDeleteAdmin)
        flpAdminControls.Controls.Add(btnEditAdmin)
        flpAdminControls.Controls.Add(btnAddAdmin)
        flpAdminControls.Controls.Add(txtSearchAdmins)
        flpAdminControls.Controls.Add(lblSearchAdmins)
        flpAdminControls.Dock = DockStyle.Fill
        flpAdminControls.FlowDirection = FlowDirection.RightToLeft
        flpAdminControls.Location = New Point(0, 5)
        flpAdminControls.Name = "flpAdminControls"
        flpAdminControls.Size = New Size(1010, 50)
        flpAdminControls.TabIndex = 0
        ' 
        ' btnDeleteAdmin
        ' 
        btnDeleteAdmin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteAdmin.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteAdmin.Cursor = Cursors.Hand
        btnDeleteAdmin.FlatAppearance.BorderSize = 0
        btnDeleteAdmin.FlatStyle = FlatStyle.Flat
        btnDeleteAdmin.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnDeleteAdmin.ForeColor = Color.White
        btnDeleteAdmin.Location = New Point(877, 3)
        btnDeleteAdmin.Name = "btnDeleteAdmin"
        btnDeleteAdmin.Size = New Size(130, 36)
        btnDeleteAdmin.TabIndex = 4
        btnDeleteAdmin.Text = "🗑️ Delete"
        btnDeleteAdmin.UseVisualStyleBackColor = False
        ' 
        ' btnEditAdmin
        ' 
        btnEditAdmin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditAdmin.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditAdmin.Cursor = Cursors.Hand
        btnEditAdmin.FlatAppearance.BorderSize = 0
        btnEditAdmin.FlatStyle = FlatStyle.Flat
        btnEditAdmin.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnEditAdmin.ForeColor = Color.White
        btnEditAdmin.Location = New Point(741, 3)
        btnEditAdmin.Name = "btnEditAdmin"
        btnEditAdmin.Size = New Size(130, 36)
        btnEditAdmin.TabIndex = 3
        btnEditAdmin.Text = "✏️ Edit"
        btnEditAdmin.UseVisualStyleBackColor = False
        ' 
        ' btnAddAdmin
        ' 
        btnAddAdmin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddAdmin.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddAdmin.Cursor = Cursors.Hand
        btnAddAdmin.FlatAppearance.BorderSize = 0
        btnAddAdmin.FlatStyle = FlatStyle.Flat
        btnAddAdmin.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnAddAdmin.ForeColor = Color.White
        btnAddAdmin.Location = New Point(604, 3)
        btnAddAdmin.Name = "btnAddAdmin"
        btnAddAdmin.Size = New Size(131, 36)
        btnAddAdmin.TabIndex = 2
        btnAddAdmin.Text = "➕ Add Admin"
        btnAddAdmin.UseVisualStyleBackColor = False
        ' 
        ' txtSearchAdmins
        ' 
        txtSearchAdmins.Font = New Font("Poppins", 9.0F)
        txtSearchAdmins.Location = New Point(348, 8)
        txtSearchAdmins.Margin = New Padding(3, 8, 3, 3)
        txtSearchAdmins.Name = "txtSearchAdmins"
        txtSearchAdmins.PlaceholderText = "Search admins..."
        txtSearchAdmins.Size = New Size(250, 25)
        txtSearchAdmins.TabIndex = 6
        ' 
        ' lblSearchAdmins
        ' 
        lblSearchAdmins.AutoSize = True
        lblSearchAdmins.Font = New Font("Poppins", 9.0F)
        lblSearchAdmins.Location = New Point(281, 10)
        lblSearchAdmins.Margin = New Padding(3, 10, 10, 0)
        lblSearchAdmins.Name = "lblSearchAdmins"
        lblSearchAdmins.Size = New Size(54, 22)
        lblSearchAdmins.TabIndex = 7
        lblSearchAdmins.Text = "Search:"
        ' 
        ' pnlAdminHeader
        ' 
        pnlAdminHeader.Controls.Add(lblAdminsTotal)
        pnlAdminHeader.Controls.Add(lblAdminManagement)
        pnlAdminHeader.Dock = DockStyle.Top
        pnlAdminHeader.Location = New Point(0, 0)
        pnlAdminHeader.Name = "pnlAdminHeader"
        pnlAdminHeader.Padding = New Padding(0, 0, 0, 10)
        pnlAdminHeader.Size = New Size(1010, 60)
        pnlAdminHeader.TabIndex = 9
        ' 
        ' lblAdminsTotal
        ' 
        lblAdminsTotal.AutoSize = True
        lblAdminsTotal.Font = New Font("Poppins", 11.0F)
        lblAdminsTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblAdminsTotal.Location = New Point(280, 15)
        lblAdminsTotal.Name = "lblAdminsTotal"
        lblAdminsTotal.Size = New Size(79, 26)
        lblAdminsTotal.TabIndex = 5
        lblAdminsTotal.Text = "(Total: 0)"
        ' 
        ' lblAdminManagement
        ' 
        lblAdminManagement.AutoSize = True
        lblAdminManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblAdminManagement.Location = New Point(5, 8)
        lblAdminManagement.Name = "lblAdminManagement"
        lblAdminManagement.Size = New Size(272, 42)
        lblAdminManagement.TabIndex = 0
        lblAdminManagement.Text = "Admin Management"
        ' 
        ' pnlUserManagement
        ' 
        pnlUserManagement.Controls.Add(tabUserManagement)
        pnlUserManagement.Controls.Add(pnlUserControls)
        pnlUserManagement.Controls.Add(pnlUserHeader)
        pnlUserManagement.Dock = DockStyle.Fill
        pnlUserManagement.Location = New Point(25, 25)
        pnlUserManagement.Name = "pnlUserManagement"
        pnlUserManagement.Size = New Size(1010, 565)
        pnlUserManagement.TabIndex = 5
        pnlUserManagement.Visible = False
        ' 
        ' tabUserManagement
        ' 
        tabUserManagement.Controls.Add(tpWithAccount)
        tabUserManagement.Controls.Add(tpWithoutAccount)
        tabUserManagement.Dock = DockStyle.Fill
        tabUserManagement.Location = New Point(0, 120)
        tabUserManagement.Name = "tabUserManagement"
        tabUserManagement.SelectedIndex = 0
        tabUserManagement.Size = New Size(1010, 445)
        tabUserManagement.TabIndex = 9
        ' 
        ' tpWithAccount
        ' 
        tpWithAccount.Controls.Add(dgvUsersWithAccount)
        tpWithAccount.Location = New Point(4, 24)
        tpWithAccount.Name = "tpWithAccount"
        tpWithAccount.Padding = New Padding(3)
        tpWithAccount.Size = New Size(1002, 417)
        tpWithAccount.TabIndex = 0
        tpWithAccount.Text = "Students With Account"
        tpWithAccount.UseVisualStyleBackColor = True
        ' 
        ' dgvUsersWithAccount
        ' 
        dgvUsersWithAccount.AllowUserToAddRows = False
        dgvUsersWithAccount.AllowUserToDeleteRows = False
        dgvUsersWithAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsersWithAccount.BackgroundColor = Color.White
        dgvUsersWithAccount.BorderStyle = BorderStyle.None
        dgvUsersWithAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsersWithAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvUsersWithAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvUsersWithAccount.ColumnHeadersHeight = 40
        dgvUsersWithAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.White
        DataGridViewCellStyle5.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        dgvUsersWithAccount.DefaultCellStyle = DataGridViewCellStyle5
        dgvUsersWithAccount.Dock = DockStyle.Fill
        dgvUsersWithAccount.EnableHeadersVisualStyles = False
        dgvUsersWithAccount.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvUsersWithAccount.Location = New Point(3, 3)
        dgvUsersWithAccount.MultiSelect = False
        dgvUsersWithAccount.Name = "dgvUsersWithAccount"
        dgvUsersWithAccount.ReadOnly = True
        dgvUsersWithAccount.RowHeadersVisible = False
        dgvUsersWithAccount.RowHeadersWidth = 51
        DataGridViewCellStyle6.Padding = New Padding(10, 0, 0, 0)
        dgvUsersWithAccount.RowsDefaultCellStyle = DataGridViewCellStyle6
        dgvUsersWithAccount.RowTemplate.Height = 45
        dgvUsersWithAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithAccount.Size = New Size(996, 411)
        dgvUsersWithAccount.TabIndex = 1
        ' 
        ' tpWithoutAccount
        ' 
        tpWithoutAccount.Controls.Add(dgvUsersWithoutAccount)
        tpWithoutAccount.Location = New Point(4, 24)
        tpWithoutAccount.Name = "tpWithoutAccount"
        tpWithoutAccount.Padding = New Padding(3)
        tpWithoutAccount.Size = New Size(1002, 417)
        tpWithoutAccount.TabIndex = 1
        tpWithoutAccount.Text = "Students Without Account"
        tpWithoutAccount.UseVisualStyleBackColor = True
        ' 
        ' dgvUsersWithoutAccount
        ' 
        dgvUsersWithoutAccount.AllowUserToAddRows = False
        dgvUsersWithoutAccount.AllowUserToDeleteRows = False
        dgvUsersWithoutAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsersWithoutAccount.BackgroundColor = Color.White
        dgvUsersWithoutAccount.BorderStyle = BorderStyle.None
        dgvUsersWithoutAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvUsersWithoutAccount.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = Color.White
        DataGridViewCellStyle7.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgvUsersWithoutAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgvUsersWithoutAccount.ColumnHeadersHeight = 40
        dgvUsersWithoutAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.White
        DataGridViewCellStyle8.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle8.SelectionForeColor = Color.White
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvUsersWithoutAccount.DefaultCellStyle = DataGridViewCellStyle8
        dgvUsersWithoutAccount.Dock = DockStyle.Fill
        dgvUsersWithoutAccount.EnableHeadersVisualStyles = False
        dgvUsersWithoutAccount.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvUsersWithoutAccount.Location = New Point(3, 3)
        dgvUsersWithoutAccount.MultiSelect = False
        dgvUsersWithoutAccount.Name = "dgvUsersWithoutAccount"
        dgvUsersWithoutAccount.ReadOnly = True
        dgvUsersWithoutAccount.RowHeadersVisible = False
        dgvUsersWithoutAccount.RowHeadersWidth = 51
        DataGridViewCellStyle9.Padding = New Padding(10, 0, 0, 0)
        dgvUsersWithoutAccount.RowsDefaultCellStyle = DataGridViewCellStyle9
        dgvUsersWithoutAccount.RowTemplate.Height = 45
        dgvUsersWithoutAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithoutAccount.Size = New Size(996, 411)
        dgvUsersWithoutAccount.TabIndex = 2
        ' 
        ' pnlUserControls
        ' 
        pnlUserControls.Controls.Add(flpUserControls)
        pnlUserControls.Dock = DockStyle.Top
        pnlUserControls.Location = New Point(0, 60)
        pnlUserControls.Name = "pnlUserControls"
        pnlUserControls.Padding = New Padding(0, 5, 0, 5)
        pnlUserControls.Size = New Size(1010, 60)
        pnlUserControls.TabIndex = 8
        ' 
        ' flpUserControls
        ' 
        flpUserControls.Controls.Add(btnDeleteUser)
        flpUserControls.Controls.Add(btnEditUser)
        flpUserControls.Controls.Add(btnAddUser)
        flpUserControls.Controls.Add(txtSearchUsers)
        flpUserControls.Controls.Add(lblSearchUsers)
        flpUserControls.Dock = DockStyle.Fill
        flpUserControls.FlowDirection = FlowDirection.RightToLeft
        flpUserControls.Location = New Point(0, 5)
        flpUserControls.Margin = New Padding(3, 2, 3, 2)
        flpUserControls.Name = "flpUserControls"
        flpUserControls.Size = New Size(1010, 50)
        flpUserControls.TabIndex = 8
        ' 
        ' btnDeleteUser
        ' 
        btnDeleteUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteUser.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteUser.Cursor = Cursors.Hand
        btnDeleteUser.FlatAppearance.BorderSize = 0
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location = New Point(877, 3)
        btnDeleteUser.Name = "btnDeleteUser"
        btnDeleteUser.Size = New Size(130, 36)
        btnDeleteUser.TabIndex = 4
        btnDeleteUser.Text = "🗑️ Delete"
        btnDeleteUser.UseVisualStyleBackColor = False
        ' 
        ' btnEditUser
        ' 
        btnEditUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditUser.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditUser.Cursor = Cursors.Hand
        btnEditUser.FlatAppearance.BorderSize = 0
        btnEditUser.FlatStyle = FlatStyle.Flat
        btnEditUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnEditUser.ForeColor = Color.White
        btnEditUser.Location = New Point(741, 3)
        btnEditUser.Name = "btnEditUser"
        btnEditUser.Size = New Size(130, 36)
        btnEditUser.TabIndex = 3
        btnEditUser.Text = "✏️ Edit"
        btnEditUser.UseVisualStyleBackColor = False
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddUser.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddUser.Cursor = Cursors.Hand
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnAddUser.ForeColor = Color.White
        btnAddUser.Location = New Point(585, 3)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(150, 36)
        btnAddUser.TabIndex = 2
        btnAddUser.Text = "➕ Create Account"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' txtSearchUsers
        ' 
        txtSearchUsers.Font = New Font("Poppins", 9.0F)
        txtSearchUsers.Location = New Point(329, 8)
        txtSearchUsers.Margin = New Padding(3, 8, 3, 3)
        txtSearchUsers.Name = "txtSearchUsers"
        txtSearchUsers.PlaceholderText = "Search users..."
        txtSearchUsers.Size = New Size(250, 25)
        txtSearchUsers.TabIndex = 6
        ' 
        ' lblSearchUsers
        ' 
        lblSearchUsers.AutoSize = True
        lblSearchUsers.Font = New Font("Poppins", 9.0F)
        lblSearchUsers.Location = New Point(262, 10)
        lblSearchUsers.Margin = New Padding(3, 10, 10, 0)
        lblSearchUsers.Name = "lblSearchUsers"
        lblSearchUsers.Size = New Size(54, 22)
        lblSearchUsers.TabIndex = 7
        lblSearchUsers.Text = "Search:"
        ' 
        ' pnlUserHeader
        ' 
        pnlUserHeader.Controls.Add(lblUsersTotal)
        pnlUserHeader.Controls.Add(lblUserManagement)
        pnlUserHeader.Dock = DockStyle.Top
        pnlUserHeader.Location = New Point(0, 0)
        pnlUserHeader.Name = "pnlUserHeader"
        pnlUserHeader.Padding = New Padding(0, 0, 0, 10)
        pnlUserHeader.Size = New Size(1010, 60)
        pnlUserHeader.TabIndex = 7
        ' 
        ' lblUsersTotal
        ' 
        lblUsersTotal.AutoSize = True
        lblUsersTotal.Font = New Font("Poppins", 11.0F)
        lblUsersTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblUsersTotal.Location = New Point(310, 15)
        lblUsersTotal.Name = "lblUsersTotal"
        lblUsersTotal.Size = New Size(79, 26)
        lblUsersTotal.TabIndex = 5
        lblUsersTotal.Text = "(Total: 0)"
        ' 
        ' lblUserManagement
        ' 
        lblUserManagement.AutoSize = True
        lblUserManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblUserManagement.Location = New Point(5, 8)
        lblUserManagement.Name = "lblUserManagement"
        lblUserManagement.Size = New Size(288, 42)
        lblUserManagement.TabIndex = 0
        lblUserManagement.Text = "Student Management"
        ' 
        ' pnlQueueLogs
        ' 
        pnlQueueLogs.Controls.Add(dgvQueueLogs)
        pnlQueueLogs.Controls.Add(pnlQueueLogsControls)
        pnlQueueLogs.Controls.Add(pnlQueueLogsHeader)
        pnlQueueLogs.Dock = DockStyle.Fill
        pnlQueueLogs.Location = New Point(25, 25)
        pnlQueueLogs.Name = "pnlQueueLogs"
        pnlQueueLogs.Size = New Size(1010, 565)
        pnlQueueLogs.TabIndex = 8
        pnlQueueLogs.Visible = False
        ' 
        ' dgvQueueLogs
        ' 
        dgvQueueLogs.AllowUserToAddRows = False
        dgvQueueLogs.AllowUserToDeleteRows = False
        dgvQueueLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvQueueLogs.BackgroundColor = Color.White
        dgvQueueLogs.BorderStyle = BorderStyle.None
        dgvQueueLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueueLogs.Dock = DockStyle.Fill
        dgvQueueLogs.Location = New Point(0, 120)
        dgvQueueLogs.Name = "dgvQueueLogs"
        dgvQueueLogs.ReadOnly = True
        dgvQueueLogs.RowHeadersWidth = 51
        dgvQueueLogs.RowTemplate.Height = 35
        dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueueLogs.Size = New Size(1010, 445)
        dgvQueueLogs.TabIndex = 2
        ' 
        ' pnlQueueLogsControls
        ' 
        pnlQueueLogsControls.Controls.Add(flpQueueLogControls)
        pnlQueueLogsControls.Dock = DockStyle.Top
        pnlQueueLogsControls.Location = New Point(0, 60)
        pnlQueueLogsControls.Name = "pnlQueueLogsControls"
        pnlQueueLogsControls.Padding = New Padding(0, 5, 0, 5)
        pnlQueueLogsControls.Size = New Size(1010, 60)
        pnlQueueLogsControls.TabIndex = 11
        ' 
        ' flpQueueLogControls
        ' 
        flpQueueLogControls.Controls.Add(btnChangeStatus)
        flpQueueLogControls.Controls.Add(txtSearchQueueLogs)
        flpQueueLogControls.Controls.Add(lblSearchQueueLogs)
        flpQueueLogControls.Controls.Add(cboSortQueueLogs)
        flpQueueLogControls.Controls.Add(lblSortQueueLogs)
        flpQueueLogControls.Dock = DockStyle.Fill
        flpQueueLogControls.FlowDirection = FlowDirection.RightToLeft
        flpQueueLogControls.Location = New Point(0, 5)
        flpQueueLogControls.Margin = New Padding(3, 2, 3, 2)
        flpQueueLogControls.Name = "flpQueueLogControls"
        flpQueueLogControls.Size = New Size(1010, 50)
        flpQueueLogControls.TabIndex = 11
        ' 
        ' btnChangeStatus
        ' 
        btnChangeStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnChangeStatus.BackColor = Color.FromArgb(CByte(23), CByte(162), CByte(184))
        btnChangeStatus.Cursor = Cursors.Hand
        btnChangeStatus.FlatAppearance.BorderSize = 0
        btnChangeStatus.FlatStyle = FlatStyle.Flat
        btnChangeStatus.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnChangeStatus.ForeColor = Color.White
        btnChangeStatus.Location = New Point(847, 3)
        btnChangeStatus.Name = "btnChangeStatus"
        btnChangeStatus.Size = New Size(160, 36)
        btnChangeStatus.TabIndex = 5
        btnChangeStatus.Text = "✏️ Change Status"
        btnChangeStatus.UseVisualStyleBackColor = False
        ' 
        ' txtSearchQueueLogs
        ' 
        txtSearchQueueLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearchQueueLogs.Font = New Font("Poppins", 9.0F)
        txtSearchQueueLogs.Location = New Point(641, 8)
        txtSearchQueueLogs.Margin = New Padding(3, 8, 3, 3)
        txtSearchQueueLogs.Name = "txtSearchQueueLogs"
        txtSearchQueueLogs.PlaceholderText = "Search queues..."
        txtSearchQueueLogs.Size = New Size(200, 25)
        txtSearchQueueLogs.TabIndex = 7
        ' 
        ' lblSearchQueueLogs
        ' 
        lblSearchQueueLogs.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearchQueueLogs.AutoSize = True
        lblSearchQueueLogs.Font = New Font("Poppins", 9.0F)
        lblSearchQueueLogs.Location = New Point(553, 10)
        lblSearchQueueLogs.Margin = New Padding(3, 10, 10, 0)
        lblSearchQueueLogs.Name = "lblSearchQueueLogs"
        lblSearchQueueLogs.Size = New Size(75, 22)
        lblSearchQueueLogs.TabIndex = 8
        lblSearchQueueLogs.Text = "🔍 Search:"
        ' 
        ' cboSortQueueLogs
        ' 
        cboSortQueueLogs.DropDownStyle = ComboBoxStyle.DropDownList
        cboSortQueueLogs.Font = New Font("Poppins", 9.0F)
        cboSortQueueLogs.FormattingEnabled = True
        cboSortQueueLogs.Location = New Point(347, 8)
        cboSortQueueLogs.Margin = New Padding(3, 8, 3, 3)
        cboSortQueueLogs.Name = "cboSortQueueLogs"
        cboSortQueueLogs.Size = New Size(200, 30)
        cboSortQueueLogs.TabIndex = 10
        ' 
        ' lblSortQueueLogs
        ' 
        lblSortQueueLogs.AutoSize = True
        lblSortQueueLogs.Font = New Font("Poppins", 9.0F)
        lblSortQueueLogs.Location = New Point(280, 10)
        lblSortQueueLogs.Margin = New Padding(3, 10, 10, 0)
        lblSortQueueLogs.Name = "lblSortQueueLogs"
        lblSortQueueLogs.Size = New Size(54, 22)
        lblSortQueueLogs.TabIndex = 9
        lblSortQueueLogs.Text = "Sort by:"
        ' 
        ' pnlQueueLogsHeader
        ' 
        pnlQueueLogsHeader.Controls.Add(lblQueueLogsTotal)
        pnlQueueLogsHeader.Controls.Add(lblQueueLogs)
        pnlQueueLogsHeader.Dock = DockStyle.Top
        pnlQueueLogsHeader.Location = New Point(0, 0)
        pnlQueueLogsHeader.Name = "pnlQueueLogsHeader"
        pnlQueueLogsHeader.Padding = New Padding(0, 0, 0, 10)
        pnlQueueLogsHeader.Size = New Size(1010, 60)
        pnlQueueLogsHeader.TabIndex = 10
        ' 
        ' lblQueueLogsTotal
        ' 
        lblQueueLogsTotal.AutoSize = True
        lblQueueLogsTotal.Font = New Font("Poppins", 11.0F)
        lblQueueLogsTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblQueueLogsTotal.Location = New Point(185, 15)
        lblQueueLogsTotal.Name = "lblQueueLogsTotal"
        lblQueueLogsTotal.Size = New Size(79, 26)
        lblQueueLogsTotal.TabIndex = 6
        lblQueueLogsTotal.Text = "(Total: 0)"
        ' 
        ' lblQueueLogs
        ' 
        lblQueueLogs.AutoSize = True
        lblQueueLogs.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblQueueLogs.Location = New Point(5, 8)
        lblQueueLogs.Name = "lblQueueLogs"
        lblQueueLogs.Size = New Size(159, 42)
        lblQueueLogs.TabIndex = 1
        lblQueueLogs.Text = "Queue Logs"
        ' 
        ' pnlReports
        ' 
        pnlReports.Controls.Add(tabReports)
        pnlReports.Controls.Add(lblReports)
        pnlReports.Dock = DockStyle.Fill
        pnlReports.Location = New Point(25, 25)
        pnlReports.Name = "pnlReports"
        pnlReports.Size = New Size(1010, 565)
        pnlReports.TabIndex = 7
        pnlReports.Visible = False
        ' 
        ' tabReports
        ' 
        tabReports.Controls.Add(tpQueueLogsReport)
        tabReports.Dock = DockStyle.Fill
        tabReports.Font = New Font("Poppins", 9.0F)
        tabReports.Location = New Point(0, 50)
        tabReports.Name = "tabReports"
        tabReports.SelectedIndex = 0
        tabReports.Size = New Size(1010, 515)
        tabReports.TabIndex = 2
        ' 
        ' tpQueueLogsReport
        ' 
        tpQueueLogsReport.Controls.Add(pnlQueueLogsReport)
        tpQueueLogsReport.Location = New Point(4, 31)
        tpQueueLogsReport.Name = "tpQueueLogsReport"
        tpQueueLogsReport.Padding = New Padding(3)
        tpQueueLogsReport.Size = New Size(1002, 480)
        tpQueueLogsReport.TabIndex = 0
        tpQueueLogsReport.Text = "Queue Logs Report"
        tpQueueLogsReport.UseVisualStyleBackColor = True
        ' 
        ' pnlQueueLogsReport
        ' 
        pnlQueueLogsReport.Controls.Add(dgvReports)
        pnlQueueLogsReport.Controls.Add(pnlReportControls)
        pnlQueueLogsReport.Dock = DockStyle.Fill
        pnlQueueLogsReport.Location = New Point(3, 3)
        pnlQueueLogsReport.Name = "pnlQueueLogsReport"
        pnlQueueLogsReport.Size = New Size(996, 474)
        pnlQueueLogsReport.TabIndex = 0
        ' 
        ' dgvReports
        ' 
        dgvReports.AllowUserToAddRows = False
        dgvReports.AllowUserToDeleteRows = False
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReports.BackgroundColor = Color.White
        dgvReports.BorderStyle = BorderStyle.None
        dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReports.Dock = DockStyle.Fill
        dgvReports.Location = New Point(0, 80)
        dgvReports.Name = "dgvReports"
        dgvReports.ReadOnly = True
        dgvReports.RowHeadersWidth = 51
        dgvReports.RowTemplate.Height = 35
        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReports.Size = New Size(996, 394)
        dgvReports.TabIndex = 7
        ' 
        ' pnlReportControls
        ' 
        pnlReportControls.Controls.Add(lblReportTotal)
        pnlReportControls.Controls.Add(btnGenerateReport)
        pnlReportControls.Controls.Add(dtpEndDate)
        pnlReportControls.Controls.Add(lblEndDate)
        pnlReportControls.Controls.Add(dtpStartDate)
        pnlReportControls.Controls.Add(lblStartDate)
        pnlReportControls.Controls.Add(cboReportType)
        pnlReportControls.Controls.Add(lblReportType)
        pnlReportControls.Dock = DockStyle.Top
        pnlReportControls.Location = New Point(0, 0)
        pnlReportControls.Name = "pnlReportControls"
        pnlReportControls.Padding = New Padding(10)
        pnlReportControls.Size = New Size(996, 80)
        pnlReportControls.TabIndex = 9
        ' 
        ' lblReportTotal
        ' 
        lblReportTotal.AutoSize = True
        lblReportTotal.Font = New Font("Poppins", 9.0F)
        lblReportTotal.Location = New Point(13, 48)
        lblReportTotal.Name = "lblReportTotal"
        lblReportTotal.Size = New Size(103, 22)
        lblReportTotal.TabIndex = 8
        lblReportTotal.Text = "Total Records: 0"
        ' 
        ' btnGenerateReport
        ' 
        btnGenerateReport.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGenerateReport.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnGenerateReport.Cursor = Cursors.Hand
        btnGenerateReport.FlatAppearance.BorderSize = 0
        btnGenerateReport.FlatStyle = FlatStyle.Flat
        btnGenerateReport.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnGenerateReport.ForeColor = Color.White
        btnGenerateReport.Location = New Point(820, 15)
        btnGenerateReport.Name = "btnGenerateReport"
        btnGenerateReport.Size = New Size(165, 36)
        btnGenerateReport.TabIndex = 6
        btnGenerateReport.Text = "📊 Generate Report"
        btnGenerateReport.UseVisualStyleBackColor = False
        ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Font = New Font("Poppins", 9.0F)
        dtpEndDate.Location = New Point(606, 18)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(200, 25)
        dtpEndDate.TabIndex = 5
        ' 
        ' lblEndDate
        ' 
        lblEndDate.AutoSize = True
        lblEndDate.Font = New Font("Poppins", 9.0F)
        lblEndDate.Location = New Point(521, 21)
        lblEndDate.Name = "lblEndDate"
        lblEndDate.Size = New Size(65, 22)
        lblEndDate.TabIndex = 4
        lblEndDate.Text = "End Date:"
        ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Font = New Font("Poppins", 9.0F)
        dtpStartDate.Location = New Point(301, 18)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(200, 25)
        dtpStartDate.TabIndex = 3
        ' 
        ' lblStartDate
        ' 
        lblStartDate.AutoSize = True
        lblStartDate.Font = New Font("Poppins", 9.0F)
        lblStartDate.Location = New Point(211, 21)
        lblStartDate.Name = "lblStartDate"
        lblStartDate.Size = New Size(70, 22)
        lblStartDate.TabIndex = 2
        lblStartDate.Text = "Start Date:"
        ' 
        ' cboReportType
        ' 
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList
        cboReportType.Font = New Font("Poppins", 9.0F)
        cboReportType.FormattingEnabled = True
        cboReportType.Items.AddRange(New Object() {"Daily", "Weekly", "Monthly", "Annual"})
        cboReportType.Location = New Point(103, 18)
        cboReportType.Name = "cboReportType"
        cboReportType.Size = New Size(100, 30)
        cboReportType.TabIndex = 1
        ' 
        ' lblReportType
        ' 
        lblReportType.AutoSize = True
        lblReportType.Font = New Font("Poppins", 9.0F)
        lblReportType.Location = New Point(13, 21)
        lblReportType.Name = "lblReportType"
        lblReportType.Size = New Size(82, 22)
        lblReportType.TabIndex = 0
        lblReportType.Text = "Report Type:"
        ' 
        ' lblReports
        ' 
        lblReports.AutoSize = True
        lblReports.Dock = DockStyle.Top
        lblReports.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblReports.Location = New Point(0, 0)
        lblReports.Name = "lblReports"
        lblReports.Padding = New Padding(5, 8, 0, 0)
        lblReports.Size = New Size(118, 50)
        lblReports.TabIndex = 1
        lblReports.Text = "Reports"
        ' 
        ' pnlCashierManagement
        ' 
        pnlCashierManagement.Controls.Add(dgvCashiers)
        pnlCashierManagement.Controls.Add(pnlCashierControls)
        pnlCashierManagement.Controls.Add(pnlCashierHeader)
        pnlCashierManagement.Dock = DockStyle.Fill
        pnlCashierManagement.Location = New Point(25, 25)
        pnlCashierManagement.Name = "pnlCashierManagement"
        pnlCashierManagement.Size = New Size(1010, 565)
        pnlCashierManagement.TabIndex = 6
        pnlCashierManagement.Visible = False
        ' 
        ' dgvCashiers
        ' 
        dgvCashiers.AllowUserToAddRows = False
        dgvCashiers.AllowUserToDeleteRows = False
        dgvCashiers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCashiers.BackgroundColor = Color.White
        dgvCashiers.BorderStyle = BorderStyle.None
        dgvCashiers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCashiers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle10.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle10.SelectionForeColor = Color.White
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.True
        dgvCashiers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        dgvCashiers.ColumnHeadersHeight = 40
        dgvCashiers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = Color.White
        DataGridViewCellStyle11.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle11.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle11.SelectionForeColor = Color.White
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.False
        dgvCashiers.DefaultCellStyle = DataGridViewCellStyle11
        dgvCashiers.Dock = DockStyle.Fill
        dgvCashiers.EnableHeadersVisualStyles = False
        dgvCashiers.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCashiers.Location = New Point(0, 120)
        dgvCashiers.MultiSelect = False
        dgvCashiers.Name = "dgvCashiers"
        dgvCashiers.ReadOnly = True
        dgvCashiers.RowHeadersVisible = False
        dgvCashiers.RowHeadersWidth = 51
        DataGridViewCellStyle12.Padding = New Padding(10, 0, 0, 0)
        dgvCashiers.RowsDefaultCellStyle = DataGridViewCellStyle12
        dgvCashiers.RowTemplate.Height = 45
        dgvCashiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashiers.Size = New Size(1010, 445)
        dgvCashiers.TabIndex = 10
        ' 
        ' pnlCashierControls
        ' 
        pnlCashierControls.Controls.Add(flpCashierControls)
        pnlCashierControls.Dock = DockStyle.Top
        pnlCashierControls.Location = New Point(0, 60)
        pnlCashierControls.Name = "pnlCashierControls"
        pnlCashierControls.Padding = New Padding(0, 5, 0, 5)
        pnlCashierControls.Size = New Size(1010, 60)
        pnlCashierControls.TabIndex = 7
        ' 
        ' flpCashierControls
        ' 
        flpCashierControls.Controls.Add(btnDeleteCashier)
        flpCashierControls.Controls.Add(btnEditCashier)
        flpCashierControls.Controls.Add(btnAddCashier)
        flpCashierControls.Controls.Add(txtSearchCashiers)
        flpCashierControls.Controls.Add(lblSearchCashiers)
        flpCashierControls.Controls.Add(lblCashiersTotal)
        flpCashierControls.Dock = DockStyle.Fill
        flpCashierControls.FlowDirection = FlowDirection.RightToLeft
        flpCashierControls.Location = New Point(0, 5)
        flpCashierControls.Margin = New Padding(3, 2, 3, 2)
        flpCashierControls.Name = "flpCashierControls"
        flpCashierControls.Size = New Size(1010, 50)
        flpCashierControls.TabIndex = 8
        flpCashierControls.WrapContents = False
        ' 
        ' btnDeleteCashier
        ' 
        btnDeleteCashier.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteCashier.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDeleteCashier.Cursor = Cursors.Hand
        btnDeleteCashier.FlatAppearance.BorderSize = 0
        btnDeleteCashier.FlatStyle = FlatStyle.Flat
        btnDeleteCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnDeleteCashier.ForeColor = Color.White
        btnDeleteCashier.Location = New Point(877, 3)
        btnDeleteCashier.Name = "btnDeleteCashier"
        btnDeleteCashier.Size = New Size(130, 36)
        btnDeleteCashier.TabIndex = 4
        btnDeleteCashier.Text = "🗑️ Delete"
        btnDeleteCashier.UseVisualStyleBackColor = False
        ' 
        ' btnEditCashier
        ' 
        btnEditCashier.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnEditCashier.BackColor = Color.FromArgb(CByte(255), CByte(193), CByte(7))
        btnEditCashier.Cursor = Cursors.Hand
        btnEditCashier.FlatAppearance.BorderSize = 0
        btnEditCashier.FlatStyle = FlatStyle.Flat
        btnEditCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnEditCashier.ForeColor = Color.White
        btnEditCashier.Location = New Point(741, 3)
        btnEditCashier.Name = "btnEditCashier"
        btnEditCashier.Size = New Size(130, 36)
        btnEditCashier.TabIndex = 3
        btnEditCashier.Text = "✏️ Edit"
        btnEditCashier.UseVisualStyleBackColor = False
        ' 
        ' btnAddCashier
        ' 
        btnAddCashier.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddCashier.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAddCashier.Cursor = Cursors.Hand
        btnAddCashier.FlatAppearance.BorderSize = 0
        btnAddCashier.FlatStyle = FlatStyle.Flat
        btnAddCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)
        btnAddCashier.ForeColor = Color.White
        btnAddCashier.Location = New Point(604, 3)
        btnAddCashier.Name = "btnAddCashier"
        btnAddCashier.Size = New Size(131, 36)
        btnAddCashier.TabIndex = 2
        btnAddCashier.Text = "➕ Add Cashier"
        btnAddCashier.UseVisualStyleBackColor = False
        ' 
        ' txtSearchCashiers
        ' 
        txtSearchCashiers.Font = New Font("Poppins", 9.0F)
        txtSearchCashiers.Location = New Point(348, 8)
        txtSearchCashiers.Margin = New Padding(3, 8, 3, 3)
        txtSearchCashiers.Name = "txtSearchCashiers"
        txtSearchCashiers.PlaceholderText = "Search cashiers..."
        txtSearchCashiers.Size = New Size(250, 25)
        txtSearchCashiers.TabIndex = 6
        ' 
        ' lblSearchCashiers
        ' 
        lblSearchCashiers.AutoSize = True
        lblSearchCashiers.Font = New Font("Poppins", 9.0F)
        lblSearchCashiers.Location = New Point(281, 10)
        lblSearchCashiers.Margin = New Padding(3, 10, 10, 0)
        lblSearchCashiers.Name = "lblSearchCashiers"
        lblSearchCashiers.Size = New Size(54, 22)
        lblSearchCashiers.TabIndex = 7
        lblSearchCashiers.Text = "Search:"
        ' 
        ' lblCashiersTotal
        ' 
        lblCashiersTotal.AutoSize = True
        lblCashiersTotal.Font = New Font("Poppins", 9.0F)
        lblCashiersTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblCashiersTotal.Location = New Point(212, 10)
        lblCashiersTotal.Margin = New Padding(10, 10, 3, 0)
        lblCashiersTotal.Name = "lblCashiersTotal"
        lblCashiersTotal.Size = New Size(63, 22)
        lblCashiersTotal.TabIndex = 5
        lblCashiersTotal.Text = "(Total: 0)"
        ' 
        ' pnlCashierHeader
        ' 
        pnlCashierHeader.Controls.Add(lblCashierManagement)
        pnlCashierHeader.Dock = DockStyle.Top
        pnlCashierHeader.Location = New Point(0, 0)
        pnlCashierHeader.Name = "pnlCashierHeader"
        pnlCashierHeader.Padding = New Padding(0, 0, 0, 10)
        pnlCashierHeader.Size = New Size(1010, 60)
        pnlCashierHeader.TabIndex = 6
        ' 
        ' lblCashierManagement
        ' 
        lblCashierManagement.AutoSize = True
        lblCashierManagement.Font = New Font("Poppins", 18.0F, FontStyle.Bold)
        lblCashierManagement.Location = New Point(5, 8)
        lblCashierManagement.Name = "lblCashierManagement"
        lblCashierManagement.Size = New Size(285, 42)
        lblCashierManagement.TabIndex = 1
        lblCashierManagement.Text = "Cashier Management"
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.Controls.Add(pnlQueues)
        pnlDashboard.Controls.Add(pnlCashiersPanel)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(25, 25)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(1010, 565)
        pnlDashboard.TabIndex = 4
        ' 
        ' pnlQueues
        ' 
        pnlQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlQueues.BackColor = Color.White
        pnlQueues.Controls.Add(dgvAllQueues)
        pnlQueues.Controls.Add(pnlQueuesControls)
        pnlQueues.Controls.Add(pnlQueuesHeader)
        pnlQueues.Location = New Point(435, 0)
        pnlQueues.Name = "pnlQueues"
        pnlQueues.Size = New Size(575, 565)
        pnlQueues.TabIndex = 3
        ' 
        ' dgvAllQueues
        ' 
        dgvAllQueues.AllowUserToAddRows = False
        dgvAllQueues.AllowUserToDeleteRows = False
        dgvAllQueues.AllowUserToResizeRows = False
        dgvAllQueues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAllQueues.BackgroundColor = Color.White
        dgvAllQueues.BorderStyle = BorderStyle.None
        dgvAllQueues.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvAllQueues.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = Color.White
        DataGridViewCellStyle13.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle13.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle13.SelectionForeColor = Color.White
        DataGridViewCellStyle13.WrapMode = DataGridViewTriState.True
        dgvAllQueues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        dgvAllQueues.ColumnHeadersHeight = 40
        dgvAllQueues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = Color.White
        DataGridViewCellStyle14.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle14.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle14.SelectionForeColor = Color.White
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.False
        dgvAllQueues.DefaultCellStyle = DataGridViewCellStyle14
        dgvAllQueues.Dock = DockStyle.Fill
        dgvAllQueues.EnableHeadersVisualStyles = False
        dgvAllQueues.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvAllQueues.Location = New Point(0, 125)
        dgvAllQueues.MultiSelect = False
        dgvAllQueues.Name = "dgvAllQueues"
        dgvAllQueues.ReadOnly = True
        dgvAllQueues.RowHeadersVisible = False
        dgvAllQueues.RowHeadersWidth = 51
        DataGridViewCellStyle15.Padding = New Padding(10, 0, 0, 0)
        dgvAllQueues.RowsDefaultCellStyle = DataGridViewCellStyle15
        dgvAllQueues.RowTemplate.Height = 45
        dgvAllQueues.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllQueues.Size = New Size(575, 440)
        dgvAllQueues.TabIndex = 1
        ' 
        ' pnlQueuesControls
        ' 
        pnlQueuesControls.Controls.Add(txtSearchAllQueues)
        pnlQueuesControls.Controls.Add(lblSearchAllQueues)
        pnlQueuesControls.Dock = DockStyle.Top
        pnlQueuesControls.Location = New Point(0, 65)
        pnlQueuesControls.Name = "pnlQueuesControls"
        pnlQueuesControls.Padding = New Padding(20, 10, 20, 10)
        pnlQueuesControls.Size = New Size(575, 60)
        pnlQueuesControls.TabIndex = 5
        ' 
        ' txtSearchAllQueues
        ' 
        txtSearchAllQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearchAllQueues.Font = New Font("Poppins", 9.0F)
        txtSearchAllQueues.Location = New Point(345, 16)
        txtSearchAllQueues.Name = "txtSearchAllQueues"
        txtSearchAllQueues.PlaceholderText = "Search queues..."
        txtSearchAllQueues.Size = New Size(210, 25)
        txtSearchAllQueues.TabIndex = 3
        ' 
        ' lblSearchAllQueues
        ' 
        lblSearchAllQueues.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearchAllQueues.AutoSize = True
        lblSearchAllQueues.Font = New Font("Poppins", 9.0F)
        lblSearchAllQueues.Location = New Point(270, 19)
        lblSearchAllQueues.Name = "lblSearchAllQueues"
        lblSearchAllQueues.Size = New Size(75, 22)
        lblSearchAllQueues.TabIndex = 4
        lblSearchAllQueues.Text = "🔍 Search:"
        ' 
        ' pnlQueuesHeader
        ' 
        pnlQueuesHeader.Controls.Add(lblQueueTotal)
        pnlQueuesHeader.Controls.Add(lblQueueTitle)
        pnlQueuesHeader.Dock = DockStyle.Top
        pnlQueuesHeader.Location = New Point(0, 0)
        pnlQueuesHeader.Name = "pnlQueuesHeader"
        pnlQueuesHeader.Padding = New Padding(20, 15, 20, 5)
        pnlQueuesHeader.Size = New Size(575, 65)
        pnlQueuesHeader.TabIndex = 0
        ' 
        ' lblQueueTotal
        ' 
        lblQueueTotal.AutoSize = True
        lblQueueTotal.Font = New Font("Poppins", 10.0F)
        lblQueueTotal.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblQueueTotal.Location = New Point(230, 20)
        lblQueueTotal.Name = "lblQueueTotal"
        lblQueueTotal.Size = New Size(74, 25)
        lblQueueTotal.TabIndex = 2
        lblQueueTotal.Text = "(Total: 0)"
        ' 
        ' lblQueueTitle
        ' 
        lblQueueTitle.AutoSize = True
        lblQueueTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblQueueTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblQueueTitle.Location = New Point(20, 15)
        lblQueueTitle.Name = "lblQueueTitle"
        lblQueueTitle.Size = New Size(204, 34)
        lblQueueTitle.TabIndex = 0
        lblQueueTitle.Text = "Live Queue Activity"
        ' 
        ' pnlCashiersPanel
        ' 
        pnlCashiersPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        pnlCashiersPanel.BackColor = Color.White
        pnlCashiersPanel.Controls.Add(dgvCashierStatus)
        pnlCashiersPanel.Controls.Add(pnlCashiersHeader)
        pnlCashiersPanel.Location = New Point(0, 0)
        pnlCashiersPanel.Name = "pnlCashiersPanel"
        pnlCashiersPanel.Size = New Size(420, 565)
        pnlCashiersPanel.TabIndex = 2
        ' 
        ' dgvCashierStatus
        ' 
        dgvCashierStatus.AllowUserToAddRows = False
        dgvCashierStatus.AllowUserToDeleteRows = False
        dgvCashierStatus.AllowUserToResizeRows = False
        dgvCashierStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCashierStatus.BackgroundColor = Color.White
        dgvCashierStatus.BorderStyle = BorderStyle.None
        dgvCashierStatus.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvCashierStatus.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = Color.White
        DataGridViewCellStyle16.Font = New Font("Poppins", 10.2F, FontStyle.Bold)
        DataGridViewCellStyle16.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        DataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle16.SelectionForeColor = Color.White
        DataGridViewCellStyle16.WrapMode = DataGridViewTriState.True
        dgvCashierStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        dgvCashierStatus.ColumnHeadersHeight = 40
        dgvCashierStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = Color.White
        DataGridViewCellStyle17.Font = New Font("Poppins", 9.75F)
        DataGridViewCellStyle17.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        DataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        DataGridViewCellStyle17.SelectionForeColor = Color.White
        DataGridViewCellStyle17.WrapMode = DataGridViewTriState.False
        dgvCashierStatus.DefaultCellStyle = DataGridViewCellStyle17
        dgvCashierStatus.Dock = DockStyle.Fill
        dgvCashierStatus.EnableHeadersVisualStyles = False
        dgvCashierStatus.GridColor = Color.FromArgb(CByte(233), CByte(236), CByte(239))
        dgvCashierStatus.Location = New Point(0, 65)
        dgvCashierStatus.MultiSelect = False
        dgvCashierStatus.Name = "dgvCashierStatus"
        dgvCashierStatus.ReadOnly = True
        dgvCashierStatus.RowHeadersVisible = False
        dgvCashierStatus.RowHeadersWidth = 51
        DataGridViewCellStyle18.Padding = New Padding(10, 0, 0, 0)
        dgvCashierStatus.RowsDefaultCellStyle = DataGridViewCellStyle18
        dgvCashierStatus.RowTemplate.Height = 45
        dgvCashierStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashierStatus.Size = New Size(420, 500)
        dgvCashierStatus.TabIndex = 1
        ' 
        ' pnlCashiersHeader
        ' 
        pnlCashiersHeader.Controls.Add(lblActiveCashiers)
        pnlCashiersHeader.Controls.Add(lblCashierTitle)
        pnlCashiersHeader.Dock = DockStyle.Top
        pnlCashiersHeader.Location = New Point(0, 0)
        pnlCashiersHeader.Name = "pnlCashiersHeader"
        pnlCashiersHeader.Padding = New Padding(20, 15, 20, 5)
        pnlCashiersHeader.Size = New Size(420, 65)
        pnlCashiersHeader.TabIndex = 0
        ' 
        ' lblActiveCashiers
        ' 
        lblActiveCashiers.AutoSize = True
        lblActiveCashiers.Font = New Font("Poppins", 10.0F)
        lblActiveCashiers.ForeColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        lblActiveCashiers.Location = New Point(187, 20)
        lblActiveCashiers.Name = "lblActiveCashiers"
        lblActiveCashiers.Size = New Size(83, 25)
        lblActiveCashiers.TabIndex = 2
        lblActiveCashiers.Text = "(Active: 0)"
        ' 
        ' lblCashierTitle
        ' 
        lblCashierTitle.AutoSize = True
        lblCashierTitle.Font = New Font("Poppins", 14.25F, FontStyle.Bold)
        lblCashierTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCashierTitle.Location = New Point(20, 15)
        lblCashierTitle.Name = "lblCashierTitle"
        lblCashierTitle.Size = New Size(161, 34)
        lblCashierTitle.TabIndex = 0
        lblCashierTitle.Text = "Cashier Status"
        ' 
        ' tmrRefresh
        ' 
        tmrRefresh.Enabled = True
        tmrRefresh.Interval = 5000
        ' 
        ' frmAdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(1280, 700)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        MinimumSize = New Size(1024, 648)
        Name = "frmAdminDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOA EASE - Admin Dashboard"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlAdminManagement.ResumeLayout(False)
        CType(dgvAdmins, ComponentModel.ISupportInitialize).EndInit()
        pnlAdminControls.ResumeLayout(False)
        flpAdminControls.ResumeLayout(False)
        flpAdminControls.PerformLayout()
        pnlAdminHeader.ResumeLayout(False)
        pnlAdminHeader.PerformLayout()
        pnlUserManagement.ResumeLayout(False)
        tabUserManagement.ResumeLayout(False)
        tpWithAccount.ResumeLayout(False)
        CType(dgvUsersWithAccount, ComponentModel.ISupportInitialize).EndInit()
        tpWithoutAccount.ResumeLayout(False)
        CType(dgvUsersWithoutAccount, ComponentModel.ISupportInitialize).EndInit()
        pnlUserControls.ResumeLayout(False)
        flpUserControls.ResumeLayout(False)
        flpUserControls.PerformLayout()
        pnlUserHeader.ResumeLayout(False)
        pnlUserHeader.PerformLayout()
        pnlQueueLogs.ResumeLayout(False)
        CType(dgvQueueLogs, ComponentModel.ISupportInitialize).EndInit()
        pnlQueueLogsControls.ResumeLayout(False)
        flpQueueLogControls.ResumeLayout(False)
        flpQueueLogControls.PerformLayout()
        pnlQueueLogsHeader.ResumeLayout(False)
        pnlQueueLogsHeader.PerformLayout()
        pnlReports.ResumeLayout(False)
        pnlReports.PerformLayout()
        tabReports.ResumeLayout(False)
        tpQueueLogsReport.ResumeLayout(False)
        pnlQueueLogsReport.ResumeLayout(False)
        CType(dgvReports, ComponentModel.ISupportInitialize).EndInit()
        pnlReportControls.ResumeLayout(False)
        pnlReportControls.PerformLayout()
        pnlCashierManagement.ResumeLayout(False)
        CType(dgvCashiers, ComponentModel.ISupportInitialize).EndInit()
        pnlCashierControls.ResumeLayout(False)
        flpCashierControls.ResumeLayout(False)
        flpCashierControls.PerformLayout()
        pnlCashierHeader.ResumeLayout(False)
        pnlCashierHeader.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlQueues.ResumeLayout(False)
        CType(dgvAllQueues, ComponentModel.ISupportInitialize).EndInit()
        pnlQueuesControls.ResumeLayout(False)
        pnlQueuesControls.PerformLayout()
        pnlQueuesHeader.ResumeLayout(False)
        pnlQueuesHeader.PerformLayout()
        pnlCashiersPanel.ResumeLayout(False)
        CType(dgvCashierStatus, ComponentModel.ISupportInitialize).EndInit()
        pnlCashiersHeader.ResumeLayout(False)
        pnlCashiersHeader.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents btnCounterManagement As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnQueueLogs As Button
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents pnlQueues As Panel
    Friend WithEvents dgvAllQueues As DataGridView
    Friend WithEvents pnlQueuesHeader As Panel
    Friend WithEvents lblQueueTitle As Label
    Friend WithEvents lblQueueTotal As Label
    Friend WithEvents pnlCashiersPanel As Panel
    Friend WithEvents dgvCashierStatus As DataGridView
    Friend WithEvents pnlCashiersHeader As Panel
    Friend WithEvents lblCashierTitle As Label
    Friend WithEvents lblActiveCashiers As Label
    Friend WithEvents pnlUserManagement As Panel
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnEditUser As Button
    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents lblUsersTotal As Label
    Friend WithEvents pnlCashierManagement As Panel ' Renamed
    ' Removed Friend WithEvents dgvCounters As DataGridView
    ' Removed Friend WithEvents btnAddCounter As Button
    ' Removed Friend WithEvents btnEditCounter As Button
    ' Removed Friend WithEvents btnDeleteCounter As Button
    Friend WithEvents lblCashierManagement As Label ' Renamed
    Friend WithEvents lblCashiersTotal As Label ' Renamed
    Friend WithEvents pnlReports As Panel
    Friend WithEvents lblReports As Label
    Friend WithEvents tabReports As TabControl
    Friend WithEvents tpQueueLogsReport As TabPage
    Friend WithEvents pnlQueueLogsReport As Panel
    Friend WithEvents dgvReports As DataGridView
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents cboReportType As ComboBox
    Friend WithEvents lblReportType As Label
    Friend WithEvents lblReportTotal As Label
    Friend WithEvents pnlQueueLogs As Panel
    Friend WithEvents dgvQueueLogs As DataGridView
    Friend WithEvents lblQueueLogs As Label
    Friend WithEvents btnChangeStatus As Button
    Friend WithEvents lblQueueLogsTotal As Label
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents txtSearchAllQueues As TextBox
    Friend WithEvents lblSearchAllQueues As Label
    Friend WithEvents txtSearchUsers As TextBox
    Friend WithEvents lblSearchUsers As Label
    Friend WithEvents txtSearchQueueLogs As TextBox
    Friend WithEvents lblSearchQueueLogs As Label
    Friend WithEvents cboSortQueueLogs As ComboBox
    Friend WithEvents lblSortQueueLogs As Label
    Friend WithEvents pnlQueueLogsHeader As Panel
    Friend WithEvents pnlQueueLogsControls As Panel
    Friend WithEvents pnlUserHeader As Panel
    Friend WithEvents pnlUserControls As Panel
    Friend WithEvents pnlCashierHeader As Panel ' Renamed
    Friend WithEvents pnlCashierControls As Panel ' Renamed
    Friend WithEvents pnlReportControls As Panel
    Friend WithEvents pnlQueuesControls As Panel
    Friend WithEvents tabUserManagement As TabControl
    Friend WithEvents tpWithAccount As TabPage
    Friend WithEvents dgvUsersWithAccount As DataGridView
    Friend WithEvents tpWithoutAccount As TabPage
    Friend WithEvents dgvUsersWithoutAccount As DataGridView
    Friend WithEvents btnAdminManagement As Button
    Friend WithEvents pnlAdminManagement As Panel
    Friend WithEvents pnlAdminHeader As Panel
    Friend WithEvents lblAdminsTotal As Label
    Friend WithEvents lblAdminManagement As Label
    Friend WithEvents pnlAdminControls As Panel
    Friend WithEvents btnAddAdmin As Button
    Friend WithEvents btnEditAdmin As Button
    Friend WithEvents btnDeleteAdmin As Button
    Friend WithEvents txtSearchAdmins As TextBox
    Friend WithEvents lblSearchAdmins As Label
    Friend WithEvents dgvAdmins As DataGridView
    Friend WithEvents dgvCashiers As DataGridView
    ' Removed Friend WithEvents Label1 As Label
    Friend WithEvents btnAddCashier As Button
    Friend WithEvents btnEditCashier As Button
    Friend WithEvents btnDeleteCashier As Button
    Friend WithEvents lblSearchCashiers As Label
    Friend WithEvents txtSearchCashiers As TextBox
    Friend WithEvents flpUserControls As FlowLayoutPanel
    Friend WithEvents flpAdminControls As FlowLayoutPanel
    Friend WithEvents flpQueueLogControls As FlowLayoutPanel
    ' Removed Friend WithEvents flpCounterControls As FlowLayoutPanel
    ' Removed Friend WithEvents Label2 As Label
    Friend WithEvents flpCashierControls As FlowLayoutPanel ' Renamed
End Class

