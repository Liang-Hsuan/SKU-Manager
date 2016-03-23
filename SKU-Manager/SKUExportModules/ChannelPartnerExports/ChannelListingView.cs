using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables;
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
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool done;  // default set to false

        // initialize BestbuyExportTable object
        private readonly ChannelListingTable listingTable = new ChannelListingTable();

        /* constructor that initialize graphic components */
        public ChannelListingView()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + listingTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the bestbuy export table */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = listingTable.getTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;
            changeColor();

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
            progressLabel.Text = listingTable.progress + " / " + listingTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
                timer.Start();
            }
            else
                loadingLabel.Text += ".";
        }

        /* a mehtod that change coloumn color for data grid view */
        private void changeColor()
        {
            dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[9].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[10].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[13].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[14].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[17].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
            dataGridView.Columns[18].DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 255);
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void ChannelListingView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done)
                Properties.Settings.Default.ChannelListingTable = table;
        }
    }
}
