


Imports System.IO

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


Public Class EmailSndng





    Dim obj As Object
    Dim CCode, Eml
    Dim word As Object
    ' Dim wrdApp As New Word.Application

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

            HTMLT.Text = ""
            txtCust.Text = ""
            cmbCustGrp.Text = ""
            txtAtch1.Text = "" : txtAtch1.Visible = False
            txtAtch2.Text = "" : txtAtch2.Visible = False
            txtAtch3.Text = "" : txtAtch3.Visible = False
            txtAtch4.Text = "" : txtAtch4.Visible = False
            txtAtch5.Text = "" : txtAtch5.Visible = False
            txtAtch6.Text = "" : txtAtch6.Visible = False
            txtAtch7.Text = "" : txtAtch7.Visible = False
            BtnRmv1.Visible = False : BtnRmv2.Visible = False : BtnRmv3.Visible = False : BtnRmv4.Visible = False
            BtnRmv5.Visible = False : BtnRmv6.Visible = False : BtnRmv7.Visible = False
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

    Private Sub EmailSndng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clearform()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim renderer As New clsColorToolstripRenderer
        renderer.BackColor = Me.BackColor
        ToolStrip.Renderer = renderer
    End Sub

    Private Sub txtCust_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCust.TextChanged
        Try
            obj = txtCust
            populateCust()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub populateCust()
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim ds As New DataSet

            If rdbCust.Checked = True Then
                If obj.text <> "" Then
                    cmd.Connection = Conn
                    cmd.CommandText = "Select AcCode as [Code],AcName as [Customer Name],Place,Email as [Email ID] " & _
                        "from Acmaster where AcName like '" & obj.text & "' + '%' AND GRPCODE=3"

                    da.SelectCommand = cmd
                    da.Fill(ds, "Acmaster")
                    dgCustNm.DataSource = ds.Tables("Acmaster")

                    dgCustNm.Columns(0).Visible = False
                    dgCustNm.Columns(1).Width = 300
                    dgCustNm.Columns(2).Width = 100
                    dgCustNm.Columns(3).Width = 250

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

    Private Sub dgCustNm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustNm.CellContentClick

    End Sub

    Private Sub dgCustNm_DoubleClick() Handles dgCustNm.DoubleClick
        Try
            CCode = "" : Eml = ""
            If rdbCust.Checked = True Then
                CCode = dgCustNm.CurrentRow.Cells(0).Value
                Eml = dgCustNm.CurrentRow.Cells(3).Value
                txtCust.Text = dgCustNm.CurrentRow.Cells(1).Value
            ElseIf rdbLoyaltyCust.Checked = True Then
                CCode = dgCustNm.CurrentRow.Cells(0).Value
                Eml = dgCustNm.CurrentRow.Cells(2).Value
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
                dgCust.Rows.Add(CCode, txtCust.Text, Eml)
            End If
            txtCust.Text = ""
            txtCust.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnGrpAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpAdd.Click
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim dr As OleDb.OleDbDataReader
            'Dim i As Integer

            cmd.Connection = Conn
            cmd.CommandText = "Select AcCode,AcName,Email from Acmaster where CGrpCode='" & cmbCustGrp.SelectedValue & "'"
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    'dgCust.Rows.Add()
                    'dgCust.Item(0, i).Value = dr("AcCode")
                    'dgCust.Item(1, i).Value = dr("AcName")
                    'dgCust.Item(2, i).Value = dr("Email")
                    dgCust.Rows.Add(dr("AcCode"), dr("AcName"), dr("Email"))
                    'i += 1
                End While
            End If
            cmbCustGrp.Text = ""
            cmbCustGrp.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnOpn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpn.Click
        openfile()
    End Sub

    Private Sub openfile()



        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub


        HTMLT.LoadUrl(opnfd.FileName)

    End Sub

    Private Sub btnAtch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtch.Click
        opnfd.InitialDirectory = "C:\"
        opnfd.FileName = ""
        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If txtAtch1.Text = "" Then
            txtAtch1.Visible = True
            BtnRmv1.Visible = True
            txtAtch1.Text = opnfd.FileName
        ElseIf txtAtch2.Text = "" Then
            txtAtch2.Visible = True
            BtnRmv2.Visible = True
            txtAtch2.Text = opnfd.FileName
        ElseIf txtAtch3.Text = "" Then
            txtAtch3.Visible = True
            BtnRmv3.Visible = True
            txtAtch3.Text = opnfd.FileName
        ElseIf txtAtch4.Text = "" Then
            txtAtch4.Visible = True
            BtnRmv4.Visible = True
            txtAtch4.Text = opnfd.FileName
        ElseIf txtAtch5.Text = "" Then
            txtAtch5.Visible = True
            BtnRmv5.Visible = True
            txtAtch5.Text = opnfd.FileName
        ElseIf txtAtch6.Text = "" Then
            txtAtch6.Visible = True
            BtnRmv6.Visible = True
            txtAtch6.Text = opnfd.FileName
        ElseIf txtAtch7.Text = "" Then
            txtAtch7.Visible = True
            BtnRmv7.Visible = True
            txtAtch7.Text = opnfd.FileName
            Exit Sub
        End If

        If txtAtch1.Text <> "" And txtAtch2.Text <> "" And txtAtch3.Text <> "" And txtAtch4.Text <> "" And txtAtch5.Text <> "" And txtAtch6.Text <> "" And txtAtch7.Text <> "" Then
            MsgBox("Can't attach more files", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            HTMLT.Focus()
        End If



    End Sub

    Private Sub tsbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExit.Click
        Me.Close()
    End Sub

    Private Sub BtnRmv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv1.Click
        txtAtch1.Text = "" : txtAtch1.Visible = False : BtnRmv1.Visible = False
    End Sub

    Private Sub BtnRmv2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv2.Click
        txtAtch2.Text = "" : txtAtch2.Visible = False : BtnRmv2.Visible = False
    End Sub

    Private Sub BtnRmv3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv3.Click
        txtAtch3.Text = "" : txtAtch3.Visible = False : BtnRmv3.Visible = False
    End Sub

    Private Sub BtnRmv4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv4.Click
        txtAtch4.Text = "" : txtAtch4.Visible = False : BtnRmv4.Visible = False
    End Sub

    Private Sub BtnRmv5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv5.Click
        txtAtch5.Text = "" : txtAtch5.Visible = False : BtnRmv5.Visible = False
    End Sub

    Private Sub BtnRmv6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv6.Click
        txtAtch6.Text = "" : txtAtch6.Visible = False : BtnRmv6.Visible = False
    End Sub

    Private Sub BtnRmv7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRmv7.Click
        txtAtch7.Text = "" : txtAtch7.Visible = False : BtnRmv7.Visible = False
    End Sub


    'Private Shared Function GetPageHTML(ByVal url As String) As String
    '    Dim pageHTML As String = String.Empty

    '    Dim request = DirectCast(WebRequest.Create(url), HttpWebRequest)
    '    request.Timeout = 100000
    '    Using stream = request.GetResponse().GetResponseStream()
    '        Using reader = New StreamReader(stream)
    '            pageHTML = reader.ReadToEnd()
    '        End Using
    '    End Using

    '    Return pageHTML
    'End Function


    'Private Shared Function ProcessEmbeddedHTML(ByRef processedPageHTML As String, ByVal pageHTML As String, ByVal images As List(Of String), ByVal baseURL As String) As List(Of LinkedResource)
    '    Dim resources As New List(Of LinkedResource)()
    '    For Each image As String In images
    '        Dim imageName As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
    '        pageHTML = pageHTML.Replace(image, "cid:" & imageName)
    '        Dim imagelink As LinkedResource = GetLinkedResource(image, baseURL, imageName)
    '        resources.Add(imagelink)
    '    Next
    '    processedPageHTML = pageHTML
    '    Return resources
    'End Function

    'Private Shared Function GetLinkedResource(ByVal imageURL As String, ByVal baseURL As String, ByVal imageName As String) As LinkedResource
    '    ' Turn reletiv URLs to absolute URLs
    '    Dim imageURI As Uri = Nothing
    '    If Not Uri.TryCreate(imageURL, UriKind.Absolute, imageURI) Then
    '        Uri.TryCreate(New Uri(baseURL), imageURL, imageURI)
    '    End If

    '    If imageURI Is Nothing Then
    '        Return Nothing
    '    End If

    '    Dim memoryStream As MemoryStream = Nothing
    '    Dim imagelink As LinkedResource = Nothing
    '    Using client As New WebClient()
    '        Dim myDataBuffer As Byte() = client.DownloadData(imageURI)
    '        memoryStream = New MemoryStream(myDataBuffer)
    '        imagelink = New LinkedResource(memoryStream, client.ResponseHeaders("Content-Type"))
    '    End Using

    '    imagelink.ContentId = imageName
    '    imagelink.ContentLink = New Uri("cid:" & imageName)
    '    imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64
    '    Return imagelink
    'End Function

    'Public Shared Function FindHTMLImages(ByVal HTMLText As String) As List(Of String)
    '    Dim anchorPattern As String = "(?<=img\s*\S*src\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])"
    '    Dim matches As MatchCollection = Regex.Matches(HTMLText, anchorPattern, RegexOptions.IgnorePatternWhitespace Or RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)
    '    Dim imageSources As New List(Of String)()

    '    For Each m As Match In matches
    '        Dim url As String = m.Groups("Url").Value
    '        Dim testUri As Uri = Nothing
    '        If Uri.TryCreate(url, UriKind.RelativeOrAbsolute, testUri) Then
    '            If Not imageSources.Exists(Function(s) s = testUri.ToString()) Then
    '                imageSources.Add(testUri.ToString())
    '            End If
    '        End If
    '    Next
    '    Return imageSources
    'End Function




    'Private Sub SendEmailWithResources(ByVal url As String, ByVal fromName As String, ByVal fromEmail As String, ByVal toEmail As String)
    '    Try
    '        Dim html As String = GetPageHTML(url)
    '        'html = HTMLT.HtmlDocument2.GetBody().innerHTML
    '        Dim images As List(Of String) = FindHTMLImages(html)
    '        Dim processedPageHTML As String
    '        Dim linkedResources As List(Of LinkedResource) = ProcessEmbeddedHTML(processedPageHTML, html, images, url)
    '        SendEmail(linkedResources, processedPageHTML, url, fromName, fromEmail, toEmail)
    '    Catch e As Exception
    '        Console.WriteLine(e.Message)
    '    End Try
    'End Sub

    'Private Shared Sub SendEmail(ByVal linkedResources As List(Of LinkedResource), ByVal processedPageHTML As String, ByVal messageURL As String, ByVal fromName As String, ByVal fromEmail As String, ByVal toEmail As String)
    '    Using mail As New MailMessage()
    '        mail.From = New MailAddress("vijith@relysoft.in", DeScriptRS(Firm.Name))
    '        mail.[To].Add("vijith_amar@yahoo.com")
    '        mail.Subject = "This email contains a web page"

    '        Dim txtBody As String = "See this email online here: " & messageURL
    '        Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(txtBody, Nothing, "text/plain")

    '        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(processedPageHTML, Nothing, "text/html")
    '        For Each linkedResource As LinkedResource In linkedResources
    '            htmlView.LinkedResources.Add(linkedResource)
    '        Next

    '        mail.AlternateViews.Add(plainView)
    '        mail.AlternateViews.Add(htmlView)

    '        Dim client As New SmtpClient("202.54.119.153")
    '        client.Credentials = New System.Net.NetworkCredential("vijith@relysoft.in", "reliable")
    '        client.Send(mail)
    '    End Using
    'End Sub

    'Sub DoEmail1()
    '    SendEmailWithResources("http://www.relysoft.in/services.aspx", "", "", "")
    'End Sub


    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function

    Sub DoEmail()
        Dim cmd As New OleDb.OleDbCommand
        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim palinBody As String = HTMLT.Text
            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(palinBody, Nothing, "text/plain")
            Dim htmlBody As String = HTMLT.HtmlDocument2.GetBody().innerHTML
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")
            'Dim images As List(Of String) = FindHTMLImages(html)

            Dim blnSMTP As Boolean = False
            Dim blnCC As Boolean = False
            Dim blnAttachments As Boolean = False
            Dim atch As Attachment

            cmd.Connection = Conn
            cmd.CommandText = "Select Host,PortNo,UserName,Password from Settings"
            da.SelectCommand = cmd
            da.Fill(ds, "Setting")
            dt = ds.Tables("Setting")

            Dim smtp As System.Net.Mail.SmtpClient = New SmtpClient(dt.Rows(0).Item("Host"), Val(dt.Rows(0).Item("PortNo")))

            smtp.Host = dt.Rows(0).Item("Host")

            smtp.Port = 25
            smtp.UseDefaultCredentials = False
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
                            .Subject = "v"

                            If txtAtch1.Text <> "" Then
                                atch = New Attachment(txtAtch1.Text)
                                .Attachments.Add(atch)
                            End If

                            If txtAtch2.Text <> "" Then
                                atch = New Attachment(txtAtch2.Text)
                                .Attachments.Add(atch)
                            End If

                            If txtAtch3.Text <> "" Then
                                atch = New Attachment(txtAtch3.Text)
                                .Attachments.Add(atch)
                            End If

                            If txtAtch4.Text <> "" Then
                                atch = New Attachment(txtAtch4.Text)
                                .Attachments.Add(atch)
                            End If


                            If txtAtch5.Text <> "" Then
                                atch = New Attachment(txtAtch5.Text)
                                .Attachments.Add(atch)
                            End If

                            If txtAtch6.Text <> "" Then
                                atch = New Attachment(txtAtch6.Text)
                                .Attachments.Add(atch)
                            End If

                            If txtAtch7.Text <> "" Then
                                atch = New Attachment(txtAtch7.Text)
                                .Attachments.Add(atch)
                            End If

                            'add the views
                            .AlternateViews.Add(plainView)
                            .AlternateViews.Add(htmlView)
                            '.AlternateViews.Add(imageView)
                        End With

                        smtp.Send(insMail)
                    End If
                End If
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSend.Click
        DoEmail()
    End Sub

    Private Sub tsunder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsunder.Click
        HTMLT.HtmlDocument2.ExecCommand("Underline", False, DBNull.Value)
    End Sub

    Private Sub tsbold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbold.Click
        HTMLT.HtmlDocument2.ExecCommand("bold", False, DBNull.Value)
    End Sub

    Private Sub tsitalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsitalic.Click
        HTMLT.HtmlDocument2.ExecCommand("Italic", False, DBNull.Value)
    End Sub

    Private Sub tsjc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsjc.Click
        HTMLT.HtmlDocument2.ExecCommand("JustifyCenter", False, DBNull.Value)
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsjr.Click
        HTMLT.HtmlDocument2.ExecCommand("JustifyRight", False, DBNull.Value)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsjl.Click
        HTMLT.HtmlDocument2.ExecCommand("JustifyLeft", False, DBNull.Value)
    End Sub

    Private Sub tsfont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsfont.Click
        Dim fd As FontDialog = New FontDialog()
        Dim dr As DialogResult = fd.ShowDialog()
        If dr = DialogResult.OK Then
            HTMLT.SelectionFont = fd.Font

            If (fd.Font.Bold = False And fd.Font.Italic = False And fd.Font.Underline = False) Then
                tsbold.Checked = False
                tsitalic.Checked = False
                tsunder.Checked = False
            ElseIf fd.Font.Bold = True And fd.Font.Italic = True Then
                tsbold.Checked = True
                tsitalic.Checked = True
                tsunder.Checked = False
                tsbold_Click(New Object(), EventArgs.Empty)
                tsitalic_Click(New Object(), EventArgs.Empty)
            ElseIf (fd.Font.Bold = True) Then
                tsbold.Checked = True
                tsitalic.Checked = False
                tsunder.Checked = False
                tsbold_Click(New Object(), EventArgs.Empty)
            ElseIf (fd.Font.Italic = True) Then

                tsitalic.Checked = True
                tsunder.Checked = False
                tsbold.Checked = False
                tsitalic_Click(New Object(), EventArgs.Empty)
            ElseIf (fd.Font.Underline = True) Then
                tsunder.Checked = True
                tsitalic.Checked = False
                tsbold.Checked = False
                tsunder_Click(New Object(), EventArgs.Empty)
            End If
        End If
        tsfont.Checked = False


    End Sub

    Private Sub HTMLT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLT.Click

    End Sub

    Private Sub HTMLT_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HTMLT.CursorChanged

    End Sub

    Private Sub HTMLT_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HTMLT.UpdateUI

        tsbold.Checked = (HTMLT.SelectionFont.Bold = True)
        tsunder.Checked = (HTMLT.SelectionFont.Underline = True)
        tsitalic.Checked = (HTMLT.SelectionFont.Italic = True)
        tsjc.Checked = HTMLT.SelectionAlignment = HorizontalAlignment.Center
        tsjl.Checked = HTMLT.SelectionAlignment = HorizontalAlignment.Left
        tsjr.Checked = HTMLT.SelectionAlignment = HorizontalAlignment.Right

    End Sub

    Private Sub tscolor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscolor.Click

        Dim cd As ColorDialog = New ColorDialog()
        Dim dr As DialogResult = cd.ShowDialog()
        If dr = DialogResult.OK Then
            HTMLT.SelectionForeColor = cd.Color
        End If
    End Sub


    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        HTMLT.HtmlDocument2.ExecCommand("undo", False, DBNull.Value)
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        HTMLT.HtmlDocument2.ExecCommand("redo", False, DBNull.Value)
    End Sub

    Private Sub tsbul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbul.Click

        HTMLT.HtmlDocument2.ExecCommand("InsertOrderedList", False, DBNull.Value)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opnfd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'rt.LoadFile(opnfd.FileName)
    End Sub

    Private Sub rdbLoyaltyCust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbLoyaltyCust.CheckedChanged

    End Sub
End Class