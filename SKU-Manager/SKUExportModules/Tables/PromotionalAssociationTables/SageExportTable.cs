using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables
{
    /*
     * A class that return sage export table
     */
    public class SageExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public SageExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset the table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU Ashlin");                             // 1
            AddColumn(MainTable, "Design Service Code");                    // 2
            AddColumn(MainTable, "Design Service Fashion Name Ashlin");     // 3
            AddColumn(MainTable, "Design_Short Description");               // 4
            AddColumn(MainTable, "Design Extended Description");            // 5
            AddColumn(MainTable, "Material Code");                          // 6
            AddColumn(MainTable, "Colour Code");                            // 7
            AddColumn(MainTable, "Material Description Extended");          // 8
            AddColumn(MainTable, "Colour Description Extended");            // 9
            AddColumn(MainTable, "Design Service Family Description");      // 10
            AddColumn(MainTable, "Option 1");                               // 11
            AddColumn(MainTable, "Option 2");                               // 12
            AddColumn(MainTable, "Option 3");                               // 13
            AddColumn(MainTable, "Option 4");                               // 14
            AddColumn(MainTable, "Option 5");                               // 15
            AddColumn(MainTable, "Strap");                                  // 16
            AddColumn(MainTable, "Detachable Strap");                       // 17
            AddColumn(MainTable, "Zippered Enclosure");                     // 18
            AddColumn(MainTable, "Shippable Weight grams");                 // 19
            AddColumn(MainTable, "Shippable Weight lb");                    // 20
            AddColumn(MainTable, "Imprintable");                            // 21
            AddColumn(MainTable, "Imprint Area cm");                        // 22
            AddColumn(MainTable, "Imprint Area in");                        // 23
            AddColumn(MainTable, "Finished Dimensions (cm)");               // 24
            AddColumn(MainTable, "Finished Dimensions (in)");               // 25
            AddColumn(MainTable, "Price 1 C Blank");                        // 26
            AddColumn(MainTable, "Price 6 C Blank");                        // 27
            AddColumn(MainTable, "Price 24 C Blank");                       // 28
            AddColumn(MainTable, "Price 50 C Blank");                       // 29
            AddColumn(MainTable, "Price 100 C Blank");                      // 30
            AddColumn(MainTable, "Price 250 C Blank");                      // 31
            AddColumn(MainTable, "Price 500 C Blank");                      // 32
            AddColumn(MainTable, "Price 1000 C Blank");                     // 33
            AddColumn(MainTable, "Price 2500 C Blank");                     // 34
            AddColumn(MainTable, "Price RUSH 1 C Blank");                   // 35
            AddColumn(MainTable, "Price RUSH 6 C Blank");                   // 36
            AddColumn(MainTable, "Price RUSH 24 C Blank");                  // 37
            AddColumn(MainTable, "Price RUSH 50 C Blank");                  // 38
            AddColumn(MainTable, "Price RUSH 100 C Blank");                 // 39
            AddColumn(MainTable, "Price RUSH 250 C Blank");                 // 40
            AddColumn(MainTable, "Price RUSH 500 C Blank");                 // 41
            AddColumn(MainTable, "Price RUSH 1000 C Blank");                // 42
            AddColumn(MainTable, "Price RUSH 2500 C Blank");                // 43
            AddColumn(MainTable, "Price 1 Net Blank");                      // 44
            AddColumn(MainTable, "Price 6 Net Blank");                      // 45
            AddColumn(MainTable, "Price 24 Net Blank");                     // 46
            AddColumn(MainTable, "Price 50 Net Blank");                     // 47
            AddColumn(MainTable, "Price 100 Net Blank");                    // 48
            AddColumn(MainTable, "Price 250 Net Blank");                    // 49
            AddColumn(MainTable, "Price 500 Net Blank");                    // 50
            AddColumn(MainTable, "Price 1000 Net Blank");                   // 51
            AddColumn(MainTable, "Price 2500 Net Blank");                   // 52
            AddColumn(MainTable, "Price RUSH 1 Net Blank");                 // 53
            AddColumn(MainTable, "Price RUSH 6 Net Blank");                 // 54
            AddColumn(MainTable, "Price RUSH 24 Net Blank");                // 55
            AddColumn(MainTable, "Price RUSH 50 Net Blank");                // 56
            AddColumn(MainTable, "Price RUSH 100 Net Blank");               // 57
            AddColumn(MainTable, "Price RUSH 250 Net Blank");               // 58
            AddColumn(MainTable, "Price RUSH 500 Net Blank");               // 59
            AddColumn(MainTable, "Price RUSH 1000 Net Blank");              // 60
            AddColumn(MainTable, "Price RUSH 2500 Net Blank");              // 61
            AddColumn(MainTable, "Price 1 C Imprinted");                    // 62
            AddColumn(MainTable, "Price 6 C Imprinted");                    // 63
            AddColumn(MainTable, "Price 24 C Imprinted");                   // 64
            AddColumn(MainTable, "Price 50 C Imprinted");                   // 65
            AddColumn(MainTable, "Price 100 C Imprinted");                  // 66
            AddColumn(MainTable, "Price 250 C Imprinted");                  // 67
            AddColumn(MainTable, "Price 500 C Imprinted");                  // 68
            AddColumn(MainTable, "Price 1000 C Imprinted");                 // 69
            AddColumn(MainTable, "Price 2500 C Imprinted");                 // 70
            AddColumn(MainTable, "Price Rush 1 C Imprinted");               // 71
            AddColumn(MainTable, "Price Rush 6 C Imprinted");               // 72
            AddColumn(MainTable, "Price Rush 24 C Imprinted");              // 73
            AddColumn(MainTable, "Price Rush 50 C Imprinted");              // 74
            AddColumn(MainTable, "Price Rush 100 C Imprinted");             // 75
            AddColumn(MainTable, "Price Rush 250 C Imprinted");             // 76
            AddColumn(MainTable, "Price Rush 500 C Imprinted");             // 77
            AddColumn(MainTable, "Price Rush 1000 C Imprinted");            // 78
            AddColumn(MainTable, "Price Rush 2500 C Imprinted");            // 79
            AddColumn(MainTable, "Price 1 Net Imprinted");                  // 80
            AddColumn(MainTable, "Price 6 Net Imprinted");                  // 81
            AddColumn(MainTable, "Price 24 Net Imprinted");                 // 82
            AddColumn(MainTable, "Price 50 Net Imprinted");                 // 83
            AddColumn(MainTable, "Price 100 Net Imprinted");                // 84
            AddColumn(MainTable, "Price 250 Net Imprinted");                // 85
            AddColumn(MainTable, "Price 500 Net Imprinted");                // 86
            AddColumn(MainTable, "Price 1000 Net Imprinted");               // 87
            AddColumn(MainTable, "Price 2500 Net Imprinted");               // 88
            AddColumn(MainTable, "Price RUSH 1 Net Imprinted");             // 89
            AddColumn(MainTable, "Price RUSH 6 Net Imprinted");             // 90
            AddColumn(MainTable, "Price RUSH 24 Net Imprinted");            // 91
            AddColumn(MainTable, "Price RUSH 50 Net Imprinted");            // 92
            AddColumn(MainTable, "Price RUSH 100 Net Imprinted");           // 93
            AddColumn(MainTable, "Price RUSH 250 Net Imprinted");           // 94
            AddColumn(MainTable, "Price RUSH 500 Net Imprinted");           // 95
            AddColumn(MainTable, "Price RUSH 1000 Net Imprinted");          // 96
            AddColumn(MainTable, "Price RUSH 2500 Net Imprinted");          // 97
            AddColumn(MainTable, "Image 1 Path");                           // 98
            AddColumn(MainTable, "Image 2 Path");                           // 99
            AddColumn(MainTable, "Image 3 Path");                           // 100
            AddColumn(MainTable, "Image 4 Path");                           // 101
            AddColumn(MainTable, "Image 5 Path");                           // 102
            AddColumn(MainTable, "Image 6 Path");                           // 103
            AddColumn(MainTable, "Image 7 Path");                           // 104
            AddColumn(MainTable, "Image 8 Path");                           // 105
            AddColumn(MainTable, "Image 9 Path");                           // 106
            AddColumn(MainTable, "Image 10 Path");                          // 107
            AddColumn(MainTable, "Image Group 1 Path");                     // 108
            AddColumn(MainTable, "Image Group 2 Path");                     // 109
            AddColumn(MainTable, "Image Group 3 Path");                     // 110
            AddColumn(MainTable, "Image Group 4 Path");                     // 111
            AddColumn(MainTable, "Image Group 5 Path");                     // 112
            AddColumn(MainTable, "Image Model 1 Path");                     // 113
            AddColumn(MainTable, "Image Model 2 Path");                     // 114
            AddColumn(MainTable, "Image Model 3 Path");                     // 115
            AddColumn(MainTable, "Image Model 4 Path");                     // 116
            AddColumn(MainTable, "Image Model 5 Path");                     // 117
            AddColumn(MainTable, "Swatch Path");                            // 118
            AddColumn(MainTable, "Wholesale");                              // 119
            AddColumn(MainTable, "Keywords");                               // 120

            // local field for price calculation
            double[][] discountList = GetDiscount();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = MainTable.NewRow();

                row[0] = sku;                                                 // sku ashlin
                row[1] = list[0];                                             // design service code
                row[2] = list[3];                                             // design service fashion name ashlin
                row[3] = list[4];                                             // design short description
                row[4] = list[5];                                             // design extended description
                row[5] = list[1];                                             // material code
                row[6] = list[2];                                             // colour code
                row[7] = list[44];                                            // material description extended
                row[8] = list[45];                                            // colour description extended
                row[9] = list[46];                                            // design service family description
                row[10] = list[6];                                            // option 1
                row[11] = list[7];                                            // option 2
                row[12] = list[8];                                            // option 3
                row[13] = list[9];                                            // option 4
                row[14] = list[10];                                           // option 5
                row[15] = list[11];                                           // strap
                row[16] = list[12];                                           // detachable strap
                row[17] = list[13];                                           // zippered enclosure
                row[18] = list[14];                                           // shippable weight grams  
                if (!list[14].Equals(DBNull.Value))                                                                                                                                 
                    row[19] = Convert.ToDouble(list[14]) / 453.592;           // shippable weight lb
                row[20] = list[15];                                           // imprintable
                row[21] = list[16] + " cm x " + list[17] + " cm";             // imprint area cm
                if (!list[16].Equals(DBNull.Value))
                    row[22] = Math.Round(Convert.ToDouble(list[16]) / 2.54, 2) + " in x " + Math.Round(Convert.ToDouble(list[16]) / 2.54, 2) + " in";                                                                  // imprint area in
                row[23] = list[18] + " cm x " + list[19] + " cm x " + list[19] + " cm";                                                                                                                                // finished dimensions (cm)
                if (!list[18].Equals(DBNull.Value))
                    row[24] = Math.Round(Convert.ToDouble(list[18]) / 2.54, 2) + " in x " + Math.Round(Convert.ToDouble(list[19]) / 2.54, 2) + " in x " + Math.Round(Convert.ToDouble(list[19]) / 2.54, 2) + " in";    // finished dimensions (in)
                double msrp = Convert.ToDouble(list[22]) * discountList[5][0];
                double runCharge = list[21].Equals(DBNull.Value) ? Math.Round(msrp * 0.05) / 0.6 : Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[21]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                int k;
                switch (Convert.ToInt32(list[43]))
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
                row[25] = Math.Round(msrp * discountList[k][1], 2);                                  // price 1 c
                row[26] = Math.Round(msrp * discountList[k][2], 2);                                  // price 6 c        
                row[27] = Math.Round(msrp * discountList[k][3], 2);                                  // price 24 c
                row[28] = Math.Round(msrp * discountList[k][4], 2);                                  // price 50 c
                row[29] = Math.Round(msrp * discountList[k][5], 2);                                  // price 100 c
                row[30] = Math.Round(msrp * discountList[k][6], 2);                                  // price 250 c
                row[31] = Math.Round(msrp * discountList[k][7], 2);                                  // price 500 c
                row[32] = Math.Round(msrp * discountList[k][8], 2);                                  // price 1000 c
                row[33] = Math.Round(msrp * discountList[k][9], 2);                                  // price 2500 c
                row[34] = Math.Round(msrp * discountList[k][0] * discountList[k][1], 2);             // price rush 1 c
                row[35] = Math.Round(msrp * discountList[k][0] * discountList[k][2], 2);             // price rush 6 c
                row[36] = Math.Round(msrp * discountList[k][0] * discountList[k][3], 2);             // price rush 24 c
                row[37] = Math.Round(msrp * discountList[k][0] * discountList[k][4], 2);             // price rush 50 c
                row[38] = Math.Round(msrp * discountList[k][0] * discountList[k][5], 2);             // price rush 100 c
                row[39] = Math.Round(msrp * discountList[k][0] * discountList[k][6], 2);             // price rush 250 c
                row[40] = Math.Round(msrp * discountList[k][0] * discountList[k][7], 2);             // price rush 500 c
                row[41] = Math.Round(msrp * discountList[k][0] * discountList[k][8], 2);             // price rush 1000 c
                row[42] = Math.Round(msrp * discountList[k][0] * discountList[k][9], 2);             // price rush 2500 c
                row[43] = Math.Round(msrp * discountList[k][11], 2);                                 // price 1 net
                row[44] = Math.Round(msrp * discountList[k][12], 2);                                 // price 6 net
                row[45] = Math.Round(msrp * discountList[k][13], 2);                                 // price 24 net
                row[46] = Math.Round(msrp * discountList[k][14], 2);                                 // price 50 net
                row[47] = Math.Round(msrp * discountList[k][15], 2);                                 // price 100 net
                row[48] = Math.Round(msrp * discountList[k][16], 2);                                 // price 250 net
                row[49] = Math.Round(msrp * discountList[k][17], 2);                                 // price 500 net
                row[50] = Math.Round(msrp * discountList[k][18], 2);                                 // price 1000 net
                row[51] = Math.Round(msrp * discountList[k][19], 2);                                 // price 2500 net
                row[52] = Math.Round(msrp * discountList[k][10] * discountList[k][11], 2);           // price rush 1 net
                row[53] = Math.Round(msrp * discountList[k][10] * discountList[k][12], 2);           // price rush 6 net
                row[54] = Math.Round(msrp * discountList[k][10] * discountList[k][13], 2);           // price rush 24 net
                row[55] = Math.Round(msrp * discountList[k][10] * discountList[k][14], 2);           // price rush 50 net
                row[56] = Math.Round(msrp * discountList[k][10] * discountList[k][15], 2);           // price rush 100 net
                row[57] = Math.Round(msrp * discountList[k][10] * discountList[k][16], 2);           // price rush 250 net
                row[58] = Math.Round(msrp * discountList[k][10] * discountList[k][17], 2);           // price rush 500 net
                row[59] = Math.Round(msrp * discountList[k][10] * discountList[k][18], 2);           // price rush 1000 net
                row[60] = Math.Round(msrp * discountList[k][10] * discountList[k][19], 2);           // price rush 2500 net
                msrp += runCharge;
                row[61] = Math.Round(msrp * discountList[k][1], 2);                                  // price 1 c imprinted
                row[62] = Math.Round(msrp * discountList[k][2], 2);                                  // price 6 c imprinted         
                row[63] = Math.Round(msrp * discountList[k][3], 2);                                  // price 24 c imprinted
                row[64] = Math.Round(msrp * discountList[k][4], 2);                                  // price 50 c imprinted
                row[65] = Math.Round(msrp * discountList[k][5], 2);                                  // price 100 c imprinted
                row[66] = Math.Round(msrp * discountList[k][6], 2);                                  // price 250 c imprinted
                row[67] = Math.Round(msrp * discountList[k][7], 2);                                  // price 500 c imprinted
                row[68] = Math.Round(msrp * discountList[k][8], 2);                                  // price 1000 c imprinted
                row[69] = Math.Round(msrp * discountList[k][9], 2);                                  // price 2500 c imprinted
                row[70] = Math.Round(msrp * discountList[k][0] * discountList[k][1], 2);             // price rush 1 c imprinted
                row[71] = Math.Round(msrp * discountList[k][0] * discountList[k][2], 2);             // price rush 6 c imprinted
                row[72] = Math.Round(msrp * discountList[k][0] * discountList[k][3], 2);             // price rush 24 c imprinted
                row[73] = Math.Round(msrp * discountList[k][0] * discountList[k][4], 2);             // price rush 50 c imprinted
                row[74] = Math.Round(msrp * discountList[k][0] * discountList[k][5], 2);             // price rush 100 c imprinted
                row[75] = Math.Round(msrp * discountList[k][0] * discountList[k][6], 2);             // price rush 250 c imprinted
                row[76] = Math.Round(msrp * discountList[k][0] * discountList[k][7], 2);             // price rush 500 c imprinted
                row[77] = Math.Round(msrp * discountList[k][0] * discountList[k][8], 2);             // price rush 1000 c imprinted
                row[78] = Math.Round(msrp * discountList[k][0] * discountList[k][9], 2);             // price rush 2500 c imprinted
                row[79] = Math.Round(msrp * discountList[k][11], 2);                                 // price 1 net imprinted
                row[80] = Math.Round(msrp * discountList[k][12], 2);                                 // price 6 net imprinted
                row[81] = Math.Round(msrp * discountList[k][13], 2);                                 // price 24 net imprinted
                row[82] = Math.Round(msrp * discountList[k][14], 2);                                 // price 50 net imprinted
                row[83] = Math.Round(msrp * discountList[k][15], 2);                                 // price 100 net imprinted
                row[84] = Math.Round(msrp * discountList[k][16], 2);                                 // price 250 net imprinted
                row[85] = Math.Round(msrp * discountList[k][17], 2);                                 // price 500 net imprinted
                row[86] = Math.Round(msrp * discountList[k][18], 2);                                 // price 1000 net imprinted
                row[87] = Math.Round(msrp * discountList[k][19], 2);                                 // price 2500 net imprinted
                row[88] = Math.Round(msrp * discountList[k][10] * discountList[k][11], 2);           // price rush 1 net imprinted
                row[89] = Math.Round(msrp * discountList[k][10] * discountList[k][12], 2);           // price rush 6 net imprinted
                row[90] = Math.Round(msrp * discountList[k][10] * discountList[k][13], 2);           // price rush 24 net imprinted
                row[91] = Math.Round(msrp * discountList[k][10] * discountList[k][14], 2);           // price rush 50 net imprinted
                row[92] = Math.Round(msrp * discountList[k][10] * discountList[k][15], 2);           // price rush 100 net imprinted
                row[93] = Math.Round(msrp * discountList[k][10] * discountList[k][16], 2);           // price rush 250 net imprinted
                row[94] = Math.Round(msrp * discountList[k][10] * discountList[k][17], 2);           // price rush 500 net imprinted
                row[95] = Math.Round(msrp * discountList[k][10] * discountList[k][18], 2);           // price rush 1000 net imprinted
                row[96] = Math.Round(msrp * discountList[k][10] * discountList[k][19], 2);           // price rush 2500 net imprinted
                row[97] = list[23];                                                // image 1 path
                row[98] = list[24];                                                // image 2 path
                row[99] = list[25];                                                // image 3 path
                row[100] = list[26];                                               // image 4 path
                row[101] = list[27];                                               // image 5 path
                row[102] = list[28];                                               // image 6 path
                row[103] = list[29];                                               // image 7 path
                row[104] = list[30];                                               // image 8 path
                row[105] = list[31];                                               // image 9 path
                row[106] = list[32];                                               // image 10 path
                row[107] = list[33];                                               // image group 1 path
                row[108] = list[34];                                               // image group 2 path
                row[109] = list[35];                                               // image group 3 path
                row[110] = list[36];                                               // image group 4 path
                row[111] = list[37];                                               // image group 5 path
                row[112] = list[38];                                               // image model 1 path   
                row[113] = list[39];                                               // image model 2 path
                row[114] = list[40];                                               // image model 3 path
                row[115] = list[41];                                               // image model 4 path
                row[116] = list[42];                                               // image model 5 path
                row[117] = GetSwatch(sku);                                         // swatch material colour path
                row[118] = (msrp - runCharge) * discountList[k][20];               // whole sale
                row[119] = list[47];                                               // keywords

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND Design_Service_Code in (" +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code in (" +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_Sage != ''))", Connection);
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
            // [3] design service family name ashlin, [4] design short description, [5] design extended description, [6] ~ [10] option, [11] strap, [12] detachable strap, [13] zippered enclosure, [14] shippable weight grams, [15] imprintable, [16] & [17] imprint area cm, , [18] ~ [20] finished dimension (cm), [21] for run charge calculation
            //                                                                                                                                                                                         & shippable weight lb                                 & imprint area in              & finished dimension (in)
            // [22] all relate to price, [23] ~ [32] image, [33] ~ [37] group image, [38] ~ [42] model image, [43] for price calculation, [44] material description extended, [45] colour description extended, [46] design service family description, [47] keywords
            SqlCommand commnad = new SqlCommand("SELECT Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Option_1, Option_2, Option_3, Option_4, Option_5, Strap, Detachable_Strap, Zippered_Enclosure, Shippable_Weight_grams, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Components, " +
                                                "Base_Price, Image_1_Path, Image_2_Path, Image_3_Path, Image_1_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, " +
                                                "sku.Pricing_Tier, Material_Description_Extended, Colour_Description_Extended, Design_Service_Family_Description, Design_Service_Family_KeyWords_General " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 44; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[6][];

            // [0] rush standard, [1] 1 c standard, [2] 6 c standard, [3] 24 c standard, [4] 50 c standard, [5] 100 c standard, [6] 250 c standard, [7] 500 c standard, [8] 1000 c standard, [9] 2500 c standard, [10] rush net, [11] 1 c net standard
            // [12] 6 c net standard, [13] 24 c net standard, [14] 50 c net standard, [15] 100 net standard, [16] 250 net standard, [17] 500 net standard, [18] 1000 net standard, [19] 2500 net standard, [20] wholesale net
            SqlCommand command = new SqlCommand("SELECT [RUSH_C_25_wks], [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_Net_25_wks], [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], [Wholesale_Net] FROM Discount_Matrix", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
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

            // [5] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[5] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }

        /* method that add swatch image url */
        private static string GetSwatch(string sku)
        {
            // get material + color code
            string node = sku.Substring(sku.IndexOf('-'));

            return "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/1_WEB_SWATCHES/" + node + ".jpg";
        }
    }
}
