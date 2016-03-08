namespace SKU_Manager.SplashModules.Update
{
    partial class UpdateMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMaterial));
            this.inactiveListButton = new System.Windows.Forms.Button();
            this.activeListButton = new System.Windows.Forms.Button();
            this.updateMaterialButton = new System.Windows.Forms.Button();
            this.noteLabel = new System.Windows.Forms.Label();
            this.extendedDescriptionLabel = new System.Windows.Forms.Label();
            this.extendedFrenchDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.extendedEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortFrenchDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortEnglishDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.translateButton = new System.Windows.Forms.Button();
            this.frenchLabel = new System.Windows.Forms.Label();
            this.englishLabel = new System.Windows.Forms.Label();
            this.materialCodeLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.activeLabel = new System.Windows.Forms.Label();
            this.activeCheckbox = new System.Windows.Forms.CheckBox();
            this.materialCodeCombobox = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerCombobox = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTranslate = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inactiveListButton
            // 
            this.inactiveListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveListButton.BackColor = System.Drawing.Color.Silver;
            this.inactiveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveListButton.ForeColor = System.Drawing.Color.Black;
            this.inactiveListButton.Location = new System.Drawing.Point(361, 683);
            this.inactiveListButton.Name = "inactiveListButton";
            this.inactiveListButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveListButton.TabIndex = 21;
            this.inactiveListButton.Text = "Inactive List";
            this.inactiveListButton.UseVisualStyleBackColor = false;
            this.inactiveListButton.Click += new System.EventHandler(this.inactiveMaterialButton_Click);
            // 
            // activeListButton
            // 
            this.activeListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activeListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.activeListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeListButton.ForeColor = System.Drawing.Color.White;
            this.activeListButton.Location = new System.Drawing.Point(178, 683);
            this.activeListButton.Name = "activeListButton";
            this.activeListButton.Size = new System.Drawing.Size(180, 39);
            this.activeListButton.TabIndex = 20;
            this.activeListButton.Text = "Active List";
            this.activeListButton.UseVisualStyleBackColor = false;
            this.activeListButton.Click += new System.EventHandler(this.activeMaterialButton_Click);
            // 
            // updateMaterialButton
            // 
            this.updateMaterialButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.updateMaterialButton.BackColor = System.Drawing.Color.Green;
            this.updateMaterialButton.Enabled = false;
            this.updateMaterialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateMaterialButton.ForeColor = System.Drawing.Color.White;
            this.updateMaterialButton.Location = new System.Drawing.Point(176, 601);
            this.updateMaterialButton.Name = "updateMaterialButton";
            this.updateMaterialButton.Size = new System.Drawing.Size(370, 76);
            this.updateMaterialButton.TabIndex = 19;
            this.updateMaterialButton.Text = "Update Material";
            this.updateMaterialButton.UseVisualStyleBackColor = false;
            this.updateMaterialButton.Click += new System.EventHandler(this.updateMaterialButton_Click);
            // 
            // noteLabel
            // 
            this.noteLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.noteLabel.AutoSize = true;
            this.noteLabel.BackColor = System.Drawing.Color.White;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLabel.ForeColor = System.Drawing.Color.Gray;
            this.noteLabel.Location = new System.Drawing.Point(58, 553);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(612, 13);
            this.noteLabel.TabIndex = 17;
            this.noteLabel.Text = "PLEASE NOTE - DO NOT USE THE FOLLOWING SYMBOLS IN CODES, NAMES AND DESCRIPTIONS: " +
    "%, ?, *, #, $, @, >, <";
            // 
            // extendedDescriptionLabel
            // 
            this.extendedDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedDescriptionLabel.AutoSize = true;
            this.extendedDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedDescriptionLabel.ForeColor = System.Drawing.Color.Green;
            this.extendedDescriptionLabel.Location = new System.Drawing.Point(21, 295);
            this.extendedDescriptionLabel.Name = "extendedDescriptionLabel";
            this.extendedDescriptionLabel.Size = new System.Drawing.Size(169, 20);
            this.extendedDescriptionLabel.TabIndex = 12;
            this.extendedDescriptionLabel.Text = "Extended Description";
            // 
            // extendedFrenchDescriptionTextbox
            // 
            this.extendedFrenchDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedFrenchDescriptionTextbox.Enabled = false;
            this.extendedFrenchDescriptionTextbox.Location = new System.Drawing.Point(469, 297);
            this.extendedFrenchDescriptionTextbox.MaxLength = 250;
            this.extendedFrenchDescriptionTextbox.Multiline = true;
            this.extendedFrenchDescriptionTextbox.Name = "extendedFrenchDescriptionTextbox";
            this.extendedFrenchDescriptionTextbox.Size = new System.Drawing.Size(230, 190);
            this.extendedFrenchDescriptionTextbox.TabIndex = 14;
            // 
            // extendedEnglishDescriptionTextbox
            // 
            this.extendedEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedEnglishDescriptionTextbox.Enabled = false;
            this.extendedEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 297);
            this.extendedEnglishDescriptionTextbox.MaxLength = 250;
            this.extendedEnglishDescriptionTextbox.Multiline = true;
            this.extendedEnglishDescriptionTextbox.Name = "extendedEnglishDescriptionTextbox";
            this.extendedEnglishDescriptionTextbox.Size = new System.Drawing.Size(233, 190);
            this.extendedEnglishDescriptionTextbox.TabIndex = 13;
            // 
            // shortFrenchDescriptionTextbox
            // 
            this.shortFrenchDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortFrenchDescriptionTextbox.Enabled = false;
            this.shortFrenchDescriptionTextbox.Location = new System.Drawing.Point(469, 215);
            this.shortFrenchDescriptionTextbox.MaxLength = 50;
            this.shortFrenchDescriptionTextbox.Multiline = true;
            this.shortFrenchDescriptionTextbox.Name = "shortFrenchDescriptionTextbox";
            this.shortFrenchDescriptionTextbox.Size = new System.Drawing.Size(230, 59);
            this.shortFrenchDescriptionTextbox.TabIndex = 11;
            // 
            // shortEnglishDescriptionTextbox
            // 
            this.shortEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortEnglishDescriptionTextbox.Enabled = false;
            this.shortEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 217);
            this.shortEnglishDescriptionTextbox.MaxLength = 50;
            this.shortEnglishDescriptionTextbox.Multiline = true;
            this.shortEnglishDescriptionTextbox.Name = "shortEnglishDescriptionTextbox";
            this.shortEnglishDescriptionTextbox.Size = new System.Drawing.Size(233, 59);
            this.shortEnglishDescriptionTextbox.TabIndex = 10;
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.Green;
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 215);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 9;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // translateButton
            // 
            this.translateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.translateButton.BackColor = System.Drawing.Color.Black;
            this.translateButton.Enabled = false;
            this.translateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.Location = new System.Drawing.Point(411, 171);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(92, 23);
            this.translateButton.TabIndex = 7;
            this.translateButton.Text = "TRANSLATE";
            this.translateButton.UseVisualStyleBackColor = false;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // frenchLabel
            // 
            this.frenchLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.frenchLabel.AutoSize = true;
            this.frenchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frenchLabel.ForeColor = System.Drawing.Color.Gray;
            this.frenchLabel.Location = new System.Drawing.Point(561, 175);
            this.frenchLabel.Name = "frenchLabel";
            this.frenchLabel.Size = new System.Drawing.Size(57, 15);
            this.frenchLabel.TabIndex = 8;
            this.frenchLabel.Text = "FRENCH";
            // 
            // englishLabel
            // 
            this.englishLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.englishLabel.AutoSize = true;
            this.englishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.englishLabel.ForeColor = System.Drawing.Color.Gray;
            this.englishLabel.Location = new System.Drawing.Point(289, 175);
            this.englishLabel.Name = "englishLabel";
            this.englishLabel.Size = new System.Drawing.Size(60, 15);
            this.englishLabel.TabIndex = 6;
            this.englishLabel.Text = "ENGLISH";
            // 
            // materialCodeLabel
            // 
            this.materialCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialCodeLabel.AutoSize = true;
            this.materialCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCodeLabel.ForeColor = System.Drawing.Color.Green;
            this.materialCodeLabel.Location = new System.Drawing.Point(21, 132);
            this.materialCodeLabel.Name = "materialCodeLabel";
            this.materialCodeLabel.Size = new System.Drawing.Size(113, 20);
            this.materialCodeLabel.TabIndex = 2;
            this.materialCodeLabel.Text = "Material Code";
            // 
            // detailLabel
            // 
            this.detailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLabel.BackColor = System.Drawing.Color.Green;
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.White;
            this.detailLabel.Location = new System.Drawing.Point(-6, 70);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(754, 29);
            this.detailLabel.TabIndex = 1;
            this.detailLabel.Text = "Update Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Green;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(-9, -3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(761, 60);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Update Material";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activeLabel
            // 
            this.activeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activeLabel.AutoSize = true;
            this.activeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeLabel.ForeColor = System.Drawing.Color.Green;
            this.activeLabel.Location = new System.Drawing.Point(21, 509);
            this.activeLabel.Name = "activeLabel";
            this.activeLabel.Size = new System.Drawing.Size(179, 20);
            this.activeLabel.TabIndex = 15;
            this.activeLabel.Text = "Is this Material Active?";
            // 
            // activeCheckbox
            // 
            this.activeCheckbox.AutoSize = true;
            this.activeCheckbox.Enabled = false;
            this.activeCheckbox.Location = new System.Drawing.Point(218, 512);
            this.activeCheckbox.Name = "activeCheckbox";
            this.activeCheckbox.Size = new System.Drawing.Size(15, 14);
            this.activeCheckbox.TabIndex = 16;
            this.activeCheckbox.UseVisualStyleBackColor = true;
            // 
            // materialCodeCombobox
            // 
            this.materialCodeCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.materialCodeCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.materialCodeCombobox.FormattingEnabled = true;
            this.materialCodeCombobox.Location = new System.Drawing.Point(218, 131);
            this.materialCodeCombobox.Name = "materialCodeCombobox";
            this.materialCodeCombobox.Size = new System.Drawing.Size(400, 21);
            this.materialCodeCombobox.TabIndex = 3;
            this.materialCodeCombobox.SelectedValueChanged += new System.EventHandler(this.materialCodeCombobox_SelectedValueChanged);
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
            // backgroundWorkerTranslate
            // 
            this.backgroundWorkerTranslate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTranslate_DoWork);
            this.backgroundWorkerTranslate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTranslate_RunWorkerCompleted);
            // 
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.WorkerReportsProgress = true;
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUpdate_ProgressChanged);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Location = new System.Drawing.Point(176, 595);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 18;
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.Color.Green;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.Location = new System.Drawing.Point(627, 131);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(33, 23);
            this.leftButton.TabIndex = 4;
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.Color.Green;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.Location = new System.Drawing.Point(666, 131);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(33, 23);
            this.rightButton.TabIndex = 5;
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // UpdateMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 751);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.materialCodeCombobox);
            this.Controls.Add(this.activeCheckbox);
            this.Controls.Add(this.activeLabel);
            this.Controls.Add(this.inactiveListButton);
            this.Controls.Add(this.activeListButton);
            this.Controls.Add(this.updateMaterialButton);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.extendedDescriptionLabel);
            this.Controls.Add(this.extendedFrenchDescriptionTextbox);
            this.Controls.Add(this.extendedEnglishDescriptionTextbox);
            this.Controls.Add(this.shortFrenchDescriptionTextbox);
            this.Controls.Add(this.shortEnglishDescriptionTextbox);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.frenchLabel);
            this.Controls.Add(this.englishLabel);
            this.Controls.Add(this.materialCodeLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Material";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inactiveListButton;
        private System.Windows.Forms.Button activeListButton;
        private System.Windows.Forms.Button updateMaterialButton;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label extendedDescriptionLabel;
        private System.Windows.Forms.TextBox extendedFrenchDescriptionTextbox;
        private System.Windows.Forms.TextBox extendedEnglishDescriptionTextbox;
        private System.Windows.Forms.TextBox shortFrenchDescriptionTextbox;
        private System.Windows.Forms.TextBox shortEnglishDescriptionTextbox;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Label frenchLabel;
        private System.Windows.Forms.Label englishLabel;
        private System.Windows.Forms.Label materialCodeLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label activeLabel;
        private System.Windows.Forms.CheckBox activeCheckbox;
        private System.Windows.Forms.ComboBox materialCodeCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCombobox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranslate;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
    }
}