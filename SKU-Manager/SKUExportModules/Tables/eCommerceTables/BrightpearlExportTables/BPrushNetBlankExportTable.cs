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
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case

            // add column to table
            AddColumn(mainTable, "BP item ID#");          // 1
            AddColumn(mainTable, "SKU#");                 // 2
            AddColumn(mainTable, "Description");          // 3
            AddColumn(mainTable, "QTY breaks");           // 4
            AddColumn(mainTable, "COSTS breaks");         // 5

            // local field for inserting data to table
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            double[][] discountList = GetDiscount();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                DataRow row = mainTable.NewRow();
                object[] list = GetData(sku);

                row[0] = table.Select("SKU = \'" + sku + "\'")[0][1];       // BP item id#
                row[1] = sku;                                               // sku#
                row[2] = list[2] + " - " + list[3] + " - " + list[4];       // description
                row[3] = "1; 6; 24; 50; 100; 250; 500; 1000; 2500";         // qty breaks
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
                    default:
                        k = 0;
                        break;
                }
                double msrp = Convert.ToDouble(list[0]) * discountList[k][9] * discountList[5][0];
                // costs breaks
                row[4] = Math.Round(msrp * discountList[k][0], 4) + "; " + Math.Round(msrp * discountList[k][1], 4) + "; " + Math.Round(msrp * discountList[k][2], 4) + "; " + Math.Round(msrp * discountList[k][3], 4) + "; "
                       + Math.Round(msrp * discountList[k][4], 4) + "; " + Math.Round(msrp * discountList[k][5], 4) + "; " + Math.Round(msrp * discountList[k][6], 4) + "; " + Math.Round(msrp * discountList[k][7], 4) + "; "
                       + Math.Round(msrp * discountList[k][8], 4);

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that return the discount matrix */
        protected override double[][] GetDiscount()
        {
            double[][] list = new double[6][];

            //  [0] 1 net standard, [1] 6 net standard, [2] 24 net standard, [3] 50 net standard, [4] 100 net standard, [5] 250 net standard, [6] 500 net standard, [7] 1000 net standard, [8] 2500 net standard, [9] rush net
            SqlCommand command = new SqlCommand("SELECT [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], "
                                              + "[RUSH_Net_25_wks] FROM Discount_Matrix", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i <= 4; i++)
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
            list[5] = new double[] { reader.GetDouble(0) };
            connection.Close();

            return list;
        }
    }
}
