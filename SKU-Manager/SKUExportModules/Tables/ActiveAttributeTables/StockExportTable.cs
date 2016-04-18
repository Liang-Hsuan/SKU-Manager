using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SKU_Manager.SupportingClasses.ProductDetail;

namespace SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables
{
    /*
     * A class that return stock export table
     */
    public class StockExportTable : ExportTable
    {
        /* constructor that initializes fields */
        public StockExportTable()
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
            AddColumn(mainTable, "SKU");                // 1
            AddColumn(mainTable, "BP Item#");           // 2
            AddColumn(mainTable, "Quantity");           // 3
            AddColumn(mainTable, "Reorder Quantity");   // 4 
            AddColumn(mainTable, "Reorder Level");      // 5

            // local field for inserting data to table
            Product product = new Product();
            List<Values> list = product.GetStockList();
            bool found = false;

            // start load data
            mainTable.BeginLoadData();

            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();

                row[0] = sku;

                // looking for the data for this sku
                foreach (Values value in list.Where(value => sku == value.Sku))
                {
                    row[1] = value.ProductId;
                    row[2] = value.Quantity;
                    row[3] = value.ReorderQuantity;
                    row[4] = value.ReorderLevel;
                    list.Remove(value);
                    found = true;
                    break;
                }

                if (!found)
                {
                    row[2] = -1;
                    row[3] = -1;
                    row[4] = -1;
                }

                found = false;

                mainTable.Rows.Add(row);
                Progress++;
            }

            // end loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }
    }
}
