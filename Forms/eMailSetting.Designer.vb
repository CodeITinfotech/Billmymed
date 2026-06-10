<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eMailSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eMailSetting))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.lblPortNo = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.txtPortNo = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.chkWithHeader = New System.Windows.Forms.CheckBox()
        Me.txtEmailServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmailText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSMSSaleInfo = New System.Windows.Forms.CheckBox()
        Me.txtEmailSaleText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtId1 = New System.Windows.Forms.TextBox()
        Me.txtId5 = New System.Windows.Forms.TextBox()
        Me.txtId4 = New System.Windows.Forms.TextBox()
        Me.txtId3 = New System.Windows.Forms.TextBox()
        Me.txtId2 = New System.Windows.Forms.TextBox()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbCls, Me.tsbClear, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(745, 33)
        Me.ToolStrip.TabIndex = 61
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Firebrick
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripLabel1.Size = New System.Drawing.Size(480, 30)
        Me.ToolStripLabel1.Text = "Email Setting"
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.Location = New System.Drawing.Point(37, 61)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(32, 15)
        Me.lblHost.TabIndex = 62
        Me.lblHost.Text = "Host"
        '
        'lblPortNo
        '
        Me.lblPortNo.AutoSize = True
        Me.lblPortNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortNo.Location = New System.Drawing.Point(37, 96)
        Me.lblPortNo.Name = "lblPortNo"
        Me.lblPortNo.Size = New System.Drawing.Size(51, 15)
        Me.lblPortNo.TabIndex = 63
        Me.lblPortNo.Text = "Port No."
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(37, 131)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(70, 15)
        Me.lblUserName.TabIndex = 64
        Me.lblUserName.Text = "User Name"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(37, 160)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(61, 15)
        Me.lblPass.TabIndex = 65
        Me.lblPass.Text = "Password"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(114, 54)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(238, 20)
        Me.txtHost.TabIndex = 66
        '
        'txtPortNo
        '
        Me.txtPortNo.Location = New System.Drawing.Point(114, 89)
        Me.txtPortNo.Name = "txtPortNo"
        Me.txtPortNo.Size = New System.Drawing.Size(238, 20)
        Me.txtPortNo.TabIndex = 67
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(114, 124)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(238, 20)
        Me.txtUserName.TabIndex = 68
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(114, 160)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(238, 20)
        Me.txtPass.TabIndex = 69
        '
        'chkWithHeader
        '
        Me.chkWithHeader.AutoSize = True
        Me.chkWithHeader.Location = New System.Drawing.Point(114, 332)
        Me.chkWithHeader.Name = "chkWithHeader"
        Me.chkWithHeader.Size = New System.Drawing.Size(86, 17)
        Me.chkWithHeader.TabIndex = 70
        Me.chkWithHeader.Text = "With Header"
        Me.chkWithHeader.UseVisualStyleBackColor = True
        '
        'txtEmailServer
        '
        Me.txtEmailServer.Location = New System.Drawing.Point(114, 198)
        Me.txtEmailServer.Name = "txtEmailServer"
        Me.txtEmailServer.Size = New System.Drawing.Size(238, 20)
        Me.txtEmailServer.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "EmailServer"
        '
        'txtEmailText
        '
        Me.txtEmailText.Location = New System.Drawing.Point(114, 235)
        Me.txtEmailText.Multiline = True
        Me.txtEmailText.Name = "txtEmailText"
        Me.txtEmailText.Size = New System.Drawing.Size(238, 91)
        Me.txtEmailText.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 51)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Stock Arrived Intimation"
        '
        'chkSMSSaleInfo
        '
        Me.chkSMSSaleInfo.AutoSize = True
        Me.chkSMSSaleInfo.Location = New System.Drawing.Point(389, 54)
        Me.chkSMSSaleInfo.Name = "chkSMSSaleInfo"
        Me.chkSMSSaleInfo.Size = New System.Drawing.Size(99, 17)
        Me.chkSMSSaleInfo.TabIndex = 75
        Me.chkSMSSaleInfo.Text = "Email Sale Info."
        Me.chkSMSSaleInfo.UseVisualStyleBackColor = True
        '
        'txtEmailSaleText
        '
        Me.txtEmailSaleText.Location = New System.Drawing.Point(114, 356)
        Me.txtEmailSaleText.Multiline = True
        Me.txtEmailSaleText.Name = "txtEmailSaleText"
        Me.txtEmailSaleText.Size = New System.Drawing.Size(238, 91)
        Me.txtEmailSaleText.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoEllipsis = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 356)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 51)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Email Sale Text"
        '
        'txtId1
        '
        Me.txtId1.Location = New System.Drawing.Point(389, 77)
        Me.txtId1.Name = "txtId1"
        Me.txtId1.Size = New System.Drawing.Size(213, 20)
        Me.txtId1.TabIndex = 78
        '
        'txtId5
        '
        Me.txtId5.Location = New System.Drawing.Point(389, 186)
        Me.txtId5.Name = "txtId5"
        Me.txtId5.Size = New System.Drawing.Size(213, 20)
        Me.txtId5.TabIndex = 82
        '
        'txtId4
        '
        Me.txtId4.Location = New System.Drawing.Point(389, 160)
        Me.txtId4.Name = "txtId4"
        Me.txtId4.Size = New System.Drawing.Size(213, 20)
        Me.txtId4.TabIndex = 81
        '
        'txtId3
        '
        Me.txtId3.Location = New System.Drawing.Point(389, 131)
        Me.txtId3.Name = "txtId3"
        Me.txtId3.Size = New System.Drawing.Size(213, 20)
        Me.txtId3.TabIndex = 80
        '
        'txtId2
        '
        Me.txtId2.Location = New System.Drawing.Point(389, 103)
        Me.txtId2.Name = "txtId2"
        Me.txtId2.Size = New System.Drawing.Size(213, 20)
        Me.txtId2.TabIndex = 79
        '
        'eMailSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(745, 466)
        Me.Controls.Add(Me.txtId5)
        Me.Controls.Add(Me.txtId4)
        Me.Controls.Add(Me.txtId3)
        Me.Controls.Add(Me.txtId2)
        Me.Controls.Add(Me.txtId1)
        Me.Controls.Add(Me.txtEmailSaleText)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkSMSSaleInfo)
        Me.Controls.Add(Me.txtEmailText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmailServer)
        Me.Controls.Add(Me.chkWithHeader)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.txtPortNo)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblPortNo)
        Me.Controls.Add(Me.lblHost)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "eMailSetting"
        Me.Text = "eMailSetting"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents lblPortNo As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents txtPortNo As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents chkWithHeader As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmailServer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmailText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chkSMSSaleInfo As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmailSaleText As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtId1 As System.Windows.Forms.TextBox
    Friend WithEvents txtId5 As System.Windows.Forms.TextBox
    Friend WithEvents txtId4 As System.Windows.Forms.TextBox
    Friend WithEvents txtId3 As System.Windows.Forms.TextBox
    Friend WithEvents txtId2 As System.Windows.Forms.TextBox
End Class
