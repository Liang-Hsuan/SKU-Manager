using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return Brightpearl rush coded imprint price list export table
     */
    public class BPrushCodedImprintExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPrushCodedImprintExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case

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

                row[0] = table.Select("SKU = \'" + sku + "\'")[0][1];       // BP item id#
                row[1] = sku;                                               // sku#
                row[2] = list[2] + " - " + list[3] + " - " + list[4];       // description
                row[3] = "1; 6; 24; 50; 100; 250; 500; 1000; 2500";         // qty breaks
                double msrp = Convert.ToDouble(list[0]) * discountList[5][0];
                double runCharge = list[1].Equals(DBNull.Value) ? Math.Round(msrp*0.05)/0.6 : Math.Round(msrp*0.05)/0.6 + Convert.ToInt32(list[1]) - 1;
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
            double[][] list = new double[6][];

            //  [0] 1 c standard, [1] 6 c standard, [2] 24 c standard, [3] 50 c standard, [4] 100 c standard, [5] 250 c standard, [6] 500 c standard, [7] 1000 c standard, [8] 2500 c standard, [9] rush c
            SqlCommand command = new SqlCommand("SELECT [1_C_Standard Delivery], [6_C_Standard Delivery], [24_C_Standard Delivery], [50_C_Standard Delivery], [100_C_Standard Delivery], [250_C_Standard Delivery], [500_C_Standard Delivery], [1000_C_Standard Delivery], [2500_C_Standard Delivery], "
                                              + "[RUSH_C_25_wks] FROM Discount_Matrix", Connection);

            Connection.Open();
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
            list[5] = new[] { reader.GetDouble(0) };
            Connection.Close();

            return list;
        }
    }
}
