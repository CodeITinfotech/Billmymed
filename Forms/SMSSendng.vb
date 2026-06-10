'Imports Amruth_II_Pharma_Retail.SendSMS

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class SMSSendng
    'Inherits System.Web.UI.Page

    Dim obj As Object
    Dim Mob, Code

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub SMSSendng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Private Sub clearform()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            cmd.Connection = Conn
            cmd.CommandText = "Select GrpCode,GrpName from CustGroup order by GrpName"
            da.SelectCommand = cmd
            da.Fill(ds, "CustGroup")
            cmbCustGrp.DisplayMember = "GrpName"
            cmbCustGrp.ValueMember = "GrpCode"
            cmbCustGrp.DataSource = ds.Tables("CustGroup")

            txtText.Text = "" : txtCust.Text = "" : cmbCustGrp.Text = ""
            dgCust.Rows.Clear()
            dgCustNm.Visible = False
            rdbCust.Checked = True
            rdbCust.Enabled = True
            rdbLoyaltyCust.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClr.Click
        clearform()
    End Sub

    Private Sub txtCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCust.GotFocus
        dgCustNm.Focus()
    End Sub

    Private Sub txtCust_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCust.TextChanged
        Try
            obj = txtCust
            PopulateCustomer()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PopulateCustomer()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        'Dim dr As OleDb.OleDbDataReader
        'Dim i As Integer
        Try
            If rdbCust.Checked = True Then
                If obj.text <> "" Then
                    cmd.Connection = Conn
                    cmd.CommandText = "Select AcCode,AcName as [Customer Name],Place,Mob as [Mobile] from Acmaster where AcName like '" & obj.text & "' + '%' AND GRPCODE=3"
                    'dr = cmd.ExecuteReader

                    da.SelectCommand = cmd
                    da.Fill(ds, "Acmaster")
                    dgCustNm.DataSource = ds.Tables("Acmaster")

                    dgCustNm.Columns(0).Visible = False
                    dgCustNm.Columns(1).Width = 250
                    dgCustNm.Columns(2).Width = 100
                    dgCustNm.Columns(3).Width = 150

                    If (dgCustNm.Rows.Count >= 1) Then
                        dgCustNm.Visible = True
                        dgCustNm.Focus()
                        rdbCust.Enabled = False
                        rdbLoyaltyCust.Enabled = False
                        Exit Sub
                    End If

                    dgCustNm.Visible = False
                    rdbCust.Enabled = True
                    rdbLoyaltyCust.Enabled = True
                    obj.Focus()
                    'dgCustNm.Rows.Clear()
                    'If dr.HasRows Then
                    '    dgCustNm.Visible = True
                    '    While dr.Read
                    '        dgCustNm.Rows.Add()
                    '        dgCustNm.Item(0, i).Value = dr("AcCode")
                    '        dgCustNm.Item(1, i).Value = dr("ACName")
                    '        dgCustNm.Item(2, i).Value = dr("Place")
                    '        dgCustNm.Item(3, i).Value = dr("Mob")
                    '        i += 1
                    '    End While
                    'End If
                End If
            ElseIf rdbLoyaltyCust.Checked = True Then
                If obj.text <> "" Then
                    cmd.Connection = Conn
                    cmd.CommandText = "select cardno,name,Emailid,phone from CardDetails where name like '" & obj.text & "%'"

                    da.SelectCommand = cmd
                    da.Fill(ds, "CardDetails")
                    dgCustNm.DataSource = ds.Tables("CardDetails")

                    '  dgCust.Columns(0).Width = 100
                    dgCustNm.Columns(1).Width = 250
                    dgCustNm.Columns(2).Width = 150
                    dgCustNm.Columns(3).Width = 150

                    dgCustNm.Columns(0).Visible = False

                    If (dgCustNm.Rows.Count >= 1) Then
                        dgCustNm.Visible = True
                        dgCustNm.Focus()
                        rdbCust.Enabled = False
                        rdbLoyaltyCust.Enabled = False
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCustNm_DoubleClick() Handles dgCustNm.DoubleClick
        Try
            Mob = "" : Code = ""
            If rdbCust.Checked = True Then
                Code = dgCustNm.CurrentRow.Cells(0).Value
                Mob = dgCustNm.CurrentRow.Cells(3).Value
                txtCust.Text = dgCustNm.CurrentRow.Cells(1).Value
            ElseIf rdbLoyaltyCust.Checked = True Then
                Code = dgCustNm.CurrentRow.Cells(0).Value
                Mob = dgCustNm.CurrentRow.Cells(3).Value
                txtCust.Text = dgCustNm.CurrentRow.Cells(1).Value
            End If
            dgCustNm.Visible = False
            rdbCust.Enabled = True
            rdbLoyaltyCust.Enabled = True
            txtCust.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCustNm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgCustNm.KeyDown
        Try
            If e.KeyCode = 27 Then
                dgCustNm.Visible = False
                rdbCust.Enabled = True
                rdbLoyaltyCust.Enabled = True
                txtCust.Text = ""
                txtCust.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCustNm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgCustNm.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                dgCustNm.Visible = False : rdbCust.Enabled = True : rdbLoyaltyCust.Enabled = True : obj.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.text <> "" Then
                obj.text = Microsoft.VisualBasic.Left(Trim(obj.text), Len(obj.text) - 1)
                If obj.text = "" Then dgCustNm.Visible = False : rdbCust.Enabled = True : rdbLoyaltyCust.Enabled = True : obj.text = "" : obj.focus()

            Else
                obj.text = obj.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCustNm_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgCustNm.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgCustNm_DoubleClick()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

            If txtCust.Text <> "" Then
                dgCust.Rows.Add(Code, txtCust.Text, Mob)
            End If

            txtCust.Text = ""
            txtCust.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub dgCustNm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustNm.CellContentClick

    End Sub

    Private Sub btnCustGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustGrp.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader

            cmd.Connection = Conn
            cmd.CommandText = "Select AcCode,AcName,Email from Acmaster where CGrpCode='" & cmbCustGrp.SelectedValue & "'"
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    dgCust.Rows.Add(dr("AcCode"), dr("AcName"), dr("Email"))
                End While
            End If
            cmbCustGrp.Text = ""
            cmbCustGrp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSend.Click
        DoSMS()
    End Sub

    Sub DoSMS()
        'Inherits System.Web.UI.Page
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sURL As String
        Dim objReader As StreamReader
        Try
            'Me.Cursor = Cursors.WaitCursor
            '9422063290 dgCust.Item(2, i).Value).ToString
            cmd.Connection = Conn
            cmd.CommandText = "Select MobUserName,MobPassword,SenderId,Transactional from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")
            For i = 0 To dgCust.Rows.Count - 1
                sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" & dt.Rows(0).Item("MobUserName") & _
                    "&password=" & dt.Rows(0).Item("MobPassword") & _
                    "&msisdn=" & (dgCust.Item(2, i).Value).ToString & _
                    "&sid=" & dt.Rows(0).Item("SenderId") & _
                    "&msg=" & txtText.Text & _
                    "&fl=0"
                '& _
                '"&gwid=2"
                Dim request As WebRequest
                request = WebRequest.Create(sURL)
                request.Credentials = CredentialCache.DefaultCredentials
                Dim response As WebResponse = request.GetResponse()
                Dim objStream As Stream
                objStream = request.GetResponse.GetResponseStream()
                objReader = New StreamReader(objStream)
                Dim responseFromServer As String = objReader.ReadToEnd()
                Console.WriteLine(responseFromServer)
                objReader.Close()
                response.Close()
                'response.Write(objReader.ReadToEnd())
                'objReader.Close()
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class

