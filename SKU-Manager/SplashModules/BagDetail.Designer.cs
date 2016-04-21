namespace SKU_Manager.SplashModules
{
    partial class BagDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BagDetail));
            this.shoulderDropLengthTextbox = new System.Windows.Forms.TextBox();
            this.shoulderDropLengthLabel = new System.Windows.Forms.Label();
            this.handleStrapDropLengthTextbox = new System.Windows.Forms.TextBox();
            this.handleStrapDropLengthLabel = new System.Windows.Forms.Label();
            this.notableStrapGeneralFeaturesLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.notableStrapGeneralFeaturesCombobox = new System.Windows.Forms.ComboBox();
            this.protectiveFeetCombobox = new System.Windows.Forms.ComboBox();
            this.protectiveFeetLabel = new System.Windows.Forms.Label();
            this.closureCombobox = new System.Windows.Forms.ComboBox();
            this.closureLabel = new System.Windows.Forms.Label();
            this.innerPocketCombobox = new System.Windows.Forms.ComboBox();
            this.outsidePocketCombobox = new System.Windows.Forms.ComboBox();
            this.sizeDifferentiationCombobox = new System.Windows.Forms.ComboBox();
            this.innerPocketLabel = new System.Windows.Forms.Label();
            this.outsidePocketLabel = new System.Windows.Forms.Label();
            this.sizeDifferentiationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shoulderDropLengthTextbox
            // 
            this.shoulderDropLengthTextbox.Location = new System.Drawing.Point(294, 21);
            this.shoulderDropLengthTextbox.MaxLength = 10;
            this.shoulderDropLengthTextbox.Name = "shoulderDropLengthTextbox";
            this.shoulderDropLengthTextbox.Size = new System.Drawing.Size(386, 20);
            this.shoulderDropLengthTextbox.TabIndex = 1;
            this.shoulderDropLengthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shoulderDropLengthTextbox_KeyPress);
            // 
            // shoulderDropLengthLabel
            // 
            this.shoulderDropLengthLabel.AutoSize = true;
            this.shoulderDropLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoulderDropLengthLabel.ForeColor = System.Drawing.Color.Green;
            this.shoulderDropLengthLabel.Location = new System.Drawing.Point(12, 21);
            this.shoulderDropLengthLabel.Name = "shoulderDropLengthLabel";
            this.shoulderDropLengthLabel.Size = new System.Drawing.Size(173, 20);
            this.shoulderDropLengthLabel.TabIndex = 0;
            this.shoulderDropLengthLabel.Text = "Shoulder Drop Length";
            // 
            // handleStrapDropLengthTextbox
            // 
            this.handleStrapDropLengthTextbox.Location = new System.Drawing.Point(294, 47);
            this.handleStrapDropLengthTextbox.MaxLength = 10;
            this.handleStrapDropLengthTextbox.Name = "handleStrapDropLengthTextbox";
            this.handleStrapDropLengthTextbox.Size = new System.Drawing.Size(386, 20);
            this.handleStrapDropLengthTextbox.TabIndex = 3;
            this.handleStrapDropLengthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.handleStrapDropLengthTextbox_KeyPress);
            // 
            // handleStrapDropLengthLabel
            // 
            this.handleStrapDropLengthLabel.AutoSize = true;
            this.handleStrapDropLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handleStrapDropLengthLabel.ForeColor = System.Drawing.Color.Green;
            this.handleStrapDropLengthLabel.Location = new System.Drawing.Point(12, 47);
            this.handleStrapDropLengthLabel.Name = "handleStrapDropLengthLabel";
            this.handleStrapDropLengthLabel.Size = new System.Drawing.Size(205, 20);
            this.handleStrapDropLengthLabel.TabIndex = 2;
            this.handleStrapDropLengthLabel.Text = "Handle/Strap Drop Length";
            // 
            // notableStrapGeneralFeaturesLabel
            // 
            this.notableStrapGeneralFeaturesLabel.AutoSize = true;
            this.notableStrapGeneralFeaturesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notableStrapGeneralFeaturesLabel.ForeColor = System.Drawing.Color.Green;
            this.notableStrapGeneralFeaturesLabel.Location = new System.Drawing.Point(12, 76);
            this.notableStrapGeneralFeaturesLabel.Name = "notableStrapGeneralFeaturesLabel";
            this.notableStrapGeneralFeaturesLabel.Size = new System.Drawing.Size(266, 20);
            this.notableStrapGeneralFeaturesLabel.TabIndex = 4;
            this.notableStrapGeneralFeaturesLabel.Text = "Notable Strap or General Features";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Green;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(294, 259);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 40);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // notableStrapGeneralFeaturesCombobox
            // 
            this.notableStrapGeneralFeaturesCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.notableStrapGeneralFeaturesCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.notableStrapGeneralFeaturesCombobox.FormattingEnabled = true;
            this.notableStrapGeneralFeaturesCombobox.Items.AddRange(new object[] {
            "1 long",
            "2 long",
            "2 short",
            "1 short",
            "top handle strap"});
            this.notableStrapGeneralFeaturesCombobox.Location = new System.Drawing.Point(294, 75);
            this.notableStrapGeneralFeaturesCombobox.Name = "notableStrapGeneralFeaturesCombobox";
            this.notableStrapGeneralFeaturesCombobox.Size = new System.Drawing.Size(386, 21);
            this.notableStrapGeneralFeaturesCombobox.TabIndex = 5;
            this.notableStrapGeneralFeaturesCombobox.Text = "1 long";
            // 
            // protectiveFeetCombobox
            // 
            this.protectiveFeetCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.protectiveFeetCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.protectiveFeetCombobox.FormattingEnabled = true;
            this.protectiveFeetCombobox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.protectiveFeetCombobox.Location = new System.Drawing.Point(294, 102);
            this.protectiveFeetCombobox.Name = "protectiveFeetCombobox";
            this.protectiveFeetCombobox.Size = new System.Drawing.Size(386, 21);
            this.protectiveFeetCombobox.TabIndex = 7;
            this.protectiveFeetCombobox.Text = "False";
            // 
            // protectiveFeetLabel
            // 
            this.protectiveFeetLabel.AutoSize = true;
            this.protectiveFeetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protectiveFeetLabel.ForeColor = System.Drawing.Color.Green;
            this.protectiveFeetLabel.Location = new System.Drawing.Point(12, 103);
            this.protectiveFeetLabel.Name = "protectiveFeetLabel";
            this.protectiveFeetLabel.Size = new System.Drawing.Size(122, 20);
            this.protectiveFeetLabel.TabIndex = 6;
            this.protectiveFeetLabel.Text = "Protective Feet";
            // 
            // closureCombobox
            // 
            this.closureCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.closureCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.closureCombobox.FormattingEnabled = true;
            this.closureCombobox.Items.AddRange(new object[] {
            "Zippered",
            "Flap",
            "Open",
            "Button"});
            this.closureCombobox.Location = new System.Drawing.Point(294, 129);
            this.closureCombobox.Name = "closureCombobox";
            this.closureCombobox.Size = new System.Drawing.Size(386, 21);
            this.closureCombobox.TabIndex = 9;
            this.closureCombobox.Text = "Zippered";
            // 
            // closureLabel
            // 
            this.closureLabel.AutoSize = true;
            this.closureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closureLabel.ForeColor = System.Drawing.Color.Green;
            this.closureLabel.Location = new System.Drawing.Point(12, 130);
            this.closureLabel.Name = "closureLabel";
            this.closureLabel.Size = new System.Drawing.Size(67, 20);
            this.closureLabel.TabIndex = 8;
            this.closureLabel.Text = "Closure";
            // 
            // innerPocketCombobox
            // 
            this.innerPocketCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.innerPocketCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.innerPocketCombobox.FormattingEnabled = true;
            this.innerPocketCombobox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.innerPocketCombobox.Location = new System.Drawing.Point(294, 156);
            this.innerPocketCombobox.Name = "innerPocketCombobox";
            this.innerPocketCombobox.Size = new System.Drawing.Size(386, 21);
            this.innerPocketCombobox.TabIndex = 11;
            this.innerPocketCombobox.Text = "False";
            // 
            // outsidePocketCombobox
            // 
            this.outsidePocketCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.outsidePocketCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.outsidePocketCombobox.FormattingEnabled = true;
            this.outsidePocketCombobox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.outsidePocketCombobox.Location = new System.Drawing.Point(294, 183);
            this.outsidePocketCombobox.Name = "outsidePocketCombobox";
            this.outsidePocketCombobox.Size = new System.Drawing.Size(386, 21);
            this.outsidePocketCombobox.TabIndex = 13;
            this.outsidePocketCombobox.Text = "False";
            // 
            // sizeDifferentiationCombobox
            // 
            this.sizeDifferentiationCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.sizeDifferentiationCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sizeDifferentiationCombobox.FormattingEnabled = true;
            this.sizeDifferentiationCombobox.Items.AddRange(new object[] {
            "Mini",
            "Small",
            "Medium",
            "Large",
            "X-Large",
            "XX-Large"});
            this.sizeDifferentiationCombobox.Location = new System.Drawing.Point(294, 210);
            this.sizeDifferentiationCombobox.Name = "sizeDifferentiationCombobox";
            this.sizeDifferentiationCombobox.Size = new System.Drawing.Size(386, 21);
            this.sizeDifferentiationCombobox.TabIndex = 15;
            this.sizeDifferentiationCombobox.Text = "Medium";
            // 
            // innerPocketLabel
            // 
            this.innerPocketLabel.AutoSize = true;
            this.innerPocketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.innerPocketLabel.ForeColor = System.Drawing.Color.Green;
            this.innerPocketLabel.Location = new System.Drawing.Point(12, 157);
            this.innerPocketLabel.Name = "innerPocketLabel";
            this.innerPocketLabel.Size = new System.Drawing.Size(102, 20);
            this.innerPocketLabel.TabIndex = 10;
            this.innerPocketLabel.Text = "Inner Pocket";
            // 
            // outsidePocketLabel
            // 
            this.outsidePocketLabel.AutoSize = true;
            this.outsidePocketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outsidePocketLabel.ForeColor = System.Drawing.Color.Green;
            this.outsidePocketLabel.Location = new System.Drawing.Point(12, 184);
            this.outsidePocketLabel.Name = "outsidePocketLabel";
            this.outsidePocketLabel.Size = new System.Drawing.Size(123, 20);
            this.outsidePocketLabel.TabIndex = 12;
            this.outsidePocketLabel.Text = "Outside Pocket";
            // 
            // sizeDifferentiationLabel
            // 
            this.sizeDifferentiationLabel.AutoSize = true;
            this.sizeDifferentiationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeDifferentiationLabel.ForeColor = System.Drawing.Color.Green;
            this.sizeDifferentiationLabel.Location = new System.Drawing.Point(12, 211);
            this.sizeDifferentiationLabel.Name = "sizeDifferentiationLabel";
            this.sizeDifferentiationLabel.Size = new System.Drawing.Size(152, 20);
            this.sizeDifferentiationLabel.TabIndex = 14;
            this.sizeDifferentiationLabel.Text = "Size Differentiation";
            // 
            // BagDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 321);
            this.Controls.Add(this.sizeDifferentiationLabel);
            this.Controls.Add(this.outsidePocketLabel);
            this.Controls.Add(this.innerPocketLabel);
            this.Controls.Add(this.sizeDifferentiationCombobox);
            this.Controls.Add(this.outsidePocketCombobox);
            this.Controls.Add(this.innerPocketCombobox);
            this.Controls.Add(this.closureLabel);
            this.Controls.Add(this.closureCombobox);
            this.Controls.Add(this.protectiveFeetLabel);
            this.Controls.Add(this.protectiveFeetCombobox);
            this.Controls.Add(this.notableStrapGeneralFeaturesCombobox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.notableStrapGeneralFeaturesLabel);
            this.Controls.Add(this.handleStrapDropLengthTextbox);
            this.Controls.Add(this.handleStrapDropLengthLabel);
            this.Controls.Add(this.shoulderDropLengthTextbox);
            this.Controls.Add(this.shoulderDropLengthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BagDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bag Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shoulderDropLengthTextbox;
        private System.Windows.Forms.Label shoulderDropLengthLabel;
        private System.Windows.Forms.TextBox handleStrapDropLengthTextbox;
        private System.Windows.Forms.Label handleStrapDropLengthLabel;
        private System.Windows.Forms.Label notableStrapGeneralFeaturesLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox notableStrapGeneralFeaturesCombobox;
        private System.Windows.Forms.ComboBox protectiveFeetCombobox;
        private System.Windows.Forms.Label protectiveFeetLabel;
        private System.Windows.Forms.ComboBox closureCombobox;
        private System.Windows.Forms.Label closureLabel;
        private System.Windows.Forms.ComboBox innerPocketCombobox;
        private System.Windows.Forms.ComboBox outsidePocketCombobox;
        private System.Windows.Forms.ComboBox sizeDifferentiationCombobox;
        private System.Windows.Forms.Label innerPocketLabel;
        private System.Windows.Forms.Label outsidePocketLabel;
        private System.Windows.Forms.Label sizeDifferentiationLabel;
    }
}