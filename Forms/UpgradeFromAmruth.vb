Public Class FromAmruth
    Dim ab2 As New OleDb.OleDbConnection
    Dim acd As New OleDb.OleDbConnection

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        amfld.Text = fd.SelectedPath.ToString

        



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ab2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & amfld.Text & "\Inventory\Ab2.mdb;Jet OLEDB:Database Password=VALOTH;"
        ab2.Open()
        acd.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & amfld.Text & "\accounts\unit1\acdata.mdb;Jet OLEDB:Database Password=VALOTH;"
        acd.Open()
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandTimeout = 0
        If Not IsDate(txtdt.Text) Then
            MsgBox("Invalid Date...")
            Exit Sub
        End If
        Label2.Text = "DELETING..."
        Me.ResumeLayout()
        'cmd.ExecuteNonQuery()
        cmd.CommandText = "delete FROM   Acmaster "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from adjdetails"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from BarCodes"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Batch"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from BatchRtn"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete  from CardDependent"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from cardsales"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Classification"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Company"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from CustGroup"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " delete from carddetails"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from DLNoteAdj"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Generic"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from groups"
        cmd.ExecuteNonQuery()
        cmd.CommandText = " delete from invaccounts"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from  InvDetails "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from invtotal"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from ledger"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from outgo"
        cmd.ExecuteNonQuery()
        cmd.Connection = Conn
        cmd.CommandText = "delete from patient"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from doctor"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from PndOrd"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from PrescriptionEntry"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Product"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Purchase"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from purchasereturn"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from RateChange"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from RateEdit"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from RctSave"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from Salesman  where salcode<>0"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from stockadj"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from SubGroups"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from supcom"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from tax"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from ACMASTER"
        cmd.ExecuteNonQuery()


        Dim dr As OleDb.OleDbDataReader
        Dim dr1 As OleDb.OleDbDataReader
        cmd.Connection = ab2
        cmd1.Connection = Conn
        Label2.Text = "PATIENT..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from patient"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Patient(PatCode,PatName,Adr1,Adr2,Adr3,Place,Ph,Email)values (" & dr("code") & ",""" & dr("name") & _
                    """,'','','','','','')"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "DOCTORS..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from doctorS"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Doctor(DocCode,DocName,Spec,Adr1,Adr2,Adr3,Place,Ph,Email)values (" & dr("code") & ",""" & dr("name") & _
                    """,""" & (dr("Specialisation") & "") & """,""" & (dr("Details") & "") & """,'',''," & _
                    "'','','')"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "CLASSIFICATION..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from classification"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Classification(ClsCode,ClsName)values (" & dr("code") & ",""" & dr("name") & """)"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "GENERIC..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from generic"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Generic(GenCode,GenName)values (" & dr("code") & ",""" & dr("name") & """)"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()

        Label2.Text = "COMPANY..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from company"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Company (comcode,ComName,shortname,rackno,fsupcode) values(" & dr("code") & _
                ",""" & Replace(dr("name"), """", "") & """,""" & dr("sname") & """,""" & dr("rackno") & """,0 )"

            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "PRODUCTS..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from product "
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Product (prdcode,prdname,comcode,clscode,gencode1,gencode2,gencode3," & _
                 "gencode4,gencode5,strng1,strng2,strng3,strng4,strng5,sched,rackno,mfr,rol,roqty,maxqty,case1,case2,case3," & _
                 "unit1,unit2,unit3,cst,st,Srate,Prate,aliascode,invmsg,rectmsg,ordnote,RptCase,prgrp1code,prgrp2code,taxinc ) " & _
                 "values (""" & dr("code") & """,""" & _
                  (Replace(dr("name") & "", """", "")) & """," & Val(dr("cmcode") & "") & "," & Val(dr("clcode") & "") & "," & _
                 Val(dr("Gcode") & "") & ",0,0," & _
                 "0,0,'','','','','',""" & _
                 (dr("sched") & "") & """,""" & (dr("rack") & "") & """,""" & (dr("mfr") & "") & """," & Val(dr("rol") & "") & "," & _
                 Val(dr("roqty") & "") & ",0,""" & dr("case1") & """,""" & (dr("case2") & "") & """,""" & _
                 (dr("case3")) & """,1," & Val(dr("unit2") & "") & "," & Val(dr("unit3") & "") & "," & _
                 "0," & Val(dr("st") & "") & "," & Val(dr("srate") & "") & "," & Val(dr("Brate") & "") & "," & _
                 "'','','',''," & _
                 Val(dr("pricase") & "") & ",0,0,1)"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()


        Dim sqlexdt, sqlbdt, sqlpdt, SQLADJDT, SQLCRDT As String
        Label2.Text = "BATCH..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from batch"
        dr = cmd.ExecuteReader
        While dr.Read
            If Not IsDate(dr("billdt") & "") Then
                sqlbdt = "NULL"
            Else
                sqlbdt = "'" & dr("billdt") & "'"
            End If

            If Not IsDate(dr("pdate") & "") Then
                sqlpdt = "NULL"
            Else
                sqlpdt = "'" & dr("pdate") & "" & "'"
            End If

            If Not IsDate((dr("exdt") & "")) Then
                sqlexdt = "NULL"
            Else
                sqlexdt = "'" & (dr("exdt") & "") & "'"
            End If

            cmd1.CommandText = "insert into Batch(batch,Prate,PCST,Ptax,PDis,SRate,SCST," & _
                "Stax,TaxInc,PrdCode,ExDt,Profit,Pack,Unit,RQty,FQty,RepQty,Stock,BDis,BillNo,BillDt," & _
                "RctNo,Type,SupCode,PDate,Lock,SDis,batchid,seq,flag,BrkQty,SSch,TrRate,psch,wcode) Values(""" & _
              (dr("batch") & "") & """," & Val(dr("Brate") & "") & ",0," & Val(dr("Btax") & "") & _
                "," & Val(dr("pdis") & "") & "," & Val(dr("srate") & "") & ",0," & Val(dr("STAX") & "") & _
                ",1,""" & (dr("code") & "") & """," & sqlexdt & "," & Val(dr("profit") & "") & _
                ",""" & (dr("pack") & "") & """," & Val(dr("unit") & "") & _
                "," & Val(dr("rqty") & "") & _
                "," & Val(dr("fqty") & "") & _
                ",0," & Val(dr("stock") & "") & _
                ",0,""" & (dr("billno") & "") & """," & sqlbdt & _
                "," & Val(dr("rctno") & "") & ",''," & Val(dr("supcode") & "") & _
                "," & sqlpdt & ",0,0," & (dr("batchid") & "") & "," & Val(dr("seq") & "") & ",'" & _
                 "',0,0," & Val(dr("Brate") & "") & ",0,""" & (dr("Connecter") & "") & """)"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        cmd1.CommandText = "UPDATE BATCH SET STAX=5 WHERE STAX=4"
        cmd1.ExecuteNonQuery()
        cmd1.CommandText = "UPDATE PRODUCT SET ST=5 WHERE ST=4"
        cmd1.ExecuteNonQuery()
        cmd1.CommandText = "UPDATE BATCH SET STAX=PTAX WHERE STAX<>0"
        cmd1.ExecuteNonQuery()

        cmd.Connection = acd

        Label2.Text = "GROUPS..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from groups"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into Groups (GrpCode,GrpName,GrpClass,GrpSeq,grpFixed) values(" & dr("grpcode") & ",""" & dr("grpname") & _
            """," & dr("GRPClass") & ",0,'false')"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "SUBGROUPS..."
        Me.ResumeLayout()
        cmd.CommandText = "select * from groups"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "Insert into SUBGroups (SgCode,GrpCode,SgName,GrpClass,SgSeq ) values(" & dr("grpcode") & "," & dr("grpcode") & ",""" & dr("grpname") & _
            """," & dr("GRPClass") & ",0 )"
            cmd1.ExecuteNonQuery()
        End While
        dr.Close()
        Label2.Text = "ACMASTER..."
        Me.ResumeLayout()
        cmd.Connection = acd
        cmd.CommandText = "select * from ACMASTER"
        dr = cmd.ExecuteReader
        While dr.Read
            cmd1.CommandText = "INSERT INTO Acmaster (AcCode,AcSeq,AcName,AcClass,GrpCode,SgCode,Adr1,Adr2,Adr3,Place,Pin" & _
            ",ST,CST,Ph,Email,Person,CrLmt,Crday,Bwise,CrDOnLr,AreaCode,RepCode,BnkName,BnkBranch,AliasCode,OurBnk,OutSt" & _
            ",Fax,CrPlus,inival,dep,BnkArea,DLNO1,DLNO2,DLNO3,DLNO4,Website,TownCode,VisitRep,VisitDay,InvLmt,Mob,pan) " & _
            "VALUES (" & dr("AcCode") & "," & dr("Acseq") & ",""" & Replace((dr("Acname") & ""), """", "") & """," & dr("AcClass") & _
            "," & Val(dr("grpcode") & "") & "," & Val(dr("grpcode") & "") & ",""" & Replace(dr("Adr1") & "", """", "") & """,""" & Replace((dr("Adr2") & ""), """", "") & """,""" & _
          (dr("Adr2") & "") & """,""" & Replace((dr("place") & ""), """", "") & """,""" & dr("pin") & """, " & _
           "'','','" & dr("ph") & "', '', '', 0," & VAL(dr("crday") & "") & ",'" & dr("bwise") & "',0, 0,0,'','', " & _
           "'',0,0,'',0,0,0,0,'','','','','',0," & _
           "'','',0,'','')"
            cmd1.ExecuteNonQuery()
            ' dr.Close()

            'cmd.Connection = ab2
        End While
        dr.Close()
        Label2.Text = "SUPCOM..."
        Me.ResumeLayout()
        cmd.Connection = ab2
        cmd2.Connection = ab2
        cmd.CommandText = "select * from supplier"
        dr = cmd.ExecuteReader
        While dr.Read
            'cmd2.CommandText = "select code from company where instr('" & dr("com") & "', ';' & company.code & ';')<>0 "
            'dr1 = cmd2.ExecuteReader
            cmd2.CommandText = "select code from company where instr('" & dr("com") & "', ';' & company.code & ';')<>0 "
            dr1 = cmd2.ExecuteReader
            While dr1.Read
                cmd1.CommandText = " INSERT INTO Supcom (SupCode,ComCode) " & _
                      "VALUES (" & dr("code") & "," & dr1("code") & ")"
                cmd1.ExecuteNonQuery()
            End While
            dr1.Close()
        End While
        dr.Close()


        cmd1.Connection = Conn
        cmd.Connection = ab2
        cmd2.Connection = acd
        Label2.Text = "LEDGER..."
        Me.ResumeLayout()
        Dim pamt As Double
        cmd.Connection = acd
        cmd.CommandText = "select * from ledger"
        dr = cmd.ExecuteReader
        While dr.Read

            If Not IsDate(dr("billdt") & "") Then
                sqlbdt = "NULL"
            Else
                sqlbdt = "'" & dr("billdt") & "'"
            End If

            If Not IsDate(dr("duedt") & "") Then
                sqlpdt = "NULL"
            Else
                sqlpdt = "'" & dr("duedt") & "" & "'"
            End If
            pamt = 0
            If dr("trntype") = "Sa" Or dr("trntype") = "Sr" Or dr("trntype") = "Pu" Or dr("trntype") = "Pr" And dr("seq") = 1 Then
                cmd2.CommandText = "select sum(amt) from adjdetails where billtrntype='" & dr("trntype") & "'  and billvouno=" & dr("vouno") & _
                    " AND ACCODE=" & dr("ACCODE")
                pamt = Val(cmd2.ExecuteScalar & "")
            ElseIf dr("trntype") = "Ju" Or dr("trntype") = "OP" Then
                cmd2.CommandText = "select sum(amt) from adjdetails where billtrntype='" & dr("trntype") & "'  and billvouno=" & dr("vouno") & _
                   " AND ACCODE=" & dr("ACCODE")
                pamt = Val(cmd2.ExecuteScalar & "")
            End If
            cmd1.CommandText = "insert into Ledger (TrnDate,vouno,trntype,AcCode,Amt,seq,BillNo,Billdt,BillType,OthNo,othdt,RepCode," & _
                "BranchVno,DueDt,invcode,pamt,Narration,OutSt,TransCh,BnkName,Branch) values ('" & dr("trndate") & "'," & dr("vouno") & _
                ",'" & dr("trntype") & "'," & dr("accode") & "," & (Math.Round(Val(dr("amt").ToString.Replace("E", "")), 2) * IIf(dr("DrCr") = 2, -1, 1)) & _
                "," & dr("seq") & ",'" & dr("billno") & "'," & sqlbdt & "," & dr("billtype") & ",'',null,0,0," & _
                sqlpdt & ",'" & dr("invcode") & "'," & pamt & ",""" & Replace(dr("Narration") & "", """", "") & """,0,'','','')"
            cmd1.ExecuteNonQuery()

        End While
        dr.Close()
        Label2.Text = "UPDATE SV..."
        Me.ResumeLayout()
        cmd1.CommandText = "update ledger set trntype='Sv' where trntype='Sa' "
        cmd1.ExecuteNonQuery()
        Label2.Text = "UPDATE JV..."
        Me.ResumeLayout()
        cmd1.CommandText = "update ledger set trntype='Jv' where trntype='Ju' "
        cmd1.ExecuteNonQuery()
        Label2.Text = "UPDATE OP..."
        Me.ResumeLayout()
        cmd1.CommandText = "update ledger set trntype='PB' where trntype='OP' "
        cmd1.ExecuteNonQuery()

        Label2.Text = "UPDATE BALANCE..."
        Me.ResumeLayout()

        cmd1.Connection = Conn
        cmd.Connection = acd
        cmd.CommandText = "select * from ACMASTER WHERE OPBAL<>0"
        dr = cmd.ExecuteReader
        While dr.Read
            txtdt.Text = "01/04/2012" 'Format(txtdt.Text, "dd/mm/yyyy")

            cmd1.CommandText = "insert into Ledger (TrnDate,vouno,trntype,AcCode,Amt,seq,BillNo,BillType,OthNo, RepCode," & _
                 "BranchVno,invcode,pamt,Narration,OutSt,TransCh,BnkName,Branch) values (CONVERT(datetime,'" & txtdt.Text & "',103),0" & _
                ",'OP'," & dr("accode") & "," & (dr("opbal") * IIf(dr("DrCr") = 2, -1, 1)) & _
                ",1,'NULL',2,'',0,0," & _
                "'',0,'',0,'','','')"
            cmd1.ExecuteNonQuery()

            'cmd1.CommandText = "insert into Ledger (TrnDate,vouno,trntype,AcCode,Amt,seq,BillNo,Billdt,BillType,OthNo,othdt,RepCode," & _
            '      "BranchVno,DueDt,invcode,pamt,Narration,OutSt,TransCh,BnkName,Branch) values ('" & txtdt.Text & "',0" & _
            '      ",'OP'," & dr("accode") & "," & (dr("opbal") * IIf(dr("DrCr") = 2, -1, 1)) & _
            '      ",1,'',NULL,2,'',NULL,0,''," & _
            '      "NULL,'',0,'',0,'','','')"
            'cmd1.ExecuteNonQuery()
        End While
        dr.Close()

        cmd.Connection = ab2

        cmd1.Connection = Conn
        Label2.Text = "PURCHASE RETURN..."
        Me.ResumeLayout()
        cmd1.CommandText = "DELETE  from purchasereturn "
        cmd1.ExecuteNonQuery()

        cmd.CommandText = "select * from purchasereturn "
        dr = cmd.ExecuteReader

        While dr.Read

            If Not IsDate(dr("billdt") & "") Then
                sqlbdt = "NULL"
            Else
                sqlbdt = "'" & dr("billdt") & "'"
            End If

            If Not IsDate(dr("EXDT") & "") Then
                sqlexdt = "NULL"
            Else
                sqlexdt = "'" & dr("EXDT") & "" & "'"
            End If

            If Not IsDate(dr("adjbilldt") & "") Then
                SQLADJDT = "NULL"
            Else
                SQLADJDT = "'" & dr("adjbilldt") & "" & "'"
            End If

            If Not IsDate(dr("crnotedt")) Then
                SQLCRDT = "NULL"
            Else
                SQLCRDT = "'" & dr("crnotedt") & "" & "'"
            End If

            cmd1.CommandText = "INSERT INTO  PurchaseReturn ([prno],[prdt] ,[supcode],[code],[batch],[exdt],[exqty],[brqty],[unit] " & _
                 ",[pack],[rate],[billno] ,[billdt] ,[remark],[settled],[batchid],[crnoteno],[crnotedt],[adjamt],[adjbillno],[adjbilldt] " & _
                 ",[prevmonth],[srate],[fqty] ) vALUES (" & dr("prno") & ",'" & dr("prdt") & "'," & dr("supcode") & ",""" & _
                 dr("code") & """,""" & dr("batch") & """," & sqlexdt & "," & dr("exqty") & "," & dr("brqty") & "," & dr("unit") & ",""" & _
                 dr("pack") & """," & dr("rate") & ",""" & dr("billno") & """," & sqlbdt & ",""" & Replace(dr("remarkS") & "", """", "") & """,'" & dr("settled") & "'," & _
                 dr("batchid") & ",""" & dr("crnoteno") & """," & SQLCRDT & "," & dr("adjamt") & ",""" & dr("adjbillno") & """," & _
                SQLADJDT & ",'" & dr("prevmonth") & "'," & dr("srate") & ",0)"

            cmd1.ExecuteNonQuery()

        End While


        dr.Close()



    End Sub

    Private Sub FromAmruth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class