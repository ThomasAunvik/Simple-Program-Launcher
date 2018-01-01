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
        public LauncherForm()
        {
            InitializeComponent();
            try
            {
                Save_Settings save_Settings = null;
                if (File.Exists("Settings.json")) save_Settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Save_Settings>(File.ReadAllText("Settings.json"));

                if (save_Settings != null)
                {
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
        }

        private string JsonWebLink = "https://raw.githubusercontent.com/ThomasAunvik/Simple-Program-Launcher/master/update.json";
        private string JsonFileName = "update.json";
        private string ApplicationName = "Application";
        public static string ApplicationDirectory = "ExtractedApplication";
        public static string DownloadLocation = "DownloadedApplication";

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
        
        public UpdateProgramClass webJson;
        public UpdateProgramClass GetFromWebsite()
        {
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData(JsonWebLink);

            string webData = Encoding.UTF8.GetString(raw);

            UpdateProgramClass data = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProgramClass>(webData);
            webJson = data;
            return data;
        }

        public UpdateProgramClass GetFromLocal()
        {
            string localJson = ApplicationDirectory + "\\" + JsonFileName;
            if (File.Exists(localJson))
            {
                string jsonData = File.ReadAllText(localJson);
                UpdateProgramClass data = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProgramClass>(jsonData);
                return data;
            }
            return null;
        }

        public bool CheckDifferences()
        {
            UpdateProgramClass webJson = GetFromWebsite();
            UpdateProgramClass localJson = GetFromLocal();
            return localJson == null || localJson.version != webJson.version;
        }

        private void DownloadAndInstall(UpdateProgramClass webJson)
        {
            StartApplicationButton.Enabled = false;
            CheckForUpdateButton.Enabled = false;
            ForceUpdateButton.Enabled = false;

            if (!Directory.Exists(ApplicationDirectory)) Directory.CreateDirectory(ApplicationDirectory);
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

            Console.WriteLine("Downloading game files...");
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += DownloadProgressChanged;
            wc.DownloadFileCompleted += DownloadCompleted;
            wc.DownloadFileAsync(new Uri(webJson.url), DownloadLocation + "\\" + ApplicationName +".zip");
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Completed, now installling.");

            FastZipEvents zipEvents = new FastZipEvents();
            FastZip zip = new FastZip(zipEvents);
            zipEvents.Progress += ZipProgress;

            Task.Run(() => ExtractZipFromDownload(zip));
        }

        private void ExtractZipFromDownload(FastZip zip)
        {
            zip.ExtractZip(DownloadLocation + "\\" + ApplicationName + ".zip", ApplicationDirectory, "");

            string newJson = Newtonsoft.Json.JsonConvert.SerializeObject(webJson);
            FileStream stream = File.Create(ApplicationDirectory + "\\" + JsonFileName);
            stream.Close();
            File.WriteAllText(ApplicationDirectory + "\\" + JsonFileName, newJson);

            StartApplicationButton.Enabled = true;
            CheckForUpdateButton.Enabled = true;
            ForceUpdateButton.Enabled = true;
        }

        private void ZipProgress(object sender, ProgressEventArgs e)
        {
            InstallProgressBar.Value = (int)(e.PercentComplete);
            InstallPercentage.Text = (int)(e.PercentComplete) + "% Extracting... " + e.Target;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressBar.Value = e.ProgressPercentage;
            DownloadPercentage.Text = e.ProgressPercentage + "% (" + e.BytesReceived + "b / " + e.TotalBytesToReceive + "b)";
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog(this);
            
        }
    }

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
