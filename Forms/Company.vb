Public Class Company
    Private obj As Object
    Private CompSelected As Boolean
    Private CompAdding As Boolean
    Private EditCode As Long

    Private Sub Company_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If UCase(Me.ActiveControl.Name) = "TXTCRACK" And tsbSave.Enabled Then
                    'tsbSave.Focus()
                Else
                    System.Windows.Forms.SendKeys.Send("{TAB}")
                End If
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub Company_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgSupp.ColumnHeadersVisible = True
            ClearForm()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtCName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCname.TextChanged
        Try
            If CompSelected = True Then Exit Sub
            obj = txtCname
            PopulateCompany()
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub PopulateCompany()

        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Dim serstr As String
        Try

            serstr = obj.text

            If obj.Text <> "" Then

                pcmd.Connection = Conn
                pcmd.CommandText = "Select ComCode,ComName as [Company Name],shortname as [Sname],RackNo from Company where " & obj.tag & " like """ + obj.Text + "%"""
                pda.SelectCommand = pcmd
                pda.Fill(pds, "Company")

                dgCompSer.DataSource = pds.Tables("Company")
                dgCompSer.Columns(0).Visible = False
                dgCompSer.Columns(1).Width = 250
                dgCompSer.Columns(2).Width = 70
                dgCompSer.Columns(3).Width = 60
                ' dgCompSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgCompSer.DefaultCellStyle.BackColor = Color.Navy
                'dgCompSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgCompSer.Rows.Count >= 1) Then
                    pnlComp.Visible = True
                    dgCompSer.Focus()
                    Exit Sub
                End If
            End If
            pnlComp.Visible = False
            If Not CompAdding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgCompSer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCompSer.CellEnter
        '  ShowProducts(Val(dgCompSer.Item(0, dgCompSer.CurrentCell.RowIndex).Value))
    End Sub

    Private Sub dgSuppSer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSupp.CellEnter
        ' ShowSupplier(Val(dgSupp.Item(0, dgSupp.CurrentCell.RowIndex).Value))
    End Sub

    Private Sub dgCompSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgCompSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlComp.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlComp.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub GetCompany(ByVal ccode As Long)
        Dim pcmd As New OleDb.OleDbCommand
        pcmd.Connection = Conn
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.CommandText = "Select * from Company where Comcode=" & ccode

            CompSelected = True
            Dim dataredr As OleDb.OleDbDataReader = pcmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()
                txtCname.Text = dataredr.Item("ComName")
                txtCSname.Text = dataredr.Item("ShortName") & ""
                cbRack.Text = dataredr.Item("RackNo") & ""
                tsbSave.Enabled = True
                txtCname.Focus()
                txtCname.SelectionStart = Len(txtCname.Text)
                cbSupp.SelectedValue = dataredr.Item("fsupcode")
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblStatus.Text = ""
            EditCode = ccode
            ShowProducts(ccode)
            ShowSupplier(ccode)
        Catch er As Exception

            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgCompSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgCompSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetInfo()
        End If
    End Sub
    Private Sub dgCompSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCompSer.CellDoubleClick
        GetInfo()
    End Sub

    Private Sub GetInfo()
        Try
            pnlComp.Visible = False
            If Not CompAdding Then
                GetCompany(Val(dgCompSer.Item(0, dgCompSer.CurrentCell.RowIndex).Value))
                cbRack.Focus()
            Else
                txtCname.Focus()
                txtCname.SelectionStart = Len(txtCname.Text)
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ClearForm()
        Try
            Me.Cursor = Cursors.WaitCursor
            EditCode = 0
            tsbDel.Enabled = False
            txtCname.Text = ""
            txtCSname.Text = ""
            'txtCRack.Text = ""
            CompSelected = False
            'txtCRack.Text = ""
            tsbSave.Enabled = False
            tsbAdd.Enabled = True
            txtCname.Focus()
            lblStatus.Visible = True
            CompAdding = False
            dgProd.DataSource = Nothing
            dgSupp.DataSource = Nothing

            dgProd.Columns.Clear()
            dgSupp.Columns.Clear()



            dgProd.Columns.Add("PrdCode", "PrdCode")
            dgProd.Columns.Add("PrdName", "Product Name")
            dgProd.Columns.Add("Case1", "Case1")


            dgProd.Columns(0).DataPropertyName = "PrdCode"
            dgProd.Columns(0).Visible = False
            dgProd.Columns(1).DataPropertyName = "PrdName"
            dgProd.Columns(2).DataPropertyName = "Case1"

            dgProd.Columns(1).Width = 350
            dgProd.Columns(2).Width = 100

            ' dgProd.Columns(1).DefaultCellStyle.BackColor = Color.Navy
            ' dgProd.Columns(2).DefaultCellStyle.BackColor = Color.Navy

            'dgProd.Columns(1).DefaultCellStyle.ForeColor = Color.Yellow
            ' dgProd.Columns(2).DefaultCellStyle.ForeColor = Color.Yellow


            dgSupp.Columns.Add("AcCode", "AcCode")
            dgSupp.Columns.Add("AcName", "Supplier Name")
            dgSupp.Columns.Add("Place", "Place")

            dgSupp.Columns(0).DataPropertyName = "AcCode"
            dgSupp.Columns(0).Visible = False
            dgSupp.Columns(1).DataPropertyName = "AcName"
            dgSupp.Columns(2).DataPropertyName = "Place"

            dgSupp.Columns(1).Width = 350
            dgSupp.Columns(2).Width = 100

            ' dgSupp.Columns(1).DefaultCellStyle.BackColor = Color.Navy
            '  dgSupp.Columns(2).DefaultCellStyle.BackColor = Color.Navy

            'dgSupp.Columns(1).DefaultCellStyle.ForeColor = Color.Yellow
            'dgSupp.Columns(2).DefaultCellStyle.ForeColor = Color.Yellow
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet
            cmd.Connection = Conn

            cmd.CommandText = "select Accode,Acname from Acmaster order by Acname"
            da.SelectCommand = cmd
            da.Fill(ds, "Acmaster")
            cbSupp.DisplayMember = "AcName"
            cbSupp.ValueMember = "AcCode"
            cbSupp.DataSource = ds.Tables("Acmaster")

            lblStatus.Text = "Select a  Company.."
            cbSupp.SelectedValue = 0
            cbSupp.Text = ""

            cmd.CommandText = "select code,name from racks order by name"
            da.SelectCommand = cmd
            da.Fill(ds, "rack")
            cbRack.DisplayMember = "name"
            cbRack.ValueMember = "code"
            cbRack.DataSource = ds.Tables("rack")
            cbRack.SelectedValue = 0
            cbRack.SelectedText = ""
            cbRack.Text = ""
        Catch er As Exception


            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ShowProducts(ByVal cmcode As Long)
        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.Connection = Conn
            pcmd.CommandText = "Select PrdCode,PrdName,Case1 from product where comcode=" & cmcode
            pda.SelectCommand = pcmd
            pda.Fill(pds, "Product")
            dgProd.DataSource = pds.Tables("Product")
            dgProd.Columns(0).Visible = False
        Catch er As Exception


            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowSupplier(ByVal comcode As Long)
        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.Connection = Conn
            pcmd.CommandText = "Select AcCode,AcName,Place from Acmaster,supcom where supcom.supcode=Acmaster.Accode and supcom.comcode=" & comcode
            pda.SelectCommand = pcmd
            pda.Fill(pds, "Acmaster")
            dgSupp.DataSource = pds.Tables("Acmaster")
            dgSupp.Columns(0).Visible = False
        Catch er As Exception


            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtCname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCname.GotFocus
        txtCname.SelectAll()
    End Sub

    Private Sub txtCSname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCSname.GotFocus
        txtCSname.SelectAll()
    End Sub

    'Private Sub txtCRack_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCRack.GotFocus
    '    txtCRack.SelectAll()
    'End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        ClearForm()
        tsbAdd.Enabled = False
        tsbSave.Enabled = True
        tsbClear.Enabled = True
        CompAdding = True
        'lblStatus.Visible = True
        lblStatus.Text = "Adding Company.."
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        If MsgBox("Want to delete the company : " & txtCname.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        If MsgBox("Are you sure.. Want to delete the company : " & txtCname.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        Dim cmd As New OleDb.OleDbCommand
        'cmd.CommandText = "Update Company set deleted=1 where comcode = comcode"
        'cmd.Connection = Conn
        'cmd.ExecuteNonQuery()
        tsbClear.PerformClick()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim cd As Long
        If CompAdding = False Then
            If CheckUserLocked("Edit Company") = False Then Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            If txtCname.Text = "" Then
                MsgBox("Company name is not entered..", MsgBoxStyle.Exclamation)
                txtCname.Focus()
                Exit Sub

            End If
            If txtCSname.Text = "" Then
                MsgBox("Company short name is not entered..", MsgBoxStyle.Exclamation)
                txtCname.Focus()
                Exit Sub

            End If


            cmd.Connection = Conn
            If CompAdding = False Then
                cmd.CommandText = "Update Company set comname=""" + txtCname.Text + """, shortname = """ & txtCSname.Text & """,rackno=""" & cbRack.Text & """,fsupcode=" & Val(cbSupp.SelectedValue & "") & " where Comcode = " & EditCode
            Else
                cmd.CommandText = "select max(comCode) from company "
                Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                If Not dataredr.HasRows Then
                    cd = 1
                Else
                    dataredr.Read()
                    cd = dataredr.Item(0) + 1
                End If
                dataredr.Close()
                cmd.CommandText = "Insert into Company (comcode,ComName,shortname,rackno,fsupcode) values(" & cd & _
                ",""" & txtCname.Text & """,""" & txtCSname.Text & """,""" & cbRack.Text & """," & Val(cbSupp.SelectedValue & "") & " )"

            End If
            cmd.ExecuteNonQuery()
            If CompAdding Then
                tsbClear.PerformClick()
                tsbAdd.PerformClick()
            Else
                tsbClear.PerformClick()
            End If
            tsbSave.Enabled = True
            lblStatus.Visible = True
        Catch er As Exception


            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click

        Me.Close()
    End Sub

    Private Sub tsbCls_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub cbSupp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbSupp.KeyPress
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    
    Private Sub cbSupp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSupp.SelectedIndexChanged

    End Sub

    Private Sub dgCompSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCompSer.CellContentClick

    End Sub

    Private Sub txtCSname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCSname.KeyPress
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtCSname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCSname.TextChanged

    End Sub

    'Private Sub txtCRack_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCRack.KeyPress
    '    If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{TAB}")
    'End Sub

End Class
