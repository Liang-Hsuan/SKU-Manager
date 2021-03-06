﻿using System;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    /* 
     * A class that deal with amazon inventory import and update the database
     */
    public class Amazon : ImportUpdate
    {
        /* a method that update new amzon merchant sku from the excel import */
        public override void Update(string xlPath)
        {
            // set error to false
            Error = false;

            try
            {
                // fields for excel sheet reading
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(xlPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);

                // declare range in sheet
                Excel.Range range = xlWorkSheet.UsedRange;
                Total = range.Rows.Count;

                // start updating database for new amazon sku
                Connection.Open();
                for (int row = 1; row <= range.Rows.Count; row++)
                {
                    // getting amazon's sku and our sku
                    string merchantSku = (string) (range.Cells[row, 1] as Excel.Range).Value2;
                    string vendorSku = (string) (range.Cells[row, 2] as Excel.Range).Value2;

                    // update database - amazon.ca
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_AMAZON_CA = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + '\'', Connection);
                    command.ExecuteNonQuery();

                    // getting amazon's sku and our sku
                    merchantSku = (string) (range.Cells[row, 3] as Excel.Range).Value2;
                    vendorSku = (string) (range.Cells[row, 4] as Excel.Range).Value2;

                    // update database - amazon.ca
                    command.CommandText = "UPDATE master_SKU_Attributes SET SKU_AMAZON_COM = \'" + merchantSku +
                                          "\' WHERE SKU_Ashlin = \'" + vendorSku + '\'';
                    command.ExecuteNonQuery();

                    Current = row;
                }
                Connection.Close();

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
            catch (Exception ex)
            {
                Error = true;
                ErrorMessage = ex.Message;
            }
        }

        /* override discontinue method */
        public override void Discontinue(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
