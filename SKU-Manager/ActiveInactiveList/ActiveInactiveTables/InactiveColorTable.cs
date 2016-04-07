using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive color table
     */
    public class InactiveColorTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveColorTable()
        {
            mainTable = new DataTable();
        }

        /* method that get the table */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // connect to database and grab the all the active colors' data and put them into the table
            using (connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM inactive_colour_list_new;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }

        /* not implement get sku method */
        protected override string[] getSku()
        {
            throw new NotImplementedException();
        }
    }
}
