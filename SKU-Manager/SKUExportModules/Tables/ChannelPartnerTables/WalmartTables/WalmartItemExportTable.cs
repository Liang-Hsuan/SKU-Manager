using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.WalmartTables
{
    /*
     * A class that return walmart item export table
     */
    public class WalmartItemExportTable : WalmartExportTable
    {
        /* constructor that initialize fields */
        public WalmartItemExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            MainTable.Reset();

            // add column to table
            AddColumn(MainTable, "UPC/GTIN");                       // 1
            AddColumn(MainTable, "UPC CK Digit");                   // 2
            AddColumn(MainTable, "Supplier Stock Number");          // 3
            AddColumn(MainTable, "Item Description 1");             // 4
            AddColumn(MainTable, "French Item Description 1");      // 5
            AddColumn(MainTable, "Shelf 1 / Color");                // 6
            AddColumn(MainTable, "French Shelf 1 / Color");         // 7
            AddColumn(MainTable, "Shelf 2 / Size");                 // 8
            AddColumn(MainTable, "French Shelf 2 / Size");          // 9
            AddColumn(MainTable, "Unit Size UOM");                  // 10
            AddColumn(MainTable, "Unit Size/Sell Qty");             // 11
            AddColumn(MainTable, "Item Description 2");             // 12
            AddColumn(MainTable, "French Item Description 2");      // 13
            AddColumn(MainTable, "UPC Description");                // 14
            AddColumn(MainTable, "French UPC Description");         // 15
            AddColumn(MainTable, "Signing Desc");                   // 16
            AddColumn(MainTable, "French Signing Desc");            // 17
            AddColumn(MainTable, "Brand");                          // 18
            AddColumn(MainTable, "Shop/Ticket Description");        // 19
            AddColumn(MainTable, "French Shop/Ticket Description"); // 20
            AddColumn(MainTable, "Plu Number");                     // 21
            AddColumn(MainTable, "Case UPC Supplier Pack");         // 22
            AddColumn(MainTable, "Supplier Pack Qty");              // 23
            AddColumn(MainTable, "Supplier Pack Length");           // 24
            AddColumn(MainTable, "Supplier Pack Width");            // 25
            AddColumn(MainTable, "Supplier Pack Height");           // 26
            AddColumn(MainTable, "Supplier Pack Weight");           // 27
            AddColumn(MainTable, "Supplier Min Order Qty");         // 28
            AddColumn(MainTable, "Warehouse Pack UPC Number");      // 29
            AddColumn(MainTable, "Whse Pack Qty");                  // 30
            AddColumn(MainTable, "Whse Pack Length");               // 31
            AddColumn(MainTable, "Whse Pack Width");                // 32
            AddColumn(MainTable, "Whse Pack Height");               // 33
            AddColumn(MainTable, "Whse Pack Weight");               // 34
            AddColumn(MainTable, "Whse Max Order Qty");             // 35
            AddColumn(MainTable, "Special Handling Instructions");  // 36
            AddColumn(MainTable, "Pallet Ti");                      // 37
            AddColumn(MainTable, "pallet Hi");                      // 38
            AddColumn(MainTable, "Pallet Rount Pct");               // 39
            AddColumn(MainTable, "Whse Area");                      // 40
            AddColumn(MainTable, "Marshal ID");                     // 41
            AddColumn(MainTable, "Conveyable");                     // 42
            AddColumn(MainTable, "Master Carton Ind");              // 43
            AddColumn(MainTable, "Crush Factor");                   // 44
            AddColumn(MainTable, "Whse Rotation");                  // 45
            AddColumn(MainTable, "unit Cost");                      // 46
            AddColumn(MainTable, "Base Unit Retail");               // 47
            AddColumn(MainTable, "Supplier Pack Cost");             // 48
            AddColumn(MainTable, "Mfgr Pre Price");                 // 49
            AddColumn(MainTable, "Mfgr Suggested Price");           // 50
            AddColumn(MainTable, "Item Opp");                       // 51
            AddColumn(MainTable, "Whse Pacck Calc Method");         // 52
            AddColumn(MainTable, "Department");                     // 53
            AddColumn(MainTable, "Supplier Number");                // 54
            AddColumn(MainTable, "item Type");                      // 55
            AddColumn(MainTable, "Sub type");                       // 56
            AddColumn(MainTable, "Subclass");                       // 57
            AddColumn(MainTable, "Fineline");                       // 58
            AddColumn(MainTable, "Shelf Number");                   // 59
            AddColumn(MainTable, "Product Number");                 // 60
            AddColumn(MainTable, "Projected yearly Sales Qty");     // 61
            AddColumn(MainTable, "Send to Store Date");             // 62
            AddColumn(MainTable, "Item Effective Date");            // 63
            AddColumn(MainTable, "Item Expiration Date");           // 64
            AddColumn(MainTable, "Performance Rating");             // 65
            AddColumn(MainTable, "Corporate Orderbook");            // 66
            AddColumn(MainTable, "eCommerce Orderbook");            // 67
            AddColumn(MainTable, "Variety Pack Ind");               // 68
            AddColumn(MainTable, "intangible Ind");                 // 69
            AddColumn(MainTable, "Country of Origin");              // 70
            AddColumn(MainTable, "Place of Manufacture");           // 71
            AddColumn(MainTable, "Factory ID");                     // 72
            AddColumn(MainTable, "Whse Aligment");                  // 73
            AddColumn(MainTable, "Warehouses Stocked");             // 74
            AddColumn(MainTable, "Wal-Mart");                       // 75
            AddColumn(MainTable, "Supercenter");                    // 76
            AddColumn(MainTable, "Neighborhood Market/Amigo");      // 77
            AddColumn(MainTable, "Online");                         // 78
            AddColumn(MainTable, "Send Traits");                    // 79
            AddColumn(MainTable, "Omit Traits");                    // 80
            AddColumn(MainTable, "replaces Item");                  // 81
            AddColumn(MainTable, "Change Reason Code");             // 82
            AddColumn(MainTable, "Comment");                        // 83
            AddColumn(MainTable, "Item Length");                    // 84
            AddColumn(MainTable, "Item Width");                     // 85
            AddColumn(MainTable, "Item Height");                    // 86
            AddColumn(MainTable, "Item Weight");                    // 87
            AddColumn(MainTable, "Guaranteed sales");               // 88
            AddColumn(MainTable, "Eletronic Article Serveillance Ind"); // 89
            AddColumn(MainTable, "Temp sensitive Ind");             // 90
            AddColumn(MainTable, "Modular Batch Print");            // 91
            AddColumn(MainTable, "Retail Unit Measurement");        // 92
            AddColumn(MainTable, "Item Scannable Ind");             // 93
            AddColumn(MainTable, "Scalable at Register Ind");       // 94
            AddColumn(MainTable, "Backroom Scale Ind");             // 95
            AddColumn(MainTable, "Sold by Weight/Repl by Unit");    // 96
            AddColumn(MainTable, "Shelf Life Days");                // 97
            AddColumn(MainTable, "Min Whse Life Qty");              // 98
            AddColumn(MainTable, "Variance Days");                  // 99
            AddColumn(MainTable, "Ideal Temp Lo");                  // 100
            AddColumn(MainTable, "Ideal Temp Hi");                  // 101  
            AddColumn(MainTable, "Acceptable Temp Lo");             // 102
            AddColumn(MainTable, "Acceptable Temp hi");             // 103
            AddColumn(MainTable, "Vnpk Netwgt");                    // 104
            AddColumn(MainTable, "Acctg Dept Nbr");                 // 105
            AddColumn(MainTable, "Supplier Pack Weight Format");    // 106
            AddColumn(MainTable, "Variable Comp Ind");              // 107
            AddColumn(MainTable, "Season Code");                    // 108
            AddColumn(MainTable, "Season Year");                    // 109
            AddColumn(MainTable, "Hazmat Ind");                     // 110
            AddColumn(MainTable, "Consideration Code");             // 111

            // local field for inserting data to table
            double[] price = GetPriceList();

            // start loading data
            MainTable.BeginLoadData();
            Connection.Open();

            // add data to each row 
            foreach (string sku in SkuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = MainTable.NewRow();

                row[0] = list[0];                                 // upc/gtin
                row[2] = sku;                                     // supplier stock number
                row[3] = list[8];                                 // item description 1
                row[4] = list[9];                                 // french item description 1
                row[5] = list[10];                                // shelf 1 / color
                row[6] = list[11];                                // french shelf 1 / color
                row[9] = "Ea";                                    // unit size uom
                row[10] = 00001.0000;                             // unit size / sell qty
                row[11] = "Online Only";                          // item description 2
                row[12] = "En ligne seulement";                   // french item description 2
                row[13] = "Leather Goods";                        // UPC Description
                row[14] = "Ashlin Cuir";                          // French UPC description
                row[15] = "Ashlin® " + list[2];                   // signing desc
                row[16] = "Ashlin® " + list[3];                   // french signing desc
                row[17] = 312999;                                 // brand 
                double sellMsrp = Math.Ceiling((Convert.ToDouble(list[1]) * price[0]) * (1 - price[1] / 100) + price[3]) - (1 - price[2]);
                row[45] = sellMsrp - (price[4] * sellMsrp) + price[3];   // unit cost
                row[46] = sellMsrp;                               // base unit retail
                row[83] = list[4];                                // item length
                row[84] = list[5];                                // item width
                row[85] = list[6];                                // item height
                row[86] = list[7];                                // item weight

                MainTable.Rows.Add(row);  
                Progress++;
            }

            // finish loading data
            MainTable.EndLoadData();
            Connection.Close();

            return MainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList GetData(string sku)
        {
            // local fields for storing data
            ArrayList list = new ArrayList();

            SqlCommand command = new SqlCommand("SELECT UPC_Code_10, Base_Price, " +
                                                "Short_Description, Short_Description_FR, Depth_cm, Width_cm, Height_cm, Weight_grams, " +
                                                "Design_Service_Family_Description, Design_Service_Family_Description_FR, " +
                                                "Colour_Description_Short, Colour_Description_Short_FR " +
                                                "FROM master_SKU_Attributes sku " +
                                                "INNER JOIN master_Design_Attributes design ON design.Design_Service_Code = sku.Design_Service_Code " +
                                                "INNER JOIN ref_Families family ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "INNER JOIN ref_Colours color ON color.Colour_Code = sku.Colour_Code " +
                                                "WHERE SKU_Ashlin = \'" + sku + '\'', Connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 11; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
