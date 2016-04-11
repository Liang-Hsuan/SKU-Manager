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
            skuList = getSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
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
            double[] price = getPriceList();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();

                row[0] = "ashlin_bpg";                                           // brand
                row[1] = "nishis_boutique";                                      // store name
                row[2] = sku;                                                    // sku
                double msrp = Convert.ToDouble(getData(sku)[0]) * price[0];
                row[3] = Math.Ceiling(msrp * (1 - price[1] / 100)) - (1 - price[2]);      // supplier suggested retail price
                row[4] = msrp;                                                            // msrp
                row[5] = Math.Ceiling(msrp * (1 - price[1] / 100)) - (1 - price[2]);      // supplier list price

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
        private double[] getPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents
            double[] list = new double[3];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents FROM Channel_Pricing WHERE Channel_No = 1005";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = Convert.ToDouble(reader.GetValue(0));
            list[2] = Convert.ToDouble(reader.GetValue(1));
            connection.Close();

            return list;
        }
    }
}
