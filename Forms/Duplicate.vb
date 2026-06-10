Imports System
Imports System.Globalization
Imports System.Math
'Imports PrePrintDirect_Class
Imports PrePrintDirectClass.PrePrintDirect
Imports PrintDirectClass
Imports PrePrintDirectClass


Public Class Duplicate
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
    Private value, totscst, Svalue, totstax, totadj, tfamt, totbdis, totsdis, totvalue, totcst As Double
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


    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.LightGreen 'RGB(192, 255, 192) 'Color.Wheat
        ToolStrip.Renderer = renderer
    End Sub


    Private Sub cbType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'cbType.SelectAll()
    End Sub


    Private Sub ClearForm()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim I As Integer
        Dim cmd As New OleDb.OleDbCommand

        Try
            'Dim i As Integer

            curunit = 0
            cmd.Connection = Conn

            cmd.CommandText = "select Docname from Doctor order by docname "
            DA.SelectCommand = cmd
            DA.Fill(DS, "Doctor")
            cbDoc.DisplayMember = "DocName"
            cbDoc.DataSource = DS.Tables("Doctor")

            cmd.CommandText = "select Patname from Patient order by Patname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Patient")
            cbPat.DisplayMember = "PatName"
            cbPat.DataSource = DS.Tables("Patient")

            cmd.CommandText = "select salcode,Salname from Salesman order by salname "
            DA.SelectCommand = cmd
            DA.Fill(DS, "Salesman")
            cbSal.DisplayMember = "SalName"
            cbSal.ValueMember = "Salcode"
            cbSal.DataSource = DS.Tables("Salesman")

            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & CustGrpcode & " order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Acmaster")
            cbCus.DisplayMember = "AcName"
            cbCus.ValueMember = "Accode"
            cbCus.DataSource = DS.Tables("Acmaster")

            cmd.CommandText = "select cardno,name  from CardDetails order by name "
            DA.SelectCommand = cmd
            DA.Fill(DS, "CCard")
            cbccard.DisplayMember = "Name"
            cbccard.ValueMember = "cardno"
            cbccard.DataSource = DS.Tables("CCard")

            'cbccard.SelectedText = ""
            cbccard.Text = ""
            cbccard.SelectedValue = 0
            'txtccard.Text = ""




            TaxTbl = New DataTable
            Sales = New DataTable
            dgInv.DataSource = Nothing
            Sales.TableName = "Sales"

            dgInv.Enabled = True
