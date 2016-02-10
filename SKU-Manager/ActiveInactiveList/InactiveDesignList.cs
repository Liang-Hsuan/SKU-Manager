using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update design that show the list of all active designs
    */
    public partial class InactiveDesignList : Form
    {
        /* constructor that initialize graphic componenets */
        public InactiveDesignList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void InactiveDesignList_Load(object sender, EventArgs e)
        {
            InactiveDesignTable inactiveDesignTable = new InactiveDesignTable();
            dataGridView.DataSource = inactiveDesignTable.Table;
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
