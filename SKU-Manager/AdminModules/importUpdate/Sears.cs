using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
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
        public int Total => total;
        public int Current => current;

        /* a method that update sears inventory data and create purchase order if necessary, also send email for notification*/
        public void update(SearsInventoryValues[] list)
        {
            // field for storing the sku that need purchase order
            List<string> purchaseList = new List<string>();

            #region XML
            // generate xml file
            string xml = "<advice_file>" +
                         "<advice_file_control_number>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</advice_file_control_number>" +
                         "<vendorMerchID>searscanada</vendorMerchID>";
            foreach (SearsInventoryValues value in list)
            {
                xml += "<product>" +
                       "<vendor_SKU>" + value.VendorSku + "</vendor_SKU>" +
                       "<qtyonhand>" + value.QtyOnHand + "</qtyonhand>";
                if (value.Discontinued)
                {
                    discontinue(value.VendorSku);
                    xml += "<available>No</available>" +
                           "<discontinued_date>" + DateTime.Today.ToString("yyyyMMdd") + "</discontinued_date>";
                }
                else if (value.PurchaseOrder)
                {
                    // add this sku to purchase order list
                    purchaseList.Add(value.VendorSku);

                    xml += "<available>Yes</available>" +
                           "<next_available_date>" + value.NextAvailableDate.ToString("yyyyMMdd") + "</next_available_date>" +
                           "<next_available_qty>" + 25 + "</next_available_qty>";
                }
                xml += "<merchantSKU>" + value.MerchantSku + "</merchantSKU>" +
                       "</product>";
            }
            xml += "<advice_file_count>" + list.Length + "</advice_file_count>" +
                   "</advice_file>";
            #endregion

            #region Email
            if (purchaseList.Count < 1) return;

            // generating email body
            string body = "SKU need to be purchased: \n\r";
            foreach (string sku in purchaseList)
                body += sku + "\n";

            // send email
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("intern1002@ashlinbpg.com");
            mail.To.Add("intern1002@ashlinbpg.com");
            mail.Subject = "PENDING PURCHASE ORDER";
            mail.Body = body;

            client.Port = 587;
            client.Credentials = new NetworkCredential("intern1002@ashlinbpg.com", "AshlinIntern2");
            client.EnableSsl = true;
            client.Send(mail);
            #endregion
        }

        #region Supporting Method
        /* a supporting method that set the given sku to discontine in database for sears */
        private static void discontinue(string sku)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SEARS_CA = '' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
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
        #endregion
    }
}
