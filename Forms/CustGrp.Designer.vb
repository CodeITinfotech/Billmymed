<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustGrp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Tsbadd = New System.Windows.Forms.ToolStripButton()
        Me.Tsbsave = New System.Windows.Forms.ToolStripButton()
        Me.Tsbdelete = New System.Windows.Forms.ToolStripButton()
        Me.Tsbexit = New System.Windows.Forms.ToolStripButton()
        Me.Tsbclear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblcap = New System.Windows.Forms.Label()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Txtremark = New System.Windows.Forms.TextBox()
        Me.Txtdept = New System.Windows.Forms.TextBox()
        Me.Txtcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnl.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsbadd, Me.Tsbsave, Me.Tsbdelete, Me.Tsbexit, Me.Tsbclear, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1022, 32)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Tsbadd
        '
        Me.Tsbadd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsbadd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbadd.Name = "Tsbadd"
        Me.Tsbadd.Size = New System.Drawing.Size(68, 29)
        Me.Tsbadd.Text = "  &Add  "
        '
        'Tsbsave
        '
        Me.Tsbsave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsbsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbsave.Name = "Tsbsave"
        Me.Tsbsave.Size = New System.Drawing.Size(76, 29)
        Me.Tsbsave.Text = "  &Save  "
        '
        'Tsbdelete
        '
        Me.Tsbdelete.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsbdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbdelete.Name = "Tsbdelete"
        Me.Tsbdelete.Size = New System.Drawing.Size(92, 29)
        Me.Tsbdelete.Text = "  &Delete  "
        '
        'Tsbexit
        '
        Me.Tsbexit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Tsbexit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsbexit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbexit.Name = "Tsbexit"
        Me.Tsbexit.Size = New System.Drawing.Size(76, 29)
        Me.Tsbexit.Text = "  E&xit  "
        '
        'Tsbclear
        '
        Me.Tsbclear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Tsbclear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tsbclear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsbclear.Name = "Tsbclear"
        Me.Tsbclear.Size = New System.Drawing.Size(84, 29)
        Me.Tsbclear.Text = "  &Clear  "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(500, 30)
        Me.ToolStripLabel1.Text = "Customer Groups"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblcap)
        Me.Panel1.Controls.Add(Me.pnl)
        Me.Panel1.Controls.Add(Me.Txtremark)
        Me.Panel1.Controls.Add(Me.Txtdept)
        Me.Panel1.Controls.Add(Me.Txtcode)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 714)
        Me.Panel1.TabIndex = 1
        '
        'lblcap
        '
        Me.lblcap.AutoSize = True
        Me.lblcap.BackColor = System.Drawing.Color.Transparent
        Me.lblcap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblcap.ForeColor = System.Drawing.Color.Red
        Me.lblcap.Location = New System.Drawing.Point(183, 32)
        Me.lblcap.Name = "lblcap"
        Me.lblcap.Size = New System.Drawing.Size(16, 16)
        Me.lblcap.TabIndex = 15
        Me.lblcap.Text = "L"
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.White
        Me.pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl.Controls.Add(Me.Dg)
        Me.pnl.Location = New System.Drawing.Point(185, 84)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(315, 197)
        Me.pnl.TabIndex = 14
        Me.pnl.Visible = False
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.AllowUserToDeleteRows = False
        Me.Dg.AllowUserToResizeColumns = False
        Me.Dg.AllowUserToResizeRows = False
        Me.Dg.BackgroundColor = System.Drawing.Color.White
        Me.Dg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dg.DefaultCellStyle = DataGridViewCellStyle1
        Me.Dg.Location = New System.Drawing.Point(3, 3)
        Me.Dg.Name = "Dg"
        Me.Dg.ReadOnly = True
        Me.Dg.RowHeadersVisible = False
        Me.Dg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dg.Size = New System.Drawing.Size(305, 187)
        Me.Dg.TabIndex = 0
        '
        'Txtremark
        '
        Me.Txtremark.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtremark.Location = New System.Drawing.Point(185, 84)
        Me.Txtremark.Multiline = True
        Me.Txtremark.Name = "Txtremark"
        Me.Txtremark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txtremark.Size = New System.Drawing.Size(238, 82)
        Me.Txtremark.TabIndex = 5
        '
        'Txtdept
        '
        Me.Txtdept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtdept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdept.Location = New System.Drawing.Point(185, 54)
        Me.Txtdept.Name = "Txtdept"
        Me.Txtdept.Size = New System.Drawing.Size(238, 22)
        Me.Txtdept.TabIndex = 4
        Me.Txtdept.Tag = "Name"
        '
        'Txtcode
        '
        Me.Txtcode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcode.Location = New System.Drawing.Point(507, 54)
        Me.Txtcode.Name = "Txtcode"
        Me.Txtcode.Size = New System.Drawing.Size(122, 22)
        Me.Txtcode.TabIndex = 3
        Me.Txtcode.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(35, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Remark :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Department Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(445, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code :"
        Me.Label1.Visible = False
        '
        'CustGrp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 746)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "CustGrp"
        Me.Text = "Department"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl.ResumeLayout(False)
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txtremark As System.Windows.Forms.TextBox
    Friend WithEvents Txtdept As System.Windows.Forms.TextBox
    Friend WithEvents Txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents Dg As System.Windows.Forms.DataGridView
    Friend WithEvents Tsbadd As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbsave As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbclear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsbexit As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblcap As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
