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
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, SKU_GIANT_TIGER FROM master_SKU_Attributes WHERE SKU_GIANT_TIGER != ''", connection);
                connection.Open();
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
            mainTable.Reset();
            Current = 0;

            AddColumn(mainTable, "Giant Tiger SKU", false);     // 1
            AddColumn(mainTable, "Ashlin SKU", false);          // 2
            AddColumn(mainTable, "BP Item ID", false);          // 3
            AddColumn(mainTable, "UPC", false);                 // 4
            AddColumn(mainTable, "Description", false);         // 5
            AddColumn(mainTable, "Unit Cost", false);           // 6
            AddColumn(mainTable, "On Hand", false);             // 7
            AddColumn(mainTable, "Reorder Quantity", false);    // 8
            AddColumn(mainTable, "Reorder Level", false);       // 9
            AddColumn(mainTable, "Purchase Order", true);       // 10

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            connection.Open();
            mainTable.BeginLoadData();

            // add data to each row
            foreach (Sku sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                Current++;

                // get data
                object[] list = GetDate(sku.AshlinSku);

                row[0] = sku.AshlinSku;                                 // ashlin sku
                row[1] = sku.GiantTigerSku;                             // giant tiger sku
                row[3] = list[0];                                       // upc
                row[4] = list[1];                                       // description
                row[5] = list[2];                                       // unit cost
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

                mainTable.Rows.Add(row);
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all necessary data for table generation */
        private object[] GetDate(string sku)
        {
            object[] list = new object[3];

            // [0] upc, [1] description, [2] unit cost
            SqlCommand commnad = new SqlCommand("SELECT UPC_Code_9, Short_Description, Base_Price FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            SqlDataReader reader = commnad.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 2; i++)
                list[i] = reader.GetValue(i);

            return list;
        }
    }
}
