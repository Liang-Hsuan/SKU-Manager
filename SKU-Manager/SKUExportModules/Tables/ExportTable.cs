using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables
{
    abstract public class ExportTable : Table
    {
        // field for the main table
        protected DataTable mainTable;

        // field for database connection
        protected SqlConnection connection;

        // supporting field
        public int progress = 0;
        protected string[] skuList;

        /* inherient the return table method -> the most import one */
        abstract public DataTable getTable();

        /* return the total number of sku */
        public int Total
        {
            get
            {
                return skuList.Length;
            }
        }

        /* some supporting private method that will help building the table */
        /* a method that will return all desired SKUs */
        abstract protected string[] getSKU();
        /* method that add new column to table */
        protected void addColumn(DataTable table, string name)
        {
            // set up column
            DataColumn column = new DataColumn();
            column.ColumnName = name;

            // add column to table
            table.Columns.Add(column);
        }
    }
}
