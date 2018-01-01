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

            // Sets the directory of the current place in the input
            InstallDirectoryInput.Text = LauncherForm.ApplicationDirectory;
            DownloadDirectoryInput.Text = LauncherForm.DownloadLocation;
        }

        /// <summary>
        /// Starts up a dialoge on what directory to choose for the install
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInstallDirectory_Click(object sender, EventArgs e)
        {
            InstallDirectoryInput.Text = GetSelectedDirectory(InstallDirectoryInput.Text);
        }

        /// <summary>
        /// Starts up a dialoge on what directory to choose for the download
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDownloadDirectory_Click(object sender, EventArgs e)
        {
            DownloadDirectoryInput.Text = GetSelectedDirectory(DownloadDirectoryInput.Text);
        }

        /// <summary>
        /// Gets the directory of what the user chooses,
        /// </summary>
        /// <param name="previousDirectory"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cancels the settings menu, saving nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Confirms the changes and closes the settings menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // Creates a new setting to save
            Save_Settings save_Settings = new Save_Settings() { InstallDirectory = InstallDirectoryInput.Text, DownloadDirectory = DownloadDirectoryInput.Text };
            // Turns the object into json format
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(save_Settings, Newtonsoft.Json.Formatting.Indented);
            // Writes the json
            File.WriteAllText("Settings.json", json);

            // Sets the selected directory
            if (!string.IsNullOrWhiteSpace(InstallDirectoryInput.Text)) LauncherForm.ApplicationDirectory = InstallDirectoryInput.Text;
            if (!string.IsNullOrWhiteSpace(DownloadDirectoryInput.Text)) LauncherForm.DownloadLocation = DownloadDirectoryInput.Text;

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Automaticly changes the weird directory to something better
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstallDirectoryInput_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InstallDirectoryInput.Text)) {
                string newDirectory = new FileInfo(InstallDirectoryInput.Text).FullName;
                InstallDirectoryInput.Text = newDirectory;
            }
            else InstallDirectoryInput.Text = LauncherForm.ApplicationDirectory;
        }

        /// <summary>
        /// Automaticly changes the weird directory to something better
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
