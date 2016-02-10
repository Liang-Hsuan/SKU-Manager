using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca bag export table
     */
    class ShopCaBagExportTable : ShopCaExportTable
    {
        /* constructor that initialize fields */
        public ShopCaBagExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset the table just in case
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
            addColumn(mainTable, "material");                                // 43      
            addColumn(mainTable, "color");                                   // 44
            addColumn(mainTable, "style");                                   // 45
            addColumn(mainTable, "trend");                                   // 47
            addColumn(mainTable, "strap type");                              // 46
            addColumn(mainTable, "closure type");                            // 48
            addColumn(mainTable, "generic size");                            // 49
            addColumn(mainTable, "features");                                // 50

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

                row[0] = "ashlin_bpg";                                // supplier id
                row[1] = "nishis_boutique";                           // store name
                row[2] = sku;                                         // sku
                row[3] = alt.getAlt(sku);                             // title
                row[4] = list[1];                                     // description
                row[5] = list[2];                                     // shipping weight
                row[6] = "GM";                                        // shipping weight unit of measure
                row[7] = 151048;                                      // primary product category id
                row[8] = list[19];                                    // product type
                row[9] = list[23];                                    // main image location
                row[10] = list[35];                                   // standard product id
                row[11] = "UPC";                                      // standard product id type
                row[12] = true;                                       // availability
                row[13] = "Ashlin®";                                  // brand
                row[14] = list[24];                                   // launch date
                row[15] = list[34];                                   // release date
                row[16] = "NEW";                                      // product condition
                row[17] = 1;                                          // item package quantity
                row[18] = 1;                                          // number of items
                row[19] = "Ashlin®";                                  // designer
                row[20] = list[4];                                    // package height
                row[21] = list[5];                                    // package length
                row[22] = list[6];                                    // package width
                row[23] = "CM";                                       // package dimension unit of measure
                row[24] = 100;                                        // max order quantity
                row[25] = "";                                         // legal disclaimer     
                row[26] = "Ashlin BPG Marketing INC";                 // manufacturer
                row[27] = sku;                                        // mfr part number
                row[28] = list[20];                                   // search term
                row[29] = sku.Substring(0, sku.IndexOf('-')); ;       // parent sku
                row[30] = 620977;                                     // secondary product category id
                row[31] = true;                                       // is new product
                row[32] = list[25];                                   // alt iamge location 1
                row[33] = list[26];                                   // alt iamge location 2
                row[34] = list[27];                                   // alt iamge location 3
                row[35] = list[28];                                   // alt iamge location 4
                row[36] = list[29];                                   // alt iamge location 5
                row[37] = list[30];                                   // alt iamge location 6
                row[38] = list[31];                                   // alt iamge location 7
                row[39] = list[32];                                   // alt iamge location 8
                row[40] = list[33];                                   // alt iamge location 9
                row[42] = list[21];                                   // material
                row[43] = list[22];                                   // colour
                row[44] = list[0];                                    // style
                row[45] = list[13];                                   // trend
                if ((bool)list[7] && (bool)list[8])                   // strap type
                {
                    row[46] = true + " Detachable strap";
                }
                else if ((bool)list[7])
                {
                    row[46] = true;
                }
                else
                {
                    row[46] = false;
                }
                if ((bool)list[9])                                    // colsure type
                {
                    row[47] = "Zippered enclosure";
                }
                row[48] = list[10] + "cm x " + list[11] + "cm x " + list[12] + "cm";                          // generic size
                row[49] = list[14] + " " + list[15] + " " + list[16] + " " + list[17] + " " + list[18];       // features

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND SKU_SHOP_CA != \'\' AND Design_Service_Code in ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code in ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE LOWER(Design_Service_Family_Description) LIKE \'bag%\' OR LOWER(Design_Service_Family_Description) LIKE \'%bag%\' OR LOWER(Design_Service_Family_Description) LIKE \'%bag\'));", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skuList.Add(reader.GetString(0));
            }
            connection.Close();

            return skuList.ToArray();
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
            // [0] title, [1] description, [2] shipping weight, [3] for further looking, [4] package height, [5] package length, [6] package width, [7] & [8] strap type, [9] closure type, [10] ~ [12] generic size, [13] trend, [14] ~ [18] features            
            //   & style
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Shippable_Weight_grams, Design_Service_Family_Code, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, Strap, Detachable_Strap, Zippered_enclosure, Height_cm, Width_cm, Depth_cm, Trend_Short_Description, Option_1, Option_2, Option_3, Option_4, Option_5 FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 18; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            // [19] product type, [20] search term
            adapter = new SqlDataAdapter("SELECT Design_Service_Family_Description, Design_Service_Family_KeyWords_General FROM ref_Families WHERE Design_Service_Family_Code = \'" + table.Rows[0][3].ToString() + "\';", connection);
            table.Reset();
            adapter.Fill(table);
            for (int i = 0; i <= 1; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [21] material
            adapter = new SqlDataAdapter("SELECT Material_Description_Extended FROM ref_Materials WHERE Material_Code = \'" + material + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [22] colour
            adapter = new SqlDataAdapter("SELECT Colour_Description_Extended FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [23] main image location, [24] launch date, [25] ~ [33] alt image location, [34] release date, [35] standard product id
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
