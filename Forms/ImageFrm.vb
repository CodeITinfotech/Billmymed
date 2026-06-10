Public Class ImageFrm

     

     



    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim siza As System.Drawing.Size
        Dim Rctb As System.Drawing.Rectangle
        Dim factorW As Single
        Dim factorH As Single
        Dim factor As Single
        factorW = PrintDialog1.PrinterSettings.DefaultPageSettings.PrintableArea.Width / pb.Size.Width
        factorH = PrintDialog1.PrinterSettings.DefaultPageSettings.PrintableArea.Height / pb.Size.Height
        If factorH < factorW Then
            factor = factorH
        Else
            factor = factorW
        End If
        siza.Height = pb.Size.Height * factor
        siza.Width = pb.Size.Width * factor

        e.Graphics.DrawImage(pb.Image, 0, 0, siza.Width, siza.Height)
 
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        opfile.ShowDialog()
        If opfile.FileName = "" Then
            Exit Sub
        Else

            pb.Image = Image.FromFile(opfile.FileName)

            HScrollBar1.Maximum = pb.Image.Width - pb.Width + HScrollBar1.Height
            VScrollBar1.Maximum = pb.Image.Height - pb.Height + VScrollBar1.Width

            VScrollBar1.Visible = True
            HScrollBar1.Visible = True

            If pb.Height > pb.Image.Height Then
                VScrollBar1.Visible = False
            End If

            If pb.Width > pb.Image.Width Then
                HScrollBar1.Visible = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim ret As Windows.Forms.DialogResult
        ret = PrintDialog1.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub


    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim gphPictureBox As Graphics = pb.CreateGraphics()
        gphPictureBox.DrawImage(pb.Image, New Rectangle(0, 0, _
            pb.Width - HScrollBar1.Height, _
            pb.Height - VScrollBar1.Width), _
            New Rectangle(HScrollBar1.Value, VScrollBar1.Value, _
            pb.Width - HScrollBar1.Height, _
            pb.Height - VScrollBar1.Width), GraphicsUnit.Pixel)
    End Sub

    Private Sub VScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll
        Dim gphPictureBox As Graphics = pb.CreateGraphics()
        gphPictureBox.DrawImage(pb.Image, New Rectangle(0, 0, _
            pb.Width - HScrollBar1.Height, _
            pb.Height - VScrollBar1.Width), _
            New Rectangle(HScrollBar1.Value, VScrollBar1.Value, _
            pb.Width - HScrollBar1.Height, _
            pb.Height - VScrollBar1.Width), GraphicsUnit.Pixel)
    End Sub
End Class