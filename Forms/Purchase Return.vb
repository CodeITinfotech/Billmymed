
Public Class PurchaseReturn

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
    Private UseBarCode As Boolean
    Private sertime As DateTime
    Private sertxt As String
    Private ViewValue As Boolean

    Private Sub Purchase_Return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Me.BackColor '.MediumSeaGreen
            ToolStrip.Renderer = renderer
            ClearForm()
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Try
            Dim WD As Integer
            WD = 0
            cntrol.Location = dgPR.Location
            'cntrol.top = dgPR.Top
            'cntrol.left = dgPR.Left
            cntrol.top = dgPR.Top + dgPR.GetRowDisplayRectangle(dgPR.CurrentCell.RowIndex, True).Top
            cntrol.left = dgPR.Left + dgPR.GetColumnDisplayRectangle(dgPR.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgPR.GetColumnDisplayRectangle(dgPR.CurrentCell.ColumnIndex, True).Width
            cntrol.Text = dgPR.CurrentCell.Value & ""
            'cntrol.text = ""
            cntrol.Visible = True
            cntrol.Enabled = True
            cntrol.Focus()
            dgPR.Enabled = False
            'If dgPR.CurrentCell.RowIndex <> 12 And dgPR.CurrentCell.RowIndex <> 1 Then

            '    gridctrl.MaxLength = 5
            'Else
            '    gridctrl.MaxLength = 0
            '    gridctrl.Width = 0

            '    'gridctrl.Alignment = 0
            'End If
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
            Me.Cursor = Cursors.WaitCursor
            'dgRec.Enabled = True
            If Not flg Then
                cmd.CommandText = "select usebarcode from settings"
                UseBarCode = cmd.ExecuteScalar
                cmd.CommandText = "select Accode,Acmaster.Acname + ' ' + place as [Acname] from Acmaster where grpcode=" & SupGrpcode & " order by Acname + ' ' + place"
                da.SelectCommand = cmd
                da.Fill(DS, "Acmaster")
                cbPRsup.DisplayMember = "AcName"
                cbPRsup.ValueMember = "AcCode"
                cbPRsup.DataSource = DS.Tables("Acmaster")
                cbPRsup.SelectedValue = 0
                'If Not IsDate(txtPrdate.Text) Then
                'txtPrdate.Text = Format(SysDt, DateFormat)
                'Else

                'End If

                lbldate.Text = Format(SysDt, DateFormat)

                cmd1.CommandText = "select slno from serialnum where type='41'"
                'cmd1.CommandText = "select purretno from settings"
                dr = cmd1.ExecuteReader
                dr.Read()

                lblprno.Text = dr(0) + 1
                dr.Close()
                lstcom.Items.Clear()
            End If

            dgPR.Rows.Clear()
            dgPR.Rows.Add()
            EditFlag = False
            dgPR.Enabled = True
            dgPR.Columns(3).Visible = UseBarCode
            gridctrl.Visible = False
            lbltot.Text = "0.00"
            pnlViewValue.Visible = False
            ViewValue = False
            Me.Cursor = Cursors.Default
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Sub

    Private Sub cbPRsup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPRsup.SelectedIndexChanged
        lstcom.Items.Clear()
        ShowCompany()
        chksup.Checked = False
    End Sub

    Public Sub ShowCompany()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim cmd As New OleDb.OleDbCommand
            Dim reader As OleDb.OleDbDataReader
            Dim cb1 As CheckedListBox.ObjectCollection
            cmd.Connection = Conn
            cmd.CommandText = "Select company.comCode,comName as [Company Name] from company,supcom where supcom.comcode=company.comcode and supcom.supcode=" & Val(cbPRsup.SelectedValue) & "  order by comname"
            reader = cmd.ExecuteReader
            Me.Cursor = Cursors.WaitCursor
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
            tmpmemo = ""
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
        Me.Cursor = Cursors.Default
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
            If tmpmemo <> "" Then btnPRgen.Enabled = True
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
            btnPRgen.Enabled = False
            dclick = 0
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub ExpColor(ByVal i As Integer)
        Try
            Dim nds As Long
            dgPR.Item(6, i).Style.ForeColor = Color.Black

            If dgPR.Item(6, i).Value & "" <> "" Then
                If IsDate(dgPR.Item(6, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgPR.Item(6, i).Value)
                    If nds < 0 Then
                        dgPR.Item(6, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgPR.Item(6, i).Style.ForeColor = Color.DarkRed
                    End If
                End If
            End If

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub Calculate()
        Dim tot As Double
        For i = 0 To dgPR.Rows.Count - 1
            tot = tot + ((Val(dgPR.Item(9, i).Value & "") + Val(dgPR.Item(10, i).Value & "")) * Val(dgPR.Item(20, i).Value & ""))
        Next
        lbltot.Text = Format(tot, "0.00")
    End Sub

    Private Sub btnPRgen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRgen.Click
        Dim rt As Double
        Dim rmk As String

        Try
            If EditFlag Then
                If MsgBox("Can't Generate while editing.") Then
                    Exit Sub
                End If
            End If

            Dim cmd As New OleDb.OleDbCommand
            Dim reader As OleDb.OleDbDataReader

            Dim dt As DateTime
            cmd.Connection = Conn

            'dgPR.Refresh()

            dgPR.Rows.Clear()
            gridctrl.Visible = False

            If Not IsDate(txtPrdate.Text) And cbPRexpprod.Checked Then
                MsgBox("Invalid Date..", vbInformation)
                txtPrdate.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Generate_PRtn"

            cmd.Parameters.Add("@tmpmemo", OleDb.OleDbType.VarChar).Value = tmpmemo & ""

            If chksup.Checked = True Then
                cmd.Parameters.Add("@prallsup", OleDb.OleDbType.Boolean).Value = 1
            Else
                cmd.Parameters.Add("@prallsup", OleDb.OleDbType.Boolean).Value = 0
            End If

            cmd.Parameters.Add("@supcode", OleDb.OleDbType.VarChar).Value = Val(cbPRsup.SelectedValue)

            If cbPRexpprod.Checked = True Then
                cmd.Parameters.Add("@prexpprod", OleDb.OleDbType.Boolean).Value = 1
            Else
                cmd.Parameters.Add("@prexpprod", OleDb.OleDbType.Boolean).Value = 0
            End If

            If cbPRbrk.Checked = True Then
                cmd.Parameters.Add("@prbrk", OleDb.OleDbType.Boolean).Value = 1
            Else
                cmd.Parameters.Add("@prbrk", OleDb.OleDbType.Boolean).Value = 0
            End If

            If cbslmove.Checked = True And Val(txtslmove.Text) <> 0 Then
                cmd.Parameters.Add("@prsmove", OleDb.OleDbType.Boolean).Value = 1
            Else
                cmd.Parameters.Add("@prsmove", OleDb.OleDbType.Boolean).Value = 0
            End If

            If cbPRexpprod.Checked = True Then
                cmd.Parameters.Add("@exdt", OleDb.OleDbType.DBDate).Value = CDate(txtPrdate.Text)
            Else
                cmd.Parameters.Add("@exdt", OleDb.OleDbType.DBDate).Value = CDate("01/01/1950")
            End If

            If cbslmove.Checked = True And Val(txtslmove.Text) <> 0 Then
                cmd.Parameters.Add("@smovedt", OleDb.OleDbType.DBDate).Value = Microsoft.VisualBasic.DateAdd(DateInterval.Day, Val(txtslmove.Text), SysDt)
            Else
                cmd.Parameters.Add("@smovedt", OleDb.OleDbType.DBDate).Value = CDate("01/01/1950")
            End If

            reader = cmd.ExecuteReader

            Dim r As Integer = 0
            If reader.HasRows Then

                While reader.Read
                    If reader.Item("BrkQty") + reader.Item("ExpQty") = 0 Then GoTo NextProd
                    dgPR.Rows.Add()
                    dgPR.Item(0, r).Value = r + 1

                    dgPR.Item(1, r).Value = 1 ' reader.Item("PrdCode")
                    dgPR.Item(2, r).Value = reader.Item("batchid")

                    dgPR.Item(3, r).Value = reader.Item("PrdCode")
                    dgPR.Item(4, r).Value = reader.Item("PrdName")
                    dgPR.Item(5, r).Value = reader.Item("Batch")
                    If IsDate(reader.Item("ExDt")) Then
                        dgPR.Item(6, r).Value = Format(reader.Item("ExDt"), DateFormat)
                    Else
                        dgPR.Item(6, r).Value = ""
                    End If
                    ExpColor(r)
                    If optsr.Checked Then
                        rt = reader.Item("Srate")
                    Else
                        rt = reader.Item("prate")
                        If chincdisc.Checked Then
                            rt = rt - (rt * reader.Item("pdis") / 100)
                            rt = rt - (rt * reader.Item("bdis") / 100)
                        End If
                        If chinctax.Checked Then
                            rt = rt + (rt * reader.Item("ptax") / 100)
                        End If
                    End If
                    rmk = ""
                    If reader.Item("ExpQty") <> 0 Then
                        rmk = "Expiry"
                    End If

                    If reader.Item("BrkQty") <> 0 Then
                        rmk = rmk & " " & "Breakage"
                    End If

                    dgPR.Item(7, r).Value = Format(reader.Item("Prate"), "0.00")
                    dgPR.Item(8, r).Value = Format(reader.Item("Srate"), "0.00")
                    dgPR.Item(9, r).Value = reader.Item("BrkQty")
                    dgPR.Item(10, r).Value = reader.Item("ExpQty")
                    dgPR.Item(12, r).Value = reader.Item("case1")
                    dgPR.Item(14, r).Value = reader.Item("billno")
                    If IsDBNull(reader.Item("billdt")) Then
                        dgPR.Item(15, r).Value = ""
                    Else
                        dgPR.Item(15, r).Value = Format(reader.Item("billdt"), DateFormat)
                    End If


                    dgPR.Item(16, r).Value = rmk

                    dgPR.Item(17, r).Value = reader.Item("supcode")
                    dgPR.Item(18, r).Value = reader.Item("acname") & "  " & reader.Item("place")
                    ' dgPR.Item(19, r).Value = 
                    dgPR.Item(20, r).Value = Format(rt, "0.00")


                    r = r + 1
NextProd:
                End While
                dgPR.Rows.Add()

                cmd.Parameters.Clear()
            Else
                dgPR.Rows.Add()
            End If
            reader.Close()
            dgPR.Enabled = True
            dgPR.Refresh()
            dgPR.Focus()
            Calculate()
            'Exit Sub

            Me.Cursor = Cursors.Default

        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
        Me.Cursor = Cursors.Default
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
                    btnPRgen.Enabled = False
                Else
                    btnPRgen.Enabled = True
                End If
            End If

        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try

        'Try

        '    Dim i As Integer
        '    Dim mList As MyList
        '    ' mList = lstsup.Items(lstsup.SelectedIndex)

        '    'MsgBox(mList.ItemData)
        '    If Not sclick = 1 And Not dclick = 1 Then
        '        tmpmemo = ";"
        '        For i = 0 To lstsup.Items.Count - 1
        '            MessageBox.Show(lstsup.GetItemChecked(i))
        '            'tmpmemo = ";" & tmpmemo & lstsup.Items(i) & ";"
        '            If lstsup.GetItemChecked(i) = True Then
        '                mList = lstsup.Items(lstsup.SelectedIndex)
        '                tmpmemo = ";" & tmpmemo & mList.ItemData() & ";"
        '                'btnPRgen.Enabled = True

        '            End If
        '        Next
        '    End If
        '    If tmpmemo = ";" Then
        '        btnPRgen.Enabled = False
        '    Else
        '        If cbPRbrk.Checked = True Or cbPRexpprod.Checked = True Or cbPRslwday.Checked = True Then btnPRgen.Enabled = True
        '    End If

        'Catch d As Exception
        '    MessageBox.Show(d.Message)
        'End Try
    End Sub

    Private Sub dgPR_DoubleClick() Handles dgPR.DoubleClick
        EditGrid()
    End Sub

    Public Sub EditGrid()
        Try
            Dim EDROW As Integer = dgPR.CurrentCell.RowIndex
            Dim EDCOL As Integer = dgPR.CurrentCell.ColumnIndex

            If dgPR.CurrentCell.ColumnIndex <= 5 And dgPR.Item(3, dgPR.CurrentRow.Index).Value & "" <> "" Then
                Exit Sub
            End If

            If dgPR.CurrentCell.ColumnIndex = 3 Or dgPR.CurrentCell.ColumnIndex = 4 Or dgPR.CurrentCell.ColumnIndex = 9 Or dgPR.CurrentCell.ColumnIndex = 10 Or dgPR.CurrentCell.ColumnIndex = 11 Then
                If dgPR.Item(3, dgPR.CurrentRow.Index).Value & "" = "" And dgPR.CurrentCell.ColumnIndex > 4 Then
                    dgPR.CurrentCell = dgPR.Item(4, dgPR.CurrentRow.Index)
                    ShowEditControl(gridctrl)
                    Exit Sub
                End If

                If dgPR.CurrentCell.ColumnIndex > 4 And dgPR.Item(3, dgPR.CurrentCell.RowIndex).Value & " " = " " Then
                    dgPR.Columns(4).Selected = True
                    dgPR.CurrentCell = dgPR.Item(dgPR.CurrentCell.ColumnIndex, dgPR.CurrentRow.Index)
                    ShowEditControl(gridctrl)
                    Exit Sub
                End If

                dgPR.CurrentCell = dgPR.Item(dgPR.CurrentCell.ColumnIndex, dgPR.CurrentRow.Index)
                ShowEditControl(gridctrl)
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
                End If
                cmd.Parameters.Clear()
            End If
            Prodgrid.Visible = False
            obj.focus()

        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub RowClear()
        For i As Integer = 0 To dgPR.ColumnCount - 1
            dgPR.Item(i, dgPR.CurrentRow.Index).Value = ""
        Next
    End Sub

    Private Sub gridctrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridctrl.KeyPress
        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim EDROW As Integer
            Dim EDCOL As Integer
            Dim qt As Long
            Dim txtc As String
            Dim reader As OleDb.OleDbDataReader
            cmd.Connection = Conn

            If Asc(e.KeyChar) = 27 Then
                If dgPR.CurrentRow.Index = dgPR.RowCount - 1 Then
                    RowClear()
                    gridctrl.Text = ""
                    gridctrl.Visible = False
                    dgPR.Enabled = True
                    dgPR.Focus()
                Else
                    gridctrl.Visible = False
                    dgPR.Enabled = True
                    dgPR.Focus()
                End If
            End If

            If Asc(e.KeyChar) = 13 Then

                If dgPR.CurrentCell.ColumnIndex = 9 Or dgPR.CurrentCell.ColumnIndex = 10 Or dgPR.CurrentCell.ColumnIndex = 11 Then
                    txtc = ""
                    Select Case dgPR.CurrentCell.ColumnIndex
                        Case 9
                            txt = "Brkqty"
                            txtc = "Breakage Qty."
                            qt = Val(gridctrl.Text)
                        Case 10
                            txt = "Stock"
                            txtc = "Stock"
                            qt = Val(gridctrl.Text) + Val(dgPR.Item(9, dgPR.CurrentCell.RowIndex).Value & "")
                        Case 11
                            txt = "Stock"
                            qt = Val(gridctrl.Text) + Val(dgPR.Item(10, dgPR.CurrentCell.RowIndex).Value & "")
                    End Select
                    If Val(dgPR.CurrentRow.Cells(2).Value & "") <> 0 Then
                        cmd.CommandText = "select " & txt & " from batch where batchid=" & dgPR.CurrentRow.Cells(2).Value & ""
                        reader = cmd.ExecuteReader
                        reader.Read()

                        If reader(0) < qt Then
                            pnlbatch.Visible = False
                            MessageBox.Show("Insufficient " & txtc & "..")
                            gridctrl.Focus()

                            reader.Close()
                            Exit Sub
                        End If
                        reader.Close()
                    End If
                    dgPR.Item(dgPR.CurrentCell.ColumnIndex, dgPR.CurrentRow.Index).Value = gridctrl.Text

                    If dgPR.CurrentRow.Index = dgPR.RowCount - 1 Then
                        gridctrl.Visible = False
                        dgPR.CurrentCell = dgPR.CurrentRow.Cells(16)
                        dgPR.FirstDisplayedScrollingColumnIndex = 16
                        dgPR.Focus()
                        ShowEditControl(gridctrl)
                        Exit Sub
                    Else
                        Calculate()
                    End If
                ElseIf dgPR.CurrentCell.ColumnIndex = 16 Then
                    dgPR.Item(dgPR.CurrentCell.ColumnIndex, dgPR.CurrentRow.Index).Value = gridctrl.Text
                    If dgPR.CurrentRow.Index = dgPR.RowCount - 1 Then
                        If dgPR.CurrentCell.RowIndex = dgPR.Rows.Count - 1 Then
                            gridctrl.Visible = False
                            dgPR.Rows.Add()
                            dgPR.CurrentCell = dgPR.Item(4, dgPR.Rows.Count - 1)
                            dgPR.FirstDisplayedScrollingColumnIndex = 0

                            dgPR.Enabled = True

                            Prodgrid.Visible = False
                            dgPR.Focus()
                            Calculate()
                            EditGrid()
                        Else
                            gridctrl.Visible = False
                            dgPR.CurrentCell = dgPR.Item(1, dgPR.Rows.Count - 1)
                            EDROW = dgPR.CurrentCell.RowIndex
                            EDCOL = dgPR.CurrentCell.ColumnIndex
                            dgPR.Focus()
                            EditGrid()
                            gridctrl.SelectAll()
                        End If
                        Exit Sub

                    End If

                ElseIf dgPR.CurrentCell.ColumnIndex = 3 Then
                    If gridctrl.Text = "" Then
                        dgPR.CurrentCell = dgPR.Item(4, dgPR.CurrentCell.RowIndex)

                        dgPR.Focus()
                        EditGrid()
                        Exit Sub
                    Else
                        GetBarCode()
                        Exit Sub

                    End If

                ElseIf dgPR.CurrentCell.ColumnIndex = 4 Then
                    If gridctrl.Text = "" Then
                        dgPR.CurrentCell = dgPR.Item(3, dgPR.CurrentCell.RowIndex)

                        dgPR.Focus()
                        EditGrid()
                        Exit Sub
                    End If
                End If

                gridctrl.Visible = False
                dgPR.Enabled = True
                dgPR.Focus()
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


            cmd.Connection = Conn

            tsbSave.Enabled = False
            'Check for the stock if present

            cmd.Connection = Conn
            cmd.CommandText = "Select product.PrdCode,prdname,product.case1,product.case2,product.unit2 from Barcodes,product where  product.prdcode=barcodes.prdcode  and BarCode=""" & gridctrl.Text & """ "
            dataredr = cmd.ExecuteReader

            If dataredr.HasRows Then
                dataredr.Read()

                Try
                    Dim cmd1 As New OleDb.OleDbCommand

                    Dim da As New OleDb.OleDbDataAdapter
                    Dim i As Integer = 0

                    Prodgrid.Visible = False
                    dgPR.CurrentRow.Cells(4).Value = dataredr(1)
                    lblname.Text = dataredr(1)
                    lblpack.Text = dataredr(2) & "   " & dataredr(3) & "(" & dataredr(4) & ")"
                    gridctrl.Visible = False

                    dgPR.CurrentRow.Cells(3).Value = dataredr(0)
                    cmd1.Connection = Conn
                    cmd1.CommandType = CommandType.Text

                    '(Batch.RQty+Batch.RepQty) AS [RQty] in palce Batch.PCST as [P CST] in the query
                    'Batch.FQty in place of Batch.PSch in the query

                    cmd1.CommandText = "SELECT  Batch.Batch as Batch,CONVERT(varchar, Batch.ExDt, 103) AS ExDt," & _
                            "Batch.Stock as Stock, Product.case1 as Case1,  CONVERT(numeric(18,3), Batch.PRate) AS [P Rate], " & _
                            "CONVERT(numeric(18,2), Batch.Ptax) AS [P VAT], (Batch.RQty+Batch.RepQty) AS [RQty],Batch.FQty," & _
                            "CONVERT(numeric(18,2), Batch.PDis) AS PDisc, CONVERT(numeric(18, 2), Batch.BDis) AS BDisc," & _
                            "CONVERT(numeric(18, 3), Batch.SRate) AS [S Rate], CONVERT(numeric(18, 2), Batch.SCST) AS [S CST]," & _
                            "CONVERT(numeric(18, 2), Batch.Stax) AS [S VAT], Batch.BillNo as [Bill No], " & _
                            "CONVERT(varchar, Batch.BillDt, 103) AS [Bill Dt], Batch.BatchId as Batchid,Product.unit1," & _
                            "Product.unit2,Product.case1,Product.case2,Batch.SupCode " & _
                            "FROM  Batch INNER JOIN Product ON Batch.PrdCode = Product.PrdCode " & _
                            "WHERE  (Batch.PrdCode = """ + dataredr(0) + """ ) AND (Batch.Supcode = " & Val(cbPRsup.SelectedValue) & ") and Batch.Stock > 0"

                    da.SelectCommand = cmd1

                    da.Fill(ds, "Batch")
                    If ds.Tables("batch").Rows.Count = 0 Then
                        MsgBox("No Stock/Product Not Supplied by Selected Supplier..", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                        dgPR.CurrentRow.Cells(4).Value = ""
                        dgPR.CurrentRow.Cells(3).Value = ""
                        gridctrl.Visible = True
                        gridctrl.Text = ""
                        gridctrl.Focus()
                        Exit Sub
                    End If

                    batchgrid.DataSource = ds.Tables("batch")

                    pnlbatch.Visible = True
                    batchgrid.Focus()
                    dgPR.Enabled = False
                    gridctrl.Enabled = False
                    batchgrid.Focus()
                    cmd1.Parameters.Clear()

                    Exit Sub
                Catch d As Exception
                    MessageBox.Show(d.Message)

                End Try
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

    Private Sub gridctrl_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridctrl.TextChanged
        Try
            If dgPR.CurrentRow.Cells(4).Selected = True Then
                obj = gridctrl
                Populate()
            End If
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub Prodgrid_DoubleClick() Handles Prodgrid.DoubleClick

        Try
            Dim cmd1 As New OleDb.OleDbCommand


            Dim ds As New DataSet
            Dim da As New OleDb.OleDbDataAdapter
            Dim i As Integer = 0
            Dim NOSUP As Boolean = False
            Prodgrid.Visible = False
            dgPR.CurrentRow.Cells(4).Value = Prodgrid.CurrentRow.Cells(1).Value
            lblname.Text = Prodgrid.CurrentRow.Cells(1).Value
            lblpack.Text = Prodgrid.CurrentRow.Cells(3).Value & "   " & Prodgrid.CurrentRow.Cells(4).Value
            gridctrl.Visible = False

            dgPR.CurrentRow.Cells(3).Value = Prodgrid.CurrentRow.Cells(0).Value
            cmd1.Connection = Conn
            cmd1.CommandType = CommandType.Text

            '(Batch.RQty+Batch.RepQty) AS [RQty] in palce Batch.PCST as [P CST] in the query
            'Batch.FQty in place of Batch.PSch in the query

            cmd1.CommandText = "SELECT  Batch.Batch as Batch,CONVERT(varchar, Batch.ExDt, 103) AS ExDt," & _
                    "Batch.Stock as Stock, Product.case1 as Case1,  CONVERT(numeric(18,3), Batch.PRate) AS [P Rate], " & _
                    "CONVERT(numeric(18,2), Batch.Ptax) AS [P VAT], (Batch.RQty+Batch.RepQty) AS [RQty],Batch.FQty," & _
                    "CONVERT(numeric(18,2), Batch.PDis) AS PDisc, CONVERT(numeric(18, 2), Batch.BDis) AS BDisc," & _
                    "CONVERT(numeric(18, 3), Batch.SRate) AS [S Rate], CONVERT(numeric(18, 2), Batch.SCST) AS [S CST]," & _
                    "CONVERT(numeric(18, 2), Batch.Stax) AS [S VAT], Batch.BillNo as [Bill No], " & _
                    "CONVERT(varchar, Batch.BillDt, 103) AS [Bill Dt], Batch.BatchId as Batchid,Product.unit1," & _
                    "Product.unit2,Product.case1,Product.case2,Batch.SupCode " & _
                    "FROM  Batch INNER JOIN Product ON Batch.PrdCode = Product.PrdCode " & _
                    "WHERE  (Batch.PrdCode = """ + dgPR.CurrentRow.Cells(3).Value + """ ) AND (Batch.Supcode = " & Val(cbPRsup.SelectedValue) & ") and Batch.Stock > 0"
            da.SelectCommand = cmd1

            da.Fill(ds, "Batch")
            If ds.Tables("batch").Rows.Count = 0 Then
                'If MsgBox("No Stock/Product Not Supplied by Selected Supplier..", vbYesNo + vbDefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                '    dgPR.CurrentRow.Cells(4).Value = ""
                '    dgPR.CurrentRow.Cells(3).Value = ""
                '    gridctrl.Visible = True
                '    gridctrl.Text = ""
                '    gridctrl.Focus()
                '    Exit Sub
                'End If
                NOSUP = True
                cmd1.CommandText = "SELECT  Batch.Batch as Batch,CONVERT(varchar, Batch.ExDt, 103) AS ExDt," & _
                        "Batch.Stock as Stock, Product.case1 as Case1,  CONVERT(numeric(18,3), Batch.PRate) AS [P Rate], " & _
                        "CONVERT(numeric(18,2), Batch.Ptax) AS [P VAT], (Batch.RQty+Batch.RepQty) AS [RQty],Batch.FQty," & _
                        "CONVERT(numeric(18,2), Batch.PDis) AS PDisc, CONVERT(numeric(18, 2), Batch.BDis) AS BDisc," & _
                        "CONVERT(numeric(18, 3), Batch.SRate) AS [S Rate], CONVERT(numeric(18, 2), Batch.SCST) AS [S CST]," & _
                        "CONVERT(numeric(18, 2), Batch.Stax) AS [S VAT], Batch.BillNo as [Bill No], " & _
                        "CONVERT(varchar, Batch.BillDt, 103) AS [Bill Dt], Batch.BatchId as Batchid,Product.unit1," & _
                        "Product.unit2,Product.case1,Product.case2,Batch.SupCode " & _
                        "FROM  Batch INNER JOIN Product ON Batch.PrdCode = Product.PrdCode " & _
                        "WHERE  (Batch.PrdCode = """ + dgPR.CurrentRow.Cells(3).Value + """ ) AND  Batch.Stock > 0"

                da.SelectCommand = cmd1
                da.Fill(ds, "Batch")
            End If

            If ds.Tables("batch").Rows.Count = 0 Then
                MsgBox("No Stock... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                dgPR.CurrentRow.Cells(4).Value = ""
                dgPR.CurrentRow.Cells(3).Value = ""
                gridctrl.Visible = True
                gridctrl.Text = ""
                gridctrl.Focus()
                Exit Sub
            End If
            If NOSUP Then
                If MsgBox("No Stock/Product Not Supplied by Selected Supplier..", vbYesNo + vbDefaultButton2 + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    dgPR.CurrentRow.Cells(4).Value = ""
                    dgPR.CurrentRow.Cells(3).Value = ""
                    gridctrl.Visible = True
                    gridctrl.Text = ""
                    gridctrl.Focus()
                    Exit Sub
                End If
                NOSUP = True
            End If



            batchgrid.DataSource = ds.Tables("batch")


            pnlbatch.Visible = True
            batchgrid.Focus()
            dgPR.Enabled = False
            gridctrl.Enabled = False


            cmd1.Parameters.Clear()
            'End If

        Catch d As Exception
            MessageBox.Show(d.Message)

        End Try
    End Sub

    Private Sub batchgrid_DoubleClick() Handles batchgrid.DoubleClick
        Try
            Dim cmd As New OleDb.OleDbCommand

            SelectBatch()
        Catch d As Exception
            MessageBox.Show(d.Message)
        End Try
    End Sub

    Private Sub dgPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgPR.KeyDown
        Dim dec As DialogResult

        Dim i, vi, vii, v As Integer


        If e.KeyCode = Keys.Escape Then
            gridctrl.Visible = False
            dgPR.Focus()
            dgPR.Enabled = True
            e.Handled = True
        End If

        If e.KeyCode = Keys.Delete And dgPR.CurrentRow.Index < dgPR.Rows.Count - 1 Then



            dec = MessageBox.Show("Want to delete selected products ?", " ", MessageBoxButtons.YesNo)
            If dec = Windows.Forms.DialogResult.No Then
                dgPR.Focus()
                Exit Sub
            End If


            For i = 0 To dgPR.Rows.Count - 1
                totprval = totprval + Val(dgPR.Item(9, dgPR.CurrentRow.Index).Value)
            Next

            vi = dgPR.SelectedCells(0).RowIndex
            vii = dgPR.SelectedCells(dgPR.SelectedCells.Count - 1).RowIndex

            If vi > vii Then
                v = vii
                vii = vi
                vi = v
            End If

            For i = vi To vii
                If dgPR.Item(1, vi).Value & "" <> "" Then dgPR.Rows.Remove(dgPR.Rows(vi))
            Next


            For i = vi To dgPR.Rows.Count - 2
                dgPR.Item(0, i).Value = i + 1 'Val(dgPR.Item(0, i).Value) - 1
            Next
            Calculate()
            e.Handled = True
        End If



        If e.KeyCode = Keys.Enter Then

            dgPR_DoubleClick()

            e.Handled = True
        End If
    End Sub

    Public Sub deleterow(ByVal delcol As Integer)
        Dim i As Integer
        If dgPR.Rows.Count > 2 Then
            dgPR.Rows.Remove(dgPR.Rows(delcol))
        Else
            dgPR.CurrentRow.Cells(0).Value = ""
            dgPR.CurrentRow.Cells(1).Value = ""
            dgPR.CurrentRow.Cells(2).Value = ""
            dgPR.CurrentRow.Cells(3).Value = ""
            dgPR.CurrentRow.Cells(4).Value = ""
            dgPR.CurrentRow.Cells(5).Value = ""
            dgPR.CurrentRow.Cells(6).Value = ""
            dgPR.CurrentRow.Cells(7).Value = ""
            dgPR.CurrentRow.Cells(8).Value = ""
            dgPR.CurrentRow.Cells(9).Value = ""
            dgPR.CurrentRow.Cells(10).Value = ""
        End If

        For i = 1 To dgPR.Rows.Count - 1
            dgPR.Item(0, i).Value = i
        Next i

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
                Prodgrid.Visible = False : obj.Focus() : pnlbatch.Visible = False : Exit Sub
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
        If chksup.Checked = True Then
            cbPRsup.SelectedValue = 0
            cbPRsup.Text = ""
            cbPRsup.SelectedText = ""
            cbPRsup.Enabled = False
            lstcom.Enabled = False
        Else
            cbPRsup.Enabled = True
            lstcom.Enabled = True
        End If
    End Sub

    Private Sub tbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        Dim Trn As Boolean
        Dim tmpsupcode As Long
        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        Dim StNum As Long
        Dim CurDt As Date
        Dim i As Integer
        Dim curno As Long
        Dim stk As Long

        If EditFlag Then
            If CheckUserLocked("Edit Purchase Return", , IIf(EditFlag, EditDate, Nothing)) = False Then Exit Sub
        End If


        Dim Brqty, exqty, prqty, fqty As Long
        Me.Cursor = Cursors.WaitCursor
        'Dim reader As OleDb.OleDbDataReader
        Dim ednum As Integer

        Try


            Trn = False
            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn
            Trn = True

            CurDt = SysDt
            If EditFlag Then
                cmd.CommandText = "Cancel_PurchaseRtn"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@prno", OleDb.OleDbType.BigInt).Value = EditNum
                cmd.Parameters.Add("@prdtt", OleDb.OleDbType.DBDate).Value = EditDate
                cmd.Parameters.Add("@prdtf", OleDb.OleDbType.DBDate).Value = EditDate
                cmd.ExecuteNonQuery()
                CurDt = EditDate
                curno = EditNum
            End If


            StNum = 0
            tmpsupcode = -1
            If chksup.Checked Then

                dgPR.Sort(dgPR.Columns(18), System.ComponentModel.ListSortDirection.Descending)
            End If

            For i = 0 To dgPR.Rows.Count - 2

                Brqty = 0
                exqty = 0
                fqty = 0
                prqty = 0

                Brqty = Val(dgPR.Item(9, i).Value) * Val((dgPR.Item(1, i).Value))
                exqty = Val(dgPR.Item(10, i).Value) * Val((dgPR.Item(1, i).Value))
                fqty = Val(dgPR.Item(11, i).Value) * Val((dgPR.Item(1, i).Value))

                If exqty + fqty + Brqty = 0 Then GoTo Last
                prqty = exqty + fqty

                If EditFlag = False Then
                    If tmpsupcode <> Val(dgPR.Item(17, i).Value & "") Then
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "update serialnum set slno=slno+1 where type='41'"
                        'cmd.CommandText = "update settings set purretno=purretno+1"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "select slno from serialnum where type='41'"
                        dataredr = cmd.ExecuteReader()
                        dataredr.Read()
                        curno = dataredr(0)
                        dataredr.Close()
                        If StNum = 0 Then StNum = curno
                        ednum = curno
                        lblprno.Text = curno
                    End If
                End If

                If curno = 0 Then
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "update serialnum set slno=slno+1 where type='41'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select slno from serialnum where type='41'"
                    curno = Val(cmd.ExecuteScalar & "")
                    lblprno.Text = curno
                End If


                If exqty + fqty <> 0 Then
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "select stock from batch where batchid=" & Val(dgPR.Item(2, i).Value)
                    stk = cmd.ExecuteScalar

                    If stk < (exqty + fqty) Then
                        ' MsgBox("Insufficiant Stock for the Product " & dgPR.Item(4, i).Value, MsgBoxStyle.Information)
                        Throw New Exception("Insufficiant Stock for the Product : " & dgPR.Item(4, i).Value)

                    End If
                End If


                If Brqty <> 0 Then
                    cmd.CommandText = "select brkqty from batch where batchid=" & Val(dgPR.Item(2, i).Value)
                    stk = cmd.ExecuteScalar

                    If stk < (Brqty) Then
                        MsgBox("Insufficiant Breakage Qty. for the Product " & dgPR.Item(4, i).Value, MsgBoxStyle.Information)
                        Throw New Exception(" Insufficiant Stock for the Product " & dgPR.Item(4, i).Value)
                    End If
                End If


                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "insert_PurchaseRtn"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@curno", OleDb.OleDbType.Integer).Value = Val(curno)
                cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate).Value = CurDt
                cmd.Parameters.Add("@code", OleDb.OleDbType.VarChar).Value = dgPR.Item(3, i).Value
                If chksup.Checked = False Then
                    cmd.Parameters.Add("@supcode", OleDb.OleDbType.Integer).Value = Val(cbPRsup.SelectedValue)
                Else
                    cmd.Parameters.Add("@supcode", OleDb.OleDbType.Integer).Value = Val(dgPR.Item(17, i).Value & "")
                End If

                cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = dgPR.Item(5, i).Value

                If IsDate(dgPR.Item(6, i).Value & "") Then
                    cmd.Parameters.Add("@exdt", OleDb.OleDbType.DBDate).Value = CDate(dgPR.Item(6, i).Value)
                Else
                    cmd.Parameters.Add("@exdt", OleDb.OleDbType.DBDate).Value = System.DBNull.Value
                End If

                cmd.Parameters.Add("@exqty", OleDb.OleDbType.Numeric).Value = exqty
                cmd.Parameters.Add("@brqty", OleDb.OleDbType.Numeric).Value = Brqty
                cmd.Parameters.Add("@fqty", OleDb.OleDbType.Numeric).Value = fqty
                If IsDate(dgPR.Item(15, i).Value & "") Then
                    cmd.Parameters.Add("@billdt", OleDb.OleDbType.DBDate).Value = CDate(dgPR.Item(15, i).Value)
                Else
                    cmd.Parameters.Add("@billdt", OleDb.OleDbType.DBDate).Value = System.DBNull.Value
                End If

                cmd.Parameters.Add("@billno", OleDb.OleDbType.VarChar).Value = dgPR.Item(14, i).Value & ""
                cmd.Parameters.Add("@pack", OleDb.OleDbType.VarChar).Value = dgPR.Item(12, i).Value
                cmd.Parameters.Add("@unit", OleDb.OleDbType.Integer).Value = Val(dgPR.Item(1, i).Value)
                cmd.Parameters.Add("@remark", OleDb.OleDbType.VarChar).Value = dgPR.Item(16, i).Value
                cmd.Parameters.Add("@batchid", OleDb.OleDbType.Integer).Value = Val(dgPR.Item(2, i).Value)
                cmd.Parameters.Add("@srate", OleDb.OleDbType.Numeric).Value = Val(dgPR.Item(8, i).Value)
                cmd.Parameters.Add("@rate", OleDb.OleDbType.Numeric).Value = Val(dgPR.Item(20, i).Value & "")
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()

                'updating stock
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Update_BatchPurRtn"
                cmd.Parameters.Add("@qty", OleDb.OleDbType.Numeric).Value = exqty
                cmd.Parameters.Add("@Free", OleDb.OleDbType.Numeric).Value = fqty
                cmd.Parameters.Add("@BrQty", OleDb.OleDbType.Numeric).Value = Brqty
                cmd.Parameters.Add("@batchid", OleDb.OleDbType.BigInt).Value = Val(dgPR.Item(2, i).Value)
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
last:
                tmpsupcode = Val(dgPR.Item(17, i).Value & "")
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

    Private Sub batchgrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batchgrid.DoubleClick
        SelectBatch()
    End Sub

    Private Sub txtPrdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ExpDateCheck(txtPrdate, True, False) Then

            End If
        End If
    End Sub

    Private Sub SelectBatch()
        Dim rt As Double
        With dgPR
            .Item(0, .RowCount - 1).Value = .RowCount '- 1
            .Item(1, .RowCount - 1).Value = 1
            .Item(2, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(15).Value

            .Item(5, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(0).Value
            .Item(6, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(1).Value

            .Item(7, .RowCount - 1).Value = Format(Val(batchgrid.CurrentRow.Cells(4).Value & ""), "0.00")
            .Item(8, .RowCount - 1).Value = Format(Val(batchgrid.CurrentRow.Cells(10).Value & ""), "0.00")

            If optsr.Checked Then
                rt = Val(batchgrid.CurrentRow.Cells(10).Value & "")
            Else
                rt = Val(batchgrid.CurrentRow.Cells(4).Value & "")
                If chincdisc.Checked Then
                    rt = rt - (rt * Val(batchgrid.CurrentRow.Cells(8).Value & "") / 100)
                    rt = rt - (rt * Val(batchgrid.CurrentRow.Cells(9).Value & "") / 100)
                End If
                If chinctax.Checked Then
                    rt = rt + (rt * Val(batchgrid.CurrentRow.Cells(5).Value & "") / 100)
                End If
            End If


            .Item(12, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(18).Value

            .Item(14, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(13).Value
            .Item(15, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(14).Value
            .Item(16, .RowCount - 1).Value = ""

            .Item(17, .RowCount - 1).Value = batchgrid.CurrentRow.Cells(20).Value
            .Item(20, .RowCount - 1).Value = Format(rt, "0.00")



            pnlbatch.Visible = False
            gridctrl.Visible = False
            .CurrentCell = .Item(10, .RowCount - 1)
            EditGrid()
        End With
    End Sub

    Private Sub optbr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optbr.CheckedChanged
        chincdisc.Enabled = optbr.Checked
        chinctax.Enabled = optbr.Checked
    End Sub

    Private Sub batchgrid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles batchgrid.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            batchgrid_DoubleClick()
        ElseIf e.KeyCode = Keys.Escape Then
            pnlbatch.Visible = False
            dgPR.CurrentRow.Cells(4).Value = ""
            dgPR.CurrentRow.Cells(3).Value = ""
            gridctrl.Visible = True
            gridctrl.Enabled = True
            gridctrl.Text = ""
            Application.DoEvents()
            gridctrl.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub tsbBCalcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBCalcel.Click
        EditSales.Text = "Cancelling.. Purchase Return"
        EditSales.txtSalNo.Focus()
        EditSales.ShowDialog()
        Dim nor As Long

        If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
            EditSales.Dispose()
            Exit Sub
        End If
        Dim cmd As New OleDb.OleDbCommand

        If MsgBox("Want to Cancel Purchase Return No. " & EditSales.txtSalNo.Text & " for the period " & EditSales.dtpf.Text & " - " & EditSales.dtpt.Text & "..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            If MsgBox("Are You Sure.. Want to Cancel Purchase Return No. " & EditSales.txtSalNo.Text & " for the period " & EditSales.dtpf.Text & " - " & EditSales.dtpt.Text & "..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                cmd.Connection = Conn
                cmd.CommandText = "Cancel_PurchaseRtn"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@prno", OleDb.OleDbType.BigInt).Value = Val(EditSales.txtSalNo.Text)
                cmd.Parameters.Add("@prdtf", OleDb.OleDbType.DBDate).Value = EditSales.dtpf.Value.Date
                cmd.Parameters.Add("@prdtt", OleDb.OleDbType.DBDate).Value = EditSales.dtpt.Value.Date
                nor = cmd.ExecuteNonQuery()
                If nor = 0 Then
                    MsgBox("Purchase Retrun not found..", MsgBoxStyle.Information)
                End If
            End If
        End If

        EditSales.Dispose()
    End Sub

    Private Sub EditingPurchaseReturn(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim dataredr As OleDb.OleDbDataReader
            Dim r As Integer
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            cmd.CommandText = "Select_PurchaseRtn"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@prno", OleDb.OleDbType.BigInt).Value = Val(no)
            cmd.Parameters.Add("@prdtf", OleDb.OleDbType.DBDate).Value = CDate(dtf)
            cmd.Parameters.Add("@prdtt", OleDb.OleDbType.DBDate).Value = CDate(dtt)
            dataredr = cmd.ExecuteReader
            r = 0
            dgPR.Rows.Clear()
            If dataredr.HasRows Then

                While dataredr.Read
                    If r = 0 Then
                        EditNum = dataredr.Item("prno")
                        EditDate = dataredr.Item("prdt")
                        cbPRsup.SelectedValue = dataredr.Item("supcode")
                        lbldate.Text = dataredr.Item("prdt")
                    End If

                    dgPR.Rows.Add()
                    dgPR.Item(0, r).Value = r + 1

                    dgPR.Item(1, r).Value = 1
                    dgPR.Item(2, r).Value = dataredr.Item("batchid")

                    dgPR.Item(3, r).Value = dataredr.Item("Code")
                    dgPR.Item(4, r).Value = dataredr.Item("PrdName")
                    dgPR.Item(5, r).Value = dataredr.Item("Batch")
                    If IsDBNull(dataredr.Item("ExDt")) Then
                        dgPR.Item(6, r).Value = DBNull.Value
                    Else
                        dgPR.Item(6, r).Value = Format(dataredr.Item("ExDt"), DateFormat)
                    End If

                    dgPR.Item(7, r).Value = Format(dataredr.Item("Prate"), "0.00")
                    dgPR.Item(8, r).Value = Format(dataredr.Item("Srate"), "0.00")
                    dgPR.Item(9, r).Value = dataredr.Item("BrQty")
                    dgPR.Item(10, r).Value = dataredr.Item("ExQty")
                    dgPR.Item(11, r).Value = dataredr.Item("fqty")
                    dgPR.Item(12, r).Value = dataredr.Item("pack")
                    dgPR.Item(14, r).Value = dataredr.Item("billno")
                    If IsDBNull(dataredr.Item("billdt")) Then

                    Else
                        dgPR.Item(15, r).Value = Format(dataredr.Item("billdt"), DateFormat)
                    End If

                    dgPR.Item(16, r).Value = dataredr.Item("remark")
                    dgPR.Item(17, r).Value = dataredr.Item("supcode")
                    dgPR.Item(18, r).Value = dataredr.Item("acname") & "  " & dataredr.Item("place")

                    dgPR.Item(20, r).Value = Format(dataredr.Item("rate"), "0.00")
                    r = r + 1
NextProd:       End While
                dgPR.Rows.Add()
                lbldate.Text = Format(EditDate, DateFormat)
                lblprno.Text = EditNum
                EditFlag = True
                pnlViewValue.Visible = False
                ViewValue = False
            Else
                MsgBox("Purchase Return Not Fond..", MsgBoxStyle.Information)
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            ClearForm()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        EditSales.Text = "Editing.. Purchase Return"
        EditSales.txtSalNo.Focus()
        EditSales.ShowDialog()

        If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
            EditSales.Dispose()
            Exit Sub
        End If
        EditingPurchaseReturn(EditSales.txtSalNo.Text, EditSales.dtpf.Value.Date, EditSales.dtpt.Value.Date)

        EditSales.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        BillCopy.txtNof.Focus()
        BillCopy.ChkPrePrint.Visible = False
        BillCopy.cbType.Visible = False
        BillCopy.lblType.Visible = False
        BillCopy.BtnFile.Visible = False
        BillCopy.btnPrint.Visible = False
        BillCopy.Label2.Text = "Purchase Return No"
        BillCopy.Text = "Purchase Return Copy "
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
        cmd.CommandText = "Get_PurchaseReturn_Print"
        cmd.Parameters.Add("@Nosf", OleDb.OleDbType.BigInt).Value = Val(BillCopy.txtNof.Text)
        cmd.Parameters.Add("@Nost", OleDb.OleDbType.BigInt).Value = Val(BillCopy.txtNot.Text)
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = BillCopy.dtpf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = BillCopy.dtpt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)

        Dim FRMRPT As New Reports1
        Dim RPT As New PurchaseReturnPrint

        RPT.SetDataSource(dtab)
        RPT.SetParameterValue("Head1", DeScriptRS(Firm.Name))
        RPT.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
        RPT.SetParameterValue("HEAD3", "Purchase Return")

        FRMRPT.crv.ReportSource = RPT

        FRMRPT.MdiParent = Main
        FRMRPT.Show()

        Me.Cursor = Cursors.Default

        'rt.StartNumber = Val(BillCopy.txtNof.Text)
        'rt.EndNumber = Val(BillCopy.txtNot.Text)
        'rt.StartDate = BillCopy.dtpf.Value.Date
        'rt.EndDate = BillCopy.dtpt.Value.Date
        'rt.TransType = cbType.SelectedValue
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
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "-R"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            NUM = Val(dr("prno") & "")
        Else
            'GoTo che
            ' ClearForm()
            Me.Cursor = Cursors.Default
            dr.Close()
            Exit Sub
        End If

        NUM = (dr("prno") & "")
        DT = dr("prdt")
        dr.Close()
        ClearForm(True)
        EditingPurchaseReturn(NUM, DT, DT)
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
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "+R"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()

            NUM = Val(dr("prno") & "")
            ' dr.Close()

        Else
            ClearForm()
            dr.Close()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        NUM = (dr("prno") & "")
        DT = dr("prdt")
        dr.Close()
        ClearForm(True)
        EditingPurchaseReturn(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearForm()
    End Sub

    Private Sub btnViewVal_Click(sender As System.Object, e As System.EventArgs) Handles btnViewVal.Click

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt, dt1, dt2 As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn

        If ViewValue Then
            ViewValue = False
        Else
            ViewValue = True
        End If

        dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add()
        dt2.Columns.Add("Rate") : dt2.Columns.Add("Purchase Value") : dt2.Columns.Add("VAT") : dt2.Columns.Add("MRP Value")

        If dgPR.Rows.Count > 1 And ViewValue Then

            For i As Integer = 0 To dgPR.Rows.Count - 2

                Dim BtcId As Integer = dgPR.Rows(i).Cells(2).Value
                Dim Qty As Double = (dgPR.Rows(i).Cells(9).Value) + (dgPR.Rows(i).Cells(10).Value)

                cmd.CommandType = CommandType.Text
                cmd.CommandText = "select Ptax,Stax,PRate,SRate from Batch where BatchId=" & btcId.ToString
                da.SelectCommand = cmd
                dt.Rows.Clear()
                da.Fill(dt)

                Dim Ptax As Double = dt.Rows(0).Item("Ptax")
                Dim Pvalue As Double = Qty * Val(dt.Rows(0).Item("PRate"))
                Dim PtaxVal As Double = Pvalue * (Ptax / 100)
                Dim Svalue As Double = Qty * Val(dt.Rows(0).Item("SRate"))

                dt1.Rows.Add(Ptax, Pvalue, PtaxVal, Svalue)
            Next

            'Assign to Data View to Sort
            Dim dv As DataView = New DataView(dt1, "", "Column1 Desc", DataViewRowState.CurrentRows)
            dt1 = dv.ToTable()

            'Grouping and attach to data Table
            Dim m As Integer = 0
            Dim pval2, ptaxval2, sval2 As Double

            While m < dt1.Rows.Count

                Dim Prt As String = 0, Prtn As Double = 0
                Dim pval1 As Double = 0, ptaxval1 As Double = 0, sval1 As Double = 0

                Prtn = dt1.Rows(m).Item(0)
                If dt1.Rows(m).Item(0) = 0 Then
                    Prt = "Tax Free"
                Else
                    Prt = dt1.Rows(m).Item(0) & "%"
                End If

                While Prtn = dt1.Rows(m).Item(0)

                    pval1 = pval1 + Val(dt1.Rows(m).Item(1))
                    ptaxval1 = ptaxval1 + Val(dt1.Rows(m).Item(2))
                    sval1 = sval1 + Val(dt1.Rows(m).Item(3))

                    m = m + 1
                    If m >= dt1.Rows.Count Then
                        Exit While
                    End If
                End While

                dt2.Rows.Add(Prt, Format(pval1, "0.00"), Format(ptaxval1, "0.00"), Format(sval1, "0.00"))

                pval2 = pval2 + pval1
                ptaxval2 = ptaxval2 + ptaxval1
                sval2 = sval2 + sval1

                If m >= dt1.Rows.Count Then
                    dt2.Rows.Add("Total", Format(pval2, "0.00"), Format(ptaxval2, "0.00"), Format(sval2, "0.00"))

                    dgViewValue.DataSource = dt2

                    dgViewValue.Columns(0).Width = 60
                    dgViewValue.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgViewValue.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(0).Style.BackColor = Color.LemonChiffon
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(0).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgViewValue.Columns(1).Width = 100
                    dgViewValue.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgViewValue.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(1).Style.BackColor = Color.LemonChiffon
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(1).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgViewValue.Columns(2).Width = 100
                    dgViewValue.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgViewValue.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(2).Style.BackColor = Color.LemonChiffon
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(2).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgViewValue.Columns(3).Width = 100
                    dgViewValue.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgViewValue.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(3).Style.BackColor = Color.LemonChiffon
                    dgViewValue.Rows(dgViewValue.RowCount - 1).Cells(3).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    pnlViewValue.Visible = True
                    Exit Sub
                End If
            End While

        Else
            pnlViewValue.Visible = False
        End If

    End Sub

End Class

'