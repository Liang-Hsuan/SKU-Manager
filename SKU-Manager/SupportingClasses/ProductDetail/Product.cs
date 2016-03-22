using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace SKU_Manager.SupportingClasses.ProductDetail
{
    /* 
     * A class that can get information about the product from Brightpearl
     */
    public class Product
    {
        // fields for brightpearl integration
        private readonly GetRequest get;
        private readonly PostRequest post;

        /* constructor that initilize GetRequest class */
        public Product()
        {
            string appRef;
            string appToken;

            using (SqlConnection authenticationConnection = new SqlConnection(Properties.Settings.Default.ASCMcs))
            {
                SqlCommand getAuthetication = new SqlCommand("SELECT Field3_Value, Field1_Value FROM ASCM_Credentials WHERE Source = \'Brightpearl\';", authenticationConnection);
                authenticationConnection.Open();
                SqlDataReader reader = getAuthetication.ExecuteReader();
                reader.Read();
                appRef = reader.GetString(0);
                appToken = reader.GetString(1);
            }

            get = new GetRequest(appRef, appToken);
            post = new PostRequest(appRef, appToken);
        }

        #region Get Methods
        /* a method that return the quantity of specific sku */
        public int getQuantity(string sku)
        {
            int quantity = get.getQuantity(sku);

            if (quantity == -2)
            {
                do
                {
                    Thread.Sleep(5000);
                    quantity = getQuantity(sku);
                } while (quantity == -2);
            }
            else if (quantity == -3)
                quantity = -1;

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
                while (textJSON.Contains("\"id\"") && textJSON.Contains("\"sku\""))
                {
                    // get product id
                    textJSON = substringMethod(textJSON, "\"id\"", 5);
                    string productId = getTarget(textJSON);

                    // get sku number
                    textJSON = substringMethod(textJSON, "\"sku\"", 7);
                    string sku = getTarget(textJSON);

                    // get reorder level
                    textJSON = substringMethod(textJSON, "reorderLevel", 14);
                    int reorderLevel = Convert.ToInt32(getTarget(textJSON));

                    // get reorder quantity
                    textJSON = substringMethod(textJSON, "reorderQuantity", 17);
                    int reorderQuantity = Convert.ToInt32(getTarget(textJSON));

                    list.Add(new Values(sku, productId, 0, reorderQuantity, reorderLevel));

                    // proceed the text to next token
                    textJSON = substringMethod(textJSON, "reporting", 10);
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
                    length--;
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
                    value.Quantity = Convert.ToInt32(quantity);
                    break;
                }

                // proceed the text to the next token
                textJSON = textJSON.Substring(textJSON.IndexOf("allocated") + 10);
                textJSON = textJSON.Substring(textJSON.IndexOf("warehouses") + 13);
                if (textJSON[0] != '}')
                    textJSON = textJSON.Substring(textJSON.IndexOf("allocated") + 10);
            }

            return list;
        }
        #endregion

        /* a method that post purchase order */
        public void postOrder(Dictionary<string,int> list, int channelId, string reference)
        {
            // post order and get the order id
            string orderId = post.postPurchaseOrder(channelId, reference);

            // post row row into the order
            foreach (var item in list)
            {
                string orderRowId = post.postOrderRow(orderId, item.Key, item.Value);
                if (orderRowId == "Error")
                {
                    do
                        orderRowId = post.postOrderRow(orderId, item.Key, item.Value);
                    while (orderRowId == "Error");
                }
            }
        }

        #region Supporting Methods
        /* a method that substring the given string */
        private static string substringMethod(string original, string startingString, int additionIndex)
        {
            return original.Substring(original.IndexOf(startingString) + additionIndex);
        }

        /* a method that get the next target token */
        private static string getTarget(string text)
        {
            int i = 0;
            while (text[i] != '"' && text[i] != ',' && text[i] != '}')
                i++;

            return text.Substring(0, i);
        }
        #endregion

        /* 
         * A class that Get request from brightpearl
         */
        private class GetRequest
        {
            private WebRequest request;
            private HttpWebResponse response;
            private readonly string appRef;
            private readonly string appToken;

            /* constructor to initialize the web request of app reference and app token */
            public GetRequest(string appRef, string appToken)
            {
                this.appRef = appRef;
                this.appToken = appToken;
            }

            #region Deprecated
            /* get the product id from the sku */
            public string getProductId(string sku)
            {
                string uriSearch = "https://ws-use.brightpearl.com/2.0.0/ashlin/product-service/product-search?SKU=" + sku;

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

                // check if there is result return or not
                textJSON = substringMethod(textJSON, "resultsReturned", 17);
                if (Convert.ToInt32(getTarget(textJSON)) < 1)
                    return null;

                // getting product id
                textJSON = substringMethod(textJSON, "\"results\":", 12);
                return getTarget(textJSON);
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
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/warehouse-service/product-availability/" + id;

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
                textJSON = substringMethod(textJSON, "inStock", 9);
                return Convert.ToInt32(getTarget(textJSON));
            }
            #endregion

            /* a method that get the text response from product search */
            public string productTextResponse(int starting)
            {
                // uri for getting all item on brightpearl
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/product-service/product/" + starting + "-" + (starting + 199);

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
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/warehouse-service/product-availability/" + starting + "-" + ending;

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

        /* 
         * A class that Post request to brightpearl 
         */
        private class PostRequest
        {
            // fields for web request
            private HttpWebRequest request;
            private HttpWebResponse response;

            // fields for credentials
            private readonly string appRef;
            private readonly string appToken;

            /* constructor to initialize the web request of app reference and app token */
            public PostRequest(string appRef, string appToken)
            {
                this.appRef = appRef;
                this.appToken = appToken;
            }

            /* post purchase order to API */
            public string postPurchaseOrder(int channelId, string reference)
            {
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/order-service/order";

                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);

                // generate JSON file for order post
                string textJSON = "{\"orderTypeCode\":\"PO\",\"reference\":\"" + reference + "\",\"priceListId\":1,\"placeOn\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T') + "+00:00\",\"orderStatus\":{\"orderStatusId\":6},\"delivery\":{\"deliveryDate\":\"" + DateTime.Today.AddDays(12).ToString("yyyy-MM-dd") + "T00:00:00+00:00\",\"shippingMethodId\":9}," + 
                                  "\"currency\":{\"orderCurrencyCode\":\"CAD\"},\"parties\":{\"supplier\":{\"contactId\":204}},\"assignment\":{\"current\":{\"channelId\":" + channelId + ",\"staffOwnerContactId\":4}}}";

                // turn request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(textJSON);

                // send request
                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(postBytes, 0, postBytes.Length);

                // get the response from the server
                try    // might have server internal error, so do it in try and catch
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch    // HTTP response 500
                {
                    return "Error";    // cannot post order, return error instead
                }

                string result;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    result = streamReader.ReadToEnd();

                result = substringMethod(result, ":", 1);
                return getTarget(result);  //return the order ID
            }

            /* post order row to API */
            public string postOrderRow(string orderId, string productId, int quantity)
            {
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/order-service/order/" + orderId + "/row";
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);

                // generate json file
                string textJSON = "{\"productId\":\"" + productId + "\",\"quantity\":{\"magnitude\":\"" + quantity + "\"},\"rowValue\":{\"taxCode\":\"ON\",\"rowNet\":{\"value\":\"" + 0 + "\"},\"rowTax\":{\"value\":\"" + 0 + "\"}}}";

                // turn request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(textJSON);

                // send request
                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(postBytes, 0, postBytes.Length);

                // get the response from server
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                    return "Error";     // 503 Server Unabailable
                }

                string result;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    result = streamReader.ReadToEnd();

                result = substringMethod(result, ":", 1);
                return getTarget(result);  //return the order row ID
            }
        }
    }
}
