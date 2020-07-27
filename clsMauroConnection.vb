Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text.Json

Imports System.Text.Json.Serialization
Imports System.Text
Imports System.IO
Imports System.Xml

Namespace MauroAPI
    Class clsMauroConnection
        Private Shared ReadOnly client As HttpClient = New HttpClient()
        Public Shared Property Username As String
        Public Shared Property Password As String
        Public Shared Property Endpoint As String = "https://modelcatalogue.cs.ox.ac.uk/nhsd"

        Public Shared Property LoginStatus As Boolean = False

        ' Set up basic strings for the API
        Const LoginAPI = "/api/authentication/login"
        Const LogoutAPI = "/api/authentication/logout"
        Const ModelAPI = "/api/dataModels"
        Const JSONMime = "application/json"

        Public Shared Property LoginDetails As LoginResponse = Nothing

        Public Shared Property MauroModels As Models

        Public Shared Async Function Login() As Task(Of LoginResponse)
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(JSONMime))

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser")
            Dim MauroLogin As New LoginRequest With {.username = Username, .password = Password}
            Dim strBody = JsonSerializer.Serialize(MauroLogin)
            Dim Body As New StringContent(strBody, Encoding.UTF8, "application/json")

            Dim PostResult = Await client.PostAsync(Endpoint & LoginAPI, Body)

            Dim JSONResult = Await PostResult.Content.ReadAsStreamAsync

            LoginDetails = Await JsonSerializer.DeserializeAsync(Of LoginResponse)(JSONResult)
            LoginStatus = True
            Return LoginDetails
        End Function

        Public Shared Async Function GetModels() As Task(Of Models)
            Dim JSONString = Await GetMauroJSON(ModelAPI)
            MauroModels = JsonSerializer.Deserialize(Of Models)(JSONString)
            Return MauroModels
        End Function

        Public Shared Async Function GetModel(ID As Guid) As Task(Of Model)
            Dim JSONString = Await GetMauroJSON(ModelAPI & "/" & ID.ToString)
            Dim MauroModel = JsonSerializer.Deserialize(Of Model)(JSONString)
            Return MauroModel
        End Function



        Private Shared Async Function GetMauroJSON(API As String) As Task(Of String)

            If LoginStatus = False Then
                Await Login()
            End If
            ' Async retrieval of Mauro API JSON
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(JSONMime))
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser")

            ' Retrieve the JSON from the Mauro endpoint
            Dim GetResult = Await client.GetAsync(Endpoint & API)
            Dim JSONResult = Await GetResult.Content.ReadAsStreamAsync
            Dim reader As New StreamReader(JSONResult)

            Dim JSONstring = reader.ReadToEnd()
            Return JSONstring
        End Function

        Public Shared Async Function Logout() As Task
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(JSONMime))

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser")

            Dim PostResult = Await client.GetAsync(Endpoint & LogoutAPI)

            Dim ResultContent = Await PostResult.Content.ReadAsStringAsync
            Console.WriteLine(ResultContent)
        End Function

    End Class

    Public Class LoginResponse

        <JsonPropertyName("id")>
        Public Property id As Guid
        <JsonPropertyName("emailAddress")>
        Public Property emailAddress As String

        <JsonPropertyName("firstName")>
        Public Property firstName As String
        <JsonPropertyName("lastName")>
        Public Property lastName As String

        <JsonPropertyName("userRole")>
        Public Property userRole As String
        <JsonPropertyName("disabled")>
        Public Property disabled As Boolean
    End Class
    ''' <summary>
    ''' Mauro dataModels data structure
    ''' count of models as integer
    ''' list of Mauro model data structures
    ''' </summary>
    Public Class Models
        <JsonPropertyName("count")>
        Public Property count As Integer

        <JsonPropertyName("items")>
        Public Property items As List(Of Model)
    End Class
    ''' <summary>
    ''' Mauro dataModel datastructure
    ''' </summary>
    Public Class Model

        <JsonPropertyName("id")>
        Public Property id As Guid

        <JsonPropertyName("domainType")>
        Public Property domainType As String

        <JsonPropertyName("label")>
        Public Property label As String

        <JsonPropertyName("aliases")>
        Public Property aliases As Object ' List(Of String)

        <JsonPropertyName("description")>
        Public Property description As String

        <JsonPropertyName("author")>
        Public Property author As String

        <JsonPropertyName("organisation")>
        Public Property organisation As String

        <JsonPropertyName("editable")>
        Public Property editable As Boolean

        <JsonPropertyName("documentationVersion")>
        Public Property documentationVersion As String

        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As Date

        <JsonPropertyName("classifiers")>
        Public Property classifiers() As List(Of Classifier)

        <JsonPropertyName("type")>
        Public Property type As String

        <JsonPropertyName("finalised")>
        Public Property finalised As Boolean

        Public Property metadata As List(Of Metadata)

    End Class

    Public Class Classifier
        <JsonPropertyName("id")>
        Public Property id As Guid

        <JsonPropertyName("label")>
        Public Property label As String
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As Date
    End Class

    Public Class Metadata
        '        {
        '    "id": "c9a36d30-2c6a-4dd0-a792-a337a2eca9c8",
        '    "namespace": "ox.softeng.metadatacatalogue.dataloaders.hdf",
        '    "key": "Volumes",
        '    "value": "Varies annually: in 2013/14, 18.2m finished consultant episodes (FCEs) and 15.5m Finished Admission Episodes (FAEs)",
        '    "lastUpdated": "2019-10-03T09:15:12.082Z"
        '}

        <JsonPropertyName("id")>
        Public Property id As Guid

        <JsonPropertyName("namespace")>
        Public Property mauroNamespace As String

        <JsonPropertyName("key")>
        Public Property key As String

        <JsonPropertyName("value")>
        Public Property value As String
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As Date

    End Class

    Public Class LoginRequest
        Property username As String
        Property password As String
    End Class
End Namespace

