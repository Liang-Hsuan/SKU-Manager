using SKU_Manager.SKUExportModules.Tables;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules
{
    public abstract class AdminTable : Table
    {
        // the main table that will be return to client
        protected DataTable MainTable = new DataTable();

        // field for database connection
        protected SqlConnection Connection = new SqlConnection(Credentials.DesignCon);

        // fields for progress 
        public int Total { get; protected set; }
        public int Current { get; protected set; }

        /* the most major method for the class -> return table to the client */
        public abstract DataTable GetTable();

        /* method that add new column to table */
        protected void AddColumn(DataTable table, string name, bool checkbox)
        {
            // set up column
            DataColumn column = new DataColumn {ColumnName = name};
            if (checkbox)
                column.DataType = typeof(bool);

            // add column to table
            table.Columns.Add(column);
        }
    }
}
