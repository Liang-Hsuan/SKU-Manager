using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables
{
    /*
     * A class that return asi export table
     */
    public class AsiExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public AsiExportTable()
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
            AddColumn(MainTable, "XID");                             // 1
            AddColumn(MainTable, "Product_Name");                    // 2
            AddColumn(MainTable, "Product_Number");                  // 3
            AddColumn(MainTable, "Product_SKU");                     // 4
            AddColumn(MainTable, "Product_Inventory_Link");          // 5
            AddColumn(MainTable, "Product_Inventory_Status");        // 6
            AddColumn(MainTable, "Product_Inventory_Quantity");      // 7
            AddColumn(MainTable, "Description");                     // 8
            AddColumn(MainTable, "Summary");                         // 9
            AddColumn(MainTable, "Prod_Image");                      // 10
            AddColumn(MainTable, "Catalog_Information");             // 11
            AddColumn(MainTable, "Category");                        // 12
            AddColumn(MainTable, "Keywords");                        // 13
            AddColumn(MainTable, "Product_Color");                   // 14
            AddColumn(MainTable, "Material");                        // 15
            AddColumn(MainTable, "Size_Group");                      // 16
            AddColumn(MainTable, "Size_Values");                     // 17
            AddColumn(MainTable, "Shape");                           // 18
            AddColumn(MainTable, "Theme");                           // 19
            AddColumn(MainTable, "Tradename");                       // 20
            AddColumn(MainTable, "Origin");                          // 21
            AddColumn(MainTable, "Option_Type");                     // 22
            AddColumn(MainTable, "Option_Name");                     // 23
            AddColumn(MainTable, "Option_Values");                   // 24
            AddColumn(MainTable, "Can_order_only_one");              // 25
            AddColumn(MainTable, "Req_for_order");                   // 26
            AddColumn(MainTable, "Option_Additional_Info");          // 27
            AddColumn(MainTable, "Imprint_Method");                  // 28
            AddColumn(MainTable, "Linename");                        // 29
            AddColumn(MainTable, "Artwork");                         // 30
            AddColumn(MainTable, "Imprint_Color");                   // 31
            AddColumn(MainTable, "Sold_Unimprinted");                // 32
            AddColumn(MainTable, "Personalization");                 // 33
            AddColumn(MainTable, "Imprint_Size");                    // 34
            AddColumn(MainTable, "Imprint_Location");                // 35
            AddColumn(MainTable, "Additional_Color");                // 36
            AddColumn(MainTable, "Additional_Location");             // 37
            AddColumn(MainTable, "Product_Sample");                  // 38
            AddColumn(MainTable, "Spec_Sample");                     // 39
            AddColumn(MainTable, "Production_Time");                 // 40
            AddColumn(MainTable, "Rush_Service");                    // 41
            AddColumn(MainTable, "Rush_time");                       // 42
            AddColumn(MainTable, "Same_Day_Service");                // 43
            AddColumn(MainTable, "Packaging");                       // 44
            AddColumn(MainTable, "Shipping_Items");                  // 45
            AddColumn(MainTable, "Shipping_Dimensions");             // 46
            AddColumn(MainTable, "Shipping_Weight");                 // 47
            AddColumn(MainTable, "Shipper_Bills_By");                // 48
            AddColumn(MainTable, "Shipping_Info");                   // 49
            AddColumn(MainTable, "Ship_Plain_Box");                  // 50
            AddColumn(MainTable, "Comp_Cert");                       // 51
            AddColumn(MainTable, "Product_Data_Sheet");              // 52
            AddColumn(MainTable, "Safety_Warnings");                 // 53
            AddColumn(MainTable, "Additional_Info");                 // 54
            AddColumn(MainTable, "Distributor_Only");                // 55
            AddColumn(MainTable, "Disclaimer");                      // 56
            AddColumn(MainTable, "Base_Price_Name");                 // 57
            AddColumn(MainTable, "Base_Price_Criteria_1");           // 58
            AddColumn(MainTable, "Base_Price_Criteria_2");           // 59
            AddColumn(MainTable, "Q1");                              // 60
            AddColumn(MainTable, "Q2");                              // 61
            AddColumn(MainTable, "Q3");                              // 62
            AddColumn(MainTable, "Q4");                              // 63
            AddColumn(MainTable, "Q5");                              // 64
            AddColumn(MainTable, "Q6");                              // 65
            AddColumn(MainTable, "Q7");                              // 66
            AddColumn(MainTable, "Q8");                              // 67
            AddColumn(MainTable, "Q9");                              // 68
            AddColumn(MainTable, "Q10");                             // 69
            AddColumn(MainTable, "P1");                              // 70
            AddColumn(MainTable, "P2");                              // 71
            AddColumn(MainTable, "P3");                              // 72
            AddColumn(MainTable, "P4");                              // 73
            AddColumn(MainTable, "P5");                              // 74
            AddColumn(MainTable, "P6");                              // 75
            AddColumn(MainTable, "P7");                              // 76
            AddColumn(MainTable, "P8");                              // 77
            AddColumn(MainTable, "P9");                              // 78
            AddColumn(MainTable, "P10");                             // 79
            AddColumn(MainTable, "D1");                              // 80
            AddColumn(MainTable, "D2");                              // 81
            AddColumn(MainTable, "D3");                              // 82
            AddColumn(MainTable, "D4");                              // 83
            AddColumn(MainTable, "D5");                              // 84
            AddColumn(MainTable, "D6");                              // 85
            AddColumn(MainTable, "D7");                              // 86
            AddColumn(MainTable, "D8");                              // 87
            AddColumn(MainTable, "D9");                              // 88
            AddColumn(MainTable, "D10");                             // 89
            AddColumn(MainTable, "Product_Number_Price");            // 90
            AddColumn(MainTable, "Price_Includes");                  // 91
            AddColumn(MainTable, "QUR_Flag");                        // 92
            AddColumn(MainTable, "Currency");                        // 93
            AddColumn(MainTable, "Less_Than_Min");                   // 94
            AddColumn(MainTable, "Price_Type");                      // 95
            AddColumn(MainTable, "Breakout_by_price");               // 96
            AddColumn(MainTable, "Upcharge_Name");                   // 97
            AddColumn(MainTable, "Upcharge_Criteria_1");             // 98
            AddColumn(MainTable, "Upcharge_Criteria_2");             // 99
            AddColumn(MainTable, "Upcharge_Type");                   // 100
            AddColumn(MainTable, "Upcharge_Level");                  // 101
            AddColumn(MainTable, "UQ1");                             // 102
            AddColumn(MainTable, "UQ2");                             // 103
            AddColumn(MainTable, "UQ3");                             // 104
            AddColumn(MainTable, "UQ4");                             // 105
            AddColumn(MainTable, "UQ5");                             // 106
            AddColumn(MainTable, "UQ6");                             // 107
            AddColumn(MainTable, "UQ7");                             // 108
            AddColumn(MainTable, "UQ8");                             // 109
            AddColumn(MainTable, "UQ9");                             // 110
            AddColumn(MainTable, "UQ10");                            // 111
            AddColumn(MainTable, "UP1");                             // 112
            AddColumn(MainTable, "UP2");                             // 113
            AddColumn(MainTable, "UP3");                             // 114
            AddColumn(MainTable, "UP4");                             // 115
            AddColumn(MainTable, "UP5");                             // 116
            AddColumn(MainTable, "UP6");                             // 117
            AddColumn(MainTable, "UP7");                             // 118
            AddColumn(MainTable, "UP8");                             // 119
            AddColumn(MainTable, "UP9");                             // 120
            AddColumn(MainTable, "UP10");                            // 121
            AddColumn(MainTable, "UD1");                             // 122
            AddColumn(MainTable, "UD2");                             // 123
            AddColumn(MainTable, "UD3");                             // 124
            AddColumn(MainTable, "UD4");                             // 125
            AddColumn(MainTable, "UD5");                             // 126
            AddColumn(MainTable, "UD6");                             // 127
            AddColumn(MainTable, "UD7");                             // 128
            AddColumn(MainTable, "UD8");                             // 129
            AddColumn(MainTable, "UD9");                             // 130
            AddColumn(MainTable, "UD10");                            // 131
            AddColumn(MainTable, "UpCharge_Details");                // 132
            AddColumn(MainTable, "U_QUR_Flag");                      // 133
            AddColumn(MainTable, "Confirmed_Thru_Date");             // 134
            AddColumn(MainTable, "Dont_Make_Active");                // 135
            AddColumn(MainTable, "Product_Number_Criteria_1");       // 136
            AddColumn(MainTable, "Product_Number_Criteria_2");       // 137
            AddColumn(MainTable, "Product_Number_Other");            // 138
            AddColumn(MainTable, "Breakout_by_other_attribute");     // 139
            AddColumn(MainTable, "SKU_Criteria_1");                  // 140
            AddColumn(MainTable, "SKU_Criteria_2");                  // 141
            AddColumn(MainTable, "SKU_Criteria_3");                  // 142
            AddColumn(MainTable, "SKU_Criteria_4");                  // 143  
            AddColumn(MainTable, "SKU");                             // 144
            AddColumn(MainTable, "Inventory_Link");                  // 145
            AddColumn(MainTable, "Inventory_Status");                // 146
            AddColumn(MainTable, "Inventory_Quantity");              // 147
            AddColumn(MainTable, "Distributor_View_Only");           // 148
            AddColumn(MainTable, "SEO_FLG");                         // 149
            AddColumn(MainTable, "Active_Date");                     // 150

            // local field for inserting data to table
            double[][] discountList = GetDiscount();
            string[] skus = GetSku();
            DateTime time = DateTime.Today;

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in skus)
            {
                ArrayList list = GetData(sku);
                DataRow row = MainTable.NewRow();

                row[0] = list[14];                                                 // xid
                row[1] = list[0];                                                  // product name
                row[2] = list[15];                                                 // product number
                row[7] = list[1] + " " + list[2];                                  // description
                row[8] = list[3];                                                  // summary
                row[9] = list[17];                                                 // prod image
                row[10] = time.Year + " Ashlin Executive Catalog:" + time.Year;    // catagory imformation
                row[11] = list[19];                                                // category
                row[12] = list[20];                                                // keywords
                row[13] = list[21];                                                // product color
                row[14] = list[22];                                                // material
                row[15] = "Dimension";                                             // size group
                if (!list[4].Equals(DBNull.Value) && !list[5].Equals(DBNull.Value) && !list[6].Equals(DBNull.Value))
                    row[16] = "Length:" + Math.Round(Convert.ToDouble(list[4]) / 2.54, 2) + ":in;Width:" + Math.Round(Convert.ToDouble(list[5]) / 2.54, 2) + ":in;Height:" + Math.Round(Convert.ToDouble(list[6]) / 2.54, 2) + ":in";    // size values
                row[19] = list[1];                                                 // tradename
                row[21] = "Imprint Option";                                        // option type
                row[22] = "Embroidery - Available Upon Request";                   // option name
                row[23] = "Embroidery - Available Upon Request";                   // option values
                row[24] = 'N';                                                     // can order only one
                row[25] = 'N';                                                     // req for order                                                                                                                                  
                row[27] = "Foil Stamped=Hot Foil Stamping,Embossed=Blind Debossing";     // imprint method
                row[28] = "Ashlin";                                                // linename
                double length = 0;
                double width = 0;
                if (!list[7].Equals(DBNull.Value))
                {
                    length = Convert.ToDouble(list[7]) / 2.54;
                    width = Convert.ToDouble(list[8]) / 2.54;
                }
                row[33] = list[7] + " cm x " + list[8] + " cm/" + Math.Round(length, 2) + "\" x " + Math.Round(width, 2) + '"';    // imprint size
                row[39] = "20-25:Standard Delivery:  4-5 Weeks Delivery; includes a single location imprint";                      // production time
                row[40] = 'Y';                                                                                                     // rush service
                row[41] = "10:Rush Delivery:  2-2.5 Weeks Delivery (If Possible)";                                                 // rush time 
                if (!list[9].Equals(DBNull.Value) && !list[10].Equals(DBNull.Value) && !list[11].Equals(DBNull.Value))          
                    row[45] = "Length:" + Math.Round(Convert.ToDouble(list[9]) / 2.54, 2) + ":in;Width:" + Math.Round(Convert.ToDouble(list[10]) / 2.54, 2) + ":in;Height:" + Math.Round(Convert.ToDouble(list[11]) / 2.54, 2) + ":in";                                      // shipping dimensions
                if (!list[12].Equals(DBNull.Value))
                    row[46] = Math.Round(Convert.ToDouble(list[12]) / 453.592, 2) + ":lbs";                                        // shipping weight     
                row[48] = "Shippable Weight: " + list[12] + " grams";                                                              // shipping info
                row[49] = 'N';                                                                                                     // ship plain box
                row[53] = "Our products are border and NAFTA friendly and are easily imported into USA Mexico and European Economic Community Countries. Prices do not include import duties or taxes. For other import requirements please call and we will assist you.";   // additional info
                row[56] = "Blank Pricing, 20-25 business days";                                                                    // base price name
                row[57] = "PRTM:20-25";                                                                                            // base price criteria 1
                row[58] = "IMOP:BLANK PRICING OR IMPRINTED PRICING:BLANK PRICING";                                                 // base price criteria 2
                row[59] = 1;                 // q1
                row[60] = 6;                 // q2
                row[61] = 24;                // q3
                row[62] = 50;                // q4
                row[63] = 100;               // q5
                row[64] = 250;               // q6
                row[65] = 500;               // q7
                row[66] = 1000;              // q8
                row[67] = 2500;              // q9
                double msrp = Convert.ToDouble(list[16]) * discountList[7][0];
                double runCharge = list[13].Equals(DBNull.Value) ? Math.Round(msrp * 0.05) / 0.6 : Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[13]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                int k;
                switch (Convert.ToInt32(list[18]))
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
                row[69] = Math.Round(msrp * discountList[k][0], 2);         // p1
                row[70] = Math.Round(msrp * discountList[k][1], 2);         // p2
                row[71] = Math.Round(msrp * discountList[k][2], 2);         // p3
                row[72] = Math.Round(msrp * discountList[k][3], 2);         // p4
                row[73] = Math.Round(msrp * discountList[k][4], 2);         // p5
                row[74] = Math.Round(msrp * discountList[k][5], 2);         // p6
                row[75] = Math.Round(msrp * discountList[k][6], 2);         // p7
                row[76] = Math.Round(msrp * discountList[k][7], 2);         // p8
                row[77] = Math.Round(msrp * discountList[k][8], 2);         // p9
                row[79] = 'R';                                              // d1
                row[80] = 'R';                                              // d2
                row[81] = 'R';                                              // d3
                row[82] = 'R';                                              // d4
                row[83] = 'R';                                              // d5
                row[84] = 'R';                                              // d6
                row[85] = 'R';                                              // d7
                row[86] = 'R';                                              // d8
                row[87] = 'R';                                              // d9
                row[90] = "Blank Product Only";                             // price includes
                row[92] = "CAD";                                            // currency
                row[94] = "List";                                           // price type
                row[96] = "Hot Foil Stamping";                              // upcharge name      
                row[97] = "IMMD:HOT FOIL STAMPING";                         // upcharge criteria 1
                row[99] = "Die Charge";                                     // upcharge type
                row[100] = "Per Order";                                     // upcharge level
                row[101] = 1;                                               // uq1
                row[111] = 93.75;                                           // up1
                row[121] = 'V';                                             // ud1
                row[131] = Math.Round(length) * Math.Round(width) + " Square Inchees (ie. " + Math.Round(length) + 'x' + Math.Round(width) + " inches)";     // upcharge details
                row[133] = new DateTime(time.Year, 12, 31).ToString("MM/dd/yyyy");                                                                           // ocnifrmed thru date
                row[147] = 'N';                                                                                                                              // distributor view only
                row[149] = time.ToString("MMM dd, yyyy");                                                                                                    // active date

                MainTable.Rows.Add(row);
                row = MainTable.NewRow();

                row[21] = "Imprint Option";                                         // option type
                row[22] = "HOT FOIL Color Options";                                 // option name
                row[23] = "Gold,Silver,Custom Colors - Available Upon Request";     // option values
                row[24] = 'N';                                                      // can order only one
                row[25] = 'N';                                                      // req for order
                row[56] = "Blank Pricing, 10 business days";                        // base price name
                row[57] = "RUSH:10";                                                // base price criteria 1
                row[58] = "IMOP:BLANK PRICING OR IMPRINTED PRICING:BLANK PRICING";  // base price criteria 2
                row[59] = 1;                 // q1
                row[60] = 6;                 // q2
                row[61] = 24;                // q3
                row[62] = 50;                // q4
                row[63] = 100;               // q5
                row[64] = 250;               // q6
                row[65] = 500;               // q7
                row[66] = 1000;              // q8
                row[67] = 2500;              // q9
                msrp *= discountList[k][9];
                row[69] = Math.Round(msrp * discountList[k][0], 2);         // p1
                row[70] = Math.Round(msrp * discountList[k][1], 2);         // p2
                row[71] = Math.Round(msrp * discountList[k][2], 2);         // p3
                row[72] = Math.Round(msrp * discountList[k][3], 2);         // p4
                row[73] = Math.Round(msrp * discountList[k][4], 2);         // p5
                row[74] = Math.Round(msrp * discountList[k][5], 2);         // p6
                row[75] = Math.Round(msrp * discountList[k][6], 2);         // p7
                row[76] = Math.Round(msrp * discountList[k][7], 2);         // p8
                row[77] = Math.Round(msrp * discountList[k][8], 2);         // p9
                row[79] = 'R';                                              // d1
                row[80] = 'R';                                              // d2
                row[81] = 'R';                                              // d3
                row[82] = 'R';                                              // d4
                row[83] = 'R';                                              // d5
                row[84] = 'R';                                              // d6
                row[85] = 'R';                                              // d7
                row[86] = 'R';                                              // d8
                row[87] = 'R';                                              // d9
                row[90] = "Blank Product Only";                             // price includes
                row[96] = "Hot Foil Stamping - Over Sized Logos";           // upcharge name      
                row[97] = "IMMD:HOT FOIL STAMPING";                         // upcharge criteria 1
                row[99] = "Other Charge";                                   // upcharge type
                row[100] = "Other";                                         // upcharge level
                row[101] = 1;                                               // uq1
                row[111] = 5.0;                                             // up1
                row[121] = 'Z';                                             // ud1
                row[131] = "Per Square Inch";                               // upcharge details

                MainTable.Rows.Add(row);
                row = MainTable.NewRow();

                row[21] = "Imprint Option";                                             // option type
                row[22] = "Blank Pricing or Imprinted Pricing";                         // option name
                row[23] = "Blank Pricing,Imprinted Pricing";                            // option values
                row[24] = 'N';                                                          // can order only one
                row[25] = 'N';                                                          // req for order
                row[56] = "Imprinted Pricing, 20-25 business days";                     // base price name
                row[57] = "PRTM:20-25";                                                 // base price criteria 1
                row[58] = "IMOP:BLANK PRICING OR IMPRINTED PRICING:IMPRINTED PRICING";  // base price criteria 2
                row[59] = 1;                 // q1
                row[60] = 6;                 // q2
                row[61] = 24;                // q3
                row[62] = 50;                // q4
                row[63] = 100;               // q5
                row[64] = 250;               // q6
                row[65] = 500;               // q7
                row[66] = 1000;              // q8
                row[67] = 2500;              // q9
                msrp = (Convert.ToDouble(list[16]) + runCharge) * discountList[7][0];
                row[69] = Math.Round(msrp * discountList[k][0], 2);         // p1
                row[70] = Math.Round(msrp * discountList[k][1], 2);         // p2
                row[71] = Math.Round(msrp * discountList[k][2], 2);         // p3
                row[72] = Math.Round(msrp * discountList[k][3], 2);         // p4
                row[73] = Math.Round(msrp * discountList[k][4], 2);         // p5
                row[74] = Math.Round(msrp * discountList[k][5], 2);         // p6
                row[75] = Math.Round(msrp * discountList[k][6], 2);         // p7
                row[76] = Math.Round(msrp * discountList[k][7], 2);         // p8
                row[77] = Math.Round(msrp * discountList[k][8], 2);         // p9
                row[79] = 'R';                                              // d1
                row[80] = 'R';                                              // d2
                row[81] = 'R';                                              // d3
                row[82] = 'R';                                              // d4
                row[83] = 'R';                                              // d5
                row[84] = 'R';                                              // d6
                row[85] = 'R';                                              // d7
                row[86] = 'R';                                              // d8
                row[87] = 'R';                                              // d9
                row[90] = "a Single Location Imprint";                      // price includes
                row[96] = "Blind Debossing";                                // upcharge name      
                row[97] = "IMMD:BLIND DEBOSSING";                           // upcharge criteria 1
                row[99] = "Die Charge";                                     // upcharge type
                row[100] = "Per Order";                                     // upcharge level
                row[101] = 1;                                               // uq1
                row[111] = 93.75;                                           // up1
                row[121] = 'V';                                             // ud1
                row[131] = "4 Square Inches (ie. 2x2 inches)";              // upcharge details

                MainTable.Rows.Add(row);
                row = MainTable.NewRow();

                row[56] = "Imprinted Pricing, 10 business days";                        // base price name
                row[57] = "RUSH:10";                                                    // base price criteria 1
                row[58] = "IMOP:BLANK PRICING OR IMPRINTED PRICING:IMPRINTED PRICING";  // base price criteria 2
                row[59] = 1;                 // q1
                row[60] = 6;                 // q2
                row[61] = 24;                // q3
                row[62] = 50;                // q4
                row[63] = 100;               // q5
                row[64] = 250;               // q6
                row[65] = 500;               // q7
                row[66] = 1000;              // q8
                row[67] = 2500;              // q9
                msrp *= discountList[k][9];
                row[69] = Math.Round(msrp * discountList[k][0], 2);         // p1
                row[70] = Math.Round(msrp * discountList[k][1], 2);         // p2
                row[71] = Math.Round(msrp * discountList[k][2], 2);         // p3
                row[72] = Math.Round(msrp * discountList[k][3], 2);         // p4
                row[73] = Math.Round(msrp * discountList[k][4], 2);         // p5
                row[74] = Math.Round(msrp * discountList[k][5], 2);         // p6
                row[75] = Math.Round(msrp * discountList[k][6], 2);         // p7
                row[76] = Math.Round(msrp * discountList[k][7], 2);         // p8
                row[77] = Math.Round(msrp * discountList[k][8], 2);         // p9
                row[79] = 'R';                                              // d1
                row[80] = 'R';                                              // d2
                row[81] = 'R';                                              // d3
                row[82] = 'R';                                              // d4
                row[83] = 'R';                                              // d5
                row[84] = 'R';                                              // d6
                row[85] = 'R';                                              // d7
                row[86] = 'R';                                              // d8
                row[87] = 'R';                                              // d9
                row[90] = "a Single Location Imprint";                      // price includes
                row[96] = "Blind Debossing - Over Sized Logos";             // upcharge name      
                row[97] = "IMMD:BLIND DEBOSSING";                           // upcharge criteria 1
                row[99] = "Run Charge";                                     // upcharge type
                row[100] = "Per Quantity";                                  // upcharge level
                row[101] = 1;                                               // uq1
                row[111] = 5.0;                                             // up1
                row[121] = 'Z';                                             // ud1
                row[131] = "Per Square Inch";                               // upcharge details

                MainTable.Rows.Add(row);
                row = MainTable.NewRow();

                row[96] = "Embroidery - Available Upon Request";            // upcharge name      
                row[97] = "IMOP:EMBROIDERY - AVAILABLE UPON REQUEST:EMBROIDERY - AVAILABLE UPON REQUEST";    // upcharge criteria 1
                row[99] = "Imprint Option Charge";                          // upcharge type
                row[100] = "Other";                                         // upcharge level
                row[132] = 'Y';

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_Website = 'True'", Connection);
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

            // grab data from database
            // [0] product name, [1] description, [2] description, [3] summary, [4] ~ [6] size values, [7] & [8] imprint size, [9] ~ [11] shipping dimensions, [12] shipping weight, [13] for runcharge calculation
            //                     & tradename
            // [14] xid, [15] product number, [16] for price calculation, [17] prod image, [18] for price calculation
            // [19] category, [20] keywords, [21] product color, [22] material
            SqlCommand commnad = new SqlCommand("SELECT Short_Description, Design_Service_Fashion_Name_Ashlin, Extended_Description, Design_Online, Height_cm, Width_cm, Depth_cm, Imprint_Height_cm, Imprint_Width_cm, Shippable_Height_cm, Shippable_Width_cm, Shippable_Depth_cm, Shippable_Weight_grams, Components, " +
                                                "ASI_XID, SKU_Ashlin, Base_Price, Image_1_Path, sku.Pricing_Tier, " +
                                                "Design_Service_Family_Description, Design_Service_Family_KeyWords_General, " +
                                                "Colour_Online, Material_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 22; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[8][];

            //  [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard, [9] rush c
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_C_25_wks] FROM Discount_Matrix", Connection);

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 6; i++)
            {
                double[] itemList = new double[10];
                reader.Read();
                for (int j = 0; j <= 9; j++)
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
            list[7] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }
    }
}
