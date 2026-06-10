Public Class UserMaster
    Dim obj As Object
    Dim UsrID As String

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub UserMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Private Sub clearform()
        Try
            txtUid.Text = "" : txtUNm.Text = "" : ChkCom.Checked = False
            dgUser.Visible = False
            txtUNm.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            cmd.Connection = Conn
            cmd1.Connection = Conn
            cmd2.Connection = Conn

            If txtUNm.Text = "" Then
                MsgBox("User Name can't be blank.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If txtUid.Text = "" Then
                MsgBox("User ID can't be blank.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If UsrID <> "" Then
                cmd2.CommandText = "Delete UserMaster where flg='" & PRGID & "' and  UserID='" & txtUid.Text & "'"
                cmd2.ExecuteNonQuery()

                cmd.CommandText = "Insert into UserMaster(UserID, UserName,flg,com)  values('" & txtUid.Text & "','" & txtUNm.Text & "','" & PRGID & "'," & IIf(ChkCom.Checked, 1, 0) & ")"
                cmd.ExecuteNonQuery()
            Else
                cmd1.CommandText = "Select UserName from UserMaster where flg='" & PRGID & "' and UserID='" & txtUid.Text & "'"
                dr = cmd1.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    MsgBox("User ID already existing for the User Name " & dr("UserName"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    txtUid.Focus()
                    dr.Close()
                    Exit Sub
                End If

                cmd.CommandText = "Insert into UserMaster(UserID, UserName,flg,com) values('" & txtUid.Text & "','" & txtUNm.Text & "','" & PRGID & "'," & IIf(ChkCom.Checked, 1, 0) & ")"
                cmd.ExecuteNonQuery()
            End If

            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClr.Click
        clearform()
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            If MsgBox("Want to Delete the User Entry?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                cmd.CommandText = "Delete UserMaster where flg='" & PRGID & "' and UserID='" & txtUid.Text & "'"
                cmd.ExecuteNonQuery()
                clearform()
            End If
            txtUNm.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtUNm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUNm.TextChanged
        Try
            obj = txtUNm
            PopulateUser()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PopulateUser()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            If obj.text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select UserID,UserName as [User Name],com as [Computer] from UserMaster where flg='" & PRGID & "' and upper(UserName) like """ & UCase(obj.text) & """ + '%'"
                da.SelectCommand = cmd
                da.Fill(ds, "UserMaster")
                dgUser.DataSource = ds.Tables("UserMaster")

                dgUser.Columns(0).Visible = False
                dgUser.Columns(1).Width = 300

                If (dgUser.Rows.Count >= 1) Then
                    dgUser.Visible = True
                    dgUser.Focus()
                    Exit Sub
                Else
                    dgUser.Visible = False
                    obj.focus()
                    txtUNm.SelectionStart = Len(txtUNm.Text)
                End If

                dgUser.Visible = False
                obj.focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgUser_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUser.CellContentClick

    End Sub

    Private Sub dgUser_DoubleClick() Handles dgUser.DoubleClick
        Try
            UsrID = ""
            UsrID = dgUser.CurrentRow.Cells(0).Value
            txtUid.Text = dgUser.CurrentRow.Cells(0).Value
            txtUNm.Text = dgUser.CurrentRow.Cells(1).Value
            If dgUser.CurrentRow.Cells(2).Value = True Then
                ChkCom.Checked = True
            Else
                ChkCom.Checked = False
            End If
            dgUser.Visible = False
            txtUNm.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgUser.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                dgUser.Visible = False : obj.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.text <> "" Then
                obj.text = Microsoft.VisualBasic.Left(Trim(obj.text), Len(obj.text) - 1)
                If obj.text = "" Then dgUser.Visible = False : obj.text = "" : obj.focus()
            Else
                obj.text = obj.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgUser_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgUser.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgUser_DoubleClick()
        End If
    End Sub
End Class