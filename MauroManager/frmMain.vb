﻿Imports System.Text.RegularExpressions
Imports System.Text.Json
Imports MauroClasses
Imports MauroClasses.MauroAPI
Imports MauroClasses.MauroAPI.FreemarkerProject
Imports ScintillaNET

Public Class frmMain

    Public project As Project

    Dim ProjectLoaded As Boolean = False
    Dim ProjectDirty As Boolean = False
    Dim AppSettings As New ApplicationSettings("Mauro")
    Dim RecentFiles As List(Of ApplicationSettings.AppSetting)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshStatus()
        RefreshRecentFileList()
        InitColors()
        InitSyntaxColoring()
        InitNumberMargin()
    End Sub

#Region "File open, save, close"
    ''' <summary>
    ''' Creates a new project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click

        Dim DefaultURI As Uri
        Dim EndpointURL As String = AppSettings.GetAppSetting("EndpointConnection", "https://localhost")
        Dim Username As String = AppSettings.GetAppSetting("DefaultUsername")
        Dim Password As String = AppSettings.GetAppSetting("DefaultPassword")

        Try
            DefaultURI = New Uri(EndpointURL)
        Catch ex As Exception
            DefaultURI = New Uri("https://localhost")
        End Try
        project = New Project(DefaultURI, Username, Password)
        EndpointConnection.Login()
        EndpointConnection.GetModels()

        txtEndpointURL.Text = project.Endpoint.EndpointURL.ToString
        txtUsername.Text = project.Endpoint.Username
        txtPassword.Text = ""
        ProjectLoaded = True
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
        Dim DiagRes As DialogResult = OpenDialogue.ShowDialog()

        If Not (DiagRes = DialogResult.Cancel) Then
            OpenFile(OpenDialogue.FileName)
        End If

        Tabs.SelectedIndex = 1
    End Sub
    Private Sub mnuOpenRecent_Click(sender As Object, e As EventArgs) Handles mnuOpenRecent.Click
        Dim s As List(Of ApplicationSettings.AppSetting) = AppSettings.GetAppSettingAll("RecentFileList")
        If s.Count > 0 Then
            Dim Filename As String = s(0).Value
            OpenFile(Filename)
        Else
            MsgBox("There have not been any recent files", vbCritical)
        End If

        Tabs.SelectedIndex = 2
    End Sub
    Public Sub OpenFile(Filename As String)
        project = Nothing
        Try
            project = New Project(Filename)

            ' Set up the Project tab

            EndpointConnection.Login()
            EndpointConnection.GetModels()

            If AppSettings.GetAppSetting("SavePassword") = "True" Then
                If AppSettings.GetAppSetting("DefaultUsername", "") = "" Then
                    AppSettings.SetAppSetting("DefaultUsername", EndpointConnection.Username)
                    AppSettings.SetAppSetting("DefaultPassword", EndpointConnection.Password)
                End If
            End If

            ProjectLoaded = True
            ProjectDirty = False
            AppSettings.AddOrMoveToStart("RecentFileList", project.Filename)
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
        RefreshRecentFileList()
    End Sub
    ''' <summary>
    ''' Saves the project to JSON to the existing filename
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        project.SaveProject()
        Dim s As String
        s = AppSettings.GetAppSetting("ConnectionEndpoint", "")
        If s = "" Then
            AppSettings.SetAppSetting("EndpointConnection", project.Endpoint.EndpointURL.ToString)
        End If
        s = AppSettings.GetAppSetting("DefaultUsername", "")
        If s = "" Then
            AppSettings.SetAppSetting("DefaultUsername", project.Endpoint.Username)
        End If

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

    Public Sub RefreshRecentFileList()
        RecentFiles = AppSettings.GetAppSettingAll("RecentFileList")
        mnuOpenRecent.DropDownItems.Clear()

        For Each setting As ApplicationSettings.AppSetting In RecentFiles
            Dim m As New ToolStripMenuItem
            m.Text = setting.Value
            m.Name = "Recent" & setting.Sequence.ToString

            AddHandler m.Click, AddressOf OpenRecentFileHandler
                mnuOpenRecent.DropDownItems.Add(m)

        Next
    End Sub

    Public Sub OpenRecentFileHandler(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, ToolStripMenuItem).Name.StartsWith("Recent") Then
            Dim Filename As String = CType(sender, ToolStripMenuItem).Text
            OpenFile(Filename)
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

        If ProjectLoaded Then

            ' Set up the tabbed dialogue 
            Tabs.Visible = True
            Me.BackgroundImageLayout = ImageLayout.None


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


            ' Update the screen
            Application.DoEvents()

            RefreshQueue()
            RefreshModelList()
            RedrawActionList()
            ' Populate the actions
            lstActions.DataSource = project.Actions
            lstActions.DisplayMember = "Name"
            lstActions.ValueMember = "id"
            'tvQueue.ExpandAll()
        Else
            StatusEndpoint.Text = "Not connected"
            SavedState.Text = "No project loaded"
            StatusFilename.Text = ""

            Tabs.Visible = False
            Me.BackgroundImageLayout = ImageLayout.Center
        End If

        Application.DoEvents()
    End Sub

    Private Sub RefreshQueue()

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
                                .Tag = r.Response.Result.RequestMessage.RequestUri.ToString,
                                .ImageIndex = e.Status
                                }

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
        End If
    End Sub
    Private Sub RefreshModelList()

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

            Dim MissingModels As Integer = project.Models.Count - SelectedModels.Count
            'If MissingModels <> 0 Then
            '    MsgBox(MissingModels.ToString & " models are no longer available on the Mauro server.  Saving this project will remove missing models.", MsgBoxStyle.Exclamation, "Missing models")

            '    For i = project.Models.Count - 1 To 0 Step -1
            '        Dim id As Guid = project.Models(i)
            '        If EndpointConnection.MauroModels.items.FindAll(Function(x) x.id = id).Count = 0 Then
            '            project.Models.RemoveAt(i)
            '        End If
            '        i -= 1
            '    Next
            'End If
            lstGUIDs.DataSource = SelectedModels.ToList
            lstGUIDs.DisplayMember = "Label"
            lstGUIDs.ValueMember = "p"
        End If


    End Sub
    Private Sub UpdateActionEntryResult(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvQueue.NodeMouseClick
        Dim n As TreeNode = e.Node
        If n.GetNodeCount(False) > 0 Then
            n.Expand()
        End If
        Try

            For Each ae As ActionEntry In ActionEntries.Entries



                For Each pr As ActionResponse In ae.ActionResponses
                    If pr.ResponseID.ToString = n.Name Then

                        Dim ResponseText As String = pr.Response.Body
                        Try
                            ResponseText = PrettyJson(ResponseText)
                        Catch
                            ' if there is an error, just show the text
                        End Try
                        txtPostBody.Text = ResponseText
                    End If
                Next


            Next
        Catch ex As Exception

        End Try

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
                    Case ActionTypes.actionClass
                        rbClass.Checked = True
                    Case ActionTypes.actionSingleModel
                        rbModel.Checked = True

                    Case ActionTypes.actionTerminology
                        rbTerminology.Checked = True
                End Select
            End With
        End If

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
    Private Sub PrefixChanged(sender As Object, e As EventArgs) Handles TextFilePrefix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).FilePrefix = TextFilePrefix.Text
        SetDirty()
    End Sub

    Private Sub TemplateChanged(sender As Object, e As EventArgs) Handles txtTemplate.TextChanged
        If lstActions.SelectedIndex >= 0 Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).Template = txtTemplate.Text
        End If
        SetDirty()

    End Sub

    Private Sub SuffixChanged(sender As Object, e As EventArgs) Handles textFileSuffix.TextChanged
        CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).FileSuffix = textFileSuffix.Text
        SetDirty()
    End Sub

    ''' <summary>
    ''' Update the actionType to reflect the radiobutton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ActionTypeChanged(sender As Object, e As EventArgs) Handles rbModel.CheckedChanged, rbClass.CheckedChanged, rbTerminology.CheckedChanged
        If rbModel.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = ActionTypes.actionSingleModel
        ElseIf rbClass.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = ActionTypes.actionClass
        ElseIf rbAllModels.Checked Then
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = ActionTypes.actionAllModels

        Else
            CType(lstActions.SelectedItem, FreemarkerProject.FreemarkerAction).ActionType = ActionTypes.actionTerminology
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
#End Region

