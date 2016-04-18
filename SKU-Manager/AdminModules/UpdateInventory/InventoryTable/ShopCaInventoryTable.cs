using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules.UpdateInventory.InventoryTable
{
    /*
     * A class for creating shop.ca inventory table for inventory management
     */
    public class ShopCaInventoryTable : AdminTable
    {
        // field for storing sku data
        private readonly List<string> skuList = new List<string>();

        /* constructor that get all the sku that are on shop.ca */
        public ShopCaInventoryTable()
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_SHOP_CA != ''", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    skuList.Add(reader.GetString(0));
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

            AddColumn(mainTable, "Ashlin SKU", false);
            AddColumn(mainTable, "BP Item ID", false);
            AddColumn(mainTable, "On Hand", false);
            AddColumn(mainTable, "Reorder Quantity", false);
            AddColumn(mainTable, "Reorder Level", false);
            AddColumn(mainTable, "Purchase Order", true);
            AddColumn(mainTable, "Discontinue", true);

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                Current++;

                row[0] = sku;                                 // ashlin sku
                try
                {
                    DataRow rowCopy = table.Select("SKU = \'" + sku + '\'')[0];
                    row[1] = rowCopy[1];                      // bp item id
                    row[2] = rowCopy[2];                      // on hand
                    row[3] = rowCopy[3];                      // reorder quantity
                    row[4] = rowCopy[4];                      // reorder level
                }
                catch { /* ignore -> null case */ }
                row[5] = false;                               // purchase order
                row[6] = false;                               // discontinue

                mainTable.Rows.Add(row);
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }
    }
}
