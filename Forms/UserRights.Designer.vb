<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRights
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserRights))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbClr = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbDel = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUserID = New System.Windows.Forms.ComboBox()
        Me.dgRights = New System.Windows.Forms.DataGridView()
        Me.Rights = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Blocked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Txtsales = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSrtn = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPur = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPurRtn = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtOrd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsaadd = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsaless = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPuLessLmt = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPuAddLmt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtdiscfor = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDiscLmt = New System.Windows.Forms.TextBox()
        Me.txtdiscfor2 = New System.Windows.Forms.TextBox()
        Me.txtDiscLmt2 = New System.Windows.Forms.TextBox()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbClr, Me.tsbExit, Me.ToolStripLabel1, Me.tsbDel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1028, 36)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(80, 33)
        Me.tsbSave.Text = "&Save"
        '
        'tsbClr
        '
        Me.tsbClr.AutoSize = False
        Me.tsbClr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClr.Image = CType(resources.GetObject("tsbClr.Image"), System.Drawing.Image)
        Me.tsbClr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClr.Name = "tsbClr"
        Me.tsbClr.Size = New System.Drawing.Size(80, 33)
        Me.tsbClr.Text = "&Clear"
        '
        'tsbExit
        '
        Me.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExit.AutoSize = False
        Me.tsbExit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbExit.Image = CType(resources.GetObject("tsbExit.Image"), System.Drawing.Image)
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(80, 33)
        Me.tsbExit.Text = "E&xit"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(650, 33)
        Me.ToolStripLabel1.Text = "User Locked"
        '
        'tsbDel
        '
        Me.tsbDel.AutoSize = False
        Me.tsbDel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbDel.Image = CType(resources.GetObject("tsbDel.Image"), System.Drawing.Image)
        Me.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDel.Name = "tsbDel"
        Me.tsbDel.Size = New System.Drawing.Size(80, 33)
        Me.tsbDel.Text = "&Delete"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User ID :"
        '
        'cmbUserID
        '
        Me.cmbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUserID.FormattingEnabled = True
        Me.cmbUserID.Location = New System.Drawing.Point(123, 65)
        Me.cmbUserID.Name = "cmbUserID"
        Me.cmbUserID.Size = New System.Drawing.Size(211, 24)
        Me.cmbUserID.TabIndex = 0
        '
        'dgRights
        '
        Me.dgRights.AllowUserToAddRows = False
        Me.dgRights.AllowUserToDeleteRows = False
        Me.dgRights.AllowUserToResizeColumns = False
        Me.dgRights.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgRights.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRights.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgRights.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRights.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRights.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rights, Me.Blocked})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRights.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgRights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgRights.EnableHeadersVisualStyles = False
        Me.dgRights.Location = New System.Drawing.Point(123, 95)
        Me.dgRights.Name = "dgRights"
        Me.dgRights.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRights.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgRights.RowHeadersVisible = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgRights.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgRights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgRights.Size = New System.Drawing.Size(474, 393)
        Me.dgRights.TabIndex = 1
        '
        'Rights
        '
        Me.Rights.HeaderText = "Rights"
        Me.Rights.Name = "Rights"
        Me.Rights.ReadOnly = True
        Me.Rights.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Rights.Width = 250
        '
        'Blocked
        '
        Me.Blocked.HeaderText = "Blocked"
        Me.Blocked.Name = "Blocked"
        Me.Blocked.ReadOnly = True
        Me.Blocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Txtsales
        '
        Me.Txtsales.Location = New System.Drawing.Point(743, 136)
        Me.Txtsales.Name = "Txtsales"
        Me.Txtsales.Size = New System.Drawing.Size(90, 20)
        Me.Txtsales.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(622, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lock on  days"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(636, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sales"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(636, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sales Rtn"
        '
        'TxtSrtn
        '
        Me.TxtSrtn.Location = New System.Drawing.Point(743, 162)
        Me.TxtSrtn.Name = "TxtSrtn"
        Me.TxtSrtn.Size = New System.Drawing.Size(90, 20)
        Me.TxtSrtn.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(636, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Purchase"
        '
        'TxtPur
        '
        Me.TxtPur.Location = New System.Drawing.Point(743, 188)
        Me.TxtPur.Name = "TxtPur"
        Me.TxtPur.Size = New System.Drawing.Size(90, 20)
        Me.TxtPur.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(636, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Purchase Rtn"
        '
        'TxtPurRtn
        '
        Me.TxtPurRtn.Location = New System.Drawing.Point(743, 214)
        Me.TxtPurRtn.Name = "TxtPurRtn"
        Me.TxtPurRtn.Size = New System.Drawing.Size(90, 20)
        Me.TxtPurRtn.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(636, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Orders"
        '
        'TxtOrd
        '
        Me.TxtOrd.Location = New System.Drawing.Point(743, 240)
        Me.TxtOrd.Name = "TxtOrd"
        Me.TxtOrd.Size = New System.Drawing.Size(90, 20)
        Me.TxtOrd.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(636, 314)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Sales Add"
        '
        'txtsaadd
        '
        Me.txtsaadd.Location = New System.Drawing.Point(743, 312)
        Me.txtsaadd.Name = "txtsaadd"
        Me.txtsaadd.Size = New System.Drawing.Size(90, 20)
        Me.txtsaadd.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(636, 283)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Limits"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(636, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Sales Less"
        '
        'txtsaless
        '
        Me.txtsaless.Location = New System.Drawing.Point(743, 340)
        Me.txtsaless.Name = "txtsaless"
        Me.txtsaless.Size = New System.Drawing.Size(90, 20)
        Me.txtsaless.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(636, 454)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Purchase Less"
        '
        'TxtPuLessLmt
        '
        Me.TxtPuLessLmt.Location = New System.Drawing.Point(754, 452)
        Me.TxtPuLessLmt.Name = "TxtPuLessLmt"
        Me.TxtPuLessLmt.Size = New System.Drawing.Size(79, 20)
        Me.TxtPuLessLmt.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(636, 426)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 16)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Purchase Add"
        '
        'TxtPuAddLmt
        '
        Me.TxtPuAddLmt.Location = New System.Drawing.Point(754, 424)
        Me.TxtPuAddLmt.Name = "TxtPuAddLmt"
        Me.TxtPuAddLmt.Size = New System.Drawing.Size(79, 20)
        Me.TxtPuAddLmt.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(636, 398)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Disc for"
        '
        'txtdiscfor
        '
        Me.txtdiscfor.Location = New System.Drawing.Point(743, 396)
        Me.txtdiscfor.Name = "txtdiscfor"
        Me.txtdiscfor.Size = New System.Drawing.Size(90, 20)
        Me.txtdiscfor.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(636, 370)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Sales Disc%"
        '
        'txtDiscLmt
        '
        Me.txtDiscLmt.Location = New System.Drawing.Point(743, 368)
        Me.txtDiscLmt.Name = "txtDiscLmt"
        Me.txtDiscLmt.Size = New System.Drawing.Size(90, 20)
        Me.txtDiscLmt.TabIndex = 9
        '
        'txtdiscfor2
        '
        Me.txtdiscfor2.Location = New System.Drawing.Point(839, 396)
        Me.txtdiscfor2.Name = "txtdiscfor2"
        Me.txtdiscfor2.Size = New System.Drawing.Size(90, 20)
        Me.txtdiscfor2.TabIndex = 29
        '
        'txtDiscLmt2
        '
        Me.txtDiscLmt2.Location = New System.Drawing.Point(839, 368)
        Me.txtDiscLmt2.Name = "txtDiscLmt2"
        Me.txtDiscLmt2.Size = New System.Drawing.Size(90, 20)
        Me.txtDiscLmt2.TabIndex = 28
        '
        'UserRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Orchid
        Me.ClientSize = New System.Drawing.Size(1028, 517)
        Me.Controls.Add(Me.txtdiscfor2)
        Me.Controls.Add(Me.txtDiscLmt2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtdiscfor)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtDiscLmt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtPuLessLmt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPuAddLmt)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtsaless)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtsaadd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtOrd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtPurRtn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPur)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSrtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtsales)
        Me.Controls.Add(Me.dgRights)
        Me.Controls.Add(Me.cmbUserID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "UserRights"
        Me.Text = "User Locked"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClr As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUserID As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgRights As System.Windows.Forms.DataGridView
    Friend WithEvents Rights As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Blocked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsbDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Txtsales As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSrtn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPur As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPurRtn As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtOrd As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtsaadd As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtsaless As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPuLessLmt As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtPuAddLmt As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtdiscfor As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDiscLmt As System.Windows.Forms.TextBox
    Friend WithEvents txtdiscfor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscLmt2 As System.Windows.Forms.TextBox
End Class
