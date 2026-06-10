Public Class CardSales

    Private Sub InvAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Application.DoEvents()
        clearform()
    End Sub

    Private Sub clearform()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Try
            cmd.Connection = Conn


            cmd.CommandText = "select cardno,name as [view] from Carddetails order by name"
            da.SelectCommand = cmd
            da.Fill(dt)
            cbccard.DisplayMember = "view"
            cbccard.ValueMember = "cardno"
            cbccard.DataSource = dt

            'cbccard.SelectedText = ""
            cbccard.Text = ""
            cbccard.SelectedValue = 0
            'txtccard.Text = ""
            dtp.Value = CDate("01/" & SysDt.Month & "/" & SysDt.Year)
            grdacc.Rows.Clear()
            lbltotc1.Text = ""
            lbltotc2.Text = ""
            lbltotc3.Text = ""

            lbl21.Text = ""
            lbl22.Text = ""
            lbl23.Text = ""


            lbl51.Text = ""
            lbl52.Text = ""
            lbl53.Text = ""

            lbltot1.Text = ""
            lbltot2.Text = ""
            lbltot3.Text = ""
            txtrmk.Text = ""


           

            grdacc.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            grdacc.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'grdacc.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'grdacc.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            grdacc.Rows.Add()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer

        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
        'grdacc.Columns(0).SortMode = 
    End Sub


    Private Sub GetTotal()
        Dim cmd As New OleDb.OleDbCommand


    End Sub



    Private Sub populate()
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim dtf1 As Date
        Dim dtt1 As Date

        Dim dtf2 As Date
        Dim dtt2 As Date

        Dim dtf3 As Date
        Dim dtt3 As Date

        Dim ds As New DataSet

        lbltotc1.Text = ""
        lbltotc2.Text = ""
        lbltotc3.Text = ""

        lbl21.Text = ""
        lbl22.Text = ""
        lbl23.Text = ""


        lbl51.Text = ""
        lbl52.Text = ""
        lbl53.Text = ""

        lbltot1.Text = ""
        lbltot2.Text = ""
        lbltot3.Text = ""
        txtrmk.Text = ""
        chk.Checked = False

        If cbccard.Text = "" Then Exit Sub
        If cbccard.SelectedValue = Nothing Then Exit Sub
        Try

            dtf1 = CDate("01/" & dtp.Value.Date.Month & "/" & dtp.Value.Date.Year)

            dtf2 = DateAdd(DateInterval.Month, -1, dtf1)
            dtf3 = DateAdd(DateInterval.Month, -2, dtf1)

            dtt1 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf1))

            dtt2 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf2))
            dtt3 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf3))

            lbltotc1.Text = Format(dtf1, "MMM yyyy")
            lbltotc2.Text = Format(dtf2, "MMM yyyy")
            lbltotc3.Text = Format(dtf3, "MMM yyyy")

            cmd.Connection = Conn
            cmd.CommandText = "Select billno as [Bill No],convert(datetime,billdt,103) as [Bill Date]," & _
                 "amt as [Amount],id,settled,rmk " & _
                  " from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                     " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  order by billdt,id"

            dr = cmd.ExecuteReader
            grdacc.Rows.Clear()

            Dim flg As Integer
            flg = 0

            If dr.HasRows Then

                While dr.Read
                    If flg = 0 Then
                        chk.Checked = dr("settled")

                        txtrmk.Text = dr("rmk") & ""
                        flg = 1
                    End If
                    grdacc.Rows.Add()
                    grdacc.Item(0, grdacc.Rows.Count - 1).Value = dr(0)
                    grdacc.Item(1, grdacc.Rows.Count - 1).Value = Format(dr(1), DateFormat)
                    grdacc.Item(2, grdacc.Rows.Count - 1).Value = dr(2)
                    grdacc.Item(3, grdacc.Rows.Count - 1).Value = dr(3)

                End While

            End If
            grdacc.Rows.Add()
            dr.Close()

            Dim T1, T2, T3, CNT1, CNT2, CNT3, CNT4 As Double

            cmd.CommandText = "Select sum(amt) from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                       " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  AND  SETTLED=0"
            T1 = Format(Val(cmd.ExecuteScalar & ""), "0.00")

            cmd.CommandText = "Select sum(amt)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf2 & "') AND billdt <= convert(datetime,'" & dtt2 & "')  AND  SETTLED=0 "
            T2 = Format(Val(cmd.ExecuteScalar & ""), "0.00")

            cmd.CommandText = "Select sum(amt) from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf3 & "') AND billdt <= convert(datetime,'" & dtt3 & "')   AND  SETTLED=0"

            T3 = Format(Val(cmd.ExecuteScalar & ""), "0.00")


            cmd.CommandText = "Select sum(amt)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                     " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  "

            lbltot1.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")


            If T1 = 0 And Val(lbltot1.Text) <> 0 Then
                lbltot1.Text = "Settled"
            Else
                'lbltot1.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")
            End If


            cmd.CommandText = "Select sum(amt)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf2 & "') AND billdt <= convert(datetime,'" & dtt2 & "')     "
            lbltot2.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")


            If T2 = 0 And Val(lbltot2.Text) <> 0 Then
                lbltot2.Text = "Settled"
            Else
                'lbltot3.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")
            End If


            cmd.CommandText = "Select sum(amt)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf3 & "') AND billdt <= convert(datetime,'" & dtt3 & "')       "

            lbltot3.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")


            If T3 = 0 And Val(lbltot3.Text) <> 0 Then
                lbltot3.Text = "Settled"
            Else
                'lbltot3.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")
            End If





            If T3 = 0 And Val(lbltot3.Text) <> 0 Then
                lbltot3.Text = "Settled"
            Else
                lbltot3.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")
            End If



            cmd.CommandText = "Select COUNT(BILLNO)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                     " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  "
            CNT1 = Format(Val(cmd.ExecuteScalar & ""), "0.00")

            cmd.CommandText = "Select COUNT(BILLNO)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf2 & "') AND billdt <= convert(datetime,'" & dtt2 & "')   "
            CNT2 = Format(Val(cmd.ExecuteScalar & ""), "0.00")

            cmd.CommandText = "Select COUNT(BILLNO)  from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                   " billdt >= convert(datetime,'" & dtf3 & "') AND billdt <= convert(datetime,'" & dtt3 & "')   "

            CNT3 = Format(Val(cmd.ExecuteScalar & ""), "0.00")




            cmd.CommandText = "Select COUNT(BILLNO)  from cardsales WHERE " & _
                  " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')   "

            CNT4 = Format(Val(cmd.ExecuteScalar & ""), "0.00")

            totbills.Text = "Total No of Bill " & CNT4

            lbltotc1.Text = Format(dtf1, "MMM yyyy") & " (" & CNT1 & ")"
            lbltotc2.Text = Format(dtf2, "MMM yyyy") & " (" & CNT2 & ")"
            lbltotc3.Text = Format(dtf3, "MMM yyyy") & " (" & CNT3 & ")"






            lbl21.Text = Format(Val(T1) * 2 / 100, "0.00")
            lbl22.Text = Format(Val(T2) * 2 / 100, "0.00")
            lbl23.Text = Format(Val(T3) * 2 / 100, "0.00")

            lbl51.Text = Format(Val(T1) * 5 / 100, "0.00")
            lbl52.Text = Format(Val(T2) * 5 / 100, "0.00")
            lbl53.Text = Format(Val(T3) * 5 / 100, "0.00")

            lbltotot.Text = Format(Val(lbltot1.Text) + Val(lbltot2.Text) + Val(lbltot3.Text), "0.00")

            lbl2tot.Text = Format(Val(lbl21.Text) + Val(lbl22.Text) + Val(lbl23.Text), "0.00")
            lbl5tot.Text = Format(Val(lbl51.Text) + Val(lbl52.Text) + Val(lbl53.Text), "0.00")

            'Dim x As Integer
            'x = InStr(cbccard.Text, "(")
            'Dim vx As String
            'If x <> 0 Then
            '    vx = Trim(Microsoft.VisualBasic.Left(cbccard.Text, x - 1))
            'Else
            '    vx = cbccard.Text
            'End If

            ''cmd.CommandText = "Select round(isnull(sum(amt-adjamt),0),2) as [Balance]  from Invaccounts where mode ='R' and name = """ + _
            'vx(+"""  ")
            '' lblrcpt.Text = cmd.ExecuteScalar

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
                'If grdacc.CurrentCell.ColumnIndex = 5 Then

                '    gridctrl.Top = grdacc.Top + grdacc.GetRowDisplayRectangle(grdacc.CurrentCell.RowIndex, True).Top
                '    gridctrl.Left = grdacc.Left + grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Left
                '    gridctrl.Width = grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Width
                '    grdacc.Enabled = False
                '    gridctrl.Visible = True
                '    gridctrl.Text = Format(Val(grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & ""), "0.00")
                '    grdacc.Enabled = False
                '    Application.DoEvents()
                '    gridctrl.Focus()
                'ElseIf grdacc.CurrentCell.ColumnIndex = 7 Then

                '    gridctrl.Top = grdacc.Top + grdacc.GetRowDisplayRectangle(grdacc.CurrentCell.RowIndex, True).Top
                '    gridctrl.Left = grdacc.Left + grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Left
                '    gridctrl.Width = grdacc.GetColumnDisplayRectangle(grdacc.CurrentCell.ColumnIndex, True).Width
                '    grdacc.Enabled = False
                '    gridctrl.Visible = True
                '    gridctrl.Text = grdacc.Item(grdacc.CurrentCell.ColumnIndex, grdacc.CurrentRow.Index).Value & ""
                '    grdacc.Enabled = False
                '    Application.DoEvents()
                '    gridctrl.Focus()
                'End If

            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Sub

    Private Sub gridctrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.GotFocus
        gridctrl.SelectAll()

    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress
        Dim dtt1, dtf1 As Date
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        cmd.Connection = Conn
        Try
            If e.KeyChar = Chr(13) Then

                Select Case grdacc.CurrentCell.ColumnIndex

                    Case 2 '  AMT
                        grdacc.CurrentCell.Value = Format(Val(gridctrl.Text), "0.00")
                  
                        If grdacc.Item(0, grdacc.CurrentRow.Index).Value & "" = "" Then

                            grdacc.Item(0, grdacc.CurrentRow.Index).Value = grdacc.CurrentRow.Index + 1

                        End If

                        If Not IsDate(grdacc.Item(1, grdacc.CurrentRow.Index).Value & "") Then

                            grdacc.Item(1, grdacc.CurrentRow.Index).Value = SysDt

                        End If

                        cmd.CommandText = "insert into cardsales (billno,Billdt," & _
                                "Amt,cardno,settled) values('" & _
                                (grdacc.Item(0, grdacc.CurrentRow.Index).Value & "") & "','" & _
                                 (grdacc.Item(1, grdacc.CurrentRow.Index).Value & "") & _
                                "'," & (grdacc.Item(2, grdacc.CurrentRow.Index).Value & "") & _
                                 ",'" & cbccard.SelectedValue & "',0)"
                        cmd.ExecuteNonQuery()

                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.Rows.Add()
                        grdacc.Focus()
                        populate()

                    Case 0 '  NO
                        grdacc.CurrentCell.Value = gridctrl.Text
                        gridctrl.Visible = False
                        grdacc.Enabled = True
                        grdacc.CurrentCell = grdacc.Item(1, grdacc.CurrentRow.Index)
                        editgrid()
                    Case 1  ' DT 
                        If DateCheck(gridctrl, False) Then

                            dtf1 = CDate("01/" & dtp.Value.Date.Month & "/" & dtp.Value.Date.Year)
                            dtt1 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf1))

                            If CDate(gridctrl.Text) < dtf1 Or CDate(gridctrl.Text) > dtt1 Then
                                MsgBox("Bill date is not in selected Month.", MsgBoxStyle.Information)
                                gridctrl.Focus()

                                Exit Sub
                            End If

                            cmd.CommandText = "Select settled,rmk  " & _
                                         " from cardsales WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                                        " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "') and settled=1 order by billdt,id"
                            rdr = cmd.ExecuteReader
                            If rdr.HasRows Then
                                MsgBox("Month already settled.")
                                Exit Sub
                            End If


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

    Private Sub grdacc_CellDoubleClick() Handles grdacc.CellDoubleClick
        If cbccard.Text = "" Then Exit Sub
        editgrid()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub grdacc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdacc.KeyDown
        Try
            Dim CMD As New OleDb.OleDbCommand

            If e.KeyCode = Keys.Enter Then

                grdacc_CellDoubleClick()

                e.Handled = True
            End If
            If e.KeyCode = Keys.Delete Then
                CMD.Connection = Conn
                If MsgBox("Want to Delete the Selected Entry ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2) = MsgBoxResult.No Then Exit Sub
                CMD.CommandText = "DELETE CARDSALES WHERE ID=" & Val(grdacc.Item(3, grdacc.CurrentRow.Index).Value & "")
                CMD.ExecuteNonQuery()
                populate()

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

    Private Sub txtccard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtccard.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub


    Private Sub txtccard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtccard.TextChanged
      
    End Sub

    Private Sub cbccard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbccard.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbccard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbccard.KeyPress

    End Sub

    Private Sub cbccard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbccard.TextChanged
       
    End Sub
   
     

    Private Sub cbccard_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbccard.SelectedIndexChanged
        txtccard.Tag = "Y"
        txtccard.Text = cbccard.SelectedValue
        txtccard.Tag = ""
        populate()
    End Sub

 
    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp.ValueChanged
        populate()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim dtt1, dtf1, dtv As Date
        Dim cmd As New OleDb.OleDbCommand
       


        dtf1 = CDate("01/" & dtp.Value.Date.Month & "/" & dtp.Value.Date.Year)

        dtv = CDate("01/" & Now.Date.Month & "/" & Now.Date.Year)
        If chk.Checked Then
            If dtv = dtf1 Then
                MsgBox("Can't Settle Current Month data. ")
                Exit Sub

            End If
        End If
        dtt1 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf1))


        cmd.Connection = Conn
        If chk.Checked Then
            cmd.CommandText = "UPDATE cardsales set settled =1,rmk=""" & txtrmk.Text & """ WHERE  cardno = '" & cbccard.SelectedValue & "' and " & _
                     " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  "
            cmd.ExecuteNonQuery()
            populate()

        Else
            cmd.CommandText = "UPDATE cardsales set settled =0,rmk=""" & txtrmk.Text & """ WHERE cardno = '" & cbccard.SelectedValue & "' and " & _
                     " billdt >= convert(datetime,'" & dtf1 & "') AND billdt <= convert(datetime,'" & dtt1 & "')  "
            cmd.ExecuteNonQuery()
            populate()
        End If

        ' clearform()

    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        clearform()
    End Sub

    Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk.CheckedChanged
        If chk.Checked Then
            If txtrmk.Text = "" Then

                txtrmk.Text = "Settled"

            End If
        Else
            txtrmk.Text = ""
        End If
    End Sub

    Private Sub gridctrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridctrl.KeyUp

    End Sub

    Private Sub gridctrl_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles gridctrl.MaskInputRejected

    End Sub

    Private Sub txtccard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtccard.Validating
        Try
            If txtccard.Tag = "Y" Then Exit Sub
            If txtccard.Text = "" Then
                cbccard.Text = ""
                txtccard.Tag = "Y"
                txtccard.Text = ""
                cbccard.SelectedValue = 0
                txtccard.Tag = ""
                Exit Sub
            End If

            cbccard.SelectedValue = Val(txtccard.Text)
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub grdacc_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdacc.CellContentClick

    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        populate()
    End Sub
End Class