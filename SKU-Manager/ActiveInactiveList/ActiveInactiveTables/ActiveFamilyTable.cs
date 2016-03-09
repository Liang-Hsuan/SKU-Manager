using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active family table
     */
    class ActiveFamilyTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveFamilyTable()
        {
            mainTable = new DataTable();
        }

        /* method that get the table */
        protected override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // connect to database and grab the all the active colors' data and put them into the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM active_family_list_new;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
