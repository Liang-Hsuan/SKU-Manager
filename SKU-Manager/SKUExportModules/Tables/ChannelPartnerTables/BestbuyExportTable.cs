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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU");                                                 // 1
            AddColumn(MainTable, "DEPARTMENT");                                          // 2
            AddColumn(MainTable, "SHORT DESCRIPTION");                                   // 3
            AddColumn(MainTable, "LONG DESCRIPTION");                                    // 4
            AddColumn(MainTable, "UPC (PRIMARY)");                                       // 4
            AddColumn(MainTable, "UPC (ADDITIONAL)");                                    // 5
            AddColumn(MainTable, "BRAND NAME");                                          // 6
            AddColumn(MainTable, "MODEL NO");                                            // 7
            AddColumn(MainTable, "MANUFACTURER");                                        // 8
            AddColumn(MainTable, "SUPPLIER");                                            // 9
            AddColumn(MainTable, "VENDOR PART NO");                                      // 10
            AddColumn(MainTable, "UNIT COST");                                           // 11
            AddColumn(MainTable, "RETAIL PRICE");                                        // 12
            AddColumn(MainTable, "DIMENSION (CM) WIDTH (WITH BOX)");                     // 13
            AddColumn(MainTable, "DIMENSION (CM) HEIGHT (WITH BOX)");                    // 14
            AddColumn(MainTable, "DIMENSION (CM) LENGTH/DEPTH (WITH BOX)");              // 15
            AddColumn(MainTable, "DIMENSION (KG) WEIGHT (WITH BOX)");                    // 16
            AddColumn(MainTable, "DIMENSION (CM) WIDTH (NO BOX)");                       // 17
            AddColumn(MainTable, "DIMENSION (CM) HEIGHT (NO BOX)");                      // 18
            AddColumn(MainTable, "DIMENSION (CM) LENGTH/DEPTH (NO BOX)");                // 19
            AddColumn(MainTable, "DIMENSION (KG) WEIGHT (NO BOX)");                      // 20
            AddColumn(MainTable, "FRENCH COMPLIANT");                                    // 21
            AddColumn(MainTable, "ENERGY STAR");                                         // 22
            AddColumn(MainTable, "REFURBISHED");                                         // 23
            AddColumn(MainTable, "SOFTWARE PLATFORM");                                   // 24
            AddColumn(MainTable, "STREET DATE");                                         // 25
            AddColumn(MainTable, "SERIAL NO REQUIRED");                                  // 26
            AddColumn(MainTable, "SERIALIZED FORMAT");                                   // 27
            AddColumn(MainTable, "SUPPORT MANUFACTURER WARRANTY");                       // 28
            AddColumn(MainTable, "SERVICE UNDER MNF WARRANTY");                          // 29
            AddColumn(MainTable, "SERVICE OUTSIDE MNF WARRANTY");                        // 30
            AddColumn(MainTable, "SUPPLIER CONTACT");                                    // 31
            AddColumn(MainTable, "ALWAYS RTV");                                          // 32
            AddColumn(MainTable, "RETURN TO VENDOR DEFECTIVE DATE");                     // 33
            AddColumn(MainTable, "RETURN TO VENDOR OPEN BOX DAYS");                      // 34
            AddColumn(MainTable, "PRODUCT WARRANTY DAYS");                               // 35
            AddColumn(MainTable, "PRODUCT WARRANTY COVERAGE");                           // 36
            AddColumn(MainTable, "EXTENDED PARTS WARRANTY");                             // 37
            AddColumn(MainTable, "RETURN RESTRICTIONS");                                 // 38
            AddColumn(MainTable, "EMBARGO DATE");                                        // 39
            AddColumn(MainTable, "EXPIRATION DATE/LOT NUMBER");                          // 40
            AddColumn(MainTable, "SHELF LIFE");                                          // 41
            AddColumn(MainTable, "DATA FLAG");                                           // 42
            AddColumn(MainTable, "LESS THAN TRUCKLOAD");                                 // 43
            AddColumn(MainTable, "SKU_BESTBUY_CA");                                      // 44

            // local field for inserting data to table
            DataTable table = GetDataTable();
            double[] price = GetPrice();

            // start load data
            MainTable.BeginLoadData();

            // add data to each row 
            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = MainTable.NewRow();

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
                double sellMsrp = Math.Ceiling((Convert.ToDouble(row[12]) * price[0]) * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                newRow[11] = sellMsrp - (price[4] * sellMsrp) + price[3];        // unit cost
                newRow[12] = sellMsrp;                                // retail price
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

                MainTable.Rows.Add(newRow);
                Progress++;
            }

            // end loading data
            MainTable.EndLoadData();

            return MainTable;
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
                                                        "WHERE SKU_BESTBUY_CA != '' and sku.Active = 'True' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            adapter.Fill(table);
            Connection.Close();

            return table;
        }

        /* a method that get all the sku that is active and have on bestbuy */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND SKU_BESTBUY_CA != '' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }

        /* a method that return the discount matrix -> [0] wholesale, [1] multiplier */
        private double[] GetPrice()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship, [4] gross marg
            double[] list = new double[5];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship, Gross_Marg FROM Channel_Pricing WHERE Channel_No = 2008";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            list[4] = (double)reader.GetDecimal(3);
            Connection.Close();

            return list;
        }
    }
}
