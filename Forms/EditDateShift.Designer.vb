<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditDateShift
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
        Me.lblBilDt = New System.Windows.Forms.Label()
        Me.lblSalno = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbshft = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpt = New System.Windows.Forms.DateTimePicker()
        Me.dtpf = New System.Windows.Forms.DateTimePicker()
        Me.txtNot = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNof = New System.Windows.Forms.TextBox()
        Me.txtdoc = New System.Windows.Forms.TextBox()
        Me.txtpat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UpdPat = New System.Windows.Forms.Button()
        Me.UpdDoc = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBilDt
        '
        Me.lblBilDt.AutoSize = True
        Me.lblBilDt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBilDt.Location = New System.Drawing.Point(32, 56)
        Me.lblBilDt.Name = "lblBilDt"
        Me.lblBilDt.Size = New System.Drawing.Size(56, 16)
        Me.lblBilDt.TabIndex = 1
        Me.lblBilDt.Text = "Period"
        '
        'lblSalno
        '
        Me.lblSalno.AutoSize = True
        Me.lblSalno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalno.Location = New System.Drawing.Point(56, 109)
        Me.lblSalno.Name = "lblSalno"
        Me.lblSalno.Size = New System.Drawing.Size(40, 16)
        Me.lblSalno.TabIndex = 135
        Me.lblSalno.Text = "from"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.UpdDoc)
        Me.Panel1.Controls.Add(Me.UpdPat)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtpat)
        Me.Panel1.Controls.Add(Me.txtdoc)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cbshft)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtp)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Controls.Add(Me.lblType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpt)
        Me.Panel1.Controls.Add(Me.dtpf)
        Me.Panel1.Controls.Add(Me.txtNot)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtNof)
        Me.Panel1.Controls.Add(Me.lblSalno)
        Me.Panel1.Controls.Add(Me.lblBilDt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 488)
        Me.Panel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(176, 432)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(126, 32)
        Me.Button3.TabIndex = 152
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(250, 259)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 23)
        Me.Button2.TabIndex = 151
        Me.Button2.Text = "Update Shift"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbshft
        '
        Me.cbshft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbshft.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbshft.FormattingEnabled = True
        Me.cbshft.Location = New System.Drawing.Point(118, 260)
        Me.cbshft.Name = "cbshft"
        Me.cbshft.Size = New System.Drawing.Size(121, 24)
        Me.cbshft.TabIndex = 150
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = "New Shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "New Date"
        '
        'dtp
        '
        Me.dtp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(118, 219)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(126, 22)
        Me.dtp.TabIndex = 147
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(249, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 23)
        Me.Button1.TabIndex = 146
        Me.Button1.Text = "Update Date"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(100, 14)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(150, 24)
        Me.cbType.TabIndex = 2
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(32, 17)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(48, 16)
        Me.lblType.TabIndex = 145
        Me.lblType.Text = "Type "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Bill No"
        '
        'dtpt
        '
        Me.dtpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpt.Location = New System.Drawing.Point(250, 53)
        Me.dtpt.Name = "dtpt"
        Me.dtpt.Size = New System.Drawing.Size(126, 22)
        Me.dtpt.TabIndex = 4
        '
        'dtpf
        '
        Me.dtpf.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpf.Location = New System.Drawing.Point(100, 53)
        Me.dtpf.Name = "dtpf"
        Me.dtpf.Size = New System.Drawing.Size(120, 22)
        Me.dtpf.TabIndex = 3
        '
        'txtNot
        '
        Me.txtNot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNot.Location = New System.Drawing.Point(250, 106)
        Me.txtNot.MaxLength = 10
        Me.txtNot.Name = "txtNot"
        Me.txtNot.Size = New System.Drawing.Size(74, 22)
        Me.txtNot.TabIndex = 1
        Me.txtNot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(220, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "to"
        '
        'txtNof
        '
        Me.txtNof.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNof.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNof.Location = New System.Drawing.Point(100, 106)
        Me.txtNof.MaxLength = 10
        Me.txtNof.Name = "txtNof"
        Me.txtNof.Size = New System.Drawing.Size(82, 22)
        Me.txtNof.TabIndex = 0
        Me.txtNof.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdoc
        '
        Me.txtdoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdoc.Location = New System.Drawing.Point(118, 300)
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(239, 22)
        Me.txtdoc.TabIndex = 153
        '
        'txtpat
        '
        Me.txtpat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpat.Location = New System.Drawing.Point(118, 340)
        Me.txtpat.Name = "txtpat"
        Me.txtpat.Size = New System.Drawing.Size(239, 22)
        Me.txtpat.TabIndex = 154
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "Doctor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 344)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Patient"
        '
        'UpdPat
        '
        Me.UpdPat.Location = New System.Drawing.Point(363, 340)
        Me.UpdPat.Name = "UpdPat"
        Me.UpdPat.Size = New System.Drawing.Size(126, 25)
        Me.UpdPat.TabIndex = 157
        Me.UpdPat.Text = "Update Patient Name"
        Me.UpdPat.UseVisualStyleBackColor = True
        '
        'UpdDoc
        '
        Me.UpdDoc.Location = New System.Drawing.Point(363, 297)
        Me.UpdDoc.Name = "UpdDoc"
        Me.UpdDoc.Size = New System.Drawing.Size(126, 25)
        Me.UpdDoc.TabIndex = 158
        Me.UpdDoc.Text = "Update Doctor Name"
        Me.UpdDoc.UseVisualStyleBackColor = True
        '
        'EditDateShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 488)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditDateShift"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Date & Shift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBilDt As System.Windows.Forms.Label
    Friend WithEvents lblSalno As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNot As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpf As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtNof As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbshft As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents UpdPat As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpat As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents UpdDoc As System.Windows.Forms.Button

End Class
