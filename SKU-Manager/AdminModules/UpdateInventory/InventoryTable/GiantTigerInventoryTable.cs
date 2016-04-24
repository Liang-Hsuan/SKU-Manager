using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules.UpdateInventory.InventoryTable
{
    /*
     * A class for creating giant tiger inventory table for inventory management
     */
    public class GiantTigerInventoryTable : AdminTable
    {
        // field for sku data
        private struct Sku
        {
            public string AshlinSku;
            public string GiantTigerSku;
        }
        private readonly List<Sku> skuList = new List<Sku>();

        /* constructor that get all the sku that are on sears */
        public GiantTigerInventoryTable()
        {
            using (Connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, SKU_GIANT_TIGER FROM master_SKU_Attributes WHERE SKU_GIANT_TIGER != ''", Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sku sku = new Sku
                    {
                        AshlinSku = reader.GetString(0),
                        GiantTigerSku = reader.GetString(1)
                    };
                    skuList.Add(sku);
                }
            }

            // initialize progress
            Total = skuList.Count;
            Current = 0;
        }

        /* the most major method for the class -> return table to the client */
        public override DataTable GetTable()
        {
            // reset table just in case and set current to zero
            MainTable.Reset();
            Current = 0;

            AddColumn(MainTable, "Ashlin SKU", false);          // 1
            AddColumn(MainTable, "Host SKU", false);            // 2
            AddColumn(MainTable, "BP Item ID", false);          // 3
            AddColumn(MainTable, "UPC", false);                 // 4
            AddColumn(MainTable, "Description", false);         // 5
            AddColumn(MainTable, "Unit Cost", false);           // 6
            AddColumn(MainTable, "On Hand", false);             // 7
            AddColumn(MainTable, "Reorder Quantity", false);    // 8
            AddColumn(MainTable, "Reorder Level", false);       // 9
            AddColumn(MainTable, "Purchase Order", true);       // 10
            AddColumn(MainTable, "Discontinued", true);         // 11

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            Connection = new SqlConnection(Credentials.DesignCon);
            double[] price = GetPriceList();
            Connection.Open();
            MainTable.BeginLoadData();

            // add data to each row
            foreach (Sku sku in skuList)
            {
                DataRow row = MainTable.NewRow();
                Current++;

                // get data
                object[] list = GetDate(sku.AshlinSku);

                row[0] = sku.AshlinSku;                                 // ashlin sku
                row[1] = sku.GiantTigerSku;                             // giant tiger sku
                row[3] = list[0];                                       // upc
                row[4] = list[1];                                       // description
                double sellMsrp = Math.Ceiling(Convert.ToDouble(list[2]) * price[0] * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                row[5] = sellMsrp - (price[4] * sellMsrp) + price[3];   // unit cost
                try
                {
                    DataRow rowCopy = table.Select("SKU = \'" + sku.AshlinSku + '\'')[0];
                    row[2] = rowCopy[1];                                // bp item id
                    row[6] = rowCopy[2];                                // on hand
                    row[7] = rowCopy[3];                                // reorder quantity
                    row[8] = rowCopy[4];                                // reorder level
                }
                catch { /* ignore -> null case */ }
                row[9] = false;                                         // purchase order
                row[10] = false;                                        // discontinue

                MainTable.Rows.Add(row);
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* a method that get all necessary data for table generation */
        private object[] GetDate(string sku)
        {
            object[] list = new object[3];

            // [0] upc, [1] description, [2] unit cost
            SqlCommand commnad = new SqlCommand("SELECT UPC_Code_9, Short_Description, Base_Price FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 2; i++)
                list[i] = reader.GetValue(i);

            return list;
        }

        /* method that give price list */
        private double[] GetPriceList()
        {
            // [0] multiplier, [1] msrp disc, [2] sell cents, [3] base ship, [4] gross marg
            double[] list = new double[5];

            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            command.CommandText = "SELECT Msrp_Disc, Sell_Cents, Base_Ship, Gross_Marg FROM Channel_Pricing WHERE Channel_No = 2001";
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetInt32(0);
            list[2] = (double)reader.GetDecimal(1);
            list[3] = (double)reader.GetDecimal(2);
            list[4] = (double)reader.GetDecimal(3);
            Connection.Close();

            return list;
        }
    }
}
