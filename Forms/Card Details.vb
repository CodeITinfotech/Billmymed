Imports System.Text.RegularExpressions

Public Class CardDetails
    Dim obj As Object
    Dim flag As Integer
    Dim Adding As Boolean
    Dim Selected As Boolean

    Private Sub dgdep_DoubleClick() Handles dgdep.DoubleClick
        Try
            'If dgdep.CurrentCell.ColumnIndex = 1 Or dgdep.CurrentCell.ColumnIndex = 3 Then
            '    grid()

            'End If

            'If dgdep.CurrentCell.ColumnIndex = 4 Then
            '    depcombo.Visible = True
            '    depcombo.Location = dgdep.Location
            '    depcombo.Top = dgdep.Top
            '    depcombo.Left = dgdep.Left
            '    depcombo.Top = dgdep.Top + dgdep.GetRowDisplayRectangle(dgdep.CurrentCell.RowIndex, True).Top
            '    depcombo.Left = dgdep.Left + dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Left
            '    depcombo.Width = dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Width
            '    depcombo.Text = dgdep.CurrentCell.Value & ""
            '    depcombo.Visible = False
            '    depcombo.Focus()
            '    'depcombo1()
            'End If

            'If dgdep.CurrentCell.ColumnIndex = 2 Then
            '    cmbsex1()
            'End If

            EditGrid()

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub EditGrid()
        Try

            If dgdep.CurrentCell.ColumnIndex = 1 Or dgdep.CurrentCell.ColumnIndex = 3 Then
                dgdep.CurrentCell = dgdep.Item(dgdep.CurrentCell.ColumnIndex, dgdep.CurrentRow.Index)
                grid()
                Exit Sub
            ElseIf dgdep.CurrentCell.ColumnIndex = 2 Then
                dgdep.CurrentCell = dgdep.Item(2, dgdep.CurrentRow.Index)
                cmbsex1()
                Exit Sub
            ElseIf dgdep.CurrentCell.ColumnIndex = 4 Then
                dgdep.CurrentCell = dgdep.Item(4, dgdep.CurrentRow.Index)
                depcombo1()
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub depcombo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles depcombo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case dgdep.CurrentCell.ColumnIndex
                    Case 4
                        dgdep.Item(4, dgdep.CurrentCell.RowIndex).Value = depcombo.Text
                        dgdep.FirstDisplayedScrollingColumnIndex = 4
                        grid()
                End Select
            End If

            If e.KeyCode = Keys.Escape Then
                dgdep.Item(4, dgdep.CurrentRow.Index).Value = ""
                'dgdep.Rows.Add()
                'dgdep.CurrentCell = dgdep.Item(0, dgdep.CurrentRow.Index + 1)
                depcombo.Visible = False
                depcombo.Text = ""
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgdep_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdep.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Want to delete the record..? ", vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then Exit Sub
                'Dim command As New OleDb.OleDbCommand
                'command.Connection = Conn

                If dgdep.Item(0, dgdep.CurrentRow.Index).Value & "" <> "" Then
                    'command.CommandText = "delete from dependent where cardno=" & txtcno.Text & " and code=" & dgdep.Item(0, dgdep.CurrentRow.Index).Value & ""
                    'command.CommandType = CommandType.StoredProcedure
                    'command.CommandText = "delete_dependent1"
                    'command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = txtcno.Text
                    'command.Parameters.Add("@code", OleDb.OleDbType.BigInt).Value = dgdep.Item(0, dgdep.CurrentRow.Index).Value
                    'command.ExecuteNonQuery()
                    'command.Parameters.Clear()
                    dgdep.Rows.RemoveAt((dgdep.CurrentRow.Index))
                    ' Else
                    'dgdep.Rows.RemoveAt((dgdep.CurrentRow.Index))
                End If
            End If

            If e.KeyCode = Keys.Enter Then
                dgdep_DoubleClick()
                e.Handled = True
            End If

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgdep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgdep.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                'If dgdep.CurrentCell.ColumnIndex = 1 Then
                '    If dgdep.Item(1, dgdep.CurrentRow.Index - 1).Value & "" = "" Then Exit Sub
                '    dgdep.Item(2, dgdep.CurrentRow.Index - 1).Selected = True
                'End If
                ''If dgdep.CurrentCell.ColumnIndex = 1 Or dgdep.CurrentCell.ColumnIndex = 2 Then
                ''    grid()
                ''    Exit Sub
                ''End If

                ''If dgdep.CurrentCell.ColumnIndex = 3 Then
                ''    If dgdep.CurrentRow.Index = dgdep.Rows.Count Then
                ''        dgdep.Rows.Add()
                ''    End If
                ''    dgdep.CurrentCell = dgdep.Item(1, dgdep.Rows.Count - 1)
                ''    grid()
                ''End If
                'If dgdep.CurrentCell.ColumnIndex = 3 Then
                '    'depcombo.Visible = True
                '    'depcombo.Location = dgdep.Location
                '    'depcombo.Top = dgdep.Top
                '    'depcombo.Left = dgdep.Left
                '    'depcombo.Top = dgdep.Top + dgdep.GetRowDisplayRectangle(dgdep.CurrentCell.RowIndex, True).Top
                '    'depcombo.Left = dgdep.Left + dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Left
                '    'depcombo.Width = dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Width
                '    'depcombo.Text = dgdep.CurrentCell.Value & ""
                '    'depcombo.Visible = True
                '    'depcombo.Focus()
                '    ' depcombo1()
                '    If depcombo.Visible = True And depcombo.Text <> "" Then
                '        dgdep.Item(3, dgdep.CurrentRow.Index).Value = depcombo.SelectedItem
                '        depcombo.Visible = False

                '        dgdep.CurrentCell = dgdep.Item(0, dgdep.CurrentRow.Index + 1)

                '        grid()
                '    End If
                'End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub tsbadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        Try
            Adding = True
            Selected = False
            'prodadding = True
            tsbSave.Enabled = True
            tsbAdd.Enabled = False
            txtcno.Enabled = False
            lblStatus.Text = "Adding A New Card.."
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtname.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub grid()
        Try
            gridctrl.Visible = True
            gridctrl.Location = dgdep.Location
            gridctrl.Top = dgdep.Top
            gridctrl.Left = dgdep.Left
            gridctrl.Top = dgdep.Top + dgdep.GetRowDisplayRectangle(dgdep.CurrentCell.RowIndex, True).Top
            gridctrl.Left = dgdep.Left + dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Left
            gridctrl.Width = dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Width
            gridctrl.Text = dgdep.CurrentCell.Value & ""
            gridctrl.Visible = True
            gridctrl.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        If Selected = True Then Exit Sub
        obj = txtname
        populate()
    End Sub

    Private Sub populate()
        Dim prodstr As String
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Try
            prodstr = obj.text
            cmd.Connection = Conn
            ' cmd.CommandText = "SET QUOTED_IDENTIFIER ON"
            'cmd.ExecuteNonQuery()

            If obj.Text <> "" Then

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "select_cardname"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = prodstr

                da.SelectCommand = cmd
                da.Fill(ds, "Carddetails")
                Dgcard.DataSource = ds.Tables("Carddetails")

                If ds.Tables("Carddetails").Rows.Count = 0 Then
                    Pnl.Visible = False
                    obj.SelectionStart = Len(obj.Text)
                    obj.Focus()
                    If Not Adding Then
                        txtname.Text = ""
                    End If
                    Exit Sub
                End If

                Dgcard.Columns(0).Width = 0
                Dgcard.Columns(0).Width = 100
                Dgcard.Columns(1).Width = 250
                Dgcard.Columns(2).Width = 120
                Pnl.Visible = False

                Dgcard.DefaultCellStyle.ForeColor = Color.Black
                Dgcard.DefaultCellStyle.BackColor = Color.White

                If (Dgcard.Rows.Count >= 1) Then
                    Pnl.Visible = True
                    Dgcard.Focus()
                    Exit Sub
                End If
            End If

            Pnl.Visible = False
            If Not Adding Then
                obj.Text = ""
            Else
                obj.Focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub getcarddetils(ByVal code As String)
        Dim command As New OleDb.OleDbCommand
        Dim cmd As New OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        Dim dr As OleDb.OleDbDataReader
        Dim i As Integer = 0
        If code = "" Then
            If Not Adding Then clearform()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            command.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = " select_carddetails"
            command.Parameters.Add("@cardno", OleDb.OleDbType.Integer).Value = code 'dgname.Item(2, dgname.CurrentRow.Index).Value
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
                If Not Adding Then clearform()
                Me.Cursor = Cursors.Default
                reader.Close()
                Exit Sub
            End If
            dgdep.Rows.Clear()
            Selected = True
            tsbAdd.Enabled = False
            tsbSave.Enabled = True
            tsbDel.Enabled = True
            dgdep.Rows.Add()
            While reader.Read
                lblcardno.Visible = True
                txtcno.Visible = True
                txtcno.Text = reader("cardno") & ""
                txtname.Text = reader("name") & ""
                txtaddr1.Text = reader("addr1") & ""
                txtaddr2.Text = reader("addr2") & ""
                txtaddr3.Text = reader("addr3") & ""
                txtplace.Text = reader("place") & ""
                txtphone.Text = reader("phone") & ""
                txtemail.Text = reader("emailid") & ""
                chkSMS.Checked = reader("ActSMS")
                ChkEmail.Checked = reader("ActEmail")
                txtDeclratnNo.Text = reader("SMSDeclNo") & ""
                txtdob.Text = reader("DOB") & ""
                txtdis.Text = reader("disc") & ""
                cmbCustGrp.SelectedValue = Val(reader("Cgrpcode") & "")

                txtname.Focus()
                txtname.SelectionStart = Len(txtname.Text)

                If reader("code") & "" <> "" Then

                    dgdep.Item(0, i).Value = reader("code")
                    dgdep.Item(1, i).Value = reader("dname")
                    dgdep.Item(2, i).Value = reader("sex")
                    dgdep.Item(3, i).Value = reader("age")
                    dgdep.Item(4, i).Value = reader("relation")
                    i += 1
                    dgdep.Rows.Add()

                End If
            End While
            reader.Close()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Try
            'If txtname.Text = "" Or txtcno.Text = "" Or txtaddr1.Text = "" Or txtplace.Text = "" Or txtphone.Text = "" Or txtemail.Text = "" Then
            '    MsgBox("Please fill in all records", vbInformation)
            '    Exit Sub
            'End If

            'If Not Regex.Match(txtphone.Text, "^[0-9]*$").Success Then
            '    MsgBox("Invalid phone No", vbInformation)
            '    Exit Sub
            'End If

            'If Not Regex.Match(txtname.Text, "^[A-Z]*$").Success Then
            '    MsgBox("Invalid name", vbInformation)
            '    Exit Sub
            'End If
            Me.Cursor = Cursors.WaitCursor
            Dim command As New Data.OleDb.OleDbCommand
            Dim command1 As New OleDb.OleDbCommand
            Dim i As Integer
            Dim code As Integer
            Dim cardno As Integer
            Dim DeclratnNo As Integer
            Dim CustGrp As Integer
            command.Connection = Conn
            command1.Connection = Conn
            'If ConnectionState.Open Then
            '    Conn.Close()
            'End If

            If Adding = True Then
                command.CommandText = "select max(cardno) from CardDetails"
                cardno = Val(command.ExecuteScalar & "")
                If cardno = Nothing Then
                    cardno = 1
                Else
                    cardno = cardno + 1
                End If
                txtcno.Text = cardno
            ElseIf Adding = False Then
                cardno = Val(txtcno.Text)
            End If

            CustGrp = Val(cmbCustGrp.SelectedValue)
            'Conn.Open()
            command.CommandType = CommandType.StoredProcedure
            'If recadd = True Then

            command.Parameters.Add("@cardno", OleDb.OleDbType.Integer).Value = cardno
            command.Parameters.Add("@name", OleDb.OleDbType.VarChar).Value = txtname.Text & ""
            command.Parameters.Add("@addr1", OleDb.OleDbType.VarChar).Value = txtaddr1.Text & ""
            command.Parameters.Add("@addr2", OleDb.OleDbType.VarChar).Value = txtaddr2.Text & ""
            command.Parameters.Add("@addr3", OleDb.OleDbType.VarChar).Value = txtaddr3.Text & ""
            command.Parameters.Add("@place", OleDb.OleDbType.VarChar).Value = txtplace.Text & ""
            command.Parameters.Add("@phone", OleDb.OleDbType.VarChar).Value = txtphone.Text & ""
            command.Parameters.Add("@email", OleDb.OleDbType.VarChar).Value = txtemail.Text & ""
            command.Parameters.Add("@ActSMS", OleDb.OleDbType.Boolean).Value = chkSMS.Checked
            command.Parameters.Add("@ActEmail", OleDb.OleDbType.Boolean).Value = ChkEmail.Checked
            command.Parameters.Add("@SMSDeclNo", OleDb.OleDbType.VarChar).Value = txtDeclratnNo.Text

            If IsDate(txtdob.Text) Then
                command.Parameters.Add("@DOB", OleDb.OleDbType.Date).Value = CDate(txtdob.Text)
            Else
                command.Parameters.Add("@DOB", OleDb.OleDbType.Date).Value = DBNull.Value
            End If

            command.Parameters.Add("@CGrpCode", OleDb.OleDbType.BigInt).Value = CustGrp
            command.Parameters.Add("@disc", OleDb.OleDbType.Double).Value = Val(txtdis.Text)

            If Adding = True Then
                command.CommandText = "insert_carddetails"
            ElseIf Adding = False Then
                command.CommandText = "update_carddetails"
            End If

            command.ExecuteNonQuery()
            command.Parameters.Clear()

            If dgdep.Rows.Count >= 2 Then
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "delete_CardDependent"
                command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(txtcno.Text)
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                For i = 0 To dgdep.Rows.Count - 2
                    If dgdep.Item(1, i).Value & "" <> "" Then
                        command1.CommandType = CommandType.Text
                        command1.CommandText = "select max(code) from carddependent"
                        code = Val(command1.ExecuteScalar & "")
                        If code = Nothing Then
                            code = 1
                        Else
                            code += 1
                        End If

                        command.CommandType = CommandType.StoredProcedure
                        command.CommandText = "insert_carddependent"
                        command.Parameters.Add("@cardno", OleDb.OleDbType.Integer).Value = Val(txtcno.Text & "")
                        command.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = code
                        'command.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = Val(dgdep.Item(0, i).Value & "")
                        command.Parameters.Add("@name", OleDb.OleDbType.VarChar).Value = dgdep.Item(1, i).Value & ""
                        command.Parameters.Add("@age", OleDb.OleDbType.Integer).Value = Val(dgdep.Item(3, i).Value & "")
                        command.Parameters.Add("@relation", OleDb.OleDbType.VarChar).Value = dgdep.Item(4, i).Value & ""
                        command.Parameters.Add("@sex", OleDb.OleDbType.VarChar).Value = dgdep.Item(2, i).Value & ""
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    End If

                Next
            End If

            If Adding = True Then
                MsgBox("Card number is " & txtcno.Text)
            End If

            clearform()
            'populate()
            Selected = False

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        Dim command As New OleDb.OleDbCommand
        Try
            command.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "delete_carddetails"
            command.Parameters.Add("@cardno", OleDb.OleDbType.Integer).Value = txtcno.Text
            command.ExecuteNonQuery()
            command.Parameters.Clear()
            clearform()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub gridctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridctrl.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case dgdep.CurrentCell.ColumnIndex
                Case 1
                    If gridctrl.Text = "" Then Exit Sub
                    If dgdep.CurrentCell.RowIndex = dgdep.Rows.Count - 1 Then dgdep.Rows.Add()
                    dgdep.Item(1, dgdep.CurrentCell.RowIndex).Value = gridctrl.Text
                    'dgdep.CurrentCell = dgdep.Item(0, dgdep.Rows.Count - 1)
                    dgdep.FirstDisplayedScrollingColumnIndex = 1
                    'dgdep.Focus()
                    dgdep.CurrentCell = dgdep.CurrentRow.Cells(2)
                    cmbsex1()

                Case 3
                    dgdep.Item(3, dgdep.CurrentCell.RowIndex).Value = gridctrl.Text
                    dgdep.FirstDisplayedScrollingColumnIndex = 3
                    'dgdep.Focus()
                    dgdep.CurrentCell = dgdep.CurrentRow.Cells(4)
                    depcombo1()

            End Select
        End If
    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If dgdep.CurrentCell.ColumnIndex = 1 Then
                    If gridctrl.Visible = True And gridctrl.Text <> "" Then
                        dgdep.Item(1, dgdep.CurrentRow.Index).Value = gridctrl.Text
                        dgdep.Focus()
                        gridctrl.Visible = False

                        dgdep.CurrentCell = dgdep.CurrentRow.Cells(2)
                        cmbsex1()
                        Exit Sub
                    End If
                End If

                If dgdep.CurrentCell.ColumnIndex = 3 Then
                    If gridctrl.Visible = True And gridctrl.Text <> "" Then
                        dgdep.Item(3, dgdep.CurrentRow.Index).Value = gridctrl.Text

                        dgdep.Focus()
                        gridctrl.Visible = False

                        dgdep.CurrentCell = dgdep.CurrentRow.Cells(4)
                        depcombo1()
                        Exit Sub
                    End If
                End If

            End If

            If Asc(e.KeyChar) = 27 Then
                dgdep.Focus()
                gridctrl.Visible = False

                Exit Sub
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub depcombo1()
        Try
            depcombo.Visible = True
            depcombo.Location = dgdep.Location
            depcombo.Top = dgdep.Top
            depcombo.Left = dgdep.Left
            depcombo.Top = dgdep.Top + dgdep.GetRowDisplayRectangle(dgdep.CurrentCell.RowIndex, True).Top
            depcombo.Left = dgdep.Left + dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Left
            depcombo.Width = dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Width
            depcombo.Text = dgdep.CurrentCell.Value & ""
            depcombo.Visible = True
            depcombo.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub cmbsex1()
        Try
            cmbsex.Visible = True
            cmbsex.Location = dgdep.Location
            cmbsex.Top = dgdep.Top
            cmbsex.Left = dgdep.Left
            cmbsex.Top = dgdep.Top + dgdep.GetRowDisplayRectangle(dgdep.CurrentCell.RowIndex, True).Top
            cmbsex.Left = dgdep.Left + dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Left
            cmbsex.Width = dgdep.GetColumnDisplayRectangle(dgdep.CurrentCell.ColumnIndex, True).Width
            cmbsex.Text = dgdep.CurrentCell.Value & ""
            cmbsex.Visible = True
            cmbsex.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub depcombo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles depcombo.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If dgdep.CurrentCell.ColumnIndex = 4 Then

                    dgdep.Item(4, dgdep.CurrentRow.Index).Value = depcombo.Text
                    depcombo.Visible = False

                    If dgdep.CurrentRow.Index = dgdep.Rows.Count - 1 Then
                        dgdep.Rows.Add()
                    End If
                    dgdep.CurrentCell = dgdep.Item(1, dgdep.Rows.Count - 1)
                    grid()
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub CardDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                System.Windows.Forms.SendKeys.Send("{tab}")
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub CardDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgdep.Rows.Add()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
            lblStatus.Text = "Please select a card.."
            clearform()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub gridctrl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.LostFocus
        gridctrl.Visible = False
    End Sub

    Private Sub cmbsex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbsex.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case dgdep.CurrentCell.ColumnIndex
                Case 2
                    dgdep.Item(2, dgdep.CurrentCell.RowIndex).Value = cmbsex.Text
                    dgdep.FirstDisplayedScrollingColumnIndex = 2
                    'dgdep.Focus()
                    dgdep.CurrentCell = dgdep.CurrentRow.Cells(3)
                    grid()
            End Select
        End If
    End Sub

    Private Sub cmbsex_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsex.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If dgdep.CurrentCell.ColumnIndex = 2 Then
                    If cmbsex.Visible = True Then
                        dgdep.Item(2, dgdep.CurrentRow.Index).Value = cmbsex.SelectedText
                        cmbsex.Visible = False
                        dgdep.CurrentCell = dgdep.CurrentRow.Cells(3)
                        grid()
                        Exit Sub
                    End If
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub cmbsex_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsex.LostFocus
        cmbsex.Visible = False
    End Sub

    Private Sub depcombo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles depcombo.LostFocus
        depcombo.Visible = False
    End Sub

    Private Sub clearform()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            cmd.Connection = Conn
            cmd.CommandText = "Select GrpCode,GrpName from CustGroup order by Grpname"
            da.SelectCommand = cmd
            da.Fill(ds, "CustGroup")
            cmbCustGrp.DataSource = Nothing
            cmbCustGrp.DisplayMember = "GrpName"
            cmbCustGrp.ValueMember = "GrpCode"
            cmbCustGrp.DataSource = ds.Tables("CustGroup")
            cmbCustGrp.Refresh()
            dgdep.Rows.Clear()
            gridctrl.Text = ""
            gridctrl.Visible = False
            cmbsex.Text = ""
            cmbsex.Visible = False
            depcombo.Text = ""
            depcombo.Visible = False
            txtcno.Enabled = True
            txtcno.Text = ""
            txtname.Text = ""
            txtaddr1.Text = ""
            txtaddr2.Text = ""
            txtaddr3.Text = ""
            txtphone.Text = ""
            txtplace.Text = ""
            txtemail.Text = ""
            chkSMS.Checked = False
            ChkEmail.Checked = False
            txtDeclratnNo.Text = ""
            TXTDOB.Text = ""
            cmbCustGrp.Text = ""
            txtdis.Text = ""
            lblStatus.Text = "Please select a card.."
            'lblcardno.Visible = False
            ' txtcno.Visible = False
            tsbAdd.Enabled = True
            tsbDel.Enabled = False
            tsbSave.Enabled = False
            Selected = False
            dgdep.Rows.Add()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        clearform()
        Adding = False
    End Sub

    Private Sub Getinfo()
        Pnl.Visible = False
        Try
            If Not Adding Then

                getcarddetils(Dgcard.Item(0, Dgcard.CurrentCell.RowIndex).Value)
            Else
                txtname.Focus()
                txtname.SelectionStart = Len(txtname.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub Dgcard_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgcard.DoubleClick
        Getinfo()
    End Sub

    Private Sub Dgcard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dgcard.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then
                Exit Sub
            End If

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                Pnl.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then Pnl.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub Dgcard_PreviewKeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Dgcard.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Getinfo()
        End If
    End Sub

    Private Sub txtaddr1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtaddr1.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtaddr2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtaddr2.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtaddr3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtaddr3.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtplace_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplace.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtphone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtphone.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtemail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtemail.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub txtcno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcno.KeyPress
        If e.KeyChar = Chr(13) Then
            System.Windows.Forms.SendKeys.Send("{tab}")

        End If
        If InStr("0123456789.", e.KeyChar) = 0 And e.KeyChar <> Chr(8) Then e.KeyChar = ""
    End Sub

    Private Sub txtcno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcno.Validating
        getcarddetils(Val(txtcno.Text))
    End Sub

    Private Sub chkSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkSMS.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub ChkEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDeclratnNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeclratnNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtdob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdob.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

End Class