using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "SKU Ashlin");                              // 1
            addColumn(mainTable, "Design Service Code");                     // 2
            addColumn(mainTable, "Design_Service_Fashion_Name_Ashlin");      // 3
            addColumn(mainTable, "Design Short Description");                // 4
            addColumn(mainTable, "Design Extended Description");             // 5
            addColumn(mainTable, "Material Code");                           // 6
            addColumn(mainTable, "Colour Code");                             // 7
            addColumn(mainTable, "Colour Material Code");                    // 8
            addColumn(mainTable, "Material Description Extended");           // 9
            addColumn(mainTable, "Colour Description Extended");             // 10
            addColumn(mainTable, "Design Service Family Description");       // 11
            addColumn(mainTable, "Option 1");                                // 12
            addColumn(mainTable, "Option 2");                                // 13
            addColumn(mainTable, "Option 3");                                // 14
            addColumn(mainTable, "Option 4");                                // 15
            addColumn(mainTable, "Option 5");                                // 16
            addColumn(mainTable, "Strap");                                   // 17
            addColumn(mainTable, "Detachable Strap");                        // 18
            addColumn(mainTable, "Zuooered Enclosure");                      // 19
            addColumn(mainTable, "Shippable weight grams");                  // 20
            addColumn(mainTable, "Shippable weight lb");                     // 21
            addColumn(mainTable, "Imprintable");                             // 22
            addColumn(mainTable, "Imprint Area cm");                         // 23
            addColumn(mainTable, "Imprint Area in");                         // 24
            addColumn(mainTable, "Finished Dimensions (cm)");                // 25
            addColumn(mainTable, "Finished Dimensions (in)");                // 26
            addColumn(mainTable, "price 1 c blank");                         // 27
            addColumn(mainTable, "price 6 c blank");                         // 28
            addColumn(mainTable, "price 24 c blank");                        // 29
            addColumn(mainTable, "price 50 c blank");                        // 30
            addColumn(mainTable, "price 100 c blank");                       // 31
            addColumn(mainTable, "price 250 c blank");                       // 32
            addColumn(mainTable, "price 500 c blank");                       // 33
            addColumn(mainTable, "price 1000 c blank");                      // 34
            addColumn(mainTable, "price 2500 c blank");                      // 35
            addColumn(mainTable, "price 1 c im");                            // 36
            addColumn(mainTable, "price 6 c im");                            // 37
            addColumn(mainTable, "price 24 c im");                           // 38
            addColumn(mainTable, "price 50 c im");                           // 39
            addColumn(mainTable, "price 100 c im");                          // 40   
            addColumn(mainTable, "price 250 c im");                          // 41
            addColumn(mainTable, "price 500 c im");                          // 42
            addColumn(mainTable, "price 1000 c im");                         // 43
            addColumn(mainTable, "price 2500 c im");                         // 44
            addColumn(mainTable, "price 1 net blank");                       // 45
            addColumn(mainTable, "price 6 net blank");                       // 46
            addColumn(mainTable, "price 24 net blank");                      // 47
            addColumn(mainTable, "price 50 net blank");                      // 48
            addColumn(mainTable, "price 100 net blank");                     // 49
            addColumn(mainTable, "price 250 net blank");                     // 50
            addColumn(mainTable, "price 500 net blank");                     // 51
            addColumn(mainTable, "price 1000 net blank");                    // 52
            addColumn(mainTable, "price 2500 net blank");                    // 53
            addColumn(mainTable, "price 1 net im");                          // 54
            addColumn(mainTable, "price 6 net im");                          // 55
            addColumn(mainTable, "price 24 net im");                         // 56
            addColumn(mainTable, "price 50 net im");                         // 57
            addColumn(mainTable, "price 100 net im");                        // 58
            addColumn(mainTable, "price 250 net im");                        // 59
            addColumn(mainTable, "price 500 net im");                        // 60
            addColumn(mainTable, "price 1000 net im");                       // 61
            addColumn(mainTable, "price 2500 net im");                       // 62
            addColumn(mainTable, "price rush 1 c blank");                    // 63
            addColumn(mainTable, "price rush 6 c blank");                    // 64
            addColumn(mainTable, "price rush 24 c blank");                   // 65
            addColumn(mainTable, "price rush 50 c blank");                   // 66
            addColumn(mainTable, "price rush 100 c blank");                  // 67
            addColumn(mainTable, "price rush 250 c blank");                  // 68
            addColumn(mainTable, "price rush 500 c blank");                  // 69
            addColumn(mainTable, "price rush 1000 c blank");                 // 70
            addColumn(mainTable, "price rush 2500 c blank");                 // 71
            addColumn(mainTable, "price rush 1 c im");                       // 72
            addColumn(mainTable, "price rush 6 c im");                       // 73
            addColumn(mainTable, "price rush 24 c im");                      // 74
            addColumn(mainTable, "price rush 50 c im");                      // 75   
            addColumn(mainTable, "price rush 100 c im");                     // 76
            addColumn(mainTable, "price rush 250 c im");                     // 77
            addColumn(mainTable, "price rush 500 c im");                     // 78
            addColumn(mainTable, "price rush 1000 c im");                    // 79
            addColumn(mainTable, "price rush 2500 c im");                    // 80
            addColumn(mainTable, "price rush 1 net blank");                  // 81
            addColumn(mainTable, "price rush 6 net blank");                  // 82
            addColumn(mainTable, "price rush 24 net blank");                 // 83
            addColumn(mainTable, "price rush 50 net blank");                 // 84
            addColumn(mainTable, "price rush 100 net blank");                // 85
            addColumn(mainTable, "price rush 250 net blank");                // 86
            addColumn(mainTable, "price rush 500 net blank");                // 87
            addColumn(mainTable, "price rush 1000 net blank");               // 88
            addColumn(mainTable, "price rush 2500 net blank");               // 89
            addColumn(mainTable, "price rush 1 net im");                     // 90
            addColumn(mainTable, "price rush 6 net im");                     // 91
            addColumn(mainTable, "price rush 24 net im");                    // 92
            addColumn(mainTable, "price rush 50 net im");                    // 93
            addColumn(mainTable, "price rush 100 net im");                   // 94
            addColumn(mainTable, "price rush 250 net im");                   // 95
            addColumn(mainTable, "price rush 500 net im");                   // 96
            addColumn(mainTable, "price rush 1000 net im");                  // 97
            addColumn(mainTable, "price rush 2500 net im");                  // 98
            addColumn(mainTable, "image 1 path");                            // 99
            addColumn(mainTable, "image 2 path");                            // 100
            addColumn(mainTable, "image 3 path");                            // 101
            addColumn(mainTable, "image 4 path");                            // 102
            addColumn(mainTable, "image 5 path");                            // 103
            addColumn(mainTable, "image 6 path");                            // 104
            addColumn(mainTable, "image 7 path");                            // 105
            addColumn(mainTable, "image 8 path");                            // 106
            addColumn(mainTable, "image 9 path");                            // 107
            addColumn(mainTable, "image 10 path");                           // 108
            addColumn(mainTable, "image group 1 path");                      // 109
            addColumn(mainTable, "image group 2 path");                      // 110
            addColumn(mainTable, "image group 3 path");                      // 111
            addColumn(mainTable, "image group 4 path");                      // 112
            addColumn(mainTable, "image group 5 path");                      // 113
            addColumn(mainTable, "image model 1 path");                      // 114
            addColumn(mainTable, "image model 2 path");                      // 115
            addColumn(mainTable, "image model 3 path");                      // 116
            addColumn(mainTable, "image model 4 path");                      // 117
            addColumn(mainTable, "image model 5 path");                      // 118
            addColumn(mainTable, "Swatch Path");                             // 119
            addColumn(mainTable, "Alt Text Image 1 Path");                   // 120
            addColumn(mainTable, "Alt Text Image 2 Path");                   // 121  
            addColumn(mainTable, "Alt Text Image 3 Path");                   // 122
            addColumn(mainTable, "Alt Text Image 4 Path");                   // 123
            addColumn(mainTable, "Alt Text Image 5 Path");                   // 124
            addColumn(mainTable, "Alt Text Image 6 Path");                   // 125
            addColumn(mainTable, "Alt Text Image 7 Path");                   // 126
            addColumn(mainTable, "Alt Text Image 8 Path");                   // 127
            addColumn(mainTable, "Alt Text Image 9 Path");                   // 128
            addColumn(mainTable, "Alt Text Image 10 Path");                  // 129
            addColumn(mainTable, "Alt Text Image Group 1 Path");             // 130
            addColumn(mainTable, "Alt Text Image Group 2 Path");             // 131
            addColumn(mainTable, "Alt Text Image Group 3 Path");             // 132
            addColumn(mainTable, "Alt Text Image Group 4 Path");             // 133
            addColumn(mainTable, "Alt Text Image Group 5 Path");             // 134
            addColumn(mainTable, "Alt Text Image Model 1 Path");             // 135
            addColumn(mainTable, "Alt Text Image Model 2 Path");             // 136
            addColumn(mainTable, "Alt Text Image Model 3 Path");             // 137
            addColumn(mainTable, "Alt Text Image Model 4 Path");             // 138
            addColumn(mainTable, "Alt Text Image Model 5 Path");             // 139
            addColumn(mainTable, "MSRP");                                    // 140
            addColumn(mainTable, "MSRP Imprinted");                          // 141
            addColumn(mainTable, "Wholesale");                               // 142
            addColumn(mainTable, "Keywords");                                // 143
            addColumn(mainTable, "Monogram");                                // 144


            // local field for inserting data to table
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                DataRow row = mainTable.NewRow();

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
                {
                    row[20] = Convert.ToDouble(list[16]) / 453.592;      // shippable weight lb
                }
                row[21] = list[17];                                      // imprintable
                if (!list[19].Equals(DBNull.Value))
                {
                    row[22] = list[18] + "cm x " + list[19] + " cm";                                                                                             // imprint area cm
                    row[23] = Convert.ToDouble(list[18]) / 2.54 + "in x " + Convert.ToDouble(list[19]) / 2.54 + " in";                                           // imprint area in
                }
                row[24] = list[20] + "cm x " + list[21] + "cm x " + list[22] + "cm";                                                                             // finished dimensions (cm)
                row[25] = Convert.ToDouble(list[20]) / 2.54 + "in x " + Convert.ToDouble(list[21]) / 2.54 + "in x " + Convert.ToDouble(list[22]) / 2.54 + "in";  // finished dimensions (in)
                double msrp = discountList[21] * Convert.ToDouble(list[27]);
                row[26] = msrp * discountList[1];                        // price 1 c blank
                row[27] = msrp * discountList[2];                        // price 6 c blank
                row[28] = msrp * discountList[3];                        // price 24 c blank
                row[29] = msrp * discountList[4];                        // price 50 c blank
                row[30] = msrp * discountList[5];                        // price 100 c blank
                row[31] = msrp * discountList[6];                        // price 250 c blank
                row[32] = msrp * discountList[7];                        // price 500 c blank
                row[33] = msrp * discountList[8];                        // price 1000 c blank
                row[34] = msrp * discountList[9];                        // price 2500 c blank
                double runCharge = Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[24]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                row[35] = (msrp + runCharge) * discountList[1];                             // price 1 c im
                row[36] = (msrp + runCharge) * discountList[2];                             // price 6 c im
                row[37] = (msrp + runCharge) * discountList[3];                             // price 24 c im
                row[38] = (msrp + runCharge) * discountList[4];                             // price 50 c im
                row[39] = (msrp + runCharge) * discountList[5];                             // price 100 c im
                row[40] = (msrp + runCharge) * discountList[6];                             // price 250 c im
                row[41] = (msrp + runCharge) * discountList[7];                             // price 500 c im
                row[42] = (msrp + runCharge) * discountList[8];                             // price 1000 c im 
                row[43] = (msrp + runCharge) * discountList[9];                             // price 2500 c im
                row[44] = msrp * discountList[11];                                          // price 1 net blank
                row[45] = msrp * discountList[12];                                          // price 6 net blank
                row[46] = msrp * discountList[13];                                          // price 24 net blank
                row[47] = msrp * discountList[14];                                          // price 50 net blank
                row[48] = msrp * discountList[15];                                          // price 100 net blank
                row[49] = msrp * discountList[16];                                          // price 250 net blank
                row[50] = msrp * discountList[17];                                          // price 500 net blank
                row[51] = msrp * discountList[18];                                          // price 1000 net blank
                row[52] = msrp * discountList[19];                                          // price 2500 net blank
                row[53] = (msrp + runCharge) * discountList[11];                            // price 1 net im
                row[54] = (msrp + runCharge) * discountList[12];                            // price 6 net im
                row[55] = (msrp + runCharge) * discountList[13];                            // price 24 net im
                row[56] = (msrp + runCharge) * discountList[14];                            // price 50 net im
                row[57] = (msrp + runCharge) * discountList[15];                            // price 100 net im
                row[58] = (msrp + runCharge) * discountList[16];                            // price 250 net im
                row[59] = (msrp + runCharge) * discountList[17];                            // price 500 net im
                row[60] = (msrp + runCharge) * discountList[18];                            // price 1000 net im
                row[61] = (msrp + runCharge) * discountList[19];                            // price 2500 net im
                row[62] = msrp * discountList[0] * discountList[1];                         // price rush 1 c blank
                row[63] = msrp * discountList[0] * discountList[2];                         // price rush 6 c blank
                row[64] = msrp * discountList[0] * discountList[3];                         // price rush 24 c blank 
                row[65] = msrp * discountList[0] * discountList[4];                         // price rush 50 c blank
                row[66] = msrp * discountList[0] * discountList[5];                         // price rush 100 c blank
                row[67] = msrp * discountList[0] * discountList[6];                         // price rush 250 c blank
                row[68] = msrp * discountList[0] * discountList[7];                         // price rush 500 c blank
                row[69] = msrp * discountList[0] * discountList[8];                         // price rush 1000 c blank
                row[70] = msrp * discountList[0] * discountList[9];                         // price rush 2500 c blank
                row[71] = (msrp + runCharge) * discountList[0] * discountList[1];           // price rush 1 c im
                row[72] = (msrp + runCharge) * discountList[0] * discountList[2];           // price rush 6 c im
                row[73] = (msrp + runCharge) * discountList[0] * discountList[3];           // price rush 24 c im
                row[74] = (msrp + runCharge) * discountList[0] * discountList[4];           // price rush 50 c im
                row[75] = (msrp + runCharge) * discountList[0] * discountList[5];           // price rush 100 c im
                row[76] = (msrp + runCharge) * discountList[0] * discountList[6];           // price rush 250 c im
                row[77] = (msrp + runCharge) * discountList[0] * discountList[7];           // price rush 500 c im
                row[78] = (msrp + runCharge) * discountList[0] * discountList[8];           // price rush 1000 c im
                row[79] = (msrp + runCharge) * discountList[0] * discountList[9];           // price rush 2500 c im
                row[80] = msrp * discountList[10] * discountList[11];                       // price rush 1 net blank
                row[81] = msrp * discountList[10] * discountList[12];                       // price rush 6 net blank
                row[82] = msrp * discountList[10] * discountList[13];                       // price rush 24 net blank
                row[83] = msrp * discountList[10] * discountList[14];                       // price rush 50 net blank
                row[84] = msrp * discountList[10] * discountList[15];                       // price rush 100 net blank
                row[85] = msrp * discountList[10] * discountList[16];                       // price rush 250 net blank
                row[86] = msrp * discountList[10] * discountList[17];                       // price rush 500 net blank
                row[87] = msrp * discountList[10] * discountList[18];                       // price rush 1000 net blank
                row[88] = msrp * discountList[10] * discountList[19];                       // price rush 2500 net blank
                row[89] = (msrp + runCharge) * discountList[10] * discountList[11];         // price rush 1 net im
                row[90] = (msrp + runCharge) * discountList[10] * discountList[12];         // price rush 6 net im
                row[91] = (msrp + runCharge) * discountList[10] * discountList[13];         // price rush 24 net im
                row[92] = (msrp + runCharge) * discountList[10] * discountList[14];         // price rush 50 net im        
                row[93] = (msrp + runCharge) * discountList[10] * discountList[15];         // price rush 100 net im
                row[94] = (msrp + runCharge) * discountList[10] * discountList[16];         // price rush 250 net im
                row[95] = (msrp + runCharge) * discountList[10] * discountList[17];         // price rush 500 net im
                row[96] = (msrp + runCharge) * discountList[10] * discountList[18];         // price rush 1000 net im
                row[97] = (msrp + runCharge) * discountList[10] * discountList[19];         // price rush 2500 net im
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
                row[118] = getSwatch(sku);                               // swatch path
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
                row[140] = msrp + runCharge;                             // msrp imprinted
                row[141] = msrp * discountList[20];                      // wholesale
                row[142] = list[26];                                     // keywords
                row[143] = list[23];                                     // monogram

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' and Design_Service_Code IN (SELECT Design_Service_Code FROM master_Design_Attributes WHERE Website_Flag = \'True\') ORDER BY SKU_Ashlin", connection);
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
            // [27] all related to price, [28] ~ [37] iamge path, [38] ~ [42] group path, [43] ~ [47] model path, [48] ~ [57] alt image path, [58] ~ [62] alt group path, [63] ~ [67] alt model path
            SqlCommand command = new SqlCommand("SELECT Material_Description_Extended, " +
                                                "Colour_Description_Extended, " +
                                                "Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Strap, Detachable_Strap, Zippered_Enclosure, Shippable_weight_grams, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Monogram, Components, " +
                                                "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                "Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 64; i++)
                list.Add(reader.GetValue(i));
            connection.Close();

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
                                              + "[RUSH_Net_25_wks], [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], [Wholesale_Net] FROM ref_discount_matrix;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 20; i++)
                list[i] = reader.GetDouble(i);
            reader.Close();
            // [21] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[21] = reader.GetDouble(0);
            connection.Close();

            return list.ToArray();
        }
    }
}
