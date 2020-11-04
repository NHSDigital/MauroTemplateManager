Imports System.Text.RegularExpressions
Imports System.Text.Json
Imports ScintillaNET
Imports ScintillaPrinting
Imports MauroDataModeller.MauroTemplates
Imports MauroDataModeller.MauroModel
Imports MauroDataModeller.Settings


Public Class frmMain

    Public project As Project

    Dim ProjectLoaded As Boolean = False
    Private locDirty As Boolean = False
    Private Property ProjectDirty As Boolean
        Get
            Return locDirty
        End Get
        Set(value As Boolean)
            If value Then
                SavedState.Text = "Unsaved changes"
            Else
                SavedState.Text = "No changess"
            End If
            locDirty = value
        End Set
    End Property

    Dim AppSettings As New ApplicationSettings("Mauro")
    Dim RecentFiles As List(Of ApplicationSettings.AppSetting)

    Private Sub MauroDataManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Hard coded the toolbar locations
        tsFile.Location = New Point(0, 0)
        tsProcess.Location = New Point(tsFile.Width, 0)
        tsPrinting.Location = New Point(tsProcess.Location.X + tsProcess.Width, 0)

        RefreshStatus()
        RefreshRecentFileList()
        RefreshQueue()

        InitColors(txtTemplate)
        InitColors(txtPostBody)
        InitSyntaxColoring(txtTemplate)
        InitSyntaxColoring(txtPostBody)

        InitNumberMargin(txtTemplate)
        InitNumberMargin(txtPostBody)

    End Sub

