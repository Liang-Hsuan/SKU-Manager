using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables
{
    /* 
     * A subclass for ExportTable that allow fast datatable retrieve
     */
    public abstract class ExportTableFast : ExportTable
    {
        /* method that return the table that have all desired data */
        abstract protected DataTable getDataTable();
    }
}
