Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text.Json

Imports System.Text.Json.Serialization
Imports System.Text
Imports System.IO

Imports uuid = System.Guid
Imports mandatoryString = System.String
Imports multiplicity = System.Int32

Namespace MauroModel

    Public Class dataTypeDomainTypeEnum : Inherits enumerationValueType

    End Class

    Public Class MauroResponse
        Property url As Uri
        Property Body As String
        Property Response As HttpResponseMessage
    End Class
    Public Class EndpointConnection
        Private Shared ReadOnly client As HttpClient = New HttpClient()
        Public Shared Property Username As String
        Public Shared Property Password As String
        Public Shared Property Endpoint As Uri
        Public Shared Property Timeout As TimeSpan
            Get
                Return client.Timeout
            End Get
            Set(value As TimeSpan)
                client.Timeout = Timeout
            End Set
        End Property
        Public Shared Property Responses As List(Of MauroResponse) = New List(Of MauroResponse)

        Public Shared Property LoginStatus As Boolean = False

        ' Set up basic strings for the API
        Const LoginAPI = "/api/authentication/login"
        Const LogoutAPI = "/api/authentication/logout"
        Const ModelAPI = "/api/dataModels"
        Const ModelAllClassesAPI = "/api/api/dataModels/$MODEL$/allDataClasses"

        Const ModelTemplateAPI = "/api/dataModels/$MODEL$/template"
        Const ModelClassTemplateAPI = "/api/dataModels/$MODEL$/dataClasses/$CLASS$/template"
        Const JSONMime = "application/json"
        Public Shared Property LoginDetails As LoginResponse = Nothing

        Public Shared Function ApplyModelTemplateAsync(ID As Guid, Template As String) As Task(Of PostResponse)
            Dim API As String = Replace(ModelTemplateAPI, "$MODEL$", ID.ToString)
            Try
                Return PostMauroJSON(Endpoint.ToString & API, Template)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Shared Function ApplyModelTemplate(ID As Guid, Template As String) As PostResponse
            Try
                Return ApplyModelTemplateAsync(ID, Template).Result
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Shared Function ApplyModelClassTemplateAsync(ModelID As Guid, ClassID As Guid, Template As String) As Task(Of PostResponse)
            Dim API As String = Replace(ModelClassTemplateAPI, "$MODEL$", ModelID.ToString)
            API = Replace(API, "$CLASS$", ClassID.ToString)
            Try
                Return PostMauroJSON(Endpoint.ToString & API, Template)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Shared Function ApplyModelClassTemplate(ModelID As Guid, ClassID As Guid, Template As String) As PostResponse
            Try
                Return ApplyModelClassTemplateAsync(ModelID, ClassID, Template).Result
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Shared Property MauroModels As Models
        Public Shared Async Function LoginAsync() As Task(Of LoginResponse)

            Dim MauroLogin As New LoginRequest With {.username = Username, .password = Password}
            Dim strBody = JsonSerializer.Serialize(MauroLogin)

            Dim PostResult = Await PostMauroJSON(Endpoint.ToString & LoginAPI, strBody).ConfigureAwait(False)
            Dim JSONResult = PostResult.Body

            LoginDetails = JsonSerializer.Deserialize(Of LoginResponse)(JSONResult)
            LoginStatus = True
            Return LoginDetails
        End Function
        Public Shared Function Login() As LoginResponse
            If LoginStatus = True Then
                Throw New Exception("User is already logged into a Mauro endpoint")
            End If
            Dim response As LoginResponse = LoginAsync.Result
            EndpointConnection.LoginDetails = response
            Return response
        End Function

        Sub New()
            client.Timeout = New TimeSpan(0, 0, 5)
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Mauro Template Serialiser")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(JSONMime))

        End Sub

        Public Shared Async Function GetModelsAsync() As Task(Of Models)
            Dim JSONString = Await GetMauroJSON(ModelAPI).ConfigureAwait(False)
            MauroModels = JsonSerializer.Deserialize(Of Models)(JSONString)
            Return MauroModels
        End Function

        Public Shared Function GetModels() As Models
            Return GetModelsAsync.Result
        End Function

        Public Shared Async Function GetModelAsync(ModelID As Guid) As Task(Of Model)
            Dim JSONString = Await GetMauroJSON(ModelAPI & "/" & ModelID.ToString).ConfigureAwait(False)
            Dim MauroModel = JsonSerializer.Deserialize(Of Model)(JSONString)
            Dim cls As dataClassesType = Await GetModelChildClassesAsync(ModelID)
            Dim desc As dataClassesType = Await GetModelAllClassesAsync(ModelID)
            MauroModel.childDataClasses = cls
            MauroModel.descendantDataClasses = desc

            Return MauroModel
        End Function
        Public Shared Function GetModel(modelID As Guid) As Model

            Dim res As Model = GetModelAsync(modelID).Result


            Return res
        End Function
        Public Shared Async Function GetModelChildClassesAsync(ModelID As Guid) As Task(Of dataClassesType)
            Dim JSONString = Await GetMauroJSON(ModelAPI & "/" & ModelID.ToString & "/dataClasses").ConfigureAwait(False)
            Dim RetMauroClasses = JsonSerializer.Deserialize(Of dataClassesType)(JSONString)
            Return RetMauroClasses
        End Function
        Public Shared Async Function GetModelAllClassesAsync(ModelID As Guid) As Task(Of dataClassesType)
            Dim JSONString = Await GetMauroJSON(ModelAPI & "/" & ModelID.ToString & "/allDataClasses").ConfigureAwait(False)
            Dim RetMauroClasses = JsonSerializer.Deserialize(Of dataClassesType)(JSONString)
            Return RetMauroClasses
        End Function
        Public Shared Function GetModelClasses(ModelID As Guid) As dataClassesType
            Return GetModelChildClassesAsync(ModelID).Result
        End Function
        Public Shared Sub SaveModels(Filename As String)
            Dim JSONFile As New FileStream(Filename, FileMode.Create, FileAccess.Write)
            Dim Writer As New StreamWriter(JSONFile)
            Dim jsonOpt As New JsonSerializerOptions
            jsonOpt.WriteIndented = True

            Dim jsonText As String = JsonSerializer.Serialize(Of Models)(MauroModels, jsonOpt)

            Writer.Write(jsonText)
            Writer.Close()
        End Sub


        Private Shared Async Function GetMauroJSON(API As String) As Task(Of String)

            If LoginStatus = False Then
                Await LoginAsync()
            End If
            ' Async retrieval of Mauro API JSON

            ' Retrieve the JSON from the Mauro endpoint
            Dim GetResult = Await client.GetAsync(Endpoint.ToString & API).ConfigureAwait(False)
            If Not GetResult.IsSuccessStatusCode Then
                Dim ex As New Exception("Error " & GetResult.ReasonPhrase)
                Throw ex
            End If
            Dim JSONResult = Await GetResult.Content.ReadAsStreamAsync.ConfigureAwait(False)
            Dim reader As New StreamReader(JSONResult)

            Dim JSONstring = reader.ReadToEnd()
            Return JSONstring
        End Function

        Private Shared Async Function PostMauroJSON(API As String, BodyText As String) As Task(Of PostResponse)

            ' Async retrieval of Mauro API JSON
            Dim Body As New StringContent(BodyText, Encoding.UTF8, "application/json")
            Dim PostResult As HttpResponseMessage
            Dim Outcome As New PostResponse
            Try
                PostResult = Await client.PostAsync(API, Body).ConfigureAwait(False)
                If Not PostResult.IsSuccessStatusCode Then
                    Dim mr As New MauroResponse With {
                        .url = New Uri(API),
                        .Body = BodyText,
                        .Response = PostResult}
                    EndpointConnection.Responses.Add(mr)
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Dim JSONResult = Await PostResult.Content.ReadAsStreamAsync
            Dim reader As New StreamReader(JSONResult)
            Outcome.Result = PostResult
            Outcome.Body = reader.ReadToEnd()
            Return Outcome
        End Function

        Public Shared Async Function LogoutAsync() As Task(Of String)

            Dim PostResult = Await client.GetAsync(Endpoint.ToString & LogoutAPI).ConfigureAwait(False)

            Dim ResultContent = Await PostResult.Content.ReadAsStringAsync
            Return (ResultContent)
        End Function
        Public Shared Function Logout() As String
            LoginStatus = False
            Return LogoutAsync.Result

        End Function

    End Class


    ''' <summary>
    ''' Class to pass back http post responses
    ''' </summary>
    ''' 
    Public Class PostResponse
        Property Body As String
        Property Result As HttpResponseMessage
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
        Public Property classifiers() As List(Of classifiersType)

        <JsonPropertyName("type")>
        Public Property type As String

        <JsonPropertyName("finalised")>
        Public Property finalised As Boolean

        Public Property metadata As List(Of Metadata)

        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassesType</returns>
        <JsonPropertyName("childDataClasses")>
        Public Property childDataClasses As dataClassesType

        Public Property descendantDataClasses As dataClassesType

    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataClassesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassType</returns>
        ''' 
        <JsonPropertyName("count")>
        Public Property count As Integer

        <JsonPropertyName("items")>
        Public Property dataClass As List(Of dataClassType)
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("alias")>
        Public Property [alias] As String
        ' ############## WARNING ##############
        ' The model uses the Visual Basic keyword alias - this has been escaped to [alias] - Consider refactoring
        ' ############## WARNING ##############
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class metadataType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("namespace")>
        Public Property [namespace] As String
        ' ############## WARNING ##############
        ' The model uses the Visual Basic keyword namespace - this has been escaped to [namespace] - Consider refactoring
        ' ############## WARNING ##############
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As Guid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("key")>
        Public Property key As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("value")>
        Public Property value As String
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataType
    End Class
    Public Class dataClassType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As Guid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassesType</returns>
        <JsonPropertyName("childDataClasses")>
        Public Property childDataClasses As dataClassesType
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("minMultiplicity")>
        Public Property minMultiplicity As multiplicity
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("maxMultiplicity")>
        Public Property maxMultiplicity As multiplicity
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataElementsType</returns>
        <JsonPropertyName("childDataElements")>
        Public Property childDataElements As dataElementsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class annotationsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationType</returns>
        <JsonPropertyName("annotation")>
        Public Property annotation As annotationType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class annotationType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' Only optional if is a child annotation, the top level annotation must have a label 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("childAnnotations")>
        Public Property childAnnotations As annotationsType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifierType</returns>
        <JsonPropertyName("classifier")>
        Public Property classifier As classifierType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class classifierType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
    End Class
    Public Class Classifier
        <JsonPropertyName("id")>
        Public Property id As Guid

        <JsonPropertyName("label")>
        Public Property label As String
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As Date
    End Class

    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataTypeType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataTypeDomainTypeEnum</returns>
        <JsonPropertyName("domainType")>
        Public Property domainType As dataTypeDomainTypeEnum
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' Mandatory if domainType is "ReferenceType". Ignored otherwise 
        ''' </summary>
        ''' <returns>dataClassType</returns>
        <JsonPropertyName("referenceClass")>
        Public Property referenceClass As dataClassType
        ''' <summary>
        ''' Mandatory if domainType is "EnumerationType". Ignored otherwise 
        ''' </summary>
        ''' <returns>enumerationValuesType</returns>
        <JsonPropertyName("enumerationValues")>
        Public Property enumerationValues As enumerationValuesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' Optional if domainType is "PrimitiveType". Ignored otherwise 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("units")>
        Public Property units As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class enumerationValuesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>enumerationValueType</returns>
        <JsonPropertyName("enumerationValue")>
        Public Property enumerationValue As enumerationValueType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class enumerationValueType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("value")>
        Public Property value As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("key")>
        Public Property key As String
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataElementsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataElementType</returns>
        <JsonPropertyName("dataElement")>
        Public Property dataElement As dataElementType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataElementType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' If you've already provided the full DataType information in the DataModel list of DataTypes, then you need only provide the label and domainType here to link to the DataType. If you have not provided all the information at the DataModel level then a DataType will be created using the information provided. 
        ''' </summary>
        ''' <returns>dataTypeType</returns>
        <JsonPropertyName("dataType")>
        Public Property dataType As dataTypeType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("maxMultiplicity")>
        Public Property maxMultiplicity As multiplicity
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("minMultiplicity")>
        Public Property minMultiplicity As multiplicity
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
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

