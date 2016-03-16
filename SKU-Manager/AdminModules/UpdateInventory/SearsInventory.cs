using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using System.Data;
using System.Windows.Forms;

namespace SKU_Manager.AdminModules.UpdateInventory
{
    /*
     * An application module for admin table that show the inventory table for sears
     */
    public partial class SearsInventory : Form
    {
        // field for storing data
        private DataTable table;

        // supporting fields
        private int timeLeft;
        private bool done;  // default set to false

        // initialize SearsInventoryTable object
        private readonly SearsInventoryTable searsTable = new SearsInventoryTable();

        /* constructor that initialize graphic components */
        public SearsInventory()
        {
            InitializeComponent();

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            progressLabel.Text = 0 + " / " + searsTable.Total;

            // call background worker adding data on data grid view
            if (!backgroundWorkerTable.IsBusy)
                backgroundWorkerTable.RunWorkerAsync();
        }

        /* background worker that get the sears inventory table */
        private void backgroundWorkerTable_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // send table to table field
            table = searsTable.getTable();
        }
        private void backgroundWorkerTable_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = table;

            // stop the loading promopt
            timer.Stop();
            loadingLabel.Visible = false;
            progressLabel.Visible = false;

            done = true;
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, System.EventArgs e)
        {
            timeLeft--;

            // set progress
            progressLabel.Text = searsTable.Current + " / " + searsTable.Total;

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Please Wait";
                timeLeft = 4;
                timer.Start();
            }
            else
                loadingLabel.Text += ".";
        }
    }
}
