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
    public class UducatExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public UducatExportTable()
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
            AddColumn(mainTable, "SKU");                    // 1
            AddColumn(mainTable, "Category");               // 2
            AddColumn(mainTable, "Category1EN");            // 3
            AddColumn(mainTable, "Category1FR");            // 4
            AddColumn(mainTable, "Category2EN");            // 5
            AddColumn(mainTable, "Category2FR");            // 6
            AddColumn(mainTable, "Category3EN");            // 7
            AddColumn(mainTable, "Category3FR");            // 8
            AddColumn(mainTable, "Category4EN");            // 9
            AddColumn(mainTable, "Category4FR");            // 10
            AddColumn(mainTable, "Category5EN");            // 11
            AddColumn(mainTable, "Category5FR");            // 12
            AddColumn(mainTable, "NameEN");                 // 13
            AddColumn(mainTable, "NameFR");                 // 14
            AddColumn(mainTable, "DescriptionEN");          // 15
            AddColumn(mainTable, "DescriptionFR");          // 16
            AddColumn(mainTable, "Image");                  // 17
            AddColumn(mainTable, "CatelogPage");            // 18
            AddColumn(mainTable, "CatelogYear");            // 19
            AddColumn(mainTable, "Active");                 // 20
            AddColumn(mainTable, "CartQtrMin");             // 21
            AddColumn(mainTable, "CartQtyMax");             // 23
            AddColumn(mainTable, "CADCertified");           // 24
            AddColumn(mainTable, "CADValidUntilDate");      // 25
            AddColumn(mainTable, "CADGeneralInfoEN");       // 26
            AddColumn(mainTable, "CADGeneralInfoFR");       // 27
            AddColumn(mainTable, "CADMinQty1");             // 28
            AddColumn(mainTable, "CADMaxQty1");             // 29
            AddColumn(mainTable, "CADPrice1");              // 30
            AddColumn(mainTable, "CADSalePrice1");          // 31
            AddColumn(mainTable, "CADPriceCode1");          // 32
            AddColumn(mainTable, "CADPriceMsg1EN");         // 33
            AddColumn(mainTable, "CADPriceMsg1FR");         // 34   
            AddColumn(mainTable, "CADMINQty2");             // 35
            AddColumn(mainTable, "CADMAXQTY2");             // 36
            AddColumn(mainTable, "CADSalePrice2");          // 37
            AddColumn(mainTable, "CADPrice2");              // 38
            AddColumn(mainTable, "CADPriceCode2");          // 39
            AddColumn(mainTable, "CADPriceMsg2EN");         // 40
            AddColumn(mainTable, "CADPriceMsg2FR");         // 41
            AddColumn(mainTable, "CADMinQty3");             // 42
            AddColumn(mainTable, "CADMAXQty3");             // 43
            AddColumn(mainTable, "CADPrice3");              // 44
            AddColumn(mainTable, "CADSalePrice3");          // 45
            AddColumn(mainTable, "CADPriceCode3");          // 46
            AddColumn(mainTable, "CADPriceMsg3EN");         // 47
            AddColumn(mainTable, "CADPriceMsg3FR");         // 48
            AddColumn(mainTable, "CADMinQty4");             // 49
            AddColumn(mainTable, "CADMAXQty4");             // 50
            AddColumn(mainTable, "CADPrice4");              // 51
            AddColumn(mainTable, "CADSalePrice4");          // 52
            AddColumn(mainTable, "CADPriceCode4");          // 53
            AddColumn(mainTable, "CADPriceMsg4EN");         // 54
            AddColumn(mainTable, "CADPriceMsg4FR");         // 55
            AddColumn(mainTable, "CADMinQty5");             // 56
            AddColumn(mainTable, "CADMAXQty5");             // 57
            AddColumn(mainTable, "CADPrice5");              // 58
            AddColumn(mainTable, "CADSalePrice5");          // 59
            AddColumn(mainTable, "CADPriceCode5");          // 60
            AddColumn(mainTable, "CADPriceMsg5EN");         // 61
            AddColumn(mainTable, "CADPriceMsg5FR");         // 62
            AddColumn(mainTable, "CADMinQty6");             // 63
            AddColumn(mainTable, "CADMAXQty6");             // 64
            AddColumn(mainTable, "CADPrice6");              // 65
            AddColumn(mainTable, "CADSalePrice6");          // 66
            AddColumn(mainTable, "CADPriceCode6");          // 67
            AddColumn(mainTable, "CADPriceMsg6EN");         // 68
            AddColumn(mainTable, "CADPriceMsg6FR");         // 69
            AddColumn(mainTable, "CADMinQty7");             // 70
            AddColumn(mainTable, "CADMAXQty7");             // 71
            AddColumn(mainTable, "CADPrice7");              // 72
            AddColumn(mainTable, "CADSalePrice7");          // 73
            AddColumn(mainTable, "CADPriceCode7");          // 74
            AddColumn(mainTable, "CADPriceMsg7EN");         // 75
            AddColumn(mainTable, "CADPriceMsg7FR");         // 76
            AddColumn(mainTable, "CADMinQty8");             // 77
            AddColumn(mainTable, "CADMAXQty8");             // 78
            AddColumn(mainTable, "CADPrice8");              // 79
            AddColumn(mainTable, "CADSalePrice8");          // 80
            AddColumn(mainTable, "CADPriceCode8");          // 81
            AddColumn(mainTable, "CADPriceMsg8EN");         // 82
            AddColumn(mainTable, "CADPriceMsg8FR");         // 83
            AddColumn(mainTable, "CADMinQty9");             // 84
            AddColumn(mainTable, "CADMAXQty9");             // 85
            AddColumn(mainTable, "CADPrice9");              // 86
            AddColumn(mainTable, "CADSalePrice9");          // 87
            AddColumn(mainTable, "CADPriceCode9");          // 88
            AddColumn(mainTable, "CADPriceMsg9EN");         // 89
            AddColumn(mainTable, "CADPriceMsg9FR");         // 90
            AddColumn(mainTable, "CADMinQty10");            // 91
            AddColumn(mainTable, "CADMAXQty10");            // 92
            AddColumn(mainTable, "CADPrice10");             // 93
            AddColumn(mainTable, "CADSalePrice10");         // 94
            AddColumn(mainTable, "CADPriceCode10");         // 95
            AddColumn(mainTable, "CADPriceMsg10EN");        // 96
            AddColumn(mainTable, "CADPriceMsg10FR");        // 97
            AddColumn(mainTable, "CADSaleStartDateTime");   // 98
            AddColumn(mainTable, "CADSaleEndDateTime");     // 99
            AddColumn(mainTable, "Keywords");               // 100

            // local field for inserting data to table
            double[][] discountList = GetDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();
           
                row[0] = sku;                                            // sku 
                row[1] = list[1];                                        // category
                row[12] = "Ashlin® " + list[0] + " " + list[1] + ", " + list[8];  // name en
                row[14] = list[2];                                       // description en
                row[16] = list[5];                                       // image
                row[18] = DateTime.Now.Year;                             // catalog year
                row[19] = list[6];                                       // active
                row[20] = 1;                                             // cart qtr min
                // cad general info en
                row[24] = "CUSTOM COLORS: We have several custom colours available upon enquiry.\n" +
                          "DECORATION OPTIONS: Blind debossing, hot foil stamping (in gold and silver) as well as screen printing.\n" + 
                          "DIE & SETUP: Blind debossing, hot foil stamping (in gold and silver) as well as Custom Colours"; 
                row[26] = 1;                                             // cad min qty1
                row[27] = 5;                                             // cad max qty1
                double msrp = discountList[5][0] * Convert.ToDouble(list[4]);
                int k;
                switch (Convert.ToInt32(list[7]))
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
                row[28] = msrp * discountList[k][0];                     // cad price 1
                row[30] = 'C';                                           // cad price code 1 
                row[33] = 6;                                             // cad min qty 2
                row[34] = 23;                                            // cad max qty 2
                row[36] = msrp * discountList[k][1];                     // cad price 2
                row[37] = 'C';                                           // cad price code 2
                row[40] = 24;                                            // cad min qty 3
                row[41] = 49;                                            // cad max qty 3
                row[42] = msrp * discountList[k][2];                     // cad price 3
                row[44] = 'C';                                           // cad price code 3
                row[47] = 50;                                            // cad min qty 4
                row[48] = 99;                                            // cad max qty 4
                row[49] = msrp * discountList[k][3];                     // cad price 4
                row[51] = 'C';                                           // cad price code 4
                row[54] = 100;                                           // cad min qty 5
                row[55] = 249;                                           // cad max qty 5
                row[56] = msrp * discountList[k][4];                     // cad price 5
                row[58] = 'C';                                           // cad price code 5
                row[61] = 250;                                           // cad min qty 6
                row[62] = 499;                                           // cad max qty 6
                row[63] = msrp * discountList[k][5];                     // cad price 6
                row[65] = 'C';                                           // cad price code 6
                row[68] = 500;                                           // cad min qty 7
                row[69] = 999;                                           // cad max qty 7
                row[70] = msrp * discountList[k][6];                     // cad price 7
                row[72] = 'C';                                           // cad price code 7
                row[75] = 1000;                                          // cad min qty 8
                row[76] = 2499;                                          // cad max qty 8
                row[77] = msrp * discountList[k][7];                     // cad price 8
                row[79] = 'C';                                           // cad price code 8
                row[82] = 2500;                                          // cad min qty 8
                row[84] = msrp * discountList[k][8];                     // cad price 9
                row[86] = 'C';                                           // cad price code 9
                row[98] = list[3];                                       // keywords

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND Design_Service_Code in ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Website_Flag = 'True' And Design_Service_Family_Code in ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_UDUCAT !=''));", connection);
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

            // start grabbing data
            // [0] name en, [1] category, [2] description en
            //                & name en
            // [3] keywords
            // [4] for all related to price, [5] image, [6] active, [7] for price calculation
            // [8] name En
            SqlCommand command = new SqlCommand("SELECT Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, " +
                                                "Design_Service_family_Category_UDUCAT, " +
                                                "Base_Price, Image_1_Path, sku.Active, sku.Pricing_Tier, " +
                                                "Colour_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 8; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[6][];

            // [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery] "
                                                     + "FROM Discount_Matrix", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
            {
                double[] itemList = new double[9];
                reader.Read();
                for (int j = 0; j <= 8; j++)
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
