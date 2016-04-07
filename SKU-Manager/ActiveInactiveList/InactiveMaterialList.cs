using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
    /*
     * An application module for update material that show the list of all inactive materials
     */
    public partial class InactiveMaterialList : Form
    {
        /* constructor that initialize graphic componenets */
        public InactiveMaterialList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void InactiveMaterialList_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = new InactiveMaterialTable().GetTable();
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
