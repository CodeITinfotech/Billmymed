<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardSales
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CardSales))
        Me.grdacc = New System.Windows.Forms.DataGridView()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridctrl = New System.Windows.Forms.MaskedTextBox()

        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.lbltotc1 = New System.Windows.Forms.Label()
        Me.lbltot1 = New System.Windows.Forms.Label()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtccard = New System.Windows.Forms.TextBox()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.cbccard = New System.Windows.Forms.ComboBox()
        Me.lbltot2 = New System.Windows.Forms.Label()
        Me.lbltotc2 = New System.Windows.Forms.Label()
        Me.lbltot3 = New System.Windows.Forms.Label()
        Me.lbltotc3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrmk = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.chk = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl23 = New System.Windows.Forms.Label()
        Me.lbl22 = New System.Windows.Forms.Label()
        Me.lbl21 = New System.Windows.Forms.Label()
        Me.lbl53 = New System.Windows.Forms.Label()
        Me.lbl52 = New System.Windows.Forms.Label()
        Me.lbl51 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl5tot = New System.Windows.Forms.Label()
        Me.lbl2tot = New System.Windows.Forms.Label()
        Me.lbltotot = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.totbills = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblrcpt = New System.Windows.Forms.Label()
        CType(Me.grdacc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdacc
        '
        Me.grdacc.AllowUserToAddRows = False
        Me.grdacc.AllowUserToResizeRows = False
        Me.grdacc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdacc.BackgroundColor = System.Drawing.Color.Wheat
        Me.grdacc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdacc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdacc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdacc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BillNo, Me.BillDate, Me.Amount, Me.Id})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdacc.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdacc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdacc.EnableHeadersVisualStyles = False
        Me.grdacc.Location = New System.Drawing.Point(33, 118)
        Me.grdacc.Name = "grdacc"
        Me.grdacc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdacc.Size = New System.Drawing.Size(468, 457)
        Me.grdacc.TabIndex = 12
        '
        'BillNo
        '
        Me.BillNo.DataPropertyName = "bill no"
        Me.BillNo.HeaderText = "Bill No"
        Me.BillNo.Name = "BillNo"
        Me.BillNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'BillDate
        '
        Me.BillDate.DataPropertyName = "BILL DATE"
        Me.BillDate.HeaderText = "Bill Date"
        Me.BillDate.Name = "BillDate"
        Me.BillDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.BillDate.Width = 150
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "amount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle2
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Id
        '
        Me.Id.DataPropertyName = "id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'gridctrl
        '
        Me.gridctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gridctrl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridctrl.ForeColor = System.Drawing.Color.White
        Me.gridctrl.Location = New System.Drawing.Point(324, 172)
        Me.gridctrl.Name = "gridctrl"
        Me.gridctrl.Size = New System.Drawing.Size(100, 22)
        Me.gridctrl.TabIndex = 14
        Me.gridctrl.Visible = False
        '
        'PrintForm1
    
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefresh, Me.ToolStripLabel1, Me.tsbCls, Me.tsbClear})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1020, 36)
        Me.ToolStrip.TabIndex = 15
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbRefresh.ForeColor = System.Drawing.Color.Black
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(68, 33)
        Me.tsbRefresh.Text = "&Refresh"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(600, 30)
        Me.ToolStripLabel1.Text = "Loyalty Sales"
        '
        'tsbCls
        '
        Me.tsbCls.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCls.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCls.Image = CType(resources.GetObject("tsbCls.Image"), System.Drawing.Image)
        Me.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCls.Name = "tsbCls"
        Me.tsbCls.Size = New System.Drawing.Size(91, 33)
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
        'lbltotc1
        '
        Me.lbltotc1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltotc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotc1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotc1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbltotc1.Location = New System.Drawing.Point(507, 399)
        Me.lbltotc1.Name = "lbltotc1"
        Me.lbltotc1.Size = New System.Drawing.Size(154, 27)
        Me.lbltotc1.TabIndex = 16
        Me.lbltotc1.Text = "Total"
        Me.lbltotc1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltot1
        '
        Me.lbltot1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltot1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltot1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbltot1.Location = New System.Drawing.Point(667, 399)
        Me.lbltot1.Name = "lbltot1"
        Me.lbltot1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltot1.Size = New System.Drawing.Size(133, 27)
        Me.lbltot1.TabIndex = 17
        Me.lbltot1.Text = "0.00"
        Me.lbltot1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl5
        '
        Me.lbl5.AutoSize = True
        Me.lbl5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5.ForeColor = System.Drawing.Color.Black
        Me.lbl5.Location = New System.Drawing.Point(30, 78)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(56, 16)
        Me.lbl5.TabIndex = 178
        Me.lbl5.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Card No :"
        '
        'txtccard
        '
        Me.txtccard.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtccard.Location = New System.Drawing.Point(116, 48)
        Me.txtccard.Name = "txtccard"
        Me.txtccard.Size = New System.Drawing.Size(88, 22)
        Me.txtccard.TabIndex = 176
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMMM yyyy"
        Me.dtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(601, 75)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(202, 22)
        Me.dtp.TabIndex = 180
        '
        'cbccard
        '
        Me.cbccard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbccard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbccard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbccard.FormattingEnabled = True
        Me.cbccard.Location = New System.Drawing.Point(116, 76)
        Me.cbccard.Name = "cbccard"
        Me.cbccard.Size = New System.Drawing.Size(370, 21)
        Me.cbccard.TabIndex = 181
        '
        'lbltot2
        '
        Me.lbltot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltot2.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltot2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltot2.Location = New System.Drawing.Point(667, 511)
        Me.lbltot2.Name = "lbltot2"
        Me.lbltot2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltot2.Size = New System.Drawing.Size(133, 27)
        Me.lbltot2.TabIndex = 183
        Me.lbltot2.Text = "0.00"
        Me.lbltot2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltotc2
        '
        Me.lbltotc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotc2.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotc2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltotc2.Location = New System.Drawing.Point(507, 511)
        Me.lbltotc2.Name = "lbltotc2"
        Me.lbltotc2.Size = New System.Drawing.Size(154, 27)
        Me.lbltotc2.TabIndex = 182
        Me.lbltotc2.Text = "Total"
        Me.lbltotc2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltot3
        '
        Me.lbltot3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltot3.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltot3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltot3.Location = New System.Drawing.Point(667, 581)
        Me.lbltot3.Name = "lbltot3"
        Me.lbltot3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltot3.Size = New System.Drawing.Size(133, 27)
        Me.lbltot3.TabIndex = 185
        Me.lbltot3.Text = "0.00"
        Me.lbltot3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbltot3.Visible = False
        '
        'lbltotc3
        '
        Me.lbltotc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotc3.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotc3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltotc3.Location = New System.Drawing.Point(507, 581)
        Me.lbltotc3.Name = "lbltotc3"
        Me.lbltotc3.Size = New System.Drawing.Size(154, 27)
        Me.lbltotc3.TabIndex = 184
        Me.lbltotc3.Text = "Total"
        Me.lbltotc3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbltotc3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(523, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 186
        Me.Label1.Text = "Month"
        '
        'txtrmk
        '
        Me.txtrmk.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrmk.Location = New System.Drawing.Point(526, 172)
        Me.txtrmk.Name = "txtrmk"
        Me.txtrmk.Size = New System.Drawing.Size(277, 24)
        Me.txtrmk.TabIndex = 187
        Me.txtrmk.Text = "Settled"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(523, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Remarks"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(728, 202)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 189
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk.Location = New System.Drawing.Point(526, 203)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(97, 22)
        Me.chk.TabIndex = 190
        Me.chk.Text = "Settled"
        Me.chk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(558, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "Month"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(752, 373)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Sales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(861, 373)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "2 %"
        '
        'lbl23
        '
        Me.lbl23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl23.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl23.Location = New System.Drawing.Point(818, 581)
        Me.lbl23.Name = "lbl23"
        Me.lbl23.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl23.Size = New System.Drawing.Size(75, 27)
        Me.lbl23.TabIndex = 196
        Me.lbl23.Text = "0.00"
        Me.lbl23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl23.Visible = False
        '
        'lbl22
        '
        Me.lbl22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl22.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl22.Location = New System.Drawing.Point(818, 511)
        Me.lbl22.Name = "lbl22"
        Me.lbl22.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl22.Size = New System.Drawing.Size(75, 27)
        Me.lbl22.TabIndex = 195
        Me.lbl22.Text = "0.00"
        Me.lbl22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl21
        '
        Me.lbl21.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl21.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl21.Location = New System.Drawing.Point(818, 399)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl21.Size = New System.Drawing.Size(75, 27)
        Me.lbl21.TabIndex = 194
        Me.lbl21.Text = "0.00"
        Me.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl53
        '
        Me.lbl53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl53.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl53.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl53.Location = New System.Drawing.Point(899, 581)
        Me.lbl53.Name = "lbl53"
        Me.lbl53.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl53.Size = New System.Drawing.Size(75, 27)
        Me.lbl53.TabIndex = 200
        Me.lbl53.Text = "0.00"
        Me.lbl53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl53.Visible = False
        '
        'lbl52
        '
        Me.lbl52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl52.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl52.Location = New System.Drawing.Point(899, 511)
        Me.lbl52.Name = "lbl52"
        Me.lbl52.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl52.Size = New System.Drawing.Size(75, 27)
        Me.lbl52.TabIndex = 199
        Me.lbl52.Text = "0.00"
        Me.lbl52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl52.Visible = False
        '
        'lbl51
        '
        Me.lbl51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl51.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl51.Location = New System.Drawing.Point(899, 399)
        Me.lbl51.Name = "lbl51"
        Me.lbl51.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl51.Size = New System.Drawing.Size(75, 27)
        Me.lbl51.TabIndex = 198
        Me.lbl51.Text = "0.00"
        Me.lbl51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl51.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(942, 373)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 16)
        Me.Label13.TabIndex = 197
        Me.Label13.Text = "5 %"
        Me.Label13.Visible = False
        '
        'lbl5tot
        '
        Me.lbl5tot.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbl5tot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl5tot.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5tot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl5tot.Location = New System.Drawing.Point(899, 548)
        Me.lbl5tot.Name = "lbl5tot"
        Me.lbl5tot.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl5tot.Size = New System.Drawing.Size(75, 27)
        Me.lbl5tot.TabIndex = 204
        Me.lbl5tot.Text = "0.00"
        Me.lbl5tot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl5tot.Visible = False
        '
        'lbl2tot
        '
        Me.lbl2tot.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbl2tot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl2tot.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2tot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl2tot.Location = New System.Drawing.Point(818, 548)
        Me.lbl2tot.Name = "lbl2tot"
        Me.lbl2tot.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl2tot.Size = New System.Drawing.Size(75, 27)
        Me.lbl2tot.TabIndex = 203
        Me.lbl2tot.Text = "0.00"
        Me.lbl2tot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltotot
        '
        Me.lbltotot.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbltotot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotot.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltotot.Location = New System.Drawing.Point(667, 548)
        Me.lbltotot.Name = "lbltotot"
        Me.lbltotot.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltotot.Size = New System.Drawing.Size(133, 27)
        Me.lbltotot.TabIndex = 202
        Me.lbltotot.Text = "0.00"
        Me.lbltotot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(507, 548)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(154, 27)
        Me.lbl.TabIndex = 201
        Me.lbl.Text = "Total"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'totbills
        '
        Me.totbills.AutoSize = True
        Me.totbills.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totbills.ForeColor = System.Drawing.Color.Black
        Me.totbills.Location = New System.Drawing.Point(598, 118)
        Me.totbills.Name = "totbills"
        Me.totbills.Size = New System.Drawing.Size(0, 16)
        Me.totbills.TabIndex = 205
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(523, 279)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Receivable"
        '
        'lblrcpt
        '
        Me.lblrcpt.AutoSize = True
        Me.lblrcpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrcpt.ForeColor = System.Drawing.Color.Black
        Me.lblrcpt.Location = New System.Drawing.Point(639, 279)
        Me.lblrcpt.Name = "lblrcpt"
        Me.lblrcpt.Size = New System.Drawing.Size(48, 16)
        Me.lblrcpt.TabIndex = 207
        Me.lblrcpt.Text = "Month"
        '
        'CardSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1020, 617)
        Me.Controls.Add(Me.lblrcpt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.totbills)
        Me.Controls.Add(Me.lbl5tot)
        Me.Controls.Add(Me.lbl2tot)
        Me.Controls.Add(Me.lbltotot)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.lbl53)
        Me.Controls.Add(Me.lbl52)
        Me.Controls.Add(Me.lbl51)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lbl23)
        Me.Controls.Add(Me.lbl22)
        Me.Controls.Add(Me.lbl21)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtrmk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbltot3)
        Me.Controls.Add(Me.lbltotc3)
        Me.Controls.Add(Me.lbltot2)
        Me.Controls.Add(Me.lbltotc2)
        Me.Controls.Add(Me.cbccard)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.lbl5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtccard)
        Me.Controls.Add(Me.lbltot1)
        Me.Controls.Add(Me.lbltotc1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gridctrl)
        Me.Controls.Add(Me.grdacc)
        Me.Name = "CardSales"
        Me.Text = "Loyalty  Sales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdacc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdacc As System.Windows.Forms.DataGridView
    Friend WithEvents gridctrl As System.Windows.Forms.MaskedTextBox

    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbltot1 As System.Windows.Forms.Label
    Friend WithEvents lbltotc1 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtccard As System.Windows.Forms.TextBox
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbccard As System.Windows.Forms.ComboBox
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbltot3 As System.Windows.Forms.Label
    Friend WithEvents lbltotc3 As System.Windows.Forms.Label
    Friend WithEvents lbltot2 As System.Windows.Forms.Label
    Friend WithEvents lbltotc2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtrmk As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk As System.Windows.Forms.CheckBox
    Friend WithEvents lbl53 As System.Windows.Forms.Label
    Friend WithEvents lbl52 As System.Windows.Forms.Label
    Friend WithEvents lbl51 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl23 As System.Windows.Forms.Label
    Friend WithEvents lbl22 As System.Windows.Forms.Label
    Friend WithEvents lbl21 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl5tot As System.Windows.Forms.Label
    Friend WithEvents lbl2tot As System.Windows.Forms.Label
    Friend WithEvents lbltotot As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents totbills As System.Windows.Forms.Label
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblrcpt As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
