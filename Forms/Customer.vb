Public Class Customer
    Private obj As Object
    Private CustSelected As Boolean
    Private CustAdding As Boolean
    Private EditCode As Long

    Private Sub Customer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If UCase(Me.ActiveControl.Name) = "CKBBIL" And tsbSave.Enabled Then
                'tsbSave.Focus()
            Else
                System.Windows.Forms.SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Private Sub txtAcName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcname.TextChanged
        If CustSelected = True Then Exit Sub
        Try
            obj = txtAcname
            Populatecustomer()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Populatecustomer()

        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Dim serstr As String

        Try
            serstr = obj.text

            If obj.Text <> "" Then
                pcmd.Connection = Conn
                pcmd.CommandText = "Select AcCode as [Code],AcName as [Name],Place from Acmaster where grpcode=" & CustGrpcode & " and " & obj.tag & " like """ + obj.Text + "%"" order by AcName "
                pda.SelectCommand = pcmd
                pda.Fill(pds, "Acmaster")
                dgCustSer.DataSource = pds.Tables("Acmaster")

                dgCustSer.Columns(0).Visible = False
                dgCustSer.Columns(1).Width = 300

                dgCustSer.Columns(2).Width = 100
                ' dgCustSer.DefaultCellStyle.ForeColor = Color.Yellow
                'dgCustSer.DefaultCellStyle.BackColor = Color.Navy
                'dgCustSer.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet

                If (dgCustSer.Rows.Count >= 1) Then
                    pnlCust.Visible = True
                    dgCustSer.Focus()
                    Exit Sub
                End If
            End If
            pnlCust.Visible = False
            If Not CustAdding Then
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

    Private Sub dgCustSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgCustSer.KeyPress
        If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

        If Asc(e.KeyChar) = 13 Then Exit Sub

        If Asc(e.KeyChar) = 9 Then Exit Sub

        If Asc(e.KeyChar) = 27 Then
            pnlCust.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub

        End If

        If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
            obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
            If obj.Text = "" Then pnlCust.Visible = False : obj.Text = "" : obj.Focus()
        Else
            obj.Text = obj.Text & UCase(e.KeyChar)
        End If

    End Sub

    Private Sub dgCustSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustSer.CellDoubleClick
        GetInfo()
    End Sub

    Private Sub dgCustSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgCustSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            GetInfo()
        End If
    End Sub

    Private Sub GetInfo()
        pnlCust.Visible = False
        If Not CustAdding Then
            GetCustomer(dgCustSer.Item(0, dgCustSer.CurrentCell.RowIndex).Value)
        Else
            txtAcname.Focus()
            txtAcname.SelectionStart = Len(txtAcname.Text)
        End If
    End Sub

    Private Sub GetCustomer(ByVal Accode As String)
        Dim pcmd As New OleDb.OleDbCommand
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Me.Cursor = Cursors.WaitCursor
        Try
            pcmd.Connection = Conn
            cmd.Connection = Conn

            pcmd.CommandText = "Select * from Acmaster where Accode='" + Accode + "' "
            CustSelected = True
            Dim dataredr As OleDb.OleDbDataReader = pcmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                txtAcname.Text = dataredr.Item("Acname")
                txtSaddr1.Text = dataredr.Item("Adr1") & ""
                txtSaddr2.Text = dataredr.Item("Adr2") & ""
                txtSaddr3.Text = dataredr.Item("Adr3") & ""
                txtSplace.Text = dataredr.Item("Place")
                txtSpin.Text = dataredr.Item("Pin")
                txtSphon.Text = dataredr.Item("Ph")
                txtSfax.Text = dataredr.Item("Fax") & ""
                txtSEmail.Text = dataredr.Item("Email") & ""
                txtILmt.Text = dataredr.Item("InvLmt") & ""
                txtdis.Text = dataredr.Item("disc") & ""
                txtCsCdtLmt.Text = dataredr.Item("CrLmt") & ""
                txtPlus.Text = dataredr.Item("CrPlus") & ""
                txtCrday.Text = dataredr.Item("Crday") & ""
                txtScper.Text = dataredr.Item("Person") & ""
                ckbBil.Checked = dataredr.Item("Bwise")
                If dataredr.Item("Mob") & "" <> "" Then
                    If Len(dataredr.Item("Mob").ToString) = 12 Then
                        txtMob.Text = Microsoft.VisualBasic.Right(dataredr.Item("Mob"), 10)
                    End If
                End If

                If IsDBNull(dataredr.Item("ActSMS")) Then
                    ChkSMS.Checked = False
                Else
                    ChkSMS.Checked = True
                End If

                If IsDBNull(dataredr.Item("ActEmail")) Then
                    ChkEmail.Checked = False
                Else
                    ChkEmail.Checked = True
                End If

                txtSMSDeclartn.Text = dataredr.Item("SMSDeclNo") & ""
                If IsDate(dataredr.Item("DOB") & "") Then
                    txtdob.Text = dataredr.Item("DOB")
                Else
                    txtdob.Clear()
                End If

                cmbGroup.SelectedValue = Val(dataredr("CGrpcode") & "")

                'cmd.CommandText = "Select GrpName,grpcode from CustGroup where GrpCode='" & dataredr.Item("CGrpCode") & "'"
                'dr = cmd.ExecuteReader
                'If dr.HasRows Then
                'dr.Read()
                'cmbGroup.Text = dr("Grpname")
                'End If
                'dr.Close()

                tsbSave.Enabled = True
                txtAcname.Focus()
                txtAcname.SelectionStart = Len(txtAcname.Text)
            End If
            tsbClr.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblStatus.Text = ""
            EditCode = Accode
        Catch er As Exception
            Me.Cursor = Cursors.Default
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ClearForm()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet

        cmd.Connection = Conn
        cmd.CommandText = "Select GrpCode,GrpName from CustGroup"
        da.SelectCommand = cmd
        da.Fill(ds, "CustGroup")
        cmbGroup.DisplayMember = "GrpName"
        cmbGroup.ValueMember = "GrpCode"
        cmbGroup.DataSource = ds.Tables("CustGroup")

        EditCode = 0
        tsbDel.Enabled = False
        txtAcname.Text = ""
        CustSelected = False
        txtSaddr1.Text = ""
        txtSaddr2.Text = ""
        txtSaddr3.Text = ""
        txtSplace.Text = ""
        txtSphon.Text = ""
        txtSpin.Text = ""
        txtSfax.Text = ""
        txtSEmail.Text = ""
        txtScper.Text = ""
        txtILmt.Text = "0.00"
        txtCsCdtLmt.Text = "0.00"
        txtCrday.Text = "0"
        txtPlus.Text = "0"
        txtMob.Text = ""
        tsbSave.Enabled = False
        tsbAdd.Enabled = True
        txtAcname.Focus()
        CustAdding = False
        ckbBil.Checked = True
        lblStatus.Text = "Select a  Customer.."
        ChkSMS.Checked = False
        ChkEmail.Checked = False
        txtSMSDeclartn.Text = ""
        txtdis.Text = ""
        txtdob.Clear()
        cmbGroup.Text = ""
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtAcName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcname.GotFocus
        txtAcname.SelectAll()
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

    Private Sub txtScper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScper.GotFocus
        txtScper.SelectAll()
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        ClearForm()
        tsbAdd.Enabled = False
        tsbSave.Enabled = True
        tsbClr.Enabled = True
        CustAdding = True
        lblStatus.Text = "Adding Customer.."
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click

        If CheckUserLocked("Delete Customer") = False Then Exit Sub
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

        If MsgBox("Want to delete the customer : " & txtAcname.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        If MsgBox("Are you sure.. Want to delete the customer : " & txtAcname.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
        cmd.CommandText = "delete from  Acmaster  where Accode = " & EditCode
        cmd.ExecuteNonQuery()
        tsbClr.PerformClick()
    End Sub

    Private Sub tsbClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClr.Click
        ClearForm()
    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        'If MsgBox("Want to 'Exit' from Customer ..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, ) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim DOBDT As String
        If txtAcname.Text = "" Then
            MsgBox("Customer name is not entered..", MsgBoxStyle.Exclamation)
            txtAcname.Focus()
            Exit Sub
        End If
        If CustAdding = False Then
            If CheckUserLocked("Edit Customer") = False Then Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn


            If Not IsDate(txtdob.Text) Then
                DOBDT = "NULL"
            Else
                DOBDT = "'" & txtdob.Text & "'"
            End If

            If CustAdding = False Then

                cmd.CommandText = "Update Acmaster set Acname=""" + txtAcname.Text + """, adr1 = """ & txtSaddr1.Text & """,adr2=""" & txtSaddr2.Text & """,adr3=""" & txtSaddr3.Text & """,Place=""" & txtSplace.Text & """,Pin=""" & txtSpin.Text & _
                """,Ph=""" & txtSphon.Text & """,Fax=""" & txtSfax.Text & """,Email= """ & txtSEmail.Text & """ ,Person=""" & txtScper.Text & """,InvLmt=" & Val(txtILmt.Text) & _
                ",CrLmt= " & Val(txtCsCdtLmt.Text) & ",Crday= " & Val(txtCrday.Text) & ",CrPlus= " & Val(txtPlus.Text) & ",bwise='" & ckbBil.Checked & "',Mob='91" & RTrim(txtMob.Text) & "'," & _
                "ActSMS='" & ChkSMS.Checked & "',ActEmail='" & ChkEmail.Checked & "',SMSDeclNo='" & txtSMSDeclartn.Text & "'," & _
                "DOB=" & DOBDT & ",CGrpCode='" & cmbGroup.SelectedValue & "',disc=" & Val(txtdis.Text) & " where Accode = " & EditCode
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


                cmd.CommandText = "Insert into Acmaster (Accode,AcName,Adr1,Adr2,Adr3,Place,Pin,Ph,Fax,Email,Person,InvLmt,CrLmt,Crday,CrPlus,bwise,grpcode,Mob,ActSMS,ActEmail,SMSDeclNo,DOB,CGrpCode,SGCODE,ACCLASS,disc) values(" & EditCode & ",""" & txtAcname.Text & """,""" & txtSaddr1.Text & _
                """,""" & txtSaddr2.Text & """ ,""" & txtSaddr3.Text & """ ,""" & txtSplace.Text & """ ,""" & txtSpin.Text & """, """ & txtSphon.Text & """,""" & txtSfax.Text & _
                """,""" & txtSEmail.Text & """,""" & txtScper.Text & """," & Val(txtILmt.Text) & "," & Val(txtCsCdtLmt.Text) & ", " & Val(txtCrday.Text) & ", " & Val(txtPlus.Text) & ",'" & ckbBil.Checked & "',3,'91" & RTrim(txtMob.Text) & "'," & _
                "'" & ChkSMS.Checked & "','" & ChkEmail.Checked & "','" & txtSMSDeclartn.Text & "'," & DOBDT & ",'" & cmbGroup.SelectedValue & "',3,1," & Val(txtdis.Text) & ")"
            End If

            cmd.ExecuteNonQuery()
            If CustAdding Then
                tsbClr.PerformClick()
                tsbAdd.PerformClick()
            Else
                tsbClr.PerformClick()
            End If
            tsbSave.Enabled = True
            lblStatus.Visible = True
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

End Class
