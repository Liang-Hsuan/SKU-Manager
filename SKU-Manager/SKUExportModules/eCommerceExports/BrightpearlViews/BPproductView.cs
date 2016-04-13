using SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SKU_Manager.SKUExportModules.eCommerceExports.BrightpearlViews
{
    /* 
     * An application module for sku export that view the export sheet for brightpearl product
     */
    public partial class BPproductView : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool complete;  // default set to false

        // initialize BPproductExportTable object
        private readonly BPproductExportTable bpTable = new BPproductExportTable();

        /* constructor that initialize graphic components */
        public BPproductView()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " +bpTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the brightpearl product export table and send it to data grid view */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = bpTable.GetTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            complete = true;

            // set first column to freeze 
            dataGridView.Columns[0].Frozen = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = bpTable.Progress + " / " + bpTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += '.';
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void BPproductView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (complete)
                Properties.Settings.Default.BPproductTable = table;
        }
    }
}
