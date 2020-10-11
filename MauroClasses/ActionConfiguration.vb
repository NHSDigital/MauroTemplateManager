Imports System.IO

Imports System.Text.Json

Namespace MauroAPI.FreemarkerProject
    ''' <summary>
    ''' Holds the main project, handles file open and save, and connects to a Mauro endpoint
    ''' </summary>
    Public Class Project
        Property Endpoint As MauroEndpoint
        Property Filename As String
        Property FileType As String
        Property Actions As List(Of FreemarkerAction)
        Property Models As List(Of Guid)

        ''' <summary>
        ''' Read a project as a JSON file
        ''' </summary>
        ''' <param name="Filename"></param>
        Public Sub LoadProject(Filename As String)
            Dim JSONFile As New FileStream(Filename, FileMode.Open, FileAccess.Read)
            Dim Reader As New StreamReader(JSONFile)
            Try
                Dim ser As ProjectSerialisation = JsonSerializer.Deserialize(Of ProjectSerialisation)(Reader.ReadToEnd)
                Endpoint = New MauroEndpoint With {
                    .EndpointURL = ser.EndpointURL,
                    .Timeout = ser.Timeout,
                    .Username = ser.Username,
                    .Password = ser.Password
               }
                ' Filename = ser.Filename Use the supplied filename instead
                FileType = ser.FileType
                Actions = ser.Actions
                Models = ser.Models

                If FileType <> "MauroProject" Then
                    Dim Ex As New InvalidMauroFileException("Unable to load file " & Filename & " invalid Endpoint.FileType.")
                    Throw Ex
                End If
            Catch ex As Exception
                Dim newEx As New InvalidMauroFileException("Unable to load file " & Filename, ex)
                Throw newEx
            End Try

            ' Initialise the connection
            Try
                EndpointConnection.Timeout = Endpoint.Timeout

            Catch ex As Exception

            End Try
            EndpointConnection.Username = Endpoint.Username
            EndpointConnection.Password = Endpoint.Password
            EndpointConnection.Endpoint = Endpoint.EndpointURL.ToString
            Reader.Close()
        End Sub


        ''' <summary>
        ''' Private class for project serialisation to disk
        ''' </summary>
        Private Class ProjectSerialisation
            Property Filename As String
            Property FileType As String
            Property Actions As List(Of FreemarkerAction)
            Property Models As List(Of Guid)

            Property EndpointURL As Uri
            Property Username As String
            Property Password As String
            Property Timeout As TimeSpan
        End Class
        Public Sub SaveProject(Optional SaveAsFilename As String = "")
            If SaveAsFilename = "" Then
                SaveAsFilename = Filename
            End If

            Dim ser As New ProjectSerialisation With {
                .EndpointURL = Endpoint.EndpointURL,
                .Username = Endpoint.Username,
                .Password = Endpoint.Password,
                .Timeout = Endpoint.Timeout,
                .Filename = SaveAsFilename,
                .FileType = FileType,
                .Actions = Actions,
                .Models = Models}

            Dim JSONFile As New FileStream(SaveAsFilename, FileMode.Create, FileAccess.Write)
            Dim Writer As New StreamWriter(JSONFile)

            Dim jsonOpt As New JsonSerializerOptions
            Dim jsontext As String = JsonSerializer.Serialize(ser, jsonOpt)

            Writer.Write(jsontext)
            Writer.Close()
        End Sub
        Public Sub New(OpenFilename As String)
            Me.Filename = OpenFilename

            LoadProject(Filename)
        End Sub
        Public Sub New()
            Filename = ""
            FileType = "MauroProject"
            Models = New List(Of Guid)
            Actions = New List(Of FreemarkerAction)

            Endpoint = New MauroEndpoint With {
            .EndpointURL = New Uri("https://localhost"),
            .Username = "",
            .Password = ""
            }
        End Sub

    End Class

    ''' <summary>
    ''' Connection details to a Mauro endpoint
    ''' </summary>
    Public Class MauroEndpoint

        Property EndpointURL As Uri
        Property Username As String
        Property Password As String
        Property Timeout As TimeSpan

    End Class
    ''' <summary>
    ''' The type of entity to work on
    ''' </summary>
    Public Enum ActionTypes
        actionClass
        actionSingleModel
        actionAllModels
        actionTerminology
    End Enum

    Public Class ActionEntries
        Private Shared SyncLockObject As Object = New Object
        Private Shared locEntries As New List(Of ActionEntry)
        Public Shared Property Entries As List(Of ActionEntry)
            Get
                SyncLock SyncLockObject
                    Return locEntries
                End SyncLock
            End Get
            Set(value As List(Of ActionEntry))
                SyncLock SyncLockObject
                    locEntries = value
                End SyncLock
            End Set
        End Property

        Public Function FindByID(ID As Guid) As ActionEntry
            Dim r = Entries.Where(Function(x) x.ID = ID).FirstOrDefault
            Return r
        End Function

        Public Shared ReadOnly Property NotStarted As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionOutcomeStatus.NotStarted).Count
                Return res
            End Get
        End Property
        Public Shared ReadOnly Property InProgress As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionOutcomeStatus.InProgress).Count
                Return res
            End Get
        End Property
        Public Shared ReadOnly Property Success As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionOutcomeStatus.Success).Count
                Return res
            End Get
        End Property
        Public Shared ReadOnly Property Failed As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionOutcomeStatus.Failed).Count
                Return res
            End Get
        End Property

        Public Shared Sub Execute()
            Dim Inactive As List(Of ActionEntry) = Entries.Where(Function(x) x.Status = ActionOutcomeStatus.NotStarted)
            For Each e As ActionEntry In Inactive
                e.Status = ActionOutcomeStatus.InProgress
            Next
        End Sub

    End Class

    Public Class FreemarkerAction
        Property Template As String
        Property FilePrefix As String
        Property FileSuffix As String
        Property ActionType As ActionTypes
        Property Name As String
        Property Description As String

        Property id As Guid
    End Class

    Public Class ActionEntry
        Property Model As List(Of Guid)
        Property Action As FreemarkerAction
        Property postResponses As List(Of PostResponse)
        Property Status As ActionOutcomeStatus
        Property ID As Guid
        Property OutputDirectory As String
        Sub New()
            ID = Guid.NewGuid
            If OutputDirectory = "" Then OutputDirectory = Environment.CurrentDirectory
        End Sub

    End Class

    Public Enum ActionOutcomeStatus
        NotStarted
        InProgress
        Success
        Failed
    End Enum
    Public Class InvalidMauroFileException
        Inherits Exception

        Public Sub New()
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New(message, inner)
        End Sub
    End Class
End Namespace