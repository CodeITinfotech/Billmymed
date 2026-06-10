Public Class Settings

    Private Sub InvMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            cmd.Connection = Conn

            cmd.CommandText = "Select * from Settings"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                txtInvMsg.Text = dr("InvMsg") & ""

                txtRndPs.Text = Val(dr("Rndpaise") & "")
                ChkPrePrint.Checked = dr("InvPrePrint")
                txtShrtExpDys.Text = Val(dr("ShtExpWar") & "")
                ChkExpbill.Checked = dr("ExpWiseBill")
                txtdoc.Text = dr("DefaultDoc") & ""
                txtpat.Text = dr("Defaultpat") & ""
                ChkBarcode.Checked = dr("usebarcode")
            End If
            dr.Close()

            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Me.BackColor
            ToolStrip.Renderer = renderer
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub



    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            Me.Cursor = Cursors.WaitCursor
            cmd.CommandText = "Update Settings set InvMsg='" & txtInvMsg.Text & "', " & _
                "Rndpaise=" & Val(txtRndPs.Text) & ",InvPrePrint=" & IIf(ChkPrePrint.Checked, 1, 0) & "," & _
                "ShtExpWar=" & Val(txtShrtExpDys.Text) & ",DefaultDoc=""" & txtdoc.Text & """," & _
                "Defaultpat=""" & txtpat.Text & """,ExpWiseBill=" & IIf(ChkExpbill.Checked, 1, 0) & ",usebarcode=" & IIf(ChkBarcode.Checked, 1, 0)
            cmd.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub
End Class