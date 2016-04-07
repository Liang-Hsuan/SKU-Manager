using System.Data;

namespace SKU_Manager.SKUExportModules.Tables
{
    /* 
     * A subclass for ExportTable that allow fast datatable retrieve
     * NOTE: due to some server runtime issue this class only allowed to be inheriented by a single table channel without having any time expired issue when querying database
     */
    public abstract class ExportTableFast : ExportTable
    {
        /* method that return the table that have all desired data */
        protected abstract DataTable GetDataTable();
    }
}
