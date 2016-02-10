using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return staples export table
     */
    class StaplesExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public StaplesExportTable()
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
            addColumn(mainTable, "Vendor");                                                 // 1
            addColumn(mainTable, "Vendor Name");                                            // 2
            addColumn(mainTable, "UPC");                                                    // 3
            addColumn(mainTable, "STAPLES SKU");                                            // 4
            addColumn(mainTable, "SHORT PRODUCT NAME");                                     // 5
            addColumn(mainTable, "VENDOR PART #");                                          // 6
            addColumn(mainTable, "MFR MODEL");                                              // 7
            addColumn(mainTable, "___");                                                    // 8
            addColumn(mainTable, "__");                                                     // 9
            addColumn(mainTable, "_");                                                      // 10
            addColumn(mainTable, "CS");                                                     // 11
            addColumn(mainTable, "Div");                                                    // 12
            addColumn(mainTable, "Dept");                                                   // 13
            addColumn(mainTable, "Class");                                                  // 14
            addColumn(mainTable, "LENGTH");                                                 // 15
            addColumn(mainTable, "WIDTH");                                                  // 16
            addColumn(mainTable, "HEIGHT");                                                 // 17
            addColumn(mainTable, "WEIGHT");                                                 // 18
            addColumn(mainTable, "WHOLESALE COST");                                         // 19
            addColumn(mainTable, "RETAIL PRICE");                                           // 20
            addColumn(mainTable, "PRODUCT GROUP");                                          // 21
            addColumn(mainTable, "RECOMMENDED PRIMARY CATEGORY");                           // 22
            addColumn(mainTable, "RECOMMENDED SECONDARY CATEGORY");                         // 23
            addColumn(mainTable, "Brand");                                                  // 24
            addColumn(mainTable, "Web Name");                                               // 25
            addColumn(mainTable, "SELLING PACK SIZE");                                      // 26
            addColumn(mainTable, "COPY BULLET 1");                                          // 27
            addColumn(mainTable, "COPY BULLET 2");                                          // 28
            addColumn(mainTable, "COPY BULLET 3");                                          // 29
            addColumn(mainTable, "COPY BULLET 4");                                          // 30
            addColumn(mainTable, "COPY BULLET 5");                                          // 31
            addColumn(mainTable, "COPY BULLET 6");                                          // 32
            addColumn(mainTable, "COPY BULLET 7");                                          // 33
            addColumn(mainTable, "COPY BULLET 8");                                          // 34
            addColumn(mainTable, "COPY BULLET 9");                                          // 35
            addColumn(mainTable, "COPY BULLET 10");                                         // 36
            addColumn(mainTable, "Image_1_Path");                                           // 37 
            addColumn(mainTable, "Image_2_Path");                                           // 38
            addColumn(mainTable, "Image_3_Path");                                           // 39
            addColumn(mainTable, "Image_4_Path");                                           // 40
            addColumn(mainTable, "Customization_Personalization_Initials_Charge");          // 41
            addColumn(mainTable, "Customization_Personalization_Name_Charge");              // 42
            addColumn(mainTable, "Customization_Logo_Charge");                              // 43

            // local field for inserting data to table
            DataRow row;
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();

                row[0] = "Ashlin Leather";                                            // vendor
                row[1] = "juanne.kochhar@ashlinbpg.com";                              // vendor name
                row[2] = list[15];                                                    // UPC 
                row[3] = list[16];                                                    // staples sku
                row[4] = list[0];                                                     // short product name
                row[5] = list[17];                                                    // vendor part #
                row[6] = list[17];                                                    // mfr model
                if (!list[1].Equals(DBNull.Value))
                { 
                    row[14] = Math.Round(Convert.ToDouble(list[1]) / 2.54, 2);        // length
                    row[15] = Math.Round(Convert.ToDouble(list[2]) / 2.54, 2);        // width
                    row[16] = Math.Round(Convert.ToDouble(list[3]) / 2.54, 2);        // height
                }
                if (!list[4].Equals(DBNull.Value))
                {
                    row[17] = Math.Round(Convert.ToDouble(list[4]) / 453.952, 2);     // weight
                }
                row[18] = Convert.ToDouble(list[18]) * discountList[0] * discountList[1];    // wholesale cost
                row[19] = Convert.ToDouble(list[18]) * discountList[1];               // retail price
                row[23] = "Ashlin®";                                                  // brand
                row[24] = "Ashlin® " + list[0] + " " + list[5] + " " + list[23];      // web name
                row[26] = list[6];                                                    // copy bullet 1
                row[27] = list[7];                                                    // copy bullet 2
                row[28] = list[8];                                                    // copy bullet 3
                row[29] = list[9];                                                    // copy bullet 4
                row[30] = list[10];                                                   // copy bullet 5
                row[31] = list[11];                                                   // copy bullet 6
                if (!list[12].Equals(DBNull.Value))
                {
                    row[32] = "Finished Dimensions (cm): " + list[12] + " x " + list[13] + " x " + list[14];                                                                                                                                           // copy bullet 7
                    row[33] = "Finished Dimensions (in): " + Math.Round(Convert.ToDouble(list[12]) / 2.54, 2) + "\" x " + Math.Round(Convert.ToDouble(list[13]) / 2.54, 2) + "\" x " + Math.Round(Convert.ToDouble(list[14]) / 2.54, 2) + "\"";        // copy bullet 8
                }
                row[34] = list[24];                                                   // copy bullet 9
                row[36] = list[19];                                                   // image 1 path
                row[37] = list[20];                                                   // image 2 path
                row[38] = list[21];                                                   // image 3 path
                row[39] = list[22];                                                   // image 4 path
                row[40] = 6.00;                                                       // customization personalization initials charge
                row[41] = 10.00;                                                      // customization personalization name change 
                row[42] = 75.00;                                                      // customization logo charge

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'TRUE\' AND SKU_STAPLES_CA != \'\' ORDER BY SKU_Ashlin", connection);
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
        private ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();
            DataTable table = new DataTable();

            // get the design and color code from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            // [0] for short product name, [1] for length [2] for width, [3] for height, [4] for weight , [5] for web name, [6] for copy bullet 1, [7] ~ [11] for copy bullet 2 to 6, [12] ~ [14] for copy bullet 7 
            //     and web name                                                                                                                                                                                                                                                                                                                                      
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Fashion_Name_STAPLES_CA, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Height_cm, Shippable_Weight_grams, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Width_cm, Height_cm, Depth_cm FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            for (int i = 0; i <= 14; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [15] for upc, [16] for staples sku, [17] for vendor part #, [18] for wholesale cost, [19] ~ [22] for image path
            //                                      and mfr model           and retail price
            adapter = new SqlDataAdapter("SELECT UPC_CODE_10, SKU_STAPLES_CA, SKU_Ashlin, Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 7; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [23] for web name, [24] for copy bullet 9
            adapter = new SqlDataAdapter("SELECT Colour_Description_Short, Colour_Description_Extended FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            list.Add(table.Rows[0][1]);
            connection.Close();

            return list;
        }

        /* a method that return the discount matrix */
        private double[] getDiscount()
        {
            double[] list = new double[2];

            // [0] wholesale
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM ref_discount_matrix;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();
            // [1] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
