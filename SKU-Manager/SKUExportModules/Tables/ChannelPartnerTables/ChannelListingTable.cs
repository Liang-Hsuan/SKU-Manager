using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables
{
    /*
     * A class that return all channels' listing export table
     */
    public class ChannelListingTable : ExportTable
    {
        /* constructor that initialize fields */
        public ChannelListingTable()
        {
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            addColumn(mainTable, "SKU");                    // 1
            addColumn(mainTable, "Bestbuy");                // 2
            addColumn(mainTable, "Bestbuy Net");            // 3
            addColumn(mainTable, "Amazon CA");              // 4
            addColumn(mainTable, "Amazon CA Price");        // 5
            addColumn(mainTable, "Amazon US");              // 6
            addColumn(mainTable, "Amazon US Price");        // 7
            addColumn(mainTable, "Staples");                // 8
            addColumn(mainTable, "Staples Net");            // 9
            addColumn(mainTable, "Staples Advantage");      // 10
            addColumn(mainTable, "Staples Advantage Net");  // 11
            addColumn(mainTable, "Walmart");                // 12
            addColumn(mainTable, "Walmart Net");            // 13
            addColumn(mainTable, "Shop.ca");                // 14
            addColumn(mainTable, "Shop.ca Price");          // 15
            addColumn(mainTable, "Sears");                  // 16
            addColumn(mainTable, "Sears Net");              // 17
            addColumn(mainTable, "Giant Tiger");            // 18
            addColumn(mainTable, "Giant Tiger Net");        // 19

            // start load data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = sku;               // sku
                row[1] = list[1];           // bestbuy
                if (list[1].ToString() != "")
                row[2] = list[0];           // bestbuy net
                row[3] = list[2];           // amazon ca
                if (list[2].ToString() != "")
                    row[4] = list[0];       // amazon ca price
                row[5] = list[3];           // amazon us
                if (list[3].ToString() != "")
                    row[6] = list[0];       // amaozn us price
                row[7] = list[4];           // staples
                if (list[4].ToString() != "")
                    row[8] = list[0];       // staples net
                row[9] = list[4];           // staples advantage
                if (list[4].ToString() != "")
                    row[10] = list[0];      // staples advantage net
                row[11] = list[5];          // walmart
                if (list[5].ToString() != "")
                    row[12] = list[0];      // walmart net
                row[13] = list[6];          // shop.ca
                if (list[6].ToString() != "")
                    row[14] = list[0];      // shop.ca price
                row[15] = list[7];          // sears
                if (list[7].ToString() != "")
                    row[16] = list[0];      // sears net
                row[17] = list[5];          // giant tiger
                if (list[5].ToString() != "")
                    row[18] = list[0];      // giant tiger net

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* method that get the data from given sku */
        private ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] for price calculation, [1] bestbuy, [2] amazon ca, [3] amazon us, [4] statples advantage, [5] walmart, [6] shop.ca, [7] sears
            //                                                                         & statples            & giant tiger
            SqlCommand command = new SqlCommand("SELECT Base_Price, SKU_BESTBUY_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_SHOP_CA, SKU_SEARS_CA " +
                                                "FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 7; i++)
                list.Add(reader.GetValue(i));
            connection.Close();

            return list;
        }

        /* a method that get all the sku that is active and have on shop ca with bag design */
        protected sealed override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' ;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }
    }
}
