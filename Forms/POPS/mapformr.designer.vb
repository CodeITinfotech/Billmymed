<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class mapformr
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
    Public WithEvents txtname As System.Windows.Forms.TextBox
	Public WithEvents txtcode As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents lblprod As System.Windows.Forms.Label
	Public WithEvents _Label2_1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.lblprod = New System.Windows.Forms.Label()
        Me._Label2_1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Prodgrid = New System.Windows.Forms.DataGridView()
        Me.code1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Packing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsup = New System.Windows.Forms.Label()
        CType(Me.Prodgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtname
        '
        Me.txtname.AcceptsReturn = True
        Me.txtname.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtname.Location = New System.Drawing.Point(112, 56)
        Me.txtname.MaxLength = 0
        Me.txtname.Name = "txtname"
        Me.txtname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtname.Size = New System.Drawing.Size(412, 20)
        Me.txtname.TabIndex = 0
        '
        'txtcode
        '
        Me.txtcode.AcceptsReturn = True
        Me.txtcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtcode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcode.Location = New System.Drawing.Point(480, 16)
        Me.txtcode.MaxLength = 0
        Me.txtcode.Name = "txtcode"
        Me.txtcode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcode.Size = New System.Drawing.Size(73, 20)
        Me.txtcode.TabIndex = 6
        Me.txtcode.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(264, 144)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(89, 25)
        Me.Command2.TabIndex = 2
        Me.Command2.Text = "Don't Map"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(184, 144)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(65, 25)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "&Map"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'lblprod
        '
        Me.lblprod.AutoSize = True
        Me.lblprod.BackColor = System.Drawing.SystemColors.Control
        Me.lblprod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblprod.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblprod.Location = New System.Drawing.Point(112, 24)
        Me.lblprod.Name = "lblprod"
        Me.lblprod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblprod.Size = New System.Drawing.Size(0, 15)
        Me.lblprod.TabIndex = 5
        '
        '_Label2_1
        '
        Me._Label2_1.AutoSize = True
        Me._Label2_1.BackColor = System.Drawing.Color.Transparent
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(16, 56)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(96, 16)
        Me._Label2_1.TabIndex = 4
        Me._Label2_1.Text = "Web Product"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Product"
        '
        'Prodgrid
        '
        Me.Prodgrid.AllowUserToAddRows = False
        Me.Prodgrid.AllowUserToDeleteRows = False
        Me.Prodgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Prodgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code1, Me.Prod, Me.Packing})
        Me.Prodgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Prodgrid.Location = New System.Drawing.Point(19, 82)
        Me.Prodgrid.Name = "Prodgrid"
        Me.Prodgrid.RowHeadersVisible = False
        Me.Prodgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Prodgrid.Size = New System.Drawing.Size(505, 313)
        Me.Prodgrid.TabIndex = 7
        Me.Prodgrid.Visible = False
        '
        'code1
        '
        Me.code1.DataPropertyName = "ProdCode"
        Me.code1.HeaderText = "Code"
        Me.code1.Name = "code1"
        Me.code1.Width = 75
        '
        'Prod
        '
        Me.Prod.DataPropertyName = "ProdName"
        Me.Prod.HeaderText = "Product"
        Me.Prod.Name = "Prod"
        Me.Prod.Width = 300
        '
        'Packing
        '
        Me.Packing.DataPropertyName = "Pack"
        Me.Packing.HeaderText = "Packing"
        Me.Packing.Name = "Packing"
        '
        'lblsup
        '
        Me.lblsup.AutoSize = True
        Me.lblsup.BackColor = System.Drawing.Color.Transparent
        Me.lblsup.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblsup.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblsup.Location = New System.Drawing.Point(249, 5)
        Me.lblsup.Name = "lblsup"
        Me.lblsup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblsup.Size = New System.Drawing.Size(72, 16)
        Me.lblsup.TabIndex = 8
        Me.lblsup.Text = "supplier"
        '
        'mapformr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(653, 455)
        Me.Controls.Add(Me.Prodgrid)
        Me.Controls.Add(Me.lblsup)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.lblprod)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 31)
        Me.Name = "mapformr"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Map Products"
        CType(Me.Prodgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Prodgrid As System.Windows.Forms.DataGridView
    Friend WithEvents code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents code1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Packing As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents lblsup As System.Windows.Forms.Label
#End Region
End Class