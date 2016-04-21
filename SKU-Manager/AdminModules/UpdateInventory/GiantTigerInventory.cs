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
     * An application module for admin table that show the inventory table for giant tiger
     */
    public partial class GiantTigerInventory : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;

        // initialize GiantTigerInventoryTable object
        private readonly GiantTigerInventoryTable giantTigerTable = new GiantTigerInventoryTable();

        /* constructor that initialize graphic components */
        public GiantTigerInventory()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + giantTigerTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the sears inventory table */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = giantTigerTable.GetTable();
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
                if (row.Cells[6].Value != DBNull.Value && Convert.ToInt32(row.Cells[6].Value) == 0)
                    row.DefaultCellStyle.BackColor = Color.Pink;
                else if (row.Cells[6].Value != DBNull.Value && row.Cells[8].Value != DBNull.Value && Convert.ToInt32(row.Cells[6].Value) < Convert.ToInt32(row.Cells[8].Value))
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = giantTigerTable.Current + " / " + giantTigerTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += '.';

        }

        /* button event for update that refresh the inventory data in giant tiger */
        private void updateButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            #region Processing
            // local fields
            List<GiantTigerInventoryValues> list = new List<GiantTigerInventoryValues>();
            GiantTiger giantTiger = new GiantTiger();

            foreach (DataRow row in table.Rows)
            {
                // check the discontinue item to udpate database
                bool discontinue = Convert.ToBoolean(row[10]);
                if (discontinue)
                    giantTiger.Discontinue(row[0].ToString());

                if (row[2].ToString() == "") continue;
                GiantTigerInventoryValues value = new GiantTigerInventoryValues(row[1].ToString(), row[0].ToString(), row[3].ToString(), row[4].ToString(), Convert.ToInt32(row[6]), Convert.ToDouble(row[5]),
                                                                                Convert.ToBoolean(row[9]), discontinue, row[2].ToString(), Convert.ToInt32(row[7]));
                list.Add(value);
            }

            // start updating
            try
            {
                giantTiger.Update(list.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs during updating:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            Cursor.Current = Cursors.Default;

            // show complete message
            MessageBox.Show("Inventory update complete to Giant Tiger");
        }
    }
}
