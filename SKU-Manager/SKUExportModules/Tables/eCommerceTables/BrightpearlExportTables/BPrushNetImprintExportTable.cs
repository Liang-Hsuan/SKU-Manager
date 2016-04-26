using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return Brightpearl rush net imprint price list export table
     */
    public class BPrushNetImprintExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPrushNetImprintExportTable()
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
            AddColumn(MainTable, "BP item ID#");          // 1
            AddColumn(MainTable, "SKU#");                 // 2
            AddColumn(MainTable, "Description");          // 3
            AddColumn(MainTable, "QTY breaks");           // 4
            AddColumn(MainTable, "COSTS breaks");         // 5

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            double[][] discountList = GetDiscount();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                DataRow row = MainTable.NewRow();
                object[] list = GetData(sku);

                row[0] = table.Select("SKU = \'" + sku + '\'')[0][1];       // BP item id#
                row[1] = sku;                                               // sku#
                row[2] = list[2] + " - " + list[3] + " - " + list[4];       // description
                row[3] = "1; 6; 24; 50; 100; 250; 500; 1000; 2500";         // qty breaks
                double msrp = Convert.ToDouble(list[0]) * discountList[7][0];
                double runCharge = list[1].Equals(DBNull.Value) ? Math.Round(msrp * 0.05) / 0.6 : Math.Round(msrp * 0.05) / 0.6 + Convert.ToInt32(list[1]) - 1;
                if (runCharge > 8)
                    runCharge = 8;
                else if (runCharge < 1)
                    runCharge = 1;
                int k;
                switch (Convert.ToInt32(list[5]))
                {
                    case 1:
                        k = 1;
                        break;
                    case 2:
                        k = 2;
                        break;
                    case 3:
                        k = 3;
                        break;
                    case 4:
                        k = 4;
                        break;
                    case 5:
                        k = 5;
                        break;
                    case 6:
                        k = 6;
                        break;
                    default:
                        k = 0;
                        break;
                }
                msrp = (msrp + runCharge) * discountList[k][9];
                // costs breaks
                row[4] = Math.Round(msrp * discountList[k][0], 4) + "; " + Math.Round(msrp * discountList[k][1], 4) + "; " + Math.Round(msrp * discountList[k][2], 4) + "; " + Math.Round(msrp * discountList[k][3], 4) + "; "
                       + Math.Round(msrp * discountList[k][4], 4) + "; " + Math.Round(msrp * discountList[k][5], 4) + "; " + Math.Round(msrp * discountList[k][6], 4) + "; " + Math.Round(msrp * discountList[k][7], 4) + "; "
                       + Math.Round(msrp * discountList[k][8], 4);

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* a method that return the discount matrix */
        protected override double[][] GetDiscount()
        {
            double[][] list = new double[8][];

            //  [0] 1 net standard, [1] 6 net standard, [2] 24 net standard, [3] 50 net standard, [4] 100 net standard, [5] 250 net standard, [6] 500 net standard, [7] 1000 net standard, [8] 2500 net standard, [9] rush net
            SqlCommand command = new SqlCommand("SELECT [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], "
                                              + "[RUSH_Net_25_wks] FROM Discount_Matrix", Connection);

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 6; i++)
            {
                double[] itemList = new double[10];
                reader.Read();
                for (int j = 0; j <= 9; j++)
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
            list[7] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }
    }
}
