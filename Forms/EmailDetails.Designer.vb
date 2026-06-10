<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailDetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.CANCEL_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.txteMail = New System.Windows.Forms.TextBox()
        Me.rdbCust = New System.Windows.Forms.RadioButton()
        Me.rdbLoyaltyCust = New System.Windows.Forms.RadioButton()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgCust = New System.Windows.Forms.DataGridView()
        Me.CustCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(46, 92)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(64, 16)
        Me.lblEmail.TabIndex = 137
        Me.lblEmail.Text = "Email :"
        '
        'lblCust
        '
        Me.lblCust.AutoSize = True
        Me.lblCust.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust.Location = New System.Drawing.Point(22, 50)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(88, 16)
        Me.lblCust.TabIndex = 138
        Me.lblCust.Text = "Customer :"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(123, 50)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(211, 21)
        Me.cbCustomer.TabIndex = 139
        '
        'CANCEL_Button
        '
        Me.CANCEL_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CANCEL_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CANCEL_Button.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CANCEL_Button.Location = New System.Drawing.Point(248, 406)
        Me.CANCEL_Button.Name = "CANCEL_Button"
        Me.CANCEL_Button.Size = New System.Drawing.Size(67, 23)
        Me.CANCEL_Button.TabIndex = 141
        Me.CANCEL_Button.Text = "&Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(175, 406)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 140
        Me.OK_Button.Text = "O&K"
        '
        'txteMail
        '
        Me.txteMail.Location = New System.Drawing.Point(123, 88)
        Me.txteMail.Name = "txteMail"
        Me.txteMail.Size = New System.Drawing.Size(211, 20)
        Me.txteMail.TabIndex = 142
        '
        'rdbCust
        '
        Me.rdbCust.AutoSize = True
        Me.rdbCust.Location = New System.Drawing.Point(25, 12)
        Me.rdbCust.Name = "rdbCust"
        Me.rdbCust.Size = New System.Drawing.Size(69, 17)
        Me.rdbCust.TabIndex = 143
        Me.rdbCust.TabStop = True
        Me.rdbCust.Text = "Customer"
        Me.rdbCust.UseVisualStyleBackColor = True
        '
        'rdbLoyaltyCust
        '
        Me.rdbLoyaltyCust.AutoSize = True
        Me.rdbLoyaltyCust.Location = New System.Drawing.Point(123, 12)
        Me.rdbLoyaltyCust.Name = "rdbLoyaltyCust"
        Me.rdbLoyaltyCust.Size = New System.Drawing.Size(105, 17)
        Me.rdbLoyaltyCust.TabIndex = 144
        Me.rdbLoyaltyCust.TabStop = True
        Me.rdbLoyaltyCust.Text = "Loyalty Customer"
        Me.rdbLoyaltyCust.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAdd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(343, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 23)
        Me.btnAdd.TabIndex = 145
        Me.btnAdd.Text = "&Add"
        '
        'dgCust
        '
        Me.dgCust.AllowUserToAddRows = False
        Me.dgCust.AllowUserToResizeColumns = False
        Me.dgCust.AllowUserToResizeRows = False
        Me.dgCust.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgCust.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgCust.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCust.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCust.ColumnHeadersHeight = 27
        Me.dgCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgCust.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustCode, Me.CustName, Me.Email})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCust.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCust.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCust.EnableHeadersVisualStyles = False
        Me.dgCust.Location = New System.Drawing.Point(25, 126)
        Me.dgCust.Name = "dgCust"
        Me.dgCust.ReadOnly = True
        Me.dgCust.RowHeadersVisible = False
        Me.dgCust.RowHeadersWidth = 35
        Me.dgCust.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCust.Size = New System.Drawing.Size(484, 274)
        Me.dgCust.TabIndex = 146
        '
        'CustCode
        '
        Me.CustCode.HeaderText = "Code"
        Me.CustCode.Name = "CustCode"
        Me.CustCode.ReadOnly = True
        Me.CustCode.Visible = False
        '
        'CustName
        '
        Me.CustName.HeaderText = "Customer Name"
        Me.CustName.Name = "CustName"
        Me.CustName.ReadOnly = True
        Me.CustName.Width = 270
        '
        'Email
        '
        Me.Email.HeaderText = "Email ID"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 200
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(321, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 23)
        Me.Button1.TabIndex = 147
        Me.Button1.Text = "C&lear"
        '
        'EmailDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(534, 451)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgCust)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.rdbLoyaltyCust)
        Me.Controls.Add(Me.rdbCust)
        Me.Controls.Add(Me.txteMail)
        Me.Controls.Add(Me.CANCEL_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.lblCust)
        Me.Controls.Add(Me.lblEmail)
        Me.Name = "EmailDetails"
        Me.Text = "EmailDetails"
        CType(Me.dgCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblCust As System.Windows.Forms.Label
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents CANCEL_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents txteMail As System.Windows.Forms.TextBox
    Friend WithEvents rdbCust As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLoyaltyCust As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgCust As System.Windows.Forms.DataGridView
    Friend WithEvents CustCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
