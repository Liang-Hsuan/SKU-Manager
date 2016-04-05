using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables
{
    /*
     * A class that return active price list export table
     */
    public class ActivePriceListTable : ExportTable
    {
        /* constructor that initialize fields */
        public ActivePriceListTable()
        {
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "Brand");                                                 // 1
            addColumn(mainTable, "Brand Description");                                     // 2
            addColumn(mainTable, "SKU_Ahslin");                                            // 3
            addColumn(mainTable, "Design_Service_Code");                                   // 4
            addColumn(mainTable, "Material_Code");                                         // 5
            addColumn(mainTable, "Material_Description_Short");                            // 6
            addColumn(mainTable, "Material_Description_Extended");                         // 7
            addColumn(mainTable, "Material_Description_Short_FR");                         // 8
            addColumn(mainTable, "Material_Description_Extended_FR");                      // 9
            addColumn(mainTable, "Colour_Code");                                           // 10
            addColumn(mainTable, "Colour_Description_Short");                              // 11
            addColumn(mainTable, "Colour_Description_Extended");                           // 12
            addColumn(mainTable, "Colour_Description_Short_FR");                           // 13
            addColumn(mainTable, "Colour_Description_Extended_FR");                        // 14
            addColumn(mainTable, "Design_Service_Flag");                                   // 15
            addColumn(mainTable, "Design_Service_Family_Code");                            // 16
            addColumn(mainTable, "Design_Service_Family_Description");                     // 17
            addColumn(mainTable, "Design_Service_Family_Description_FR");                  // 18
            addColumn(mainTable, "Design_Service_Family_KeyWords_Generals");               // 19
            addColumn(mainTable, "Design_Service_Family_Category_Sage");                   // 20
            addColumn(mainTable, "Design_Service_Family_Category_ESP");                    // 21
            addColumn(mainTable, "Design_Service_Family_Category_PromoMarketing");         // 22
            addColumn(mainTable, "Design_Service_Family_Category_UDUCAT");                 // 23
            addColumn(mainTable, "Design_Service_Family_Category_DistributorCentral");     // 24
            addColumn(mainTable, "Design_Service_Family_Themes_Sage");                     // 25
            addColumn(mainTable, "Design Short Description");                              // 26
            addColumn(mainTable, "Design Extended Description");                           // 27
            addColumn(mainTable, "Design Short Description FR");                           // 28
            addColumn(mainTable, "Design Extended Description FR");                        // 29
            addColumn(mainTable, "Imprintable");                                           // 30
            addColumn(mainTable, "Imprint_Height_cm");                                     // 31
            addColumn(mainTable, "Imprint_Width_cm");                                      // 32
            addColumn(mainTable, "Depth_cm");                                              // 33
            addColumn(mainTable, "Width_cm");                                              // 34
            addColumn(mainTable, "Height_cm");                                             // 35
            addColumn(mainTable, "Imprint_Height_in");                                     // 36
            addColumn(mainTable, "Imprint_Width_in");                                      // 37
            addColumn(mainTable, "Depth_in");                                              // 38
            addColumn(mainTable, "Width_in");                                              // 39
            addColumn(mainTable, "Height_in");                                             // 40
            addColumn(mainTable, "Weight_grams");                                          // 41
            addColumn(mainTable, "Weight_Pounds");                                         // 42
            addColumn(mainTable, "Shippable_Width_cm");                                    // 43
            addColumn(mainTable, "Shippable_Height_cm");                                   // 44
            addColumn(mainTable, "Shippable_Depth_cm");                                    // 45
            addColumn(mainTable, "Shippable_Width_in");                                    // 46
            addColumn(mainTable, "Shippable_Height_in");                                   // 47
            addColumn(mainTable, "Shippable_Depth_in");                                    // 48
            addColumn(mainTable, "Shippable_weight_grams");                                // 49
            addColumn(mainTable, "Shippable_weight_lb");                                   // 50
            addColumn(mainTable, "Strap");                                                 // 51
            addColumn(mainTable, "Detachable_Strap");                                      // 52
            addColumn(mainTable, "Zippered_Enclosure");                                    // 53
            addColumn(mainTable, "Design_Service_Fashion_Name_Ashlin");                    // 54
            addColumn(mainTable, "Design_Service_Fashion_Name_TSC_CA");                    // 55
            addColumn(mainTable, "Design_Service_Fashion_name_COSTCO_CA");                 // 56
            addColumn(mainTable, "Design_Service_Fashion_Name_BESTBUY_CA");                // 57
            addColumn(mainTable, "Design_Service_Fashion_Name_SHOP_CA");                   // 58
            addColumn(mainTable, "Design_Servive_Fashion_Name_AMAZON_CA");                 // 59
            addColumn(mainTable, "Design_Service_Fashion_Name_AMAZON_COM");                // 60
            addColumn(mainTable, "Design_Service_Fashion_Name_SEARS");                     // 61
            addColumn(mainTable, "Design_Service_Fashion_Name_STAPLES_CA");                // 62
            addColumn(mainTable, "Design_Service_Fashion_Name_WALMART");                   // 63
            addColumn(mainTable, "SKU_SEARS");                                             // 64
            addColumn(mainTable, "SKU_TSC_CA");                                            // 65
            addColumn(mainTable, "SKU_COSTCO_CA");                                         // 66
            addColumn(mainTable, "SKU_BESTBUY_CA");                                        // 67
            addColumn(mainTable, "SKU_AMAZON_CA");                                         // 68
            addColumn(mainTable, "SKU_AMAZON_COM");                                        // 69
            addColumn(mainTable, "SKU_SHOP_CA");                                           // 70 
            addColumn(mainTable, "SKU_STAPLES_CA");                                        // 71
            addColumn(mainTable, "SKU_WALMART_CA");                                        // 72
            addColumn(mainTable, "SKU_WALMART_COM");                                       // 73
            addColumn(mainTable, "SKU_DistributorCentral");                                // 74
            addColumn(mainTable, "SKU_PromoMarketing");                                    // 75
            addColumn(mainTable, "SKU_MAGENTO");                                           // 76
            addColumn(mainTable, "Option_1");                                              // 77
            addColumn(mainTable, "Option_2");                                              // 78
            addColumn(mainTable, "Option_3");                                              // 79
            addColumn(mainTable, "Option_4");                                              // 80
            addColumn(mainTable, "Option_5");                                              // 81
            addColumn(mainTable, "Option_1_FR");                                           // 82
            addColumn(mainTable, "Option_2_FR");                                           // 83
            addColumn(mainTable, "Option_3_FR");                                           // 84
            addColumn(mainTable, "Option_4_FR");                                           // 85
            addColumn(mainTable, "Option_5_FR");                                           // 86
            addColumn(mainTable, "UPC_Code_9");                                            // 87
            addColumn(mainTable, "UPC_Code_10");                                           // 88
            addColumn(mainTable, "Base_Price");                                            // 89
            addColumn(mainTable, "Components");                                            // 90
            addColumn(mainTable, "MSRP");                                                  // 91
            addColumn(mainTable, "Run_Charges");                                           // 92
            addColumn(mainTable, "Price_1_C");                                             // 93
            addColumn(mainTable, "Price_6_C");                                             // 94
            addColumn(mainTable, "Price_24_C");                                            // 95
            addColumn(mainTable, "Price_50_C");                                            // 96
            addColumn(mainTable, "Price_100_C");                                           // 97
            addColumn(mainTable, "Price_250_C");                                           // 98
            addColumn(mainTable, "Price_500_C");                                           // 99
            addColumn(mainTable, "Price_1000_C");                                          // 100
            addColumn(mainTable, "Price_2500_C");                                          // 101
            addColumn(mainTable, "Price_RUSH_1_C");                                        // 102
            addColumn(mainTable, "Price_RUSH_6_C");                                        // 103
            addColumn(mainTable, "Price_RUSH_24_C");                                       // 104
            addColumn(mainTable, "Price_RUSH_50_C");                                       // 105
            addColumn(mainTable, "Price_RUSH_100_C");                                      // 106
            addColumn(mainTable, "Price_RUSH_250_C");                                      // 107
            addColumn(mainTable, "Price_RUSH_500_C");                                      // 108
            addColumn(mainTable, "Price_RUSH_1000_C");                                     // 109
            addColumn(mainTable, "Price_RUSH_2500_C");                                     // 110
            addColumn(mainTable, "Run_Charge_1_C");                                        // 111
            addColumn(mainTable, "Run_Charge_6_C");                                        // 112
            addColumn(mainTable, "Run_Charge_24_C");                                       // 113
            addColumn(mainTable, "Run_Charge_50_C");                                       // 114
            addColumn(mainTable, "Run_Charge_100_C");                                      // 115
            addColumn(mainTable, "Run_Charge_250_C");                                      // 116
            addColumn(mainTable, "Run_Charge_500_C");                                      // 117
            addColumn(mainTable, "Run_Charge_1000_C");                                     // 118
            addColumn(mainTable, "Run_Charge_2500_C");                                     // 119
            addColumn(mainTable, "Run_Charge_RUSH_1_C");                                   // 120
            addColumn(mainTable, "Run_Charge_RUSH_6_C");                                   // 121
            addColumn(mainTable, "Run_Charge_RUSH_24_C");                                  // 122
            addColumn(mainTable, "Run_Charge_RUSH_50_C");                                  // 123
            addColumn(mainTable, "Run_Charge_RUSH_100_C");                                 // 124
            addColumn(mainTable, "Run_Charge_RUSH_250_C");                                 // 125
            addColumn(mainTable, "Run_Charge_RUSH_500_C");                                 // 126
            addColumn(mainTable, "Run_Charge_RUSH_1000_C");                                // 127
            addColumn(mainTable, "Run_Charge_RUSH_2500_C");                                // 128
            addColumn(mainTable, "Price_1_Net");                                           // 129
            addColumn(mainTable, "Price_6_Net");                                           // 130
            addColumn(mainTable, "Price_24_Net");                                          // 131
            addColumn(mainTable, "Price_50_Net");                                          // 132
            addColumn(mainTable, "Price_100_Net");                                         // 133
            addColumn(mainTable, "Price_250_Net");                                         // 134
            addColumn(mainTable, "Price_500_Net");                                         // 135
            addColumn(mainTable, "Price_1000_Net");                                        // 136
            addColumn(mainTable, "Price_2500_Net");                                        // 137
            addColumn(mainTable, "Price_RUSH_1_Net");                                      // 138
            addColumn(mainTable, "Price_RUSH_6_Net");                                      // 139
            addColumn(mainTable, "Price_RUSH_24_Net");                                     // 140
            addColumn(mainTable, "Price_RUSH_50_Net");                                     // 141
            addColumn(mainTable, "Price_RUSH_100_Net");                                    // 142
            addColumn(mainTable, "Price_RUSH_250_Net");                                    // 143
            addColumn(mainTable, "Price_RUSH_500_Net");                                    // 144
            addColumn(mainTable, "Price_RUSH_1000_Net");                                   // 145
            addColumn(mainTable, "Price_RUSH_2500_Net");                                   // 146
            addColumn(mainTable, "Run_Charge_1_Net");                                      // 147
            addColumn(mainTable, "Run_Charge_6_Net");                                      // 148
            addColumn(mainTable, "Run_Charge_24_Net");                                     // 149
            addColumn(mainTable, "Run_Charge_50_Net");                                     // 150
            addColumn(mainTable, "Run_Charge_100_Net");                                    // 151
            addColumn(mainTable, "Run_Charge_250_Net");                                    // 152
            addColumn(mainTable, "Run_Charge_500_Net");                                    // 153
            addColumn(mainTable, "Run_Charge_1000_Net");                                   // 154
            addColumn(mainTable, "Run_Charge_2500_Net");                                   // 155
            addColumn(mainTable, "Run_Charge_RUSH_1_Net");                                 // 156
            addColumn(mainTable, "Run_Charge_RUSH_6_Net");                                 // 157
            addColumn(mainTable, "Run_Charge_RUSH_24_Net");                                // 158
            addColumn(mainTable, "Run_Charge_RUSH_50_Net");                                // 159
            addColumn(mainTable, "Run_Charge_RUSH_100_Net");                               // 160
            addColumn(mainTable, "Run_Charge_RUSH_250_Net");                               // 161
            addColumn(mainTable, "Run_Charge_RUSH_500_Net");                               // 162
            addColumn(mainTable, "Run_Charge_RUSH_1000_Net");                              // 163
            addColumn(mainTable, "Run_Charge_RUSH_2500_Net");                              // 164
            addColumn(mainTable, "Location_WH");                                           // 165
            addColumn(mainTable, "Location_Shelf");                                        // 166
            addColumn(mainTable, "Location_Rack");                                         // 167
            addColumn(mainTable, "Location_ColIndex");                                     // 168  
            addColumn(mainTable, "Location_Full");                                         // 169
            addColumn(mainTable, "Image_1_Path");                                          // 170
            addColumn(mainTable, "Image_2_Path");                                          // 171
            addColumn(mainTable, "Image_3_Path");                                          // 172
            addColumn(mainTable, "Image_4_Path");                                          // 173
            addColumn(mainTable, "Image_5_Path");                                          // 174  
            addColumn(mainTable, "Image_6_Path");                                          // 175
            addColumn(mainTable, "Image_7_Path");                                          // 176
            addColumn(mainTable, "Image_8_Path");                                          // 177
            addColumn(mainTable, "Image_9_Path");                                          // 178
            addColumn(mainTable, "Image_10_Path");                                         // 179
            addColumn(mainTable, "Image_Group_1_Path");                                    // 180
            addColumn(mainTable, "Image_Group_2_Path");                                    // 181
            addColumn(mainTable, "Image_Group_3_Path");                                    // 182
            addColumn(mainTable, "Image_Group_4_Path");                                    // 183
            addColumn(mainTable, "Image_Group_5_Path");                                    // 184
            addColumn(mainTable, "Image_Model_1_Path");                                    // 185
            addColumn(mainTable, "Image_Model_2_Path");                                    // 186
            addColumn(mainTable, "Image_Model_3_Path");                                    // 187
            addColumn(mainTable, "Image_Model_4_Path");                                    // 188
            addColumn(mainTable, "Image_Model_5_Path");                                    // 189
            addColumn(mainTable, "Swatch_Material_Colour_Path");                           // 190
            addColumn(mainTable, "Swatch_Colour_Path");                                    // 191
            addColumn(mainTable, "Flat_Shippable");                                        // 192
            addColumn(mainTable, "Website_Flag");                                          // 193
            addColumn(mainTable, "Alt_Text_Image_1_Path");                                 // 194
            addColumn(mainTable, "Alt_Text_Image_2_Path");                                 // 195
            addColumn(mainTable, "Alt_Text_Image_3_Path");                                 // 196
            addColumn(mainTable, "Alt_Text_Image_4_Path");                                 // 197
            addColumn(mainTable, "Alt_Text_Image_5_Path");                                 // 198
            addColumn(mainTable, "Alt_Text_Image_6_Path");                                 // 199
            addColumn(mainTable, "Alt_Text_Image_7_Path");                                 // 200
            addColumn(mainTable, "Alt_Text_Image_8_Path");                                 // 201
            addColumn(mainTable, "Alt_Text_Image_9_Path");                                 // 202
            addColumn(mainTable, "Alt_Text_Image_10_Path");                                // 203
            addColumn(mainTable, "Alt_Text_Group_1_Path");                                 // 204
            addColumn(mainTable, "Alt_Text_Group_2_Path");                                 // 205
            addColumn(mainTable, "Alt_Text_Group_3_Path");                                 // 206
            addColumn(mainTable, "Alt_Text_Group_4_Path");                                 // 207
            addColumn(mainTable, "Alt_Text_Group_5_Path");                                 // 208
            addColumn(mainTable, "Alt_Text_Model_1_Path");                                 // 209
            addColumn(mainTable, "Alt_Text_Model_2_Path");                                 // 210
            addColumn(mainTable, "Alt_Text_Model_3_Path");                                 // 211
            addColumn(mainTable, "Alt_Text_Model_4_Path");                                 // 212
            addColumn(mainTable, "Alt_Text_Model_5_Path");                                 // 213

            // local field for inserting data to table
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = "Ashlin®";                                                 // brand
                row[1] = "Ashlin® is a boutique quality brand, featuring elegant leathergoods for your fashion needs";         // brand description
                row[2] = sku;                                                       // sku ashlin
                row[3] = list[0];                                                   // design service code
                row[4] = list[1];                                                   // material code
                row[5] = list[3];                                                   // material description short
                row[6] = list[4];                                                   // material description extended
                row[7] = list[5];                                                   // material description short fr
                row[8] = list[6];                                                   // material description extended fr
                row[9] = list[2];                                                   // color code
                row[10] = list[7];                                                  // colour description short
                row[11] = list[8];                                                  // color description extended
                row[12] = list[9];                                                  // color description short fr
                row[13] = list[10];                                                 // color description extended fr
                row[14] = list[11];                                                 // design service flag
                row[15] = list[12];                                                 // design service family code
                row[16] = list[54];                                                 // design service family description
                row[17] = list[55];                                                 // design service family description fr
                row[18] = list[56];                                                 // design service family keywords general                                                                                                                                    
                row[19] = list[57];                                                 // design service family category sage
                row[20] = list[58];                                                 // design service family category esp
                row[21] = list[59];                                                 // design service family category promo marketing
                row[22] = list[60];                                                 // design service family category uducat
                row[23] = list[61];                                                 // design service family category distributor central
                row[24] = list[62];                                                 // design service family themes sage
                row[25] = list[13];                                                 // design short description
                row[26] = list[14];                                                 // design extended description
                row[27] = list[15];                                                 // design short description fr
                row[28] = list[16];                                                 // design extended description fr
                row[29] = list[17];                                                 // imprintable
                row[30] = list[18];                                                 // imprint height cm
                row[31] = list[19];                                                 // imprint width cm
                row[32] = list[20];                                                 // depth cm
                row[33] = list[21];                                                 // width cm
                row[34] = list[22];                                                 // height cm
                if (!list[18].Equals(DBNull.Value))
                {
                    row[35] = Math.Round(Convert.ToDouble(list[18]) / 2.54, 2);     // imprint height in
                    row[36] = Math.Round(Convert.ToDouble(list[19]) / 2.54, 2);     // imprint width in
                }
                if (!list[20].Equals(DBNull.Value))
                {
                    row[37] = Math.Round(Convert.ToDouble(list[20]) / 2.54, 2);     // depth in
                    row[38] = Math.Round(Convert.ToDouble(list[21]) / 2.54, 2);     // width in
                    row[39] = Math.Round(Convert.ToDouble(list[22]) / 2.54, 2);     // height in
                }
                row[40] = list[23];                                                 // weight grams
                if (!list[23].Equals(DBNull.Value))
                {
                    row[41] = Math.Round(Convert.ToDouble(list[23]) / 453.592, 2);  // weight pounds
                }
                row[42] = list[24];                                                 // shippable width cm  
                row[43] = list[25];                                                 // shippable height cm
                row[44] = list[26];                                                 // shippable depth cm
                if (!list[24].Equals(DBNull.Value) && !list[26].Equals(DBNull.Value))
                {
                    row[45] = Math.Round(Convert.ToDouble(list[24]) / 2.54, 2);     // shippable width in
                    row[46] = Math.Round(Convert.ToDouble(list[25]) / 2.54, 2);     // shippable height in
                    row[47] = Math.Round(Convert.ToDouble(list[26]) / 2.54, 2);     // shippable depth in
                }
                row[48] = list[27];                                                 // shippable weight grams
                if (!list[27].Equals(DBNull.Value))
                {
                    row[49] = Math.Round(Convert.ToDouble(list[27]) / 453.592, 2);  // shippable weight lb
                }
                row[50] = list[28];                                                 // strap
                row[51] = list[29];                                                 // detachable strap
                row[52] = list[30];                                                 // zipped enclosure
                row[53] = list[31];                                                 // design service fashion name ashlin
                row[54] = list[32];                                                 // design service fashion name tsc
                row[55] = list[33];                                                 // design service fashion name costco
                row[56] = list[34];                                                 // design service fashion name bestbuy
                row[57] = list[35];                                                 // design service fashion name shop ca
                row[58] = list[36];                                                 // design service fashion name amazon ca
                row[59] = list[37];                                                 // design service fashion name amazon com
                row[60] = list[38];                                                 // design service fashion name sears
                row[61] = list[39];                                                 // design service fashion name staples
                row[62] = list[40];                                                 // design service fashion name walmart
                row[63] = list[63];                                                 // sears
                row[64] = list[64];                                                 // sku tsc
                row[65] = list[65];                                                 // sku costco 
                row[66] = list[66];                                                 // sku bestbuy
                row[67] = list[67];                                                 // sku amazon ca
                row[68] = list[68];                                                 // sku amazon com
                row[69] = list[69];                                                 // sku shop ca
                row[70] = list[70];                                                 // sku staples ca
                row[71] = list[71];                                                 // sku walmart ca
                row[72] = list[72];                                                 // sku walmart com
                row[73] = list[73];                                                 // sku distributor central
                row[74] = list[74];                                                 // sku promo marketing
                row[75] = list[75];                                                 // sku magento
                row[76] = list[41];                                                 // option 1
                row[77] = list[42];                                                 // option 2
                row[78] = list[43];                                                 // option 3
                row[79] = list[44];                                                 // option 4
                row[80] = list[45];                                                 // option 5
                row[81] = list[46];                                                 // option 1 fr
                row[82] = list[47];                                                 // option 2 fr
                row[83] = list[48];                                                 // option 3 fr
                row[84] = list[49];                                                 // option 4 fr
                row[85] = list[50];                                                 // option 5 fr
                row[86] = list[76];                                                 // upc code 9
                row[87] = list[77];                                                 // upc code 10
                double basePrice = Convert.ToDouble(list[78]);
                row[88] = basePrice;                                                // base price
                row[89] = list[51];                                                 // components
                double msrp = discountList[21] * basePrice;
                row[90] = msrp;                                                     // msrp
                double runCharge;
                if (!list[51].Equals(DBNull.Value))
                    runCharge = Math.Round(msrp*0.05)/0.6 + Convert.ToInt32(list[51]) - 1;
                else
                    runCharge = Math.Round(msrp*0.05)/0.6;
                if (runCharge > 8)
                    row[91] = 8;
                else if (runCharge < 1)
                    row[91] = 1;
                else
                    row[91] = runCharge; // run charge
                row[92] = msrp * discountList[1];                                   // price 1 c
                row[93] = msrp * discountList[2];                                   // price 6 c        
                row[94] = msrp * discountList[3];                                   // price 24 c
                row[95] = msrp * discountList[4];                                   // price 50 c
                row[96] = msrp * discountList[5];                                   // price 100 c
                row[97] = msrp * discountList[6];                                   // price 250 c
                row[98] = msrp * discountList[7];                                   // price 500 c
                row[99] = msrp * discountList[8];                                   // price 1000 c
                row[100] = msrp * discountList[9];                                  // price 2500 c
                row[101] = msrp * discountList[0] * discountList[1];                // price rush 1 c
                row[102] = msrp * discountList[0] * discountList[2];                // price rush 6 c
                row[103] = msrp * discountList[0] * discountList[3];                // price rush 24 c
                row[104] = msrp * discountList[0] * discountList[4];                // price rush 50 c
                row[105] = msrp * discountList[0] * discountList[5];                // price rush 100 c
                row[106] = msrp * discountList[0] * discountList[6];                // price rush 250 c
                row[107] = msrp * discountList[0] * discountList[7];                // price rush 500 c
                row[108] = msrp * discountList[0] * discountList[8];                // price rush 1000 c
                row[109] = msrp * discountList[0] * discountList[9];                // price rush 2500 c
                row[110] = runCharge * discountList[1];                             // run charge 1 c
                row[111] = runCharge * discountList[2];                             // run charge 6 c
                row[112] = runCharge * discountList[3];                             // run charge 24 c 
                row[113] = runCharge * discountList[4];                             // run charge 50 c
                row[114] = runCharge * discountList[5];                             // run charge 100 c
                row[115] = runCharge * discountList[6];                             // run charge 250 c
                row[116] = runCharge * discountList[7];                             // run charge 500 c
                row[117] = runCharge * discountList[8];                             // run charge 1000 c
                row[118] = runCharge * discountList[9];                             // run charge 2500 c
                row[119] = runCharge * discountList[0] * discountList[1];           // run charge rush 1 c
                row[120] = runCharge * discountList[0] * discountList[2];           // run charge rush 6 c
                row[121] = runCharge * discountList[0] * discountList[3];           // run charge rush 24 c
                row[122] = runCharge * discountList[0] * discountList[4];           // run charge rush 50 c
                row[123] = runCharge * discountList[0] * discountList[5];           // run charge rush 100 c
                row[124] = runCharge * discountList[0] * discountList[6];           // run charge rush 250 c
                row[125] = runCharge * discountList[0] * discountList[7];           // run charge rush 500 c
                row[126] = runCharge * discountList[0] * discountList[8];           // run charge rush 1000 c
                row[127] = runCharge * discountList[0] * discountList[9];           // run charge rush 2500 c
                row[128] = msrp * discountList[11];                                 // price 1 net
                row[129] = msrp * discountList[12];                                 // price 6 net
                row[130] = msrp * discountList[13];                                 // price 24 net
                row[131] = msrp * discountList[14];                                 // price 50 net
                row[132] = msrp * discountList[15];                                 // price 100 net
                row[133] = msrp * discountList[16];                                 // price 250 net
                row[134] = msrp * discountList[17];                                 // price 500 net
                row[135] = msrp * discountList[18];                                 // price 1000 net
                row[136] = msrp * discountList[19];                                 // price 2500 net
                row[137] = msrp * discountList[10] * discountList[11];              // price rush 1 net
                row[138] = msrp * discountList[10] * discountList[12];              // price rush 6 net
                row[139] = msrp * discountList[10] * discountList[13];              // price rush 24 net
                row[140] = msrp * discountList[10] * discountList[14];              // price rush 50 net
                row[141] = msrp * discountList[10] * discountList[15];              // price rush 100 net
                row[142] = msrp * discountList[10] * discountList[16];              // price rush 250 net
                row[143] = msrp * discountList[10] * discountList[17];              // price rush 500 net
                row[144] = msrp * discountList[10] * discountList[18];              // price rush 1000 net
                row[145] = msrp * discountList[10] * discountList[19];              // price rush 2500 net
                row[146] = runCharge * discountList[11];                            // run charge 1 net
                row[147] = runCharge * discountList[12];                            // run charge 6 net
                row[148] = runCharge * discountList[13];                            // run charge 24 net
                row[149] = runCharge * discountList[14];                            // run charge 50 net
                row[150] = runCharge * discountList[15];                            // run charge 100 net
                row[151] = runCharge * discountList[16];                            // run charge 250 net
                row[152] = runCharge * discountList[17];                            // run charge 500 net 
                row[153] = runCharge * discountList[18];                            // run charge 1000 net
                row[154] = runCharge * discountList[19];                            // run charge 2500 net
                row[155] = runCharge * discountList[10] * discountList[11];         // run charge rush 1 net
                row[156] = runCharge * discountList[10] * discountList[12];         // run charge rush 6 net
                row[157] = runCharge * discountList[10] * discountList[13];         // run charge rush 24 net
                row[158] = runCharge * discountList[10] * discountList[14];         // run charge rush 50 net
                row[159] = runCharge * discountList[10] * discountList[15];         // run charge rush 100 net
                row[160] = runCharge * discountList[10] * discountList[16];         // run charge rush 250 net
                row[161] = runCharge * discountList[10] * discountList[17];         // run charge rush 500 net
                row[162] = runCharge * discountList[10] * discountList[18];         // run charge rush 1000 net
                row[163] = runCharge * discountList[10] * discountList[19];         // run charge rush 2500 net
                row[164] = list[79];                                                // location wh
                row[165] = list[80];                                                // location shelf
                row[166] = list[81];                                                // location rack
                row[167] = list[82];                                                // location cloindex
                row[168] = list[83];                                                // location full
                row[169] = list[84];                                                // image 1 path
                row[170] = list[85];                                                // image 2 path
                row[171] = list[86];                                                // image 3 path
                row[172] = list[87];                                                // image 4 path
                row[173] = list[88];                                                // image 5 path
                row[174] = list[89];                                                // image 6 path
                row[175] = list[90];                                                // image 7 path
                row[176] = list[91];                                                // image 8 path
                row[177] = list[92];                                                // image 9 path
                row[178] = list[93];                                                // image 10 path
                row[179] = list[94];                                                // image group 1 path
                row[180] = list[95];                                                // image group 2 path
                row[181] = list[96];                                                // image group 3 path
                row[182] = list[97];                                                // image group 4 path
                row[183] = list[98];                                                // image group 5 path
                row[184] = list[99];                                                // image model 1 path   
                row[185] = list[100];                                               // image model 2 path
                row[186] = list[101];                                               // image model 3 path
                row[187] = list[102];                                               // image model 4 path
                row[188] = list[103];                                               // image model 5 path
                row[189] = getSwatch(sku);                                          // swatch material colour path
                row[190] = "";                                                      // swatch colour path
                row[191] = list[52];                                                // flat shippable
                row[192] = list[53];                                                // website flag
                row[193] = list[104];                                               // alt text image 1 path
                row[194] = list[105];                                               // alt text image 2 path
                row[195] = list[106];                                               // alt text image 3 path
                row[196] = list[107];                                               // alt text image 4 path
                row[197] = list[108];                                               // alt text image 5 path
                row[198] = list[109];                                               // alt text image 6 path
                row[199] = list[110];                                               // alt text image 7 path
                row[200] = list[111];                                               // alt text image 8 path
                row[201] = list[112];                                               // alt text image 9 path
                row[202] = list[113];                                               // alt text image 10 path
                row[203] = list[114];                                               // alt text image group 1 path
                row[204] = list[115];                                               // alt text image group 2 path
                row[205] = list[116];                                               // alt text image group 3 path
                row[206] = list[117];                                               // alt text image group 4 path
                row[207] = list[118];                                               // alt text image group 5 path
                row[208] = list[119];                                               // alt text image model 1 path
                row[209] = list[120];                                               // alt text image model 2 path
                row[210] = list[121];                                               // alt text image model 3 path
                row[211] = list[122];                                               // alt text image model 4 path
                row[212] = list[123];                                               // alt text image model 5 path

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            //return list;
            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // [0] design, [1] material, [2] color;
            list.Add(design); list.Add(material); list.Add(color);

            // grab data from database
            // [3] material description short, [4] material description extended, [5] material description short fr, [6] material description extended fr 
            // [7] colour description short, [8] colour description extended, [9] colour description short fr, [10] colour description extended fr
            // [11] design service flag, [12] design service family code, [13] design short description, [14] design extended description, [15] design short description fr, [16] design extended description fr, [17] imprintable, [18] imprint height cm, [19] imprint width cm, [20] depth cm, [21] width cm, [22] height cm, [23] weight grams. [24] shippable width cm, [25] shippable height cm, [26] shippable depth cm, [27] shippable weight grams, [28] strap, [29] detachable strap, [30] zipped enclosure, [31] design service fashion name ashlin, [32] design service fashion name tsc, [33] design service fashion name costco, [34] design service fashion name bestbuy, [35] design service fashion name shop ca, [36] design service fashion name amazon ca, [37] design service fashion name amazon com, [38] design service fashion name sears, [39] design service fashion name staples, [40] design service fashion name walmart, [41] option 1, [42] option 2, [43] option 3, [44] option 4, [45] option 5, [46] option 1 fr, [47] option 2 fr, [48] option 3 fr, [49] option 4 fr, [50] option 5 fr, [51] components, [52] flat shippable, [53] website flag
            // [54] design servie family description, [55] design service family description fr, [56] design service family keywords general, [57] design service family category sage, [58] design service family category esp, [59] design service family category promomarketing, [60] design service family category uducat, [61] design service family distributocentral, [62] design service family themes sage                                                                                                                                                                                                                  & imprint height in     & imprint width in     & depth in     & width in     & height in     & weight pounds    & shippable width in     & shippable height in     & shippable depth in     & shippalbe weight lb
            // [63] sku sears, [64] sku tsc, [65] sku costco, [66] sku bestbuy, [67] sku amazon ca, [68] sku amazon com, [69] sku shop ca, [70] sku staples ca, [71] sku walmart ca, [72] walmart com, [73] sku distributorcentral, [74] sku promomarketing, [75] sku magento, [76] upc code 9, [77] upc code 10, [78] all columns related to price, [79] location wh, [80] location shelf, [81] location rack, [82] location colindex, [83] location full, [84] ~ [93] image path, [94] ~ [98] group path, [99] ~ [103] model path, [104] ~ [113] alt text image path, [114] ~ [118] alt text image group path, [119] ~ [123] alt text image model path
            SqlCommand commnad = new SqlCommand("SELECT Material_Description_Short, Material_Description_Extended, Material_Description_Short_FR, Material_Description_Extended_FR, " +
                                                "Colour_Description_Short, Colour_Description_Extended, Colour_Description_Short_FR, Colour_Description_Extended_FR, " +
                                                "Design_Service_Flag, design.Design_Service_Family_Code, Short_Description, Extended_Description, Short_Description_FR, Extended_Description_FR, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Depth_cm, Width_cm, Height_cm, Weight_grams, Shippable_Width_cm, Shippable_Height_cm, Shippable_Depth_cm, Shippable_weight_grams, Strap, Detachable_Strap, Zippered_Enclosure, Design_Service_Fashion_Name_Ashlin, Design_Service_Fashion_Name_TSC_CA, Design_Service_Fashion_Name_COSTCO_CA, Design_Service_Fashion_Name_BESTBUY_CA, Design_Service_Fashion_Name_SHOP_CA, Design_Service_Fashion_Name_AMAZON_CA, Design_Service_Fashion_Name_AMAZON_COM, Design_Service_Fashion_Name_SEARS_CA, Design_Service_Fashion_Name_STAPLES_CA, Design_Service_Fashion_Name_WALMART, Option_1, Option_2, Option_3, Option_4, Option_5, Option_1_FR, Option_2_FR, Option_3_FR, Option_4_FR, Option_5_FR, Components, Flat_Shippable, Website_Flag, " +
                                                "Design_Service_Family_Description, Design_Service_Family_Description_FR, Design_Service_Family_KeyWords_General, Design_Service_Family_Category_Sage, Design_Service_Family_Category_ESP, Design_Service_Family_Category_PromoMarketing, Design_Service_Family_Category_UDUCAT, Design_Service_Family_Category_DistributorCentral, Design_Service_Family_Themes_Sage, " +
                                                "SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_SHOP_CA, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_WALMART_COM, SKU_DistributorCentral, SKU_PromoMarketing, SKU_MAGENTO, UPC_Code_9, UPC_Code_10, Base_Price, Location_WH, Location_Shelf, Location_Rack, Location_ColIndex, Location_Full, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 120; i++)
                list.Add(reader.GetValue(i)); 

            return list;
        }

        /* method that add swatch image url */
        private static string getSwatch(string sku)
        {
            // get material + color code
            string node = sku.Substring(sku.IndexOf('-'));

            return "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/1_WEB_SWATCHES/" + node + ".jpg";
        }

        /* a method that return the discount matrix */
        private double[] getDiscount()
        {
            double[] list = new double[22];

            // [0] rush standard, [1] 1 c standard, [2] 6 c standard, [3] 24 c standard, [4] 50 c standard, [5] 100 c standard, [6] 250 c standard, [7] 500 c standard, [8] 1000 c standard, [9] 2500 c standard, [10] rush net, [11] 1 c net standard
            // [12] 6 c net standard, [13] 24 c net standard, [14] 50 c net standard, [15] 100 net standard, [16] 250 net standard, [17] 500 net standard, [18] 1000 net standard, [19] 2500 net standard, [20] wholesale net
            SqlCommand command = new SqlCommand("SELECT [RUSH_C_25_wks], [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_Net_25_wks], [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], [Wholesale_Net] FROM ref_discount_matrix", connection);         
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 20; i++)
                list[i] = reader.GetDouble(i);
            reader.Close();

            // [21] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[21] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
