using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return bestbuy export table
     */
    public class BestbuyExportTable : ExportTableFast
    {
        /* constructor that initialize fields */
        public BestbuyExportTable()
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
            addColumn(mainTable, "SKU");                                                 // 1
            addColumn(mainTable, "DEPARTMENT");                                          // 2
            addColumn(mainTable, "SHORT DESCRIPTION");                                   // 3
            addColumn(mainTable, "LONG DESCRIPTION");                                    // 4
            addColumn(mainTable, "UPC (PRIMARY)");                                       // 4
            addColumn(mainTable, "UPC (ADDITIONAL)");                                    // 5
            addColumn(mainTable, "BRAND NAME");                                          // 6
            addColumn(mainTable, "MODEL NO");                                            // 7
            addColumn(mainTable, "MANUFACTURER");                                        // 8
            addColumn(mainTable, "SUPPLIER");                                            // 9
            addColumn(mainTable, "VENDOR PART NO");                                      // 10
            addColumn(mainTable, "UNIT COST");                                           // 11
            addColumn(mainTable, "RETAIL PRICE");                                        // 12
            addColumn(mainTable, "DIMENSION (CM) WIDTH (WITH BOX)");                     // 13
            addColumn(mainTable, "DIMENSION (CM) HEIGHT (WITH BOX)");                    // 14
            addColumn(mainTable, "DIMENSION (CM) LENGTH/DEPTH (WITH BOX)");              // 15
            addColumn(mainTable, "DIMENSION (KG) WEIGHT (WITH BOX)");                    // 16
            addColumn(mainTable, "DIMENSION (CM) WIDTH (NO BOX)");                       // 17
            addColumn(mainTable, "DIMENSION (CM) HEIGHT (NO BOX)");                      // 18
            addColumn(mainTable, "DIMENSION (CM) LENGTH/DEPTH (NO BOX)");                // 19
            addColumn(mainTable, "DIMENSION (KG) WEIGHT (NO BOX)");                      // 20
            addColumn(mainTable, "FRENCH COMPLIANT");                                    // 21
            addColumn(mainTable, "ENERGY STAR");                                         // 22
            addColumn(mainTable, "REFURBISHED");                                         // 23
            addColumn(mainTable, "SOFTWARE PLATFORM");                                   // 24
            addColumn(mainTable, "STREET DATE");                                         // 25
            addColumn(mainTable, "SERIAL NO REQUIRED");                                  // 26
            addColumn(mainTable, "SERIALIZED FORMAT");                                   // 27
            addColumn(mainTable, "SUPPORT MANUFACTURER WARRANTY");                       // 28
            addColumn(mainTable, "SERVICE UNDER MNF WARRANTY");                          // 29
            addColumn(mainTable, "SERVICE OUTSIDE MNF WARRANTY");                        // 30
            addColumn(mainTable, "SUPPLIER CONTACT");                                    // 31
            addColumn(mainTable, "ALWAYS RTV");                                          // 32
            addColumn(mainTable, "RETURN TO VENDOR DEFECTIVE DATE");                     // 33
            addColumn(mainTable, "RETURN TO VENDOR OPEN BOX DAYS");                      // 34
            addColumn(mainTable, "PRODUCT WARRANTY DAYS");                               // 35
            addColumn(mainTable, "PRODUCT WARRANTY COVERAGE");                           // 36
            addColumn(mainTable, "EXTENDED PARTS WARRANTY");                             // 37
            addColumn(mainTable, "RETURN RESTRICTIONS");                                 // 38
            addColumn(mainTable, "EMBARGO DATE");                                        // 39
            addColumn(mainTable, "EXPIRATION DATE/LOT NUMBER");                          // 40
            addColumn(mainTable, "SHELF LIFE");                                          // 41
            addColumn(mainTable, "DATA FLAG");                                           // 42
            addColumn(mainTable, "LESS THAN TRUCKLOAD");                                 // 43
            addColumn(mainTable, "SKU_BESTBUY_CA");                                      // 44

            // local field for inserting data to table
            DataTable table = GetDataTable();
            double[] price = getPrice();

            // start load data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = mainTable.NewRow();

                newRow[0] = row[13];                                  // sku
                newRow[1] = "104";                                    // department
                newRow[2] = "Ashlin® " + row[2] + " " + row[1] + ", " + row[14];    // short description 
                newRow[3] = row[0];                                   // long description
                newRow[4] = row[10];                                  // upc code primary
                newRow[5] = row[11];                                  // upc code additional
                newRow[6] = "Ashlin®";                                // brand name
                newRow[7] = row[2];                                   // model no
                newRow[8] = "Ashlin®";                                // manufacturer
                newRow[9] = "234326";                                 // supplier
                newRow[10] = row[13];                                 // vendor
                newRow[11] = (Math.Round((Convert.ToDouble(row[12]) * price[0]), 2));         // unit cost
                newRow[12] = (Math.Ceiling((Convert.ToDouble(row[12]) * price[1])) - 0.01);   // retail price
                newRow[13] = row[3];                                  // dimension width (with box)
                newRow[14] = row[4];                                  // dimension height (with box)
                newRow[15] = row[5];                                  // dimension length (with box)
                newRow[16] = (Convert.ToDouble(row[6]) / 1000);       // dimension weight (with box)
                newRow[17] = row[3];                                  // dimension width (no box)
                newRow[18] = row[4];                                  // dimension height (no box)
                newRow[19] = row[7];                                  // dimension length (no box)
                newRow[20] = row[8];                                  // dimension weight (no box)
                newRow[21] = 'Y';                                     // french compliant
                newRow[23] = 'N';                                     // refurbished
                newRow[24] = 'N';                                     // software platform
                newRow[26] = 'N';                                     // serial no required
                newRow[28] = 'N';                                     // support manufacturer warranty
                newRow[29] = 'Y';                                     // service under mnf warranty
                newRow[30] = 'N';                                     // service outside mnf warranty
                newRow[31] = 8884274546;                              // supplier contact
                newRow[32] = 'N';                                     // always rtv
                newRow[33] = 0;                                       // return to vendor defective date
                newRow[34] = 0;                                       // return to vendor open box days
                newRow[35] = 365;                                     // peoduct warranty days
                newRow[44] = row[9];                                  // sku bestbuy ca

                mainTable.Rows.Add(newRow);
                Progress++;
            }

            // end loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* new version of getData that directly return the desired table -> no issue */
        protected override DataTable GetDataTable()
        {
            // local field for storing data
            DataTable table = new DataTable();

            // grab data from database
            // [0] for long description, [1], short description, [2] for model no, [3] for diemsion width (with box), [4] for dimension height (with box), [5] for dimension legth (with box), [6] for dimension weight (with box), [7] for dimension length (no box), [8] for dimension weight(no box)
            //                                                   & short description & (no box)                         & (no box)
            // [9] for SKU_BESTBUY_CA, [10] for upc code primary, [11] for upc code additional, [12] for unit cost and retail price, [13] sku, [14] short description
            //                                                                                                                         & vendor 
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Extended_Description, Short_Description, Design_Service_Fashion_Name_BESTBUY_CA, Width_cm, Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Depth_cm, Weight_grams, SKU_BESTBUY_CA, UPC_Code_9, UPC_Code_10, Base_Price, SKU_Ashlin, Colour_Description_Short " + 
                                                        "FROM master_Design_Attributes design " +
                                                        "INNER JOIN master_SKU_Attributes sku ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                        "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                        "WHERE SKU_BESTBUY_CA != \'\' and sku.Active = 'True' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();

            return table;
        }

        /* a method that get all the sku that is active and have on bestbuy */
        protected sealed override string[] getSku()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' AND SKU_BESTBUY_CA != \'\' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* a method that return the discount matrix -> [0] wholesale, [1] multiplier*/
        private double[] getPrice()
        {
            double[] list = new double[2];

            // [0] wholesale
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM ref_discount_matrix", connection);
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

            return list;
        }
    }
}
