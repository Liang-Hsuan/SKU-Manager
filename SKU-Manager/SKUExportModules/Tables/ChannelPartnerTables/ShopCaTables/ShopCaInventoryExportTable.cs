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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "supplier id");                                    // 1
            AddColumn(MainTable, "store name");                                     // 2
            AddColumn(MainTable, "sku");                                            // 3
            AddColumn(MainTable, "quantity");                                       // 4
            AddColumn(MainTable, "out of stock quantity");                          // 5
            AddColumn(MainTable, "restock date");                                   // 6
            AddColumn(MainTable, "standard fulfillment latency");                   // 7
            AddColumn(MainTable, "priority fulfillment latency");                   // 8
            AddColumn(MainTable, "backorderable");                                  // 9
            AddColumn(MainTable, "return not desired");                             // 10
            AddColumn(MainTable, "inventory as of date");                           // 11
            AddColumn(MainTable, "external inventory id");                          // 12
            AddColumn(MainTable, "shipping comments");                              // 13

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;

            // start loading data
            MainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                DataRow row = MainTable.NewRow();

                row[0] = "ashlin_bpg";                               // brand
                row[1] = "nishis_boutique";                          // store name
                row[2] = sku;                                        // sku
                row[3] = table.Select("SKU='" + sku + '\'')[0][2];    // quantity
                row[8] = true;                                       // backorderable

                MainTable.Rows.Add(row);         
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();

            return MainTable;
        }

        /* override getData method */
        protected override ArrayList GetData(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
