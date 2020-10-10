Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports MauroClasses.MauroAPI.FreemarkerProject

Namespace MauroAPI
    Public Module Freemarker

        Const ModelTemplateAPI = "/api/dataModels/$MODEL$/template"
        ''' <summary>
        ''' Executes all the template actions in a project against all the models in that project
        ''' </summary>
        ''' <param name="Project">Project containing the models and actions</param>
        ''' <param name="OutputDirectory">Filepath as a string for the output directory.  If not specified the application current directory is used.</param>
        Public Sub QueueProjectActionEntries(Project As FreemarkerProject.Project, Optional OutputDirectory As String = "")

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
                            .Model = Project.Models,
                            .OutputDirectory = OutputDirectory,
                            .Status = ActionOutcomeStatus.NotStarted}
                    ActionEntries.Entries.Add(ae)
                Else

                    For Each id As Guid In Project.Models
                        Dim m As Model = EndpointConnection.GetModel(id)
                        Dim lstModel As New List(Of Guid)
                        lstModel.add(m.id)
                        Dim ae As New ActionEntry With {
                            .Action = act,
                            .Model = lstmodel,
                            .OutputDirectory = OutputDirectory,
                            .Status = ActionOutcomeStatus.NotStarted}
                        ActionEntries.Entries.Add(ae)
                        'ProcessActionForModel(m, act, OutputDirectory)
                    Next
                End If


                'End If

            Next
        End Sub

        Public Sub StartActionEntryQueueAsync(Optional limit As Integer = 20)
            Dim i As Integer = 0
            For Each ae As ActionEntry In ActionEntries.Entries.Where(Function(x) x.Status = ActionOutcomeStatus.NotStarted)
                ' newEntry.Start()
                Dim Evaluator = New Thread(Sub() ProcessActionEntry(ae))
                Evaluator.Name = ae.ID.ToString
                Evaluator.Start()
                i += 1
                If i > limit Then Exit For
            Next
        End Sub

        Public Sub RunActionEntryQueue()
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
        Public Function ProcessActionForModel(MauroModel As Model, Action As FreemarkerProject.FreemarkerAction, OutputDirectory As String) As PostResponse
            Debug.WriteLine("ProcessActionForModel with {0}, {1}", MauroModel.label, Action.Name)

            Dim SuccessCount As Integer = 0
            Dim FailCount As Integer = 0
            Dim pr As PostResponse = Nothing

            Select Case Action.ActionType ' Apply to the model

                Case ActionTypes.actionSingleModel
                    pr = ProcessModelOnly(MauroModel, Action, OutputDirectory)
                    If IsNothing(pr) Then
                        FailCount += 1
                    ElseIf pr.Result.IsSuccessStatusCode Then
                        SuccessCount += 1
                    Else
                        FailCount += 1
                    End If
                Case ActionTypes.actionAllModels
                    Throw New NotImplementedException("ProcessActionForModel: actionAllModels not supported ")

                Case ActionTypes.actionClass ' Apply to a class within the model
                    MauroModel.childDataClasses = EndpointConnection.GetModelClasses(MauroModel.id)
                    For Each dataClass In MauroModel.childDataClasses.dataClass
                        pr = ProcessModelClass(MauroModel, dataClass, Action, OutputDirectory)
                        If IsNothing(pr) Then
                            FailCount += 1
                        ElseIf pr.Result.IsSuccessStatusCode Then
                            SuccessCount += 1
                        Else
                            FailCount += 1
                        End If
                    Next
                Case ActionTypes.actionTerminology ' Apply to a teminology within a model
                    Throw New NotImplementedException
            End Select

            Return pr
        End Function

        Public Sub ProcessActionEntry(ActionEntry As ActionEntry)
            Dim res As New List(Of PostResponse)
            Try
                If ActionEntry.Action.ActionType = ActionTypes.actionAllModels Then
                    res = ProcessAllModels(ActionEntry.Model, ActionEntry.Action, ActionEntry.OutputDirectory)
                Else
                    For Each m As Guid In ActionEntry.Model
                        Dim MauroModel As Model = EndpointConnection.GetModel(m)
                        ActionEntry.Status = ActionOutcomeStatus.InProgress

                        res.Add(ProcessActionForModel(MauroModel, ActionEntry.Action, ActionEntry.OutputDirectory))
                    Next
                End If

            Catch ex As Exception
            End Try

            ActionEntry.postResponses = res
            ActionEntry.Status = ActionOutcomeStatus.Success
            If res.Count = 0 Then
                ActionEntry.Status = ActionOutcomeStatus.Failed
            Else
                For Each PR As PostResponse In res
                    If Not PR.Result.IsSuccessStatusCode Then
                        ActionEntry.Status = ActionOutcomeStatus.Failed
                    End If
                Next
            End If

        End Sub


        'Public Sub ProcessActionForModelID(MauroModelID As Guid, Action As FreemarkerProject.FreemarkerAction, OutputDirectory As String)
        '    Dim MauroModel As Model = EndpointConnection.GetModel(MauroModelID)

        '    Console.WriteLine(MauroModel.label)
        '    ProcessActionForModel(MauroModel, Action, OutputDirectory)

        'End Sub


        Private Function ProcessModelClass(MauroModel As Model, MauroClass As dataClassType, Action As FreemarkerProject.FreemarkerAction, OutputDirectory As String) As PostResponse
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label & " - " & MauroClass.label) & Action.FileSuffix
            Console.Write(fname)

            Dim fstream As New FileStream(fname, FileMode.Create)
            Dim fwriter As New StreamWriter(fstream)
            Dim Res As PostResponse = Nothing

            Try
                ' Apply the template
                res = EndpointConnection.ApplyModelClassTemplate(MauroModel.id, MauroClass.id, Action.Template)
                ' Handle the output
                If Res.Result.IsSuccessStatusCode Then
                    fwriter.Write(Res.Body)
                    Console.WriteLine(" - success")
                    fwriter.Close()
                    fstream.Close()
                Else
                    fwriter.Close()
                    fstream.Close()
                    File.Delete(fname)

                    ' Write out the error
                    fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroClass.label) & "_error.html"
                    fstream = New FileStream(fname, FileMode.Create)
                    fwriter = New StreamWriter(fstream)
                    fwriter.Write(Res.Result.ReasonPhrase)
                    fwriter.Close()
                    fstream.Close()
                    Console.WriteLine(" - error")
                End If

            Catch ex As Exception
                Console.WriteLine()
                fwriter.Write(ex.Message)
                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)
                fwriter.Close()
                fstream.Close()
            End Try
            Return Res
        End Function
        Private Function ProcessModelOnly(MauroModel As Model, Action As FreemarkerProject.FreemarkerAction, OutputDirectory As String) As PostResponse
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label) & Action.FileSuffix
            Console.Write(fname)

            Dim fstream As New FileStream(fname, FileMode.Create)
            Dim fwriter As New StreamWriter(fstream)
            Dim Res As PostResponse = Nothing
            Try
                ' Apply the template
                Res = EndpointConnection.ApplyModelTemplate(MauroModel.id, Action.Template)
                ' Handle the output
                If Res.Result.IsSuccessStatusCode Then
                    fwriter.Write(Res.Body)
                    Console.WriteLine(" - success")
                    fwriter.Close()
                    fstream.Close()
                Else
                    fwriter.Close()
                    fstream.Close()
                    File.Delete(fname)

                    ' Write out the error
                    fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & RemoveIllegalFileNameChars(MauroModel.label) & "_error.html"
                    fstream = New FileStream(fname, FileMode.Create)
                    fwriter = New StreamWriter(fstream)
                    fwriter.Write(Res.Result.ReasonPhrase)
                    fwriter.Close()
                    fstream.Close()
                    Console.WriteLine(" - error")
                End If

            Catch ex As Exception
                Console.WriteLine()
                fwriter.Write(ex.Message)
                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)
                fwriter.Close()
                fstream.Close()
            End Try
            Return Res
        End Function
        Private Function ProcessAllModels(Models As List(Of Guid), Action As FreemarkerProject.FreemarkerAction, OutputDirectory As String) As List(Of PostResponse)
            Dim fname As String = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & Action.FileSuffix
            Console.Write(fname)

            Dim fstream As New FileStream(fname, FileMode.OpenOrCreate)
            Dim fwriter As New StreamWriter(fstream)
            Dim Res As New List(Of PostResponse)
            Try
                ' Apply the template to each model
                For Each m As Guid In Models
                    Dim PR As PostResponse = EndpointConnection.ApplyModelTemplate(m, Action.Template)
                    ' Handle the output
                    If PR.Result.IsSuccessStatusCode Then
                        fwriter.Write(PR.Body)
                        Console.WriteLine(" - success")

                    Else
                        fwriter.Close()
                        fstream.Close()
                        File.Delete(fname)

                        ' Write out the error
                        fname = OutputDirectory & System.IO.Path.DirectorySeparatorChar & Action.FilePrefix & "_error.html"
                        fstream = New FileStream(fname, FileMode.Create)
                        fwriter = New StreamWriter(fstream)
                        fwriter.Write(PR.Result.ReasonPhrase)
                        Console.WriteLine(" - error")
                        Exit For
                    End If
                Next
                fwriter.Close()
                fstream.Close()
            Catch ex As Exception
                Console.WriteLine()
                fwriter.Write(ex.Message)
                Console.WriteLine("Failed to generate " & fname & " - " & ex.Message)
                fwriter.Close()
                fstream.Close()
            End Try
            Return Res
        End Function
        Private Function RemoveIllegalFileNameChars(input As String, Optional replacement As String = "") As String
            Dim regexSearch = New String(Path.GetInvalidFileNameChars()) & New String(Path.GetInvalidPathChars())
            Dim r = New Regex(String.Format("[{0}]", Regex.Escape(regexSearch)))
            Return r.Replace(input, replacement)
        End Function
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