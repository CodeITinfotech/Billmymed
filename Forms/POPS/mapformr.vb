Option Strict Off
Option Explicit On
Friend Class mapformr
	Inherits System.Windows.Forms.Form
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
        On Error GoTo errmsg
        Dim scmd As New SqlClient.SqlCommand
        Dim cmd As New OleDb.OleDbCommand
        Dim prcode As String

        scmd.Connection = PopsConn
        If txtcode.Text = "" Then
            MsgBox("Select a product...")
            Exit Sub
        End If

        If CheckPOPSConnection() = False Then
            MsgBox("Can't connect POPS Server...")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        prcode = lblprod.Tag
        scmd.CommandType = CommandType.StoredProcedure
        scmd.CommandText = "ProductMap"
        scmd.Parameters.Add("@rclientid", SqlDbType.VarChar).Value = ClientId
        scmd.Parameters.Add("@wclientid", SqlDbType.VarChar).Value = Me.Tag
        scmd.Parameters.Add("@rpcode", SqlDbType.VarChar).Value = prcode
        scmd.Parameters.Add("@wpcode", SqlDbType.VarChar).Value = txtcode.Text
        scmd.ExecuteNonQuery()

        'scmd.CommandText = "delete from prodmap where rclientid='" & ClientId & "' and rprodcode='" & prcode & "' and wclientid = '" & Me.Tag & "' "
        'scmd.ExecuteNonQuery()
        'scmd.CommandText = "delete from prodmap where rprodcode='" & prcode & "'and rclientid='" & ClientId & "' and wclientid = '" & Me.Tag & "'"
        'scmd.ExecuteNonQuery()
        'scmd.CommandText = "insert into prodmap (rprodcode,rclientid,wclientid,wprodcode) values ('" & prcode & "','" & ClientId & "','" & Me.Tag & "','" & txtcode.Text & "')"


        txtname.Focus()
        If Me.Command1.Tag <> "Trans" Then

        Else
            txtcode.Tag = txtcode.Text
            txtcode.Text = ""
            txtname.Text = ""
        End If
        Me.Command1.Tag = ""

        Me.Close()
        Exit Sub
errmsg:
        MsgBox(Err.Description)

    End Sub

    '	Public Sub getdata(ByRef dat As String, ByRef pr As String, ByRef prnm As String, ByRef fr As String)
    '		Dim free1 As Object
    '		Dim qty1 As Object
    '		Dim qt As Object
    '		Dim cmbmapwprod As Object
    '		Dim cmps1 As Object
    '		Dim cmps As Object
    '        On Error GoTo errmsg

    '        Dim rswprod As OleDb.OleDbDataReader
    '        Dim rsprod As OleDb.OleDbDataReader

    '        rswprod.Open("select prodcode,prodname + ' ' + pkg as [View]  from products where clientid = '" & dat & "'  order by prodname + ' ' + pkg", SConn)

    '        cmbmapwprod.DataSource = rswprod
    ' 		cmbmapwprod.RowSource = rswprod

    '        cmbmapwprod.Text = ""
    '        qty1 = qt
    '        free1 = fr
    '		Exit Sub
    'errmsg: 
    '		ErrorMsg(Err.Description & Chr(13) & Err.Source)

    '	End Sub


    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        If Me.Command1.Tag <> "Trans" Then

        Else
            Upload.Tag = ""
        End If
        Me.Close()
    End Sub
	
   
	
	
	
	Public Sub Populate(ByRef fld As String)
		Dim SQL As Object
        Dim da As New SqlClient.SqlDataAdapter
        Dim scmd As New SqlClient.SqlCommand
        Dim tconn As New OleDb.OleDbConnection
        Dim tb As New DataTable

        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        scmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        scmd.ExecuteNonQuery()
		On Error GoTo errmsg
        If fld = "Code" Then
            SQL = "SELECT prodCode,prodName,pkg as [Pack]  FROM Products WHERE  clientid='" & Me.Tag & "' and  prodCode  like """ & txtcode.Text & "%""    order by prodCode"
        Else
            SQL = "SELECT prodCode,prodName,pkg as [Pack] FROM products WHERE clientid='" & Me.Tag & "' and prodName like """ & txtname.Text & "%""    order by prodName,pkg"
        End If
        scmd.CommandText = SQL
        da.SelectCommand = scmd
        da.Fill(tb)

        Prodgrid.DataSource = tb

        If tb.Rows.Count > 0 Then
            Prodgrid.Visible = True
            Prodgrid.Focus()
            Exit Sub
        End If
        Prodgrid.Visible = False
        txtname.Focus()
        txtname.SelectionStart = Len(txtname.Text)
        PopsConn.Close()
        Exit Sub
errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)
        'ErrorMsg(Err.Description & Chr(13) & Err.Source)
		
	End Sub
	
	Private Sub txtname_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtname.TextChanged
        Dim ctrl As Object
        On Error GoTo errmsg
        If txtname.Tag = "Y" Then txtname.Tag = "" : Exit Sub

        If txtname.Text = "" Then
            Prodgrid.Visible = False
        Else
            ctrl = "Name"
            Populate(("Name"))
        End If
        Exit Sub
errmsg:
        'ErrorMsg(Err.Description & Chr(13) & Err.Source)

    End Sub
	
	Private Sub txtname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If Chr(KeyAscii) = "[" Or KeyAscii = 34 Then KeyAscii = 0
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		If KeyAscii = 27 Then Prodgrid.Visible = False
		If KeyAscii = 13 Then System.Windows.Forms.SendKeys.Send("{tab}")
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

    Private Sub Prodgrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Prodgrid.CellContentClick

    End Sub

    Private Sub Prodgrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Prodgrid.CellDoubleClick

        txtcode.Tag = "Y"
        txtname.Tag = "Y"
        txtcode.Text = Prodgrid.Item(0, Prodgrid.CurrentCell.RowIndex).Value   ' .get_TextMatrix(Prodgrid.Row, 0) & ""
        txtname.Text = Prodgrid.Item(1, Prodgrid.CurrentCell.RowIndex).Value & " " & Prodgrid.Item(2, Prodgrid.CurrentCell.RowIndex).Value
        Prodgrid.Visible = False
    End Sub

    Private Sub Prodgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Prodgrid.KeyPress
        ' Dim Serstr As String
        ' Asci value of ????? is 34
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            'Asci value of Tab is 9
            If Asc(e.KeyChar) = 9 Then Exit Sub

            'Asci value of Enter is 13
            If Asc(e.KeyChar) = 13 Then Exit Sub

            'Asci value of Escape is  27
            If Asc(e.KeyChar) = 27 Then
                Prodgrid.Visible = False : txtname.Text = "" : txtname.Focus() : Exit Sub
            End If

            ' Asci value of Backspace is 8
            If Asc(e.KeyChar) = 8 And txtname.Text <> "" Then
                txtname.Text = Microsoft.VisualBasic.Left(Trim(txtname.Text), Len(txtname.Text) - 1)
                If txtname.Text = "" Then Prodgrid.Visible = False : txtname.Text = "" : txtname.Focus()
            Else
                txtname.Text = txtname.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            'ErrorMsg(er.Message)

        End Try
    End Sub

    Private Sub Prodgrid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Prodgrid.Leave

    End Sub

    Private Sub Prodgrid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Prodgrid.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                txtcode.Tag = "Y"
                txtname.Tag = "Y"
                txtcode.Text = Prodgrid.Item(0, Prodgrid.CurrentCell.RowIndex).Value   ' .get_TextMatrix(Prodgrid.Row, 0) & ""
                txtname.Text = Prodgrid.Item(1, Prodgrid.CurrentCell.RowIndex).Value & " " & Prodgrid.Item(2, Prodgrid.CurrentCell.RowIndex).Value
                txtcode.Tag = ""
                txtname.Tag = ""
                Prodgrid.Visible = False
            End If
        Catch er As Exception
            ' ErrorMsg(er.Message)

        End Try
    End Sub

    Private Sub mapformr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtname.Focus()
        Catch ex As Exception

        End Try

    End Sub
End Class