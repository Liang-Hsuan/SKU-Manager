namespace SKU_Manager.SplashModules.Activate
{
    partial class ActivateFamily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateFamily));
            this.productFamilyCombobox = new System.Windows.Forms.ComboBox();
            this.shortEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.productFamilyLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.activateFamilyButton = new System.Windows.Forms.Button();
            this.backgroundWorkerCombobox = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActivate = new System.ComponentModel.BackgroundWorker();
            this.reorderLevelUpdown = new System.Windows.Forms.NumericUpDown();
            this.reorderLevelLabel = new System.Windows.Forms.Label();
            this.reorderQtyUpdown = new System.Windows.Forms.NumericUpDown();
            this.reorderQtyLabel = new System.Windows.Forms.Label();
            this.pricingTierUpdown = new System.Windows.Forms.NumericUpDown();
            this.pricingTierLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.reorderLevelUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reorderQtyUpdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricingTierUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // productFamilyCombobox
            // 
            this.productFamilyCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.productFamilyCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.productFamilyCombobox.FormattingEnabled = true;
            this.productFamilyCombobox.Location = new System.Drawing.Point(245, 144);
            this.productFamilyCombobox.Name = "productFamilyCombobox";
            this.productFamilyCombobox.Size = new System.Drawing.Size(481, 21);
            this.productFamilyCombobox.TabIndex = 3;
            this.productFamilyCombobox.SelectedValueChanged += new System.EventHandler(this.productFamilyCombobox_SelectedValueChanged);
            // 
            // shortEnglishDescriptionTextbox
            // 
            this.shortEnglishDescriptionTextbox.Enabled = false;
            this.shortEnglishDescriptionTextbox.Location = new System.Drawing.Point(245, 221);
            this.shortEnglishDescriptionTextbox.Name = "shortEnglishDescriptionTextbox";
            this.shortEnglishDescriptionTextbox.Size = new System.Drawing.Size(481, 20);
            this.shortEnglishDescriptionTextbox.TabIndex = 5;
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 221);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 4;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // productFamilyLabel
            // 
            this.productFamilyLabel.AutoSize = true;
            this.productFamilyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productFamilyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.productFamilyLabel.Location = new System.Drawing.Point(21, 145);
            this.productFamilyLabel.Name = "productFamilyLabel";
            this.productFamilyLabel.Size = new System.Drawing.Size(121, 20);
            this.productFamilyLabel.TabIndex = 2;
            this.productFamilyLabel.Text = "Product Family";
            // 
            // detailLabel
            // 
            this.detailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.Black;
            this.detailLabel.Location = new System.Drawing.Point(0, 69);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(746, 29);
            this.detailLabel.TabIndex = 1;
            this.detailLabel.Text = "Product Family Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(746, 60);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Activate Product Family";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.progressBar.Location = new System.Drawing.Point(188, 361);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 12;
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(373, 451);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 15;
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
            this.activeListButton.Location = new System.Drawing.Point(188, 451);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 14;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeListButton_Click);
            // 
            // activateFamilyButton
            // 
            this.activateFamilyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activateFamilyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.activateFamilyButton.Enabled = false;
            this.activateFamilyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateFamilyButton.ForeColor = System.Drawing.Color.Black;
            this.activateFamilyButton.Location = new System.Drawing.Point(188, 369);
            this.activateFamilyButton.Name = "activateFamilyButton";
            this.activateFamilyButton.Size = new System.Drawing.Size(370, 76);
            this.activateFamilyButton.TabIndex = 13;
            this.activateFamilyButton.Text = "Activate Family";
            this.activateFamilyButton.UseVisualStyleBackColor = false;
            this.activateFamilyButton.Click += new System.EventHandler(this.activateFamilyButton_Click);
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
            // reorderLevelUpdown
            // 
            this.reorderLevelUpdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reorderLevelUpdown.Enabled = false;
            this.reorderLevelUpdown.Location = new System.Drawing.Point(635, 294);
            this.reorderLevelUpdown.Name = "reorderLevelUpdown";
            this.reorderLevelUpdown.Size = new System.Drawing.Size(91, 20);
            this.reorderLevelUpdown.TabIndex = 11;
            // 
            // reorderLevelLabel
            // 
            this.reorderLevelLabel.AutoSize = true;
            this.reorderLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderLevelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.reorderLevelLabel.Location = new System.Drawing.Point(515, 294);
            this.reorderLevelLabel.Name = "reorderLevelLabel";
            this.reorderLevelLabel.Size = new System.Drawing.Size(114, 20);
            this.reorderLevelLabel.TabIndex = 10;
            this.reorderLevelLabel.Text = "Reorder Level";
            // 
            // reorderQtyUpdown
            // 
            this.reorderQtyUpdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reorderQtyUpdown.Enabled = false;
            this.reorderQtyUpdown.Location = new System.Drawing.Point(384, 294);
            this.reorderQtyUpdown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.reorderQtyUpdown.Name = "reorderQtyUpdown";
            this.reorderQtyUpdown.Size = new System.Drawing.Size(91, 20);
            this.reorderQtyUpdown.TabIndex = 9;
            // 
            // reorderQtyLabel
            // 
            this.reorderQtyLabel.AutoSize = true;
            this.reorderQtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderQtyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.reorderQtyLabel.Location = new System.Drawing.Point(278, 294);
            this.reorderQtyLabel.Name = "reorderQtyLabel";
            this.reorderQtyLabel.Size = new System.Drawing.Size(100, 20);
            this.reorderQtyLabel.TabIndex = 8;
            this.reorderQtyLabel.Text = "Reorder Qty";
            // 
            // pricingTierUpdown
            // 
            this.pricingTierUpdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pricingTierUpdown.Enabled = false;
            this.pricingTierUpdown.Location = new System.Drawing.Point(122, 294);
            this.pricingTierUpdown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.pricingTierUpdown.Name = "pricingTierUpdown";
            this.pricingTierUpdown.Size = new System.Drawing.Size(91, 20);
            this.pricingTierUpdown.TabIndex = 7;
            // 
            // pricingTierLabel
            // 
            this.pricingTierLabel.AutoSize = true;
            this.pricingTierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricingTierLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.pricingTierLabel.Location = new System.Drawing.Point(21, 294);
            this.pricingTierLabel.Name = "pricingTierLabel";
            this.pricingTierLabel.Size = new System.Drawing.Size(95, 20);
            this.pricingTierLabel.TabIndex = 6;
            this.pricingTierLabel.Text = "Pricing Tier";
            // 
            // ActivateFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 528);
            this.Controls.Add(this.reorderLevelUpdown);
            this.Controls.Add(this.reorderLevelLabel);
            this.Controls.Add(this.reorderQtyUpdown);
            this.Controls.Add(this.reorderQtyLabel);
            this.Controls.Add(this.pricingTierUpdown);
            this.Controls.Add(this.pricingTierLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.activateFamilyButton);
            this.Controls.Add(this.productFamilyCombobox);
            this.Controls.Add(this.shortEnglishDescriptionTextbox);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.productFamilyLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ActivateFamily";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activate Family";
            ((System.ComponentModel.ISupportInitialize)(this.reorderLevelUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reorderQtyUpdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricingTierUpdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox productFamilyCombobox;
        private System.Windows.Forms.TextBox shortEnglishDescriptionTextbox;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.Label productFamilyLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button activateFamilyButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActivate;
        private System.Windows.Forms.NumericUpDown reorderLevelUpdown;
        private System.Windows.Forms.Label reorderLevelLabel;
        private System.Windows.Forms.NumericUpDown reorderQtyUpdown;
        private System.Windows.Forms.Label reorderQtyLabel;
        private System.Windows.Forms.NumericUpDown pricingTierUpdown;
        private System.Windows.Forms.Label pricingTierLabel;
    }
}