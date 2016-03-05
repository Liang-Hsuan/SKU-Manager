namespace SKU_Manager.SplashModules.Deactivate
{
    partial class DeactivateDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeactivateDesign));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.deactivateDesignButton = new System.Windows.Forms.Button();
            this.extendedDescriptionLabel = new System.Windows.Forms.Label();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.internalNameLabel = new System.Windows.Forms.Label();
            this.designServiceFlagLabel = new System.Windows.Forms.Label();
            this.brandLabel = new System.Windows.Forms.Label();
            this.productFamilyLabel = new System.Windows.Forms.Label();
            this.extendedDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.internalNameTextbox = new System.Windows.Forms.TextBox();
            this.designServiceFlagTextbox = new System.Windows.Forms.TextBox();
            this.brandTextbox = new System.Windows.Forms.TextBox();
            this.productFamilyTextbox = new System.Windows.Forms.TextBox();
            this.designCodeCombobox = new System.Windows.Forms.ComboBox();
            this.designCodeLabel = new System.Windows.Forms.Label();
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
            this.progressBar.Location = new System.Drawing.Point(188, 528);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 36;
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(374, 618);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 39;
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
            this.activeListButton.Location = new System.Drawing.Point(188, 618);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 38;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeListButton_Click);
            // 
            // deactivateDesignButton
            // 
            this.deactivateDesignButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deactivateDesignButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deactivateDesignButton.Enabled = false;
            this.deactivateDesignButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deactivateDesignButton.ForeColor = System.Drawing.Color.White;
            this.deactivateDesignButton.Location = new System.Drawing.Point(188, 536);
            this.deactivateDesignButton.Name = "deactivateDesignButton";
            this.deactivateDesignButton.Size = new System.Drawing.Size(370, 76);
            this.deactivateDesignButton.TabIndex = 37;
            this.deactivateDesignButton.Text = "Deactivate Design";
            this.deactivateDesignButton.UseVisualStyleBackColor = false;
            this.deactivateDesignButton.Click += new System.EventHandler(this.deactivateDesignButton_Click);
            // 
            // extendedDescriptionLabel
            // 
            this.extendedDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedDescriptionLabel.AutoSize = true;
            this.extendedDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.extendedDescriptionLabel.Location = new System.Drawing.Point(23, 340);
            this.extendedDescriptionLabel.Name = "extendedDescriptionLabel";
            this.extendedDescriptionLabel.Size = new System.Drawing.Size(169, 20);
            this.extendedDescriptionLabel.TabIndex = 34;
            this.extendedDescriptionLabel.Text = "Extended Description";
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(23, 291);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 32;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // internalNameLabel
            // 
            this.internalNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.internalNameLabel.AutoSize = true;
            this.internalNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.internalNameLabel.Location = new System.Drawing.Point(23, 262);
            this.internalNameLabel.Name = "internalNameLabel";
            this.internalNameLabel.Size = new System.Drawing.Size(176, 20);
            this.internalNameLabel.TabIndex = 30;
            this.internalNameLabel.Text = "Internal (Ashlin) Name";
            // 
            // designServiceFlagLabel
            // 
            this.designServiceFlagLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.designServiceFlagLabel.AutoSize = true;
            this.designServiceFlagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designServiceFlagLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.designServiceFlagLabel.Location = new System.Drawing.Point(23, 233);
            this.designServiceFlagLabel.Name = "designServiceFlagLabel";
            this.designServiceFlagLabel.Size = new System.Drawing.Size(161, 20);
            this.designServiceFlagLabel.TabIndex = 28;
            this.designServiceFlagLabel.Text = "Design-Service Flag";
            // 
            // brandLabel
            // 
            this.brandLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.brandLabel.Location = new System.Drawing.Point(23, 204);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(54, 20);
            this.brandLabel.TabIndex = 26;
            this.brandLabel.Text = "Brand";
            // 
            // productFamilyLabel
            // 
            this.productFamilyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productFamilyLabel.AutoSize = true;
            this.productFamilyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productFamilyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.productFamilyLabel.Location = new System.Drawing.Point(23, 175);
            this.productFamilyLabel.Name = "productFamilyLabel";
            this.productFamilyLabel.Size = new System.Drawing.Size(121, 20);
            this.productFamilyLabel.TabIndex = 24;
            this.productFamilyLabel.Text = "Product Family";
            // 
            // extendedDescriptionTextbox
            // 
            this.extendedDescriptionTextbox.Enabled = false;
            this.extendedDescriptionTextbox.Location = new System.Drawing.Point(218, 340);
            this.extendedDescriptionTextbox.Multiline = true;
            this.extendedDescriptionTextbox.Name = "extendedDescriptionTextbox";
            this.extendedDescriptionTextbox.Size = new System.Drawing.Size(481, 120);
            this.extendedDescriptionTextbox.TabIndex = 35;
            // 
            // shortDescriptionTextbox
            // 
            this.shortDescriptionTextbox.Enabled = false;
            this.shortDescriptionTextbox.Location = new System.Drawing.Point(218, 291);
            this.shortDescriptionTextbox.Multiline = true;
            this.shortDescriptionTextbox.Name = "shortDescriptionTextbox";
            this.shortDescriptionTextbox.Size = new System.Drawing.Size(481, 40);
            this.shortDescriptionTextbox.TabIndex = 33;
            // 
            // internalNameTextbox
            // 
            this.internalNameTextbox.Enabled = false;
            this.internalNameTextbox.Location = new System.Drawing.Point(218, 262);
            this.internalNameTextbox.Name = "internalNameTextbox";
            this.internalNameTextbox.Size = new System.Drawing.Size(481, 20);
            this.internalNameTextbox.TabIndex = 31;
            // 
            // designServiceFlagTextbox
            // 
            this.designServiceFlagTextbox.Enabled = false;
            this.designServiceFlagTextbox.Location = new System.Drawing.Point(218, 233);
            this.designServiceFlagTextbox.Name = "designServiceFlagTextbox";
            this.designServiceFlagTextbox.Size = new System.Drawing.Size(481, 20);
            this.designServiceFlagTextbox.TabIndex = 29;
            // 
            // brandTextbox
            // 
            this.brandTextbox.Enabled = false;
            this.brandTextbox.Location = new System.Drawing.Point(218, 204);
            this.brandTextbox.Name = "brandTextbox";
            this.brandTextbox.Size = new System.Drawing.Size(481, 20);
            this.brandTextbox.TabIndex = 27;
            // 
            // productFamilyTextbox
            // 
            this.productFamilyTextbox.Enabled = false;
            this.productFamilyTextbox.Location = new System.Drawing.Point(218, 175);
            this.productFamilyTextbox.Name = "productFamilyTextbox";
            this.productFamilyTextbox.Size = new System.Drawing.Size(481, 20);
            this.productFamilyTextbox.TabIndex = 25;
            // 
            // designCodeCombobox
            // 
            this.designCodeCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.designCodeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.designCodeCombobox.FormattingEnabled = true;
            this.designCodeCombobox.Location = new System.Drawing.Point(218, 134);
            this.designCodeCombobox.Name = "designCodeCombobox";
            this.designCodeCombobox.Size = new System.Drawing.Size(481, 21);
            this.designCodeCombobox.TabIndex = 23;
            this.designCodeCombobox.SelectedValueChanged += new System.EventHandler(this.designCodeCombobox_SelectedValueChanged);
            // 
            // designCodeLabel
            // 
            this.designCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.designCodeLabel.AutoSize = true;
            this.designCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.designCodeLabel.Location = new System.Drawing.Point(23, 135);
            this.designCodeLabel.Name = "designCodeLabel";
            this.designCodeLabel.Size = new System.Drawing.Size(168, 20);
            this.designCodeLabel.TabIndex = 22;
            this.designCodeLabel.Text = "Design-Service Code";
            // 
            // detailLabel
            // 
            this.detailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.White;
            this.detailLabel.Location = new System.Drawing.Point(-4, 73);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(754, 29);
            this.detailLabel.TabIndex = 21;
            this.detailLabel.Text = "Design Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(-7, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(761, 60);
            this.titleLabel.TabIndex = 20;
            this.titleLabel.Text = "Deactivate Design";
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
            // DeactivateDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 751);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.deactivateDesignButton);
            this.Controls.Add(this.extendedDescriptionLabel);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.internalNameLabel);
            this.Controls.Add(this.designServiceFlagLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.productFamilyLabel);
            this.Controls.Add(this.extendedDescriptionTextbox);
            this.Controls.Add(this.shortDescriptionTextbox);
            this.Controls.Add(this.internalNameTextbox);
            this.Controls.Add(this.designServiceFlagTextbox);
            this.Controls.Add(this.brandTextbox);
            this.Controls.Add(this.productFamilyTextbox);
            this.Controls.Add(this.designCodeCombobox);
            this.Controls.Add(this.designCodeLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeactivateDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deactivate Design";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button deactivateDesignButton;
        private System.Windows.Forms.Label extendedDescriptionLabel;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.Label internalNameLabel;
        private System.Windows.Forms.Label designServiceFlagLabel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label productFamilyLabel;
        private System.Windows.Forms.TextBox extendedDescriptionTextbox;
        private System.Windows.Forms.TextBox shortDescriptionTextbox;
        private System.Windows.Forms.TextBox internalNameTextbox;
        private System.Windows.Forms.TextBox designServiceFlagTextbox;
        private System.Windows.Forms.TextBox brandTextbox;
        private System.Windows.Forms.TextBox productFamilyTextbox;
        private System.Windows.Forms.ComboBox designCodeCombobox;
        private System.Windows.Forms.Label designCodeLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDeactivate;
    }
}