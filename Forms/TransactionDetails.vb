Public Class TransactionDetails

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OptSales.Checked = True
    End Sub

    Private Sub comview_Click(sender As System.Object, e As System.EventArgs) Handles comview.Click
        Dim CMD As New OleDb.OleDbCommand
        Dim DA As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        CMD.Connection = Conn





        If OptSales.Checked Then


            If CB.SelectedIndex = 0 Then
                CMD.CommandText = "select invno as [Bill No],invdt as [Date],name as [Patient],docname [Doctor],netamt as [Amount],bdisamt as [Discount],usrname  as [User],salname as [Sales Man] , node as [Computer],Edited as [Edited]" & _
                        " from  Invtotal LEFT OUTER JOIN Salesman ON Invtotal.SMan = Salesman.SalCode  where invdt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                             "' and  invdt<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and type='" & cbType.SelectedValue & "' and  cancelled=0 and (cuscode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') order by invdt,invno"
            ElseIf CB.SelectedIndex = 1 Then
                CMD.CommandText = "select invno as [Bill No],invdt as [Date],product.PRDname [Product] ,invdetails.qty as [Qty],invdetails.srate as [S Rate],Batch,ExDt as [Ex.Dt] " & _
                    " from  invdetails inner JOIN product ON product.prdcode = invdetails.prdCode  where invdt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                   "' and  invdt<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and type='" & cbType.SelectedValue & "' and  cancelled=0 and (cuscode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') order by invdt,invno"
            Else

                CMD.CommandText = "select  product.PRDname [Product],sum(invdetails.qty) as [Qty],CONVERT(NUMERIC(18,2),SUM(invdetails.srate * invdetails.qty)) as [Value]  " & _
                      " from  invdetails inner JOIN product ON product.prdcode = invdetails.PRDCode  where invdt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                       "' and  invdt<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and type='" & cbType.SelectedValue & "' and  cancelled=0 and (cuscode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') " & _
                       " GROUP BY product.PRDname order by PRDNAME"
            End If



        ElseIf OptPurch.Checked Then

            If CB.SelectedIndex = 0 Then
                CMD.CommandText = "select rctno as [Rct No],Pdate as [Rct Date], billno as [Bill No],BillDt as [Bill Date],rctamt as [Amount],acmaster.acname + ' '  + acmaster.place as [Supplier ],billdis as [Bill Disc], usrname  as [User],node as [Computer] " & _
                             " from  purchase LEFT OUTER JOIN acmaster ON acmaster.accode = purchase.supcode  where pdate>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                                "' and  pdate<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and type='" & cbType.SelectedValue & "' and  (purchase.supcode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') order by pdate,rctno"
            ElseIf CB.SelectedIndex = 1 Then
                CMD.CommandText = "SELECT Purchase.Rctno AS [Rcpt No], Purchase.Pdate AS [Rcpt Date], Product.PrdName as [Product], Product.case1 as [Pack], Batch.Batch, Batch.ExDt, " & _
                    "Batch.PRate [P.Rate], Batch.SRate as [S Rate],batch.Rqty as [Qty],batch.Fqty as [Free],batch.Repqty as [Repl],batch.Stock as [Stock], Batch.PDis, Batch.BDis,Batch.Ptax as [P.VAT], Batch.Stax as [S VAT], Purchase.BillNo AS [Bill No], Purchase.BillDt AS [Bill Date], Company.ComName AS [Company]," & _
                    "Acmaster.AcName + ' ' + Acmaster.Place AS [Supplier ], Purchase.Usrname AS [User], Purchase.node AS Computer " & _
                    "FROM Purchase INNER JOIN Batch ON Purchase.Type = Batch.Type AND Purchase.Pdate = Batch.PDate AND Purchase.Rctno = Batch.RctNo INNER JOIN " & _
                    "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN Company ON Product.Comcode = Company.ComCode LEFT OUTER JOIN acmaster ON Acmaster.AcCode = Purchase.Supcode " & _
                    " where Purchase.pdate>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                    "' and  Purchase.pdate<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and Purchase.type='" & cbType.SelectedValue & "' and (purchase.supcode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') order by Purchase.pdate,Purchase.rctno"
            Else
                CMD.CommandText = "SELECT Product.PrdName as [Product], Product.case1 as [Pack], " & _
                        "sum(batch.Rqty) as [Qty],sum(batch.Fqty) as [Free],sum(batch.Repqty) as [Repl],Company.ComName AS [Company] " & _
                                                "FROM Purchase INNER JOIN Batch ON Purchase.Type = Batch.Type AND Purchase.Pdate = Batch.PDate AND Purchase.Rctno = Batch.RctNo INNER JOIN " & _
                        "Product ON Batch.PrdCode = Product.PrdCode INNER JOIN Company ON Product.Comcode = Company.ComCode LEFT OUTER JOIN acmaster ON Acmaster.AcCode = Purchase.Supcode " & _
                        " where Purchase.pdate>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                        "' and  Purchase.pdate<='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and Purchase.type='" & cbType.SelectedValue & "' and (purchase.supcode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='') group by prdname,case1,ComName order by prdname,case1"
            End If


        ElseIf optord.Checked Then
            CMD.CommandText = "SELECT PndOrd.OrdNo as [Ord No], PndOrd.orddt [Ord Dt], Product.PrdName as [Product], PndOrd.Pack as [Pack], convert(numeric(18,0),PndOrd.Qty / PndOrd.Unit) AS Qty, " & _
             "convert(numeric(18,0),PndOrd.Free / PndOrd.Unit) AS Free," & _
             "Acmaster.AcName AS [Supplier], Acmaster.Place, Company.ComName as [Company] FROM  PndOrd INNER JOIN " & _
             "Product ON PndOrd.PrdCode = Product.PrdCode INNER JOIN " & _
             "Company ON Product.Comcode = Company.ComCode INNER JOIN " & _
             "Acmaster ON PndOrd.SupCode = Acmaster.AcCode   where orddt>='" & _
             Format(dtf.Value.Date, "yyyyMMdd") & "' and  orddt<='" & Format(dtt.Value.Date, "yyyyMMdd") & _
             "' and (PndOrd.supcode=" & Val(cbsupp.SelectedValue) & " or """ & cbsupp.Text & """ ='')   order by orddt,ordno,prdname,case1"

        End If
        DA.SelectCommand = CMD
        DA.Fill(dt)
        gv.DataSource = dt
    End Sub

    Private Sub OptSales_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OptSales.CheckedChanged

        Dim CMD As New OleDb.OleDbCommand
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        If Not OptSales.Checked Then Exit Sub
        CMD.Connection = Conn
        CMD.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where type>20 and type<29 order by seq"
        DA.SelectCommand = CMD
        DA.Fill(DS, "SerialNum")
        cbType.DisplayMember = "Descr"
        cbType.ValueMember = "Type"
        cbType.DataSource = DS.Tables("SerialNum")
        cbType.Enabled = True
        cbsupp.Enabled = True


        CMD.CommandText = "select Accode,Acname + ' ' + place  as [AcName] from Acmaster where grpcode=" & CustGrpcode & " order by Acname"

        DA.SelectCommand = CMD
        DA.Fill(DS, "Acmaster")
        cbsupp.DisplayMember = "AcName"
        cbsupp.ValueMember = "AcCode"
        cbsupp.DataSource = DS.Tables("Acmaster")
        cbsupp.SelectedValue = -1
        cbsupp.Enabled = True
        lblPRsup.Text = "Customer:"
        CB.SelectedIndex = 0

    End Sub

    Private Sub OptPurch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OptPurch.CheckedChanged
        Dim CMD As New OleDb.OleDbCommand
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        If Not OptPurch.Checked Then Exit Sub
        CMD.Connection = Conn
        CMD.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where type>10 and type<19 order by seq"
        DA.SelectCommand = CMD
        DA.Fill(DS, "SerialNum")
        cbType.DisplayMember = "Descr"
        cbType.ValueMember = "Type"
        cbType.DataSource = DS.Tables("SerialNum")
        cbType.Enabled = True

        CMD.CommandText = "select Accode,Acname + ' ' + place  as [AcName] from Acmaster where grpcode=" & SupGrpcode & " order by Acname"

        DA.SelectCommand = CMD
        DA.Fill(DS, "Acmaster")
        cbsupp.DisplayMember = "AcName"
        cbsupp.ValueMember = "AcCode"
        cbsupp.DataSource = DS.Tables("Acmaster")
        cbsupp.SelectedValue = -1
        cbsupp.Enabled = True
        lblPRsup.Text = "Supplier:"
        CB.SelectedIndex = 0
    End Sub

    Private Sub optord_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optord.CheckedChanged
       
        If Not optord.Checked Then Exit Sub
        cbType.DataSource = Nothing
        cbType.Enabled = False
        cbsupp.Enabled = False
    End Sub

    Private Sub cbsupp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbsupp.KeyDown
        If e.KeyCode = Keys.Delete Then
            cbsupp.SelectedValue = -1

        End If

    End Sub

    Private Sub cbsupp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbsupp.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub gv_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv.CellContentClick

    End Sub
End Class