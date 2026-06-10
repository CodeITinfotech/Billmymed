Imports System.Windows.Forms


Public Class Backup
    Private bakflg As Boolean = False
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
        ' Me.Close()

        Me.Cursor = Cursors.WaitCursor
        Label2.ForeColor = Color.Red
        Label2.Text = "Backing-up please wait."
        pbar.Style = ProgressBarStyle.Marquee
        Cancel_Button.Enabled = False
        OK_Button.Enabled = False
        bw.RunWorkerAsync()
        
        Exit Sub



    End Sub

   

    Private Sub Backup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Showdrives()
    End Sub
  
   
    Private Sub Showdrives()
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GET_backupfolder"
        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
        cmd.Parameters.Clear()
        If dataredr.HasRows Then
            dataredr.Read()
            Try
                fd.SelectedPath = dataredr(0)
                bkdrv.Text = dataredr(0)
            Catch ex As Exception

            End Try
        End If
        dataredr.Close()
    End Sub

   
   
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If fd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        bkdrv.Text = fd.SelectedPath.ToString
    End Sub

    Private Sub TakeBackup()
        Try

       
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Clear()
        cmd.CommandText = "Update_backupfolder"
        cmd.Parameters.Add("@bkd", OleDb.OleDbType.VarChar).Value = fd.SelectedPath.ToString

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()

            cmd.CommandTimeout = 5000
            cmd.CommandText = "Backupdatabase"

        Dim fn1 As String
        Dim FN2 As String
            fn1 = Application.StartupPath & "\BACKUP\AMRUTH_II_Backup_" & DbName & "_" & DeScriptRS(Firm.FirmID) & "_" & SysDt.DayOfWeek.ToString & ".Bak"
            FN2 = fd.SelectedPath.ToString & "\AMRUTH_II_Backup_" & DbName & "_" & DeScriptRS(Firm.FirmID) & "_" & SysDt.DayOfWeek.ToString & ".Bak"

        If Not IO.Directory.Exists(Application.StartupPath & "\BACKUP") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\BACKUP")
        End If

        If IO.File.Exists(fn1) Then
            IO.File.Delete(fn1)
        End If

        cmd.Parameters.Add("@fn", OleDb.OleDbType.VarChar).Value = fn1
            cmd.Parameters.Add("@DBNAME", OleDb.OleDbType.VarChar).Value = DbName
        cmd.ExecuteNonQuery()

        If IO.File.Exists(FN2) Then
            IO.File.Delete(FN2)
        End If

        If Not IO.Directory.Exists(fd.SelectedPath.ToString) Then
            IO.Directory.CreateDirectory(fd.SelectedPath.ToString)
        End If

            IO.File.Copy(fn1, FN2)
            bakflg = True
        Catch ex As Exception
            MsgBox(ex.Message)
            bakflg = False
        End Try
    End Sub

    
    Private Sub bw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        TakeBackup()

    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        pbar.Style = ProgressBarStyle.Blocks
        If bakflg Then
            Label2.ForeColor = Color.Black
            Label2.Text = "Backup completed."
        Else
            Label2.Text = "Backup Error."
            Label2.ForeColor = Color.Red
        End If

        Cancel_Button.Enabled = True
        OK_Button.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
End Class
