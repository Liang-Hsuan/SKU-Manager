using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SupportingClasses
{
    /* 
     * A class that receive sku and return the alt text for it
     */
    class AltText
    {
        // fields for database connection
        private string connectionString = Properties.Settings.Default.Designcs;
        private SqlConnection connection;

        /* constructor that initialize database connection */
        public AltText()
        {
            connection = new SqlConnection(connectionString);
        }

        /* method that return the alt text from the given sku */
        public string getAlt(string sku)
        {
            // local fields for storing data
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
    }
}
