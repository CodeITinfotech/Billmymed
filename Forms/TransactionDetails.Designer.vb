<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionDetails
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtf = New System.Windows.Forms.DateTimePicker()
        Me.dtt = New System.Windows.Forms.DateTimePicker()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.OptSales = New System.Windows.Forms.RadioButton()
        Me.OptPurch = New System.Windows.Forms.RadioButton()
        Me.optord = New System.Windows.Forms.RadioButton()
        Me.comview = New System.Windows.Forms.Button()
        Me.lblPRsup = New System.Windows.Forms.Label()
        Me.cbsupp = New System.Windows.Forms.ComboBox()
        Me.CB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(202, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From"
        '
        'dtf
        '
        Me.dtf.CalendarFont = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtf.CustomFormat = "dd/MM/yyyy"
        Me.dtf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtf.Location = New System.Drawing.Point(66, 43)
        Me.dtf.Name = "dtf"
        Me.dtf.Size = New System.Drawing.Size(127, 20)
        Me.dtf.TabIndex = 11
        '
        'dtt
        '
        Me.dtt.CalendarFont = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtt.CustomFormat = "dd/MM/yyyy"
        Me.dtt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtt.Location = New System.Drawing.Point(232, 42)
        Me.dtt.Name = "dtt"
        Me.dtt.Size = New System.Drawing.Size(127, 20)
        Me.dtt.TabIndex = 10
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(66, 69)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(122, 24)
        Me.cbType.TabIndex = 15
        '
        'lblType
        '
        Me.lblType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(13, 73)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(56, 16)
        Me.lblType.TabIndex = 14
        Me.lblType.Text = "T&ype :"
        '
        'gv
        '
        Me.gv.AllowUserToAddRows = False
        Me.gv.AllowUserToDeleteRows = False
        Me.gv.AllowUserToOrderColumns = True
        Me.gv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Purple
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gv.DefaultCellStyle = DataGridViewCellStyle3
        Me.gv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gv.EnableHeadersVisualStyles = False
        Me.gv.Location = New System.Drawing.Point(12, 104)
        Me.gv.Name = "gv"
        Me.gv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.gv.RowHeadersVisible = False
        Me.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gv.Size = New System.Drawing.Size(910, 480)
        Me.gv.TabIndex = 16
        '
        'OptSales
        '
        Me.OptSales.AutoSize = True
        Me.OptSales.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSales.Location = New System.Drawing.Point(14, 12)
        Me.OptSales.Name = "OptSales"
        Me.OptSales.Size = New System.Drawing.Size(66, 20)
        Me.OptSales.TabIndex = 17
        Me.OptSales.Text = "Sales"
        Me.OptSales.UseVisualStyleBackColor = True
        '
        'OptPurch
        '
        Me.OptPurch.AutoSize = True
        Me.OptPurch.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptPurch.Location = New System.Drawing.Point(95, 12)
        Me.OptPurch.Name = "OptPurch"
        Me.OptPurch.Size = New System.Drawing.Size(98, 20)
        Me.OptPurch.TabIndex = 18
        Me.OptPurch.Text = "Purchases"
        Me.OptPurch.UseVisualStyleBackColor = True
        '
        'optord
        '
        Me.optord.AutoSize = True
        Me.optord.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optord.Location = New System.Drawing.Point(199, 12)
        Me.optord.Name = "optord"
        Me.optord.Size = New System.Drawing.Size(74, 20)
        Me.optord.TabIndex = 19
        Me.optord.Text = "Orders"
        Me.optord.UseVisualStyleBackColor = True
        '
        'comview
        '
        Me.comview.Location = New System.Drawing.Point(628, 36)
        Me.comview.Name = "comview"
        Me.comview.Size = New System.Drawing.Size(75, 28)
        Me.comview.TabIndex = 20
        Me.comview.Text = "View"
        Me.comview.UseVisualStyleBackColor = True
        '
        'lblPRsup
        '
        Me.lblPRsup.AutoSize = True
        Me.lblPRsup.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRsup.ForeColor = System.Drawing.Color.Black
        Me.lblPRsup.Location = New System.Drawing.Point(202, 73)
        Me.lblPRsup.Name = "lblPRsup"
        Me.lblPRsup.Size = New System.Drawing.Size(64, 16)
        Me.lblPRsup.TabIndex = 59
        Me.lblPRsup.Text = "Party :"
        '
        'cbsupp
        '
        Me.cbsupp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbsupp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbsupp.BackColor = System.Drawing.Color.White
        Me.cbsupp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbsupp.FormattingEnabled = True
        Me.cbsupp.Location = New System.Drawing.Point(290, 68)
        Me.cbsupp.Name = "cbsupp"
        Me.cbsupp.Size = New System.Drawing.Size(413, 24)
        Me.cbsupp.TabIndex = 60
        '
        'CB
        '
        Me.CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB.FormattingEnabled = True
        Me.CB.Items.AddRange(New Object() {"Bill wise", "Product wise ", "Product wise summary"})
        Me.CB.Location = New System.Drawing.Point(449, 40)
        Me.CB.Name = "CB"
        Me.CB.Size = New System.Drawing.Size(173, 24)
        Me.CB.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(379, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "View as"
        '
        'TransactionDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1174, 596)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB)
        Me.Controls.Add(Me.lblPRsup)
        Me.Controls.Add(Me.cbsupp)
        Me.Controls.Add(Me.comview)
        Me.Controls.Add(Me.optord)
        Me.Controls.Add(Me.OptPurch)
        Me.Controls.Add(Me.OptSales)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtf)
        Me.Controls.Add(Me.dtt)
        Me.Name = "TransactionDetails"
        Me.Text = "Form1"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtf As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents OptSales As System.Windows.Forms.RadioButton
    Friend WithEvents OptPurch As System.Windows.Forms.RadioButton
    Friend WithEvents optord As System.Windows.Forms.RadioButton
    Friend WithEvents comview As System.Windows.Forms.Button
    Friend WithEvents lblPRsup As System.Windows.Forms.Label
    Friend WithEvents cbsupp As System.Windows.Forms.ComboBox
    Friend WithEvents CB As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
