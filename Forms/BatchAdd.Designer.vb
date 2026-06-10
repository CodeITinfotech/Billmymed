<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchAdd
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
        Me.txtExDt = New System.Windows.Forms.MaskedTextBox()
        Me.lblBatch = New System.Windows.Forms.Label()
        Me.txtMRP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSVat = New System.Windows.Forms.Label()
        Me.cbSVat = New System.Windows.Forms.ComboBox()
        Me.cbbat = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CachedCustwise1 = New Amruth_II_Pharma_Retail.CachedCustwise()
        Me.cbPUnit = New System.Windows.Forms.ComboBox()
        Me.lblTB = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtExDt
        '
        Me.txtExDt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExDt.Location = New System.Drawing.Point(123, 57)
        Me.txtExDt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtExDt.Mask = "00/00/0000"
        Me.txtExDt.Name = "txtExDt"
        Me.txtExDt.Size = New System.Drawing.Size(99, 22)
        Me.txtExDt.TabIndex = 1
        Me.txtExDt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtExDt.ValidatingType = GetType(Date)
        '
        'lblBatch
        '
        Me.lblBatch.AutoSize = True
        Me.lblBatch.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatch.Location = New System.Drawing.Point(45, 30)
        Me.lblBatch.Name = "lblBatch"
        Me.lblBatch.Size = New System.Drawing.Size(64, 16)
        Me.lblBatch.TabIndex = 141
        Me.lblBatch.Text = "Batch :"
        '
        'txtMRP
        '
        Me.txtMRP.Location = New System.Drawing.Point(122, 86)
        Me.txtMRP.Name = "txtMRP"
        Me.txtMRP.Size = New System.Drawing.Size(100, 20)
        Me.txtMRP.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Ex Dt :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "MRP   :"
        '
        'lblSVat
        '
        Me.lblSVat.AutoSize = True
        Me.lblSVat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSVat.Location = New System.Drawing.Point(45, 116)
        Me.lblSVat.Name = "lblSVat"
        Me.lblSVat.Size = New System.Drawing.Size(64, 16)
        Me.lblSVat.TabIndex = 148
        Me.lblSVat.Text = "VAT%  :"
        '
        'cbSVat
        '
        Me.cbSVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSVat.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSVat.FormattingEnabled = True
        Me.cbSVat.Location = New System.Drawing.Point(122, 113)
        Me.cbSVat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbSVat.Name = "cbSVat"
        Me.cbSVat.Size = New System.Drawing.Size(100, 24)
        Me.cbSVat.TabIndex = 4
        '
        'cbbat
        '
        Me.cbbat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbbat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbbat.FormattingEnabled = True
        Me.cbbat.Location = New System.Drawing.Point(123, 30)
        Me.cbbat.Name = "cbbat"
        Me.cbbat.Size = New System.Drawing.Size(114, 21)
        Me.cbbat.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(122, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 32)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(238, 150)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 32)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbPUnit
        '
        Me.cbPUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPUnit.BackColor = System.Drawing.SystemColors.Menu
        Me.cbPUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPUnit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPUnit.FormattingEnabled = True
        Me.cbPUnit.Location = New System.Drawing.Point(228, 87)
        Me.cbPUnit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbPUnit.MaxDropDownItems = 15
        Me.cbPUnit.Name = "cbPUnit"
        Me.cbPUnit.Size = New System.Drawing.Size(109, 24)
        Me.cbPUnit.TabIndex = 3
        '
        'lblTB
        '
        Me.lblTB.AutoSize = True
        Me.lblTB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTB.ForeColor = System.Drawing.Color.Navy
        Me.lblTB.Location = New System.Drawing.Point(297, 67)
        Me.lblTB.Name = "lblTB"
        Me.lblTB.Size = New System.Drawing.Size(40, 16)
        Me.lblTB.TabIndex = 154
        Me.lblTB.Text = "Unit"
        '
        'BatchAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(365, 201)
        Me.Controls.Add(Me.lblTB)
        Me.Controls.Add(Me.cbPUnit)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbbat)
        Me.Controls.Add(Me.cbSVat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMRP)
        Me.Controls.Add(Me.txtExDt)
        Me.Controls.Add(Me.lblBatch)
        Me.Controls.Add(Me.lblSVat)
        Me.Name = "BatchAdd"
        Me.Text = "Add Stock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtExDt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblBatch As System.Windows.Forms.Label
    Friend WithEvents CachedCustwise1 As Amruth_II_Pharma_Retail.CachedCustwise
    Friend WithEvents txtMRP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSVat As System.Windows.Forms.Label
    Friend WithEvents cbSVat As System.Windows.Forms.ComboBox
    Friend WithEvents cbbat As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbPUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lblTB As System.Windows.Forms.Label
End Class
