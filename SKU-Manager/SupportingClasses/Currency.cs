using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace SKU_Manager.SupportingClasses
{
    /*
     * A class that return the lastest currency
     */
    public static class Currency
    {
        // field for keep track currency right now
        public static string BrightpearlCurrency { get; set; }
        public static string SageCurrency { get; set; }
        public static string AsiCurrency { get; set; }

        // field for currency rate
        public static readonly double Usd;

        /* constructor that initialize currency rate */
        static Currency()
        {
            // get the rate for USD currency
            using (var connection = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.Designcs))
            {
                var command = new System.Data.SqlClient.SqlCommand("SELECT Value FROM Currency WHERE Currency = 'USD'", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                Usd = reader.GetDouble(0);
            }
        }

        /* method that return latest currency */
        public static Dictionary<string, double> GetCurrency(string baseCurrency)
        {
            // create uri
            string uri = "http://api.fixer.io/latest?base=" + baseCurrency;

            // post request to uri
            WebRequest request = WebRequest.Create(uri);
            request.Method = "GET";

            // get the response from the server
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                return null;
            }

            // read all the text from JSON response
            string textJson;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                textJson = streamReader.ReadToEnd();

            // deserialize json to key value
            var info = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(textJson);

            // adding Currency and Rate to the dictionary
            Dictionary<string, double> dic = new Dictionary<string, double>();
            foreach (var currency in info["rates"])
                dic.Add(currency.Key, (double) currency.Value);

            return dic;
        }
    }
}
