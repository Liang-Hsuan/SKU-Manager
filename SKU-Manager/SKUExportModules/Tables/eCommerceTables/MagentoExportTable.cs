using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables
{
    /*
     * A class that return magento export table
     */
    public class MagentoExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public MagentoExportTable()
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
            AddColumn(MainTable, "SKU Ashlin");                              // 1
            AddColumn(MainTable, "Design Service Code");                     // 2
            AddColumn(MainTable, "Design_Service_Fashion_Name_Ashlin");      // 3
            AddColumn(MainTable, "Design Short Description");                // 4
            AddColumn(MainTable, "Design Extended Description");             // 5
            AddColumn(MainTable, "Material Code");                           // 6
            AddColumn(MainTable, "Colour Code");                             // 7
            AddColumn(MainTable, "Colour Material Code");                    // 8
            AddColumn(MainTable, "Material Description Extended");           // 9
            AddColumn(MainTable, "Colour Description Extended");             // 10
            AddColumn(MainTable, "Design Service Family Description");       // 11
            AddColumn(MainTable, "Option 1");                                // 12
            AddColumn(MainTable, "Option 2");                                // 13
            AddColumn(MainTable, "Option 3");                                // 14
            AddColumn(MainTable, "Option 4");                                // 15
            AddColumn(MainTable, "Option 5");                                // 16
            AddColumn(MainTable, "Strap");                                   // 17
            AddColumn(MainTable, "Detachable Strap");                        // 18
            AddColumn(MainTable, "Zuooered Enclosure");                      // 19
            AddColumn(MainTable, "Shippable weight grams");                  // 20
            AddColumn(MainTable, "Shippable weight lb");                     // 21
            AddColumn(MainTable, "Imprintable");                             // 22
            AddColumn(MainTable, "Imprint Area cm");                         // 23
            AddColumn(MainTable, "Imprint Area in");                         // 24
            AddColumn(MainTable, "Finished Dimensions (cm)");                // 25
            AddColumn(MainTable, "Finished Dimensions (in)");                // 26
            AddColumn(MainTable, "price 1 c blank");                         // 27
            AddColumn(MainTable, "price 6 c blank");                         // 28
            AddColumn(MainTable, "price 24 c blank");                        // 29
            AddColumn(MainTable, "price 50 c blank");                        // 30
            AddColumn(MainTable, "price 100 c blank");                       // 31
            AddColumn(MainTable, "price 250 c blank");                       // 32
            AddColumn(MainTable, "price 500 c blank");                       // 33
            AddColumn(MainTable, "price 1000 c blank");                      // 34
            AddColumn(MainTable, "price 2500 c blank");                      // 35
            AddColumn(MainTable, "price 1 c im");                            // 36
            AddColumn(MainTable, "price 6 c im");                            // 37
            AddColumn(MainTable, "price 24 c im");                           // 38
            AddColumn(MainTable, "price 50 c im");                           // 39
            AddColumn(MainTable, "price 100 c im");                          // 40   
            AddColumn(MainTable, "price 250 c im");                          // 41
            AddColumn(MainTable, "price 500 c im");                          // 42
            AddColumn(MainTable, "price 1000 c im");                         // 43
            AddColumn(MainTable, "price 2500 c im");                         // 44
            AddColumn(MainTable, "price 1 net blank");                       // 45
            AddColumn(MainTable, "price 6 net blank");                       // 46
            AddColumn(MainTable, "price 24 net blank");                      // 47
            AddColumn(MainTable, "price 50 net blank");                      // 48
            AddColumn(MainTable, "price 100 net blank");                     // 49
            AddColumn(MainTable, "price 250 net blank");                     // 50
            AddColumn(MainTable, "price 500 net blank");                     // 51
            AddColumn(MainTable, "price 1000 net blank");                    // 52
            AddColumn(MainTable, "price 2500 net blank");                    // 53
            AddColumn(MainTable, "price 1 net im");                          // 54
            AddColumn(MainTable, "price 6 net im");                          // 55
            AddColumn(MainTable, "price 24 net im");                         // 56
            AddColumn(MainTable, "price 50 net im");                         // 57
            AddColumn(MainTable, "price 100 net im");                        // 58
            AddColumn(MainTable, "price 250 net im");                        // 59
            AddColumn(MainTable, "price 500 net im");                        // 60
            AddColumn(MainTable, "price 1000 net im");                       // 61
            AddColumn(MainTable, "price 2500 net im");                       // 62
            AddColumn(MainTable, "price rush 1 c blank");                    // 63
            AddColumn(MainTable, "price rush 6 c blank");                    // 64
            AddColumn(MainTable, "price rush 24 c blank");                   // 65
            AddColumn(MainTable, "price rush 50 c blank");                   // 66
            AddColumn(MainTable, "price rush 100 c blank");                  // 67
            AddColumn(MainTable, "price rush 250 c blank");                  // 68
            AddColumn(MainTable, "price rush 500 c blank");                  // 69
            AddColumn(MainTable, "price rush 1000 c blank");                 // 70
            AddColumn(MainTable, "price rush 2500 c blank");                 // 71
            AddColumn(MainTable, "price rush 1 c im");                       // 72
            AddColumn(MainTable, "price rush 6 c im");                       // 73
            AddColumn(MainTable, "price rush 24 c im");                      // 74
            AddColumn(MainTable, "price rush 50 c im");                      // 75   
            AddColumn(MainTable, "price rush 100 c im");                     // 76
            AddColumn(MainTable, "price rush 250 c im");                     // 77
            AddColumn(MainTable, "price rush 500 c im");                     // 78
            AddColumn(MainTable, "price rush 1000 c im");                    // 79
            AddColumn(MainTable, "price rush 2500 c im");                    // 80
            AddColumn(MainTable, "price rush 1 net blank");                  // 81
            AddColumn(MainTable, "price rush 6 net blank");                  // 82
            AddColumn(MainTable, "price rush 24 net blank");                 // 83
            AddColumn(MainTable, "price rush 50 net blank");                 // 84
            AddColumn(MainTable, "price rush 100 net blank");                // 85
            AddColumn(MainTable, "price rush 250 net blank");                // 86
            AddColumn(MainTable, "price rush 500 net blank");                // 87
            AddColumn(MainTable, "price rush 1000 net blank");               // 88
            AddColumn(MainTable, "price rush 2500 net blank");               // 89
            AddColumn(MainTable, "price rush 1 net im");                     // 90
            AddColumn(MainTable, "price rush 6 net im");                     // 91
            AddColumn(MainTable, "price rush 24 net im");                    // 92
            AddColumn(MainTable, "price rush 50 net im");                    // 93
            AddColumn(MainTable, "price rush 100 net im");                   // 94
            AddColumn(MainTable, "price rush 250 net im");                   // 95
            AddColumn(MainTable, "price rush 500 net im");                   // 96
            AddColumn(MainTable, "price rush 1000 net im");                  // 97
            AddColumn(MainTable, "price rush 2500 net im");                  // 98
            AddColumn(MainTable, "image 1 path");                            // 99
            AddColumn(MainTable, "image 2 path");                            // 100
            AddColumn(MainTable, "image 3 path");                            // 101
            AddColumn(MainTable, "image 4 path");                            // 102
            AddColumn(MainTable, "image 5 path");                            // 103
            AddColumn(MainTable, "image 6 path");                            // 104
            AddColumn(MainTable, "image 7 path");                            // 105
            AddColumn(MainTable, "image 8 path");                            // 106
            AddColumn(MainTable, "image 9 path");                            // 107
            AddColumn(MainTable, "image 10 path");                           // 108
            AddColumn(MainTable, "image group 1 path");                      // 109
            AddColumn(MainTable, "image group 2 path");                      // 110
            AddColumn(MainTable, "image group 3 path");                      // 111
            AddColumn(MainTable, "image group 4 path");                      // 112
            AddColumn(MainTable, "image group 5 path");                      // 113
            AddColumn(MainTable, "image model 1 path");                      // 114
            AddColumn(MainTable, "image model 2 path");                      // 115
            AddColumn(MainTable, "image model 3 path");                      // 116
            AddColumn(MainTable, "image model 4 path");                      // 117
            AddColumn(MainTable, "image model 5 path");                      // 118
            AddColumn(MainTable, "Swatch Path");                             // 119
            AddColumn(MainTable, "Alt Text Image 1 Path");                   // 120
            AddColumn(MainTable, "Alt Text Image 2 Path");                   // 121  
            AddColumn(MainTable, "Alt Text Image 3 Path");                   // 122
            AddColumn(MainTable, "Alt Text Image 4 Path");                   // 123
            AddColumn(MainTable, "Alt Text Image 5 Path");                   // 124
            AddColumn(MainTable, "Alt Text Image 6 Path");                   // 125
            AddColumn(MainTable, "Alt Text Image 7 Path");                   // 126
            AddColumn(MainTable, "Alt Text Image 8 Path");                   // 127
            AddColumn(MainTable, "Alt Text Image 9 Path");                   // 128
            AddColumn(MainTable, "Alt Text Image 10 Path");                  // 129
            AddColumn(MainTable, "Alt Text Image Group 1 Path");             // 130
            AddColumn(MainTable, "Alt Text Image Group 2 Path");             // 131
            AddColumn(MainTable, "Alt Text Image Group 3 Path");             // 132
            AddColumn(MainTable, "Alt Text Image Group 4 Path");             // 133
            AddColumn(MainTable, "Alt Text Image Group 5 Path");             // 134
            AddColumn(MainTable, "Alt Text Image Model 1 Path");             // 135
            AddColumn(MainTable, "Alt Text Image Model 2 Path");             // 136
            AddColumn(MainTable, "Alt Text Image Model 3 Path");             // 137
            AddColumn(MainTable, "Alt Text Image Model 4 Path");             // 138
            AddColumn(MainTable, "Alt Text Image Model 5 Path");             // 139
            AddColumn(MainTable, "MSRP");                                    // 140
            AddColumn(MainTable, "MSRP Imprinted");                          // 141
            AddColumn(MainTable, "Wholesale");                               // 142
            AddColumn(MainTable, "Keywords");                                // 143
            AddColumn(MainTable, "Monogram");                                // 144


            // local field for inserting data to table
            double[][] discountList = GetDiscount();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = MainTable.NewRow();

                row[0] = sku;                                            // SKU ashlin
                row[1] = list[0];                                        // design service code 
                row[2] = list[5];                                        // design service fashion name ashlin
                row[3] = list[6];                                        // design short description
                row[4] = list[7];                                        // design extended description
                row[5] = list[1];                                        // material code
                row[6] = list[2];                                        // color code
                row[7] = list[1] + "-" + list[2];                        // colour material code
                row[8] = list[3];                                        // material description extended 
                row[9] = list[4];                                        // color description extended
                row[10] = list[25];                                      // design service family description
                row[11] = list[8];                                       // option 1
                row[12] = list[9];                                       // option 2
                row[13] = list[10];                                      // option 3
                row[14] = list[11];                                      // option 4
                row[15] = list[12];                                      // option 5
                row[16] = list[13];                                      // strap
                row[17] = list[14];                                      // detachable strap
                row[18] = list[15];                                      // zippered enclosure                                                                                                                                    
                row[19] = list[16];                                      // shippable weight grams
                if (!list[16].Equals(DBNull.Value))
                    row[20] = Math.Round(Convert.ToDouble(list[16])/453.592, 2);        // shippable weight lb
                row[21] = list[17];                                                     // imprintable
                if (!list[19].Equals(DBNull.Value))
                {
                    row[22] = list[18] + "cm x " + list[19] + " cm";                                                                                                 // imprint area cm
                    row[23] = Math.Round(Convert.ToDouble(list[18]) / 2.54, 2) + "in x " + Math.Round(Convert.ToDouble(list[19]) / 2.54, 2) + " in";                 // imprint area in
                }
                if (!list[20].Equals(DBNull.Value) && !list[21].Equals(DBNull.Value) && !list[22].Equals(DBNull.Value))
                {
                    row[24] = list[20] + "cm x " + list[21] + "cm x " + list[22] + "cm";                                                                                                                          // finished dimensions (cm)
                    row[25] = Math.Round(Convert.ToDouble(list[20]) / 2.54, 2) + "in x " + Math.Round(Convert.ToDouble(list[21]) / 2.54, 2) + "in x " + Math.Round(Convert.ToDouble(list[22]) / 2.54, 2) + "in";  // finished dimensions (in)
                }
                double msrp = discountList[7][0] * Convert.ToDouble(list[27]);
                int k;
                switch (Convert.ToInt32(list[68]))
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
                    case 5:
                        k = 5;
                        break;
                    case 6:
                        k = 6;
                        break;
                    default:
                        k = 0;
                        break;
                }
                row[26] = Math.Round(msrp * discountList[k][1], 2);                        // price 1 c blank
                row[27] = Math.Round(msrp * discountList[k][2], 2);                        // price 6 c blank
                row[28] = Math.Round(msrp * discountList[k][3], 2);                        // price 24 c blank
                row[29] = Math.Round(msrp * discountList[k][4], 2);                        // price 50 c blank
                row[30] = Math.Round(msrp * discountList[k][5], 2);                        // price 100 c blank
                row[31] = Math.Round(msrp * discountList[k][6], 2);                        // price 250 c blank
                row[32] = Math.Round(msrp * discountList[k][7], 2);                        // price 500 c blank
                row[33] = Math.Round(msrp * discountList[k][8], 2);                        // price 1000 c blank
                row[34] = Math.Round(msrp * discountList[k][9], 2);                        // price 2500 c blank
                double runCharge = Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[24]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                row[35] = Math.Round((msrp + runCharge) * discountList[k][1], 2);                             // price 1 c im
                row[36] = Math.Round((msrp + runCharge) * discountList[k][2], 2);                             // price 6 c im
                row[37] = Math.Round((msrp + runCharge) * discountList[k][3], 2);                             // price 24 c im
                row[38] = Math.Round((msrp + runCharge) * discountList[k][4], 2);                             // price 50 c im
                row[39] = Math.Round((msrp + runCharge) * discountList[k][5], 2);                             // price 100 c im
                row[40] = Math.Round((msrp + runCharge) * discountList[k][6], 2);                             // price 250 c im
                row[41] = Math.Round((msrp + runCharge) * discountList[k][7], 2);                             // price 500 c im
                row[42] = Math.Round((msrp + runCharge) * discountList[k][8], 2);                             // price 1000 c im 
                row[43] = Math.Round((msrp + runCharge) * discountList[k][9], 2);                             // price 2500 c im
                row[44] = Math.Round(msrp * discountList[k][11], 2);                                          // price 1 net blank
                row[45] = Math.Round(msrp * discountList[k][12], 2);                                          // price 6 net blank
                row[46] = Math.Round(msrp * discountList[k][13], 2);                                          // price 24 net blank
                row[47] = Math.Round(msrp * discountList[k][14], 2);                                          // price 50 net blank
                row[48] = Math.Round(msrp * discountList[k][15], 2);                                          // price 100 net blank
                row[49] = Math.Round(msrp * discountList[k][16], 2);                                          // price 250 net blank
                row[50] = Math.Round(msrp * discountList[k][17], 2);                                          // price 500 net blank
                row[51] = Math.Round(msrp * discountList[k][18], 2);                                          // price 1000 net blank
                row[52] = Math.Round(msrp * discountList[k][19], 2);                                          // price 2500 net blank
                row[53] = Math.Round((msrp + runCharge) * discountList[k][11], 2);                            // price 1 net im
                row[54] = Math.Round((msrp + runCharge) * discountList[k][12], 2);                            // price 6 net im
                row[55] = Math.Round((msrp + runCharge) * discountList[k][13], 2);                            // price 24 net im
                row[56] = Math.Round((msrp + runCharge) * discountList[k][14], 2);                            // price 50 net im
                row[57] = Math.Round((msrp + runCharge) * discountList[k][15], 2);                            // price 100 net im
                row[58] = Math.Round((msrp + runCharge) * discountList[k][16], 2);                            // price 250 net im
                row[59] = Math.Round((msrp + runCharge) * discountList[k][17], 2);                            // price 500 net im
                row[60] = Math.Round((msrp + runCharge) * discountList[k][18], 2);                            // price 1000 net im
                row[61] = Math.Round((msrp + runCharge) * discountList[k][19], 2);                            // price 2500 net im
                row[62] = Math.Round(msrp * discountList[k][0] * discountList[k][1], 2);                         // price rush 1 c blank
                row[63] = Math.Round(msrp * discountList[k][0] * discountList[k][2], 2);                         // price rush 6 c blank
                row[64] = Math.Round(msrp * discountList[k][0] * discountList[k][3], 2);                         // price rush 24 c blank 
                row[65] = Math.Round(msrp * discountList[k][0] * discountList[k][4], 2);                         // price rush 50 c blank
                row[66] = Math.Round(msrp * discountList[k][0] * discountList[k][5], 2);                         // price rush 100 c blank
                row[67] = Math.Round(msrp * discountList[k][0] * discountList[k][6], 2);                         // price rush 250 c blank
                row[68] = Math.Round(msrp * discountList[k][0] * discountList[k][7], 2);                         // price rush 500 c blank
                row[69] = Math.Round(msrp * discountList[k][0] * discountList[k][8], 2);                         // price rush 1000 c blank
                row[70] = Math.Round(msrp * discountList[k][0] * discountList[k][9], 2);                         // price rush 2500 c blank
                row[71] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][1], 2);           // price rush 1 c im
                row[72] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][2], 2);           // price rush 6 c im
                row[73] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][3], 2);           // price rush 24 c im
                row[74] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][4], 2);           // price rush 50 c im
                row[75] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][5], 2);           // price rush 100 c im
                row[76] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][6], 2);           // price rush 250 c im
                row[77] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][7], 2);           // price rush 500 c im
                row[78] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][8], 2);           // price rush 1000 c im
                row[79] = Math.Round((msrp + runCharge) * discountList[k][0] * discountList[k][9], 2);           // price rush 2500 c im
                row[80] = Math.Round(msrp * discountList[k][10] * discountList[k][11], 2);                       // price rush 1 net blank
                row[81] = Math.Round(msrp * discountList[k][10] * discountList[k][12], 2);                       // price rush 6 net blank
                row[82] = Math.Round(msrp * discountList[k][10] * discountList[k][13], 2);                       // price rush 24 net blank
                row[83] = Math.Round(msrp * discountList[k][10] * discountList[k][14], 2);                       // price rush 50 net blank
                row[84] = Math.Round(msrp * discountList[k][10] * discountList[k][15], 2);                       // price rush 100 net blank
                row[85] = Math.Round(msrp * discountList[k][10] * discountList[k][16], 2);                       // price rush 250 net blank
                row[86] = Math.Round(msrp * discountList[k][10] * discountList[k][17], 2);                       // price rush 500 net blank
                row[87] = Math.Round(msrp * discountList[k][10] * discountList[k][18], 2);                       // price rush 1000 net blank
                row[88] = Math.Round(msrp * discountList[k][10] * discountList[k][19], 2);                       // price rush 2500 net blank
                row[89] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][11], 2);         // price rush 1 net im
                row[90] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][12], 2);         // price rush 6 net im
                row[91] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][13], 2);         // price rush 24 net im
                row[92] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][14], 2);         // price rush 50 net im        
                row[93] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][15], 2);         // price rush 100 net im
                row[94] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][16], 2);         // price rush 250 net im
                row[95] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][17], 2);         // price rush 500 net im
                row[96] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][18], 2);         // price rush 1000 net im
                row[97] = Math.Round((msrp + runCharge) * discountList[k][10] * discountList[k][19], 2);         // price rush 2500 net im
                row[98] = list[28];                                      // image 1 path
                row[99] = list[29];                                      // image 2 path
                row[100] = list[30];                                     // image 3 path
                row[101] = list[31];                                     // image 4 path
                row[102] = list[32];                                     // image 5 path
                row[103] = list[33];                                     // image 6 path
                row[104] = list[34];                                     // image 7 path
                row[105] = list[35];                                     // image 8 path
                row[106] = list[36];                                     // image 9 path
                row[107] = list[37];                                     // image 10 path
                row[108] = list[38];                                     // image group 1 path
                row[109] = list[39];                                     // image group 2 path
                row[110] = list[40];                                     // image group 3 path
                row[111] = list[41];                                     // image group 4 path
                row[112] = list[42];                                     // image group 5 path
                row[113] = list[43];                                     // image model 1 path   
                row[114] = list[44];                                     // image model 2 path
                row[115] = list[45];                                     // image model 3 path
                row[116] = list[46];                                     // image model 4 path
                row[117] = list[47];                                     // image model 5 path
                row[118] = GetSwatch(sku);                               // swatch path
                row[119] = list[48];                                     // alt text image 1 path
                row[120] = list[49];                                     // alt text image 2 path
                row[121] = list[50];                                     // alt text image 3 path
                row[122] = list[51];                                     // alt text image 4 path
                row[123] = list[52];                                     // alt text image 5 path
                row[124] = list[53];                                     // alt text image 6 path
                row[125] = list[54];                                     // alt text image 7 path
                row[126] = list[55];                                     // alt text image 8 path
                row[127] = list[56];                                     // alt text image 9 path
                row[128] = list[57];                                     // alt text image 10 path
                row[129] = list[58];                                     // alt text image group 1 path
                row[130] = list[59];                                     // alt text image group 2 path
                row[131] = list[60];                                     // alt text image group 3 path
                row[132] = list[61];                                     // alt text image group 4 path
                row[133] = list[62];                                     // alt text image group 5 path
                row[134] = list[63];                                     // alt text image model 1 path
                row[135] = list[64];                                     // alt text image model 2 path
                row[136] = list[65];                                     // alt text image model 3 path
                row[137] = list[66];                                     // alt text image model 4 path
                row[138] = list[67];                                     // alt text image model 5 path
                row[139] = msrp;                                         // msrp
                row[140] = Math.Round(msrp + runCharge, 2);              // msrp imprinted
                row[141] = Math.Round(msrp * discountList[k][20], 2);    // wholesale
                row[142] = list[26];                                     // keywords
                row[143] = list[23];                                     // monogram

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_Website = 'True' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // [0] design, [1] material, [2] color;
            list.Add(design); list.Add(material); list.Add(color);

            // grab data from design
            // [3] material description extended 
            // [4] colour description extended
            // [5] design service fashion name ashlin, [6] design short description, [7] design extended description, [8] ~ [12] options, [13] strap, [14] detachable strap, [15] zippered enclosure, [16] shippable weight grams, [17] imprintable,  [18] & [19] imprint area cm, [20] ~ [22] finished dimensions (cm), [23] monogram, [24] for price calculation
            //                                                                                                                                                                                           & shippable weight lb                                  & imprint area in            & finished dimensions (in)
            // [25] design servie family description, [26] keywords
            // [27] all related to price, [28] ~ [37] iamge path, [38] ~ [42] group path, [43] ~ [47] model path, [48] ~ [57] alt image path, [58] ~ [62] alt group path, [63] ~ [67] alt model path, [68] for price calculation
            SqlCommand command = new SqlCommand("SELECT Material_Description_Extended, " +
                                                "Colour_Description_Extended, " +
                                                "Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Strap, Detachable_Strap, Zippered_Enclosure, Shippable_weight_grams, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Monogram, Components, " +
                                                "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                "Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path, " +
                                                "sku.Pricing_Tier FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 65; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* method that add swatch image url */
        private static string GetSwatch(string sku)
        {
            // get material + color code
            string node = sku.Substring(sku.IndexOf('-'));

            return "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/1_WEB_SWATCHES/" + node + ".jpg";
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[8][];

            // [0] rush standard, [1] 1 c standard, [2] 6 c standard, [3] 24 c standard, [4] 50 c standard, [5] 100 c standard, [6] 250 c standard, [7] 500 c standard, [8] 1000 c standard, [9] 2500 c standard, [10] rush net, [11] 1 c net standard
            // [12] 6 c net standard, [13] 24 c net standard, [14] 50 c net standard, [15] 100 net standard, [16] 250 net standard, [17] 500 net standard, [18] 1000 net standard, [19] 2500 net standard, [20] wholesale net
            SqlCommand command = new SqlCommand("SELECT [RUSH_C_25_wks], [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_Net_25_wks], [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], [Wholesale_Net] FROM Discount_Matrix", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 6; i++)
            {
                double[] itemList = new double[21];
                reader.Read();
                for (int j = 0; j <= 20; j++)
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

            // [21] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[7] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }
    }
}
