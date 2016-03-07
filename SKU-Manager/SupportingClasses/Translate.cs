using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private string textJSON;

        // fields for translation
        private List<char> englishList = new List<char>();

        /* translate the english string provided */
        public void nowTranslate(string englishString)
        {
            // replace space with %20
            foreach (char ch in englishString)
            {
                if (ch == ' ')
                {
                    englishList.Add('%');
                    englishList.Add('2');
                    englishList.Add('0');
                }
                else
                    englishList.Add(ch);
            }

            //store new english string to english variable and create the real uri
            char[] englishChar = englishList.ToArray();
            string uri = englishChar.Aggregate("https://www.googleapis.com/language/translate/v2?key=AIzaSyD9Ea5kxACuae1vnxo9C4MDkg4IXZkbVI8&source=en&target=fr&q=", (current, ch) => current + ch);

            // retrieve response from Google
            // post request to uri
            request = WebRequest.Create(uri);
            request.Method = "GET";

            // get the response from the server
            response = (HttpWebResponse)request.GetResponse();
      
            // read all the text from JSON response
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                textJSON = streamReader.ReadToEnd();
            }

            // reset 
            englishList.Clear();
        }

        /* return response string */
        public string getFrench()
        {
            int index = textJSON.IndexOf("translatedText") + 18;
            int length = index;
            while (textJSON[length] != '\"')
                length++;

            return textJSON.Substring(index, length - index); 
        }
    }
}
