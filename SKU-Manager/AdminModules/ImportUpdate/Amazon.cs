using System;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    public class Amazon
    {
        // field for database connection
        private readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // field for showing the progress
        public int Total { get; private set; } = 1;
        public int Current { get; private set; }

        /* a method that update new amzon merchant sku from the excel import */
        public void update(string xlPath)
        {
            // fields for excel sheet reading
            Application xlApp = new Excel.Application();
            Workbook xlWorkBook = xlApp.Workbooks.Open(xlPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // declare range in sheet
            Range range = xlWorkSheet.UsedRange;
            Total = range.Rows.Count;

            // start updating database for new amazon sku
            connection.Open();
            for (int row = 1; row <= range.Rows.Count; row++)
            {
                // getting amazon's sku and our sku
                string merchantSku = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                string vendorSku = (string)(range.Cells[row, 2] as Excel.Range).Value2;

                // update database - amazon.ca
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_AMAZON_CA = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + "\'", connection);
                command.ExecuteNonQuery();

                // getting amazon's sku and our sku
                merchantSku = (string)(range.Cells[row, 3] as Excel.Range).Value2;
                vendorSku = (string)(range.Cells[row, 4] as Excel.Range).Value2;

                // update database - amazon.ca
                command.CommandText = "UPDATE master_SKU_Attributes SET SKU_AMAZON_COM = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + "\'";
                command.ExecuteNonQuery();

                Current = row;
            }
            connection.Close();

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        /* a supporting method that release the excel object */
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
