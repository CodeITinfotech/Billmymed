Imports System.Windows.Forms
Imports System.Math

Public Class OTCConv
    Private Trans As OleDb.OleDbTransaction
    Private netamt, totdis, tfamt, tmpamt, tmpdis, tmpstax As Double
    Private taxary(5, 3) As Double
    Private addamt As Double
    Private lesamt As Double

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim tcmd As New OleDb.OleDbCommand
        Dim t1cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim tconn As New OleDb.OleDbConnection


        tconn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=" & DbName & ";Data Source=" & Sqlsvrname & ""

        ' tconn.ConnectionString = "PROVIDER=SQLOLEDB;PERSIST SECURITY INFO=FALSE;INTEGRATED SECURITY=SSPI;DATABASE=" & DbName & ";SERVER=" & Sqlsvrname & ";CONNECT TIMEOUT=30;"
        tconn.Open()
        tcmd.Connection = tconn

        t1cmd.Connection = tconn
        Dim invdr As OleDb.OleDbDataReader


        Dim i As Integer
        Dim tmpcode As String
        Dim tmpbatch As String
        Dim tmpunit As String
        Dim tmpsrate, sqlexdt, tmpdocnm, tmppatnm As String
        Dim findtax As Integer
        Dim docmax As Integer
        Dim patmax As Integer
        Dim tmp As Integer

        Dim Rndpai As Double
        Dim RndBill As Double
        Dim sacacode As Long
        Dim tmprnd As Double

        Dim Trn As Boolean
        Dim num As Long
        Dim PLINE As Integer
        Try

            cmd.Connection = Conn
            cmd1.Connection = Conn

            cmd1.CommandText = "select * from invdetails  where type='23' and cancelled=0  ORDER BY prdcode,batch,Srate,unit"
            invdr = cmd1.ExecuteReader
            If Not invdr.HasRows Then
                MsgBox("Zero records found.", MsgBoxStyle.Information)

                invdr.Close()
                Exit Sub
            End If
            invdr.Close()

            tcmd.CommandText = "select taxper,accode,surch from tax where flag='1'"

            invdr = tcmd.ExecuteReader()
            If invdr.HasRows Then
                i = 0
                While invdr.Read()
                    taxary(i, 0) = invdr.Item("taxper")
                    taxary(i, 2) = invdr.Item("accode")
                    i = i + 1
                End While
            End If
            invdr.Close()

            tcmd.CommandText = "select RndPaise,Rndbill,sacacode,InvPrePrint,PrintLine,PrePrintLine from settings"
            invdr = tcmd.ExecuteReader

            If invdr.HasRows Then
                While invdr.Read()
                    Rndpai = invdr.Item("RndPaise")
                    RndBill = invdr.Item("RndBill")
                    sacacode = invdr.Item("sacacode")

                    If invdr.Item("InvPrePrint") Then
                        PLINE = invdr.Item("PrePrintLine")
                    Else
                        PLINE = invdr.Item("PrintLine")
                    End If
                End While
            End If
            invdr.Close()



            Trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            cmd.Transaction = Trans
            cmd1.Transaction = Trans
            Trn = True




            cmd.CommandText = "update serialnum set slno=slno+1 where type=21"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select slno from serialnum where type=21"
            num = cmd.ExecuteScalar

            tcmd.CommandText = "select max(doccode) from doctor"
            docmax = Val(tcmd.ExecuteScalar & "")

            tcmd.CommandText = "select max(patcode) from patient"
            patmax = Val(tcmd.ExecuteScalar & "")

            tcmd.CommandText = "select * from invdetails  where type='23' and cancelled=0  ORDER BY prdcode,batch,Srate,unit"
            invdr = tcmd.ExecuteReader
            If Not invdr.HasRows Then
                Exit Sub
            Else
                invdr.Read()
            End If

            Dim rend As Boolean = True

            While rend


                netamt = 0


                netamt = 0
                totdis = 0

                totdis = 0
                tfamt = 0
                For i = 0 To 4
                    taxary(i, 1) = 0
                    taxary(i, 2) = 0
                Next i
                addamt = 0
                lesamt = 0
                i = 0

                pbar.Maximum = PLINE
                pbar.Value = 0

                Do While i < PLINE
                    pbar.Value = i

                    tmpcode = invdr("prdcode")        'for grouping
                    tmpbatch = invdr("batch")          ' for grouping
                    tmpsrate = invdr("srate")        ' for grouping
                    tmpunit = invdr("unit")          'for grouping


                    tmpdis = 0
                    tmpamt = Round(invdr("srate") * invdr("qty"), 2)
                    If invdr("taxinc") Then
                        If invdr("st") <> 0 Then
                            tmpstax = Round((tmpamt * invdr("st")) / (invdr("st") + 100), 2)
                            'tmpamt = tmpamt - tmpstax
                        Else
                            tfamt = tfamt + tmpamt
                        End If
                    Else
                        If invdr("st") <> 0 Then
                            tmpstax = Round(tmpamt * invdr("st") / 100, 2)
                            tmpamt = tmpamt + tmpstax

                        Else
                            tfamt = tfamt + tmpamt
                        End If
                    End If

                    If invdr("st") <> 0 Then
                        findtax = 0
                        For n = 0 To 4
                            If taxary(n, 0) = invdr("st") Then
                                taxary(n, 1) = taxary(n, 1) + (tmpamt - tmpstax)
                                taxary(n, 2) = taxary(n, 2) + tmpstax
                                findtax = 1
                                Exit For
                            End If
                        Next n
                        If findtax = 0 Then
                            tfamt = tfamt + tmpamt ' tmpstax
                        End If
                    End If
                    netamt = netamt + tmpamt


                    If Not IsDate(invdr("exdt")) Then
                        sqlexdt = "NULL"
                    Else
                        sqlexdt = "'" & invdr("exdt") & "'"
                    End If

                    cmd.CommandText = "insert into invdetails(Invno,Invdt,Type,PrdCode,Batch,Batchid,ExDt,Pack,Qty," & _
                       "Srate,ST,cst,Unit,SValue,Seq,Sman,Bdis,Priflag," & _
                       "TaxInc,cancelled,edited) values(" & num & ",'" & SysDt & "',21" & _
                       ",""" & invdr("prdcode") & """,""" & invdr("batch") & _
                       """," & invdr("batchid") & "," & sqlexdt & _
                       ",""" & invdr("pack") & """," & invdr("qty") & _
                       "," & invdr("srate") & ",""" & invdr("st") & _
                       """," & invdr("cst") & "," & invdr("unit") & "," & tmpamt & _
                       "," & i & ",0" & _
                       ",0,0," & IIf(invdr("taxinc"), "1", "0") & ",0,0)"
                    cmd.ExecuteNonQuery()

                    If Not invdr.Read Then
                        rend = False
                        Exit Do
                    End If


                    If invdr("prdcode") <> tmpcode Or tmpbatch <> invdr("batch") Or Val(tmpsrate) <> invdr("srate") Or tmpunit <> invdr("unit") Then i = i + 1 'for  grouping
                Loop


                Randomize()
                Do While True
                    tmp = Int((docmax * Rnd()) + 1) ' for doctor record
                    If Microsoft.VisualBasic.IsDBNull(tmp) Then tmpdocnm = "" : Exit Do
                    t1cmd.CommandText = "select docname from doctor where doccode=" & tmp
                    tmpdocnm = t1cmd.ExecuteScalar
                    If tmpdocnm <> "" Then Exit Do
                Loop


                Do While True
                    tmp = Int((patmax * Rnd()) + 1) ' for doctor record
                    If Microsoft.VisualBasic.IsDBNull(tmp) Then tmppatnm = "" : Exit Do
                    t1cmd.CommandText = "select patname from patient where patcode=" & tmp
                    tmppatnm = t1cmd.ExecuteScalar
                    If tmppatnm <> "" Then Exit Do
                Loop

                addamt = 0
                lesamt = 0

                If RndBill Then
                    tmprnd = RoundPaise(netamt, Rndpai)
                    If Val(netamt) - Val(tmprnd) < 0 Then
                        addamt = Format(Abs(Val(tmprnd) - Val(netamt)), "0.00")
                    ElseIf Val(netamt) - Val(tmprnd) > 0 Then
                        lesamt = Format(Abs(Val(tmprnd) - Val(netamt)), "0.00")
                    End If
                End If
                netamt = Format(netamt + addamt - lesamt, "0.00")

                cmd.CommandText = "insert into invtotal (Invno,Invdt,type,CusCode,Name," & _
                   "BDis,BDisAmt,TFAmt,Amt1," & _
                   "Tax1,Amt2,Tax2,Amt3,Tax3,Amt4,Tax4,Amt5, Tax5,NetAmt,AddAmt," & _
                   "Flag,DedAmt,DocName,Cardno,UsrName," & _
                   "node,Cashamt,cancelled,edited,sman) Values(" & num & _
                   ",'" & SysDt & "',21,0,""" & tmppatnm & _
                   """,0" & _
                   ",0," & tfamt & "," & Val(taxary(0, 1)) & "," & Val(taxary(0, 2)) & _
                   "," & Val(taxary(1, 1)) & "," & Val(taxary(1, 2)) & "," & Val(taxary(2, 1)) & "," & Val(taxary(2, 2)) & _
                   "," & Val(taxary(3, 1)) & "," & Val(taxary(3, 2)) & "," & Val(taxary(4, 1)) & "," & Val(taxary(4, 2)) & _
                   "," & netamt & "," & addamt & _
                   ",''," & lesamt & ",""" & _
                   tmpdocnm & """,'',""" & UsrName & """,""" & _
                   NodeName & """," & netamt & ",0,0,0)"

                cmd.ExecuteNonQuery()
                WriteAcc("21", num, SysDt)

                tmpdocnm = ""
                tmppatnm = ""
                lbl.Text = lbl.Tag & ".. " & num
                pbar.Value = pbar.Maximum
                If rend Then num = num + 1
            End While
            invdr.Close()
            cmd.CommandText = "delete from invdetails where type='23'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "delete from invtotal where type='23'"
            cmd.ExecuteNonQuery()



            cmd.CommandText = "update serialnum set slno=" & num & " where type=21"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update serialnum set slno=0 where type=23"
            cmd.ExecuteNonQuery()

            Trans.Commit()
            Trn = False

        Catch er As Exception
            If Trn Then Trans.Rollback()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        tconn.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OTCConv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldt.Text = SysDt

        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandText = "select slno from serialnum where type=21"
        lbl.Text = cmd.ExecuteScalar() + 1
        lbl.Tag = lbl.Text
    End Sub

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

        cmd.CommandText = "update serialnum  set slno=slno+1 where type=93"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "select slno from serialnum where type=93"
        vouno = cmd.ExecuteScalar
        'InvDt = upddt

        cmd.CommandText = "select sacacode from settings "
        cashcode = cmd.ExecuteScalar

        cmd.CommandText = "select sacoincode from settings "
        coincode = cmd.ExecuteScalar

       
        BillType = 1
        pcode = cashcode
        

        cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                "Amt,BillType,BillNo,Seq,InvCode) values('" & _
                upddt & "','Sv'," & vouno & "," & _
                pcode & ", " & netamt & "," & BillType & "," & _
                updno & "," & _
                "1,'" & updtype & updno & "')"
        cmd.ExecuteNonQuery()
        seq = 1

        For i = 1 To 5

            If taxary(i - 1, 1) <> 0 Then
                'writting taxable
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='1' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                      "AcCode,  Amt,BillType,BillNo,Seq,InvCode) " & _
                      "values('" & upddt & "','Sv'," & _
                      vouno & "," & CD & "," & _
                      Val(Format((taxary(i - 1, 1) * -1), "0.00")) & "," & BillType & "," & _
                      updno & "," & seq & ",'" & updtype & updno & "')"
                cmd.ExecuteNonQuery()
                'writing tax
                seq = seq + 1

                cmd.CommandText = "Select accode from tax where flag='2' " & _
                    " and  seq=" & i
                CD = cmd.ExecuteScalar
                cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                   "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                   "values('" & upddt & "','Sv'," & _
                   vouno & "," & CD & ", " & _
                   Val(Format((taxary(i - 1, 2) * -1), "0.00")) & "," & BillType & "," & _
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
                "values('" & upddt & "','Sv'," & _
                vouno & "," & CD & "," & _
                (tfamt * -1) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()
        End If

        TADJ = (Val(lesamt) - Val(addamt))

        If TADJ <> 0 Then
            seq = seq + 1
            cmd.CommandText = "Select accode from tax where flag='6' " & _
                    " and  seq=1"
            CD = cmd.ExecuteScalar
            cmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo," & _
                "AcCode,Amt,BillType,BillNo,Seq,invcode) " & _
                "values('" & upddt & "','Sv'," & _
                vouno & "," & CD & "," & _
                (TADJ) & "," & BillType & "," & _
                updno & "," & seq & ",'" & updtype & updno & "')"
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
