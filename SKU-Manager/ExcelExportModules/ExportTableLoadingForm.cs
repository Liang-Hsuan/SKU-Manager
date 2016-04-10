using SKU_Manager.SKUExportModules.Tables;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SKU_Manager.ExcelExportModules
{
    /* 
     * an application module for excel export that show the loading prompt for generating table
     */
    public partial class ExportTableLoadingForm : Form
    {
        // field for storing data
        private readonly DataTable[] dt; // in order to get the table in the same order the export tables came in we need to use datatable array

        // supporting fields
        private int timeLeft;
        private readonly int total;

        // initialize AmazonCATable object
        private readonly ExportTable[] tables;
        
        /* constrcutor that get the ExportTable object */
        public ExportTableLoadingForm(ExportTable[] tables)
        {
            InitializeComponent();
           
            // initializes  tables field;
            this.tables = tables;

            // set up timer
            timeLeft = 4;
            timer.Start();

            // set progress
            int length = tables.Length;
            foreach (ExportTable table in tables)
                total += table.Total;
            total = total / length;
            progressLabel.Text = 0 + " / " + total;

            // initialize datatable field
            dt = new DataTable[length];

            // down to business
            // start the threads
            Thread[] thread = new Thread[length];
            for (int i = 0; i < length; i++)
            {
                int index = i;
                thread[i] = new Thread(() => getTables(tables[index], index));
                thread[i].Start();
            }
        }

        /* return tables to client */
        public DataSet Tables { get; } = new DataSet();

        /* return if the tables are complete */
        public bool Complete { get; private set; }

        /* method that get the tables from ExportTable */
        private void getTables(ExportTable table, int index)
        {
            dt[index] = table.GetTable();
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            // set progress
            int progress = tables.Sum(table => table.Progress);
            progress = progress / tables.Length;
            progressLabel.Text = progress + " / " + total;

            // when the progress is finished
            if (progress >= total)
            {
                try
                {
                    foreach (DataTable table in dt)
                        Tables.Tables.Add(table);
                }
                catch { /* ignore */ }

                Complete = true;
                Close();
            }

            if (timeLeft <= 0)
            {
                loadingLabel.Text = "Generating Table";
                timeLeft = 4;
            }
            else
                loadingLabel.Text += ".";
        }
    }
}
