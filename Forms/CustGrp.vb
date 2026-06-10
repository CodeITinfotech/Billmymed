Public Class CustGrp
    Private Adding As Boolean
    Private Selected As Boolean
    Private obj As Object

    Private Sub Txtname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtdept.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub PopulateDept()
        Dim prodstr As String
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet

        prodstr = obj.text
        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()

        If obj.Text <> "" Then

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Populate_CustGrp"
            cmd.Parameters.Add("@Deptname", OleDb.OleDbType.VarChar).Value = prodstr


            da.SelectCommand = cmd
            da.Fill(ds, "CustGrp")
            Dg.DataSource = ds.Tables("CustGrp")

            If ds.Tables("CustGrp").Rows.Count = 0 Then

                pnl.Visible = False
                obj.SelectionStart = Len(obj.Text)
                obj.Focus()
                If Not Adding Then
                    Txtdept.Text = ""
                End If
                Exit Sub

            End If


            Dg.Columns(0).Width = 0
            Dg.Columns(0).Visible = False
            Dg.Columns(1).Width = 280

            pnl.Visible = False

            Dg.DefaultCellStyle.ForeColor = Color.Black
            Dg.DefaultCellStyle.BackColor = Color.White

            If (Dg.Rows.Count >= 1) Then
                pnl.Visible = True
                Dg.Focus()
                Exit Sub
            End If
        End If

        pnl.Visible = False


        If Not Adding Then
            obj.Text = ""

        Else
            obj.Focus()
            obj.SelectionStart = Len(obj.Text)

        End If
        obj.Focus()

    End Sub

    Private Sub Createcode()
        Dim cmd As New OleDb.OleDbCommand
        'Dim nm As String
        Dim x As Long
        cmd.Connection = Conn

        cmd.CommandText = "SELECT MAX(grpCODE) AS [newcode] FROM CustGroup "

        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
        If dataredr.HasRows Then
            dataredr.Read()
            If Val(dataredr.Item(0) & "") = 0 Then x = 1 Else x = Val(dataredr("newcode") & "") + 1
            Selected = True
        Else
            x = 1
        End If
        Txtcode.Text = x
    End Sub

    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdept.TextChanged
        If Selected = True Then Exit Sub
        obj = Txtdept
        PopulateDept()
    End Sub

    Private Sub getdept(ByVal prodcode As String)
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GET_CustGrp"
        cmd.Parameters.Add("@code", OleDb.OleDbType.Integer).Value = prodcode
        Selected = True
        Dim Dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
        cmd.Parameters.Clear()
        If Dataredr.HasRows Then
            Dataredr.Read()
            Txtcode.Text = Dataredr("GrpCODE")
            Txtdept.Text = Dataredr("Grpname")
            Txtremark.Text = Dataredr("REMARK") & ""

        End If
        Txtdept.Focus()
        Txtdept.SelectionStart = Len(Txtdept.Text)
        Tsbdelete.Enabled = True
        Tsbclear.Enabled = True
    End Sub
    Private Sub Getinfo()
        pnl.Visible = False

        If Not Adding Then

            getdept(Dg.Item(0, Dg.CurrentCell.RowIndex).Value)
        Else
            Txtdept.Focus()
            Txtdept.SelectionStart = Len(Txtdept.Text)

        End If

    End Sub

    Private Sub Dg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg.DoubleClick
        Getinfo()
    End Sub

    Private Sub Dg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dg.KeyPress
        If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

        If Asc(e.KeyChar) = 13 Then
            Exit Sub
        End If

        If Asc(e.KeyChar) = 9 Then Exit Sub

        If Asc(e.KeyChar) = 27 Then
            pnl.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
        End If

        If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
            obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
            If obj.Text = "" Then pnl.Visible = False : obj.Text = "" : obj.Focus()
        Else
            obj.Text = obj.Text & UCase(e.KeyChar)
        End If
    End Sub

    Private Sub Dg_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Dg.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            getinfo()
        End If
    End Sub
    Private Sub Save()
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        If Adding = True Then
            Createcode()
        End If

        cmd.CommandType = CommandType.StoredProcedure
        If Adding Then
            cmd.Parameters.Add("@Flg", OleDb.OleDbType.BigInt).Value = 1
        Else
            cmd.Parameters.Add("@Flg", OleDb.OleDbType.BigInt).Value = 2
        End If
        cmd.Parameters.Add("@Grpcode", OleDb.OleDbType.BigInt).Value = Val(Txtcode.Text)
        cmd.Parameters.Add("@Grpname", OleDb.OleDbType.VarChar).Value = Txtdept.Text
        cmd.Parameters.Add("@remark", OleDb.OleDbType.VarChar).Value = Txtremark.Text


        cmd.CommandText = "InUp_CustGrp"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()

        If Adding Then
            Tsbclear.PerformClick()
            Tsbadd.PerformClick()
        Else
            Tsbclear.PerformClick()
            Txtcode.Text = ""
            Txtdept.Text = ""
            Txtremark.Text = ""
            Selected = False
            Txtdept.Select()
            Txtdept.Focus()
        End If
    End Sub

    Private Sub Tsbsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbsave.Click
        If Txtdept.Text = "" Then
            MsgBox("Customer Group is blank..!", MsgBoxStyle.Information)
            Txtdept.Select()
            Exit Sub
        End If
        Save()
    End Sub

    Private Sub Tsbadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbadd.Click
        Add()
    End Sub
    Private Sub Clearform()
        Txtcode.Text = ""
        Txtdept.Text = ""
        Txtremark.Text = ""
        Adding = False
        Selected = False
        Txtdept.Select()
        Txtdept.Focus()
        lblcap.Text = "Please Select a Customer Group.."
        Tsbdelete.Enabled = False
        Tsbclear.Enabled = True
        tsbadd.Enabled = True

    End Sub
    Private Sub Delete()
        If Txtdept.Text = "" Then
            MsgBox("Please Select A Customer Group..!", MsgBoxStyle.Exclamation)
        Else
            If MsgBox("Want To Delete The Customer Group : ' " & Txtdept.Text & " ' From Customer Group Master ...? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        End If

        Dim Cmd As New OleDb.OleDbCommand
        Dim Cmd1 As New OleDb.OleDbCommand
        Cmd.Connection = Conn
        Cmd1.Connection = Conn
        'Cmd.CommandText = "SELECT * FROM EMPMASTER WHERE DEPCODE='" & Txtcode.Text & "'"
        'Dim Dataredr As OleDb.OleDbDataReader = Cmd.ExecuteReader()
        'If Dataredr.HasRows Then
        'MsgBox("Transaction Exists! You Cannot Delete..!", MsgBoxStyle.Information)
        'Exit Sub
        'Else
        Cmd1.CommandText = "DELETE FROM CustGrp WHERE GRPCODE='" & Txtcode.Text & "'"
        Cmd1.ExecuteNonQuery()
        Clearform()
        'End If
    End Sub
    Private Sub Add()

        Selected = False
        Tsbdelete.Enabled = False
        Tsbclear.Enabled = True
        Tsbadd.Enabled = False

        Adding = True
        Txtcode.Text = ""
        Txtdept.Text = ""
        Txtremark.Text = ""
        Txtdept.Select()
        Txtdept.Focus()
        lblcap.Text = "Add New Customer Group"
    End Sub

    Private Sub Department_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txtdept.Focus()
        Txtdept.Select()
        Clearform()
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.Wheat
        ToolStrip1.Renderer = renderer
    End Sub

    Private Sub Tsbdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbdelete.Click
        Delete()
    End Sub

    Private Sub Tsbclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbclear.Click
        Clearform()
    End Sub

    Private Sub Tsbexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbexit.Click
        exitform()
    End Sub
    Private Sub Exitform()
        'If MsgBox("Want To 'Exit' From Department Master...?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
        Me.Close()
    End Sub
End Class