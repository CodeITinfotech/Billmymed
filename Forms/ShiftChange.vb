Public Class ShiftChange

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim shft As Integer

        cmd.CommandText = "select workshiftcount  from settings"
        cmd.Connection = Conn
        shft = cmd.ExecuteScalar
        For i = 1 To shft
            cbshft.Items.Add(i)
        Next
        cmd.CommandText = "select  workshift from settings"

        shft = cmd.ExecuteScalar
        cbshft.Text = shft
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cbshft.SelectedIndex = cbshft.Items.Count - 1 Then
            cbshft.SelectedIndex = 0
        Else
            cbshft.SelectedIndex = cbshft.SelectedIndex + 1

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.CommandText = "update settings set workshift=" & Val(cbshft.Text)
        cmd.Connection = Conn
        cmd.ExecuteReader()
        WorkShift = Val(cbshft.Text)
        Me.Close()
    End Sub
End Class