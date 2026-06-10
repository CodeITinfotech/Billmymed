<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductGrouping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductGrouping))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbCls = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEdit = New System.Windows.Forms.TextBox()
        Me.cbEdit = New System.Windows.Forms.ComboBox()
        Me.lblSelectby = New System.Windows.Forms.Label()
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.chkChangForAll = New System.Windows.Forms.CheckBox()
        Me.lstgrp = New System.Windows.Forms.CheckedListBox()
        Me.ChkProdall = New System.Windows.Forms.CheckBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.DgProdSer = New System.Windows.Forms.DataGridView()
        Me.ToolStrip.SuspendLayout()
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbCls, Me.tsbClear, Me.ToolStripLabel1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1088, 33)
        Me.ToolStrip.TabIndex = 62
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.AutoSize = False
        Me.tsbSave.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbSave.ForeColor = System.Drawing.Color.Black
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(80, 30)
        Me.tsbSave.Text = "&Save"
        '
        'tsbCls
        '
        Me.tsbCls.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbCls.AutoSize = False
        Me.tsbCls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsbCls.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbCls.ForeColor = System.Drawing.Color.Black
        Me.tsbCls.Image = CType(resources.GetObject("tsbCls.Image"), System.Drawing.Image)
        Me.tsbCls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCls.Name = "tsbCls"
        Me.tsbCls.Size = New System.Drawing.Size(80, 30)
        Me.tsbCls.Text = "E&xit"
        '
        'tsbClear
        '
        Me.tsbClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbClear.AutoSize = False
        Me.tsbClear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbClear.ForeColor = System.Drawing.Color.Black
        Me.tsbClear.Image = CType(resources.GetObject("tsbClear.Image"), System.Drawing.Image)
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(80, 30)
        Me.tsbClear.Text = "&Clear"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(750, 30)
        Me.ToolStripLabel1.Text = "Product Grouping"
        Me.ToolStripLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Details :"
        '
        'txtEdit
        '
        Me.txtEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdit.ForeColor = System.Drawing.Color.White
        Me.txtEdit.Location = New System.Drawing.Point(146, 352)
        Me.txtEdit.MaxLength = 50
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEdit.Size = New System.Drawing.Size(87, 22)
        Me.txtEdit.TabIndex = 170
        Me.txtEdit.Tag = "PrdName"
        Me.txtEdit.Visible = False
        '
        'cbEdit
        '
        Me.cbEdit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbEdit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbEdit.DropDownWidth = 3
        Me.cbEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEdit.ForeColor = System.Drawing.Color.White
        Me.cbEdit.FormattingEnabled = True
        Me.cbEdit.Location = New System.Drawing.Point(274, 352)
        Me.cbEdit.Name = "cbEdit"
        Me.cbEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbEdit.Size = New System.Drawing.Size(121, 23)
        Me.cbEdit.TabIndex = 168
        Me.cbEdit.Visible = False
        '
        'lblSelectby
        '
        Me.lblSelectby.AutoSize = True
        Me.lblSelectby.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectby.ForeColor = System.Drawing.Color.Black
        Me.lblSelectby.Location = New System.Drawing.Point(24, 55)
        Me.lblSelectby.Name = "lblSelectby"
        Me.lblSelectby.Size = New System.Drawing.Size(96, 16)
        Me.lblSelectby.TabIndex = 166
        Me.lblSelectby.Text = "Select By :"
        '
        'cbGroup
        '
        Me.cbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbGroup.BackColor = System.Drawing.Color.White
        Me.cbGroup.DisplayMember = "Name"
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbGroup.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGroup.ForeColor = System.Drawing.Color.Black
        Me.cbGroup.ItemHeight = 16
        Me.cbGroup.Location = New System.Drawing.Point(126, 52)
        Me.cbGroup.MaxDropDownItems = 15
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(211, 24)
        Me.cbGroup.TabIndex = 165
        Me.cbGroup.Tag = ""
        Me.cbGroup.ValueMember = "Code"
        '
        'chkChangForAll
        '
        Me.chkChangForAll.AutoSize = True
        Me.chkChangForAll.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkChangForAll.Location = New System.Drawing.Point(914, 235)
        Me.chkChangForAll.Name = "chkChangForAll"
        Me.chkChangForAll.Size = New System.Drawing.Size(147, 20)
        Me.chkChangForAll.TabIndex = 172
        Me.chkChangForAll.Text = "Update All Rows"
        Me.chkChangForAll.UseVisualStyleBackColor = True
        '
        'lstgrp
        '
        Me.lstgrp.ColumnWidth = 400
        Me.lstgrp.FormattingEnabled = True
        Me.lstgrp.Location = New System.Drawing.Point(27, 98)
        Me.lstgrp.MultiColumn = True
        Me.lstgrp.Name = "lstgrp"
        Me.lstgrp.Size = New System.Drawing.Size(1041, 109)
        Me.lstgrp.Sorted = True
        Me.lstgrp.TabIndex = 173
        '
        'ChkProdall
        '
        Me.ChkProdall.AutoSize = True
        Me.ChkProdall.Checked = True
        Me.ChkProdall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkProdall.Location = New System.Drawing.Point(27, 79)
        Me.ChkProdall.Name = "ChkProdall"
        Me.ChkProdall.Size = New System.Drawing.Size(77, 17)
        Me.ChkProdall.TabIndex = 174
        Me.ChkProdall.Text = "All Product"
        Me.ChkProdall.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.Color.Transparent
        Me.BtnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnOK.FlatAppearance.BorderSize = 0
        Me.BtnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Olive
        Me.BtnOK.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.ForeColor = System.Drawing.Color.Black
        Me.BtnOK.Location = New System.Drawing.Point(447, 213)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(78, 29)
        Me.BtnOK.TabIndex = 175
        Me.BtnOK.Text = "Search"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'DgProdSer
        '
        Me.DgProdSer.AllowUserToAddRows = False
        Me.DgProdSer.AllowUserToDeleteRows = False
        Me.DgProdSer.AllowUserToResizeRows = False
        Me.DgProdSer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgProdSer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgProdSer.Location = New System.Drawing.Point(18, 261)
        Me.DgProdSer.Name = "DgProdSer"
        Me.DgProdSer.Size = New System.Drawing.Size(1043, 303)
        Me.DgProdSer.TabIndex = 177
        '
        'ProductGrouping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(1088, 654)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.lstgrp)
        Me.Controls.Add(Me.ChkProdall)
        Me.Controls.Add(Me.chkChangForAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEdit)
        Me.Controls.Add(Me.cbEdit)
        Me.Controls.Add(Me.lblSelectby)
        Me.Controls.Add(Me.cbGroup)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.DgProdSer)
        Me.Name = "ProductGrouping"
        Me.Text = "ProductGrouping"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.DgProdSer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCls As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEdit As System.Windows.Forms.TextBox
    Friend WithEvents cbEdit As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelectby As System.Windows.Forms.Label
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents chkChangForAll As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lstgrp As System.Windows.Forms.CheckedListBox
    Friend WithEvents ChkProdall As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents DgProdSer As System.Windows.Forms.DataGridView
End Class
