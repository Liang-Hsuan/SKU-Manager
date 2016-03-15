using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active design table
     */
    public class ActiveDesignTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveDesignTable()
        {
            mainTable = new DataTable();
        }

        /* method that get the table */
        protected override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // initialize connection object
            /* SqlConnection connection = new SqlConnection(connectionString);

            // get the total number of the active design
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM active_design_list", connection);
            connection.Open();
            int total = (int) command.ExecuteScalar();

            for (int finish = 1; finish <= 500; finish += 500)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM active_design_list_new WHERE RowNumber BETWEEN " + finish + " AND " + (finish + 499), connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                mainTable.Merge(table);

                Thread.Sleep(5000);
            }
            connection.Close(); */

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Code, Design_Service_Flag, Design_Service_Family_Code, Short_Description, Extended_Description, Imprintable, Imprint_Height_cm, Imprint_Width_cm, " +
                                                            "Width_cm, Height_cm, Depth_cm, Weight_grams, Strap, Detachable_Strap, Zippered_Enclosure, Monogram FROM active_Design_list_new;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
