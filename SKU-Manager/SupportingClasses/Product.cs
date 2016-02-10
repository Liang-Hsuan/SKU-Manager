using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading;

namespace SKU_Manager.SupportingClasses
{
    /* 
     * A class that can get information about the product from Brightpearl
     */
    class Product
    {
        // get request object for geting information from Brightpearl
        private GetRequest get;

        /* constructor that initilize GetRequest class */
        public Product()
        {
            SqlConnection authenticationConnection = new SqlConnection(Properties.Settings.Default.ASCMcs);
            SqlCommand getAuthetication = new SqlCommand("SELECT Field3_Value, Field1_Value FROM ASCM_Credentials WHERE Source = \'Brightpearl Testing\';", authenticationConnection);
            authenticationConnection.Open();
            SqlDataReader reader = getAuthetication.ExecuteReader();
            reader.Read();
            get = new GetRequest(reader.GetString(0), reader.GetString(1));
            authenticationConnection.Close();
        }

        /* a method that return the quantity of specific sku */
        public int getQuantity(string sku)
        {
            int quantity = get.getQuantity(sku);

            if (quantity == -2)     // server unavailiable 500
            {
                do
                {
                    Thread.Sleep(5000);
                    quantity = getQuantity(sku);
                } while (quantity == -2);
            }
            else if (quantity == -3)    // server bad request 400
            {
                quantity = -1;
            }

            return quantity;
        }

        /* a method that return product id for given sku */
        public string getProductId(string sku)
        {
            // get product id
            string id = get.getProductId(sku);
            if (id == "Error")
            {
                do
                {
                    Thread.Sleep(5000);
                    id = get.getProductId(sku);
                }
                while (id == "Error");
            }

            return id;
        }


        /*
         * A class that get JSON response
         */
        private class GetRequest
        {
            private WebRequest request;
            private HttpWebResponse response;
            private string appRef;
            private string appToken;

            /* constructor to initialize the web request of app reference and app token */
            public GetRequest(string appRef, string appToken)
            {
                this.appRef = appRef;
                this.appToken = appToken;
            }

            /* get the product id from the sku */
            public string getProductId(string sku)
            {
                string uriSearch = "https://ws-use.brightpearl.com/2.0.0/ashlintest/product-service/product-search?SKU=" + sku;

                // post request to uri
                request = WebRequest.Create(uriSearch);
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);
                request.Method = "GET";

                // get the response from the server
                string textJSON;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    // read all the text from JSON response
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        textJSON = streamReader.ReadToEnd();
                    }
                }
                catch
                {
                    return "Error";     // server 503 error
                }

                // the case there is no product exists
                if (textJSON[textJSON.IndexOf("resultsReturned") + 17] - '0' < 1)
                {
                    return null;
                }

                // starting getting product id
                int index = textJSON.LastIndexOf("results") + 11;
                int length = index;
                while (Char.IsNumber(textJSON[length]))
                {
                    length++;
                }

                return textJSON.Substring(index, length - index);
            }

            /* a method that return the quantity of specific sku */
            public int getQuantity(string sku)
            {
                // get product id
                string id = getProductId(sku);

                // the case if there is no such product
                if (id == null)
                {
                    return -1;
                }

                // generate search uri
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlintest/warehouse-service/product-availability/" + id;

                // post request to uri
                request = WebRequest.Create(uri);
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);
                request.Method = "GET";

                // get the response from the server
                string textJSON = "";
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    // read all the text from JSON response
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        textJSON = streamReader.ReadToEnd();
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = e.Response as HttpWebResponse;
                        if ((int)response.StatusCode == 400)
                        {
                            return -3;      // web server 400 bad request
                        }
                        else
                        {
                            return -2;      // web server 503 server unavailable
                        }
                    }
                }

                // starting getting product quantity
                int index = textJSON.LastIndexOf("inStock") + 9;
                int length = index;
                while (Char.IsNumber(textJSON[length]))
                {
                    length++;
                }

                return Convert.ToInt32(textJSON.Substring(index, length - index));
            }
        }
    }
}
