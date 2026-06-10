Public Class OrderList
    Inherits System.Windows.Forms.Form

    Public Sub getdata1(ByRef old As Boolean)
        Dim wname As Object
        On Error GoTo errmsg
        Dim DT As New DataTable
        Dim DT1 As New DataTable
        Dim DA As New SqlClient.SqlDataAdapter
        Dim scmd As New SqlClient.SqlCommand
        Dim scmd1 As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn
        scmd1.Connection = PopsConn
        If old Then
            scmd.CommandText = "select rordno,rorddt,supclientid,orderno,orderdate from orders where clientid = '" & ClientId & "' group by rordno,rorddt,supclientid,orderno,orderdate order by rorddt desc,rordno desc "
        Else
            scmd.CommandText = "select rordno,rorddt,supclientid,orderno,orderdate from orders where clientid = '" & ClientId & "' and isnull(processed,'')<>'P'  group by rordno,rorddt,supclientid,orderno,orderdate order by rorddt desc,rordno desc "
        End If
        DA.SelectCommand = scmd
        DA.Fill(DT)
        listgrid.Rows.Clear()
        listgrid2.Rows.Clear()
        If DT.Rows.Count > 0 Then
            For I As Integer = 0 To DT.Rows.Count - 1


                'If CheckPOPSConnection() = False Then
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If

                scmd1.CommandText = "select name from users where id = '" & DT.Rows(I).Item("supclientid") & "'"
                DA.SelectCommand = scmd1
                DA.Fill(DT1)
                If DT1.Rows.Count <> 0 Then
                    listgrid.Rows.Add()
                    listgrid.Item(0, listgrid.Rows.Count - 1).Value = DT.Rows(I).Item("Rordno")
                    listgrid.Item(1, listgrid.Rows.Count - 1).Value = Microsoft.VisualBasic.Format(DT.Rows(I).Item("Rorddt"), "dd/MM/yyyy")
                    listgrid.Item(2, listgrid.Rows.Count - 1).Value = DT1.Rows(0).Item(0) & ""
                    listgrid.Item(3, listgrid.Rows.Count - 1).Value = DT.Rows(I).Item("orderno")
                    listgrid.Item(4, listgrid.Rows.Count - 1).Value = Microsoft.VisualBasic.Format(DT.Rows(I).Item("orderdate"), "dd/MM/yyyy")
                End If
                DT1.Rows.Clear()
            Next
        Else
            listgrid2.Rows.Clear()
            listgrid.Rows.Add()
        End If


        PopsConn.Close()
        Exit Sub
errmsg:
        MsgBox(Err.Description)
        PopsConn.Close()
    End Sub

    'UPGRADE_WARNING: Event Check1.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
        getdata1((Check1.CheckState = 1))

    End Sub

    Private Sub orderlist_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        getdata1((Check1.CheckState = 1))
    End Sub

    Private Sub orderlist_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Hide()
    End Sub


    Private Sub listgrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles listgrid.CellEnter
        On Error GoTo errmsg
        Dim rs As SqlClient.SqlDataReader
        Dim scmd As New SqlClient.SqlCommand
        If CheckPOPSConnection() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        scmd.Connection = PopsConn

        scmd.CommandText = "select prodname,qty,free,processed from orders where clientid = '" & ClientId & "'  and rordno = " & Val(listgrid.Item(0, listgrid.CurrentCell.RowIndex).Value & "")

        'If rs.RecordCount <> 0 Then
        listgrid2.Rows.Clear()
        rs = scmd.ExecuteReader
        While rs.Read
            listgrid2.Rows.Add()
            listgrid2.Item(0, listgrid2.Rows.Count - 1).Value = rs("prodname")
            listgrid2.Item(1, listgrid2.Rows.Count - 1).Value = rs("qty")
            listgrid2.Item(2, listgrid2.Rows.Count - 1).Value = rs("free")
            If rs("processed") & "" = "P" Then
                listgrid2.Item(3, listgrid2.Rows.Count - 1).Value = "Yes"
            Else
                listgrid2.Item(3, listgrid2.Rows.Count - 1).Value = "No"
            End If

        End While



        rs.Close()
        PopsConn.Close()
        Exit Sub

errmsg:
        PopsConn.Close()
        MsgBox(Err.Description)

    End Sub

    Private Sub Check1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Check1.CheckedChanged

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        getdata1((Check1.CheckState = 1))
    End Sub
End Class