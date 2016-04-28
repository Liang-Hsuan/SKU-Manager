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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU");                    // 1
            AddColumn(MainTable, "Category");               // 2
            AddColumn(MainTable, "Category1EN");            // 3
            AddColumn(MainTable, "Category1FR");            // 4
            AddColumn(MainTable, "Category2EN");            // 5
            AddColumn(MainTable, "Category2FR");            // 6
            AddColumn(MainTable, "Category3EN");            // 7
            AddColumn(MainTable, "Category3FR");            // 8
            AddColumn(MainTable, "Category4EN");            // 9
            AddColumn(MainTable, "Category4FR");            // 10
            AddColumn(MainTable, "Category5EN");            // 11
            AddColumn(MainTable, "Category5FR");            // 12
            AddColumn(MainTable, "NameEN");                 // 13
            AddColumn(MainTable, "NameFR");                 // 14
            AddColumn(MainTable, "DescriptionEN");          // 15
            AddColumn(MainTable, "DescriptionFR");          // 16
            AddColumn(MainTable, "Image");                  // 17
            AddColumn(MainTable, "CatelogPage");            // 18
            AddColumn(MainTable, "CatelogYear");            // 19
            AddColumn(MainTable, "Active");                 // 20
            AddColumn(MainTable, "CartQtrMin");             // 21
            AddColumn(MainTable, "CartQtyMax");             // 23
            AddColumn(MainTable, "CADCertified");           // 24
            AddColumn(MainTable, "CADValidUntilDate");      // 25
            AddColumn(MainTable, "CADGeneralInfoEN");       // 26
            AddColumn(MainTable, "CADGeneralInfoFR");       // 27
            AddColumn(MainTable, "CADMinQty1");             // 28
            AddColumn(MainTable, "CADMaxQty1");             // 29
            AddColumn(MainTable, "CADPrice1");              // 30
            AddColumn(MainTable, "CADSalePrice1");          // 31
            AddColumn(MainTable, "CADPriceCode1");          // 32
            AddColumn(MainTable, "CADPriceMsg1EN");         // 33
            AddColumn(MainTable, "CADPriceMsg1FR");         // 34   
            AddColumn(MainTable, "CADMINQty2");             // 35
            AddColumn(MainTable, "CADMAXQTY2");             // 36
            AddColumn(MainTable, "CADSalePrice2");          // 37
            AddColumn(MainTable, "CADPrice2");              // 38
            AddColumn(MainTable, "CADPriceCode2");          // 39
            AddColumn(MainTable, "CADPriceMsg2EN");         // 40
            AddColumn(MainTable, "CADPriceMsg2FR");         // 41
            AddColumn(MainTable, "CADMinQty3");             // 42
            AddColumn(MainTable, "CADMAXQty3");             // 43
            AddColumn(MainTable, "CADPrice3");              // 44
            AddColumn(MainTable, "CADSalePrice3");          // 45
            AddColumn(MainTable, "CADPriceCode3");          // 46
            AddColumn(MainTable, "CADPriceMsg3EN");         // 47
            AddColumn(MainTable, "CADPriceMsg3FR");         // 48
            AddColumn(MainTable, "CADMinQty4");             // 49
            AddColumn(MainTable, "CADMAXQty4");             // 50
            AddColumn(MainTable, "CADPrice4");              // 51
            AddColumn(MainTable, "CADSalePrice4");          // 52
            AddColumn(MainTable, "CADPriceCode4");          // 53
            AddColumn(MainTable, "CADPriceMsg4EN");         // 54
            AddColumn(MainTable, "CADPriceMsg4FR");         // 55
            AddColumn(MainTable, "CADMinQty5");             // 56
            AddColumn(MainTable, "CADMAXQty5");             // 57
            AddColumn(MainTable, "CADPrice5");              // 58
            AddColumn(MainTable, "CADSalePrice5");          // 59
            AddColumn(MainTable, "CADPriceCode5");          // 60
            AddColumn(MainTable, "CADPriceMsg5EN");         // 61
            AddColumn(MainTable, "CADPriceMsg5FR");         // 62
            AddColumn(MainTable, "CADMinQty6");             // 63
            AddColumn(MainTable, "CADMAXQty6");             // 64
            AddColumn(MainTable, "CADPrice6");              // 65
            AddColumn(MainTable, "CADSalePrice6");          // 66
            AddColumn(MainTable, "CADPriceCode6");          // 67
            AddColumn(MainTable, "CADPriceMsg6EN");         // 68
            AddColumn(MainTable, "CADPriceMsg6FR");         // 69
            AddColumn(MainTable, "CADMinQty7");             // 70
            AddColumn(MainTable, "CADMAXQty7");             // 71
            AddColumn(MainTable, "CADPrice7");              // 72
            AddColumn(MainTable, "CADSalePrice7");          // 73
            AddColumn(MainTable, "CADPriceCode7");          // 74
            AddColumn(MainTable, "CADPriceMsg7EN");         // 75
            AddColumn(MainTable, "CADPriceMsg7FR");         // 76
            AddColumn(MainTable, "CADMinQty8");             // 77
            AddColumn(MainTable, "CADMAXQty8");             // 78
            AddColumn(MainTable, "CADPrice8");              // 79
            AddColumn(MainTable, "CADSalePrice8");          // 80
            AddColumn(MainTable, "CADPriceCode8");          // 81
            AddColumn(MainTable, "CADPriceMsg8EN");         // 82
            AddColumn(MainTable, "CADPriceMsg8FR");         // 83
            AddColumn(MainTable, "CADMinQty9");             // 84
            AddColumn(MainTable, "CADMAXQty9");             // 85
            AddColumn(MainTable, "CADPrice9");              // 86
            AddColumn(MainTable, "CADSalePrice9");          // 87
            AddColumn(MainTable, "CADPriceCode9");          // 88
            AddColumn(MainTable, "CADPriceMsg9EN");         // 89
            AddColumn(MainTable, "CADPriceMsg9FR");         // 90
            AddColumn(MainTable, "CADMinQty10");            // 91
            AddColumn(MainTable, "CADMAXQty10");            // 92
            AddColumn(MainTable, "CADPrice10");             // 93
            AddColumn(MainTable, "CADSalePrice10");         // 94
            AddColumn(MainTable, "CADPriceCode10");         // 95
            AddColumn(MainTable, "CADPriceMsg10EN");        // 96
            AddColumn(MainTable, "CADPriceMsg10FR");        // 97
            AddColumn(MainTable, "CADSaleStartDateTime");   // 98
            AddColumn(MainTable, "CADSaleEndDateTime");     // 99
            AddColumn(MainTable, "Keywords");               // 100

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
                double msrp = discountList[7][0] * Convert.ToDouble(list[4]);
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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_Website = 'True' AND Design_Service_Code in ( " +
                                                "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Website_Flag = 'True' And Design_Service_Family_Code in ( " +
                                                "SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Category_UDUCAT !=''))", Connection);
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
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 8; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that return the discount matrix */
        private double[][] GetDiscount()
        {
            double[][] list = new double[8][];

            // [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery] "
                                                     + "FROM Discount_Matrix", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 6; i++)
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
            list[7] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }
    }
}
