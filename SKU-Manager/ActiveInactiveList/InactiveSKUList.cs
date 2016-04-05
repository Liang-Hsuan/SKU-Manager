using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;
using System.Data;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update sku that show the list of all active SKUs
    */
    public partial class InactiveSKUList : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;

        // initialize InactiveSkuTable object
        private readonly InactiveSkuTable skuTable = new InactiveSkuTable();

        /* constructor that initialize graphic componenets */
        public InactiveSKUList()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + skuTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the inactive sku export table */
        private void backgroundWorkerTable_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // send table to table field
            table = skuTable.getTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            // set first column to freeze
            dataGridView.Columns[0].Frozen = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = skuTable.progress + " / " + skuTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += ".";
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
