using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive family table
     */
    public class InactiveFamilyTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveFamilyTable()
        {
            mainTable = new DataTable();
        }

        /* method that get the table */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // connect to database and grab the all the active colors' data and put them into the table
            using (connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM inactive_family_list_new;", connection);
                connection.Open();
                adapter.Fill(mainTable);
            }

            return mainTable;
        }

        /* not implement get sku method */
        protected override string[] getSKU()
        {
            throw new NotImplementedException();
        }
    }
}
