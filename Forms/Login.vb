Imports System.Drawing.Drawing2D

Public Class Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim cmd As New OleDb.OleDbCommand
        Dim i As Integer
        Dim dsep As String

        SysInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        Culture = System.Globalization.CultureInfo.CurrentCulture

        Dim SysDateFor As New Devices.ComputerInfo
        If SysInfo.ShortDatePattern <> "dd/MM/yyyy" And SysInfo.ShortDatePattern <> "dd/MM/yy" Then
            MsgBox("Invalid Date format...!!. Can't Continue. " & Chr(13) & _
                   "Change the System Date Format to 'dd/mm/yyyy' in Regional Settings. " & Chr(13) & _
                   "( Start -> Setting -> Control Panel ->  Date -> Short Date Style )", MsgBoxStyle.Critical)
            Me.Close()
        End If

        ReadLic()
        If UCase(txtUsrName.Text) = "RESTORE" Then
            ReadLic()
            Me.Hide()
            Restore.ShowDialog()

            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()
        OpenConnection()

        ShortExpDays = 90

        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET DATEFORMAT DMY"
        cmd.ExecuteNonQuery()


        cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED"
        cmd.ExecuteNonQuery()

        cmd.Connection = Conn

        cmd.CommandText = "Select *  from UserMaster WHERE  com=0 and flg='" & PRGID & "' and upper(USERID)=""" & UCase(txtUsrName.Text) & """"
        Dim dataredr1 As OleDb.OleDbDataReader = cmd.ExecuteReader()
        If dataredr1.HasRows Then
            dataredr1.Read()
            If UCase(dataredr1("PASWRD") & "") & "" <> UCase(PasswordTextBox.Text) Then
                MsgBox("Invalid User/Password", vbInformation)
                Conn.Close()
                dataredr1.Close()
                PasswordTextBox.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        Else
            Conn.Close()
            dataredr1.Close()
            MsgBox("Invalid User/Password", vbInformation)
            txtUsrName.Focus()
            Exit Sub
        End If
        UsrNameFull = dataredr1("username")
        LoginRights.SaAddLmt = Val(dataredr1("saaddlmt") & "")
        LoginRights.SaLessLmt = Val(dataredr1("salesslmt") & "")
        LoginRights.SaDiscLmt = Val(dataredr1("sadisclmt") & "")
        LoginRights.SaAmtForDisc = Val(dataredr1("SaAmtForDisc") & "")
        LoginRights.SaEditDays = Val(dataredr1("saeditday") & "")

        LoginRights.SaAmtForDisc2 = Val(dataredr1("SaAmtForDisc2") & "")
        LoginRights.SaDiscLmt = Val(dataredr1("sadisclmt2") & "")

        LoginRights.PuAddlmt = Val(dataredr1("puaddlmt") & "")
        LoginRights.PuLessLmt = Val(dataredr1("pulesslmt") & "")
        LoginRights.PuEditDays = Val(dataredr1("pueditday") & "")

        LoginRights.SrEditDays = Val(dataredr1("sreditday") & "")
        LoginRights.PrEditDays = Val(dataredr1("preditday") & "")
        LoginRights.OrdEditDays = Val(dataredr1("ordeditday") & "")

        '-----
        ComputerRights.SaAddLmt = Val(dataredr1("saaddlmt") & "")
        ComputerRights.SaLessLmt = Val(dataredr1("salesslmt") & "")
        ComputerRights.SaDiscLmt = Val(dataredr1("sadisclmt") & "")
        ComputerRights.SaAmtForDisc = Val(dataredr1("SaAmtForDisc") & "")
        ComputerRights.SaEditDays = Val(dataredr1("saeditday") & "")
        ComputerRights.SaAmtForDisc2 = Val(dataredr1("SaAmtForDisc2") & "")
        ComputerRights.SaDiscLmt2 = Val(dataredr1("sadisclmt2") & "")

        ComputerRights.PuAddlmt = Val(dataredr1("puaddlmt") & "")
        ComputerRights.PuLessLmt = Val(dataredr1("pulesslmt") & "")
        ComputerRights.PuEditDays = Val(dataredr1("pueditday") & "")

        ComputerRights.SrEditDays = Val(dataredr1("sreditday") & "")
        ComputerRights.PrEditDays = Val(dataredr1("preditday") & "")
        ComputerRights.OrdEditDays = Val(dataredr1("ordeditday") & "")

        dataredr1.Close()
        nodeName = Environment.MachineName.ToString()
        UsrName = txtUsrName.Text

        cmd.CommandText = "Select rights from userlocked WHERE flg='" & PRGID & "' and upper(USERID)=""" & UCase(txtUsrName.Text) & """"
        dataredr1 = cmd.ExecuteReader
        If dataredr1.HasRows Then
            Do While dataredr1.Read
                UserLocked.Add(dataredr1(0))
            Loop
        End If
        dataredr1.Close()

        cmd.CommandText = "Select rights from userlocked WHERE flg='" & PRGID & "' and upper(USERID)=""" & UCase(nodeName) & """"
        dataredr1 = cmd.ExecuteReader
        If dataredr1.HasRows Then
            Do While dataredr1.Read
                ComLocked.Add(dataredr1(0))
            Loop
        End If
        dataredr1.Close()

        cmd.CommandText = "Select * from Settings "
        Dim dataredr As OleDb.OleDbDataReader = cmd.ExecuteReader()
        If dataredr.HasRows Then
            dataredr.Read()
            SysDt = dataredr.Item("sysdt")
            CustGrpcode = dataredr.Item("accustgrp")
            SupGrpcode = dataredr.Item("acsupgrp")
        End If
        DateFormat = SysInfo.ShortDatePattern
        DateMask = ""

        DateBlank = ""
        nodeName = My.Computer.Name
        dsep = SysInfo.DateSeparator
        For i = 1 To Len(DateFormat)
            If Mid(DateFormat, i, 1) <> dsep Then
                DateMask = DateMask & "A"
                DateBlank = DateBlank & "_"
            Else
                DateMask = DateMask & Mid(DateFormat, i, 1)

                DateBlank = DateBlank & Mid(DateFormat, i, 1)
            End If
        Next

        Main.Text = Application.ProductName '& "   Ver " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor

        Me.Cursor = Cursors.WaitCursor
        dataredr.Close()
        cmd.Connection = Conn
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = "SELECT TOP 50 Product.PrdName, Product.case1, Batch.Batch, Batch.ExDt, Batch.Stock, Acmaster.AcName AS sup " & _
        '                ", Acmaster.Place FROM Product INNER JOIN Batch ON Product.PrdCode = Batch.PrdCode INNER JOIN  Acmaster " & _
        '                "ON Batch.Supcode = Acmaster.AcCode WHERE " & _
        '                "Batch.ExDt<='" & Format(DateAdd(DateInterval.Day, ShortExpDays, SysDt), "yyyyMMdd") & "'   and stock<>0   ORDER BY Product.PrdName, BATCH.EXDT desc "

        'dataredr = cmd.ExecuteReader()
        'cmd.Parameters.Clear()
        'ExpiryList = ""
        'If dataredr.HasRows Then
        '    ExpiryList = "Short Expiry List  "
        '    While dataredr.Read()
        '        ExpiryList = ExpiryList + "  -  " + dataredr("PrdName") & " " & Format(dataredr("Stock"), "0") & " " & dataredr("case1") & " (" & dataredr("batch") & " " & dataredr("exdt") & " " & dataredr("sup") & ") "
        '    End While

        'End If
        'dataredr.Close()
        cmd.CommandText = "select  workshift from settings"
        WorkShift = cmd.ExecuteScalar

        Me.Hide()
        Me.Cursor = Cursors.Default
        Main.Show()
        Me.Close()

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Conn.Close()
        Me.Close()
    End Sub

    Private Sub txtUsrName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsrName.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsrName.TextChanged

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ReadLic()
        Dim ini As New Inifile(Application.StartupPath & "\Reliable.lic")
        Dim tmpstr As String
        Dim x As Long

        tmpstr = ini.GetString("Setting", "FirmName", "firmname")

        If tmpstr <> "" Then
            Firm.Name = tmpstr
        End If


        tmpstr = ini.GetString("Setting", "Addr1", "addr1")
        If tmpstr <> "" Then
            Firm.Addr1 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Addr2", "addr2")
        If tmpstr <> "" Then
            Firm.Addr2 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Addr3", "addr3") & ""
        If tmpstr <> "" Then
            Firm.Addr2 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Place", "Place")
        If tmpstr <> "" Then
            Firm.Place = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Pin", "Pin")
        If tmpstr <> "" Then
            Firm.Pin = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Phone1", "Ph1")
        If tmpstr <> "" Then
            Firm.Phone1 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Phone2", "Ph2")
        If tmpstr <> "" Then
            Firm.Phone2 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Phone3", "Ph3")
        If tmpstr <> "" Then
            Firm.Phone3 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Phone4", "Ph4")
        If tmpstr <> "" Then
            Firm.Phone4 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Phone5", "Ph5")
        If tmpstr <> "" Then
            Firm.Phone5 = (tmpstr)
        End If

        tmpstr = ini.GetString("Setting", "Fax1", "Fax1")
        If tmpstr <> "" Then
            Firm.Fax1 = (tmpstr)
        End If
        tmpstr = ini.GetString("Setting", "Fax2", "Fax2")
        If tmpstr <> "" Then
            Firm.Fax2 = (tmpstr)
        End If

        tmpstr = ini.GetString("Setting", "TIN", "TIN")
        If tmpstr <> "" Then
            Firm.TIN = (tmpstr)
        End If

        tmpstr = ini.GetString("Setting", "CST", "CST")
        If tmpstr <> "" Then
            Firm.CST = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "WebSite", "web")
        If tmpstr <> "" Then
            tmpstr = Mid(tmpstr, 1, tmpstr.Length - 1)
            Firm.Website = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Email", "Email")
        If tmpstr <> "" Then
            Firm.EMail = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "PAN", "PAN")
        If tmpstr <> "" Then
            tmpstr = Mid(tmpstr, 1, tmpstr.Length - 1)
            Firm.PAN = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "FirmID", "FirmID")
        If tmpstr <> "" Then
            tmpstr = Mid(tmpstr, 1, tmpstr.Length - 1)
            Firm.FirmID = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Branch", "Branch")
        If tmpstr <> "" Then
            Firm.BranchID = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Juri", "Juri")
        If tmpstr <> "" Then
            Firm.Juri = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "ContPerson", "ContPerson")
        If tmpstr <> "" Then
            Firm.ContPerson = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "TechPerson", "TechPerson")
        If tmpstr <> "" Then
            Firm.TechPerson = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "GroupName", "GroupName")
        If tmpstr <> "" Then
            Firm.GroupName = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "LicNo1", "LicNo1")
        If tmpstr <> "" Then
            Firm.LicNo1 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "LicNo2", "LicNo2")
        If tmpstr <> "" Then
            Firm.LicNo2 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "LicNo3", "LicNo3")
        If tmpstr <> "" Then
            Firm.LicNo3 = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "ServerName", "")
        If tmpstr <> "" Then
            Sqlsvrname = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "GodName", "")
        If tmpstr <> "" Then
            Firm.GodName = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "POPSSvr", "")
        If tmpstr <> "" Then
            Firm.POPSServer = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "PopsDB", "")
        If tmpstr <> "" Then
            Firm.POPSDBName = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "PopsID", "")
        If tmpstr <> "" Then
            Firm.POPSUserID = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "PopsCID", "")
        If tmpstr <> "" Then
            Firm.POPSClientID = tmpstr
        End If


        tmpstr = ini.GetString("Setting", "PopsPWD", "")
        If tmpstr <> "" Then
            Firm.POPSPassword = tmpstr
        End If


        tmpstr = ini.GetString("Setting", "Database", "")
        If tmpstr <> "" Then
            DbName = tmpstr
        End If

        tmpstr = ini.GetString("Setting", "Uid", "")
        If tmpstr <> "" Then
            OurUId = DeScriptRS(tmpstr)
        End If

        tmpstr = ini.GetString("Setting", "Pwrd", "")
        If tmpstr <> "" Then
            OurPwrd = DeScriptRS(tmpstr)
        End If

    End Sub


    Private Sub OpenConnection()
        Dim cmd As New OleDb.OleDbCommand
        connstr = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=" & DbName & ";Data Source=" & Sqlsvrname & ""
        Conn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=" & DbName & ";Data Source=" & Sqlsvrname & ""
        Conn.Open()
        cmd.Connection = Conn
        cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED"
        cmd.ExecuteNonQuery()

        'cmd.CommandText = "DB_MODE_SHARE_EXCLUSIVE"
        'cmd.ExecuteNonQuery()
    End Sub



    Public Sub New()

        ' This call is required by the designer.


        ' Add any initialization after the InitializeComponent() call.
        MyBase.New()
        InitializeComponent()

        'Dim intDiameter As Integer = 203
        'Me.Height = intDiameter
        'Me.Width = 303
        'Dim p As New Drawing2D.GraphicsPath()
        'p.AddEllipse(0, 0, intDiameter, intDiameter)
        'Me.Region = New Region(p)
        'Me.BackColor = Color.Red

        ''add this part
        ''Create the elliptical form
        'Dim gPath As GraphicsPath = New GraphicsPath()
        'gPath.AddEllipse(0, 0, Me.ClientSize.Width, Me.ClientSize.Height)
        'Me.Region = New Region(gPath)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub PasswordTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then System.Windows.Forms.SendKeys.Send("{TAB}")
    End Sub

    Private Sub PasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordTextBox.TextChanged

    End Sub
End Class
