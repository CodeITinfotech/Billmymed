Imports System.IO

Public Class BatchBarCode
    Private obj As Object
    Private ProdSelected As Boolean
    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.TextChanged
        'If ProdSelected = True Then Exit Sub
        Try
            If Txtname.Tag = "Y" Then Exit Sub
            obj = Txtname
            PopulateProduct()
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


    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                GetInfo()
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)
            End Try
        End If
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
    Private Sub GetProduct(ByVal pcode As String)
        Dim cmd As New OleDb.OleDbCommand
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            cmd.CommandText = "Select * from product where prdcode=""" + pcode + """ "
            ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()
                Txtname.Tag = "Y"
                Txtcode.Text = dataredr.Item("PrdCode")
                Txtname.Text = dataredr.Item("Prdname")
                txtpack.Text = dataredr.Item("case1")
                txtqty.Text = ""
                Txtname.Tag = ""


            End If
            dataredr.Close()
            Dim dt As New DataTable
            Dim da As New OleDb.OleDbDataAdapter
            da.SelectCommand = cmd
            cmd.CommandText = "select Batch,ExDt,convert(numeric(18,2),Srate*unit) as Srate ,Stock,Batchid from batch where stock>0 and  prdcode=""" + Txtcode.Text + """"
            da.Fill(dt)
            batchdg.DataSource = dt
            txtqty.Focus()
            Me.Cursor = Cursors.Default
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    Private Sub GetInfo()
        Try
            pnlprod.Visible = False
            GetProduct(DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            Txtname.Focus()
            Txtname.SelectionStart = Len(Txtname.Text)

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub Opt1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Opt1.CheckedChanged
        pnl1.Enabled = Opt1.Checked
    End Sub

    Private Sub BatchBarCode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "select Type,Descr,seq from SerialNum where type>10 and type<20 order by seq"
        cmd.Connection = Conn
        da.SelectCommand = cmd
        da.Fill(ds, "SerialNum")
        cbRtype.DisplayMember = "Descr"
        cbRtype.ValueMember = "Type"
        cbRtype.DataSource = ds.Tables("SerialNum")
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles opt2.CheckedChanged
        pnl2.Enabled = opt2.Checked
    End Sub

    Private Sub DgProdSer_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub

    Private Sub tsbClear_Click(sender As System.Object, e As System.EventArgs) Handles tsbClear.Click
        Txtname.Text = ""
        Txtcode.Text = ""
        txtpack.Text = ""
        batchdg.DataSource = Nothing
    End Sub

    Private Sub tsbExit_Click(sender As System.Object, e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click

        Dim pri As Boolean = False
        Dim qt As Long
        Dim Writer As StreamWriter
        Dim FI As File
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim rq As Long
        Dim path As String
        Try

            cmd.Connection = Conn
            cmd.CommandText = "Select BarcodeFilePath from Settings"
            path = cmd.ExecuteScalar

            If Not IO.Directory.Exists(path) Then
                IO.Directory.CreateDirectory(path)
            End If

            Writer = New StreamWriter(path & "\barcode.prn")

            If Opt1.Checked Then
                If Val(txtqty.Text) <> 0 Then
                    pri = True

                    qt = Val(txtqty.Text)
                    If qt < 3 Then qt = 3
                    qt = System.Math.Round(qt / 3, 0)

                    Dim myStreamReaderL1 As System.IO.StreamReader
                    Dim myStr As String
                    myStreamReaderL1 = System.IO.File.OpenText(Application.StartupPath & "\BarcodeFormat.prn")
                    myStr = myStreamReaderL1.ReadToEnd()

                    myStreamReaderL1.Close()

                    myStr = myStr.Replace("<firmname>", DeScriptRS(Firm.Name))
                    myStr = myStr.Replace("<firmplace>", DeScriptRS(Firm.Place))
                    myStr = myStr.Replace("<prodcode>", batchdg.CurrentRow.Cells(4).Value)
                    myStr = myStr.Replace("<prodname>", Microsoft.VisualBasic.Left(Txtname.Text, 20).ToString)
                    myStr = myStr.Replace("<price>", "  Rs." & Format(batchdg.CurrentRow.Cells(2).Value, "0.00"))
                    myStr = myStr.Replace("<pack>", txtpack.Text)
                    myStr = myStr.Replace("<batch>", "Batch:" & batchdg.CurrentRow.Cells(0).Value)


                    If IsDBNull(batchdg.CurrentRow.Cells(1).Value) Then

                    Else
                        myStr = myStr.Replace("<date>", "Ex.Dt " & Format(batchdg.CurrentRow.Cells(1).Value, "MM/yy"))
                    End If


                    myStr = myStr.Replace("<qty>", qt)
                    Writer.WriteLine(myStr)


                    ' '''''''''''--------------------------- zebra
                    'Writer.WriteLine("I8,A,001")
                    'Writer.WriteLine("Q181,024")
                    'Writer.WriteLine("q863")
                    'Writer.WriteLine("rN")
                    'Writer.WriteLine("S3")
                    'Writer.WriteLine("D7")
                    'Writer.WriteLine("ZT")
                    'Writer.WriteLine("JF")
                    'Writer.WriteLine("O")
                    'Writer.WriteLine("R5,0")
                    'Writer.WriteLine("f100")
                    'Writer.WriteLine("N")

                    'Writer.WriteLine("B25,30,0,1,2,6,29,N,""" & "B" & batchdg.CurrentRow.Cells(4).Value & "" & """")
                    'Writer.WriteLine("A24,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                    'If IsDBNull(batchdg.CurrentRow.Cells(1).Value) Then

                    '    ' Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(batchdg.CurrentRow.Cells(1).Value, "MM/yy") & """")
                    'Else
                    '    Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(batchdg.CurrentRow.Cells(1).Value, "MM/yy") & """")
                    'End If

                    'Writer.WriteLine("A115,89,0,3,1,1,N,""Rs." & Format(batchdg.CurrentRow.Cells(2).Value, "0.00") & """")
                    'Writer.WriteLine("A27,111,0,3,1,1,N,""Batch:" & batchdg.CurrentRow.Cells(0).Value & """")
                    'Writer.WriteLine("A27,67,0,2,1,1,N,""" & Txtname.Text & """")
                    'Writer.WriteLine("A27,86,0,2,1,1,N,""" & txtpack.Text & """")


                    'Writer.WriteLine("B297,30,0,1,2,6,29,N,""" & "B" & batchdg.CurrentRow.Cells(4).Value & "" & """")
                    'Writer.WriteLine("A296,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                    'If IsDBNull(batchdg.CurrentRow.Cells(1).Value) Then

                    'Else
                    '    Writer.WriteLine("A300,135,0,3,1,1,N,""Ex.Dt:" & Format(batchdg.CurrentRow.Cells(1).Value, "MM/yy") & """")
                    'End If


                    'Writer.WriteLine("A387,89,0,3,1,1,N,""Rs." & Format(batchdg.CurrentRow.Cells(2).Value, "0.00") & """")
                    'Writer.WriteLine("A299,111,0,3,1,1,N,""Batch:" & batchdg.CurrentRow.Cells(0).Value & """")
                    'Writer.WriteLine("A299,67,0,2,1,1,N,""" & Txtname.Text & """")
                    'Writer.WriteLine("A299,86,0,2,1,1,N,""" & txtpack.Text & """")



                    'Writer.WriteLine("B568,30,0,1,2,6,29,N,""" & "B" & batchdg.CurrentRow.Cells(4).Value & "" & """")
                    'Writer.WriteLine("A567,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                    'If IsDBNull(batchdg.CurrentRow.Cells(1).Value) Then

                    'Else
                    '    Writer.WriteLine("A571,135,0,3,1,1,N,""Ex.Dt:" & Format(batchdg.CurrentRow.Cells(1).Value, "MM/yy") & """")
                    'End If

                    'Writer.WriteLine("A658,89,0,3,1,1,N,""Rs." & Format(batchdg.CurrentRow.Cells(2).Value, "0.00") & """")
                    'Writer.WriteLine("A570,111,0,3,1,1,N,""Batch:" & batchdg.CurrentRow.Cells(0).Value & """")
                    'Writer.WriteLine("A570,67,0,2,1,1,N,""" & Txtname.Text & """")
                    'Writer.WriteLine("A570,86,0,2,1,1,N,""" & txtpack.Text & """")


                    'qt = Val(txtqty.Text)
                    'If qt < 3 Then qt = 3

                    'qt = Math.Round(qt / 3, 0)

                    'Writer.WriteLine("P" & qt)

                    '--------------------------------------------------

                End If



                Else

                    cmd.CommandText = "Select batch.prdcode,batch.EXDT,batch.batch,batch.batchid,batch.srate,product.prdname,product.case1,batch.unit, " & _
                        "(batch.Rqty+batch.fqty) as [qty]  from batch,product where " & _
                         " batch.prdcode=product.prdcode and batch.rctno=" & (txtBilno.Text) & _
                        " and    BATCH.PDATE>=convert(datetime,'" & DateAdd("m", -4, SysDt) & "') " & _
                        " order by product.prdname, batchid"
                    cmd.Connection = Conn
                    da.SelectCommand = cmd
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        rq = Val(dt.Rows(i).Item("qty") / dt.Rows(i).Item("unit"))
                        qt = Val(dt.Rows(i).Item("qty") / dt.Rows(i).Item("unit"))
                        If qt < 3 Then qt = 3
                        qt = System.Math.Round(qt / 3, 0)

                        Dim myStreamReaderL1 As System.IO.StreamReader
                        Dim myStr As String
                        myStreamReaderL1 = System.IO.File.OpenText(Application.StartupPath & "\BarcodeFormat.prn")
                        myStr = myStreamReaderL1.ReadToEnd()
                        myStreamReaderL1.Close()

                        myStr = myStr.Replace("<firmname>", DeScriptRS(Firm.Name))
                        myStr = myStr.Replace("<firmplace>", DeScriptRS(Firm.Place))
                        myStr = myStr.Replace("<prodcode>", dt.Rows(i).Item("BATCHID"))
                        myStr = myStr.Replace("<prodname>", Microsoft.VisualBasic.Left(dt.Rows(i).Item("prdname"), 20).ToString)
                    myStr = myStr.Replace("<price>", "Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00"))
                    myStr = myStr.Replace("<pack>", dt.Rows(i).Item("case1"))
                    myStr = myStr.Replace("<batch>", "Batch:" & dt.Rows(i).Item("BATCH"))

                    If IsDBNull(dt.Rows(i).Item("EXDT")) Then

                    Else
                        myStr = myStr.Replace("<date>", "Ex.Dt " & Format(dt.Rows(i).Item("EXDT"), "MM/yy"))
                    End If


                    myStr = myStr.Replace("<qty>", qt)
                    Writer.WriteLine(myStr)



                        '''''''''''--------------------------- zebra

                        '    Writer.WriteLine("I8,A,001")
                        '    Writer.WriteLine("Q181,024")
                        '    Writer.WriteLine("q863")
                        '    Writer.WriteLine("rN")
                        '    Writer.WriteLine("S3")
                        '    Writer.WriteLine("D7")
                        '    Writer.WriteLine("ZT")
                        '    Writer.WriteLine("JF")
                        '    Writer.WriteLine("O")
                        '    Writer.WriteLine("R5,0")
                        '    Writer.WriteLine("f100")
                        '    Writer.WriteLine("N")

                        '    Writer.WriteLine("B25,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A24,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")

                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then

                        'Else
                        '    Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If

                        'Writer.WriteLine("A115,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A27,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A27,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A27,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")




                        'Writer.WriteLine("B297,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A296,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then

                        'Else
                        '    Writer.WriteLine("A300,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If

                        'Writer.WriteLine("A387,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A299,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A299,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A299,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")

                        'Writer.WriteLine("B568,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A567,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")

                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then

                        'Else
                        '    Writer.WriteLine("A571,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If

                        'Writer.WriteLine("A658,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A570,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A570,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A570,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")



                        'Writer.WriteLine("P" & qt)



                        If rq - (qt * 3) = 1 Then

 
                        myStreamReaderL1 = System.IO.File.OpenText(Application.StartupPath & "\BarcodeFormat.prn")
                        myStr = myStreamReaderL1.ReadToEnd()
                        myStreamReaderL1.Close()

                        myStr = myStr.Replace("<firmname>", DeScriptRS(Firm.Name))
                        myStr = myStr.Replace("<firmplace>", DeScriptRS(Firm.Place))
                        myStr = myStr.Replace("<prodcode>", dt.Rows(i).Item("BATCHID"))
                        myStr = myStr.Replace("<prodname>", Microsoft.VisualBasic.Left(dt.Rows(i).Item("prdname"), 20).ToString)
                        myStr = myStr.Replace("<price>", "Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00"))
                        myStr = myStr.Replace("<pack>", dt.Rows(i).Item("case1"))
                        myStr = myStr.Replace("<batch>", "Batch:" & dt.Rows(i).Item("BATCH"))
                        If IsDBNull(dt.Rows(i).Item("EXDT")) Then
                        Else
                            myStr = myStr.Replace("<date>", "Ex.Dt " & Format(dt.Rows(i).Item("EXDT"), "MM/yy"))
                        End If
                        myStr = myStr.Replace("<qty>", "1")
                        Writer.WriteLine(myStr)



                        'Writer.WriteLine("I8,A,001")
                        'Writer.WriteLine("Q181,024")
                        'Writer.WriteLine("q863")
                        'Writer.WriteLine("rN")
                        'Writer.WriteLine("S3")
                        'Writer.WriteLine("D7")
                        'Writer.WriteLine("ZT")
                        'Writer.WriteLine("JF")
                        'Writer.WriteLine("O")
                        'Writer.WriteLine("R5,0")
                        'Writer.WriteLine("f100")
                        'Writer.WriteLine("N")

                        'Writer.WriteLine("B25,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A24,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")

                        '' Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then

                        'Else
                        '    Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If


                        'Writer.WriteLine("A115,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A27,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A27,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A27,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")

                            Writer.WriteLine("P" & 1)

                    ElseIf rq - (qt * 3) = 2 Then

                        myStreamReaderL1 = System.IO.File.OpenText(Application.StartupPath & "\BarcodeFormat.prn")
                        myStr = myStreamReaderL1.ReadToEnd()
                        myStreamReaderL1.Close()

                        myStr = myStr.Replace("<firmname>", DeScriptRS(Firm.Name))
                        myStr = myStr.Replace("<firmplace>", DeScriptRS(Firm.Place))
                        myStr = myStr.Replace("<prodcode>", dt.Rows(i).Item("BATCHID"))
                        myStr = myStr.Replace("<prodname>", Microsoft.VisualBasic.Left(dt.Rows(i).Item("prdname"), 20).ToString)
                        myStr = myStr.Replace("<price>", "Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00"))
                        myStr = myStr.Replace("<pack>", dt.Rows(i).Item("case1"))
                        myStr = myStr.Replace("<batch>", "Batch:" & dt.Rows(i).Item("BATCH"))
                        If IsDBNull(dt.Rows(i).Item("EXDT")) Then
                        Else
                            myStr = myStr.Replace("<date>", "Ex.Dt " & Format(dt.Rows(i).Item("EXDT"), "MM/yy"))
                        End If
                        myStr = myStr.Replace("<qty>", "2")
                        Writer.WriteLine(myStr)


                        'Writer.WriteLine("I8,A,001")
                        'Writer.WriteLine("Q181,024")
                        'Writer.WriteLine("q863")
                        'Writer.WriteLine("rN")
                        'Writer.WriteLine("S3")
                        'Writer.WriteLine("D7")
                        'Writer.WriteLine("ZT")
                        'Writer.WriteLine("JF")
                        'Writer.WriteLine("O")
                        'Writer.WriteLine("R5,0")
                        'Writer.WriteLine("f100")
                        'Writer.WriteLine("N")

                        'Writer.WriteLine("B25,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A24,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                        ''Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then
                        'Else
                        '    Writer.WriteLine("A28,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If

                        'Writer.WriteLine("A115,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A27,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A27,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A27,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")

                        'Writer.WriteLine("B297,30,0,1,2,6,29,N,""" & "B" & dt.Rows(i).Item("BATCHID") & "" & """")
                        'Writer.WriteLine("A296,1,0,4,1,1,N,""" & DeScriptRS(Firm.Name) & """")
                        '' Writer.WriteLine("A300,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")

                        'If IsDBNull(dt.Rows(i).Item("EXDT")) Then
                        'Else
                        '    Writer.WriteLine("A300,135,0,3,1,1,N,""Ex.Dt:" & Format(dt.Rows(i).Item("EXDT"), "MM/yy") & """")
                        'End If


                        'Writer.WriteLine("A387,89,0,3,1,1,N,""Rs." & Format(dt.Rows(i).Item("SRATE") * dt.Rows(i).Item("unit"), "0.00") & """")
                        'Writer.WriteLine("A299,111,0,3,1,1,N,""Batch:" & dt.Rows(i).Item("BATCH") & """")
                        'Writer.WriteLine("A299,67,0,2,1,1,N,""" & dt.Rows(i).Item("prdname") & """")
                        'Writer.WriteLine("A299,86,0,2,1,1,N,""" & dt.Rows(i).Item("case1") & """")
                        'Writer.WriteLine("P" & 1)
                        ElseIf rq - (qt * 3) = 3 Then

                        End If

                    pri = True

                    Next




                End If
            Writer.Close()
                'Try
                '    'FileCopy(Application.StartupPath & "\barcode.bat", "c:\barcode.bat")
                'Catch ex As Exception

                'End Try
            If pri Then Shell(Application.StartupPath & "\barcode.bat", AppWinStyle.Hide)



        Catch Ex As Exception
            'ErrInfo = Ex. Next
            MsgBox(Ex.Message)
        End Try

    End Sub
End Class