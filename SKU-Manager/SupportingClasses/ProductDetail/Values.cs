namespace SKU_Manager.SupportingClasses.ProductDetail
{
    /*
     *  A class that store the information of a sku
     */
    public class Values
    {
        // fields for the infomation about the product 
        public string SKU { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }

        /* first constructor that accept the sku and product id for the product */
        public Values(string sku, string productId)
        {
            SKU = sku;
            ProductId = productId;
        }

        /* second constructor that accept sku, produc id and quantity for the product */
        public Values(string sku, string productId, string quantity)
        {
            SKU = sku;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
