using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SupportingClasses
{
    /* 
     * A class that receive sku and return the alt text for it
     */
    public static class AltText
    {
        // fields for database connection
        private static readonly SqlConnection connection =  new SqlConnection(Properties.Settings.Default.Designcs);

        /* method that return the alt text from the given sku -> the sku already exist */
        public static string GetAltWithSkuExist(string sku)
        {
            // local fields for generating alt text
            string alt = "Ashlin® ";

            // search design 
            SqlCommand command = new SqlCommand("SELECT Short_Description, Material_Description_Short, Colour_Description_Short FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Materials material ON material.Material_Code = sku.Material_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            alt += reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
            connection.Close();

            return alt;
        }

        /* method that return alt text from the given sku -> the sku does not exist */
        public static string GetAltWithSkuNotExist(string sku)
        {
            // local fields for storing data
            string alt = "Ashlin® ";

            // allocating elemets from sku
            string firstTwo = sku.Remove(sku.LastIndexOf('-'));
            string design = sku.Substring(0, sku.IndexOf('-'));
            string material = firstTwo.Substring(firstTwo.IndexOf('-') + 1);
            string color = sku.Substring(sku.LastIndexOf('-') + 1);

            SqlCommand command = new SqlCommand("SELECT Short_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            alt += reader.GetString(0) + " ";
            reader.Close();

            command.CommandText = "SELECT Material_Description_Short FROM ref_Materials WHERE Material_Code = \'" + material + "\'";
            reader = command.ExecuteReader();
            reader.Read();
            alt += reader.GetString(0) + ", ";
            reader.Close();

            command.CommandText = "SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + color + "\'";
            reader = command.ExecuteReader();
            reader.Read();
            alt += reader.GetString(0);
            connection.Close();

            return alt;
        }
    }
}
