Imports System.Windows.Forms

Public Class BillCopy

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If txtNof.Text = "" Then

        ElseIf txtNof.Text = 0 Then
            Exit Sub
        End If

        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub
    Public Sub loadform()
        Dim cmd As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        cmd.Connection = Conn
        cmd.CommandText = "select billprint,invpreprint,sysdt from settings"
        dr = cmd.ExecuteReader

        dr.Read()
        If dr("invpreprint") Then
            ChkPrePrint.Checked = True
        Else
            ChkPrePrint.Checked = False
        End If
        dtpt.Value = SysDt
        dtpf.Value = DateAdd(DateInterval.Month, -1, SysDt)
        dr.Close()
        If Me.Text = "Sales Return Copy" Then

            cmd.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where type like '3%' and isnull(accopt,0) =0  Order by seq"

            da.SelectCommand = cmd
            da.Fill(ds, "SerialNum")
            cbType.DisplayMember = "Descr"
            cbType.ValueMember = "Type"
            cbType.DataSource = ds.Tables("SerialNum")
        ElseIf Me.Text = "Duplicate Copy" Then

            cmd.CommandText = "select 99 as type,'Cash' as Descr,1 as seq union all select 98 as type,'Credit' as Descr,2 as seq order by seq"
            da.SelectCommand = cmd
            da.Fill(ds, "SerialNum")
            cbType.DisplayMember = "Descr"
            cbType.ValueMember = "Type"
            cbType.DataSource = ds.Tables("SerialNum")
        Else

            cmd.CommandText = "select DISTINCT Type,Descr,seq from SerialNum where type like '2%' and isnull(accopt,0) =0 Order by seq"

            da.SelectCommand = cmd
            da.Fill(ds, "SerialNum")
            cbType.DisplayMember = "Descr"
            cbType.ValueMember = "Type"
            cbType.DataSource = ds.Tables("SerialNum")

        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNof.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub txtSalNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNof.KeyDown

    End Sub

    Private Sub txtSalNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNof.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtBilDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        End If
    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtNof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNof.TextChanged

    End Sub

    Private Sub lblSalno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSalno.Click

    End Sub

    Private Sub txtNot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNot.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtBilDt_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub ChkPrePrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPrePrint.CheckedChanged

    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click

    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

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

    Private Sub BillCopy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
