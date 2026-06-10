<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMSReg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SMSReg))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCPlc = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPPck = New System.Windows.Forms.Label()
        Me.dgProd = New System.Windows.Forms.DataGridView()
        Me.PCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSupp = New System.Windows.Forms.DataGridView()
        Me.txtCust = New System.Windows.Forms.TextBox()
        Me.dgCust = New System.Windows.Forms.DataGridView()
        Me.txtProd = New System.Windows.Forms.TextBox()
        Me.dgPrd = New System.Windows.Forms.DataGridView()
        Me.ChkSMS = New System.Windows.Forms.CheckBox()
        Me.ChkEmail = New System.Windows.Forms.CheckBox()
        Me.rdbLoyaltyCust = New System.Windows.Forms.RadioButton()
        Me.rdbCust = New System.Windows.Forms.RadioButton()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtMob = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbClear, Me.tsbExit, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1163, 36)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsbAdd
        '
        Me.tsbAdd.AutoSize = False
        Me.tsbAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(80, 33)
        Me.tsbAdd.Text = "&Add"
        '
        'tsbClear
        '
        Me.tsbClear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(68, 33)
        Me.tsbClear.Text = "&Clear"
        '
        'tsbExit
        '
        Me.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbExit.Image = CType(resources.GetObject("tsbExit.Image"), System.Drawing.Image)
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(60, 33)
        Me.tsbExit.Text = "E&xit"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(650, 33)
        Me.ToolStripLabel1.Text = "SMS Registry"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer :"
        '
        'lblCPlc
        '
        Me.lblCPlc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPlc.Location = New System.Drawing.Point(436, 121)
        Me.lblCPlc.Name = "lblCPlc"
        Me.lblCPlc.Size = New System.Drawing.Size(153, 16)
        Me.lblCPlc.TabIndex = 4
        Me.lblCPlc.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Product :"
        '
        'lblPPck
        '
        Me.lblPPck.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPck.Location = New System.Drawing.Point(435, 151)
        Me.lblPPck.Name = "lblPPck"
        Me.lblPPck.Size = New System.Drawing.Size(153, 18)
        Me.lblPPck.TabIndex = 7
        Me.lblPPck.Text = "Label2"
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToDeleteRows = False
        Me.dgProd.AllowUserToResizeColumns = False
        Me.dgProd.AllowUserToResizeRows = False
        Me.dgProd.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProd.ColumnHeadersHeight = 27
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCode, Me.PName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgProd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProd.EnableHeadersVisualStyles = False
        Me.dgProd.Location = New System.Drawing.Point(41, 255)
        Me.dgProd.Name = "dgProd"
        Me.dgProd.ReadOnly = True
        Me.dgProd.RowHeadersVisible = False
        Me.dgProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProd.Size = New System.Drawing.Size(445, 310)
        Me.dgProd.TabIndex = 8
        Me.dgProd.Visible = False
        '
        'PCode
        '
        Me.PCode.HeaderText = "Code"
        Me.PCode.Name = "PCode"
        Me.PCode.ReadOnly = True
        '
        'PName
        '
        Me.PName.HeaderText = "Name"
        Me.PName.Name = "PName"
        Me.PName.ReadOnly = True
        Me.PName.Width = 300
        '
        'dgSupp
        '
        Me.dgSupp.AllowUserToAddRows = False
        Me.dgSupp.AllowUserToDeleteRows = False
        Me.dgSupp.AllowUserToResizeColumns = False
        Me.dgSupp.AllowUserToResizeRows = False
        Me.dgSupp.BackgroundColor = System.Drawing.Color.White
        Me.dgSupp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgSupp.CausesValidation = False
        Me.dgSupp.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgSupp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSupp.ColumnHeadersHeight = 27
        Me.dgSupp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSupp.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgSupp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSupp.EnableHeadersVisualStyles = False
        Me.dgSupp.Location = New System.Drawing.Point(528, 117)
        Me.dgSupp.MultiSelect = False
        Me.dgSupp.Name = "dgSupp"
        Me.dgSupp.ReadOnly = True
        Me.dgSupp.RowHeadersVisible = False
        Me.dgSupp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSupp.Size = New System.Drawing.Size(567, 246)
        Me.dgSupp.TabIndex = 9
        Me.dgSupp.Visible = False
        '
        'txtCust
        '
        Me.txtCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCust.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(142, 117)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(267, 22)
        Me.txtCust.TabIndex = 1
        '
        'dgCust
        '
        Me.dgCust.AllowUserToAddRows = False
        Me.dgCust.AllowUserToDeleteRows = False
        Me.dgCust.AllowUserToResizeColumns = False
        Me.dgCust.AllowUserToResizeRows = False
        Me.dgCust.BackgroundColor = System.Drawing.Color.White
        Me.dgCust.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCust.CausesValidation = False
        Me.dgCust.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCust.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCust.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCust.ColumnHeadersHeight = 27
        Me.dgCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCust.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgCust.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCust.EnableHeadersVisualStyles = False
        Me.dgCust.Location = New System.Drawing.Point(415, 117)
        Me.dgCust.MultiSelect = False
        Me.dgCust.Name = "dgCust"
        Me.dgCust.ReadOnly = True
        Me.dgCust.RowHeadersVisible = False
        Me.dgCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCust.Size = New System.Drawing.Size(434, 357)
        Me.dgCust.TabIndex = 11
        Me.dgCust.Visible = False
        '
        'txtProd
        '
        Me.txtProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProd.Location = New System.Drawing.Point(142, 152)
        Me.txtProd.Name = "txtProd"
        Me.txtProd.Size = New System.Drawing.Size(267, 22)
        Me.txtProd.TabIndex = 2
        '
        'dgPrd
        '
        Me.dgPrd.AllowUserToAddRows = False
        Me.dgPrd.AllowUserToDeleteRows = False
        Me.dgPrd.AllowUserToResizeColumns = False
        Me.dgPrd.AllowUserToResizeRows = False
        Me.dgPrd.BackgroundColor = System.Drawing.Color.White
        Me.dgPrd.CausesValidation = False
        Me.dgPrd.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgPrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPrd.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgPrd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgPrd.EnableHeadersVisualStyles = False
        Me.dgPrd.Location = New System.Drawing.Point(166, 167)
        Me.dgPrd.MultiSelect = False
        Me.dgPrd.Name = "dgPrd"
        Me.dgPrd.ReadOnly = True
        Me.dgPrd.RowHeadersVisible = False
        Me.dgPrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPrd.Size = New System.Drawing.Size(586, 307)
        Me.dgPrd.TabIndex = 13
        Me.dgPrd.Visible = False
        '
        'ChkSMS
        '
        Me.ChkSMS.AutoSize = True
        Me.ChkSMS.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSMS.Location = New System.Drawing.Point(142, 91)
        Me.ChkSMS.Name = "ChkSMS"
        Me.ChkSMS.Size = New System.Drawing.Size(67, 20)
        Me.ChkSMS.TabIndex = 14
        Me.ChkSMS.Text = "SMS  "
        Me.ChkSMS.UseVisualStyleBackColor = True
        '
        'ChkEmail
        '
        Me.ChkEmail.AutoSize = True
        Me.ChkEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEmail.Location = New System.Drawing.Point(284, 91)
        Me.ChkEmail.Name = "ChkEmail"
        Me.ChkEmail.Size = New System.Drawing.Size(83, 20)
        Me.ChkEmail.TabIndex = 15
        Me.ChkEmail.Text = "Email  "
        Me.ChkEmail.UseVisualStyleBackColor = True
        '
        'rdbLoyaltyCust
        '
        Me.rdbLoyaltyCust.AutoSize = True
        Me.rdbLoyaltyCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbLoyaltyCust.Location = New System.Drawing.Point(142, 55)
        Me.rdbLoyaltyCust.Name = "rdbLoyaltyCust"
        Me.rdbLoyaltyCust.Size = New System.Drawing.Size(134, 19)
        Me.rdbLoyaltyCust.TabIndex = 146
        Me.rdbLoyaltyCust.TabStop = True
        Me.rdbLoyaltyCust.Text = "Loyalty Customer"
        Me.rdbLoyaltyCust.UseVisualStyleBackColor = True
        '
        'rdbCust
        '
        Me.rdbCust.AutoSize = True
        Me.rdbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbCust.Location = New System.Drawing.Point(44, 55)
        Me.rdbCust.Name = "rdbCust"
        Me.rdbCust.Size = New System.Drawing.Size(86, 19)
        Me.rdbCust.TabIndex = 145
        Me.rdbCust.TabStop = True
        Me.rdbCust.Text = "Customer"
        Me.rdbCust.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(142, 218)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(267, 22)
        Me.txtEmail.TabIndex = 149
        '
        'txtMob
        '
        Me.txtMob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMob.Enabled = False
        Me.txtMob.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMob.Location = New System.Drawing.Point(142, 183)
        Me.txtMob.Name = "txtMob"
        Me.txtMob.Size = New System.Drawing.Size(267, 22)
        Me.txtMob.TabIndex = 148
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Email Id :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Mob. No. :"
        '
        'SMSReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1163, 746)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rdbLoyaltyCust)
        Me.Controls.Add(Me.rdbCust)
        Me.Controls.Add(Me.ChkEmail)
        Me.Controls.Add(Me.ChkSMS)
        Me.Controls.Add(Me.dgPrd)
        Me.Controls.Add(Me.txtProd)
        Me.Controls.Add(Me.dgCust)
        Me.Controls.Add(Me.txtCust)
        Me.Controls.Add(Me.dgSupp)
        Me.Controls.Add(Me.dgProd)
        Me.Controls.Add(Me.lblPPck)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCPlc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtMob)
        Me.Name = "SMSReg"
        Me.Text = "SMS Registry (Stock Available)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCPlc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPPck As System.Windows.Forms.Label
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents dgSupp As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents dgCust As System.Windows.Forms.DataGridView
    Friend WithEvents txtProd As System.Windows.Forms.TextBox
    Friend WithEvents dgPrd As System.Windows.Forms.DataGridView
    Friend WithEvents ChkSMS As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents PCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdbLoyaltyCust As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCust As System.Windows.Forms.RadioButton
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMob As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
