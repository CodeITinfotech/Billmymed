Imports System.Net.Mail
'Imports System.Net.Mail
Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Net.Mime
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Text.RegularExpressions

Public Class EmailDetails

    Private Sub EmailDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbCustomer.DataSource = Nothing
        rdbLoyaltyCust.Checked = False
        rdbLoyaltyCust.Checked = True
        dgCust.Rows.Clear()
        txteMail.Text = ""
    End Sub

    Private Sub cbCustomer_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbCustomer.SelectedValueChanged
        CustomerChange()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        DoEmail()
    End Sub

    Sub DoEmail()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strHTML As String

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim palinBody As String = GenericPrint.rt.Text
            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(palinBody, Nothing, "text/plain")
            strHTML = ConvertToHTML(GenericPrint.rt)

            Dim htmlBody As String = strHTML 'strHTML 'HTMLT.HtmlDocument2.GetBody().innerHTML
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")
            'htmlView.LinkedResources.Add(img1)

            Dim blnSMTP As Boolean = False
            Dim blnCC As Boolean = False
            Dim blnAttachments As Boolean = False
            'Dim atch As Attachment

            cmd.Connection = Conn
            cmd.CommandText = "Select Host,PortNo,UserName,Password from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            Dim smtp As System.Net.Mail.SmtpClient = New SmtpClient(dt.Rows(0).Item("Host"), Val(dt.Rows(0).Item("PortNo")))
            smtp.Host = dt.Rows(0).Item("Host")

            smtp.Port = Val(dt.Rows(0).Item("PortNo"))
            smtp.UseDefaultCredentials = True
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential(dt.Rows(0).Item("UserName").ToString, dt.Rows(0).Item("Password").ToString)

            For i = 0 To dgCust.Rows.Count - 1
                If dgCust.Item(2, i).Value & "" <> "" Then
                    If EmailAddressCheck(dgCust.Item(2, i).Value) = True Then
                        Dim insMail As New System.Net.Mail.MailMessage()
                        With insMail
                            .From = New System.Net.Mail.MailAddress(dt.Rows(0).Item("UserName").ToString, DeScriptRS(Firm.Name))
                            .To.Add(New System.Net.Mail.MailAddress(dgCust.Item(2, i).Value).ToString)
                            .IsBodyHtml = True
                            .Subject = "PATIENT INFORMATION LEAFLET"
                            .AlternateViews.Add(htmlView)
                        End With
                        smtp.Send(insMail)
                    End If
                End If
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        
    End Sub

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function

    Public Function ConvertToHTML(ByVal Box As RichTextBox) As String
        ' Takes a RichTextBox control and returns a
        ' simple HTML-formatted version of its contents
        Dim strHTML As String
        Dim strColour As String
        Dim blnBold As Boolean
        Dim blnItalic As Boolean
        Dim strFont As String
        Dim shtSize As Short
        Dim lngOriginalStart As Long
        Dim lngOriginalLength As Long
        Dim intCount As Integer
        ' If nothing in the box, exit
        If Box.Text.Length = 0 Then
            Exit Function
        End If

        lngOriginalStart = 0
        lngOriginalLength = Box.TextLength
        Box.Select(0, 1)
        'Box
        strHTML = "<html>"
        strColour = Box.SelectionColor.ToKnownColor.ToString
        blnBold = Box.SelectionFont.Bold
        blnItalic = Box.SelectionFont.Italic
        strFont = Box.SelectionFont.FontFamily.Name
        shtSize = Box.SelectionFont.Size

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\MailHeader.jpg") Then


            'Dim img1 As LinkedResource = New LinkedResource("C:\Users\admin\Desktop\imgres.jpg", MediaTypeNames.Image.Jpeg)
            'img1.ContentId = "Image1"
            Dim base64Data As String
            base64Data = Convert.ToBase64String(System.IO.File.ReadAllBytes(Application.StartupPath & "\MailHeader.jpg"))
            ' strHTML += "<% string base64Data = Convert.ToBase64String(File.ReadAllBytes(""C:\Users\admin\Desktop\A.jpg"")); %>"
            strHTML += "<img src=""data:image/png;base64," & base64Data & """ alt=""" & Application.StartupPath & "\MailHeader.jpg" & """ />"
        End If
        strHTML += "<span style=""font-family: " & strFont & _
          "; font-size: " & shtSize & "pt; color: " _
                          & strColour & """>"

        If blnBold = True Then
            strHTML += "<b>"
        End If
        ' Include italic tag, if required
        If blnItalic = True Then
            strHTML += "<i>"
        End If
        ' Final add our first character
        strHTML += Box.Text.Substring(0, 1)
        ' Loop around all remaining characters
        For intCount = 2 To Box.Text.Length
            Box.Select(intCount - 1, 1)
            If Box.Text.Substring(intCount - 1, 1) = _
                   Convert.ToChar(10) Then
                strHTML += "<br>"
            End If
            If IsNothing(Box.SelectionFont) = False Then
                If Box.SelectionColor.ToKnownColor.ToString <> _
                   strColour Or Box.SelectionFont.FontFamily.Name _
                   <> strFont Or Box.SelectionFont.Size <> shtSize Then
                    strHTML += "</span><span style=""font-family: " _
                      & Box.SelectionFont.FontFamily.Name & _
                      "; font-size: " & Box.SelectionFont.Size & _
                      "pt; color: " & _
                      Box.SelectionColor.ToKnownColor.ToString & """>"
                End If

                ' Check for bold changes
                If Box.SelectionFont.Bold <> blnBold Then
                    If Box.SelectionFont.Bold = False Then
                        strHTML += "</b>"
                    Else
                        strHTML += "<b>"
                    End If
                End If
                If Box.SelectionFont.Italic <> blnItalic Then
                    If Box.SelectionFont.Italic = False Then
                        strHTML += "</i>"
                    Else
                        strHTML += "<i>"
                    End If
                End If
                strHTML += Mid(Box.Text, intCount, 1)
                strColour = Box.SelectionColor.ToKnownColor.ToString
                blnBold = Box.SelectionFont.Bold
                blnItalic = Box.SelectionFont.Italic
                strFont = Box.SelectionFont.FontFamily.Name

                shtSize = Box.SelectionFont.Size
            End If
        Next

        If blnBold = True Then strHTML += ""

        If blnItalic = True Then strHTML += ""
        strHTML += "</span></html>"

        ' Create alternate view HTML


        Box.Select(lngOriginalStart, lngOriginalLength)
        ' Return HTML
        Return strHTML
    End Function

    Private Sub rdbCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbCust.CheckedChanged
        'cbCustomer.DataSource = Nothing
        FillCust()
    End Sub

    Private Sub FillCust()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        'Dim I As Integer
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = Conn
        If rdbCust.Checked = True Then
            cbCustomer.DataSource = Nothing
            cmd.CommandText = "select Accode,Acname from Acmaster where (grpcode=" & CustGrpcode & " or grpcode=5)  order by Acname"
            DA.SelectCommand = cmd
            DA.Fill(DS, "Acmaster")
            cbCustomer.DisplayMember = "AcName"
            cbCustomer.ValueMember = "Accode"
            cbCustomer.DataSource = DS.Tables("Acmaster")
            txteMail.Text = ""
            cbCustomer.SelectedIndex = -1
        ElseIf rdbLoyaltyCust.Checked = True Then
            cbCustomer.DataSource = Nothing
            cmd.CommandText = "select cardno,name from CardDetails order by name"
            DA.SelectCommand = cmd
            DA.Fill(DS, "CardDetails")
            cbCustomer.DisplayMember = "name"
            cbCustomer.ValueMember = "cardno"
            cbCustomer.DataSource = DS.Tables("CardDetails")
            txteMail.Text = ""
            cbCustomer.SelectedIndex = -1
        End If
    End Sub

    Private Sub rdbLoyaltyCust_CheckedChanged(sender As Object, e As System.EventArgs) Handles rdbLoyaltyCust.CheckedChanged
        FillCust()
    End Sub
    Private Sub CustomerChange()
        Dim DA As New OleDb.OleDbDataAdapter
        Dim DS As New DataSet
        Dim dt As DataTable
        'Dim I As Integer
        Try
            If rdbCust.Checked = True Then
                If IsNothing(cbCustomer.SelectedValue) = False Then
                    Dim cmd As New OleDb.OleDbCommand
                    cmd.Connection = Conn
                    cmd.CommandText = "select Accode,Acname,Email from Acmaster where (Accode=" & cbCustomer.SelectedValue & ")"
                    DA.SelectCommand = cmd
                    DA.Fill(DS, "Email")
                    dt = DS.Tables("Email")

                    txteMail.Text = dt.Rows(0).Item("Email")
                End If
            ElseIf rdbLoyaltyCust.Checked = True Then
                If IsNothing(cbCustomer.SelectedValue) = False Then
                    Dim cmd As New OleDb.OleDbCommand
                    cmd.Connection = Conn
                    cmd.CommandText = "select cardno,name,Emailid from CardDetails where (cardno=" & cbCustomer.SelectedValue & ")"
                    DA.SelectCommand = cmd
                    DA.Fill(DS, "Email")
                    dt = DS.Tables("Email")

                    txteMail.Text = dt.Rows(0).Item("Emailid")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If cbCustomer.SelectedIndex > -1 Then
                dgCust.Rows.Add(cbCustomer.SelectedValue, cbCustomer.Text, txteMail.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            dgCust.Rows.Clear()
            cbCustomer.SelectedIndex = -1
            txteMail.Text = ""
        Catch ex As Exception

        End Try
    End Sub
End Class