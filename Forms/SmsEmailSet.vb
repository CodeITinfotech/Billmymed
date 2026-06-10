Imports System.Windows.Forms

Public Class SmsEmailSet

    Private Sub TxtSId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSId.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TxtSPwrd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSPwrd.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TxtEid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEid.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TxtEPwrd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEPwrd.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub Save()
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = Conn
        Cmd.CommandText = "UPDATE SETTINGS SET SId='" & TxtSId.Text & "',SPwrd='" & TxtSPwrd.Text & "', " & _
                          "EId='" & TxtEid.Text & "',Epwrd='" & TxtEPwrd.Text & "'"
        Cmd.ExecuteNonQuery()
    End Sub



    Private Sub SmsEmailSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection=conn
        Dim dataredr As OleDb.OleDbDataReader
        Cmd.CommandText = "SELECT SID,SPWRD,EID,EPWRD FROM SETTINGS"
        dataredr = Cmd.ExecuteReader
        If dataredr.HasRows Then
            dataredr.Read()
            TxtSId.Text = dataredr("SID") & ""
            TxtSPwrd.Text = dataredr("SPWRD") & ""
            TxtEid.Text = dataredr("EID") & ""
            TxtEPwrd.Text = dataredr("EPWRD") & ""
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Cursor = Cursors.WaitCursor
        Save()
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub
End Class
