using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.DirectUpdate
{
    /*
     * An application module for admin table that can modify discount matrix table directly 
     */
    public partial class ModifyDiscount : Form
    {
        // fields for database connection
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        // field for storing tables
        private DataSet dataSet;

        /* constructor that initialize graphic componenets */
        public ModifyDiscount()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void ModifyDiscount_Load(object sender, EventArgs e)
        {
            // connect to database and grab discount matrix data and put them into the data grid view
            try
            {
                // initialize data set
                dataSet = new DataSet();

                // connect to database
                connection = new SqlConnection(Credentials.DesignCon);

                // grab data
                adapter = new SqlDataAdapter("SELECT [Pricing_Tier], [RUSH_C_25_wks], [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], " 
                                           + "[RUSH_Net_25_wks], [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], [Wholesale_Net] FROM Discount_Matrix", connection);
                connection.Open();
                adapter.Fill(dataSet, "Discount_Matrix");
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
        /* the event when modify discount button click that update change to database */
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
                adapter.Update(dataSet, "Discount_Matrix");
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
