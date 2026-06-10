Public Class GraphPurchase

    Private Sub CreatePG()
          Dim dtab As New DataSet
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String
        Me.Cursor = Cursors.WaitCursor
        If gr.Tag = "Y" Then Exit Sub
        gr.Tag = "Y"
        cmd.Connection = Conn
        sql = ""

        gr.Visible = False
        lblwait.Visible = True
        cmd.CommandType = CommandType.StoredProcedure
 
        cmd.CommandText = "GetPurchaseSum"


        cmd.Parameters.Add("@Stdt", OleDb.OleDbType.DBDate).Value = dtf.Value.Date
        cmd.Parameters.Add("@eddt", OleDb.OleDbType.DBDate).Value = dtt.Value.Date
        cmd.Parameters.Add("@es", OleDb.OleDbType.Integer).Value = 1

        da.SelectCommand = cmd
        da.Fill(dtab)

        Dim xq, mini, maxi, x1, valu, nod, ava As Double
        gr.Series(0).Points.Clear()
        gr.Series(1).Points.Clear()

        'gr.Series.Clear()
        'gr.Series.Add("Sales")
        'gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.
        nod = 0
        For i = 0 To dtab.Tables(0).Rows.Count - 1
            x1 = 0
            On Error Resume Next
            If Microsoft.VisualBasic.IsDBNull(dtab.Tables(0).Rows(i).Item("netamt")) Then x1 = 0 Else x1 = dtab.Tables(0).Rows(i).Item("netamt") '- rsinv!dis
            On Error GoTo 0
            If x1 <> 0 Then

                gr.Series(0).Points.AddXY(Format(dtab.Tables(0).Rows(i).Item("pdt"), "MMM yy"), x1)

                If Val(x1) < mini Or mini = 0 Then mini = x1
                If Val(x1) > maxi Then maxi = x1
                nod = nod + 1
                valu = valu + x1
            End If
        Next i

        If nod = 0 Then ava = 0 Else ava = Val(valu / nod)
        'gr.Tag = ava
        For i As Integer = 0 To nod
            gr.Series(1).Points.AddY(ava)
        Next
        lblwait.Visible = False
        gr.Visible = True
        gr.Tag = ""
        Me.Cursor = Cursors.Default
        'CreateSj = dtab.Tables(0)
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim fs As New FileSystemObject
    '    Dim db As New ADODB.Connection
    '    Dim rsback As New ADODB.Recordset
    '    Dim rsinv As New ADODB.Recordset

    '    If Not IsDate(txtfrom) Or Not IsDate(txtto) Then
    '        x = MsgBox("Invalid Date ..!", vbCritical)
    '        txtfrom.SetFocus()
    '        Exit Sub
    '    End If

    '    Screen.MousePointer = vbHourglass
    '    TmpFile = fs.GetTempName
    '    fs.CopyFile(App.Path & "\tmprpt.mdb", App.Path & "\" & TmpFile)

    '    Stdt = CDate(txtfrom)
    '    Eddt = CDate(txtto)
    '    Sql = "insert into INVMTOTAL in '" & _
    '        App.Path & "\" & TmpFile & "'  SELECT invmtotal.* from " & _
    '        "invmtotal where invdt>=cdate('" & Stdt & "') and invdt<=cdate('" & Eddt & "') and (type='21' or type='22' or type='31' or type='32') "

    '    db.CursorLocation = adUseClient
    '    rsback.Open("select backup from backupname where (cdate('" & Stdt & "') >=backupname.stdt and cdate('" & Stdt & "')<=backupname.eddt) or (backupname.stdt<=cdate('" & Eddt & "') and backupname.stdt>=cdate('" & Stdt & "')) order by seq", Conn, adOpenStatic, adLockReadOnly, 1)
    '    While Not rsback.EOF
    '        db.ConnectionString = ConnStr & App.Path & "\backup\" & rsback(0) & ".MDB;Jet OLEDB:Database Password=" & Pwrd
    '        db.Open()
    '        db.Execute(Sql)
    '        db.Close()
    '        rsback.MoveNext()
    '    End While
    '    If MonStDt <= Eddt Then
    '        db.ConnectionString = Conn.ConnectionString
    '        db.Open()
    '        db.Execute(Sql)
    '        db.Close()
    '    End If
    '    db.ConnectionString = ConnStr & App.Path & "\" & TmpFile
    '    db.Open()
    '    Graph.RowCount = 0
    '    For dt = CDate(Stdt) To CDate(Eddt)


    '        rsinv.Open("select sum(iif(type='32' or type='31',netamt*-1,netamt)) as [sal] " & _
    '            " from invmtotal where " & _
    '            "invdt = cdate('" & dt & "') and flag & '' <> 'XX' ", db)

    '        X1 = 0
    '        On Error Resume Next
    '        If IsNull(rsinv!sal) Then X1 = 0 Else X1 = rsinv!sal '- rsinv!dis
    '        On Error GoTo 0
    '        If X1 <> 0 Then
    '            Graph.DataGrid.InsertRows(Graph.DataGrid.RowCount + 1, 1)
    '            Graph.DataGrid.SetData(Graph.DataGrid.RowCount, 1, X1, 0)
    '            Graph.DataGrid.RowLabel(Graph.DataGrid.RowCount, 1) = Format(dt, "dd")
    '            If Val(X1) < mini Or mini = 0 Then mini = X1
    '            If Val(X1) > maxi Then maxi = X1
    '            nod = nod + 1
    '            valu = valu + X1
    '        End If
    '        rsinv.Close()
    '    Next dt
    '    If nod = 0 Then ava = 0 Else ava = Val(valu / nod)
    '    For i = 1 To Graph.DataGrid.RowCount
    '        Graph.DataGrid.SetData(i, 2, ava, 0)
    '    Next i
    '    lblmax = "Min.: " & Format(mini, "0") & ".00"
    '    lblmin = "Max.: " & Format(maxi, "0") & ".00"
    '    lbltot = "Total: " & Format(valu, "0") & ".00"
    '    lblave = "Average: " & Format(ava, "0") & ".00"
    '    lbllst = "Last: " & Format(X1, "0") & ".00"
    '    lblgp = "" '"Gross Profit: " & "Wait."
    '    Graph.Title = "Daily sales from " & txtfrom & " to " & txtto & "."
    '    Graph.Repaint = True
    '    Graph.Visible = True
    '    Screen.MousePointer = vbDefault

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click

        CreatePG()
    End Sub

    Private Sub Graph_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtt.Value = SysDt
        dtf.Value = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Month, -1, SysDt))
        Me.Show()
        BtnView.PerformClick()
    End Sub

    Private Sub rdine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdline.CheckedChanged
        If Me.Visible = False Then Exit Sub
        If reBar.Checked Then
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

        Else
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline

        End If


    End Sub

    Private Sub reBar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reBar.CheckedChanged
        If Me.Visible = False Then Exit Sub
        If reBar.Checked Then
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

        Else
            gr.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        End If


    End Sub


    
End Class