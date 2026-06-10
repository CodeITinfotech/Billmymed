<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillReturn
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillReturn))
        Me.dgInv = New System.Windows.Forms.DataGridView()
        Me.txtEdit = New System.Windows.Forms.TextBox()
        Me.CbEditUnit = New System.Windows.Forms.ComboBox()
        Me.cbEditVat = New System.Windows.Forms.ComboBox()
        Me.CbEditTaxInc = New System.Windows.Forms.ComboBox()
        Me.pnlPDet = New System.Windows.Forms.Panel()
        Me.dgBDet = New System.Windows.Forms.DataGridView()
        Me.lblBDet = New System.Windows.Forms.Label()
        Me.panInvoice = New System.Windows.Forms.Panel()
        Me.pnlprod = New System.Windows.Forms.FlowLayoutPanel()
        Me.DgProdSer = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlsales = New System.Windows.Forms.Panel()
        Me.comok = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgSales = New System.Windows.Forms.DataGridView()
        Me.Selectyn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batchid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expiry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TaxInc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNamt = New System.Windows.Forms.Label()
        Me.lNamt = New System.Windows.Forms.Label()
        Me.txtDis = New System.Windows.Forms.TextBox()
        Me.lblDisc = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        CType(Me.dgInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPDet.SuspendLayout()
        CType(Me.dgBDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panInvoice.SuspendLayout()
        Me.pnlprod.SuspendLayout()
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlsales.SuspendLayout()
        CType(Me.DgSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgInv
        '
        Me.dgInv.AllowUserToAddRows = False
        Me.dgInv.AllowUserToDeleteRows = False
        Me.dgInv.AllowUserToOrderColumns = True
        Me.dgInv.AllowUserToResizeRows = False
        Me.dgInv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgInv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgInv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgInv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgInv.EnableHeadersVisualStyles = False
        Me.dgInv.Location = New System.Drawing.Point(12, 85)
        Me.dgInv.MultiSelect = False
        Me.dgInv.Name = "dgInv"
        Me.dgInv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgInv.RowHeadersVisible = False
        Me.dgInv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgInv.RowTemplate.Height = 24
        Me.dgInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgInv.Size = New System.Drawing.Size(992, 323)
        Me.dgInv.StandardTab = True
        Me.dgInv.TabIndex = 5
        '
        'txtEdit
        '
        Me.txtEdit.BackColor = System.Drawing.Color.LightGreen
        Me.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdit.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdit.ForeColor = System.Drawing.Color.Black
        Me.txtEdit.Location = New System.Drawing.Point(254, 118)
        Me.txtEdit.MaxLength = 50
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.Size = New System.Drawing.Size(183, 24)
        Me.txtEdit.TabIndex = 6
        Me.txtEdit.Tag = "PrdName"
        Me.txtEdit.Visible = False
        '
        'CbEditUnit
        '
        Me.CbEditUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbEditUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbEditUnit.BackColor = System.Drawing.Color.White
        Me.CbEditUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEditUnit.DropDownWidth = 74
        Me.CbEditUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbEditUnit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbEditUnit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CbEditUnit.FormattingEnabled = True
        Me.CbEditUnit.ItemHeight = 16
        Me.CbEditUnit.Location = New System.Drawing.Point(38, 241)
        Me.CbEditUnit.MaxDropDownItems = 15
        Me.CbEditUnit.Name = "CbEditUnit"
        Me.CbEditUnit.Size = New System.Drawing.Size(74, 24)
        Me.CbEditUnit.TabIndex = 0
        '
        'cbEditVat
        '
        Me.cbEditVat.BackColor = System.Drawing.Color.White
        Me.cbEditVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEditVat.DropDownWidth = 3
        Me.cbEditVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbEditVat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEditVat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbEditVat.FormattingEnabled = True
        Me.cbEditVat.Location = New System.Drawing.Point(753, 211)
        Me.cbEditVat.Name = "cbEditVat"
        Me.cbEditVat.Size = New System.Drawing.Size(74, 24)
        Me.cbEditVat.TabIndex = 1
        Me.cbEditVat.Visible = False
        '
        'CbEditTaxInc
        '
        Me.CbEditTaxInc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbEditTaxInc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbEditTaxInc.BackColor = System.Drawing.Color.White
        Me.CbEditTaxInc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEditTaxInc.DropDownWidth = 3
        Me.CbEditTaxInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbEditTaxInc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbEditTaxInc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CbEditTaxInc.FormattingEnabled = True
        Me.CbEditTaxInc.Items.AddRange(New Object() {"Yes", "No"})
        Me.CbEditTaxInc.Location = New System.Drawing.Point(753, 270)
        Me.CbEditTaxInc.MaxDropDownItems = 15
        Me.CbEditTaxInc.Name = "CbEditTaxInc"
        Me.CbEditTaxInc.Size = New System.Drawing.Size(74, 24)
        Me.CbEditTaxInc.TabIndex = 2
        Me.CbEditTaxInc.Visible = False
        '
        'pnlPDet
        '
        Me.pnlPDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPDet.BackColor = System.Drawing.Color.LightGreen
        Me.pnlPDet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPDet.Controls.Add(Me.dgBDet)
        Me.pnlPDet.Controls.Add(Me.lblBDet)
        Me.pnlPDet.Location = New System.Drawing.Point(12, 414)
        Me.pnlPDet.Name = "pnlPDet"
        Me.pnlPDet.Size = New System.Drawing.Size(995, 168)
        Me.pnlPDet.TabIndex = 39
        Me.pnlPDet.Visible = False
        '
        'dgBDet
        '
        Me.dgBDet.AllowUserToAddRows = False
        Me.dgBDet.AllowUserToDeleteRows = False
        Me.dgBDet.AllowUserToOrderColumns = True
        Me.dgBDet.AllowUserToResizeRows = False
        Me.dgBDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBDet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgBDet.BackgroundColor = System.Drawing.Color.LightGreen
        Me.dgBDet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgBDet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgBDet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBDet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgBDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.NullValue = " "
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBDet.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgBDet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgBDet.EnableHeadersVisualStyles = False
        Me.dgBDet.Location = New System.Drawing.Point(6, 19)
        Me.dgBDet.MultiSelect = False
        Me.dgBDet.Name = "dgBDet"
        Me.dgBDet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgBDet.RowHeadersVisible = False
        Me.dgBDet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgBDet.RowTemplate.Height = 24
        Me.dgBDet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgBDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBDet.Size = New System.Drawing.Size(978, 144)
        Me.dgBDet.TabIndex = 0
        '
        'lblBDet
        '
        Me.lblBDet.AutoSize = True
        Me.lblBDet.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBDet.ForeColor = System.Drawing.Color.Red
        Me.lblBDet.Location = New System.Drawing.Point(3, 0)
        Me.lblBDet.Name = "lblBDet"
        Me.lblBDet.Size = New System.Drawing.Size(36, 16)
        Me.lblBDet.TabIndex = 1
        Me.lblBDet.Text = "Name"
        '
        'panInvoice
        '
        Me.panInvoice.AutoSize = True
        Me.panInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panInvoice.BackColor = System.Drawing.Color.LightGreen
        Me.panInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panInvoice.Controls.Add(Me.pnlprod)
        Me.panInvoice.Controls.Add(Me.txtEdit)
        Me.panInvoice.Controls.Add(Me.pnlsales)
        Me.panInvoice.Controls.Add(Me.CbEditUnit)
        Me.panInvoice.Controls.Add(Me.pnlPDet)
        Me.panInvoice.Controls.Add(Me.ToolStrip)
        Me.panInvoice.Controls.Add(Me.GroupBox2)
        Me.panInvoice.Controls.Add(Me.txtDis)
        Me.panInvoice.Controls.Add(Me.lblDisc)
        Me.panInvoice.Controls.Add(Me.CbEditTaxInc)
        Me.panInvoice.Controls.Add(Me.cbEditVat)
        Me.panInvoice.Controls.Add(Me.dgInv)
        Me.panInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panInvoice.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panInvoice.Location = New System.Drawing.Point(0, 0)
        Me.panInvoice.Name = "panInvoice"
        Me.panInvoice.Size = New System.Drawing.Size(1020, 703)
        Me.panInvoice.TabIndex = 0
        '
        'pnlprod
        '
        Me.pnlprod.AutoSize = True
        Me.pnlprod.BackColor = System.Drawing.Color.Wheat
        Me.pnlprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlprod.Controls.Add(Me.DgProdSer)
        Me.pnlprod.Location = New System.Drawing.Point(406, 85)
        Me.pnlprod.Name = "pnlprod"
        Me.pnlprod.Size = New System.Drawing.Size(589, 414)
        Me.pnlprod.TabIndex = 177
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgProdSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgProdSer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Rack, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgProdSer.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgProdSer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgProdSer.EnableHeadersVisualStyles = False
        Me.DgProdSer.Location = New System.Drawing.Point(3, 3)
        Me.DgProdSer.Name = "DgProdSer"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DgProdSer.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.DgProdSer.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DgProdSer.RowTemplate.Height = 28
        Me.DgProdSer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgProdSer.Size = New System.Drawing.Size(581, 406)
        Me.DgProdSer.TabIndex = 3
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "#"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
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
        Me.DataGridViewTextBoxColumn5.Width = 73
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
        Me.DataGridViewTextBoxColumn6.Width = 89
        '
        'pnlsales
        '
        Me.pnlsales.BackColor = System.Drawing.Color.LightGreen
        Me.pnlsales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlsales.Controls.Add(Me.comok)
        Me.pnlsales.Controls.Add(Me.Label2)
        Me.pnlsales.Controls.Add(Me.DgSales)
        Me.pnlsales.Location = New System.Drawing.Point(77, 39)
        Me.pnlsales.Name = "pnlsales"
        Me.pnlsales.Size = New System.Drawing.Size(886, 297)
        Me.pnlsales.TabIndex = 184
        Me.pnlsales.Visible = False
        '
        'comok
        '
        Me.comok.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comok.Location = New System.Drawing.Point(354, 258)
        Me.comok.Name = "comok"
        Me.comok.Size = New System.Drawing.Size(75, 23)
        Me.comok.TabIndex = 186
        Me.comok.Text = "O&k"
        Me.comok.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGreen
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(15, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 185
        Me.Label2.Text = "Select the Product"
        '
        'DgSales
        '
        Me.DgSales.AllowUserToAddRows = False
        Me.DgSales.AllowUserToDeleteRows = False
        Me.DgSales.AllowUserToOrderColumns = True
        Me.DgSales.AllowUserToResizeRows = False
        Me.DgSales.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgSales.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DgSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgSales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selectyn, Me.Unit, Me.Code, Me.Batchid, Me.ProdName, Me.Qty, Me.Pack, Me.Batch, Me.Expiry, Me.SRate, Me.vat, Me.TaxInc, Me.RT})
        Me.DgSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgSales.EnableHeadersVisualStyles = False
        Me.DgSales.Location = New System.Drawing.Point(6, 30)
        Me.DgSales.MultiSelect = False
        Me.DgSales.Name = "DgSales"
        Me.DgSales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DgSales.RowHeadersVisible = False
        Me.DgSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgSales.RowTemplate.Height = 24
        Me.DgSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgSales.Size = New System.Drawing.Size(875, 221)
        Me.DgSales.StandardTab = True
        Me.DgSales.TabIndex = 184
        '
        'Selectyn
        '
        Me.Selectyn.HeaderText = "Return ?"
        Me.Selectyn.Name = "Selectyn"
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Unit.Visible = False
        '
        'Code
        '
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.Visible = False
        '
        'Batchid
        '
        Me.Batchid.HeaderText = "Batchid"
        Me.Batchid.Name = "Batchid"
        Me.Batchid.Visible = False
        '
        'ProdName
        '
        Me.ProdName.HeaderText = "Product Name"
        Me.ProdName.Name = "ProdName"
        Me.ProdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProdName.Width = 250
        '
        'Qty
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle10
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Pack
        '
        Me.Pack.HeaderText = "Pack"
        Me.Pack.Name = "Pack"
        Me.Pack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Batch
        '
        Me.Batch.HeaderText = "Batch"
        Me.Batch.Name = "Batch"
        '
        'Expiry
        '
        Me.Expiry.HeaderText = "Expiry"
        Me.Expiry.Name = "Expiry"
        '
        'SRate
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.SRate.DefaultCellStyle = DataGridViewCellStyle11
        Me.SRate.HeaderText = "SRate"
        Me.SRate.Name = "SRate"
        Me.SRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'vat
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.vat.DefaultCellStyle = DataGridViewCellStyle12
        Me.vat.HeaderText = "VAT%"
        Me.vat.Name = "vat"
        Me.vat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TaxInc
        '
        Me.TaxInc.HeaderText = "TaxInc"
        Me.TaxInc.Name = "TaxInc"
        Me.TaxInc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RT
        '
        Me.RT.HeaderText = "RT%"
        Me.RT.Name = "RT"
        Me.RT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RT.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCls, Me.tsbClear, Me.ToolStripLabel1, Me.ToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1016, 36)
        Me.ToolStrip.TabIndex = 187
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbCls
        '
        Me.tsbCls.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCls.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCls.ForeColor = System.Drawing.Color.DarkBlue
        Me.tsbCls.Image = CType(resources.GetObject("tsbCls.Image"), System.Drawing.Image)
        Me.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCls.Name = "tsbCls"
        Me.tsbCls.Size = New System.Drawing.Size(68, 33)
        Me.tsbCls.Text = "&Close"
        '
        'tsbClear
        '
        Me.tsbClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClear.AutoSize = False
        Me.tsbClear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClear.ForeColor = System.Drawing.Color.DarkBlue
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(80, 30)
        Me.tsbClear.Text = "&Clear"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(260, 22)
        Me.ToolStripLabel1.Text = "Sales Return"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 33)
        Me.ToolStripButton1.Text = "From Sales"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblNamt)
        Me.GroupBox2.Controls.Add(Me.lNamt)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 548)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 105)
        Me.GroupBox2.TabIndex = 186
        Me.GroupBox2.TabStop = False
        '
        'lblNamt
        '
        Me.lblNamt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNamt.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamt.ForeColor = System.Drawing.Color.Red
        Me.lblNamt.Location = New System.Drawing.Point(871, 46)
        Me.lblNamt.Name = "lblNamt"
        Me.lblNamt.Size = New System.Drawing.Size(115, 18)
        Me.lblNamt.TabIndex = 172
        Me.lblNamt.Text = "0.00"
        Me.lblNamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lNamt
        '
        Me.lNamt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lNamt.AutoSize = True
        Me.lNamt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lNamt.Location = New System.Drawing.Point(761, 48)
        Me.lNamt.Name = "lNamt"
        Me.lNamt.Size = New System.Drawing.Size(104, 16)
        Me.lNamt.TabIndex = 170
        Me.lNamt.Text = "Net Amount :"
        '
        'txtDis
        '
        Me.txtDis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDis.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDis.Location = New System.Drawing.Point(103, 57)
        Me.txtDis.MaxLength = 10
        Me.txtDis.Name = "txtDis"
        Me.txtDis.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDis.Size = New System.Drawing.Size(73, 22)
        Me.txtDis.TabIndex = 164
        '
        'lblDisc
        '
        Me.lblDisc.AutoSize = True
        Me.lblDisc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisc.Location = New System.Drawing.Point(25, 57)
        Me.lblDisc.Name = "lblDisc"
        Me.lblDisc.Size = New System.Drawing.Size(72, 16)
        Me.lblDisc.TabIndex = 168
        Me.lblDisc.Text = "Disc % :"
        '
        'BillReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(1020, 703)
        Me.Controls.Add(Me.panInvoice)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "BillReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sales Return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPDet.ResumeLayout(False)
        Me.pnlPDet.PerformLayout()
        CType(Me.dgBDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panInvoice.ResumeLayout(False)
        Me.panInvoice.PerformLayout()
        Me.pnlprod.ResumeLayout(False)
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlsales.ResumeLayout(False)
        Me.pnlsales.PerformLayout()
        CType(Me.DgSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgInv As System.Windows.Forms.DataGridView
    Friend WithEvents txtEdit As System.Windows.Forms.TextBox
    Friend WithEvents CbEditUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cbEditVat As System.Windows.Forms.ComboBox
    Friend WithEvents CbEditTaxInc As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPDet As System.Windows.Forms.Panel
    Friend WithEvents lblBDet As System.Windows.Forms.Label
    Friend WithEvents dgBDet As System.Windows.Forms.DataGridView
    Friend WithEvents panInvoice As System.Windows.Forms.Panel
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents pnlprod As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtDis As System.Windows.Forms.TextBox
    Friend WithEvents lblDisc As System.Windows.Forms.Label
    Friend WithEvents pnlsales As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgSales As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comok As System.Windows.Forms.Button
    Friend WithEvents DgProdSer As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selectyn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batchid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxInc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNamt As System.Windows.Forms.Label
    Friend WithEvents lNamt As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
