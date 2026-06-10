Public Class GetGodownFile

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbcn As New OleDb.OleDbConnection
        Dim dbcmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim tb As New DataTable
        Dim btb As New DataTable
        Dim btb1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        opnfd.FileName = ""
        opnfd.Filter = "|*.mdb"

        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        System.IO.File.Copy(opnfd.FileName, Application.StartupPath & "\ab2.mdb", True)

        dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & opnfd.FileName & ";Jet OLEDB:Database Password=VALOTH;"
        dbcn.Open()
        dbcmd.Connection = dbcn
        cmd1.Connection = Conn
        dbcmd.CommandText = "select sum(stock),code from batch group by code"
        da.SelectCommand = dbcmd
        da.Fill(tb)
        dbcn.Close()

        If Not tb.Rows.Count > 0 Then

            MsgBox("File is empty..", vbInformation)
            Exit Sub
        End If

        For i As Long = 0 To tb.Rows.Count - 1
            cmd1.CommandText = "Update product set gdnqty=" & Val(tb.Rows(i).Item(0) & "") & " where prdcode=""" & tb.Rows(i).Item(1) & """"
            cmd1.ExecuteNonQuery()
        Next
        dbcn.Close()
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub
End Class