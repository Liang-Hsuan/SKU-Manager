using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.ExcelExportModules
{
    /*
     * A class that export Excel File
     */
    class XlExport
    {
        // fields for excel export
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;

        /* constructor that initialize Excel fields */
        public XlExport()
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
        }

        /* method that export excel file from the table and save path given */
        public void nowExport(string path, DataSet ds, string[] names)
        {
            // add worksheet for each table
            addSheet(ds);

            // add column name to each worksheet
            addColumn(ds, names);

            // add data to each worksheet
            addData(ds);

            // save file from the given save path 
            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        /* a method that add the number of worksheets according to dataset */
        private void addSheet(DataSet ds)
        {
            int length = ds.Tables.Count;

            // the case when there are more than 1 table
            if (length > 1)
            {
                // add worksheet for each table
                for (int i = 2; i <= length; i++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                }
            }
        }

        /* method that add column to the table */
        private void addColumn(DataSet ds, string[] names)
        {
            int i = 1;

            // add column name to each worksheet
            foreach (DataTable table in ds.Tables)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[i];
                xlWorkSheet.Name = names[i - 1];
                i++;

                // add column name to the table
                int k = 1;
                foreach (DataColumn column in table.Columns)
                {
                    xlWorkSheet.Cells[1, k] = column.ColumnName;
                    k++;
                }
                Excel.Range range = xlWorkSheet.Cells[1, 1] as Excel.Range;
                range.EntireRow.Font.Bold = true;
                range.EntireRow.Columns.AutoFit();
            }
        }

        /* a method that add data to each sheet */
        private void addData(DataSet ds)
        {
            int length = ds.Tables.Count;

            // add data to each sheet 
            for (int i = 0; i < length; i++)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[i + 1];

                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                    {
                        object data = ds.Tables[i].Rows[j][k];
                        xlWorkSheet.Cells[j + 2, k + 1] = data;
                    }
                }
            }
        }

        /* method that release the object */
        private void releaseObject(object obj)
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
