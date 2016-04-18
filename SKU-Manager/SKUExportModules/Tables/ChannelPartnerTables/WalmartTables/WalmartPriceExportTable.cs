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
                double sellMsrp = Math.Ceiling(msrp * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                row[1] = msrp;                                                       // total VNPK case cost
                row[2] = sellMsrp;                                                   // unit retail
                row[3] = sellMsrp - (price[4] * sellMsrp) + price[3];                // whse pack cost

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
            SqlCommand command = new SqlCommand("SELECT Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list.Add(reader.GetValue(0));

            return list;
        }
    }
}
