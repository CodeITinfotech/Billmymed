Public Class eMailSetting

    Private Sub eMailSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select Host,PortNo,UserName,Password,WithHeader,MailServer,MailSAIText,MailSaleInfo,EmailSaleText" & _
                ",EmailSaleId1, EmailSaleId2, EmailSaleId3, EmailSaleId4, EmailSaleId5 from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            If IsDBNull(dt.Rows(0).Item("Host")) = True Then
                txtHost.Text = ""
            Else
                txtHost.Text = dt.Rows(0).Item("Host")
            End If
            If IsDBNull(dt.Rows(0).Item("PortNo")) = True Then
                txtPortNo.Text = ""
            Else
                txtPortNo.Text = dt.Rows(0).Item("PortNo")
            End If
            If IsDBNull(dt.Rows(0).Item("UserName")) = True Then
                txtUserName.Text = ""
            Else
                txtUserName.Text = dt.Rows(0).Item("UserName")
            End If
            If IsDBNull(dt.Rows(0).Item("Password")) = True Then
                txtPass.Text = ""
            Else
                txtPass.Text = dt.Rows(0).Item("Password")
            End If

            If IsDBNull(dt.Rows(0).Item("WithHeader")) = True Then
                chkWithHeader.Checked = False
            Else
                If dt.Rows(0).Item("WithHeader") = True Then
                    chkWithHeader.Checked = True
                Else
                    chkWithHeader.Checked = False
                End If
            End If

            If IsDBNull(dt.Rows(0).Item("MailServer")) = True Then
                txtEmailServer.Text = ""
            Else
                txtEmailServer.Text = dt.Rows(0).Item("MailServer")
            End If

            If IsDBNull(dt.Rows(0).Item("MailSAIText")) = True Then
                txtEmailText.Text = ""
            Else
                txtEmailText.Text = dt.Rows(0).Item("MailSAIText")
            End If

            If IsDBNull(dt.Rows(0).Item("EmailSaleText")) = True Then
                txtEmailSaleText.Text = ""
            Else
                txtEmailSaleText.Text = dt.Rows(0).Item("EmailSaleText")
            End If

            If IsDBNull(dt.Rows(0).Item("MailSaleInfo")) = True Then
                chkSMSSaleInfo.Checked = False
                txtId1.Visible = False
                txtId2.Visible = False
                txtId3.Visible = False
                txtId4.Visible = False
                txtId5.Visible = False
            Else
                If dt.Rows(0).Item("MailSaleInfo") = True Then
                    chkSMSSaleInfo.Checked = True

                    If IsDBNull(dt.Rows(0).Item("EmailSaleId1")) = True Then
                        txtId1.Text = ""
                    Else
                        txtId1.Text = dt.Rows(0).Item("EmailSaleId1")
                    End If

                    If IsDBNull(dt.Rows(0).Item("EmailSaleId2")) = True Then
                        txtId2.Text = ""
                    Else
                        txtId2.Text = dt.Rows(0).Item("EmailSaleId2")
                    End If

                    If IsDBNull(dt.Rows(0).Item("EmailSaleId3")) = True Then
                        txtId3.Text = ""
                    Else
                        txtId3.Text = dt.Rows(0).Item("EmailSaleId3")
                    End If

                    If IsDBNull(dt.Rows(0).Item("EmailSaleId4")) = True Then
                        txtId4.Text = ""
                    Else
                        txtId4.Text = dt.Rows(0).Item("EmailSaleId4")
                    End If

                    If IsDBNull(dt.Rows(0).Item("EmailSaleId5")) = True Then
                        txtId5.Text = ""
                    Else
                        txtId5.Text = dt.Rows(0).Item("EmailSaleId5")
                    End If

                    txtId1.Visible = True
                    txtId2.Visible = True
                    txtId3.Visible = True
                    txtId4.Visible = True
                    txtId5.Visible = True
                Else
                    chkSMSSaleInfo.Checked = False
                    txtId1.Visible = False
                    txtId2.Visible = False
                    txtId3.Visible = False
                    txtId4.Visible = False
                    txtId5.Visible = False
                End If
            End If
            'Conn.Close()

            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Me.BackColor
            ToolStrip.Renderer = renderer
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Try
            'Conn.Open()
            cmd.Connection = Conn
            cmd.CommandText = "update settings set Host ='" & txtHost.Text & "',PortNo =" & Val(txtPortNo.Text) & _
                            ",UserName ='" & txtUserName.Text & "',Password='" & txtPass.Text & "', WithHeader='" & chkWithHeader.Checked & "',MailServer='" & _
                            txtEmailServer.Text & "',MailSAIText = '" & txtEmailText.Text & "',MailSaleInfo = '" & chkSMSSaleInfo.Checked & _
                            "',EmailSaleText = '" & txtEmailSaleText.Text & "',EmailSaleId1 = '" & txtId1.Text & "',EmailSaleId2 = '" & txtId2.Text & _
                            "',EmailSaleId3 = '" & txtId3.Text & "',EmailSaleId4 = '" & txtId4.Text & "',EmailSaleId5 = '" & txtId5.Text & "'"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbCls_Click(sender As System.Object, e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(sender As System.Object, e As System.EventArgs) Handles tsbClear.Click
        txtHost.Text = ""
        txtPass.Text = ""
        txtPortNo.Text = ""
        txtUserName.Text = ""
        txtEmailServer.Text = ""
        txtEmailText.Text = ""
        chkWithHeader.Checked = False
        chkSMSSaleInfo.Checked = False
        txtEmailSaleText.Text = ""
        txtId1.Text = ""
        txtId2.Text = ""
        txtId3.Text = ""
        txtId4.Text = ""
        txtId5.Text = ""
    End Sub

    Private Sub chkSMSSaleInfo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSMSSaleInfo.CheckedChanged
        If chkSMSSaleInfo.Checked = True Then
            txtId1.Visible = True
            txtId2.Visible = True
            txtId3.Visible = True
            txtId4.Visible = True
            txtId5.Visible = True
        Else
            txtId1.Visible = False
            txtId2.Visible = False
            txtId3.Visible = False
            txtId4.Visible = False
            txtId5.Visible = False
        End If
    End Sub
End Class