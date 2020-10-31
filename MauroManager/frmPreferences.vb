Imports MauroDataModeller.Settings

Public Class frmPreferences
    Dim settings As New ApplicationSettings("Mauro")
    Private Sub frmPreferences_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnection.Text = settings.GetAppSetting("EndpointConnection", "https://modelcatalogue.cs.ox.ac.uk/")
        txtUsername.Text = settings.GetAppSetting("DefaultUsername")
        txtRecentFileCount.Text = settings.GetAppSetting("RecentFileCount", "12")
        txtOutputDirectory.Text = settings.GetAppSetting("DefaultOutputDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        Dim p As String = settings.GetPasswordAppSetting()
        txtPassword.Text = p
        Select Case settings.GetAppSetting("SavePassword")
            Case "True"
                cbSavePassword.Checked = True
            Case Else
                cbSavePassword.Checked = False
        End Select
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        settings.SetAppSetting("EndpointConnection", txtConnection.Text)
        settings.SetAppSetting("DefaultUsername", txtUsername.Text)
        settings.SetAppSetting("RecentFileCount", txtRecentFileCount.Text)
        settings.SetPasswordAppSetting(txtPassword.Text)
        settings.SetAppSetting("SavePassword", cbSavePassword.Checked.ToString)
        Me.Close()
    End Sub

    Private Sub cmdBrowseDirectory_Click(sender As Object, e As EventArgs) Handles cmdBrowseDirectory.Click
        FolderBrowserDialog1.SelectedPath = settings.GetAppSetting("DefaultOutputDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        Dim res As DialogResult = FolderBrowserDialog1.ShowDialog()
        If res = DialogResult.OK Then
            settings.SetAppSetting("DefaultOutputDirectory", FolderBrowserDialog1.SelectedPath)
            txtOutputDirectory.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

End Class