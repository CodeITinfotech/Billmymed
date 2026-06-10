Public Class PRSettlement

    Private Sub PRSettlement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearform()
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.Wheat
        ToolStrip.Renderer = renderer
        'Prgrid.Rows.Add()
    End Sub

    Private Sub clearform()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim DS As New DataSet
            Me.Cursor = Cursors.WaitCursor
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
            Prgrid.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Prgrid.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Prgrid.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Prgrid.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Prgrid.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Prgrid.Columns(17).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            lblmrpv.Text = ""
            GetGrandTotal()
            lblflt.Text = ""
            Me.Cursor = Cursors.Default
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Sub

    Private Sub suppliercombo_Click(sender As Object, e As System.EventArgs) Handles suppliercombo.Click

    End Sub

    Private Sub suppliercombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles suppliercombo.SelectedIndexChanged
        suppliercombo.DroppedDown = False
        populate()

    End Sub

    Private Sub populate()
        Dim command As New Data.OleDb.OleDbCommand
        Dim reader As Data.OleDb.OleDbDataReader
        Dim i As Integer = 0
        Dim j As Integer
        Dim bl As Integer
        Try

            Prgrid.Rows.Clear()
            If suppliercombo.SelectedValue = 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            command.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "Select_PurRtnSettlement"

            If Chkhide.Checked = True Then
                command.Parameters.Add("@chkhide", OleDb.OleDbType.Integer).Value = 1
            ElseIf Chkhide.Checked = False Then
                command.Parameters.Add("@chkhide", OleDb.OleDbType.Integer).Value = 0
            End If


            command.Parameters.Add("@suppliercode", OleDb.OleDbType.Integer).Value = suppliercombo.SelectedValue

            If chkfilter.Checked = True Then
                command.Parameters.Add("@flt", OleDb.OleDbType.Integer).Value = 1
            ElseIf chkfilter.Checked = False Then
                command.Parameters.Add("@flt", OleDb.OleDbType.Integer).Value = 0
            End If
            command.Parameters.Add("@dtf", OleDb.OleDbType.Date).Value = CDate(dtfrm.Value.Date)
            command.Parameters.Add("@dtt", OleDb.OleDbType.Date).Value = CDate(dtto.Value.Date)


            reader = command.ExecuteReader
            Prgrid.SuspendLayout()
            Prgrid.Visible = False
            While reader.Read
                Prgrid.Rows.Add()
                If reader.Item("settled") = "False" Then
                    Prgrid.Item(0, i).Value = "No"
                ElseIf reader.Item("settled") = "True" Then
                    Prgrid.Item(0, i).Value = "Yes"
                End If

                Prgrid.Item(1, i).Value = reader.Item("prno")
                Prgrid.Item(2, i).Value = reader.Item("prdt")
                Prgrid.Item(3, i).Value = reader.Item("prdname")
                Prgrid.Item(4, i).Value = reader.Item("batch")
                Prgrid.Item(5, i).Value = reader.Item("exdt")
                Prgrid.Item(6, i).Value = reader.Item("rate")
                Prgrid.Item(7, i).Value = reader.Item("brqty")
                Prgrid.Item(8, i).Value = reader.Item("exqty")
                Prgrid.Item(9, i).Value = reader.Item("pack")
                Prgrid.Item(10, i).Value = reader.Item("value")
                Prgrid.Item(11, i).Value = reader.Item("adjamt")
                Prgrid.Item(12, i).Value = reader.Item("crnoteno")
                Prgrid.Item(13, i).Value = reader.Item("crnotedt")
                Prgrid.Item(14, i).Value = reader.Item("adjbillno")
                Prgrid.Item(15, i).Value = reader.Item("adjbilldt")
                Prgrid.Item(16, i).Value = reader.Item("remark")
                Prgrid.Item(17, i).Value = ""
                Prgrid.Item(18, i).Value = reader.Item("prid")
                i += 1

            End While
            Prgrid.ResumeLayout()
            Prgrid.Visible = True
            For j = 0 To Prgrid.Rows.Count - 1
                If Prgrid.Item(0, j).Value = "No" Then
                    bl = bl + Prgrid.Item(10, j).Value
                End If

                If Prgrid.Item(0, j).Value = "Yes" Then
                    For c = 0 To Prgrid.Columns.Count - 1
                        Prgrid.Item(c, j).Style.ForeColor = Color.Blue

                    Next
                End If

                If Prgrid.Item(12, j).Value & "" <> "" Then
                    Prgrid.Item(17, j).Value = Format(Val(Prgrid.Item(11, j).Value) * 100 / Prgrid.Item(10, j).Value, "0.00")
                End If
            Next


            lblbalval.Text = Format(bl, "0.00")
            Me.Cursor = Cursors.Default
        Finally
            If chkfilter.Checked Then
                lblflt.Visible = True
                lblflt.Text = "(Filtered.. )"
            Else
                lblflt.Visible = False
                lblflt.Text = ""
            End If
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Prgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prgrid.DoubleClick
        editgrid()
    End Sub

    Private Sub Prgrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Prgrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            editgrid()
            e.Handled = True
        End If
    End Sub

    Private Sub editgrid()
        Dim settled As Integer
        Dim n As Integer
        Dim command As New OleDb.OleDbCommand
        command.Connection = Conn

        If Prgrid.CurrentRow.Index >= 0 And Prgrid.CurrentRow.Index < Prgrid.Rows.Count - 1 Then

            If Prgrid.CurrentCell.ColumnIndex >= 11 And Prgrid.CurrentCell.ColumnIndex < 17 Then
                If Prgrid.CurrentCell.ColumnIndex = 13 Or Prgrid.CurrentCell.ColumnIndex = 15 Then
                    gridctrl.Mask = DateMask

                    gridctrl.PromptChar = "_"
                Else
                    gridctrl.Mask = ""
                    'gridctrl.TextMaskFormat = ""
                    gridctrl.PromptChar = " "
                End If

                gridctrl.Top = Prgrid.Top + Prgrid.GetRowDisplayRectangle(Prgrid.CurrentCell.RowIndex, True).Top
                gridctrl.Left = Prgrid.Left + Prgrid.GetColumnDisplayRectangle(Prgrid.CurrentCell.ColumnIndex, True).Left
                gridctrl.Width = Prgrid.GetColumnDisplayRectangle(Prgrid.CurrentCell.ColumnIndex, True).Width
                Prgrid.Enabled = False

                Chkhide.Enabled = False
                gridctrl.Visible = True

                If Prgrid.CurrentCell.ColumnIndex = 13 Or Prgrid.CurrentCell.ColumnIndex = 15 Then
                    If IsDate(Prgrid.Item(Prgrid.CurrentCell.ColumnIndex, Prgrid.CurrentRow.Index).Value & "") Then
                        gridctrl.Text = (Prgrid.Item(Prgrid.CurrentCell.ColumnIndex, Prgrid.CurrentRow.Index).Value)
                    Else
                        gridctrl.Text = "__/__/__"
                    End If
                Else
                    'If Prgrid.CurrentCell.ColumnIndex = 12 Or Prgrid.CurrentCell.ColumnIndex = 14 Then gridctrl.MaxLength = 10
                    gridctrl.Text = Prgrid.Item(Prgrid.CurrentCell.ColumnIndex, Prgrid.CurrentRow.Index).Value & ""
                End If
                Prgrid.Enabled = False
                Application.DoEvents()
                gridctrl.Focus()

            End If




            If Prgrid.CurrentCell.ColumnIndex = 0 Then
                If Prgrid.Item(0, Prgrid.CurrentRow.Index).Value = "Yes" Then
                    command.CommandText = "select settled from purchasereturn where prid=" & Prgrid.Item(18, Prgrid.CurrentRow.Index).Value & ""
                    settled = command.ExecuteScalar

                    If settled Then
                        If MsgBox("Previously settled. Want to change it..?", vbYesNo + vbQuestion) = vbNo Then
                            Exit Sub
                        End If
                        Prgrid.Item(0, Prgrid.CurrentRow.Index).Value = "No"
                    Else
                        Prgrid.Item(0, Prgrid.CurrentRow.Index).Value = "No"
                    End If


                    For n = 0 To Prgrid.Columns.Count - 1
                        Prgrid.Item(n, Prgrid.CurrentCell.RowIndex).Style.ForeColor = Color.Black

                    Next n

                Else
                    Prgrid.Item(0, Prgrid.CurrentRow.Index).Value = "Yes"

                    For n = 0 To Prgrid.Columns.Count - 1
                        Prgrid.Item(n, Prgrid.CurrentCell.RowIndex).Style.ForeColor = Color.Red

                    Next n

                End If
                Dim mrpval As Integer = 0
                Dim rs As Decimal
                For n = 0 To Prgrid.Rows.Count - 2
                    If Prgrid.Item(0, n).Value = "Yes" Then
                        command.CommandText = "select srate*(exqty+brqty) from purchaseReturn  where prid=" & Prgrid.Item(18, n).Value & ""

                        rs = command.ExecuteScalar
                        If rs <> 0 Then
                            mrpval = mrpval + Val(rs & "")
                        End If
                    End If
                Next n
                lblmrpv.Text = "Settled MRP Value : " & Format(mrpval, "0.00")
                lblmrpv.Visible = True
                Prgrid.Columns(0).Selected = True
                Prgrid.Focus()

            End If
        End If
    End Sub

    Private Sub Prgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Prgrid.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        '    editgrid()
        'End If
    End Sub



    Private Sub Prgrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Prgrid.KeyUp

        Dim command As New OleDb.OleDbCommand
        Dim command1 As New OleDb.OleDbCommand

        Dim rstmp1 As Integer
        Dim reader As OleDb.OleDbDataReader

        If e.KeyCode = 46 And Prgrid.CurrentRow.Index < Prgrid.Rows.Count - 1 Then
            command.Connection = Conn

            command.CommandText = "select * from purchasereturn where prid=" & Prgrid.Item(18, Prgrid.CurrentRow.Index).Value & ""
            reader = command.ExecuteReader
            If reader.HasRows Then

                reader.Read()
                command1.Connection = Conn
                command1.CommandText = "select batchid from batch where batchid=" & reader("batchid") & ""
                rstmp1 = command1.ExecuteScalar
                If rstmp1 = 0 Then
                    MsgBox("Batch Record not found.. Can't Delete.")
                    Exit Sub
                End If

                If MsgBox("Want to delete the record..? ", vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then Exit Sub
                command.CommandText = "update batch set stock=stock+" & reader("exqty") & ",brkqty=brkqty+" & reader("Brqty") & " where batchid=" & reader("batchid")
                reader.Close()
                command.ExecuteNonQuery()

                command.CommandText = "delete from purchasereturn where prid=" & Prgrid.Item(18, Prgrid.CurrentRow.Index).Value & ""

                command.ExecuteNonQuery()

                Prgrid.Rows.RemoveAt(Prgrid.CurrentRow.Index)

            End If
            Prgrid.Focus()

        End If
    End Sub

    Private Sub GetGrandTotal()
        'grtot = ab2.OpenRecordset("Select format(sum((purchasereturn.brqty + purchasereturn.exqty)* " & _
        '    "purchasereturn.rate),'0.00') as gtot from purchasereturn where not settled")
        Dim command As New OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        command.Connection = Conn
        command.CommandType = CommandType.Text
        command.CommandText = "select sum((exqty+brqty)*rate) from PurchaseReturn where settled=0 "
        lblgrandval.Text = Format(Val(command.ExecuteScalar & ""), "0.00")

    End Sub

    Private Sub Chkhide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkhide.Click
        populate()
    End Sub

    Private Sub Prgrid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Prgrid.PreviewKeyDown
        'editgrid()
    End Sub

    Private Sub gridctrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.GotFocus
        gridctrl.SelectAll()
    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress

        If e.KeyChar = Chr(13) Then
            Select Case Prgrid.CurrentCell.ColumnIndex
                Case 11 'ADJ AMT
                    Dim per As Double

                    If Val(gridctrl.Text) <> 0 Then
                        Prgrid.CurrentCell.Value = Format(Val(gridctrl.Text), "0.00")

                        per = Val(Prgrid.Item(10, Prgrid.CurrentRow.Index).Value & "")

                        per = Val(gridctrl.Text) * 100 / Val(Prgrid.Item(10, Prgrid.CurrentRow.Index).Value & "")
                        Prgrid.Item(17, Prgrid.CurrentRow.Index).Value = Format(per, "0.00")
                    Else
                        Prgrid.Item(17, Prgrid.CurrentRow.Index).Value = ""
                    End If
                    gridctrl.Visible = False
                    Prgrid.Enabled = True
                    Prgrid.Focus()

                Case 12 ' CRNO
                    Prgrid.CurrentCell.Value = gridctrl.Text
                    gridctrl.Visible = False
                    Prgrid.Enabled = True
                    Prgrid.Focus()

                Case 13  'CRDT 
                    If DateCheck(gridctrl, True) Then
                        Prgrid.CurrentCell.Value = gridctrl.Text

                        gridctrl.Visible = False
                        Prgrid.Enabled = True
                        Prgrid.Focus()
                    Else
                        gridctrl.Focus()
                    End If


                Case 14 'BNO
                    Prgrid.CurrentCell.Value = gridctrl.Text
                    gridctrl.Visible = False
                    Prgrid.Enabled = True
                    Prgrid.Focus()

                Case 15 'BDT
                    If DateCheck(gridctrl, True) Then
                        Prgrid.CurrentCell.Value = gridctrl.Text

                        gridctrl.Visible = False
                        Prgrid.Enabled = True
                        Prgrid.Focus()
                    Else
                        gridctrl.Focus()
                    End If

                Case 16 'RMK
                    Prgrid.CurrentCell.Value = gridctrl.Text
                    gridctrl.Visible = False
                    Prgrid.Enabled = True
                    Prgrid.Focus()


            End Select
        ElseIf e.KeyChar = Chr(27) Then

            ' Prgrid.CurrentCell.Value = gridctrl.Text
            gridctrl.Visible = False
            Prgrid.Enabled = True
            Prgrid.Focus()

        End If
    End Sub

    Private Sub tbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Me.Cursor = Cursors.WaitCursor
        Save()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Save()
        Dim i, st As Integer

        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Update_PurchaseRtn"
        cmd.Parameters.Add("@settled", OleDb.OleDbType.Boolean)
        cmd.Parameters.Add("@remarks", OleDb.OleDbType.VarChar)
        cmd.Parameters.Add("@adjamt", OleDb.OleDbType.Numeric)
        cmd.Parameters.Add("@crnoteno", OleDb.OleDbType.VarChar)
        cmd.Parameters.Add("@crnotedt", OleDb.OleDbType.DBDate)
        cmd.Parameters.Add("@adjbillno", OleDb.OleDbType.VarChar)
        cmd.Parameters.Add("@adjbilldt", OleDb.OleDbType.DBDate)
        cmd.Parameters.Add("@prid", OleDb.OleDbType.BigInt)
        cmd.Parameters.Add("@sysdt", OleDb.OleDbType.DBDate)

        For i = 0 To Prgrid.Rows.Count - 2
            st = 0
            If Prgrid.Item(0, i).Value & "" = "Yes" Then
                st = 1
            End If
            cmd.Parameters(0).Value = st
            cmd.Parameters(1).Value = Prgrid.Item(16, i).Value & ""
            cmd.Parameters(2).Value = Val(Prgrid.Item(11, i).Value & "")
            cmd.Parameters(3).Value = Prgrid.Item(12, i).Value & ""

            If IsDate(Prgrid.Item(13, i).Value & "") Then
                cmd.Parameters(4).Value = Prgrid.Item(13, i).Value & ""
            Else
                cmd.Parameters(4).Value = DBNull.Value
            End If
            cmd.Parameters(5).Value = Prgrid.Item(14, i).Value & ""
            If IsDate(Prgrid.Item(15, i).Value & "") Then
                cmd.Parameters(6).Value = Prgrid.Item(15, i).Value & ""
            Else
                cmd.Parameters(6).Value = DBNull.Value
            End If
            cmd.Parameters(7).Value = Val(Prgrid.Item(18, i).Value & "")
            cmd.Parameters(8).Value = SysDt
            cmd.ExecuteNonQuery()
        Next
        populate()
    End Sub

    Private Sub chkfilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfilter.CheckedChanged
        pnl.Visible = chkfilter.Checked
        If Not chkfilter.Checked Then
            populate()
        End If
    End Sub

    Private Sub Show1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        BtnShow.Tag = "Y"
        populate()
        BtnShow.Tag = ""
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        clearform()
    End Sub
 

    
End Class