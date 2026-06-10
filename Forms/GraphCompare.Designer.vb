<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphCompare
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlprod = New System.Windows.Forms.FlowLayoutPanel()
        Me.DgProdSer = New System.Windows.Forms.DataGridView()
        Me.dtf = New System.Windows.Forms.DateTimePicker()
        Me.dtt = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txtcode = New System.Windows.Forms.TextBox()
        Me.Txtname = New System.Windows.Forms.TextBox()
        Me.txtpack = New System.Windows.Forms.TextBox()
        Me.cb = New System.Windows.Forms.ComboBox()
        Me.lst = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnview = New System.Windows.Forms.Button()
        Me.chkmon = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblc = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnlprod.SuspendLayout()
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlprod
        '
        Me.pnlprod.BackColor = System.Drawing.Color.Wheat
        Me.pnlprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlprod.Controls.Add(Me.DgProdSer)
        Me.pnlprod.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlprod.Location = New System.Drawing.Point(266, 81)
        Me.pnlprod.Name = "pnlprod"
        Me.pnlprod.Size = New System.Drawing.Size(633, 275)
        Me.pnlprod.TabIndex = 172
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgProdSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgProdSer.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgProdSer.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgProdSer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgProdSer.EnableHeadersVisualStyles = False
        Me.DgProdSer.Location = New System.Drawing.Point(3, 3)
        Me.DgProdSer.Name = "DgProdSer"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgProdSer.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgProdSer.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DgProdSer.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgProdSer.RowTemplate.Height = 28
        Me.DgProdSer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgProdSer.Size = New System.Drawing.Size(629, 271)
        Me.DgProdSer.TabIndex = 2
        '
        'dtf
        '
        Me.dtf.CalendarTitleBackColor = System.Drawing.Color.Chocolate
        Me.dtf.CustomFormat = "dd/MM/yyyy"
        Me.dtf.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtf.Location = New System.Drawing.Point(52, 14)
        Me.dtf.Name = "dtf"
        Me.dtf.Size = New System.Drawing.Size(123, 22)
        Me.dtf.TabIndex = 163
        '
        'dtt
        '
        Me.dtt.CalendarTitleBackColor = System.Drawing.Color.Chocolate
        Me.dtt.CustomFormat = "dd/MM/yyyy"
        Me.dtt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtt.Location = New System.Drawing.Point(52, 41)
        Me.dtt.Name = "dtt"
        Me.dtt.Size = New System.Drawing.Size(123, 22)
        Me.dtt.TabIndex = 164
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 16)
        Me.Label8.TabIndex = 166
        Me.Label8.Text = "To"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(885, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 167
        Me.Label9.Text = "Code :"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(196, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "Name "
        '
        'Txtcode
        '
        Me.Txtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcode.Location = New System.Drawing.Point(625, 49)
        Me.Txtcode.Name = "Txtcode"
        Me.Txtcode.Size = New System.Drawing.Size(37, 20)
        Me.Txtcode.TabIndex = 169
        Me.Txtcode.Tag = "PrdCode"
        Me.Txtcode.Visible = False
        '
        'Txtname
        '
        Me.Txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtname.Location = New System.Drawing.Point(266, 43)
        Me.Txtname.Name = "Txtname"
        Me.Txtname.Size = New System.Drawing.Size(236, 22)
        Me.Txtname.TabIndex = 170
        Me.Txtname.Tag = "PrdName"
        '
        'txtpack
        '
        Me.txtpack.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpack.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpack.Location = New System.Drawing.Point(508, 43)
        Me.txtpack.Name = "txtpack"
        Me.txtpack.Size = New System.Drawing.Size(111, 22)
        Me.txtpack.TabIndex = 171
        Me.txtpack.Tag = "PrdCode"
        '
        'cb
        '
        Me.cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb.FormattingEnabled = True
        Me.cb.Items.AddRange(New Object() {"---- Sales ----", "", "Product  (Qty)", "Product  (Value)", "Company ", "Classification ", "Group1", "Group2 ", "", "---- Purchase  ----", "", "Supplier ", "", "---- Profit  ----", "", "Product ", "Company ", "Classification ", "Group1 ", "Group2  "})
        Me.cb.Location = New System.Drawing.Point(266, 10)
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(166, 24)
        Me.cb.TabIndex = 173
        '
        'lst
        '
        Me.lst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst.FormattingEnabled = True
        Me.lst.ItemHeight = 16
        Me.lst.Location = New System.Drawing.Point(625, 4)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(217, 68)
        Me.lst.TabIndex = 174
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Compare"
        '
        'btnview
        '
        Me.btnview.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(848, 37)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 28)
        Me.btnview.TabIndex = 176
        Me.btnview.Text = "View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'chkmon
        '
        Me.chkmon.AutoSize = True
        Me.chkmon.Checked = True
        Me.chkmon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkmon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmon.Location = New System.Drawing.Point(508, 12)
        Me.chkmon.Name = "chkmon"
        Me.chkmon.Size = New System.Drawing.Size(83, 20)
        Me.chkmon.TabIndex = 179
        Me.chkmon.Text = "Monthly"
        Me.chkmon.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblc)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lst)
        Me.Panel1.Controls.Add(Me.dtf)
        Me.Panel1.Controls.Add(Me.chkmon)
        Me.Panel1.Controls.Add(Me.dtt)
        Me.Panel1.Controls.Add(Me.btnview)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cb)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtpack)
        Me.Panel1.Controls.Add(Me.Txtcode)
        Me.Panel1.Controls.Add(Me.Txtname)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 75)
        Me.Panel1.TabIndex = 181
        '
        'lblc
        '
        Me.lblc.AutoSize = True
        Me.lblc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc.Location = New System.Drawing.Point(438, 13)
        Me.lblc.Name = "lblc"
        Me.lblc.Size = New System.Drawing.Size(64, 16)
        Me.lblc.TabIndex = 180
        Me.lblc.Text = "Compare"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.crv)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(926, 629)
        Me.Panel2.TabIndex = 182
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crv.Location = New System.Drawing.Point(0, 75)
        Me.crv.Margin = New System.Windows.Forms.Padding(0)
        Me.crv.Name = "crv"
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowParameterPanelButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.Size = New System.Drawing.Size(926, 554)
        Me.crv.TabIndex = 181
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ToolPanelWidth = 2
        '
        'GraphCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(926, 629)
        Me.Controls.Add(Me.pnlprod)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "GraphCompare"
        Me.Text = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlprod.ResumeLayout(False)
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlprod As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents DgProdSer As System.Windows.Forms.DataGridView
    Friend WithEvents dtf As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Txtname As System.Windows.Forms.TextBox
    Friend WithEvents txtpack As System.Windows.Forms.TextBox
    Friend WithEvents cb As System.Windows.Forms.ComboBox
    Friend WithEvents lst As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents chkmon As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblc As System.Windows.Forms.Label
End Class
