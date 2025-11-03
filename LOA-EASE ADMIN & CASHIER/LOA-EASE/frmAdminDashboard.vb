Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Public Class frmAdminDashboard
    Private ReadOnly _adminFullName As String
    Private _activeButton As Button
    Private queueLogsTable As DataTable
    Private _lastQueueLogTimestamp As DateTime
    Private lblNoResultsFound As Label
    Private WithEvents tmrUserManagementRefresh As New Timer()
    Private WithEvents btnAddNewStudent As Button
    Private WithEvents btnBulkAddStudents As Button
    Private WithEvents btnDeleteStudent As Button
    Private _activePanel As Panel
    Private WithEvents cboSortUsers As ComboBox


    Public Sub New(adminFullName As String)
        InitializeComponent()
        _adminFullName = adminFullName
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmAdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblWelcome.Text = $"Welcome, {_adminFullName}"

        SetupDataGridViews()

        RefreshAllData()


        cboSortQueueLogs.Items.Clear()
        cboSortQueueLogs.Items.Add("Default")
        cboSortQueueLogs.Items.Add("Queue Number")
        cboSortQueueLogs.Items.Add("Full Name")
        cboSortQueueLogs.Items.Add("Status")
        cboSortQueueLogs.SelectedIndex = 0


        cboSortUsers = New ComboBox() With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Name = "cboSortUsers",
            .Size = New Size(150, 36),
            .Font = New Font("Poppins", 9.0F),
            .Margin = New Padding(3, 6, 3, 3)
        }
        cboSortUsers.Items.Add("Default")
        cboSortUsers.Items.Add("Name (A-Z)")
        cboSortUsers.Items.Add("Name (Z-A)")
        cboSortUsers.Items.Add("Student No.")
        cboSortUsers.Items.Add("Course")
        cboSortUsers.Items.Add("Year Level")
        cboSortUsers.Items.Add("Last Activity")
        cboSortUsers.Items.Add("New Added")
        cboSortUsers.SelectedIndex = 0
        AddHandler cboSortUsers.SelectedIndexChanged, AddressOf cboSortUsers_SelectedIndexChanged

        Dim lblSortUsers As New Label() With {
            .Text = "Sort:",
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F),
            .Name = "lblSortUsers",
            .Margin = New Padding(15, 13, 3, 0)
        }

        Dim lblSearchUsers As New Label() With {
            .Text = "Search:",
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F),
            .Name = "lblSearchUsers",
            .Margin = New Padding(0, 13, 3, 0)
        }

        txtSearchUsers.Size = New Size(200, 36)
        txtSearchUsers.Margin = New Padding(3, 8, 3, 3)

        btnAddNewStudent = New Button() With {
            .Name = "btnAddNewStudent",
            .Text = "➕ Add Student",
            .Size = New Size(130, 36),
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .BackColor = Color.FromArgb(0, 123, 255),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .Visible = False,
            .Margin = New Padding(3, 3, 3, 3)
        }
        btnAddNewStudent.FlatAppearance.BorderSize = 0

        btnBulkAddStudents = New Button() With {
            .Name = "btnBulkAddStudents",
            .Text = "📋 Bulk Add",
            .Size = New Size(130, 36),
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .BackColor = Color.FromArgb(40, 167, 69),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .Visible = False,
            .Margin = New Padding(3, 3, 3, 3)
        }
        btnBulkAddStudents.FlatAppearance.BorderSize = 0

        btnDeleteStudent = New Button() With {
            .Name = "btnDeleteStudent",
            .Text = "🗑️ Delete",
            .Size = New Size(100, 36),
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .BackColor = Color.FromArgb(220, 53, 69),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .Visible = False,
            .Margin = New Padding(3, 3, 3, 3)
        }
        btnDeleteStudent.FlatAppearance.BorderSize = 0
        AddHandler btnDeleteStudent.Click, AddressOf btnDeleteStudent_Click

        btnAddUser.Size = New Size(140, 36)
        btnAddUser.Text = "➕ Create Account"
        btnAddUser.Margin = New Padding(3, 3, 3, 3)

        btnEditUser.Size = New Size(100, 36)
        btnEditUser.Text = "✏️ Edit"
        btnEditUser.Margin = New Padding(3, 3, 3, 3)

        btnDeleteUser.Size = New Size(100, 36)
        btnDeleteUser.Text = "🗑️ Delete"
        btnDeleteUser.Margin = New Padding(3, 3, 3, 3)

        Dim lblNoResultsUsers As New Label() With {
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .ForeColor = Color.Red,
            .Name = "lblNoResultsFound",
            .Text = "No results found",
            .Visible = False,
            .Margin = New Padding(15, 13, 3, 3)
        }

        Dim spacerUser As New Panel With {
            .Name = "spacerUser",
            .Size = New Size(1, 1),
            .Margin = New Padding(0)
        }

        flpUserControls.FlowDirection = FlowDirection.LeftToRight
        flpUserControls.Controls.Clear()
        flpUserControls.Controls.Add(lblSearchUsers)
        flpUserControls.Controls.Add(txtSearchUsers)
        flpUserControls.Controls.Add(lblSortUsers)
        flpUserControls.Controls.Add(cboSortUsers)
        flpUserControls.Controls.Add(lblNoResultsUsers)
        flpUserControls.Controls.Add(spacerUser)
        flpUserControls.Controls.Add(btnAddUser)
        flpUserControls.Controls.Add(btnAddNewStudent)
        flpUserControls.Controls.Add(btnBulkAddStudents)
        flpUserControls.Controls.Add(btnEditUser)
        flpUserControls.Controls.Add(btnDeleteUser)
        flpUserControls.Controls.Add(btnDeleteStudent)

        AddHandler flpUserControls.Resize, AddressOf FlowLayoutPanel_Resize

        btnAddAdmin.Size = New Size(120, 36)
        btnAddAdmin.Text = "➕ Add Admin"
        btnAddAdmin.Margin = New Padding(3, 3, 3, 3)

        btnEditAdmin.Size = New Size(100, 36)
        btnEditAdmin.Text = "✏️ Edit"
        btnEditAdmin.Margin = New Padding(3, 3, 3, 3)

        btnDeleteAdmin.Size = New Size(100, 36)
        btnDeleteAdmin.Text = "🗑️ Delete"
        btnDeleteAdmin.Margin = New Padding(3, 3, 3, 3)

        txtSearchAdmins.Size = New Size(200, 36)
        txtSearchAdmins.Margin = New Padding(3, 8, 3, 3)

        Dim lblSearchAdmins As New Label() With {
            .Text = "Search:",
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F),
            .Name = "lblSearchAdmins",
            .Margin = New Padding(0, 13, 3, 0)
        }

        Dim lblNoResultsAdmins As New Label() With {
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .ForeColor = Color.Red,
            .Name = "lblNoResultsAdmins",
            .Text = "No results found",
            .Visible = False,
            .Margin = New Padding(15, 13, 3, 3)
        }

        Dim spacerAdmin As New Panel With {
            .Name = "spacerAdmin",
            .Size = New Size(1, 1),
            .Margin = New Padding(0)
        }

        flpAdminControls.FlowDirection = FlowDirection.LeftToRight
        flpAdminControls.Controls.Clear()
        flpAdminControls.Controls.Add(lblSearchAdmins)
        flpAdminControls.Controls.Add(txtSearchAdmins)
        flpAdminControls.Controls.Add(lblNoResultsAdmins)
        flpAdminControls.Controls.Add(spacerAdmin)
        flpAdminControls.Controls.Add(btnAddAdmin)
        flpAdminControls.Controls.Add(btnEditAdmin)
        flpAdminControls.Controls.Add(btnDeleteAdmin)

        AddHandler flpAdminControls.Resize, AddressOf FlowLayoutPanel_Resize

        btnAddCashier.Size = New Size(140, 36)
        btnAddCashier.Text = "➕ Add Cashier"
        btnAddCashier.Margin = New Padding(3, 3, 3, 3)
        btnAddCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)

        btnEditCashier.Size = New Size(100, 36)
        btnEditCashier.Text = "✏️ Edit"
        btnEditCashier.Margin = New Padding(3, 3, 3, 3)
        btnEditCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)

        btnDeleteCashier.Size = New Size(100, 36)
        btnDeleteCashier.Text = "🗑️ Delete"
        btnDeleteCashier.Margin = New Padding(3, 3, 3, 3)
        btnDeleteCashier.Font = New Font("Poppins", 9.0F, FontStyle.Bold)

        txtSearchCashiers.Size = New Size(200, 36)
        txtSearchCashiers.Margin = New Padding(3, 8, 3, 3)
        txtSearchCashiers.Font = New Font("Poppins", 9.0F)

        Dim lblSearchCashiers As New Label() With {
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F),
            .Name = "lblSearchCashiers",
            .Text = "Search:",
            .Margin = New Padding(0, 13, 3, 0)
        }

        Dim lblNoResultsCashiers As New Label() With {
            .AutoSize = True,
            .Font = New Font("Poppins", 9.0F, FontStyle.Bold),
            .ForeColor = Color.Red,
            .Name = "lblNoResultsCashiers",
            .Text = "No results found",
            .Visible = False,
            .Margin = New Padding(15, 13, 3, 3)
        }

        Dim spacerCashier As New Panel With {
            .Name = "spacerCashier",
            .Size = New Size(1, 1),
            .Margin = New Padding(0)
        }

        flpCashierControls.FlowDirection = FlowDirection.LeftToRight
        flpCashierControls.Controls.Clear()
        flpCashierControls.Controls.Add(lblSearchCashiers)
        flpCashierControls.Controls.Add(txtSearchCashiers)
        flpCashierControls.Controls.Add(lblNoResultsCashiers)
        flpCashierControls.Controls.Add(spacerCashier)
        flpCashierControls.Controls.Add(btnAddCashier)
        flpCashierControls.Controls.Add(btnEditCashier)
        flpCashierControls.Controls.Add(btnDeleteCashier)

        AddHandler flpCashierControls.Resize, AddressOf FlowLayoutPanel_Resize

        ShowPanel(pnlDashboard, btnDashboard)
        AddHandler tabUserManagement.SelectedIndexChanged, AddressOf tabUserManagement_SelectedIndexChanged
        AddHandler txtSearchAdmins.TextChanged, AddressOf txtSearchAdmins_TextChanged
        AddHandler txtSearchCashiers.TextChanged, AddressOf txtSearchCashiers_TextChanged
        AddHandler dgvCashiers.CellFormatting, AddressOf dgvCashiers_CellFormatting

        AddHandler dgvAdmins.DataError, AddressOf dgvAdmins_DataError
        AddHandler dgvCashiers.DataError, AddressOf dgvCashiers_DataError


    End Sub

    Private Sub FlowLayoutPanel_Resize(sender As Object, e As EventArgs)
        Dim flp = DirectCast(sender, FlowLayoutPanel)
        Dim spacer = flp.Controls.OfType(Of Panel).FirstOrDefault(Function(p) p.Name.StartsWith("spacer"))

        If spacer IsNot Nothing Then
            Dim occupiedWidth As Integer = 0
            For Each ctrl As Control In flp.Controls
                If ctrl IsNot spacer AndAlso ctrl.Visible Then
                    occupiedWidth += ctrl.Width + ctrl.Margin.Horizontal
                End If
            Next

            Dim availableWidth = flp.ClientSize.Width - occupiedWidth - flp.Padding.Horizontal
            spacer.Width = Math.Max(0, availableWidth)
            spacer.Visible = True
        End If
    End Sub


    Private Sub cboSortUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSortUsers.SelectedIndexChanged
        If cboSortUsers.SelectedItem IsNot Nothing Then
            ApplySorting(cboSortUsers.SelectedItem.ToString())
        End If
    End Sub


    Private Sub ApplySorting(sortBy As String)
        If _activePanel IsNot pnlUserManagement Then Return
        If tabUserManagement Is Nothing OrElse tabUserManagement.SelectedTab Is Nothing Then Return

        Dim activeGridView As DataGridView = Nothing
        If tabUserManagement.SelectedTab Is tpWithAccount Then
            activeGridView = dgvUsersWithAccount
        ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount Then
            activeGridView = dgvUsersWithoutAccount
        Else
            Return
        End If

        If activeGridView Is Nothing Then Return
        Dim source As BindingList(Of User) = TryCast(activeGridView.DataSource, BindingList(Of User))
        If source Is Nothing OrElse source.Count = 0 Then Return
        Dim userList As New List(Of User)(source)
        Select Case sortBy
            Case "Name (A-Z)"
                userList.Sort(Function(x, y) String.Compare(x.FullName, y.FullName))
            Case "Name (Z-A)"
                userList.Sort(Function(x, y) String.Compare(y.FullName, x.FullName))
            Case "Student No."
                userList.Sort(Function(x, y) String.Compare(x.StudentNo, y.StudentNo))
            Case "Course"
                userList.Sort(Function(x, y) String.Compare(x.Course, y.Course))
            Case "Year Level"
                userList.Sort(Function(x, y) String.Compare(x.YearLevel, y.YearLevel))
            Case "New Added"
                userList.Sort(Function(x, y) DateTime.Compare(y.CreatedAt, x.CreatedAt))
            Case "Last Activity"
                userList.Sort(Function(x, y)
                                  If x.LastQueueDateTime = "N/A" AndAlso y.LastQueueDateTime = "N/A" Then
                                      Return 0
                                  ElseIf x.LastQueueDateTime = "N/A" Then
                                      Return 1
                                  ElseIf y.LastQueueDateTime = "N/A" Then
                                      Return -1
                                  Else
                                      Dim format As String = "g"
                                      Dim dtX As DateTime
                                      Dim dtY As DateTime
                                      If DateTime.TryParseExact(x.LastQueueDateTime, format, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, dtX) AndAlso
                                         DateTime.TryParseExact(y.LastQueueDateTime, format, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, dtY) Then
                                          Return DateTime.Compare(dtY, dtX)
                                      Else
                                          Return 0
                                      End If
                                  End If
                              End Function)
            Case "Default"
                FetchUsers()
                Return
            Case Else
                Return
        End Select

        activeGridView.DataSource = New BindingList(Of User)(userList)
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs)
        If _activePanel Is pnlDashboard Then
            RefreshAllData()
        ElseIf _activePanel Is pnlCashierManagement Then
            FetchCashiers()
        ElseIf _activePanel Is pnlQueueLogs Then
            CheckForQueueLogUpdates()
        ElseIf _activePanel Is pnlAdminManagement Then
            FetchAdmins()
        ElseIf _activePanel Is pnlUserManagement Then
            FetchUsers()
        End If
    End Sub

    Private Sub CheckForQueueLogUpdates()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "SELECT MAX(created_at) FROM queues"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        Dim latest As DateTime = Convert.ToDateTime(result)
                        If latest > _lastQueueLogTimestamp Then
                            _lastQueueLogTimestamp = latest
                            FetchAllQueueLogs()
                        End If
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine($"Error checking queue updates: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub SetupDataGridViews()

        dgvAdmins.AutoGenerateColumns = False
        dgvAdmins.Columns.Clear()
        dgvAdmins.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "FullName",
            .HeaderText = "Full Name",
            .DataPropertyName = "FullName",
            .FillWeight = 40
        })
        dgvAdmins.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Username",
            .HeaderText = "Username",
            .DataPropertyName = "Username",
            .FillWeight = 30
        })
        dgvAdmins.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "LastLogin",
            .HeaderText = "Last Login",
            .DataPropertyName = "LastLogin",
            .FillWeight = 30
        })

        dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAdmins.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvAdmins.DefaultCellStyle.SelectionForeColor = Color.White
        dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvCashiers.AutoGenerateColumns = False
        dgvCashiers.Columns.Clear()
        dgvCashiers.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "FullName",
            .HeaderText = "Full Name",
            .DataPropertyName = "FullName",
            .FillWeight = 40
        })
        dgvCashiers.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Username",
            .HeaderText = "Username",
            .DataPropertyName = "Username",
            .FillWeight = 30
        })
        dgvCashiers.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "LastLogin",
            .HeaderText = "Last Login",
            .DataPropertyName = "LastLogin",
            .FillWeight = 30
        })


        Dim processedTodayColumnCashier As New DataGridViewTextBoxColumn With {
            .Name = "ProcessedToday",
            .HeaderText = "Processed Today",
            .DataPropertyName = "ProcessedToday",
            .FillWeight = 20,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        }
        dgvCashiers.Columns.Add(processedTodayColumnCashier)
        dgvCashiers.Columns("ProcessedToday").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvCashiers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashiers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvCashiers.DefaultCellStyle.SelectionForeColor = Color.White
        dgvCashiers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


        dgvCashierStatus.AutoGenerateColumns = False
        dgvCashierStatus.Columns.Clear()
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CashierName", .HeaderText = "Cashier Name", .DataPropertyName = "CashierName", .FillWeight = 35})
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Status", .HeaderText = "Status", .DataPropertyName = "Status", .FillWeight = 20})
        dgvCashierStatus.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Counter", .HeaderText = "Counter", .DataPropertyName = "Counter", .FillWeight = 25})

        dgvCashierStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashierStatus.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvCashierStatus.DefaultCellStyle.SelectionForeColor = Color.White
        dgvCashierStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvAllQueues.AutoGenerateColumns = False
        dgvAllQueues.Columns.Clear()
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "QueueNumber", .HeaderText = "Queue No.", .DataPropertyName = "QueueNumber"})
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FullName", .HeaderText = "Full Name", .DataPropertyName = "FullName"})
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "StudentNo", .HeaderText = "Student No.", .DataPropertyName = "StudentNo"})
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Counter", .HeaderText = "Counter", .DataPropertyName = "Counter"})
        dgvAllQueues.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Status", .HeaderText = "Status", .DataPropertyName = "Status"})
        dgvAllQueues.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllQueues.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvAllQueues.DefaultCellStyle.SelectionForeColor = Color.White
        dgvAllQueues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvQueueLogs.AutoGenerateColumns = False
        dgvQueueLogs.Columns.Clear()
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "QueueNumber", .HeaderText = "Queue No.", .DataPropertyName = "Queue Number"})
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FullName", .HeaderText = "Full Name", .DataPropertyName = "Full Name"})
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Status", .HeaderText = "Status", .DataPropertyName = "Status"})
        dgvQueueLogs.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CreatedAt", .HeaderText = "Date Created", .DataPropertyName = "Date Created"})
        dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueueLogs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvQueueLogs.DefaultCellStyle.SelectionForeColor = Color.White
        dgvQueueLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvUsersWithAccount.AutoGenerateColumns = False
        dgvUsersWithAccount.Columns.Clear()
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FullName", .HeaderText = "Full Name", .DataPropertyName = "FullName"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Username", .HeaderText = "Username", .DataPropertyName = "Username"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "StudentNo", .HeaderText = "Student No.", .DataPropertyName = "StudentNo"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Role", .HeaderText = "Role", .DataPropertyName = "Role"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "LastLogin", .HeaderText = "Last Login", .DataPropertyName = "LastLogin"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "LastSession", .HeaderText = "Last Session", .DataPropertyName = "LastSession"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "LastQueueDateTime", .HeaderText = "Last Queue", .DataPropertyName = "LastQueueDateTime"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Course", .HeaderText = "Course", .DataPropertyName = "Course"})
        dgvUsersWithAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "YearLevel", .HeaderText = "Year Level", .DataPropertyName = "YearLevel"})
        dgvUsersWithAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvUsersWithAccount.DefaultCellStyle.SelectionForeColor = Color.White
        dgvUsersWithAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvUsersWithoutAccount.AutoGenerateColumns = False
        dgvUsersWithoutAccount.Columns.Clear()
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FullName", .HeaderText = "Full Name", .DataPropertyName = "FullName"})
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "StudentNo", .HeaderText = "Student No.", .DataPropertyName = "StudentNo"})
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Course", .HeaderText = "Course", .DataPropertyName = "Course"})
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "YearLevel", .HeaderText = "Year Level", .DataPropertyName = "YearLevel"})
        dgvUsersWithoutAccount.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "LastQueueDateTime", .HeaderText = "Last Queue", .DataPropertyName = "LastQueueDateTime"})
        dgvUsersWithoutAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsersWithoutAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvUsersWithoutAccount.DefaultCellStyle.SelectionForeColor = Color.White
        dgvUsersWithoutAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        dgvReports.DefaultCellStyle.SelectionForeColor = Color.White
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub RefreshAllData()
        FetchCashierStatus()
        FetchAllQueues()
    End Sub

    Private Sub FetchCashierStatus()
        Dim cashierStatusList As New BindingList(Of CashierStatusItem)()
        Dim activeCashiers As Integer = 0
        Try
            Dim dt As DataTable = DatabaseHelper.GetCashierStatus()
            For Each row As DataRow In dt.Rows
                Dim statusText As String = "Offline"
                If Not row.IsNull("is_open") AndAlso CBool(row("is_open")) Then
                    statusText = If(row.IsNull("status"), "Open", row("status").ToString())
                    activeCashiers += 1
                End If

                cashierStatusList.Add(New CashierStatusItem With {
                    .CashierName = row("full_name").ToString(),
                    .Status = statusText,
                    .Counter = row("counter_name").ToString()
                })
            Next
            dgvCashierStatus.DataSource = cashierStatusList
            lblActiveCashiers.Text = $"(Active: {activeCashiers})"
            dgvCashierStatus.ClearSelection()
        Catch ex As Exception
            HandleDbError("fetching cashier status", ex)
        End Try
    End Sub

    Private Sub FetchAllQueues()
        Dim queueList As New BindingList(Of QueueLogItem)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                        SELECT
                            q.queue_number,
                            CASE 
                                WHEN q.visitor_id IS NOT NULL THEN v.full_name
                                ELSE CONCAT(s.first_name, ' ', s.last_name)
                            END AS FullName,
                        CASE 
                            WHEN q.visitor_id IS NOT NULL THEN 'VISITOR'
                            ELSE s.student_number
                        END AS StudentNo,
                        c.counter_name,
                        q.status
                    FROM queues q
                    LEFT JOIN students s ON q.student_id = s.student_id
                    LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                    JOIN counters c ON q.counter_id = c.counter_id
                    WHERE DATE(q.created_at) = CURDATE()
                    ORDER BY q.created_at DESC"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            queueList.Add(New QueueLogItem With {
                                .QueueNumber = reader("queue_number").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .StudentNo = If(reader("StudentNo") IsNot DBNull.Value, reader("StudentNo").ToString(), "VISITOR"),
                                .Counter = reader("counter_name").ToString(),
                                .Status = reader("status").ToString()
                            })
                        End While
                    End Using
                End Using
                dgvAllQueues.DataSource = queueList
                lblQueueTotal.Text = $"(Total: {queueList.Count})"
                dgvAllQueues.ClearSelection()
            Catch ex As Exception
                HandleDbError("fetching all queues", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchAllQueueLogs()
        queueLogsTable = New DataTable()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                SELECT
                    q.queue_id,
                    q.queue_number AS 'Queue Number',
                    CASE 
                        WHEN q.visitor_id IS NOT NULL THEN v.full_name
                        ELSE CONCAT(s.first_name, ' ', s.last_name)
                    END AS 'Full Name',
                    q.status AS 'Status',
                    q.created_at AS 'Date Created'
                FROM queues q
                LEFT JOIN students s ON q.student_id = s.student_id
                LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                ORDER BY
                    CASE
                        WHEN q.status = 'serving' THEN 1
                        WHEN q.status = 'waiting' THEN 2
                        ELSE 3
                    END,
                    q.created_at DESC"
                Using adapter As New MySqlDataAdapter(query, conn)
                    adapter.Fill(queueLogsTable)
                End Using

                dgvQueueLogs.DataSource = queueLogsTable

                dgvQueueLogs.AllowUserToOrderColumns = True
                dgvQueueLogs.ReadOnly = True
                dgvQueueLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                lblQueueLogsTotal.Text = $"(Total: {queueLogsTable.Rows.Count})"

                If queueLogsTable.Rows.Count > 0 Then
                    _lastQueueLogTimestamp = Convert.ToDateTime(queueLogsTable.Rows(0)("Date Created"))
                Else
                    _lastQueueLogTimestamp = DateTime.MinValue
                End If
                dgvQueueLogs.ClearSelection()

            Catch ex As Exception
                HandleDbError("fetching queue logs", ex)
            End Try
        End Using
    End Sub

    Private Sub txtSearchQueueLogs_TextChanged(sender As Object, e As EventArgs) Handles txtSearchQueueLogs.TextChanged
        If queueLogsTable Is Nothing Then Return
        Dim filterText As String = txtSearchQueueLogs.Text.Trim().Replace("'", "''")
        Dim view As DataView = queueLogsTable.DefaultView

        Try
            If String.IsNullOrWhiteSpace(filterText) Then
                view.RowFilter = String.Empty
            Else
                view.RowFilter = $"[Queue Number] LIKE '%{filterText}%' OR [Full Name] LIKE '%{filterText}%' OR [Status] LIKE '%{filterText}%'"
            End If
            Dim noResultsLabel = flpQueueLogControls.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Name = "lblNoResultsFound")
            If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = (view.Count = 0 AndAlso Not String.IsNullOrWhiteSpace(filterText))
        Catch ex As Exception
            Console.WriteLine($"Filter error: {ex.Message}")
            view.RowFilter = String.Empty
        End Try
    End Sub

    Private Sub txtSearchUsers_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUsers.TextChanged
        Dim searchText As String = txtSearchUsers.Text.Trim().ToLower()
        Dim noResultsLabel = flpUserControls.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Name = "lblNoResultsFound")
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = False

        If String.IsNullOrEmpty(searchText) Then
            If tabUserManagement.SelectedTab Is tpWithAccount AndAlso dgvUsersWithAccount.Tag IsNot Nothing Then
                dgvUsersWithAccount.DataSource = CType(dgvUsersWithAccount.Tag, BindingList(Of User))
                dgvUsersWithAccount.Tag = Nothing
            ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount AndAlso dgvUsersWithoutAccount.Tag IsNot Nothing Then
                dgvUsersWithoutAccount.DataSource = CType(dgvUsersWithoutAccount.Tag, BindingList(Of User))
                dgvUsersWithoutAccount.Tag = Nothing
            End If
            Return
        End If

        Dim resultsFound As Boolean = False
        If tabUserManagement.SelectedTab Is tpWithAccount Then
            Dim source = TryCast(dgvUsersWithAccount.DataSource, BindingList(Of User))
            If source IsNot Nothing Then
                If dgvUsersWithAccount.Tag Is Nothing Then dgvUsersWithAccount.Tag = source
                Dim originalSource = CType(dgvUsersWithAccount.Tag, BindingList(Of User))
                Dim filteredList = New BindingList(Of User)(originalSource.Where(Function(user)
                                                                                     Return user.FullName.ToLower().Contains(searchText) OrElse
                                                                                            user.Username.ToLower().Contains(searchText) OrElse
                                                                                            user.StudentNo.ToLower().Contains(searchText) OrElse
                                                                                            (user.Course IsNot Nothing AndAlso user.Course.ToLower().Contains(searchText)) OrElse
                                                                                            (user.YearLevel IsNot Nothing AndAlso user.YearLevel.ToLower().Contains(searchText)) OrElse
                                                                                            user.Role.ToLower().Contains(searchText)
                                                                                 End Function).ToList())
                dgvUsersWithAccount.DataSource = filteredList
                resultsFound = filteredList.Any()
            End If
        ElseIf tabUserManagement.SelectedTab Is tpWithoutAccount Then
            Dim source = TryCast(dgvUsersWithoutAccount.DataSource, BindingList(Of User))
            If source IsNot Nothing Then
                If dgvUsersWithoutAccount.Tag Is Nothing Then dgvUsersWithoutAccount.Tag = source
                Dim originalSource = CType(dgvUsersWithoutAccount.Tag, BindingList(Of User))
                Dim filteredList = New BindingList(Of User)(originalSource.Where(Function(user)
                                                                                     Return user.FullName.ToLower().Contains(searchText) OrElse
                                                                                            user.StudentNo.ToLower().Contains(searchText) OrElse
                                                                                            (user.Course IsNot Nothing AndAlso user.Course.ToLower().Contains(searchText)) OrElse
                                                                                            user.LastQueueDateTime.ToLower().Contains(searchText)
                                                                                 End Function).ToList())
                dgvUsersWithoutAccount.DataSource = filteredList
                resultsFound = filteredList.Any()
            End If
        End If

        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = Not resultsFound AndAlso Not String.IsNullOrEmpty(searchText)
    End Sub

    Private Sub txtSearchAdmins_TextChanged(sender As Object, e As EventArgs)
        Dim searchText As String = txtSearchAdmins.Text.Trim().ToLower()
        Dim noResultsLabel = flpAdminControls.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Name = "lblNoResultsAdmins")
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = False

        Dim source = TryCast(dgvAdmins.DataSource, BindingList(Of StaffUser))
        If source Is Nothing Then Return

        If String.IsNullOrEmpty(searchText) Then
            If dgvAdmins.Tag IsNot Nothing Then
                dgvAdmins.DataSource = CType(dgvAdmins.Tag, BindingList(Of StaffUser))
                dgvAdmins.Tag = Nothing
            End If
            Return
        End If

        If dgvAdmins.Tag Is Nothing Then dgvAdmins.Tag = source
        Dim originalSource = CType(dgvAdmins.Tag, BindingList(Of StaffUser))
        Dim filteredList = New BindingList(Of StaffUser)(originalSource.Where(Function(user)
                                                                                  Return user.FullName.ToLower().Contains(searchText) OrElse
                                                                                         user.Username.ToLower().Contains(searchText)
                                                                              End Function).ToList())
        dgvAdmins.DataSource = filteredList
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = Not filteredList.Any()
    End Sub

    Private Sub txtSearchCashiers_TextChanged(sender As Object, e As EventArgs)
        Dim searchText As String = txtSearchCashiers.Text.Trim().ToLower()
        Dim noResultsLabel = flpCashierControls.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Name = "lblNoResultsCashiers")
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = False

        Dim source = TryCast(dgvCashiers.DataSource, BindingList(Of StaffUser))
        If source Is Nothing Then Return

        If String.IsNullOrEmpty(searchText) Then
            If dgvCashiers.Tag IsNot Nothing Then
                dgvCashiers.DataSource = CType(dgvCashiers.Tag, BindingList(Of StaffUser))
                dgvCashiers.Tag = Nothing
            End If
            Return
        End If

        If dgvCashiers.Tag Is Nothing Then dgvCashiers.Tag = source
        Dim originalSource = CType(dgvCashiers.Tag, BindingList(Of StaffUser))
        Dim filteredList = New BindingList(Of StaffUser)(originalSource.Where(Function(user)
                                                                                  Return user.FullName.ToLower().Contains(searchText) OrElse
                                                                                         user.Username.ToLower().Contains(searchText)
                                                                              End Function).ToList())
        dgvCashiers.DataSource = filteredList
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = Not filteredList.Any()
    End Sub

    Private Sub txtSearchAllQueues_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAllQueues.TextChanged
        Dim searchText As String = txtSearchAllQueues.Text.Trim().ToLower()

        Dim source = TryCast(dgvAllQueues.DataSource, BindingList(Of QueueLogItem))
        If source Is Nothing Then Return

        If String.IsNullOrEmpty(searchText) Then
            If dgvAllQueues.Tag IsNot Nothing Then
                Dim originalData = CType(dgvAllQueues.Tag, BindingList(Of QueueLogItem))
                dgvAllQueues.DataSource = originalData
                dgvAllQueues.Tag = Nothing
                lblQueueTotal.Text = $"(Total: {originalData.Count})"
            End If
            Return
        End If

        If dgvAllQueues.Tag Is Nothing Then dgvAllQueues.Tag = source
        Dim originalSource = CType(dgvAllQueues.Tag, BindingList(Of QueueLogItem))
        Dim filteredList = New BindingList(Of QueueLogItem)(originalSource.Where(Function(queue)
                                                                                      Return queue.QueueNumber.ToLower().Contains(searchText) OrElse
                                                                                             queue.FullName.ToLower().Contains(searchText) OrElse
                                                                                             queue.StudentNo.ToLower().Contains(searchText) OrElse
                                                                                             queue.Counter.ToLower().Contains(searchText) OrElse
                                                                                             queue.Status.ToLower().Contains(searchText)
                                                                                  End Function).ToList())
        dgvAllQueues.DataSource = filteredList
        lblQueueTotal.Text = $"(Total: {filteredList.Count})"
    End Sub

    Private Sub cboSortQueueLogs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSortQueueLogs.SelectedIndexChanged
        If queueLogsTable Is Nothing Then Return

        Dim sortColumn As String = ""
        Select Case cboSortQueueLogs.SelectedItem.ToString()
            Case "Queue Number"
                sortColumn = "[Queue Number]"
            Case "Full Name"
                sortColumn = "[Full Name]"
            Case "Status"
                sortColumn = "[Status]"
            Case Else
                queueLogsTable.DefaultView.Sort = "[Date Created] DESC"
                Return
        End Select
        queueLogsTable.DefaultView.Sort = $"{sortColumn} ASC, [Date Created] DESC"
    End Sub

    Private Sub FetchUsers()
        Dim usersWithAccount As New BindingList(Of User)()
        Dim usersWithoutAccount As New BindingList(Of User)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                    SELECT
                        s.student_id, s.student_number, CONCAT(s.first_name, ' ', s.last_name) AS full_name,
                        s.course, s.year_level, s.created_at AS student_created_at,
                        u.user_id, u.username, u.last_login, u.created_at AS user_created_at,
                        q.last_queue_time
                    FROM students s
                    LEFT JOIN users u ON s.student_id = u.student_id
                    LEFT JOIN (SELECT student_id, MAX(created_at) AS last_queue_time FROM queues GROUP BY student_id) q
                        ON s.student_id = q.student_id
                    ORDER BY s.last_name, s.first_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New User With {
                                .StudentID = Convert.ToInt32(reader("student_id")),
                                .UserID = If(reader.IsDBNull(reader.GetOrdinal("user_id")), 0, Convert.ToInt32(reader("user_id"))),
                                .FullName = reader("full_name").ToString(),
                                .Username = If(reader.IsDBNull(reader.GetOrdinal("username")), "N/A", reader("username").ToString()),
                                .StudentNo = reader("student_number").ToString(),
                                .Course = If(reader.IsDBNull(reader.GetOrdinal("course")), "N/A", reader("course").ToString()),
                                .YearLevel = If(reader.IsDBNull(reader.GetOrdinal("year_level")), "N/A", reader("year_level").ToString()),
                                .Role = If(reader.IsDBNull(reader.GetOrdinal("user_id")), "No Account", "Student"),
                                .LastLogin = If(reader.IsDBNull(reader.GetOrdinal("last_login")), "N/A", Convert.ToDateTime(reader("last_login")).ToString("g")),
                                .LastSession = If(reader.IsDBNull(reader.GetOrdinal("user_created_at")), "N/A", Convert.ToDateTime(reader("user_created_at")).ToString("g")),
                                .LastQueueDateTime = If(reader.IsDBNull(reader.GetOrdinal("last_queue_time")), "N/A", Convert.ToDateTime(reader("last_queue_time")).ToString("g")),
                                .CreatedAt = If(reader.IsDBNull(reader.GetOrdinal("student_created_at")), DateTime.MinValue, Convert.ToDateTime(reader("student_created_at")))
                            }
                            If user.Role = "No Account" Then
                                usersWithoutAccount.Add(user)
                            Else
                                usersWithAccount.Add(user)
                            End If
                        End While
                    End Using
                End Using
                dgvUsersWithAccount.DataSource = usersWithAccount
                dgvUsersWithoutAccount.DataSource = usersWithoutAccount
                lblUsersTotal.Text = $"(Students: {usersWithAccount.Count + usersWithoutAccount.Count})"
                dgvUsersWithAccount.ClearSelection()
                dgvUsersWithoutAccount.ClearSelection()
                dgvUsersWithAccount.Tag = Nothing
                dgvUsersWithoutAccount.Tag = Nothing
            Catch ex As Exception
                HandleDbError("fetching student users", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchAdmins()
        Dim adminList As New BindingList(Of StaffUser)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "SELECT admin_id, full_name, username, last_login FROM admins ORDER BY full_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            adminList.Add(New StaffUser With {
                                .UserID = Convert.ToInt32(reader("admin_id")),
                                .FullName = reader("full_name").ToString(),
                                .Username = reader("username").ToString(),
                                .LastLogin = If(reader.IsDBNull(reader.GetOrdinal("last_login")), "N/A", Convert.ToDateTime(reader("last_login")).ToString("g")),
                                .Role = "Admin"
                            })
                        End While
                    End Using
                End Using
                dgvAdmins.DataSource = adminList
                lblAdminsTotal.Text = $"(Total: {adminList.Count})"
                dgvAdmins.ClearSelection()
                dgvAdmins.Tag = Nothing
            Catch ex As Exception
                HandleDbError("fetching admins", ex)
            End Try
        End Using
    End Sub

    Private Sub FetchCashiers()
        Dim processedCounts As New Dictionary(Of Integer, Integer)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "SELECT counter_id, COUNT(*) as ProcessedCount 
                                      FROM queues 
                                      WHERE status = 'completed' AND DATE(created_at) = CURDATE() 
                                      GROUP BY counter_id"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If Not reader.IsDBNull(reader.GetOrdinal("counter_id")) Then
                                processedCounts.Add(Convert.ToInt32(reader("counter_id")), Convert.ToInt32(reader("ProcessedCount")))
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error fetching processed queue counts: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Dim cashierList As New BindingList(Of StaffUser)()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                        SELECT csh.cashier_id, csh.counter_id, csh.full_name, csh.username, csh.last_login
                        FROM cashiers csh
                        ORDER BY csh.full_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim cashierId As Integer = Convert.ToInt32(reader("cashier_id"))
                            Dim processedToday As Integer = 0
                            
                            If Not reader.IsDBNull(reader.GetOrdinal("counter_id")) Then
                                Dim counterId As Integer = Convert.ToInt32(reader("counter_id"))
                                If processedCounts.ContainsKey(counterId) Then
                                    processedToday = processedCounts(counterId)
                                End If
                            End If

                            cashierList.Add(New StaffUser With {
                                .UserID = cashierId,
                                .FullName = reader("full_name").ToString(),
                                .Username = reader("username").ToString(),
                                .LastLogin = If(reader.IsDBNull(reader.GetOrdinal("last_login")), "N/A", Convert.ToDateTime(reader("last_login")).ToString("g")),
                                .Role = "Cashier",
                                .ProcessedToday = processedToday
                            })
                        End While
                    End Using
                End Using
                dgvCashiers.DataSource = cashierList
                lblCashiersTotal.Text = $"(Total: {cashierList.Count})"
                dgvCashiers.ClearSelection()
                dgvCashiers.Tag = Nothing
            Catch ex As Exception
                HandleDbError("fetching cashiers", ex)
            End Try
        End Using
    End Sub


    Private Sub HandleDbError(action As String, ex As Exception)
        tmrRefresh.Stop()
        MessageBox.Show($"Error {action}: {ex.Message}{vbCrLf}{vbCrLf}Please check the database connection and configuration.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowPanel(panelToShow As Panel, clickedButton As Button)
        pnlDashboard.Visible = False
        pnlUserManagement.Visible = False
        pnlAdminManagement.Visible = False
        pnlCashierManagement.Visible = False
        pnlReports.Visible = False
        pnlQueueLogs.Visible = False

        panelToShow.Visible = True
        panelToShow.BringToFront()
        _activePanel = panelToShow

        If _activeButton IsNot Nothing Then
            _activeButton.BackColor = Color.FromArgb(45, 52, 54)
        End If
        clickedButton.BackColor = Color.FromArgb(0, 85, 164)
        _activeButton = clickedButton
    End Sub


    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard, btnDashboard)
        RefreshAllData()
    End Sub

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click
        ShowPanel(pnlUserManagement, btnUserManagement)
        FetchUsers()
        tabUserManagement_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub btnAdminManagement_Click(sender As Object, e As EventArgs) Handles btnAdminManagement.Click
        ShowPanel(pnlAdminManagement, btnAdminManagement)
        FetchAdmins()
    End Sub

    Private Sub btnCounterManagement_Click(sender As Object, e As EventArgs) Handles btnCounterManagement.Click
        ShowPanel(pnlCashierManagement, btnCounterManagement)
        FetchCashiers()
    End Sub

    Private Sub btnQueueLogs_Click(sender As Object, e As EventArgs) Handles btnQueueLogs.Click
        ShowPanel(pnlQueueLogs, btnQueueLogs)
        FetchAllQueueLogs()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ShowPanel(pnlReports, btnReports)
        dgvReports.DataSource = Nothing
        lblReportTotal.Text = "Total Records: 0"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        tmrRefresh.Stop()
        If tmrUserManagementRefresh IsNot Nothing Then
            tmrUserManagementRefresh.Stop()
        End If

        Me.Close()
        Dim frmLogin As New frmLogin()
        frmLogin.Show()
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        DirectCast(sender, Button).Enabled = False
        Try
            If _activePanel Is pnlUserManagement AndAlso tabUserManagement.SelectedTab Is tpWithoutAccount Then
                If dgvUsersWithoutAccount.SelectedRows.Count > 0 Then
                    Dim selectedStudent As User = CType(dgvUsersWithoutAccount.SelectedRows(0).DataBoundItem, User)
                    If selectedStudent.Role = "No Account" Then
                        Using frm As New frmAddEditUser(selectedStudent.StudentID, selectedStudent.FullName)
                            frm.ShowDialog(Me)
                            If frm.DialogResult = DialogResult.OK Then
                                FetchUsers()
                            End If
                        End Using
                    Else
                        MessageBox.Show("This student seems to already have an account listed elsewhere.", "Account Exists Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        FetchUsers()
                    End If
                Else
                    MessageBox.Show("Please select a student from the 'Without Account' tab to create an account for.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("This action is only available for students without accounts.", "Action Not Applicable", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        DirectCast(sender, Button).Enabled = False
        Try
            If _activePanel Is pnlUserManagement AndAlso tabUserManagement.SelectedTab Is tpWithAccount Then
                If dgvUsersWithAccount.SelectedRows.Count > 0 Then
                    Dim selectedUser As User = CType(dgvUsersWithAccount.SelectedRows(0).DataBoundItem, User)
                    If selectedUser.Role <> "No Account" AndAlso selectedUser.UserID > 0 Then
                        Using frm As New frmAddEditUser(selectedUser.UserID, selectedUser.FullName, selectedUser.Username, selectedUser.Role)
                            frm.ShowDialog(Me)
                            If frm.DialogResult = DialogResult.OK Then
                                FetchUsers()
                            End If
                        End Using
                    Else
                        MessageBox.Show("Cannot edit selected entry. It might not have a valid account.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        FetchUsers()
                    End If
                Else
                    MessageBox.Show("Please select a student user from the 'With Account' tab to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("This action is only available for student accounts.", "Action Not Applicable", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub


    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If _activePanel Is pnlUserManagement AndAlso tabUserManagement.SelectedTab Is tpWithAccount Then
            If dgvUsersWithAccount.SelectedRows.Count > 0 Then
                Dim selectedUser As User = CType(dgvUsersWithAccount.SelectedRows(0).DataBoundItem, User)

                If selectedUser.Role = "No Account" OrElse selectedUser.UserID <= 0 Then
                    MessageBox.Show("This student does not have an account to delete.", "No Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                If MessageBox.Show($"Are you sure you want to delete the user account for '{selectedUser.FullName}'?{vbCrLf}This will NOT delete the student record itself.", "Confirm Account Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DirectCast(sender, Button).Enabled = False
                    Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                        Try
                            conn.Open()
                            Dim query As String = "DELETE FROM users WHERE user_id = @userId"

                            Using cmd As New MySqlCommand(query, conn)
                                cmd.Parameters.AddWithValue("@userId", selectedUser.UserID)
                                Dim result = cmd.ExecuteNonQuery()

                                If result > 0 Then
                                    MessageBox.Show("Student user account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    FetchUsers()
                                Else
                                    MessageBox.Show("Could not find the student user account to delete. The list will be refreshed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    FetchUsers()
                                End If
                            End Using
                        Catch ex As Exception
                            MessageBox.Show($"Error deleting student user account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
                            DirectCast(sender, Button).Enabled = True
                        End Try
                    End Using
                End If
            Else
                MessageBox.Show("Please select a student user from the 'With Account' tab to delete their account.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("This action is only available for student accounts.", "Action Not Applicable", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAddAdmin_Click(sender As Object, e As EventArgs) Handles btnAddAdmin.Click
        DirectCast(sender, Button).Enabled = False
        Try
            Using frm As New frmAddEditUser("Admin")
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.OK Then
                    FetchAdmins()
                End If
            End Using
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub



    Private Sub btnEditAdmin_Click(sender As Object, e As EventArgs) Handles btnEditAdmin.Click
        DirectCast(sender, Button).Enabled = False
        Try
            If dgvAdmins.SelectedRows.Count > 0 Then
                Dim selectedAdmin As StaffUser = CType(dgvAdmins.SelectedRows(0).DataBoundItem, StaffUser)
                Using frm As New frmAddEditUser(selectedAdmin.UserID, selectedAdmin.FullName, selectedAdmin.Username, "Admin")
                    frm.ShowDialog(Me)
                    If frm.DialogResult = DialogResult.OK Then
                        FetchAdmins()
                    End If
                End Using
            Else
                MessageBox.Show("Please select an admin to edit.", "No Admin Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnDeleteAdmin_Click(sender As Object, e As EventArgs) Handles btnDeleteAdmin.Click
        If dgvAdmins.SelectedRows.Count > 0 Then
            Dim selectedAdmin As StaffUser = CType(dgvAdmins.SelectedRows(0).DataBoundItem, StaffUser)

            If selectedAdmin.FullName = _adminFullName Then
                MessageBox.Show("You cannot delete your own admin account while logged in.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show($"Are you sure you want to permanently delete the admin account for '{selectedAdmin.FullName}'?", "Confirm Admin Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DirectCast(sender, Button).Enabled = False
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    Try
                        conn.Open()
                        Dim query As String = "DELETE FROM admins WHERE admin_id = @adminId"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@adminId", selectedAdmin.UserID)
                            Dim result = cmd.ExecuteNonQuery()
                            If result > 0 Then
                                MessageBox.Show("Admin account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                FetchAdmins()
                            Else
                                MessageBox.Show("Could not find the admin account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As Exception
                        MessageBox.Show($"Error deleting admin account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
                        DirectCast(sender, Button).Enabled = True
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select an admin to delete.", "No Admin Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAddCashier_Click(sender As Object, e As EventArgs) Handles btnAddCashier.Click
        DirectCast(sender, Button).Enabled = False
        Try
            Using frm As New frmAddEditUser("Cashier")
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.OK Then
                    FetchCashiers()
                End If
            End Using
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnEditCashier_Click(sender As Object, e As EventArgs) Handles btnEditCashier.Click
        DirectCast(sender, Button).Enabled = False
        Try
            If dgvCashiers.SelectedRows.Count > 0 Then
                Dim selectedCashier As StaffUser = CType(dgvCashiers.SelectedRows(0).DataBoundItem, StaffUser)
                Using frm As New frmAddEditUser(selectedCashier.UserID, selectedCashier.FullName, selectedCashier.Username, "Cashier")
                    frm.ShowDialog(Me)
                    If frm.DialogResult = DialogResult.OK Then
                        FetchCashiers()
                    End If
                End Using
            Else
                MessageBox.Show("Please select a cashier to edit.", "No Cashier Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnDeleteCashier_Click(sender As Object, e As EventArgs) Handles btnDeleteCashier.Click
        If dgvCashiers.SelectedRows.Count > 0 Then
            Dim selectedCashier As StaffUser = CType(dgvCashiers.SelectedRows(0).DataBoundItem, StaffUser)

            If MessageBox.Show($"Are you sure you want to permanently delete the cashier account for '{selectedCashier.FullName}'?", "Confirm Cashier Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DirectCast(sender, Button).Enabled = False
                Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                    Try
                        conn.Open()
                        Dim query As String = "DELETE FROM cashiers WHERE cashier_id = @cashierId"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@cashierId", selectedCashier.UserID)
                            Dim result = cmd.ExecuteNonQuery()
                            If result > 0 Then
                                MessageBox.Show("Cashier account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                FetchCashiers()
                            Else
                                MessageBox.Show("Could not find the cashier account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As MySqlException
                        If ex.Number = 1451 Then
                            MessageBox.Show($"Cannot delete cashier. They might be referenced elsewhere (e.g., active session logs - check database schema).", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show($"Error deleting cashier account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Catch ex As Exception
                        MessageBox.Show($"Error deleting cashier account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
                        DirectCast(sender, Button).Enabled = True
                    End Try
                End Using
            End If
        Else
            MessageBox.Show("Please select a cashier to delete.", "No Cashier Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnChangeStatus_Click(sender As Object, e As EventArgs) Handles btnChangeStatus.Click
        If dgvQueueLogs.SelectedRows.Count > 0 Then
            Dim selectedRow As DataRowView = TryCast(dgvQueueLogs.SelectedRows(0).DataBoundItem, DataRowView)

            If selectedRow IsNot Nothing Then
                Dim queueId As Integer = Convert.ToInt32(selectedRow("queue_id"))
                Dim queueNumber As String = selectedRow("Queue Number").ToString()
                Dim currentStatus As String = selectedRow("Status").ToString()

                Using statusForm As New Form() With {
                    .Text = "Change Queue Status",
                    .StartPosition = FormStartPosition.CenterParent,
                    .FormBorderStyle = FormBorderStyle.FixedDialog,
                    .ClientSize = New Size(250, 150),
                    .MaximizeBox = False,
                    .MinimizeBox = False
                }

                    Dim lbl As New Label() With {
                        .Text = $"Change status for {queueNumber}:",
                        .Location = New Point(10, 10),
                        .AutoSize = True
                    }
                    statusForm.Controls.Add(lbl)

                    Dim cboStatus As New ComboBox() With {
                        .DropDownStyle = ComboBoxStyle.DropDownList,
                        .Location = New Point(10, 40),
                        .Width = 230
                    }
                    cboStatus.Items.AddRange(New String() {"waiting", "serving", "completed", "cancelled", "no-show", "scheduled", "expired"})
                    cboStatus.SelectedItem = currentStatus
                    statusForm.Controls.Add(cboStatus)

                    Dim btnOk As New Button() With {
                        .Text = "OK",
                        .DialogResult = DialogResult.OK,
                        .Location = New Point(80, 80)
                    }
                    statusForm.Controls.Add(btnOk)

                    Dim btnCancel As New Button() With {
                        .Text = "Cancel",
                        .DialogResult = DialogResult.Cancel,
                        .Location = New Point(160, 80)
                    }
                    statusForm.Controls.Add(btnCancel)
                    statusForm.AcceptButton = btnOk
                    statusForm.CancelButton = btnCancel

                    If statusForm.ShowDialog(Me) = DialogResult.OK Then
                        Dim newStatus As String = cboStatus.SelectedItem.ToString()
                        If newStatus <> currentStatus Then
                            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                                Try
                                    conn.Open()
                                    Dim query As String = "UPDATE queues SET status = @status WHERE queue_id = @queueId"
                                    Using cmd As New MySqlCommand(query, conn)
                                        cmd.Parameters.AddWithValue("@status", newStatus)
                                        cmd.Parameters.AddWithValue("@queueId", queueId)
                                        cmd.ExecuteNonQuery()
                                    End Using
                                    FetchAllQueueLogs()
                                Catch ex As Exception
                                    MessageBox.Show($"Error updating status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End Using
                        End If
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Please select a queue entry to change its status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        FetchReportData()
    End Sub

    Private Sub FetchReportData()
        If cboReportType.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a report type.", "No Report Type Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reportType As String = cboReportType.SelectedItem.ToString()
        Dim startDate As Date = dtpStartDate.Value.Date
        Dim endDate As Date = dtpEndDate.Value.Date
        Dim reportData As New BindingList(Of QueueLogAdminItem)()

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim queryBuilder As New System.Text.StringBuilder("
                    SELECT q.queue_id, q.queue_number,
                           CASE 
                               WHEN q.visitor_id IS NOT NULL THEN v.full_name
                               ELSE CONCAT(s.first_name, ' ', s.last_name)
                           END AS FullName,
                           q.status, q.created_at,
                           c.full_name AS CashierName
                    FROM queues q
                    LEFT JOIN students s ON q.student_id = s.student_id
                    LEFT JOIN visitors v ON q.visitor_id = v.visitor_id
                    LEFT JOIN cashiers c ON q.counter_id = c.counter_id
                    WHERE ")

                Dim cmd As New MySqlCommand()

                Select Case reportType
                    Case "Daily"
                        queryBuilder.Append("DATE(q.created_at) = @dateParam")
                        cmd.Parameters.AddWithValue("@dateParam", startDate)
                    Case "Weekly"
                        queryBuilder.Append("YEARWEEK(q.created_at, 1) = YEARWEEK(@dateParam, 1)")
                        cmd.Parameters.AddWithValue("@dateParam", startDate)
                    Case "Monthly"
                        queryBuilder.Append("YEAR(q.created_at) = @yearParam AND MONTH(q.created_at) = @monthParam")
                        cmd.Parameters.AddWithValue("@yearParam", startDate.Year)
                        cmd.Parameters.AddWithValue("@monthParam", startDate.Month)
                    Case "Annual"
                        queryBuilder.Append("YEAR(q.created_at) = @yearParam")
                        cmd.Parameters.AddWithValue("@yearParam", startDate.Year)
                    Case Else
                        queryBuilder.Append("DATE(q.created_at) = @dateParam")
                        cmd.Parameters.AddWithValue("@dateParam", startDate)
                End Select

                queryBuilder.Append(" ORDER BY q.created_at DESC")

                cmd.CommandText = queryBuilder.ToString()
                cmd.Connection = conn


                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        reportData.Add(New QueueLogAdminItem With {
                            .QueueID = Convert.ToInt32(reader("queue_id")),
                            .QueueNumber = reader("queue_number").ToString(),
                            .FullName = reader("FullName").ToString(),
                            .Status = reader("status").ToString(),
                            .CreatedAt = Convert.ToDateTime(reader("created_at")).ToString("g"),
                            .CashierName = If(reader.IsDBNull(reader.GetOrdinal("CashierName")), "N/A", reader("CashierName").ToString())
                        })
                    End While
                End Using

                dgvReports.DataSource = reportData
                lblReportTotal.Text = $"Total Records: {reportData.Count}"
                dgvReports.ClearSelection()
            Catch ex As Exception
                HandleDbError("fetching report data", ex)
            End Try
        End Using
    End Sub

    Private Sub dgvQueueLogs_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvQueueLogs.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex <> dgvQueueLogs.Columns("Status").Index OrElse e.Value Is Nothing Then Return

        Dim status As String = e.Value.ToString()
        Dim isSelected As Boolean = dgvQueueLogs.Rows(e.RowIndex).Selected
        Dim backColor As Color = Color.White
        Dim foreColor As Color = Color.FromArgb(108, 117, 125)

        Select Case status
            Case "completed" : backColor = Color.LimeGreen : foreColor = Color.White
            Case "serving" : backColor = Color.DodgerBlue : foreColor = Color.White
            Case "waiting" : backColor = Color.Orange : foreColor = Color.White
            Case "cancelled" : backColor = Color.Crimson : foreColor = Color.White
            Case "no-show" : backColor = Color.DimGray : foreColor = Color.White
            Case "scheduled" : backColor = Color.MediumPurple : foreColor = Color.White
            Case "expired" : backColor = Color.SlateGray : foreColor = Color.White
        End Select

        e.CellStyle.BackColor = backColor
        e.CellStyle.ForeColor = foreColor

        If isSelected Then
            e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
            e.CellStyle.SelectionForeColor = Color.White
        Else
            e.CellStyle.SelectionBackColor = backColor
            e.CellStyle.SelectionForeColor = foreColor
        End If
        e.FormattingApplied = True



    End Sub

Private Sub dgvAllQueues_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvAllQueues.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex <> dgvAllQueues.Columns("Status").Index OrElse e.Value Is Nothing Then Return

        Dim status As String = e.Value.ToString()
        Dim isSelected As Boolean = dgvAllQueues.Rows(e.RowIndex).Selected
        Dim backColor As Color = Color.White
        Dim foreColor As Color = Color.FromArgb(108, 117, 125)

        Select Case status
            Case "completed" : backColor = Color.LimeGreen : foreColor = Color.White
            Case "serving" : backColor = Color.DodgerBlue : foreColor = Color.White
            Case "waiting" : backColor = Color.Orange : foreColor = Color.White
            Case "cancelled" : backColor = Color.Crimson : foreColor = Color.White
            Case "no-show" : backColor = Color.DimGray : foreColor = Color.White
            Case "scheduled" : backColor = Color.MediumPurple : foreColor = Color.White
            Case "expired" : backColor = Color.SlateGray : foreColor = Color.White
        End Select

        e.CellStyle.BackColor = backColor
        e.CellStyle.ForeColor = foreColor

        If isSelected Then
            e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
            e.CellStyle.SelectionForeColor = Color.White
        Else
            e.CellStyle.SelectionBackColor = backColor
            e.CellStyle.SelectionForeColor = foreColor
        End If
        e.FormattingApplied = True

    End Sub

    Private Sub dgvCashierStatus_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCashierStatus.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return

        If e.ColumnIndex = dgvCashierStatus.Columns("Status").Index Then
            Dim status As String = e.Value.ToString()
            Dim isSelected As Boolean = dgvCashierStatus.Rows(e.RowIndex).Selected
            Dim backColor As Color = Color.White
            Dim foreColor As Color = Color.FromArgb(108, 117, 125)

            Select Case status.ToLower()
                Case "open" : backColor = Color.LimeGreen : foreColor = Color.White
                Case "offline" : backColor = Color.DimGray : foreColor = Color.White
                Case "break" : backColor = Color.Orange : foreColor = Color.White
                Case Else
                    backColor = Color.LightGray : foreColor = Color.Black
            End Select

            e.CellStyle.BackColor = backColor
            e.CellStyle.ForeColor = foreColor

            If isSelected Then
                e.CellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
                e.CellStyle.SelectionForeColor = Color.White
            Else
                e.CellStyle.SelectionBackColor = backColor
                e.CellStyle.SelectionForeColor = foreColor
            End If
        End If

    End Sub

    Private Sub tabUserManagement_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim isWithoutAccountTab As Boolean = (tabUserManagement.SelectedTab Is tpWithoutAccount)

        btnAddUser.Visible = isWithoutAccountTab
        btnAddNewStudent.Visible = isWithoutAccountTab
        btnBulkAddStudents.Visible = isWithoutAccountTab
        btnDeleteStudent.Visible = isWithoutAccountTab
        btnEditUser.Visible = Not isWithoutAccountTab
        btnDeleteUser.Visible = Not isWithoutAccountTab

        txtSearchUsers.Clear()
        If dgvUsersWithAccount.Tag IsNot Nothing Then
            dgvUsersWithAccount.DataSource = CType(dgvUsersWithAccount.Tag, BindingList(Of User))
            dgvUsersWithAccount.Tag = Nothing
        End If
        If dgvUsersWithoutAccount.Tag IsNot Nothing Then
            dgvUsersWithoutAccount.DataSource = CType(dgvUsersWithoutAccount.Tag, BindingList(Of User))
            dgvUsersWithoutAccount.Tag = Nothing
        End If
        Dim noResultsLabel = flpUserControls.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Name = "lblNoResultsFound")
        If noResultsLabel IsNot Nothing Then noResultsLabel.Visible = False

        FlowLayoutPanel_Resize(flpUserControls, EventArgs.Empty)

    End Sub

    Private Sub btnAddNewStudent_Click(sender As Object, e As EventArgs) Handles btnAddNewStudent.Click
        DirectCast(sender, Button).Enabled = False
        Try
            Using frm As New frmAddStudent()
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.OK Then
                    MessageBox.Show("Student added successfully!",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information)
                    FetchUsers()
                End If
            End Using
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnBulkAddStudents_Click(sender As Object, e As EventArgs) Handles btnBulkAddStudents.Click
        DirectCast(sender, Button).Enabled = False
        Try
            Using frm As New frmBulkAddStudents()
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.OK Then
                    MessageBox.Show("Students added successfully!",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information)
                    FetchUsers()
                End If
            End Using
        Finally
            DirectCast(sender, Button).Enabled = True
        End Try
    End Sub

    Private Sub btnDeleteStudent_Click(sender As Object, e As EventArgs) Handles btnDeleteStudent.Click
        If dgvUsersWithoutAccount.SelectedRows.Count > 0 Then
            Dim selectedUser As User = CType(dgvUsersWithoutAccount.SelectedRows(0).DataBoundItem, User)

            If selectedUser.UserID > 0 Then
                MessageBox.Show($"Student '{selectedUser.FullName}' appears to have an account.{vbCrLf}Please delete the account first from the 'With Account' tab.", "Account Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to PERMANENTLY delete the student record for '{selectedUser.FullName}' (Student No: {selectedUser.StudentNo})?{vbCrLf}{vbCrLf}" &
            "⚠️ WARNING: This action cannot be undone and will remove the student entirely!",
            "Confirm Student Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)

            If result = DialogResult.Yes Then
                DirectCast(sender, Button).Enabled = False
                Try
                    Dim success As Boolean = DatabaseHelper.DeleteStudent(selectedUser.StudentNo)

                    If success Then
                        MessageBox.Show($"Student record for '{selectedUser.FullName}' has been successfully deleted.", "Student Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FetchUsers()
                    Else
                        MessageBox.Show("Failed to delete the student record. The student might no longer exist or there was a database error.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        FetchUsers()
                    End If
                Finally
                    DirectCast(sender, Button).Enabled = True
                End Try
            End If
        Else
            MessageBox.Show("Please select a student from the 'Without Account' tab to delete their record.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvCashiers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCashiers.CellFormatting
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return

        If e.ColumnIndex = dgvCashiers.Columns("ProcessedToday").Index Then
            If TypeOf e.Value Is Integer AndAlso CInt(e.Value) = 0 Then
                e.CellStyle.ForeColor = Color.Gray
                e.CellStyle.Format = "0"
            Else
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.Format = "N0"
            End If
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub dgvAdmins_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        Console.WriteLine($"DataGridView Admins Error: {e.Exception.Message}")
        e.ThrowException = False
    End Sub

    Private Sub dgvCashiers_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        Console.WriteLine($"DataGridView Cashiers Error: {e.Exception.Message}")
        e.ThrowException = False
    End Sub
End Class

Public Class CashierStatusItem
    Public Property CashierName As String
    Public Property Status As String
    Public Property Counter As String
End Class

Public Class QueueLogItem
    Public Property QueueNumber As String
    Public Property FullName As String
    Public Property StudentNo As String
    Public Property Counter As String
    Public Property Status As String
End Class

Public Class QueueLogAdminItem
    Public Property QueueID As Integer
    Public Property QueueNumber As String
    Public Property FullName As String
    Public Property Status As String
    Public Property CreatedAt As String
    Public Property CashierName As String
End Class

Public Class User
    Public Property UserID As Integer
    Public Property StudentID As Integer
    Public Property FullName As String
    Public Property Username As String
    Public Property StudentNo As String
    Public Property Role As String
    Public Property LastLogin As String
    Public Property LastSession As String
    Public Property LastQueueDateTime As String
    Public Property Course As String
    Public Property YearLevel As String
    Public Property CreatedAt As DateTime
End Class

Public Class StaffUser
    Public Property UserID As Integer
    Public Property FullName As String
    Public Property Username As String
    Public Property Role As String
    Public Property LastLogin As String
    Public Property ProcessedToday As Integer
End Class
