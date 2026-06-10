Option Strict Off
Option Explicit On
Friend Class FrmBillSearch
    Inherits System.Windows.Forms.Form
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        SearchBill()

    End Sub

    Private Sub SearchBill()

        Dim da As New SqlClient.SqlDataAdapter
        Dim tb As New DataTable
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        scmd.CommandText = "SELECT DISTINCT RelySoft.trans.rclientid, RelySoft.trans.wclientid, case RelySoft.trans.processed WHEN 'p'  then 1 else 0 end as 'Downloaded',  RelySoft.trans.billno, RelySoft.trans.billdt, RelySoft.Users.name as [Supplier], RelySoft.Users.place FROM RelySoft.trans INNER JOIN " & _
                " RelySoft.Users ON RelySoft.trans.wclientid = RelySoft.Users.id WHERE RelySoft.trans.rclientid =""" & DeScriptRS(Firm.POPSClientID) & """ and RelySoft.trans.billno LIKE ""%" & txt.Text & "%"" ORDER by BILLDT,BILLNO "
        '   scmd.CommandText = "SELECT products.prodname as [Product Name], products.pkg as [Pack],Users.name as [Distributor], Users.place as [Place],company.name AS [Company] " & " FROM company INNER JOIN products ON company.cmpcode = products.cmpcode " & "AND company.clientid = products.clientid INNER JOIN Users ON " & "products.clientid = Users.id where products.prodname like """ & txt.Text & "%""   order by products.prodname"
        da.SelectCommand = scmd
        da.Fill(tb)

        grd.DataSource = tb
        Me.Cursor = Cursors.Default
        PopsConn.Close()

    End Sub

    Private Sub grd_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick

    End Sub

    Private Sub grd_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellEnter
        If grd.CurrentRow Is Nothing Then Exit Sub
        BtnUnmark.Visible = (grd.CurrentRow.Cells("Downloaded").Value = 1)


    End Sub

    Private Sub BtnUnmark_Click(sender As System.Object, e As System.EventArgs) Handles BtnUnmark.Click
        If grd.CurrentRow Is Nothing Then Exit Sub
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        scmd.CommandText = "update RelySoft.trans set relySoft.trans.processed='' " & _
            " WHERE RelySoft.trans.rclientid =""" & DeScriptRS(Firm.POPSClientID) & _
            """ and RelySoft.trans.billno =""" & grd.CurrentRow.Cells("billno").Value & _
            """ and billdt=convert(datetime,'" & grd.CurrentRow.Cells("billdt").Value & _
            "',103) and wclientid=""" & grd.CurrentRow.Cells("wclientid").Value & """"
        scmd.ExecuteNonQuery()

        Me.Cursor = Cursors.Default
        SearchBill()
        PopsConn.Close()

    End Sub

    Private Sub txt_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt.TextChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If grd.CurrentRow Is Nothing Then Exit Sub
        Dim scmd As New SqlClient.SqlCommand
        If MsgBox("Want to delete the selected bill from Server ?", vbYesNo + vbDefaultButton2) = MsgBoxResult.No Then
            Exit Sub
        End If
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        scmd.CommandText = "delete RelySoft.trans  " & _
            " WHERE RelySoft.trans.rclientid =""" & DeScriptRS(Firm.POPSClientID) & _
            """ and RelySoft.trans.billno =""" & grd.CurrentRow.Cells("billno").Value & _
            """ and billdt=convert(datetime,'" & grd.CurrentRow.Cells("billdt").Value & _
            "',103) and wclientid=""" & grd.CurrentRow.Cells("wclientid").Value & """"
        scmd.ExecuteNonQuery()

        Me.Cursor = Cursors.Default
        SearchBill()
        PopsConn.Close()
    End Sub
End Class