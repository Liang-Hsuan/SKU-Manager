using System;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.importUpdate
{
    /* 
     * A class that deal with sears inventory import and update the database
     */
    public class Sears
    {
        // field for database connection
        private static readonly SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs);

        // field for showing the progress
        private int total = 1;
        private int current = 0;

        /* a method that update new sears merchant sku from the excel import */
        public void update(string xlPath)
        {
            // fields for excel sheet reading
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(xlPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // declare range in sheet
            range = xlWorkSheet.UsedRange;

            total = range.Rows.Count;

            // start updating database for new sears sku
            connection.Open();
            for (int row = 1; row <= range.Rows.Count; row++)
            {
                // getting sears's sku and our sku
                string merchantSku = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                string vendorSku = (string)(range.Cells[row, 2] as Excel.Range).Value2;

                // update database
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SEARS_CA = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + "\';", connection);
                command.ExecuteNonQuery();
                current = row;
            }
            connection.Close();

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        /* Get methods for the progress to client */
        public int Total
        {
            get { return total; }
        }
        public int Current
        {
            get { return current; }
        }

        /* a supporting method that release the excel object */
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
