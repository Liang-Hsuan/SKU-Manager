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
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset the table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "SKU number");                                // 1
            addColumn(mainTable, "Brand");                                     // 2
            addColumn(mainTable, "Style");                                     // 3
            addColumn(mainTable, "Description");                               // 4
            addColumn(mainTable, "Romance");                                   // 5
            addColumn(mainTable, "Color");                                     // 6
            addColumn(mainTable, "Material");                                  // 7
            addColumn(mainTable, "Size in CM");                                // 8
            addColumn(mainTable, "Weight");                                    // 9
            addColumn(mainTable, "Cost");                                      // 10
            addColumn(mainTable, "Retail");                                    // 11
            addColumn(mainTable, "MSRP");                                      // 12
            addColumn(mainTable, "Area Code");                                 // 13
            addColumn(mainTable, "Image 1 Path");                              // 14
            addColumn(mainTable, "Image 2 Path");                              // 15
            addColumn(mainTable, "Image 3 Path");                              // 16
            addColumn(mainTable, "Image 4 Path");                              // 17
            addColumn(mainTable, "Image 5 Path");                              // 18
            addColumn(mainTable, "Image 6 Path");                              // 19
            addColumn(mainTable, "Image 7 Path");                              // 20
            addColumn(mainTable, "Image 8 Path");                              // 21
            addColumn(mainTable, "Image 9 Path");                              // 22
            addColumn(mainTable, "Image 10 Path");                             // 23

            // local field for inserting data to table
            DataTable table = getDataTable();
            double multiplier = getMultiplier();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (DataRow row in table.Rows)
            {
                var newRow = mainTable.NewRow();

                newRow[0] = row[20];                                                   // sku number
                newRow[1] = "Ashlin®";                                                 // brand
                newRow[2] = row[6];                                                    // style
                newRow[3] = "Ashlin® " + row[0] + " " + row[7] + " " + row[8];         // description
                newRow[4] = row[0];                                                    // romance
                newRow[5] = row[8];                                                    // color
                newRow[6] = row[7];                                                    // material
                newRow[7] = row[2] + "cm x " + row[3] + "cm x " + row[4] + "cm";       // size in cm
                newRow[8] = row[5];                                                    // weight
                newRow[9] = Convert.ToDouble(row[9]) * 0.6;                            // cost
                newRow[10] = Convert.ToDouble(row[9]) * multiplier * 0.95;             // retail
                newRow[11] = Convert.ToDouble(row[9]) * multiplier;                    // mrsp
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

            // connect to database and grab data ( use the ones that have on walmart )
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND SKU_WALMART_CA != \'\' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* method that get the data from given sku */
        protected override DataTable getDataTable()
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
                                                        "WHERE sku.Active = \'True\' AND SKU_WALMART_CA != \'\' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();

            return table;
        }

        /* method that give price multiplier */
        private double getMultiplier()
        {
            // get multiplier data
            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            double multiplier = reader.GetDouble(0);
            connection.Close();

            return multiplier;
        }
    }
}
