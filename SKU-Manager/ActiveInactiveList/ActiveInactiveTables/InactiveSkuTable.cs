using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return inactive sku table
     */
    public class InactiveSkuTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public InactiveSkuTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* method that get the table */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "SKU");
            AddColumn(mainTable, "Design Service Code");
            AddColumn(mainTable, "Material Code");
            AddColumn(mainTable, "Colour Code");
            AddColumn(mainTable, "SKU Sears.ca");
            AddColumn(mainTable, "SKU TSC.ca");
            AddColumn(mainTable, "SKU COSTCO.ca");
            AddColumn(mainTable, "SKU Bestbuy.ca");
            AddColumn(mainTable, "SKU Amazon.ca");
            AddColumn(mainTable, "SKU Amazon.com");
            AddColumn(mainTable, "SKU Shop.ca");
            AddColumn(mainTable, "Base Price");
            AddColumn(mainTable, "Pricing Tier");
            AddColumn(mainTable, "UPC Code 9");
            AddColumn(mainTable, "UPC Code 10");
            AddColumn(mainTable, "Location Full");
            AddColumn(mainTable, "HTS CA");
            AddColumn(mainTable, "HTS US");
            AddColumn(mainTable, "Duty CA");
            AddColumn(mainTable, "Duty US");
            AddColumn(mainTable, "Active");

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = list[0];       // sku
                row[1] = list[1];       // design service code
                row[2] = list[2];       // material code
                row[3] = list[3];       // colour code
                row[4] = list[4];       // sku sears ca
                row[5] = list[5];       // sku tsc ca
                row[6] = list[6];       // sku costco ca
                row[7] = list[7];       // sku bestbuy ca
                row[8] = list[8];       // sku amazon ca
                row[9] = list[9];       // sku amazon com
                row[10] = list[10];     // sku shop ca
                row[11] = list[11];     // base price
                row[12] = list[12];     // pricing tier
                row[13] = list[13];     // upc code 9
                row[14] = list[14];     // upc code 10
                row[15] = list[15];     // location full
                row[16] = list[16];     // hts ca
                row[17] = list[17];     // hts us
                row[18] = list[18];     // duty ca
                row[19] = list[19];     // duty us
                row[20] = list[20];     // active

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is inactive */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'False' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        protected ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] sku, [1] design service code, [2] material code, [3] colour code, [4] sku sears ca, [5] sku tsc ca, [6] sku costco ca, [7] sku bestbuy ca, [8] sku amazon ca 
            // [9] sku amazon com, [10] sku shop ca, [11] base price, [12] pricing tier, [13] upc code 9, [14] upc code 10, [15] location full, [16] hts ca, [17] hts us, [18] duty ca, [19] duty us, [20] active
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, " +
                                                "SKU_AMAZON_COM, SKU_SHOP_CA, Base_Price, Pricing_Tier, UPC_CODE_9, UPC_CODE_10, Location_Full, HTS_CDN, HTS_US, Duty_CDN, Duty_US, Active " +
                                                "FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 20; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
