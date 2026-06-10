Public Class QuickView
    Private dtf1, dtf2, dtt1, dtt2 As Date
    Private tdt As Date
    Private vi As Integer = 0

    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim rdr As OleDb.OleDbDataReader
        Dim va(2)
        Dim i As Integer
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "GetStockQV"
        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = SysDt
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = SysDt
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        va(0) = 0
        va(1) = 0
        rdr = cmd.ExecuteReader
        I = 0
        If rdr.HasRows Then
            While rdr.Read
                va(0) = Val(rdr("pv") & "")
                va(1) = Val(rdr("sv") & "")
            End While
        End If
        rdr.Close()
        e.Result = va
    End Sub

    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblstk1.Text = Format(va(0), "0.00")
        lblstk2.Text = Format(va(1), "0.00")
        vi = vi - 1
    End Sub
    Private Sub QuickView(ByVal dt As Date)



        dtf1 = CDate("01/" & dt.Month & "/" & dt.Year)

        dtf2 = DateAdd(DateInterval.Month, -1, dtf1)

        dtt1 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf1))

        dtt2 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtf2))



        Do While vi <> 0
            Application.DoEvents()
        Loop
        lbldt.Text = Format(dt, "MMMM yyyy")
        lblpurc1.Text = Format(dtf1, "MMMM yyyy")
        lblpurc2.Text = Format(dtf2, "MMMM yyyy")

        lblsalc1.Text = Format(dtf1, "MMMM yyyy")
        lblsalc2.Text = Format(dtf2, "MMMM yyyy")

        lblproc1.Text = Format(dtf1, "MMMM yyyy")
        lblproc2.Text = Format(dtf2, "MMMM yyyy")

        lblloyc1.Text = Format(dtf1, "MMMM yyyy")
        lblloyc2.Text = Format(dtf2, "MMMM yyyy")

        lblstk1.Text = "Wait..."
        lblstk2.Text = "Wait..."
        lblpro1.Text = "Wait..."
        lblpro2.Text = "Wait..."
        lblsal1.Text = "Wait..."
        lblsal2.Text = "Wait..."
        lblpur1.Text = "Wait..."
        lblpur2.Text = "Wait..."
        lblloy1.Text = "Wait..."
        lblloy2.Text = "Wait..."
        vi = 7
        bw1.RunWorkerAsync()
        bw2.RunWorkerAsync()
        bw3.RunWorkerAsync()
        bw4.RunWorkerAsync()
        bw5.RunWorkerAsync()
        bw6.RunWorkerAsync()
        bw7.RunWorkerAsync()


    End Sub
    Private Sub QuickView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tdt = SysDt
        QuickView(SysDt)
    End Sub

    Private Sub bw3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw3.DoWork
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim va(2)

        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "GetSalesSumQV"
        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf1
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt1
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        va(0) = 0
        va(1) = 0
        va(0) = Val(cmd.ExecuteScalar & "")
        cmd.Parameters(0).Value = dtf2
        cmd.Parameters(1).Value = dtt2
        va(1) = Val(cmd.ExecuteScalar & "")
     
        e.Result = va
    End Sub

    Private Sub bw3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw3.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblsal1.Text = Format(Val(va(0) & ""), "0.00")
        lblsal2.Text = Format(Val(va(1) & ""), "0.00")
        vi = vi - 1
    End Sub

    Private Sub bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw2.DoWork
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim va(2)

        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "GetPurchaseSumQV"
        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf1
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt1
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        va(0) = 0
        va(1) = 0
        va(0) = Val(cmd.ExecuteScalar & "")
        cmd.Parameters(0).Value = dtf2
        cmd.Parameters(1).Value = dtt2
        va(1) = Val(cmd.ExecuteScalar & "")

        e.Result = va
    End Sub

    Private Sub bw2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw2.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblpur1.Text = Format(Val(va(0) & ""), "0.00")
        lblpur2.Text = Format(Val(va(1) & ""), "0.00")
        vi = vi - 1
    End Sub

    Private Sub bw4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw4.DoWork
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim va(2)
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "GetprofitSumQV"
        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf1
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt1
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        va(0) = 0
        va(1) = 0
        va(0) = Val(cmd.ExecuteScalar & "")
        cmd.Parameters(0).Value = dtf2
        cmd.Parameters(1).Value = dtt2
        va(1) = Val(cmd.ExecuteScalar & "")

        e.Result = va
    End Sub

    Private Sub bw4_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw4.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblpro1.Text = Format(Val(va(0) & ""), "0.00")
        lblpro2.Text = Format(Val(va(1) & ""), "0.00")
        vi = vi - 1
    End Sub

    Private Sub bw5_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw5.DoWork
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim va(2)

        cmd.Connection = Conn
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "select count(prdcode) from product where  deleted=0 "

        va(0) = 0
        va(1) = 0
        va(0) = Val(cmd.ExecuteScalar & "")
        
        cmd.CommandText = "select count(distinct prdcode) from batch where stock<>0 "
        va(1) = Val(cmd.ExecuteScalar & "")
        e.Result = va

    End Sub

    Private Sub bw5_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw5.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblprd1.Text = Format(Val(va(0) & ""), "0")
        lblprd2.Text = Format(Val(va(1) & ""), "0")
        vi = vi - 1
    End Sub

    Private Sub bw6_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw6.DoWork
        Dim cmd As New OleDb.OleDbCommand

        Dim rdr As OleDb.OleDbDataReader

        Dim va(4)

     

        va(0) = 0
        va(1) = 0
        va(2) = 0
        va(3) = 0


        e.Result = va
    End Sub

    Private Sub bw6_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw6.RunWorkerCompleted
        Dim va(4) As Object
        va = e.Result
        lblloy1.Text = Format(Val(va(0) & ""), "0.00") & " - (" & va(1) & ")"
        lblloy2.Text = Format(Val(va(2) & ""), "0.00") & " - (" & va(3) & ")"
        vi = vi - 1

    End Sub

    Private Sub lblstk2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblstk2.Click

    End Sub

    Private Sub lblstk1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblstk1.Click

    End Sub

    Private Sub bw7_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw7.DoWork
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim va(2)

        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetPurchaseReturnPending"
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate).Value = dtf1

        va(0) = 0
        va(1) = 0
        va(0) = Val(cmd.ExecuteScalar & "")

        e.Result = va

    End Sub

    Private Sub bw7_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw7.RunWorkerCompleted
        Dim va(2) As Object
        va = e.Result
        lblprtn.Text = Format(Val(va(0) & ""), "0.00")
        va = e.Result
        vi = vi - 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
     
    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tdt = DateAdd("m", -1, tdt)
        QuickView(tdt)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If tdt = SysDt Then Exit Sub
        tdt = DateAdd("m", 1, tdt)
        QuickView(tdt)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        tdt = SysDt
        QuickView(tdt)
    End Sub
 
End Class