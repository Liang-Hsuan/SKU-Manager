using SKU_Manager.SupportingClasses;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca base data export table
     */
    public class ShopCaBaseExportTable : ShopCaExportTable
    {
        /* constructor that initialize fields */
        public ShopCaBaseExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "supplier id");                             // 1
            addColumn(mainTable, "store name");                              // 2
            addColumn(mainTable, "sku");                                     // 3
            addColumn(mainTable, "title");                                   // 4
            addColumn(mainTable, "description");                             // 5
            addColumn(mainTable, "shipping weight");                         // 6
            addColumn(mainTable, "shipping weight unit of measure");         // 7
            addColumn(mainTable, "primary product category id");             // 8
            addColumn(mainTable, "product type");                            // 9
            addColumn(mainTable, "main image location");                     // 10
            addColumn(mainTable, "standard product id");                     // 11
            addColumn(mainTable, "standard product id type");                // 12
            addColumn(mainTable, "availability");                            // 13
            addColumn(mainTable, "brand");                                   // 14
            addColumn(mainTable, "launch date");                             // 15
            addColumn(mainTable, "release date");                            // 16
            addColumn(mainTable, "product condition");                       // 17
            addColumn(mainTable, "item package quantity");                   // 18
            addColumn(mainTable, "number of items");                         // 19
            addColumn(mainTable, "designer");                                // 20
            addColumn(mainTable, "package height");                          // 21
            addColumn(mainTable, "package length");                          // 22
            addColumn(mainTable, "package width");                           // 23
            addColumn(mainTable, "package dimension unit of measure");       // 24
            addColumn(mainTable, "max order quantity");                      // 25
            addColumn(mainTable, "legal disclaimer");                        // 26
            addColumn(mainTable, "manufacturer");                            // 27
            addColumn(mainTable, "mfr part number");                         // 28
            addColumn(mainTable, "search terms");                            // 29
            addColumn(mainTable, "parent sku");                              // 30
            addColumn(mainTable, "secondary product category id");           // 31
            addColumn(mainTable, "is new product");                          // 32
            addColumn(mainTable, "alt image location 1");                    // 33
            addColumn(mainTable, "alt image location 2");                    // 34
            addColumn(mainTable, "alt image location 3");                    // 35
            addColumn(mainTable, "alt image location 4");                    // 36
            addColumn(mainTable, "alt image location 5");                    // 37
            addColumn(mainTable, "alt image location 6");                    // 38
            addColumn(mainTable, "alt image location 7");                    // 39
            addColumn(mainTable, "alt image location 8");                    // 40
            addColumn(mainTable, "alt image location 9");                    // 41
            addColumn(mainTable, "video location");                          // 42

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                var row = mainTable.NewRow();

                row[0] = "ashlin_bpg";                       // supplier id
                row[1] = "nishis_boutique";                  // store name
                row[2] = sku;                                // sku
                row[3] = AltText.getAltWithSkuExist(sku);    // title
                row[4] = list[1];                            // description
                row[5] = list[2];                            // shipping weight
                row[6] = "GM";                               // shipping weight unit of measure
                row[7] = 151048;                             // primary product category id
                row[8] = list[6];                            // product type
                row[9] = list[8];                            // main image location
                row[10] = list[20];                          // standard product id
                row[11] = "UPC";                             // standard product id type
                row[12] = true;                              // availability
                row[13] = "Ashlin®";                         // brand
                row[14] = list[9];                           // launch date
                row[15] = list[19];                          // release date
                row[16] = "NEW";                             // product condition
                row[17] = 1;                                 // item package quantity
                row[18] = 1;                                 // number of items
                row[19] = "Ashlin®";                         // designer
                row[20] = list[3];                           // package height
                row[21] = list[4];                           // package length
                row[22] = list[5];                           // package width
                row[23] = "CM";                              // package dimension unit of measure
                row[24] = 100;                               // max order quantity
                row[25] = "";                                // legal disclaimer
                row[26] = "Ashlin BPG Marketing INC";        // manufacturer
                row[27] = sku;                               // mfr part number
                row[28] = list[7];                           // search term
                row[29] = sku.Substring(0, sku.IndexOf('-')); ;       // parent sku
                row[30] = 620977;                            // secondary product category id
                row[31] = true;                              // is new product
                row[32] = list[11];                          // alt iamge location 1
                row[33] = list[12];                          // alt iamge location 2
                row[34] = list[13];                          // alt iamge location 3
                row[35] = list[14];                          // alt iamge location 4
                row[36] = list[15];                          // alt iamge location 5
                row[37] = list[16];                          // alt iamge location 6
                row[38] = list[17];                          // alt iamge location 7
                row[39] = list[18];                          // alt iamge location 8
                row[40] = list[19];                          // alt iamge location 9

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList getData(string sku)
        {
            ArrayList list = new ArrayList();

            // grab data from design
            // [0] title, [1] description, [2] shipping weight, [3] package height, [4] package length, [5] package width
            // [6] product type, [7] search term
            // [8] main image location, [9] launch date, [10] ~ [18] alt image location, [19] release date, [20] standard product id
            SqlCommand command = new SqlCommand("SELECT Short_Description, Extended_Description, Shippable_Weight_grams, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, " +
                                                "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                "Image_1_Path, sku.Date_Added, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, sku.Date_Activated, UPC_Code_9 " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 20; i++)
                list.Add(reader.GetValue(i));
            connection.Close();

            return list;
        }

        #region Deprecated Area
        /* new version of getData that directly return the desired table -> fixing issue right now */
        /* private DataTable getData()
        {
            // local field for storing data
            DataTable table = new DataTable();

            // grab data from database
            // [0] title, [1] description, [2] shipping weight, [3] package height, [4] package length, [5] package width                                                                                                                 
            // [6] product type, [7] search term
            // [8] sku, [9] main image location, [10] launch date, [11] ~ [19] alt image location, [20] release date, [21] standard product id
            // & mfr part number
            // [22] & [23] title
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Shippable_Weight_grams, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, " +
                                                        "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                        "SKU_Ashlin, Image_1_Path, sku.Date_Added, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, sku.Date_Activated, UPC_Code_9, " +
                                                        "Colour_Description_Short, Material_Description_Short " +
                                                        "FROM master_Design_Attributes design " +
                                                        "INNER JOIN master_SKU_Attributes sku ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                        "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                        "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                        "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                        "WHERE SKU_SHOP_CA != \'\' AND sku.Active = \'True\' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();

            return table;
        } */
        #endregion
    }
}
