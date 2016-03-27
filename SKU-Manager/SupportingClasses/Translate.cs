using System.IO;
using System.Net;

namespace SKU_Manager.SupportingClasses
{
    /*
     * A static class that translate English to French via Google translate
     */ 
    public static class Translate
    {
        // fields for web request
        private static WebRequest request;
        private static HttpWebResponse response;

        /* translate the english string provided */
        public static string nowTranslate(string englishString)
        {
            // format translate string
            string copy = englishString.Trim();
            copy = copy.Replace("'", string.Empty);
            copy = copy.Replace("\n", " ");
            copy = copy.Replace("\r", " ");
            copy = copy.Replace(" ", "%20");

            // create uri
            string uri = "https://www.googleapis.com/language/translate/v2?key=AIzaSyD9Ea5kxACuae1vnxo9C4MDkg4IXZkbVI8&source=en&target=fr&q=" + copy;

            // retrieve response from Google
            // post request to uri
            request = WebRequest.Create(uri);
            request.Method = "GET";

            try
            {
                // get the response from the server
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                return "Error: " + ex.Message;
            }

            // read all the text from JSON response
            string textJSON;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                textJSON = streamReader.ReadToEnd();

            // get translated text
            int index = textJSON.IndexOf("translatedText") + 18;
            int length = index;
            while (textJSON[length] != '\"')
                length++;

            return textJSON.Substring(index, length - index).Replace("&#39;", "'");
        }
    }
}
