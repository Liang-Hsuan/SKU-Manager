using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SupportingClasses
{
    /* 
     * A class that receive sku and return the alt text for it
     */
    class AltText
    {
        // fields for sku elements
        private string design;
        private string material;
        private string color;

        // fields for database connection
        private string connectionString = Properties.Settings.Default.Designcs;
        private SqlConnection connection;
        private SqlDataAdapter adapter;

        /* constructor that initialize database connection */
        public AltText()
        {
            connection = new SqlConnection(connectionString);
        }

        public string getAlt(string sku)
        {
            // local fields for storing data
            DataTable table = new DataTable();
            string alt = "Ashlin® ";

            // get the first two of elements in the sku (design and material)
            string firstTwo = sku.Substring(0, sku.LastIndexOf('-'));

            // allocate elements from sku
            color = sku.Substring(sku.LastIndexOf('-') + 1);
            material = firstTwo.Substring(firstTwo.LastIndexOf('-') + 1);
            design = sku.Substring(0, sku.IndexOf('-'));

            // search design 
            adapter = new SqlDataAdapter("SELECT Short_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();
            alt += table.Rows[0][0] + " ";
            table.Reset();

            // search material
            adapter = new SqlDataAdapter("SELECT Material_Description_Short FROM ref_Materials WHERE Material_Code = \'" + material + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();
            alt += table.Rows[0][0] + " ";
            table.Reset();

            // search material
            adapter = new SqlDataAdapter("SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + color + "\';", connection);
            connection.Open();
            adapter.Fill(table);
            connection.Close();
            alt += table.Rows[0][0];

            return alt;
        }
    }
}
