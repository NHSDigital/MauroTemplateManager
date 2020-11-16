<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Mnu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenRecent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportExportToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PageSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusEndpoint = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoginStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusFilename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SavedState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.QueueProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.OpenDialogue = New System.Windows.Forms.OpenFileDialog()
        Me.SaveDialogue = New System.Windows.Forms.SaveFileDialog()
        Me.ActionsTab = New System.Windows.Forms.TabPage()
        Me.scActions = New System.Windows.Forms.SplitContainer()
        Me.lstActions = New System.Windows.Forms.ListBox()
        Me.pnlActionsTabButtons = New System.Windows.Forms.Panel()
        Me.cmdDoAll = New System.Windows.Forms.Button()
        Me.cmdSingleAction = New System.Windows.Forms.Button()
        Me.cmdAddAction = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTemplate = New ScintillaNET.Scintilla()
        Me.pnlActionProperties = New System.Windows.Forms.Panel()
        Me.PnlActionsTabActionProperties = New System.Windows.Forms.Panel()
        Me.textFileSuffix = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextFilePrefix = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textDesription = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpActionType = New System.Windows.Forms.GroupBox()
        Me.rbAllModels = New System.Windows.Forms.RadioButton()
        Me.rbTerminology = New System.Windows.Forms.RadioButton()
        Me.rbClass = New System.Windows.Forms.RadioButton()
        Me.rbModel = New System.Windows.Forms.RadioButton()
        Me.ModelsTab = New System.Windows.Forms.TabPage()
        Me.ModelsContainer = New System.Windows.Forms.SplitContainer()
        Me.lstModels = New System.Windows.Forms.ListBox()
        Me.pnlModelButtons = New System.Windows.Forms.Panel()
        Me.cmdAddGUID = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.txtModelGUID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlRemoveModelButtons = New System.Windows.Forms.Panel()
        Me.cmdRemoveModel = New System.Windows.Forms.Button()
        Me.lstGUIDs = New System.Windows.Forms.ListBox()
        Me.ProjectTab = New System.Windows.Forms.TabPage()
        Me.PnlProjectSettingsRight = New System.Windows.Forms.Panel()
        Me.cmdLogInOut = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtEndpointURL = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.pnlProjectSettings = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.Queue = New System.Windows.Forms.TabPage()
        Me.pbProgressHidden = New System.Windows.Forms.PictureBox()
        Me.scModels = New System.Windows.Forms.SplitContainer()
        Me.pnlTVQueueButtons = New System.Windows.Forms.Panel()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.tvQueue = New System.Windows.Forms.TreeView()
        Me.ilStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.txtPostBody = New ScintillaNET.Scintilla()
        Me.ilTabs = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MainTSContainer = New System.Windows.Forms.ToolStripContainer()
        Me.tsProcess = New System.Windows.Forms.ToolStrip()
        Me.tsbRun = New System.Windows.Forms.ToolStripButton()
        Me.Counters = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsFile = New System.Windows.Forms.ToolStrip()
        Me.tsNewProject = New System.Windows.Forms.ToolStripButton()
        Me.tsOpenProject = New System.Windows.Forms.ToolStripButton()
        Me.tsOpenLast = New System.Windows.Forms.ToolStripButton()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.tsPrinting = New System.Windows.Forms.ToolStrip()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbPreview = New System.Windows.Forms.ToolStripButton()
        Me.BGPicture = New System.Windows.Forms.PictureBox()
        Me.Mnu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ActionsTab.SuspendLayout()
        CType(Me.scActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scActions.Panel1.SuspendLayout()
        Me.scActions.Panel2.SuspendLayout()
        Me.scActions.SuspendLayout()
        Me.pnlActionsTabButtons.SuspendLayout()
        Me.pnlActionProperties.SuspendLayout()
        Me.PnlActionsTabActionProperties.SuspendLayout()
        Me.grpActionType.SuspendLayout()
        Me.ModelsTab.SuspendLayout()
        CType(Me.ModelsContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ModelsContainer.Panel1.SuspendLayout()
        Me.ModelsContainer.Panel2.SuspendLayout()
        Me.ModelsContainer.SuspendLayout()
        Me.pnlModelButtons.SuspendLayout()
        Me.pnlRemoveModelButtons.SuspendLayout()
        Me.ProjectTab.SuspendLayout()
        Me.PnlProjectSettingsRight.SuspendLayout()
        Me.pnlProjectSettings.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.Queue.SuspendLayout()
        CType(Me.pbProgressHidden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scModels.Panel1.SuspendLayout()
        Me.scModels.Panel2.SuspendLayout()
        Me.scModels.SuspendLayout()
        Me.pnlTVQueueButtons.SuspendLayout()
        Me.MainTSContainer.ContentPanel.SuspendLayout()
        Me.MainTSContainer.TopToolStripPanel.SuspendLayout()
        Me.MainTSContainer.SuspendLayout()
        Me.tsProcess.SuspendLayout()
        Me.tsFile.SuspendLayout()
        Me.tsPrinting.SuspendLayout()
        CType(Me.BGPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Mnu
        '
        Me.Mnu.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Mnu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.PreferencesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.Mnu.Location = New System.Drawing.Point(0, 0)
        Me.Mnu.Name = "Mnu"
        Me.Mnu.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.Mnu.Size = New System.Drawing.Size(1709, 33)
        Me.Mnu.TabIndex = 0
        Me.Mnu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.OpenToolStripMenuItem, Me.mnuOpenRecent, Me.mnuSave, Me.mnuSaveAs, Me.ImportExportToolStripSeparator, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.PrintToolStripSeparator, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.PageSetupToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.NewFile_16x
        Me.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuNew.Size = New System.Drawing.Size(368, 34)
        Me.mnuNew.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.OpenProject_16x
        Me.OpenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.OpenToolStripMenuItem.Text = "&Open project"
        '
        'mnuOpenRecent
        '
        Me.mnuOpenRecent.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.OpenFile_16x
        Me.mnuOpenRecent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuOpenRecent.Name = "mnuOpenRecent"
        Me.mnuOpenRecent.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuOpenRecent.Size = New System.Drawing.Size(368, 34)
        Me.mnuOpenRecent.Text = "Open recent"
        '
        'mnuSave
        '
        Me.mnuSave.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Save_16x
        Me.mnuSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSave.Size = New System.Drawing.Size(368, 34)
        Me.mnuSave.Text = "Save current project"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.SaveAs_16x
        Me.mnuSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnuSaveAs.Size = New System.Drawing.Size(368, 34)
        Me.mnuSaveAs.Text = "&Save current project as ..."
        '
        'ImportExportToolStripSeparator
        '
        Me.ImportExportToolStripSeparator.Name = "ImportExportToolStripSeparator"
        Me.ImportExportToolStripSeparator.Size = New System.Drawing.Size(365, 6)
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'PrintToolStripSeparator
        '
        Me.PrintToolStripSeparator.Name = "PrintToolStripSeparator"
        Me.PrintToolStripSeparator.Size = New System.Drawing.Size(365, 6)
        Me.PrintToolStripSeparator.Visible = False
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Print_16x
        Me.PrintToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.PrintPreview_16x
        Me.PrintPreviewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.PrintPreviewToolStripMenuItem.Text = "Print preview"
        '
        'PageSetupToolStripMenuItem
        '
        Me.PageSetupToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.PrintSetup_16x
        Me.PageSetupToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        Me.PageSetupToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.PageSetupToolStripMenuItem.Text = "Page setup"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(365, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Exit_16x
        Me.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(368, 34)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Settings_16x
        Me.PreferencesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(134, 29)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(65, 29)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.F1Help_16x
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(164, 34)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusEndpoint, Me.LoginStatus, Me.StatusFilename, Me.SavedState, Me.QueueProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 1083)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1709, 32)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusEndpoint
        '
        Me.StatusEndpoint.Name = "StatusEndpoint"
        Me.StatusEndpoint.Size = New System.Drawing.Size(110, 25)
        Me.StatusEndpoint.Text = "statusModel"
        '
        'LoginStatus
        '
        Me.LoginStatus.Name = "LoginStatus"
        Me.LoginStatus.Size = New System.Drawing.Size(104, 25)
        Me.LoginStatus.Text = "LoginStatus"
        '
        'StatusFilename
        '
        Me.StatusFilename.Name = "StatusFilename"
        Me.StatusFilename.Size = New System.Drawing.Size(130, 25)
        Me.StatusFilename.Text = "StatusFilename"
        '
        'SavedState
        '
        Me.SavedState.Name = "SavedState"
        Me.SavedState.Size = New System.Drawing.Size(99, 25)
        Me.SavedState.Text = "SavedState"
        '
        'QueueProgress
        '
        Me.QueueProgress.Name = "QueueProgress"
        Me.QueueProgress.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.QueueProgress.Size = New System.Drawing.Size(300, 24)
        Me.QueueProgress.Step = 1
        Me.QueueProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ActionsTab
        '
        Me.ActionsTab.Controls.Add(Me.scActions)
        Me.ActionsTab.ImageIndex = 2
        Me.ActionsTab.Location = New System.Drawing.Point(4, 29)
        Me.ActionsTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ActionsTab.Name = "ActionsTab"
        Me.ActionsTab.Size = New System.Drawing.Size(1701, 915)
        Me.ActionsTab.TabIndex = 2
        Me.ActionsTab.Text = "Templates"
        Me.ActionsTab.UseVisualStyleBackColor = True
        '
        'scActions
        '
        Me.scActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.scActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scActions.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.scActions.Location = New System.Drawing.Point(0, 0)
        Me.scActions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.scActions.Name = "scActions"
        '
        'scActions.Panel1
        '
        Me.scActions.Panel1.AutoScroll = True
        Me.scActions.Panel1.Controls.Add(Me.lstActions)
        Me.scActions.Panel1.Controls.Add(Me.pnlActionsTabButtons)
        Me.scActions.Panel1.Controls.Add(Me.Label7)
        Me.scActions.Panel1MinSize = 250
        '
        'scActions.Panel2
        '
        Me.scActions.Panel2.Controls.Add(Me.txtTemplate)
        Me.scActions.Panel2.Controls.Add(Me.pnlActionProperties)
        Me.scActions.Panel2MinSize = 270
        Me.scActions.Size = New System.Drawing.Size(1701, 915)
        Me.scActions.SplitterDistance = 425
        Me.scActions.SplitterWidth = 6
        Me.scActions.TabIndex = 1
        '
        'lstActions
        '
        Me.lstActions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstActions.FormattingEnabled = True
        Me.lstActions.ItemHeight = 20
        Me.lstActions.Location = New System.Drawing.Point(0, 20)
        Me.lstActions.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstActions.Name = "lstActions"
        Me.lstActions.Size = New System.Drawing.Size(421, 816)
        Me.lstActions.TabIndex = 4
        '
        'pnlActionsTabButtons
        '
        Me.pnlActionsTabButtons.Controls.Add(Me.cmdDoAll)
        Me.pnlActionsTabButtons.Controls.Add(Me.cmdSingleAction)
        Me.pnlActionsTabButtons.Controls.Add(Me.cmdAddAction)
        Me.pnlActionsTabButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActionsTabButtons.Location = New System.Drawing.Point(0, 836)
        Me.pnlActionsTabButtons.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlActionsTabButtons.MinimumSize = New System.Drawing.Size(0, 75)
        Me.pnlActionsTabButtons.Name = "pnlActionsTabButtons"
        Me.pnlActionsTabButtons.Size = New System.Drawing.Size(421, 75)
        Me.pnlActionsTabButtons.TabIndex = 1
        '
        'cmdDoAll
        '
        Me.cmdDoAll.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Run_16x
        Me.cmdDoAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDoAll.Location = New System.Drawing.Point(282, 9)
        Me.cmdDoAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdDoAll.Name = "cmdDoAll"
        Me.cmdDoAll.Size = New System.Drawing.Size(131, 56)
        Me.cmdDoAll.TabIndex = 2
        Me.cmdDoAll.Text = "Do &all"
        Me.cmdDoAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdDoAll.UseVisualStyleBackColor = True
        '
        'cmdSingleAction
        '
        Me.cmdSingleAction.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.RunChecked_16x
        Me.cmdSingleAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSingleAction.Location = New System.Drawing.Point(145, 9)
        Me.cmdSingleAction.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdSingleAction.Name = "cmdSingleAction"
        Me.cmdSingleAction.Size = New System.Drawing.Size(131, 55)
        Me.cmdSingleAction.TabIndex = 1
        Me.cmdSingleAction.Text = "Do &selected"
        Me.cmdSingleAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSingleAction.UseVisualStyleBackColor = True
        '
        'cmdAddAction
        '
        Me.cmdAddAction.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.XMLTransformation_16x
        Me.cmdAddAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddAction.Location = New System.Drawing.Point(7, 9)
        Me.cmdAddAction.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddAction.Name = "cmdAddAction"
        Me.cmdAddAction.Size = New System.Drawing.Size(131, 56)
        Me.cmdAddAction.TabIndex = 0
        Me.cmdAddAction.Text = "Add &new action"
        Me.cmdAddAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAddAction.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Mauro actions"
        '
        'txtTemplate
        '
        Me.txtTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTemplate.Lexer = ScintillaNET.Lexer.Xml
        Me.txtTemplate.Location = New System.Drawing.Point(0, 305)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(1266, 606)
        Me.txtTemplate.TabIndex = 1
        '
        'pnlActionProperties
        '
        Me.pnlActionProperties.AutoScroll = True
        Me.pnlActionProperties.Controls.Add(Me.PnlActionsTabActionProperties)
        Me.pnlActionProperties.Controls.Add(Me.grpActionType)
        Me.pnlActionProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActionProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlActionProperties.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlActionProperties.Name = "pnlActionProperties"
        Me.pnlActionProperties.Size = New System.Drawing.Size(1266, 305)
        Me.pnlActionProperties.TabIndex = 0
        '
        'PnlActionsTabActionProperties
        '
        Me.PnlActionsTabActionProperties.Controls.Add(Me.textFileSuffix)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.Label6)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.TextFilePrefix)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.Label5)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.textDesription)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.Label9)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.textName)
        Me.PnlActionsTabActionProperties.Controls.Add(Me.Label8)
        Me.PnlActionsTabActionProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlActionsTabActionProperties.Location = New System.Drawing.Point(0, 0)
        Me.PnlActionsTabActionProperties.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PnlActionsTabActionProperties.Name = "PnlActionsTabActionProperties"
        Me.PnlActionsTabActionProperties.Size = New System.Drawing.Size(964, 282)
        Me.PnlActionsTabActionProperties.TabIndex = 1
        '
        'textFileSuffix
        '
        Me.textFileSuffix.Dock = System.Windows.Forms.DockStyle.Top
        Me.textFileSuffix.Location = New System.Drawing.Point(0, 135)
        Me.textFileSuffix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.textFileSuffix.Name = "textFileSuffix"
        Me.textFileSuffix.Size = New System.Drawing.Size(964, 26)
        Me.textFileSuffix.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Location = New System.Drawing.Point(0, 115)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "File suffix"
        '
        'TextFilePrefix
        '
        Me.TextFilePrefix.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextFilePrefix.Location = New System.Drawing.Point(0, 89)
        Me.TextFilePrefix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextFilePrefix.Name = "TextFilePrefix"
        Me.TextFilePrefix.Size = New System.Drawing.Size(964, 26)
        Me.TextFilePrefix.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Location = New System.Drawing.Point(0, 69)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "File prefix"
        '
        'textDesription
        '
        Me.textDesription.Dock = System.Windows.Forms.DockStyle.Top
        Me.textDesription.Location = New System.Drawing.Point(0, 66)
        Me.textDesription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.textDesription.Multiline = True
        Me.textDesription.Name = "textDesription"
        Me.textDesription.Size = New System.Drawing.Size(964, 3)
        Me.textDesription.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Location = New System.Drawing.Point(0, 46)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(237, 20)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Action description and approach"
        '
        'textName
        '
        Me.textName.Dock = System.Windows.Forms.DockStyle.Top
        Me.textName.Location = New System.Drawing.Point(0, 20)
        Me.textName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.textName.Name = "textName"
        Me.textName.Size = New System.Drawing.Size(964, 26)
        Me.textName.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Action Name"
        '
        'grpActionType
        '
        Me.grpActionType.Controls.Add(Me.rbAllModels)
        Me.grpActionType.Controls.Add(Me.rbTerminology)
        Me.grpActionType.Controls.Add(Me.rbClass)
        Me.grpActionType.Controls.Add(Me.rbModel)
        Me.grpActionType.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpActionType.Location = New System.Drawing.Point(964, 0)
        Me.grpActionType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpActionType.Name = "grpActionType"
        Me.grpActionType.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpActionType.Size = New System.Drawing.Size(302, 305)
        Me.grpActionType.TabIndex = 0
        Me.grpActionType.TabStop = False
        Me.grpActionType.Text = "Create files for ..."
        '
        'rbAllModels
        '
        Me.rbAllModels.AutoSize = True
        Me.rbAllModels.Location = New System.Drawing.Point(10, 140)
        Me.rbAllModels.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbAllModels.Name = "rbAllModels"
        Me.rbAllModels.Size = New System.Drawing.Size(235, 24)
        Me.rbAllModels.TabIndex = 4
        Me.rbAllModels.Text = "All the models concatenated"
        Me.rbAllModels.UseVisualStyleBackColor = True
        '
        'rbTerminology
        '
        Me.rbTerminology.AutoSize = True
        Me.rbTerminology.Location = New System.Drawing.Point(9, 100)
        Me.rbTerminology.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbTerminology.Name = "rbTerminology"
        Me.rbTerminology.Size = New System.Drawing.Size(232, 24)
        Me.rbTerminology.TabIndex = 2
        Me.rbTerminology.Text = "Each terminology in a model"
        Me.rbTerminology.UseVisualStyleBackColor = True
        '
        'rbClass
        '
        Me.rbClass.AutoSize = True
        Me.rbClass.Location = New System.Drawing.Point(9, 65)
        Me.rbClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbClass.Name = "rbClass"
        Me.rbClass.Size = New System.Drawing.Size(187, 24)
        Me.rbClass.TabIndex = 1
        Me.rbClass.Text = "Each class in a model"
        Me.rbClass.UseVisualStyleBackColor = True
        '
        'rbModel
        '
        Me.rbModel.AutoSize = True
        Me.rbModel.Location = New System.Drawing.Point(9, 29)
        Me.rbModel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbModel.Name = "rbModel"
        Me.rbModel.Size = New System.Drawing.Size(118, 24)
        Me.rbModel.TabIndex = 0
        Me.rbModel.Text = "Each model"
        Me.rbModel.UseVisualStyleBackColor = True
        '
        'ModelsTab
        '
        Me.ModelsTab.Controls.Add(Me.ModelsContainer)
        Me.ModelsTab.ImageIndex = 1
        Me.ModelsTab.Location = New System.Drawing.Point(4, 29)
        Me.ModelsTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ModelsTab.Name = "ModelsTab"
        Me.ModelsTab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ModelsTab.Size = New System.Drawing.Size(1701, 915)
        Me.ModelsTab.TabIndex = 1
        Me.ModelsTab.Text = "Models"
        Me.ModelsTab.UseVisualStyleBackColor = True
        '
        'ModelsContainer
        '
        Me.ModelsContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModelsContainer.Location = New System.Drawing.Point(4, 5)
        Me.ModelsContainer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ModelsContainer.Name = "ModelsContainer"
        '
        'ModelsContainer.Panel1
        '
        Me.ModelsContainer.Panel1.Controls.Add(Me.lstModels)
        Me.ModelsContainer.Panel1.Controls.Add(Me.pnlModelButtons)
        '
        'ModelsContainer.Panel2
        '
        Me.ModelsContainer.Panel2.Controls.Add(Me.pnlRemoveModelButtons)
        Me.ModelsContainer.Panel2.Controls.Add(Me.lstGUIDs)
        Me.ModelsContainer.Size = New System.Drawing.Size(1693, 905)
        Me.ModelsContainer.SplitterDistance = 420
        Me.ModelsContainer.SplitterWidth = 3
        Me.ModelsContainer.TabIndex = 0
        '
        'lstModels
        '
        Me.lstModels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstModels.FormattingEnabled = True
        Me.lstModels.ItemHeight = 20
        Me.lstModels.Location = New System.Drawing.Point(0, 0)
        Me.lstModels.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstModels.Name = "lstModels"
        Me.lstModels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstModels.Size = New System.Drawing.Size(420, 787)
        Me.lstModels.TabIndex = 2
        '
        'pnlModelButtons
        '
        Me.pnlModelButtons.Controls.Add(Me.cmdAddGUID)
        Me.pnlModelButtons.Controls.Add(Me.cmdAdd)
        Me.pnlModelButtons.Controls.Add(Me.txtModelGUID)
        Me.pnlModelButtons.Controls.Add(Me.Label10)
        Me.pnlModelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlModelButtons.Location = New System.Drawing.Point(0, 787)
        Me.pnlModelButtons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlModelButtons.Name = "pnlModelButtons"
        Me.pnlModelButtons.Size = New System.Drawing.Size(420, 118)
        Me.pnlModelButtons.TabIndex = 1
        '
        'cmdAddGUID
        '
        Me.cmdAddGUID.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdAddGUID.Location = New System.Drawing.Point(136, 46)
        Me.cmdAddGUID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAddGUID.Name = "cmdAddGUID"
        Me.cmdAddGUID.Size = New System.Drawing.Size(136, 72)
        Me.cmdAddGUID.TabIndex = 3
        Me.cmdAddGUID.Text = "Add GUID"
        Me.cmdAddGUID.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdAdd.Location = New System.Drawing.Point(0, 46)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(136, 72)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "Add selected models"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'txtModelGUID
        '
        Me.txtModelGUID.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtModelGUID.Location = New System.Drawing.Point(0, 20)
        Me.txtModelGUID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtModelGUID.Name = "txtModelGUID"
        Me.txtModelGUID.Size = New System.Drawing.Size(420, 26)
        Me.txtModelGUID.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Model GUID"
        '
        'pnlRemoveModelButtons
        '
        Me.pnlRemoveModelButtons.Controls.Add(Me.cmdRemoveModel)
        Me.pnlRemoveModelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRemoveModelButtons.Location = New System.Drawing.Point(0, 830)
        Me.pnlRemoveModelButtons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlRemoveModelButtons.MinimumSize = New System.Drawing.Size(0, 75)
        Me.pnlRemoveModelButtons.Name = "pnlRemoveModelButtons"
        Me.pnlRemoveModelButtons.Size = New System.Drawing.Size(1270, 75)
        Me.pnlRemoveModelButtons.TabIndex = 4
        '
        'cmdRemoveModel
        '
        Me.cmdRemoveModel.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdRemoveModel.Location = New System.Drawing.Point(0, 0)
        Me.cmdRemoveModel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdRemoveModel.Name = "cmdRemoveModel"
        Me.cmdRemoveModel.Size = New System.Drawing.Size(136, 75)
        Me.cmdRemoveModel.TabIndex = 2
        Me.cmdRemoveModel.Text = "Remove selected models"
        Me.cmdRemoveModel.UseVisualStyleBackColor = True
        '
        'lstGUIDs
        '
        Me.lstGUIDs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstGUIDs.FormattingEnabled = True
        Me.lstGUIDs.ItemHeight = 20
        Me.lstGUIDs.Location = New System.Drawing.Point(0, 0)
        Me.lstGUIDs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstGUIDs.Name = "lstGUIDs"
        Me.lstGUIDs.Size = New System.Drawing.Size(1270, 905)
        Me.lstGUIDs.TabIndex = 3
        '
        'ProjectTab
        '
        Me.ProjectTab.Controls.Add(Me.PnlProjectSettingsRight)
        Me.ProjectTab.Controls.Add(Me.pnlProjectSettings)
        Me.ProjectTab.ImageIndex = 0
        Me.ProjectTab.Location = New System.Drawing.Point(4, 29)
        Me.ProjectTab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProjectTab.Name = "ProjectTab"
        Me.ProjectTab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProjectTab.Size = New System.Drawing.Size(1701, 915)
        Me.ProjectTab.TabIndex = 0
        Me.ProjectTab.Text = "Connection"
        Me.ProjectTab.UseVisualStyleBackColor = True
        '
        'PnlProjectSettingsRight
        '
        Me.PnlProjectSettingsRight.Controls.Add(Me.cmdLogInOut)
        Me.PnlProjectSettingsRight.Controls.Add(Me.lblError)
        Me.PnlProjectSettingsRight.Controls.Add(Me.txtPassword)
        Me.PnlProjectSettingsRight.Controls.Add(Me.txtUsername)
        Me.PnlProjectSettingsRight.Controls.Add(Me.txtEndpointURL)
        Me.PnlProjectSettingsRight.Controls.Add(Me.lblFilename)
        Me.PnlProjectSettingsRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlProjectSettingsRight.Location = New System.Drawing.Point(212, 5)
        Me.PnlProjectSettingsRight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PnlProjectSettingsRight.Name = "PnlProjectSettingsRight"
        Me.PnlProjectSettingsRight.Size = New System.Drawing.Size(1485, 905)
        Me.PnlProjectSettingsRight.TabIndex = 1
        '
        'cmdLogInOut
        '
        Me.cmdLogInOut.Location = New System.Drawing.Point(6, 165)
        Me.cmdLogInOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdLogInOut.Name = "cmdLogInOut"
        Me.cmdLogInOut.Size = New System.Drawing.Size(111, 42)
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
        Me.lblError.Location = New System.Drawing.Point(0, 107)
        Me.lblError.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(57, 20)
        Me.lblError.TabIndex = 5
        Me.lblError.Text = "Label5"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtPassword
        '
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPassword.Location = New System.Drawing.Point(0, 81)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(1485, 26)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUsername
        '
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtUsername.Location = New System.Drawing.Point(0, 63)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUsername.Multiline = True
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(1485, 18)
        Me.txtUsername.TabIndex = 2
        '
        'txtEndpointURL
        '
        Me.txtEndpointURL.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtEndpointURL.Location = New System.Drawing.Point(0, 34)
        Me.txtEndpointURL.Margin = New System.Windows.Forms.Padding(0)
        Me.txtEndpointURL.MinimumSize = New System.Drawing.Size(4, 29)
        Me.txtEndpointURL.Multiline = True
        Me.txtEndpointURL.Name = "txtEndpointURL"
        Me.txtEndpointURL.Size = New System.Drawing.Size(1485, 29)
        Me.txtEndpointURL.TabIndex = 1
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFilename.Location = New System.Drawing.Point(0, 0)
        Me.lblFilename.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Padding = New System.Windows.Forms.Padding(4, 5, 4, 9)
        Me.lblFilename.Size = New System.Drawing.Size(65, 34)
        Me.lblFilename.TabIndex = 4
        Me.lblFilename.Text = "Label5"
        '
        'pnlProjectSettings
        '
        Me.pnlProjectSettings.Controls.Add(Me.Label4)
        Me.pnlProjectSettings.Controls.Add(Me.Label3)
        Me.pnlProjectSettings.Controls.Add(Me.Label2)
        Me.pnlProjectSettings.Controls.Add(Me.Label1)
        Me.pnlProjectSettings.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlProjectSettings.Location = New System.Drawing.Point(4, 5)
        Me.pnlProjectSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlProjectSettings.Name = "pnlProjectSettings"
        Me.pnlProjectSettings.Size = New System.Drawing.Size(208, 905)
        Me.pnlProjectSettings.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Location = New System.Drawing.Point(0, 114)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 9, 4, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(4, 9, 4, 9)
        Me.Label4.Size = New System.Drawing.Size(86, 38)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(0, 76)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(4, 9, 4, 9)
        Me.Label3.Size = New System.Drawing.Size(91, 38)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(4, 9, 4, 9)
        Me.Label2.Size = New System.Drawing.Size(118, 38)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Endpoint URL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(4, 9, 4, 9)
        Me.Label1.Size = New System.Drawing.Size(86, 38)
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
        Me.Tabs.ImageList = Me.ilTabs
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(1709, 948)
        Me.Tabs.TabIndex = 2
        '
        'Queue
        '
        Me.Queue.Controls.Add(Me.pbProgressHidden)
        Me.Queue.Controls.Add(Me.scModels)
        Me.Queue.ImageIndex = 3
        Me.Queue.Location = New System.Drawing.Point(4, 29)
        Me.Queue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Queue.Name = "Queue"
        Me.Queue.Size = New System.Drawing.Size(1701, 915)
        Me.Queue.TabIndex = 3
        Me.Queue.Text = "Process Queue"
        Me.Queue.UseVisualStyleBackColor = True
        '
        'pbProgressHidden
        '
        Me.pbProgressHidden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbProgressHidden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbProgressHidden.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Fra_Mauro_World_Mapjpg
        Me.pbProgressHidden.Location = New System.Drawing.Point(0, 0)
        Me.pbProgressHidden.Name = "pbProgressHidden"
        Me.pbProgressHidden.Size = New System.Drawing.Size(1701, 915)
        Me.pbProgressHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbProgressHidden.TabIndex = 2
        Me.pbProgressHidden.TabStop = False
        '
        'scModels
        '
        Me.scModels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scModels.Location = New System.Drawing.Point(0, 0)
        Me.scModels.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.scModels.Name = "scModels"
        '
        'scModels.Panel1
        '
        Me.scModels.Panel1.Controls.Add(Me.pnlTVQueueButtons)
        Me.scModels.Panel1.Controls.Add(Me.tvQueue)
        '
        'scModels.Panel2
        '
        Me.scModels.Panel2.Controls.Add(Me.txtPostBody)
        Me.scModels.Size = New System.Drawing.Size(1701, 915)
        Me.scModels.SplitterDistance = 422
        Me.scModels.SplitterWidth = 3
        Me.scModels.TabIndex = 1
        '
        'pnlTVQueueButtons
        '
        Me.pnlTVQueueButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTVQueueButtons.Controls.Add(Me.cmdClear)
        Me.pnlTVQueueButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTVQueueButtons.Location = New System.Drawing.Point(0, 832)
        Me.pnlTVQueueButtons.MinimumSize = New System.Drawing.Size(0, 75)
        Me.pnlTVQueueButtons.Name = "pnlTVQueueButtons"
        Me.pnlTVQueueButtons.Size = New System.Drawing.Size(422, 83)
        Me.pnlTVQueueButtons.TabIndex = 2
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(8, 15)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(113, 50)
        Me.cmdClear.TabIndex = 0
        Me.cmdClear.Text = "Clear results"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'tvQueue
        '
        Me.tvQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvQueue.ImageIndex = 0
        Me.tvQueue.ImageList = Me.ilStatus
        Me.tvQueue.Location = New System.Drawing.Point(0, 0)
        Me.tvQueue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tvQueue.Name = "tvQueue"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Models"
        Me.tvQueue.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tvQueue.SelectedImageIndex = 0
        Me.tvQueue.ShowNodeToolTips = True
        Me.tvQueue.Size = New System.Drawing.Size(422, 915)
        Me.tvQueue.TabIndex = 1
        '
        'ilStatus
        '
        Me.ilStatus.ImageStream = CType(resources.GetObject("ilStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ilStatus.Images.SetKeyName(0, "StatusNotStarted_16x.png")
        Me.ilStatus.Images.SetKeyName(1, "StatusRun_16x.png")
        Me.ilStatus.Images.SetKeyName(2, "StatusOK_16x.png")
        Me.ilStatus.Images.SetKeyName(3, "StatusCriticalError_12x_16x.png")
        Me.ilStatus.Images.SetKeyName(4, "FolderOpened_16x.png")
        '
        'txtPostBody
        '
        Me.txtPostBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPostBody.Location = New System.Drawing.Point(0, 0)
        Me.txtPostBody.Name = "txtPostBody"
        Me.txtPostBody.Size = New System.Drawing.Size(1276, 915)
        Me.txtPostBody.TabIndex = 0
        '
        'ilTabs
        '
        Me.ilTabs.ImageStream = CType(resources.GetObject("ilTabs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTabs.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTabs.Images.SetKeyName(0, "Connect_16x.png")
        Me.ilTabs.Images.SetKeyName(1, "Class_16x.png")
        Me.ilTabs.Images.SetKeyName(2, "XMLTransformation_16x.png")
        Me.ilTabs.Images.SetKeyName(3, "StatusRunOutline_16x.png")
        Me.ilTabs.Images.SetKeyName(4, "Print_16x.png")
        Me.ilTabs.Images.SetKeyName(5, "PrintPreview_16x.png")
        Me.ilTabs.Images.SetKeyName(6, "PrintSetup_16x.png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'MainTSContainer
        '
        Me.MainTSContainer.BottomToolStripPanelVisible = False
        '
        'MainTSContainer.ContentPanel
        '
        Me.MainTSContainer.ContentPanel.BackgroundImage = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Fra_Mauro_World_Mapjpg
        Me.MainTSContainer.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MainTSContainer.ContentPanel.Controls.Add(Me.Tabs)
        Me.MainTSContainer.ContentPanel.Size = New System.Drawing.Size(1709, 948)
        Me.MainTSContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTSContainer.LeftToolStripPanelVisible = False
        Me.MainTSContainer.Location = New System.Drawing.Point(0, 33)
        Me.MainTSContainer.Name = "MainTSContainer"
        Me.MainTSContainer.RightToolStripPanelVisible = False
        Me.MainTSContainer.Size = New System.Drawing.Size(1709, 1050)
        Me.MainTSContainer.TabIndex = 6
        Me.MainTSContainer.Text = "Main Toolstrip"
        '
        'MainTSContainer.TopToolStripPanel
        '
        Me.MainTSContainer.TopToolStripPanel.Controls.Add(Me.tsProcess)
        Me.MainTSContainer.TopToolStripPanel.Controls.Add(Me.tsFile)
        Me.MainTSContainer.TopToolStripPanel.Controls.Add(Me.tsPrinting)
        Me.MainTSContainer.TopToolStripPanel.MinimumSize = New System.Drawing.Size(0, 48)
        '
        'tsProcess
        '
        Me.tsProcess.Dock = System.Windows.Forms.DockStyle.None
        Me.tsProcess.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tsProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRun, Me.Counters})
        Me.tsProcess.Location = New System.Drawing.Point(4, 0)
        Me.tsProcess.Name = "tsProcess"
        Me.tsProcess.Size = New System.Drawing.Size(164, 34)
        Me.tsProcess.TabIndex = 5
        Me.tsProcess.Text = "tsProcess"
        '
        'tsbRun
        '
        Me.tsbRun.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Run_16x
        Me.tsbRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRun.Name = "tsbRun"
        Me.tsbRun.Size = New System.Drawing.Size(63, 29)
        Me.tsbRun.Text = "Run"
        '
        'Counters
        '
        Me.Counters.Name = "Counters"
        Me.Counters.Size = New System.Drawing.Size(83, 27)
        Me.Counters.Text = "Counters"
        '
        'tsFile
        '
        Me.tsFile.Dock = System.Windows.Forms.DockStyle.None
        Me.tsFile.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tsFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNewProject, Me.tsOpenProject, Me.tsOpenLast, Me.tsSave, Me.tsSaveAs})
        Me.tsFile.Location = New System.Drawing.Point(4, 34)
        Me.tsFile.Name = "tsFile"
        Me.tsFile.Size = New System.Drawing.Size(579, 34)
        Me.tsFile.TabIndex = 4
        Me.tsFile.Text = "tsFile"
        '
        'tsNewProject
        '
        Me.tsNewProject.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.NewFile_16x
        Me.tsNewProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsNewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNewProject.Name = "tsNewProject"
        Me.tsNewProject.Size = New System.Drawing.Size(127, 29)
        Me.tsNewProject.Text = "New project"
        Me.tsNewProject.ToolTipText = "Create a new project"
        '
        'tsOpenProject
        '
        Me.tsOpenProject.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.OpenProject_16x
        Me.tsOpenProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOpenProject.Name = "tsOpenProject"
        Me.tsOpenProject.Size = New System.Drawing.Size(76, 29)
        Me.tsOpenProject.Text = "Open"
        Me.tsOpenProject.ToolTipText = "Open an existing project"
        '
        'tsOpenLast
        '
        Me.tsOpenLast.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.OpenFile_16x
        Me.tsOpenLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsOpenLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOpenLast.Name = "tsOpenLast"
        Me.tsOpenLast.Size = New System.Drawing.Size(198, 29)
        Me.tsOpenLast.Text = "Open the last project"
        '
        'tsSave
        '
        Me.tsSave.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Save_16x
        Me.tsSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(69, 29)
        Me.tsSave.Text = "Save"
        Me.tsSave.ToolTipText = "Save current project"
        '
        'tsSaveAs
        '
        Me.tsSaveAs.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.SaveAs_16x
        Me.tsSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveAs.Name = "tsSaveAs"
        Me.tsSaveAs.Size = New System.Drawing.Size(91, 29)
        Me.tsSaveAs.Text = "Save as"
        Me.tsSaveAs.ToolTipText = "Save the current project using a new filename"
        '
        'tsPrinting
        '
        Me.tsPrinting.AllowItemReorder = True
        Me.tsPrinting.Dock = System.Windows.Forms.DockStyle.None
        Me.tsPrinting.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tsPrinting.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPrint, Me.tsbPreview})
        Me.tsPrinting.Location = New System.Drawing.Point(4, 68)
        Me.tsPrinting.Name = "tsPrinting"
        Me.tsPrinting.Size = New System.Drawing.Size(220, 34)
        Me.tsPrinting.TabIndex = 3
        Me.tsPrinting.Text = "Printing"
        '
        'tsbPrint
        '
        Me.tsbPrint.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Print_16x
        Me.tsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.MergeIndex = 2
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(68, 29)
        Me.tsbPrint.Text = "Print"
        '
        'tsbPreview
        '
        Me.tsbPreview.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.PrintPreview_16x
        Me.tsbPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreview.Name = "tsbPreview"
        Me.tsbPreview.Size = New System.Drawing.Size(134, 29)
        Me.tsbPreview.Text = "Print preview"
        '
        'BGPicture
        '
        Me.BGPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BGPicture.Image = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Fra_Mauro_World_Mapjpg
        Me.BGPicture.Location = New System.Drawing.Point(0, 33)
        Me.BGPicture.Name = "BGPicture"
        Me.BGPicture.Size = New System.Drawing.Size(1709, 1050)
        Me.BGPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.BGPicture.TabIndex = 4
        Me.BGPicture.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MauroDataModeller.My.Resources.MauroTemplateManager.Fra_Mauro_World_Mapjpg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1709, 1115)
        Me.Controls.Add(Me.MainTSContainer)
        Me.Controls.Add(Me.BGPicture)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Mnu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.Mnu
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmMain"
        Me.Text = "Mauro Template Manager"
        Me.Mnu.ResumeLayout(False)
        Me.Mnu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ActionsTab.ResumeLayout(False)
        Me.scActions.Panel1.ResumeLayout(False)
        Me.scActions.Panel1.PerformLayout()
        Me.scActions.Panel2.ResumeLayout(False)
        CType(Me.scActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scActions.ResumeLayout(False)
        Me.pnlActionsTabButtons.ResumeLayout(False)
        Me.pnlActionProperties.ResumeLayout(False)
        Me.PnlActionsTabActionProperties.ResumeLayout(False)
        Me.PnlActionsTabActionProperties.PerformLayout()
        Me.grpActionType.ResumeLayout(False)
        Me.grpActionType.PerformLayout()
        Me.ModelsTab.ResumeLayout(False)
        Me.ModelsContainer.Panel1.ResumeLayout(False)
        Me.ModelsContainer.Panel2.ResumeLayout(False)
        CType(Me.ModelsContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ModelsContainer.ResumeLayout(False)
        Me.pnlModelButtons.ResumeLayout(False)
        Me.pnlModelButtons.PerformLayout()
        Me.pnlRemoveModelButtons.ResumeLayout(False)
        Me.ProjectTab.ResumeLayout(False)
        Me.PnlProjectSettingsRight.ResumeLayout(False)
        Me.PnlProjectSettingsRight.PerformLayout()
        Me.pnlProjectSettings.ResumeLayout(False)
        Me.pnlProjectSettings.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.Queue.ResumeLayout(False)
        CType(Me.pbProgressHidden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scModels.Panel1.ResumeLayout(False)
        Me.scModels.Panel2.ResumeLayout(False)
        CType(Me.scModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scModels.ResumeLayout(False)
        Me.pnlTVQueueButtons.ResumeLayout(False)
        Me.MainTSContainer.ContentPanel.ResumeLayout(False)
        Me.MainTSContainer.TopToolStripPanel.ResumeLayout(False)
        Me.MainTSContainer.TopToolStripPanel.PerformLayout()
        Me.MainTSContainer.ResumeLayout(False)
        Me.MainTSContainer.PerformLayout()
        Me.tsProcess.ResumeLayout(False)
        Me.tsProcess.PerformLayout()
        Me.tsFile.ResumeLayout(False)
        Me.tsFile.PerformLayout()
        Me.tsPrinting.ResumeLayout(False)
        Me.tsPrinting.PerformLayout()
        CType(Me.BGPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Mnu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSaveAs As ToolStripMenuItem
    Friend WithEvents ImportExportToolStripSeparator As ToolStripSeparator
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusEndpoint As ToolStripStatusLabel
    Friend WithEvents SavedState As ToolStripStatusLabel
    Friend WithEvents OpenDialogue As OpenFileDialog
    Friend WithEvents StatusFilename As ToolStripStatusLabel
    Friend WithEvents PrintToolStripSeparator As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSave As ToolStripMenuItem
    Friend WithEvents SaveDialogue As SaveFileDialog
    Friend WithEvents ActionsTab As TabPage
    Friend WithEvents scActions As SplitContainer
    Friend WithEvents pnlActionsTabButtons As Panel
    Friend WithEvents cmdAddAction As Button
    Friend WithEvents pnlActionProperties As Panel
    Friend WithEvents grpActionType As GroupBox
    Friend WithEvents rbTerminology As RadioButton
    Friend WithEvents rbClass As RadioButton
    Friend WithEvents rbModel As RadioButton
    Friend WithEvents ModelsTab As TabPage
    Friend WithEvents ProjectTab As TabPage
    Friend WithEvents PnlProjectSettingsRight As Panel
    Friend WithEvents lblError As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtEndpointURL As TextBox
    Friend WithEvents lblFilename As Label
    Friend WithEvents pnlProjectSettings As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlActionsTabActionProperties As Panel
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
    Friend WithEvents pnlModelButtons As Panel
    Friend WithEvents txtModelGUID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdAdd As Button
    Friend WithEvents LoginStatus As ToolStripStatusLabel
    Friend WithEvents cmdLogInOut As Button
    Friend WithEvents cmdDoAll As Button
    Friend WithEvents cmdSingleAction As Button
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
    Friend WithEvents rbAllModels As RadioButton
    Friend WithEvents mnuOpenRecent As ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ilTabs As ImageList
    Friend WithEvents txtTemplate As ScintillaNET.Scintilla
    Friend WithEvents BGPicture As PictureBox
    Friend WithEvents pnlTVQueueButtons As Panel
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdAddGUID As Button
    Friend WithEvents pnlRemoveModelButtons As Panel
    Friend WithEvents cmdRemoveModel As Button
    Friend WithEvents MainTSContainer As ToolStripContainer
    Friend WithEvents txtPostBody As ScintillaNET.Scintilla
    Friend WithEvents pbProgressHidden As PictureBox
    Friend WithEvents tsProcess As ToolStrip
    Friend WithEvents tsbRun As ToolStripButton
    Friend WithEvents Counters As ToolStripStatusLabel
    Friend WithEvents tsFile As ToolStrip
    Friend WithEvents tsNewProject As ToolStripButton
    Friend WithEvents tsOpenProject As ToolStripButton
    Friend WithEvents tsOpenLast As ToolStripButton
    Friend WithEvents tsSave As ToolStripButton
    Friend WithEvents tsSaveAs As ToolStripButton
    Friend WithEvents tsPrinting As ToolStrip
    Friend WithEvents tsbPrint As ToolStripButton
    Friend WithEvents tsbPreview As ToolStripButton
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
End Class
