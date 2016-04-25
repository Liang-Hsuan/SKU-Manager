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
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* method that get the table */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "SKU");                    // 1
            AddColumn(MainTable, "Design Service Code");    // 2
            AddColumn(MainTable, "Material Code");          // 3
            AddColumn(MainTable, "Colour Code");            // 4
            AddColumn(MainTable, "SKU Sears.ca");           // 5
            AddColumn(MainTable, "SKU TSC.ca");             // 6
            AddColumn(MainTable, "SKU COSTCO.ca");          // 7
            AddColumn(MainTable, "SKU Bestbuy.ca");         // 8
            AddColumn(MainTable, "SKU Amazon.ca");          // 9
            AddColumn(MainTable, "SKU Amazon.com");         // 10
            AddColumn(MainTable, "SKU Shop.ca");            // 11
            AddColumn(MainTable, "Base Price");             // 12
            AddColumn(MainTable, "Pricing Tier");           // 13
            AddColumn(MainTable, "Reorder Quantity");       // 14
            AddColumn(MainTable, "Reorder Level");          // 15
            AddColumn(MainTable, "UPC Code 9");             // 16
            AddColumn(MainTable, "UPC Code 10");            // 17
            AddColumn(MainTable, "Location Full");          // 18
            AddColumn(MainTable, "HTS CA");                 // 19
            AddColumn(MainTable, "HTS US");                 // 20
            AddColumn(MainTable, "Duty CA");                // 21
            AddColumn(MainTable, "Duty US");                // 22
            AddColumn(MainTable, "Lining Material");        // 23
            AddColumn(MainTable, "Trim");                   // 24
            AddColumn(MainTable, "Active");                 // 25

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = MainTable.NewRow();

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
                row[13] = list[13];     // reorder quantity
                row[14] = list[14];     // reorder level
                row[15] = list[15];     // upc code 9
                row[16] = list[16];     // upc code 10
                row[17] = list[17];     // location full
                row[18] = list[18];     // hts ca
                row[19] = list[19];     // hts us
                row[20] = list[20];     // duty ca
                row[21] = list[21];     // duty us
                row[22] = list[22];     // lining material
                row[23] = list[23];     // trim
                row[24] = list[24];     // active

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* a method that get all the sku that is inactive */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'False' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        protected ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] sku, [1] design service code, [2] material code, [3] colour code, [4] sku sears ca, [5] sku tsc ca, [6] sku costco ca, [7] sku bestbuy ca, [8] sku amazon ca [9] sku amazon com, [10] sku shop ca, [11] base price, [12] Pricing_Tier, 
            // [13] reorder quantity, [14] reorder level [15] upc code 9, [16] upc code 10, [17] location full, [18] hts ca, [19] hts us, [20] duty ca, [21] duty us, [22] lining material, [23] trim, [24] active
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, " +
                                                "SKU_AMAZON_COM, SKU_SHOP_CA, Base_Price, Pricing_Tier, Reorder_Quantity, Reorder_Level, UPC_CODE_9, UPC_CODE_10, Location_Full, HTS_CDN, HTS_US, Duty_CDN, Duty_US, Lining_Material, Trim, Active " +
                                                "FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 24; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
