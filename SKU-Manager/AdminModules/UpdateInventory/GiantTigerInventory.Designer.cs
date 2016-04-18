namespace SKU_Manager.AdminModules.UpdateInventory
{
    partial class GiantTigerInventory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiantTigerInventory));
            this.updateButton = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerTable = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.updateButton.BackColor = System.Drawing.Color.Purple;
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.updateButton.Location = new System.Drawing.Point(570, 652);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(184, 80);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update Inventory";
            this.updateButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.Purple;
            this.progressLabel.Location = new System.Drawing.Point(601, 402);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(100, 23);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.Color.Purple;
            this.loadingLabel.Location = new System.Drawing.Point(514, 310);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "Please Wait";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.Purple;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1330, 622);
            this.dataGridView.TabIndex = 0;
            // 
            // backgroundWorkerTable
            // 
            this.backgroundWorkerTable.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTable_DoWork);
            this.backgroundWorkerTable.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTable_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 600;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // GiantTigerInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 751);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GiantTigerInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giant Tiger Inventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable;
        private System.Windows.Forms.Timer timer;
    }
}