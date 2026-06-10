<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardDetails
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CardDetails))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.txtcno = New System.Windows.Forms.TextBox()
        Me.txtaddr1 = New System.Windows.Forms.TextBox()
        Me.txtphone = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtplace = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.txtaddr2 = New System.Windows.Forms.TextBox()
        Me.lblphno = New System.Windows.Forms.Label()
        Me.txtaddr3 = New System.Windows.Forms.TextBox()
        Me.lblplace = New System.Windows.Forms.Label()
        Me.lbladdress = New System.Windows.Forms.Label()
        Me.lblname = New System.Windows.Forms.Label()
        Me.lblcardno = New System.Windows.Forms.Label()
        Me.Dependent = New System.Windows.Forms.GroupBox()
        Me.cmbsex = New System.Windows.Forms.ComboBox()
        Me.depcombo = New System.Windows.Forms.ComboBox()
        Me.gridctrl = New System.Windows.Forms.TextBox()
        Me.dgdep = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgname = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Pnl = New System.Windows.Forms.Panel()
        Me.Dgcard = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtdob = New System.Windows.Forms.MaskedTextBox()
        Me.cmbCustGrp = New System.Windows.Forms.ComboBox()
        Me.txtDeclratnNo = New System.Windows.Forms.TextBox()
        Me.ChkEmail = New System.Windows.Forms.CheckBox()
        Me.chkSMS = New System.Windows.Forms.CheckBox()
        Me.lblCustGrp = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblDeclrtnNo = New System.Windows.Forms.Label()
        Me.lblActvEmail = New System.Windows.Forms.Label()
        Me.lblActvSMS = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbDel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdis = New System.Windows.Forms.TextBox()
        Me.Dependent.SuspendLayout()
        CType(Me.dgdep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgname, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl.SuspendLayout()
        CType(Me.Dgcard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtname
        '
        Me.txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(210, 85)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(231, 22)
        Me.txtname.TabIndex = 1
        Me.txtname.Tag = "name"
        Me.ToolTip1.SetToolTip(Me.txtname, "Enter Name")
        '
        'txtcno
        '
        Me.txtcno.BackColor = System.Drawing.Color.White
        Me.txtcno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcno.Location = New System.Drawing.Point(210, 55)
        Me.txtcno.Name = "txtcno"
        Me.txtcno.Size = New System.Drawing.Size(231, 22)
        Me.txtcno.TabIndex = 0
        Me.txtcno.Tag = "code"
        Me.ToolTip1.SetToolTip(Me.txtcno, "Enter Card Number")
        '
        'txtaddr1
        '
        Me.txtaddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtaddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaddr1.Location = New System.Drawing.Point(210, 115)
        Me.txtaddr1.Name = "txtaddr1"
        Me.txtaddr1.Size = New System.Drawing.Size(231, 22)
        Me.txtaddr1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtaddr1, "Enter Address")
        '
        'txtphone
        '
        Me.txtphone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphone.Location = New System.Drawing.Point(210, 235)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(231, 22)
        Me.txtphone.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtphone, "Enter Phone Number")
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(210, 265)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(231, 22)
        Me.txtemail.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtemail, "Enter Email Id")
        '
        'txtplace
        '
        Me.txtplace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplace.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplace.Location = New System.Drawing.Point(210, 205)
        Me.txtplace.Name = "txtplace"
        Me.txtplace.Size = New System.Drawing.Size(231, 22)
        Me.txtplace.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtplace, "Enter Place")
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.Location = New System.Drawing.Point(36, 265)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(80, 16)
        Me.lblemail.TabIndex = 5
        Me.lblemail.Text = "Email-Id:"
        '
        'txtaddr2
        '
        Me.txtaddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtaddr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaddr2.Location = New System.Drawing.Point(210, 145)
        Me.txtaddr2.Name = "txtaddr2"
        Me.txtaddr2.Size = New System.Drawing.Size(231, 22)
        Me.txtaddr2.TabIndex = 3
        '
        'lblphno
        '
        Me.lblphno.AutoSize = True
        Me.lblphno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblphno.Location = New System.Drawing.Point(36, 235)
        Me.lblphno.Name = "lblphno"
        Me.lblphno.Size = New System.Drawing.Size(80, 16)
        Me.lblphno.TabIndex = 4
        Me.lblphno.Text = "Phone No:"
        '
        'txtaddr3
        '
        Me.txtaddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtaddr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaddr3.Location = New System.Drawing.Point(210, 175)
        Me.txtaddr3.Name = "txtaddr3"
        Me.txtaddr3.Size = New System.Drawing.Size(231, 22)
        Me.txtaddr3.TabIndex = 4
        '
        'lblplace
        '
        Me.lblplace.AutoSize = True
        Me.lblplace.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblplace.Location = New System.Drawing.Point(36, 205)
        Me.lblplace.Name = "lblplace"
        Me.lblplace.Size = New System.Drawing.Size(56, 16)
        Me.lblplace.TabIndex = 3
        Me.lblplace.Text = "Place:"
        '
        'lbladdress
        '
        Me.lbladdress.AutoSize = True
        Me.lbladdress.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbladdress.Location = New System.Drawing.Point(36, 115)
        Me.lbladdress.Name = "lbladdress"
        Me.lbladdress.Size = New System.Drawing.Size(72, 16)
        Me.lbladdress.TabIndex = 2
        Me.lbladdress.Text = "Address:"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.Location = New System.Drawing.Point(36, 85)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(48, 16)
        Me.lblname.TabIndex = 1
        Me.lblname.Text = "Name:"
        '
        'lblcardno
        '
        Me.lblcardno.AutoSize = True
        Me.lblcardno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcardno.Location = New System.Drawing.Point(36, 55)
        Me.lblcardno.Name = "lblcardno"
        Me.lblcardno.Size = New System.Drawing.Size(72, 16)
        Me.lblcardno.TabIndex = 0
        Me.lblcardno.Text = "Card No:"
        '
        'Dependent
        '
        Me.Dependent.Controls.Add(Me.cmbsex)
        Me.Dependent.Controls.Add(Me.depcombo)
        Me.Dependent.Controls.Add(Me.gridctrl)
        Me.Dependent.Controls.Add(Me.dgdep)
        Me.Dependent.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dependent.Location = New System.Drawing.Point(460, 52)
        Me.Dependent.Name = "Dependent"
        Me.Dependent.Size = New System.Drawing.Size(553, 294)
        Me.Dependent.TabIndex = 14
        Me.Dependent.TabStop = False
        Me.Dependent.Text = "Dependent"
        '
        'cmbsex
        '
        Me.cmbsex.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsex.ForeColor = System.Drawing.Color.Black
        Me.cmbsex.FormattingEnabled = True
        Me.cmbsex.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbsex.Location = New System.Drawing.Point(224, 128)
        Me.cmbsex.Name = "cmbsex"
        Me.cmbsex.Size = New System.Drawing.Size(121, 24)
        Me.cmbsex.TabIndex = 2
        Me.cmbsex.Visible = False
        '
        'depcombo
        '
        Me.depcombo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.depcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.depcombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.depcombo.ForeColor = System.Drawing.Color.Black
        Me.depcombo.FormattingEnabled = True
        Me.depcombo.Items.AddRange(New Object() {"Husband", "Wife", "Father", "Mother", "Son ", "Daughter", "Self"})
        Me.depcombo.Location = New System.Drawing.Point(151, 168)
        Me.depcombo.Name = "depcombo"
        Me.depcombo.Size = New System.Drawing.Size(140, 24)
        Me.depcombo.TabIndex = 3
        Me.depcombo.Visible = False
        '
        'gridctrl
        '
        Me.gridctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gridctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gridctrl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.gridctrl.ForeColor = System.Drawing.Color.Black
        Me.gridctrl.Location = New System.Drawing.Point(39, 128)
        Me.gridctrl.Name = "gridctrl"
        Me.gridctrl.Size = New System.Drawing.Size(168, 22)
        Me.gridctrl.TabIndex = 1
        Me.gridctrl.Visible = False
        '
        'dgdep
        '
        Me.dgdep.AllowUserToAddRows = False
        Me.dgdep.AllowUserToResizeColumns = False
        Me.dgdep.BackgroundColor = System.Drawing.Color.White
        Me.dgdep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgdep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdep.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdep.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column6, Me.Column3, Me.Column4})
        Me.dgdep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgdep.EnableHeadersVisualStyles = False
        Me.dgdep.Location = New System.Drawing.Point(16, 21)
        Me.dgdep.Name = "dgdep"
        Me.dgdep.RowHeadersVisible = False
        Me.dgdep.Size = New System.Drawing.Size(522, 255)
        Me.dgdep.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "code"
        Me.Column1.HeaderText = "Dep Code"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "dname"
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column6
        '
        Me.Column6.HeaderText = "Sex"
        Me.Column6.Name = "Column6"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "age"
        Me.Column3.HeaderText = "Age"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "relation"
        Me.Column4.HeaderText = "Relation"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgname
        '
        Me.dgname.AllowUserToAddRows = False
        Me.dgname.AllowUserToDeleteRows = False
        Me.dgname.AllowUserToResizeColumns = False
        Me.dgname.AllowUserToResizeRows = False
        Me.dgname.BackgroundColor = System.Drawing.Color.White
        Me.dgname.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgname.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.cardno})
        Me.dgname.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgname.Location = New System.Drawing.Point(107, 496)
        Me.dgname.Name = "dgname"
        Me.dgname.RowHeadersVisible = False
        Me.dgname.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgname.Size = New System.Drawing.Size(378, 202)
        Me.dgname.TabIndex = 17
        Me.dgname.Visible = False
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "name"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column5.HeaderText = "Name"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 225
        '
        'cardno
        '
        Me.cardno.DataPropertyName = "cardno"
        Me.cardno.HeaderText = "CardNo"
        Me.cardno.Name = "cardno"
        Me.cardno.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(149, 33)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 16)
        Me.lblStatus.TabIndex = 20
        Me.lblStatus.Text = "Label"
        '
        'Pnl
        '
        Me.Pnl.BackColor = System.Drawing.Color.White
        Me.Pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl.Controls.Add(Me.Dgcard)
        Me.Pnl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl.Location = New System.Drawing.Point(447, 52)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(482, 319)
        Me.Pnl.TabIndex = 18
        Me.Pnl.Visible = False
        '
        'Dgcard
        '
        Me.Dgcard.AllowUserToAddRows = False
        Me.Dgcard.AllowUserToDeleteRows = False
        Me.Dgcard.AllowUserToResizeColumns = False
        Me.Dgcard.AllowUserToResizeRows = False
        Me.Dgcard.BackgroundColor = System.Drawing.Color.White
        Me.Dgcard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgcard.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgcard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.Dgcard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgcard.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgcard.DefaultCellStyle = DataGridViewCellStyle12
        Me.Dgcard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgcard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgcard.Location = New System.Drawing.Point(0, 0)
        Me.Dgcard.Name = "Dgcard"
        Me.Dgcard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Dgcard.RowHeadersVisible = False
        Me.Dgcard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Dgcard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgcard.Size = New System.Drawing.Size(480, 317)
        Me.Dgcard.TabIndex = 56
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtdis)
        Me.Panel1.Controls.Add(Me.txtdob)
        Me.Panel1.Controls.Add(Me.cmbCustGrp)
        Me.Panel1.Controls.Add(Me.txtDeclratnNo)
        Me.Panel1.Controls.Add(Me.ChkEmail)
        Me.Panel1.Controls.Add(Me.Pnl)
        Me.Panel1.Controls.Add(Me.dgname)
        Me.Panel1.Controls.Add(Me.chkSMS)
        Me.Panel1.Controls.Add(Me.lblCustGrp)
        Me.Panel1.Controls.Add(Me.lblDOB)
        Me.Panel1.Controls.Add(Me.lblDeclrtnNo)
        Me.Panel1.Controls.Add(Me.lblActvEmail)
        Me.Panel1.Controls.Add(Me.lblActvSMS)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.txtplace)
        Me.Panel1.Controls.Add(Me.Dependent)
        Me.Panel1.Controls.Add(Me.lblcardno)
        Me.Panel1.Controls.Add(Me.txtemail)
        Me.Panel1.Controls.Add(Me.lblname)
        Me.Panel1.Controls.Add(Me.txtphone)
        Me.Panel1.Controls.Add(Me.lbladdress)
        Me.Panel1.Controls.Add(Me.lblplace)
        Me.Panel1.Controls.Add(Me.txtaddr3)
        Me.Panel1.Controls.Add(Me.lblphno)
        Me.Panel1.Controls.Add(Me.txtaddr2)
        Me.Panel1.Controls.Add(Me.lblemail)
        Me.Panel1.Controls.Add(Me.txtaddr1)
        Me.Panel1.Controls.Add(Me.txtcno)
        Me.Panel1.Controls.Add(Me.txtname)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 742)
        Me.Panel1.TabIndex = 18
        '
        'txtdob
        '
        Me.txtdob.BackColor = System.Drawing.Color.White
        Me.txtdob.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdob.ForeColor = System.Drawing.Color.Black
        Me.txtdob.Location = New System.Drawing.Point(210, 424)
        Me.txtdob.Mask = "00/00/0000"
        Me.txtdob.Name = "txtdob"
        Me.txtdob.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtdob.Size = New System.Drawing.Size(116, 22)
        Me.txtdob.TabIndex = 12
        Me.txtdob.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtdob.ValidatingType = GetType(Date)
        '
        'cmbCustGrp
        '
        Me.cmbCustGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustGrp.FormattingEnabled = True
        Me.cmbCustGrp.Location = New System.Drawing.Point(210, 454)
        Me.cmbCustGrp.Name = "cmbCustGrp"
        Me.cmbCustGrp.Size = New System.Drawing.Size(231, 24)
        Me.cmbCustGrp.TabIndex = 13
        '
        'txtDeclratnNo
        '
        Me.txtDeclratnNo.AcceptsReturn = True
        Me.txtDeclratnNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeclratnNo.Location = New System.Drawing.Point(210, 391)
        Me.txtDeclratnNo.Name = "txtDeclratnNo"
        Me.txtDeclratnNo.Size = New System.Drawing.Size(116, 22)
        Me.txtDeclratnNo.TabIndex = 11
        '
        'ChkEmail
        '
        Me.ChkEmail.AutoSize = True
        Me.ChkEmail.Location = New System.Drawing.Point(210, 360)
        Me.ChkEmail.Name = "ChkEmail"
        Me.ChkEmail.Size = New System.Drawing.Size(15, 14)
        Me.ChkEmail.TabIndex = 10
        Me.ChkEmail.UseVisualStyleBackColor = True
        '
        'chkSMS
        '
        Me.chkSMS.AutoSize = True
        Me.chkSMS.Location = New System.Drawing.Point(210, 330)
        Me.chkSMS.Name = "chkSMS"
        Me.chkSMS.Size = New System.Drawing.Size(15, 14)
        Me.chkSMS.TabIndex = 9
        Me.chkSMS.UseVisualStyleBackColor = True
        '
        'lblCustGrp
        '
        Me.lblCustGrp.AutoSize = True
        Me.lblCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustGrp.Location = New System.Drawing.Point(36, 459)
        Me.lblCustGrp.Name = "lblCustGrp"
        Me.lblCustGrp.Size = New System.Drawing.Size(56, 16)
        Me.lblCustGrp.TabIndex = 25
        Me.lblCustGrp.Text = "Group:"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDOB.Location = New System.Drawing.Point(36, 427)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(40, 16)
        Me.lblDOB.TabIndex = 24
        Me.lblDOB.Text = "DOB:"
        '
        'lblDeclrtnNo
        '
        Me.lblDeclrtnNo.AutoSize = True
        Me.lblDeclrtnNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeclrtnNo.Location = New System.Drawing.Point(36, 393)
        Me.lblDeclrtnNo.Name = "lblDeclrtnNo"
        Me.lblDeclrtnNo.Size = New System.Drawing.Size(160, 16)
        Me.lblDeclrtnNo.TabIndex = 23
        Me.lblDeclrtnNo.Text = "SMS Declaration No:"
        '
        'lblActvEmail
        '
        Me.lblActvEmail.AutoSize = True
        Me.lblActvEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActvEmail.Location = New System.Drawing.Point(36, 361)
        Me.lblActvEmail.Name = "lblActvEmail"
        Me.lblActvEmail.Size = New System.Drawing.Size(112, 16)
        Me.lblActvEmail.TabIndex = 22
        Me.lblActvEmail.Text = "Active Email:"
        '
        'lblActvSMS
        '
        Me.lblActvSMS.AutoSize = True
        Me.lblActvSMS.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActvSMS.Location = New System.Drawing.Point(36, 330)
        Me.lblActvSMS.Name = "lblActvSMS"
        Me.lblActvSMS.Size = New System.Drawing.Size(96, 16)
        Me.lblActvSMS.TabIndex = 21
        Me.lblActvSMS.Text = "Active SMS:"
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbAdd, Me.tsbExit, Me.tsbClear, Me.tsbDel, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1028, 33)
        Me.ToolStrip.TabIndex = 62
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
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(500, 30)
        Me.ToolStripLabel1.Text = "Loyalty Card Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Discount % :"
        '
        'txtdis
        '
        Me.txtdis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdis.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdis.Location = New System.Drawing.Point(210, 297)
        Me.txtdis.Name = "txtdis"
        Me.txtdis.Size = New System.Drawing.Size(54, 22)
        Me.txtdis.TabIndex = 8
        Me.txtdis.Text = "0"
        Me.txtdis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CardDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1028, 742)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CardDetails"
        Me.Text = "Loyalty Card Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Dependent.ResumeLayout(False)
        Me.Dependent.PerformLayout()
        CType(Me.dgdep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgname, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl.ResumeLayout(False)
        CType(Me.Dgcard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents txtcno As System.Windows.Forms.TextBox
    Friend WithEvents txtaddr1 As System.Windows.Forms.TextBox
    Friend WithEvents lblemail As System.Windows.Forms.Label
    Friend WithEvents txtaddr2 As System.Windows.Forms.TextBox
    Friend WithEvents lblphno As System.Windows.Forms.Label
    Friend WithEvents txtaddr3 As System.Windows.Forms.TextBox
    Friend WithEvents lblplace As System.Windows.Forms.Label
    Friend WithEvents lbladdress As System.Windows.Forms.Label
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents lblcardno As System.Windows.Forms.Label
    Friend WithEvents Dependent As System.Windows.Forms.GroupBox
    Friend WithEvents cmbsex As System.Windows.Forms.ComboBox
    Friend WithEvents depcombo As System.Windows.Forms.ComboBox
    Friend WithEvents gridctrl As System.Windows.Forms.TextBox
    Friend WithEvents dgdep As System.Windows.Forms.DataGridView
    Friend WithEvents txtplace As System.Windows.Forms.TextBox
    Friend WithEvents dgname As System.Windows.Forms.DataGridView
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cardno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Pnl As System.Windows.Forms.Panel
    Friend WithEvents Dgcard As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblActvSMS As System.Windows.Forms.Label
    Friend WithEvents lblActvEmail As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblDeclrtnNo As System.Windows.Forms.Label
    Friend WithEvents lblCustGrp As System.Windows.Forms.Label
    Friend WithEvents ChkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkSMS As System.Windows.Forms.CheckBox
    Friend WithEvents txtDeclratnNo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCustGrp As System.Windows.Forms.ComboBox
    Friend WithEvents txtdob As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdis As System.Windows.Forms.TextBox
End Class
