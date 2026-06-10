Imports System.Runtime.InteropServices
Module Amruth_II_R
    Public Sqlsvrname As String
    Public DbName As String
    Public SysDt As Date
    Public Conn As New System.Data.OleDb.OleDbConnection
    Public DateFormat As String
    Public DateMask As String
    Public DateBlank As String
    Public nodeName As String
    Public UsrName As String
    Public UsrNameFull As String
    Public UserLocked As New List(Of String)()
    Public ComLocked As New List(Of String)()

    'Public sqlsvrname As String
    Public CustGrpcode As String
    Public SupGrpcode As String
    Public CashGrpCode As String
    Public delrec As Boolean
    Public ShortExpDays As Long
    Public ExpiryList As String
    Public SysInfo As System.Globalization.DateTimeFormatInfo
    Public Culture As System.Globalization.CultureInfo

    Private Declare Unicode Function NetRemoteTOD Lib "netapi32" ( _
      <MarshalAs(UnmanagedType.LPWStr)> ByVal ServerName As String, _
      ByRef BufferPtr As IntPtr) As Integer
    Private Declare Function NetApiBufferFree Lib _
      "netapi32" (ByVal Buffer As IntPtr) As Integer
    Public connstr As String

    Public PRGID As String = "I"
    Public WorkShift As Integer
    Public WCode As String
    Public cmdtimeout As Long = 480
    Public histno As Long
    Public histdt As Date
    Public histtype As String
    Public ClientId As String

    Public PopsConn As New System.Data.SqlClient.SqlConnection
    Public RegChecked As Boolean

    Public Enum PrintOutput As Byte
        ToPrinter = 1
        ToWindow = 2
        ToFile = 3
    End Enum

    Public Function CheckUserLocked(ByVal rgt As String, Optional ByVal FLG As Boolean = False, Optional ByVal dt As Date = Nothing) As Boolean
        Dim cmd As New OleDb.OleDbCommand

        If UserLocked.Contains(rgt) Then
            If FLG = False Then MsgBox("No user rights..", vbInformation)
            Return False
            Exit Function
        End If

        If ComLocked.Contains(rgt) Then
            If FLG = False Then MsgBox("No computer rights..", vbInformation)
            Return False
            Exit Function
        End If
        Dim da As Long = 0
        Dim cda As Long = 0
        cmd.CommandText = ""

        Select Case rgt
            Case "Edit Sales"
                da = LoginRights.SaEditDays
                cda = ComputerRights.SaEditDays
            Case "Edit Purchase"
                da = LoginRights.PuEditDays
                cda = ComputerRights.PuEditDays
            Case "Edit Sales Return"
                da = LoginRights.SrEditDays
                cda = ComputerRights.SrEditDays
            Case "Edit Purchase Return"

                da = LoginRights.PrEditDays
                cda = ComputerRights.PrEditDays
            Case "Edit Orders"
                da = LoginRights.OrdEditDays
                cda = ComputerRights.OrdEditDays
        End Select

        If da <> 0 Then
            If System.Math.Abs(DateDiff("d", SysDt, dt)) >= da Then
                If FLG = False Then MsgBox("No user rights..", vbInformation)
                Return False
                Exit Function
            End If
        End If

        If cda <> 0 Then
            If System.Math.Abs(DateDiff("d", SysDt, dt)) >= cda Then
                If FLG = False Then MsgBox("No Computer rights..", vbInformation)
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Structure TIME_OF_DAY_INFO
        Dim tod_elapsedt As Integer
        Dim tod_msecs As Integer
        Dim tod_hours As Integer
        Dim tod_mins As Integer
        Dim tod_secs As Integer
        Dim tod_hunds As Integer
        Dim tod_timezone As Integer
        Dim tod_tinterval As Integer
        Dim tod_day As Integer
        Dim tod_month As Integer
        Dim tod_year As Integer
        Dim tod_weekday As Integer
    End Structure

    Public Firm As FirmData

    Public Structure FirmData
        Dim Name As String
        Dim Addr1 As String
        Dim Addr2 As String
        Dim Addr3 As String
        Dim Place As String
        Dim Pin As String
        Dim Phone1 As String
        Dim Phone2 As String
        Dim Phone3 As String
        Dim Phone4 As String
        Dim Phone5 As String
        Dim Fax1 As String
        Dim Fax2 As String
        Dim TIN As String
        Dim CST As String
        Dim Website As String
        Dim EMail As String
        Dim PAN As String
        Dim ProductCode As String
        Dim FirmID As String
        Dim BranchID As String
        Dim Juri As String
        Dim ContPerson As String
        Dim TechPerson As String
        Dim GroupName As String
        Dim LicNo1 As String
        Dim LicNo2 As String
        Dim LicNo3 As String
        Dim GodName As String
        Dim POPSServer As String
        Dim POPSDBName As String
        Dim POPSUserID As String
        Dim POPSClientID As String
        Dim POPSPassword As String
    End Structure

    Public Structure StrRights
        Dim SaEditDays As Long
        Dim SrEditDays As Long
        Dim PuEditDays As Long
        Dim PrEditDays As Long
        Dim OrdEditDays As Long
        Dim SaAddLmt As Double
        Dim SaLessLmt As Double
        Dim SrAddLmt As Double
        Dim SrLessLmt As Double
        Dim PuAddlmt As Double
        Dim PuLessLmt As Double
        Dim SaDiscLmt As Double
        Dim SaAmtForDisc As Double
        Dim SaDiscLmt2 As Double
        Dim SaAmtForDisc2 As Double
    End Structure

    Public LoginRights As StrRights
    Public ComputerRights As StrRights

    Public OurUId As String
    Public OurPwrd As String

    Public Sub mainw()
        Dim logform As New Login
        logform.ShowDialog()
    End Sub

    Public Function ExpDateCheck(ByVal Objdt As MaskedTextBox, ByVal allowexp As Boolean, Optional ByVal showmsg As Boolean = True) As Boolean
        Dim dt1, dt, vij
        Dim ttp As New ToolTip()

        Objdt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        dt1 = Trim(Objdt.Text)
        Objdt.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        dt = Objdt.Text

        If Len(dt1) = 4 And Val(Microsoft.VisualBasic.Left(dt1, 2)) <= 12 Then
            vij = "01/" & (Microsoft.VisualBasic.Left(dt1, 2)) & "/" & (Microsoft.VisualBasic.Right(dt1, 2))
            Dim tmpdt As Date = Date.ParseExact(vij, "dd/mm/yy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            tmpdt = tmpdt.AddMonths(Val(Microsoft.VisualBasic.Left(dt1, 2)))
            tmpdt = tmpdt.AddDays(-1)
            Objdt.Text = tmpdt
        End If

        If Microsoft.VisualBasic.Right(Objdt.Text, 2) = "__" Then
            vij = Mid(Objdt.Text, 1, (Microsoft.VisualBasic.Len(Objdt.Text) - 2))
            If IsDate(vij) Then
                Objdt.Text = Format(CDate(vij), DateFormat)
            End If
        End If

        If Not IsDate(Objdt.Text) And Objdt.Text <> DateBlank Then
            Objdt.Clear()
            ttp.ToolTipIcon = ToolTipIcon.Error
            ttp.UseAnimation = True
            ttp.UseFading = True
            'objdt.

            Dim p1 As Point = Objdt.PointToScreen(New Point(0, 0))

            ttp.SetToolTip(Objdt, "")
            If showmsg Then
                ttp.Show("Invalid Expiry Date.. ", Objdt.FindForm, p1.X + Objdt.Width, p1.Y - Objdt.Height, 1000)
            End If
            ExpDateCheck = False
            Exit Function

        ElseIf Objdt.Text <> "__/__/____" And IsDate(Objdt.Text) Then

            If CDate(Objdt.Text) <= SysDt Then

                ttp.ToolTipIcon = ToolTipIcon.Error
                ttp.UseAnimation = True
                ttp.UseFading = True

                Dim p1 As Point = Objdt.PointToScreen(New Point(0, 0))

                ttp.SetToolTip(Objdt, "")
                If showmsg Then
                    ttp.Show("Product Already Expired.. ", Objdt.FindForm, p1.X + Objdt.Width, p1.Y - Objdt.Height, 1000)
                End If
                If allowexp Then
                    ExpDateCheck = True
                Else
                    ExpDateCheck = False
                    Objdt.Clear()
                End If

                Exit Function
            End If
        End If
        ExpDateCheck = True

    End Function

    Public Function DateCheck(ByVal Objdt As MaskedTextBox, ByVal blnk As Boolean) As Boolean
        Dim ttp As New ToolTip()
        Dim dts, dt1, dt As String

        Objdt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        dt1 = Trim(Objdt.Text)
        Objdt.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        dt = Objdt.Text

        If UCase(Microsoft.VisualBasic.Right(DateFormat, 2)) = "YY" Then
            If Microsoft.VisualBasic.Right(Objdt.Text, 2) = "__" Then
                dts = Mid(Objdt.Text, 1, (Microsoft.VisualBasic.Len(Objdt.Text) - 2))
                If IsDate(dts) Then
                    Objdt.Text = Format(CDate(dts), DateFormat)
                End If
            End If
        End If

        If Not IsDate(Objdt.Text) And Objdt.Text <> DateBlank Then
            Objdt.Clear()

            ttp.ToolTipIcon = ToolTipIcon.Error
            ttp.UseAnimation = True
            ttp.UseFading = True
            'objdt.

            Dim p1 As Point = Objdt.PointToScreen(New Point(0, 0))

            ttp.SetToolTip(Objdt, "")
            ttp.Show("Invalid  Date.. ", Objdt.FindForm, p1.X + Objdt.Width, p1.Y - Objdt.Height, 1000)

            DateCheck = False
            Exit Function
        End If

        If Not blnk And Objdt.Text = DateBlank Then
            Objdt.Clear()

            ttp.ToolTipIcon = ToolTipIcon.Error
            ttp.UseAnimation = True
            ttp.UseFading = True
            'objdt.

            Dim p1 As Point = Objdt.PointToScreen(New Point(0, 0))

            ttp.SetToolTip(Objdt, "")

            ttp.Show("Invalid Date.. ", Objdt.FindForm, p1.X + Objdt.Width, p1.Y - Objdt.Height, 1000)

            DateCheck = False
            Exit Function
        End If
        'dts = Mid(Objdt.Text, 1, (Microsoft.VisualBasic.Len(Objdt.Text) - 2))
        If IsDate(Objdt.Text) Then
            Objdt.Text = Format(CDate(Objdt.Text), DateFormat)
        Else
            Objdt.Text = DateBlank
        End If
        DateCheck = True

    End Function

    Public Sub ErrorMsg(ByVal msg As String, ByVal stk As String)
        MsgBox(msg & Chr(13) & stk)
        Exit Sub
    End Sub

    Public Function GetNetRemoteTOD(Optional ByVal strServerName As String = "") As Date
        ' Try
        Dim iRet As Integer
        Dim ptodi As IntPtr
        Dim todi As TIME_OF_DAY_INFO
        Dim dDate As Date
        If strServerName = "" Then strServerName = Sqlsvrname
        strServerName = strServerName & vbNullChar
        iRet = NetRemoteTOD(strServerName, ptodi)
        If iRet = 0 Then
            todi = CType(Marshal.PtrToStructure(ptodi, GetType(TIME_OF_DAY_INFO)),  _
              TIME_OF_DAY_INFO)
            NetApiBufferFree(ptodi)
            dDate = DateSerial(todi.tod_year, todi.tod_month, todi.tod_day) + " " + _
            TimeSerial(todi.tod_hours, todi.tod_mins - todi.tod_timezone, todi.tod_secs)
            GetNetRemoteTOD = dDate
        Else
            'MsgBox("Error retrieving time")
            GetNetRemoteTOD = Nothing
        End If
        'Catch
        'GetNetRemoteTOD = Nothing
        'MsgBox("Error in GetNetRemoteTOD: " & Err.Description)
        ' End Try
    End Function


    'Private Function CalculateProfit()

    '    If stk <> 0 Then


    '        value = System.Math.Round((stk * Val(dgRec.Item(13, n).Value)), 2)
    '        pcst = value * Val(dgRec.Item(12, n).Value) / 100
    '        totpcst = totpcst + pcst
    '        value = value + pcst     'after pcst
    '        pdis = value * Val(dgRec.Item(16, n).Value) / 100
    '        totpdis = totpdis + pdis
    '        value = value - pdis
    '        bdis = apdis * Val(txtDis.Text) / 100
    '        totbdis = totbdis + bdis
    '        value = value - bdis     'after bill disc
    '        abdis = value
    '        ptax = value * Val(dgRec.Item(15, n).Value) / 100

    '        If Val(dgRec.Item(15, n).Value) <> 0 Then
    '            fnd = 0
    '            For i = 0 To 4
    '                If Val(dgRec.Item(15, n).Value) = rtaxary(i, 0) Then                                                      
    '                    rtaxary(i, 1) = rtaxary(i, 1) + value
    '                    rptax(i, 1) = rptax(i, 1) + ptax
    '                    fnd = 1
    '                    Exit For
    '                End If
    '            Next i
    '            If fnd = 0 Then
    '                rtfamt = rtfamt + value + ptax
    '            End If
    '        Else
    '            rtfamt = rtfamt + value
    '        End If
    '        totptax = totptax + ptax
    '        value = value + ptax  'after purchase tax
    '        dgRec.Item(23, n).Value = Format(value, "0.00")
    '        totvalue = totvalue + value
    '    End If
    '    'calculating after sale profit amount
    '    sr = Val(dgRec.Item(14, n).Value)
    '    sr = sr + sr * Val(dgRec.Item(25, n).Value) / 100
    '    If dgRec.Item(27, n).Value = "Yes" Then

    '        sr = sr - Round((sr * Val(dgRec.Item(26, n).Value)) / (Val(dgRec.Item(26, n).Value) + 100), 2)
    '    End If

    '    Dim VX
    '    VX = Val(dgRec.Item(19, n).Value) + Val(dgRec.Item(20, n).Value)
    '    Svalue = sr * VX
    '    If Svalue <> 0 Then
    '        pro = Round((Svalue - value) * 100 / Svalue, 2)
    '    Else
    '        pro = 0
    '    End If
    'End Function

    Public Function RoundPaise(ByVal amtval As Double, ByVal RndPai As Integer)
        Dim tmprnd, x As Double
        Select Case RndPai
            Case -1

                x = amtval
                tmprnd = x

            Case 100
                x = Int(amtval)
                If System.Math.Abs(x - Val(amtval)) >= 0.5 Then
                    tmprnd = x + 1
                Else
                    tmprnd = x
                End If

            Case 150
                tmprnd = System.Math.Round(amtval - Int(amtval), 2)
                'If tmprnd < 0.25 Then
                '    tmprnd = Int(amtval)
                'Else
                If tmprnd <> 0 Then
                    'tmprnd = Int(amtval) + 1
                    If tmprnd < 0.5 Then
                        tmprnd = Int(amtval) + 0.5
                    ElseIf tmprnd > 0.5 Then
                        tmprnd = Int(amtval) + 1
                    Else
                        tmprnd = Val(amtval)
                    End If
                    'Else
                    '    tmprnd = Int(amtval) + 0.5
                Else
                    tmprnd = Val(amtval)
                End If
            Case 0
                tmprnd = Val(Format(amtval, "0"))
            Case 50
                tmprnd = System.Math.Round(amtval - Int(amtval), 2)
                If tmprnd < 0.25 Then
                    tmprnd = Int(amtval)
                ElseIf tmprnd >= 0.75 Then
                    tmprnd = Int(amtval) + 1
                Else
                    tmprnd = Int(amtval) + 0.5
                End If

            Case 25
                tmprnd = System.Math.Round(amtval - Int(amtval), 2)
                If tmprnd <= 0.12 Then
                    tmprnd = Int(amtval)
                ElseIf tmprnd >= 0.13 And tmprnd < 0.38 Then
                    tmprnd = Int(amtval) + 0.25
                ElseIf tmprnd >= 0.38 And tmprnd < 0.63 Then
                    tmprnd = Int(amtval) + 0.5
                ElseIf tmprnd >= 0.63 And tmprnd < 0.88 Then
                    tmprnd = Int(amtval) + 0.75
                ElseIf tmprnd >= 0.88 Then
                    tmprnd = Int(amtval) + 1
                End If
            Case Else

                x = amtval
                tmprnd = x

        End Select
        RoundPaise = tmprnd
    End Function

    Public Function RupeeConversion(ByVal amt As Double) As String
        Dim lac, thou, hun, tens, units, deci, decitens, deciunits As Integer
        Dim n, x As Double
        Dim amtstr(3, 10) As String
        Dim amttext As String

        amtstr(0, 0) = ""
        amtstr(0, 1) = "One"
        amtstr(0, 2) = "Two"
        amtstr(0, 3) = "Three"
        amtstr(0, 4) = "Four"
        amtstr(0, 5) = "Five"
        amtstr(0, 6) = "Six"
        amtstr(0, 7) = "Seven"
        amtstr(0, 8) = "Eight"
        amtstr(0, 9) = "Nine"
        amtstr(0, 10) = "Ten"
        amtstr(1, 0) = "Ten"
        amtstr(1, 1) = "Eleven"
        amtstr(1, 2) = "Twelve"
        amtstr(1, 3) = "Thirteen"
        amtstr(1, 4) = "Fourteen"
        amtstr(1, 5) = "Fifteen"
        amtstr(1, 6) = "Sixteen"
        amtstr(1, 7) = "Seventeen"
        amtstr(1, 8) = "Eighteen"
        amtstr(1, 9) = "Nineteen"
        amtstr(1, 10) = "Twenty"
        amtstr(2, 0) = ""
        amtstr(2, 1) = "Ten"
        amtstr(2, 2) = "Twenty"
        amtstr(2, 3) = "Thirty"
        amtstr(2, 4) = "Forty"
        amtstr(2, 5) = "Fifty"
        amtstr(2, 6) = "Sixty"
        amtstr(2, 7) = "Seventy"
        amtstr(2, 8) = "Eighty"
        amtstr(2, 9) = "Ninety"
        amtstr(2, 10) = "Hundred"

        amttext = ""
        n = amt
        '   Take the decimal part
        deci = val(Format(n - Int(n), "0.00")) * 100
        If Int(n) > 0 Then amttext = "Rupees "
        '   Lakhs
        lac = Int(n / 100000)
        If lac > 0 And lac <= 10 Then amttext = amttext & amtstr(0, lac) & " Lakh"
        If (lac > 10) And (lac <= 20) Then amttext = amttext & amtstr(1, lac - 10) & " Lakh"
        If (lac > 20) Then
            amttext = amttext & amtstr(2, Int(lac / 10))
            x = lac Mod 10
            amttext = amttext & amtstr(0, x) & " Lakh"
        End If
        '   Thousands
        n = n - lac * 100000
        thou = Int(n / 1000)
        If thou > 0 And thou <= 10 Then amttext = amttext & amtstr(0, thou) & " Thousand"
        If (thou > 10) And (thou <= 20) Then amttext = amttext & " " & amtstr(1, thou - 10) & " Thousand"
        If (thou > 20) Then
            amttext = amttext & " " & amtstr(2, Int(thou / 10))
            x = thou Mod 10
            amttext = amttext & " " & amtstr(0, x) & " Thousand"
        End If
        '   Hundreds
        n = n - thou * 1000
        hun = Int(n / 100)
        If hun > 0 Then amttext = amttext & " " & amtstr(0, hun) & " Hundred"
        '   Tens
        n = n - hun * 100
        tens = Int(n / 10)
        n = n - tens * 10
        units = n
        '   twenty to ninetynine
        If tens >= 2 Then
            amttext = amttext & " " & amtstr(2, Int(tens))
            amttext = amttext & " " & amtstr(0, Int(units))
        End If
        '   ten to twenty
        If tens = 1 Then amttext = amttext & " " & amtstr(1, Int(units))
        '   one to ten
        If tens = 0 Then amttext = amttext & " " & amtstr(0, Int(units))

        '   Decimal part checking
        deci = deci
        If deci > 0 Then
            amttext = amttext & " and Paise"

            decitens = Int(deci / 10)
            deciunits = deci - decitens * 10
            If decitens >= 2 Then
                amttext = amttext & " " & amtstr(2, decitens)
                amttext = amttext & " " & amtstr(0, deciunits)
            End If
            If decitens = 1 Then amttext = amttext & " " & amtstr(1, deciunits)
            If decitens = 0 Then amttext = amttext & " " & amtstr(0, deciunits)
            amttext = amttext
        End If
        RupeeConversion = amttext & " Only."
    End Function

    Public Function DeScriptRS(ByVal Rv1 As String) As String
        Dim rv As String
        Dim r As String
        Dim m As Double
        Dim i, v As Long

        If Rv1 = "" Then
            Return ""
            Exit Function
        End If


        rv = ""
        For i = Rv1.Length To 1 Step -1
            rv = rv & Microsoft.VisualBasic.Mid(Rv1, i, 1)
        Next

        Rv1 = ""
        For i = 1 To rv.Length
            r = Microsoft.VisualBasic.Mid(rv, i, 1)
            m = i Mod 2
            If m <> 0 Then
                v = Asc(r) - 98
            Else
                v = Asc(r) - 85
            End If
            Rv1 = Rv1 & Chr(v)
        Next
        Return Rv1
    End Function

    Public Sub ShowGenericInfo(ByVal cd As String)
        Dim dr As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand
        Dim RT1 As New RichTextBox
        Dim RT2 As New RichTextBox
        Dim RT3 As New RichTextBox

        Dim da As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        Dim rtf As String
        Dim rt As String
        cmd.Connection = Conn
        cmd.CommandText = "select * from product where prdcode=""" & cd & """"
        dr = cmd.ExecuteReader
        dr.Read()

        cmd2.Connection = Conn
        cmd2.CommandText = "Select WithHeader from Settings"
        da.SelectCommand = cmd2
        da.Fill(ds, "Setting")
        dt = ds.Tables("Setting")

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\MailHeader.jpg") Then
            Dim img As Image
            img = Image.FromFile(Application.StartupPath & "\MailHeader.jpg")
            Clipboard.SetDataObject(img)
            Dim tempDF As DataFormats.Format
            tempDF = DataFormats.GetFormat(DataFormats.Bitmap)
            If RT2.CanPaste(tempDF) Then
                RT2.Paste(tempDF)
                RT2.SelectionAlignment = HorizontalAlignment.Center
            End If
        End If
        'RT3.Text = DeScriptRS(Firm.Name) & " - " & DeScriptRS(Firm.Place) & Chr(13) '& "CHEMIST & DRUGIST" & Chr(13)
        'RT3.SelectAll()
        'RT3.SelectionAlignment = HorizontalAlignment.Center
        ''Dim fnt1 As New Font(RT3.SelectionFont, RT3.SelectionFont.Style Xor FontStyle.Underline)
        'RT3.SelectionFont = New Font("Courier New", 20, FontStyle.Bold)
        'RT2.Select(RT2.TextLength, 0)
        'RT2.SelectedRtf = RT3.SelectedRtf
        If IsDBNull(dt.Rows(0).Item("WithHeader")) = False Then
            If dt.Rows(0).Item("WithHeader") = True Then
                RT3.Text = Chr(13) & DeScriptRS(Firm.Name) & " - " & DeScriptRS(Firm.Place) & Chr(13) '& "CHEMIST & DRUGIST" & Chr(13)
                RT3.SelectAll()
                RT3.SelectionAlignment = HorizontalAlignment.Center
                'Dim fnt1 As New Font(RT3.SelectionFont, RT3.SelectionFont.Style Xor FontStyle.Underline)
                RT3.SelectionFont = New Font("Courier New", 20, FontStyle.Bold)
                RT2.Select(RT2.TextLength, 0)
                RT2.SelectedRtf = RT3.SelectedRtf

                RT3.Text = "CHEMIST & DRUGIST" & Chr(13)
                RT3.SelectAll()
                RT3.SelectionAlignment = HorizontalAlignment.Center
                'Dim fnt1 As New Font(RT3.SelectionFont, RT3.SelectionFont.Style Xor FontStyle.Underline)
                RT3.SelectionFont = New Font("Courier New", 18, FontStyle.Bold)
                RT2.Select(RT2.TextLength, 0)
                RT2.SelectedRtf = RT3.SelectedRtf

                RT3.Text = "PATIENT INFORMATION LEAFLET" & Chr(13) & Chr(13)
                RT3.SelectAll()
                RT3.SelectionAlignment = HorizontalAlignment.Center
                'Dim fnt1 As New Font(RT3.SelectionFont, RT3.SelectionFont.Style Xor FontStyle.Underline)
                RT3.SelectionFont = New Font("Courier New", 18, FontStyle.Bold)
                RT2.Select(RT2.TextLength, 0)
                RT2.SelectedRtf = RT3.SelectedRtf
            Else
                RT3.Text = Chr(13)
                RT3.SelectAll()
                RT3.SelectionAlignment = HorizontalAlignment.Center
                RT2.Select(RT2.TextLength, 0)
                RT2.SelectedRtf = RT3.SelectedRtf
            End If
        End If
        RT3.Text = Chr(13) & dr("prdname") '& " " & dr("case1")
        RT3.SelectAll()
        RT3.SelectionFont = New Font("Courier New", 16, FontStyle.Bold)
        RT3.SelectionColor = Color.Blue
        'Dim fnt As New Font(RT3.SelectionFont, RT3.SelectionFont.Style Xor FontStyle.Underline)
        'RT3.SelectionFont = fnt
        RT2.Select(RT2.TextLength, 0)
        RT2.SelectedRtf = RT3.SelectedRtf

        RT3.Text = Chr(13) & Chr(13)
        RT3.SelectAll()
        For i = 1 To 5
            cmd2.CommandText = "select gen from generic where gencode=" & dr.Item("gencode" & i)
            cmd2.Connection = Conn
            rt = (cmd2.ExecuteScalar & "")
            RT1.Rtf = rt
            RT1.SelectAll()
            RT2.Select(RT2.TextLength, 0)
            RT2.SelectedRtf = RT3.SelectedRtf
            RT2.Select(RT2.TextLength, 0)
            RT2.SelectedRtf = RT1.SelectedRtf
        Next
        GenericPrint.rt.Rtf = RT2.Rtf
        GenericPrint.MdiParent = Main
        GenericPrint.Height = Main.Height
        GenericPrint.Width = Main.Width
        GenericPrint.Show()
    End Sub

    Public Sub FirmValues(ByVal rpt As Object)
        rpt.FirmGodName = Firm.GodName
        rpt.FirmName = Firm.Name
        rpt.FirmAddr1 = Firm.Addr1
        rpt.FirmAddr2 = Firm.Addr2
        rpt.FirmAddr3 = Firm.Addr3 '
        rpt.FirmPhone1 = Firm.Phone1
        rpt.FirmPhone2 = Firm.Phone2
        rpt.FirmPhone3 = Firm.Phone3 '
        rpt.FirmPhone4 = Firm.Phone4 '
        rpt.FirmPhone5 = Firm.Phone5 '
        rpt.FirmPlace = Firm.Place
        rpt.FirmPin = Firm.Pin
        rpt.FirmLicNo1 = Firm.LicNo1
        rpt.FirmLicNo2 = Firm.LicNo2
        rpt.FirmLicNo3 = Firm.LicNo3
        rpt.FirmTIN = Firm.TIN '
        rpt.FirmFax1 = Firm.Fax1 '
        rpt.FirmFax2 = Firm.Fax2 '
        rpt.FirmPhone3 = Firm.Phone3 '
        rpt.FirmPhone4 = Firm.Phone4 '
        rpt.FirmPhone5 = Firm.Phone5 '
        rpt.FirmAddr3 = Firm.Addr3 '
        rpt.FirmCST = Firm.CST '
        rpt.FirmWebsite = Firm.Website '
        rpt.FirmEMail = Firm.EMail '
        rpt.FirmPAN = Firm.PAN '
        rpt.FirmProductCode = Firm.ProductCode '
        rpt.FirmFirmID = Firm.FirmID '
        rpt.FirmBranchID = Firm.BranchID '
        rpt.FirmJuri = Firm.Juri '
        rpt.FirmContPerson = Firm.ContPerson '
        rpt.FirmGroupName = Firm.GroupName '
    End Sub

    Public Function CheckConnection() As Boolean
        Dim cmd As New OleDb.OleDbCommand
        Main.Cursor = Cursors.WaitCursor
        CheckConnection = False
        Try
            If Conn.State <> ConnectionState.Open Then
                If Conn.State <> ConnectionState.Closed Then
                    Conn.Close()
                End If

                connstr = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=" & DbName & ";Data Source=" & Sqlsvrname & ""
                Conn.ConnectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=" & OurUId & ";password=" & OurPwrd & ";Initial Catalog=" & DbName & ";Data Source=" & Sqlsvrname & ""
                Conn.Open()
                cmd.Connection = Conn
                cmd.CommandText = "SET QUOTED_IDENTIFIER OFF"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED"
                cmd.ExecuteNonQuery()

            End If
            Main.Cursor = Cursors.Default
            CheckConnection = True

        Catch ex As Exception
            Main.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Exit Function
        End Try
        CheckConnection = True
        Main.Cursor = Cursors.Default
    End Function

    Public Function CheckPOPSConnection() As Boolean
        Dim cmd As New SqlClient.SqlCommand
        Dim dt As New DataTable
        Dim da As New SqlClient.SqlDataAdapter
        CheckPOPSConnection = False

        Main.Cursor = Cursors.WaitCursor
        Try
            If PopsConn.State <> ConnectionState.Open Then
                If PopsConn.State <> ConnectionState.Closed Then
                    PopsConn.Close()
                End If
ChkUser:
                PopsConn.ConnectionString = " Persist Security Info=False;User ID=" & DeScriptRS(Firm.POPSUserID) & ";password=" & DeScriptRS(Firm.POPSPassword) & ";Initial Catalog=" & DeScriptRS(Firm.POPSDBName) & ";Data Source=" & DeScriptRS(Firm.POPSServer)
                PopsConn.Open()
                cmd.Connection = PopsConn
                cmd.CommandText = ("SET QUOTED_IDENTIFIER OFF")
                cmd.ExecuteNonQuery()
                cmd.CommandText = ("SET DATEFORMAT DMY")
                cmd.ExecuteNonQuery()
                cmd.CommandText = ("SET TRANSACTION ISOLATION LEVEL READ COMMITTED")
                cmd.ExecuteNonQuery()

                If Trim(PopsLogin.PasswordTextBox.Text) = "" Then
                    PopsLogin.UsernameTextBox.Text = DeScriptRS(Firm.POPSClientID)
                    PopsLogin.ShowDialog()
                    If PopsLogin.DialogResult = DialogResult.Cancel Then
                        PopsLogin.PasswordTextBox.Text = ""
                        PopsLogin.Focus()
                        PopsConn.Close()
                        Main.Cursor = Cursors.Default
                        Exit Function
                    End If

                    cmd.CommandText = "select expdt,mode,preferred,lock from users where id='" & PopsLogin.UsernameTextBox.Text & "' and password='" & PopsLogin.PasswordTextBox.Text & "'  and type='R'"
                    da.SelectCommand = cmd
                    da.Fill(dt)
                    If dt.Rows.Count = 0 Then
                        PopsLogin.PasswordTextBox.Text = ""
                        MsgBox("Invalid User/Password... Login failed...")
                        PopsConn.Close()
                        Main.Cursor = Cursors.Default
                        GoTo ChkUser
                    ElseIf dt.Rows(0).Item("lock") = True Then
                        PopsLogin.PasswordTextBox.Text = ""
                        MsgBox("Account locked...  Access Failed")
                        CheckPOPSConnection = "Account locked...  Access Failed"
                        PopsConn.Close()
                        Main.Cursor = Cursors.Default
                        Exit Function
                    ElseIf (dt.Rows(0).Item("preferred") = 0) And (SysDt > dt.Rows(0).Item("expdt")) Then
                        PopsLogin.PasswordTextBox.Text = ""
                        MsgBox("Account Expired... Login Failed")
                        CheckPOPSConnection = "Account Expired... Login Failed"
                        PopsConn.Close()
                        Main.Cursor = Cursors.Default
                        Exit Function
                    End If
                Else
                    Main.Cursor = Cursors.Default
                    CheckPOPSConnection = True
                End If

            End If
            ClientId = PopsLogin.UsernameTextBox.Text
            CheckPOPSConnection = True
            Main.Cursor = Cursors.Default
        Catch ex As Exception
            Main.Cursor = Cursors.Default
            MsgBox(ex.Message)
            Exit Function
        End Try
        CheckPOPSConnection = True
        Main.Cursor = Cursors.Default

    End Function
End Module