#Region "File open, save, close"
    ''' <summary>
    ''' Creates a new Mauro Template Manager project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click, tsNewProject.Click

        Dim DefaultURI As Uri
        Dim EndpointURL As String = AppSettings.GetAppSetting("EndpointConnection", "https://localhost")
        Dim Username As String = AppSettings.GetAppSetting("DefaultUsername")
        Dim Password As String = AppSettings.GetPasswordAppSetting()

        Try
            DefaultURI = New Uri(EndpointURL)
        Catch ex As Exception
            DefaultURI = New Uri("https://localhost")
        End Try
        project = New Project(DefaultURI, Username, Password)
        If Not EndpointConnection.LoginStatus Then
            EndpointConnection.Login()
        End If

        EndpointConnection.GetModels()

        txtEndpointURL.Text = project.Endpoint.EndpointURL.ToString
        txtUsername.Text = project.Endpoint.Username
        txtPassword.Text = ""
        ProjectLoaded = True
        RefreshStatus()
    End Sub

    ''' <summary>
    ''' Opens a file selected using the open file dialogue and loads the project if it is valid, updating the form as appropriate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click, tsOpenProject.Click
        StatusEndpoint.Text = "Opening ..."
        OpenDialogue.Filter = "Mauro Project JSON|*.json"
        OpenDialogue.Title = "Mauro Project"
        OpenDialogue.DefaultExt = ".json"
        Dim DiagRes As DialogResult = OpenDialogue.ShowDialog()

        If Not (DiagRes = DialogResult.Cancel) Then
            OpenMauroTemplateManagerProject(OpenDialogue.FileName)
        End If

        SetTab(1)

    End Sub
    ''' <summary>
    ''' Open the last Mauro Template Manager project file used
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuOpenRecent_Click(sender As Object, e As EventArgs) Handles tsOpenLast.Click
        Dim s As List(Of ApplicationSettings.AppSetting) = AppSettings.GetAppSettingAll("RecentFileList")
        If s.Count > 0 Then
            Dim Filename As String = s(0).Value
            OpenMauroTemplateManagerProject(Filename)
        Else
            MsgBox("There have not been any recent files", vbCritical)
        End If
        SetTab(2)
    End Sub
    ''' <summary>
    ''' Opens a project and attempts to log into the Mauro endpoint specified in the project 
    ''' </summary>
    ''' <param name="Filename">The filename containing the Mauro Template Manager Project</param>
    Public Sub OpenMauroTemplateManagerProject(Filename As String)
        project = Nothing
        Dim dirty As Boolean = ProjectDirty
        Try
            project = New Project(Filename)

            ' Set up the Project tab
            If project.Endpoint.Username = "" Then
                If AppSettings.GetAppSetting("DefaultUsername", "") <> "" Then
                    EndpointConnection.Username = AppSettings.GetAppSetting("DefaultUsername")
                    EndpointConnection.Password = AppSettings.GetPasswordAppSetting()
                End If
            Else
                If AppSettings.GetAppSetting("SavePassword") = "True" Then
                    If AppSettings.GetAppSetting("DefaultUsername", "") = "" Then
                        AppSettings.SetAppSetting("DefaultUsername", EndpointConnection.Username)
                        AppSettings.SetPasswordAppSetting(EndpointConnection.Password)
                    End If
                End If
            End If

            EndpointConnection.Login()
            If EndpointConnection.LoginStatus Then
                project.Endpoint.EndpointURL = EndpointConnection.Endpoint
                project.Endpoint.Username = EndpointConnection.Username
                project.Endpoint.Password = EndpointConnection.Password
            End If
            EndpointConnection.GetModels()

            ProjectLoaded = True
            dirty = False
            AppSettings.AddOrMoveToStart("RecentFileList", project.Filename)
        Catch ex As Exception
            If IsNothing(project) Then
                ProjectLoaded = False
                MsgBox(ex.Message,, "Unable to open file")
            Else
                ProjectLoaded = True
                MsgBox(ex.Message,, "Unable to connect to " & EndpointConnection.Endpoint.ToString)
            End If

        End Try

        RefreshStatus()
        RefreshModelList()
        RedrawActionList()
        RefreshRecentFileList()
        RefreshQueue()
        ProjectDirty = dirty
    End Sub
    ''' <summary>
    ''' Saves the active Mauro Template Manager project to JSON using the existing filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        DoSave(project.Filename) ' Saves without changing the filename
    End Sub

    ''' <summary>
    ''' Saves the project as JSON to a new filename specified in the Save File Dialogue
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
            DoSave(SaveDialogue.FileName)
            AppSettings.AddOrMoveToStart("RecentFileList", project.Filename)
            RefreshRecentFileList()
        End If
    End Sub

    ''' <summary>
    ''' Actions the saving of a Mauro Template Manager file to disk
    ''' </summary>
    ''' <param name="Filename">File to save the project to</param>
    Public Sub DoSave(Optional Filename As String = "")
        Dim pwdSave As Boolean = False
        If AppSettings.GetAppSetting("SavePassword") = "true" Then
            Dim MBRSavePass As MsgBoxResult = MsgBox("Do you want to save your password in this file?", vbYesNo Or MsgBoxStyle.DefaultButton2 Or vbQuestion, "Save project " & project.Filename)
            If MBRSavePass = MsgBoxResult.Yes Then
                pwdSave = True
            End If
        End If
        Dim s As String
        If pwdSave Then
            project.SaveProject(False, Filename)
            s = AppSettings.GetAppSetting("ConnectionEndpoint", "")
            If s = "" Then
                AppSettings.SetAppSetting("EndpointConnection", project.Endpoint.EndpointURL.ToString)
            End If
            s = AppSettings.GetAppSetting("DefaultUsername", "")
            If s = "" Then
                AppSettings.SetAppSetting("DefaultUsername", project.Endpoint.Username)
            End If
            project.Filename = Filename
            ProjectDirty = False
        Else
            project.SaveProject(True, Filename)
            s = AppSettings.GetAppSetting("ConnectionEndpoint", "")
            If s = "" Then
                AppSettings.SetAppSetting("EndpointConnection", project.Endpoint.EndpointURL.ToString)
            End If
            s = AppSettings.GetAppSetting("DefaultUsername", "")
            If s = "" Then
                AppSettings.SetAppSetting("DefaultUsername", project.Endpoint.Username)
            End If
            project.Filename = Filename
            ProjectDirty = False
        End If
        RefreshStatus()
    End Sub

    ''' <summary>
    ''' Update the display list of the most recently accessed files.
    ''' </summary>
    Public Sub RefreshRecentFileList()
        RecentFiles = AppSettings.GetAppSettingAll("RecentFileList")

        mnuOpenRecent.DropDownItems.Clear()
        If RecentFiles.Count = 0 Then
            tsOpenLast.Enabled = False
            mnuOpenRecent.Enabled = False
        Else
            tsOpenLast.Enabled = True
            mnuOpenRecent.Enabled = True
            For Each setting As ApplicationSettings.AppSetting In RecentFiles
                Dim m As New ToolStripMenuItem
                m.Text = setting.Value
                m.Name = "Recent" & setting.Sequence.ToString

                AddHandler m.Click, AddressOf OpenRecentFileHandler
                mnuOpenRecent.DropDownItems.Add(m)
            Next
        End If

    End Sub
    ''' <summary>
    ''' Event handler for each of the most recently accessed file menu items
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub OpenRecentFileHandler(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, ToolStripMenuItem).Name.StartsWith("Recent") Then
            Dim Filename As String = CType(sender, ToolStripMenuItem).Text
            OpenMauroTemplateManagerProject(Filename)
        End If

    End Sub

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
#End Region

#Region "Display management"
    ''' <summary>
    ''' Updates the display for the main panel and status bar
    ''' </summary>
    Public Sub RefreshStatus()
        mnuSave.Enabled = ProjectLoaded
        mnuSaveAs.Enabled = ProjectLoaded
        tsSave.Enabled = ProjectLoaded
        tsSaveAs.Enabled = ProjectLoaded
        If ProjectLoaded Then

            Dim dirty As Boolean = ProjectDirty
            ' Set up the tabbed dialogue / update the UI
            Me.BackgroundImageLayout = ImageLayout.None
            tsProcess.Visible = True
            tsPrinting.Visible = True
            ' Tabs.Visible = True

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
            StatusEndpoint.Text = EndpointConnection.Endpoint.ToString


            If EndpointConnection.LoginStatus And (EndpointConnection.Username <> "") Then
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

            ' Update the screen
            Application.DoEvents()

            RefreshQueue()
            RefreshModelList()
            RedrawActionList()

            ProjectDirty = dirty
            'LoginStatus.Text = EndpointConnection.LoginDetails.userRole
            'tvQueue.ExpandAll()
        Else
            StatusEndpoint.Text = "Not connected"
            SavedState.Text = "No project loaded"
            StatusFilename.Text = ""
            ' Update the UI
            tsProcess.Visible = False
            tsPrinting.Visible = False
            SetTab(-1)
            Me.BackgroundImageLayout = ImageLayout.Center
        End If

        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Refresh the display of the queue metrics
    ''' </summary>
    Private Sub RefreshQueue()

        ' Update the queue
        If ActionEntries.Entries.Count = 0 Then
            tvQueue.Nodes.Clear()
            Counters.Text = "No actions taken"
            tvQueue.Visible = False
            pnlTVQueueButtons.Visible = False
            pbProgressHidden.Visible = True
        Else
            tvQueue.Visible = True
            pnlTVQueueButtons.Visible = True
            pbProgressHidden.Visible = False
            Counters.Text = "Waiting: " & ActionEntries.NotStarted.ToString
            Counters.Text &= ";  Executing: " & ActionEntries.InProgress.ToString
            Counters.Text &= ";  Success: " & ActionEntries.Success.ToString
            Counters.Text &= "; Failed: " & ActionEntries.Failed.ToString

            tvQueue.Nodes.Clear()
            Dim RootNode, ModelNode As TreeNode
            RootNode = New TreeNode With {
                .ImageIndex = 4,
                .Text = "Result status"}

            Dim q = From Entries In ActionEntries.Entries
                    Order By Entries.Action.Name ' entries.model

            ' Update the tree
            For Each e As ActionEntry In q

                Dim ActionNode As New TreeNode With {
                    .Text = e.Action.Name,
                    .ToolTipText = e.Action.Description,
                    .ImageIndex = 4}

                Dim modelID As String = "" ' Reset the model list
                For Each ModelEntry As Guid In e.ModelIDs
                    Dim NewLabel As String = ""
                    Dim Tooltip As String = ""

                    If e.ModelIDs.ToString <> modelID Then
                        modelID = e.ModelIDs.ToString

                        Dim MdlList As List(Of Model) = EndpointConnection.MauroModels.items
                        Dim mdl = From m In MdlList.Where(Function(x) x.id = ModelEntry)

                        If mdl.Count = 1 Then
                            NewLabel = mdl(0).label
                            If Not IsNothing(mdl(0).description) Then
                                Tooltip = mdl(0).description
                            End If
                        Else
                            NewLabel = "Unknown model"
                        End If

                        ' Add the model node
                        ModelNode = New TreeNode With {
                                    .Text = NewLabel,
                                    .Tag = e.ActionEntryID.ToString,
                                    .ImageIndex = 4,
                                    .ToolTipText = Tooltip}

                    End If

                    ' Need to create a new folder here if there are more than one responses 
                    Select Case e.Status

                        Case ActionOutcomeStatus.Success, e.Status = ActionOutcomeStatus.Failed, ActionOutcomeStatus.InProgress

                            For Each r As ActionResponse In e.ActionResponses
                                ' Store the post response
                                Dim n As New TreeNode With {
                                .Text = r.ResponseDescription,
                                .Name = r.ResponseID.ToString,
                                                                .ImageIndex = e.Status
                                }
                                If Not IsNothing(r.Response) Then
                                    n.Tag = r.Response.Result.RequestMessage.RequestUri.ToString
                                Else
                                    n.Tag = r.ResponseID.ToString
                                End If
                                ModelNode.Nodes.Add(n)
                            Next
                            ActionNode.Nodes.Add(ModelNode)

                            ModelNode.ImageIndex = e.Status

                        Case Else

                    End Select

                Next
                RootNode.Nodes.Add(ActionNode)
            Next

            tvQueue.Nodes.Add(RootNode)
            For Each n As TreeNode In tvQueue.Nodes
                n.Expand()
            Next
        End If
    End Sub
    ''' <summary>
    ''' Refresh the list of models available to select in the project and the models that have been selected
    ''' </summary>
    Private Sub RefreshModelList()

        ' Update the model list boxes
        If EndpointConnection.LoginStatus = True Then
            Dim AvailableModels = From m In EndpointConnection.MauroModels.items

            AvailableModels = AvailableModels.Where(Function(x) project.Models.Contains(x.id) = False).OrderBy(Function(x) x.label).ToList

            lstModels.DataSource = AvailableModels.ToList

            lstModels.DisplayMember = "label"
            lstModels.ValueMember = "id"

            Dim AllModels As List(Of Model) = EndpointConnection.MauroModels.items

            Dim SelectedModels = From ModelGUID In project.Models
                                 Join m In AllModels
                   On ModelGUID Equals m.id
                                 Select ModelGUID, m.label

            Dim MissingModels As Integer = project.Models.Count - SelectedModels.Count

            lstGUIDs.DataSource = SelectedModels.ToList
            lstGUIDs.DisplayMember = "Label"
            lstGUIDs.ValueMember = "ModelGUID"
        End If


    End Sub
    ''' <summary>
    ''' Update the output display when the selected action changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub UpdateActionEntryResult(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvQueue.NodeMouseClick
        Dim n As TreeNode = e.Node
        If n.GetNodeCount(False) > 0 Then
            n.Expand()
        End If
        Try

            For Each ae As ActionEntry In ActionEntries.Entries
                For Each pr As ActionResponse In ae.ActionResponses
                    If pr.ResponseID.ToString = n.Name Then
                        If Not IsNothing(pr.Response) Then
                            Dim ResponseText As String = pr.Response.Body
                            Try
                                ResponseText = PrettyJson(ResponseText)
                                txtPostBody.Lexer = Lexer.Json
                            Catch
                                Select Case ae.Action.FileSuffix.ToLower
                                    Case ".xml", ".dita", ".ditamap", ".bookmap"
                                        DITA(txtPostBody)
                                    Case ".htm", ".html"
                                        txtPostBody.Lexer = Lexer.Html
                                    Case ".bat"
                                        txtPostBody.Lexer = Lexer.Batch
                                    Case Else
                                        txtPostBody.Lexer = Lexer.Null
                                End Select
                                ' if there is an error, just show the text
                            End Try

                            txtPostBody.ReadOnly = False
                            txtPostBody.Text = ResponseText
                            txtPostBody.ReadOnly = True
                        Else
                            txtPostBody.Lexer = Lexer.Null
                            txtPostBody.Text = pr.ResponseDescription
                        End If
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Update the edit controls for the selected action
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RefreshActions(sender As Object, e As EventArgs) Handles lstActions.SelectedIndexChanged
        Dim dirty As Boolean = ProjectDirty

        If lstActions.SelectedIndex >= 0 Then
            With CType(lstActions.SelectedItem, FreemarkerAction)
                textName.Text = .Name
                textDesription.Text = .Description

                TextFilePrefix.Text = .FilePrefix
                textFileSuffix.Text = .FileSuffix

                txtTemplate.Text = .Template

                ' Set the layout colours
                Select Case .FileSuffix.ToLower
                    Case ".xml", ".dita", ".ditamap", ".bookmap"
                        DITA(txtTemplate)
                    Case ".htm", ".html"
                        txtTemplate.Lexer = Lexer.Html
                    Case ".bat"
                        txtTemplate.Lexer = Lexer.Batch
                    Case Else
                        txtTemplate.Lexer = Lexer.Xml
                End Select

                Select Case .ActionType
                    Case ActionTypes.actionClass
                        rbClass.Checked = True
                    Case ActionTypes.actionSingleModel
                        rbModel.Checked = True

                    Case ActionTypes.actionTerminology
                        rbTerminology.Checked = True
                End Select
            End With
        End If
        ProjectDirty = dirty
    End Sub

    ''' <summary>
    ''' Redraw the list of available actions
    ''' </summary>
    Public Sub RedrawActionList()
        Dim selIndex As Integer = lstActions.SelectedIndex
        If project.Actions.Count > 0 Then
            lstActions.DataSource = Nothing
            lstActions.DataSource = project.Actions
            lstActions.DisplayMember = "Name"
            lstActions.ValueMember = "id"
            lstActions.SelectedIndex = selIndex

            If lstActions.Items.Count > 0 Then
                scActions.Panel2.Enabled = True
                If lstActions.SelectedIndex = -1 Then
                    lstActions.SelectedIndex = 0
                End If
            Else
                scActions.Panel2.Enabled = False
            End If
        End If

    End Sub

    Private Sub SetTab(Tab As Integer)
        If Tab = -1 Then
            Tabs.Visible = False
        Else
            Tabs.Visible = True
            Tabs.SelectedIndex = Tab
            If Tab = 2 Or Tab = 3 Then
                tsPrinting.Visible = True
            Else
                tsPrinting.Visible = False
            End If
        End If
    End Sub
#End Region
#Region "Form control value handling"
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
    Private Sub PrefixChanged(sender As Object, e As EventArgs) Handles TextFilePrefix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerAction).FilePrefix = TextFilePrefix.Text
        SetDirty()
    End Sub

    Private Sub TemplateChanged(sender As Object, e As EventArgs) Handles txtTemplate.TextChanged
        If lstActions.SelectedIndex >= 0 Then
            CType(lstActions.SelectedItem, FreemarkerAction).Template = txtTemplate.Text
        End If
        SetDirty()

    End Sub

    Private Sub SuffixChanged(sender As Object, e As EventArgs) Handles textFileSuffix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerAction).FileSuffix = textFileSuffix.Text
        SetDirty()
    End Sub

    ''' <summary>
    ''' Update the actionType to reflect the radiobutton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ActionTypeChanged(sender As Object, e As EventArgs) Handles rbModel.CheckedChanged, rbClass.CheckedChanged, rbTerminology.CheckedChanged
        If rbModel.Checked Then
            CType(lstActions.SelectedItem, FreemarkerAction).ActionType = ActionTypes.actionSingleModel
        ElseIf rbClass.Checked Then
            CType(lstActions.SelectedItem, FreemarkerAction).ActionType = ActionTypes.actionClass
        ElseIf rbAllModels.Checked Then
            CType(lstActions.SelectedItem, FreemarkerAction).ActionType = ActionTypes.actionAllModels

        Else
            CType(lstActions.SelectedItem, FreemarkerAction).ActionType = ActionTypes.actionTerminology
        End If

        SetDirty()
    End Sub

    Private Sub ActionNameChanged(sender As Object, e As EventArgs) Handles textName.Leave
        Try
            CType(lstActions.SelectedItem, FreemarkerAction).Name = textName.Text
            RedrawActionList()
        Catch ex As Exception
        End Try

        SetDirty()
    End Sub

    Private Sub ActionDesciptionChanged(sender As Object, e As EventArgs) Handles textDesription.TextChanged
        CType(lstActions.SelectedItem, FreemarkerAction).Description = textDesription.Text
        SetDirty()
    End Sub
#End Region

#Region "Handle mouse clicks"
    Private Sub cmdAddAction_Click(sender As Object, e As EventArgs) Handles cmdAddAction.Click
        Dim act As New FreemarkerAction With {
            .ActionType = ActionTypes.actionSingleModel,
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

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        For Each itm As Model In lstModels.SelectedItems
            project.Models.Add(itm.id)
        Next
        RefreshStatus()
    End Sub

    Private Sub cmdAddGUID_Click(sender As Object, e As EventArgs) Handles cmdAddGUID.Click
        Dim id As Guid
        Try
            id = New Guid(txtModelGUID.Text)
            project.Models.Add(id)
        Catch ex As Exception
            MsgBox("The guid was Not valid", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Invalid GUID")
        End Try
        RefreshStatus()
    End Sub


    Private Sub cmdRemoveModel_Click(sender As Object, e As EventArgs) Handles cmdRemoveModel.Click
        For Each ModelListEntry As Object In lstGUIDs.SelectedItems
            project.Models.Remove(project.Models.Find(Function(x) x.ToString = ModelListEntry.modelguid.ToString))
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
        Dim act As FreemarkerAction = lstActions.SelectedItem
        Dim OutputDirectory As String = AppSettings.GetAppSetting("DefaultOutputDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))

        If project.Models.Count = 0 Then ' Process all the models
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
                    .ModelIDs = mdlList}

            ActionEntries.Entries.Add(newEntry)

        End If
        StartActionEntryQueueAsync(1)
        TimerReset()
        SetTab(3)
        Application.DoEvents()


    End Sub

    Private Sub cmdDoAll_Click(sender As Object, e As EventArgs) Handles cmdDoAll.Click, tsbRun.Click
        If EndpointConnection.LoginStatus = False Then
            MsgBox("You need to log in to a Mauro endpoint.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Not logged in")
            SetTab(0)
        ElseIf EndpointConnection.Username = "" Then
            MsgBox("You have not logged in to a Mauro endpoint", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Not logged in")
            SetTab(0)

        Else
            SetTab(3)
            Application.DoEvents()
            Dim OutputDirectory As String = AppSettings.GetAppSetting("DefaultOutputDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            QueueProjectActionEntries(project, OutputDirectory)
            Application.DoEvents()
            'StartActionEntryQueueAsync() ' TimerReset kicks off the queue
            TimerReset()
        End If
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)
        RefreshStatus()
    End Sub



    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        Dim f As New frmPreferences
        f.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutMauroTemplateManager.ShowDialog()
    End Sub


    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ActionEntries.Clear()
        RefreshQueue()
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click
        Select Case Tabs.SelectedIndex
            Case 2
                Print(txtTemplate, False, CType(lstActions.SelectedItem, FreemarkerAction).Name)
            Case 3
                Print(txtPostBody, False, tvQueue.SelectedNode.Text)
            Case Else
                MsgBox("Select the template or process queue before printing.")
        End Select

    End Sub

    Private Sub tsbPreview_Click(sender As Object, e As EventArgs) Handles tsbPreview.Click
        Select Case Tabs.SelectedIndex
            Case 2
                Print(txtTemplate, True, CType(lstActions.SelectedItem, FreemarkerAction).Name)
            Case 3
                If Not IsNothing(tvQueue.SelectedNode) Then
                    Print(txtPostBody, True, tvQueue.SelectedNode.Text)
                Else
                    MsgBox("No output selected", vbOKOnly & MsgBoxStyle.Exclamation)
                End If
            Case Else
                MsgBox("Select the template or process queue before printing.")
        End Select

    End Sub
#End Region

#Region "Supporting functions"
    ''' <summary>
    ''' Event handler to handle the action queue timer refresh
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
            RefreshQueue()
        Else
            Timer1.Enabled = True
            Timer1.Start()
            RefreshQueue()
        End If
        Application.DoEvents()
        If q > 0 And i < 20 Then
            ' Restart the queue
            StartActionEntryQueueAsync(20)
        End If
    End Sub
    ''' <summary>
    ''' Flags that the project has unsaved changes
    ''' </summary>
    Public Sub SetDirty()
        ProjectDirty = True
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

#End Region

#Region "Scintilla"

    Private Sub Print(Box As Scintilla, Preview As Boolean, DocName As String)
        If Box.Text = "" Then
            MsgBox("There is nothing selected to print", vbInformation Or vbOKOnly)
        Else
            Dim printer As Printing = New Printing(Box)

            Dim Settings As New PageSettings() With {
            .ColorMode = PageSettings.PrintColorMode.ColorOnWhite
            }

            Settings.Footer = New FooterInformation() With {
                .Left = InformationType.DocumentName,
                .Right = InformationType.PageNumber,
                .Border = PageInformationBorder.Top
            }
            Settings.Header = New HeaderInformation() With {
                .Left = InformationType.DocumentName,
                .Right = InformationType.PageNumber,
                .Border = PageInformationBorder.Bottom
            }

            printer.PageSettings = Settings
            printer.PrintDocument = New PrintDocument(Box) With {
                .DocumentName = "Mauro Template Manager - " & DocName}

            If Preview Then
                printer.PrintPreview()
            Else
                printer.Print()
            End If
        End If


    End Sub
    Private Sub InitSyntaxColoring(txtTemplate As Scintilla)

        ' Configure the default style
        txtTemplate.StyleResetDefault()
        txtTemplate.Styles(Style.Default).Font = "Consolas"
        txtTemplate.Styles(Style.Default).Size = 10
        txtTemplate.Styles(Style.Default).BackColor = Color.White
        txtTemplate.Styles(Style.Default).ForeColor = Color.Black
        txtTemplate.CaretForeColor = Color.Black
        txtTemplate.StyleClearAll() ' Reset all properties to the defaults

        txtTemplate.Styles(Style.Xml.Tag).ForeColor = Color.Red
        txtTemplate.Styles(Style.Xml.TagUnknown).ForeColor = Color.DarkGreen
        txtTemplate.Styles(Style.Xml.Attribute).ForeColor = Color.Blue
        txtTemplate.Styles(Style.Xml.AttributeUnknown).ForeColor = Color.Yellow
        txtTemplate.Styles(Style.Xml.Number).ForeColor = Color.Fuchsia
        txtTemplate.Styles(Style.Xml.DoubleString).ForeColor = Color.Maroon
        txtTemplate.Styles(Style.Xml.SingleString).ForeColor = Color.Maroon
        txtTemplate.Styles(Style.Xml.Other).ForeColor = Color.Green
        txtTemplate.Styles(Style.Xml.Comment).BackColor = Color.Beige
        txtTemplate.Styles(Style.Xml.Comment).ForeColor = Color.Navy
        txtTemplate.Styles(Style.Xml.Entity).ForeColor = Color.Olive
        txtTemplate.Styles(Style.Xml.TagEnd).ForeColor = Color.Purple
        txtTemplate.Styles(Style.Xml.XmlStart).ForeColor = Color.Teal
        txtTemplate.Styles(Style.Xml.XmlEnd).ForeColor = Color.Gray
        txtTemplate.Styles(Style.Xml.Script).ForeColor = Color.FromArgb(-4194304)
        txtTemplate.Styles(Style.Xml.Asp).ForeColor = Color.FromArgb(-16728064)
        txtTemplate.Styles(Style.Xml.AspAt).ForeColor = Color.FromArgb(-16777024)
        txtTemplate.Styles(Style.Xml.CData).ForeColor = Color.FromArgb(-4145152)
        txtTemplate.Styles(Style.Xml.Question).ForeColor = Color.FromArgb(-4194112)
        txtTemplate.Styles(Style.Xml.Value).ForeColor = Color.DarkSlateBlue
        txtTemplate.Styles(Style.Xml.XcComment).ForeColor = Color.Silver

        txtTemplate.Lexer = Lexer.Xml
        txtTemplate.AllowDrop = True
        txtTemplate.SetKeywords(0, "#function #include #import")
        txtTemplate.SetKeywords(1, "#assign #return #default #break #noparse #compress #escape #noescape #global #local #setting #macro #nested #flush #stop #ftl #t #lt #rt #nt #visit #recurse #fallback #if #else #elseif #list #switch #case #attempt #recover")

    End Sub

    Private Sub DITA(Box As Scintilla)
        Box.Styles(ScintillaNET.Style.Xml.Tag).ForeColor = Color.DarkGreen
        Box.Styles(ScintillaNET.Style.Xml.TagUnknown).ForeColor = Color.DarkRed
        Box.Styles(ScintillaNET.Style.Xml.Attribute).ForeColor = Color.Blue
        Box.Styles(ScintillaNET.Style.Xml.AttributeUnknown).ForeColor = Color.DarkBlue
        Box.Styles(ScintillaNET.Style.Xml.Number).ForeColor = Color.Fuchsia
        Box.Styles(ScintillaNET.Style.Xml.DoubleString).ForeColor = Color.DarkMagenta
        Box.Styles(ScintillaNET.Style.Xml.SingleString).ForeColor = Color.Maroon
        Box.Styles(ScintillaNET.Style.Xml.Other).ForeColor = Color.Green
        Box.Styles(ScintillaNET.Style.Xml.Comment).ForeColor = Color.Navy
        Box.Styles(ScintillaNET.Style.Xml.Entity).ForeColor = Color.Olive
        Box.Styles(ScintillaNET.Style.Xml.TagEnd).ForeColor = Color.Red
        Box.Styles(ScintillaNET.Style.Xml.XmlStart).ForeColor = Color.Teal
        Box.Styles(ScintillaNET.Style.Xml.XmlEnd).ForeColor = Color.Gray
        Box.Styles(ScintillaNET.Style.Xml.Script).BackColor = Color.DarkBlue
        Box.Styles(ScintillaNET.Style.Xml.Script).ForeColor = Color.White
        Box.Styles(ScintillaNET.Style.Xml.Value).ForeColor = Color.Yellow
        Box.Lexer = ScintillaNET.Lexer.Xml
        Box.SetKeywords(2, "two #function #include #import")
        Box.SetKeywords(1, "#assign #return #default #break #noparse #compress #escape #noescape #global #local #setting #macro #nested #flush #stop #ftl #t #lt #rt #nt #visit #recurse #fallback #if #else #elseif #list #switch #case #attempt #recover")
        Box.SetKeywords(0, "abstract alt anchor anchorid anchorkey anchorref area attributedef audience author b body bodydiv boolean brand category cite colspec component consequence coords copyrholder copyright copyryear created critdates data-about data dd ddhd defaultSubject desc dita ditavalmeta ditavalref div dl dlentry dlhead draft-comment dt dthd dvrKeyscopePrefix dvrKeyscopeSuffix dvrResourcePrefix dvrResourceSuffix elementdef entry enumerationdef example exportanchors featnum fig figgroup fn foreign hasInstance hasKind hasNarrower hasPart hasRelated hazardstatement hazardsymbol howtoavoid i image imagemap index-base index-see-also index-see index-sort-as indexterm indextermref itemgroup keydef keyword keywords li lines line-through link linkinfo linklist linkpool linktext longdescref longquoteref lq map mapref messagepanel metadata navref navtitle no-topic-nesting note object ol othermeta overline p param permissions ph platform pre prodinfo prodname prognum prolog publisher q related-links relatedSubjects relcell relcolspec relheader relrow reltable required-cleanup resourceid revised row schemeref searchtitle section sectiondiv series shape shortdesc simpletable sl sli sort-as source state stentry sthead strow sub subjectCell subjectHead subjectHeadMeta subjectRel subjectRelHeader subjectRelTable subjectRole subjectScheme subjectdef subjectref sup table tbody term text tgroup thead title titlealts tm topic topicCell topicSubjectHeader topicSubjectRow topicSubjectTable topicapply topicgroup topichead topicmeta topicref topicset topicsetref topicsubject tt typeofhazard u ul unknown ux-window vrm vrmlist xref ")

    End Sub
    Private Sub InitColors(txtTemplate As Scintilla)
        txtTemplate.SetSelectionBackColor(True, IntToColor(&H114D9C))
    End Sub
    Public Function IntToColor(ByVal rgb As Integer) As Color
        'Return Color.FromArgb(255, CByte(rgb >> 16), CByte(rgb >> 8), CByte(rgb))
        Return Color.FromArgb(255, Color.FromArgb(rgb))
    End Function
    Private Sub InitNumberMargin(txtTemplate As Scintilla)
        Const BACK_COLOR As Integer = &H2A211C
        Const FORE_COLOR As Integer = &HB7B7B7
        Const NUMBER_MARGIN As Integer = 1
        Const BOOKMARK_MARGIN As Integer = 2
        Const BOOKMARK_MARKER As Integer = 2
        Const FOLDING_MARGIN As Integer = 3
        Const CODEFOLDING_CIRCULAR As Boolean = True

        txtTemplate.Styles(Style.LineNumber).BackColor = IntToColor(BACK_COLOR)
        txtTemplate.Styles(Style.LineNumber).ForeColor = IntToColor(FORE_COLOR)
        txtTemplate.Styles(Style.IndentGuide).ForeColor = IntToColor(FORE_COLOR)
        txtTemplate.Styles(Style.IndentGuide).BackColor = IntToColor(BACK_COLOR)
        Dim nums = txtTemplate.Margins(NUMBER_MARGIN)
        nums.Width = 30
        nums.Type = MarginType.Number
        nums.Sensitive = True
        nums.Mask = 0
        ' txtTemplate.MarginClick += TextArea_MarginClick
    End Sub


#End Region
End Class
