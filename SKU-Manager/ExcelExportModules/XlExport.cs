using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.ExcelExportModules
{
    /*
     * A class that export Excel File
     */
    public class XlExport
    {
        // fields for excel export
        private readonly Excel.Application xlApp;
        private readonly Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private readonly object misValue = System.Reflection.Missing.Value;

        /* constructor that initialize Excel fields */
        public XlExport()
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
        }

        #region Export Excel Methods
        /* methods that export excel file from the table and save path given */
        public void NowExport(string path, DataSet ds, string[] names)
        {
            // add worksheet for each table
            AddSheet(ds);

            // add column names and data to each worksheet
            AddData(ds, names);

            // save file from the given save path 
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
        }
        public void NowExport(string path, DataSet ds, string[] names, int[][] textIndex)
        {
            // add worksheet for each table
            AddSheet(ds);

            // add column names and data to each worksheet
            AddData(ds, names, textIndex);

            // save file from the given save path 
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
        }
        #endregion

        /* a method that add the number of worksheets according to dataset */
        private void AddSheet(DataSet ds)
        {
            int length = ds.Tables.Count;

            // the case when there are more than 1 table
            if (length <= 1) return;
            // add worksheet for each table
            for (int i = 2; i <= length; i++)
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
        }

        #region Add Data Methods
        /* method that add column names and data to the tables */
        private void AddData(DataSet ds, IReadOnlyList<string> names)
        {
            int length = ds.Tables.Count;

            for (int i = 0; i < length; i++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[i + 1];
                xlWorkSheet.Name = names[i];

                int rows = ds.Tables[i].Rows.Count;
                int columns = ds.Tables[i].Columns.Count;
                var data = new object[rows + 1, columns];

                // insert column names
                for (int column = 0; column < columns; column++)
                {
                    data[0, column] = ds.Tables[i].Columns[column].ColumnName;
                }

                // insert data
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                        data[row + 1, column] = ds.Tables[i].Rows[row][column];
                }

                // write data to the excel worksheet
                Excel.Range beginWrite = xlWorkSheet.Cells[1, 1];
                Excel.Range endWrite = xlWorkSheet.Cells[rows + 1, columns];
                Excel.Range sheetData = xlWorkSheet.Range[beginWrite, endWrite];
                sheetData.Value2 = data;

                // format headers
                Excel.Range range = xlWorkSheet.Cells[1, 1] as Excel.Range;
                range.EntireRow.Font.Bold = true;
                range.EntireRow.Columns.AutoFit();
            }
        }
        private void AddData(DataSet ds, IReadOnlyList<string> names, IReadOnlyList<int[]> textIndex)
        {
            int length = ds.Tables.Count;

            for (int i = 0; i < length; i++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[i + 1];
                xlWorkSheet.Name = names[i];

                // format column cast as text 
                Excel.Range range;
                foreach (int j in textIndex[i])
                {
                    range = xlWorkSheet.Cells[1, j] as Excel.Range;
                    range.EntireColumn.NumberFormat = "@";
                }

                int rows = ds.Tables[i].Rows.Count;
                int columns = ds.Tables[i].Columns.Count;
                var data = new object[rows + 1, columns];

                // insert column names
                for (int column = 0; column < columns; column++)
                {
                    data[0, column] = ds.Tables[i].Columns[column].ColumnName;
                }

                // insert data
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                        data[row + 1, column] = ds.Tables[i].Rows[row][column];
                }

                // write data to the excel worksheet
                Excel.Range beginWrite = xlWorkSheet.Cells[1, 1];
                Excel.Range endWrite = xlWorkSheet.Cells[rows + 1, columns];
                Excel.Range sheetData = xlWorkSheet.Range[beginWrite, endWrite];
                sheetData.Value2 = data;

                // format headers
                range = xlWorkSheet.Cells[1, 1] as Excel.Range;
                range.EntireRow.Font.Bold = true;
                range.EntireRow.Columns.AutoFit();
            }
        }
        #endregion

        /* method that release the object */
        private static void ReleaseObject(object obj)
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
