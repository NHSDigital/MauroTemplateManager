Imports System.IO
Imports System.Text.Json
Imports System.Text.RegularExpressions
Imports System.Threading
Imports MauroDataModeller.MauroModel
Namespace MauroTemplates
    Public Module Freemarker
        ''' <summary>
        ''' Executes all the template actions in a project against all the models in that project
        ''' </summary>
        ''' <param name="Project">Project containing the models and actions</param>
        ''' <param name="OutputDirectory">Filepath as a string for the output directory.  If not specified the application current directory is used.</param>
        Public Sub QueueProjectActionEntries(Project As Project, Optional OutputDirectory As String = "")

            ' If the current directory isn't specified, use the applicaiton's current directory 
            If OutputDirectory = "" Then OutputDirectory = Environment.CurrentDirectory

            If IsNothing(Project.Endpoint) Then
                Dim ex As New InvalidFreemarkerProjectException("The endpoint has not been defined")
            End If

            If Project.Models.Count = 0 Then
                Dim ex As New InvalidFreemarkerProjectException("There are no models available in the project")
            End If

            If Project.Actions.Count = 0 Then
                Dim ex As New InvalidFreemarkerProjectException("There are no actions defined in the project")
            End If

            If Project.Models.Count = 0 Then ' Process all the models
                Dim ex As New Exception("No models selected")
            End If
            For Each act In Project.Actions

                If act.ActionType = ActionTypes.actionAllModels Then

                    Dim ae As New ActionEntry With {
                            .Action = act,
                            .ModelIDs = Project.Models,
                            .OutputDirectory = OutputDirectory,
                            .Status = ActionOutcomeStatus.NotStarted}
                    ActionEntries.Entries.Add(ae)
                Else

                    For Each id As Guid In Project.Models
                        Dim m As Model = EndpointConnection.GetModel(id)
                        Dim lstModel As New List(Of Guid)
                        lstModel.Add(m.id)
                        Dim ae As New ActionEntry With {
                            .Action = act,
                            .ModelIDs = lstModel,
                            .OutputDirectory = OutputDirectory,
                            .Status = ActionOutcomeStatus.NotStarted}
                        ActionEntries.Entries.Add(ae)
                        'ProcessActionForModel(m, act, OutputDirectory)
                    Next
                End If
            Next
        End Sub
        ''' <summary>
        ''' Checks the queue of pending action entries and if there are less than the limit in progress, initiates separate threads for pending entries up to the limit.
        ''' </summary>
        ''' <param name="limit">MAximum number of threads to be running at once</param>
        Public Sub StartActionEntryQueueAsync(limit As Integer)
            Dim i As Integer = 0
            For Each ae As ActionEntry In ActionEntries.Entries.Where(Function(x) x.Status = ActionOutcomeStatus.NotStarted)
                ' newEntry.Start()
                Dim Evaluator = New Thread(Sub() ProcessActionEntry(ae))
                Evaluator.Name = ae.ActionEntryID.ToString
                Evaluator.Start()
                i += 1
                If i > limit Then Exit For
            Next
        End Sub

        ''' <summary>
        ''' Run all the pending action entries in the queue synchronously.
        ''' </summary>
        ''' <remarks>
        ''' It is recommended StartActionEntryQueueAsync
        ''' </remarks>
        Public Sub RunActionEntryQueueSync()
            For Each ae As ActionEntry In ActionEntries.Entries.Where(Function(x) x.Status = ActionOutcomeStatus.NotStarted)
                ProcessActionEntry(ae)
            Next
        End Sub
        ''' <summary>
        ''' Execute a single action for a single model
        ''' </summary>
        ''' <param name="MauroModel">Model metadata to execute against</param>
        ''' <param name="Action">Action to execute</param>
        ''' <param name="OutputDirectory">Filepath as a string for the output directory</param>
        Public Sub ProcessActionForModel(MauroModel As Model, Action As FreemarkerAction, OutputDirectory As String, ByRef ActionResponses As List(Of ActionResponse))
            Debug.WriteLine("ProcessActionForModel with {0}, {1}", MauroModel.label, Action.Name)

            Dim SuccessCount As Integer = 0
            Dim FailCount As Integer = 0
            ' Dim res As New List(Of ActionResponse)

            Select Case Action.ActionType ' Apply to the model

                Case ActionTypes.actionSingleModel
                    ActionResponses.Add(ProcessOneModel(MauroModel, Action, OutputDirectory))

                Case ActionTypes.actionAllModels
                    Throw New NotImplementedException("ProcessActionForModel: actionAllModels not supported ")

                Case ActionTypes.actionClass ' Apply to a class within the model
                    MauroModel.childDataClasses = EndpointConnection.GetModelClasses(MauroModel.id)
                    For Each dataClass In MauroModel.descendantDataClasses.dataClass
                        ActionResponses.AddRange(ProcessModelClass(MauroModel, dataClass, Action, OutputDirectory))

                    Next
                Case ActionTypes.actionTerminology ' Apply to a teminology within a model
                    Throw New NotImplementedException
            End Select

            For Each ActResp As ActionResponse In ActionResponses

                If IsNothing(ActResp) Then
                    FailCount += 1
                ElseIf ActResp.responseOutcome = ActionOutcomeStatus.Failed Then
                    FailCount += 1
                ElseIf ActResp.Response.Result.IsSuccessStatusCode Then
                    SuccessCount += 1
                Else
                    FailCount += 1
                End If
            Next

        End Sub

        ''' <summary>
        ''' Executes an ActionEntrt definition against the current endpoint
        ''' </summary>
        ''' <param name="ActionEntry">Action template and list of models to apply</param>
        Public Sub ProcessActionEntry(ByRef ActionEntry As ActionEntry)
            ActionEntry.Status = ActionOutcomeStatus.InProgress

            ' Dim res As New List(Of ActionResponse)
            Try
                If ActionEntry.Action.ActionType = ActionTypes.actionAllModels Then
                    Try
                        ActionEntry.ActionResponses = ProcessAllModels(ActionEntry.ModelIDs, ActionEntry.Action, ActionEntry.OutputDirectory)
                        ActionEntry.Status = ActionOutcomeStatus.Success

                    Catch ex As Exception
                        ActionEntry.Status = ActionOutcomeStatus.Retry
                        ActionEntry.ActionResponses.Add(New ActionResponse With {
                            .ResponseDescription = ex.Message,
                                .ResponseID = Guid.NewGuid,
                        .responseOutcome = ActionOutcomeStatus.Failed
                            })

                    End Try
                Else
                    For Each m As Guid In ActionEntry.ModelIDs

                        Dim MauroModel As Model = EndpointConnection.GetModel(m)
                        ActionEntry.Status = ActionOutcomeStatus.InProgress
                        Try
                            ProcessActionForModel(MauroModel, ActionEntry.Action, ActionEntry.OutputDirectory, ActionEntry.ActionResponses)
                            ActionEntry.Status = ActionOutcomeStatus.Success

                        Catch ex As Exception
                            ActionEntry.Status = ActionOutcomeStatus.Retry
                            ActionEntry.ActionResponses.Add(New ActionResponse With {
                                .ResponseDescription = ex.Message,
                                .Response = Nothing,
                                .ResponseID = Guid.NewGuid,
                            .responseOutcome = ActionOutcomeStatus.Failed
                                })
                        End Try

                    Next
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        ''' <summary>
        ''' Show a JSON file indented
        ''' </summary>
        ''' <remarks>
        ''' Applies JSON serialisation with writeIndented = true
        ''' </remarks>
        ''' <param name="uglyJSON">JSON text in minifieed or inconsistent form</param>
        ''' <returns>
        ''' JSON text in pretty form
        ''' </returns>
        Public Function PrettyJson(ByVal uglyJSON As String) As String
            Dim options = New JsonSerializerOptions() With {
        .WriteIndented = True
    }

            Dim jsonElement = JsonSerializer.Deserialize(Of JsonElement)(uglyJSON)


            Dim s As String = JsonSerializer.Serialize(jsonElement, options)
            ' s = Replace(s, vbCrLf, "</br>")
            s = Replace(s, "\u0022", """")
            s = Replace(s, "\t", vbTab)
            s = Replace(s, "\n", vbCrLf)
            Return s
        End Function
        ''' <param name="MauroModel">The Mauro model to apply the template to</param>
        ''' <param name="MauroClass">The class within the model to apply the template
        ''' to</param>
        ''' <param name="Action">The action / template to apply</param>
        ''' <param name="OutputDirectory">The directory to store the output file in</param>
        ''' <returns>
        ''' A list of actionresponses
        ''' </returns>
        Private Function ProcessModelClass(MauroModel As Model, MauroClass As dataClassType, Action As FreemarkerAction, OutputDirectory As String) As List(Of ActionResponse)
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label & " - " & MauroClass.label) & Action.FileSuffix

            Dim ResList As New List(Of ActionResponse)
            Dim ActResp As New ActionResponse With {
                .ResponseDescription = MauroClass.label,
                .ResponseID = Guid.NewGuid
            }
            Try
                ' Apply the template
                ActResp.Response = EndpointConnection.ApplyModelClassTemplate(MauroModel.id, MauroClass.id, Action.Template)

                ' Handle the output
                If ActResp.Response.Result.IsSuccessStatusCode Then
                    Dim fstream As New FileStream(fname, FileMode.Create)
                    Dim fwriter As New StreamWriter(fstream)

                    ActResp.responseOutcome = ActionOutcomeStatus.Success
                    fwriter.Write(ActResp.Response.Body)
                    Console.WriteLine(" - success")
                    fwriter.Close()
                    fstream.Close()
                Else
                    ActResp.responseOutcome = ActionOutcomeStatus.Success
                    fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroClass.label) & "_error.html"

                    Dim fstream As New FileStream(fname, FileMode.Create)
                    Dim fwriter As New StreamWriter(fstream)
                    WriteErrorFile(fwriter, Action, ActResp.Response)
                    fwriter.Close()
                    fstream.Close()
                    Console.WriteLine(" - error")
                End If
                ResList.Add(ActResp)
            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)
            End Try
            Return ResList
        End Function

        ''' <summary>
        ''' Create a sparse error file in HTML showing the error and the template
        ''' </summary>
        ''' <param name="FileStream">Destination filestream</param>
        ''' <param name="Action">Freemarker action causing the error</param>
        ''' <param name="Response">The http response from the API</param>
        Public Sub WriteErrorFile(FileStream As StreamWriter, Action As FreemarkerAction, Response As PostResponse)
            ' Write out the error

            FileStream.WriteLine("<html><head><title>Error</title></head>")
            FileStream.WriteLine("<body>")
            FileStream.Write("<h1>Error - " & Response.Result.ReasonPhrase)

            FileStream.WriteLine("</h1>")
            FileStream.WriteLine("<p>")
            Dim s As String = Response.Body
            Try
                s = PrettyJson(s)
                s = Replace(s, "\t", " ")
                s = Replace(s, "\n", "</br>")
                s = Replace(s, " ", "&nbsp;")
            Catch ex As Exception
                ' leave alone if not pretty
            End Try
            FileStream.Write(s)
            FileStream.WriteLine("</p>")
            FileStream.WriteLine("<h2>Original template</h2>")
            FileStream.WriteLine("<p>")
            FileStream.WriteLine("<table>")
            FileStream.WriteLine("<thead><th>Line</th><th></th></thead>")
            Dim i As Integer = 1
            For Each l As String In Action.Template.Split(vbCrLf)
                FileStream.WriteLine("<tr>")
                FileStream.WriteLine("<td>" & i.ToString & "</td>")
                FileStream.WriteLine("<td>" & System.Net.WebUtility.HtmlEncode(l) & "</td>")
                FileStream.WriteLine("</tr>")
                i += 1
            Next
            FileStream.WriteLine("</table>")
            FileStream.WriteLine("</p>")
            FileStream.WriteLine("</body>")
            FileStream.WriteLine("</html>")
        End Sub
        ''' <summary>
        ''' Execute a template against a model
        ''' </summary>
        ''' <param name="MauroModel">Model to excecute the template against</param>
        ''' <param name="Action">The action (including template) to execute</param>
        ''' <param name="OutputDirectory"></param>
        Private Function ProcessOneModel(MauroModel As Model, Action As FreemarkerAction, OutputDirectory As String) As ActionResponse
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label) & Action.FileSuffix
            Console.Write(fname)

            Dim ActResp As ActionResponse = Nothing
            Try
                ' Apply the template
                ActResp = New ActionResponse With {
                 .ResponseID = Guid.NewGuid,
                 .ResponseDescription = MauroModel.label,
                 .OutputFilename = fname,
                 .ErrorFileName = ""
                }

                ActResp.Response = EndpointConnection.ApplyModelTemplate(MauroModel.id, Action.Template)
                ' Handle the output
                If ActResp.Response.Result.IsSuccessStatusCode Then
                    Dim fstream As New FileStream(fname, FileMode.Create)
                    Dim fwriter As New StreamWriter(fstream)

                    ActResp.responseOutcome = ActionOutcomeStatus.Success
                    fwriter.Write(ActResp.Response.Body)
                    Console.WriteLine(" - success")
                    fwriter.Close()
                    fstream.Close()
                Else
                    ActResp.responseOutcome = ActionOutcomeStatus.Failed

                    ' Write out the error
                    fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label) & "_error.html"
                    ActResp.ErrorFileName = fname
                    Dim fstream As New FileStream(fname, FileMode.Create)
                    Dim fwriter As New StreamWriter(fstream)
                    WriteErrorFile(fwriter, Action, ActResp.Response)
                    fwriter.Close()
                    fstream.Close()
                    Console.WriteLine(" - error")
                End If

            Catch ex As Exception
                Console.WriteLine()

                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)

            End Try
            Return ActResp
        End Function
        Private Function ProcessAllModels(Models As List(Of Guid), Action As FreemarkerAction, OutputDirectory As String) As List(Of ActionResponse)
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & Action.FileSuffix
            Console.Write(fname)
            Dim Res As New List(Of ActionResponse)
            Try
                ' Apply the template to each model
                For Each m As Guid In Models
                    Dim PR As PostResponse = EndpointConnection.ApplyModelTemplate(m, Action.Template)
                    ' Handle the output
                    If PR.Result.IsSuccessStatusCode Then

                        Dim fstream As New FileStream(fname, FileMode.OpenOrCreate)
                        Dim fwriter As New StreamWriter(fstream)

                        fwriter.Write(PR.Body)
                        Console.WriteLine(" - success")
                        fwriter.Close()
                        fstream.Close()
                    Else
                        ' Write out the error
                        fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & "_error.html"
                        Dim fstream As New FileStream(fname, FileMode.Create)
                        Dim fwriter As New StreamWriter(fstream)
                        fwriter.Write(PR.Result.ReasonPhrase)
                        Console.WriteLine(" - error")
                        fwriter.Close()
                        fstream.Close()
                        Exit For
                    End If
                Next

            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)
            End Try
            Return Res
        End Function
        Private Function RemoveIllegalFileNameChars(input As String, Optional replacement As String = "") As String
            Dim regexSearch = New String(Path.GetInvalidFileNameChars()) & New String(Path.GetInvalidPathChars())
            Dim r = New Regex(String.Format("[{0}]", Regex.Escape(regexSearch)))
            Return r.Replace(input, replacement)
        End Function

        Private Sub DumpQueue()
            For Each ae As ActionEntry In ActionEntries.Entries
                Debug.WriteLine(ae.ActionEntryID.ToString & ae.Action.Name & " - " & ae.ActionResponses.Count.ToString & " - " & ae.Status.ToString)
            Next
        End Sub
    End Module
    Public Class InvalidFreemarkerProjectException
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