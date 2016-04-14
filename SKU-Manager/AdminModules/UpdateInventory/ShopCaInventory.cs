using SKU_Manager.AdminModules.ImportUpdate;
using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.UpdateInventory
{
    /*
     * An application module for admin table that show the inventory table for shop.ca
     */
    public partial class ShopCaInventory : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;

        // initialize SearsInventoryTable object
        private readonly ShopCaInventoryTable shopCaTable = new ShopCaInventoryTable();

        /* constructor that initialize graphic components */
        public ShopCaInventory()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + shopCaTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the shop.ca inventory table */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = shopCaTable.GetTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            // change color for order that are in low quantity
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[2].Value != DBNull.Value && Convert.ToInt32(row.Cells[2].Value) == 0)
                    row.DefaultCellStyle.BackColor = Color.Pink;
                else if (row.Cells[2].Value != DBNull.Value && row.Cells[4].Value != DBNull.Value && Convert.ToInt32(row.Cells[2].Value) < Convert.ToInt32(row.Cells[4].Value))
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = shopCaTable.Current + " / " + shopCaTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += '.';
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            processingLabel.Visible = true;

            #region Processing
            // local fields
            List<ShopCaInventoryValues> list = new List<ShopCaInventoryValues>();
            ShopCa shopCa = new ShopCa();

            foreach (DataRow row in table.Rows)
            {
                // check the discontinue item to udpate database
                bool discontinue = Convert.ToBoolean(row[6]);
                if (discontinue)
                    shopCa.Discontinue(row[0].ToString());

                if (row[1].ToString() == "") continue;
                ShopCaInventoryValues value = new ShopCaInventoryValues(row[0].ToString(), Convert.ToInt32(row[2]), Convert.ToBoolean(row[5]), discontinue,
                                              DateTime.Today.AddDays(Convert.ToInt32(availableDaysUpdown.Value)), Convert.ToInt32(row[3]), row[1].ToString());
                list.Add(value);
            }

            // start updating
            try
            {
                shopCa.Update(list.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs during updating:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            processingLabel.Visible = false;
        }
    }
}
