<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillCopy
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnFile = New System.Windows.Forms.Button()
        Me.lblBilDt = New System.Windows.Forms.Label()
        Me.lblSalno = New System.Windows.Forms.Label()
        Me.txtNof = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.ChkPrePrint = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpt = New System.Windows.Forms.DateTimePicker()
        Me.dtpf = New System.Windows.Forms.DateTimePicker()
        Me.txtNot = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnPrint, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnView, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnCancel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnFile, 2, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(204, 149)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(285, 29)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnPrint
        '
        Me.btnPrint.AutoSize = True
        Me.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPrint.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(3, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(65, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "&Print"
        '
        'BtnView
        '
        Me.BtnView.AutoSize = True
        Me.BtnView.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnView.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnView.Location = New System.Drawing.Point(74, 3)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(65, 23)
        Me.BtnView.TabIndex = 1
        Me.BtnView.Text = "&View"
        '
        'BtnCancel
        '
        Me.BtnCancel.AutoSize = True
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnCancel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(216, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "&Cancel"
        '
        'BtnFile
        '
        Me.BtnFile.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnFile.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFile.Location = New System.Drawing.Point(145, 3)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(65, 23)
        Me.BtnFile.TabIndex = 2
        Me.BtnFile.Text = "&File"
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Controls.Add(Me.lblType)
        Me.Panel1.Controls.Add(Me.ChkPrePrint)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpt)
        Me.Panel1.Controls.Add(Me.dtpf)
        Me.Panel1.Controls.Add(Me.txtNot)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtNof)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.lblSalno)
        Me.Panel1.Controls.Add(Me.lblBilDt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 185)
        Me.Panel1.TabIndex = 0
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
        'ChkPrePrint
        '
        Me.ChkPrePrint.AutoSize = True
        Me.ChkPrePrint.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPrePrint.Location = New System.Drawing.Point(35, 154)
        Me.ChkPrePrint.Name = "ChkPrePrint"
        Me.ChkPrePrint.Size = New System.Drawing.Size(163, 20)
        Me.ChkPrePrint.TabIndex = 5
        Me.ChkPrePrint.Text = "Pre-Print Format "
        Me.ChkPrePrint.UseVisualStyleBackColor = True
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
        'BillCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(503, 185)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BillCopy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBilDt As System.Windows.Forms.Label
    Friend WithEvents lblSalno As System.Windows.Forms.Label
    Friend WithEvents txtNof As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNot As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpf As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkPrePrint As System.Windows.Forms.CheckBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnView As System.Windows.Forms.Button
    Friend WithEvents BtnFile As System.Windows.Forms.Button

End Class
