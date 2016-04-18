using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return giant tiger export table
     */
    public class GiantTigerExportTable : ExportTableFast
    {
        /* constructor that initialize fields */
        public GiantTigerExportTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset the table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "SKU number");                                // 1
            AddColumn(mainTable, "Brand");                                     // 2
            AddColumn(mainTable, "Style");                                     // 3
            AddColumn(mainTable, "Description");                               // 4
            AddColumn(mainTable, "Romance");                                   // 5
            AddColumn(mainTable, "Color");                                     // 6
            AddColumn(mainTable, "Material");                                  // 7
            AddColumn(mainTable, "Size in CM");                                // 8
            AddColumn(mainTable, "Weight");                                    // 9
            AddColumn(mainTable, "Cost");                                      // 10
            AddColumn(mainTable, "Retail");                                    // 11
            AddColumn(mainTable, "MSRP");                                      // 12
            AddColumn(mainTable, "Area Code");                                 // 13
            AddColumn(mainTable, "Image 1 Path");                              // 14
            AddColumn(mainTable, "Image 2 Path");                              // 15
            AddColumn(mainTable, "Image 3 Path");                              // 16
            AddColumn(mainTable, "Image 4 Path");                              // 17
            AddColumn(mainTable, "Image 5 Path");                              // 18
            AddColumn(mainTable, "Image 6 Path");                              // 19
            AddColumn(mainTable, "Image 7 Path");                              // 20
            AddColumn(mainTable, "Image 8 Path");                              // 21
            AddColumn(mainTable, "Image 9 Path");                              // 22
            AddColumn(mainTable, "Image 10 Path");                             // 23

            // local field for inserting data to table
            DataTable table = GetDataTable();
            double[] price = GetPriceList();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = mainTable.NewRow();
                double msrp = Convert.ToDouble(row[9]) * price[0];

                newRow[0] = row[20];                                                   // sku number
                newRow[1] = "Ashlin®";                                                 // brand
                newRow[2] = row[6];                                                    // style
                newRow[3] = "Ashlin® " + row[0] + " " + row[7] + " " + row[8];         // description
                newRow[4] = row[0];                                                    // romance
                newRow[5] = row[8];                                                    // color
                newRow[6] = row[7];                                                    // material
                newRow[7] = row[2] + "cm x " + row[3] + "cm x " + row[4] + "cm";       // size in cm
                newRow[8] = row[5];                                                    // weight
                double sellMsrp = Math.Ceiling(msrp * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                newRow[9] = sellMsrp - (price[4] * sellMsrp) + price[3];               // cost
                newRow[10] = sellMsrp;                                                 // retail
                newRow[11] = msrp;                                                     // mrsp
                newRow[12] = "L5J 4S7";                                                // area code
                newRow[13] = row[10];                                                  // image 1 path
                newRow[14] = row[11];                                                  // image 2 path
                newRow[15] = row[12];                                                  // image 3 path
                newRow[16] = row[13];                                                  // image 4 path
                newRow[17] = row[14];                                                  // image 5 path
                newRow[18] = row[15];                                                  // image 6 path
                newRow[19] = row[16];                                                  // image 7 path
                newRow[20] = row[17];                                                  // image 8 path
                newRow[21] = row[18];                                                  // image 9 path
                newRow[22] = row[19];                                                  // image 10 path

                mainTable.Rows.Add(newRow);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data ( use the ones that have on walmart )
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_GIANT_TIGER != ''", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        protected override DataTable GetDataTable()
        {
            // local field for storing data
            DataTable table = new DataTable();

            // grab data from design
            // [0] description, [1] romance, [2] ~ [4] size in cm, [5] weight
            // [6] style
            // [7] material
            // [8] color
            // [9] for all related to price, [10] ~ [19] iamge paths, [20] sku number
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Height_cm, Width_cm, Depth_cm, Weight_grams, " +
                                                        "Design_Service_Family_Description, " +
                                                        "Material_Description_Short, " +
                                                        "Colour_Description_Short, " +
                                                        "Base_Price, Image_1_Path,Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, SKU_Ashlin " +
                                                        "FROM master_SKU_Attributes sku " +
                                                        "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " + 
                                                        "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " + 
                                                        "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " + 
                                                        "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                        "WHERE sku.Active = 'True' AND SKU_GIANT_TIGER != '' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();

            return table;
        }

        /* method that give price list */
        private double[] GetPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship, [4] gross marg
            double[] list = new double[5];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship, Gross_Marg FROM Channel_Pricing WHERE Channel_No = 2001";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            list[4] = (double)reader.GetDecimal(3);
            connection.Close();

            return list;
        }
    }
}
