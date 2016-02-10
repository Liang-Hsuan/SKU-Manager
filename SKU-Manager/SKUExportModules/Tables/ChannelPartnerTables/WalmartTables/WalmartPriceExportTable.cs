using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.WalmartTables
{
    /*
     * A class that return walmart price export table
     */
    class WalmartPriceExportTable : WalmartExportTable
    {
        /* constructor that initialize fields */
        public WalmartPriceExportTable()
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
            addColumn(mainTable, "Item Number");                          // 1
            addColumn(mainTable, "Total VNPK Case Cost");                 // 2
            addColumn(mainTable, "Unit Retail");                          // 3
            addColumn(mainTable, "Whse Pack Cost");                       // 4
            addColumn(mainTable, "item Description");
            addColumn(mainTable, "VNPK Case Qty");
            addColumn(mainTable, "Current Total VNPK Case Cost");
            addColumn(mainTable, "Current EDLP Retail");
            addColumn(mainTable, "Current On Hand");
            addColumn(mainTable, "Current On Order");
            addColumn(mainTable, "Per Unit Cost WM");
            addColumn(mainTable, "Optimal PP Covered Uni Retail");
            addColumn(mainTable, "Case Cost Needed to Cover PP");
            addColumn(mainTable, "Markdown $ At Cost");
            addColumn(mainTable, "Markdown $ At Retail");
            addColumn(mainTable, "Old Margin");
            addColumn(mainTable, "New Margin");

            // local field for inserting data to table
            DataRow row;
            double multiplier = getMultiplier();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();

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

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList getData(string sku)
        {
            ArrayList list = new ArrayList();

            // start grabbing data              
            // [0] for all related to price       
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            connection.Close();

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
