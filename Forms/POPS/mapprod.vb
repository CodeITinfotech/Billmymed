Option Strict Off
Option Explicit On
Friend Class mapprod
	Inherits System.Windows.Forms.Form
	
   
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        On Error GoTo errmsg
        Dim scmd As New SqlClient.SqlCommand
		If cmbwebprod.Text ="" Then
			MsgBox("Select a Web product...")
			Exit Sub
		End If
		
        If cmbprod.Text = "" Then
            MsgBox("Select a product...")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        scmd.Connection = PopsConn
        scmd.CommandText = "delete  from prodmap where rclientid='" & ClientId & "' and rprodcode='" & cmbprod.SelectedValue & "'"
        scmd.ExecuteNonQuery()
        scmd.CommandText = "delete from prodmap where wprodcode='" & cmbwebprod.SelectedValue & "' and rclientid='" & ClientId & "'"
        scmd.ExecuteNonQuery()
        'scmd.CommandText = "insert into prodmap (rclientid,rprodcode,wclientid,wprodcode) values ('" & ClientId & "','" & cmbprod.SelectedValue & "','" & cmbwebsup.SelectedValue & "', '" & cmbwebprod.SelectedValue & "')"
        ' scmd.ExecuteNonQuery()
        GetRec1()
        cmbprod.Text = ""
        cmbwebprod.Text = ""
        Me.Cursor = Cursors.Default
		Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        MsgBox(Err.Description)
		
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		On Error GoTo errmsg
        If cmbprod.Text = "" Then
            MsgBox("Select a product...")
            Exit Sub
        End If
        Dim scmd As New SqlClient.SqlCommand
        scmd.Connection = PopsConn
        Me.Cursor = Cursors.WaitCursor

        If cmbwebprod.Text <> "" Then
            scmd.CommandText = "delete  from prodmap where rclientid='" & ClientId & "' and rprodcode='" & cmbprod.SelectedValue & "' and wclientid='" & _
                cmbwebsup.SelectedValue & "'"
            scmd.ExecuteNonQuery()
        Else
            scmd.CommandText = "delete  from prodmap where rclientid='" & ClientId & "' and rprodcode='" & cmbprod.SelectedValue & "'"
            scmd.ExecuteNonQuery()
        End If

        cmbprod.Text = ""
        cmbwebprod.Text = ""
        GetRec1()
        Me.Cursor = Cursors.Default
        Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        MsgBox(Err.Description)

    End Sub
	
	Private Sub mapprod_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error GoTo errmsg
        Dim prod As OleDb.OleDbDataReader
        Dim websup As OleDb.OleDbDataReader
        Dim scmd As New SqlClient.SqlCommand
        Dim cmd As New OleDb.OleDbCommand
        Dim tbp As New DataTable
        Dim tbs As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim da1 As New SqlClient.SqlDataAdapter

        cmd.Connection = Conn
        scmd.Connection = PopsConn

        cmd.CommandText = "select   prdCode,prdName + ' ' + case1 as [view] from Product order by prdName"
        da.SelectCommand = cmd
        da.Fill(tbp)



        cmbprod.ValueMember = "prdcode"
        cmbprod.DisplayMember = "view"
        cmbprod.DataSource = tbp

        scmd.CommandText = "select id,name + ' ' + place  as [view]  from users where type = 'W' order by name + ' ' + place"
        da1.SelectCommand = scmd
        da1.Fill(tbs)



        cmbwebsup.ValueMember = "id"
        cmbwebsup.DisplayMember = "view"

        cmbwebsup.DataSource = tbs

        'cmbwebsup.Text = ""
        'cmbwebsup.SelectedValue = 0
        'cmbprod.SelectedValue = 0
        'cmbprod.Text = ""
		
		Exit Sub
