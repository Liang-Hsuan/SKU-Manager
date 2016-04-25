using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables
{
    public abstract class ExportTable : Table
    {
        // field for the main table
        protected DataTable MainTable;

        // field for database connection
        protected SqlConnection Connection = new SqlConnection(Credentials.DesignCon);

        // supporting field
        public int Progress { get; protected set; } = 0;
        protected string[] SkuList;

        /* inherient the return table method -> the most import one */
        public abstract DataTable GetTable();

        /* return the total number of sku */
        public int Total => SkuList.Length;

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
