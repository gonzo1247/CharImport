﻿'Copyright (C) 2011-2012 CharImport <http://sourceforge.net/projects/charimport/>
'*
'* This application is free and can be distributed.
'*
'* The class Functions provides some basic functions which are used by core classes
'*
'* Developed by Alcanmage/megasus

Imports System.Net
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Functions
    Dim reporttext As RichTextBox = Process_Status.processreport
    ' Dim SQLConnection As MySqlConnection = New MySqlConnection
    Dim characterguid As Integer
    Dim xpacressource As String
    ' Dim conn As New MySqlConnection()
    Public Function getglyphid(ByVal glyphid As Integer) As Integer
        Try
            Select Case Main.xpac
                Case 3
                    xpacressource = My.Resources.GlyphProperties_335
                Case 4
                    xpacressource = My.Resources.GlyphProperties_434
                Case Else
                    xpacressource = My.Resources.GlyphProperties_335
            End Select
            Dim zclienyx88 As New WebClient
            Dim zquellcodeyx88 As String = xpacressource
            Dim zanfangyx88 As String = "<entry>" & glyphid.ToString & "</entry><spell>"
            Dim zendeyx88 As String = "</spell>"
            Dim zquellcodeSplityx88 As String
            zquellcodeSplityx88 = Split(zquellcodeyx88, zanfangyx88, 5)(1)
            zquellcodeSplityx88 = Split(zquellcodeSplityx88, zendeyx88, 6)(0)

            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://www.wowhead.com/spell=" & zquellcodeSplityx88)
            Dim anfangyx88 As String = ",""id"":"
            Dim endeyx88 As String = ",""level"""
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)


            Return CInt(quellcodeSplityx88)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub getweapontype(ByVal itemid As Integer)
        If Not itemid = 0 Then
            Try
                Process_Status.processreport.appendText(
                    Now.TimeOfDay.ToString & "// Loading Weapontype from itemid: " & itemid & vbNewLine)
                My.Application.DoEvents()
                Dim clienyx88 As New WebClient
                Dim quellcodeyx88 As String = clienyx88.DownloadString("http://www.wowhead.com/item=" & itemid.ToString)
                Dim anfangyx88 As String = "description"" content="""
                Dim endeyx88 As String = """ /><meta"
                Dim quellcodeSplityx88 As String
                quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
                quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)

                Select Case True
                    Case quellcodeSplityx88.ToLower.Contains(" crossbow ")
                        Main.specialspells.Add("5011")
                        Main.specialskills.Add("226")
                    Case quellcodeSplityx88.ToLower.Contains(" bow ")
                        Main.specialspells.Add("264")
                        Main.specialskills.Add("45")
                    Case quellcodeSplityx88.ToLower.Contains(" gun ")
                        Main.specialspells.Add("266")
                        Main.specialskills.Add("46")
                    Case quellcodeSplityx88.ToLower.Contains(" thrown ")
                        Main.specialspells.Add("2764")
                        Main.specialspells.Add("2567")
                        Main.specialskills.Add("176")
                    Case quellcodeSplityx88.ToLower.Contains(" wands ")
                        Main.specialspells.Add("5009")
                        Main.specialspells.Add("5019")
                        Main.specialskills.Add("228")
                    Case quellcodeSplityx88.ToLower.Contains(" sword ")
                        If quellcodeSplityx88.ToLower.Contains(" one-handed ") Then
                            Main.specialspells.Add("201")
                            Main.specialskills.Add("43")
                        Else
                            Main.specialspells.Add("201")
                            Main.specialskills.Add("43")
                            Main.specialspells.Add("202")
                            Main.specialskills.Add("55")
                        End If
                    Case quellcodeSplityx88.ToLower.Contains(" dagger ")
                        Main.specialspells.Add("1180")
                        Main.specialskills.Add("173")
                    Case quellcodeSplityx88.ToLower.Contains(" axe ")
                        If quellcodeSplityx88.ToLower.Contains(" one-handed ") Then
                            Main.specialspells.Add("196")
                            Main.specialskills.Add("44")
                        Else
                            Main.specialspells.Add("197")
                            Main.specialskills.Add("44")
                            Main.specialspells.Add("196")
                            Main.specialskills.Add("142")
                        End If
                    Case quellcodeSplityx88.ToLower.Contains(" mace ")
                        If quellcodeSplityx88.ToLower.Contains(" one-handed ") Then
                            Main.specialspells.Add("198")
                            Main.specialskills.Add("54")
                        Else
                            Main.specialskills.Add("54")
                            Main.specialspells.Add("198")
                            Main.specialskills.Add("160")
                            Main.specialspells.Add("199")
                        End If
                    Case quellcodeSplityx88.ToLower.Contains(" polearm ")
                        Main.specialspells.Add("200")
                        Main.specialskills.Add("229")
                    Case quellcodeSplityx88.ToLower.Contains(" staff ")
                        Main.specialspells.Add("227")
                        Main.specialskills.Add("136")

                    Case Else

                End Select
            Catch ex As Exception
                Process_Status.processreport.appendText(
                    Now.TimeOfDay.ToString & "// Error while loading Weapontype with itemid: " & itemid & " > " &
                    ex.ToString & vbNewLine)
                My.Application.DoEvents()
            End Try
        Else

        End If
    End Sub

    Public Function getvzeffectname(ByVal vzid As Integer) As String
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://de.wowhead.com/spell=" & vzid.ToString)
            Dim anfangyx88 As String = "Enchant Item: [<span class=""q2"">"
            Dim endeyx88 As String = "</span>"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            If quellcodeSplityx88.Contains("<a href=") Then
                Dim quellcodeyx882 As String = quellcodeSplityx88
                Dim anfangyx882 As String = "<a href="
                Dim endeyx882 As String = """>"
                Dim quellcodeSplityx882 As String
                quellcodeSplityx882 = Split(quellcodeyx882, anfangyx882, 5)(1)
                quellcodeSplityx882 = Split(quellcodeSplityx882, endeyx882, 6)(0)
                quellcodeSplityx88 = quellcodeSplityx88.Replace("<a href=" & quellcodeSplityx882 & """>", "")
                If quellcodeSplityx88.Contains("</a>") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("</a>", "")

            End If
            Dim b() As Byte = Encoding.Default.GetBytes(quellcodeSplityx88)
            quellcodeSplityx88 = Encoding.UTF8.GetString(b)
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Tempo", "Tempowertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Trefferwert", "Trefferwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Ausweichen", "Ausweichwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Blockwert", "Blockwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Parieren", "Parierwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Abhärtungswert", "Abhärtungswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Waffenkundewert", "Waffenkundewertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Meisterschaft", "Meisterschaftswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("kritischer", "kritische")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungswertung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungwertung", "wertung")
            Catch ex As Exception

            End Try
            Return quellcodeSplityx88
        Catch ex As Exception

            Return ""
        End Try
    End Function
    Public Function getnamefromitemid(ByVal itemid As String) As String
        Try
            Dim dt As New DataTable()
            Dim stext As String
            If My.Settings.language = "de" Then
                stext = My.Resources.item_name_de
            Else
                stext = My.Resources.item_name_en
            End If

            Dim a() As String
            Dim strArray As String()
            a = Split(stext, vbNewLine)
            For i = 0 To UBound(a)
                strArray = a(i).Split(CChar(";"))
                If i = 0 Then
                    For Each value As String In strArray
                        dt.Columns.Add(value.Trim())
                    Next
                Else
                    Dim dr As DataRow = dt.NewRow()
                    dt.Rows.Add(strArray)
                End If
            Next i
            Dim nameresult As String = executex("itemid", itemid, dt)
            If nameresult = "-" Then
                Return "Error loading itemname"
            Else
                Return nameresult
            End If
        Catch ex As Exception
            Return "Error loading itemname"
        End Try
    End Function
    Private Function executex(ByVal field As String, ByVal isvalue As String, ByVal tempdatatable As DataTable) As String
        Try
            Dim foundRows() As DataRow
            foundRows = tempdatatable.Select(field & " = '" & isvalue & "'")
            If foundRows.Length = 0 Then
                Return "-"
            Else
                Dim i As Integer
                Dim tmpreturn As String = "-"
                For i = 0 To foundRows.GetUpperBound(0)
                    tmpreturn = (foundRows(i)(1)).ToString

                Next i
                Return tmpreturn
            End If

        Catch ex As Exception
            Return "-"
        End Try
    End Function
    Public Function getsocketeffectname(ByVal socketid As Integer) As String
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://de.wowhead.com/item=" & socketid.ToString)
            Dim anfangyx88 As String = "<span class=""q1"">"
            Dim endeyx88 As String = "</span>"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            If quellcodeSplityx88.Contains("<a href=") Then
                Dim quellcodeyx882 As String = quellcodeSplityx88
                Dim anfangyx882 As String = "<a href="
                Dim endeyx882 As String = """>"
                Dim quellcodeSplityx882 As String
                quellcodeSplityx882 = Split(quellcodeyx882, anfangyx882, 5)(1)
                quellcodeSplityx882 = Split(quellcodeSplityx882, endeyx882, 6)(0)
                quellcodeSplityx88 = quellcodeSplityx88.Replace("<a href=" & quellcodeSplityx882 & """>", "")
                If quellcodeSplityx88.Contains("</a>") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("</a>", "")

            End If
            Dim b() As Byte = Encoding.Default.GetBytes(quellcodeSplityx88)
            quellcodeSplityx88 = Encoding.UTF8.GetString(b)
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Tempo", "Tempowertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Trefferwert", "Trefferwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Ausweichen", "Ausweichwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Blockwert", "Blockwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Parieren", "Parierwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Abhärtungswert", "Abhärtungswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Waffenkundewert", "Waffenkundewertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Meisterschaft", "Meisterschaftswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("kritischer", "kritische")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungswertung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungwertung", "wertung")
            Catch ex As Exception

            End Try
            Return quellcodeSplityx88
        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Sub getimage(ByVal itemid As Integer, ByVal picbox As PictureBox)
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://wowdb.com/items/" & itemid.ToString)
            Dim anfangyx88 As String = "<img src="""
            Dim endeyx88 As String = """ alt="""" />"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            LoadImageFromUrl(quellcodeSplityx88, picbox)
        Catch ex As Exception
            picbox.Image = My.Resources.empty
        End Try
    End Sub

    Public Sub LoadImageFromUrl(ByRef url As String, ByVal pb As PictureBox)
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
        Dim img As Image = Image.FromStream(response.GetResponseStream())
        response.Close()
        pb.SizeMode = PictureBoxSizeMode.StretchImage
        pb.Image = img
    End Sub

    Public Function getnamefromid(ByVal itemid As Integer) As String

        Try
            'Dim clienyx88 As New WebClient
            'Dim quellcodeyx88 As String = clienyx88.DownloadString("http://wowdb.com/items/" & itemid.ToString)
            'Dim anfangyx88 As String = "<title>"
            'Dim endeyx88 As String = " - "
            Dim quellcodeSplityx88 As String = getnamefromitemid(itemid.ToString())
            'quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            'quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            If quellcodeSplityx88.Contains("&#x27;") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("&#x27;", "'")
            If quellcodeSplityx88.Contains("Ã¼") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("Ã¼", "ü")
            If quellcodeSplityx88.Contains("Ã¤") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("Ã¤", "ä")
            If quellcodeSplityx88.Contains("Ã¶") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("Ã¶", "ö")
            If quellcodeSplityx88.Contains("ÃŸ") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("ÃŸ", "ß")
            Return quellcodeSplityx88
        Catch ex As Exception
            Return "-"
        End Try
    End Function

    Public Function runcommand(ByVal command As String, ByVal spalte As String) As String

        Dim da As New MySqlDataAdapter(command, Main.GLOBALconn)
        Dim dt As New DataTable

        Try
            da.Fill(dt)

            Dim lastcount As Integer = CInt(Val(dt.Rows.Count.ToString))

            If Not lastcount = 0 Then

                Dim readed As String = (dt.Rows(0).Item(0)).ToString
                If readed = "DBnull" Then
                    Return ""
                Else
                    Return readed
                End If
            Else
                Return ""
            End If

        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Function returncountresults(ByVal command As String, ByVal spalte As String) As Integer
        Dim da As New MySqlDataAdapter(command, Main.GLOBALconn)
        Dim dt As New DataTable

        Try
            da.Fill(dt)

            Dim lastcount As Integer = CInt(Val(dt.Rows.Count.ToString))

            Return lastcount

        Catch ex As Exception

            Return 0
        End Try
    End Function

    Public Function returnresultwithrow(ByVal command As String, ByVal spalte As String, ByVal row As Integer) As String
        Dim da As New MySqlDataAdapter(command, Main.GLOBALconn)
        Dim dt As New DataTable

        Try
            da.Fill(dt)

            Dim lastcount As Integer = CInt(Val(dt.Rows.Count.ToString))

            If Not lastcount = 0 Then

                Dim readed As String = (dt.Rows(row).Item(0)).ToString
                If readed = "DBnull" Then
                    Return ""
                Else
                    Return readed
                End If
            Else
                Return ""
            End If

        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Function runcommandRealmd(ByVal command As String, ByVal spalte As String) As String

        Dim da As New MySqlDataAdapter(command, Main.GLOBALconnRealmd)
        Dim dt As New DataTable

        Try
            da.Fill(dt)

            Dim lastcount As Integer = CInt(Val(dt.Rows.Count.ToString))

            If Not lastcount = 0 Then
                Dim readed As String = (dt.Rows(0).Item(0)).ToString
                If readed = "DBnull" Then
                    Return ""
                Else
                    Return readed
                End If

            Else
                Return ""
            End If

        Catch ex As Exception

            Return ""
        End Try
    End Function

    Public Function normalsqlcommand(ByVal command As String, Optional ByVal showerror As Boolean = True, Optional ByVal returnerror As Boolean = False) As Boolean
        Try
            NewUser(command)
            Return False

        Catch ex As Exception
            If ex.ToString.Contains("Duplicate entry ") Then

            Else
                If showerror = True Then _
                    Process_Status.processreport.AppendText(
                        Now.TimeOfDay.ToString &
                        "> ERROR WHILE EXECUTING MYSQL COMMAND (MAYBE YOU CAN IGNORE THIS): command is: " & command &
                        "| ErrMsg is:" & ex.ToString & vbNewLine)

            End If
            If returnerror = True Then
                Return True
            Else
                Return False
            End If
        End Try
    End Function

    Public Function normalsqlcommandRealmd(ByVal command As String, Optional ByVal showerror As Boolean = True, Optional ByVal returnerror As Boolean = False) As Boolean

        Try


            NewUserRealmd(command)
            Return False

        Catch ex As Exception
            If ex.ToString.Contains("Duplicate entry ") Then

            Else
                If showerror = True Then _
                    Process_Status.processreport.AppendText(
                        Now.TimeOfDay.ToString &
                        "> ERROR WHILE EXECUTING MYSQL COMMAND (MAYBE YOU CAN IGNORE THIS): command is: " & command &
                        "| ErrMsg is:" & ex.ToString & vbNewLine)

            End If
            If returnerror = True Then
                Return True
            Else
                Return False
            End If
        End Try
    End Function

    Public Sub NewUser(ByRef SQLStatement As String)

        Dim cmd As MySqlCommand = New MySqlCommand

        With cmd
            .CommandText = SQLStatement
            .CommandType = CommandType.Text
            .Connection = Main.GLOBALconn
            ' .ExecuteNonQuery()
            Dim cres As IAsyncResult = .BeginExecuteNonQuery(Nothing, Nothing)
            .EndExecuteReader(cres)
            .EndExecuteNonQuery(cres)

        End With
    End Sub

    Public Sub NewUserRealmd(ByRef SQLStatement As String)

        Dim cmd As MySqlCommand = New MySqlCommand

        With cmd
            .CommandText = SQLStatement
            .CommandType = CommandType.Text
            .Connection = Main.GLOBALconnRealmd
            ' .ExecuteNonQuery()
            Dim cres As IAsyncResult = .BeginExecuteNonQuery(Nothing, Nothing)
            .EndExecuteReader(cres)
            .EndExecuteNonQuery(cres)


        End With
    End Sub
    Public Function geteffectnameofeffectid(ByVal effectid As Integer) As String

        Try
            Dim dt As New DataTable()
            Dim stext As String
            If My.Settings.language = "de" Then
                stext = My.Resources.enchant_name_de
            Else
                stext = My.Resources.enchant_name_en
            End If

            Dim a() As String
            Dim strArray As String()
            a = Split(stext, vbNewLine)
            For i = 0 To UBound(a)
                strArray = a(i).Split(CChar(";"))
                If i = 0 Then
                    For Each value As String In strArray
                        dt.Columns.Add(value.Trim())
                    Next
                Else
                    Dim dr As DataRow = dt.NewRow()
                    dt.Rows.Add(strArray)
                End If
            Next i
            Dim nameresult As String = executex2("effectid", effectid.ToString(), dt)
            If nameresult = "-" Then
                Return "Error loading effectname"
            Else
                Return nameresult
            End If
        Catch ex As Exception
            Return "Error loading effectname"
        End Try
    End Function
    Private Function executex2(ByVal field As String, ByVal isvalue As String, ByVal tempdatatable As DataTable) As String
        Try
            Dim foundRows() As DataRow
            foundRows = tempdatatable.Select(field & " = '" & isvalue & "'")
            If foundRows.Length = 0 Then
                Return "-"
            Else
                Dim i As Integer
                Dim tmpreturn As String = "-"
                For i = 0 To foundRows.GetUpperBound(0)
                    tmpreturn = (foundRows(i)(1)).ToString

                Next i
                Return tmpreturn
            End If

        Catch ex As Exception
            Return "-"
        End Try
    End Function
    Public Function getvzeffectname2(ByVal vzid As Integer) As String
        Process_Status.processreport.appendText(
            Now.TimeOfDay.ToString & "// Getting effectname of vzid: " & vzid & vbNewLine)
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://de.wowhead.com/spell=" & vzid.ToString)
            Dim anfangyx88 As String = "Enchant Item: [<span class=""q2"">"
            Dim endeyx88 As String = "</span>"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            If quellcodeSplityx88.Contains("<a href=") Then
                Dim quellcodeyx882 As String = quellcodeSplityx88
                Dim anfangyx882 As String = "<a href="
                Dim endeyx882 As String = """>"
                Dim quellcodeSplityx882 As String
                quellcodeSplityx882 = Split(quellcodeyx882, anfangyx882, 5)(1)
                quellcodeSplityx882 = Split(quellcodeSplityx882, endeyx882, 6)(0)
                quellcodeSplityx88 = quellcodeSplityx88.Replace("<a href=" & quellcodeSplityx882 & """>", "")
                If quellcodeSplityx88.Contains("</a>") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("</a>", "")

            End If
            Dim b() As Byte = Encoding.Default.GetBytes(quellcodeSplityx88)
            quellcodeSplityx88 = Encoding.UTF8.GetString(b)
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Tempo", "Tempowertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Trefferwert", "Trefferwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Ausweichen", "Ausweichwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Blockwert", "Blockwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Parieren", "Parierwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Abhärtungswert", "Abhärtungswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Waffenkundewert", "Waffenkundewertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Meisterschaft", "Meisterschaftswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("kritischer", "kritische")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungswertung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungwertung", "wertung")
            Catch ex As Exception

            End Try
            Return quellcodeSplityx88
        Catch ex As Exception
            Process_Status.processreport.appendText(
                Now.TimeOfDay.ToString & "> EXCEPTION WHILE GETTING EFFECTNAME FROM VZID: " & ex.ToString & vbNewLine)
            Return "error"
        End Try
    End Function

    Public Function getsocketeffectname2(ByVal socketid As Integer) As String
        Process_Status.processreport.appendText(
            Now.TimeOfDay.ToString & "// Getting effectname of socketid: " & socketid & vbNewLine)
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://de.wowhead.com/item=" & socketid)
            Dim anfangyx88 As String = "<span class=""q1"">"
            Dim endeyx88 As String = "</span>"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
            If quellcodeSplityx88.Contains("<a href=") Then
                Dim quellcodeyx882 As String = quellcodeSplityx88
                Dim anfangyx882 As String = "<a href="
                Dim endeyx882 As String = """>"
                Dim quellcodeSplityx882 As String
                quellcodeSplityx882 = Split(quellcodeyx882, anfangyx882, 5)(1)
                quellcodeSplityx882 = Split(quellcodeSplityx882, endeyx882, 6)(0)
                quellcodeSplityx88 = quellcodeSplityx88.Replace("<a href=" & quellcodeSplityx882 & """>", "")
                If quellcodeSplityx88.Contains("</a>") Then quellcodeSplityx88 = quellcodeSplityx88.Replace("</a>", "")

            End If
            Dim b() As Byte = Encoding.Default.GetBytes(quellcodeSplityx88)
            quellcodeSplityx88 = Encoding.UTF8.GetString(b)
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Tempo", "Tempowertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Trefferwert", "Trefferwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Ausweichen", "Ausweichwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Blockwert", "Blockwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Parieren", "Parierwertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("kritischer", "kritische")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Abhärtungswert", "Abhärtungswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Waffenkundewert", "Waffenkundewertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("Meisterschaft", "Meisterschaftswertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungswertung", "wertung")
            Catch ex As Exception

            End Try
            Try
                quellcodeSplityx88 = quellcodeSplityx88.Replace("wertungwertung", "wertung")
            Catch ex As Exception

            End Try
            Return quellcodeSplityx88
        Catch ex As Exception
            Process_Status.processreport.appendText(
                Now.TimeOfDay.ToString & "> ERROR WHILE GETTING EFFECTNAME OF SOCKETID: " & ex.ToString & vbNewLine)
            Return "error"
        End Try
    End Function

    Public Function getvzeffectid(ByVal effectname As String) As Integer
        Process_Status.processreport.AppendText(
            Now.TimeOfDay.ToString & "// Getting effectid of effectname: " & effectname & vbNewLine)
        Select Case Main.xpac
            Case 3
                xpacressource = My.Resources.VZ_ID_wotlk
            Case 4
                xpacressource = My.Resources.VZ_ID_cata
            Case Else
                xpacressource = My.Resources.VZ_ID_wotlk
        End Select
        Try
            Dim zclienyx88 As New WebClient
            Dim zquellcodeyx88 As String = xpacressource
            Dim zanfangyx88 As String = effectname & ";"
            Dim zendeyx88 As String = ";xxx"
            Dim zquellcodeSplityx88 As String
            zquellcodeSplityx88 = Split(zquellcodeyx88, zanfangyx88, 5)(1)
            zquellcodeSplityx88 = Split(zquellcodeSplityx88, zendeyx88, 6)(0)

            Return CInt(zquellcodeSplityx88)

        Catch ex As Exception
            Process_Status.processreport.appendText(
                Now.TimeOfDay.ToString & "> ERROR WHILE GETTING EFFECTID OF EFFECTNAME: " & ex.ToString & vbNewLine)
            Return 0
        End Try
    End Function
    Public Function getspellidfromitem(ByVal itemid As String) As Integer
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://www.wowhead.com/item=" & itemid)
            Dim anfangyx88 As String = "<a href=""/spell="
            Dim endeyx88 As String = """"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)

            Return CInt(Val(quellcodeSplityx88))
        Catch ex As Exception
            Process_Status.processreport.AppendText(
                Now.TimeOfDay.ToString & "// Error while loading spellid from itemid: " & itemid & " > " & ex.ToString &
                vbNewLine)
            My.Application.DoEvents()
            Return 0
        End Try
    End Function
    Public Function getspellnamefromid(ByVal spellid As String) As String
        Try
            Dim clienyx88 As New WebClient
            Dim quellcodeyx88 As String = clienyx88.DownloadString("http://wowdata.buffed.de/?s=" & spellid)
            Dim anfangyx88 As String = "<h1 class=""headline1"">"
            Dim endeyx88 As String = "</h1>"
            Dim quellcodeSplityx88 As String
            quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
            quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)

            Dim s As String = quellcodeSplityx88
            Dim b() As Byte = Encoding.Default.GetBytes(s)
            Dim s1 As String = Encoding.UTF8.GetString(b)

            Return s1
        Catch ex As Exception
            Process_Status.processreport.AppendText(
                Now.TimeOfDay.ToString & "// Error while spell name from spellid: " & spellid & " > " & ex.ToString &
                vbNewLine)
            My.Application.DoEvents()
            Return "Fehler"
        End Try
    End Function
    Public Function getgemeffectid(ByVal gemid As String) As Integer
        Process_Status.processreport.AppendText(
            Now.TimeOfDay.ToString & "// Getting effectid of gemid: " & gemid & vbNewLine)
        Select Case Main.xpac
            Case 3
                xpacressource = My.Resources.GEM_ID_wotlk
            Case 4
                xpacressource = My.Resources.GEM_ID_cata
            Case Else
                xpacressource = My.Resources.GEM_ID_wotlk
        End Select
        Try
            Dim zclienyx88 As New WebClient
            Dim zquellcodeyx88 As String = xpacressource
            Dim zanfangyx88 As String = gemid & ";"
            Dim zendeyx88 As String = ";xxxx"
            Dim zquellcodeSplityx88 As String
            zquellcodeSplityx88 = Split(zquellcodeyx88, zanfangyx88, 5)(1)
            zquellcodeSplityx88 = Split(zquellcodeSplityx88, zendeyx88, 6)(0)

            Return CInt(zquellcodeSplityx88)
        Catch ex As Exception
            Process_Status.processreport.appendText(
                Now.TimeOfDay.ToString & "> ERROR WHILE GETTING EFFECTID OF GEMID: " & ex.ToString & vbNewLine)
            Return 0
        End Try
    End Function

    Public Function getglyphid2(ByVal glyphid As String) As Integer
        If Not glyphid = "" And Not glyphid = " " Then
            Process_Status.processreport.AppendText(
                Now.TimeOfDay.ToString & "// Loading Glyphid from id: " & glyphid & "..." & vbNewLine)
            Select Case Main.xpac
                Case 3
                    xpacressource = My.Resources.GlyphProperties_335
                Case 4
                    xpacressource = My.Resources.GlyphProperties_434
                Case Else
                    xpacressource = My.Resources.GlyphProperties_335
            End Select
            Try
                Dim clienyx88 As New WebClient
                Dim quellcodeyx88 As String = clienyx88.DownloadString("http://wowhead.com/item=" & glyphid)
                Dim anfangyx88 As String = "<a href=""/spell="
                Dim endeyx88 As String = """ "
                Dim quellcodeSplityx88 As String
                quellcodeSplityx88 = Split(quellcodeyx88, anfangyx88, 5)(1)
                quellcodeSplityx88 = Split(quellcodeSplityx88, endeyx88, 6)(0)
                Process_Status.processreport.AppendText(
                    Now.TimeOfDay.ToString & "/// SpellId of glyph is: " & quellcodeSplityx88 & "!?" & vbNewLine)
                Dim zclienyx88 As New WebClient
                Dim zquellcodeyx88 As String = xpacressource
                Dim zanfangyx88 As String = "<spell>" & quellcodeSplityx88 & "</spell><entry2>"
                Dim zendeyx88 As String = "</entry2><spell2>"
                Dim zquellcodeSplityx88 As String
                zquellcodeSplityx88 = Split(zquellcodeyx88, zanfangyx88, 5)(1)
                zquellcodeSplityx88 = Split(zquellcodeSplityx88, zendeyx88, 6)(0)

                If zquellcodeSplityx88.Length > 10 Then
                    If Not glyphid = "0" Then _
                        Process_Status.processreport.AppendText(
                            Now.TimeOfDay.ToString & "> ERROR WHILE GETTING GLYPHID FROM ID: " & glyphid & vbNewLine)

                    Return 0
                Else
                    Process_Status.processreport.AppendText(
                        Now.TimeOfDay.ToString & "/// GlyphId is: " & zquellcodeSplityx88 & "!?" & vbNewLine)
                    Return CInt(zquellcodeSplityx88)
                End If

            Catch ex As Exception
                If Not glyphid = "0" Then _
                    Process_Status.processreport.AppendText(
                        Now.TimeOfDay.ToString & "> ERROR WHILE GETTING GLYPHID FROM ID: " & glyphid & " ## " & ex.ToString &
                        vbNewLine)

                Return 0
            End Try

        Else
            Return 0
        End If
        'Dim trinitycore As New Trinity_core
        'Return trinitycore.getglyphid2(glyphid)
    End Function

    Public Function runcommandInfo(ByVal command As String, ByVal spalte As String) As String

        Dim da As New MySqlDataAdapter(command, Main.GLOBALconn)
        Dim dt As New DataTable

        da.Fill(dt)

        Dim lastcount As Integer = CInt(Val(dt.Rows.Count.ToString))

        If Not lastcount = 0 Then
            Dim readed As String = (dt.Rows(0).Item(0)).ToString
            If readed = "DBnull" Then
                Return ""
            Else
                Return readed
            End If

        Else
            Return ""
        End If
    End Function

    Public Sub writelog(ByVal logtext As String, Optional ByVal showtime As Boolean = True)
        If My.Settings.writelog = True Then
            If showtime = True Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Errorlog.log",
                                                    vbCrLf & "[" & Date.Now.ToString & "] " & logtext, True)
            Else
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Errorlog.log", vbCrLf & logtext, True)
            End If
        End If
    End Sub
End Class
