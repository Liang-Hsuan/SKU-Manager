using System;

namespace SKU_Manager.AdminModules.UpdateInventory.InventoryTable
{
    /*
     * A class for storing sears inventory values in order to generate xml file
     */
    public class SearsInventoryValues
    {
        // must have fields
        public string VendorSku { get; set; }
        public int QtyOnHand { get; set; }
        public string MerchantSku { get; set; }

        // boolean flags fields
        public bool PurchaseOrder { get; set; }
        public bool Discontinued { get; set; }

        // fields that are determined by the flags
        public DateTime NextAvailableDate { get; set; }
        public int NextAvailableQty { get; set; }

        /* first constructor that takes no argument */
        public SearsInventoryValues()
        {
            VendorSku = "";
            QtyOnHand = 0;
            MerchantSku = "";

            PurchaseOrder = false;
            Discontinued = false;

            NextAvailableDate = DateTime.Today;
            NextAvailableQty = 0;
        }

        /* second constructor that accept all parameters as argument */
        public SearsInventoryValues(string vendorSku, int qtyOnHand, string merchantSku, bool purchaseOrder, bool discontinued,
                                    DateTime nextAvailableDate, int nextAvailableQty, DateTime discontinuedDate)
        {
            VendorSku = vendorSku;
            QtyOnHand = qtyOnHand;
            MerchantSku = merchantSku;

            PurchaseOrder = purchaseOrder;
            Discontinued = discontinued;

            NextAvailableDate = nextAvailableDate;
            NextAvailableQty = nextAvailableQty;
        }
    }
}
