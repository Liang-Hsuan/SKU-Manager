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
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "supplier id");                         // 1
            AddColumn(mainTable, "store name");                          // 2
            AddColumn(mainTable, "sku");                                 // 3
            AddColumn(mainTable, "supplier suggested retail price");     // 4
            AddColumn(mainTable, "msrp");                                // 5
            AddColumn(mainTable, "supplier list price");                 // 6
            AddColumn(mainTable, "supplier cost");                       // 7
            AddColumn(mainTable, "effective");                           // 8
            AddColumn(mainTable, "effective end date");                  // 9
            AddColumn(mainTable, "is point");                            // 10
            AddColumn(mainTable, "currency");                            // 11
            AddColumn(mainTable, "standard ship cost");                  // 12
            AddColumn(mainTable, "priority shup cost");                  // 13
            AddColumn(mainTable, "ab tax exempt");                       // 14
            AddColumn(mainTable, "bc tax exempt");                       // 15
            AddColumn(mainTable, "mb tax exempt");                       // 16
            AddColumn(mainTable, "nb tax exempt");                       // 17
            AddColumn(mainTable, "nl tax exempt");                       // 18
            AddColumn(mainTable, "nt tax exempt");                       // 19
            AddColumn(mainTable, "ns tax exempt");                       // 20
            AddColumn(mainTable, "nu tax exempt");                       // 21
            AddColumn(mainTable, "on tax exempt");                       // 22
            AddColumn(mainTable, "pe tax exempt");                       // 23
            AddColumn(mainTable, "qc tax exempt");                       // 24
            AddColumn(mainTable, "sk tax exempt");                       // 25
            AddColumn(mainTable, "yt tax exempt");                       // 26

            // local field for inserting data to table
            double[] price = GetPriceList();

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
                double msrp = Convert.ToDouble(GetData(sku)[0]) * price[0];
                double sellMsrp = Math.Ceiling(msrp * (1 - price[1] / 100)) - (1 - price[2]) + price[3];
                row[3] = sellMsrp;                                               // supplier suggested retail price
                row[4] = msrp;                                                   // msrp
                row[5] = sellMsrp;                                               // supplier list price

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
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship
            double[] list = new double[4];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship FROM Channel_Pricing WHERE Channel_No = 1005";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            connection.Close();

            return list;
        }
    }
}
