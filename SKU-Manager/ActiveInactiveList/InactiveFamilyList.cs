using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update family that show the list of all inactive families
    */
    public partial class InactiveFamilyList : Form
    {
        /* constructor that initialize graphic componenets */
        public InactiveFamilyList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void InactiveFamilyList_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = new InactiveFamilyTable().getTable();
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
