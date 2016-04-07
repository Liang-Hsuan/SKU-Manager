using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables;

namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    /* 
     * An application module for sku export that view the export sheet for bestbuy
     */
    public partial class BestbuyView : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool done;  // default set to false

        // initialize BestbuyExportTable object
        private readonly BestbuyExportTable bestbuyTable = new BestbuyExportTable();

        /* constructor that initialize graphic components */
        public BestbuyView()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + bestbuyTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the bestbuy export table */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = bestbuyTable.GetTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            done = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = bestbuyTable.Progress + " / " + bestbuyTable.Total;

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

        /* save the data when the form is closing */
        private void BestbuyView1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done)
                Properties.Settings.Default.BestbuyTable1 = table;
        }
    } 
}
