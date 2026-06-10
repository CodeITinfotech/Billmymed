<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class mapformr2
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents txtcode As System.Windows.Forms.TextBox
    Public WithEvents TxtMfr As System.Windows.Forms.TextBox
    Public WithEvents Txtrack As System.Windows.Forms.TextBox
    Public WithEvents txtsched As System.Windows.Forms.TextBox
    Public WithEvents txtname As System.Windows.Forms.TextBox
    Public WithEvents _Rpt_Option_0 As System.Windows.Forms.RadioButton
    Public WithEvents _Rpt_Option_1 As System.Windows.Forms.RadioButton
    Public WithEvents _Rpt_Option_2 As System.Windows.Forms.RadioButton
    Public WithEvents txtcase1 As System.Windows.Forms.TextBox
    Public WithEvents txtunit1 As System.Windows.Forms.TextBox
    Public WithEvents txtcase2 As System.Windows.Forms.TextBox
    Public WithEvents Txtunit2 As System.Windows.Forms.TextBox
    Public WithEvents Txtcase3 As System.Windows.Forms.TextBox
    Public WithEvents Txtunit3 As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents lblprod As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents lblmclass As System.Windows.Forms.Label
    Public WithEvents lblcomp As System.Windows.Forms.Label
    Public WithEvents lblname As System.Windows.Forms.Label
    Public WithEvents lblcode As System.Windows.Forms.Label
    Public WithEvents lblrack As System.Windows.Forms.Label
    Public WithEvents Frm As System.Windows.Forms.GroupBox
    Public WithEvents ComClear As System.Windows.Forms.Button
    Public WithEvents comselect As System.Windows.Forms.Button
    Public WithEvents ComCancel As System.Windows.Forms.Button
    Public WithEvents Comok As System.Windows.Forms.Button
    Public WithEvents comadd As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frm = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbClass = New System.Windows.Forms.ComboBox()
        Me.cbComp = New System.Windows.Forms.ComboBox()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.TxtMfr = New System.Windows.Forms.TextBox()
        Me.Txtrack = New System.Windows.Forms.TextBox()
        Me.txtsched = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me._Rpt_Option_0 = New System.Windows.Forms.RadioButton()
        Me._Rpt_Option_1 = New System.Windows.Forms.RadioButton()
        Me._Rpt_Option_2 = New System.Windows.Forms.RadioButton()
        Me.txtcase1 = New System.Windows.Forms.TextBox()
        Me.txtunit1 = New System.Windows.Forms.TextBox()
        Me.txtcase2 = New System.Windows.Forms.TextBox()
        Me.Txtunit2 = New System.Windows.Forms.TextBox()
        Me.Txtcase3 = New System.Windows.Forms.TextBox()
        Me.Txtunit3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblprod = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblmclass = New System.Windows.Forms.Label()
        Me.lblcomp = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.lblcode = New System.Windows.Forms.Label()
        Me.lblrack = New System.Windows.Forms.Label()
        Me.pnlprod = New System.Windows.Forms.FlowLayoutPanel()
        Me.DgProdSer = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComClear = New System.Windows.Forms.Button()
        Me.comselect = New System.Windows.Forms.Button()
        Me.ComCancel = New System.Windows.Forms.Button()
        Me.Comok = New System.Windows.Forms.Button()
        Me.comadd = New System.Windows.Forms.Button()
        Me.Frm.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.pnlprod.SuspendLayout()
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frm
        '
        Me.Frm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Frm.Controls.Add(Me.Label3)
        Me.Frm.Controls.Add(Me.TextBox1)
        Me.Frm.Controls.Add(Me.cbClass)
        Me.Frm.Controls.Add(Me.cbComp)
        Me.Frm.Controls.Add(Me.txtcode)
        Me.Frm.Controls.Add(Me.TxtMfr)
        Me.Frm.Controls.Add(Me.Txtrack)
        Me.Frm.Controls.Add(Me.txtsched)
        Me.Frm.Controls.Add(Me.txtname)
        Me.Frm.Controls.Add(Me.Frame2)
        Me.Frm.Controls.Add(Me.lblprod)
        Me.Frm.Controls.Add(Me.Label8)
        Me.Frm.Controls.Add(Me.Label7)
        Me.Frm.Controls.Add(Me.lblmclass)
        Me.Frm.Controls.Add(Me.lblcomp)
        Me.Frm.Controls.Add(Me.lblname)
        Me.Frm.Controls.Add(Me.lblcode)
        Me.Frm.Controls.Add(Me.lblrack)
        Me.Frm.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frm.ForeColor = System.Drawing.Color.Blue
        Me.Frm.Location = New System.Drawing.Point(34, 41)
        Me.Frm.Name = "Frm"
        Me.Frm.Padding = New System.Windows.Forms.Padding(0)
        Me.Frm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frm.Size = New System.Drawing.Size(885, 364)
        Me.Frm.TabIndex = 0
        Me.Frm.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(13, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(152, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Product not Mapped"
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(171, 19)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(703, 26)
        Me.TextBox1.TabIndex = 37
        Me.TextBox1.WordWrap = False
        '
        'cbClass
        '
        Me.cbClass.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbClass.FormattingEnabled = True
        Me.cbClass.Location = New System.Drawing.Point(139, 177)
        Me.cbClass.Name = "cbClass"
        Me.cbClass.Size = New System.Drawing.Size(265, 26)
        Me.cbClass.TabIndex = 2
        '
        'cbComp
        '
        Me.cbComp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbComp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComp.FormattingEnabled = True
        Me.cbComp.Location = New System.Drawing.Point(139, 137)
        Me.cbComp.Name = "cbComp"
        Me.cbComp.Size = New System.Drawing.Size(265, 24)
        Me.cbComp.TabIndex = 1
        '
        'txtcode
        '
        Me.txtcode.AcceptsReturn = True
        Me.txtcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcode.CausesValidation = False
        Me.txtcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcode.Location = New System.Drawing.Point(139, 61)
        Me.txtcode.MaxLength = 6
        Me.txtcode.Name = "txtcode"
        Me.txtcode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcode.Size = New System.Drawing.Size(73, 22)
        Me.txtcode.TabIndex = 6
        '
        'TxtMfr
        '
        Me.TxtMfr.AcceptsReturn = True
        Me.TxtMfr.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtMfr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMfr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMfr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtMfr.Location = New System.Drawing.Point(307, 222)
        Me.TxtMfr.MaxLength = 0
        Me.TxtMfr.Name = "TxtMfr"
        Me.TxtMfr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMfr.Size = New System.Drawing.Size(51, 22)
        Me.TxtMfr.TabIndex = 5
        Me.TxtMfr.Visible = False
        '
        'Txtrack
        '
        Me.Txtrack.AcceptsReturn = True
        Me.Txtrack.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txtrack.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txtrack.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtrack.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txtrack.Location = New System.Drawing.Point(191, 222)
        Me.Txtrack.MaxLength = 10
        Me.Txtrack.Name = "Txtrack"
        Me.Txtrack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txtrack.Size = New System.Drawing.Size(63, 22)
        Me.Txtrack.TabIndex = 4
        Me.Txtrack.Visible = False
        '
        'txtsched
        '
        Me.txtsched.AcceptsReturn = True
        Me.txtsched.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtsched.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtsched.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsched.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtsched.Location = New System.Drawing.Point(133, 219)
        Me.txtsched.MaxLength = 3
        Me.txtsched.Name = "txtsched"
        Me.txtsched.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtsched.Size = New System.Drawing.Size(48, 22)
        Me.txtsched.TabIndex = 3
        '
        'txtname
        '
        Me.txtname.AcceptsReturn = True
        Me.txtname.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtname.Location = New System.Drawing.Point(139, 99)
        Me.txtname.MaxLength = 30
        Me.txtname.Name = "txtname"
        Me.txtname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtname.Size = New System.Drawing.Size(265, 22)
        Me.txtname.TabIndex = 0
        Me.txtname.WordWrap = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Frame2.Controls.Add(Me._Rpt_Option_0)
        Me.Frame2.Controls.Add(Me._Rpt_Option_1)
        Me.Frame2.Controls.Add(Me._Rpt_Option_2)
        Me.Frame2.Controls.Add(Me.txtcase1)
        Me.Frame2.Controls.Add(Me.txtunit1)
        Me.Frame2.Controls.Add(Me.txtcase2)
        Me.Frame2.Controls.Add(Me.Txtunit2)
        Me.Frame2.Controls.Add(Me.Txtcase3)
        Me.Frame2.Controls.Add(Me.Txtunit3)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.Color.Black
        Me.Frame2.Location = New System.Drawing.Point(443, 99)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(247, 139)
        Me.Frame2.TabIndex = 5
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Packings"
        '
        '_Rpt_Option_0
        '
        Me._Rpt_Option_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Rpt_Option_0.Checked = True
        Me._Rpt_Option_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Rpt_Option_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Rpt_Option_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Rpt_Option_0.Location = New System.Drawing.Point(173, 45)
        Me._Rpt_Option_0.Name = "_Rpt_Option_0"
        Me._Rpt_Option_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Rpt_Option_0.Size = New System.Drawing.Size(25, 10)
        Me._Rpt_Option_0.TabIndex = 19
        Me._Rpt_Option_0.TabStop = True
        Me._Rpt_Option_0.Text = "&1"
        Me._Rpt_Option_0.UseVisualStyleBackColor = False
        Me._Rpt_Option_0.Visible = False
        '
        '_Rpt_Option_1
        '
        Me._Rpt_Option_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Rpt_Option_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Rpt_Option_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Rpt_Option_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Rpt_Option_1.Location = New System.Drawing.Point(173, 73)
        Me._Rpt_Option_1.Name = "_Rpt_Option_1"
        Me._Rpt_Option_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Rpt_Option_1.Size = New System.Drawing.Size(25, 16)
        Me._Rpt_Option_1.TabIndex = 18
        Me._Rpt_Option_1.TabStop = True
        Me._Rpt_Option_1.Text = "&2"
        Me._Rpt_Option_1.UseVisualStyleBackColor = False
        Me._Rpt_Option_1.Visible = False
        '
        '_Rpt_Option_2
        '
        Me._Rpt_Option_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me._Rpt_Option_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Rpt_Option_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Rpt_Option_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Rpt_Option_2.Location = New System.Drawing.Point(173, 103)
        Me._Rpt_Option_2.Name = "_Rpt_Option_2"
        Me._Rpt_Option_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Rpt_Option_2.Size = New System.Drawing.Size(25, 16)
        Me._Rpt_Option_2.TabIndex = 17
        Me._Rpt_Option_2.TabStop = True
        Me._Rpt_Option_2.Text = "&3"
        Me._Rpt_Option_2.UseVisualStyleBackColor = False
        Me._Rpt_Option_2.Visible = False
        '
        'txtcase1
        '
        Me.txtcase1.AcceptsReturn = True
        Me.txtcase1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcase1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcase1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcase1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcase1.Location = New System.Drawing.Point(15, 38)
        Me.txtcase1.MaxLength = 6
        Me.txtcase1.Name = "txtcase1"
        Me.txtcase1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcase1.Size = New System.Drawing.Size(77, 22)
        Me.txtcase1.TabIndex = 0
        '
        'txtunit1
        '
        Me.txtunit1.AcceptsReturn = True
        Me.txtunit1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtunit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtunit1.Enabled = False
        Me.txtunit1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunit1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtunit1.Location = New System.Drawing.Point(101, 41)
        Me.txtunit1.MaxLength = 0
        Me.txtunit1.Name = "txtunit1"
        Me.txtunit1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtunit1.Size = New System.Drawing.Size(57, 22)
        Me.txtunit1.TabIndex = 1
        Me.txtunit1.Text = "1"
        Me.txtunit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcase2
        '
        Me.txtcase2.AcceptsReturn = True
        Me.txtcase2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcase2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcase2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcase2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcase2.Location = New System.Drawing.Point(15, 68)
        Me.txtcase2.MaxLength = 5
        Me.txtcase2.Name = "txtcase2"
        Me.txtcase2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcase2.Size = New System.Drawing.Size(77, 22)
        Me.txtcase2.TabIndex = 2
        '
        'Txtunit2
        '
        Me.Txtunit2.AcceptsReturn = True
        Me.Txtunit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txtunit2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txtunit2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtunit2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txtunit2.Location = New System.Drawing.Point(101, 70)
        Me.Txtunit2.MaxLength = 0
        Me.Txtunit2.Name = "Txtunit2"
        Me.Txtunit2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txtunit2.Size = New System.Drawing.Size(57, 22)
        Me.Txtunit2.TabIndex = 3
        Me.Txtunit2.Text = "0"
        Me.Txtunit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txtcase3
        '
        Me.Txtcase3.AcceptsReturn = True
        Me.Txtcase3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txtcase3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txtcase3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcase3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txtcase3.Location = New System.Drawing.Point(15, 98)
        Me.Txtcase3.MaxLength = 5
        Me.Txtcase3.Name = "Txtcase3"
        Me.Txtcase3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txtcase3.Size = New System.Drawing.Size(77, 22)
        Me.Txtcase3.TabIndex = 4
        '
        'Txtunit3
        '
        Me.Txtunit3.AcceptsReturn = True
        Me.Txtunit3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txtunit3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Txtunit3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtunit3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Txtunit3.Location = New System.Drawing.Point(101, 100)
        Me.Txtunit3.MaxLength = 0
        Me.Txtunit3.Name = "Txtunit3"
        Me.Txtunit3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txtunit3.Size = New System.Drawing.Size(57, 22)
        Me.Txtunit3.TabIndex = 5
        Me.Txtunit3.Text = "0"
        Me.Txtunit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(170, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "In Rpt"
        Me.Label5.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(52, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Case"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(118, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Unit"
        '
        'lblprod
        '
        Me.lblprod.AutoSize = True
        Me.lblprod.BackColor = System.Drawing.SystemColors.Control
        Me.lblprod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblprod.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblprod.Location = New System.Drawing.Point(136, 0)
        Me.lblprod.Name = "lblprod"
        Me.lblprod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblprod.Size = New System.Drawing.Size(0, 15)
        Me.lblprod.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(264, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(41, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Mfr."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Schedule"
        '
        'lblmclass
        '
        Me.lblmclass.AutoSize = True
        Me.lblmclass.BackColor = System.Drawing.Color.Transparent
        Me.lblmclass.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblmclass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmclass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblmclass.Location = New System.Drawing.Point(13, 182)
        Me.lblmclass.Name = "lblmclass"
        Me.lblmclass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblmclass.Size = New System.Drawing.Size(120, 16)
        Me.lblmclass.TabIndex = 28
        Me.lblmclass.Text = "Classification"
        '
        'lblcomp
        '
        Me.lblcomp.AutoSize = True
        Me.lblcomp.BackColor = System.Drawing.Color.Transparent
        Me.lblcomp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblcomp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcomp.Location = New System.Drawing.Point(13, 141)
        Me.lblcomp.Name = "lblcomp"
        Me.lblcomp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblcomp.Size = New System.Drawing.Size(64, 16)
        Me.lblcomp.TabIndex = 27
        Me.lblcomp.Text = "Company"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblname.Location = New System.Drawing.Point(13, 102)
        Me.lblname.Name = "lblname"
        Me.lblname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblname.Size = New System.Drawing.Size(40, 16)
        Me.lblname.TabIndex = 25
        Me.lblname.Text = "Name"
        '
        'lblcode
        '
        Me.lblcode.AutoSize = True
        Me.lblcode.BackColor = System.Drawing.Color.Transparent
        Me.lblcode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblcode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcode.Location = New System.Drawing.Point(13, 63)
        Me.lblcode.Name = "lblcode"
        Me.lblcode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblcode.Size = New System.Drawing.Size(40, 16)
        Me.lblcode.TabIndex = 24
        Me.lblcode.Text = "C&ode"
        '
        'lblrack
        '
        Me.lblrack.AutoSize = True
        Me.lblrack.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblrack.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblrack.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrack.ForeColor = System.Drawing.Color.Black
        Me.lblrack.Location = New System.Drawing.Point(141, 187)
        Me.lblrack.Name = "lblrack"
        Me.lblrack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblrack.Size = New System.Drawing.Size(40, 16)
        Me.lblrack.TabIndex = 23
        Me.lblrack.Text = "Rack"
        '
        'pnlprod
        '
        Me.pnlprod.AutoSize = True
        Me.pnlprod.BackColor = System.Drawing.Color.Wheat
        Me.pnlprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlprod.Controls.Add(Me.DgProdSer)
        Me.pnlprod.Location = New System.Drawing.Point(301, 89)
        Me.pnlprod.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlprod.Name = "pnlprod"
        Me.pnlprod.Size = New System.Drawing.Size(607, 414)
        Me.pnlprod.TabIndex = 161
        Me.pnlprod.Visible = False
        '
        'DgProdSer
        '
        Me.DgProdSer.AllowUserToAddRows = False
        Me.DgProdSer.AllowUserToDeleteRows = False
        Me.DgProdSer.AllowUserToOrderColumns = True
        Me.DgProdSer.AllowUserToResizeRows = False
        Me.DgProdSer.BackgroundColor = System.Drawing.Color.Wheat
        Me.DgProdSer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgProdSer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgProdSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgProdSer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Rack, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgProdSer.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgProdSer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgProdSer.EnableHeadersVisualStyles = False
        Me.DgProdSer.Location = New System.Drawing.Point(3, 4)
        Me.DgProdSer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DgProdSer.Name = "DgProdSer"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgProdSer.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DgProdSer.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgProdSer.RowTemplate.Height = 28
        Me.DgProdSer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgProdSer.Size = New System.Drawing.Size(599, 399)
        Me.DgProdSer.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 270
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Stock"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "#"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Stock"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Case1"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Case1"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Case2"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Case2"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 61
        '
        'Rack
        '
        Me.Rack.DataPropertyName = "rack no"
        Me.Rack.HeaderText = "Rack"
        Me.Rack.Name = "Rack"
        Me.Rack.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ComName"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Company"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 75
        '
        'ComClear
        '
        Me.ComClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ComClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComClear.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComClear.Location = New System.Drawing.Point(210, 12)
        Me.ComClear.Name = "ComClear"
        Me.ComClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComClear.Size = New System.Drawing.Size(73, 23)
        Me.ComClear.TabIndex = 4
        Me.ComClear.Text = "C&lear"
        Me.ComClear.UseVisualStyleBackColor = False
        '
        'comselect
        '
        Me.comselect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.comselect.CausesValidation = False
        Me.comselect.Cursor = System.Windows.Forms.Cursors.Default
        Me.comselect.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comselect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.comselect.Location = New System.Drawing.Point(130, 12)
        Me.comselect.Name = "comselect"
        Me.comselect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comselect.Size = New System.Drawing.Size(65, 23)
        Me.comselect.TabIndex = 3
        Me.comselect.Tag = "N"
        Me.comselect.Text = "&Select"
        Me.comselect.UseVisualStyleBackColor = False
        '
        'ComCancel
        '
        Me.ComCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ComCancel.CausesValidation = False
        Me.ComCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComCancel.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComCancel.Location = New System.Drawing.Point(418, 12)
        Me.ComCancel.Name = "ComCancel"
        Me.ComCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComCancel.Size = New System.Drawing.Size(65, 23)
        Me.ComCancel.TabIndex = 5
        Me.ComCancel.Text = "&Cancel"
        Me.ComCancel.UseVisualStyleBackColor = False
        '
        'Comok
        '
        Me.Comok.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Comok.CausesValidation = False
        Me.Comok.Cursor = System.Windows.Forms.Cursors.Default
        Me.Comok.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comok.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Comok.Location = New System.Drawing.Point(322, 12)
        Me.Comok.Name = "Comok"
        Me.Comok.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Comok.Size = New System.Drawing.Size(65, 23)
        Me.Comok.TabIndex = 1
        Me.Comok.Text = "O&k"
        Me.Comok.UseVisualStyleBackColor = False
        '
        'comadd
        '
        Me.comadd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.comadd.CausesValidation = False
        Me.comadd.Cursor = System.Windows.Forms.Cursors.Default
        Me.comadd.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comadd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.comadd.Location = New System.Drawing.Point(42, 12)
        Me.comadd.Name = "comadd"
        Me.comadd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comadd.Size = New System.Drawing.Size(65, 23)
        Me.comadd.TabIndex = 2
        Me.comadd.Tag = "N"
        Me.comadd.Text = "&Add"
        Me.comadd.UseVisualStyleBackColor = False
        '
        'mapformr2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(952, 528)
        Me.Controls.Add(Me.pnlprod)
        Me.Controls.Add(Me.ComClear)
        Me.Controls.Add(Me.comselect)
        Me.Controls.Add(Me.ComCancel)
        Me.Controls.Add(Me.Comok)
        Me.Controls.Add(Me.comadd)
        Me.Controls.Add(Me.Frm)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(4, 24)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mapformr2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Maping Product"
        Me.Frm.ResumeLayout(False)
        Me.Frm.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.pnlprod.ResumeLayout(False)
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbClass As System.Windows.Forms.ComboBox
    Friend WithEvents cbComp As System.Windows.Forms.ComboBox
    Friend WithEvents pnlprod As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DgProdSer As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
#End Region
End Class