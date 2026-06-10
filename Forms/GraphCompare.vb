Public Class GraphCompare
    Private sertime As DateTime
    Private sertxt As String
    Private obj As Object
    Private ProdSelected As Boolean
    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.TextChanged
        'If ProdSelected = True Then Exit Sub
        Try
            If Txtname.Tag = "Y" Then Exit Sub
            obj = Txtname
            Select Case cb.SelectedIndex
                Case 0, 1, 8, 9, 10, 12, 14
                    Exit Sub
            End Select
            PopulateProduct()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    
    Private Sub GetInfo()
        Try
            pnlprod.Visible = False
            Select Case cb.SelectedIndex
                Case 2, 3, 15
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value & " " & DgProdSer.Item(3, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
                Case 4, 16
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
                Case 5, 17
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
                Case 6, 18
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
                Case 7, 19
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
                Case 11
                    lst.Items.Add(New MyListText(DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value, DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value))
            End Select

            Txtname.Focus()
            Txtname.Text = ""

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    Private Sub PopulateProduct()
        Try
            Txtcode.Text = ""
            txtpack.Text = ""
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand
                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet
                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                Select Case cb.SelectedIndex
                    Case 2, 3, 15
                        cmd.CommandText = "Populate_product"
                    Case 4, 16
                        cmd.CommandText = "Populate_company"
                    Case 5, 17
                        cmd.CommandText = "Populate_classification"
                    Case 6, 18
                        cmd.CommandText = "Populate_prgroup1"
                    Case 7, 19
                        cmd.CommandText = "Populate_prgroup2"
                    Case 11
                        cmd.CommandText = "Populate_supplier"
                End Select
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = obj.text
                da.SelectCommand = cmd
                da.Fill(ds, "Product")

                DgProdSer.DataSource = ds.Tables("Product")
                If ds.Tables("Product").Rows.Count > 0 Then
                    pnlprod.Visible = True
                    DgProdSer.Columns(0).Visible = False
                    DgProdSer.Columns(1).Width = 500
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
    

    Private Sub DgProdSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        Try
            GetInfo()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub DgProdSer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgProdSer.KeyDown
       
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

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub
    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                GetInfo()
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Dim mlist As New MyListText
        Dim rh As String
        Dim tmplst As String = ";"
        For i = 0 To lst.Items.Count - 1
            mlist = lst.Items(i)
            tmplst = tmplst & mlist.ItemData & ";"
        Next
        Dim rpt As Object
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        rh = ""
        Me.Cursor = Cursors.WaitCursor
        cmd.CommandType = CommandType.StoredProcedure

        Select Case cb.SelectedIndex
            Case 0, 1, 8, 10, 12, 13, 14

            Case 2, 3
                cmd.CommandText = "GetProductComparison"
                rh = "Productwise sales graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

            Case 4
                cmd.CommandText = "GetCompanyComparison"
                rh = "Companywise sales graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 5
                cmd.CommandText = "GetClassComparison"
                rh = "Classificationwise sales graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 6
                cmd.CommandText = "GetGroup1Comparison"
                rh = "Group1wise sales graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 7
                cmd.CommandText = "GetGroup2Comparison"
                rh = "Group2wise sales graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 9
                cmd.CommandText = "GetSupplierComparison"
                rh = "Supplierwise purchase graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

            Case 11
                cmd.CommandText = "GetSupplierComparison"
                rh = "Supplierwise purchase graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

            Case 15
                cmd.CommandText = "GetProfitabilityCompareProduct"
                rh = "Productwise Profitability graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 16
                cmd.CommandText = "GetProfitabilityCompareCompany"
                rh = "Companyrwise Profitabilityv graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

            Case 17
                cmd.CommandText = "GetProfitabilityCompareClassification"
                rh = "Classificationwise Profitability graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date
            Case 18
                cmd.CommandText = "GetProfitabilityComparePrgroup1"
                rh = "Group1wise Profitability graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

            Case 19
                cmd.CommandText = "GetProfitabilityComparePrgroup2"
                rh = "Group2wise Profitability graph for the period " & dtf.Value.Date & " - " & dtt.Value.Date

        End Select
   



        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        cmd.Parameters.Add("@cd", OleDb.OleDbType.VarChar).Value = tmplst
        cmd.Parameters.Add("@mon", OleDb.OleDbType.Integer).Value = IIf(chkmon.Checked, 1, 0)
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1


        da.SelectCommand = cmd
        da.Fill(dtab)


        rpt = New RptGraphCompaison

        rpt.SetDataSource(dtab.Tables(0))

        rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
        rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
        rpt.SetParameterValue("HEAD4", rh)
        rpt.SetParameterValue("MON", IIf(chkmon.Checked, 1, 0))
        rpt.SetParameterValue("QT", IIf(cb.SelectedIndex = 2, 1, 0))


        crv.ReportSource = rpt


        crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        crv.DisplayStatusBar = True
        crv.ShowParameterPanelButton = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub crv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb.SelectedIndexChanged

        Select Case cb.SelectedIndex
            Case 0, 1, 8, 9, 10, 12, 14
                cb.SelectedIndex = 1
                lblc.Text = ""
                Exit Sub
            Case 2, 3, 4, 5, 6, 7
                lblc.Text = "Sales"
            Case 9
                lblc.Text = "Purchase"

            Case 11
                lblc.Text = "Purchase"
            Case 15, 16, 17, 18, 19
                lblc.Text = "Profit"


        End Select
 



        If (cb.SelectedIndex = 2 Or cb.SelectedIndex = 3 Or cb.SelectedIndex = 15) And (Val(cb.Tag) = 2 Or Val(cb.Tag) = 3 Or Val(cb.Tag) = 15) Then
        ElseIf (cb.SelectedIndex = 4 Or cb.SelectedIndex = 16) And (Val(cb.Tag) = 4 Or Val(cb.Tag) = 16) Then
        ElseIf (cb.SelectedIndex = 5 Or cb.SelectedIndex = 17) And (Val(cb.Tag) = 5 Or Val(cb.Tag) = 17) Then
        ElseIf (cb.SelectedIndex = 6 Or cb.SelectedIndex = 18) And (Val(cb.Tag) = 6 Or Val(cb.Tag) = 18) Then
        ElseIf (cb.SelectedIndex = 7 Or cb.SelectedIndex = 19) And (Val(cb.Tag) = 7 Or Val(cb.Tag) = 19) Then
        Else
            lst.Items.Clear()
        End If






        cb.Tag = cb.SelectedIndex

    End Sub

    Private Sub dtt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtt.ValueChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub dtf_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtf.ValueChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub GraphCompare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtt.Value = SysDt
        dtf.Value = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, SysDt))
        cb.SelectedIndex = 2
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class