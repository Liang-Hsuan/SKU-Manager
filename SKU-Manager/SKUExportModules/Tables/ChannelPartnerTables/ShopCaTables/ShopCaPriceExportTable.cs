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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "supplier id");                         // 1
            AddColumn(MainTable, "store name");                          // 2
            AddColumn(MainTable, "sku");                                 // 3
            AddColumn(MainTable, "supplier suggested retail price");     // 4
            AddColumn(MainTable, "msrp");                                // 5
            AddColumn(MainTable, "supplier list price");                 // 6
            AddColumn(MainTable, "supplier cost");                       // 7
            AddColumn(MainTable, "effective");                           // 8
            AddColumn(MainTable, "effective end date");                  // 9
            AddColumn(MainTable, "is point");                            // 10
            AddColumn(MainTable, "currency");                            // 11
            AddColumn(MainTable, "standard ship cost");                  // 12
            AddColumn(MainTable, "priority shup cost");                  // 13
            AddColumn(MainTable, "ab tax exempt");                       // 14
            AddColumn(MainTable, "bc tax exempt");                       // 15
            AddColumn(MainTable, "mb tax exempt");                       // 16
            AddColumn(MainTable, "nb tax exempt");                       // 17
            AddColumn(MainTable, "nl tax exempt");                       // 18
            AddColumn(MainTable, "nt tax exempt");                       // 19
            AddColumn(MainTable, "ns tax exempt");                       // 20
            AddColumn(MainTable, "nu tax exempt");                       // 21
            AddColumn(MainTable, "on tax exempt");                       // 22
            AddColumn(MainTable, "pe tax exempt");                       // 23
            AddColumn(MainTable, "qc tax exempt");                       // 24
            AddColumn(MainTable, "sk tax exempt");                       // 25
            AddColumn(MainTable, "yt tax exempt");                       // 26

            // local field for inserting data to table
            double[] price = GetPriceList();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                DataRow row = MainTable.NewRow();

                row[0] = "ashlin_bpg";                                           // brand
                row[1] = "nishis_boutique";                                      // store name
                row[2] = sku;                                                    // sku
                double msrp = Convert.ToDouble(GetData(sku)[0]) * price[0];
                double sellMsrp = Math.Ceiling(msrp * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                row[3] = sellMsrp;                                               // supplier suggested retail price
                row[4] = msrp;                                                   // msrp
                row[5] = sellMsrp;                                               // supplier list price

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

        /* a method that return the all fields for price calculation */
        private double[] GetPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship
            double[] list = new double[4];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier", Connection);
            Connection.Open();
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
            Connection.Close();

            return list;
        }
    }
}
