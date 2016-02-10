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
    class UducatExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public UducatExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "SKU");                    // 1
            addColumn(mainTable, "Category");               // 2
            addColumn(mainTable, "Category1EN");            // 3
            addColumn(mainTable, "Category1FR");            // 4
            addColumn(mainTable, "Category2EN");            // 5
            addColumn(mainTable, "Category2FR");            // 6
            addColumn(mainTable, "Category3EN");            // 7
            addColumn(mainTable, "Category3FR");            // 8
            addColumn(mainTable, "Category4EN");            // 9
            addColumn(mainTable, "Category4FR");            // 10
            addColumn(mainTable, "Category5EN");            // 11
            addColumn(mainTable, "Category5FR");            // 12
            addColumn(mainTable, "NameEN");                 // 13
            addColumn(mainTable, "NameFR");                 // 14
            addColumn(mainTable, "DescriptionEN");          // 15
            addColumn(mainTable, "DescriptionFR");          // 16
            addColumn(mainTable, "Image");                  // 17
            addColumn(mainTable, "CatelogPage");            // 18
            addColumn(mainTable, "CatelogYear");            // 19
            addColumn(mainTable, "Active");                 // 20
            addColumn(mainTable, "CartQtrMin");             // 21
            addColumn(mainTable, "CartQtyMax");             // 23
            addColumn(mainTable, "CADCertified");           // 24
            addColumn(mainTable, "CADValidUntilDate");      // 25
            addColumn(mainTable, "CADGeneralInfoEN");       // 26
            addColumn(mainTable, "CADGeneralInfoFR");       // 27
            addColumn(mainTable, "CADMinQty1");             // 28
            addColumn(mainTable, "CADMaxQty1");             // 29
            addColumn(mainTable, "CADPrice1");              // 30
            addColumn(mainTable, "CADSalePrice1");          // 31
            addColumn(mainTable, "CADPriceCode1");          // 32
            addColumn(mainTable, "CADPriceMsg1EN");         // 33
            addColumn(mainTable, "CADPriceMsg1FR");         // 34   
            addColumn(mainTable, "CADMINQty2");             // 35
            addColumn(mainTable, "CADMAXQTY2");             // 36
            addColumn(mainTable, "CADSalePrice2");          // 37
            addColumn(mainTable, "CADPrice2");              // 38
            addColumn(mainTable, "CADPriceCode2");          // 39
            addColumn(mainTable, "CADPriceMsg2EN");         // 40
            addColumn(mainTable, "CADPriceMsg2FR");         // 41
            addColumn(mainTable, "CADMinQty3");             // 42
            addColumn(mainTable, "CADMAXQty3");             // 43
            addColumn(mainTable, "CADPrice3");              // 44
            addColumn(mainTable, "CADSalePrice3");          // 45
            addColumn(mainTable, "CADPriceCode3");          // 46
            addColumn(mainTable, "CADPriceMsg3EN");         // 47
            addColumn(mainTable, "CADPriceMsg3FR");         // 48
            addColumn(mainTable, "CADMinQty4");             // 49
            addColumn(mainTable, "CADMAXQty4");             // 50
            addColumn(mainTable, "CADPrice4");              // 51
            addColumn(mainTable, "CADSalePrice4");          // 52
            addColumn(mainTable, "CADPriceCode4");          // 53
            addColumn(mainTable, "CADPriceMsg4EN");         // 54
            addColumn(mainTable, "CADPriceMsg4FR");         // 55
            addColumn(mainTable, "CADMinQty5");             // 56
            addColumn(mainTable, "CADMAXQty5");             // 57
            addColumn(mainTable, "CADPrice5");              // 58
            addColumn(mainTable, "CADSalePrice5");          // 59
            addColumn(mainTable, "CADPriceCode5");          // 60
            addColumn(mainTable, "CADPriceMsg5EN");         // 61
            addColumn(mainTable, "CADPriceMsg5FR");         // 62
            addColumn(mainTable, "CADMinQty6");             // 63
            addColumn(mainTable, "CADMAXQty6");             // 64
            addColumn(mainTable, "CADPrice6");              // 65
            addColumn(mainTable, "CADSalePrice6");          // 66
            addColumn(mainTable, "CADPriceCode6");          // 67
            addColumn(mainTable, "CADPriceMsg6EN");         // 68
            addColumn(mainTable, "CADPriceMsg6FR");         // 69
            addColumn(mainTable, "CADMinQty7");             // 70
            addColumn(mainTable, "CADMAXQty7");             // 71
            addColumn(mainTable, "CADPrice7");              // 72
            addColumn(mainTable, "CADSalePrice7");          // 73
            addColumn(mainTable, "CADPriceCode7");          // 74
            addColumn(mainTable, "CADPriceMsg7EN");         // 75
            addColumn(mainTable, "CADPriceMsg7FR");         // 76
            addColumn(mainTable, "CADMinQty8");             // 77
            addColumn(mainTable, "CADMAXQty8");             // 78
            addColumn(mainTable, "CADPrice8");              // 79
            addColumn(mainTable, "CADSalePrice8");          // 80
            addColumn(mainTable, "CADPriceCode8");          // 81
            addColumn(mainTable, "CADPriceMsg8EN");         // 82
            addColumn(mainTable, "CADPriceMsg8FR");         // 83
            addColumn(mainTable, "CADMinQty9");             // 84
            addColumn(mainTable, "CADMAXQty9");             // 85
            addColumn(mainTable, "CADPrice9");              // 86
            addColumn(mainTable, "CADSalePrice9");          // 87
            addColumn(mainTable, "CADPriceCode9");          // 88
            addColumn(mainTable, "CADPriceMsg9EN");         // 89
            addColumn(mainTable, "CADPriceMsg9FR");         // 90
            addColumn(mainTable, "CADMinQty10");            // 91
            addColumn(mainTable, "CADMAXQty10");            // 92
            addColumn(mainTable, "CADPrice10");             // 93
            addColumn(mainTable, "CADSalePrice10");         // 94
            addColumn(mainTable, "CADPriceCode10");         // 95
            addColumn(mainTable, "CADPriceMsg10EN");        // 96
            addColumn(mainTable, "CADPriceMsg10FR");        // 97
            addColumn(mainTable, "CADSaleStartDateTime");   // 98
            addColumn(mainTable, "CADSaleEndDateTime");     // 99
            addColumn(mainTable, "Keywords");               // 100

            // local field for inserting data to table
            DataRow row;
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();
           
                row[0] = sku;                                            // sku 
                row[1] = list[2];                                        // category
                row[12] = "Ashlin® " + list[1] + " " + list[2] + ", " + list[8];  // name en
                row[14] = list[3];                                       // description en
                row[16] = list[6];                                       // image
                row[18] = DateTime.Now.Year;                             // catalog year
                row[19] = list[7];                                       // active
                row[20] = 1;                                             // cart qtr min
                // cad general info en
                row[24] = "CUSTOM COLORS: We have several custom colours available upon enquiry.\n" +
                          "DECORATION OPTIONS: Blind debossing, hot foil stamping (in gold and silver) as well as screen printing.\n" + 
                          "DIE & SETUP: Blind debossing, hot foil stamping (in gold and silver) as well as Custom Colours"; 
                row[26] = 1;                                             // cad min qty1
                row[27] = 5;                                             // cad max qty1
                double msrp = discountList[9] * Convert.ToDouble(list[5]);
                row[28] = msrp * discountList[0];                        // cad price 1
                row[30] = 'C';                                           // cad price code 1 
                row[33] = 6;                                             // cad min qty 2
                row[34] = 23;                                            // cad max qty 2
                row[36] = msrp * discountList[1];                        // cad price 2
                row[37] = 'C';                                           // cad price code 2
                row[40] = 24;                                            // cad min qty 3
                row[41] = 49;                                            // cad max qty 3
                row[42] = msrp * discountList[2];                        // cad price 3
                row[44] = 'C';                                           // cad price code 3
                row[47] = 50;                                            // cad min qty 4
                row[48] = 99;                                            // cad max qty 4
                row[49] = msrp * discountList[3];                        // cad price 4
                row[51] = 'C';                                           // cad price code 4
                row[54] = 100;                                           // cad min qty 5
                row[55] = 249;                                           // cad max qty 5
                row[56] = msrp * discountList[4];                        // cad price 5
                row[58] = 'C';                                           // cad price code 5
                row[61] = 250;                                           // cad min qty 6
                row[62] = 499;                                           // cad max qty 6
                row[63] = msrp * discountList[5];                        // cad price 6
                row[65] = 'C';                                           // cad price code 6
                row[68] = 500;                                           // cad min qty 7
                row[69] = 999;                                           // cad max qty 7
                row[70] = msrp * discountList[6];                        // cad price 7
                row[72] = 'C';                                           // cad price code 7
                row[75] = 1000;                                          // cad min qty 8
                row[76] = 2499;                                          // cad max qty 8
                row[77] = msrp * discountList[7];                        // cad price 8
                row[79] = 'C';                                           // cad price code 8
                row[82] = 2500;                                          // cad min qty 8
                row[84] = msrp * discountList[8];                        // cad price 9
                row[86] = 'C';                                           // cad price code 9
                row[98] = list[4];                                       // keywords

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND Design_Service_Code in ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Website_Flag = \'True\' And Design_Service_Family_Code in ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_UDUCAT !=\'\'));", connection);
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

            // allocate design from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            connection.Open();
            // [0] for further looking, [1] name en, [2] category, [3] description en
            //                                         & name en
            SqlCommand command = new SqlCommand("SELECT Design_Service_Family_Code, Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 3; i++)
            {
                list.Add(reader.GetValue(i));
            }
            reader.Close();
            // [4] keywords
            command = new SqlCommand("SELECT Design_Service_family_Category_UDUCAT FROM ref_Families WHERE Design_Service_Family_Code = \'" + list[0] + "\';", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list.Add(reader.GetString(0));
            reader.Close();
            // [5] for all related to price, [6] image, [7] active
            command = new SqlCommand("SELECT Base_Price, Image_1_Path, Active FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 2; i++)
            {
                list.Add(reader.GetValue(i));
            }
            reader.Close();
            // [8] name En
            command = new SqlCommand("SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list.Add(reader.GetString(0));
            connection.Close();

            return list;
        }

        /* a method that return the discount matrix */
        private double[] getDiscount()
        {
            double[] list = new double[10];

            // [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery] "
                                                     + "FROM ref_discount_matrix;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 8; i++)
            {
                list[i] = reader.GetDouble(i);
            }
            reader.Close();
            // [9] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[9] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
