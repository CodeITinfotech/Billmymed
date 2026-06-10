Imports System.Windows.Forms

Public Class EditSales

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If txtSalNo.Text = "" Then
            MsgBox("Enter Receipt No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            txtSalNo.Focus()
            Exit Sub
        ElseIf txtSalNo.Text = 0 Then
            Exit Sub
        End If

        
        'txtSalNo.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANCEL_Button.Click
        txtSalNo.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EditSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSalNo.Focus()
        dtpt.Value = SysDt
        dtpf.Value = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, SysDt))

    End Sub

    Private Sub txtSalNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpf.Focus()

        End If
    End Sub

    Private Sub txtSalNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalNo.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtBilDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            OK_Button.Focus()
            OK_Button.PerformClick()
        End If
    End Sub

  
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
