Option Strict Off
Option Explicit On
Friend Class OrderView
    Inherits System.Windows.Forms.Form
    Private Sub comexit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comexit.Click
        If chkdel.Checked = True Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            cmd.CommandText = "delete from pndord where supcode=" & grd.Tag
            cmd.ExecuteReader()

        End If
        Me.Close()
    End Sub

    Private Sub grd_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick

    End Sub

    Private Sub grd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd.KeyDown
        If e.KeyCode = Keys.F10 Then

            If MsgBox("Want to send " & grd.Item(2, grd.CurrentRow.Index).Value & " to Shor titem list ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + vbQuestion) = MsgBoxResult.No Then Exit Sub
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            cmd.CommandText = "insert into shortitem (prdcode) values (""" + grd.Item(2, grd.CurrentRow.Index).Value + """"
            cmd.ExecuteReader()




        End If
    End Sub

    Private Sub SndAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SndAll.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        If MsgBox("Want to send all RED products to Shor titem list ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + vbQuestion) = MsgBoxResult.No Then Exit Sub

        For i = 0 To grd.Rows.Count - 1
            If Val(grd.Item(8, i).Value & "") + Val(grd.Item(9, i).Value & "") = 0 Then
                cmd.CommandText = "insert into shortitem (prdcode) values (""" + grd.Item(2, i).Value + """"
                cmd.ExecuteReader()
            End If
        Next
    End Sub
End Class