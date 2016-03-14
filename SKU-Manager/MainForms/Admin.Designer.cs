namespace SKU_Manager.MainForms
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.applicationTitle = new System.Windows.Forms.Label();
            this.companyTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.modifyDiscountButton = new System.Windows.Forms.Button();
            this.modifyHtsButton = new System.Windows.Forms.Button();
            this.noteLabel = new System.Windows.Forms.Label();
            this.topButton3 = new System.Windows.Forms.Button();
            this.topButton2 = new System.Windows.Forms.Button();
            this.topButton1 = new System.Windows.Forms.Button();
            this.searsButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.loadingLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationTitle
            // 
            this.applicationTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.applicationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationTitle.Location = new System.Drawing.Point(562, 172);
            this.applicationTitle.Name = "applicationTitle";
            this.applicationTitle.Size = new System.Drawing.Size(223, 24);
            this.applicationTitle.TabIndex = 1;
            this.applicationTitle.Text = "ADMIN TABLE";
            this.applicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // companyTitle
            // 
            this.companyTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.companyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyTitle.Location = new System.Drawing.Point(460, 119);
            this.companyTitle.Name = "companyTitle";
            this.companyTitle.Size = new System.Drawing.Size(434, 53);
            this.companyTitle.TabIndex = 0;
            this.companyTitle.Text = "Ashlin BPG Marketing";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1030, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(310, 385);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 385);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-7, 373);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(310, 385);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1030, 375);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(310, 385);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // modifyDiscountButton
            // 
            this.modifyDiscountButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modifyDiscountButton.BackColor = System.Drawing.Color.Purple;
            this.modifyDiscountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyDiscountButton.ForeColor = System.Drawing.Color.White;
            this.modifyDiscountButton.Location = new System.Drawing.Point(420, 384);
            this.modifyDiscountButton.Name = "modifyDiscountButton";
            this.modifyDiscountButton.Size = new System.Drawing.Size(222, 142);
            this.modifyDiscountButton.TabIndex = 5;
            this.modifyDiscountButton.Text = "Modify Discount Matrix";
            this.modifyDiscountButton.UseVisualStyleBackColor = false;
            this.modifyDiscountButton.Click += new System.EventHandler(this.modifyDiscountButton_Click);
            // 
            // modifyHtsButton
            // 
            this.modifyHtsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modifyHtsButton.BackColor = System.Drawing.Color.Purple;
            this.modifyHtsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyHtsButton.ForeColor = System.Drawing.Color.White;
            this.modifyHtsButton.Location = new System.Drawing.Point(713, 384);
            this.modifyHtsButton.Name = "modifyHtsButton";
            this.modifyHtsButton.Size = new System.Drawing.Size(222, 142);
            this.modifyHtsButton.TabIndex = 6;
            this.modifyHtsButton.Text = "Modify HTS Tables";
            this.modifyHtsButton.UseVisualStyleBackColor = false;
            this.modifyHtsButton.Click += new System.EventHandler(this.modifyHtsButton_Click);
            // 
            // noteLabel
            // 
            this.noteLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.noteLabel.AutoSize = true;
            this.noteLabel.BackColor = System.Drawing.Color.White;
            this.noteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLabel.ForeColor = System.Drawing.Color.Gray;
            this.noteLabel.Location = new System.Drawing.Point(463, 689);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(442, 13);
            this.noteLabel.TabIndex = 7;
            this.noteLabel.Text = "PLEASE NOTE - ONLY ADMINISTRATOR LEVEL USER IS ABLE TO ENTER THIS PAGE";
            // 
            // topButton3
            // 
            this.topButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.topButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topButton3.ForeColor = System.Drawing.Color.White;
            this.topButton3.Location = new System.Drawing.Point(907, 251);
            this.topButton3.Name = "topButton3";
            this.topButton3.Size = new System.Drawing.Size(179, 61);
            this.topButton3.TabIndex = 4;
            this.topButton3.Text = "VIEW SKU EXPORT TABLE";
            this.topButton3.UseVisualStyleBackColor = false;
            this.topButton3.Click += new System.EventHandler(this.topButton3_Click);
            // 
            // topButton2
            // 
            this.topButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topButton2.BackColor = System.Drawing.Color.Green;
            this.topButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topButton2.ForeColor = System.Drawing.Color.White;
            this.topButton2.Location = new System.Drawing.Point(589, 251);
            this.topButton2.Name = "topButton2";
            this.topButton2.Size = new System.Drawing.Size(179, 61);
            this.topButton2.TabIndex = 3;
            this.topButton2.Text = "EXPORT SKU TO EXCEL";
            this.topButton2.UseVisualStyleBackColor = false;
            this.topButton2.Click += new System.EventHandler(this.topButton2_Click);
            // 
            // topButton1
            // 
            this.topButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topButton1.BackColor = System.Drawing.Color.Black;
            this.topButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.topButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topButton1.ForeColor = System.Drawing.Color.White;
            this.topButton1.Location = new System.Drawing.Point(273, 251);
            this.topButton1.Name = "topButton1";
            this.topButton1.Size = new System.Drawing.Size(179, 61);
            this.topButton1.TabIndex = 2;
            this.topButton1.Text = "VIEW SKU MANAGEMENT";
            this.topButton1.UseVisualStyleBackColor = false;
            this.topButton1.Click += new System.EventHandler(this.topButton1_Click);
            // 
            // searsButton
            // 
            this.searsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.searsButton.BackColor = System.Drawing.Color.Transparent;
            this.searsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searsButton.FlatAppearance.BorderSize = 0;
            this.searsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searsButton.Image = ((System.Drawing.Image)(resources.GetObject("searsButton.Image")));
            this.searsButton.Location = new System.Drawing.Point(589, 613);
            this.searsButton.Name = "searsButton";
            this.searsButton.Size = new System.Drawing.Size(179, 61);
            this.searsButton.TabIndex = 11;
            this.searsButton.UseVisualStyleBackColor = false;
            this.searsButton.Click += new System.EventHandler(this.searsButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 600;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadingLabel.Location = new System.Drawing.Point(633, 587);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(100, 23);
            this.loadingLabel.TabIndex = 12;
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel File (*.xls)|*.xls";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 751);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.searsButton);
            this.Controls.Add(this.topButton3);
            this.Controls.Add(this.topButton2);
            this.Controls.Add(this.topButton1);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.modifyHtsButton);
            this.Controls.Add(this.modifyDiscountButton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.applicationTitle);
            this.Controls.Add(this.companyTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1346, 789);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label applicationTitle;
        private System.Windows.Forms.Label companyTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button modifyDiscountButton;
        private System.Windows.Forms.Button modifyHtsButton;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button topButton3;
        private System.Windows.Forms.Button topButton2;
        private System.Windows.Forms.Button topButton1;
        private System.Windows.Forms.Button searsButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}