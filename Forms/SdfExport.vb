Imports System.Windows.Forms

Public Class SdfExport

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Dim cmd As New OleDb.OleDbCommand
        'Dim rd As OleDb.OleDbDataReader
        'Dim Bno As String
        'Dim dt As String
        'Dim cuscod As String
        'Dim cusnam As String
        'Dim tot As String
        'Dim txbl1 As String
        'Dim tax1 As String
        'Dim txbl2 As String
        'Dim tax2 As String
        'Dim txbl3 As String
        'Dim tax3 As String
        'Dim txf As String
        'Dim txp As String
        'Dim bc As String
        'Dim tp As String

        'Dim DRCR As String

        'Dim coin As String
        'Dim surch As String
        'Dim othno As String
        'Dim bnknm As String
        'Dim bnkcd As String
        'Dim billno As String
        'Dim type1 As String


        'Dim oFile As System.IO.File
        'Dim oWrite As System.IO.StreamWriter
        'oWrite = IO.File.CreateText("C:\AmruthSD.txt")


        'cmd.Connection = Conn
        'cmd.CommandText = "select * from invtotal where (type='22' or type='21' or type='26')   and cancelled=0 and invdt>=convert(datetime,'" & dtf.Value.Date & "') and invdt<=convert(datetime,'" & dtt.Value.Date & "')"

        'rd = cmd.ExecuteReader


        'While rd.Read
        '    dt = Format(rd("Invdt"), "dd/MM/yyyy")
        '    cuscod = rd("CusCode")
        '    type1 = "" 'rsinv!Type
        '    cusnam = rd("Name") & ""
        '    Bno = rd("invNo")
        '    tp = "Sa"
        '    txbl1 = Format(rd("amt1"), "0.00")
        '    tax1 = Format(rd("tax1"), "0.00")

        '    txbl2 = Format(rd("amt2"), "0.00")
        '    tax2 = Format(rd("tax2"), "0.00")

        '    txbl3 = Format(rd("amt3"), "0.00")
        '    tax3 = Format(rd("tax3"), "0.00")

        '    txf = Format(rd("tfamt"), "0.00")
        '    txp = Format(rd("tpamt"), "0.00")
        '    surch = Format(rd("surchamt"), "0.00")
        '    bc = Format(rd("addamt"), "0.00")
        '    coin = Format(rd("coinadj"), "0.00")
        '    tot = Format(rd("netamt"), "0.00")

        '    'Dim Bno As String * 11
        '    'Dim dt As String * 10
        '    'Dim cuscod As String * 10
        '    'Dim cusnam As String * 30
        '    'Dim tot As String * 12
        '    'Dim txbl1 As String * 12
        '    'Dim tax1 As String * 12
        '    'Dim txbl2 As String * 12
        '    'Dim tax2 As String * 12
        '    'Dim txbl3 As String * 12
        '    'Dim tax3 As String * 12
        '    'Dim txf As String * 12
        '    'Dim txp As String * 12
        '    'Dim bc As String * 12

        '    'Dim DRCR As String * 5

        '    'Dim coin As String * 12
        '    'Dim surch As String * 12
        '    'Dim othno As String * 12
        '    'Dim bnknm As String * 30
        '    'Dim bnkcd As String * 10
        '    'Dim billno As String * 12
        '    'Dim type1 As String * 3
        '    'Dim TP As String * 3
        '    oWrite.WriteLine("{0,11}{1,3}{2,10}{3,10}{4,30}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}{13,12}{14,12}{15,12}", Bno, tp, dt, cuscod, cusnam, txbl1, tax1, txbl2, tax2, txbl3, tax3, txp, txf, surch, coin, tot)
        'End While
        'rd.Close()



        'cmd.Connection = Conn
        'cmd.CommandText = "select PURCHASE.*,ACMASTER.ACNAME  from PURCHASE,ACMASTER  where ACMASTER.ACCODE=PURCHASE.SUPCODE AND  (type='11' or type='12' )   and pdate>=convert(datetime,'" & dtf.Value.Date & "') and pdate<=convert(datetime,'" & dtt.Value.Date & "')"

        'rd = cmd.ExecuteReader


        'While rd.Read
        '    dt = Format(rd("pdate"), "dd/MM/yyyy")
        '    cuscod = rd("supcode")
        '    type1 = "" 'rsinv!Type
        '    cusnam = rd("acName") & ""
        '    Bno = rd("billno")
        '    tp = "Pu"
        '    txbl1 = Format(rd("pamt1"), "0.00")
        '    tax1 = Format(rd("ptx1"), "0.00")

        '    txbl2 = Format(rd("pamt2"), "0.00")
        '    tax2 = Format(rd("ptx2"), "0.00")

        '    txbl3 = Format(rd("pamt3"), "0.00")
        '    tax3 = Format(rd("ptx3"), "0.00")

        '    txf = Format(rd("ptfamt"), "0.00")
        '    txp = "0" 'Format(rd("ptpamt"), "0.00")
        '    surch = "0" 'Format(rd("surchamt"), "0.00")
        '    bc = 0 'Format(rd("addamt"), "0.00")
        '    coin = Format(rd("padj"), "0.00")
        '    tot = Format(rd("rctamt"), "0.00")

        '    'Dim Bno As String * 11
        '    'Dim dt As String * 10
        '    'Dim cuscod As String * 10
        '    'Dim cusnam As String * 30
        '    'Dim tot As String * 12
        '    'Dim txbl1 As String * 12
        '    'Dim tax1 As String * 12
        '    'Dim txbl2 As String * 12
        '    'Dim tax2 As String * 12
        '    'Dim txbl3 As String * 12
        '    'Dim tax3 As String * 12
        '    'Dim txf As String * 12
        '    'Dim txp As String * 12
        '    'Dim bc As String * 12

        '    'Dim DRCR As String * 5

        '    'Dim coin As String * 12
        '    'Dim surch As String * 12
        '    'Dim othno As String * 12
        '    'Dim bnknm As String * 30
        '    'Dim bnkcd As String * 10
        '    'Dim billno As String * 12
        '    'Dim type1 As String * 3
        '    'Dim TP As String * 3

        '    oWrite.WriteLine("{0,11}{1,3}{2,10}{3,10}{4,30}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}{13,12}{14,12}{15,12}", Bno, tp, dt, cuscod, cusnam, txbl1, tax1, txbl2, tax2, txbl3, tax3, txp, txf, surch, coin, tot)


        'End While

        'oWrite.Close()



        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()

        Dim cmd As New OleDb.OleDbCommand
        Dim rd As OleDb.OleDbDataReader
        Dim trndt As String
        Dim trntype As String
        Dim vno As String
        Dim acname As String
        Dim accode As String
        Dim amt As String
        Dim bno As String
        Dim bdt As String
        Dim othrno As String
        Dim othrdt As String

        'Dim oFile As System.IO.File
        Dim oWrite As System.IO.StreamWriter
        oWrite = IO.File.CreateText("App.path\..\..\AmruthSD.csv")

        cmd.Connection = Conn
        cmd.CommandText = "SELECT Acmaster.AcCode as accode, Ledger.TrnDate as tdate, Ledger.TrnType as ttype, Ledger.VouNo as vno, Acmaster.AcName as acname, Ledger.Amt as amnt, Ledger.OthDt as otherdate, Ledger.Billdt as bildt, Ledger.OthNo as otherno, Ledger.BillNo as bilno" & _
                        " FROM Acmaster INNER JOIN Ledger ON Acmaster.AcCode = Ledger.AcCode WHERE (Ledger.TrnType<>'OP' AND Ledger.TrnType<>'PL' AND Ledger.TrnType<>'PB' AND Ledger.TrnDate>=convert(datetime,'" & dtf.Value.Date & "') AND Ledger.TrnDate<=convert(datetime,'" & dtt.Value.Date & "')) ORDER BY ledger.trndate ASC"
        rd = cmd.ExecuteReader

        oWrite.WriteLine("Transaction Date, Tranaction Type, Voucher Number, AC Code, AC Name, Amount, Bill No, Bill Date, Cheque Number, Cheque Date")
        While rd.Read
            trndt = rd("tdate")
            trntype = rd("ttype")
            vno = rd("vno")
            accode = rd("accode")
            acname = rd("acname")
            amt = Format(rd("amnt"), "0.00")
            bno = rd("bilno") & ""
            If IsDBNull(rd("bildt")) = False Then
                bdt = rd("bildt")
            Else
                bdt = ""
            End If

            othrno = rd("otherno") & ""
            othrdt = rd("otherdate") & ""

            oWrite.WriteLine(trndt & "," & trntype & "," & vno & "," & accode & "," & acname & "," & amt & "," & bno & "," & bdt & "," & othrno & "," & othrdt)

        End While
        rd.Close()
        oWrite.Close()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        MsgBox("AmruthSD.csv file Created in 'Reliable Software' Folder")
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SdfExport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
