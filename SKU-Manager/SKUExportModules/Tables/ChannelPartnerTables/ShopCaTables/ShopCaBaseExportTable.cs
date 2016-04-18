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
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "supplier id");                             // 1
            AddColumn(mainTable, "store name");                              // 2
            AddColumn(mainTable, "sku");                                     // 3
            AddColumn(mainTable, "title");                                   // 4
            AddColumn(mainTable, "description");                             // 5
            AddColumn(mainTable, "shipping weight");                         // 6
            AddColumn(mainTable, "shipping weight unit of measure");         // 7
            AddColumn(mainTable, "primary product category id");             // 8
            AddColumn(mainTable, "product type");                            // 9
            AddColumn(mainTable, "main image location");                     // 10
            AddColumn(mainTable, "standard product id");                     // 11
            AddColumn(mainTable, "standard product id type");                // 12
            AddColumn(mainTable, "availability");                            // 13
            AddColumn(mainTable, "brand");                                   // 14
            AddColumn(mainTable, "launch date");                             // 15
            AddColumn(mainTable, "release date");                            // 16
            AddColumn(mainTable, "product condition");                       // 17
            AddColumn(mainTable, "item package quantity");                   // 18
            AddColumn(mainTable, "number of items");                         // 19
            AddColumn(mainTable, "designer");                                // 20
            AddColumn(mainTable, "package height");                          // 21
            AddColumn(mainTable, "package length");                          // 22
            AddColumn(mainTable, "package width");                           // 23
            AddColumn(mainTable, "package dimension unit of measure");       // 24
            AddColumn(mainTable, "max order quantity");                      // 25
            AddColumn(mainTable, "legal disclaimer");                        // 26
            AddColumn(mainTable, "manufacturer");                            // 27
            AddColumn(mainTable, "mfr part number");                         // 28
            AddColumn(mainTable, "search terms");                            // 29
            AddColumn(mainTable, "parent sku");                              // 30
            AddColumn(mainTable, "secondary product category id");           // 31
            AddColumn(mainTable, "is new product");                          // 32
            AddColumn(mainTable, "alt image location 1");                    // 33
            AddColumn(mainTable, "alt image location 2");                    // 34
            AddColumn(mainTable, "alt image location 3");                    // 35
            AddColumn(mainTable, "alt image location 4");                    // 36
            AddColumn(mainTable, "alt image location 5");                    // 37
            AddColumn(mainTable, "alt image location 6");                    // 38
            AddColumn(mainTable, "alt image location 7");                    // 39
            AddColumn(mainTable, "alt image location 8");                    // 40
            AddColumn(mainTable, "alt image location 9");                    // 41
            AddColumn(mainTable, "video location");                          // 42

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = "ashlin_bpg";                       // supplier id
                row[1] = "nishis_boutique";                  // store name
                row[2] = sku;                                // sku
                row[3] = AltText.GetAltWithSkuExist(sku);    // title
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
                row[29] = sku.Substring(0, sku.IndexOf('-'));       // parent sku
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
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList GetData(string sku)
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
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 20; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
