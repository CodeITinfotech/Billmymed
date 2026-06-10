<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSales
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CANCEL_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.lblSalno = New System.Windows.Forms.Label
        Me.txtSalNo = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpt = New System.Windows.Forms.DateTimePicker
        Me.dtpf = New System.Windows.Forms.DateTimePicker
        Me.lblBilDt = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CANCEL_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(122, 99)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'CANCEL_Button
        '
        Me.CANCEL_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CANCEL_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CANCEL_Button.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CANCEL_Button.Location = New System.Drawing.Point(76, 3)
        Me.CANCEL_Button.Name = "CANCEL_Button"
        Me.CANCEL_Button.Size = New System.Drawing.Size(67, 23)
        Me.CANCEL_Button.TabIndex = 1
        Me.CANCEL_Button.Text = "&Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "O&K"
        '
        'lblSalno
        '
        Me.lblSalno.AutoSize = True
        Me.lblSalno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalno.Location = New System.Drawing.Point(18, 27)
        Me.lblSalno.Name = "lblSalno"
        Me.lblSalno.Size = New System.Drawing.Size(88, 16)
        Me.lblSalno.TabIndex = 135
        Me.lblSalno.Text = "Bill No. :"
        '
        'txtSalNo
        '
        Me.txtSalNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalNo.Location = New System.Drawing.Point(113, 24)
        Me.txtSalNo.MaxLength = 10
        Me.txtSalNo.Name = "txtSalNo"
        Me.txtSalNo.Size = New System.Drawing.Size(98, 22)
        Me.txtSalNo.TabIndex = 0
        Me.txtSalNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.dtpt)
        Me.Panel1.Controls.Add(Me.dtpf)
        Me.Panel1.Controls.Add(Me.lblBilDt)
        Me.Panel1.Controls.Add(Me.txtSalNo)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.lblSalno)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 142)
        Me.Panel1.TabIndex = 0
        '
        'dtpt
        '
        Me.dtpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpt.Location = New System.Drawing.Point(244, 55)
        Me.dtpt.Name = "dtpt"
        Me.dtpt.Size = New System.Drawing.Size(126, 22)
        Me.dtpt.TabIndex = 2
        '
        'dtpf
        '
        Me.dtpf.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpf.Location = New System.Drawing.Point(113, 55)
        Me.dtpf.Name = "dtpf"
        Me.dtpf.Size = New System.Drawing.Size(120, 22)
        Me.dtpf.TabIndex = 1
        '
        'lblBilDt
        '
        Me.lblBilDt.AutoSize = True
        Me.lblBilDt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBilDt.Location = New System.Drawing.Point(18, 61)
        Me.lblBilDt.Name = "lblBilDt"
        Me.lblBilDt.Size = New System.Drawing.Size(56, 16)
        Me.lblBilDt.TabIndex = 136
        Me.lblBilDt.Text = "Period"
        '
        'EditSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 142)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditSales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editing Sales"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSalno As System.Windows.Forms.Label
    Friend WithEvents txtSalNo As System.Windows.Forms.TextBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents CANCEL_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpf As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBilDt As System.Windows.Forms.Label

End Class
