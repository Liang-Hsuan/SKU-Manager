using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules.UpdateInventory.InventoryTable
{
    /*
     * A class that for creating sears inventory table for inventory management
     */
    public class SearsInventoryTable
    {
        // the main table that will be return to client
        protected DataTable mainTable = new DataTable();

        // field for database connection
        protected readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // field for sku data
        private struct Sku
        {
            public string ashlinSku;
            public string searsSku;
        }
        private readonly List<Sku> skuList = new List<Sku>();

        // fields for progress 
        public readonly int Total;
        public int Current;

        /* constructor that get all the sku that are on sears */
        public SearsInventoryTable()
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, SKU_SEARS_CA FROM master_SKU_Attributes WHERE SKU_SEARS_CA != '';", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sku sku = new Sku();
                    sku.ashlinSku = reader.GetString(0);
                    sku.searsSku = reader.GetString(1);
                    skuList.Add(sku);
                }
            }

            // initialize progress
            Total = skuList.Count;
            Current = 0;
        }

        /* the most major method for the class -> return table to the client */
        public DataTable getTable()
        {
            // reset table just in case and set current to zero
            mainTable.Reset();
            Current = 0;

            addColumn(mainTable, "Ashlin SKU", false);
            addColumn(mainTable, "Sears SKU", false);
            addColumn(mainTable, "BP Item ID", false);
            addColumn(mainTable, "On Hand", false);
            addColumn(mainTable, "Reorder Quantity", false);
            addColumn(mainTable, "Purchase Order", true);
            addColumn(mainTable, "Discontinue", true);

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row
            foreach (Sku sku in skuList)
            {
                var row = mainTable.NewRow();
                Current++;

                row[0] = sku.ashlinSku;                                 // ashlin sku
                row[1] = sku.searsSku;                                  // sears sku
                try
                {
                    DataRow rowCopy = table.Select("SKU = \'" + sku.ashlinSku + "\'")[0];
                    row[2] = rowCopy[1];                                // bp item id
                    row[3] = rowCopy[2];                                // on hand
                    row[4] = rowCopy[3];                                // reorder quantity
                }
                catch { }
                row[5] = false;                                         // purchase order
                row[6] = false;                                         // discontinue

                mainTable.Rows.Add(row);
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* method that add new column to table */
        private void addColumn(DataTable table, string name, bool checkbox)
        {
            // set up column
            DataColumn column = new DataColumn();
            column.ColumnName = name;
            if (checkbox)
                column.DataType = typeof(bool);

            // add column to table
            table.Columns.Add(column);
        }
    }
}
