Public Class BarcodeEntry

    Private Obj As Object
    Private a, b
    Private Barcd, Editcd, Editgrd As Boolean
    Dim PCode = ""

    Private Sub BarcodeEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim DS As New DataSet
            cmd.Connection = Conn

            dgBarcode.Rows.Clear()
            txtProd.Text = "" : txtProd.Focus()
            txtCase1.Text = "" : txtUnit1.Text = "" : txtSearch.Text = "" : txtEdit.Text = ""
            txtEdit.Visible = False : DgProdSer.Visible = False
            Barcd = False : Editcd = False : Editgrd = False
            dgBarcode.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            'Dim dr As OleDb.OleDbDataReader
            Dim i As Integer

            cmd.Connection = Conn
            cmd1.Connection = Conn

            If txtProd.Text = "" Then
                MsgBox("Select a product..", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'PCode = ""
            'cmd1.CommandText = "Select PrdCode from Product where PrdName='" & txtProd.Text & "'"
            'dr = cmd1.ExecuteReader

            'If dr.HasRows Then
            '    dr.Read()
            '    PCode = dr("PrdCode")
            'End If
            'dr.Close()

            If Editcd = True Then
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "Delete Barcodes where PrdCode=""" & PCode & """"
                cmd.ExecuteNonQuery()
            End If

            For i = 0 To dgBarcode.Rows.Count - 2
                cmd.CommandText = "Insert into Barcodes(PrdCode, BarCode) values(""" & PCode & """,""" & dgBarcode.Item(0, i).Value & """)"
                cmd.ExecuteNonQuery()
            Next i
            clearform()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        Try
            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        Dim dr1 As OleDb.OleDbDataReader
        Dim PrdNm = ""
        cmd.Connection = Conn
        cmd1.Connection = Conn

        If e.KeyCode = Keys.Enter Then
            Select Case dgBarcode.CurrentCell.ColumnIndex
                Case 0
                    If txtEdit.Text = "" Then Application.DoEvents() : txtEdit.Focus() : Exit Sub
                    a = txtEdit.Text

                    cmd.CommandText = "Select BarCode,PrdCode from Barcodes where BarCode=""" & a & """ AND PRDCODE<>""" & PCode & """"
                    dr = cmd.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        cmd1.CommandText = "Select PrdName from Product where PrdCode=""" & dr("PrdCode") & """"
                        dr1 = cmd1.ExecuteReader
                        dr1.Read()
1:                      PrdNm = dr1("PrdName")

                        MsgBox("Barcode already existing for the Product " & PrdNm, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                        a = ""
                        txtEdit.Focus()
                        dr1.Close()
                        Exit Sub
                    Else
                        If txtEdit.Text <> "" Then
                            If dgBarcode.CurrentCell.RowIndex = dgBarcode.Rows.Count - 1 Then
                                dgBarcode.Rows.Add(a)
                                dgBarcode.FirstDisplayedScrollingColumnIndex = 0
                            Else
                                dgBarcode.Item(dgBarcode.CurrentCell.ColumnIndex, dgBarcode.CurrentRow.Index).Value = a
                                txtEdit.Visible = False
                            End If
                        End If
                    End If
                    dr.Close()
                    txtEdit.Text = ""
                    dgBarcode.Focus()
                    ShowEditControl(txtEdit)

            End Select
        End If
    End Sub

    Private Sub ShowEditControl(ByVal cntrol As Object)
        Try
            Dim WD As Integer
            WD = 0

            cntrol.location = dgBarcode.Location
            cntrol.top = dgBarcode.Top + dgBarcode.GetRowDisplayRectangle(dgBarcode.CurrentCell.RowIndex, True).Top
            cntrol.left = dgBarcode.Left + dgBarcode.GetColumnDisplayRectangle(dgBarcode.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgBarcode.GetColumnDisplayRectangle(dgBarcode.CurrentCell.ColumnIndex, True).Width

            If Barcd = False Then
                cntrol.text = dgBarcode.CurrentCell.Value & ""
            Else
                dgBarcode.CurrentCell.Value = cntrol.text
            End If

            cntrol.visible = True
            cntrol.enabled = True
            cntrol.focus()
            dgBarcode.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        Try
            Dim cmd As New OleDb.OleDbCommand
            'Dim dr As OleDb.OleDbDataReader
            cmd.Connection = Conn

            If Asc(e.KeyChar) = 27 Then
                If dgBarcode.CurrentRow.Index = dgBarcode.RowCount - 1 Then
                    RowClear()
                    txtEdit.Text = ""
                    txtEdit.Visible = False
                    dgBarcode.Enabled = True
                    dgBarcode.Focus()
                Else
                    txtEdit.Visible = False
                    dgBarcode.Enabled = True
                    dgBarcode.Focus()
                End If
            End If

            If Asc(e.KeyChar) = 13 Then
                Select Case dgBarcode.CurrentCell.ColumnIndex
                    Case 0
                        dgBarcode.Item(dgBarcode.CurrentCell.ColumnIndex, dgBarcode.CurrentRow.Index).Value = a
                        txtEdit.Visible = False
                        If dgBarcode.CurrentCell.RowIndex = dgBarcode.Rows.Count - 1 Then
                            RowClear()
                            txtEdit.Text = ""
                            dgBarcode.Enabled = True
                            dgBarcode.Focus()
                            ShowEditControl(txtEdit)
                        Else
                            txtEdit.Visible = False
                            dgBarcode.Enabled = True
                            dgBarcode.Focus()
                        End If
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RowClear()
        For i As Integer = 0 To dgBarcode.ColumnCount - 1
            dgBarcode.Item(i, dgBarcode.CurrentRow.Index).Value = ""
        Next
    End Sub

    Private Sub dgBarcode_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBarcode.CellDoubleClick
        dgBarcode_DoubleClick()
    End Sub

    Private Sub dgBarcode_DoubleClick() Handles dgBarcode.DoubleClick
        If Barcd = False Then
            EditGrid()
        End If
    End Sub

    Private Sub EditGrid()
        Try
            Dim EDROW As Integer = dgBarcode.CurrentCell.RowIndex
            Dim EDCOL As Integer = dgBarcode.CurrentCell.ColumnIndex

            If dgBarcode.CurrentCell.ColumnIndex = 0 Then
                dgBarcode.Columns(0).Selected = True
                dgBarcode.CurrentCell = dgBarcode.Item(dgBarcode.CurrentCell.ColumnIndex, dgBarcode.CurrentRow.Index)
                ShowEditControl(txtEdit)
                txtEdit.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
  
    'Private Sub txtProd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd.TextChanged
    '    'Try

    '    '    If txtProd.Text <> "" Then
    '    '        Obj = txtProd
    '    '        Populate()
    '    '    End If

    '    'Catch ex As Exception
    '    '    MessageBox.Show(ex.Message)
    '    'End Try
    'End Sub

    Private Sub Populate()
        Try

            If Obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand
                Dim da As New OleDb.OleDbDataAdapter
                Dim DS As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = Obj.text

                da.SelectCommand = cmd
                da.Fill(DS, "Product")

                DgProdSer.DataSource = DS.Tables("Product")

                If txtProd.Text <> "" Then
                    DgProdSer.Visible = True
                    DgProdSer.Enabled = True
                    DgProdSer.Focus()
                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If

            DgProdSer.Visible = False
            Obj.focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtProd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProd.TextChanged
        Try
            If Barcd = True Then Exit Sub
            If txtProd.Text <> "" Then
                Obj = txtProd
                Populate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgProd_DoubleClick() Handles DgProdSer.DoubleClick
        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim cmd1 As New OleDb.OleDbCommand
            Dim cmd2 As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim da As New OleDb.OleDbDataAdapter
            Dim DS As New DataSet
            Dim Prdcd

            Barcd = True
            cmd.Connection = Conn
            cmd1.Connection = Conn
            cmd2.Connection = Conn

            DgProdSer.Visible = True

            PCode = DgProdSer.CurrentRow.Cells(0).Value
            txtProd.Text = DgProdSer.CurrentRow.Cells(1).Value
            txtCase1.Text = DgProdSer.CurrentRow.Cells(3).Value

            'cmd.CommandText = "Select PrdCode, PrdName, Case1, Case2, Unit1, Unit2, RackNo from Product"
            'dr = cmd.ExecuteReader
            'dr.Read()

            'DgProdSer.CurrentRow.Cells(0).Value = dr("PrdCode")
            'DgProdSer.CurrentRow.Cells(1).Value = dr("PrdName")
            'DgProdSer.CurrentRow.Cells(3).Value = dr("Case1")
            'DgProdSer.CurrentRow.Cells(4).Value = dr("Case2")
            'DgProdSer.CurrentRow.Cells(6).Value = dr("RackNo")
            'txtUnit1.Text = dr("Unit1")

            'dr.Close()
            DgProdSer.Visible = False

            Prdcd = ""
            cmd2.CommandText = "Select Product.PrdCode, BarCodes.PrdCode, Barcodes.BarCode" & _
                " from Barcodes, Product where Barcodes.PrdCode=""" & PCode & """ and Product.PrdCode=Barcodes.Prdcode"
            dr = cmd2.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    Dim Brcd As String = dr("BarCode")

                    dgBarcode.Rows.Add(Brcd)
                    txtEdit.Visible = False
                    txtProd.Focus()

                End While
                Editcd = True
            End If
            dr.Close()
            dgBarcode.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Barcd = False
    End Sub

    Private Sub dgProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgProdSer.KeyDown
        Try
            If e.KeyCode = 27 Then
                DgProdSer.Visible = False
                txtProd.Text = ""
                txtProd.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgProd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgProdSer.KeyPress
        Try

            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 27 Then
                DgProdSer.Visible = False : txtProd.Text = "" : txtProd.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 8 And txtProd.Text <> "" Then
                txtProd.Text = Microsoft.VisualBasic.Left(Trim(txtProd.Text), Len(txtProd.Text) - 1)
                If txtProd.Text = "" Then DgProdSer.Visible = False : txtProd.Focus()
            Else
                txtProd.Text = txtProd.Text & UCase(e.KeyChar)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub GL_GetInfo()
    '    DgProdSer.Visible = False
    '    GetGLCode(DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value)
    '    txtProd.Enabled = True
    '    txtProd.Focus()
    '    txtProd.SelectionStart = Len(txtProd.Text)
    'End Sub

    'Private Sub GetGLCode(ByVal GLCode As String)
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim dr As OleDb.OleDbDataReader

    '    cmd.Connection = Conn
    '    cmd.CommandText = "Select PrdCode, PrdName, Case1 from Product "
    '    dr = cmd.ExecuteReader
    '    If dr.HasRows Then
    '        While dr.Read
    '            txtProd.Text = dr.Item("PrdName") & ""
    '        End While
    '    ElseIf Not dr.HasRows Then
    '        txtProd.Text = ""
    '    End If

    '    dr.Close()
    'End Sub

    Private Sub dgProd_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgProd_DoubleClick()
        End If
    End Sub

    Private Sub dgBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                txtEdit.Visible = False
                dgBarcode.Enabled = True
                dgBarcode.Focus()
                e.Handled = True
            End If

            If e.KeyCode = Keys.Enter Then
                dgBarcode_DoubleClick()
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgBarcode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgBarcode.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            dgBarcode_DoubleClick()
        End If
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                Dim cmd As New OleDb.OleDbCommand
                Dim cmd1 As New OleDb.OleDbCommand
                Dim dr As OleDb.OleDbDataReader
                Dim dr1 As OleDb.OleDbDataReader
                Dim Prdcd

                cmd.Connection = Conn
                cmd1.Connection = Conn

                cmd.CommandText = "Select Product.PrdCode as PrBr,Product.PrdName,Product.Unit1,Product.Case1" & _
                    " from Product,Barcodes where BarCode='" & txtSearch.Text & "' and Product.PrdCode=Barcodes.PrdCode"
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    Prdcd = dr("PrBr")
                Else
                    Prdcd = ""
                End If

                cmd1.CommandText = "Select BarCode from Barcodes where PrdCode=""" & Prdcd & """"
                dr1 = cmd1.ExecuteReader

                dgBarcode.Rows.Clear()
                If dr1.HasRows And dr.HasRows Then
                    While dr1.Read
                        txtProd.Text = dr("PrdName")
                        txtUnit1.Text = dr("Unit1")
                        txtCase1.Text = dr("Case1")
                        dgBarcode.Rows.Add(dr1("BarCode"))
                        DgProdSer.Visible = False
                    End While
                Else
                    txtProd.Text = ""
                    txtUnit1.Text = ""
                    txtCase1.Text = ""
                    dgBarcode.Rows.Clear()
                End If
                dr.Close()
                dr1.Close()
                dgBarcode.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

   
 
    Private Sub dgBarcode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBarcode.CellContentClick

    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged

    End Sub

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub
End Class