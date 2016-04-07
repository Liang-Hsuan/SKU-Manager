using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables;

namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    /* 
     * An application module for sku export that view the export sheet for shop.ca
     */
    public partial class ShopCaView : Form
    {
        // field for storing data
        private readonly DataTable[] table = new DataTable[4];

        // field for countdown
        private readonly int[] timeLeft = new int[4];

        // supporting field
        private readonly bool[] done = new bool[4];

        // initialize ShopCa Table objects
        private readonly ShopCaBagExportTable bagTable = new ShopCaBagExportTable();
        private readonly ShopCaBaseExportTable baseTable = new ShopCaBaseExportTable();
        private readonly ShopCaPriceExportTable priceTable = new ShopCaPriceExportTable();
        private readonly ShopCaInventoryExportTable inventoryTable = new ShopCaInventoryExportTable();

        /* constructor that initialize graphic components */
        public ShopCaView()
        {
            InitializeComponent();

            // set up timer
            timeLeft[0] = 4; timeLeft[1] = 4; timeLeft[2] = 4; timeLeft[3] = 4;
            timer1.Start(); timer2.Start(); timer3.Start(); timer4.Start();

            // set progress
            progressLabel1.Text = 0 + " / " + bagTable.Total;
            progressLabel2.Text = 0 + " / " + baseTable.Total;
            progressLabel3.Text = 0 + " / " + priceTable.Total;
            progressLabel4.Text = 0 + " / " + inventoryTable.Total;

            // set up boolean flag
            done[0] = false; done[1] = false; done[2] = false; done[3] = false;

            // call background workers adding data on data grid view
            if (!backgroundWorkerTable1.IsBusy)
                backgroundWorkerTable1.RunWorkerAsync();
            if (!backgroundWorkerTable2.IsBusy)
                backgroundWorkerTable2.RunWorkerAsync();
            if (!backgroundWorkerTable3.IsBusy)
                backgroundWorkerTable3.RunWorkerAsync();
            if (!backgroundWorkerTable4.IsBusy)
                backgroundWorkerTable4.RunWorkerAsync();
        }

        #region Table Generation
        /* background workers for getting tables */
        private void backgroundWorkerTable1_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[0] = bagTable.GetTable();
        }
        private void backgroundWorkerTable2_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[1] = baseTable.GetTable();
        }
        private void backgroundWorkerTable3_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[2] = priceTable.GetTable();
        }
        private void backgroundWorkerTable4_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[3] = inventoryTable.GetTable();
        }
        #endregion

        #region Complete Table
        /* put tables to data grid views */
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
        private void backgroundWorkerTable3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView3.DataSource = table[2];

            // stop the loading promopt
            timer3.Stop();
            loadingLabel3.Visible = false;
            progressLabel3.Visible = false;

            done[2] = true;
        }
        private void backgroundWorkerTable4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView4.DataSource = table[3];

            // stop the loading promopt
            timer4.Stop();
            loadingLabel4.Visible = false;
            progressLabel4.Visible = false;

            done[3] = true;
        }
        #endregion

        #region Timers
        /* the event for timers that make the visual of loading promopt */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft[0]--;

            // set progress
            progressLabel1.Text = bagTable.Progress + " / " + bagTable.Total;

            if (timeLeft[0] <= 0)
            {
                loadingLabel1.Text = "Please Wait";
                timeLeft[0] = 4;
            }
            else
                loadingLabel1.Text += ".";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timeLeft[1]--;

            // set progress
            progressLabel2.Text = baseTable.Progress + " / " + baseTable.Total;

            if (timeLeft[1] <= 0)
            {
                loadingLabel2.Text = "Please Wait";
                timeLeft[1] = 4;
            }
            else
                loadingLabel2.Text += ".";
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            timeLeft[2]--;

            // set progress
            progressLabel3.Text = priceTable.Progress + " / " + priceTable.Total;

            if (timeLeft[2] <= 0)
            {
                loadingLabel3.Text = "Please Wait";
                timeLeft[2] = 4;
            }
            else
                loadingLabel3.Text += ".";
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            timeLeft[3]--;

            // set progress
            progressLabel4.Text = inventoryTable.Progress + " / " + inventoryTable.Total;

            if (timeLeft[3] <= 0)
            {
                loadingLabel4.Text = "Please Wait";
                timeLeft[3] = 4;
            }
            else
                loadingLabel4.Text += ".";
        }
        #endregion

        #region Switch Buttons
        /* event for switching buttons click */
        private void shopButton_Click(object sender, EventArgs e)
        {
            shopButton.Enabled = false;
            baseButton.Enabled = true;
            priceButton.Enabled = true;
            inventoryButton.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;

            if (done[0]) return;

            loadingLabel1.Visible = true;
            progressLabel1.Visible = true;
        }
        private void baseButton_Click(object sender, EventArgs e)
        {
            shopButton.Enabled = true;
            baseButton.Enabled = false;
            priceButton.Enabled = true;
            inventoryButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            progressLabel1.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;

            if (done[1]) return;

            loadingLabel2.Visible = true;
            progressLabel2.Visible = true;
        }
        private void priceButton_Click(object sender, EventArgs e)
        {
            shopButton.Enabled = true;
            baseButton.Enabled = true;
            priceButton.Enabled = false;
            inventoryButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel4.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel4.Visible = false;

            if (done[2]) return;

            loadingLabel3.Visible = true;
            progressLabel3.Visible = true;
        }
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            shopButton.Enabled = true;
            baseButton.Enabled = true;
            priceButton.Enabled = true;
            inventoryButton.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;

            if (done[3]) return;

            loadingLabel4.Visible = true;
            progressLabel4.Visible = true;
        }
        #endregion

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void ShopCaView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done[0])
                Properties.Settings.Default.ShopCaBagTable = table[0];
            if (done[1])
                Properties.Settings.Default.ShopCaBaseDataTable = table[1];
            if (done[2])
                Properties.Settings.Default.ShopCaPriceTable = table[2];
            if (done[3])
                Properties.Settings.Default.ShopCaInventoryTable = table[3];
        }
    }
}
