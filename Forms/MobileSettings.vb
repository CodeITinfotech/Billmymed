Public Class Mobile_Settings
    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Try

            'Conn.Open()
            If Validation() = True Then
                cmd.Connection = Conn
                cmd.CommandText = "update settings set MobUserName ='" & txtUserName.Text & "',MobPassword='" & txtPass.Text & _
                    "', Transactional='" & chkTransactional.Checked & "',SenderId='" & txtSenderId.Text & "',MobSAIText ='" & txtMobText.Text & _
                    "',SmsSaleInfo = '" & chkSMSSaleInfo.Checked & _
                    "',SmsSaleText = '" & txtSMSSaleText.Text & "',SmsSaleMoNo1 = 91" & Val(txtMob1.Text) & ",SmsSaleMoNo2 = 91" & Val(txtMob2.Text) & _
                    ",SmsSaleMoNo3 = 91" & Val(txtMob3.Text) & ",SmsSaleMoNo4 = 91" & Val(txtMob4.Text) & ",SmsSaleMoNo5 = 91" & Val(txtMob5.Text) & ",SendAfterHrs =" & Val(txtSendAftHrs.Text)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Update successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Conn.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Mobile_Settings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select MobUserName,MobPassword,SenderId,Transactional,MobSAIText,SmsSaleInfo,SmsSaleText" & _
                ",SmsSaleMoNo1, SmsSaleMoNo2, SmsSaleMoNo3, SmsSaleMoNo4, SmsSaleMoNo5,SendAfterHrs from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            If IsDBNull(dt.Rows(0).Item("MobUserName")) = True Then
                txtUserName.Text = ""
            Else
                txtUserName.Text = dt.Rows(0).Item("MobUserName")
            End If
            If IsDBNull(dt.Rows(0).Item("MobPassword")) = True Then
                txtPass.Text = ""
            Else
                txtPass.Text = dt.Rows(0).Item("MobPassword")
            End If
            If IsDBNull(dt.Rows(0).Item("SenderId")) = True Then
                txtSenderId.Text = ""
            Else
                txtSenderId.Text = dt.Rows(0).Item("SenderId")
            End If
            If IsDBNull(dt.Rows(0).Item("MobSAIText")) = True Then
                txtMobText.Text = ""
            Else
                txtMobText.Text = dt.Rows(0).Item("MobSAIText")
            End If

            If IsDBNull(dt.Rows(0).Item("Transactional")) = True Then
                chkTransactional.Checked = False
            Else
                If dt.Rows(0).Item("Transactional") = True Then
                    chkTransactional.Checked = True
                Else
                    chkTransactional.Checked = False
                End If
            End If

            If IsDBNull(dt.Rows(0).Item("SmsSaleText")) = True Then
                txtSMSSaleText.Text = ""
            Else
                txtSMSSaleText.Text = dt.Rows(0).Item("SmsSaleText")
            End If

            If IsDBNull(dt.Rows(0).Item("SendAfterHrs")) = True Then
                txtSendAftHrs.Text = ""
            Else
                txtSendAftHrs.Text = dt.Rows(0).Item("SendAfterHrs")
            End If

            If IsDBNull(dt.Rows(0).Item("SmsSaleInfo")) = True Then
                chkSMSSaleInfo.Checked = False
                txtMob1.Visible = False
                txtMob2.Visible = False
                txtMob3.Visible = False
                txtMob4.Visible = False
                txtMob5.Visible = False
            Else
                If dt.Rows(0).Item("SmsSaleInfo") = True Then
                    chkSMSSaleInfo.Checked = True

                    If IsDBNull(dt.Rows(0).Item("SmsSaleMoNo1")) = True Then
                        txtMob1.Text = ""
                    Else
                        If Len(dt.Rows(0).Item("SmsSaleMoNo1").ToString) = 12 Then
                            If Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo1"), 10) <> 0 Then
                                txtMob1.Text = Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo1"), 10)
                            Else
                                txtMob1.Text = ""
                            End If
                        End If
                    End If

                    If IsDBNull(dt.Rows(0).Item("SmsSaleMoNo2")) = True Then
                        txtMob2.Text = ""
                    Else
                        If Len(dt.Rows(0).Item("SmsSaleMoNo2").ToString) = 12 Then
                            If Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo2"), 10) <> 0 Then
                                txtMob2.Text = Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo2"), 10)
                            Else
                                txtMob2.Text = ""
                            End If
                        End If
                    End If

                    If IsDBNull(dt.Rows(0).Item("SmsSaleMoNo3")) = True Then
                        txtMob3.Text = ""
                    Else
                        If Len(dt.Rows(0).Item("SmsSaleMoNo3").ToString) = 12 Then
                            If Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo3"), 10) <> 0 Then
                                txtMob3.Text = Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo3"), 10)
                            Else
                                txtMob3.Text = ""
                            End If
                        End If
                    End If

                    If IsDBNull(dt.Rows(0).Item("SmsSaleMoNo4")) = True Then
                        txtMob4.Text = ""
                    Else
                        If Len(dt.Rows(0).Item("SmsSaleMoNo4").ToString) = 12 Then
                            If Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo4"), 10) <> 0 Then
                                txtMob4.Text = Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo4"), 10)
                            Else
                                txtMob4.Text = ""
                            End If
                        End If
                    End If

                    If IsDBNull(dt.Rows(0).Item("SmsSaleMoNo5")) = True Then
                        txtMob5.Text = ""
                    Else
                        If Len(dt.Rows(0).Item("SmsSaleMoNo5").ToString) = 12 Then
                            If Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo5"), 10) <> 0 Then
                                txtMob5.Text = Microsoft.VisualBasic.Right(dt.Rows(0).Item("SmsSaleMoNo5"), 10)
                            Else
                                txtMob5.Text = ""
                            End If
                        End If
                    End If

                    txtMob1.Visible = True
                    txtMob2.Visible = True
                    txtMob3.Visible = True
                    txtMob4.Visible = True
                    txtMob5.Visible = True
                Else
                    chkSMSSaleInfo.Checked = False
                    txtMob1.Visible = False
                    txtMob2.Visible = False
                    txtMob3.Visible = False
                    txtMob4.Visible = False
                    txtMob5.Visible = False
                End If
            End If
            'Conn.Close()

            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Me.BackColor
            ToolStrip.Renderer = renderer
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsbClear_Click(sender As System.Object, e As System.EventArgs) Handles tsbClear.Click
        txtPass.Text = ""
        txtUserName.Text = ""
        txtMobText.Text = ""
        txtSenderId.Text = ""
        chkTransactional.Checked = False
        txtMob1.Text = ""
        txtMob2.Text = ""
        txtMob3.Text = ""
        txtMob4.Text = ""
        txtMob5.Text = ""
        chkSMSSaleInfo.Checked = False
        txtSMSSaleText.Text = ""
        txtSendAftHrs.Text = ""
        txtMob1.Text = ""
        txtMob2.Text = ""
        txtMob3.Text = ""
        txtMob4.Text = ""
        txtMob5.Text = ""
    End Sub

    Private Sub tsbCls_Click(sender As System.Object, e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub chkSMSSaleInfo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSMSSaleInfo.CheckedChanged
        If chkSMSSaleInfo.Checked = True Then
            txtMob1.Visible = True
            txtMob2.Visible = True
            txtMob3.Visible = True
            txtMob4.Visible = True
            txtMob5.Visible = True
        Else
            txtMob1.Visible = False
            txtMob2.Visible = False
            txtMob3.Visible = False
            txtMob4.Visible = False
            txtMob5.Visible = False
        End If
    End Sub

    Function Validation() As Boolean
        Validation = True
        If txtMob1.Text <> "" Then
            If Len(txtMob1.Text) <> 10 Then
                MessageBox.Show("Enter Correct Mob No.")
                Validation = False
                Exit Function
            End If
        End If
        If txtMob2.Text <> "" Then
            If Len(txtMob2.Text) <> 10 Then
                MessageBox.Show("Enter Correct Mob No.")
                Validation = False
                Exit Function
            End If
        End If
        If txtMob3.Text <> "" Then
            If Len(txtMob3.Text) <> 10 Then
                MessageBox.Show("Enter Correct Mob No.")
                Validation = False
                Exit Function
            End If
        End If
        If txtMob4.Text <> "" Then
            If Len(txtMob4.Text) <> 10 Then
                MessageBox.Show("Enter Correct Mob No.")
                Validation = False
                Exit Function
            End If
        End If
        If txtMob5.Text <> "" Then
            If Len(txtMob5.Text) <> 10 Then
                MessageBox.Show("Enter Correct Mob No.")
                Validation = False
                Exit Function
            End If
        End If
    End Function
End Class