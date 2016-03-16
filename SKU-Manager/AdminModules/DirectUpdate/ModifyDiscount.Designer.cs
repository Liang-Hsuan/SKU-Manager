namespace SKU_Manager.AdminModules.DirectUpdate
{
    partial class ModifyDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyDiscount));
            this.modifyButton = new System.Windows.Forms.Button();
            this.backgroundWorkerModify = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // modifyButton
            // 
            this.modifyButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.modifyButton.BackColor = System.Drawing.Color.Purple;
            this.modifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyButton.ForeColor = System.Drawing.Color.White;
            this.modifyButton.Image = ((System.Drawing.Image)(resources.GetObject("modifyButton.Image")));
            this.modifyButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.modifyButton.Location = new System.Drawing.Point(584, 644);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(184, 80);
            this.modifyButton.TabIndex = 1;
            this.modifyButton.Text = "Modify Discount";
            this.modifyButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.modifyButton.UseVisualStyleBackColor = false;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // backgroundWorkerModify
            // 
            this.backgroundWorkerModify.WorkerReportsProgress = true;
            this.backgroundWorkerModify.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModify_DoWork);
            this.backgroundWorkerModify.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerModify_ProgressChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.Thistle;
            this.progressBar.Location = new System.Drawing.Point(-9, 609);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1346, 153);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.Purple;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1337, 611);
            this.dataGridView.TabIndex = 0;
            // 
            // ModifyDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 755);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Discount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ModifyDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button modifyButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModify;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}