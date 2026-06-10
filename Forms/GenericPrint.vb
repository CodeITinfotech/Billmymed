
Public Class GenericPrint

    Private checkPrint As Integer

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = rt.Print(checkPrint, rt.TextLength, e)

        ' Look for more pages
        If checkPrint < rt.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetup.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then

            PrintDocument1.Print()
        End If
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        Dim f As New PrintPreviewDialog
        f = PrintPreviewDialog1

        ' f.MdiParent = Main
        f.Width = Main.Width
        f.Height = Main.Height
        f.PrintPreviewControl.AutoZoom = True
        f.ShowDialog()
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub


    Private Sub TsFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsFont.Click
        If Not rt.SelectionFont Is Nothing Then
            FontDialog1.Font = rt.SelectionFont
        Else
            FontDialog1.Font = Nothing
        End If
        FontDialog1.ShowApply = True
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            rt.SelectionFont = FontDialog1.Font
        End If
    End Sub

    Private Sub TsColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsColor.Click
        ColorDialog1.ShowDialog()
        rt.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub TsLalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsLalign.Click
        rt.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub TsCalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsCalign.Click
        rt.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub TsRalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsRalign.Click
        rt.SelectionAlignment = HorizontalAlignment.Right

    End Sub

    Private Sub TsUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsUndo.Click
        rt.Undo()
    End Sub

    Private Sub TsRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsRedo.Click
        rt.Redo()
    End Sub

    Private Sub TsBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBold.Click
        If rt.SelectionFont.Bold Then
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Xor FontStyle.Bold)
            rt.SelectionFont = fnt
        Else
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Or FontStyle.Bold)
            rt.SelectionFont = fnt
        End If
    End Sub

    Private Sub TsItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsItalic.Click
        If rt.SelectionFont.Bold Then
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Xor FontStyle.Italic)
            rt.SelectionFont = fnt
        Else
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Or FontStyle.Italic)
            rt.SelectionFont = fnt
        End If
    End Sub

    Private Sub TsU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsU.Click
        If rt.SelectionFont.Bold Then
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Xor FontStyle.Underline)
            rt.SelectionFont = fnt
        Else
            Dim fnt As New Font(rt.SelectionFont, rt.SelectionFont.Style Or FontStyle.Underline)
            rt.SelectionFont = fnt
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        rt.SelectionHangingIndent = rt.Width * (TrackBar1.Value / TrackBar1.Maximum) - rt.SelectionIndent
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll

        rt.SelectionIndent = rt.Width * (TrackBar2.Value / TrackBar2.Maximum)
        rt.SelectionHangingIndent = rt.Width * (TrackBar1.Value / TrackBar1.Maximum) - rt.SelectionIndent
    End Sub

    Private Sub rt_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rt.SelectionChanged
        If rt.SelectionIndent = Nothing Then
            TrackBar1.Value = TrackBar1.Minimum
            TrackBar2.Value = TrackBar2.Minimum
        Else
            TrackBar2.Value = rt.SelectionIndent * TrackBar2.Maximum / rt.Width
            TrackBar1.Value = (rt.SelectionHangingIndent / rt.Width) * TrackBar1.Maximum + TrackBar2.Value
        End If
    End Sub

    Private Sub rt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rt.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub TsMail_Click(sender As Object, e As System.EventArgs) Handles TsMail.Click
        EmailDetails.ShowDialog()
        If EmailDetails.DialogResult = Windows.Forms.DialogResult.OK Or EmailDetails.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        'EmailDetails.rdbCust.Checked = True
        'EmailDetails.rdbLoyaltyCust.Checked = False
        'EmailDetails.MdiParent = Me
        'EmailDetails.Width = Me.Width
        'EmailDetails.Height = Me.Height
        'EmailDetails.Show()
    End Sub
End Class