using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca bag export table
     */
    public class ShopCaBagExportTable : ShopCaExportTable
    {
        /* constructor that initialize fields */
        public ShopCaBagExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset the table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "supplier id");                             // 1
            AddColumn(MainTable, "store name");                              // 2
            AddColumn(MainTable, "sku");                                     // 3
            AddColumn(MainTable, "title");                                   // 4
            AddColumn(MainTable, "description");                             // 5
            AddColumn(MainTable, "shipping weight");                         // 6
            AddColumn(MainTable, "shipping weight unit of measure");         // 7
            AddColumn(MainTable, "primary product category id");             // 8
            AddColumn(MainTable, "product type");                            // 9
            AddColumn(MainTable, "main image location");                     // 10
            AddColumn(MainTable, "standard product id");                     // 11
            AddColumn(MainTable, "standard product id type");                // 12
            AddColumn(MainTable, "availability");                            // 13
            AddColumn(MainTable, "brand");                                   // 14
            AddColumn(MainTable, "launch date");                             // 15
            AddColumn(MainTable, "release date");                            // 16
            AddColumn(MainTable, "product condition");                       // 17
            AddColumn(MainTable, "item package quantity");                   // 18
            AddColumn(MainTable, "number of items");                         // 19
            AddColumn(MainTable, "designer");                                // 20
            AddColumn(MainTable, "package height");                          // 21
            AddColumn(MainTable, "package length");                          // 22
            AddColumn(MainTable, "package width");                           // 23
            AddColumn(MainTable, "package dimension unit of measure");       // 24
            AddColumn(MainTable, "max order quantity");                      // 25
            AddColumn(MainTable, "legal disclaimer");                        // 26
            AddColumn(MainTable, "manufacturer");                            // 27
            AddColumn(MainTable, "mfr part number");                         // 28
            AddColumn(MainTable, "search terms");                            // 29
            AddColumn(MainTable, "parent sku");                              // 30
            AddColumn(MainTable, "secondary product category id");           // 31
            AddColumn(MainTable, "is new product");                          // 32
            AddColumn(MainTable, "alt image location 1");                    // 33
            AddColumn(MainTable, "alt image location 2");                    // 34
            AddColumn(MainTable, "alt image location 3");                    // 35
            AddColumn(MainTable, "alt image location 4");                    // 36
            AddColumn(MainTable, "alt image location 5");                    // 37
            AddColumn(MainTable, "alt image location 6");                    // 38
            AddColumn(MainTable, "alt image location 7");                    // 39
            AddColumn(MainTable, "alt image location 8");                    // 40
            AddColumn(MainTable, "alt image location 9");                    // 41
            AddColumn(MainTable, "video location");                          // 42
            AddColumn(MainTable, "material");                                // 43      
            AddColumn(MainTable, "color");                                   // 44
            AddColumn(MainTable, "style");                                   // 45
            AddColumn(MainTable, "trend");                                   // 47
            AddColumn(MainTable, "strap type");                              // 46
            AddColumn(MainTable, "closure type");                            // 48
            AddColumn(MainTable, "generic size");                            // 49
            AddColumn(MainTable, "features");                                // 50

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);
                DataRow newRow = MainTable.NewRow();

                newRow[0] = "ashlin_bpg";                                // supplier id
                newRow[1] = "nishis_boutique";                           // store name
                newRow[2] = list[24];                                    // sku
                newRow[3] = "Ashlin® " + list[0] + " " + list[21] + " " + list[23];    // title
                newRow[4] = list[1];                                     // description
                newRow[5] = list[2];                                     // shipping weight
                newRow[6] = "GM";                                        // shipping weight unit of measure
                newRow[7] = 151048;                                      // primary product category id
                newRow[8] = list[18];                                    // product type
                newRow[9] = list[25];                                    // main image location
                newRow[10] = list[37];                                   // standard product id
                newRow[11] = "UPC";                                      // standard product id type
                newRow[12] = true;                                       // availability
                newRow[13] = "Ashlin®";                                  // brand
                newRow[14] = list[26];                                   // launch date
                newRow[15] = list[36];                                   // release date
                newRow[16] = "NEW";                                      // product condition
                newRow[17] = 1;                                          // item package quantity
                newRow[18] = 1;                                          // number of items
                newRow[19] = "Ashlin®";                                  // designer
                newRow[20] = list[3];                                    // package height
                newRow[21] = list[4];                                    // package length
                newRow[22] = list[5];                                    // package width
                newRow[23] = "CM";                                       // package dimension unit of measure
                newRow[24] = 100;                                        // max order quantity
                newRow[25] = "";                                         // legal disclaimer     
                newRow[26] = "Ashlin BPG Marketing INC";                 // manufacturer
                newRow[27] = list[24];                                   // mfr part number
                newRow[28] = list[19];                                   // search term
                newRow[29] = list[24].ToString().Substring(0, list[24].ToString().IndexOf('-'));     // parent sku
                newRow[30] = 620977;                                     // secondary product category id
                newRow[31] = true;                                       // is new product
                newRow[32] = list[27];                                   // alt iamge location 1
                newRow[33] = list[28];                                   // alt iamge location 2
                newRow[34] = list[29];                                   // alt iamge location 3
                newRow[35] = list[30];                                   // alt iamge location 4
                newRow[36] = list[31];                                   // alt iamge location 5
                newRow[37] = list[32];                                   // alt iamge location 6
                newRow[38] = list[33];                                   // alt iamge location 7
                newRow[39] = list[34];                                   // alt iamge location 8
                newRow[40] = list[35];                                   // alt iamge location 9
                newRow[42] = list[20];                                   // material
                newRow[43] = list[22];                                   // colour
                newRow[44] = list[0];                                    // style
                newRow[45] = list[12];                                   // trend
                if ((bool) list[6] && (bool) list[7]) // strap type

                    newRow[46] = true + " Detachable strap";
                else if ((bool) list[6])
                    newRow[46] = true;
                else
                    newRow[46] = false;
                if ((bool) list[8]) // colsure type
                    newRow[47] = "Zippered enclosure";
                newRow[48] = list[9] + "cm x " + list[10] + "cm x " + list[11] + "cm";                         // generic size
                newRow[49] = list[13] + " " + list[14] + " " + list[15] + " " + list[16] + " " + list[17];     // features

                MainTable.Rows.Add(newRow);
                Progress++;
            } 

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] title, [1] description, [2] shipping weight, [3] package height, [4] package length, [5] package width, [6] & [7] strap type, [8] closure type, [9] ~ [11] generic size, [12] trend, [13] ~ [17] features            
            //   & style                                                                                                                 
            // [18] product type, [19] search term
            // [20] material, [21] title
            // [22] colour, [23] title
            // [24] sku, [25] main image location, [26] launch date, [27] ~ [35] alt image location, [36] release date, [37] standard product id
            // & mfr part number
            SqlCommand command = new SqlCommand("SELECT Short_Description, Extended_Description, Shippable_Weight_grams, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Width_cm, Strap, Detachable_Strap, Zippered_enclosure, Height_cm, Width_cm, Depth_cm, Trend_Short_Description, Option_1, Option_2, Option_3, Option_4, Option_5, " +
                                                "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                "Material_Description_Extended, Material_Description_Short, " +
                                                "Colour_Description_Extended, Colour_Description_Short, " +
                                                "SKU_Ashlin, Image_1_Path, sku.Date_Added, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, sku.Date_Activated, UPC_Code_9 " +
                                                "FROM master_Design_Attributes design " +
                                                "INNER JOIN master_SKU_Attributes sku ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 37; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that get all the sku that is active and have on shop ca with bag design */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_SHOP_CA != '' AND Design_Service_Code in (" +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code in ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE LOWER(Design_Service_Family_Description) LIKE 'bag%' OR LOWER(Design_Service_Family_Description) LIKE '%bag%' OR LOWER(Design_Service_Family_Description) LIKE '%bag'))", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }
    }
}
