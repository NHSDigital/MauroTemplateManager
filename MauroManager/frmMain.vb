Imports System.Text.RegularExpressions
Imports System.Text.Json
Imports MauroClasses
Imports MauroClasses.MauroAPI
Imports MauroClasses.MauroAPI.FreemarkerProject

Public Class frmMain

    Public project As FreemarkerProject.Project

    Dim ProjectLoaded As Boolean = False
    Dim ProjectDirty As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshStatus()
    End Sub
    ''' <summary>
    ''' Opens a file and loads the project if valid, updating the form as appropriate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        StatusEndpoint.Text = "Opening ..."
        OpenDialogue.Filter = "Mauro Project JSON|*.json"
        OpenDialogue.Title = "Mauro Project"
        OpenDialogue.DefaultExt = ".json"
        OpenDialogue.ShowDialog()
        project = Nothing
        Try
            project = New FreemarkerProject.Project(OpenDialogue.FileName)

            ' Set up the Project tab

            EndpointConnection.Login()
            EndpointConnection.GetModels()

            ProjectLoaded = True
            ProjectDirty = False
        Catch ex As Exception
            If IsNothing(project) Then
                ProjectLoaded = False
                MsgBox(ex.Message,, "Unable to open file")
            Else
                ProjectLoaded = True
                MsgBox(ex.Message,, "Unable to connect to " & EndpointConnection.Endpoint)
            End If

        End Try
        RefreshStatus()
    End Sub
    ''' <summary>
    ''' Saves the project to JSON to the existing filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        project.SaveProject()
        ProjectDirty = False
        RefreshStatus()
    End Sub

    ''' <summary>
    ''' Saves the project as JSON to a new filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        StatusEndpoint.Text = "Opening ..."
        SaveDialogue.Filter = "Mauro Project JSON|*.json"
        SaveDialogue.Title = "Save Mauro Project as"
        SaveDialogue.DefaultExt = ".json"
        SaveDialogue.FileName = project.Filename

        If SaveDialogue.ShowDialog() = DialogResult.OK Then
            project.SaveProject(SaveDialogue.FileName)
            ProjectDirty = False
        End If
        RefreshStatus()
    End Sub

    ''' <summary>
    ''' Updates the display for the main panel and status bar
    ''' </summary>
    Public Sub RefreshStatus()
        mnuSave.Enabled = ProjectLoaded
        mnuSaveAs.Enabled = ProjectLoaded

        If ProjectLoaded Then

            ' Set up the tabbed dialogue 
            Tabs.Visible = True

            ' Populate endpoint details
            lblFilename.Text = project.Filename
            txtEndpointURL.Text = project.Endpoint.EndpointURL.ToString
            txtUsername.Text = project.Endpoint.Username
            txtPassword.Text = ""
            If project.Filename = "" Then
                mnuSave.Enabled = False
            Else
                mnuSave.Enabled = True
            End If

            ' Set up the status bar
            StatusFilename.Text = project.Filename
            StatusEndpoint.Text = project.Endpoint.EndpointURL.ToString

            'LoginStatus.Text = EndpointConnection.LoginDetails.userRole
            If ProjectDirty Then
                SavedState.Text = "Unsaved changes"
            Else
                SavedState.Text = "No changes"
            End If

            If EndpointConnection.LoginStatus Then
                cmdLogInOut.Text = "Log out"
                If EndpointConnection.LoginDetails.disabled Then
                    LoginStatus.Text = "Account disabled"
                Else
                    LoginStatus.Text = EndpointConnection.LoginDetails.firstName & " " & EndpointConnection.LoginDetails.lastName & " (" & EndpointConnection.LoginDetails.userRole & ")"
                End If
            Else
                cmdLogInOut.Text = "Log in"
                LoginStatus.Text = "Not logged in"
            End If

            ' Update the tabs before repopulating the listboxes
            Application.DoEvents()

            ' Update the model list boxes
            If EndpointConnection.LoginStatus = True Then
                Dim AvailableModels = From m In EndpointConnection.MauroModels.items

                AvailableModels = AvailableModels.Where(Function(x) project.Models.Contains(x.id) = False).OrderBy(Function(x) x.label).ToList

                lstModels.DataSource = AvailableModels.ToList

                lstModels.DisplayMember = "label"
                lstModels.ValueMember = "id"

                Dim AllModels As List(Of Model) = EndpointConnection.MauroModels.items

                Dim SelectedModels = From p In project.Models
                                     Join m In AllModels
                       On p Equals m.id
                                     Select p, m.label

                lstGUIDs.DataSource = SelectedModels.ToList
                lstGUIDs.DisplayMember = "Label"
                lstGUIDs.ValueMember = "p"
            End If
            ' Populate the actions
            lstActions.DataSource = project.Actions
            lstActions.DisplayMember = "Name"
            lstActions.ValueMember = "id"
            RedrawActionList()
        Else
            StatusEndpoint.Text = "Not connected"
            SavedState.Text = "No project loaded"
            StatusFilename.Text = ""

            Tabs.Visible = False
        End If

        ' Update the screen
        Application.DoEvents()


        ' Update the queue
        If ActionEntries.Entries.Count = 0 Then
            Counters.Text = "No actions taken"
            Queue.Visible = False

        Else
            Counters.Text = "Waiting: " & ActionEntries.NotStarted.ToString
            Counters.Text &= " Executing: " & ActionEntries.InProgress.ToString
            Counters.Text &= " Success: " & ActionEntries.Success.ToString
            Counters.Text &= " Fail: " & ActionEntries.Failed.ToString

            Queue.Visible = True
            tvQueue.Nodes.Clear()
            Dim modelID As String = ""
            Dim RootNode As New TreeNode

            Dim q = From Entries In ActionEntries.Entries
                    Order By Entries.Action.Name ' entries.model
            For Each e As ActionEntry In q
                For Each ModelEntry As Guid In e.Model
                    Dim n As New TreeNode With {
                    .Text = e.Action.Name,
                    .Name = e.ID.ToString,
                    .ImageIndex = e.Status}
                    If e.Model.ToString <> modelID Then
                        modelID = e.Model.ToString

                        Dim MdlList As List(Of Model) = EndpointConnection.MauroModels.items
                        Dim mdl = From m In MdlList.Where(Function(x) x.id = ModelEntry)


                        Dim NewLabel As String = ""
                        Dim Tooltip As String = ""
                        If mdl.Count = 1 Then
                            NewLabel = mdl(0).label
                            If Not IsNothing(mdl(0).description) Then
                                Tooltip = mdl(0).description
                            End If
                        Else
                            NewLabel = "Unknown model"
                        End If

                        RootNode = New TreeNode With {
                        .Text = NewLabel,
                        .Tag = e.ID.ToString,
                        .ImageIndex = 4,
                        .ToolTipText = Tooltip
                                                }
                        tvQueue.Nodes.Add(RootNode)
                    End If
                    RootNode.Nodes.Add(n)
                Next
            Next

        End If
        tvQueue.ExpandAll()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Checks the validity of the proposed URL and, if valid,
    ''' Stores the amended URL and sets the flag for unsaved changes.
    ''' Otherwise shows error text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub EndpointURLChanged(sender As Object, e As EventArgs) Handles txtEndpointURL.TextChanged
        If Not IsURLValid(txtEndpointURL.Text) Then
            lblError.Text = "Invalid endpoint URL"
            lblError.Visible = True
        Else
            project.Endpoint.EndpointURL = New Uri(txtEndpointURL.Text)
            lblError.Visible = False
        End If

        SetDirty()
    End Sub
    ''' <summary>
    ''' Stores the amended username and sets the flag for unsaved changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub UsernameChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        project.Endpoint.Username = txtUsername.Text
        SetDirty()
    End Sub

    ''' <summary>
    ''' Stores the amended password and sets the flag for unsaved changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub PasswordChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" Then
            project.Endpoint.Password = txtPassword.Text
            EndpointConnection.Password = txtPassword.Text
            SetDirty()
        End If

    End Sub

    ''' <summary>
    ''' Flags that the project has unsaved changes
    ''' </summary>
    Public Sub SetDirty()
        ProjectDirty = True
        SavedState.Text = "Unsaved changes"
    End Sub
    ''' <summary>
    ''' Check whether a string is a valid URL
    ''' </summary>
    ''' <param name="URL">String to check</param>
    ''' <returns>True if the string matches the Regex for a URL, otherwise false.</returns>
    Public Function IsURLValid(URL As String) As Boolean
        Dim pattern As String
        pattern = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
        Return Regex.IsMatch(URL, pattern)
    End Function

    ''' <summary>
    ''' Exit the program
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If EndpointConnection.LoginStatus Then
            EndpointConnection.Logout()
        End If
        Application.Exit()
    End Sub

    Private Sub cmdAddAction_Click(sender As Object, e As EventArgs) Handles cmdAddAction.Click
        Dim act As New FreemarkerProject.FreemarkerAction With {
            .ActionType = MauroAPI.FreemarkerProject.ActionTypes.actionSingleModel,
            .FilePrefix = "Model_",
            .FileSuffix = ".txt",
            .Template = "",
            .Name = "(New template)",
            .Description = "No description",
            .id = Guid.NewGuid
        }
        project.Actions.Add(act)
        RedrawActionList()
    End Sub

    Private Sub PrefixChanged(sender As Object, e As EventArgs) Handles TextFilePrefix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).FilePrefix = TextFilePrefix.Text
        SetDirty()
    End Sub

    Private Sub TemplateChanged(sender As Object, e As EventArgs) Handles txtTemplate.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).Template = txtTemplate.Text
        SetDirty()

    End Sub

    Private Sub SuffixChanged(sender As Object, e As EventArgs) Handles textFileSuffix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).FileSuffix = textFileSuffix.Text
        SetDirty()
    End Sub

    Private Sub RefreshActions(sender As Object, e As EventArgs) Handles lstActions.SelectedIndexChanged

        If lstActions.SelectedIndex >= 0 Then
            With CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction)
                textName.Text = .Name
                textDesription.Text = .Description

                TextFilePrefix.Text = .FilePrefix
                textFileSuffix.Text = .FileSuffix

                txtTemplate.Text = .Template
                Select Case .ActionType
                    Case MauroAPI.FreemarkerProject.ActionTypes.actionClass
                        rbClass.Checked = True
                    Case MauroAPI.FreemarkerProject.ActionTypes.actionSingleModel
                        rbModel.Checked = True

                    Case MauroAPI.FreemarkerProject.ActionTypes.actionTerminology
                        rbTerminology.Checked = True
                End Select
            End With
        End If

    End Sub
    ''' <summary>
    ''' Update the actionType to reflect the radiobutton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ActionTypeChanged(sender As Object, e As EventArgs) Handles rbModel.CheckedChanged, rbClass.CheckedChanged, rbTerminology.CheckedChanged
        If rbModel.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = MauroAPI.FreemarkerProject.ActionTypes.actionSingleModel
        ElseIf rbClass.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = MauroAPI.FreemarkerProject.ActionTypes.actionClass
        ElseIf rbAllModels.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = MauroAPI.FreemarkerProject.ActionTypes.actionAllModels

        Else
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = MauroAPI.FreemarkerProject.ActionTypes.actionTerminology
        End If

        SetDirty()
    End Sub

    Private Sub ActionNameChanged(sender As Object, e As EventArgs) Handles textName.Leave
        Try
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).Name = textName.Text
            RedrawActionList()
        Catch ex As Exception
        End Try

        SetDirty()
    End Sub

    Private Sub ActionDesciptionChanged(sender As Object, e As EventArgs) Handles textDesription.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).Description = textDesription.Text
        SetDirty()
    End Sub

    Public Sub RedrawActionList()
        Dim selIndex As Integer = lstActions.SelectedIndex

        lstActions.DataSource = Nothing
        lstActions.DataSource = project.Actions
        lstActions.DisplayMember = "Name"
        lstActions.ValueMember = "id"
        lstActions.SelectedIndex = selIndex

        If lstActions.Items.Count > 0 Then
            scActions.Panel2.Enabled = True
        Else
            scActions.Panel2.Enabled = False

        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        For Each itm As Model In lstModels.SelectedItems
            project.Models.Add(itm.id)
        Next
        RefreshStatus()
    End Sub

    Private Sub cmdLogInOut_Click(sender As Object, e As EventArgs) Handles cmdLogInOut.Click
        If EndpointConnection.LoginStatus Then
            EndpointConnection.Logout()
        Else
            EndpointConnection.Login()
        End If
        RefreshStatus()
    End Sub

    Private Sub cmdSingleAction_Click(sender As Object, e As EventArgs) Handles cmdSingleAction.Click
        Dim act As FreemarkerProject.FreemarkerAction = lstActions.SelectedItem
        Dim OutputDirectory As String = "C:\git\TemplateOutput"

        If project.Models.Count = 0 Then ' Process all the models
            'For Each m As Model In EndpointConnection.GetModels.items
            '    Dim mdlList As New List(Of Guid)
            '    mdlList.Add(m.id)
            '    Dim newEntry As New ActionEntry With {
            '        .Status = ActionOutcomeStatus.NotStarted,
            '        .Action = act,
            '        .OutputDirectory = OutputDirectory,
            '        .Model = mdlList}
            '    ActionEntries.Entries.Add(newEntry)

            'Next
            Throw New DataException("No models selected")
        Else
            Dim mdlList As New List(Of Guid)
            For Each id As Guid In project.Models
                mdlList.Add(id)
            Next
            Dim newEntry As New ActionEntry With {
                    .Status = ActionOutcomeStatus.NotStarted,
                    .Action = act,
                      .OutputDirectory = OutputDirectory,
                    .Model = mdlList}
            ActionEntries.Entries.Add(newEntry)

        End If
        Tabs.SelectedIndex = 3
        Application.DoEvents()
        RunActionEntryQueue()
        'StartActionEntryQueueAsync()
        ' TimerReset()
    End Sub

    Private Sub cmdDoAll_Click(sender As Object, e As EventArgs) Handles cmdDoAll.Click
        Tabs.SelectedIndex = 3
        Application.DoEvents()
        MauroAPI.Freemarker.QueueProjectActionEntries(project, "c:\git\templateoutput")
        Application.DoEvents()
        StartActionEntryQueueAsync()
        TimerReset()

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)
        RefreshStatus()
    End Sub

    Private Sub TimerElapsed(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimerReset()
    End Sub

    Public Sub TimerReset()
        Timer1.Enabled = False
        Dim q, i, s, f As Integer
        q = ActionEntries.NotStarted
        i = ActionEntries.InProgress
        s = ActionEntries.Success
        f = ActionEntries.Failed
        Debug.WriteLine("Q:{0} I:{1} S:{2} F:{3}", q, i, s, f)
        Dim Total As Integer = q + i + s + f
        QueueProgress.Maximum = Total
        QueueProgress.Value = s + f
        If q = 0 And i = 0 Then
            RefreshStatus()
        Else
            Timer1.Enabled = True
            Timer1.Start()
        End If
        Application.DoEvents()
        If q > 0 And i = 0 Then
            ' Restart the queue
            StartActionEntryQueueAsync()
        End If
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        project = New FreemarkerProject.Project
        ProjectLoaded = True
        RefreshStatus()
    End Sub
    Private Function PrettyJson(ByVal unPrettyJson As String) As String
        Dim options = New JsonSerializerOptions() With {
        .WriteIndented = True
    }
        Dim jsonElement = JsonSerializer.Deserialize(Of JsonElement)(unPrettyJson)
        Return JsonSerializer.Serialize(jsonElement, options)
    End Function
    Private Sub UpdateActionEntryResult(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvQueue.NodeMouseClick
        Dim n As TreeNode = e.Node
        Dim g As Guid
        Try
            g = Guid.Parse(n.Name)
            Dim ae As ActionEntry = ActionEntries.Entries.Find(Function(x) x.ID = g)
            For Each pr As PostResponse In ae.postResponses
                If Not IsNothing(ae) And Not IsNothing(ae.postResponses) Then
                    Dim ResponseText As String = pr.Body
                    Try
                        ResponseText = PrettyJson(ResponseText)
                    Catch
                    End Try
                    txtPostBody.Text &= ResponseText
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
End Class
