namespace Simple_Program_Launcher
{
    partial class LauncherForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InstallProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.CheckForUpdateButton = new System.Windows.Forms.Button();
            this.StartApplicationButton = new System.Windows.Forms.Button();
            this.ForceUpdateButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.DownloadPercentage = new System.Windows.Forms.Label();
            this.InstallPercentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 502);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Install";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Download";
            // 
            // InstallProgressBar
            // 
            this.InstallProgressBar.Location = new System.Drawing.Point(16, 529);
            this.InstallProgressBar.Name = "InstallProgressBar";
            this.InstallProgressBar.Size = new System.Drawing.Size(796, 23);
            this.InstallProgressBar.TabIndex = 2;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(16, 476);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(796, 23);
            this.DownloadProgressBar.TabIndex = 3;
            // 
            // CheckForUpdateButton
            // 
            this.CheckForUpdateButton.Location = new System.Drawing.Point(828, 476);
            this.CheckForUpdateButton.Name = "CheckForUpdateButton";
            this.CheckForUpdateButton.Size = new System.Drawing.Size(110, 35);
            this.CheckForUpdateButton.TabIndex = 4;
            this.CheckForUpdateButton.Text = "Check For Update";
            this.CheckForUpdateButton.UseVisualStyleBackColor = true;
            this.CheckForUpdateButton.Click += new System.EventHandler(this.CheckForUpdateButton_Click);
            // 
            // StartApplicationButton
            // 
            this.StartApplicationButton.Location = new System.Drawing.Point(962, 476);
            this.StartApplicationButton.Name = "StartApplicationButton";
            this.StartApplicationButton.Size = new System.Drawing.Size(106, 35);
            this.StartApplicationButton.TabIndex = 5;
            this.StartApplicationButton.Text = "Start";
            this.StartApplicationButton.UseVisualStyleBackColor = true;
            this.StartApplicationButton.Click += new System.EventHandler(this.StartApplicationButton_Click);
            // 
            // ForceUpdateButton
            // 
            this.ForceUpdateButton.Location = new System.Drawing.Point(828, 517);
            this.ForceUpdateButton.Name = "ForceUpdateButton";
            this.ForceUpdateButton.Size = new System.Drawing.Size(110, 35);
            this.ForceUpdateButton.TabIndex = 6;
            this.ForceUpdateButton.Text = "Force Update";
            this.ForceUpdateButton.UseVisualStyleBackColor = true;
            this.ForceUpdateButton.Click += new System.EventHandler(this.ForceUpdateButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(962, 523);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(106, 29);
            this.SettingsButton.TabIndex = 7;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DownloadPercentage
            // 
            this.DownloadPercentage.AutoSize = true;
            this.DownloadPercentage.Location = new System.Drawing.Point(103, 457);
            this.DownloadPercentage.Name = "DownloadPercentage";
            this.DownloadPercentage.Size = new System.Drawing.Size(0, 13);
            this.DownloadPercentage.TabIndex = 8;
            // 
            // InstallPercentage
            // 
            this.InstallPercentage.AutoSize = true;
            this.InstallPercentage.Location = new System.Drawing.Point(64, 510);
            this.InstallPercentage.Name = "InstallPercentage";
            this.InstallPercentage.Size = new System.Drawing.Size(0, 13);
            this.InstallPercentage.TabIndex = 9;
            // 
            // LauncherForm
            // 
            this.ClientSize = new System.Drawing.Size(1080, 564);
            this.Controls.Add(this.InstallPercentage);
            this.Controls.Add(this.DownloadPercentage);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ForceUpdateButton);
            this.Controls.Add(this.StartApplicationButton);
            this.Controls.Add(this.CheckForUpdateButton);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.InstallProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "LauncherForm";
            this.Text = "Simple Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar InstallProgressBar;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Button CheckForUpdateButton;
        private System.Windows.Forms.Button StartApplicationButton;
        private System.Windows.Forms.Button ForceUpdateButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Label DownloadPercentage;
        private System.Windows.Forms.Label InstallPercentage;
    }
}

