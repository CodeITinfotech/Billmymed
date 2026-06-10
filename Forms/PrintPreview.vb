Imports PrePrintDirectClass
'Imports PrePrintDirect_Class

Public Class PrintPreview
    Dim ds As New DataTable
    Public dga() As DataGridView

    Public Sub CreateTab(ByVal cap As String)

        Dim tbl As New TableLayoutPanel
        Dim dg As New DataGridView
        Dim pg As New TabPage
        Dim lbl As New Label
        'Dim sty1 As New RowStyle
        'Dim sty2 As New RowStyle
        'Dim cols As New ColumnStyle
        'sty1.SizeType = SizeType.AutoSize
        'sty2.SizeType = SizeType.AutoSize
        'cols.SizeType = SizeType.AutoSize
        'tbl.Name = "Tbl"
        dg.Name = "Dg"
        lbl.Name = "lbl"
        ''tbl.RowCount = 2

        'tbl.ColumnCount = 1

        dg.Dock = DockStyle.Fill
        lbl.Visible = False
        'lbl.AutoSize = True
        'tbl.RowStyles.Add(sty1)
        'tbl.RowStyles.Add(sty2)
        'tbl.ColumnStyles.Add(cols)
        'tbl.Dock = DockStyle.Fill
        'tbl.AutoSize = True

        'tbl.Parent = pg


        'lbl.Text = "skhd S SSLSKJSS KJSSKJHSJKSH KSJS KBS KJSHKJSH SKJHSKJSHSK  HKJH KJH KJ L;KS;LSK934938398 39833-44 9I3P4IU4 9083494 UI34U40U -98409394 3-84-98 -4398 49-834-98 9-83-98 -98 4--938  948-98-34-=3 -039-049- -095-0HSJH JS HJKHJHS JH  SS KJHSKJSHSJKHSJHSJKSH "




        tbl.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single

        'lbl.Parent = tbl

        dg.Parent = pg
        dg.Dock = DockStyle.Fill
        'pg.Tag = cap
        'tbl.SetRow(lbl, 0)
        'tbl.SetRowSpan(lbl, 1)
        'tbl.SetColumn(lbl, 1)


        'tbl.SetRow(dg, 1)
        'tbl.SetRowSpan(dg, 1)
        'tbl.SetColumn(dg, 1)
        'tbl.GrowStyle = TableLayoutPanelGrowStyle.AddRows

        AddHandler dg.CellDoubleClick, AddressOf Dg_CellDoubleClick
        dg.EditMode = DataGridViewEditMode.EditProgrammatically
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        pg.Controls.Add(lbl)
        dg.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        pg.ForeColor = TB.Parent.ForeColor
        pg.Text = cap '"Report " & TB.TabCount + 1
        TB.TabPages.Add(pg)

    End Sub

    Public Function GetLabel() As Label
        Dim cntrl() As Control
        cntrl = TB.TabPages(TB.TabPages.Count - 1).Controls.Find("lbl", True)
        Return cntrl(0)
    End Function

    Public Function GetGrid() As DataGridView
        Dim cntrl() As Control
        cntrl = TB.TabPages(TB.TabPages.Count - 1).Controls.Find("dg", True)
        Return cntrl(0)
    End Function

    Private Sub Dg_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'MsgBox(DirectCast(sender, DataGridView).CurrentCell.Value)

    End Sub



    Private Sub PrintPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Color.Wheat
        ToolStrip.Renderer = renderer
    End Sub



    Private Sub TB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB.SelectedIndexChanged

    End Sub

    Private Sub tsbCls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCls.Click
        Me.Close()
    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click
        Dim Bdt1 As Date
        Dim Bdt2 As Date
        Dim BN1 As Long
        Dim BN2 As Long
        Dim Btype As String
        Dim lb() As Control
        'Dim RPT
        Dim CMD As New OleDb.OleDbCommand
        Dim DR As OleDb.OleDbDataReader
        Dim RPT1 As New Object
        BN1 = System.Math.Abs(Val(Microsoft.VisualBasic.Left(TB.SelectedTab.Text, InStr(TB.SelectedTab.Text, "-"))))
        BN2 = System.Math.Abs(Val(Mid(TB.SelectedTab.Text, InStr(TB.SelectedTab.Text, "-") + 1, Len(TB.SelectedTab.Text))))

        lb = TB.SelectedTab.Controls.Find("lbl", True)

        Bdt1 = CDate(Microsoft.VisualBasic.Left(lb(0).Text, InStr(lb(0).Text, "-") - 1))
        Bdt2 = CDate(Mid(lb(0).Text, InStr(lb(0).Text, "-") + 1, Len(lb(0).Text)))


        CMD.Connection = Conn
        CMD.CommandText = "select printline,preprintline,invmsg,invpreprint,BigPrintForCredit,printlinebig from settings"
        DR = CMD.ExecuteReader
        DR.Read()

        If DR("invpreprint") Then
            'RPT = New PharmaPrePrint.PrePrintDirect
            'RPT.PageLines = DR("preprintline")
            'RPT.Main_form = Me.ParentForm
            'RPT.DbConn = Conn
            'RPT.Pre_Form = Me
            'RPT1 = New PrePrintDirect.PrePrintDirect
            RPT1 = New PrePrintDirect
            RPT1.PageLines = DR("preprintline")
        Else
            RPT1 = New PrintDirectClass.PrintDirect
            RPT1.PageLines = DR("printline")
            If DR("BigPrintForCredit") And lb(0).Tag = "22" Or DR("BigPrintForCredit") And lb(0).Tag = "32" Then
                RPT1 = New PrintDirectBig.PrintDirectBig
                RPT1.PageLines = DR("printlinebig")
            End If
        End If

        RPT1.PrintMessage = (DR("invmsg") & "")
        DR.Close()
        RPT1.StartNumber = BN1
        RPT1.EndNumber = BN1
        RPT1.StartDate = Bdt1
        RPT1.EndDate = Bdt2
        RPT1.TransType = lb(0).Tag
        FirmValues(RPT1)

        RPT1.PrintDestination = PrintOutput.ToPrinter

        RPT1.PrintInvoice(Conn, Me, Main, TB)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
End Class