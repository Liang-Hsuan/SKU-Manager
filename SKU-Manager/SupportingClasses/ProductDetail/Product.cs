using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

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
        public int GetQuantity(string sku)
        {
            int quantity = get.GetQuantity(sku);

            switch (quantity)
            {
                case -2:
                    do
                    {
                        Thread.Sleep(5000);
                        quantity = GetQuantity(sku);
                    } while (quantity == -2);
                    break;
                case -3:
                    quantity = -1;
                    break;
            }

            return quantity;
        }

        /* a method that return product id for given sku */
        public string GetProductId(string sku)
        {
            // get product id
            string id = get.GetProductId(sku);
            while (id == "Error")
            {
                Thread.Sleep(5000);
                id = get.GetProductId(sku);
            }

            return id;
        }

        /* a method that return all the SkUs' stock information */
        public List<Values> GetStockList()
        {
            // local field for sotring data, getting data, and parsing data
            List<Values> list = new List<Values>();
            int starting = 1000;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // first step get response for all the sku - product id relation
            string textJson = get.ProductTextResponse(starting);

            // check if there is more item
            while (textJson != "404")
            {
                // deserialize json to key value
                var productInfo = serializer.Deserialize<Dictionary<string, dynamic>>(textJson);

                // looping through each product from the response
                foreach (var product in productInfo["response"])
                {
                    // get data for the product
                    string productId = product["id"].ToString();
                    string sku = product["identity"]["sku"];
                    int reorderLevel = product["warehouses"]["2"]["reorderLevel"];
                    int reorderQuantity = product["warehouses"]["2"]["reorderQuantity"];

                    list.Add(new Values(sku, productId, 0, reorderQuantity, reorderLevel));
                }

                // proceed the request to next set of result
                starting += 200;
                textJson = get.ProductTextResponse(starting);
                while (textJson == "503")
                {
                    Thread.Sleep(5000);
                    textJson = get.ProductTextResponse(starting);
                }
            }

            // get the last item's product id in order to get the stock we need for request
            string lastProductId = list[list.Count - 1].ProductId;
            textJson = get.QuantityTextResponse(1000, Convert.ToInt32(lastProductId));
            while (textJson == "503")
            {
                Thread.Sleep(5000);
                textJson = get.QuantityTextResponse(1000, Convert.ToInt32(lastProductId));
            }

            // deserialize json to key value
            var qtyInfo = serializer.Deserialize<Dictionary<string, dynamic>>(textJson);

            foreach (var product in qtyInfo["response"])
            {
                // get product id number
                string productId = product.Key;

                // get quantity of the product
                int quantity = product.Value["total"]["inStock"];

                // allocate quantity to the corresponding product
                foreach (Values value in list.Where(value => productId == value.ProductId))
                {
                    value.Quantity = quantity;
                    break;
                }
            }

            return list;
        }
        #endregion

        /* a method that post purchase order */
        public void postOrder(Dictionary<string,int> list, int channelId, string reference)
        {
            // post order and get the order id
            string orderId = post.PostPurchaseOrder(channelId, reference);

            // post row row into the order
            foreach (var item in list)
            {
                string orderRowId = post.PostOrderRow(orderId, item.Key, item.Value);
                while (orderRowId == "Error")
                {
                    Thread.Sleep(5000);
                    orderRowId = post.PostOrderRow(orderId, item.Key, item.Value);
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
            public string GetProductId(string sku)
            {
                string uriSearch = "https://ws-use.brightpearl.com/2.0.0/ashlin/product-service/product-search?SKU=" + sku;

                // post request to uri
                request = WebRequest.Create(uriSearch);
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);
                request.Method = "GET";

                // get the response from the server
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch
                {
                    return "Error";     // server 503 error
                }

                // read all the text from JSON response
                string textJson;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    textJson = streamReader.ReadToEnd();

                // deserialize json to key value
                var info = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(textJson);

                // the case there is no product exists
                return info["response"]["metaData"]["resultsAvailable"] < 1 ? null : info["response"]["results"][0][0].ToString();
            }

            /* a method that return the quantity of specific sku */
            public int GetQuantity(string sku)
            {
                // get product id
                string id = GetProductId(sku);

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
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
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

                // read all the text from JSON response
                string textJson;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    textJson = streamReader.ReadToEnd();

                // deserialize json to key value
                var info = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(textJson);

                return info["response"][id]["total"]["inStock"];
            }
            #endregion

            /* a method that get the text response from product search */
            public string ProductTextResponse(int starting)
            {
                // uri for getting all item on brightpearl
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/product-service/product/" + starting + "-" + (starting + 199);

                // post request to uri
                request = WebRequest.Create(uri);
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);
                request.Method = "GET";

                // get the response from the server
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        response = e.Response as HttpWebResponse;
                        return (int)response.StatusCode == 404 ? "404" : "503";
                    }
                }

                // read all the text from JSON response
                string textJson;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    textJson = streamReader.ReadToEnd();

                return textJson;
            }

            /* a method that get the text response form quantity search */
            public string QuantityTextResponse(int starting, int ending)
            {
                // generate search uri
                string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/warehouse-service/product-availability/" + starting + "-" + ending;

                // post request to uri
                request = WebRequest.Create(uri);
                request.Headers.Add("brightpearl-app-ref", appRef);
                request.Headers.Add("brightpearl-account-token", appToken);
                request.Method = "GET";

                // get the response from the server
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
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

                // read all the text from JSON response
                string textJson;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    textJson = streamReader.ReadToEnd();

                return textJson;
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
            public string PostPurchaseOrder(int channelId, string reference)
            {
                const string uri = "https://ws-use.brightpearl.com/2.0.0/ashlin/order-service/order";

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
            public string PostOrderRow(string orderId, string productId, int quantity)
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
