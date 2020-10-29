<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferences))
        Me.PreferencesPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConnection = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cbSavePassword = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecentFileCount = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOutputDirectory = New System.Windows.Forms.TextBox()
        Me.cmdBrowseDirectory = New System.Windows.Forms.Button()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.PreferencesPanel.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'PreferencesPanel
        '
        Me.PreferencesPanel.Controls.Add(Me.Label1)
        Me.PreferencesPanel.Controls.Add(Me.txtConnection)
        Me.PreferencesPanel.Controls.Add(Me.Label2)
        Me.PreferencesPanel.Controls.Add(Me.txtUsername)
        Me.PreferencesPanel.Controls.Add(Me.Label5)
        Me.PreferencesPanel.Controls.Add(Me.txtPassword)
        Me.PreferencesPanel.Controls.Add(Me.cbSavePassword)
        Me.PreferencesPanel.Controls.Add(Me.Label3)
        Me.PreferencesPanel.Controls.Add(Me.txtRecentFileCount)
        Me.PreferencesPanel.Controls.Add(Me.Label4)
        Me.PreferencesPanel.Controls.Add(Me.txtOutputDirectory)
        Me.PreferencesPanel.Controls.Add(Me.cmdBrowseDirectory)
        Me.PreferencesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreferencesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PreferencesPanel.Location = New System.Drawing.Point(0, 0)
        Me.PreferencesPanel.Name = "PreferencesPanel"
        Me.PreferencesPanel.Size = New System.Drawing.Size(822, 525)
        Me.PreferencesPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connection endpoint"
        '
        'txtConnection
        '
        Me.txtConnection.Location = New System.Drawing.Point(3, 17)
        Me.txtConnection.Name = "txtConnection"
        Me.txtConnection.Size = New System.Drawing.Size(798, 22)
        Me.txtConnection.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Connection username"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(3, 54)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(798, 22)
        Me.txtUsername.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 75)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Connection password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(3, 93)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(796, 22)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'cbSavePassword
        '
        Me.cbSavePassword.AutoSize = True
        Me.cbSavePassword.Location = New System.Drawing.Point(3, 120)
        Me.cbSavePassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbSavePassword.Name = "cbSavePassword"
        Me.cbSavePassword.Size = New System.Drawing.Size(363, 21)
        Me.cbSavePassword.TabIndex = 11
        Me.cbSavePassword.Text = "Save connection username and password in projects"
        Me.cbSavePassword.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Recently opend file list entries"
        '
        'txtRecentFileCount
        '
        Me.txtRecentFileCount.Location = New System.Drawing.Point(3, 158)
        Me.txtRecentFileCount.Mask = "90"
        Me.txtRecentFileCount.Name = "txtRecentFileCount"
        Me.txtRecentFileCount.Size = New System.Drawing.Size(82, 22)
        Me.txtRecentFileCount.TabIndex = 5
        Me.txtRecentFileCount.ValidatingType = GetType(Integer)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Default output directory"
        '
        'txtOutputDirectory
        '
        Me.txtOutputDirectory.Location = New System.Drawing.Point(3, 196)
        Me.txtOutputDirectory.Name = "txtOutputDirectory"
        Me.txtOutputDirectory.Size = New System.Drawing.Size(798, 22)
        Me.txtOutputDirectory.TabIndex = 7
        '
        'cmdBrowseDirectory
        '
        Me.cmdBrowseDirectory.Location = New System.Drawing.Point(3, 219)
        Me.cmdBrowseDirectory.Name = "cmdBrowseDirectory"
        Me.cmdBrowseDirectory.Size = New System.Drawing.Size(100, 32)
        Me.cmdBrowseDirectory.TabIndex = 8
        Me.cmdBrowseDirectory.Text = "Browse"
        Me.cmdBrowseDirectory.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.cmdSave)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 457)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(822, 68)
        Me.pnlButtons.TabIndex = 1
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(14, 14)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(90, 42)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 525)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.PreferencesPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreferences"
        Me.Text = "Mauro Manager - Preferences"
        Me.PreferencesPanel.ResumeLayout(False)
        Me.PreferencesPanel.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PreferencesPanel As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtConnection As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRecentFileCount As MaskedTextBox
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOutputDirectory As TextBox
    Friend WithEvents cmdBrowseDirectory As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents cbSavePassword As CheckBox
End Class
