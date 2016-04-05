using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return Brightpearl rush net blank price list export table
     */
    public class BPrushNetBlankExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPrushNetBlankExportTable()
        {
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case

            // add column to table
            addColumn(mainTable, "BP item ID#");          // 1
            addColumn(mainTable, "SKU#");                 // 2
            addColumn(mainTable, "Description");          // 3
            addColumn(mainTable, "QTY breaks");           // 4
            addColumn(mainTable, "COSTS breaks");         // 5

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                object[] list = getData(sku);

                row[0] = table.Select("SKU = \'" + sku + "\'")[0][1];       // BP item id#
                row[1] = sku;                                               // sku#
                row[2] = list[2] + " - " + list[3] + " - " + list[4];       // description
                row[3] = "1; 6; 24; 50; 100; 250; 500; 1000; 2500";         // qty breaks
                double msrp = Convert.ToDouble(list[0]) * discountList[9] * discountList[10];
                // costs breaks
                row[4] = Math.Round(msrp * discountList[0], 4) + "; " + Math.Round(msrp * discountList[1], 4) + "; " + Math.Round(msrp * discountList[2], 4) + "; " + Math.Round(msrp * discountList[3], 4) + "; "
                       + Math.Round(msrp * discountList[4], 4) + "; " + Math.Round(msrp * discountList[5], 4) + "; " + Math.Round(msrp * discountList[6], 4) + "; " + Math.Round(msrp * discountList[7], 4) + "; "
                       + Math.Round(msrp * discountList[8], 4);

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that return the discount matrix */
        protected override double[] getDiscount()
        {
            double[] list = new double[11];

            //  [0] 1 net standard, [1] 6 net standard, [2] 24 net standard, [3] 50 net standard, [4] 100 net standard, [5] 250 net standard, [6] 500 net standard, [7] 1000 net standard, [8] 2500 net standard, [9] rush net
            SqlCommand command = new SqlCommand("SELECT [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], "
                                              + "[RUSH_Net_25_wks] FROM ref_discount_matrix", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 9; i++)
                list[i] = reader.GetDouble(i);
            reader.Close();

            // [10] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[10] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
