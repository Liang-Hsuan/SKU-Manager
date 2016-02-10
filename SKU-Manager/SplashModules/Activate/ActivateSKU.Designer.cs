namespace SKU_Manager.SplashModules.Activate
{
    partial class ActivateSKU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateSKU));
            this.skuCombobox = new System.Windows.Forms.ComboBox();
            this.skuLable = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.designCodeLabel = new System.Windows.Forms.Label();
            this.designDescriptionLabel = new System.Windows.Forms.Label();
            this.internalNameLabel = new System.Windows.Forms.Label();
            this.designServiceFlagLabel = new System.Windows.Forms.Label();
            this.brandLabel = new System.Windows.Forms.Label();
            this.productFamilyLabel = new System.Windows.Forms.Label();
            this.designDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.internalNameTextbox = new System.Windows.Forms.TextBox();
            this.designServiceFlagTextbox = new System.Windows.Forms.TextBox();
            this.brandTextbox = new System.Windows.Forms.TextBox();
            this.productFamilyTextbox = new System.Windows.Forms.TextBox();
            this.designCodeTextbox = new System.Windows.Forms.TextBox();
            this.materialCodeTextbox = new System.Windows.Forms.TextBox();
            this.materialDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.colorCodeTextbox = new System.Windows.Forms.TextBox();
            this.colorDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.materialCodeLabel = new System.Windows.Forms.Label();
            this.materialDescriptionLabel = new System.Windows.Forms.Label();
            this.colorCodeLabel = new System.Windows.Forms.Label();
            this.colorDescriptionLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.activateSKUButton = new System.Windows.Forms.Button();
            this.backgroundWorkerCombobox = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActivate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // skuCombobox
            // 
            this.skuCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.skuCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.skuCombobox.FormattingEnabled = true;
            this.skuCombobox.Location = new System.Drawing.Point(218, 134);
            this.skuCombobox.Name = "skuCombobox";
            this.skuCombobox.Size = new System.Drawing.Size(481, 21);
            this.skuCombobox.TabIndex = 3;
            this.skuCombobox.SelectedValueChanged += new System.EventHandler(this.skuCombobox_SelectedValueChanged);
            // 
            // skuLable
            // 
            this.skuLable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skuLable.AutoSize = true;
            this.skuLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skuLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.skuLable.Location = new System.Drawing.Point(23, 135);
            this.skuLable.Name = "skuLable";
            this.skuLable.Size = new System.Drawing.Size(94, 20);
            this.skuLable.TabIndex = 2;
            this.skuLable.Text = "Ashlin SKU";
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
            this.detailLabel.Text = "SKU Details";
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
            this.titleLabel.Text = "Activate SKU";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // designCodeLabel
            // 
            this.designCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.designCodeLabel.AutoSize = true;
            this.designCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.designCodeLabel.Location = new System.Drawing.Point(23, 180);
            this.designCodeLabel.Name = "designCodeLabel";
            this.designCodeLabel.Size = new System.Drawing.Size(106, 20);
            this.designCodeLabel.TabIndex = 4;
            this.designCodeLabel.Text = "Design Code";
            // 
            // designDescriptionLabel
            // 
            this.designDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.designDescriptionLabel.AutoSize = true;
            this.designDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.designDescriptionLabel.Location = new System.Drawing.Point(23, 310);
            this.designDescriptionLabel.Name = "designDescriptionLabel";
            this.designDescriptionLabel.Size = new System.Drawing.Size(153, 20);
            this.designDescriptionLabel.TabIndex = 14;
            this.designDescriptionLabel.Text = "Design Description";
            // 
            // internalNameLabel
            // 
            this.internalNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.internalNameLabel.AutoSize = true;
            this.internalNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.internalNameLabel.Location = new System.Drawing.Point(23, 284);
            this.internalNameLabel.Name = "internalNameLabel";
            this.internalNameLabel.Size = new System.Drawing.Size(176, 20);
            this.internalNameLabel.TabIndex = 12;
            this.internalNameLabel.Text = "Internal (Ashlin) Name";
            // 
            // designServiceFlagLabel
            // 
            this.designServiceFlagLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.designServiceFlagLabel.AutoSize = true;
            this.designServiceFlagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designServiceFlagLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.designServiceFlagLabel.Location = new System.Drawing.Point(23, 258);
            this.designServiceFlagLabel.Name = "designServiceFlagLabel";
            this.designServiceFlagLabel.Size = new System.Drawing.Size(161, 20);
            this.designServiceFlagLabel.TabIndex = 10;
            this.designServiceFlagLabel.Text = "Design-Service Flag";
            // 
            // brandLabel
            // 
            this.brandLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.brandLabel.AutoSize = true;
            this.brandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.brandLabel.Location = new System.Drawing.Point(23, 232);
            this.brandLabel.Name = "brandLabel";
            this.brandLabel.Size = new System.Drawing.Size(54, 20);
            this.brandLabel.TabIndex = 8;
            this.brandLabel.Text = "Brand";
            // 
            // productFamilyLabel
            // 
            this.productFamilyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productFamilyLabel.AutoSize = true;
            this.productFamilyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productFamilyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.productFamilyLabel.Location = new System.Drawing.Point(23, 206);
            this.productFamilyLabel.Name = "productFamilyLabel";
            this.productFamilyLabel.Size = new System.Drawing.Size(121, 20);
            this.productFamilyLabel.TabIndex = 6;
            this.productFamilyLabel.Text = "Product Family";
            // 
            // designDescriptionTextbox
            // 
            this.designDescriptionTextbox.Enabled = false;
            this.designDescriptionTextbox.Location = new System.Drawing.Point(218, 310);
            this.designDescriptionTextbox.Multiline = true;
            this.designDescriptionTextbox.Name = "designDescriptionTextbox";
            this.designDescriptionTextbox.Size = new System.Drawing.Size(481, 40);
            this.designDescriptionTextbox.TabIndex = 15;
            // 
            // internalNameTextbox
            // 
            this.internalNameTextbox.Enabled = false;
            this.internalNameTextbox.Location = new System.Drawing.Point(218, 284);
            this.internalNameTextbox.Name = "internalNameTextbox";
            this.internalNameTextbox.Size = new System.Drawing.Size(481, 20);
            this.internalNameTextbox.TabIndex = 13;
            // 
            // designServiceFlagTextbox
            // 
            this.designServiceFlagTextbox.Enabled = false;
            this.designServiceFlagTextbox.Location = new System.Drawing.Point(218, 258);
            this.designServiceFlagTextbox.Name = "designServiceFlagTextbox";
            this.designServiceFlagTextbox.Size = new System.Drawing.Size(481, 20);
            this.designServiceFlagTextbox.TabIndex = 11;
            // 
            // brandTextbox
            // 
            this.brandTextbox.Enabled = false;
            this.brandTextbox.Location = new System.Drawing.Point(218, 232);
            this.brandTextbox.Name = "brandTextbox";
            this.brandTextbox.Size = new System.Drawing.Size(481, 20);
            this.brandTextbox.TabIndex = 9;
            // 
            // productFamilyTextbox
            // 
            this.productFamilyTextbox.Enabled = false;
            this.productFamilyTextbox.Location = new System.Drawing.Point(218, 206);
            this.productFamilyTextbox.Name = "productFamilyTextbox";
            this.productFamilyTextbox.Size = new System.Drawing.Size(481, 20);
            this.productFamilyTextbox.TabIndex = 7;
            // 
            // designCodeTextbox
            // 
            this.designCodeTextbox.Enabled = false;
            this.designCodeTextbox.Location = new System.Drawing.Point(218, 180);
            this.designCodeTextbox.Name = "designCodeTextbox";
            this.designCodeTextbox.Size = new System.Drawing.Size(481, 20);
            this.designCodeTextbox.TabIndex = 5;
            // 
            // materialCodeTextbox
            // 
            this.materialCodeTextbox.Enabled = false;
            this.materialCodeTextbox.Location = new System.Drawing.Point(218, 366);
            this.materialCodeTextbox.Name = "materialCodeTextbox";
            this.materialCodeTextbox.Size = new System.Drawing.Size(481, 20);
            this.materialCodeTextbox.TabIndex = 17;
            // 
            // materialDescriptionTextbox
            // 
            this.materialDescriptionTextbox.Enabled = false;
            this.materialDescriptionTextbox.Location = new System.Drawing.Point(218, 392);
            this.materialDescriptionTextbox.Name = "materialDescriptionTextbox";
            this.materialDescriptionTextbox.Size = new System.Drawing.Size(481, 20);
            this.materialDescriptionTextbox.TabIndex = 19;
            // 
            // colorCodeTextbox
            // 
            this.colorCodeTextbox.Enabled = false;
            this.colorCodeTextbox.Location = new System.Drawing.Point(218, 428);
            this.colorCodeTextbox.Name = "colorCodeTextbox";
            this.colorCodeTextbox.Size = new System.Drawing.Size(481, 20);
            this.colorCodeTextbox.TabIndex = 21;
            // 
            // colorDescriptionTextbox
            // 
            this.colorDescriptionTextbox.Enabled = false;
            this.colorDescriptionTextbox.Location = new System.Drawing.Point(218, 454);
            this.colorDescriptionTextbox.Name = "colorDescriptionTextbox";
            this.colorDescriptionTextbox.Size = new System.Drawing.Size(481, 20);
            this.colorDescriptionTextbox.TabIndex = 23;
            // 
            // materialCodeLabel
            // 
            this.materialCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialCodeLabel.AutoSize = true;
            this.materialCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.materialCodeLabel.Location = new System.Drawing.Point(23, 366);
            this.materialCodeLabel.Name = "materialCodeLabel";
            this.materialCodeLabel.Size = new System.Drawing.Size(113, 20);
            this.materialCodeLabel.TabIndex = 16;
            this.materialCodeLabel.Text = "Material Code";
            // 
            // materialDescriptionLabel
            // 
            this.materialDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialDescriptionLabel.AutoSize = true;
            this.materialDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.materialDescriptionLabel.Location = new System.Drawing.Point(23, 392);
            this.materialDescriptionLabel.Name = "materialDescriptionLabel";
            this.materialDescriptionLabel.Size = new System.Drawing.Size(160, 20);
            this.materialDescriptionLabel.TabIndex = 18;
            this.materialDescriptionLabel.Text = "Material Description";
            // 
            // colorCodeLabel
            // 
            this.colorCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorCodeLabel.AutoSize = true;
            this.colorCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.colorCodeLabel.Location = new System.Drawing.Point(23, 428);
            this.colorCodeLabel.Name = "colorCodeLabel";
            this.colorCodeLabel.Size = new System.Drawing.Size(102, 20);
            this.colorCodeLabel.TabIndex = 20;
            this.colorCodeLabel.Text = "Colour Code";
            // 
            // colorDescriptionLabel
            // 
            this.colorDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorDescriptionLabel.AutoSize = true;
            this.colorDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(162)))), ((int)(((byte)(56)))));
            this.colorDescriptionLabel.Location = new System.Drawing.Point(23, 454);
            this.colorDescriptionLabel.Name = "colorDescriptionLabel";
            this.colorDescriptionLabel.Size = new System.Drawing.Size(149, 20);
            this.colorDescriptionLabel.TabIndex = 22;
            this.colorDescriptionLabel.Text = "Colour Description";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.progressBar.Location = new System.Drawing.Point(188, 531);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 24;
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(374, 621);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 27;
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
            this.activeListButton.Location = new System.Drawing.Point(188, 621);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 26;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeListButton_Click);
            // 
            // activateSKUButton
            // 
            this.activateSKUButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activateSKUButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.activateSKUButton.Enabled = false;
            this.activateSKUButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateSKUButton.ForeColor = System.Drawing.Color.Black;
            this.activateSKUButton.Location = new System.Drawing.Point(188, 539);
            this.activateSKUButton.Name = "activateSKUButton";
            this.activateSKUButton.Size = new System.Drawing.Size(370, 76);
            this.activateSKUButton.TabIndex = 25;
            this.activateSKUButton.Text = "Activate SKU";
            this.activateSKUButton.UseVisualStyleBackColor = false;
            this.activateSKUButton.Click += new System.EventHandler(this.activateSKUButton_Click);
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
            // ActivateSKU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 751);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.activateSKUButton);
            this.Controls.Add(this.colorDescriptionLabel);
            this.Controls.Add(this.colorCodeLabel);
            this.Controls.Add(this.materialDescriptionLabel);
            this.Controls.Add(this.materialCodeLabel);
            this.Controls.Add(this.colorDescriptionTextbox);
            this.Controls.Add(this.colorCodeTextbox);
            this.Controls.Add(this.materialDescriptionTextbox);
            this.Controls.Add(this.materialCodeTextbox);
            this.Controls.Add(this.designCodeTextbox);
            this.Controls.Add(this.designDescriptionLabel);
            this.Controls.Add(this.internalNameLabel);
            this.Controls.Add(this.designServiceFlagLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.productFamilyLabel);
            this.Controls.Add(this.designDescriptionTextbox);
            this.Controls.Add(this.internalNameTextbox);
            this.Controls.Add(this.designServiceFlagTextbox);
            this.Controls.Add(this.brandTextbox);
            this.Controls.Add(this.productFamilyTextbox);
            this.Controls.Add(this.designCodeLabel);
            this.Controls.Add(this.skuCombobox);
            this.Controls.Add(this.skuLable);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ActivateSKU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activate SKU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox skuCombobox;
        private System.Windows.Forms.Label skuLable;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label designCodeLabel;
        private System.Windows.Forms.Label designDescriptionLabel;
        private System.Windows.Forms.Label internalNameLabel;
        private System.Windows.Forms.Label designServiceFlagLabel;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label productFamilyLabel;
        private System.Windows.Forms.TextBox designDescriptionTextbox;
        private System.Windows.Forms.TextBox internalNameTextbox;
        private System.Windows.Forms.TextBox designServiceFlagTextbox;
        private System.Windows.Forms.TextBox brandTextbox;
        private System.Windows.Forms.TextBox productFamilyTextbox;
        private System.Windows.Forms.TextBox designCodeTextbox;
        private System.Windows.Forms.TextBox materialCodeTextbox;
        private System.Windows.Forms.TextBox materialDescriptionTextbox;
        private System.Windows.Forms.TextBox colorCodeTextbox;
        private System.Windows.Forms.TextBox colorDescriptionTextbox;
        private System.Windows.Forms.Label materialCodeLabel;
        private System.Windows.Forms.Label materialDescriptionLabel;
        private System.Windows.Forms.Label colorCodeLabel;
        private System.Windows.Forms.Label colorDescriptionLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button activateSKUButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActivate;
    }
}