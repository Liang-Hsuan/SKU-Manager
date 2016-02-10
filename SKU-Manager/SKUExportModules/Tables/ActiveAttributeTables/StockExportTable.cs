using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables
{
    /*
     * A class that return stock export table
     */
    class StockExportTable : ExportTable
    {
        /* constructor that initializes fields */
        public StockExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "SKU");           // 1
            addColumn(mainTable, "BP Item#");      // 2
            addColumn(mainTable, "Quantity");      // 3

            // local field for inserting data to table
            DataRow row;
            Product product = new Product();

            // start load data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                row = mainTable.NewRow();

                row[0] = sku;                           // sku
                row[1] = product.getProductId(sku);     // bp item#
                row[2] = product.getQuantity(sku);      // quantity 

                mainTable.Rows.Add(row);
                progress++;
            }

            // end loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'TRUE\' ORDER BY SKU_Ashlin;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skuList.Add(reader.GetString(0));
            }
            connection.Close();

            return skuList.ToArray();
        }
    }
}
