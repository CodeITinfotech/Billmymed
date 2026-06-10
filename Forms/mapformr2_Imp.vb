Option Strict Off
Option Explicit On
Friend Class mapformr2_Imp
    Inherits System.Windows.Forms.Form
    Dim prod As OleDb.OleDbDataReader
    Dim mode As String
    Public Sub Get_Product_Details()
        Dim i As Object
        Dim SQL As Object
        On Error GoTo errmsg
        Dim prod As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        If txtcode.Text = "" Then txtcode.Focus() : Exit Sub

        Dim tmprs As OleDb.OleDbDataReader
        Dim TMPPR As OleDb.OleDbDataReader

        SQL = "select prdcode,prdname,comcode,clscode,sched,rol,roqty,maxqty,rackno,mfr,case1,case2,case3,unit1,unit2,unit3,lrd,lid,srate,prate from product where prdcode=""" & Trim(txtcode.Text) & """"
        cmd.CommandText = SQL
        cmd.Connection = Conn

        prod = cmd.ExecuteReader

        'Prodgrid.Visible = False
        If prod.HasRows And mode = "A" Then
            MsgBox("Code already exists ..!")
            txtcode.Text = ""
            txtcode.Focus()
            Exit Sub
        End If
        If prod.HasRows And (mode = "E" Or mode = "D") Then
            prod.Read()
            txtname.Text = prod("prdName")

            cbComp.SelectedValue = prod("comcode")
            cbClass.SelectedValue = prod("clscode")
            If (prod("sched") & "") <> "" Then txtsched.Text = prod("sched")
            If Not IsDBNull(prod("Mfr")) Then TxtMfr.Text = prod("Mfr")
            Txtrack.Text = prod("rackno") & ""
            txtunit1.Text = prod("Unit1") & ""
            Txtunit2.Text = prod("Unit2") & ""
            Txtunit3.Text = prod("Unit3") & ""

            txtcase1.Text = prod("case1") & ""
            txtcase2.Text = prod("case2") & ""
            Txtcase3.Text = prod("case3") & ""

        End If

        Comok.Enabled = True

        txtname.SelectionStart = Len(txtname.Text)
        txtname.Focus()
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub

    Private Sub Populate(ByRef fld As String)
        Try
            If txtname.Text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = txtname.Text

                da.SelectCommand = cmd
                da.Fill(ds, "Product")

                DgProdSer.DataSource = ds.Tables("Product")
                If ds.Tables("Product").Rows.Count > 0 Then
                    pnlprod.Visible = True

                    DgProdSer.Focus()

                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False

            txtname.Focus()
            txtname.SelectionStart = txtname.TextLength
        Catch d As Exception
            MessageBox.Show(d.Message)


        End Try


    End Sub

    Public Sub Write_Product_Details()
        Dim SQL As Object
        Dim opt As Object
        Dim i As Object
        Dim cmd As New OleDb.OleDbCommand
        On Error GoTo errmsg
        If txtcase1.Text = "" Then
            MsgBox("Enter Case1", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Val(txtunit1.Text) = 0 Then
            MsgBox("Enter Unit1", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        cmd.Connection = Conn
        If mode = "E" Then
            cmd.CommandText = "update product set prdname=""" & txtname.Text & """,  Comcode = " & cbComp.SelectedValue & ",clscode = " & cbClass.SelectedValue & ",rackno=""" & Txtrack.Text & """,sched = """ & txtsched.Text & """," & "Mfr=""" & TxtMfr.Text & """,case1=""" & txtcase1.Text & """,unit1=" & txtunit1.Text & ",case2=""" & Trim(txtcase2.Text) & """,unit2=" & Txtunit2.Text & ",case3=""" & Trim(Txtcase3.Text) & """,unit3=" & Txtunit3.Text & " where prdcode=""" & txtcode.Text & """"
        Else
            cmd.CommandText = "insert into product(prdCode,prdname,comcode,clscode,rackno,mfr,case1,unit1,case2,unit2,case3,unit3,sched)  values(""" & Trim(txtcode.Text) & """,""" & txtname.Text & """," & cbComp.SelectedValue & "," & Val(cbClass.SelectedValue & "") & ",""" & Txtrack.Text & """,""" & TxtMfr.Text & """,""" & txtcase1.Text & """," & Val(txtunit1.Text) & ",""" & Trim(txtcase2.Text) & """," & Val(Txtunit2.Text) & ",""" & Trim(Txtcase3.Text) & """," & Val(Txtunit3.Text) & ",""" & txtsched.Text & """)"
        End If
        cmd.ExecuteNonQuery()
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub



    Private Sub Comadd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comadd.Click
        On Error GoTo errmsg
        Blank_text()
        comadd.Enabled = False
        comselect.Enabled = True
        txtname.Focus()
        mode = "A"
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub

    Private Sub ComCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComCancel.Click
        Me.Tag = ""
        Me.Close()
    End Sub

    Private Sub ComClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComClear.Click
        Blank_text()
        txtname.Focus()
    End Sub

    Private Sub comok_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Comok.Click
        Dim X As Object
        On Error GoTo errmsg
        If txtcode.Text = "" Then
            txtcode.Focus()
            X = MsgBox("Product Code is not entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If txtname.Text = "" Then
            txtname.Focus()
            X = MsgBox("Product Name is not entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Trim(cbComp.Text) = "" Then
            X = MsgBox("Company is not selected ..!", MsgBoxStyle.Information)
            cbComp.Focus()
            Exit Sub
        End If
        If Val(cbComp.SelectedValue & "") = 0 Then
            X = MsgBox("Company is not selected ..!", MsgBoxStyle.Information)
            cbComp.Focus()
            Exit Sub
        End If

        If txtcase1.Text = "" Then
            txtcase1.Focus()
            X = MsgBox("Case 1 is not entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If CDbl(txtunit1.Text) = 0 Then
            txtunit1.Focus()
            X = MsgBox("Unit 1 is not Entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If txtcase2.Text <> "" And Val(Txtunit2.Text) = 0 Then
            Txtunit2.Focus()
            X = MsgBox("Unit 2 is not Entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Trim(Txtcase3.Text) <> "" And Val(Txtunit3.Text) = 0 Then
            Txtunit3.Focus()
            X = MsgBox("Unit 3 is not Entered ..!", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim scmd As New OleDb.OleDbCommand

        Write_Product_Details()

        WCode = txtcode.Text

        Blank_text()
        comadd.Enabled = True
        comselect.Enabled = False
        txtname.Focus()
        mode = "E"


        Me.Close()
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub



    Private Sub comselect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles comselect.Click
        Blank_text()
        comadd.Enabled = True
        comselect.Enabled = False
        txtname.Focus()
        mode = "E"
    End Sub

    Private Sub mapformr2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo errmsg

        On Error GoTo errmsg
        Dim cmd As New OleDb.OleDbCommand
        Dim ds As New DataSet
        Dim da As New OleDb.OleDbDataAdapter
        cmd.Connection = Conn

        cmd.CommandText = "select clscode,clsname from Classification order by clsname"
        DA.SelectCommand = cmd
        DA.Fill(DS, "Classification")
        cbClass.DisplayMember = "clsName"
        cbClass.ValueMember = "clscode"
        cbClass.DataSource = DS.Tables("Classification")
        cbClass.SelectedValue = 0
        cbClass.SelectedText = ""
        cbClass.Text = ""


        cmd.CommandText = "select comcode,comname from Company order by comname"
        DA.SelectCommand = cmd
        DA.Fill(DS, "Company")
        cbComp.DisplayMember = "comName"
        cbComp.ValueMember = "comCode"
        cbComp.DataSource = DS.Tables("Company")
        cbComp.SelectedValue = 0
        cbComp.SelectedText = ""

        cbClass.Text = "OTHERS"

        cbComp.Text = ""
        comselect.Enabled = False
        mode = "E"
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub
    Private Sub mapformr2_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo errmsg
        prod = Nothing
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")

    End Sub


    Private Sub TxtMfr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtMfr.Enter
        TxtMfr.SelectionStart = 0
        TxtMfr.SelectionLength = Len(TxtMfr.Text)
        TxtMfr.Text = TxtMfr.SelectedText
    End Sub

    Private Sub TxtMfr_KeyPress(ByVal eventSender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMfr.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    'Private Sub txtname_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
    '    Dim Cancel As Boolean = eventArgs.Cancel
    '    If txtname.Text = "" And mode = "A" Then MsgBox("Product Name is Blank..!") : Cancel = True
    '    If txtcode.Text = "" And mode = "A" And Trim(txtname.Text) <> "" Then
    '        Create_Code()
    '    End If
    '    eventArgs.Cancel = Cancel
    'End Sub





    Private Sub txtcode_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtcode.TextChanged
        '        Dim ctrl As Object
        '        On Error GoTo errmsg
        '        If txtcode.Tag = "Y" Then txtcode.Tag = "" : Exit Sub
        '        If txtcode.Text = "" Then
        '            pnlprod.Visible = False
        '        Else
        '            ctrl = "Code"
        '            Populate(("Code"))
        '        End If
        '        Exit Sub
        'errmsg:
        '        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")
    End Sub

    '    Private Sub txtcode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtcode.KeyPress
    '        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '        On Error GoTo errmsg
    '        If Chr(KeyAscii) = "[" Or KeyAscii = 34 Then KeyAscii = 0
    '        KeyAscii = Asc(UCase(Chr(KeyAscii)))
    '        If KeyAscii = 13 Then
    '            If (mode = "E" Or mode = "D") And txtcode.Text <> "" Then
    '                Get_Product_Details()
    '            Else
    '                If txtcode.Text = "" And mode = "A" And Trim(txtname.Text) <> "" Then
    '                    Create_Code()
    '                End If
    '            End If


    '        End If
    '            System.Windows.Forms.SendKeys.Send("{tab}")
    '            GoTo EventExitSub
    'errmsg:
    '        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")
    'EventExitSub:
    '            eventArgs.KeyChar = Chr(KeyAscii)
    '            If KeyAscii = 0 Then
    '                eventArgs.Handled = True
    '            End If
    'End Sub

    Private Sub txtname_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtname.TextChanged

        Try
            Populate("NAME")
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        '        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '        Dim X As Object
        '        Dim tmprs As OleDb.OleDbDataReader
        '        Dim cmd As New OleDb.OleDbCommand

        '        On Error GoTo errmsg
        '        If Chr(KeyAscii) = "[" Or KeyAscii = 34 Then KeyAscii = 0
        '        KeyAscii = Asc(UCase(Chr(KeyAscii)))
        '        If KeyAscii = 13 Then
        '            If (mode = "E" Or mode = "D") And Trim(txtcode.Text) = "" Then
        '                cmd.CommandText = "select * from product where name=""" & txtname.Text & """"
        '                tmprs = cmd.ExecuteReader
        '                If Not tmprs.HasRows Then
        '                    X = MsgBox("No such Product..!", MsgBoxStyle.Information)
        '                    txtcode.Text = ""
        '                    txtname.Text = ""
        '                    GoTo EventExitSub
        '                End If
        '            Else
        '                If txtcode.Text = "" And mode = "A" And Trim(txtname.Text) <> "" Then
        '                    Create_Code()
        '                End If
        '            End If
        '            System.Windows.Forms.SendKeys.Send("{tab}")
        '        End If
        '        GoTo EventExitSub
        'errmsg:
        '        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")
        'EventExitSub:
        '        eventArgs.KeyChar = Chr(KeyAscii)
        '        If KeyAscii = 0 Then
        '            eventArgs.Handled = True
        '        End If
    End Sub

    Private Sub Txtrack_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txtrack.Enter
        Txtrack.SelectionStart = 0
        Txtrack.SelectionLength = Len(Txtrack.Text)
        Txtrack.Text = Txtrack.SelectedText
    End Sub

    Private Sub Txtrack_KeyPress(ByVal eventSender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtrack.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub


    Private Sub txtsched_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtsched.Enter
        txtsched.SelectionStart = 0
        txtsched.SelectionLength = Len(txtsched.Text)
        txtsched.Text = txtsched.SelectedText
    End Sub

    Private Sub txtsched_KeyPress(ByVal eventSender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsched.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")


    End Sub









    Private Sub Create_Code()
        Dim X As Object
        Dim maxcode As OleDb.OleDbDataReader
        Dim nm As Object
        On Error GoTo errmsg
        Dim rsprod As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand

        cmd.Connection = Conn
        cmd.CommandText = "select PrdCode from product where prdname=""" & txtname.Text & """"
        rsprod = cmd.ExecuteReader

        If rsprod.HasRows Then
            MsgBox("Product already exists..!", MsgBoxStyle.Information)
        End If

        rsprod.Close()
        If Len(txtname.Text) > 3 Then
            nm = Microsoft.VisualBasic.Left(txtname.Text, 3)
        Else
            nm = txtname.Text
        End If
        cmd.CommandText = "Select max(convert(int,rtrim(substring(prdcode,4,4)))) as [newcode] from product where prdcode like """ + nm + "%"""
        maxcode = cmd.ExecuteReader
        maxcode.read()
        If IsDBNull(maxcode!newcode) Then
            X = 1
        Else
            X = maxcode!newcode + 1
        End If
        txtcode.Tag = "Y"
        txtcode.Text = nm & X
        maxcode.Close()
        pnlprod.Visible = False
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")
    End Sub

    Public Sub Blank_text()
        Dim i As Object
        On Error GoTo errmsg
        txtcode.Text = ""
        txtname.Text = ""
        'cmbgen.SelectedValue = 0
        cbComp.SelectedValue = 0
        cbComp.Text = ""
        cbClass.SelectedValue = 0
        txtsched.Text = ""
        Txtrack.Text = ""
        TxtMfr.Text = ""

        txtcase1.Text = ""
        txtunit1.Text = "1"

        txtcase2.Text = ""
        Txtunit2.Text = ""

        Txtcase3.Text = ""
        Txtunit3.Text = ""


        'Prodgrid.Visible = False
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")
    End Sub




    Private Sub Prodgrid_CellDoubleClick() Handles DgProdSer.CellDoubleClick
        Dim ctrl As Object
        On Error GoTo errmsg

        If DgProdSer.RowCount <> 0 Then
            'Prodgrid.CurrentCell.co  = 0
            If mode = "A" And ctrl = "Name" And Trim(txtname.Text) <> "" Then
                If txtcode.Text = "" Then Create_Code()
                cbComp.Focus()
                pnlprod.Visible = False
                Exit Sub
            End If
            If mode = "E" Or mode = "D" Then
                txtcode.Tag = "Y"
                txtcode.Text = DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value
            End If
            txtname.Focus()
            Get_Product_Details()
        End If
        pnlprod.Visible = False
        Exit Sub
