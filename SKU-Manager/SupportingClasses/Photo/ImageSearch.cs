using System.Collections.Generic;
using System.IO;

namespace SKU_Manager.SupportingClasses.Photo
{
    class ImageSearch
    {
        // fields for searching image
        private string startDirectory;
        private string prefix;

        // field for dropboxUri
        private const string dropboxUri = "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/";

        /* constructor that initialize the starting directory */
        public ImageSearch()
        {
            startDirectory = @"Z:\Public\Product Media Content";
        }

        /* return all pure product image */
        public string[] getImage(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = startDirectory;

            // get the path to the target directory
            foreach (string directory in Directory.GetDirectories(targetDirectory))
            {
                if (directory.Contains(prefix))
                {
                    targetDirectory += "/" + prefix;
                    break;
                }
            }

            // add found images to the list
            List<string> list = new List<string>();
            foreach (string image in Directory.GetFiles(targetDirectory, "*.jpg"))
            {
                if (image.Contains(sku) && !image.Contains("GROUP") && !image.Contains("MODEL"))
                {
                    // trim the image path to just image code
                    string imageCopy = image.Substring(image.LastIndexOf('\\') + 1);

                    list.Add(imageCopy);
                }
            }

            return list.ToArray();
        }

        /* return all group product image */
        public string[] getGroup(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = startDirectory;

            // get the path to the target directory
            foreach (string directory in Directory.GetDirectories(targetDirectory))
            {
                if (directory.Contains(prefix))
                {
                    targetDirectory += "\\" + prefix;
                    break;
                }
            }

            // add found group images to the list
            List<string> list = new List<string>();
            foreach (string image in Directory.GetFiles(targetDirectory, "*.jpg"))
            {
                if (image.Contains(sku) && image.Contains("GROUP") && !image.Contains("MODEL"))
                {
                    // trim the image path to just image code
                    string imageCopy = image.Substring(image.LastIndexOf('\\') + 1);

                    list.Add(imageCopy);
                }
            }

            return list.ToArray();
        }

        /* return all model product image */
        public string[] getModel(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = startDirectory;

            // get the path to the target directory
            foreach (string directory in Directory.GetDirectories(targetDirectory))
            {
                if (directory.Contains(prefix))
                {
                    targetDirectory += "/" + prefix;
                    break;
                }
            }

            // add found model images to the list
            List<string> list = new List<string>();
            foreach (string image in Directory.GetFiles(targetDirectory, "*.jpg"))
            {
                if (image.Contains(sku) && !image.Contains("GROUP") && image.Contains("MODEL"))
                {
                    // trim the image path to just image code
                    string imageCopy = image.Substring(image.LastIndexOf('\\') + 1);

                    list.Add(imageCopy);
                }
            }

            return list.ToArray();
        }

        /* return all template product image */
        public string[] getTemplate(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the template directory 
            string templateDirectory = startDirectory + @"\1_DESIGN TEMPLATE LAYOUTS";

            // add found model images to the list
            List<string> list = new List<string>();
            foreach (string image in Directory.GetFiles(templateDirectory, "*.jpg"))
            {
                if (image.Contains(sku))
                {
                    // trim the image path to just image code
                    string imageCopy = image.Substring(image.LastIndexOf('\\') + 1);

                    list.Add(imageCopy);
                }
            }

            return list.ToArray();
        }

        /* return all pure product image in uri form */
        public string[] getImageUri(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // list for storing image found
            List<string> list = new List<string>();

            // add imge to the list
            foreach (string name in getImage(sku))
            {
                list.Add(dropboxUri + prefix + "/" + name);
            }

            return list.ToArray();
        }

        /* return all group product image in uri form */
        public string[] getGroupUri(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // list for storing image found
            List<string> list = new List<string>();

            // add imge to the list
            foreach (string name in getGroup(sku))
            {
                list.Add(dropboxUri + prefix + "/" + name);
            }

            return list.ToArray();
        }

        /* return all model product image in uri form */
        public string[] getModelUri(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // list for storing image found
            List<string> list = new List<string>();

            // add imge to the list
            foreach (string name in getModel(sku))
            {
                list.Add(dropboxUri + prefix + "/" + name);
            }

            return list.ToArray();
        }

        /* return all template product image in uri form */
        public string[] getTemplateUri(string sku)
        {
            // get the design service code for the product
            prefix = sku.Substring(0, sku.IndexOf('-'));

            // list for storing image found
            List<string> list = new List<string>();

            // add imge to the list
            foreach (string name in getTemplate(sku))
            {
                list.Add(dropboxUri + "1_DESIGN%20TEMPLATE%20LAYOUTS" + prefix + "/" + name);
            }

            return list.ToArray();
        }
 
    }
}
