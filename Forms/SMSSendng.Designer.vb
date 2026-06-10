<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMSSendng
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SMSSendng))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSend = New System.Windows.Forms.ToolStripButton()
        Me.tsbClr = New System.Windows.Forms.ToolStripButton()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCust = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgCust = New System.Windows.Forms.DataGridView()
        Me.CustCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCustNm = New System.Windows.Forms.DataGridView()
        Me.lblCustGrp = New System.Windows.Forms.Label()
        Me.cmbCustGrp = New System.Windows.Forms.ComboBox()
        Me.btnCustGrp = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbLoyaltyCust = New System.Windows.Forms.RadioButton()
        Me.rdbCust = New System.Windows.Forms.RadioButton()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCustNm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSend, Me.tsbClr, Me.tsbExit, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1028, 36)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsbSend
        '
        Me.tsbSend.AutoSize = False
        Me.tsbSend.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSend.Image = CType(resources.GetObject("tsbSend.Image"), System.Drawing.Image)
        Me.tsbSend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSend.Name = "tsbSend"
        Me.tsbSend.Size = New System.Drawing.Size(80, 33)
        Me.tsbSend.Text = "&Send"
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
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(650, 33)
        Me.ToolStripLabel1.Text = "SMS Sending"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Text :"
        '
        'txtText
        '
        Me.txtText.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(154, 29)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(353, 119)
        Me.txtText.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Customer :"
        '
        'txtCust
        '
        Me.txtCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCust.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(154, 156)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(353, 22)
        Me.txtCust.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Location = New System.Drawing.Point(547, 154)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 26)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgCust
        '
        Me.dgCust.AllowUserToAddRows = False
        Me.dgCust.AllowUserToResizeColumns = False
        Me.dgCust.AllowUserToResizeRows = False
        Me.dgCust.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgCust.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCust.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCust.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCust.ColumnHeadersHeight = 27
        Me.dgCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustCode, Me.CustName, Me.Mobile})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCust.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCust.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCust.EnableHeadersVisualStyles = False
        Me.dgCust.Location = New System.Drawing.Point(154, 228)
        Me.dgCust.Name = "dgCust"
        Me.dgCust.ReadOnly = True
        Me.dgCust.RowHeadersVisible = False
        Me.dgCust.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCust.Size = New System.Drawing.Size(467, 283)
        Me.dgCust.TabIndex = 6
        '
        'CustCode
        '
        Me.CustCode.HeaderText = "Customer Code"
        Me.CustCode.Name = "CustCode"
        Me.CustCode.ReadOnly = True
        Me.CustCode.Visible = False
        '
        'CustName
        '
        Me.CustName.HeaderText = "Customer Name"
        Me.CustName.Name = "CustName"
        Me.CustName.ReadOnly = True
        Me.CustName.Width = 300
        '
        'Mobile
        '
        Me.Mobile.HeaderText = "Mobile"
        Me.Mobile.Name = "Mobile"
        Me.Mobile.ReadOnly = True
        Me.Mobile.Width = 150
        '
        'dgCustNm
        '
        Me.dgCustNm.AllowUserToAddRows = False
        Me.dgCustNm.AllowUserToDeleteRows = False
        Me.dgCustNm.AllowUserToResizeColumns = False
        Me.dgCustNm.AllowUserToResizeRows = False
        Me.dgCustNm.BackgroundColor = System.Drawing.Color.Wheat
        Me.dgCustNm.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCustNm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCustNm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCustNm.ColumnHeadersHeight = 27
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustNm.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCustNm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCustNm.EnableHeadersVisualStyles = False
        Me.dgCustNm.Location = New System.Drawing.Point(154, 228)
        Me.dgCustNm.Name = "dgCustNm"
        Me.dgCustNm.ReadOnly = True
        Me.dgCustNm.RowHeadersVisible = False
        Me.dgCustNm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCustNm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustNm.Size = New System.Drawing.Size(549, 303)
        Me.dgCustNm.TabIndex = 7
        Me.dgCustNm.Visible = False
        '
        'lblCustGrp
        '
        Me.lblCustGrp.AutoSize = True
        Me.lblCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustGrp.Location = New System.Drawing.Point(12, 189)
        Me.lblCustGrp.Name = "lblCustGrp"
        Me.lblCustGrp.Size = New System.Drawing.Size(136, 16)
        Me.lblCustGrp.TabIndex = 8
        Me.lblCustGrp.Text = "Customer Group :"
        '
        'cmbCustGrp
        '
        Me.cmbCustGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustGrp.FormattingEnabled = True
        Me.cmbCustGrp.Location = New System.Drawing.Point(154, 186)
        Me.cmbCustGrp.Name = "cmbCustGrp"
        Me.cmbCustGrp.Size = New System.Drawing.Size(353, 24)
        Me.cmbCustGrp.TabIndex = 9
        '
        'btnCustGrp
        '
        Me.btnCustGrp.BackColor = System.Drawing.Color.Transparent
        Me.btnCustGrp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustGrp.ForeColor = System.Drawing.Color.Black
        Me.btnCustGrp.Location = New System.Drawing.Point(547, 184)
        Me.btnCustGrp.Name = "btnCustGrp"
        Me.btnCustGrp.Size = New System.Drawing.Size(85, 26)
        Me.btnCustGrp.TabIndex = 10
        Me.btnCustGrp.Text = "Add"
        Me.btnCustGrp.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.rdbLoyaltyCust)
        Me.Panel1.Controls.Add(Me.rdbCust)
        Me.Panel1.Controls.Add(Me.txtText)
        Me.Panel1.Controls.Add(Me.txtCust)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblCustGrp)
        Me.Panel1.Controls.Add(Me.dgCustNm)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.dgCust)
        Me.Panel1.Controls.Add(Me.btnCustGrp)
        Me.Panel1.Controls.Add(Me.cmbCustGrp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 591)
        Me.Panel1.TabIndex = 11
        '
        'rdbLoyaltyCust
        '
        Me.rdbLoyaltyCust.AutoSize = True
        Me.rdbLoyaltyCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbLoyaltyCust.Location = New System.Drawing.Point(746, 156)
        Me.rdbLoyaltyCust.Name = "rdbLoyaltyCust"
        Me.rdbLoyaltyCust.Size = New System.Drawing.Size(134, 19)
        Me.rdbLoyaltyCust.TabIndex = 150
        Me.rdbLoyaltyCust.TabStop = True
        Me.rdbLoyaltyCust.Text = "Loyalty Customer"
        Me.rdbLoyaltyCust.UseVisualStyleBackColor = True
        '
        'rdbCust
        '
        Me.rdbCust.AutoSize = True
        Me.rdbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbCust.Location = New System.Drawing.Point(648, 156)
        Me.rdbCust.Name = "rdbCust"
        Me.rdbCust.Size = New System.Drawing.Size(86, 19)
        Me.rdbCust.TabIndex = 149
        Me.rdbCust.TabStop = True
        Me.rdbCust.Text = "Customer"
        Me.rdbCust.UseVisualStyleBackColor = True
        '
        'SMSSendng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1028, 627)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "SMSSendng"
        Me.Text = "SMS Sending"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCustNm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSend As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClr As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgCust As System.Windows.Forms.DataGridView
    Friend WithEvents dgCustNm As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblCustGrp As System.Windows.Forms.Label
    Friend WithEvents cmbCustGrp As System.Windows.Forms.ComboBox
    Friend WithEvents btnCustGrp As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CustCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdbLoyaltyCust As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCust As System.Windows.Forms.RadioButton
End Class
