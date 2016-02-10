namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    partial class ShopCaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopCaView));
            this.progressLabel1 = new System.Windows.Forms.Label();
            this.loadingLabel1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerTable1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.shopButton = new System.Windows.Forms.Button();
            this.baseButton = new System.Windows.Forms.Button();
            this.priceButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.backgroundWorkerTable2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTable3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTable4 = new System.ComponentModel.BackgroundWorker();
            this.progressLabel2 = new System.Windows.Forms.Label();
            this.loadingLabel2 = new System.Windows.Forms.Label();
            this.progressLabel3 = new System.Windows.Forms.Label();
            this.loadingLabel3 = new System.Windows.Forms.Label();
            this.progressLabel4 = new System.Windows.Forms.Label();
            this.loadingLabel4 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // progressLabel1
            // 
            this.progressLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel1.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel1.Location = new System.Drawing.Point(321, 401);
            this.progressLabel1.Name = "progressLabel1";
            this.progressLabel1.Size = new System.Drawing.Size(100, 23);
            this.progressLabel1.TabIndex = 0;
            this.progressLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadingLabel1
            // 
            this.loadingLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel1.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel1.Location = new System.Drawing.Point(232, 309);
            this.loadingLabel1.Name = "loadingLabel1";
            this.loadingLabel1.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel1.TabIndex = 4;
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
            this.exitButton.Location = new System.Drawing.Point(302, 684);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(142, 76);
            this.exitButton.TabIndex = 10;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(762, 653);
            this.dataGridView1.TabIndex = 8;
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
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.Visible = false;
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
            this.dataGridView3.TabIndex = 10;
            this.dataGridView3.Visible = false;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(762, 653);
            this.dataGridView4.TabIndex = 11;
            this.dataGridView4.Visible = false;
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
            // shopButton
            // 
            this.shopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shopButton.BackColor = System.Drawing.Color.Transparent;
            this.shopButton.Enabled = false;
            this.shopButton.FlatAppearance.BorderSize = 0;
            this.shopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shopButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.shopButton.Location = new System.Drawing.Point(2, 658);
            this.shopButton.Name = "shopButton";
            this.shopButton.Size = new System.Drawing.Size(82, 34);
            this.shopButton.TabIndex = 6;
            this.shopButton.Text = "Bag";
            this.shopButton.UseVisualStyleBackColor = false;
            this.shopButton.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // baseButton
            // 
            this.baseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.baseButton.BackColor = System.Drawing.Color.Transparent;
            this.baseButton.FlatAppearance.BorderSize = 0;
            this.baseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.baseButton.Location = new System.Drawing.Point(90, 659);
            this.baseButton.Name = "baseButton";
            this.baseButton.Size = new System.Drawing.Size(82, 34);
            this.baseButton.TabIndex = 7;
            this.baseButton.Text = "Base Data";
            this.baseButton.UseVisualStyleBackColor = false;
            this.baseButton.Click += new System.EventHandler(this.baseButton_Click);
            // 
            // priceButton
            // 
            this.priceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceButton.BackColor = System.Drawing.Color.Transparent;
            this.priceButton.FlatAppearance.BorderSize = 0;
            this.priceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priceButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.priceButton.Location = new System.Drawing.Point(178, 659);
            this.priceButton.Name = "priceButton";
            this.priceButton.Size = new System.Drawing.Size(82, 34);
            this.priceButton.TabIndex = 8;
            this.priceButton.Text = "Price";
            this.priceButton.UseVisualStyleBackColor = false;
            this.priceButton.Click += new System.EventHandler(this.priceButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inventoryButton.BackColor = System.Drawing.Color.Transparent;
            this.inventoryButton.FlatAppearance.BorderSize = 0;
            this.inventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventoryButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.inventoryButton.Location = new System.Drawing.Point(266, 659);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(82, 34);
            this.inventoryButton.TabIndex = 9;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
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
            // backgroundWorkerTable4
            // 
            this.backgroundWorkerTable4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTable4_DoWork);
            this.backgroundWorkerTable4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTable4_RunWorkerCompleted);
            // 
            // progressLabel2
            // 
            this.progressLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel2.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel2.Location = new System.Drawing.Point(321, 401);
            this.progressLabel2.Name = "progressLabel2";
            this.progressLabel2.Size = new System.Drawing.Size(100, 23);
            this.progressLabel2.TabIndex = 1;
            this.progressLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressLabel2.Visible = false;
            // 
            // loadingLabel2
            // 
            this.loadingLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel2.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel2.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel2.Location = new System.Drawing.Point(232, 309);
            this.loadingLabel2.Name = "loadingLabel2";
            this.loadingLabel2.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel2.TabIndex = 5;
            this.loadingLabel2.Text = "Please Wait";
            this.loadingLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel2.Visible = false;
            // 
            // progressLabel3
            // 
            this.progressLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel3.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel3.Location = new System.Drawing.Point(321, 401);
            this.progressLabel3.Name = "progressLabel3";
            this.progressLabel3.Size = new System.Drawing.Size(100, 23);
            this.progressLabel3.TabIndex = 2;
            this.progressLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressLabel3.Visible = false;
            // 
            // loadingLabel3
            // 
            this.loadingLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel3.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel3.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel3.Location = new System.Drawing.Point(232, 309);
            this.loadingLabel3.Name = "loadingLabel3";
            this.loadingLabel3.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel3.TabIndex = 6;
            this.loadingLabel3.Text = "Please Wait";
            this.loadingLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel3.Visible = false;
            // 
            // progressLabel4
            // 
            this.progressLabel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressLabel4.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressLabel4.Location = new System.Drawing.Point(321, 401);
            this.progressLabel4.Name = "progressLabel4";
            this.progressLabel4.Size = new System.Drawing.Size(100, 23);
            this.progressLabel4.TabIndex = 3;
            this.progressLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressLabel4.Visible = false;
            // 
            // loadingLabel4
            // 
            this.loadingLabel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLabel4.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel4.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loadingLabel4.Location = new System.Drawing.Point(232, 309);
            this.loadingLabel4.Name = "loadingLabel4";
            this.loadingLabel4.Size = new System.Drawing.Size(323, 92);
            this.loadingLabel4.TabIndex = 7;
            this.loadingLabel4.Text = "Please Wait";
            this.loadingLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadingLabel4.Visible = false;
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
            // timer4
            // 
            this.timer4.Interval = 600;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // ShopCaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 790);
            this.Controls.Add(this.progressLabel4);
            this.Controls.Add(this.loadingLabel4);
            this.Controls.Add(this.progressLabel3);
            this.Controls.Add(this.loadingLabel3);
            this.Controls.Add(this.progressLabel2);
            this.Controls.Add(this.loadingLabel2);
            this.Controls.Add(this.priceButton);
            this.Controls.Add(this.baseButton);
            this.Controls.Add(this.shopButton);
            this.Controls.Add(this.progressLabel1);
            this.Controls.Add(this.loadingLabel1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.inventoryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopCaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shop.ca Export Table";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShopCaView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label progressLabel1;
        private System.Windows.Forms.Label loadingLabel1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button shopButton;
        private System.Windows.Forms.Button baseButton;
        private System.Windows.Forms.Button priceButton;
        private System.Windows.Forms.Button inventoryButton;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTable4;
        private System.Windows.Forms.Label progressLabel2;
        private System.Windows.Forms.Label loadingLabel2;
        private System.Windows.Forms.Label progressLabel3;
        private System.Windows.Forms.Label loadingLabel3;
        private System.Windows.Forms.Label progressLabel4;
        private System.Windows.Forms.Label loadingLabel4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
    }
}