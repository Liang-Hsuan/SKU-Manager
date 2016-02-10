using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;

namespace SKU_Manager.ActiveInactiveList
{
   /*
    * An application module for update design that show the list of all active designs
    */
    public partial class ActiveDesignList : Form
    {
        /* constructor that initialize graphic componenets */
        public ActiveDesignList()
        {
            InitializeComponent();
        }

        /* load the data from database and show them on the grid view */
        private void ActiveDesignList_Load(object sender, EventArgs e)
        {
            ActiveDesignTable activeDesignTable = new ActiveDesignTable();
            dataGridView.DataSource = activeDesignTable.Table;
        }

        /* the event for exit button click */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
