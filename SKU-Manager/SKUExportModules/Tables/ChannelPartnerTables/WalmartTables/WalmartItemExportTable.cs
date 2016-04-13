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
            mainTable = new DataTable();
            skuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "UPC/GTIN");                       // 1
            AddColumn(mainTable, "UPC CK Digit");                   // 2
            AddColumn(mainTable, "Supplier Stock Number");          // 3
            AddColumn(mainTable, "Item Description 1");             // 4
            AddColumn(mainTable, "French Item Description 1");      // 5
            AddColumn(mainTable, "Shelf 1 / Color");                // 6
            AddColumn(mainTable, "French Shelf 1 / Color");         // 7
            AddColumn(mainTable, "Shelf 2 / Size");                 // 8
            AddColumn(mainTable, "French Shelf 2 / Size");          // 9
            AddColumn(mainTable, "Unit Size UOM");                  // 10
            AddColumn(mainTable, "Unit Size/Sell Qty");             // 11
            AddColumn(mainTable, "Item Description 2");             // 12
            AddColumn(mainTable, "French Item Description 2");      // 13
            AddColumn(mainTable, "UPC Description");                // 14
            AddColumn(mainTable, "French UPC Description");         // 15
            AddColumn(mainTable, "Signing Desc");                   // 16
            AddColumn(mainTable, "French Signing Desc");            // 17
            AddColumn(mainTable, "Brand");                          // 18
            AddColumn(mainTable, "Shop/Ticket Description");        // 19
            AddColumn(mainTable, "French Shop/Ticket Description"); // 20
            AddColumn(mainTable, "Plu Number");                     // 21
            AddColumn(mainTable, "Case UPC Supplier Pack");         // 22
            AddColumn(mainTable, "Supplier Pack Qty");              // 23
            AddColumn(mainTable, "Supplier Pack Length");           // 24
            AddColumn(mainTable, "Supplier Pack Width");            // 25
            AddColumn(mainTable, "Supplier Pack Height");           // 26
            AddColumn(mainTable, "Supplier Pack Weight");           // 27
            AddColumn(mainTable, "Supplier Min Order Qty");         // 28
            AddColumn(mainTable, "Warehouse Pack UPC Number");      // 29
            AddColumn(mainTable, "Whse Pack Qty");                  // 30
            AddColumn(mainTable, "Whse Pack Length");               // 31
            AddColumn(mainTable, "Whse Pack Width");                // 32
            AddColumn(mainTable, "Whse Pack Height");               // 33
            AddColumn(mainTable, "Whse Pack Weight");               // 34
            AddColumn(mainTable, "Whse Max Order Qty");             // 35
            AddColumn(mainTable, "Special Handling Instructions");  // 36
            AddColumn(mainTable, "Pallet Ti");                      // 37
            AddColumn(mainTable, "pallet Hi");                      // 38
            AddColumn(mainTable, "Pallet Rount Pct");               // 39
            AddColumn(mainTable, "Whse Area");                      // 40
            AddColumn(mainTable, "Marshal ID");                     // 41
            AddColumn(mainTable, "Conveyable");                     // 42
            AddColumn(mainTable, "Master Carton Ind");              // 43
            AddColumn(mainTable, "Crush Factor");                   // 44
            AddColumn(mainTable, "Whse Rotation");                  // 45
            AddColumn(mainTable, "unit Cost");                      // 46
            AddColumn(mainTable, "Base Unit Retail");               // 47
            AddColumn(mainTable, "Supplier Pack Cost");             // 48
            AddColumn(mainTable, "Mfgr Pre Price");                 // 49
            AddColumn(mainTable, "Mfgr Suggested Price");           // 50
            AddColumn(mainTable, "Item Opp");                       // 51
            AddColumn(mainTable, "Whse Pacck Calc Method");         // 52
            AddColumn(mainTable, "Department");                     // 53
            AddColumn(mainTable, "Supplier Number");                // 54
            AddColumn(mainTable, "item Type");                      // 55
            AddColumn(mainTable, "Sub type");                       // 56
            AddColumn(mainTable, "Subclass");                       // 57
            AddColumn(mainTable, "Fineline");                       // 58
            AddColumn(mainTable, "Shelf Number");                   // 59
            AddColumn(mainTable, "Product Number");                 // 60
            AddColumn(mainTable, "Projected yearly Sales Qty");     // 61
            AddColumn(mainTable, "Send to Store Date");             // 62
            AddColumn(mainTable, "Item Effective Date");            // 63
            AddColumn(mainTable, "Item Expiration Date");           // 64
            AddColumn(mainTable, "Performance Rating");             // 65
            AddColumn(mainTable, "Corporate Orderbook");            // 66
            AddColumn(mainTable, "eCommerce Orderbook");            // 67
            AddColumn(mainTable, "Variety Pack Ind");               // 68
            AddColumn(mainTable, "intangible Ind");                 // 69
            AddColumn(mainTable, "Country of Origin");              // 70
            AddColumn(mainTable, "Place of Manufacture");           // 71
            AddColumn(mainTable, "Factory ID");                     // 72
            AddColumn(mainTable, "Whse Aligment");                  // 73
            AddColumn(mainTable, "Warehouses Stocked");             // 74
            AddColumn(mainTable, "Wal-Mart");                       // 75
            AddColumn(mainTable, "Supercenter");                    // 76
            AddColumn(mainTable, "Neighborhood Market/Amigo");      // 77
            AddColumn(mainTable, "Online");                         // 78
            AddColumn(mainTable, "Send Traits");                    // 79
            AddColumn(mainTable, "Omit Traits");                    // 80
            AddColumn(mainTable, "replaces Item");                  // 81
            AddColumn(mainTable, "Change Reason Code");             // 82
            AddColumn(mainTable, "Comment");                        // 83
            AddColumn(mainTable, "Item Length");                    // 84
            AddColumn(mainTable, "Item Width");                     // 85
            AddColumn(mainTable, "Item Height");                    // 86
            AddColumn(mainTable, "Item Weight");                    // 87
            AddColumn(mainTable, "Guaranteed sales");               // 88
            AddColumn(mainTable, "Eletronic Article Serveillance Ind"); // 89
            AddColumn(mainTable, "Temp sensitive Ind");             // 90
            AddColumn(mainTable, "Modular Batch Print");            // 91
            AddColumn(mainTable, "Retail Unit Measurement");        // 92
            AddColumn(mainTable, "Item Scannable Ind");             // 93
            AddColumn(mainTable, "Scalable at Register Ind");       // 94
            AddColumn(mainTable, "Backroom Scale Ind");             // 95
            AddColumn(mainTable, "Sold by Weight/Repl by Unit");    // 96
            AddColumn(mainTable, "Shelf Life Days");                // 97
            AddColumn(mainTable, "Min Whse Life Qty");              // 98
            AddColumn(mainTable, "Variance Days");                  // 99
            AddColumn(mainTable, "Ideal Temp Lo");                  // 100
            AddColumn(mainTable, "Ideal Temp Hi");                  // 101  
            AddColumn(mainTable, "Acceptable Temp Lo");             // 102
            AddColumn(mainTable, "Acceptable Temp hi");             // 103
            AddColumn(mainTable, "Vnpk Netwgt");                    // 104
            AddColumn(mainTable, "Acctg Dept Nbr");                 // 105
            AddColumn(mainTable, "Supplier Pack Weight Format");    // 106
            AddColumn(mainTable, "Variable Comp Ind");              // 107
            AddColumn(mainTable, "Season Code");                    // 108
            AddColumn(mainTable, "Season Year");                    // 109
            AddColumn(mainTable, "Hazmat Ind");                     // 110
            AddColumn(mainTable, "Consideration Code");             // 111

            // local field for inserting data to table
            double[] price = GetPriceList();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = GetData(sku);
                DataRow row = mainTable.NewRow();

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

                mainTable.Rows.Add(row);  
                Progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
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
                                                "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for (int i = 0; i <= 11; i++)
                list.Add(reader.GetValue(i));

            return list;
        }
    }
}
