using SKU_Manager.AdminModules.importUpdate;
using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using System;
using System.Collections.Generic;
using System.Data;
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
            table = searsTable.getTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;
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
                timer.Start();
            }
            else
                loadingLabel.Text += ".";
        }

        /* button event for update that refresh the inventory data in sears */
        private void updateButton_Click(object sender, EventArgs e)
        {
            // fields for storing data
            List<SearsInventoryValues> list = new List<SearsInventoryValues>();

            foreach (DataRow row in table.Rows)
            {
                if (row[3].ToString() == "" || row[3].ToString() == "-1") continue;
                SearsInventoryValues value = new SearsInventoryValues(row[0].ToString(), Convert.ToInt32(row[3]), row[1].ToString(), Convert.ToBoolean(row[4]),
                                                                      Convert.ToBoolean(row[5]), DateTime.Today.AddDays(14), 0, DateTime.Today);
                list.Add(value);
            }

            new Sears().update(list.ToArray());
        }
    }
}
