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
            skuList = getSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
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
            double[] price = getPriceList();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();

                row[0] = sku;                                                        // item number
                double msrp = Convert.ToDouble(getData(sku)[0]) * price[0];
                row[1] = msrp * 0.6;                                                 // total VNPK case cost
                row[2] = Math.Ceiling(msrp * 0.9) - 0.01;                            // unit retail
                row[3] = Math.Ceiling(msrp * (1 - price[1] / 100)) - (1 - price[2]); // whse pack cost

                mainTable.Rows.Add(row);
                Progress++;
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

        /* a method that return the all fields for price calculation */
        protected double[] getPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents
            double[] list = new double[3];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents FROM Channel_Pricing WHERE Channel_No = 1003";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = Convert.ToDouble(reader.GetValue(0));
            list[2] = Convert.ToDouble(reader.GetValue(1));
            connection.Close();

            return list;
        }
    }
}
