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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU");                    // 1
            AddColumn(MainTable, "Name");                   // 2
            AddColumn(MainTable, "Brand");                  // 3
            AddColumn(MainTable, "Category");               // 4
            AddColumn(MainTable, "PRICE (COST)");           // 5
            AddColumn(MainTable, "PRICE (WHOLE)");          // 6
            AddColumn(MainTable, "PRICE (RETAIL)");         // 7
            AddColumn(MainTable, "Tax Class");              // 8
            AddColumn(MainTable, "Manage Stock");           // 9
            AddColumn(MainTable, "Supplier");               // 10
            AddColumn(MainTable, "Collection");             // 11
            AddColumn(MainTable, "Weight");                 // 12
            AddColumn(MainTable, "Barcode");                // 13
            AddColumn(MainTable, "EAN");                    // 14
            AddColumn(MainTable, "ISBN");                   // 15
            AddColumn(MainTable, "UPC");                    // 16
            AddColumn(MainTable, "Sell code");              // 17
            AddColumn(MainTable, "Buy code");               // 18
            AddColumn(MainTable, "Stock code");             // 19
            AddColumn(MainTable, "Aisle");                  // 20
            AddColumn(MainTable, "Bay");                    // 21
            AddColumn(MainTable, "Shelf");                  // 22
            AddColumn(MainTable, "Bin");                    // 23
            AddColumn(MainTable, "Reorder level");          // 24
            AddColumn(MainTable, "Reorder qty");            // 25
            AddColumn(MainTable, "Bundle (SKU)");           // 26
            AddColumn(MainTable, "Colour");                 // 27
            AddColumn(MainTable, "Size");                   // 28
            AddColumn(MainTable, "Short Description");      // 29
            AddColumn(MainTable, "Long Description");       // 30
            AddColumn(MainTable, "Image");                  // 31
            AddColumn(MainTable, "Option 1");               // 32
            AddColumn(MainTable, "Option 2");               // 33
            AddColumn(MainTable, "OPTION 3");               // 34
            AddColumn(MainTable, "OPTION 4");               // 35
            AddColumn(MainTable, "Design Name");            // 36
            AddColumn(MainTable, "Design Code");            // 37
            AddColumn(MainTable, "Material Code");          // 38
            AddColumn(MainTable, "Colour Code");            // 39
            AddColumn(MainTable, "Material Description");   // 40
            AddColumn(MainTable, "Colour Description");     // 41
            AddColumn(MainTable, "Actual Product Weight (unshipped)");      // 42
            AddColumn(MainTable, "Imprintable");            // 43
            AddColumn(MainTable, "Imprint Height cm");      // 44
            AddColumn(MainTable, "Imprint Width cm");       // 45
            AddColumn(MainTable, "Depth cm");               // 46
            AddColumn(MainTable, "Width cm");               // 47
            AddColumn(MainTable, "Height cm");              // 48
            AddColumn(MainTable, "Run Charge");             // 49

            // local field for inserting data to table
            double[][] discountList = GetDiscount();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                object[] list = GetData(sku);
                DataRow row = MainTable.NewRow();

                row[0] = sku;           // sku
                row[1] = list[8];       // name
                row[2] = "Ashlin";      // brand
                row[3] = list[24];      // category
                double msrp = Convert.ToDouble(list[3]) * discountList[0][1];
                row[4] = Math.Ceiling(msrp * discountList[0][0]);        // price (cost)
                row[5] = Math.Ceiling(msrp * discountList[0][0]);        // price (whole)
                row[6] = Math.Ceiling(msrp);                             // price (retail)
                row[7] = 'T';                              // tax class
                row[8] = "Yes";                            // manage stock
                row[9] = 9835;          // supplier
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

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
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
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
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
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM Discount_Matrix WHERE Pricing_Tier = 0", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            // [1] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetDouble(0);
            Connection.Close();

            return new[] { list };
        }
    }
}
