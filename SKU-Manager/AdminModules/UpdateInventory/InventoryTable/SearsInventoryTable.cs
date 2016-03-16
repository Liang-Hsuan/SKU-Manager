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
        private List<string> skuList = new List<string>();

        // fields for progress 
        public readonly int Total;
        public int Current;

        /* constructor that get all the sku that are on sears */
        public SearsInventoryTable()
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_SEARS_CA != '';", connection);
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
        public DataTable getTable()
        {
            // reset table just in case and set current to zero
            mainTable.Reset();
            Current = 0;

            addColumn(mainTable, "SKU", false);
            addColumn(mainTable, "BP Item ID", false);
            addColumn(mainTable, "On Hand", false);
            addColumn(mainTable, "Purchase Order", true);
            addColumn(mainTable, "Discontinue", true);

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            DataRow row;

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row
            foreach (string sku in skuList)
            {
                row = mainTable.NewRow();

                try
                {
                    row[0] = sku;                                           // sku
                    row[1] = table.Select("SKU = \'" + sku + "\'")[0][1];   // bp item id
                    row[2] = table.Select("SKU = \'" + sku + "\'")[0][2];   // on hand
                }
                catch
                {
                    continue;
                }

                mainTable.Rows.Add(row);
                Current++;
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
