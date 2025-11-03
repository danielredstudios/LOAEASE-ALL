Imports MySql.Data.MySqlClient
Imports System.Data
Imports BCrypt.Net

Public Class DatabaseHelper
    Private Shared ReadOnly ConnectionString As String = "Server=localhost;Database=loa_ease_queuing_experiemental;User ID=root;Password=;"

    Public Shared Function GetConnectionString() As String
        Return ConnectionString
    End Function

    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

    Public Shared Function GetStudentInfo(studentNumber As String) As DataRow
        Using conn As New MySqlConnection(ConnectionString)
            Try
                Dim number_with_c As String = studentNumber
                Dim number_without_c As String = studentNumber

                If Not studentNumber.StartsWith("C", StringComparison.OrdinalIgnoreCase) Then
                    number_with_c = "C" & studentNumber
                Else
                    number_without_c = studentNumber.Substring(1)
                End If

                conn.Open()
                Dim query As String = "SELECT last_name, first_name, course FROM students WHERE student_number = @num1 OR student_number = @num2"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@num1", number_with_c)
                cmd.Parameters.AddWithValue("@num2", number_without_c)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                End If
            Catch ex As Exception
                Throw New Exception("Unable to connect to the system. Please ask staff for help.")
            End Try
        End Using
        Return Nothing
    End Function
End Class
