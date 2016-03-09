using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive sku table
     */
    class InactiveSkuTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveSkuTable()
        {
            mainTable = new DataTable();
        }

        /* method that get the table */
        protected override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // connect to database and grab the all the inactive sku' data and put them into the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM inactive_SKU_list", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
