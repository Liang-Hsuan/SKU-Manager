using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active color table
     */
    public class ActiveColorTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveColorTable()
        {
            MainTable = new DataTable();
        }

        /* method that get the table */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // connect to database and grab the all the active colors' data and put them into the table
            using (Connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM active_colour_list_new", Connection);
                Connection.Open();
                adapter.Fill(MainTable);
            }

            return MainTable;
        }

        /* not implement get sku method */
        protected override string[] GetSku()
        {
            throw new NotImplementedException();
        }
    }
}
