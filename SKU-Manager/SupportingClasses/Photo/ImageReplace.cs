using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SKU_Manager.SupportingClasses.Photo
{
   /*
    * A class that add image with different name
    */
    class ImageReplace
    {
        // fields for searching image, sku, and upc
        private string startDirectory;
        private List<string> skuList = new List<string>();
        
        // field for database connection
        private string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize the starting directory */
        public ImageReplace()
        {
            startDirectory = @"Z:\Public\Product Media Content";
        }

        /* method that add existing sku image with upc code */
        public void addUPC(string sku, string upc)
        {
            // local supporting fields
            string prefix = sku.Substring(0, sku.IndexOf('-'));
            string targetDirectory = startDirectory;
            int i = 1;    // for naming file

            // check if directory exists
            if (Directory.Exists(startDirectory + "/" + prefix))
            {
                targetDirectory += "/" + prefix;
            }
            else    // no image for this design, return it
            {
                return;
            }

            // start copying a upc code image
            foreach (string image in Directory.GetFiles(targetDirectory, "*.jpg"))
            {
                if (image.Contains(sku))
                {
                    File.Copy(image, targetDirectory + "/" + upc + "_" + i + ".jpg", true);
                    i++;
                }
            }
        }

        /* update all the current existing sku image with a upc code image */
        public void addGlobalUPC()
        {
            // clear the list first
            skuList.Clear();

            // get all the sku from database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes ORDER BY SKU_Ashlin");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skuList.Add(reader.GetString(0));
                }
            }

            // initialize field for stroing upc code data and generate upc
            string[] upcCode;
            UPC upc = new UPC();

            // start adding image
            foreach (string sku in skuList)
            {
                // get the upc code
                upcCode = getUPC(sku);

                // if no upc code assign yet, give them one and update to database
                if (upcCode[0] == "" || upcCode[1] == "")
                {
                    upcCode[0] = upc.getUPC();
                    upcCode[1] = upc.getUPC10(upcCode[0]);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET UPC_Code_9 = \'" + upcCode[0] + "\', UPC_Code_10 = \'" + upcCode[1] + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // add image for 9 and 10 digit upc
                addUPC(sku, upcCode[0]);
                addUPC(sku, upcCode[1]);
            }
        }

        /* return upc code for the given sku */
        private string[] getUPC(string sku)
        {
            // local field for storing data
            DataTable table = new DataTable();
            string[] upcCode = new string[2];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT UPC_Code_9, UPC_Code_10 FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            upcCode[0] = table.Rows[0][0].ToString();
            upcCode[1] = table.Rows[0][1].ToString();

            return upcCode;
        }
    }
}
