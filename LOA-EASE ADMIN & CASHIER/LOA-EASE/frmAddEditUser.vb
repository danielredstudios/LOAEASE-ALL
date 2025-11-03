Imports MySql.Data.MySqlClient

Public Class frmAddEditUser
    Private ReadOnly _isEditMode As Boolean
    Private ReadOnly _userId As Integer
    Private ReadOnly _studentId As Integer
    Private ReadOnly _initialUsername As String
    Private _role As String

    Public Sub New()
        InitializeComponent()
        _isEditMode = False
        _role = "Admin"
        Me.Text = "Add New Admin"
        lblTitle.Text = "Add New Admin"
        txtFullName.ReadOnly = False
        Label4.Visible = False
        cboRole.Visible = False
    End Sub

    Public Sub New(addRole As String)
        InitializeComponent()
        _isEditMode = False
        _role = addRole
        Me.Text = $"Add New {addRole}"
        lblTitle.Text = $"Add New {addRole}"
        txtFullName.ReadOnly = False
        Label4.Visible = False
        cboRole.Visible = False
    End Sub

    Public Sub New(userId As Integer, fullName As String, username As String, role As String)
        InitializeComponent()
        _isEditMode = True
        _userId = userId
        _initialUsername = username
        _role = role
        Me.Text = $"Edit {role}"
        lblTitle.Text = $"Edit {role}"
        txtFullName.Text = fullName
        txtUsername.Text = username

        If role = "Student" Then
            txtFullName.ReadOnly = True
        Else
            txtFullName.ReadOnly = False
        End If

        Label4.Visible = False
        cboRole.Visible = False
    End Sub

    Public Sub New(studentId As Integer, fullName As String)
        InitializeComponent()
        _isEditMode = False
        _studentId = studentId
        _role = "Student"
        Me.Text = "Create Student Account"
        lblTitle.Text = "Create Account for Student"
        txtFullName.Text = fullName
        txtFullName.ReadOnly = True
        txtUsername.Text = GenerateUsername(fullName)
        Label4.Visible = False
        cboRole.Visible = False
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFullName.Text) OrElse String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not _isEditMode AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRole As String = _role

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()

                If _isEditMode Then
                    If _role = "Student" Then
                        Dim studentQuery As New System.Text.StringBuilder()
                        studentQuery.Append("UPDATE users SET username = @username")
                        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                            studentQuery.Append(", password_hash = @passwordHash")
                        End If
                        studentQuery.Append(" WHERE user_id = @userId")

                        Using cmd As New MySqlCommand(studentQuery.ToString(), conn)
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                            cmd.Parameters.AddWithValue("@userId", _userId)
                            If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                                cmd.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                            End If
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        Dim tableName As String = If(selectedRole = "Admin", "admins", "cashiers")
                        Dim idColumn As String = If(selectedRole = "Admin", "admin_id", "cashier_id")

                        Dim query As New System.Text.StringBuilder()
                        query.Append($"UPDATE {tableName} SET full_name = @fullName, username = @username")
                        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                            query.Append(", password_hash = @passwordHash")
                        End If

                        query.Append($" WHERE {idColumn} = @userId")

                        Using cmd As New MySqlCommand(query.ToString(), conn)
                            cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim())
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                            cmd.Parameters.AddWithValue("@userId", _userId)
                            If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                                cmd.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                            End If

                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Else
                    Dim query As String
                    If _studentId > 0 Then
                        query = "INSERT INTO users (student_id, username, password_hash) VALUES (@studentId, @username, @passwordHash)"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@studentId", _studentId)
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                            cmd.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        Dim tableName As String = If(selectedRole = "Admin", "admins", "cashiers")
                        query = $"INSERT INTO {tableName} (full_name, username, password_hash) VALUES (@fullName, @username, @passwordHash)"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim())
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                            cmd.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MessageBox.Show($"Error saving user: The username '{txtUsername.Text.Trim()}' already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show($"Error saving user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class