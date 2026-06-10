<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrescriptionEntry
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrescriptionEntry))
        Me.lblcardno = New System.Windows.Forms.Label()
        Me.lblptno = New System.Windows.Forms.Label()
        Me.lbldocno = New System.Windows.Forms.Label()
        Me.lblpres = New System.Windows.Forms.Label()
        Me.dgpresc = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbpatient = New System.Windows.Forms.ComboBox()
        Me.cbdoctor = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgcode = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblname = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.gridcrtl = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgmedicine = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Case1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgcardno = New System.Windows.Forms.DataGridView()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbcardno = New System.Windows.Forms.ComboBox()
        Me.cbpresc = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbDel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.dgpresc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgmedicine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgcardno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblcardno
        '
        Me.lblcardno.AutoSize = True
        Me.lblcardno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcardno.Location = New System.Drawing.Point(38, 72)
        Me.lblcardno.Name = "lblcardno"
        Me.lblcardno.Size = New System.Drawing.Size(72, 16)
        Me.lblcardno.TabIndex = 0
        Me.lblcardno.Text = "Card No:"
        '
        'lblptno
        '
        Me.lblptno.AutoSize = True
        Me.lblptno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblptno.Location = New System.Drawing.Point(38, 166)
        Me.lblptno.Name = "lblptno"
        Me.lblptno.Size = New System.Drawing.Size(112, 16)
        Me.lblptno.TabIndex = 1
        Me.lblptno.Text = "Patient Name:"
        '
        'lbldocno
        '
        Me.lbldocno.AutoSize = True
        Me.lbldocno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldocno.Location = New System.Drawing.Point(38, 198)
        Me.lbldocno.Name = "lbldocno"
        Me.lbldocno.Size = New System.Drawing.Size(104, 16)
        Me.lbldocno.TabIndex = 2
        Me.lbldocno.Text = "Doctor Name:"
        '
        'lblpres
        '
        Me.lblpres.AutoSize = True
        Me.lblpres.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpres.Location = New System.Drawing.Point(38, 136)
        Me.lblpres.Name = "lblpres"
        Me.lblpres.Size = New System.Drawing.Size(152, 16)
        Me.lblpres.TabIndex = 3
        Me.lblpres.Text = "Prescription Name:"
        '
        'dgpresc
        '
        Me.dgpresc.AllowUserToAddRows = False
        Me.dgpresc.AllowUserToDeleteRows = False
        Me.dgpresc.AllowUserToResizeColumns = False
        Me.dgpresc.AllowUserToResizeRows = False
        Me.dgpresc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgpresc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgpresc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column2, Me.Column3, Me.Column10})
        Me.dgpresc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgpresc.Location = New System.Drawing.Point(41, 235)
        Me.dgpresc.Name = "dgpresc"
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgpresc.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgpresc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgpresc.Size = New System.Drawing.Size(700, 253)
        Me.dgpresc.TabIndex = 4
        '
        'Column4
        '
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column4.HeaderText = "Code"
        Me.Column4.Name = "Column4"
        '
        'Column1
        '
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column1.HeaderText = "Medicine Name"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 200
        '
        'Column2
        '
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column2.HeaderText = "Dosage"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column3.HeaderText = "Qty"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 50
        '
        'Column10
        '
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle21
        Me.Column10.HeaderText = "Description"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 200
        '
        'cbpatient
        '
        Me.cbpatient.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpatient.FormattingEnabled = True
        Me.cbpatient.Location = New System.Drawing.Point(196, 163)
        Me.cbpatient.Name = "cbpatient"
        Me.cbpatient.Size = New System.Drawing.Size(301, 24)
        Me.cbpatient.TabIndex = 3
        '
        'cbdoctor
        '
        Me.cbdoctor.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdoctor.FormattingEnabled = True
        Me.cbdoctor.Location = New System.Drawing.Point(196, 195)
        Me.cbdoctor.Name = "cbdoctor"
        Me.cbdoctor.Size = New System.Drawing.Size(301, 24)
        Me.cbdoctor.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.dgcode)
        Me.Panel1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(503, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 253)
        Me.Panel1.TabIndex = 9
        Me.Panel1.Visible = False
        '
        'dgcode
        '
        Me.dgcode.AllowUserToAddRows = False
        Me.dgcode.AllowUserToDeleteRows = False
        Me.dgcode.AllowUserToResizeColumns = False
        Me.dgcode.AllowUserToResizeRows = False
        Me.dgcode.BackgroundColor = System.Drawing.Color.White
        Me.dgcode.CausesValidation = False
        Me.dgcode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.Column5})
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgcode.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgcode.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgcode.EnableHeadersVisualStyles = False
        Me.dgcode.Location = New System.Drawing.Point(0, 0)
        Me.dgcode.Name = "dgcode"
        Me.dgcode.ReadOnly = True
        Me.dgcode.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgcode.RowHeadersVisible = False
        Me.dgcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgcode.Size = New System.Drawing.Size(314, 253)
        Me.dgcode.TabIndex = 0
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "name"
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle24
        Me.Column6.HeaderText = "Name"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 200
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "cardno"
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle25
        Me.Column7.HeaderText = "code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "place"
        Me.Column5.HeaderText = "Place"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.Location = New System.Drawing.Point(38, 101)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(48, 16)
        Me.lblname.TabIndex = 10
        Me.lblname.Text = "Name:"
        '
        'txtname
        '
        Me.txtname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(196, 98)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(301, 22)
        Me.txtname.TabIndex = 1
        '
        'gridcrtl
        '
        Me.gridcrtl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gridcrtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gridcrtl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.gridcrtl.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridcrtl.ForeColor = System.Drawing.Color.Black
        Me.gridcrtl.Location = New System.Drawing.Point(196, 341)
        Me.gridcrtl.Name = "gridcrtl"
        Me.gridcrtl.Size = New System.Drawing.Size(116, 22)
        Me.gridcrtl.TabIndex = 12
        Me.gridcrtl.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.dgmedicine)
        Me.Panel2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(389, 235)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(480, 253)
        Me.Panel2.TabIndex = 14
        Me.Panel2.Visible = False
        '
        'dgmedicine
        '
        Me.dgmedicine.AllowUserToAddRows = False
        Me.dgmedicine.AllowUserToDeleteRows = False
        Me.dgmedicine.AllowUserToOrderColumns = True
        Me.dgmedicine.AllowUserToResizeRows = False
        Me.dgmedicine.BackgroundColor = System.Drawing.Color.White
        Me.dgmedicine.CausesValidation = False
        Me.dgmedicine.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgmedicine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgmedicine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgmedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgmedicine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Case1})
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgmedicine.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgmedicine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgmedicine.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgmedicine.Location = New System.Drawing.Point(0, 0)
        Me.dgmedicine.MultiSelect = False
        Me.dgmedicine.Name = "dgmedicine"
        Me.dgmedicine.ReadOnly = True
        Me.dgmedicine.RowHeadersVisible = False
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgmedicine.RowsDefaultCellStyle = DataGridViewCellStyle31
        Me.dgmedicine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgmedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgmedicine.Size = New System.Drawing.Size(480, 253)
        Me.dgmedicine.TabIndex = 0
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "Prdcode"
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle28
        Me.Column8.HeaderText = "Code"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        Me.Column8.Width = 50
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "Prdname"
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle29
        Me.Column9.HeaderText = "Name"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 300
        '
        'Case1
        '
        Me.Case1.HeaderText = "Case1"
        Me.Case1.Name = "Case1"
        Me.Case1.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.dgcardno)
        Me.Panel3.Location = New System.Drawing.Point(856, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(168, 125)
        Me.Panel3.TabIndex = 15
        Me.Panel3.Visible = False
        '
        'dgcardno
        '
        Me.dgcardno.BackgroundColor = System.Drawing.Color.White
        Me.dgcardno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgcardno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgcardno.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11})
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgcardno.DefaultCellStyle = DataGridViewCellStyle32
        Me.dgcardno.Location = New System.Drawing.Point(13, 12)
        Me.dgcardno.Name = "dgcardno"
        Me.dgcardno.RowHeadersVisible = False
        Me.dgcardno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgcardno.Size = New System.Drawing.Size(153, 106)
        Me.dgcardno.TabIndex = 0
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "cardno"
        Me.Column11.HeaderText = "Card No"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 150
        '
        'cbcardno
        '
        Me.cbcardno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcardno.FormattingEnabled = True
        Me.cbcardno.Location = New System.Drawing.Point(196, 69)
        Me.cbcardno.Name = "cbcardno"
        Me.cbcardno.Size = New System.Drawing.Size(301, 24)
        Me.cbcardno.TabIndex = 0
        '
        'cbpresc
        '
        Me.cbpresc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpresc.FormattingEnabled = True
        Me.cbpresc.Location = New System.Drawing.Point(196, 133)
        Me.cbpresc.Name = "cbpresc"
        Me.cbpresc.Size = New System.Drawing.Size(301, 24)
        Me.cbpresc.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbpresc, "Enter Prescription Name")
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbAdd, Me.tsbExit, Me.tsbClear, Me.tsbDel, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1024, 33)
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
        Me.tsbAdd.Visible = False
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
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Maroon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(600, 30)
        Me.ToolStripLabel1.Text = "Customer Prescription Entry"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(38, 46)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 16)
        Me.lblStatus.TabIndex = 63
        Me.lblStatus.Text = "Label"
        '
        'PrescriptionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1024, 746)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gridcrtl)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbpresc)
        Me.Controls.Add(Me.cbcardno)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.lblname)
        Me.Controls.Add(Me.cbdoctor)
        Me.Controls.Add(Me.cbpatient)
        Me.Controls.Add(Me.dgpresc)
        Me.Controls.Add(Me.lblpres)
        Me.Controls.Add(Me.lbldocno)
        Me.Controls.Add(Me.lblptno)
        Me.Controls.Add(Me.lblcardno)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PrescriptionEntry"
        Me.Text = "Customer Prescription Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgpresc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgmedicine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgcardno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblcardno As System.Windows.Forms.Label
    Friend WithEvents lblptno As System.Windows.Forms.Label
    Friend WithEvents lbldocno As System.Windows.Forms.Label
    Friend WithEvents lblpres As System.Windows.Forms.Label
    Friend WithEvents dgpresc As System.Windows.Forms.DataGridView
    Friend WithEvents cbpatient As System.Windows.Forms.ComboBox
    Friend WithEvents cbdoctor As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgcode As System.Windows.Forms.DataGridView
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents gridcrtl As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgmedicine As System.Windows.Forms.DataGridView
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgcardno As System.Windows.Forms.DataGridView
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbcardno As System.Windows.Forms.ComboBox
    Friend WithEvents cbpresc As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Case1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
