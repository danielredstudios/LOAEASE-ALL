Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class frmAddStudent
    Private ReadOnly _accentColor As Color = Color.FromArgb(0, 85, 164)
    Private ReadOnly _grayColor As Color = Color.FromArgb(108, 117, 125)

    Private courseDictionary As New Dictionary(Of String, List(Of String))

    Public Sub New()
        InitializeComponent()
        InitializeCourseDictionary()

        For Each dept As String In courseDictionary.Keys
            cboDepartment.Items.Add(dept)
        Next
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Input_FocusEnter(sender As Object, e As EventArgs)
        Dim control As Control = TryCast(sender, Control)
        If control IsNot Nothing AndAlso control.Tag IsNot Nothing Then
            Dim underlinePanel As Panel = TryCast(control.Tag, Panel)
            If underlinePanel IsNot Nothing Then
                underlinePanel.BackColor = _accentColor
                underlinePanel.Height = 2
            End If
        End If
    End Sub

    Private Sub Input_FocusLeave(sender As Object, e As EventArgs)
        Dim control As Control = TryCast(sender, Control)
        If control IsNot Nothing AndAlso control.Tag IsNot Nothing Then
            Dim underlinePanel As Panel = TryCast(control.Tag, Panel)
            If underlinePanel IsNot Nothing Then
                underlinePanel.BackColor = _grayColor
                underlinePanel.Height = 1
            End If
        End If
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)
        cboCourse.Items.Clear()
        cboCourse.SelectedIndex = -1

        If cboDepartment.SelectedIndex > 0 Then
            Dim selectedDept As String = cboDepartment.SelectedItem.ToString()

            If courseDictionary.ContainsKey(selectedDept) Then
                cboCourse.Enabled = True
                cboCourse.Items.Add("-- Select Course --")

                For Each course As String In courseDictionary(selectedDept)
                    cboCourse.Items.Add(course)
                Next

                cboCourse.SelectedIndex = 0
            End If
        Else
            cboCourse.Enabled = False
            cboCourse.Items.Add("-- Select Department First --")
            cboCourse.SelectedIndex = 0
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtStudentNo.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           cboDepartment.SelectedIndex <= 0 OrElse
           cboCourse.SelectedIndex <= 0 OrElse
           cboYearLevel.SelectedIndex <= 0 Then
            MessageBox.Show("Please fill in all required fields:" & vbCrLf & vbCrLf &
                          "• Last Name" & vbCrLf &
                          "• First Name" & vbCrLf &
                          "• Student Number" & vbCrLf &
                          "• Email Address" & vbCrLf &
                          "• Department/College" & vbCrLf &
                          "• Course" & vbCrLf &
                          "• Year Level",
                          "Missing Information",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            Return
        End If

        If Not IsValidEmail(txtEmail.Text.Trim()) Then
            MessageBox.Show("Please enter a valid email address." & vbCrLf & vbCrLf &
                          "Example: student@example.com",
                          "Invalid Email",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Try
            Dim success As Boolean = DatabaseHelper.AddStudent(
                txtFirstName.Text.Trim(),
                txtLastName.Text.Trim(),
                txtStudentNo.Text.Trim(),
                cboCourse.SelectedItem.ToString(),
                cboYearLevel.SelectedItem.ToString(),
                txtEmail.Text.Trim()
            )

            If success Then
                Me.DialogResult = DialogResult.OK
            Else
                MessageBox.Show("Failed to add student." & vbCrLf &
                              "The student number or email might already exist.",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving: {ex.Message}",
                          "Database Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
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