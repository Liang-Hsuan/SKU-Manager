using System.IO;
using System.Linq;

namespace SKU_Manager.SupportingClasses.Photo
{
    /*
     * A class that return the images of the sku
     */
    public class ImageSearch
    {
        // fields for searching image
        private const string START_DIR = @"Z:\Public\Product Media Content";

        // field for dropboxUri
        private const string DROPBOX_URI = "https://dl.dropboxusercontent.com/u/21921657/Product%20Media%20Content/";

        #region Get Image
        /* return all pure product image */
        public string[] getImage(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = START_DIR;

            // get the path to the target directory
            if (Directory.GetDirectories(targetDirectory).Any(directory => directory.Contains(prefix)))
                targetDirectory += "/" + prefix;

            // add found images to the list
            return (from image in Directory.GetFiles(targetDirectory, "*.jpg") where image.Contains(sku) && !image.Contains("GROUP") && !image.Contains("MODEL") select image.Substring(image.LastIndexOf('\\') + 1)).ToArray();
        }

        /* return all group product image */
        public string[] getGroup(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = START_DIR;

            // get the path to the target directory
            if (Directory.GetDirectories(targetDirectory).Any(directory => directory.Contains(prefix)))
                targetDirectory += "\\" + prefix;

            // add found group images to the list
            return (from image in Directory.GetFiles(targetDirectory, "*.jpg") where image.Contains(sku) && image.Contains("GROUP") && !image.Contains("MODEL") select image.Substring(image.LastIndexOf('\\') + 1)).ToArray();
        }

        /* return all model product image */
        public string[] getModel(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // initialize the target directory 
            string targetDirectory = START_DIR;

            // get the path to the target directory
            if (Directory.GetDirectories(targetDirectory).Any(directory => directory.Contains(prefix)))
                targetDirectory += "/" + prefix;

            // add found model images to the list
            return (from image in Directory.GetFiles(targetDirectory, "*.jpg") where image.Contains(sku) && !image.Contains("GROUP") && image.Contains("MODEL") select image.Substring(image.LastIndexOf('\\') + 1)).ToArray();
        }

        /* return all template product image */
        public string[] getTemplate(string sku)
        {
            // initialize the template directory 
            string templateDirectory = START_DIR + @"\1_DESIGN TEMPLATE LAYOUTS";

            // add found model images to the list
            return (from image in Directory.GetFiles(templateDirectory, "*.jpg") where image.Contains(sku) select image.Substring(image.LastIndexOf('\\') + 1)).ToArray();
        }
        #endregion

        #region Get URI
        /* return all pure product image in uri form */
        public string[] getImageUri(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // add imge to the list
            return getImage(sku).Select(name => DROPBOX_URI + prefix + "/" + name).ToArray();
        }

        /* return all group product image in uri form */
        public string[] getGroupUri(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // add imge to the list
            return getGroup(sku).Select(name => DROPBOX_URI + prefix + "/" + name).ToArray();
        }

        /* return all model product image in uri form */
        public string[] getModelUri(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // add imge to the list
            return getModel(sku).Select(name => DROPBOX_URI + prefix + "/" + name).ToArray();
        }

        /* return all template product image in uri form */
        public string[] getTemplateUri(string sku)
        {
            // get the design service code for the product
            string prefix = sku.Substring(0, sku.IndexOf('-'));

            // add imge to the list
            return getTemplate(sku).Select(name => DROPBOX_URI + "1_DESIGN%20TEMPLATE%20LAYOUTS" + prefix + "/" + name).ToArray();
        }
        #endregion

    }
}
