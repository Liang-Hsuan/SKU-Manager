using SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SKU_Manager.SKUExportModules.eCommerceExports.BrightpearlViews
{
    /* 
     * An application module for sku export that view the export sheet for brightpearl inventory price list
     */
    public partial class BPinventoryView : Form
    {
        // field for storing data
        private readonly DataTable[] table = new DataTable[8];

        // field for countdown
        private readonly int[] timeLeft = new int[8];

        // supporting field
        private readonly bool[] done = new bool[8];

        // initialize brightpearl inventory Table objects
        private readonly BPexportTable[] exportTable = new BPexportTable[8];

        /* constructor that initialize graphic components */
        public BPinventoryView()
        {
            InitializeComponent();

            // initialize export tables
            exportTable[0] = new BPcodedBlankExportTable();
            exportTable[1] = new BPcodedImprintExportTable();
            exportTable[2] = new BPrushCodedBlankExportTable();
            exportTable[3] = new BPrushCodedImprintExportTable();
            exportTable[4] = new BPnetBlankExportTable();
            exportTable[5] = new BPnetImprintExportTable();
            exportTable[6] = new BPrushNetBlankExportTable();
            exportTable[7] = new BPrushNetImprintExportTable();

            // set timers
            for (int i = 0; i <= 7; i++)
                timeLeft[i] = 4;
            timer1.Start(); timer2.Start(); timer3.Start(); timer4.Start(); timer5.Start(); timer6.Start(); timer7.Start(); timer8.Start();

            // set progress
            progressLabel1.Text = 0 + " / " + exportTable[0].Total;
            progressLabel2.Text = 0 + " / " + exportTable[1].Total;
            progressLabel3.Text = 0 + " / " + exportTable[2].Total;
            progressLabel4.Text = 0 + " / " + exportTable[3].Total;
            progressLabel5.Text = 0 + " / " + exportTable[4].Total;
            progressLabel6.Text = 0 + " / " + exportTable[5].Total;
            progressLabel7.Text = 0 + " / " + exportTable[6].Total;
            progressLabel8.Text = 0 + " / " + exportTable[7].Total;

            // call background workers adding data on data grid view
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            backgroundWorker4.RunWorkerAsync();
            backgroundWorker5.RunWorkerAsync();
            backgroundWorker6.RunWorkerAsync();
            backgroundWorker7.RunWorkerAsync();
            backgroundWorker8.RunWorkerAsync();

            // set up boolean flag
            for (int i = 0; i <= 7; i++)
                done[i] = false;
        }

        #region Tables Generation
        /* background workers for getting tables */
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[0] = exportTable[0].GetTable();
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[1] = exportTable[1].GetTable();
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[2] = exportTable[2].GetTable();
        }
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[3] = exportTable[3].GetTable();
        }
        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[4] = exportTable[4].GetTable();
        }
        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[5] = exportTable[5].GetTable();
        }
        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[6] = exportTable[6].GetTable();
        }
        private void backgroundWorker8_DoWork(object sender, DoWorkEventArgs e)
        {
            // send table to table field
            table[7] = exportTable[7].GetTable();
        }
        #endregion

        #region Complete Table
        /* put tables to data grid views */
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = table[0];

            // stop the loading promopt
            timer1.Stop();
            loadingLabel1.Visible = false;
            progressLabel1.Visible = false;

            done[0] = true;
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView2.DataSource = table[1];

            // stop the loading promopt
            timer2.Stop();
            loadingLabel2.Visible = false;
            progressLabel2.Visible = false;

            done[1] = true;
        }
        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView3.DataSource = table[2];

            // stop the loading promopt
            timer3.Stop();
            loadingLabel3.Visible = false;
            progressLabel3.Visible = false;

            done[2] = true;
        }
        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView4.DataSource = table[3];

            // stop the loading promopt
            timer4.Stop();
            loadingLabel4.Visible = false;
            progressLabel4.Visible = false;

            done[3] = true;
        }
        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView5.DataSource = table[4];

            // stop the loading promopt
            timer5.Stop();
            loadingLabel5.Visible = false;
            progressLabel5.Visible = false;

            done[4] = true;
        }
        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView6.DataSource = table[5];

            // stop the loading promopt
            timer6.Stop();
            loadingLabel6.Visible = false;
            progressLabel6.Visible = false;

            done[5] = true;
        }
        private void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView7.DataSource = table[6];

            // stop the loading promopt
            timer7.Stop();
            loadingLabel7.Visible = false;
            progressLabel7.Visible = false;

            done[6] = true;

        }
        private void backgroundWorker8_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView8.DataSource = table[7];

            // stop the loading promopt
            timer8.Stop();
            loadingLabel8.Visible = false;
            progressLabel8.Visible = false;

            done[7] = true;
        }
        #endregion

        #region Timers
        /* the event for timers that make the visual of loading promopt */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft[0]--;

            // set progress
            progressLabel1.Text = exportTable[0].Progress + " / " + exportTable[0].Total;

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
            progressLabel2.Text = exportTable[1].Progress + " / " + exportTable[1].Total;

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
            progressLabel3.Text = exportTable[2].Progress + " / " + exportTable[2].Total;

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
            progressLabel4.Text = exportTable[3].Progress + " / " + exportTable[3].Total;

            if (timeLeft[3] <= 0)
            {
                loadingLabel4.Text = "Please Wait";
                timeLeft[3] = 4;
            }
            else
                loadingLabel4.Text += ".";
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            timeLeft[4]--;

            // set progress
            progressLabel5.Text = exportTable[4].Progress + " / " + exportTable[4].Total;

            if (timeLeft[4] <= 0)
            {
                loadingLabel5.Text = "Please Wait";
                timeLeft[4] = 4;
            }
            else
                loadingLabel5.Text += ".";
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            timeLeft[5]--;

            // set progress
            progressLabel6.Text = exportTable[5].Progress + " / " + exportTable[5].Total;

            if (timeLeft[5] <= 0)
            {
                loadingLabel6.Text = "Please Wait";
                timeLeft[5] = 4;
            }
            else
                loadingLabel6.Text += ".";
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            timeLeft[6]--;

            // set progress
            progressLabel7.Text = exportTable[6].Progress + " / " + exportTable[6].Total;

            if (timeLeft[6] <= 0)
            {
                loadingLabel7.Text = "Please Wait";
                timeLeft[6] = 4;
            }
            else
                loadingLabel7.Text += ".";
        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            timeLeft[7]--;

            // set progress
            progressLabel8.Text = exportTable[7].Progress + " / " + exportTable[7].Total;

            if (timeLeft[7] <= 0)
            {
                loadingLabel8.Text = "Please Wait";
                timeLeft[7] = 4;
            }
            else
                loadingLabel8.Text += ".";
        }
        #endregion

        #region Buttons
        /* event for switching buttons click */
        private void codedBlankButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = false;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[0])
            {
                loadingLabel1.Visible = true;
                progressLabel1.Visible = true;
            }
        }
        private void codedImprintButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = false;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[1])
            {
                loadingLabel2.Visible = true;
                progressLabel2.Visible = true;
            }
        }
        private void rushCodedBlankButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = false;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[2])
            {
                loadingLabel3.Visible = true;
                progressLabel3.Visible = true;
            }
        }
        private void rushCodedImprintButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = false;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[3])
            {
                loadingLabel4.Visible = true;
                progressLabel4.Visible = true;
            }
        }
        private void netBlankButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = false;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[4])
            {
                loadingLabel5.Visible = true;
                progressLabel5.Visible = true;
            }
        }
        private void netImprintButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = false;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = true;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel7.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel7.Visible = false;
            progressLabel8.Visible = false;


            if (!done[5])
            {
                loadingLabel6.Visible = true;
                progressLabel6.Visible = true;
            }
        }
        private void rushNetBlankButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = false;
            rushNetImprintButton.Enabled = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = true;
            dataGridView8.Visible = false;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel8.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel8.Visible = false;


            if (!done[6])
            {
                loadingLabel7.Visible = true;
                progressLabel7.Visible = true;
            }
        }
        private void rushNetImprintButton_Click(object sender, EventArgs e)
        {
            codedBlankButton.Enabled = true;
            codedImprintButton.Enabled = true;
            rushCodedBlankButton.Enabled = true;
            rushCodedImprintButton.Enabled = true;
            netBlankButton.Enabled = true;
            netImprintButton.Enabled = true;
            rushNetBlankButton.Enabled = true;
            rushNetImprintButton.Enabled = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = true;
            loadingLabel1.Visible = false;
            loadingLabel2.Visible = false;
            loadingLabel3.Visible = false;
            loadingLabel4.Visible = false;
            loadingLabel5.Visible = false;
            loadingLabel6.Visible = false;
            loadingLabel7.Visible = false;
            progressLabel1.Visible = false;
            progressLabel2.Visible = false;
            progressLabel3.Visible = false;
            progressLabel4.Visible = false;
            progressLabel5.Visible = false;
            progressLabel6.Visible = false;
            progressLabel7.Visible = false;

            if (done[7]) return;

            loadingLabel8.Visible = true;
            progressLabel8.Visible = true;
        }
        #endregion

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* save the data when the form is closing */
        private void BPinventoryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done[0])
                Properties.Settings.Default.BPcodedBlankTable = table[0];
            if (done[1])
                Properties.Settings.Default.BPcodedImprintTable = table[1];
            if (done[2])
                Properties.Settings.Default.BPrushCodedBlankTable = table[2];
            if (done[3])
                Properties.Settings.Default.BPrushCodedImprintTable = table[3];
            if (done[4])
                Properties.Settings.Default.BPnetBlankTable = table[4];
            if (done[5])
                Properties.Settings.Default.BPnetImprintTable = table[5];
            if (done[6])
                Properties.Settings.Default.BPrushNetBlankTable = table[6];
            if (done[7])
                Properties.Settings.Default.BPrushNetImprintTable = table[7];
        }
    }
}
