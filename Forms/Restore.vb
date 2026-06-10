Imports System.IO

Public Class Restore


    Private Sub restoreDatabase()
        Dim cmd As New OleDb.OleDbCommand
        Dim tconn As New OleDb.OleDbConnection
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Conn.Close()
        tconn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=master;Data Source=" & Sqlsvrname & ""
        tconn.Open()

        opnfd.FileName = ""
        opnfd.Filter = "|*.bak"
        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub


        Dim sql As String
        Dim sql1 As String

        cmd.Connection = tconn
        cmd.CommandTimeout = 0

        Conn = Nothing
        Label2.Text = "Restoring Database from " & Chr(13) & opnfd.FileName & Chr(13) & Chr(13) & "        PLEASE WAIT .."
        Me.Refresh()
        Button1.Enabled = False
        Button2.Enabled = False
        Try


            sql1 = "ALTER DATABASE " & DbName & " SET MULTI_USER WITH NO_WAIT"
            cmd.CommandText = sql

            sql1 = "ALTER DATABASE " & DbName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE"
            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try

        sql = "restore filelistonly from disk =  N'" & opnfd.FileName & "' "
        cmd.CommandText = sql
        da.SelectCommand = cmd
        da.Fill(dt)
        Dim logf, dbf As String
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("type") = "D" Then
                dbf = dt.Rows(i).Item("Logicalname")
            Else
                logf = dt.Rows(i).Item("Logicalname")
            End If

        Next

        Dim di As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\..\DATA")

        sql = "RESTORE DATABASE " & DbName & " FROM  DISK = N'" & opnfd.FileName & "'  WITH  FILE = 1,  MOVE N'" & dbf & "' TO N'" & _
              di.FullName & "\RelyDataPharmaRetail.MDF',MOVE N'" & logf & "' TO N'" & _
              di.FullName & "\RelyDataPharmaRetail.LDF',  NOUNLOAD,  REPLACE,  STATS = 10"
        cmd.CommandText = sql

        cmd.ExecuteNonQuery()


        sql1 = "ALTER DATABASE " & DbName & " SET MULTI_USER WITH NO_WAIT"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        MsgBox("Database Restoration Successful")

        End



    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If UCase(TextBox1.Text) = "RESTORE1" Then
            Me.Cursor = Cursors.WaitCursor


            restoreDatabase()
            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class