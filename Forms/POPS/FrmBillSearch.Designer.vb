<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmBillSearch
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txt As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grd = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnUnmark = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.rclientid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Wclientid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Downloaded = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Place = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Billdt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(312, 28)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 33)
        Me.Command1.TabIndex = 1
        Me.Command1.Text = "Search"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'txt
        '
        Me.txt.AcceptsReturn = True
        Me.txt.BackColor = System.Drawing.SystemColors.Window
        Me.txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt.Location = New System.Drawing.Point(80, 35)
        Me.txt.MaxLength = 0
        Me.txt.Name = "txt"
        Me.txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt.Size = New System.Drawing.Size(225, 20)
        Me.txt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bill No"
        '
        'grd
        '
        Me.grd.AllowUserToAddRows = False
        Me.grd.AllowUserToDeleteRows = False
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rclientid, Me.Wclientid, Me.Downloaded, Me.Supplier, Me.Place, Me.BillNo, Me.Billdt})
        Me.grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grd.Location = New System.Drawing.Point(27, 73)
        Me.grd.Name = "grd"
        Me.grd.RowHeadersVisible = False
        Me.grd.Size = New System.Drawing.Size(957, 408)
        Me.grd.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(996, 29)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "POPS - Bill Search"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnUnmark
        '
        Me.BtnUnmark.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnUnmark.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnUnmark.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnmark.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnUnmark.Location = New System.Drawing.Point(640, 37)
        Me.BtnUnmark.Name = "BtnUnmark"
        Me.BtnUnmark.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnUnmark.Size = New System.Drawing.Size(73, 33)
        Me.BtnUnmark.TabIndex = 10
        Me.BtnUnmark.Text = "UnMark"
        Me.BtnUnmark.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(738, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(73, 33)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'rclientid
        '
        Me.rclientid.DataPropertyName = "rclientid"
        Me.rclientid.HeaderText = "rclientid"
        Me.rclientid.Name = "rclientid"
        Me.rclientid.Visible = False
        '
        'Wclientid
        '
        Me.Wclientid.DataPropertyName = "Wclientid"
        Me.Wclientid.HeaderText = "Wclientid"
        Me.Wclientid.Name = "Wclientid"
        Me.Wclientid.Visible = False
        '
        'Downloaded
        '
        Me.Downloaded.DataPropertyName = "Downloaded"
        Me.Downloaded.HeaderText = "Download Mark"
        Me.Downloaded.Name = "Downloaded"
        Me.Downloaded.ReadOnly = True
        Me.Downloaded.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Supplier
        '
        Me.Supplier.DataPropertyName = "Supplier"
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Supplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Place
        '
        Me.Place.DataPropertyName = "Place"
        Me.Place.HeaderText = "Place"
        Me.Place.Name = "Place"
        Me.Place.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Place.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BillNo
        '
        Me.BillNo.DataPropertyName = "BillNo"
        Me.BillNo.HeaderText = "BillNo"
        Me.BillNo.Name = "BillNo"
        Me.BillNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BillNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Billdt
        '
        Me.Billdt.DataPropertyName = "BillDt"
        Me.Billdt.HeaderText = "BillDt"
        Me.Billdt.Name = "Billdt"
        Me.Billdt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Billdt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmBillSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(996, 645)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtnUnmark)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmBillSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "POPS - Bill Search"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents BtnUnmark As System.Windows.Forms.Button
    Public WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rclientid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Wclientid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Downloaded As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Place As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Billdt As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class