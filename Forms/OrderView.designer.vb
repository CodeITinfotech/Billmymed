<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class OrderView
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents comexit As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.comexit = New System.Windows.Forms.Button
        Me.grd = New System.Windows.Forms.DataGridView
        Me.Orddt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pack = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Free = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RctQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RctFre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SndAll = New System.Windows.Forms.Button
        Me.chkdel = New System.Windows.Forms.CheckBox
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comexit
        '
        Me.comexit.BackColor = System.Drawing.SystemColors.Control
        Me.comexit.Cursor = System.Windows.Forms.Cursors.Default
        Me.comexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.comexit.Location = New System.Drawing.Point(625, 439)
        Me.comexit.Name = "comexit"
        Me.comexit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.comexit.Size = New System.Drawing.Size(73, 25)
        Me.comexit.TabIndex = 1
        Me.comexit.Text = "E&xit"
        Me.comexit.UseVisualStyleBackColor = False
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.AllowUserToResizeRows = False
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orddt, Me.OrdNo, Me.PCode, Me.Pname, Me.pack, Me.Qty, Me.Free, Me.RctQty, Me.RctFre})
        Me.grd.Location = New System.Drawing.Point(12, 21)
        Me.grd.Name = "grd"
        Me.grd.RowHeadersVisible = False
        Me.grd.Size = New System.Drawing.Size(696, 410)
        Me.grd.TabIndex = 2
        '
        'Orddt
        '
        Me.Orddt.DataPropertyName = "orddt"
        Me.Orddt.HeaderText = "Ord Date"
        Me.Orddt.Name = "Orddt"
        Me.Orddt.Width = 80
        '
        'OrdNo
        '
        Me.OrdNo.DataPropertyName = "ordno"
        Me.OrdNo.HeaderText = "No"
        Me.OrdNo.Name = "OrdNo"
        Me.OrdNo.Width = 50
        '
        'PCode
        '
        Me.PCode.DataPropertyName = "prdcode"
        Me.PCode.HeaderText = "Code"
        Me.PCode.Name = "PCode"
        Me.PCode.Visible = False
        '
        'Pname
        '
        Me.Pname.DataPropertyName = "prdname"
        Me.Pname.HeaderText = "Product Name"
        Me.Pname.Name = "Pname"
        Me.Pname.Width = 200
        '
        'pack
        '
        Me.pack.DataPropertyName = "pack"
        Me.pack.HeaderText = "Pack"
        Me.pack.Name = "pack"
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 60
        '
        'Free
        '
        Me.Free.DataPropertyName = "free"
        Me.Free.HeaderText = "Free"
        Me.Free.Name = "Free"
        Me.Free.Width = 60
        '
        'RctQty
        '
        Me.RctQty.DataPropertyName = "rctqty"
        Me.RctQty.HeaderText = "R Qty"
        Me.RctQty.Name = "RctQty"
        Me.RctQty.Width = 60
        '
        'RctFre
        '
        Me.RctFre.DataPropertyName = "Rctfree"
        Me.RctFre.HeaderText = "R Fr"
        Me.RctFre.Name = "RctFre"
        Me.RctFre.Width = 60
        '
        'SndAll
        '
        Me.SndAll.BackColor = System.Drawing.SystemColors.Control
        Me.SndAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.SndAll.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SndAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SndAll.Location = New System.Drawing.Point(12, 439)
        Me.SndAll.Name = "SndAll"
        Me.SndAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SndAll.Size = New System.Drawing.Size(189, 25)
        Me.SndAll.TabIndex = 3
        Me.SndAll.Text = "Send all 'RED' to short item list "
        Me.SndAll.UseVisualStyleBackColor = False
        Me.SndAll.Visible = False
        '
        'chkdel
        '
        Me.chkdel.AutoSize = True
        Me.chkdel.Checked = True
        Me.chkdel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdel.Location = New System.Drawing.Point(492, 446)
        Me.chkdel.Name = "chkdel"
        Me.chkdel.Size = New System.Drawing.Size(93, 18)
        Me.chkdel.TabIndex = 4
        Me.chkdel.Text = "Delete Orders"
        Me.chkdel.UseVisualStyleBackColor = True
        '
        'OrderView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(710, 476)
        Me.Controls.Add(Me.chkdel)
        Me.Controls.Add(Me.SndAll)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.comexit)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OrderView"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Order View"
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd As System.Windows.Forms.DataGridView
    Friend WithEvents Orddt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Free As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RctQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RctFre As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents SndAll As System.Windows.Forms.Button
    Friend WithEvents chkdel As System.Windows.Forms.CheckBox
#End Region
End Class