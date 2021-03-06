﻿using SKU_Manager.AdminModules.ImportUpdate;
using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.UpdateInventory
{
    /*
     * An application module for admin table that show the inventory table for sears
     */
    public partial class SearsInventory : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;

        // initialize SearsInventoryTable object
        private readonly SearsInventoryTable searsTable = new SearsInventoryTable();

        /* constructor that initialize graphic components */
        public SearsInventory()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + searsTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the sears inventory table */
        private void backgroundWorkerTable_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // send table to table field
            table = searsTable.GetTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            // change color for order that are in low quantity
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[3].Value != DBNull.Value && Convert.ToInt32(row.Cells[3].Value) == 0)
                    row.DefaultCellStyle.BackColor = Color.Pink;
                else if (row.Cells[3].Value != DBNull.Value && row.Cells[5].Value != DBNull.Value && Convert.ToInt32(row.Cells[3].Value) < Convert.ToInt32(row.Cells[5].Value))
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = searsTable.Current + " / " + searsTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += '.';
        }

        /* button event for update that refresh the inventory data in sears */
        private void updateButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            #region Processing
            // local fields
            List<SearsInventoryValues> list = new List<SearsInventoryValues>();
            Sears sears = new Sears();

            foreach (DataRow row in table.Rows)
            {
                // check the discontinue item to udpate database
                bool discontinue = Convert.ToBoolean(row[7]);
                if (discontinue)
                    sears.Discontinue(row[0].ToString());

                if (row[2].ToString() == "") continue;
                SearsInventoryValues value = new SearsInventoryValues(row[0].ToString(), Convert.ToInt32(row[3]), row[1].ToString(), Convert.ToBoolean(row[6]),
                                                                      discontinue, DateTime.Today.AddDays(Convert.ToInt32(availableDaysUpdown.Value)), Convert.ToInt32(row[4]), row[2].ToString());
                list.Add(value);
            }

            // start updating
            try
            {
                sears.Update(list.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs during updating:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            Cursor.Current = Cursors.Default;

            // show complete message
            MessageBox.Show("Inventory update complete to Sears");
        }
    }
}
