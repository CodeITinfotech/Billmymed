Public Class Reports

    Private sertime As DateTime
    Private sertxt As String
    Private obj As Object
    Private ProdSelected As Boolean
    Dim rptcnt As Long = 0

    Public Class Myview
        Inherits CrystalDecisions.Windows.Forms.CrystalReportViewer

        Private Sub Myview_DoubleClickPage(ByVal sender As Object, ByVal e As CrystalDecisions.Windows.Forms.PageMouseEventArgs) Handles MyBase.DoubleClickPage
            'MsgBox(e.ObjectInfo.Name)
            Dim f As CrystalDecisions.CrystalReports.Engine.ReportObject

            'MsgBox(MyBase.ReportSource.ToString)
            'MsgBox(e.ObjectInfo.Name)
            'MsgBox(e.ObjectInfo.DataContext)

        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Sub New()

        End Sub
    End Class

    Private Sub tv_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        ctbc.Visible = False
        ctbc.Tag = "Y"
        BtnView.Tag = e.Node.Tag

        lblshift.Visible = False
        cbshft.Visible = False
        ChkAllShift.Visible = False
        txtfrom.Visible = False
        txtto.Visible = False
        lblcomdtfrm.Text = "From"
        pnlage.Visible = False
        grpmrp.Visible = False
        chkeststk.Visible = False
        ChkNonStk.Visible = False
        txtcomnos.Visible = False
        lblcomnos.Visible = False
        Chk.Visible = False
        ChkNonStk.Checked = True
        cbschpl.Visible = False
        lblschpl.Visible = False
        gbinv.Visible = False

        Select Case e.Node.Tag
            Case "ScheduleSale"
                ctbc.SelectedTab = ctbc.TabPages(7)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc8.Text = "Schedule wise sales register"
                Chk.Checked = False
                Chk.Text = "With Batch No"
                Chk.Visible = True
            Case "ProdWiseMonthly"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomnos.Visible = True
                txtcomnos.Visible = True
                txtcomnos.Text = 10
                ChkComOpt.Text = "Ascending Order"
                ChkComOpt.Enabled = False
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblc2.Text = "Product wise monthly sales"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("Productwise")
                ' cbrptcom.Items.Add("Company wise")
                'cbrptcom.Items.Add("Classification wise")
                'cbrptcom.Items.Add("Group 1 wise")
                'cbrptcom.Items.Add("Group 2 wise")
                'cbrptcom.Items.Add("Customer wise")
                txtcomnos.Visible = False
                lblcomnos.Visible = False
                CmbSuppRpt.Items.Clear()
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = True
                ChkComOpt.Checked = False
                ChkTax.Visible = False
                cbrptcom.SelectedIndex = 0
                chkCust.Visible = False
                cbcust.Visible = False
            Case "ProdWiseWeekly"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomnos.Visible = True
                txtcomnos.Visible = True
                txtcomnos.Text = 10
                ChkComOpt.Text = "Ascending Order"
                ChkComOpt.Enabled = False
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblc2.Text = "Product wise weekly sales"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("Productwise")
                txtcomnos.Visible = False
                lblcomnos.Visible = False
                ' cbrptcom.Items.Add("Company wise")
                'cbrptcom.Items.Add("Classification wise")
                'cbrptcom.Items.Add("Group 1 wise")
                'cbrptcom.Items.Add("Group 2 wise")
                'cbrptcom.Items.Add("Customer wise")
                CmbSuppRpt.Items.Clear()
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = True
                ChkComOpt.Checked = False
                ChkTax.Visible = False
                cbrptcom.SelectedIndex = 0
                chkCust.Visible = False
                cbcust.Visible = False
            Case "AgeWiseStock"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)

                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtto.Visible = True
                lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                pnlage.Visible = True
                lblc2.Text = "Age wise Stock"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True
                lblrptcb.Visible = False
                ChkComOpt.Visible = False

                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                'chkCust.Visible = False
                'cbcust.Visible = False
                ChkComOpt.Text = "Summary Report"
                ChkComOpt.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "RackWise"
                ctbc.SelectedTab = ctbc.TabPages(6)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc7.Text = "Rack wise stock statement"
            Case "TimeSales"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = False
                gp1.Visible = False
                'ChkSun.Visible = False
                ChkCash.Checked = True
                chkCr.Checked = True
                'ChkSun.Checked = False
                cbrpt.SelectedIndex = 0
                cbrpt.Visible = False
                lblrptcb.Visible = False

                lblc1.Text = "Time wise Sales"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "EditedBills"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = True
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = False
                gp1.Visible = False
                'ChkSun.Visible = False
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                'ChkSun.Checked = False
                cbrpt.SelectedIndex = 0
                cbrpt.Visible = False
                lblrptcb.Visible = False

                lblc1.Text = "Edited Bills Report"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "ProdPurch"

                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                'lblcomdtfrm.Visible = False
                ' dtpComf.Visible = False
                lblcomdtto.Visible = True
                'lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                txtprcnt.Visible = True
                cbrnge.Visible = True

                lblc2.Text = "Product wise Purchase statement"
                cbrnge.Items.Clear()
                cbrnge.Items.Add("Select Profit %")
                cbrnge.Items.Add("Above")
                cbrnge.Items.Add("Below")
                cbrnge.SelectedIndex = 0
                'cbrptcom.Items.Clear()
                'cbrptcom.Items.Add("No Grouping")
                'cbrptcom.Items.Add("Company wise")
                'cbrptcom.Items.Add("Supplier wise")
                'cbrptcom.Items.Add("Classification wise")
                'cbrptcom.Items.Add("Group 1 wise")
                'cbrptcom.Items.Add("Group 2 wise")
                'cbrptcom.SelectedIndex = 1


                cbrptcom.Visible = False
                lblrptcb.Visible = False
                ChkComOpt.Visible = True
                ChkComOpt.Text = "Summary Report"
                ChkComOpt.Enabled = True
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptSRate.Checked = False
                OptTrRate.Visible = False
                lblrpttype.Visible = False
                chkCust.Visible = False
                cbcust.Visible = False

            Case "PrdProf"
                txtcomnos.Visible = True
                lblcomnos.Visible = True
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomnos.Visible = True
                txtcomnos.Visible = True
                txtcomnos.Text = 10
                ChkComOpt.Text = "Ascending Order"
                ChkComOpt.Enabled = False
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblc2.Text = "Profitability"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("Productwise")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                CmbSuppRpt.Items.Clear()
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = True
                ChkComOpt.Checked = False
                chkCust.Visible = False
                cbcust.Visible = False
                cbrptcom.SelectedIndex = 0
            Case "LockPrd"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc6.Text = "Locked Product List"
            Case "AccPay"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc6.Text = "Accounts Payable"
            Case "AccRecv"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc6.Text = "Accounts Receivable"
            Case "ExessStkPrd"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblc2.Text = "Excess Stock Products"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptTrRate.Visible = True
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = False
                cbrptcom.SelectedIndex = 0
                chkCust.Visible = False
                cbcust.Visible = False

            Case "OrdLst"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = True
                cbrpt.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                gp1.Visible = False
                lblrptcb.Visible = False
                ChkSum1.Visible = False
                lblc1.Text = "Order List"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "NonStkPrd"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtto.Visible = True
                lblcomdtto.Visible = False
                dtpComt.Visible = False
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Non Stock Products"

                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True

                lblrptcb.Visible = False
                ChkComOpt.Visible = False
                'ChkComOpt.Text = "Summary Report"
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptSRate.Checked = False
                OptTrRate.Visible = False
                lblrpttype.Visible = True


            Case "SlowPrd"

                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtfrm.Visible = True
                lblcomdtto.Visible = False
                lblcomdtfrm.Text = "                Days not sold"
                ' lblcomdtto.Text = "From "
                txtto.Visible = True
                txtto.Text = "100"
                dtpComt.Visible = False
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                ChkComOpt.Text = "Short expiry only"
                ChkComOpt.Visible = True
                ChkComOpt.Enabled = False

                lblc2.Text = "Slow Moving Products"

                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True

                lblrptcb.Visible = False

                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "SlowPrdPurchase"

                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtfrm.Visible = True
                lblcomdtto.Visible = True
                lblcomdtfrm.Text = "Purchase days"
                ' lblcomdtto.Text = "From "
                txtto.Visible = True
                txtto.Text = "40"
                txtfrom.Visible = True
                txtfrom.Text = "30"

                dtpComt.Visible = False
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                ChkComOpt.Text = "Short expiry only"
                ChkComOpt.Visible = True
                ChkComOpt.Enabled = False
                lblc2.Text = "Slow Moving Products (by purchase date)"

                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True

                lblrptcb.Visible = False

                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False

            Case "PurRtnDet"
                ctbc.SelectedTab = ctbc.TabPages(4)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)

                lblc1.Text = e.Node.Text
                lblc5.Text = "Purchase Return Details"

                CmbSuppRpt.Items.Clear()
                CmbSuppRpt.Items.Add("Detail")
                CmbSuppRpt.Items.Add("Summary")

                CmbSuppRpt.SelectedIndex = 0
                CmbSuppRpt.Visible = True
                lblsuprpt.Visible = True
                GroupBox1.Visible = False
                ChkSmryPurchase.Visible = True
                'ctbc.SelectedTab = ctbc.TabPages(0)
                'ctbc.Visible = True
                'tbc.SelectedTab = tbc.TabPages(0)
                'gp2.Visible = False
                'gp1.Visible = False
                'ChkSun.Visible = True
                'cbrpt.Visible = False
                'ChkCash.Checked = False
                'chkCr.Checked = False
                'ChkSun.Checked = False
                'gp1.Visible = False
                'lblrptcb.Visible = False
                'ChkSum1.Visible = True
                'ChkSum1.Text = "Show Only Pending"
                'lblc1.Text = "Purchase Return Details"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkPurEst.Visible = False
                Else
                    ChkPurEst.Visible = True
                End If

            Case "PurRtnSettled"
                ctbc.SelectedTab = ctbc.TabPages(4)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)

                lblc1.Text = e.Node.Text
                lblc5.Text = "Purchase Return Settled"

                CmbSuppRpt.Items.Clear()
                CmbSuppRpt.Items.Add("Detail")
                CmbSuppRpt.Items.Add("Summary")

                CmbSuppRpt.SelectedIndex = 0
                CmbSuppRpt.Visible = True
                lblsuprpt.Visible = True
                GroupBox1.Visible = False
                ChkSmryPurchase.Visible = False
                'ctbc.SelectedTab = ctbc.TabPages(0)
                'ctbc.Visible = True
                'tbc.SelectedTab = tbc.TabPages(0)
                'gp2.Visible = False
                'gp1.Visible = False
                'ChkSun.Visible = True
                'cbrpt.Visible = False
                'ChkCash.Checked = False
                'chkCr.Checked = False
                'ChkSun.Checked = False
                'gp1.Visible = False
                'lblrptcb.Visible = False
                'ChkSum1.Visible = True
                'ChkSum1.Text = "Show Only Pending"
                'lblc1.Text = "Purchase Return Details"
                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkPurEst.Visible = False
                Else
                    ChkPurEst.Visible = True
                End If

            Case "SalRtnDet"

                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = True
                cbrpt.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                gp1.Visible = False
                lblrptcb.Visible = False
                lblc1.Text = "Sales Return Details"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "PrdList"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtto.Visible = True
                lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Product List"

                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True

                lblrptcb.Visible = False
                ChkComOpt.Visible = False
                'ChkComOpt.Text = "Summary Report"
                OptBrate.Visible = False
                OptSRate.Visible = False
                OptSRate.Checked = False
                OptTrRate.Visible = False
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "SupComLst"

                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)



                lblc6.Text = "Supplier wise Company List"
            Case "ComSupLst"

                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)



                lblc6.Text = "Company wise Supplier List"
            Case "ComLst"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)



                lblc6.Text = "Company List"
            Case "SupLst"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)



                lblc6.Text = "Supplier List"

            Case "PndDelNote"
                ctbc.SelectedTab = ctbc.TabPages(5)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)



                lblc6.Text = "Pending Delivery Notes"


            Case "StkAdj"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)

                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "to"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Stock Adjustments"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True
                lblrptcb.Visible = False
                ChkComOpt.Visible = False
                'ChkComOpt.Text = "Summary"
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False

            Case "ExpStk"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "to"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                ChkComOpt.Visible = False
                lblc2.Text = "Expiry forcast"

                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.Items.Add("Small format")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True

                lblrptcb.Visible = False
                'ChkComOpt.Visible = True
                'ChkComOpt.Text = "Summary Report"
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "StkSale"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                'lblcomdtfrm.Visible = False
                ' dtpComf.Visible = False
                lblcomdtfrm.Visible = True
                lblcomdtto.Visible = True
                'lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                dtpComf.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Stock and Sale statement"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1


                cbrptcom.Visible = True
                lblrptcb.Visible = False
                ChkComOpt.Visible = True
                ChkComOpt.Text = "Summary Report"
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True

                chkCust.Visible = False
                cbcust.Visible = False

            Case "BatchStk"
                grpmrp.Visible = True
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)

                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtto.Visible = True
                lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Batchwise Stock"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True
                lblrptcb.Visible = False
                ChkComOpt.Visible = False
                ChkNonStk.Visible = True
                'ChkComOpt.Text = "Summary"
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "StkStmt"
                chkeststk.Visible = True
                ChkComOpt.Enabled = True
                ChkNonStk.Visible = True
                ctbc.SelectedTab = ctbc.TabPages(1)
                grpmrp.Visible = True
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                ChkTax.Visible = True
                lblcomdtfrm.Visible = False
                dtpComf.Visible = False
                lblcomdtto.Visible = True
                lblcomdtto.Text = "As on"
                dtpComt.Visible = True
                ChkComOpt.Visible = True
                txtprcnt.Visible = False
                cbrnge.Visible = False
                ChkComOpt.Text = "Summary Report"
                lblc2.Text = "Closing Stock"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.Items.Add("Tax wise")
                cbrptcom.Items.Add("Value wise")
                cbrptcom.SelectedIndex = 1
                cbrptcom.Visible = True
                lblrptcb.Visible = False

                'ChkComOpt.Text = "Summary"
                OptBrate.Visible = True
                OptSRate.Visible = True
                OptSRate.Checked = True
                OptTrRate.Visible = True
                lblrpttype.Visible = True
                chkCust.Visible = False
                cbcust.Visible = False
            Case "CustwiseSales"


                ctbc.SelectedTab = ctbc.TabPages(3)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                cbcustwiseser.SelectedIndex = 0
                chkCustwiseSmry.SelectedIndex = 0
                'gp2.Visible = False
                'gp1.Visible = False
                'ChkSun.Visible = False
                'ChkCash.Checked = False
                'chkCr.Checked = False
                'ChkSun.Checked = False
                'cbrpt.SelectedIndex = 3
                'cbrpt.Visible = False
                'lblrptcb.Visible = False
                lblc4.Text = "Customer wise sales"

                'cbcustwiseser.Visible = False
                Label12.Visible = False
                lblser.Visible = False
                cmbcust.Visible = False
                'cbSearchRpt.Visible = False
                'lblSearchRpt.Visible = False
                chklstCust.Visible = False
                ChkAllCust.Visible = False

            Case "VATRpt"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                cbrpt.SelectedIndex = 0
                cbrpt.Visible = False
                lblrptcb.Visible = False
                lblc1.Text = "VAT Reports"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "SJ", "SalesList"
                ChkSum1.Visible = False
                ctbc.SelectedTab = ctbc.TabPages(0)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = True
                gp1.Visible = True
                ChkSun.Visible = True
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                ChkSun.Checked = True
                cbrpt.Items.Clear()
                cbrpt.Items.Add("Detail")
                cbrpt.Items.Add("Daily")
                cbrpt.Items.Add("Monthly")
                cbrpt.SelectedIndex = 1
                cbrpt.Visible = True
                lblrptcb.Visible = True
                frmlbl.Visible = False
                tolbl.Visible = False
                bfrmtxt.Visible = False
                btotxt.Visible = False
                Application.DoEvents()
                If e.Node.Tag = "SJ" Then
                    lblc1.Text = "Sales Journal"
                    cbrpt.Items.Add("With Patient Name")
                ElseIf e.Node.Tag = "SalesList" Then
                    lblc1.Text = "Sales List"
                    cbrpt.Items.Add("Patient Wise")
                    cbrpt.Items.Add("Billno. From-To")
                End If

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

                '    lblc.Text = e.Node.Text
                'Case "SalesList"
                '    ctbc.SelectedTab = ctbc.TabPages(0)
                '    ctbc.Visible = True
                '    tbc.SelectedTab = tbc.TabPages(0)
                '    lblc.Text = e.Node.Text

            Case "ProdWiseSalesDiscount"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                txtprcnt.Visible = False
                cbrnge.Visible = False

                lblc2.Text = "Product wise Sales Discount"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")


                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = True

                ChkComOpt.Text = "Short Item only"
                ChkComOpt.Enabled = False
                cbrptcom.SelectedIndex = 0
                'ShowList
                chkCust.Visible = False
                cbcust.Visible = False
            Case "ShiftJou", "ShiftCash"

                lblshift.Visible = True
                cbshft.Visible = True
                ChkAllShift.Visible = True
                ChkSum1.Visible = False
                ctbc.SelectedTab = ctbc.TabPages(0)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = True
                gp1.Visible = True
                ChkSun.Visible = True
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                ChkSun.Checked = True
                cbrpt.Items.Clear()
                cbrpt.Items.Add("Detail")
                cbrpt.Items.Add("Summary")
                ' cbrpt.Items.Add("Monthly")
                cbrpt.SelectedIndex = 0
                cbrpt.Visible = True
                lblrptcb.Visible = True
                Application.DoEvents()
                If e.Node.Tag = "ShiftJou" Then
                    lblc1.Text = "Shift wise Sales Journal"
                ElseIf e.Node.Tag = "ShiftCash" Then
                    lblc1.Text = "Shift wise Cash Report"
                End If

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

                '    lblc.Text = e.Node.Text
                'Case "SalesList"
                '    ctbc.SelectedTab = ctbc.TabPages(0)
                '    ctbc.Visible = True
                '    tbc.SelectedTab = tbc.TabPages(0)
                '    lblc.Text = e.Node.Text

            Case "SmanWiseSales"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc1.Text = "Salesman wise Sales"
                gp2.Text = "Sales"
                gp2.Visible = True
                gp1.Visible = True
                ChkSun.Visible = True
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                ChkSun.Checked = True

                cbrpt.Items.Clear()
                cbrpt.Items.Add("Detail")
                cbrpt.Items.Add("Summary")
                cbrpt.Items.Add("Monthly")
                cbrpt.SelectedIndex = 1
                cbrpt.Visible = True
                lblrptcb.Visible = True

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "DocWiseSales"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc1.Text = "Doctor wise Sales"
                gp2.Text = "Sales"
                gp2.Visible = True
                gp1.Visible = True
                ChkSun.Visible = True
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                ChkSun.Checked = True
                cbrpt.Items.Clear()
                cbrpt.Items.Add("Detail")
                cbrpt.Items.Add("Summary")
                cbrpt.Items.Add("Monthly")

                cbrpt.SelectedIndex = 1
                cbrpt.Visible = True
                lblrptcb.Visible = True

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "ProdWiseSales"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ChkTax.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False
                txtprcnt.Visible = False
                cbrnge.Visible = False
                gbinv.Visible = True
                lblc2.Text = "Product wise Sales"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")


                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                ChkComOpt.Visible = True

                ChkComOpt.Text = "Short Item only"
                ChkComOpt.Enabled = True
                cbrptcom.SelectedIndex = 0
                'ShowList
                chkCust.Visible = False
                cbcust.Visible = False
                cbSupwise.Enabled = True
                ChkSupWise.Enabled = True
                chkdom.Enabled = True

            Case "DaySaleGraph"
                ctbc.SelectedTab = ctbc.TabPages(2)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblc1.Text = e.Node.Text

            Case "SundryList"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = True
                cbrpt.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                gp1.Visible = False
                lblrptcb.Visible = False

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

                lblc1.Text = "Sundry Sales List"

            Case "PurReg", "PurList"
                ctbc.SelectedTab = ctbc.TabPages(4)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                GroupBox1.Visible = True
                ChkSmryPurchase.Visible = False
                lblc1.Text = e.Node.Text

                If e.Node.Tag = "PurReg" Then
                    lblc5.Text = "Purchse Register"
                Else
                    lblc5.Text = "Purchse List"
                End If
                CmbSuppRpt.Items.Clear()
                CmbSuppRpt.Items.Add("Detail")
                CmbSuppRpt.Items.Add("Summary")
                CmbSuppRpt.Items.Add("Day Summary")
                CmbSuppRpt.Items.Add("Monthly")
                If e.Node.Tag = "PurList" Then
                    CmbSuppRpt.Items.Add("Product")
                End If
                CmbSuppRpt.Items.Add("Supplier Wise")
                CmbSuppRpt.SelectedIndex = 0
                CmbSuppRpt.Visible = True
                lblsuprpt.Visible = True

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkPurEst.Visible = False
                Else
                    ChkPurEst.Visible = True
                End If

            Case "StkLdg"
                ctbc.SelectedTab = ctbc.TabPages(2)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Visible = False
                gp2.Text = "Purchase"
                ChkSun.Visible = False
                lblc1.Text = e.Node.Text
                ChkCash.Checked = True
                chkCr.Checked = True
                ChkCrCd.Checked = True
                lblc3.Text = "Stock Ledger"

            Case "VATRpt"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Text = "Sales"
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                cbrpt.SelectedIndex = 0
                cbrpt.Visible = False
                lblrptcb.Visible = False
                lblc1.Text = "VAT Reports"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "ProdEdit"
                ctbc.SelectedTab = ctbc.TabPages(0)
                ChkSum1.Visible = False
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                gp2.Visible = False
                gp1.Visible = False
                ChkSun.Visible = True
                cbrpt.Visible = False
                ChkCash.Checked = False
                chkCr.Checked = False
                ChkCrCd.Checked = False
                ChkSun.Checked = False
                gp1.Visible = False
                lblrptcb.Visible = False
                lblc1.Text = "Product Edited List"

                If UserLocked.Contains("AllowEstimateSales") Then
                    ChkEst.Visible = False
                Else
                    ChkEst.Visible = True
                End If

            Case "TransOut"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Product wise Transfer Out"
                cbrptcom.Items.Clear()
                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.Items.Add("Customer wise")

                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = True
                lblrptcb.Visible = True
                lblrpttype.Visible = True
                'ChkComOpt.Visible = True
                chkCust.Visible = True
                cbcust.Visible = True
                'ChkComOpt.Text = "Short Item only"
                ChkComOpt.Visible = False
                cbrptcom.SelectedIndex = 0

            Case "DateWise"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Date wise Customer Wise"
                cbrptcom.Items.Clear()

                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.Items.Add("Customer wise")


                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = False
                lblrptcb.Visible = True
                lblrpttype.Visible = False
                'ChkComOpt.Visible = True
                chkCust.Visible = True
                cbcust.Visible = True
                'ChkComOpt.Text = "Short Item only"
                ChkComOpt.Visible = False
                cbrptcom.SelectedIndex = 0
                'ShowList

            Case "Customer Wise"
                ctbc.SelectedTab = ctbc.TabPages(1)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                lblcomdtfrm.Visible = True
                dtpComf.Visible = True
                lblcomdtto.Visible = True
                lblcomdtto.Text = "To"
                dtpComt.Visible = True
                lblcomnos.Visible = False
                txtcomnos.Visible = False

                lblc2.Text = "Customer wise Date Wise"
                cbrptcom.Items.Clear()

                cbrptcom.Items.Add("No Grouping")
                cbrptcom.Items.Add("Company wise")
                cbrptcom.Items.Add("Supplier wise")
                cbrptcom.Items.Add("Classification wise")
                cbrptcom.Items.Add("Group 1 wise")
                cbrptcom.Items.Add("Group 2 wise")
                cbrptcom.Items.Add("Customer wise")


                OptBrate.Visible = False
                OptSRate.Visible = False
                OptTrRate.Visible = False
                cbrptcom.Visible = False
                lblrptcb.Visible = True
                lblrpttype.Visible = False
                'ChkComOpt.Visible = True
                chkCust.Visible = True
                cbcust.Visible = True
                'ChkComOpt.Text = "Short Item only"
                ChkComOpt.Visible = False
                cbrptcom.SelectedIndex = 0
                'ShowList

            Case "CustWiseBillWise"
                chkinc.Visible = False
                txtser.Visible = False
                cbccard.Visible = False
                'lblcomnnos.Visible = False
                'txtcommonos.Visible = False
                'txtcommonos.Text = 10
                ctbc.SelectedTab = ctbc.TabPages(3)
                ctbc.Visible = True
                tbc.SelectedTab = tbc.TabPages(0)
                cmbcust.Enabled = False
                cbcust.Visible = False
                cmbcust.SelectedText = ""
                cmbcust.Text = ""
                cbcustwiseser.Visible = False
                Label12.Visible = False
                chkCustwiseSmry.Visible = False
                lblser.Visible = False
                cmbcust.Visible = False
                'cbSearchRpt.Visible = False
                'lblSearchRpt.Visible = False
                chklstCust.Visible = True
                ChkAllCust.Visible = True
                lblc4.Text = "Customer wise Bill Wise"
                Label18.Visible = False
        End Select

        ctbc.Tag = ""
    End Sub


    Private Function CreateVATRpt() As DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim scode(5) As Long
        Dim svcode(5) As Long
        Dim Pcode(5) As Long
        Dim Pvcode(5) As Long
        Dim Ptf As Long
        Dim stf As Long
        Dim padj As Long
        Dim sadj As Long
        Dim TAXP(5) As Double
        Dim sval(5) As Double
        Dim Pval(5) As Double
        Dim svval(5) As Double
        Dim pvval(5) As Double
        Dim padjval As Double
        Dim sadjval As Double
        Dim stfval As Double
        Dim ptfval As Double

        Dim accmd As New OleDb.OleDbCommand
        accmd.Connection = Conn
        accmd.CommandText = "Select Accode,taxper,surch,seq,flag from tax order by flag,seq "
        Dim dataredr As OleDb.OleDbDataReader = accmd.ExecuteReader()
        If dataredr.HasRows Then
            Do While dataredr.Read()
                Select Case Val(dataredr.Item("flag"))
                    Case 1
                        scode(dataredr.Item("seq")) = dataredr.Item(0)
                        TAXP(dataredr.Item("seq")) = Val(dataredr.Item(1))
                    Case 2
                        svcode(dataredr.Item("seq")) = dataredr.Item(0)
                    Case 31
                        Pcode(dataredr.Item("seq")) = dataredr.Item(0)
                    Case 32
                        Pvcode(dataredr.Item("seq")) = dataredr.Item(0)
                    Case 4
                        stf = dataredr.Item(0)
                    Case 34
                        Ptf = dataredr.Item(0)
                    Case 6
                        sadj = dataredr.Item(0)
                    Case 36
                        padj = dataredr.Item(0)
                End Select
            Loop
        End If

        dataredr.Close()
        For i As Integer = 1 To 5
            If TAXP(i) <> 0 Then





                accmd.CommandText = "Select sum(amt) from ledger where accode=" & scode(i) & _
                       " and trndate>=convert(datetime,'" & dtf.Value.Date & _
                       "') and trndate<=convert(datetime,'" & dtt.Value.Date & "') and (trntype='Sv' or Trntype='Sr')"


                sval(i) = Val(accmd.ExecuteScalar & "") * -1


                'accmd.CommandText = "Select sum(amt" & i & " ) from invtotal where cancelled =0 and (type='31' or type='32' or type='36')  " & _
                '       " and invdt>=convert(datetime,'" & dtf.Value.Date & _
                '       "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "
                'sval(i) = sval(i) - Val(accmd.ExecuteScalar & "")


                '-------------------

                'accmd.CommandText = "Select sum(tax" & i & " ) from invtotal where cancelled =0 and (type='21' or type='22' or type='26')  " & _
                '        " and invdt>=convert(datetime,'" & dtf.Value.Date & _
                '        "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "



                accmd.CommandText = "Select sum(amt) from ledger where accode=" & svcode(i) & _
                       " and trndate>=convert(datetime,'" & dtf.Value.Date & _
                       "') and trndate<=convert(datetime,'" & dtt.Value.Date & "') and (trntype='Sv' or Trntype='Sr') "


                svval(i) = (sval(i) * TAXP(i) / 100) 'Val(accmd.ExecuteScalar & "")


                'accmd.CommandText = "Select sum(tax" & i & " ) from invtotal where cancelled =0 and (type='31' or type='32' or type='36')  " & _
                '       " and invdt>=convert(datetime,'" & dtf.Value.Date & _
                '       "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "
                'svval(i) = svval(i) - Val(accmd.ExecuteScalar & "")


                accmd.CommandText = "Select sum(amt) from ledger where accode=" & Pcode(i) & _
                       " and trndate>=convert(datetime,'" & dtf.Value.Date & _
                       "') and trndate<=convert(datetime,'" & dtt.Value.Date & "') and (trntype='Pu' or Trntype='Pr') "
                Pval(i) = Val(accmd.ExecuteScalar & "")

                accmd.CommandText = "Select sum(amt) from ledger where accode=" & Pvcode(i) & _
                        " and trndate>=convert(datetime,'" & dtf.Value.Date & _
                        "') and trndate<=convert(datetime,'" & dtt.Value.Date & "')  and (trntype='Pu' or Trntype='Pr') "
                pvval(i) = Val(accmd.ExecuteScalar & "")

            End If
        Next i


        '' accmd.CommandText = "Select sum(tfamt) from invtotal where cancelled =0 and (type='21' or type='22' or type='26')  " & _
        '               " and invdt>=convert(datetime,'" & dtf.Value.Date & _
        '               "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "


        accmd.CommandText = "Select sum(amt) from ledger where accode=" & stf & _
               " and trndate>=convert(datetime,'" & dtf.Value.Date & _
               "') and trndate<=convert(datetime,'" & dtt.Value.Date & "') and (trntype='Sv' or Trntype='Sr') "


        stfval = Val(accmd.ExecuteScalar & "") * -1


        'accmd.CommandText = "Select sum(tfamt) from invtotal where cancelled =0 and (type='31' or type='32' or type='36')  " & _
        '       " and invdt>=convert(datetime,'" & dtf.Value.Date & _
        '       "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "
        'stfval = stfval - Val(accmd.ExecuteScalar & "")


        'accmd.CommandText = "Select sum(AddAmt-dedamt) from invtotal where cancelled =0 and (type='21' or type='22' or type='26')  " & _
        '                    " and invdt>=convert(datetime,'" & dtf.Value.Date & _
        '                    "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "

        accmd.CommandText = "Select sum(amt) from ledger where accode=" & sadj & _
             " and trndate>=convert(datetime,'" & dtf.Value.Date & _
             "') and trndate<=convert(datetime,'" & dtt.Value.Date & "') and (trntype='Sv' or Trntype='Sr') "

        sadjval = Val(accmd.ExecuteScalar & "") * -1


        'accmd.CommandText = "Select sum(AddAmt-dedamt) from invtotal where cancelled =0 and (type='31' or type='32' or type='36')  " & _
        '       " and invdt>=convert(datetime,'" & dtf.Value.Date & _
        '       "') and invdt<=convert(datetime,'" & dtt.Value.Date & "') "
        'sadjval = sadjval - Val(accmd.ExecuteScalar & "")





        accmd.CommandText = "Select sum(amt) from ledger where accode=" & Ptf & _
           " and trndate>=convert(datetime,'" & dtf.Value.Date & _
           "') and trndate<=convert(datetime,'" & dtt.Value.Date & "')  and (trntype='Pu' or Trntype='Pr')  "
        ptfval = Val(accmd.ExecuteScalar & "")



        accmd.CommandText = "Select sum(amt) from ledger where accode=" & padj & _
            " and trndate>=convert(datetime,'" & dtf.Value.Date & _
            "') and trndate<=convert(datetime,'" & dtt.Value.Date & "')  and (trntype='Pu' or Trntype='Pr') "
        padjval = Val(accmd.ExecuteScalar & "")

        Dim tb As New DataSet1.VATRptTblDataTable
        For i = 1 To 5
            If TAXP(i) <> 0 Then
                tb.Rows.Add()
                tb.Rows(tb.Rows.Count - 1).Item("Flg") = 1
                tb.Rows(tb.Rows.Count - 1).Item("amt") = sval(i)
                tb.Rows(tb.Rows.Count - 1).Item("vat") = svval(i)
                tb.Rows(tb.Rows.Count - 1).Item("seq") = i
                tb.Rows(tb.Rows.Count - 1).Item("Caption") = Format(TAXP(i), "0.00") & " %"
            End If
        Next


        tb.Rows.Add()
        tb.Rows(tb.Rows.Count - 1).Item("Flg") = 1
        tb.Rows(tb.Rows.Count - 1).Item("amt") = stfval
        tb.Rows(tb.Rows.Count - 1).Item("vat") = 0
        tb.Rows(tb.Rows.Count - 1).Item("seq") = 6
        tb.Rows(tb.Rows.Count - 1).Item("Caption") = "Tax Free"

        tb.Rows.Add()
        tb.Rows(tb.Rows.Count - 1).Item("Flg") = 1
        tb.Rows(tb.Rows.Count - 1).Item("amt") = sadjval
        tb.Rows(tb.Rows.Count - 1).Item("vat") = 0
        tb.Rows(tb.Rows.Count - 1).Item("seq") = 7
        tb.Rows(tb.Rows.Count - 1).Item("Caption") = "Sales Adj."

        For i = 1 To 5
            If TAXP(i) <> 0 Then
                tb.Rows.Add()
                tb.Rows(tb.Rows.Count - 1).Item("Flg") = 2
                tb.Rows(tb.Rows.Count - 1).Item("amt") = Pval(i)
                tb.Rows(tb.Rows.Count - 1).Item("vat") = pvval(i)
                tb.Rows(tb.Rows.Count - 1).Item("seq") = i + 9
                tb.Rows(tb.Rows.Count - 1).Item("Caption") = Format(TAXP(i), "0.00") & " %"
            End If
        Next

        tb.Rows.Add()
        tb.Rows(tb.Rows.Count - 1).Item("Flg") = 2
        tb.Rows(tb.Rows.Count - 1).Item("amt") = ptfval
        tb.Rows(tb.Rows.Count - 1).Item("vat") = 0
        tb.Rows(tb.Rows.Count - 1).Item("seq") = 16
        tb.Rows(tb.Rows.Count - 1).Item("Caption") = "Tax Free"

        tb.Rows.Add()
        tb.Rows(tb.Rows.Count - 1).Item("Flg") = 2
        tb.Rows(tb.Rows.Count - 1).Item("amt") = padjval
        tb.Rows(tb.Rows.Count - 1).Item("vat") = 0
        tb.Rows(tb.Rows.Count - 1).Item("Caption") = "Purchase Adj."
        tb.Rows(tb.Rows.Count - 1).Item("seq") = 17
        CreateVATRpt = tb



    End Function




    Private Sub Reports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.Wheat
        ShowList()
        Me.ctbc.Region = New Region(New RectangleF(Me.ctbc.SelectedTab.Left, Me.ctbc.SelectedTab.Top, Me.ctbc.SelectedTab.Width, Me.ctbc.SelectedTab.Height))
        dtt.Value = SysDt

        dtf.Value = CDate("01/" & Format(SysDt, "MM/yyyy"))

        dtpComf.Value = dtf.Value
        dtpComt.Value = SysDt

        dtpcustwisef.Value = dtf.Value
        dtpcustwiset.Value = SysDt

        dtprodf.Value = dtf.Value
        dtprodt.Value = SysDt

        DtpSuppf.Value = dtf.Value
        DtpSuppt.Value = SysDt
        Me.WindowState = FormWindowState.Maximized
        Me.Show()
        tv.Nodes(0).Expand()
        tv.Nodes(0).Nodes(0).Expand()
        tv.Nodes(0).Nodes(1).Expand()
        tv.Nodes(0).Nodes(2).Expand()
        tv.SelectedNode = tv.Nodes(0)
        'tv.Nodes(0).Nodes("nodesales").Nodes("Profitability").Remove()
        Dim cmd As New OleDb.OleDbCommand
        Dim shft As Integer

        cmd.CommandText = "select workshiftcount  from settings"
        cmd.Connection = Conn
        shft = cmd.ExecuteScalar
        For i = 1 To shft
            cbshft.Items.Add(i)
        Next
        cmd.CommandText = "select  workshift from settings"


        For I = 0 To tv.Nodes.Count - 1
            For v = 0 To tv.Nodes(I).Nodes.Count - 1
                Dim ml As Integer = tv.Nodes(I).Nodes(v).Nodes.Count - 1
                For x = ml To 0 Step -1
                    If Not CheckUserLocked(tv.Nodes(I).Nodes(v).Nodes(x).Text, True, Nothing) Then
                        Dim vx As String = tv.Nodes(I).Nodes(v).Nodes(x).Text
                        tv.Nodes(I).Nodes(v).Nodes.RemoveAt(x)

                    End If
                Next
            Next
        Next

        For I = 0 To tv.Nodes.Count - 1
            If tv.Nodes(I).Nodes.Count = 0 Then
                tv.Nodes(I).Remove()
            Else

                Dim g As Integer = tv.Nodes(I).Nodes.Count - 1

                For v = g To 0 Step -1
                    Try
                        If tv.Nodes(I).Nodes(v).Nodes.Count = 0 Then
                            tv.Nodes(I).Nodes(v).Remove()
                        Else

                        End If
                    Catch ex As Exception

                    End Try


                Next
            End If
        Next


        shft = cmd.ExecuteScalar
        cbshft.Text = shft
    End Sub
    Private Sub CompanyList()
        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader

        cmd.Connection = Conn
        ' ChkSupWise.Enabled = False
        ChkComOpt.Enabled = False
        If cbSupwise.SelectedValue Is Nothing Then Exit Sub
        If ChkSupWise.Checked Then

            If chkdom.Checked Then
                cmd.CommandText = "Select company.comCode,comName   from company where fsupcode=" & cbSupwise.SelectedValue & "  order by comname"
            Else
                cmd.CommandText = "Select company.comCode,comName   from company,supcom where supcom.comcode=company.comcode and supcom.supcode=" & cbSupwise.SelectedValue & "  order by comname"
            End If

        Else

            cmd.CommandText = "Select comCode,comName  from company order by comname"
        End If


        dataredr = cmd.ExecuteReader()
        lstcom.Items.Clear()
        ChkComAll.Checked = False
        If dataredr.HasRows Then
            Do While dataredr.Read()
                lstcom.Items.Add(New MyList(dataredr.Item("ComName"), dataredr.Item("Comcode")))
                'lstcom.SetItemChecked(lstcom.Items.Count -1,t  
            Loop
        End If
        dataredr.Close()
        ChkComAll.Checked = True
    End Sub
    Private Sub ShowList()
        Dim cmd As New OleDb.OleDbCommand
        Dim dataredr As OleDb.OleDbDataReader
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Me.Cursor = Cursors.WaitCursor

        Try
            cmd.Connection = Conn
            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & CustGrpcode & " order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "cust")
            cmbcust.DisplayMember = "AcName"
            cmbcust.ValueMember = "Accode"
            cmbcust.DataSource = DS.Tables("cust")
            cmbcust.SelectedValue = 0

            cmd.CommandText = "select cardno,name  from Carddetails order by name "
            DA.SelectCommand = cmd
            DA.Fill(DS, "CCard")
            cbccard.DisplayMember = "Name"
            cbccard.ValueMember = "cardno"
            cbccard.DataSource = DS.Tables("CCard")
            cbccard.SelectedValue = 0

            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & SupGrpcode & " order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Acmaster")
            cbSupwise.DisplayMember = "AcName"
            cbSupwise.ValueMember = "AcCode"
            cbSupwise.DataSource = DS.Tables("Acmaster")
            cbSupwise.SelectedValue = 0

            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & CustGrpcode & " order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "cust")
            cbcust.DisplayMember = "AcName"
            cbcust.ValueMember = "AcCode"
            cbcust.DataSource = DS.Tables("cust")
            cbcust.SelectedValue = 0

            CompanyList()

            ChkClsAll.Checked = False
            ChkGrp1All.Checked = False
            ChkGrp2All.Checked = False

            lstclass.Items.Clear()
            cmd.CommandText = "Select clsCode,clsName from Classification order by clsName"
            dataredr = cmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    lstclass.Items.Add(New MyList(dataredr.Item("ClsName"), dataredr.Item("Clscode")))
                Loop
            End If
            dataredr.Close()

            lstgrp1.Items.Clear()
            cmd.CommandText = "Select PrGrp1Code,PrGrp1Name from PrGroup1 order by PrGrp1name"
            dataredr = cmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    lstgrp1.Items.Add(New MyList(dataredr.Item("PrGrp1Name"), dataredr.Item("PrGrp1Code")))
                Loop
            End If
            dataredr.Close()

            lstgrp2.Items.Clear()
            cmd.CommandText = "Select PrGrp2Code,PrGrp2Name from PrGroup2 order by PrGrp2name"
            dataredr = cmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    lstgrp2.Items.Add(New MyList(dataredr.Item("PrGrp2Name"), dataredr.Item("PrGrp2Code")))
                Loop
            End If

            lstsupp.Items.Clear()
            dataredr.Close()
            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & SupGrpcode & " order by Acname"
            dataredr = cmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read()
                    lstsupp.Items.Add(New MyList(dataredr.Item("Acname"), dataredr.Item("Accode")), True)
                Loop
            End If

            chklstCust.Items.Clear()
            dataredr.Close()
            cmd.CommandText = "select Accode,Acname from Acmaster where grpcode=" & CustGrpcode & " order by Acname"
            dataredr = cmd.ExecuteReader()
            If dataredr.HasRows Then
                Do While dataredr.Read
                    chklstCust.Items.Add(New MyList(dataredr.Item("Acname"), dataredr.Item("Accode")), True)
                Loop
            End If
            dataredr.Close()
            ChkSuppAll.Checked = True
            ChkClsAll.Checked = True
            ChkGrp1All.Checked = True
            ChkGrp2All.Checked = True

            cmd.CommandText = "select code,name from racks  union all select 0 as code,'(No Rack)' as name order by name "
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

            cmd.CommandText = "select code,name from schedule order by name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "sched1")
            cbschpl.DisplayMember = "name"
            cbschpl.ValueMember = "code"
            cbschpl.DataSource = DS.Tables("sched1")
            cbschpl.SelectedValue = 0
            cbschpl.SelectedText = ""
            cbschpl.Text = ""
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CreateEditedBills() As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim dr As OleDb.OleDbDataReader
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetEditedBills"
        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)
        cmd.CommandType = CommandType.Text
        For i = 0 To dtab.Rows.Count - 1
            If Not dtab.Rows(i).Item("cancelled") Then
                cmd.CommandTimeout = 600
                cmd.CommandText = "select netamt,usrname,node,bdisamt,pdisamt from invtotal where type='" & _
                    Microsoft.VisualBasic.Right(dtab.Rows(i).Item("type"), 2) & "' and invno=" & dtab.Rows(i).Item("invno") & _
                    " and invdt=convert(datetime,'" & dtab.Rows(i).Item("invdt") & "')"
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    dtab.Rows(i).Item("newnetamt") = dr("netamt")
                    dtab.Rows(i).Item("newbdisamt") = dr("bdisamt")
                    dtab.Rows(i).Item("newpdisamt") = dr("pdisamt")
                    dtab.Rows(i).Item("newnode") = dr("node")
                    dtab.Rows(i).Item("newusrname") = dr("usrname")
                End If
                dr.Close()
            Else
                dtab.Rows(i).Item("newnode") = dtab.Rows(i).Item("nodeCancelled")
                dtab.Rows(i).Item("newusrname") = dtab.Rows(i).Item("UsrnameCancelled")
                dtab.Rows(i).Item("netamt") = dtab.Rows(i).Item("netamtCancelled")
            End If
        Next
        CreateEditedBills = dtab

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tbc.SelectedIndex = 0 Then Me.Close() : Exit Sub
        tbc.TabPages.Remove(tbc.SelectedTab)
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Try
            Dim HEAD As String
            Dim rtstr As String

            Select Case BtnView.Tag
                Case "ScheduleSale"

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Schedule " & cbsch.Text & " sales register for the period " & dtschf.Value.Date & " - " & dtscht.Value.Date
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    If Chk.Checked Then
                        rpt = New RptScheduleSale
                    Else
                        rpt = New RptScheduleSale1
                    End If

                    rpt.SetDataSource(CreateScheduleWise())

                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "ProdWiseWeekly"

                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Product wise weekly sales for the period  " & dtpComf.Value.Date & " - " & dtpComt.Value.Date

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptProductwiseWeekwise

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)

                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    txtcomnos.Text = 0
                    rpt.SetDataSource(CreateProductWiseDateWise(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date, (cbrptcom.SelectedIndex + 1), Val(txtcomnos.Text)))
                    txtcomnos.Text = 10
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("Opt", IIf(ChkComOpt.Checked, 1, 0))
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ProdWiseMonthly"
                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Product wise monthly sales for the period  " & dtpComf.Value.Date & " - " & dtpComt.Value.Date


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptProductwiseMonthwise

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)

                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    txtcomnos.Text = 0
                    rpt.SetDataSource(CreateProductWiseDateWise(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date, (cbrptcom.SelectedIndex + 1), Val(txtcomnos.Text)))
                    txtcomnos.Text = 10
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("Opt", IIf(ChkComOpt.Checked, 1, 0))
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "AgeWiseStock"
                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next



                    If Val(txtage1.Text) > Val(txtage2.Text) Then
                        MsgBox("Invalid Age parameter")
                        txtage2.Focus()
                        Exit Sub

                    End If


                    If Val(txtage2.Text) > Val(txtage3.Text) Then
                        MsgBox("Invalid Age parameter")
                        txtage2.Focus()
                        Exit Sub

                    End If

                    If Val(txtage1.Text) > Val(txtage3.Text) Then
                        MsgBox("Invalid Age parameter")
                        txtage1.Focus()
                        Exit Sub
                    End If

                    If Val(txtage1.Text) + Val(txtage2.Text) + Val(txtage3.Text) = 0 Then
                        MsgBox("Invalid Age parameter")
                        txtage1.Focus()
                        Exit Sub

                    End If

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If





                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If

                    HEAD = "Batchwise Stock Statement as on " & dtpComt.Value.Date & rtstr
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    If ChkComOpt.Checked Then
                        rpt = New RptBatchWiseStockAgewiseSmry

                    Else
                        rpt = New RptBatchWiseStockAgewise
                    End If


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateClsStk(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComt.Value.Date))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)
                    rpt.SetParameterValue("age1", Val(txtage1.Text))
                    rpt.SetParameterValue("age2", Val(txtage2.Text))
                    rpt.SetParameterValue("age3", Val(txtage3.Text))
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()

                    Me.Cursor = Cursors.Default
                Case "RackWise"

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Rack wise stock statement as on " & SysDt
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptRackWiseStock




                    rpt.SetDataSource(CreateRackWise())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    'v.ReportSource = rpt


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default


                Case "TimeSales"





                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Time wise sales for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As New RptTimewisesales


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "EditedBills"

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Edited/Cancelled Bills Report for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As Object

                    If ChkSum1.Checked Then
                        rpt = New EditedSalesSmry
                    Else
                        rpt = New EditedSales
                    End If
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateEditedBills())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ProdPurch"


                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If (cbrnge.SelectedIndex = 0 And txtprcnt.Text > "0") Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor

                    HEAD = "Product wise Purchase Statement as on " & dtpComf.Value.Date & " to " & dtpComt.Value.Date

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    If ChkComOpt.Checked Then
                        rpt = New RptProductwisePurchaseSmry
                    Else
                        rpt = New RptProductwisePurchase
                    End If



                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateProductwisepurchase(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "PrdProf"

                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Profitability Statement for the perion  " & dtpComf.Value.Date & " - " & dtpComt.Value.Date


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptProdProfitability

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)

                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)


                    rpt.SetDataSource(CreateProductProfitability(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date, (cbrptcom.SelectedIndex + 1), Val(txtcomnos.Text)))

                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("Opt", IIf(ChkComOpt.Checked, 1, 0))
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "AccPay"

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Accounts Payable as on  " & SysDt

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview

                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptInvPayable

                    rpt.SetDataSource(CreateInvAccPayable)
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "AccRecv"
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Accounts Receivable as on  " & SysDt

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptInvReceivable

                    rpt.SetDataSource(CreateInvAccReceivable)

                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ExessStkPrd"


                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Excess stock product list for the period  " & dtpComf.Value.Date & " - " & dtpComt.Value.Date & "  (" & cbrptcom.Text & ")"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As New RptExcessStockProduct
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateExcessStock(tmpcom, tmpcls, tmpgrp1, tmpgrp2))

                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "OrdLst"

                    Dim cmd As New OleDb.OleDbCommand

                    Dim rptsal(5) As String
                    Dim rpttax(5) As String


                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Order List for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As New RptOderList




                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    'v.ShowGroupTree()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ShowParameterPanelButton = False
                    v.Dock = DockStyle.Fill

                    v.DisplayStatusBar = True
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateOrderList())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ReportSource = rpt

                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "NonStkPrd"
                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Non Stock producta as on " & SysDt

                    tbc.TabPages(0).Hide()

                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptNonStockProd

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.ShowParameterPanelButton = False

                    v.DisplayStatusBar = True
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateNonStock(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "SlowPrdPurchase"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If




                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Slow moving product list - Purchased between " & txtfrom.Text & " to " & txtto.Text & " days"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptSlowMoving

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSlowmovingPurchase(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "SlowPrd"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If




                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Slow moving product list - not sold for last " & txtto.Text & " days"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptSlowMoving

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSlowmoving(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "PurRtnSettled"
                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim tmpsup As String
                    Dim i As Integer
                    Dim mlist As New MyList



                    Dim rpt As Object

                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            rpt = New RptPurchaseReturn
                            HEAD = "Purchase Return Settled for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                        Case 1
                            HEAD = "Purchase Return Settled Summary for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                            rpt = New RptPurchaseReturnSmry
                            'Case 2
                            '    HEAD = "Purchase Register Summary for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                            '    rpt = New PurchaseRegister_DaySmry
                            'Case 3
                            '    HEAD = "Purchase Register Summary for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                            '    rpt = New PurchaseRegister_MonthSmry
                    End Select


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    tmpsup = ";"
                    For i = 0 To lstsupp.Items.Count - 1
                        If lstsupp.GetItemChecked(i) = True Then
                            mlist = lstsupp.Items(i)
                            tmpsup = tmpsup & mlist.ItemData & ";"
                        End If
                    Next

                    If tmpsup = ";" Then
                        MsgBox("Select a Supplier..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Me.Cursor = Cursors.WaitCursor
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreatePurchaseRetrunSettled(tmpsup))
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default


                Case "PurRtnDet"



                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim tmpsup As String
                    Dim i As Integer
                    Dim mlist As New MyList



                    Dim rpt As Object

                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            rpt = New RptPurchaseReturn
                            HEAD = "Purchase Return Details for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                        Case 1
                            HEAD = "Purchase Return Summary for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                            rpt = New RptPurchaseReturnSmry
                            'Case 2
                            '    HEAD = "Purchase Register Summary for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                            '    rpt = New PurchaseRegister_DaySmry
                            'Case 3
                            '    HEAD = "Purchase Register Summary for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                            '    rpt = New PurchaseRegister_MonthSmry
                    End Select


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    tmpsup = ";"
                    For i = 0 To lstsupp.Items.Count - 1
                        If lstsupp.GetItemChecked(i) = True Then
                            mlist = lstsupp.Items(i)
                            tmpsup = tmpsup & mlist.ItemData & ";"
                        End If
                    Next

                    If tmpsup = ";" Then
                        MsgBox("Select a Supplier..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Me.Cursor = Cursors.WaitCursor
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreatePurchaseRetrun(tmpsup))
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "SalRtnDet"

                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    'Dim i As Integer

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Sales Return Details for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As New RptSalesReturn





                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSalesRetrun())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "PrdList"
                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Product List as on " & dtpComt.Value.Date

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptProductList


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateProductList(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()

                    Me.Cursor = Cursors.Default


                Case "ComSupLst", "SupComLst"
                    Me.Cursor = Cursors.WaitCursor
                    If BtnView.Tag = "SupComLst" Then

                        HEAD = "Supplier wise Company List " & SysDt
                    Else
                        HEAD = "Company wise Supplier List " & SysDt

                    End If

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    If BtnView.Tag = "SupComLst" Then

                        rpt = New RptSupComList
                    Else
                        rpt = New RptComSupList

                    End If

                    rpt.SetDataSource(CreateComSupList())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    'v.ReportSource = rpt


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt

                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "ComLst"

                    HEAD = "Company List " & SysDt

                    Me.Cursor = Cursors.WaitCursor
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptComList



                    rpt.SetDataSource(CreateComList())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)




                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "SupLst"

                    HEAD = "Supplier List " & SysDt

                    Me.Cursor = Cursors.WaitCursor
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptSupList

                    rpt.SetDataSource(CreateSupList())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)




                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "LockPrd"
                    HEAD = "Locked Products List as on " & SysDt
                    Me.Cursor = Cursors.WaitCursor

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptLockedProducts




                    rpt.SetDataSource(CreateLockedProducts())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    'v.ReportSource = rpt


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "PndDelNote"
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Pending Delivery Note as on " & SysDt


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    rpt = New RptPndDLNote




                    rpt.SetDataSource(CreateDLNote())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)

                    'v.ReportSource = rpt


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()

                    Me.Cursor = Cursors.Default
                Case "StkAdj"
                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If

                    HEAD = "Stock Adjustments for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date & "  ( on P Rate)"


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptStockAdj

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateStockAdj(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "CustwiseSales"
                    Select Case cbcustwiseser.SelectedIndex
                        Case 0
                            If txtser.Text = "" Then
                                MsgBox("Patient name is blank.")
                                Exit Sub
                            End If
                        Case 1
                            If txtser.Text = "" Then
                                MsgBox("Doctor name is blank.")
                                Exit Sub
                            End If
                        Case 2
                            If cmbcust.Text = "" Then
                                MsgBox("Customer name is blank.")
                                Exit Sub
                            End If
                        Case 3
                            If txtser.Text = "" Then
                                MsgBox("Card No.  is blank.")
                                Exit Sub
                            End If
                        Case 4
                            If txtser.Text = "" Then
                                MsgBox("Employe No.is blank.")
                                Exit Sub
                            End If
                        Case 5
                            If txtser.Text = "" Then
                                MsgBox("ESI No. is blank.")
                                Exit Sub
                            End If
                        Case 6
                            If txtser.Text = "" Then
                                MsgBox("Employe Name is blank.")
                                Exit Sub
                            End If
                    End Select
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Customer wise sales for the period " & dtpcustwisef.Value.Date & " - " & dtpcustwiset.Value.Date
                    Dim rpt As Object
                    If chkCustwiseSmry.SelectedIndex = 0 Then
                        rpt = New CustwiseSmry
                    ElseIf chkCustwiseSmry.SelectedIndex = 1 Then
                        rpt = New Custwise
                    ElseIf chkCustwiseSmry.SelectedIndex = 2 Then
                        rpt = New CustwiseSmall
                    End If
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    rpt.SetDataSource(CreateCustomerWiseSales())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "StkStmt"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If

                    HEAD = "Closing Stock Statement as on " & dtpComt.Value.Date & rtstr

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object


                    If ChkTax.Checked Then

                        If ChkComOpt.Checked Then
                            rpt = New RptClosingStockSmryVAT
                        Else
                            rpt = New RptClosingStockVAT
                        End If
                    Else

                        If ChkComOpt.Checked Then
                            rpt = New RptClosingStockSmry
                        Else
                            rpt = New RptClosingStock
                        End If
                    End If
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)


                    If cbrptcom.SelectedIndex = 7 Then
                        rpt = New RptClosingStockValueWise
                        rpt.SetDataSource(CreateClsStkValuewise(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComt.Value.Date))
                    Else
                        rpt.SetDataSource(CreateClsStk(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComt.Value.Date))
                    End If


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "StkSale"


                    Dim cmd As New OleDb.OleDbCommand
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If

                    HEAD = "Stock and Sale Statement for the period " & dtpComf.Value.Date & " to " & dtpComt.Value.Date & rtstr

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    If ChkComOpt.Checked Then
                        rpt = New RptStockAndSaleSmry
                    Else
                        rpt = New RptStockAndSale
                    End If



                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateStockAndSale(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComf.Value.Date, dtpComt.Value.Date))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ExpStk"
                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If


                    HEAD = "Expiry forecast as for the period " & dtpComf.Value.Date & " to " & dtpComt.Value.Date & " " & rtstr

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object
                    If cbrptcom.SelectedIndex = cbrptcom.Items.Count - 1 Then
                        rpt = New ExpiryForcastSmall
                    Else
                        If cbrptcom.SelectedIndex = 2 Then
                            rpt = New ExpiryForcastSupwise
                        Else
                            rpt = New ExpiryForcast
                        End If

                    End If


                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    rpt.SetDataSource(CreateExpStk(tmpcom, tmpcls, tmpgrp1, tmpgrp2))
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "BatchStk"
                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    If OptBrate.Checked Then
                        rtstr = " ( on P Rate)"
                    ElseIf OptSRate.Checked Then
                        rtstr = " ( on S Rate)"
                    Else
                        rtstr = " ( on Tr Rate)"
                    End If

                    HEAD = "Batchwise Stock Statement as on " & dtpComt.Value.Date & rtstr
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As Object

                    rpt = New RptBatchWiseStock

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateClsStk(tmpcom, tmpcls, tmpgrp1, tmpgrp2, dtpComt.Value.Date))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    If OptBrate.Checked Then
                        rpt.SetParameterValue("RtOpt", 2)
                    ElseIf OptSRate.Checked Then
                        rpt.SetParameterValue("RtOpt", 1)
                    Else
                        rpt.SetParameterValue("RtOpt", 3)
                    End If
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)

                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()

                    Me.Cursor = Cursors.Default

                Case "ProdWiseSalesDiscount"

                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Productwise sales for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date & "  (" & cbrptcom.Text & ")"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As New ProductwiseSalesDiscount
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateProdwiseSaleDiscount(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    'rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "ProdWiseSales"


                    If txtinvt.Text = "" Then txtinvt.Text = txtinvf.Text


                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company..", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2..", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Productwise sales for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date & "  (" & cbrptcom.Text & ")"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()
                    Dim rpt As New ProductwiseSales
                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateProdwiseSale(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "VATRpt"
                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Me.Cursor = Cursors.WaitCursor
                    'If chkCaRtn.Checked = False And ChkCash.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                    '    MsgBox("Select an option.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If



                    HEAD = "VAT Report for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As New VATRpt


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateVATRpt())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ShiftJou"
                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim i As Integer

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    cmd.Connection = Conn
                    cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' and taxper<>0  order by seq"
                    dr = cmd.ExecuteReader
                    i = 0
                    While dr.Read
                        rptsal(i) = "Sale" & Format(dr("taxper"), "#.##") & "%"
                        rpttax(i) = "VAT" & Format(dr("taxper"), "#.##") & "%"
                        i = i + 1
                    End While


                    HEAD = "Shiftwise Sales Journal for the period " & dtf.Value.Date & " - " & dtt.Value.Date & " ( " & IIf(ChkAllShift.Checked, "All Shift", "Shift " & cbshft.Text) & " )"

                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New ShiftSjournal
                        Case 1
                            rpt = New ShiftSjournalSmry

                    End Select
                    'rpt = New Sjournal


                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ(IIf(ChkAllShift.Checked, "", cbshft.Text)))
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)


                    For i = 1 To 5
                        rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                        rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                    Next
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "SJ"
                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim i As Integer

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    cmd.Connection = Conn
                    cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0' and taxper<>0  order by seq"
                    dr = cmd.ExecuteReader
                    i = 0
                    While dr.Read
                        rptsal(i) = "Sale" & Format(dr("taxper"), "#.##") & "%"
                        rpttax(i) = "VAT" & Format(dr("taxper"), "#.##") & "%"
                        i = i + 1
                    End While

                    HEAD = "Sales Journal for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New Sjournal
                        Case 1
                            rpt = New Sjournal_DaySmry
                        Case 2
                            rpt = New Sjournal_MonthSmry
                        Case 3
                            rpt = New SjournalPat
                    End Select
                    'rpt = New Sjournal

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)


                    For i = 1 To 5
                        rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                        rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                    Next
                    v.ReportSource = rpt

                    v.ShowNthPage(9000)

                    v.ShowNthPage(9000)
                    v.ShowNthPage(9000)
                    v.ShowNthPage(1)
                    v.Refresh()
                    tbc.ResumeLayout()
                    Me.ResumeLayout()

                    Me.Cursor = Cursors.Default

                Case "ShiftCash"

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Shift wise Sales List for the period " & dtf.Value.Date & " - " & dtt.Value.Date & "  ( " & IIf(ChkAllShift.Checked, "All Shift", "Shift " & cbshft.Text) & " )"
                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New ShiftSalesList
                        Case 1
                            rpt = New ShiftSalesListSmry

                    End Select

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ(IIf(ChkAllShift.Checked, "", cbshft.Text)))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "SalesList"

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If (cbrpt.SelectedItem = "Billno. From-To") And (bfrmtxt.Text = "") Then
                        MsgBox("Enter Bill no From - To", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Sales List for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New SalesList
                        Case 4
                            If ChkSum1.Checked Then
                                rpt = New SalesList_DaySmry
                            Else
                                rpt = New SalesList
                            End If
                        Case 1
                            rpt = New SalesList_DaySmry
                        Case 2
                            rpt = New SalesList_MonthSmry
                        Case 3
                            rpt = New SalesList_Cust
                    End Select

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "DaySaleGraph"
                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Sales List for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As New RptDayGraph

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSJ())

                    v.ReportSource = rpt
                    '' rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    ' rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
                    ' rpt.SetParameterValue("HEAD4", HEAD)

                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "SundryList"

                    Dim cmd As New OleDb.OleDbCommand
                    'Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    ' Dim i As Integer

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Sundry Sales list for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As New SundrySales





                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSundry())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)



                    v.ReportSource = rpt
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "PurReg"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList
                    Dim tmpsup As String


                    If ChkPurCa.Checked = False And ChkPurCr.Checked = False And ChkPurEst.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    tmpsup = ";"
                    For i = 0 To lstsupp.Items.Count - 1
                        If lstsupp.GetItemChecked(i) = True Then
                            mList = lstsupp.Items(i)
                            tmpsup = tmpsup & mList.ItemData & ";"
                        End If
                    Next

                    If tmpsup = ";" Then
                        MsgBox("Select a Supplier..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    cmd.Connection = Conn
                    cmd.CommandText = "select taxper,surch from tax where flag='1' OR flag='0'  and taxper<>0 order by seq"
                    dr = cmd.ExecuteReader
                    i = 0
                    While dr.Read
                        rptsal(i) = "Pur" & Format(dr("taxper"), "#.##") & "%"
                        rpttax(i) = "VAT" & Format(dr("taxper"), "#.##") & "%"
                        i = i + 1
                    End While

                    HEAD = "Purchase Register for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                    Dim rpt As Object '
                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            rpt = New PurchaseRegister
                        Case 1
                            HEAD = "Purchase Register Summary for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                            rpt = New PurchaseRegister_Smry
                        Case 2
                            HEAD = "Purchase Register Summary for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                            rpt = New PurchaseRegister_DaySmry
                        Case 3
                            HEAD = "Purchase Register Summary for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                            rpt = New PurchaseRegister_MonthSmry
                    End Select

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)



                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            rpt.SetDataSource(CreatePurReg(tmpsup))
                        Case 1
                            rpt.SetDataSource(CreatePurReg(tmpsup))
                        Case 2
                            rpt.SetDataSource(CreatePurReg(tmpsup))
                            'rpt.SetDataSource(CreatePurRegTaxSmry(tmpsup, rptsal(0), rptsal(1), rptsal(2), rptsal(3), rptsal(4)))
                        Case 3
                            rpt.SetDataSource(CreatePurReg(tmpsup))
                            'rpt.SetDataSource(CreatePurRegTaxSmry(tmpsup, rptsal(0), rptsal(1), rptsal(2), rptsal(3), rptsal(4)))
                    End Select



                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)


                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            For i = 1 To 5
                                rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                                rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                            Next
                        Case 1
                            For i = 1 To 5
                                rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                                rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                            Next
                        Case 2
                            For i = 1 To 5
                                rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                                rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                            Next
                        Case 3
                            For i = 1 To 5
                                rpt.SetParameterValue("AMT" & i, rptsal(i - 1) & "")
                                rpt.SetParameterValue("TAX" & i, rpttax(i - 1) & "")
                            Next
                    End Select


                    v.ReportSource = rpt
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "PurList"
                    Dim mList As MyList
                    Dim tmpsup As String
                    If ChkPurCa.Checked = False And ChkPurCr.Checked = False And ChkPurEst.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    tmpsup = ";"
                    For i = 0 To lstsupp.Items.Count - 1
                        If lstsupp.GetItemChecked(i) = True Then
                            mList = lstsupp.Items(i)
                            tmpsup = tmpsup & mList.ItemData & ";"
                        End If
                    Next

                    If tmpsup = ";" Then
                        MsgBox("Select a Supplier..", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    HEAD = "Purchase List for the period " & DtpSuppf.Value.Date & " - " & DtpSuppt.Value.Date
                    'Dim rpt As New PurchaseList

                    Dim rpt As Object '
                    Select Case CmbSuppRpt.SelectedIndex
                        Case 0
                            rpt = New PurchaseList
                        Case 1
                            rpt = New PurchaseList_Smry
                        Case 2
                            rpt = New PurchaseList_DaySmry
                        Case 3
                            rpt = New PurchaseList_MonthSmry
                        Case 4
                            rpt = New RptProductwisePurchase
                        Case 5
                            rpt = New PurchaseListSupwise
                    End Select

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreatePurReg(tmpsup))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "StkLdg"
                    HEAD = "Product: " & Txtname.Text & " " & txtpack.Text & ".  Stock Ledger for the period " & dtprodf.Value.Date & " - " & dtprodt.Value.Date & " "
                    Dim rpt As New StockLedger
                    Dim cmdsl As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim cls As Double
                    Me.Cursor = Cursors.WaitCursor
                    cmdsl.Connection = Conn
                    cmdsl.CommandType = CommandType.StoredProcedure
                    cmdsl.CommandText = "GetClosingStockBatchwise"
                    cmdsl.Parameters.Add("@supp", OleDb.OleDbType.VarChar).Value = 0
                    cmdsl.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = ""
                    cmdsl.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = ""
                    cmdsl.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = ""
                    cmdsl.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = ""
                    cmdsl.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = DateAdd(DateInterval.Day, -1, dtprodf.Value.Date)
                    cmdsl.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = Txtcode.Text
                    cmdsl.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = TxtBatch.Text

                    If OptEql.Checked Then
                        cmdsl.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "0"
                    ElseIf OptStart.Checked Then

                        cmdsl.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "1"
                    ElseIf OptInclu.Checked Then
                        cmdsl.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "2"
                    Else
                        cmdsl.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "3"
                    End If
                    cmdsl.Parameters.Add("@mrpfrm", OleDb.OleDbType.Double).Value = 0
                    cmdsl.Parameters.Add("@mrpto", OleDb.OleDbType.Double).Value = 0
                    cmdsl.Parameters.Add("@showzero", OleDb.OleDbType.Double).Value = 1
                    cmdsl.Parameters.Add("@showest", OleDb.OleDbType.Double).Value = 1


                    dr = cmdsl.ExecuteReader

                    While dr.Read

                        cls = cls + dr("CLS")
                    End While



                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateStockLedger())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("OPSTK", cls)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default

                Case "SmanWiseSales"

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And ChkCrCd.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Salesman wise sales for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New SalesManwise
                        Case 1
                            rpt = New SalesManwise_Smry
                        Case 2
                            rpt = New SalesManwise_MonthSmry
                        Case 3
                            rpt = New SalesManwise_YearSmry
                    End Select

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateSalesManSales())


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "DocWiseSales"

                    If chkCaRtn.Checked = False And ChkCash.Checked = False And chkCr.Checked = False And ChkCrRtn.Checked = False And ChkEst.Checked = False And ChkSun.Checked = False And ChkCrCd.Checked = False Then
                        MsgBox("Select an option.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Doctor wise sales for the period " & dtf.Value.Date & " - " & dtt.Value.Date
                    Dim rpt As Object '
                    Select Case cbrpt.SelectedIndex
                        Case 0
                            rpt = New SalesManwise
                        Case 1
                            rpt = New SalesManwise_Smry
                        Case 2
                            rpt = New SalesManwise_MonthSmry
                        Case 3
                            rpt = New SalesManwise_YearSmry
                    End Select
                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)
                    rpt.SetDataSource(CreateDoctorSales())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "ProdEdit"

                    Dim cmd As New OleDb.OleDbCommand
                    ' Dim dr As OleDb.OleDbDataReader
                    Dim rptsal(5) As String
                    Dim rpttax(5) As String
                    'Dim i As Integer

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Product Edited list for the period " & dtf.Value.Date & " - " & dtt.Value.Date

                    Dim rpt As New ProductEdited

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateProdEdited())
                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Addr1) & " " & DeScriptRS(Firm.Addr2) & "  " & DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD3", HEAD)



                    v.ReportSource = rpt
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "TransOut"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Productwise Transfer-Out for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date & "  (" & cbrptcom.Text & ")"

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    Dim rpt As New ProductwiseTransOut

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateProdwiseTransOut(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)
                    'If DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date) = 0 Then
                    '    rpt.SetParameterValue("days", 1)
                    'Else
                    '    rpt.SetParameterValue("days", DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date))
                    'End If


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "DateWise"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Datewise Customer Wise Transfer-Out for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    Dim rpt As New RptDateWiseCustWise

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateCustWiseDateWiseTransOut(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    'rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)
                    'If DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date) = 0 Then
                    '    rpt.SetParameterValue("days", 1)
                    'Else
                    '    rpt.SetParameterValue("days", DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date))
                    'End If


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "Customer Wise"

                    Dim cmd As New OleDb.OleDbCommand
                    Dim dr As OleDb.OleDbDataReader
                    Dim tmpcom, tmpcls, tmpgrp1, tmpgrp2 As String
                    Dim rpttax(5) As String
                    Dim i As Integer
                    Dim mList As MyList

                    tmpcom = ";"
                    For i = 0 To lstcom.Items.Count - 1
                        If lstcom.GetItemChecked(i) = True Then
                            mList = lstcom.Items(i)
                            tmpcom = tmpcom & mList.ItemData & ";"
                        End If
                    Next

                    tmpcls = ";"
                    For i = 0 To lstclass.Items.Count - 1
                        If lstclass.GetItemChecked(i) = True Then
                            mList = lstclass.Items(i)
                            tmpcls = tmpcls & mList.ItemData & ";"
                        End If
                    Next

                    tmpgrp1 = ";"
                    For i = 0 To lstgrp1.Items.Count - 1
                        If lstgrp1.GetItemChecked(i) = True Then
                            mList = lstgrp1.Items(i)
                            tmpgrp1 = tmpgrp1 & mList.ItemData & ";"
                        End If
                    Next


                    tmpgrp2 = ";"
                    For i = 0 To lstgrp2.Items.Count - 1
                        If lstgrp2.GetItemChecked(i) = True Then
                            mList = lstgrp2.Items(i)
                            tmpgrp2 = tmpgrp2 & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcom = ";" Then
                        MsgBox("Select a company...", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                    If tmpcls = ";" Then
                        MsgBox("Select a classification...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    If tmpgrp1 = ";" Then
                        MsgBox("Select a Group 1...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If tmpgrp2 = ";" Then
                        MsgBox("Select a Group 2...", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Customer wise DateWise Transfer-Out for the period " & dtpComf.Value.Date & " - " & dtpComt.Value.Date

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD

                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    Dim rpt As New RptCustWiseDateWise

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)



                    rpt.SetDataSource(CreateCustWiseDateWiseTransOut(tmpcom, tmpcls, tmpgrp1, tmpgrp2))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
                    'rpt.SetParameterValue("HEAD3", "")
                    rpt.SetParameterValue("HEAD4", HEAD)
                    'rpt.SetParameterValue("grp", (cbrptcom.SelectedIndex + 1).ToString)
                    'If DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date) = 0 Then
                    '    rpt.SetParameterValue("days", 1)
                    'Else
                    '    rpt.SetParameterValue("days", DateDiff(DateInterval.Day, dtpComf.Value.Date, dtpComt.Value.Date))
                    'End If


                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
                Case "CustWiseBillWise"
                    Dim tmpcust As String
                    Dim mList As MyList

                    tmpcust = ";"
                    For i = 0 To chklstCust.Items.Count - 1
                        If chklstCust.GetItemChecked(i) = True Then
                            mList = chklstCust.Items(i)
                            tmpcust = tmpcust & mList.ItemData & ";"
                        End If
                    Next

                    If tmpcust = ";" Then
                        MsgBox("Select a Customer...", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    HEAD = "Customer wise Bill Wise sales for the period " & dtpcustwisef.Value.Date & " - " & dtpcustwiset.Value.Date

                    Dim rpt As New RptCustWiseBillWise

                    tbc.TabPages(0).Hide()
                    rptcnt = rptcnt + 1
                    tbc.TabPages.Add("Report " & rptcnt & "   ")
                    tbc.TabPages(tbc.TabPages.Count - 1).ToolTipText = HEAD


                    Dim v As New Myview
                    Me.SuspendLayout()
                    tbc.SuspendLayout()

                    v.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    v.Parent = tbc.TabPages(tbc.TabPages.Count - 1)
                    v.Dock = DockStyle.Fill
                    v.DisplayStatusBar = True
                    v.ShowParameterPanelButton = False
                    tbc.TabPages(tbc.TabPages.Count - 1).Controls.Add(v)
                    tbc.SelectedTab = tbc.TabPages(tbc.TabPages.Count - 1)

                    rpt.SetDataSource(CreateCustomerWiseBillWiseSales(tmpcust))


                    rpt.SetParameterValue("HEAD1", DeScriptRS(Firm.Name))
                    rpt.SetParameterValue("HEAD2", DeScriptRS(Firm.Place))
                    rpt.SetParameterValue("HEAD4", HEAD)
                    v.ReportSource = rpt
                    tbc.ResumeLayout()
                    Me.ResumeLayout()
                    Me.Cursor = Cursors.Default
            End Select
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub

    Private Function CreateCustomerWiseBillWiseSales(ByVal tmpcust As String) As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        cmd.Connection = Conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Select_CustWiseBillWiseSale"
        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpcustwisef.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpcustwiset.Value.Date
        cmd.Parameters.Add("@Cust", OleDb.OleDbType.VarChar).Value = tmpcust
        'cmd.Parameters.Add("@CbCust", OleDb.OleDbType.VarChar).Value = cbcustwiseser.SelectedIndex
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateCustomerWiseBillWiseSales = dtab
    End Function

    Private Function CreateCustWiseDateWiseTransOut(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = cmdtimeout
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Select_DatewiseCustWiseSale"


        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@short", OleDb.OleDbType.VarChar).Value = IIf(ChkComOpt.Checked, 1, 0)
        cmd.Parameters.Add("@es", OleDb.OleDbType.VarChar).Value = 1
        cmd.Parameters.Add("@unac", OleDb.OleDbType.Boolean).Value = IIf(UsrName = "OPEN", 1, 0)
        cmd.Parameters.Add("@cust", OleDb.OleDbType.BigInt).Value = IIf(chkCust.Checked, Val(cbcust.SelectedValue & ""), 0)
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateCustWiseDateWiseTransOut = dtab.Tables(0)

    End Function

    Private Function CreateProdwiseTransOut(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = cmdtimeout
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Select_ProductwiseTransOut"

        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@short", OleDb.OleDbType.VarChar).Value = IIf(ChkComOpt.Checked, 1, 0)
        cmd.Parameters.Add("@es", OleDb.OleDbType.VarChar).Value = 1
        cmd.Parameters.Add("@unac", OleDb.OleDbType.Boolean).Value = IIf(UsrName = "OPEN", 1, 0)
        cmd.Parameters.Add("@cust", OleDb.OleDbType.BigInt).Value = IIf(chkCust.Checked, Val(cbcust.SelectedValue & ""), 0)
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProdwiseTransOut = dtab.Tables(0)

    End Function

    Private Function CreateSJ(Optional ByVal shift As String = "") As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        Dim bfrm As String
        bfrm = ""

        If bfrmtxt.Text <> "" And btotxt.Text = "" Then
            bfrm = bfrmtxt.Text.ToString
            btotxt.Text = bfrm
        End If
        cmd.Connection = Conn

        sql = ""

        If ChkCash.Checked Then

            If cbrpt.SelectedIndex = 4 And (Val(bfrmtxt.Text) <> 0 Or Val(btotxt.Text) <> 0) Then

                sql = "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                    "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                    " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                    " FROM   Invtotal where  Type='21' and Invtotal.InvNo>=" & Val(bfrmtxt.Text) & " and Invtotal.InvNo<=" & Val(btotxt.Text) & " and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                    "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' = '' or workshift=" & Val(shift) & ")    "
            Else

                sql = "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                    "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                    " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                    " FROM   Invtotal where  Type='21' and  Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                    "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' = '' or workshift=" & Val(shift) & ")    "
            End If


        End If

        If chkCr.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                " FROM   Invtotal where  Type='22'   and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and  ('" & shift & "' ='' or workshift=" & Val(shift) & ")    "


        End If


        If ChkCrCd.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                " FROM   Invtotal where  Type='27' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' ='' or workshift=" & Val(shift) & ")    "


        End If

        If ChkSun.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                " FROM   Invtotal where  Type='26' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' ='' or workshift=" & Val(shift) & ")    "

        End If



        If ChkEst.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end) AS tfamt, (case when Cancelled=1 then 0 else  Amt1 end ) AS amt1, (case when Cancelled=1 then 0 else  Tax1 end) AS tax1, (case when Cancelled=1 then 0 else  Amt2 end ) AS amt2,  (case when Cancelled=1 then 0 else  Tax2 end ) " & _
                "AS tax2,  (case when Cancelled=1 then 0 else  Amt3 end ) AS amt3,  (case when Cancelled=1 then 0 else  Tax3 end ) AS tax3,  (case when Cancelled=1 then 0 else  Amt4 end ) AS amt4,  (case when Cancelled=1 then 0 else  Tax4 end ) AS tax4, (case when Cancelled=1 then 0 else  Amt5 end ) AS amt5,  (case when Cancelled=1 then 0 else  Tax5 end ) AS tax5,  (case when Cancelled=1 then 0 else  NetAmt end ) AS netamt,(case when Cancelled=1 then 0 else  unacamt end ) AS unacamt, " & _
                " (AddAmt) AS addamt, (DedAmt) AS dedamt, DocName, Cancelled,1 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                " FROM   Invtotal where  Type='25' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' ='' or workshift=" & Val(shift) & ")    "

        End If



        If ChkCrRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt*-1) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end *-1) AS tfamt, (case when Cancelled=1 then 0 else Amt1 end *-1) AS amt1, (case when Cancelled=1 then 0 else Tax1 end *-1) AS tax1, (case when Cancelled=1 then 0 else Amt2 end *-1) AS amt2,  (case when Cancelled=1 then 0 else Tax2  end *-1) " & _
            " AS tax2,  (case when Cancelled=1 then 0 else Amt3 end *-1) AS amt3,  (case when Cancelled=1 then 0 else Tax3 end *-1) AS tax3,  (case when Cancelled=1 then 0 else Amt4 end *-1) AS amt4,  (case when Cancelled=1 then 0 else Tax4 end *-1) AS tax4, (case when Cancelled=1 then 0 else Amt5 end *-1) AS amt5,  (case when Cancelled=1 then 0 else Tax5 end *-1) AS tax5,  (case when Cancelled=1 then 0 else NetAmt end *-1) AS netamt,(case when Cancelled=1 then 0 else  unacamt*-1 end ) AS unacamt, " & _
            " (AddAmt*-1) AS addamt, (DedAmt*-1) AS dedamt, DocName, Cancelled,5 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
            " FROM   Invtotal where  Type='32' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and ('" & shift & "' ='' or workshift=" & Val(shift) & ") "
        End If

        If chkCaRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt*-1) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end *-1) AS tfamt, (case when Cancelled=1 then 0 else Amt1 end *-1) AS amt1, (case when Cancelled=1 then 0 else Tax1 end *-1) AS tax1, (case when Cancelled=1 then 0 else Amt2 end *-1) AS amt2,  (case when Cancelled=1 then 0 else Tax2  end *-1) " & _
                " AS tax2,  (case when Cancelled=1 then 0 else Amt3 end *-1) AS amt3,  (case when Cancelled=1 then 0 else Tax3 end *-1) AS tax3,  (case when Cancelled=1 then 0 else Amt4 end *-1) AS amt4,  (case when Cancelled=1 then 0 else Tax4 end *-1) AS tax4, (case when Cancelled=1 then 0 else Amt5 end *-1) AS amt5,  (case when Cancelled=1 then 0 else Tax5 end *-1) AS tax5,  (case when Cancelled=1 then 0 else NetAmt end *-1) AS netamt,(case when Cancelled=1 then 0 else  unacamt*-1 end ) AS unacamt, " & _
                " (AddAmt*-1) AS addamt, (DedAmt*-1) AS dedamt, DocName, Cancelled,5 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
                " FROM   Invtotal where  Type='31' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
                "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and  ('" & shift & "' ='' or workshift=" & Val(shift) & ") "
        End If


        If ChkCrCd.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt, CusCode, Name, BDis, (BDisAmt*-1) AS bdisamt, (case when Cancelled=1 then 0 else TFAmt end *-1) AS tfamt, (case when Cancelled=1 then 0 else Amt1 end *-1) AS amt1, (case when Cancelled=1 then 0 else Tax1 end *-1) AS tax1, (case when Cancelled=1 then 0 else Amt2 end *-1) AS amt2,  (case when Cancelled=1 then 0 else Tax2  end *-1) " & _
            " AS tax2,  (case when Cancelled=1 then 0 else Amt3 end *-1) AS amt3,  (case when Cancelled=1 then 0 else Tax3 end *-1) AS tax3,  (case when Cancelled=1 then 0 else Amt4 end *-1) AS amt4,  (case when Cancelled=1 then 0 else Tax4 end *-1) AS tax4, (case when Cancelled=1 then 0 else Amt5 end *-1) AS amt5,  (case when Cancelled=1 then 0 else Tax5 end *-1) AS tax5,  (case when Cancelled=1 then 0 else NetAmt end *-1) AS netamt,(case when Cancelled=1 then 0 else  unacamt *-1 end ) AS unacamt, " & _
            " (AddAmt*-1) AS addamt, (DedAmt*-1) AS dedamt, DocName, Cancelled,5 as seq,workshift,name, ESINO, empno, CardNo,CASE WHEN datepart(hour, InvTime )>12 THEN datepart(hour, InvTime )-12 ELSE datepart(hour, InvTime  ) END  as hour,InvTime     " & _
            " FROM   Invtotal where  Type='37' and Invtotal.InvDt>='" & Format(dtf.Value.Date, "yyyyMMdd") & _
            "' AND Invtotal.InvDt <='" & Format(dtt.Value.Date, "yyyyMMdd") & "' and  ('" & shift & "' ='' or workshift=" & Val(shift) & ") "


        End If

        sql = sql & " order by  invdt,seq,TYPE,invno  "
        cmd.CommandText = sql
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateSJ = dtab

    End Function

    Private Function CreateSalesManSales() As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        If ChkCash.Checked Then
            sql = "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where Invtotal.type = '21' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0 "
        End If

        If chkCr.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type = '22' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0  "
        End If


        If ChkCrCd.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type = '27' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0  "
        End If

        If ChkSun.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type = '26' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0 "
        End If

        If ChkEst.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type='25' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')  and Invtotal.cancelled=0 "

        End If

        If ChkCrRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name,  (NetAmt*-1) AS netamt " & _
                " FROM   Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type='32' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')   and Invtotal.cancelled=0  "
        End If

        If chkCaRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,Salesman.salname as name, (NetAmt*-1) AS netamt " & _
                " FROM   Invtotal INNER JOIN " & _
                " Salesman ON Invtotal.SMan = Salesman.SalCode where  Type='31' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')  and  Invtotal.cancelled=0 "
        End If
        sql = sql & " order by invdt,invno,type"
        cmd.CommandText = sql
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateSalesManSales = dtab

    End Function

    Private Function CreateDoctorSales() As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        If ChkCash.Checked Then
            sql = "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal   where Invtotal.type = '21' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0 "
        End If

        If chkCr.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal   where  Type = '22' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0  "
        End If


        If ChkCrCd.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal   where  Type = '27' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0  "
        End If

        If ChkSun.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal where  Type = '26' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "') and Invtotal.cancelled=0 "
        End If

        If ChkEst.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt) AS netamt " & _
                " FROM    Invtotal   where  Type='25' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')  and Invtotal.cancelled=0 "

        End If

        If ChkCrRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name,  (NetAmt*-1) AS netamt " & _
                " FROM   Invtotal  where  Type='32' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')   and Invtotal.cancelled=0  "
        End If

        If chkCaRtn.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name, (NetAmt*-1) AS netamt " & _
                " FROM   Invtotal  where  Type='31' and Invtotal.InvDt>=convert(datetime,'" & _
                dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')   and Invtotal.cancelled=0 "
        End If
        If ChkCrCd.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT InvNo, Type, InvDt,docname as name, (NetAmt*-1) AS netamt " & _
                " FROM   Invtotal  where  Type='37' and Invtotal.InvDt>=convert(datetime,'" & _
                 dtf.Value.Date & "') AND Invtotal.InvDt <=convert(datetime,'" & dtt.Value.Date & "')   and Invtotal.cancelled=0 "

        End If


        sql = sql & " order by invdt,invno,type"
        cmd.CommandText = sql
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateDoctorSales = dtab

    End Function




    Private Function CreatePurReg(ByVal tmpsup As String) As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn

        sql = ""
        If ChkPurCa.Checked Then
            sql = "SELECT rctno, Type,acmaster.acname,acmaster.place , (pTFAmt) AS tfamt, (pAmt1) AS amt1, (pTx1) AS tax1, (pAmt2) AS amt2,  (ptx2) " & _
                "AS tax2,  (pAmt3) AS amt3,  (pTx3) AS tax3,  (pAmt4) AS amt4,  (pTx4) AS tax4, (pAmt5) AS amt5,  (pTx5) AS tax5,  (rctamt) AS netamt, " & _
                " (padj) AS padj,1 as seq,pdate,billno,billdt,acmaster.ST " & _
                " FROM  purchase,acmaster where  purchase.supcode=acmaster.accode and purchase.Type='11' and purchase.pdate>=convert(datetime,'" & DtpSuppf.Value.Date & _
                "') AND purchase.pdate <=convert(datetime,'" & DtpSuppt.Value.Date & "') and " & _
                "CHARINDEX(';'+ convert(varchar,purchase.supcode) + ';','" & tmpsup & "') <>0"
        End If

        If ChkPurCr.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT rctno, Type,acmaster.acname,acmaster.place , (pTFAmt) AS tfamt, (pAmt1) AS amt1, (pTx1) AS tax1, (pAmt2) AS amt2,  (ptx2) " & _
               "AS tax2,  (pAmt3) AS amt3,  (pTx3) AS tax3,  (pAmt4) AS amt4,  (pTx4) AS tax4, (pAmt5) AS amt5,  (pTx5) AS tax5,  (rctamt) AS netamt, " & _
               " (padj) AS padj,2 as seq,pdate,billno,billdt,acmaster.ST " & _
               " FROM  purchase,acmaster where  purchase.supcode=acmaster.accode and purchase.Type='12' and purchase.pdate>=convert(datetime,'" & DtpSuppf.Value.Date & _
               "') AND purchase.pdate <=convert(datetime,'" & DtpSuppt.Value.Date & "') and " & _
                "CHARINDEX(';'+ convert(varchar,purchase.supcode) + ';','" & tmpsup & "') <>0"

        End If

        If ChkPurEst.Checked Then
            If sql <> "" Then sql = sql & " union all "
            sql = sql & "SELECT rctno, Type,acmaster.acname,acmaster.place , (pTFAmt) AS tfamt, (pAmt1) AS amt1, (pTx1) AS tax1, (pAmt2) AS amt2,  (ptx2) " & _
                   "AS tax2,  (pAmt3) AS amt3,  (pTx3) AS tax3,  (pAmt4) AS amt4,  (pTx4) AS tax4, (pAmt5) AS amt5,  (pTx5) AS tax5,  (rctamt) AS netamt, " & _
                   " (padj) AS padj,3 as seq,pdate,billno,billdt,acmaster.ST " & _
                   " FROM  purchase,acmaster where  purchase.supcode=acmaster.accode and Type='15' and purchase.pdate>=convert(datetime,'" & DtpSuppf.Value.Date & _
                   "') AND purchase.pdate <=convert(datetime,'" & DtpSuppt.Value.Date & "') and " & _
                "CHARINDEX(';'+ convert(varchar,purchase.supcode) + ';','" & tmpsup & "') <>0"

        End If


        If CmbSuppRpt.SelectedIndex = 4 Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600
            cmd.CommandText = "GetSupplierwiseProductwisePurchase"
            cmd.Parameters.Add("@supp", OleDb.OleDbType.VarChar).Value = tmpsup
            cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = DtpSuppf.Value
            cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = DtpSuppt.Value
            cmd.Parameters.Add("@ca", OleDb.OleDbType.Boolean).Value = IIf(ChkPurCa.Checked, 1, 0)
            cmd.Parameters.Add("@cr", OleDb.OleDbType.Boolean).Value = IIf(ChkPurCr.Checked, 1, 0)
            cmd.Parameters.Add("@es", OleDb.OleDbType.Boolean).Value = IIf(ChkPurEst.Checked, 1, 0)
        Else
            sql = sql & " order by pdate,Type,rctno"
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql

        End If
        da.SelectCommand = cmd
        da.Fill(dtab)


        CreatePurReg = dtab

    End Function



    Private Function CreatePurRegTaxSmry(ByVal tmpsup As String, ByVal str1 As String, ByVal str2 As String, ByVal str3 As String, ByVal str4 As String, ByVal str5 As String) As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn




        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Get_Purchase_RegisterSmry"


        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = DtpSuppt.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = DtpSuppf.Value.Date()
        cmd.Parameters.Add("@ca", OleDb.OleDbType.Integer).Value = IIf(ChkPurCa.Checked, 1, 0)
        cmd.Parameters.Add("@cr", OleDb.OleDbType.Integer).Value = IIf(ChkPurCr.Checked, 1, 0)
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = IIf(ChkPurEst.Checked, 1, 0)
        cmd.Parameters.Add("@cri", OleDb.OleDbType.VarChar).Value = tmpsup
        cmd.Parameters.Add("@amt1", OleDb.OleDbType.VarChar).Value = str1
        cmd.Parameters.Add("@amt2", OleDb.OleDbType.VarChar).Value = str2
        cmd.Parameters.Add("@amt3", OleDb.OleDbType.VarChar).Value = str3 & ""
        cmd.Parameters.Add("@amt4", OleDb.OleDbType.VarChar).Value = str4 & ""
        cmd.Parameters.Add("@amt5", OleDb.OleDbType.VarChar).Value = str5 & ""

        da.SelectCommand = cmd

        da.Fill(dtab)

        CreatePurRegTaxSmry = dtab

    End Function



    Private Function CreateSundry() As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn

        sql = ""


        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Get_SundrySales"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = dtf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = dtt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateSundry = dtab

    End Function


    Private Function CreateSalesRetrun() As DataTable

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn

        sql = ""


        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetSalesReturn"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = dtf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = dtt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateSalesRetrun = dtab

    End Function


    Private Function CreatePurchaseRetrun(ByVal cri As String) As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetPurchaseReturn"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = DtpSuppf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = DtpSuppt.Value.Date
        cmd.Parameters.Add("@flg", OleDb.OleDbType.Integer).Value = IIf(ChkSmryPurchase.Checked, 1, 0)
        cmd.Parameters.Add("@cri", OleDb.OleDbType.VarChar).Value = cri
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreatePurchaseRetrun = dtab
    End Function
    Private Function CreatePurchaseRetrunSettled(ByVal cri As String) As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetPurchaseReturnSettled"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = DtpSuppf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = DtpSuppt.Value.Date
        cmd.Parameters.Add("@flg", OleDb.OleDbType.Integer).Value = IIf(ChkSmryPurchase.Checked, 1, 0)
        cmd.Parameters.Add("@cri", OleDb.OleDbType.VarChar).Value = cri
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreatePurchaseRetrunSettled = dtab
    End Function

    Private Function CreateOrderList() As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetOrderList"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = dtf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = dtt.Value.Date

        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateOrderList = dtab
    End Function


    'Private Function CreateBatchwiseStock(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
    '    Dim dtab As New DataSet
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim da As New OleDb.OleDbDataAdapter
    '    Dim sql As String
    '    cmd.Connection = Conn
    '    sql = ""

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "Select_BatchwiseStock"

    '    cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
    '    cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
    '    cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
    '    cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
    '    cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
    '    cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2


    '    da.SelectCommand = cmd
    '    da.Fill(dtab)
    '    'MsgBox(dtab.Tables(0).Rows.Count)
    '    CreateBatchwiseStock = dtab.Tables(0)

    'End Function


    Private Function CreateStockLedger() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "GetProdTrans"
        cmd.CommandTimeout = 60000
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtprodf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtprodt.Value.Date
        cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = Txtcode.Text
        cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = TxtBatch.Text
        If OptEql.Checked Then
            cmd.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "0"
        ElseIf OptStart.Checked Then

            cmd.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "1"
        ElseIf OptInclu.Checked Then
            cmd.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "2"
        Else
            cmd.Parameters.Add("'@batchflg", OleDb.OleDbType.VarChar).Value = "3"
        End If
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateStockLedger = dtab.Tables(0)
    End Function



    Private Function CreateSlowmoving(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetSlowmoving"

        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate).Value = DateAdd(DateInterval.Day, Val(-1 * Val(txtto.Text)), SysDt)
        cmd.Parameters.Add("@exp", OleDb.OleDbType.Boolean).Value = IIf(ChkComOpt.Checked, 1, 0)
        cmd.Parameters.Add("@dtexp", OleDb.OleDbType.DBDate).Value = DateAdd(DateInterval.Day, ShortExpDays * -1, SysDt)



        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateSlowmoving = dtab.Tables(0)


    End Function


    Private Function CreateSlowmovingPurchase(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetSlowmovingPurchase"

        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@day1", OleDb.OleDbType.BigInt).Value = Val(txtfrom.Text)
        cmd.Parameters.Add("@day2", OleDb.OleDbType.BigInt).Value = Val(txtto.Text)
        cmd.Parameters.Add("@dt", OleDb.OleDbType.DBDate).Value = SysDt
        cmd.Parameters.Add("@exp", OleDb.OleDbType.Boolean).Value = IIf(ChkComOpt.Checked, 1, 0)
        cmd.Parameters.Add("@dtexp", OleDb.OleDbType.DBDate).Value = DateAdd(DateInterval.Day, ShortExpDays * -1, SysDt)
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateSlowmovingPurchase = dtab.Tables(0)


    End Function


    Private Function CreateExpStk(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetExpBatchwise"

        cmd.Parameters.Add("@Supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batchflg", OleDb.OleDbType.VarChar).Value = ""



        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateExpStk = dtab.Tables(0)


    End Function

    Private Function CreateNonStock(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetNonstock"

        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2




        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateNonStock = dtab.Tables(0)


    End Function


    Private Function CreateProductList(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetProductList"
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@sch", OleDb.OleDbType.VarChar).Value = cbschpl.Text
        cmd.Parameters.Add("@tax", OleDb.OleDbType.Numeric).Value = -1
        cmd.Parameters.Add("@rack", OleDb.OleDbType.VarChar).Value = ""

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProductList = dtab.Tables(0)


    End Function

    Private Function CreateProductProfitability(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal sdt As Date, ByVal edt As Date, ByVal grp As Integer, ByVal top As Long) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.CommandTimeout = cmdtimeout
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetProductProfitability"
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = sdt
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = edt
        cmd.Parameters.Add("@grp", OleDb.OleDbType.Integer).Value = grp
        cmd.Parameters.Add("@top", OleDb.OleDbType.Integer).Value = top
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProductProfitability = dtab.Tables(0)

    End Function

    Private Function CreateClsStkValuewise(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dt As Date) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.CommandTimeout = cmdtimeout
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetClosingStockBatchwiseValueWise"
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dt
        cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batchflg", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@mrpfrm", OleDb.OleDbType.Double).Value = Val(TxtMrpfrm.Text)
        cmd.Parameters.Add("@mrpto", OleDb.OleDbType.Double).Value = Val(Txtmrpto.Text)
        cmd.Parameters.Add("@showzero", OleDb.OleDbType.Boolean).Value = IIf(ChkNonStk.Checked, 0, 1)
        cmd.Parameters.Add("@showest", OleDb.OleDbType.Boolean).Value = IIf(chkeststk.Checked, 1, 0)

        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateClsStkValuewise = dtab.Tables(0)

    End Function

    Private Function CreateClsStk(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dt As Date) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.CommandTimeout = cmdtimeout
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetClosingStockBatchwise"
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dt
        cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batchflg", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@mrpfrm", OleDb.OleDbType.Double).Value = Val(TxtMrpfrm.Text)
        cmd.Parameters.Add("@mrpto", OleDb.OleDbType.Double).Value = Val(Txtmrpto.Text)
        cmd.Parameters.Add("@showzero", OleDb.OleDbType.Boolean).Value = IIf(ChkNonStk.Checked, 0, 1)
        cmd.Parameters.Add("@showest", OleDb.OleDbType.Boolean).Value = IIf(chkeststk.Checked, 1, 0)
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateClsStk = dtab.Tables(0)

    End Function


    Private Function CreateStockAndSale(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dtf As Date, ByVal dtt As Date) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.CommandTimeout = cmdtimeout
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetStockAndSaleBatchwise"
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt
        cmd.Parameters.Add("@pcode", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batch", OleDb.OleDbType.VarChar).Value = ""
        cmd.Parameters.Add("@batchflg", OleDb.OleDbType.VarChar).Value = ""
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateStockAndSale = dtab.Tables(0)

    End Function
    Private Function CreateProductwisepurchase(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dtf As Date, ByVal dtt As Date) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        If (cbrnge.SelectedIndex = 1) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600
            cmd.CommandText = "GetProductwisePurchase"
            cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
            cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
            cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
            cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
            cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
            cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
            cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt
            cmd.Parameters.Add("@flag", OleDb.OleDbType.BigInt).Value = 2
            cmd.Parameters.Add("@percnt", OleDb.OleDbType.Numeric).Value = Val(txtprcnt.Text)

            da.SelectCommand = cmd
            da.Fill(dtab)

            ' CreateProductwisepurchase = dtab.Tables(0)
        ElseIf (cbrnge.SelectedIndex = 2) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600
            cmd.CommandText = "GetProductwisePurchase"
            cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
            cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
            cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
            cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
            cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
            cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
            cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt
            cmd.Parameters.Add("@flag", OleDb.OleDbType.BigInt).Value = 3
            cmd.Parameters.Add("@percnt", OleDb.OleDbType.Numeric).Value = Val(txtprcnt.Text)

            da.SelectCommand = cmd
            da.Fill(dtab)

            'CreateProductwisepurchase = dtab.Tables(0)
        ElseIf (cbrnge.SelectedIndex = 0 And (txtprcnt.Text = "" Or txtprcnt.Text = "0")) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600
            cmd.CommandText = "GetProductwisePurchase"
            cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
            cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
            cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
            cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
            cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
            cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
            cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt
            cmd.Parameters.Add("@flag", OleDb.OleDbType.BigInt).Value = 1
            cmd.Parameters.Add("@percnt", OleDb.OleDbType.Numeric).Value = Val(txtprcnt.Text)

            da.SelectCommand = cmd
            da.Fill(dtab)

            'CreateProductwisepurchase = dtab.Tables(0)
        End If
        CreateProductwisepurchase = dtab.Tables(0)
    End Function


    'Private Function CreateProductwisepurchase(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dtf As Date, ByVal dtt As Date) As DataTable
    '    Dim dtab As New DataSet
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim da As New OleDb.OleDbDataAdapter
    '    Dim sql As String
    '    cmd.Connection = Conn
    '    sql = ""
    '    ' If (cbrnge) Then
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "GetProductwisePurchase"
    '    cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
    '    cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
    '    cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
    '    cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
    '    cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
    '    cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
    '    cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt

    '    da.SelectCommand = cmd
    '    da.Fill(dtab)

    '    CreateProductwisepurchase = dtab.Tables(0)

    'End Function

    Private Function CreateStockAdj(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal dtf As Date, ByVal dtt As Date) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetStockAdj"
        cmd.Parameters.Add("@Supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtf
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateStockAdj = dtab.Tables(0)

    End Function
    Private Function CreateSupList() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetSupplierList"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateSupList = dtab.Tables(0)

    End Function
    Private Function CreateInvAccReceivable() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetInvReceivable"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateInvAccReceivable = dtab.Tables(0)

    End Function
    Private Function CreateInvAccPayable() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetInvPayable"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateInvAccPayable = dtab.Tables(0)

    End Function
    Private Function CreateComList() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetCompanyList"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateComList = dtab.Tables(0)

    End Function


    Private Function CreateComSupList() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetComSupList"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateComSupList = dtab.Tables(0)

    End Function

    Private Function CreateDLNote() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetPendingDL"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateDLNote = dtab.Tables(0)

    End Function

    Private Function CreateRackWise() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetRackwiseStock"
        cmd.Parameters.Add("@rackno", OleDb.OleDbType.VarChar).Value = Trim(cbRack.Text)
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateRackWise = dtab.Tables(0)

    End Function

    Private Function CreateScheduleWise() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 600
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Select_ScheduleSales"
        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtschf.Value.Date
        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtscht.Value.Date
        cmd.Parameters.Add("@sch", OleDb.OleDbType.VarChar).Value = cbsch.Text

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateScheduleWise = dtab.Tables(0)

    End Function
    Private Function CreateLockedProducts() As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "GetLockedProd"


        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateLockedProducts = dtab.Tables(0)

    End Function

    Private Function CreateProdwiseSaleDiscount(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = cmdtimeout
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Select_ProductwiseDiscSale"
        cmd.CommandTimeout = 60000

        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = 0
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        ' cmd.Parameters.Add("@short", OleDb.OleDbType.VarChar).Value = IIf(ChkComOpt.Checked, 1, 0)
        'cmd.Parameters.Add("@es", OleDb.OleDbType.VarChar).Value = 1

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProdwiseSaleDiscount = dtab.Tables(0)

    End Function
    Private Function CreateProdwiseSale(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = cmdtimeout
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Select_ProductwiseSale"
        cmd.CommandTimeout = 60000

        cmd.Parameters.Add("@dtf", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@dtt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = 0
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@short", OleDb.OleDbType.VarChar).Value = IIf(ChkComOpt.Checked, 1, 0)
        cmd.Parameters.Add("@es", OleDb.OleDbType.VarChar).Value = 1
        cmd.Parameters.Add("@frmno", OleDb.OleDbType.BigInt).Value = Val(txtinvf.Text)
        cmd.Parameters.Add("@tono", OleDb.OleDbType.BigInt).Value = Val(txtinvt.Text)

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProdwiseSale = dtab.Tables(0)

    End Function

    Private Function CreateExcessStock(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn
        sql = ""
        cmd.CommandTimeout = 120
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "GetExecssStock"

        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = dtpComf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtpComt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateExcessStock = dtab.Tables(0)

    End Function


    Private Sub ctbc_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctbc.VisibleChanged
        BtnView.Visible = ctbc.Visible
    End Sub

    Private Sub FillCombo()

    End Sub

    Private Sub ChkSupWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSupWise.CheckedChanged
        If ChkSupWise.Checked = True Then
            cbSupwise.Enabled = True
            chkdom.Enabled = True

        Else
            cbSupwise.Enabled = False
            chkdom.Enabled = False
            cbSupwise.SelectedValue = 0
            cbSupwise.SelectedText = ""
            cbSupwise.Text = ""
        End If
    End Sub

    Private Sub PopulateProduct()
        Try
            Txtcode.Text = ""
            txtpack.Text = ""
            If obj.text <> "" Then
                Dim cmd As New OleDb.OleDbCommand

                Dim da As New OleDb.OleDbDataAdapter
                Dim ds As New DataSet

                cmd.Connection = Conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 600
                cmd.CommandText = "Populate_product"
                cmd.Parameters.Add("@ctrl", OleDb.OleDbType.VarChar).Value = obj.text

                da.SelectCommand = cmd
                da.Fill(ds, "Product")


                DgProdSer.DataSource = ds.Tables("Product")
                If ds.Tables("Product").Rows.Count > 0 Then
                    pnlprod.Visible = True

                    DgProdSer.Focus()

                    Exit Sub
                End If
                cmd.Parameters.Clear()
            End If
            pnlprod.Visible = False
            obj.SelectionStart = obj.TextLength
            obj.focus()




        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub GetInfo()
        Try
            pnlprod.Visible = False
            GetProduct(DgProdSer.Item(0, DgProdSer.CurrentCell.RowIndex).Value)
            Txtname.Focus()
            Txtname.SelectionStart = Len(Txtname.Text)

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
                Txtname.Tag = "Y"
                Txtcode.Text = dataredr.Item("PrdCode")
                Txtname.Text = dataredr.Item("Prdname")
                txtpack.Text = dataredr.Item("case1")
                Txtname.Tag = ""
            End If
            Me.Cursor = Cursors.Default
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)
        End Try
    End Sub





    Private Sub SAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To lstcom.Items.Count - 1
            lstcom.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub DSAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To lstcom.Items.Count - 1
            lstcom.SetItemChecked(i, False)
        Next
    End Sub



    Private Sub ChkClsAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkClsAll.CheckedChanged
        If ChkClsAll.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstclass.Items.Count - 1
            lstclass.Tag = "Y"
            lstclass.SetItemChecked(i, (ChkClsAll.Checked))
            lstclass.Tag = ""
        Next
    End Sub



    Private Sub Chkgrp1All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGrp1All.CheckedChanged
        If ChkGrp1All.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstgrp1.Items.Count - 1
            lstgrp1.Tag = "Y"
            lstgrp1.SetItemChecked(i, (ChkGrp1All.Checked))
            lstgrp1.Tag = ""
        Next
    End Sub




    Private Sub Chkgrp2All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGrp2All.CheckedChanged
        If ChkGrp2All.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstgrp2.Items.Count - 1
            lstgrp2.Tag = "Y"
            lstgrp2.SetItemChecked(i, (ChkGrp2All.Checked))
            lstgrp2.Tag = ""
        Next
    End Sub



    Private Sub ChkcomAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkComAll.CheckedChanged
        If ChkComAll.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstcom.Items.Count - 1
            lstcom.Tag = "Y"
            lstcom.SetItemChecked(i, (ChkComAll.Checked))
            lstcom.Tag = ""
        Next
    End Sub



    Private Sub cbSupwise_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSupwise.SelectedIndexChanged
        CompanyList()
    End Sub

    Private Sub chkdom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdom.CheckedChanged
        CompanyList()
    End Sub


    Private Sub DgProdSer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellDoubleClick
        Try
            GetInfo()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub DgProdSer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles DgProdSer.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                GetInfo()
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)
            End Try
        End If
    End Sub


    Private Sub DgProdSer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgProdSer.KeyDown
        If e.KeyCode = Keys.F10 Then
            If MsgBox("Add " & DgProdSer.Item(1, DgProdSer.CurrentRow.Index).Value & " to Short list ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim CMD As New OleDb.OleDbCommand
            CMD.Connection = Conn
            CMD.CommandType = CommandType.StoredProcedure
            CMD.CommandTimeout = 600
            CMD.CommandText = "Update_ShortItem"
            CMD.Parameters.Add("@Code", OleDb.OleDbType.VarChar).Value = DgProdSer.Item(0, DgProdSer.CurrentRow.Index).Value
            CMD.Parameters.Add("flg", OleDb.OleDbType.Boolean).Value = 1
            CMD.ExecuteNonQuery()
            CMD.Parameters.Clear()
            CMD.CommandType = CommandType.Text
        End If
    End Sub

    Private Sub DgProdSer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgProdSer.KeyPress
        Try
            If e.KeyChar = "[" Or Asc(e.KeyChar) = 34 Then e.KeyChar = ""

            If Asc(e.KeyChar) = 9 Then Exit Sub

            If Asc(e.KeyChar) = 13 Then Exit Sub

            If Asc(e.KeyChar) = 27 Then
                pnlprod.Visible = False : obj.Text = "" : obj.Focus() : Exit Sub
            End If

            If Asc(e.KeyChar) = 8 And obj.Text <> "" Then
                obj.Text = Microsoft.VisualBasic.Left(Trim(obj.Text), Len(obj.Text) - 1)
                If obj.Text = "" Then pnlprod.Visible = False : obj.Text = "" : obj.Focus()
            Else

                obj.Text = obj.Text & UCase(e.KeyChar)
                e.KeyChar = ""

            End If
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcustwiseser.SelectedIndexChanged

        'Patient(Name)
        'Doctor(Name)
        'Customer(Name)
        'Card(No)
        'Institution(Emp.No)
        'Institution ESI No
        'Institution(Name)
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        txtser.Items.Clear()
        dt.Clear()
        cmd.Connection = Conn
        Select Case cbcustwiseser.SelectedIndex
            Case 0
                lblser.Text = "Patient Name"
                lblser.Visible = True
                txtser.Visible = True
                cmbcust.Visible = False
                txtser.Text = ""
                cbccard.Visible = False
                chkinc.Visible = True

                cmd.CommandText = "select patname from patient order by patname "
                da.SelectCommand = cmd
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    txtser.Items.Add(dt.Rows(i).Item("patname") & "")
                Next
            Case 1
                lblser.Text = "Doctor Name"
                chkinc.Visible = True
                lblser.Visible = True
                txtser.Visible = True
                cmbcust.Visible = False
                txtser.Text = ""
                cbccard.Visible = False
                cmd.CommandText = "select docname from Doctor order by docname "
                da.SelectCommand = cmd
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    txtser.Items.Add(dt.Rows(i).Item("docname") & "")
                Next
            Case 2
                lblser.Text = "Customer Name"
                cmbcust.Visible = True
                lblser.Visible = True

                txtser.Visible = False
                txtser.Text = ""
                cbccard.SelectedValue = 0
                cbccard.SelectedText = ""
                cbccard.Visible = False
                chkinc.Visible = False
            Case 3
                lblser.Text = "Cust. Card No."
                cbcustwiseser.Visible = True
                cbccard.Visible = True
                cmbcust.Visible = False
                txtser.Visible = True
                lblser.Visible = True
                txtser.Text = ""



            Case 4
                lblser.Text = "Inst. Emp. No"
                lblser.Visible = True
                txtser.Visible = True
                cmbcust.Visible = False
                txtser.Text = ""
                cbccard.Visible = False
                chkinc.Visible = False
            Case 5
                lblser.Text = "Inst. ESI No"
                lblser.Visible = True
                txtser.Visible = True
                txtser.Text = ""
                cmbcust.Visible = False

                cbccard.Visible = False
                chkinc.Visible = False
            Case 6
                lblser.Text = "Inst. Name"
                lblser.Visible = True
                txtser.Visible = True
                cmbcust.Visible = False
                txtser.Text = ""

                cbccard.Visible = False
                chkinc.Visible = True
        End Select
    End Sub

    Private Function CreateCustomerWiseSales() As DataTable
        Dim wher, sql As String

        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        cmd.Connection = Conn
        sql = "SELECT     Invtotal.Invno, Invtotal.Invdt, Invtotal.Type, Product.PrdName, InvDetails.Batch, " & _
            "InvDetails.ExDt, InvDetails.Pack, (case  when left(Invtotal.Type,1)='3' then InvDetails.Qty else InvDetails.Qty end) as qty , InvDetails.Srate, " & _
            "InvDetails.Unit, InvDetails.Seq, Invtotal.CardNo, Invtotal.empno, Invtotal.ESINO, Invtotal.EmpName, " & _
            "CardDetails.Name as cardname, Acmaster.AcName, Acmaster.Place,Invtotal.Name AS Name, Invtotal.DocName " & _
            ", Invtotal.DedAmt, Invtotal.AddAmt, Invtotal.BDisAmt, Invtotal.BDis,(case  when left(Invtotal.Type,1)='3' then Invtotal.netamt*-1 else Invtotal.netamt end) as netamt  " & _
            "FROM InvDetails INNER JOIN Invtotal ON InvDetails.Invno = Invtotal.InvNo AND " & _
            " InvDetails.Invdt = Invtotal.InvDt AND InvDetails.Type = Invtotal.Type INNER JOIN " & _
            "Product ON InvDetails.PrdCode = Product.PrdCode LEFT OUTER JOIN " & _
            "CardDetails ON Invtotal.CardNo = CardDetails.cardno LEFT OUTER JOIN " & _
            "Acmaster ON Invtotal.CusCode = Acmaster.AcCode "
        Select Case cbcustwiseser.SelectedIndex
            Case 0
                If chkinc.Checked Then
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27' )  AND Invtotal.name like '%" & txtser.Text & "%' "
                Else
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND upper(Invtotal.name) = '" & UCase(txtser.Text) & "' "
                End If
            Case 1
                If chkinc.Checked Then
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.docname like '%" & txtser.Text & "%' "
                Else
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND  upper(Invtotal.docname) = '" & UCase(txtser.Text) & "' "
                End If
            Case 2
                wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.cuscode = " & Val(cmbcust.SelectedValue & "")

            Case 3
                wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.cardno = '" & Val(txtser.Text & "") & "' "
            Case 4

                wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.empno  = '" & txtser.Text & "'"
            Case 5
                wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.esino  = '" & txtser.Text & "'"
            Case 6
                If chkinc.Checked Then
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND Invtotal.empname like '%" & txtser.Text & "%' "
                Else
                    wher = " WHERE (Invtotal.TYPE='21' OR INVTOTAL.TYPE='22' OR INVTOTAL.TYPE='31' OR INVTOTAL.TYPE='32' OR INVTOTAL.TYPE='25' OR INVTOTAL.TYPE='37' OR INVTOTAL.TYPE='27')  AND  upper(Invtotal.empname) = '" & UCase(txtser.Text) & "' "
                End If
        End Select
        wher = wher & " and Invtotal.cancelled=0  and Invtotal.invdt>=convert(datetime,'" & dtpcustwisef.Value.Date & "') and Invtotal.invdt<=convert(datetime,'" & dtpcustwiset.Value.Date & "' )"
        sql = sql & wher
        cmd.CommandText = sql
        da.SelectCommand = cmd
        da.Fill(dtab)
        CreateCustomerWiseSales = dtab
    End Function

    Private Sub cbccard_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbccard.SelectedIndexChanged
        If cbcustwiseser.SelectedIndex = 3 Then
            txtser.Tag = "Y"
            txtser.Text = cbccard.SelectedValue
            txtser.Tag = ""
        End If
    End Sub

    Private Sub txtser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtser.TextChanged
        If cbcustwiseser.SelectedIndex = 3 Then
            Try

                If txtser.Tag = "Y" Then Exit Sub
                If txtser.Text = "" Then
                    txtser.Text = ""
                    txtser.Tag = "Y"
                    txtser.Text = ""
                    cbccard.SelectedValue = 0
                    txtser.Tag = ""
                    Exit Sub
                End If

                cbccard.SelectedValue = Val(txtser.Text)
            Catch er As Exception
                ErrorMsg(er.Message, er.StackTrace)

            End Try
        End If
    End Sub

    Private Sub ChkSuppAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSuppAll.CheckedChanged
        If ChkSuppAll.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To lstsupp.Items.Count - 1
            lstsupp.Tag = "Y"
            lstsupp.SetItemChecked(i, (ChkSuppAll.Checked))
            lstsupp.Tag = ""
        Next
    End Sub





    Private Sub tbc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbc.SelectedIndexChanged
        Label1.Text = tbc.SelectedTab.ToolTipText
    End Sub


    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.TextChanged
        'If ProdSelected = True Then Exit Sub
        Try
            If Txtname.Tag = "Y" Then Exit Sub
            obj = Txtname
            PopulateProduct()
        Catch er As Exception
            ErrorMsg(er.Message, er.StackTrace)

        End Try
    End Sub

    Private Sub DgProdSer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgProdSer.CellContentClick

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub lstcom_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstcom.KeyPress
        Dim fnd As Boolean = False
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            'Me.Text = System.Math.Abs(Val(Mid(Now().TimeOfDay.ToString, 7, 2))) & "  " & Val(Mid(sertime, 7, 2)) & "  " & sertxt


            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = CDate(Now().TimeOfDay.ToString)
            For n = 0 To lstcom.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstcom.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstcom.SelectedItem = lstcom.Items(n)
                    ' lstcom.SelectedIndex = n
                    e.Handled = True
                    fnd = True
                    Exit For
                End If
            Next n
            If fnd = False Then sertxt = UCase(e.KeyChar)

        End If

    End Sub

    Private Sub lstcom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstcom.SelectedIndexChanged

    End Sub

    Private Sub ChkAllShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAllShift.CheckedChanged
        cbshft.Enabled = (ChkAllShift.Checked = False)
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtmrpto.TextChanged

    End Sub

    Private Sub lstclass_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstclass.KeyPress
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 5 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = Now().TimeOfDay.ToString
            For n = 0 To lstclass.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstclass.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstclass.SelectedItem = lstclass.Items(n)
                    'lstcom.SelectedIndex = n
                    e.Handled = True
                    Exit For
                End If
            Next n
        End If
    End Sub

    Private Sub lstclass_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstclass.SelectedIndexChanged

    End Sub

    Private Sub lstgrp1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstgrp1.KeyPress
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = Now().TimeOfDay.ToString
            For n = 0 To lstgrp1.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstgrp1.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstgrp1.SelectedItem = lstgrp1.Items(n)
                    'lstcom.SelectedIndex = n
                    e.Handled = True
                    Exit For
                End If
            Next n
        End If
    End Sub

    Private Sub lstgrp2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstgrp2.KeyPress
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = Now().TimeOfDay.ToString
            For n = 0 To lstgrp2.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstgrp2.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstgrp2.SelectedItem = lstgrp2.Items(n)
                    'lstcom.SelectedIndex = n
                    e.Handled = True
                    Exit For
                End If
            Next n
        End If
    End Sub

    Private Sub lstsupp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lstsupp.KeyPress
        Dim fnd As Boolean = False
        If e.KeyChar = Chr(27) Then sertxt = ""
        If InStr("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", UCase(e.KeyChar)) <> 0 Then
            'Me.Text = System.Math.Abs(Val(Mid(Now().TimeOfDay.ToString, 7, 2))) & "  " & Val(Mid(sertime, 7, 2)) & "  " & sertxt


            If System.Math.Abs(Val(Mid(Format(CDate(Now().TimeOfDay.ToString), "hh:mm:ss"), 7, 2)) - Val(Mid(Format(sertime, "hh:mm:ss"), 7, 2))) > 2 Or sertxt = "" Then
                sertxt = UCase(e.KeyChar)
            Else
                sertxt = sertxt & UCase(e.KeyChar)
            End If
            sertime = CDate(Now().TimeOfDay.ToString)
            For n = 0 To lstsupp.Items.Count - 1
                If Microsoft.VisualBasic.Left(lstsupp.Items(n).ToString, Len(sertxt)) = sertxt Then
                    Application.DoEvents()
                    lstsupp.SelectedItem = lstsupp.Items(n)
                    ' lstcom.SelectedIndex = n
                    e.Handled = True
                    fnd = True
                    Exit For
                End If
            Next n
            If fnd = False Then sertxt = UCase(e.KeyChar)

        End If
    End Sub

    Private Function CreateProductWiseDateWise(ByVal tmpcom As String, ByVal tmpcls As String, ByVal tmpgrp1 As String, ByVal tmpgrp2 As String, ByVal sdt As Date, ByVal edt As Date, ByVal grp As Integer, ByVal top As Long) As DataTable
        Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.CommandTimeout = cmdtimeout
        cmd.Connection = Conn
        sql = ""
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 60000
        cmd.CommandText = "GetProductwiseSaleDatewise"
        cmd.Parameters.Add("@supp", OleDb.OleDbType.BigInt).Value = Val(cbSupwise.SelectedValue & "")
        cmd.Parameters.Add("@com", OleDb.OleDbType.VarChar).Value = tmpcom
        cmd.Parameters.Add("@cls", OleDb.OleDbType.VarChar).Value = tmpcls
        cmd.Parameters.Add("@grp1", OleDb.OleDbType.VarChar).Value = tmpgrp1
        cmd.Parameters.Add("@grp2", OleDb.OleDbType.VarChar).Value = tmpgrp2
        cmd.Parameters.Add("@stdt", OleDb.OleDbType.DBDate).Value = sdt
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = edt
        cmd.Parameters.Add("@grp", OleDb.OleDbType.Integer).Value = grp
        cmd.Parameters.Add("@top", OleDb.OleDbType.Integer).Value = top
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        da.SelectCommand = cmd
        da.Fill(dtab)
        'MsgBox(dtab.Tables(0).Rows.Count)
        CreateProductWiseDateWise = dtab.Tables(0)

    End Function

    Private Function CreateProdEdited() As DataTable
        Dim dtab As New DataTable
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        cmd.Connection = Conn

        sql = ""

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 600
        cmd.CommandText = "Get_ProdEdited"
        cmd.Parameters.Add("@StDt", OleDb.OleDbType.Date).Value = dtf.Value.Date
        cmd.Parameters.Add("@EdDt", OleDb.OleDbType.Date).Value = dtt.Value.Date
        da.SelectCommand = cmd
        da.Fill(dtab)

        CreateProdEdited = dtab

    End Function

    Private Sub cbrpt_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbrpt.SelectedIndexChanged

        If cbrpt.SelectedIndex = 4 Then
            frmlbl.Visible = True
            tolbl.Visible = True
            bfrmtxt.Visible = True
            btotxt.Visible = True
            ChkSum1.Visible = True

        Else
            frmlbl.Visible = False
            tolbl.Visible = False
            bfrmtxt.Visible = False
            btotxt.Visible = False
            ChkSum1.Visible = False

        End If
    End Sub

    Private Sub chkCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCust.CheckedChanged
        If chkCust.Checked = True Then
            cbcust.Enabled = True
        Else
            cbcust.Enabled = False
            cbcust.SelectedValue = 0
            cbcust.SelectedText = ""
            cbcust.Text = ""
        End If
    End Sub

    Private Sub ChkAllCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkAllCust.CheckedChanged
        If ChkAllCust.Tag = "Y" Then Exit Sub
        For i As Integer = 0 To chklstCust.Items.Count - 1
            chklstCust.Tag = "Y"
            chklstCust.SetItemChecked(i, (ChkAllCust.Checked))
            chklstCust.Tag = ""
        Next
    End Sub

    Private Sub ChkSupWise_EnabledChanged(sender As Object, e As System.EventArgs) Handles ChkSupWise.EnabledChanged
        'MsgBox("dd")
    End Sub

    Private Sub ctb2_Click(sender As System.Object, e As System.EventArgs) Handles ctb2.Click

    End Sub
End Class
