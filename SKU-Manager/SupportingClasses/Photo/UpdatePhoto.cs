using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SupportingClasses.Photo
{
   /*
    * A class that update all photos found in dropbox to sku database
    */
    class UpdatePhoto
    {
        // field that finds and store all sku
        private string connectionString = Properties.Settings.Default.Designcs;
        private List<string> skuList = new List<string>();
        ImageSearch imageSearch = new ImageSearch();

        /* constructor that initilize that store all sku data */
        public UpdatePhoto()
        {
            // local supporting fields
            int count = 0;
            DataTable table = new DataTable();

            // getting sku data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_Ashlin is not NULL", connection);
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM master_SKU_Attributes WHERE SKU_Ashlin is not NULL", connection);
                connection.Open();
                adapter.Fill(table);
                count = (int)command.ExecuteScalar();
            }

            // store sku data name in the list
            for (int i = 0; i < count; i++)
            {
                skuList.Add(table.Rows[i][0].ToString());
            }
        }

        /* update all photo and put them in database */
        public void startUpdate()
        {
            // local field for storing found uri
            string[] image;

            // puting uri to database by looping through the list (getting sku name list)
            foreach (string sku in skuList)
            {
                // get image uri and put them in database, if not found eliminate them in database
                image = imageSearch.getImageUri(sku);
                putImageInDatabase(sku, image);

                // get group uri and put them in database, if not found eliminate them in database
                image = imageSearch.getGroupUri(sku);
                putGroupInDatabase(sku, image);

                // get model uri and put them in database, if not found eliminate them in database
                image = imageSearch.getModelUri(sku);
                putModelInDatabase(sku, image);

                // get template uri and put them in database, if not found eliminate them in database
                image = imageSearch.getTemplateUri(sku);
                putTemplateInDatabase(sku, image);
            }
        }

        /* put the given image uri to database */
        private void putImageInDatabase(string sku, string[] imageUri)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // local field for looping through column in table to add uri
                int i = 1;

                // start adding
                foreach (string uri in imageUri)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_" + i + "_Path = \'" + uri + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    i++;
                }

                // assign null to the columns left
                for (; i <= 10; i++)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_" + i + "_Path = NULL WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /* put the given group image uri to database */
        private void putGroupInDatabase(string sku, string[] groupUri)
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // local field for looping through column in table to add uri
                int i = 1;

                // start adding
                foreach (string uri in groupUri)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_Group_" + i + "_Path = \'" + uri + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    i++;
                }

                // assign null to the columns left
                for (; i <= 5; i++)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_Group_" + i + "_Path = NULL WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /* put the given model image uri to database */
        private void putModelInDatabase(string sku, string[] modelUri)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // local field for looping through column in table to add uri
                int i = 1;

                // start adding
                foreach (string uri in modelUri)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_Model_" + i + "_Path = \'" + uri + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    i++;
                }

                // assign null to the columns left
                for (; i <= 5; i++)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Image_Model_" + i + "_Path = NULL WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /* put the given template image uri to database */
        private void putTemplateInDatabase(string sku, string[] templateUri)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // local field for looping through column in table to add uri
                int i = 1;

                // start adding
                foreach (string uri in templateUri)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Template_URL_" + i + " = \'" + uri + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    i++;
                }

                // assign null to the columns left
                for (; i <= 2; i++)
                {
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Template_URL_" + i + " = NULL WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
