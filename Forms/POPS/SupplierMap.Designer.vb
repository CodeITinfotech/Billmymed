<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class mapsupplier
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		'This form is an MDI child.
		'This code simulates the VB6 
		' functionality of automatically
		' loading and showing an MDI
		' child's parent.
         
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
    Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents lblrlist As System.Windows.Forms.Label
	Public WithEvents lblwlist As System.Windows.Forms.Label
	Public WithEvents mapsupp_frame As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mapsupp_frame = New System.Windows.Forms.GroupBox()
        Me.cmbwebsup = New System.Windows.Forms.ComboBox()
        Me.cmbretsup = New System.Windows.Forms.ComboBox()
        Me.grd = New System.Windows.Forms.DataGridView()
        Me.rsup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WebSupname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.lblrlist = New System.Windows.Forms.Label()
        Me.lblwlist = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mapsupp_frame.SuspendLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mapsupp_frame
        '
        Me.mapsupp_frame.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mapsupp_frame.Controls.Add(Me.cmbwebsup)
        Me.mapsupp_frame.Controls.Add(Me.cmbretsup)
        Me.mapsupp_frame.Controls.Add(Me.grd)
        Me.mapsupp_frame.Controls.Add(Me.Command2)
        Me.mapsupp_frame.Controls.Add(Me.Command1)
        Me.mapsupp_frame.Controls.Add(Me.lblrlist)
        Me.mapsupp_frame.Controls.Add(Me.lblwlist)
        Me.mapsupp_frame.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mapsupp_frame.ForeColor = System.Drawing.Color.Red
        Me.mapsupp_frame.Location = New System.Drawing.Point(24, 24)
        Me.mapsupp_frame.Name = "mapsupp_frame"
        Me.mapsupp_frame.Padding = New System.Windows.Forms.Padding(0)
        Me.mapsupp_frame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mapsupp_frame.Size = New System.Drawing.Size(889, 425)
        Me.mapsupp_frame.TabIndex = 0
        Me.mapsupp_frame.TabStop = False
        Me.mapsupp_frame.Text = " Mapping Supplier "
        '
        'cmbwebsup
        '
        Me.cmbwebsup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbwebsup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbwebsup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbwebsup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbwebsup.FormattingEnabled = True
        Me.cmbwebsup.Location = New System.Drawing.Point(363, 44)
        Me.cmbwebsup.Name = "cmbwebsup"
        Me.cmbwebsup.Size = New System.Drawing.Size(289, 20)
        Me.cmbwebsup.TabIndex = 10
        '
        'cmbretsup
        '
        Me.cmbretsup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbretsup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbretsup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbretsup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbretsup.FormattingEnabled = True
        Me.cmbretsup.Location = New System.Drawing.Point(11, 44)
        Me.cmbretsup.Name = "cmbretsup"
        Me.cmbretsup.Size = New System.Drawing.Size(300, 20)
        Me.cmbretsup.TabIndex = 9
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rsup, Me.supname, Me.WebSupname, Me.Wid})
        Me.grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd.Location = New System.Drawing.Point(11, 78)
        Me.grd.Name = "grd"
        Me.grd.RowHeadersVisible = False
        Me.grd.Size = New System.Drawing.Size(652, 306)
        Me.grd.TabIndex = 8
        '
        'rsup
        '
        Me.rsup.HeaderText = "Column1"
        Me.rsup.Name = "rsup"
        Me.rsup.Visible = False
        '
        'supname
        '
        Me.supname.HeaderText = "Supplier Name"
        Me.supname.Name = "supname"
        Me.supname.Width = 300
        '
        'WebSupname
        '
        Me.WebSupname.HeaderText = "Web Supplier Name"
        Me.WebSupname.Name = "WebSupname"
        Me.WebSupname.Width = 300
        '
        'Wid
        '
        Me.Wid.HeaderText = "Column1"
        Me.Wid.Name = "Wid"
        Me.Wid.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(704, 72)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(121, 25)
        Me.Command2.TabIndex = 7
        Me.Command2.Text = "&Remove Maping"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(728, 40)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 25)
        Me.Command1.TabIndex = 6
        Me.Command1.Text = "&Map"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'lblrlist
        '
        Me.lblrlist.AutoSize = True
        Me.lblrlist.BackColor = System.Drawing.Color.Transparent
        Me.lblrlist.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblrlist.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrlist.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblrlist.Location = New System.Drawing.Point(8, 24)
        Me.lblrlist.Name = "lblrlist"
        Me.lblrlist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblrlist.Size = New System.Drawing.Size(80, 16)
        Me.lblrlist.TabIndex = 2
        Me.lblrlist.Text = "Suppliers"
        '
        'lblwlist
        '
        Me.lblwlist.AutoSize = True
        Me.lblwlist.BackColor = System.Drawing.Color.Transparent
        Me.lblwlist.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblwlist.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwlist.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblwlist.Location = New System.Drawing.Point(360, 24)
        Me.lblwlist.Name = "lblwlist"
        Me.lblwlist.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblwlist.Size = New System.Drawing.Size(112, 16)
        Me.lblwlist.TabIndex = 1
        Me.lblwlist.Text = "Web Suppliers"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(927, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "POPS - Suppliers Mapping"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mapsupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(927, 505)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mapsupp_frame)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "mapsupplier"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "POPS - Suppliers Mapping"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mapsupp_frame.ResumeLayout(False)
        Me.mapsupp_frame.PerformLayout()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grd As System.Windows.Forms.DataGridView
    Friend WithEvents cmbwebsup As System.Windows.Forms.ComboBox
    Friend WithEvents cmbretsup As System.Windows.Forms.ComboBox
    Friend WithEvents rsup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents supname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WebSupname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
#End Region 
End Class