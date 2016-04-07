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
            skuList = getSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "XID");                             // 1
            addColumn(mainTable, "Product_Name");                    // 2
            addColumn(mainTable, "Product_Number");                  // 3
            addColumn(mainTable, "Product_SKU");                     // 4
            addColumn(mainTable, "Product_Inventory_Link");          // 5
            addColumn(mainTable, "Product_Inventory_Status");        // 6
            addColumn(mainTable, "Product_Inventory_Quantity");      // 7
            addColumn(mainTable, "Description");                     // 8
            addColumn(mainTable, "Summary");                         // 9
            addColumn(mainTable, "Prod_Image");                      // 10
            addColumn(mainTable, "Catalog_Information");             // 11
            addColumn(mainTable, "Category");                        // 12
            addColumn(mainTable, "Keywords");                        // 13
            addColumn(mainTable, "Product_Color");                   // 14
            addColumn(mainTable, "Material");                        // 15
            addColumn(mainTable, "Size_Group");                      // 16
            addColumn(mainTable, "Size_Values");                     // 17
            addColumn(mainTable, "Shape");                           // 18
            addColumn(mainTable, "Theme");                           // 19
            addColumn(mainTable, "Tradename");                       // 20
            addColumn(mainTable, "Origin");                          // 21
            addColumn(mainTable, "Option_Type");                     // 22
            addColumn(mainTable, "Option_Name");                     // 23
            addColumn(mainTable, "Option_Values");                   // 24
            addColumn(mainTable, "Can_order_only_one");              // 25
            addColumn(mainTable, "Req_for_order");                   // 26
            addColumn(mainTable, "Option_Additional_Info");          // 27
            addColumn(mainTable, "Imprint_Method");                  // 28
            addColumn(mainTable, "Linename");                        // 29
            addColumn(mainTable, "Artwork");                         // 30
            addColumn(mainTable, "Imprint_Color");                   // 31
            addColumn(mainTable, "Sold_Unimprinted");                // 32
            addColumn(mainTable, "Personalization");                 // 33
            addColumn(mainTable, "Imprint_Size");                    // 34
            addColumn(mainTable, "Imprint_Location");                // 35
            addColumn(mainTable, "Additional_Color");                // 36
            addColumn(mainTable, "Additional_Location");             // 37
            addColumn(mainTable, "Product_Sample");                  // 38
            addColumn(mainTable, "Spec_Sample");                     // 39
            addColumn(mainTable, "Production_Time");                 // 40
            addColumn(mainTable, "Rush_Service");                    // 41
            addColumn(mainTable, "Rush_time");                       // 42
            addColumn(mainTable, "Same_Day_Service");                // 43
            addColumn(mainTable, "Packaging");                       // 44
            addColumn(mainTable, "Shipping_Items");                  // 45
            addColumn(mainTable, "Shipping_Dimensions");             // 46
            addColumn(mainTable, "Shipping_Weight");                 // 47
            addColumn(mainTable, "Shipper_Bills_By");                // 48
            addColumn(mainTable, "Shipping_Info");                   // 49
            addColumn(mainTable, "Ship_Plain_Box");                  // 50
            addColumn(mainTable, "Comp_Cert");                       // 51
            addColumn(mainTable, "Product_Data_Sheet");              // 52
            addColumn(mainTable, "Safety_Warnings");                 // 53
            addColumn(mainTable, "Additional_Info");                 // 54
            addColumn(mainTable, "Distributor_Only");                // 55
            addColumn(mainTable, "Disclaimer");                      // 56
            addColumn(mainTable, "Base_Price_Name");                 // 57
            addColumn(mainTable, "Base_Price_Criteria_1");           // 58
            addColumn(mainTable, "Base_Price_Criteria_2");           // 59
            addColumn(mainTable, "Q1");                              // 60
            addColumn(mainTable, "Q2");                              // 61
            addColumn(mainTable, "Q3");                              // 62
            addColumn(mainTable, "Q4");                              // 63
            addColumn(mainTable, "Q5");                              // 64
            addColumn(mainTable, "Q6");                              // 65
            addColumn(mainTable, "Q7");                              // 66
            addColumn(mainTable, "Q8");                              // 67
            addColumn(mainTable, "Q9");                              // 68
            addColumn(mainTable, "Q10");                             // 69
            addColumn(mainTable, "P1");                              // 70
            addColumn(mainTable, "P2");                              // 71
            addColumn(mainTable, "P3");                              // 72
            addColumn(mainTable, "P4");                              // 73
            addColumn(mainTable, "P5");                              // 74
            addColumn(mainTable, "P6");                              // 75
            addColumn(mainTable, "P7");                              // 76
            addColumn(mainTable, "P8");                              // 77
            addColumn(mainTable, "P9");                              // 78
            addColumn(mainTable, "P10");                             // 79
            addColumn(mainTable, "D1");                              // 80
            addColumn(mainTable, "D2");                              // 81
            addColumn(mainTable, "D3");                              // 82
            addColumn(mainTable, "D4");                              // 83
            addColumn(mainTable, "D5");                              // 84
            addColumn(mainTable, "D6");                              // 85
            addColumn(mainTable, "D7");                              // 86
            addColumn(mainTable, "D8");                              // 87
            addColumn(mainTable, "D9");                              // 88
            addColumn(mainTable, "D10");                             // 89
            addColumn(mainTable, "Product_Number_Price");            // 90
            addColumn(mainTable, "Price_Includes");                  // 91
            addColumn(mainTable, "QUR_Flag");                        // 92
            addColumn(mainTable, "Currency");                        // 93
            addColumn(mainTable, "Less_Than_Min");                   // 94
            addColumn(mainTable, "Price_Type");                      // 95
            addColumn(mainTable, "Breakout_by_price");               // 96
            addColumn(mainTable, "Upcharge_Name");                   // 97
            addColumn(mainTable, "Upcharge_Criteria_1");             // 98
            addColumn(mainTable, "Upcharge_Criteria_2");             // 99
            addColumn(mainTable, "Upcharge_Type");                   // 100
            addColumn(mainTable, "Upcharge_Level");                  // 101
            addColumn(mainTable, "UQ1");                             // 102
            addColumn(mainTable, "UQ2");                             // 103
            addColumn(mainTable, "UQ3");                             // 104
            addColumn(mainTable, "UQ4");                             // 105
            addColumn(mainTable, "UQ5");                             // 106
            addColumn(mainTable, "UQ6");                             // 107
            addColumn(mainTable, "UQ7");                             // 108
            addColumn(mainTable, "UQ8");                             // 109
            addColumn(mainTable, "UQ9");                             // 110
            addColumn(mainTable, "UQ10");                            // 111
            addColumn(mainTable, "UP1");                             // 112
            addColumn(mainTable, "UP2");                             // 113
            addColumn(mainTable, "UP3");                             // 114
            addColumn(mainTable, "UP4");                             // 115
            addColumn(mainTable, "UP5");                             // 116
            addColumn(mainTable, "UP6");                             // 117
            addColumn(mainTable, "UP7");                             // 118
            addColumn(mainTable, "UP8");                             // 119
            addColumn(mainTable, "UP9");                             // 120
            addColumn(mainTable, "UP10");                            // 121
            addColumn(mainTable, "UD1");                             // 122
            addColumn(mainTable, "UD2");                             // 123
            addColumn(mainTable, "UD3");                             // 124
            addColumn(mainTable, "UD4");                             // 125
            addColumn(mainTable, "UD5");                             // 126
            addColumn(mainTable, "UD6");                             // 127
            addColumn(mainTable, "UD7");                             // 128
            addColumn(mainTable, "UD8");                             // 129
            addColumn(mainTable, "UD9");                             // 130
            addColumn(mainTable, "UD10");                            // 131
            addColumn(mainTable, "UpCharge_Details");                // 132
            addColumn(mainTable, "U_QUR_Flag");                      // 133
            addColumn(mainTable, "Confirmed_Thru_Date");             // 134
            addColumn(mainTable, "Dont_Make_Active");                // 135
            addColumn(mainTable, "Product_Number_Criteria_1");       // 136
            addColumn(mainTable, "Product_Number_Criteria_2");       // 137
            addColumn(mainTable, "Product_Number_Other");            // 138
            addColumn(mainTable, "Breakout_by_other_attribute");     // 139
            addColumn(mainTable, "SKU_Criteria_1");                  // 140
            addColumn(mainTable, "SKU_Criteria_2");                  // 141
            addColumn(mainTable, "SKU_Criteria_3");                  // 142
            addColumn(mainTable, "SKU_Criteria_4");                  // 143  
            addColumn(mainTable, "SKU");                             // 144
            addColumn(mainTable, "Inventory_Link");                  // 145
            addColumn(mainTable, "Inventory_Status");                // 146
            addColumn(mainTable, "Inventory_Quantity");              // 147
            addColumn(mainTable, "Distributor_View_Only");           // 148
            addColumn(mainTable, "SEO_FLG");                         // 149
            addColumn(mainTable, "Active_Date");                     // 150

            // local field for inserting data to table
            double[] discountList = getDiscount();
            string[] skuList = getSku();
            DateTime time = DateTime.Today;

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = list[14];                                                 // xid
                row[1] = list[0];                                                  // product name
                row[2] = list[15];                                                 // product number
                row[7] = list[1] + " " + list[2];                                  // description
                row[8] = list[3];                                                  // summary
                row[9] = list[17];                                                 // prod image
                row[10] = time.Year + " Ashlin Executive Catalog:" + time.Year;    // catagory imformation
                row[11] = list[18];                                                // category
                row[12] = list[19];                                                // keywords
                row[13] = list[20];                                                // product color
                row[14] = list[21];                                                // material
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
                double msrp = Convert.ToDouble(list[16]) * discountList[10];
                double runCharge = list[13].Equals(DBNull.Value) ? runCharge = Math.Round(msrp * 0.05) / 0.6 : runCharge = Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[13]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                row[69] = Math.Round(msrp * discountList[0], 2);            // p1
                row[70] = Math.Round(msrp * discountList[1], 2);            // p2
                row[71] = Math.Round(msrp * discountList[2], 2);            // p3
                row[72] = Math.Round(msrp * discountList[3], 2);            // p4
                row[73] = Math.Round(msrp * discountList[4], 2);            // p5
                row[74] = Math.Round(msrp * discountList[5], 2);            // p6
                row[75] = Math.Round(msrp * discountList[6], 2);            // p7
                row[76] = Math.Round(msrp * discountList[7], 2);            // p8
                row[77] = Math.Round(msrp * discountList[8], 2);            // p9
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
                msrp *= discountList[9];
                row[69] = Math.Round(msrp * discountList[0], 2);            // p1
                row[70] = Math.Round(msrp * discountList[1], 2);            // p2
                row[71] = Math.Round(msrp * discountList[2], 2);            // p3
                row[72] = Math.Round(msrp * discountList[3], 2);            // p4
                row[73] = Math.Round(msrp * discountList[4], 2);            // p5
                row[74] = Math.Round(msrp * discountList[5], 2);            // p6
                row[75] = Math.Round(msrp * discountList[6], 2);            // p7
                row[76] = Math.Round(msrp * discountList[7], 2);            // p8
                row[77] = Math.Round(msrp * discountList[8], 2);            // p9
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
                msrp = (Convert.ToDouble(list[16]) + runCharge) * discountList[10];
                row[69] = Math.Round(msrp * discountList[0], 2);            // p1
                row[70] = Math.Round(msrp * discountList[1], 2);            // p2
                row[71] = Math.Round(msrp * discountList[2], 2);            // p3
                row[72] = Math.Round(msrp * discountList[3], 2);            // p4
                row[73] = Math.Round(msrp * discountList[4], 2);            // p5
                row[74] = Math.Round(msrp * discountList[5], 2);            // p6
                row[75] = Math.Round(msrp * discountList[6], 2);            // p7
                row[76] = Math.Round(msrp * discountList[7], 2);            // p8
                row[77] = Math.Round(msrp * discountList[8], 2);            // p9
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
                msrp *= discountList[9];
                row[69] = Math.Round(msrp * discountList[0], 2);            // p1
                row[70] = Math.Round(msrp * discountList[1], 2);            // p2
                row[71] = Math.Round(msrp * discountList[2], 2);            // p3
                row[72] = Math.Round(msrp * discountList[3], 2);            // p4
                row[73] = Math.Round(msrp * discountList[4], 2);            // p5
                row[74] = Math.Round(msrp * discountList[5], 2);            // p6
                row[75] = Math.Round(msrp * discountList[6], 2);            // p7
                row[76] = Math.Round(msrp * discountList[7], 2);            // p8
                row[77] = Math.Round(msrp * discountList[8], 2);            // p9
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
        protected sealed override string[] getSku()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True'", connection);
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

            // grab data from database
            // [0] product name, [1] description, [2] description, [3] summary, [4] ~ [6] size values, [7] & [8] imprint size, [9] ~ [11] shipping dimensions, [12] shipping weight, [13] for runcharge calculation
            //                     & tradename
            // [14] xid, [15] product number, [16] for price calculation, [17] prod image
            // [18] category, [19] keywords, [20] product color, [21] material
            SqlCommand commnad = new SqlCommand("SELECT Short_Description, Design_Service_Fashion_Name_Ashlin, Extended_Description, Design_Online, Height_cm, Width_cm, Depth_cm, Imprint_Height_cm, Imprint_Width_cm, Shippable_Height_cm, Shippable_Width_cm, Shippable_Depth_cm, Shippable_Weight_grams, Components, " +
                                                "ASI_XID, SKU_Ashlin, Base_Price, Image_1_Path, " +
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
            for (int i = 0; i <= 21; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[] getDiscount()
        {
            double[] list = new double[11];

            //  [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard, [9] rush c
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_C_25_wks] FROM ref_discount_matrix", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 9; i++)
                list[i] = reader.GetDouble(i);
            reader.Close();

            // [10] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[10] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
