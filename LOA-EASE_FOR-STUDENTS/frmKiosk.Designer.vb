<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKiosk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKiosk))
        tcKiosk = New TabControl()
        tpMain = New TabPage()
        pnlMainInput = New Panel()
        lblInstructions = New Label()
        lblCheckInPrompt = New Label()
        btnCheckIn = New Button()
        btnNewVisitor = New Button()
        tlpPurpose = New TableLayoutPanel()
        gbDocumentRequest = New GroupBox()
        chkGMC = New CheckBox()
        chkTOR = New CheckBox()
        chkDiploma = New CheckBox()
        gbPurpose = New GroupBox()
        chkClearance = New CheckBox()
        chkIsPriority = New CheckBox()
        chkDocRequest = New CheckBox()
        chkPromissory = New CheckBox()
        chkEnrollment = New CheckBox()
        chkTuition = New CheckBox()
        btnGetTicket = New Button()
        gbStudentInfo = New GroupBox()
        txtYearLevel = New TextBox()
        Label5 = New Label()
        txtCourse = New TextBox()
        Label4 = New Label()
        txtFirstName = New TextBox()
        Label3 = New Label()
        txtLastName = New TextBox()
        Label2 = New Label()
        txtStudentID = New TextBox()
        Label1 = New Label()
        tpTicket = New TabPage()
        pnlTicketResult = New Panel()
        pnlTicketCard = New Panel()
        lblMessage = New Label()
        lblAssignedCashier = New Label()
        lblAssignedCounter = New Label()
        lblQueueNumber = New Label()
        pnlHeader = New Panel()
        lblAppName = New Label()
        lblSystemName = New Label()
        pbLogo = New PictureBox()
        tcKiosk.SuspendLayout()
        tpMain.SuspendLayout()
        pnlMainInput.SuspendLayout()
        tlpPurpose.SuspendLayout()
        gbDocumentRequest.SuspendLayout()
        gbPurpose.SuspendLayout()
        gbStudentInfo.SuspendLayout()
        tpTicket.SuspendLayout()
        pnlTicketResult.SuspendLayout()
        pnlTicketCard.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(pbLogo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tcKiosk
        ' 
        tcKiosk.Appearance = TabAppearance.FlatButtons
        tcKiosk.Controls.Add(tpMain)
        tcKiosk.Controls.Add(tpTicket)
        tcKiosk.Dock = DockStyle.Fill
        tcKiosk.ItemSize = New Size(0, 1)
        tcKiosk.Location = New Point(0, 120)
        tcKiosk.Name = "tcKiosk"
        tcKiosk.SelectedIndex = 0
        tcKiosk.Size = New Size(1920, 941)
        tcKiosk.SizeMode = TabSizeMode.Fixed
        tcKiosk.TabIndex = 0
        ' 
        ' tpMain
        ' 
        tpMain.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        tpMain.Controls.Add(pnlMainInput)
        tpMain.Location = New Point(4, 5)
        tpMain.Name = "tpMain"
        tpMain.Padding = New Padding(20)
        tpMain.Size = New Size(1912, 932)
        tpMain.TabIndex = 0
        tpMain.Text = "Main"
        ' 
        ' pnlMainInput
        ' 
        pnlMainInput.Anchor = AnchorStyles.None
        pnlMainInput.BackColor = Color.White
        pnlMainInput.Controls.Add(lblInstructions)
        pnlMainInput.Controls.Add(lblCheckInPrompt)
        pnlMainInput.Controls.Add(btnCheckIn)
        pnlMainInput.Controls.Add(btnNewVisitor)
        pnlMainInput.Controls.Add(tlpPurpose)
        pnlMainInput.Controls.Add(btnGetTicket)
        pnlMainInput.Controls.Add(gbStudentInfo)
        pnlMainInput.Location = New Point(460, 91)
        pnlMainInput.Name = "pnlMainInput"
        pnlMainInput.Padding = New Padding(40)
        pnlMainInput.Size = New Size(1000, 750)
        pnlMainInput.TabIndex = 0
        ' 
        ' lblInstructions
        ' 
        lblInstructions.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblInstructions.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        lblInstructions.BorderStyle = BorderStyle.FixedSingle
        lblInstructions.Font = New Font("Poppins", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInstructions.ForeColor = Color.FromArgb(CByte(133), CByte(100), CByte(4))
        lblInstructions.Location = New Point(40, 60)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Padding = New Padding(15, 10, 15, 10)
        lblInstructions.Size = New Size(920, 90)
        lblInstructions.TabIndex = 10
        lblInstructions.Text = "📋 HOW TO USE:" & vbCrLf & " 1.  Enter Student ID  •   2.   Select Purpose  •  3.  Tap Get Ticket"
        lblInstructions.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblCheckInPrompt
        ' 
        lblCheckInPrompt.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblCheckInPrompt.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCheckInPrompt.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblCheckInPrompt.Location = New Point(40, 627)
        lblCheckInPrompt.Name = "lblCheckInPrompt"
        lblCheckInPrompt.Size = New Size(450, 30)
        lblCheckInPrompt.TabIndex = 9
        lblCheckInPrompt.Text = "Prompt Text Goes Here"
        lblCheckInPrompt.TextAlign = ContentAlignment.MiddleCenter
        lblCheckInPrompt.Visible = False
        ' 
        ' btnCheckIn
        ' 
        btnCheckIn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCheckIn.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnCheckIn.Cursor = Cursors.Hand
        btnCheckIn.FlatAppearance.BorderSize = 0
        btnCheckIn.FlatStyle = FlatStyle.Flat
        btnCheckIn.Font = New Font("Poppins", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCheckIn.ForeColor = Color.White
        btnCheckIn.Location = New Point(40, 660)
        btnCheckIn.Name = "btnCheckIn"
        btnCheckIn.Size = New Size(450, 60)
        btnCheckIn.TabIndex = 8
        btnCheckIn.Text = "📅 Check-In for Appointment"
        btnCheckIn.UseVisualStyleBackColor = False
        ' 
        ' btnNewVisitor
        ' 
        btnNewVisitor.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnNewVisitor.BackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        btnNewVisitor.Cursor = Cursors.Hand
        btnNewVisitor.FlatAppearance.BorderSize = 0
        btnNewVisitor.FlatStyle = FlatStyle.Flat
        btnNewVisitor.Font = New Font("Poppins", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewVisitor.ForeColor = Color.White
        btnNewVisitor.Location = New Point(810, 30)
        btnNewVisitor.Name = "btnNewVisitor"
        btnNewVisitor.Size = New Size(150, 40)
        btnNewVisitor.TabIndex = 7
        btnNewVisitor.Text = "👤 Visitor"
        btnNewVisitor.UseVisualStyleBackColor = False
        ' 
        ' tlpPurpose
        ' 
        tlpPurpose.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tlpPurpose.ColumnCount = 2
        tlpPurpose.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpPurpose.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpPurpose.Controls.Add(gbDocumentRequest, 1, 0)
        tlpPurpose.Controls.Add(gbPurpose, 0, 0)
        tlpPurpose.Location = New Point(40, 380)
        tlpPurpose.Name = "tlpPurpose"
        tlpPurpose.RowCount = 1
        tlpPurpose.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpPurpose.Size = New Size(920, 260)
        tlpPurpose.TabIndex = 6
        ' 
        ' gbDocumentRequest
        ' 
        gbDocumentRequest.Controls.Add(chkGMC)
        gbDocumentRequest.Controls.Add(chkTOR)
        gbDocumentRequest.Controls.Add(chkDiploma)
        gbDocumentRequest.Dock = DockStyle.Fill
        gbDocumentRequest.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        gbDocumentRequest.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        gbDocumentRequest.Location = New Point(463, 3)
        gbDocumentRequest.Margin = New Padding(3, 3, 0, 3)
        gbDocumentRequest.Name = "gbDocumentRequest"
        gbDocumentRequest.Padding = New Padding(20, 15, 20, 20)
        gbDocumentRequest.Size = New Size(457, 254)
        gbDocumentRequest.TabIndex = 3
        gbDocumentRequest.TabStop = False
        gbDocumentRequest.Text = "📄 Document Details"
        ' 
        ' chkGMC
        ' 
        chkGMC.AutoSize = True
        chkGMC.Cursor = Cursors.Hand
        chkGMC.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkGMC.Location = New Point(25, 140)
        chkGMC.Name = "chkGMC"
        chkGMC.Padding = New Padding(8, 8, 0, 8)
        chkGMC.Size = New Size(210, 46)
        chkGMC.TabIndex = 2
        chkGMC.Text = "Good Moral Certificate"
        chkGMC.UseVisualStyleBackColor = True
        ' 
        ' chkTOR
        ' 
        chkTOR.AutoSize = True
        chkTOR.Cursor = Cursors.Hand
        chkTOR.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkTOR.Location = New Point(25, 95)
        chkTOR.Name = "chkTOR"
        chkTOR.Padding = New Padding(8, 8, 0, 8)
        chkTOR.Size = New Size(246, 46)
        chkTOR.TabIndex = 1
        chkTOR.Text = "Transcript of Records (TOR)"
        chkTOR.UseVisualStyleBackColor = True
        ' 
        ' chkDiploma
        ' 
        chkDiploma.AutoSize = True
        chkDiploma.Cursor = Cursors.Hand
        chkDiploma.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkDiploma.Location = New Point(25, 50)
        chkDiploma.Name = "chkDiploma"
        chkDiploma.Padding = New Padding(8, 8, 0, 8)
        chkDiploma.Size = New Size(103, 46)
        chkDiploma.TabIndex = 0
        chkDiploma.Text = "Diploma"
        chkDiploma.UseVisualStyleBackColor = True
        ' 
        ' gbPurpose
        ' 
        gbPurpose.Controls.Add(chkClearance)
        gbPurpose.Controls.Add(chkIsPriority)
        gbPurpose.Controls.Add(chkDocRequest)
        gbPurpose.Controls.Add(chkPromissory)
        gbPurpose.Controls.Add(chkEnrollment)
        gbPurpose.Controls.Add(chkTuition)
        gbPurpose.Dock = DockStyle.Fill
        gbPurpose.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        gbPurpose.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        gbPurpose.Location = New Point(0, 3)
        gbPurpose.Margin = New Padding(0, 3, 3, 3)
        gbPurpose.Name = "gbPurpose"
        gbPurpose.Padding = New Padding(20, 15, 20, 20)
        gbPurpose.Size = New Size(457, 254)
        gbPurpose.TabIndex = 1
        gbPurpose.TabStop = False
        gbPurpose.Text = "🎯 Purpose of Visit"
        ' 
        ' chkClearance
        ' 
        chkClearance.AutoSize = True
        chkClearance.Cursor = Cursors.Hand
        chkClearance.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkClearance.Location = New Point(240, 95)
        chkClearance.Name = "chkClearance"
        chkClearance.Padding = New Padding(8, 8, 0, 8)
        chkClearance.Size = New Size(179, 46)
        chkClearance.TabIndex = 5
        chkClearance.Text = "Clearance Signing"
        chkClearance.UseVisualStyleBackColor = True
        ' 
        ' chkIsPriority
        ' 
        chkIsPriority.AutoSize = True
        chkIsPriority.Cursor = Cursors.Hand
        chkIsPriority.Font = New Font("Poppins", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        chkIsPriority.ForeColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        chkIsPriority.Location = New Point(25, 185)
        chkIsPriority.Name = "chkIsPriority"
        chkIsPriority.Padding = New Padding(8, 8, 0, 8)
        chkIsPriority.Size = New Size(254, 46)
        chkIsPriority.TabIndex = 4
        chkIsPriority.Text = "⭐ Priority (PWD, Senior, etc.)"
        chkIsPriority.UseVisualStyleBackColor = True
        ' 
        ' chkDocRequest
        ' 
        chkDocRequest.AutoSize = True
        chkDocRequest.Cursor = Cursors.Hand
        chkDocRequest.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkDocRequest.Location = New Point(25, 140)
        chkDocRequest.Name = "chkDocRequest"
        chkDocRequest.Padding = New Padding(8, 8, 0, 8)
        chkDocRequest.Size = New Size(182, 46)
        chkDocRequest.TabIndex = 3
        chkDocRequest.Text = "Document Request"
        chkDocRequest.UseVisualStyleBackColor = True
        ' 
        ' chkPromissory
        ' 
        chkPromissory.AutoSize = True
        chkPromissory.Cursor = Cursors.Hand
        chkPromissory.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkPromissory.Location = New Point(240, 50)
        chkPromissory.Name = "chkPromissory"
        chkPromissory.Padding = New Padding(8, 8, 0, 8)
        chkPromissory.Size = New Size(162, 46)
        chkPromissory.TabIndex = 2
        chkPromissory.Text = "Promissory Note"
        chkPromissory.UseVisualStyleBackColor = True
        ' 
        ' chkEnrollment
        ' 
        chkEnrollment.AutoSize = True
        chkEnrollment.Cursor = Cursors.Hand
        chkEnrollment.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkEnrollment.Location = New Point(25, 95)
        chkEnrollment.Name = "chkEnrollment"
        chkEnrollment.Padding = New Padding(8, 8, 0, 8)
        chkEnrollment.Size = New Size(190, 46)
        chkEnrollment.TabIndex = 1
        chkEnrollment.Text = "Enrollment Concern"
        chkEnrollment.UseVisualStyleBackColor = True
        ' 
        ' chkTuition
        ' 
        chkTuition.AutoSize = True
        chkTuition.Cursor = Cursors.Hand
        chkTuition.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkTuition.Location = New Point(25, 50)
        chkTuition.Name = "chkTuition"
        chkTuition.Padding = New Padding(8, 8, 0, 8)
        chkTuition.Size = New Size(160, 46)
        chkTuition.TabIndex = 0
        chkTuition.Text = "Tuition Payment"
        chkTuition.UseVisualStyleBackColor = True
        ' 
        ' btnGetTicket
        ' 
        btnGetTicket.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnGetTicket.BackColor = Color.FromArgb(CByte(255), CByte(199), CByte(44))
        btnGetTicket.Cursor = Cursors.Hand
        btnGetTicket.FlatAppearance.BorderSize = 0
        btnGetTicket.FlatStyle = FlatStyle.Flat
        btnGetTicket.Font = New Font("Poppins", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGetTicket.ForeColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        btnGetTicket.Location = New Point(510, 660)
        btnGetTicket.Name = "btnGetTicket"
        btnGetTicket.Size = New Size(450, 60)
        btnGetTicket.TabIndex = 2
        btnGetTicket.Text = "🎫 GET TICKET"
        btnGetTicket.UseVisualStyleBackColor = False
        ' 
        ' gbStudentInfo
        ' 
        gbStudentInfo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        gbStudentInfo.Controls.Add(txtYearLevel)
        gbStudentInfo.Controls.Add(Label5)
        gbStudentInfo.Controls.Add(txtCourse)
        gbStudentInfo.Controls.Add(Label4)
        gbStudentInfo.Controls.Add(txtFirstName)
        gbStudentInfo.Controls.Add(Label3)
        gbStudentInfo.Controls.Add(txtLastName)
        gbStudentInfo.Controls.Add(Label2)
        gbStudentInfo.Controls.Add(txtStudentID)
        gbStudentInfo.Controls.Add(Label1)
        gbStudentInfo.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        gbStudentInfo.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        gbStudentInfo.Location = New Point(40, 165)
        gbStudentInfo.Name = "gbStudentInfo"
        gbStudentInfo.Padding = New Padding(20, 15, 20, 20)
        gbStudentInfo.Size = New Size(920, 285)
        gbStudentInfo.TabIndex = 0
        gbStudentInfo.TabStop = False
        gbStudentInfo.Text = "👨‍🎓 Student Information"
        ' 
        ' txtYearLevel
        ' 
        txtYearLevel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtYearLevel.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtYearLevel.BorderStyle = BorderStyle.FixedSingle
        txtYearLevel.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtYearLevel.Location = New Point(160, 230)
        txtYearLevel.Name = "txtYearLevel"
        txtYearLevel.ReadOnly = True
        txtYearLevel.Size = New Size(740, 29)
        txtYearLevel.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(25, 232)
        Label5.Name = "Label5"
        Label5.Size = New Size(89, 26)
        Label5.TabIndex = 8
        Label5.Text = "Year Level:"
        ' 
        ' txtCourse
        ' 
        txtCourse.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCourse.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtCourse.BorderStyle = BorderStyle.FixedSingle
        txtCourse.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtCourse.Location = New Point(160, 185)
        txtCourse.Name = "txtCourse"
        txtCourse.ReadOnly = True
        txtCourse.Size = New Size(740, 29)
        txtCourse.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(25, 187)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 26)
        Label4.TabIndex = 6
        Label4.Text = "Course:"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFirstName.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtFirstName.BorderStyle = BorderStyle.FixedSingle
        txtFirstName.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFirstName.Location = New Point(160, 140)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.ReadOnly = True
        txtFirstName.Size = New Size(740, 29)
        txtFirstName.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(25, 142)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 26)
        Label3.TabIndex = 4
        Label3.Text = "First Name:"
        ' 
        ' txtLastName
        ' 
        txtLastName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLastName.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        txtLastName.BorderStyle = BorderStyle.FixedSingle
        txtLastName.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLastName.Location = New Point(160, 95)
        txtLastName.Name = "txtLastName"
        txtLastName.ReadOnly = True
        txtLastName.Size = New Size(740, 29)
        txtLastName.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(25, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 26)
        Label2.TabIndex = 2
        Label2.Text = "Last Name:"
        ' 
        ' txtStudentID
        ' 
        txtStudentID.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtStudentID.BackColor = Color.White
        txtStudentID.BorderStyle = BorderStyle.FixedSingle
        txtStudentID.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtStudentID.Location = New Point(160, 50)
        txtStudentID.Name = "txtStudentID"
        txtStudentID.Size = New Size(740, 29)
        txtStudentID.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 26)
        Label1.TabIndex = 0
        Label1.Text = "Student ID:"
        ' 
        ' tpTicket
        ' 
        tpTicket.BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        tpTicket.Controls.Add(pnlTicketResult)
        tpTicket.Location = New Point(4, 5)
        tpTicket.Name = "tpTicket"
        tpTicket.Padding = New Padding(20)
        tpTicket.Size = New Size(1912, 951)
        tpTicket.TabIndex = 1
        tpTicket.Text = "Ticket"
        ' 
        ' pnlTicketResult
        ' 
        pnlTicketResult.Anchor = AnchorStyles.None
        pnlTicketResult.BackColor = Color.Transparent
        pnlTicketResult.Controls.Add(pnlTicketCard)
        pnlTicketResult.Location = New Point(456, 175)
        pnlTicketResult.Name = "pnlTicketResult"
        pnlTicketResult.Size = New Size(1000, 600)
        pnlTicketResult.TabIndex = 0
        ' 
        ' pnlTicketCard
        ' 
        pnlTicketCard.Anchor = AnchorStyles.None
        pnlTicketCard.BackColor = Color.White
        pnlTicketCard.Controls.Add(lblMessage)
        pnlTicketCard.Controls.Add(lblAssignedCashier)
        pnlTicketCard.Controls.Add(lblAssignedCounter)
        pnlTicketCard.Controls.Add(lblQueueNumber)
        pnlTicketCard.Location = New Point(100, 50)
        pnlTicketCard.Name = "pnlTicketCard"
        pnlTicketCard.Padding = New Padding(40)
        pnlTicketCard.Size = New Size(800, 500)
        pnlTicketCard.TabIndex = 2
        ' 
        ' lblMessage
        ' 
        lblMessage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblMessage.Font = New Font("Poppins", 13F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblMessage.ForeColor = Color.DimGray
        lblMessage.Location = New Point(40, 400)
        lblMessage.Name = "lblMessage"
        lblMessage.Padding = New Padding(20, 0, 20, 0)
        lblMessage.Size = New Size(720, 60)
        lblMessage.TabIndex = 4
        lblMessage.Text = "Please proceed to your assigned counter. Your number will be called shortly."
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAssignedCashier
        ' 
        lblAssignedCashier.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAssignedCashier.Font = New Font("Poppins", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAssignedCashier.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblAssignedCashier.Location = New Point(40, 330)
        lblAssignedCashier.Name = "lblAssignedCashier"
        lblAssignedCashier.Size = New Size(720, 50)
        lblAssignedCashier.TabIndex = 3
        lblAssignedCashier.Text = "👤 Cashier: John Doe"
        lblAssignedCashier.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAssignedCounter
        ' 
        lblAssignedCounter.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAssignedCounter.Font = New Font("Poppins", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAssignedCounter.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        lblAssignedCounter.Location = New Point(40, 280)
        lblAssignedCounter.Name = "lblAssignedCounter"
        lblAssignedCounter.Size = New Size(720, 50)
        lblAssignedCounter.TabIndex = 2
        lblAssignedCounter.Text = ChrW(55358) & ChrW(56991) & " Counter: Cashier 1"
        lblAssignedCounter.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblQueueNumber
        ' 
        lblQueueNumber.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblQueueNumber.Font = New Font("Poppins", 56F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQueueNumber.ForeColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        lblQueueNumber.Location = New Point(40, 60)
        lblQueueNumber.Name = "lblQueueNumber"
        lblQueueNumber.Size = New Size(720, 200)
        lblQueueNumber.TabIndex = 0
        lblQueueNumber.Text = "CCS-0926-001"
        lblQueueNumber.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(0), CByte(41), CByte(82))
        pnlHeader.Controls.Add(lblAppName)
        pnlHeader.Controls.Add(lblSystemName)
        pnlHeader.Controls.Add(pbLogo)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(40, 5, 40, 5)
        pnlHeader.Size = New Size(1920, 60)
        pnlHeader.TabIndex = 2
        ' 
        ' lblAppName
        ' 
        lblAppName.AutoSize = True
        lblAppName.Font = New Font("Poppins", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppName.ForeColor = Color.FromArgb(CByte(255), CByte(199), CByte(44))
        lblAppName.Location = New Point(145, 55)
        lblAppName.Name = "lblAppName"
        lblAppName.Size = New Size(220, 67)
        lblAppName.TabIndex = 2
        lblAppName.Text = "LOA-EASE"
        ' 
        ' lblSystemName
        ' 
        lblSystemName.AutoSize = True
        lblSystemName.Font = New Font("Poppins", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSystemName.ForeColor = Color.White
        lblSystemName.Location = New Point(150, 20)
        lblSystemName.Name = "lblSystemName"
        lblSystemName.Size = New Size(379, 36)
        lblSystemName.TabIndex = 1
        lblSystemName.Text = "Lyceum of Alabang Queuing System"
        ' 
        ' pbLogo
        ' 
        pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), Image)
        pbLogo.Location = New Point(40, 20)
        pbLogo.Name = "pbLogo"
        pbLogo.Size = New Size(90, 90)
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom
        pbLogo.TabIndex = 0
        pbLogo.TabStop = False
        ' 
        ' frmKiosk
        ' 
        AutoScaleDimensions = New SizeF(13F, 37F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(0), CByte(51), CByte(102))
        ClientSize = New Size(1920, 1061)
        Controls.Add(tcKiosk)
        Controls.Add(pnlHeader)
        Font = New Font("Poppins", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmKiosk"
        Text = "LOA-EASE Kiosk"
        WindowState = FormWindowState.Maximized
        tcKiosk.ResumeLayout(False)
        tpMain.ResumeLayout(False)
        pnlMainInput.ResumeLayout(False)
        tlpPurpose.ResumeLayout(False)
        gbDocumentRequest.ResumeLayout(False)
        gbDocumentRequest.PerformLayout()
        gbPurpose.ResumeLayout(False)
        gbPurpose.PerformLayout()
        gbStudentInfo.ResumeLayout(False)
        gbStudentInfo.PerformLayout()
        tpTicket.ResumeLayout(False)
        pnlTicketResult.ResumeLayout(False)
        pnlTicketCard.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(pbLogo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tcKiosk As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents pnlMainInput As Panel
    Friend WithEvents gbStudentInfo As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStudentID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCourse As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtYearLevel As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents gbPurpose As GroupBox
    Friend WithEvents chkTuition As CheckBox
    Friend WithEvents chkDocRequest As CheckBox
    Friend WithEvents chkPromissory As CheckBox
    Friend WithEvents chkEnrollment As CheckBox
    Friend WithEvents chkIsPriority As CheckBox
    Friend WithEvents btnGetTicket As Button
    Friend WithEvents gbDocumentRequest As GroupBox
    Friend WithEvents chkGMC As CheckBox
    Friend WithEvents chkTOR As CheckBox
    Friend WithEvents chkDiploma As CheckBox
    Friend WithEvents tpTicket As TabPage
    Friend WithEvents pnlTicketResult As Panel
    Friend WithEvents lblQueueNumber As Label
    Friend WithEvents lblAssignedCounter As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblAssignedCashier As Label
    Friend WithEvents tlpPurpose As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblSystemName As Label
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents pnlTicketCard As Panel
    Friend WithEvents btnNewVisitor As Button
    Friend WithEvents chkClearance As CheckBox
    Friend WithEvents btnCheckIn As Button
    Friend WithEvents lblCheckInPrompt As Label
    Friend WithEvents lblInstructions As Label
End Class
