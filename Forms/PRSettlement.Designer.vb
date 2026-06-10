<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PRSettlement
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRSettlement))
        Me.suppliercombo = New System.Windows.Forms.ComboBox()
        Me.Supplierlabel = New System.Windows.Forms.Label()
        Me.Prgrid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblbal = New System.Windows.Forms.Label()
        Me.lblbalval = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lblgrandval = New System.Windows.Forms.Label()
        Me.Chkhide = New System.Windows.Forms.CheckBox()
        Me.gridctrl = New System.Windows.Forms.MaskedTextBox()
        Me.lblmrpv = New System.Windows.Forms.Label()
        Me.chkfilter = New System.Windows.Forms.CheckBox()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.dtfrm = New System.Windows.Forms.DateTimePicker()
        Me.lblflt = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbHlp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Prgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'suppliercombo
        '
        Me.suppliercombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.suppliercombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.suppliercombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.suppliercombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.suppliercombo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suppliercombo.FormattingEnabled = True
        Me.suppliercombo.Location = New System.Drawing.Point(119, 44)
        Me.suppliercombo.Name = "suppliercombo"
        Me.suppliercombo.Size = New System.Drawing.Size(368, 24)
        Me.suppliercombo.TabIndex = 0
        '
        'Supplierlabel
        '
        Me.Supplierlabel.AutoSize = True
        Me.Supplierlabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Supplierlabel.Location = New System.Drawing.Point(12, 48)
        Me.Supplierlabel.Name = "Supplierlabel"
        Me.Supplierlabel.Size = New System.Drawing.Size(99, 16)
        Me.Supplierlabel.TabIndex = 1
        Me.Supplierlabel.Text = "Supplier Name"
        '
        'Prgrid
        '
        Me.Prgrid.AllowUserToDeleteRows = False
        Me.Prgrid.AllowUserToResizeColumns = False
        Me.Prgrid.AllowUserToResizeRows = False
        Me.Prgrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Prgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Prgrid.BackgroundColor = System.Drawing.Color.Wheat
        Me.Prgrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Prgrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Prgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Prgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column29, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column28})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Prgrid.DefaultCellStyle = DataGridViewCellStyle9
        Me.Prgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Prgrid.EnableHeadersVisualStyles = False
        Me.Prgrid.Location = New System.Drawing.Point(4, 74)
        Me.Prgrid.Name = "Prgrid"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Prgrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.Prgrid.Size = New System.Drawing.Size(1004, 496)
        Me.Prgrid.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "Settled"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 81
        '
        'Column2
        '
        Me.Column2.HeaderText = "PR No"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 67
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Date"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Product"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 81
        '
        'Column5
        '
        Me.Column5.HeaderText = "Batch"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 67
        '
        'Column6
        '
        Me.Column6.HeaderText = "Exp. Dt."
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 88
        '
        'Column7
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column7.HeaderText = "Rate"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 60
        '
        'Column8
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column8.HeaderText = "Brk.Qty"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 81
        '
        'Column29
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column29.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column29.HeaderText = "Exp/Oth Qty."
        Me.Column29.Name = "Column29"
        Me.Column29.Width = 116
        '
        'Column9
        '
        Me.Column9.HeaderText = "Pack"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 60
        '
        'Column10
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column10.HeaderText = "Value"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 67
        '
        'Column11
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column11.HeaderText = "Adj Amount"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 102
        '
        'Column12
        '
        Me.Column12.HeaderText = "Cr Note No"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 102
        '
        'Column13
        '
        Me.Column13.HeaderText = "Cr Note Date"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 116
        '
        'Column14
        '
        Me.Column14.HeaderText = "Adj Bill No"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 109
        '
        'Column15
        '
        Me.Column15.HeaderText = "Adj Bill Date"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 123
        '
        'Column16
        '
        Me.Column16.HeaderText = "Remarks"
        Me.Column16.Name = "Column16"
        Me.Column16.Width = 81
        '
        'Column17
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column17.HeaderText = "Adj%"
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 60
        '
        'Column28
        '
        Me.Column28.HeaderText = "prid"
        Me.Column28.Name = "Column28"
        Me.Column28.Visible = False
        Me.Column28.Width = 5
        '
        'lblbal
        '
        Me.lblbal.AutoSize = True
        Me.lblbal.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbal.Location = New System.Drawing.Point(446, 589)
        Me.lblbal.Name = "lblbal"
        Me.lblbal.Size = New System.Drawing.Size(64, 16)
        Me.lblbal.TabIndex = 5
        Me.lblbal.Text = "Balance:"
        '
        'lblbalval
        '
        Me.lblbalval.AutoSize = True
        Me.lblbalval.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalval.Location = New System.Drawing.Point(544, 589)
        Me.lblbalval.Name = "lblbalval"
        Me.lblbalval.Size = New System.Drawing.Size(40, 16)
        Me.lblbalval.TabIndex = 6
        Me.lblbalval.Tag = ""
        Me.lblbalval.Text = "0.00"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(446, 621)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(92, 16)
        Me.lbltotal.TabIndex = 7
        Me.lbltotal.Text = "Grand Total:"
        '
        'lblgrandval
        '
        Me.lblgrandval.AutoSize = True
        Me.lblgrandval.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgrandval.Location = New System.Drawing.Point(544, 621)
        Me.lblgrandval.Name = "lblgrandval"
        Me.lblgrandval.Size = New System.Drawing.Size(40, 16)
        Me.lblgrandval.TabIndex = 8
        Me.lblgrandval.Text = "0.00"
        '
        'Chkhide
        '
        Me.Chkhide.AutoSize = True
        Me.Chkhide.Checked = True
        Me.Chkhide.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkhide.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkhide.Location = New System.Drawing.Point(711, 585)
        Me.Chkhide.Name = "Chkhide"
        Me.Chkhide.Size = New System.Drawing.Size(216, 20)
        Me.Chkhide.TabIndex = 10
        Me.Chkhide.Text = "Show Only Unsettled Returns"
        Me.Chkhide.UseVisualStyleBackColor = True
        '
        'gridctrl
        '
        Me.gridctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gridctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gridctrl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridctrl.Location = New System.Drawing.Point(132, 171)
        Me.gridctrl.Name = "gridctrl"
        Me.gridctrl.Size = New System.Drawing.Size(100, 22)
        Me.gridctrl.TabIndex = 13
        Me.gridctrl.Visible = False
        '
        'lblmrpv
        '
        Me.lblmrpv.AutoSize = True
        Me.lblmrpv.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmrpv.Location = New System.Drawing.Point(541, 48)
        Me.lblmrpv.Name = "lblmrpv"
        Me.lblmrpv.Size = New System.Drawing.Size(50, 16)
        Me.lblmrpv.TabIndex = 14
        Me.lblmrpv.Text = "Label1"
        Me.lblmrpv.Visible = False
        '
        'chkfilter
        '
        Me.chkfilter.AutoSize = True
        Me.chkfilter.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfilter.Location = New System.Drawing.Point(11, 576)
        Me.chkfilter.Name = "chkfilter"
        Me.chkfilter.Size = New System.Drawing.Size(69, 20)
        Me.chkfilter.TabIndex = 15
        Me.chkfilter.Text = "Filter"
        Me.chkfilter.UseVisualStyleBackColor = True
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.Wheat
        Me.pnl.Controls.Add(Me.BtnShow)
        Me.pnl.Controls.Add(Me.Label2)
        Me.pnl.Controls.Add(Me.Label1)
        Me.pnl.Controls.Add(Me.dtto)
        Me.pnl.Controls.Add(Me.dtfrm)
        Me.pnl.Location = New System.Drawing.Point(74, 576)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(345, 70)
        Me.pnl.TabIndex = 85
        Me.pnl.Visible = False
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(261, 40)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(75, 23)
        Me.BtnShow.TabIndex = 8
        Me.BtnShow.Text = "Show"
        Me.BtnShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "From"
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(226, 12)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(110, 22)
        Me.dtto.TabIndex = 1
        Me.dtto.Value = New Date(2010, 5, 19, 23, 54, 49, 0)
        '
        'dtfrm
        '
        Me.dtfrm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrm.Location = New System.Drawing.Point(51, 12)
        Me.dtfrm.Name = "dtfrm"
        Me.dtfrm.Size = New System.Drawing.Size(110, 22)
        Me.dtfrm.TabIndex = 0
        Me.dtfrm.Value = New Date(2010, 5, 19, 23, 54, 49, 0)
        '
        'lblflt
        '
        Me.lblflt.AutoSize = True
        Me.lblflt.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblflt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblflt.Location = New System.Drawing.Point(446, 605)
        Me.lblflt.Name = "lblflt"
        Me.lblflt.Size = New System.Drawing.Size(29, 16)
        Me.lblflt.TabIndex = 86
        Me.lblflt.Text = "flt"
        Me.lblflt.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbCls, Me.tsbClear, Me.tsbHlp, Me.ToolStripLabel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1020, 36)
        Me.ToolStrip.TabIndex = 97
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(80, 33)
        Me.tsbSave.Text = "&Save"
        '
        'tsbCls
        '
        Me.tsbCls.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCls.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCls.Image = CType(resources.GetObject("tsbCls.Image"), System.Drawing.Image)
        Me.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCls.Name = "tsbCls"
        Me.tsbCls.Size = New System.Drawing.Size(100, 33)
        Me.tsbCls.Text = "E&xit     "
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
        'tsbHlp
        '
        Me.tsbHlp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHlp.Image = CType(resources.GetObject("tsbHlp.Image"), System.Drawing.Image)
        Me.tsbHlp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHlp.Name = "tsbHlp"
        Me.tsbHlp.Size = New System.Drawing.Size(82, 33)
        Me.tsbHlp.Text = "     &Help     "
        Me.tsbHlp.Visible = False
        '
        'ToolStripLabel
        '
        Me.ToolStripLabel.AutoSize = False
        Me.ToolStripLabel.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel.Name = "ToolStripLabel"
        Me.ToolStripLabel.Size = New System.Drawing.Size(500, 30)
        Me.ToolStripLabel.Text = "Purchase Return Settlement"
        '
        'PRSettlement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 733)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.lblflt)
        Me.Controls.Add(Me.pnl)
        Me.Controls.Add(Me.chkfilter)
        Me.Controls.Add(Me.lblmrpv)
        Me.Controls.Add(Me.gridctrl)
        Me.Controls.Add(Me.Chkhide)
        Me.Controls.Add(Me.lblgrandval)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.lblbalval)
        Me.Controls.Add(Me.lblbal)
        Me.Controls.Add(Me.Supplierlabel)
        Me.Controls.Add(Me.suppliercombo)
        Me.Controls.Add(Me.Prgrid)
        Me.Name = "PRSettlement"
        Me.Text = "Purchase Return Settlement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Prgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl.ResumeLayout(False)
        Me.pnl.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents suppliercombo As System.Windows.Forms.ComboBox
    Friend WithEvents Supplierlabel As System.Windows.Forms.Label
    Friend WithEvents Prgrid As System.Windows.Forms.DataGridView
    Friend WithEvents lblbal As System.Windows.Forms.Label
    Friend WithEvents lblbalval As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents lblgrandval As System.Windows.Forms.Label
    Friend WithEvents Chkhide As System.Windows.Forms.CheckBox
    Friend WithEvents gridctrl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblmrpv As System.Windows.Forms.Label
    Friend WithEvents chkfilter As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfrm As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents lblflt As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbHlp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
End Class
