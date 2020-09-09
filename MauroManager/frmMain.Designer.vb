﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Models")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModelSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusEndpoint = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoginStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusFilename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SavedState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Counters = New System.Windows.Forms.ToolStripStatusLabel()
        Me.QueueProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.OpenDialogue = New System.Windows.Forms.OpenFileDialog()
        Me.SaveDialogue = New System.Windows.Forms.SaveFileDialog()
        Me.ActionsTab = New System.Windows.Forms.TabPage()
        Me.scActions = New System.Windows.Forms.SplitContainer()
        Me.lstActions = New System.Windows.Forms.ListBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdDoAll = New System.Windows.Forms.Button()
        Me.cmdSingleAction = New System.Windows.Forms.Button()
        Me.cmdAddAction = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTemplate = New System.Windows.Forms.TextBox()
        Me.pnlActionProperties = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.textFileSuffix = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextFilePrefix = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textDesription = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpActionType = New System.Windows.Forms.GroupBox()
        Me.rbTerminology = New System.Windows.Forms.RadioButton()
        Me.rbClass = New System.Windows.Forms.RadioButton()
        Me.rbModel = New System.Windows.Forms.RadioButton()
        Me.ModelsTab = New System.Windows.Forms.TabPage()
        Me.ModelsContainer = New System.Windows.Forms.SplitContainer()
        Me.lstModels = New System.Windows.Forms.ListBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtModelGUID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lstGUIDs = New System.Windows.Forms.ListBox()
        Me.ProjectTab = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdLogInOut = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtEndpointURL = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.Queue = New System.Windows.Forms.TabPage()
        Me.scModels = New System.Windows.Forms.SplitContainer()
        Me.tvQueue = New System.Windows.Forms.TreeView()
        Me.ilStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.txtPostBody = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ActionsTab.SuspendLayout()
        CType(Me.scActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scActions.Panel1.SuspendLayout()
        Me.scActions.Panel2.SuspendLayout()
        Me.scActions.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlActionProperties.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.grpActionType.SuspendLayout()
        Me.ModelsTab.SuspendLayout()
        CType(Me.ModelsContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ModelsContainer.Panel1.SuspendLayout()
        Me.ModelsContainer.Panel2.SuspendLayout()
        Me.ModelsContainer.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.ProjectTab.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.Queue.SuspendLayout()
        CType(Me.scModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scModels.Panel1.SuspendLayout()
        Me.scModels.Panel2.SuspendLayout()
        Me.scModels.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(3, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(992, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.OpenToolStripMenuItem, Me.mnuSave, Me.mnuSaveAs, Me.ToolStripSeparator1, Me.ImportToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(205, 22)
        Me.mnuNew.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.OpenToolStripMenuItem.Text = "&Open project"
        '
        'mnuSave
        '
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(205, 22)
        Me.mnuSave.Text = "Save current project"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(205, 22)
        Me.mnuSaveAs.Text = "&Save current project as ..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModelSetToolStripMenuItem, Me.ActionSetToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ModelSetToolStripMenuItem
        '
        Me.ModelSetToolStripMenuItem.Name = "ModelSetToolStripMenuItem"
        Me.ModelSetToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ModelSetToolStripMenuItem.Text = "Model set"
        '
        'ActionSetToolStripMenuItem
        '
        Me.ActionSetToolStripMenuItem.Name = "ActionSetToolStripMenuItem"
        Me.ActionSetToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ActionSetToolStripMenuItem.Text = "Action set"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(202, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusEndpoint, Me.LoginStatus, Me.StatusFilename, Me.SavedState, Me.Counters, Me.QueueProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 501)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 7, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(992, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusEndpoint
        '
        Me.StatusEndpoint.Name = "StatusEndpoint"
        Me.StatusEndpoint.Size = New System.Drawing.Size(72, 17)
        Me.StatusEndpoint.Text = "statusModel"
        '
        'LoginStatus
        '
        Me.LoginStatus.Name = "LoginStatus"
        Me.LoginStatus.Size = New System.Drawing.Size(69, 17)
        Me.LoginStatus.Text = "LoginStatus"
        '
        'StatusFilename
        '
        Me.StatusFilename.Name = "StatusFilename"
        Me.StatusFilename.Size = New System.Drawing.Size(87, 17)
        Me.StatusFilename.Text = "StatusFilename"
        '
        'SavedState
        '
        Me.SavedState.Name = "SavedState"
        Me.SavedState.Size = New System.Drawing.Size(64, 17)
        Me.SavedState.Text = "SavedState"
        '
        'Counters
        '
        Me.Counters.Name = "Counters"
        Me.Counters.Size = New System.Drawing.Size(55, 17)
        Me.Counters.Text = "Counters"
        '
        'QueueProgress
        '
        Me.QueueProgress.Name = "QueueProgress"
        Me.QueueProgress.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.QueueProgress.Size = New System.Drawing.Size(200, 16)
        Me.QueueProgress.Step = 1
        Me.QueueProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ActionsTab
        '
        Me.ActionsTab.Controls.Add(Me.scActions)
        Me.ActionsTab.Location = New System.Drawing.Point(4, 22)
        Me.ActionsTab.Name = "ActionsTab"
        Me.ActionsTab.Size = New System.Drawing.Size(1074, 655)
        Me.ActionsTab.TabIndex = 2
        Me.ActionsTab.Text = "Actions"
        Me.ActionsTab.UseVisualStyleBackColor = True
        '
        'scActions
        '
        Me.scActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.scActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scActions.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scActions.Location = New System.Drawing.Point(0, 0)
        Me.scActions.Name = "scActions"
        '
        'scActions.Panel1
        '
        Me.scActions.Panel1.AutoScroll = True
        Me.scActions.Panel1.Controls.Add(Me.lstActions)
        Me.scActions.Panel1.Controls.Add(Me.Panel3)
        Me.scActions.Panel1.Controls.Add(Me.Label7)
        Me.scActions.Panel1MinSize = 250
        '
        'scActions.Panel2
        '
        Me.scActions.Panel2.Controls.Add(Me.txtTemplate)
        Me.scActions.Panel2.Controls.Add(Me.pnlActionProperties)
        Me.scActions.Panel2MinSize = 270
        Me.scActions.Size = New System.Drawing.Size(1074, 655)
        Me.scActions.SplitterDistance = 270
        Me.scActions.TabIndex = 1
        '
        'lstActions
        '
        Me.lstActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstActions.FormattingEnabled = True
        Me.lstActions.Location = New System.Drawing.Point(0, 13)
        Me.lstActions.Name = "lstActions"
        Me.lstActions.Size = New System.Drawing.Size(266, 546)
        Me.lstActions.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmdDoAll)
        Me.Panel3.Controls.Add(Me.cmdSingleAction)
        Me.Panel3.Controls.Add(Me.cmdAddAction)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 559)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(266, 92)
        Me.Panel3.TabIndex = 1
        '
        'cmdDoAll
        '
        Me.cmdDoAll.Location = New System.Drawing.Point(186, 3)
        Me.cmdDoAll.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdDoAll.Name = "cmdDoAll"
        Me.cmdDoAll.Size = New System.Drawing.Size(76, 31)
        Me.cmdDoAll.TabIndex = 2
        Me.cmdDoAll.Text = "Do &all"
        Me.cmdDoAll.UseVisualStyleBackColor = True
        '
        'cmdSingleAction
        '
        Me.cmdSingleAction.Location = New System.Drawing.Point(95, 3)
        Me.cmdSingleAction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdSingleAction.Name = "cmdSingleAction"
        Me.cmdSingleAction.Size = New System.Drawing.Size(76, 31)
        Me.cmdSingleAction.TabIndex = 1
        Me.cmdSingleAction.Text = "Do &selected"
        Me.cmdSingleAction.UseVisualStyleBackColor = True
        '
        'cmdAddAction
        '
        Me.cmdAddAction.Location = New System.Drawing.Point(3, 3)
        Me.cmdAddAction.Name = "cmdAddAction"
        Me.cmdAddAction.Size = New System.Drawing.Size(78, 31)
        Me.cmdAddAction.TabIndex = 0
        Me.cmdAddAction.Text = "Add &new action"
        Me.cmdAddAction.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Mauro actions"
        '
        'txtTemplate
        '
        Me.txtTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTemplate.Location = New System.Drawing.Point(0, 198)
        Me.txtTemplate.Multiline = True
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTemplate.Size = New System.Drawing.Size(796, 453)
        Me.txtTemplate.TabIndex = 1
        '
        'pnlActionProperties
        '
        Me.pnlActionProperties.AutoScroll = True
        Me.pnlActionProperties.Controls.Add(Me.Panel4)
        Me.pnlActionProperties.Controls.Add(Me.grpActionType)
        Me.pnlActionProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActionProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlActionProperties.Name = "pnlActionProperties"
        Me.pnlActionProperties.Size = New System.Drawing.Size(796, 198)
        Me.pnlActionProperties.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.textFileSuffix)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.TextFilePrefix)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.textDesription)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.textName)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(628, 184)
        Me.Panel4.TabIndex = 1
        '
        'textFileSuffix
        '
        Me.textFileSuffix.Dock = System.Windows.Forms.DockStyle.Top
        Me.textFileSuffix.Location = New System.Drawing.Point(0, 153)
        Me.textFileSuffix.Name = "textFileSuffix"
        Me.textFileSuffix.Size = New System.Drawing.Size(628, 20)
        Me.textFileSuffix.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Location = New System.Drawing.Point(0, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "File suffix"
        '
        'TextFilePrefix
        '
        Me.TextFilePrefix.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextFilePrefix.Location = New System.Drawing.Point(0, 120)
        Me.TextFilePrefix.Name = "TextFilePrefix"
        Me.TextFilePrefix.Size = New System.Drawing.Size(628, 20)
        Me.TextFilePrefix.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Location = New System.Drawing.Point(0, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "File prefix"
        '
        'textDesription
        '
        Me.textDesription.Dock = System.Windows.Forms.DockStyle.Top
        Me.textDesription.Location = New System.Drawing.Point(0, 46)
        Me.textDesription.Multiline = True
        Me.textDesription.Name = "textDesription"
        Me.textDesription.Size = New System.Drawing.Size(628, 61)
        Me.textDesription.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Location = New System.Drawing.Point(0, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Action description and approach"
        '
        'textName
        '
        Me.textName.Dock = System.Windows.Forms.DockStyle.Top
        Me.textName.Location = New System.Drawing.Point(0, 13)
        Me.textName.Name = "textName"
        Me.textName.Size = New System.Drawing.Size(628, 20)
        Me.textName.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Action Name"
        '
        'grpActionType
        '
        Me.grpActionType.Controls.Add(Me.rbTerminology)
        Me.grpActionType.Controls.Add(Me.rbClass)
        Me.grpActionType.Controls.Add(Me.rbModel)
        Me.grpActionType.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpActionType.Location = New System.Drawing.Point(628, 0)
        Me.grpActionType.Name = "grpActionType"
        Me.grpActionType.Size = New System.Drawing.Size(168, 198)
        Me.grpActionType.TabIndex = 0
        Me.grpActionType.TabStop = False
        Me.grpActionType.Text = "Create files for ..."
        '
        'rbTerminology
        '
        Me.rbTerminology.AutoSize = True
        Me.rbTerminology.Location = New System.Drawing.Point(6, 65)
        Me.rbTerminology.Name = "rbTerminology"
        Me.rbTerminology.Size = New System.Drawing.Size(157, 17)
        Me.rbTerminology.TabIndex = 2
        Me.rbTerminology.Text = "Each terminology in a model"
        Me.rbTerminology.UseVisualStyleBackColor = True
        '
        'rbClass
        '
        Me.rbClass.AutoSize = True
        Me.rbClass.Location = New System.Drawing.Point(6, 42)
        Me.rbClass.Name = "rbClass"
        Me.rbClass.Size = New System.Drawing.Size(128, 17)
        Me.rbClass.TabIndex = 1
        Me.rbClass.Text = "Each class in a model"
        Me.rbClass.UseVisualStyleBackColor = True
        '
        'rbModel
        '
        Me.rbModel.AutoSize = True
        Me.rbModel.Location = New System.Drawing.Point(6, 19)
        Me.rbModel.Name = "rbModel"
        Me.rbModel.Size = New System.Drawing.Size(93, 17)
        Me.rbModel.TabIndex = 0
        Me.rbModel.Text = "Just the model"
        Me.rbModel.UseVisualStyleBackColor = True
        '
        'ModelsTab
        '
        Me.ModelsTab.Controls.Add(Me.ModelsContainer)
        Me.ModelsTab.Location = New System.Drawing.Point(4, 22)
        Me.ModelsTab.Name = "ModelsTab"
        Me.ModelsTab.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ModelsTab.Size = New System.Drawing.Size(1074, 655)
        Me.ModelsTab.TabIndex = 1
        Me.ModelsTab.Text = "Models"
        Me.ModelsTab.UseVisualStyleBackColor = True
        '
        'ModelsContainer
        '
        Me.ModelsContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModelsContainer.Location = New System.Drawing.Point(3, 3)
        Me.ModelsContainer.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ModelsContainer.Name = "ModelsContainer"
        '
        'ModelsContainer.Panel1
        '
        Me.ModelsContainer.Panel1.Controls.Add(Me.lstModels)
        Me.ModelsContainer.Panel1.Controls.Add(Me.Panel5)
        '
        'ModelsContainer.Panel2
        '
        Me.ModelsContainer.Panel2.Controls.Add(Me.lstGUIDs)
        Me.ModelsContainer.Size = New System.Drawing.Size(1068, 649)
        Me.ModelsContainer.SplitterDistance = 354
        Me.ModelsContainer.SplitterWidth = 2
        Me.ModelsContainer.TabIndex = 0
        '
        'lstModels
        '
        Me.lstModels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstModels.FormattingEnabled = True
        Me.lstModels.Location = New System.Drawing.Point(0, 0)
        Me.lstModels.Name = "lstModels"
        Me.lstModels.Size = New System.Drawing.Size(354, 573)
        Me.lstModels.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cmdAdd)
        Me.Panel5.Controls.Add(Me.txtModelGUID)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 573)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(354, 76)
        Me.Panel5.TabIndex = 1
        '
        'cmdAdd
        '
        Me.cmdAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAdd.Location = New System.Drawing.Point(0, 33)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(354, 43)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtModelGUID
        '
        Me.txtModelGUID.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtModelGUID.Location = New System.Drawing.Point(0, 13)
        Me.txtModelGUID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtModelGUID.Name = "txtModelGUID"
        Me.txtModelGUID.Size = New System.Drawing.Size(354, 20)
        Me.txtModelGUID.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Model GUID"
        '
        'lstGUIDs
        '
        Me.lstGUIDs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstGUIDs.FormattingEnabled = True
        Me.lstGUIDs.Location = New System.Drawing.Point(0, 0)
        Me.lstGUIDs.Name = "lstGUIDs"
        Me.lstGUIDs.Size = New System.Drawing.Size(712, 649)
        Me.lstGUIDs.TabIndex = 3
        '
        'ProjectTab
        '
        Me.ProjectTab.Controls.Add(Me.Panel2)
        Me.ProjectTab.Controls.Add(Me.Panel1)
        Me.ProjectTab.Location = New System.Drawing.Point(4, 22)
        Me.ProjectTab.Name = "ProjectTab"
        Me.ProjectTab.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ProjectTab.Size = New System.Drawing.Size(984, 451)
        Me.ProjectTab.TabIndex = 0
        Me.ProjectTab.Text = "Project settings"
        Me.ProjectTab.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdLogInOut)
        Me.Panel2.Controls.Add(Me.lblError)
        Me.Panel2.Controls.Add(Me.txtPassword)
        Me.Panel2.Controls.Add(Me.txtUsername)
        Me.Panel2.Controls.Add(Me.txtEndpointURL)
        Me.Panel2.Controls.Add(Me.lblFilename)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(203, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 445)
        Me.Panel2.TabIndex = 1
        '
        'cmdLogInOut
        '
        Me.cmdLogInOut.Location = New System.Drawing.Point(4, 107)
        Me.cmdLogInOut.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmdLogInOut.Name = "cmdLogInOut"
        Me.cmdLogInOut.Size = New System.Drawing.Size(74, 27)
        Me.cmdLogInOut.TabIndex = 6
        Me.cmdLogInOut.Text = "Log in"
        Me.cmdLogInOut.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.Color.DarkRed
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblError.ForeColor = System.Drawing.SystemColors.Control
        Me.lblError.Location = New System.Drawing.Point(0, 95)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(39, 13)
        Me.lblError.TabIndex = 5
        Me.lblError.Text = "Label5"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtPassword
        '
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPassword.Location = New System.Drawing.Point(0, 75)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(778, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUsername
        '
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtUsername.Location = New System.Drawing.Point(0, 50)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUsername.Multiline = True
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(778, 25)
        Me.txtUsername.TabIndex = 2
        '
        'txtEndpointURL
        '
        Me.txtEndpointURL.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtEndpointURL.Location = New System.Drawing.Point(0, 22)
        Me.txtEndpointURL.Margin = New System.Windows.Forms.Padding(0)
        Me.txtEndpointURL.MinimumSize = New System.Drawing.Size(4, 20)
        Me.txtEndpointURL.Multiline = True
        Me.txtEndpointURL.Name = "txtEndpointURL"
        Me.txtEndpointURL.Size = New System.Drawing.Size(778, 28)
        Me.txtEndpointURL.TabIndex = 1
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFilename.Location = New System.Drawing.Point(0, 0)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Padding = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.lblFilename.Size = New System.Drawing.Size(45, 22)
        Me.lblFilename.TabIndex = 4
        Me.lblFilename.Text = "Label5"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 445)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Location = New System.Drawing.Point(0, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label4.Size = New System.Drawing.Size(59, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(0, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label3.Size = New System.Drawing.Size(61, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label2.Size = New System.Drawing.Size(80, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Endpoint URL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label1.Size = New System.Drawing.Size(58, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File name"
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.ProjectTab)
        Me.Tabs.Controls.Add(Me.ModelsTab)
        Me.Tabs.Controls.Add(Me.ActionsTab)
        Me.Tabs.Controls.Add(Me.Queue)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 24)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(992, 477)
        Me.Tabs.TabIndex = 2
        '
        'Queue
        '
        Me.Queue.Controls.Add(Me.scModels)
        Me.Queue.Location = New System.Drawing.Point(4, 22)
        Me.Queue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Queue.Name = "Queue"
        Me.Queue.Size = New System.Drawing.Size(1074, 655)
        Me.Queue.TabIndex = 3
        Me.Queue.Text = "Process Queue"
        Me.Queue.UseVisualStyleBackColor = True
        '
        'scModels
        '
        Me.scModels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scModels.Location = New System.Drawing.Point(0, 0)
        Me.scModels.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.scModels.Name = "scModels"
        '
        'scModels.Panel1
        '
        Me.scModels.Panel1.Controls.Add(Me.tvQueue)
        '
        'scModels.Panel2
        '
        Me.scModels.Panel2.Controls.Add(Me.txtPostBody)
        Me.scModels.Size = New System.Drawing.Size(1074, 655)
        Me.scModels.SplitterDistance = 355
        Me.scModels.SplitterWidth = 2
        Me.scModels.TabIndex = 1
        '
        'tvQueue
        '
        Me.tvQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvQueue.ImageIndex = 0
        Me.tvQueue.ImageList = Me.ilStatus
        Me.tvQueue.Location = New System.Drawing.Point(0, 0)
        Me.tvQueue.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tvQueue.Name = "tvQueue"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Models"
        Me.tvQueue.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tvQueue.SelectedImageIndex = 0
        Me.tvQueue.Size = New System.Drawing.Size(355, 655)
        Me.tvQueue.TabIndex = 1
        '
        'ilStatus
        '
        Me.ilStatus.ImageStream = CType(resources.GetObject("ilStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ilStatus.Images.SetKeyName(0, "Graphicloads-Colorful-Long-Shadow-Button-2-pause.ico")
        Me.ilStatus.Images.SetKeyName(1, "Graphicloads-Colorful-Long-Shadow-Button-1-play.ico")
        Me.ilStatus.Images.SetKeyName(2, "Graphicloads-Colorful-Long-Shadow-Check-3.ico")
        Me.ilStatus.Images.SetKeyName(3, "Graphicloads-Colorful-Long-Shadow-Close.ico")
        Me.ilStatus.Images.SetKeyName(4, "Mahm0udwally-All-Flat-Folder.ico")
        '
        'txtPostBody
        '
        Me.txtPostBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPostBody.Location = New System.Drawing.Point(0, 0)
        Me.txtPostBody.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPostBody.Multiline = True
        Me.txtPostBody.Name = "txtPostBody"
        Me.txtPostBody.Size = New System.Drawing.Size(717, 655)
        Me.txtPostBody.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 523)
        Me.Controls.Add(Me.Tabs)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmMain"
        Me.Text = "Mauro Template editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ActionsTab.ResumeLayout(False)
        Me.scActions.Panel1.ResumeLayout(False)
        Me.scActions.Panel1.PerformLayout()
        Me.scActions.Panel2.ResumeLayout(False)
        Me.scActions.Panel2.PerformLayout()
        CType(Me.scActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scActions.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlActionProperties.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.grpActionType.ResumeLayout(False)
        Me.grpActionType.PerformLayout()
        Me.ModelsTab.ResumeLayout(False)
        Me.ModelsContainer.Panel1.ResumeLayout(False)
        Me.ModelsContainer.Panel2.ResumeLayout(False)
        CType(Me.ModelsContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ModelsContainer.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ProjectTab.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.Queue.ResumeLayout(False)
        Me.scModels.Panel1.ResumeLayout(False)
        Me.scModels.Panel2.ResumeLayout(False)
        Me.scModels.Panel2.PerformLayout()
        CType(Me.scModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scModels.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModelSetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActionSetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusEndpoint As ToolStripStatusLabel
    Friend WithEvents SavedState As ToolStripStatusLabel
    Friend WithEvents OpenDialogue As OpenFileDialog
    Friend WithEvents StatusFilename As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSave As ToolStripMenuItem
    Friend WithEvents SaveDialogue As SaveFileDialog
    Friend WithEvents ActionsTab As TabPage
    Friend WithEvents scActions As SplitContainer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmdAddAction As Button
    Friend WithEvents txtTemplate As TextBox
    Friend WithEvents pnlActionProperties As Panel
    Friend WithEvents grpActionType As GroupBox
    Friend WithEvents rbTerminology As RadioButton
    Friend WithEvents rbClass As RadioButton
    Friend WithEvents rbModel As RadioButton
    Friend WithEvents ModelsTab As TabPage
    Friend WithEvents ProjectTab As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblError As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtEndpointURL As TextBox
    Friend WithEvents lblFilename As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents textFileSuffix As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextFilePrefix As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents textDesription As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents textName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ModelsContainer As SplitContainer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtModelGUID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdAdd As Button
    Friend WithEvents LoginStatus As ToolStripStatusLabel
    Friend WithEvents cmdLogInOut As Button
    Friend WithEvents cmdDoAll As Button
    Friend WithEvents cmdSingleAction As Button
    Friend WithEvents Counters As ToolStripStatusLabel
    Friend WithEvents Queue As TabPage
    Friend WithEvents scModels As SplitContainer
    Friend WithEvents tvQueue As TreeView
    Public WithEvents Tabs As TabControl
    Friend WithEvents ilStatus As ImageList
    Friend WithEvents lstModels As ListBox
    Friend WithEvents lstGUIDs As ListBox
    Friend WithEvents QueueProgress As ToolStripProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lstActions As ListBox
    Friend WithEvents mnuNew As ToolStripMenuItem
    Friend WithEvents txtPostBody As TextBox
End Class