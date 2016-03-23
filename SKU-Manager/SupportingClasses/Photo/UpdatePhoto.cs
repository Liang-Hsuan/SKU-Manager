using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SKU_Manager.SupportingClasses.Photo
{
    /*
     * A class that update all photos found in dropbox to sku database
     */
    public class UpdatePhoto
    {
        // field that finds and store all sku
        private readonly string connectionString = Properties.Settings.Default.Designcs;
        private readonly List<string> skuList = new List<string>();
        private readonly ImageSearch imageSearch = new ImageSearch();

        // fields for getting progress
        public int Progress { get; private set; } = 0;
        public int Total => skuList.Count;

        /* constructor that initilize that store all sku data */
        public UpdatePhoto()
        {
            // getting sku data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    skuList.Add(reader.GetString(0));
            }
        }

        /* update all photo and put them in database */
        public void startUpdate()
        {
            // puting uri to database by looping through the list (getting sku name list)
            foreach (string sku in skuList)
            {
                // get uri array
                string[] image = imageSearch.getImageUri(sku);
                string[] group = imageSearch.getGroupUri(sku);
                string[] model = imageSearch.getModelUri(sku);
                string[] template = imageSearch.getTemplateUri(sku);

                // start update
                putImageInDatabase(sku, image, group, model, template);

                Progress++;
            }
        }

        /* put the given image uri to database */
        private void putImageInDatabase(string sku, string[] imageUri, string[] groupUri, string[] modelUri, string[] templateUri)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // local field for looping through column in table to add uri
                string commandString = "UPDATE master_SKU_Attributes SET ";
                int i = 1;

                #region Image
                foreach (string uri in imageUri.TakeWhile(uri => i <= 10))
                {
                    commandString += "Image_" + i + "_Path = \'" + uri + "\',";
                    i++;
                }

                for (; i <= 10; i++)
                    commandString += "Image_" + i + "_Path = NULL,";
                #endregion

                i = 1;

                #region Group
                foreach (string uri in groupUri.TakeWhile(uri => i <= 5))
                {
                    commandString += "Image_Group_" + i + "_Path = \'" + uri + "\',";
                    i++;
                }

                for (; i <= 5; i++)
                    commandString += "Image_Group_" + i + "_Path = NULL,";
                #endregion

                i = 1;

                #region Model
                foreach (string uri in modelUri.TakeWhile(uri => i <= 5))
                {
                    commandString += "Image_Model_" + i + "_Path = \'" + uri + "\',";
                    i++;
                }

                for (; i <= 5; i++)
                    commandString += "Image_Model_" + i + "_Path = NULL,";
                #endregion

                i = 1;

                #region Template
                foreach (string uri in templateUri.TakeWhile(uri => i <= 2))
                {
                    commandString += "Template_URL_" + i + " = \'" + uri + "\',";
                    i++;
                }

                for (; i <= 2; i++)
                    commandString += "Template_URL_" + i + " = NULL,";
                #endregion

                // remove last comma
                commandString = commandString.Remove(commandString.Length - 1);
                commandString += " WHERE SKU_Ashlin = \'" + sku + "\';";

                // start update
                SqlCommand command = new SqlCommand(commandString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
