using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ChannelListing;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SKU_Manager.SKUExportModules.ChannelPartnerExports
{
    /* 
     * An application module for sku export that view the export sheet for all channels' listing product
     */
    public partial class ChannelListingView : Form
    {
        // field for storing data
        private readonly DataTable[] table = new DataTable[3];

        // field for countdown
        private readonly int[] timeLeft = new int[3];

        // supporting field
        private readonly bool[] done = new bool[3];

        // initialize Channel Listing objects
        private readonly ChannelListingTable allTable = new ChannelListingTable();
        private readonly ChannelHasListingTable hasTable = new ChannelHasListingTable();
        private readonly ChannelNewListingTable newTable = new ChannelNewListingTable();

        /* constructor that initialize graphic components */
        public ChannelListingView()
        {
            InitializeComponent();

            // set up timer
            timeLeft[0] = 4; timeLeft[1] = 4; timeLeft[2] = 4;
            timer1.Start(); timer2.Start(); timer3.Start();

            // set progress
            progressLabel1.Text = 0 + " / " + allTable.Total;
            progressLabel2.Text = 0 + " / " + hasTable.Total;
            progressLabel3.Text = 0 + " / " + newTable.Total;

            // set up boolean flag
            done[0] = false; done[1] = false; done[2] = false;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable1.IsBusy)
                backgroundWorkerTable1.RunWorkerAsync();
            if (!backgroundWorkerTable2.IsBusy)
                backgroundWorkerTable2.RunWorkerAsync();
            if (!backgroundWorkerTable3.IsBusy)
                backgroundWorkerTable3.RunWorkerAsync();
        }

        #region Table Generation
        /* background worker that get the channel listing export tables */
        private void backgroundWorkerTable1_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[0] = allTable.GetTable();
        }
        private void backgroundWorkerTable2_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[1] = hasTable.GetTable();
        }
        private void backgroundWorkerTable3_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[2] = newTable.GetTable();
        }
        #endregion

        #region Complete Table
        /* put tables to data grid views */
        private void backgroundWorkerTable1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = table[0];
            changeColor(0);

            // stop the loading promopt
            timer1.Stop();
            loadingLabel1.Visible = false;
            progressLabel1.Visible = false;

            done[0] = true;

            // set first column to freeze
            dataGridView1.Columns[0].Frozen = true;
        }
        private void backgroundWorkerTable2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView2.DataSource = table[1];
            changeColor(1);

            // stop the loading promopt
            timer2.Stop();
            loadingLabel2.Visible = false;
            progressLabel2.Visible = false;

            done[1] = true;

            // set first column to freeze
            dataGridView2.Columns[0].Frozen = true;
        }
        private void backgroundWorkerTable3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView3.DataSource = table[2];
            changeColor(2);

            // stop the loading promopt
            timer3.Stop();
            loadingLabel3.Visible = false;
            progressLabel3.Visible = false;

            done[2] = true;

            // set first column to freeze
            dataGridView3.Columns[0].Frozen = true;
        }
        #endregion

        #region Timers
        /* the event for timer that make the visual of loading promopt */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft[0]--;

            // set progress
            progressLabel1.Text = allTable.Progress + " / " + allTable.Total;

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
            progressLabel2.Text = hasTable.Progress + " / " + hasTable.Total;

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
            progressLabel3.Text = newTable.Progress + " / " + newTable.Total;

            if (timeLeft[2] <= 0)
            {
                loadingLabel3.Text = "Please Wait";
                timeLeft[2] = 4;
            }
            else
                loadingLabel3.Text += ".";
        }
        #endregion

        #region Switch Buttons
        /* event for switching buttons click */
        private void allButton_Click(object sender, EventArgs e)
        {
            allButton.Enabled = false;
            hasButton.Enabled = true;
            noButton.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;

            if (done[0]) return;
            loadingLabel1.Visible = true;
            progressLabel1.Visible = true;
        }
        private void hasButton_Click(object sender, EventArgs e)
        {
            if (!done[1])
            {
                loadingLabel2.Visible = true;
                progressLabel2.Visible = true;
            }

            allButton.Enabled = true;
            hasButton.Enabled = false;
            noButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel3.Visible = false;
            progressLabel1.Visible = false;
            progressLabel3.Visible = false;
        }
        private void noButton_Click(object sender, EventArgs e)
        {
            allButton.Enabled = true;
            hasButton.Enabled = true;
            noButton.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;

            if (done[2]) return;
            loadingLabel3.Visible = true;
            progressLabel3.Visible = true;
        }
        #endregion

        /* a mehtod that change coloumn color for data grid view */
        private void changeColor(int i)
        {
            // add data grid view to the list
            DataGridView[] viewList = { dataGridView1, dataGridView2, dataGridView3};

            // start changing color
            viewList[i].Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[9].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[10].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[13].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[14].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[17].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            viewList[i].Columns[18].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void ChannelListingView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done[0])
                Properties.Settings.Default.ChannelListingTable = table[0];
            if (done[1])
                Properties.Settings.Default.ChannelHasListingTable = table[1];
            if (done[2])
                Properties.Settings.Default.ChannelNewListingTable = table[2];
        }
    }
}
