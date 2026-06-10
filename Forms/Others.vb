Public Class Others
    Private obj As Object
    Private ClassSelected As Boolean
    Private Grp1Selected As Boolean
    Private Grp2Selected As Boolean

    Private GenSelected As Boolean
    Private DocSelected As Boolean
    Private PatSelected As Boolean
    Private SalSelected As Boolean
    Private RackSelected As Boolean
    Private SchedSelected As Boolean
    Private EditCode As String
    'Private ClassAdding As Boolean
    'Private GenAdding As Boolean
    'Private DocAdding As Boolean
    'Private PatAdding As Boolean
    'Private SalAdding As Boolean
    Private Adding As Boolean

    Private Sub Others_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.Wheat
        ToolStrip.Renderer = renderer
        If CheckUserLocked("Edit SalesMan", True) = False Then tabctrl.TabPages.Remove(tabctrl.TabPages("tbSals"))

    End Sub

    Private Sub Others_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If UCase(Me.ActiveControl.Name) = "txtGNam" And tsbSave.Enabled Then
                'tsbSave.Focus()
            ElseIf Me.ActiveControl.Name = rt.Name Then

            Else

                System.Windows.Forms.SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    ''c''
    Private Sub txtCNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCNam.TextChanged
        If ClassSelected = True Then Exit Sub
        obj = txtCNam
        PopulateClassification()
    End Sub
    ''g''
    Private Sub txtGNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGNam.TextChanged
        If GenSelected = True Then Exit Sub
        obj = txtGNam
        PopulateGeneric()
    End Sub
    ''d''
    Private Sub txtDNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNam.TextChanged
        If DocSelected = True Then Exit Sub
        obj = txtDNam
        PopulateDoctor()
    End Sub

    ''p''
    Private Sub txtPNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPNam.TextChanged
        If PatSelected = True Then Exit Sub
        obj = txtPNam
        PopulatePatient()
    End Sub

    ''s''
    Private Sub txtSNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSNam.TextChanged
        If SalSelected = True Then Exit Sub
        obj = txtSNam
        PopulateSalesman()
    End Sub

    ''c''
    Private Sub PopulateClassification()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select ClsCode as [Code],ClsName as [Name] from Classification where " & obj.tag & " like """ + obj.Text + "%"" order by ClsName"
                da.SelectCommand = cmd
                da.Fill(ds, "Classification")
                dgClassSer.DataSource = ds.Tables("Classification")
                dgClassSer.Columns(0).Visible = False
                dgClassSer.Columns(1).Width = 299
                'dgClassSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgClassSer.DefaultCellStyle.BackColor = Color.Navy
                'dgClassSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet
                If (dgClassSer.Rows.Count >= 1) Then
                    pnlCNam.Visible = True
                    dgClassSer.Focus()
                    Exit Sub
                End If
            End If
            pnlCNam.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub
    ''g''


    ''c''
    Private Sub PopulateGroup1()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select PrGrp1Code as [Code],PrGrp1Name as [Name] from PrGroup1 where " & obj.tag & " like """ + obj.Text + "%"" order by PrGrp1Name"
                da.SelectCommand = cmd
                da.Fill(ds, "PrGrp1")
                dgGrp1Ser.DataSource = ds.Tables("PrGrp1")
                dgGrp1Ser.Columns(0).Visible = False
                dgGrp1Ser.Columns(1).Width = 299
                'dgClassSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgClassSer.DefaultCellStyle.BackColor = Color.Navy
                'dgClassSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet
                If (dgGrp1Ser.Rows.Count >= 1) Then
                    PnlGrp1.Visible = True
                    dgGrp1Ser.Focus()
                    Exit Sub
                End If
            End If
            PnlGrp1.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    Private Sub PopulateRacks()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select Code as [Code],name as [Rack No] from RackS where " & obj.tag & " like """ + obj.Text + "%"" order by Name"
                da.SelectCommand = cmd
                da.Fill(ds, "racks")
                DgRackSer.DataSource = ds.Tables("racks")
                DgRackSer.Columns(0).Visible = False
                DgRackSer.Columns(1).Width = 299
                'dgClassSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgClassSer.DefaultCellStyle.BackColor = Color.Navy
                'dgClassSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet
                If (DgRackSer.Rows.Count >= 1) Then
                    Pnlracks.Visible = True
                    DgRackSer.Focus()
                    Exit Sub
                End If
            End If
            Pnlracks.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    Private Sub PopulateSched()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select Code as [Code],name as [Schedule] from schedule where " & obj.tag & " like """ + obj.Text + "%"" order by Name"
                da.SelectCommand = cmd
                da.Fill(ds, "Sched")
                DgSchSer.DataSource = ds.Tables("Sched")
                DgSchSer.Columns(0).Visible = False
                DgSchSer.Columns(1).Width = 299
                'dgClassSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgClassSer.DefaultCellStyle.BackColor = Color.Navy
                'dgClassSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet
                If (DgSchSer.Rows.Count >= 1) Then
                    pnlsch.Visible = True
                    DgSchSer.Focus()
                    Exit Sub
                End If
            End If
            pnlsch.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    Private Sub PopulateGroup2()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text
            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select PrGrp2Code as [Code],PrGrp2Name as [Name] from PrGroup2 where " & obj.tag & " like """ + obj.Text + "%"" order by PrGrp2Name "
                da.SelectCommand = cmd
                da.Fill(ds, "PrGrp2")
                DgGrp2Ser.DataSource = ds.Tables("PrGrp2")
                DgGrp2Ser.Columns(0).Visible = False
                DgGrp2Ser.Columns(1).Width = 299
                'dgClassSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgClassSer.DefaultCellStyle.BackColor = Color.Navy
                'dgClassSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet
                If (DgGrp2Ser.Rows.Count >= 1) Then
                    PnlGrp2.Visible = True
                    DgGrp2Ser.Focus()
                    Exit Sub
                End If
            End If
            PnlGrp2.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    Private Sub PopulateGeneric()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select GenCode as [Code],GenName as [Name] from Generic where " & obj.tag & " like """ + obj.Text + "%"" order by GenName"
                da.SelectCommand = cmd
                da.Fill(ds, "Generic")
                dgGenSer.DataSource = ds.Tables("Generic")
                dgGenSer.Columns(0).Visible = False
                dgGenSer.Columns(1).Width = 299
                'dgGenSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgGenSer.DefaultCellStyle.BackColor = Color.Navy
                'dgGenSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgGenSer.Rows.Count >= 1) Then
                    pnlGNam.Visible = True

                    dgGenSer.Focus()
                    Exit Sub
                End If
            End If
            pnlGNam.Visible = False
            'If Not GenAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    ''d''
    Private Sub PopulateDoctor()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select DocCode as [Code],DocName as [Name] from Doctor where " & obj.tag & " like """ + obj.Text + "%"" order by DocName "
                da.SelectCommand = cmd
                da.Fill(ds, "Doctor")
                dgDocSer.DataSource = ds.Tables("Doctor")
                dgDocSer.Columns(0).Visible = False
                dgDocSer.Columns(1).Width = 337
                'dgDocSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgDocSer.DefaultCellStyle.BackColor = Color.Navy
                'dgDocSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgDocSer.Rows.Count >= 1) Then
                    pnlDNam.Visible = True
                    dgDocSer.Focus()
                    Exit Sub
                End If
            End If
            pnlDNam.Visible = False
            'If Not DocAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    ''p''
    Private Sub PopulatePatient()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select PatCode as[Code],PatName as [Name]  from Patient where " & obj.tag & " like '" + obj.Text + "%'"
                da.SelectCommand = cmd
                da.Fill(ds, "Patient")
                dgPatSer.DataSource = ds.Tables("Patient")
                dgPatSer.Columns(0).Visible = False
                dgPatSer.Columns(1).Width = 354
                ' dgPatSer.DefaultCellStyle.ForeColor = Color.Yellow
                ' dgPatSer.DefaultCellStyle.BackColor = Color.Navy
                'dgPatSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgPatSer.Rows.Count >= 1) Then
                    pnlPNam.Visible = True
                    dgPatSer.Focus()
                    Exit Sub
                End If
            End If
            pnlPNam.Visible = False
            ' If Not PatAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    ''s''
    Private Sub PopulateSalesman()

        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim serstr As String
        Try
            serstr = obj.text

            If obj.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "Select SalCode as [Code],SalName as [Name]  from Salesman where " & obj.tag & " like """ + obj.Text + "%"""
                da.SelectCommand = cmd
                da.Fill(ds, "Salesman")
                dgSalSer.DataSource = ds.Tables("Salesman")
                dgSalSer.Columns(0).Visible = False
                dgSalSer.Columns(1).Width = 352
                'dgSalSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgSalSer.DefaultCellStyle.BackColor = Color.Navy
                'dgSalSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgSalSer.Rows.Count >= 1) Then
                    pnlSNam.Visible = True
                    dgSalSer.Focus()
                    Exit Sub
                End If
            End If
            pnlSNam.Visible = False
            'If Not SalAdding Then
            If Not Adding Then
                obj.Text = ""
            Else
                obj.focus()
                obj.SelectionStart = Len(obj.Text)
            End If
            obj.Focus()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    ''c''
    Private Sub dgClassSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgClassSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlCNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlCNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    ''g''
    Private Sub dgGenSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgGenSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlGNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlGNam.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub

    ''d''
    Private Sub dgDocSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDocSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlDNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlDNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    '' p''
    Private Sub dgPatSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgPatSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlPNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlPNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    '' s''
    Private Sub dgSalSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSalSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlSNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlSNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    ''c''
    Private Sub dgClassSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgClassSer.CellDoubleClick
        GetClassInfo()
    End Sub

    Private Sub dgGrp1Ser_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGrp1Ser.CellDoubleClick
        GetGrp1Info()
    End Sub

    Private Sub dgGrp2Ser_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgGrp2Ser.CellDoubleClick
        GetGrp2Info()
    End Sub
    ''c''
    Private Sub dgClassSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgClassSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetClassInfo()
        End If
    End Sub
    ''c''
    Private Sub GetClassInfo()
        Try
            pnlCNam.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                GetClassification(dgClassSer.Item(0, dgClassSer.CurrentCell.RowIndex).Value)
            Else
                txtCNam.Focus()
                txtCNam.SelectionStart = Len(txtCNam.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub GetGrp1Info()
        Try
            PnlGrp1.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                GetGrp1(dgGrp1Ser.Item(0, dgGrp1Ser.CurrentCell.RowIndex).Value)
            Else
                txtgrp1name.Focus()
                txtgrp1name.SelectionStart = Len(txtgrp1name.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub GetGrp2Info()
        Try
            PnlGrp2.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                GetGrp2(DgGrp2Ser.Item(0, DgGrp2Ser.CurrentCell.RowIndex).Value)
            Else
                txtgrp2name.Focus()
                txtgrp2name.SelectionStart = Len(txtgrp2name.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub


    Private Sub GetRackInfo()
        Try
            Pnlracks.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                GetRack(DgRackSer.Item(0, DgRackSer.CurrentCell.RowIndex).Value)
            Else
                txtrackno.Focus()
                txtrackno.SelectionStart = Len(txtrackno.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub GetSchedInfo()
        Try
            pnlsch.Visible = False
            'If Not ClassAdding Then
            If Not Adding Then
                GetSched(DgSchSer.Item(0, DgSchSer.CurrentCell.RowIndex).Value & "")
            Else
                txtsch.Focus()
                txtsch.SelectionStart = Len(txtsch.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    ''g''
    Private Sub dgGenSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGenSer.CellDoubleClick
        GetGenInfo()
    End Sub
    ''g''
    Private Sub dgGenSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgGenSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetGenInfo()
        End If
    End Sub
    ''g''
    Private Sub GetGenInfo()
        pnlGNam.Visible = False
        Try
            'If Not GenAdding Then
            If Not Adding Then
                GetGeneric(dgGenSer.Item(0, dgGenSer.CurrentCell.RowIndex).Value)
            Else
                txtGNam.Focus()
                txtGNam.SelectionStart = Len(txtGNam.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    ''d''
    Private Sub dgDocSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDocSer.CellDoubleClick
        GetDocInfo()
    End Sub
    ''d''
    Private Sub dgDocSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgDocSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetDocInfo()
        End If
    End Sub
    ''d''
    Private Sub GetDocInfo()
        Try
            pnlDNam.Visible = False
            'If Not DocAdding Then
            If Not Adding Then
                GetDoctor(dgDocSer.Item(0, dgDocSer.CurrentCell.RowIndex).Value)
            Else
                txtDNam.Focus()
                txtDNam.SelectionStart = Len(txtDNam.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    ''p''
    Private Sub dgPatSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPatSer.CellDoubleClick
        GetPatInfo()
    End Sub
    ''p''
    Private Sub GetPatInfo()
        Try
            pnlPNam.Visible = False
            'If Not PatAdding Then
            If Not Adding Then
                GetPatient(dgPatSer.Item(0, dgPatSer.CurrentCell.RowIndex).Value)
            Else
                txtPNam.Focus()
                txtPNam.SelectionStart = Len(txtPNam.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub
    ''p''
    Private Sub dgPatSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgPatSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetPatInfo()
        End If
    End Sub
    ''s''
    Private Sub dgsalSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSalSer.CellDoubleClick
        GetSalInfo()
    End Sub
    ''s''
    Private Sub dgsalSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgSalSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetSalInfo()
        End If
    End Sub
    ''s''
    Private Sub GetSalInfo()
        pnlSNam.Visible = False
        'If Not SalAdding Then
        If Not Adding Then
            GetSalesman(dgSalSer.Item(0, dgSalSer.CurrentCell.RowIndex).Value)
        Else
            txtSNam.Focus()
            txtSNam.SelectionStart = Len(txtSNam.Text)
        End If
    End Sub

    ''c''
    Private Sub GetClassification(ByVal ClsCode As String)
        Dim cmd As New OleDb.OleDbCommand

        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from Classification where ClsCode='" + ClsCode + "' "
            ClassSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtCNam.Text = dataredr.Item("Clsname")

                tsbSave.Enabled = True
                txtCNam.Focus()
                txtCNam.SelectionStart = Len(txtCNam.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductC(ClsCode)
            lblClass.Text = ""
            EditCode = ClsCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub GetGrp1(ByVal GrpCode As String)
        Dim cmd As New OleDb.OleDbCommand

        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from PrGroup1 where PrGrp1code='" + GrpCode + "' "
            Grp1Selected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtgrp1name.Text = dataredr.Item("PrGrp1Name")

                tsbSave.Enabled = True
                txtgrp1name.Focus()
                txtgrp1name.SelectionStart = Len(txtgrp1name.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductGrp1(GrpCode)
            LblGrp1.Text = ""
            EditCode = GrpCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetSched(ByVal GrpCode As String)
        Dim cmd As New OleDb.OleDbCommand

        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from schedule where code='" + GrpCode + "' "
            SchedSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtsch.Text = dataredr.Item("name")

                tsbSave.Enabled = True
                txtsch.Focus()
                txtsch.SelectionStart = Len(txtsch.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductSched(GrpCode)
            lblsch.Text = ""
            EditCode = GrpCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetRack(ByVal GrpCode As String)
        Dim cmd As New OleDb.OleDbCommand

        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from racks where code='" + GrpCode + "' "
            RackSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtrackno.Text = dataredr.Item("name")

                tsbSave.Enabled = True
                txtrackno.Focus()
                txtrackno.SelectionStart = Len(txtrackno.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductRack(GrpCode)
            lblrack.Text = ""
            EditCode = GrpCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetGrp2(ByVal GrpCode As String)
        Dim cmd As New OleDb.OleDbCommand

        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from PrGroup2 where PrGrp2code='" + GrpCode + "' "
            Grp2Selected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtgrp2name.Text = dataredr.Item("PrGrp2Name")

                tsbSave.Enabled = True
                txtgrp2name.Focus()
                txtgrp2name.SelectionStart = Len(txtgrp2name.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductGrp2(GrpCode)
            LblGrp2.Text = ""
            EditCode = GrpCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    ''g''
    Private Sub GetGeneric(ByVal GenCode As String)
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try


            cmd.Connection = Conn
            cmd.CommandText = "Select * from Generic where GenCode='" + GenCode + "' "
            GenSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtGNam.Text = dataredr.Item("Genname")
                RT.Rtf = dataredr.Item("Gen") & ""
                tsbSave.Enabled = True
                txtGNam.Focus()
                txtGNam.SelectionStart = Len(txtGNam.Text)

            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            ShowProductG(GenCode)
            lblGen.Text = ""
            EditCode = GenCode

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    ''d''
    Private Sub GetDoctor(ByVal DocCode As String)
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn

            cmd.CommandText = "Select * from Doctor where DocCode='" + DocCode + "' "
            DocSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtDNam.Text = dataredr.Item("Docname")
                txtSpec.Text = dataredr.Item("Spec")
                txtDAdr1.Text = dataredr.Item("Adr1") & ""
                txtDAdr2.Text = dataredr.Item("Adr2") & ""
                txtDAdr3.Text = dataredr.Item("Adr3") & ""
                txtDPlac.Text = dataredr.Item("Place") & ""
                txtDPh.Text = dataredr.Item("Ph") & ""
                txtDEmail.Text = dataredr.Item("Email") & ""
                'Temp.Text = dataredr.Item("Docname")
                tsbSave.Enabled = True
                txtDNam.Focus()
                txtDNam.SelectionStart = Len(txtDNam.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblDoc.Text = ""
            EditCode = DocCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    ''p''
    Private Sub GetPatient(ByVal PatCode As String)
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            cmd.CommandText = "Select * from Patient where PatCode='" + PatCode + "' "
            PatSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtPNam.Text = dataredr.Item("PatName")
                txtPAdr1.Text = dataredr.Item("Adr1") & ""
                txtPAdr2.Text = dataredr.Item("Adr2") & ""
                txtPAdr3.Text = dataredr.Item("Adr3") & ""
                txtPPlac.Text = dataredr.Item("Place") & ""
                txtPPh.Text = dataredr.Item("Ph") & ""
                txtPEmail.Text = dataredr.Item("Email") & ""

                tsbSave.Enabled = True
                txtPNam.Focus()
                txtPNam.SelectionStart = Len(txtPNam.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblPat.Text = ""
            EditCode = PatCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    ''s''
    Private Sub GetSalesman(ByVal SalCode As String)
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn

            cmd.CommandText = "Select * from Salesman where SalCode='" + SalCode + "' "
            SalSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtSNam.Text = dataredr.Item("SalName")
                txtSAdr.Text = dataredr.Item("Adr") & ""
                txtSPh.Text = dataredr.Item("Ph") & ""
                txtPass.Text = dataredr.Item("Password") & ""
                'Temp.Text = dataredr.Item("Name")
                tsbSave.Enabled = True
                txtSNam.Focus()
                txtSNam.SelectionStart = Len(txtSNam.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblSal.Text = ""
            EditCode = SalCode
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ClearForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            'EditCode = 0
            pnlProd1.Visible = False
            lblProd1.Visible = False
            lblProd2.Visible = False
            pnlProd2.Visible = False
            pnlprodsch.Visible = False
            lblprod3.Visible = False
            pnlprod3.Visible = False
            lblprod4.Visible = False
            pnlprod4.Visible = False
            lblprod5.Visible = False
            pnlprod5.Visible = False
            pnlsch.Visible = False
            tsbDel.Enabled = False
            txtgrp1name.Text = ""
            txtgrp2name.Text = ""
            RT.Rtf = ""
            txtCNam.Text = ""
            txtGNam.Text = ""
            txtDNam.Text = ""
            txtSpec.Text = ""
            txtDAdr1.Text = ""
            txtDAdr2.Text = ""
            txtDAdr3.Text = ""
            txtDPlac.Text = ""
            txtDPh.Text = ""
            txtDEmail.Text = ""
            txtrackno.Text = ""
            txtsch.Text = ""
            txtPNam.Text = ""
            txtPAdr1.Text = ""
            txtPAdr2.Text = ""
            txtPAdr3.Text = ""
            txtPPlac.Text = ""
            txtPPh.Text = ""
            txtPEmail.Text = ""


            txtSNam.Text = ""
            txtSAdr.Text = ""
            txtSPh.Text = ""
            txtPass.Text = ""
            SchedSelected = False
            RackSelected = False
            ClassSelected = False
            Grp1Selected = False
            Grp2Selected = False

            GenSelected = False
            DocSelected = False
            PatSelected = False
            SalSelected = False

            tsbSave.Enabled = False
            tsbAdd.Enabled = True

            txtgrp1name.Focus()
            txtgrp2name.Focus()
            txtCNam.Focus()
            txtGNam.Focus()
            txtDNam.Focus()
            txtPNam.Focus()
            txtSNam.Focus()
            Adding = False
            'ClassAdding = False
            'GenAdding = False
            'DocAdding = False
            'PatAdding = False
            'SalAdding = False

            dgGProd.DataSource = Nothing
            dgGProd.Columns.Clear()

            dgGProd.Columns.Add("PrdCode", "PrdCode")
            dgGProd.Columns.Add("PrdName", "Product Name")
            dgGProd.Columns.Add("Case1", "Case1")

            dgGProd.Columns(0).DataPropertyName = "PrdCode"
            dgGProd.Columns(0).Visible = False
            dgGProd.Columns(1).DataPropertyName = "PrdName"
            dgGProd.Columns(2).DataPropertyName = "Case1"

            dgGProd.Columns(1).Width = 300
            dgGProd.Columns(2).Width = 55

            dgCProd.DataSource = Nothing
            dgCProd.Columns.Clear()

            dgCProd.Columns.Add("PrdCode", "PrdCode")
            dgCProd.Columns.Add("PrdName", "Product Name")
            dgCProd.Columns.Add("Case1", "Case1")

            dgCProd.Columns(0).DataPropertyName = "PrdCode"
            dgCProd.Columns(0).Visible = False
            dgCProd.Columns(1).DataPropertyName = "PrdName"
            dgCProd.Columns(2).DataPropertyName = "Case1"

            dgCProd.Columns(1).Width = 300
            dgCProd.Columns(2).Width = 55


            dggrp1prod.DataSource = Nothing
            dggrp1prod.Columns.Clear()

            dggrp1prod.Columns.Add("PrdCode", "PrdCode")
            dggrp1prod.Columns.Add("PrdName", "Product Name")
            dggrp1prod.Columns.Add("Case1", "Case1")

            dggrp1prod.Columns(0).DataPropertyName = "PrdCode"
            dggrp1prod.Columns(0).Visible = False
            dggrp1prod.Columns(1).DataPropertyName = "PrdName"
            dggrp1prod.Columns(2).DataPropertyName = "Case1"

            dggrp1prod.Columns(1).Width = 300
            dggrp1prod.Columns(2).Width = 55

            DgGrp2prod.DataSource = Nothing
            DgGrp2prod.Columns.Clear()

            DgGrp2prod.Columns.Add("PrdCode", "PrdCode")
            DgGrp2prod.Columns.Add("PrdName", "Product Name")
            DgGrp2prod.Columns.Add("Case1", "Case1")

            DgGrp2prod.Columns(0).DataPropertyName = "PrdCode"
            DgGrp2prod.Columns(0).Visible = False
            DgGrp2prod.Columns(1).DataPropertyName = "PrdName"
            DgGrp2prod.Columns(2).DataPropertyName = "Case1"

            DgGrp2prod.Columns(1).Width = 300
            DgGrp2prod.Columns(2).Width = 55

            DgRackProd.DataSource = Nothing
            DgRackProd.Columns.Clear()

            DgRackProd.Columns.Add("PrdCode", "PrdCode")
            DgRackProd.Columns.Add("PrdName", "Product Name")
            DgRackProd.Columns.Add("Case1", "Case1")

            DgRackProd.Columns(0).DataPropertyName = "PrdCode"
            DgRackProd.Columns(0).Visible = False
            DgRackProd.Columns(1).DataPropertyName = "PrdName"
            DgRackProd.Columns(2).DataPropertyName = "Case1"

            DgRackProd.Columns(1).Width = 300
            DgRackProd.Columns(2).Width = 55

            DgSchProd.DataSource = Nothing
            DgSchProd.Columns.Clear()

            DgSchProd.Columns.Add("PrdCode", "PrdCode")
            DgSchProd.Columns.Add("PrdName", "Product Name")
            DgSchProd.Columns.Add("Case1", "Case1")

            DgSchProd.Columns(0).DataPropertyName = "PrdCode"
            DgSchProd.Columns(0).Visible = False
            DgSchProd.Columns(1).DataPropertyName = "PrdName"
            DgSchProd.Columns(2).DataPropertyName = "Case1"

            DgSchProd.Columns(1).Width = 300
            DgSchProd.Columns(2).Width = 55

            'dgCProd.Columns(1).DefaultCellStyle.BackColor = Color.Navy
            'dgCProd.Columns(2).DefaultCellStyle.BackColor = Color.Navy

            'dgCProd.Columns(1).DefaultCellStyle.ForeColor = Color.Yellow
            'dgCProd.Columns(2).DefaultCellStyle.ForeColor = Color.Yellow

            lblGen.Text = "Select Generic.."
            lblClass.Text = "Select Classification.."
            lblDoc.Text = "Select a Doctor.."
            lblSal.Text = "Select a Salesman.."
            lblPat.Text = "Select a Patient.."
            LblGrp1.Text = "Select a Group 1 Name.."
            LblGrp2.Text = "Select a Group 2 Name.."
            lblsch.Text = "Select a Schedule.."
            lblrack.Text = "Select a Rack No.."
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    ''c''
    Private Sub txtCNam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNam.GotFocus
        txtCNam.SelectAll()
    End Sub
    ''g''
    Private Sub txtGNam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGNam.GotFocus
        txtGNam.SelectAll()
    End Sub
    ''d''
    Private Sub txtDNam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDNam.GotFocus
        txtDNam.SelectAll()
    End Sub
    ''d''
    Private Sub txtSpec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpec.GotFocus
        txtSpec.SelectAll()
    End Sub
    ''d''
    Private Sub txtDAdr1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDAdr1.GotFocus
        txtDAdr1.SelectAll()
    End Sub
    ''d''
    Private Sub txtDAdr2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDAdr2.GotFocus
        txtDAdr2.SelectAll()
    End Sub
    ''d''
    Private Sub txtDAdr3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDAdr3.GotFocus
        txtDAdr3.SelectAll()
    End Sub
    ''d''
    Private Sub txtDPlac_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPlac.GotFocus
        txtDPlac.SelectAll()
    End Sub
    ''d''
    Private Sub txtDPh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPh.GotFocus
        txtDPh.SelectAll()
    End Sub
    ''d''
    Private Sub txtDEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEmail.GotFocus
        txtDEmail.SelectAll()
    End Sub
    ''p''
    Private Sub txtpNam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPNam.GotFocus
        txtPNam.SelectAll()
    End Sub
    ''p''
    Private Sub txtSAdr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSAdr.GotFocus
        txtSAdr.SelectAll()
    End Sub
    ''p''
    Private Sub txtSPh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSPh.GotFocus
        txtSPh.SelectAll()
    End Sub
    ''p''
    Private Sub txtPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPass.GotFocus
        txtPass.SelectAll()
    End Sub
    ''s''
    Private Sub txtsNam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSNam.GotFocus
        txtSNam.SelectAll()
    End Sub
    ''s''
    Private Sub txtPAdr1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPAdr1.GotFocus
        txtPAdr1.SelectAll()
    End Sub
    ''s''
    Private Sub txtPAdr2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPAdr2.GotFocus
        txtPAdr2.SelectAll()
    End Sub
    ''s''
    Private Sub txtPAdr3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPAdr3.GotFocus
        txtPAdr3.SelectAll()
    End Sub
    ''s''
    Private Sub txtPPlac_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPlac.GotFocus
        txtPPlac.SelectAll()
    End Sub
    ''s''
    Private Sub txtPPh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPh.GotFocus
        txtPPh.SelectAll()
    End Sub
    ''s''
    Private Sub txtPEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPEmail.GotFocus
        txtPEmail.SelectAll()
    End Sub

    Private Sub ShowProductG(ByVal editCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Try
            cmd.Connection = Conn
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock] from product where  (Product.GenCode1=" & _
                    editCode & " or  Product.GenCode2=" & editCode & " or  Product.GenCode3=" & editCode & " or  Product.GenCode4=" & editCode & " or  Product.GenCode5=" & editCode & ")  Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            dgGProd.DataSource = ds.Tables("Product")
            dgGProd.Columns(0).Visible = False
            dgGProd.Columns(1).Width = 250
            dgGProd.Columns(2).Width = 60
            dgGProd.Columns(3).Width = 100
            'dgGProd.Columns(4).Visible = False
            'dgGProd.Columns(5).Visible = False
            pnlProd1.Visible = True
            lblProd1.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub ShowProductC(ByVal EditCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            'cmd.CommandText = "Select PrdCode,Prdname,Case1,ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode"
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock],Product.ClsCode,Classification.ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode and Classification.ClsCode=" & EditCode & " Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            dgCProd.DataSource = ds.Tables("Product")
            dgCProd.Columns(0).Visible = False
            dgCProd.Columns(1).Width = 250
            dgCProd.Columns(2).Width = 100
            dgCProd.Columns(3).Width = 100
            dgCProd.Columns(4).Visible = False
            dgCProd.Columns(5).Visible = False
            pnlProd2.Visible = True
            lblProd2.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ShowProductGrp1(ByVal EditCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            'cmd.CommandText = "Select PrdCode,Prdname,Case1,ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode"
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock],Product.PrGrp1Code,PrGroup1.PrGrp1Code from product,PrGroup1 where PrGroup1.PrGrp1Code=Product.prGrp1Code and PrGroup1.PrGrp1Code=" & EditCode & " Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            dggrp1prod.DataSource = ds.Tables("Product")
            dggrp1prod.Columns(0).Visible = False
            dggrp1prod.Columns(1).Width = 250
            dggrp1prod.Columns(2).Width = 100
            dggrp1prod.Columns(3).Width = 100
            dggrp1prod.Columns(4).Visible = False
            dggrp1prod.Columns(5).Visible = False
            lblprod4.Visible = True
            pnlprod4.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ShowProductGrp2(ByVal EditCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            'cmd.CommandText = "Select PrdCode,Prdname,Case1,ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode"
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock],Product.PrGrp2Code,PrGroup2.PrGrp2Code from product,PrGroup2 where PrGroup2.PrGrp2Code=Product.prGrp2Code and PrGroup2.PrGrp2Code=" & EditCode & " Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            DgGrp2prod.DataSource = ds.Tables("Product")
            DgGrp2prod.Columns(0).Visible = False
            DgGrp2prod.Columns(1).Width = 250
            DgGrp2prod.Columns(2).Width = 100
            DgGrp2prod.Columns(3).Width = 100
            DgGrp2prod.Columns(4).Visible = False
            DgGrp2prod.Columns(5).Visible = False
            lblprod3.Visible = True
            pnlprod3.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowProductRack(ByVal EditCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            'cmd.CommandText = "Select PrdCode,Prdname,Case1,ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode"
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock],Product.PrGrp2Code,PrGroup2.PrGrp2Code from product,PrGroup2 where product.rackno=""" & txtrackno.Text & """ Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            DgRackProd.DataSource = ds.Tables("Product")
            DgRackProd.Columns(0).Visible = False
            DgRackProd.Columns(1).Width = 250
            DgRackProd.Columns(2).Width = 100
            DgRackProd.Columns(3).Width = 100
            DgRackProd.Columns(4).Visible = False
            DgRackProd.Columns(5).Visible = False
            lblprod5.Visible = True
            pnlprod5.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowProductSched(ByVal EditCode As Long)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            cmd.Connection = Conn
            'cmd.CommandText = "Select PrdCode,Prdname,Case1,ClsCode from product,Classification where Classification.ClsCode=Product.ClsCode"
            cmd.CommandText = " Select Product.PrdCode,Product.Prdname,Product.Case1, (select sum(stock) from batch where batch.prdcode=product.prdcode) as [Stock],Product.PrGrp2Code,PrGroup2.PrGrp2Code from product,PrGroup2 where product.sched=""" & txtsch.Text & """ Order by Product.PrdName "
            da.SelectCommand = cmd
            da.Fill(ds, "Product")

            DgSchProd.DataSource = ds.Tables("Product")
            DgSchProd.Columns(0).Visible = False
            DgSchProd.Columns(1).Width = 250
            DgSchProd.Columns(2).Width = 100
            DgSchProd.Columns(3).Width = 100
            DgSchProd.Columns(4).Visible = False
            DgSchProd.Columns(5).Visible = False
            lblsch.Visible = True
            Label5.Visible = False
            pnlprodsch.Visible = True

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        ClearForm()
        tsbAdd.Enabled = False
        tsbSave.Enabled = True
        tsbClear.Enabled = True
        Adding = True
        'ClassAdding = True
        'GenAdding = True
        'DocAdding = True
        'PatAdding = True
        'SalAdding = True
        lblGen.Text = "Adding Generic.."
        lblClass.Text = "Adding Classification.."
        lblDoc.Text = "Adding a Doctor.."
        lblSal.Text = "Adding a Salesman.."
        lblPat.Text = "Adding a Patient.."
        LblGrp1.Text = "Adding a Group 1 Name.."
        LblGrp2.Text = "Adding a Group 2 Name.."
        lblsch.Text = "Adding a Schedule"

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Me.Cursor = Cursors.WaitCursor
        Try

            If Adding = False Then
                If txtGNam.Text <> "" And GenSelected = True Then
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "UpdateGeneric" '"Update Generic set GenName=""" + txtGNam.Text + """,gen=""" & rt.Rtf & """ where GenCode = " &  cmd.Parameters.Add("@code", OleDb.OleDbType.BigInt)
                    cmd.Parameters.Add("@code", OleDb.OleDbType.BigInt).Value = Val(EditCode)
                    cmd.Parameters.Add("@name", OleDb.OleDbType.VarChar).Value = txtGNam.Text
                    cmd.Parameters.Add("@gen", OleDb.OleDbType.VarChar).Value = rt.Rtf
                    cmd.ExecuteNonQuery()
                End If


                If txtCNam.Text <> "" And ClassSelected = True Then
                    cmd.CommandText = "Update Classification set ClsName=""" + txtCNam.Text + """ where ClsCode = " & EditCode
                    cmd.ExecuteNonQuery()
                End If

                If txtgrp1name.Text <> "" And Grp1Selected = True Then
                    cmd.CommandText = "Update PrGroup1 set PrGrp1Name=""" + txtgrp1name.Text + """ where PrGrp1Code = " & EditCode
                    cmd.ExecuteNonQuery()
                End If

                If txtgrp2name.Text <> "" And Grp2Selected = True Then
                    cmd.CommandText = "Update PrGroup2 set PrGrp1Name=""" + txtgrp2name.Text + """ where PrGrp2Code = " & EditCode
                    cmd.ExecuteNonQuery()
                End If


                If txtDNam.Text <> "" And DocSelected = True Then
                    cmd.CommandText = "Update Doctor set DocName = """ + txtDNam.Text + """,Spec = """ & txtSpec.Text & _
                    """,adr1 = """ & txtDAdr1.Text & """,adr2 = """ & txtDAdr2.Text & _
                    """,adr3 = """ & txtDAdr3.Text & """,Place = """ & txtDPlac.Text & _
                    """,Ph = """ & txtDPh.Text & """,Email = """ & txtDEmail.Text & _
                    """ where DocCode = " & EditCode
                    cmd.ExecuteNonQuery()
                End If


                If txtSNam.Text <> "" And SalSelected = True Then
                    cmd.CommandText = "Update Salesman set SalName = """ + txtSNam.Text + """,adr = """ & txtSAdr.Text & _
                    """,Ph = """ & txtSPh.Text & """,Password = """ & txtPass.Text & _
                    """ where SalCode = " & EditCode
                    cmd.ExecuteNonQuery()
                End If


                If txtPNam.Text <> "" And PatSelected = True Then
                    cmd.CommandText = "Update Patient set PatName = """ + txtPNam.Text + """,adr1 = """ & txtPAdr1.Text & _
                    """,adr2 = """ & txtPAdr2.Text & """,adr3 = """ & txtPAdr3.Text & _
                    """,Place = """ & txtPPlac.Text & """,Ph = """ & txtPPh.Text & _
                    """,Email = """ & txtPEmail.Text & """ where Patcode = " & EditCode
                    cmd.ExecuteNonQuery()
                End If


                If txtrackno.Text <> "" And RackSelected = True Then
                    cmd.CommandText = "Update racks set Name = """ + txtrackno.Text + """  where code = " & EditCode
                    cmd.ExecuteNonQuery()
                End If

                If txtsch.Text <> "" And SchedSelected = True Then
                    cmd.CommandText = "Update schedule set Name = """ + txtsch.Text + """  where code = " & EditCode
                    cmd.ExecuteNonQuery()
                End If

            Else

                Select Case Val(tabctrl.SelectedTab.Tag)
                    Case 0
                        If txtGNam.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If
                        cmd.CommandText = "select max(GenCode) From Generic"

                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = dataredr.Item(0) + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into Generic(GenCode,GenName,gen)values (" & EditCode & ",""" & txtGNam.Text & """,""" & rt.Rtf & """)"
                    Case 1
                        If txtCNam.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If
                        cmd.CommandText = "select max(ClsCode) From Classification"

                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = dataredr.Item(0) + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into Classification(ClsCode,ClsName)values (" & EditCode & ",""" & txtCNam.Text & """)"

                    Case 2

                        If txtDNam.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If

                        cmd.CommandText = "select max(DocCode) From doctor"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = Val(dataredr.Item(0) & "") + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into Doctor(DocCode,DocName,Spec,Adr1,Adr2,Adr3,Place,Ph,Email)values (" & EditCode & ",""" & txtDNam.Text & _
                                  """,""" & txtSpec.Text & """,""" & txtDAdr1.Text & """,""" & txtDAdr2.Text & """,""" & txtDAdr3.Text & _
                                     """,""" & txtDPlac.Text & """,""" & txtDPh.Text & """,""" & txtDEmail.Text & """)"

                    Case 3

                        If txtSNam.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If
                        cmd.CommandText = "select max(SalCode) From salesman"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = Val(dataredr.Item(0) & "") + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into Salesman(SalCode,SalName,Adr,Ph,Password)values (" & EditCode & ",""" & txtSNam.Text & _
                                       """,""" & txtSAdr.Text & """,""" & txtSPh.Text & """,""" & txtPass.Text & """)"

                    Case 4

                        If txtPNam.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If

                        cmd.CommandText = "select max(PatCode) From Patient"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = Val(dataredr.Item(0) & "") + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into Patient(PatCode,PatName,Adr1,Adr2,Adr3,Place,Ph,Email)values (" & EditCode & ",""" & txtPNam.Text & _
                                """,""" & txtPAdr1.Text & """,""" & txtPAdr2.Text & """,""" & txtPAdr3.Text & _
                                """,""" & txtPPlac.Text & """,""" & txtPPh.Text & """,""" & txtPEmail.Text & """)"
                    Case 5

                        If txtgrp1name.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If


                        cmd.CommandText = "select max(PrGrp1Code) From PrGroup1"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = dataredr.Item(0) + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into PrGroup1(Prgrp1Code,Prgrp1Name)values (" & EditCode & ",""" & txtgrp1name.Text & """)"
                    Case 6


                        If txtgrp2name.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If

                        cmd.CommandText = "select max(PrGrp2Code) From PrGroup2"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = dataredr.Item(0) + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into PrGroup2(Prgrp2Code,Prgrp2Name)values (" & EditCode & ",""" & txtgrp2name.Text & """)"
                    Case 7

                        If txtrackno.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If

                        cmd.CommandText = "select max(Code) From racks"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = Val(dataredr.Item(0) & "") + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into RACKS(Code,Name) values (" & EditCode & ",""" & txtrackno.Text & """)"

                    Case 8
                        If txtsch.Text = "" Then
                            MsgBox("Name is Blank")
                            Exit Sub
                        End If

                        cmd.CommandText = "select max(Code) From schedule"
                        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If Not dataredr.HasRows Then
                            EditCode = 1
                        Else
                            dataredr.Read()
                            EditCode = Val(dataredr.Item(0) & "") + 1
                        End If
                        dataredr.Close()
                        cmd.CommandText = "Insert into schedule(Code,Name) values (" & EditCode & ",""" & txtsch.Text & """)"
                End Select
                cmd.ExecuteNonQuery()
            End If


            If Adding Then
                tsbClear.PerformClick()
                tsbAdd.PerformClick()
            Else
                tsbClear.PerformClick()
            End If
            tsbSave.Enabled = True
            lblGen.Visible = True
            lblClass.Visible = True
            lblDoc.Visible = True
            lblSal.Visible = True
            lblPat.Visible = True

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        'If MsgBox("Want to 'Exit' from Others ..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub

    Private Sub txtgrp1name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrp1name.TextChanged
        If Grp1Selected = True Then Exit Sub
        obj = txtgrp1name
        PopulateGroup1()
    End Sub

    Private Sub txtgrp2name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrp2name.TextChanged
        If Grp2Selected = True Then Exit Sub
        obj = txtgrp2name
        PopulateGroup2()
    End Sub

    Private Sub dgGrp1Ser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgGrp1Ser.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlCNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlCNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

    End Sub



    Private Sub dgGrp2Ser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgGrp2Ser.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlCNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlCNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub dgGrp1Ser_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgGrp1Ser.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetGrp1Info()
        End If
    End Sub

    Private Sub dgGrp2Ser_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgGrp2Ser.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetGrp2Info()
        End If
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn

        If GenSelected = True Then
            cmd.CommandText = "DELETE  Generic Where GenCode = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If ClassSelected = True Then
            cmd.CommandText = "DELETE Classification   where ClsCode = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If Grp1Selected = True Then
            cmd.CommandText = "DELETE PrGroup1 where PrGrp1Code = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If Grp2Selected = True Then
            cmd.CommandText = "DELETE PrGroup2   where PrGrp2Code = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If txtDNam.Text <> "" And DocSelected = True Then
            cmd.CommandText = "DELETE Doctor where DocCode = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If SalSelected = True Then
            cmd.CommandText = "DELETE Salesman where SalCode = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If PatSelected = True Then
            cmd.CommandText = "DELETE Patient  where Patcode = " & EditCode
            cmd.ExecuteNonQuery()
        End If

        If RackSelected = True Then
            cmd.CommandText = "select RackNo from Product where Rackno='" & txtrackno.Text & "'"
            Dim rckno As String = cmd.ExecuteScalar()

            If rckno = "" Or rckno Is Nothing Then
                cmd.CommandText = "DELETE Racks where Code= " & EditCode
                cmd.ExecuteNonQuery()
            Else
                MsgBox("Product Exist,Cannot delete!", MsgBoxStyle.MsgBoxHelp)
            End If
        End If

        ClearForm()

    End Sub

    Private Sub SaveTemplets()
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandText = "Update Generic Set gen=""" & RT.Rtf & """  where Gencode=" & EditCode
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub TsFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsFont.Click
        If Not RT.SelectionFont Is Nothing Then
            FontDialog1.Font = RT.SelectionFont
        Else
            FontDialog1.Font = Nothing
        End If
        FontDialog1.ShowApply = True
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            RT.SelectionFont = FontDialog1.Font
        End If
    End Sub

    Private Sub TsColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsColor.Click
        ColorDialog1.ShowDialog()
        RT.SelectionColor = ColorDialog1.Color
    End Sub

    Private Sub TsLalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsLalign.Click
        RT.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub TsCalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsCalign.Click
        RT.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub TsRalign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsRalign.Click
        RT.SelectionAlignment = HorizontalAlignment.Right

    End Sub

    Private Sub TsUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsUndo.Click
        RT.Undo()
    End Sub

    Private Sub TsRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsRedo.Click
        RT.Redo()
    End Sub

    Private Sub TsBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBold.Click
        If RT.SelectionFont.Bold Then
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Xor FontStyle.Bold)
            RT.SelectionFont = fnt
        Else
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Or FontStyle.Bold)
            RT.SelectionFont = fnt
        End If
    End Sub

    Private Sub TsItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsItalic.Click
        If RT.SelectionFont.Bold Then
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Xor FontStyle.Italic)
            RT.SelectionFont = fnt
        Else
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Or FontStyle.Italic)
            RT.SelectionFont = fnt
        End If
    End Sub

    Private Sub TsU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsU.Click
        If RT.SelectionFont.Bold Then
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Xor FontStyle.Underline)
            RT.SelectionFont = fnt
        Else
            Dim fnt As New Font(RT.SelectionFont, RT.SelectionFont.Style Or FontStyle.Underline)
            RT.SelectionFont = fnt
        End If
    End Sub

    Private Sub TsClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RT.Clear()
    End Sub

    Private Sub rt_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rt.MouseUp


        If e.Button = MouseButtons.Right Then
            'If dgBDet.CurrentCell Is Nothing Then Exit Sub
         
            If My.Computer.Clipboard.GetText = "" Then
                ContextMenuStrip1.Items(2).Enabled = False
            Else
                ContextMenuStrip1.Items(2).Enabled = True
            End If
            If rt.SelectedText = "" Then
                ContextMenuStrip1.Items(1).Enabled = False
                ContextMenuStrip1.Items(0).Enabled = False
            Else
                ContextMenuStrip1.Items(1).Enabled = True
                ContextMenuStrip1.Items(0).Enabled = True

            End If
            ContextMenuStrip1.Show(rt, New Point(e.X, e.Y))

            'End If
        End If
    End Sub

    Private Sub RT_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rt.SelectionChanged
        If rt.SelectionIndent = Nothing Then
            TrackBar1.Value = TrackBar1.Minimum
            TrackBar2.Value = TrackBar2.Minimum
        Else
            TrackBar1.Value = rt.SelectionIndent * TrackBar1.Maximum / rt.Width
            TrackBar2.Value = (rt.SelectionHangingIndent / rt.Width) * TrackBar2.Maximum + TrackBar1.Value
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        RT.SelectionIndent = RT.Width * (TrackBar1.Value / TrackBar1.Maximum)
        RT.SelectionHangingIndent = RT.Width * (TrackBar2.Value / TrackBar2.Maximum) - RT.SelectionIndent
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        RT.SelectionHangingIndent = RT.Width * (TrackBar2.Value / TrackBar2.Maximum) - RT.SelectionIndent
    End Sub

    Private checkPrint As Integer

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = RT.Print(checkPrint, RT.TextLength, e)

        ' Look for more pages
        If checkPrint < RT.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetup.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then

            PrintDocument1.Print()
        End If
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        Dim f As New PrintPreviewDialog
        f = PrintPreviewDialog1

        ' f.MdiParent = Main
        f.Width = Main.Width
        f.Height = Main.Height
        f.PrintPreviewControl.AutoZoom = True
        f.ShowDialog()
    End Sub

    Private Sub Cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cut.Click
        System.Windows.Forms.SendKeys.Send("^{X}")
    End Sub

    Private Sub Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copy.Click
        System.Windows.Forms.SendKeys.Send("^{C}")
    End Sub

    Private Sub Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Paste.Click
        System.Windows.Forms.SendKeys.Send("^{V}")
    End Sub

    Private Sub txtrackno_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtrackno.TextChanged
        If RackSelected = True Then Exit Sub
        obj = txtrackno
        PopulateRacks()
    End Sub

    Private Sub DgRackSer_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgRackSer.CellDoubleClick
        GetRackInfo()
    End Sub

    Private Sub DgRackSer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DgRackSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlCNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlCNam.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub DgSchSer_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSchSer.CellDoubleClick
        GetSchedInfo()
    End Sub

    Private Sub DgschSer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DgSchSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlCNam.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlsch.Visible = False : obj.Text = "" : obj.Focus()

            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub DgRackSer_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgRackSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetRackInfo()
        End If
    End Sub

    Private Sub txtsch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsch.TextChanged
        If SchedSelected = True Then Exit Sub
        obj = txtsch
        PopulateSched()
    End Sub

End Class
