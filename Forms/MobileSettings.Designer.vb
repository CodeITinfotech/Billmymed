<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mobile_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mobile_Settings))
        Me.txtMobText = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtSenderId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTransactional = New System.Windows.Forms.CheckBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMob5 = New System.Windows.Forms.TextBox()
        Me.txtMob4 = New System.Windows.Forms.TextBox()
        Me.txtMob3 = New System.Windows.Forms.TextBox()
        Me.txtMob2 = New System.Windows.Forms.TextBox()
        Me.txtMob1 = New System.Windows.Forms.TextBox()
        Me.chkSMSSaleInfo = New System.Windows.Forms.CheckBox()
        Me.txtSMSSaleText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSendAftHrs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMobText
        '
        Me.txtMobText.Location = New System.Drawing.Point(88, 153)
        Me.txtMobText.Multiline = True
        Me.txtMobText.Name = "txtMobText"
        Me.txtMobText.Size = New System.Drawing.Size(238, 91)
        Me.txtMobText.TabIndex = 80
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(88, 79)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(238, 20)
        Me.txtPass.TabIndex = 78
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(88, 43)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(238, 20)
        Me.txtUserName.TabIndex = 77
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(11, 79)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(67, 15)
        Me.lblPass.TabIndex = 76
        Me.lblPass.Text = "Password :"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(11, 43)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(76, 15)
        Me.lblUserName.TabIndex = 75
        Me.lblUserName.Text = "User Name :"
        '
        'txtSenderId
        '
        Me.txtSenderId.Location = New System.Drawing.Point(88, 115)
        Me.txtSenderId.Name = "txtSenderId"
        Me.txtSenderId.Size = New System.Drawing.Size(238, 20)
        Me.txtSenderId.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Sender Id :"
        '
        'chkTransactional
        '
        Me.chkTransactional.AutoSize = True
        Me.chkTransactional.Location = New System.Drawing.Point(14, 256)
        Me.chkTransactional.Name = "chkTransactional"
        Me.chkTransactional.Size = New System.Drawing.Size(90, 17)
        Me.chkTransactional.TabIndex = 83
        Me.chkTransactional.Text = "Transactional"
        Me.chkTransactional.UseVisualStyleBackColor = True
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.ToolStripLabel1, Me.tsbCls, Me.tsbClear})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(755, 33)
        Me.ToolStrip.TabIndex = 84
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSave.ForeColor = System.Drawing.Color.Black
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(60, 30)
        Me.tsbSave.Text = "&Save"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Firebrick
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripLabel1.Size = New System.Drawing.Size(490, 30)
        Me.ToolStripLabel1.Text = "SMS Setting"
        '
        'tsbCls
        '
        Me.tsbCls.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCls.AutoSize = False
        Me.tsbCls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsbCls.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCls.ForeColor = System.Drawing.Color.Black
        Me.tsbCls.Image = CType(resources.GetObject("tsbCls.Image"), System.Drawing.Image)
        Me.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCls.Name = "tsbCls"
        Me.tsbCls.Size = New System.Drawing.Size(80, 30)
        Me.tsbCls.Text = "E&xit"
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
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 51)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Stock Arrived Intimation :"
        '
        'txtMob5
        '
        Me.txtMob5.Location = New System.Drawing.Point(352, 173)
        Me.txtMob5.Name = "txtMob5"
        Me.txtMob5.Size = New System.Drawing.Size(213, 20)
        Me.txtMob5.TabIndex = 91
        '
        'txtMob4
        '
        Me.txtMob4.Location = New System.Drawing.Point(352, 147)
        Me.txtMob4.Name = "txtMob4"
        Me.txtMob4.Size = New System.Drawing.Size(213, 20)
        Me.txtMob4.TabIndex = 90
        '
        'txtMob3
        '
        Me.txtMob3.Location = New System.Drawing.Point(352, 118)
        Me.txtMob3.Name = "txtMob3"
        Me.txtMob3.Size = New System.Drawing.Size(213, 20)
        Me.txtMob3.TabIndex = 89
        '
        'txtMob2
        '
        Me.txtMob2.Location = New System.Drawing.Point(352, 90)
        Me.txtMob2.Name = "txtMob2"
        Me.txtMob2.Size = New System.Drawing.Size(213, 20)
        Me.txtMob2.TabIndex = 88
        '
        'txtMob1
        '
        Me.txtMob1.Location = New System.Drawing.Point(352, 64)
        Me.txtMob1.Name = "txtMob1"
        Me.txtMob1.Size = New System.Drawing.Size(213, 20)
        Me.txtMob1.TabIndex = 87
        '
        'chkSMSSaleInfo
        '
        Me.chkSMSSaleInfo.AutoSize = True
        Me.chkSMSSaleInfo.Location = New System.Drawing.Point(352, 41)
        Me.chkSMSSaleInfo.Name = "chkSMSSaleInfo"
        Me.chkSMSSaleInfo.Size = New System.Drawing.Size(97, 17)
        Me.chkSMSSaleInfo.TabIndex = 86
        Me.chkSMSSaleInfo.Text = "SMS Sale Info."
        Me.chkSMSSaleInfo.UseVisualStyleBackColor = True
        '
        'txtSMSSaleText
        '
        Me.txtSMSSaleText.Location = New System.Drawing.Point(88, 291)
        Me.txtSMSSaleText.Multiline = True
        Me.txtSMSSaleText.Name = "txtSMSSaleText"
        Me.txtSMSSaleText.Size = New System.Drawing.Size(238, 91)
        Me.txtSMSSaleText.TabIndex = 93
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 51)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "SMS Sale Text"
        '
        'txtSendAftHrs
        '
        Me.txtSendAftHrs.Location = New System.Drawing.Point(108, 405)
        Me.txtSendAftHrs.Name = "txtSendAftHrs"
        Me.txtSendAftHrs.Size = New System.Drawing.Size(54, 20)
        Me.txtSendAftHrs.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 405)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Send After Hrs :"
        '
        'Mobile_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(755, 500)
        Me.Controls.Add(Me.txtSendAftHrs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSMSSaleText)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMob5)
        Me.Controls.Add(Me.txtMob4)
        Me.Controls.Add(Me.txtMob3)
        Me.Controls.Add(Me.txtMob2)
        Me.Controls.Add(Me.txtMob1)
        Me.Controls.Add(Me.chkSMSSaleInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.chkTransactional)
        Me.Controls.Add(Me.txtSenderId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMobText)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUserName)
        Me.Name = "Mobile_Settings"
        Me.Text = "Mobile Settings"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMobText As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtSenderId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTransactional As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtMob5 As System.Windows.Forms.TextBox
    Friend WithEvents txtMob4 As System.Windows.Forms.TextBox
    Friend WithEvents txtMob3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMob2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMob1 As System.Windows.Forms.TextBox
    Friend WithEvents chkSMSSaleInfo As System.Windows.Forms.CheckBox
    Friend WithEvents txtSMSSaleText As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSendAftHrs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
