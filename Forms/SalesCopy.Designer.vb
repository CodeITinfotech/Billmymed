<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesCopy
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
        Me.btnPMth = New System.Windows.Forms.RadioButton()
        Me.rbCMth = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblBilNo = New System.Windows.Forms.Label()
        Me.ckbPrint = New System.Windows.Forms.CheckBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.cbPmth = New System.Windows.Forms.ComboBox()
        Me.txtFrm = New System.Windows.Forms.MaskedTextBox()
        Me.txtTo = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPMth
        '
        Me.btnPMth.AutoSize = True
        Me.btnPMth.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPMth.Location = New System.Drawing.Point(179, 24)
        Me.btnPMth.Name = "btnPMth"
        Me.btnPMth.Size = New System.Drawing.Size(138, 20)
        Me.btnPMth.TabIndex = 64
        Me.btnPMth.Text = "&Previous Month"
        Me.btnPMth.UseVisualStyleBackColor = True
        '
        'rbCMth
        '
        Me.rbCMth.AutoSize = True
        Me.rbCMth.Checked = True
        Me.rbCMth.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCMth.Location = New System.Drawing.Point(11, 24)
        Me.rbCMth.Name = "rbCMth"
        Me.rbCMth.Size = New System.Drawing.Size(130, 20)
        Me.rbCMth.TabIndex = 63
        Me.rbCMth.TabStop = True
        Me.rbCMth.Text = "&Current Month"
        Me.rbCMth.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(179, 174)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 62
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(3, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(67, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(76, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'cbType
        '
        Me.cbType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Cash"})
        Me.cbType.Location = New System.Drawing.Point(75, 62)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(74, 24)
        Me.cbType.TabIndex = 75
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(13, 65)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(56, 16)
        Me.lblType.TabIndex = 74
        Me.lblType.Text = "Type :"
        '
        'lblBilNo
        '
        Me.lblBilNo.AutoSize = True
        Me.lblBilNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBilNo.Location = New System.Drawing.Point(8, 102)
        Me.lblBilNo.Name = "lblBilNo"
        Me.lblBilNo.Size = New System.Drawing.Size(112, 16)
        Me.lblBilNo.TabIndex = 73
        Me.lblBilNo.Text = "Bill Number. "
        '
        'ckbPrint
        '
        Me.ckbPrint.AutoSize = True
        Me.ckbPrint.Checked = True
        Me.ckbPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbPrint.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbPrint.Location = New System.Drawing.Point(11, 179)
        Me.ckbPrint.Name = "ckbPrint"
        Me.ckbPrint.Size = New System.Drawing.Size(147, 20)
        Me.ckbPrint.TabIndex = 76
        Me.ckbPrint.Text = "Print To Window"
        Me.ckbPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ckbPrint.UseVisualStyleBackColor = True
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(155, 135)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(40, 16)
        Me.lblTo.TabIndex = 78
        Me.lblTo.Text = "To :"
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(13, 135)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(56, 16)
        Me.lblFrom.TabIndex = 77
        Me.lblFrom.Text = "From :"
        '
        'cbPmth
        '
        Me.cbPmth.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPmth.FormattingEnabled = True
        Me.cbPmth.Items.AddRange(New Object() {"Cash"})
        Me.cbPmth.Location = New System.Drawing.Point(201, 62)
        Me.cbPmth.Name = "cbPmth"
        Me.cbPmth.Size = New System.Drawing.Size(73, 24)
        Me.cbPmth.TabIndex = 81
        Me.cbPmth.Visible = False
        '
        'txtFrm
        '
        Me.txtFrm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrm.Location = New System.Drawing.Point(75, 132)
        Me.txtFrm.Mask = "00/00/0000"
        Me.txtFrm.Name = "txtFrm"
        Me.txtFrm.Size = New System.Drawing.Size(74, 22)
        Me.txtFrm.TabIndex = 83
        Me.txtFrm.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtFrm.ValidatingType = GetType(Date)
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTo.Location = New System.Drawing.Point(201, 132)
        Me.txtTo.Mask = "00/00/0000"
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(73, 22)
        Me.txtTo.TabIndex = 84
        Me.txtTo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtTo.ValidatingType = GetType(Date)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Wheat
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.txtTo)
        Me.Panel1.Controls.Add(Me.ckbPrint)
        Me.Panel1.Controls.Add(Me.txtFrm)
        Me.Panel1.Controls.Add(Me.btnPMth)
        Me.Panel1.Controls.Add(Me.cbPmth)
        Me.Panel1.Controls.Add(Me.rbCMth)
        Me.Panel1.Controls.Add(Me.lblTo)
        Me.Panel1.Controls.Add(Me.lblBilNo)
        Me.Panel1.Controls.Add(Me.lblFrom)
        Me.Panel1.Controls.Add(Me.lblType)
        Me.Panel1.Controls.Add(Me.cbType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(335, 216)
        Me.Panel1.TabIndex = 85
        '
        'SalesCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 216)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SalesCopy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Copy"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPMth As System.Windows.Forms.RadioButton
    Friend WithEvents rbCMth As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblBilNo As System.Windows.Forms.Label
    Friend WithEvents ckbPrint As System.Windows.Forms.CheckBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents cbPmth As System.Windows.Forms.ComboBox
    Friend WithEvents txtFrm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
