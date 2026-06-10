Public Class AccPostHeads

    Private Sub Account_Posting_Heads_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Account_Posting_Heads_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
      
            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
     

            FillCombo()

            Dim accmd As New OleDb.OleDbCommand
            accmd.Connection = Conn
            accmd.CommandText = "Select Accode,taxper,surch,seq,flag from tax order by flag,seq "
            Dim dataredr As OleDb.OleDbDataReader = accmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read()

                    Select Case Val(dataredr.Item("flag"))
                        Case 1

                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbSalAc1.SelectedValue = dataredr.Item(0)
                                    txtVat1.Text = Format(Val(dataredr.Item(1)), "0.00")
                                Case 2
                                    cbSalAc2.SelectedValue = dataredr.Item(0)
                                    txtVat2.Text = Format(Val(dataredr.Item(1)), "0.00")
                                Case 3
                                    cbSalAc3.SelectedValue = dataredr.Item(0)
                                    txtVat3.Text = Format(Val(dataredr.Item(1)), "0.00")
                                Case 4
                                    cbSalAc4.SelectedValue = dataredr.Item(0)
                                    txtVat4.Text = Format(Val(dataredr.Item(1)), "0.00")
                            End Select
                        Case 2

                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbSalVAc1.SelectedValue = dataredr.Item(0)
                                Case 2
                                    cbSalVAc2.SelectedValue = dataredr.Item(0)
                                Case 3
                                    cbSalVAc3.SelectedValue = dataredr.Item(0)
                                Case 4
                                    cbSalVAc4.SelectedValue = dataredr.Item(0)
                            End Select

                        Case 31
                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbPurAc1.SelectedValue = dataredr.Item(0)
                                Case 2
                                    cbPurAc2.SelectedValue = dataredr.Item(0)
                                Case 3
                                    cbPurAc3.SelectedValue = dataredr.Item(0)
                                Case 4
                                    cbPurAc4.SelectedValue = dataredr.Item(0)
                            End Select
                        Case 32
                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbPurVAc1.SelectedValue = dataredr.Item(0)
                                Case 2
                                    cbPurVAc2.SelectedValue = dataredr.Item(0)
                                Case 3
                                    cbPurVAc3.SelectedValue = dataredr.Item(0)
                                Case 4
                                    cbPurVAc4.SelectedValue = dataredr.Item(0)
                            End Select
                        Case 4
                            cbTFS.SelectedValue = dataredr.Item(0)
                        Case 34
                            cbTFP.SelectedValue = dataredr.Item(0)
                        Case 6
                            cbSA.SelectedValue = dataredr.Item(0)
                        Case 36
                            cbPA.SelectedValue = dataredr.Item(0)
                        Case 50
                            cbcrcd.SelectedValue = dataredr.Item(0)

                        Case 51
                            cbcoup.SelectedValue = dataredr.Item(0)

                        Case 91

                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbcstpur1.SelectedValue = dataredr.Item(0)
                                Case 2
                                    cbcstpur2.SelectedValue = dataredr.Item(0)
                                Case 3
                                    cbcstpur3.SelectedValue = dataredr.Item(0)
                                Case 4
                                    cbcstpur4.SelectedValue = dataredr.Item(0)
                            End Select
                        Case 92
                            Select Case Val(dataredr.Item("seq"))
                                Case 1
                                    cbpurcst1.SelectedValue = dataredr.Item(0)
                                Case 2
                                    cbpurcst2.SelectedValue = dataredr.Item(0)
                                Case 3
                                    cbpurcst3.SelectedValue = dataredr.Item(0)
                                Case 4
                                    cbpurcst4.SelectedValue = dataredr.Item(0)
                            End Select
                    End Select

                Loop
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub FillCombo()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand

        cmd.Connection = Conn

        cmd.CommandText = "select Accode,Acname from Acmaster where grpcode<>1 and grpcode<>2  order by Acname"
        DA.SelectCommand = cmd

        ''VAT1
        DA.Fill(DS, "Acmaster1")
        cbSalAc1.DisplayMember = "AcName"
        cbSalAc1.ValueMember = "AcCode"
        cbSalAc1.DataSource = DS.Tables("Acmaster1")

        DA.Fill(DS, "Acmaster2")
        cbSalVAc1.DisplayMember = "AcName"
        cbSalVAc1.ValueMember = "AcCode"
        cbSalVAc1.DataSource = DS.Tables("Acmaster2")

        DA.Fill(DS, "Acmaster3")
        cbPurAc1.DisplayMember = "AcName"
        cbPurAc1.ValueMember = "AcCode"
        cbPurAc1.DataSource = DS.Tables("Acmaster3")

        DA.Fill(DS, "Acmaster4")
        cbPurVAc1.DisplayMember = "AcName"
        cbPurVAc1.ValueMember = "AcCode"
        cbPurVAc1.DataSource = DS.Tables("Acmaster4")



        DA.Fill(DS, "Acmastercstpur1")
        cbcstpur1.DisplayMember = "AcName"
        cbcstpur1.ValueMember = "AcCode"
        cbcstpur1.DataSource = DS.Tables("Acmastercstpur1")

        DA.Fill(DS, "Acmastercst1")
        cbpurcst1.DisplayMember = "AcName"
        cbpurcst1.ValueMember = "AcCode"
        cbpurcst1.DataSource = DS.Tables("Acmastercst1")


        ''VAT2
        DA.Fill(DS, "Acmaster5")
        cbSalAc2.DisplayMember = "AcName"
        cbSalAc2.ValueMember = "AcCode"
        cbSalAc2.DataSource = DS.Tables("Acmaster5")

        DA.Fill(DS, "Acmaster6")
        cbSalVAc2.DisplayMember = "AcName"
        cbSalVAc2.ValueMember = "AcCode"
        cbSalVAc2.DataSource = DS.Tables("Acmaster6")

        DA.Fill(DS, "Acmaster7")
        cbPurAc2.DisplayMember = "AcName"
        cbPurAc2.ValueMember = "AcCode"
        cbPurAc2.DataSource = DS.Tables("Acmaster7")

        DA.Fill(DS, "Acmaster8")
        cbPurVAc2.DisplayMember = "AcName"
        cbPurVAc2.ValueMember = "AcCode"
        cbPurVAc2.DataSource = DS.Tables("Acmaster8")



        DA.Fill(DS, "Acmastercstpur2")
        cbcstpur2.DisplayMember = "AcName"
        cbcstpur2.ValueMember = "AcCode"
        cbcstpur2.DataSource = DS.Tables("Acmastercstpur2")

        DA.Fill(DS, "Acmastercst2")
        cbpurcst2.DisplayMember = "AcName"
        cbpurcst2.ValueMember = "AcCode"
        cbpurcst2.DataSource = DS.Tables("Acmastercst2")


        ''VAT3
        DA.Fill(DS, "Acmaster9")
        cbSalAc3.DisplayMember = "AcName"
        cbSalAc3.ValueMember = "AcCode"
        cbSalAc3.DataSource = DS.Tables("Acmaster9")

        DA.Fill(DS, "Acmaster10")
        cbSalVAc3.DisplayMember = "AcName"
        cbSalVAc3.ValueMember = "AcCode"
        cbSalVAc3.DataSource = DS.Tables("Acmaster10")

        DA.Fill(DS, "Acmaster11")
        cbPurAc3.DisplayMember = "AcName"
        cbPurAc3.ValueMember = "AcCode"
        cbPurAc3.DataSource = DS.Tables("Acmaster11")

        DA.Fill(DS, "Acmaster12")
        cbPurVAc3.DisplayMember = "AcName"
        cbPurVAc3.ValueMember = "AcCode"
        cbPurVAc3.DataSource = DS.Tables("Acmaster12")

        DA.Fill(DS, "Acmastercstpur3")
        cbcstpur3.DisplayMember = "AcName"
        cbcstpur3.ValueMember = "AcCode"
        cbcstpur3.DataSource = DS.Tables("Acmastercstpur3")

        DA.Fill(DS, "Acmastercst3")
        cbpurcst3.DisplayMember = "AcName"
        cbpurcst3.ValueMember = "AcCode"
        cbpurcst3.DataSource = DS.Tables("Acmastercst3")

        ''VAT4
        DA.Fill(DS, "Acmaster13")
        cbSalAc4.DisplayMember = "AcName"
        cbSalAc4.ValueMember = "AcCode"
        cbSalAc4.DataSource = DS.Tables("Acmaster13")

        DA.Fill(DS, "Acmaster14")
        cbSalVAc4.DisplayMember = "AcName"
        cbSalVAc4.ValueMember = "AcCode"
        cbSalVAc4.DataSource = DS.Tables("Acmaster14")

        DA.Fill(DS, "Acmaster15")
        cbPurAc4.DisplayMember = "AcName"
        cbPurAc4.ValueMember = "AcCode"
        cbPurAc4.DataSource = DS.Tables("Acmaster15")

        DA.Fill(DS, "Acmaster16")
        cbPurVAc4.DisplayMember = "AcName"
        cbPurVAc4.ValueMember = "AcCode"
        cbPurVAc4.DataSource = DS.Tables("Acmaster16")

        DA.Fill(DS, "Acmastercstpur4")
        cbcstpur4.DisplayMember = "AcName"
        cbcstpur4.ValueMember = "AcCode"
        cbcstpur4.DataSource = DS.Tables("Acmastercstpur4")

        DA.Fill(DS, "Acmastercst4")
        cbpurcst4.DisplayMember = "AcName"
        cbpurcst4.ValueMember = "AcCode"
        cbpurcst4.DataSource = DS.Tables("Acmastercst4")


        ''TAX FREE
        DA.Fill(DS, "Acmaster17")
        cbTFS.DisplayMember = "AcName"
        cbTFS.ValueMember = "AcCode"
        cbTFS.DataSource = DS.Tables("Acmaster17")

        DA.Fill(DS, "Acmaster18")
        cbTFP.DisplayMember = "AcName"
        cbTFP.ValueMember = "AcCode"
        cbTFP.DataSource = DS.Tables("Acmaster18")



        ''OTHERS
        DA.Fill(DS, "Acmaster19")
        cbSA.DisplayMember = "AcName"
        cbSA.ValueMember = "AcCode"
        cbSA.DataSource = DS.Tables("Acmaster19")

        DA.Fill(DS, "Acmaster20")
        cbPA.DisplayMember = "AcName"
        cbPA.ValueMember = "AcCode"
        cbPA.DataSource = DS.Tables("Acmaster20")


        DA.Fill(DS, "Acmaster21")
        cbcrcd.DisplayMember = "AcName"
        cbcrcd.ValueMember = "AcCode"
        cbcrcd.DataSource = DS.Tables("Acmaster21")

        DA.Fill(DS, "Acmaster22")
        cbcoup.DisplayMember = "AcName"
        cbcoup.ValueMember = "AcCode"
        cbcoup.DataSource = DS.Tables("Acmaster22")

    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        cmd.CommandText = "DELETE FROM TAX "
        cmd.ExecuteNonQuery()

        ''VAT1
        If Val(txtVat1.Text) <> 0 Then
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalAc1.SelectedValue) & "," & _
                Val(txtVat1.Text) & ",0,1,1)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalVAc1.SelectedValue) & "," & _
                Val(txtVat1.Text) & ",0,2,1)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurAc1.SelectedValue) & "," & _
                Val(txtVat1.Text) & ",0,31,1)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurVAc1.SelectedValue) & "," & _
                Val(txtVat1.Text) & ",0,32,1)"
            cmd.ExecuteNonQuery()


            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
               "values(" & Val(cbcstpur1.SelectedValue) & "," & _
               Val(txtVat1.Text) & ",0,91,1)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurcst1.SelectedValue) & "," & _
                Val(txtVat1.Text) & ",0,92,1)"
            cmd.ExecuteNonQuery()



        End If

        cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(2," & _
                 "0,0,0,0)"
        cmd.ExecuteNonQuery()


        ''VAT2
        If Val(txtVat2.Text) <> 0 Then
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalAc2.SelectedValue) & "," & _
                Val(txtVat2.Text) & ",0,1,2)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalVAc2.SelectedValue) & "," & _
                Val(txtVat2.Text) & ",0,2,2)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurAc2.SelectedValue) & "," & _
                Val(txtVat2.Text) & ",0,31,2)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurVAc2.SelectedValue) & "," & _
                Val(txtVat2.Text) & ",0,32,2)"
            cmd.ExecuteNonQuery()


            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
            "values(" & Val(cbcstpur2.SelectedValue) & "," & _
            Val(txtVat2.Text) & ",0,91,2)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbpurcst2.SelectedValue) & "," & _
                Val(txtVat2.Text) & ",0,92,2)"
            cmd.ExecuteNonQuery()
        End If

        ''VAT3
        If Val(txtVat3.Text) <> 0 Then
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalAc3.SelectedValue) & "," & _
                Val(txtVat3.Text) & ",0,1,3)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalVAc3.SelectedValue) & "," & _
                Val(txtVat3.Text) & ",0,2,3)"

            cmd.ExecuteNonQuery()


            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurAc3.SelectedValue) & "," & _
                Val(txtVat3.Text) & ",0,31,3)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurVAc3.SelectedValue) & "," & _
                Val(txtVat3.Text) & ",0,32,3)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
            "values(" & Val(cbcstpur3.SelectedValue) & "," & _
            Val(txtVat3.Text) & ",0,91,3)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbpurcst3.SelectedValue) & "," & _
                Val(txtVat3.Text) & ",0,92,3)"
            cmd.ExecuteNonQuery()
        End If

        ''VAT4
        If Val(txtVat4.Text) <> 0 Then
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalAc4.SelectedValue) & "," & _
                Val(txtVat4.Text) & ",0,1,4)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbSalVAc4.SelectedValue) & "," & _
                Val(txtVat4.Text) & ",0,2,4)"

            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurAc4.SelectedValue) & "," & _
             Val(txtVat4.Text) & ",0,31,4)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbPurVAc4.SelectedValue) & "," & _
                Val(txtVat4.Text) & ",0,32,4)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
        "values(" & Val(cbcstpur4.SelectedValue) & "," & _
        Val(txtVat4.Text) & ",0,91,4)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into tax (AcCode,TaxPer,Surch,flag,seq) " & _
                "values(" & Val(cbpurcst4.SelectedValue) & "," & _
                Val(txtVat4.Text) & ",0,92,4)"
        End If

        ''TAX FREE
        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
            "values(" & Val(cbTFS.SelectedValue) & ",4,1)"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
             "values(" & Val(cbTFP.SelectedValue) & ",34,1)"
        cmd.ExecuteNonQuery()

        ''OTHERS
        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
           "values(" & Val(cbSA.SelectedValue) & ",6,1)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
            "values(" & Val(cbPA.SelectedValue) & ",36,1)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
           "values(" & Val(cbcrcd.SelectedValue) & ",50,1)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "insert into tax (AcCode,flag,seq) " & _
        "values(" & Val(cbcoup.SelectedValue) & ",51,1)"
        cmd.ExecuteNonQuery()
        Me.Close()
    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub PanAccPHeads_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanAccPHeads.Paint

    End Sub
End Class