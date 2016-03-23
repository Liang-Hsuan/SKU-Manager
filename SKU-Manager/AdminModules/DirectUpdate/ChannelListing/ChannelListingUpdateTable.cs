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
        private List<string> skuList = new List<string>();

        /* constructor that adding sku list */
        public ChannelListingUpdateTable()
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True';", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    skuList.Add(reader.GetString(0));
            }

            // initialize progress
            Total = skuList.Count;
            Current = 0;
        }

        /* the most major method for the class -> return table to the client */
        public override DataTable getTable()
        {
            // reset table just in case and set current to zero
            mainTable.Reset();
            Current = 0;

            addColumn(mainTable, "SKU", false);                    // 1
            addColumn(mainTable, "Bestbuy", false);                // 2
            addColumn(mainTable, "Bestbuy Net", false);            // 3
            addColumn(mainTable, "Bestbuy Listed", true);          // 4
            addColumn(mainTable, "Amazon CA", false);              // 5
            addColumn(mainTable, "Amazon CA Price", false);        // 6
            addColumn(mainTable, "Amazon CA Listed", true);        // 7
            addColumn(mainTable, "Amazon US", false);              // 8
            addColumn(mainTable, "Amazon US Price", false);        // 9
            addColumn(mainTable, "Amazon US Listed", true);        // 10
            addColumn(mainTable, "Staples", false);                // 11
            addColumn(mainTable, "Staples Net", false);            // 12
            addColumn(mainTable, "Staples Listed", true);          // 13
            addColumn(mainTable, "Staples Advantage", false);      // 14
            addColumn(mainTable, "Staples Advantage Net", false);  // 15
            addColumn(mainTable, "Staples Advantage Listed", true);// 16
            addColumn(mainTable, "Walmart", false);                // 17
            addColumn(mainTable, "Walmart Net", false);            // 18
            addColumn(mainTable, "Walmart Listed", true);          // 19
            addColumn(mainTable, "Shop.ca", false);                // 20
            addColumn(mainTable, "Shop.ca Price", false);          // 21
            addColumn(mainTable, "Shop.ca Listed", true);          // 22
            addColumn(mainTable, "Sears", false);                  // 23
            addColumn(mainTable, "Sears Net", false);              // 24
            addColumn(mainTable, "Sears Listed", true);            // 25
            addColumn(mainTable, "Giant Tiger", false);            // 26
            addColumn(mainTable, "Giant Tiger Net", false);        // 27
            addColumn(mainTable, "Giant Tiger Listed", true);      // 28

            // starting work for begin loading data to the table
            DataTable table = Properties.Settings.Default.ChannelListingTable;

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                Current++;

                DataRow rowCopy = table.Select("SKU = \'" + sku + "\'")[0];
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

                mainTable.Rows.Add(row);
            }

            // finish loading data
            mainTable.EndLoadData();
            return mainTable;
        }
    }
}
