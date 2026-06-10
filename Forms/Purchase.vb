Imports System
Imports System.Globalization
Imports System.math

Public Class Purchase
    Private obj As Object
    Private ProdSelected As Boolean
    Private TaxTbl As DataTable
    Public Rcpts As DataTable
    Private EDCOL As Integer
    Private EDROW As Integer
    Private EditRectNo As Long
    Private EditSupCode As Long

    Private EditRectDt As Date
    Private TabFlag, EditFlag As Boolean
    Private curunit As Double
    Private rtaxary(4, 2) As Double
    Private rptax(4, 2) As Double
    Private rpcstary(4, 2) As Double
    Private rpcst(4, 2) As Double
    Private value, totcst, Svalue, tottax, rctadj, rtfamt, totbdis, totpdis, totvalue, totsch, tot, totcstpur As Double
    Dim tmpbatid As Integer
    Dim tmpbat, EditType As String
    Dim RcptNum As Long

    Dim RcptDt As Date
    Private Trans As OleDb.OleDbTransaction
    Private CreditPost As Boolean
    Private PostAc As Boolean
    Private EditVouNo As Long

    Private repltot As Double
    Private UseBarCode As Boolean
    Private SeriesSame As Boolean
    Private CompareValue As Boolean

    Private Sub Purchase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.Tag = "POPS" Then


            If MsgBox("Want to exit from Purchase..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Purchase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If Asc(e.KeyChar) = 27 And panPur.Visible Then
                btnCncl.PerformClick()
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub Purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ClearForm()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ClearForm(Optional ByVal flg As Boolean = False)

        Dim i As Integer
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            txtBildat.Mask = DateMask
            txtDuedat.Mask = DateMask
            txtExDt.Mask = DateMask
            EditSupCode = 0
            EDCOL = 0
            EDROW = 0
            EditRectNo = 0
            EditVouNo = 0
            'EditRectDt = vbNull
            TabFlag = False
            EditFlag = False
            EditType = ""

            curunit = 0
            cmd.Connection = Conn
            'dgRec.Enabled = True
            If Not flg Then
                cmd.CommandText = "select Accode,Acname + ' ' + place as [AcName] from Acmaster where grpcode=" & SupGrpcode & " order by Acname"
                DA.SelectCommand = cmd
                DA.Fill(DS, "Acmaster")
                cbSupp.DisplayMember = "AcName"
                cbSupp.ValueMember = "AcCode"
                cbSupp.DataSource = DS.Tables("Acmaster")

                cmd.CommandText = "select Type,Descr,seq from SerialNum where type>10 and type<20 order by seq"
                DA.SelectCommand = cmd
                DA.Fill(DS, "SerialNum")
                cbRtype.DisplayMember = "Descr"
                cbRtype.ValueMember = "Type"
                cbRtype.DataSource = DS.Tables("SerialNum")
            End If
            chkBlockPay.Checked = False
            tsbSave.Enabled = False
            txtEdit.Visible = False
            txtEditDt.Visible = False
            CbEditUnit.Visible = False
            CbEditTaxInc.Visible = False
            cbEditVat.Visible = False
            ckbSelect.Checked = False
            cbSupp.Enabled = True
            cbRtype.Enabled = True
            dgRec.Enabled = True
            lbldt.Text = SysDt

            cbTaxInc.Text = "Yes"
            cbSupp.Text = ""
            txtBilno.Text = ""
            txtBildat.Text = ""
            txtDis.Text = "0.00"
            txtDuedat.Text = ""
            txtRmk.Text = ""
            txtDed.Text = "0.00"
            txtAdd.Text = "0.00"
            lblTamt.Text = "0.00"
            lblNamt.Text = "0.00"

            txtRepl.Text = "0"
            txtCST.Text = "0.000"
            txtPRate.Text = "0.000"
            txtSRate.Text = "0.000"
            txtPVat.Text = "0.00"
            txtPDis.Text = "0.00"
            txtQty.Text = "0"
            txtFree.Text = "0"
            txtRt.Text = "0.000"


            TaxTbl = New DataTable
            Rcpts = New DataTable
            dgRec.DataSource = Nothing
            Rcpts.TableName = "Rcpts"

            Rcpts.Columns.Add("SL")
            Rcpts.Columns.Add("BatchId")
            Rcpts.Columns.Add("Unit")
            Rcpts.Columns.Add("pk")
            Rcpts.Columns.Add("StkLs")
            Rcpts.Columns.Add("Wcode")
            Rcpts.Columns.Add("resv4")
            Rcpts.Columns.Add("resv5")
            Rcpts.Columns.Add("Code")
            Rcpts.Columns.Add("Product")
            Rcpts.Columns.Add("Batch")
            Rcpts.Columns.Add("ExDt")
            Rcpts.Columns.Add("resv6")
            Rcpts.Columns.Add("PRate")
            Rcpts.Columns.Add("SRate")
            Rcpts.Columns.Add("PVAT")
            Rcpts.Columns.Add("PDis")
            Rcpts.Columns.Add("resv7")
            Rcpts.Columns.Add("resv8")
            Rcpts.Columns.Add("Qty")
            Rcpts.Columns.Add("Free")
            Rcpts.Columns.Add("Repl")
            Rcpts.Columns.Add("Pack")
            Rcpts.Columns.Add("Value")
            Rcpts.Columns.Add("Profit")
            Rcpts.Columns.Add("RT")
            Rcpts.Columns.Add("SVAT")
            Rcpts.Columns.Add("TaxInc")
            Rcpts.Columns.Add("PCST")
            Rcpts.Columns.Add("PScheme")
            Rcpts.Columns.Add("TrRate")

            dgPurch.ColumnHeadersDefaultCellStyle.Font = New Font("Courier New", 8, FontStyle.Bold)

            dgPurch.DefaultCellStyle.Font = New Font("Courier New", 8, FontStyle.Regular)

            dgRec.Columns.Add("SL", "SL")
            dgRec.Columns.Add("BatchId", "")
            dgRec.Columns.Add("Unit", "")
            dgRec.Columns.Add("pk", "")
            dgRec.Columns.Add("StkLs", "")
            dgRec.Columns.Add("Wcode", "")
            dgRec.Columns.Add("resv4", "")
            dgRec.Columns.Add("resv5", "")
            dgRec.Columns.Add("Code", "Code")
            dgRec.Columns.Add("Product", "Products")
            dgRec.Columns.Add("Batch", "Batch")
            dgRec.Columns.Add("ExDt", "Ex.Dt")
            dgRec.Columns.Add("Rcsv6", "")
            dgRec.Columns.Add("PRate", "P.Rate")
            dgRec.Columns.Add("SRate", "S.Rate")
            dgRec.Columns.Add("PVAT", "PVAT%")
            dgRec.Columns.Add("PDis", "PDis%")
            dgRec.Columns.Add("resv7", "")
            dgRec.Columns.Add("resv8", "")
            dgRec.Columns.Add("Qty", "Qty")
            dgRec.Columns.Add("Free", "Free")
            dgRec.Columns.Add("Repl", "Repl")
            dgRec.Columns.Add("Pack", "Packing")
            dgRec.Columns.Add("Value", "Value")
            dgRec.Columns.Add("Profit", "Profit%")
            dgRec.Columns.Add("RT", "RT%")
            dgRec.Columns.Add("SVAT", "SVAT%")
            dgRec.Columns.Add("TaxInc", "Tax Inc")
            dgRec.Columns.Add("PCST", "P CST%")
            dgRec.Columns.Add("PScheme", "P Scheme")
            dgRec.Columns.Add("TrRate", " Tr Rate")

            dgRec.Columns(0).DataPropertyName = "SL"
            dgRec.Columns(0).Width = Int(dgRec.Width * 3 / 100)

            dgRec.Columns(1).DataPropertyName = "BatchId"
            dgRec.Columns(1).Visible = False

            dgRec.Columns(2).DataPropertyName = "Unit"
            dgRec.Columns(2).Visible = False
            dgRec.Columns(3).DataPropertyName = "Pk"
            dgRec.Columns(3).Visible = False
            dgRec.Columns(4).DataPropertyName = "StkLs"
            dgRec.Columns(4).Visible = False
            dgRec.Columns(5).DataPropertyName = "wcode"
            dgRec.Columns(5).Visible = False
            dgRec.Columns(6).DataPropertyName = "resv4"
            dgRec.Columns(6).Visible = False
            dgRec.Columns(7).DataPropertyName = "resv5"
            dgRec.Columns(7).Visible = False
            dgRec.Columns(8).DataPropertyName = "Code"
            dgRec.Columns(8).Width = Int(dgRec.Width * 7 / 100)

            dgRec.Columns(9).DataPropertyName = "Product"
            dgRec.Columns(9).Visible = True
            dgRec.Columns(9).Width = Int(dgRec.Width * 20 / 100)
            dgRec.Columns(9).Frozen = True
            dgRec.Columns(10).DataPropertyName = "Batch"
            dgRec.Columns(10).Width = Int(dgRec.Width * 9 / 100)

            dgRec.Columns(11).DataPropertyName = "ExDt"
            dgRec.Columns(11).Width = Int(dgRec.Width * 9 / 100)

            dgRec.Columns(12).DataPropertyName = "resv6"
            dgRec.Columns(12).Visible = False

            dgRec.Columns(13).DataPropertyName = "PRate"
            dgRec.Columns(13).Width = Int(dgRec.Width * 7 / 100)
            dgRec.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(14).DataPropertyName = "SRate"
            dgRec.Columns(14).Width = Int(dgRec.Width * 7 / 100)
            dgRec.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(15).DataPropertyName = "PVAT"
            dgRec.Columns(15).Width = Int(dgRec.Width * 5 / 100)
            dgRec.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(16).DataPropertyName = "PDis"
            dgRec.Columns(16).Width = Int(dgRec.Width * 4 / 100)
            dgRec.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            dgRec.Columns(17).DataPropertyName = "resv7"
            dgRec.Columns(17).Visible = False

            dgRec.Columns(18).DataPropertyName = "resv8"
            dgRec.Columns(18).Visible = False

            dgRec.Columns(19).DataPropertyName = "Qty"
            dgRec.Columns(19).Width = Int(dgRec.Width * 5 / 100)
            dgRec.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(19).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            dgRec.Columns(20).DataPropertyName = "Free"
            dgRec.Columns(20).Width = Int(dgRec.Width * 4 / 100)
            dgRec.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(20).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            dgRec.Columns(21).DataPropertyName = "Repl"
            dgRec.Columns(21).Width = Int(dgRec.Width * 4 / 100)
            dgRec.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(21).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(22).DataPropertyName = "Pack"
            dgRec.Columns(22).Width = Int(dgRec.Width * 6 / 100)

            dgRec.Columns(23).DataPropertyName = "Value"
            dgRec.Columns(23).Width = Int(dgRec.Width * 6 / 100)
            dgRec.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(23).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            dgRec.Columns(24).DataPropertyName = "Profit"
            dgRec.Columns(24).Width = Int(dgRec.Width * 6 / 100)
            dgRec.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(24).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(25).Visible = False
            dgRec.Columns(25).DataPropertyName = "RT"
            dgRec.Columns(25).Width = Int(dgRec.Width * 10 / 100)
            dgRec.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(25).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(26).DataPropertyName = "SVAT"
            dgRec.Columns(26).Width = Int(dgRec.Width * 10 / 100)
            dgRec.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(26).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(27).DataPropertyName = "TaxInc"
            dgRec.Columns(27).Width = Int(dgRec.Width * 10 / 100)


            dgRec.Columns(28).DataPropertyName = "PCST"
            dgRec.Columns(28).Width = Int(dgRec.Width * 10 / 100)
            dgRec.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(28).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(29).DataPropertyName = "PScheme"
            dgRec.Columns(29).Width = Int(dgRec.Width * 10 / 100)
            dgRec.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(29).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            dgRec.Columns(30).DataPropertyName = "TrRate"
            dgRec.Columns(30).Width = Int(dgRec.Width * 10 / 100)
            dgRec.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgRec.Columns(30).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            'dgRec.Columns(0).Visible = False


            dgPurch.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgPurch.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            'dgRec.RowHeadersVisible = False

            'dgRec.BackgroundColor = Color.Navy
            dgRec.DataSource = Rcpts

            Rcpts.Rows.Add()

            dgRec.CurrentCell.Selected = False

            For i = 0 To 29
                dgRec.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                'dgRec.Columns(i).DefaultCellStyle.BackColor = Color.Navy
                'dgRec.Columns(i).DefaultCellStyle.ForeColor = Color.Yellow
            Next i

            TaxTbl.TableName = "Tax"
            cmd.Connection = Conn

            cmd.CommandText = "select usebarcode from settings "
            UseBarCode = cmd.ExecuteScalar
            dgRec.Columns(8).Visible = UseBarCode


            cmd.CommandText = "select rcptseriessame from settings "
            SeriesSame = cmd.ExecuteScalar


            cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' order by seq"
            DA.SelectCommand = cmd
            DA.Fill(TaxTbl)

            cbSVat.DataSource = TaxTbl
            cbSVat.DisplayMember = "taxper"

            cbEditVat.DataSource = TaxTbl
            cbEditVat.DisplayMember = "taxper"
            pnlprod.Visible = False

            cmd.CommandText = "select taxper,accode,surch from tax where flag='31'"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                i = 0
                While dataredr.Read()
                    rtaxary(i, 0) = dataredr.Item("taxper")
                    rtaxary(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If
            dataredr.Close()




            cmd.CommandText = "select taxper,accode,surch from tax where flag='91'"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                i = 0
                While dataredr.Read()

                    rpcstary(i, 0) = dataredr.Item("taxper")
                    rpcstary(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If
            dataredr.Close()



            cmd.CommandText = "select taxper,accode,surch from tax where flag='92'"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                i = 0
                While dataredr.Read()
                    rpcst(i, 0) = dataredr.Item("taxper")
                    rpcst(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If
            dataredr.Close()

            cmd.CommandText = "select taxper,accode,surch from tax where flag='32'"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                i = 0
                While dataredr.Read()

                    rptax(i, 0) = dataredr.Item("taxper")
                    rptax(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If
            dataredr.Close()
            EditFlag = False
            pnlDNote.Visible = False
            'dgRec.Enabled = True
            tsbPrint.Enabled = True
            tsbEdit.Enabled = True
            If Not flg Then
                GetSeries()
                cbSupp.SelectedValue = 0
                cbSupp.Text = ""
            End If

            dgRec.Enabled = True
            'dgRec.CurrentCell = dgRec.Item(9, dgRec.Rows.Count - 1)
            dgRec.Focus()

            Me.Cursor = Cursors.Default
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
        pnlacc.Visible = False
        pnlDNote.Visible = False
        pnlprod.Visible = False

        pnlCmpVal.Visible = False
        CompareValue = False
        chkUpdatePurRtn.Checked = False

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetBarcode()
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
                GetInfo(dataredr(0), dataredr(1))
            Else
                txtEdit.Focus()
                txtEdit.SelectAll()
                dataredr.Close()
                MsgBox("Product not found..")
                Exit Sub
            End If
            dataredr.Close()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Select Case dgRec.CurrentCell.ColumnIndex
                    Case 8
                        If txtEdit.Text = "" Then
                            dgRec.CurrentCell = dgRec.Item(9, dgRec.CurrentCell.RowIndex)
                            EditGrid()
                            Exit Sub
                        Else

                            GetBarcode()
                            Exit Sub
                        End If
                    Case 13, 14

                        dgRec.CurrentCell.Value = Format(Val(txtEdit.Text), "0.000")
                        Calculate()
                        ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value.ToString)
                    Case 15, 16, 25, 26, 27, 28, 29
                        dgRec.CurrentCell.Value = Format(Val(txtEdit.Text), "0.00")
                        Calculate()
                        ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value.ToString)
                    Case 19, 20, 21
                        dgRec.CurrentCell.Value = Format(Val(txtEdit.Text), "0")
                        Calculate()
                        ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value.ToString)
                    Case 9
                        If txtEdit.Text = "" And UseBarCode Then
                            dgRec.CurrentCell = dgRec.Item(8, dgRec.CurrentCell.RowIndex)
                            EditGrid()
                            Exit Sub
                        Else
                            pnlprod.Visible = False
                        End If

                    Case Else
                        dgRec.CurrentCell.Value = txtEdit.Text
                End Select

                txtEdit.Visible = False
                dgRec.Focus()

                If EditFlag = True Or EditFlag = False Then
                    pnlDNote.Visible = False
                    dgRec.Focus()
                End If

            End If

            If e.KeyCode = Keys.Escape Then
                txtEdit.Visible = True
                pnlDNote.Visible = False
                dgRec.Focus()
                If dgRec.CurrentCell.RowIndex = dgRec.Rows.Count - 1 Then ClearRow()
                e.Handled = True
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        Try
            Select Case dgRec.CurrentCell.ColumnIndex
                Case 12, 13, 15, 16, 19, 20, 21, 24, 25, 28
                    If InStr("0123456789." & Chr(8), e.KeyChar) = 0 Then e.KeyChar = ""
                Case 9
                    'pnlDNote.Visible = False
                    'EditGrid()
                    Exit Sub
            End Select
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.Leave
        Try
            If Not pnlprod.Visible Then
                txtEdit.Visible = False
                TabFlag = False
                pnlprod.Visible = False
                dgRec.Enabled = True
                dgRec.Focus()
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged
        Try
            Select Case dgRec.CurrentCell.ColumnIndex
                Case 9
                    If txtEdit.Text = "" Then pnlprod.Visible = False : Exit Sub
                    'If ProdSelected = True Then Exit Sub
                    obj = txtEdit
                    PopulateProduct()
            End Select
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

    Private Sub DgProdSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        GetInfo()
    End Sub

    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetInfo()
        End If
    End Sub

    Private Sub GetInfo(Optional ByVal CD As String = "", Optional ByVal PN As String = "")

        Dim i, ci As Integer
        Try

            If CD = "" Then
                CD = DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value.ToString
                PN = DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value.ToString
            End If

            For i = 0 To dgRec.Rows.Count - 1
                If dgRec.Item(8, i).Value & "" = CD Then
                    If MsgBox("Product Already Entered.. Want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then
                        pnlprod.Visible = False
                        txtEdit.Text = ""
                        txtEdit.Focus()
                        tsbClear.Enabled = True
                        Exit Sub
                        Exit For
                    Else
                        Exit For
                    End If
                End If
            Next

            Dim cmd As New OleDb.OleDbCommand
            Dim unittab As New DataTable


            cmd.Connection = Conn
            cmd.CommandText = "Select PRDCODE from product,supcom where  prdcode=""" + CD + """ AND supcom.SUPCODE=" & Val(cbSupp.SelectedValue) & " AND supcom.comcode=product.comcode "

            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If Not dataredr.HasRows Then

                If MsgBox("Company of product '" & PN & " is not available in supplier's company list." & Chr(13) & _
                    "You cannot enter the product unless company is added." & Chr(13) & _
                    "Click 'Yes' to add Company in supplier's list", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    pnlprod.Visible = False
                    txtEdit.Text = ""
                    txtEdit.Focus()
                    tsbClear.Enabled = True
                    dataredr.Close()
                    Exit Sub
                End If
                dataredr.Close()
                Dim ccd As Long
                cmd.CommandText = "Select comcode from product where  prdcode=""" + CD + """ "
                ccd = cmd.ExecuteScalar
                cmd.CommandText = "insert into supcom (supcode,comcode) values(" & Val(cbSupp.SelectedValue) & "," & ccd & ")"
                cmd.ExecuteNonQuery()
            Else
                dataredr.Close()
            End If

            cmd.CommandText = "Select  color from product where  prdcode=""" + CD + """ "
            ci = Val(cmd.ExecuteScalar & "")

            txtEdit.SelectionStart = Len(txtEdit.Text)
            dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value = CD
            dgRec.Item(9, dgRec.CurrentCell.RowIndex).Value = PN
            dgRec.Item(9, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.FromArgb(ci)

            dgRec.Item(0, dgRec.CurrentCell.RowIndex).Value = dgRec.CurrentCell.RowIndex + 1
            pnlprod.Visible = False

            GetProduct(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value)
            panPur.Visible = True
            txtBatch.Focus()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ClearRow()
        Try
            Dim i As Integer
            For i = 0 To dgRec.ColumnCount - 1
                dgRec.Item(i, dgRec.CurrentCell.RowIndex).Value = ""


            Next i
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub GetProduct(ByVal pcode As String)

        Dim cmd As New OleDb.OleDbCommand
        Dim unittab As New DataTable

        Try
            unittab.TableName = "Pack"
            unittab.Columns.Add()
            unittab.Columns(0).ColumnName = "unit"
            unittab.Columns.Add()
            unittab.Columns(1).ColumnName = "Case"
            unittab.Rows.Clear()
            cmd.Connection = Conn
            cmd.CommandText = "Select * from product where prdcode=""" + pcode + """ "
            'ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()
                lblPrdNam.Text = dataredr.Item("prdname")
                txtEdit.Text = dataredr.Item("Prdname")

                cbPUnit.DataSource = Nothing

                cbPUnit.ValueMember = "unit"
                cbPUnit.DisplayMember = "Case"
                cbPUnit.DataSource = unittab
                unittab.Rows.Add(Round(dataredr.Item("unit1"), 0), dataredr.Item("case1"))

                If dataredr.Item("unit2") <> 0 Then
                    unittab.Rows.Add(Round(dataredr.Item("unit2"), 0), dataredr.Item("case2"))

                Else

                End If

                If dataredr.Item("unit3") <> 0 Then
                    unittab.Rows.Add(Round(dataredr.Item("unit3"), 0), dataredr.Item("case3"))
                End If

                If dataredr.Item("unit2") <> 0 Then
                    cbPUnit.SelectedIndex = 1
                Else
                    cbPUnit.SelectedIndex = 0
                End If
                cbTaxInc.SelectedIndex = 1
            End If
            dataredr.Close()
            cbSupp1.Items.Clear()
            cbSupp1.Items.Add(cbSupp.Text)
            cbSupp1.Items.Add("All Supplier")
            cbSupp1.Tag = "Y"
            cbSupp1.SelectedIndex = 0
            'GridClick()
            cbSupp1.Tag = "'"
            GridClick()

            chkstkded.Checked = False
            txtQty.Text = "0"
            txtQty.Tag = 0
            pnlprod.Visible = False
            panPur.Visible = True

            tsbClear.Enabled = False
            tsbPrint.Enabled = False
            tsbEdit.Enabled = False
            tsbSave.Enabled = False
            tsbPrint.Enabled = False
            Application.DoEvents()
            txtBatch.Focus()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
        'ProdSelected = False
    End Sub

    Private Sub btnCncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncl.Click
        Try
            If dgRec.CurrentCell.RowIndex = dgRec.Rows.Count - 1 Then
                dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value = Nothing
                dgRec.Item(9, dgRec.CurrentCell.RowIndex).Value = Nothing
                dgRec.Item(0, dgRec.CurrentCell.RowIndex).Value = Nothing
                txtEdit.Visible = True
            End If

            panPur.Visible = False
            txtEdit.Clear()
            txtEdit.Focus()
            tsbClear.Enabled = True
            tsbPrint.Enabled = True
            tsbEdit.Enabled = True
            tsbSave.Enabled = True
            tsbPrint.Enabled = True
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgRec_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRec.CellValueChanged
        Try
            Select Case e.ColumnIndex
                Case 11
                    If IsDate(dgRec.Item(11, dgRec.CurrentCell.RowIndex).Value & "") Then

                        If DateDiff("d", SysDt, CDate(dgRec.Item(11, dgRec.CurrentCell.RowIndex).Value)) < 90 Then
                            dgRec.Item(11, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                        Else
                            dgRec.Item(11, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Black

                        End If
                    End If

            End Select
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgRec_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRec.DoubleClick
        Try
            If Val(dgRec.Item(19, dgRec.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgRec.Item(20, dgRec.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgRec.Item(21, dgRec.CurrentCell.RowIndex).Value & "") < 0 Then
                'pcode = dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value
                GetProduct(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value)
                ShowEntries()
            Else
                If dgRec.CurrentCell.RowIndex = dgRec.Rows.Count - 1 And dgRec.CurrentCell.ColumnIndex > 9 Then
                    If UseBarCode Then
                        dgRec.CurrentCell = dgRec.Item(8, dgRec.CurrentCell.RowIndex)
                    Else
                        dgRec.CurrentCell = dgRec.Item(9, dgRec.CurrentCell.RowIndex)
                    End If
                End If

                EditGrid()
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Dim WD As Integer
        Try
            WD = 0
            cntrol.Location = dgRec.Location
            cntrol.top = dgRec.Top
            cntrol.left = dgRec.Left
            cntrol.top = dgRec.Top + dgRec.GetRowDisplayRectangle(dgRec.CurrentCell.RowIndex, True).Top
            cntrol.left = dgRec.Left + dgRec.GetColumnDisplayRectangle(dgRec.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgRec.GetColumnDisplayRectangle(dgRec.CurrentCell.ColumnIndex, True).Width
            cntrol.Text = dgRec.CurrentCell.Value & ""

            cntrol.Visible = True
            cntrol.Focus()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ShowEntries()
        Try
            txtBatch.Text = dgRec.Item(10, dgRec.CurrentCell.RowIndex).Value
            txtExDt.Text = dgRec.Item(11, dgRec.CurrentCell.RowIndex).Value
            cbPUnit.SelectedValue = dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value
            'dgRec.Item(3, dgRec.CurrentCell.RowIndex).Value = cbPUnit.Text
            cbSVat.Text = dgRec.Item(26, dgRec.CurrentCell.RowIndex).Value
            cbTaxInc.Text = dgRec.Item(27, dgRec.CurrentCell.RowIndex).Value
            txtCST.Text = dgRec.Item(28, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtCST.Text), "0.000")
            txtPRate.Text = dgRec.Item(13, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtPRate.Text), "0.000")
            txtSRate.Text = dgRec.Item(14, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtSRate.Text), "0.000")
            txtPVat.Text = dgRec.Item(15, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtPVat.Text), "0.000")
            txtPDis.Text = dgRec.Item(16, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtPDis.Text), "0.000")
            txtQty.Text = dgRec.Item(19, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtQty.Text), "0.00")
            txtFree.Text = dgRec.Item(20, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtFree.Text), "0.00")
            txtRepl.Text = dgRec.Item(21, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtRepl.Text), "0.00")
            txtRt.Text = dgRec.Item(25, dgRec.CurrentCell.RowIndex).Value '= Format(Val(txtRt.Text), "0.00")
            chkstkded.Checked = IIf(Val(dgRec.Item(4, dgRec.CurrentCell.RowIndex).Value & "") = 1, True, False)
            txtQty.Tag = Val(dgRec.Item(4, dgRec.CurrentCell.RowIndex).Value)
            If cbPUnit.Items.Count > 1 Then
                cbPUnit.SelectedIndex = 1
            Else
                cbPUnit.SelectedIndex = 0
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If Val(txtQty.Text) + Val(txtFree.Text) + Val(txtRepl.Text) = 0 Then
                MsgBox("Quantity is zero..", MsgBoxStyle.Information)
                txtQty.Focus()
                Exit Sub
            End If


            If Val(txtQty.Text) < 0 Or Val(txtFree.Text) < 0 Or Val(txtRepl.Text) < 0 Then
                If Val(txtQty.Text) > 0 Or Val(txtFree.Text) > 0 Or Val(txtRepl.Text) > 0 Then
                    MsgBox("Purchase Qty. and Return Qty. Cannot be entered toghter.. ")
                    If txtRepl.Text <> 0 Then
                        txtRepl.Focus()
                    Else
                        txtFree.Focus()
                    End If
                    Exit Sub
                End If
            End If
            If chkstkded.Checked = True And Val(txtQty.Tag) = 0 Then
                MsgBox("Select a batch row to deduct.")
                Exit Sub
            End If
            If cbPUnit.Text = "" Then
                MsgBox("Select the packing.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ShowQty()

            tsbSave.Enabled = True
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub





    Private Sub ShowQty()
        Dim tmpdt As DateTime
        Dim dt
        Try
            txtEdit.Visible = False
            'dgRec.Enabled = True

            dt = txtExDt.Text
            If txtExDt.Text <> "__/__/____" And Microsoft.VisualBasic.Right(txtExDt.Text, 2) = "__" And Val(Microsoft.VisualBasic.Left(txtExDt.Text, 2)) <= 12 Then

                tmpdt = Nothing

                tmpdt = "01/" & Val(Microsoft.VisualBasic.Left(txtExDt.Text, 2)) & "/" & Val(Microsoft.VisualBasic.Mid(txtExDt.Text, 4, 2))

                tmpdt = tmpdt.AddMonths(1)

                tmpdt = tmpdt.AddDays(-1)

                txtExDt.Text = tmpdt
            End If

            If Not (IsDate(txtExDt.Text) Or txtExDt.Text = "__/__/____") Then
                txtExDt.Text = dt
                MsgBox("Invalid Expiry Date ..!")
                txtExDt.Focus()
                txtExDt.SelectAll()
                Exit Sub
            End If


            If Val(txtQty.Text) + Val(txtFree.Text) + Val(txtRepl.Text) > 0 Then
                If txtExDt.Text <> "__/__/____" And IsDate(txtExDt.Text) Then
                    If CDate(txtExDt.Text) <= SysDt Then
                        txtExDt.Text = dt
                        MsgBox("Product Already Expired ..!")
                        txtExDt.Focus()
                        txtExDt.SelectAll()
                        Exit Sub
                    End If
                End If
            End If

            If Val(txtPRate.Text) > Val(txtSRate.Text) Then
                MsgBox(" Invalid Selling Rate ", MsgBoxStyle.Question + MsgBoxStyle.OkOnly)
                txtSRate.Focus()
                Exit Sub
            End If


            dgRec.Item(10, dgRec.CurrentCell.RowIndex).Value = txtBatch.Text
            dgRec.Item(11, dgRec.CurrentCell.RowIndex).Value = txtExDt.Text
            dgRec.Item(22, dgRec.CurrentCell.RowIndex).Value = cbPUnit.Text & " (" & cbPUnit.SelectedValue & ") "
            dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value = cbPUnit.SelectedValue
            'dgRec.Item(3, dgRec.CurrentCell.RowIndex).Value = cbPUnit.Text
            dgRec.Item(4, dgRec.CurrentCell.RowIndex).Value = IIf(chkstkded.Checked, 1, 0)

            If Val(txtQty.Text) + Val(txtFree.Text) + Val(txtRepl.Text) < 0 Then
                dgRec.Item(1, dgRec.CurrentCell.RowIndex).Value = Val(txtQty.Tag)

                If chkstkded.Checked Then
                    dgRec.Item(19, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                    dgRec.Item(20, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                    dgRec.Item(21, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                Else
                    dgRec.Item(19, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon
                    dgRec.Item(20, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon
                    dgRec.Item(21, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon
                End If

            End If


            dgRec.Item(26, dgRec.CurrentCell.RowIndex).Value = cbSVat.Text
            dgRec.Item(27, dgRec.CurrentCell.RowIndex).Value = cbTaxInc.Text
            dgRec.Item(28, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtCST.Text), "0.00")
            dgRec.Item(13, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtPRate.Text), "0.000")
            dgRec.Item(14, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtSRate.Text), "0.000")
            dgRec.Item(15, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtPVat.Text), "0.00")
            dgRec.Item(16, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtPDis.Text), "0.00")
            dgRec.Item(19, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtQty.Text), "0")
            dgRec.Item(20, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtFree.Text), "0")
            dgRec.Item(21, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtRepl.Text), "0")
            'dgRec.Item(23, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtRepl.Text), "0.00")
            'dgRec.Item(24, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtRepl.Text), "0.00")
            dgRec.Item(25, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtRt.Text), "0.00")
            dgRec.Item(4, dgRec.CurrentCell.RowIndex).Value = IIf(chkstkded.Checked, 1, 0)
            dgRec.Item(29, dgRec.CurrentCell.RowIndex).Value = Format(Val(txtpch.Text), "0.00")
            dgRec.Update()
            ExpColor(dgRec.CurrentCell.RowIndex)


            If dgRec.CurrentCell.RowIndex = dgRec.Rows.Count - 1 Then
                Rcpts.Rows.Add()
            End If

            panPur.Visible = False
            dgRec.Focus()

            NewRcpt()
            Calculate()
            ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value)
            If UseBarCode Then
                dgRec.CurrentCell = dgRec.Item(8, Rcpts.Rows.Count - 1)
            Else
                dgRec.CurrentCell = dgRec.Item(9, Rcpts.Rows.Count - 1)
            End If
            ShowEditControl(txtEdit)

            tsbSave.Enabled = True
            'tsbCopy.Enabled = True
            'tsbNew.Enabled = True
            tsbClear.Enabled = True
            'txtQty.Text = "0"

        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Public Sub ExpColor(ByVal i As Integer)
        Try

            Dim nds As Long
            dgRec.Item(11, i).Style.ForeColor = Color.Black
            If dgRec.Item(11, i).Value & "" <> "" Then
                If IsDate(dgRec.Item(11, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgRec.Item(11, i).Value)
                    If nds < 0 Then
                        dgRec.Item(11, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then
                        dgRec.Item(11, i).Style.ForeColor = Color.DarkRed

                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub NewRcpt()
        Try
            txtBatch.Text = ""
            txtExDt.Text = ""
            txtRepl.Text = "0"
            txtCST.Text = "0.000"
            txtPRate.Text = "0.000"
            txtSRate.Text = "0.000"
            txtPVat.Text = "0.00"
            txtPDis.Text = "0.000"
            txtQty.Text = "0"
            txtFree.Text = "0"
            txtRt.Text = "0.000"
            cbSVat.Text = "0.00"
            txtQty.Tag = ""
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub HidePanel()
        Try
            dgSupp.Visible = False
            panPur.Visible = False
            txtEdit.Focus()
            txtEdit.Text = ""
            dgSupp.Visible = True
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtBatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatch.KeyDown
        If e.KeyCode = Keys.Enter Then txtExDt.Focus()
    End Sub

    Private Sub txtExDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExDt.GotFocus
        txtExDt.SelectAll()
    End Sub

    Private Sub txtPRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRate.KeyPress
        If Asc(e.KeyChar) = 13 Then txtSRate.Focus()
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtCST_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCST.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtPCST_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCST.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtPVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPVat.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtPVat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPVat.KeyPress
        Try
            If Asc(e.KeyChar) = 27 Then
                HidePanel()
                NewRcpt()
            End If
            If Asc(e.KeyChar) = 8 Then Exit Sub
            If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtPDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPDis.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtPDis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPDis.KeyPress
        Try
            If Asc(e.KeyChar) = 27 Then
                HidePanel()
                NewRcpt()
            End If
            If Asc(e.KeyChar) = 8 Then Exit Sub
            If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtSRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSRate.KeyPress

        If Asc(e.KeyChar) = 13 Then txtQty.Focus()
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRt.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtRt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRt.KeyPress
        If Asc(e.KeyChar) = 27 Then
            HidePanel()
            NewRcpt()
        End If
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub cbPUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbPUnit.KeyPress

        If Asc(e.KeyChar) = 13 Then txtPRate.Focus()
        ' If Asc(e.KeyChar) = 8 Then Exit Sub
        ' If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRepl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepl.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtRepl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepl.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.-", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Try
            If cbRtype.SelectedIndex <> 2 Then
                If Asc(e.KeyChar) = 8 Then Exit Sub
                If InStr("0123456789.-", e.KeyChar) = 0 Then e.KeyChar = ""
            ElseIf cbRtype.SelectedIndex = 2 Then
                If Asc(e.KeyChar) = 8 Then Exit Sub
                If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtFree_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFree.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtFree_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFree.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789-.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtDis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDis.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDis.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        NewRcpt()
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub cbSup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSupp1.KeyPress
        If Asc(e.KeyChar) = 27 Then
            HidePanel()
            NewRcpt()
        End If
    End Sub

    Private Sub cbPUnit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPUnit.SelectedIndexChanged
        Try
            lblTB.Text = cbPUnit.SelectedValue & " ' S"
            If curunit <> 0 Then
                txtPRate.Text = Format((Val(txtPRate.Text) / curunit) * cbPUnit.SelectedValue, "0.000")
                txtSRate.Text = Format((Val(txtSRate.Text) / curunit) * cbPUnit.SelectedValue, "0.000")
                curunit = cbPUnit.SelectedValue
            Else
                curunit = cbPUnit.SelectedValue
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtBatch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatch.GotFocus
        txtBatch.SelectAll()
    End Sub

    Private Sub txtPRate_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRate.GotFocus
        txtPRate.SelectAll()
    End Sub

    Private Sub txtCST_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCST.GotFocus
        txtCST.SelectAll()
    End Sub

    Private Sub txtPVat_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPVat.GotFocus
        txtPVat.SelectAll()
    End Sub

    Private Sub txtPDis_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPDis.GotFocus
        txtPDis.SelectAll()
    End Sub

    Private Sub txtSRate_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSRate.GotFocus
        txtSRate.SelectAll()
    End Sub

    Private Sub txtRt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRt.GotFocus
        txtRt.SelectAll()
    End Sub

    Private Sub txtQty_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        txtQty.SelectAll()
    End Sub

    Private Sub txtFree_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFree.GotFocus
        txtFree.SelectAll()
    End Sub

    Private Sub txtRepl_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepl.GotFocus
        txtRepl.SelectAll()
    End Sub

    Private Sub EditGrid()
        Try

            If dgRec.CurrentCell.RowIndex = dgRec.Rows.Count - 1 And dgRec.CurrentCell.ColumnIndex > 9 Then
                If UseBarCode Then
                    dgRec.CurrentCell = dgRec.Item(8, dgRec.CurrentCell.RowIndex)
                Else
                    dgRec.CurrentCell = dgRec.Item(9, dgRec.CurrentCell.RowIndex)
                End If
            End If


            EDROW = dgRec.CurrentCell.RowIndex
            EDCOL = dgRec.CurrentCell.ColumnIndex
            If EDCOL = 0 Then
                EDCOL = 9
                dgRec.CurrentCell = dgRec.Item(EDCOL, EDROW)
            End If




            If IsNothing(dgRec.CurrentCell) Then Exit Sub
            TabFlag = True

            Select Case dgRec.CurrentCell.ColumnIndex
                Case 0, 23, 24
                    Exit Sub
                Case 11
                    ShowEditControl(txtEditDt)
                    txtEditDt.SelectAll()
                Case 26
                    ShowEditControl(cbEditVat)
                Case 27
                    ShowEditControl(CbEditTaxInc)
                Case 22
                    GetPacking()
                    ShowEditControl(CbEditUnit)


                    CbEditUnit.SelectedValue = CLng(dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value)

                Case Else
                    ShowEditControl(txtEdit)
                    txtEdit.SelectAll()
            End Select
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEditDt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditDt.GotFocus
        txtEditDt.SelectAll()
    End Sub

    Private Sub txtEditDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEditDt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Not ExpDateCheck(txtEditDt, False) Then
                    txtEditDt.Focus()
                    txtEditDt.SelectAll()
                    Exit Sub
                End If

                dgRec.CurrentCell.Value = txtEditDt.Text
                ExpColor(dgRec.CurrentCell.RowIndex)
                txtEditDt.Visible = False
                dgRec.Focus()

                If EditFlag = True Or EditFlag = False Then
                    pnlDNote.Visible = False
                    dgRec.Focus()
                End If

            End If
            If e.KeyCode = Keys.Escape Then
                txtEditDt.Visible = False
                dgRec.Focus()
            End If
            e.Handled = True
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEditDt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditDt.Leave
        txtEditDt.Visible = False
        dgRec.Enabled = True
        dgRec.Focus()
    End Sub

    Private Sub dgRec_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgRec.Scroll
        cbEditVat.Visible = False
        CbEditUnit.Visible = False
        CbEditTaxInc.Visible = False
        txtEdit.Visible = False
        txtEditDt.Visible = False
        pnlprod.Visible = False
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
            cmd.CommandText = "Select case1,case2,case3,unit1,unit2,unit3 from product where prdcode=""" + dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value + """ "
            'ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                CbEditUnit.DataSource = Nothing

                unittab1.Rows.Add(Round(dataredr.Item("unit1"), 0), dataredr.Item("case1"))

                If dataredr.Item("unit2") <> 0 Then
                    unittab1.Rows.Add(Round(dataredr.Item("unit2"), 0), dataredr.Item("case2"))
                End If

                If dataredr.Item("unit3") <> 0 Then
                    unittab1.Rows.Add(Round(dataredr.Item("unit3"), 0), dataredr.Item("case3"))
                End If

                CbEditUnit.ValueMember = "unit"
                CbEditUnit.DisplayMember = "Case"
                CbEditUnit.DataSource = unittab1

            End If
            dataredr.Close()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditTaxInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditTaxInc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                dgRec.CurrentCell.Value = CbEditTaxInc.Text
                dgRec.Focus()
                Calculate()
                ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value.ToString)
                e.Handled = True
            Catch er As Exception

                ErrorMsg(er.Message, er.StackTrace)

            End Try
        End If
    End Sub

    Private Sub CbEditTaxInc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditTaxInc.Leave
        CbEditTaxInc.Visible = False
        dgRec.Focus()
        dgRec.Enabled = True
        dgRec.Focus()
    End Sub

    Private Sub dgRec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgRec.KeyDown
        Dim i As Integer
        Try
            If e.KeyCode = Keys.Enter Then

                If Val(dgRec.Item(19, dgRec.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgRec.Item(20, dgRec.CurrentCell.RowIndex).Value & "") < 0 Or Val(dgRec.Item(21, dgRec.CurrentCell.RowIndex).Value & "") < 0 Then
                    GetProduct(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value)
                    ShowEntries()
                Else
                    EditGrid()
                End If

                e.Handled = True
            End If
            pnlDNote.Visible = False

            If e.KeyCode = Keys.Delete And dgRec.CurrentCell.RowIndex <> dgRec.Rows.Count - 1 Then
                If MsgBox("Want to Delete the item ' " & dgRec.Item(9, dgRec.CurrentCell.RowIndex).Value.ToString & " '..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    dgRec.Rows.Remove(dgRec.CurrentRow)
                    For i = 0 To dgRec.Rows.Count - 2
                        dgRec.Item(0, i).Value = i + 1
                    Next
                    Calculate()
                    dgRec.Focus()
                End If
            End If

            'If ProdSelected = True Then
            ' pnlprod.Visible = False
            'End If


            'If e.KeyCode = Keys.Delete And dgRec.CurrentCell.Value(dgRec.CurrentCell.RowIndex, 0) <> "" Then
            '    MsgBox("Want to Delete the item ' " & dgRec.CurrentCell.Value(dgRec.CurrentCell.RowIndex, 0) & " '..?", vbYesNo + vbQuestion + vbDefaultButton2)
            '    If vbYes Then DeleteRow()
            'End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    'Private Sub DeleteRow()

    '    dgRec.RemoveItem(dgRec.CurrentCell.RowIndex)
    '    For i = 1 To dgRec.Rows.Count - 2
    '        dgRec.CurrentCell.RowIndex(i, 0) = i
    '    Next
    '    slno = i - 1
    '    If slno = 0 Then tsbSave.Enabled = False
    '    Calculate()
    '    dgRec.Focus()
    '    Exit Sub
    'End Sub

    Private Sub txtPRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRate.LostFocus
        txtPRate.Text = Format(Val(txtPRate.Text), "0.000")
    End Sub

    Private Sub txtCST_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCST.LostFocus
        txtCST.Text = Format(Val(txtCST.Text), "0.000")
    End Sub

    Private Sub txtPVat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPVat.LostFocus
        txtPVat.Text = Format(Val(txtPVat.Text), "0.00")
        Try
            cbSVat.Text = Format(Val(txtPVat.Text), "0.00")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtPDis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPDis.LostFocus
        txtPDis.Text = Format(Val(txtPDis.Text), "0.000")
    End Sub

    Private Sub txtSRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSRate.LostFocus
        txtSRate.Text = Format(Val(txtSRate.Text), "0.000")
    End Sub

    Private Sub txtRt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRt.LostFocus
        txtRt.Text = Format(Val(txtRt.Text), "0.000")
    End Sub

    Private Sub txtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.LostFocus
        txtQty.Text = Format(Val(txtQty.Text), "0")
    End Sub

    Private Sub txtFree_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFree.LostFocus
        txtFree.Text = Format(Val(txtFree.Text), "0")
    End Sub

    Private Sub txtRepl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepl.LostFocus
        txtRepl.Text = Format(Val(txtRepl.Text), "0")
    End Sub

    Private Sub txtDis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDis.LostFocus
        txtDis.Text = Format(Val(txtDis.Text), "0.00")
    End Sub

    Private Sub txtDed_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDed.GotFocus
        txtDed.SelectAll()
    End Sub

    Public Sub Calculate()
        Dim n As Integer

        Dim i, fnd, stk, pr, pdis, pro, pcst, ptax, bdis, sr, prrup, amtval, tmprnd, sch, showvalue As Double
        Try
            amtval = 0
            tmprnd = 0
            totvalue = 0
            showvalue = 0
            value = 0
            totcst = 0
            Svalue = 0
            rctadj = 0
            rtfamt = 0
            totbdis = 0
            totpdis = 0
            totcst = 0
            tottax = 0
            totcstpur = 0
            totsch = 0
            repltot = 0
            For i = 0 To 4
                rtaxary(i, 1) = 0
                rptax(i, 1) = 0
                rpcstary(i, 1) = 0
                rpcst(i, 1) = 0
            Next i

            For n = 0 To dgRec.Rows.Count - 2
                stk = 0
                value = 0
                pcst = 0
                ptax = 0
                pr = 0
                sr = 0
                Svalue = 0
                sch = 0
                stk = Val(dgRec.Item(19, n).Value)
                repltot = repltot + Val(dgRec.Item(21, n).Value) * Val(dgRec.Item(14, n).Value)
                If stk <> 0 Then

                    value = System.Math.Round((stk * Val(dgRec.Item(13, n).Value)), 2)
                    dgRec.Item(23, n).Value = Format(value, "0.00")
                    sch = Val(dgRec.Item(29, n).Value & "")
                    value = value - sch
                    totsch = totsch + sch
                    pcst = value * Val(dgRec.Item(28, n).Value) / 100
                    totcst = totcst + pcst
                    'value = value + pcst     'after pcst
                    pdis = value * Val(dgRec.Item(16, n).Value) / 100
                    totpdis = totpdis + pdis
                    value = value - pdis
                    bdis = value * Val(txtDis.Text) / 100
                    totbdis = totbdis + bdis

                    value = value - bdis     'after bill disc

                    ptax = value * Val(dgRec.Item(15, n).Value) / 100


                    If pcst <> 0 Then
                        fnd = 0
                        'For i = 0 To 4
                        'If Val(dgRec.Item(28, n).Value) = rpcstary(i, 0) Then
                        If ptax = 0 Then rpcstary(0, 1) = rpcstary(0, 1) + value
                        rpcst(0, 1) = rpcst(0, 1) + pcst
                        fnd = 1
                        ' Exit For
                        'End If
                        'Next i
                    End If


                    If Val(dgRec.Item(15, n).Value) <> 0 Then

                        fnd = 0
                        For i = 0 To 4
                            If Val(dgRec.Item(15, n).Value) = rtaxary(i, 0) Then
                                rtaxary(i, 1) = rtaxary(i, 1) + value
                                rptax(i, 1) = rptax(i, 1) + ptax
                                fnd = 1
                                Exit For
                            End If
                        Next i
                        If fnd = 0 Then
                            rtfamt = rtfamt + value + ptax
                        End If
                    ElseIf pcst = 0 Then
                        rtfamt = rtfamt + value
                    End If

                    tottax = tottax + ptax



                    value = value + ptax  'after purchase tax

                    totvalue = totvalue + value
                    dgRec.Item(30, n).Value = Round(value / Round(Val(dgRec.Item(19, n).Value & "") + Val(dgRec.Item(20, n).Value), 3), 2)
                Else
                    dgRec.Item(23, n).Value = "0.00"
                    dgRec.Item(30, n).Value = "0.00"
                End If
                'calculating after sale profit amount
                pr = Val(dgRec.Item(13, n).Value) * Val(dgRec.Item(19, n).Value & "") 'PVAL
                pr = pr - Val(dgRec.Item(29, n).Value & "") 'SCH
                pr = pr + (pr * Val(dgRec.Item(28, n).Value) / 100) 'CST
                pr = pr - (pr * Val(dgRec.Item(16, n).Value) / 100) 'PDIS
                pr = pr - (pr * Val(txtDis.Text) / 100) 'BDIS
                pr = pr + (pr * Val(dgRec.Item(15, n).Value) / 100) 'PVAT

                sr = Val(dgRec.Item(14, n).Value) * (Val(dgRec.Item(19, n).Value & "") + Val(dgRec.Item(20, n).Value & "")) 'SVAL
                If Trim(dgRec.Item(27, n).Value) = "Yes" Then
                    '    sr = sr - Round((sr * Val(dgRec.Item(26, n).Value) / (Val(dgRec.Item(26, n).Value) + 100)), 2)
                Else
                    sr = sr + (sr * Val(dgRec.Item(25, n).Value & "") / 100) 'SCST
                    sr = sr + (sr * Val(dgRec.Item(26, n).Value & "") / 100) 'SVAT
                End If


                prrup = prrup + (sr - pr) '* (Val(dgRec.Item(19, n).Value & "") + Val(dgRec.Item(20, n).Value & "")))
                If sr <> 0 Then
                    pro = Round((sr - pr) * 100 / sr, 2)

                Else
                    pro = 0
                End If
                dgRec.Item(24, n).Value = pro

            Next

            totvalue = 0

            For i = 0 To 4
                rtaxary(i, 1) = Round(rtaxary(i, 1), 2)
                rptax(i, 1) = Round(rptax(i, 1), 2)
                rpcstary(i, 1) = Round(rpcstary(i, 1), 2)
                rpcst(i, 1) = Round(rpcst(i, 1), 2)
                totvalue = totvalue + rtaxary(i, 1) + rptax(i, 1) + rpcstary(i, 1) + rpcst(i, 1)
            Next

            rtfamt = Round(rtfamt, 2)
            totvalue = totvalue + rtfamt

            rctadj = Val(txtAdd.Text) - Val(txtDed.Text)


            totvalue = Val(Format(totvalue, "0.00"))
            tottax = Val(Format(tottax, "0.00"))
            totbdis = Val(Format(totbdis, "0.00"))
            totpdis = Val(Format(totpdis, "0.00"))
            totcst = Val(Format(totcst, "0.00"))
            lblTamt.Text = Format(totvalue, "0.00")
            amtval = Format(totvalue, "0.00")
            tmprnd = Format(amtval, "0")
            txtAdd.Text = "0.00"
            txtDed.Text = "0.00"

            If Val(amtval) - Val(tmprnd) < 0 Then
                txtAdd.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            ElseIf Val(amtval) - Val(tmprnd) > 0 Then
                txtDed.Text = Format(Abs(Val(tmprnd) - Val(amtval)), "0.00")
            End If
            lblNamt.Text = Format(totvalue + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
            lblreplval.Text = Format(repltot, "0.00")
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdd.GotFocus
        txtAdd.SelectAll()
    End Sub

    Private Sub CbEditUnit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditUnit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Convert()
                dgRec.CurrentCell.Value = CbEditUnit.Text & " (" & CbEditUnit.SelectedValue & ") "
                dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value = CbEditUnit.SelectedValue
                dgRec.Item(3, dgRec.CurrentCell.RowIndex).Value = CbEditUnit.Text
                CbEditUnit.Visible = False
                dgRec.Focus()
                Calculate()
                e.Handled = True
            End If
            If e.KeyCode = Keys.Escape Then
                CbEditUnit.Visible = False
                dgRec.Focus()
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditUnit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditUnit.Leave
        CbEditUnit.Visible = False
        dgRec.Focus()
        dgRec.Enabled = True
        dgRec.Focus()
    End Sub

    Private Sub cbEditVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbEditVat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dgRec.CurrentCell.Value = cbEditVat.Text
                dgRec.Focus()
                Calculate()
                ChkProfit(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value.ToString)
                e.Handled = True
            End If
            If e.KeyCode = Keys.Escape Then
                cbEditVat.Visible = False
                dgRec.Focus()
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbEditVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEditVat.Leave
        cbEditVat.Visible = False
        dgRec.Enabled = True
        dgRec.Focus()
    End Sub

    Private Sub Convert()
        'If curunit <> 0 Then
        Try
            dgRec.Item(13, dgRec.CurrentCell.RowIndex).Value = Format((Val(dgRec.Item(13, dgRec.CurrentCell.RowIndex).Value) / Val(dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value)) * CbEditUnit.SelectedValue, "0.000")
            dgRec.Item(14, dgRec.CurrentCell.RowIndex).Value = Format((Val(dgRec.Item(14, dgRec.CurrentCell.RowIndex).Value) / Val(dgRec.Item(2, dgRec.CurrentCell.RowIndex).Value)) * CbEditUnit.SelectedValue, "0.000")
            curunit = CbEditUnit.SelectedValue
            'Else
            'curunit = CbEditUnit.SelectedValue
            'End If
            Calculate()
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtDis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDis.TextChanged
        Calculate()
    End Sub

    Private Sub txtDed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDed.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtDed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDed.TextChanged
        lblNamt.Text = Format(totvalue + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtAdd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdd.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtAdd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd.TextChanged
        lblNamt.Text = Format(totvalue + Val(txtAdd.Text) - Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtDed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDed.KeyDown
        If e.KeyCode = Keys.Enter Then
            'txtDed.Text = Format(txtDed.Text, "0.00")
            txtAdd.Focus()
            txtAdd.SelectAll()

        End If
    End Sub

    Private Sub txtDed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDed.LostFocus
        txtDed.Text = Format(Val(txtDed.Text), "0.00")
    End Sub

    Private Sub txtAdd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            'txtAdd.Focus()
            'txtAdd.SelectAll()
            ' tsbSave.Select()

        End If
    End Sub

    Private Sub txtAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdd.LostFocus
        txtAdd.Text = Format(Val(txtAdd.Text), "0.00")
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click

        If dgRec.RowCount > 1 Then
            MsgBox("Entries found. Clear the entries before editing.", vbInformation)
            Exit Sub

        End If

        Try
            txtEdit.Visible = False
            pnlDNote.Visible = False
            EditSales.lblSalno.Text = "Receipt No"
            EditSales.lblBilDt.Text = "Period "
            EditSales.Text = "Purchase Edit"


            EditSales.Text = "Purchase Editing (" & cbRtype.Text & ")"
            EditSales.txtSalNo.Focus()
            EditSales.ShowDialog()



            If EditSales.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If


            EditReceipt(EditSales.txtSalNo.Text, EditSales.dtpf.Value.Date, EditSales.dtpt.Value.Date)
            EditSales.Dispose()

        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Public Sub EditReceipt(ByVal no As String, ByVal dtf As Date, ByVal dtt As Date)
        Dim dtab As New DataTable
        Dim dtab1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim ad, ls As Double
        cmd.Connection = Conn
        Me.Cursor = Cursors.WaitCursor
        Try
            tsbSave.Enabled = True

            cmd.CommandText = "select Batch.*,Product.PrdCode,Product.PrdName,Purchase.addi," & _
                    "Purchase.ded,Purchase.BillDis,Purchase.Remark,Purchase.DueDt," & _
                    "Purchase.BillNo,AcMaster.AcCode,AcMaster.AcName from Purchase,AcMaster,Batch,Product where " & _
                    "Purchase.PDate=Batch.PDate and acmaster.accode=Purchase.supcode and  " & _
                    "Batch.RctNo=Purchase.RctNo and " & _
                    "batch.type=Purchase.Type and Product.PrdCode=Batch.PrdCode and  " & _
                    "Batch.RctNo=" & no & " and Batch.PDate>= convert(datetime,'" & _
                    CDate(dtf) & "') and Batch.PDate<= convert(datetime,'" & _
                    CDate(dtt) & "')  and  Batch.Type=  " & cbRtype.SelectedValue & " order by batchid,Batch.seq"

            Rcpts.Rows.Clear()
            Rcpts.Rows.Add()
            EditRectNo = 0
            EditRectDt = Nothing
            EditType = ""
            EditSupCode = 0
            da.SelectCommand = cmd
            da.Fill(dtab)
           
            If dtab.Rows.Count > 0 Then
                cmd.CommandText = "select Batch.*,Product.PrdCode,Product.PrdName,Purchase.addi," & _
                   "Purchase.ded,Purchase.BillDis,Purchase.Remark,Purchase.DueDt," & _
                   "Purchase.BillNo,AcMaster.AcCode,AcMaster.AcName from Purchase,AcMaster,Batch,Product where " & _
                   "Purchase.PDate=Batch.PDate and acmaster.accode=Purchase.supcode and  " & _
                   "Batch.RctNo=Purchase.RctNo and " & _
                   "batch.type=Purchase.Type and Product.PrdCode=Batch.PrdCode and  " & _
                   "Batch.RctNo=" & dtab.Rows(0).Item("rctno") & " and Batch.PDate>= convert(datetime,'" & _
                   dtab.Rows(0).Item("pdate") & "') and Batch.PDate<= convert(datetime,'" & _
                   dtab.Rows(0).Item("pdate") & "')  and  Batch.Type=  " & cbRtype.SelectedValue & " order by batchid,Batch.seq"
            End If
            dtab.Clear()
            dtab.Rows.Clear()
            Rcpts.Rows.Clear()
            Rcpts.Rows.Add()
            EditRectNo = 0
            EditRectDt = Nothing
            EditType = ""
            EditSupCode = 0
            da.SelectCommand = cmd
            da.Fill(dtab)

            If dtab.Rows.Count > 0 Then


                For i As Long = 0 To dtab.Rows.Count - 1

                    lblno.Text = dtab.Rows(i).Item("RctNo")
                    EditRectNo = dtab.Rows(i).Item("RctNo")
                    EditRectDt = dtab.Rows(i).Item("Pdate")
                    EditType = dtab.Rows(i).Item("Type")
                    EditSupCode = dtab.Rows(i).Item("supcode")

                    ad = dtab.Rows(i).Item("addi")
                    ls = dtab.Rows(i).Item("ded")

                    dgRec.Item(0, dgRec.Rows.Count - 1).Value = dgRec.Rows.Count
                    dgRec.Item(2, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Unit")
                    dgRec.Item(1, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("batchid")
                    dgRec.Item(8, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdCode")
                    dgRec.Item(9, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdName")
                    dgRec.Item(10, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("batch")
                    dgRec.Item(11, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("ExDt")
                    dgRec.Item(22, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Pack")
                    dgRec.Item(26, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Stax")

                    tmpbatid = dtab.Rows(i).Item("batchid")
                    tmpbat = dtab.Rows(i).Item("batch")

                    If (dtab.Rows(i).Item("TaxInc")) = 0 Then
                        dgRec.Item(27, dgRec.Rows.Count - 1).Value = "No"
                    Else
                        dgRec.Item(27, dgRec.Rows.Count - 1).Value = "Yes"
                    End If
                    dgRec.Item(13, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PRate")) * Val(dtab.Rows(i).Item("unit")), "0.00")
                    dgRec.Item(14, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("SRate")) * Val(dtab.Rows(i).Item("unit")), "0.00")
                    dgRec.Item(15, dgRec.Rows.Count - 1).Value = Format(dtab.Rows(i).Item("Ptax"), "0.00")
                    dgRec.Item(16, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PDis")), "0.00")
                    dgRec.Item(19, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("RQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(20, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("FQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(21, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("RepQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(25, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("SCST")), "0.00")
                    dgRec.Item(28, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PCST")), "0.00")
                    dgRec.Item(29, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("psch")), "0.00")
                    If dgRec.Rows.Count = 1 Then
                        cbSupp.SelectedValue = dtab.Rows(i)("Supcode")
                        txtBilno.Text = dtab.Rows(i)("BillNo")
                        txtDis.Text = dtab.Rows(i)("BDis")
                        txtBildat.Text = dtab.Rows(i)("BillDt")
                        txtDuedat.Text = dtab.Rows(i)("DueDt") & ""
                        txtRmk.Text = dtab.Rows(i)("Remark")
                        lblno.Text = dtab.Rows(i)("RctNo")
                        cbRtype.SelectedValue = dtab.Rows(i)("Type")
                        lbldt.Text = Format(dtab.Rows(i)("PDATE"), "dd/MM/yyyy")
                    End If

                    dgRec.Update()
                    Rcpts.Rows.Add()
                Next

            Else
                MsgBox("Purchase entry not found..", MsgBoxStyle.Information)
                Me.Cursor = Cursors.Default

                Exit Sub

            End If



            EditVouNo = 0
            EditSupCode = 0
            cmd.CommandText = "select vouno,pamt,accode,ISNULL(dispute,0) AS dispute from ledger where trntype='Pu' and " & _
                "trndate=convert(datetime,'" & EditRectDt & "' ) and " & _
                "InvCode='" & EditType & EditRectNo & "' and  seq=1"
            da.SelectCommand = cmd
            da.Fill(dtab1)


            If dtab1.Rows.Count > 0 Then

                EditVouNo = dtab1.Rows(0).Item("vouno")
                EditSupCode = dtab1.Rows(0).Item("accode")
                chkBlockPay.Checked = dtab1.Rows(0).Item("dispute")
                If Val(dtab1.Rows(0).Item("pamt") & "") <> 0 Then
                    cbSupp.Enabled = False
                    cbRtype.Enabled = False
                Else
                    cbSupp.Enabled = True
                    cbRtype.Enabled = True
                End If
            End If


            cmd.CommandText = "select BatchRtn.*,Product.PrdCode,Product.PrdName,Purchase.addi," & _
                "Purchase.ded,Purchase.BillDis,Purchase.Remark,Purchase.DueDt," & _
                "Purchase.BillNo,AcMaster.AcCode,AcMaster.AcName from Purchase," & _
                "AcMaster,BatchRtn,Product where Purchase.PDate=BatchRtn.PDate and " & _
                "acmaster.accode=Purchase.supcode and BatchRtn.RctNo=Purchase.RctNo and " & _
                "BatchRtn.type=Purchase.Type and Product.PrdCode=BatchRtn.PrdCode and " & _
                "BatchRtn.RctNo=" & no & " and BatchRtn.PDate>=convert(datetime,'" & EditRectDt & _
                "') and BatchRtn.PDate<=convert(datetime,'" & EditRectDt & _
                "') and BatchRtn.Type=" & cbRtype.SelectedValue & " order by Batchid"
            dtab.Clear()
            da.Fill(dtab)

            If dtab.Rows.Count > 0 Then
                For i As Long = 0 To dtab.Rows.Count - 1

                    'lblno.Text = dtab.Rows(i).Item("RctNo")
                    'EditRectNo = dtab.Rows(i).Item("RctNo")
                    'EditRectDt = dtab.Rows(i).Item("Pdate")
                    'EditType = dtab.Rows(i).Item("Type")
                    dgRec.Item(0, dgRec.Rows.Count - 1).Value = dgRec.Rows.Count
                    dgRec.Item(2, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Unit")
                    dgRec.Item(4, dgRec.Rows.Count - 1).Value = IIf(dtab.Rows(i).Item("StkLes"), 1, 0)
                    dgRec.Item(1, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("batchid")
                    dgRec.Item(8, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdCode")
                    dgRec.Item(9, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("PrdName")
                    dgRec.Item(10, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("batch")
                    dgRec.Item(11, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("ExDt")
                    dgRec.Item(22, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Pack")
                    dgRec.Item(26, dgRec.Rows.Count - 1).Value = dtab.Rows(i).Item("Stax")
                    tmpbatid = dtab.Rows(i).Item("batchid")
                    tmpbat = dtab.Rows(i).Item("batch")

                    If (dtab.Rows(i).Item("TaxInc")) = 0 Then
                        dgRec.Item(27, dgRec.Rows.Count - 1).Value = "No"
                    Else
                        dgRec.Item(27, dgRec.Rows.Count - 1).Value = "Yes"
                    End If

                    'dgRec.Item(12, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("PCST")), "0.000")
                    dgRec.Item(13, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PRate")) * Val(dtab.Rows(i).Item("unit")), "0.00")
                    dgRec.Item(14, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("SRate")) * Val(dtab.Rows(i).Item("unit")), "0.00")
                    dgRec.Item(15, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("Ptax")), "0.00")
                    dgRec.Item(16, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PDis")), "0.00")
                    dgRec.Item(19, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("RQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(20, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("FQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(21, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("RepQty")) / Val(dtab.Rows(i).Item("unit")), "0")
                    dgRec.Item(25, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("SCST")), "0.00")
                    dgRec.Item(28, dgRec.Rows.Count - 1).Value = Format(Val(dtab.Rows(i).Item("PCST")), "0.00")

                    If dtab.Rows(i).Item("StkLes") = "True" Then
                        dgRec.Item(19, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                        dgRec.Item(20, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                        dgRec.Item(21, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Red
                    Else
                        dgRec.Item(19, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon
                        dgRec.Item(20, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon
                        dgRec.Item(21, dgRec.CurrentCell.RowIndex).Style.ForeColor = Color.Maroon

                    End If


                    'If dgRec.Rows.Count = 1 Then
                    '    cbSupp.SelectedValue = dataredr("Supcode")
                    '    txtBilno.Text = dataredr("BillNo")
                    '    txtDis.Text = dataredr("BDis")
                    '    txtBildat.Text = dataredr("BillDt")
                    '    txtDuedat.Text = dataredr("DueDt") & ""
                    '    txtRmk.Text = dataredr("Remark")
                    '    lblno.Text = dataredr("RctNo")
                    '    cbRtype.SelectedValue = dataredr("Type")
                    'End If
                    dgRec.Update()
                    Rcpts.Rows.Add()
                Next
            End If

            EditFlag = True
            Calculate()
            txtAdd.Text = Format(ad, "0.00")
            txtDed.Text = Format(ls, "0.00")
            pnlCmpVal.Visible = False
            CompareValue = False
            dgRec.Enabled = True
            dgRec.CurrentCell = dgRec.Item(9, dgRec.RowCount - 1)
            dgRec.Focus()
            ' dgRec.ColumnHeadersDefaultCellStyle.Font = New Font(dgRec.ColumnHeadersDefaultCellStyle.Font, FontStyle.Regular)
        Catch er As Exception
            Me.Cursor = Cursors.Default
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtBilno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBilno.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtBildat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBildat.KeyDown
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader

        If e.KeyCode = Keys.Enter Then
            Try


                If cbSupp.SelectedValue <> Nothing Then
                    If IsDate(txtBildat.Text) Then
                        cmd.Connection = Conn
                        cmd.CommandText = "select rctno,pdate from batch where supcode=" & _
                    cbSupp.SelectedValue & " and billno=""" + txtBilno.Text & """ and " & _
                        "billdt='" & Format(CDate(txtBildat.Text), "yyyyMMdd") & "'"
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Read()
                            MsgBox("Bill already entered.. Rcpt No." & dr("rctno") & " dated " & dr("pdate"), MsgBoxStyle.Information)
                            ClearForm()
                        End If
                        dr.Close()
                    End If

                End If

                System.Windows.Forms.SendKeys.Send("{TAB}")

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txtDuedat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDuedat.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgRec.CurrentCell.Selected = True
            EditGrid()
        End If
    End Sub

    Private Sub cbSVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbSVat.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbTaxInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbTaxInc.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub ChkProfit(ByVal cd As String, Optional ByVal flg As Boolean = False, Optional ByVal rid As Integer = -1)
        Dim cmd As New OleDb.OleDbCommand
        Dim x
        Dim i As Integer
        If rid = -1 Then
            i = dgRec.CurrentCell.RowIndex
        Else
            i = rid
        End If
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select batch.*,acmaster.acname,acmaster.place  from batch,acmaster where acmaster.accode=batch.supcode and prdcode=""" + cd + """ and (type='11' or type='12') and supcode<>0 and profit <>0 order by batchid desc "
            'ProdSelected = True
            dgRec.Item(0, i).Style.BackColor = Color.White
            dgRec.Item(24, i).Style.ForeColor = Color.Black
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()


            If dataredr.HasRows Then
                dataredr.Read()

                If Abs(dataredr.Item("Profit") - Val(dgRec.Item(24, i).Value)) > 0.5 Then
                    If flg = False Then
                        x = MsgBox("Difference in profit margin ..!" & Chr(13) & _
                        "Previous Margin: " & dataredr.Item("Profit") & " %" & Chr(13) & _
                        "Current  Margin: " & Val(dgRec.Item(24, i).Value) & " %" & Chr(13) & _
                        "Difference: " & Format(Val(dgRec.Item(24, i).Value) - dataredr.Item("Profit"), "0.00") & " %" & _
                        Chr(13) & Chr(13) & "Last Purchase Details:- " & Chr(13) & _
                       "    " & dataredr.Item("Acname") & ", " & dataredr.Item("place") & _
                       Chr(13) & "    Bill No.: " & _
                       dataredr.Item("billno") & "  Dt.: " & dataredr.Item("billdt") & Chr(13) & _
                        "    Rct No.: " & dataredr.Item("RctNo") & "   Dt.: " & Format(dataredr.Item("pdate"), DateFormat) & Chr(13) & Chr(13) & _
                        "    PRate: " & Format(dataredr.Item("prate") * dataredr.Item("unit"), "0.000") & "  P.CST: " & _
                        Format(dataredr.Item("pcst"), "0.00") & "%" & _
                        "  P.Dis: " & dataredr.Item("pdis") & _
                        "  P.VAT: " & Format(dataredr.Item("ptax"), "0.00") & "%" & Chr(13) & _
                        "    SRate: " & Format(dataredr.Item("srate") * dataredr.Item("unit"), "0.000") & "  S.CST: " & _
                        Format(dataredr.Item("scst"), "0.00") & "%" & _
                        "  S.VAT: " & Format(dataredr.Item("stax"), "0.00") & "%" & Chr(13) & _
                        "    Qty  : " & Format(dataredr.Item("rqty") / dataredr.Item("unit"), "0") & _
                        "  Free: " & Format(dataredr.Item("fqty") / dataredr.Item("unit"), "0") & _
                        "   Packing: " & dataredr.Item("pack") & "(" & dataredr.Item("unit") & ")", MsgBoxStyle.Exclamation)

                    End If
                    If Val(dgRec.Item(24, i).Value) - dataredr.Item("Profit") < 0 Then
                        dgRec.Item(0, i).Style.BackColor = Color.Red
                        dgRec.Item(24, i).Style.ForeColor = Color.Red
                    Else
                        dgRec.Item(0, i).Style.BackColor = Color.Blue
                        dgRec.Item(24, i).Style.ForeColor = Color.Blue
                    End If
                End If

            End If


            dataredr.Close()

        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgRec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRec.LostFocus
        dgRec.CurrentCell.Selected = False
    End Sub

    Private Sub dgRec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRec.GotFocus
        dgRec.CurrentCell.Selected = True
    End Sub

    Private Sub txtExDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExDt.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Not ExpDateCheck(txtExDt, False) Then
                txtExDt.Focus()
                txtExDt.SelectAll()
                Exit Sub
            End If
            cbPUnit.Focus()
        End If

    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        chkstkded.Visible = (Val(txtQty.Text) < 0 Or Val(txtFree.Text) < 0 Or Val(txtRepl.Text) < 0)
    End Sub

    Private Sub txtFree_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFree.TextChanged
        chkstkded.Visible = (Val(txtQty.Text) < 0 Or Val(txtFree.Text) < 0 Or Val(txtRepl.Text) < 0)
    End Sub

    Private Sub txtRepl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepl.TextChanged
        chkstkded.Visible = (Val(txtQty.Text) < 0 Or Val(txtFree.Text) < 0 Or Val(txtRepl.Text) < 0)
    End Sub

    Private Sub txtBildat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBildat.Validating
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim cday As Long
            If cbSupp.SelectedValue = Nothing Then Exit Sub
            If DateCheck(txtBildat, True) = False Then
                e.Cancel = True
            Else

                If cbRtype.SelectedValue = "12" Then
                    If IsDate(txtBildat.Text) Then
                        cmd.Connection = Conn
                        cmd.CommandText = "select Crday from acmaster where accode=" & cbSupp.SelectedValue
                        cday = cmd.ExecuteScalar
                        txtDuedat.Text = Format(DateAdd(DateInterval.Day, cday, CDate(txtBildat.Text)), DateFormat)
                        txtDuedat.Tag = cday
                    End If
                ElseIf cbRtype.SelectedValue = "11" Then
                    txtDuedat.Text = txtBildat.Text
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtDuedat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDuedat.Validating
        If DateCheck(txtDuedat, True) = False Then e.Cancel = False
    End Sub

    Private Sub cbSupp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSupp1.SelectedIndexChanged
        If cbSupp1.Tag = "Y" Then Exit Sub
        GridClick(True)
    End Sub

    Private Sub GridClick(Optional ByVal chk As Boolean = False)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim i As Integer
        Dim sqlt As String
        Try
            cmd.Connection = Conn
            sqlt = ""
            Select Case cbSupp1.SelectedIndex
                Case 0
                    sqlt = " and  batch.supcode=" & Val(cbSupp.SelectedValue & "")
                Case 1
                    sqlt = ""
            End Select

            'MsgBox(dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value)
            cmd.CommandText = "Select  Batch,exdt as [Expiry],CONVERT(numeric(10,3),(PRate*unit)) as " & _
                " [PRate],convert(numeric(10,3),(SRate*unit)) as [SRate] ,Ptax as [P VAT],Pdis [PDisc], " & _
                "convert(int,(Rqty/unit)) as [Rct Qty],convert(int,(Fqty*unit)) as [Free Qty.], " & _
                "convert(int,(RepQty/unit)) as [Repl Qty],Stock,Pack,Profit,Scst as [RT], " & _
                "Stax as [S VAT],case batch.taxinc when 1 then 'Yes' when 0 then 'No' end  as [Tax Inc], " & _
                "Pcst as [P CST],Unit,Batchid,(acmaster.acname +  ' ' + acmaster.place) as [Supplier]  from Batch,acmaster where batch.supcode=acmaster.accode and prdcode=""" + (dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value & "") & _
                """" & sqlt & " order by Batchid desc "

            'cmd.CommandText = "Select Batch.batch,Exdt as [Expiry],(Prate*unit) as [PRate],(Srate*unit) as [Srate] ,Ptax as [PVAT],Pdis [PDisc],(Rqty/unit) as [RctQty],(Fqty*unit) as [Free],[RepQty/unit] as [ReplQty],Pack,Profit,Scst as [RT],Stax as [SVAT],iif(TaxInc,'Yes','No') as [Tax Inc],Pcst as [P CST],unit from batch order by batchid "

            da.SelectCommand = cmd
            da.Fill(ds, "Supp")

            If Not chk Then
                If ds.Tables("Supp").Rows.Count = 0 Then
                    cbSupp1.Tag = "Y"
                    cbSupp1.SelectedIndex = 1
                    cbSupp1.Tag = ""
                    sqlt = ""
                    cmd.CommandText = "Select  Batch,exdt as [Expiry],CONVERT(numeric(10,3),(PRate*unit)) as " & _
                       " [PRate],convert(numeric(10,3),(SRate*unit)) as [SRate] ,Ptax as [P VAT],Pdis [PDisc], " & _
                       "convert(int,(Rqty/unit)) as [Rct Qty],convert(int,(Fqty*unit)) as [Free Qty.], " & _
                       "convert(int,(RepQty/unit)) as [Repl Qty],Stock,Pack,Profit,Scst as [RT], " & _
                       "Stax as [S VAT],case batch.taxinc when 1 then 'Yes' when 0 then 'No' end  as [Tax Inc], " & _
                       "Pcst as [P CST],Unit,Batchid,(acmaster.acname +  ' ' + acmaster.place) as [Supplier]  from Batch,acmaster where batch.supcode=acmaster.accode and prdcode=""" + (dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value & "") & _
                       """" & sqlt & " order by Batchid desc "

                    da.Fill(ds, "Supp")
                End If
            End If


            dgSupp.DataSource = ds.Tables("Supp")


            dgSupp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            For i = 2 To dgSupp.ColumnCount - 1

                dgSupp.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Next i
            txtQty.Tag = 0
            If dgSupp.Rows.Count <= 0 Then
                cmd.CommandText = "Select case1,case2,case3,unit1,unit2,unit3,srate,prate,cst,st,case taxinc when 1 then 'Yes' when 0 then 'No' end  as [TaxInc] from product where prdcode=""" + dgRec.Item(8, dgRec.CurrentCell.RowIndex).Value + """ "
                Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                If dataredr.HasRows Then
                    dataredr.Read()
                    curunit = 1

                    txtBatch.Text = ""
                    txtExDt.Text = DateBlank

                    'txtCST.Text = Format(dataredr.Item("Srate"), "0.000")

                    txtPVat.Text = Format(dataredr.Item("st"), "0.00")
                    'txtPDis.Text = dgSupp.Item(5, dgSupp.CurrentCell.RowIndex).Value

                    'txtRt.Text = dgSupp.Item(11, dgSupp.CurrentCell.RowIndex).Value
                    cbSVat.Text = Format(dataredr.Item("st"), "0.00")

                    cbTaxInc.Text = "Yes" ''dataredr.Item("taxinc")
                    txtQty.Tag = ""
                    If dataredr.Item("unit2") <> 0 Then
                        cbPUnit.SelectedValue = Round(dataredr.Item("unit2"), 0)
                        curunit = Round(dataredr.Item("unit2"), 0)
                    Else
                        cbPUnit.SelectedValue = Round(dataredr.Item("unit1"), 0)
                        curunit = Round(dataredr.Item("unit1"), 0)
                    End If

                    txtPRate.Text = Format(dataredr.Item("Prate") * Val(cbPUnit.SelectedValue), "0.000")
                    txtSRate.Text = Format(dataredr.Item("Srate") * Val(cbPUnit.SelectedValue), "0.000")
                End If
                dataredr.Close()
            Else

                dgSupp.CurrentCell = dgSupp.Item(0, 0)
                'cbPUnit.SelectedValue = Val(dgSupp.Item(15, dgSupp.CurrentCell.RowIndex).Value)
                'txtBatch.Text = dgSupp.Item(0, dgSupp.CurrentCell.RowIndex).Value
                'If IsDate(dgSupp.Item(1, dgSupp.CurrentCell.RowIndex).Value) Then
                '    txtExDt.Text = Format(dgSupp.Item(1, dgSupp.CurrentCell.RowIndex).Value, DateFormat)
                'Else
                '    txtExDt.Text = DateBlank
                'End If

                'txtPRate.Text = dgSupp.Item(2, dgSupp.CurrentCell.RowIndex).Value
                'txtSRate.Text = dgSupp.Item(3, dgSupp.CurrentCell.RowIndex).Value
                'txtCST.Text = dgSupp.Item(14, dgSupp.CurrentCell.RowIndex).Value

                'txtPVat.Text = dgSupp.Item(4, dgSupp.CurrentCell.RowIndex).Value
                'txtPDis.Text = dgSupp.Item(5, dgSupp.CurrentCell.RowIndex).Value

                'txtRt.Text = dgSupp.Item(11, dgSupp.CurrentCell.RowIndex).Value
                'cbSVat.Text = dgSupp.Item(12, dgSupp.CurrentCell.RowIndex).Value

                'cbTaxInc.Text = dgSupp.Item(13, dgSupp.CurrentCell.RowIndex).Value
                'txtQty.Tag = dgSupp.Item(16, dgSupp.CurrentCell.RowIndex).Value
            End If

        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgSupp_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSupp.CellEnter
        Try
            cbPUnit.SelectedValue = Round(dgSupp.Item(16, dgSupp.CurrentCell.RowIndex).Value, 0)
            txtBatch.Text = dgSupp.Item(0, dgSupp.CurrentCell.RowIndex).Value
            If IsDate(dgSupp.Item(1, dgSupp.CurrentCell.RowIndex).Value) Then
                txtExDt.Text = Format(dgSupp.Item(1, dgSupp.CurrentCell.RowIndex).Value, DateFormat)
            Else
                txtExDt.Text = DateBlank
            End If

            txtPRate.Text = dgSupp.Item(2, dgSupp.CurrentCell.RowIndex).Value
            txtSRate.Text = dgSupp.Item(3, dgSupp.CurrentCell.RowIndex).Value
            txtCST.Text = dgSupp.Item(15, dgSupp.CurrentCell.RowIndex).Value

            txtPVat.Text = dgSupp.Item(4, dgSupp.CurrentCell.RowIndex).Value
            txtPDis.Text = dgSupp.Item(5, dgSupp.CurrentCell.RowIndex).Value

            txtRt.Text = dgSupp.Item(12, dgSupp.CurrentCell.RowIndex).Value

            cbSVat.Text = dgSupp.Item(13, dgSupp.CurrentCell.RowIndex).Value

            cbTaxInc.Text = dgSupp.Item(14, dgSupp.CurrentCell.RowIndex).Value
            txtQty.Tag = dgSupp.Item(17, dgSupp.CurrentCell.RowIndex).Value
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEdit.Validating
        'txtEdit.Visible = False
        'pnlprod.Visible = False
    End Sub

    Private Sub panPur_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panPur.Paint
        If panPur.Visible = True Then
            tsbSave.Enabled = False
            'tsbEdit.Enabled = False
            'tsbCopy.Enabled = False
            'tsbClear.Enabled = False
        Else
            tsbSave.Enabled = True
            'tsbEdit.Enabled = True
            'tsbCopy.Enabled = True
            'tsbClear.Enabled = True
        End If
    End Sub

    Private Function BatchSave(ByVal i As Integer) As Boolean

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim nextid, nextseq As Integer
        Dim nStk, oRqty, oFree, oRepl, oStk, CunsQty As Double
        Dim sqlexdt, sql, sqlbdt, sqlddt, sqldldt As String
        Dim rflag, rtype As String

        cmd.Transaction = Trans
        cmd.Connection = Conn

        If Not IsDate(txtBildat.Text) Then
            sqlbdt = "NULL"
        Else
            sqlbdt = "'" & txtBildat.Text & "'"
        End If

        If Not IsDate(txtDuedat.Text) Then
            sqlddt = "NULL"
        Else
            sqlddt = "'" & txtDuedat.Text & "'"
        End If

        If Not IsDate(dgRec.Item(11, i).Value) Then
            sqlexdt = "NULL"
        Else
            sqlexdt = "'" & dgRec.Item(11, i).Value & "'"
        End If
        sqldldt = "NULL"

        If Val(dgRec.Item(1, i).Value & "") <> 0 Then
            nStk = 0
            cmd.CommandText = "select rqty,fqty,repqty,stock,type,flag,pdate from Batch where batchid=" & Val(dgRec.Item(1, i).Value)
            da.SelectCommand = cmd
            da.Fill(dt)


            rflag = "R"
            rtype = cbRtype.SelectedValue

            If dt.Rows.Count <> 0 Then
                oRqty = dt.Rows(0).Item("Rqty")
                oFree = dt.Rows(0).Item("Fqty")
                oRepl = dt.Rows(0).Item("RepQty")
                oStk = dt.Rows(0).Item("Stock")
                CunsQty = (oRqty + oFree + oRepl) - oStk

                nStk = (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) * Val(dgRec.Item(2, i).Value)

                nStk = nStk - CunsQty
                If nStk < 0 Then
                    Trans.Rollback()
                    MsgBox("Insufficient Stock : " & dgRec.Item(9, i).Value & ". Can't Deduct the Qty.")
                    nStk = 0
                    BatchSave = False
                    Exit Function
                End If

                If dt.Rows(0).Item("Type") = "13" And cbRtype.SelectedValue <> "13" Then
                    rflag = "RD"
                    sqldldt = "'" & dt.Rows(0).Item("pdate") & "'"
                Else
                    rflag = dt.Rows(0).Item("flag") & ""
                End If
            End If

            cmd.CommandText = "insert into dlnoteadj  select * from batch where batch.batchid=" & Val(dgRec.Item(1, i).Value)
            cmd.ExecuteNonQuery()


            sql = "Update Batch set batch=""" & dgRec.Item(10, i).Value & _
                """,PRate= " & Round(Val(dgRec.Item(13, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                ",PCST=" & Val(dgRec.Item(28, i).Value) & _
                ",Ptax= " & Val(dgRec.Item(15, i).Value) & _
                ",PDis= " & Val(dgRec.Item(16, i).Value) & _
                ",SRate=" & Round(Val(dgRec.Item(14, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                ",SCST=" & Val(dgRec.Item(25, i).Value) & _
                ",Stax= " & Val(dgRec.Item(26, i).Value) & _
                ",TaxInc=" & IIf(dgRec.Item(27, i).Value = "Yes", 1, 0) & _
                ",PrdCode= """ & dgRec.Item(8, i).Value & _
                """,Exdt=" & sqlexdt & ",Profit =" & Val(dgRec.Item(24, i).Value) & _
                ",Pack=""" & Microsoft.VisualBasic.Left(dgRec.Item(22, i).Value, 20) & _
                """,Unit=" & Val(dgRec.Item(2, i).Value) & _
                ",Rqty=" & Round(Val(dgRec.Item(19, i).Value) * Val(dgRec.Item(2, i).Value), 0) & _
                ",Fqty=" & Round(Val(dgRec.Item(20, i).Value) * Val(dgRec.Item(2, i).Value), 0) & _
                ",RepQty=" & Round(Val(dgRec.Item(21, i).Value) * Val(dgRec.Item(2, i).Value), 0) & _
                ",Stock=" & nStk & ",BDis=" & Val(txtDis.Text) & ",BillNo=""" & txtBilno.Text & _
                """,BillDt=" & sqlbdt & ",Type=" & Val(cbRtype.SelectedValue) & _
                ",SupCode=" & Val(cbSupp.SelectedValue) & _
                ",psch=" & Val(dgRec.Item(29, i).Value) & ",Pdate='" & RcptDt & _
                "',flag='" & rflag & "',rctno=" & RcptNum & _
                ",TrRate=" & Round(Val(dgRec.Item(30, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                ",Dldt=" & sqldldt & _
                ",unac=" & IIf(Val(cbRtype.SelectedValue) = 15, 1, 0) & " where batchid=" & Val(dgRec.Item(1, i).Value)
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Else

            cmd.CommandText = "select max(batchid) from batch "
            da.SelectCommand = cmd
            da.Fill(dt1)



            nextid = 1
            If dt1.Rows.Count <> 0 Then
                nextid = Val(dt1.Rows(0).Item(0) & "") + 1
                dt1.Rows.Clear()
            End If

            If cbRtype.SelectedValue = "13" Then
                rflag = "D"
            Else
                rflag = "R"
            End If

            cmd.CommandText = "select max(seq) from batch where Prdcode=""" + dgRec.Item(8, i).Value + """"
            da.SelectCommand = cmd
            da.Fill(dt1)
            nextseq = 1

            If dt1.Rows.Count <> 0 Then
                nextseq = Val(dt1.Rows(0).Item(0) & "") + 1
            End If


            sql = "insert into Batch(batch,Prate,PCST,Ptax,PDis,SRate,SCST," & _
                "Stax,TaxInc,PrdCode,ExDt,Profit,Pack,Unit,RQty,FQty,RepQty,Stock,BDis,BillNo,BillDt," & _
                "RctNo,Type,SupCode,PDate,Lock,SDis,batchid,seq,flag,BrkQty,SSch,TrRate,psch,wcode,unac) Values(""" & _
                dgRec.Item(10, i).Value & """," & Round(Val(dgRec.Item(13, i).Value) / Val(dgRec.Item(2, i).Value), 4) & "," & _
                Val(dgRec.Item(28, i).Value) & "," & Val(dgRec.Item(15, i).Value) & _
                "," & Val(dgRec.Item(16, i).Value) & "," & Round(Val(dgRec.Item(14, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                "," & Val(dgRec.Item(25, i).Value) & "," & Val(dgRec.Item(26, i).Value) & _
                "," & IIf(dgRec.Item(27, i).Value = "Yes", 1, 0) & _
                ",""" & dgRec.Item(8, i).Value & """," & sqlexdt & "," & Val(dgRec.Item(24, i).Value) & _
                ",""" & Microsoft.VisualBasic.Left(dgRec.Item(22, i).Value & "", 20) & """," & Val(dgRec.Item(2, i).Value) & _
                "," & Round(Val(dgRec.Item(19, i).Value) * Val(dgRec.Item(2, i).Value), 0) & _
                "," & Round(Val(dgRec.Item(20, i).Value) * Val(dgRec.Item(2, i).Value), 0) & _
                "," & Round(Val(dgRec.Item(21, i).Value) * Val(dgRec.Item(2, i).Value), 0) & "," & _
                Round((Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) * Val(dgRec.Item(2, i).Value), 0) & _
                "," & Val(txtDis.Text) & ",""" & txtBilno.Text & """," & sqlbdt & _
                "," & RcptNum & ",'" & cbRtype.SelectedValue & "'," & Val(cbSupp.SelectedValue) & _
                ",'" & lbldt.Text & "',0,0," & nextid & "," & nextseq & ",'" & rflag & "',0,0," & _
                Round(Val(dgRec.Item(30, i).Value & "") / Val(dgRec.Item(2, i).Value), 4) & "," & Val(dgRec.Item(29, i).Value & "") & _
                ",""" & dgRec.Item(5, i).Value & """," & IIf(Val(cbRtype.SelectedValue) = 15, 1, 0) & ")"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Update_ShortItem"
            cmd.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = dgRec.Item(8, i).Value
            cmd.Parameters.Add("@flg", OleDb.OleDbType.Boolean).Value = 0
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.Text

        End If
        BatchSave = True
    End Function

    Private Function BatchRtnSave(ByVal i As Integer) As Boolean
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Dim AvlQty, nstk As Double
        Dim sqlexdt, sql, sqlbdt, sqlddt As String

        cmd.Transaction = Trans
        cmd.Connection = Conn


        If Not IsDate(txtBildat.Text) Then
            sqlbdt = "NULL"
        Else
            sqlbdt = "'" & txtBildat.Text & "'"
        End If

        If Not IsDate(txtDuedat.Text) Then
            sqlddt = "NULL"
        Else
            sqlddt = "'" & txtDuedat.Text & "'"
        End If

        If Not IsDate(dgRec.Item(11, i).Value) Then
            sqlexdt = "NULL"
        Else
            sqlexdt = "'" & dgRec.Item(11, i).Value & "'"

        End If

        If Val(dgRec.Item(4, i).Value & "") <> 0 Then
            cmd.CommandText = "select stock from Batch where batchid=" & Val(dgRec.Item(1, i).Value)
            da.SelectCommand = cmd
            da.Fill(dt)

            nstk = (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) * Val(dgRec.Item(2, i).Value)
            If dt.Rows.Count <> 0 Then

                AvlQty = dt.Rows(0).Item("stock")
                If AvlQty < nstk Then
                    Trans.Rollback()
                    MsgBox("Insufficient Stock : " & dgRec.Item(9, i).Value)
                    nstk = 0
                    BatchRtnSave = False
                    Exit Function
                End If
            End If

            cmd.CommandText = "update batch set stock=stock-" & Abs(nstk) & " from Batch where batchid=" & Val(dgRec.Item(1, i).Value)
            cmd.ExecuteNonQuery()
        Else


        End If



        sql = "insert into BatchRtn (batch,Prate,PCST,Ptax,PDis,SRate,SCST," & _
            "Stax,TaxInc,PrdCode,ExDt,Profit,Pack,Unit,RQty,FQty,RepQty,Stock,BDis,BillNo,BillDt," & _
            "RctNo,Type,SupCode,PDate,OutGo,Lock,SDis,PrevMonth,batchid,seq,flag,Psch,BrkQty,Ssch,TrRate,StkLes) Values(""" & _
            dgRec.Item(10, i).Value & """," & Round(Val(dgRec.Item(13, i).Value) / Val(dgRec.Item(2, i).Value & ""), 4) & "," & _
            Val(dgRec.Item(28, i).Value) & "," & Val(dgRec.Item(15, i).Value) & _
            "," & Val(dgRec.Item(16, i).Value) & "," & Round(Val(dgRec.Item(14, i).Value) / Val(dgRec.Item(2, i).Value & ""), 4) & _
            "," & Val(dgRec.Item(25, i).Value) & "," & Val(dgRec.Item(26, i).Value) & _
            "," & IIf(dgRec.Item(27, i).Value = "Yes", 1, 0) & _
            ",""" & dgRec.Item(8, i).Value & """," & sqlexdt & "," & Val(dgRec.Item(24, i).Value) & _
            ",""" & dgRec.Item(22, i).Value & """," & Val(dgRec.Item(2, i).Value & "") & _
            "," & Val((dgRec.Item(19, i).Value) * Val(dgRec.Item(2, i).Value & "")) & "," & (Val(dgRec.Item(20, i).Value) * Val(dgRec.Item(2, i).Value & "")) & _
            "," & (Val(dgRec.Item(21, i).Value) * Val(dgRec.Item(2, i).Value & "")) & "," & _
            (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) & _
            "," & Val(txtDis.Text) & ",""" & txtBilno.Text & """," & sqlbdt & _
            "," & RcptNum & "," & Val(cbRtype.SelectedValue) & "," & Val(cbSupp.SelectedValue) & _
            ",'" & RcptDt & "',0,0,0,0," & Val(dgRec.Item(1, i).Value) & ",0,'R',0,0,0,0," & Val(dgRec.Item(4, i).Value & "") & ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Function

    Private Sub dgSupp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSupp.CellClick
        'cbPUnit.SelectedIndex = 1
    End Sub

    Private Sub DeliveryDisplay()
        'Dim dataredr As OleDb.OleDbDataReader
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim i As Integer
        If Val(cbRtype.SelectedValue) = 13 Then Exit Sub

        If cbSupp.SelectedValue = Nothing Then Exit Sub
        Try

            Me.Cursor = Cursors.WaitCursor

            cmd.CommandText = "Select 'No' as [Adj   ], billno as [Slip No  ],billdt as [Slip Date  ] ,Batch,batch.EXDT  as [Expiry   ]," & _
                              "Product.PrdName as [Product],convert(int,(Rqty/unit)) as [Rcvd Qty],convert(int,(Fqty/unit)) as [Free], " & _
                              "convert(int,(RepQty/unit)) as [Repl Qty],Stock,Pack as [Packing],Profit,Scst, " & _
                              "Stax as [Svat],Case batch.taxinc when 1 then 'Yes' when 0 then 'No' end as [Tax Inc], " & _
                              "Pcst,Unit,Batchid from batch,Product where Product.Prdcode=Batch.Prdcode and flag='D' and type='13'and supcode=" & cbSupp.SelectedValue



            DA.SelectCommand = cmd
            DA.Fill(DS, "DevNt")

            dgDN.DataSource = DS.Tables("DevNt")
            dgDN.Columns(0).Width = 50  'Adj
            dgDN.Columns(1).Width = 50  'PslipNo 
            dgDN.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(2).Width = 100  'PSlipDate
            dgDN.Columns(3).Width = 80  'Batch
            dgDN.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(4).Width = 100
            dgDN.Columns(5).Width = 265 'Product

            dgDN.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(6).Width = 80  'Rcvd Qty
            dgDN.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(7).Width = 80  'Free
            dgDN.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(8).Width = 80  'Repl Qty
            dgDN.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(9).Width = 80  'Stock
            dgDN.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(10).Width = 100 'Packing
            dgDN.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgDN.Columns(11).Visible = False  'Profit
            dgDN.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(12).Visible = False
            dgDN.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(13).Width = 40 'Stax
            dgDN.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(14).Width = 40 'TaxInc
            dgDN.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDN.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgDN.Columns(15).Visible = False
            dgDN.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgDN.Columns(16).Visible = False
            dgDN.Columns(17).Visible = False

            'dgDN.Columns(16).Width = 40 'Unit
            'dgDN.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgDN.Columns(17).Width = 50 'Batchid
            'dgDN.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i = 0 To 17
                dgDN.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                'dgDN.Columns(i).DefaultCellStyle.BackColor = Color.Navy
                'dgDN.Columns(i).DefaultCellStyle.ForeColor = Color.Yellow
            Next i

            If dgDN.RowCount <> 0 Then
                pnlDNote.Visible = True
                dgDN.Focus()
            Else
                pnlDNote.Visible = False
            End If
            Me.Cursor = Cursors.Default
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDnOK.Click
        pnlDNote.Visible = False
        txtBilno.Focus()

        Dim dataredr As OleDb.OleDbDataReader
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim i, j As Integer
        Dim DFlg As Boolean
        'Dim sqlt As String
        Me.Cursor = Cursors.Default
        Try
            For i = 0 To dgDN.Rows.Count - 1
                If dgDN.Item(0, i).Value = "Yes" Then

                    DFlg = False  'to avoid duplicate entry into dgRec

                    For j = 0 To dgRec.Rows.Count - 1
                        'Checking For BatchId
                        If Val(dgRec.Item(1, j).Value & "") = dgDN.Item(17, i).Value Then
                            DFlg = True
                            Exit For
                        End If
                    Next j


                    If DFlg = False Then

                        cmd.CommandText = "select Batch.*,Product.PrdName from batch,Product where Product.PrdCode=Batch.PrdCode and Flag='D'and type='13'and batchid=" & (dgDN.Item(17, i).Value)

                        dataredr = cmd.ExecuteReader()
                        If dataredr.HasRows Then
                            While dataredr.Read()
                                dgRec.Item(0, dgRec.Rows.Count - 1).Value = dgRec.Rows.Count
                                dgRec.Item(1, dgRec.Rows.Count - 1).Value = dataredr.Item("BatchId")
                                dgRec.Item(2, dgRec.Rows.Count - 1).Value = dataredr.Item("Unit")
                                dgRec.Item(8, dgRec.Rows.Count - 1).Value = dataredr.Item("PrdCode")
                                dgRec.Item(9, dgRec.Rows.Count - 1).Value = dataredr.Item("PrdName")
                                dgRec.Item(10, dgRec.Rows.Count - 1).Value = dataredr.Item("Batch")
                                dgRec.Item(11, dgRec.Rows.Count - 1).Value = dataredr.Item("ExDt")
                                dgRec.Item(13, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("PRate")) * Val(dataredr.Item("unit")), "0.0000")
                                dgRec.Item(14, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("SRate")) * Val(dataredr.Item("unit")), "0.0000")
                                dgRec.Item(15, dgRec.Rows.Count - 1).Value = dataredr.Item("Ptax")
                                dgRec.Item(16, dgRec.Rows.Count - 1).Value = dataredr.Item("PDis")
                                dgRec.Item(19, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("RQty")) / Val(dataredr.Item("unit")), "0")
                                dgRec.Item(20, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("FQty")) / Val(dataredr.Item("unit")), "0")
                                dgRec.Item(21, dgRec.Rows.Count - 1).Value = Format(Val(dataredr.Item("RepQty")) / Val(dataredr.Item("unit")), "0")
                                dgRec.Item(22, dgRec.Rows.Count - 1).Value = dataredr.Item("Pack")
                                dgRec.Item(25, dgRec.Rows.Count - 1).Value = dataredr.Item("SCST")
                                dgRec.Item(26, dgRec.Rows.Count - 1).Value = dataredr.Item("Stax")

                                If dataredr.Item("TaxInc") = "True" Then
                                    dgRec.Item(27, dgRec.Rows.Count - 1).Value = "Yes"
                                Else
                                    dgRec.Item(27, dgRec.Rows.Count - 1).Value = "No"
                                End If

                                dgRec.Item(28, dgRec.Rows.Count - 1).Value = dataredr.Item("PCST")
                                dgRec.Item(29, dgRec.Rows.Count - 1).Value = dataredr.Item("PSCH")

                            End While
                            Rcpts.Rows.Add()
                        End If
                        dataredr.Close()
                    End If
                End If
            Next i
            Calculate()
            tsbSave.Enabled = True
            Me.Cursor = Cursors.Default
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbRtype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbRtype.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbRtype_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRtype.SelectedValueChanged
        GetSeries()
    End Sub
    Private Sub GetSeries()
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        If cbRtype.SelectedValue = Nothing Then Exit Sub
        Try
            cmd.Connection = Conn
            If (cbRtype.SelectedValue = "12" Or cbRtype.SelectedValue = "11") And SeriesSame Then
                cmd.CommandText = "select CreditEntry,POSTAC from serialnum where type='12'"
            Else
                cmd.CommandText = "select CreditEntry,POSTAC from serialnum where type=" & cbRtype.SelectedValue
            End If

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If dr("CreditEntry") Then
                    CreditPost = True
                Else
                    CreditPost = False

                End If
                If dr("POSTAC") Then
                    PostAc = True
                Else
                    PostAc = False
                End If
            End If

            dr.Close()


            If EditFlag Then
                If cbRtype.SelectedValue = EditType Then
                    lblno.Text = EditRectNo
                    Exit Sub
                End If
            End If

            If (cbRtype.SelectedValue = "12" Or cbRtype.SelectedValue = "11") And SeriesSame Then
                cmd.CommandText = "select slno from serialnum where type='12'"
            Else
                cmd.CommandText = "select slno from serialnum where type=" & cbRtype.SelectedValue
            End If
            If cbRtype.SelectedValue = "11" Then
                txtDuedat.Text = txtBildat.Text
            ElseIf cbRtype.SelectedValue = "12" Then
                If IsDate(txtBildat.Text) Then
                    txtDuedat.Text = DateAdd("d", txtDuedat.Tag, CDate(txtBildat.Text))
                End If
            End If

            lblno.Text = cmd.ExecuteScalar + 1


        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    Private Sub cbRtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRtype.Validated
        Try

            If cbRtype.SelectedValue <> "13" Then
                DeliveryDisplay()
            Else
                pnlDNote.Visible = False
                'dgRec.Enabled = True
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgDN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDN.CellDoubleClick
        'Dim i As Integer
        If dgDN.CurrentCell.RowIndex < 0 Then Exit Sub
        SelDeSelDlNotes(e.RowIndex)

        'If dgDN.Item(0, i).Value = "Yes" Then
        '    dgDN.CurrentRow.DefaultCellStyle.ForeColor = Color.Red
        '    ckbSelect.Checked = True
        'ElseIf dgDN.Item(0, i).Value = "No" Then
        '    dgDN.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
        '    ckbSelect.Checked = False
        'End If

    End Sub
    Private Sub SelDeSelDlNotes(ByVal i As Integer)
        If i < 0 Then Exit Sub
        Try
            If dgDN.Item(0, i).Value = "No" Or dgDN.Item(0, i).Value = "" Then
                dgDN.Item(0, i).Value = "Yes"
                dgDN.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            Else
                dgDN.Item(0, i).Value = "No"
                dgDN.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbSupp_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cbSupp.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then

            System.Windows.Forms.SendKeys.Send("{TAB}")

        End If
    End Sub


    Private Sub cbSupp_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSupp.SelectedValueChanged
        Dim cmd As New OleDb.OleDbCommand
        Dim cday As Long
        If cbSupp.SelectedValue = Nothing Then Exit Sub
        GetSeries()
        Try
            If CreditPost Then
                If IsDate(txtBildat.Text) Then
                    cmd.Connection = Conn
                    cmd.CommandText = "select Crday from acmaster where accode=" & cbSupp.SelectedValue
                    cday = cmd.ExecuteScalar
                    txtDuedat.Text = Format(DateAdd(DateInterval.Day, cday, CDate(txtBildat.Text)), DateFormat)
                    txtDuedat.Tag = cday
                End If
            Else
                txtDuedat.Text = txtBildat.Text
            End If
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub


    Private Sub cbSupp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSupp.Validated
        Try
            If cbSupp.SelectedValue <> "13" Then
                DeliveryDisplay()
                dgDN.Focus()
                ckbSelect.Checked = False
            Else
                pnlDNote.Visible = False
                'dgRec.Enabled = True
                ckbSelect.Checked = False
            End If


        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ckbSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbSelect.CheckedChanged
        Dim i As Integer
        Try
            For i = 0 To dgDN.Rows.Count - 1
                If ckbSelect.Checked = True Then
                    dgDN.Item(0, i).Value = "Yes"
                    dgDN.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dgDN.Item(0, i).Value = "No"
                    dgDN.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next

            'For i = 0 To dgDN.Rows.Count - 1
            'If ckbSelect.Checked = False Then
            'dgDN.Item(0, i).Value = "No"
            ' dgDN.DefaultCellStyle.ForeColor = Color.Black
            'End If
            'Next
        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub tsbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        Try
            txtEdit.Visible = False
            pnlDNote.Visible = False
            'dgRec.Enabled = True
            PurchaseCopy.Text = "Purchase Copy.."
            PurchaseCopy.pnlrct.Visible = True
            PurchaseCopy.txtRctno2.Visible = True
            PurchaseCopy.lblTo1.Visible = True
            PurchaseCopy.rbRcpt.Checked = True
            PurchaseCopy.ShowDialog()



            Select Case PurchaseCopy.DialogResult
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
                Case Windows.Forms.DialogResult.Yes

                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.OK

            End Select

            Dim dtab As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Me.Cursor = Cursors.WaitCursor

            cmd.Connection = Conn

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Get_Purchase_Print"

            If PurchaseCopy.rbDtAll.Checked Then

                cmd.Parameters.Add("@Types", OleDb.OleDbType.VarChar).Value = PurchaseCopy.cbType.SelectedValue
                cmd.Parameters.Add("@Nosf", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno.Text)
                cmd.Parameters.Add("@Nost", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno2.Text)
                cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpf.Value.Date
                cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpt.Value.Date
                cmd.Parameters.Add("@Opt", OleDb.OleDbType.BigInt).Value = 1
                cmd.Parameters.Add("@scode", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.cbSupp.SelectedValue)
                cmd.Parameters.Add("@bno", OleDb.OleDbType.VarChar).Value = PurchaseCopy.txtBNo.Text

            ElseIf PurchaseCopy.rbRcpt.Checked Then

                cmd.Parameters.Add("@Types", OleDb.OleDbType.VarChar).Value = PurchaseCopy.cbType.SelectedValue
                cmd.Parameters.Add("@Nosf", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno.Text)

                cmd.Parameters.Add("@Nost", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno2.Text)
                cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpf.Value.Date
                cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpt.Value.Date
                cmd.Parameters.Add("@Opt", OleDb.OleDbType.BigInt).Value = 2
                cmd.Parameters.Add("@scode", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.cbSupp.SelectedValue)
                cmd.Parameters.Add("@bno", OleDb.OleDbType.VarChar).Value = PurchaseCopy.txtBNo.Text

            ElseIf PurchaseCopy.rbSupp.Checked Then

                cmd.Parameters.Add("@Types", OleDb.OleDbType.VarChar).Value = PurchaseCopy.cbType.SelectedValue
                cmd.Parameters.Add("@Nosf", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno.Text)
                cmd.Parameters.Add("@Nost", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.txtRctno2.Text)
                cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpf.Value.Date
                cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = PurchaseCopy.dtpt.Value.Date
                cmd.Parameters.Add("@Opt", OleDb.OleDbType.BigInt).Value = 3
                cmd.Parameters.Add("@scode", OleDb.OleDbType.BigInt).Value = Val(PurchaseCopy.cbSupp.SelectedValue)
                cmd.Parameters.Add("@bno", OleDb.OleDbType.VarChar).Value = PurchaseCopy.txtBNo.Text

            End If


            da.SelectCommand = cmd
            da.Fill(dtab)


            Dim FRMRPT As New Reports1
            Dim RPT As New PurchasePrint

            RPT.SetDataSource(dtab)
            RPT.SetParameterValue("Head1", DeScriptRS(Firm.Name))
            RPT.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
            RPT.SetParameterValue("HEAD3", "Purchase Copy")

            FRMRPT.crv.ReportSource = RPT
            FRMRPT.Width = Main.Width
            FRMRPT.Height = Main.Height

            FRMRPT.MdiParent = Main
            FRMRPT.Show()

        Catch er As Exception

            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        If dgRec.RowCount > 1 Then
            If MsgBox("Entries found. Want to exit now..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        If dgRec.RowCount > 1 Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If
        ClearForm()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        If EditFlag Then
            If CheckUserLocked("Edit Purchase", , IIf(EditFlag, EditRectDt, Nothing)) = False Then Exit Sub
        End If


        If dgRec.Rows.Count < 2 Then
            MsgBox("No entries...")
            Exit Sub
        End If


        If cbRtype.SelectedValue <> "14" Then
            If ComputerRights.PuAddlmt <> 0 Then
                If Val(txtAdd.Text) > ComputerRights.PuAddlmt Then
                    MsgBox("Other addition amount above " & ComputerRights.PuAddlmt & " not allowed.")

                    Exit Sub
                End If
            End If
            If LoginRights.PuAddlmt <> 0 Then
                If Val(txtAdd.Text) > LoginRights.PuAddlmt Then
                    MsgBox("Other addition amount above " & LoginRights.PuAddlmt & " not allowed.")

                    Exit Sub
                End If
            End If
        End If

        If cbRtype.SelectedValue <> "14" Then

            If ComputerRights.PuLessLmt <> 0 Then
                If Abs(Val(txtDed.Text)) > ComputerRights.PuLessLmt Then
                    MsgBox("Other deduction amount above " & ComputerRights.PuLessLmt & " not allowed.")
                    Exit Sub
                End If
            End If

            If LoginRights.PuLessLmt <> 0 Then
                If Abs(Val(txtDed.Text)) > LoginRights.PuLessLmt Then
                    MsgBox("Other deduction amount above " & LoginRights.PuLessLmt & " not allowed.")
                    Exit Sub
                End If
            End If
        End If

        If cbRtype.SelectedValue = "13" Then
            If txtBilno.Text = "" Then
                txtBilno.Text = lblno.Text
                txtBildat.Text = Format(SysDt, "dd/MM/yyyy")
            End If
        End If

        If cbRtype.SelectedValue <> "13" Then

            If Not IsDate(txtBildat.Text) Then
                MsgBox("Invalid bill date..!", MsgBoxStyle.Information) : txtBildat.Focus() : Exit Sub


            End If

        End If

        If txtBilno.Text = "" Then MsgBox("Bill no should not be blank ..!", MsgBoxStyle.Information) : txtBilno.Focus() : Exit Sub
        If Not IsDate(txtBildat.Text) Then MsgBox("Invalid bill date..!", MsgBoxStyle.Information) : txtBildat.Focus() : Exit Sub
        If Val(cbSupp.SelectedValue) = 0 Then
            MsgBox("Select a supplier.", MsgBoxStyle.Information)
            Exit Sub
        End If
        'If EditFlag = True Then
        '    If MsgBox("Want to save Receipt No " & lblno.Text & "..? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        'Else
        '    If MsgBox("Want to save this Record..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        'End If

        If PostAc Then
            GetPurchaseDet()
        Else
            Save()
        End If

    End Sub

    Private Sub Save()
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand
        Dim cmd3 As New OleDb.OleDbCommand
        Dim TMPCONN As New OleDb.OleDbConnection
        Dim TMPCMD As New OleDb.OleDbCommand

        Dim sql, sqlbdt, sqlddt As String
        Dim i As Integer
        Dim Trn As Boolean = False
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim dr As OleDb.OleDbDataReader
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet

        Dim eMailText, MobText As String

        'If MsgBox("Finished " & cbRtype.Text & " Entries..? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

        Try
            If Not IsDate(txtBildat.Text) Then
                sqlbdt = "NULL"
            Else
                sqlbdt = "'" & txtBildat.Text & "'"
            End If

            If Not IsDate(txtDuedat.Text) Then
                sqlddt = "NULL"
            Else
                sqlddt = "'" & txtDuedat.Text & "'"
            End If

            'Writing new purchase records in edit mode
            TMPCONN.ConnectionString = connstr ' Conn.ConnectionString
            TMPCONN.Open()
            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd.Connection = Conn

            cmd1.Transaction = Trans
            cmd1.Connection = Conn

            cmd2.Transaction = Trans
            cmd2.Connection = Conn

            cmd3.Transaction = Trans
            cmd3.Connection = Conn


            Trn = True
            'cmd.CommandText = "update serialnum set slno=slno+1 where type=" & cbRtype.SelectedValue
            'cmd.ExecuteNonQuery()

            'cmd.CommandText = "select slno from serialnum where type=" & cbRtype.SelectedValue
            'dataredr = cmd.ExecuteReader()
            'dataredr.Read()
            'RcptNum = dataredr.Item("slno")
            'RcptDt = SysDt

            'dataredr.Close()
            Me.Cursor = Cursors.WaitCursor
            If Not EditFlag Then

                If (cbRtype.SelectedValue = "11" Or cbRtype.SelectedValue = "12") And SeriesSame Then
                    cmd.CommandText = "update serialnum set slno=slno+1 where type='12' "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select slno from serialnum where type='12'"
                Else
                    cmd.CommandText = "update serialnum set slno=slno+1 where type=" & cbRtype.SelectedValue
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select slno from serialnum where type=" & cbRtype.SelectedValue
                End If

                RcptNum = cmd.ExecuteScalar
                RcptDt = SysDt

                'If Not EditFlag Then

                For i = 0 To dgRec.Rows.Count - 2
                    If (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) > 0 Then

                        cmd.CommandText = "update pndord set " & _
                                  "rctqty= isnull(0,rctqty) + " & (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(21, i).Value)) & _
                                  ",rctfree=isnull(0,rctfree) + " & Val(dgRec.Item(20, i).Value) & _
                                  ",rctno=" & RcptNum & ",rctdt='" & RcptDt & "' where prdcode=""" + dgRec.Item(8, i).Value + """ and supcode=" & cbSupp.SelectedValue
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "update product set " & _
                            "PRate= " & Round(Val(dgRec.Item(13, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                            ",SRate=" & Round(Val(dgRec.Item(14, i).Value) / Val(dgRec.Item(2, i).Value), 4) & _
                            ",St= " & Val(dgRec.Item(26, i).Value) & _
                            ",TaxInc=" & IIf(dgRec.Item(27, i).Value = "Yes", 1, 0) & _
                            ",lrd='" & RcptDt & "'" & _
                            " where prdcode=""" + dgRec.Item(8, i).Value + """ "
                        cmd.ExecuteNonQuery()

                        If Not BatchSave(i) Then
                            'If Trn Then Trans.Rollback()
                            Trn = False
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else 'Returns
                        BatchRtnSave(i)
                    End If
                Next i
                sql = "insert into purchase(Type,pdate,RctNo,billno,billdt,addi,ded,rctamt,duedt,billdis," & _
                      "supcode,remark,bdisamt,pdisamt,pcstamt,sval,ptx1,ptx2,ptx3,ptx4,ptx5,pamt1,pamt2," & _
                      "pamt3,pamt4,pamt5,ptfamt,padj,pschamt) Values(" & Val(cbRtype.SelectedValue) & ",'" & RcptDt & _
                      "'," & RcptNum & ",""" & txtBilno.Text & """," & sqlbdt & "," & Val(txtAdd.Text) & _
                      "," & Val(txtDed.Text) & "," & Val(lblNamt.Text) & "," & sqlddt & "," & Val(txtDis.Text) & _
                      "," & Val(cbSupp.SelectedValue) & ",""" & txtRmk.Text & """," & totbdis & "," & totpdis & _
                      "," & totcst & "," & Svalue & "," & rptax(0, 1) & "," & rptax(1, 1) & "," & rptax(2, 1) & _
                      "," & rptax(3, 1) & "," & rptax(4, 1) & "," & rtaxary(0, 1) & "," & rtaxary(1, 1) & _
                      "," & rtaxary(2, 1) & "," & rtaxary(3, 1) & "," & rtaxary(4, 1) & "," & rtfamt & "," & rctadj & "," & _
                      totsch & ")"

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                'Trans.Commit()
                Dim dt As New DataTable
                Dim dt3 As New DataTable
                Dim OrgText As String
                For i = 0 To dgRec.Rows.Count - 2
                    cmd.CommandText = "SELECT SMSRegistry.CusCode, SMSRegistry.PCode, SMSRegistry.BySMS, SMSRegistry.ByEmail, Acmaster.AcName, Acmaster.mob," & _
                       " Product.PrdName, Acmaster.Email FROM SMSRegistry INNER JOIN" & _
                         " Acmaster ON SMSRegistry.CusCode = Acmaster.AcCode INNER JOIN Product ON SMSRegistry.PCode = Product.PrdCode WHERE PCode =""" & dgRec.Item(8, i).Value & """"
                    da.SelectCommand = cmd
                    da.Fill(ds, "SMSRegistry")
                    dt = ds.Tables("SMSRegistry")

                    For j = 0 To dt.Rows.Count - 1
                        cmd.Connection = Conn
                        cmd.CommandText = "Select MobSAIText,MailSAIText from Settings"
                        da.SelectCommand = cmd
                        da.Fill(ds, "Setting")
                        dt3 = ds.Tables("Setting")

                        If IsDBNull(dt3.Rows(0).Item("MailSAIText")) = False Then
                            OrgText = dt3.Rows(0).Item("MailSAIText")
                            eMailText = OrgText.Replace("#ProductName#", dt.Rows(j).Item("PrdName"))
                            eMailText = eMailText.Replace("#Customer#", dt.Rows(j).Item("AcName"))
                            eMailText = eMailText.Replace("#Qty#", (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)))
                        Else
                            eMailText = ""
                        End If

                        If IsDBNull(dt3.Rows(0).Item("MobSAIText")) = False Then
                            OrgText = dt3.Rows(0).Item("MobSAIText")
                            MobText = OrgText.Replace("#ProductName#", dt.Rows(j).Item("PrdName"))
                            '    MobText = OrgText.Replace("#Customer#", dt.Rows(j).Item("AcName"))
                            '    MobText = OrgText.Replace("#Qty#", (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)))
                            'Else
                            'MobText = "Your Requested Product:" & dt.Rows(j).Item("PrdName") & " stock is available with us. please contact us to confirm."
                        Else
                            MobText = ""
                        End If
                        'If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("BySMS") = True Then
                            If dt.Rows(0).Item("mob") <> "" Then
                                cmd.CommandText = "insert into SMSStatus(MobNo,SMSText,Sent,Dt,CustCode) Values(""" & dt.Rows(j).Item("mob") & """,""" & MobText & """,0," & RcptDt & "," & dt.Rows(j).Item("CusCode") & ")"
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        If dt.Rows(0).Item("ByEmail") = True Then
                            If dt.Rows(0).Item("Email") <> "" Then
                                cmd.CommandText = "insert into MailStatus(EMailIdTo,Text,Sent,Dt,CustCode) Values(""" & dt.Rows(j).Item("Email") & """,""" & eMailText & """,0," & RcptDt & "," & dt.Rows(j).Item("CusCode") & ")"
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        'End If
                    Next
                Next

            Else    'Editing receipt 'EditType

                Dim n1, fnd As Integer

                RcptNum = EditRectNo
                RcptDt = EditRectDt

                If EditType <> cbRtype.SelectedValue Then
                    If (EditFlag = "11" Or EditFlag = "12") And (cbRtype.SelectedValue = "11" Or cbRtype.SelectedValue = "12") And SeriesSame Then

                    Else
                        If (cbRtype.SelectedValue = "11" Or cbRtype.SelectedValue = "12") And SeriesSame Then
                            cmd.CommandText = "update serialnum set slno=slno+1 where type= '12' "
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "select slno from serialnum where type='12'"
                        Else
                            cmd.CommandText = "update serialnum set slno=slno+1 where type='" & cbRtype.SelectedValue & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "select slno from serialnum where type='" & cbRtype.SelectedValue & "'"
                        End If

                        RcptNum = cmd.ExecuteScalar
                    End If

                End If

                cmd.CommandText = "select Batch.rqty,fqty,repqty,stock,batchid,product.prdname,product.case1,Batch.flag " & _
                      "from Batch,product where product.prdcode=batch.prdcode and  Batch.RctNo=" & EditRectNo & _
                      " and Batch.PDate='" & EditRectDt & _
                      "'and Batch.Type=" & EditType & " order by Batchid"
                dt1 = New DataTable
                da.SelectCommand = cmd
                da.Fill(dt1)
                'dataredr = cmd.ExecuteReader()
                Dim FLGRCT As String
                For v As Integer = 0 To dt1.Rows.Count - 1

                    fnd = -1
                    For n1 = 0 To dgRec.Rows.Count - 2
                        If dt1.Rows(v).Item("Batchid") = Val(dgRec.Item(1, n1).Value & "") Then
                            fnd = n1
                            Exit For
                        End If
                    Next

                    If fnd = -1 Then
                        'If TMPCONN.State = ConnectionState.Open Then TMPCONN.Close()

                        'TMPCONN.Open()
                        'TMPCMD.Connection = TMPCONN
                        'TMPCMD.CommandText = "select (stock-(rqty+fqty+repqty)) as [CQty],flag from Batch where batchid=" & dt1.Rows(v).Item("Batchid")
                        'dataredr1 = TMPCMD.ExecuteReader()

                        'If dataredr1.HasRows() Then
                        ' dataredr1.Read()
                        If (dt1.Rows(v).Item("stock") - (dt1.Rows(v).Item("rqty") + dt1.Rows(v).Item("fqty") + dt1.Rows(v).Item("repqty"))) <> 0 And dt1.Rows(v).Item("flag") <> "RD" Then
                            'Trans.Rollback()
                            MsgBox("Insufficient Stock : " & dt1.Rows(v).Item("prdname") & " " & dt1.Rows(v).Item("case1"))
                            ' Exit Sub
                        End If
                        'dataredr = cmd.ExecuteReader()
                        'cmd3.Connection = Conn

                        cmd3.CommandType = CommandType.Text


                        FLGRCT = dt1.Rows(v).Item("flag") & ""


                        cmd3.CommandText = "Delete from batch where batchid=" & dt1.Rows(v).Item("Batchid")
                        cmd3.ExecuteNonQuery()

                        If FLGRCT = "RD" Then
                            cmd2.CommandText = "insert into batch select * from dlnoteadj where batchid=" & dt1.Rows(v).Item("Batchid")
                            cmd2.ExecuteNonQuery()

                            cmd2.CommandText = "delete from dlnoteadj where batchid=" & dt1.Rows(v).Item("Batchid")
                            cmd2.ExecuteNonQuery()
                        End If

                        'End If
                        'dataredr1.Close()
                        'TMPCONN.Close()

                    End If
                Next

                ' return

                'dataredr.Close()
                cmd.CommandText = "select BatchRtn.rqty,fqty,repqty,stock,batchid,stkles " & _
                     "from BatchRtn where BatchRtn.RctNo=" & EditRectNo & _
                     " and BatchRtn.PDate='" & EditRectDt & _
                     "'and BatchRtn.Type=" & EditType & " order by Batchid"

                dt2 = New DataTable
                da.SelectCommand = cmd
                da.Fill(dt2)

                For v As Integer = 0 To dt2.Rows.Count - 1
                    If dt2.Rows(v).Item("stkles") <> 0 Then
                        cmd2.CommandText = "update batch set stock = stock + " & Abs(dt2.Rows(v).Item("rqty") + dt2.Rows(v).Item("fqty") + dt2.Rows(v).Item("repqty")) & " where batchid=" & dt2.Rows(v).Item("Batchid")
                        fnd = cmd2.ExecuteNonQuery()
                    End If
                Next v

                cmd2.CommandText = "delete from BatchRtn where BatchRtn.RctNo=" & EditRectNo & _
                   " and BatchRtn.PDate='" & EditRectDt & _
                   "'and BatchRtn.Type=" & EditType
                cmd2.ExecuteNonQuery()

                For i = 0 To dgRec.Rows.Count - 2

                    If (Val(dgRec.Item(19, i).Value) + Val(dgRec.Item(20, i).Value) + Val(dgRec.Item(21, i).Value)) >= 0 Then
                        If Not BatchSave(i) Then
                            ' If Trn Then Trans.Rollback()
                            Trn = False
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else 'Returns
                        BatchRtnSave(i)
                    End If
                Next i

                sql = "Update purchase set type= " & Val(cbRtype.SelectedValue) & _
                    ",Pdate= '" & RcptDt & "',billno=""" & txtBilno.Text & """,billdt=" & sqlbdt & _
                    ",addi=" & Val(txtAdd.Text) & ",ded=" & Val(txtDed.Text) & _
                    ",rctamt=" & Val(lblNamt.Text) & ",duedt=" & sqlddt & _
                    ",billdis=" & Val(txtDis.Text) & ",supcode=" & Val(cbSupp.SelectedValue) & _
                    ",remark=""" & txtRmk.Text & """,bdisamt=" & totbdis & _
                    ",pdisamt=" & totpdis & ",pcstamt=" & totcst & _
                    ",sval=" & Svalue & ",ptx1=" & rptax(0, 1) & _
                    ",ptx2=" & rptax(1, 1) & ",ptx3=" & rptax(2, 1) & _
                    ",ptx4=" & rptax(3, 1) & ",ptx5=" & rptax(4, 1) & _
                    ",pamt1=" & rtaxary(0, 1) & ",pamt2=" & rtaxary(1, 1) & _
                    ",pamt3=" & rtaxary(2, 1) & ",pamt4=" & rtaxary(3, 1) & _
                    ",pamt5=" & rtaxary(4, 1) & ",ptfamt=" & rtfamt & _
                    ",RctNo=" & RcptNum & _
                    ",padj=" & rctadj & "Where RctNo= " & EditRectNo & _
                    " and Pdate = '" & EditRectDt & "' and Type= " & EditType & ""

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                'WriteAcc(cbRtype.SelectedValue, RcptNum, RcptDt)
                'Trans.Commit()
            End If

            cmd.Connection = Conn
            cmd.CommandText = "update rctsave set flag='P' where supcode=" & cbSupp.SelectedValue & _
                " and billno=""" & txtBilno.Tag & """ and billdt=convert(datetime,'" & txtBildat.Text & "')"
            cmd.ExecuteNonQuery()

            'Set Purchase Return and Comparison table
            If chkUpdatePurRtn.Checked = True Then
                If dgCmpValue.Rows.Count > 0 Then

                    cmd.Connection = Conn
                    cmd.CommandType = CommandType.Text

                    cmd.CommandText = "delete from Comparison where pno=" & lblno.Text & " and pdt='" & lbldt.Text & "' and type='" & cbRtype.SelectedValue.ToString & "' and supcode=" & cbSupp.SelectedValue.ToString
                    cmd.ExecuteNonQuery()

                    For x As Integer = 0 To dgCmpValue.Rows.Count - 1
                        If dgCmpValue.Rows(x).Cells(0).Value = True Then

                            cmd.CommandText = "update PurchaseReturn set settled=1,adjbillno='" & txtBilno.Text & "',adjbilldt='" & txtBildat.Text & "' where prno=" & dgCmpValue.Rows(x).Cells(1).Value & " and prdt='" & CDate(dgCmpValue.Rows(x).Cells(2).Value) & "' and supcode=" & cbSupp.SelectedValue.ToString
                            cmd.ExecuteNonQuery()

                            cmd.CommandText = "insert into Comparison(pno,pdt,type,prno,prdt,supcode) values(" & lblno.Text & ",'" & lbldt.Text & "','" & cbRtype.SelectedValue.ToString & "'," & dgCmpValue.Rows(x).Cells(1).Value & ",'" & CDate(dgCmpValue.Rows(x).Cells(2).Value) & "'," & cbSupp.SelectedValue.ToString & ")"
                            cmd.ExecuteNonQuery()

                        Else

                            cmd.CommandText = "update PurchaseReturn set settled=0,adjbillno=NULL,adjbilldt=NULL where prno=" & dgCmpValue.Rows(x).Cells(1).Value & " and prdt='" & CDate(dgCmpValue.Rows(x).Cells(2).Value) & "' and supcode=" & cbSupp.SelectedValue.ToString
                            cmd.ExecuteNonQuery()

                        End If
                    Next

                End If
            End If

            WriteAcc(cbRtype.SelectedValue, RcptNum, RcptDt)
            Trans.Commit()
            Trn = False
            'MsgBox("Saved Succesfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            If Not EditFlag Then
                Dim vfrm As New OrderView
                Dim dtab As New DataTable

                cmd.CommandText = "select OrdDt,OrdNo,PndOrd.prdcode,product.prdname,pndord.pack,pndord.qty,pndord.free,rctqty,rctfree " & _
                    " from product,pndord  where product.prdcode=pndord.prdcode " & _
                    "  and supcode=" & Val(cbSupp.SelectedValue) & _
                    " order by id "
                da.SelectCommand = cmd
                da.Fill(dtab)
                ' OrderView.grd.DataSource = Nothing
                'OrderView.grd.Rows.Clear()
                If dtab.Rows.Count > 0 Then
                    vfrm.grd.DataSource = dtab
                    vfrm.grd.Tag = Val(cbSupp.SelectedValue)

                    For vi As Integer = 0 To OrderView.grd.RowCount - 1
                        If Val(vfrm.grd.Item(7, vi).Value & "") + Val(vfrm.grd.Item(8, vi).Value & "") = 0 Then
                            vfrm.grd.Rows(vi).DefaultCellStyle.ForeColor = Color.Red
                            vfrm.grd.Rows(vi).DefaultCellStyle.BackColor = Color.Beige
                        End If
                    Next
                    vfrm.ShowDialog()
                End If

            End If

            ClearForm()
            If Me.Tag = "POPS" Then
                Me.Close()
            End If
        Catch er As Exception
            If Trn Then Trans.Rollback()
            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub WriteAcc(ByVal updtype As Long, ByVal updno As Long, ByVal upddt As Date)
        Dim vouno, cashcode, pcode As Long
        Dim seq As Long
        Dim sqlddt As String

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim BillType As Long
        Dim vn As Long

        cmd.Connection = Conn
        cmd1.Transaction = Trans
        cmd.Transaction = Trans

        cmd1.Connection = Conn


        If EditFlag Then

            If EditVouNo <> 0 Then
                cmd.CommandText = "delete  Invaccounts where mode = 'P' and type ='" & EditType & _
                                     "' and invcode='" & EditType & EditRectNo & "' and " & _
                                     "rctdt=convert(datetime,'" & EditRectDt & "')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "select vouno from ledger where  trntype='Pu' and " & _
                    "trndate=convert(datetime,'" & EditRectDt & "') and " & _
                    "InvCode='" & EditType & EditRectNo & "' and  seq=1 "
                vn = cmd.ExecuteScalar

                cmd.CommandText = "delete from ledger where trntype='Pu' and invcode='" & EditType & EditRectNo & _
                    "' and  trndate=convert(datetime,'" & EditRectDt & "')  "
                cmd.ExecuteNonQuery()

                'cmd.CommandText = "delete from adjdetails where (vouno=" & vn & _
                '        " and trntype='Pu' and trndate=convert(datetime,'" & EditRectDt & "')) or " & _
                '        " (billtrntype='Pu' and billVouno=" & vn & _
                '        " and  billtrndt=convert(datetime,'" & EditRectDt & "')) "
                'cmd.ExecuteNonQuery()

            End If

        End If
        If updtype = "13" Or updtype = "14" Then Exit Sub

        If PostAc = True Then
            If EditRectNo = 0 Or EditFlag = False Or EditVouNo = 0 Then

                cmd.CommandText = "update serialnum set slno=slno+1 where type=94"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "select slno from serialnum where type=94"
                vouno = cmd.ExecuteScalar
            Else
                vouno = EditVouNo
            End If 'InvDt = upddt

            cmd.CommandText = "select pucacode from settings "
            cashcode = cmd.ExecuteScalar


            If (CreditPost Or updtype = "12") And updtype <> "11" Then
                BillType = 2
                pcode = Val(cbSupp.SelectedValue)
            Else
                pcode = cashcode
                BillType = 1
            End If

            If Not IsDate(txtDuedat.Text) Then
                sqlddt = "NULL"
            Else
                sqlddt = "'" & txtDuedat.Text & "'"
            End If

            If EditFlag Then
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,pamt,supcode,dispute,Narration) values('" & _
                        upddt & "','Pu'," & vouno & "," & _
                        pcode & "," & Val(lblactot.Text) * -1 & "," & BillType & ",""" & _
                        txtBilno.Text & """,'" & txtBildat.Text & "'," & sqlddt & "," & _
                        "1,'" & updtype & updno & "',COALESCE((select sum(amt) from adjdetails where " & _
                        " billtrntype='Pu' and  billvouno=" & EditVouNo & " and billtrndt=convert(datetime,'" & upddt & "'  )),0)," & Val(cbSupp.SelectedValue) & _
                        "," & IIf(chkBlockPay.Checked, 1, 0) & ",""" & txtRmk.Text & """ ) "
            Else
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,supcode,dispute,Narration ) values('" & _
                        upddt & "','Pu'," & vouno & "," & _
                        pcode & "," & Val(lblactot.Text) * -1 & "," & BillType & ",""" & _
                        txtBilno.Text & """,'" & txtBildat.Text & "'," & sqlddt & "," & _
                        "1,'" & updtype & updno & "'," & Val(cbSupp.SelectedValue) & _
                       "," & IIf(chkBlockPay.Checked, 1, 0) & ",""" & txtRmk.Text & """ ) "
            End If
            cmd.ExecuteNonQuery()

            seq = 2

            For i = 0 To dgPurch.RowCount - 1
                If (Val(dgPurch.Item(3, i).Value & "") - Val(dgPurch.Item(4, i).Value & "")) <> 0 Then
                    cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                        "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode,supcode) " & _
                        "values('" & upddt & "','Pu'," & _
                        vouno & "," & Val(dgPurch.Item(0, i).Value & "") & "," & _
                        (Val(dgPurch.Item(3, i).Value & "") - Val(dgPurch.Item(4, i).Value & "")) & _
                        "," & BillType & ",""" & _
                        txtBilno.Text & """,'" & txtBildat.Text & "'," & seq & ",'" & updtype & updno & "'," & Val(cbSupp.SelectedValue) & ")"
                    cmd.ExecuteNonQuery()
                    'writing tax
                    seq = seq + 1
                End If
            Next i

        End If

        If updtype <> "14" And PostAc = False Then

            cmd.CommandText = "insert into iNVaccounts (type,mode,billno,Billdt," & _
                    "Party,Amt,adjamt,rctdt,invcode) values('" & updtype & "','P','" & _
                    txtBilno.Text & "','" & txtBildat.Text & _
                    "'," & cbSupp.SelectedValue & "," & Val(lblNamt.Text) & ",0,'" & upddt & "','" & updtype & updno & "')"
            cmd.ExecuteNonQuery()

        End If

    End Sub

    Private Sub dgDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDN.KeyDown
        Try
            If e.KeyCode = 13 Then
                If dgDN.Item(0, dgDN.CurrentCell.RowIndex).Value = "No" Or dgDN.Item(0, dgDN.CurrentCell.RowIndex).Value = "" Then
                    ckbSelect.Checked = False
                    dgDN.Item(0, dgDN.CurrentCell.RowIndex).Value = "Yes"
                    dgDN.CurrentRow.DefaultCellStyle.ForeColor = Color.Red
                Else
                    dgDN.Item(0, dgDN.CurrentCell.RowIndex).Value = "No"
                    dgDN.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgDN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDN.KeyPress
        Try
            If Asc(e.KeyChar) = 27 Then
                pnlDNote.Visible = False
                'dgRec.Enabled = True
                dgRec.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtpch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpch.GotFocus
        txtpch.SelectAll()
    End Sub

    Private Sub txtpch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpch.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtpch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpch.KeyPress
        If Asc(e.KeyChar) = 27 Then
            HidePanel()
            NewRcpt()
        End If
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtpch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpch.LostFocus
        txtpch.Text = Format(Val(txtpch.Text), "0.000")
    End Sub

    Private Sub GetPurchaseDet()
        Dim dataredr As OleDb.OleDbDataReader
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select AcMaster.AcName,AcMaster.AcCode,accountCtr.* from AcMaster,accountCtr where AcMaster.AcCode=accountCtr.AcCode and  LTRIM(RTRIM(accountCtr.contrl))    = 'P' "

            dgPurch.Rows.Clear()
            'Sal.Rows.Add()

            dataredr = cmd.ExecuteReader()

            If dataredr.HasRows Then
                While dataredr.Read()
                    dgPurch.Rows.Add()
                    dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = dataredr.Item("AcCode")
                    dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = dataredr.Item("DrCr")
                    dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = dataredr.Item("AcName")

                    If dataredr.Item("DrCr") = "1" Then
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = "0.00"
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True

                    ElseIf dataredr.Item("DrCr") = "2" Then
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = "0.00"
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                    End If
                    ' dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "PU" & i
                    dgPurch.Update()
                End While
            End If
            dataredr.Close()

            Dim acamt, postamt As Double
            Dim fnd As Boolean
            Dim hcode As Long

            acamt = 0

            For i = 0 To 4
                If rtaxary(i, 1) <> 0 Then
                    postamt = rtaxary(i, 1)
                    fnd = 0
                    For n = 0 To dgPurch.Rows.Count - 1
                        If rtaxary(i, 2) = Val(dgPurch.Item(0, n).Value) Then
                            fnd = 1
                            '.TextMatrix(n, 0) = rsctr!code
                            If postamt >= 0 Then
                                dgPurch.Item(1, n).Value = 1
                                dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(4, n).ReadOnly = True
                                dgPurch.Item(3, n).ReadOnly = False
                            Else
                                dgPurch.Item(1, n).Value = 2
                                dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(3, n).ReadOnly = True
                                dgPurch.Item(4, n).ReadOnly = False
                            End If
                            acamt = acamt + postamt
                            dgPurch.Item(5, n).Value = "PU" & i
                            Exit For
                        End If
                    Next n

                    If fnd = 0 Then
                        cmd.CommandText = "Select acmaster.acname " & _
                            "from acmaster where accode=" & rtaxary(i, 2)
                        dgPurch.Rows.Add()

                        dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = rtaxary(i, 2)
                        dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                        If postamt >= 0 Then
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                        Else
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                        End If
                        dgPurch.Update()
                        dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "PU" & i
                        acamt = acamt + postamt
                    End If
                End If


                If rptax(i, 1) <> 0 Then
                    postamt = rptax(i, 1)
                    fnd = 0
                    For n = 0 To dgPurch.Rows.Count - 1

                        If rptax(i, 2) = Val(dgPurch.Item(0, n).Value) Then
                            fnd = 1

                            If postamt >= 0 Then
                                dgPurch.Item(1, n).Value = 1
                                dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(4, n).ReadOnly = True
                                dgPurch.Item(3, n).ReadOnly = False
                            Else
                                dgPurch.Item(1, n).Value = 2
                                dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(3, n).ReadOnly = True
                                dgPurch.Item(4, n).ReadOnly = False
                            End If
                            acamt = acamt + postamt
                            dgPurch.Item(5, n).Value = "TX" & i
                            Exit For
                        End If
                    Next n


                    If fnd = 0 Then
                        cmd.CommandText = "Select acmaster.acname " & _
                            "from acmaster where accode=" & rptax(i, 2)
                        dgPurch.Rows.Add()

                        dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = rptax(i, 2)
                        dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                        If postamt >= 0 Then
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                        Else
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                        End If
                        dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "TX" & i
                        dgPurch.Update()
                        acamt = acamt + postamt


                    End If
                End If



                '---------cst



                If rpcstary(i, 1) <> 0 Then
                    postamt = rpcstary(i, 1)
                    fnd = 0
                    For n = 0 To dgPurch.Rows.Count - 1
                        If rpcstary(i, 2) = Val(dgPurch.Item(0, n).Value) Then
                            fnd = 1
                            '.TextMatrix(n, 0) = rsctr!code
                            If postamt >= 0 Then
                                dgPurch.Item(1, n).Value = 1
                                dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(4, n).ReadOnly = True
                                dgPurch.Item(3, n).ReadOnly = False
                            Else
                                dgPurch.Item(1, n).Value = 2
                                dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(3, n).ReadOnly = True
                                dgPurch.Item(4, n).ReadOnly = False
                            End If
                            acamt = acamt + postamt
                            dgPurch.Item(5, n).Value = "CPU" & i
                            Exit For
                        End If
                    Next n

                    If fnd = 0 Then
                        cmd.CommandText = "Select acmaster.acname " & _
                            "from acmaster where accode=" & rpcstary(i, 2)
                        dgPurch.Rows.Add()

                        dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = rpcstary(i, 2)
                        dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                        If postamt >= 0 Then
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                        Else
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                        End If
                        dgPurch.Update()
                        dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "CPU" & i
                        acamt = acamt + postamt
                    End If
                End If


                If rpcst(i, 1) <> 0 Then
                    postamt = rpcst(i, 1)
                    fnd = 0
                    For n = 0 To dgPurch.Rows.Count - 1

                        If rpcst(i, 2) = Val(dgPurch.Item(0, n).Value) Then
                            fnd = 1

                            If postamt >= 0 Then
                                dgPurch.Item(1, n).Value = 1
                                dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(4, n).ReadOnly = True
                                dgPurch.Item(3, n).ReadOnly = False
                            Else
                                dgPurch.Item(1, n).Value = 2
                                dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                                dgPurch.Item(3, n).ReadOnly = True
                                dgPurch.Item(4, n).ReadOnly = False
                            End If
                            acamt = acamt + postamt
                            dgPurch.Item(5, n).Value = "CST" & i
                            Exit For
                        End If
                    Next n


                    If fnd = 0 Then
                        cmd.CommandText = "Select acmaster.acname " & _
                            "from acmaster where accode=" & rpcst(i, 2)
                        dgPurch.Rows.Add()

                        dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = rpcst(i, 2)
                        dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                        If postamt >= 0 Then
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                        Else
                            dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                            dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                        End If
                        dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "CST" & i
                        dgPurch.Update()
                        acamt = acamt + postamt


                    End If
                End If


                '--- 







            Next i

            If rtfamt <> 0 Then
                postamt = rtfamt
                cmd.CommandText = "Select accode from tax " & _
                   " where flag='34'"
                fnd = 0
                hcode = cmd.ExecuteScalar
                For n = 0 To dgPurch.Rows.Count - 1
                    If hcode = Val(dgPurch.Item(0, n).Value & "") Then
                        fnd = 1

                        If postamt >= 0 Then
                            dgPurch.Item(1, n).Value = 1
                            dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, n).ReadOnly = True
                            dgPurch.Item(3, n).ReadOnly = False
                        Else
                            dgPurch.Item(1, n).Value = 2
                            dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, n).ReadOnly = True
                            dgPurch.Item(4, n).ReadOnly = False
                        End If
                        dgPurch.Item(5, n).Value = "TF"
                        acamt = acamt + postamt
                        Exit For
                    End If
                Next n

                If fnd = 0 Then
                    cmd.CommandText = "Select acname from acmaster " & _
                        " where accode=" & hcode
                    dgPurch.Rows.Add()
                    dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = hcode
                    dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                    If postamt >= 0 Then
                        dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                    Else
                        dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                    End If
                    dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "TF"
                    dgPurch.Update()
                    acamt = acamt + postamt

                End If
            End If
            rctadj = Val(txtAdd.Text) - Val(txtDed.Text)
            If rctadj <> 0 Then
                postamt = rctadj

                cmd.CommandText = "Select accode from tax " & _
                    " where flag='36'"
                fnd = 0
                hcode = cmd.ExecuteScalar
                For n = 0 To dgPurch.Rows.Count - 1
                    If hcode = Val(dgPurch.Item(0, n).Value & "") Then
                        fnd = 1

                        If postamt >= 0 Then
                            dgPurch.Item(1, n).Value = 1
                            dgPurch.Item(3, n).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(4, n).ReadOnly = True
                            dgPurch.Item(3, n).ReadOnly = False
                        Else
                            dgPurch.Item(1, n).Value = 2
                            dgPurch.Item(4, n).Value = Format(Abs(postamt), "0.00")
                            dgPurch.Item(3, n).ReadOnly = True
                            dgPurch.Item(4, n).ReadOnly = False
                        End If
                        dgPurch.Item(5, n).Value = "AD"
                        dgPurch.Update()
                        acamt = acamt + postamt
                        Exit For
                    End If
                Next n

                If fnd = 0 Then
                    cmd.CommandText = "Select acname from acmaster " & _
                        " where accode=" & hcode
                    dgPurch.Rows.Add()
                    dgPurch.Item(0, dgPurch.Rows.Count - 1).Value = hcode
                    dgPurch.Item(2, dgPurch.Rows.Count - 1).Value = cmd.ExecuteScalar

                    If postamt >= 0 Then
                        dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 1
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = True
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = False
                    Else
                        dgPurch.Item(1, dgPurch.Rows.Count - 1).Value = 2
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).Value = Format(Abs(postamt), "0.00")
                        dgPurch.Item(3, dgPurch.Rows.Count - 1).ReadOnly = True
                        dgPurch.Item(4, dgPurch.Rows.Count - 1).ReadOnly = False
                    End If
                    dgPurch.Item(5, dgPurch.Rows.Count - 1).Value = "AD"
                    dgPurch.Update()
                    acamt = acamt + postamt
                End If
            End If

            'panPurchase.Enabled = False
            pnlacc.Visible = True
            pnlacc.Show()
            Dim AMT As Double = 0
            For i = 0 To dgPurch.Rows.Count - 1
                AMT = AMT + Val(dgPurch.Item(3, i).Value & "") - Val(dgPurch.Item(4, i).Value & "")

            Next
            lblactot.Text = Format(AMT, "0.00")
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgPurch_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPurch.CellEndEdit
        Dim amt As Double
        dgPurch.Item(e.ColumnIndex, e.RowIndex).Value = Format(Val(dgPurch.Item(e.ColumnIndex, e.RowIndex).Value), "0.00")
        amt = 0
        For I = 0 To dgPurch.Rows.Count - 1
            amt = amt + Val(dgPurch.Item(3, I).Value & "") - Val(dgPurch.Item(4, I).Value & "")
        Next
        lblactot.Text = Format(amt, "0.00")
    End Sub

    Private Sub dgPurch_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgPurch.CellValidating
        'Dim cbc As DataGridViewTextBoxColumn = dgPurch.Columns(e.ColumnIndex)
        'MsgBox(e.FormattedValue)

    End Sub

    Private Sub ComAcOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComAcOk.Click
        Save()
        'panPurchase.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'panPurchase.Enabled = True
        pnlacc.Visible = False
    End Sub

    Private Sub pnlacc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlacc.Leave
        If pnlacc.Visible Then pnlacc.Focus()
    End Sub

    Private Sub tsbSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSave.EnabledChanged
        If dgRec.Rows.Count > 1 Then
            tsbSave.Enabled = True
        End If
    End Sub

    Private Sub tsbnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbnew.Click
        If cbSupp.Text = "" Then
            MsgBox("Select a supplier..", vbInformation)
            Exit Sub
        End If
        txtEdit.Visible = False
        panPur.Visible = False
        pnlDNote.Visible = False
        Dim dbcn As New OleDb.OleDbConnection
        Dim dbcmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim tb As New DataTable
        Dim btb As New DataTable
        Dim btb1 As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        opnfd.FileName = ""
        opnfd.Filter = "|*.mdb"
        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & opnfd.FileName & ";"
        dbcn.Open()
        dbcmd.Connection = dbcn
        cmd1.Connection = Conn
        dbcmd.CommandText = "select * from receipt   "
        da.SelectCommand = dbcmd
        da.Fill(tb)
        dbcn.Close()

        If Not tb.Rows.Count > 0 Then
            MsgBox("File is empty..", vbInformation)
            Exit Sub
        End If

        cmd1.CommandText = "select top 1 rctno,pdate from batch  where billno=""" + tb.Rows(0).Item("billno") + _
                       """ AND  billdt=convert(datetime,'" & tb.Rows(0).Item("billdt") & "') and batch.supcode=" & Val(cbSupp.SelectedValue) & _
                       "    order by pdate desc,rctno desc"

        da.SelectCommand = cmd1
        da.Fill(btb)
        If btb.Rows.Count > 0 Then
            MsgBox("File is already imported.. Rcpt No." & btb.Rows(0).Item(0) & " Dated " & btb.Rows(0).Item(1), vbInformation)
            Exit Sub
        End If
        btb.Clear()

        With dgRec
            For i = 0 To tb.Rows.Count - 1

                If i = 0 Then
                    txtBilno.Text = tb.Rows(i).Item("Billno") & ""

                    txtBildat.Text = tb.Rows(i).Item("billdt") '& "", "dd/MM/yyyy")

                End If
                btb.Rows.Clear()

                cmd1.CommandText = "select product.prdcode,product.prdname," & _
                        "product.case1,product.unit1,product.case2,product.unit2,batch.stax, " & _
                        "batch.prate,batch.srate,batch.unit,batch.pack,batch.taxinc,unit3,CASE3 from batch,product where batch.wcode=""" + tb.Rows(i).Item("code") + _
                        """ and batch.supcode=" & Val(cbSupp.SelectedValue) & _
                        " and  batch.unit<>0 AND batch.prdcode=product.prdcode  order by batchid desc"
                da.SelectCommand = cmd1

                da.Fill(btb)

                If btb.Rows.Count = 0 Then
                    WCode = ""
                    mapformr2_Imp.Frm.Text = tb.Rows(i).Item("Name") & "    " & tb.Rows(i).Item("pack") & "   (" & tb.Rows(i).Item("com") & ")"
                    mapformr2_Imp.ShowDialog()
                    If WCode = "" Then Exit Sub

                    btb.Rows.Clear()

                    cmd1.CommandText = "select product.prdcode," & _
                        "product.prdname,product.case1,product.unit1," & _
                        "product.case2,product.unit2," & _
                        "batch.prate,batch.srate,BATCH.unit,batch.scst,Batch.Taxinc,unit3,CASE3 " & _
                        " from product Product LEFT join Batch ON " & _
                        "Product.prdCode = Batch.prdCode where product.prdcode=""" + _
                        WCode + """  order by batchid desc  "

                    da.SelectCommand = cmd1
                    da.Fill(btb)


                End If

                .Item(0, .Rows.Count - 1).Value = .Rows.Count

                .Item(1, .Rows.Count - 1).Value = ""
                .Item(5, .Rows.Count - 1).Value = tb.Rows(i).Item("code")
                .Item(8, .Rows.Count - 1).Value = btb.Rows(0).Item("PrdCode")
                .Item(9, .Rows.Count - 1).Value = btb.Rows(0).Item("PrdName")
                .Item(10, .Rows.Count - 1).Value = tb.Rows(i).Item("batch") & ""
                If Not IsDBNull(tb.Rows(i).Item("ExDt")) Then
                    .Item(11, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("ExDt"), "dd/MM/yyyy")
                    ExpColor(.Rows.Count - 1)
                Else
                    .Item(11, .Rows.Count - 1).Value = ""
                End If


                .Item(26, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("ptax"), "0.00")
                .Item(15, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("ptax"), "0.00")

                .Item(13, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("pRate"), "0.00")
                .Item(14, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("MRP"), "0.00")
                .Item(16, .Rows.Count - 1).Value = Format((tb.Rows(i).Item("PDis") + tb.Rows(i).Item("bdis")), "0.00")
                .Item(25, .Rows.Count - 1).Value = "0.00"
                .Item(28, .Rows.Count - 1).Value = "0.00"
                .Item(29, .Rows.Count - 1).Value = "0.00"

                If btb.Rows.Count > 0 Then

                    'If Not btb.Rows(0).Item("TaxInc") Then
                    '.Item(27, .Rows.Count - 1).Value = "No"
                    ' Else
                    .Item(27, .Rows.Count - 1).Value = "Yes"
                    'End If

                    If Val(btb.Rows(0).Item("unit") & "") <> 0 Then
                        'If btb.Rows(0).Item("UNIT") & "" = "" Then
                        If btb.Rows(0).Item("unit") = btb.Rows(0).Item("unit2") Then
                            btb.Rows(0).Item("pack") = btb.Rows(0).Item("CASE2")
                        ElseIf btb.Rows(0).Item("unit") = btb.Rows(0).Item("unit1") Then
                            btb.Rows(0).Item("pack") = btb.Rows(0).Item("CASE1")
                        ElseIf btb.Rows(0).Item("unit") = btb.Rows(0).Item("unit3") Then
                            btb.Rows(0).Item("pack") = btb.Rows(0).Item("CASE3")
                        Else
                            If btb.Rows(0).Item("UNIT2") <> 0 Then
                                .Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                                btb.Rows(0).Item("pack") = btb.Rows(0).Item("CASE2")
                                btb.Rows(0).Item("UNIT") = btb.Rows(0).Item("UNIT2")
                            Else
                                .Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                                btb.Rows(0).Item("pack") = btb.Rows(0).Item("CASE1")
                                btb.Rows(0).Item("UNIT") = btb.Rows(0).Item("UNIT1")
                            End If


                        End If
                        .Item(2, .Rows.Count - 1).Value = btb.Rows(0).Item("unit")
                        .Item(22, .Rows.Count - 1).Value = Microsoft.VisualBasic.Left(btb.Rows(0).Item("pack"), 6) & " (" & btb.Rows(0).Item("unit") & ")"
                    Else
                        If btb.Rows(0).Item("case2") & "" = "" Then
                            .Item(2, .Rows.Count - 1).Value = btb.Rows(0).Item("unit1")
                            .Item(22, .Rows.Count - 1).Value = btb.Rows(0).Item("CASE1")
                        Else
                            .Item(2, .Rows.Count - 1).Value = btb.Rows(0).Item("unit2")
                            .Item(22, .Rows.Count - 1).Value = btb.Rows(0).Item("CASE2") & " (" & btb.Rows(0).Item("unit2") & ")"
                        End If
                        .Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                    End If


                    .Item(19, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("Qty"), "0")
                    .Item(20, .Rows.Count - 1).Value = Format(tb.Rows(i).Item("free"), "0")
                    .Item(21, .Rows.Count - 1).Value = ""  ' Format(tb.Rows(i).Item(("repl") & ""), "0")
                    Rcpts.Rows.Add()
                    Calculate()
                    ChkProfit(btb.Rows(0).Item("PrdCode"), True, .Rows.Count - 2)
                    tsbSave.Enabled = True
                Else
                    '.Item(27, .Rows.Count - 1).Value = "Yes"
                    '.Item(27, .Rows.Count - 1).Style.ForeColor = Color.Red
                    'If btb.Rows(0).Item("case2") & "" = "" Then
                    '    .Item(2, .Rows.Count - 1).Value = btb.Rows(0).Item("unit1")
                    '    .Item(22, .Rows.Count - 1).Value = btb.Rows(0).Item("CASE1")
                    'Else
                    '    .Item(2, .Rows.Count - 1).Value = btb.Rows(0).Item("unit2")
                    '    .Item(22, .Rows.Count - 1).Value = btb.Rows(0).Item("CASE2") & " (" & btb.Rows(0).Item("unit2") & ")"
                    'End If
                    '.Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                End If

            Next
        End With

    End Sub

    Private Sub txtPVat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPVat.TextChanged
        Try
            'cbSVat.SelectedText = Format(txtPVat.Text, "0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim NUM As String
        Dim DT As Date
        If EditFlag = False And dgRec.Rows.Count > 1 Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        If EditFlag Then
            DT = EditRectDt
        Else
            DT = SysDt
        End If
        NUM = Val(lblno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = cbRtype.SelectedValue
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "-P"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            'If dr("cancelled") Then
            '    cmd.Parameters.Clear()
            NUM = Val(dr("rctno") & "")

            '    dr.Close()
            '    GoTo che
            'End If
        Else
            'GoTo che
            ' ClearForm()
            Me.Cursor = Cursors.Default
            dr.Close()
            Exit Sub
        End If

        NUM = (dr("rctno") & "")
        DT = dr("pdate")
        dr.Close()
        ClearForm(True)
        EditReceipt(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim NUM As String
        Dim DT As Date
        If EditFlag = False And dgRec.Rows.Count > 1 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        If EditFlag Then
            DT = EditRectDt
        Else
            DT = SysDt
        End If
        NUM = Val(lblno.Text)
che:

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "NavigateRecord"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate, 10).Value = DT
        cmd.Parameters.Add("@vno", OleDb.OleDbType.BigInt, 10).Value = NUM
        cmd.Parameters.Add("@vtype", OleDb.OleDbType.VarChar, 10).Value = cbRtype.SelectedValue
        cmd.Parameters.Add("@vflg", OleDb.OleDbType.VarChar, 10).Value = "+P"

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            dr.Read()
            'If dr("cancelled") Then
            '    cmd.Parameters.Clear()
            NUM = Val(dr("rctno") & "")
            '    dr.Close()
            '    GoTo che
            'End If
        Else
            ' ClearForm()
            dr.Close()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        NUM = (dr("rctno") & "")
        DT = dr("pdate")
        dr.Close()
        ClearForm(True)
        EditReceipt(NUM, DT, DT)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If dgRec.RowCount > 1 And Not EditFlag Then
            If MsgBox("Entries found. Want to clear the entries..?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If
        ClearForm()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim rcv As New Purchase
        rcv.MdiParent = Main
        rcv.Width = Me.Width
        rcv.Height = Me.Height
        rcv.Show()
    End Sub

    Private Sub btnCmpVal_Click(sender As Object, e As System.EventArgs) Handles btnCmpVal.Click

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt, dt1, dt2 As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn

        If CompareValue Then
            CompareValue = False
            chkUpdatePurRtn.Checked = False
        Else
            CompareValue = True
        End If

        dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add() ': dt1.Columns.Add()
        dt2.Columns.Add("Rate") : dt2.Columns.Add("Purchase Value") : dt2.Columns.Add("VAT") : dt2.Columns.Add("MRP Value") ': dt2.Columns.Add("Profit")

        If dgRec.Rows.Count > 1 And CompareValue Then

            If EditFlag = True Then
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "select 0 as 'sel',prno,prdt from PurchaseReturn where supcode=" & cbSupp.SelectedValue.ToString & " and settled=0 group by prno,prdt"
                da.SelectCommand = cmd
                dt.Rows.Clear()
                da.Fill(dt)

                cmd.CommandText = "select prno,prdt from Comparison where pno=" & lblno.Text & " and pdt='" & lbldt.Text & "' and type='" & cbRtype.SelectedValue.ToString & "' and supcode=" & cbSupp.SelectedValue.ToString
                da.SelectCommand = cmd
                Dim dtnew As New DataTable
                dtnew.Rows.Clear()
                da.Fill(dtnew)
                If dtnew.Rows.Count > 0 Then
                    For n As Integer = 0 To dtnew.Rows.Count - 1
                        dt.Rows.Add(1, dtnew.Rows(n).Item(0).ToString, dtnew.Rows(n).Item(1).ToString)
                    Next
                End If
            Else
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "select 0 as 'sel',prno,prdt from PurchaseReturn where supcode=" & cbSupp.SelectedValue.ToString & " and settled=0 group by prno,prdt"
                da.SelectCommand = cmd
                dt.Rows.Clear()
                da.Fill(dt)
            End If

            dgCmpValue.Rows.Clear()

            Dim dvCmp As DataView = New DataView(dt, "", "prno", DataViewRowState.CurrentRows)
            dt = dvCmp.ToTable()

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dgCmpValue.Rows.Add()
                    If dt.Rows(i)("sel") = 1 Then
                        dgCmpValue.Rows(i).Cells(0).Value = True
                    Else
                        dgCmpValue.Rows(i).Cells(0).Value = False
                    End If
                    dgCmpValue.Rows(i).Cells(1).Value = dt.Rows(i)("prno")
                    dgCmpValue.Rows(i).Cells(2).Value = Format(dt.Rows(i)("prdt"), "dd/MM/yyyy")
                Next
            Else
                'MsgBox("Purchase Return Not Found For This Supplier", MsgBoxStyle.MsgBoxHelp)
            End If

            For i As Integer = 0 To dgRec.Rows.Count - 2
                Dim Qty As Double = dgRec.Rows(i).Cells(21).Value
                Dim Ptax As Double = dgRec.Rows(i).Cells(15).Value
                Dim Pvalue As Double = Qty * dgRec.Rows(i).Cells(13).Value
                Dim PtaxVal As Double = Pvalue * (Ptax / 100)
                Dim Svalue As Double = Qty * dgRec.Rows(i).Cells(14).Value

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

                    dgRplValue.DataSource = dt2

                    dgRplValue.Columns(0).Width = 60
                    dgRplValue.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgRplValue.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(0).Style.BackColor = Color.LightYellow
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(0).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgRplValue.Columns(1).Width = 80
                    dgRplValue.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgRplValue.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(1).Style.BackColor = Color.LightYellow
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(1).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgRplValue.Columns(2).Width = 70
                    dgRplValue.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgRplValue.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(2).Style.BackColor = Color.LightYellow
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(2).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgRplValue.Columns(3).Width = 80
                    dgRplValue.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgRplValue.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(3).Style.BackColor = Color.LightYellow
                    dgRplValue.Rows(dgRplValue.RowCount - 1).Cells(3).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    pnlCmpVal.Visible = True
                    Exit Sub
                End If
            End While

        Else
            pnlCmpVal.Visible = False
        End If

    End Sub

    Private Sub dgCmpValue_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgCmpValue.CurrentCellDirtyStateChanged
        If dgCmpValue.IsCurrentCellDirty Then
            dgCmpValue.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgCmpValue_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCmpValue.CellValueChanged

        If dgCmpValue.Rows.Count > 0 Then

            Dim da As New OleDb.OleDbDataAdapter
            Dim dt, dt1, dt2 As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn

            dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add() : dt1.Columns.Add()
            dt2.Columns.Add("Rate") : dt2.Columns.Add("Purchase Value") : dt2.Columns.Add("VAT") : dt2.Columns.Add("MRP Value")

            For i As Integer = 0 To dgCmpValue.Rows.Count - 1
                If dgCmpValue.Rows(i).Cells(0).Value = True Then

                    Dim prno As Integer = dgCmpValue.Rows(i).Cells(1).Value
                    Dim prdt As Date = dgCmpValue.Rows(i).Cells(2).Value

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "select (p.exqty + p.brqty) as Qty,b.Ptax,b.PRate,b.SRate from PurchaseReturn p,Batch b where p.supcode=b.Supcode and p.batchid=b.BatchId and p.prno=" & prno & " and p.prdt='" & prdt & "' and p.supcode=" & cbSupp.SelectedValue.ToString
                    da.SelectCommand = cmd
                    dt.Rows.Clear()
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        For j As Integer = 0 To dt.Rows.Count - 1
                            Dim Qty As Double = dt.Rows(j).Item("Qty")
                            Dim Ptax As Double = dt.Rows(j).Item("Ptax")
                            Dim Pvalue As Double = Qty * Val(dt.Rows(j).Item("PRate"))
                            Dim PtaxVal As Double = Pvalue * (Ptax / 100)
                            Dim Svalue As Double = Qty * Val(dt.Rows(j).Item("SRate"))

                            dt1.Rows.Add(Ptax, Pvalue, PtaxVal, Svalue)
                        Next
                    End If

                End If
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

                    dgPrtValue.DataSource = dt2

                    dgPrtValue.Columns(0).Width = 60
                    dgPrtValue.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgPrtValue.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(0).Style.BackColor = Color.LightYellow
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(0).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgPrtValue.Columns(1).Width = 80
                    dgPrtValue.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgPrtValue.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(1).Style.BackColor = Color.LightYellow
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(1).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgPrtValue.Columns(2).Width = 70
                    dgPrtValue.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgPrtValue.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(2).Style.BackColor = Color.LightYellow
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(2).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)

                    dgPrtValue.Columns(3).Width = 80
                    dgPrtValue.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                    dgPrtValue.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(3).Style.BackColor = Color.LightYellow
                    dgPrtValue.Rows(dgPrtValue.RowCount - 1).Cells(3).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)
                End If
            End While

            If dt1.Rows.Count < 1 Then
                dgPrtValue.DataSource = dt2

                dgPrtValue.Columns(0).Width = 60
                dgPrtValue.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                dgPrtValue.Columns(1).Width = 80
                dgPrtValue.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

                dgPrtValue.Columns(2).Width = 70
                dgPrtValue.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

                dgPrtValue.Columns(3).Width = 80
                dgPrtValue.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            End If

        End If

    End Sub

End Class