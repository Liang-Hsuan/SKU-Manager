using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update SKU that show the list of all active SKUs
    */
    public partial class ActiveSKUList : Form
    {
        /* constructor that initialize graphic componenets */
        public ActiveSKUList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void ActiveSKUList_Load(object sender, EventArgs e)
        {
            ActiveSkuTable activeSkuTable = new ActiveSkuTable();
            try
            {
                dataGridView.DataSource = activeSkuTable.Table;
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
