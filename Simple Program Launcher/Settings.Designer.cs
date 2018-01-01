namespace Simple_Program_Launcher
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.InstallationDirectoryText = new System.Windows.Forms.Label();
            this.InstallDirectoryInput = new System.Windows.Forms.TextBox();
            this.SelectInstallDirectory = new System.Windows.Forms.Button();
            this.DownloadDirectoryText = new System.Windows.Forms.Label();
            this.SelectDownloadDirectory = new System.Windows.Forms.Button();
            this.DownloadDirectoryInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            resources.ApplyResources(this.ConfirmButton, "ConfirmButton");
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // InstallationDirectoryText
            // 
            resources.ApplyResources(this.InstallationDirectoryText, "InstallationDirectoryText");
            this.InstallationDirectoryText.Name = "InstallationDirectoryText";
            // 
            // InstallDirectoryInput
            // 
            resources.ApplyResources(this.InstallDirectoryInput, "InstallDirectoryInput");
            this.InstallDirectoryInput.Name = "InstallDirectoryInput";
            this.InstallDirectoryInput.Leave += new System.EventHandler(this.InstallDirectoryInput_Leave);
            // 
            // SelectInstallDirectory
            // 
            resources.ApplyResources(this.SelectInstallDirectory, "SelectInstallDirectory");
            this.SelectInstallDirectory.Name = "SelectInstallDirectory";
            this.SelectInstallDirectory.UseVisualStyleBackColor = true;
            this.SelectInstallDirectory.Click += new System.EventHandler(this.SelectInstallDirectory_Click);
            // 
            // DownloadDirectoryText
            // 
            resources.ApplyResources(this.DownloadDirectoryText, "DownloadDirectoryText");
            this.DownloadDirectoryText.Name = "DownloadDirectoryText";
            // 
            // SelectDownloadDirectory
            // 
            resources.ApplyResources(this.SelectDownloadDirectory, "SelectDownloadDirectory");
            this.SelectDownloadDirectory.Name = "SelectDownloadDirectory";
            this.SelectDownloadDirectory.UseVisualStyleBackColor = true;
            this.SelectDownloadDirectory.Click += new System.EventHandler(this.SelectDownloadDirectory_Click);
            // 
            // DownloadDirectoryInput
            // 
            resources.ApplyResources(this.DownloadDirectoryInput, "DownloadDirectoryInput");
            this.DownloadDirectoryInput.Name = "DownloadDirectoryInput";
            this.DownloadDirectoryInput.Leave += new System.EventHandler(this.DownloadDirectoryInput_Leave);
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectDownloadDirectory);
            this.Controls.Add(this.DownloadDirectoryInput);
            this.Controls.Add(this.DownloadDirectoryText);
            this.Controls.Add(this.SelectInstallDirectory);
            this.Controls.Add(this.InstallDirectoryInput);
            this.Controls.Add(this.InstallationDirectoryText);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label InstallationDirectoryText;
        private System.Windows.Forms.TextBox InstallDirectoryInput;
        private System.Windows.Forms.Button SelectInstallDirectory;
        private System.Windows.Forms.Label DownloadDirectoryText;
        private System.Windows.Forms.Button SelectDownloadDirectory;
        private System.Windows.Forms.TextBox DownloadDirectoryInput;
    }
}