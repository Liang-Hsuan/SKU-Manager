using System;
using System.Collections;
using System.Data;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables
{
    /*
     * A class that return shop ca inventory export table
     */
    public class ShopCaInventoryExportTable : ShopCaExportTable
    {
        /* constructor that initialize fields */
        public ShopCaInventoryExportTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "supplier id");                                    // 1
            AddColumn(mainTable, "store name");                                     // 2
            AddColumn(mainTable, "sku");                                            // 3
            AddColumn(mainTable, "quantity");                                       // 4
            AddColumn(mainTable, "out of stock quantity");                          // 5
            AddColumn(mainTable, "restock date");                                   // 6
            AddColumn(mainTable, "standard fulfillment latency");                   // 7
            AddColumn(mainTable, "priority fulfillment latency");                   // 8
            AddColumn(mainTable, "backorderable");                                  // 9
            AddColumn(mainTable, "return not desired");                             // 10
            AddColumn(mainTable, "inventory as of date");                           // 11
            AddColumn(mainTable, "external inventory id");                          // 12
            AddColumn(mainTable, "shipping comments");                              // 13

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();

                row[0] = "ashlin_bpg";                               // brand
                row[1] = "nishis_boutique";                          // store name
                row[2] = sku;                                        // sku
                row[3] = table.Select("SKU='" + sku + "'")[0][2];    // quantity
                row[8] = true;                                       // backorderable

                mainTable.Rows.Add(row);         
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* override getData method */
        protected override ArrayList GetData(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
