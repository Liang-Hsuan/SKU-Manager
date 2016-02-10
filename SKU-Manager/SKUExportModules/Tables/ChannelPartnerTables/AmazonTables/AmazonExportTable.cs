using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.AmazonTables
{
    /*
     * An abstract class that inherient ExportTable class and override getSKU for all Amazon subclasses
     */
    abstract class AmazonExportTable : ExportTable
    {
        /* method that get the data from given sku */
        protected ArrayList getData(string sku)
        {
            // local field for storing data
            // List<string> list = new List<string>(); 
            ArrayList list = new ArrayList();
            DataTable table = new DataTable();

            // get the design and color code from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            // [0] for item name, [1] for product description [2] for item height, [3] for item length, [4] for item width, [5] for item weight, [6] website shipping weight, [7] for finding amaozn keywords, [8] ~ [12] for bullet points, [13] for package height, [14] for package length, [15] for package width, [16] for package weight, [17] for outer material type, 
            //                                                                                                                                                                                                                                                                                                                                       and material type, leather type
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Height_cm, Depth_cm, Width_cm, Weight_grams, Shippable_Weight_grams, Design_Service_Family_Code, Option_1, Option_2, Option_3, Option_4, Option_5, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Weight_grams, Design_Service_Fashion_Name_AMAZON_CA FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            for (int i = 0; i <= 15; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            // [16] ~ [20] for keyword amazon, [21] & [22] for recommended browse nodes
            adapter = new SqlDataAdapter("SELECT KeyWords_Amazon_1, KeyWords_Amazon_2, KeyWords_Amazon_3, KeyWords_Amazon_4, KeyWords_Amazon_5, Amazon_Browse_Nodes_1_CDA, Amazon_Browse_Nodes_2_CDA FROM ref_Families WHERE Design_Service_Family_Code = \'" + table.Rows[0][7] + "\';", connection);
            table.Reset();
            adapter.Fill(table);
            for (int i = 0; i <= 6; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [23] for external product id, [24] for item sku, [25] for standard price, [26] ~ [34] for image stuff
            adapter = new SqlDataAdapter("SELECT UPC_CODE_10, SKU_Ashlin, Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 11; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [35] for color name and color map
            adapter = new SqlDataAdapter("SELECT Colour_Description_Extended FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            connection.Close();

            return list;
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
