﻿using SKU_Manager.SKUExportModules.Tables;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules
{
    public abstract class AdminTable : Table
    {
        // the main table that will be return to client
        protected DataTable mainTable = new DataTable();

        // field for database connection
        protected readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // fields for progress 
        public int Total { get; protected set; }
        public int Current { get; protected set; }

        /* the most major method for the class -> return table to the client */
        public abstract DataTable getTable();

        /* method that add new column to table */
        protected void addColumn(DataTable table, string name, bool checkbox)
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