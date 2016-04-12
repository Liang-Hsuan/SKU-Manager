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
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "XID");                             // 1
            AddColumn(mainTable, "Product_Name");                    // 2
            AddColumn(mainTable, "Product_Number");                  // 3
            AddColumn(mainTable, "Product_SKU");                     // 4
            AddColumn(mainTable, "Product_Inventory_Link");          // 5
            AddColumn(mainTable, "Product_Inventory_Status");        // 6
            AddColumn(mainTable, "Product_Inventory_Quantity");      // 7
            AddColumn(mainTable, "Description");                     // 8
            AddColumn(mainTable, "Summary");                         // 9
            AddColumn(mainTable, "Prod_Image");                      // 10
            AddColumn(mainTable, "Catalog_Information");             // 11
            AddColumn(mainTable, "Category");                        // 12
            AddColumn(mainTable, "Keywords");                        // 13
            AddColumn(mainTable, "Product_Color");                   // 14
            AddColumn(mainTable, "Material");                        // 15
            AddColumn(mainTable, "Size_Group");                      // 16
            AddColumn(mainTable, "Size_Values");                     // 17
            AddColumn(mainTable, "Shape");                           // 18
            AddColumn(mainTable, "Theme");                           // 19
            AddColumn(mainTable, "Tradename");                       // 20
            AddColumn(mainTable, "Origin");                          // 21
            AddColumn(mainTable, "Option_Type");                     // 22
            AddColumn(mainTable, "Option_Name");                     // 23
            AddColumn(mainTable, "Option_Values");                   // 24
            AddColumn(mainTable, "Can_order_only_one");              // 25
            AddColumn(mainTable, "Req_for_order");                   // 26
            AddColumn(mainTable, "Option_Additional_Info");          // 27
            AddColumn(mainTable, "Imprint_Method");                  // 28
            AddColumn(mainTable, "Linename");                        // 29
            AddColumn(mainTable, "Artwork");                         // 30
            AddColumn(mainTable, "Imprint_Color");                   // 31
            AddColumn(mainTable, "Sold_Unimprinted");                // 32
            AddColumn(mainTable, "Personalization");                 // 33
            AddColumn(mainTable, "Imprint_Size");                    // 34
            AddColumn(mainTable, "Imprint_Location");                // 35
            AddColumn(mainTable, "Additional_Color");                // 36
            AddColumn(mainTable, "Additional_Location");             // 37
            AddColumn(mainTable, "Product_Sample");                  // 38
            AddColumn(mainTable, "Spec_Sample");                     // 39
            AddColumn(mainTable, "Production_Time");                 // 40
            AddColumn(mainTable, "Rush_Service");                    // 41
            AddColumn(mainTable, "Rush_time");                       // 42
            AddColumn(mainTable, "Same_Day_Service");                // 43
            AddColumn(mainTable, "Packaging");                       // 44
            AddColumn(mainTable, "Shipping_Items");                  // 45
            AddColumn(mainTable, "Shipping_Dimensions");             // 46
            AddColumn(mainTable, "Shipping_Weight");                 // 47
            AddColumn(mainTable, "Shipper_Bills_By");                // 48
            AddColumn(mainTable, "Shipping_Info");                   // 49
            AddColumn(mainTable, "Ship_Plain_Box");                  // 50
            AddColumn(mainTable, "Comp_Cert");                       // 51
            AddColumn(mainTable, "Product_Data_Sheet");              // 52
            AddColumn(mainTable, "Safety_Warnings");                 // 53
            AddColumn(mainTable, "Additional_Info");                 // 54
            AddColumn(mainTable, "Distributor_Only");                // 55
            AddColumn(mainTable, "Disclaimer");                      // 56
            AddColumn(mainTable, "Base_Price_Name");                 // 57
            AddColumn(mainTable, "Base_Price_Criteria_1");           // 58
            AddColumn(mainTable, "Base_Price_Criteria_2");           // 59
            AddColumn(mainTable, "Q1");                              // 60
            AddColumn(mainTable, "Q2");                              // 61
            AddColumn(mainTable, "Q3");                              // 62
            AddColumn(mainTable, "Q4");                              // 63
            AddColumn(mainTable, "Q5");                              // 64
            AddColumn(mainTable, "Q6");                              // 65
            AddColumn(mainTable, "Q7");                              // 66
            AddColumn(mainTable, "Q8");                              // 67
            AddColumn(mainTable, "Q9");                              // 68
            AddColumn(mainTable, "Q10");                             // 69
            AddColumn(mainTable, "P1");                              // 70
            AddColumn(mainTable, "P2");                              // 71
            AddColumn(mainTable, "P3");                              // 72
            AddColumn(mainTable, "P4");                              // 73
            AddColumn(mainTable, "P5");                              // 74
            AddColumn(mainTable, "P6");                              // 75
            AddColumn(mainTable, "P7");                              // 76
            AddColumn(mainTable, "P8");                              // 77
            AddColumn(mainTable, "P9");                              // 78
            AddColumn(mainTable, "P10");                             // 79
            AddColumn(mainTable, "D1");                              // 80
            AddColumn(mainTable, "D2");                              // 81
            AddColumn(mainTable, "D3");                              // 82
            AddColumn(mainTable, "D4");                              // 83
            AddColumn(mainTable, "D5");                              // 84
            AddColumn(mainTable, "D6");                              // 85
            AddColumn(mainTable, "D7");                              // 86
            AddColumn(mainTable, "D8");                              // 87
            AddColumn(mainTable, "D9");                              // 88
            AddColumn(mainTable, "D10");                             // 89
            AddColumn(mainTable, "Product_Number_Price");            // 90
            AddColumn(mainTable, "Price_Includes");                  // 91
            AddColumn(mainTable, "QUR_Flag");                        // 92
            AddColumn(mainTable, "Currency");                        // 93
            AddColumn(mainTable, "Less_Than_Min");                   // 94
            AddColumn(mainTable, "Price_Type");                      // 95
            AddColumn(mainTable, "Breakout_by_price");               // 96
            AddColumn(mainTable, "Upcharge_Name");                   // 97
            AddColumn(mainTable, "Upcharge_Criteria_1");             // 98
            AddColumn(mainTable, "Upcharge_Criteria_2");             // 99
            AddColumn(mainTable, "Upcharge_Type");                   // 100
            AddColumn(mainTable, "Upcharge_Level");                  // 101
            AddColumn(mainTable, "UQ1");                             // 102
            AddColumn(mainTable, "UQ2");                             // 103
            AddColumn(mainTable, "UQ3");                             // 104
            AddColumn(mainTable, "UQ4");                             // 105
            AddColumn(mainTable, "UQ5");                             // 106
            AddColumn(mainTable, "UQ6");                             // 107
            AddColumn(mainTable, "UQ7");                             // 108
            AddColumn(mainTable, "UQ8");                             // 109
            AddColumn(mainTable, "UQ9");                             // 110
            AddColumn(mainTable, "UQ10");                            // 111
            AddColumn(mainTable, "UP1");                             // 112
            AddColumn(mainTable, "UP2");                             // 113
            AddColumn(mainTable, "UP3");                             // 114
            AddColumn(mainTable, "UP4");                             // 115
            AddColumn(mainTable, "UP5");                             // 116
            AddColumn(mainTable, "UP6");                             // 117
            AddColumn(mainTable, "UP7");                             // 118
            AddColumn(mainTable, "UP8");                             // 119
            AddColumn(mainTable, "UP9");                             // 120
            AddColumn(mainTable, "UP10");                            // 121
            AddColumn(mainTable, "UD1");                             // 122
            AddColumn(mainTable, "UD2");                             // 123
            AddColumn(mainTable, "UD3");                             // 124
            AddColumn(mainTable, "UD4");                             // 125
            AddColumn(mainTable, "UD5");                             // 126
            AddColumn(mainTable, "UD6");                             // 127
            AddColumn(mainTable, "UD7");                             // 128
            AddColumn(mainTable, "UD8");                             // 129
            AddColumn(mainTable, "UD9");                             // 130
            AddColumn(mainTable, "UD10");                            // 131
            AddColumn(mainTable, "UpCharge_Details");                // 132
            AddColumn(mainTable, "U_QUR_Flag");                      // 133
            AddColumn(mainTable, "Confirmed_Thru_Date");             // 134
            AddColumn(mainTable, "Dont_Make_Active");                // 135
            AddColumn(mainTable, "Product_Number_Criteria_1");       // 136
            AddColumn(mainTable, "Product_Number_Criteria_2");       // 137
            AddColumn(mainTable, "Product_Number_Other");            // 138
            AddColumn(mainTable, "Breakout_by_other_attribute");     // 139
            AddColumn(mainTable, "SKU_Criteria_1");                  // 140
            AddColumn(mainTable, "SKU_Criteria_2");                  // 141
            AddColumn(mainTable, "SKU_Criteria_3");                  // 142
            AddColumn(mainTable, "SKU_Criteria_4");                  // 143  
            AddColumn(mainTable, "SKU");                             // 144
            AddColumn(mainTable, "Inventory_Link");                  // 145
            AddColumn(mainTable, "Inventory_Status");                // 146
            AddColumn(mainTable, "Inventory_Quantity");              // 147
            AddColumn(mainTable, "Distributor_View_Only");           // 148
            AddColumn(mainTable, "SEO_FLG");                         // 149
            AddColumn(mainTable, "Active_Date");                     // 150

            // local field for inserting data to table
            double[][] discountList = GetDiscount();
            string[] skus = GetSku();
            DateTime time = DateTime.Today;

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skus)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

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
                double msrp = Convert.ToDouble(list[16]) * discountList[5][0];
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
                row[92] = "USD";                                            // currency
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

                mainTable.Rows.Add(row);
                row = mainTable.NewRow();

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

                mainTable.Rows.Add(row);
                row = mainTable.NewRow();

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
                msrp = (Convert.ToDouble(list[16]) + runCharge) * discountList[5][0];
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

                mainTable.Rows.Add(row);
                row = mainTable.NewRow();

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

                mainTable.Rows.Add(row);
                row = mainTable.NewRow();

                row[96] = "Embroidery - Available Upon Request";            // upcharge name      
                row[97] = "IMOP:EMBROIDERY - AVAILABLE UPON REQUEST:EMBROIDERY - AVAILABLE UPON REQUEST";                           // upcharge criteria 1
                row[99] = "Imprint Option Charge";                                     // upcharge type
                row[100] = "Other";                                     // upcharge level
                row[132] = 'Y';

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True'", connection);
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
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 22; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[6][];

            //  [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard, [9] rush c
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_C_25_wks] FROM Discount_Matrix", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
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
            list[5] = new[] { reader.GetDouble(0) };
            connection.Close();

            return list;
        }
    }
}
