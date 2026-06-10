Public Class SerialReNumber

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        Try
            dgDisplay.Rows.Clear()
            txtEdit.Text = ""
            txtEdit.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShow.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim r As Integer

            cmd.Connection = Conn
            cmd.CommandText = "Select Type,SlNo,Descr,Prefix,Sufix,Descr1 from SerialNum where ISNULL(0,accopt)=0  "
            dr = cmd.ExecuteReader

            dgDisplay.Rows.Clear()

            If dr.HasRows Then
                While dr.Read
                    dgDisplay.Rows.Add()
                    dgDisplay.Item(0, r).Value = dr("Type")
                    dgDisplay.Item(1, r).Value = dr("Descr1") & " " & dr("Descr")
                    'If dr("SlNo") = 0 Then
                    'dgDisplay.Item(2, r).Value = 1
                    'Else
                    dgDisplay.Item(2, r).Value = dr("SlNo") + 1

                    'End If
                    dgDisplay.Item(3, r).Value = dr("Prefix")
                    dgDisplay.Item(4, r).Value = dr("Sufix")
                    r = r + 1
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim SlNo As Integer

        cmd.Connection = Conn

        Try
            For i = 0 To dgDisplay.Rows.Count - 1
                If Val(dgDisplay.Item(2, i).Value) <= 0 Then
                    SlNo = 0
                Else
                    SlNo = Val(dgDisplay.Item(2, i).Value) - 1
                End If

                cmd.CommandText = "Update SerialNum set SlNo=" & SlNo & "," & _
                    " Prefix='" & dgDisplay.Item(3, i).Value & "'," & _
                    " Sufix='" & dgDisplay.Item(4, i).Value & "' where Type = " & Val(dgDisplay.Item(0, i).Value)
                cmd.ExecuteNonQuery()

            Next

            dgDisplay.Rows.Clear()
            txtEdit.Text = ""
            txtEdit.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case dgDisplay.CurrentCell.ColumnIndex
                Case 2
                    dgDisplay.Item(2, dgDisplay.CurrentCell.RowIndex).Value = txtEdit.Text
                    dgDisplay.FirstDisplayedScrollingColumnIndex = 2
                    dgDisplay.Focus()
                    ShowEditControl(txtEdit)
            End Select
        End If
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        Try
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            If Asc(e.KeyChar) = 27 Then
                txtEdit.Text = ""
                txtEdit.Visible = False
                dgDisplay.Focus()
            End If

            If Asc(e.KeyChar) = 13 Then
                Select Case dgDisplay.CurrentCell.ColumnIndex
                    Case 2
                        dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index).Value = Val(txtEdit.Text)
                        txtEdit.Visible = False
                        dgDisplay.Focus()
                        dgDisplay.CurrentCell = dgDisplay.Item(3, dgDisplay.CurrentRow.Index)
                        ShowEditControl(txtEdit)

                    Case 3
                        dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index).Value = txtEdit.Text
                        txtEdit.Visible = False
                        dgDisplay.Focus()
                        dgDisplay.CurrentCell = dgDisplay.Item(4, dgDisplay.CurrentRow.Index)
                        ShowEditControl(txtEdit)

                    Case 4
                        dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index).Value = txtEdit.Text
                        dgDisplay.Focus()
                        ShowEditControl(txtEdit)
                        txtEdit.Visible = False
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.LostFocus
        txtEdit.Visible = False
        dgDisplay.Focus()
    End Sub

    Private Sub txtEdit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged
        Try
            'If dgDisplay.CurrentRow.Cells(2).Selected = True Then
            '    dgDisplay.CurrentRow.Cells(2).Selected = txtEdit.Text

            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Try
            Dim WD As Integer
            WD = 0
            cntrol.location = dgDisplay.Location
            cntrol.top = dgDisplay.Top + dgDisplay.GetRowDisplayRectangle(dgDisplay.CurrentCell.RowIndex, True).Top
            cntrol.left = dgDisplay.Left + dgDisplay.GetColumnDisplayRectangle(dgDisplay.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgDisplay.GetColumnDisplayRectangle(dgDisplay.CurrentCell.ColumnIndex, True).Width
            cntrol.text = dgDisplay.CurrentCell.Value & ""
            cntrol.visible = True
            cntrol.enabled = True
            cntrol.focus()
            'cntrol.enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgDisplay_DoubleClick() Handles dgDisplay.DoubleClick
        EditGrid()
    End Sub

    Public Sub EditGrid()
        Try

            Dim EDROW As Integer = dgDisplay.CurrentCell.RowIndex
            Dim EDCOL As Integer = dgDisplay.CurrentCell.ColumnIndex

            If dgDisplay.CurrentCell.ColumnIndex = 2 Then
                dgDisplay.Columns(2).Selected = True
                dgDisplay.CurrentCell = dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index)
                ShowEditControl(txtEdit)
                txtEdit.Enabled = True
                Exit Sub
            ElseIf dgDisplay.CurrentCell.ColumnIndex = 3 Then
                dgDisplay.Columns(3).Selected = True
                dgDisplay.CurrentCell = dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index)
                ShowEditControl(txtEdit)
                txtEdit.Enabled = True
                Exit Sub
            ElseIf dgDisplay.CurrentCell.ColumnIndex = 4 Then
                dgDisplay.Columns(4).Selected = True
                dgDisplay.CurrentCell = dgDisplay.Item(dgDisplay.CurrentCell.ColumnIndex, dgDisplay.CurrentRow.Index)
                ShowEditControl(txtEdit)
                txtEdit.Enabled = True
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgDisplay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDisplay.KeyDown
        Try

            If e.KeyCode = Keys.Escape Then
                txtEdit.Visible = False
                dgDisplay.Focus()
                e.Handled = True
            End If

            If e.KeyCode = Keys.Enter Then
                dgDisplay_DoubleClick()
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReset.Click
        Dim i As Integer
        Try
            For i = 0 To dgDisplay.Rows.Count - 1
                dgDisplay.Item(2, i).Value = 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Me.BackColor
            ToolStrip.Renderer = renderer
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class