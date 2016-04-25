using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return staples export table
     */
    public class StaplesExportTable : ExportTableFast
    {
        /* constructor that initialize fields */
        public StaplesExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "Vendor");                                                 // 1
            AddColumn(MainTable, "Vendor Name");                                            // 2
            AddColumn(MainTable, "UPC");                                                    // 3
            AddColumn(MainTable, "STAPLES SKU");                                            // 4
            AddColumn(MainTable, "SHORT PRODUCT NAME");                                     // 5
            AddColumn(MainTable, "VENDOR PART #");                                          // 6
            AddColumn(MainTable, "MFR MODEL");                                              // 7
            AddColumn(MainTable, "___");                                                    // 8
            AddColumn(MainTable, "__");                                                     // 9
            AddColumn(MainTable, "_");                                                      // 10
            AddColumn(MainTable, "CS");                                                     // 11
            AddColumn(MainTable, "Div");                                                    // 12
            AddColumn(MainTable, "Dept");                                                   // 13
            AddColumn(MainTable, "Class");                                                  // 14
            AddColumn(MainTable, "LENGTH");                                                 // 15
            AddColumn(MainTable, "WIDTH");                                                  // 16
            AddColumn(MainTable, "HEIGHT");                                                 // 17
            AddColumn(MainTable, "WEIGHT");                                                 // 18
            AddColumn(MainTable, "WHOLESALE COST");                                         // 19
            AddColumn(MainTable, "RETAIL PRICE");                                           // 20
            AddColumn(MainTable, "PRODUCT GROUP");                                          // 21
            AddColumn(MainTable, "RECOMMENDED PRIMARY CATEGORY");                           // 22
            AddColumn(MainTable, "RECOMMENDED SECONDARY CATEGORY");                         // 23
            AddColumn(MainTable, "Brand");                                                  // 24
            AddColumn(MainTable, "Web Name");                                               // 25
            AddColumn(MainTable, "SELLING PACK SIZE");                                      // 26
            AddColumn(MainTable, "COPY BULLET 1");                                          // 27
            AddColumn(MainTable, "COPY BULLET 2");                                          // 28
            AddColumn(MainTable, "COPY BULLET 3");                                          // 29
            AddColumn(MainTable, "COPY BULLET 4");                                          // 30
            AddColumn(MainTable, "COPY BULLET 5");                                          // 31
            AddColumn(MainTable, "COPY BULLET 6");                                          // 32
            AddColumn(MainTable, "COPY BULLET 7");                                          // 33
            AddColumn(MainTable, "COPY BULLET 8");                                          // 34
            AddColumn(MainTable, "COPY BULLET 9");                                          // 35
            AddColumn(MainTable, "COPY BULLET 10");                                         // 36
            AddColumn(MainTable, "Image_1_Path");                                           // 37 
            AddColumn(MainTable, "Image_2_Path");                                           // 38
            AddColumn(MainTable, "Image_3_Path");                                           // 39
            AddColumn(MainTable, "Image_4_Path");                                           // 40
            AddColumn(MainTable, "Customization_Personalization_Initials_Charge");          // 41
            AddColumn(MainTable, "Customization_Personalization_Name_Charge");              // 42
            AddColumn(MainTable, "Customization_Logo_Charge");                              // 43

            // local field for inserting data to table
            DataTable table = GetDataTable();
            double[] discountList = GetDiscount();

            // start loading data
            MainTable.BeginLoadData();

            // add data to each row 
            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = MainTable.NewRow();

                newRow[0] = "Ashlin Leather";                                          // vendor
                newRow[1] = "juanne.kochhar@ashlinbpg.com";                            // vendor name
                newRow[2] = row[15];                                                   // UPC 
                newRow[3] = row[16];                                                   // staples sku
                newRow[4] = row[0];                                                    // short product name
                newRow[5] = row[17];                                                   // vendor part #
                newRow[6] = row[17];                                                   // mfr model
                if (!row[1].Equals(DBNull.Value))
                {
                    newRow[14] = Math.Round(Convert.ToDouble(row[1]) / 2.54, 2);       // length
                    newRow[15] = Math.Round(Convert.ToDouble(row[2]) / 2.54, 2);       // width
                    newRow[16] = Math.Round(Convert.ToDouble(row[3]) / 2.54, 2);       // height
                }
                if (!row[4].Equals(DBNull.Value))
                    newRow[17] = Math.Round(Convert.ToDouble(row[4])/453.952, 2);      // weight
                double sellMsrp = Math.Ceiling((Convert.ToDouble(row[18]) * discountList[0]) * (1 - discountList[1] / 100) + discountList[3]) - (1 - discountList[2]);
                newRow[18] = sellMsrp - (discountList[4] * sellMsrp) + discountList[3];// wholesale cost
                newRow[19] = sellMsrp;                                                 // retail price
                newRow[23] = "Ashlin®";                                                // brand
                newRow[24] = "Ashlin® " + row[0] + " " + row[5] + " " + row[23];       // web name
                newRow[26] = row[6];                                                   // copy bullet 1
                newRow[27] = row[7];                                                   // copy bullet 2
                newRow[28] = row[8];                                                   // copy bullet 3
                newRow[29] = row[9];                                                   // copy bullet 4
                newRow[30] = row[10];                                                  // copy bullet 5
                newRow[31] = row[11];                                                  // copy bullet 6
                if (!row[12].Equals(DBNull.Value))
                {
                    newRow[32] = "Finished Dimensions (cm): " + row[12] + " x " + row[13] + " x " + row[14];                                                                                                                                           // copy bullet 7
                    newRow[33] = "Finished Dimensions (in): " + Math.Round(Convert.ToDouble(row[12]) / 2.54, 2) + "\" x " + Math.Round(Convert.ToDouble(row[13]) / 2.54, 2) + "\" x " + Math.Round(Convert.ToDouble(row[14]) / 2.54, 2) + "\"";        // copy bullet 8
                }
                newRow[34] = row[24];                                                   // copy bullet 9
                newRow[36] = row[19];                                                   // image 1 path
                newRow[37] = row[20];                                                   // image 2 path
                newRow[38] = row[21];                                                   // image 3 path
                newRow[39] = row[22];                                                   // image 4 path
                newRow[40] = 6.00;                                                      // customization personalization initials charge
                newRow[41] = 10.00;                                                     // customization personalization name change 
                newRow[42] = 75.00;                                                     // customization logo charge

                MainTable.Rows.Add(newRow);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();

            return MainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_STAPLES_CA != '' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }

        /* new version of getData that directly return the desired table -> no issue */
        protected override DataTable GetDataTable()
        {
            // local field for storing data
            DataTable table = new DataTable();

            // grab data from design
            // [0] for short product name, [1] for length [2] for width, [3] for height, [4] for weight , [5] for web name, [6] for copy bullet 1, [7] ~ [11] for copy bullet 2 to 6, [12] ~ [14] for copy bullet 7 
            //     and web name  
            // [15] for upc, [16] for staples sku, [17] for vendor part #, [18] for wholesale cost, [19] ~ [22] for image path
            //                                      and mfr model           and retail price
            // [23] for web name, [24] for copy bullet 9
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Fashion_Name_STAPLES_CA, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Height_cm, Shippable_Weight_grams, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Width_cm, Height_cm, Depth_cm, " +
                                                        "UPC_CODE_10, SKU_STAPLES_CA, SKU_Ashlin, Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, " +
                                                        "Colour_Description_Short, Colour_Description_Extended " + 
                                                        "FROM master_SKU_Attributes sku " +
                                                        "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                        "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                        "WHERE sku.Active = 'True' AND SKU_STAPLES_CA != '' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            adapter.Fill(table);
            Connection.Close();

            return table;
        }

        /* a method that return the discount matrix */
        private double[] GetDiscount()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship, [4] gross marg
            double[] list = new double[5];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship, Gross_Marg FROM Channel_Pricing WHERE Channel_No = 2008";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            list[4] = (double)reader.GetDecimal(3);
            Connection.Close();

            return list;
        }
    }
}
