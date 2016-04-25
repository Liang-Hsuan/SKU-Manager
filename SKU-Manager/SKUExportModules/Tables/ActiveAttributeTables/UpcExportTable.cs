using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables
{
    /*
     * A class that return bestbuy export table
     */
    public class UpcExportTable : ExportTable
    {
        /* constructor that initialize fields */
        public UpcExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // add column to table
            AddColumn(MainTable, "UPC Code 9");                  // 1
            AddColumn(MainTable, "UPC Code Check Digit");        // 2
            AddColumn(MainTable, "SKU Number");                  // 3
            AddColumn(MainTable, "Short Description");           // 4

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);

                var row = MainTable.NewRow();

                row[0] = list[1];                                 // upc code 9
                row[1] = list[2];                                 // upc code check digit
                row[2] = sku;                                     // sku number
                row[3] = "Ashlin® " + list[0];                    // short description

                MainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList GetData(string sku)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from design
            // [0] short description, [1] upc code 10, [2] upc code check digit
            SqlCommand command  = new SqlCommand("SELECT Short_Description, UPC_Code_9, UPC_Code_10 " +
                                                 "FROM master_SKU_Attributes sku " +
                                                 "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                 "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 2; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
