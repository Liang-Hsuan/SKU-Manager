using System;
using System.Windows.Forms;

namespace SKU_Manager.SKUExportModules.eCommerceExports.BrightpearlViews
{
    public partial class SelectionViewTable : Form
    {
        // field for the root form
        private IWin32Window parent;

        /* constructor that initialize graphic components */
        public SelectionViewTable(IWin32Window parent)
        {
            InitializeComponent();

            // set the root form 
            this.parent = parent;
        }

        /* the event for inventory button click */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                BPinventoryView bpInventoryView = new BPinventoryView();
                bpInventoryView.ShowDialog(parent);
            }
            else
            {
                MessageBox.Show("For performance purpose, please go to \n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
            }
        }
    }
}
