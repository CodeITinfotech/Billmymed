
'Imports System.Data.DataTableExtensions

Public Class Reorder
    Public txt1 As String
    Public txt As String
    Public chkdate As DateTime
    Public tmpmemo As String
    Public totprval As Integer
    Public sclick As Integer
    Public dclick As Integer
    Public obj As Object
    Private Trans As OleDb.OleDbTransaction
    Private EditFlag As Boolean
    Private EditNum As Long
    Private EditDate As Date
    Private TKV As Long
    Private UseBarCode As Boolean
    Private dbcn As New OleDb.OleDbConnection
    Private sertime As DateTime
    Private sertxt As String

    Private Sub Reorder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            If pnlshow.Visible Then pnlshow.Visible = False
        End If
    End Sub

    Private Sub Purchase_Return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clearform()

            'Dim tb As New DataTable
            'Dim btb As New DataTable
            'Dim btb1 As New DataTable
            'Dim da As New OleDb.OleDbDataAdapter

            'dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\ab2.mdb;Jet OLEDB:Database Password=VALOTH;"
            'dbcn.Open()
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Try
            Dim WD As Integer

            WD = 0
            cntrol.Location = dgord.Location


            cntrol.top = dgord.Top + dgord.GetRowDisplayRectangle(dgord.CurrentCell.RowIndex, True).Top
            cntrol.left = dgord.Left + dgord.GetColumnDisplayRectangle(dgord.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgord.GetColumnDisplayRectangle(dgord.CurrentCell.ColumnIndex, True).Width
            cntrol.Text = dgord.CurrentCell.Value & ""

            cntrol.Visible = True
            cntrol.Enabled = True
            cntrol.Focus()
            dgord.Enabled = False

        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Sub

    Private Sub ClearForm(Optional ByVal flg As Boolean = False)
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim dr As OleDb.OleDbDataReader
            Dim cmd1 As New OleDb.OleDbCommand
            Dim DS As New DataSet

            cmd.Connection = Conn
            cmd1.Connection = Conn
            gridctrl.Visible = False
            CbEditSupp.Visible = False

            'dgRec.Enabled = True
            If Not flg Then
                Try
                    cmd.CommandText = "select convert(varchar,min(PndOrd.ordno))  + ' - ' + convert(varchar,max(PndOrd.ordno)) from pndord where orddt=convert(datetime,'" & SysDt & "') "
                    lbltoday.Text = " Todays Orders : " & cmd.ExecuteScalar & ""

                Catch ex As Exception

                End Try
              
                cmd.CommandText = "select Accode,Acname + ' ' + place  as [AcName] from Acmaster where grpcode=" & SupGrpcode & " order by Acname"

                da.SelectCommand = cmd
                da.Fill(DS, "Acmaster")
                cbsupp.DisplayMember = "AcName"
                cbsupp.ValueMember = "AcCode"
                cbsupp.DataSource = DS.Tables("Acmaster")
                lbldate.Text = Format(SysDt, DateFormat)

                cmd1.CommandText = "select usebarcode from settings"
                UseBarCode = cmd1.ExecuteScalar

                cmd1.CommandText = "select slno from serialnum where type='51'"
                dr = cmd1.ExecuteReader
                dr.Read()
                lblprno.Text = dr(0) + 1
                dr.Close()

                cmd.CommandText = "select Accode,Acname + ' ' + place  as [AcName] from  AcMaster where grpcode=" & SupGrpcode & " order by Acname"
                da.SelectCommand = cmd
                da.Fill(DS, "AcMaster1")
                CbEditSupp.DisplayMember = "Acname"
                CbEditSupp.ValueMember = "Accode"
                CbEditSupp.DataSource = DS.Tables("AcMaster1")

                dgord.Columns(2).Visible = UseBarCode

                dr.Close()
                lstcom.Items.Clear()
                cbsupp.SelectedValue = 0
                cbsupp.SelectedText = ""
                'lbldate.Text = SysDt
            End If

            dgord.Rows.Clear()
            dgord.Rows.Add()
            EditFlag = False
            EditNum = 0

            dgord.Columns(2).Visible = UseBarCode

            dgord.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgord.Columns(17).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(18).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgord.Columns(0).ValueType = GetType(String)
            dgord.Columns(3).ValueType = GetType(String)
            dgord.Columns(4).ValueType = GetType(String)
            dgord.Columns(5).ValueType = GetType(String)

            dgord.Enabled = True
            dgord.Rows.Clear()
            dgord.Rows.Add()
            Calculate()
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Sub

    Private Sub cbPRsup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsupp.SelectedIndexChanged
        lstcom.Items.Clear()
        ShowCompany()
        If chksup.Checked Then Exit Sub
        chksup.Checked = False
    End Sub
  
    Public Sub ShowCompany()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim reader As OleDb.OleDbDataReader
            Dim cb1 As CheckedListBox.ObjectCollection
            cmd.Connection = Conn
            If cbsupp.SelectedValue = Nothing And chksup.Checked = False Then Exit Sub

            If chksup.Checked = True Then
                cmd.CommandText = "Select company.comCode,comName as [Company Name] from company  order by comname"
            Else
                If ChkSupliedCom.Checked Then
                    cmd.CommandText = "Select company.comCode,comName as [Company Name] from company,batch,product where  batch.supcode=" & cbsupp.SelectedValue & " and product.prdcode=batch.prdcode and company.comcode=product.comcode group by  company.comCode,comName  order by comname"
                Else
                    If chkdom.Checked Then
                        cmd.CommandText = "Select company.comCode,comName as [Company Name] from company where fsupcode=" & cbsupp.SelectedValue & "  order by comname"
                    Else
                        cmd.CommandText = "Select company.comCode,comName as [Company Name] from company,supcom where supcom.comcode=company.comcode and supcom.supcode=" & cbsupp.SelectedValue & "  order by comname"
                    End If
                End If

            End If


            reader = cmd.ExecuteReader
            lstcom.Items.Clear()
            If reader.HasRows Then
                While reader.Read
                    'lstsup.Items.Add(reader(0), False)

                    'CheckedListBox1.Tag = reader(0)

                    'CheckedListBox1.SelectedValue = reader(1)
                    'CheckedListBox1.Selecte()
                    'checkedlistbox1.Text
                    lstcom.Items.Add(New MyList(reader(1), reader(0)))
                End While
                reader.Close()
            Else
                lstcom.Items.Clear()
            End If

        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Sub

    Private Sub btnPRselall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRselall.Click
        Try
            sclick = 1
            'btnPRgen.Enabled = True
            Dim i As Integer
            Dim mList As MyList
            tmpmemo = ""
            For i = 0 To lstcom.Items.Count - 1
                lstcom.SetItemChecked(i, True)
                mList = lstcom.Items(i)
                tmpmemo = ";" & tmpmemo & mList.ItemData() & ";"
            Next
            sclick = 0
            If tmpmemo <> "" Then btnOrdGen.Enabled = True
            'If cbPRbrkn .Checked = True Or cbPRexpprod.Checked = True Or cbslmove.Checked = True And lstsup.CheckedItems.Count > 0 Then btnPRgen.Enabled = True
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try

    End Sub

    Private Sub btnPRdselall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRdselall.Click
        Try
            dclick = 1
            'btnPRgen.Enabled = False
            Dim i As Integer
            For i = 0 To lstcom.Items.Count - 1
                lstcom.SetItemChecked(i, False)
            Next
            'btnPRgen.Enabled = False
            tmpmemo = ""
            btnOrdGen.Enabled = False
            dclick = 0
        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try

    End Sub

    Private Sub lstsup_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstcom.ItemCheck
        Try
            Dim i As Integer
            Dim mList As MyList

            If Not sclick = 1 And Not dclick = 1 Then
                tmpmemo = ""
                For i = 0 To lstcom.Items.Count - 1
                    If i = e.Index Then
                        If e.NewValue = CheckState.Checked Then
                            mList = lstcom.Items(i)
                            tmpmemo = ";" & tmpmemo & mList.ItemData & ";"
                        End If
                    Else
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpmemo = ";" & tmpmemo & mList.ItemData & ";"
                        End If

                    End If

                Next

                If tmpmemo = "" Then
                    btnOrdGen.Enabled = False
                Else
                    btnOrdGen.Enabled = True
                End If

            End If

        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try

    End Sub

    Private Sub dgPR_DoubleClick() Handles dgord.DoubleClick
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        If dgord.CurrentCell Is Nothing Then Exit Sub
        If dgord.CurrentCell.ColumnIndex = 10 And (dgord.CurrentCell.Value & "") <> "" Then
            cmd.Connection = Conn
            Label7.Text = "Pending Order List:-"
            pnlshow.Tag = "PO"
            dgshow.Width = 457
            cmd.CommandText = "Select OrdNo as [Ord No],OrdDt as [Ord Dt],acmaster.acname + ' ' + acmaster.place  as [Supplier]  from " & _
                "pndord,acmaster where pndord.supcode=acmaster.accode and pndord.prdcode=""" + _
                dgord.Item(2, dgord.CurrentCell.RowIndex).Value + """ group   by OrdNo  ,OrdDt  ,acmaster.acname + ' ' + acmaster.place  order by OrdDt,OrdNo  "
            da.SelectCommand = cmd
            dt.Rows.Clear()
            dt.Clear()
            da.Fill(dt)

            dgshow.DataSource = dt
            dgshow.Columns(0).Width = 80
            dgshow.Columns(1).Width = 100
            dgshow.Columns(2).Width = 300
            

            If dt.Rows.Count > 0 Then
                Dim v As Long = 306
                Dim a As Integer
                If TKV <> 1 Then
                    pnlshow.Height = 0
                End If
                pnlshow.Visible = True
                pnlshow.Height = 5
                For i = 0 To v
                    pnlshow.Height = i
                    For n As Integer = 0 To 200
                        Application.DoEvents()
                        TKV = 0
                    Next
                Next
            Else
                pnlshow.Visible = False

            End If
            Exit Sub

        ElseIf dgord.CurrentCell.ColumnIndex = 17 And (dgord.Item(2, dgord.CurrentCell.RowIndex).Value & "") <> "" Then
            cmd.Connection = Conn
            dgshow1.Visible = False
            dgshow.Width = 1500
            Label7.Text = "Purchase Details:-"
            pnlshow.Tag = "PD"
            cmd.CommandText = "Select top 20 RctNo, Batch,ExDt,convert(bigint,(batch.Rqty/(case when unit<2 then 1 else unit end) )) as [RQty], convert(bigint,(batch.Fqty/(case when unit<2 then 1 else unit end))) as FQty,BillNo,Stock,BillDt,Pdate as [Pur.Date],Profit as [Profit%],acmaster.acname + ' ' + acmaster.place  as [Supplier]  from " & _
                "batch,acmaster where batch.supcode=acmaster.accode and batch.prdcode=""" + _
                dgord.Item(2, dgord.CurrentCell.RowIndex).Value + """ order by batchid Desc"
            da.SelectCommand = cmd
            dt.Rows.Clear()
            dt.Clear()
            da.Fill(dt)

            dgshow.DataSource = dt
            dgshow.Columns(0).Width = 80
            dgshow.Columns(1).Width = 80
            dgshow.Columns(2).Width = 90
            dgshow.Columns(3).Width = 80
            dgshow.Columns(4).Width = 80
            dgshow.Columns(5).Width = 90
            dgshow.Columns(6).Width = 70
            dgshow.Columns(7).Width = 90
            dgshow.Columns(8).Width = 90
            dgshow.Columns(9).Width = 70
            dgshow.Columns(10).Width = 250


            If dt.Rows.Count > 0 Then
                Dim v As Long = 306
                Dim a As Integer
                If TKV <> 1 Then
                    pnlshow.Height = 0
                End If
                pnlshow.Visible = True
                pnlshow.Height = 5
                For i = 0 To v
                    pnlshow.Height = i
                    For n As Integer = 0 To 200
                        Application.DoEvents()
                        TKV = 0
                    Next
                Next
            Else
                pnlshow.Visible = False

            End If
            Exit Sub
        End If
        EditGrid()
    End Sub

    Public Sub EditGrid()
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Try
            Dim EDROW As Integer = dgord.CurrentCell.RowIndex
            Dim EDCOL As Integer = dgord.CurrentCell.ColumnIndex

            If dgord.CurrentCell.ColumnIndex = 6 Or dgord.CurrentCell.ColumnIndex = 7 Then
                If dgord.Item(2, dgord.CurrentRow.Index).Value & "" = "" Then
                    dgord.CurrentCell = dgord.Item(3, dgord.CurrentRow.Index)
                    ShowEditControl(gridctrl)
                    Exit Sub
                End If
                If dgord.CurrentCell.ColumnIndex > 3 And dgord.Item(3, dgord.CurrentCell.RowIndex).Value & "" = "" Then
                    dgord.Columns(3).Selected = True
                    dgord.CurrentCell = dgord.Item(dgord.CurrentCell.ColumnIndex, dgord.CurrentRow.Index)
                    ShowEditControl(gridctrl)
                    Exit Sub
                End If
                dgord.CurrentCell = dgord.Item(dgord.CurrentCell.ColumnIndex, dgord.CurrentRow.Index)
                ShowEditControl(gridctrl)
            ElseIf dgord.CurrentCell.ColumnIndex = 14 Then
                cmd.Connection = Conn
                If dgord.Item(2, dgord.CurrentRow.Index).Value & "" = "" Then

                    dgord.CurrentCell = dgord.Item(3, dgord.CurrentRow.Index)
                    ShowEditControl(gridctrl)
                    Exit Sub
                End If


                cmd.CommandText = "SELECT Acmaster.AcCode, Acmaster.AcName + ' ' + Acmaster.Place AS AcName, Supcom.ComCode FROM  Acmaster INNER JOIN " & _
                         "Supcom ON Acmaster.AcCode = Supcom.SupCode WHERE  (Acmaster.GrpCode = " & SupGrpcode & ") AND (Supcom.ComCode = " & Val(dgord.CurrentRow.Cells("cmcode").Value & "") & ")  group by Acmaster.AcCode, Acmaster.AcName + ' ' + Acmaster.Place , Supcom.ComCode ORDER BY AcName"

                da.SelectCommand = cmd
                dt.Rows.Clear()
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    cmd.CommandText = "select Accode,Acname + ' ' + place  as [AcName] from Acmaster where grpcode=" & SupGrpcode & " order by Acname"
                    da.Fill(dt)

                End If
                CbEditSupp.DisplayMember = "AcName"
                CbEditSupp.ValueMember = "AcCode"
                CbEditSupp.DataSource = dt



                CbEditSupp.SelectedValue = Int(Val(dgord.Item(13, dgord.CurrentRow.Index).Value & ""))
                ShowEditControl(CbEditSupp)
                CbEditSupp.DroppedDown = True
            ElseIf dgord.CurrentCell.ColumnIndex = 2 Then
                If dgord.CurrentCell.Value & "" <> "" Then Exit Sub
                'If gridctrl.Text = "" Then
                'dgord.CurrentCell = dgord.Item(3, dgord.CurrentRow.Index)
                ShowEditControl(gridctrl)
                'End If

            ElseIf dgord.CurrentCell.ColumnIndex = 3 Then
                'If gridctrl.Text = "" Then
                If dgord.CurrentCell.Value & "" <> "" Then Exit Sub
                ShowEditControl(gridctrl)
                'End If

            End If

        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try
    End Sub

    Public Sub Populate()
        Try
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = obj.text

                da.SelectCommand = cmd
                da.Fill(ds, "Product")

                Prodgrid.DataSource = ds.Tables("Product")
                If (Prodgrid.Rows.Count - 1) >= 1 Then
                    Prodgrid.Visible = True

                    Prodgrid.Focus()

                    Exit Sub
                Else

                End If
                cmd.Parameters.Clear()
            End If
            Prodgrid.Visible = False

            obj.SelectionStart = obj.TextLength
            obj.focus()
        Catch d As Exception
            MessageBox.Show(d.Message)


        End Try
    End Sub

    Private Sub RowClear()
        dgord.Rows.RemoveAt(dgord.CurrentRow.Index)
        dgord.Rows.Add()
         

    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress
        Try

            Dim cmd As New OleDb.OleDbCommand

            cmd.Connection = Conn

            If Asc(e.KeyChar) = 27 Then
                If dgord.CurrentRow.Index = dgord.RowCount - 1 Then
                    RowClear()
                    gridctrl.Text = ""
                    gridctrl.Visible = False
                    dgord.Enabled = True
                    dgord.Focus()
                Else
                    gridctrl.Visible = False
                    dgord.Enabled = True
                    dgord.Focus()

                End If
            End If
            If Asc(e.KeyChar) = 13 Then
                Select Case dgord.CurrentCell.ColumnIndex
                    Case 6
                        dgord.Item(dgord.CurrentCell.ColumnIndex, dgord.CurrentRow.Index).Value = Val(gridctrl.Text)
                        gridctrl.Visible = False
                        Prodgrid.Visible = False
                        If dgord.CurrentCell.RowIndex = dgord.Rows.Count - 1 Then
                            dgord.CurrentCell = dgord.CurrentRow.Cells(7)
                            dgord.Focus()
                            ShowEditControl(gridctrl)

                        Else
                            gridctrl.Visible = False
                            dgord.Enabled = True
                            dgord.Focus()
                        End If
                    Case 7

                        dgord.Item(dgord.CurrentCell.ColumnIndex, dgord.CurrentRow.Index).Value = Val(gridctrl.Text)
                        If dgord.CurrentCell.RowIndex = dgord.Rows.Count - 1 Then
                            dgord.CurrentCell = dgord.CurrentRow.Cells(9)
                            'dgord.FirstDisplayedScrollingColumnIndex = 9
                            dgord.Focus()
                            'EditGrid()
                            ShowEditControl(gridctrl)

                        Else
                            gridctrl.Visible = False
                            dgord.Enabled = True
                            dgord.Focus()
                        End If
                    Case 9
                        dgord.Item(dgord.CurrentCell.ColumnIndex, dgord.CurrentRow.Index).Value = gridctrl.Text
                        If chksup.Checked = True Then

                            If dgord.CurrentCell.RowIndex = dgord.Rows.Count - 1 Then
                                dgord.CurrentCell = dgord.CurrentRow.Cells(14)
                                '  dgord.FirstDisplayedScrollingColumnIndex = 14
                                gridctrl.Visible = False
                                dgord.Focus()
                                EditGrid()
                            Else
                                gridctrl.Visible = False
                                dgord.Enabled = True
                                Prodgrid.Visible = False
                                dgord.Focus()
                            End If

                        Else
                            If dgord.CurrentCell.RowIndex = dgord.Rows.Count - 1 Then
                                gridctrl.Visible = False
                                dgord.Rows.Add()
                                dgord.CurrentCell = dgord.Item(3, dgord.Rows.Count - 1)
                                ' dgord.FirstDisplayedScrollingColumnIndex = 4
                                dgord.Enabled = True
                                Prodgrid.Visible = False
                                dgord.Focus()
                                EditGrid()
                            Else
                                gridctrl.Visible = False
                                dgord.Enabled = True
                                Prodgrid.Visible = False
                                dgord.Focus()
                            End If
                        End If

                    Case 2
                        If gridctrl.Text = "" Then

                            dgord.CurrentCell = dgord.CurrentRow.Cells(3)
                            EditGrid()
                            Exit Sub
                        Else
                            GetBarCode()
                            Exit Sub
                        End If


                    Case 3
                        If gridctrl.Text = "" Then
                            Try

                                dgord.CurrentCell = dgord.CurrentRow.Cells(2)
                                EditGrid()
                                Exit Sub
                            Catch ex As Exception

                            End Try
                        Else

                        End If

                End Select
                Calculate()

            End If

        Catch d As Exception
            MessageBox.Show(d.Message)


        End Try
    End Sub

    'Public Sub RowHeader()
    '    Try
    '        For Each Row As DataGridViewRow In dgPR.Rows
    '            If Row.Index = dgPR.Rows.Count - 1 Then
    '                Row.HeaderCell.Value = ""
    '            Else
    '                Row.HeaderCell.Value = (Row.Index + 1).ToString
    '            End If
    '        Next
    '    Catch d As Exception
    '        MessageBox.Show(d.Message)

    '    End Try
    'End Sub
    Private Sub gridctrl_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.TextChanged

        Try
            If dgord.CurrentRow.Cells(3).Selected = True Then
                obj = gridctrl
                Populate()

            End If

        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try
    End Sub

    Private Sub Prodgrid_CellContextMenuStripChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Prodgrid.CellContextMenuStripChanged

    End Sub

    Private Sub Prodgrid_DoubleClick() Handles Prodgrid.DoubleClick
        GetInfo()
    End Sub

    Private Sub GetInfo(Optional cd As String = "", Optional pn As String = "")
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim drp As OleDb.OleDbDataReader

            cmd.Connection = Conn
            cmd1.Connection = Conn
            If cd = "" Then
                cd = Prodgrid.CurrentRow.Cells(0).Value
                pn = Prodgrid.CurrentRow.Cells(1).Value
            End If

            Prodgrid.Visible = False
            dgord.CurrentRow.Cells(0).Value = dgord.CurrentRow.Index + 1
            dgord.CurrentRow.Cells(3).Value = pn
            gridctrl.Visible = False

            dgord.CurrentRow.Cells(2).Value = cd

            cmd.CommandText = "select product.lid,case1,unit1,case2,unit2,comname,ordnote,sum(batch.stock) as stk,product.comcode from product INNER JOIN " & _
                    "company ON company.comcode = product.comcode LEFT JOIN batch ON batch.prdcode=product.prdcode  where product.prdcode=""" + _
                    dgord.CurrentRow.Cells(2).Value + """  group by  product.lid,case1,unit1,case2,unit2,comname,ordnote,product.comcode "
            dr = cmd.ExecuteReader
            dr.Read()
            If dr("UNIT2") <> 0 Then
                dgord.CurrentRow.Cells(1).Value = Val(dr("UNIT2"))
                dgord.CurrentRow.Cells(8).Value = dr("CASE2")
            Else
                dgord.CurrentRow.Cells(1).Value = Val(dr("UNIT1"))
                dgord.CurrentRow.Cells(8).Value = dr("CASE1")
            End If
            dgord.CurrentRow.Cells("cmcode").Value = dr("comcode")
            dgord.CurrentRow.Cells(15).Value = dr("COMNAME")
            dgord.CurrentRow.Cells(18).Value = dr("ordnote")

            dgord.CurrentRow.Cells(4).Value = Val(dr("STK") & "") / Val(dgord.CurrentRow.Cells(1).Value & "")

            If IsDate(dr("lid")) Then
                dgord.CurrentRow.Cells(11).Value = Format(dr("lid"), "dd/MM/yy")
            Else
                dgord.CurrentRow.Cells(11).Value = ""
            End If
            dr.Close()

            cmd1.CommandText = "select sum(qty/unit),sum(free/unit) from pndord where prdcode=""" + dgord.CurrentRow.Cells(2).Value + """"
            drp = cmd1.ExecuteReader

            cmd.CommandText = "select supcode,exdt,Acmaster.acname,acmaster.place,rqty,fqty,stock,srate,prate,rctno,pdate from batch INNER JOIN " & _
                    "Acmaster ON Batch.Supcode = Acmaster.AcCode  where supcode<>0 and rctno<>0 and prdcode=""" + _
                     dgord.CurrentRow.Cells(2).Value + """ order by batchid desc "

            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                dr.Close()
                cmd.CommandText = "select supcode,exdt,Acmaster.acname,acmaster.place,rqty,fqty,stock,srate,prate,rctno,pdate from batch INNER JOIN " & _
                    "Acmaster ON Batch.Supcode = Acmaster.AcCode  where supcode<>0 and prdcode=""" + _
                     dgord.CurrentRow.Cells(2).Value + """ order by batchid desc "
                dr = cmd.ExecuteReader
            End If


            If dr.HasRows Then
                dr.Read()
                dgord.CurrentRow.Cells(19).Value = Format(dr("SRATE") * Val(dgord.CurrentRow.Cells(1).Value), "0.000")

                dgord.CurrentRow.Cells(20).Value = Format(dr("PRATE") * Val(dgord.CurrentRow.Cells(1).Value), "0.000")
                If Not IsDBNull(dr("pdate")) Then
                    dgord.CurrentRow.Cells(17).Value = dr("rctno") & " - " & Format(dr("pdate"), "dd/MM/yy") & "  " & System.Math.Round(dr("rqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & " + " & System.Math.Round(dr("Fqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & "  " & dr("acname") & " " & dr("place")

                Else
                    dgord.CurrentRow.Cells(17).Value = dr("rctno") & " - " & System.Math.Round(dr("rqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & " + " & System.Math.Round(dr("Fqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & "  " & dr("acname") & " " & dr("place")

                End If
                If IsDate(dr("exdt")) Then
                    dgord.CurrentRow.Cells(12).Value = Format(dr("exdt"), "dd/MM/yy")
                Else
                    dgord.CurrentRow.Cells(12).Value = ""
                End If

                If chksup.Checked Then
                    dgord.CurrentRow.Cells(13).Value = dr("supcode")
                    dgord.CurrentRow.Cells(14).Value = dr("acname")
                Else
                    dgord.CurrentRow.Cells(13).Value = cbsupp.SelectedValue
                    dgord.CurrentRow.Cells(14).Value = cbsupp.Text
                End If
                'dgord.CurrentRow.Cells(18).Value = dr("ordnote")
                If drp.HasRows Then
                    drp.Read()
                    If Val(drp(0) & "") <> 0 Then
                        dgord.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue
                        dgord.CurrentRow.Cells(10).Value = System.Math.Round(drp(0), 0) & " + " & System.Math.Round(Val(drp(1) & ""), 0)
                    End If
                End If
            End If
            drp.Close()
            dr.Close()
            'For i = 0 To dgord.ColumnCount - 1
            '    If IsDBNull(dgord.CurrentRow.Cells(i).Value) Then
            '        dgord.CurrentRow.Cells(i).Value = ""

            '    End If
            'Next
            dgord.CurrentCell = dgord.Item(6, dgord.CurrentCell.RowIndex)
            dgPR_DoubleClick()
        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try
    End Sub

    Private Sub dgPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgord.KeyDown
        Dim dec As DialogResult
        Dim vi, vii, v As Integer

        Try

            If e.KeyCode = Keys.Escape Then
                gridctrl.Visible = False
                dgord.Focus()
                dgord.Enabled = True
                e.Handled = True
            End If

            If e.KeyCode = Keys.Delete And dgord.CurrentRow.Index < dgord.Rows.Count - 1 Then

                dec = MessageBox.Show("Want to delete selected products ?", " ", MessageBoxButtons.YesNo)
                If dec = Windows.Forms.DialogResult.No Then
                    dgord.Focus()
                    Exit Sub
                End If


                vi = dgord.SelectedCells(0).RowIndex
                vii = dgord.SelectedCells(dgord.SelectedCells.Count - 1).RowIndex

                If vi > vii Then
                    v = vii
                    vii = vi
                    vi = v
                End If

                For i = vi To vii
                    If dgord.Item(1, vi).Value & "" <> "" Then dgord.Rows.Remove(dgord.Rows(vi))
                Next


                For i = vi To dgord.Rows.Count - 2
                    dgord.Item(0, i).Value = i + 1 'Val(dgPR.Item(0, i).Value) - 1
                Next
                e.Handled = True
                Calculate()
            End If



            If e.KeyCode = Keys.Enter Then

                dgPR_DoubleClick()

                e.Handled = True
            End If
        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try
    End Sub

    Public Sub deleterow(ByVal delcol As Integer)
        Dim i As Integer
        Try
            If dgord.Rows.Count > 2 Then
                dgord.Rows.Remove(dgord.Rows(delcol))
            Else
                dgord.CurrentRow.Cells(0).Value = DBNull.Value
                dgord.CurrentRow.Cells(1).Value = DBNull.Value
                dgord.CurrentRow.Cells(2).Value = DBNull.Value
                dgord.CurrentRow.Cells(3).Value = DBNull.Value
                dgord.CurrentRow.Cells(4).Value = DBNull.Value
                dgord.CurrentRow.Cells(5).Value = DBNull.Value
                dgord.CurrentRow.Cells(6).Value = DBNull.Value
                dgord.CurrentRow.Cells(7).Value = DBNull.Value
                dgord.CurrentRow.Cells(8).Value = DBNull.Value
                dgord.CurrentRow.Cells(9).Value = DBNull.Value
                dgord.CurrentRow.Cells(10).Value = DBNull.Value
            End If

            For i = 1 To dgord.Rows.Count - 1
                dgord.Item(0, i).Value = i
            Next i
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub Prodgrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Prodgrid.KeyDown
        Try
            If e.KeyCode = 27 Then
                Prodgrid.Visible = False
                gridctrl.Text = ""
                gridctrl.Focus()
            End If
            'If e.KeyCode = 13 Then
            '    'Prodgrid_DoubleClick()
            '    'e.Handled = True
            '    Exit Sub

            'End If
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub Prodgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Prodgrid.KeyPress
        Try

            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                Prodgrid.Visible = False : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then Prodgrid.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If

        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub GetBarCode()
        Try
            Dim dataredr As OleDb.OleDbDataReader
            Dim DS As New DataSet
            Dim cmd As New OleDb.OleDbCommand

            Dim pc As String

            cmd.Connection = Conn

            tsbSave.Enabled = False
            'Check for the stock if present

            cmd.Connection = Conn
            cmd.CommandText = "Select product.PrdCode,prdname from Barcodes,product where  product.prdcode=barcodes.prdcode  and BarCode=""" & gridctrl.Text & """ "
            dataredr = cmd.ExecuteReader

            If dataredr.HasRows Then
                dataredr.Read()
                GetInfo(dataredr(0), dataredr(1))
            Else
                gridctrl.Focus()
                gridctrl.SelectAll()
                MsgBox("Product not found..")
                Exit Sub
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub Prodgrid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Prodgrid.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Prodgrid_DoubleClick()
        End If
    End Sub

    Private Sub lstcom_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstcom.KeyPress
        Dim fnd As Boolean = False
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            'Me.Text = System.Math.Abs(Val(Mid(Now().TimeOfDay.ToString, 7, 2))) & "  " & Val(Mid(sertime, 7, 2)) & "  " & sertxt

            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = CDate(Now().TimeOfDay.ToString)
            For n = 0 To lstcom.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstcom.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstcom.SelectedItem = lstcom.Items(n)
                    ' lstcom.SelectedIndex = n
                    e.Handled = True
                    fnd = True
                    Exit For
                End If
            Next n
            If fnd = False Then sertxt = UCase(e.KeyChar)

        End If
    End Sub

    Private Sub cbPRallsup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksup.CheckedChanged
        Try
            If chksup.Checked = True Then
                cbsupp.SelectedValue = 0
                cbsupp.Text = ""
                cbsupp.SelectedText = ""
                cbsupp.Enabled = False
                ' lstcom.Enabled = Fal
                ChkSupliedCom.Enabled = False
                chkdom.Enabled = False
                ShowCompany()
            Else
                cbsupp.Enabled = True
                lstcom.Enabled = True
                chkdom.Enabled = True
                ChkSupliedCom.Enabled = True
            End If
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub tbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        Dim Trn As Boolean
        Dim tmpsupcode As Long
        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        Dim StNum As Long
        Dim curdt As Date
        Dim i As Integer
        Dim curno As Long
        Dim oqty As Long
        Dim ednum As Long

        If EditFlag Then
            If CheckUserLocked("Edit Orders", , IIf(EditFlag, EditDate, Nothing)) = False Then Exit Sub
        End If
        Try

            If chksup.Checked = False Then
                If Val(cbsupp.SelectedValue & "") = 0 Then
                    MsgBox("Supplier name is not selected.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            For i = 0 To dgord.Rows.Count - 2
                If Val(dgord.Item(13, i).Value & "") = 0 Then
                    If chksup.Checked Then
                        MsgBox("Supplier name is not selected for the product " & dgord.Item(3, i).Value, MsgBoxStyle.Information)
                        dgord.CurrentCell = dgord.Item(3, i)
                        dgord.Focus()
                        Exit Sub
                    Else
                        dgord.Item(13, i).Value = Val(cbsupp.SelectedValue & "")
                    End If
                End If
            Next
            Me.Cursor = Cursors.WaitCursor
            Trn = False
            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn
            Trn = True

            curdt = SysDt
            If EditFlag Then
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "delete pndord  where ordno=" & _
                       Val(EditNum) & " and orddt=convert(datetime,'" & EditDate & "')"
                cmd.ExecuteNonQuery()

                curdt = EditDate
            End If

            StNum = 0
            tmpsupcode = -1
            Dim dt As DataTable
            dt = dgord.DataSource
            If chksup.Checked Then

                dgord.Sort(dgord.Columns(14), System.ComponentModel.ListSortDirection.Ascending)

            End If

            For i = 0 To dgord.Rows.Count - 2

                oqty = Val(dgord.Item(6, i).Value) * (Val((dgord.Item(1, i).Value)))

                If oqty = 0 Then GoTo last
                If EditFlag = False Then
                    If tmpsupcode <> Int(Val(dgord.Item(13, i).Value & "")) Then
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "update serialnum set slno=slno+1 where type='51'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "select slno from serialnum where type='51'"
                        dataredr = cmd.ExecuteReader()
                        dataredr.Read()
                        curno = dataredr(0)
                        dataredr.Close()
                        If StNum = 0 Then StNum = curno
                        ednum = curno
                        lblprno.Text = curno
                    End If
                Else
                    curno = EditNum
                    curdt = EditDate
                End If

                cmd.CommandType = CommandType.Text
                cmd.CommandText = "insert into pndord (prdcode,qty,supcode,ordno,orddt,free,unit,pack,rmk,instock) values (""" & _
                    dgord.Item(2, i).Value & """," & (Val(dgord.Item(6, i).Value & "") * Val(dgord.Item(1, i).Value & "")) & _
                    "," & Val(dgord.Item(13, i).Value) & "," & curno & ",'" & curdt & "'," & _
                   (Val(dgord.Item(7, i).Value & "") * Val(dgord.Item(1, i).Value & "")) & "," & _
                   Val(dgord.Item(1, i).Value) & ",""" & (dgord.Item(8, i).Value & "") & """,""" & _
                   (dgord.Item(9, i).Value & "") & """, " & Val(dgord.Item(4, i).Value & "") & ")"
                cmd.ExecuteNonQuery()
                tmpsupcode = Val(dgord.Item(13, i).Value & "")

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Update_ShortItem"
                cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = dgord.Item(2, i).Value
                cmd.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 0
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text
last:

            Next i

            Trans.Commit()
            Trn = False
            gridctrl.Visible = False
            ClearForm()

        Catch d As Exception
            If Trn Then
                Trans.Rollback()
            End If
            MessageBox.Show(d.Message)
        Finally

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Calculate()
        Dim tot As Double
        For i = 0 To dgord.Rows.Count - 1
            tot = tot + (Val(dgord.Item(6, i).Value & "") * Val(dgord.Item(20, i).Value & ""))
        Next
        lbltot.Text = Format(tot, "0.00")
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

















    Private Sub tsbcans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBCalcel.Click
        EditSales.Text = "Cancelling.. Purchase Order"
        EditSales.txtSalNo.Focus()
        EditSales.ShowDialog()
        Dim nor As Long

        If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
            EditSales.Dispose()
            Exit Sub
        End If
        Dim cmd As New OleDb.OleDbCommand

        If MsgBox("Want to cancel purchase order no. " & EditSales.txtSalNo.Text & " for the period " & EditSales.dtpf.Text & " - " & EditSales.dtpt.Text & "..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            If MsgBox("Are you sure.. Want to cancel purchase order no. " & EditSales.txtSalNo.Text & " for the period " & EditSales.dtpf.Text & " - " & EditSales.dtpt.Text & "..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                cmd.Connection = Conn
                cmd.CommandType = CommandType.Text

                cmd.CommandText = "delete pndord where ordno = " & _
                Val(EditSales.txtSalNo.Text) & " and orddt >= convert(datetime,'" & _
                    EditSales.dtpf.Value.Date & "') and orddt <= convert(datetime,'" & _
                    EditSales.dtpt.Value.Date & "')"

                nor = cmd.ExecuteNonQuery()

                If nor = 0 Then
                    MsgBox("Purchase order not found..", MsgBoxStyle.Information)
                End If

            End If
        End If



        EditSales.Dispose()



    End Sub

    Private Sub EditingOrder(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim cmd As New OleDb.OleDbCommand
            Dim dataredr As OleDb.OleDbDataReader
            Dim r As Integer
            cmd.Connection = Conn

            cmd.CommandText = "Select_PurchaseOrder"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@orno", OleDb.OleDbType.BigInt).Value = Val(no)
            cmd.Parameters.Add("@ordtf", OleDb.OleDbType.DBDate).Value = CDate(dtf)
            cmd.Parameters.Add("@ordtt", OleDb.OleDbType.DBDate).Value = CDate(dtt)
            dataredr = cmd.ExecuteReader


            r = 0
            dgord.Rows.Clear()
            If dataredr.HasRows Then

                While dataredr.Read
                    If r = 0 Then
                        EditNum = dataredr.Item("ordno")
                        EditDate = dataredr.Item("orddt")
                        cbsupp.SelectedValue = dataredr.Item("supcode")
                        lbldate.Text = dataredr.Item("orddt")
                    End If

                    dgord.Rows.Add()
                    dgord.Item(0, r).Value = r + 1

                    dgord.Item(1, r).Value = dataredr.Item("unit")
                    dgord.Item(2, r).Value = dataredr.Item("prdcode")
                    dgord.Item(3, r).Value = dataredr.Item("prdname")
                    dgord.Item(4, r).Value = Format(Val(dataredr.Item("instock") & "") / dataredr.Item("unit"), "0") '& ""
                    dgord.Item(6, r).Value = System.Math.Round(dataredr.Item("qty") / dataredr.Item("unit"), 0)
                    dgord.Item(7, r).Value = System.Math.Round(dataredr.Item("free") / dataredr.Item("unit"), 0)
                    dgord.Item(8, r).Value = dataredr.Item("pack")
                    'If IsDate(dataredr.Item("ExDt")) Then
                    '    dgord.Item(12, r).Value = Format(dataredr.Item("ExDt"), DateFormat)
                    'Else
                    '    dgord.Item(12, r).Value = ""
                    'End If
                    dgord.Item(9, r).Value = dataredr.Item("rmk")

                    dgord.Item(13, r).Value = dataredr.Item("supcode")
                    dgord.Item(14, r).Value = dataredr.Item("acname") & "  " & dataredr.Item("place")
                    dgord.Item(15, r).Value = dataredr.Item("comname")
                    dgord.Item(20, r).Value = Format(dataredr.Item("Prate") * dataredr.Item("unit"), "0.00")


                    r = r + 1
NextProd:
                End While
                dgord.Rows.Add()


                lbldate.Text = Format(EditDate, DateFormat)
                lblprno.Text = EditNum
                EditFlag = True
                tsbSave.Enabled = True
            Else
                MsgBox("Purchase order not found..", MsgBoxStyle.Information)
                ClearForm()

            End If
            dataredr.Close()
            Calculate()
        Catch ex As Exception

            MessageBox.Show(ex.Message)
            ClearForm()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        EditSales.Text = "Editing.. Purchase Order"
        EditSales.txtSalNo.Focus()
        EditSales.ShowDialog()

        If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
            EditSales.Dispose()
            Exit Sub
        End If
        EditingOrder(EditSales.txtSalNo.Text, EditSales.dtpf.Value.Date, EditSales.dtpt.Value.Date)
        EditSales.Dispose()
    End Sub

    Private Sub dgPR_QueryAccessibilityHelp(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryAccessibilityHelpEventArgs) Handles dgord.QueryAccessibilityHelp

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub lblPRdealcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPRdealcomp.Click

    End Sub

    Private Sub chkdom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdom.CheckedChanged
        If chkdom.Checked Then ChkSupliedCom.Checked = False
        ShowCompany()
    End Sub



    Private Sub ExpColor(ByVal i As Integer)
        Try

            Dim nds As Long
            dgord.Item(12, i).Style.ForeColor = Color.Black
            If dgord.Item(12, i).Value & "" <> "" Then
                If IsDate(dgord.Item(12, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgord.Item(12, i).Value)
                    If nds < 0 Then
                        dgord.Item(12, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgord.Item(12, i).Style.ForeColor = Color.DarkRed

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub btnOrdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrdGen.Click
        Dim dt1 As Date
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader
        Dim dr As OleDb.OleDbDataReader
        Dim drp As OleDb.OleDbDataReader
        Dim cmdp As New OleDb.OleDbCommand
        Dim r As Integer
        Dim ord, pndq, pndf As Double
        Dim CONN2 As New OleDb.OleDbConnection
        Me.Cursor = Cursors.WaitCursor
        Dim dbcmd As New OleDb.OleDbCommand
        dbcmd.Connection = dbcn
        Try
            Dim mList As MyList

            tmpmemo = ""
            For i = 0 To lstcom.Items.Count - 1
                If lstcom.GetItemChecked(i) = True Then
                    mList = lstcom.Items(i)
                    tmpmemo = ";" & tmpmemo & mList.ItemData & ";"
                End If
            Next

            CONN2.ConnectionString = connstr 'Conn.ConnectionString
            CONN2.Open()

            cmd.Connection = Conn
            cmd1.Connection = Conn

            cmdp.Connection = CONN2

            dt1 = DateAdd(DateInterval.Day, Val(txtavgdays.Text) * -1, SysDt)

            cmdp.CommandText = "SET QUOTED_IDENTIFIER OFF"

            cmdp.ExecuteNonQuery()
            Me.Cursor = Cursors.WaitCursor

            If chklevel.Checked Then

                If chksup.Checked Then
                    cmd.CommandText = "SELECT Product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                  "WHERE PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                  "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd, " & _
                  "rol AS sales, " & _
                  "Company.ComName, Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                  "Product.unit2,Product.case3,Product.unit3, Company.fsupcode,ordnote,roqty,Product.comcode FROM  Product INNER JOIN " & _
                  "Company ON Product.Comcode = Company.ComCode WHERE product.deleted=0 and " & _
                   "  ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                  "WHERE Batch.PrdCode = Product.PrdCode), 0) < isnull(rol,0) and Charindex(';' + convert(varchar,product.comcode) + ';','" & tmpmemo & "',0)<>0 and isnull(rol,0)>0 and isnull(roqty,0)>0 order by Company.ComName, Product.PrdName "
                Else
                    cmd.CommandText = "SELECT Product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                    "WHERE PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                    "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd, " & _
                    "rol AS sales, " & _
                    "Company.ComName, Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                    "Product.unit2,Product.case3,Product.unit3, Company.fsupcode,ordnote,roqty,Product.comcode FROM  Product INNER JOIN " & _
                    "Company ON Product.Comcode = Company.ComCode WHERE product.deleted=0 and " & _
                    "  ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                    "WHERE  Charindex(';' + convert(varchar,product.comcode) + ';','" & tmpmemo & "',0)<>0 and Batch.PrdCode = Product.PrdCode), 0) < isnull(rol,0) and isnull(rol,0)>0 and isnull(roqty,0)>0  order by Company.ComName, Product.PrdName"
                End If

            Else

                If chksup.Checked Then
                    cmd.CommandText = "SELECT Product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                   "WHERE PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                   "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd, " & _
                   "ISNULL((SELECT SUM(Qty)   FROM InvDetails WHERE InvDetails.PrdCode = Product.PrdCode AND " & _
                   "LEFT(Type, 1) = '2' AND Cancelled = 0 AND invdt>=convert(datetime,'" & dt1 & "') and invdt<=convert(datetime,'" & SysDt & "') ), 0) AS sales, " & _
                   "Company.ComName, Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                   "Product.unit2,Product.case3,Product.unit3,Company.fsupcode,ordnote,Product.comcode FROM  Product INNER JOIN " & _
                   "Company ON Product.Comcode = Company.ComCode WHERE product.deleted=0 and " & _
                   "ISNULL((SELECT  SUM(Qty)   " & _
                   "FROM InvDetails  WHERE InvDetails.PrdCode = Product.PrdCode AND LEFT(Type, 1) = '2'   AND   cancelled = 0   AND  " & _
                    "Charindex(';' + convert(varchar,product.comcode) + ';','" & tmpmemo & "',0)<>0  and " & _
                   "invdt>=convert(datetime,'" & dt1 & "',103) and invdt<=convert(datetime,'" & SysDt & "',103)),0)<>0  order by Company.ComName, Product.PrdName "
                Else
                    cmd.CommandText = "SELECT Product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                   "WHERE PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                   "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd, " & _
                   "ISNULL((SELECT SUM(Qty)   FROM InvDetails WHERE InvDetails.PrdCode = Product.PrdCode AND " & _
                   "LEFT(Type, 1) = '2' AND Cancelled = 0 AND invdt>=convert(datetime,'" & dt1 & "') and invdt<=convert(datetime,'" & SysDt & "') ), 0) AS sales, " & _
                   "Company.ComName, Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                   "Product.unit2,Product.case3,Product.unit3, Company.fsupcode,ordnote,Product.comcode FROM  Product INNER JOIN " & _
                   "Company ON Product.Comcode = Company.ComCode WHERE product.deleted=0 and " & _
                    " " & _
                   "Charindex(';' + convert(varchar,product.comcode) + ';','" & tmpmemo & "',0)<>0 AND " & _
                   "ISNULL((SELECT  SUM(Qty)   " & _
                   "FROM InvDetails  WHERE InvDetails.PrdCode = Product.PrdCode AND LEFT(Type, 1) = '2'   AND   cancelled = 0   AND  " & _
                   "invdt>=convert(datetime,'" & dt1 & "',103) and invdt<=convert(datetime,'" & SysDt & "',103)),0)<>0 order by Company.ComName, Product.PrdName"
                End If

            End If

            cmd.CommandTimeout = 300
            dr = cmd.ExecuteReader
            dgord.Rows.Clear()
            r = 0
            While dr.Read

                If chklevel.Checked Then
                    ord = dr("roqty")
                Else
                    ord = System.Math.Round((dr("sales") / Val(txtavgdays.Text) * Val(txtorddays.Text)) + 0.49, 2)
                End If

                If chklesstk.Checked Then
                    ord = ord - dr("STK")
                    If ord > 0 And ord < 1 Then ord = 1
                    ord = System.Math.Round(ord, 0)
                End If

                If ord > 0 Then

                    cmdp.CommandText = " select sum(pndord.qty/pndord.unit),sum(pndord.free/pndord.unit) from pndord where pndord.prdcode=""" + dr("prdcode") + """"

                    drp = cmdp.ExecuteReader
                    drp.Read()
                    pndq = Val(drp(0) & "")
                    pndf = Val(drp(1) & "")
                    drp.Close()
                    dgord.Rows.Add()

                    'cmdp.CommandText = "select gdnqty from product where prdcode=""" + dr("prdcode") + """"

                    'dgord.Item(9, r).Value = Format(cmdp.ExecuteScalar & "", "0")
                    'If dgord.Item(9, r).Value = "0" Then dgord.Item(9, r).Value = ""

                    dgord.Item(0, r).Value = r + 1
                    cmdp.CommandText = "select top 1 batch.supcode,batch.exdt,Acmaster.acname,Acmaster.place,batch.rqty,batch.fqty,batch.stock,batch.srate" & _
                        ",batch.prate,batch.rctno,batch.pdate,unit from batch," & _
                              "Acmaster WHERE Batch.Supcode = Acmaster.AcCode  AND (Batch.supcode<>0) and (Batch.rctno<>0) and BATCH.prdcode=""" & _
                              dr("prdcode") & """ order by batchid desc "
                    drp = cmdp.ExecuteReader

                    If drp.HasRows = False Then
                        drp.Close()
                        cmdp.CommandText = "select top 1 batch.supcode,batch.exdt,Acmaster.acname,Acmaster.place,batch.rqty,batch.fqty,batch.stock,batch.srate" & _
                     ",batch.prate,batch.rctno,batch.pdate,unit from batch," & _
                           "Acmaster WHERE Batch.Supcode = Acmaster.AcCode  AND (Batch.supcode<>0)  and BATCH.prdcode=""" & _
                           dr("prdcode") & """ order by batchid desc "
                        drp = cmdp.ExecuteReader
                    End If
                    If drp.HasRows Then
                        drp.Read()

                        If drp.Item("unit") = dr("unit2") Then
                            dgord.Item(1, r).Value = dr("unit2")
                            dgord.Item(8, r).Value = dr("case2")
                        ElseIf drp.Item("unit") = dr("unit3") Then
                            dgord.Item(1, r).Value = dr("unit3")
                            dgord.Item(8, r).Value = dr("case3")
                        ElseIf drp.Item("unit") = 1 Then
                            dgord.Item(1, r).Value = dr("unit1")
                            dgord.Item(8, r).Value = dr("case1")
                        Else
                            dgord.Item(1, r).Value = dr("unit2")
                            dgord.Item(8, r).Value = dr("case2")
                        End If

                        dgord.Item(2, r).Value = dr("prdcode")
                        dgord.Item(3, r).Value = dr("prdname")
                        dgord.Item(4, r).Value = Format(dr("stk") / Val(dgord.Item(1, r).Value), "0.0")

                        dgord.Item(5, r).Value = Format(dr("sales") / Val(dgord.Item(1, r).Value), "0.0")

                        ord = System.Math.Round(ord / Val(dgord.Item(1, r).Value), 2)
                        If ord > 0 And ord < 1 Then ord = 1
                        ord = System.Math.Round(ord, 0)

                        If chkprevqty.Checked = True Then
                            ord = System.Math.Round(Val(drp("rqty") & "") / Val(dgord.Item(1, r).Value & ""), 0)
                        End If
                        If ord > 0 Then
                            dgord.Item(6, r).Value = ord
                        Else
                            dgord.Item(6, r).Value = ""
                        End If

                        dgord.Item(7, r).Value = ""
                        dgord.Item(9, r).Value = ""

                        If drp.HasRows Then
                            dgord.Item(19, r).Value = Format(drp("SRATE") * Val(dgord.Item(1, r).Value), "0.00")


                            dgord.Item(20, r).Value = Format(drp("PRATE") * Val(dgord.Item(1, r).Value), "0.00")

                            If IsDate(dr("lid")) Then
                                dgord.Item(11, r).Value = Format(dr("lid"), "dd/MM/yy")
                            Else
                                dgord.Item(11, r).Value = ""
                            End If

                            If IsDate(drp("ExDt")) Then
                                dgord.Item(12, r).Value = Format(drp("ExDt"), "dd/MM/yy")
                            Else
                                dgord.Item(12, r).Value = ""
                            End If
                            ExpColor(r)
                            If chksup.Checked Then
                                dgord.Item(13, r).Value = drp("supcode")
                                dgord.Item(14, r).Value = drp("acname")
                            Else
                                dgord.Item(13, r).Value = cbsupp.SelectedValue
                                dgord.Item(14, r).Value = cbsupp.Text
                            End If
                            dgord.Item(15, r).Value = dr("ComName")

                            If Not IsDBNull(drp("pdate")) Then
                                dgord.Item(17, r).Value = drp("rctno") & " - " & Format(drp("pdate"), "dd/MM/yy") & "  " & System.Math.Round(drp("rqty") / Val(dgord.Item(1, r).Value & ""), 0) & " + " & System.Math.Round(drp("Fqty") / Val(dgord.Item(1, r).Value & ""), 0) & "  " & drp("acname") & " " & drp("place")
                            Else
                                dgord.Item(17, r).Value = drp("rctno") & " - " & System.Math.Round(drp("rqty") / Val(dgord.Item(1, r).Value & ""), 0) & " + " & System.Math.Round(drp("Fqty") / Val(dgord.Item(1, r).Value & ""), 0) & "  " & drp("acname") & " " & drp("place")
                            End If
                            'dgord.Item(17, r).Value = drp("rctno") & " - " & Format(drp("pdate"), "dd/MM/yy") & "  " & System.Math.Round(drp("rqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & " + " & System.Math.Round(drp("Fqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & "  " & drp("acname") & " " & drp("place")

                        Else

                            If chksup.Checked Then
                                dgord.Item(13, r).Value = 0
                                dgord.Item(14, r).Value = ""
                            Else
                                dgord.Item(13, r).Value = cbsupp.SelectedValue
                                dgord.Item(14, r).Value = cbsupp.Text
                            End If
                        End If

                        dgord.Item(15, r).Value = dr("comname")
                        dgord.Rows(r).Cells("cmcode").Value = dr("comcode")
                        dgord.Item(18, r).Value = dr("ordnote") & ""
                        If drp.HasRows Then
                            drp.Read()
                            If pndq + pndf <> 0 Then
                                dgord.Rows(r).DefaultCellStyle.ForeColor = Color.Blue
                                dgord.Item(10, r).Value = System.Math.Round(pndq, 0) & " + " & System.Math.Round(pndf, 0)
                            End If
                        End If


                        r = r + 1
                    End If
                    drp.Close()
                End If
            End While
            dr.Close()
            Calculate()
            Me.Cursor = Cursors.Default
            gridctrl.Visible = False
            CbEditSupp.Visible = False
            dgord.Enabled = True
            dgord.Focus()
            dgord.Rows.Add()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub CbEditSupp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbEditSupp.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If CbEditSupp.SelectedValue = Nothing Then Exit Sub
            dgord.Item(13, dgord.CurrentRow.Index).Value = Int(Val(CbEditSupp.SelectedValue))
            dgord.Item(14, dgord.CurrentRow.Index).Value = CbEditSupp.Text

            CbEditSupp.Visible = False
            Prodgrid.Visible = False
            If dgord.CurrentCell.RowIndex = dgord.Rows.Count - 1 Then
                dgord.Rows.Add()
                dgord.CurrentCell = dgord.Item(3, dgord.Rows.Count - 1)
                dgord.FirstDisplayedScrollingColumnIndex = 8
                dgord.Focus()
                ShowEditControl(gridctrl)
            Else
                CbEditSupp.Visible = False
                dgord.Enabled = True
                dgord.Focus()
            End If
        End If

    End Sub

    Private Sub chklevel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklevel.CheckedChanged
        If chklevel.Checked Then
            dgord.Columns(5).HeaderText = "ROL"

        Else
            dgord.Columns(5).HeaderText = "Sales"
        End If
    End Sub

    Private Sub dgshow_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgshow.CellEnter
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        If pnlshow.Tag = "PD" Then Exit Sub
        If dgshow.CurrentCell Is Nothing Then Exit Sub

        cmd.Connection = Conn
        cmd.CommandText = "Select  product.prdname as [Product        ],CONVERT(INT,(Qty/UNIT)) as [Qty],CONVERT(INT,(Free*UNIT)) as [Free] ,Pack  from " & _
            "pndord,product where product.prdcode=pndord.prdcode   and pndord.ordno= " & dgshow.CurrentRow.Cells(0).Value & " and orddt=convert(datetime,'" & dgshow.CurrentRow.Cells(1).Value & "')"
        da.SelectCommand = cmd
        da.Fill(dt)

        dgshow1.DataSource = dt
        dgshow1.Columns(0).Width = 250
        dgshow1.Columns(1).Width = 80
        dgshow1.Columns(2).Width = 50
        dgshow1.Columns(3).Width = 50
        
        If dt.Rows.Count > 0 Then
            dgshow1.Visible = True
        Else
            dgshow1.Visible = False

        End If
    End Sub

    Private Sub dgshow_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgshow.Leave
        'pnlshow.Visible = False
    End Sub

    Private Sub dgshow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgshow.LostFocus
        'Dim V, I As Integer
        'TKV = 1
        'pnlshow.Height = 303
        ''pnlshow.Visible = True
        ''pnlshow.Height = 5
        'For I = 303 To 0 Step -1
        '    pnlshow.Height = I
        '    For n As Integer = 0 To 200
        '        Application.DoEvents()
        '        If TKV = 0 Then Exit Sub
        '    Next
        'Next
        ''dgshow.Focus()


        'pnlshow.Visible = False
        'TKV = 0
    End Sub

    Private Sub dgord_CellEnter() Handles dgord.CellEnter
        pnlshow.Visible = False
        If dgord.CurrentRow.Cells("code").Value & "" = "" Then Panel1.Visible = False : Exit Sub
        If dgord.CurrentRow.Cells("stk").Value & "" = "" Then Panel1.Visible = False : Exit Sub
        If chkshow.Checked = False Then Panel1.Visible = False : Exit Sub
        If chksup.Checked Then
            lblsup.Text = dgord.CurrentRow.Cells("supplier").Value & " "
        Else
            lblsup.Text = cbsupp.Text
        End If
        grd.Visible = False
        Btpopsser.Text = "Search"
        lblprod.Text = dgord.CurrentRow.Cells("prodname").Value & " " & dgord.CurrentRow.Cells("packing").Value
        lblStk.Text = dgord.CurrentRow.Cells("stk").Value & ""
        lblsch.Text = dgord.CurrentRow.Cells("sch").Value & "  - " & dgord.CurrentRow.Cells("dtf").Value & " - " & dgord.CurrentRow.Cells("dtt").Value
        lblupd.Text = dgord.CurrentRow.Cells("updated").Value
        Panel1.Visible = True
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        BillCopy.txtNof.Focus()
        BillCopy.ChkPrePrint.Visible = False
        BillCopy.cbType.Visible = False
        BillCopy.lblType.Visible = False
        BillCopy.BtnFile.Visible = False
        BillCopy.btnPrint.Visible = False
        BillCopy.Label2.Text = "Purchase Order No"
        BillCopy.Text = "Order Copy"
        BillCopy.loadform()
        BillCopy.ShowDialog()

        Select Case BillCopy.DialogResult
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
            Case Windows.Forms.DialogResult.Yes

            Case Windows.Forms.DialogResult.No

            Case Windows.Forms.DialogResult.OK

        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Get_PurchaseOrder_Print"
        cmd.Parameters.Add("@Nosf", OleDb.OleDbType.BigInt).Value = Val(BillCopy.txtNof.Text)
        cmd.Parameters.Add("@Nost", OleDb.OleDbType.BigInt).Value = Val(BillCopy.txtNot.Text)
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = BillCopy.dtpf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = BillCopy.dtpt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)

        Dim FRMRPT As New Reports1
        Dim RPT As Object
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select StkInOrdCopy from settings"
        If cmd.ExecuteScalar Then
            RPT = New OrderPrintWithStock
            cmd.CommandText = "select  valueInOrdCopy from settings"
            If cmd.ExecuteScalar Then
                RPT = New OrderPrintWithValueStock
            End If
        Else
            cmd.CommandText = "select  valueInOrdCopy from settings"
            If cmd.ExecuteScalar Then
                RPT = New OrderPrintWithValue
            Else
                RPT = New OrderPrint
            End If

        End If


        RPT.SetDataSource(dtab)
        RPT.SetParameterValue("Head1", DeScriptRS(Firm.Name))
        RPT.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
        RPT.SetParameterValue("HEAD3", "Purchase Order")

        FRMRPT.crv.ReportSource = RPT

        FRMRPT.MdiParent = Main
        FRMRPT.Show()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnShList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShList.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
       
        Dim dr As OleDb.OleDbDataReader
        Dim drp As OleDb.OleDbDataReader
        Dim cmdp As New OleDb.OleDbCommand
        Dim r, VI As Integer
        Dim ord, pndq, pndf As Double
        Dim CONN2 As New OleDb.OleDbConnection
        Me.Cursor = Cursors.WaitCursor
        Try

            CONN2.ConnectionString = connstr 'Conn.ConnectionString
            CONN2.Open()

            cmd.Connection = Conn
            cmd1.Connection = Conn

            cmdp.Connection = CONN2


            cmdp.CommandText = "SET QUOTED_IDENTIFIER OFF"

            cmdp.ExecuteNonQuery()


            If chksup.Checked Then
                cmd.CommandText = "SELECT product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                    "WHERE Batch.PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                    "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd, " & _
                    "Company.ComName,Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                    "Product.unit2,Company.fsupcode,ordnote,product.comcode FROM Product,company,shortitem where  product.deleted=0 and  " & _
                    "Company.ComCode=Product.Comcode and shortitem.prdcode=Product.prdcode"
            Else
                cmd.CommandText = "SELECT product.lid,Product.PrdCode AS [PRDCODE],ISNULL((SELECT  SUM(Stock)  FROM Batch " & _
                    "WHERE Batch.PrdCode = Product.PrdCode), 0) AS Stk, ISNULL((SELECT  SUM(Qty + Free)   " & _
                    "FROM  PndOrd  WHERE  PndOrd.PrdCode = Product.PrdCode), 0) AS pnd," & _
                    "Company.ComName, Product.PrdName, Product.case1,Product.case2, Product.unit1, " & _
                    "Product.unit2, Company.fsupcode,ordnote,product.comcode FROM  Product,company,shortitem where product.deleted=0 and " & _
                    "Company.ComCode=Product.Comcode and product.prdcode=shortitem.prdcode and " & _
                    "Charindex(';' + convert(varchar,product.comcode) + ';','" & tmpmemo & "',0)<>0 "
            End If
            dr = cmd.ExecuteReader
            'dgord.Rows.Clear()
            r = dgord.RowCount - 1
            While dr.Read

                ord = 0

                For VI = 0 To dgord.RowCount - 1
                    If dgord.Item(2, VI).Value = dr("prdcode") Then
                        GoTo NEXTROW
                    End If
                Next


                cmdp.CommandText = " select sum(pndord.qty/pndord.unit),sum(pndord.free/pndord.unit) from pndord where pndord.prdcode=""" + dr("prdcode") + """"

                drp = cmdp.ExecuteReader
                drp.Read()
                pndq = Val(drp(0) & "")
                pndf = Val(drp(1) & "")


                drp.Close()
                If dgord.Item(2, dgord.RowCount - 1).Value & "" <> "" Then
                    dgord.Rows.Add()
                End If
                dgord.Item(0, r).Value = r + 1
                cmdp.CommandText = "select batch.supcode,batch.exdt,Acmaster.acname,Acmaster.place,batch.rqty,batch.fqty,batch.stock,batch.srate" & _
                    ",batch.prate,batch.rctno,batch.pdate from batch," & _
                    "Acmaster WHERE Batch.Supcode = Acmaster.AcCode  AND (Batch.supcode<>0) and (Batch.rctno<>0) and BATCH.prdcode=""" & _
                        dr("prdcode") & """ order by batchid desc "
                drp = cmdp.ExecuteReader

                If drp.HasRows = False Then
                    drp.Close()
                    cmdp.CommandText = "select batch.supcode,batch.exdt,Acmaster.acname,Acmaster.place,batch.rqty,batch.fqty,batch.stock,batch.srate" & _
                    ",batch.prate,batch.rctno,batch.pdate from batch," & _
                    "Acmaster WHERE Batch.Supcode = Acmaster.AcCode  AND (Batch.supcode<>0)   and BATCH.prdcode=""" & _
                        dr("prdcode") & """ order by batchid desc "
                    drp = cmdp.ExecuteReader
                End If


                drp.Read()

                If dr("unit2") = 0 Then
                    dgord.Item(1, r).Value = 1
                    dgord.Item(8, r).Value = dr("case1")
                Else
                    dgord.Item(1, r).Value = dr("unit2")
                    dgord.Item(8, r).Value = dr("case2")
                End If
                dgord.Item(2, r).Value = dr("prdcode")
                dgord.Item(3, r).Value = dr("prdname")
                dgord.Item(4, r).Value = Format(dr("stk") / Val(dgord.Item(1, r).Value), "0.0")
                'dgord.Item(5, r).Value =0 'Format(dr("sales") / Val(dgord.Item(1, r).Value), "0.0")
                ord = System.Math.Round(ord / Val(dgord.Item(1, r).Value), 0)

                dgord.Item(7, r).Value = ""
                dgord.Item(9, r).Value = ""

                If drp.HasRows Then

                    'If drp("rqty") > 0 Then
                    dgord.Item(6, r).Value = Format(Val(drp("rqty") & "") / Val(dgord.Item(1, r).Value), "0.0") '
                    'Else
                    'dgord.Item(6, r).Value = ""
                    'End If

                    If IsDate(dr("lid") & "") Then
                        dgord.Item(11, r).Value = Format(dr("lid"), "dd/MM/yy")
                    Else
                        dgord.Item(11, r).Value = ""
                    End If
                    dgord.Item(19, r).Value = Format(drp("SRATE") * Val(dgord.Item(1, r).Value), "0.00")
                    dgord.Item(20, r).Value = Format(drp("PRATE") * Val(dgord.Item(1, r).Value), "0.00")

                    If IsDate(drp("ExDt")) Then
                        dgord.Item(12, r).Value = Format(drp("ExDt"), "dd/MM/yy")
                    Else
                        dgord.Item(12, r).Value = ""
                    End If
                    ExpColor(r)
                    If chksup.Checked Then
                        dgord.Item(13, r).Value = drp("supcode")
                        dgord.Item(14, r).Value = drp("acname")
                    Else
                        dgord.Item(13, r).Value = cbsupp.SelectedValue
                        dgord.Item(14, r).Value = cbsupp.Text
                    End If
                    dgord.Item(15, r).Value = dr("ComName")
                    dgord.Rows(r).Cells("cmcode").Value = dr("Comcode")
                    If Not IsDBNull(drp("pdate")) Then
                        dgord.Item(17, r).Value = drp("rctno") & " - " & Format(drp("pdate"), "dd/MM/yy") & "  " & System.Math.Round(drp("rqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & " + " & System.Math.Round(drp("Fqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & "  " & drp("acname") & " " & drp("place")
                    Else
                        dgord.Item(17, r).Value = drp("rctno") & " - " & System.Math.Round(drp("rqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & " + " & System.Math.Round(drp("Fqty") / Val(dgord.CurrentRow.Cells(1).Value & ""), 0) & "  " & drp("acname") & " " & drp("place")

                    End If


                Else

                    If chksup.Checked Then
                        dgord.Item(13, r).Value = 0
                        dgord.Item(14, r).Value = ""
                    Else
                        dgord.Item(13, r).Value = cbsupp.SelectedValue
                        dgord.Item(14, r).Value = cbsupp.Text
                    End If
                End If

                    dgord.Item(15, r).Value = dr("comname")
                    dgord.Item(18, r).Value = dr("ordnote")
                    If drp.HasRows Then
                        drp.Read()
                        If pndq + pndf <> 0 Then
                            dgord.Rows(r).DefaultCellStyle.ForeColor = Color.Blue
                            dgord.Item(10, r).Value = System.Math.Round(pndq, 0) & " + " & System.Math.Round(pndf, 0)
                        End If
                    End If
                    drp.Close()
                    drp.Close()
                    r = r + 1
                    'End If
NEXTROW:

            End While

            If dgord.Item(2, dgord.RowCount - 1).Value & "" <> "" Then
                dgord.Rows.Add()
            End If
            Calculate()
            gridctrl.Visible = False
            CbEditSupp.Visible = False
            dgord.Enabled = True
            dgord.Focus()
            If dgord.Item(2, dgord.RowCount - 1).Value & "" <> "" Then
                dgord.Rows.Add()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnClearShlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearShlist.Click
        Dim cmd As New OleDb.OleDbCommand
        If MsgBox("Want to clear Short Item list ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        cmd.CommandText = "delete from shortitem "
        cmd.ExecuteNonQuery()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim NUM As String
        Dim DT As Date
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        If EditFlag Then
            DT = EditDate
        Else
            DT = SysDt
        End If
        NUM = Val(lblprno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = ""
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "-O"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()

            NUM = Val(dr("ordno") & "")



        Else
            'GoTo che
            ' ClearForm()
            Me.Cursor = Cursors.Default
            dr.Close()
            Exit Sub
        End If

        NUM = (dr("ordno") & "")
        DT = dr("orddt")
        dr.Close()
        ClearForm(True)
        EditingOrder(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim NUM As String
        Dim DT As Date
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        If EditFlag Then
            DT = EditDate
        Else
            DT = SysDt
        End If
        NUM = Val(lblprno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = ""
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "+O"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()

            NUM = Val(dr("ordno") & "")
            ' dr.Close()

        Else
            ClearForm()
            dr.Close()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        NUM = (dr("ordno") & "")
        DT = dr("orddt")
        dr.Close()
        ClearForm(True)
        EditingOrder(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearForm()
    End Sub

    Private Sub lbltoday_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbltoday.DoubleClick
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Label7.Text = "Today's Order List:-"
        pnlshow.Tag = "OL"
        dgshow.Width = 457
        cmd.Connection = Conn
        cmd.CommandText = "Select OrdNo as [Ord No],OrdDt as [Ord Dt],acmaster.acname + ' ' + acmaster.place  as [Supplier]  from " & _
            "pndord,acmaster where pndord.supcode=acmaster.accode and pndord.orddt=convert(datetime,'" & SysDt & "') group by OrdNo ,OrdDt  ,acmaster.acname + ' ' + acmaster.place   "

        da.SelectCommand = cmd
        da.Fill(dt)

        dgshow.DataSource = dt
        dgshow.Columns(0).Width = 80
        dgshow.Columns(1).Width = 100
        dgshow.Columns(2).Width = 300
        'dgshow.Columns(3).Width = 50
        'dgshow.Columns(4).Width = 50
        ' dgshow.Columns(5).Width = 60

        If dt.Rows.Count > 0 Then
            Dim v As Long = 306
            Dim a As Integer
            If TKV <> 1 Then
                pnlshow.Height = 0
            End If
            pnlshow.Visible = True
            pnlshow.Height = 5
            For i = 0 To v
                pnlshow.Height = i
                For n As Integer = 0 To 200
                    Application.DoEvents()
                    TKV = 0
                Next
            Next
        Else
            pnlshow.Visible = False

        End If

    End Sub

    Private Function CheckAvailability(cd As String, wcli As String, ro As Integer) As Boolean

        Dim cmd As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim dt As New DataTable
        Me.Cursor = Cursors.WaitCursor
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            CheckAvailability = False
            Exit Function
        End If
        Try
            cmd.Connection = PopsConn
            cmd.CommandTimeout = 600
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetAvailability"
            cmd.Parameters.Add("@ClientId", SqlDbType.VarChar).Value = DeScriptRS(Firm.POPSClientID)
            cmd.Parameters.Add("@wclientId", SqlDbType.VarChar).Value = wcli
            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = cd
            da.SelectCommand = cmd
            da.Fill(dt)

            dgord.Item(6, ro).Style.ForeColor = Color.Black
            dgord.Item(7, ro).Style.ForeColor = Color.Black

            If dt.Rows.Count <> 0 Then

                dgord.Rows(ro).Cells("updated").Value = dt.Rows(0).Item("Updated") & ""
                dgord.Rows(ro).Cells("sch").Value = dt.Rows(0).Item("sch") & ""
                If Val(dt.Rows(0).Item("stk") & "") = -1 Then
                    dgord.Rows(ro).Cells("stk").Value = "Not Updated"
                Else
                    If (Val(dgord.Item(6, ro).Value & "") + Val(dgord.Item(7, ro).Value & "")) <= Val(dt.Rows(0).Item("stk") & "") Then
                        dgord.Rows(ro).Cells("stk").Value = "Available"
                        dgord.Item(6, ro).Style.ForeColor = Color.DarkGreen
                        dgord.Item(7, ro).Style.ForeColor = Color.DarkGreen
                    ElseIf Val(dt.Rows(0).Item("stk") & "") = 0 Then
                        dgord.Rows(ro).Cells("stk").Value = "Not in Stock"

                        dgord.Item(6, ro).Style.ForeColor = Color.Red
                        dgord.Item(7, ro).Style.ForeColor = Color.Red
                    Else
                        dgord.Rows(ro).Cells("stk").Value = "Insufficient Stock"

                        dgord.Item(6, ro).Style.ForeColor = Color.Red
                        dgord.Item(7, ro).Style.ForeColor = Color.Red
                    End If
                End If
                dgord.Rows(ro).Cells("dtf").Value = dt.Rows(0).Item("SchFrmDt") & ""
                dgord.Rows(ro).Cells("dtt").Value = dt.Rows(0).Item("SchtoDt") & ""
                CheckAvailability = True
            Else
                dgord.Rows(ro).Cells("updated").Value = ""
                dgord.Rows(ro).Cells("sch").Value = ""
                dgord.Rows(ro).Cells("stk").Value = "Data not available"
                dgord.Rows(ro).Cells("dtf").Value = ""
                dgord.Rows(ro).Cells("dtt").Value = ""
                CheckAvailability = False
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            CheckAvailability = False
        End Try

    End Function

    Private Sub BtnAvailability_Click(sender As System.Object, e As System.EventArgs) Handles BtnAvailability.Click
        Dim CMD1 As New SqlClient.SqlCommand
        Dim ini As Inifile
        Dim wclientid As String

        Try
            Me.Cursor = Cursors.WaitCursor


            If CheckPOPSConnection() = False Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            CMD1.Connection = PopsConn

            CMD1.CommandText = "SET QUOTED_IDENTIFIER OFF"
            CMD1.ExecuteNonQuery()
            CMD1.CommandText = "SET DATEFORMAT DMY"
            CMD1.ExecuteNonQuery()
            CMD1.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED"
            CMD1.ExecuteNonQuery()

            Dim i As Long
            Dim mapped As String
            wclientid = ""
            For i = 0 To dgord.Rows.Count - 2

                If chksup.Checked Then
                    If i = 0 Then
                        CMD1.Parameters.Add("@ClientId", SqlDbType.VarChar).Value = DeScriptRS(Firm.POPSClientID)
                        CMD1.Parameters.Add("@supcode", SqlDbType.VarChar).Value = CLng(Val(dgord.Rows(i).Cells(13).Value & ""))
                        CMD1.CommandType = CommandType.StoredProcedure
                        CMD1.CommandText = "CheckSupmaped"
                        wclientid = ""
                        wclientid = CMD1.ExecuteScalar() & ""
                        CMD1.Parameters.Clear()

                    ElseIf dgord.Rows(i - 1).Cells(13).Value & "" <> dgord.Rows(i).Cells(13).Value & "" Then
                        CMD1.Parameters.Add("@ClientId", SqlDbType.VarChar).Value = DeScriptRS(Firm.POPSClientID)
                        CMD1.Parameters.Add("@supcode", SqlDbType.VarChar).Value = dgord.Rows(i).Cells(13).Value & ""
                        CMD1.CommandType = CommandType.StoredProcedure
                        CMD1.CommandText = "CheckSupmaped"
                        wclientid = ""
                        wclientid = CMD1.ExecuteScalar() & ""
                        CMD1.Parameters.Clear()
                    End If

                ElseIf wclientid = "" Then

                    If cbsupp.Text = "" Then
                        MsgBox("Select a supplier", vbInformation)
                        Exit Sub
                    End If

                    CMD1.Parameters.Add("@ClientId", SqlDbType.VarChar).Value = DeScriptRS(Firm.POPSClientID)
                    CMD1.Parameters.Add("@supcode", SqlDbType.VarChar).Value = CLng(cbsupp.SelectedValue).ToString
                    CMD1.CommandType = CommandType.StoredProcedure
                    CMD1.CommandText = "CheckSupmaped"
                    wclientid = ""
                    wclientid = CMD1.ExecuteScalar() & ""
                    CMD1.Parameters.Clear()

                End If

                If wclientid = "" Then
                    dgord.Rows(i).Cells("sch").Value = "Supplier not maped"
                    dgord.Rows(i).Cells("stk").Value = "Supplier not maped"
                    dgord.Rows(i).Cells("dtf").Value = "'"
                    dgord.Rows(i).Cells("dtt").Value = ""
                    dgord.Rows(i).Cells("updated").Value = ""
                End If

                mapped = ""
                If wclientid <> "" Then
                    If dgord.Rows(i).Cells("Code").Value & "" <> "" Then
                        If CheckAvailability(dgord.Rows(i).Cells("Code").Value, wclientid, i) Then


                        Else
                            Me.Cursor = Cursors.Default
                            Me.Tag = ""
                            mapformr.Command1.Tag = DeScriptRS(Firm.POPSClientID)
                            mapformr.Text = "Maping Product...."
                            mapformr.lblsup.Text = dgord.Rows(i).Cells("supplier").Value
                            mapformr.lblprod.Text = dgord.Rows(i).Cells("prodname").Value & "  " & dgord.Rows(i).Cells("packing").Value
                            mapformr.lblprod.Tag = dgord.Rows(i).Cells("code").Value
                            mapformr.txtname.Text = ""
                            mapformr.Tag = wclientid
                            mapformr.ShowDialog()
                            mapformr.Command1.Tag = ""
                            mapformr.txtname.Focus()
                            mapped = mapformr.txtcode.Tag
                            mapformr.txtcode.Tag = ""
                            Me.Cursor = Cursors.WaitCursor
                            If mapped <> "" Then
                                If CheckAvailability(dgord.Rows(i).Cells("code").Value, wclientid, i) Then

                                Else
                                    dgord.Rows(i).Cells("sch").Value = "Product not maped"
                                    dgord.Rows(i).Cells("stk").Value = "Product not maped"
                                    dgord.Rows(i).Cells("dtf").Value = "'"
                                    dgord.Rows(i).Cells("dtt").Value = ""
                                    dgord.Rows(i).Cells("updated").Value = ""
                                End If
                            Else
                                dgord.Rows(i).Cells("sch").Value = "Product not maped"
                                dgord.Rows(i).Cells("stk").Value = "Product not maped"
                                dgord.Rows(i).Cells("dtf").Value = "'"
                                dgord.Rows(i).Cells("dtt").Value = ""
                                dgord.Rows(i).Cells("updated").Value = ""

                            End If

                        End If
                    End If
                End If

                'ordergrid.TextMatrix(i, 21) = ordergrid.TextMatrix(i, 2) & " " & ordergrid.TextMatrix(i, 4)

            Next
            PopsConn.Close()
            Me.Cursor = Cursors.Default
            dgord.Focus()
            dgord_CellEnter()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        PopsConn.Close()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = False
        grd.Visible = False
        Btpopsser.Text = "Search"
    End Sub

    Private Sub lblStk_TextChanged(sender As Object, e As System.EventArgs) Handles lblStk.TextChanged
        If lblStk.Text = "Available" Then
            lblStk.ForeColor = Color.LightGreen
        Else
            lblStk.ForeColor = Color.Red
        End If
    End Sub

    Private Sub dgord_Sorted(sender As Object, e As System.EventArgs) Handles dgord.Sorted
        Try
            If dgord.Rows.Count <> 0 Then
                If dgord.Rows(0).Cells("code").Value = "" Then dgord.Rows.RemoveAt(0)
                If dgord.Rows(dgord.Rows.Count - 1).Cells("code").Value = "" Then dgord.Rows.RemoveAt(dgord.Rows.Count - 1)
            End If
            dgord.Rows.Add()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgord_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgord.CellValueChanged
        If dgord.CurrentCell Is Nothing Then Exit Sub
        If dgord.CurrentCell.ColumnIndex = 4 Then

            If btnOrdGen.Visible = True Then Exit Sub
        End If
        If BtnAvailability.Visible = True Then Exit Sub
        If btnOrdGen.Visible = True Then Exit Sub
        If BtnShList.Visible = True Then Exit Sub
        Try
            If InStr("2,3,6,7,13,14", e.ColumnIndex & "") <> 0 Then
                dgord.Rows(e.RowIndex).Cells("stk").Value = ""
                dgord.Item(6, e.RowIndex).Style.ForeColor = Color.Black
                dgord.Item(7, e.RowIndex).Style.ForeColor = Color.Black
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpload_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpload.Click
        Upload.Show()
    End Sub

    Private Sub ChkSupliedCom_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkSupliedCom.CheckedChanged
        If ChkSupliedCom.Checked Then chkdom.Checked = False

        ShowCompany()
    End Sub

    Private Sub ShowCompanySupplied()
        Throw New NotImplementedException
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Btpopsser.Click
        Dim da As New SqlClient.SqlDataAdapter
        Dim tb As New DataTable
        Dim scmd As New SqlClient.SqlCommand
        Dim x As Long = 0
        Dim str As String

        Try

        If Btpopsser.Text = "Hide" Then
                grd.Visible = False
                BtpopsserCode.Text = "Search"
                Btpopsser.Text = "Search"
            Exit Sub
        End If

        x = InStr(lblprod.Text, " ") - 1
        str = ""
        grd.Visible = False
        If x <= 3 Then
            str = Microsoft.VisualBasic.Left(lblprod.Text, 3)

        Else

            str = Microsoft.VisualBasic.Left(lblprod.Text, x)

        End If

        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If str = "" Then Exit Sub
        scmd.Connection = PopsConn
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            ' dgord.Item(2, i).Value
            scmd.CommandText = "SELECT case   isnull(stk,-1)  when  '-1' then '-' when '0' then 'No' when '' then'-' else 'Yes' end as 'Stock',  products.prodname as [Product Name],Pkg as [Pack],rate as Rate,Sch as [Scheme],MRP,Users.name as [Distributor], Users.place as [Place],schfrmdt [Valid From],SchtoDt as [Valid to],company.name AS [Company],updated as [Updated On]  FROM company INNER JOIN products ON company.cmpcode = products.cmpcode AND company.clientid = products.clientid INNER JOIN Users ON  products.clientid = Users.id where " & _
                "ISNULL(POPSSTATE,'GOA')='GOA' and products.prodname like """ & str & _
                "%""   order by products.prodname,Sch desc"
        da.SelectCommand = scmd
        da.Fill(tb)
        grd.DataSource = tb

        Me.Cursor = Cursors.Default
        PopsConn.Close()
        If tb.Rows.Count > 0 Then
            grd.Visible = True
            Btpopsser.Text = "Hide"

        End If

        Catch ex As Exception
            MsgBox(ex.Message)
            grd.Visible = False
            Btpopsser.Text = "Search"
        End Try

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles BtpopsserCode.Click
        Dim da As New SqlClient.SqlDataAdapter
        Dim tb As New DataTable
        Dim scmd As New SqlClient.SqlCommand
        Dim x As Long = 0
        Dim str As String

        Try
            If dgord.CurrentCell Is Nothing Then Exit Sub

            If BtpopsserCode.Text = "Hide" Then
                grd.Visible = False
                BtpopsserCode.Text = "Search"
                Btpopsser.Text = "Search"
                Exit Sub
            End If

            grd.Visible = False

            If CheckPOPSConnection() = False Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            scmd.Connection = PopsConn
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            ' dgord.Item(2, i).Value
            scmd.CommandType = CommandType.StoredProcedure
            scmd.CommandText = "GetProductSearchGOA"
            scmd.Parameters.Add("@rclientid", SqlDbType.VarChar).Value = DeScriptRS(Firm.POPSClientID)
            scmd.Parameters.Add("@rprdcode", SqlDbType.VarChar).Value = dgord.Item(2, dgord.CurrentRow.Index).Value

            da.SelectCommand = scmd
            da.Fill(tb)
            grd.DataSource = tb
            grd.ResumeLayout()
            Me.Cursor = Cursors.Default
            PopsConn.Close()
            If tb.Rows.Count > 0 Then
                grd.Visible = True
                BtpopsserCode.Text = "Hide"

            End If
            grd.ResumeLayout()
        Catch ex As Exception
            MsgBox(ex.Message)
            grd.Visible = False
            Btpopsser.Text = "Search"
        End Try
    End Sub
End Class

'