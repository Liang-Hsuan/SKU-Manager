using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables;

namespace SKU_Manager.SKUExportModules.PromotionalAssociationExports
{
    /* 
     * An application module for sku export that view the export sheet for uducat
     */
    public partial class UducatView : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool done;  // default set to false

        // initialize BestbuyExportTable object
        private readonly UducatExportTable uducatTable = new UducatExportTable();

        /* constructor that initialize graphic components */
        public UducatView()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + uducatTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the uducat export table and send it to data grid view */
        private void backgroundWorkerTable_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table = uducatTable.GetTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            done = true;

            // set first column to freeze 
            dataGridView.Columns[0].Frozen = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = uducatTable.Progress + " / " + uducatTable.Total;

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
        private void UducatView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done)
                Properties.Settings.Default.UducatTable = table;
        }
    }
}
