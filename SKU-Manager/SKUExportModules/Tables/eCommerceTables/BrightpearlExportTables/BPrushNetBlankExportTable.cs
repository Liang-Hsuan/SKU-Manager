using System;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    /*
     * A class that return Brightpearl rush net blank price list export table
     */
    class BPrushNetBlankExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPrushNetBlankExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
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
            DataRow row;
            DataTable table = Properties.Settings.Default.StockQuantityTable;
            double[] discountList = getDiscount();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                row = mainTable.NewRow();
                object[] list = getData(sku);

                row[0] = table.Select("SKU = \'" + sku + "\'")[0][1];       // BP item id#
                row[1] = sku;                                               // sku#
                row[2] = list[1];                                           // description
                row[3] = "1; 6; 24; 50; 100; 250; 500; 1000; 2500";         // qty breaks
                double msrp = Convert.ToDouble(list[0]) * discountList[9] * discountList[10];
                // costs breaks
                row[4] = msrp * discountList[0] + "; " + msrp * discountList[1] + "; " + msrp * discountList[2] + "; " + msrp * discountList[3] + "; " + msrp * discountList[4] + "; " +
                         msrp * discountList[5] + "; " + msrp * discountList[6] + "; " + msrp * discountList[7] + "; " + msrp * discountList[8];

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override object[] getData(string sku)
        {
            // local fields for storing data
            object[] list = new object[2];

            // grab data from design database
            // [0] field that related to price
            SqlCommand command = new SqlCommand("SELECT Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetValue(0);
            reader.Close();
            // [1] description
            command = new SqlCommand("SELECT Short_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + sku.Substring(0, sku.IndexOf('-')) + "\';", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetString(0);
            connection.Close();

            return list;
        }

        /* a method that return the discount matrix */
        protected override double[] getDiscount()
        {
            double[] list = new double[11];

            //  [0] 1 c net standard, [1] 6 c net standard, [2] 24 c net standard, [3] 50 c net standard, [4] 100 net standard, [5] 250 net standard, [6] 500 net standard, [7] 1000 net standard, [8] 2500 net standard, [9] rush net
            SqlCommand command = new SqlCommand("SELECT [1_Net_Standard Delivery], [6_Net_Standard Delivery], [24_Net_Standard Delivery], [50_Net_Standard Delivery], [100_Net_Standard Delivery], [250_Net_Standard Delivery], [500_Net_Standard Delivery], [1000_Net_Standard Delivery], [2500_Net_Standard Delivery], "
                                              + "[RUSH_Net_25_wks] FROM ref_discount_matrix;", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 9; i++)
            {
                list[i] = reader.GetDouble(i);
            }
            reader.Close();
            // [10] multiplier
            command = new SqlCommand("SELECT [MSRP Multiplier] FROM ref_msrp_multiplier;", connection);
            reader = command.ExecuteReader();
            reader.Read();
            list[10] = reader.GetDouble(0);
            connection.Close();

            return list;
        }
    }
}
