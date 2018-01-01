using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Program_Launcher
{
    public partial class LauncherForm : Form
    {
        public bool connected = true;
        public LauncherForm()
        {
            InitializeComponent();

            // Gets update.json class
            UpdateProgramClass localJson = GetFromLocal();
            if(localJson != null)
            {
                // Sets the local version of the downloaded program
                VersionText.Text = localJson.version;
            }

            try
            {
                Save_Settings save_Settings = null;
                // Gets the settings
                if (File.Exists("Settings.json")) save_Settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Save_Settings>(File.ReadAllText("Settings.json"));

                if (save_Settings != null)
                {
                    // Sets the directories from the settings file
                    if (!string.IsNullOrWhiteSpace(save_Settings.InstallDirectory) && Directory.Exists(save_Settings.InstallDirectory)) {
                        ApplicationDirectory = save_Settings.InstallDirectory;
                    }
                    if (!string.IsNullOrWhiteSpace(save_Settings.DownloadDirectory) && Directory.Exists(save_Settings.DownloadDirectory)) {
                        DownloadLocation = save_Settings.DownloadDirectory;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

            if(!File.Exists(ApplicationDirectory + "\\" + ApplicationName + ".exe"))
            {
                StartApplicationButton.Text = "Download";
            }
        }

        /// <summary>
        /// A Permanent link (hard-coded) for updating/downloading the downloaded program.
        /// </summary>
        private string JsonWebLink = "https://raw.githubusercontent.com/ThomasAunvik/Simple-Program-Launcher/master/update.json";
        /// <summary>
        /// The filename of the update file, could be changed to anything
        /// </summary>
        private string JsonFileName = "update.json";
        /// <summary>
        /// The name of the application, the .exe file also has to be the same name
        /// </summary>
        private string ApplicationName = "Simple Program Launcher";
        /// <summary>
        /// The directory where the downloaded application is going to install
        /// </summary>
        public static string ApplicationDirectory = "ExtractedApplication";
        /// <summary>
        /// The directory where the downloaded application is going to be stored
        /// </summary>
        public static string DownloadLocation = "DownloadedApplication";

        /// <summary>
        /// Starts the installed application, if there isnt already one, install it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartApplicationButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(ApplicationDirectory + "\\" + ApplicationName + ".exe"))
            {
                System.Diagnostics.Process.Start(ApplicationDirectory + "\\" + ApplicationName + ".exe");
                Application.Exit();
            }
            else UpdateGame();
        }

        private void CheckForUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateGame();
        }

        private void ForceUpdateButton_Click(object sender, EventArgs e)
        {
            DownloadAndInstall(GetFromWebsite());
        }
        
        private void UpdateGame()
        {
            if (CheckDifferences()) DownloadAndInstall(webJson);
        }
        
        /// <summary>
        /// This json is where you got it from the jsonURL.
        /// </summary>
        public UpdateProgramClass webJson;
        /// <summary>
        /// This gets the json from the jsonWebLink
        /// </summary>
        /// <returns></returns>
        public UpdateProgramClass GetFromWebsite()
        {
            try
            {
                WebClient wc = new WebClient();
                byte[] raw = wc.DownloadData(JsonWebLink);

                // Turns data into string
                string webData = Encoding.UTF8.GetString(raw);

                // turns json string into a class
                UpdateProgramClass data = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProgramClass>(webData);
                webJson = data;
                connected = true;
                return data;
            }catch(WebException e)
            {
                connected = false;
                ErrorText.Text = "Unable to communicate with the internet... (" + e.Message + ")";
                Console.WriteLine(e.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// Gets the local json.
        /// </summary>
        /// <returns></returns>
        public UpdateProgramClass GetFromLocal()
        {
            string localJson = ApplicationDirectory + "\\" + JsonFileName;
            if (File.Exists(localJson))
            {
                string jsonData = File.ReadAllText(localJson);
                // Turns the json string into class
                UpdateProgramClass data = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProgramClass>(jsonData);
                return data;
            }
            return null;
        }

        /// <summary>
        /// This checks the difference between web and local json, which one is the newest
        /// </summary>
        /// <returns>If there is an update, return true</returns>
        public bool CheckDifferences()
        {
            UpdateProgramClass webJson = GetFromWebsite();
            UpdateProgramClass localJson = GetFromLocal();
            if (!connected) return false;
            return localJson == null || localJson.version != webJson.version;
        }

        /// <summary>
        /// Downloads the program, then installs it later
        /// </summary>
        /// <param name="webJson"></param>
        private void DownloadAndInstall(UpdateProgramClass webJson)
        {
            GetFromWebsite();
            if (!connected) return;

            // Disables the button until the install is done
            StartApplicationButton.Enabled = false;
            CheckForUpdateButton.Enabled = false;
            ForceUpdateButton.Enabled = false;
            SettingsButton.Enabled = false;

            // Checks if the directory does not exist, and then creates it
            if (!Directory.Exists(ApplicationDirectory)) Directory.CreateDirectory(ApplicationDirectory);
            if (!Directory.Exists(DownloadLocation)) Directory.CreateDirectory(DownloadLocation);

            // This deletes everything that is in the application folder, deleting the old files.
            try
            {
                DirectoryInfo di = new DirectoryInfo(ApplicationDirectory);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            // This downloads the program files
            Console.WriteLine("Downloading program files to " + new FileInfo(DownloadLocation + "\\" + ApplicationName + ".zip").FullName + " ...");
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += DownloadProgressChanged;
            wc.DownloadFileCompleted += DownloadCompleted;
            wc.DownloadFileAsync(new Uri(webJson.url), DownloadLocation + "\\" + ApplicationName +".zip");
        }

        /// <summary>
        /// When the download is completed, install it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Completed, now installling.");

            // Initialize the zip events.
            FastZipEvents zipEvents = new FastZipEvents();
            // Creates the zip, including with the zipEvent
            FastZip zip = new FastZip(zipEvents);
            // Sets the delegate for whenever the progress changes
            zipEvents.Progress += ZipProgress;

            // Starts extraxting
            ExtractZipFromDownload(zip);
        }

        /// <summary>
        /// Extracts the program files into the specified installation folder.
        /// </summary>
        /// <param name="zip"></param>
        private void ExtractZipFromDownload(FastZip zip)
        {
            // Checks if the zip file exists, if it does not it wont start
            if (File.Exists(DownloadLocation + "\\" + ApplicationName + ".zip"))
            {
                // Extracts the zip
                zip.ExtractZip(DownloadLocation + "\\" + ApplicationName + ".zip", ApplicationDirectory, "");

                // Updates the old json file into the new one.
                string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(webJson);
                FileStream stream = File.Create(ApplicationDirectory + "\\" + JsonFileName);
                stream.Close();
                File.WriteAllText(ApplicationDirectory + "\\" + JsonFileName, newJson);

            }
            // Enables all buttons again.
            StartApplicationButton.Enabled = true;
            CheckForUpdateButton.Enabled = true;
            ForceUpdateButton.Enabled = true;
            SettingsButton.Enabled = true;

            // Checks if the .exe file exists.
            if (!File.Exists(ApplicationDirectory + "\\" + ApplicationName + ".exe"))
            {
                StartApplicationButton.Text = "Start";
            }
        }

        /// <summary>
        /// This counts the process of the zipping, and sets the progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZipProgress(object sender, ProgressEventArgs e)
        {
            InstallProgressBar.Value = (int)(e.PercentComplete);
            InstallPercentage.Text = (int)(e.PercentComplete) + "% Extracting... ";
        }

        /// <summary>
        /// This counts how much has been downloaded, and sets the progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressBar.Value = e.ProgressPercentage;
            DownloadPercentage.Text = e.ProgressPercentage + "% (" + e.BytesReceived + "b / " + e.TotalBytesToReceive + "b)";
        }

        /// <summary>
        /// Starts up a dialog for the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog(this);
            
        }
    }

    /// <summary>
    /// This is a class for when you are saving which version the program is currently on. (local only needs version)
    /// </summary>
    public class UpdateProgramClass
    {
        public string version;
        public string url;

        public UpdateProgramClass(string version, string url)
        {
            try
            {
                this.version = version;
                this.url = url;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
