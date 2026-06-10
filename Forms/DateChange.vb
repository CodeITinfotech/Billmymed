Imports System.Windows.Forms

Public Class DateChange

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DateChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldt.Text = Format(SysDt, "dddd dd, MMMM yyyy")
        lbldt.Tag = SysDt
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As New OleDb.OleDbCommand
        SysDt = CDate(lbldt.Tag)
        cmd.Connection = Conn
        cmd.CommandText = "update settings set sysdt='" & Format(SysDt, "yyyyMMdd") & "'"
        cmd.ExecuteNonQuery()
        Conn.Close()
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As Date
        dt = DateAdd(DateInterval.Day, 1, CDate(lbldt.Tag))
        lbldt.Text = Format(dt, "dddd dd, MMMM yyyy")
        lbldt.Tag = dt
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dt As Date
        If CheckUserLocked("Date Change Back") = False Then Exit Sub
        dt = DateAdd(DateInterval.Day, -1, CDate(lbldt.Tag))
        lbldt.Text = Format(dt, "dddd dd, MMMM yyyy")
        lbldt.Tag = dt
    End Sub

    Private Sub lbldt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbldt.Click
        Dim dt As Date
        Dim x As String
        x = InputBox("Enter date (dd/mm/yyyy):")
        If IsDate(x) Then

            dt = CDate(x)
            If dt < SysDt Then
                If CheckUserLocked("Date Change Back") = False Then Exit Sub
            End If

            lbldt.Text = Format(dt, "dddd dd, MMMM yyyy")
            lbldt.Tag = dt
        End If

    End Sub
End Class
