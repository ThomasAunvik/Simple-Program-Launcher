using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Program_Launcher
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            InstallDirectoryInput.Text = LauncherForm.ApplicationDirectory;
            DownloadDirectoryInput.Text = LauncherForm.DownloadLocation;
        }

        private void SelectInstallDirectory_Click(object sender, EventArgs e)
        {
            InstallDirectoryInput.Text = GetSelectedDirectory(InstallDirectoryInput.Text);
        }

        private void SelectDownloadDirectory_Click(object sender, EventArgs e)
        {
            DownloadDirectoryInput.Text = GetSelectedDirectory(DownloadDirectoryInput.Text);
        }

        string GetSelectedDirectory(string previousDirectory)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }
            return previousDirectory;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Save_Settings save_Settings = new Save_Settings() { InstallDirectory = InstallDirectoryInput.Text, DownloadDirectory = DownloadDirectoryInput.Text };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(save_Settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Settings.json", json);

            if (string.IsNullOrWhiteSpace(InstallDirectoryInput.Text)) LauncherForm.ApplicationDirectory = InstallDirectoryInput.Text;
            if (string.IsNullOrWhiteSpace(DownloadDirectoryInput.Text)) LauncherForm.DownloadLocation = DownloadDirectoryInput.Text;

            DialogResult = DialogResult.OK;
        }

        private void InstallDirectoryInput_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InstallDirectoryInput.Text)) {
                string newDirectory = new FileInfo(InstallDirectoryInput.Text).FullName;
                InstallDirectoryInput.Text = newDirectory;
            }
            else InstallDirectoryInput.Text = LauncherForm.ApplicationDirectory;
        }

        private void DownloadDirectoryInput_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DownloadDirectoryInput.Text))
            {
                string newDirectory = new FileInfo(DownloadDirectoryInput.Text).FullName;
                DownloadDirectoryInput.Text = newDirectory;
            }
            else DownloadDirectoryInput.Text = LauncherForm.DownloadLocation;
        }
    }

    class Save_Settings
    {
        public string InstallDirectory;
        public string DownloadDirectory;
    }
}
