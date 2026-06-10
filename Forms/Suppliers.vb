
Public Class Suppliers

    Private obj As Object
    Private SuppSelected As Boolean
    Private SuppAdding As Boolean
    Private EditCode As Long
    Private sertime As DateTime
    Private sertxt As String

    Private Sub Suppliers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If UCase(Me.ActiveControl.Name) = "CKBBIL" And tsbSave.Enabled Then
                    'tsbSave.Focus()
                Else
                    System.Windows.Forms.SendKeys.Send("{TAB}")
                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Supplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ClearForm()
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtAcName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcName.TextChanged
        Try
            If SuppSelected = True Then Exit Sub
            obj = txtAcName
            PopulateSupplier()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PopulateSupplier()

        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Dim serstr As String
        serstr = obj.text
        'Replace(obj.text, "'", "[']")
        Try
            If obj.Text <> "" Then
                pcmd.Connection = Conn
                pcmd.CommandText = "Select AcCode as [Code],AcName as [Name],Place from Acmaster where grpcode=" & SupGrpcode & " and " & obj.tag & " like """ + obj.Text + "%"" order by AcName "
                pda.SelectCommand = pcmd
                pda.Fill(pds, "Acmaster")
                'dgSuppSer.Rows.Clear()
                dgSuppSer.DataSource = pds.Tables("Acmaster")
                'dgSuppSer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
                dgSuppSer.Columns(0).Width = 60
                dgSuppSer.Columns(1).Width = 265
                dgSuppSer.Columns(2).Width = 265

                '  dgSuppSer.DefaultCellStyle.ForeColor = Color.Yellow
                ' dgSuppSer.DefaultCellStyle.BackColor = Color.Navy
                'dgSuppSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgSuppSer.Rows.Count >= 1) Then
                    pnlSupp.Visible = True
                    dgSuppSer.Focus()
                    Exit Sub
                End If
            End If
            pnlSupp.Visible = False
            If Not SuppAdding Then
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

    Private Sub dgSuppSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgSuppSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 13 Then
                Exit Sub
            End If

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlSupp.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlSupp.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgSuppSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSuppSer.CellDoubleClick
        GetInfo()
    End Sub

    Private Sub dgSuppSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgSuppSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetInfo()
        End If
    End Sub

    Private Sub GetInfo()
        Try
            pnlSupp.Visible = False
            ckbCom.Checked = True
            If Not SuppAdding Then
                GetSupplier(dgSuppSer.Item(0, dgSuppSer.CurrentCell.RowIndex).Value)
                CkbProd.Enabled = True
            Else
                txtAcName.Focus()
                txtAcName.SelectionStart = Len(txtAcName.Text)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetSupplier(ByVal Accode As String)
        Dim pcmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.Connection = Conn

            pcmd.CommandText = "Select * from Acmaster where Accode='" + Accode + "' "
            SuppSelected = True
            Dim dataredr As OleDb.OleDbDataReader = pcmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtAcName.Text = dataredr.Item("Acname")
                txtSaddr1.Text = dataredr.Item("Adr1") & ""
                txtSaddr2.Text = dataredr.Item("Adr2") & ""
                txtSaddr3.Text = dataredr.Item("Adr3") & ""
                txtSplace.Text = dataredr.Item("Place")
                txtSpin.Text = dataredr.Item("Pin") & ""
                txtSphon.Text = dataredr.Item("Ph") & ""
                txtSfax.Text = dataredr.Item("Fax") & ""
                txtSEmail.Text = dataredr.Item("Email") & ""
                txtWeb.Text = dataredr.Item("website") & ""
                txtTIN.Text = dataredr.Item("st") & ""
                txtDLno1.Text = dataredr.Item("DLNO1") & ""
                txtDLno2.Text = dataredr.Item("DLNO2") & ""
                txtDLno3.Text = dataredr.Item("DLNO3") & ""
                txtCSTno.Text = dataredr.Item("CST") & ""
                txtScper.Text = dataredr.Item("Person") & ""
                txtScrdays.Text = dataredr.Item("Crday") & ""
                txtSrep.Text = dataredr.Item("VisitRep") & ""
                txtSvisit.Text = dataredr.Item("VisitDay") & ""
                ckbBil.Checked = dataredr.Item("Bwise")
                txtRemarks.Text = dataredr.Item("remarks") & ""
                EditCode = Accode
                tsbSave.Enabled = True
                txtAcName.Focus()
                txtAcName.SelectionStart = Len(txtAcName.Text)
            End If

            dataredr.Close()
            ShowSelectedCompany()
            'txtAcName.Focus()
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblStatus.Text = ""
        Catch er As Exception
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ClearForm()
        Me.Cursor = Cursors.WaitCursor
        Try
            EditCode = 0
            CkbProd.Checked = False
            tsbDel.Enabled = False
            txtAcName.Text = ""
            SuppSelected = False
            txtSaddr1.Text = ""
            txtSaddr2.Text = ""
            txtSaddr3.Text = ""
            txtSplace.Text = ""
            txtSphon.Text = ""
            txtSpin.Text = ""
            txtSfax.Text = ""
            txtSEmail.Text = ""
            txtWeb.Text = ""
            txtTIN.Text = ""
            txtDLno1.Text = ""
            txtDLno2.Text = ""
            txtDLno3.Text = ""
            txtCSTno.Text = ""
            txtScper.Text = ""
            txtSrep.Text = ""
            txtScrdays.Text = ""
            txtSrep.Text = ""
            txtSvisit.Text = ""
            txtRemarks.Text = ""
            compchecklistbox.Items.Clear()
            ckbBil.Checked = True
            tsbSave.Enabled = False
            tsbAdd.Enabled = True

            SuppAdding = False
            HideProducts()
            dgcom.Rows.Clear()
            txtAcName.Focus()
            lblStatus.Text = "Select a Supplier.."
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtCSTno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCSTno.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtAcName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcName.GotFocus
        txtAcName.SelectAll()
    End Sub

    Private Sub txtSaddr1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaddr1.GotFocus
        txtSaddr1.SelectAll()
    End Sub

    Private Sub txtSaddr2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaddr2.GotFocus
        txtSaddr2.SelectAll()
    End Sub
    Private Sub txtSaddr3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaddr3.GotFocus
        txtSaddr3.SelectAll()
    End Sub

    Private Sub txtSplace_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSplace.GotFocus
        txtSplace.SelectAll()
    End Sub

    Private Sub txtSpin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpin.GotFocus
        txtSpin.SelectAll()
    End Sub

    Private Sub txtSphon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSphon.GotFocus
        txtSphon.SelectAll()
    End Sub

    Private Sub txtSfax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSfax.GotFocus
        txtSfax.SelectAll()
    End Sub

    Private Sub txtSEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEmail.GotFocus
        txtSEmail.SelectAll()
    End Sub

    Private Sub txtWeb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeb.GotFocus
        txtWeb.SelectAll()
    End Sub

    Private Sub txtTIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIN.GotFocus
        txtTIN.SelectAll()
    End Sub

    Private Sub txtDLno1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDLno1.GotFocus
        txtDLno1.SelectAll()
    End Sub

    Private Sub txtDLno2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDLno2.GotFocus
        txtDLno2.SelectAll()
    End Sub

    Private Sub txtDLno3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDLno3.GotFocus
        txtDLno3.SelectAll()
    End Sub

    Private Sub txtCSTno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCSTno.GotFocus
        txtCSTno.SelectAll()
    End Sub

    Private Sub txtScper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScper.GotFocus
        txtScper.SelectAll()
    End Sub

    Private Sub txtScrdays_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScrdays.GotFocus
        txtScrdays.SelectAll()
    End Sub

    Private Sub txtSrep_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrep.GotFocus
        txtSrep.SelectAll()
    End Sub

    Private Sub txtSvisit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSvisit.GotFocus
        txtSvisit.SelectAll()
    End Sub

    Private Sub ShowCompany()
        Dim cmd As New OleDb.OleDbCommand
        Dim vx, i, fnd As Integer
        Me.Cursor = Cursors.WaitCursor
        Try

            ShowSelectedCompany()
            cmd.Connection = Conn
            cmd.CommandText = "Select comCode,comName as [Company Name]  from company order by comname"
            vx = dgcom.Rows.Count - 1
            'SuppSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            'dgcom.Rows.Clear()
            'compchecklistbox.Items.Clear()
            Dim mlist As MyList
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    fnd = 0
                    For i = 0 To compchecklistbox.Items.Count - 1
                        'If dgcom.Item(1, i).Value = dataredr.Item("Comcode") Then
                        mList = compchecklistbox.Items(i)
                        If mlist.ItemData = dataredr.Item("Comcode") Then

                            fnd = 1
                            Exit For
                        End If
                    Next

                    If fnd = 0 Then
                        'dgcom.Rows.Add()
                        'dgcom.Item(0, dgcom.Rows.Count - 1).Value = False
                        'dgcom.Item(1, dgcom.Rows.Count - 1).Value = dataredr.Item("Comcode")
                        'dgcom.Item(2, dgcom.Rows.Count - 1).Value = dataredr.Item("Company Name")
                        'Dim mlist As MyList
                        compchecklistbox.Items.Add(New MyList(dataredr.Item("Company Name"), dataredr.Item("Comcode")))

                    End If
                Loop
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowFavCompany()
        Dim cmd As New OleDb.OleDbCommand
        Dim vx, i, fnd As Integer
        Me.Cursor = Cursors.WaitCursor
        Try

            cmd.Connection = Conn
            cmd.CommandText = "Select comCode,comName as [Company Name]  from company where fsupcode=" & EditCode & "  order by comname"
            vx = dgcom.Rows.Count - 1
            'SuppSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            'dgcom.Rows.Clear()
            compchecklistbox.Items.Clear()
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    fnd = 0
                    For i = 0 To vx
                        'If dgcom.Item(1, i).Value = dataredr.Item("Comcode") Then
                        If compchecklistbox.Items(1) = dataredr.Item("Comcode") Then

                            fnd = 1
                            Exit For
                        End If
                    Next
                    If fnd = 0 Then
                        'dgcom.Rows.Add()
                        'dgcom.Item(0, dgcom.Rows.Count - 1).Value = False
                        'dgcom.Item(1, dgcom.Rows.Count - 1).Value = dataredr.Item("Comcode")
                        'dgcom.Item(2, dgcom.Rows.Count - 1).Value = dataredr.Item("Company Name")
                        'Dim mlist As MyList
                        compchecklistbox.Items.Add(New MyList(dataredr.Item("Company Name"), dataredr.Item("Comcode")), True)

                    End If
                Loop
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowSelectedCompany()
        Dim cmd As New OleDb.OleDbCommand
        Me.Cursor = Cursors.WaitCursor
        Try

            cmd.Connection = Conn
            cmd.CommandText = "Select company.comCode,comName as [Company Name] from company,supcom where supcom.comcode=company.comcode and supcom.supcode=" & EditCode & "  order by comname"
            ' SuppSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            Dim list As New MyList
            dgcom.Rows.Clear()
            compchecklistbox.Items.Clear()
            If dataredr.HasRows Then
                Do While dataredr.Read()

                    compchecklistbox.Items.Add(New MyList(dataredr.Item("Company Name"), dataredr.Item("Comcode")))
                    compchecklistbox.SetItemChecked(compchecklistbox.Items.Count - 1, True)
                Loop
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ckbCom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbCom.CheckedChanged
        If ckbCom.Checked = False Then
            ShowCompany()
        Else
            HideCompany()
        End If
    End Sub

    Private Sub HideCompany()
        Dim i As Integer
        'dgcom.EndEdit()
        'For i = dgcom.Rows.Count - 1 To 0 Step -1
        '    If dgcom.Item(0, i).Value = False Then
        '        dgcom.Rows.RemoveAt(i)
        '    End If
        'Next
        Try
            For i = compchecklistbox.Items.Count - 1 To 0 Step -1
                If compchecklistbox.GetItemChecked(i) = False Then
                    compchecklistbox.Items.Remove(compchecklistbox.Items(i))
                End If
            Next
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try


    End Sub

    Private Sub CkbProd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkbProd.CheckedChanged
        If CkbProd.Checked Then
            ShowProducts()
        Else
            HideProducts()
        End If
    End Sub

    Private Sub ShowProducts()
        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.Connection = Conn
            pcmd.CommandText = "Select PrdCode,Prdname,Case1 from product,supcom where " & _
                "product.comcode=supcom.comcode and supcom.supcode=" & EditCode

            pda.SelectCommand = pcmd
            pda.Fill(pds, "Product")
            dgprod.DataSource = pds.Tables("Product")
            dgprod.Columns(0).Visible = False
            pnlprod.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub HideProducts()
        Me.Cursor = Cursors.WaitCursor
        Try
            dgprod.DataSource = Nothing
            dgprod.Columns.Clear()

            dgprod.Columns.Add("PrdCode", "PrdCode")
            dgprod.Columns.Add("PrdName", "Product Name")
            dgprod.Columns.Add("Case1", "Case1")

            dgprod.Columns(0).DataPropertyName = "PrdCode"
            dgprod.Columns(0).Visible = False

            dgprod.Columns(1).DataPropertyName = "PrdName"
            dgprod.Columns(2).DataPropertyName = "Case1"

            dgprod.Columns(1).Width = 290
            dgprod.Columns(2).Width = 70

            dgprod.Columns(1).DefaultCellStyle.BackColor = Color.White
            dgprod.Columns(2).DefaultCellStyle.BackColor = Color.White

            dgprod.Columns(1).DefaultCellStyle.ForeColor = Color.Yellow
            dgprod.Columns(2).DefaultCellStyle.ForeColor = Color.Yellow
            pnlprod.Visible = False
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
        SuppAdding = True
        ckbCom.Checked = False
        lblStatus.Text = "Adding Supplier.."
        ShowCompany()
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click

        If CheckUserLocked("Delete Supplier") = False Then Exit Sub

        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim rdr As OleDb.OleDbDataReader

        cmd.CommandText = "Select trntype,vouno,trndate from ledger where accode=" & EditCode
        rdr = cmd.ExecuteReader
        If rdr.HasRows Then
            rdr.Read()
            MsgBox("Transaction exists " & rdr(0) & " " & rdr(1) & " " & rdr(2) & " can't delete.")
            Exit Sub
        End If
        rdr.Close()
        If MsgBox("Want to Delete the supplier : " & txtAcName.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        If MsgBox("Are you sure. Want to delete the supplier : " & txtAcName.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        cmd.CommandText = "delete from  Acmaster  where Accode = " & EditCode
        cmd.ExecuteNonQuery()
        tsbClear.PerformClick()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer
        If SuppAdding = False Then
            If CheckUserLocked("Edit Supplier") = False Then Exit Sub
        End If
        Try
            If txtAcName.Text = "" Then
                MsgBox("Supplier name is not entered..", MsgBoxStyle.Exclamation)
                txtAcName.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            If SuppAdding = False Then
                cmd.CommandText = "Update Acmaster set Acname=""" + txtAcName.Text + """, adr1 = """ & txtSaddr1.Text & """,adr2=""" & txtSaddr2.Text & """,adr3=""" & txtSaddr3.Text & """,Place=""" & txtSplace.Text & """,Pin=""" & txtSpin.Text & _
                    """,Ph=""" & txtSphon.Text & """,Fax=""" & txtSfax.Text & """,Email= """ & txtSEmail.Text & """ ,Website=""" & txtWeb.Text & """ ,ST=""" & txtTIN.Text & """,DLNO1=""" & txtDLno1.Text & _
                    """ ,DLNO2=""" & txtDLno2.Text & """,DLNO3=""" & txtDLno3.Text & """,CST=""" & txtCSTno.Text & """,Person=""" & txtScper.Text & """,Crday=" & Val(txtScrdays.Text) & _
                    " ,VisitRep=""" & txtSrep.Text & """,VisitDay= """ & txtSvisit.Text & """,bwise='" & ckbBil.Checked & "',remarks='" & txtRemarks.Text & "' where Accode = " & EditCode
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Delete from supcom where supcode=" & EditCode
                cmd.ExecuteNonQuery()

            Else
                cmd.CommandText = "select max(AcCode) from Acmaster "
                Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
                If Not dataredr.HasRows Then
                    EditCode = 1
                Else
                    dataredr.Read()
                    EditCode = dataredr.Item(0) + 1
                End If
                dataredr.Close()
                cmd.CommandText = "Insert into Acmaster (Accode,AcName,Adr1,Adr2,Adr3,Place,Pin,Ph,Fax,Email,Website,St,DLNO1,DLNO2,DLNO3,CST,Person,Crday,VisitRep,VisitDay,bwise,grpcode,sgcode,acclass,remarks) values(" & EditCode & ",""" & txtAcName.Text & """,""" & txtSaddr1.Text & _
                    """,""" & txtSaddr2.Text & """ ,""" & txtSaddr3.Text & """ ,""" & txtSplace.Text & """ ,""" & txtSpin.Text & """, """ & txtSphon.Text & """,""" & txtSfax.Text & """,""" & txtSEmail.Text & """,""" & txtWeb.Text & """ ,""" & txtTIN.Text & _
                    """, """ & txtDLno1.Text & """, """ & txtDLno2.Text & """, """ & txtDLno3.Text & """, """ & txtCSTno.Text & """, """ & txtScper.Text & """, " & Val(txtScrdays.Text) & ", """ & txtSrep.Text & """, """ & txtSvisit.Text & """,'" & ckbBil.Checked & "'," & SupGrpcode & "," & SupGrpcode & ",1,'" & txtRemarks.Text & "')"
                cmd.ExecuteNonQuery()
            End If

            dgcom.EndEdit()
            Dim mList As MyList

            ' For i = 0 To dgcom.Rows.Count - 1
            For i = 0 To compchecklistbox.Items.Count - 1
                'If dgcom.Item(0, i).Value Then
                If compchecklistbox.GetItemChecked(i) = True Then
                    'cmd.CommandText = "Insert into SupCom (supcode,Comcode) values(" & _
                    'EditCode & "," & dgcom.Item(1, i).Value & ")"
                    mList = compchecklistbox.Items(i)
                    cmd.CommandText = "Insert into SupCom (supcode,Comcode) values(" & _
                        EditCode & "," & mList.ItemData & ")"

                    cmd.ExecuteNonQuery()
                End If
            Next

            If SuppAdding Then
                tsbClear.PerformClick()
                tsbAdd.PerformClick()
            Else
                tsbClear.PerformClick()
            End If

            HideCompany()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        'If MsgBox("Want to 'Exit' from Suppliers ..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub

    Private Sub compchecklistbox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles compchecklistbox.KeyPress
        Dim fnd As Boolean = False
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            'Me.Text = System.Math.Abs(Val(Mid(Now().TimeOfDay.ToString, 7, 2))) & "  " & Val(Mid(sertime, 7, 2)) & "  " & sertxt


            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = CDate(Now().TimeOfDay.ToString)
            For n = 0 To compchecklistbox.Items.Count - 1
                If Microsoft.VisualBasic.Left(compchecklistbox.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    compchecklistbox.SelectedItem = compchecklistbox.Items(n)
                    ' lstcom.SelectedIndex = n
                    e.Handled = True
                    fnd = True
                    Exit For
                End If
            Next n
            If fnd = False Then sertxt = UCase(e.KeyChar)

        End If
    End Sub

    Private Sub Btnclrchk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnclrchk.Click
        For i = 0 To compchecklistbox.Items.Count - 1
            compchecklistbox.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub optcomall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optcomall.CheckedChanged
        If optcomall.Checked Then ShowCompany()
    End Sub

    Private Sub optcomdeal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optcomdeal.CheckedChanged
        If optcomdeal.Checked Then
            ShowSelectedCompany()
        End If
    End Sub

    Private Sub optcomfav_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optcomfav.CheckedChanged
        If optcomfav.Checked Then
            ShowFavCompany()
        End If
    End Sub

    'Private Sub txtRemarks_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        txtRemarks.Text = Constants.vbCrLf
    '    End If
    'End Sub
End Class


