<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseCopy
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cbSupp = New System.Windows.Forms.ComboBox()
        Me.rbSupp = New System.Windows.Forms.RadioButton()
        Me.rbRcpt = New System.Windows.Forms.RadioButton()
        Me.txtBNo = New System.Windows.Forms.TextBox()
        Me.lblBNo = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.txtRctno = New System.Windows.Forms.TextBox()
        Me.rbDtAll = New System.Windows.Forms.RadioButton()
        Me.lblTo1 = New System.Windows.Forms.Label()
        Me.txtRctno2 = New System.Windows.Forms.TextBox()
        Me.pnlrct = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBilDt = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpt = New System.Windows.Forms.DateTimePicker()
        Me.dtpf = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlsup = New System.Windows.Forms.Panel()
        Me.dtpbdt = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlrct.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlsup.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(555, 517)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 44)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOK.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(4, 8)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&View"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(101, 8)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'cbSupp
        '
        Me.cbSupp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbSupp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSupp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSupp.FormattingEnabled = True
        Me.cbSupp.Location = New System.Drawing.Point(184, 17)
        Me.cbSupp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbSupp.Name = "cbSupp"
        Me.cbSupp.Size = New System.Drawing.Size(363, 26)
        Me.cbSupp.TabIndex = 1
        '
        'rbSupp
        '
        Me.rbSupp.AutoSize = True
        Me.rbSupp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSupp.Location = New System.Drawing.Point(28, 311)
        Me.rbSupp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbSupp.Name = "rbSupp"
        Me.rbSupp.Size = New System.Drawing.Size(110, 24)
        Me.rbSupp.TabIndex = 73
        Me.rbSupp.Text = "&Supplier"
        Me.rbSupp.UseVisualStyleBackColor = True
        '
        'rbRcpt
        '
        Me.rbRcpt.AutoSize = True
        Me.rbRcpt.Checked = True
        Me.rbRcpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRcpt.Location = New System.Drawing.Point(28, 180)
        Me.rbRcpt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbRcpt.Name = "rbRcpt"
        Me.rbRcpt.Size = New System.Drawing.Size(140, 24)
        Me.rbRcpt.TabIndex = 74
        Me.rbRcpt.TabStop = True
        Me.rbRcpt.Text = "&Receipt Nos"
        Me.rbRcpt.UseVisualStyleBackColor = True
        '
        'txtBNo
        '
        Me.txtBNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBNo.Location = New System.Drawing.Point(184, 54)
        Me.txtBNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBNo.MaxLength = 10
        Me.txtBNo.Name = "txtBNo"
        Me.txtBNo.Size = New System.Drawing.Size(124, 26)
        Me.txtBNo.TabIndex = 2
        Me.txtBNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBNo
        '
        Me.lblBNo.AutoSize = True
        Me.lblBNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBNo.Location = New System.Drawing.Point(16, 58)
        Me.lblBNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBNo.Name = "lblBNo"
        Me.lblBNo.Size = New System.Drawing.Size(109, 20)
        Me.lblBNo.TabIndex = 118
        Me.lblBNo.Text = "Bill No. :"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(20, 34)
        Me.lblType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(69, 20)
        Me.lblType.TabIndex = 120
        Me.lblType.Text = "Type :"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(128, 25)
        Me.cbType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(200, 26)
        Me.cbType.TabIndex = 119
        '
        'txtRctno
        '
        Me.txtRctno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRctno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRctno.Location = New System.Drawing.Point(103, 16)
        Me.txtRctno.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRctno.MaxLength = 10
        Me.txtRctno.Name = "txtRctno"
        Me.txtRctno.Size = New System.Drawing.Size(124, 26)
        Me.txtRctno.TabIndex = 0
        Me.txtRctno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbDtAll
        '
        Me.rbDtAll.AutoSize = True
        Me.rbDtAll.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDtAll.Location = New System.Drawing.Point(28, 132)
        Me.rbDtAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbDtAll.Name = "rbDtAll"
        Me.rbDtAll.Size = New System.Drawing.Size(60, 24)
        Me.rbDtAll.TabIndex = 124
        Me.rbDtAll.Text = "&All"
        Me.rbDtAll.UseVisualStyleBackColor = True
        '
        'lblTo1
        '
        Me.lblTo1.AutoSize = True
        Me.lblTo1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo1.Location = New System.Drawing.Point(271, 20)
        Me.lblTo1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTo1.Name = "lblTo1"
        Me.lblTo1.Size = New System.Drawing.Size(39, 20)
        Me.lblTo1.TabIndex = 126
        Me.lblTo1.Text = "To:"
        '
        'txtRctno2
        '
        Me.txtRctno2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRctno2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRctno2.Location = New System.Drawing.Point(321, 16)
        Me.txtRctno2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRctno2.MaxLength = 10
        Me.txtRctno2.Name = "txtRctno2"
        Me.txtRctno2.Size = New System.Drawing.Size(121, 26)
        Me.txtRctno2.TabIndex = 125
        Me.txtRctno2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlrct
        '
        Me.pnlrct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlrct.Controls.Add(Me.Label1)
        Me.pnlrct.Controls.Add(Me.txtRctno2)
        Me.pnlrct.Controls.Add(Me.txtRctno)
        Me.pnlrct.Controls.Add(Me.lblTo1)
        Me.pnlrct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlrct.Location = New System.Drawing.Point(28, 212)
        Me.pnlrct.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlrct.Name = "pnlrct"
        Me.pnlrct.Size = New System.Drawing.Size(567, 62)
        Me.pnlrct.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "From:"
        '
        'lblBilDt
        '
        Me.lblBilDt.AutoSize = True
        Me.lblBilDt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBilDt.Location = New System.Drawing.Point(16, 98)
        Me.lblBilDt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBilDt.Name = "lblBilDt"
        Me.lblBilDt.Size = New System.Drawing.Size(109, 20)
        Me.lblBilDt.TabIndex = 133
        Me.lblBilDt.Text = "Bill Date:"
        Me.lblBilDt.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.dtpt)
        Me.Panel1.Controls.Add(Me.dtpf)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.pnlsup)
        Me.Panel1.Controls.Add(Me.rbDtAll)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.pnlrct)
        Me.Panel1.Controls.Add(Me.rbSupp)
        Me.Panel1.Controls.Add(Me.rbRcpt)
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Controls.Add(Me.lblType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(783, 594)
        Me.Panel1.TabIndex = 134
        '
        'dtpt
        '
        Me.dtpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpt.Location = New System.Drawing.Point(313, 75)
        Me.dtpt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpt.Name = "dtpt"
        Me.dtpt.Size = New System.Drawing.Size(167, 26)
        Me.dtpt.TabIndex = 141
        '
        'dtpf
        '
        Me.dtpf.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpf.Location = New System.Drawing.Point(113, 75)
        Me.dtpf.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpf.Name = "dtpf"
        Me.dtpf.Size = New System.Drawing.Size(159, 26)
        Me.dtpf.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Period"
        '
        'pnlsup
        '
        Me.pnlsup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlsup.Controls.Add(Me.dtpbdt)
        Me.pnlsup.Controls.Add(Me.Label2)
        Me.pnlsup.Controls.Add(Me.cbSupp)
        Me.pnlsup.Controls.Add(Me.lblBNo)
        Me.pnlsup.Controls.Add(Me.txtBNo)
        Me.pnlsup.Controls.Add(Me.lblBilDt)
        Me.pnlsup.Enabled = False
        Me.pnlsup.Location = New System.Drawing.Point(28, 343)
        Me.pnlsup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlsup.Name = "pnlsup"
        Me.pnlsup.Size = New System.Drawing.Size(567, 134)
        Me.pnlsup.TabIndex = 138
        '
        'dtpbdt
        '
        Me.dtpbdt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbdt.Location = New System.Drawing.Point(184, 92)
        Me.dtpbdt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpbdt.Name = "dtpbdt"
        Me.dtpbdt.Size = New System.Drawing.Size(167, 26)
        Me.dtpbdt.TabIndex = 142
        Me.dtpbdt.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Supplier"
        '
        'PurchaseCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(783, 594)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PurchaseCopy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Copy"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlrct.ResumeLayout(False)
        Me.pnlrct.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlsup.ResumeLayout(False)
        Me.pnlsup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbSupp As System.Windows.Forms.ComboBox
    Friend WithEvents rbSupp As System.Windows.Forms.RadioButton
    Friend WithEvents rbRcpt As System.Windows.Forms.RadioButton
    Friend WithEvents txtBNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBNo As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtRctno As System.Windows.Forms.TextBox
    Friend WithEvents rbDtAll As System.Windows.Forms.RadioButton
    Friend WithEvents lblTo1 As System.Windows.Forms.Label
    Friend WithEvents txtRctno2 As System.Windows.Forms.TextBox
    Friend WithEvents pnlrct As System.Windows.Forms.Panel
    Friend WithEvents lblBilDt As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlsup As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpf As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpbdt As System.Windows.Forms.DateTimePicker

End Class
