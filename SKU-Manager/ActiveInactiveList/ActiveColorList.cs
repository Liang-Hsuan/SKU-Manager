using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update color that show the list of all active colors
    */
    public partial class ActiveColorList : Form
    {
        /* constructor that initialize graphic componenets */
        public ActiveColorList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void ActiveColorList_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = new ActiveColorTable().GetTable();
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
