Imports System
Imports System.Globalization
Imports System.Math
Imports PrePrintDirect_Class
Imports PrePrintDirectClass

Public Class SalesRtn
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
    Private UseBarCode As Boolean
    Private EditVouNo, EditCusCode As Long
    Private UseSalesmanPass As Boolean
    Private editworkshift As Integer


    Private Sub Sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' If e.KeyCode = Keys.Enter Then
        'If Not TabFlag Then System.Windows.Forms.SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.LightGreen 'RGB(192, 255, 192) 'Color.Wheat
        ToolStrip.Renderer = renderer
    End Sub


    Private Sub cbType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.GotFocus
        'cbType.SelectAll()
    End Sub

    Private Sub cbType_SleectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.SelectedValueChanged
        GetSeries()



    End Sub
    Private Sub GetSeries()
        Dim cmd As New OleDb.OleDbCommand
        Dim DR As OleDb.OleDbDataReader
        If cbType.SelectedValue = Nothing Then Exit Sub
        cmd.Connection = Conn
        Try

            If EditFlag Then
                If cbType.SelectedValue = EditType Then
                    lblno.Text = EditNum
                End If
            Else
                cmd.CommandText = "select slno from serialnum where type=" & cbType.SelectedValue
                lblno.Text = cmd.ExecuteScalar + 1
            End If

            cmd.CommandText = "select workshift from settings"
            WorkShift = cmd.ExecuteScalar

            cmd.CommandText = "select CreditEntry,POSTAC from serialnum where type=" & cbType.SelectedValue
            DR = cmd.ExecuteReader
            If DR.HasRows Then
                DR.Read()
                If DR("CreditEntry") Then
                    cbCus.Visible = True
                    lblCus.Visible = True
                    CreditPost = True
                Else
                    CreditPost = False
                    cbCus.Visible = False
                    lblCus.Visible = False
                End If
                If DR("POSTAC") Then
                    PostAc = True
                Else
                    PostAc = False
                    cbCus.Visible = False
                    lblCus.Visible = False
                End If
            End If



            'cbSal.Enabled = True
            cbPat.Enabled = True
            cbDoc.Enabled = True


            txtDis.Enabled = True
            txtDed.Enabled = True
            txtAdd.Enabled = True

            'SUNDRY
            If cbType.SelectedValue = 36 Or cbType.SelectedValue = 33 Then
                lblCus.Visible = False
                cbCus.Visible = False
                'cbSal.Enabled = False
                cbPat.Enabled = False
                cbDoc.Enabled = False


                txtDis.Enabled = False
                txtDed.Enabled = False
                txtAdd.Enabled = False

                txtDis.Text = "0.00"

                'txtRecv.BackColor = Color.White
                'txtDis.BackColor = Color.White
                'txtDed.BackColor = Color.White
                'txtAdd.BackColor = Color.White

                'cbDoc.BackColor = Color.White
                'cbSal.BackColor = Color.White
                'cbPat.BackColor = Color.White


                'OTC SALES



            ElseIf cbType.SelectedValue = 35 Then
                lblCus.Visible = False

                ' cbSal.Enabled = True
                cbPat.Enabled = True
                cbDoc.Enabled = True
                txtDis.Enabled = True
                txtDed.Enabled = True
                txtAdd.Enabled = True


                'TRANSFER
            ElseIf cbType.SelectedValue = 34 Then
                lblCus.Visible = True
                cbCus.Visible = True
                'cbSal.Enabled = False
                cbPat.Enabled = False
                cbDoc.Enabled = False


                txtDis.Enabled = False
                txtDed.Enabled = False
                txtAdd.Enabled = False



            End If
            Calculate()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub ClearForm(Optional ByVal flg As Boolean = False)
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim I As Integer
        Dim cmd As New OleDb.OleDbCommand

        Try
            'Dim i As Integer
            editworkshift = 1
            curunit = 0
            cmd.Connection = Conn
            If Not flg Then
                cmd.CommandText = "select Docname,Doccode from Doctor order by docname "
                DA.SelectCommand = cmd
                DA.Fill(DS, "Doctor")
                cbDoc.DisplayMember = "DocName"
                cbDoc.DataSource = DS.Tables("Doctor")
                cbDoc.ValueMember = "DocCode"
                cbDoc.SelectedIndex = -1
                cbDoc.Text = ""
                cmd.CommandText = "select Patname,Patcode from Patient order by Patname"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Patient")
                cbPat.DisplayMember = "PatName"
                ' cbPat.ValueMember = "Patcode"

                cbPat.DataSource = DS.Tables("Patient")


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


                cmd.CommandText = "select Type,Descr,seq from SerialNum where type>30 and type<40 order by seq"
                DA.SelectCommand = cmd
                DA.Fill(DS, "SerialNum")
                cbType.DisplayMember = "Descr"
                cbType.ValueMember = "Type"
                cbType.DataSource = DS.Tables("SerialNum")
            End If
            EditVouNo = 0
            TaxTbl = New DataTable
            Sales = New DataTable
            dgInv.DataSource = Nothing
            Sales.TableName = "Sales"
            lbldt.Text = SysDt
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
21:         Sales.Columns.Add("nodisc")
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


            ' dgInv.Columns(1).Visible = False
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
            cmd.CommandText = "select usebarcode  from settings "
            UseBarCode = cmd.ExecuteScalar
            dgInv.Columns(1).Visible = UseBarCode

            cmd.CommandText = "select UseSalesmanPass from settings "
            UseSalesmanPass = cmd.ExecuteScalar
            If UseSalesmanPass Then
                txtsmcode.Text = ""
                cmd.CommandText = "select salcode,Salname from Salesman WHERE salcode<>0 ORDER BY Salname "
                cbSal.Enabled = False
            Else
                cmd.CommandText = "select salcode,Salname from Salesman  ORDER BY Salname "
                cbSal.Enabled = True
            End If

            txtsmcode.Visible = UseSalesmanPass
            ' cbSal.Enabled = Not UseSalesmanPass



            DA.SelectCommand = cmd
            DA.Fill(DS, "Salesman")
            cbSal.DisplayMember = "SalName"
            cbSal.ValueMember = "Salcode"
            cbSal.DataSource = DS.Tables("Salesman")



            cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' order by seq"
            DA.SelectCommand = cmd
            DA.Fill(TaxTbl)

            cbEditVat.DataSource = TaxTbl
            cbEditVat.DisplayMember = "taxper"

            dgBDet.Columns.Clear()

            cmd.CommandText = "select taxper,accode,surch from tax where flag='1' order by seq"
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

            cmd.CommandText = "select taxper,accode,surch from tax where flag='2' order by seq"
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

            If Not flg Then
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
            End If
            txtEdit.Visible = False
            CbEditUnit.Visible = False
            cbEditVat.Visible = False
            pnlPDet.Visible = False
            pnlprod.Visible = False
            tsbSave.Enabled = False
            cbCus.Enabled = True
            cbType.Enabled = True
            EditFlag = False
            cbType.Focus()

            cbSal.SelectedValue = 0
            lblTamt.Text = "0.00"
            lblNamt.Text = "0.00"
            txtDed.Text = "0.00"
            txtAdd.Text = "0.00"
            txtDis.Text = "0.00"
            cbCus.SelectedValue = 0
            cbCus.Text = ""
            cbPat.Text = ""
            cbDoc.Text = ""
            ckbPntwin.Checked = True
            'lblCus.Visible = False
            'cbCus.Visible = False
            slno = 0
            If Not flg Then GetSeries()
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
    Private Sub InvDetail(Optional ByVal cd As String = "", Optional ByVal pc As String = "")

        Dim dataredr As OleDb.OleDbDataReader
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim tmpvar As Double

        cmd.Connection = Conn
        Try

            tsbSave.Enabled = False
            'Check for the stock if present
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

                If dgInv.CurrentCell.RowIndex = dgInv.RowCount - 1 Then '
                    tsbSave.Enabled = False
                Else
                    tsbSave.Enabled = True
                End If

                txtEdit.Focus()
                txtEdit.Text = ""
                Exit Sub
            End If
            dataredr.Close()
            tsbSave.Enabled = False
            'Check for the stock if present

            'If tmpvar <> 0 Then
            txtEdit.SelectionStart = Len(txtEdit.Text)
            dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value = cd '(DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            dgInv.Item(7, dgInv.CurrentCell.RowIndex).Value = pc '(DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value)


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
            'Batch.Stock<>0 and " & _
            '            "((Batch.Stock+COALESCE(select sum(qty) from invdetails where invdetails.type='" & cbType.SelectedValue & _
            '           "' and invno=22 and invdt= convert(datetime,'" & SysDt & "') and invdetails.batchid=batch.batchid))- COALESCE((SELECT SUM(tqty) FROM OutGo WHERE (Batchid = Batch.BatchId)),0))<>0 and


            cmd.CommandText = "select Batch.Batch,Batch.ExDt,Batch.PRate,Batch.SRate,Batch.Pack," & _
               "Batch.Stock AS STOCK,AcMaster.AcName as [Supplier],Batch.Profit,Batch.SCST,Batch.Stax,Batch.TaxInc," & _
               "Batch.BillNo,Batch.BillDt,Batch.PCST,Batch.Ptax,Batch.BatchId," & _
               "product.case1,isnull(product.nodisc,0) as nodisc FROM Batch INNER JOIN " & _
               "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN " & _
               "Acmaster ON Batch.Supcode = Acmaster.AcCode " & _
               " WHERE  Batch.PrdCode = """ & dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & """   order by BatchId desc"




            'dgBDet.Rows.Clear()
            'dgBDet.Rows.Add()

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
            'dgBDet.CurrentRow.Selected = False

            'If Not NoStockBill Then
            '    MsgBox("Insufficient Stock ..!" & Chr(13) & "Stock available = " & stkext & " " & Batchgrid.TextMatrix(Batchgrid.Row, 5))
            '    Billgrid.Col = 3
            '    Billgrid_DblClick()
            'Else
            '    frm2.Visible = True
            '    Batchgrid.SetFocus()
            '    If Batchdata.Recordset.RecordCount = 0 Then txtqty = Val(Billgrid.TextMatrix(Billgrid.Row, 3)) * Val(Billgrid.TextMatrix(Billgrid.Row, 13)) : txtqty.SetFocus()
            'End If

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
            dgInv.Enabled = False
            cntrol.Visible = True
            cntrol.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub EditGrid()
        Try
            'If dgInv.CurrentCell.RowIndex = dgInv.Rows.Count - 1 Then dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
            If dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value & "" = "" Then

                'If UseBarCode Then
                '    dgInv.CurrentCell = dgInv.Item(1, dgInv.CurrentCell.RowIndex)
                'Else
                ' dgInv.CurrentCell = dgInv.Item(7, dgInv.CurrentCell.RowIndex)
                'End If

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
        'If Val(dgInv.Item(8, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(9, dgInv.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgInv.Item(10, dgInv.CurrentCell.RowIndex).Value & "") < 0 Then
        ' GetProduct(dgInv.Item(1, dgInv.CurrentCell.RowIndex).Value)
        ' Else

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
        'End If
    End Sub

    Private Sub dgInv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgInv.KeyDown
        'Dim k As Integer
        Try
            If e.KeyCode = Keys.Enter Then
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



                        'While i <= dgInv.Rows.Count - 1
                        '    If dgInv.Item(0, i).Value & "" = TMPSL Then

                        '        dgInv.Rows.Remove(dgInv.Rows(i))

                        '    Else

                        '        If vi = 1 Then
                        '            If InStr(dgInv.Item(0, i).Value & "", "*") <> 0 Then
                        '                vii = Val(dgInv.Item(0, i).Value & "")
                        '                If vii > 0 Then
                        '                    dgInv.Item(0, i).Value = vii - 1 & "*"
                        '                    slno = vii - 1
                        '                End If

                        '            Else
                        '                vii = Val(dgInv.Item(0, i).Value & "")
                        '                If vii > 0 Then
                        '                    dgInv.Item(0, i).Value = vii - 1
                        '                    slno = vii - 1
                        '                End If

                        '                vii = vii + 1

                        '            End If
                        '        End If

                        '        i = i + 1
                        '    End If
                        'End While













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

    Private Sub Calculate()
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
                stk = Val(dgInv.Item(8, n).Value)
                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgInv.Item(14, n).Value)), 2)
                    scst = value * Val(dgInv.Item(15, n).Value) / 100
                    totcst = totcst + scst
                    value = value + scst
                    bdis = 0
                    ' If IsDBNull(dgInv.Item(20, n).Value) Then dgInv.Item(20, n).Value = False
                    'If Not CBool(dgInv.Item(20, n).Value) Then
                    bdis = value * Val(txtDis.Text) / 100
                    'End If

                    totbdis = totbdis + bdis
                    value = value - bdis

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

                    totstax = totstax + stax
                    value = value + stax
                    dgInv.Item(22, n).Value = Format(value, "0.00")
                    totvalue = totvalue + value
                End If

            Next

            totvalue = 0
            Dim RAMT, TX As Double
            For i = 0 To 4

                RAMT = Round(rtaxary(i, 1), 2) '+ Round(rptax(i, 1), 2)
                TX = Round(RAMT * rtaxary(i, 0) / (rtaxary(i, 0) + 100), 2)
                RAMT = Round(RAMT - TX, 2)
                rtaxary(i, 1) = RAMT 'Round(rtaxary(i, 1), 2)
                rptax(i, 1) = TX ''Round(rptax(i, 1), 2)
                totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1)

                'rtaxary(i, 1) = Round(rtaxary(i, 1), 2)
                'rptax(i, 1) = Round(rptax(i, 1), 2)
                'totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1)
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
        If e.KeyCode = Keys.Enter Then
            'txtDed.Text = Format(txtDed.Text, "0.00")
            txtDed.Focus()
            txtDed.SelectAll()
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

    Private Sub tsbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        BillCopy.txtNof.Focus()
        BillCopy.Text = "Sales Return Copy"
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
        Dim dr As OleDb.OleDbDataReader
        Dim rt
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
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
            If dt.Rows(0).Item("BigPrintForCredit") And BillCopy.cbType.SelectedValue = "32" Then

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
        Me.Cursor = Cursors.Default

    End Sub

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

        If EditFlag Then
            If CheckUserLocked("Edit Sales Return", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub
        End If

        If txtsmcode.Visible Then
            If cbSal.SelectedValue = 0 Then
                txtsmcode.Focus()
                txtsmcode.SelectAll()
                Exit Sub
            End If
        End If

        If cbType.SelectedValue <> "24" Then

            If Val(lblNamt.Text) <= ComputerRights.SaAmtForDisc And Val(txtDis.Text) <> 0 And ComputerRights.SaAmtForDisc <> 0 Then
                MsgBox("Amount bellow " & ComputerRights.SaAmtForDisc & "/-. discount not allowed.")
                txtDis.Text = "0.00"
                Exit Sub
            End If

            If Val(lblNamt.Text) <= LoginRights.SaAmtForDisc And Val(txtDis.Text) <> 0 And LoginRights.SaAmtForDisc <> 0 Then
                MsgBox("Amount bellow " & LoginRights.SaAmtForDisc & "/-. discount not allowed.")
                txtDis.Text = "0.00"
                Exit Sub
            End If

        End If


        If cbType.SelectedValue <> "34" Then

            If Val(txtDis.Text) > ComputerRights.SaDiscLmt And ComputerRights.SaDiscLmt <> 0 Then
                MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                txtDis.Text = "0.00"
                Exit Sub
            End If

            If Val(txtDis.Text) > LoginRights.SaDiscLmt And LoginRights.SaDiscLmt <> 0 Then
                MsgBox("Discount above " & ComputerRights.SaDiscLmt & "% not allowed.")
                txtDis.Text = "0.00"
                Exit Sub
            End If

        End If


        If cbType.SelectedValue <> "34" Then



            If Val(txtAdd.Text) > LoginRights.SaAddLmt And LoginRights.SaAddLmt <> 0 Then
                MsgBox("Other addition amount above " & LoginRights.SaAddLmt & " not allowed.")

                Exit Sub
            End If

            If Val(txtAdd.Text) > ComputerRights.SaAddLmt And ComputerRights.SaAddLmt <> 0 Then
                MsgBox("Other addition amount above " & LoginRights.SaAddLmt & " not allowed.")

                Exit Sub
            End If
        End If


        If cbType.SelectedValue <> "34" Then

            If Abs(Val(txtDed.Text)) > ComputerRights.SaLessLmt And ComputerRights.SaLessLmt <> 0 Then
                MsgBox("Other deduction amount above " & ComputerRights.SaLessLmt & " not allowed.")

                Exit Sub
            End If

            If Abs(Val(txtDed.Text)) > LoginRights.SaLessLmt And LoginRights.SaLessLmt <> 0 Then
                MsgBox("Other deduction amount above " & ComputerRights.SaLessLmt & " not allowed.")

                Exit Sub
            End If

        End If


        If cbType.SelectedValue = "32" And cbCus.SelectedValue = 0 Then

            MsgBox("Select a customer..", vbInformation)
            cbCus.Focus()
            Exit Sub
        End If
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter

        Try
            Me.Cursor = Cursors.WaitCursor

            If save() <> 0 Then
                cmd.Connection = Conn
                cmd.CommandText = "select printline,preprintline,invmsg,invpreprint,BigPrintForCredit,printlinebig from settings"
                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows(0).Item("invpreprint") Then
                    'rpt = New PrePrintDirect.PrePrintDirect
                    rpt = New PrePrintDirect
                    rpt.PageLines = dt.Rows(0).Item("preprintline")
                Else
                    rpt = New PrintDirectClass.PrintDirect
                    rpt.PageLines = dt.Rows(0).Item("printline")
                    If dt.Rows(0).Item("BigPrintForCredit") And cbType.SelectedValue = "32" Then

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
                If ckbPntwin.Checked Then
                    rpt.PrintDestination = PrintOutput.ToWindow
                Else
                    rpt.PrintDestination = PrintOutput.ToPrinter
                End If
                lblB.Text = cbType.Text & " " & InvNum & " Rs. " & lblNamt.Text
                ClearForm()
                rpt.PrintInvoice(Conn, PrintPreview, Main, PrintPreview.TB)


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
                    dataredr = cmd.ExecuteReader()
                    dataredr.Read()
                    InvNum = dataredr.Item("slno")
                    InvDt = SysDt
                    dataredr.Close()

                End If

            Else
                cmd.CommandText = "update serialnum set slno=slno+1 where type=" & cbType.SelectedValue
                cmd.ExecuteNonQuery()

                cmd.CommandText = "select slno from serialnum where type=" & cbType.SelectedValue
                dataredr = cmd.ExecuteReader()
                dataredr.Read()
                InvNum = dataredr.Item("slno")
                InvDt = SysDt
                dataredr.Close()
            End If

            sql = "insert into invtotal (Invno,Invdt,type,CusCode,Name," & _
                  "BDis,BDisAmt,TFAmt,Amt1,Tax1,Amt2,Tax2,Amt3,Tax3,Amt4,Tax4,Amt5,Tax5,NetAmt,AddAmt," & _
                  "Flag,DedAmt,DocName,cardno,cancelled,edited,workshift,sman,unacamt,pl,docadr) Values(" & InvNum & ",'" & InvDt & "'," & _
                  Val(cbType.SelectedValue) & "," & Val(cbCus.SelectedValue) & ",""" & cbPat.Text & _
                  """," & Val(txtDis.Text) & "," & totbdis & "," & tfamt & "," & Val(rtaxary(0, 1)) & "," & Val(rptax(0, 1)) & _
                  "," & Val(rtaxary(1, 1)) & "," & Val(rptax(1, 1)) & "," & Val(rtaxary(2, 1)) & "," & Val(rptax(2, 1)) & _
                  "," & Val(rtaxary(3, 1)) & "," & Val(rptax(3, 1)) & "," & Val(rtaxary(4, 1)) & "," & Val(rptax(4, 1)) & _
                  "," & Val(lblNamt.Text) & "," & Val(txtAdd.Text) & _
                  ",''," & Val(txtDed.Text) & ",""" & cbDoc.Text & """,'" & txtccard.Text & "',0," & IIf(EditFlag, 1, 0) & "," & _
                  IIf(EditFlag, editworkshift, WorkShift) & "," & Val(cbSal.SelectedValue & "") & ",0,""" & txtplace.Text & """,""" & txtDoc.Text & """)"

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
                      "TaxInc,BrkRtn,cancelled,edited) values(" & InvNum & ",'" & InvDt & "'," & Val(cbType.SelectedValue) & _
                      ",""" & dgInv.Item(1, i).Value & """,""" & dgInv.Item(12, i).Value & _
                      """," & Val(dgInv.Item(2, i).Value) & "," & sqlexdt & _
                      ",""" & dgInv.Item(11, i).Value & """," & (Val(dgInv.Item(8, i).Value) * Val(dgInv.Item(3, i).Value)) & _
                      "," & Format(Val(dgInv.Item(14, i).Value) / Val(dgInv.Item(3, i).Value), "0.0000") & ",""" & Val(dgInv.Item(16, i).Value) & _
                      """," & dgInv.Item(15, i).Value & "," & Val(dgInv.Item(3, i).Value) & "," & Val(dgInv.Item(22, i).Value) & _
                      "," & i & "," & Val(cbSal.SelectedValue & "") & _
                      "," & IIf(dgInv.Item(20, i).Value, 0, Val(txtDis.Text)) & ",0," & IIf(dgInv.Item(17, i).Value = "Yes", 1, 0) & _
                      "," & IIf(dgInv.Item(21, i).Value & "" = "Yes", 1, 0) & ",0," & IIf(EditFlag, 1, 0) & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                sql = "update batch set stock = stock + " & _
                      Val(dgInv.Item(3, i).Value) * (Val(dgInv.Item(8, i).Value) + Val(dgInv.Item(9, i).Value & "") + Val(dgInv.Item(10, i).Value & "")) & _
                      " where batchid = " & Val(dgInv.Item(2, i).Value)
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

            Next i
            If PostAc Then
                WriteAcc(cbType.SelectedValue, InvNum, InvDt)
            End If

            Trans.Commit()
            Trn = False
            save = InvNum
        Catch er As Exception
            save = 0
            If Trn Then Trans.Rollback()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
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

        If Not EditFlag Or EditVouNo = 0 Then
            cmd.CommandText = "update serialnum  set slno=slno+1 where type=96"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select slno from serialnum where type=96"
            vouno = cmd.ExecuteScalar
        Else
            vouno = EditVouNo
            'InvDt = upddt
        End If

        cmd.CommandText = "select sacacode from settings "
        cashcode = cmd.ExecuteScalar

        cmd.CommandText = "select sacoincode from settings "
        coincode = cmd.ExecuteScalar



        If CreditPost Or updtype = "32" Or updtype = "37" Then

            If updtype = "37" Then
                cmd.CommandText = "Select accode from tax where flag='50' " & _
                     " and  seq=1"
                pcode = Val(cmd.ExecuteScalar & "")
                BillType = 2
            Else
                BillType = 2
                pcode = Val(cbCus.SelectedValue)
            End If

        Else
            BillType = 1
            pcode = cashcode
        End If

        If EditFlag Then
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                    "Amt,BillType,BillNo,Seq,InvCode,pamt) values('" & _
                    upddt & "','Sr'," & vouno & "," & _
                    pcode & ", " & Val(lblNamt.Text) * -1 & "," & BillType & "," & _
                    updno & "," & _
                    "1,'" & updtype & updno & "',  COALESCE((select sum(amt) from adjdetails where " & _
                        " billtrntype='Sr' and  billvouno=" & vouno & " and billtrndt=convert(datetime,'" & upddt & "'  )),0))"
            cmd.ExecuteNonQuery()
        Else
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                   "Amt,BillType,BillNo,Seq,InvCode) values('" & _
                   upddt & "','Sr'," & vouno & "," & _
                   pcode & ", " & Val(lblNamt.Text) * -1 & "," & BillType & "," & _
                   updno & "," & _
                   "1,'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()

        End If


        seq = 1
        For i = 1 To 5
            If rtaxary(i - 1, 1) <> 0 Then
                'writting taxable
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='1' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar

                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                      "AcCode,  Amt,BillType,BillNo,Seq,InvCode) " & _
                      "values('" & upddt & "','Sr'," & _
                      vouno & "," & CD & "," & _
                      Val(Format((rtaxary(i - 1, 1)), "0.00")) & "," & BillType & "," & _
                      updno & "," & seq & ",'" & updtype & updno & "')"
                cmd.ExecuteNonQuery()

                'writing tax
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='2' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar

                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                   "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                   "values('" & upddt & "','Sr'," & _
                   vouno & "," & CD & ", " & _
                   Val(Format((rptax(i - 1, 1)), "0.00")) & "," & BillType & "," & _
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
                "values('" & upddt & "','Sr'," & _
                vouno & "," & CD & "," & _
                (tfamt) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"

            cmd.ExecuteNonQuery()
        End If

        TADJ = (Val(txtAdd.Text) - Val(txtDed.Text))

        If TADJ <> 0 Then
            seq = seq + 1
            cmd.CommandText = "Select accode from tax where flag='6' " & _
                    " and  seq=1"
            CD = cmd.ExecuteScalar
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                "values('" & upddt & "','Sr'," & _
                vouno & "," & CD & "," & _
                (TADJ) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()

        End If
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click

        Try
            If EditFlag Then
                MsgBox("Can't cancell the sales return while Editing.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If dgInv.RowCount > 1 Then
                MsgBox("Entries found. Clear the entries before editing.", vbInformation)
                Exit Sub
            End If

            EditSales.txtSalNo.Focus()
            EditSales.Text = "Editing Sales Return"
            EditSales.ShowDialog()

            If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            cmd.Connection = Conn
            cmd.CommandText = "select InvDetails.* from InvDetails where InvDetails.InvNo=" & EditSales.txtSalNo.Text & _
                    " and InvDetails.Invdt>=convert(datetime,'" & EditSales.dtpf.Value.Date & "') and  " & _
                    "InvDetails.Invdt<=convert(datetime,'" & EditSales.dtpt.Value.Date & "') and  " & _
                    " InvDetails.type='" & cbType.SelectedValue & "'  order by seq"

            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                If dr("cancelled") Then
                    MsgBox("Sales Return already cancelled.", MsgBoxStyle.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                MsgBox("Sales Return not found.", MsgBoxStyle.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            EditingSales(EditSales.txtSalNo.Text, dr("invdt"), dr("invdt"))
            dr.Close()
            EditSales.Dispose()

        Catch er As Exception
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EditingSales(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)

        'Dim dataredrinv As OleDb.OleDbDataReader
        Try
            Dim DS As New DataSet
            Dim dtab As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            Dim tmpcode As String


            EditFlag = True

            slno = 0
            tmpcode = ""

            Sales.Rows.Clear()
            Sales.Rows.Add()
            EditNum = 0
            EditType = 0
            EditDt = Nothing
            EditVouNo = 0



            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName,isnull(product.nodisc,0) as nodisc from invtotal," & _
                     "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                     "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                     "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                     " and InvDetails.Invdt>=convert(datetime,'" & dtf & "') and  " & _
                     " InvDetails.Invdt<=convert(datetime,'" & dtt & "') and  " & _
                     " invtotal.type='" & cbType.SelectedValue & "' order by InvDetails.invdt, seq"

            da.SelectCommand = cmd
            da.Fill(dtab)



            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName,isnull(product.nodisc,0) as nodisc from invtotal," & _
                   "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                   "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                   "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                   " and InvDetails.Invdt>=convert(datetime,'" & dtab.Rows(0).Item("invdt") & "') and  " & _
                   " InvDetails.Invdt<=convert(datetime,'" & dtab.Rows(0).Item("invdt") & "') and  " & _
                   " invtotal.type='" & cbType.SelectedValue & "' order by seq"

            dtab.Clear()
            dtab.Rows.Clear()

            da.Fill(dtab)
            If dtab.Rows.Count > 0 Then
                For i As Long = 0 To dtab.Rows.Count - 1
                    If i = 0 Then
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
                        txtccard.Text = Val(dtab.Rows(i).Item("cardamt") & "")
                        txtccard.Text = dtab.Rows(i).Item("Cardno")
                        cbccard.Text = dtab.Rows(i).Item("paydet") & ""
                        editworkshift = dtab.Rows(i).Item("workshift")
                        cbCus.SelectedValue = Val(dtab.Rows(i).Item("cuscode") & "")
                        lbldt.Text = EditDt
                    End If




                    slno = slno + 1
                    dgInv.Item(0, dgInv.Rows.Count - 1).Value = slno

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
                    dgInv.Item(20, dgInv.Rows.Count - 1).Value = dtab.Rows(i).Item("nodisc")
                    If (dtab.Rows(i).Item("TaxInc")) = 0 Then
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "No"
                    Else
                        dgInv.Item(17, dgInv.Rows.Count - 1).Value = "Yes"
                    End If

                    'lblno.Text = dataredr("InvNo")
                    'cbPat.Text = dataredr("Name")

                    'lblNamt.Text = dataredr("NetAmt")
                    'lblTamt.Text = dataredr("TfAmt")
                    'txtDis.Text = dataredr("BDis")
                    'txtDed.Text = dataredr("DedAmt")
                    'txtAdd.Text = dataredr("AddAmt")
                    'cbSal.Text = dataredr("Sman")
                    'cbDoc.Text = dataredr("Docname")
                    'cbType.SelectedValue = dataredr("Type")
                    '' cbcus.Text =dataredr("
                    'EditNum = dataredr("INVNO")
                    'EditType = dataredr("TYPE")
                    'EditDt = dataredr("Invdt")
                    dgInv.Update()
                    Sales.Rows.Add()
                Next
            Else
                MsgBox("Sales Return bill not found.", MsgBoxStyle.Information)
                Exit Sub
            End If





            cmd.CommandText = "select pamt,vouno from ledger where  trntype='Sr' and " & _
               "trndate=convert(datetime,'" & EditDt & "') and " & _
               "InvCode='" & EditType & EditNum & "' and  seq=1"

            dtab.Clear()
            da.SelectCommand = cmd
            da.Fill(dtab)

            EditVouNo = dtab.Rows(0).Item("vouno")

            If Val(dtab.Rows(0).Item("pamt") & "") <> 0 Then
                cbCus.Enabled = False
                cbType.Enabled = False
            Else
                cbCus.Enabled = True
                cbType.Enabled = True
            End If

            tsbSave.Enabled = True
            Calculate()
            dgInv.Enabled = True

        Catch er As Exception
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
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


            i = 0
            slno = 0
            tmpcode = ""

            DgSales.Rows.Clear()




            cmd.CommandType = CommandType.Text

            cmd.CommandText = "select invtotal.*,InvDetails.*,Product.PrdName,product.nodisc from invtotal," & _
                     "InvDetails,Product where Product.PrdCode=InvDetails.prdcode and " & _
                     "invtotal.InvNo=InvDetails.InvNo and invtotal.Invdt=InvDetails.Invdt and " & _
                     "invdetails.type=invtotal.type and InvDetails.InvNo=" & no & _
                     " and InvDetails.Invdt>=convert(datetime,'" & dtf & "') " & _
                     " and InvDetails.Invdt<=convert(datetime,'" & dtt & "') and  " & _
                     " invtotal.type='2" & Microsoft.VisualBasic.Right(cbType.SelectedValue, 1) & "' order by seq"

            dataredr = cmd.ExecuteReader()
            cmd.Parameters.Clear()
            If dataredr.HasRows Then

                While dataredr.Read()

                    DgSales.Rows.Add()
                    If DgSales.Rows.Count - 1 = 0 Then
                        cbPat.Text = dataredr.Item("name") & ""
                        cbDoc.Text = dataredr.Item("docname") & ""
                        txtplace.Text = dataredr.Item("pl") & ""
                        txtDoc.Text = dataredr.Item("docadr") & ""
                    End If
                    DgSales.Item(0, DgSales.Rows.Count - 1).Value = "No" 'dataredr.Item("prdcode")
                    DgSales.Item(1, DgSales.Rows.Count - 1).Value = dataredr.Item("Unit") 'dataredr.Item("prdcode")
                    DgSales.Item(2, DgSales.Rows.Count - 1).Value = dataredr.Item("prdcode")
                    DgSales.Item(3, DgSales.Rows.Count - 1).Value = dataredr.Item("batchid")
                    DgSales.Item(4, DgSales.Rows.Count - 1).Value = dataredr.Item("PrdName")
                    DgSales.Item(5, DgSales.Rows.Count - 1).Value = Round(dataredr.Item("Qty") / dataredr.Item("unit"), 2, MidpointRounding.AwayFromZero)
                    DgSales.Item(6, DgSales.Rows.Count - 1).Value = dataredr.Item("Pack") & ""
                    DgSales.Item(7, DgSales.Rows.Count - 1).Value = dataredr.Item("Batch") & ""
                    DgSales.Item(8, DgSales.Rows.Count - 1).Value = dataredr.Item("Exdt")
                    DgSales.Rows(DgSales.Rows.Count - 1).Cells("nodisc").Value = dataredr.Item("nodisc")

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

            tsbSave.Enabled = True
            Calculate()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged

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





    Private Sub cbType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SalesReturn()

        End If

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

    Private Sub InvEditChecking(ByVal updtype As Long, ByVal updno As Long, ByVal upddt As Date, ByVal updflag As String)

        Dim dataredr As OleDb.OleDbDataReader

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim edtd As Integer


        cmd.Connection = Conn

        cmd1.Transaction = Trans
        cmd.Transaction = Trans

        cmd1.Connection = Conn

        cmd.CommandText = "select InvDetails.* from InvDetails where InvDetails.InvNo=" & updno & _
                 " and InvDetails.Invdt= '" & upddt & "' and  " & _
                 " InvDetails.type='" & updtype & "'  order by seq"

        dataredr = cmd.ExecuteReader()
        edtd = 0
        If dataredr.HasRows Then

            While dataredr.Read()
                edtd = dataredr("Edited")
                cmd1.CommandText = "update batch set stock=stock-" & dataredr.Item("Qty") & _
                    " where batchid=" & dataredr.Item("batchid")
                cmd1.ExecuteNonQuery()
            End While
        End If
        dataredr.Close()

        If updflag = "E" Then

            If edtd = 0 Then
                cmd1.CommandText = "update InvDetails set type='E" & updtype & "' where InvDetails.InvNo=" & updno & _
                   " and InvDetails.Invdt= '" & upddt & "' and  " & _
                    " InvDetails.type='" & updtype & "'"

                cmd1.ExecuteNonQuery()

                cmd1.CommandText = "update invtotal set type='E" & updtype & "' where invtotal.InvNo=" & updno & _
                      " and invtotal.Invdt= '" & upddt & "' and  " & _
                       " invtotal.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()
            Else
                cmd1.CommandText = "delete InvDetails   where InvDetails.InvNo=" & updno & _
                  " and InvDetails.Invdt= '" & upddt & "' and  " & _
                   " InvDetails.type='" & updtype & "'"

                cmd1.ExecuteNonQuery()

                cmd1.CommandText = "delete invtotal  where invtotal.InvNo=" & updno & _
                      " and invtotal.Invdt= '" & upddt & "' and  " & _
                       " invtotal.type='" & updtype & "'"
                cmd1.ExecuteNonQuery()

            End If

        ElseIf updflag = "C" Then

            cmd1.CommandText = "update invtotal set cancelled=1,netamt=0,amt1=0,amt2=0,amt3=0,amt4=0,amt5=0," & _
                    "tax1=0,tax2=0,tax3=0,tax4=0,tax5=0,addamt=0,dedamt=0 where invtotal.InvNo=" & updno & _
                   " and invtotal.Invdt= '" & upddt & "' and  " & _
                   " invtotal.type='" & updtype & "'"
            cmd1.ExecuteNonQuery()
            cmd1.CommandText = "update InvDetails set  cancelled=1  where InvDetails.InvNo=" & updno & _
                   " and InvDetails.Invdt= '" & upddt & "' and  " & _
                    " InvDetails.type='" & updtype & "'"
            cmd1.ExecuteNonQuery()

        End If


        cmd.CommandText = "select vouno from ledger where  trntype='Sr' and " & _
            "trndate=convert(datetime,'" & upddt & "') and " & _
            "InvCode='" & updtype & updno & "' and  seq=1"
        dataredr = cmd.ExecuteReader()
        If dataredr.HasRows Then
            dataredr.Read()
            EditVouNo = dataredr("vouno")
            cmd1.CommandText = "delete from ledger where vouno=" & dataredr("vouno") & _
                " and trntype='Sr' and trndate=convert(datetime,'" & upddt & "') "
            cmd1.ExecuteNonQuery()

            'cmd1.CommandText = "delete from adjdetails where (vouno=" & dataredr("vouno") & _
            '     " and trntype='Sr' and trndate=convert(datetime,'" & upddt & "')) or " & _
            '     " (billtrntype='Sr' and billVouno=" & dataredr("vouno") & _
            '     " and  billtrndt=convert(datetime,'" & upddt & "')) "
            'cmd1.ExecuteNonQuery()

        End If

    End Sub


    Private Sub DgSales_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSales.CellContentClick

    End Sub

    Private Sub DgSales_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSales.CellDoubleClick
        If DgSales.CurrentCell Is Nothing Then Exit Sub
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
                dgInv.Item(20, dgInv.RowCount - 1).Value = DgSales.Rows(i).Cells("nodisc").Value  ' .Item(11, i).Value
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

    Private Sub cbType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbType.Validating

    End Sub



    Private Sub tsbBCalcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBCalcel.Click
        Dim trn As Boolean
        Try
            If CheckUserLocked("Cancel Sales Rtn") = False Then Exit Sub

            If EditFlag Then
                MsgBox("Can't Cancell the Sales Return  while Editing.", MsgBoxStyle.Information)
                Exit Sub
            End If
            EditSales.txtSalNo.Focus()
            EditSales.Text = "Credit Note Cancellation (" & cbType.Text & ")"
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



                If MsgBox("Want to cancell the bill No." & EditSales.txtSalNo.Text & " dated: " & indt, vbYesNo + vbDefaultButton2) = vbNo Then
                    Exit Sub
                End If


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
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub



    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
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

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            If dr("cancelled") Then
                cmd.Parameters.Clear()
                NUM = Val(dr("invno") & "")
                dr.Close()
                GoTo che
            End If
        Else
            ' ClearForm()
            dr.Close()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        NUM = (dr("invno") & "")
        DT = dr("invdt")
        dr.Close()
        ClearForm(True)
        EditingSales(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
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
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "-S"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            If dr("cancelled") Then
                cmd.Parameters.Clear()
                NUM = Val(dr("invno") & "")

                dr.Close()
                GoTo che
            End If
        Else
            'GoTo che
            ' ClearForm()
            Me.Cursor = Cursors.Default
            dr.Close()
            Exit Sub
        End If

        NUM = (dr("invno") & "")
        DT = dr("invdt")
        dr.Close()
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SalesReturn()
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

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If CheckUserLocked("Edit Sales", , IIf(EditFlag, EditDt, Nothing)) = False Then Exit Sub
        EditDateShift.Text = EditDateShift.Text
        EditDateShift.loadform("3")
        EditDateShift.ShowDialog()
    End Sub

    Private Sub cbDoc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDoc.SelectedIndexChanged
        Try
            Dim cmd As New OleDb.OleDbCommand
            If cbDoc.SelectedIndex = -1 Then Exit Sub
            If IsDBNull(cbDoc.SelectedValue) Then Exit Sub
            If cbDoc.SelectedValue Is Nothing Then Exit Sub

            txtDoc.Text = ""
            cmd.Connection = Conn
            cmd.CommandText = "select place from doctor where doccode=" & Val(cbDoc.SelectedValue & "")
            txtDoc.Text = cmd.ExecuteScalar & ""
        Catch ex As Exception

        End Try
    End Sub
End Class

