﻿Imports MySql.Data.MySqlClient
Public Class Armory2Database
    Dim armoryproc As New prozedur_armory
    Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim trinitycore1 As New Trinity_core
    Dim mangoscore As New Mangos_core
    Dim reporttext As RichTextBox = Process_Status.processreport
    Dim procstatus As New Process_Status
    Dim trinitycorecheck As New Core_Check_Trinity
    Dim mangoscorecheck As New Core_Check_Mangos
    Dim arcemucorecheck As New Core_Check_ArcEmu
    Dim arcemucore As New ArcEmu_core
    Dim xnumber As Integer = 0
    Dim xpansion As String = ""
    Dim xstring As String = ""
    Dim localeDE As New LanguageDE
    Dim localeEN As New LanguageEN
    Dim runfunction As New Functions
    Public Sub New()
        MyBase.New()

        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo(My.Settings.language)
        InitializeComponent()
    End Sub
    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click

        My.Settings.realmd = auth.Text
        My.Settings.characters = characters.Text
        My.Settings.Save()
      Main.ServerStringInfo = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=information_schema"

        If automatic.Checked = True Then
            runfunction.writelog("Connect request with automatic checked")
            If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=characters") = False Then
                If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=character") = False Then
                    runfunction.writelog("Could not find character db or connection info wrong")
                    If My.Settings.language = "de" Then
                        xlabel.Text = localeDE.armory2database_txt1
                    Else
                        xlabel.Text = localeEN.armory2database_txt1
                    End If

                Else
                    If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realmd") = False Then
                        If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realm") = False Then
                            If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=auth") = False Then
                                If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=logon") = False Then
                                    If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=op_realm") = False Then
                                        If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text) = False Then
                                            runfunction.writelog("Could find character db but not auth db")
                                            If My.Settings.language = "de" Then
                                                MsgBox(localeDE.armory2database_txt2 & vbNewLine & localeDE.armory2database_txt3, MsgBoxStyle.Critical, localeDE.armory2database_txt3)
                                            Else
                                                MsgBox(localeEN.armory2database_txt2 & vbNewLine & localeEN.armory2database_txt3, MsgBoxStyle.Critical, localeEN.armory2database_txt3)
                                            End If
                                            Exit Sub
                                        Else
                                            Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text
                                        End If
                                    Else
                                        Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=op_realm"
                                    End If
                                Else
                                    Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=logon"
                                End If
                            Else
                                Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=auth"
                            End If
                        Else
                            Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realm"
                        End If
                    Else
                        Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realmd"
                    End If
                    runfunction.writelog("Could find character db and auth db")
                    Main.ServerString = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=character"
                    Main.characterdbname = "character"
                    Main.ServerStringCheck = Main.ServerString
                    If My.Settings.language = "de" Then
                        xlabel.Text = localeDE.armory2database_txt5
                    Else
                        xlabel.Text = localeEN.armory2database_txt5
                    End If

                    optionspanel.Location = New System.Drawing.Point(0, 0)
                    connectpanel.Location = New System.Drawing.Point(4000, 4000)
                End If
            Else
                If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realmd") = False Then
                    If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realm") = False Then
                        If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=auth") = False Then
                            If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=logon") = False Then
                                If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=op_realm") = False Then
                                    If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text) = False Then
                                        If My.Settings.language = "de" Then
                                            MsgBox(localeDE.armory2database_txt2 & vbNewLine & localeDE.armory2database_txt3, MsgBoxStyle.Critical, localeDE.armory2database_txt3)
                                        Else
                                            MsgBox(localeEN.armory2database_txt2 & vbNewLine & localeEN.armory2database_txt3, MsgBoxStyle.Critical, localeEN.armory2database_txt3)
                                        End If
                                        runfunction.writelog("Could find character db but not auth db")
                                        Exit Sub
                                    Else
                                        Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text
                                    End If
                                Else
                                    Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=op_realm"
                                End If
                            Else
                                Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=logon"
                            End If
                        Else
                            Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=auth"
                        End If
                    Else
                        Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realm"
                    End If
                Else
                    Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=realmd"
                End If
                Main.ServerString = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=characters"
                Main.ServerStringCheck = Main.ServerString
                Main.characterdbname = "characters"
                runfunction.writelog("Could find character db and auth db")
                If My.Settings.language = "de" Then
                    xlabel.Text = localeDE.armory2database_txt5
                Else
                    xlabel.Text = localeEN.armory2database_txt5
                End If

                optionspanel.Location = New System.Drawing.Point(0, 0)
                connectpanel.Location = New System.Drawing.Point(4000, 4000)
            End If
        Else
            runfunction.writelog("Connect request with manually checked")
            If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & characters.Text) = True Then
                runfunction.writelog("Could find character db")
                If trytoconnect("server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text) = True Then
                    runfunction.writelog("Could find auth db")
                    Main.ServerStringRealmd = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & auth.Text
                    Main.ServerString = "server=" & address.Text & ";Port=" & port.Text & ";User id=" & user.Text & ";Password=" & password.Text & ";Database=" & characters.Text
                    Main.characterdbname = characters.Text
                    Main.ServerStringCheck = Main.ServerString
                    If My.Settings.language = "de" Then
                        xlabel.Text = localeDE.armory2database_txt5
                    Else
                        xlabel.Text = localeEN.armory2database_txt5
                    End If

                    optionspanel.Location = New System.Drawing.Point(0, 0)
                    connectpanel.Location = New System.Drawing.Point(4000, 4000)
                Else
                    runfunction.writelog("Could find character db but not auth db")
                    If My.Settings.language = "de" Then
                        MsgBox(localeDE.armory2database_txt2 & vbNewLine & localeDE.armory2database_txt3, MsgBoxStyle.Critical, localeDE.armory2database_txt3)
                    Else
                        MsgBox(localeEN.armory2database_txt2 & vbNewLine & localeEN.armory2database_txt3, MsgBoxStyle.Critical, localeEN.armory2database_txt3)
                    End If
                    Exit Sub
                End If
            Else
                runfunction.writelog("Could not find character db or login info wrong")
                If My.Settings.language = "de" Then
                    MsgBox(localeDE.armory2database_txt2 & vbNewLine & localeDE.armory2database_txt3, MsgBoxStyle.Critical, localeDE.armory2database_txt3)
                Else
                    MsgBox(localeEN.armory2database_txt2 & vbNewLine & localeEN.armory2database_txt3, MsgBoxStyle.Critical, localeEN.armory2database_txt3)
                End If
                Exit Sub
            End If
        End If
    End Sub



    Private Function trytoconnect(ByVal connectionstring As String) As Boolean
        Try
            SQLConnection.Close()
            SQLConnection.Dispose()
        Catch ex As Exception

        End Try
        SQLConnection.ConnectionString = connectionstring
        Try

            If SQLConnection.State = ConnectionState.Closed Then
                SQLConnection.Open()

                Return True


                SQLConnection.Close()
                SQLConnection.Dispose()

            Else

                SQLConnection.Close()
                SQLConnection.Dispose()
                Return False
            End If
        Catch ex As Exception
            Try
                SQLConnection.Close()
                SQLConnection.Dispose()
            Catch

            End Try
            Return False


        End Try


    End Function
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        runfunction.writelog("Standard login info call")
        address.Text = My.Settings.address
        port.Text = My.Settings.port
        user.Text = My.Settings.user
        password.Text = My.Settings.pass
    End Sub

    Private Sub Armory2Database_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        My.Settings.shellclose = True
        My.Settings.Save()
        Me.MaximumSize = Me.Size
        auth.Text = My.Settings.realmd
        characters.Text = My.Settings.characters
        trinity1.Checked = True
        Select Case My.Settings.favcore
            Case 1
                trinity1.Checked = True
            Case 2
                mangos.Checked = True
            Case 3
                arcemu.Checked = True
            Case Else
                trinity1.Checked = True
        End Select
            runfunction.writelog("Armory2Database_Load call")
    End Sub

    Private Sub connectpanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles connectpanel.Paint

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        runfunction.writelog("Armory2Database_closing call")
        Me.Close()
        Starter.Show()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If CheckBox1.Checked = False And CheckBox3.Checked = False Then
            Button4.Enabled = False
        Else
            If items.Checked = True Then
                Button4.Enabled = True
            ElseIf glyphs.Checked = True Then
                Button4.Enabled = True
            ElseIf talents.Checked = True Then
                Button4.Enabled = True
            ElseIf level.Checked = True Then
                Button4.Enabled = True
            ElseIf talents.Checked = True Then
                Button4.Enabled = True
            ElseIf alternatelevellabel.Checked = True Then
                Button4.Enabled = True
            Else
                Button4.Enabled = False
            End If
        End If
        If CheckBox3.Checked = True Then
            If accnames.Text.Length < 2 Then
                Button4.Enabled = False
            Else
                Button4.Enabled = True
            End If
        End If
    End Sub

   

    Private Sub male_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles male.CheckedChanged
        If male.Checked = True Then
            female.Checked = False
            genderstay.checked = False
        End If
    End Sub

    Private Sub female_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles female.CheckedChanged
        If female.Checked = True Then
            male.Checked = False
            genderstay.Checked = False
        End If
    End Sub

    Private Sub tbc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles tbc.CheckedChanged
        If tbc.Checked = True Then
            runfunction.writelog("TBC checked")
            Main.xpac = 2
            glyphs.Enabled = False
            classic.Checked = False
            wotlk.Checked = False
            cata.Checked = False
        End If


    End Sub

    Private Sub classic_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles classic.CheckedChanged
        If classic.Checked = True Then
            runfunction.writelog("Classic checked")
            Main.xpac = 1
            glyphs.Enabled = False
            tbc.Checked = False
            wotlk.Checked = False
            cata.Checked = False
        End If

    End Sub

    Private Sub wotlk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles wotlk.CheckedChanged
        If wotlk.Checked = True Then
            runfunction.writelog("Wotlk checked")
            Main.xpac = 3
            glyphs.Enabled = True
            tbc.Checked = False
            classic.Checked = False
            cata.Checked = False
        End If

    End Sub

    Private Sub cata_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cata.CheckedChanged
        If cata.Checked = True Then
            runfunction.writelog("Cata checked")
            Main.xpac = 4
            glyphs.Enabled = True
            tbc.Checked = False
            wotlk.Checked = False
            classic.Checked = False
        End If

    End Sub
    Public Sub button4click()
        trinitycore1.opensql()
        If Main.ausgangsformat = 1 Then

            If trinity1.Checked = True Then
                Dim xpacressource As String
                Dim xpacressource2 As String
                Select Case Main.xpac
                    Case 3
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                    Case 4
                        xpacressource = My.Resources.GEM_ID_cata
                        xpacressource2 = My.Resources.VZ_ID_cata
                    Case Else
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                End Select
                trinitycore1.spellgemtext = xpacressource
                trinitycore1.spellitemtext = xpacressource2
                Main.outputcore = "trinity1"

                For Each link As String In Main.linklist
                    xnumber += 1

                    armoryproc.prozedur(link, xnumber, False)
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                trinitycore1.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                ' trinitycore1.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then trinitycore1.additems()
                                If sockets.Checked = True Then trinitycore1.addgems()
                                If vzs.Checked = True Then trinitycore1.addenchantments()
                                If glyphs.Checked = True Then trinitycore1.addglyphs(xpansion)
                                If male.Checked = True Then trinitycore1.setgender("0")
                                If female.Checked = True Then trinitycore1.setgender("1")
                                If genderstay.Checked = True Then trinitycore1.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then trinitycore1.setlevel()
                                If alternatelevellabel.Checked = True Then trinitycore1.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then trinitycore1.setrace()
                                If playerclass.Checked = True Then trinitycore1.setclass()
                                If goldlabel.Checked = True Then trinitycore1.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        trinitycore1.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then trinitycore1.updatechars(Main.char_name)

                        If items.Checked = True Then trinitycore1.additems()
                        If sockets.Checked = True Then trinitycore1.addgems()
                        If vzs.Checked = True Then trinitycore1.addenchantments()
                        If glyphs.Checked = True Then trinitycore1.addglyphs(xpansion)
                        If male.Checked = True Then trinitycore1.setgender("0")
                        If female.Checked = True Then trinitycore1.setgender("1")
                        If genderstay.Checked = True Then trinitycore1.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then trinitycore1.setlevel()
                        If alternatelevellabel.Checked = True Then trinitycore1.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then trinitycore1.setrace()
                        If playerclass.Checked = True Then trinitycore1.setclass()
                        If goldlabel.Checked = True Then trinitycore1.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Next


            ElseIf mangos.Checked = True Then
                Main.outputcore = "mangos"
                Dim xpacressource As String
                Dim xpacressource2 As String
                Select Case Main.xpac
                    Case 3
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                    Case 4
                        xpacressource = My.Resources.GEM_ID_cata
                        xpacressource2 = My.Resources.VZ_ID_cata
                    Case Else
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                End Select
                mangoscore.spellgemtext = xpacressource
                mangoscore.spellitemtext = xpacressource2


                For Each link As String In Main.linklist
                    xnumber += 1

                    armoryproc.prozedur(link, xnumber, False)
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                mangoscore.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                ' mangoscore.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then mangoscore.additems()
                                If sockets.Checked = True Then mangoscore.addgems()
                                If vzs.Checked = True Then mangoscore.addenchantments()
                                If glyphs.Checked = True Then mangoscore.addglyphs(xpansion)
                                If male.Checked = True Then mangoscore.setgender("0")
                                If female.Checked = True Then mangoscore.setgender("1")
                                If genderstay.Checked = True Then mangoscore.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then mangoscore.setlevel()
                                If alternatelevellabel.Checked = True Then mangoscore.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then mangoscore.setrace()
                                If playerclass.Checked = True Then mangoscore.setclass()
                                If goldlabel.Checked = True Then mangoscore.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        mangoscore.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then mangoscore.updatechars(Main.char_name)

                        If items.Checked = True Then mangoscore.additems()
                        If sockets.Checked = True Then mangoscore.addgems()
                        If vzs.Checked = True Then mangoscore.addenchantments()
                        If glyphs.Checked = True Then mangoscore.addglyphs(xpansion)
                        If male.Checked = True Then mangoscore.setgender("0")
                        If female.Checked = True Then mangoscore.setgender("1")
                        If genderstay.Checked = True Then mangoscore.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then mangoscore.setlevel()
                        If alternatelevellabel.Checked = True Then mangoscore.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then mangoscore.setrace()
                        If playerclass.Checked = True Then mangoscore.setclass()
                        If goldlabel.Checked = True Then mangoscore.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Next
            ElseIf arcemu.Checked = True Then
                Main.outputcore = "arcemu"
                Dim xpacressource As String
                Dim xpacressource2 As String
                Select Case Main.xpac
                    Case 3
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                    Case 4
                        xpacressource = My.Resources.GEM_ID_cata
                        xpacressource2 = My.Resources.VZ_ID_cata
                    Case Else
                        xpacressource = My.Resources.GEM_ID_wotlk
                        xpacressource2 = My.Resources.VZ_ID_wotlk
                End Select
                arcemucore.spellgemtext = xpacressource
                arcemucore.spellitemtext = xpacressource2


                For Each link As String In Main.linklist
                    xnumber += 1

                    armoryproc.prozedur(link, xnumber, False)
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                arcemucore.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                ' arcemucore.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then arcemucore.additems()
                                If sockets.Checked = True Then arcemucore.addgems()
                                If vzs.Checked = True Then arcemucore.addenchantments()
                                If glyphs.Checked = True Then arcemucore.addglyphs(xpansion)
                                If male.Checked = True Then arcemucore.setgender("0")
                                If female.Checked = True Then arcemucore.setgender("1")
                                If genderstay.Checked = True Then arcemucore.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then arcemucore.setlevel()
                                If alternatelevellabel.Checked = True Then arcemucore.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then arcemucore.setrace()
                                If playerclass.Checked = True Then arcemucore.setclass()
                                If goldlabel.Checked = True Then arcemucore.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        arcemucore.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then arcemucore.updatechars(Main.char_name)

                        If items.Checked = True Then arcemucore.additems()
                        If sockets.Checked = True Then arcemucore.addgems()
                        If vzs.Checked = True Then arcemucore.addenchantments()
                        If glyphs.Checked = True Then arcemucore.addglyphs(xpansion)
                        If male.Checked = True Then arcemucore.setgender("0")
                        If female.Checked = True Then arcemucore.setgender("1")
                        If genderstay.Checked = True Then arcemucore.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then arcemucore.setlevel()
                        If alternatelevellabel.Checked = True Then arcemucore.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then arcemucore.setrace()
                        If playerclass.Checked = True Then arcemucore.setclass()
                        If goldlabel.Checked = True Then arcemucore.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Next

            Else

            End If

        Else
            If trinity1.Checked = True Then
                Main.outputcore = "trinity1"

                Do
                    Dim ciu As New CIUFile
                    ciu.readspecial(Main.cuisets)
                    Main.cuisets -= 1
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                trinitycore1.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                '  trinitycore1.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then trinitycore1.additems()
                                If sockets.Checked = True Then trinitycore1.addgems()
                                If vzs.Checked = True Then trinitycore1.addenchantments()
                                If glyphs.Checked = True Then trinitycore1.addglyphs(xpansion)
                                If male.Checked = True Then trinitycore1.setgender("0")
                                If female.Checked = True Then trinitycore1.setgender("1")
                                If genderstay.Checked = True Then trinitycore1.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then trinitycore1.setlevel()
                                If alternatelevellabel.Checked = True Then trinitycore1.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then trinitycore1.setrace()
                                If playerclass.Checked = True Then trinitycore1.setclass()
                                If goldlabel.Checked = True Then trinitycore1.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        trinitycore1.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then trinitycore1.updatechars(Main.char_name)
                        ' If namechange1.Checked = True Then trinitycore1.requestnamechange(Main.char_name)
                        If items.Checked = True Then trinitycore1.additems()
                        If sockets.Checked = True Then trinitycore1.addgems()
                        If vzs.Checked = True Then trinitycore1.addenchantments()
                        If glyphs.Checked = True Then trinitycore1.addglyphs(xpansion)
                        If male.Checked = True Then trinitycore1.setgender("0")
                        If female.Checked = True Then trinitycore1.setgender("1")
                        If genderstay.Checked = True Then trinitycore1.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then trinitycore1.setlevel()
                        If alternatelevellabel.Checked = True Then trinitycore1.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then trinitycore1.setrace()
                        If playerclass.Checked = True Then trinitycore1.setclass()
                        If goldlabel.Checked = True Then trinitycore1.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Loop Until Main.cuisets = 0



            ElseIf mangos.Checked = True Then
                Main.outputcore = "mangos"


                Do
                    Dim ciu As New CIUFile
                    ciu.readspecial(Main.cuisets)
                    Main.cuisets -= 1
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                mangoscore.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                '  mangoscore.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then mangoscore.additems()
                                If sockets.Checked = True Then mangoscore.addgems()
                                If vzs.Checked = True Then mangoscore.addenchantments()
                                If glyphs.Checked = True Then mangoscore.addglyphs(xpansion)
                                If male.Checked = True Then mangoscore.setgender("0")
                                If female.Checked = True Then mangoscore.setgender("1")
                                If genderstay.Checked = True Then mangoscore.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then mangoscore.setlevel()
                                If alternatelevellabel.Checked = True Then mangoscore.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then mangoscore.setrace()
                                If playerclass.Checked = True Then mangoscore.setclass()
                                If goldlabel.Checked = True Then mangoscore.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        mangoscore.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then mangoscore.updatechars(Main.char_name)
                        ' If namechange1.Checked = True Then mangoscore.requestnamechange(Main.char_name)
                        If items.Checked = True Then mangoscore.additems()
                        If sockets.Checked = True Then mangoscore.addgems()
                        If vzs.Checked = True Then mangoscore.addenchantments()
                        If glyphs.Checked = True Then mangoscore.addglyphs(xpansion)
                        If male.Checked = True Then mangoscore.setgender("0")
                        If female.Checked = True Then mangoscore.setgender("1")
                        If genderstay.Checked = True Then mangoscore.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then mangoscore.setlevel()
                        If alternatelevellabel.Checked = True Then mangoscore.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then mangoscore.setrace()
                        If playerclass.Checked = True Then mangoscore.setclass()
                        If goldlabel.Checked = True Then mangoscore.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Loop Until Main.cuisets = 0
            ElseIf arcemu.Checked = True Then
                Main.outputcore = "arcemu"
                Do
                    Dim ciu As New CIUFile
                    ciu.readspecial(Main.cuisets)
                    Main.cuisets -= 1
                    If CheckBox3.Checked = True Then
                        Dim sLines() As String = accnames.Lines
                        For i As Integer = 0 To sLines.Length - 1
                            xstring = sLines(i)
                            If sLines(i) = "" Then
                            Else
                                arcemucore.addchars(sLines(i), Main.char_name, namechange1.Checked)
                                '  arcemucore.updatechars(sLines(i), Main.char_name, namechange2.Checked)
                                If items.Checked = True Then arcemucore.additems()
                                If sockets.Checked = True Then arcemucore.addgems()
                                If vzs.Checked = True Then arcemucore.addenchantments()
                                If glyphs.Checked = True Then arcemucore.addglyphs(xpansion)
                                If male.Checked = True Then arcemucore.setgender("0")
                                If female.Checked = True Then arcemucore.setgender("1")
                                If genderstay.Checked = True Then arcemucore.setgender(Main.char_gender.ToString)
                                If level.Checked = True Then arcemucore.setlevel()
                                If alternatelevellabel.Checked = True Then arcemucore.setalternatelevel(alternateleveltext.Text)
                                If race.Checked = True Then arcemucore.setrace()
                                If playerclass.Checked = True Then arcemucore.setclass()
                                If goldlabel.Checked = True Then arcemucore.setgold(goldtext.Text)
                                Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                            End If

                        Next

                    End If
                    If CheckBox1.Checked = True Then
                        arcemucore.getguidfromname(Main.char_name)
                        If namechange1.Checked = True Then arcemucore.updatechars(Main.char_name)
                        ' If namechange1.Checked = True Then arcemucore.requestnamechange(Main.char_name)
                        If items.Checked = True Then arcemucore.additems()
                        If sockets.Checked = True Then arcemucore.addgems()
                        If vzs.Checked = True Then arcemucore.addenchantments()
                        If glyphs.Checked = True Then arcemucore.addglyphs(xpansion)
                        If male.Checked = True Then arcemucore.setgender("0")
                        If female.Checked = True Then arcemucore.setgender("1")
                        If genderstay.Checked = True Then arcemucore.setgender(Main.char_gender.ToString)
                        If level.Checked = True Then arcemucore.setlevel()
                        If alternatelevellabel.Checked = True Then arcemucore.setalternatelevel(alternateleveltext.Text)
                        If race.Checked = True Then arcemucore.setrace()
                        If playerclass.Checked = True Then arcemucore.setclass()
                        If goldlabel.Checked = True Then arcemucore.setgold(goldtext.Text)
                        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Character is completed!" & vbNewLine)
                    End If

                Loop Until Main.cuisets = 0

            Else

            End If
        End If
        trinitycore1.closesql()
        Process_Status.processreport.AppendText(Now.TimeOfDay.ToString & "// Transfer is completed!" & vbNewLine)
        Process_Status.Button1.Enabled = True
        Starter.Show()
        Me.Close()
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim errortext As String = ""
        If CheckBox3.Checked = True Then

            runfunction.writelog("Accountnames: " & accnames.Text)
            Dim sLines() As String = accnames.Lines
            Dim removecount As Integer
            For i As Integer = 0 To sLines.Length - 1

                If sLines(i) = "" Then
                    removecount += 1
                Else
                    If trinity1.Checked = True Then
                        trinitycore1.opensql()
                        If trinitycore1.accountexist((sLines(i)).ToUpper) = False Then errortext = errortext & "Account " & sLines(i) & " could not be found!" & vbNewLine
                        trinitycore1.closesql()
                    ElseIf mangos.Checked = True Then
                        trinitycore1.opensql()
                        If mangoscore.accountexist((sLines(i)).ToUpper) = False Then errortext = errortext & "Account " & sLines(i) & " could not be found!" & vbNewLine
                        trinitycore1.closesql()
                    Else
                        trinitycore1.opensql()
                        If arcemucore.accountexist((sLines(i)).ToUpper) = False Then errortext = errortext & "Account " & sLines(i) & " could not be found!" & vbNewLine
                        trinitycore1.closesql()
                    End If
                End If

            Next


        End If
        If Not errortext = "" Then
            MsgBox("The following errors occurred:" & vbNewLine & vbNewLine & errortext, MsgBoxStyle.Critical, "Attention!")
            Exit Sub
        End If

        If classic.Checked = False Then
            If tbc.Checked = False Then
                If wotlk.Checked = False Then
                    If cata.Checked = False Then
                        If My.Settings.language = "de" Then
                            MsgBox(localeDE.armory2database_txt6, MsgBoxStyle.Critical, localeDE.armory2database_txt7)

                        Else
                            MsgBox(localeEN.armory2database_txt6, MsgBoxStyle.Critical, localeEN.armory2database_txt7)

                        End If
                        Exit Sub
                    End If
                End If
            End If

        End If
        runfunction.writelog("Start corecheck request")
        Process_Status.Show()
        Application.DoEvents()
        xnumber = 0
        xpansion = "wotlk"
        xstring = ""
        If cata.Checked = True Then
            xpansion = "cata"
        ElseIf wotlk.Checked = True Then
            xpansion = "wotlk"
        ElseIf tbc.Checked = True Then
            xpansion = "tbc"
        ElseIf classic.Checked = True Then
            xpansion = "classic"
        Else
            If My.Settings.language = "de" Then
                MsgBox(localeDE.armory2database_txt6, MsgBoxStyle.Critical, localeDE.armory2database_txt7)
            Else
                MsgBox(localeEN.armory2database_txt6, MsgBoxStyle.Critical, localeEN.armory2database_txt7)
            End If
        End If
        If trinity1.Checked = True Then
            trinitycorecheck.begincheck(14)
        ElseIf mangos.Checked = True Then
            mangoscorecheck.begincheck(14)
        Else
            arcemucorecheck.begincheck(14)
        End If




    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            runfunction.writelog("Checkbox3 checked")
            CheckBox1.Checked = False
        End If

    End Sub

    

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            runfunction.writelog("Checkbox1 checked")
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub items_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles items.CheckedChanged
        If items.Checked = True Then
            sockets.Enabled = True
            vzs.Enabled = True
        Else
            sockets.Enabled = False
            vzs.Enabled = False
            sockets.Checked = False
            vzs.Checked = False
        End If
    End Sub

    Private Sub namechange1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles namechange1.CheckedChanged
        If namechange1.Checked = True Then
            namechange2.Checked = False

        Else
            namechange2.Checked = True
        End If
    End Sub

    Private Sub namechange2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles namechange2.CheckedChanged
        If namechange2.Checked = True Then
            namechange1.Checked = False

        Else
            namechange1.Checked = True
        End If
    End Sub

    Private Sub optionspanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles optionspanel.Paint

    End Sub

    Private Sub trinity1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles trinity1.CheckedChanged
        If trinity1.Checked = True Then runfunction.writelog("Trinity checked")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        runfunction.writelog("Armory2Database_closing call")
        Me.Close()
        Starter.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        items.Checked = True
        sockets.Checked = True
        vzs.Checked = True
        glyphs.Checked = True
        talents.Checked = True
        level.Checked = True
        race.Checked = True
        playerclass.Checked = True
      
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        runfunction.writelog("Set standard login info call")
        My.Settings.address = address.Text
        My.Settings.port = port.Text
        My.Settings.user = user.Text
        My.Settings.pass = password.Text
        If trinity1.Checked = True Then
            My.Settings.favcore = 1
        ElseIf mangos.Checked = True Then
            My.Settings.favcore = 2
        ElseIf arcemu.Checked = True Then
            My.Settings.favcore = 3
        Else : End If
        My.Settings.Save()
    End Sub

    Private Sub mangos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mangos.CheckedChanged
        If mangos.Checked = True Then runfunction.writelog("Mangos checked")
    End Sub

    Private Sub arcemu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arcemu.CheckedChanged
        If arcemu.Checked = True Then runfunction.writelog("ArcEmu checked")
    End Sub

    Private Sub automatic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub genderstay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles genderstay.CheckedChanged
        If genderstay.Checked = True Then
            female.Checked = False
            male.Checked = False
        End If
    End Sub
End Class