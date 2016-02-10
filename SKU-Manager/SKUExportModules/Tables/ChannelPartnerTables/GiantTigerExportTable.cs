using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return giant tiger export table
     */
    class GiantTigerExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public GiantTigerExportTable()
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
            DataRow row;
            AltText alt = new AltText();
            double multiplier = getMultiplier();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();

                row[0] = sku;                                                        // sku number
                row[1] = "Ashlin®";                                                  // brand
                row[2] = list[7];                                                    // style
                row[3] = alt.getAlt(sku);                                            // description
                row[4] = list[1];                                                    // romance
                row[5] = list[9];                                                    // color
                row[6] = list[8];                                                    // material
                row[7] = list[3] + "cm x " + list[4] + "cm x " + list[5] + "cm";     // size in cm
                row[8] = list[6];                                                    // weight
                row[9] = Convert.ToDouble(list[10]) * 0.6;                           // cost
                row[10] = Convert.ToDouble(list[10]) * multiplier * 0.95;            // retail
                row[11] = Convert.ToDouble(list[10]) * multiplier;                   // mrsp
                row[12] = "L5J 4S7";                                                 // area code
                row[13] = list[11];                                                  // image 1 path
                row[14] = list[12];                                                  // image 2 path
                row[15] = list[13];                                                  // image 3 path
                row[16] = list[14];                                                  // image 4 path
                row[17] = list[15];                                                  // image 5 path
                row[18] = list[16];                                                  // image 6 path
                row[19] = list[17];                                                  // image 7 path
                row[20] = list[18];                                                  // image 8 path
                row[21] = list[19];                                                  // image 9 path
                row[22] = list[20];                                                  // image 10 path

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

            // connect to database and grab data ( use the ones that have on walmart )
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND SKU_WALMART_CA != \'\' ORDER BY SKU_Ashlin;", connection);
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

            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            connection.Open();
            // [0] description, [1] romance, [2] for further looking, [3] ~ [5] size in cm, [6] weight
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description, Extended_Description, Design_Service_Family_Code, Height_cm, Width_cm, Depth_cm, Weight_grams FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 6; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            // [7] style
            adapter = new SqlDataAdapter("SELECT Design_Service_Family_Description FROM ref_Families WHERE Design_Service_Family_Code = \'" + table.Rows[0][2].ToString() + "\';", connection);
            table.Reset();
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [8] material
            adapter = new SqlDataAdapter("SELECT Material_Description_Short FROM ref_Materials WHERE Material_Code = \'" + material + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [9] color
            adapter = new SqlDataAdapter("SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [10] for all related to price, [11] ~ [20] iamge paths
            adapter = new SqlDataAdapter("SELECT Base_Price, Image_1_Path,Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 10; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            connection.Close();

            return list;
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
