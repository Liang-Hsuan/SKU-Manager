namespace SKU_Manager.SplashModules.Add
{
    partial class Online
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Online));
            this.translateButton = new System.Windows.Forms.Button();
            this.frenchLabel = new System.Windows.Forms.Label();
            this.englishLabel = new System.Windows.Forms.Label();
            this.englishTextbox = new System.Windows.Forms.TextBox();
            this.frenchTextbox = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.backgroundWorkerTranslate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // translateButton
            // 
            this.translateButton.BackColor = System.Drawing.Color.Black;
            this.translateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.Location = new System.Drawing.Point(206, 21);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(92, 23);
            this.translateButton.TabIndex = 2;
            this.translateButton.Text = "TRANSLATE";
            this.translateButton.UseVisualStyleBackColor = false;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // frenchLabel
            // 
            this.frenchLabel.AutoSize = true;
            this.frenchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frenchLabel.ForeColor = System.Drawing.Color.Gray;
            this.frenchLabel.Location = new System.Drawing.Point(356, 25);
            this.frenchLabel.Name = "frenchLabel";
            this.frenchLabel.Size = new System.Drawing.Size(57, 15);
            this.frenchLabel.TabIndex = 3;
            this.frenchLabel.Text = "FRENCH";
            // 
            // englishLabel
            // 
            this.englishLabel.AutoSize = true;
            this.englishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.englishLabel.ForeColor = System.Drawing.Color.Gray;
            this.englishLabel.Location = new System.Drawing.Point(84, 25);
            this.englishLabel.Name = "englishLabel";
            this.englishLabel.Size = new System.Drawing.Size(60, 15);
            this.englishLabel.TabIndex = 1;
            this.englishLabel.Text = "ENGLISH";
            // 
            // englishTextbox
            // 
            this.englishTextbox.Location = new System.Drawing.Point(12, 60);
            this.englishTextbox.MaxLength = 255;
            this.englishTextbox.Multiline = true;
            this.englishTextbox.Name = "englishTextbox";
            this.englishTextbox.Size = new System.Drawing.Size(225, 195);
            this.englishTextbox.TabIndex = 4;
            // 
            // frenchTextbox
            // 
            this.frenchTextbox.Location = new System.Drawing.Point(271, 60);
            this.frenchTextbox.MaxLength = 255;
            this.frenchTextbox.Multiline = true;
            this.frenchTextbox.Name = "frenchTextbox";
            this.frenchTextbox.Size = new System.Drawing.Size(225, 195);
            this.frenchTextbox.TabIndex = 5;
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Green;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(206, 265);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(92, 40);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "EDIT";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // backgroundWorkerTranslate
            // 
            this.backgroundWorkerTranslate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTranslate_DoWork);
            this.backgroundWorkerTranslate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTranslate_RunWorkerCompleted);
            // 
            // Online
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(508, 313);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.frenchTextbox);
            this.Controls.Add(this.englishTextbox);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.frenchLabel);
            this.Controls.Add(this.englishLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Online";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Online Description";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Label frenchLabel;
        private System.Windows.Forms.Label englishLabel;
        private System.Windows.Forms.TextBox englishTextbox;
        private System.Windows.Forms.TextBox frenchTextbox;
        private System.Windows.Forms.Button editButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranslate;
    }
}