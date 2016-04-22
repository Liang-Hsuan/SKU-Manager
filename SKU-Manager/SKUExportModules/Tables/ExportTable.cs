using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables
{
    public abstract class ExportTable : Table
    {
        // field for the main table
        protected DataTable mainTable;

        // field for database connection
        protected SqlConnection connection = new SqlConnection(Credentials.DesignCon);

        // supporting field
        public int Progress { get; protected set; } = 0;
        protected string[] skuList;

        /* inherient the return table method -> the most import one */
        public abstract DataTable GetTable();

        /* return the total number of sku */
        public int Total => skuList.Length;

        /* some supporting private method that will help building the table */
        /* a method that will return all desired SKUs */
        protected abstract string[] GetSku();
        /* method that add new column to table */
        protected void AddColumn(DataTable table, string name)
        {
            // set up column
            DataColumn column = new DataColumn {ColumnName = name};

            // add column to table
            table.Columns.Add(column);
        }
    }
}
