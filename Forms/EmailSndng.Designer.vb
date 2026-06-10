<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSndng
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailSndng))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSend = New System.Windows.Forms.ToolStripButton()
        Me.tsbClr = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.lbltxt = New System.Windows.Forms.Label()
        Me.txtCust = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgCust = New System.Windows.Forms.DataGridView()
        Me.CustCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCustNm = New System.Windows.Forms.DataGridView()
        Me.lblCustGrp = New System.Windows.Forms.Label()
        Me.btnGrpAdd = New System.Windows.Forms.Button()
        Me.cmbCustGrp = New System.Windows.Forms.ComboBox()
        Me.btnOpn = New System.Windows.Forms.Button()
        Me.btnAtch = New System.Windows.Forms.Button()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtAtch1 = New System.Windows.Forms.TextBox()
        Me.txtAtch2 = New System.Windows.Forms.TextBox()
        Me.txtAtch3 = New System.Windows.Forms.TextBox()
        Me.opnfd = New System.Windows.Forms.OpenFileDialog()
        Me.txtAtch4 = New System.Windows.Forms.TextBox()
        Me.txtAtch5 = New System.Windows.Forms.TextBox()
        Me.txtAtch6 = New System.Windows.Forms.TextBox()
        Me.txtAtch7 = New System.Windows.Forms.TextBox()
        Me.BtnRmv1 = New System.Windows.Forms.Button()
        Me.BtnRmv2 = New System.Windows.Forms.Button()
        Me.BtnRmv3 = New System.Windows.Forms.Button()
        Me.BtnRmv4 = New System.Windows.Forms.Button()
        Me.BtnRmv5 = New System.Windows.Forms.Button()
        Me.BtnRmv6 = New System.Windows.Forms.Button()
        Me.BtnRmv7 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbLoyaltyCust = New System.Windows.Forms.RadioButton()
        Me.rdbCust = New System.Windows.Forms.RadioButton()
        Me.HTMLT = New onlyconnect.HtmlEditor()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbold = New System.Windows.Forms.ToolStripButton()
        Me.tsitalic = New System.Windows.Forms.ToolStripButton()
        Me.tsunder = New System.Windows.Forms.ToolStripButton()
        Me.tsfont = New System.Windows.Forms.ToolStripButton()
        Me.tscolor = New System.Windows.Forms.ToolStripButton()
        Me.tsjl = New System.Windows.Forms.ToolStripButton()
        Me.tsjc = New System.Windows.Forms.ToolStripButton()
        Me.tsjr = New System.Windows.Forms.ToolStripButton()
        Me.tsbul = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCustNm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSend, Me.tsbClr, Me.tsbExit, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1321, 36)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsbSend
        '
        Me.tsbSend.AutoSize = False
        Me.tsbSend.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSend.Image = CType(resources.GetObject("tsbSend.Image"), System.Drawing.Image)
        Me.tsbSend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSend.Name = "tsbSend"
        Me.tsbSend.Size = New System.Drawing.Size(80, 33)
        Me.tsbSend.Text = "&Send"
        '
        'tsbClr
        '
        Me.tsbClr.AutoSize = False
        Me.tsbClr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClr.Image = CType(resources.GetObject("tsbClr.Image"), System.Drawing.Image)
        Me.tsbClr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClr.Name = "tsbClr"
        Me.tsbClr.Size = New System.Drawing.Size(80, 33)
        Me.tsbClr.Text = "&Clear"
        '
        'tsbExit
        '
        Me.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExit.AutoSize = False
        Me.tsbExit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbExit.Image = CType(resources.GetObject("tsbExit.Image"), System.Drawing.Image)
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(80, 33)
        Me.tsbExit.Text = "E&xit"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Indigo
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(700, 33)
        Me.ToolStripLabel1.Text = "Email Sending"
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust.Location = New System.Drawing.Point(16, 374)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(88, 16)
        Me.lblCust.TabIndex = 2
        Me.lblCust.Text = "Customer :"
        '
        'lbltxt
        '
        Me.lbltxt.AutoSize = True
        Me.lbltxt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt.Location = New System.Drawing.Point(13, 55)
        Me.lbltxt.Name = "lbltxt"
        Me.lbltxt.Size = New System.Drawing.Size(56, 16)
        Me.lbltxt.TabIndex = 3
        Me.lbltxt.Text = "Text :"
        '
        'txtCust
        '
        Me.txtCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCust.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(159, 368)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(367, 22)
        Me.txtCust.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(532, 361)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 29)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgCust
        '
        Me.dgCust.AllowUserToAddRows = False
        Me.dgCust.AllowUserToResizeColumns = False
        Me.dgCust.AllowUserToResizeRows = False
        Me.dgCust.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgCust.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCust.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCust.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCust.ColumnHeadersHeight = 27
        Me.dgCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustCode, Me.CustName, Me.Email})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCust.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCust.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCust.EnableHeadersVisualStyles = False
        Me.dgCust.Location = New System.Drawing.Point(159, 442)
        Me.dgCust.Name = "dgCust"
        Me.dgCust.ReadOnly = True
        Me.dgCust.RowHeadersVisible = False
        Me.dgCust.RowHeadersWidth = 35
        Me.dgCust.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCust.Size = New System.Drawing.Size(484, 122)
        Me.dgCust.TabIndex = 6
        '
        'CustCode
        '
        Me.CustCode.HeaderText = "Code"
        Me.CustCode.Name = "CustCode"
        Me.CustCode.ReadOnly = True
        Me.CustCode.Visible = False
        '
        'CustName
        '
        Me.CustName.HeaderText = "Customer Name"
        Me.CustName.Name = "CustName"
        Me.CustName.ReadOnly = True
        Me.CustName.Width = 270
        '
        'Email
        '
        Me.Email.HeaderText = "Email ID"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 200
        '
        'dgCustNm
        '
        Me.dgCustNm.AllowUserToAddRows = False
        Me.dgCustNm.AllowUserToDeleteRows = False
        Me.dgCustNm.AllowUserToResizeColumns = False
        Me.dgCustNm.AllowUserToResizeRows = False
        Me.dgCustNm.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgCustNm.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCustNm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustNm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCustNm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustNm.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCustNm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCustNm.EnableHeadersVisualStyles = False
        Me.dgCustNm.Location = New System.Drawing.Point(201, 393)
        Me.dgCustNm.Name = "dgCustNm"
        Me.dgCustNm.RowHeadersVisible = False
        Me.dgCustNm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustNm.Size = New System.Drawing.Size(638, 204)
        Me.dgCustNm.TabIndex = 7
        Me.dgCustNm.Visible = False
        '
        'lblCustGrp
        '
        Me.lblCustGrp.AutoSize = True
        Me.lblCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustGrp.Location = New System.Drawing.Point(16, 399)
        Me.lblCustGrp.Name = "lblCustGrp"
        Me.lblCustGrp.Size = New System.Drawing.Size(136, 16)
        Me.lblCustGrp.TabIndex = 8
        Me.lblCustGrp.Text = "Customer Group :"
        '
        'btnGrpAdd
        '
        Me.btnGrpAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnGrpAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrpAdd.ForeColor = System.Drawing.Color.Black
        Me.btnGrpAdd.Location = New System.Drawing.Point(533, 395)
        Me.btnGrpAdd.Name = "btnGrpAdd"
        Me.btnGrpAdd.Size = New System.Drawing.Size(87, 27)
        Me.btnGrpAdd.TabIndex = 10
        Me.btnGrpAdd.Text = "Add"
        Me.btnGrpAdd.UseVisualStyleBackColor = False
        '
        'cmbCustGrp
        '
        Me.cmbCustGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustGrp.FormattingEnabled = True
        Me.cmbCustGrp.Location = New System.Drawing.Point(159, 396)
        Me.cmbCustGrp.Name = "cmbCustGrp"
        Me.cmbCustGrp.Size = New System.Drawing.Size(364, 24)
        Me.cmbCustGrp.TabIndex = 11
        '
        'btnOpn
        '
        Me.btnOpn.BackColor = System.Drawing.Color.Transparent
        Me.btnOpn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpn.ForeColor = System.Drawing.Color.Black
        Me.btnOpn.Location = New System.Drawing.Point(395, 28)
        Me.btnOpn.Name = "btnOpn"
        Me.btnOpn.Size = New System.Drawing.Size(83, 26)
        Me.btnOpn.TabIndex = 12
        Me.btnOpn.Text = "Open"
        Me.btnOpn.UseVisualStyleBackColor = False
        '
        'btnAtch
        '
        Me.btnAtch.BackColor = System.Drawing.Color.Transparent
        Me.btnAtch.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtch.ForeColor = System.Drawing.Color.Black
        Me.btnAtch.Location = New System.Drawing.Point(955, 38)
        Me.btnAtch.Name = "btnAtch"
        Me.btnAtch.Size = New System.Drawing.Size(71, 26)
        Me.btnAtch.TabIndex = 13
        Me.btnAtch.Text = "Attach"
        Me.btnAtch.UseVisualStyleBackColor = False
        '
        'txtAtch1
        '
        Me.txtAtch1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch1.Location = New System.Drawing.Point(955, 65)
        Me.txtAtch1.Name = "txtAtch1"
        Me.txtAtch1.Size = New System.Drawing.Size(320, 22)
        Me.txtAtch1.TabIndex = 14
        '
        'txtAtch2
        '
        Me.txtAtch2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch2.Location = New System.Drawing.Point(955, 95)
        Me.txtAtch2.Name = "txtAtch2"
        Me.txtAtch2.Size = New System.Drawing.Size(320, 22)
        Me.txtAtch2.TabIndex = 15
        '
        'txtAtch3
        '
        Me.txtAtch3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch3.Location = New System.Drawing.Point(955, 125)
        Me.txtAtch3.Name = "txtAtch3"
        Me.txtAtch3.Size = New System.Drawing.Size(320, 22)
        Me.txtAtch3.TabIndex = 16
        '
        'opnfd
        '
        Me.opnfd.FileName = "OpenFileDialog1"
        '
        'txtAtch4
        '
        Me.txtAtch4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch4.Location = New System.Drawing.Point(955, 155)
        Me.txtAtch4.Name = "txtAtch4"
        Me.txtAtch4.Size = New System.Drawing.Size(320, 22)
        Me.txtAtch4.TabIndex = 17
        '
        'txtAtch5
        '
        Me.txtAtch5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch5.Location = New System.Drawing.Point(956, 185)
        Me.txtAtch5.Name = "txtAtch5"
        Me.txtAtch5.Size = New System.Drawing.Size(318, 22)
        Me.txtAtch5.TabIndex = 18
        '
        'txtAtch6
        '
        Me.txtAtch6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch6.Location = New System.Drawing.Point(956, 215)
        Me.txtAtch6.Name = "txtAtch6"
        Me.txtAtch6.Size = New System.Drawing.Size(318, 22)
        Me.txtAtch6.TabIndex = 19
        '
        'txtAtch7
        '
        Me.txtAtch7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtch7.Location = New System.Drawing.Point(955, 246)
        Me.txtAtch7.Name = "txtAtch7"
        Me.txtAtch7.Size = New System.Drawing.Size(320, 22)
        Me.txtAtch7.TabIndex = 20
        '
        'BtnRmv1
        '
        Me.BtnRmv1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv1.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv1.Location = New System.Drawing.Point(1290, 64)
        Me.BtnRmv1.Name = "BtnRmv1"
        Me.BtnRmv1.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv1.TabIndex = 21
        Me.BtnRmv1.Text = "X"
        Me.BtnRmv1.UseVisualStyleBackColor = True
        '
        'BtnRmv2
        '
        Me.BtnRmv2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv2.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv2.Location = New System.Drawing.Point(1290, 95)
        Me.BtnRmv2.Name = "BtnRmv2"
        Me.BtnRmv2.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv2.TabIndex = 22
        Me.BtnRmv2.Text = "X"
        Me.BtnRmv2.UseVisualStyleBackColor = True
        '
        'BtnRmv3
        '
        Me.BtnRmv3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv3.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv3.Location = New System.Drawing.Point(1290, 125)
        Me.BtnRmv3.Name = "BtnRmv3"
        Me.BtnRmv3.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv3.TabIndex = 23
        Me.BtnRmv3.Text = "X"
        Me.BtnRmv3.UseVisualStyleBackColor = True
        '
        'BtnRmv4
        '
        Me.BtnRmv4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv4.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv4.Location = New System.Drawing.Point(1290, 155)
        Me.BtnRmv4.Name = "BtnRmv4"
        Me.BtnRmv4.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv4.TabIndex = 24
        Me.BtnRmv4.Text = "X"
        Me.BtnRmv4.UseVisualStyleBackColor = True
        '
        'BtnRmv5
        '
        Me.BtnRmv5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv5.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv5.Location = New System.Drawing.Point(1290, 185)
        Me.BtnRmv5.Name = "BtnRmv5"
        Me.BtnRmv5.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv5.TabIndex = 25
        Me.BtnRmv5.Text = "X"
        Me.BtnRmv5.UseVisualStyleBackColor = True
        '
        'BtnRmv6
        '
        Me.BtnRmv6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv6.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv6.Location = New System.Drawing.Point(1290, 215)
        Me.BtnRmv6.Name = "BtnRmv6"
        Me.BtnRmv6.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv6.TabIndex = 26
        Me.BtnRmv6.Text = "X"
        Me.BtnRmv6.UseVisualStyleBackColor = True
        '
        'BtnRmv7
        '
        Me.BtnRmv7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmv7.ForeColor = System.Drawing.Color.Red
        Me.BtnRmv7.Location = New System.Drawing.Point(1290, 245)
        Me.BtnRmv7.Name = "BtnRmv7"
        Me.BtnRmv7.Size = New System.Drawing.Size(22, 23)
        Me.BtnRmv7.TabIndex = 27
        Me.BtnRmv7.Text = "X"
        Me.BtnRmv7.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.rdbLoyaltyCust)
        Me.Panel1.Controls.Add(Me.rdbCust)
        Me.Panel1.Controls.Add(Me.dgCustNm)
        Me.Panel1.Controls.Add(Me.HTMLT)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.txtAtch3)
        Me.Panel1.Controls.Add(Me.cmbCustGrp)
        Me.Panel1.Controls.Add(Me.txtAtch2)
        Me.Panel1.Controls.Add(Me.BtnRmv1)
        Me.Panel1.Controls.Add(Me.txtAtch1)
        Me.Panel1.Controls.Add(Me.BtnRmv2)
        Me.Panel1.Controls.Add(Me.btnAtch)
        Me.Panel1.Controls.Add(Me.BtnRmv3)
        Me.Panel1.Controls.Add(Me.btnOpn)
        Me.Panel1.Controls.Add(Me.BtnRmv7)
        Me.Panel1.Controls.Add(Me.lblCustGrp)
        Me.Panel1.Controls.Add(Me.BtnRmv6)
        Me.Panel1.Controls.Add(Me.BtnRmv5)
        Me.Panel1.Controls.Add(Me.BtnRmv4)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.txtAtch7)
        Me.Panel1.Controls.Add(Me.txtCust)
        Me.Panel1.Controls.Add(Me.txtAtch6)
        Me.Panel1.Controls.Add(Me.lbltxt)
        Me.Panel1.Controls.Add(Me.txtAtch5)
        Me.Panel1.Controls.Add(Me.lblCust)
        Me.Panel1.Controls.Add(Me.txtAtch4)
        Me.Panel1.Controls.Add(Me.btnGrpAdd)
        Me.Panel1.Controls.Add(Me.dgCust)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1321, 697)
        Me.Panel1.TabIndex = 28
        '
        'rdbLoyaltyCust
        '
        Me.rdbLoyaltyCust.AutoSize = True
        Me.rdbLoyaltyCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbLoyaltyCust.Location = New System.Drawing.Point(731, 368)
        Me.rdbLoyaltyCust.Name = "rdbLoyaltyCust"
        Me.rdbLoyaltyCust.Size = New System.Drawing.Size(134, 19)
        Me.rdbLoyaltyCust.TabIndex = 148
        Me.rdbLoyaltyCust.TabStop = True
        Me.rdbLoyaltyCust.Text = "Loyalty Customer"
        Me.rdbLoyaltyCust.UseVisualStyleBackColor = True
        '
        'rdbCust
        '
        Me.rdbCust.AutoSize = True
        Me.rdbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbCust.Location = New System.Drawing.Point(633, 368)
        Me.rdbCust.Name = "rdbCust"
        Me.rdbCust.Size = New System.Drawing.Size(86, 19)
        Me.rdbCust.TabIndex = 147
        Me.rdbCust.TabStop = True
        Me.rdbCust.Text = "Customer"
        Me.rdbCust.UseVisualStyleBackColor = True
        '
        'HTMLT
        '
        Me.HTMLT.DefaultComposeSettings.BackColor = System.Drawing.Color.White
        Me.HTMLT.DefaultComposeSettings.DefaultFont = New System.Drawing.Font("Arial", 10.0!)
        Me.HTMLT.DefaultComposeSettings.Enabled = False
        Me.HTMLT.DefaultComposeSettings.ForeColor = System.Drawing.Color.Black
        Me.HTMLT.DefaultPreamble = onlyconnect.EncodingType.UTF8
        Me.HTMLT.DocumentEncoding = onlyconnect.EncodingType.WindowsCurrent
        Me.HTMLT.IsDesignMode = True
        Me.HTMLT.IsDivOnEnter = True
        Me.HTMLT.Location = New System.Drawing.Point(14, 74)
        Me.HTMLT.Name = "HTMLT"
        Me.HTMLT.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.HTMLT.SelectionBackColor = System.Drawing.Color.Empty
        Me.HTMLT.SelectionBullets = False
        Me.HTMLT.SelectionFont = Nothing
        Me.HTMLT.SelectionForeColor = System.Drawing.Color.Empty
        Me.HTMLT.SelectionNumbering = False
        Me.HTMLT.Size = New System.Drawing.Size(921, 274)
        Me.HTMLT.TabIndex = 29
        Me.HTMLT.Text = "HTMLT"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Wheat
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbold, Me.tsitalic, Me.tsunder, Me.tsfont, Me.tscolor, Me.tsjl, Me.tsjc, Me.tsjr, Me.tsbul, Me.ToolStripButton10, Me.ToolStripButton11})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1317, 25)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbold
        '
        Me.tsbold.CheckOnClick = True
        Me.tsbold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbold.Image = CType(resources.GetObject("tsbold.Image"), System.Drawing.Image)
        Me.tsbold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbold.Name = "tsbold"
        Me.tsbold.Size = New System.Drawing.Size(23, 22)
        Me.tsbold.Text = "ToolStripButton1"
        Me.tsbold.ToolTipText = "Bold"
        '
        'tsitalic
        '
        Me.tsitalic.CheckOnClick = True
        Me.tsitalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsitalic.Image = CType(resources.GetObject("tsitalic.Image"), System.Drawing.Image)
        Me.tsitalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsitalic.Name = "tsitalic"
        Me.tsitalic.Size = New System.Drawing.Size(23, 22)
        Me.tsitalic.Text = "ToolStripButton2"
        Me.tsitalic.ToolTipText = "Italic"
        '
        'tsunder
        '
        Me.tsunder.CheckOnClick = True
        Me.tsunder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsunder.Image = CType(resources.GetObject("tsunder.Image"), System.Drawing.Image)
        Me.tsunder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsunder.Name = "tsunder"
        Me.tsunder.Size = New System.Drawing.Size(23, 22)
        Me.tsunder.Text = "ToolStripButton3"
        Me.tsunder.ToolTipText = "Underline"
        '
        'tsfont
        '
        Me.tsfont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsfont.Image = CType(resources.GetObject("tsfont.Image"), System.Drawing.Image)
        Me.tsfont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsfont.Name = "tsfont"
        Me.tsfont.Size = New System.Drawing.Size(23, 22)
        Me.tsfont.Text = "ToolStripButton4"
        Me.tsfont.ToolTipText = "Font"
        '
        'tscolor
        '
        Me.tscolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscolor.Image = CType(resources.GetObject("tscolor.Image"), System.Drawing.Image)
        Me.tscolor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscolor.Name = "tscolor"
        Me.tscolor.Size = New System.Drawing.Size(23, 22)
        Me.tscolor.Text = "ToolStripButton5"
        Me.tscolor.ToolTipText = "Color"
        '
        'tsjl
        '
        Me.tsjl.CheckOnClick = True
        Me.tsjl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsjl.Image = CType(resources.GetObject("tsjl.Image"), System.Drawing.Image)
        Me.tsjl.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsjl.Name = "tsjl"
        Me.tsjl.Size = New System.Drawing.Size(23, 22)
        Me.tsjl.Text = "ToolStripButton6"
        Me.tsjl.ToolTipText = "Justify left"
        '
        'tsjc
        '
        Me.tsjc.CheckOnClick = True
        Me.tsjc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsjc.Image = CType(resources.GetObject("tsjc.Image"), System.Drawing.Image)
        Me.tsjc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsjc.Name = "tsjc"
        Me.tsjc.Size = New System.Drawing.Size(23, 22)
        Me.tsjc.Text = "ToolStripButton7"
        Me.tsjc.ToolTipText = "Justify center"
        '
        'tsjr
        '
        Me.tsjr.CheckOnClick = True
        Me.tsjr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsjr.Image = CType(resources.GetObject("tsjr.Image"), System.Drawing.Image)
        Me.tsjr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsjr.Name = "tsjr"
        Me.tsjr.Size = New System.Drawing.Size(23, 22)
        Me.tsjr.Text = "ToolStripButton8"
        Me.tsjr.ToolTipText = "Justify right"
        '
        'tsbul
        '
        Me.tsbul.CheckOnClick = True
        Me.tsbul.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbul.Image = CType(resources.GetObject("tsbul.Image"), System.Drawing.Image)
        Me.tsbul.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbul.Name = "tsbul"
        Me.tsbul.Size = New System.Drawing.Size(23, 22)
        Me.tsbul.Text = "ToolStripButton9"
        Me.tsbul.ToolTipText = "Insert Serial No"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "ToolStripButton10"
        Me.ToolStripButton10.ToolTipText = "Undo"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "ToolStripButton11"
        Me.ToolStripButton11.ToolTipText = "Redo"
        '
        'EmailSndng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1321, 733)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "EmailSndng"
        Me.Text = "Email Sending"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCustNm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSend As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClr As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents lbltxt As System.Windows.Forms.Label
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgCust As System.Windows.Forms.DataGridView
    Friend WithEvents dgCustNm As System.Windows.Forms.DataGridView
    Friend WithEvents CustCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCustGrp As System.Windows.Forms.Label
    Friend WithEvents btnGrpAdd As System.Windows.Forms.Button
    Friend WithEvents cmbCustGrp As System.Windows.Forms.ComboBox
    Friend WithEvents btnOpn As System.Windows.Forms.Button
    Friend WithEvents btnAtch As System.Windows.Forms.Button
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtAtch1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAtch2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAtch3 As System.Windows.Forms.TextBox
    Friend WithEvents opnfd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtAtch4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAtch5 As System.Windows.Forms.TextBox
    Friend WithEvents txtAtch6 As System.Windows.Forms.TextBox
    Friend WithEvents txtAtch7 As System.Windows.Forms.TextBox
    Friend WithEvents BtnRmv1 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv2 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv3 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv4 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv5 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv6 As System.Windows.Forms.Button
    Friend WithEvents BtnRmv7 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents HTMLT As onlyconnect.HtmlEditor
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbold As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsitalic As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsunder As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsfont As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscolor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsjl As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsjc As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsjr As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbul As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rdbLoyaltyCust As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCust As System.Windows.Forms.RadioButton
End Class
