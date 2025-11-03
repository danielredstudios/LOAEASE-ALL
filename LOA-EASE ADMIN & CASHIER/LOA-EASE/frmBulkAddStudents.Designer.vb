Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBulkAddStudents
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
    Friend WithEvents dgvStudents As DataGridView
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnSaveAll As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblInstructions As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim _bgColor As Color = Color.FromArgb(248, 249, 250)
        Dim _panelColor As Color = Color.White
        Dim _primaryColor As Color = Color.FromArgb(0, 123, 255)
        Dim _textColor As Color = Color.FromArgb(33, 37, 41)
        Dim _textSecondary As Color = Color.FromArgb(108, 117, 125)
        Dim _successColor As Color = Color.FromArgb(40, 167, 69)
        Dim _warningColor As Color = Color.FromArgb(255, 193, 7)
        Dim _dangerColor As Color = Color.FromArgb(220, 53, 69)
        Dim _lightGray As Color = Color.FromArgb(233, 236, 239)
        Dim _cancelColor As Color = Color.FromArgb(108, 117, 125)

        Dim titleFont As New Font("Segoe UI", 14.0F, FontStyle.Bold)
        Dim labelFont As New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Dim buttonFont As New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)

        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.dgvStudents = New System.Windows.Forms.DataGridView()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()

        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.dgvStudents, ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()

        Me.pnlHeader.BackColor = _panelColor
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 70
        Me.pnlHeader.Location = New Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New Padding(30, 0, 10, 0)

        Me.lblTitle.Text = "BULK ADD STUDENTS"
        Me.lblTitle.Font = titleFont
        Me.lblTitle.ForeColor = _textColor
        Me.lblTitle.Location = New Point(30, 24)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Name = "lblTitle"

        Me.btnClose.Text = "✕"
        Me.btnClose.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular)
        Me.btnClose.Size = New Size(45, 45)
        Me.btnClose.BackColor = Color.Transparent
        Me.btnClose.ForeColor = _textSecondary
        Me.btnClose.FlatStyle = FlatStyle.Flat
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseOverBackColor = _lightGray
        Me.btnClose.Cursor = Cursors.Hand
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler Me.btnClose.Click, AddressOf btnCancel_Click

        Me.pnlMain.BackColor = _bgColor
        Me.pnlMain.Controls.Add(Me.lblInstructions)
        Me.pnlMain.Controls.Add(Me.dgvStudents)
        Me.pnlMain.Dock = DockStyle.Fill
        Me.pnlMain.Location = New Point(0, 70)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New Padding(20)

        Me.lblInstructions.Text = "Enter student information in the table below. You can add multiple students at once. Click 'Save All Students' when done."
        Me.lblInstructions.Font = labelFont
        Me.lblInstructions.ForeColor = _textSecondary
        Me.lblInstructions.Location = New Point(20, 10)
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.MaximumSize = New Size(1160, 0)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Me.dgvStudents.Location = New Point(20, 45)
        Me.dgvStudents.Name = "dgvStudents"
        Me.dgvStudents.BackgroundColor = _panelColor
        Me.dgvStudents.BorderStyle = BorderStyle.None
        Me.dgvStudents.AllowUserToResizeRows = False
        Me.dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = _primaryColor
        Me.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        Me.dgvStudents.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        Me.dgvStudents.ColumnHeadersDefaultCellStyle.Padding = New Padding(5)
        Me.dgvStudents.EnableHeadersVisualStyles = False
        Me.dgvStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 85, 164)
        Me.dgvStudents.DefaultCellStyle.SelectionForeColor = Color.White
        Me.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = _lightGray
        Me.dgvStudents.RowTemplate.Height = 30
        Me.dgvStudents.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        Me.pnlFooter.BackColor = _panelColor
        Me.pnlFooter.Controls.Add(Me.btnSaveAll)
        Me.pnlFooter.Controls.Add(Me.btnClear)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Dock = DockStyle.Bottom
        Me.pnlFooter.Height = 75
        Me.pnlFooter.Location = New Point(0, 625)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Padding = New Padding(30, 15, 30, 15)

        Me.btnSaveAll.Text = "💾 Save All Students"
        Me.btnSaveAll.Size = New Size(170, 38)
        Me.btnSaveAll.Font = buttonFont
        Me.btnSaveAll.BackColor = _successColor
        Me.btnSaveAll.ForeColor = Color.White
        Me.btnSaveAll.FlatStyle = FlatStyle.Flat
        Me.btnSaveAll.FlatAppearance.BorderSize = 0
        Me.btnSaveAll.Cursor = Cursors.Hand
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.btnClear.Text = "🗑️ Clear All"
        Me.btnClear.Size = New Size(120, 38)
        Me.btnClear.Font = buttonFont
        Me.btnClear.BackColor = _warningColor
        Me.btnClear.ForeColor = _textColor
        Me.btnClear.FlatStyle = FlatStyle.Flat
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.Cursor = Cursors.Hand
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Size = New Size(90, 38)
        Me.btnCancel.Font = buttonFont
        Me.btnCancel.BackColor = _cancelColor
        Me.btnCancel.ForeColor = Color.White
        Me.btnCancel.FlatStyle = FlatStyle.Flat
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.Cursor = Cursors.Hand
        Me.btnCancel.DialogResult = DialogResult.Cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.Text = "Bulk Add Students"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(1200, 700)
        Me.MinimumSize = New Size(800, 500)
        Me.BackColor = _bgColor
        Me.Padding = New Padding(0)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmBulkAddStudents"

        AddHandler Me.Resize, AddressOf frmBulkAddStudents_Resize

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.dgvStudents, ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Private Sub frmBulkAddStudents_Resize(sender As Object, e As EventArgs)
        Dim rightMargin As Integer = 30
        btnCancel.Location = New Point(Me.ClientSize.Width - btnCancel.Width - rightMargin, btnCancel.Location.Y)
        btnClear.Location = New Point(btnCancel.Left - btnClear.Width - 10, btnClear.Location.Y)
        btnSaveAll.Location = New Point(btnClear.Left - btnSaveAll.Width - 10, btnSaveAll.Location.Y)
        btnClose.Location = New Point(Me.ClientSize.Width - btnClose.Width - 12, btnClose.Location.Y)
    End Sub
End Class
