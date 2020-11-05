Imports System.IO
Imports MauroDataModeller.MauroModel
Imports System.Text.Json
Imports System.Threading

Namespace MauroTemplates
#Region "Main class"
    ''' <summary>
    ''' <para>Main Mauro Template Manager project class </para>
    ''' <list type="bullet">
    '''  <item>
    '''   <description>Handles file open and save, </description>
    '''  </item>
    '''  <item>
    '''   <description>Connects to a Mauro endpoint</description>
    '''  </item>
    ''' </list>
    ''' <para></para>
    ''' </summary>
    Public Class Project
        ''' <summary>
        ''' Gets or sets the Mauro endpoint connection details
        ''' </summary>
        Property Endpoint As MauroEndpoint
        ''' <summary>
        ''' Gets or sets the project&apos;s filename
        ''' </summary>
        Property Filename As String
        ''' <summary>
        ''' Gets or sets the filetype.
        ''' </summary>
        ''' <remarks>
        ''' The only permitted value is &quot;MauroProject&quot;.  Any other value will be
        ''' rejected as an invalid file.
        ''' </remarks>
        ''' <value>
        ''' MauroProject
        ''' </value>
        Property FileType As String
        ''' <summary>
        ''' Gets or sets the list of Freemarker action scripts.
        ''' </summary>
        Property Actions As List(Of FreemarkerAction)
        ''' <summary>
        ''' Gets or sets the list of Mauro model identifiers to apply the Freemarker
        ''' template to.
        ''' </summary>
        Property Models As List(Of Guid)

        ''' <summary>
        ''' Read a project as a JSON file
        ''' </summary>
        ''' <param name="Filename">Filename of the project to read</param>
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
                    Dim Ex As New InvalidMauroProjectFileException("Unable to load file " & Filename & " invalid Endpoint.FileType.")
                    Throw Ex
                End If
            Catch ex As Exception
                Dim newEx As New InvalidMauroProjectFileException("Unable to load file " & Filename, ex)
                Throw newEx
            End Try

            ' Initialise the connection
            Try
                EndpointConnection.Timeout = Endpoint.Timeout

            Catch ex As Exception

            End Try
            UpdateEndpointConnection(Endpoint)
            Reader.Close()
        End Sub

        Private Sub UpdateEndpointConnection(Endpoint As MauroEndpoint)
            EndpointConnection.Username = Endpoint.Username
            EndpointConnection.Password = Endpoint.Password
            EndpointConnection.Endpoint = Endpoint.EndpointURL
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
        Public Sub SaveProject(ClobberPassword As Boolean, Optional SaveAsFilename As String = "")
            If SaveAsFilename = "" Then
                SaveAsFilename = Filename
            End If

            Dim ser As New ProjectSerialisation With {
                .EndpointURL = Endpoint.EndpointURL,
                .Username = "",
                .Password = "",
                .Timeout = Endpoint.Timeout,
                .Filename = SaveAsFilename,
                .FileType = FileType,
                .Actions = Actions,
                .Models = Models}

            If Not ClobberPassword Then
                ser.Password = Endpoint.Password
                ser.Username = Endpoint.Username
            End If

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

        End Sub
        Public Sub New(EndpointURL As Uri, Optional Username As String = "", Optional Password As String = "")
            Filename = ""
            FileType = "MauroProject"
            Models = New List(Of Guid)
            Actions = New List(Of FreemarkerAction)

            Endpoint = New MauroEndpoint With {
            .EndpointURL = EndpointURL,
            .Username = Username,
            .Password = Password
            }

            UpdateEndpointConnection(Endpoint)
        End Sub
        ''' <summary>
        ''' Connection details to a Mauro endpoint but does not handle the connection to
        ''' that endpoint.
        ''' </summary>
        Public Class MauroEndpoint

            ''' <summary>
            ''' Gets or sets the http URL to access the Mauro endpoint.
            ''' </summary>
            ''' <value>
            ''' http URL of the Mauro endpoint
            ''' </value>
            Property EndpointURL As Uri
            ''' <summary>
            ''' Gets or sets the username used to identify the user seeking to access the Mauro endpoint.
            ''' </summary>
            ''' <value>
            ''' e-mail address or other user identifier to access the Mauro endpoint
            ''' </value>
            Property Username As String
            ''' <summary>
            ''' Gets or sets the password used to authenticate the username against the Mauro
            ''' endpoint.
            ''' </summary>
            Property Password As String
            ''' <summary>
            ''' Gets or sets the TimeSpan used by the endpoint connection to connect to a Mauro
            ''' API.
            ''' </summary>
            Property Timeout As TimeSpan

        End Class
    End Class
#End Region
#Region "Supporting classes"

    ''' <summary>
    ''' The type of entity to work on
    ''' </summary>
    Public Enum ActionTypes
        ''' <summary>
        ''' Action is on each class in each of the selected data models
        ''' </summary>
        actionClass
        ''' <summary>
        ''' Action is applied independently to each data model selected in turn
        ''' </summary>
        actionSingleModel
        ''' <summary>
        ''' Action is applied to all the selected data models creating a single output
        ''' </summary>
        actionAllModels
        ''' <summary>
        ''' Action is applied to each terminology in each of the selected data models
        ''' </summary>
        actionTerminology
    End Enum

    ''' <summary>
    ''' A list of ActionEntry instances for use in the queue
    ''' </summary>
    Public Class ActionEntries
        Private Shared SyncLockObject As Object = New Object
        Private Shared locEntries As New List(Of ActionEntry)
        ''' <summary>
        ''' Gets or sets the list of ActionEntry classes.
        ''' </summary>
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

        ''' <summary>
        ''' Finds a specific entry by the ID
        ''' </summary>
        ''' <remarks>
        ''' If more than one entry exist (a data error) only the first entry will be
        ''' returned
        ''' </remarks>
        ''' <param name="ID">ID of the ActionEntry to find</param>
        ''' <returns>
        ''' The ActionEntry with the specified ID
        ''' </returns>
        Public Function FindByID(ID As Guid) As ActionEntry
            Dim r = Entries.Where(Function(x) x.ActionEntryID = ID).FirstOrDefault
            Return r
        End Function

        ''' <summary>
        ''' Gets the number of ActionEntry classes in the list where the ActionEntry has not
        ''' started executing.
        ''' </summary>
        Public Shared ReadOnly Property NotStarted As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionStatus.NotStarted).Count
                Return res
            End Get
        End Property
        ''' <summary>
        ''' Gets the number of ActionEntry classes in the list where the ActionEntry is
        ''' currently processing
        ''' </summary>
        Public Shared ReadOnly Property InProgress As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionStatus.InProgress).Count
                Return res
            End Get
        End Property
        ''' <summary>
        ''' Gets the number of ActionEntry classes in the list where the ActionEntry has
        ''' completed processing successfully
        ''' </summary>
        Public Shared ReadOnly Property Success As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionStatus.Success).Count
                Return res
            End Get
        End Property
        ''' <summary>
        ''' Gets the number of ActionEntry classes in the list where the ActionEntry has
        ''' completed processing but has not been successful
        ''' </summary>
        Public Shared ReadOnly Property Failed As Integer
            Get
                Dim res = Entries.Where(Function(x) x.Status = ActionStatus.Failed).Count
                Return res
            End Get
        End Property

        ''' <summary>
        ''' Checks the queue of pending action entries and if there are less than the limit in progress, initiates separate threads for pending entries up to the limit.
        ''' </summary>
        ''' <param name="limit">Maximum number of threads to be running at once</param>
        Public Shared Sub Start(limit As Integer)
            Dim i As Integer = 0
            For Each ae As ActionEntry In Entries.Where(Function(x) x.Status = ActionStatus.NotStarted)
                ' newEntry.Start()
                Dim Evaluator = New Thread(Sub() ProcessActionEntry(ae)) With {
                    .Name = ae.ActionEntryID.ToString
                }
                Evaluator.Start()
                i += 1
                If i > limit Then Exit For
            Next
        End Sub

        ''' <summary>
        ''' Clears down the list of ActionEntry classes
        ''' </summary>
        Public Shared Sub Clear()
            Entries.Clear()
        End Sub
    End Class

    ''' <summary>
    ''' An individual action within the Action Entry queue
    ''' </summary>
    Public Class ActionEntry
        ''' <summary>
        ''' Gets or sets the list of data model identifier Guids.
        ''' </summary>
        Property ModelIDs As List(Of Guid)
        ''' <summary>
        ''' Gets or sets the action to perform.
        ''' </summary>
        Property Action As FreemarkerAction
        ''' <summary>
        ''' Gets or sets the list of responses where an actionentry has been executed.
        ''' </summary>
        Property ActionResponses As List(Of ActionResponse) = New List(Of ActionResponse)
        ''' <summary>
        ''' Gets or sets the current Action Outcome Status for the action entry.
        ''' </summary>
        Property Status As ActionStatus
        ''' <summary>
        ''' Gets the unique identifier for the Action Entry.
        ''' </summary>
        ReadOnly Property ActionEntryID As Guid
        ''' <summary>
        ''' Gets or sets the directory files will be stored in.
        ''' </summary>
        ''' <remarks>
        ''' The system&apos;s current directory will be used if the output directory is not
        ''' specified on creation
        ''' </remarks>
        Property OutputDirectory As String
        Sub New()
            ActionEntryID = Guid.NewGuid
            If OutputDirectory = "" Then OutputDirectory = Environment.CurrentDirectory
        End Sub

    End Class
    ''' <summary>
    ''' The template action to execute and the file details for storing the output
    ''' </summary>
    Public Class FreemarkerAction
        ''' <summary>
        ''' Gets or sets the freemarker template to execute.
        ''' </summary>
        ''' <seealso href="https://freemarker.apache.org/">Apache Freemarker</seealso>
        Property Template As String
        ''' <summary>
        ''' Gets or sets the text to place at the start of the filename.
        ''' </summary>
        Property FilePrefix As String
        ''' <summary>
        ''' Gets or sets the text to place at the end of the filename..
        ''' </summary>
        ''' <remarks>
        ''' This should include any suffix to assist in identifying the type of output, e.g.
        ''' &quot;.html&quot;, &quot;.dita&quot;
        ''' </remarks>
        Property FileSuffix As String
        ''' <summary>
        ''' Gets or sets the type of action.
        ''' </summary>
        ''' <seealso cref="MauroDataModeller.MauroTemplates.ActionTypes"/>
        Property ActionType As ActionTypes
        ''' <summary>
        ''' Gets or sets a meaningful name fo rthe action.
        ''' </summary>
        Property Name As String
        ''' <summary>
        ''' Gets or sets a meaningful description of the action.
        ''' </summary>
        Property Description As String

        ''' <summary>
        ''' Gets a unique identifier for the action set at creation.
        ''' </summary>
        ReadOnly Property id As Guid = Guid.NewGuid
    End Class

    ''' <summary>
    ''' The response output for an executed action
    ''' </summary>
    ''' <remarks>
    ''' This is only populated where the ActionOutcomeStatus is <see
    ''' cref="MauroDataModeller.MauroTemplates.ActionStatus.Success"/> or <see
    ''' cref="MauroDataModeller.MauroTemplates.ActionStatus.Failed"/>
    ''' </remarks>
    ''' <seealso cref="MauroDataModeller.MauroTemplates.ActionStatus"/>
    Public Class ActionResponse
        ''' <summary>
        ''' Gets a unique identifier for this response.
        ''' </summary>
        ReadOnly Property ResponseID As Guid = Guid.NewGuid
        ''' <summary>
        ''' Gets or sets the description of the response.
        ''' </summary>
        Property ResponseDescription As String

        ''' <summary>
        ''' Gets or sets the outcome of executing this action.
        ''' </summary>
        Property responseOutcome As ActionStatus

        ''' <summary>
        ''' Gets or sets the full filename of the generated file.
        ''' </summary>
        ''' <remarks>
        ''' Populated if the responseOutcome is Success
        ''' </remarks>
        Property OutputFilename As String

        ''' <summary>
        ''' Gets or sets the HTML file name for an error file.
        ''' </summary>
        ''' <remarks>
        ''' Populated if the responseOutcome is Failed
        ''' </remarks>
        Property ErrorFileName As String

        ''' <summary>
        ''' Gets or sets the HTTP response from the server to the request.
        ''' </summary>
        Property Response As PostResponse
    End Class
    ''' <summary>
    ''' The status of an Action
    ''' </summary>
    Public Enum ActionStatus
        ''' <summary>
        ''' The action has been added to a queue to execute but has not started executing
        ''' </summary>
        NotStarted
        ''' <summary>
        ''' The action is currently being executed
        ''' </summary>
        InProgress
        ''' <summary>
        ''' The action was executed successfully
        ''' </summary>
        Success
        ''' <summary>
        ''' The action was executed but failed
        ''' </summary>
        Failed
        ''' <summary>
        ''' The action is queued for retry
        ''' </summary>
        Retry
    End Enum
    ''' <summary>
    ''' Exception for when a Mauro Template Project file is invalid
    ''' </summary>
    Public Class InvalidMauroProjectFileException
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
#End Region
End Namespace