Imports MauroDataModeller.MauroModel
Imports MauroDataModeller.MauroTemplates

Namespace MauroTemplates.commandline
    Module Program
        ''' <remarks>
        ''' <para>Parameters</para>
        ''' <list type="bullet">
        '''  <item>
        '''   <description>o, outputdir : The file system directory to write the template
        ''' output to</description>
        '''  </item>
        '''  <item>
        '''   <description>u, username : The Mauro endpoint username</description>
        '''  </item>
        '''  <item>
        '''   <description>p, password : The Mauro endpoint password </description>
        '''  </item>
        ''' </list>
        ''' </remarks>
        ''' <param name="args">Command line arguments</param>
        ''' <example>
        ''' MauroTemplateCLI.exe -o&quot;c:\temp&quot; template.json
        ''' </example>

        Sub Main(args As String())
            ' Dim Mauro As New WebAPIClient.EndpointConnection
            Dim strProject As String = ""
            Dim strOutputDir As String = Environment.CurrentDirectory
            Dim strUsername As String = ""
            Dim strPassword As String = ""
            Dim CLArgs() As String = Environment.GetCommandLineArgs
            For i As Integer = 1 To CLArgs.Count - 1 ' Miss the program executable
                Dim s As String = CLArgs(i)

                If Left(s, 1) = "-" Or Left(s, 1) = "/" Then
                    Select Case Mid(s, 2).ToLower
                        Case "o", "outputdir", "out"
                            i += 1
                            strOutputDir = CLArgs(i)
                        Case "u", "user", "username"
                            i += 1
                            strUsername = CLArgs(i)
                        Case "p", "pwd", "pass", "password"
                            i += 1
                            strPassword = CLArgs(i)
                    End Select
                Else
                    strProject = s
                End If
            Next
            Dim template As New Project()

            template.LoadProject(strProject)
            If strUsername <> "" Then
                template.Endpoint.Username = strUsername
            End If
            If strPassword <> "" Then
                template.Endpoint.Password = strPassword
            End If
            'MauroAPI.EndpsointConnection.Login()
            ' MauroAPI.Freemarker.ApplyProject(template, strOutputDir)
            Try
                'MauroAPI.EndpointConnection.GetModelsAsync().Wait()
                'MauroAPI.EndpointConnection.SaveModels("c:\users\nicholas\Models.json")
                ''For Each m As MauroAPI.Model In MauroAPI.EndpointConnection.MauroModels.items
                '    m.childDataClasses = MauroAPI.EndpointConnection.GetModelClasses(m.id)
                '    Console.WriteLine(m.label & " has " & m.childDataClasses.dataClass.Count & " classes.")
                'Next
                EndpointConnection.Logout()
                'Console.WriteLine("There are {0} models", MauroAPI.EndpointConnection.MauroModels.count)
                Console.WriteLine("Completed")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                EndpointConnection.Logout()
                Console.WriteLine("Failed")
            End Try
        End Sub
    End Module
End Namespace
