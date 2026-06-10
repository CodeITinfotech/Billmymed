Public Class Product
    Private obj As Object
    Private ProdSelected As Boolean
    Private ProdAdding As Boolean
    Private EditCode As Long
    Private TaxTbl As DataTable
    Private EdCol As Integer
    Private EdRow As Integer
    Private TabFlag As Boolean
    Private rtaxary(4, 2) As Double
    Private rptax(4, 2) As Double
    Dim tkv As Long
    Dim ShowAdjOpt As Boolean
    Dim sdetread As Boolean
    Dim mdetread As Boolean
    Private PrdCodeAsBarCode As Boolean

    Private BillOrder As Integer
    Private RndPai As Double
    Private outgoid As Long
    Private UseBarCode As Boolean
    Private UseSalesmanPass As Boolean
    Private ShowPrateInSales As Boolean

    Private Sub dgMTrans_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMTrans.CellDoubleClick
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        If pnlshow.Tag = "Y" Then Exit Sub
        Dim dat1, dat2 As Date
        dat1 = CDate("01/" & Microsoft.VisualBasic.Left(dgMTrans.Item(0, dgMTrans.CurrentCell.RowIndex).Value & "", 3) & "/" & Microsoft.VisualBasic.Right(dgMTrans.Item(0, dgMTrans.CurrentCell.RowIndex).Value & "", 4))
        'If dgSDetails.CurrentCell.ColumnIndex = 10 And (dgSDetails.CurrentCell.Value & "") <> "" Then
        dat2 = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dat1))

        pnlshow.Tag = "Y"

        pnlshow.Width = 100
        cmd.Connection = Conn
        Select Case dgMTrans.CurrentCell.ColumnIndex
            Case 1, 2 'sales
                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [Bill No] ,INVDT as [Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],convert(bigint,QTY) AS Qty,convert(DECIMAL(12,2),SRATE) as [SRate],convert(decimal(12,2),QTY *srate) as Value FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                """ and (type = '21' OR type = '22' OR type = '23' OR type = '25' OR type = '26') and INVDT>=convert(datetime,'" & dat1 & "') and INVDT<=convert(datetime,'" & dat2 & "') "


                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 3, 4 'srtn
                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [SRtn No] ,INVDT as [Sr Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt] ,convert(bigint,QTY) AS Qty,convert(DECIMAL(12,2),SRATE) as [SRate],convert(decimal(12,2),QTY *srate) as Value FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                  """ and (type = '31' OR type = '32' OR type = '33' OR type = '35' OR type = '36') and INVDT>=convert(datetime,'" & dat1 & "') and INVDT<=convert(datetime,'" & dat2 & "') "


                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 11 'TRN

                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [Trn/Rcpt No] ,INVDT as [Trn/Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt] ,convert(bigint,QTY*-1) AS Qty,0 as [Free],0 as [Repl],convert(DECIMAL(12,2),SRATE) as [Rate],convert(decimal(12,2),(QTY*-1)*srate) as Value,'' as [Bill No],null as [Bill Date],'' as [Supplier       ]  FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                    """ and (type = '24') and BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """ union all " & _
                    " SELECT 'TRIN' as [Type],RctNo as [Trn/Rcpt No] ,Pdate as [Trn/Rcpt Date],Batch As [Batch],ExDt,RQty as [Qty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),(rQTY*-1)*Trrate) as Value,BillNo as [Bill No],Billdt as [Bill Date],acmaster.acname as [Supplier       ]  from batch,acmaster WHERE batch.supcode=acmaster.accode and PRDCODE=""" + txtCode.Text & _
                  """ and type = '14'and INVDT>=convert(datetime,'" & dat1 & "') and INVDT<=convert(datetime,'" & dat2 & "') "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 80
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 80
                dgshow.Columns(5).Width = 80
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 80
                dgshow.Columns(8).Width = 80
                dgshow.Columns(9).Width = 80

                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Case 5, 6, 7, 8
                cmd.CommandText = " SELECT (case when type='11' then 'CA' else 'CR' END ) as [Type],RctNo as [Rcpt No] ,Pdate as [Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],RQty as [Qty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),rQTY*Trrate) as Value,BillNo as [Bill No],BillDt as [Bill Dt],acmaster.acname as [Supplier       ]  from batch,acmaster WHERE batch.supcode=acmaster.accode and PRDCODE=""" + txtCode.Text & _
                  """ and (type ='12' or type ='11') and Pdate>=convert(datetime,'" & dat1 & "') and Pdate<=convert(datetime,'" & dat2 & "') "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 60
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 60
                dgshow.Columns(8).Width = 60
                dgshow.Columns(9).Width = 80

                dgshow.Columns(10).Width = 80
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                ' dgshow.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                ' dgshow.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight


                'dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight


            Case 9 'prtn


                cmd.CommandText = " SELECT (case when type='12' then 'CA' else 'CR' END ) as [Type],RctNo as [PR/Rcpt No] ,Pdate as [PR/Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],RQty as [RtnQty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),rQTY*TRrate) as Value,BillNo as [Bill No],BillDt as [Bill Dt],acmaster.acname as [Supplier       ]  from BatchRtn,acmaster WHERE BatchRtn.supcode=acmaster.accode   and PRDCODE=""" + txtCode.Text & _
                  """ and (type ='12' or type ='11') and Pdate>=convert(datetime,'" & dat1 & "') and Pdate<=convert(datetime,'" & dat2 & "')  and stkles=1 " & _
                 "union all SELECT 'PR' as [Type],prno as [PR/Rcpt No] ,prdt as [PR/Rcpt Date],Batch As [Batch],ExDt,(EXQTY+BRQTY) as [RtnQty],Fqty as [Free],null as [Repl],convert(DECIMAL(12,2),RATE) as [Rate],convert(decimal(12,2),(EXQTY+BRQTY)*rate),'' as [Bill No],null as [Bill Dt],acmaster.acname as [Supplier       ]  from purchasereturn,acmaster WHERE purchasereturn.supcode=acmaster.accode and  CODE=""" + txtCode.Text & _
                  """  and prdt>=convert(datetime,'" & dat1 & "') and prdt<=convert(datetime,'" & dat2 & "') "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt
                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 80
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 80
                dgshow.Columns(5).Width = 80
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 80
                dgshow.Columns(8).Width = 80
                dgshow.Columns(9).Width = 80

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 10 'adj


                cmd.CommandText = " SELECT  adjdt as [Adj Date    ],batch.Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],qty as [AdjQty],convert(DECIMAL(12,2),batch.Trrate) as [Rate],convert(decimal(12,2),qty*batch.Trrate) as Value, Remarks as [Remarks             ] ,usrname as [User Name ] from batch,stockadj WHERE stockadj.batchid=batch.batchid   and stockadj.prdcode=""" + txtCode.Text & _
                  """   and adjdt>=convert(datetime,'" & dat1 & "') and adjdt<=convert(datetime,'" & dat2 & "') "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 100
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60

                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        End Select

        'cmd.CommandText = "Select OrdNo as [Ord No],OrdDt as [Ord Dt],acmaster.acname + ' ' + acmaster.place  as [Supplier],CONVERT(INT,(Qty/UNIT)) as [Qty],CONVERT(INT,(Free*UNIT)) as [Free] ,Pack from " & _
        '    "pndord,acmaster where pndord.supcode=acmaster.accode and pndord.prdcode=""" + _
        '    dgSDetails.Item(2, dgSDetails.CurrentCell.RowIndex).Value + """ "
        Application.DoEvents()
        dgshow.AutoResizeRows()

        If dt.Rows.Count > 0 Then
            'dgshow.ScrollBars = ScrollBars.None
            Dim v As Long = 500
            Dim vw As Long = 26
            Dim VI As Long
            pnlshow.Width = 20
            For I = 0 To dgshow.Columns.Count - 1
                pnlshow.Width = pnlshow.Width + dgshow.Item(I, 0).Size.Width
                'dgshow.Width = dgshow.Width + dgshow.Item(I, 0).Size.Width
            Next



            pnlshow.Top = -250

            pnlshow.Height = 125 - (vw * 2)


            pnlshow.Visible = True
            dgshow.Refresh()
            pnlshow.Left = -275



            For i = 0 To vw Step 2
                pnlshow.Top = pnlshow.Top + 20
                pnlshow.Left = pnlshow.Left + 20
                pnlshow.Height = pnlshow.Height + (i)


                Application.DoEvents()
            Next

            dgshow.Focus()
        Else
            pnlshow.Visible = False

        End If
        pnlshow.Tag = ""
        Exit Sub

    End Sub

    Private Sub FillCombo()

        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn

            cmd.CommandText = "select comcode,comname from Company order by comname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Company")
            cbComp.DisplayMember = "comName"
            cbComp.ValueMember = "comCode"
            cbComp.DataSource = DS.Tables("Company")
            cbComp.SelectedValue = 0
            cbComp.SelectedText = ""


            cmd.CommandText = "select clscode,clsname from Classification order by clsname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Classification")
            cbClass.DisplayMember = "clsName"
            cbClass.ValueMember = "clscode"
            cbClass.DataSource = DS.Tables("Classification")
            cbClass.SelectedValue = 0
            cbClass.SelectedText = ""
            cbClass.Text = ""

            cmd.CommandText = "select prgrp1code,PrGrp1name from PrGroup1 order by PrGrp1name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Grp1")
            CbGrp1.DisplayMember = "PrGrp1Name"
            CbGrp1.ValueMember = "PrGrp1code"
            CbGrp1.DataSource = DS.Tables("Grp1")
            CbGrp1.SelectedValue = 0
            CbGrp1.SelectedText = ""
            CbGrp1.Text = ""

            cmd.CommandText = "select Prgrp2code,PrGrp2name from PrGroup2 order by PrGrp2name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Grp2")
            CbGrp2.DisplayMember = "PrGrp2Name"
            CbGrp2.ValueMember = "PrGrp2code"
            CbGrp2.DataSource = DS.Tables("Grp2")
            CbGrp2.SelectedValue = 0
            CbGrp2.SelectedText = ""
            CbGrp2.Text = ""

            'cmd.CommandText = "select clscode,clsname from Classification order by clsname"
            'DA.SelectCommand = cmd
            'DA.Fill(DS, "Classification")
            'cbClass.DisplayMember = "clsName"
            'cbClass.ValueMember = "clscode"
            'cbClass.DataSource = DS.Tables("Classification")
            'cbClass.SelectedValue = 0
            'cbClass.SelectedText = ""
            'cbClass.Text = ""


            cmd.CommandText = "select Gencode,Genname from Generic order by genname"
            DA.SelectCommand = cmd

            DA.Fill(DS, "Generic1")
            cbGen1.DisplayMember = "GenName"
            cbGen1.ValueMember = "Gencode"
            cbGen1.DataSource = DS.Tables("Generic1")
            cbGen1.SelectedValue = 0
            cbGen1.SelectedText = ""


            DA.Fill(DS, "Generic2")
            cbGen2.DisplayMember = "GenName"
            cbGen2.ValueMember = "Gencode"
            cbGen2.DataSource = DS.Tables("Generic2")
            cbGen2.SelectedValue = 0
            cbGen2.SelectedText = ""


            DA.Fill(DS, "Generic3")
            cbGen3.DisplayMember = "GenName"
            cbGen3.ValueMember = "Gencode"
            cbGen3.DataSource = DS.Tables("Generic3")
            cbGen3.SelectedValue = 0
            cbGen3.SelectedText = ""

            DA.Fill(DS, "Generic4")
            cbGen4.DisplayMember = "GenName"
            cbGen4.ValueMember = "Gencode"
            cbGen4.DataSource = DS.Tables("Generic4")
            cbGen4.SelectedValue = 0
            cbGen4.SelectedText = ""

            DA.Fill(DS, "Generic5")
            cbGen5.DisplayMember = "GenName"
            cbGen5.ValueMember = "Gencode"
            cbGen5.DataSource = DS.Tables("Generic5")
            cbGen5.SelectedValue = 0
            cbGen5.SelectedText = ""

            cmd.CommandText = "select Accode,Acname from  AcMaster where grpcode=" & SupGrpcode & " order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "AcMaster")
            CbEditSupp.DisplayMember = "Acname"
            CbEditSupp.ValueMember = "Accode"
            CbEditSupp.DataSource = DS.Tables("AcMaster")


            cmd.CommandText = "select code,name from racks order by name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "rack")
            cbRack.DisplayMember = "name"
            cbRack.ValueMember = "code"
            cbRack.DataSource = DS.Tables("rack")
            cbRack.SelectedValue = 0
            cbRack.SelectedText = ""
            cbRack.Text = ""

            cmd.CommandText = "select code,name from schedule order by name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "sched")
            cbsch.DisplayMember = "name"
            cbsch.ValueMember = "code"
            cbsch.DataSource = DS.Tables("sched")
            cbsch.SelectedValue = 0
            cbsch.SelectedText = ""
            cbsch.Text = ""

            Me.Cursor = Cursors.Default
        Catch er As Exception
            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub

    Private Sub Product_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then


                If UCase(Me.ActiveControl.Name) = "CBTAXINC" And tsbSave.Enabled Then
                    'tsbSave.Focus()
                    e.Handled = True
                ElseIf Me.ActiveControl.Name = dgBDet.Name Then

                ElseIf Me.ActiveControl.Name = txtEdit.Name Then
                ElseIf Me.ActiveControl.Name = cbEditVat.Name Then
                ElseIf Me.ActiveControl.Name = CbEditSupp.Name Then
                ElseIf Me.ActiveControl.Name = CbEditTaxInc.Name Then
                ElseIf Me.ActiveControl.Name = txtEditDt.Name Then

                ElseIf Me.ActiveControl.Name = BtnOK.Name Then
                    e.Handled = True
                    BtnOK.PerformClick()
                Else
                    System.Windows.Forms.SendKeys.Send("{TAB}")
                    e.Handled = True

                End If

                ' e.Handled = True
            End If

            If e.KeyCode = Keys.F10 Then

                NextProduct(2)
                Application.DoEvents()
                e.Handled = True
            ElseIf e.KeyCode = Keys.F9 Then

                NextProduct(1)
                Application.DoEvents()
                e.Handled = True

            ElseIf e.KeyCode = Keys.K And e.Alt And pnlstk.Visible Then
                UpdateStock()
            ElseIf e.KeyCode = Keys.C And e.Alt And pnlstk.Visible Then
                pnlstk.Visible = False
                txtEdit.Enabled = True
                txtEdit.Focus()
            ElseIf e.KeyCode = Keys.F3 Then
                If UseSalesmanPass Then
                    txtsmcode.Text = ""
                    txtName.Focus()
                End If
            End If

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub Product_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'pnlstk.Parent = Me
        Try
            'FillCombo()
            ClearForm()

            Dim renderer As New clsColorToolstripRenderer
            renderer.BackColor = Color.Wheat
            ToolStrip.Renderer = renderer
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus

    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress

    End Sub

    'Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
    '    ' type only in the Upper case
    '    e.KeyChar = UCase(e.KeyChar)
    'End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If ProdSelected = True Then Exit Sub
        Try
            obj = txtName
            PopulateProduct()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    'Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
    '    ' type only in the Upper case
    '    e.KeyChar = UCase(e.KeyChar)
    'End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        Try
            If ProdSelected = True Then Exit Sub
            obj = txtCode
            PopulateProduct()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub PopulateProduct()
        Try
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = obj.text

                da.SelectCommand = cmd
                da.Fill(ds, "Product")

                DgProdSer.DataSource = ds.Tables("Product")
                If (DgProdSer.Rows.Count - 1) >= 1 Then
                    pnlprod.Visible = True

                    DgProdSer.Focus()

                    Exit Sub
                End If
                pnlprod.Visible = False

                If Not ProdAdding Then
                    'obj.Text = ""
                    obj.SelectionStart = obj.TextLength
                    ' Exit Sub
                Else
                    obj.focus()
                    obj.SelectionStart = Len(obj.Text)
                End If

                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False
            obj.focus()

        Catch d As Exception
            MessageBox.Show(d.Message)


        End Try
    End Sub

    Private Sub DgProdSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgProdSer.KeyPress
        ' Dim Serstr As String
        ' Asci value of ????? is 34
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            'Asci value of Tab is 9
            If Asc(e.KeyChar) = 9 Then Exit Sub

            'Asci value of Enter is 13
            If Asc(e.KeyChar) = 13 Then Exit Sub

            'Asci value of Escape is  27
            If Asc(e.KeyChar) = 27 Then
                pnlprod.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub

            End If

            ' Asci value of Backspace is 8
            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlprod.Visible = False : obj.Text = "" : obj.Focus()
            Else
                obj.Text = obj.Text & UCase(e.KeyChar)
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub DgProdSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        Try
            GetInfo()
            ' BatchDetails()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        Try
            Dim x, x1 As String
            Dim R, C As Integer
            Dim cmd As New OleDb.OleDbCommand
            If e.KeyCode = Keys.Enter Then
                GetInfo()
                cbComp.Focus()
                ' BatchDetails()
            ElseIf e.KeyCode = Keys.F8 Then
                cmd.Connection = Conn
                x = InputBox("Enter Product code to Mearge with ")
                cmd.CommandText = "Select PRDname + ' ' + case1  as [nm] from product where prdcode=""" + x + """ "
                x1 = cmd.ExecuteScalar & ""
                If x1 = "" Then Exit Sub
                If MsgBox("Want to Mearge the product : " & DgProdSer.Item(1, DgProdSer.CurrentCell.RowIndex).Value & _
                           " " & DgProdSer.Item(3, DgProdSer.CurrentCell.RowIndex).Value & " with " & x1, vbYesNo + vbDefaultButton2) = vbNo Then
                    Exit Sub
                End If
                x = UCase(x)
                R = DgProdSer.CurrentRow.Index

                cmd.CommandText = "update batch set prdcode=""" & x & """ where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "update batchRtn set prdcode=""" & x & """ where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "update pndord set prdcode=""" & x & """ where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "update purchasereturn set code=""" & x & """ where code=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()


                cmd.CommandText = "update stockadj set prdcode=""" & x & """ where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "update invdetails set prdcode=""" & x & """ where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()


                cmd.CommandText = "delete from product where prdcode=""" & DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value & """"
                cmd.ExecuteNonQuery()
                PopulateProduct()
                Try
                    If DgProdSer.RowCount - 1 >= R Then
                        DgProdSer.CurrentCell = DgProdSer.Item(0, R)
                    Else
                        DgProdSer.CurrentCell = DgProdSer.Item(0, DgProdSer.RowCount - 1)
                    End If
                Catch ex As Exception

                End Try


            End If


        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub GetInfo()
        Try
            tbCtrl1.Enabled = True
            pnlprod.Visible = False
            If Not ProdAdding Then
                GetProduct(DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            Else
                txtName.Focus()
                txtName.SelectionStart = Len(txtName.Text)
            End If
            BatchDetails(txtCode.Text)
            'salesdetails(txtCode.Text)
            'monthlytransaction()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub GetProduct(ByVal pcode As String)
        Dim cmd As New OleDb.OleDbCommand
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            cmd.CommandText = "Select * from product where prdcode=""" + pcode + """ "
            ProdSelected = True
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                dataredr.Read()
                txtCode.Text = dataredr.Item("PrdCode")
                txtName.Text = dataredr.Item("Prdname")
                cbComp.SelectedValue = dataredr.Item("comcode")
                cbClass.SelectedValue = dataredr.Item("clscode")
                CbGrp1.SelectedValue = Val(dataredr.Item("prgrp1code") & "")
                CbGrp2.SelectedValue = Val(dataredr.Item("prgrp2code") & "")

                Try
                    cbRack.Text = dataredr.Item("RackNo") & ""
                    cbsch.Text = dataredr.Item("Sched") & ""
                Catch ex As Exception

                End Try
              

                txtCST.Text = Format(dataredr.Item("CST"), "0.00")
                txtCase1.Text = dataredr.Item("case1")
                txtCase2.Text = dataredr.Item("case2")
                txtCase3.Text = dataredr.Item("case3") & ""
                txtMfr.Text = dataredr.Item("mfr") & ""

                cbInRpt.Text = Format(dataredr.Item("rptCase") & "")
                Select Case Val(dataredr.Item("rptCase") & "")
                    Case 1
                        radb1.Checked = True
                    Case 2
                        radb2.Checked = True
                    Case 3
                        radb3.Checked = True
                End Select

                txtRol.Text = dataredr.Item("rol")
                txtOrdqty.Text = dataredr.Item("roqty")
                txtMaxqty.Text = dataredr.Item("maxqty")
                txtPndOrd.Text = dataredr.Item("pndord")

                cbvat.Text = Format(dataredr.Item("st"), "0.00")
                txtSrate.Text = Format(dataredr.Item("srate"), "0.0000")
                txtPrate.Text = Format(dataredr.Item("prate"), "0.0000")

                txtGen1.Text = dataredr.Item("strng1") & ""
                txtGen2.Text = dataredr.Item("strng2") & ""
                txtGen3.Text = dataredr.Item("strng3") & ""
                txtGen4.Text = dataredr.Item("strng4") & ""
                txtGen5.Text = dataredr.Item("strng5") & ""

                cbGen1.SelectedValue = dataredr.Item("gencode1")
                cbGen2.SelectedValue = dataredr.Item("gencode2")
                cbGen3.SelectedValue = dataredr.Item("gencode3")
                cbGen4.SelectedValue = dataredr.Item("gencode4")
                cbGen5.SelectedValue = dataredr.Item("gencode5")

                txtNote.Text = dataredr.Item("ordnote") & ""
                txtInvMsg.Text = dataredr.Item("invmsg") & ""
                txtRectMsg.Text = dataredr.Item("Rectmsg") & ""
                txtalias.Text = dataredr.Item("AliasCode") & ""
                txtCreDt.Text = dataredr.Item("credt") & ""
                txtlrd.Text = dataredr.Item("lrd") & ""
                txtLid.Text = dataredr.Item("lid") & ""
                txtUnit2.Text = dataredr.Item("unit2") & ""
                txtUnit3.Text = dataredr.Item("unit3") & ""
                cbTaxinc.Checked = IIf(dataredr.Item("taxinc"), True, False)
                ChkDisc.Checked = False
                If Not IsDBNull(dataredr.Item("nodisc")) Then
                    ChkDisc.Checked = IIf(dataredr.Item("nodisc"), True, False)
                End If


                If Not IsDBNull(dataredr.Item("color")) Then
                    lblcolor.BackColor = Color.FromArgb(dataredr.Item("color"))
                Else
                    lblcolor.BackColor = Color.Black
                End If
                ShowSupplier()
                tsbSave.Enabled = True
                txtName.Focus()
                txtName.SelectionStart = Len(txtName.Text)
            End If
            tsbClear.Enabled = True
            tsbDel.Enabled = True
            tsbAdd.Enabled = False
            lblStatus.Text = ""
            dgMTrans.Rows.Clear()
            dgSDetails.Rows.Clear()

            dataredr.Close()

            cmd.CommandText = "Select Product.PrdCode, BarCodes.PrdCode, Barcodes.BarCode" & _
              " from Barcodes, Product where Barcodes.PrdCode=""" & pcode & """ and Product.PrdCode=Barcodes.Prdcode"
            dataredr = cmd.ExecuteReader
            dgBarcode.Rows.Clear()
            If dataredr.HasRows Then
                While dataredr.Read
                    Dim Brcd As String = dataredr("BarCode")
                    dgBarcode.Rows.Add(Brcd)
                End While

            End If
            dataredr.Close()


            'dgBDet.Rows.Clear()
            Me.Cursor = Cursors.Default
        Catch er As Exception
            Me.Cursor = Cursors.Default
            ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub ClearForm()
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer
        Dim DA As New OleDb.OleDbDataAdapter

        Try
            Me.Cursor = Cursors.WaitCursor
            lblcolor.BackColor = Color.Black
            txtEditDt.Mask = DateMask
            cmd.Connection = Conn
            FillCombo()
            ChkDisc.Checked = False
            dgBarcode.Enabled = True
            lblstk.Text = "0"
            tsbDel.Enabled = False
            cbInRpt.Text = "1"
            txtCode.Text = ""
            txtName.Text = ""
            ProdSelected = False
            'cbClass.Text = "NONE"
            cbClass.SelectedValue = 0
            cbGen1.Text = "NONE"
            cbGen2.Text = "NONE"
            cbGen3.Text = "NONE"
            cbGen4.Text = "NONE"
            cbGen5.Text = "NONE"
            cbRack.Text = ""
            txtMfr.Text = ""
            cbsch.Text = ""
            txtRol.Text = ""
            txtOrdqty.Text = ""
            txtPndOrd.Text = ""
            txtMaxqty.Text = ""
            txtCase1.Text = ""
            txtCase2.Text = ""
            txtCase3.Text = ""
            txtUnit1.Text = "1"
            txtUnit2.Text = ""
            txtUnit3.Text = ""
            txtCST.Text = ""
            cbvat.Text = ""
            txtlrd.Text = ""
            txtLid.Text = ""
            txtCreDt.Text = ""
            txtGen1.Text = ""
            txtGen2.Text = ""
            txtGen3.Text = ""
            txtGen4.Text = ""
            txtGen5.Text = ""
            txtalias.Text = ""
            txtNote.Text = ""
            txtInvMsg.Text = ""
            txtRectMsg.Text = ""
            txtPrate.Text = "0.000"
            txtSrate.Text = "0.000"
            cbTaxinc.Checked = True
            cbComp.SelectedValue = 0
            cbComp.SelectedText = "NONE"
            txtbarcode.Text = ""
            cbComp.Text = ""
            txtCase1.Enabled = True
            txtCase2.Enabled = True
            txtCase3.Enabled = False

            txtUnit1.Enabled = False
            txtUnit2.Enabled = False
            txtUnit3.Enabled = False

            tsbSave.Enabled = False
            tsbAdd.Enabled = True
            txtName.Focus()
            'lblStatus.Visible = False
            ProdAdding = False
            dgSupp.DataSource = Nothing
            dgSupp.Columns.Clear()

            dgSupp.Columns.Add("AcCode", "AcCode")
            dgSupp.Columns.Add("AcName", "Supplier Name")
            dgSupp.Columns.Add("Place", "Place")
            dgSupp.Columns.Add("Ph", "Phone Nos.")
            dgSupp.Columns.Add("Person", "Contact Person")

            dgSupp.Columns(0).DataPropertyName = "AcCode"
            dgSupp.Columns(0).Visible = False
            dgSupp.Columns(1).DataPropertyName = "AcName"
            dgSupp.Columns(2).DataPropertyName = "Place"
            dgSupp.Columns(3).DataPropertyName = "Ph"
            dgSupp.Columns(4).DataPropertyName = "Person"

            dgSupp.Columns(1).Width = 300
            dgSupp.Columns(2).Width = 195
            dgSupp.Columns(3).Width = 275
            dgSupp.Columns(4).Width = 192

            'For i = 0 To 4
            '    dgSupp.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            '    dgSupp.Columns(i).DefaultCellStyle.BackColor = Color.Navy
            '    dgSupp.Columns(i).DefaultCellStyle.ForeColor = Color.Yellow
            'Next i

            TxtBarcodeEdit.Visible = False
            lblStatus.Text = "Select a Product.."

            TaxTbl = New DataTable
            TaxTbl.TableName = "Tax"
            cmd.Connection = Conn
            cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' order by seq"
            DA.SelectCommand = cmd
            DA.Fill(TaxTbl)

            cbEditVat.DataSource = TaxTbl
            cbEditVat.DisplayMember = "taxper"

            cbvat.DataSource = TaxTbl
            cbvat.DisplayMember = "taxper"


            pnlprod.Visible = False

            cmd.CommandText = "select taxper,accode,surch from tax where flag='31'"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            If dataredr.HasRows Then
                i = 0
                While dataredr.Read()
                    rtaxary(i, 0) = dataredr.Item("taxper")
                    rtaxary(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If
            dataredr.Close()

            cmd.CommandText = "select taxper,accode,surch from tax where flag='32'"
            dataredr = cmd.ExecuteReader
            If dataredr.HasRows Then
                While dataredr.Read()
                    i = 0
                    rptax(i, 0) = dataredr.Item("taxper")
                    rptax(i, 2) = dataredr.Item("accode")
                    i = i + 1
                End While
            End If

            dgBDet.Columns.Clear()

            dataredr.Close()


            cmd.CommandText = "select  StkAdjOpt   from settings"
            ShowAdjOpt = cmd.ExecuteScalar

            cmd.CommandText = "select   PrdCodeAsBarCode  from settings"
            PrdCodeAsBarCode = cmd.ExecuteScalar
            dgBarcode.Rows.Clear()
            dgBarcode.Rows.Add("")
            'dgBDet.BackgroundColor = Color.Navy
            'dgBDet.RowHeadersVisible = False


            'dgBDet.Columns(0).Width = 60
            'dgBDet.Columns(1).Width = 85
            'dgBDet.Columns(2).Width = 50
            'dgBDet.Columns(3).Width = 70
            'dgBDet.Columns(4).Width = 50
            'dgBDet.Columns(5).Width = 60
            'dgBDet.Columns(6).Width = 70
            'dgBDet.Columns(7).Width = 250
            'dgBDet.Columns(8).Width = 80
            'dgBDet.Columns(9).Width = 85
            'dgBDet.Columns(10).Width = 70
            'dgBDet.Columns(11).Width = 60
            'dgBDet.Columns(12).Width = 60
            'dgBDet.Columns(13).Width = 60
            'dgBDet.Columns(14).Width = 60
            'dgBDet.Columns(15).Width = 60
            'dgBDet.Columns(16).Width = 80
            'dgBDet.Columns(17).Width = 85
            'dgBDet.Columns(18).Width = 60
            'dgBDet.Columns(19).Width = 60
            'dgBDet.Columns(20).Width = 60
            'dgBDet.Columns(21).Visible = False
            'dgBDet.Columns(22).Visible = False
            Dim dt As New DataTable
            Dim DS As New DataSet

            cmd.CommandText = "select RndPaise,outgoid,ExpWiseBill,defaultDoc,DefaultPat,usebarcode,UseSalesmanPass,ShowPrateInSales,workshift from settings"
            dt.Rows.Clear()
            dt.Clear()
            DA.SelectCommand = cmd
            DA.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                RndPai = dt.Rows(i).Item("RndPaise")
                outgoid = dt.Rows(i).Item("outgoid")
                BillOrder = IIf(dt.Rows(i).Item("ExpWiseBill"), 1, 0)
                UseSalesmanPass = dt.Rows(i).Item("UseSalesmanPass")
                txtsmcode.Visible = UseSalesmanPass
                cbSal.Enabled = Not UseSalesmanPass

                UseBarCode = dt.Rows(i).Item("usebarcode")
                ShowPrateInSales = dt.Rows(i).Item("ShowPrateInSales")
                ShowPrateInSales = dt.Rows(i).Item("workshift")
            Next

            If UseSalesmanPass Then
                cmd.CommandText = "select salcode,Salname from Salesman WHERE salcode<>0 ORDER BY Salname "
            Else
                cmd.CommandText = "select salcode,Salname from Salesman ORDER BY Salname "
            End If
            DA.SelectCommand = cmd
            DA.Fill(DS, "Salesman")
            cbSal.DisplayMember = "SalName"
            cbSal.ValueMember = "salcode"
            cbSal.DataSource = DS.Tables("Salesman")

            If txtsmcode.Text = "" Then
                cbSal.SelectedValue = 0
            End If


            cbSal.Visible = UseSalesmanPass
            lblSal.Visible = UseSalesmanPass
            'If UseSalesmanPass Then
            '    txtsmcode.Text = ""
            'End If

            txtEditDt.Visible = False
            CbEditSupp.Visible = False
            CbEditTaxInc.Visible = False
            cbEditVat.Visible = False
            tbCtrl1.Enabled = False
            pnlstk.Visible = False
            cbadjopt.Text = ""
            cbadjrmk.Text = ""
            txtEdit.Visible = False
            txtEditDt.Visible = False
            sdetread = False
            mdetread = False
            'dgBDet.Rows.Clear()
            dgMTrans.Rows.Clear()
            dgSDetails.Rows.Clear()
            tbCtrl1.SelectedTab = tbCtrl1.TabPages(0)

            If txtsmcode.Text <> "" Then
                cmd.Connection = Conn
                cmd.CommandText = "SELECT SalCode FROM SALESMAN WHERE UPPER(PASSWORD)=""" + UCase(txtsmcode.Text) & """"
                cbSal.SelectedValue = Val(cmd.ExecuteScalar & "")
            End If
            dgBDet.Enabled = True
            Application.DoEvents()
            txtName.Focus()

            Me.Cursor = Cursors.Default
        Catch er As Exception
            Me.Cursor = Cursors.Default
            'ClearForm()
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtSch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        cbsch.SelectAll()
    End Sub
    Private Sub txtRack_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cbRack.SelectAll()
    End Sub
    Private Sub txtRol_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRol.GotFocus
        txtRol.SelectAll()
    End Sub

    Private Sub txtPndOrd_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPndOrd.GotFocus
        txtPndOrd.SelectAll()
    End Sub

    Private Sub txtOrdqty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrdqty.GotFocus
        txtOrdqty.SelectAll()
    End Sub

    Private Sub txtMaxqty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaxqty.GotFocus
        txtMaxqty.SelectAll()
    End Sub

    Private Sub txtCase1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCase1.GotFocus
        txtCase1.SelectAll()
    End Sub

    Private Sub txtCase2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCase2.GotFocus
        txtCase2.SelectAll()
    End Sub

    Private Sub txtCase3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCase3.GotFocus
        txtCase3.SelectAll()
    End Sub

    Private Sub txtUnit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnit1.GotFocus
        txtUnit1.SelectAll()
    End Sub

    Private Sub txtUnit2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnit2.GotFocus
        txtUnit2.SelectAll()
    End Sub

    Private Sub txtUnit3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnit3.GotFocus
        txtUnit3.SelectAll()
    End Sub

    Private Sub txtMfr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMfr.GotFocus
        txtMfr.SelectAll()
    End Sub

    Private Sub txtGen1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGen1.GotFocus
        txtGen1.SelectAll()
    End Sub

    Private Sub txtGen2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGen2.GotFocus
        txtGen2.SelectAll()
    End Sub

    Private Sub txtGen3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGen3.GotFocus
        txtGen3.SelectAll()
    End Sub

    Private Sub txtGen4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGen4.GotFocus
        txtGen4.SelectAll()
    End Sub

    Private Sub txtGen5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGen5.GotFocus
        txtGen5.SelectAll()
    End Sub

    Private Sub txtNote_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.GotFocus
        txtNote.SelectAll()
    End Sub

    Private Sub txtInvMsg_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvMsg.GotFocus
        txtInvMsg.SelectAll()
    End Sub

    Private Sub txtRectMsg_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRectMsg.GotFocus
        txtRectMsg.SelectAll()
    End Sub

    Private Sub txtName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating

        If txtCode.Text = "" And ProdAdding = True And Trim(txtName.Text) <> "" And DgProdSer.Visible = False Then CreateCode()

    End Sub

    Private Sub CreateCode()
        Dim cmd As New OleDb.OleDbCommand
        Dim nm As String
        Dim x As Long
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn
            cmd.CommandText = "select PrdCode from product where prdname=""" + txtName.Text + """"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
            dataredr.Read()
            If dataredr.HasRows Then
                MsgBox("Product already exists..!", MsgBoxStyle.Information)
            End If
            If Len(txtName.Text) > 3 Then nm = Microsoft.VisualBasic.Left(txtName.Text, 3) Else nm = txtName.Text

            ' cmd.CommandText = "Select max(CONVERT(BIGINT,prdcode)) as [newcode] from product where prdcode like """ + nm + "%"""
            Try
                cmd.CommandText = "Select max(convert(int,rtrim(substring(prdcode,4,4)))) as [newcode] from product where prdcode like """ + nm + "%"""
                dataredr.Close()
                dataredr = cmd.ExecuteReader()
            Catch ex As Exception
                cmd.CommandText = "Select max(convert(int,rtrim(substring(prdcode,5,4)))) as [newcode] from product where prdcode like """ + nm + "%"""
                dataredr.Close()
                dataredr = cmd.ExecuteReader()
            End Try

            If dataredr.HasRows Then
                dataredr.Read()
                If dataredr.Item(0) & "" = "" Then x = 1 Else x = Val(dataredr("newcode") & "") + 1
                ProdSelected = True
                txtCode.Text = nm & x
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtCase2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCase2.TextChanged
        Try
            If txtCase2.Text = "" Then
                txtUnit2.Text = ""
                txtUnit2.Enabled = False
                radb2.Enabled = False
                If radb2.Checked Then
                    radb1.Checked = True
                    radb2.Checked = False
                End If
            Else
                txtUnit2.Enabled = True
                txtCase3.Enabled = True
                txtUnit2.Text = ""
                txtUnit3.Text = ""
                radb2.Checked = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtUnit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnit2.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtUnit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnit3.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtCST_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCST.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtSrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSrate.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtPrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrate.KeyPress
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If InStr("0123456789.", e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtcase3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCase3.TextChanged
        Try
            If txtCase3.Text = "" Then
                txtUnit3.Enabled = False
                If radb3.Checked Then
                    radb1.Checked = True
                    radb3.Checked = False
                End If
            Else
                txtUnit3.Enabled = True
                radb3.Checked = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Sub ShowSupplier()

        Dim pcmd As New OleDb.OleDbCommand
        Dim pda As New OleDb.OleDbDataAdapter
        Dim pds As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            pcmd.Connection = Conn
            pcmd.CommandText = "Select AcCode,Acname,Place,ph,Person from Acmaster,Product,supcom where " & _
                " acmaster.accode=supcom.supcode and supcom.comcode=product.comcode and product.prdcode=""" + txtCode.Text + """"

            pda.SelectCommand = pcmd
            pda.Fill(pds, "Acmaster")

            'dgSupp.DataSource. 
            'dgSupp.Rows.Clear()
            dgSupp.DataSource = pds.Tables("Acmaster")

            dgSupp.Columns(0).Visible = False
            'dgSupp.Columns(1).Width = 240
            'dgSupp.Columns(2).Width = 60
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbComp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbComp.LostFocus
        'If cbComp.SelectedValue = 0 Then
        ' cbComp.SelectedValue = 1
        'End If
    End Sub

    Private Sub cbGen1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGen1.LostFocus
        'If cbGen1.SelectedValue = 0 Then
        '    cbGen1.SelectedValue = 1
        'End If
    End Sub

    Private Sub cbGen2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGen2.LostFocus
        'If cbGen2.SelectedValue = 0 Then
        '    cbGen2.SelectedValue = 1
        'End If
    End Sub

    Private Sub cbGen4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGen4.LostFocus
        'If cbGen4.SelectedValue = 0 Then
        '    cbGen4.SelectedValue = 1
        'End If
    End Sub

    Private Sub cbGen3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGen3.LostFocus
        'If cbGen3.SelectedValue = 0 Then
        '    cbGen3.SelectedValue = 1
        'End If
    End Sub

    Private Sub cbGen5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGen5.LostFocus
        'If cbGen5.SelectedValue = 0 Then
        '    cbGen5.SelectedValue = 1
        'End If
    End Sub

    Private Sub txtEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.GotFocus
        txtEdit.SelectAll()
    End Sub

    Private Sub txtEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEdit.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then

                'If txtsmcode.Visible Then
                '    If cbSal.SelectedValue = 0 Then
                '        txtsmcode.Tag = "Y"
                '        MsgBox("Enter staff code ", vbInformation)
                '        txtsmcode.Focus()
                '        txtsmcode.SelectAll()
                '        txtsmcode.Tag = ""
                '        Exit Sub
                '    End If
                'Else
                '    'If cbSal.Text = "" Then

                '    '    Exit Sub
                '    'End If
                'End If

                Select Case dgBDet.CurrentCell.ColumnIndex
                    Case 6, 17

                        UpdateBatch(txtEdit.Text)
                        InsertProductEdited()
                        dgBDet.CurrentCell.Value = Format(Val(txtEdit.Text), "0.0000")
                        txtEdit.Visible = False
                    Case 7, 8, 9, 10, 18, 19, 20, 21, 22, 24, 25, 26, 29
                        UpdateBatch(txtEdit.Text)
                        InsertProductEdited()
                        dgBDet.CurrentCell.Value = Format(Val(txtEdit.Text), "0.00")
                        txtEdit.Visible = False
                    Case 11, 12, 13

                        UpdateBatch(txtEdit.Text)
                        InsertProductEdited()
                        dgBDet.CurrentCell.Value = Format(Val(txtEdit.Text), "0")
                        txtEdit.Visible = False
                    Case 5
                        ShowStockAdjOpt()
                    Case Else

                        UpdateBatch(txtEdit.Text)
                        InsertProductEdited()
                        dgBDet.CurrentCell.Value = txtEdit.Text
                        txtEdit.Visible = False
                End Select
                'txtEdit.Visible = False
                View_Profit()
                dgBDet.Focus()
                e.Handled = True


            End If

            If e.KeyCode = Keys.Escape Then
                txtEdit.Visible = False
                dgBDet.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        Try
            Select Case dgBDet.CurrentCell.ColumnIndex
                Case 6, 7, 8, 28, 27, 24, 25, 18, 19, 20, 21, 22
                    If InStr("0123456789." & Chr(8), e.KeyChar) = 0 Then e.KeyChar = ""
                Case 11, 12, 29
                    If InStr("0123456789" & Chr(8), e.KeyChar) = 0 Then e.KeyChar = ""
                Case 5
                    If InStr("0123456789.+-" & Chr(8), e.KeyChar) = 0 Then e.KeyChar = ""
            End Select
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub dgBDet_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgBDet.CellMouseUp

    End Sub

    Private Sub dgBDet_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBDet.DoubleClick
        If txtsmcode.Visible Then
            If cbSal.SelectedValue = 0 Then
                MsgBox("Enter staff code ", vbInformation)
                txtsmcode.Focus()
                txtsmcode.SelectAll()
                Exit Sub
            End If
            'Else
            'If cbSal.Text = "" Then
            '    MsgBox("Select a salesman", vbInformation)
            '    Exit Sub
            'End If
        End If

        EditGrid()
    End Sub

    Private Sub UpdateBatch(ByVal newval As String)
        Dim fld As String
        Dim cmd As New OleDb.OleDbCommand
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn

            fld = Choose(dgBDet.CurrentCell.ColumnIndex + 1, "batchid", "seq", "supcode", "batch", "exdt", "stock", "srate", "", "", "Rctno", "Pdate", "Rqty", "Fqty", "repqty", "supcode", "billno", "billdt", "prate", "Pdis", "Bdis", "psch", "pcst", "Ptax", "TrRate", "Ssch", "stax", "taxinc", "scst", "", "brkqty")

            Select Case dgBDet.CurrentCell.ColumnIndex
                Case 3, 15
                    cmd.CommandText = "Update batch set " & fld & " = """ & newval & """ where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                Case 4, 16
                    If IsDate(newval) Then
                        cmd.CommandText = "Update batch set " & fld & " = '" & newval & "' where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    Else
                        cmd.CommandText = "Update batch set " & fld & " = NULL where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    End If
                Case 14
                    cmd.CommandText = "Update batch set " & fld & " = " & Val(newval) & " where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                Case 26
                    cmd.CommandText = "Update batch set " & fld & " = " & IIf(newval = "Yes", 1, 0) & " where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                Case Else
                    If dgBDet.CurrentCell.ColumnIndex = 6 Then
                        Dim vrem As String = InputBox("Enter Remarks : ", "Selling Rate Editing")
                        cmd.CommandText = "Insert Into RateEdit (adjdt,PrdCode,newrt,oldrt,Remarks,batchid,nodename,usrname ) " & _
                            " values ('" & SysDt & "',""" & txtCode.Text & """," & Val(newval) & "," & _
                            Val(dgBDet.CurrentCell.Value) & ",""" & "" & """," & _
                            Val(dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value) & ",""" & NodeName & """,""" & UsrName & """)"

                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = "Update batch set " & fld & " = " & newval & " where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value

            End Select
            cmd.ExecuteNonQuery()


            '           1       2       3           4       5       6       7       8   9   10  11      12      13      14          15          16      17          18      19      20      21      22      23      24      25      26      27          28      29      30      
            'fld =  "batchid", "seq", "supcode", "batch", "exdt", "stock", "srate", "", "", "", "scst", "Ssch", "stax", "taxinc", "supcode", "billno", "billdt", "prate", "Pdis", "Bdis", "psch", "pcst", "Ptax", "TrRate", "Rqty", "Fqty", "repqty", "Pdate", "Rctno", "brkqty")

        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub InsertProductEdited()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim sql As String
        Dim ThisDate As DateTime = Now
        Dim TimePart As String = ThisDate.ToShortTimeString
        Dim DatePart As String = ThisDate.ToShortDateString

        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn

            cmd.CommandText = "Select GetDate() as Date"
            da.SelectCommand = cmd
            da.Fill(ds, "Date")
            dt = ds.Tables("Date")


            sql = "insert into ProductEdited(node,PCode,UserName,Staff,DateTime) values(""" & _
                    nodeName & """,""" & txtCode.Text & """,""" & UsrName & """," & Val(cbSal.SelectedValue) & ",'" & dt.Rows(0).Item("Date") & "')"
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EditGrid()
        Dim cntrol As Object
        Dim WD As Integer
        Try
            EdCol = dgBDet.CurrentCell.ColumnIndex
            EdRow = dgBDet.CurrentCell.RowIndex
            dgBDet.CurrentCell = dgBDet.Item(EdCol, EdRow)
        Catch
            Exit Sub
        End Try
        Try

            If CheckUserLocked("Edit Stock", True) = False And CheckUserLocked("Edit Price", True) = False Then


                Exit Sub
            End If

            If IsNothing(dgBDet.CurrentCell) Then Exit Sub
            TabFlag = True
            Select Case dgBDet.CurrentCell.ColumnIndex
                Case 23, 10, 9, 30, 31
                    Exit Sub
                Case 25
                    cntrol = cbEditVat
                    cntrol.Text = dgBDet.CurrentCell.Value & ""
                Case 26
                    cntrol = CbEditTaxInc
                    cntrol.Text = dgBDet.CurrentCell.Value & ""
                Case 14
                    cntrol = CbEditSupp
                    cntrol.selectedvalue = dgBDet.Item(1, dgBDet.CurrentCell.RowIndex).Value
                Case 4, 16
                    cntrol = txtEditDt
                    If IsDate(dgBDet.CurrentCell.Value) Then

                        cntrol.Text = Format(dgBDet.CurrentCell.Value, DateFormat)
                    Else
                        cntrol.Text = "__/__/__"
                    End If
                    'Application.DoEvents()
                    cntrol.SelectAll()
                Case Else

                    If dgBDet.CurrentCell.ColumnIndex = 5 Then
                        If CheckUserLocked("Edit Stock") = False Then Exit Sub
                    End If

                    If dgBDet.CurrentCell.ColumnIndex = 6 Or dgBDet.CurrentCell.ColumnIndex = 17 Then
                        If CheckUserLocked("Edit Price") = False Then Exit Sub
                    End If


                    cntrol = txtEdit
                    If dgBDet.CurrentCell.ColumnIndex = 15 Then
                        If Microsoft.VisualBasic.Left(dgBDet.CurrentCell.Value & "", 3) = "DN " Then
                            cntrol.Text = Mid(dgBDet.CurrentCell.Value & "", 4, 20)
                        Else
                            cntrol.Text = dgBDet.CurrentCell.Value & ""
                        End If

                    Else
                        cntrol.Text = dgBDet.CurrentCell.Value & ""
                    End If

                    'Application.DoEvents()
                    cntrol.SelectAll()
            End Select

            WD = 0
            cntrol.Location = dgBDet.Location
            cntrol.top = dgBDet.Top
            cntrol.left = dgBDet.Left
            cntrol.top = dgBDet.Top + dgBDet.GetRowDisplayRectangle(dgBDet.CurrentCell.RowIndex, True).Top
            cntrol.left = dgBDet.Left + dgBDet.GetColumnDisplayRectangle(dgBDet.CurrentCell.ColumnIndex, True).Left
            cntrol.width = dgBDet.GetColumnDisplayRectangle(dgBDet.CurrentCell.ColumnIndex, True).Width
            cntrol.Visible = True
            cntrol.Focus()
            cntrol.SelectAll()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditTaxInc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditTaxInc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                UpdateBatch(CbEditTaxInc.Text)

                dgBDet.CurrentCell.Value = CbEditTaxInc.Text
                View_Profit()
                dgBDet.Focus()

                ' Calculate()
                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditTaxInc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditTaxInc.Leave
        CbEditTaxInc.Visible = False
        dgBDet.Focus()
    End Sub

    Private Sub dgBDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgBDet.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                If txtsmcode.Visible Then
                    If cbSal.SelectedValue = 0 Then
                        MsgBox("Enter staff code ", vbInformation)
                        txtsmcode.Focus()
                        txtsmcode.SelectAll()
                        Exit Sub
                    End If
                Else
                    'If cbSal.Text = "" Then

                    '    Exit Sub
                    'End If
                End If


                e.Handled = True
                EditGrid()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbEditVat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbEditVat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                UpdateBatch(cbEditVat.Text)
                dgBDet.CurrentCell.Value = cbEditVat.Text
                View_Profit()
                dgBDet.Focus()
                e.Handled = True
            End If
            If e.KeyCode = Keys.Escape Then
                cbEditVat.Visible = False
                dgBDet.Focus()
                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub cbEditVat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEditVat.Leave
        cbEditVat.Visible = False
        dgBDet.Focus()
    End Sub

    Private Sub dgBDet_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgBDet.Scroll
        cbEditVat.Visible = False
        CbEditSupp.Visible = False
        CbEditTaxInc.Visible = False
        txtEdit.Visible = False
        txtEditDt.Visible = False

    End Sub

    Private Sub CbEditSupp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CbEditSupp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                If CbEditSupp.Text = "" Then CbEditSupp.Visible = False : Exit Sub
                UpdateBatch(CbEditSupp.SelectedValue.ToString)
                dgBDet.CurrentCell.Value = CbEditSupp.Text
                dgBDet.Item(2, dgBDet.CurrentCell.RowIndex).Value = CbEditSupp.SelectedValue

                dgBDet.Focus()
                e.Handled = True
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub CbEditSupp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEditSupp.Leave
        CbEditSupp.Visible = False
        dgBDet.Focus()
    End Sub

    Private Sub txtEditDt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEditDt.KeyDown
        'Dim tmpdt As DateTime
        Try
            If e.KeyCode = Keys.Enter Then
                If dgBDet.CurrentCell.ColumnIndex = 4 Then
                    If ExpDateCheck(txtEditDt, True) Then

                        UpdateBatch(txtEditDt.Text)
                        If IsDate(txtEditDt.Text) Then
                            dgBDet.CurrentCell.Value = txtEditDt.Text
                        Else
                            dgBDet.CurrentCell.Value = System.DBNull.Value
                        End If
                        ExpColor(dgBDet.CurrentCell.RowIndex)
                        txtEditDt.Visible = False
                        dgBDet.Focus()
                        e.Handled = True
                    End If
                Else
                    If DateCheck(txtEditDt, False) Then

                        UpdateBatch(txtEditDt.Text)

                        If IsDate(txtEditDt.Text) Then
                            dgBDet.CurrentCell.Value = txtEditDt.Text
                        Else
                            dgBDet.CurrentCell.Value = System.DBNull.Value
                        End If

                        txtEditDt.Visible = False
                        dgBDet.Focus()
                        e.Handled = True
                    End If

                End If
            End If

            If e.KeyCode = Keys.Escape Then
                txtEditDt.Visible = False
                dgBDet.Focus()
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEditDt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditDt.Leave
        txtEditDt.Visible = False
    End Sub

    Private Sub txtEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.Leave


        'TabFlag = False
    End Sub

    Private Sub BatchDetails(ByVal cd As String)
        If txtCode.Text = "" Then Exit Sub
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim batds As New DataSet
        Dim i As Integer
        Dim totstk As Long
        Try
            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn

            cmd.CommandText = "select Batch.Batchid,batch.supcode,Batch.seq,Batch.Batch as [Batch No.],batch.ExDt as [Exp.Dt], convert(int,batch.Stock) as [Stock]," & _
                "batch.SRate as [S.Rate],0,0,batch.RctNo as [Rcpt.No],batch.PDate as [Rcpt.Dt], convert(integer,Batch.RQty) as [Rcpt],convert(integer,batch.FQty) as [Free]," & _
                "convert(integer,batch.RepQty) as [Repl],AcMaster.AcName as [Supplier's Name],(case when flag +''='D' then 'DN ' + batch.BillNo else batch.BillNo end) as [Bill No]," & _
                "convert(datetime,batch.BillDt,103) as [Bill Dt.],batch.PRate as [P.Rate],Batch.PDis as [P.Disc.],Batch.BDis as [B.Disc.]," & _
                "Batch.PSch as [p.Scheme],batch.PCST as [P.CST],Batch.Ptax as [P.VAT],batch.trrate as [Tr.Rate ],SSch as  [S.Scheme],batch.stax as [SVAT]," & _
                "case batch.taxinc when 1 then 'Yes' when 0 then 'No' end  as [Tax Inc],Batch.SCST as [S.CST],0,batch.BrkQty as [Brk. Qty.]," & _
                "batch.Profit as [Profit %],(case when batch.lock=1 then 'Yes'  else 'No' end) as [Locked] ,batch.flag from Batch LEFT JOIN ACMASTER ON Acmaster.accode=batch.supcode WHERE " & IIf(chkbat.Checked, "  stock <> 0 AND ", "") & "  " & _
                "batch.PrdCode=""" + cd + """ order by seq ,BatchId"

            da.SelectCommand = cmd

            da.Fill(batds, "batch")
            'DgProdSer.Rows.Clear()
            dgBDet.SuspendLayout()
            dgBDet.DataSource = batds.Tables("batch")

            dgBDet.ColumnHeadersDefaultCellStyle.Font = New Font(dgBDet.ColumnHeadersDefaultCellStyle.Font, FontStyle.Regular)
            'dgBDet.BackgroundColor = Me.BackColor
            'dgBDet.
            ' dgBDet.ColumnHeadersDefaultCellStyle.BackColor = Color.Black

            dgBDet.Columns(0).Visible = False
            dgBDet.Columns(1).Visible = False
            dgBDet.Columns(2).Visible = False

            For i = 0 To dgBDet.Columns.Count - 1

                Select Case i
                    Case 5, 6, 7, 8, 9, 27, 11, 12, 17, 18, 19, 20, 21, 23, 24, 25, 13, 28, 29, 31
                        dgBDet.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dgBDet.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End Select
                dgBDet.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable

            Next i
            totstk = 0


            dgBDet.Columns(5).HeaderCell.Style.Font = (New Font(dgBDet.RowHeadersDefaultCellStyle.Font, FontStyle.Bold))
            dgBDet.Columns(5).HeaderCell.Style.ForeColor = Color.Gold
            For i = 0 To dgBDet.Rows.Count - 1
                ExpColor(i)


                dgBDet.Item(5, i).Style.Font = (New Font(dgBDet.DefaultCellStyle.Font, FontStyle.Bold))
                dgBDet.Item(5, i).Style.ForeColor = Color.Blue
                totstk = totstk + Val(dgBDet.Rows(i).Cells(5).Value & "")
                If dgBDet.Item(31, i).Value = "Yes" Then

                    dgBDet.Rows(i).DefaultCellStyle.BackColor = Color.Gray
                Else
                    dgBDet.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next
            lblstk.Text = Format(totstk, "0")

            dgBDet.Columns(7).Visible = False
            dgBDet.Columns(8).Visible = False
            dgBDet.Columns(28).Visible = False
            dgBDet.Columns(24).Visible = False
            dgBDet.Columns(20).Visible = False
            dgBDet.ResumeLayout()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExpColor(ByVal i As Integer)
        Try

            Dim nds As Long
            dgBDet.Item(4, i).Style.ForeColor = Color.Black
            If dgBDet.Item(4, i).Value & "" <> "" Then
                If IsDate(dgBDet.Item(4, i).Value & "") Then
                    nds = DateDiff(DateInterval.Day, SysDt, dgBDet.Item(4, i).Value)
                    If nds < 0 Then
                        dgBDet.Item(4, i).Style.ForeColor = Color.Red
                    ElseIf nds < ShortExpDays Then

                        dgBDet.Item(4, i).Style.ForeColor = Color.DarkRed




                    End If

                End If
            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    'Private Sub BntCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    pnlstk.Visible = False
    '    txtEdit.Enabled = True
    '    txtEdit.Focus()

    '    'dgBDet.Focus()
    '    'pnl.Enabled = False
    'End Sub
    Private Sub UpdateStock()
        Dim adjqty As Double
        Dim cmd As New OleDb.OleDbCommand
        Dim Trn As OleDb.OleDbTransaction
        Dim TrnFlg As Boolean

        Try
            'MsgBox(dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value)
            adjqty = Val(txtEdit.Text) - Val(dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value)
            If Val(Microsoft.VisualBasic.Left(cbadjopt.Text, 1)) = 2 Then
                If dgstkadj.CurrentCell.RowIndex = dgstkadj.Rows.Count - 1 Then
                    MsgBox("Select a batch to adjust..!", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If dgstkadj.Item(3, dgstkadj.CurrentCell.RowIndex).Value - adjqty < 0 Then
                    MsgBox("Insufficient Qty. Can't Adjust with Selected Batch.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            cmd.Connection = Conn

            Trn = Conn.BeginTransaction()
            TrnFlg = True
            'TRN.IsolationLevel = IsolationLevel.Serializable
            cmd.Transaction = Trn

            cmd.CommandText = "select batch.Stock from Batch with (rowlock,holdlock) where " & _
                    "batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value & "  order by BatchId"
            Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
            If dataredr.HasRows Then
                dataredr.Read()
                If dataredr.Item("Stock") <> dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value Then
                    MsgBox("Can't save..  Qty. of this batch is updated by other user/process. Please try Again.", MsgBoxStyle.Information)
                    Trn.Rollback()
                    Me.Cursor = Cursors.Default
                    TrnFlg = False
                    BtnCan.PerformClick()
                    BatchDetails(txtCode.Text)
                    Exit Sub
                End If
            End If

            dataredr.Close()

            cmd.CommandText = "Insert Into StockAdj (adjdt,PrdCode,Qty,type,Remarks,batchid,nodename,usrname) " & _
                        " values ('" & SysDt & "',""" & txtCode.Text & """," & adjqty & "," & _
                        Microsoft.VisualBasic.Left(cbadjopt.Text, 1) & ",""" & cbadjrmk.Text & """," & _
                        Val(dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value) & ",""" & NodeName & """,""" & UsrName & """)"
            cmd.ExecuteNonQuery()

            Select Case Val(Microsoft.VisualBasic.Left(cbadjopt.Text, 1))

                Case 1 'other adj
                    cmd.CommandText = "Update batch set stock=" & Val(txtEdit.Text) & "  where batchid = " & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()
                Case 2 ' adjust with other batch

                    cmd.CommandText = "Update batch set stock=" & Val(txtEdit.Text) & "  where batchid = " & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Insert Into StockAdj (adjdt,PrdCode,Qty,type,Remarks,batchid,nodename,usrname) " & _
                        " values ('" & SysDt & "',""" & txtCode.Text & """," & (adjqty * -1) & "," & _
                        Microsoft.VisualBasic.Left(cbadjopt.Text, 1) & ",""" & cbadjrmk.Text & """," & _
                        Val(dgstkadj.Item(0, dgstkadj.CurrentCell.RowIndex).Value) & ",""" & NodeName & """,""" & UsrName & """)"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Update batch set stock=stock-(" & adjqty & ")  where batchid = " & dgstkadj.Item(0, dgstkadj.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()

                Case 3 'breakage
                    cmd.CommandText = "Update batch set stock=" & Val(txtEdit.Text) & ",brkqty=brkqty-(" & adjqty & ")  where batchid = " & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()
            End Select

            Trn.Commit()
            txtEdit.Enabled = True
            TrnFlg = False
            Dim r, c As Integer
            r = dgBDet.CurrentCell.RowIndex
            c = dgBDet.CurrentCell.ColumnIndex
            BatchDetails(txtCode.Text)
            pnlstk.Visible = False
            txtEdit.Visible = False
            Try
                If dgBDet.CurrentCell Is Nothing Then

                Else
                    dgBDet.CurrentCell = dgBDet.Item(c, r)
                End If
            Catch ex As Exception

            End Try
            dgBDet.Focus()

        Catch er As Exception
            If TrnFlg Then Trn.Rollback()
            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UpdateStock()

    'End Sub

    Private Sub pnlstk_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If pnlstk.Visible Then e.Cancel = True
    End Sub

    Private Sub ShowStockAdjOpt()
        Try
            If Microsoft.VisualBasic.Left(txtEdit.Text, 1) = "-" Or Microsoft.VisualBasic.Left(txtEdit.Text, 1) = "+" Then
                txtEdit.Text = Val(dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value) + Val(txtEdit.Text)
            End If

            If Val(txtEdit.Text) <> dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value Then
                Dim adjqty As Double
                cbadjopt.Items.Clear()
                adjqty = Val(txtEdit.Text) - dgBDet.Item(dgBDet.CurrentCell.ColumnIndex, dgBDet.CurrentCell.RowIndex).Value
                If adjqty > 0 Then
                    lbladjcap1.Text = "Adding Qty.. " & System.Math.Abs(adjqty)
                    cbadjopt.Items.Add("1 - Other Adjustment")
                    cbadjopt.Items.Add("2 - Adjust with Other Batch")
                Else
                    lbladjcap1.Text = "Deducting Qty.. " & System.Math.Abs(adjqty)

                    cbadjopt.Items.Add("1 - Other Adjustment")
                    cbadjopt.Items.Add("2 - Adjust with Other Batch")
                    cbadjopt.Items.Add("3 - Send to Breakage")
                End If

                lbladjcap.Text = txtName.Text
                cbadjopt.SelectedIndex = 0
                Application.DoEvents()
                If ShowAdjOpt Then
                    pnlstk.Visible = True
                    dgBDet.Enabled = False
                    txtEdit.Enabled = False
                    Application.DoEvents()
                    cbadjrmk.Focus()
                Else
                    UpdateStock()
                End If

            Else

                txtEdit.Visible = False
                'pnl.Enabled = False
            End If

        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub
    Private Sub monthlytransaction()
        Dim command As New Data.OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        Dim i As Integer = 0
        Dim tmpdt As Date
        Try
            Me.Cursor = Cursors.WaitCursor
            command.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "GetMonthTrans"
            command.Parameters.Add("@prdcode", OleDb.OleDbType.VarChar).Value = txtCode.Text
            command.Parameters.Add("@es", OleDb.OleDbType.Numeric).Value = 1
            reader = command.ExecuteReader
            dgMTrans.Rows.Clear()
            Dim entlop As Boolean = True
            If reader.HasRows Then
                reader.Read()
                While True

                    tmpdt = reader("dt")

                    dgMTrans.Rows.Add()
                    dgMTrans.Item(0, dgMTrans.Rows.Count - 1).Value = Format(reader("dt"), "MMM yyyy")
                    While tmpdt = reader("dt")



                        Select Case reader("flg")
                            Case "Sal"
                                dgMTrans.Item(1, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")
                                dgMTrans.Item(2, dgMTrans.Rows.Count - 1).Value = Format(reader("va"), "0.00")
                            Case "SRtn"
                                dgMTrans.Item(3, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")
                                dgMTrans.Item(4, dgMTrans.Rows.Count - 1).Value = Format(reader("va"), "0.00")
                            Case "RQ"
                                dgMTrans.Item(5, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")
                                dgMTrans.Item(6, dgMTrans.Rows.Count - 1).Value = Format(reader("va"), "0.00")
                            Case "FQ"
                                dgMTrans.Item(7, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")
                            Case "RepQ"
                                dgMTrans.Item(8, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")

                            Case "BRtn", "PRtn"
                                dgMTrans.Item(9, dgMTrans.Rows.Count - 1).Value = Format(Val(dgMTrans.Item(9, dgMTrans.Rows.Count - 1).Value & "") + Val(reader("qt") & ""), "0.00")

                            Case "StkAdj"
                                dgMTrans.Item(10, dgMTrans.Rows.Count - 1).Value = Format(reader("qt"), "0.00")

                            Case "TrnOut", "TrnIn"
                                dgMTrans.Item(11, dgMTrans.Rows.Count - 1).Value = Format(Val(dgMTrans.Item(11, dgMTrans.Rows.Count - 1).Value & "") + Val(reader("qt") & ""), "0.00")

                        End Select

                        If reader.Read() = False Then

                            entlop = False
                            Exit While
                        End If

                        i += 1
                    End While
                    If entlop = False Then Exit While
                End While
            End If
            reader.Close()

        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub cbadjopt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbadjopt.SelectedIndexChanged
        Try
            Select Case Val(Microsoft.VisualBasic.Left(cbadjopt.Text, 1))
                Case 2
                    Dim cmd As New OleDb.OleDbCommand
                    Dim da1 As New OleDb.OleDbDataAdapter
                    Dim batds1 As New DataSet
                    cmd.Connection = Conn
                    cmd.CommandText = "select Batch.Batchid,Batch.Batch as [Batch No],batch.ExDt as [Expiry], convert(int,batch.Stock) as [Stock],batch.SRate as [S Rate] from Batch where " & _
                    "batch.PrdCode=""" + txtCode.Text + """ and batchid<>" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value & "  order by BatchId"

                    da1.SelectCommand = cmd

                    da1.Fill(batds1, "batch")
                    'DgProdSer.Rows.Clear()
                    dgstkadj.DataSource = batds1.Tables("batch")

                    dgstkadj.Columns(0).Visible = False

                    dgstkadj.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgstkadj.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    gb1.Visible = True
                    pnlstk.Width = 550
                    dgstkadj.CurrentCell = dgstkadj.Item(1, dgstkadj.RowCount - 1)
                Case Else
                    pnlstk.Width = 284
                    gb1.Visible = False

            End Select

        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub



    'Private Function CalculateProfit(ByVal id As Integer)
    '    Dim prt As Double
    '    prt = dgBDet.Item(12, id).Value
    '    prt = prt - (prt * dgBDet.Item(17, id).Value / 100) 'p discount
    '    prt = prt - (prt * dgBDet.Item(17, id).Value / 100) 'b discount


    '    value = System.Math.Round((stk * Val(dgRec.Item(13, n).Value)), 2)
    '    pcst = value * Val(dgRec.Item(12, n).Value) / 100
    '    totpcst = totpcst + pcst
    '    value = value + pcst     'after pcst
    '    pdis = value * Val(dgRec.Item(16, n).Value) / 100
    '    totpdis = totpdis + pdis
    '    value = value - pdis
    '    bdis = apdis * Val(txtDis.Text) / 100
    '    totbdis = totbdis + bdis
    '    value = value - bdis     'after bill disc
    '    abdis = value
    '    ptax = value * Val(dgRec.Item(15, n).Value) / 100
    '    If Val(dgRec.Item(15, n).Value) <> 0 Then
    '        fnd = 0
    '        For i = 0 To 4
    '            '                If Val(dgRec.Item(15, n).Value) = rtaxary(i, 0) Then
    '            '                    rtaxary(i, 1) = rtaxary(i, 1) + value
    '            '                    rptax(i, 1) = rptax(i, 1) + ptax
    '            '                    fnd = 1
    '            '                    Exit For
    '            '                End If
    '            '            Next i
    '            '            If fnd = 0 Then
    '            '                rtfamt = rtfamt + value + ptax
    '            '            End If
    '            '        Else
    '            '            rtfamt = rtfamt + value
    '            '        End If
    '            '        totptax = totptax + ptax
    '            '        value = value + ptax  'after purchase tax
    '            '        dgRec.Item(23, n).Value = Format(value, "0.00")
    '            '        totvalue = totvalue + value
    '            '    End If
    '            '    'calculating after sale profit amount
    '            '    sr = Val(dgRec.Item(14, n).Value)
    '            '    sr = sr + sr * Val(dgRec.Item(25, n).Value) / 100
    '            '    If dgRec.Item(27, n).Value = "Yes" Then

    '            '        sr = sr - Round((sr * Val(dgRec.Item(26, n).Value)) / (Val(dgRec.Item(26, n).Value) + 100), 2)
    '            '    End If

    '            '    Dim VX
    '            '    VX = Val(dgRec.Item(19, n).Value) + Val(dgRec.Item(20, n).Value)
    '            '    Svalue = sr * VX
    '            '    If Svalue <> 0 Then
    '            '        pro = Round((Svalue - value) * 100 / Svalue, 2)
    '            '    Else
    '            '        pro = 0
    '            '    End If


    '            'End Function


    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        'If MsgBox("Want to 'Exit' from Product Master..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Top = 100) = MsgBoxResult.No Then Exit Sub

        pnlstk.Visible = False
        Me.Close()
    End Sub

    Private Sub tsbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClear.Click
        ClearForm()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        Dim cmd As New OleDb.OleDbCommand
        ' Dim i As Integer
        ' Dim sqlexdt, sqlBildt, sqlpdt, sql As String
        If ProdAdding = False Then
            If CheckUserLocked("Edit Product") = False Then Exit Sub
        End If
        If ProdAdding = True And txtCode.Text = "" Then
            CreateCode()
        End If
        Try
            If txtCode.Text = "" Then
                MsgBox("Product code is not entered..", MsgBoxStyle.Exclamation)
                txtCode.Focus()
                Exit Sub
            End If

            If txtName.Text = "" Then
                MsgBox("Product name is not entered..", MsgBoxStyle.Exclamation)
                txtName.Focus()
                Exit Sub
            End If

            If txtCase1.Text = "" Then
                MsgBox("Case1 is not entered ..", MsgBoxStyle.Exclamation)
                txtCase1.Focus()
                Exit Sub
            End If

            If cbComp.SelectedValue = 0 Then
                MsgBox("Company name is not selected..", MsgBoxStyle.Exclamation)
                cbComp.Focus()
                Exit Sub
            End If

            If txtCase2.Text <> "" And Val(txtUnit2.Text) = 0 Then
                MsgBox("Unit2 is not entered..", MsgBoxStyle.Exclamation)
                txtUnit2.Focus()
                Exit Sub
            End If

            If txtCase3.Text <> "" And Val(txtUnit3.Text) = 0 Then
                MsgBox("Unit3 is not entered..", MsgBoxStyle.Exclamation)
                txtUnit3.Focus()
                Exit Sub
            End If

            If txtsmcode.Visible Then
                If cbSal.SelectedValue = 0 Then
                    txtsmcode.Focus()
                    txtsmcode.SelectAll()
                    Exit Sub
                End If
            Else
                'If cbSal.Text = "" Then
                '    MsgBox("Select a salesman", vbInformation)
                '    Exit Sub
                'End If
            End If

            Me.Cursor = Cursors.WaitCursor
            cmd.Connection = Conn


            If ProdAdding = False Then

                cmd.CommandText = "Update product set prdName =""" & txtName.Text & """,comcode=" & cbComp.SelectedValue & _
                    ",clscode=" & Val(cbClass.SelectedValue) & ",gencode1=" & Val(cbGen1.SelectedValue) & "," & _
                    "PrGrp1code=" & Val(CbGrp1.SelectedValue) & ",PrGrp2code=" & Val(CbGrp2.SelectedValue) & _
                    ",gencode2=" & Val(cbGen2.SelectedValue) & ",gencode3=" & Val(cbGen3.SelectedValue) & "," & _
                    "gencode4=" & Val(cbGen4.SelectedValue) & ",gencode5=" & Val(cbGen5.SelectedValue) & "," & _
                    "strng1=""" + txtGen1.Text + """,strng2=""" & txtGen2.Text & """," & _
                    "strng3=""" & txtGen3.Text & """,strng4=""" & txtGen4.Text & """," & _
                    "strng5=""" & txtGen5.Text & """,sched=""" & cbsch.Text & """,rackno=""" & cbRack.Text & """," & _
                    "Mfr=""" & txtMfr.Text & """,rol= " & Val(txtRol.Text) & ",Roqty= " & Val(txtOrdqty.Text) & "," & _
                    "MaxQty = " & Val(txtMaxqty.Text) & ",Case1=""" & txtCase1.Text & """,Case2 = """ & txtCase2.Text & """," & _
                    "Case3 = """ & txtCase3.Text & """,unit1=" & Val(txtUnit1.Text) & ",unit2 = " & Val(txtUnit2.Text) & "," & _
                    "unit3 = " & Val(txtUnit3.Text) & ",CST = " & Val(txtCST.Text) & "," & "st = " & Val(cbvat.Text) & _
                    ",aliascode=""" & txtalias.Text & """,InvMsg= """ & txtInvMsg.Text & """, " & "Rectmsg=""" & txtRectMsg.Text & _
                    """,ordNote=""" & txtNote.Text & """,RptCase=" & Val(cbInRpt.Text) & ",taxinc=" & IIf(cbTaxinc.Checked, 1, 0) & _
                    ",color=" & lblcolor.BackColor.ToArgb & ",SMan=" & Val(cbSal.SelectedValue) & ",nodisc=" & IIf(ChkDisc.Checked, 1, 0) & _
                    ",srate=" & Val(txtSrate.Text) & ",prate=" & Val(txtPrate.Text) & _
                    " where prdcode = """ & txtCode.Text & """"

            Else

                cmd.CommandText = "Insert into Product (prdcode,prdname,comcode,clscode,gencode1,gencode2,gencode3," & _
                    "gencode4,gencode5,strng1,strng2,strng3,strng4,strng5,sched,rackno,mfr,rol,roqty,maxqty,case1,case2,case3," & _
                    "unit1,unit2,unit3,cst,st,Srate,Prate,aliascode,invmsg,rectmsg,ordnote,RptCase,credt,prgrp1code,prgrp2code,taxinc,color,SMan,nodisc )  values(""" & txtCode.Text & """,""" & _
                    txtName.Text & """," & Val(cbComp.SelectedValue) & "," & Val(cbClass.SelectedValue) & "," & _
                    Val(cbGen1.SelectedValue) & "," & Val(cbGen2.SelectedValue) & "," & Val(cbGen3.SelectedValue) & "," & _
                    Val(cbGen4.SelectedValue) & "," & Val(cbGen5.SelectedValue) & ",""" & txtGen1.Text & """,""" & _
                    txtGen2.Text & """,""" & txtGen3.Text & """,""" & txtGen4.Text & """,""" & txtGen5.Text & """,""" & _
                    cbsch.Text & """,""" & cbRack.Text & """,""" & txtMfr.Text & """," & Val(txtRol.Text) & "," & _
                    Val(txtOrdqty.Text) & "," & Val(txtMaxqty.Text) & ",""" & txtCase1.Text & """,""" & txtCase2.Text & """,""" & _
                    txtCase3.Text & """," & Val(txtUnit1.Text) & "," & Val(txtUnit2.Text) & "," & Val(txtUnit3.Text) & "," & _
                    Val(txtCST.Text) & "," & Val(cbvat.Text) & "," & Val(txtSrate.Text) & "," & Val(txtPrate.Text) & ",""" & _
                    txtalias.Text & """,""" & txtInvMsg.Text & """,""" & txtRectMsg.Text & """,""" & txtNote.Text & """," & _
                    Val(cbInRpt.Text) & ",'" & SysDt & "'," & Val(CbGrp1.SelectedValue) & "," & Val(CbGrp2.SelectedValue) & _
                    "," & IIf(cbTaxinc.Checked, 1, 0) & "," & lblcolor.BackColor.ToArgb & "," & Val(cbSal.SelectedValue) & "," & IIf(ChkDisc.Checked, 1, 0) & ")"

            End If

            cmd.ExecuteNonQuery()
            If ProdAdding = False Then
                InsertProductEdited()
            End If

            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete BarcodeS where PrdCode=""" & txtCode.Text & """"
            cmd.ExecuteNonQuery()


            For i = 0 To dgBarcode.Rows.Count - 2
                If dgBarcode.Item(0, i).Value <> "" Then
                    cmd.CommandText = "Insert into Barcodes(PrdCode, BarCode) values(""" & txtCode.Text & """,""" & dgBarcode.Item(0, i).Value & """)"
                    cmd.ExecuteNonQuery()
                End If

            Next i

            If PrdCodeAsBarCode Then
                If ProdAdding = True Then
                    cmd.CommandText = "Insert into Barcodes(PrdCode, BarCode) values(""" & txtCode.Text & """,""" & txtCode.Text & """)"
                    cmd.ExecuteNonQuery()
                End If
            End If


            If ProdAdding Then
                tsbClear.PerformClick()
                tsbAdd.PerformClick()
            Else
                tsbClear.PerformClick()
            End If
            tsbSave.Enabled = True
            lblStatus.Visible = True
            Me.Cursor = Cursors.Default
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub tsbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDel.Click
        Try
            If CheckUserLocked("Delete Product") = False Then Exit Sub

            If MsgBox("Want to delete the product : " & txtName.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
            If MsgBox("Are you sure. Want to delete the product : " & txtName.Text & "..?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbNo Then Exit Sub
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "Update Product set deleted=1 where prdcode=""" & txtCode.Text + """"
            cmd.Connection = Conn
            cmd.ExecuteNonQuery()
            tsbClear.PerformClick()

        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAdd.Click
        ClearForm()
        tsbAdd.Enabled = False
        tsbSave.Enabled = True
        tsbClear.Enabled = True
        ProdAdding = True
        'lblStatus.Visible = True
        lblStatus.Text = "Adding Product.."
        tbCtrl1.Enabled = True
    End Sub
    Private Sub SalesDetails(ByVal prdcode As String)
        Dim command As New OleDb.OleDbCommand
        'Dim command1 As New OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        'Dim reader1 As OleDb.OleDbDataReader
        Dim i As Integer
        Try
            command.Connection = Conn
            'command1.Connection = Conn
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "Select_ProductTransDetailsSmry"
            command.Parameters.Add("@prdcode", OleDb.OleDbType.VarChar).Value = prdcode
            reader = command.ExecuteReader
            command.Parameters.Clear()
            dgSDetails.Rows.Clear()
            dgSDetails.Columns(1).Visible = False
            While reader.Read
                dgSDetails.Rows.Add()
                dgSDetails.Item(0, i).Value = reader("batch") & ""
                'dgSDetails.Item(1, i).Value = reader("exdt") & ""
                dgSDetails.Item(2, i).Value = reader("sqty") & ""
                dgSDetails.Item(3, i).Value = Math.Round(Val(reader("sval") & ""), 2)
                dgSDetails.Item(4, i).Value = Math.Round(Val(reader("srqty") & ""), 2)
                dgSDetails.Item(5, i).Value = Math.Round(Val(reader("srval") & ""), 2)

                dgSDetails.Item(6, i).Value = Math.Round(Val(reader("RQ") & ""), 2)
                dgSDetails.Item(7, i).Value = Math.Round(Val(reader("FQ") & ""), 2)
                dgSDetails.Item(8, i).Value = Math.Round(Val(reader("REPQ") & ""), 2)
                dgSDetails.Item(9, i).Value = Math.Round(Val(reader("Rva") & ""), 2)


                dgSDetails.Item(10, i).Value = Math.Round(Val(reader("TInRQ") & "") + Val(reader("TInfQ") & "") + Val(reader("TInrepQ") & "") - Val(reader("STrnQTY") & ""), 2)
                dgSDetails.Item(11, i).Value = Math.Round(Val(reader("TInRva") & "") - Val(reader("STrnval") & ""), 2)

                dgSDetails.Item(12, i).Value = Math.Round(Val(reader("brqty") & "") + Val(reader("PRqty") & ""), 2)
                dgSDetails.Item(13, i).Value = Math.Round(Val(reader("brval") & "") + Val(reader("PRval") & ""), 2)

                dgSDetails.Item(14, i).Value = Math.Round(Val(reader("AdjQty") & ""), 2)
                dgSDetails.Item(15, i).Value = Math.Round(Val(reader("AdjVal") & ""), 2)

                i += 1

            End While
            reader.Close()

        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try

    End Sub


    'Private Sub dgSDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSDetails.CellValueChanged
    '    Select Case e.ColumnIndex
    '        Case 1
    '            If DateDiff("d", SysDt, CDate(dgSDetails.Item(1, dgSDetails.CurrentCell.RowIndex).Value)) < 90 Then
    '                dgSDetails.Item(1, dgSDetails.CurrentCell.RowIndex).Style.ForeColor = Color.Red
    '            End If
    '    End Select
    'End Sub


    Private Sub chkbat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbat.CheckedChanged
        If txtCode.Text <> "" Then BatchDetails(txtCode.Text)
    End Sub

    Private Sub txtEdit_LostFocus(sender As Object, e As System.EventArgs) Handles txtEdit.LostFocus
        If Not pnlstk.Visible And txtsmcode.Tag <> "Y" Then txtEdit.Visible = False

    End Sub

    Private Sub txtEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdit.TextChanged

    End Sub

    Private Sub btnup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnup.Click
        'dgBDet.Item
        Dim i, vc, vr As Integer
        Dim command As New OleDb.OleDbCommand
        If dgBDet.CurrentCell Is Nothing Then Exit Sub
        Try
            If dgBDet.RowCount = 0 Then Exit Sub
            If dgBDet.CurrentCell.RowIndex >= 1 Then
                vr = dgBDet.CurrentCell.RowIndex
                vc = dgBDet.CurrentCell.ColumnIndex
                command.Connection = Conn
                'command1.Connection = Conn
                command.CommandType = CommandType.Text

                For i = 0 To dgBDet.Rows.Count - 1
                    If i = dgBDet.CurrentCell.RowIndex - 1 Then
                        command.CommandText = "update batch set seq=" & i + 1 & " where batchid=" & dgBDet.Item(0, i).Value
                        command.ExecuteNonQuery()
                        command.CommandText = "update batch set seq=" & i & " where batchid=" & dgBDet.Item(0, i + 1).Value
                        command.ExecuteNonQuery()
                        i = i + 1
                    Else
                        command.CommandText = "update batch set seq=" & i & " where batchid=" & dgBDet.Item(0, i).Value
                        command.ExecuteNonQuery()
                    End If

                Next
                BatchDetails(txtCode.Text)
                dgBDet.CurrentCell = dgBDet.Item(vc, vr - 1)
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub btndn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndn.Click
        Dim i, vc, vr As Integer
        Dim command As New OleDb.OleDbCommand
        If dgBDet.CurrentCell Is Nothing Then Exit Sub
        If dgBDet.RowCount = 0 Then Exit Sub
        Try
            If dgBDet.CurrentCell.RowIndex <> dgBDet.Rows.Count - 1 Then
                vr = dgBDet.CurrentCell.RowIndex
                vc = dgBDet.CurrentCell.ColumnIndex
                command.Connection = Conn
                'command1.Connection = Conn
                command.CommandType = CommandType.Text

                For i = 0 To dgBDet.Rows.Count - 1
                    If i = dgBDet.CurrentCell.RowIndex Then
                        command.CommandText = "update batch set seq=" & i + 1 & " where batchid=" & dgBDet.Item(0, i).Value
                        command.ExecuteNonQuery()
                        command.CommandText = "update batch set seq=" & i & " where batchid=" & dgBDet.Item(0, i + 1).Value
                        command.ExecuteNonQuery()
                        i = i + 1
                    Else
                        command.CommandText = "update batch set seq=" & i & " where batchid=" & dgBDet.Item(0, i).Value
                        command.ExecuteNonQuery()
                    End If

                Next
                BatchDetails(txtCode.Text)
                dgBDet.CurrentCell = dgBDet.Item(vc, vr + 1)
            End If
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub txtEditDt_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtEditDt.MaskInputRejected

    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub radb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radb1.CheckedChanged
        If radb1.Checked = True Then
            cbInRpt.Text = 1
        End If
    End Sub

    Private Sub radb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radb2.CheckedChanged
        If radb2.Checked = True Then
            cbInRpt.Text = 2
        End If
    End Sub

    Private Sub radb3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radb3.CheckedChanged
        If radb3.Checked = True Then
            cbInRpt.Text = 3
        End If
    End Sub

    Private Sub View_Profit()
        Dim PR As Double
        Dim SR As Double
        Dim pro As Double
        Dim n As Integer
        Dim fld As Integer
        Dim cmd As New OleDb.OleDbCommand
        Try
            cmd.Connection = Conn
            If dgBDet.CurrentCell Is Nothing Then Exit Sub
            fld = dgBDet.CurrentCell.ColumnIndex + 1 ''Choose(dgBDet.CurrentCell.ColumnIndex + 1, "batchid", "seq", "supcode", "batch", "exdt", "stock", "srate", "", "", "", "scst", "Ssch", "stax", "taxinc", "supcode", "billno", "billdt", "prate", "Pdis", "Bdis", "psch", "pcst", "Ptax", "TrRate", "Rqty", "Fqty", "repqty", "Pdate", "Rctno", "brkqty")
            n = dgBDet.CurrentCell.RowIndex
            '           1       2       3           4       5       6       7       8   9   10  11      12      13      14          15          16      17          18      19      20      21      22      23      24      25      26      27          28      29      30      
            'fld =  "batchid", "seq", "supcode", "batch", "exdt", "stock", "srate", "", "", "", "scst", "Ssch", "stax", "taxinc", "supcode", "billno", "billdt", "prate", "Pdis", "Bdis", "psch", "pcst", "Ptax", "TrRate", "Rqty", "Fqty", "repqty", "Pdate", "Rctno", "brkqty")

            PR = Val(dgBDet.Item(17, n).Value) * Val(dgBDet.Item(11, n).Value & "") 'PVAL
            PR = PR - Val(dgBDet.Item(20, n).Value & "") 'SCH

            PR = PR + (PR * Val(dgBDet.Item(21, n).Value) / 100) 'CST
            PR = PR - (PR * Val(dgBDet.Item(18, n).Value) / 100) 'PDIS

            PR = PR - (PR * Val(dgBDet.Item(19, n).Value) / 100) 'BDIS
            PR = PR + (PR * Val(dgBDet.Item(22, n).Value) / 100) 'PVAT

            SR = Val(dgBDet.Item(6, n).Value) * (Val(dgBDet.Item(11, n).Value & "") + Val(dgBDet.Item(12, n).Value & "")) 'SVAL

            If Trim(dgBDet.Item(26, n).Value) = "Yes" Then
                'sr = sr - Round((sr * Val(dgRec.Item(26, n).Value) / (Val(dgRec.Item(26, n).Value) + 100)), 2)
            Else
                SR = SR + (SR * Val(dgBDet.Item(27, n).Value & "") / 100) 'SCST
                SR = SR + (SR * Val(dgBDet.Item(25, n).Value & "") / 100) 'SVAT
            End If

            If SR <> 0 Then
                pro = System.Math.Round((SR - PR) * 100 / SR, 2)
            Else
                pro = 0
            End If
            If fld <> 6 Then
                If System.Math.Abs(Val(dgBDet.Item(30, n).Value) - pro) > 0.5 Then
                    MsgBox("Profit margin has changed.. ! " & Chr(13) & _
                    "       Before editing: " & dgBDet.Item(30, n).Value & Chr(13) & _
                    "       After editing : " & Format(pro, "0.00"), vbInformation)
                End If
            End If
            dgBDet.Item(30, n).Value = Format(pro, "0.00")

            Select Case fld
                Case 7, 11, 12, 13, 14, 18, 19, 20, 21, 22, 23, 24, 25, 26

                    If (Val(dgBDet.Item(11, n).Value & "") + Val(dgBDet.Item(12, n).Value & "")) <> 0 Then
                        PR = PR / (Val(dgBDet.Item(11, n).Value & "") + Val(dgBDet.Item(12, n).Value & ""))
                    End If

                    dgBDet.Item(23, n).Value = Format(PR, "0.000")

                    cmd.CommandText = "Update batch set profit = " & pro & ",TRRATE=" & PR & " where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
                    cmd.ExecuteNonQuery()
            End Select
        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub NextProduct(ByVal cd As Integer)
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ptbl As New DataTable
        Dim tmpcom As Long
        Dim tmpcode As String

        Try

            cmd.Connection = Conn
            cmd.CommandType = CommandType.Text

            ptbl.TableName = "prod"

            tmpcode = txtCode.Text
            tmpcom = Val(cbComp.SelectedValue)
            If tmpcom = 0 Then
                MsgBox("Select a Company..!", vbInformation)
                cbComp.Focus()
                Exit Sub
            End If
            cmd.CommandText = "select prdcode,prdname from product where comcode=" & tmpcom & " order By prdname"

            da.SelectCommand = cmd
            da.Fill(ptbl)

            For I = 0 To ptbl.Rows.Count - 1
                If ptbl.Rows(I).Item("Prdcode") = txtCode.Text Then
                    If cd = 1 Then
                        If I > 0 Then
                            tsbSave.PerformClick()
                            GetProduct(ptbl.Rows(I - 1).Item("prdcode"))
                            BatchDetails(ptbl.Rows(I - 1).Item("prdcode"))
                            tbCtrl1.Enabled = True
                            pnlprod.Visible = False

                        Else
                            MsgBox("First Record.", MsgBoxStyle.Information)
                        End If

                    Else
                        If I = ptbl.Rows.Count - 1 Then
                            MsgBox("Last Record.", MsgBoxStyle.Information)
                        Else
                            tsbSave.PerformClick()
                            GetProduct(ptbl.Rows(I + 1).Item("prdcode"))
                            BatchDetails(ptbl.Rows(I + 1).Item("prdcode"))
                            tbCtrl1.Enabled = True
                            pnlprod.Visible = False

                        End If
                    End If
                    Exit For
                ElseIf txtCode.Text = "" Then
                    If ptbl.Rows.Count > 0 Then
                        GetProduct(ptbl.Rows(0).Item("prdcode"))
                        BatchDetails(ptbl.Rows(0).Item("prdcode"))
                        tbCtrl1.Enabled = True
                        pnlprod.Visible = False

                    End If

                End If
            Next



        Catch er As Exception

            Me.Cursor = Cursors.Default
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub





    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcolor.Click
        ColDlog.ShowDialog()
        Dim ci As Integer
        ci = ColDlog.Color.ToArgb()
        lblcolor.BackColor = Color.FromArgb(ci)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatAdd.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        Dim nextseq, nextid As Long
        Dim SQL As String
        cmd.Connection = Conn
        cmd.CommandText = "select max(batchid) from batch "
        dataredr = cmd.ExecuteReader()
        nextid = 1
        If dataredr.HasRows() Then
            dataredr.Read()
            nextid = Val(dataredr.Item(0) & "") + 1
        End If
        dataredr.Close()

        cmd.CommandText = "select max(seq) from batch where Prdcode=""" + txtCode.Text + """"
        dataredr = cmd.ExecuteReader()
        nextseq = 1
        If dataredr.HasRows() Then
            dataredr.Read()
            nextseq = Val(dataredr.Item(0) & "") + 1
        End If
        dataredr.Close()
        SQL = "insert into Batch(batch,Prate,PCST,Ptax,PDis,SRate,SCST," & _
            "Stax,TaxInc,PrdCode,ExDt,Profit,Pack,Unit,RQty,FQty,RepQty,Stock,BDis,BillNo,BillDt," & _
            "RctNo,Type,SupCode,PDate,Lock,SDis,batchid,seq,flag,BrkQty,SSch,TrRate,psch) " & _
           "Values(''," & Val(txtPrate.Text) & ",0," & Val(cbvat.Text) & " ,0," & Val(txtSrate.Text) & ",0," & Val(cbvat.Text) & ",1,""" & txtCode.Text & """,NULL,0,'',1,0,0,0,0,0,'',NULL,0,'',0,NULL,0,0," & nextid & "," & nextseq & ",'',0,0,0,0)"
        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()
        BatchDetails(txtCode.Text)
    End Sub

    Private Sub dgSDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSDetails.CellContentClick

    End Sub

    Private Sub dgSDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSDetails.CellDoubleClick
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dt As New DataTable
        If pnlshow.Tag = "Y" Then Exit Sub

        'If dgSDetails.CurrentCell.ColumnIndex = 10 And (dgSDetails.CurrentCell.Value & "") <> "" Then


        pnlshow.Tag = "Y"

        pnlshow.Width = 100
        cmd.Connection = Conn
        Select Case dgSDetails.CurrentCell.ColumnIndex
            Case 2, 3 'sales
                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [Bill No] ,INVDT as [Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],convert(bigint,QTY) AS Qty,convert(DECIMAL(12,2),SRATE) as [SRate],convert(decimal(12,2),QTY *srate) as Value FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                """ and (type = '21' OR type = '22' OR type = '23' OR type = '25' OR type = '26') and BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """"


                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 4, 5 'srtn
                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [SRtn No] ,INVDT as [Sr Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt] ,convert(bigint,QTY) AS Qty,convert(DECIMAL(12,2),SRATE) as [SRate],convert(decimal(12,2),QTY *srate) as Value FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                  """ and (type = '31' OR type = '32' OR type = '33' OR type = '35' OR type = '36') and BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """"


                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 10, 11 'TRN

                cmd.CommandText = "SELECT CTYPE as [Type],INVNO as [Trn/Rcpt No] ,INVDT as [Trn/Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt] ,convert(bigint,QTY*-1) AS Qty,0 as [Free],0 as [Repl],convert(DECIMAL(12,2),SRATE) as [Rate],convert(decimal(12,2),(QTY*-1)*srate) as Value,'' as [Bill No],null as [Bill Date],'' as [Supplier       ]  FROM ViewTrans WHERE PRDCODE=""" + txtCode.Text & _
                    """ and (type = '24') and BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """ union all " & _
                    " SELECT 'TRIN' as [Type],RctNo as [Trn/Rcpt No] ,Pdate as [Trn/Rcpt Date],Batch As [Batch],ExDt,RQty as [Qty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),(rQTY*-1)*Trrate) as Value,BillNo as [Bill No],Billdt as [Bill Date],acmaster.acname as [Supplier       ]  from batch,acmaster WHERE batch.supcode=acmaster.accode and PRDCODE=""" + txtCode.Text & _
                  """ and type = '14' AND BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """"

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 80
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 80
                dgshow.Columns(5).Width = 80
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 80
                dgshow.Columns(8).Width = 80
                dgshow.Columns(9).Width = 80

                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Case 6, 7, 8, 9
                cmd.CommandText = " SELECT (case when type='11' then 'CA' else 'CR' END ) as [Type],RctNo as [Rcpt No] ,Pdate as [Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],RQty as [Qty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),rQTY*Trrate) as Value,BillNo as [Bill No],BillDt as [Bill Dt],acmaster.acname as [Supplier       ]  from batch,acmaster WHERE batch.supcode=acmaster.accode and PRDCODE=""" + txtCode.Text & _
                  """ and (type ='12' or type ='11') AND BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """"

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 60
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 60
                dgshow.Columns(8).Width = 60
                dgshow.Columns(9).Width = 80

                dgshow.Columns(10).Width = 80
                dgshow.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                ' dgshow.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                ' dgshow.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight


                'dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight


            Case 12, 13 'prtn


                cmd.CommandText = " SELECT (case when type='12' then 'CA' else 'CR' END ) as [Type],RctNo as [PR/Rcpt No] ,Pdate as [PR/Rcpt Date],Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],RQty as [RtnQty],Fqty as [Free],RepQty as [Repl],convert(DECIMAL(12,2),TrRATE) as [Rate],convert(decimal(12,2),rQTY*TRrate) as Value,BillNo as [Bill No],BillDt as [Bill Dt],acmaster.acname as [Supplier       ]  from BatchRtn,acmaster WHERE BatchRtn.supcode=acmaster.accode   and PRDCODE=""" + txtCode.Text & _
                  """ and (type ='12' or type ='11') AND BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """ and stkles=1 " & _
                 "union all SELECT 'PR' as [Type],prno as [PR/Rcpt No] ,prdt as [PR/Rcpt Date],Batch As [Batch],ExDt,(EXQTY+BRQTY) as [RtnQty],Fqty as [Free],null as [Repl],convert(DECIMAL(12,2),RATE) as [Rate],convert(decimal(12,2),(EXQTY+BRQTY)*rate),'' as [Bill No],null as [Bill Dt],acmaster.acname as [Supplier       ]  from purchasereturn,acmaster WHERE purchasereturn.supcode=acmaster.accode and  CODE=""" + txtCode.Text & _
                  """   AND BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """  "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt
                dgshow.Columns(0).Width = 50
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 80
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 80
                dgshow.Columns(5).Width = 80
                dgshow.Columns(6).Width = 60
                dgshow.Columns(7).Width = 80
                dgshow.Columns(8).Width = 80
                dgshow.Columns(9).Width = 80

                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                dgshow.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            Case 14, 15 'adj


                cmd.CommandText = " SELECT  adjdt as [Adj Date    ],batch.Batch As [Batch],convert(varchar,ExDt,103) as [Ex Dt],qty as [AdjQty],convert(DECIMAL(12,2),batch.Trrate) as [Rate],convert(decimal(12,2),qty*batch.Trrate) as Value, Remarks as [Remarks             ] ,usrname as [User Name ] from batch,stockadj WHERE stockadj.batchid=batch.batchid   and stockadj.prdcode=""" + txtCode.Text & _
                  """  AND batch.BATCH=""" + dgSDetails.Item(0, dgSDetails.CurrentCell.RowIndex).Value & """  "

                da.SelectCommand = cmd
                da.Fill(dt)
                dgshow.DataSource = dt

                dgshow.Columns(0).Width = 100
                dgshow.Columns(1).Width = 80
                dgshow.Columns(2).Width = 100
                dgshow.Columns(3).Width = 80
                dgshow.Columns(4).Width = 100
                dgshow.Columns(5).Width = 60

                dgshow.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                dgshow.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        End Select

        'cmd.CommandText = "Select OrdNo as [Ord No],OrdDt as [Ord Dt],acmaster.acname + ' ' + acmaster.place  as [Supplier],CONVERT(INT,(Qty/UNIT)) as [Qty],CONVERT(INT,(Free*UNIT)) as [Free] ,Pack from " & _
        '    "pndord,acmaster where pndord.supcode=acmaster.accode and pndord.prdcode=""" + _
        '    dgSDetails.Item(2, dgSDetails.CurrentCell.RowIndex).Value + """ "
        Application.DoEvents()
        dgshow.AutoResizeRows()

        If dt.Rows.Count > 0 Then
            'dgshow.ScrollBars = ScrollBars.None
            Dim v As Long = 500
            Dim vw As Long = 26
            Dim VI As Long
            pnlshow.Width = 20
            For I = 0 To dgshow.Columns.Count - 1
                pnlshow.Width = pnlshow.Width + dgshow.Item(I, 0).Size.Width
                'dgshow.Width = dgshow.Width + dgshow.Item(I, 0).Size.Width
            Next



            pnlshow.Top = -250

            pnlshow.Height = 125 - (vw * 2)


            pnlshow.Visible = True
            dgshow.Refresh()
            pnlshow.Left = -275



            For i = 0 To vw Step 2
                pnlshow.Top = pnlshow.Top + 20
                pnlshow.Left = pnlshow.Left + 20
                pnlshow.Height = pnlshow.Height + (i)


                Application.DoEvents()
            Next

            dgshow.Focus()
        Else
            pnlshow.Visible = False

        End If
        pnlshow.Tag = ""
        Exit Sub


        ' End If
    End Sub

    Private Sub dgshow_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgshow.CellContentClick

    End Sub

    Private Sub dgshow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgshow.KeyDown
        If e.KeyCode = Keys.Escape Then
            pnlshow.Visible = False
        End If
    End Sub

    Private Sub dgshow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgshow.LostFocus
        pnlshow.Visible = False
    End Sub

    Private Sub tbCtrl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCtrl1.SelectedIndexChanged

    End Sub

    Private Sub tbCtrl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tbCtrl1.Selecting
        If txtCode.Text = "" Then Exit Sub
        If e.TabPageIndex = 3 And sdetread = False Then
            SalesDetails(txtCode.Text)
        End If
        If e.TabPageIndex = 4 And sdetread = False Then
            monthlytransaction()
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


            cntrol.text = dgBarcode.CurrentCell.Value & ""
            'Else
            'dgBarcode.CurrentCell.Value = cntrol.text
            'End If

            cntrol.visible = True
            cntrol.enabled = True
            Application.DoEvents()
            cntrol.focus()

            dgBarcode.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtBarcodeEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarcodeEdit.KeyPress
        Try
            Dim cmd As New OleDb.OleDbCommand
            'Dim dr As OleDb.OleDbDataReader
            cmd.Connection = Conn

            If Asc(e.KeyChar) = 27 Then
                If dgBarcode.CurrentRow.Index = dgBarcode.RowCount - 1 Then
                    RowClear()
                    TxtBarcodeEdit.Text = ""
                    TxtBarcodeEdit.Visible = False
                    dgBarcode.Enabled = True
                    dgBarcode.Focus()
                Else
                    TxtBarcodeEdit.Visible = False
                    dgBarcode.Enabled = True
                    dgBarcode.Focus()
                End If
            End If


            Dim cmd1 As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            Dim dr1 As OleDb.OleDbDataReader
            Dim PrdNm = ""
            Dim a = ""
            cmd.Connection = Conn
            cmd1.Connection = Conn

            If Asc(e.KeyChar) = 13 Then
                Select Case dgBarcode.CurrentCell.ColumnIndex
                    Case 0
                        If TxtBarcodeEdit.Text = "" Then Application.DoEvents() : TxtBarcodeEdit.Focus() : Exit Sub
                        cmd.CommandText = "Select BarCode,PrdCode from Barcodes where BarCode=""" & TxtBarcodeEdit.Text & """ AND PrdCode<>""" & txtCode.Text & """"
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Read()
                            cmd1.CommandText = "Select PrdName from Product where PrdCode=""" & dr("PrdCode") & """"
                            dr1 = cmd1.ExecuteReader

                            dr1.Read()

                            PrdNm = dr1("PrdName") & ""

                            MsgBox("Barcode already existing for the Product " & PrdNm, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

                            TxtBarcodeEdit.Focus()
                            dr1.Close()
                            Exit Sub
                        Else
                            If TxtBarcodeEdit.Text <> "" Then
                                If dgBarcode.CurrentCell.RowIndex = dgBarcode.Rows.Count - 1 Then
                                    dgBarcode.Rows.Add(TxtBarcodeEdit.Text)
                                    dgBarcode.FirstDisplayedScrollingColumnIndex = 0
                                Else
                                    dgBarcode.Item(dgBarcode.CurrentCell.ColumnIndex, dgBarcode.CurrentRow.Index).Value = TxtBarcodeEdit.Text
                                    dgBarcode.Enabled = True

                                    TxtBarcodeEdit.Visible = False
                                    dgBarcode.Focus()
                                    e.Handled = True
                                    Exit Sub
                                End If
                            End If
                        End If
                        dr.Close()
                        TxtBarcodeEdit.Text = ""
                        dgBarcode.Focus()
                        ShowEditControl(TxtBarcodeEdit)

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

    Private Sub EditGridBarcode()
        Try
            Dim EDROW As Integer = dgBarcode.CurrentCell.RowIndex
            Dim EDCOL As Integer = dgBarcode.CurrentCell.ColumnIndex

            If dgBarcode.CurrentCell.ColumnIndex = 0 Then
                dgBarcode.Columns(0).Selected = True
                dgBarcode.CurrentCell = dgBarcode.Item(dgBarcode.CurrentCell.ColumnIndex, dgBarcode.CurrentRow.Index)
                ShowEditControl(TxtBarcodeEdit)
                TxtBarcodeEdit.Enabled = True
                TxtBarcodeEdit.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgBarcode_CellDoubleClick() Handles dgBarcode.CellDoubleClick
        EditGridBarcode()
    End Sub

    Private Sub dgBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgBarcode.KeyPress
        Try
            If e.KeyChar = Chr(27) Then
                TxtBarcodeEdit.Visible = False
                dgBarcode.Enabled = True
                dgBarcode.Focus()
                e.Handled = True
            End If

            If e.KeyChar = Chr(13) Then
                dgBarcode_CellDoubleClick()
                Application.DoEvents()
                TxtBarcodeEdit.Focus()
                e.Handled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtbarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarcode.KeyPress
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr As OleDb.OleDbDataReader
        If ProdAdding Then Exit Sub
        If e.KeyChar = Chr(13) Then
            cmd.Connection = Conn
            cmd.CommandText = "Select PrdCode from Barcodes where BarCode=""" & txtbarcode.Text & """"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                GetProduct(dr(0))
                BatchDetails(dr(0))
                tbCtrl1.Enabled = True
            End If
        End If

    End Sub

    Private Sub txtbarcode_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbarcode.MouseEnter

    End Sub


    Private Sub txtbarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbarcode.TextChanged

    End Sub

    Private Sub dgBDet_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgBDet.MouseUp
        Dim hitTestInfo As DataGridView.HitTestInfo

        If e.Button = MouseButtons.Right Then
            'If dgBDet.CurrentCell Is Nothing Then Exit Sub
            hitTestInfo = dgBDet.HitTest(e.X, e.Y)
            dgBDet.CurrentCell = dgBDet.Item(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex)
            If dgBDet.CurrentCell Is Nothing Then Exit Sub

            If dgBDet.Item(31, dgBDet.CurrentCell.RowIndex).Value = "Yes" Then
                ContextMenuStrip1.Items(0).Text = "Unlock"
            Else
                ContextMenuStrip1.Items(0).Text = "Lock"
            End If


            If dgBDet.Item(32, dgBDet.CurrentCell.RowIndex).Value & "" = "D" Then
                ContextMenuStrip1.Items(1).Text = "Hide this DL.Note"
                ContextMenuStrip1.Items(1).Visible = True
            Else
                ContextMenuStrip1.Items(1).Visible = False
            End If

            ContextMenuStrip1.Show(dgBDet, New Point(e.X, e.Y))



            'End If


        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub ToNewBillToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToNewBillToolStripMenuItem1.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn

        If dgBDet.Item(31, dgBDet.CurrentCell.RowIndex).Value = "No" Then

            cmd.CommandText = "update batch set lock=1 where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
        Else
            cmd.CommandText = "update batch set lock=0 where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
        End If
        cmd.ExecuteNonQuery()

        BatchDetails(txtCode.Text)

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ShowGenericInfo(txtCode.Text)
    End Sub

    Private Sub HideDNToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HideDNToolStripMenuItem.Click
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn

        If dgBDet.Item(32, dgBDet.CurrentCell.RowIndex).Value = "D" Then
            cmd.CommandText = "update batch set flag='DX' where batchid=" & dgBDet.Item(0, dgBDet.CurrentCell.RowIndex).Value
            cmd.ExecuteNonQuery()
        End If


        BatchDetails(txtCode.Text)
    End Sub

    Private Sub txtsmcode_Enter(sender As Object, e As System.EventArgs) Handles txtsmcode.Enter
        'Dim cmd As New OleDb.OleDbCommand
        'cmd.Connection = Conn
        'cmd.CommandText = "SELECT SalCode FROM SALESMAN WHERE UPPER(PASSWORD)=""" + UCase(txtsmcode.Text) & """"
        'cbSal.SelectedValue = Val(cmd.ExecuteScalar & "")
    End Sub

    Private Sub txtsmcode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtsmcode.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Dim cmd As New OleDb.OleDbCommand
        '    cmd.Connection = Conn
        '    cmd.CommandText = "SELECT SalCode FROM SALESMAN WHERE UPPER(PASSWORD)=""" + UCase(txtsmcode.Text) & """"
        '    cbSal.SelectedValue = Val(cmd.ExecuteScalar & "")
        'End If
    End Sub

    Private Sub txtsmcode_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtsmcode.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = Conn
            cmd.CommandText = "SELECT SalCode FROM SALESMAN WHERE UPPER(PASSWORD)=""" + UCase(txtsmcode.Text) & """"
            cbSal.SelectedValue = Val(cmd.ExecuteScalar & "")
            Application.DoEvents()
            txtName.Focus()
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtsmcode_TextChanged(sender As Object, e As System.EventArgs) Handles txtsmcode.TextChanged
        cbSal.SelectedValue = 0
    End Sub

    Private Sub txtsmcode_VisibleChanged(sender As Object, e As System.EventArgs) Handles txtsmcode.VisibleChanged
        lblsmcode.Visible = txtsmcode.Visible
        cbSal.Enabled = (Not txtsmcode.Visible)
    End Sub

    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOK.Click
        UpdateStock()
        dgBDet.Enabled = True
        dgBDet.Focus()
        InsertProductEdited()
    End Sub

    Private Sub BtnCan_Click(sender As System.Object, e As System.EventArgs) Handles BtnCan.Click
        pnlstk.Visible = False
        txtEdit.Enabled = True
        dgBDet.Enabled = True
        txtEdit.Focus()

        'dgBDet.Focus()
        'pnl.Enabled = False
    End Sub

End Class

