Imports System.Windows.Forms

Public Class PurchaseCopy
    Dim sFlg As Boolean

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
















        'Purchase.tsbSave.Enabled = True
        If rbRcpt.Checked = True Then
            sFlg = True
            If txtRctno.Text = "" Then
                MsgBox("Enter Receipt No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                txtRctno.Focus()
                Exit Sub
            ElseIf txtRctno.Text = 0 Then
                Exit Sub
            End If

            

        ElseIf rbSupp.Checked = True Then

            sFlg = False

            If cbSupp.SelectedIndex = 0 Then
                MsgBox("Select Supplier Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                cbSupp.Focus()
                Exit Sub
            End If

            If txtBNo.Text = "" Then
                MsgBox("Select Bill No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                txtBNo.Focus()
                Exit Sub
            End If

            

        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PurchaseCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand

        cmd.Connection = Conn

        cmd.CommandText = "select Accode,Acname + ' ' + place  as [acname] from Acmaster order by Acname + ' ' + place"
        DA.SelectCommand = cmd
        DA.Fill(DS, "Acmaster")
        cbSupp.DisplayMember = "AcName"
        cbSupp.ValueMember = "AcCode"
        cbSupp.DataSource = DS.Tables("Acmaster")

        cmd.CommandText = "select Type,Descr,seq from SerialNum where type>10 and type<20 order by seq"
        DA.SelectCommand = cmd
        DA.Fill(DS, "SerialNum")
        cbType.DisplayMember = "Descr"
        cbType.ValueMember = "Type"
        cbType.DataSource = DS.Tables("SerialNum")

        Dim cmd1 As New OleDb.OleDbCommand
        cmd1.Connection = Conn
        cmd1.CommandText = "Select * from Settings "

        Dim dataredr As OleDb.OleDbDataReader = cmd1.ExecuteReader()
        If dataredr.HasRows Then
            dataredr.Read()
            'txtRctDt.Text = dataredr.Item("sysdt")
        End If

        dtpt.Value = SysDt
        dtpf.Value = DateAdd(DateInterval.Month, -1, SysDt)
        dtpbdt.Value = SysDt

    End Sub

    Private Sub txtRctno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRctno.KeyDown
        If e.KeyCode = Keys.Enter Then
            'btnOK.Focus()
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub txtRctno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRctno.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRctno2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRctno2.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtRctDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'If DateCheck(txtRctDt, True) = False Then e.Cancel = True
    End Sub

    Private Sub rbSupp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSupp.CheckedChanged
        If rbSupp.Checked = True Then
            pnlsup.Enabled = True
            pnlrct.Enabled = False
        End If
    End Sub

    Private Sub rbRcpt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRcpt.CheckedChanged
        If rbRcpt.Checked = True Then
            pnlsup.Enabled = False
            pnlrct.Enabled = True
        End If
    End Sub

    Private Sub rbDtAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtAll.CheckedChanged
        If rbDtAll.Checked = True Then
            pnlsup.Enabled = False
            pnlrct.Enabled = False
        End If
    End Sub

   
    Private Sub txtRctno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRctno.TextChanged

    End Sub

    Private Sub txtRctno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRctno.Validated
        If Val(txtRctno2.Text) < Val(txtRctno.Text) Then
            txtRctno2.Text = Val(txtRctno.Text)
        End If
    End Sub

    Private Sub txtRctno2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRctno2.TextChanged
       
    End Sub

    Private Sub txtRctno2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRctno2.Validated
        If Val(txtRctno2.Text) < Val(txtRctno.Text) Then
            txtRctno.Text = Val(txtRctno2.Text)
        End If
    End Sub
End Class
