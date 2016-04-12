using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.ActiveInactiveList.ActiveInactiveTables
{
    /*
     * a class that return active design table
     */
    public class ActiveDesignTable : ActiveInactiveTable
    {
        /* constructor that initializes field */
        public ActiveDesignTable()
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
            AddColumn(mainTable, "Design Service Code");        // 1
            AddColumn(mainTable, "Brand");                      // 2
            AddColumn(mainTable, "Design Service Flag");        // 3
            AddColumn(mainTable, "Design Service Family Code"); // 4
            AddColumn(mainTable, "Ashlin Internal Name");       // 5
            AddColumn(mainTable, "Short Description");          // 6
            AddColumn(mainTable, "Extended Description");       // 7
            AddColumn(mainTable, "Trend Short Description");    // 8
            AddColumn(mainTable, "Trend Extended Description"); // 9
            AddColumn(mainTable, "Online Description");         // 10
            AddColumn(mainTable, "Gift Box");                   // 11
            AddColumn(mainTable, "Imprintable");                // 12
            AddColumn(mainTable, "Imprintable Height");         // 13
            AddColumn(mainTable, "Imprinttable Width");         // 14
            AddColumn(mainTable, "Width");                      // 15
            AddColumn(mainTable, "Height");                     // 16
            AddColumn(mainTable, "Depth");                      // 17
            AddColumn(mainTable, "Weight");                     // 18
            AddColumn(mainTable, "Flat Shippable");             // 19
            AddColumn(mainTable, "Fold Shippable");             // 20
            AddColumn(mainTable, "Shippable Width");            // 21
            AddColumn(mainTable, "Shippable Height");           // 22
            AddColumn(mainTable, "Shippable Depth");            // 23
            AddColumn(mainTable, "Shippable Weight");           // 24
            AddColumn(mainTable, "Detachable Strap");           // 25
            AddColumn(mainTable, "Zippered Enclosure");         // 26
            AddColumn(mainTable, "Option 1");                   // 27
            AddColumn(mainTable, "Option 2");                   // 28
            AddColumn(mainTable, "Option 3");                   // 29
            AddColumn(mainTable, "Option 4");                   // 30
            AddColumn(mainTable, "Option 5");                   // 31
            AddColumn(mainTable, "Active");                     // 32

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = list[0];       // design service code
                row[1] = list[1];       // brand
                row[2] = list[2];       // design service flag
                row[3] = list[3];       // design service family code
                row[4] = list[4];       // ashlin internal name
                row[5] = list[5];       // short description
                row[6] = list[6];       // extended description
                row[7] = list[7];       // trend short description
                row[8] = list[8];       // trend extended description
                row[9] = list[9];       // online description
                row[10] = list[10];     // gift box
                row[11] = list[11];     // imprintable
                row[12] = list[12];     // imprintable height
                row[13] = list[13];     // imprintable width
                row[14] = list[14];     // width
                row[15] = list[15];     // height
                row[16] = list[16];     // depth
                row[17] = list[17];     // weight
                row[18] = list[18];     // flat shippable 
                row[19] = list[19];     // fold shippable
                row[20] = list[20];     // shippable width
                row[21] = list[21];     // shippable height
                row[22] = list[22];     // shippable depth
                row[23] = list[23];     // shippable weight
                row[24] = list[24];     // detachable strap
                row[25] = list[25];     // zippered enclosure
                row[26] = list[26];     // option 1
                row[27] = list[27];     // option 2
                row[28] = list[28];     // option 3
                row[29] = list[29];     // option 4
                row[30] = list[30];     // option 5
                row[31] = list[31];     // active

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the design service code that is active */
        protected sealed override string[] GetSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT Design_Service_Code FROM master_Design_Attributes WHERE Active = 'TRUE' ORDER BY Design_Service_Code", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }

        /* method that get the data from given sku */
        private ArrayList GetData(string designCode)
        {
            // local field for storing data
            ArrayList list = new ArrayList();

            // grab data from database
            // [0] design service code, [1] brand, [2] design service flag, [3]cdesign service family code, [4] ashlin internal name, [5] short description, [6] extended description, [7] trend short description, [8] trend extended description
            // [9] online description, [10] gift box, [11] imprintable, [12] imprintable height, [13] imprintable width, [14] width, [15] height, [16] depth, [17] weight, [18] flat shippable, [19] fold shippable, [20] shippable width
            // [21] shippable height, [22] shippable depth, [23] shippable weight, [24] detachable strap, [25] zippered enclosure, [26] option 1, [27] option 2, [28] option 3, [29] option 4, [30] option 5, [31] active
            SqlCommand command = new SqlCommand("SELECT Design_Service_Code, Brand, Design_Service_Flag, Design_Service_Family_Code, Design_Service_Fashion_Name_Ashlin, Short_Description, Extended_Description, Trend_Short_Description,  " +
                                                "Trend_Extended_Description, Design_Online, GiftBox, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Width_cm, Height_cm, Depth_cm, Weight_grams, Flat_Shippable, Fold_Shippable, Shippable_Width_cm, " +
                                                "Shippable_Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Detachable_Strap, Zippered_Enclosure, Option_1, Option_2, Option_3, Option_4, Option_5, Active " +
                                                "FROM master_Design_Attributes WHERE Design_Service_Code = \'" + designCode + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 31; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
