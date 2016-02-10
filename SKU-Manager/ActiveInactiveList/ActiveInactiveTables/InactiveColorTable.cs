using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive color table
     */
    class InactiveColorTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveColorTable()
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Code, Colour_Description_Short, Colour_Description_Short_FR, Colour_Description_Extended, Colour_Description_Extended_FR, Active FROM ref_Colours WHERE Active = 'False' ORDER BY Colour_Code;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
