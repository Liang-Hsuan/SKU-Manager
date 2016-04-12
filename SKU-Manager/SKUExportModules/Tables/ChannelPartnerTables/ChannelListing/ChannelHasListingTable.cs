using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ChannelListing
{
    /*
     * A class that return channels' listing export table
     */
    public class ChannelHasListingTable : ChannelListingExportTable
    {
        /* constructor that initialize fields */
        public ChannelHasListingTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            AddColumn(mainTable, "SKU");                    // 1
            AddColumn(mainTable, "Bestbuy");                // 2
            AddColumn(mainTable, "Bestbuy Net");            // 3
            AddColumn(mainTable, "Amazon CA");              // 4
            AddColumn(mainTable, "Amazon CA Price");        // 5
            AddColumn(mainTable, "Amazon US");              // 6
            AddColumn(mainTable, "Amazon US Price");        // 7
            AddColumn(mainTable, "Staples");                // 8
            AddColumn(mainTable, "Staples Net");            // 9
            AddColumn(mainTable, "Staples Advantage");      // 10
            AddColumn(mainTable, "Staples Advantage Net");  // 11
            AddColumn(mainTable, "Walmart");                // 12
            AddColumn(mainTable, "Walmart Net");            // 13
            AddColumn(mainTable, "Shop.ca");                // 14
            AddColumn(mainTable, "Shop.ca Price");          // 15
            AddColumn(mainTable, "Sears");                  // 16
            AddColumn(mainTable, "Sears Net");              // 17
            AddColumn(mainTable, "Giant Tiger");            // 18
            AddColumn(mainTable, "Giant Tiger Net");        // 19

            // fields for pricing calculation
            double multiplier = GetMultiplier();
            Price[] priceList = GetPrice();

            // start load data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

                // calculate msrp
                double msrp = multiplier * Convert.ToDouble(list[0]);

                row[0] = sku;               // sku
                row[1] = list[1];           // bestbuy
                if (list[1].ToString() != "")
                    row[2] = Math.Ceiling(msrp * (1 - priceList[12].MsrpDisc / 100)) - (1 - priceList[12].SellCent);     // bestbuy net
                row[3] = list[2];           // amazon ca
                if (list[2].ToString() != "")
                    row[4] = Math.Ceiling(msrp * (1 - priceList[2].MsrpDisc / 100)) - (1 - priceList[2].SellCent);       // amazon ca price
                row[5] = list[3];           // amazon us
                if (list[3].ToString() != "")
                    row[6] = Math.Ceiling(msrp * (1 - priceList[1].MsrpDisc / 100)) - (1 - priceList[1].SellCent);       // amaozn us price
                row[7] = list[4];           // staples
                if (list[4].ToString() != "")
                    row[8] = Math.Ceiling(msrp * (1 - priceList[7].MsrpDisc / 100)) - (1 - priceList[7].SellCent);       // staples net
                row[9] = list[4];           // staples advantage
                if (list[4].ToString() != "")
                    row[10] = Math.Ceiling(msrp * (1 - priceList[7].MsrpDisc / 100)) - (1 - priceList[7].SellCent);      // staples advantage net
                row[11] = list[5];          // walmart
                if (list[5].ToString() != "")
                    row[12] = Math.Ceiling(msrp * (1 - priceList[11].MsrpDisc / 100)) - (1 - priceList[11].SellCent);    // walmart net
                row[13] = list[6];          // shop.ca
                if (list[6].ToString() != "")
                    row[14] = Math.Ceiling(msrp * (1 - priceList[4].MsrpDisc / 100)) - (1 - priceList[4].SellCent);      // shop.ca price
                row[15] = list[7];          // sears
                if (list[7].ToString() != "")
                    row[16] = Math.Ceiling(msrp * (1 - priceList[6].MsrpDisc / 100)) - (1 - priceList[6].SellCent);      // sears net
                row[17] = list[8];          // giant tiger
                if (list[8].ToString() != "")
                    row[18] = Math.Ceiling(msrp * (1 - priceList[11].MsrpDisc / 100)) - (1 - priceList[11].SellCent);    // giant tiger net

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is active and has at least one listing on channel*/
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' AND (SKU_BESTBUY_CA != '' OR SKU_AMAZON_CA != '' OR "
                                              + "SKU_AMAZON_COM != '' OR SKU_STAPLES_CA != '' OR SKU_WALMART_CA != '' OR SKU_SHOP_CA != '' OR SKU_SEARS_CA != '' OR SKU_GIANT_TIGER != '');", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }
    }
}
