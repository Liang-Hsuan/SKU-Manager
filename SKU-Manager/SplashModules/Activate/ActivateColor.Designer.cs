namespace SKU_Manager.SplashModules.Activate
{
    partial class ActivateColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateColor));
            this.colorCodeLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.colorCodeCombobox = new System.Windows.Forms.ComboBox();
            this.extendedDescriptionLabel = new System.Windows.Forms.Label();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.shortEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.extendedEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.activateColorButton = new System.Windows.Forms.Button();
            this.backgroundWorkerCombobox = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActivate = new System.ComponentModel.BackgroundWorker();
            this.onlineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorCodeLabel
            // 
            this.colorCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorCodeLabel.AutoSize = true;
            this.colorCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.colorCodeLabel.Location = new System.Drawing.Point(23, 135);
            this.colorCodeLabel.Name = "colorCodeLabel";
            this.colorCodeLabel.Size = new System.Drawing.Size(93, 20);
            this.colorCodeLabel.TabIndex = 2;
            this.colorCodeLabel.Text = "Color Code";
            // 
            // detailLabel
            // 
            this.detailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.Black;
            this.detailLabel.Location = new System.Drawing.Point(-4, 73);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(754, 29);
            this.detailLabel.TabIndex = 1;
            this.detailLabel.Text = "Color Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(-7, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(761, 60);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Activate Color";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorCodeCombobox
            // 
            this.colorCodeCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.colorCodeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.colorCodeCombobox.FormattingEnabled = true;
            this.colorCodeCombobox.Location = new System.Drawing.Point(218, 134);
            this.colorCodeCombobox.Name = "colorCodeCombobox";
            this.colorCodeCombobox.Size = new System.Drawing.Size(481, 21);
            this.colorCodeCombobox.TabIndex = 3;
            this.colorCodeCombobox.SelectedValueChanged += new System.EventHandler(this.colorCodeCombobox_SelectedValueChanged);
            // 
            // extendedDescriptionLabel
            // 
            this.extendedDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedDescriptionLabel.AutoSize = true;
            this.extendedDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.extendedDescriptionLabel.Location = new System.Drawing.Point(21, 295);
            this.extendedDescriptionLabel.Name = "extendedDescriptionLabel";
            this.extendedDescriptionLabel.Size = new System.Drawing.Size(169, 20);
            this.extendedDescriptionLabel.TabIndex = 6;
            this.extendedDescriptionLabel.Text = "Extended Description";
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 215);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 4;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // shortEnglishDescriptionTextbox
            // 
            this.shortEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortEnglishDescriptionTextbox.Enabled = false;
            this.shortEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 215);
            this.shortEnglishDescriptionTextbox.MaxLength = 50;
            this.shortEnglishDescriptionTextbox.Multiline = true;
            this.shortEnglishDescriptionTextbox.Name = "shortEnglishDescriptionTextbox";
            this.shortEnglishDescriptionTextbox.Size = new System.Drawing.Size(481, 59);
            this.shortEnglishDescriptionTextbox.TabIndex = 5;
            // 
            // extendedEnglishDescriptionTextbox
            // 
            this.extendedEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedEnglishDescriptionTextbox.Enabled = false;
            this.extendedEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 295);
            this.extendedEnglishDescriptionTextbox.MaxLength = 1000;
            this.extendedEnglishDescriptionTextbox.Multiline = true;
            this.extendedEnglishDescriptionTextbox.Name = "extendedEnglishDescriptionTextbox";
            this.extendedEnglishDescriptionTextbox.Size = new System.Drawing.Size(481, 190);
            this.extendedEnglishDescriptionTextbox.TabIndex = 7;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.progressBar.Location = new System.Drawing.Point(176, 537);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(362, 627);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 12;
            this.inactiveListButton.Text = "Inactive List";
            this.inactiveListButton.UseVisualStyleBackColor = false;
            this.inactiveListButton.Click += new System.EventHandler(this.inactiveListButton_Click);
            // 
            // activeListButton
            // 
            this.activeListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activeListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.activeListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeListButton.ForeColor = System.Drawing.Color.White;
            this.activeListButton.Location = new System.Drawing.Point(176, 627);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 11;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeListButton_Click);
            // 
            // activateColorButton
            // 
            this.activateColorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activateColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.activateColorButton.Enabled = false;
            this.activateColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateColorButton.ForeColor = System.Drawing.Color.Black;
            this.activateColorButton.Location = new System.Drawing.Point(176, 545);
            this.activateColorButton.Name = "activateColorButton";
            this.activateColorButton.Size = new System.Drawing.Size(370, 76);
            this.activateColorButton.TabIndex = 10;
            this.activateColorButton.Text = "Activate Color";
            this.activateColorButton.UseVisualStyleBackColor = false;
            this.activateColorButton.Click += new System.EventHandler(this.activateColorButton_Click);
            // 
            // backgroundWorkerCombobox
            // 
            this.backgroundWorkerCombobox.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCombobox_DoWork);
            this.backgroundWorkerCombobox.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCombobox_RunWorkerCompleted);
            // 
            // backgroundWorkerInfo
            // 
            this.backgroundWorkerInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInfo_DoWork);
            this.backgroundWorkerInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerActivate
            // 
            this.backgroundWorkerActivate.WorkerReportsProgress = true;
            this.backgroundWorkerActivate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerActivate_DoWork);
            this.backgroundWorkerActivate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerActivate_ProgressChanged);
            // 
            // onlineButton
            // 
            this.onlineButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.onlineButton.Enabled = false;
            this.onlineButton.ForeColor = System.Drawing.Color.Black;
            this.onlineButton.Location = new System.Drawing.Point(25, 455);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(165, 29);
            this.onlineButton.TabIndex = 8;
            this.onlineButton.Text = "Colour Online Description";
            this.onlineButton.UseVisualStyleBackColor = false;
            this.onlineButton.Click += new System.EventHandler(this.onlineButton_Click);
            // 
            // ActivateColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 751);
            this.Controls.Add(this.onlineButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.activateColorButton);
            this.Controls.Add(this.extendedEnglishDescriptionTextbox);
            this.Controls.Add(this.shortEnglishDescriptionTextbox);
            this.Controls.Add(this.extendedDescriptionLabel);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.colorCodeCombobox);
            this.Controls.Add(this.colorCodeLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ActivateColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activate Color";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label colorCodeLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox colorCodeCombobox;
        private System.Windows.Forms.Label extendedDescriptionLabel;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.TextBox shortEnglishDescriptionTextbox;
        private System.Windows.Forms.TextBox extendedEnglishDescriptionTextbox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button activateColorButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActivate;
        private System.Windows.Forms.Button onlineButton;
    }
}