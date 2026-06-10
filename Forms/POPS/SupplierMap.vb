Option Strict Off
Option Explicit On
Friend Class mapsupplier
	Inherits System.Windows.Forms.Form
	
    Private Sub cmbretsup_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo errmsg
        Dim rs As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        cmd.Connection = PopsConn
        cmd.CommandText = "select wclientid from supmap where rclientid='" & ClientId & "' and rsupcode='" & cmbretsup.SelectedValue & "'" 
        rs = cmd.ExecuteReader

        If rs.HasRows Then
            rs.Read()
            cmbwebsup.SelectedValue = Val(rs("wclientid") & "")
        Else
            'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            cmbwebsup.SelectedValue = 0
        End If
        rs.Close()
        PopsConn.Close()
        Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)

    End Sub
	
	Private Sub com_save_Click()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		On Error GoTo errmsg
		
        If Val(cmbretsup.SelectedValue & "") = 0 Then
            MsgBox("Select a Supplier...")
            cmbretsup.Focus()
            Exit Sub
        End If
		
        If cmbwebsup.SelectedValue & "" = "" Then
            MsgBox("Select a Web Supplier...")
            cmbwebsup.Focus()
            Exit Sub
        End If
		
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        scmd.Connection = PopsConn
        scmd.CommandText = "delete  from supmap where rclientid='" & ClientId & "' and rsupcode='" & cmbretsup.SelectedValue & "'"
        scmd.ExecuteNonQuery()
        scmd.CommandText = "delete from supmap where rclientid='" & ClientId & "' and wclientid='" & cmbwebsup.SelectedValue & "'"
        scmd.ExecuteNonQuery()
        scmd.CommandText = "insert into supmap (rclientid,wclientid,rsupcode) values ('" & ClientId & "','" & cmbwebsup.SelectedValue & "'," & cmbretsup.SelectedValue & ")"
        scmd.ExecuteNonQuery()

		GetRec()
		'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        cmbretsup.Text = ""
		'UPGRADE_NOTE: Text was upgraded to CtlText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        cmbwebsup.Text = ""
        PopsConn.Close()
        Me.Cursor = Cursors.Default
		Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        PopsConn.Close()
        MsgBox(Err.Description)

	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        On Error GoTo errmsg
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        scmd.Connection = PopsConn

        scmd.CommandText = "delete  from supmap where rclientid='" & ClientId & "' and rsupcode='" & cmbretsup.SelectedValue & "'"
        scmd.ExecuteNonQuery()

        scmd.CommandText = "delete from supmap where rclientid='" & ClientId & "' and wclientid='" & cmbwebsup.SelectedValue & "'"
        scmd.ExecuteNonQuery()
        cmbretsup.SelectedValue = 0
        cmbretsup.Text = ""
        cmbwebsup.SelectedValue = 0
        cmbwebsup.Text = ""
		
        GetRec()
        PopsConn.Close()
        Me.Cursor = Cursors.Default
		Exit Sub
errmsg:
        Me.Cursor = Cursors.Default
        PopsConn.Close()
        MsgBox(Err.Description)
		
	End Sub
	
	Private Sub mapsupplier_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error GoTo errmsg
        Dim ds As New DataSet
        Dim da As New OleDb.OleDbDataAdapter
        Dim da1 As New SqlClient.SqlDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim scmd As New SqlClient.SqlCommand

        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        cmd.Connection = Conn
        scmd.Connection = PopsConn

        cmd.CommandText = "select accode,acname + ' ' + PLACE AS [VIEW] from acmaster  where grpcode =" & SupGrpcode & " order by acname   + ' ' + PLACE"
        scmd.CommandText = "select id,name + ' ' + place  as [view] from users where type = 'W' order by name + ' ' + place "

        da.SelectCommand = cmd
        da.Fill(ds, "Supp")

        da1.SelectCommand = scmd
        da1.Fill(ds, "WSupp")

        cmbwebsup.DisplayMember = "View"
        cmbwebsup.ValueMember = "id"
        cmbwebsup.DataSource = ds.Tables("wsupp")

        cmbretsup.DisplayMember = "View"
        cmbretsup.ValueMember = "accode"
        cmbretsup.DataSource = ds.Tables("supp")

        ' cmbretsup.SelectedValue = 0
        'cmbretsup.Text = ""
        'cmbwebsup.SelectedValue = 0
        'cmbwebsup.Text = ""
        GetRec()
        PopsConn.Close()
		Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)
	End Sub
	
	Private Sub mapsupplier_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Hide()
	End Sub
	
	Private Sub GetRec()
		Dim rname As Object
		Dim wname As Object
		On Error GoTo errmsg
        Dim srs As SqlClient.SqlDataReader
        Dim rs As SqlClient.SqlDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim scmd As New SqlClient.SqlCommand
        Dim scmd1 As New SqlClient.SqlCommand
        Dim dt As New DataTable
        Dim da As New SqlClient.SqlDataAdapter
        cmd.Connection = Conn
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        scmd1.Connection = PopsConn

        grd.Rows.Clear()
        scmd.CommandText = "select wclientid,rsupcode from supmap where rclientid = '" & ClientId & "'"
        da.SelectCommand = scmd
        da.Fill(dt)

        For i = 0 To dt.Rows.Count - 1
            grd.Rows.Add()
            scmd1.CommandText = "select name + ' ' + place from users where id='" & dt.Rows(i).Item("wclientid") & "'"
            wname = scmd1.ExecuteScalar

            cmd.CommandText = "select acname + ' ' + place from acmaster where accode=" & dt.Rows(i).Item("rsupcode")
            rname = cmd.ExecuteScalar

            grd.Item(0, grd.Rows.Count - 1).Value = dt.Rows(i).Item("rsupcode")
            grd.Item(1, grd.Rows.Count - 1).Value = rname
            grd.Item(2, grd.Rows.Count - 1).Value = wname
            grd.Item(3, grd.Rows.Count - 1).Value = dt.Rows(i).Item("wclientid")
        Next

        ' srs.Close()
        PopsConn.Close()
        Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)

    End Sub
	
  
	
   

    Private Sub grd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellDoubleClick
        On Error GoTo errmsg
        cmbretsup.SelectedValue = grd.Item(0, grd.CurrentCell.RowIndex).Value
        cmbwebsup.SelectedValue = grd.Item(3, grd.CurrentCell.RowIndex).Value
        Exit Sub
errmsg:
        MsgBox(Err.Description)
    End Sub

    Private Sub grd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd.KeyDown
        On Error GoTo errmsg
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default

            Exit Sub
        End If
        scmd.Connection = PopsConn
        If e.KeyCode = Keys.Delete Then
            scmd.CommandText = "delete  from supmap where rclientid='" & ClientId & "' and rsupcode='" & grd.Item(0, grd.CurrentCell.RowIndex).Value & "'"
            scmd.ExecuteNonQuery()
            GetRec()
        End If
        PopsConn.Close()
        Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)

    End Sub

    Private Sub cmbretsup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbretsup.SelectedIndexChanged

    End Sub

    Private Sub mapsupp_frame_Enter(sender As System.Object, e As System.EventArgs) Handles mapsupp_frame.Enter

    End Sub
End Class