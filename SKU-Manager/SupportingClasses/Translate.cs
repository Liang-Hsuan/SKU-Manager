using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

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
            string textJson;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                textJson = streamReader.ReadToEnd();

            // deserialize json to key value
            var info = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(textJson);

            return info["data"]["translations"][0]["translatedText"].Replace("&#39;", "'");
        }
    }
}
