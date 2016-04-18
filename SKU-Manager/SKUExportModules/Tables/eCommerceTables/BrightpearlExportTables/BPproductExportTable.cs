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
            AddColumn(mainTable, "OPTION 3");               // 32
            AddColumn(mainTable, "OPTION 4");               // 33

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
                row[1] = list[5];       // name
                row[2] = "Ashlin";      // brand
                row[3] = list[8];       // category
                double msrp = Convert.ToDouble(list[0]) * discountList[0][1];
                row[4] = msrp * discountList[0][0];        // price (cost)
                row[5] = msrp * discountList[0][0];        // price (whole)
                row[6] = msrp;                             // price (retail)
                row[7] = 'T';                              // tax class
                row[8] = "Yes";                            // manage stock
                row[9] = "Ashlin BPG Marketing INC";       // supplier
                row[11] = list[6];      // weight
                row[12] = list[1];      // barcode
                row[15] = list[1];      // upc
                row[19] = 2;            // aisle
                row[20] = 2;            // bay
                row[21] = 2;            // shelf
                row[22] = 2;            // bin
                row[23] = list[4];      // reorder level
                row[24] = list[3];      // reorder qty
                row[26] = list[9];      // colour
                row[28] = list[5];      // short description
                row[29] = list[7];      // long description
                row[30] = list[2];      // image

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
            object[] list = new object[10];

            // grab data from database
            // [0] for fields related to price, [1] barcode, [2] image, [3] reorder qty, [4] reorder level
            //                                    & UPC
            // [5] name, [6] weight, [7] long description
            // [8] category, [9] colour
            SqlCommand commnad = new SqlCommand("SELECT Base_Price, UPC_Code_9, Image_1_Path, sku.Reorder_Quantity, sku.Reorder_Level, " +
                                                "Short_Description, Weight_grams, Extended_Description, " +
                                                "Design_Service_Family_Description, " +
                                                "Colour_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 9; i++)
                list[i] = reader.GetValue(i);

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

            return new double[][] { list };
        }
    }
}
