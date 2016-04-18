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
     * A class that deal with shop.ca inventory import and update the database
     */
    public class ShopCa : ImportUpdate
    {
        /* constructor that initialize sftp object */
        public ShopCa()
        {
            // get credentials for shop.ca sftp log on and initialize the field
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ASCMcs))
            {
                SqlCommand command = new SqlCommand("SELECT Field1_Value, Username, Password From ASCM_Credentials WHERE Source='Shop.ca - SFTP';", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                // initialize Sftp
                sftp = new Sftp(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
        }

        /* a method that update new shop.ca merchant sku from the excel import */
        public override void Update(string xlPath)
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
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SHOP_CA = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + '\'', connection);
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

        /* a method that update shop.ca inventory data and create purchase order if necessary, also send email for notification */
        public void Update(ShopCaInventoryValues[] list)
        {
            // local fields for storing data
            Dictionary<string, int> purchaseList = new Dictionary<string, int>();
            List<string> skuList = new List<string>();

            #region CSV
            // generate xml file
            string csv = "Base Data\tfeed_id=shop.ca_order_inventory_01\t(For internal processing. Do not remove rows 1 and 2)\n" +
                         "supplier_id\tstore_name\tsku\tquantity\tout_of_stock_quantity\trestock_date\tstandard_fulfillment_latency\tpriority_fulfillment_latency\tbackorderable\treturn_not_desired\tinventory_as_of_date\texternal_inventory_id\tshipping_comments\n";
            foreach (ShopCaInventoryValues value in list)
            {
                csv += value.SupplierId + '\t' + value.StoreName + '\t' + value.Sku + '\t';

                if (value.Discontinued)
                {
                    // dicontinue the sku
                    csv += "-1\t\n"; 
                }
                else if (value.PurchaseOrder)
                {
                    csv += value.Quantity + "\t\t" + value.RestockDate.ToString("yyyy-MM-dd") + "\t\t\t\t\t\t\t\n";

                    // adding item to the lists
                    purchaseList.Add(value.BpItemNumber, value.ReorderQuantity);
                    skuList.Add(value.Sku);
                }
                else
                    csv += "\t\t\t\t\t\t\t\t\t\n";
            }

            // export xml file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ShopCaInventory";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string poNumber = CreatePoNumber("1005");
            path += "\\" + poNumber + DateTime.Now.ToString("HHmm") + ".txt";
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(csv);
            writer.Close();

            // upload file to sftp server
            sftp.Connect();
            sftp.Put(path, "/fromclient/inventory");
            sftp.Close();
            #endregion

            if (purchaseList.Count < 1) return;

            #region Email
            // generating email body
            string body = "SKU need to be purchased: (Po Number = " + poNumber + ")\n\r";
            body = skuList.Aggregate(body, (current1, sku) => current1 + sku + "\n");

            // send email
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("intern1002@ashlinbpg.com");
            mail.To.Add("juanne.kochhar@ashlinbpg.com");
            mail.Subject = "PENDING PURCHASE ORDER - SHOP.CA";
            mail.Body = body;

            client.Port = 587;
            client.Credentials = new NetworkCredential("intern1002@ashlinbpg.com", "AshlinIntern2");
            client.EnableSsl = true;
            client.Send(mail);
            #endregion

            new Product().PostOrder(purchaseList, 15, poNumber);
        }

        /* a PUBLIC supporting method that set the given sku to discontine in database for shop.ca */
        public override void Discontinue(string sku)
        {
            SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_SHOP_CA = '' WHERE SKU_Ashlin = \'" + sku + '\'', connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
