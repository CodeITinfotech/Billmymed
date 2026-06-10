Public Class ServiceTools

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim tb As New DataTable
        Dim x As Long

        If TextBox1.Text <> UCase("SERVICE1") Then
            MsgBox("Invalid Password")
            Exit Sub
        End If
        cmd.Connection = Conn
        cmd.CommandText = "select rctno,type,pdate from purchase  where (type='11' or type='12') order by pdate,type,rctno "
        da.SelectCommand = cmd
        da.Fill(tb)
        If tb.Rows.Count = 0 Then Exit Sub
        x = Val(InputBox("Enter  Rcpt No. to Start ", , 1))
        If x = 0 Then x = 1
        Dim dt As Date
        For i = 0 To tb.Rows.Count - 1
            dt = tb.Rows(i).Item("pdate")
            cmd.CommandText = "update purchase set rctno=" & x & " where rctno=" & tb.Rows(i).Item("Rctno") & _
                " and  type='" & tb.Rows(i).Item("type") & "' and pdate=convert(datetime,'" & dt & "') "
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update batch set rctno=" & x & " where rctno=" & tb.Rows(i).Item("Rctno") & _
                " and  type='" & tb.Rows(i).Item("type") & "' and pdate=convert(datetime,'" & dt & "')"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update ledger set invcode='" & tb.Rows(i).Item("type") & x & "' where invcode='" & _
                tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "' and trndate=convert(datetime,'" & dt & "')"
            cmd.ExecuteNonQuery()
            x = x + 1
        Next

        MsgBox("Over ")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> UCase("SERVICE1") Then
            MsgBox("Invalid Password")
            Exit Sub
        End If
        FromAmruth.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim tb As New DataTable
        Dim tb1 As New DataTable
        Dim x, cc As Long

        If TextBox1.Text <> UCase("SERVICE1") Then
            MsgBox("Invalid Password")
            Exit Sub
        End If

        cc = InputBox("Enter Cash Code")

        cmd.Connection = Conn
        cmd.CommandText = "select rctno,type,pdate,rctamt,SUPCODE,BILLNO,BILLDT from purchase  where (type='11' or type='12') and pdate>=convert(datetime,'" & DateTimePicker1.Value.Date & "') order by pdate,type,rctno "
        da.SelectCommand = cmd
        tb.Clear()
        da.Fill(tb)

        For i = 0 To tb.Rows.Count - 1
            cmd.CommandText = "select  seq,vouno,trndate from ledger  where invcode='" & _
                    tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "' and trndate=convert(datetime,'" & tb.Rows(i).Item("pdate") & "') and trntype='Pu' and seq=1 order by vouno"
            tb1.Clear()
            da.Fill(tb1)
            If tb1.Rows.Count > 0 Then
                For x = 1 To tb1.Rows.Count - 1
                    cmd.CommandText = "delete from ledger where vouno=" & tb1.Rows(x).Item("vouno") & " and trntype='Pu' and trndate=convert(datetime,'" & tb1.Rows(x).Item("trndate") & "')"
                    cmd.ExecuteNonQuery()
                Next
            ElseIf tb1.Rows.Count = 0 Then
                cmd.CommandText = "select  seq,vouno,trndate from ledger  where invcode='" & _
                 tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "' and trndate=convert(datetime,'" & tb.Rows(i).Item("pdate") & "') and trntype='Pu' and seq<>1 order by vouno"
                tb1.Clear()
                da.Fill(tb1)
                If tb1.Rows.Count > 0 Then
                    If tb.Rows(i).Item("type") = "11" Then
                        cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                       "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,pamt) values('" & _
                       tb.Rows(i).Item("pdate") & "','Pu'," & tb1.Rows(0).Item("vouno") & "," & _
                     cc & "," & tb.Rows(i).Item("rctamt") * -1 & ",1,""" & _
                       tb.Rows(i).Item("biLLno") & """,'" & tb.Rows(i).Item("billdt") & "'," & _
                       DateAdd(DateInterval.Day, 21, tb.Rows(i).Item("billdt")) & "," & _
                       "1,'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "',COALESCE((select sum(amt) from adjdetails where " & _
                       " billtrntype='Pu' and  billvouno=" & tb1.Rows(0).Item("vouno") & " and billtrndt=convert(datetime,'" & tb1.Rows(0).Item("trndate") & "'  )),0)) "
                    Else
                        cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                           "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,pamt) values('" & _
                           tb.Rows(i).Item("pdate") & "','Pu'," & tb1.Rows(0).Item("vouno") & "," & _
                          tb.Rows(i).Item("supcode") & "," & tb.Rows(i).Item("rctamt") * -1 & ",2,""" & _
                           tb.Rows(i).Item("biLLno") & """,'" & tb.Rows(i).Item("billdt") & "'," & _
                           DateAdd(DateInterval.Day, 21, tb.Rows(i).Item("billdt")) & "," & _
                           "1,'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "',COALESCE((select sum(amt) from adjdetails where " & _
                           " billtrntype='Pu' and  billvouno=" & tb1.Rows(0).Item("vouno") & " and billtrndt=convert(datetime,'" & tb1.Rows(0).Item("trndate") & "'  )),0)) "
                    End If
                    cmd.ExecuteNonQuery()
                Else
                    MsgBox("Purchase " & tb.Rows(i).Item("rctno"))
                End If

            End If

        Next

        MsgBox("SALES")


        cmd.Connection = Conn
        cmd.CommandText = "select invno,type,invdt,netamt,CUSCODE from invtotal  where (type='21' or type='22') and invdt>=convert(datetime,'" & DateTimePicker1.Value.Date & "') order by invdt,type,invno "
        da.SelectCommand = cmd
        tb.Clear()
        da.Fill(tb)

        For i = 0 To tb.Rows.Count - 1
            cmd.CommandText = "select  seq,vouno,trndate from ledger  where invcode='" & _
                    tb.Rows(i).Item("type") & tb.Rows(i).Item("invno") & "' and trndate=convert(datetime,'" & tb.Rows(i).Item("invdt") & "') and trntype='Sv' and seq=1 order by vouno"
            tb1.Clear()
            da.Fill(tb1)
            If tb1.Rows.Count > 0 Then
                For x = 1 To tb1.Rows.Count - 1
                    cmd.CommandText = "delete from ledger where vouno=" & tb1.Rows(x).Item("vouno") & " and trntype='Sv' and trndate=convert(datetime,'" & tb1.Rows(x).Item("trndate") & "')"
                    cmd.ExecuteNonQuery()
                Next
            ElseIf tb1.Rows.Count = 0 Then
                cmd.CommandText = "select  seq,vouno,trndate from ledger  where invcode='" & _
                 tb.Rows(i).Item("type") & tb.Rows(i).Item("invno") & "' and trndate=convert(datetime,'" & tb.Rows(i).Item("invdt") & "') and trntype='Sv' and seq<>1 order by vouno"
                tb1.Clear()
                da.Fill(tb1)
                If tb1.Rows.Count > 0 Then
                    If tb.Rows(i).Item("type") = "21" Then
                        cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                       "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,pamt) values('" & _
                       tb.Rows(i).Item("invdt") & "','Sv'," & tb1.Rows(0).Item("vouno") & "," & _
                     cc & "," & tb.Rows(i).Item("netamt") & ",1,""" & _
                       tb.Rows(i).Item("invno") & """,'" & tb.Rows(i).Item("invdt") & "'," & _
                       DateAdd(DateInterval.Day, 21, tb.Rows(i).Item("invdt")) & "," & _
                       "1,'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("invno") & "',0) "

                    Else

                        cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                           "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,pamt) values('" & _
                           tb.Rows(i).Item("invdt") & "','Sv'," & tb1.Rows(0).Item("vouno") & "," & _
                         Val(tb.Rows(i).Item("cuscode") & "") & "," & tb.Rows(i).Item("netamt") & ",2,""" & _
                           tb.Rows(i).Item("invno") & """,'" & tb.Rows(i).Item("invdt") & "'," & _
                           DateAdd(DateInterval.Day, 21, tb.Rows(i).Item("invdt")) & "," & _
                           "1,'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("invno") & "',COALESCE((select sum(amt) from adjdetails where " & _
                           " billtrntype='Sv' and  billvouno=" & tb1.Rows(0).Item("vouno") & " and billtrndt=convert(datetime,'" & tb1.Rows(0).Item("trndate") & "'  )),0)) "
                    End If
                    cmd.ExecuteNonQuery()
                Else
                    MsgBox("Sales " & tb.Rows(i).Item("invno"))
                End If

            End If
        Next
        MsgBox("Over ")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim tb As New DataTable
        Dim tb1 As New DataTable
        Dim x, cc As Long

        If TextBox1.Text <> UCase("SERVICE1") Then
            MsgBox("Invalid Password")
            Exit Sub
        End If

        ' cc = InputBox("Enter Cash Code")

        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "AccNotPostedPur"
        da.SelectCommand = cmd
        tb.Clear()
        da.Fill(tb)
        Dim vouno, cashcode, billtype, pcode, seq As Long
        Dim sqlddt
        cmd.CommandType = CommandType.Text
        For i = 0 To tb.Rows.Count - 1


            cmd.CommandText = "update serialnum set slno=slno+1 where type=94"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select slno from serialnum where type=94"
            vouno = cmd.ExecuteScalar


            cmd.CommandText = "select pucacode from settings "
            cashcode = cmd.ExecuteScalar


            If tb.Rows(i).Item("type") = "12" Then
                billtype = 2
                pcode = tb.Rows(i).Item("supcode")
            Else
                pcode = cashcode
                billtype = 1
            End If


            sqlddt = "NULL"
             
          

            cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode ) values(100,'" & _
                        tb.Rows(i).Item("pdate") & "','Pu'," & vouno & "," & _
                        pcode & "," & Val(tb.Rows(i).Item("rctamt")) * -1 & "," & billtype & ",""" & _
                        tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("bilLdt") & "'," & sqlddt & "," & _
                        "1,'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"

            cmd.ExecuteNonQuery()

            seq = 2

            'For i = 0 To dgPurch.RowCount - 1
            If tb.Rows(i).Item("Pamt2") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1520," & _
                    (tb.Rows(i).Item("Pamt2")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If

            If tb.Rows(i).Item("Pamt3") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1956," & _
                    (tb.Rows(i).Item("Pamt3")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If

            If tb.Rows(i).Item("ptx2") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1769," & _
                    (tb.Rows(i).Item("ptx2")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If

            If tb.Rows(i).Item("ptx3") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1954," & _
                    (tb.Rows(i).Item("ptx3")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If


            If tb.Rows(i).Item("ptfamt") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1521," & _
                    (tb.Rows(i).Item("ptfamt")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If


            If tb.Rows(i).Item("padj") <> 0 Then
                cmd.CommandText = "insert into Ledger (repcode,TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,billdt,Seq,InvCode) " & _
                    "values(100,'" & tb.Rows(i).Item("pdate") & "','Pu'," & _
                    vouno & ", 1522," & _
                    (tb.Rows(i).Item("padj")) & _
                    "," & billtype & ",""" & _
                    tb.Rows(i).Item("billno") & """,'" & tb.Rows(i).Item("billdt") & "'," & seq & ",'" & tb.Rows(i).Item("type") & tb.Rows(i).Item("rctno") & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1
            End If
            'Next i

            'End If

        Next


        MsgBox("oVER ")
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim CMD As New OleDb.OleDbCommand
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim DT As New DataTable
        Dim rtaxary(4, 2) As Double
        Dim rptax(4, 2) As Double
        CMD.Connection = Conn
        CMD.CommandText = "select taxper,accode,surch from tax where flag='1'"
        DA.SelectCommand = CMD
        DA.Fill(dt)

        For I = 0 To dt.Rows.Count - 1
            rtaxary(I, 0) = dt.Rows(I).Item("taxper")
            rtaxary(I, 2) = dt.Rows(I).Item("accode")
        Next

        CMD.CommandText = "select taxper,accode,surch from tax where flag='2'"
        dt.Rows.Clear()
        dt.Clear()
        DA.SelectCommand = CMD
        DA.Fill(dt)

        For I = 0 To dt.Rows.Count - 1
            rptax(I, 0) = DT.Rows(I).Item("taxper")
            rptax(I, 2) = dt.Rows(I).Item("accode")
        Next

      

        Dim TB, TB1 As New DataTable
        CMD.Connection = Conn
        CMD.CommandText = "select invno,type,invdt,netamt,CUSCODE,addamt,dedamt from invtotal  where (type='21' or type='22') and invdt>=convert(datetime,'" & DateTimePicker1.Value.Date & "') order by invdt,type,invno "
        DA.SelectCommand = CMD
        TB.Clear()
        DA.Fill(tb)

        Dim VALUE As Double
        Dim BDIS As Double
        Dim FND As Long
        Dim TFAMT As Double

        Dim sql As String
        For I = 0 To TB.Rows.Count - 1

            CMD.CommandText = "select *  from InvDetails  where type='" & TB.Rows(I).Item("TYPE") & _
                "' and invdt=convert(datetime,'" & TB.Rows(I).Item("INVDT") & "') AND INVNO=" & TB.Rows(I).Item("INVNO") & "  order by invdt,type,invno "
            DA.SelectCommand = CMD
            TB1.Clear()
            DA.Fill(TB1)

            For v = 0 To 4
                rtaxary(v, 1) = 0
                rptax(v, 1) = 0
            Next v

            TFAMT = 0
            VALUE = 0
            BDIS = 0

            For n = 0 To TB1.Rows.Count - 1
                VALUE = TB1.Rows(n).Item("QTY") * TB1.Rows(n).Item("SRATE")
                BDIS = VALUE * TB1.Rows(n).Item("BDIS") / 100
                VALUE = VALUE - BDIS
                If TB1.Rows(n).Item("ST") <> 0 Then
                    '  VALUE = System.Math.Round(VALUE + (VALUE * Val(TB1.Rows(n).Item("ST")) / 100), 2)

                    FND = 0

                    For v = 0 To 4
                        If Val(TB1.Rows(n).Item("ST")) = rtaxary(v, 0) Then
                            rtaxary(v, 1) = rtaxary(v, 1) + VALUE
                            ' rptax(i, 1) = rptax(i, 1) + stax
                            FND = 1
                            Exit For
                        End If
                    Next v

                    If FND = 0 Then
                        TFAMT = TFAMT + VALUE '+ stax
                    End If
                Else
                    TFAMT = TFAMT + VALUE
                End If
            Next

            Dim RAMT, TX, TADJ As Double
            Dim seq, cd, vouno As Long
            If TB.Rows(I).Item("INVNO") = 51632 Then
                'MsgBox("s.j")
            End If
            TX = 0
            RAMT = 0

            For v = 0 To 4
                RAMT = System.Math.Round(rtaxary(v, 1), 2) '+ Round(rptax(i, 1), 2)
                TX = System.Math.Round(RAMT * rtaxary(v, 0) / (rtaxary(v, 0) + 100), 2)
                RAMT = System.Math.Round(RAMT - TX, 2)
                rtaxary(v, 1) = RAMT 'Round(rtaxary(i, 1), 2)
                rptax(v, 1) = TX ''Round(rptax(i, 1), 2)
            Next

            sql = "update invtotal set TFAmt=" & TFAMT & _
            ",Amt1=" & Val(rtaxary(0, 1)) & ",Tax1=" & Val(rptax(0, 1)) & _
            ",Amt2=" & Val(rtaxary(1, 1)) & ",Tax2=" & Val(rptax(1, 1)) & _
              ",Amt3=" & Val(rtaxary(2, 1)) & ",Tax3=" & Val(rptax(2, 1)) & _
                ",Amt4=" & Val(rtaxary(3, 1)) & ",Tax4=" & Val(rptax(3, 1)) & _
                  ",Amt5=" & Val(rtaxary(4, 1)) & ",Tax5=" & Val(rptax(4, 1)) & " where type='" & TB.Rows(I).Item("TYPE") & _
                "' and invdt=convert(datetime,'" & TB.Rows(I).Item("INVDT") & "') AND INVNO=" & TB.Rows(I).Item("INVNO")
            CMD.CommandText = sql
            CMD.ExecuteNonQuery()

            CMD.CommandText = "delete  from ledger  where invcode='" & _
                     TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "' and trndate=convert(datetime,'" & TB.Rows(I).Item("invdt") & "') and trntype='Sv' and seq<>1  "
            CMD.ExecuteNonQuery()
            CMD.CommandText = "select vouno from ledger  where invcode='" & _
                 TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "' and trndate=convert(datetime,'" & TB.Rows(I).Item("invdt") & "') and trntype='Sv' and seq=1  "

            vouno = CMD.ExecuteScalar
            seq = 1
            For v = 1 To 5
                If rtaxary(v - 1, 1) <> 0 Then
                    'writting taxable
                    seq = seq + 1

                    CMD.CommandText = "Select accode from tax where flag='1' " & _
                        " and  seq=" & v
                    cd = CMD.ExecuteScalar

                    CMD.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                          "AcCode,  Amt,BillType,BillNo,Seq,InvCode) " & _
                          "values('" & TB.Rows(I).Item("invdt") & "','Sv'," & _
                          vouno & "," & cd & "," & _
                          Val(Format((rtaxary(v - 1, 1) * -1), "0.00")) & "," & Microsoft.VisualBasic.Right(TB.Rows(I).Item("type"), 1) & "," & _
                          TB.Rows(I).Item("invno") & "," & seq & ",'" & TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "')"
                    CMD.ExecuteNonQuery()

                    'writing tax
                    seq = seq + 1

                    CMD.CommandText = "Select accode from tax where flag='2' " & _
                        " and  seq=" & v
                    cd = CMD.ExecuteScalar

                    CMD.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                       "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                       "values('" & TB.Rows(I).Item("invdt") & "','Sv'," & _
                       vouno & "," & cd & ", " & _
                       Val(Format((rptax(v - 1, 1) * -1), "0.00")) & "," & Microsoft.VisualBasic.Right(TB.Rows(I).Item("type"), 1) & "," & _
                       TB.Rows(I).Item("invno") & "," & seq & ",'" & TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "')"
                    CMD.ExecuteNonQuery()

                End If
            Next v

            If TFAMT <> 0 Then
                seq = seq + 1
                CMD.CommandText = "Select accode from tax where flag='4' " & _
                        " and  seq=1"
                CD = CMD.ExecuteScalar
                CMD.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                    "values('" & TB.Rows(I).Item("invdt") & "','Sv'," & _
                    vouno & "," & cd & "," & _
                    (TFAMT * -1) & "," & Microsoft.VisualBasic.Right(TB.Rows(I).Item("type"), 1) & "," & _
                    TB.Rows(I).Item("invno") & "," & seq & ",'" & TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "')"

                CMD.ExecuteNonQuery()
            End If
            TADJ = (Val(TB.Rows(I).Item("dedamt")) - Val(TB.Rows(I).Item("addamt")))
            If TADJ <> 0 Then
                seq = seq + 1
                CMD.CommandText = "Select accode from tax where flag='6' " & _
                        " and  seq=1"
                cd = CMD.ExecuteScalar
                CMD.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                    "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                    "values('" & TB.Rows(I).Item("invdt") & "','Sv'," & _
                    vouno & "," & cd & "," & _
                    (TADJ) & "," & Microsoft.VisualBasic.Right(TB.Rows(I).Item("type"), 1) & "," & _
                    TB.Rows(I).Item("invno") & "," & seq & ",'" & TB.Rows(I).Item("type") & TB.Rows(I).Item("invno") & "')"
                CMD.ExecuteNonQuery()

            End If
        Next

        MsgBox("Over ")
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

    End Sub
End Class