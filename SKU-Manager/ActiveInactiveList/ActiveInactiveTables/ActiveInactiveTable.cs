using System.Data;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /* 
     * a abstract class that define methods for all active and inactive list classes
     */
    public abstract class ActiveInactiveTable
    {
        // field for database connection
        protected string connectionString = Properties.Settings.Default.Designcs;

        // field for storing data and return 
        protected DataTable mainTable;

        /* return the table */
        public DataTable Table
        {
            get
            {
                return getTable();
            }
        }

        /* method that get the table */
        abstract protected DataTable getTable();
    }
}
