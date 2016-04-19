using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return product table for brightpreal export
     */
    public class BPproductExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPproductExportTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "SKU");                    // 1
            AddColumn(mainTable, "Name");                   // 2
            AddColumn(mainTable, "Brand");                  // 3
            AddColumn(mainTable, "Category");               // 4
            AddColumn(mainTable, "PRICE (COST)");           // 5
            AddColumn(mainTable, "PRICE (WHOLE)");          // 6
            AddColumn(mainTable, "PRICE (RETAIL)");         // 7
            AddColumn(mainTable, "Tax Class");              // 8
            AddColumn(mainTable, "Manage Stock");           // 9
            AddColumn(mainTable, "Supplier");               // 10
            AddColumn(mainTable, "Collection");             // 11
            AddColumn(mainTable, "Weight");                 // 12
            AddColumn(mainTable, "Barcode");                // 13
            AddColumn(mainTable, "EAN");                    // 14
            AddColumn(mainTable, "ISBN");                   // 15
            AddColumn(mainTable, "UPC");                    // 16
            AddColumn(mainTable, "Sell code");              // 17
            AddColumn(mainTable, "Buy code");               // 18
            AddColumn(mainTable, "Stock code");             // 19
            AddColumn(mainTable, "Aisle");                  // 20
            AddColumn(mainTable, "Bay");                    // 21
            AddColumn(mainTable, "Shelf");                  // 22
            AddColumn(mainTable, "Bin");                    // 23
            AddColumn(mainTable, "Reorder level");          // 24
            AddColumn(mainTable, "Reorder qty");            // 25
            AddColumn(mainTable, "Bundle (SKU)");           // 26
            AddColumn(mainTable, "Colour");                 // 27
            AddColumn(mainTable, "Size");                   // 28
            AddColumn(mainTable, "Short Description");      // 29
            AddColumn(mainTable, "Long Description");       // 30
            AddColumn(mainTable, "Image");                  // 31
            AddColumn(mainTable, "Option 1");               // 32
            AddColumn(mainTable, "Option 2");               // 33
            AddColumn(mainTable, "OPTION 3");               // 34
            AddColumn(mainTable, "OPTION 4");               // 35
            AddColumn(mainTable, "Design Name");            // 36
            AddColumn(mainTable, "Design Code");            // 37
            AddColumn(mainTable, "Material Code");          // 38
            AddColumn(mainTable, "Colour Code");            // 39
            AddColumn(mainTable, "Material Description");   // 40
            AddColumn(mainTable, "Colour Description");     // 41
            AddColumn(mainTable, "Actual Product Weight (unshipped)");      // 42
            AddColumn(mainTable, "Imprintable");            // 43
            AddColumn(mainTable, "Imprint Height cm");      // 44
            AddColumn(mainTable, "Imprint Width cm");       // 45
            AddColumn(mainTable, "Depth cm");               // 46
            AddColumn(mainTable, "Width cm");               // 47
            AddColumn(mainTable, "Height cm");              // 48
            AddColumn(mainTable, "Run Charge");             // 49

            // local field for inserting data to table
            double[][] discountList = GetDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                object[] list = GetData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = sku;           // sku
                row[1] = list[8];       // name
                row[2] = "Ashlin";      // brand
                row[3] = list[24];      // category
                double msrp = Convert.ToDouble(list[3]) * discountList[0][1];
                row[4] = msrp * discountList[0][0];        // price (cost)
                row[5] = msrp * discountList[0][0];        // price (whole)
                row[6] = msrp;                             // price (retail)
                row[7] = 'T';                              // tax class
                row[8] = "Yes";                            // manage stock
                row[9] = "Ashlin BPG Marketing INC";       // supplier
                row[11] = list[9];      // weight
                row[12] = list[4];      // barcode
                row[15] = list[4];      // upc
                row[19] = 2;            // aisle
                row[20] = 2;            // bay
                row[21] = 2;            // shelf
                row[22] = 2;            // bin
                row[23] = list[7];      // reorder level
                row[24] = list[6];      // reorder qty
                row[26] = list[25];     // colour
                row[28] = list[8];      // short description
                row[29] = list[10];     // long description
                row[30] = list[5];      // image
                row[31] = list[11];     // option 1
                row[32] = list[12];     // option 2
                row[33] = list[12];     // option 3
                row[34] = list[14];     // option 4
                row[35] = list[15];     // design name
                row[36] = list[0];      // design code
                row[37] = list[1];      // material code
                row[38] = list[2];      // colour code
                row[39] = list[26];     // material description
                row[40] = list[27];     // colour description
                row[41] = list[16];     // actual product weight
                row[42] = list[17];     // imprintable
                row[43] = list[18];     // imprint height cm
                row[44] = list[19];     // imprint width cm
                row[45] = list[20];     // depth cm
                row[46] = list[21];     // width cm
                row[47] = list[22];     // height cm
                double runCharge = !list[23].Equals(DBNull.Value) ? Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[23]) - 1 : Math.Round(msrp * 0.05) / 0.6;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                row[48] = Math.Round(runCharge, 4);   // run charge    

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* override get data method */
        protected override object[] GetData(string sku)
        {
            // local field for storing data
            object[] list = new object[28];

            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            string color = sku.Substring(sku.LastIndexOf('-') + 1);
            string material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            string design = sku.Substring(0, sku.IndexOf('-'));

            // [0] design code, [1] material code, [2] color code
            list[0] = design; list[1] = material; list[2] = color;

            // grab data from database
            // [3] for fields related to price, [4] barcode, [5] image, [6] reorder qty, [7] reorder level
            //                                    & UPC
            // [8] name, [9] weight, [10] long description, [11] ~ [14] option, [15] design name, [16] actual product weight, [17] imprintable, [18] imprint height cm, [19] imprint width cm, [20] depth cm, [21] width cm, [22] height cm, [23] for price calculation
            // & short description
            // [24] category, [25] colour, [26] material description, [27] colour description
            SqlCommand commnad = new SqlCommand("SELECT Base_Price, UPC_Code_9, Image_1_Path, sku.Reorder_Quantity, sku.Reorder_Level, " +
                                                "Short_Description, Shippable_Weight_grams, Extended_Description, Option_1, Option_2, Option_3, Option_4, Design_Service_Fashion_Name_Ashlin, Weight_grams, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Depth_cm, Width_cm, Height_cm, Components, " +
                                                "Design_Service_Family_Description, " +
                                                "Colour_Description_Short, Material_Description_Short, Colour_Description_Extended " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 24; i++)
                list[i + 3] = reader.GetValue(i);

            return list;
        }

        /* override get discount method */
        protected override double[][] GetDiscount()
        {
            double[] list = new double[2];

            //  [0] wholesale net
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM Discount_Matrix WHERE Pricing_Tier = 0", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            // [1] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetDouble(0);
            connection.Close();

            return new[] { list };
        }
    }
}
