using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables
{
    /*
     * A class that return bestbuy export table
     */
    class UpcExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public UpcExportTable()
        {
            mainTable = new DataTable();
            connection = new SqlConnection(Properties.Settings.Default.Designcs);
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // add column to table
            addColumn(mainTable, "UPC Code 9");                   // 1
            addColumn(mainTable, "UPC Code Check Digit");         // 2
            addColumn(mainTable, "SKU Number");                   // 3
            addColumn(mainTable, "Short Description");            // 4


            // local field for inserting data to table
            DataRow row;
            AltText alt = new AltText();

            // start loading data
            mainTable.BeginLoadData();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                row = mainTable.NewRow();

                row[0] = list[1];                                 // upc code 9
                row[1] = list[2];                                 // upc code check digit
                row[2] = sku;                                     // sku number
                row[3] = "Ashlin® " + list[0];                    // short description

                mainTable.Rows.Add(row);
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected override string[] getSKU()
        {
            // local field for storing data
            List<string> skuList = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'TRUE\' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skuList.Add(reader.GetString(0));
            }
            connection.Close();

            return skuList.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList getData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();
            DataTable table = new DataTable();

            // get the design code from sku
            string design = sku.Substring(0, sku.IndexOf('-'));

            // grab data from design
            // [0] short description
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Short_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            table.Reset();
            // [1] upc code 9, [2] upc check digit
            adapter = new SqlDataAdapter("SELECT UPC_Code_9, UPC_Code_10 FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            list.Add(table.Rows[0][0]);
            list.Add(table.Rows[0][1]);
            connection.Close();

            return list;
        }
    }
}
