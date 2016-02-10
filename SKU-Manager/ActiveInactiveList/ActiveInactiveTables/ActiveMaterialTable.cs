using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active material table
     */
    class ActiveMaterialTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveMaterialTable()
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Code, Material_Description_Short, Material_Description_Short_FR, Material_Description_Extended, Material_Description_Extended_FR, Active FROM ref_Materials WHERE Active = 'True' ORDER BY Material_Code;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
