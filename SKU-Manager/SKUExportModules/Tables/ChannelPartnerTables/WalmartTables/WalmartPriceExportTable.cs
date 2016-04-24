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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "Item Number");                          // 1
            AddColumn(MainTable, "Total VNPK Case Cost");                 // 2
            AddColumn(MainTable, "Unit Retail");                          // 3
            AddColumn(MainTable, "Whse Pack Cost");                       // 4
            AddColumn(MainTable, "item Description");                     // 5     
            AddColumn(MainTable, "VNPK Case Qty");                        // 6
            AddColumn(MainTable, "Current Total VNPK Case Cost");         // 7
            AddColumn(MainTable, "Current EDLP Retail");                  // 8
            AddColumn(MainTable, "Current On Hand");                      // 9
            AddColumn(MainTable, "Current On Order");                     // 10
            AddColumn(MainTable, "Per Unit Cost WM");                     // 11
            AddColumn(MainTable, "Optimal PP Covered Uni Retail");        // 12
            AddColumn(MainTable, "Case Cost Needed to Cover PP");         // 13
            AddColumn(MainTable, "Markdown $ At Cost");                   // 14
            AddColumn(MainTable, "Markdown $ At Retail");                 // 15
            AddColumn(MainTable, "Old Margin");                           // 16
            AddColumn(MainTable, "New Margin");                           // 17

            // local field for inserting data to table
            double[] price = GetPriceList();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                DataRow row = MainTable.NewRow();

                row[0] = sku;                                                        // item number
                double msrp = Convert.ToDouble(GetData(sku)[0]) * price[0];
                double sellMsrp = Math.Ceiling(msrp * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                row[1] = msrp;                                                       // total VNPK case cost
                row[2] = sellMsrp;                                                   // unit retail
                row[3] = sellMsrp - (price[4] * sellMsrp) + price[3];                // whse pack cost

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList GetData(string sku)
        {
            ArrayList list = new ArrayList();

            // start grabbing data              
            // [0] for all related to price       
            SqlCommand command = new SqlCommand("SELECT Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list.Add(reader.GetValue(0));

            return list;
        }
    }
}
