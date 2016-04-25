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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU");                // 1
            AddColumn(MainTable, "BP Item#");           // 2
            AddColumn(MainTable, "Quantity");           // 3
            AddColumn(MainTable, "Reorder Quantity");   // 4 
            AddColumn(MainTable, "Reorder Level");      // 5

            // local field for inserting data to table
            Product product = new Product();
            List<Values> list = product.GetStockList();
            bool found = false;

            // start load data
            MainTable.BeginLoadData();

            foreach (string sku in SkuList)
            {
                DataRow row = MainTable.NewRow();

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

                MainTable.Rows.Add(row);
                Progress++;
            }

            // end loading data
            MainTable.EndLoadData();

            return MainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }
    }
}
