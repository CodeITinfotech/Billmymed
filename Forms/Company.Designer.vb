<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Company
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Company))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlCompany = New System.Windows.Forms.Panel()
        Me.cbRack = New System.Windows.Forms.ComboBox()
        Me.pnlComp = New System.Windows.Forms.Panel()
        Me.dgCompSer = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbDel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCSupp = New System.Windows.Forms.Label()
        Me.lblCProd = New System.Windows.Forms.Label()
        Me.pnlCSupp = New System.Windows.Forms.Panel()
        Me.dgSupp = New System.Windows.Forms.DataGridView()
        Me.pnlCPrd = New System.Windows.Forms.Panel()
        Me.dgProd = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCSname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCname = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cbSupp = New System.Windows.Forms.ComboBox()
        Me.TTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlCompany.SuspendLayout()
        Me.pnlComp.SuspendLayout()
        CType(Me.dgCompSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.pnlCSupp.SuspendLayout()
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCPrd.SuspendLayout()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCompany
        '
        Me.pnlCompany.AutoSize = True
        Me.pnlCompany.BackColor = System.Drawing.Color.Wheat
        Me.pnlCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCompany.Controls.Add(Me.cbRack)
        Me.pnlCompany.Controls.Add(Me.pnlComp)
        Me.pnlCompany.Controls.Add(Me.Label3)
        Me.pnlCompany.Controls.Add(Me.ToolStrip)
        Me.pnlCompany.Controls.Add(Me.lblStatus)
        Me.pnlCompany.Controls.Add(Me.lblCSupp)
        Me.pnlCompany.Controls.Add(Me.lblCProd)
        Me.pnlCompany.Controls.Add(Me.pnlCSupp)
        Me.pnlCompany.Controls.Add(Me.pnlCPrd)
        Me.pnlCompany.Controls.Add(Me.Label2)
        Me.pnlCompany.Controls.Add(Me.txtCSname)
        Me.pnlCompany.Controls.Add(Me.Label1)
        Me.pnlCompany.Controls.Add(Me.txtCname)
        Me.pnlCompany.Controls.Add(Me.lblName)
        Me.pnlCompany.Controls.Add(Me.cbSupp)
        Me.pnlCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCompany.Location = New System.Drawing.Point(0, 0)
        Me.pnlCompany.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlCompany.Name = "pnlCompany"
        Me.pnlCompany.Size = New System.Drawing.Size(1365, 877)
        Me.pnlCompany.TabIndex = 70
        '
        'cbRack
        '
        Me.cbRack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbRack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbRack.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRack.FormattingEnabled = True
        Me.cbRack.Location = New System.Drawing.Point(241, 180)
        Me.cbRack.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbRack.Name = "cbRack"
        Me.cbRack.Size = New System.Drawing.Size(164, 26)
        Me.cbRack.TabIndex = 174
        '
        'pnlComp
        '
        Me.pnlComp.AutoSize = True
        Me.pnlComp.BackColor = System.Drawing.Color.Wheat
        Me.pnlComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlComp.Controls.Add(Me.dgCompSer)
        Me.pnlComp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlComp.ForeColor = System.Drawing.Color.Black
        Me.pnlComp.Location = New System.Drawing.Point(501, 76)
        Me.pnlComp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlComp.Name = "pnlComp"
        Me.pnlComp.Size = New System.Drawing.Size(547, 445)
        Me.pnlComp.TabIndex = 46
        Me.pnlComp.Visible = False
        '
        'dgCompSer
        '
        Me.dgCompSer.AllowUserToAddRows = False
        Me.dgCompSer.AllowUserToDeleteRows = False
        Me.dgCompSer.AllowUserToOrderColumns = True
        Me.dgCompSer.AllowUserToResizeRows = False
        Me.dgCompSer.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgCompSer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCompSer.CausesValidation = False
        Me.dgCompSer.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCompSer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCompSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCompSer.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCompSer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCompSer.EnableHeadersVisualStyles = False
        Me.dgCompSer.Location = New System.Drawing.Point(4, 4)
        Me.dgCompSer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgCompSer.MultiSelect = False
        Me.dgCompSer.Name = "dgCompSer"
        Me.dgCompSer.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCompSer.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCompSer.RowHeadersVisible = False
        Me.dgCompSer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCompSer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCompSer.Size = New System.Drawing.Size(535, 433)
        Me.dgCompSer.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 219)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 20)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Favorites Supplier"
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbAdd, Me.tsbExit, Me.tsbClear, Me.tsbDel, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1361, 41)
        Me.ToolStrip.TabIndex = 61
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSave.ForeColor = System.Drawing.Color.Black
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(80, 30)
        Me.tsbSave.Text = "&Save"
        '
        'tsbAdd
        '
        Me.tsbAdd.AutoSize = False
        Me.tsbAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbAdd.ForeColor = System.Drawing.Color.Black
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(80, 30)
        Me.tsbAdd.Text = "&Add"
        '
        'tsbExit
        '
        Me.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExit.AutoSize = False
        Me.tsbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsbExit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbExit.ForeColor = System.Drawing.Color.Black
        Me.tsbExit.Image = CType(resources.GetObject("tsbExit.Image"), System.Drawing.Image)
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(80, 30)
        Me.tsbExit.Text = "E&xit"
        '
        'tsbClear
        '
        Me.tsbClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClear.AutoSize = False
        Me.tsbClear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClear.ForeColor = System.Drawing.Color.Black
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(80, 30)
        Me.tsbClear.Text = "&Clear"
        '
        'tsbDel
        '
        Me.tsbDel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbDel.AutoSize = False
        Me.tsbDel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbDel.ForeColor = System.Drawing.Color.Black
        Me.tsbDel.Image = CType(resources.GetObject("tsbDel.Image"), System.Drawing.Image)
        Me.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDel.Name = "tsbDel"
        Me.tsbDel.Size = New System.Drawing.Size(80, 30)
        Me.tsbDel.Text = "&Delete"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(590, 30)
        Me.ToolStripLabel1.Text = "Company Master"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(236, 76)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(59, 20)
        Me.lblStatus.TabIndex = 51
        Me.lblStatus.Text = "Label"
        '
        'lblCSupp
        '
        Me.lblCSupp.AutoSize = True
        Me.lblCSupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCSupp.ForeColor = System.Drawing.Color.Black
        Me.lblCSupp.Location = New System.Drawing.Point(29, 257)
        Me.lblCSupp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCSupp.Name = "lblCSupp"
        Me.lblCSupp.Size = New System.Drawing.Size(119, 20)
        Me.lblCSupp.TabIndex = 50
        Me.lblCSupp.Text = "Suppliers.."
        '
        'lblCProd
        '
        Me.lblCProd.AutoSize = True
        Me.lblCProd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCProd.ForeColor = System.Drawing.Color.Black
        Me.lblCProd.Location = New System.Drawing.Point(692, 76)
        Me.lblCProd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCProd.Name = "lblCProd"
        Me.lblCProd.Size = New System.Drawing.Size(109, 20)
        Me.lblCProd.TabIndex = 49
        Me.lblCProd.Text = "Products.."
        '
        'pnlCSupp
        '
        Me.pnlCSupp.AutoSize = True
        Me.pnlCSupp.BackColor = System.Drawing.Color.Wheat
        Me.pnlCSupp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCSupp.Controls.Add(Me.dgSupp)
        Me.pnlCSupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCSupp.ForeColor = System.Drawing.Color.Black
        Me.pnlCSupp.Location = New System.Drawing.Point(29, 281)
        Me.pnlCSupp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlCSupp.Name = "pnlCSupp"
        Me.pnlCSupp.Size = New System.Drawing.Size(625, 434)
        Me.pnlCSupp.TabIndex = 48
        '
        'dgSupp
        '
        Me.dgSupp.AllowUserToAddRows = False
        Me.dgSupp.AllowUserToDeleteRows = False
        Me.dgSupp.AllowUserToOrderColumns = True
        Me.dgSupp.AllowUserToResizeRows = False
        Me.dgSupp.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgSupp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgSupp.CausesValidation = False
        Me.dgSupp.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgSupp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSupp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSupp.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgSupp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSupp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSupp.EnableHeadersVisualStyles = False
        Me.dgSupp.Location = New System.Drawing.Point(0, 0)
        Me.dgSupp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgSupp.MultiSelect = False
        Me.dgSupp.Name = "dgSupp"
        Me.dgSupp.ReadOnly = True
        Me.dgSupp.RowHeadersVisible = False
        Me.dgSupp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSupp.Size = New System.Drawing.Size(623, 432)
        Me.dgSupp.TabIndex = 30
        '
        'pnlCPrd
        '
        Me.pnlCPrd.AutoSize = True
        Me.pnlCPrd.BackColor = System.Drawing.Color.Wheat
        Me.pnlCPrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCPrd.Controls.Add(Me.dgProd)
        Me.pnlCPrd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCPrd.ForeColor = System.Drawing.Color.Black
        Me.pnlCPrd.Location = New System.Drawing.Point(692, 101)
        Me.pnlCPrd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlCPrd.Name = "pnlCPrd"
        Me.pnlCPrd.Size = New System.Drawing.Size(615, 614)
        Me.pnlCPrd.TabIndex = 47
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToDeleteRows = False
        Me.dgProd.AllowUserToOrderColumns = True
        Me.dgProd.AllowUserToResizeRows = False
        Me.dgProd.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgProd.CausesValidation = False
        Me.dgProd.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgProd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProd.EnableHeadersVisualStyles = False
        Me.dgProd.Location = New System.Drawing.Point(0, 0)
        Me.dgProd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgProd.MultiSelect = False
        Me.dgProd.Name = "dgProd"
        Me.dgProd.ReadOnly = True
        Me.dgProd.RowHeadersVisible = False
        Me.dgProd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProd.Size = New System.Drawing.Size(613, 612)
        Me.dgProd.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Rack No. :"
        '
        'txtCSname
        '
        Me.txtCSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCSname.ForeColor = System.Drawing.Color.Black
        Me.txtCSname.Location = New System.Drawing.Point(240, 145)
        Me.txtCSname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCSname.MaxLength = 5
        Me.txtCSname.Name = "txtCSname"
        Me.txtCSname.Size = New System.Drawing.Size(168, 26)
        Me.txtCSname.TabIndex = 1
        Me.txtCSname.Tag = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 145)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Short Name :"
        '
        'txtCname
        '
        Me.txtCname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCname.ForeColor = System.Drawing.Color.Black
        Me.txtCname.Location = New System.Drawing.Point(240, 110)
        Me.txtCname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCname.MaxLength = 30
        Me.txtCname.Name = "txtCname"
        Me.txtCname.Size = New System.Drawing.Size(415, 26)
        Me.txtCname.TabIndex = 0
        Me.txtCname.Tag = "ComName"
        Me.TTip.SetToolTip(Me.txtCname, "Enter the Company name")
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(29, 110)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(149, 20)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Company Name :"
        '
        'cbSupp
        '
        Me.cbSupp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSupp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSupp.BackColor = System.Drawing.SystemColors.Menu
        Me.cbSupp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSupp.FormattingEnabled = True
        Me.cbSupp.Items.AddRange(New Object() {"Cash", "Sundry", "OTC Sales", "Credit", "Transfer"})
        Me.cbSupp.Location = New System.Drawing.Point(240, 214)
        Me.cbSupp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbSupp.MaxDropDownItems = 15
        Me.cbSupp.Name = "cbSupp"
        Me.cbSupp.Size = New System.Drawing.Size(420, 26)
        Me.cbSupp.TabIndex = 3
        '
        'TTip
        '
        Me.TTip.AutomaticDelay = 50
        Me.TTip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TTip.IsBalloon = True
        Me.TTip.ShowAlways = True
        Me.TTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Company
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Wheat
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1365, 877)
        Me.Controls.Add(Me.pnlCompany)
        Me.ForeColor = System.Drawing.Color.Black
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Company"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCompany.ResumeLayout(False)
        Me.pnlCompany.PerformLayout()
        Me.pnlComp.ResumeLayout(False)
        CType(Me.dgCompSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.pnlCSupp.ResumeLayout(False)
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCPrd.ResumeLayout(False)
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlCompany As System.Windows.Forms.Panel
    Friend WithEvents txtCname As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtCSname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlComp As System.Windows.Forms.Panel
    Friend WithEvents dgCompSer As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCSupp As System.Windows.Forms.Panel
    Friend WithEvents dgSupp As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCPrd As System.Windows.Forms.Panel
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents lblCSupp As System.Windows.Forms.Label
    Friend WithEvents lblCProd As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents TTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbSupp As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbRack As System.Windows.Forms.ComboBox
End Class
