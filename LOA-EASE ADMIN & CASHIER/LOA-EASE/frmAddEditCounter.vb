Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAddEditCounter
    Private ReadOnly _isEditMode As Boolean
    Private ReadOnly _counterId As Integer

    Public Sub New()
        InitializeComponent()
        _isEditMode = False
        Me.Text = "Add New Counter"
        lblTitle.Text = "Add New Counter"
    End Sub

    Public Sub New(counterId As Integer)
        InitializeComponent()
        _isEditMode = True
        _counterId = counterId
        Me.Text = "Edit Counter"
        lblTitle.Text = "Edit Counter"
    End Sub

    Private Sub frmAddEditCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isEditMode Then
            LoadCounterAndCashierData()
        End If
    End Sub

    Private Sub LoadCounterAndCashierData()
        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            Try
                conn.Open()
                Dim query As String = "
                    SELECT c.counter_name, ch.full_name, ch.username
                    FROM counters c
                    LEFT JOIN cashiers ch ON c.counter_id = ch.counter_id
                    WHERE c.counter_id = @counterId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@counterId", _counterId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtCounterName.Text = reader("counter_name").ToString()
                            txtCashierFullName.Text = reader("full_name").ToString()
                            txtUsername.Text = reader("username").ToString()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error loading counter data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCounterName.Text) OrElse
           String.IsNullOrWhiteSpace(txtCashierFullName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("All fields except password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As MySqlConnection = DatabaseHelper.GetConnection()
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()
            Try
                If _isEditMode Then
                    Dim updateCounterQuery As String = "UPDATE counters SET counter_name = @counterName WHERE counter_id = @counterId"
                    Using cmd As New MySqlCommand(updateCounterQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@counterName", txtCounterName.Text.Trim())
                        cmd.Parameters.AddWithValue("@counterId", _counterId)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim cashierQuery As String
                    If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        cashierQuery = "
                            UPDATE cashiers
                            SET full_name = @fullName, username = @username, password_hash = @password
                            WHERE counter_id = @counterId"
                    Else
                        cashierQuery = "
                            UPDATE cashiers
                            SET full_name = @fullName, username = @username
                            WHERE counter_id = @counterId"
                    End If

                    Using cmd As New MySqlCommand(cashierQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@fullName", txtCashierFullName.Text.Trim())
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                            cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                        End If
                        cmd.Parameters.AddWithValue("@counterId", _counterId)
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    Dim insertCounterQuery As String = "INSERT INTO counters (counter_name) VALUES (@counterName); SELECT LAST_INSERT_ID();"
                    Dim newCounterId As Integer
                    Using cmd As New MySqlCommand(insertCounterQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@counterName", txtCounterName.Text.Trim())
                        newCounterId = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using
                    If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        MessageBox.Show("Password is required for new cashiers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        transaction.Rollback()
                        Return
                    End If
                    Dim insertCashierQuery As String = "
                        INSERT INTO cashiers (counter_id, username, password_hash, full_name, role)
                        VALUES (@counterId, @username, @password, @fullName, 'cashier')"
                    Using cmd As New MySqlCommand(insertCashierQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@counterId", newCounterId)
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text))
                        cmd.Parameters.AddWithValue("@fullName", txtCashierFullName.Text.Trim())
                        cmd.ExecuteNonQuery()
                    End Using
                End If
                transaction.Commit()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show($"Error saving counter: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub
End Class