namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    partial class ChannelListingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelListingView));
            this.progressLabel1 = new System.Windows.Forms.Label();
            this.loadingLabel1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerTable1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.noButton = new System.Windows.Forms.Button();
            this.hasButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.backgroundWorkerTable2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTable3 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.progressLabel2 = new System.Windows.Forms.Label();
            this.loadingLabel2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.progressLabel3 = new System.Windows.Forms.Label();
            this.loadingLabel3 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // progressLabel1
            // 
            this.progressLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel1.Location = new System.Drawing.Point(317, 402);
            this.progressLabel1.Name = "progressLabel1";
            this.progressLabel1.Size = new System.Drawing.Size(100, 23);
            this.progressLabel1.TabIndex = 2;
            this.progressLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadingLabel1
            // 
            this.loadingLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel1.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel1.Location = new System.Drawing.Point(230, 310);
            this.loadingLabel1.Name = "loadingLabel1";
            this.loadingLabel1.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel1.TabIndex = 1;
            this.loadingLabel1.Text = "Please Wait";
            this.loadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitButton.Location = new System.Drawing.Point(302, 685);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(142, 76);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit List";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(762, 653);
            this.dataGridView1.TabIndex = 0;
            // 
            // backgroundWorkerTable1
            // 
            this.backgroundWorkerTable1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTable1_DoWork);
            this.backgroundWorkerTable1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTable1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // noButton
            // 
            this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noButton.BackColor = System.Drawing.Color.Transparent;
            this.noButton.FlatAppearance.BorderSize = 0;
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.noButton.Location = new System.Drawing.Point(178, 659);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(82, 34);
            this.noButton.TabIndex = 11;
            this.noButton.Text = "New Listing";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // hasButton
            // 
            this.hasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hasButton.BackColor = System.Drawing.Color.Transparent;
            this.hasButton.FlatAppearance.BorderSize = 0;
            this.hasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hasButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hasButton.Location = new System.Drawing.Point(90, 659);
            this.hasButton.Name = "hasButton";
            this.hasButton.Size = new System.Drawing.Size(82, 34);
            this.hasButton.TabIndex = 10;
            this.hasButton.Text = "Has Listing";
            this.hasButton.UseVisualStyleBackColor = false;
            this.hasButton.Click += new System.EventHandler(this.hasButton_Click);
            // 
            // allButton
            // 
            this.allButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.allButton.BackColor = System.Drawing.Color.Transparent;
            this.allButton.Enabled = false;
            this.allButton.FlatAppearance.BorderSize = 0;
            this.allButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.allButton.Location = new System.Drawing.Point(2, 658);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(82, 34);
            this.allButton.TabIndex = 9;
            this.allButton.Text = "All Listing";
            this.allButton.UseVisualStyleBackColor = false;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // backgroundWorkerTable2
            // 
            this.backgroundWorkerTable2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTable2_DoWork);
            this.backgroundWorkerTable2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTable2_RunWorkerCompleted);
            // 
            // backgroundWorkerTable3
            // 
            this.backgroundWorkerTable3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTable3_DoWork);
            this.backgroundWorkerTable3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTable3_RunWorkerCompleted);
            // 
            // timer2
            // 
            this.timer2.Interval = 600;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 600;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // progressLabel2
            // 
            this.progressLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel2.Location = new System.Drawing.Point(317, 402);
            this.progressLabel2.Name = "progressLabel2";
            this.progressLabel2.Size = new System.Drawing.Size(100, 23);
            this.progressLabel2.TabIndex = 5;
            this.progressLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressLabel2.Visible = false;
            // 
            // loadingLabel2
            // 
            this.loadingLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel2.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel2.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel2.Location = new System.Drawing.Point(230, 310);
            this.loadingLabel2.Name = "loadingLabel2";
            this.loadingLabel2.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel2.TabIndex = 4;
            this.loadingLabel2.Text = "Please Wait";
            this.loadingLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel2.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(762, 653);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.Visible = false;
            // 
            // progressLabel3
            // 
            this.progressLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel3.Location = new System.Drawing.Point(317, 401);
            this.progressLabel3.Name = "progressLabel3";
            this.progressLabel3.Size = new System.Drawing.Size(100, 23);
            this.progressLabel3.TabIndex = 8;
            this.progressLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressLabel3.Visible = false;
            // 
            // loadingLabel3
            // 
            this.loadingLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel3.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel3.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel3.Location = new System.Drawing.Point(230, 310);
            this.loadingLabel3.Name = "loadingLabel3";
            this.loadingLabel3.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel3.TabIndex = 7;
            this.loadingLabel3.Text = "Please Wait";
            this.loadingLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel3.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(762, 653);
            this.dataGridView3.TabIndex = 6;
            this.dataGridView3.Visible = false;
            // 
            // ChannelListingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 786);
            this.Controls.Add(this.progressLabel3);
            this.Controls.Add(this.loadingLabel3);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.progressLabel2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.hasButton);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.progressLabel1);
            this.Controls.Add(this.loadingLabel1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loadingLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelListingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Channels\' Listing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChannelListingView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label progressLabel1;
        private System.Windows.Forms.Label loadingLabel1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button hasButton;
        private System.Windows.Forms.Button allButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label progressLabel2;
        private System.Windows.Forms.Label loadingLabel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label progressLabel3;
        private System.Windows.Forms.Label loadingLabel3;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}