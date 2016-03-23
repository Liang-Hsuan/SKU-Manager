using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.AmazonTables
{
    /*
     * An abstract class that inherient ExportTable class and override getSKU for all Amazon subclasses
     */
    public abstract class AmazonExportTable : ExportTable
    {
        // field for getting product's quantity
        protected DataTable minorTable = Properties.Settings.Default.StockQuantityTable;

        /* method that get the data from given sku */
        protected ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            SqlCommand command = new SqlCommand("SELECT Short_Description, Extended_Description, Height_cm, Depth_cm, Width_cm, Weight_grams, Shippable_Weight_grams, Option_1, Option_2, Option_3, Option_4, Option_5, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Weight_grams, Design_Service_Fashion_Name_AMAZON_CA, " +
                                                "KeyWords_Amazon_1, KeyWords_Amazon_2, KeyWords_Amazon_3, KeyWords_Amazon_4, KeyWords_Amazon_5, Amazon_Browse_Nodes_1_CDA, Amazon_Browse_Nodes_2_CDA, " +
                                                "UPC_CODE_10, Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, " +
                                                "Colour_Description_Extended " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_family_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 35; i++)
                list.Add(reader.GetValue(i));
            connection.Close();

            return list;
        }

        /* a method that return the multiplier */
        protected double getMultiplier()
        {
            double multiplier;

            using (SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                multiplier = reader.GetDouble(0);
                connection.Close();
            }

            return multiplier;
        }

        /* method that add swatch image url */
        protected string getSwatch(string sku)
        {
            // get material + color code
            string node = sku.Substring(sku.IndexOf('-'));

            return "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/1_WEB_SWATCHES/" + node + ".jpg";
        }
    }
}
