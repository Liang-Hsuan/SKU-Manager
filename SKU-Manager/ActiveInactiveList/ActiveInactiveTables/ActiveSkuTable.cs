using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * A class that return active color table
     */
    public class ActiveSkuTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveSkuTable()
        {
            mainTable = new DataTable();
            skuList = getSKU();
        }

        /* method that get the table */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "SKU");                    
            addColumn(mainTable, "Design Service Code");
            addColumn(mainTable, "Material Code");
            addColumn(mainTable, "Colour Code");
            addColumn(mainTable, "SKU Sears.ca");
            addColumn(mainTable, "SKU TSC.ca");
            addColumn(mainTable, "SKU COSTCO.ca");
            addColumn(mainTable, "SKU Bestbuy.ca");
            addColumn(mainTable, "SKU Amazon.ca");
            addColumn(mainTable, "SKU Amazon.com");
            addColumn(mainTable, "SKU Shop.ca");
            addColumn(mainTable, "Base Price");
            addColumn(mainTable, "UPC Code 9");
            addColumn(mainTable, "UPC Code 10");
            addColumn(mainTable, "Location Full");
            addColumn(mainTable, "HTS CA");
            addColumn(mainTable, "HTS US");
            addColumn(mainTable, "Duty CA");
            addColumn(mainTable, "Duty US");
            addColumn(mainTable, "Active");

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);
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
                row[12] = list[12];     // upc code 9
                row[13] = list[13];     // upc code 10
                row[14] = list[14];     // location full
                row[15] = list[15];     // hts ca
                row[16] = list[16];     // hts us
                row[17] = list[17];     // duty ca
                row[18] = list[18];     // duty us
                row[19] = list[19];     // active

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();

            return skuList.ToArray();
        }

        /* method that get the data from given sku */
        protected ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] sku, [1] design service code, [2] material code, [3] colour code, [4] sku sears ca, [5] sku tsc ca, [6] sku costco ca, [7] sku bestbuy ca, [8] sku amazon ca 
            // [9] sku amazon com, [10] sku shop ca, [11] base price, [12] upc code 9, [13] upc code 10, [14] location full, [15] hts ca, [16] hts us, [17] duty ca, [18] duty us, [19] active
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, " + 
                                                "SKU_AMAZON_COM, SKU_SHOP_CA, Base_Price, UPC_CODE_9, UPC_CODE_10, Location_Full, HTS_CDN, HTS_US, Duty_CDN, Duty_US, Active " +
                                                "FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 19; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
