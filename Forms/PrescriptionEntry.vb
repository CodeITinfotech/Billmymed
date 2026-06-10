

Public Class PrescriptionEntry
    Dim obj As Object
    Dim code As Integer
    Dim adding As Boolean = False


    'Private Sub GetCardDetails(ByVal obj)
    '    Try
    '        Me.Cursor = Cursors.WaitCursor
    '        If obj.text & "" <> "" Then

    '            Dim command As New OleDb.OleDbCommand
    '            Dim reader As OleDb.OleDbDataReader
    '            Dim i As Integer = 0
    '            command.Connection = Conn
    '            command.CommandType = CommandType.Text
    '            command.CommandText = "select cardno,name,place from [CardDetails] where name like '" & obj.text & "' + '%'"
    '            reader = command.ExecuteReader
    '            dgcode.Rows.Clear()
    '            ' dgcode.Rows.Add()
    '            If reader.HasRows Then
    '                dgcode.Focus()
    '                While reader.Read
    '                    Panel1.Visible = True
    '                    dgcode.Rows.Add()
    '                    dgcode.Item(0, i).Value = reader("name")
    '                    dgcode.Item(1, i).Value = reader("cardno")
    '                    dgcode.Item(2, i).Value = reader("place")
    '                    i += 1
    '                End While
    '            Else
    '                Panel1.Visible = False
    '                'obj.focus()
    '            End If
    '            reader.Close()
    '        End If
    '    Catch er As Exception
    '        ErrorMsg(er.Message, er.StackTrace)
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub dgcode_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcode.CellDoubleClick
    '    Try
    '        code = dgcode.Item(1, dgcode.CurrentRow.Index).Value
    '        getdependentdetails(code)
    '        getdoctors()
    '        Panel1.Visible = False
    '    Catch er As Exception
    '        ErrorMsg(er.Message, er.StackTrace)
    '    End Try
    'End Sub

    Public Sub OpenForm(ByVal crd As String, ByVal pres As String)
        GetDependentDetails(crd)
        ShowPrescription(pres)
      
    End Sub



    Private Sub GetDependentDetails(ByVal code As Long)
        Dim command As New OleDb.OleDbCommand
        Dim command1 As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt, dt1 As New DataTable
        Dim ds As New DataSet

        Try
            If code = 0 Then
                'txtname.Text = ""
                cbpatient.Text = ""
                cbdoctor.Text = ""
                txtname.Text = ""
                cbcardno.Enabled = True
                cbcardno.Enabled = True
                cbpresc.DataSource = Nothing
                cbpatient.DataSource = Nothing
                dgpresc.Rows.Clear()
                Exit Sub
            End If


            'txtname.Text = ""
            command.Connection = Conn
            command1.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "select_dependent"
            command.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = code
            dgpresc.Rows.Clear()
            dgpresc.Rows.Add()
            da.SelectCommand = command
            da.Fill(ds, "dependent")
            cbpatient.DisplayMember = "Dname"
            cbpatient.ValueMember = "code"
            txtname.Tag = "Y"
            cbpatient.DataSource = ds.Tables("dependent")
            cbpatient.Text = ""
            tsbDel.Enabled = True
            tsbSave.Enabled = True
            tsbAdd.Enabled = False
            cbcardno.Text = code
            command.CommandType = CommandType.Text
            command.CommandText = "select name from carddetails where cardno=" & code & " "
            txtname.Text = command.ExecuteScalar & ""
            If ds.Tables(0).Rows.Count = 0 Then
                ' txtname.Text = ""
                cbcardno.Enabled = True
                cbcardno.Enabled = True
                cbpresc.DataSource = Nothing
                cbpatient.DataSource = Nothing
                dgpresc.Rows.Clear()
            Else
                '' txtname.Text = ds.Tables("dependent").Rows(0).Item("cname").ToString
                cbcardno.Enabled = False

                command.CommandType = CommandType.Text
                command.CommandText = "select prescname from PrescriptionEntry where cardno=" & code & " group by  prescname"

                dgpresc.Rows.Clear()
                dgpresc.Rows.Add()
                da.SelectCommand = command
                da.Fill(ds, "pres")
                cbpresc.DisplayMember = "prescname"
                cbpresc.DataSource = ds.Tables("pres")
                cbpresc.Text = ""
            End If
            txtname.Tag = ""


        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try



        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtname.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtname_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtname.MouseWheel

    End Sub

    Private Sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        If txtname.Tag = "Y" Then Exit Sub
        obj = txtname
        Panel1.Visible = False
        'gridcrtl.Visible = False
        cbcardno.Enabled = True
        cbcardno.Enabled = True
        cbpresc.DataSource = Nothing
        cbpatient.DataSource = Nothing
        cbcardno.Text = ""
        cbcardno.Enabled = True
        Populate(obj)
    End Sub
    Private Sub Populate(ByVal obj)
        Try
            Me.Cursor = Cursors.WaitCursor
            If obj.text & "" <> "" Then

                Dim command As New OleDb.OleDbCommand
                Dim reader As OleDb.OleDbDataReader
                Dim i As Integer = 0
                command.Connection = Conn
                command.CommandType = CommandType.Text
                command.CommandText = "select cardno,name,place from [CardDetails] where name like '" & obj.text & "' + '%'"
                reader = command.ExecuteReader
                dgcode.Rows.Clear()
                ' dgcode.Rows.Add()
                If reader.HasRows Then
                    dgcode.Focus()
                    While reader.Read
                        Panel1.Visible = True
                        dgcode.Rows.Add()
                        dgcode.Item(0, i).Value = reader("name")
                        dgcode.Item(1, i).Value = reader("cardno")
                        dgcode.Item(2, i).Value = reader("place")
                        i += 1
                    End While
                    dgcode.Focus()
                Else
                    Panel1.Visible = False
                    Me.Cursor = Cursors.Default
                    'obj.focus()
                    Exit Sub
                End If
                reader.Close()
                'obj.focus()
                'obj.SelectionStart = Len(obj.Text)

            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Private Sub dgcode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgcode.CellDoubleClick
    '    If Panel1.Visible = True Then
    '        'Dim command As New OleDb.OleDbCommand
    '        'Dim reader As OleDb.OleDbDataReader
    '        'command.Connection = Conn
    '        code = dgcode.Item(1, dgcode.CurrentRow.Index).Value
    '        getdependentdetails(code)
    '        Panel1.Visible = False
    '    End If
    'End Sub


    Private Sub getdoctors()
        Dim command As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            command.Connection = Conn
            command.CommandType = CommandType.Text
            command.CommandText = "select Doccode,Docname from doctor "
            da.SelectCommand = command
            da.Fill(ds, "doctor")
            cbdoctor.DisplayMember = "Docname"
            cbdoctor.ValueMember = "Doccode"
            cbdoctor.DataSource = ds.Tables("doctor")
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Card_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Show()
            'cbpresc.Items.Clear()
            cbpatient.SelectedText = Nothing
            cbdoctor.SelectedText = Nothing

            clearform()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
            'dgpresc.Rows.Add()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillCard()
        Dim cmd As New OleDb.OleDbCommand

        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "select cardno from CardDetails order by cardno "
            da.SelectCommand = cmd
            cbcardno.DisplayMember = "cardno"
            da.Fill(dt)
            cbcardno.DataSource = dt
            cbcardno.Text = ""
            txtname.Text = ""
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub grid()
        Try
            gridcrtl.Location = dgpresc.Location
            gridcrtl.Top = dgpresc.Top
            gridcrtl.Left = dgpresc.Left
            gridcrtl.Top = dgpresc.Top + dgpresc.GetRowDisplayRectangle(dgpresc.CurrentRow.Index, True).Top
            gridcrtl.Left = dgpresc.Left + dgpresc.GetColumnDisplayRectangle(dgpresc.CurrentCell.ColumnIndex, True).Left
            gridcrtl.Width = dgpresc.GetColumnDisplayRectangle(dgpresc.CurrentCell.ColumnIndex, True).Width
            gridcrtl.Text = dgpresc.CurrentCell.Value & ""
            gridcrtl.Visible = True
            gridcrtl.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub tsbadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        Try
            tsbAdd.Enabled = False
            tsbDel.Enabled = False
            tsbSave.Enabled = True
            adding = True
            cbcardno.Items.Clear()
            clearform()
            lblStatus.Text = "Adding Prescription.."
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgpresc_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpresc.CellClick

    End Sub

    Private Sub gridcrtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridcrtl.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If dgpresc.CurrentCell.ColumnIndex = 2 Then
                    Panel2.Visible = False
                    dgpresc.Item(2, dgpresc.CurrentRow.Index).Value = gridcrtl.Text
                    If dgpresc.Item(3, dgpresc.CurrentRow.Index).Value & "" = "" Then
                        dgpresc.CurrentCell = dgpresc.CurrentRow.Cells(3)
                        grid()
                        Exit Sub
                    Else
                        dgpresc.Focus()
                        gridcrtl.Visible = False
                    End If
                End If

                If dgpresc.CurrentCell.ColumnIndex = 3 Then
                    dgpresc.Item(3, dgpresc.CurrentRow.Index).Value = gridcrtl.Text
                    If dgpresc.Item(4, dgpresc.CurrentRow.Index).Value & "" = "" Then
                        dgpresc.CurrentCell = dgpresc.CurrentRow.Cells(4)
                        grid()
                        Exit Sub
                    Else
                        dgpresc.Focus()
                        gridcrtl.Visible = False
                    End If
                End If

                'If dgpresc.CurrentCell.ColumnIndex = 4 Then
                '    dgpresc.Item(4, dgpresc.CurrentRow.Index).Value = gridcrtl.Text
                '    If dgpresc.Item(5, dgpresc.CurrentRow.Index).Value & "" = "" Then
                '        dgpresc.CurrentCell = dgpresc.CurrentRow.Cells(5)
                '        grid()
                '        Exit Sub
                '    Else
                '        gridcrtl.Visible = False
                '    End If

                'End If

                If dgpresc.CurrentCell.ColumnIndex = 4 Then
                    dgpresc.Item(4, dgpresc.CurrentRow.Index).Value = gridcrtl.Text
                    'dgpresc.Rows.Add()
                    gridcrtl.Text = ""
                    dgpresc.Focus()
                    gridcrtl.Visible = False
                    If dgpresc.CurrentRow.Index = dgpresc.Rows.Count - 1 Then
                        dgpresc.Rows.Add()
                    End If

                    dgpresc.CurrentCell = dgpresc.Item(1, dgpresc.Rows.Count - 1)
                    grid()
                    Exit Sub
                End If

            End If
            'End If


            If Asc(e.KeyChar) = 27 Then
                If dgpresc.CurrentCell.ColumnIndex = 1 Then

                    Panel2.Visible = False
                    dgpresc.Focus()
                    gridcrtl.Visible = False
                    Exit Sub
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try


    End Sub

    Private Sub gridcrtl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridcrtl.LostFocus
        'gridcrtl.Visible = False
    End Sub

    Private Sub gridcrtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridcrtl.TextChanged
        ' Panel1.Visible = False
        Try
            If dgpresc.CurrentCell.ColumnIndex = 1 Then
                obj = gridcrtl
                GetMedicine(obj)

                'obj.focus()
                'obj.SelectionStart = Len(obj.Text)
                'dgmedicine.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub GetMedicine(ByVal obj)
        Try
            Me.Cursor = Cursors.WaitCursor
            If obj.Text & "" <> "" Then
                Dim command As New OleDb.OleDbCommand
                Dim reader As OleDb.OleDbDataReader
                Dim i As Integer

                command.Connection = Conn
                command.CommandType = CommandType.Text
                command.CommandText = "select prdcode,prdname,case1 from product where prdname like '" & obj.Text & "'  + '%'"
                reader = command.ExecuteReader
                dgmedicine.Rows.Clear()

                If reader.HasRows Then
                    Panel2.Visible = True
                    'dgmedicine.Focus()

                    While reader.Read
                        dgmedicine.Rows.Add()
                        dgmedicine.Item(0, i).Value = reader("prdcode")
                        dgmedicine.Item(1, i).Value = reader("prdname")
                        dgmedicine.Item(2, i).Value = reader("case1")
                        i += 1
                    End While
                    dgmedicine.Focus()
                Else
                    Panel2.Visible = False

                End If

            Else
                Panel2.Visible = False

            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        'obj.focus()
        'obj.SelectionStart = Len(obj.Text)
    End Sub

    Private Sub dgmedicine_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgmedicine.CellDoubleClick
        Try
            getmedcode()
            Panel2.Visible = False
            gridcrtl.Visible = False
            dgpresc.CurrentCell = dgpresc.CurrentRow.Cells(2)
            grid()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub getmedcode()
        Try
            dgpresc.Item(0, dgpresc.CurrentRow.Index).Value = dgmedicine.CurrentRow.Cells(0).Value
            dgpresc.Item(1, dgpresc.CurrentRow.Index).Value = dgmedicine.CurrentRow.Cells(1).Value
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub tsbsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        If cbpresc.Text = "" Then
            MessageBox.Show("Enter a prescription name")
            Exit Sub
        End If

        Dim i As Integer
        Dim command As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            command.Connection = Conn
            command.CommandType = CommandType.StoredProcedure

            'If adding = True Then

            'ElseIf adding = False Then
            '    command.CommandText = "update_prescription"
            'End If
            'MessageBox.Show(dgpresc.Rows.Count)
            ' MessageBox.Show(Val(dgpresc.Item(0, i).Value))

            If dgpresc.Rows.Count > 1 Then

                command.CommandText = "delete_prescription"
                command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(cbcardno.Text)
                command.Parameters.Add("@precname", OleDb.OleDbType.VarChar).Value = cbpresc.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                For i = 0 To dgpresc.Rows.Count - 2
                    command.CommandText = "insert_prescription"
                    command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(cbcardno.Text)
                    command.Parameters.Add("@prescname", OleDb.OleDbType.VarChar).Value = cbpresc.Text
                    command.Parameters.Add("@depcode", OleDb.OleDbType.BigInt).Value = Val(cbpatient.SelectedValue)
                    command.Parameters.Add("@medcode", OleDb.OleDbType.VarChar).Value = dgpresc.Item(0, i).Value
                    command.Parameters.Add("@docname", OleDb.OleDbType.VarChar).Value = cbdoctor.Text & ""
                    command.Parameters.Add("@qty", OleDb.OleDbType.BigInt).Value = Val(dgpresc.Item(3, i).Value)
                    command.Parameters.Add("@consepattern", OleDb.OleDbType.VarChar).Value = dgpresc.Item(2, i).Value & ""
                    command.Parameters.Add("@description", OleDb.OleDbType.VarChar).Value = dgpresc.Item(4, i).Value & ""
                    command.Parameters.Add("@patname", OleDb.OleDbType.VarChar).Value = cbpatient.Text & ""
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                Next
                clearform()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If dgpresc.Rows.Count = 1 Then
                command.CommandText = "delete_prescription"
                command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(cbcardno.Text)
                command.Parameters.Add("@precname", OleDb.OleDbType.VarChar).Value = cbpresc.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                Exit Sub
            End If
            clearform()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub dgmedicine_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgmedicine.KeyDown
        If e.KeyCode = 13 Then
            getmedcode()
            Panel2.Visible = False
            gridcrtl.Visible = False
            dgpresc.CurrentCell = dgpresc.CurrentRow.Cells(2)
            grid()
        End If
    End Sub

    Private Sub dgcode_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcode.CellDoubleClick
        Try
            code = dgcode.Item(1, dgcode.CurrentRow.Index).Value
            GetDependentDetails(code)
            getdoctors()
            Panel1.Visible = False
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    'Private Sub getdependentdetails(ByVal code As Integer)
    '    Dim command As New OleDb.OleDbCommand
    '    Dim command1 As New OleDb.OleDbCommand
    '    Dim reader As OleDb.OleDbDataReader
    '    Dim da As New OleDb.OleDbDataAdapter
    '    Dim dt As New DataTable
    '    Dim ds As New DataSet
    '    Dim j As Integer = 0
    '    Try
    '        command.Connection = Conn
    '        command1.Connection = Conn
    '        command.CommandType = CommandType.StoredProcedure
    '        command.CommandText = "select_dependent"
    '        command.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = code
    '        dgpresc.Rows.Clear()
    '        dgpresc.Rows.Add()
    '        da.SelectCommand = command
    '        da.Fill(ds, "dependent")
    '        cbpatient.DisplayMember = "Dname"
    '        cbpatient.ValueMember = "code"
    '        If ds.Tables("dependent").Rows.Count = 0 Then
    '            Exit Sub
    '        End If
    '        cbpatient.DataSource = ds.Tables("dependent")



    '        command.Parameters.Clear()

    '        command1.CommandType = CommandType.StoredProcedure
    '        command1.CommandText = "Select_Dependent"
    '        command1.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = code
    '        reader = command1.ExecuteReader

    '        If reader.HasRows Then

    '            While reader.Read
    '                'dgpresc.Rows.Add()
    '                'dgpresc.Item(0, j).Value = reader("medcode")
    '                'dgpresc.Item(1, j).Value = reader("prdname")
    '                'dgpresc.Item(2, i).Value = reader("prescname")
    '                'txtpresc.Text = reader("prescname")
    '                'MessageBox.Show(dgpresc.Rows.Count)
    '                'dgpresc.Item(2, j).Value = reader("conseppattern")
    '                'dgpresc.Item(3, j).Value = reader("qty")
    '                'dgpresc.Item(4, j).Value = reader("description")
    '                'j += 1
    '            End While
    '            reader.Close()
    '        End If
    '        command1.Parameters.Clear()

    '        tsbDel.Enabled = True
    '        tsbSave.Enabled = True
    '        tsbAdd.Enabled = False



    '        cbcardno.Text = ds.Tables("dependent").Rows(0).Item("cardno").ToString
    '        txtname.Text = ds.Tables("dependent").Rows(0).Item("cname").ToString
    '    Catch er As Exception
    '        ErrorMsg(er.Message, er.StackTrace)
    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub dgcode_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgcode.KeyDown
        Try
            If e.KeyCode = 13 Then
                code = dgcode.Item(1, dgcode.CurrentRow.Index).Value
                GetDependentDetails(code)
                getdoctors()
                Panel1.Visible = False
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub dgpresc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgpresc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                dgpresc_CellDoubleClick()
                e.Handled = True
                Exit Sub
            End If
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Want to delete the record..? ", vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then Exit Sub
                dgpresc.Rows.RemoveAt((dgpresc.CurrentRow.Index))
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub clearform()
        Dim ds As New DataSet
        Try

            dgpresc.Rows.Clear()
            cbpresc.DataSource = Nothing
            cbpresc.Text = ""
            cbcardno.Text = ""
            txtname.Text = ""
            gridcrtl.Visible = False
            'cbcardno.Items.Clear()
            cbpatient.DataSource = Nothing
            cbpatient.Text = ""
            cbdoctor.Text = ""
            dgpresc.Rows.Add()
            adding = False
            lblStatus.Text = "Select a Prescription.."
            'txtcardno.DataSource = Nothing
            FillCard()
            getdoctors()
            cbcardno.Text = ""
            cbcardno.Enabled = True
            cbpresc.DataSource = Nothing
            cbpatient.DataSource = Nothing
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub





    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        Try
            clearform()
            tsbAdd.Enabled = True
            tsbSave.Enabled = False
            tsbDel.Enabled = False
            gridcrtl.Visible = False

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        'If MsgBox("Want to 'Exit' from Product Master..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub

    Private Sub cbpresc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbpresc.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
        'If e.KeyCode = Keys.Enter Then
        '    ShowPrescription()
        'End If
    End Sub

    Private Sub ShowPrescription(Optional ByVal pres As String = "")
        If cbcardno.Text & "" <> "" Then

            Dim command As New OleDb.OleDbCommand
            Dim reader As OleDb.OleDbDataReader
            Dim i As Integer = 0
            Me.Cursor = Cursors.WaitCursor

            Try

                command.Connection = Conn
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "Select_PrescriptionName"
                command.Parameters.Add("@prescname", OleDb.OleDbType.VarChar).Value = IIf(pres = "", cbpresc.Text, pres)
                command.Parameters.Add("@cardno", OleDb.OleDbType.BigInt).Value = Val(cbcardno.Text)
                dgpresc.Rows.Clear()

                reader = command.ExecuteReader
                dgpresc.Rows.Clear()
                If reader.HasRows Then

                    While reader.Read
                        'txtpresc.Items.Add(reader("Prescname"))
                        cbpresc.Text = reader("Prescname")
                        txtname.Text = reader("name")
                        cbpatient.Text = reader("patname") & ""
                        cbdoctor.Text = reader("DocName") & ""
                        dgpresc.Rows.Add()
                        dgpresc.Item(0, i).Value = reader("medcode")
                        dgpresc.Item(1, i).Value = reader("PrdName")
                        dgpresc.Item(2, i).Value = reader("conseppattern")
                        dgpresc.Item(3, i).Value = reader("qty")
                        dgpresc.Item(4, i).Value = reader("description")
                        i += 1
                    End While
                Else
                    dgpresc.Rows.Clear()
                End If
                dgpresc.Rows.Add()
                command.Parameters.Clear()
                Panel1.Visible = False
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)
            End Try
        Else
            dgpresc.Rows.Clear()
            dgpresc.Rows.Add()
        End If

        Me.Cursor = Cursors.Default
    End Sub



    Private Sub cbpresc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbpresc.TextChanged

    End Sub

    Private Sub cbcardno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbcardno.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetDependentDetails(Val(cbcardno.Text))
        End If
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cbcardno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcardno.SelectedIndexChanged
        GetDependentDetails(Val(cbcardno.Text))
    End Sub

    Private Sub dgcode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcode.CellContentClick

    End Sub

    Private Sub dgcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgcode.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                Panel1.Visible = False : obj.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.text <> "" Then
                obj.text = Microsoft.VisualBasic.Left(Trim(obj.text), Len(obj.text) - 1)
                If obj.text = "" Then Panel1.Visible = False : obj.text = "" : obj.focus()
            Else
                obj.text = obj.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgpresc_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpresc.CellContentClick

    End Sub

    Private Sub cbpresc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbpresc.Validating
        ShowPrescription()
    End Sub

    Private Sub cbpresc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpresc.SelectedIndexChanged

    End Sub

    Private Sub cbpatient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbpatient.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cbpatient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpatient.SelectedIndexChanged

    End Sub

    Private Sub cbdoctor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbdoctor.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cbdoctor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdoctor.SelectedIndexChanged

    End Sub

    Private Sub dgmedicine_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgmedicine.CellContentClick

    End Sub

    Private Sub dgmedicine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgmedicine.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                Panel1.Visible = False : obj.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.text <> "" Then
                obj.text = Microsoft.VisualBasic.Left(Trim(obj.text), Len(obj.text) - 1)
                If obj.text = "" Then Panel1.Visible = False : obj.text = "" : obj.focus()
            Else
                obj.text = obj.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgpresc_CellDoubleClick() Handles dgpresc.CellDoubleClick
        Try
            If cbpresc.Text = "" Then

                MsgBox("Enter Prescription name.", vbInformation)
                Exit Sub

            End If

            If txtname.Text & "" <> "" Then


                If dgpresc.CurrentCell.ColumnIndex = 1 Then
                    grid()
                    Exit Sub
                End If

                'If (dgpresc.CurrentCell.ColumnIndex = 2 Or dgpresc.CurrentCell.ColumnIndex = 3 Or dgpresc.CurrentCell.ColumnIndex = 4 Or dgpresc.CurrentCell.ColumnIndex = 5) And (Panel2.Visible = False) And (dgpresc.Item(1, dgpresc.CurrentRow.Index).Value & "" <> "") Then
                '    grid()
                '    Exit Sub
                'End If
                If dgpresc.CurrentCell.ColumnIndex = 0 Then
                    'dgpresc.CurrentCell = dgpresc.Item(1, dgpresc.CurrentRow.Index)
                    'grid()
                    Exit Sub
                End If

                If dgpresc.CurrentCell.ColumnIndex = 2 Or dgpresc.CurrentCell.ColumnIndex = 3 Or dgpresc.CurrentCell.ColumnIndex = 4 Then
                    Panel2.Visible = False
                    If dgpresc.Item(1, dgpresc.CurrentRow.Index).Value & "" <> "" Then
                        If gridcrtl.Visible = True Then
                            dgpresc.Item(dgpresc.CurrentCell.ColumnIndex, dgpresc.CurrentRow.Index).Value = gridcrtl.Text
                        Else
                            grid()
                        End If

                    Else
                        dgpresc.CurrentCell = dgpresc.Item(1, dgpresc.CurrentRow.Index)
                        grid()
                    End If
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgpresc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgpresc.KeyPress

    End Sub
End Class