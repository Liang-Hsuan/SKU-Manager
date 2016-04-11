using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return Brightpearl net imprinted price list export table
     */
    public class BPnetImprintExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPnetImprintExportTable()
        {
            mainTable = new DataTable();
            skuList = getSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "BP item ID#");          // 1
            addColumn(mainTable, "SKU#");                 // 2
            addColumn(mainTable, "Description");          // 3
            addColumn(mainTable, "QTY breaks");           // 4
            addColumn(mainTable, "COSTS breaks");         // 5

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            double[][] discountList = getDiscount();

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
                double msrp = Convert.ToDouble(list[0]) * discountList[5][0];
                int pricingTier;
                switch (Convert.ToInt32(list[5]))
                {
                    case 1:
                        pricingTier = 1;
                        break;
                    case 2:
                        pricingTier = 2;
                        break;
                    case 3:
                        pricingTier = 3;
                        break;
                    case 4:
                        pricingTier = 4;
                        break;
                    default:
                        pricingTier = 0;
                        break;
                }
                double runCharge = list[1].Equals(DBNull.Value)? Math.Round(msrp * 0.05) / 0.6 : Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[1]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                msrp = msrp + runCharge;
                // costs breaks
                row[4] = Math.Round(msrp * discountList[pricingTier][0], 4) + "; " + Math.Round(msrp * discountList[pricingTier][1], 4) + "; " + Math.Round(msrp * discountList[pricingTier][2], 4) + "; " + Math.Round(msrp * discountList[pricingTier][3], 4) + "; "
                       + Math.Round(msrp * discountList[pricingTier][4], 4) + "; " + Math.Round(msrp * discountList[pricingTier][5], 4) + "; " + Math.Round(msrp * discountList[pricingTier][6], 4) + "; " + Math.Round(msrp * discountList[pricingTier][7], 4) + "; "
                       + Math.Round(msrp * discountList[pricingTier][8], 4);

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that return the discount matrix */
        protected override double[][] getDiscount()
        {
            double[][] list = new double[6][];

            //  [0] 1 net standard, [1] 6 net standard, [2] 24 net standard, [3] 50 net standard, [4] 100 net standard, [5] 250 net standard, [6] 500 net standard, [7] 1000 net standard, [8] 2500 net standard
            SqlCommand command = new SqlCommand("SELECT [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery] "
                                              + "FROM Discount_Matrix", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
            {
                double[] itemList = new double[9];
                reader.Read();
                for (int j = 0; j <= 8; j++)
                {
                    try
                    {
                        itemList[j] = reader.GetDouble(j);
                    }
                    catch
                    {
                        itemList[j] = 0;
                    }
                }
                list[i] = itemList;
            }
            reader.Close();

            // [5] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";
            reader = command.ExecuteReader();
            reader.Read();
            list[5] = new double[] { reader.GetDouble(0) };
            connection.Close();

            return list;
        }
    }
}
