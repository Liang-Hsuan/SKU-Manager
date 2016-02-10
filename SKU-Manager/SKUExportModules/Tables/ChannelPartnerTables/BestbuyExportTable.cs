using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return bestbuy export table
     */
    class BestbuyExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public BestbuyExportTable()
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
            DataRow row;
            AltText alt = new AltText();
            double[] price = getPrice();

            // start load data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();

                row[0] = sku;                // sku
                row[1] = "104";              // department
                row[2] = alt.getAlt(sku);    // short description 
                row[3] = list[0];            // long description
                row[4] = list[9];            // upc code primary
                row[5] = list[10];           // upc code additional
                row[6] = "Ashlin®";          // brand name
                row[7] = list[1];            // model no
                row[8] = "Ashlin®";          // manufacturer
                row[9] = "234326";           // supplier
                row[10] = sku;               // vendor
                row[11] = (Math.Round((Convert.ToDouble(list[11]) * price[0]), 2));         // unit cost
                row[12] = (Math.Ceiling((Convert.ToDouble(list[11]) * price[1])) - 0.01);   // retail price
                row[13] = list[2];                                                 // dimension width (with box)
                row[14] = list[3];                                                 // dimension height (with box)
                row[15] = list[4];                                                 // dimension length (with box)
                row[16] = (Convert.ToDouble(list[5]) / 1000);                      // dimension weight (with box)
                row[17] = list[2];                                                 // dimension width (no box)
                row[18] = list[3];                                                 // dimension height (no box)
                row[19] = list[6];                                                 // dimension length (no box)
                row[20] = list[7];                                                 // dimension weight (no box)
                row[21] = 'Y';              // french compliant
                row[23] = 'N';              // refurbished
                row[24] = 'N';              // software platform
                row[26] = 'N';              // serial no required
                row[28] = 'N';              // support manufacturer warranty
                row[29] = 'Y';              // service under mnf warranty
                row[30] = 'N';              // service outside mnf warranty
                row[31] = 8884274546;       // supplier contact
                row[32] = 'N';              // always rtv
                row[33] = 0;                // return to vendor defective date
                row[34] = 0;                // return to vendor open box days
                row[35] = 365;              // peoduct warranty days
                row[44] = list[8];          // sku bestbuy ca

                mainTable.Rows.Add(row);
                progress++;
            }

            // end loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active and sell on bestbuy*/
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_BESTBUY_CA != \'\' AND Active = \'TRUE\' ORDER BY SKU_Ashlin;", connection);
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
            DataTable table = new DataTable();

            // get the design code from sku
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            // [0] for long description, [1] for model no, [2] for diemsion width (with box), [3] for dimension height (with box), [4] for dimension legth (with box), [5] for dimension weight (with box), [6] for dimension length (no box), [7] for dimension weight(no box)
            //                                                 and (no box)                       and (no box)
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Extended_Description, Design_Service_Fashion_Name_BESTBUY_CA, Width_cm, Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Depth_cm, Weight_grams FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 7; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            table.Reset();
            // [8] for SKU_BESTBUY_CA, [9] for upc code primary, [10] for upc code additional, [11] for unit cost and retail price
            adapter = new SqlDataAdapter("SELECT SKU_BESTBUY_CA, UPC_Code_9, UPC_Code_10, Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 3; i++)
            {
                list.Add(table.Rows[0][i]);
            }
            connection.Close();

            return list;
        }

        /* a method that return the discount matrix -> [0] wholesale, [1] multiplier*/
        private double[] getPrice()
        {
            double[] list = new double[2];

            // [0] wholesale
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM ref_discount_matrix;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();
            // [1] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