errmsg:
        ErrorMsg(Err.Description & Chr(13) & Err.Source, "")


    End Sub

    Private Sub Prodgrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgProdSer.KeyPress




        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            'Asci value of Tab is 9
            If Asc(e.KeyChar) = 9 Then Exit Sub

            'Asci value of Enter is 13
            If Asc(e.KeyChar) = 13 Then Exit Sub

            'Asci value of Escape is  27
            If Asc(e.KeyChar) = 27 Then
                pnlprod.Visible = False : txtname.Text = "" : txtname.Focus() : Exit Sub

            End If

            ' Asci value of Backspace is 8
            If Asc(e.KeyChar) = 8 And txtname.Text <> "" Then
                txtname.Text = Microsoft.VisualBasic.Left(Trim(txtname.Text), Len(txtname.Text) - 1)
                If txtname.Text = "" Then pnlprod.Visible = False : txtname.Text = "" : txtname.Focus()
            Else
                txtname.Text = txtname.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub



    Private Sub Txtrack_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtrack.TextChanged

    End Sub

    Private Sub TxtMfr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMfr.TextChanged

    End Sub

    Private Sub txtcase1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcase1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")



    End Sub

    Private Sub txtsched_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsched.TextChanged

    End Sub

    Private Sub txtcase1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcase1.TextChanged

    End Sub

    Private Sub txtcase2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcase2.KeyDown

    End Sub

    Private Sub txtcase2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcase2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    Private Sub txtcase2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcase2.TextChanged

    End Sub

    Private Sub Txtcase3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcase3.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    Private Sub Txtcase3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcase3.TextChanged

    End Sub

    Private Sub txtunit1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunit1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    Private Sub txtunit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunit1.TextChanged

    End Sub

    Private Sub Txtunit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtunit2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    Private Sub Txtunit2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtunit2.TextChanged

    End Sub

    Private Sub Txtunit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtunit3.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = Chr(13) Then System.Windows.Forms.SendKeys.Send("{tab}")

    End Sub

    Private Sub Txtunit3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtunit3.TextChanged

    End Sub

    Private Sub Prodgrid_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            pnlprod.Visible = False
            Prodgrid_CellDoubleClick()

            Exit Sub
        End If
    End Sub

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub

    Private Sub Frm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Frm.Enter

    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        If txtcode.Text = "" And mode = "A" And Trim(txtname.Text) <> "" And DgProdSer.Visible = False Then CreateCode()

    End Sub


    Private Sub CreateCode()
        Dim cmd As New OleDb.OleDbCommand
        Dim nm As String
        Dim x As Long
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            cmd.CommandText = "select PrdCode from product where prdname=""" + txtName.Text + """"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            dataredr.Read()
            If dataredr.HasRows Then
                MsgBox("Product already exists..!", MsgBoxStyle.Information)
            End If
            If Len(txtName.Text) > 3 Then nm = Microsoft.VisualBasic.Left(txtName.Text, 3) Else nm = txtName.Text

            cmd.CommandText = "Select max(convert(int,rtrim(substring(prdcode,4,4)))) as [newcode] from product where prdcode like """ + nm + "%"""

            ' cmd.CommandText = "Select max(CONVERT(BIGINT,prdcode)) as [newcode] from product where prdcode like """ + nm + "%"""

            dataredr.Close()
            dataredr = cmd.ExecuteReader()

            If dataredr.HasRows Then
                dataredr.Read()
                If dataredr.Item(0) & "" = "" Then x = 1 Else x = Val(dataredr("newcode") & "") + 1

                txtCode.Text = nm & x
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class