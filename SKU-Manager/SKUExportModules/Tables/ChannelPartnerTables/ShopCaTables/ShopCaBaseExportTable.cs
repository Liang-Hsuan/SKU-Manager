using System.Collections;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca base data export table
     */
    class ShopCaBaseExportTable : ShopCaExportTable
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

            // local field for inserting data to table
            DataRow row;
            AltText alt = new AltText();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();
          
                row[0] = "ashlin_bpg";                       // supplier id
                row[1] = "nishis_boutique";                  // store name
                row[2] = sku;                                // sku
                row[3] = alt.getAlt(sku);                    // title
                row[4] = list[1];                            // description
                row[5] = list[2];                            // shipping weight
                row[6] = "GM";                               // shipping weight unit of measure
                row[7] = 151048;                             // primary product category id
                row[8] = list[7];                            // product type
                row[9] = list[10];                           // main image location
                row[10] = list[21];                          // standard product id
                row[11] = "UPC";                             // standard product id type
                row[12] = true;                              // availability
                row[13] = "Ashlin®";                         // brand
                row[14] = list[11];                          // launch date
                row[15] = list[20];                          // release date
                row[16] = "NEW";                             // product condition
                row[17] = 1;                                 // item package quantity
                row[18] = 1;                                 // number of items
                row[19] = "Ashlin®";                         // designer
                row[20] = list[4];                           // package height
                row[21] = list[5];                           // package length
                row[22] = list[6];                           // package width
                row[23] = "CM";                              // package dimension unit of measure
                row[24] = 100;                               // max order quantity
                row[25] = "";                                // legal disclaimer
                row[26] = "Ashlin BPG Marketing INC";        // manufacturer
                row[27] = sku;                               // mfr part number
                row[28] = list[8];                           // search term
                row[29] = sku.Substring(0, sku.IndexOf('-')); ;       // parent sku
                row[30] = 620977;                            // secondary product category id
                row[31] = true;                              // is new product
                row[32] = list[12];                          // alt iamge location 1
                row[33] = list[13];                          // alt iamge location 2
                row[34] = list[14];                          // alt iamge location 3
                row[35] = list[15];                          // alt iamge location 4
                row[36] = list[16];                          // alt iamge location 5
                row[37] = list[17];                          // alt iamge location 6
                row[38] = list[18];                          // alt iamge location 7
                row[39] = list[19];                          // alt iamge location 8
                row[40] = list[20];                          // alt iamge location 9

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
            // local field for storing data
            ArrayList list = new ArrayList();
            DataTable table = new DataTable();

            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            connection.Open();
            // [0] title, [1] description, [2] shipping weight, [3] for further looking, [4] package height, [5] package length, [6] package width            
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Shippable_Weight_grams, Design_Service_Family_Code, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 6; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            // [7] product type, [8] search term
            adapter = new SqlDataAdapter("SELECT Design_Service_Family_Description, Design_Service_Family_KeyWords_General FROM ref_Families WHERE Design_Service_Family_Code = \'" + table.Rows[0][3].ToString() + "\';", connection);
            table.Reset();
            adapter.Fill(table);
            for (int i = 0; i <= 1; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [9] main image location, [10] launch date, [11] ~ [19] alt image location, [20] release date, [21] standard product id
            adapter = new SqlDataAdapter("SELECT Image_1_Path, Date_Added, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Date_Activated, UPC_Code_9 FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 12; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            connection.Close();

            return list;
        }
    }
}
