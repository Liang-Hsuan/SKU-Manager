using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.AdminModules.DirectUpdate.ChannelListing
{
    /* 
     * A table for channel product listing 
     */
    public class ChannelListingUpdateTable : AdminTable
    {
        // field for sku data
        private readonly List<string> skuList = new List<string>();

        /* constructor that adding sku list */
        public ChannelListingUpdateTable()
        {
            using (Connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True'", Connection);
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    skuList.Add(reader.GetString(0));
            }

            // initialize progress
            Total = skuList.Count;
            Current = 0;
        }

        /* the most major method for the class -> return table to the client */
        public override DataTable GetTable()
        {
            // reset table just in case and set current to zero
            MainTable.Reset();
            Current = 0;

            AddColumn(MainTable, "SKU", false);                    // 1
            AddColumn(MainTable, "Bestbuy", false);                // 2
            AddColumn(MainTable, "Bestbuy Net", false);            // 3
            AddColumn(MainTable, "Bestbuy Listed", true);          // 4
            AddColumn(MainTable, "Amazon CA", false);              // 5
            AddColumn(MainTable, "Amazon CA Price", false);        // 6
            AddColumn(MainTable, "Amazon CA Listed", true);        // 7
            AddColumn(MainTable, "Amazon US", false);              // 8
            AddColumn(MainTable, "Amazon US Price", false);        // 9
            AddColumn(MainTable, "Amazon US Listed", true);        // 10
            AddColumn(MainTable, "Staples", false);                // 11
            AddColumn(MainTable, "Staples Net", false);            // 12
            AddColumn(MainTable, "Staples Listed", true);          // 13
            AddColumn(MainTable, "Staples Advantage", false);      // 14
            AddColumn(MainTable, "Staples Advantage Net", false);  // 15
            AddColumn(MainTable, "Staples Advantage Listed", true);// 16
            AddColumn(MainTable, "Walmart", false);                // 17
            AddColumn(MainTable, "Walmart Net", false);            // 18
            AddColumn(MainTable, "Walmart Listed", true);          // 19
            AddColumn(MainTable, "Shop.ca", false);                // 20
            AddColumn(MainTable, "Shop.ca Price", false);          // 21
            AddColumn(MainTable, "Shop.ca Listed", true);          // 22
            AddColumn(MainTable, "Sears", false);                  // 23
            AddColumn(MainTable, "Sears Net", false);              // 24
            AddColumn(MainTable, "Sears Listed", true);            // 25
            AddColumn(MainTable, "Giant Tiger", false);            // 26
            AddColumn(MainTable, "Giant Tiger Net", false);        // 27
            AddColumn(MainTable, "Giant Tiger Listed", true);      // 28

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.ChannelListingTable;

            // start loading data
            MainTable.BeginLoadData();

            // add data to each row
            foreach (string sku in skuList)
            {
                DataRow row = MainTable.NewRow();
                Current++;

                DataRow rowCopy;
                try
                {
                    rowCopy = table.Select("SKU = \'" + sku + '\'')[0];
                }
                catch
                {
                    continue;
                }
                row[0] = sku;                           // sku
                row[1] = rowCopy[1];                    // bestbuy
                row[2] = rowCopy[2];                    // bestbuy net
                row[3] = rowCopy[1].ToString() != "";   // listed
                row[4] = rowCopy[3];                    // amazon ca
                row[5] = rowCopy[4];                    // amazon ca price
                row[6] = rowCopy[3].ToString() != "";   // listed
                row[7] = rowCopy[5];                    // amazon us
                row[8] = rowCopy[6];                    // amazon us price
                row[9] = rowCopy[5].ToString() != "";   // listed
                row[10] = rowCopy[7];                   // staples
                row[11] = rowCopy[8];                   // staples net
                row[12] = rowCopy[7].ToString() != "";  // listed
                row[13] = rowCopy[9];                   // staples advantage
                row[14] = rowCopy[10];                  // staples advantage net
                row[15] = rowCopy[9].ToString() != "";  // listed
                row[16] = rowCopy[11];                  // walmart
                row[17] = rowCopy[12];                  // walmart net
                row[18] = rowCopy[11].ToString() != ""; // listed
                row[19] = rowCopy[13];                  // shop.ca
                row[20] = rowCopy[14];                  // shop.ca price
                row[21] = rowCopy[13].ToString() != ""; // listed
                row[22] = rowCopy[15];                  // sears
                row[23] = rowCopy[16];                  // sears net
                row[24] = rowCopy[15].ToString() != ""; // listed
                row[25] = rowCopy[17];                  // giant tiger
                row[26] = rowCopy[18];                  // giant tiger net
                row[27] = rowCopy[17].ToString() != ""; // listed

                MainTable.Rows.Add(row);
            }

            // finish loading data
            MainTable.EndLoadData();
            return MainTable;
        }
    }
}
