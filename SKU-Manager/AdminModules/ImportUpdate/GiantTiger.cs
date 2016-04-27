using SKU_Manager.AdminModules.UpdateInventory.InventoryTable;
using SKU_Manager.SupportingClasses;
using SKU_Manager.SupportingClasses.ProductDetail;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SKU_Manager.AdminModules.ImportUpdate
{
    /* 
     * A class that deal with giant tiger inventory import and update the database
     */
    public class GiantTiger : ImportUpdate
    {
        // field for ftp server connection
        private readonly Ftp ftp;

        /* constructor that initialize ftp object */
        public GiantTiger()
        {
            // get credentials for giant tiger ftp log on and initialize the field
            using (SqlConnection authCon = new SqlConnection(Credentials.AscmCon))
            {
                SqlCommand command = new SqlCommand("SELECT Field1_Value, Field2_Value, Field3_Value FROM ASCM_Credentials WHERE Source = 'Vendornet' and Client = 'GiantTiger'", authCon);
                authCon.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                // initialize Ftp
                ftp = new Ftp(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
        }

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
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // declare range in sheet
                Excel.Range range = xlWorkSheet.UsedRange;
                Total = range.Rows.Count;

                // start updating database for new sears sku
                Connection.Open();
                for (int row = 1; row <= range.Rows.Count; row++)
                {
                    // getting sears's sku and our sku
                    string merchantSku = (string)(range.Cells[row, 1] as Excel.Range).Value2;
                    string vendorSku = (string)(range.Cells[row, 2] as Excel.Range).Value2;

                    // update database
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_GIANT_TIGER = \'" + merchantSku + "\' WHERE SKU_Ashlin = \'" + vendorSku + '\'', Connection);
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

        /* a method that update giant tiger inventory data and create purchase order if necessary, also send email for notification */
        public void Update(GiantTigerInventoryValues[] list)
        {
            // local fields for storing data
            Dictionary<string, int> purchaseList = new Dictionary<string, int>();
            List<string> skuList = new List<string>();

            #region CSV
            // fields for csv generation
            const string delimiter = ",";
            string[][] csv = new string[list.Length + 1][];

            // adding header
            csv[0] = new[] { "Host SKU", "Vendor SKU", "UPC", "Host Item Description", "Qty On Hand", "Unit Cost" };

            // writing content of csv file
            for (int i = 0; i < list.Length; i++)
            {
                // the case if the item is discontinue -> set its quantity to -1
                if (list[i].Discontinue) list[i].QtyOnHand = -1;

                csv[i + 1] = new[] { list[i].HostSku, list[i].VendorSku, list[i].Upc, '"' + list[i].HostItemDescription + '"', list[i].QtyOnHand.ToString(), list[i].UnitCost.ToString(System.Globalization.CultureInfo.InvariantCulture) };

                // check if item requires purchase order -> if yes, add to the purchase list
                if (!list[i].PurchaseOrder) continue;
                skuList.Add(list[i].VendorSku);
                purchaseList.Add(list[i].BpItemNumber, list[i].ReorderQuantity);
            }

            // export csv file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GiantTigerInventory";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string poNumber = CreatePoNumber("2001");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < csv.GetLength(0); i++)
                sb.AppendLine(string.Join(delimiter, csv[i]));

            // save file to local
            path += "\\" + poNumber + ".csv";
            File.WriteAllText(path, sb.ToString());

            // upload file to ftp server
            ftp.Upload("put/inventory/" + poNumber + DateTime.Now.ToString("HHmm") + ".csv", path);
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
            mail.Subject = "PENDING PURCHASE ORDER - GIANT TIGER";
            mail.Body = body;

            client.Port = 587;
            client.Credentials = new NetworkCredential("intern1002@ashlinbpg.com", "AshlinIntern2");
            client.EnableSsl = true;
            client.Send(mail);
            #endregion

            new Product().PostOrder(purchaseList, 12, poNumber);
        }

        /* a PUBLIC supporting method that set the given sku to discontine in database for giant tiger */
        public override void Discontinue(string sku)
        {
            SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET SKU_GIANT_TIGER = '' WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
