using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace SKU_Manager.SupportingClasses.ProductDetail
{
    /* 
     * A class that can get information about the product from Brightpearl
     */
    public class Product
    {
        // get request object for geting information from Brightpearl
        private GetRequest get;

        /* constructor that initilize GetRequest class */
        public Product()
        {
            using (SqlConnection authenticationConnection = new SqlConnection(Properties.Settings.Default.ASCMcs))
            {
                SqlCommand getAuthetication = new SqlCommand("SELECT Field3_Value, Field1_Value FROM ASCM_Credentials WHERE Source = \'Brightpearl Testing\';", authenticationConnection);
                authenticationConnection.Open();
                SqlDataReader reader = getAuthetication.ExecuteReader();
                reader.Read();
                get = new GetRequest(reader.GetString(0), reader.GetString(1));
            }
        }

        /* a method that return the quantity of specific sku */
        public int getQuantity(string sku)
        {
            int quantity = get.getQuantity(sku);

            switch (quantity)
            {
                case -2:
                    do
                    {
                        Thread.Sleep(5000);
                        quantity = getQuantity(sku);
                    } while (quantity == -2);
                    break;
                case -3:
                    quantity = -1;
                    break;
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

        /* a method that return all the SkUs' stock information */
        public List<Values> getStockList()
        {
            // local field for sotring data and getting data
            List<Values> list = new List<Values>();
            int starting = 1000;

            // first step get response for all the sku - product id relation
            string textJSON = get.productTextResponse(starting);

            // check if there is more item
            while (textJSON != "404")
            {
                // check if there is item left
                while (textJSON.Contains("id") && textJSON.Contains("sku"))
                {
                    int index = textJSON.IndexOf("sku") + 6;

                    if (textJSON[index] != '"')
                    {
                        // get sku number
                        int length = index;
                        while (textJSON[length] != '"')
                            length++;
                        string sku = textJSON.Substring(index, length - index);

                        // get id number
                        index = textJSON.IndexOf("id") + 4;
                        length = index;
                        while (char.IsNumber(textJSON[length]))
                            length++;
                        string productId = textJSON.Substring(index, length - index);

                        // add sku and id to the list
                        list.Add(new Values(sku, productId));
                    }

                    // proceed the text to next token
                    textJSON = textJSON.Substring(textJSON.IndexOf("reporting") + 10);
                }

                // proceed the request to next set of result
                starting += 200;
                textJSON = get.productTextResponse(starting);
                if (textJSON == "503")
                {
                    do
                    {
                        Thread.Sleep(5000);
                        textJSON = get.productTextResponse(starting);
                    } while (textJSON == "503");
                }
            }

            // get the last item's product id in order to get the stock we need for request
            string lastProductId = list[list.Count - 1].ProductId;
            textJSON = get.quantityTextResponse(1000, Convert.ToInt32(lastProductId));
            if (textJSON == "503")
            {
                do
                {
                    Thread.Sleep(5000);
                    textJSON = get.quantityTextResponse(1000, Convert.ToInt32(lastProductId));
                } while (textJSON == "503");
            }

            // check if there is item left
            while (textJSON.Contains("total") && textJSON.Contains("warehouses"))
            {
                int index = textJSON.IndexOf("total") - 5;

                // get product id number
                int length = index;
                while (textJSON[length] != '"')
                {
                    length--;
                }
                string productId = textJSON.Substring(length + 1, index - length);

                // get quantity of the product
                index = textJSON.IndexOf("inStock") + 9;
                length = index;
                while (char.IsNumber(textJSON[length]))
                    length++;
                string quantity = textJSON.Substring(index, length - index);

                // allocate quantity to the corresponding product
                foreach (Values value in list.Where(value => productId == value.ProductId))
                {
                    value.Quantity = quantity;
                    break;
                }

                // proceed the text to the next token
                textJSON = textJSON.Substring(textJSON.IndexOf("allocated") + 10);
                textJSON = textJSON.Substring(textJSON.IndexOf("allocated") + 10);
            }

            return list;
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
                        textJSON = streamReader.ReadToEnd();
                }
                catch
                {
                    return "Error";     // server 503 error
                }

                // the case there is no product exists
                if (textJSON[textJSON.IndexOf("resultsReturned") + 17] - '0' < 1)
                    return null;

                // starting getting product id
                int index = textJSON.LastIndexOf("results") + 11;
                int length = index;
                while (char.IsNumber(textJSON[length]))
                    length++;

                return textJSON.Substring(index, length - index);
            }

            /* a method that return the quantity of specific sku */
            public int getQuantity(string sku)
            {
                // get product id
                string id = getProductId(sku);

                // the case if there is no such product
                if (id == null)
                    return -1;

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
                        textJSON = streamReader.ReadToEnd();
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = e.Response as HttpWebResponse;
                        if ((int)response.StatusCode == 400)
                            return -3;      // web server 400 bad request

                        return -2;          // web server 503 server unavailable
                    }
                }

                // starting getting product quantity
                int index = textJSON.LastIndexOf("inStock") + 9;
                int length = index;
                while (char.IsNumber(textJSON[length]))
                    length++;

                return Convert.ToInt32(textJSON.Substring(index, length - index));
            }

            /* a method that get the text response from product search */
            public string productTextResponse(int starting)
            {
                // uri for getting all item on brightpearl
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlintest/product-service/product/" + starting + "-" + (starting + 199);

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
                        if ((int)response.StatusCode == 404)
                            return "404";    // web server 404 not found

                        return "503";        // server unavailable
                    }
                }

                return textJSON;
            }

            /* a method that get the text response form quantity search */
            public string quantityTextResponse(int starting, int ending)
            {
                // generate search uri
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlintest/warehouse-service/product-availability/" + starting + "-" + ending;

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
                        textJSON = streamReader.ReadToEnd();
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = e.Response as HttpWebResponse;
                        if ((int)response.StatusCode == 503)
                            return "503";   // web server 503 server unavailable
                    }
                }

                return textJSON;
            }
        }
    }
}
