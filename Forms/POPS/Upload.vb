Public Class Upload
    Private Sub com_trans_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles com_trans.Click
        Dim trn As Object
        Dim X As Object
        Dim rs3 As SqlClient.SqlDataReader
        Dim rs5 As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim scmd As New SqlClient.SqlCommand

        Dim NO As String
        On Error GoTo errmsg
        If Not IsDate(txtdt.Text) Then
            MsgBox("Invalid Date...")
            txtdt.Focus()
            Exit Sub
        End If
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        cmd.Connection = Conn
        scmd.Connection = PopsConn
        lst.Items.Clear()
        scmd.CommandText = "select wclientid,rsupcode from supmap where rclientid ='" & ClientId & "'"
        rs3 = scmd.ExecuteReader
        While rs3.Read
            cmd.CommandText = "select ordno,orddt,acmaster.acname + ' ' + acmaster.place as [sup],supcode  from pndord,acmaster where acmaster.accode=pndord.supcode and supcode=" & rs3("rsupcode") & " and orddt = convert(datetime,'" & txtdt.Text & "') and ordno<>0 group by orddt,ordno,acmaster.acname + ' ' + acmaster.place,supcode order by ordno"
            rs5 = cmd.ExecuteReader
            While rs5.Read
                NO = rs5("Ordno")
                NO = NO.PadRight(6, " ")

                X = NO & " " & Format(rs5("orddt"), "dd/MM/yyyy").ToString.PadRight(10, " ") & "  " & rs5("sup") & ""
                lst.Items.Add(New MyList(X, rs5("SupCode")))
            End While
            rs5.Close()
        End While
        rs3.Close()
        PopsConn.Close()
        Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)
    End Sub

    Private Sub comdall_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comdall.Click
        Dim i As Object

        For i = 0 To lst.Items.Count - 1
            lst.SetItemChecked(i, False)
        Next i
        lst.Refresh()
        If lst.Items.Count <> 0 Then lst.SelectedIndex = 0
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim wcod As Object
        Dim Worddt As Object
        Dim Wordno As Object
        Dim da As New SqlClient.SqlDataAdapter
        Dim da1 As New OleDb.OleDbDataAdapter
        Dim dtab As New DataTable
        Dim trn As Object
        Dim mapped As Object
        Dim i As Object
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmdv As New OleDb.OleDbCommand
        Dim scmd As New SqlClient.SqlCommand
        Dim scmd1 As New SqlClient.SqlCommand
        On Error GoTo errmsg

        Dim Tran As Boolean
        Dim sdata, bwcode As String
        Dim prod As String
        Dim prname As String
        Dim free As String
        Dim Trans As OleDb.OleDbTransaction
        Dim mList As MyList

        If CheckPOPSConnection() = False Then
            MsgBox("Can't connect POPS Server...")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        scmd1.Connection = PopsConn
        cmd.Connection = Conn
        cmd1.Connection = Conn
        cmdv.Connection = Conn
        Me.Cursor = Cursors.WaitCursor

        scmd.CommandTimeout = 180
        scmd1.CommandTimeout = 180
        cmd.CommandTimeout = 180
        cmd1.CommandTimeout = 180
        cmdv.CommandTimeout = 180


        pbar.Value = 0
        pbar.Maximum = lst.Items.Count
        For i = 0 To lst.Items.Count - 1
            pbar.Value = i
            If lst.GetItemChecked(i) = True Then
                mList = lst.Items(i)
                scmd.CommandType = CommandType.Text
                scmd.CommandText = "select wclientid from supmap where rclientid = """ & ClientId & """ and rsupcode = """ & mList.ItemData & """"
                sdata = scmd.ExecuteScalar & ""
                If sdata = "" Then
                    Me.Cursor = Cursors.Default
                    PopsConn.Close()
                    MsgBox("The Supplier is not mapped. Map the supplier and try again.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                cmdv.CommandText = "select pndord.*,product.prdname,product.case1 from pndord,product where product.prdcode=pndord.prdcode and ordno=" & Val(Microsoft.VisualBasic.Left(mList.Name, 5)) & " and  orddt = convert(datetime,'" & Mid(mList.Name, 8, 10) & "') order by ordno"
                da1.SelectCommand = cmdv
                dtab.Rows.Clear()
                dtab.Clear()
                da1.Fill(dtab)
                For v As Integer = 0 To dtab.Rows.Count - 1
                    If CheckPOPSConnection() = False Then
                        MsgBox("Can't connect POPS Server...")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    prod = dtab.Rows(v).Item("prdcode")
                    prname = dtab.Rows(v).Item("prdName")
                    scmd.CommandType = CommandType.StoredProcedure
                    scmd.CommandText = "CheckProductMap_Retail"
                    scmd.Parameters.Add("@rclientid", SqlDbType.VarChar).Value = ClientId
                    scmd.Parameters.Add("@wclientid", SqlDbType.VarChar).Value = sdata
                    scmd.Parameters.Add("@rpcode", SqlDbType.VarChar).Value = prod
                    bwcode = scmd.ExecuteScalar
                    scmd.Parameters.Clear()
                    If Trim(bwcode) = "" Then
                        Me.Cursor = Cursors.Default
                        mapformr.lblsup.Text = mList.Name.ToString
                        mapformr.Command1.Tag = "Trans"
                        mapformr.Text = "Maping Product...."
                        mapformr.lblprod.Text = prname & "  - " & dtab.Rows(v).Item("pack")
                        mapformr.lblprod.Tag = prod
                        mapformr.Tag = sdata
                        mapformr.txtname.Text = ""
                        mapformr.txtcode.Text = ""
                        mapformr.ShowDialog()
                        mapformr.Command1.Tag = ""
                        mapped = Me.Tag
                        Me.Cursor = Cursors.WaitCursor
                    End If
                Next
            End If
        Next
        pbar.Value = 0


        Dim ordtab As New DataTable
        Dim ds As New DataSet

        ordtab.TableName = "order"
        ds.DataSetName = "pops"
        ds.Tables.Add(ordtab)
        'clientid,supclientid,prodcode,prodname,qty,free,orderno,orderdate,prodcoder,rordno,rorddt
        ordtab.Columns.Add("prodcode", GetType(System.String))
        ordtab.Columns.Add("prodname", GetType(System.String))
        ordtab.Columns.Add("qty", GetType(System.Double))
        ordtab.Columns.Add("free", GetType(System.Double))
        ordtab.Columns.Add("prodcoder", GetType(System.String))

        Me.Cursor = Cursors.Default


        Dim pram1 As New SqlClient.SqlParameter
        Dim pram2 As New SqlClient.SqlParameter
        Dim pram3 As New SqlClient.SqlParameter
        Dim pram4 As New SqlClient.SqlParameter
        Dim pram5 As New SqlClient.SqlParameter
        Dim pram6 As New SqlClient.SqlParameter

        pram1.ParameterName = "@ClientId"
        pram1.SqlDbType = SqlDbType.VarChar
        pram1.Size = 20
        pram1.Direction = ParameterDirection.Input

        pram2.ParameterName = "@SupClientid"
        pram2.SqlDbType = SqlDbType.VarChar
        pram2.Size = 20
        pram2.Direction = ParameterDirection.Input

        pram3.ParameterName = "@cordno"
        pram3.SqlDbType = SqlDbType.BigInt
        pram3.Direction = ParameterDirection.Input

        pram4.ParameterName = "@corddt"
        pram4.SqlDbType = SqlDbType.Date
        pram4.Direction = ParameterDirection.Input

        pram5.ParameterName = "@XML"
        pram5.SqlDbType = SqlDbType.Xml
        pram5.Direction = ParameterDirection.Input


        pram6.ParameterName = "@Sucess"
        pram6.Size = 10
        pram6.SqlDbType = SqlDbType.VarChar
        pram6.Direction = ParameterDirection.Output
      

      

      




        For i = 0 To lst.Items.Count - 1
            pbar.Value = i
            If lst.GetItemChecked(i) = True Then
                If CheckPOPSConnection() = False Then
                    MsgBox("Can't connect POPS Server...")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                mList = lst.Items(i)
                scmd.CommandType = CommandType.Text
                scmd.CommandText = "select wclientid from supmap where rclientid = """ & ClientId & """ and rsupcode = """ & mList.ItemData & """"
                sdata = scmd.ExecuteScalar & ""
                If sdata = "" Then
                    Me.Cursor = Cursors.Default
                    MsgBox("The Supplier is not mapped. Map the supplier and try again.", MsgBoxStyle.Critical)

                    trn = False
                    PopsConn.Close()
                    Exit Sub
                End If

                scmd.CommandType = CommandType.Text
                scmd.CommandText = "select * from orders where " & " rordno=" & Val(Microsoft.VisualBasic.Left(mList.Name, 5)) & " and rorddt = convert(datetime,'" & Mid(mList.Name, 8, 10) & "') and clientid=""" & ClientId & """"
                da.SelectCommand = scmd
                dtab.Rows.Clear()
                dtab.Clear()
                da.Fill(dtab)
                If dtab.Rows.Count > 0 Then
                    If dtab.Rows(0).Item("processed") & "" = "P" Then
                        trn = False
                        GoTo nexRec
                    End If
                End If
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "select round(pndord.qty/pndord.unit,2) as [qty],pndord.prdcode,orddt,ordno,product.prdname,product.case1 from pndord,product  where product.prdcode=pndord.prdcode and ordno=" & Val(Microsoft.VisualBasic.Left(mList.Name, 5)) & " and  orddt = convert(datetime,'" & Mid(mList.Name, 8, 10) & "') order by ordno"
                da1.SelectCommand = cmd
                dtab.Rows.Clear()
                dtab.Clear()
                da1.Fill(dtab)
                Dim dr As DataRow
                ordtab.Rows.Clear()
                ordtab.Clear()
                For v = 0 To dtab.Rows.Count - 1
                    scmd.CommandText = "select Wprodcode from PRODMAP where Rclientid=""" & ClientId & """ and Wclientid=""" & sdata & """ and Rprodcode=""" + dtab.Rows(v).Item("prdcode") + """ "
                    wcod = scmd.ExecuteScalar
                    dr = ordtab.NewRow
                    dr.Item("prodcode") = wcod
                    dr.Item("prodname") = dtab.Rows(v).Item("prdName")
                    dr.Item("qty") = System.Math.Round(dtab.Rows(v).Item("qty"), 2)
                    dr.Item("free") = 0
                    dr.Item("prodcoder") = dtab.Rows(v).Item("prdcode")
                    ordtab.Rows.Add(dr)
                Next
                If dtab.Rows.Count <> 0 Then
                    scmd.Parameters.Add(pram1)
                    scmd.Parameters.Add(pram2)
                    scmd.Parameters.Add(pram3)
                    scmd.Parameters.Add(pram4)
                    scmd.Parameters.Add(pram5)
                    scmd.Parameters.Add(pram6)
                    pram1.Value = ClientId
                    pram2.Value = sdata
                    pram3.Value = dtab.Rows(0).Item("Ordno").ToString
                    pram4.Value = dtab.Rows(0).Item("orddt")
                    pram5.Value = ds.GetXml
                    scmd.CommandType = CommandType.StoredProcedure
                    scmd.CommandText = "InsertRetailPOPSOrder"
                    scmd.ExecuteNonQuery()
                    scmd.Parameters.Clear()
                End If
            End If
nexRec:
        Next i
       
        pbar.Value = 0
        Me.Cursor = Cursors.Default
        PopsConn.Close()
        MsgBox("Uploading Completed...")
        Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        If trn Then
            Trans.Rollback()
        End If
        PopsConn.Close()
        MsgBox(Err.Description)

    End Sub

    Private Sub Comsall_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Comsall.Click
        Dim i As Object
        For i = 0 To lst.Items.Count - 1
            lst.SetItemChecked(i, True)
        Next i
        lst.Refresh()
        If lst.Items.Count <> 0 Then lst.SelectedIndex = 0
    End Sub

    Private Sub trans_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtdt.Text = Format(SysDt, "dd/MM/yyyy")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class