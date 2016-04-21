using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using SKU_Manager.SupportingClasses.ProductDetail;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Tamir.SharpSsh;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    /* 
     * A class that deal with sears inventory import and update the database
     */
    public class Sears : ImportUpdate
    {
        // field for sftp server connection
        private readonly Sftp sftp;

        /* constructor that initialize sftp object */
        public Sears()
        {
            // get credentials for sears sftp log on and initialize the field
            using (SqlConnection authCon = new SqlConnection(Properties.Settings.Default.ASCMcs))
            {
                SqlCommand command = new SqlCommand("SELECT Field1_Value, Field2_Value, Field3_Value FROM ASCM_Credentials WHERE Source = 'CommerceHub' and Client = 'Sears'", authCon);
                authCon.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                sftp = new Sftp(reader.GetString(2), reader.GetString(0), reader.GetString(1));
            }
        }

        /* a method that update new sears merchant sku from the excel import */
        public override void Update(string xlPath)
        {
            // set error to false
            Error = false;

            try
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
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SEARS_CA = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + '\'', connection);
                    command.ExecuteNonQuery();
                    Current = row;
                }
                connection.Close();

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

        /* a method that update sears inventory data and create purchase order if necessary, also send email for notification */
        public void Update(SearsInventoryValues[] list)
        {
            // local fields for storing data
            Dictionary<string, int> purchaseList = new Dictionary<string, int>();
            List<string> skuList = new List<string>();

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
                    // dicontinue the sku
                    xml += "<available>No</available>" +
                           "<discontinued_date>" + DateTime.Today.ToString("yyyyMMdd") + "</discontinued_date>";
                }
                else if (value.PurchaseOrder)
                {
                    // add this sku to purchase order list
                    skuList.Add(value.VendorSku);
                    purchaseList.Add(value.BpItemNumber, value.NextAvailableQty);

                    xml += "<available>Yes</available>" +
                           "<next_available_date>" + value.NextAvailableDate.ToString("yyyyMMdd") + "</next_available_date>" +
                           "<next_available_qty>" + value.NextAvailableQty + "</next_available_qty>";
                }
                xml += "<merchantSKU>" + value.MerchantSku.Replace('-', '_') + "</merchantSKU>" +
                       "</product>";
            }
            xml += "<advice_file_count>" + list.Length + "</advice_file_count>" +
                   "</advice_file>";

            // export xml file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SearsInventory";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string poNumber = CreatePoNumber("2002");
            path += "\\" + poNumber + DateTime.Now.ToString("HHmm") + ".xsd";
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(xml);
            writer.Close();

            // upload file to sftp server
            sftp.Connect();
            sftp.Put(path, "incoming/inventory/searscanada");
            sftp.Close();
            #endregion

            if (purchaseList.Count < 1) return;

            #region Email
            // generating email body
            string body = "SKU need to be purchased: (Po Number = " + poNumber + ")\n\r";
            body = skuList.Aggregate(body, (current1, sku) => current1 + sku + '\n');

            // send email
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("intern1002@ashlinbpg.com");
            mail.To.Add("juanne.kochhar@ashlinbpg.com");
            mail.To.Add("ashlin@ashlinbpg.com");
            mail.Subject = "PENDING PURCHASE ORDER - SEARS";
            mail.Body = body;

            client.Port = 587;
            client.Credentials = new NetworkCredential("intern1002@ashlinbpg.com", "AshlinIntern2");
            client.EnableSsl = true;
            client.Send(mail);
            #endregion

            new Product().PostOrder(purchaseList, 1, poNumber);
        }

        /* a PUBLIC supporting method that set the given sku to discontine in database for sears */
        public override void Discontinue(string sku)
        {
            SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SEARS_CA = '' WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
