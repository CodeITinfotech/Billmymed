<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Upload
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
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Comsall = New System.Windows.Forms.Button()
        Me.comdall = New System.Windows.Forms.Button()
        Me.lst = New System.Windows.Forms.CheckedListBox()
        Me.com_trans = New System.Windows.Forms.Button()
        Me.txtdt = New System.Windows.Forms.MaskedTextBox()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Frame1.Controls.Add(Me.Button1)
        Me.Frame1.Controls.Add(Me.Command1)
        Me.Frame1.Controls.Add(Me.Comsall)
        Me.Frame1.Controls.Add(Me.comdall)
        Me.Frame1.Controls.Add(Me.lst)
        Me.Frame1.Controls.Add(Me.com_trans)
        Me.Frame1.Controls.Add(Me.txtdt)
        Me.Frame1.Controls.Add(Me.pbar)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.Color.Red
        Me.Frame1.Location = New System.Drawing.Point(77, 32)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(561, 364)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Upload Orders "
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(445, 320)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(76, 25)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(200, 320)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(115, 25)
        Me.Command1.TabIndex = 8
        Me.Command1.Text = "Upload"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Comsall
        '
        Me.Comsall.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Comsall.Cursor = System.Windows.Forms.Cursors.Default
        Me.Comsall.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comsall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Comsall.Location = New System.Drawing.Point(320, 28)
        Me.Comsall.Name = "Comsall"
        Me.Comsall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Comsall.Size = New System.Drawing.Size(97, 29)
        Me.Comsall.TabIndex = 7
        Me.Comsall.Text = "&Select All"
        Me.Comsall.UseVisualStyleBackColor = False
        '
        'comdall
        '
        Me.comdall.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.comdall.Cursor = System.Windows.Forms.Cursors.Default
        Me.comdall.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comdall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.comdall.Location = New System.Drawing.Point(424, 28)
        Me.comdall.Name = "comdall"
        Me.comdall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comdall.Size = New System.Drawing.Size(97, 29)
        Me.comdall.TabIndex = 6
        Me.comdall.Text = "&Deselect All"
        Me.comdall.UseVisualStyleBackColor = False
        '
        'lst
        '
        Me.lst.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lst.Cursor = System.Windows.Forms.Cursors.Default
        Me.lst.Font = New System.Drawing.Font("Courier New", 8.4!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lst.Location = New System.Drawing.Point(16, 63)
        Me.lst.Name = "lst"
        Me.lst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lst.Size = New System.Drawing.Size(505, 229)
        Me.lst.Sorted = True
        Me.lst.TabIndex = 5
        '
        'com_trans
        '
        Me.com_trans.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.com_trans.Cursor = System.Windows.Forms.Cursors.Default
        Me.com_trans.Font = New System.Drawing.Font("Times New Roman", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.com_trans.ForeColor = System.Drawing.SystemColors.ControlText
        Me.com_trans.Location = New System.Drawing.Point(184, 28)
        Me.com_trans.Name = "com_trans"
        Me.com_trans.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.com_trans.Size = New System.Drawing.Size(65, 25)
        Me.com_trans.TabIndex = 2
        Me.com_trans.Text = "Show"
        Me.com_trans.UseVisualStyleBackColor = False
        '
        'txtdt
        '
        Me.txtdt.AllowPromptAsInput = False
        Me.txtdt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdt.Location = New System.Drawing.Point(72, 28)
        Me.txtdt.Mask = "##/##/####"
        Me.txtdt.Name = "txtdt"
        Me.txtdt.Size = New System.Drawing.Size(97, 20)
        Me.txtdt.TabIndex = 3
        '
        'pbar
        '
        Me.pbar.Location = New System.Drawing.Point(19, 298)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(502, 16)
        Me.pbar.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.6!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date :"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(926, 29)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "POPS - Upload Orders"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(926, 429)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Frame1)
        Me.Name = "Upload"
        Me.Text = "POPS - Upload Orders"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents Comsall As System.Windows.Forms.Button
    Public WithEvents comdall As System.Windows.Forms.Button
    Public WithEvents lst As System.Windows.Forms.CheckedListBox
    Public WithEvents com_trans As System.Windows.Forms.Button
    Public WithEvents txtdt As System.Windows.Forms.MaskedTextBox
    Public WithEvents pbar As System.Windows.Forms.ProgressBar
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Button1 As System.Windows.Forms.Button
End Class
