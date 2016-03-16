using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.WalmartTables;

namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    /* 
     * An application module for sku export that view the export sheet for walmart
     */
    public partial class WalmartView : Form
    {
        // field for storing data
        private readonly DataTable[] table = new DataTable[2];

        // field for countdown
        private readonly int[] timeLeft = new int[2];

        // supporting field
        private readonly bool[] done = new bool[2];

        // initialize ShopCa Table objects
        private readonly WalmartItemExportTable itemTable = new WalmartItemExportTable();
        private readonly WalmartPriceExportTable priceTable = new WalmartPriceExportTable();

        /* constructor that initialize graphic components */
        public WalmartView()
        {
            InitializeComponent();

            // set up timer
            timeLeft[0] = 4; timeLeft[1] = 4; 
            timer1.Start(); timer2.Start();

            // set progress
            progressLabel1.Text = 0 + " / " + itemTable.Total;
            progressLabel2.Text = 0 + " / " + priceTable.Total;

            // set up boolean flag
            done[0] = false; done[1] = false; 

            // call background workers adding data on data grid view
            if (!backgroundWorkerTable1.IsBusy)
                backgroundWorkerTable1.RunWorkerAsync();
            if (!backgroundWorkerTable2.IsBusy)
                backgroundWorkerTable2.RunWorkerAsync();
        }

        #region Tables Generation
        /* background workers that get table for the data grid view */
        private void backgroundWorkerTable1_DoWork(object sender, DoWorkEventArgs e)
        {
            // send item table to table field
            table[0] = itemTable.getTable();
        }
        private void backgroundWorkerTable2_DoWork(object sender, DoWorkEventArgs e)
        {
            // send price table to table field
            table[1] = priceTable.getTable();
        }
        #endregion

        #region Complete Table
        /* put data to data grid views */
        private void backgroundWorkerTable1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = table[0];

            // stop the loading promopt
            timer1.Stop();
            loadingLabel1.Visible = false;
            progressLabel1.Visible = false;

            done[0] = true;
        }
        private void backgroundWorkerTable2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView2.DataSource = table[1];

            // stop the loading promopt
            timer2.Stop();
            loadingLabel2.Visible = false;
            progressLabel2.Visible = false;

            done[1] = true;
        }
        #endregion

        #region Timers
        /* the event for timers that make the visual of loading promopt */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft[0]--;

            // set progress
            progressLabel1.Text = itemTable.progress + " / " + itemTable.Total;

            if (timeLeft[0] <= 0)
            {
                loadingLabel1.Text = "Please Wait";
                timeLeft[0] = 4;
                timer1.Start();
            }
            else
                loadingLabel1.Text += ".";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timeLeft[1]--;

            // set progress
            progressLabel2.Text = priceTable.progress + " / " + priceTable.Total;

            if (timeLeft[1] <= 0)
            {
                loadingLabel2.Text = "Please Wait";
                timeLeft[1] = 4;
                timer2.Start();
            }
            else
                loadingLabel2.Text += ".";
        }
        #endregion

        /* the events for button click */
        private void itemButton_Click(object sender, EventArgs e)
        {
            itemButton.Enabled = false;
            priceButton.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            loadingLabel2.Visible = false;
            progressLabel2.Visible = false;

            if (!done[0])
            {
                loadingLabel1.Visible = true;
                progressLabel1.Visible = true;
            }
        }
        private void priceButton_Click(object sender, EventArgs e)
        {

            itemButton.Enabled = true;
            priceButton.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            loadingLabel1.Visible = false;
            progressLabel1.Visible = false;

            if (!done[1])
            {
                loadingLabel2.Visible = true;
                progressLabel2.Visible = true;
            }
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void WalmartView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done[0])
                Properties.Settings.Default.WalmartItemTable = table[0];
            if (done[1])
                Properties.Settings.Default.WalmartPriceTable = table[1];

            Properties.Settings.Default.Save();
        }
    }
}
