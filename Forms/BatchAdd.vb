Imports System.Math

Public Class BatchAdd

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ClearAll()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim TaxTbl As New DataTable
        cmd.CommandText = "select batch from batch  where prdcode=""" & Me.Tag & """ "
        DA.SelectCommand = cmd
        cmd.Connection = Conn
        DA.Fill(DS, "Batch")
        cbbat.DisplayMember = "Batch"
        cbbat.ValueMember = "Batch"
        cbbat.DataSource = DS.Tables("Batch")

        cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' order by seq"
        DA.SelectCommand = cmd
        DA.Fill(TaxTbl)
        cbSVat.DataSource = TaxTbl
        cbSVat.DisplayMember = "taxper"

        GetPacking()

        cmd.CommandText = "select st from product where prdcode=""" & Me.Tag & """ "
        cbSVat.Text = Format(Val(cmd.ExecuteScalar), "0.00")
    End Sub

    Private Sub GetPacking()
        Dim cmd As New OleDb.OleDbCommand
        Dim unittab1 As New DataTable
        Try
            unittab1.TableName = "Pack"
            unittab1.Columns.Add()
            unittab1.Columns(0).ColumnName = "unit"
            unittab1.Columns.Add()
            unittab1.Columns(1).ColumnName = "Case"

            cmd.Connection = Conn
            cmd.CommandText = "Select case1,case2,case3,unit1,unit2,unit3 from product where prdcode=""" + Me.Tag + """ "
            'ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()

                cbPUnit.DataSource = Nothing

                unittab1.Rows.Add(Round(dataredr.Item("unit1"), 0), dataredr.Item("case1"))

                If dataredr.Item("unit2") <> 0 Then
                    unittab1.Rows.Add(Round(dataredr.Item("unit2"), 0), dataredr.Item("case2"))
                End If

                If dataredr.Item("unit3") <> 0 Then
                    unittab1.Rows.Add(Round(dataredr.Item("unit3"), 0), dataredr.Item("case3"))
                End If

                cbPUnit.ValueMember = "unit"
                cbPUnit.DisplayMember = "Case"
                cbPUnit.DataSource = unittab1

            End If
            dataredr.Close()

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub txtExDt_GotFocus(sender As Object, e As System.EventArgs) Handles txtExDt.GotFocus
        txtExDt.SelectAll()
    End Sub

    Private Sub cbbat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbbat.KeyDown
         If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtExDt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtExDt.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Not ExpDateCheck(txtExDt, False) Then
                txtExDt.Focus()
                txtExDt.SelectAll()
                Exit Sub
            End If
            txtMRP.Focus()
        End If

    End Sub

    Private Sub txtMRP_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMRP.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbPUnit_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbPUnit.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbSVat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbSVat.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Tag = ""
        Me.Close()
    End Sub

End Class