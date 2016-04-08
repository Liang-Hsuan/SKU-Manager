using System;
using System.Collections;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ChannelListing
{
    /* 
     * An abstract class for all channel listing classes 
     */
    public abstract class ChannelListingExportTable : ExportTable
    {
        /* struct that storing price data */
        protected struct Price
        {
            public double MsrpDisc;
            public double SellCent;
        }

        /* method that get the data from given sku */
        protected ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] for price calculation, [1] bestbuy, [2] amazon ca, [3] amazon us, [4] statples advantage, [5] walmart, [6] shop.ca, [7] sears, [8] giant tiger
            //                                                                         & statples            
            SqlCommand command = new SqlCommand("SELECT Base_Price, SKU_BESTBUY_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_SHOP_CA, SKU_SEARS_CA, SKU_GIANT_TIGER " +
                                                "FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 8; i++)
                list.Add(reader.GetValue(i));

            return list;
        }

        /* a method that get the data for pricing */
        protected Price[] getPrice()
        {
            // declare Price struct list
            Price[] list = new Price[13];

            // get data 
            // [0] ebay, [1] amazon.com, [2] amazon.ca, [3] amazon.uk, [4] shop.ca, [5] giant tiger, [6] sears, [7] staples, [8] staples advantage, 
            // [9] the bay, [10] the shopping channel, [11] walmart, [12] bestbuy
            SqlCommand command = new SqlCommand("SELECT Msrp_Disc, Sell_Cents FROM Channel_Pricing;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 12; i++)
            {
                Price price = new Price();

                reader.Read();
                price.MsrpDisc = Convert.ToDouble(reader.GetValue(0));
                price.SellCent = Convert.ToDouble(reader.GetValue(1));

                list[i] = price;
            }
            connection.Close();

            return list;
        }

        /* a method that get multiplier */
        protected double getMultiplier()
        {
            SqlCommand command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            double multiplier = reader.GetDouble(0);
            connection.Close();

            return multiplier;
        }
    }
}
