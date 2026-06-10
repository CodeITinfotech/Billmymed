Public Class GraphSales

    Private Sub CreateSj()
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String

        If gr.Tag = "Y" Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        gr.Tag = "Y"
        cmd.Connection = Conn
        sql = ""

        gr.Visible = False
        lblwait.Visible = True
        cmd.CommandType = CommandType.StoredProcedure

        If chkmon.Checked Then
            cmd.CommandText = "GetSalesSumMon"
        Else
            cmd.CommandText = "GetSalesSum"
        End If

        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        da.SelectCommand = cmd
        da.Fill(dtab)

        Dim xq, mini, maxi, x1, valu, nod, ava As Double
        gr.Series(0).Points.Clear()
        gr.Series(1).Points.Clear()

        'gr.Series.Clear()
        'gr.Series.Add("Sales")
        'gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.
        nod = 0
        For i = 0 To dtab.Tables(0).Rows.Count - 1
            x1 = 0
            On Error Resume Next
            If Microsoft.VisualBasic.IsDBNull(dtab.Tables(0).Rows(i).Item("netamt")) Then x1 = 0 Else x1 = dtab.Tables(0).Rows(i).Item("netamt") '- rsinv!dis
            On Error GoTo 0
            If x1 <> 0 Then
                If chkmon.Checked Then
                    gr.Series(0).Points.AddXY(Format(dtab.Tables(0).Rows(i).Item("invdt"), "MMM yy"), x1)
                Else
                    gr.Series(0).Points.AddXY(Format(dtab.Tables(0).Rows(i).Item("invdt"), "dd"), x1)

                End If
                If Val(x1) < mini Or mini = 0 Then mini = x1
                If Val(x1) > maxi Then maxi = x1
                nod = nod + 1
                valu = valu + x1
            End If
        Next i

        If nod = 0 Then ava = 0 Else ava = Val(valu / nod)
        'gr.Tag = ava
        For i As Integer = 0 To nod
            gr.Series(1).Points.AddY(ava)
        Next
        lblwait.Visible = False
        gr.Visible = True
        lbllo.Text = Format(mini, "0.00")
        lblhi.Text = Format(maxi, "0.00")
        lblavg.Text = Format(ava, "0.00")
        lbltot.Text = Format(valu, "0.00")
        lblpro.Text = "Wait.."

        bw.RunWorkerAsync()

        Me.Cursor = Cursors.Default
        'CreateSj = dtab.Tables(0)
    End Sub

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnview.Click
       
        CreateSj()

    End Sub

    Private Sub Graph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        gr.Visible = False
        Application.DoEvents()
        dtt.Value = SysDt
        dtf.Value = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, SysDt))

        Btnview.PerformClick()
        gr.Visible = True
    End Sub

    Private Sub rdine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdline.CheckedChanged
        If Me.Visible = False Then Exit Sub
        If reBar.Checked Then
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            CreateSj()
        Else
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline
            CreateSj()
        End If


    End Sub

    Private Sub reBar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reBar.CheckedChanged
        If Me.Visible = False Then Exit Sub
        If reBar.Checked Then
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            CreateSj()
        Else
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline
            CreateSj()
        End If

    End Sub


    Private Sub chkmon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmon.CheckedChanged
        If Me.Visible = False Then Exit Sub
        CreateSj()
    End Sub

    Private Sub bw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork

        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter

        Dim pro As Double
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "GetProductProfitabilitySum"
        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1


        pro = Val(cmd.ExecuteScalar & "")

        'lblpro.Text = Format(pro, "0.00")

        da.SelectCommand = cmd
        da.Fill(dtab)

        e.Result = pro

    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw.ProgressChanged

    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        lblpro.Text = Format(e.Result, "0.00")
        gr.Tag = ""

    End Sub
End Class