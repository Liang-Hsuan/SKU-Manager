namespace SKU_Manager.SplashModules.Deactivate
{
    partial class DeactivateFamily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeactivateFamily));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.deactivateFamilyButton = new System.Windows.Forms.Button();
            this.productFamilyCombobox = new System.Windows.Forms.ComboBox();
            this.shortEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.productFamilyLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.backgroundWorkerCombobox = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDeactivate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.progressBar.Location = new System.Drawing.Point(188, 316);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 16;
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(374, 406);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 19;
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
            this.activeListButton.Location = new System.Drawing.Point(188, 406);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 18;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeListButton_Click);
            // 
            // deactivateFamilyButton
            // 
            this.deactivateFamilyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deactivateFamilyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deactivateFamilyButton.Enabled = false;
            this.deactivateFamilyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deactivateFamilyButton.ForeColor = System.Drawing.Color.White;
            this.deactivateFamilyButton.Location = new System.Drawing.Point(188, 324);
            this.deactivateFamilyButton.Name = "deactivateFamilyButton";
            this.deactivateFamilyButton.Size = new System.Drawing.Size(370, 76);
            this.deactivateFamilyButton.TabIndex = 17;
            this.deactivateFamilyButton.Text = "Deactivate Family";
            this.deactivateFamilyButton.UseVisualStyleBackColor = false;
            this.deactivateFamilyButton.Click += new System.EventHandler(this.deactivateFamilyButton_Click);
            // 
            // productFamilyCombobox
            // 
            this.productFamilyCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.productFamilyCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.productFamilyCombobox.FormattingEnabled = true;
            this.productFamilyCombobox.Location = new System.Drawing.Point(245, 144);
            this.productFamilyCombobox.Name = "productFamilyCombobox";
            this.productFamilyCombobox.Size = new System.Drawing.Size(481, 21);
            this.productFamilyCombobox.TabIndex = 13;
            this.productFamilyCombobox.SelectedValueChanged += new System.EventHandler(this.productFamilyCombobox_SelectedValueChanged);
            // 
            // shortEnglishDescriptionTextbox
            // 
            this.shortEnglishDescriptionTextbox.Enabled = false;
            this.shortEnglishDescriptionTextbox.Location = new System.Drawing.Point(245, 221);
            this.shortEnglishDescriptionTextbox.Name = "shortEnglishDescriptionTextbox";
            this.shortEnglishDescriptionTextbox.Size = new System.Drawing.Size(481, 20);
            this.shortEnglishDescriptionTextbox.TabIndex = 15;
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 221);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 14;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // productFamilyLabel
            // 
            this.productFamilyLabel.AutoSize = true;
            this.productFamilyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productFamilyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.productFamilyLabel.Location = new System.Drawing.Point(21, 145);
            this.productFamilyLabel.Name = "productFamilyLabel";
            this.productFamilyLabel.Size = new System.Drawing.Size(121, 20);
            this.productFamilyLabel.TabIndex = 12;
            this.productFamilyLabel.Text = "Product Family";
            // 
            // detailLabel
            // 
            this.detailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.White;
            this.detailLabel.Location = new System.Drawing.Point(0, 69);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(746, 29);
            this.detailLabel.TabIndex = 11;
            this.detailLabel.Text = "Product Family Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(746, 60);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Deactivate Product Family";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // backgroundWorkerDeactivate
            // 
            this.backgroundWorkerDeactivate.WorkerReportsProgress = true;
            this.backgroundWorkerDeactivate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDeactivate_DoWork);
            this.backgroundWorkerDeactivate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDeactivate_ProgressChanged);
            // 
            // DeactivateFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 528);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.deactivateFamilyButton);
            this.Controls.Add(this.productFamilyCombobox);
            this.Controls.Add(this.shortEnglishDescriptionTextbox);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.productFamilyLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeactivateFamily";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deactivate Family";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button deactivateFamilyButton;
        private System.Windows.Forms.ComboBox productFamilyCombobox;
        private System.Windows.Forms.TextBox shortEnglishDescriptionTextbox;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.Label productFamilyLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDeactivate;
    }
}