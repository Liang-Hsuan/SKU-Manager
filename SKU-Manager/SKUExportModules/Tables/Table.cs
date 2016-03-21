using System.Data;

namespace SKU_Manager.SKUExportModules.Tables
{
    /*
     *  Interface for tables
     */
    public interface Table
    {
        /* method that return the table */
        DataTable getTable();
    }
}
