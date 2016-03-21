﻿using System;
using System.Windows.Forms;
using SKU_Manager.AdminModules.importUpdate;
using System.Threading;
using SKU_Manager.AdminModules.DirectUpdate;
using SKU_Manager.AdminModules.UpdateInventory;

namespace SKU_Manager.MainForms
{
    /*
     * An subpage that manage discount matrix and hts tables
     */
    public partial class Admin : Form
    {
        // field for getting the root form
        private readonly IWin32Window parent;

        // field for channel new import 
        private Sears sears;

        /* constructor that initialize all graphic components */
        public Admin(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        #region Modify 
        /* the event when modify discount matrix button is clicked */
        private void modifyDiscountButton_Click(object sender, EventArgs e)
        {
            new ModifyDiscount().ShowDialog(this);
        }

        /* the event when modify channel pricing button is clicked */
        private void modifyChannelPricingButton_Click(object sender, EventArgs e)
        {
            new ModifyChannelPricing().ShowDialog(this);
        }

        /* the event when update hts button is clicked */
        private void modifyHtsButton_Click(object sender, EventArgs e)
        {
            new UpdateHTS().ShowDialog(this);
        }
        #endregion

        #region Sears Event
        /* sears button clicks that update the new import of inventory for sears */
        private void searsButton_Click(object sender, EventArgs e)
        {
            excelButton.Visible = false;
            inventoryButton.Visible = false;
            loadingLabel.Visible = false;
        }

        /* sears button hover that show sear's functions */
        private void searsButton_MouseHover(object sender, EventArgs e)
        {
            loadingLabel.Text = "Sears";
            loadingLabel.Visible = true;
            excelButton.Visible = true;
            inventoryButton.Visible = true;
        }
        #endregion

        #region Channel Mangement
        /* the event for excel button clicks that update the merchant sku */
        private void excelButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                sears = new Sears();

                // start updating database
                new Thread(() => sears.update(openFileDialog.FileName)).Start();
                timer.Start();
            }
        }

        /* the event for inventory button clicks that manage the inventory for eCommerce channel */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                SearsInventory bpInventoryView = new SearsInventory();
                bpInventoryView.ShowDialog(this);
            }
            else
                MessageBox.Show("For performance purpose, please go to \n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }
        #endregion

        #region Top Buttons
        /* the event when the top 1 button is clicked (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            Close();

            new Splash(parent).Show(parent);
        }

        /* the event when the top 2 button is clicked (view excel export) */
        private void topButton2_Click(object sender, EventArgs e)
        {   
            Close();

            new ExcelExport(parent).Show(parent);
        }

        /* the event when the top 3 button is clicked (view sku exports) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            Close();

            new SKUExport(parent).Show(parent);
        }
        #endregion

        /* timer event that show the progress of import update */
        private void timer_Tick(object sender, EventArgs e)
        {
            // check if updating is finish -> stop the timer and set text to nothing
            if (sears.Current >= sears.Total)
            {
                timer.Stop();
                loadingLabel.Text = "";
            }
            else
                loadingLabel.Text = sears.Current + " / " + sears.Total;
        }
    }
}
