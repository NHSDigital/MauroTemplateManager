Imports System.IO
Imports System.Text.Json

''' <summary>
''' Manipulate a JSON list of settings for an application, storing the file in the users ApplicationData folder
''' </summary>
Public Class ApplicationSettings
    ''' <summary>
    ''' Load the existing settings from the JSON file
    ''' </summary>
    ''' <param name="ApplicationName">The name of the application or application family</param>
    Public Sub New(ApplicationName As String)
        Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & ApplicationName
        If Not Directory.Exists(filePath) Then
            Directory.CreateDirectory(filePath)
        End If
        Filename = filePath & "\" & ApplicationName + ".json"
        Try
            Dim JSONFile As New FileStream(Filename, FileMode.Open, FileAccess.Read)
            Dim Reader As New StreamReader(JSONFile)
            Try
                Settings = JsonSerializer.Deserialize(Of List(Of AppSetting))(Reader.ReadToEnd)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            ' unable to open the file!
            Settings = New List(Of AppSetting)
        End Try
    End Sub
    ''' <summary>
    ''' The name of the file holding the application settings
    ''' </summary>
    ''' <returns></returns>
    Property Filename As String
    ''' <summary>
    ''' Load the first instance of the settings for settin Name
    ''' </summary>
    ''' <param name="Name">Name of the setting to retrieve</param>
    ''' <param name="Missing">A default value if the setting has not previouslyy been specified</param>
    ''' <returns></returns>
    Public Function GetAppSetting(Name As String, Optional Missing As String = "") As String
        Dim Index As Integer = Settings.FindIndex(Function(Setting As AppSetting)
                                                      Return Setting.Name = Name
                                                  End Function)
        If Index >= 0 Then
            Return Settings(Index).Value
        Else
            Return Missing
        End If
    End Function

    ''' <summary>
    ''' Get all the values of a setting ordered by the setting sequence
    ''' </summary>
    ''' <param name="Name">Name of the setting to retrieve</param>
    ''' <param name="Missing">A default value if the setting has not previously been specified</param>
    ''' <returns>List of settings ordered by sequence</returns>
    Public Function GetAppSettingAll(Name As String, Optional Missing As String = "") As List(Of AppSetting)
        Dim res As List(Of AppSetting) = Settings.FindAll(Function(Setting As AppSetting)
                                                              Return Setting.Name = Name
                                                          End Function)

        Dim sorted = res.OrderBy(Function(x) x.Sequence)
        Return sorted.ToList
    End Function

    ''' <summary>
    ''' Sets the value of Setting with index 0, overwriting if exists
    ''' </summary>
    ''' <param name="Name">Name of the setting to add or update</param>
    ''' <param name="Value">Value to set or overwrite</param>
    Public Sub SetAppSetting(Name As String, Value As String)
        Dim Setting As AppSetting = Settings.Find(Function(S As AppSetting)
                                                      Return S.Name = Name
                                                  End Function)
        Dim res As AppSetting

        If IsNothing(Setting) Then
            res = New AppSetting With {
                         .Name = Name,
                         .Value = Value,
                         .Sequence = 0
                         }
            Settings.Add(res)
        Else
            res = Setting
        End If
        Save()
    End Sub
    ''' <summary>
    ''' Add a new setting at the end of the list
    ''' </summary>
    ''' <param name="Name">Name of the setting to add</param>
    ''' <param name="Value">Value to set</param>
    Public Sub AddSettingEnd(Name As String, Value As String)
        Dim current As List(Of AppSetting) = GetAppSettingAll(Name)
        Dim i As Integer = 0
        For i = 0 To current.Count - 1
            current(i).Sequence = i
        Next
        Dim newSetting As New AppSetting With {
            .Name = Name,
        .Value = Value,
        .Sequence = i + 1}
        Settings.Add(newSetting)
        Save()
    End Sub
    ''' <summary>
    ''' Add a new setting at the start of the list, incrementing the sequence of existing members
    ''' </summary>
    ''' <param name="Name">Name of the setting to add</param>
    ''' <param name="Value">Value to set</param>
    Public Sub AddSettingStart(Name As String, Value As String)
        Dim current As List(Of AppSetting) = GetAppSettingAll(Name)
        Dim i As Integer

        For i = 1 To current.Count
            current(i - 1).Sequence = i
        Next
        Dim newSetting As New AppSetting With {
            .Name = Name,
        .Value = Value,
        .Sequence = 0}
        Settings.Add(newSetting)
        Save()
    End Sub

    Public Sub AddOrMoveToStart(Name As String, Value As String)
        Dim Index As Integer = Settings.FindIndex(Function(Setting As AppSetting)
                                                      Return Setting.Name = Name And Setting.Value = Value
                                                  End Function)
        If Index >= 0 Then
            For i = 0 To Index - 1
                Settings(i).Sequence += 1
            Next
            Settings(Index).Sequence = 0
            Save()
        Else
            AddSettingStart(Name, Value)
        End If

    End Sub

    ''' <summary>
    ''' Save the settings to the ApplicationData file
    ''' </summary>
    Private Sub Save()
        Dim JSONFile As New FileStream(Filename, FileMode.Create, FileAccess.Write)
        Dim Writer As New StreamWriter(JSONFile)

        Dim jsonOpt As New JsonSerializerOptions
        Dim jsontext As String = JsonSerializer.Serialize(Settings, jsonOpt)

        Writer.Write(jsontext)
        Writer.Close()
    End Sub

    ''' <summary>
    ''' All the settings.  This list is not directly exposed to protect setting management
    ''' </summary>
    ''' <returns></returns>
    Private Property Settings As List(Of AppSetting)

    ''' <summary>
    ''' A Name, value, sequence class to hold a specific setting
    ''' </summary>
    Public Class AppSetting
        ''' <summary>
        ''' The name of the setting
        ''' </summary>
        ''' <returns></returns>
        Property Name As String
        ''' <summary>
        ''' The string value of the setting
        ''' </summary>
        ''' <returns></returns>
        Property Value As String
        ''' <summary>
        ''' The position in the list (sequence) of the setting if there are more than one values for that name
        ''' </summary>
        ''' <returns></returns>
        Property Sequence As Integer
    End Class
End Class


