using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active color table
     */
    class ActiveSkuTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveSkuTable()
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, Base_Price, Location_WH, Location_Rack, Location_Shelf, Location_ColIndex, Active, Ashlin_URL, SKU_MAGENTO, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_SHOP_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_SEARS_CA, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_WALMART_COM, SKU_DistributorCentral, SKU_PromoMarketing, SKU_WALMART_MANUFACTURER, SKU_WALMART_MERCHANT,  Location_WH, Location_Shelf, Location_ColIndex, Location_Rack, Location_Full, Base_Price, UPC_Code_9, UPC_Code_10, Ashlin_URL, HTS_CDN, HTS_US, Duty_CDN, Duty_US, "
                                                          + "Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path,  Template_URL_1, Template_URL_2, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path "
                                                          + "FROM master_SKU_Attributes WHERE Active = 'True' ORDER BY SKU_Ashlin;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }
    }
}
