Public NotInheritable Class AboutUs

    Private Sub AboutUs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.lblprdname.Text = My.Application.Info.ProductName
        Me.lblversion.Text = String.Format("Version {0}.{1} ", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Me.lblcopyright.Text = My.Application.Info.Copyright
        Me.lblcmpyname.Text = My.Application.Info.CompanyName
        Me.TxtDescription.Text = My.Application.Info.Description
        lbllicense.Text = DeScriptRS(Firm.Name)
        Tim.Start()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("www.relysoft.in")
        LinkLabel1.LinkVisited = True
    End Sub

    Dim numspaces As Integer = 0
 
    Private Sub Tim_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tim.Tick
        'If numspaces = 100 Then
        '    lblcmpyname.Text = lblcmpyname.Text.Substring(100)
        '    numspaces = 0
        'Else
        '    lblcmpyname.Text = " " & lblcmpyname.Text
        '    numspaces += 1
        'End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
