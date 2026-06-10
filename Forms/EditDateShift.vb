Imports System.Windows.Forms

Public Class EditDateShift

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If txtNof.Text = "" Then

        ElseIf txtNof.Text = 0 Then
            Exit Sub
        End If

       
    End Sub
    Public Sub loadform(Optional str As String = "")
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        cmd.Connection = Conn
        cmd.CommandText = "select billprint,invpreprint,sysdt from settings"
        dr = cmd.ExecuteReader
        dr.Read()
        dtpt.Value = SysDt
        dtpf.Value = DateAdd(DateInterval.Month, -1, SysDt)
        dr.Close()

        cmd.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where  type like '" & str & "%'   and isnull(accopt,0) =0 Order by seq"

        da.SelectCommand = cmd
        da.Fill(ds, "SerialNum")
        cbType.DisplayMember = "Descr"
        cbType.ValueMember = "Type"
        cbType.DataSource = ds.Tables("SerialNum")


    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNof.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EditSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDb.OleDbCommand
        Dim shft As Integer

        cmd.CommandText = "select workshiftcount  from settings"
        cmd.Connection = Conn
        shft = cmd.ExecuteScalar
        For i = 1 To shft
            cbshft.Items.Add(i)
        Next
        cmd.CommandText = "select  workshift from settings"

        shft = cmd.ExecuteScalar
        cbshft.Text = shft

    End Sub

    Private Sub txtSalNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNof.KeyDown

    End Sub

    Private Sub txtSalNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNof.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    
 

   

   
     

    

   

    Private Sub txtNot_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNot.Validated
        If Val(txtNot.Text) < Val(txtNof.Text) Then
            txtNof.Text = Val(txtNot.Text)
        End If
    End Sub

    Private Sub txtNof_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNof.Validated
        If Val(txtNot.Text) < Val(txtNof.Text) Then
            txtNot.Text = Val(txtNof.Text)
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()

     

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable

        If MsgBox("Want to change the bill date ? ", vbYesNo + vbDefaultButton2) = vbNo Then Exit Sub

        cmd.CommandText = "select * from invtotal where invdt>=convert(dateTime,'" & dtpf.Value.Date & "',103) and invdt<=convert(datetime,'" & dtpt.Value.Date & "',103)  and invno>=" & Val(txtNof.Text) & _
                " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        da.SelectCommand = cmd
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            cmd.CommandText = "update ledger set trndate='" & dtp.Value.Date & "' where  trndate>=convert(datetime,'" & dtpf.Value.Date & "')  and trndate<=convert(datetime,'" & dtpt.Value.Date & "')  " & _
                " and invcode='" & cbType.SelectedValue & dt.Rows(i).Item("invno") & "' "
            cmd.ExecuteNonQuery()
        Next

        cmd.CommandText = "update invtotal set invdt='" & dtp.Value.Date & "' where  invdt>=convert(dateTime,'" & dtpf.Value.Date & "') and invdt<=convert(datetime,'" & dtpt.Value.Date & "')  and invno>=" & Val(txtNof.Text) & _
                    " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        cmd.ExecuteNonQuery()


        cmd.CommandText = "update invdetails set invdt='" & dtp.Value.Date & "' where invdt>=convert(dateTime,'" & dtpf.Value.Date & "') and invdt<=convert(datetime,'" & dtpt.Value.Date & "')  and invno>=" & Val(txtNof.Text) & _
                 " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        cmd.ExecuteNonQuery()
        MsgBox("Bill date updated sucessfully...")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        If cbshft.Text = "" Then
            MsgBox("Select a Shift...")
            Exit Sub
        End If

        If MsgBox("Want to change the shift ? ", vbYesNo + vbDefaultButton2) = vbNo Then Exit Sub

        cmd.CommandText = "update invtotal set WorkShift='" & cbshft.Text & "' where  invdt>=convert(datetime,'" & dtpf.Value.Date & "') and invdt<=convert(datetime,'" & dtpt.Value.Date & "')  and invno>=" & Val(txtNof.Text) & _
                    " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        cmd.ExecuteNonQuery()


        MsgBox("Shift updated sucessfully...")

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub UpdPat_Click(sender As System.Object, e As System.EventArgs) Handles UpdPat.Click

        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable


        If MsgBox("Want to change the Patient Name ? ", vbYesNo + vbDefaultButton2) = vbNo Then Exit Sub

        cmd.CommandText = "update invtotal set name=""" & txtpat.Text & """ where  invdt>=convert(datetime,'" & dtpf.Value.Date & "') and invdt<=convert(datetime,'" & dtpt.Value.Date & "')  and invno>=" & Val(txtNof.Text) & _
                    " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        cmd.ExecuteNonQuery()


        MsgBox("Patient Name updated sucessfully...")
    End Sub

    Private Sub upddoc_Click(sender As System.Object, e As System.EventArgs) Handles UpdDoc.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable


        If MsgBox("Want to change the Doctor Name ? ", vbYesNo + vbDefaultButton2) = vbNo Then Exit Sub

        cmd.CommandText = "update invtotal set docname=""" & txtdoc.Text & """ where  invdt>=convert(datetime,'" & dtpf.Value.Date & "') and invdt<=convert(datetime,'" & dtpt.Value.Date & "')  and invno>=" & Val(txtNof.Text) & _
                    " and invno<=" & Val(txtNot.Text) & " and type='" & cbType.SelectedValue & "'"
        cmd.ExecuteNonQuery()


        MsgBox("Doctor Name updated sucessfully...")
    End Sub
End Class
