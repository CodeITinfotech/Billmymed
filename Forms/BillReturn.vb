Imports System
Imports System.Globalization
Imports System.math



Public Class BillReturn
    Private obj As Object
    Private ProdSelected As Boolean
    Private TaxTbl As DataTable
    Public RtnSales As DataTable
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
    Private UseBarCode As Boolean

    Private Sub GetBarCode()
        Try
            Dim dataredr As OleDb.OleDbDataReader
            Dim DS As New DataSet
            Dim cmd As New OleDb.OleDbCommand

            Dim pc As String

            cmd.Connection = Conn

          

            cmd.Connection = Conn
            cmd.CommandText = "Select product.PrdCode,prdname from Barcodes,product where  product.prdcode=barcodes.prdcode  and BarCode=""" & txtEdit.Text & """ "
            dataredr = cmd.ExecuteReader

            If dataredr.HasRows Then
                dataredr.Read()
                InvDetail(dataredr(0), dataredr(1))
            Else
                txtEdit.Focus()
                txtEdit.SelectAll()
                MsgBox("Product not found..")
                Exit Sub
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub



    Private Sub Sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' If e.KeyCode = Keys.Enter Then
        'If Not TabFlag Then System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ClearForm()

        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.LightGreen 'RGB(192, 255, 192) 'Color.Wheat
        ToolStrip.Renderer = renderer
    End Sub




    Public Sub ClearForm()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim I As Integer
        Dim cmd As New OleDb.OleDbCommand

        Try
            'Dim i As Integer

            curunit = 0
            cmd.Connection = Conn

            TaxTbl = New DataTable
            RtnSales = New DataTable
            dgInv.DataSource = Nothing
            RtnSales.TableName = "RtnSales"

            dgInv.Enabled = True
1:          RtnSales.Columns.Add("SL")
2:          RtnSales.Columns.Add("Code")
3:          RtnSales.Columns.Add("BatchId")
4:          RtnSales.Columns.Add("Unit")
5:          RtnSales.Columns.Add("resv1")
6:          RtnSales.Columns.Add("resv2")
7:          RtnSales.Columns.Add("resv3")
8:          RtnSales.Columns.Add("Product")
9:          RtnSales.Columns.Add("Qty")
10:         RtnSales.Columns.Add("Free")
11:         RtnSales.Columns.Add("Repl")
12:         RtnSales.Columns.Add("Packing")
13:         RtnSales.Columns.Add("Batch")
14:         RtnSales.Columns.Add("ExDt")
15:         RtnSales.Columns.Add("Rate")
16:         RtnSales.Columns.Add("RT")
17:         RtnSales.Columns.Add("VAT")
18:         RtnSales.Columns.Add("TaxInc")
19:         RtnSales.Columns.Add("resv4")
20:         RtnSales.Columns.Add("resv5")
21:         RtnSales.Columns.Add("nodisc")
22:         RtnSales.Columns.Add("Breakage")
23:         RtnSales.Columns.Add("Amount")


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
            dgInv.Columns.Add("nodisc", "")
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
            dgInv.Columns(20).DataPropertyName = "nodisc"
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
            dgInv.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(22).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInv.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dgInv.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            dgInv.Columns(0).Width = Int(dgInv.Width * 5 / 100)


            dgInv.Columns(1).Visible = False
            dgInv.Columns(2).Visible = False
            dgInv.Columns(3).Visible = False
            dgInv.Columns(4).Visible = False
            dgInv.Columns(5).Visible = False
            dgInv.Columns(15).Visible = False
            dgInv.Columns(17).Visible = False
            dgInv.Columns(6).Visible = False

            dgInv.Columns(7).Width = Int(dgInv.Width * 30 / 100)
            dgInv.Columns(8).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(9).Visible = False
            dgInv.Columns(10).Visible = False
            dgInv.Columns(11).Width = Int(dgInv.Width * 10 / 100)
            dgInv.Columns(12).Width = Int(dgInv.Width * 7 / 100)
            dgInv.Columns(13).Width = Int(dgInv.Width * 10 / 100)
            dgInv.Columns(14).Width = Int(dgInv.Width * 8 / 100)

            dgInv.Columns(16).Width = Int(dgInv.Width * 8 / 100)
            dgInv.Columns(17).Width = Int(dgInv.Width * 6 / 100)
            dgInv.Columns(18).Visible = False
            dgInv.Columns(19).Visible = False
            dgInv.Columns(20).Visible = False

            dgInv.Columns(21).Width = Int(dgInv.Width * 8 / 100)

            dgInv.Columns(22).Width = Int(dgInv.Width * 8 / 100)

            'dgInv.BackgroundColor = Color.Navy
            dgInv.DataSource = RtnSales

            RtnSales.Rows.Add()

            'For i = 0 To 22
            '    dgInv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            '    dgInv.Columns(i).DefaultCellStyle.BackColor = Color.Navy
            '    dgInv.Columns(i).DefaultCellStyle.ForeColor = Color.Yellow
            'Next i

            TaxTbl = New DataTable
            TaxTbl.TableName = "Tax"
            cmd.Connection = Conn

            cmd.CommandText = "select usebarcode from settings "
            UseBarCode = cmd.ExecuteScalar
            dgInv.Columns(1).Visible = UseBarCode

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


            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn


            cmd.CommandText = "select RndPaise from settings"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                While dataredr.Read()
                    RndPai = dataredr.Item("RndPaise")

                End While
            End If
            Trans.Commit()
            dataredr.Close()

            txtEdit.Visible = False
            CbEditUnit.Visible = False
            cbEditVat.Visible = False
            pnlPDet.Visible = False
            pnlprod.Visible = False

            editflag = False



            txtDis.Text = "0.00"

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
                    pnlprod.BringToFront()
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

    Private Sub InvDetail(Optional ByVal cd As String = "", Optional ByVal pc As String = "")

        Dim dataredr As OleDb.OleDbDataReader
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim tmpvar As Double

        cmd.Connection = Conn
        Try
            If cd = "" Then
                cd = DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value
                pc = (DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value)
            End If

            cmd.CommandText = "Select batchid  from Batch Where Batch.PrdCode=""" & cd & """ and ((batch.exdt IS NULL) or batch.exdt > convert(datetime,'" & SysDt & "')) "
            dataredr = cmd.ExecuteReader()
            tmpvar = 0
            If Not dataredr.HasRows Then
                pnlPDet.Visible = False
                pnlprod.Visible = False
                MsgBox("Batch Records not found..!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) '

                txtEdit.Focus()
                txtEdit.Text = ""
                Exit Sub
            End If
            dataredr.Close()

            'If tmpvar <> 0 Then
            txtEdit.SelectionStart = Len(txtEdit.Text)
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = cd
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = pc


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
            Application.DoEvents()
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
        Catch ex As Exception

        End Try

    End Sub



    Private Sub dgPDet_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellDoubleClick
        AdjQty()
        Calculate()

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
            n = dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value * Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value)


            dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value = 0
            dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value = 0

            dgInv.Item(2, dgInv.CurrentCell.RowIndex).Value = dgBDet.Item(15, dgBDet.CurrentCell.RowIndex).Value

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

            'dgInv.Item(22, dgInv.CurrentCell.RowIndex).Value = Format(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value * dgInv.Item(14, dgInv.CurrentCell.RowIndex).Value, "0.000")


            dgInv.Item(20, dgInv.CurrentCell.RowIndex).Value = dgBDet.Rows(dgBDet.CurrentCell.RowIndex).Cells("nodisc").Value

            dgInv.Item(21, dgInv.CurrentCell.RowIndex).Value = "No"




            dgInv.Update()

            pnlPDet.Visible = False

            'If dgBDet.Item(5, dgBDet.CurrentCell.RowIndex).Value < n Then
            '    MsgBox("er")
            'End If

            If Val(dgInv.Item(0, dgInv.Rows.Count - 1).Value.ToString) <> 0 Then
                dgInv.Update()
                RtnSales.Rows.Add()
            End If
            dgInv.CurrentCell = dgInv.Item(7, dgInv.Rows.Count - 1)
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
        Try
            cmd.Connection = Conn
            pnlPDet.Visible = False
            lblBDet.Text = (dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value) & "   Batch Details.."
            cmd.CommandText = "select Batch.Batch,Batch.ExDt,Batch.PRate,Batch.SRate,Batch.Pack," & _
                 "Batch.Stock AS STOCK,AcMaster.AcName as [Supplier],Batch.Profit,Batch.SCST,Batch.Stax,Batch.TaxInc," & _
                 "Batch.BillNo,Batch.BillDt,Batch.PCST,Batch.Ptax,Batch.BatchId," & _
                 "product.case1,isnull(product.nodisc,0) as nodisc FROM Batch INNER JOIN " & _
                 "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN " & _
                 "Acmaster ON Batch.Supcode = Acmaster.AcCode " & _
                 " WHERE  Batch.PrdCode = """ & dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & """   order by BatchId desc"

            DA.SelectCommand = cmd
            DA.Fill(DS, "BatchDet")
            dgBDet.DataSource = DS.Tables("BatchDet")

            If dgBDet.RowCount > 0 Then
                dgBDet.CurrentCell = dgBDet.Item(0, 0)
            End If
            DisableBatchGrid()


            If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then
                For i = 0 To dgBDet.RowCount - 1
                    If dgInv.Item(2, dgInv.CurrentRow.Index).Value = dgBDet.Item(15, i).Value Then
                        dgBDet.CurrentCell = dgBDet.Item(0, i)
                    End If
                    ExpColorBat(i)
                Next

            End If


            If dgBDet.Rows.Count = 0 Then
                pnlPDet.Visible = False

            Else
                'MsgBox(dgBDet.Columns(0).Name)
                'dgBDet.Columns(0).Width = 100 'Batch

                'dgBDet.Columns(1).Width = 95 'Exdt
                'dgBDet.Columns(2).Visible = False

                'dgBDet.Columns(3).Width = 70 'Srate
                'dgBDet.Columns(4).Width = 70 'Pack
                'dgBDet.Columns(5).Width = 70 'Stock
                'dgBDet.Columns(6).Width = 150 'Supplier

                'dgBDet.Columns(7).Visible = False

                'dgBDet.Columns(8).Visible = False
                'dgBDet.Columns(9).Width = 68 'Stax
                'dgBDet.Columns(10).Width = 65 'TaxInc
                'dgBDet.Columns(11).Width = 100 'Billno
                'dgBDet.Columns(12).Width = 100 'Billdt

                dgBDet.Columns(13).Visible = False

                dgBDet.Columns(14).Visible = False
                dgBDet.Columns(15).Visible = False
                dgBDet.Columns(16).Visible = False
                dgBDet.Columns(2).Visible = False
                dgBDet.Columns(7).Visible = False
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


                pnlPDet.Visible = True

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
            'If dgInv.CurrentCell.RowIndex = dgInv.Rows.Count - 1 Then dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            'If dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & "" = "" Then
            '    dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            'End If

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





            TabFlag = True

            Select Case dgInv.CurrentCell.ColumnIndex
                Case 0, 13, 22
                    Exit Sub
                Case 12 'batch
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then
                        BatchDeselect()

                    End If

                    '
                    GetBatchDetails()
                    'Calculate()
                    EnableBatchGrid()

                    dgInv.Enabled = False
                    dgBDet.Focus()


                Case 11 'pack
                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then Exit Sub
                    dgInv.Enabled = False
                    GetPacking()
                    If dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & "" <> "" Then
                        CbEditUnit.SelectedValue = Round(Val(dgInv.Item(3, dgInv.CurrentCell.RowIndex).Value & ""), 0)
                        'Else
                        '    CbEditUnit.SelectedValue = 1
                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then


                        GetBatchDetails()
                    End If
                    ShowEditControl(CbEditUnit)
                Case 16
                    dgInv.Enabled = False
                    ShowEditControl(cbEditVat)
                Case 17
                    dgInv.Enabled = False
                    ShowEditControl(CbEditTaxInc)
                Case 8 'qty

                    If Microsoft.VisualBasic.Right(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value & "", 1) = "*" Then
                        BatchDeselect()

                    End If

                    If dgInv.CurrentRow.Index <> dgInv.RowCount - 1 Then

                        GetBatchDetails()
                    Else

                    End If
                    dgInv.Enabled = False
                    ShowEditControl(txtEdit)
                    txtEdit.SelectAll()
                Case 21

                    If dgInv.CurrentCell.Value & "" = "No" Or dgInv.CurrentCell.Value & "" = "" Then
                        dgInv.CurrentCell.Value = "Yes"
                    Else
                        dgInv.CurrentCell.Value = "No"
                    End If
                Case Else

                    dgInv.Enabled = False
                    ShowEditControl(txtEdit)
                    txtEdit.SelectAll()

            End Select
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.FontChanged

    End Sub

    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Select Case dgInv.CurrentCell.ColumnIndex
                    Case 8

                        If Val(txtEdit.Text) <> 0 Then
                            dgInv.Enabled = True
                            dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0")
                            If dgInv.CurrentCell.RowIndex <> dgInv.RowCount - 1 Then
                                txtEdit.Visible = False
                                AdjQty()
                            Else
                                txtEdit.Visible = False
                                dgInv.CurrentCell = dgInv.Item(11, dgInv.CurrentCell.RowIndex)
                                EditGrid()
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If

                    Case 14
                        dgInv.Enabled = True
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0.0000")
                        dgInv.CurrentCell = dgInv.Item(14, dgInv.CurrentCell.RowIndex)
                    Case 15
                        dgInv.Enabled = True
                        dgInv.Item(dgInv.CurrentCell.ColumnIndex, dgInv.CurrentCell.RowIndex).Value = Format(Val(txtEdit.Text), "0.00")
                        dgInv.CurrentCell = dgInv.Item(15, dgInv.CurrentCell.RowIndex)
                    Case 7
                        If txtEdit.Text = "" And UseBarCode Then
                            dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
                            EditGrid()
                            Exit Sub
                        End If
                    Case 1
                        If txtEdit.Text = "" Then
                            dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
                            EditGrid()
                            Exit Sub
                        Else
                            GetBarCode()
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
                    slno = slno - 1
                    ClearRow()
                End If
            End If
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
        If Not pnlprod.Visible Then
            TabFlag = False
            pnlprod.Visible = False
            If dgInv.CurrentRow.Index < dgInv.RowCount - 1 Then
                txtEdit.Visible = False
                dgInv.Enabled = True
                dgInv.Focus()
            End If
        End If
    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged
        Select Case dgInv.CurrentCell.ColumnIndex
            Case 7
                If ProdSelected = True Then Exit Sub
                obj = txtEdit
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
            ProdSelected = False
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgInv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.DoubleClick

        If dgInv.CurrentCell.ColumnIndex = 0 Then
            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            End If
        End If

        If dgInv.CurrentCell.RowIndex = dgInv.Rows.Count - 1 And dgInv.CurrentCell.ColumnIndex > 7 Then
            If UseBarCode Then
                dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
            Else
                dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            End If
        End If


        EditGrid()
    End Sub

    Private Sub dgInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgInv.KeyDown
        'Dim k As Integer
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
                    If Microsoft.VisualBasic.InStr(dgInv.Item(0, dgInv.CurrentCell.RowIndex).Value, "*") <> 0 Then
                        BatchDeselect()
                    Else

                        dgInv.Rows.Remove(dgInv.CurrentRow)
                        Dim i As Integer
                        For i = dgInv.CurrentRow.Index To dgInv.Rows.Count - 2
                            dgInv.Item(0, i).Value = Val(dgInv.Item(0, i).Value) - 1
                            slno = Val(dgInv.Item(0, i).Value)
                        Next








                        Calculate()
                        dgInv.Focus()

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
        txtEdit.Visible = False
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
            dgInv.Enabled = True
            dgInv.Focus()
            Calculate()
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
            dgInv.Enabled = True
            dgInv.Focus()
            Calculate()
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

    Public Sub Calculate()
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
                stk = Val(dgInv.Item(8, n).Value) * -1
                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgInv.Item(14, n).Value)), 2)
                    scst = value * Val(dgInv.Item(15, n).Value) / 100
                    totcst = totcst + scst
                    value = value + scst
                    bdis = 0

                    If IsDBNull(dgInv.Item(20, n).Value) Then dgInv.Item(20, n).Value = False
                    If Not CBool(dgInv.Item(20, n).Value) Then
                        bdis = value * Val(txtDis.Text) / 100
                    End If



                    totbdis = totbdis + bdis
                    value = value - bdis

                    If Val(dgInv.Item(16, n).Value) <> 0 Then

                        If dgInv.Item(17, n).Value = "Yes" Then
                            stax = value * Round(Val(dgInv.Item(16, n).Value) / (100 + Val(dgInv.Item(16, n).Value)), 2)
                            value = value - stax
                        Else
                            stax = value * Round(Val(dgInv.Item(16, n).Value) / 100, 2)
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

            Next

            totvalue = 0

            For i = 0 To 4
                rtaxary(i, 1) = Round(rtaxary(i, 1), 2)
                rptax(i, 1) = Round(rptax(i, 1), 2)
                totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1)
            Next

            tfamt = Round(tfamt, 2)
            totvalue = totvalue + tfamt

            totadj = 0

            totvalue = Val(Format(totvalue, "0.00"))
            totstax = Val(Format(totstax, "0.00"))
            totbdis = Val(Format(totbdis, "0.00"))
            totsdis = Val(Format(totsdis, "0.00"))
            totscst = Val(Format(totscst, "0.00"))





            lblNamt.Text = Format(totvalue, "0.00")

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub txtDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDis.KeyDown
        If e.KeyCode = Keys.Enter Then
            'txtDed.Text = Format(txtDed.Text, "0.00")

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
        dgInv.CurrentCell.Selected = False
    End Sub

    Private Sub dgInv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInv.GotFocus
        dgInv.CurrentCell.Selected = True
    End Sub



    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        If dgInv.RowCount > 1 Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If

        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click

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


    Private Sub dgBDet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.LostFocus
        'dgBDet.CurrentRow.Selected = False
    End Sub


























    Private Sub DisableBatchGrid()
        dgBDet.Enabled = False
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

                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub











    Private Sub DgSales_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSales.CellDoubleClick
        If DgSales.CurrentCell Is Nothing Then Exit Sub
        If DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "Yes" Then

            DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "No"
            For I = 0 To DgSales.ColumnCount - 1
                DgSales.Item(I, DgSales.CurrentCell.RowIndex).Style.ForeColor = Color.Black

            Next

        Else
            DgSales.Item(0, DgSales.CurrentCell.RowIndex).Value = "Yes"
            For I = 0 To DgSales.ColumnCount - 1
                DgSales.Item(I, DgSales.CurrentCell.RowIndex).Style.ForeColor = Color.Red

            Next

        End If
    End Sub

    Private Sub ComOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comok.Click


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
                RtnSales.Rows.Add()
            End If
        Next
        Calculate()
        pnlsales.Visible = False
        dgInv.Enabled = True
        dgInv.CurrentCell = dgInv.Item(7, dgInv.RowCount - 1)
        dgInv.Focus()
        'panInvoice.Enabled = True

    End Sub



    Private Sub panInvoice_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panInvoice.Paint

    End Sub

    Private Sub dgInv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInv.CellContentClick

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        SalesReturn()


    End Sub


    Private Sub SalesReturn()
        EditSales.Text = "Sales Return"
        EditSales.txtSalNo.Focus()
        EditSales.ShowDialog()

        If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        GetSales(EditSales.txtSalNo.Text, EditSales.dtpf.Value.Date, EditSales.dtpt.Value.Date)

    End Sub

    Private Sub GetSales(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)

        Dim dataredr As OleDb.OleDbDataReader
        'Dim dataredrinv As OleDb.OleDbDataReader
        Try
            Dim DS As New DataSet
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            Dim tmpcode As String
            Dim i As Integer

            EditFlag = True
            i = 0
            slno = 0
            tmpcode = ""

            DgSales.Rows.Clear()




            cmd.CommandType = CommandType.Text

            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName from invtotal," & _
                     "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                     "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                     "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                     " and InvDetails.Invdt>=convert(datetime,'" & dtf & "') " & _
                     " and InvDetails.Invdt<=convert(datetime,'" & dtt & "') and  " & _
                     " (invtotal.type='21'  or invtotal.type='22') order by seq"

            dataredr = cmd.ExecuteReader()
            cmd.Parameters.Clear()
            If dataredr.HasRows Then

                While dataredr.Read()

                    DgSales.Rows.Add()
                    DgSales.Item(0, DgSales.Rows.Count - 1).Value = "No" 'dataredr.Item("prdcode")
                    DgSales.Item(1, DgSales.Rows.Count - 1).Value = dataredr.Item("Unit") 'dataredr.Item("prdcode")
                    DgSales.Item(2, DgSales.Rows.Count - 1).Value = dataredr.Item("prdcode")
                    DgSales.Item(3, DgSales.Rows.Count - 1).Value = dataredr.Item("batchid")
                    DgSales.Item(4, DgSales.Rows.Count - 1).Value = dataredr.Item("PrdName")
                    DgSales.Item(5, DgSales.Rows.Count - 1).Value = Round(dataredr.Item("Qty") / dataredr.Item("unit"), 2, MidpointRounding.AwayFromZero)
                    DgSales.Item(6, DgSales.Rows.Count - 1).Value = dataredr.Item("Pack") & ""
                    DgSales.Item(7, DgSales.Rows.Count - 1).Value = dataredr.Item("Batch") & ""
                    DgSales.Item(8, DgSales.Rows.Count - 1).Value = dataredr.Item("Exdt")


                    DgSales.Item(9, DgSales.Rows.Count - 1).Value = Round(dataredr.Item("srate") * dataredr.Item("unit"), 4, MidpointRounding.AwayFromZero)
                    DgSales.Item(10, DgSales.Rows.Count - 1).Value = Round(dataredr.Item("st"), 2)
                    If (dataredr.Item("TaxInc")) = 0 Then
                        DgSales.Item(11, DgSales.Rows.Count - 1).Value = "No"
                    Else
                        DgSales.Item(11, DgSales.Rows.Count - 1).Value = "Yes"
                    End If
                    DgSales.Item(12, DgSales.Rows.Count - 1).Value = Round(dataredr.Item("cst"), 2)



                    DgSales.Update()


                End While
            End If
            pnlsales.Visible = True
            dataredr.Close()


            Calculate()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgBDet_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBDet.CellContentClick

    End Sub

    Private Sub DgProdSer_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub
End Class

