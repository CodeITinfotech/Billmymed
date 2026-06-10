Public Class InvAccountsPay

    Private Sub InvAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Try
            cmd.Connection = Conn
            cmd.Connection = Conn
            'dgRec.Enabled = True
            cmd.CommandText = "select Accode,Acmaster.Acname + ' ' + Acmaster.place as [AcName] from Acmaster where grpcode=" & SupGrpcode & " order by Acname"
            da.SelectCommand = cmd
            da.Fill(DS, "Acmaster")
            suppliercombo.DisplayMember = "AcName"
            suppliercombo.ValueMember = "AcCode"
            suppliercombo.DataSource = DS.Tables("Acmaster")
            suppliercombo.SelectedValue = 0
            grdacc.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            grdacc.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            grdacc.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            grdacc.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
            suppliercombo.SelectedValue = 0
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
        'grdacc.Columns(0).SortMode = 
    End Sub

    

    Private Sub GetTotal()
        Dim cmd As New OleDb.OleDbCommand
        If suppliercombo.SelectedValue = Nothing Then Exit Sub
        cmd.Connection = Conn

        cmd.CommandText = "Select round(isnull(sum(amt-adjamt),0),2) as [Balance]  from Invaccounts where mode ='p' and party = " & _
                                 suppliercombo.SelectedValue
        lbltot.Text = cmd.ExecuteScalar

        cmd.CommandText = "Select round(isnull(sum(amt-adjamt),0),2) as [Balance]  from Invaccounts where mode ='P'  "
        lblgtot.Text = cmd.ExecuteScalar


    End Sub



    Private Sub populate()
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        Dim ds As New DataSet
        Dim sqltxt As String
        If suppliercombo.SelectedValue = Nothing Then Exit Sub
        Try
            If chkshow.Checked Then
                sqltxt = " and amt-adjamt<>0 "
            Else
                sqltxt = ""
            End If

            cmd.Connection = Conn
            cmd.CommandText = "Select billno as [Bill No],convert(datetime,billdt,103) as [Bill Date]," & _
            "amt as [Amount],adjamt as [Received],amt-adjamt as [Balance],'' AS [payment],id,par,remarks " & _
            " from Invaccounts WHERE  party = " & suppliercombo.SelectedValue & " and mode = 'P' " & sqltxt & "  order by billdt,id"

            dr = cmd.ExecuteReader
            grdacc.Rows.Clear()
            If dr.HasRows Then
                While dr.Read
                    grdacc.Rows.Add()
                    grdacc.Item(0, grdacc.Rows.Count - 1).Value = dr(0)
                    grdacc.Item(1, grdacc.Rows.Count - 1).Value = Format(dr(1), DateFormat)
                    grdacc.Item(2, grdacc.Rows.Count - 1).Value = dr(2)
                    grdacc.Item(3, grdacc.Rows.Count - 1).Value = dr(3)
                    grdacc.Item(4, grdacc.Rows.Count - 1).Value = dr(4)
                    grdacc.Item(5, grdacc.Rows.Count - 1).Value = dr(5)
                    grdacc.Item(6, grdacc.Rows.Count - 1).Value = dr(6)
                    grdacc.Item(7, grdacc.Rows.Count - 1).Value = dr(7)
                    grdacc.Item(8, grdacc.Rows.Count - 1).Value = dr(8)

                End While
            End If
            grdacc.Rows.Add()

        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
        ' grdacc.Rows.Add()
    End Sub
    Private Sub editgrid()

        Dim n As Integer
        Dim command As New OleDb.OleDbCommand
        command.Connection = Conn
        Try
            If grdacc.CurrentRow.Index = grdacc.Rows.Count - 1 Then

                If grdacc.CurrentCell.ColumnIndex < 3 Then
                    If grdacc.CurrentCell.ColumnIndex = 1 Then
                        gridctrl.Mask = DateMask

                        gridctrl.PromptChar = "_"
                    Else
                        gridctrl.Mask = ""

                        gridctrl.PromptChar = " "
                    End If

                    gridctrl.Top = grdacc.Top + grdacc.GetRowDisplayRectangle(grdacc.CurrentCell.RowIndex, True).Top
                    gridctrl.Left = grdacc.Left + grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Left
                    gridctrl.Width = grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Width
                    grdacc.Enabled = False


                    gridctrl.Visible = True

                    If grdacc.CurrentCell.ColumnIndex = 1 Then
                        If IsDate(grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & "") Then
                            gridctrl.Text = (grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value)
                        Else
                            gridctrl.Text = "__/__/__"
                        End If
                    Else
                        'If grdacc.CurrentCell.ColumnIndex = 12 Or grdacc.CurrentCell.ColumnIndex = 14 Then gridctrl.MaxLength = 10
                        gridctrl.Text = grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & ""
                    End If
                    grdacc.Enabled = False
                    Application.DoEvents()
                    gridctrl.Focus()

                End If

            Else
                If grdacc.CurrentCell.ColumnIndex = 5 Then

                    gridctrl.Top = grdacc.Top + grdacc.GetRowDisplayRectangle(grdacc.CurrentCell.RowIndex, True).Top
                    gridctrl.Left = grdacc.Left + grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Left
                    gridctrl.Width = grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Width
                    grdacc.Enabled = False
                    gridctrl.Visible = True
                    If Val(grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & "") = 0 Then
                        gridctrl.Text = Format(Val(grdacc.Item(grdacc.CurrentCell.ColumnIndex - 1, grdacc.CurrentRow.Index).Value & ""), "0.00")
                    Else
                        gridctrl.Text = Format(Val(grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & ""), "0.00")
                    End If

                    grdacc.Enabled = False
                    Application.DoEvents()
                    gridctrl.Focus()
                ElseIf grdacc.CurrentCell.ColumnIndex = 7 Then

                    gridctrl.Top = grdacc.Top + grdacc.GetRowDisplayRectangle(grdacc.CurrentCell.RowIndex, True).Top
                    gridctrl.Left = grdacc.Left + grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Left
                    gridctrl.Width = grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Width
                    grdacc.Enabled = False
                    gridctrl.Visible = True
                    gridctrl.Text = grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & ""
                    grdacc.Enabled = False
                    Application.DoEvents()
                    gridctrl.Focus()
                End If

            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Sub

    Private Sub gridctrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.GotFocus
        gridctrl.SelectAll()
    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress
        Try
            Dim RVAL, ADJVAL As Double
            If e.KeyChar = Chr(13) Then
                Dim cmd As New OleDb.OleDbCommand
                Select Case grdacc.CurrentCell.ColumnIndex
                    Case 5
                        'If Val(gridctrl.Text) > 0 Then

                        If (Val(lbltot.Text) + Val(grdacc.CurrentCell.Value & "")) < Val(gridctrl.Text) Then
                            MsgBox("Payment value exceeds the balance amount..")
                            Application.DoEvents()
                            gridctrl.Focus()
                            Exit Sub
                        End If

                        RVAL = Val(gridctrl.Text)
                        For I = grdacc.CurrentCell.RowIndex To grdacc.Rows.Count - 1

                            If Val(grdacc.Item(4, I).Value & "") > 0 Then
                                If Val(grdacc.Item(4, I).Value & "") >= RVAL Then
                                    ADJVAL = RVAL
                                    RVAL = 0
                                Else
                                    ADJVAL = Val(grdacc.Item(4, I).Value & "")
                                    RVAL = RVAL - ADJVAL
                                End If
                                cmd.Connection = Conn

                                cmd.CommandText = "update invAccounts set PAR='Cash Paid on " & SysDt & "',adjamt=(adjamt-" & Val(grdacc.Item(5, I).Value & "") & "+" & ADJVAL & ") where id=" & Val(grdacc.Item(6, I).Value & "")
                                cmd.ExecuteNonQuery()
                                'cmd.CommandText = "update invAccounts set remarks='Cash Paid on " & SysDt & "', adjamt=adjamt - " & Val(grdacc.Item(5, I).Value & "") & "+" & Val(gridctrl.Text) & " where id=" & Val(grdacc.Item(6, I).Value & "")

                                'cmd.ExecuteNonQuery()
                                grdacc.Item(7, I).Value = "Cash Paid on " & SysDt
                                grdacc.Item(5, I).Value = Format(Val(ADJVAL), "0.00")
                            End If
                            If RVAL = 0 Then Exit For

                        Next
                        If RVAL <> 0 Then
                            MsgBox("Receipt Value Exceeds the balance amount..")
                        End If
                        GetTotal()
                        ' End If




                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.Focus()
                    Case 4
                        'grdacc.CurrentCell.Value = Format(Val(gridctrl.Text), "0.00")
                        'grdacc.Item(4, grdacc.CurrentRow.Index).Value = Format(Val(gridctrl.Text), "0.00")
                        'gridctrl.Visible = False
                        'grdacc.Enabled = True
                        'grdacc.Rows.Add()
                        'grdacc.Focus()
                        'cmd.Connection = Conn
                        'cmd.CommandText = "insert into invAccounts (type,mode,billno,Billdt,name," & _
                        '        "Party,Amt,adjamt) values('21','R','" & _
                        '        (grdacc.Item(0, grdacc.CurrentRow.Index).Value & "") & "','" & _
                        '        (grdacc.Item(1, grdacc.CurrentRow.Index).Value & "") & _
                        '        "',""" + cbPat.Text + """,0" & _
                        '        "," & (grdacc.Item(2, grdacc.CurrentRow.Index).Value & "") & _
                        '        ",0)"
                        'cmd.ExecuteNonQuery()
                    Case 2 '  AMT
                        grdacc.CurrentCell.Value = Format(Val(gridctrl.Text), "0.00")
                        grdacc.Item(4, grdacc.CurrentRow.Index).Value = Format(Val(gridctrl.Text), "0.00")
                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.Rows.Add()
                        grdacc.Focus()
                        cmd.Connection = Conn
                        cmd.CommandText = "insert into invAccounts (type,mode,billno,Billdt,name," & _
                                "Amt,adjamt,party) values('21','P',""" & _
                                (grdacc.Item(0, grdacc.CurrentRow.Index).Value & "") & """,'" & _
                                (grdacc.Item(1, grdacc.CurrentRow.Index).Value & "") & _
                                "',''" & _
                                "," & (grdacc.Item(2, grdacc.CurrentRow.Index).Value & "") & _
                                ",0," & suppliercombo.SelectedValue & " )"
                        cmd.ExecuteNonQuery()
                        populate()
                        GetTotal()

                    Case 0 '  NO
                        grdacc.CurrentCell.Value = gridctrl.Text
                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.CurrentCell = grdacc.Item(1, grdacc.CurrentRow.Index)
                        editgrid()
                    Case 7 '  NO

                        cmd.Connection = Conn
                        cmd.CommandText = "update invAccounts set par=""" & gridctrl.Text & """ where id=" & Val(grdacc.Item(6, grdacc.CurrentRow.Index).Value & "")
                        cmd.ExecuteNonQuery()

                        grdacc.CurrentCell.Value = gridctrl.Text
                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.CurrentCell = grdacc.Item(1, grdacc.CurrentRow.Index)
                        grdacc.Focus()
                    Case 1  ' DT 
                        If DateCheck(gridctrl, False) Then
                            grdacc.CurrentCell.Value = gridctrl.Text
                            gridctrl.Visible = False
                            grdacc.Enabled = True
                            grdacc.CurrentCell = grdacc.Item(2, grdacc.CurrentRow.Index)
                            editgrid()
                        Else
                            gridctrl.Focus()
                            Exit Sub
                        End If
                End Select
            ElseIf e.KeyChar = Chr(27) Then

                ' grdacc.CurrentCell.Value = gridctrl.Text
                gridctrl.Visible = False
                grdacc.Enabled = True
                grdacc.Focus()

            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Sub

    Private Sub gridctrl_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles gridctrl.MaskInputRejected

    End Sub

    Private Sub grdacc_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdacc.CausesValidationChanged

    End Sub

    Private Sub grdacc_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdacc.CellContentClick

    End Sub

    Private Sub grdacc_CellDoubleClick() Handles grdacc.CellDoubleClick
        editgrid()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub grdacc_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdacc.DefaultValuesNeeded

    End Sub

    Private Sub grdacc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdacc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                grdacc_CellDoubleClick()

                e.Handled = True
            End If
            If e.KeyCode = Keys.Escape Then
                gridctrl.Visible = False
                grdacc.Focus()
                grdacc.Enabled = True
                e.Handled = True
            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Try
            For i = 0 To grdacc.Rows.Count - 2
                cmd.CommandText = "update invAccounts set adjamt=adjamt + " & Val(grdacc.Item(5, grdacc.CurrentRow.Index).Value & "")

                cmd.ExecuteNonQuery()
            Next
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Sub


    Private Sub chkshow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkshow.CheckedChanged
        populate()
    End Sub

    Private Sub suppliercombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles suppliercombo.SelectedIndexChanged
        populate()
        GetTotal()
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        populate()
        GetTotal()
    End Sub
End Class