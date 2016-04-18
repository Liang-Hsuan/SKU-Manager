using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.DirectUpdate
{
    /*
     * An application module for admin table that can modify channel pricing table directly 
     */
    public partial class ModifyChannelPricing : Form
    {
        // fields for database connection
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        // field for storing tables
        private DataSet dataSet;

        // database connection string
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic componenets */
        public ModifyChannelPricing()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void ModifyChannelPricing_Load(object sender, EventArgs e)
        {
            // connect to database and grab channel pricing data and put them into the data grid view
            try
            {
                // initialize data set
                dataSet = new DataSet();

                // connect to database
                connection = new SqlConnection(connectionString);

                // grab data
                adapter = new SqlDataAdapter("SELECT Channel_No, Channel_Name, Marketplace, Currency, Msrp_Disc, Ship_Incl_Flag, Base_Ship, " + 
                                             "Gross_Marg, Sell_Net, Sell_Msrp, Sell_Cents, Default_Ship_Price FROM Channel_Pricing", connection);
                connection.Open();
                adapter.Fill(dataSet, "Channel_Pricing");
                connection.Close();

                // show data
                dataGridView.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Modify
        /* the event when modify channel pricing button click that update change to database */
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

            try
            {
                new SqlCommandBuilder(adapter);
                adapter.Update(dataSet, "Channel_Pricing");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // set progress bar to 0
                backgroundWorkerModify.ReportProgress(0);

                return;
            }

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
    }
}
