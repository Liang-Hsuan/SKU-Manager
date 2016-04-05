using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca price export table
     */
    public class ShopCaPriceExportTable : ShopCaExportTable
    {
        /* constructor that initialize fields */
        public ShopCaPriceExportTable()
        {
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "supplier id");                         // 1
            addColumn(mainTable, "store name");                          // 2
            addColumn(mainTable, "sku");                                 // 3
            addColumn(mainTable, "supplier suggested retail price");     // 4
            addColumn(mainTable, "msrp");                                // 5
            addColumn(mainTable, "supplier list price");                 // 6
            addColumn(mainTable, "supplier cost");                       // 7
            addColumn(mainTable, "effective");                           // 8
            addColumn(mainTable, "effective end date");                  // 9
            addColumn(mainTable, "is point");                            // 10
            addColumn(mainTable, "currency");                            // 11
            addColumn(mainTable, "standard ship cost");                  // 12
            addColumn(mainTable, "priority shup cost");                  // 13
            addColumn(mainTable, "ab tax exempt");                       // 14
            addColumn(mainTable, "bc tax exempt");                       // 15
            addColumn(mainTable, "mb tax exempt");                       // 16
            addColumn(mainTable, "nb tax exempt");                       // 17
            addColumn(mainTable, "nl tax exempt");                       // 18
            addColumn(mainTable, "nt tax exempt");                       // 19
            addColumn(mainTable, "ns tax exempt");                       // 20
            addColumn(mainTable, "nu tax exempt");                       // 21
            addColumn(mainTable, "on tax exempt");                       // 22
            addColumn(mainTable, "pe tax exempt");                       // 23
            addColumn(mainTable, "qc tax exempt");                       // 24
            addColumn(mainTable, "sk tax exempt");                       // 25
            addColumn(mainTable, "yt tax exempt");                       // 26

            // local field for inserting data to table
            double multiplier = getMultiplier();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                double basePrice = Convert.ToDouble(getData(sku)[0]);

                var row = mainTable.NewRow();

                row[0] = "ashlin_bpg";                                           // brand
                row[1] = "nishis_boutique";                                      // store name
                row[2] = sku;                                                    // sku
                row[3] = Math.Ceiling(basePrice * multiplier * 0.9) - 0.01;      // supplier suggested retail price
                row[4] = basePrice * multiplier;                                 // msrp
                row[5] = Math.Ceiling(basePrice * multiplier * 0.9) - 0.01;      // supplier list price

                mainTable.Rows.Add(row);        
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList getData(string sku)
        {
            ArrayList list = new ArrayList();

            // start grabbing data              
            // [0] for all related to price      
            SqlCommand command = new SqlCommand("SELECT Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list.Add(reader.GetValue(0));

            return list;
        }

        /* a method that return the discount matrix */
        private double getMultiplier()
        {
            double multiplier;

            using (SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                multiplier = reader.GetDouble(0);
                connection.Close();
            }

            return multiplier;
        }
    }
}
