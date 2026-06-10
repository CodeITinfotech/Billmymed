Public Class ChangePassword

    Private Sub ChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblid.Text = UsrName
        lblusrfull.Text = UsrNameFull
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandText = "Select *  from UserMaster WHERE flg='" & PRGID & "' and upper(USERID)=""" & UCase(lblid.Text) & """"
        Dim dataredr1 As OleDb.OleDbDataReader = cmd.ExecuteReader()
        If dataredr1.HasRows Then
            dataredr1.Read()
            If UCase(dataredr1("PASWRD") & "") & "" <> UCase(txtoldpass.Text) Then
                MsgBox("Invalid User/Password", vbInformation)
                dataredr1.Close()
                Exit Sub
            End If

            If txtpass1.Text <> txtpass2.Text Then
                MsgBox("New Password and confirm password is not matching ", vbInformation)
                dataredr1.Close()
                Exit Sub

            End If
            dataredr1.Close()
            cmd.CommandText = "update UserMaster set paswrd=""" & txtpass1.Text & """ where flg='" & PRGID & "' and upper(USERID)=""" & UCase(lblid.Text) & """"

            cmd.ExecuteNonQuery()
            Me.Close()
        Else
            dataredr1.Close()
            MsgBox("Invalid User Id", vbInformation)
            Exit Sub
        End If
       
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass2.TextChanged

    End Sub
End Class