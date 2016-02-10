using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active design table
     */
    class ActiveDesignTable : ActiveInactiveTable
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

            // connect to database and grab the all the active colors' data and put them into the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Code, Brand, Design_Service_Flag, Design_Service_Family_Code, Design_Service_Fashion_Name_Ashlin, Short_Description, Short_Description_FR, Extended_Description, Extended_Description_FR, Website_Flag, Design_Service_Fashion_Name_TSC_CA,  Design_Service_Fashion_Name_COSTCO_CA, Design_Service_Fashion_Name_BESTBUY_CA, Design_Service_Fashion_Name_SHOP_CA, Design_Service_Fashion_Name_AMAZON_CA, Design_Service_Fashion_Name_AMAZON_COM, Design_Service_Fashion_Name_SEARS_CA, Design_Service_Fashion_Name_STAPLES_CA, Design_Service_Fashion_Name_WALMART, Monogram, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Width_cm, Height_cm, Depth_cm, Weight_grams, Flat_Shippable, Fold_Shippable, Shippable_Width_cm, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Components, Strap, Detachable_Strap, Zippered_Enclosure, Option_1, Option_1_FR, Option_2, Option_2_FR, Option_3, Option_3_FR, Option_4, Option_4_FR, Option_5, Option_5_FR, Active, Design_URL FROM master_Design_Attributes WHERE Active = 'True' ORDER BY Design_Service_Code;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
