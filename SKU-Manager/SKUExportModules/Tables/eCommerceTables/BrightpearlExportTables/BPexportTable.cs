using System.Collections.Generic;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * An abstract class that inherient ExportTable class and override getSKU for all Brightpearl subclasses
     */
    abstract class BPexportTable : ExportTable
    {
        /* override the method getSKU() */
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skuList.Add(reader.GetString(0));
            }
            connection.Close();

            return skuList.ToArray();
        }

        /* define other crucial methods that require for all Brightpearl classes */
        abstract protected object[] getData(string sku);
        abstract protected double[] getDiscount();
    }
}
