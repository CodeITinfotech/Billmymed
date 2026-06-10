Public Class ProductGrouping
    Private EdCol As Integer
    Private EdRow As Integer

    Private Sub ClearForm()
        'Dim cmd As New OleDb.OleDbCommand
        ''Dim i As Integer
        'Dim DA As New OleDb.OleDbDataAdapter
        'Dim DS As New DataSet
        'Dim dt1 As New DataTable
        Try
            cbGroup.Items.Clear()
            cbGroup.Items.Add("Company")
            cbGroup.Items.Add("Classification")
            cbGroup.Items.Add("Product Group1")
            cbGroup.Items.Add("Product Group2")
            cbGroup.Items.Add("Tax")
            cbGroup.Items.Add("Rack")
            lstgrp.Items.Clear()
            DgProdSer.DataSource = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbGroup_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbGroup.SelectedValueChanged
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        cmd.Connection = Conn
        Try
            If cbGroup.Text = "Company" Then
                ChkProdall.Text = "All Company"
                'cmd.CommandText = "select comcode,comname from Company order by comname"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Company")
                'cbMaster.DisplayMember = "comName"
                'cbMaster.ValueMember = "comCode"
                'cbMaster.DataSource = DS.Tables("Company")
                'cbMaster.SelectedValue = 0
                cmd.CommandText = "Select comCode,comName  from company order by comname"
                dataredr = cmd.ExecuteReader()
                lstgrp.Items.Clear()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("ComName"), dataredr.Item("Comcode")))
                        'lstcom.SetItemChecked(lstcom.Items.Count -1,t  
                    Loop
                End If
                dataredr.Close()
                ChkProdall.Checked = True
            ElseIf cbGroup.Text = "Classification" Then
                ChkProdall.Text = "All Classification"
                'cmd.CommandText = "select clscode,clsname from Classification order by clsname"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Classification")
                'cbMaster.DisplayMember = "clsName"
                'cbMaster.ValueMember = "clscode"
                'cbMaster.DataSource = DS.Tables("Classification")
                'cbMaster.SelectedIndex = -1
                cmd.CommandText = "Select clsCode,clsName from Classification order by clsName"
                dataredr = cmd.ExecuteReader()
                lstgrp.Items.Clear()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("ClsName"), dataredr.Item("Clscode")))
                    Loop
                End If
                dataredr.Close()
                ChkProdall.Checked = True
            ElseIf cbGroup.Text = "Product Group1" Then
                ChkProdall.Text = "All Product Group1"
                'cmd.CommandText = "select prgrp1code,PrGrp1name from PrGroup1 order by PrGrp1name"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Grp1")
                'cbMaster.DisplayMember = "PrGrp1Name"
                'cbMaster.ValueMember = "PrGrp1code"
                'cbMaster.DataSource = DS.Tables("Grp1")
                'cbMaster.SelectedIndex = -1

                cmd.CommandText = "Select PrGrp1Code,PrGrp1Name from PrGroup1 order by PrGrp1name"
                dataredr = cmd.ExecuteReader()
                lstgrp.Items.Clear()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("PrGrp1Name"), dataredr.Item("PrGrp1Code")))
                    Loop
                End If
                dataredr.Close()
                ChkProdall.Checked = True
            ElseIf cbGroup.Text = "Product Group2" Then
                ChkProdall.Text = "All Product Group2"
                'cmd.CommandText = "select Prgrp2code,PrGrp2name from PrGroup2 order by PrGrp2name"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Grp2")
                'cbMaster.DisplayMember = "PrGrp2Name"
                'cbMaster.ValueMember = "PrGrp2code"
                'cbMaster.DataSource = DS.Tables("Grp2")
                'cbMaster.SelectedIndex = -1

                lstgrp.Items.Clear()
                cmd.CommandText = "Select PrGrp2Code,PrGrp2Name from PrGroup2 order by PrGrp2name"
                dataredr = cmd.ExecuteReader()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("PrGrp2Name"), dataredr.Item("PrGrp2Code")))
                    Loop
                End If

                dataredr.Close()
                ChkProdall.Checked = True
            ElseIf cbGroup.Text = "Tax" Then
                ChkProdall.Text = "All Tax"
                'cmd.CommandText = "select taxper,accode from tax where flag='31'"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Tax")
                'cbMaster.DisplayMember = "taxper"
                'cbMaster.ValueMember = "accode"
                'cbMaster.DataSource = DS.Tables("Tax")
                'cbMaster.SelectedIndex = -1
                lstgrp.Items.Clear()
                cmd.CommandText = "select taxper,accode from tax where flag='31'"
                dataredr = cmd.ExecuteReader()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("taxper"), dataredr.Item("accode")))
                    Loop
                End If

                dataredr.Close()
                ChkProdall.Checked = True
            ElseIf cbGroup.Text = "Rack" Then
                ChkProdall.Text = "All Rack"
                'cmd.CommandText = "select name,Code from Racks order by name"
                'DA.SelectCommand = cmd
                'DA.Fill(DS, "Rack")
                'cbMaster.DisplayMember = "name"
                'cbMaster.ValueMember = "Code"
                'cbMaster.DataSource = DS.Tables("Rack")
                'cbMaster.SelectedIndex = -1
                lstgrp.Items.Clear()
                cmd.CommandText = "select name,Code from Racks order by name"
                dataredr = cmd.ExecuteReader()
                ChkProdall.Checked = False
                If dataredr.HasRows Then
                    Do While dataredr.Read()
                        lstgrp.Items.Add(New MyList(dataredr.Item("name"), dataredr.Item("Code")))
                    Loop
                End If

                dataredr.Close()
                ChkProdall.Checked = True
            End If
            'If Me.Tag = "BatchGrp" Then

            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetProductDetails()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim tmpStr As String
        Dim mList As MyList
        Dim j As Integer = 0
        cmd.Connection = Conn

        If cbGroup.Text = "" Then
            MsgBox("Please Select Group", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        DgProdSer.DataSource = Nothing
        If cbGroup.Text = "Company" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.ItemData & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = tmpStr
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = ""

            DA.SelectCommand = cmd
            DA.Fill(DS, "Product")

            DgProdSer.DataSource = DS.Tables("Product")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next
            'DgProdSer.
            'DgProdSer.Columns(7).Visible = False
            'DgProdSer.Columns(8).Visible = False
            'DgProdSer.Columns(9).Visible = False
            'DgProdSer.Columns(10).Visible = False
            'DgProdSer.Columns(11).Visible = False
            'DgProdSer.Columns(12).Visible = False
        ElseIf cbGroup.Text = "Classification" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.ItemData & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = tmpStr
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = ""

            DA.SelectCommand = cmd
            DA.Fill(DS, "Product")

            DgProdSer.DataSource = DS.Tables("Product")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next
            'DgProdSer.Columns(7).Visible = False
            'DgProdSer.Columns(8).Visible = False
            'DgProdSer.Columns(9).Visible = False
            'DgProdSer.Columns(10).Visible = False
            'DgProdSer.Columns(11).Visible = False
            'DgProdSer.Columns(12).Visible = False
        ElseIf cbGroup.Text = "Product Group1" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.ItemData & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = tmpStr
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = ""

            DA.SelectCommand = cmd
            DA.Fill(DS, "Product")

            DgProdSer.DataSource = DS.Tables("Product")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next
            'DgProdSer.Columns(7).Visible = False
            'DgProdSer.Columns(8).Visible = False
            'DgProdSer.Columns(9).Visible = False
            'DgProdSer.Columns(10).Visible = False
            'DgProdSer.Columns(11).Visible = False
            'DgProdSer.Columns(12).Visible = False
        ElseIf cbGroup.Text = "Product Group2" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.ItemData & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = tmpStr
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = ""

            DA.SelectCommand = cmd
            DA.Fill(DS, "Product")

            DgProdSer.DataSource = DS.Tables("Product")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next
            'DgProdSer.Columns(7).Visible = False
            'DgProdSer.Columns(8).Visible = False
            'DgProdSer.Columns(9).Visible = False
            'DgProdSer.Columns(10).Visible = False
            'DgProdSer.Columns(11).Visible = False
            'DgProdSer.Columns(12).Visible = False
        ElseIf cbGroup.Text = "Tax" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.Name & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = tmpStr
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = ""

            DA.SelectCommand = cmd
            DA.Fill(DS, "Tax")

            DgProdSer.DataSource = DS.Tables("Tax")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next
        ElseIf cbGroup.Text = "Rack" Then
            tmpStr = ";"
            For i = 0 To lstgrp.Items.Count - 1
                If lstgrp.GetItemChecked(i) = True Then
                    mList = lstgrp.Items(i)
                    tmpStr = tmpStr & mList.Name & ";"
                End If
            Next
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetProductGrpwise"
            cmd.Parameters.Add("@CompCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@ClsCode", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp1", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Grp2", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@Tax", OleDb.OleDbType.VarChar).Value = ""
            cmd.Parameters.Add("@RackNo", OleDb.OleDbType.VarChar).Value = tmpStr

            DA.SelectCommand = cmd
            DA.Fill(DS, "Rack")

            DgProdSer.DataSource = DS.Tables("Rack")

            For Each row In DgProdSer.Rows
                DgProdSer.Rows(j).HeaderCell.Value = (1 + j).ToString
                j += 1
            Next

        End If
        DgProdSer.Columns(0).Width = 170
        DgProdSer.Columns(1).Width = 60
        DgProdSer.Columns(2).Width = 170
        DgProdSer.Columns(9).Visible = False
        DgProdSer.Columns(8).Visible = False
        DgProdSer.Columns(9).Visible = False
        DgProdSer.Columns(10).Visible = False
        DgProdSer.Columns(11).Visible = False
        DgProdSer.Columns(12).Visible = False
        DgProdSer.Columns(13).Visible = False

        If DgProdSer.Rows.Count > 0 Then
            DgProdSer.Enabled = True
        End If
    End Sub

 

    Private Sub EditGrid()

        DgProdSer.Enabled = False
        'Dim cntrol As Object
        Try
            EdCol = DgProdSer.CurrentCell.ColumnIndex
            EdRow = DgProdSer.CurrentCell.RowIndex
            DgProdSer.CurrentCell = DgProdSer.Item(EdCol, EdRow)
        Catch
            Exit Sub
        End Try

        Try
            If IsNothing(DgProdSer.CurrentCell) Then Exit Sub

            Select Case DgProdSer.CurrentCell.ColumnIndex
                Case 2, 3, 4, 5, 6, 7

                    FillComboEdit()
                    ShowEditControl(cbEdit)
                    'Case Else
                    '    ShowEditControl(cbEdit)
            End Select

        Catch
            Exit Sub
        End Try


    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Dim WD As Integer
        Try
            WD = 0
            cntrol.Location = DgProdSer.Location
            cntrol.top = DgProdSer.Top
            cntrol.left = DgProdSer.Left
            cntrol.top = DgProdSer.Top + DgProdSer.GetRowDisplayRectangle(DgProdSer.CurrentCell.RowIndex, True).Top
            cntrol.left = DgProdSer.Left + DgProdSer.GetColumnDisplayRectangle(DgProdSer.CurrentCell.ColumnIndex, True).Left
            cntrol.width = DgProdSer.GetColumnDisplayRectangle(DgProdSer.CurrentCell.ColumnIndex, True).Width
            cntrol.Text = DgProdSer.CurrentCell.Value & ""
            DgProdSer.Enabled = False
            cntrol.Visible = True
            cntrol.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub FillComboEdit()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cbEdit.DataSource = Nothing

        Select Case DgProdSer.CurrentCell.ColumnIndex
            Case 2
                cmd.CommandText = "select comcode,comname from Company order by comname"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Company")
                cbEdit.DisplayMember = "comName"
                cbEdit.ValueMember = "comCode"
                cbEdit.DataSource = DS.Tables("Company")
                cbEdit.SelectedValue = DgProdSer.Item(9, DgProdSer.CurrentCell.RowIndex).Value
            Case 3
                cmd.CommandText = "select clscode,clsname from Classification order by clsname"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Classification")
                cbEdit.DisplayMember = "clsName"
                cbEdit.ValueMember = "clscode"
                cbEdit.DataSource = DS.Tables("Classification")
                cbEdit.SelectedValue = DgProdSer.Item(10, DgProdSer.CurrentCell.RowIndex).Value
            Case 4
                cmd.CommandText = "select prgrp1code,PrGrp1name from PrGroup1 order by PrGrp1name"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Grp1")
                cbEdit.DisplayMember = "PrGrp1Name"
                cbEdit.ValueMember = "PrGrp1code"
                cbEdit.DataSource = DS.Tables("Grp1")
                cbEdit.SelectedValue = DgProdSer.Item(11, DgProdSer.CurrentCell.RowIndex).Value
            Case 5
                cmd.CommandText = "select Prgrp2code,PrGrp2name from PrGroup2 order by PrGrp2name"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Grp2")
                cbEdit.DisplayMember = "PrGrp2Name"
                cbEdit.ValueMember = "PrGrp2code"
                cbEdit.DataSource = DS.Tables("Grp2")
                cbEdit.SelectedValue = DgProdSer.Item(12, DgProdSer.CurrentCell.RowIndex).Value
            Case 6
                cmd.CommandText = "select taxper,accode from tax where flag='31'"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Tax")
                cbEdit.DisplayMember = "taxper"
                cbEdit.ValueMember = "accode"
                cbEdit.DataSource = DS.Tables("Tax")
                cbEdit.Text = DgProdSer.Item(6, DgProdSer.CurrentCell.RowIndex).Value
            Case 7
                cmd.CommandText = "select name,Code from Racks order by name"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Rack")
                cbEdit.DisplayMember = "name"
                cbEdit.ValueMember = "Code"
                cbEdit.DataSource = DS.Tables("Rack")
                cbEdit.Text = DgProdSer.Item(7, DgProdSer.CurrentCell.RowIndex).Value
        End Select
    End Sub

   

    Private Sub DgProdSer_DoubleClick(sender As Object, e As System.EventArgs) Handles DgProdSer.DoubleClick

        Select Case DgProdSer.CurrentCell.ColumnIndex
            Case 2, 3, 4, 5, 6, 7
                EditGrid()
        End Select

    End Sub

    Private Sub DgProdSer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DgProdSer.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case DgProdSer.CurrentCell.ColumnIndex
                    Case 2, 3, 4, 5, 6, 7, 10
                        e.Handled = True
                        EditGrid()
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbEdit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbEdit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case DgProdSer.CurrentCell.ColumnIndex
                    Case 2
                        If cbEdit.SelectedIndex > -1 Then
                            DgProdSer.Item(10, DgProdSer.CurrentCell.RowIndex).Value = cbEdit.SelectedValue
                            DgProdSer.CurrentCell.Value = cbEdit.Text
                        Else
                            MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Case 3
                        If cbEdit.SelectedIndex > -1 Then
                            DgProdSer.Item(11, DgProdSer.CurrentCell.RowIndex).Value = cbEdit.SelectedValue
                            DgProdSer.CurrentCell.Value = cbEdit.Text
                        Else
                            MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Case 4
                        If cbEdit.SelectedIndex > -1 Then
                            DgProdSer.Item(12, DgProdSer.CurrentCell.RowIndex).Value = cbEdit.SelectedValue
                            DgProdSer.CurrentCell.Value = cbEdit.Text
                        Else
                            MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Case 5
                        If cbEdit.SelectedIndex > -1 Then
                            DgProdSer.Item(13, DgProdSer.CurrentCell.RowIndex).Value = cbEdit.SelectedValue
                            DgProdSer.CurrentCell.Value = cbEdit.Text
                        Else
                            MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Case 6
                        If cbEdit.SelectedIndex > -1 Then
                            DgProdSer.CurrentCell.Value = cbEdit.Text
                        Else
                            MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If

                        If chkChangForAll.Checked = True Then
                            For i = 0 To DgProdSer.Rows.Count - 1
                                DgProdSer.Item(6, i).Value = Val(cbEdit.Text)
                            Next
                        End If
                    Case 7
                        'If cbEdit.SelectedIndex > -1 Then
                        '    DgProdSer.CurrentCell.Value = cbEdit.Text
                        'Else
                        '    MsgBox("Please Select Item", MsgBoxStyle.Exclamation)
                        '    Exit Sub
                        'End If
                        DgProdSer.CurrentCell.Value = cbEdit.Text
                        If chkChangForAll.Checked = True Then
                            For i = 0 To DgProdSer.Rows.Count - 1
                                DgProdSer.Item(7, i).Value = cbEdit.Text
                            Next
                        End If
                End Select

                cbEdit.Visible = False
                DgProdSer.Enabled = True
                DgProdSer.Focus()
                e.Handled = True
            End If

            
            If e.KeyCode = Keys.Escape Then
                cbEdit.Visible = False
                DgProdSer.Enabled = True
                DgProdSer.Focus()
                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim dt1 As New DataTable

        cmd.Connection = Conn
        Try
            Me.Cursor = Cursors.WaitCursor
            For i = 0 To DgProdSer.Rows.Count - 1
                If IsNothing(DgProdSer.Item(8, i).Value) = False Then
                    cmd.CommandText = "Update product set Comcode =" & DgProdSer.Item(10, i).Value & ",clscode=" & DgProdSer.Item(11, i).Value & _
                            ",PrGrp1Code=" & DgProdSer.Item(12, i).Value & ",PrGrp2Code=" & DgProdSer.Item(13, i).Value & ",st =" & Val(DgProdSer.Item(6, i).Value) & _
                            ", RackNo =""" & DgProdSer.Item(7, i).Value & _
                            """ Where PrdCode =""" & DgProdSer.Item(8, i).Value & """"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Update Batch set Stax =" & Val(DgProdSer.Item(6, i).Value) & " Where PrdCode =""" & DgProdSer.Item(8, i).Value & """"
                    cmd.ExecuteNonQuery()
                End If
            Next

            If cbGroup.SelectedIndex > -1 Then
                'If lstgrp.SelectedIndex > -1 Then
                GetProductDetails()
                'End If
            End If
            Me.Cursor = Cursors.Default
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub ProductGrouping_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer

        ClearForm()
    End Sub

    Private Sub tsbCls_Click(sender As System.Object, e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(sender As System.Object, e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    
    
    Private Sub ChkProdall_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkProdall.CheckedChanged
        If ChkProdall.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstgrp.Items.Count - 1
            lstgrp.Tag = "Y"
            lstgrp.SetItemChecked(i, (ChkProdall.Checked))
            lstgrp.Tag = ""
        Next
    End Sub

    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click
        Try
            'If lstgrp.SelectedIndex > -1 Then

            GetProductDetails()
            'Else
            ''DgProdSer.Rows.Clear()
            'DgProdSer.DataSource = Nothing
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstgrp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstgrp.SelectedIndexChanged

    End Sub

    Private Sub cbEdit_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbEdit.SelectedIndexChanged

    End Sub

    Private Sub DgProdSer_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub
End Class