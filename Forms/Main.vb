Imports System.Timers
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class Main
    Inherits System.Windows.Forms.Form
    Dim menues As New List(Of ToolStripItem)
    Dim ReportList As New List(Of String)
    Private myTimer As New System.Timers.Timer(60000)
    Private TIMERON As Boolean = False
    Private TIMERON1 As Boolean = False
    Private Timer1 As New System.Timers.Timer()
    Private ExpiryList As String
    'Public time As String = DateTime.Now.ToLongTimeString()
    Public TU As Integer = 0
 
    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Want to exit from " & Application.ProductName & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        Do While TIMERON
            myTimer.Enabled = False
        Loop
        myTimer.Stop()

        Do While TIMERON1
            Timer1.Enabled = False
        Loop
        Timer1.Stop()
        Conn.Close()
        End
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lblCap.Text = ""
        'Dim renderer As New clsToolstripRenderer

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        'Dim conn As New OleDb.OleDbConnection
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        Dim renderer As New clsColorToolstripRenderer


        renderer.BackColor = Color.Wheat

        MenuStrip1.Renderer = New clsMenuRenderer

        Ts.Renderer = New clsToolstripRenderer
        ' MenuStrip1.Renderer = renderer
        'StatusStrip1.Renderer = renderer
        Timestrip.Renderer = renderer
        bttnnode.Text = nodeName
        Btnnow.Text = Now()
        btnusr.Text = UsrName
        lblDatabase.Text = "Database : " & DbName
        lblserver.Text = "SQL Server : " & Sqlsvrname


        'Dim cmd2 As New OleDb.OleDbCommand
        'cmd2.Connection = Conn
        'cmd2.CommandType = CommandType.Text
        'cmd2.CommandText = "SELECT Product.PrdName, Product.case1, Batch.Batch, Batch.ExDt, Batch.Stock, Acmaster.AcName AS sup " & _
        '                ", Acmaster.Place FROM Product INNER JOIN Batch ON Product.PrdCode = Batch.PrdCode INNER JOIN  Acmaster " & _
        '                "ON Batch.Supcode = Acmaster.AcCode WHERE " & _
        '                "Batch.ExDt <= CONVERT(DATETIME,'" & DateAdd(DateInterval.Day, ShortExpDays, Now.Date) & "') and stock<>0 "

        'Dim dataredr As OleDb.OleDbDataReader = cmd2.ExecuteReader()
        'cmd2.Parameters.Clear()
        'Label2.Text = ""
        'If dataredr.HasRows Then
        '    Label2.Text = "Short Expiry List - "
        '    While dataredr.Read()
        '        Label2.Text = Label2.Text + "  --  " + dataredr("PrdName") & "  " & dataredr("batch") & "  " & dataredr("exdt") & " " & dataredr("Stock") & " " & dataredr("case1") & " " & dataredr("sup")
        '    End While
        '    'Label2.Text = ""

        'End If
        'time = 0

        ' OnTimedEvent()
        Label2.Text = ""
      

        cmd.Connection = Conn
        cmd.CommandText = "Select * from Settings"
        da.SelectCommand = cmd
        da.Fill(ds, "Setting")
        dt = ds.Tables("Setting")
        AddHandler Timer1.Elapsed, AddressOf Timer1_Tick1
       

        If dt.Rows(0).Item("MailServer") & "" <> "" Or dt.Rows(0).Item("MobUserName") & "" <> "" Then
            If UCase(My.Computer.Name) = UCase(dt.Rows(0).Item("MailServer")) Then
                myTimer.Enabled = True
                AddHandler myTimer.Elapsed, AddressOf tm_Tick
            Else
                myTimer.Enabled = False
            End If
        End If



        Dim ctlq As Control

        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctlq In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.try
                Try
                    ' ctlMDI = CType(ctlq, MdiClient)
                    'ctlMDI.BackColor = Me.BackColor

                Catch ex As Exception

                End Try


                ' Set the BackColor of the MdiClient control.

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        If CheckUserLocked("User Rights", True) = False Then Mnucruser.Visible = False : Mnuright.Visible = False
        If CheckUserLocked("Quick View", True) = False Then ReportMenuSeparator2.Visible = False : mnuqv.Visible = False
        If CheckUserLocked("Graph View", True) = False Then MnuGraph.Visible = False : ReportMenuSeparator1.Visible = False
        If CheckUserLocked("Reports", True) = False Then mnuReports.Visible = False : ReportMenuSeparator1.Visible = False
        If CheckUserLocked("Reports(Main)", True) = False Then MnuReportsMain.Visible = False
        If CheckUserLocked("Options", True) = False Then mnuopt.Visible = False : SystemMenuSeparator4.Visible = False
        If CheckUserLocked("Date Change", True) = False Then MnuDtChange.Visible = False : SystemMenuSeparator2.Visible = False
        If CheckUserLocked("Restore Database", True) = False Then SystemMenuSeparator6.Visible = False : mnuresotre.Visible = False
        ' Display a child form to show this is still an MDI application.
        Me.Text = Application.ProductName & System.String.Format("  Version {0}.{1}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor) & " - " & DeScriptRS(Firm.Name)

        Dim VST As String
        menues.Clear()
        For Each t As ToolStripItem In MenuStrip1.Items
            GetMenues(t, menues)
        Next

        For i = 0 To menues.Count - 1
            If menues(i).Text = "" Then
                VST = (menues(i).Name)
            Else
                VST = (menues(i).Text)
            End If
            menues(i).Visible = (CheckUserLocked(VST, True))
        Next

        Me.Show()
        bw.RunWorkerAsync()
        Timer1.Interval = 305
        Timer1.Enabled = True
        Timer1.Start()

    End Sub
    Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub

    Private Sub PicCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim winpath As String
        winpath = Space(50)
        'GetWindowsDirectory(winpath, 50)
        Shell(Trim(winpath) & "calc.exe")
    End Sub

   



    Private Sub mnuProd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProd.Click
        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Product.MdiParent = Me
        Product.Width = Me.Width
        Product.Height = Me.Height
        Product.Show()
    End Sub

    Private Sub mnuSup_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSup.Click
        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Suppliers.MdiParent = Me
        Suppliers.Width = Me.Width
        Suppliers.Height = Me.Height
        Suppliers.Show()
    End Sub

    Private Sub mnuComp_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComp.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        Company.MdiParent = Me
        Company.Width = Me.Width
        Company.Height = Me.Height
        Company.Show()
    End Sub

    Private Sub mnuCust_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCust.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Customer.MdiParent = Me
        Customer.Width = Me.Width
        Customer.Height = Me.Height
        Customer.Show()
    End Sub

    Private Sub mnuOth_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOth.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Others.MdiParent = Me
        Others.Width = Me.Width
        Others.Height = Me.Height
        Others.Show()
    End Sub

    Private Sub mnuExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        'If mnuWins.HasDropDownItems = True Then
        '    MsgBox("Close All The Forms Before You Exit..!", MsgBoxStyle.Critical)

        '    Exit Sub
        'End If

        Me.Close()
    End Sub

    Private Sub mnuInvo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvo.Click
        Dim cmd As New OleDb.OleDbCommand

        Try
            If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
            cmd.Connection = Conn
            cmd.CommandText = "select ISNULL(PatientFirst,0) from settings"

            If cmd.ExecuteScalar Then
                Dim inv As New SalesinvHp
                inv.MdiParent = Me
                inv.Width = Me.Width
                inv.Height = Me.Height
                inv.Show()
            Else
                Dim inv As New Salesinv
                inv.MdiParent = Me
                inv.Width = Me.Width
                inv.Height = Me.Height
                inv.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuRec_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRec.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Dim rcv As New Purchase
        rcv.MdiParent = Me
        rcv.Width = Me.Width
        rcv.Height = Me.Height
        rcv.Show()
    End Sub

    Private Sub mnuSalret_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalret.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        SalesRtn.MdiParent = Me
        SalesRtn.Width = Me.Width
        SalesRtn.Height = Me.Height
        SalesRtn.Show()

    End Sub

    Private Sub mnuPurcret_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPurcret.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        PurchaseReturn.MdiParent = Me
        PurchaseReturn.Width = Me.Width
        PurchaseReturn.Height = Me.Height
        PurchaseReturn.Show()
    End Sub



    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim winpath As String
        winpath = Space(50)
        'GetWindowsDirectory(winpath, 50)
        Shell(Trim(winpath) & "calc.exe")
    End Sub

    Private Sub mnuAbt_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbt.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        AboutUs.ShowDialog()
    End Sub



    Private Sub SsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnucarddetail.Click
        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        CardDetails.MdiParent = Me
        CardDetails.Width = Me.Width
        CardDetails.Height = Me.Height
        CardDetails.Show()
    End Sub

    Private Sub PrescriptionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnupreentry.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        PrescriptionEntry.MdiParent = Me
        CardDetails.Width = Me.Width
        CardDetails.Height = Me.Height
        PrescriptionEntry.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        PRSettlement.MdiParent = Me
        PRSettlement.Width = Me.Width
        PRSettlement.Height = Me.Height
        PRSettlement.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuReceivable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReceivable.Click
        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        InvAccounts.MdiParent = Me
        InvAccounts.Width = Me.Width
        InvAccounts.Height = Me.Height
        InvAccounts.Show()
    End Sub

    Private Sub mnuRefstk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefstk.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Dim CMD As New OleDb.OleDbCommand
        CMD.Connection = Conn
        CMD.CommandText = "DELETE  FROM OUTGO"
        CMD.ExecuteNonQuery()
    End Sub

    Private Sub OTCConversionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTCConversionToolStripMenuItem.Click
        If OTCConversionToolStripMenuItem.Visible Then Exit Sub
        OTCConv.ShowDialog()
    End Sub

    Private Sub mnuBilldet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReports.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        Reports.Height = Me.Height
        Reports.Width = Me.Width
        Reports.MdiParent = Me
        Reports.WindowState = FormWindowState.Maximized
        Reports.Show()

    End Sub

    Private Sub mnuGenorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReorder.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Reorder.MdiParent = Me
        Reorder.Width = Me.Width
        Reorder.Height = Me.Height
        Reorder.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub mnuWins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWins.Click

    End Sub

    Private Sub DateChangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDtChange.Click
        If mnuWins.HasDropDownItems Then
            MsgBox("Close all windows before changing the date..", MsgBoxStyle.Information)
            Exit Sub
        End If
        DateChange.ShowDialog()

    End Sub

    Private Sub mnuPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPay.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        InvAccountsPay.MdiParent = Me
        InvAccountsPay.Width = Me.Width
        InvAccountsPay.Height = Me.Height
        InvAccountsPay.Show()
    End Sub

    Private Sub PostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WriteAccll()
    End Sub


    Private Sub WriteAcc()
        Dim vouno, cashcode, pcode As Long
        Dim seq As Long
        Dim sqlddt As String

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd3 As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim dr1 As OleDb.OleDbDataReader
        Dim BillType As Long
        Dim vn As Long


        Dim dbcn As New OleDb.OleDbConnection
        Dim dbcmd As New OleDb.OleDbCommand

        dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\Sona\Reliable\Accounts\Unit1\acdata.mdb" & ";Jet OLEDB:Database Password=VALOTH"
        dbcn.Open()
        dbcmd.Connection = dbcn

        cmd.Connection = Conn
        cmd1.Connection = Conn
        cmd.CommandText = "select * from purchase where type='12'"

        dr = cmd.ExecuteReader

        While dr.Read
            If dr("RCTNO") = 21847 Then
                MsgBox("SKJHS")
            End If
            cmd3.Connection = dbcn
            cmd3.CommandText = "SELECT vouno,amt from ledger where trntype='Pu' and seq=1 and invcode='12" & dr("rctno") & "'"
            dr1 = cmd3.ExecuteReader
            If Not dr1.HasRows Then
                dr1.Close()
                cmd1.CommandText = "update serialnum set slno=slno+1 where type=94"
                cmd1.ExecuteNonQuery()

                cmd1.CommandText = "select slno from serialnum where type=94"
                vouno = cmd1.ExecuteScalar
                vouno = vouno + 100000
                'Else
                '    dr1.Read()
                '    vouno = dr1(0)

                '    dbcmd.CommandText = "DELETE FROM LEDGER WHERE VOUNO=" & vouno & " AND TRNTYPE='Pu'"
                '    dbcmd.ExecuteNonQuery()

                'End If

                cmd1.CommandText = "select pucacode from settings "
                cashcode = cmd1.ExecuteScalar


                BillType = 2
                pcode = dr("supcode") ' Val(cbSupp.SelectedValue)

                If Not IsDate(dr("duedt")) Then
                    sqlddt = "NULL"
                Else
                    sqlddt = "'" & dr("duedt") & "'"
                End If
                seq = 1

                dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                        dr("pdate") & "','Pu'," & vouno & "," & _
                        pcode & "," & dr("rctamt") & "," & BillType & ",""" & _
                        Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                        seq & ",'12" & dr("rctno") & "',2)"
                dbcmd.ExecuteNonQuery()
                seq = seq + 1

                If dr("PTX2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1517," & dr("PTX2") & "," & BillType & ",""" & _
                         Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                          seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PTX3") <> 0 Then

                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1961," & dr("PTX3") & "," & BillType & ",""" & _
                          Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PAMT2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1520," & dr("PAMT2") & "," & BillType & ",""" & _
                          Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PAMT3") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1960," & dr("PAMT3") & "," & BillType & ",""" & _
                          Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("PTFAMT") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1521," & dr("PTFAMT") & "," & BillType & ",""" & _
                        Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PADJ") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1522," & System.Math.Abs(dr("PADJ")) & "," & BillType & ",""" & _
                          Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "'," & IIf(dr("PADJ") < 0, "2", "1") & ")"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If
            Else

                dr1.Read()
                If dr1.Item("amt") <> dr("rctamt") Then
                    vouno = dr1.Item("vouno")
                    dr1.Close()

                    dbcmd.CommandText = "delete from ledger " & _
                        "where trntype='Pu' and vouno=" & vouno
                    dbcmd.ExecuteNonQuery()


                    cmd1.CommandText = "select pucacode from settings "
                    cashcode = cmd1.ExecuteScalar


                    BillType = 2
                    pcode = dr("supcode") ' Val(cbSupp.SelectedValue)

                    If Not IsDate(dr("duedt")) Then
                        sqlddt = "NULL"
                    Else
                        sqlddt = "'" & dr("duedt") & "'"
                    End If
                    seq = 1

                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                            "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                            dr("pdate") & "','Pu'," & vouno & "," & _
                            pcode & "," & dr("rctamt") & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                            seq & ",'12" & dr("rctno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1

                    If dr("PTX2") <> 0 Then
                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1517," & dr("PTX2") & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                              seq & ",'12" & dr("rctno") & "',1)"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If


                    If dr("PTX3") <> 0 Then

                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1961," & dr("PTX3") & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                             seq & ",'12" & dr("rctno") & "',1)"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If


                    If dr("PAMT2") <> 0 Then
                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1520," & dr("PAMT2") & "," & BillType & ",""" & _
                            Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                             seq & ",'12" & dr("rctno") & "',1)"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If




                    If dr("PAMT3") <> 0 Then
                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1960," & dr("PAMT3") & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                             seq & ",'12" & dr("rctno") & "',1)"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If

                    If dr("PTFAMT") <> 0 Then
                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1521," & dr("PTFAMT") & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                             seq & ",'12" & dr("rctno") & "',1)"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If


                    If dr("PADJ") <> 0 Then
                        dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                             "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                             dr("pdate") & "','Pu'," & vouno & "," & _
                             "1522," & System.Math.Abs(dr("PADJ")) & "," & BillType & ",""" & _
                             Microsoft.VisualBasic.Left(dr("billno"), 10) & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                             seq & ",'12" & dr("rctno") & "'," & IIf(dr("PADJ") < 0, "2", "1") & ")"
                        dbcmd.ExecuteNonQuery()
                        seq = seq + 1
                    End If

                    'MsgBox(dr1("VOUNO"))
                End If
                dr1.Close()

            End If
        End While
        dbcn.Close()

    End Sub
    Private Sub WriteAccll()
        Dim vouno, cashcode, pcode As Long
        Dim seq As Long
        Dim sqlddt As String

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd3 As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim dr1 As OleDb.OleDbDataReader
        Dim BillType As Long
        Dim vn As Long


        Dim dbcn As New OleDb.OleDbConnection
        Dim dbcmd As New OleDb.OleDbCommand

        dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\Llm2\d\Reliable\Accounts\Unit1\acdata.mdb" & ";Jet OLEDB:Database Password=VALOTH"
        dbcn.Open()
        dbcmd.Connection = dbcn

        cmd.Connection = Conn
        cmd1.Connection = Conn
        cmd.CommandText = "select * from purchase where type='12' AND PDATE>convert(datetime,'01/06/2011')"

        dr = cmd.ExecuteReader

        While dr.Read
            If dr("RCTNO") = 21847 Then
                'MsgBox("SKJHS")
            End If
            cmd3.Connection = dbcn
            cmd3.CommandText = "SELECT vouno,amt from ledger where trntype='Pu' and seq=1 and invcode='12" & dr("rctno") & "'"
            dr1 = cmd3.ExecuteReader
            If Not dr1.HasRows Then
                dr1.Close()
                cmd1.CommandText = "update serialnum set slno=slno+1 where type=94"
                cmd1.ExecuteNonQuery()

                cmd1.CommandText = "select slno from serialnum where type=94"
                vouno = cmd1.ExecuteScalar
                'Else
                '    dr1.Read()
                '    vouno = dr1(0)

                '    dbcmd.CommandText = "DELETE FROM LEDGER WHERE VOUNO=" & vouno & " AND TRNTYPE='Pu'"
                '    dbcmd.ExecuteNonQuery()

                'End If






                cmd1.CommandText = "select pucacode from settings "
                cashcode = cmd1.ExecuteScalar


                BillType = 2
                pcode = dr("supcode") ' Val(cbSupp.SelectedValue)

                If Not IsDate(dr("duedt")) Then
                    sqlddt = "NULL"
                Else
                    sqlddt = "'" & dr("duedt") & "'"
                End If
                seq = 1

                dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                        dr("pdate") & "','Pu'," & vouno & "," & _
                        pcode & "," & dr("rctamt") & "," & BillType & ",""" & _
                        dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                        seq & ",'12" & dr("rctno") & "',2)"
                dbcmd.ExecuteNonQuery()
                seq = seq + 1

                If dr("PTX2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1517," & dr("PTX2") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                          seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PTX3") <> 0 Then

                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1961," & dr("PTX3") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PAMT2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1520," & dr("PAMT2") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If




                If dr("PAMT3") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1960," & dr("PAMT3") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("PTFAMT") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1521," & dr("PTFAMT") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PADJ") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1522," & System.Math.Abs(dr("PADJ")) & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "'," & IIf(dr("PADJ") < 0, "2", "1") & ")"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If
            Else

                dr1.Read()
                'If dr1.Item("amt") <> dr("rctamt") Then
                vouno = dr1.Item("vouno")
                dr1.Close()

                dbcmd.CommandText = "delete from ledger " & _
                    "where trntype='Pu' and vouno=" & vouno
                dbcmd.ExecuteNonQuery()


                cmd1.CommandText = "select pucacode from settings "
                cashcode = cmd1.ExecuteScalar


                BillType = 2
                pcode = dr("supcode") ' Val(cbSupp.SelectedValue)

                If Not IsDate(dr("duedt")) Then
                    sqlddt = "NULL"
                Else
                    sqlddt = "'" & dr("duedt") & "'"
                End If
                seq = 1

                dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                        dr("pdate") & "','Pu'," & vouno & "," & _
                        pcode & "," & dr("rctamt") & "," & BillType & ",""" & _
                        dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                        seq & ",'12" & dr("rctno") & "',2)"
                dbcmd.ExecuteNonQuery()
                seq = seq + 1

                If dr("PTX2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1517," & dr("PTX2") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                          seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PTX3") <> 0 Then

                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1961," & dr("PTX3") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PAMT2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1520," & dr("PAMT2") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If




                If dr("PAMT3") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1960," & dr("PAMT3") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("PTFAMT") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1521," & dr("PTFAMT") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "',1)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("PADJ") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("pdate") & "','Pu'," & vouno & "," & _
                         "1522," & System.Math.Abs(dr("PADJ")) & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("rctno") & "'," & IIf(dr("PADJ") < 0, "2", "1") & ")"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                'End If
                dr1.Close()

            End If
        End While
        dbcn.Close()

    End Sub
    Private Sub WriteAccSal()
        Dim vouno, cashcode, pcode As Long
        Dim seq As Long
        Dim sqlddt As String

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd3 As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim dr1 As OleDb.OleDbDataReader
        Dim BillType As Long
        Dim vn As Long


        Dim dbcn As New OleDb.OleDbConnection
        Dim dbcmd As New OleDb.OleDbCommand

        dbcn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\Llm2\d\Reliable\Accounts\Unit1\acdata.mdb" & ";Jet OLEDB:Database Password=VALOTH"
        dbcn.Open()
        dbcmd.Connection = dbcn

        cmd.Connection = Conn
        cmd1.Connection = Conn
        cmd.CommandText = "select * from invtotal where type='21' or type='22' or TYPE='26' "
        cmd3.Connection = dbcn
        cmd3.CommandText = "Delete from ledger where trntype='Sv'"

        dr = cmd.ExecuteReader
        While dr.Read
            cmd3.Connection = dbcn
            cmd3.CommandText = "SELECT vouno,amt from ledger where trntype='Sv' and seq=1 and invcode='" & dr("type") & dr("rctno") & "'"
            dr1 = cmd3.ExecuteReader
            If Not dr1.HasRows Then
                dr1.Close()
                cmd1.CommandText = "update serialnum set slno=slno+1 where type=93"
                cmd1.ExecuteNonQuery()

                cmd1.CommandText = "select slno from serialnum where type=93"
                vouno = cmd1.ExecuteScalar

                cmd1.CommandText = "select sacacode from settings "
                cashcode = cmd1.ExecuteScalar

                If dr("type") = "22" Then
                    BillType = 2
                    pcode = dr("Cuscode")
                Else
                    BillType = 1
                    pcode = cashcode
                End If

                sqlddt = "NULL"

                seq = 1

                dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                        "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                        dr("invdt") & "','Sv'," & vouno & "," & _
                        pcode & "," & dr("netamt") & "," & BillType & ",""" & _
                        dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                        seq & ",'" & dr("type") & dr("rctno") & "',1)"
                dbcmd.ExecuteNonQuery()
                seq = seq + 1


                If dr("tax1") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1961," & dr("tax1") & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("tax2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1517," & dr("TaX2") & "," & BillType & ",""" & _
                         dr("invdt") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                          seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("tax3") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1961," & dr("tax3") & "," & BillType & ",""" & _
                         dr("billno") & """,'" & dr("billdt") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("amt1") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1960," & dr("amt1") & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("amt2") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1520," & dr("amt2") & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("trndate") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("amt3") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1960," & dr("amt3") & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

                If dr("tfamt") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invdt") & "','Sv'," & vouno & "," & _
                         "1521," & dr("tfamt") & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                         seq & ",'" & dr("type") & dr("invno") & "',2)"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If


                If dr("addamt") - dr("dedamt") <> 0 Then
                    dbcmd.CommandText = "insert into Ledger (TrnDate,TrnType,VouNo,AcCode," & _
                         "Amt,BillType,BillNo,billdt,duedt,Seq,InvCode,drcr) values('" & _
                         dr("invno") & "','Sv'," & vouno & "," & _
                         "1522," & System.Math.Abs(dr("addamt") - dr("dedamt")) & "," & BillType & ",""" & _
                         dr("invno") & """,'" & dr("invdt") & "'," & sqlddt & "," & _
                         seq & ",'12" & dr("invno") & "'," & IIf(dr("addamt") - dr("dedamt") < 0, "1", "2") & ")"
                    dbcmd.ExecuteNonQuery()
                    seq = seq + 1
                End If

            End If
        End While
        dbcn.Close()

    End Sub
    Private Sub DuplicateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicateToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Duplicate.MdiParent = Me
        Duplicate.Width = Me.Width
        Duplicate.Height = Me.Height
        Duplicate.Show()
    End Sub

    Private Sub CardSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardSalesToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        CardSales.MdiParent = Me
        CardSales.Width = Me.Width
        CardSales.Height = Me.Height
        CardSales.Show()
    End Sub

    Private Sub mnuBkup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBkup.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Backup.ShowDialog()
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub ExportToSDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToSDFToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        SdfExport.ShowDialog()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Label2.Text = "" Then
    '        If ExpiryList <> "" Then
    '            Label2.Text = ExpiryList
    '            Label2.Left = Panel1.Width

    '        Else



    '        End If
    '    Else
    '        Label2.Left -= 1
    '        If Label2.Left < -Label2.Width Then
    '            Label2.Left = Panel1.Width
    '        End If

    '    End If
    'End Sub

    Private Sub GraphToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuGraph.Click

    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        GraphSales.MdiParent = Me
        GraphSales.Width = Me.Width
        GraphSales.Height = Me.Height
        GraphSales.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        GraphPurchase.MdiParent = Me
        GraphPurchase.Width = Me.Width
        GraphPurchase.Height = Me.Height
        GraphPurchase.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ComparisanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparisanToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        GraphCompare.MdiParent = Me
        GraphCompare.Width = Me.Width
        GraphCompare.Height = Me.Height
        GraphCompare.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ProfitabilityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitabilityToolStripMenuItem.Click


        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Graphprofitability.MdiParent = Me
        Graphprofitability.Width = Me.Width
        Graphprofitability.Height = Me.Height
        Graphprofitability.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Timestrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Timestrip.ItemClicked

    End Sub

    Private Sub Main_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

        Dim renderer As New clsColorToolstripRenderer
        If Me.ActiveMdiChild Is Nothing Then

            renderer.BackColor = Color.Wheat
            Panel1.BackColor = Color.Wheat
            Label2.ForeColor = Color.Black
            ToolStripLabel1.ForeColor = Color.Black
            bttnnode.ForeColor = Color.Black
            ToolStripLabel3.ForeColor = Color.Black
            btnusr.ForeColor = Color.Black
            ToolStripLabel2.ForeColor = Color.Black
            Btnnow.ForeColor = Color.Black
            lblDatabase.ForeColor = Color.Black
            lblserver.ForeColor = Color.Black
            ' tsbaboutus.ForeColor = Color.Black

        Else
            renderer.BackColor = Me.ActiveMdiChild.BackColor
            Panel1.BackColor = Me.ActiveMdiChild.BackColor
            Label2.ForeColor = Me.ActiveMdiChild.ForeColor

            ToolStripLabel1.ForeColor = Me.ActiveMdiChild.ForeColor
            bttnnode.ForeColor = Me.ActiveMdiChild.ForeColor
            ToolStripLabel3.ForeColor = Me.ActiveMdiChild.ForeColor
            btnusr.ForeColor = Me.ActiveMdiChild.ForeColor
            ToolStripLabel2.ForeColor = Me.ActiveMdiChild.ForeColor
            Btnnow.ForeColor = Me.ActiveMdiChild.ForeColor
            lblDatabase.ForeColor = Me.ActiveMdiChild.ForeColor
            lblserver.ForeColor = Me.ActiveMdiChild.ForeColor
            ' tsbaboutus.ForeColor = Me.ActiveMdiChild.ForeColor
            Me.ActiveMdiChild.WindowState = FormWindowState.Maximized
        End If
        MenuStrip1.Renderer = New clsMenuRenderer
        Ts.Renderer = New clsToolstripRenderer

        'MenuStrip1.Renderer = renderer
        'StatusStrip1.Renderer = renderer
        Timestrip.Renderer = renderer
        CheckConnection()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Dim RLT As String
        Dim cmd As New OleDb.OleDbCommand
        Dim DT As New DataTable
        Dim DA As New OleDb.OleDbDataAdapter
        Dim x As Integer
        cmd.Connection = Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select isnull(scrollopt,0) from settings"
        x = cmd.ExecuteScalar
        Select Case x


            Case 0
                cmd.CommandText = "SELECT  Product.PrdName, Product.case1, Batch.Batch, Batch.ExDt, Batch.Stock, Acmaster.AcName AS sup " & _
                                ", Acmaster.Place FROM Product INNER JOIN Batch ON Product.PrdCode = Batch.PrdCode INNER JOIN  Acmaster " & _
                                "ON Batch.Supcode = Acmaster.AcCode WHERE " & _
                                "Batch.ExDt <='" & Format(DateAdd(DateInterval.Day, ShortExpDays, SysDt), "yyyyMMdd") & "' and stock>0   ORDER BY batch.exdt,Product.PrdName   "
                DA.SelectCommand = cmd
                DA.Fill(DT)
                cmd.Parameters.Clear()

                RLT = Space(150) & "Short Expiry List:- "

                For I = 0 To DT.Rows.Count - 1
                    RLT = RLT + "  -  " + DT.Rows(I).Item("PrdName") & " " & Format(DT.Rows(I).Item("Stock"), "0") & " " & DT.Rows(I).Item("case1") & " (" & DT.Rows(I).Item("batch") & " " & DT.Rows(I).Item("exdt") & " " & DT.Rows(I).Item("sup") & ") "
                Next
            Case 2
                cmd.CommandText = "SELECT Product.PrdName, Product.case1, ISNULL(Product.Rol, 0) AS Rol, batch1.stk FROM Product INNER JOIN " & _
                            " (SELECT        SUM(Stock) AS stk, PrdCode FROM Batch GROUP BY PrdCode) AS batch1 ON " & _
                            "Product.PrdCode = batch1.PrdCode AND ISNULL(Product.Rol, 0) >= batch1.stk WHERE ISNULL(Product.Rol, 0) > 0 " & _
                            " ORDER BY Product.PrdName  "
                DA.SelectCommand = cmd
                DA.Fill(DT)
                cmd.Parameters.Clear()

                RLT = Space(150) & "Bellow ROL List:- "

                For I = 0 To DT.Rows.Count - 1
                    RLT = RLT + "  -  " + DT.Rows(I).Item("PrdName") & " " & Format(DT.Rows(I).Item("stk"), "0") & " " & DT.Rows(I).Item("case1") & "  ROL (" & Format(DT.Rows(I).Item("rol"), "0") & ")"
                Next

            Case 1

                cmd.CommandText = "SELECT  Product.PrdName, Product.case1,SUM(batch1.stk) AS STK FROM  Product INNER JOIN " & _
                            "(SELECT        SUM(Stock) AS stk, PrdCode  FROM Batch GROUP BY PrdCode) AS batch1 ON Product.PrdCode = batch1.PrdCode " & _
                            " INNER JOIN ShortItem ON Product.PrdCode = ShortItem.PrdCode " & _
                            " GROUP BY Product.PrdName, Product.case1 ORDER BY Product.PrdName"

                DA.SelectCommand = cmd
                DA.Fill(DT)
                cmd.Parameters.Clear()

                RLT = Space(150) & "Short Item:- "

                For I = 0 To DT.Rows.Count - 1
                    RLT = RLT + "  -  " + DT.Rows(I).Item("PrdName") & " " & Format(DT.Rows(I).Item("stk"), "0")
                Next
        End Select
        
        e.Result = RLT & Space(50)

        If Not RegChecked Then


        End If

    End Sub








    Private Sub QuickViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuqv.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        QuickView.Height = Me.Height
        QuickView.Width = Me.Width
        QuickView.MdiParent = Me
        QuickView.WindowState = FormWindowState.Maximized
        QuickView.Show()
    End Sub

    Private Sub SerialNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialNoToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        SerialReNumber.Height = Me.Height
        SerialReNumber.Width = Me.Width
        SerialReNumber.MdiParent = Me
        SerialReNumber.WindowState = FormWindowState.Maximized
        SerialReNumber.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Settings.Height = Me.Height
        Settings.Width = Me.Width
        Settings.MdiParent = Me
        Settings.WindowState = FormWindowState.Maximized
        Settings.Show()
    End Sub

    Private Sub AccountsPostingHeadsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountsPostingHeadsToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        AccPostHeads.MdiParent = Me
        AccPostHeads.Width = Me.Width
        AccPostHeads.Height = Me.Height
        AccPostHeads.Show()
    End Sub

    Private Sub BarcodeEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeEntryToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        BarcodeEntry.MdiParent = Me
        BarcodeEntry.Width = Me.Width
        BarcodeEntry.Height = Me.Height
        BarcodeEntry.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        CustGrp.MdiParent = Me
        CustGrp.Width = Me.Width
        CustGrp.Height = Me.Height
        CustGrp.Show()
    End Sub

    Private Sub Mnucruser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnucruser.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        UserMaster.MdiParent = Me
        UserMaster.Width = Me.Width
        UserMaster.Height = Me.Height
        UserMaster.Show()
    End Sub

    Private Sub Mnuright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnuright.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        UserRights.MdiParent = Me
        UserRights.Width = Me.Width
        UserRights.Height = Me.Height
        UserRights.Show()
    End Sub

    Private Sub SMSRegistryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSRegistryToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        SMSReg.MdiParent = Me
        SMSReg.Show()
    End Sub

    Private Sub SMSSendingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSSendingToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        SMSSendng.MdiParent = Me
        SMSSendng.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        EmailSndng.MdiParent = Me
        EmailSndng.Show()
    End Sub

    Private Sub Mnupwrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnupwrd.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        ChangePassword.MdiParent = Me
        ChangePassword.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        ShiftChange.MdiParent = Me
        ShiftChange.Show()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuresotre.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Restore.Show()
    End Sub

    Private Sub ServiceToolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceToolsToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        ServiceTools.MdiParent = Me
        ServiceTools.Width = Me.Width
        ServiceTools.Height = Me.Height

        ServiceTools.Show()
    End Sub


    Private Sub TransactionDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionDetailsToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        TransactionDetails.MdiParent = Me
        TransactionDetails.Width = Me.Width
        TransactionDetails.Height = Me.Height
        TransactionDetails.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub

        BatchBarCode.MdiParent = Me
        BatchBarCode.Width = Me.Width
        BatchBarCode.Height = Me.Height
        BatchBarCode.Show()
    End Sub

    Private Sub EMailSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMailSettingsToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        eMailSetting.MdiParent = Me
        eMailSetting.Width = Me.Width
        eMailSetting.Height = Me.Height
        eMailSetting.Show()
    End Sub



    Private Sub tm_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        TIMERON = True
        OnTimedEvent()
        TIMERON = False
    End Sub

    Private Sub OnTimedEvent()
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        'Dim conn As New OleDb.OleDbConnection
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim dt1 As New DataTable
        Dim dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9 As New DataTable
        Dim LastTime As DateTime
        Try
            cmd.Connection = Conn
            cmd1.Connection = Conn
            cmd.CommandText = "Select * from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            'If IsDBNull(dt.Rows(0).Item("MailServer")) = True Then
            '    Exit Sub
            'End If
            ''myTimer.Interval = 1000
            ''myTimer.Start()
            'myTimer.Enabled = True

            'send email
            cmd.CommandText = "Select * from MailStatus where Sent = 0"
            da.SelectCommand = cmd
            da.Fill(ds1, "Setting")
            dt1 = ds1.Tables("Setting")
            If dt1.Rows.Count > 0 Then
                For i = 0 To dt1.Rows.Count - 1
                    DoEmail(dt1.Rows(0).Item("EMailIdTo"), dt1.Rows(0).Item("Text"), dt1.Rows(0).Item("Id"), 0)
                Next
            End If

            'send sms 
            cmd.CommandText = "Select * from SMSStatus where Sent = 0"
            da.SelectCommand = cmd
            da.Fill(ds2, "Setting")
            dt2 = ds2.Tables("Setting")

            If dt2.Rows.Count > 0 Then
                For i = 0 To dt2.Rows.Count - 1
                    If dt2.Rows(0).Item("MobNo") <> "" Then
                        DoSMS(dt2.Rows(0).Item("MobNo"), dt2.Rows(0).Item("SMSText"), dt2.Rows(0).Item("Id"), 0)
                    End If
                Next
            End If


            If TU = 0 Then
                cmd.CommandText = "Select GetDate() as Date"
                da.SelectCommand = cmd
                da.Fill(ds, "Date")
                dt8 = ds.Tables("Date")

                cmd.CommandText = "Update Settings set UpdatedTime ='" & dt8.Rows(0).Item("Date") & "'"
                cmd.ExecuteNonQuery()
                TU = 1
            Else
                cmd.CommandText = "Select UpdatedTime,SendAfterHrs from Settings"
                da.SelectCommand = cmd
                da.Fill(ds1, "UpdatedTime")
                dt3 = ds1.Tables("UpdatedTime")
                LastTime = dt3.Rows(0).Item("UpdatedTime")
                Dim hours As Long
                Dim OrgText, eMailText, MobText As String
                hours = DateDiff("h", LastTime, DateTime.Now)
                If Val(dt3.Rows(0).Item("SendAfterHrs") & "") <> 0 Then
                    If hours = dt3.Rows(0).Item("SendAfterHrs") Then
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "GETSALESDETAILS"
                        cmd.Parameters.Add("@DATE", OleDb.OleDbType.DBDate).Value = SysDt
                        da.SelectCommand = cmd
                        da.Fill(ds, "Sale")
                        dt5 = ds.Tables("Sale")

                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "GETPURCHASEDETAILS"
                        cmd.Parameters.Add("@DATE", OleDb.OleDbType.DBDate).Value = SysDt
                        da.SelectCommand = cmd
                        da.Fill(ds, "Purchase")
                        dt6 = ds.Tables("Purchase")

                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "GETPREVSALESDETAILS"
                        cmd.Parameters.Add("@DATE", OleDb.OleDbType.DBDate).Value = DateAdd(DateInterval.Day, -1, SysDt)
                        da.SelectCommand = cmd
                        da.Fill(ds, "Purchase")
                        dt7 = ds.Tables("Purchase")

                        If IsDBNull(dt.Rows(0).Item("EmailSaleText")) = False Then
                            OrgText = dt.Rows(0).Item("EmailSaleText")
                            eMailText = OrgText.Replace("#Sale#", dt5.Rows(0).Item("NetAmt"))
                            eMailText = eMailText.Replace("#Purchase#", dt6.Rows(0).Item("NetAmt"))
                            eMailText = eMailText.Replace("#PrevSale#", dt7.Rows(0).Item("NetAmt"))
                        Else
                            eMailText = ""
                        End If

                        If IsDBNull(dt.Rows(0).Item("SmsSaleText")) = False Then
                            OrgText = dt.Rows(0).Item("SmsSaleText")
                            MobText = OrgText.Replace("#Sales#", dt5.Rows(0).Item("NetAmt"))
                            MobText = MobText.Replace("#Purchase#", dt6.Rows(0).Item("NetAmt"))
                            MobText = MobText.Replace("#PrevSale#", dt7.Rows(0).Item("NetAmt"))
                        Else
                            MobText = ""
                        End If

                        DoEmail("", eMailText, -1, 1)

                        DoSMS("", MobText, -1, 1)

                        cmd1.CommandText = "Select GetDate() as Date"
                        da.SelectCommand = cmd1
                        da.Fill(ds2, "Date")
                        dt9 = ds2.Tables("Date")

                        cmd1.CommandText = "Update Settings set UpdatedTime ='" & dt9.Rows(0).Item("Date") & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub DoEmail(ByVal MailAdd As String, ByVal text As String, ByVal Id As Long, ByVal Type As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        'Me.Cursor = Cursors.WaitCursor
        Try
            Dim blnSMTP As Boolean = False
            Dim blnCC As Boolean = False
            Dim blnAttachments As Boolean = False
            'Dim atch As Attachment

            Dim palinBody As String = text
            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(palinBody, Nothing, "text/plain")
            'Dim htmlBody As String = text.HtmlDocument2.GetBody().innerHTML
            'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")

            cmd.Connection = Conn
            cmd.CommandText = "Select * from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            Dim smtp As System.Net.Mail.SmtpClient = New SmtpClient(dt.Rows(0).Item("Host"), Val(dt.Rows(0).Item("PortNo")))
            smtp.Host = dt.Rows(0).Item("Host")

            smtp.Port = Val(dt.Rows(0).Item("PortNo"))
            smtp.UseDefaultCredentials = False
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential(dt.Rows(0).Item("UserName").ToString, dt.Rows(0).Item("Password").ToString)
            If Type = 0 Then
                If EmailAddressCheck(MailAdd) = True Then
                    Dim insMail As New System.Net.Mail.MailMessage()
                    With insMail
                        .From = New System.Net.Mail.MailAddress(dt.Rows(0).Item("UserName").ToString, DeScriptRS(Firm.Name))
                        .To.Add(New System.Net.Mail.MailAddress(MailAdd).ToString)
                        .IsBodyHtml = True
                        .Subject = ""
                        .AlternateViews.Add(plainView)
                    End With
                    smtp.Send(insMail)

                    cmd.CommandText = "Update MailStatus set Sent = 1 where Id = " & Id
                    cmd.ExecuteNonQuery()
                End If
            End If

            If Type = 1 Then
                'If EmailAddressCheck(MailAdd) = True Then
                'End If

                Dim insMail As New System.Net.Mail.MailMessage()
                With insMail
                    .From = New System.Net.Mail.MailAddress(dt.Rows(0).Item("UserName").ToString, DeScriptRS(Firm.Name))
                    If dt.Rows(0).Item("EmailSaleId1").ToString <> "" Then
                        .To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("EmailSaleId1").ToString).ToString)
                    End If
                    If dt.Rows(0).Item("EmailSaleId2").ToString <> "" Then
                        .To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("EmailSaleId2").ToString).ToString)
                    End If
                    If dt.Rows(0).Item("EmailSaleId3").ToString <> "" Then
                        .To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("EmailSaleId3").ToString).ToString)
                    End If
                    If dt.Rows(0).Item("EmailSaleId4").ToString <> "" Then
                        .To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("EmailSaleId4").ToString).ToString)
                    End If
                    If dt.Rows(0).Item("EmailSaleId5").ToString <> "" Then
                        .To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("EmailSaleId5").ToString).ToString)
                    End If
                    '.To.Add(New System.Net.Mail.MailAddress(dt.Rows(0).Item("UserName").ToString).ToString)
                    .IsBodyHtml = True
                    .Subject = "Toatal Sale/Purchase"
                    .AlternateViews.Add(plainView)
                End With
                smtp.Send(insMail)
            End If
            'Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If
    End Function

    Private Sub SMSSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSSettingToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        Mobile_Settings.MdiParent = Me
        Mobile_Settings.Width = Me.Width
        Mobile_Settings.Height = Me.Height
        Mobile_Settings.Show()
    End Sub

    Sub DoSMS(ByVal MobNo As String, ByVal text As String, ByVal Id As Long, ByVal Type As Long)
        'Inherits System.Web.UI.Page
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sURL As String
        Dim objReader As StreamReader
        Dim MobileNo As String
        Try
            'Me.Cursor = Cursors.WaitCursor
            '9422063290
            cmd.Connection = Conn
            cmd.CommandText = "Select * from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")
            If Type = 0 Then
                sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" & dt.Rows(0).Item("MobUserName") & _
                "&password=" & dt.Rows(0).Item("MobPassword") & _
                "&msisdn=" & MobNo & _
                "&sid=" & dt.Rows(0).Item("SenderId") & _
                "&msg=" & text & _
                "&fl=0" & _
                "&gwid=2"
                Dim request As WebRequest
                request = WebRequest.Create(sURL)
                request.Credentials = CredentialCache.DefaultCredentials
                Dim response As WebResponse = request.GetResponse()
                Dim objStream As Stream
                objStream = request.GetResponse.GetResponseStream()
                objReader = New StreamReader(objStream)
                Dim responseFromServer As String = objReader.ReadToEnd()
                objReader.Close()
                response.Close()
                'Console.WriteLine(responseFromServer)
                'responseFromServer = Microsoft.VisualBasic.Left(responseFromServer, 10)
                cmd.CommandText = "Update SMSStatus set Sent = 1, Status = '" & responseFromServer & "' where Id = " & Id
                cmd.ExecuteNonQuery()
            End If
            If Type = 1 Then
                If dt.Rows(0).Item("SmsSaleInfo") = 1 Then
                    MobileNo = ""
                    If Len(dt.Rows(0).Item("SmsSaleMoNo1").ToString) = 12 Then
                        MobileNo = dt.Rows(0).Item("SmsSaleMoNo1")
                    End If

                    If Len(dt.Rows(0).Item("SmsSaleMoNo2").ToString) = 12 Then
                        If MobileNo <> "" Then
                            MobileNo = MobileNo & "," & dt.Rows(0).Item("SmsSaleMoNo2")
                        Else
                            MobileNo = dt.Rows(0).Item("SmsSaleMoNo2")
                        End If
                    End If

                    If Len(dt.Rows(0).Item("SmsSaleMoNo3").ToString) = 12 Then
                        If MobileNo <> "" Then
                            MobileNo = MobileNo & "," & dt.Rows(0).Item("SmsSaleMoNo3")
                        Else
                            MobileNo = dt.Rows(0).Item("SmsSaleMoNo3")
                        End If
                    End If

                    If Len(dt.Rows(0).Item("SmsSaleMoNo4").ToString) = 12 Then
                        If MobileNo <> "" Then
                            MobileNo = MobileNo & "," & dt.Rows(0).Item("SmsSaleMoNo4")
                        Else
                            MobileNo = dt.Rows(0).Item("SmsSaleMoNo4")
                        End If
                    End If

                    If Len(dt.Rows(0).Item("SmsSaleMoNo5").ToString) = 12 Then
                        If MobileNo <> "" Then
                            MobileNo = MobileNo & "," & dt.Rows(0).Item("SmsSaleMoNo5")
                        Else
                            MobileNo = dt.Rows(0).Item("SmsSaleMoNo5")
                        End If
                    End If
                    If MobileNo <> "" Then
                        sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" & dt.Rows(0).Item("MobUserName") & _
                        "&password=" & dt.Rows(0).Item("MobPassword") & _
                        "&msisdn=" & MobileNo & _
                        "&sid=" & dt.Rows(0).Item("SenderId") & _
                        "&msg=" & text & _
                        "&fl=0" & _
                        "&gwid=2"
                        Dim request As WebRequest
                        request = WebRequest.Create(sURL)
                        request.Credentials = CredentialCache.DefaultCredentials
                        Dim response As WebResponse = request.GetResponse()
                        Dim objStream As Stream
                        objStream = request.GetResponse.GetResponseStream()
                        objReader = New StreamReader(objStream)
                        Dim responseFromServer As String = objReader.ReadToEnd()
                        objReader.Close()
                        response.Close()
                        'Console.WriteLine(responseFromServer)
                        'responseFromServer = Microsoft.VisualBasic.Left(responseFromServer, 10)
                        'cmd.CommandText = "Update SMSStatus set Sent = 1, Status = '" & responseFromServer & "' where Id = " & Id
                        'cmd.ExecuteNonQuery()
                    End If
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub ProductGroupingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductGroupingToolStripMenuItem.Click

        If Not CheckUserLocked(sender.TEXT, True) Then Exit Sub
        ProductGrouping.MdiParent = Me
        ProductGrouping.Width = Me.Width
        ProductGrouping.Height = Me.Height
        ProductGrouping.Show()
    End Sub

    Private Sub Timer1_Tick1()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf LabelMove))
        Else
           
        End If

    End Sub

    Private Sub LabelMove()
        TIMERON1 = True

        Label2.Text = Mid(ExpiryList, Val(Label2.Tag) + 1, 500)
        Label2.Refresh()
        Panel1.Refresh()

        Label2.Tag = Val(Label2.Tag) + 1
        If Trim(Label2.Text) = "" Then Label2.Tag = 0
       

        'If Label2.Text = "" Then
        '    If ExpiryList <> "" Then
        '        Label2.Text = ExpiryList
        '        Label2.Left = Panel1.Width
        '        ExpiryList = ""
        '    Else

        '    End If
        'Else
        '    Label2.Left -= 1
        '    If Label2.Left < -Label2.Width Then
        '        Label2.Left = Panel1.Width
        '    End If

        'End If
        TIMERON1 = False
    End Sub
    
    Private Sub Label2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseClick
        If Panel1.Tag = "S" Then
            Timer1.Start()
            Panel1.Tag = ""
        Else
            Timer1.Stop()
            Panel1.Tag = "S"
        End If
    End Sub

    Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
        If Panel1.Tag = "S" Then
            Timer1.Start()
            Panel1.Tag = ""
        Else
            Timer1.Stop()
            Panel1.Tag = "S"
        End If

    End Sub

    
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        ExpiryList = e.Result
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.DoubleClick
        Dim x As Integer
        x = Val(InputBox("Enter Option: 0.Short Expiry,  1.Short Item. 2.Bellow ROL", "Scrolling Option", "0"))
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        If x < 0 Or x > 2 Then Exit Sub
        cmd.CommandText = "update settings set ScrollOpt=" & x
        cmd.ExecuteNonQuery()
        MsgBox("Scroll will reset when next time you start the " & Application.ProductName)
    End Sub


    Private Sub StockAdjustmentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StockAdjustmentToolStripMenuItem.Click
        StockAdj.MdiParent = Me
        StockAdj.Width = Me.Width
        StockAdj.Height = Me.Height
        StockAdj.Show()
    End Sub

     
    Private Sub UploadOrdersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadOrdersToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Upload.MdiParent = Me
        Upload.Width = Me.Width
        Upload.Height = Me.Height
        Upload.Show()
    End Sub

    Private Sub ReceiveBillsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReceiveBillsToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Bills.MdiParent = Me
        Bills.Width = Me.Width
        Bills.Height = Me.Height
        Bills.WindowState = FormWindowState.Maximized

        Bills.Show()
    End Sub

    Private Sub SearchProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchProductToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        FrmSearch.MdiParent = Me
        FrmSearch.Width = Me.Width
        FrmSearch.Height = Me.Height
        FrmSearch.Show()
    End Sub

    Private Sub SupplierMappingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupplierMappingToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        mapsupplier.MdiParent = Me
        mapsupplier.Width = Me.Width
        mapsupplier.Height = Me.Height
        mapsupplier.Show()
    End Sub

    Private Sub ProductMapingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductMapingToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        mapprod.MdiParent = Me
        mapprod.Width = Me.Width
        mapprod.Height = Me.Height
        mapprod.Show()
    End Sub

    Private Sub OrderListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OrderListToolStripMenuItem.Click
        OrderList.MdiParent = Me
        OrderList.Width = Me.Width
        OrderList.Height = Me.Height
        OrderList.Show()
    End Sub

    Private Sub Ts_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Ts.ItemClicked

    End Sub

    Private Sub TT_Popup(sender As System.Object, e As System.Windows.Forms.PopupEventArgs) Handles TT.Popup

    End Sub

    Private Sub Label2_Click_1(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub SearchMissingBillsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchMissingBillsToolStripMenuItem.Click
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        FrmBillSearch.MdiParent = Me
        FrmBillSearch.Width = Me.Width
        FrmBillSearch.Height = Me.Height
        FrmBillSearch.Show()
    End Sub
End Class