using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update sku that show the list of all active SKUs
    */
    public partial class InactiveSKUList : Form
    {
        /* constructor that initialize graphic componenets */
        public InactiveSKUList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void InactiveSKUList_Load(object sender, EventArgs e)
        {
            InactiveSkuTable inactiveSkuTable = new InactiveSkuTable();
            try
            {
                dataGridView.DataSource = inactiveSkuTable.Table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
