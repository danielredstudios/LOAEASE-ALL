Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class frmBulkAddStudents
    Private ReadOnly _accentColor As Color = Color.FromArgb(0, 85, 164)
    Private ReadOnly _grayColor As Color = Color.FromArgb(108, 117, 125)
    Private courseDictionary As New Dictionary(Of String, List(Of String))
    Private studentsList As New List(Of StudentEntry)
    Private Const MAX_ERRORS_TO_DISPLAY As Integer = 5

    Public Sub New()
        InitializeComponent()
        InitializeCourseDictionary()
        InitializeDataGridView()
    End Sub

    Private Sub InitializeCourseDictionary()
        courseDictionary.Add("College of Arts and Sciences", New List(Of String) From {
            "Bachelor of Science in Psychology"
        })

        courseDictionary.Add("College of Business Management Education", New List(Of String) From {
            "Bachelor of Science in Accountancy",
            "Bachelor of Science in Customs Administration",
            "BS Business Administration - Marketing Management",
            "BS Business Administration - Financial Management",
            "BS Business Administration - Human Resource Development Management"
        })

        courseDictionary.Add("College of Criminal Justice", New List(Of String) From {
            "Bachelor of Science in Criminology"
        })

        courseDictionary.Add("College of Computer Studies", New List(Of String) From {
            "BS in Computer Science",
            "BS in Information Technology"
        })

        courseDictionary.Add("College of Education", New List(Of String) From {
            "Bachelor of Elementary Education",
            "Bachelor of Secondary Education - English",
            "Bachelor of Secondary Education - Filipino",
            "Bachelor of Secondary Education - Mathematics",
            "BS Technical Vocational Teacher Education - Automotive Technology",
            "BS Technical Vocational Teacher Education - Computer Programming",
            "BS Technical Vocational Teacher Education - Food Service Management",
            "BS Technical Vocational Teacher Education - Electronics Technology",
            "BS Technical Vocational Teacher Education - Welding and Fabrication"
        })

        courseDictionary.Add("College of Engineering", New List(Of String) From {
            "Bachelor of Science in Industrial Engineering",
            "Bachelor of Science in Computer Engineering"
        })

        courseDictionary.Add("College of Law", New List(Of String) From {
            "Juris Doctor Program"
        })

        courseDictionary.Add("College of Real Estate Management", New List(Of String) From {
            "Bachelor of Science in Real Estate Management"
        })

        courseDictionary.Add("College of Tourism and Hospitality Management", New List(Of String) From {
            "Bachelor of Science in Tourism Management",
            "Bachelor of Science in Hospitality Management"
        })
    End Sub

    Private Sub InitializeDataGridView()
        dgvStudents.AutoGenerateColumns = False
        dgvStudents.AllowUserToAddRows = True
        dgvStudents.AllowUserToDeleteRows = True

        Dim colLastName As New DataGridViewTextBoxColumn With {
            .Name = "LastName",
            .HeaderText = "Last Name *",
            .DataPropertyName = "LastName",
            .Width = 150
        }
        dgvStudents.Columns.Add(colLastName)

        Dim colFirstName As New DataGridViewTextBoxColumn With {
            .Name = "FirstName",
            .HeaderText = "First Name *",
            .DataPropertyName = "FirstName",
            .Width = 150
        }
        dgvStudents.Columns.Add(colFirstName)

        Dim colStudentNo As New DataGridViewTextBoxColumn With {
            .Name = "StudentNo",
            .HeaderText = "Student Number *",
            .DataPropertyName = "StudentNo",
            .Width = 130
        }
        dgvStudents.Columns.Add(colStudentNo)

        Dim colEmail As New DataGridViewTextBoxColumn With {
            .Name = "Email",
            .HeaderText = "Email *",
            .DataPropertyName = "Email",
            .Width = 200
        }
        dgvStudents.Columns.Add(colEmail)

        Dim colDepartment As New DataGridViewComboBoxColumn With {
            .Name = "Department",
            .HeaderText = "Department *",
            .DataPropertyName = "Department",
            .Width = 200
        }
        colDepartment.Items.Add("-- Select Department --")
        For Each dept As String In courseDictionary.Keys
            colDepartment.Items.Add(dept)
        Next
        dgvStudents.Columns.Add(colDepartment)

        Dim colCourse As New DataGridViewComboBoxColumn With {
            .Name = "Course",
            .HeaderText = "Course *",
            .DataPropertyName = "Course",
            .Width = 250
        }
        colCourse.Items.Add("-- Select Course --")
        dgvStudents.Columns.Add(colCourse)

        Dim colYearLevel As New DataGridViewComboBoxColumn With {
            .Name = "YearLevel",
            .HeaderText = "Year Level *",
            .DataPropertyName = "YearLevel",
            .Width = 120
        }
        colYearLevel.Items.AddRange(New String() {"-- Select --", "1st Year", "2nd Year", "3rd Year", "4th Year", "Irregular"})
        dgvStudents.Columns.Add(colYearLevel)

        dgvStudents.DataSource = New BindingList(Of StudentEntry)(studentsList)
    End Sub

    Private Sub dgvStudents_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        If dgvStudents.Columns(e.ColumnIndex).Name = "Department" Then
            Dim selectedDept As String = dgvStudents.Rows(e.RowIndex).Cells("Department").Value?.ToString()
            If Not String.IsNullOrEmpty(selectedDept) AndAlso selectedDept <> "-- Select Department --" AndAlso courseDictionary.ContainsKey(selectedDept) Then
                Dim courseCell As DataGridViewComboBoxCell = TryCast(dgvStudents.Rows(e.RowIndex).Cells("Course"), DataGridViewComboBoxCell)
                If courseCell IsNot Nothing Then
                    courseCell.Items.Clear()
                    courseCell.Items.Add("-- Select Course --")
                    For Each course As String In courseDictionary(selectedDept)
                        courseCell.Items.Add(course)
                    Next
                    courseCell.Value = "-- Select Course --"
                End If
            End If
        End If
    End Sub

    Private Sub dgvStudents_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvStudents.CurrentCellDirtyStateChanged
        If dgvStudents.IsCurrentCellDirty Then
            dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email.Trim()
        Catch
            Return False
        End Try
    End Function

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        Dim validEntries As New List(Of StudentEntry)
        Dim errors As New List(Of String)

        For i As Integer = 0 To dgvStudents.Rows.Count - 1
            If dgvStudents.Rows(i).IsNewRow Then Continue For

            Dim firstName As String = dgvStudents.Rows(i).Cells("FirstName").Value?.ToString()?.Trim()
            Dim lastName As String = dgvStudents.Rows(i).Cells("LastName").Value?.ToString()?.Trim()
            Dim studentNo As String = dgvStudents.Rows(i).Cells("StudentNo").Value?.ToString()?.Trim()
            Dim email As String = dgvStudents.Rows(i).Cells("Email").Value?.ToString()?.Trim()
            Dim department As String = dgvStudents.Rows(i).Cells("Department").Value?.ToString()
            Dim course As String = dgvStudents.Rows(i).Cells("Course").Value?.ToString()
            Dim yearLevel As String = dgvStudents.Rows(i).Cells("YearLevel").Value?.ToString()

            If String.IsNullOrWhiteSpace(firstName) OrElse
               String.IsNullOrWhiteSpace(lastName) OrElse
               String.IsNullOrWhiteSpace(studentNo) OrElse
               String.IsNullOrWhiteSpace(email) OrElse
               String.IsNullOrEmpty(department) OrElse department = "-- Select Department --" OrElse
               String.IsNullOrEmpty(course) OrElse course = "-- Select Course --" OrElse
               String.IsNullOrEmpty(yearLevel) OrElse yearLevel = "-- Select --" Then
                errors.Add($"Row {i + 1}: Please fill in all fields")
                Continue For
            End If

            If Not IsValidEmail(email) Then
                errors.Add($"Row {i + 1}: Please enter a valid email address")
                Continue For
            End If

            validEntries.Add(New StudentEntry With {
                .FirstName = firstName,
                .LastName = lastName,
                .StudentNo = studentNo,
                .Email = email,
                .Department = department,
                .Course = course,
                .YearLevel = yearLevel
            })
        Next

        If validEntries.Count = 0 Then
            MessageBox.Show("Please add at least one student with complete information." & vbCrLf & vbCrLf &
                          If(errors.Count > 0, "Problems found:" & vbCrLf & String.Join(vbCrLf, errors), ""),
                          "No Students to Save",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            Return
        End If

        If errors.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show(
                $"{validEntries.Count} student(s) are ready to save, but {errors.Count} row(s) have problems." & vbCrLf & vbCrLf &
                "Problems found:" & vbCrLf & String.Join(vbCrLf, errors.Take(MAX_ERRORS_TO_DISPLAY)) &
                If(errors.Count > MAX_ERRORS_TO_DISPLAY, vbCrLf & $"... and {errors.Count - MAX_ERRORS_TO_DISPLAY} more problem(s)", "") & vbCrLf & vbCrLf &
                "Would you like to save the students that are ready?",
                "Some Students Have Problems",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If result <> DialogResult.Yes Then Return
        End If

        btnSaveAll.Enabled = False
        btnCancel.Enabled = False
        Try
            Dim successCount As Integer = 0
            Dim failCount As Integer = 0
            Dim failedEntries As New List(Of String)

            For Each entry In validEntries
                Dim success As Boolean = DatabaseHelper.AddStudent(
                    entry.FirstName,
                    entry.LastName,
                    entry.StudentNo,
                    entry.Course,
                    entry.YearLevel,
                    entry.Email
                )

                If success Then
                    successCount += 1
                Else
                    failCount += 1
                    failedEntries.Add($"{entry.FirstName} {entry.LastName} ({entry.StudentNo})")
                End If
            Next

            If failCount = 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                If successCount > 0 Then
                    MessageBox.Show($"{successCount} student(s) were added successfully." & vbCrLf &
                                  $"{failCount} student(s) could not be added because they may already exist:" & vbCrLf & vbCrLf &
                                  String.Join(vbCrLf, failedEntries.Take(MAX_ERRORS_TO_DISPLAY)) &
                                  If(failedEntries.Count > MAX_ERRORS_TO_DISPLAY, vbCrLf & $"... and {failedEntries.Count - MAX_ERRORS_TO_DISPLAY} more", ""),
                                  "Partial Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning)
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show($"None of the students could be added. They may already exist:" & vbCrLf & vbCrLf &
                                  String.Join(vbCrLf, failedEntries.Take(MAX_ERRORS_TO_DISPLAY)) &
                                  If(failedEntries.Count > MAX_ERRORS_TO_DISPLAY, vbCrLf & $"... and {failedEntries.Count - MAX_ERRORS_TO_DISPLAY} more", ""),
                                  "All Failed",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Sorry, something went wrong while saving the students. Please try again." & vbCrLf & vbCrLf &
                          "Details: " & ex.Message,
                          "Problem Saving Students",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        Finally
            btnSaveAll.Enabled = True
            btnCancel.Enabled = True
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MessageBox.Show("Are you sure you want to clear all entries?",
                          "Confirm Clear",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) = DialogResult.Yes Then
            studentsList.Clear()
            dgvStudents.DataSource = New BindingList(Of StudentEntry)(studentsList)
        End If
    End Sub

    Private isDragging As Boolean = False
    Private dragOffset As Point

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        AddHandler pnlHeader.MouseDown, AddressOf Header_MouseDown
        AddHandler pnlHeader.MouseMove, AddressOf Header_MouseMove
        AddHandler pnlHeader.MouseUp, AddressOf Header_MouseUp
        AddHandler lblTitle.MouseDown, AddressOf Header_MouseDown
        AddHandler lblTitle.MouseMove, AddressOf Header_MouseMove
        AddHandler lblTitle.MouseUp, AddressOf Header_MouseUp
    End Sub

    Private Sub Header_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragOffset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Header_MouseMove(sender As Object, e As MouseEventArgs)
        If isDragging Then
            Dim currentScreenPos As Point = PointToScreen(e.Location)
            Me.Location = New Point(currentScreenPos.X - dragOffset.X, currentScreenPos.Y - dragOffset.Y)
        End If
    End Sub

    Private Sub Header_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub
End Class

Public Class StudentEntry
    Public Property FirstName As String
    Public Property LastName As String
    Public Property StudentNo As String
    Public Property Email As String
    Public Property Department As String
    Public Property Course As String
    Public Property YearLevel As String
End Class