errmsg: 
        MsgBox(Err.Description)
		
	End Sub
	
	Private Sub mapprod_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Hide()
	End Sub
	
	Private Sub GetRec1()
		Dim rname As Object
		Dim pname As Object
		Dim SQL As Object
        Dim rsgrd As SqlClient.SqlDataReader
        Dim rs As OleDb.OleDbDataReader

        Dim scmd As New SqlClient.SqlCommand
        Dim cmd As New OleDb.OleDbCommand
		On Error GoTo errmsg
        scmd.Connection = PopsConn
        cmd.Connection = Conn
        grd1.Rows.Clear()
        Me.Cursor = Cursors.WaitCursor
        scmd.CommandText = "SELECT prodmap.rprodcode, prodmap.rclientid,prodmap.wprodcode, products.prodname + ' ' + pkg as [view], products.pkg " & "FROM products INNER JOIN prodmap ON products.clientid = prodmap.wclientid AND products.prodcode = prodmap.wprodcode " & " WHERE (products.cmpcode = '" & cmbcmp.SelectedValue & "') AND (prodmap.wclientid = '" & cmbwebsup.SelectedValue & "') and rclientid='" & ClientId & "'"
        rsgrd = scmd.ExecuteReader

        While rsgrd.Read
            pname = rsgrd("View")
            cmd.CommandText = "select  prdname + ' ' + case1  as [view]  from product where prdcode= '" & rsgrd("rprodcode") & "' "
            rs = cmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                rname = rs(0)
                grd1.Rows.Add()
                grd1.Item(0, grd1.Rows.Count - 1).Value = rsgrd("rprodcode")
                grd1.Item(1, grd1.Rows.Count - 1).Value = rname
                grd1.Item(2, grd1.Rows.Count - 1).Value = pname
                grd1.Item(3, grd1.Rows.Count - 1).Value = rsgrd("wprodcode")
                grd1.Item(4, grd1.Rows.Count - 1).Value = rsgrd("rclientid")
            End If
            rs.Close()

        End While
 
        rsgrd.Close()
        Me.Cursor = Cursors.Default
		Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        MsgBox(Err.Description)
		
	End Sub
	
    Private Sub grd1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd1.CellDoubleClick
        cmbprod.SelectedValue = grd1.Item(0, grd1.CurrentRow.Index).Value
        cmbwebprod.SelectedValue = grd1.Item(3, grd1.CurrentRow.Index).Value
    End Sub

    Private Sub grd1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd1.KeyDown
        On Error GoTo errmsg
        Dim scmd As New SqlClient.SqlCommand
        scmd.Connection = PopsConn
        If e.KeyCode = Keys.Delete Then
            scmd.CommandText = "delete  from prodmap where rclientid='" & ClientId & "' and rprodcode='" & grd1.Item(0, grd1.CurrentCell.RowIndex).Value & "'"
            GetRec1()
        End If
        Exit Sub
errmsg:
        MsgBox(Err.Description)

    End Sub

    Private Sub cmbprod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.SelectedIndexChanged

    End Sub

    Private Sub cmbcmp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcmp.SelectedIndexChanged
        GetRec1()
    End Sub

    Private Sub cmbwebsup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbwebsup.SelectedIndexChanged
        Dim X As Object
        If cmbwebsup.Text = "" Then Exit Sub
        On Error GoTo errmsg

        Dim scmd1 As New SqlClient.SqlCommand
        Dim scmd As New SqlClient.SqlCommand
        Dim tbwp As New DataTable
        Dim tbc As New DataTable
        Dim da As New SqlClient.SqlDataAdapter

        scmd.Connection = PopsConn
        scmd1.Connection = PopsConn
        scmd.CommandTimeout = 600
        scmd.CommandText = "select prodcode,prodname + ' ' + pkg as [view] from products where clientid='" & cmbwebsup.SelectedValue & "' order by prodname + ' ' + pkg "

        da.SelectCommand = scmd
        tbwp.Rows.Clear()
        da.Fill(tbwp)

        cmbwebprod.ValueMember = "prodcode"
        cmbwebprod.DisplayMember = "view"
        cmbwebprod.DataSource = tbwp

        cmbwebprod.SelectedValue = ""
        cmbwebprod.Text = ""

        scmd.CommandText = "select cmpcode,name from company where clientid = '" & cmbwebsup.SelectedValue & "' order by name"
        tbc.Rows.Clear()
        da.Fill(tbc)
        cmbcmp.ValueMember = "cmpcode"
        cmbcmp.DisplayMember = "name"
        cmbcmp.DataSource = tbc
        cmbcmp.SelectedValue = ""
        cmbcmp.Text = ""
        Exit Sub
errmsg:
        MsgBox(Err.Description)
    End Sub

    Private Sub grd1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd1.CellContentClick

    End Sub

    Private Sub Frame1_Enter(sender As System.Object, e As System.EventArgs) Handles Frame1.Enter

    End Sub
End Class