1:          Sales.Columns.Add("SL")
2:          Sales.Columns.Add("Code")
3:          Sales.Columns.Add("BatchId")
4:          Sales.Columns.Add("Unit")
5:          Sales.Columns.Add("resv1")
6:          Sales.Columns.Add("resv2")
7:          Sales.Columns.Add("resv3")
8:          Sales.Columns.Add("Product")
9:          Sales.Columns.Add("Qty")
10:         Sales.Columns.Add("Free")
11:         Sales.Columns.Add("Repl")
12:         Sales.Columns.Add("Packing")
13:         Sales.Columns.Add("Batch")
14:         Sales.Columns.Add("ExDt")
15:         Sales.Columns.Add("Rate")
16:         Sales.Columns.Add("RT")
17:         Sales.Columns.Add("VAT")
18:         Sales.Columns.Add("TaxInc")
19:         Sales.Columns.Add("resv4")
20:         Sales.Columns.Add("resv5")
21:         Sales.Columns.Add("resv6")
22:         Sales.Columns.Add("Breakage")
23:         Sales.Columns.Add("Amount")


            dgInv.Columns.Clear()
            dgInv.Columns.Add("SL", "Sl")
            dgInv.Columns.Add("Code", "Code")
            dgInv.Columns.Add("BatchId", "")
            dgInv.Columns.Add("Unit", "")
            dgInv.Columns.Add("resv1", "")
            dgInv.Columns.Add("resv2", "")
            dgInv.Columns.Add("resv3", "")
            dgInv.Columns.Add("Product", "Products")
            dgInv.Columns.Add("Qty", "Qty")
            dgInv.Columns.Add("Free", "Free")
            dgInv.Columns.Add("Repl", "Repl")
            dgInv.Columns.Add("Packing", "Packing")
            dgInv.Columns.Add("Batch", "Batch")
            dgInv.Columns.Add("ExDt", "Expiry")
            dgInv.Columns.Add("Rate", "Rate")
            dgInv.Columns.Add("RT", "RT%")
            dgInv.Columns.Add("VAT", "VAT%")
            dgInv.Columns.Add("TaxInc", "TaxInc")
            dgInv.Columns.Add("resv4", "")
            dgInv.Columns.Add("resv5", "")
            dgInv.Columns.Add("resv6", "")
            dgInv.Columns.Add("Breakage", "Breakage")
            dgInv.Columns.Add("Amount", "Amount")


            dgInv.Columns(0).DataPropertyName = "SL"
            dgInv.Columns(1).DataPropertyName = "Code"
            dgInv.Columns(2).DataPropertyName = "BatchId"
            dgInv.Columns(3).DataPropertyName = "Unit"
            dgInv.Columns(4).DataPropertyName = "resv1"
            dgInv.Columns(5).DataPropertyName = "resv2"
            dgInv.Columns(6).DataPropertyName = "resv3"
            dgInv.Columns(7).DataPropertyName = "Product"
            dgInv.Columns(7).Frozen = True
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
            dgInv.Columns(18).DataPropertyName = "resv4"
            dgInv.Columns(19).DataPropertyName = "resv5"
            dgInv.Columns(20).DataPropertyName = "resv6"
            dgInv.Columns(21).DataPropertyName = "Breakage"

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
            dgInv.Columns(21).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(22).SortMode = DataGridViewColumnSortMode.NotSortable
            dgInv.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            dgInv.Columns(0).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(1).Visible = False
            dgInv.Columns(2).Visible = False
            dgInv.Columns(3).Visible = False
            dgInv.Columns(4).Visible = False
            dgInv.Columns(5).Visible = False
            dgInv.Columns(15).Visible = False
            dgInv.Columns(21).Visible = False
            dgInv.Columns(6).Visible = False
            dgInv.Columns(7).Width = Int(dgInv.Width * 23 / 100)
            dgInv.Columns(8).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(9).Visible = False
            dgInv.Columns(10).Visible = False
            dgInv.Columns(11).Width = Int(dgInv.Width * 8 / 100)
            dgInv.Columns(12).Width = Int(dgInv.Width * 12 / 100)
            dgInv.Columns(13).Width = Int(dgInv.Width * 12 / 100)
            dgInv.Columns(14).Width = Int(dgInv.Width * 8 / 100)

            dgInv.Columns(16).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(17).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(18).Visible = False
            dgInv.Columns(19).Visible = False
            dgInv.Columns(20).Visible = False

            dgInv.Columns(21).Width = Int(dgInv.Width * 8 / 100)

            dgInv.Columns(22).Width = Int(dgInv.Width * 12 / 100)

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

            cmd.CommandText = "select taxper,accode,surch from tax where flag='1'"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                I = 0
                While dataredr.Read()
                    rtaxary(I, 0) = dataredr.Item("taxper")
                    rtaxary(I, 2) = dataredr.Item("accode")
                    I = I + 1
                End While
            End If
            dataredr.Close()

            cmd.CommandText = "select taxper,accode,surch from tax where flag='2'"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                While dataredr.Read()
                    I = 0
                    rptax(I, 0) = dataredr.Item("taxper")
                    rptax(I, 2) = dataredr.Item("accode")
                    I = I + 1
                End While
            End If
            dataredr.Close()





            cmd.CommandText = "select RndPaise from settings"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                While dataredr.Read()
                    RndPai = dataredr.Item("RndPaise")

                End While
            End If

            dataredr.Close()


            cmd.CommandText = "select slno from serialnum where type='21'"
            txtbno.Text = cmd.ExecuteScalar + 1

            txtedit.Visible = False
            CbEditUnit.Visible = False
            cbEditVat.Visible = False
            pnlPDet.Visible = False
            pnlprod.Visible = False
            tsbSave.Enabled = False
            EditFlag = False



            lblTamt.Text = "0.00"
            lblNamt.Text = "0.00"
            txtDed.Text = "0.00"
            txtAdd.Text = "0.00"
            txtDis.Text = "0.00"
            cbCus.SelectedValue = 0
            cbCus.Text = ""
            cbPat.Text = ""
            cbDoc.Text = ""
            ckbPntwin.Checked = False
            'lblCus.Visible = False
            'cbCus.Visible = False
            slno = 0

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
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

                    DgProdSer.Focus()

                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False
            obj.SelectionStart = obj.TextLength
            obj.focus()

        Catch d As Exception
            MessageBox.Show(d.Message)


        End Try
    End Sub

    Private Sub DgProdSer_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        InvDetail()
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
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub



    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            InvDetail()
        End If
    End Sub

    Private Sub InvDetail()

        Dim dataredr As OleDb.OleDbDataReader
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim tmpvar As Double

        cmd.Connection = Conn
        Try

            tsbSave.Enabled = False
            'Check for the stock if present

            cmd.CommandText = "Select batchid  from Batch Where Batch.PrdCode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """ and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "')) "
            dataredr = cmd.ExecuteReader()
            tmpvar = 0
            'If Not dataredr.HasRows Then
            '    pnlPDet.Visible = False
            '    pnlprod.Visible = False
            '    MsgBox("Batch Records not found..!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) '

            '    If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then '
            '        tsbSave.Enabled = False
            '    Else
            '        tsbSave.Enabled = True
            '    End If

            '    txtEdit.Focus()
            '    txtEdit.Text = ""
            '    Exit Sub
            'End If

            tsbSave.Enabled = False
            'Check for the stock if present

            'If tmpvar <> 0 Then
            txtedit.SelectionStart = Len(txtedit.Text)
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = (DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = (DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value)


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
            dataredr.Close()
            'dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value = dgInv.CurrentCell.RowIndex + 1
            pnlPDet.Visible = True
            'lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            txtedit.Focus()
            GetBatchDetails()
            Calculate()
            dgInv.CurrentCell = dgInv.Item(8, dgInv.CurrentCell.RowIndex)
            EDROW = dgInv.CurrentCell.RowIndex
            EDCOL = dgInv.CurrentCell.ColumnIndex
            Application.DoEvents()
            EditGrid()
            pnlprod.Visible = False
            'Else

            'tsbSave.Enabled = True
            'End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgBDet_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellEndEdit

    End Sub

    Private Sub dgBDet_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.GotFocus
        dgBDet.CurrentRow.Selected = True
    End Sub



    Private Sub dgPDet_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellDoubleClick
        AdjQty()
        Calculate()
        tsbSave.Enabled = True
    End Sub

    Private Sub DgPDet_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgBDet.PreviewKeyDown

    End Sub
    Private Sub ExpColor(ByVal i As Integer)
        Try

            Dim nds As Long
            dgInv.Item(13, i).Style.ForeColor = Color.Black
            If dgInv.Item(13, i).Value & "" <> "" Then
                If IsDate(dgInv.Item(11, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgInv.Item(11, i).Value)
                    If nds < 0 Then
                        dgInv.Item(11, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgInv.Item(11, i).Style.ForeColor = Color.DarkRed

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    Private Sub AdjQty()
        Dim cmd As New OleDb.OleDbCommand
        Dim n As Double
        Dim i, ir As Integer

        cmd.Connection = Conn
        Try
            n = Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value & "") * Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "")


            dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value = 0
            dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value = 0

            dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(15, dgBDet.CurrentCell.RowIndex).Value

            dgInv.Item(12, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
            dgInv.Item(13, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(1, dgBDet.CurrentCell.RowIndex).Value
            ExpColor(dgInv.CurrentCell.RowIndex)
            dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value = Format(Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "") * dgBDet.Item(3, dgBDet.CurrentCell.RowIndex).Value, "0.0000")
            dgInv.Item(15, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(8, dgBDet.CurrentCell.RowIndex).Value
            dgInv.Item(16, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(9, dgBDet.CurrentCell.RowIndex).Value


            If dgBDet.Item(10, dgBDet.CurrentCell.RowIndex).Value = True Then
                dgInv.Item(17, dgInv.CurrentCell.RowIndex).Value = "Yes"
            ElseIf dgBDet.Item(10, dgBDet.CurrentCell.RowIndex).Value = False Then
                dgInv.Item(17, dgInv.CurrentCell.RowIndex).Value = "No"
            End If

            'dgInv.Item(22, dgInv.CurrentCell.RowIndex).Value = Format(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value * dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value, "0.000")



            dgInv.Item(21, ir).Value = "No"



            dgInv.Update()

            pnlPDet.Visible = False

            'If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n Then
            '    MsgBox("er")
            'End If

            If Val(dgInv.Item(0, dgInv.Rows.Count - 1).Value.ToString) <> 0 Then
                dgInv.Update()
                Sales.Rows.Add()
            End If

            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            dgInv.Focus()
            EditGrid()
            'ShowEditControl(txtEdit)
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub GetBatchDetails()

        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer
        Try

            cmd.Connection = Conn


            pnlPDet.Visible = False
            lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            'Batch.Stock<>0 and " & _
            '            "((Batch.Stock+COALESCE(select sum(qty) from invdetails where invdetails.type='" & cbType.SelectedValue & _
            '           "' and invno=22 and invdt= convert(datetime,'" & SysDt & "') and invdetails.batchid=batch.batchid))- COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0))<>0 and


            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value


            cmd.CommandText = "GetBatchinvAll"

            DA.SelectCommand = cmd
            DA.Fill(DS, "BatchDet")
            dgBDet.DataSource = DS.Tables("BatchDet")

            dgBDet.Columns(0).Width = 70
            dgBDet.Columns(1).Width = 100
            dgBDet.Columns(2).Width = 70
            dgBDet.Columns(3).Width = 70
            dgBDet.Columns(4).Width = 70
            dgBDet.Columns(5).Width = 70
            dgBDet.Columns(6).Width = 250
            dgBDet.Columns(7).Width = 70
            dgBDet.Columns(8).Width = 68
            dgBDet.Columns(9).Width = 68
            dgBDet.Columns(10).Width = 65
            dgBDet.Columns(11).Width = 65
            dgBDet.Columns(12).Width = 82
            dgBDet.Columns(13).Width = 65
            dgBDet.Columns(14).Width = 65
            dgBDet.Columns("batch").Width = 200
            dgBDet.Columns("exdt").Width = 200
            dgBDet.Columns("pack").Width = 200

            dgBDet.Columns(1).Width = 100

            dgBDet.Columns(15).Visible = False
            dgBDet.Columns(16).Visible = False
            If dgBDet.RowCount > 0 Then
                dgBDet.CurrentCell = dgBDet.Item(0, 0)
            End If
            DisableBatchGrid()
            pnlPDet.Visible = True

            If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                For i = 0 To dgBDet.RowCount - 1
                    If Val(dgInv.Item(2, dgInv.CurrentRow.Index).Value & "") = dgBDet.Item(15, i).Value Then
                        dgBDet.CurrentCell = dgBDet.Item(0, i)
                    End If
                    ExpColorBat(i)
                Next

            End If

            If dgBDet.Rows.Count = 0 Then
                pnlPDet.Visible = False
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
                        dgBDet.Item(1, i).Style.ForeColor = Color.DarkRed

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

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
            cntrol.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub EditGrid()
        Try
            txtedit.Mask = ""
            txtedit.PromptChar = " "

            If dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & "" = "" Then
                dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            End If

            If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" And dgInv.CurrentCell.ColumnIndex = 11 Then
                Exit Sub
            End If

            If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 And dgInv.CurrentCell.ColumnIndex = 7 Then
                Exit Sub
            End If




            EDROW = dgInv.CurrentCell.RowIndex
            EDCOL = dgInv.CurrentCell.ColumnIndex

            If IsNothing(dgInv.CurrentCell) Then Exit Sub





            TabFlag = True
            pnlPDet.Enabled = False
            Select Case dgInv.CurrentCell.ColumnIndex
                Case 0, 22
                    Exit Sub
                Case 12 'batch
                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        GetBatchDetails()
                    Else
                    End If
                    pnlPDet.Enabled = True
                    dgInv.Enabled = False
                    ShowEditControl(txtedit)
                    txtedit.SelectAll()
                    txtedit.Focus()
                Case 13 'exdt
                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        GetBatchDetails()
                    Else
                    End If
                    pnlPDet.Enabled = True
                    dgInv.Enabled = False

                    txtedit.Mask = DateMask
                    txtedit.PromptChar = "_"

                    If IsDate(dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentRow.Index).Value & "") Then
                        txtedit.Text = (dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentRow.Index).Value)
                    Else
                        txtedit.Text = "__/__/__"
                    End If

                    ShowEditControl(txtedit)
                    txtedit.SelectAll()

                Case 11 'pack
                    pnlPDet.Enabled = False
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then Exit Sub
                    dgInv.Enabled = False
                    GetPacking()
                    If dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "" <> "" Then
                        CbEditUnit.SelectedValue = Round(Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & ""), 0)
                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        GetBatchDetails()
                    End If
                    ShowEditControl(CbEditUnit)
                Case 16
                    pnlPDet.Visible = False
                    dgInv.Enabled = False

                    dgInv.CurrentCell.Value = "0.00"
                    cbEditVat.Text = "0.00"
                    ShowEditControl(cbEditVat)
                Case 17
                    dgInv.Enabled = False
                    dgInv.CurrentCell.Value = "Yes"
                    CbEditTaxInc.Text = "Yes"
                    ShowEditControl(CbEditTaxInc)
                Case 8 'qty
                    pnlPDet.Enabled = False
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then
                        BatchDeselect()
                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                        GetBatchDetails()
                    Else
                    End If
                    dgInv.Enabled = False
                    ShowEditControl(txtedit)
                    txtedit.SelectAll()
                Case 21
                    pnlPDet.Visible = False
                    If dgInv.CurrentCell.Value & "" = "No" Or dgInv.CurrentCell.Value & "" = "" Then
                        dgInv.CurrentCell.Value = "Yes"
                    Else
                        dgInv.CurrentCell.Value = "No"
                    End If
                Case Else
                    pnlPDet.Enabled = False
                    dgInv.Enabled = False
                    ShowEditControl(txtedit)
                    txtedit.SelectAll()

            End Select
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub



    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtedit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Select Case dgInv.CurrentCell.ColumnIndex
                    Case 8
                        pnlPDet.Enabled = True
                        If Val(txtedit.Text) <> 0 Then
                            dgInv.Enabled = True
                            dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtedit.Text), "0")
                            If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 Then
                                txtedit.Visible = False
                                AdjQty()
                                Calculate()
                            Else
                                txtedit.Visible = False
                                dgInv.CurrentCell = dgInv.Item(11, dgInv.CurrentCell.RowIndex)
                                Calculate()
                                EditGrid()
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Case 15
                        pnlPDet.Enabled = False
                        dgInv.Enabled = True
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtedit.Text), "0.00")
                        dgInv.CurrentCell = dgInv.Item(15, dgInv.CurrentCell.RowIndex)
                        Calculate()
                    Case 7
                        Exit Sub
                    Case 12 'batch
                        pnlPDet.Enabled = False
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = txtedit.Text
                        dgInv.CurrentCell = dgInv.Item(13, dgInv.CurrentCell.RowIndex)
                        Calculate()
                        EditGrid()
                        Exit Sub
                    Case 13 'exdt
                        dgInv.Enabled = True
                        If ExpDateCheck(txtedit, True, False) = False Then
                            Exit Sub
                        End If
                        pnlPDet.Enabled = False
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = txtedit.Text
                        dgInv.CurrentCell = dgInv.Item(14, dgInv.CurrentCell.RowIndex)
                        Calculate()
                        EditGrid()
                        Exit Sub
                    Case 14
                        pnlPDet.Enabled = False
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtedit.Text), "0.000")
                        dgInv.CurrentCell = dgInv.Item(16, dgInv.CurrentCell.RowIndex)
                        txtedit.Visible = False
                        Calculate()
                        EditGrid()
                        Exit Sub
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
                    txtedit.Visible = False
                    ClearRow()
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtedit.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Select Case dgInv.CurrentCell.ColumnIndex
            Case 8
                If Asc(e.KeyChar) = 8 Then Exit Sub
                If InStr("0123456789-.", e.KeyChar) = 0 Then e.KeyChar = ""
        End Select
    End Sub

    Private Sub txtEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtedit.Leave
        If Not pnlprod.Visible Then
            TabFlag = False
            pnlprod.Visible = False
            If dgInv.CurrentRow.Index < dgInv.RowCount - 1 Then
                txtedit.Visible = False
                dgInv.Enabled = True
                dgInv.Focus()
            End If
        End If
    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtedit.TextChanged
        Select Case dgInv.CurrentCell.ColumnIndex
            Case 7
                If ProdSelected = True Then Exit Sub
                obj = txtedit
                PopulateProduct()
        End Select
    End Sub

    Private Sub GetPacking()
        Dim cmd As New OleDb.OleDbCommand
        Dim unittab1 As New DataTable
        Try
            unittab1.TableName = "Pack"
            unittab1.Columns.Add()
            unittab1.Columns(0).ColumnName = "unit"
            unittab1.Columns.Add()
            unittab1.Columns(1).ColumnName = "Case"

            cmd.Connection = Conn
            cmd.CommandText = "Select case1,case2,case3,unit1,unit2,unit3 from product where prdcode=""" + dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value + """ "
            ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                CbEditUnit.DataSource = Nothing

                unittab1.Rows.Add(dataredr.Item("unit1"), dataredr.Item("case1") & " (" & Round(dataredr.Item("unit1"), 0) & ") ")

                If dataredr.Item("unit2") <> 0 Then
                    unittab1.Rows.Add(dataredr.Item("unit2"), dataredr.Item("case2") & " (" & Round(dataredr.Item("unit2"), 0) & ") ")
                End If

                If dataredr.Item("unit3") <> 0 Then
                    unittab1.Rows.Add(dataredr.Item("unit3"), dataredr.Item("case3") & " (" & Round(dataredr.Item("unit3"), 0) & ") ")
                End If

                CbEditUnit.ValueMember = "unit"
                CbEditUnit.DisplayMember = "Case"
                CbEditUnit.DataSource = unittab1
            End If
            dataredr.Close()
            ProdSelected = False
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgInv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.DoubleClick
        'If Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value & "") < 0 Then
        ' GetProduct(dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value)
        ' Else

        EditGrid()
        'End If
    End Sub

    Private Sub dgInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgInv.KeyDown
        Dim k As Integer
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
                    If Microsoft.VisualBasic.InStr(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value, "*") <> 0 Then
                        BatchDeselect()
                    Else
                        dgInv.Rows.Remove(dgInv.CurrentRow)
                        Calculate()
                        dgInv.Focus()
                    End If
                End If

                If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then
                    tsbSave.Enabled = False
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
                    'WriteOutGo(-3, Val(dgInv.Item(8, i).Value), i)

                    If tmprow = -1 Then
                        tmprow = i
                        dgInv.Item(0, i).Value = Microsoft.VisualBasic.Left(TMPSL, Len(TMPSL) - 1)
                        i = i + 1
                        'dgInv.Item(3, i).Value = ""     'to clear outgo when cancel clicked
                    Else

                        dgInv.Rows.Remove(dgInv.Rows(i))
                        'WriteOutGo(-2, 0, i)

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
        txtedit.Visible = False
    End Sub

    Private Sub CbEditUnit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditUnit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dgInv.Enabled = True
                dgInv.CurrentCell.Value = CbEditUnit.Text '& " (" & CbEditUnit.SelectedValue & ") "
                dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value = Round(Val(CbEditUnit.SelectedValue & ""), 0)
                CbEditUnit.Visible = False
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
                    CbEditUnit.Visible = False
                    dgInv.Focus()
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditUnit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditUnit.Leave
        If dgInv.CurrentRow.Index < dgInv.RowCount - 1 Then
            CbEditUnit.Visible = False
            dgInv.Enabled = True
            dgInv.Focus()
        End If
    End Sub

    Private Sub cbEditVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbEditVat.KeyDown
        If e.KeyCode = Keys.Enter Then

            dgInv.CurrentCell.Value = cbEditVat.Text
            cbEditVat.Visible = False
            dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(cbEditVat.Text), "0.00")
            dgInv.CurrentCell = dgInv.Item(17, dgInv.CurrentCell.RowIndex)
            Calculate()
            EditGrid()

        End If
        If e.KeyCode = Keys.Escape Then

            dgInv.Enabled = True
            dgInv.Focus()
        End If
    End Sub

    Private Sub cbEditVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEditVat.Leave
        cbEditVat.Visible = False
        dgInv.Focus()
        dgInv.Enabled = True
        dgInv.Focus()
    End Sub

    Private Sub CbEditTaxInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditTaxInc.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgInv.CurrentCell.Value = CbEditTaxInc.Text
            CbEditTaxInc.Visible = False
            If Val(dgInv.Item(0, dgInv.Rows.Count - 1).Value.ToString) <> 0 Then
                dgInv.Update()
                Sales.Rows.Add()
                Calculate()
                dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
                EditGrid()
            End If

            'CbEditTaxInc.Visible = False
            'dgInv.Enabled = True
            'dgInv.Focus()
            'Calculate()
        End If
        If e.KeyCode = Keys.Escape Then
            CbEditTaxInc.Visible = False
            dgInv.Enabled = True
            dgInv.Focus()
        End If
    End Sub

    Private Sub CbEditTaxInc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditTaxInc.Leave
        CbEditTaxInc.Visible = False
        dgInv.Enabled = True
        dgInv.Focus()
    End Sub

    Private Sub Calculate()
        tsbSave.Enabled = False
        Dim n As Integer
        Try
            Dim i, fnd, stk, scst, stax, bdis, sr, abdis, amtval, tmprnd As Double
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
            For i = 0 To 4
                rtaxary(i, 1) = 0
                rptax(i, 1) = 0
            Next i

            For n = 0 To dgInv.Rows.Count - 2
                stk = 0
                value = 0
                scst = 0
                stax = 0
                sr = 0
                Svalue = 0
                stax = 0
                stk = Val(dgInv.Item(8, n).Value & "")
                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgInv.Item(14, n).Value & "")), 2)
                    scst = value * Val(dgInv.Item(15, n).Value & "") / 100
                    totcst = totcst + scst
                    value = value + scst
                    bdis = value * Val(txtDis.Text) / 100
                    totbdis = totbdis + bdis
                    value = value - bdis

                    If Val(dgInv.Item(16, n).Value) <> 0 Then

                        If dgInv.Item(17, n).Value = "Yes" Then
                            stax = value * Round(Val(dgInv.Item(16, n).Value & "") / (100 + Val(dgInv.Item(16, n).Value & "")), 2)
                            value = value - stax
                        Else
                            stax = value * Round(Val(dgInv.Item(16, n).Value & "") / 100, 2)
                        End If
                        fnd = 0
                        For i = 0 To 4
                            If Val(dgInv.Item(16, n).Value) = rtaxary(i, 0) Then
                                rtaxary(i, 1) = rtaxary(i, 1) + value
                                rptax(i, 1) = rptax(i, 1) + stax
                                fnd = 1
                                Exit For
                            End If
                        Next i
                        If fnd = 0 Then
                            tfamt = tfamt + value + stax
                        End If
                    Else
                        tfamt = tfamt + value
                    End If

                    totstax = totstax + stax
                    value = value + stax
                    dgInv.Item(22, n).Value = Format(value, "0.00")
                    totvalue = totvalue + value
                End If
                tsbSave.Enabled = True
            Next

            totvalue = 0

            For i = 0 To 4
                rtaxary(i, 1) = Round(rtaxary(i, 1), 2)
                rptax(i, 1) = Round(rptax(i, 1), 2)
                totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1)
            Next

            tfamt = Round(tfamt, 2)
            totvalue = totvalue + tfamt

            totadj = Val(txtAdd.Text) - Val(txtDed.Text)

            totvalue = Val(Format(totvalue, "0.00"))
            totstax = Val(Format(totstax, "0.00"))
            totbdis = Val(Format(totbdis, "0.00"))
            totsdis = Val(Format(totsdis, "0.00"))
            totscst = Val(Format(totscst, "0.00"))
            lblTamt.Text = Format(totvalue, "0.00")
            amtval = Format(totvalue, "0.00")
            tmprnd = Format(amtval, "0")
            txtAdd.Text = "0.00"
            txtDed.Text = "0.00"


            tmprnd = RoundPaise(amtval, RndPai)


            If Val(amtval) - Val(tmprnd) < 0 Then
                txtAdd.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            ElseIf Val(amtval) - Val(tmprnd) > 0 Then
                txtDed.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            End If

            lblNamt.Text = Format(totvalue + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub txtDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDis.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtDis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDis.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtDis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDis.LostFocus
        txtDis.Text = Format(Val(txtDis.Text), "0.00")
    End Sub

    Private Sub txtDis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDis.TextChanged
        'Calculate()
    End Sub

    Private Sub btnAddQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Purchase.MdiParent = Main
        Purchase.Show()
    End Sub

    Private Sub dgInv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.LostFocus
        dgInv.CurrentCell.Selected = False
    End Sub

    Private Sub dgInv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.GotFocus
        dgInv.CurrentCell.Selected = True
    End Sub

    'Private Sub tsbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SalesCopy.Show()
    'End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        If dgInv.RowCount > 1 Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If

        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        If dgInv.RowCount > 1 Then
            If MsgBox("Entries found. Want to exit now..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If
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
        lblNamt.Text = Format(Val(lblTamt.Text) + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtAdd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            'txtAdd.Focus()
            'txtAdd.SelectAll()
            ' tsbSave.Select()

        End If
    End Sub

    Private Sub txtAdd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdd.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdd.LostFocus
        txtAdd.Text = Format(Val(txtAdd.Text), "0.00")
    End Sub

    Private Sub txtAdd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd.TextChanged
        lblNamt.Text = Format(Val(lblTamt.Text) + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub dgBDet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.LostFocus
        'dgBDet.CurrentRow.Selected = False
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim rpt


        Try
            If save() <> 0 Then

                cmd.Connection = Conn
                cmd.CommandText = "select printline,preprintline,invmsg,invpreprint from settings"
                dr = cmd.ExecuteReader
                dr.Read()

                If dr("invpreprint") Then
                    'rpt = New PrePrintDirect.PrePrintDirect
                    'rpt = New PharmaPrePrint.PrePrintDirect
                    rpt = New PrePrintDirect
                    rpt.PageLines = dr("preprintline")
                    'rpt.Main_form = Me.ParentForm
                    'rpt.DbConn = Conn
                    'rpt.Pre_Form = PrintPreview

                    'rpt = New PrePrintDirect
                    'rpt.PageLines = dr("preprintline")
                Else
                    rpt = New PrintDirectClass.PrintDirect
                    rpt.PageLines = dr("printline")
                End If
                rpt.PrintMessage = dr("invmsg") & ""
                dr.Close()
                rpt.StartNumber = InvNum
                rpt.EndNumber = InvNum
                rpt.StartDate = dtp.Value.Date
                rpt.EndDate = dtp.Value.Date
                If ChkCredit.Checked Then
                    rpt.TransType = 98
                Else

                    rpt.TransType = 99
                End If

                FirmValues(rpt)
                If ckbPntwin.Checked Then
                    rpt.PrintDestination = PrintOutput.ToWindow
                Else
                    rpt.PrintDestination = PrintOutput.ToPrinter
                End If

                ClearForm()
                rpt.PrintInvoice(Conn, PrintPreview, Main, PrintPreview.TB)
                If Not chkKeepRec.Checked Then
                    If ChkCredit.Checked Then
                        cmd.CommandText = "DELETE FROM INVTOTAL WHERE TYPE='98' and invno=" & InvNum & " and invdt=convert(datetime," & dtp.Value.Date & ") "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM INVDETAILS WHERE TYPE='98' and invno=" & InvNum & " and invdt=convert(datetime," & dtp.Value.Date & ") "
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "DELETE FROM INVTOTAL WHERE TYPE='99' and invno=" & InvNum & " and invdt=convert(datetime," & dtp.Value.Date & ") "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM INVDETAILS WHERE TYPE='99' and invno=" & InvNum & " and invdt=convert(datetime," & dtp.Value.Date & ") "
                        cmd.ExecuteNonQuery()
                    End If

                End If

            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Function save() As Long

        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        Dim sql, sqlexdt As String
        Dim Trn As Boolean
        Dim i As Integer
        Try


            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn
            Trn = True
            InvNum = Val(txtbno.Text)
            InvDt = dtp.Value.Date




            sql = "insert into invtotal (Invno,Invdt,type,CusCode,Name," & _
                  "BDis,BDisAmt,TFAmt,Amt1,Tax1,Amt2,Tax2,Amt3,Tax3,Amt4,Tax4,Amt5,Tax5,NetAmt,AddAmt," & _
                  "Flag,DedAmt,DocName,cardno,cancelled,edited) Values(" & InvNum & ",'" & InvDt & "'," & _
                     IIf(ChkCredit.Checked, "98", "99") & "," & Val(cbCus.SelectedValue) & ",""" & cbPat.Text & _
                  """," & Val(txtDis.Text) & "," & totbdis & "," & tfamt & "," & Val(rtaxary(0, 1)) & "," & Val(rptax(0, 1)) & _
                  "," & Val(rtaxary(1, 1)) & "," & Val(rptax(1, 1)) & "," & Val(rtaxary(2, 1)) & "," & Val(rptax(2, 1)) & _
                  "," & Val(rtaxary(3, 1)) & "," & Val(rptax(3, 1)) & "," & Val(rtaxary(4, 1)) & "," & Val(rptax(4, 1)) & _
                  "," & Val(lblNamt.Text) & "," & Val(txtAdd.Text) & _
                  ",''," & Val(txtDed.Text) & ",""" & cbDoc.Text & """,""" & txtccard.Text & """,0," & IIf(EditFlag, 1, 0) & ")"


            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            For i = 0 To dgInv.Rows.Count - 2

                If Not IsDate(dgInv.Item(13, i).Value) Then
                    sqlexdt = "NULL"
                Else
                    sqlexdt = "'" & dgInv.Item(13, i).Value & "'"
                End If

                sql = "insert into invdetails(Invno,Invdt,Type,PrdCode,Batch,Batchid,ExDt,Pack,Qty," & _
                      "Srate,ST,cst,Unit,SValue,Seq,Sman,Bdis,Priflag," & _
                      "TaxInc,BrkRtn,cancelled,edited,cardno) values(" & InvNum & ",'" & InvDt & "'," & IIf(ChkCredit.Checked, "98", "99") & _
                      ",""" & dgInv.Item(1, i).Value & """,""" & dgInv.Item(12, i).Value & _
                      """," & Val(dgInv.Item(2, i).Value & "") & "," & sqlexdt & _
                      ",""" & (dgInv.Item(11, i).Value & "") & """," & (Val(dgInv.Item(8, i).Value & "") * Val(dgInv.Item(3, i).Value & "")) & _
                      "," & Math.Round((Val(dgInv.Item(14, i).Value) / Val(dgInv.Item(3, i).Value & "")), 3) & ",""" & Val(dgInv.Item(16, i).Value) & _
                      """," & dgInv.Item(16, i).Value & "," & Val(dgInv.Item(3, i).Value & "") & "," & Val(dgInv.Item(22, i).Value & "") & _
                      "," & i & "," & Val(cbSal.SelectedValue & "") & _
                      "," & Val(txtDis.Text) & ",0," & IIf(dgInv.Item(17, i).Value & "" = "Yes", 1, 0) & _
                      "," & IIf(dgInv.Item(21, i).Value & "" = "Yes", 1, 0) & ",0," & IIf(EditFlag, 1, 0) & ",""" & txtccard.Text & """)"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()


            Next i

            Trans.Commit()
            Trn = False
            save = InvNum
        Catch er As Exception
            save = 0
            If Trn Then Trans.Rollback()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Function




    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbDoc.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub



    Private Sub cbSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbSal.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
            EditGrid()
        End If
    End Sub



    Private Sub cbPat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbPat.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub







    Private Sub cbCus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbCus.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCus.SelectedIndexChanged

    End Sub

    Private Sub dgInv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInv.CellContentClick

    End Sub

    Private Sub cbSal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSal.SelectedIndexChanged

    End Sub

    Private Sub cbSal_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSal.StyleChanged

    End Sub

    Private Sub CbEditUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEditUnit.SelectedIndexChanged

    End Sub
    Private Sub DisableBatchGrid()
        'dgBDet.Enabled = False
        If dgBDet.RowCount <> 0 Then
            Try
                dgBDet.CurrentRow.Selected = False
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub EnableBatchGrid()
        dgBDet.Enabled = True
        If dgBDet.RowCount <> 0 Then dgBDet.CurrentRow.Selected = True
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

    Private Sub cbccard_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbccard.SelectedValueChanged

    End Sub

    Private Sub cbccard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbccard.TextChanged

        txtccard.Tag = "Y"
        txtccard.Text = cbccard.SelectedValue
        txtccard.Tag = ""
    End Sub


    Private Sub DgSales_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSales.CellContentClick

    End Sub

    Private Sub DgSales_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSales.CellDoubleClick
        If DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "Yes" Then

            DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "No"
            For i = 0 To DgSales.ColumnCount - 1
                DgSales.Item(i, DgSales.CurrentCell.RowIndex).Style.ForeColor = Color.Black

            Next

        Else
            DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "Yes"
            For i = 0 To DgSales.ColumnCount - 1
                DgSales.Item(i, DgSales.CurrentCell.RowIndex).Style.ForeColor = Color.Red

            Next

        End If
    End Sub

    Private Sub ComOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comok.Click
        '1:      Sales.Columns.Add("SL")
        '2:      Sales.Columns.Add("Code")
        '3:      Sales.Columns.Add("BatchId")
        '4:      Sales.Columns.Add("Unit")
        '5:      Sales.Columns.Add("resv1")
        '6:      Sales.Columns.Add("resv2")
        '7:      Sales.Columns.Add("resv3")
        '8:      Sales.Columns.Add("Product")
        '9:      Sales.Columns.Add("Qty")
        '10:     Sales.Columns.Add("Free")
        '11:     Sales.Columns.Add("Repl")
        '12:     Sales.Columns.Add("Packing")
        '13:     Sales.Columns.Add("Batch")
        '14:     Sales.Columns.Add("ExDt")
        '15:     Sales.Columns.Add("Rate")
        '16:     Sales.Columns.Add("RT")
        '17:     Sales.Columns.Add("VAT")
        '18:     Sales.Columns.Add("TaxInc")
        '19:     Sales.Columns.Add("resv4")
        '20:     Sales.Columns.Add("resv5")
        '21:     Sales.Columns.Add("resv6")
        '22:     Sales.Columns.Add("Breakage")
        '23:     Sales.Columns.Add("Amount")


        For i As Integer = 0 To DgSales.RowCount - 1
            If DgSales.Item(0, i).Value = "Yes" Then
                dgInv.Item(0, dgInv.RowCount - 1).Value = dgInv.RowCount
                dgInv.Item(1, dgInv.RowCount - 1).Value = DgSales.Item(2, i).Value
                dgInv.Item(2, dgInv.RowCount - 1).Value = DgSales.Item(3, i).Value
                dgInv.Item(3, dgInv.RowCount - 1).Value = DgSales.Item(1, i).Value
                dgInv.Item(7, dgInv.RowCount - 1).Value = DgSales.Item(4, i).Value
                dgInv.Item(8, dgInv.RowCount - 1).Value = DgSales.Item(5, i).Value
                dgInv.Item(11, dgInv.RowCount - 1).Value = DgSales.Item(6, i).Value
                dgInv.Item(12, dgInv.RowCount - 1).Value = DgSales.Item(7, i).Value
                dgInv.Item(13, dgInv.RowCount - 1).Value = DgSales.Item(8, i).Value
                dgInv.Item(14, dgInv.RowCount - 1).Value = DgSales.Item(9, i).Value
                dgInv.Item(15, dgInv.RowCount - 1).Value = DgSales.Item(12, i).Value
                dgInv.Item(16, dgInv.RowCount - 1).Value = DgSales.Item(10, i).Value
                dgInv.Item(17, dgInv.RowCount - 1).Value = DgSales.Item(11, i).Value
                dgInv.Item(21, dgInv.RowCount - 1).Value = "No"
                dgInv.Update()
                Sales.Rows.Add()
            End If
        Next
        Calculate()
        pnlsales.Visible = False
        dgInv.Enabled = True
        dgInv.CurrentCell = dgInv.Item(7, dgInv.RowCount - 1)
        dgInv.Focus()
        'panInvoice.Enabled = True

    End Sub








    Private Sub CbEditTaxInc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEditTaxInc.SelectedIndexChanged

    End Sub

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub

    Private Sub txtbno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbno.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtbno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbno.TextChanged

    End Sub

    Private Sub cbDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDoc.SelectedIndexChanged

    End Sub

    Private Sub dtp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp.ValueChanged
        Dim CMD As New OleDb.OleDbCommand
        CMD.Connection = Conn
        CMD.CommandText = "select invno from invtotal where type='21' and invdt<convert(datetime,'" & dtp.Value.Date & "') order by invno desc"
        txtbno.Text = Val(CMD.ExecuteScalar & "") + 1
    End Sub

    Private Sub cbPat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPat.SelectedIndexChanged

    End Sub

    Private Sub dgBDet_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellContentClick

    End Sub

    Private Sub panInvoice_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panInvoice.Paint

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        histno = 0
        CustHistory.History(Val(txtccard.Text))
        CustHistory.ShowDialog()
        If histno <> 0 Then



            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            Dim qt As Long

            cmd1.CommandText = "select invdetails.*,product.prdname,product.case1,docname,name from invdetails,invtotal,product where " & _
                "invtotal.invdt=invdetails.invdt and invtotal.invno=invdetails.invno and invtotal.type=invdetails.type and  " & _
                    "product.prdcode=invdetails.prdcode and invdetails.type='" & histtype & "' and invdetails.invno=" & histno & " and  invdetails.invdt=convert(datetime,'" & histdt & "')"
            cmd1.Connection = Conn
            rdr = cmd1.ExecuteReader
            txtedit.Visible = False
            CbEditTaxInc.Visible = False
            cbEditVat.Visible = False
            CbEditUnit.Visible = False
            If Not rdr.HasRows Then
                Exit Sub
            End If
            While rdr.Read


                qt = rdr("qty")

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = rdr("prdcode")
                cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = SysDt
                cmd.Parameters.Add("@edit", OleDb.OleDbType.Integer).Value = 0
                cmd.Parameters.Add("@type", OleDb.OleDbType.VarChar, 2).Value = " "
                cmd.Parameters.Add("@no", OleDb.OleDbType.BigInt).Value = 0
                cmd.Parameters.Add("@ord", OleDb.OleDbType.BigInt).Value = 1
                cmd.CommandText = "GetBatchinv"

                cmd.Connection = Conn
                da.SelectCommand = cmd
                dt.Clear()
                da.Fill(dt)

                cbDoc.Text = rdr("docname") & ""
                cbPat.Text = rdr("name") & ""
                For i = 0 To dt.Rows.Count - 1



                    dgInv.Item(1, dgInv.Rows.Count - 1).Value = rdr("prdcode")
                    dgInv.Item(2, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batchid")
                    dgInv.Item(3, dgInv.Rows.Count - 1).Value = 1
                    dgInv.Item(7, dgInv.Rows.Count - 1).Value = rdr("PrdName")

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
                    dgInv.Item(11, dgInv.Rows.Count - 1).Value = rdr("case1") & ""
                    dgInv.Item(12, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batch") & ""
                    dgInv.Item(13, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("ExDt")
                    dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("srate"), 4, MidpointRounding.AwayFromZero)
                    dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("scst"), 2)
                    dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("vat"), 2)
                    ' WriteOutGo(dt.Rows(i).Item("batchid"), dgInv.Item(8, dgInv.Rows.Count - 1).Value, dgInv.Rows.Count - 1)
                    If (dt.Rows(i).Item("TaxInc")) = 0 Then
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                    Else
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                    End If
                    dgInv.Update()
                    Sales.Rows.Add()
                    If qt = 0 Then Exit For
                Next

            End While

            rdr.Close()

            Calculate()

            dgInv.Enabled = True
            dgInv.Focus()


        End If
    End Sub

    Private Sub cbccard_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbccard.SelectedIndexChanged
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
    End Sub

    Private Sub btnpresadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpresadd.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim qt As Long

        cmd1.CommandText = "select PrescriptionEntry.*,product.prdname,product.case1 from PrescriptionEntry,product where product.prdcode=PrescriptionEntry.medcode and  cardno=" & Val(txtccard.Text) & _
                " and Prescname=""" & cbpresc.Text & """"
        cmd1.Connection = Conn
        rdr = cmd1.ExecuteReader
        txtedit.Visible = False
        CbEditTaxInc.Visible = False
        cbEditVat.Visible = False
        CbEditUnit.Visible = False
        While rdr.Read


            qt = rdr("qty")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar, 10).Value = rdr("medcode")
            cmd.Parameters.Add("@SysDt", OleDb.OleDbType.DBDate).Value = SysDt
            cmd.Parameters.Add("@edit", OleDb.OleDbType.Integer).Value = 0
            cmd.Parameters.Add("@type", OleDb.OleDbType.VarChar, 2).Value = " "
            cmd.Parameters.Add("@no", OleDb.OleDbType.BigInt).Value = 0
            cmd.Parameters.Add("@ord", OleDb.OleDbType.BigInt).Value = 1
            cmd.CommandText = "GetBatchinv"

            cmd.Connection = Conn
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)

            cbDoc.Text = rdr("docname") & ""
            cbPat.Text = rdr("patname") & ""
            For i = 0 To dt.Rows.Count - 1



                dgInv.Item(1, dgInv.Rows.Count - 1).Value = rdr("medcode")
                dgInv.Item(2, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batchid")
                dgInv.Item(3, dgInv.Rows.Count - 1).Value = 1
                dgInv.Item(7, dgInv.Rows.Count - 1).Value = rdr("PrdName")

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
                dgInv.Item(11, dgInv.Rows.Count - 1).Value = rdr("case1") & ""
                dgInv.Item(12, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("batch") & ""
                dgInv.Item(13, dgInv.Rows.Count - 1).Value = dt.Rows(i).Item("ExDt")
                dgInv.Item(14, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("srate"), 4, MidpointRounding.AwayFromZero)
                dgInv.Item(15, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("scst"), 2)
                dgInv.Item(16, dgInv.Rows.Count - 1).Value = Round(dt.Rows(i).Item("vat"), 2)
                'WriteOutGo(dt.Rows(i).Item("batchid"), dgInv.Item(8, dgInv.Rows.Count - 1).Value, dgInv.Rows.Count - 1)
                If (dt.Rows(i).Item("TaxInc")) = 0 Then
                    dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                Else
                    dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                End If
                dgInv.Update()
                Sales.Rows.Add()
                If qt = 0 Then Exit For
            Next

        End While

        rdr.Close()

        Calculate()

        dgInv.Enabled = True
        dgInv.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New PrescriptionEntry
        If txtccard.Text = "" Then Exit Sub

        frm.MdiParent = Me.ParentForm
        frm.Width = Me.ParentForm.Width
        frm.Height = Me.ParentForm.Height
        frm.Show()
        frm.OpenForm(txtccard.Text, cbpresc.Text)
    End Sub


    Private Sub tsbCopy_Click(sender As System.Object, e As System.EventArgs) Handles tsbCopy.Click
        If CheckUserLocked("Allow Bill Copy", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub

        BillCopy.txtNof.Focus()

        BillCopy.Text = "Duplicate Copy"
        BillCopy.loadform()
        BillCopy.btnPrint.Visible = True
        BillCopy.BtnFile.Visible = True
        BillCopy.cbType.SelectedValue = "99"
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
End Class

