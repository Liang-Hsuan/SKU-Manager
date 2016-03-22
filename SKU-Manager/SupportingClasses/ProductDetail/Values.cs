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
        public int Quantity { get; set; }
        public int ReorderQuantity { get; set; }
        public int ReorderLevel { get; set; }

        /* first constructor that accept the sku and product id for the product */
        public Values(string sku, string productId)
        {
            SKU = sku;
            ProductId = productId;
        }

        /* second constructor that take all parameters */
        public Values(string sku, string productId, int quantity, int reorderQuantity, int reorderLevel)
        {
            SKU = sku;
            ProductId = productId;
            Quantity = quantity;
            ReorderQuantity = reorderQuantity;
            ReorderLevel = reorderLevel;
        }
    }
}
