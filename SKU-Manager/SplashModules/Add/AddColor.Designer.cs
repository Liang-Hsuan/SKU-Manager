namespace SKU_Manager.SplashModules.Add
{
    partial class AddColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddColor));
            this.titleLabel = new System.Windows.Forms.Label();
            this.detailLabel = new System.Windows.Forms.Label();
            this.inactiveColorButton = new System.Windows.Forms.Button();
            this.activeColorButton = new System.Windows.Forms.Button();
            this.addColorButton = new System.Windows.Forms.Button();
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
            this.colorCodeTextbox = new System.Windows.Forms.TextBox();
            this.colorCodeLabel = new System.Windows.Forms.Label();
            this.backgroundWorkerAddColor = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTranslate = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.duplicateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(-9, -3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(761, 60);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Add Color";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detailLabel
            // 
            this.detailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.detailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLabel.ForeColor = System.Drawing.Color.White;
            this.detailLabel.Location = new System.Drawing.Point(-6, 70);
            this.detailLabel.Name = "detailLabel";
            this.detailLabel.Size = new System.Drawing.Size(754, 29);
            this.detailLabel.TabIndex = 2;
            this.detailLabel.Text = "Color Details";
            this.detailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inactiveColorButton
            // 
            this.inactiveColorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inactiveColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inactiveColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveColorButton.ForeColor = System.Drawing.Color.White;
            this.inactiveColorButton.Location = new System.Drawing.Point(362, 627);
            this.inactiveColorButton.Name = "inactiveColorButton";
            this.inactiveColorButton.Size = new System.Drawing.Size(185, 39);
            this.inactiveColorButton.TabIndex = 18;
            this.inactiveColorButton.Text = "Inactive Color";
            this.inactiveColorButton.UseVisualStyleBackColor = false;
            this.inactiveColorButton.Click += new System.EventHandler(this.inactiveColorButton_Click);
            // 
            // activeColorButton
            // 
            this.activeColorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activeColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(67)))));
            this.activeColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeColorButton.ForeColor = System.Drawing.Color.Black;
            this.activeColorButton.Location = new System.Drawing.Point(176, 627);
            this.activeColorButton.Name = "activeColorButton";
            this.activeColorButton.Size = new System.Drawing.Size(180, 39);
            this.activeColorButton.TabIndex = 17;
            this.activeColorButton.Text = "Active Color";
            this.activeColorButton.UseVisualStyleBackColor = false;
            this.activeColorButton.Click += new System.EventHandler(this.activeColorButton_Click);
            // 
            // addColorButton
            // 
            this.addColorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.addColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addColorButton.ForeColor = System.Drawing.Color.White;
            this.addColorButton.Location = new System.Drawing.Point(176, 545);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(370, 76);
            this.addColorButton.TabIndex = 16;
            this.addColorButton.Text = "Add Color";
            this.addColorButton.UseVisualStyleBackColor = false;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // noteLabel
            // 
            this.noteLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.noteLabel.AutoSize = true;
            this.noteLabel.BackColor = System.Drawing.Color.White;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLabel.ForeColor = System.Drawing.Color.Gray;
            this.noteLabel.Location = new System.Drawing.Point(58, 497);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(612, 13);
            this.noteLabel.TabIndex = 14;
            this.noteLabel.Text = "PLEASE NOTE - DO NOT USE THE FOLLOWING SYMBOLS IN CODES, NAMES AND DESCRIPTIONS: " +
    "%, ?, *, #, $, @, >, <";
            // 
            // extendedDescriptionLabel
            // 
            this.extendedDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedDescriptionLabel.AutoSize = true;
            this.extendedDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.extendedDescriptionLabel.Location = new System.Drawing.Point(21, 295);
            this.extendedDescriptionLabel.Name = "extendedDescriptionLabel";
            this.extendedDescriptionLabel.Size = new System.Drawing.Size(169, 20);
            this.extendedDescriptionLabel.TabIndex = 11;
            this.extendedDescriptionLabel.Text = "Extended Description";
            // 
            // extendedFrenchDescriptionTextbox
            // 
            this.extendedFrenchDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedFrenchDescriptionTextbox.Location = new System.Drawing.Point(469, 295);
            this.extendedFrenchDescriptionTextbox.MaxLength = 250;
            this.extendedFrenchDescriptionTextbox.Multiline = true;
            this.extendedFrenchDescriptionTextbox.Name = "extendedFrenchDescriptionTextbox";
            this.extendedFrenchDescriptionTextbox.Size = new System.Drawing.Size(230, 190);
            this.extendedFrenchDescriptionTextbox.TabIndex = 13;
            // 
            // extendedEnglishDescriptionTextbox
            // 
            this.extendedEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.extendedEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 295);
            this.extendedEnglishDescriptionTextbox.MaxLength = 250;
            this.extendedEnglishDescriptionTextbox.Multiline = true;
            this.extendedEnglishDescriptionTextbox.Name = "extendedEnglishDescriptionTextbox";
            this.extendedEnglishDescriptionTextbox.Size = new System.Drawing.Size(233, 190);
            this.extendedEnglishDescriptionTextbox.TabIndex = 12;
            // 
            // shortFrenchDescriptionTextbox
            // 
            this.shortFrenchDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortFrenchDescriptionTextbox.Location = new System.Drawing.Point(469, 215);
            this.shortFrenchDescriptionTextbox.MaxLength = 50;
            this.shortFrenchDescriptionTextbox.Multiline = true;
            this.shortFrenchDescriptionTextbox.Name = "shortFrenchDescriptionTextbox";
            this.shortFrenchDescriptionTextbox.Size = new System.Drawing.Size(230, 59);
            this.shortFrenchDescriptionTextbox.TabIndex = 10;
            // 
            // shortEnglishDescriptionTextbox
            // 
            this.shortEnglishDescriptionTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortEnglishDescriptionTextbox.Location = new System.Drawing.Point(218, 215);
            this.shortEnglishDescriptionTextbox.MaxLength = 50;
            this.shortEnglishDescriptionTextbox.Multiline = true;
            this.shortEnglishDescriptionTextbox.Name = "shortEnglishDescriptionTextbox";
            this.shortEnglishDescriptionTextbox.Size = new System.Drawing.Size(233, 59);
            this.shortEnglishDescriptionTextbox.TabIndex = 9;
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 215);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(140, 20);
            this.shortDescriptionLabel.TabIndex = 8;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // translateButton
            // 
            this.translateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.translateButton.BackColor = System.Drawing.Color.Black;
            this.translateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.Location = new System.Drawing.Point(411, 171);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(92, 23);
            this.translateButton.TabIndex = 6;
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
            this.frenchLabel.TabIndex = 7;
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
            this.englishLabel.TabIndex = 5;
            this.englishLabel.Text = "ENGLISH";
            // 
            // colorCodeTextbox
            // 
            this.colorCodeTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorCodeTextbox.Location = new System.Drawing.Point(218, 132);
            this.colorCodeTextbox.Name = "colorCodeTextbox";
            this.colorCodeTextbox.Size = new System.Drawing.Size(481, 20);
            this.colorCodeTextbox.TabIndex = 4;
            this.colorCodeTextbox.TextChanged += new System.EventHandler(this.colorCodeTextbox_TextChanged);
            // 
            // colorCodeLabel
            // 
            this.colorCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorCodeLabel.AutoSize = true;
            this.colorCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.colorCodeLabel.Location = new System.Drawing.Point(21, 132);
            this.colorCodeLabel.Name = "colorCodeLabel";
            this.colorCodeLabel.Size = new System.Drawing.Size(93, 20);
            this.colorCodeLabel.TabIndex = 3;
            this.colorCodeLabel.Text = "Color Code";
            // 
            // backgroundWorkerAddColor
            // 
            this.backgroundWorkerAddColor.WorkerReportsProgress = true;
            this.backgroundWorkerAddColor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddColor_DoWork);
            this.backgroundWorkerAddColor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAddColor_ProgressChanged);
            // 
            // backgroundWorkerTranslate
            // 
            this.backgroundWorkerTranslate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTranslate_DoWork);
            this.backgroundWorkerTranslate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTranslate_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(95)))), ((int)(((byte)(190)))));
            this.progressBar.Location = new System.Drawing.Point(176, 537);
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(370, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 15;
            // 
            // duplicateLabel
            // 
            this.duplicateLabel.AutoSize = true;
            this.duplicateLabel.ForeColor = System.Drawing.Color.Red;
            this.duplicateLabel.Location = new System.Drawing.Point(545, 116);
            this.duplicateLabel.Name = "duplicateLabel";
            this.duplicateLabel.Size = new System.Drawing.Size(154, 13);
            this.duplicateLabel.TabIndex = 111;
            this.duplicateLabel.Text = "duplicate color code detected !";
            this.duplicateLabel.Visible = false;
            // 
            // AddColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 751);
            this.Controls.Add(this.duplicateLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.inactiveColorButton);
            this.Controls.Add(this.activeColorButton);
            this.Controls.Add(this.addColorButton);
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
            this.Controls.Add(this.colorCodeTextbox);
            this.Controls.Add(this.colorCodeLabel);
            this.Controls.Add(this.detailLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Color";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label detailLabel;
        private System.Windows.Forms.Button inactiveColorButton;
        private System.Windows.Forms.Button activeColorButton;
        private System.Windows.Forms.Button addColorButton;
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
        private System.Windows.Forms.TextBox colorCodeTextbox;
        private System.Windows.Forms.Label colorCodeLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddColor;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranslate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label duplicateLabel;
    }
}