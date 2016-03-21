﻿using System.IO;
using System.Net;

namespace SKU_Manager.SupportingClasses
{
    /*
     * A class that translate English to French via Google translate
     */ 
    public class Translate
    {
        // fields for web request
        private WebRequest request;
        private HttpWebResponse response;

        /* translate the english string provided */
        public string nowTranslate(string englishString)
        {
            // replace space with %20 and single quotation to nothing
            string copy = englishString.Trim().Replace(" ", "%20");
            copy = copy.Replace("'", string.Empty);

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

            return textJSON.Substring(index, length - index);
        }
    }
}
