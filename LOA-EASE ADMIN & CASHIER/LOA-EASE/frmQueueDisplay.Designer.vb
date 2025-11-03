<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQueueDisplay
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueueDisplay))
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlServingSection = New System.Windows.Forms.Panel()
        Me.flpNowServing = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlServingHeader = New System.Windows.Forms.Panel()
        Me.lblServingTitle = New System.Windows.Forms.Label()
        Me.pnlWaitingSection = New System.Windows.Forms.Panel()
        Me.flpWaiting = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlQueueHeaderWrapper = New System.Windows.Forms.Panel()
        Me.lblQueueHeader = New System.Windows.Forms.Label()
        Me.lblQueueCount = New System.Windows.Forms.Label()
        Me.pnlBrandingHeader = New System.Windows.Forms.Panel()
        Me.lblBrandSubtitle = New System.Windows.Forms.Label()
        Me.lblBrandTitle = New System.Windows.Forms.Label()
        Me.pnlBrandDivider = New System.Windows.Forms.Panel()
        Me.tlpMain.SuspendLayout()
        Me.pnlServingSection.SuspendLayout()
        Me.pnlServingHeader.SuspendLayout()
        Me.pnlWaitingSection.SuspendLayout()
        Me.pnlQueueHeaderWrapper.SuspendLayout()
        Me.pnlBrandingHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 3000
        '
        'tlpMain
        '
        Me.tlpMain.BackColor = Color.Transparent
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.67!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpMain.Controls.Add(Me.pnlServingSection, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnlWaitingSection, 1, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.Padding = New System.Windows.Forms.Padding(20)
        Me.tlpMain.RowCount = 1
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1920, 1080)
        Me.tlpMain.TabIndex = 0
        '
        'pnlServingSection
        '
        Me.pnlServingSection.BackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.pnlServingSection.Controls.Add(Me.flpNowServing)
        Me.pnlServingSection.Controls.Add(Me.pnlServingHeader)
        Me.pnlServingSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlServingSection.Location = New System.Drawing.Point(23, 23)
        Me.pnlServingSection.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.pnlServingSection.Name = "pnlServingSection"
        Me.pnlServingSection.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlServingSection.Size = New System.Drawing.Size(1227, 1034)
        Me.pnlServingSection.TabIndex = 0
        '
        'flpNowServing
        '
        Me.flpNowServing.BackColor = Color.Transparent
        Me.flpNowServing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpNowServing.Location = New System.Drawing.Point(30, 130)
        Me.flpNowServing.Name = "flpNowServing"
        Me.flpNowServing.Padding = New System.Windows.Forms.Padding(10)
        Me.flpNowServing.Size = New System.Drawing.Size(1167, 874)
        Me.flpNowServing.TabIndex = 1
        '
        'pnlServingHeader
        '
        Me.pnlServingHeader.BackColor = Color.Transparent
        Me.pnlServingHeader.Controls.Add(Me.lblServingTitle)
        Me.pnlServingHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlServingHeader.Location = New System.Drawing.Point(30, 30)
        Me.pnlServingHeader.Name = "pnlServingHeader"
        Me.pnlServingHeader.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.pnlServingHeader.Size = New System.Drawing.Size(1167, 100)
        Me.pnlServingHeader.TabIndex = 0
        '
        'lblServingTitle
        '
        Me.lblServingTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblServingTitle.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServingTitle.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.lblServingTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblServingTitle.Name = "lblServingTitle"
        Me.lblServingTitle.Size = New System.Drawing.Size(1167, 80)
        Me.lblServingTitle.TabIndex = 0
        Me.lblServingTitle.Text = "NOW SERVING"
        Me.lblServingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblServingTitle.UseMnemonic = False
        Me.lblServingTitle.UseCompatibleTextRendering = False
        '
        'pnlWaitingSection
        '
        Me.pnlWaitingSection.BackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.pnlWaitingSection.Controls.Add(Me.flpWaiting)
        Me.pnlWaitingSection.Controls.Add(Me.pnlQueueHeaderWrapper)
        Me.pnlWaitingSection.Controls.Add(Me.pnlBrandingHeader)
        Me.pnlWaitingSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWaitingSection.Location = New System.Drawing.Point(1263, 23)
        Me.pnlWaitingSection.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.pnlWaitingSection.Name = "pnlWaitingSection"
        Me.pnlWaitingSection.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlWaitingSection.Size = New System.Drawing.Size(634, 1034)
        Me.pnlWaitingSection.TabIndex = 1
        '
        'flpWaiting
        '
        Me.flpWaiting.AutoScroll = True
        Me.flpWaiting.BackColor = Color.Transparent
        Me.flpWaiting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpWaiting.Location = New System.Drawing.Point(30, 280)
        Me.flpWaiting.Name = "flpWaiting"
        Me.flpWaiting.Padding = New System.Windows.Forms.Padding(10)
        Me.flpWaiting.Size = New System.Drawing.Size(574, 724)
        Me.flpWaiting.TabIndex = 2
        '
        'pnlQueueHeaderWrapper
        '
        Me.pnlQueueHeaderWrapper.BackColor = Color.Transparent
        Me.pnlQueueHeaderWrapper.Controls.Add(Me.lblQueueHeader)
        Me.pnlQueueHeaderWrapper.Controls.Add(Me.lblQueueCount)
        Me.pnlQueueHeaderWrapper.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlQueueHeaderWrapper.Location = New System.Drawing.Point(30, 180)
        Me.pnlQueueHeaderWrapper.Name = "pnlQueueHeaderWrapper"
        Me.pnlQueueHeaderWrapper.Padding = New System.Windows.Forms.Padding(10, 15, 10, 15)
        Me.pnlQueueHeaderWrapper.Size = New System.Drawing.Size(574, 100)
        Me.pnlQueueHeaderWrapper.TabIndex = 3
        '
        'lblQueueHeader
        '
        Me.lblQueueHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblQueueHeader.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.lblQueueHeader.Location = New System.Drawing.Point(10, 15)
        Me.lblQueueHeader.Name = "lblQueueHeader"
        Me.lblQueueHeader.Size = New System.Drawing.Size(554, 50)
        Me.lblQueueHeader.TabIndex = 1
        Me.lblQueueHeader.Text = "WAITING IN QUEUE"
        Me.lblQueueHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblQueueHeader.UseMnemonic = False
        Me.lblQueueHeader.UseCompatibleTextRendering = False
        '
        'lblQueueCount
        '
        Me.lblQueueCount.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblQueueCount.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueCount.ForeColor = Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblQueueCount.Location = New System.Drawing.Point(10, 65)
        Me.lblQueueCount.Name = "lblQueueCount"
        Me.lblQueueCount.Size = New System.Drawing.Size(554, 20)
        Me.lblQueueCount.TabIndex = 2
        Me.lblQueueCount.Text = "0 customers waiting"
        Me.lblQueueCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblQueueCount.UseMnemonic = False
        Me.lblQueueCount.UseCompatibleTextRendering = False
        '
        'pnlBrandingHeader
        '
        Me.pnlBrandingHeader.BackColor = Color.Transparent
        Me.pnlBrandingHeader.Controls.Add(Me.lblBrandSubtitle)
        Me.pnlBrandingHeader.Controls.Add(Me.lblBrandTitle)
        Me.pnlBrandingHeader.Controls.Add(Me.pnlBrandDivider)
        Me.pnlBrandingHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrandingHeader.Location = New System.Drawing.Point(30, 30)
        Me.pnlBrandingHeader.Name = "pnlBrandingHeader"
        Me.pnlBrandingHeader.Padding = New System.Windows.Forms.Padding(10, 10, 10, 20)
        Me.pnlBrandingHeader.Size = New System.Drawing.Size(574, 150)
        Me.pnlBrandingHeader.TabIndex = 0
        '
        'lblBrandSubtitle
        '
        Me.lblBrandSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBrandSubtitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandSubtitle.ForeColor = Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.lblBrandSubtitle.Location = New System.Drawing.Point(10, 70)
        Me.lblBrandSubtitle.Name = "lblBrandSubtitle"
        Me.lblBrandSubtitle.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lblBrandSubtitle.Size = New System.Drawing.Size(554, 40)
        Me.lblBrandSubtitle.TabIndex = 1
        Me.lblBrandSubtitle.Text = "Lyceum of Alabang Queuing System"
        Me.lblBrandSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblBrandSubtitle.UseMnemonic = False
        Me.lblBrandSubtitle.UseCompatibleTextRendering = False
        '
        'lblBrandTitle
        '
        Me.lblBrandTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBrandTitle.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandTitle.ForeColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.lblBrandTitle.Location = New System.Drawing.Point(10, 10)
        Me.lblBrandTitle.Name = "lblBrandTitle"
        Me.lblBrandTitle.Size = New System.Drawing.Size(554, 60)
        Me.lblBrandTitle.TabIndex = 0
        Me.lblBrandTitle.Text = "LOA-EASE"
        Me.lblBrandTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblBrandTitle.UseMnemonic = False
        Me.lblBrandTitle.UseCompatibleTextRendering = False
        '
        'pnlBrandDivider
        '
        Me.pnlBrandDivider.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.pnlBrandDivider.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBrandDivider.Location = New System.Drawing.Point(10, 127)
        Me.pnlBrandDivider.Name = "pnlBrandDivider"
        Me.pnlBrandDivider.Size = New System.Drawing.Size(554, 3)
        Me.pnlBrandDivider.TabIndex = 2
        '
        'frmQueueDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.tlpMain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(1024, 768)
        Me.Name = "frmQueueDisplay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Live Queue Display - LOA-EASE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlpMain.ResumeLayout(False)
        Me.pnlServingSection.ResumeLayout(False)
        Me.pnlServingHeader.ResumeLayout(False)
        Me.pnlWaitingSection.ResumeLayout(False)
        Me.pnlQueueHeaderWrapper.ResumeLayout(False)
        Me.pnlBrandingHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RefreshTimer As Timer
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents pnlServingSection As Panel
    Friend WithEvents pnlServingHeader As Panel
    Friend WithEvents lblServingTitle As Label
    Friend WithEvents flpNowServing As FlowLayoutPanel
    Friend WithEvents pnlWaitingSection As Panel
    Friend WithEvents pnlBrandingHeader As Panel
    Friend WithEvents lblBrandTitle As Label
    Friend WithEvents lblBrandSubtitle As Label
    Friend WithEvents pnlBrandDivider As Panel
    Friend WithEvents pnlQueueHeaderWrapper As Panel
    Friend WithEvents lblQueueHeader As Label
    Friend WithEvents lblQueueCount As Label
    Friend WithEvents flpWaiting As FlowLayoutPanel
End Class