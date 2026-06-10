Public Class UserRights
    Dim menues As New List(Of ToolStripItem)
    Dim ReportList As New List(Of String)

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub UserLocked_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub

    Private Sub clearform()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet
            cmd.Connection = Conn

            cmd.CommandText = "Select UserID from UserMaster where flg='" & PRGID & "'  order by UserID"
            da.SelectCommand = cmd

            da.Fill(ds, "UserMaster")
            cmbUserID.DisplayMember = "UserID"
            cmbUserID.DataSource = ds.Tables("UserMaster")

            cmbUserID.Text = ""
            cmbUserID.SelectedItem = Nothing
            dgRights.Rows.Clear()
            cmbUserID.Focus()
            menues.Clear()
            For Each t As ToolStripItem In Main.MenuStrip1.Items
                GetMenues(t, menues)
            Next

            ReportList.Clear()
            For I = 0 To Reports.tv.Nodes.Count - 1
                For v = 0 To Reports.tv.Nodes(I).Nodes.Count - 1
                    For x = 0 To Reports.tv.Nodes(I).Nodes(v).Nodes.Count - 1
                        ReportList.Add(Reports.tv.Nodes(I).Nodes(v).Nodes(x).Text)
                    Next
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClr.Click
        clearform()
    End Sub

    Private Sub cmbUserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUserID.TextChanged
        Try
            If cmbUserID.Text <> "" Then
                Dim cmd As New OleDb.OleDbCommand
                Dim cmd1 As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader
                Dim dr1 As OleDb.OleDbDataReader
                Dim i As Integer

                i = 0
                cmd.Connection = Conn
                cmd1.Connection = Conn

                cmd.CommandText = "Select * from usermaster where  upper(userid)=""" & UCase(cmbUserID.Text) & """ and  flg='" & PRGID & "' "
                dr = cmd.ExecuteReader
                dr.Read()
                Txtsales.Text = Val(dr("saeditDay") & "")
                TxtPur.Text = Val(dr("pueditday") & "")
                TxtSrtn.Text = Val(dr("sreditday") & "")
                TxtPurRtn.Text = Val(dr("preditday") & "")
                TxtOrd.Text = Val(dr("ordeditday") & "")
                TxtPuAddLmt.Text = Val(dr("puaddlmt") & "")
                TxtPuLessLmt.Text = Val(dr("pulesslmt") & "")
                txtsaadd.Text = Val(dr("saaddlmt") & "")
                txtsaless.Text = Val(dr("salesslmt") & "")
                txtDiscLmt.Text = Val(dr("saDisclmt") & "")
                txtdiscfor.Text = Val(dr("saamtforDisc") & "")

                txtDiscLmt2.Text = Val(dr("saDisclmt2") & "")
                txtdiscfor2.Text = Val(dr("saamtforDisc2") & "")

                dr.Close()

                cmd.CommandText = "Select Rights from userRights where flg='" & PRGID & "' "
                dr = cmd.ExecuteReader

                dgRights.Rows.Clear()

                If dr.HasRows Then
                    While dr.Read
                        cmd1.CommandText = "Select Blockd from userLocked where flg='" & PRGID & "' and upper(UserID)='" & UCase(cmbUserID.Text) & "'" & _
                            " and Rights='" & dr("Rights") & "'"
                        dr1 = cmd1.ExecuteReader
                        dgRights.Rows.Add()
                        dgRights.Item(0, i).Value = dr("Rights")
                        If dr1.HasRows Then
                            dr1.Read()
                            dgRights.Item(1, i).Value = dr1("Blockd")
                        End If
                        i = i + 1
                        dr1.Close()
                    End While
                    dr.Close()
                    dgRights.Focus()
                End If

                dgRights.Rows.Add()
                dgRights.Item(0, dgRights.RowCount - 1).Value = "---- Menues ---- "
                dgRights.Item(1, dgRights.RowCount - 1).Value = " ----- "
                dgRights.Rows(dgRights.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray

                For i = 0 To menues.Count - 1
                    If menues(i).Tag <> "NO" Then
                        If menues(i).Text = "" Then
                            dgRights.Rows.Add()
                            dgRights.Item(0, dgRights.RowCount - 1).Value = (menues(i).Name)
                        Else
                            dgRights.Rows.Add()

                            dgRights.Item(0, dgRights.RowCount - 1).Value = (menues(i).Text)
                        End If

                        cmd1.CommandText = "Select Blockd from userLocked where flg='" & PRGID & "' and UserID='" & cmbUserID.Text & "'" & _
                               " and Rights='" & dgRights.Item(0, dgRights.RowCount - 1).Value & "'"
                        dr1 = cmd1.ExecuteReader
                        If dr1.HasRows Then
                            dr1.Read()
                            dgRights.Item(1, dgRights.RowCount - 1).Value = dr1("Blockd")
                        End If
                        dr1.Close()
                    End If
                Next

                dgRights.Rows.Add()
                dgRights.Item(0, dgRights.RowCount - 1).Value = "---- Reports ---- "
                dgRights.Item(1, dgRights.RowCount - 1).Value = " ----- "
                dgRights.Rows(dgRights.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray

                For i = 0 To Reports.tv.Nodes.Count - 1
                    For v = 0 To Reports.tv.Nodes(i).Nodes.Count - 1
                        For x = 0 To Reports.tv.Nodes(i).Nodes(v).Nodes.Count - 1

                            dgRights.Rows.Add()

                            dgRights.Item(0, dgRights.RowCount - 1).Value = (Reports.tv.Nodes(i).Nodes(v).Nodes(x).Text)


                            cmd1.CommandText = "Select Blockd from userLocked where flg='" & PRGID & "' and UserID='" & cmbUserID.Text & "'" & _
                                   " and Rights='" & dgRights.Item(0, dgRights.RowCount - 1).Value & "'"
                            dr1 = cmd1.ExecuteReader
                            If dr1.HasRows Then
                                dr1.Read()
                                dgRights.Item(1, dgRights.RowCount - 1).Value = dr1("Blockd")
                            End If
                            dr1.Close()
                        Next
                    Next
                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EditGrid()
        Try
            If dgRights.CurrentRow.Cells(1).Selected = True Then
                dgRights.Columns(1).Selected = True
                If dgRights.CurrentRow.Cells(0).Value <> "" Then
                    If dgRights.CurrentRow.Cells(1).Value = "" Then
                        dgRights.CurrentRow.Cells(1).Value = "Yes"
                    ElseIf dgRights.CurrentRow.Cells(1).Value = "Yes" Then
                        dgRights.CurrentRow.Cells(1).Value = "No"
                    ElseIf dgRights.CurrentRow.Cells(1).Value = "No" Then
                        dgRights.CurrentRow.Cells(1).Value = "Yes"
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgRights_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgRights.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                dgRights.Focus()
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim i As Integer
            cmd.Connection = Conn

            If cmbUserID.Text = "" Then
                MsgBox("User ID can't be blank.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                cmbUserID.Focus()
                Exit Sub
            End If

            cmd.CommandText = "Delete UserLocked where flg='" & PRGID & "' and UserId='" & cmbUserID.Text & "'"
            cmd.ExecuteNonQuery()

            For i = 0 To dgRights.Rows.Count - 1
                If dgRights.Item(1, i).Value = "Yes" Then
                    cmd.CommandText = "Insert into UserLocked(UserID,Rights,Blockd,flg) values('" & cmbUserID.Text & "'," & _
                    "'" & dgRights.Item(0, i).Value & "','" & dgRights.Item(1, i).Value & "','" & PRGID & "')"
                    cmd.ExecuteNonQuery()
                End If
            Next

            cmd.CommandText = "update usermaster set puaddlmt=" & Val(TxtPuAddLmt.Text) & ",pulesslmt=" & Val(TxtPuLessLmt.Text) & _
                ",Salesslmt=" & Val(txtsaless.Text) & ",SaAddlmt=" & Val(txtsaadd.Text) & _
                 ",SaAmtForDisc=" & Val(txtdiscfor.Text) & ", sadisclmt=" & Val(txtDiscLmt.Text) & _
                 ",SaAmtForDisc2=" & Val(txtdiscfor2.Text) & ", sadisclmt2=" & Val(txtDiscLmt2.Text) & _
                ",saeditday=" & Val(Txtsales.Text) & ",pueditday=" & Val(TxtPur.Text) & _
                    ",sreditday=" & Val(TxtSrtn.Text) & ",preditday=" & Val(TxtPurRtn.Text) & ",ordeditday=" & Val(TxtOrd.Text) & _
                    " where flg='" & PRGID & "' and UserId='" & cmbUserID.Text & "'"
            cmd.ExecuteNonQuery()

            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            If MsgBox("Want to Delete?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                cmd.CommandText = "Delete UserLocked where flg='" & PRGID & "' and UserID='" & cmbUserID.Text & "'"
                cmd.ExecuteNonQuery()
                clearform()
            End If
            cmbUserID.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgRights_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgRights.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            EditGrid()
        End If
    End Sub

    Private Sub cmbUserID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserID.SelectedIndexChanged

    End Sub

    Private Sub TxtPur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPur.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
End Class