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
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "Item Number");                          // 1
            AddColumn(mainTable, "Total VNPK Case Cost");                 // 2
            AddColumn(mainTable, "Unit Retail");                          // 3
            AddColumn(mainTable, "Whse Pack Cost");                       // 4
            AddColumn(mainTable, "item Description");                     // 5     
            AddColumn(mainTable, "VNPK Case Qty");                        // 6
            AddColumn(mainTable, "Current Total VNPK Case Cost");         // 7
            AddColumn(mainTable, "Current EDLP Retail");                  // 8
            AddColumn(mainTable, "Current On Hand");                      // 9
            AddColumn(mainTable, "Current On Order");                     // 10
            AddColumn(mainTable, "Per Unit Cost WM");                     // 11
            AddColumn(mainTable, "Optimal PP Covered Uni Retail");        // 12
            AddColumn(mainTable, "Case Cost Needed to Cover PP");         // 13
            AddColumn(mainTable, "Markdown $ At Cost");                   // 14
            AddColumn(mainTable, "Markdown $ At Retail");                 // 15
            AddColumn(mainTable, "Old Margin");                           // 16
            AddColumn(mainTable, "New Margin");                           // 17

            // local field for inserting data to table
            double[] price = GetPriceList();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();

                row[0] = sku;                                                        // item number
                double msrp = Convert.ToDouble(GetData(sku)[0]) * price[0];
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
        protected override ArrayList GetData(string sku)
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
        private double[] GetPriceList()
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
