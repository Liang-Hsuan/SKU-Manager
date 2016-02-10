using System;
using System.Data;
using System.Windows.Forms;

namespace SKU_Manager.ExcelExportModules.BrightpearlExports
{
    public partial class SelectionViewExcel : Form
    {
        // field for the root form
        private IWin32Window parent;

        // field for storing tables
        private DataSet ds = new DataSet();

        /* constructor that initialize graphic components */
        public SelectionViewExcel(IWin32Window parent)
        {
            InitializeComponent();

            // set the root form 
            this.parent = parent;
        }

        /* the event for inventory button click */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.BPcodedBlankTable != null && Properties.Settings.Default.BPcodedImprintTable != null && Properties.Settings.Default.BPrushCodedBlankTable != null && Properties.Settings.Default.BPrushCodedImprintTable != null
             && Properties.Settings.Default.BPnetBlankTable != null && Properties.Settings.Default.BPnetImprintTable != null && Properties.Settings.Default.BPrushCodedBlankTable != null && Properties.Settings.Default.BPrushNetImprintTable != null)   // tables have already been saved
            {
                // local field for excel export
                XlExport export = new XlExport();
                string[] names = new string[8];
                names[0] = "Coded Blank Price List";
                names[1] = "Coded Imprinted Price List";
                names[2] = "Rush Coded Blank Price List";
                names[3] = "Rush Coded Imprinted Price List";
                names[4] = "Net Blank Price List";
                names[5] = "Net Imprinted Price List";
                names[6] = "Rush Net Blank Price List";
                names[7] = "Rush Net Imprinted Price List";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ds.Reset();

                    ds.Tables.Add(Properties.Settings.Default.BPcodedBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPcodedImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushCodedBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushCodedImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPnetBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPnetImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushNetBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushNetImprintTable);

                    // export the excel files               
                    export.nowExport(saveFileDialog.FileName, ds, names);
                }
            }
            else    // prompt user to load stock quantity table first
            {
                MessageBox.Show("For performance purpose, please go to \n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
            }

        }

        /* the event for amazon button clikc */
        private void amazonButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
