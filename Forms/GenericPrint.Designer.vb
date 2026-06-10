<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenericPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericPrint))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rt = New RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.TSRT = New System.Windows.Forms.ToolStrip()
        Me.BtnSetup = New System.Windows.Forms.ToolStripButton()
        Me.BtnPreview = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.TsFont = New System.Windows.Forms.ToolStripButton()
        Me.TsColor = New System.Windows.Forms.ToolStripButton()
        Me.TsMail = New System.Windows.Forms.ToolStripButton()
        Me.TsLalign = New System.Windows.Forms.ToolStripButton()
        Me.TsCalign = New System.Windows.Forms.ToolStripButton()
        Me.TsRalign = New System.Windows.Forms.ToolStripButton()
        Me.TsUndo = New System.Windows.Forms.ToolStripButton()
        Me.TsRedo = New System.Windows.Forms.ToolStripButton()
        Me.TsBold = New System.Windows.Forms.ToolStripButton()
        Me.TsItalic = New System.Windows.Forms.ToolStripButton()
        Me.TsU = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSRT.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rt)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.TSRT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1017, 598)
        Me.Panel2.TabIndex = 66
        '
        'rt
        '
        Me.rt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rt.Location = New System.Drawing.Point(0, 82)
        Me.rt.Name = "rt"
        Me.rt.Size = New System.Drawing.Size(1017, 516)
        Me.rt.TabIndex = 174
        Me.rt.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TrackBar1)
        Me.Panel1.Controls.Add(Me.TrackBar2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1017, 57)
        Me.Panel1.TabIndex = 175
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TrackBar1.LargeChange = 1
        Me.TrackBar1.Location = New System.Drawing.Point(0, 27)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.RightToLeftLayout = True
        Me.TrackBar1.Size = New System.Drawing.Size(1017, 27)
        Me.TrackBar1.TabIndex = 28
        '
        'TrackBar2
        '
        Me.TrackBar2.AutoSize = False
        Me.TrackBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TrackBar2.LargeChange = 1
        Me.TrackBar2.Location = New System.Drawing.Point(0, 0)
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(1017, 27)
        Me.TrackBar2.TabIndex = 29
        '
        'TSRT
        '
        Me.TSRT.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TSRT.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSetup, Me.BtnPreview, Me.btnPrint, Me.TsFont, Me.TsColor, Me.TsMail, Me.TsLalign, Me.TsCalign, Me.TsRalign, Me.TsUndo, Me.TsRedo, Me.TsBold, Me.TsItalic, Me.TsU, Me.ToolStripButton1})
        Me.TSRT.Location = New System.Drawing.Point(0, 0)
        Me.TSRT.Name = "TSRT"
        Me.TSRT.Size = New System.Drawing.Size(1017, 25)
        Me.TSRT.TabIndex = 0
        Me.TSRT.Text = "ToolStrip2"
        '
        'BtnSetup
        '
        Me.BtnSetup.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetup.Image = CType(resources.GetObject("BtnSetup.Image"), System.Drawing.Image)
        Me.BtnSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSetup.Name = "BtnSetup"
        Me.BtnSetup.Size = New System.Drawing.Size(68, 22)
        Me.BtnSetup.Text = "Setup"
        '
        'BtnPreview
        '
        Me.BtnPreview.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreview.Image = CType(resources.GetObject("BtnPreview.Image"), System.Drawing.Image)
        Me.BtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(84, 22)
        Me.BtnPreview.Text = "Preview"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(68, 22)
        Me.btnPrint.Text = "Print"
        '
        'TsFont
        '
        Me.TsFont.Image = CType(resources.GetObject("TsFont.Image"), System.Drawing.Image)
        Me.TsFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsFont.Name = "TsFont"
        Me.TsFont.Size = New System.Drawing.Size(63, 22)
        Me.TsFont.Text = "  Font  "
        Me.TsFont.ToolTipText = "Change Font Type"
        '
        'TsColor
        '
        Me.TsColor.Image = CType(resources.GetObject("TsColor.Image"), System.Drawing.Image)
        Me.TsColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsColor.Name = "TsColor"
        Me.TsColor.Size = New System.Drawing.Size(63, 22)
        Me.TsColor.Text = "Colour"
        Me.TsColor.ToolTipText = "Change Colour"
        '
        'TsMail
        '
        Me.TsMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TsMail.Image = CType(resources.GetObject("TsMail.Image"), System.Drawing.Image)
        Me.TsMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsMail.Name = "TsMail"
        Me.TsMail.Size = New System.Drawing.Size(40, 22)
        Me.TsMail.Text = "eMail"
        Me.TsMail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'TsLalign
        '
        Me.TsLalign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsLalign.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsLalign.Image = CType(resources.GetObject("TsLalign.Image"), System.Drawing.Image)
        Me.TsLalign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsLalign.Name = "TsLalign"
        Me.TsLalign.Size = New System.Drawing.Size(23, 22)
        Me.TsLalign.Text = "ToolStripButton4"
        Me.TsLalign.ToolTipText = "Left Align"
        '
        'TsCalign
        '
        Me.TsCalign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsCalign.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsCalign.Image = CType(resources.GetObject("TsCalign.Image"), System.Drawing.Image)
        Me.TsCalign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsCalign.Name = "TsCalign"
        Me.TsCalign.Size = New System.Drawing.Size(23, 22)
        Me.TsCalign.Text = "ToolStripButton5"
        Me.TsCalign.ToolTipText = "Centre Align"
        '
        'TsRalign
        '
        Me.TsRalign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsRalign.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsRalign.Image = CType(resources.GetObject("TsRalign.Image"), System.Drawing.Image)
        Me.TsRalign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsRalign.Name = "TsRalign"
        Me.TsRalign.Size = New System.Drawing.Size(23, 22)
        Me.TsRalign.Text = "ToolStripButton6"
        Me.TsRalign.ToolTipText = "Right Align"
        '
        'TsUndo
        '
        Me.TsUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsUndo.Image = CType(resources.GetObject("TsUndo.Image"), System.Drawing.Image)
        Me.TsUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsUndo.Name = "TsUndo"
        Me.TsUndo.Size = New System.Drawing.Size(23, 22)
        Me.TsUndo.Text = "ToolStripButton7"
        Me.TsUndo.ToolTipText = "Undo"
        '
        'TsRedo
        '
        Me.TsRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsRedo.Image = CType(resources.GetObject("TsRedo.Image"), System.Drawing.Image)
        Me.TsRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsRedo.Name = "TsRedo"
        Me.TsRedo.Size = New System.Drawing.Size(23, 22)
        Me.TsRedo.Text = "ToolStripButton8"
        Me.TsRedo.ToolTipText = "Redo"
        '
        'TsBold
        '
        Me.TsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBold.Image = CType(resources.GetObject("TsBold.Image"), System.Drawing.Image)
        Me.TsBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBold.Name = "TsBold"
        Me.TsBold.Size = New System.Drawing.Size(23, 22)
        Me.TsBold.Text = "ToolStripButton9"
        Me.TsBold.ToolTipText = "Bold"
        '
        'TsItalic
        '
        Me.TsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsItalic.Image = CType(resources.GetObject("TsItalic.Image"), System.Drawing.Image)
        Me.TsItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsItalic.Name = "TsItalic"
        Me.TsItalic.Size = New System.Drawing.Size(23, 22)
        Me.TsItalic.Text = "ToolStripButton10"
        Me.TsItalic.ToolTipText = "Italic"
        '
        'TsU
        '
        Me.TsU.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsU.Image = CType(resources.GetObject("TsU.Image"), System.Drawing.Image)
        Me.TsU.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsU.Name = "TsU"
        Me.TsU.Size = New System.Drawing.Size(23, 22)
        Me.TsU.Text = "ToolStripButton11"
        Me.TsU.ToolTipText = "Underline"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton1.Text = "Close"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'FontDialog1
        '
        Me.FontDialog1.ShowApply = True
        Me.FontDialog1.ShowColor = True
        '
        'GenericPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Peru
        Me.ClientSize = New System.Drawing.Size(1017, 598)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "GenericPrint"
        Me.Text = "Pharmacology Info"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSRT.ResumeLayout(False)
        Me.TSRT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents TSRT As System.Windows.Forms.ToolStrip
    Friend WithEvents TsFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsLalign As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsCalign As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsRalign As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBold As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsItalic As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsU As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents rt As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsMail As System.Windows.Forms.ToolStripButton
End Class
