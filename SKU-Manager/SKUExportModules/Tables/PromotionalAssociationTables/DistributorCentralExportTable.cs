using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables
{
    /*
     * A class that return distributor central export table
     */
    public class DistributorCentralExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public DistributorCentralExportTable()
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
            AddColumn(mainTable, "SupplierItemGUID");               // 1
            AddColumn(mainTable, "Status");                         // 2
            AddColumn(mainTable, "SuplItemNo");                     // 3
            AddColumn(mainTable, "ItemName");                       // 4
            AddColumn(mainTable, "SupDisplayNo");                   // 5
            AddColumn(mainTable, "SupDisplayName");                 // 6
            AddColumn(mainTable, "CreatedDate");                    // 7
            AddColumn(mainTable, "LastUpdateDate");                 // 8
            AddColumn(mainTable, "Description");                    // 9
            AddColumn(mainTable, "AddInfo");                        // 10
            AddColumn(mainTable, "DistributorOnlyInfo");            // 11
            AddColumn(mainTable, "SuplInventoryNo");                // 12
            AddColumn(mainTable, "Categories");                     // 13
            AddColumn(mainTable, "Size");                           // 14
            AddColumn(mainTable, "DisplayWeight");                  // 15
            AddColumn(mainTable, "CountryOfManufactureGUID");       // 16
            AddColumn(mainTable, "CountryOfManufatureName");        // 17
            AddColumn(mainTable, "OptionsByOptionNumber");          // 18
            AddColumn(mainTable, "OptionsByOptionName");            // 19
            AddColumn(mainTable, "OptionsByOptionStyleNumber");     // 20
            AddColumn(mainTable, "ItemOptionGUIDList");             // 21
            AddColumn(mainTable, "ShipQty1");                       // 22
            AddColumn(mainTable, "ShipWeight1");                    // 23
            AddColumn(mainTable, "ShipLength1");                    // 24
            AddColumn(mainTable, "ShipWidth1");                     // 25
            AddColumn(mainTable, "ShipHeight1");                    // 26
            AddColumn(mainTable, "ShipQty2");                       // 27
            AddColumn(mainTable, "ShipWeigt2");                     // 28
            AddColumn(mainTable, "ShipLength2");                    // 29
            AddColumn(mainTable, "ShipWidth2");                     // 30
            AddColumn(mainTable, "ShipHeight2");                    // 31
            AddColumn(mainTable, "ShipQty3");                       // 32
            AddColumn(mainTable, "ShipWeight3");                    // 33
            AddColumn(mainTable, "ShipLength3");                    // 34
            AddColumn(mainTable, "ShipWidth3");                     // 35
            AddColumn(mainTable, "ShipHeight3");                    // 36
            AddColumn(mainTable, "ShipQty4");                       // 37
            AddColumn(mainTable, "ShipWeight4");                    // 38
            AddColumn(mainTable, "ShipLength4");                    // 39
            AddColumn(mainTable, "ShipWidth4");                     // 40
            AddColumn(mainTable, "ShipHeight4A");                   // 41
            AddColumn(mainTable, "HasImage");                       // 42
            AddColumn(mainTable, "ImageLink");                      // 43
            AddColumn(mainTable, "ProductVersionName");             // 44
            AddColumn(mainTable, "AcctProductVersionGUID");         // 45
            AddColumn(mainTable, "PriceTierName");                  // 46
            AddColumn(mainTable, "PriceTierGUID");                  // 47
            AddColumn(mainTable, "ShowCallForPricing");             // 48
            AddColumn(mainTable, "SetupQty1");                      // 49
            AddColumn(mainTable, "SetupNet1");                      // 50
            AddColumn(mainTable, "SetupRetail1");                   // 51
            AddColumn(mainTable, "SetupMargin1");                   // 52
            AddColumn(mainTable, "SetupDisplay1");                  // 53
            AddColumn(mainTable, "Qty1");                           // 54
            AddColumn(mainTable, "Qty2");                           // 55
            AddColumn(mainTable, "Qty3");                           // 56
            AddColumn(mainTable, "Qty4");                           // 57
            AddColumn(mainTable, "Qty5");                           // 58
            AddColumn(mainTable, "Qty6");                           // 59
            AddColumn(mainTable, "Qty7");                           // 60
            AddColumn(mainTable, "Qty8");                           // 61
            AddColumn(mainTable, "Net1");                           // 62
            AddColumn(mainTable, "Net2");                           // 63
            AddColumn(mainTable, "Net3");                           // 64
            AddColumn(mainTable, "Net4");                           // 65
            AddColumn(mainTable, "Net5");                           // 66
            AddColumn(mainTable, "Net6");                           // 67
            AddColumn(mainTable, "Net7");                           // 68
            AddColumn(mainTable, "Net8");                           // 69
            AddColumn(mainTable, "Retail1");                        // 70
            AddColumn(mainTable, "Retail2");                        // 71
            AddColumn(mainTable, "Retail3");                        // 72
            AddColumn(mainTable, "Retail4");                        // 73
            AddColumn(mainTable, "Retail5");                        // 74
            AddColumn(mainTable, "Retail6");                        // 75
            AddColumn(mainTable, "Retail7");                        // 76
            AddColumn(mainTable, "Retail8");                        // 77
            AddColumn(mainTable, "Margin1");                        // 78
            AddColumn(mainTable, "Margin2");                        // 79
            AddColumn(mainTable, "Margin3");                        // 80   
            AddColumn(mainTable, "Margin4");                        // 81
            AddColumn(mainTable, "Margin5");                        // 82
            AddColumn(mainTable, "Margin6");                        // 83
            AddColumn(mainTable, "Margin7");                        // 84
            AddColumn(mainTable, "Margin8");                        // 85
            AddColumn(mainTable, "Display1");                       // 86
            AddColumn(mainTable, "Display2");                       // 87
            AddColumn(mainTable, "Display3");                       // 88
            AddColumn(mainTable, "Display4");                       // 89
            AddColumn(mainTable, "Display5");                       // 90
            AddColumn(mainTable, "Display6");                       // 91
            AddColumn(mainTable, "Display7");                       // 92
            AddColumn(mainTable, "Display8");                       // 93
            AddColumn(mainTable, "Updated");                        // 94

            // local field for inserting data to table
            double[][] discountList = GetDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                ArrayList list = GetData(sku);

                row[0] = list[1];                                                       // supplier item guid
                row[2] = sku;                                                           // supl item no
                row[3] = "Ashlin® " + list[4] + " " + list[5] + ", " + list[23];        // item name
                row[4] = sku;                                                           // sup display no
                row[5] = "Ashlin";                                                      // supl display name
                row[8] = list[6] + ". " + list[7] + ". " + list[8] + ". " + list[9] + ". " + list[10] + ". " + list[11];    // description
                row[9] = list[12] + "cm x " + list[13] + "cm";                          // add info
                row[11] = sku;                                                          // supl inventory no
                row[12] = list[22];                                                     // categories
                row[13] = list[14] + "cm x " + list[15] + "cm x " + list[16] + "cm";    // size
                row[14] = Convert.ToDouble(list[17]) / 453.592 + " lb";                 // display weight
                row[15] = "AE5A5850-05E9-42F9-A2B0-8CDA87D605AB";                       // country of manufacture guid
                row[16] = "Other/None";                                                 // country of manufacture name
                row[22] = Convert.ToDouble(list[18]) / 453.592;                         // ship weight 1
                row[23] = Convert.ToDouble(list[19]) / 2.54;                            // ship length 1
                row[24] = Convert.ToDouble(list[20]) / 2.54;                            // ship width 1
                row[25] = Convert.ToDouble(list[21]) / 2.54;                            // ship height 1
                row[27] = list[18];                                                     // ship weight 2
                row[28] = list[19];                                                     // ship length 2
                row[29] = list[20];                                                     // ship width 2
                row[30] = list[21];                                                     // ship height 2
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
                double msrp = Convert.ToDouble(list[0]) * discountList[5][0];
                int k;
                switch (Convert.ToInt32(list[3]))
                {
                    case 1:
                        k = 1;
                        break;
                    case 2:
                        k = 2;
                        break;
                    case 3:
                        k = 3;
                        break;
                    case 4:
                        k = 4;
                        break;
                    default:
                        k = 0;
                        break;
                }
                row[61] = msrp * discountList[k][8];                                    // net 1
                row[62] = msrp * discountList[k][9];                                    // net 2
                row[63] = msrp * discountList[k][10];                                   // net 3
                row[64] = msrp * discountList[k][11];                                   // net 4
                row[65] = msrp * discountList[k][12];                                   // net 5
                row[66] = msrp * discountList[k][13];                                   // net 6
                row[67] = msrp * discountList[k][14];                                   // net 7
                row[68] = msrp * discountList[k][15];                                   // net 8
                row[69] = msrp * discountList[k][0];                                    // retail 1
                row[70] = msrp * discountList[k][1];                                    // retail 2
                row[71] = msrp * discountList[k][2];                                    // retail 3
                row[72] = msrp * discountList[k][3];                                    // retail 4
                row[73] = msrp * discountList[k][4];                                    // retail 5
                row[74] = msrp * discountList[k][5];                                    // retail 6
                row[75] = msrp * discountList[k][6];                                    // retail 7
                row[76] = msrp * discountList[k][7];                                    // retail 8
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
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_DistributorCentral != '' AND Design_Service_Code IN ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code IN ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_DistributorCentral != ''));", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList GetData(string sku)
        {
            // local fields for storing data
            ArrayList list = new ArrayList();

            // grab data from design database
            // [0] field that related to price, [1] SupplierItemGuid, [2] has image, [3] for price calculation
            //                                                          & image link
            // [4] & [5] ItemName, [6] ~ [11] description, [12] & [13] add info, [4] ~ [16] size, [17] displayWeight, [18] ship weight 1, [19] ship legnth 1, [20] ship width 1, [21] ship height 1
            //                                                                                                           & ship weight 2,    & ship length2      & ship width 2,    & ship height 2
            // [22] categories
            // [23] item name
            SqlCommand command = new SqlCommand("SELECT Base_Price, SKU_DistributorCentral, Image_1_Path, sku.Pricing_Tier, " +
                                                "Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Weight_grams, Shippable_Weight_grams, Shippable_Depth_cm, Shippable_Width_cm, Shippable_Height_cm, " +
                                                "Design_service_Family_Category_DistributorCentral, " +
                                                "Colour_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 23; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[6][];

            // [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 1 c net standard
            // [9] 6 c net standard, [10] 24 c net standard, [11] 50 c net standard, [12] 100 net standard, [13] 250 net standard, [14] 500 net standard, [15] 1000 net standard
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], "
                                              + "[1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery] FROM Discount_Matrix", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
            {
                double[] itemList = new double[16];
                reader.Read();
                for (int j = 0; j <= 15; j++)
                {
                    try
                    {
                        itemList[j] = reader.GetDouble(j);
                    }
                    catch
                    {
                        itemList[j] = 0;
                    }
                }
                list[i] = itemList;
            }
            reader.Close();

            // [5] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[5] = new[] { reader.GetDouble(0) };
            connection.Close();

            return list;
        }
    }
}
