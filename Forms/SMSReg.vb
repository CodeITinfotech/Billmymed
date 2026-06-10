Public Class SMSReg

    Private CustCode
    Private PrdCode
    Private EditCust As Boolean
    Dim obj As Object
    Dim objP As Object
    Dim PrCode

    Private Sub SMSReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Clearform()
            txtCust.Focus()
            rdbCust.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Private Sub Clearform()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim da1 As New OleDb.OleDbDataAdapter
            Dim DS As New DataSet
            Dim DS1 As New DataSet

            cmd.Connection = Conn
            cmd1.Connection = Conn

            dgProd.Rows.Clear()
            txtCust.Text = "" : txtProd.Text = "" : lblCPlc.Text = "" : lblPPck.Text = ""
            txtCust.Focus()
            EditCust = False
            dgSupp.Visible = False
            dgCust.Visible = False
            dgProd.Visible = False
            dgPrd.Visible = False
            ChkSMS.Checked = False
            ChkEmail.Checked = False
            txtMob.Text = ""
            txtEmail.Text = ""
            rdbCust.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        Try
            Clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim i As Integer
            cmd.Connection = Conn

            If txtCust.Text = "" Then
                MsgBox("Customer name can't be blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If txtProd.Text = "" Then
                MsgBox("Product name can't be blank", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If ChkSMS.Checked = True Then
                If txtMob.Text = "" Then
                    MsgBox("Mobile No. Required", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If

            If ChkEmail.Checked = True Then
                If txtEmail.Text = "" Then
                    MsgBox("Email Id Required", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If

            If EditCust = True Then
                For i = 0 To dgProd.Rows.Count - 1
                    cmd.CommandText = "Delete from SMSRegistry where PCode='" & PrdCode & "'" & _
                        " and CusCode='" & CustCode & "'"
                    cmd.ExecuteNonQuery()
                Next
            End If

            cmd.CommandText = "Insert into SMSRegistry(CusCode,PCode,BySMS,ByEmail,CustType) values('" & CustCode & "'," & _
                "'" & PrdCode & "','" & ChkSMS.Checked & "','" & ChkEmail.Checked & "'," & IIf(rdbCust.Checked, "'" & "C" & "'", "'" & "L" & "'") & ")"
            cmd.ExecuteNonQuery()
            Clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCust_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCust.TextChanged
        Try
            obj = txtCust
            PopulateCust()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PopulateCust()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet
            If rdbCust.Checked = True Then
                If obj.text <> "" Then
                    cmd.Connection = Conn
                    cmd.CommandText = "Select AcCode as [Code],AcName as [Customer Name],Place,Email,mob from Acmaster where AcName like '" & obj.text & "' + '%' AND GRPCODE=" & CustGrpcode & ""

                    da.SelectCommand = cmd
                    da.Fill(ds, "Acmaster")
                    dgCust.DataSource = ds.Tables("Acmaster")

                    '  dgCust.Columns(0).Width = 100
                    dgCust.Columns(1).Width = 250
                    dgCust.Columns(2).Width = 150

                    dgCust.Columns(0).Visible = False

                    If (dgCust.Rows.Count >= 1) Then
                        dgCust.Visible = True
                        dgCust.Focus()
                        Exit Sub
                    End If
                End If
            ElseIf rdbLoyaltyCust.Checked = True Then
                If obj.text <> "" Then
                    cmd.Connection = Conn
                    cmd.CommandText = "select cardno,name,Emailid,phone from CardDetails where name like '" & obj.text & "%'"

                    da.SelectCommand = cmd
                    da.Fill(ds, "CardDetails")
                    dgCust.DataSource = ds.Tables("CardDetails")

                    '  dgCust.Columns(0).Width = 100
                    dgCust.Columns(1).Width = 250
                    dgCust.Columns(2).Width = 150
                    dgCust.Columns(3).Width = 150

                    dgCust.Columns(0).Visible = False

                    If (dgCust.Rows.Count >= 1) Then
                        dgCust.Visible = True
                        dgCust.Focus()
                        Exit Sub
                    End If
                End If
            End If
            dgCust.Visible = False
            obj.focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCust_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCust.CellContentClick

    End Sub

    Private Sub dgCust_DoubleClick() Handles dgCust.DoubleClick
        Try
            Dim CCode
            CCode = ""
            If rdbCust.Checked = True Then
                CCode = dgCust.CurrentRow.Cells(0).Value
                txtCust.Text = dgCust.CurrentRow.Cells(1).Value
                txtMob.Text = dgCust.CurrentRow.Cells(4).Value & ""
                txtEmail.Text = dgCust.CurrentRow.Cells(3).Value & ""
            Else
                CCode = dgCust.CurrentRow.Cells(0).Value
                txtCust.Text = dgCust.CurrentRow.Cells(1).Value
                txtMob.Text = dgCust.CurrentRow.Cells(3).Value & ""
                txtEmail.Text = dgCust.CurrentRow.Cells(2).Value & ""
            End If
           

            dgCust.Visible = False
            txtCust.Focus()

            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim dr1 As OleDb.OleDbDataReader
            Dim dr2 As OleDb.OleDbDataReader
            Dim r As Integer

            cmd.Connection = Conn
            cmd1.Connection = Conn
            cmd2.Connection = Conn
            r = 0

            If rdbCust.Checked = True Then
                cmd.CommandText = "Select AcCode,Place,Email,mob from Acmaster where AcCode='" & CCode & "'"
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    lblCPlc.Text = dr("Place")
                    CustCode = dr("AcCode")
                End If
                dr.Close()

                cmd1.CommandText = "Select CusCode,PCode,BySMS,ByEmail from SMSRegistry where CusCode='" & CustCode & "'"
                dr1 = cmd1.ExecuteReader

                If dr1.HasRows Then
                    dgProd.Visible = True
                    dgProd.Rows.Clear()
                    EditCust = True
                    While dr1.Read

                        Dim PCode As String = dr1("PCode")
                        cmd2.CommandText = "Select PrdName from Product where PrdCode=""" & PCode & """"
                        dr2 = cmd2.ExecuteReader

                        If dr2.HasRows Then
                            dr2.Read()
                            dgProd.Rows.Add()
                            dgProd.Item(0, r).Value = dr1("PCode")
                            dgProd.Item(1, r).Value = dr2("PrdName")
                            ChkSMS.Checked = dr1("BySMS")
                            ChkEmail.Checked = dr1("ByEmail")
                        End If
                        r = r + 1
                        dr2.Close()
                    End While
                Else
                    dgProd.Visible = False
                End If
                dr1.Close()
            ElseIf rdbLoyaltyCust.Checked = True Then
                cmd.CommandText = "select cardno,name,Emailid,phone from CardDetails where cardno=" & Val(CCode)
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    CustCode = dr("cardno")
                End If
                dr.Close()

                cmd1.CommandText = "Select CusCode,PCode,BySMS,ByEmail from SMSRegistry where CusCode='" & CustCode & "'"
                dr1 = cmd1.ExecuteReader

                If dr1.HasRows Then
                    dgProd.Visible = True
                    dgProd.Rows.Clear()
                    EditCust = True
                    While dr1.Read

                        Dim PCode As String = dr1("PCode")
                        cmd2.CommandText = "Select PrdName from Product where PrdCode=""" & PCode & """"
                        dr2 = cmd2.ExecuteReader

                        If dr2.HasRows Then
                            dr2.Read()
                            dgProd.Rows.Add()
                            dgProd.Item(0, r).Value = dr1("PCode")
                            dgProd.Item(1, r).Value = dr2("PrdName")
                            ChkSMS.Checked = dr1("BySMS")
                            ChkEmail.Checked = dr1("ByEmail")
                        End If
                        r = r + 1
                        dr2.Close()
                    End While
                Else
                    dgProd.Visible = False
                End If
                dr1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgCust.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                dgCust.Visible = False : obj.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And obj.text <> "" Then
                obj.text = Microsoft.VisualBasic.Left(Trim(obj.text), Len(obj.text) - 1)
                If obj.text = "" Then dgCust.Visible = False : obj.text = "" : obj.focus()
            Else
                obj.text = obj.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgCust_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgCust.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgCust_DoubleClick()
        End If
    End Sub

    Private Sub txtProd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProd.TextChanged
        Try
            objP = txtProd
            PopulateProd()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PopulateProd()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            If objP.text <> "" Then
                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = objP.text


                da.SelectCommand = cmd

                da.Fill(ds, "Product")
                dgPrd.DataSource = ds.Tables("Product")


                ' dgPrd.Columns(0).Width = 100
                dgPrd.Columns(1).Width = 300
                dgPrd.Columns(2).Width = 100

                dgPrd.Columns(0).Visible = False

                If (dgPrd.Rows.Count >= 1) Then
                    dgPrd.Visible = True
                    dgPrd.Focus()
                    Exit Sub
                End If
                dgPrd.Visible = False
                objP.focus()
            End If
            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPrd_DoubleClick() Handles dgPrd.DoubleClick
        Try
            PrCode = ""
            PrCode = dgPrd.CurrentRow.Cells(0).Value
            txtProd.Text = dgPrd.CurrentRow.Cells(1).Value
            dgPrd.Visible = False
            txtProd.Focus()

            Try
                Dim cmd As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader

                cmd.Connection = Conn
                cmd.CommandText = "Select PrdCode,Case1 from Product where PrdCode=""" & PrCode & """"
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    lblPPck.Text = dr("Case1")
                    PrdCode = dr("PrdCode")
                End If
                dr.Close()

                ShowSupplier()
                txtProd.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ShowSupplier()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dr As OleDb.OleDbDataReader

        Try
            dgSupp.Focus()
            cmd.Connection = Conn
            cmd.CommandText = "Select Acmaster.AcCode,Acmaster.AcName as [Reg.Customer],Acmaster.Place as [Place],Acmaster.ph as [Ph:],Acmaster.Person As [Person]" & _
                " from Acmaster,SMSRegistry where SMSRegistry.PCode='" & PrCode & "'" & _
                " and SMSRegistry.CusCode=Acmaster.AcCode order by AcName"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dgSupp.Visible = True
            Else
                dgSupp.Visible = False
            End If
            dr.Close()
            da.SelectCommand = cmd
            da.Fill(ds, "Acmaster")
            dgSupp.DataSource = ds.Tables("Acmaster")

            dgSupp.Columns(1).Width = 250


            dgSupp.Columns(0).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPrd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgPrd.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                dgPrd.Visible = False : objP.focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And objP.text <> "" Then
                objP.text = Microsoft.VisualBasic.Left(Trim(objP.text), Len(objP.text) - 1)
                If objP.text = "" Then dgPrd.Visible = False : objP.text = "" : objP.focus()
            Else
                objP.text = objP.text & UCase(e.KeyChar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPrd_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgPrd.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgPrd_DoubleClick()
        End If
    End Sub

    Private Sub rdbLoyaltyCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbLoyaltyCust.CheckedChanged

    End Sub

    Private Sub rdbCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbCust.CheckedChanged

    End Sub
End Class