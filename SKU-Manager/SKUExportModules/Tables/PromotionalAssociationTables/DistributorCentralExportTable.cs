using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables
{
    /*
     * A class that return magento export table
     */
    class DistributorCentralExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public DistributorCentralExportTable()
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
            addColumn(mainTable, "SupplierItemGUID");               // 1
            addColumn(mainTable, "Status");                         // 2
            addColumn(mainTable, "SuplItemNo");                     // 3
            addColumn(mainTable, "ItemName");                       // 4
            addColumn(mainTable, "SupDisplayNo");                   // 5
            addColumn(mainTable, "SupDisplayName");                 // 6
            addColumn(mainTable, "CreatedDate");                    // 7
            addColumn(mainTable, "LastUpdateDate");                 // 8
            addColumn(mainTable, "Description");                    // 9
            addColumn(mainTable, "AddInfo");                        // 10
            addColumn(mainTable, "DistributorOnlyInfo");            // 11
            addColumn(mainTable, "SuplInventoryNo");                // 12
            addColumn(mainTable, "Categories");                     // 13
            addColumn(mainTable, "Size");                           // 14
            addColumn(mainTable, "DisplayWeight");                  // 15
            addColumn(mainTable, "CountryOfManufactureGUID");       // 16
            addColumn(mainTable, "CountryOfManufatureName");        // 17
            addColumn(mainTable, "OptionsByOptionNumber");          // 18
            addColumn(mainTable, "OptionsByOptionName");            // 19
            addColumn(mainTable, "OptionsByOptionStyleNumber");     // 20
            addColumn(mainTable, "ItemOptionGUIDList");             // 21
            addColumn(mainTable, "ShipQty1");                       // 22
            addColumn(mainTable, "ShipWeight1");                    // 23
            addColumn(mainTable, "ShipLength1");                    // 24
            addColumn(mainTable, "ShipWidth1");                     // 25
            addColumn(mainTable, "ShipHeight1");                    // 26
            addColumn(mainTable, "ShipQty2");                       // 27
            addColumn(mainTable, "ShipWeigt2");                     // 28
            addColumn(mainTable, "ShipLength2");                    // 29
            addColumn(mainTable, "ShipWidth2");                     // 30
            addColumn(mainTable, "ShipHeight2");                    // 31
            addColumn(mainTable, "ShipQty3");                       // 32
            addColumn(mainTable, "ShipWeight3");                    // 33
            addColumn(mainTable, "ShipLength3");                    // 34
            addColumn(mainTable, "ShipWidth3");                     // 35
            addColumn(mainTable, "ShipHeight3");                    // 36
            addColumn(mainTable, "ShipQty4");                       // 37
            addColumn(mainTable, "ShipWeight4");                    // 38
            addColumn(mainTable, "ShipLength4");                    // 39
            addColumn(mainTable, "ShipWidth4");                     // 40
            addColumn(mainTable, "ShipHeight4A");                   // 41
            addColumn(mainTable, "HasImage");                       // 42
            addColumn(mainTable, "ImageLink");                      // 43
            addColumn(mainTable, "ProductVersionName");             // 44
            addColumn(mainTable, "AcctProductVersionGUID");         // 45
            addColumn(mainTable, "PriceTierName");                  // 46
            addColumn(mainTable, "PriceTierGUID");                  // 47
            addColumn(mainTable, "ShowCallForPricing");             // 48
            addColumn(mainTable, "SetupQty1");                      // 49
            addColumn(mainTable, "SetupNet1");                      // 50
            addColumn(mainTable, "SetupRetail1");                   // 51
            addColumn(mainTable, "SetupMargin1");                   // 52
            addColumn(mainTable, "SetupDisplay1");                  // 53
            addColumn(mainTable, "Qty1");                           // 54
            addColumn(mainTable, "Qty2");                           // 55
            addColumn(mainTable, "Qty3");                           // 56
            addColumn(mainTable, "Qty4");                           // 57
            addColumn(mainTable, "Qty5");                           // 58
            addColumn(mainTable, "Qty6");                           // 59
            addColumn(mainTable, "Qty7");                           // 60
            addColumn(mainTable, "Qty8");                           // 61
            addColumn(mainTable, "Net1");                           // 62
            addColumn(mainTable, "Net2");                           // 63
            addColumn(mainTable, "Net3");                           // 64
            addColumn(mainTable, "Net4");                           // 65
            addColumn(mainTable, "Net5");                           // 66
            addColumn(mainTable, "Net6");                           // 67
            addColumn(mainTable, "Net7");                           // 68
            addColumn(mainTable, "Net8");                           // 69
            addColumn(mainTable, "Retail1");                        // 70
            addColumn(mainTable, "Retail2");                        // 71
            addColumn(mainTable, "Retail3");                        // 72
            addColumn(mainTable, "Retail4");                        // 73
            addColumn(mainTable, "Retail5");                        // 74
            addColumn(mainTable, "Retail6");                        // 75
            addColumn(mainTable, "Retail7");                        // 76
            addColumn(mainTable, "Retail8");                        // 77
            addColumn(mainTable, "Margin1");                        // 78
            addColumn(mainTable, "Margin2");                        // 79
            addColumn(mainTable, "Margin3");                        // 80   
            addColumn(mainTable, "Margin4");                        // 81
            addColumn(mainTable, "Margin5");                        // 82
            addColumn(mainTable, "Margin6");                        // 83
            addColumn(mainTable, "Margin7");                        // 84
            addColumn(mainTable, "Margin8");                        // 85
            addColumn(mainTable, "Display1");                       // 86
            addColumn(mainTable, "Display2");                       // 87
            addColumn(mainTable, "Display3");                       // 88
            addColumn(mainTable, "Display4");                       // 89
            addColumn(mainTable, "Display5");                       // 90
            addColumn(mainTable, "Display6");                       // 91
            addColumn(mainTable, "Display7");                       // 92
            addColumn(mainTable, "Display8");                       // 93
            addColumn(mainTable, "Updated");                        // 94

            // local field for inserting data to table
            DataRow row;
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                row = mainTable.NewRow();
                ArrayList list = getData(sku);

                row[0] = list[1];                                                       // supplier item guid
                row[2] = sku;                                                           // supl item no
                row[3] = "Ashlin® " + list[3] + " " + list[4] + ", " + list[22];        // item name
                row[4] = sku;                                                           // sup display no
                row[5] = "Ashlin";                                                      // supl display name
                row[8] = list[5] + ". " + list[6] + ". " + list[7] + ". " + list[8] + ". " + list[9] + ". " + list[10];    // description
                row[9] = list[11] + "cm x " + list[12] + "cm";                          // add info
                row[11] = sku;                                                          // supl inventory no
                row[12] = list[21];                                                     // categories
                row[13] = list[13] + "cm x " + list[14] + "cm x " + list[15] + "cm";    // size
                row[14] = Convert.ToDouble(list[16]) / 453.592 + " lb";                 // display weight
                row[15] = "AE5A5850-05E9-42F9-A2B0-8CDA87D605AB";                       // country of manufacture guid
                row[16] = "Other/None";                                                 // country of manufacture name
                row[22] = Convert.ToDouble(list[17]) / 453.592;                         // ship weight 1
                row[23] = Convert.ToDouble(list[18]) / 2.54;                            // ship length 1
                row[24] = Convert.ToDouble(list[19]) / 2.54;                            // ship width 1
                row[25] = Convert.ToDouble(list[20]) / 2.54;                            // ship height 1
                row[27] = list[17];                                                     // ship weight 2
                row[28] = list[18];                                                     // ship length 2
                row[29] = list[19];                                                     // ship width 2
                row[30] = list[20];                                                     // ship height 2
                row[41] = list[2].ToString() != "";                                     // has image
                row[42] = list[2];                                                      // image link
                row[43] = "Regular";                                                    // product version name
                row[44] = "209671F9-D866-4E67-9000-FAFF9CB00683";                       // acct product version guid
                row[45] = "Default";                                                    // price tier name
                row[46] = "F32C0E86-E87B-485A-B9DD-B37BE4EEDC1A";                       // price tier guid
                row[47] = 0;                                                            // show call for pricing
                row[48] = 1;                                                            // set up qty 1
                row[49] = 37.5;                                                         // set up net 1
                row[50] = 46.875;                                                       // set up retail 1
                row[51] = 'G';                                                          // set up margin 1
                row[53] = 1;                                                            // qty 1
                row[54] = 6;                                                            // qty 2
                row[55] = 24;                                                           // qty 3
                row[56] = 50;                                                           // qty 4
                row[57] = 100;                                                          // qty 5
                row[58] = 250;                                                          // qty 6
                row[59] = 500;                                                          // qty 7
                row[60] = 1000;                                                         // qty 8
                double msrp = Convert.ToDouble(list[0]) * discountList[16];
                row[61] = msrp * discountList[8];                                       // net 1
                row[62] = msrp * discountList[9];                                       // net 2
                row[63] = msrp * discountList[10];                                      // net 3
                row[64] = msrp * discountList[11];                                      // net 4
                row[65] = msrp * discountList[12];                                      // net 5
                row[66] = msrp * discountList[13];                                      // net 6
                row[67] = msrp * discountList[14];                                      // net 7
                row[68] = msrp * discountList[15];                                      // net 8
                row[69] = msrp * discountList[0];                                       // retail 1
                row[70] = msrp * discountList[1];                                       // retail 2
                row[71] = msrp * discountList[2];                                       // retail 3
                row[72] = msrp * discountList[3];                                       // retail 4
                row[73] = msrp * discountList[4];                                       // retail 5
                row[74] = msrp * discountList[5];                                       // retail 6
                row[75] = msrp * discountList[6];                                       // retail 7
                row[76] = msrp * discountList[7];                                       // retail 8
                row[77] = 'C';                                                          // margin 1
                row[78] = 'C';                                                          // margin 2
                row[79] = 'C';                                                          // margin 3
                row[80] = 'C';                                                          // margin 4
                row[81] = 'C';                                                          // margin 5
                row[82] = 'C';                                                          // margin 6
                row[83] = 'C';                                                          // margin 7
                row[84] = 'C';                                                          // margin 8
                row[85] = true;                                                         // display 1
                row[86] = true;                                                         // display 2
                row[87] = true;                                                         // display 3
                row[88] = true;                                                         // display 4
                row[89] = true;                                                         // display 5
                row[90] = true;                                                         // display 6
                row[91] = true;                                                         // display 7
                row[92] = true;                                                         // display 8
                row[93] = 0;                                                            // updated

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND SKU_DistributorCentral != \'\' AND Design_Service_Code IN ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code IN ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_DistributorCentral != \'\'));", connection);
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
            // local fields for storing data
            ArrayList list = new ArrayList();

            // grab data from design database
            // [0] field that related to price, [1] SupplierItemGuid, [2] has image
            //                                                          & image link
            // [3] & [4] ItemName, [5] ~ [10] description, [11] ~ [12] add info, [13] ~ [15] size, [16] displayWeight, [17] ship weight 1, [18] ship legnth 1, [19] ship width 1, [20] ship height 1
            //                                                                                                            & ship weight 2,    & ship length2      & ship width 2,    & ship height 2
            // [21] categories
            // [22] item name
            SqlCommand command = new SqlCommand("SELECT Base_Price, SKU_DistributorCentral, Image_1_Path, " +
                                                "Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Weight_grams, Shippable_Weight_grams, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Height_cm, " +
                                                "Design_service_Family_Category_DistributorCentral, " +
                                                "Colour_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 22; i++)
            {
                list.Add(reader.GetValue(i));
            }
            connection.Close();

            return list;
        }

        /* a method that return the discount matrix */
        private double[] getDiscount()
        {
            double[] list = new double[17];

            // [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 1 c net standard
            // [9] 6 c net standard, [10] 24 c net standard, [11] 50 c net standard, [12] 100 net standard, [13] 250 net standard, [14] 500 net standard, [15] 1000 net standard
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], "
                                                     + "[1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery] FROM ref_discount_matrix;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 15; i++)
            {
                list[i] = reader.GetDouble(i);
            }
            reader.Close();
            // [16] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[16] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
