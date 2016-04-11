using System;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    /* 
     * A class that deal with giant tiger inventory import and update the database
     */
    public class GiantTiger
    {
        // field for database connection
        private readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // field for showing the progress
        public int Total { get; private set; } = 1;
        public int Current { get; private set; }

        /* a method that update new amzon merchant sku from the excel import */
        public void Update(string xlPath)
        {
            // fields for excel sheet reading
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(xlPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // declare range in sheet
            Excel.Range range = xlWorkSheet.UsedRange;
            Total = range.Rows.Count;

            // start updating database for new sears sku
            connection.Open();
            for (int row = 1; row <= range.Rows.Count; row++)
            {
                // getting sears's sku and our sku
                string merchantSku = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                string vendorSku = (string)(range.Cells[row, 2] as Excel.Range).Value2;

                // update database
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_GIANT_TIGER = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + "\';", connection);
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
