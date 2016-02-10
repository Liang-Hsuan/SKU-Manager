namespace SKU_Manager.ExcelExportModules.BrightpearlExports
{
    partial class SelectionViewExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionViewExcel));
            this.amazonLabel = new System.Windows.Forms.Label();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.hintLabel = new System.Windows.Forms.Label();
            this.amazonButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // amazonLabel
            // 
            this.amazonLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amazonLabel.Location = new System.Drawing.Point(270, 207);
            this.amazonLabel.Name = "amazonLabel";
            this.amazonLabel.Size = new System.Drawing.Size(109, 15);
            this.amazonLabel.TabIndex = 4;
            this.amazonLabel.Text = "Amazon Price List";
            this.amazonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryLabel.Location = new System.Drawing.Point(93, 209);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(109, 15);
            this.inventoryLabel.TabIndex = 2;
            this.inventoryLabel.Text = "Inventory Price List";
            this.inventoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.hintLabel.Location = new System.Drawing.Point(42, 39);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(403, 24);
            this.hintLabel.TabIndex = 0;
            this.hintLabel.Text = "Please select the export for Brightpearl";
            // 
            // amazonButton
            // 
            this.amazonButton.BackColor = System.Drawing.Color.Transparent;
            this.amazonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.amazonButton.FlatAppearance.BorderSize = 0;
            this.amazonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.amazonButton.Image = ((System.Drawing.Image)(resources.GetObject("amazonButton.Image")));
            this.amazonButton.Location = new System.Drawing.Point(273, 92);
            this.amazonButton.Name = "amazonButton";
            this.amazonButton.Size = new System.Drawing.Size(106, 106);
            this.amazonButton.TabIndex = 3;
            this.amazonButton.UseVisualStyleBackColor = false;
            this.amazonButton.Click += new System.EventHandler(this.amazonButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.BackColor = System.Drawing.Color.Transparent;
            this.inventoryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inventoryButton.FlatAppearance.BorderSize = 0;
            this.inventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventoryButton.Image = ((System.Drawing.Image)(resources.GetObject("inventoryButton.Image")));
            this.inventoryButton.Location = new System.Drawing.Point(94, 95);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(106, 106);
            this.inventoryButton.TabIndex = 1;
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel File (*.xls)|*.xls";
            // 
            // SelectionViewExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 268);
            this.Controls.Add(this.amazonLabel);
            this.Controls.Add(this.inventoryLabel);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.amazonButton);
            this.Controls.Add(this.inventoryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionViewExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brightpearl Exports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amazonLabel;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.Button amazonButton;
        private System.Windows.Forms.Button inventoryButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}