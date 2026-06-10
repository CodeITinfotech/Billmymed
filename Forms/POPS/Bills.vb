Option Strict Off
Option Explicit On
Friend Class Bills
	Inherits System.Windows.Forms.Form
	
    Private Sub chk_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk.CheckStateChanged
        ReadBills()
    End Sub
	
    Private Sub ReadBillsWeb()
        Dim cmd As New SqlClient.SqlCommand

        Dim rs As SqlClient.SqlDataReader

        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        cmd.CommandTimeout = 200
        cmd.Connection = PopsConn

        Try

       
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GetBills"
            cmd.Parameters.Add("@clientid", SqlDbType.VarChar, 20).Value = ClientId
            rs = cmd.ExecuteReader
            grd.Rows.Clear()

            While rs.Read
                grd.Rows.Add()
                grd.Item(0, grd.Rows.Count - 1).Value = rs("billno") & ""
                grd.Item(1, grd.Rows.Count - 1).Value = Format(rs("billdt"), "dd/MM/yyy")
                grd.Item(2, grd.Rows.Count - 1).Value = rs("Name")
                grd.Item(3, grd.Rows.Count - 1).Value = rs("place") & ""
                grd.Item(4, grd.Rows.Count - 1).Value = rs("wclientid") & ""
                grd.Item(5, grd.Rows.Count - 1).Value = rs("rsupcode") & ""
                grd.Item(6, grd.Rows.Count - 1).Value = rs("Type") & ""
            End While

            grd.Rows.Add()
            If rs.HasRows Then
                Panel1.Visible = True
            Else
                Panel1.Visible = False
            End If
            rs.Close()
            Me.Cursor = Cursors.Default
            PopsConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub com_rcvbill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles com_rcvbill.Click
        ReadBillsWeb()
        ReadBills()

    End Sub


    Private Function DownloadBill(RO As Integer) As Boolean
        Dim sqlexdt As Object
        Dim rcode As Object
        Dim mapcd As Object

        Dim cmd As New OleDb.OleDbCommand
        Dim scmd As New SqlClient.SqlCommand
        Dim scmd1 As New SqlClient.SqlCommand
        Dim Trans As OleDb.OleDbTransaction
        Dim tb As New DataTable
        Dim tb1 As New DataTable
        Dim da As New SqlClient.SqlDataAdapter
        Dim trn As Boolean
        trn = False
        On Error GoTo errmsg
        Dim bwcode As String
        Dim cmd1 As New OleDb.OleDbCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            DownloadBill = False
            Exit Function
        End If
        cmd.Connection = Conn
        cmd1.Connection = Conn
        scmd.Connection = PopsConn
        scmd1.Connection = PopsConn
        DownloadBill = False
        If grd.Item(5, RO).Value & "" = "" Then
            If grd.Item(0, RO).Value & "" <> "" Then MsgBox("Supplier not maped " & grd.Item(2, RO).Value & " " & grd.Item(3, RO).Value)
            PopsConn.Close()
            Exit Function
        End If

        If CheckPOPSConnection() = False Then

            Me.Cursor = Cursors.Default
            MsgBox("Can't Connect POPS Server...")
            DownloadBill = False
            Exit Function
        End If


        scmd1.CommandTimeout = 200
        scmd.CommandTimeout = 200
        cmd.CommandTimeout = 200
        scmd1.CommandText = "select * from trans where Billno=""" & grd.Item(0, RO).Value & """ and billdt=convert(datetime,'" & grd.Item(1, RO).Value & "' ) and  rclientid='" & ClientId & "' and wclientid='" + grd.Item(4, RO).Value + "' and isnull(processed,'') <>'P' order by seq  "
        da.SelectCommand = scmd1
        tb1.Rows.Clear()
        da.Fill(tb1)

        For n As Long = 0 To tb1.Rows.Count - 1
            rcode = ""
            bwcode = ""
            If CheckPOPSConnection() = False Then
                MsgBox("Can't Connect POPS Server...")
                Me.Cursor = Cursors.Default
                DownloadBill = False
                Exit Function
            End If
            scmd.Connection = PopsConn
            scmd.CommandType = CommandType.StoredProcedure
            scmd.CommandText = "CheckProductMap_Wholesale"
            scmd.Parameters.Add("@rclientid", SqlDbType.VarChar).Value = ClientId
            scmd.Parameters.Add("@wclientid", SqlDbType.VarChar).Value = grd.Item(4, RO).Value
            scmd.Parameters.Add("@wpcode", SqlDbType.VarChar).Value = tb1.Rows(n).Item("wpcode")
            If CheckPOPSConnection() = False Then
                Me.Cursor = Cursors.Default
                MsgBox("Can't Connect POPS Server...")
                DownloadBill = False
                Exit Function
            End If
            ' scmd.CommandText = "select rprodcode from prodmap where wprodcode = '" & tb1.Rows(n).Item("wpcode") & "' and rclientid = '" & ClientId & "' and wclientid='" & grd.Item(4, RO).Value & "' AND rprodcode + ''<>''"
            rcode = scmd.ExecuteScalar & ""
            scmd.Parameters.Clear()
            If Trim(rcode & "") <> "" Then
                cmd1.CommandText = "select prdcode from product WHERE prdcode=""" & rcode & """ and deleted=0"
                bwcode = cmd1.ExecuteScalar & ""
                If bwcode = "" Then
                    rcode = ""
                    GoTo MapProd
                End If
            Else
MapProd:        rcode = ""
                Me.Tag = ""
                mapformr2.Text = "Mapping products..."
                mapformr2.TextBox1.Tag = ""
                mapformr2.TextBox1.Text = tb1.Rows(n).Item("Name") & "    " & tb1.Rows(n).Item("pack") & "   (" & tb1.Rows(n).Item("cmpname") & ")"
                mapformr2.TextBox1.Tag = tb1.Rows(n).Item("Name") & "    " & tb1.Rows(n).Item("pack") & "   (" & tb1.Rows(n).Item("cmpname") & ")"
                mapformr2.Frm.Tag = tb1.Rows(n).Item("wpcode")
                mapformr2.Tag = tb1.Rows(n).Item("wclientid")
                mapformr2.comadd.Enabled = True
                mapformr2.txtname.Focus()
                mapformr2.Refresh()
                mapformr2.ShowDialog()
                rcode = mapformr2.txtcode.Tag
                mapformr2.txtcode.Tag = ""
                Me.Tag = ""
                If rcode = "" Then PopsConn.Close() : Exit Function
            End If
        Next

        ' Trans = Conn.BeginTransaction
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            DownloadBill = False
            Exit Function
        End If
        'STrans = PopsConn.BeginTransaction
        '  trn = True

        ' cmd.Transaction = Trans
        'scmd.Transaction = STrans
        'scmd1.Transaction = STrans


        For n As Long = 0 To tb1.Rows.Count - 1
            rcode = ""
            If CheckPOPSConnection() = False Then
                Me.Cursor = Cursors.Default
                MsgBox("Can't Connect POPS Server...")
                DownloadBill = False
                Exit Function
            End If

            scmd.Connection = PopsConn
            scmd.CommandType = CommandType.StoredProcedure
            scmd.CommandText = "CheckProductMap_Wholesale"
            scmd.Parameters.Add("@rclientid", SqlDbType.VarChar).Value = ClientId
            scmd.Parameters.Add("@wclientid", SqlDbType.VarChar).Value = grd.Item(4, RO).Value
            scmd.Parameters.Add("@wpcode", SqlDbType.VarChar).Value = tb1.Rows(n).Item("wpcode")

            'If CheckPOPSConnection() = False Then
            '    Me.Cursor = Cursors.Default
            '    DownloadBill = False
            '    Exit Function
            'End If

            rcode = scmd.ExecuteScalar & ""
            scmd.Parameters.Clear()

            If Trim(rcode) <> "" Then
                'rcode = rs("rprodcode")
            Else
                rcode = ""
                Me.Tag = ""
                mapformr2.Text = "Mapping products..."
                mapformr2.TextBox1.Tag = ""
                mapformr2.TextBox1.Text = tb1.Rows(n).Item("Name") & "    " & tb1.Rows(n).Item("pack") & "   (" & tb1.Rows(n).Item("cmpname") & ")"
                mapformr2.TextBox1.Tag = tb1.Rows(n).Item("Name") & "    " & tb1.Rows(n).Item("pack") & "   (" & tb1.Rows(n).Item("cmpname") & ")"
                mapformr2.Frm.Tag = tb1.Rows(n).Item("wpcode")
                mapformr2.Tag = tb1.Rows(n).Item("wclientid")
                mapformr2.comadd.Enabled = True
                mapformr2.txtname.Focus()
                mapformr2.Refresh()
                mapformr2.ShowDialog()
                rcode = mapformr2.txtcode.Tag
                mapformr2.txtcode.Tag = ""
                rcode = Me.Tag
                Me.Tag = ""
                If rcode = "" Then PopsConn.Close() : Exit Function
            End If

            If Trim(rcode) <> "" Then
                sqlexdt = "NULL"

                cmd.CommandText = "delete from rctsave where WebRowId=" & tb1.Rows(n).Item("rowid")
                cmd.ExecuteNonQuery()
                If Not IsDBNull(tb1.Rows(n).Item("exdt")) Then sqlexdt = "'" & Microsoft.VisualBasic.Format(tb1.Rows(n).Item("exdt"), "dd/MM/yyyy") & "'"
                cmd.CommandText = "insert into rctsave (code,billno,billdt,batch,exdt,tax,rate,mrp,qty,free,pack,pdis,bdis,type,seq,flag,supcode,repl,webrowid) values (""" & _
                rcode & """," & tb1.Rows(n).Item("billno") & ",'" & tb1.Rows(n).Item("billdt") & _
                "',""" & tb1.Rows(n).Item("batch") & """," & sqlexdt & "," & _
                tb1.Rows(n).Item("tax") & "," & tb1.Rows(n).Item("Rate") & "," & _
                tb1.Rows(n).Item("mrp") & "," & tb1.Rows(n).Item("qty") & "," & _
                 tb1.Rows(n).Item("free") & ",""" & tb1.Rows(n).Item("pack") & """," & _
                tb1.Rows(n).Item("pdis") & "," & tb1.Rows(n).Item("bdis") & ",'" & _
                tb1.Rows(n).Item("Type") & "'," & tb1.Rows(n).Item("seq") & ",'" & _
                tb1.Rows(n).Item("flag") & "'," & grd.Item(5, RO).Value & "," & _
                tb1.Rows(n).Item("repl") & "," & tb1.Rows(n).Item("rowid") & ")"
                cmd.ExecuteNonQuery()

            End If

        Next
        'rs.Close()
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            DownloadBill = False
            MsgBox("Can't Connect POPS Server...")
            Exit Function
        End If
        scmd1.Connection = PopsConn
        scmd1.CommandText = "update trans set Processed='P'  where  Billno=""" & grd.Item(0, RO).Value & """ and billdt=convert(datetime,'" & grd.Item(1, RO).Value & "' ) and  rclientid='" & ClientId & "' and wclientid='" + grd.Item(4, RO).Value + "' "
        scmd1.ExecuteNonQuery()
        ' Trans.Commit()
        'STrans.Commit()
        trn = False
        ReadBills()
        DownloadBill = True
        PopsConn.Close()
        Exit Function

errmsg:
        If trn Then
            ' Trans.Rollback()
            ' STrans.Rollback()
        End If
        DownloadBill = False
        PopsConn.Close()
        MsgBox(Err.Description)
    End Function

    Private Sub ReadBills()

        Dim rs As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        cmd.CommandTimeout = 200
        cmd.Connection = Conn

        Try

       
            If CheckPOPSConnection() = False Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If chk.CheckState = 1 Then
                cmd.CommandText = "select acmaster.acname,acmaster.place,billno,billdt,acmaster.accode from rctsave,acmaster where acmaster.accode=rctsave.supcode  group by acmaster.acname,acmaster.place,billno,billdt,acmaster.accode order by acmaster.acname,billno"
            Else
                cmd.CommandText = "select acmaster.acname,acmaster.place,billno,billdt,acmaster.accode from rctsave,acmaster where acmaster.accode=rctsave.supcode AND rctsave.FLAG + ''<>'P' group by acmaster.acname,acmaster.place,billno,billdt,acmaster.accode order by acmaster.acname,billno"
            End If
            rs = cmd.ExecuteReader
            billgrid.Rows.Clear()

            While rs.Read
                billgrid.Rows.Add()
                billgrid.Item(0, billgrid.Rows.Count - 1).Value = rs("billno")
                billgrid.Item(1, billgrid.Rows.Count - 1).Value = Format(rs("billdt"), "dd/MM/yyy")
                billgrid.Item(2, billgrid.Rows.Count - 1).Value = rs("acname")
                billgrid.Item(3, billgrid.Rows.Count - 1).Value = rs("place")
                billgrid.Item(4, billgrid.Rows.Count - 1).Value = rs("accode")

            End While
            rs.Close()
            billgrid.Rows.Add()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComDel.Click
        Dim cmd As New OleDb.OleDbCommand

        If MsgBox("Want to delete all Data ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If MsgBox("Want to delete all Data ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                cmd.Connection = Conn
                cmd.CommandText = "Delete  from rctsave "
                cmd.ExecuteNonQuery()
                ReadBills()
            End If
        End If

    End Sub

    Private Sub ComDelPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComDelPro.Click
        Dim cmd As New OleDb.OleDbCommand
        If MsgBox("Want to delete all Processed Data...?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            cmd.Connection = Conn
            cmd.CommandText = "Delete from rctsave WHERE FLAG + ''='P' "
            cmd.ExecuteNonQuery()
            ReadBills()
        End If

    End Sub

    Private Sub Bills_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ReadBillsWeb()
    End Sub

    Private Sub billgrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles billgrid.CellContentClick

    End Sub

    Private Sub billgrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles billgrid.CellEnter
        Dim prname As Object

        On Error GoTo errmsg

        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand

        If billgrid.Item(0, billgrid.CurrentCell.RowIndex).Value & "" = "" Then
            billgrid2.Rows.Clear()
            Exit Sub
        End If

        cmd.Connection = Conn
        cmd2.Connection = Conn
        cmd.CommandText = "select code,pack,qty,free,repl,mrp,batch,exdt from rctsave where billno=""" & billgrid.Item(0, billgrid.CurrentCell.RowIndex).Value & "" & """ and billdt=convert(datetime,'" & billgrid.Item(1, billgrid.CurrentCell.RowIndex).Value & "') and supcode = " & billgrid.Item(4, billgrid.CurrentCell.RowIndex).Value
        da.SelectCommand = cmd
        da.Fill(dt)

        billgrid2.Rows.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            cmd2.CommandText = "select pRDname from product where PRdcode = """ & dt.Rows(i).Item("code") & """"
            prname = cmd2.ExecuteScalar
            billgrid2.Rows.Add()
            billgrid2.Item(0, billgrid2.Rows.Count - 1).Value = prname
            billgrid2.Item(1, billgrid2.Rows.Count - 1).Value = dt.Rows(i).Item("pack")
            billgrid2.Item(2, billgrid2.Rows.Count - 1).Value = dt.Rows(i).Item("Qty")
            billgrid2.Item(3, billgrid2.Rows.Count - 1).Value = dt.Rows(i).Item("free")
            billgrid2.Item(4, billgrid2.Rows.Count - 1).Value = dt.Rows(i).Item("repl")
            billgrid2.Item(5, billgrid2.Rows.Count - 1).Value = dt.Rows(i).Item("Batch")
            If IsDBNull(dt.Rows(i).Item("exdt")) Then
                'billgrid2.Item(6, billgrid2.Rows.Count - 1).Value = Format(dt.Rows(i).Item("exdt"), "MM/yy")
            Else
                billgrid2.Item(6, billgrid2.Rows.Count - 1).Value = Format(dt.Rows(i).Item("exdt"), "MM/yy")
            End If

            billgrid2.Item(7, billgrid2.Rows.Count - 1).Value = Format(dt.Rows(i).Item("mrp"), "0.00")
        Next


        Exit Sub
errmsg:
        MsgBox(Err.Description)
    End Sub

    Private Sub billgrid_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles billgrid.CellMouseEnter

    End Sub

    Private Sub com_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles com_invoice.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim cmdb As New OleDb.OleDbCommand
        Dim cmdp As New OleDb.OleDbCommand

        Dim rs As OleDb.OleDbDataReader
        Dim da As New OleDb.OleDbDataAdapter
 

        Dim dtp As New DataTable
        Dim dtb As New DataTable
        Dim dr As OleDb.OleDbDataReader

        If billgrid.CurrentCell Is Nothing Then Exit Sub
        If billgrid.Item(0, billgrid.CurrentRow.Index).Value & "" = "" Then Exit Sub


        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()

        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()
        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()

        cmd.Connection = Conn

        cmdb.Connection = Conn
        cmdp.Connection = Conn

        Try
            If IsDate(billgrid.Item(1, billgrid.CurrentRow.Index).Value) Then
                cmd.Connection = Conn
                cmd.CommandText = "select top 1 rctno,pdate from batch where supcode=" & _
             billgrid.Item(4, billgrid.CurrentRow.Index).Value & " and billno=""" + billgrid.Item(0, billgrid.CurrentRow.Index).Value & """ and " & _
                "billdt=convert(datetime,'" & CDate(billgrid.Item(1, billgrid.CurrentRow.Index).Value) & "',103)"
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    MsgBox("Bill already entered... Rcpt No." & dr("rctno") & " dated " & dr("pdate"), MsgBoxStyle.Information)
                    dr.Close()
                    Exit Sub
                End If
                dr.Close()
            End If
        Catch ex As Exception

        End Try

        Dim rsv As New DataTable
        cmd.CommandText = "select * from rctsave where billno = '" & billgrid.Item(0, billgrid.CurrentRow.Index).Value & "' and billdt=convert(datetime,'" & billgrid.Item(1, billgrid.CurrentRow.Index).Value & "',103) and supcode=" & Val(billgrid.Item(4, billgrid.CurrentRow.Index).Value) & " AND rctsave.FLAG + ''<>'P' "
        da.SelectCommand = cmd
        da.Fill(rsv)
        If rsv.Rows.Count = 0 Then Exit Sub
        Dim v As Boolean = False
        Dim prch As New Purchase
        prch.Show()
        prch.Tag = "POPS"
        With prch.dgRec
            For i As Integer = 0 To rsv.Rows.Count - 1
                If Not v Then
                    prch.cbSupp.SelectedValue = billgrid.Item(4, billgrid.CurrentRow.Index).Value
                    prch.txtBilno.Text = billgrid.Item(0, billgrid.CurrentRow.Index).Value
                    'MsgBox(Format(billgrid.Item(1, billgrid.CurrentRow.Index).Value, "dd/MM/yyyy"))
                    prch.txtBildat.Text = billgrid.Item(1, billgrid.CurrentRow.Index).Value ', "dd/MM/yyyy")
                    prch.txtDis.Text = "0.00" 'Format(rs("bdis"), "0.00")
                    prch.cbSupp.Tag = billgrid.Item(4, billgrid.CurrentRow.Index).Value
                    prch.txtBildat.Tag = billgrid.Item(1, billgrid.CurrentRow.Index).Value ', "dd/MM/yyyy")
                    prch.txtBilno.Tag = billgrid.Item(0, billgrid.CurrentRow.Index).Value
                    v = True
                End If

                cmdp.CommandText = "select product.prdcode,product.prdname,product.case1,product.unit1,product.case2,product.unit2,product.case3,product.unit3 from product where prdCODE=""" + rsv.Rows(i).Item("code") + """"
                cmdb.CommandText = "select  * from batch where prdCODE=""" + rsv.Rows(i).Item("code") + """  and unit <>0 order by batchid desc"
                da.SelectCommand = cmdp
                dtp.Rows.Clear()
                dtb.Rows.Clear()
                da.Fill(dtp)
                da.SelectCommand = cmdb
                da.Fill(dtb)

                '.Rows.Add()

                .Item(0, .Rows.Count - 1).Value = .Rows.Count

                .Item(1, .Rows.Count - 1).Value = ""
                .Item(8, .Rows.Count - 1).Value = dtp.Rows(0).Item("PrdCode")
                .Item(9, .Rows.Count - 1).Value = dtp.Rows(0).Item("PrdName")
                .Item(10, .Rows.Count - 1).Value = rsv.Rows(i).Item("batch")
                If Not IsDBNull(rsv.Rows(i).Item("ExDt")) Then
                    .Item(11, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("ExDt"), "dd/MM/yyyy")
                    prch.ExpColor(.Rows.Count - 1)
                Else
                    .Item(11, .Rows.Count - 1).Value = ""
                End If


                .Item(26, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("tax"), "0.00")
                .Item(15, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("tax"), "0.00")

                .Item(13, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("Rate"), "0.00")
                .Item(14, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("MRP"), "0.00")
                .Item(16, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("PDis") + rsv.Rows(i).Item("bdis"), "0.00")
                .Item(25, .Rows.Count - 1).Value = "0.00"
                .Item(28, .Rows.Count - 1).Value = "0.00"
                .Item(29, .Rows.Count - 1).Value = "0.00"

                If dtb.Rows.Count > 0 Then
                    If Not dtb.Rows(0).Item("TaxInc") Then
                        .Item(27, .Rows.Count - 1).Value = "No"
                    Else
                        .Item(27, .Rows.Count - 1).Value = "Yes"
                    End If

                    .Item(2, .Rows.Count - 1).Value = dtb.Rows(0).Item("unit")

                    Select Case dtb.Rows(0).Item("unit")
                        Case dtp.Rows(0).Item("unit1")
                            .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("case1") & " (" & dtb.Rows(0).Item("unit") & ")"

                        Case dtp.Rows(0).Item("unit2")
                            .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("case2") & " (" & dtb.Rows(0).Item("unit") & ")"

                        Case dtp.Rows(0).Item("unit3")
                            .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("case3") & " (" & dtb.Rows(0).Item("unit") & ")"
                        Case Else
                            If Val(dtp.Rows(0).Item("unit2") & "") = 0 Then
                                .Item(2, .Rows.Count - 1).Value = dtp.Rows(0).Item("unit1")
                                .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("CASE1")
                            Else
                                .Item(2, .Rows.Count - 1).Value = dtp.Rows(0).Item("unit2")
                                .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("CASE2") & " (" & dtp.Rows(0).Item("unit2") & ")"
                            End If
                            .Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                    End Select


                Else
                    .Item(27, .Rows.Count - 1).Value = "Yes"
                    .Item(27, .Rows.Count - 1).Style.ForeColor = Color.Red
                    If Val(dtp.Rows(0).Item("unit2") & "") = 0 Then
                        .Item(2, .Rows.Count - 1).Value = dtp.Rows(0).Item("unit1")
                        .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("CASE1")
                    Else
                        .Item(2, .Rows.Count - 1).Value = dtp.Rows(0).Item("unit2")
                        .Item(22, .Rows.Count - 1).Value = dtp.Rows(0).Item("CASE2") & " (" & dtp.Rows(0).Item("unit2") & ")"
                    End If
                    .Item(22, .Rows.Count - 1).Style.ForeColor = Color.Red
                End If
                .Item(19, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("Qty"), "0")
                .Item(20, .Rows.Count - 1).Value = Format(rsv.Rows(i).Item("free"), "0")
                .Item(21, .Rows.Count - 1).Value = Format(Val(rsv.Rows(i).Item("repl") & ""), "0")
                prch.Rcpts.Rows.Add()
                prch.Calculate()
                prch.tsbSave.Enabled = True
            Next


        End With

    End Sub

    Private Sub billgrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles billgrid.KeyDown
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        If e.KeyCode = 46 Then
            If MsgBox("Want to Delete selected Purchase...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                If MsgBox("Want to Delete selected Purchase...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    cmd.CommandText = "delete from rctsave where billno=""" & billgrid.Item(0, billgrid.CurrentRow.Index).Value & """ and billdt=convert(datetime,'" & billgrid.Item(1, billgrid.CurrentRow.Index).Value & "',103) and supcode=" & billgrid.Item(4, billgrid.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()
                    ReadBills()
                End If
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim dic As New List(Of Integer)
        Me.Cursor = Cursors.WaitCursor
        For i = 0 To grd.SelectedCells.Count - 1
            If Not dic.Contains(grd.SelectedCells(i).RowIndex) Then
                dic.Add(grd.SelectedCells(i).RowIndex)
            End If
        Next

        For i = 0 To dic.Count - 1
            DownloadBill(dic(i))
        Next
        ReadBillsWeb()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim cmd As New SqlClient.SqlCommand
        Dim dic As New List(Of Integer)
        Me.Cursor = Cursors.WaitCursor
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        For i = 0 To grd.SelectedCells.Count - 1
            If Not dic.Contains(grd.SelectedCells(i).RowIndex) Then
                dic.Add(grd.SelectedCells(i).RowIndex)
            End If
        Next

        cmd.Connection = PopsConn
        If MsgBox("Want to delete selected bills from server ? ", vbYesNo + vbDefaultButton2) = vbYes Then
            For i = 0 To dic.Count - 1
                cmd.CommandText = "delete from trans where rclientid='" + ClientId + "' and wclientid='" + grd.Item(4, dic(i)).Value + "' and billno=""" & grd.Item(0, dic(i)).Value & """  and billdt=convert(datetime,'" & grd.Item(1, dic(i)).Value & "') and  type='" & grd.Item(6, dic(i)).Value & "' "
                cmd.ExecuteNonQuery()
            Next
        End If
        ReadBillsWeb()
        Me.Cursor = Cursors.Default
        PopsConn.Close()
    End Sub

    Private Sub grd_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellDoubleClick
        DownloadBill(grd.CurrentCell.RowIndex)
        ReadBillsWeb()
    End Sub

    Private Sub billgrid2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles billgrid2.CellContentClick

    End Sub
End Class