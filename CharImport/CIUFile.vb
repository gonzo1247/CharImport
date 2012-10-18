﻿'****************************************************************************************
'****************************************************************************************
'***************************** CharImport - CIUFile *****************************************
'****************************************************************************************
'..................Status
'...................Code:        95%
'...................Design:     100%
'...................Functions:   95%
'****************************************************************************************
'****************************************************************************************
'..................Last modified: 21.02.12
'****************************************************************************************
'****************************************************************************************
'..................Comments:
'Talents need to be compiled into citf




Imports System.IO
Imports System.Text

Public Class CIUFile
    '   Dim writestring As String
    Dim clsConvert As New clsConvert
    Dim writepath As String
    Dim readstring As String
    Dim strread As StreamReader
    Dim fileextract As String
    Public Sub createfile(ByVal xpath As String)
        writepath = xpath
    

        nowwrite()



        'Lists

        '    writeit("talentpage", clsConvert.ConvListObject2String(Main.talentlist), True)
    End Sub
    Public Sub nowread()
        Starter.Hide()
        Try
            strread = New StreamReader(Main.tmplpath, System.Text.Encoding.Default)
            Dim xXquellcodeyx88 As String = strread.ReadLine
            Dim xXanfangyx88 As String = "<<datasets>>"
            Dim xXendeyx88 As String = "<</datasets>>"
            Dim xXquellcodeSplityx88 As String
            xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
            xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
            If xXquellcodeSplityx88 = "1" Then
                wait.Show()
                Application.DoEvents()
                Dim xXanfangyx888 As String = "<<importmode>>"
                Dim xXendeyx888 As String = "<</importmode>>"
                Dim xXquellcodeSplityx888 As String
                xXquellcodeSplityx888 = Split(xXquellcodeyx88, xXanfangyx888, 5)(1)
                xXquellcodeSplityx888 = Split(xXquellcodeSplityx888, xXendeyx888, 6)(0)
                Main.importmode = CInt(Val(xXquellcodeSplityx888))
                Main.progressmode = CInt(Val(xXquellcodeSplityx888))
                Dim xXanfangyx8888 As String = "<startdataset1>"
                Dim xXendeyx8888 As String = "<enddataset1>"
                Dim xXquellcodeSplityx8888 As String
                xXquellcodeSplityx8888 = Split(xXquellcodeyx88, xXanfangyx8888, 5)(1)
                xXquellcodeSplityx8888 = Split(xXquellcodeSplityx8888, xXendeyx8888, 6)(0)
                fileextract = xXquellcodeSplityx8888
                getfile()


                Application.DoEvents()
                Main.Show()
                Main.Panel21.Location = New System.Drawing.Point(5000, 5000)
                Main.Panel21.Size = New System.Drawing.Size(0, 0)
                wait.Close()
                Application.DoEvents()

            Else
                Dim xXanfangyx888 As String = "<<importmode>>"
                Dim xXendeyx888 As String = "<</importmode>>"
                Dim xXquellcodeSplityx888 As String
                xXquellcodeSplityx888 = Split(xXquellcodeyx88, xXanfangyx888, 5)(1)
                xXquellcodeSplityx888 = Split(xXquellcodeSplityx888, xXendeyx888, 6)(0)
                Main.importmode = CInt(Val(xXquellcodeSplityx888))
                Main.progressmode = CInt(Val(xXquellcodeSplityx888))

                Main.cuisets = CInt(Val(xXquellcodeSplityx88))
                If xXquellcodeSplityx888 = "1" Then
                    Main.ausgangsformat = 2
                    Armory2Database.Show()
                ElseIf xXquellcodeSplityx888 = "2" Then
                    Main.ausgangsformat = 2
                    Database2Database.Show()
                ElseIf xXquellcodeSplityx888 = "3" Then
                    Main.ausgangsformat = 2
                    Database2Database.Show()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub readtempdataset(ByVal dataset As Integer)
        Try

            Dim xXquellcodeyx88 As String = My.Settings.savecontent
            Dim xXanfangyx88 As String = "<startdataset" & dataset.ToString & ">"
            Dim xXendeyx88 As String = "<enddataset" & dataset.ToString & ">"
            Dim xXquellcodeSplityx88 As String
            xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
            xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
            fileextract = xXquellcodeSplityx88
            getfile()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub readspecial(ByVal dataset As Integer)
        Try
            strread = New StreamReader(Main.tmplpath, System.Text.Encoding.Default)
            Dim xXquellcodeyx88 As String = strread.ReadLine
            Dim xXanfangyx88 As String = "<startdataset" & dataset.ToString & ">"
            Dim xXendeyx88 As String = "<enddataset" & dataset.ToString & ">"
            Dim xXquellcodeSplityx88 As String
            xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
            xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
            fileextract = xXquellcodeSplityx88
            getfile()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub adddataset()
        prepare_new_dataset(Main.datasets.ToString)
        writeit("importmode", Main.progressmode.ToString, False)
        writeit("charlevel", Main.char_level.ToString, False)
        writeit("charclass", Main.char_class.ToString, False)
        writeit("charrace", Main.char_race.ToString, False)
        writeit("chargender", Main.char_gender.ToString, False)
        writeit("charname", Main.char_name.ToString, False)
        writeit("characterspells", list2string(Main.character_spells), False)
        writeit("specialspells", list2string(Main.specialspells), False)
        writeit("specialskills", list2string(Main.specialskills), False)
        writeit("talents", list2string(Main.talentlist), False)
        writeit("inventoryzero", list2string(Main.character_inventoryzero_list), False)
        writeit("queststatus", list2string(Main.character_queststatus), False)
        writeit("finished_quests", Main.finished_quests, False)
        writeit("action1", Main.arcemu_action1, False)
        writeit("action2", Main.arcemu_action2, False)
        writeit("leveltext", Main.level.Text, False)
        writeit("custom_faction", Main.custom_faction, False)
        'Main IDs


        writeit("kopfid", Main.kopfid.ToString, False)
        writeit("schulterid", Main.schulterid.ToString, False)
        writeit("halsid", Main.halsid.ToString, False)
        writeit("rueckenid", Main.rueckenid.ToString, False)
        writeit("beineid", Main.beineid.ToString, False)
        writeit("wappenrockid", Main.wappenrockid.ToString, False)
        writeit("hemdid", Main.hemdid.ToString, False)
        writeit("handgelenkeid", Main.handgelenkeid.ToString, False)
        writeit("haendeid", Main.haendeid.ToString, False)
        writeit("brustid", Main.brustid.ToString, False)
        writeit("guertelid", Main.guertelid.ToString, False)
        writeit("stiefelid", Main.stiefelid.ToString, False)
        writeit("ring1id", Main.ring1id.ToString, False)
        writeit("ring2id", Main.ring2id.ToString, False)
        writeit("schmuck1id", Main.schmuck1id.ToString, False)
        writeit("schmuck2id", Main.schmuck2id.ToString, False)
        writeit("hauptid", Main.hauptid.ToString, False)
        writeit("offid", Main.offid.ToString, False)
        writeit("distanzid", Main.distanzid.ToString, False)


        'Main names

        writeit("kopfname", Main.Kopf.Text, False)
        writeit("schultername", Main.Schulter.Text, False)
        writeit("halsname", Main.Hals.Text, False)
        writeit("rueckenname", Main.Ruecken.Text, False)
        writeit("beinename", Main.Beine.Text, False)
        writeit("wappenrockname", Main.Wappenrock.Text, False)
        writeit("hemdname", Main.Hemd.Text, False)
        writeit("handgelenkename", Main.Handgelenke.Text, False)
        writeit("haendename", Main.Haende.Text, False)
        writeit("brustname", Main.Brust.Text, False)
        writeit("guertelname", Main.Guertel.Text, False)
        writeit("stiefelname", Main.Stiefel.Text, False)
        writeit("ring1name", Main.Ring1.Text, False)
        writeit("ring2name", Main.Ring2.Text, False)
        writeit("schmuck1name", Main.Schmuck1.Text, False)
        writeit("schmuck2name", Main.Schmuck2.Text, False)
        writeit("hauptname", Main.Haupt.Text, False)
        writeit("offname", Main.Off.Text, False)
        writeit("distanzname", Main.Distanz.Text, False)

        'Item Vz IDs

        writeit("kopfvzench", Main.kopfench.ToString, False)
        writeit("schultervzench", Main.schulterench.ToString, False)
        writeit("halsvzench", Main.halsench.ToString, False)
        writeit("rueckenvzench", Main.rueckenench.ToString, False)
        writeit("beinevzench", Main.beineench.ToString, False)
        writeit("handgelenkevzench", Main.handgelenkeench.ToString, False)
        writeit("haendevzench", Main.haendeench.ToString, False)
        writeit("brustvzench", Main.brustench.ToString, False)
        writeit("guertelvzench", Main.guertelench.ToString, False)
        writeit("stiefelvzench", Main.stiefelench.ToString, False)
        writeit("ring1vzench", Main.ring1ench.ToString, False)
        writeit("ring2vzench", Main.ring2ench.ToString, False)
        writeit("schmuck1vzench", Main.schmuck1ench.ToString, False)
        writeit("schmuck2vzench", Main.schmuck2ench.ToString, False)
        writeit("hauptvzench", Main.hauptench.ToString, False)
        writeit("offvzench", Main.offench.ToString, False)
        writeit("distanzvzench", Main.distanzench.ToString, False)

        '  writeit("vzlist", list2string(Main.vzlist), False)
        writeit("kopfvzid", Main.kopfvzid.ToString, False)
        writeit("schultervzid", Main.schultervzid.ToString, False)
        writeit("halsvzid", Main.halsvzid.ToString, False)
        writeit("rueckenvzid", Main.rueckenvzid.ToString, False)
        writeit("beinevzid", Main.beinevzid.ToString, False)
        writeit("handgelenkevzid", Main.handgelenkevzid.ToString, False)
        writeit("haendevzid", Main.haendevzid.ToString, False)
        writeit("brustvzid", Main.brustvzid.ToString, False)
        writeit("guertelvzid", Main.guertelvzid.ToString, False)
        writeit("stiefelvzid", Main.stiefelvzid.ToString, False)
        writeit("ring1vzid", Main.ring1vzid.ToString, False)
        writeit("ring2vzid", Main.ring2vzid.ToString, False)
        writeit("schmuck1vzid", Main.schmuck1vzid.ToString, False)
        writeit("schmuck2vzid", Main.schmuck2vzid.ToString, False)
        writeit("hauptvzid", Main.hauptvzid.ToString, False)
        writeit("offvzid", Main.offvzid.ToString, False)
        writeit("distanzvzid", Main.distanzvzid.ToString, False)


        'Item Vz Names

        writeit("kopfvzname", Main.kopfvz.Text, False)
        writeit("schultervzname", Main.schultervz.Text, False)
        writeit("halsvzname", Main.halsvz.Text, False)
        writeit("rueckenvzname", Main.rueckenvz.Text, False)
        writeit("beinevzname", Main.beinevz.Text, False)
        writeit("handgelenkevzname", Main.handgelenkevz.Text, False)
        writeit("haendevzname", Main.haendevz.Text, False)
        writeit("brustvzname", Main.brustvz.Text, False)
        writeit("guertelvzname", Main.guertelvz.Text, False)
        writeit("stiefelvzname", Main.stiefelvz.Text, False)
        writeit("ring1vzname", Main.ring1vz.Text, False)
        writeit("ring2vzname", Main.ring2vz.Text, False)
        writeit("schmuck1vzname", Main.schmuck1vz.Text, False)
        writeit("schmuck2vzname", Main.schmuck2vz.Text, False)
        writeit("hauptvzname", Main.hauptvz.Text, False)
        writeit("offvzname", Main.offvz.Text, False)
        writeit("distanzvzname", Main.distanzvz.Text, False)

        'Item Socket IDs

        '     writeit("gemlist", list2string(Main.gemlist), False)
        writeit("kopfsocket1id", Main.kopfsocket1id.ToString, False)
        writeit("schultersocket1id", Main.schultersocket1id.ToString, False)
        writeit("halssocket1id", Main.halssocket1id.ToString, False)
        writeit("rueckensocket1id", Main.rueckensocket1id.ToString, False)
        writeit("beinesocket1id", Main.beinesocket1id.ToString, False)
        writeit("handgelenkesocket1id", Main.handgelenkesocket1id.ToString, False)
        writeit("haendesocket1id", Main.haendesocket1id.ToString, False)
        writeit("brustsocket1id", Main.brustsocket1id.ToString, False)
        writeit("guertelsocket1id", Main.guertelsocket1id.ToString, False)
        writeit("stiefelsocket1id", Main.stiefelsocket1id.ToString, False)
        writeit("ring1socket1id", Main.ring1socket1id.ToString, False)
        writeit("ring2socket1id", Main.ring2socket1id.ToString, False)
        writeit("hauptsocket1id", Main.hauptsocket1id.ToString, False)
        writeit("offsocket1id", Main.offsocket1id.ToString, False)
        writeit("distanzsocket1id", Main.distanzsocket1id.ToString, False)

        writeit("kopfsocket2id", Main.kopfsocket2id.ToString, False)
        writeit("schultersocket2id", Main.schultersocket2id.ToString, False)
        writeit("halssocket2id", Main.halssocket2id.ToString, False)
        writeit("rueckensocket2id", Main.rueckensocket2id.ToString, False)
        writeit("beinesocket2id", Main.beinesocket2id.ToString, False)
        writeit("handgelenkesocket2id", Main.handgelenkesocket2id.ToString, False)
        writeit("haendesocket2id", Main.haendesocket2id.ToString, False)
        writeit("brustsocket2id", Main.brustsocket2id.ToString, False)
        writeit("guertelsocket2id", Main.guertelsocket2id.ToString, False)
        writeit("stiefelsocket2id", Main.stiefelsocket2id.ToString, False)
        writeit("ring2socket2id", Main.ring2socket2id.ToString, False)
        writeit("ring2socket2id", Main.ring2socket2id.ToString, False)
        writeit("hauptsocket2id", Main.hauptsocket2id.ToString, False)
        writeit("offsocket2id", Main.offsocket2id.ToString, False)
        writeit("distanzsocket2id", Main.distanzsocket2id.ToString, False)

        writeit("kopfsocket3id", Main.kopfsocket3id.ToString, False)
        writeit("schultersocket3id", Main.schultersocket3id.ToString, False)
        writeit("halssocket3id", Main.halssocket3id.ToString, False)
        writeit("rueckensocket3id", Main.rueckensocket3id.ToString, False)
        writeit("beinesocket3id", Main.beinesocket3id.ToString, False)
        writeit("handgelenkesocket3id", Main.handgelenkesocket3id.ToString, False)
        writeit("haendesocket3id", Main.haendesocket3id.ToString, False)
        writeit("brustsocket3id", Main.brustsocket3id.ToString, False)
        writeit("guertelsocket3id", Main.guertelsocket3id.ToString, False)
        writeit("stiefelsocket3id", Main.stiefelsocket3id.ToString, False)
        writeit("hauptsocket3id", Main.hauptsocket3id.ToString, False)
        writeit("offsocket3id", Main.offsocket3id.ToString, False)
        writeit("distanzsocket3id", Main.distanzsocket3id.ToString, False)

        'Item Socket Names

        writeit("kopfsocket1name", Main.kopfsocket1.Text, False)
        writeit("schultersocket1name", Main.schultersocket1.Text, False)
        writeit("halssocket1name", Main.halssocket1.Text, False)
        writeit("rueckensocket1name", Main.rueckensocket1.Text, False)
        writeit("beinesocket1name", Main.beinesocket1.Text, False)
        writeit("handgelenkesocket1name", Main.Handgelenkesocket1.Text, False)
        writeit("haendesocket1name", Main.haendesocket1.Text, False)
        writeit("brustsocket1name", Main.brustsocket1.Text, False)
        writeit("guertelsocket1name", Main.guertelsocket1.Text, False)
        writeit("stiefelsocket1name", Main.stiefelsocket1.Text, False)
        writeit("ring1socket1name", Main.Ring1socket1.Text, False)
        writeit("ring2socket1name", Main.ring2socket1.Text, False)
        writeit("hauptsocket1name", Main.Hauptsocket1.Text, False)
        writeit("offsocket1name", Main.Offsocket1.Text, False)
        writeit("distanzsocket1name", Main.Distanzsocket1.Text, False)

        writeit("kopfsocket2name", Main.kopfsocket2.Text, False)
        writeit("schultersocket2name", Main.schultersocket2.Text, False)
        writeit("halssocket2name", Main.halssocket2.Text, False)
        writeit("rueckensocket2name", Main.rueckensocket2.Text, False)
        writeit("beinesocket2name", Main.beinesocket2.Text, False)
        writeit("handgelenkesocket2name", Main.handgelenkesocket2.Text, False)
        writeit("haendesocket2name", Main.haendesocket2.Text, False)
        writeit("brustsocket2name", Main.brustsocket2.Text, False)
        writeit("guertelsocket2name", Main.guertelsocket2.Text, False)
        writeit("stiefelsocket2name", Main.stiefelsocket2.Text, False)
        writeit("ring2socket2name", Main.ring2socket2.Text, False)
        writeit("ring2socket2name", Main.ring2socket2.Text, False)
        writeit("hauptsocket2name", Main.Hauptsocket2.Text, False)
        writeit("offsocket2name", Main.Offsocket2.Text, False)
        writeit("distanzsocket2name", Main.Distanzsocket2.Text, False)

        writeit("kopfsocket3name", Main.kopfsocket3.Text, False)
        writeit("schultersocket3name", Main.schultersocket3.Text, False)
        writeit("halssocket3name", Main.halssocket3.Text, False)
        writeit("rueckensocket3name", Main.rueckensocket3.Text, False)
        writeit("beinesocket3name", Main.beinesocket3.Text, False)
        writeit("handgelenkesocket3name", Main.Handgelenkesocket3.Text, False)
        writeit("haendesocket3name", Main.haendesocket3.Text, False)
        writeit("brustsocket3name", Main.brustsocket3.Text, False)
        writeit("guertelsocket3name", Main.guertelsocket3.Text, False)
        writeit("stiefelsocket3name", Main.stiefelsocket3.Text, False)
        writeit("hauptsocket3name", Main.hauptsocket3.Text, False)
        writeit("offsocket3name", Main.offsocket3.Text, False)
        writeit("distanzsocket3name", Main.distanzsocket3.Text, False)

        'Glyph IDs

        '   writeit("glyphlist", list2string(Main.glyphlist), False)
        writeit("primeglyph1id", Main.primeglyph1.ToString, False)
        writeit("primeglyph2id", Main.primeglyph2.ToString, False)
        writeit("primeglyph3id", Main.primeglyph3.ToString, False)
        writeit("majorglyph1id", Main.majorglyph1.ToString, False)
        writeit("majorglyph2id", Main.majorglyph2.ToString, False)
        writeit("majorglyph3id", Main.majorglyph3.ToString, False)
        writeit("minorglyph1id", Main.minorglyph1.ToString, False)
        writeit("minorglyph2id", Main.minorglyph2.ToString, False)
        writeit("minorglyph3id", Main.minorglyph3.ToString, False)
        writeit("secprimeglyph1id", Main.secprimeglyph1.ToString, False)
        writeit("secprimeglyph2id", Main.secprimeglyph2.ToString, False)
        writeit("secprimeglyph3id", Main.secprimeglyph3.ToString, False)
        writeit("secmajorglyph1id", Main.secmajorglyph1.ToString, False)
        writeit("secmajorglyph2id", Main.secmajorglyph2.ToString, False)
        writeit("secmajorglyph3id", Main.secmajorglyph3.ToString, False)
        writeit("secminorglyph1id", Main.secminorglyph1.ToString, False)
        writeit("secminorglyph2id", Main.secminorglyph2.ToString, False)
        writeit("secminorglyph3id", Main.secminorglyph3.ToString, False)
        'Glyph Names

        writeit("primeglyph1", Main.textprimeglyph1, False)
        writeit("primeglyph2", Main.textprimeglyph2, False)
        writeit("primeglyph3", Main.textprimeglyph3, False)
        writeit("majorglyph1", Main.textmajorglyph1, False)
        writeit("majorglyph2", Main.textmajorglyph2, False)
        writeit("majorglyph3", Main.textmajorglyph3, False)
        writeit("minorglyph1", Main.textminorglyph1, False)
        writeit("minorglyph2", Main.textminorglyph2, False)
        writeit("minorglyph3", Main.textminorglyph3, False)
        writeit("secprimeglyph1", Main.sectextprimeglyph1, False)
        writeit("secprimeglyph2", Main.sectextprimeglyph2, False)
        writeit("secprimeglyph3", Main.sectextprimeglyph3, False)
        writeit("secmajorglyph1", Main.sectextmajorglyph1, False)
        writeit("secmajorglyph2", Main.sectextmajorglyph2, False)
        writeit("secmajorglyph3", Main.sectextmajorglyph3, False)
        writeit("secminorglyph1", Main.sectextminorglyph1, False)
        writeit("secminorglyph2", Main.sectextminorglyph2, False)
        writeit("secminorglyph3", Main.sectextminorglyph3, False)

        writeit("accountid", Main.accountid.ToString, False)
        writeit("char_guid", Main.char_guid.ToString, False)
        writeit("char_xp", Main.char_xp.ToString, False)
        writeit("player_money", Main.player_money.ToString, False)
        writeit("playerBytes", Main.playerBytes.ToString, False)
        writeit("playerBytes2", Main.playerBytes2.ToString, False)
        writeit("playerFlags", Main.playerFlags.ToString, False)
        writeit("position_x", Main.position_x, False)
        writeit("position_y", Main.position_y, False)
        writeit("position_z", Main.position_z, False)
        writeit("map", Main.map.ToString, False)
        writeit("instance_id", Main.instance_id.ToString, False)
        writeit("instance_mode_mask", Main.instance_mode_mask, False)
        writeit("orientation", Main.orientation, False)
        writeit("taximask", Main.taximask, False)
        writeit("cinematic", Main.cinematic.ToString, False)
        writeit("totaltime", Main.totaltime.ToString, False)
        writeit("leveltime", Main.leveltime.ToString, False)
        writeit("extra_flags", Main.extra_flags, False)
        writeit("stable_slots", Main.stable_slots, False)
        writeit("at_login", Main.at_login, False)
        writeit("zone", Main.zone.ToString, False)
        writeit("arenaPoints", Main.arenaPoints.ToString, False)
        writeit("totalHonorPoints", Main.totalHonorPoints.ToString, False)
        writeit("totalKills", Main.totalKills.ToString, False)
        writeit("chosenTitle", Main.chosenTitle, False)
        writeit("knownCurrencies", Main.knownCurrencies, False)
        writeit("watchedFaction", Main.watchedFaction, False)
        writeit("health", Main.health.ToString, False)
        writeit("speccount", Main.speccount.ToString, False)
        writeit("activespec", Main.activespec.ToString, False)
        writeit("exploredZones", Main.exploredZones, False)
        writeit("knownTitles", Main.knownTitles, False)
        writeit("actionBars", Main.actionBars, False)
        writeit("character_homebind", Main.character_homebind, False)
        'character_achievement Table

        writeit("character_achievement_list", list2string(Main.character_achievement_list), False)
        'character_action Table



        writeit("character_action_list", list2string(Main.character_action_list), False)

        writeit("character_inventory_list", list2string(Main.character_inventory_list), False)
        writeit("character_reputatuion_list", list2string(Main.character_reputatuion_list), False)
        writeit("character_skills_list", list2string(Main.character_skills_list), False)
        writeit("character_talent_list", list2string(Main.character_talent_list), False)

        writeit("accountname", Main.accountname, False)
        writeit("sha_pass_hash", Main.sha_pass_hash, False)
        writeit("sessionkey", Main.sessionkey, False)
        writeit("account_v", Main.account_v, False)
        writeit("account_s", Main.account_s, False)
        writeit("email", Main.email, False)
        writeit("joindate", Main.joindate, False)
        writeit("expansion", Main.expansion.ToString, False)
        writeit("locale", Main.locale.ToString, False)

        writeit("account_access_gmlevel", Main.account_access_gmlevel.ToString, False)
        writeit("account_access_RealmID", Main.account_access_RealmID.ToString, False)
        If Not Main.datasets >= 2 Then
            'Item Pics

            writeit("kopfpic", ConvertImageToString(Main.kopfpic.Image), False)
            writeit("halspic", ConvertImageToString(Main.Halspic.Image), False)
            writeit("schulterpic", ConvertImageToString(Main.Schulterpic.Image), False)
            writeit("wappenrockpic", ConvertImageToString(Main.Wappenrockpic.Image), False)
            writeit("hemdpic", ConvertImageToString(Main.Hemdpic.Image), False)
            writeit("rueckenpic", ConvertImageToString(Main.Rueckenpic.Image), False)
            writeit("handgelenkepic", ConvertImageToString(Main.Handgelenkepic.Image), False)
            writeit("haendepic", ConvertImageToString(Main.Haendepic.Image), False)
            writeit("guertelpic", ConvertImageToString(Main.Guertelpic.Image), False)
            writeit("stiefelpic", ConvertImageToString(Main.Stiefelpic.Image), False)
            writeit("beinepic", ConvertImageToString(Main.Beinepic.Image), False)
            writeit("ring1pic", ConvertImageToString(Main.Ring1pic.Image), False)
            writeit("ring2pic", ConvertImageToString(Main.Ring2pic.Image), False)
            writeit("schmuck1pic", ConvertImageToString(Main.Schmuck1pic.Image), False)
            writeit("schmuck2pic", ConvertImageToString(Main.Schmuck2pic.Image), False)
            writeit("hauptpic", ConvertImageToString(Main.Hauptpic.Image), False)
            writeit("offpic", ConvertImageToString(Main.Offpic.Image), False)
            writeit("distanzpic", ConvertImageToString(Main.Distanzpic.Image), False)
            writeit("brustpic", ConvertImageToString(Main.Brustpic.Image), False)

            'Glyph Pics

            writeit("prim1pic", ConvertImageToString(Main.glyphpic1), False)
            writeit("prim2pic", ConvertImageToString(Main.glyphpic2), False)
            writeit("prim3pic", ConvertImageToString(Main.glyphpic3), False)
            writeit("erheb1pic", ConvertImageToString(Main.glyphpic4), False)
            writeit("erheb2pic", ConvertImageToString(Main.glyphpic5), False)
            writeit("erheb3pic", ConvertImageToString(Main.glyphpic6), False)
            writeit("gering1pic", ConvertImageToString(Main.glyphpic7), False)
            writeit("gering2pic", ConvertImageToString(Main.glyphpic8), False)
            writeit("gering3pic", ConvertImageToString(Main.glyphpic9), False)

            writeit("secprim1pic", ConvertImageToString(Main.secglyphpic1), False)
            writeit("secprim2pic", ConvertImageToString(Main.secglyphpic2), False)
            writeit("secprim3pic", ConvertImageToString(Main.secglyphpic3), False)
            writeit("secerheb1pic", ConvertImageToString(Main.secglyphpic4), False)
            writeit("secerheb2pic", ConvertImageToString(Main.secglyphpic5), False)
            writeit("secerheb3pic", ConvertImageToString(Main.secglyphpic6), False)
            writeit("secgering1pic", ConvertImageToString(Main.secglyphpic7), False)
            writeit("secgering2pic", ConvertImageToString(Main.secglyphpic8), False)
            writeit("secgering3pic", ConvertImageToString(Main.secglyphpic9), False)
        End If
        writeit("last", "go", True)
        end_dataset(Main.datasets.ToString)
    End Sub
    Public Sub getfile()

        readitINT("charlevel", Main.char_level, False, True)
        readitINT("charclass", Main.char_class, False, True)
        readitINT("charrace", Main.char_race, False, True)
        readitINT("chargender", Main.char_gender, False, True)
        readit("charname", Main.char_name, False)
        readit("finished_quests", Main.finished_quests, False)
        readit("action1", Main.arcemu_action1, False)
        readit("action2", Main.arcemu_action2, False)
        readit("custom_faction", Main.custom_faction, False)
        '      string2list("charopt", Main.charopt)
        '   string2list("charenchlist", Main.charenchlist)
        string2list("specialspells", Main.specialspells)
        string2list("specialskills", Main.specialskills)
        string2list("characterspells", Main.character_spells)
        string2list("talents", Main.talentlist)
        string2list("inventoryzero", Main.character_inventoryzero_list)
        string2list("queststatus", Main.character_queststatus)

        '     string2list("vzlist", Main.vzlist)
        '    string2list("gemlist", Main.gemlist)
        '   string2list("glyphlist", Main.glyphlist)
        'Main IDs
        '  string2list("itemlist", Main.itemlist)

        readit2("leveltext", Main.level, False)


        readitINT("importmode", Main.importmode, False, True)

        readitINT("kopfid", Main.kopfid, False, True)
        readitINT("schulterid", Main.schulterid, False, True)
        readitINT("halsid", Main.halsid, False, True)
        readitINT("rueckenid", Main.rueckenid, False, True)
        readitINT("beineid", Main.beineid, False, True)
        readitINT("wappenrockid", Main.wappenrockid, False, True)
        readitINT("hemdid", Main.hemdid, False, True)
        readitINT("handgelenkeid", Main.handgelenkeid, False, True)
        readitINT("haendeid", Main.haendeid, False, True)
        readitINT("brustid", Main.brustid, False, True)
        readitINT("guertelid", Main.guertelid, False, True)
        readitINT("stiefelid", Main.stiefelid, False, True)
        readitINT("ring1id", Main.ring1id, False, True)
        readitINT("ring2id", Main.ring2id, False, True)
        readitINT("schmuck1id", Main.schmuck1id, False, True)
        readitINT("schmuck2id", Main.schmuck2id, False, True)
        readitINT("hauptid", Main.hauptid, False, True)
        readitINT("offid", Main.offid, False, True)
        readitINT("distanzid", Main.distanzid, False, True)


        'Main names

        readit2("kopfname", Main.Kopf, False)
        readit2("schultername", Main.Schulter, False)
        readit2("halsname", Main.Hals, False)
        readit2("rueckenname", Main.Ruecken, False)
        readit2("beinename", Main.Beine, False)
        readit2("wappenrockname", Main.Wappenrock, False)
        readit2("hemdname", Main.Hemd, False)
        readit2("handgelenkename", Main.Handgelenke, False)
        readit2("haendename", Main.Haende, False)
        readit2("brustname", Main.Brust, False)
        readit2("guertelname", Main.Guertel, False)
        readit2("stiefelname", Main.Stiefel, False)
        readit2("ring1name", Main.Ring1, False)
        readit2("ring2name", Main.Ring2, False)
        readit2("schmuck1name", Main.Schmuck1, False)
        readit2("schmuck2name", Main.Schmuck2, False)
        readit2("hauptname", Main.Haupt, False)
        readit2("offname", Main.Off, False)
        readit2("distanzname", Main.Distanz, False)


        readitINT("kopfvzid", Main.kopfvzid, False, True)
        readitINT("schultervzid", Main.schultervzid, False, True)
        readitINT("halsvzid", Main.halsvzid, False, True)
        readitINT("rueckenvzid", Main.rueckenvzid, False, True)
        readitINT("beinevzid", Main.beinevzid, False, True)
        readitINT("handgelenkevzid", Main.handgelenkevzid, False, True)
        readitINT("haendevzid", Main.haendevzid, False, True)
        readitINT("brustvzid", Main.brustvzid, False, True)
        readitINT("guertelvzid", Main.guertelvzid, False, True)
        readitINT("stiefelvzid", Main.stiefelvzid, False, True)
        readitINT("ring1vzid", Main.ring1vzid, False, True)
        readitINT("ring2vzid", Main.ring2vzid, False, True)
        readitINT("schmuck1vzid", Main.schmuck1vzid, False, True)
        readitINT("schmuck2vzid", Main.schmuck2vzid, False, True)
        readitINT("hauptvzid", Main.hauptvzid, False, True)
        readitINT("offvzid", Main.offvzid, False, True)
        readitINT("distanzvzid", Main.distanzvzid, False, True)
        readitINT("hauptvzid", Main.hauptvzid, False, True)
        readitINT("offvzid", Main.offvzid, False, True)
        readitINT("distanzvzid", Main.distanzvzid, False, True)

        'Item Vz Names

        readit2("kopfvzname", Main.kopfvz, False)
        readit2("schultervzname", Main.schultervz, False)
        readit2("halsvzname", Main.halsvz, False)
        readit2("rueckenvzname", Main.rueckenvz, False)
        readit2("beinevzname", Main.beinevz, False)
        readit2("handgelenkevzname", Main.handgelenkevz, False)
        readit2("haendevzname", Main.haendevz, False)
        readit2("brustvzname", Main.brustvz, False)
        readit2("guertelvzname", Main.guertelvz, False)
        readit2("stiefelvzname", Main.stiefelvz, False)
        readit2("ring1vzname", Main.ring1vz, False)
        readit2("ring2vzname", Main.ring2vz, False)
        readit2("schmuck1vzname", Main.schmuck1vz, False)
        readit2("schmuck2vzname", Main.schmuck2vz, False)
        readit2("hauptvzname", Main.hauptvz, False)
        readit2("offvzname", Main.offvz, False)
        readit2("distanzvzname", Main.distanzvz, False)
        readit2("hauptvzname", Main.hauptvzlabel2, False)
        readit2("offvzname", Main.offvzlabel2, False)
        readit2("distanzvzname", Main.distanzvzlabel2, False)

        'Item Socket Names
        readitINT("kopfsocket1id", Main.kopfsocket1id, False, True)
        readitINT("schultersocket1id", Main.schultersocket1id, False, True)
        readitINT("halssocket1id", Main.halssocket1id, False, True)
        readitINT("rueckensocket1id", Main.rueckensocket1id, False, True)
        readitINT("beinesocket1id", Main.beinesocket1id, False, True)
        readitINT("handgelenkesocket1id", Main.handgelenkesocket1id, False, True)
        readitINT("haendesocket1id", Main.haendesocket1id, False, True)
        readitINT("brustsocket1id", Main.brustsocket1id, False, True)
        readitINT("guertelsocket1id", Main.guertelsocket1id, False, True)
        readitINT("stiefelsocket1id", Main.stiefelsocket1id, False, True)
        readitINT("ring1socket1id", Main.ring1socket1id, False, True)
        readitINT("ring2socket1id", Main.ring2socket1id, False, True)
        readitINT("hauptsocket1id", Main.hauptsocket1id, False, True)
        readitINT("offsocket1id", Main.offsocket1id, False, True)
        readitINT("distanzsocket1id", Main.distanzsocket1id, False, True)

        readitINT("kopfsocket2id", Main.kopfsocket2id, False, True)
        readitINT("schultersocket2id", Main.schultersocket2id, False, True)
        readitINT("halssocket2id", Main.halssocket2id, False, True)
        readitINT("rueckensocket2id", Main.rueckensocket2id, False, True)
        readitINT("beinesocket2id", Main.beinesocket2id, False, True)
        readitINT("handgelenkesocket2id", Main.handgelenkesocket2id, False, True)
        readitINT("haendesocket2id", Main.haendesocket2id, False, True)
        readitINT("brustsocket2id", Main.brustsocket2id, False, True)
        readitINT("guertelsocket2id", Main.guertelsocket2id, False, True)
        readitINT("stiefelsocket2id", Main.stiefelsocket2id, False, True)
        readitINT("ring2socket2id", Main.ring2socket2id, False, True)
        readitINT("ring2socket2id", Main.ring2socket2id, False, True)
        readitINT("hauptsocket2id", Main.hauptsocket2id, False, True)
        readitINT("offsocket2id", Main.offsocket2id, False, True)
        readitINT("distanzsocket2id", Main.distanzsocket2id, False, True)

        readitINT("kopfsocket3id", Main.kopfsocket3id, False, True)
        readitINT("schultersocket3id", Main.schultersocket3id, False, True)
        readitINT("halssocket3id", Main.halssocket3id, False, True)
        readitINT("rueckensocket3id", Main.rueckensocket3id, False, True)
        readitINT("beinesocket3id", Main.beinesocket3id, False, True)
        readitINT("handgelenkesocket3id", Main.handgelenkesocket3id, False, True)
        readitINT("haendesocket3id", Main.haendesocket3id, False, True)
        readitINT("brustsocket3id", Main.brustsocket3id, False, True)
        readitINT("guertelsocket3id", Main.guertelsocket3id, False, True)
        readitINT("stiefelsocket3id", Main.stiefelsocket3id, False, True)
        readitINT("hauptsocket3id", Main.hauptsocket3id, False, True)
        readitINT("offsocket3id", Main.offsocket3id, False, True)
        readitINT("distanzsocket3id", Main.distanzsocket3id, False, True)

        readit("kopfvzench", Main.kopfench, False)
        readit("schultervzench", Main.schulterench, False)
        readit("halsvzench", Main.halsench, False)
        readit("rueckenvzench", Main.rueckenench, False)
        readit("beinevzench", Main.beineench, False)
        readit("handgelenkevzench", Main.handgelenkeench, False)
        readit("haendevzench", Main.haendeench, False)
        readit("brustvzench", Main.brustench, False)
        readit("guertelvzench", Main.guertelench, False)
        readit("stiefelvzench", Main.stiefelench, False)
        readit("ring1vzench", Main.ring1ench, False)
        readit("ring2vzench", Main.ring2ench, False)
        readit("schmuck1vzench", Main.schmuck1ench, False)
        readit("schmuck2vzench", Main.schmuck2ench, False)
        readit("hauptvzench", Main.hauptench, False)
        readit("offvzench", Main.offench, False)
        readit("distanzvzench", Main.distanzench, False)

        readit2("kopfsocket1name", Main.kopfsocket1, False)
        readit2("schultersocket1name", Main.schultersocket1, False)
        readit2("halssocket1name", Main.halssocket1, False)
        readit2("rueckensocket1name", Main.rueckensocket1, False)
        readit2("beinesocket1name", Main.beinesocket1, False)
        readit2("handgelenkesocket1name", Main.Handgelenkesocket1, False)
        readit2("haendesocket1name", Main.haendesocket1, False)
        readit2("brustsocket1name", Main.brustsocket1, False)
        readit2("guertelsocket1name", Main.guertelsocket1, False)
        readit2("stiefelsocket1name", Main.stiefelsocket1, False)
        readit2("ring1socket1name", Main.Ring1socket1, False)
        readit2("ring2socket1name", Main.ring2socket1, False)
        readit2("hauptsocket1name", Main.Hauptsocket1, False)
        readit2("offsocket1name", Main.Offsocket1, False)
        readit2("distanzsocket1name", Main.Distanzsocket1, False)

        readit2("kopfsocket2name", Main.kopfsocket2, False)
        readit2("schultersocket2name", Main.schultersocket2, False)
        readit2("halssocket2name", Main.halssocket2, False)
        readit2("rueckensocket2name", Main.rueckensocket2, False)
        readit2("beinesocket2name", Main.beinesocket2, False)
        readit2("handgelenkesocket2name", Main.handgelenkesocket2, False)
        readit2("haendesocket2name", Main.haendesocket2, False)
        readit2("brustsocket2name", Main.brustsocket2, False)
        readit2("guertelsocket2name", Main.guertelsocket2, False)
        readit2("stiefelsocket2name", Main.stiefelsocket2, False)
        readit2("ring2socket2name", Main.ring2socket2, False)
        readit2("ring2socket2name", Main.ring2socket2, False)
        readit2("hauptsocket2name", Main.Hauptsocket2, False)
        readit2("offsocket2name", Main.Offsocket2, False)
        readit2("distanzsocket2name", Main.Distanzsocket2, False)

        readit2("kopfsocket3name", Main.kopfsocket3, False)
        readit2("schultersocket3name", Main.schultersocket3, False)
        readit2("halssocket3name", Main.halssocket3, False)
        readit2("rueckensocket3name", Main.rueckensocket3, False)
        readit2("beinesocket3name", Main.beinesocket3, False)
        readit2("handgelenkesocket3name", Main.Handgelenkesocket3, False)
        readit2("haendesocket3name", Main.haendesocket3, False)
        readit2("brustsocket3name", Main.brustsocket3, False)
        readit2("guertelsocket3name", Main.guertelsocket3, False)
        readit2("stiefelsocket3name", Main.stiefelsocket3, False)
        readit2("hauptsocket3name", Main.hauptsocket3, False)
        readit2("offsocket3name", Main.offsocket3, False)
        readit2("distanzsocket3name", Main.distanzsocket3, False)

        'Glyph Names

        readit("primeglyph1id", Main.primeglyph1, False)
        readit("primeglyph2id", Main.primeglyph2, False)
        readit("primeglyph3id", Main.primeglyph3, False)
        readit("majorglyph1id", Main.majorglyph1, False)
        readit("majorglyph2id", Main.majorglyph2, False)
        readit("majorglyph3id", Main.majorglyph3, False)
        readit("minorglyph1id", Main.minorglyph1, False)
        readit("minorglyph2id", Main.minorglyph2, False)
        readit("minorglyph3id", Main.minorglyph3, False)
        readit("secprimeglyph1id", Main.secprimeglyph1, False)
        readit("secprimeglyph2id", Main.secprimeglyph2, False)
        readit("secprimeglyph3id", Main.secprimeglyph3, False)
        readit("secmajorglyph1id", Main.secmajorglyph1, False)
        readit("secmajorglyph2id", Main.secmajorglyph2, False)
        readit("secmajorglyph3id", Main.secmajorglyph3, False)
        readit("secminorglyph1id", Main.secminorglyph1, False)
        readit("secminorglyph2id", Main.secminorglyph2, False)
        readit("secminorglyph3id", Main.secminorglyph3, False)

        readit("primeglyph1", Main.textprimeglyph1, False)
        readit("primeglyph2", Main.textprimeglyph2, False)
        readit("primeglyph3", Main.textprimeglyph3, False)
        readit("majorglyph1", Main.textmajorglyph1, False)
        readit("majorglyph2", Main.textmajorglyph2, False)
        readit("majorglyph3", Main.textmajorglyph3, False)
        readit("minorglyph1", Main.textminorglyph1, False)
        readit("minorglyph2", Main.textminorglyph2, False)
        readit("minorglyph3", Main.textminorglyph3, False)
        readit("secprimeglyph1", Main.sectextprimeglyph1, False)
        readit("secprimeglyph2", Main.sectextprimeglyph2, False)
        readit("secprimeglyph3", Main.sectextprimeglyph3, False)
        readit("secmajorglyph1", Main.sectextmajorglyph1, False)
        readit("secmajorglyph2", Main.sectextmajorglyph2, False)
        readit("secmajorglyph3", Main.sectextmajorglyph3, False)
        readit("secminorglyph1", Main.sectextminorglyph1, False)
        readit("secminorglyph2", Main.sectextminorglyph2, False)
        readit("secminorglyph3", Main.sectextminorglyph3, False)


        readitINT("accountid", Main.accountid, False, True)
        readitINT("char_guid", Main.char_guid, False, True)
        readitINT("char_xp", Main.char_xp, False, True)
        readitINT("player_money", Main.player_money, False, True)
        readitINT("playerBytes", Main.playerBytes, False, True)
        readitINT("playerBytes2", Main.playerBytes2, False, True)
        readitINT("playerFlags", Main.playerFlags, False, True)
        readit("position_x", Main.position_x, False)
        readit("position_y", Main.position_y, False)
        readit("position_z", Main.position_z, False)
        readitINT("map", Main.map, False, True)
        readitINT("instance_id", Main.instance_id, False, True)
        readit("instance_mode_mask", Main.instance_mode_mask, False)
        readit("orientation", Main.orientation, False)
        readit("taximask", Main.taximask, False)
        readitINT("cinematic", Main.cinematic, False, True)
        readitINT("totaltime", Main.totaltime, False, True)
        readitINT("leveltime", Main.leveltime, False, True)
        readit("extra_flags", Main.extra_flags, False)
        readit("stable_slots", Main.stable_slots, False)
        readit("at_login", Main.at_login, False)
        readitINT("zone", Main.zone, False, True)
        readitINT("arenaPoints", Main.arenaPoints, False, True)
        readitINT("totalHonorPoints", Main.totalHonorPoints, False, True)
        readitINT("totalKills", Main.totalKills, False, True)
        readit("chosenTitle", Main.chosenTitle, False)
        readit("knownCurrencies", Main.knownCurrencies, False)
        readit("watchedFaction", Main.watchedFaction, False)
        readitINT("health", Main.health, False, True)
        readitINT("speccount", Main.speccount, False, True)
        readitINT("activespec", Main.activespec, False, True)
        readit("exploredZones", Main.exploredZones, False)
        readit("knownTitles", Main.knownTitles, False)
        readit("actionBars", Main.actionBars, False)
        readit("character_homebind", Main.character_homebind, False)
        'character_achievement Table

        string2list("character_achievement_list", Main.character_achievement_list)
        'character_action Table



        string2list("character_action_list", Main.character_action_list)

        string2list("character_inventory_list", Main.character_inventory_list)
        string2list("character_reputatuion_list", Main.character_reputatuion_list)
        string2list("character_skills_list", Main.character_skills_list)
        string2list("character_talent_list", Main.character_talent_list)

        readit("accountname", Main.accountname, False)
        readit("sha_pass_hash", Main.sha_pass_hash, False)
        readit("sessionkey", Main.sessionkey, False)
        readit("account_v", Main.account_v, False)
        readit("account_s", Main.account_s, False)
        readit("email", Main.email, False)
        readit("joindate", Main.joindate, False)
        readitINT("expansion", Main.expansion, False, True)
        readitINT("locale", Main.locale, False, True)

        readitINT("account_access_gmlevel", Main.account_access_gmlevel, False, True)
        readitINT("account_access_RealmID", Main.account_access_RealmID, False, True)

        'Item Pics

        readimage2("kopfpic", Main.kopfpic, False)
        readimage2("halspic", Main.Halspic, False)
        readimage2("schulterpic", Main.Schulterpic, False)
        readimage2("wappenrockpic", Main.Wappenrockpic, False)
        readimage2("hemdpic", Main.Hemdpic, False)
        readimage2("rueckenpic", Main.Rueckenpic, False)
        readimage2("handgelenkepic", Main.Handgelenkepic, False)
        readimage2("haendepic", Main.Haendepic, False)
        readimage2("guertelpic", Main.Guertelpic, False)
        readimage2("stiefelpic", Main.Stiefelpic, False)
        readimage2("beinepic", Main.Beinepic, False)
        readimage2("ring1pic", Main.Ring1pic, False)
        readimage2("ring2pic", Main.Ring2pic, False)
        readimage2("schmuck1pic", Main.Schmuck1pic, False)
        readimage2("schmuck2pic", Main.Schmuck2pic, False)
        readimage2("hauptpic", Main.Hauptpic, False)
        readimage2("offpic", Main.Offpic, False)
        readimage2("distanzpic", Main.Distanzpic, False)
        readimage2("brustpic", Main.Brustpic, False)

        'Glyph Pics

        readimage("prim1pic", Main.glyphpic1, False)
        readimage("prim2pic", Main.glyphpic2, False)
        readimage("prim3pic", Main.glyphpic3, False)
        readimage("erheb1pic", Main.glyphpic4, False)
        readimage("erheb2pic", Main.glyphpic5, False)
        readimage("erheb3pic", Main.glyphpic6, False)
        readimage("gering1pic", Main.glyphpic7, False)
        readimage("gering2pic", Main.glyphpic8, False)
        readimage("gering3pic", Main.glyphpic9, False)

        readimage("secprim1pic", Main.secglyphpic1, False)
        readimage("secprim2pic", Main.secglyphpic2, False)
        readimage("secprim3pic", Main.secglyphpic3, False)
        readimage("secerheb1pic", Main.secglyphpic4, False)
        readimage("secerheb2pic", Main.secglyphpic5, False)
        readimage("secerheb3pic", Main.secglyphpic6, False)
        readimage("secgering1pic", Main.secglyphpic7, False)
        readimage("secgering2pic", Main.secglyphpic8, False)
        readimage("secgering3pic", Main.secglyphpic9, True)

    End Sub

    Public Sub readit(ByVal schlüssel As String, ByRef nonsense As String, ByVal lastone As Boolean, Optional ByVal isint As Boolean = False)

        If lastone = False Then
            Try
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                Dim s As String = xXquellcodeSplityx88
                Dim b() As Byte = Encoding.Default.GetBytes(s)
                Dim s1 As String = System.Text.Encoding.UTF8.GetString(b)
               
                    nonsense = s1

            Catch ex As Exception
                nonsense = ""
            End Try



        Else

        End If


    End Sub
    Public Sub readitINT(ByVal schlüssel As String, ByRef nonsense As Integer, ByVal lastone As Boolean, Optional ByVal isint As Boolean = False)

        If lastone = False Then
            Try
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                Dim s As String = xXquellcodeSplityx88
                Dim b() As Byte = Encoding.Default.GetBytes(s)
                Dim s1 As String = System.Text.Encoding.UTF8.GetString(b)

                nonsense = CInt(s1)

            Catch ex As Exception
                nonsense = 0
            End Try



        Else

        End If


    End Sub
    Private Function list2string(ByVal xlist As List(Of String)) As String
        Try
            Dim builder As StringBuilder = New StringBuilder()
            For Each val As String In xlist
                builder.Append(val).Append("|")
            Next

            ' Convert to string.
            Return builder.ToString()
        Catch ex As Exception
            Return ""
        End Try


    End Function
    Private Sub string2list(ByVal schlüssel As String, ByRef dieliste As List(Of String))
        Try
         
            Dim xXquellcodeyx88 As String = fileextract
            Dim xXanfangyx88 As String = schlüssel & "="
            Dim xXendeyx88 As String = "<++>"
            Dim xXquellcodeSplityx88 As String
            xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
            xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
            Dim s As String = xXquellcodeSplityx88
            Dim b() As Byte = Encoding.Default.GetBytes(s)
            Dim s1 As String = System.Text.Encoding.UTF8.GetString(b)

            Dim stringlist As String() = s1.Split("|"c)
            Dim position As Integer = 0
            Dim xlist As List(Of String) = New List(Of String)
            Do
                Try

                    Dim temp As String = stringlist(position)
                    If Not temp = "" Then xlist.Add(temp)

                    position += 1
                Catch ex As Exception
                    Exit Do
                End Try
            Loop
            dieliste = xlist
        Catch ex As Exception
            Dim leerelist As List(Of String) = New List(Of String)
            dieliste = leerelist
        End Try
    End Sub
    Public Sub readit2(ByVal schlüssel As String, ByRef nonsense As Label, ByVal lastone As Boolean)
        If lastone = False Then

           
            Dim xXquellcodeyx88 As String = fileextract
            Dim xXanfangyx88 As String = schlüssel & "="
            Dim xXendeyx88 As String = "<++>"
            Dim xXquellcodeSplityx88 As String
            xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
            xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
            nonsense.Text = xXquellcodeSplityx88
            Dim s As String = xXquellcodeSplityx88
            Dim b() As Byte = Encoding.Default.GetBytes(s)
            Dim s1 As String = System.Text.Encoding.UTF8.GetString(b)
            If s1 = "" Then
                nonsense.Visible = False
            ElseIf s1 = "Platz leer" Then

                nonsense.Visible = False
            Else
                nonsense.Visible = True
            End If

            nonsense.Text = s1
            Application.DoEvents()
        Else
         
        End If


    End Sub
    Public Sub readimage(ByVal schlüssel As String, ByRef nonsense As Image, ByVal lastone As Boolean)
        Try
            If lastone = False Then

              
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                nonsense = ConvertStringToImage(xXquellcodeSplityx88)
            Else
               
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                nonsense = ConvertStringToImage(xXquellcodeSplityx88)

                Application.DoEvents()
                '  MsgBox("Template erfolgreich geladen!", MsgBoxStyle.OkOnly, "Hinweis")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub readimage2(ByVal schlüssel As String, ByRef nonsense As PictureBox, ByVal lastone As Boolean)
        Try
            If lastone = False Then

               
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                nonsense.Image = ConvertStringToImage(xXquellcodeSplityx88)
            Else
              
                Dim xXquellcodeyx88 As String = fileextract
                Dim xXanfangyx88 As String = schlüssel & "="
                Dim xXendeyx88 As String = "<++>"
                Dim xXquellcodeSplityx88 As String
                xXquellcodeSplityx88 = Split(xXquellcodeyx88, xXanfangyx88, 5)(1)
                xXquellcodeSplityx88 = Split(xXquellcodeSplityx88, xXendeyx88, 6)(0)
                nonsense.Image = ConvertStringToImage(xXquellcodeSplityx88)


                Application.DoEvents()
                MsgBox("Template erfolgreich geladen!", MsgBoxStyle.OkOnly, "Hinweis")
            End If
        Catch ex As Exception

        End Try

    End Sub



    Public Function Image2ByteArray(ByVal Bild As Image, ByVal Bildformat As System.Drawing.Imaging.ImageFormat) As Byte()

        Try
            Dim MS As New IO.MemoryStream
            Bild.Save(MS, Bildformat)
            MS.Flush()
            Return MS.ToArray
        Catch ex As Exception
            Dim MS As New IO.MemoryStream
            My.Resources.empty.Save(MS, Bildformat)
            MS.Flush()
            Return MS.ToArray
        End Try

    End Function
    Private Sub prepare_new_dataset(ByVal dataset As String)
        My.Settings.savecontent = My.Settings.savecontent & "<startdataset" & dataset & ">"
        My.Settings.Save()
    End Sub
    Private Sub writeit(ByVal schlüssel As String, ByVal wert As String, ByVal lastone As Boolean)


        My.Settings.savecontent = My.Settings.savecontent & schlüssel & "=" & wert.ToString & "<++>"
        If lastone = True Then
            My.Settings.Save()
        End If


    End Sub
    Private Sub end_dataset(ByVal dataset As String)
        My.Settings.savecontent = My.Settings.savecontent & "<enddataset" & dataset & ">"
        My.Settings.Save()
    End Sub
    Private Sub nowwrite()
        Dim fs As FileStream = New FileStream(writepath, FileMode.OpenOrCreate, FileAccess.Write)


        Dim w As StreamWriter = New StreamWriter(fs)


        w.WriteLine("<<datasets>>" & Main.datasets & "<</datasets>> <<importmode>>" & Main.progressmode.ToString & "<</importmode>>" & My.Settings.savecontent)

        w.WriteLine()

        w.Close()
        fs.Close()
        '      MsgBox("Template erfolgreich erstellt!", MsgBoxStyle.OkOnly, "Hinweis")
    End Sub
    Public Function ByteArray2Image(ByVal ByAr() As Byte) As Image
        Dim img As Image
        Dim MS As New IO.MemoryStream(ByAr)

        'das TRY ist Notwending, da wenn ein ARRAY eingelesen wird, welches KEIN Bild war,
        'eine Exception auftritt!
        Try
            img = Image.FromStream(MS)
        Catch ex As Exception
            Return Nothing
        End Try

        Return img
    End Function
    Public Function StringToByteArray(ByRef str As String) As Byte()
        Return Convert.FromBase64String(str)
    End Function

    Public Function ByteArrayToString(ByRef Barr() As Byte) As String
        Return Convert.ToBase64String(Barr)
    End Function

    '------------------Text in Bytearray und zurück-------------------
    Public Function TextStringToByteArray(ByRef str As String) As Byte()
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default

        Return enc.GetBytes(str)
    End Function
    Public Shared Function ConvertImageToString(ByVal bild As Image) As String
        Dim Result As String = String.Empty


        Try

            Dim img As Image = bild
            Using ms As MemoryStream = New MemoryStream
                img.Save(ms, img.RawFormat)
                Dim Bytes() As Byte = ms.ToArray()
                Result = Convert.ToBase64String(Bytes)
            End Using

        Catch ex As Exception

        End Try

        Return Result
    End Function

    Public Shared Function ConvertStringToImage(ByVal Base64String As String) As Image
        Dim img As Image = Nothing
        If Base64String Is Nothing Then

        Else
            Try
                Dim Bytes() As Byte = Convert.FromBase64String(Base64String)
                img = Image.FromStream(New MemoryStream(Bytes))
            Catch ex As Exception

            End Try
        End If
        Return img
    End Function
    Public Function ByteArrayToTextString(ByRef Barr() As Byte) As String
        Try
            Dim enc As System.Text.Encoding = System.Text.Encoding.Default

            Return enc.GetString(Barr)
        Catch ex As Exception
            Return ""
        End Try

    End Function
End Class
