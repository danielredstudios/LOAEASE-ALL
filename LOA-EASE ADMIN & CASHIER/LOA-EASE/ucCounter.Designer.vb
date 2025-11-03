<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCounter
    Inherits System.Windows.Forms.UserControl

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblCounterName = New Label()
        lblQueueNumber = New Label()
        lblStatusBadge = New Label()
        SuspendLayout()
        ' 
        ' lblCounterName
        ' 
        lblCounterName.Dock = DockStyle.Top
        lblCounterName.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        lblCounterName.ForeColor = Color.FromArgb(CByte(0), CByte(85), CByte(164))
        lblCounterName.Location = New Point(0, 0)
        lblCounterName.Name = "lblCounterName"
        lblCounterName.Padding = New Padding(9, 11, 9, 4)
        lblCounterName.Size = New Size(350, 60)
        lblCounterName.TabIndex = 0
        lblCounterName.Text = "Counter 1"
        lblCounterName.TextAlign = ContentAlignment.MiddleCenter
        lblCounterName.UseMnemonic = False
        lblCounterName.UseCompatibleTextRendering = False
        ' 
        ' lblQueueNumber
        ' 
        lblQueueNumber.Dock = DockStyle.Fill
        lblQueueNumber.Font = New Font("Segoe UI", 52.0F, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        lblQueueNumber.ForeColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        lblQueueNumber.Location = New Point(0, 60)
        lblQueueNumber.Name = "lblQueueNumber"
        lblQueueNumber.Padding = New Padding(9, 8, 9, 8)
        lblQueueNumber.Size = New Size(350, 165)
        lblQueueNumber.TabIndex = 1
        lblQueueNumber.Text = "A-001"
        lblQueueNumber.TextAlign = ContentAlignment.MiddleCenter
        lblQueueNumber.UseMnemonic = False
        lblQueueNumber.UseCompatibleTextRendering = False
        ' 
        ' lblStatusBadge
        ' 
        lblStatusBadge.Anchor = AnchorStyles.None
        lblStatusBadge.AutoSize = False
        lblStatusBadge.BackColor = Color.Transparent
        lblStatusBadge.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        lblStatusBadge.ForeColor = Color.White
        lblStatusBadge.Location = New Point(122, 188)
        lblStatusBadge.Name = "lblStatusBadge"
        lblStatusBadge.Size = New Size(105, 26)
        lblStatusBadge.TabIndex = 2
        lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter
        lblStatusBadge.Visible = False
        lblStatusBadge.UseMnemonic = False
        lblStatusBadge.UseCompatibleTextRendering = False
        ' 
        ' ucCounter
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(lblStatusBadge)
        Controls.Add(lblQueueNumber)
        Controls.Add(lblCounterName)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Margin = New Padding(9, 8, 9, 8)
        Name = "ucCounter"
        Size = New Size(350, 225)
        ResumeLayout(False)

    End Sub

    Friend WithEvents lblCounterName As Label
    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents lblStatusBadge As Label
End Class