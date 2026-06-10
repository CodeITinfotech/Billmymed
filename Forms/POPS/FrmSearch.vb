Option Strict Off
Option Explicit On
Friend Class FrmSearch
	Inherits System.Windows.Forms.Form
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        Dim da As New SqlClient.SqlDataAdapter
        Dim tb As New DataTable
        Dim scmd As New SqlClient.SqlCommand
        If txt.Text = "" Then Exit Sub
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        scmd.CommandText = "SELECT products.prodname as [Product Name],Pkg as [Pack],rate as Rate ,Sch as [Scheme],MRP,Users.name as [Distributor], " & _
            " Users.place as [Place],company.name AS [Company]    FROM company INNER JOIN products ON company.cmpcode = products.cmpcode " & " AND company.clientid = products.clientid INNER JOIN Users ON " & "products.clientid = Users.id where " & _
            "ISNULL(POPSSTATE,'GOA')='GOA' and  products.prodname like """ & txt.Text & "%""   order by products.prodname"
        da.SelectCommand =scmd
        da.Fill(tb)

        grd.DataSource = tb
        Me.Cursor = Cursors.Default
        PopsConn.Close()
		
	End Sub

    Private Sub FrmSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub grd_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick

    End Sub
End Class