#Region "Handle mouse clicks"
    Private Sub cmdAddAction_Click(sender As Object, e As EventArgs) Handles cmdAddAction.Click
        Dim act As New FreemarkerProject.FreemarkerAction With {
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
                    .ModelIDs = mdlList}
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
        Dim OutputDirectory As String = AppSettings.GetAppSetting("DefaultOutputDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        QueueProjectActionEntries(project, OutputDirectory)
        Application.DoEvents()
        'StartActionEntryQueueAsync() ' TimerReset kicks off the queue
        TimerReset()

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)
        RefreshStatus()
    End Sub



    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        Dim f As New frmPreferences
        f.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub
#End Region

#Region "Supporting functions"
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
            RefreshStatus()
        End If
        Application.DoEvents()
        If q > 0 And i = 0 Then
            ' Restart the queue
            StartActionEntryQueueAsync()
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

#End Region
    Private Sub InitSyntaxColoring()

        ' Configure the default style
        txtTemplate.StyleResetDefault()
        txtTemplate.Styles(Style.Default).Font = "Consolas"
        txtTemplate.Styles(Style.Default).Size = 10
        txtTemplate.Styles(Style.Default).BackColor = Color.Black
        txtTemplate.Styles(Style.Default).ForeColor = Color.LightGray
        txtTemplate.CaretForeColor = Color.White
        txtTemplate.StyleClearAll() ' Reset all properties to the defaults

        txtTemplate.Styles(Style.Xml.Tag).ForeColor = Color.Red
        txtTemplate.Styles(Style.Xml.TagUnknown).ForeColor = Color.Lime
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
        txtTemplate.Styles(Style.Xml.Value).ForeColor = Color.SaddleBrown
        txtTemplate.Styles(Style.Xml.XcComment).ForeColor = Color.Silver

        txtTemplate.Lexer = Lexer.Xml
        txtTemplate.AllowDrop = True
        txtTemplate.SetKeywords(0, "#function #include #import")
        txtTemplate.SetKeywords(1, "#assign #return #default #break #noparse #compress #escape #noescape #global #local #setting #macro #nested #flush #stop #ftl #t #lt #rt #nt #visit #recurse #fallback #if #else #elseif #list #switch #case #attempt #recover")

    End Sub
    Private Sub InitColors()
        txtTemplate.SetSelectionBackColor(True, IntToColor(&H114D9C))
    End Sub
    Public Shared Function IntToColor(ByVal rgb As Integer) As Color
        'Return Color.FromArgb(255, CByte(rgb >> 16), CByte(rgb >> 8), CByte(rgb))
        Return Color.FromArgb(255, Color.FromArgb(rgb))
    End Function
    Private Sub InitNumberMargin()
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

End Class
