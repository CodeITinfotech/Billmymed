Imports System
Imports System.Globalization
Imports System.Math
Imports PrintDirectClass
Imports PrintDirectBig
Imports PrePrintDirectClass

Public Class SalesinvHp
    Private obj As Object
    Private ProdSelected As Boolean
    Private TaxTbl As DataTable
    Private Sales As DataTable
    Private EDCOL As Integer
    Private EDROW As Integer
    Private TabFlag As Boolean
    Private curunit As Double
    Private rtaxary(4, 2) As Double
    Private rptax(4, 2) As Double
    Private value, totscst, Svalue, totstax, totadj, tfamt, totbdis, totsdis, totvalue, totcst, subtot, totrtnval, totrtntax, unacamt As Double

    Private RndPai As Double
    Private Trans As OleDb.OleDbTransaction
    'Dim tmpqty As Long
    Private slno As Long
    Private InvNum As Long
    Private InvDt As Date
    Private EditFlag As Boolean
    Private EditNum As Long
    Private EditType As Long
    Private EditDt As Date
    Private PostAc As Boolean
    Private CreditPost As Boolean

    Private outgoid As Long
    Private BillOrder As Integer
    Private UseBarCode As Boolean
    Private UseSalesmanPass As Boolean
    Private ShowPrateInSales As Boolean
    Private editworkshift As Integer
    Private EditVouno As Long
    'Private dic As New List(Of Integer)

    Private Sub ExpColor(ByVal i As Integer)
        Try

            Dim nds As Long
            dgInv.Item(13, i).Style.ForeColor = Color.Black
            If dgInv.Item(13, i).Value & "" <> "" Then
                If IsDate(dgInv.Item(13, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgInv.Item(13, i).Value)
                    If nds < 0 Then
                        dgInv.Item(13, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgInv.Item(13, i).Style.ForeColor = Color.Red

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub ExpColorBat(ByVal i As Integer)
        Try

            Dim nds As Long
            dgBDet.Item(1, i).Style.ForeColor = Color.Black
            If dgBDet.Item(1, i).Value & "" <> "" Then
                If IsDate(dgBDet.Item(1, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgBDet.Item(1, i).Value)
                    If nds < 0 Then
                        dgBDet.Item(1, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgBDet.Item(1, i).Style.ForeColor = Color.Red

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub Salesinv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'txtEdit.Visible = False
        'cbDoc.Focus()
        MsgBox("")
    End Sub

    Private Sub Salesinv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dgInv.RowCount > 1 Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If
        For I = 0 To dgInv.RowCount - 1
            WriteOutGo(-3, 0, I)
        Next
    End Sub

    Private Sub Sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' If e.KeyCode = Keys.Enter Then
        'If Not TabFlag Then System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If
        If e.KeyCode = Keys.F5 Then

            If dgInv.RowCount > 1 Then
                MsgBox("Entries found. Clear the entries before restoring.", vbInformation)
                Exit Sub
            End If

            ' RestoreLostBill()
        ElseIf e.KeyCode = Keys.M And e.Alt = True Then
            cbSal.Focus()

            'End If
        ElseIf e.KeyCode = Keys.F3 Then
            txtsmcode.Text = ""
            txtsmcode.Focus()
        End If

    End Sub

    Private Sub RestoreLostBill()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn
            Dim i As Integer
            i = 0
            slno = 0


            Sales.Rows.Clear()
            Sales.Rows.Add()

            cmd.CommandText = "select batch.*,outgo.*,product.prdname,unit1,case1 from outgo,batch,product  " & _
                     "  where batch.batchid=outgo.batchid and batch.prdcode=product.prdcode order by outgo.id "

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0S Then

                For i = 0 To dt.Rows.Count - 1


                    slno = slno + 1
                    dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno

                    dgInv.Item(1, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("prdcode")
                    dgInv.Item(2, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batchid")
                    dgInv.Item(3, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("Unit1")
                    dgInv.Item(7, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("PrdName")
                    dgInv.Item(8, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("Qty"), 2, MidpointRounding.AwayFromZero)
                    dgInv.Item(9, dgInv.Rows.Count - 1).Value = 0
                    dgInv.Item(10, dgInv.Rows.Count - 1).Value = 0
                    dgInv.Item(11, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("case1") & ""
                    dgInv.Item(12, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batch") & ""
                    dgInv.Item(13, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("ExDt")
                    dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("srate"), 4, MidpointRounding.AwayFromZero)
                    dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("scst"), 2)
                    dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("stax"), 2)

                    If (dt.Rows(i).Item("TaxInc")) = 0 Then
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                    Else
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                    End If

                    WriteOutGo(dt.Rows(i).Item("batchid"), dt.Rows(i).Item("Qty"), dgInv.Rows.Count - 1, False)

                    dgInv.Update()
                    Sales.Rows.Add()

                Next

                cmd.CommandText = "delete outgo where id<>" & outgoid
                cmd.ExecuteNonQuery()

            Else

                MsgBox("Records not found.", MsgBoxStyle.Information)
                Exit Sub
            End If

            tsbSave.Enabled = True
            Calculate()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
            ClearForm()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CbPrintOut.SelectedIndex = 0
            ClearForm()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.MediumSeaGreen
            ToolStrip.Renderer = renderer
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            Application.DoEvents()
            
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.GotFocus
        'cbType.SelectAll()
    End Sub

    Private Sub cbType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.SelectedValueChanged
        Me.Text = "Sales - " & cbType.Text
        Me.Refresh()
        GetSeries()
    End Sub

    Private Sub GetSeries()
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter

        If cbType.SelectedValue = Nothing Then Exit Sub
        cmd.Connection = Conn
        Dim totsal As Double
        Try
            cmd.CommandText = "select workshift from settings "
            WorkShift = cmd.ExecuteScalar
            cmd.CommandText = "select CreditEntry,POSTAC from serialnum where type=" & cbType.SelectedValue
            da.SelectCommand = cmd
            da.Fill(dt)

            txtcash.Enabled = True
            txtccard.Enabled = True
            txtcoup.Enabled = True

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("CreditEntry") Then
                    cbCus.Visible = True
                    lblCus.Visible = True
                    CreditPost = True
                Else
                    CreditPost = False
                    cbCus.Visible = False
                    lblCus.Visible = False
                End If
                If dt.Rows(0).Item("POSTAC") Then
                    PostAc = True
                Else
                    PostAc = False
                    cbCus.Visible = False
                    lblCus.Visible = False
                End If
            End If


            cbSal.Enabled = Not UseSalesmanPass
            cbPat.Enabled = True
            cbDoc.Enabled = True

            ' txtRecv.Enabled = False
            txtDis.Enabled = True
            txtDed.Enabled = True
            txtAdd.Enabled = True

            ckbUpaid.Enabled = True
            If cbType.SelectedValue = 22 Then
                txtcrcard.Enabled = False
                txtcash.Enabled = False
            ElseIf cbType.SelectedValue = 21 Then
                txtcrcard.Enabled = False
            End If

            'SUNDRY

            If cbType.SelectedValue = 26 Or cbType.SelectedValue = 23 Then
                txtcrcard.Enabled = False
                txtcash.Enabled = False
                txtcoup.Enabled = False
                lblCus.Visible = False
                cbCus.Visible = False
                cbSal.Enabled = Not UseSalesmanPass
                cbPat.Enabled = False
                cbDoc.Enabled = False

                'txtRecv.Enabled = False
                txtDis.Enabled = False
                txtDed.Enabled = False
                txtAdd.Enabled = False
                ckbUpaid.Enabled = False
                txtDis.Text = "0.00"

                'txtRecv.BackColor = Color.White
                'txtDis.BackColor = Color.White
                'txtDed.BackColor = Color.White
                'txtAdd.BackColor = Color.White

                'cbDoc.BackColor = Color.White
                'cbSal.BackColor = Color.White
                'cbPat.BackColor = Color.White

                'OTC SALES
            ElseIf cbType.SelectedValue = 27 Then
                cmd.Connection = Conn
                cmd.CommandText = "Select accode from tax where flag='50' " & _
                    " and  seq=1"
                cbCus.SelectedValue = Val(cmd.ExecuteScalar & "")
                lblCus.Visible = True
                cbCus.Visible = True
                txtcrcard.Enabled = True
                txtcash.Enabled = True
                txtcoup.Enabled = True

            ElseIf cbType.SelectedValue = 25 Then
                lblCus.Visible = False
                cbSal.Enabled = Not UseSalesmanPass
                cbPat.Enabled = True
                cbDoc.Enabled = True
                'txtRecv.Enabled = False
                txtDis.Enabled = True
                txtDed.Enabled = True
                txtAdd.Enabled = True
                ckbUpaid.Enabled = True
                txtcrcard.Enabled = False

                'TRANSFER
            ElseIf cbType.SelectedValue = 24 Then
                lblCus.Visible = True
                cbCus.Visible = True
                cbSal.Enabled = Not UseSalesmanPass
                cbPat.Enabled = False
                cbDoc.Enabled = False

                txtRecv.Enabled = False
                txtDis.Enabled = False
                txtDed.Enabled = False
                txtAdd.Enabled = False
                ckbUpaid.Enabled = False
                txtcrcard.Enabled = False
                txtcash.Enabled = False
                txtcoup.Enabled = False
            End If

            Calculate()

            cmd.CommandText = "select isnull(sum(netamt),0) from invtotal where invtotal.type='" & cbType.SelectedValue & "' and invdt=convert(datetime,'" & SysDt & "')"
            totsal = cmd.ExecuteScalar
            lbltypetot.Text = "Total " & cbType.Text & " " & Format(totsal, "0.00")


            If EditFlag Then
                If cbType.SelectedValue = EditType Then
                    lblno.Text = EditNum
                    Exit Sub
                End If
            End If

            cmd.CommandText = "select slno from serialnum where type=" & cbType.SelectedValue
            lblno.Text = cmd.ExecuteScalar + 1

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ClearForm(Optional ByVal flg As Boolean = False)
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim I As Integer
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            For I = 0 To dgInv.RowCount - 1
                WriteOutGo(-3, 0, I)
            Next
            lblrtnval.Text = "0.00"
            lblrtnval.Tag = ""
            curunit = 0
            cmd.Connection = Conn

            If Not flg Then
                cmd.CommandText = "select Docname from Doctor order by docname "
                DA.SelectCommand = cmd
                DA.Fill(DS, "Doctor")
                cbDoc.DisplayMember = "DocName"
                cbDoc.DataSource = DS.Tables("Doctor")

                cmd.CommandText = "select Patname,Patcode from Patient order by Patname"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Patient")
                cbPat.DisplayMember = "PatName"

                'cbPat.ValueMember = "Patcode"
                cbPat.DataSource = DS.Tables("Patient")

                ' cbSal.Enabled = False
            End If

            cmd.CommandText = "select Accode,Acname from Acmaster where (grpcode=" & CustGrpcode & " or grpcode=5  or accode= (Select  accode from tax where flag='50' and seq=1)) order by acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Acmaster")
            cbCus.DisplayMember = "AcName"
            cbCus.ValueMember = "Accode"
            cbCus.DataSource = DS.Tables("Acmaster")

            cmd.CommandText = "select cardno,name  from Carddetails order by name "
            DA.SelectCommand = cmd
            DA.Fill(DS, "CCard")
            cbccard.DisplayMember = "Name"
            cbccard.ValueMember = "cardno"
            cbccard.DataSource = DS.Tables("CCard")
            EditVouno = 0
            'cbccard.SelectedText = ""
            cbccard.Text = ""
            cbccard.SelectedValue = 0
            'txtccard.Text = ""

            If cbType.Items.Count = 0 Then
                If Not flg Then
                    cmd.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where type>20 and type<29 order by seq"
                    DA.SelectCommand = cmd
                    DA.Fill(DS, "SerialNum")
                    cbType.DisplayMember = "Descr"
                    cbType.ValueMember = "Type"
                    cbType.DataSource = DS.Tables("SerialNum")
                End If
            End If

            TaxTbl = New DataTable
            Sales = New DataTable
            dgInv.DataSource = Nothing
            Sales.TableName = "Sales"
            lbldt.Text = SysDt

            Sales.Columns.Add("SL")
            Sales.Columns.Add("Code")
            Sales.Columns.Add("BatchId")
            Sales.Columns.Add("Unit")
            Sales.Columns.Add("resv1")
            Sales.Columns.Add("resv2")
            Sales.Columns.Add("resv3")
            Sales.Columns.Add("Product")
            Sales.Columns.Add("Qty")
            Sales.Columns.Add("Free")
            Sales.Columns.Add("Repl")
            Sales.Columns.Add("Packing")
            Sales.Columns.Add("Batch")
            Sales.Columns.Add("ExDt")
            Sales.Columns.Add("Rate")
            Sales.Columns.Add("RT")
            Sales.Columns.Add("VAT")
            Sales.Columns.Add("TaxInc")
            Sales.Columns.Add("RACK")
            Sales.Columns.Add("resv5")
            Sales.Columns.Add("unac")
            Sales.Columns.Add("Nodisc")
            Sales.Columns.Add("Amount")

            dgInv.Columns.Clear()

0:          dgInv.Columns.Add("SL", "Sl")
1:          dgInv.Columns.Add("Code", "Code")
2:          dgInv.Columns.Add("BatchId", "")
3:          dgInv.Columns.Add("Unit", "")
4:          dgInv.Columns.Add("resv1", "")
5:          dgInv.Columns.Add("resv2", "")
6:          dgInv.Columns.Add("resv3", "")
7:          dgInv.Columns.Add("Product", "Products")
8:          dgInv.Columns.Add("Qty", "Qty")
9:          dgInv.Columns.Add("Free", "   Free")
10:         dgInv.Columns.Add("Repl", "Repl")
11:         dgInv.Columns.Add("Packing", "Packing")
12:         dgInv.Columns.Add("Batch", "Batch")
13:         dgInv.Columns.Add("ExDt", "Ex.Dt")
14:         dgInv.Columns.Add("Rate", "Rate")
15:         dgInv.Columns.Add("RT", "      RT%")
16:         dgInv.Columns.Add("VAT", " VAT%")
17:         dgInv.Columns.Add("TaxInc", "Tax Inc")
18:         dgInv.Columns.Add("Rack", "Rack")
19:         dgInv.Columns.Add("resv5", "")
20:         dgInv.Columns.Add("unac", "")
21:         dgInv.Columns.Add("Nodisc", "")
22:         dgInv.Columns.Add("Amount", "Amount")

            dgInv.Columns(0).DataPropertyName = "SL"
            dgInv.Columns(1).DataPropertyName = "Code"
            dgInv.Columns(2).DataPropertyName = "BatchId"
            dgInv.Columns(3).DataPropertyName = "Unit"
            dgInv.Columns(4).DataPropertyName = "resv1"
            dgInv.Columns(5).DataPropertyName = "resv2"
            dgInv.Columns(6).DataPropertyName = "resv3"
            dgInv.Columns(7).DataPropertyName = "Product"
            dgInv.Columns(8).DataPropertyName = "Qty"
            dgInv.Columns(9).DataPropertyName = "Free"
            dgInv.Columns(10).DataPropertyName = "Repl"
            dgInv.Columns(11).DataPropertyName = "Packing"
            dgInv.Columns(12).DataPropertyName = "Batch"
            dgInv.Columns(13).DataPropertyName = "ExDt"
            dgInv.Columns(14).DataPropertyName = "Rate"
            dgInv.Columns(15).DataPropertyName = "RT"
            dgInv.Columns(16).DataPropertyName = "VAT"
            dgInv.Columns(17).DataPropertyName = "TaxInc"
            dgInv.Columns(18).DataPropertyName = "Rack"
            dgInv.Columns(19).DataPropertyName = "resv5"
            dgInv.Columns(20).DataPropertyName = "unac"
            dgInv.Columns(21).DataPropertyName = "Nodisc"
            dgInv.Columns(22).DataPropertyName = "Amount"

            dgInv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(15).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(16).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(17).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(22).SortMode = DataGridViewColumnSortMode.NotSortable

            dgInv.Columns(0).Width = 25
            dgInv.Columns(1).Width = Int(dgInv.Width * 6 / 100)
            'dgInv.Columns(1).Visible = False
            dgInv.Columns(2).Visible = False
            dgInv.Columns(3).Visible = False
            dgInv.Columns(4).Visible = False
            dgInv.Columns(5).Visible = False
            dgInv.Columns(6).Visible = False
            'dgInv.Columns(17).Visible = False
            dgInv.Columns(7).Width = Int(dgInv.Width * 25 / 100)
            dgInv.Columns(17).Visible = False
            'dgInv.Columns(7).Width =   250
            dgInv.Columns(7).Frozen = True

            dgInv.Columns(8).Width = Int(dgInv.Width * 3 / 100)
            'dgInv.Columns(8).Width = 60
            dgInv.Columns(9).Visible = False
            dgInv.Columns(10).Visible = False
            dgInv.Columns(11).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(12).Width = Int(dgInv.Width * 7 / 100)
            dgInv.Columns(13).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(14).Width = Int(dgInv.Width * 6 / 100)
            'dgInv.Columns(11).Width = 100
            'dgInv.Columns(12).Width = 100
            'dgInv.Columns(13).Width = 100
            'dgInv.Columns(14).Width = 120
            dgInv.Columns(15).Width = Int(dgInv.Width * 3 / 100)
            ' dgInv.Columns(15).Width = 50
            dgInv.Columns(16).Width = Int(dgInv.Width * 4 / 100)
            'dgInv.Columns(22).Width = Int(dgInv.Width * 4 / 100)
            'dgInv.Columns(16).Width = 60
            ' dgInv.Columns(17).Width = 80
            dgInv.Columns(18).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(15).Visible = False
            dgInv.Columns(18).Visible = True
            dgInv.Columns(19).Visible = False
            dgInv.Columns(20).Visible = False
            dgInv.Columns(21).Visible = False
            ' dgInv.Columns(22).Width = 80
            dgInv.Columns(22).Width = Int(dgInv.Width * 7 / 100)
            dgInv.Columns.Item(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns.Item(22).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgInv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgInv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgInv.BackgroundColor = Color.Navy

            dgInv.DataSource = Sales
            Sales.Rows.Add()

            'For i = 0 To 22
            '    dgInv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            '    dgInv.Columns(i).DefaultCellStyle.BackColor = Color.Navy
            '    dgInv.Columns(i).DefaultCellStyle.ForeColor = Color.Yellow
            'Next i

            TaxTbl = New DataTable
            TaxTbl.TableName = "Tax"
            cmd.Connection = Conn
            cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' order by seq"
            DA.SelectCommand = cmd
            DA.Fill(TaxTbl)
            cbEditVat.DataSource = TaxTbl
            cbEditVat.DisplayMember = "taxper"
            dgBDet.Columns.Clear()

            Dim dt As New DataTable

            cmd.CommandText = "select taxper,accode,surch from tax where flag='1'"
            DA.SelectCommand = cmd
            DA.Fill(dt)

            For I = 0 To dt.Rows.Count - 1
                rtaxary(I, 0) = dt.Rows(I).Item("taxper")
                rtaxary(I, 2) = dt.Rows(I).Item("accode")

            Next

            cmd.CommandText = "select taxper,accode,surch from tax where flag='2'"
            dt.Rows.Clear()
            dt.Clear()
            DA.SelectCommand = cmd
            DA.Fill(dt)

            For I = 0 To dt.Rows.Count - 1

                rptax(I, 0) = dt.Rows(I).Item("taxper")
                rptax(I, 2) = dt.Rows(I).Item("accode")

            Next

            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn
            outgoid = 0
            cbDoc.Text = ""
            cbPat.Text = ""
            cmd.CommandText = "update settings set outgoid=outgoid+1 "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "select RndPaise,outgoid,ExpWiseBill,defaultDoc,DefaultPat,usebarcode,UseSalesmanPass,ShowPrateInSales,workshift from settings"
            dt.Rows.Clear()
            dt.Clear()
            DA.SelectCommand = cmd
            DA.Fill(dt)
            For I = 0 To dt.Rows.Count - 1
                RndPai = dt.Rows(I).Item("RndPaise")
                outgoid = dt.Rows(I).Item("outgoid")
                BillOrder = IIf(dt.Rows(I).Item("ExpWiseBill"), 1, 0)
                UseSalesmanPass = dt.Rows(I).Item("UseSalesmanPass")
                txtsmcode.Visible = UseSalesmanPass
                cbSal.Enabled = Not UseSalesmanPass
                If Not flg Then
                    cbDoc.Text = dt.Rows(I).Item("defaultDoc") & ""
                    cbPat.Text = dt.Rows(I).Item("defaultpat") & ""
                End If
                UseBarCode = dt.Rows(I).Item("usebarcode")
                ShowPrateInSales = dt.Rows(I).Item("ShowPrateInSales")
                WorkShift = dt.Rows(I).Item("workshift")
            Next
            dgInv.Columns(1).Visible = UseBarCode
            Trans.Commit()

            If UseSalesmanPass Then
                ' txtsmcode.Text = ""
            End If
            If Not flg Then
                If txtsmcode.Text = "" Then
                    If UseSalesmanPass Then
                        cmd.CommandText = "select salcode,Salname from Salesman WHERE salcode<>0 ORDER BY Salname "
                    Else
                        cmd.CommandText = "select salcode,Salname from Salesman ORDER BY Salname "
                    End If
                    DA.SelectCommand = cmd
                    DA.Fill(DS, "Salesman")
                    cbSal.DisplayMember = "SalName"
                    cbSal.ValueMember = "salcode"
                    cbSal.DataSource = DS.Tables("Salesman")
                    cbSal.SelectedValue = 0
                End If

                cbCus.Visible = False
            End If

            'cbSal.SelectedValue = 0
            txtEdit.Visible = False
            CbEditUnit.Visible = False
            cbEditVat.Visible = False
            pnlPDet.Visible = False
            pnlprod.Visible = False
            tsbSave.Enabled = False
            cbType.Enabled = True

            EditFlag = False
            EditVouno = 0
            txtRecv.BackColor = Color.White
            lblTamt.Text = "0.00"
            lblNamt.Text = "0.00"
            txtDed.Text = "0.00"
            txtAdd.Text = "0.00"
            txtDis.Text = "0.00"
            txtcash.Text = "0.00"
            txtcrcard.Text = "0.00"
            txtmobno.Text = ""
            txtcoup.Text = "0.00"
            txtplace.Text = ""
            txtrefno.Text = ""
            cmbpaydet.Text = ""
            txtRecv.Text = "0.00"
            txtempname.Text = ""
            txtempno.Text = ""
            txtesino.Text = ""
            txtpresno.Text = ""
            LblCard.Text = ""
            ckbUpaid.Checked = False
            lblchange.Text = "Change: "
            'cbSal.SelectedValue = 0
            ' cbSal.Text = ""
            'lblCus.Visible = False
            'cbCus.Visible = False
            subtot = 0
            dgInv.Enabled = True
            EditFlag = False
            EditNum = 0
            EditType = cbType.SelectedValue
            cbCus.SelectedValue = 0
            cbCus.Text = ""
            PostAc = True
            CreditPost = False
            ClearRtn()
            slno = 0
            If Not flg Then
                ' cbType.SelectedValue = 21
                GetSeries()
            End If
            Application.DoEvents()
            cbPat.Focus()
            Application.DoEvents()

            'If UseBarCode Then
            'dgInv.CurrentCell = dgInv.Item(8, dgInv.Rows.Count - 1)
            'Else
            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            'End If

            EditGrid()
            Application.DoEvents()
            txtEdit.Focus()

            EditGrid()
            'ClearForm()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PopulateProduct()
        Try
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = obj.text

                da.SelectCommand = cmd
                da.Fill(ds, "Product")


                DgProdSer.DataSource = ds.Tables("Product")
                If ds.Tables("Product").Rows.Count > 0 Then
                    pnlprod.Visible = True
                    DgProdSer.Columns(1).HeaderText = "Name"
                    DgProdSer.Focus()
                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False
            obj.SelectionStart = obj.TextLength
            obj.focus()

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub PopulateProductGeneric(ByVal cd As String)
        Try
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet
                Dim dt As New DataTable

                cmd.Connection = Conn

                cmd.CommandText = "SELECT top 1 Product.prdname, Product.Gencode1, Product.Gencode2, Product.Gencode3, Product.Gencode4, Product.Gencode5," & _
                    " Generic.GenName AS GenName1, Generic_1.GenName AS GenName2, Generic_2.GenName AS GenName3, " & _
                    " Generic_3.GenName AS GenName4, Generic_4.GenName AS GenName5 FROM   Product LEFT OUTER JOIN " & _
                         " Generic AS Generic_4 ON Product.Gencode5 = Generic_4.GenCode and Generic_4.GenCode<>0 LEFT OUTER JOIN " & _
                      "    Generic AS Generic_3 ON Product.Gencode4 = Generic_3.GenCode and Generic_3.GenCode<>0  LEFT OUTER JOIN " & _
                      "    Generic AS Generic_2 ON Product.Gencode3 = Generic_2.GenCode and Generic_2.GenCode<>0 LEFT OUTER JOIN " & _
                      "    Generic ON Product.Gencode1 = Generic.GenCode and Generic.GenCode<>0 LEFT OUTER JOIN " & _
                      "    Generic AS Generic_1 ON Product.Gencode2 = Generic_1.GenCode and Generic_1.GenCode<>0 where prdcode=""" & cd & """"
                da.SelectCommand = cmd
                da.Fill(dt)

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Populate_productGeneric"
                cmd.Parameters.Add("@gn1", OleDb.OleDbType.BigInt).Value = Val(dt.Rows(0).Item("gencode1"))
                cmd.Parameters.Add("@gn2", OleDb.OleDbType.BigInt).Value = Val(dt.Rows(0).Item("gencode2"))
                cmd.Parameters.Add("@gn3", OleDb.OleDbType.BigInt).Value = Val(dt.Rows(0).Item("gencode3"))
                cmd.Parameters.Add("@gn4", OleDb.OleDbType.BigInt).Value = Val(dt.Rows(0).Item("gencode4"))
                cmd.Parameters.Add("@gn5", OleDb.OleDbType.BigInt).Value = Val(dt.Rows(0).Item("gencode5"))

                da.SelectCommand = cmd
                da.Fill(ds, "Product")

                Dim va As String
                DgProdSer.DataSource = ds.Tables("Product")
                If ds.Tables("Product").Rows.Count > 0 Then
                    pnlprod.Visible = True
                    va = "Substitute for: " & dt.Rows(0).Item("prdname")


                    If dt.Rows(0).Item("GenName1") & "" <> "" Then
                        va = va & Chr(13) & dt.Rows(0).Item("GenName1")
                    End If

                    If dt.Rows(0).Item("GenName2") & "" <> "" Then
                        va = va & " + " & dt.Rows(0).Item("GenName2")
                    End If


                    If dt.Rows(0).Item("GenName3") & "" <> "" Then
                        va = va & Chr(13) & dt.Rows(0).Item("GenName3")
                    End If

                    If dt.Rows(0).Item("GenName4") & "" <> "" Then
                        va = va & " + " & dt.Rows(0).Item("GenName4")
                    End If

                    If dt.Rows(0).Item("GenName5") & "" <> "" Then
                        va = va & Chr(13) & dt.Rows(0).Item("GenName5")
                    End If
                    DgProdSer.Columns(1).HeaderText = va
                    DgProdSer.Focus()
                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False
            obj.SelectionStart = obj.TextLength
            obj.focus()

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub PopulateProductInfo(ByVal PrdCd As String, ByVal pno As Integer)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim va As String
        cmd.Connection = Conn

        cmd.CommandText = "SELECT top 1 Product.prdname, Product.Gencode1, Product.Gencode2, Product.Gencode3, Product.Gencode4, Product.Gencode5," & _
                         "        Generic.GenName AS GenName1, Generic_1.GenName AS GenName2, Generic_2.GenName AS GenName3,  Generic_3.GenName AS GenName4, Generic_4.GenName AS GenName5," & _
                         "        Strng1,Strng2,Strng3,Strng4,Strng5,Classification.ClsName,PrGroup1.PrGrp1Name " & _
                         " FROM   Product LEFT OUTER JOIN  Generic AS Generic_4 ON Product.Gencode5 = Generic_4.GenCode and Generic_4.GenCode<>0 LEFT OUTER JOIN " & _
                         "        Generic AS Generic_3 ON Product.Gencode4 = Generic_3.GenCode and Generic_3.GenCode<>0  LEFT OUTER JOIN " & _
                         "        Generic AS Generic_2 ON Product.Gencode3 = Generic_2.GenCode and Generic_2.GenCode<>0 LEFT OUTER JOIN " & _
                         "        Generic AS Generic_1 ON Product.Gencode2 = Generic_1.GenCode and Generic_1.GenCode<>0 LEFT OUTER JOIN " & _
                         "        Generic ON Product.Gencode1 = Generic.GenCode and Generic.GenCode<>0  INNER JOIN " & _
                         "        Classification ON Product.ClsCode=Classification.ClsCode INNER JOIN " & _
                         "        PrGroup1 ON Product.PrGrp1Code=PrGroup1.PrGrp1Code " & _
                         "WHERE  prdcode=""" & PrdCd.ToString & """"

        da.SelectCommand = cmd
        da.Fill(dt)

        If dt.Rows.Count > 0 Then

            va = "Generic: "

            If dt.Rows(0).Item("GenName1") & "" <> "" Then
                va = va & Chr(13) & dt.Rows(0).Item("GenName1") & " " & dt.Rows(0).Item("Strng1")
            End If

            If dt.Rows(0).Item("GenName2") & "" <> "" Then
                va = va & Chr(13) & dt.Rows(0).Item("GenName2") & " " & dt.Rows(0).Item("Strng2")
            End If

            If dt.Rows(0).Item("GenName3") & "" <> "" Then
                va = va & Chr(13) & dt.Rows(0).Item("GenName3") & " " & dt.Rows(0).Item("Strng3")
            End If

            If dt.Rows(0).Item("GenName4") & "" <> "" Then
                va = va & Chr(13) & dt.Rows(0).Item("GenName4") & " " & dt.Rows(0).Item("Strng4")
            End If

            If dt.Rows(0).Item("GenName5") & "" <> "" Then
                va = va & Chr(13) & dt.Rows(0).Item("GenName5") & " " & dt.Rows(0).Item("Strng5")
            End If

            If dt.Rows(0).Item("ClsName") & "" <> "" Then
                va = va & Chr(13) & Chr(13) & "Classification:" & Chr(13) & dt.Rows(0).Item("ClsName")
            End If

            If dt.Rows(0).Item("PrGrp1Name") & "" <> "" Then
                va = va & Chr(13) & Chr(13) & "Group:" & Chr(13) & dt.Rows(0).Item("PrGrp1Name")
            End If

            If pno = 0 Then
                txtgentxt.Text = va
            Else
                MsgBox(va)
            End If

            Exit Sub
        End If
    End Sub

    Private Sub DgProdSer_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellEnter
        PopulateProductInfo(DgProdSer.CurrentRow.Cells(0).Value, 0)
    End Sub

    Private Sub DgProdSer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgProdSer.KeyDown

        If e.KeyCode = Keys.F10 Then
            If MsgBox("Add " & DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value & " to Short list ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim CMD As New OleDb.OleDbCommand
            CMD.Connection = Conn
            CMD.CommandType = CommandType.StoredProcedure
            CMD.CommandText = "Update_ShortItem"
            CMD.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value
            CMD.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
            CMD.ExecuteNonQuery()
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.Text
        End If

        If e.KeyCode = Keys.F9 Then
            ShowGenericInfo(DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value)
        End If

        If e.KeyCode = Keys.F8 Then
            PopulateProductGeneric(DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value)
        End If

        If e.KeyCode = Keys.F4 Then
            PopulateProductInfo(DgProdSer.CurrentRow.Cells(0).Value, 1)
        End If

    End Sub

    Private Sub DgProdSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgProdSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlprod.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlprod.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
                e.KeyChar = ""
            End If

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub DgProdSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        InvDetail()
    End Sub

    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            InvDetail()
        End If
    End Sub

    Private Sub InvDetail()

        Try
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            Dim tmpvar As Double
            Dim ic As Integer
            Dim pn As String
            cmd.Connection = Conn

            tsbSave.Enabled = False
            'Check for the stock if present

            cmd.CommandText = "Select Batch.Stock - " & _
                "COALESCE((SELECT sum(tqty) FROM OutGo WHERE " & _
                "(OutGo.Batchid = Batch.BatchId)),0) AS STOCK,product.color,product.prdname  from Batch,product Where product.prdcode=batch.prdcode and  Batch.PrdCode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """ and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "')) "
            da.SelectCommand = cmd
            da.Fill(dt)
            tmpvar = 0
            pn = ""

            For i = 0 To dt.Rows.Count - 1
                ic = IIf(IsDBNull(dt.Rows(i).Item("color")), Color.Black.ToArgb, dt.Rows(i).Item("color"))
                tmpvar = tmpvar + IIf(dt.Rows(i).Item("stock") > 0, dt.Rows(i).Item("stock"), 0)
                pn = dt.Rows(i).Item("prdname")
            Next

            If tmpvar = 0 Then
                pnlPDet.Visible = False
                pnlprod.Visible = False
                If MsgBox(pn & Chr(13) & "No Stock..!" & Chr(13) & "Want to add to short list ? ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "Update_ShortItem"
                    cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value
                    cmd.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    cmd.CommandType = CommandType.Text
                Else

                End If
                If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then '
                    tsbSave.Enabled = False
                Else
                    tsbSave.Enabled = True
                End If

                txtEdit.Focus()
                txtEdit.Text = ""
                Exit Sub
            End If


            'If tmpvar <> 0 Then
            txtEdit.SelectionStart = Len(txtEdit.Text)
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = (DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = (DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value)
            dgInv.Item(18, dgInv.CurrentCell.RowIndex).Value = (DgProdSer.Item(6, DgProdSer.CurrentCell.RowIndex).Value)
            'ic
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Style.ForeColor = Color.FromArgb(ic)
            If dgInv.CurrentCell.RowIndex = 0 Then
                dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
                slno = 1
                'ElseIf dgInv.CurrentCell.RowIndex > 0 And dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                '    slno = slno + 1
                '    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

            ElseIf dgInv.CurrentCell.RowIndex > 0 Or dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                slno = slno + 1
                dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

            End If

            'dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
            pnlPDet.Visible = True
            'lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            txtEdit.Visible = False
            GetBatchDetails()
            Calculate()
            dgInv.CurrentCell = dgInv.Item(8, dgInv.CurrentCell.RowIndex)
            EDROW = dgInv.CurrentCell.RowIndex
            EDCOL = dgInv.CurrentCell.ColumnIndex
            'Application.DoEvents()
            EditGrid()
            txtEdit.Focus()
            pnlprod.Visible = False
            'Else

            'tsbSave.Enabled = True
            'End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgBDet_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.GotFocus
        Try
            dgBDet.CurrentRow.Selected = True
        Catch er As Exception

        End Try
    End Sub

    Private Sub dgPDet_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellDoubleClick
        If dgInv.CurrentCell.ColumnIndex <> 12 Then
            If txtEdit.Visible Then
                txtEdit.Focus()
            ElseIf CbEditUnit.Visible Then
                CbEditUnit.Focus()
            End If
            Exit Sub
        End If

        AdjQty()
        Calculate()
        tsbSave.Enabled = True
    End Sub

    Private Sub AdjQty()
        Dim cmd As New OleDb.OleDbCommand
        Dim n As Double
        Dim i, ir As Integer
        Try
            cmd.Connection = Conn

            n = dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value * Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value)
            If dgBDet.CurrentCell Is Nothing Then
                dgBDet.CurrentCell = dgBDet.Item(5, 0)
            End If
            If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n And dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then

                If MsgBox("Stock insufficient in the batch selected." & _
                          "Adjust with existing batch ? Click Yes to " & _
                          "Proceed or No to Select a batch of your own.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    dgBDet.Focus()

                    Exit Sub
                Else

                    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno & "*"
                    If Val(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value) = 0 Then
                        slno = slno + 1
                    Else
                        slno = Val(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value)
                    End If
                End If

            End If

            If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n Then
                dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = Val(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value) & "*"
            End If


            dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(15, dgBDet.CurrentCell.RowIndex).Value

            If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n Then
                dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value = Format(dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value, "0")

                WriteOutGo(dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value, dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value, dgInv.CurrentCell.RowIndex)

                n = n - dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value

                dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = 1
                dgInv.Item(11, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(16, dgBDet.CurrentCell.RowIndex).Value & " (" & dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "." & "00" & ") "
            Else


                WriteOutGo(dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value, n, dgInv.CurrentCell.RowIndex)

                n = 0
            End If

            dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value = 0
            dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value = 0

            dgInv.Item(12, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
            dgInv.Item(13, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(1, dgBDet.CurrentCell.RowIndex).Value
            ExpColor(dgInv.CurrentCell.RowIndex)
            dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value = Format(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value * dgBDet.Item(3, dgBDet.CurrentCell.RowIndex).Value, "0.0000")
            dgInv.Item(15, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(8, dgBDet.CurrentCell.RowIndex).Value
            dgInv.Item(16, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(9, dgBDet.CurrentCell.RowIndex).Value

            If dgBDet.Item(10, dgBDet.CurrentCell.RowIndex).Value = True Then
                dgInv.Item(17, dgInv.CurrentCell.RowIndex).Value = "Yes"
            ElseIf dgBDet.Item(10, dgBDet.CurrentCell.RowIndex).Value = False Then
                dgInv.Item(17, dgInv.CurrentCell.RowIndex).Value = "No"
            End If

            dgInv.Item(21, dgInv.CurrentCell.RowIndex).Value = dgBDet.Rows(dgBDet.CurrentCell.RowIndex).Cells("nodisc").Value
            dgInv.Item(20, dgInv.CurrentCell.RowIndex).Value = dgBDet.Rows(dgBDet.CurrentCell.RowIndex).Cells("unac").Value
            dgInv.Item(22, dgInv.CurrentCell.RowIndex).Value = Format(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value * dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value, "0.000")

            dgInv.Update()
            If n <> 0 Then
                For i = 0 To dgBDet.Rows.Count - 1
                    If dgBDet.Item(15, i).Value <> dgBDet.Item(15, dgBDet.CurrentCell.RowIndex).Value Then
                        ir = dgInv.CurrentCell.RowIndex + 1

                        Sales.Rows.InsertAt(Sales.NewRow, ir)

                        WriteOutGo(-1, 0, ir)

                        dgInv.Item(0, ir).Value = dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value
                        dgInv.Item(1, ir).Value = dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value

                        dgInv.Item(2, ir).Value = dgBDet.Item(15, i).Value

                        dgInv.Item(3, ir).Value = dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value
                        dgInv.Item(11, ir).Value = dgInv.Item(11, dgInv.CurrentCell.RowIndex).Value

                        dgInv.Item(7, ir).Value = dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value
                        dgInv.Item(7, ir).Style.ForeColor = dgInv.Item(7, dgInv.CurrentCell.RowIndex).Style.ForeColor

                        If dgBDet.Item(5, i).Value < n Then
                            dgInv.Item(8, ir).Value = dgBDet.Item(5, i).Value
                            n = n - dgBDet.Item(5, i).Value
                        Else
                            dgInv.Item(8, ir).Value = n
                            n = 0
                        End If
                        'If ir < dgInv.Rows.Count - 1 Then
                        '    WriteOutGo(-5, 0, ir)
                        'End If

                        WriteOutGo(dgBDet.Item(15, i).Value, dgInv.Item(8, ir).Value, ir)


                        dgInv.Item(9, ir).Value = 0
                        dgInv.Item(10, ir).Value = 0
                        dgInv.Item(12, ir).Value = dgBDet.Item(0, i).Value
                        dgInv.Item(13, ir).Value = dgBDet.Item(1, i).Value
                        ExpColor(dgInv.CurrentCell.RowIndex)
                        dgInv.Item(14, ir).Value = Format(dgBDet.Item(3, i).Value, "0.0000")
                        dgInv.Item(15, ir).Value = dgBDet.Item(8, i).Value
                        dgInv.Item(16, ir).Value = dgBDet.Item(9, i).Value

                        If dgBDet.Item(10, i).Value = True Then
                            dgInv.Item(17, ir).Value = "Yes"
                        ElseIf dgBDet.Item(10, i).Value = False Then
                            dgInv.Item(17, ir).Value = "No"
                        End If
                        dgInv.Item(21, ir).Value = dgBDet.Rows(dgBDet.CurrentCell.RowIndex).Cells("nodisc").Value
                        dgInv.Item(20, ir).Value = dgBDet.Rows(dgBDet.CurrentCell.RowIndex).Cells("unac").Value
                        ir = ir + 1
                        dgInv.Update()
                    End If
                    If n = 0 Then Exit For
                Next

            End If

            pnlPDet.Visible = False

            'If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n Then
            '    MsgBox("er")
            'End If

            If Val(dgInv.Item(0, dgInv.Rows.Count - 1).Value.ToString) <> 0 Then
                dgInv.Update()
                Sales.Rows.Add()
            End If
            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            End If
            'dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            dgInv.Focus()
            ShowEditControl(txtEdit)
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub GetBatchDetails()

        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer
        cmd.Connection = Conn
        Try
            'pnlPDet.Visible = False
            lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            'Batch.Stock<>0 and " & _
            '            "((Batch.Stock+COALESCE(select sum(qty) from invdetails where invdetails.type='" & cbType.SelectedValue & _
            '           "' and invno=22 and invdt= convert(datetime,'" & SysDt & "') and invdetails.batchid=batch.batchid))- COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0))<>0 and

            'If EditFlag Then

            ''cmd.CommandText = "select Batch.Batch,Batch.ExDt,Batch.PRate,Batch.SRate,Batch.Pack," & _
            '   "((Batch.Stock+COALESCE((select sum(qty) from invdetails where invdetails.type='" & cbType.SelectedValue & _
            '   "' and invno=26 and invdt= convert(datetime,'" & SysDt & "') and invdetails.batchid=batch.batchid),0)) - " & _
            '   " COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (OutGo.Batchid = Batch.BatchId)),0)) AS STOCK,AcMaster.AcName as [Supplier],Batch.Profit,Batch.SCST,Batch.Stax,Batch.TaxInc," & _
            '   "Batch.BillNo,Batch.BillDt,Batch.PCST,Batch.Ptax,Batch.BatchId," & _
            '   "product.case1 FROM Batch INNER JOIN " & _
            '   "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN " & _
            '   "Acmaster ON Batch.Supcode = Acmaster.AcCode " & _
            '   " WHERE  ((Batch.Stock+COALESCE((select sum(qty) from invdetails where invdetails.type='" & cbType.SelectedValue & _
            '   "' and invno=26 and invdt= convert(datetime,'" & SysDt & "') and invdetails.batchid=batch.batchid),0)) - " & _
            '   " COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0)) <>0 and " & _
            '    "Batch.PrdCode = """ & dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & """  and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "'))  order by BatchId"

            ''Else
            '    'cmd.CommandText = "select Batch.Batch,Batch.ExDt,Batch.PRate,Batch.SRate,Batch.Pack," & _
            '    "Batch.Stock - " & _
            '    "COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0) AS STOCK,AcMaster.AcName as [Supplier],Batch.Profit,Batch.SCST,Batch.Stax,Batch.TaxInc," & _
            '    "Batch.BillNo,Batch.BillDt,Batch.PCST,Batch.Ptax,Batch.BatchId," & _
            '    "product.case1 FROM Batch INNER JOIN " & _
            '    "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN " & _
            '    "Acmaster ON Batch.Supcode = Acmaster.AcCode " & _
            '    " WHERE Batch.Stock<>0 and " & _
            '    "(Batch.Stock - COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0))<>0 and " & _
            '    "Batch.PrdCode = """ & dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & """  and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "'))  order by BatchId"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value
            If EditFlag Then
                cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = EditDt
            Else
                cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = SysDt

            End If
            cmd.Parameters.Add("@edit", OleDb.OleDbType.Integer).Value = IIf(EditFlag, 1, 0)
            cmd.Parameters.Add("@type", OleDb.OleDbType.VarChar, 2).Value = EditType
            cmd.Parameters.Add("@no", OleDb.OleDbType.BigInt).Value = EditNum
            cmd.Parameters.Add("@ord", OleDb.OleDbType.BigInt).Value = BillOrder

            cmd.CommandText = "GetBatchinv"


            DA.SelectCommand = cmd
            DA.Fill(DS, "BatchDet")
            dgBDet.DataSource = Nothing
            dgBDet.DataSource = DS.Tables("BatchDet")
            dgBDet.CurrentCell = Nothing
            dgBDet.Columns("unac").Visible = False
            dgBDet.Columns("nodisc").Visible = False
            'dgBDet.Columns(0).Width = 100 'Batch
            'dgBDet.Columns(1).Width = 95 'Exdt
            'dgBDet.Columns(2).Visible = False
            'dgBDet.Columns(2).Width = 70 'Prate
            'dgBDet.Columns(3).Width = 70 'Srate
            'dgBDet.Columns(4).Width = 120 'Pack
            'dgBDet.Columns(5).Width = 70 'Stock
            'dgBDet.Columns(6).Width = 250 'Supplier
            'dgBDet.Columns(7).Width = 70 'Profit
            'dgBDet.Columns(7).Visible = False
            'dgBDet.Columns(8).Width = 68 'Scst
            'dgBDet.Columns(8).Visible = False
            'dgBDet.Columns(9).Width = 68 'Stax
            'dgBDet.Columns(10).Width = 65 'TaxInc
            'dgBDet.Columns(11).Width = 65 'Billno
            'dgBDet.Columns(12).Width = 95 'Billdt
            'dgBDet.Columns(13).Width = 65 'Pcst
            'dgBDet.Columns(13).Visible = False
            'dgBDet.Columns(14).Width = 65 'Ptax
            'dgBDet.Columns(14).Visible = False
            'dgBDet.Columns(15).Visible = False
            'dgBDet.Columns(16).Visible = False

            'dgBDet.Columns(5).DefaultCellStyle.ForeColor = Color.Blue
            ''dgBDet.Columns(5).DefaultCellStyle.    
            'dgBDet.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Prate
            'dgBDet.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Srate
            'dgBDet.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Stock
            'dgBDet.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Profit
            'dgBDet.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Scst
            'dgBDet.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Stax
            'dgBDet.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Pcst
            'dgBDet.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Ptax

            'dgBDet.Columns.Item(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgBDet.Columns.Item(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            'DisableBatchGrid()
            'pnlPDet.Visible = True
            'If dgInv.CurrentCell.ColumnIndex = 12 Then
            Try
                If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                    For i = 0 To dgBDet.RowCount - 1
                        If dgInv.Item(2, dgInv.CurrentRow.Index).Value = dgBDet.Item(15, i).Value Then
                            dgBDet.CurrentCell = dgBDet.Item(0, i)
                            '  dgBDet.Rows(i).Height = 10

                        End If

                    Next

                End If
            Catch ex As Exception

            End Try

            'End If
            For i = 0 To dgBDet.RowCount - 1
                ExpColorBat(i)

            Next



            '          Batch.Batch,Batch.ExDt,Batch.PRate,Batch.SRate,Batch.Pack, 
            '  (convert(int,(Batch.Stock+COALESCE((select sum(qty) from invdetails where invdetails.type = @type 
            'and invno=@no and invdt= @sysdt and invdetails.batchid=batch.batchid),0)) -  
            'COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (OutGo.Batchid = Batch.BatchId)),0))) AS Stock,
            'AcMaster.AcName as [Supplier],Batch.Profit,Batch.SCST,Batch.Stax AS [VAT],Batch.TaxInc, 
            'Batch.BillNo,Batch.BillDt,Batch.PCST,Batch.Ptax,Batch.BatchId,product.case1

            dgBDet.Columns(0).Width = 80 'Batch
            dgBDet.Columns(1).Width = 90 'Exdt
            'dgBDet.Columns(2).Visible = False

            dgBDet.Columns(3).Width = 70 'Srate
            dgBDet.Columns(4).Width = 70 'Pack
            dgBDet.Columns(5).Width = 50 'Stock
            dgBDet.Columns(6).Width = 120 'Supplier

            dgBDet.Columns(7).Width = 80 '100
            ' dgBDet.Columns(7).Visible = False

            dgBDet.Columns(8).Visible = False
            dgBDet.Columns(9).Width = 68 'Stax
            dgBDet.Columns(10).Width = 65 'TaxInc
            dgBDet.Columns(10).Visible = False
            dgBDet.Columns(11).Width = 70 'Billno
            dgBDet.Columns(12).Width = 100 'Billdt

            dgBDet.Columns(13).Visible = False

            dgBDet.Columns(14).Visible = False
            dgBDet.Columns(15).Visible = False
            dgBDet.Columns(16).Visible = False

            If ShowPrateInSales = False Then

                dgBDet.Columns(2).Visible = False
                dgBDet.Columns(7).Visible = False
                dgBDet.Columns(9).Visible = False
                dgBDet.Columns(10).Visible = False
            End If

            dgBDet.Columns(5).DefaultCellStyle.ForeColor = Color.Blue

            'dgBDet.Columns(5).DefaultCellStyle.    
            dgBDet.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Prate
            dgBDet.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Srate
            dgBDet.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Stock
            dgBDet.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Profit
            dgBDet.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Scst
            dgBDet.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Stax
            dgBDet.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Pcst
            dgBDet.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Ptax

            dgBDet.Columns.Item(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgBDet.Columns.Item(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            pnlPDet.Height = dgInv.Top - 26

            pnlPDet.Visible = True
            ' Me.Refresh()
            'Me.ResizeRedraw = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub



    'Private Sub GetProduct(ByVal pcode As String)
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim unittab As New DataTable

    '    unittab.TableName = "Pack"
    '    unittab.Columns.Add()
    '    unittab.Columns(0).ColumnName = "unit"
    '    unittab.Columns.Add()
    '    unittab.Columns(1).ColumnName = "Case"

    '    cmd.Connection = Conn
    '    cmd.CommandText = "Select PrdName,unit1,Case1,unit2," & _
    '                      "case2,unit3,case3 from product where prdcode='" + pcode + "' "
    '    ProdSelected = True
    '    Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
    '    If dataredr.HasRows Then
    '        dataredr.Read()
    '        txtEdit.Text = dataredr.Item("Prdname")

    '        CbEditUnit.DataSource = Nothing
    '        dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = dataredr.Item("unit1")
    '        dgInv.Item(11, dgInv.CurrentCell.RowIndex).Value = dataredr.Item("case1") & " (" & dataredr.Item("unit1") & ") "
    '        unittab.Rows.Add(dataredr.Item("unit1"), dataredr.Item("case1"))
    '        If dataredr.Item("unit2") <> 0 Then
    '            unittab.Rows.Add(dataredr.Item("unit2"), dataredr.Item("case2"))
    '        End If

    '        If dataredr.Item("unit3") <> 0 Then
    '            unittab.Rows.Add(dataredr.Item("unit3"), dataredr.Item("case3"))
    '        End If
    '        CbEditUnit.ValueMember = "unit"
    '        CbEditUnit.DisplayMember = "Case"
    '        CbEditUnit.DataSource = unittab

    '    End If

    '    ProdSelected = False

    'End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Dim WD As Integer
        Try
            WD = 0
            cntrol.Location = dgInv.Location
            cntrol.top = dgInv.Top
            cntrol.left = dgInv.Left
            cntrol.top = dgInv.Top + dgInv.GetRowDisplayRectangle(dgInv.CurrentCell.RowIndex, True).Top
            cntrol.left = dgInv.Left + dgInv.GetColumnDisplayRectangle(dgInv.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgInv.GetColumnDisplayRectangle(dgInv.CurrentCell.ColumnIndex, True).Width
            cntrol.Text = dgInv.CurrentCell.Value & ""

            cntrol.Visible = True
            Application.DoEvents()
            cntrol.Focus()

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub EditGrid()
        Try
            'If dgInv.CurrentCell.RowIndex = dgInv.Rows.Count - 1 Then dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            If dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & "" = "" And dgInv.CurrentCell.ColumnIndex > 7 Then
                If UseBarCode Then
                    dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
                Else
                    dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
                End If

            End If

            If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" And dgInv.CurrentCell.ColumnIndex = 11 Then
                Exit Sub
            End If

            If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 And dgInv.CurrentCell.ColumnIndex = 7 Then
                Exit Sub
            End If

            EDROW = dgInv.CurrentCell.RowIndex
            EDCOL = dgInv.CurrentCell.ColumnIndex
            'If EDCOL = 0 Then
            '    EDCOL = 7
            '    dgInv.CurrentCell = dgInv.Item(EDCOL, EDROW)
            'End If

            If IsNothing(dgInv.CurrentCell) Then Exit Sub

            Select Case dgInv.CurrentCell.ColumnIndex
                Case 0
                    If UseBarCode Then
                        dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                    Else
                        dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                    End If
                    EditGrid()
                Case 13, 22
                    Exit Sub
                Case 12 'batch
                    TabFlag = True
                    dgInv.Enabled = False
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then
                        BatchDeselect()
                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        WriteOutGo(-3, 0, dgInv.CurrentRow.Index)
                    End If
                    GetBatchDetails()
                    'Calculate()
                    'EnableBatchGrid()

                    dgInv.Enabled = False
                    dgBDet.Focus()

                Case 11 'pack
                    TabFlag = True
                    dgInv.Enabled = False

                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then Exit Sub
                    dgInv.Enabled = False
                    GetPacking()
                    If Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "") <> 0 Then
                        CbEditUnit.SelectedValue = Round(Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & ""), 0)
                        'Else
                        '    CbEditUnit.SelectedValue = 1
                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then

                        WriteOutGo(-3, 0, dgInv.CurrentRow.Index)
                        GetBatchDetails()
                    End If
                    ShowEditControl(CbEditUnit)
                Case 16
                    TabFlag = True
                    dgInv.Enabled = False

                    dgInv.Enabled = False
                    ShowEditControl(cbEditVat)
                Case 17
                    TabFlag = True
                    dgInv.Enabled = False

                    ShowEditControl(CbEditTaxInc)
                Case 8 'qty
                    TabFlag = True
                    dgInv.Enabled = False
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then
                        BatchDeselect()

                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        WriteOutGo(-3, 0, dgInv.CurrentRow.Index)
                        GetBatchDetails()
                    Else

                    End If
                    TabFlag = True
                    dgInv.Enabled = False
                    ShowEditControl(txtEdit)
                    txtEdit.SelectAll()
                Case 13
                    Exit Sub
                Case Else

                    TabFlag = True
                    dgInv.Enabled = False

                    ShowEditControl(txtEdit)
                    txtEdit.SelectAll()

            End Select
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.GotFocus
        dgInv.Enabled = False
    End Sub

    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Dim totstk As Long
        Try

            If e.KeyCode = Keys.Enter Then

                Select Case dgInv.CurrentCell.ColumnIndex
                    Case 8
                        If Val(txtEdit.Text) <> 0 Then
                            totstk = 0
                            For i = 0 To dgBDet.Rows.Count - 1
                                totstk = totstk + Val(dgBDet.Item(5, i).Value & "")
                            Next
                            If Val(txtEdit.Text) > totstk Then
                                MsgBox("Insufficient Stotk..")
                                Exit Sub
                            End If

                            dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0")
                            If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 Then
                                AdjQty()
                                dgInv.CurrentCell = dgInv.Item(7, dgInv.RowCount - 1)
                                EditGrid()
                                Calculate()
                                Exit Sub
                            Else
                                dgInv.Enabled = True
                                dgInv.Focus()
                                txtEdit.Visible = False
                                dgInv.CurrentCell = dgInv.Item(11, dgInv.CurrentCell.RowIndex)
                                EditGrid()
                                Calculate()
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If

                    Case 14
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0.0000")
                        dgInv.CurrentCell = dgInv.Item(14, dgInv.CurrentCell.RowIndex)
                        txtEdit.Visible = False
                        dgInv.Enabled = True

                    Case 15
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0.00")
                        dgInv.CurrentCell = dgInv.Item(15, dgInv.CurrentCell.RowIndex)
                        dgInv.Enabled = True
                    Case 7
                        If txtEdit.Text = "" And UseBarCode Then
                            dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
                            EditGrid()
                        End If
                        Exit Sub
                        e.Handled = True
                    Case 1
                        If txtEdit.Text = "" Then
                            dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
                            EditGrid()
                            Exit Sub
                        Else

                            GetBarcode()
                            Exit Sub
                        End If
                End Select
                dgInv.Enabled = True
                dgInv.Focus()
                Calculate()
                Exit Sub
            End If

            If e.KeyCode = Keys.Escape Then
                dgInv.Enabled = True
                If dgInv.CurrentRow.Index = dgInv.RowCount - 1 Then
                    dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
                    txtEdit.Visible = False
                    If Val(dgInv.Item(0, dgInv.CurrentRow.Index).Value & "") <> 0 Then slno = slno - 1
                    ClearRow()
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub GetBarcode()

        Try

            Dim dt, dt2, dt3 As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            Dim tmpvar As Double
            Dim pn As String
            Dim pc As String
            Dim ic As Integer
            cmd.Connection = Conn

            tsbSave.Enabled = False
            'Check for the stock if present
            cmd.CommandText = "select isnull(prdcodeasbarcode,0) from settings"
            Dim cd, bat As String
            If Microsoft.VisualBasic.Left(txtEdit.Text, 1) = "B" And cmd.ExecuteScalar = 0 Then

                bat = Microsoft.VisualBasic.Mid(txtEdit.Text, 2, 15)

                cd = RTrim(LTrim(Microsoft.VisualBasic.Left(txtEdit.Text, 6)))

                cmd.Connection = Conn
                cmd.CommandText = "Select batch.*,product.prdcode,product.prdname,product.case1 from batch,product  where product.prdcode=batch.prdcode and batchid=" + bat

                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows(0).Item("stock") = 0 Then

                    cmd.CommandText = "Select batch.*,product.prdcode,product.prdname,product.case1 from batch,product  where product.prdcode=batch.prdcode and prdcode=""" + dt.Rows(0).Item("prdcode") & """ and batch.batch=""" & dt.Rows(0).Item("batch") & """ and stock<>0 "
                    dt.Rows.Clear()
                    dt.Clear()
                    da.Fill(dt)
                End If

                If dt.Rows.Count > 0 Then
                    If dgInv.CurrentCell.RowIndex = 0 Then slno = 0
                    slno = slno + 1
                    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno
                    dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("prdcode")
                    dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("batchid")
                    dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = 1
                    dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("PrdName")
                    dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value = Round(dt.Rows(0).Item("unit"), 0, MidpointRounding.AwayFromZero)
                    dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value = 0
                    dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value = 0
                    dgInv.Item(11, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("case1") & ""
                    dgInv.Item(12, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("batch") & ""

                    If IsDBNull(dt.Rows(0).Item("ExDt")) Then
                        ' dgInv.Item(13, dgInv.CurrentCell.RowIndex).Value = ""
                    Else
                        dgInv.Item(13, dgInv.CurrentCell.RowIndex).Value = dt.Rows(0).Item("ExDt")

                    End If

                    dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value = Round(dt.Rows(0).Item("srate"), 4, MidpointRounding.AwayFromZero)
                    dgInv.Item(15, dgInv.CurrentCell.RowIndex).Value = "0.00"
                    dgInv.Item(16, dgInv.CurrentCell.RowIndex).Value = Round(dt.Rows(0).Item("stax"), 2)
                    If (dt.Rows(0).Item("TaxInc")) = 0 Then
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                    Else
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                    End If

                    WriteOutGo(dt.Rows(0).Item("batchid"), Round(1, 2, MidpointRounding.AwayFromZero), dgInv.Rows.Count - 1)
                    dgInv.Update()
                    Sales.Rows.Add()

                    Calculate()

                    If UseBarCode Then
                        dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                    Else
                        dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                    End If
                    'dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                    dgInv.Focus()
                    ShowEditControl(txtEdit)
                    txtEdit.Focus()
                    pnlprod.Visible = False
                    EDROW = dgInv.CurrentCell.RowIndex
                    EDCOL = dgInv.CurrentCell.ColumnIndex

                    'Application.DoEvents()
                    EditGrid()

                    Exit Sub
                End If

                Exit Sub
            Else
                bat = txtEdit.Text
                dt.Clear()
                cmd.Connection = Conn
                cmd.CommandText = "Select PrdCode from Barcodes where BarCode=""" & txtEdit.Text & """"
                da.SelectCommand = cmd
                da.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    pc = dt2.Rows(0).Item(0)
                Else
                    MsgBox("Product not found...")
                    Exit Sub
                End If

                dt.Clear()
                cmd.CommandText = "Select Batch.Stock - " & _
                    "COALESCE((SELECT sum(tqty) FROM OutGo WHERE " & _
                    "(OutGo.Batchid = Batch.BatchId)),0) AS STOCK,product.color,product.prdname,product.prdcode  from Batch,product Where product.prdcode=batch.prdcode and  Batch.PrdCode=""" & pc & """ and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "')) "
                da.SelectCommand = cmd
                da.Fill(dt3)
                tmpvar = 0
                pn = ""
                If dt3.Rows.Count > 0 Then
                    For i = 0 To dt3.Rows.Count - 1
                        ic = IIf(IsDBNull(dt3.Rows(i).Item("color")), Color.Black.ToArgb, dt3.Rows(i).Item("color"))
                        tmpvar = tmpvar + dt3.Rows(i).Item("stock")
                        pn = dt3.Rows(i).Item("prdname")
                        pc = dt3.Rows(i).Item("prdcode")
                    Next
                Else

                End If

                If tmpvar = 0 Then
                    pnlPDet.Visible = False
                    pnlprod.Visible = False
                    If MsgBox(pn & Chr(13) & "No Stock...!  " & Chr(13) & "Want to add to short list ? ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "Update_ShortItem"
                        cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = pc
                        cmd.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.Text
                    Else

                    End If
                    If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then '
                        tsbSave.Enabled = False
                    Else
                        tsbSave.Enabled = True
                    End If

                    txtEdit.Focus()
                    txtEdit.Text = ""
                    Exit Sub
                End If


                'If tmpvar <> 0 Then
                txtEdit.SelectionStart = Len(txtEdit.Text)
                dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = pc
                dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = pn

                'ic
                dgInv.Item(7, dgInv.CurrentCell.RowIndex).Style.ForeColor = Color.FromArgb(ic)
                If dgInv.CurrentCell.RowIndex = 0 Then
                    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
                    slno = 1
                    'ElseIf dgInv.CurrentCell.RowIndex > 0 And dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                    '    slno = slno + 1
                    '    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

                ElseIf dgInv.CurrentCell.RowIndex > 0 Or dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                    slno = slno + 1
                    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

                End If

                'dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
                pnlPDet.Visible = True
                'lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details..."
                txtEdit.Visible = False
                GetBatchDetails()

                Calculate()
                dgInv.CurrentCell = dgInv.Item(8, dgInv.CurrentCell.RowIndex)
                EDROW = dgInv.CurrentCell.RowIndex
                EDCOL = dgInv.CurrentCell.ColumnIndex
                'Application.DoEvents()
                EditGrid()
                txtEdit.Focus()
                pnlprod.Visible = False
                'Else
            End If

            'tsbSave.Enabled = True
            'End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub GetBarcodeold()

        Try

            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            Dim tmpvar As Double
            Dim pn As String
            Dim pc As String
            Dim ic As Integer
            cmd.Connection = Conn

            tsbSave.Enabled = False
            'Check for the stock if present

            cmd.Connection = Conn
            cmd.CommandText = "Select PrdCode from Barcodes where BarCode=""" & txtEdit.Text & """"
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then


                pc = dt.Rows(0).Item(0)
            Else
                MsgBox("Product not found..")
                Exit Sub
            End If

            dt.Clear()
            cmd.CommandText = "Select Batch.Stock - " & _
                "COALESCE((SELECT sum(tqty) FROM OutGo WHERE " & _
                "(OutGo.Batchid = Batch.BatchId)),0) AS STOCK,product.color,product.prdname,product.prdcode  from Batch,product Where product.prdcode=batch.prdcode and  Batch.PrdCode=""" & pc & """ and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "')) "
            da.SelectCommand = cmd
            da.Fill(dt)
            tmpvar = 0
            pn = ""

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ic = IIf(IsDBNull(dt.Rows(i).Item("color")), Color.Black.ToArgb, dt.Rows(i).Item("color"))
                    tmpvar = tmpvar + dt.Rows(i).Item("stock")
                    pn = dt.Rows(i).Item("prdname")
                    pc = dt.Rows(i).Item("prdcode")
                Next
            Else

            End If

            If tmpvar = 0 Then
                pnlPDet.Visible = False
                pnlprod.Visible = False
                'If MsgBox(pn & Chr(13) & "No Stock..!  " & Chr(13) & "Want to add to short list ? ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Update_ShortItem"
                cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = pc
                cmd.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text
                'Else

                'End If
                If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then '
                    tsbSave.Enabled = False
                Else
                    tsbSave.Enabled = True
                End If

                txtEdit.Focus()
                txtEdit.Text = ""
                Exit Sub
            End If

            'If tmpvar <> 0 Then
            txtEdit.SelectionStart = Len(txtEdit.Text)
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = pc
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = pn

            'ic
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Style.ForeColor = Color.FromArgb(ic)
            If dgInv.CurrentCell.RowIndex = 0 Then
                dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
                slno = 1
                'ElseIf dgInv.CurrentCell.RowIndex > 0 And dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                '    slno = slno + 1
                '    dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

            ElseIf dgInv.CurrentCell.RowIndex > 0 Or dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*" Then
                slno = slno + 1
                dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = slno

            End If

            'dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
            pnlPDet.Visible = True
            'lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            txtEdit.Visible = False
            GetBatchDetails()

            Calculate()
            dgInv.CurrentCell = dgInv.Item(8, dgInv.CurrentCell.RowIndex)
            EDROW = dgInv.CurrentCell.RowIndex
            EDCOL = dgInv.CurrentCell.ColumnIndex
            'Application.DoEvents()
            EditGrid()
            txtEdit.Focus()
            pnlprod.Visible = False
            'Else

            'tsbSave.Enabled = True
            'End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress

        Select Case dgInv.CurrentCell.ColumnIndex
            Case 8
                If Asc(e.KeyChar) = 8 Then Exit Sub
                If InStr("0123456789-.", e.KeyChar) = 0 Then e.KeyChar = ""
        End Select
    End Sub

    Private Sub txtEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.Leave
        'If Not pnlprod.Visible Then

        '    pnlprod.Visible = False
        '    TabFlag = False
        '    If dgInv.CurrentRow.Index < dgInv.RowCount - 1 Then
        '        dgInv.Enabled = True
        '        dgInv.Focus()
        '        txtEdit.Visible = False
        '    End If

        'End If
    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged
        If dgInv.CurrentCell.ColumnIndex = 0 Then

            If dgInv.Rows.Count = 1 Then
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)

            End If
        End If

        Select Case dgInv.CurrentCell.ColumnIndex
            Case 7
                If txtEdit.Tag = "Y" Then Exit Sub
                If ProdSelected = True Then Exit Sub
                obj = txtEdit
                PopulateProduct()
        End Select
    End Sub

    Private Sub GetPacking()

        Dim cmd As New OleDb.OleDbCommand
        Dim unittab1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Try
            unittab1.TableName = "Pack"
            unittab1.Columns.Add()
            unittab1.Columns(0).ColumnName = "unit"
            unittab1.Columns.Add()
            unittab1.Columns(1).ColumnName = "Case"

            cmd.Connection = Conn
            cmd.CommandText = "Select case1,case2,case3,unit1,unit2,unit3 from product where prdcode=""" + dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value + """ "

            ProdSelected = True
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                CbEditUnit.DataSource = Nothing

                unittab1.Rows.Add(dt.Rows(0).Item("unit1"), dt.Rows(0).Item("case1") & " (" & Round(dt.Rows(0).Item("unit1"), 0) & ") ")

                If dt.Rows(0).Item("unit2") <> 0 Then
                    unittab1.Rows.Add(dt.Rows(0).Item("unit2"), dt.Rows(0).Item("case2") & " (" & Round(dt.Rows(0).Item("unit2"), 0) & ") ")
                End If

                If dt.Rows(0).Item("unit3") <> 0 Then
                    unittab1.Rows.Add(dt.Rows(0).Item("unit3"), dt.Rows(0).Item("case3") & " (" & Round(dt.Rows(0).Item("unit3"), 0) & ") ")
                End If

                CbEditUnit.ValueMember = "unit"
                CbEditUnit.DisplayMember = "Case"
                CbEditUnit.DataSource = unittab1
            End If
            ProdSelected = False
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub dgInv_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgInv.CellContextMenuStripNeeded
        'If dgInv.SelectedCells.Contains(dgInv.Item(e.ColumnIndex, e.RowIndex)) Then
        '    dgInv.Item(e.ColumnIndex, e.RowIndex).ContextMenuStrip = cmenu
        'Else
        '    dgInv.Item(e.ColumnIndex, e.RowIndex).ContextMenuStrip = Nothing

        'End If
    End Sub

    Private Sub dgInv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInv.CellEnter
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        cmd.Connection = Conn
        Dim str, msg As String
        tmr.Enabled = False
        tmr.Stop()
        lblsch.Visible = False
        If dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & "" = "" Then Exit Sub
        cmd.CommandText = "select sched,invmsg from product where prdcode=""" & dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & """ "
        da.SelectCommand = cmd
        da.Fill(dt)
        lblsch.Text = ""
        If dt.Rows.Count > 0 Then
            str = dt.Rows(0).Item(0) & ""
            msg = dt.Rows(0).Item(1) & ""
            lblsch.Visible = False

            If UCase(Trim(str)) = "H" Or UCase(Trim(str)) = "H1" Or UCase(Trim(str)) = "X" Or UCase(Trim(str)) = "H*" Then
                lblsch.Text = "Schedule " & str & " Drug. "
            End If
            If msg <> "" Then
                If lblsch.Text <> "" Then
                    lblsch.Text = lblsch.Text & Chr(13)
                End If
                lblsch.Text = lblsch.Text & msg
            End If

            If Trim(lblsch.Text) <> "" Then
                tmr.Enabled = True
                tmr.Start()
                lblsch.Visible = True
            End If
        End If
    End Sub

    Public Sub DeleteRenumberRows()

        Dim TMPSL As String = dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value
        Dim i, vi, vii As Integer
        i = 0
        vi = 0

        While i <= dgInv.Rows.Count - 1
            If dgInv.Item(0, i).Value & "" = TMPSL Then
                WriteOutGo(-4, 0, i, False)
                dgInv.Rows.Remove(dgInv.Rows(i))
                vi = 1
                dgInv.Focus()

            Else

                If vi = 1 Then
                    If InStr(dgInv.Item(0, i).Value & "", "*") <> 0 Then
                        vii = Val(dgInv.Item(0, i).Value & "")
                        If vii > 0 Then
                            dgInv.Item(0, i).Value = vii - 1 & "*"
                            slno = vii - 1
                        End If

                    Else
                        vii = Val(dgInv.Item(0, i).Value & "")
                        If vii > 0 Then
                            dgInv.Item(0, i).Value = vii - 1
                            slno = vii - 1
                        End If

                        vii = vii + 1

                    End If
                End If

                i = i + 1
            End If
        End While
    End Sub

    Private Sub dgInv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.DoubleClick
        'If Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value & "") < 0 Then
        ' GetProduct(dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value)
        ' Else
        Try
            EditGrid()
            'End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgInv.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                EditGrid()
                e.Handled = True
                Exit Sub

                'If Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value & "") < 0 Then
                '    GetProduct(dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value)
                'Else
                'EditGrid()
                'End If

                'e.Handled = True


                'EDROW = dgInv.CurrentCell.RowIndex
                'EDCOL = dgInv.CurrentCell.ColumnIndex

                'Application.DoEvents()
                Select Case dgInv.CurrentCell.ColumnIndex

                    Case 8

                        If Microsoft.VisualBasic.InStr(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", "*") <> 0 Then
                            BatchDeselect()
                            pnlPDet.Visible = True
                            'dgBDet.CurrentRow.Selected = False

                            GetBatchDetails()

                            'If Val(dgInv.Item(0, dgInv.Rows.Count - 1).Value.ToString) <> 0 Then
                            '    dgInv.Update()
                            '    Sales.Rows.Add()
                            'End If
                            'dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                            'dgInv.Focus()
                            'ShowEditControl(txtEdit)

                        End If
                        'pnlPDet.Visible = False

                    Case 12
                        'If dgInv.CurrentCell.RowIndex <> Nothing Then
                        GetBatchDetails()
                        Calculate()
                        pnlPDet.Visible = True

                        dgBDet.Focus()
                        'Else
                        'lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
                        'End If
                        dgBDet.Focus()
                End Select
                e.Handled = True
            End If

            If e.KeyCode = Keys.Delete And dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 Then
                If MsgBox("Want to Delete the item ' " & dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value.ToString & " '..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    '    If Microsoft.VisualBasic.InStr(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value, "*") <> 0 Then
                    '        BatchDeselect()
                    '    Else
                    '        WriteOutGo(-3, Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value), dgInv.CurrentCell.RowIndex)
                    '    End If
                    DeleteRenumberRows()
                    Calculate()
                    If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then
                        tsbSave.Enabled = False
                    End If
                End If
            End If

            If e.KeyCode = Keys.Escape Then
                'pnlPDet.Visible = False
                ''For k = 0 To dgInv.Rows.Count - 1
                ''    If dgInv.CurrentCell.RowIndex = Nothing And dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then
                ''        tsbSave.Enabled = False
                ''    Else
                ''        tsbSave.Enabled = True
                ''    End If
                ''Next
                e.Handled = True
            End If

            If e.KeyCode = Keys.F4 Then
                PopulateProductInfo(dgInv.CurrentRow.Cells(1).Value, 1)
            End If

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub BatchDeselect()
        Dim cmd As New OleDb.OleDbCommand
        Dim TMPSL As String
        Dim tmprow As Integer
        Dim i As Integer
        Dim tmpqty As Long
        Try
            cmd.Connection = Conn

            TMPSL = dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value

            tmpqty = 0 'Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value)

            tmprow = -1
            i = 0

            While i <= dgInv.Rows.Count - 1
                If dgInv.Item(0, i).Value & "" = TMPSL Then
                    tmpqty = tmpqty + Val(dgInv.Item(8, i).Value)


                    'sql = "update batch set outgo = outgo - " & _
                    '            Val(dgInv.Item(3, i).Value) * (Val(dgInv.Item(8, i).Value) + Val(dgInv.Item(9, i).Value) + Val(dgInv.Item(10, i).Value)) & _
                    '            " where batchid = " & Val(dgInv.Item(2, i).Value)
                    WriteOutGo(-3, Val(dgInv.Item(8, i).Value), i)

                    If tmprow = -1 Then
                        tmprow = i
                        dgInv.Item(0, i).Value = Microsoft.VisualBasic.Left(TMPSL, Len(TMPSL) - 1)
                        i = i + 1
                        'dgInv.Item(3, i).Value = ""     'to clear outgo when cancel clicked
                    Else

                        dgInv.Rows.Remove(dgInv.Rows(i))
                        WriteOutGo(-2, 0, i)

                    End If
                Else
                    i = i + 1
                End If

            End While


            dgInv.CurrentCell = dgInv.Item(dgInv.CurrentCell.ColumnIndex, tmprow)
            dgInv.Item(8, tmprow).Value = tmpqty
            EditGrid()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub dgInv_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgInv.Scroll
        cbEditVat.Visible = False
        CbEditUnit.Visible = False
        txtEdit.Visible = False
    End Sub

    Private Sub CbEditUnit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditUnit.GotFocus
        dgInv.Enabled = False
    End Sub

    Private Sub CbEditUnit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditUnit.KeyDown

        Try

            If e.KeyCode = Keys.Enter Then
                dgInv.Enabled = True
                CbEditUnit.Visible = False
                dgInv.CurrentCell.Value = CbEditUnit.Text '& " (" & CbEditUnit.SelectedValue & ") "
                dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = Round(Val(CbEditUnit.SelectedValue), 0)

                If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 Then
                    AdjQty()

                Else
                    dgInv.CurrentCell = dgInv.Item(12, dgInv.CurrentCell.RowIndex)
                    EditGrid()
                End If
                Calculate()
            End If

            If e.KeyCode = Keys.Escape Then
                dgInv.Enabled = True
                If dgInv.CurrentRow.Index = dgInv.RowCount - 1 Then
                    CbEditUnit.Visible = False
                    dgInv.CurrentCell = dgInv.Item(8, dgInv.CurrentCell.RowIndex)
                    EditGrid()
                Else
                    'pnlPDet.Visible = False
                    'CbEditUnit.Visible = False
                    'dgInv.Focus()


                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditUnit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditUnit.Leave
        'If dgInv.CurrentRow.Index < dgInv.RowCount - 1 Then
        '    CbEditUnit.Visible = False
        '    dgInv.Enabled = True
        '    dgInv.Focus()
        'End If
    End Sub

    Private Sub cbEditVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbEditVat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dgInv.CurrentCell.Value = cbEditVat.Text
                cbEditVat.Visible = False
                dgInv.Enabled = True
                dgInv.Focus()
                Calculate()
            End If
            If e.KeyCode = Keys.Escape Then

                dgInv.Enabled = True
                dgInv.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbEditVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEditVat.Leave
        cbEditVat.Visible = False

        dgInv.Enabled = True
        dgInv.Focus()
    End Sub

    Private Sub CbEditTaxInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditTaxInc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dgInv.CurrentCell.Value = CbEditTaxInc.Text
                CbEditTaxInc.Visible = False
                dgInv.Enabled = True
                dgInv.Focus()
                Calculate()
            End If
            If e.KeyCode = Keys.Escape Then
                CbEditTaxInc.Visible = False
                dgInv.Enabled = True
                dgInv.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditTaxInc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditTaxInc.Leave
        CbEditTaxInc.Visible = False
        dgInv.Enabled = True
        dgInv.Focus()

    End Sub

    Public Sub Calculate()
        Dim n As Integer
        Dim vcnt As Long
        Dim i, fnd, stk, scst, stax, bdis, sr, abdis, amtval, tmprnd As Double
        Try
            unacamt = 0
            amtval = 0
            tmprnd = 0
            totvalue = 0
            value = 0
            totscst = 0
            Svalue = 0
            totstax = 0
            totadj = 0
            tfamt = 0
            totcst = 0
            totbdis = 0
            totsdis = 0
            abdis = 0
            totstax = 0
            subtot = 0
            totrtntax = 0
            totrtnval = 0

            For i = 0 To 4
                rtaxary(i, 1) = 0
                rptax(i, 1) = 0
            Next i
            'vcnt = 0
            For n = 0 To dgInv.Rows.Count - 2
                stk = 0
                value = 0
                scst = 0
                stax = 0
                sr = 0
                Svalue = 0
                stax = 0
                stk = Val(dgInv.Item(8, n).Value)

                'dgInv.Item(0, n).Value = vcnt

                'If dgInv.Item(0, n).Value Then

                'End If

                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgInv.Item(14, n).Value)), 2)
                    scst = value * Val(dgInv.Item(15, n).Value) / 100
                    totcst = totcst + scst
                    value = value + scst
                    bdis = 0

                    If Not CBool(dgInv.Item(21, n).Value) Then
                        bdis = value * Val(txtDis.Text) / 100
                    End If

                    totbdis = totbdis + bdis
                    value = value - bdis
                    If CBool(dgInv.Item(20, n).Value) And cbType.SelectedValue = 21 Then
                        unacamt = unacamt + value
                    Else

                        If Val(dgInv.Item(16, n).Value) <> 0 Then

                            If dgInv.Item(17, n).Value = "Yes" Then
                                'stax = Round(value * Val(dgInv.Item(16, n).Value) / (100 + Val(dgInv.Item(16, n).Value)), 2)
                                'value = value - stax
                            Else
                                value = Round(value + (value * Val(dgInv.Item(16, n).Value) / 100), 2)
                            End If

                            fnd = 0
                            For i = 0 To 4
                                If Val(dgInv.Item(16, n).Value) = rtaxary(i, 0) Then
                                    rtaxary(i, 1) = rtaxary(i, 1) + value
                                    ' rptax(i, 1) = rptax(i, 1) + stax
                                    fnd = 1
                                    Exit For
                                End If
                            Next i
                            If fnd = 0 Then
                                tfamt = tfamt + value '+ stax
                            End If
                        Else
                            tfamt = tfamt + value
                        End If
                    End If

                    totstax = totstax + stax
                    'If dgInv.Item(17, n).Value = "No" Then
                    '     value = value + stax
                    'End If

                    dgInv.Item(22, n).Value = Format(value + stax, "0.00")
                    totvalue = totvalue + value
                End If

            Next

            lblTamt.Text = Format(totvalue + totstax, "0.00")

            '-------------

            For n = 0 To dgRtn.Rows.Count - 2
                stk = 0
                value = 0
                scst = 0
                stax = 0
                sr = 0
                Svalue = 0
                stax = 0
                stk = Val(dgRtn.Item(8, n).Value) * -1
                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgRtn.Item(14, n).Value)), 2)
                    value = value
                    scst = value * Val(dgRtn.Item(15, n).Value) / 100
                    totcst = totcst + scst
                    value = value + scst
                    bdis = 0
                    If Not CBool(dgRtn.Item(20, n).Value) Then

                        bdis = value * Val(lblrtnval.Tag) / 100

                    End If


                    totbdis = totbdis + bdis
                    value = value - bdis

                    If Val(dgRtn.Item(16, n).Value) <> 0 Then

                        If dgRtn.Item(17, n).Value = "Yes" Then
                            'stax = value * Round(Val(dgRtn.Item(16, n).Value) / (100 + Val(dgRtn.Item(16, n).Value)), 2)
                            'value = value - stax
                        Else
                            value = Round(value + (value * Val(dgRtn.Item(16, n).Value) / 100), 2)

                        End If
                        fnd = 0
                        For i = 0 To 4
                            If Val(dgRtn.Item(16, n).Value) = rtaxary(i, 0) Then
                                rtaxary(i, 1) = rtaxary(i, 1) + value
                                'rptax(i, 1) = rptax(i, 1) + stax
                                fnd = 1
                                Exit For
                            End If
                        Next i
                        If fnd = 0 Then
                            tfamt = tfamt + value '+ stax
                        End If
                    Else
                        tfamt = tfamt + value
                    End If

                    totstax = totstax + stax
                    value = value + stax
                    dgRtn.Item(22, n).Value = Format(value, "0.00")
                    totvalue = totvalue + value
                    totrtnval = totrtnval + value
                    totrtntax = totrtntax + stax
                End If

            Next


            '-----

            totvalue = 0
            Dim RAMT, TX As Double
            For i = 0 To 4
                RAMT = Round(rtaxary(i, 1), 2) '+ Round(rptax(i, 1), 2)
                TX = Round(RAMT * rtaxary(i, 0) / (rtaxary(i, 0) + 100), 2)
                RAMT = Round(RAMT - TX, 2)
                rtaxary(i, 1) = RAMT 'Round(rtaxary(i, 1), 2)
                rptax(i, 1) = TX ''Round(rptax(i, 1), 2)
                totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1)
            Next

            tfamt = Round(tfamt, 2)
            totvalue = totvalue + tfamt + unacamt

            totadj = Val(txtAdd.Text) - Val(txtDed.Text)

            totvalue = Val(Format(totvalue, "0.00"))
            totstax = Val(Format(totstax, "0.00"))
            totbdis = Val(Format(totbdis, "0.00"))
            totsdis = Val(Format(totsdis, "0.00"))
            totscst = Val(Format(totscst, "0.00"))
            subtot = totvalue
            amtval = Format(totvalue, "0.00")
            tmprnd = Format(amtval, "0")
            txtAdd.Text = "0.00"
            txtDed.Text = "0.00"

            tmprnd = RoundPaise(amtval, RndPai)


            If cbType.SelectedValue = "22" Then
                ' Dim vvj As Double
                tmprnd = Math.Round(amtval, 0)
                ' tmprnd = tmprnd - amtval
                ' amtval = vvj
            End If

            If Val(amtval) - Val(tmprnd) < 0 Then
                txtAdd.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            ElseIf Val(amtval) - Val(tmprnd) > 0 Then
                txtDed.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            End If

            lblNamt.Text = Format(totvalue + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
            lblrtnval.Text = Format(totrtnval, "0.00")
            'If Not EditFlag Then
            If cbType.SelectedValue = "21" Then
                txtcash.Text = lblNamt.Text
            ElseIf cbType.SelectedValue = "27" Then
                If Not EditFlag Then txtcrcard.Text = lblNamt.Text
            Else

                txtcash.Text = "0.00"
                txtcrcard.Text = "0.00"
                txtcoup.Text = "0.00"
            End If


            If Val(txtRecv.Text) <> 0 Then
                lblchange.Text = "Change: " & Format(Val(txtRecv.Text) - Val(lblNamt.Text), "0.00")
            Else
                lblchange.Text = "Change: "
            End If


            'End If
            If dgInv.Rows.Count > 1 Then tsbSave.Enabled = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDis.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
            'txtDed.Text = Format(txtDed.Text, "0.00")
            'txtDed.Focus()
            'txtDed.SelectAll()

            'If UseBarCode Then
            '    dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)

            'Else
            '    dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            'End If
            'EditGrid()
            'Exit Sub
        End If


    End Sub

    Private Sub txtDis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDis.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtDis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDis.LostFocus
        txtDis.Text = Format(Val(txtDis.Text), "0.00")
    End Sub

    Private Sub txtDis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDis.TextChanged
        Calculate()
    End Sub



    Private Sub dgInv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.LostFocus
        Try
            dgInv.CurrentCell.Selected = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgInv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.GotFocus
        Try
            dgInv.CurrentCell.Selected = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        If dgInv.RowCount > 1 Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If

        ClearForm()
    End Sub
    Private Sub pnlprod_VisibleChanged(sender As Object, e As System.EventArgs) Handles pnlprod.VisibleChanged
        pnlgen.Visible = pnlprod.Visible
    End Sub
    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        'If dgInv.RowCount > 1 Then
        '    If MsgBox("Entries found. Want to exit now..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        'End If
        Me.Close()
    End Sub

    Private Sub Convert()
        'If curunit <> 0 Then
        'dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value = Format((Val(dgBDet.Item(3, dgBDet.CurrentCell.RowIndex).Value) / Val(dgBDet.Item(4, dgBDet.CurrentCell.RowIndex).Value)) * CbEditUnit.SelectedValue, "0.000")
        'curunit = CbEditUnit.SelectedValue
        'Else
        'curunit = CbEditUnit.SelectedValue
        'End If
        Calculate()
    End Sub

    Private Sub txtDed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDed.KeyDown
        If e.KeyCode = Keys.Enter Then
            'txtDed.Text = Format(txtDed.Text, "0.00")
            txtAdd.Focus()
            txtAdd.SelectAll()
        End If
    End Sub

    Private Sub txtDed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDed.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtDed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDed.LostFocus
        txtDed.Text = Format(Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtDed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDed.TextChanged
        lblNamt.Text = Format(Val(subtot) + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtAdd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdd.KeyDown

    End Sub

    Private Sub txtAdd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdd.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdd.LostFocus
        txtAdd.Text = Format(Val(txtAdd.Text), "0.00")
    End Sub

    Private Sub txtAdd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd.TextChanged
        lblNamt.Text = Format(Val(subtot) + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub dgBDet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.LostFocus
        'dgBDet.CurrentRow.Selected = False
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim rpt As Object

        If EditFlag Then
            If CheckUserLocked("Edit Sales", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub
        End If

        If CbPrintOut.SelectedIndex = 1 Then
            If CheckUserLocked("View Bill", , ) = False Then Exit Sub
        End If

        If txtsmcode.Visible Then
            If cbSal.SelectedValue = 0 Then
                txtsmcode.Focus()
                txtsmcode.SelectAll()
                Exit Sub
            End If
        Else
            If cbSal.Text = "" Then
                MsgBox("Select a salesman", vbInformation)
                Exit Sub
            End If
        End If

        Dim DISCHK1, DISCHK2 As Boolean
        DISCHK1 = True


        If cbType.SelectedValue <> "24" Then
            If Val(lblNamt.Text) <= ComputerRights.SaAmtForDisc And Val(txtDis.Text) <> 0 And ComputerRights.SaAmtForDisc <> 0 Then
                'MsgBox("Amount bellow " & ComputerRights.SaAmtForDisc & "/-. discount not allowed.")
                ' txtDis.Text = "0.00"
                DISCHK1 = False
            End If
            If Val(lblNamt.Text) <= LoginRights.SaAmtForDisc And Val(txtDis.Text) <> 0 And LoginRights.SaAmtForDisc <> 0 Then
                'MsgBox("Amount bellow " & LoginRights.SaAmtForDisc & "/-. discount not allowed.")
                ' txtDis.Text = "0.00"
                DISCHK1 = False
            End If
        End If


        If cbType.SelectedValue <> "24" Then
            If Val(txtDis.Text) > ComputerRights.SaDiscLmt And ComputerRights.SaDiscLmt <> 0 Then
                '  MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                'txtDis.Text = "0.00"
                DISCHK1 = False
            End If
            If Val(txtDis.Text) > LoginRights.SaDiscLmt And LoginRights.SaDiscLmt <> 0 Then
                ' MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                'txtDis.Text = "0.00"
                DISCHK1 = False
            End If
        End If

        DISCHK2 = DISCHK1
        ' ------------------ DISC 2ND SLAB
        If Val(lblNamt.Text) >= ComputerRights.SaDiscLmt2 Then
            If cbType.SelectedValue <> "24" Then
                If Val(lblNamt.Text) <= ComputerRights.SaAmtForDisc2 And Val(txtDis.Text) <> 0 And ComputerRights.SaAmtForDisc2 <> 0 Then
                    'MsgBox("Amount bellow " & ComputerRights.SaAmtForDisc & "/-. discount not allowed.")
                    ' txtDis.Text = "0.00"
                    DISCHK2 = False
                End If
                If Val(txtDis.Text) > LoginRights.SaDiscLmt2 And LoginRights.SaDiscLmt2 <> 0 Then
                    ' MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                    'txtDis.Text = "0.00"
                    DISCHK2 = False
                End If
            End If

        End If

        If Val(lblNamt.Text) >= LoginRights.SaDiscLmt2 Then
            If cbType.SelectedValue <> "24" Then
                If Val(txtDis.Text) > ComputerRights.SaDiscLmt2 And ComputerRights.SaDiscLmt2 <> 0 Then
                    '  MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                    'txtDis.Text = "0.00"
                    DISCHK2 = False
                End If

                If Val(lblNamt.Text) <= LoginRights.SaAmtForDisc2 And Val(txtDis.Text) <> 0 And LoginRights.SaAmtForDisc2 <> 0 Then
                    'MsgBox("Amount bellow " & LoginRights.SaAmtForDisc & "/-. discount not allowed.")
                    ' txtDis.Text = "0.00"
                    DISCHK2 = False
                End If

            End If
        End If

        If DISCHK1 = False Then
            MsgBox("Discount not allowed for this amount.")
            txtDis.Text = "0.00"
            Exit Sub
        Else

            'If DISCHK2 = False Then
            '    MsgBox("Discount not allowed for this amount.")
            '    txtDis.Text = "0.00"
            '    Exit Sub
            'End If

        End If

        '-----------------



        If cbType.SelectedValue <> "24" Then
            If Val(txtAdd.Text) > ComputerRights.SaAddLmt And ComputerRights.SaAddLmt <> 0 Then
                MsgBox("Other addition amount above " & ComputerRights.SaAddLmt & " not allowed.")
                Exit Sub
            End If
            If Val(txtAdd.Text) > LoginRights.SaAddLmt And LoginRights.SaAddLmt <> 0 Then
                MsgBox("Other addition amount above " & ComputerRights.SaAddLmt & " not allowed.")
                Exit Sub
            End If
        End If


        If cbType.SelectedValue <> "24" Then
            If Abs(Val(txtDed.Text)) > ComputerRights.SaLessLmt And ComputerRights.SaLessLmt <> 0 Then
                MsgBox("Other deduction amount above " & ComputerRights.SaLessLmt & " not allowed.")
                Exit Sub
            End If
            If Abs(Val(txtDed.Text)) > LoginRights.SaLessLmt And LoginRights.SaLessLmt <> 0 Then
                MsgBox("Other deduction amount above " & ComputerRights.SaLessLmt & " not allowed.")
                Exit Sub
            End If
        End If



        If cbType.SelectedValue = "22" Or cbType.SelectedValue = "27" Then
            If cbCus.SelectedValue = 0 Then
                MsgBox("Select an Account Name...", vbInformation)
                cbCus.Focus()
                Exit Sub
            End If

            If Val(lblNamt.Text) <> (Val(txtcash.Text) + Val(txtcrcard.Text) + Val(txtcoup.Text)) And (cbType.SelectedValue = "27" Or cbType.SelectedValue = "21") Then
                MsgBox("Payment details not tallying with bill amount.", vbInformation)
                txtcash.Focus()
                Exit Sub
            End If


            'Dim da As New OleDb.OleDbDataAdapter
            'Dim dt As New DataTable
            'Dim str As String
            'If cbCus.SelectedValue Is Nothing Then Exit Sub
            'cmd.Connection = Conn
            'cmd.CommandText = "select amt-pamt,billno,billdt from ledger,acmaster where acmaster.accode=ledger.accode and acmaster.cgrpcode<>2 and  ledger.accode=" & cbCus.SelectedValue & " and amt-pamt>0 "
            'da.SelectCommand = cmd
            'da.Fill(dt)
            'str = ""
            'If dt.Rows.Count > 1 Then
            '    str = "Bill pending bills " & Chr(13)

            '    For i As Long = 0 To dt.Rows.Count - 1
            '        str = str & "  " & dt.Rows(i).Item("billno") & "  Dt. " & dt.Rows(i).Item("billdt") & " Amt " & dt.Rows(i).Item(0) & Chr(13)
            '    Next
            'End If
            'If str <> "" Then
            '    MsgBox(str)
            '    Exit Sub
            'End If


            Dim str As String
            Dim crlmt, totvalue As Double

            If cbCus.SelectedValue Is Nothing Then Exit Sub

            cmd.Connection = Conn
            cmd.CommandText = "select crlmt from acmaster where  accode=" & cbCus.SelectedValue
            crlmt = Val(cmd.ExecuteScalar & "")


            If crlmt > 0 Then
                If EditFlag Then
                    cmd.CommandText = "select sum(amt) from ledger where  ledger.accode=" & cbCus.SelectedValue & "  and trntype <> 'PB' and (invcode<>'" & cbType.SelectedValue & EditNum & "' and trndate=convert(datetime,'" & EditDt & "'))"
                Else
                    cmd.CommandText = "select sum(amt) from ledger where  ledger.accode=" & cbCus.SelectedValue & "  and trntype <> 'PB' "
                End If

                totvalue = Val(cmd.ExecuteScalar & "")
                totvalue = totvalue + Val(lblNamt.Text)
                str = ""

                If totvalue > crlmt Then
                    MsgBox("Pending amount exceeds credit limit. can't save the bill.")
                    Exit Sub
                End If

            End If

        End If





        If cbType.SelectedValue = "24" And cbCus.SelectedValue = 0 Then
            MsgBox("Select a Branch..", vbInformation)
            cbCus.Focus()
            Exit Sub
        End If

        If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then

            If txtEdit.Visible Then txtEdit.Focus() : Exit Sub
            If CbEditUnit.Visible Then CbEditUnit.Focus() : Exit Sub

        End If
        If pnlPDet.Visible Then


            dgBDet.Focus()
            Exit Sub

        End If


        If cbType.SelectedValue = "22" Or cbType.SelectedValue = "21" Or cbType.SelectedValue = "27" Then

            If cbPat.Text = "" Then
                If MsgBox("Patient name is blank.. Proceed ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2) = MsgBoxResult.No Then
                    cbPat.Focus()
                    Exit Sub
                End If
            End If

            If cbDoc.Text = "" Then
                If MsgBox("Doctor name is blank.. Proceed ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2) = MsgBoxResult.No Then
                    cbDoc.Focus()
                    Exit Sub
                End If
            End If




        End If


        Try
            CreateLoyaltyCustomer()
            If Save() <> 0 Then
                If CbPrintOut.SelectedIndex <> 2 Then
                    Me.Cursor = Cursors.WaitCursor

                    If cbType.SelectedValue = "22" Or cbType.SelectedValue = "21" Or cbType.SelectedValue = "25" Or cbType.SelectedValue = "24" Or cbType.SelectedValue = "27" Then
                        cmd.Connection = Conn
                        cmd.CommandText = "select printline,preprintline,invmsg,invpreprint,BigPrintForCredit,printlinebig from settings"
                        da.SelectCommand = cmd
                        da.Fill(dt)
                        If dt.Rows(0).Item("invpreprint") Then
                            'rpt = New PrePrintDirect.PrePrintDirect
                            rpt = New PrePrintDirectClass.PrePrintDirect
                            rpt.PageLines = dt.Rows(0).Item("preprintline")
                        Else
                            rpt = New PrintDirectClass.PrintDirect
                            rpt.PageLines = dt.Rows(0).Item("printline")
                            If dt.Rows(0).Item("BigPrintForCredit") And cbType.SelectedValue = "22" Then

                                rpt = New PrintDirectBig.PrintDirectBig
                                rpt.PageLines = dt.Rows(0).Item("printlinebig")
                            End If

                            'rpt.fdata = Firm
                            'rpt.FirmGodName = Firm.GodName
                            'rpt.FirmName = Firm.Name
                            'rpt.FirmAddr1 = Firm.Addr1
                            'rpt.FirmAddr2 = Firm.Addr2
                            'rpt.FirmPhone1 = Firm.Phone1
                            'rpt.FirmPhone2 = Firm.Phone2
                            'rpt.FirmPlace = Firm.Place
                            'rpt.FirmPin = Firm.Pin
                            'rpt.FirmLicNo1 = Firm.LicNo1
                            'rpt.FirmLicNo2 = Firm.LicNo2
                            'rpt.FirmLicNo3 = Firm.LicNo3
                        End If
                        rpt.PrintMessage = dt.Rows(0).Item("invmsg") & ""
                        rpt.StartNumber = InvNum
                        rpt.EndNumber = InvNum
                        rpt.StartDate = InvDt
                        rpt.EndDate = InvDt
                        rpt.TransType = cbType.SelectedValue
                        'rpt.FirmName = Firm.Name
                        FirmValues(rpt)
                        If CbPrintOut.SelectedIndex = 1 Then
                            rpt.PrintDestination = PrintOutput.ToWindow
                        ElseIf CbPrintOut.SelectedIndex = 0 Then
                            rpt.PrintDestination = PrintOutput.ToPrinter
                        End If
                        lblB.Text = cbType.Text & " " & InvNum & " Rs. " & lblNamt.Text
                        ClearForm()
                        rpt.PrintInvoice(Conn, PrintPreview, Main, PrintPreview.TB)

                        Me.Cursor = Cursors.Default
                        Application.DoEvents()
                        If UseBarCode Then
                            dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                        Else
                            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                        End If
                        EditGrid()
                    Else
                        ClearForm()
                        Application.DoEvents()
                        If UseBarCode Then
                            dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                        Else
                            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                        End If
                        EditGrid()
                    End If
                Else
                    ClearForm()
                    Application.DoEvents()
                    If UseBarCode Then
                        dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
                    Else
                        dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                    End If
                    EditGrid()
                End If



            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function Save() As Long
        Dim cmd As New OleDb.OleDbCommand
        Dim tstk As Long
        Dim sql, sqlexdt As String
        Dim i, seq As Integer
        Dim Trn As Boolean
        Dim vqty As Long
        Try
            seq = 1
            Me.Cursor = Cursors.WaitCursor
            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn
            Trn = True

            If EditFlag Then
                If Val(cbType.SelectedValue) = EditType Then
                    InvEditChecking(EditType, EditNum, EditDt, "E")
                    InvNum = EditNum
                    InvDt = EditDt
                Else
                    InvEditChecking(EditType, EditNum, EditDt, "C")
                    cmd.CommandText = "update serialnum set slno=slno+1 where type=" & cbType.SelectedValue
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "select slno from serialnum where type=" & cbType.SelectedValue
                    InvNum = cmd.ExecuteScalar
                    InvDt = EditDt
                    cmd.CommandText = "select creditentry from serialnum where type=" & cbType.SelectedValue
                    CreditPost = cmd.ExecuteScalar
                End If
            Else
                cmd.CommandText = "update serialnum set slno=slno+1 where type=" & cbType.SelectedValue
                cmd.ExecuteNonQuery()

                cmd.CommandText = "select slno from serialnum where type=" & cbType.SelectedValue
                InvNum = cmd.ExecuteScalar
                InvDt = SysDt
                cmd.CommandText = "select creditentry from serialnum where type=" & cbType.SelectedValue
                CreditPost = cmd.ExecuteScalar
            End If
            lblno.Text = InvNum
            sql = "insert into invtotal (Invno,Invdt,type,CusCode,Name," & _
                 "BDis,BDisAmt,TFAmt,Amt1," & _
                  "Tax1,Amt2,Tax2,Amt3,Tax3,Amt4,Tax4,Amt5,Tax5,NetAmt,AddAmt," & _
                  "Flag,DedAmt,DocName,Cardno,UsrName," & _
                  "node,Cashamt,cardamt,couamt,paydet,payref,empno,esino,empname,presno,cancelled,edited,sman,workshift,mobno,pl,unacamt) Values(" & InvNum & _
                  ",'" & InvDt & "'," & Val(cbType.SelectedValue) & "," & Val(cbCus.SelectedValue) & ",""" & cbPat.Text & _
                  """," & Val(txtDis.Text) & _
                  "," & totbdis & "," & tfamt & "," & Val(rtaxary(0, 1)) & "," & Val(rptax(0, 1)) & _
                  "," & Val(rtaxary(1, 1)) & "," & Val(rptax(1, 1)) & "," & Val(rtaxary(2, 1)) & "," & Val(rptax(2, 1)) & _
                  "," & Val(rtaxary(3, 1)) & "," & Val(rptax(3, 1)) & "," & Val(rtaxary(4, 1)) & "," & Val(rptax(4, 1)) & _
                  "," & Val(lblNamt.Text) & "," & Val(txtAdd.Text) & _
                  ",''," & Val(txtDed.Text) & ",""" & _
                  cbDoc.Text & """,'" & txtccard.Text & "',""" & UsrName & """,""" & _
                  nodeName & """," & Val(txtcash.Text) & "," & _
                  Val(txtcrcard.Text) & "," & Val(txtcoup.Text) & ",""" & _
                  cmbpaydet.Text & """,""" & txtrefno.Text & """,""" & txtempno.Text & """,""" + _
                  txtesino.Text + """,""" + txtempname.Text + """,""" + txtpresno.Text + """,0," & IIf(EditFlag, 1, 0) & _
                  "," & Val(cbSal.SelectedValue & "") & "," & IIf(EditFlag, editworkshift, WorkShift) & ",""" & txtmobno.Text & """,""" & txtplace.Text & """," & unacamt & ")"

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            For i = 0 To dgInv.Rows.Count - 2

                If Not IsDate(dgInv.Item(13, i).Value) Then
                    sqlexdt = "NULL"
                Else
                    sqlexdt = "'" & dgInv.Item(13, i).Value & "'"
                End If
                'MsgBox(Val(cbSal.SelectedValue.ToString & ""))

                sql = "insert into invdetails(Invno,Invdt,Type,PrdCode,Batch,Batchid,ExDt,Pack,Qty," & _
                      "Srate,ST,cst,Unit,SValue,Seq,Sman,Bdis,Priflag," & _
                      "TaxInc,cancelled,edited,cuscode,cardno,unac) values(" & InvNum & ",'" & InvDt & "'," & Val(cbType.SelectedValue) & _
                      ",""" & dgInv.Item(1, i).Value & """,""" & dgInv.Item(12, i).Value & _
                      """," & Val(dgInv.Item(2, i).Value) & "," & sqlexdt & _
                      ",""" & dgInv.Item(11, i).Value & """," & (Val(dgInv.Item(8, i).Value) * Val(dgInv.Item(3, i).Value)) & _
                      "," & Format(Val(dgInv.Item(14, i).Value) / Val(dgInv.Item(3, i).Value), "0.0000") & ",""" & dgInv.Item(16, i).Value & _
                      """," & Val(dgInv.Item(15, i).Value & "") & "," & Val(dgInv.Item(3, i).Value) & "," & Val(dgInv.Item(22, i).Value) & _
                      "," & i & "," & Val(cbSal.SelectedValue & "") & _
                      "," & IIf(CBool(dgInv.Item(21, i).Value), 0, Val(txtDis.Text)) & ",0," & IIf(dgInv.Item(17, i).Value = "Yes", 1, 0) & ",0," & _
                      IIf(EditFlag, 1, 0) & "," & Val(cbCus.SelectedValue & "") & ",'" & txtccard.Text & "'," & IIf(CBool(dgInv.Item(20, i).Value), 1, 0) & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                vqty = Val(dgInv.Item(3, i).Value) * (Val(dgInv.Item(8, i).Value) + Val(dgInv.Item(9, i).Value) + Val(dgInv.Item(10, i).Value))
                sql = "update batch set stock = stock - " & vqty & _
                     " where stock-" & vqty & ">=0  and batchid = " & Val(dgInv.Item(2, i).Value)
                cmd.CommandText = sql
                If cmd.ExecuteNonQuery() = 0 Then
                    Throw New Exception("Insufficiant Stock for the Product : " & dgInv.Item(7, i).Value)
                End If



                'sql = "update batch set stock = stock - " & _
                '      Val(dgInv.Item(3, i).Value) * (Val(dgInv.Item(8, i).Value) + Val(dgInv.Item(9, i).Value) + Val(dgInv.Item(10, i).Value)) & _
                '      " where batchid = " & Val(dgInv.Item(2, i).Value)
                'cmd.CommandText = sql
                'cmd.ExecuteNonQuery()









                cmd.CommandText = "update product set " & _
                            "lid='" & InvDt & "'" & _
                            " where prdcode=""" + dgInv.Item(1, i).Value + """ "
                cmd.ExecuteNonQuery()


                cmd.CommandText = "select isnull(sum(stock),0) from batch where prdcode=""" + dgInv.Item(1, i).Value + _
                        """ and ((batch.exdt IS NULL) or (batch.exdt > convert(datetime,'" & SysDt & "')))"
                tstk = 0
                tstk = cmd.ExecuteScalar


                If Not EditFlag Then
                    If tstk <= (Val(dgInv.Item(8, i).Value) * Val(dgInv.Item(3, i).Value)) Then
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "Update_ShortItem"
                        cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = dgInv.Item(1, i).Value
                        cmd.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.Text
                    End If
                End If
                seq = seq + 1
            Next i
            For i = 0 To dgRtn.Rows.Count - 2   'returns

                If Not IsDate(dgRtn.Item(13, i).Value) Then
                    sqlexdt = "NULL"
                Else
                    sqlexdt = "'" & dgRtn.Item(13, i).Value & "'"
                End If
                If dgRtn.Item(1, i).Value & "" <> "" Then
                    sql = "insert into invdetails(Invno,Invdt,Type,PrdCode,Batch,Batchid,ExDt,Pack,Qty," & _
                            "Srate,ST,cst,Unit,SValue,Seq,Sman,Bdis,Priflag," & _
                            "TaxInc,BrkRtn,cancelled,edited,billrtn) values(" & InvNum & ",'" & InvDt & "'," & Val(cbType.SelectedValue) & _
                            ",""" & dgRtn.Item(1, i).Value & """,""" & dgRtn.Item(12, i).Value & _
                            """," & Val(dgRtn.Item(2, i).Value) & "," & sqlexdt & _
                            ",""" & (dgRtn.Item(11, i).Value & "") & """," & ((Val(dgRtn.Item(8, i).Value) * Val(dgRtn.Item(3, i).Value)) * -1) & _
                            "," & Format(Val(dgRtn.Item(14, i).Value) / Val(dgRtn.Item(3, i).Value), "0.0000") & ",""" & Val(dgRtn.Item(16, i).Value) & _
                            """," & dgRtn.Item(15, i).Value & "," & Val(dgRtn.Item(3, i).Value) & "," & Val(dgRtn.Item(22, i).Value) & _
                            "," & seq & "," & Val(cbSal.SelectedValue & "") & _
                            "," & IIf(dgRtn.Item(20, i).Value, 0, Val(lblrtnval.Tag)) & ",0," & IIf(dgRtn.Item(17, i).Value = "Yes", 1, 0) & _
                            "," & IIf(dgRtn.Item(21, i).Value & "" = "Yes", 1, 0) & ",0," & IIf(EditFlag, 1, 0) & ",1)"

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()



                    sql = "update batch set stock = stock + " & _
                        (Val(dgRtn.Item(3, i).Value) * Val(dgRtn.Item(8, i).Value)) & _
                        " where batchid = " & Val(dgRtn.Item(2, i).Value)
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    seq = seq + 1
                End If

            Next


            If ckbUpaid.Checked Then
                cmd.CommandText = "insert into invAccounts (type,mode,billno,Billdt,name," & _
                    "Party,Amt,adjamt) values('" & cbType.SelectedValue & "','R','" & InvNum & "','" & _
                    InvDt & "',""" + cbPat.Text + """," & Val(cbCus.SelectedValue & "") & _
                    "," & Val(lblNamt.Text) & _
                    "," & Val(txtRecv.Text) & ")"
                cmd.ExecuteNonQuery()
            End If


            If Val(cbccard.SelectedValue) <> 0 Then
                cmd.CommandText = "insert into cardsales (billno,Billdt," & _
                     "Amt,cardno,settled,type) values(""" & _
                   InvNum & """,'" & _
                    InvDt & _
                    "'," & Val(lblNamt.Text) & _
                    ",'" & cbccard.SelectedValue & "',0," & cbType.SelectedValue & ")"
                cmd.ExecuteNonQuery()
            End If


            If PostAc Then
                WriteAcc(cbType.SelectedValue, InvNum, InvDt)
            End If
            Trans.Commit()
            Trn = False
            Save = InvNum

        Catch er As Exception
            If Trn Then Trans.Rollback()
            ErrorMsg(er.Message, er.StackTrace)
            Save = 0
        End Try
        Me.Cursor = Cursors.Default
    End Function
    Private Sub WriteAcc(ByVal updtype As Long, ByVal updno As Long, ByVal upddt As Date)

        Dim vouno, coincode, cashcode, pcode, CD As Long
        Dim seq As Long
        Dim TADJ As Double
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim BillType As Long
        cmd.Connection = Conn
        cmd1.Transaction = Trans
        cmd.Transaction = Trans
        cmd1.Connection = Conn

        If EditVouno = 0 Or Not EditFlag Then
            cmd.CommandText = "update serialnum  set slno=slno+1 where type=93"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "select slno from serialnum where type=93"
            vouno = cmd.ExecuteScalar
        Else
            vouno = EditVouno
        End If

        cmd.CommandText = "select sacacode from settings "
        cashcode = cmd.ExecuteScalar

        cmd.CommandText = "select sacoincode from settings "
        coincode = cmd.ExecuteScalar

        If CreditPost Or updtype = "22" Or updtype = "27" Then

            'If updtype = "27" Then
            'cmd.CommandText = "Select accode from tax where flag='50' " & _
            '    " and  seq=1"
            'pcode = Val(cmd.ExecuteScalar & "")
            'BillType = 2
            'Else
            BillType = 2
            pcode = Val(cbCus.SelectedValue)
            'End If

        Else
            BillType = 1
            pcode = cashcode
        End If

        Dim AMT_1, AMT_2, AMT_3 As Double

        Dim PCODE_1, PCODE_2, PCODE_3 As Double

        AMT_1 = 0
        AMT_2 = 0
        AMT_3 = 0

        Select Case updtype
            Case "27"
                AMT_1 = Val(txtcrcard.Text)
                PCODE_1 = Val(cbCus.SelectedValue & "")

                AMT_2 = Val(txtcash.Text)
                PCODE_2 = cashcode

                AMT_3 = Val(txtcoup.Text)
                cmd.CommandText = "Select accode from tax where flag='51' and  seq=1"
                PCODE_3 = Val(cmd.ExecuteScalar & "")

            Case "21"
                AMT_1 = Val(txtcash.Text) - unacamt
                PCODE_1 = cashcode

                If Val(txtcoup.Text) <> 0 Then
                    AMT_3 = Val(txtcoup.Text)
                    cmd.CommandText = "Select accode from tax where flag='51' and  seq=1"
                    PCODE_3 = Val(cmd.ExecuteScalar & "")
                    AMT_1 = AMT_1 - AMT_3
                End If
            Case "22"

                AMT_1 = Val(lblNamt.Text)
                PCODE_1 = Val(cbCus.SelectedValue)
                If Val(txtcoup.Text) <> 0 Then
                    AMT_3 = Val(txtcoup.Text)
                    AMT_1 = AMT_1 - AMT_3
                    cmd.CommandText = "Select accode from tax where flag='51' and  seq=1"
                    PCODE_3 = Val(cmd.ExecuteScalar & "")
                End If

            Case Else
                AMT_1 = Val(lblNamt.Text)
                PCODE_1 = pcode
                AMT_2 = 0
                AMT_3 = 0
        End Select

        seq = 1
        If EditFlag Then
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                    "Amt,BillType,BillNo,Seq,InvCode,pamt) values('" & _
                    upddt & "','Sv'," & vouno & "," & _
                    PCODE_1 & ", " & AMT_1 & "," & BillType & ",""" & _
                     updno & """," & _
                    "1,'" & updtype & updno & "',  COALESCE((select sum(amt) from adjdetails where " & _
                        " billtrntype='Sv' and  billvouno=" & vouno & " and billtrndt=convert(datetime,'" & upddt & "'  )),0))"
            cmd.ExecuteNonQuery()
            seq = seq + 1

            If AMT_2 <> 0 Then
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                   "Amt,BillType,BillNo,Seq,InvCode,pamt) values('" & _
                   upddt & "','Sv'," & vouno & "," & _
                   PCODE_2 & ", " & AMT_2 & "," & BillType & ",""" & _
                    updno & """," & _
                   seq & ",'" & updtype & updno & "',  COALESCE((select sum(amt) from adjdetails where " & _
                       " billtrntype='Sv' and  billvouno=" & vouno & " and billtrndt=convert(datetime,'" & upddt & "'  )),0))"
                cmd.ExecuteNonQuery()
                seq = seq + 1

            End If


            If AMT_3 <> 0 Then
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                   "Amt,BillType,BillNo,Seq,InvCode,pamt) values('" & _
                   upddt & "','Sv'," & vouno & "," & _
                   PCODE_3 & ", " & AMT_3 & "," & BillType & ",""" & _
                    updno & """," & _
                   seq & ",'" & updtype & updno & "',  COALESCE((select sum(amt) from adjdetails where " & _
                       " billtrntype='Sv' and  billvouno=" & vouno & " and billtrndt=convert(datetime,'" & upddt & "'  )),0))"
                cmd.ExecuteNonQuery()
                seq = seq + 1
            End If

        Else
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                "Amt,BillType,BillNo,Seq,InvCode ) values('" & _
                upddt & "','Sv'," & vouno & "," & _
                PCODE_1 & ", " & AMT_1 & "," & BillType & ",""" & _
                 updno & """," & _
                "1,'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()
            seq = seq + 1

            If AMT_2 <> 0 Then
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                   "Amt,BillType,BillNo,Seq,InvCode ) values('" & _
                   upddt & "','Sv'," & vouno & "," & _
                   PCODE_2 & ", " & AMT_2 & "," & BillType & ",""" & _
                    updno & """," & _
                   "1,'" & updtype & updno & "')"

                seq = seq + 1
            End If

            If AMT_3 <> 0 Then
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                   "Amt,BillType,BillNo,Seq,InvCode ) values('" & _
                   upddt & "','Sv'," & vouno & "," & _
                   PCODE_3 & ", " & AMT_3 & "," & BillType & ",""" & _
                    updno & """," & _
                    seq & ",'" & updtype & updno & "')"
                seq = seq + 1
            End If

        End If







        For i = 1 To 5
            If rtaxary(i - 1, 1) <> 0 Then
                'writting taxable
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='1' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar

                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                      "AcCode,  Amt,BillType,BillNo,Seq,InvCode) " & _
                      "values('" & upddt & "','Sv'," & _
                      vouno & "," & CD & "," & _
                      Val(Format((rtaxary(i - 1, 1) * -1), "0.00")) & "," & BillType & "," & _
                      updno & "," & seq & ",'" & updtype & updno & "')"
                cmd.ExecuteNonQuery()

                'writing tax
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='2' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar

                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                   "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                   "values('" & upddt & "','Sv'," & _
                   vouno & "," & CD & ", " & _
                   Val(Format((rptax(i - 1, 1) * -1), "0.00")) & "," & BillType & "," & _
                   updno & "," & seq & ",'" & updtype & updno & "')"
                cmd.ExecuteNonQuery()

            End If
        Next i

        If tfamt <> 0 Then
            seq = seq + 1
            cmd.CommandText = "Select accode from tax where flag='4' " & _
                    " and  seq=1"
            CD = cmd.ExecuteScalar
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                "values('" & upddt & "','Sv'," & _
                vouno & "," & CD & "," & _
                (tfamt * -1) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"

            cmd.ExecuteNonQuery()
        End If
        TADJ = (Val(txtDed.Text) - Val(txtAdd.Text))
        If TADJ <> 0 Then
            seq = seq + 1
            cmd.CommandText = "Select accode from tax where flag='6' " & _
                    " and  seq=1"

            CD = cmd.ExecuteScalar

            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                "values('" & upddt & "','Sv'," & _
                vouno & "," & CD & "," & _
                (TADJ) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()

        End If
    End Sub



    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        Try
            'If EditFlag Then
            '    MsgBox("Can't edit  the sales while Editing.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If



            If dgInv.RowCount > 1 Then
                MsgBox("Entries found. Clear the entries before editing.", vbInformation)
                Exit Sub
            End If
            EditSales.txtSalNo.Text = Val(lblno.Text) - 1
            EditSales.txtSalNo.Focus()
            EditSales.Text = "Bill Editing (" & cbType.Text & ")"
            EditSales.ShowDialog()

            If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            cmd.Connection = Conn

            cmd.CommandText = "select InvDetails.* from InvDetails where InvDetails.InvNo=" & Val(EditSales.txtSalNo.Text) & _
                    " and InvDetails.Invdt>=convert(datetime,'" & EditSales.dtpf.Value.Date & "') and " & _
                    "InvDetails.Invdt<=convert(datetime,'" & EditSales.dtpt.Value.Date & "') and  " & _
                    " InvDetails.type='" & cbType.SelectedValue & "'  order by seq"

            da.SelectCommand = cmd
            da.Fill(dt)


            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("cancelled") Then
                    MsgBox("Bill already cancelled.", MsgBoxStyle.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                MsgBox("Sales bill not found.", MsgBoxStyle.Information)
                Me.Cursor = Cursors.Default

                Exit Sub
            End If


            EditingSales(EditSales.txtSalNo.Text, EditSales.dtpf.Value.Date, EditSales.dtpt.Value.Date)
            EditSales.Dispose()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EditingSales(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim da As New OleDb.OleDbDataAdapter

            Dim dtab As New DataTable
            Dim DS As New DataSet
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            Dim tmpcode As String
            Dim i As Integer

            EditFlag = True
            i = 0
            slno = 0
            tmpcode = ""

            Sales.Rows.Clear()
            Sales.Rows.Add()
            EditNum = 0
            EditType = 0
            EditDt = Nothing
            EditVouno = 0

            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName,Product.nodisc from invtotal," & _
                     "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                     "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                     "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                     " and InvDetails.Invdt>=convert(datetime,'" & dtf & "') and  " & _
                     " InvDetails.Invdt<=convert(datetime,'" & dtt & "') and  " & _
                     " invtotal.type='" & cbType.SelectedValue & "' order by InvDetails.invdt,seq"

            da.SelectCommand = cmd
            da.Fill(dtab)

            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName,isnull(Product.nodisc,0) as nodisc from invtotal," & _
                     "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                     "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                     "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                     " and InvDetails.Invdt>=convert(datetime,'" & dtab.Rows(0).Item("invdt") & "') and  " & _
                     " InvDetails.Invdt<=convert(datetime,'" & dtab.Rows(0).Item("invdt") & "') and  " & _
                     " invtotal.type='" & cbType.SelectedValue & "' order by InvDetails.invdt,seq"
            dtab.Clear()
            dtab.Rows.Clear()

            da.Fill(dtab)

            If dtab.Rows.Count <> 0 Then

                For i = 0 To dtab.Rows.Count - 1
                    If slno = 0 Then

                        lblno.Text = dtab.Rows(i).Item("InvNo")
                        cbPat.Text = dtab.Rows(i).Item("Name")
                        lblNamt.Text = dtab.Rows(i).Item("NetAmt")
                        lblTamt.Text = dtab.Rows(i).Item("TfAmt")
                        txtDis.Text = dtab.Rows(i).Item("BDis")
                        txtDed.Text = dtab.Rows(i).Item("DedAmt")
                        txtAdd.Text = dtab.Rows(i).Item("AddAmt")
                        cbSal.Text = dtab.Rows(i).Item("Sman")
                        cbDoc.Text = dtab.Rows(i).Item("Docname")
                        cbType.SelectedValue = dtab.Rows(i).Item("Type")
                        EditNum = dtab.Rows(i).Item("INVNO")
                        EditType = dtab.Rows(i).Item("TYPE")
                        EditDt = dtab.Rows(i).Item("Invdt")
                        txtcash.Text = dtab.Rows(i).Item("cashamt")
                        txtcrcard.Text = Val(dtab.Rows(i).Item("cardamt") & "")
                        txtcoup.Text = Val(dtab.Rows(i).Item("couamt") & "")
                        txtccard.Text = dtab.Rows(i).Item("Cardno")
                        cbccard.Text = dtab.Rows(i).Item("paydet") & ""
                        txtrefno.Text = dtab.Rows(i).Item("payref") & ""
                        cbCus.SelectedValue = Val(dtab.Rows(i).Item("cuscode") & "")
                        lbldt.Text = EditDt
                        txtmobno.Text = dtab.Rows(i).Item("mobno") & ""
                        txtplace.Text = (dtab.Rows(i).Item("pl") & "")
                        editworkshift = dtab.Rows(i).Item("workshift")
                        If Not UseSalesmanPass Then
                            cbSal.SelectedValue = Val(dtab.Rows(i).Item("SMAN") & "")
                        End If
                        FindCardDetails()
                    End If

                    If dtab.Rows(i).Item("Qty") < 0 Then
                        dgRtn.Rows.Add()
                        dgRtn.Item(1, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("prdcode")
                        dgRtn.Item(2, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("batchid")
                        dgRtn.Item(3, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("Unit")
                        dgRtn.Item(7, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdName")
                        dgRtn.Item(8, dgRtn.Rows.Count - 1).Value = Round(Abs(dtab.Rows(i).Item("Qty")) / dtab.Rows(i).Item("unit"), 2, MidpointRounding.AwayFromZero)
                        dgRtn.Item(9, dgRtn.Rows.Count - 1).Value = 0
                        dgRtn.Item(10, dgRtn.Rows.Count - 1).Value = 0
                        dgRtn.Item(11, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("Pack") & ""
                        dgRtn.Item(12, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("batch") & ""
                        dgRtn.Item(13, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("ExDt")
                        dgRtn.Item(14, dgRtn.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("srate") * dtab.Rows(i).Item("unit"), 4, MidpointRounding.AwayFromZero)
                        dgRtn.Item(15, dgRtn.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("cst"), 2)
                        dgRtn.Item(16, dgRtn.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("st"), 2)
                        dgRtn.Item(20, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("nodisc")
                        'dgRtn.Item(20, dgRtn.Rows.Count - 1).Value = dtab.Rows(i).Item("nodisc")
                        If (dtab.Rows(i).Item("TaxInc")) = 0 Then
                            dgRtn.Item(17, dgRtn.Rows.Count - 1).Value = "No"
                        Else
                            dgRtn.Item(17, dgRtn.Rows.Count - 1).Value = "Yes"
                        End If
                        lblrtnval.Tag = dtab.Rows(i).Item("BDis")

                    Else

                        If dgInv.Rows.Count > 1 Then
                            If dgInv.Item(1, dgInv.Rows.Count - 2).Value & "" = dtab.Rows(i).Item("PrdCode") Then
                                dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                                dgInv.Item(0, dgInv.Rows.Count - 2).Value = slno & "*"
                            Else
                                slno = slno + 1
                                dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno
                            End If

                        Else
                            slno = slno + 1
                            dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno
                        End If
                        dgInv.Item(1, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("prdcode")
                        dgInv.Item(2, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("batchid")
                        dgInv.Item(3, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("Unit")
                        dgInv.Item(7, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdName")
                        dgInv.Item(8, dgInv.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("Qty") / dtab.Rows(i).Item("unit"), 2, MidpointRounding.AwayFromZero)
                        dgInv.Item(9, dgInv.Rows.Count - 1).Value = 0
                        dgInv.Item(10, dgInv.Rows.Count - 1).Value = 0
                        dgInv.Item(11, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("Pack") & ""
                        dgInv.Item(12, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("batch") & ""
                        dgInv.Item(13, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("ExDt")
                        dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("srate") * dtab.Rows(i).Item("unit"), 4, MidpointRounding.AwayFromZero)
                        dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("cst"), 2)
                        dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dtab.Rows(i).Item("st"), 2)
                        dgInv.Item(21, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("nodisc")
                        dgInv.Item(20, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("UNAC")
                        If (dtab.Rows(i).Item("TaxInc")) = 0 Then
                            dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                        Else
                            dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                        End If

                        WriteOutGo(dtab.Rows(i).Item("batchid"), Round(dtab.Rows(i).Item("Qty"), 2, MidpointRounding.AwayFromZero), dgInv.Rows.Count - 1)

                        dgInv.Update()
                        Sales.Rows.Add()

                    End If


                Next
            Else
                MsgBox("Sales bill not found.", MsgBoxStyle.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            dgRtn.Rows.Add()

            Dim dt As New DataTable

            cmd.CommandText = "select amt,adjamt from Invaccounts where mode = 'R' and type ='" & EditType & _
                            "' and billno='" & EditNum & "' and BillDt=convert(datetime,'" & EditDt & "')"

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ckbUpaid.Checked = True
                txtRecv.Text = Format(dt.Rows(0).Item("adjamt"), "0.00")
            End If


            cmd.CommandText = "select  pamt,vouno from ledger where  trntype='Sv' and " & _
                "trndate=convert(datetime,'" & EditDt & "') and " & _
                "InvCode='" & EditType & EditNum & "' and  seq=1"

            dtab.Clear()
            da.SelectCommand = cmd
            da.Fill(dtab)
            If dtab.Rows.Count > 0 Then
                EditVouno = dtab.Rows(0).Item("vouno")

                If Val(dtab.Rows(0).Item("pamt") & "") <> 0 Then
                    cbCus.Enabled = False
                    cbType.Enabled = False
                Else
                    cbCus.Enabled = True
                    cbType.Enabled = True
                End If
            End If

            tsbSave.Enabled = True
            EditFlag = True
            dgInv.Enabled = True

            dgInv.Enabled = True
            txtEdit.Visible = False
            Calculate()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
            ClearForm()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            End If
            EditGrid()
        End If

    End Sub

    Private Sub cbSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbSal.KeyDown
        If e.KeyCode = Keys.Enter Then
            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            End If
            EditGrid()
        End If
    End Sub

    Private Sub cbPat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbPat.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cbType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbType.KeyPress

    End Sub

    Private Sub cbType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbType.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbCus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbCus.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub ClearRow()
        Try
            dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(11, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(12, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(13, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(15, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(16, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(17, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Item(22, dgInv.CurrentCell.RowIndex).Value = Nothing
            dgInv.Focus()
            pnlPDet.Visible = False
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgBDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgBDet.KeyDown
        Try
            If Asc(e.KeyCode) = 27 Then
                dgInv.Enabled = True
                If dgInv.CurrentRow.Index = dgInv.RowCount - 1 Then
                    dgInv.CurrentCell = dgInv.Item(11, dgInv.CurrentCell.RowIndex)

                    ClearRow()

                Else
                    pnlPDet.Visible = False
                    dgInv.Enabled = True
                    dgInv.Focus()

                End If
                e.Handled = True
            ElseIf e.KeyValue = 13 Then
                If dgInv.CurrentCell.ColumnIndex <> 12 Then

                    If txtEdit.Visible Then
                        txtEdit.Focus()
                    ElseIf CbEditUnit.Visible Then
                        CbEditUnit.Focus()

                    End If
                    Exit Sub
                End If

                dgInv.Enabled = True
                AdjQty()
                Calculate()
                tsbSave.Enabled = True
                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub WriteOutGo(ByVal batchid As Long, ByVal qty As Double, ByVal rseq As Long, Optional ByVal Upd As Boolean = False)
        Dim cmd As New OleDb.OleDbCommand
        Try
            cmd.Connection = Conn
            If batchid = -1 Then 'insert row
                cmd.CommandText = "update outgo set rseq=rseq+1 where id=" & outgoid & " and rseq>=" & rseq
            ElseIf batchid = -2 Then 'delete row
                cmd.CommandText = "update outgo set rseq=rseq-1 where id=" & outgoid & " and rseq>=" & rseq
            ElseIf batchid = -3 Then 'clear 
                cmd.CommandText = "delete from outgo where id=" & outgoid & " and rseq=" & rseq
            ElseIf batchid = -4 Then 'clear 
                cmd.CommandText = "delete from outgo where id=" & outgoid & " and rseq=" & rseq
                cmd.ExecuteNonQuery()
                cmd.CommandText = "update outgo set rseq=rseq-1 where id=" & outgoid & " and rseq>" & rseq
            ElseIf batchid = -5 Then 'clear 
                'cmd.CommandText = "delete from outgo where id=" & outgoid & " and rseq=" & rseq
                cmd.CommandText = "update outgo set rseq=rseq+1 where id=" & outgoid & " and rseq>" & rseq

            Else
                If Upd Then
                    cmd.CommandText = "update outgo set qty=" & qty & ",tqty=" & qty & " where id=" & outgoid & " and rseq=" & rseq

                Else
                    cmd.CommandText = "insert into outgo (id,batchid,qty,tqty,nodename,rseq,dt) values(" & outgoid & "," & _
                          batchid & "," & qty & "," & qty & ",""" + nodeName + """," & rseq & ",'" & SysDt & "')"
                End If
            End If
            cmd.ExecuteNonQuery()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtccard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtccard.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtccard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtccard.TextChanged
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

    Private Sub cbccard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbccard.KeyDown
        If e.KeyCode = Keys.Enter Then dgInv.Focus()
    End Sub

    Private Sub cbccard_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbccard.SelectedIndexChanged
        txtccard.Tag = "Y"
        txtccard.Text = cbccard.SelectedValue
        txtccard.Tag = ""
        Dim command As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        command.Connection = Conn
        command.CommandType = CommandType.Text
        command.CommandText = "select prescname from PrescriptionEntry where cardno=" & Val(txtccard.Text) & " group by  prescname"

        da.SelectCommand = command
        da.Fill(ds, "pres")

        cbpresc.DisplayMember = "prescname"
        cbpresc.DataSource = ds.Tables("pres")
        cbpresc.Text = ""
        'cbpresc.SelectedValue = ""
    End Sub

    Private Sub InvEditChecking(ByVal updtype As Long, ByVal updno As Long, ByVal upddt As Date, ByVal updflag As String)

        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim edtd As Integer
        Dim vflg As Boolean = False

        cmd.Connection = Conn
        cmd1.Transaction = Trans
        cmd.Transaction = Trans
        cmd1.Connection = Conn

        cmd.CommandText = "select InvDetails.* from InvDetails where InvDetails.InvNo=" & updno & _
                 " and InvDetails.Invdt=convert(datetime,'" & upddt & "') and  " & _
                 " InvDetails.type='" & updtype & "'  order by seq"
        da.SelectCommand = cmd
        da.Fill(dt)
        edtd = 0

        If dt.Rows.Count <> 0 Then
            For i = 0 To dt.Rows.Count - 1

                If vflg = False Then  'if cardsales

                    If Val(dt.Rows(i).Item("cardno") & "") <> 0 Then
                        cmd1.CommandText = "delete cardsales where billno='" & updno & "' and type='" & _
                            EditType & "' and billdt=convert(datetime,'" & upddt & "')"

                        cmd1.ExecuteNonQuery()
                    End If
                    vflg = True

                End If

                edtd = dt.Rows(i).Item("edited")
                cmd1.CommandText = "update batch set stock=stock+" & dt.Rows(i).Item("Qty") & _
                    " where batchid=" & dt.Rows(i).Item("batchid")
                cmd1.ExecuteNonQuery()
            Next
        Else


        End If

        If updflag = "E" Then
            If edtd = 0 Then
                cmd1.CommandText = "update InvDetails set type='E" & updtype & "' where InvDetails.InvNo=" & updno & _
                   " and InvDetails.Invdt=convert(datetime,'" & upddt & "') and  " & _
                    " InvDetails.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()
                cmd1.CommandText = "update invtotal set type='E" & updtype & "' where invtotal.InvNo=" & updno & _
                      " and invtotal.Invdt=convert(datetime,'" & upddt & "') and  " & _
                       " invtotal.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()
            Else
                cmd1.CommandText = "delete InvDetails where InvDetails.InvNo=" & updno & _
                  " and InvDetails.Invdt=convert(datetime,'" & upddt & "') and  " & _
                   " InvDetails.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()
                cmd1.CommandText = "delete invtotal  where invtotal.InvNo=" & updno & _
                      " and invtotal.Invdt=convert(datetime,'" & upddt & "') and  " & _
                       " invtotal.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()

            End If

        ElseIf updflag = "C" Then
            cmd1.CommandText = "update InvDetails set cancelled=1 where InvDetails.InvNo=" & updno & _
                   " and InvDetails.Invdt=convert(datetime,'" & upddt & "') and  " & _
                   " InvDetails.type='" & updtype & "'"
            cmd1.ExecuteNonQuery()

            cmd1.CommandText = "update invtotal set cancelled=1,netamt=0,amt1=0,amt2=0,amt3=0,amt4=0,amt5=0," & _
                    "tax1=0,tax2=0,tax3=0,tax4=0,tax5=0,addamt=0,dedamt=0,UsrNameCancelled=""" + UsrName + _
                    """,nodeCancelled=""" + nodeName + """,invtimecancelled=getdate()  where invtotal.InvNo=" & updno & _
                   " and invtotal.Invdt=convert(datetime,'" & upddt & "') and  " & _
                    " invtotal.type='" & updtype & "'"


            cmd1.ExecuteNonQuery()
        End If
        ' dataredr.Close()



        cmd1.CommandText = "delete   Invaccounts where mode = 'R' and type ='" & EditType & _
                             "' and billno='" & updno & "' and BillDt=convert(datetime,'" & upddt & "')"
        cmd1.ExecuteNonQuery()



        cmd.CommandText = "select vouno from ledger where  trntype='Sv' and " & _
            "trndate=convert(datetime,'" & upddt & "') and " & _
            "InvCode='" & updtype & updno & "' and  seq=1"

        da.SelectCommand = cmd
        da.Fill(dt1)


        If dt1.Rows.Count > 0 Then
            EditVouno = dt1.Rows(0).Item("vouno")
            cmd1.CommandText = "delete from ledger where vouno=" & dt1.Rows(0).Item("vouno") & _
                " and trntype='Sv' and trndate=convert(datetime,'" & upddt & "') "
            cmd1.ExecuteNonQuery()


            ''cmd1.CommandText = "delete from adjdetails where (vouno=" & dataredr("vouno") & _
            '     " and trntype='Sv' and trndate=convert(datetime,'" & upddt & "')) or " & _
            '     " (billtrntype='Sv' and billVouno=" & dataredr("vouno") & _
            '     " and  billtrndt=convert(datetime,'" & upddt & "')) "
            ''cmd1.ExecuteNonQuery()

        End If

    End Sub

    Private Sub ckbUpaid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbUpaid.CheckedChanged
        'txtRecv.Enabled = ckbUpaid.Checked
        'txtRecv.Focus()
    End Sub

    Private Sub tsbBCalcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBCalcel.Click
        Dim trn As Boolean
        Try

            If CheckUserLocked("Cancel Bill", False) = False Then Exit Sub

            If EditFlag Then
                MsgBox("Can't Cancel the bill while Editing.", MsgBoxStyle.Information)
                Exit Sub
            End If

            EditSales.txtSalNo.Focus()
            EditSales.Text = "Bill Cancellation (" & cbType.Text & ")"
            EditSales.ShowDialog()

            If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If Val(EditSales.txtSalNo.Text) = 0 Then
                Exit Sub
            End If

            Dim cmd As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim indt As DateTime
            cmd.Connection = Conn
            cmd.CommandText = "select InvDetails.* from InvDetails where InvDetails.InvNo=" & EditSales.txtSalNo.Text & _
                " and InvDetails.Invdt>=convert(datetime,'" & EditSales.dtpf.Value.Date & "')   " & _
                "and InvDetails.Invdt<=convert(datetime,'" & EditSales.dtpt.Value.Date & "') and  " & _
                " InvDetails.type='" & cbType.SelectedValue & "'  order by INVDT DESC,seq"
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("cancelled") Then
                    MsgBox("Bill already cancelled.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                indt = dt.Rows(0).Item("invdt")

                Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
                cmd.Transaction = Trans
                cmd.Connection = Conn

                trn = True

                InvEditChecking(cbType.SelectedValue, EditSales.txtSalNo.Text, indt, "C")

                Trans.Commit()
                trn = False
                MsgBox("Bill No: " & EditSales.txtSalNo.Text & " dated: " & indt & Chr(13) & " is sucessfully cancelled.", MsgBoxStyle.Information)

                Exit Sub
            Else
                MsgBox("Bill not found..", MsgBoxStyle.Information)
            End If
        Catch er As Exception
            If trn Then Trans.Rollback()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click


        If CheckUserLocked("Allow Bill Copy", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub

        BillCopy.txtNof.Focus()


        BillCopy.Text = "Bill Copy "
        BillCopy.loadform()
        BillCopy.btnPrint.Visible = True
        BillCopy.BtnFile.Visible = True
        BillCopy.cbType.SelectedValue = cbType.SelectedValue
        BillCopy.ShowDialog()


        Select Case BillCopy.DialogResult
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
            Case Windows.Forms.DialogResult.Yes

            Case Windows.Forms.DialogResult.No

            Case Windows.Forms.DialogResult.OK

        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim rt As Object
        cmd.Connection = Conn

        cmd.CommandText = "select printline,preprintline,invmsg,BigPrintForCredit,printlinebig from settings"
        da.SelectCommand = cmd
        da.Fill(dt)

        If BillCopy.ChkPrePrint.Checked Then
            'rt = New PrePrintDirect.PrePrintDirect
            rt = New PrePrintDirect
            rt.PageLines = dt.Rows(0).Item("preprintline")
        Else
            rt = New PrintDirectClass.PrintDirect
            rt.PageLines = dt.Rows(0).Item("printline")
            If dt.Rows(0).Item("BigPrintForCredit") And BillCopy.cbType.SelectedValue = "22" Then

                rt = New PrintDirectBig.PrintDirectBig
                rt.PageLines = dt.Rows(0).Item("printlinebig")

            End If
        End If


        rt.PrintMessage = dt.Rows(0).Item("invmsg") & " "
        rt.StartNumber = Val(BillCopy.txtNof.Text)
        rt.EndNumber = Val(BillCopy.txtNot.Text)
        rt.StartDate = BillCopy.dtpf.Value.Date
        rt.EndDate = BillCopy.dtpt.Value.Date
        rt.TransType = BillCopy.cbType.SelectedValue
        FirmValues(rt)

        Select Case BillCopy.DialogResult
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
            Case Windows.Forms.DialogResult.Yes
                rt.PrintDestination = PrintOutput.ToPrinter
            Case Windows.Forms.DialogResult.No
                rt.PrintDestination = PrintOutput.ToWindow
            Case Windows.Forms.DialogResult.OK
                rt.PrintDestination = rt.PrintOutput.ToFile

        End Select


        rt.PrintInvoice(Conn, PrintPreview, Main, PrintPreview.TB)

        Me.Cursor = Cursors.Default

        '        '2420829:
        '        '        echs poly clinic
        '2415748:

    End Sub

    Private Sub tsbnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbnew.Click
        Dim inv As New SalesinvHp
        inv.MdiParent = Main
        inv.Width = Main.Width
        inv.Height = Main.Height
        inv.Show()
    End Sub

    Private Sub dgInv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.SelectionChanged

        Dim i As Integer
        Dim st As Double
        Dim dic As New List(Of Integer)
        st = 0
        ' If lnknewbill.IsHandleCreated Then Exit Sub

        If dgInv.SelectedCells.Count = 0 Then
            lblseltot.Text = "Selected Value : " & Format(st, "0.00")
        End If

        dic.Clear()

        For i = 0 To dgInv.SelectedCells.Count - 1
            If Not dic.Contains(dgInv.SelectedCells(i).RowIndex) Then
                dic.Add(dgInv.SelectedCells(i).RowIndex)
            End If
        Next

        'r1 = dgInv.SelectedCells(0).RowIndex
        'r2 = dgInv.SelectedCells(dgInv.SelectedCells.Count - 1).RowIndex
        'If r1 > r2 Then
        '    r = r2
        '    r2 = r1
        '    r1 = r
        'End If

        For i = 0 To dic.Count - 1
            st = st + Val(dgInv.Item(22, dic(i)).Value & "")
        Next
        lblseltot.Text = "Selected Value : " & Format(st, "0.00")

    End Sub

    Private Sub tsbSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSave.EnabledChanged
        If dgInv.Rows.Count > 1 Then
            tsbSave.Enabled = True
        End If
    End Sub

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick
        'MsgBox(DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & "  - " & DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value & " - " & DgProdSer.Item(2, DgProdSer.CurrentCell.RowIndex).Value)
    End Sub

    Private Sub cbPat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbPat.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub cbDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbDoc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtempno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtempno.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtesino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtesino.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtempname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtempname.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtempname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempname.TextChanged

    End Sub

    Private Sub txtpresno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpresno.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        BillReturn.ClearForm()


        For i As Integer = 0 To dgRtn.Rows.Count - 2
            For n As Integer = 0 To dgRtn.Columns.Count - 1
                BillReturn.dgInv.Item(n, BillReturn.dgInv.Rows.Count - 1).Value = dgRtn.Item(n, i).Value
            Next
            BillReturn.RtnSales.Rows.Add()
        Next
        BillReturn.txtDis.Text = lblrtnval.Tag
        BillReturn.Calculate()
        BillReturn.ShowDialog()
        ClearRtn()

        For i As Integer = 0 To BillReturn.dgInv.Rows.Count - 1
            dgRtn.Rows.Add()
            For n As Integer = 0 To BillReturn.dgInv.Columns.Count - 1
                dgRtn.Item(n, dgRtn.Rows.Count - 1).Value = BillReturn.dgInv.Item(n, i).Value
            Next
        Next
        lblrtnval.Text = BillReturn.lblNamt.Text

        lblrtnval.Tag = BillReturn.txtDis.Text
        Calculate()
    End Sub

    Private Sub ClearRtn()

        dgRtn.Columns.Clear()
        dgRtn.Columns.Add("SL", "Sl")
        dgRtn.Columns.Add("Code", "Code")
        dgRtn.Columns.Add("BatchId", "")
        dgRtn.Columns.Add("Unit", "")
        dgRtn.Columns.Add("resv1", "")
        dgRtn.Columns.Add("resv2", "")
        dgRtn.Columns.Add("resv3", "")
        dgRtn.Columns.Add("Product", "Products")
        dgRtn.Columns.Add("Qty", "Qty")
        dgRtn.Columns.Add("Free", "Free")
        dgRtn.Columns.Add("Repl", "Repl")
        dgRtn.Columns.Add("Packing", "Packing")
        dgRtn.Columns.Add("Batch", "Batch")
        dgRtn.Columns.Add("ExDt", "Expiry")
        dgRtn.Columns.Add("Rate", "Rate")
        dgRtn.Columns.Add("RT", "RT%")
        dgRtn.Columns.Add("VAT", "VAT%")
        dgRtn.Columns.Add("TaxInc", "TaxInc")
        dgRtn.Columns.Add("resv4", "")
        dgRtn.Columns.Add("resv5", "")
        dgRtn.Columns.Add("resv6", "")
        dgRtn.Columns.Add("Breakage", "Breakage")
        dgRtn.Columns.Add("Amount", "Amount")
        dgRtn.Rows.Clear()

    End Sub

    Private Sub ShowPrescription()
        If txtccard.Text & "" <> "" Then

            Dim command As New OleDb.OleDbCommand
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim i As Integer = 0
            Me.Cursor = Cursors.WaitCursor

            Try

                command.Connection = Conn
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "Select_PrescriptionName"
                command.Parameters.Add("@prescname", OleDb.OleDbType.VarChar).Value = cbpresc.Text
                command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(txtccard.Text)
                'dgpresc.Rows.Clear()

                'reader = command.ExecuteReader
                'dgpresc.Rows.Clear()
                'If reader.HasRows Then

                '    While reader.Read
                '        'txtpresc.Items.Add(reader("Prescname"))
                '        cbpresc.Text = reader("Prescname")
                '        txtname.Text = reader("name")
                '        cbpatient.Text = reader("patname") & ""
                '        cbdoctor.Text = reader("DocName") & ""
                '        dgpresc.Rows.Add()
                '        dgpresc.Item(0, i).Value = reader("medcode")
                '        dgpresc.Item(1, i).Value = reader("PrdName")
                '        dgpresc.Item(2, i).Value = reader("conseppattern")
                '        dgpresc.Item(3, i).Value = reader("qty")
                '        dgpresc.Item(4, i).Value = reader("description")
                '        i += 1
                '    End While
                'Else
                '    dgpresc.Rows.Clear()
                'End If
                'dgpresc.Rows.Add()
                'command.Parameters.Clear()
                'Panel1.Visible = False
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)
            End Try
        Else
            'dgpresc.Rows.Clear()
            'dgpresc.Rows.Add()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnpresadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpresadd.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dt1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim qt As Long

        cmd1.CommandText = "select disc from PrescriptionEntry inner join CardDetails on PrescriptionEntry.cardno=CardDetails.cardno where PrescriptionEntry.cardno=" & Val(txtccard.Text) & " and PrescriptionEntry.Prescname=""" & cbpresc.Text & """"
        cmd1.Connection = Conn
        txtDis.Text = Val(cmd1.ExecuteScalar & "")

        cmd1.CommandText = "select PrescriptionEntry.*,product.prdname,product.case1 from PrescriptionEntry,product where product.prdcode=PrescriptionEntry.medcode and  cardno=" & Val(txtccard.Text) & _
                " and Prescname=""" & cbpresc.Text & """"
        cmd1.Connection = Conn
        da.SelectCommand = cmd1
        da.Fill(dt1)

        txtEdit.Visible = False
        CbEditTaxInc.Visible = False
        cbEditVat.Visible = False
        CbEditUnit.Visible = False
        For x = 0 To dt1.Rows.Count - 1

            qt = dt1.Rows(x).Item("qty")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = dt1.Rows(x).Item("medcode")
            cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = SysDt
            cmd.Parameters.Add("@edit", OleDb.OleDbType.Integer).Value = 0
            cmd.Parameters.Add("@type", OleDb.OleDbType.VarChar, 2).Value = " "
            cmd.Parameters.Add("@no", OleDb.OleDbType.BigInt).Value = 0
            cmd.Parameters.Add("@ord", OleDb.OleDbType.BigInt).Value = BillOrder
            cmd.CommandText = "GetBatchinv"

            cmd.Connection = Conn
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)

            cbDoc.Text = dt1.Rows(x).Item("docname") & ""
            cbPat.Text = dt1.Rows(x).Item("patname") & ""
            For i = 0 To dt.Rows.Count - 1

                dgInv.Item(1, dgInv.Rows.Count - 1).Value = dt1.Rows(x).Item("medcode")
                dgInv.Item(2, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batchid")
                dgInv.Item(3, dgInv.Rows.Count - 1).Value = 1
                dgInv.Item(7, dgInv.Rows.Count - 1).Value = dt1.Rows(x).Item("PrdName")

                If qt <= dt.Rows(i).Item("stock") Then
                    If i > 0 Then
                        dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                    Else
                        slno = slno + 1
                        dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno
                    End If
                    dgInv.Item(8, dgInv.Rows.Count - 1).Value = qt
                    qt = 0
                Else

                    dgInv.Item(8, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("stock")
                    qt = qt - dt.Rows(i).Item("stock")
                    If i > 0 Then
                        dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                    Else
                        slno = slno + 1
                        dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                    End If
                End If

                dgInv.Item(9, dgInv.Rows.Count - 1).Value = 0
                dgInv.Item(10, dgInv.Rows.Count - 1).Value = 0
                dgInv.Item(11, dgInv.Rows.Count - 1).Value = dt1.Rows(x).Item("case1") & ""
                dgInv.Item(12, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batch") & ""
                dgInv.Item(13, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("ExDt")
                dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("srate"), 4, MidpointRounding.AwayFromZero)
                dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("scst"), 2)
                dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("vat"), 2)
                WriteOutGo(dt.Rows(i).Item("batchid"), dgInv.Item(8, dgInv.Rows.Count - 1).Value, dgInv.Rows.Count - 1)
                If (dt.Rows(i).Item("TaxInc")) = 0 Then
                    dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                Else
                    dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                End If
                dgInv.Update()
                Sales.Rows.Add()
                If qt = 0 Then Exit For
            Next

        Next

        Calculate()

        dgInv.Enabled = True
        dgInv.Focus()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New PrescriptionEntry
        If txtccard.Text = "" Then Exit Sub

        frm.MdiParent = Me.ParentForm
        frm.Width = Me.ParentForm.Width
        frm.Height = Me.ParentForm.Height
        frm.Show()
        frm.OpenForm(txtccard.Text, cbpresc.Text)
    End Sub

    Public Sub SetSlno(ByVal sl As Long)
        slno = sl
    End Sub

    Public Sub ReNumber()
        Dim i As Integer
        Dim TMPCD As String
        Dim RPID As Integer
        slno = 0
        i = 0
        Do While i <= dgInv.Rows.Count - 2
            slno = slno + 1
            TMPCD = dgInv.Item(1, i).Value
            RPID = 0
            Do While TMPCD = dgInv.Item(1, i).Value & ""
                If RPID = 0 Then
                    dgInv.Item(0, i).Value = slno
                Else

                    dgInv.Item(0, i - 1).Value = slno & "*"
                    dgInv.Item(0, i).Value = slno & "*"
                End If
                RPID = 1
                i = i + 1
            Loop
        Loop
    End Sub

    Private Sub dgInv_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgInv.MouseUp
        Dim hitTestInfo As DataGridView.HitTestInfo

        If e.Button = MouseButtons.Right Then

            hitTestInfo = dgInv.HitTest(e.X, e.Y)

            If hitTestInfo.Type = DataGridViewHitTestType.Cell Then

                If dgInv.SelectedCells.Contains(dgInv.Item(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex)) And hitTestInfo.RowIndex <> dgInv.Rows.Count - 1 Then
                    ContextMenuStrip1.Show(dgInv, New Point(e.X, e.Y))
                End If

            End If
        End If

    End Sub

    Private Sub ToNewBillToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToNewBillToolStripMenuItem1.Click
        Dim frmv As New SalesinvHp
        Dim r As Integer
        Dim I As Integer
        frmv.MdiParent = Main
        frmv.Width = Main.Width
        frmv.Height = Main.Height

        Dim dic As New List(Of Integer)

        If dgInv.Rows.Count < 2 Then Exit Sub
        If dgInv.SelectedCells.Count = 0 Then Exit Sub

        For I = 0 To dgInv.SelectedCells.Count - 1
            If Not dic.Contains(dgInv.SelectedCells(I).RowIndex) And dgInv.SelectedCells(I).RowIndex < dgInv.Rows.Count - 1 Then
                dic.Add(dgInv.SelectedCells(I).RowIndex)

            End If
        Next

        If dic.Count = 0 Then Exit Sub
        dic.Sort()
        frmv.Show()


        For r = 0 To dic.Count - 1

            For c = 0 To dgInv.ColumnCount - 1
                If c = 0 Then
                    If InStr(dgInv.Item(c, dic(r)).Value, "*") <> 0 Then
                        frmv.dgInv.Item(c, frmv.dgInv.Rows.Count - 1).Value = r + 1 & "*"
                    Else
                        frmv.dgInv.Item(c, frmv.dgInv.Rows.Count - 1).Value = r + 1
                    End If
                Else
                    frmv.dgInv.Item(c, frmv.dgInv.Rows.Count - 1).Value = dgInv.Item(c, dic(r)).Value
                End If
            Next
            frmv.dgInv.Update()
            frmv.WriteOutGo(frmv.dgInv.Item(2, frmv.dgInv.Rows.Count - 1).Value, frmv.dgInv.Item(8, frmv.dgInv.Rows.Count - 1).Value, frmv.dgInv.Rows.Count - 1)
            frmv.Sales.Rows.Add()
        Next

        For r = dic.Count - 1 To 0 Step -1
            dgInv.CurrentCell = dgInv.Item(0, dic(r))
            WriteOutGo(-4, 0, dic(r), False)
            dgInv.Rows.Remove(dgInv.Rows(dic(r)))
        Next
        Calculate()

        ReNumber()
        frmv.slno = dic.Count
        frmv.ReNumber()
        frmv.Calculate()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dtab As New DataTable
        Dim NUM As String
        Dim DT As Date
        Dim da As New OleDb.OleDbDataAdapter

        If EditFlag = False And dgInv.Rows.Count > 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn

        If EditFlag Then
            DT = EditDt
        Else
            DT = SysDt
        End If
        NUM = Val(lblno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = cbType.SelectedValue
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "-S"
        da.SelectCommand = cmd
        da.Fill(dtab)


        If dtab.Rows.Count > 0 Then

            If dtab.Rows(0).Item("cancelled") Then
                cmd.Parameters.Clear()
                NUM = Val(dtab.Rows(0).Item("invno") & "")


                GoTo che
            End If
        Else
            'GoTo che
            ' ClearForm(True)
            Me.Cursor = Cursors.Default

            Exit Sub
        End If

        NUM = (dtab.Rows(0).Item("invno") & "")
        DT = dtab.Rows(0).Item("invdt")

        ClearForm(True)
        Application.DoEvents()
        EditingSales(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dtab As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim NUM As String
        Dim DT As Date
        If EditFlag = False And dgInv.Rows.Count > 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        If EditFlag Then
            DT = EditDt
        Else
            DT = SysDt
        End If
        NUM = Val(lblno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = cbType.SelectedValue
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "+S"

        da.SelectCommand = cmd
        da.Fill(dtab)


        If dtab.Rows.Count > 0 Then
            If dtab.Rows(0).Item("cancelled") Then
                cmd.Parameters.Clear()
                NUM = Val(dtab.Rows(0).Item("invno") & "")

                GoTo che
            End If
        Else
            'ClearForm(True)

            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        NUM = (dtab.Rows(0).Item("invno") & "")
        DT = dtab.Rows(0).Item("invdt")
        ClearForm(True)
        EditingSales(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If Not EditFlag Then
            If dgInv.RowCount > 1 Then
                If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
            End If
        End If

        ClearForm()
    End Sub

    Private Sub txtsmcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsmcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn
            cmd.CommandText = "SELECT SalCode FROM SALESMAN WHERE UPPER(PASSWORD)=""" + UCase(txtsmcode.Text) & """"
            cbSal.SelectedValue = Val(cmd.ExecuteScalar & "")


            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(1, dgInv.Rows.Count - 1)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            End If
            EditGrid()
        End If
    End Sub

    Private Sub txtsmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsmcode.TextChanged
        cbSal.SelectedValue = 0
    End Sub

    Private Sub txtsmcode_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsmcode.VisibleChanged
        lblsmcode.Visible = txtsmcode.Visible
        cbSal.Enabled = (Not txtsmcode.Visible)
    End Sub

    Private Sub Button6_Click() Handles Button6.Click

        Dim i As Integer
        i = PnlInst.Width
        While i >= 60

            PnlInst.Width = PnlInst.Width - 10
            If PnlInst.Height > 50 Then
                PnlInst.Height = PnlInst.Height - 10
            End If
            Application.DoEvents()
            i = i - 10
        End While
        PnlInst.Visible = False

    End Sub

    Private Sub comoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comoth.Click

        Dim i As Integer
        i = PnlInst.Width

        PnlInst.Visible = True
        While i <= 375

            PnlInst.Width = PnlInst.Width + 10
            If PnlInst.Height < 265 Then
                PnlInst.Height = PnlInst.Height + 10
            End If

            Application.DoEvents()
            i = i + 10
            txtccard.Focus()

        End While
    End Sub

    Private Sub PnlInst_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PnlInst.Leave
        Button6_Click()
    End Sub

    Private Sub PnlInst_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles PnlInst.PreviewKeyDown
        If e.KeyCode = Keys.Escape And PnlInst.Visible Then Button6_Click()
    End Sub

    Private Sub txtcash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcash.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtcrcard_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrcard.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtcoup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoup.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRecv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecv.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRecv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecv.TextChanged
        If Val(txtRecv.Text) <> 0 Then
            lblchange.Text = "Change: " & Format(Val(txtRecv.Text) - Val(lblNamt.Text), "0.00")
        Else
            lblchange.Text = "Change: "
        End If
    End Sub

    Private Sub CreateLoyaltyCustomer()
        Dim cmdv As New OleDb.OleDbCommand
        Dim cardno As Long
        If txtmobno.Text = "" Then Exit Sub
        Dim ct As New DataTable

        cmdv.Connection = Conn

        cmdv.CommandText = "select cardno from CardDetails where phone=""" & txtmobno.Text & """"
        If Val(cmdv.ExecuteScalar & "") <> 0 Then Exit Sub

        cmdv.CommandText = "select max(cardno) from CardDetails"
        cardno = Val(cmdv.ExecuteScalar & "")
        If cardno = Nothing Then
            cardno = 1
        Else
            cardno = cardno + 1
        End If

        cmdv.CommandType = CommandType.StoredProcedure
        'If recadd = True Then

        cmdv.Parameters.Add("@cardno", OleDb.OleDbType.Integer).Value = cardno
        cmdv.Parameters.Add("@name", OleDb.OleDbType.VarChar).Value = cbPat.Text
        cmdv.Parameters.Add("@addr1", OleDb.OleDbType.VarChar).Value = ""
        cmdv.Parameters.Add("@addr2", OleDb.OleDbType.VarChar).Value = ""
        cmdv.Parameters.Add("@addr3", OleDb.OleDbType.VarChar).Value = ""
        cmdv.Parameters.Add("@place", OleDb.OleDbType.VarChar).Value = txtplace.Text
        cmdv.Parameters.Add("@phone", OleDb.OleDbType.VarChar).Value = txtmobno.Text
        cmdv.Parameters.Add("@email", OleDb.OleDbType.VarChar).Value = ""
        cmdv.Parameters.Add("@ActSMS", OleDb.OleDbType.Boolean).Value = 1
        cmdv.Parameters.Add("@ActEmail", OleDb.OleDbType.Boolean).Value = 1
        cmdv.Parameters.Add("@SMSDeclNo", OleDb.OleDbType.VarChar).Value = ""
        cmdv.Parameters.Add("@DOB", OleDb.OleDbType.Date).Value = DBNull.Value
        cmdv.Parameters.Add("@CGrpCode", OleDb.OleDbType.BigInt).Value = 0
        cmdv.CommandText = "insert_carddetails"
        cmdv.ExecuteNonQuery()
        LblCard.Text = "Card Created No. " & cardno
        Dim dap As New OleDb.OleDbDataAdapter
        cmdv.CommandType = CommandType.Text
        cmdv.CommandText = "select cardno,name from Carddetails order by name "
        dap.SelectCommand = cmdv
        dap.Fill(ct)
        cbccard.DisplayMember = "Name"
        cbccard.ValueMember = "cardno"
        cbccard.DataSource = ct
        cbccard.SelectedValue = cardno
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        histno = 0
        CustHistory.History(Val(txtccard.Text))
        CustHistory.ShowDialog()
        If histno <> 0 Then


            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand

            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            Dim qt As Long

            cmd1.CommandText = "select invdetails.*,product.prdname,product.case1,docname,name,batch.unac,product.nodisc from invdetails,batch,invtotal,product where " & _
                "batch.batchid=invdetails.batchid and invtotal.invdt=invdetails.invdt and invtotal.invno=invdetails.invno and invtotal.type=invdetails.type and  " & _
                    "product.prdcode=invdetails.prdcode and invdetails.type='" & histtype & "' and invdetails.invno=" & histno & " and  invdetails.invdt=convert(datetime,'" & histdt & "')"

            cmd.Connection = Conn
            cmd1.Connection = Conn
            da.SelectCommand = cmd1
            da.Fill(dt1)

            txtEdit.Visible = False
            CbEditTaxInc.Visible = False
            cbEditVat.Visible = False
            CbEditUnit.Visible = False
            If Not dt1.Rows.Count > 0 Then
                Exit Sub
            End If
            For v = 0 To dt1.Rows.Count - 1
                qt = dt1.Rows(v).Item("qty")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = dt1.Rows(v).Item("prdcode")
                cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = SysDt
                cmd.Parameters.Add("@edit", OleDb.OleDbType.Integer).Value = 0
                cmd.Parameters.Add("@type", OleDb.OleDbType.VarChar, 2).Value = " "
                cmd.Parameters.Add("@no", OleDb.OleDbType.BigInt).Value = 0
                cmd.Parameters.Add("@ord", OleDb.OleDbType.BigInt).Value = BillOrder
                cmd.CommandText = "GetBatchinv"

                cmd.Connection = Conn
                da.SelectCommand = cmd
                dt.Clear()
                da.Fill(dt)

                cbDoc.Text = dt1.Rows(v).Item("docname") & ""
                cbPat.Text = dt1.Rows(v).Item("name") & ""
                For i = 0 To dt.Rows.Count - 1

                    dgInv.Item(1, dgInv.Rows.Count - 1).Value = dt1.Rows(v).Item("prdcode")
                    dgInv.Item(2, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batchid")
                    dgInv.Item(3, dgInv.Rows.Count - 1).Value = 1
                    dgInv.Item(7, dgInv.Rows.Count - 1).Value = dt1.Rows(v).Item("PrdName")

                    If qt <= dt.Rows(i).Item("stock") Then
                        If i > 0 Then
                            dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                        Else
                            slno = slno + 1
                            dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno
                        End If
                        dgInv.Item(8, dgInv.Rows.Count - 1).Value = qt
                        qt = 0
                    Else

                        dgInv.Item(8, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("stock")
                        qt = qt - dt.Rows(i).Item("stock")
                        If i > 0 Then
                            dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                        Else
                            slno = slno + 1
                            dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno & "*"
                        End If
                    End If

                    dgInv.Item(9, dgInv.Rows.Count - 1).Value = 0
                    dgInv.Item(10, dgInv.Rows.Count - 1).Value = 0
                    dgInv.Item(11, dgInv.Rows.Count - 1).Value = dt1.Rows(v).Item("case1") & ""
                    dgInv.Item(12, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batch") & ""
                    dgInv.Item(13, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("ExDt")
                    dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("srate"), 4, MidpointRounding.AwayFromZero)
                    dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("scst"), 2)
                    dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("vat"), 2)
                    dgInv.Item(21, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("NODISC")
                    dgInv.Item(20, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("unac")
                    WriteOutGo(dt.Rows(i).Item("batchid"), dgInv.Item(8, dgInv.Rows.Count - 1).Value, dgInv.Rows.Count - 1)
                    If (dt.Rows(i).Item("TaxInc")) = 0 Then
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                    Else
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                    End If
                    dgInv.Update()
                    Sales.Rows.Add()
                    If qt = 0 Then Exit For
                Next
            Next
            Calculate()

            dgInv.Enabled = True
            dgInv.Focus()

        End If
    End Sub

    Private Sub txtmobno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmobno.KeyDown
        If e.KeyCode = Keys.Enter Then
            FindCardDetails()
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FindCardDetails()
        Dim cmd As New OleDb.OleDbCommand
        Dim cc As String = ""
        cmd.Connection = Conn
        cmd.CommandText = "select cardno from carddetails where phone=""" & txtmobno.Text & """"
        cc = cmd.ExecuteScalar & ""
        LblCard.Text = "Card No: " & cc
        cbccard.SelectedValue = Val(cc)

    End Sub

    Private Sub txtplace_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplace.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDis.Focus()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If CheckUserLocked("Edit Sales", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub
        EditDateShift.loadform("2")
        EditDateShift.ShowDialog()
    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        lblsch.Visible = (Not lblsch.Visible)
    End Sub

    Private Sub cbCus_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cbCus.SelectedIndexChanged
        If cbCus.SelectedItem Is Nothing Then Exit Sub
        Dim cmd As New OleDb.OleDbCommand
        Dim A As String
        cmd.Connection = Conn
        cmd.CommandText = "select disc from acmaster where accode=" & Val(cbCus.SelectedValue & "")
        A = cbCus.Text
        For I = 0 To 9
            A = Replace(A, I.ToString, "")
        Next

        txtDis.Text = Format(Val(cmd.ExecuteScalar & ""), "0.00")

        If cbType.SelectedValue = "22" Then
            cbPat.Text = Trim(A)
        End If
    End Sub

End Class

