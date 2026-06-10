<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvAccounts
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvAccounts))
        Me.cbPat = New System.Windows.Forms.ComboBox()
        Me.lblPat = New System.Windows.Forms.Label()
        Me.grdacc = New System.Windows.Forms.DataGridView()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Received = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Payment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Particulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkshow = New System.Windows.Forms.CheckBox()
        Me.gridctrl = New System.Windows.Forms.MaskedTextBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.Comprint = New System.Windows.Forms.ToolStripButton()
        Me.tsbHlp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltot = New System.Windows.Forms.Label()
        Me.lblgtot = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.grdacc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbPat
        '
        Me.cbPat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPat.FormattingEnabled = True
        Me.cbPat.Location = New System.Drawing.Point(103, 49)
        Me.cbPat.Name = "cbPat"
        Me.cbPat.Size = New System.Drawing.Size(315, 24)
        Me.cbPat.TabIndex = 10
        '
        'lblPat
        '
        Me.lblPat.AutoSize = True
        Me.lblPat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPat.Location = New System.Drawing.Point(26, 52)
        Me.lblPat.Name = "lblPat"
        Me.lblPat.Size = New System.Drawing.Size(80, 16)
        Me.lblPat.TabIndex = 11
        Me.lblPat.Text = "Patient :"
        '
        'grdacc
        '
        Me.grdacc.AllowUserToAddRows = False
        Me.grdacc.AllowUserToResizeRows = False
        Me.grdacc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdacc.BackgroundColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdacc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdacc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdacc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BillNo, Me.BillDate, Me.Amount, Me.Received, Me.Balance, Me.Payment, Me.Id, Me.Particulars, Me.Remarks})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdacc.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdacc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdacc.EnableHeadersVisualStyles = False
        Me.grdacc.Location = New System.Drawing.Point(29, 89)
        Me.grdacc.Name = "grdacc"
        Me.grdacc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdacc.Size = New System.Drawing.Size(886, 345)
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
        'Received
        '
        Me.Received.DataPropertyName = "received"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Received.DefaultCellStyle = DataGridViewCellStyle3
        Me.Received.HeaderText = "Received"
        Me.Received.Name = "Received"
        Me.Received.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Balance
        '
        Me.Balance.DataPropertyName = "BALANCE"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Balance.DefaultCellStyle = DataGridViewCellStyle4
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Payment
        '
        Me.Payment.DataPropertyName = "PAYMENT"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Payment.DefaultCellStyle = DataGridViewCellStyle5
        Me.Payment.HeaderText = "Payment"
        Me.Payment.Name = "Payment"
        Me.Payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Id
        '
        Me.Id.DataPropertyName = "id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Particulars
        '
        Me.Particulars.HeaderText = "Particulars"
        Me.Particulars.Name = "Particulars"
        Me.Particulars.Width = 250
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 250
        '
        'chkshow
        '
        Me.chkshow.AutoSize = True
        Me.chkshow.Checked = True
        Me.chkshow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkshow.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkshow.Location = New System.Drawing.Point(29, 437)
        Me.chkshow.Name = "chkshow"
        Me.chkshow.Size = New System.Drawing.Size(163, 20)
        Me.chkshow.TabIndex = 13
        Me.chkshow.Text = "Show Only Pending"
        Me.chkshow.UseVisualStyleBackColor = True
        '
        'gridctrl
        '
        Me.gridctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gridctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gridctrl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridctrl.ForeColor = System.Drawing.Color.White
        Me.gridctrl.Location = New System.Drawing.Point(365, 168)
        Me.gridctrl.Name = "gridctrl"
        Me.gridctrl.Size = New System.Drawing.Size(100, 22)
        Me.gridctrl.TabIndex = 14
        Me.gridctrl.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCls, Me.tsbRefresh, Me.Comprint, Me.tsbHlp, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1020, 36)
        Me.ToolStrip.TabIndex = 15
        Me.ToolStrip.Text = "ToolStrip1"
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
        'tsbRefresh
        '
        Me.tsbRefresh.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbRefresh.ForeColor = System.Drawing.Color.Black
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(68, 33)
        Me.tsbRefresh.Text = "&Refresh"
        '
        'Comprint
        '
        Me.Comprint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Comprint.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comprint.Image = CType(resources.GetObject("Comprint.Image"), System.Drawing.Image)
        Me.Comprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Comprint.Name = "Comprint"
        Me.Comprint.Size = New System.Drawing.Size(52, 33)
        Me.Comprint.Text = "Print"
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(800, 22)
        Me.ToolStripLabel1.Text = "Account Receivable"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(232, 437)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Total"
        '
        'lbltot
        '
        Me.lbltot.AutoSize = True
        Me.lbltot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltot.Location = New System.Drawing.Point(314, 437)
        Me.lbltot.Name = "lbltot"
        Me.lbltot.Size = New System.Drawing.Size(40, 16)
        Me.lbltot.TabIndex = 17
        Me.lbltot.Text = "0.00"
        Me.lbltot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblgtot
        '
        Me.lblgtot.AutoSize = True
        Me.lblgtot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgtot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblgtot.Location = New System.Drawing.Point(635, 437)
        Me.lblgtot.Name = "lblgtot"
        Me.lblgtot.Size = New System.Drawing.Size(40, 16)
        Me.lblgtot.TabIndex = 19
        Me.lblgtot.Text = "0.00"
        Me.lblgtot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(503, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Grand Total"
        '
        'InvAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1020, 617)
        Me.Controls.Add(Me.lblgtot)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbltot)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gridctrl)
        Me.Controls.Add(Me.chkshow)
        Me.Controls.Add(Me.grdacc)
        Me.Controls.Add(Me.cbPat)
        Me.Controls.Add(Me.lblPat)
        Me.Name = "InvAccounts"
        Me.Text = "Accounts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdacc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPat As System.Windows.Forms.ComboBox
    Friend WithEvents lblPat As System.Windows.Forms.Label
    Friend WithEvents grdacc As System.Windows.Forms.DataGridView
    Friend WithEvents chkshow As System.Windows.Forms.CheckBox
    Friend WithEvents gridctrl As System.Windows.Forms.MaskedTextBox

    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbHlp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lbltot As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblgtot As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Received As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Particulars As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Comprint As System.Windows.Forms.ToolStripButton
End Class
