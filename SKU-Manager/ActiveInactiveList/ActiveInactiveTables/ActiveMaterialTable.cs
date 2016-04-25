using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active material table
     */
    public class ActiveMaterialTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveMaterialTable()
        {
            MainTable = new DataTable();
        }

        /* method that get the table */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // connect to database and grab the all the active materials' data and put them into the table
            using (Connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM active_material_list_new", Connection);
                Connection.Open();
                adapter.Fill(MainTable);
            }

            return MainTable;
        }

        /* not implement get sku method */
        protected override string[] GetSku()
        {
            throw new NotImplementedException();
        }
    }
}
