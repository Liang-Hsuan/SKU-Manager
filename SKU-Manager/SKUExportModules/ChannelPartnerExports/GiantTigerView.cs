using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables;

namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    /* 
     * An application module for sku export that view the export sheet for giant tiger
     */
    public partial class GiantTigerView : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool complete;  // default set to false

        // initialize GiantTigerExportTable object
        private readonly GiantTigerExportTable giantTigerTable = new GiantTigerExportTable();

        /* constructor that initialize graphic components */
        public GiantTigerView()
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

        /* background worker that get the giant tiger export table and send it to data grid view */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = giantTigerTable.getTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            complete = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = giantTigerTable.progress + " / " + giantTigerTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
                timer.Start();
            }
            else
                loadingLabel.Text += ".";
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void GiantTigerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (complete)
                Properties.Settings.Default.GiantTigerTable = table;
        }
    }
}
