using SKU_Manager.AdminModules.DirectUpdate.ChannelListing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ChannelListing;

namespace SKU_Manager.AdminModules.DirectUpdate
{
    /*
     * An application module for admin table that show the channels' listing table
     */
    public partial class ModifyChannelListing : Form
    {
        // field for storing data
        private DataTable table;

        // supporting boolean flag
        private bool hasLoaded;
        private bool strangeSort;

        // initialize ChannelListingUpdateTable and ChannelListingTable object
        private readonly ChannelListingUpdateTable channelUpdateTable = new ChannelListingUpdateTable();
        private readonly ChannelListingTable channelTable = new ChannelListingTable();

        /* constructor that initialize graphic components */
        public ModifyChannelListing()
        {
            InitializeComponent();

            // start timer
            timer.Start();

            // set boolean flag
            hasLoaded = Properties.Settings.Default.ChannelListingTable != null;

            // set progress
            if (hasLoaded)
            {
                loadingLabel.Text = "Stage 2";
                progressLabel.Text = 0 + " / " + channelUpdateTable.Total;
            }
            else
            {
                loadingLabel.Text = "Stage 1";
                progressLabel.Text = 0 + " / " + channelTable.Total;
            }


            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        #region Table Get
        /* background worker that get the channel listing update table */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // retrieve table
            if (hasLoaded)
                table = channelUpdateTable.GetTable();
            else
            {
                // if channel listing table has not been loaded yet, do it now
                Properties.Settings.Default.ChannelListingTable = channelTable.GetTable();
                hasLoaded = true;

                table = channelUpdateTable.GetTable();
            }
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;
            changeColor();

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;
            sortButton.Enabled = true;

            // set first column to freeze
            dataGridView.Columns[0].Frozen = true;
        }
        #endregion

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            // set progress
            if (hasLoaded)
                progressLabel.Text = channelUpdateTable.Current + " / " + channelUpdateTable.Total;
            else
                progressLabel.Text = channelTable.Progress + " / " + channelTable.Total;

            loadingLabel.Text = hasLoaded ? "Stage 2" : "Stage 1";
        }

        /* a method that change color for data grid view */
        private void changeColor()
        {
            dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[8].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[9].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[13].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[14].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[15].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[19].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[20].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[21].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[25].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[26].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
            dataGridView.Columns[27].DefaultCellStyle.BackColor = Color.FromArgb(254, 232, 255);
        }

        #region Modify
        /* the event when modify listing button click that update change to database */
        private void modifyButton_Click(object sender, EventArgs e)
        {
            // call background workder to update the change
            if (!backgroundWorkerModify.IsBusy)
                backgroundWorkerModify.RunWorkerAsync();
        }
        private void backgroundWorkerModify_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 50%
            for (int i = 1; i <= 50; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerModify.ReportProgress(i);
            }

            #region Processing
            foreach (DataRow row in table.Rows)
            {
                // field command string
                string command = "UPDATE master_SKU_Attributes SET ";

                // field for determine do we need to update
                int change = 0;

                // bestbuy
                bool listed = Convert.ToBoolean(row[3]);
                if (listed && row[1].ToString() == "")
                {
                    command += "SKU_BESTBUY_CA = 'NEW',";
                    change++;
                }

                // amazon ca
                listed = Convert.ToBoolean(row[6]);
                if (listed && row[4].ToString() == "")
                {
                    command += "SKU_AMAZON_CA = 'NEW',";
                    change++;
                }

                // amazon com
                listed = Convert.ToBoolean(row[9]);
                if (listed && row[7].ToString() == "")
                {
                    command += "SKU_AMAZON_COM = 'NEW',";
                    change++;
                }

                // staples
                listed = Convert.ToBoolean(row[12]);
                if (listed && row[10].ToString() == "")
                {
                    command += "SKU_STAPLES = 'NEW',";
                    change++;
                }

                // walmart 
                listed = Convert.ToBoolean(row[18]);
                if (listed && row[16].ToString() == "")
                {
                    command += "SKU_WALMART_CA = 'NEW',";
                    change++;
                }

                // shop.ca
                listed = Convert.ToBoolean(row[21]);
                if (listed && row[19].ToString() == "")
                {
                    command += "SKU_SHOP_CA = 'NEW',";
                    change++;
                }

                // sears
                listed = Convert.ToBoolean(row[24]);
                if (listed && row[22].ToString() == "")
                {
                    command += "SKU_SEARS_CA = 'NEW',";
                    change++;
                }

                // the case if there is any changes in the row -> update database
                if (change > 0)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs))
                        {
                            SqlCommand updateCommand = new SqlCommand(command.Remove(command.Length - 1) + " WHERE SKU_Ashlin = \'" + row[0] + "\';", connection);
                            connection.Open();
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurs during updating database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            #endregion

            // simulate progress 50% ~ 100%
            for (int i = 50; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerModify.ReportProgress(i);
            }
        }
        private void backgroundWorkerModify_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        /* sort button click that sort the table in different ways */
        private void sortButton_Click(object sender, EventArgs e)
        {
            if (strangeSort)
            {   
                // create dataview
                DataView view = new DataView(table) {Sort = "SKU ASC"};

                // sort by sku
                table = view.ToTable();
                dataGridView.DataSource = table;

                // set boolean flag to false;
                strangeSort = false;
            }
            else
            {
                // get datarow list
                DataTable copy = table.Copy();
                List<DataRow>[] rows = { new List<DataRow>(copy.Select()), new List<DataRow>(), new List<DataRow>() };

                // start sorting
                foreach (DataRow row in rows[0])
                {
                    // the case if the product has at least one listing
                    if (row["Bestbuy"].ToString() != "" || row["Amazon CA"].ToString() != "" || row["Amazon US"].ToString() != "" || row["Staples"].ToString() != ""
                        || row["Walmart"].ToString() != "" || row["Shop.ca"].ToString() != "" || row["Sears"].ToString() != "")
                        rows[1].Add(row);
                    else
                        rows[2].Add(row);
                }

                // add rows to table
                table.Clear();
                foreach (DataRow row in rows[1])
                    table.ImportRow(row);
                foreach (DataRow row in rows[2])
                    table.ImportRow(row);
                dataGridView.DataSource = table;

                // set boolean flag to true;
                strangeSort = true;
            }
        }
    }
}
