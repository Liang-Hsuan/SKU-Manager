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
        protected ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // [0] item name, [1] product description, [2] item height, [3] item length, [4] item width, [5] item weight, [6] website shipping weight, [7] ~ [11] bullet points, [12] package height, [13] package length, [14] package width, [15] package weight, [16] outer material type
            //                                                                                                              & package weight                                                                                                                       & material type,leather type
            // [17] ~ [21] keyword amazon, [22] & [23] recommanded browse node, [24] external product id, [25] for field related to price, [26] main image url, [27] ~ [34] other image url, [35] color name 1 & color map, [36] & [37] item name
            SqlCommand command = new SqlCommand("SELECT Design_Online, Extended_Description, Depth_cm, Height_cm, Width_cm, Weight_grams, Shippable_Weight_grams, Option_1, Option_2, Option_3, Option_4, Option_5, Shippable_Depth_cm, Shippable_Height_cm, Shippable_Width_cm, Shippable_Weight_grams, Design_Service_Fashion_Name_AMAZON_CA, " +
                                                "KeyWords_Amazon_1, KeyWords_Amazon_2, KeyWords_Amazon_3, KeyWords_Amazon_4, KeyWords_Amazon_5, Amazon_Browse_Nodes_1_CDA, Amazon_Browse_Nodes_2_CDA, " +
                                                "UPC_CODE_10, Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, " +
                                                "Colour_Description_Extended, Colour_Online, Material_Online " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 37; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the all fields for price calculation */
        protected double[] GetPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship
            double[] list = new double[4];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship FROM Channel_Pricing WHERE Channel_No = 1003";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            connection.Close();

            return list;
        }

        /* method that add swatch image url */
        protected string GetSwatch(string sku)
        {
            // get material + color code
            string node = sku.Substring(sku.IndexOf('-'));

            return "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/1_WEB_SWATCHES/" + node + ".jpg";
        }
    }
}
