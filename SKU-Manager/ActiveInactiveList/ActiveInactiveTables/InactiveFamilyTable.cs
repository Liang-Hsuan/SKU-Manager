using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive family table
     */
    class InactiveFamilyTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveFamilyTable()
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Family_Code, Design_Service_Family_Description, Design_Service_Family_Description_FR, Design_Service_Family_Keywords_General, KeyWords_Amazon_1, KeyWords_Amazon_2, KeyWords_Amazon_3, KeyWords_Amazon_4, KeyWords_Amazon_5, Amazon_Browse_Nodes_1_CDA, Amazon_Browse_Nodes_2_CDA, Amazon_Browse_Nodes_1_USA, Amazon_Browse_Nodes_2_USA, Active, Design_Service_Family_Category_Sage, Design_Service_Family_Themes_Sage, Design_Service_Family_Category_ESP, Design_Service_Family_Category_PromoMarketing, Design_Service_Family_Category_UDUCAT, Design_Service_Family_Category_DistributorCentral FROM ref_Families ORDER BY Design_Service_Family_Code;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
