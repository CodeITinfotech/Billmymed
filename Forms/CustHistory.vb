Public Class CustHistory
    Public Sub History(ByVal cd As Long)
        Dim stdt As Date
        Dim eddt As Date
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim tab, tab2 As New DataTable
        stdt = DateAdd("m", -36, CDate("01/" & Format(SysDt, "MM/yy")))
        eddt = SysDt
        cmd.Connection = Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select name + ' ' + place from carddetails where cardno=" & cd
        lblcust.Text = cmd.ExecuteScalar & ""

        cmd.CommandTimeout = 200
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetCustHistory"
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.Date).Value = stdt
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.Date).Value = eddt
        cmd.Parameters.Add("@cuscode", OleDb.OleDbType.BSTR).Value = cd.ToString

        da.SelectCommand = cmd
        da.Fill(tab)
        DgHist.DataSource = tab
        DgHist.Columns(0).Visible = False
        'DgHist.Columns(8).Visible = False
        'DgHist.Columns(9).Visible = False
        'DgHist.Columns(3).Visible = False
        DgHist.Columns(1).Width = 100
        DgHist.Columns(2).Width = 80

        DgHist.Columns(4).Width = 400
        DgHist.Columns(3).Width = 80

        DgHist.Columns(5).Width = 80
        DgHist.Columns(6).Width = 80
        DgHist.Columns(7).Width = 80
        DgHist.Columns(7).Visible = False
        DgHist.Columns(8).Visible = False
        DgHist.Columns(9).Visible = False
        DgHist.Columns(10).Visible = False
        ' DgHist.Columns(8).Width = 80

        DgHist.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DgHist.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' DgHist.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        DgHist.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        ' DgHist.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        cmd.CommandText = "GetCustHistoryMonthWise"
        cmd.Parameters.Clear()
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.Date).Value = stdt
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.Date).Value = eddt
        cmd.Parameters.Add("@cuscode", OleDb.OleDbType.BSTR).Value = cd.ToString
        cmd.Parameters.Add("@cigcode", OleDb.OleDbType.BigInt).Value = 15
        da.SelectCommand = cmd
        da.Fill(tab2)
        DgHist2.DataSource = tab2
        DgHist2.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        DgHist2.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgHist2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(0).DefaultCellStyle.Format = "MMM yyyy"
        DgHist2.Columns(0).HeaderText = "Month"
        DgHist2.Columns(1).DefaultCellStyle.Format = "N2"
        DgHist2.Columns(2).DefaultCellStyle.Format = "N2"
        DgHist2.Columns(3).DefaultCellStyle.Format = "N2"
        DgHist2.Columns(4).DefaultCellStyle.Format = "N2"
        DgHist2.Columns(5).DefaultCellStyle.Format = "N2"
        DgHist2.Columns(1).Width = 150
        DgHist2.Columns(2).Width = 150
        DgHist2.Columns(3).Width = 150
        DgHist2.Columns(4).Width = 150

        DgHist2.Columns(1).Visible = False
        DgHist2.Columns(2).Visible = False
        DgHist2.Columns(4).Visible = False

        DgHist2.Columns(5).Visible = False


        DgHist2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgHist2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        DgHist2.DataSource = tab2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        histno = 0
        Me.Close()
    End Sub

    Private Sub DgHist_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHist.CellDoubleClick
        Try
            histdt = DgHist.Item(1, DgHist.CurrentRow.Index).Value
            histno = DgHist.Item(2, DgHist.CurrentRow.Index).Value
            histtype = DgHist.Item(3, DgHist.CurrentRow.Index).Value
        Catch ex As Exception
            histno = 0
        End Try
        Me.Close()
    End Sub

    Private Sub DgHist_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgHist.CellContentClick

    End Sub

    Private Sub CustHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class