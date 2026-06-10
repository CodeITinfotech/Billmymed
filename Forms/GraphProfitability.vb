Public Class Graphprofitability
    Private sertime As DateTime
    Private sertxt As String
    Private obj As Object
    Private ProdSelected As Boolean
     


   
  


    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Dim mlist As New MyListText
        Dim rh As String

        Dim rpt As Object
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        Me.Cursor = Cursors.WaitCursor
        cmd.Connection = Conn
        sql = ""
        Me.Cursor = Cursors.WaitCursor
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Getsvop"
        rh = "Profitability graph for the period " & dtf.Value.Date & "-" & dtt.Value.Date


        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1


        da.SelectCommand = cmd
        da.Fill(dtab)


        rpt = New RptGraphSVOP


        rpt.SetDataSource(dtab.Tables(0))


        rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
        rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
        rpt.SetParameterValue("HEAD4", rh)


        crv.ReportSource = rpt


        crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

        crv.DisplayStatusBar = True
        crv.ShowParameterPanelButton = False

        Me.Cursor = Cursors.Default

    End Sub

     

    Private Sub Graphprofitability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtt.Value = SysDt
        dtf.Value = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, SysDt))

    End Sub
End Class