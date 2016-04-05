using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.WalmartTables
{
    /*
     * A class that return walmart price export table
     */
    public class WalmartPriceExportTable : WalmartExportTable
    {
        /* constructor that initialize fields */
        public WalmartPriceExportTable()
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
            addColumn(mainTable, "Item Number");                          // 1
            addColumn(mainTable, "Total VNPK Case Cost");                 // 2
            addColumn(mainTable, "Unit Retail");                          // 3
            addColumn(mainTable, "Whse Pack Cost");                       // 4
            addColumn(mainTable, "item Description");                     // 5     
            addColumn(mainTable, "VNPK Case Qty");                        // 6
            addColumn(mainTable, "Current Total VNPK Case Cost");         // 7
            addColumn(mainTable, "Current EDLP Retail");                  // 8
            addColumn(mainTable, "Current On Hand");                      // 9
            addColumn(mainTable, "Current On Order");                     // 10
            addColumn(mainTable, "Per Unit Cost WM");                     // 11
            addColumn(mainTable, "Optimal PP Covered Uni Retail");        // 12
            addColumn(mainTable, "Case Cost Needed to Cover PP");         // 13
            addColumn(mainTable, "Markdown $ At Cost");                   // 14
            addColumn(mainTable, "Markdown $ At Retail");                 // 15
            addColumn(mainTable, "Old Margin");                           // 16
            addColumn(mainTable, "New Margin");                           // 17

            // local field for inserting data to table
            double multiplier = getMultiplier();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                DataRow row = mainTable.NewRow();

                row[0] = sku;                                            // item number
                double msrp = Convert.ToDouble(list[0]) * multiplier;
                row[1] = msrp * 0.6;                                     // total VNPK case cost
                row[2] = Math.Ceiling(msrp * 0.9) - 0.01;                // unit retail
                row[3] = (Math.Ceiling(msrp * 0.9) - 0.01) * msrp * 0.6; // whse pack cost

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

        /* a method that return the multiplier */
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
