﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.18052
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My

    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0"), _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()), MySettings)

#Region "Funktion zum automatischen Speichern von My.Settings"
#If _MyType = "WindowsForms" Then
        Private Shared addedHandler As Boolean

        Private Shared addedHandlerLockObject As New Object

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
            If My.Application.SaveMySettingsOnExit Then
                My.Settings.Save()
            End If
        End Sub
#End If
#End Region

        Public Shared ReadOnly Property [Default]() As MySettings
            Get

#If _MyType = "WindowsForms" Then
                If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph1() As String
            Get
                Return CType(Me("glyph1"), String)
            End Get
            Set(value As String)
                Me("glyph1") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph2() As String
            Get
                Return CType(Me("glyph2"), String)
            End Get
            Set(value As String)
                Me("glyph2") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph3() As String
            Get
                Return CType(Me("glyph3"), String)
            End Get
            Set(value As String)
                Me("glyph3") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph4() As String
            Get
                Return CType(Me("glyph4"), String)
            End Get
            Set(value As String)
                Me("glyph4") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph5() As String
            Get
                Return CType(Me("glyph5"), String)
            End Get
            Set(value As String)
                Me("glyph5") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property glyph6() As String
            Get
                Return CType(Me("glyph6"), String)
            End Get
            Set(value As String)
                Me("glyph6") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property lol() As String
            Get
                Return CType(Me("lol"), String)
            End Get
            Set(value As String)
                Me("lol") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property savecontent() As String
            Get
                Return CType(Me("savecontent"), String)
            End Get
            Set(value As String)
                Me("savecontent") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("en")> _
        Public Property language() As String
            Get
                Return CType(Me("language"), String)
            End Get
            Set(value As String)
                Me("language") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("True")> _
        Public Property firststart() As Boolean
            Get
                Return CType(Me("firststart"), Boolean)
            End Get
            Set(value As Boolean)
                Me("firststart") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("root")> _
        Public Property user() As String
            Get
                Return CType(Me("user"), String)
            End Get
            Set(value As String)
                Me("user") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("trinity")> _
        Public Property pass() As String
            Get
                Return CType(Me("pass"), String)
            End Get
            Set(value As String)
                Me("pass") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("3316")> _
        Public Property port() As String
            Get
                Return CType(Me("port"), String)
            End Get
            Set(value As String)
                Me("port") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("localhost")> _
        Public Property address() As String
            Get
                Return CType(Me("address"), String)
            End Get
            Set(value As String)
                Me("address") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("realmd")> _
        Public Property realmd() As String
            Get
                Return CType(Me("realmd"), String)
            End Get
            Set(value As String)
                Me("realmd") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("characters")> _
        Public Property characters() As String
            Get
                Return CType(Me("characters"), String)
            End Get
            Set(value As String)
                Me("characters") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property writelog() As Boolean
            Get
                Return CType(Me("writelog"), Boolean)
            End Get
            Set(value As Boolean)
                Me("writelog") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property nope() As String
            Get
                Return CType(Me("nope"), String)
            End Get
            Set(value As String)
                Me("nope") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("True")> _
        Public Property shellclose() As Boolean
            Get
                Return CType(Me("shellclose"), Boolean)
            End Get
            Set(value As Boolean)
                Me("shellclose") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property levelrangeactive() As Boolean
            Get
                Return CType(Me("levelrangeactive"), Boolean)
            End Get
            Set(value As Boolean)
                Me("levelrangeactive") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property lastloginactive() As Boolean
            Get
                Return CType(Me("lastloginactive"), Boolean)
            End Get
            Set(value As Boolean)
                Me("lastloginactive") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property gmlevelactive() As Boolean
            Get
                Return CType(Me("gmlevelactive"), Boolean)
            End Get
            Set(value As Boolean)
                Me("gmlevelactive") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property levelrangemin() As Integer
            Get
                Return CType(Me("levelrangemin"), Integer)
            End Get
            Set(value As Integer)
                Me("levelrangemin") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property lastlogindate1() As String
            Get
                Return CType(Me("lastlogindate1"), String)
            End Get
            Set(value As String)
                Me("lastlogindate1") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property lastlogindate2() As String
            Get
                Return CType(Me("lastlogindate2"), String)
            End Get
            Set(value As String)
                Me("lastlogindate2") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property gmlevel() As String
            Get
                Return CType(Me("gmlevel"), String)
            End Get
            Set(value As String)
                Me("gmlevel") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property levelrangemax() As Integer
            Get
                Return CType(Me("levelrangemax"), Integer)
            End Get
            Set(value As Integer)
                Me("levelrangemax") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("1")> _
        Public Property favcore() As Integer
            Get
                Return CType(Me("favcore"), Integer)
            End Get
            Set(value As Integer)
                Me("favcore") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My

    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(), _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()> _
    Friend Module MySettingsProperty

        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")> _
        Friend ReadOnly Property Settings() As Global.CharImport.My.MySettings
            Get
                Return Global.CharImport.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
