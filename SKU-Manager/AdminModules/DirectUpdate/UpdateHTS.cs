using SKU_Manager.SupportingClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.DirectUpdate
{
    /*
     * An application module for admin table that can update hts tables directly 
     */
    public partial class UpdateHts : Form
    {
        // fields for database connection
        private SqlConnection connection;
        private readonly SqlDataAdapter[] adapter = new SqlDataAdapter[3];    // [0] for HTS_CA, [1] for HTS_US, [2] for Currency

        // field for storing tables
        private DataSet dataSet;

        /* constructor that initialize graphic componenets */
        public UpdateHts()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void UpdateHTS_Load(object sender, EventArgs e)
        {
            // connect to database and grab hts data and put them into the data grid view
            try
            {
                // initialize data set
                dataSet = new DataSet();

                // connect to database
                connection = new SqlConnection(Credentials.DesignCon);

                // grab data
                adapter[0] = new SqlDataAdapter("SELECT * FROM HTS_CA", connection);
                connection.Open();
                adapter[0].Fill(dataSet, "HTS_CA");
                adapter[1] = new SqlDataAdapter("SELECT * FROM HTS_US", connection);
                adapter[1].Fill(dataSet, "HTS_US");
                adapter[2] = new SqlDataAdapter("SELECT * FROM CURRENCY", connection);
                adapter[2].Fill(dataSet, "Currency");
                connection.Close();

                // show data
                dataGridViewCA.DataSource = dataSet.Tables[0];
                dataGridViewUS.DataSource = dataSet.Tables[1];
                dataGridViewCurrency.DataSource = dataSet.Tables[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // get the lastest currency dictionary
            Dictionary<string, double> dic = Currency.GetCurrency("CAD");

            // display lastest currency on the list view
            foreach (KeyValuePair<string, double> pair in dic)
            {
                ListViewItem item = new ListViewItem(pair.Key);
                item.SubItems.Add(pair.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                listview.Items.Add(item);
            }
            listview.Visible = true;
        }

        #region Modify
        /* the event when update hts button click that update change to database */
        private void modifyButton_Click(object sender, EventArgs e)
        {
            // call background workder to update the change
            if (!backgroundWorkerUpdate.IsBusy)
                backgroundWorkerUpdate.RunWorkerAsync();
        }
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 20%
            for (int i = 1; i <= 20; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            try
            {
                // udpate HTS CA
                new SqlCommandBuilder(adapter[0]);
                adapter[0].Update(dataSet, "HTS_CA");

                // simulate progress 20% ~ 50%
                for (int i = 20; i <= 50; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }

                // update HTS US
                new SqlCommandBuilder(adapter[1]);
                adapter[1].Update(dataSet, "HTS_US");

                // simulate progress 50% ~ 80%
                for (int i = 50; i <= 80; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }

                // update Currency
                new SqlCommandBuilder(adapter[2]);
                adapter[2].Update(dataSet, "Currency");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // set progress bar to 0
                backgroundWorkerUpdate.ReportProgress(0);

                return;
            }

            // simulate progress 80% ~ 100%
            for (int i = 80; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }
        }
        private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion
    }
}
