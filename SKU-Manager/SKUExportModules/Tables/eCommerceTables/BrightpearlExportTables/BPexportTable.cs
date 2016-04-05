using System.Collections.Generic;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * An abstract class that inherient ExportTable class and override getSKU for all Brightpearl subclasses
     */
    public abstract class BPexportTable : ExportTable
    {
        /* override the method getSKU() */
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* set a method for getting data from given sku */
        protected object[] getData(string sku)
        {
            // local fields for storing data
            object[] list = new object[5];

            // grab data from design database
            // [0] field that related to price
            // [1] for price calculation, [2] description, [3] description, [4] description
            SqlCommand command = new SqlCommand("SELECT Base_Price, Components, Short_Description, Material_Description_Short, Colour_Description_Short " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\'", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 4; i++)
                list[i] = reader.GetValue(i);

            return list;
        }

        /* define a crucial method that require for all Brightpearl classes */
        protected abstract double[] getDiscount();
    }
}
