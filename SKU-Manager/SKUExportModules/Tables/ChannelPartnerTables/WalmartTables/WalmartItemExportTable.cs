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
            skuList = getSKU();
        }

        /* the real thing -> return the table !!! */
        public override DataTable getTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "UPC/GTIN");                       // 1
            addColumn(mainTable, "UPC CK Digit");                   // 2
            addColumn(mainTable, "Supplier Stock Number");          // 3
            addColumn(mainTable, "Item Description 1");             // 4
            addColumn(mainTable, "French Item Description 1");      // 5
            addColumn(mainTable, "Shelf 1 / Color");                // 6
            addColumn(mainTable, "French Shelf 1 / Color");         // 7
            addColumn(mainTable, "Shelf 2 / Size");                 // 8
            addColumn(mainTable, "French Shelf 2 / Size");          // 9
            addColumn(mainTable, "Unit Size UOM");                  // 10
            addColumn(mainTable, "Unit Size/Sell Qty");             // 11
            addColumn(mainTable, "Item Description 2");             // 12
            addColumn(mainTable, "French Item Description 2");      // 13
            addColumn(mainTable, "UPC Description");                // 14
            addColumn(mainTable, "French UPC Description");         // 15
            addColumn(mainTable, "Signing Desc");                   // 16
            addColumn(mainTable, "French Signing Desc");            // 17
            addColumn(mainTable, "Brand");                          // 18
            addColumn(mainTable, "Shop/Ticket Description");        // 19
            addColumn(mainTable, "French Shop/Ticket Description"); // 20
            addColumn(mainTable, "Plu Number");                     // 21
            addColumn(mainTable, "Case UPC Supplier Pack");         // 22
            addColumn(mainTable, "Supplier Pack Qty");              // 23
            addColumn(mainTable, "Supplier Pack Length");           // 24
            addColumn(mainTable, "Supplier Pack Width");            // 25
            addColumn(mainTable, "Supplier Pack Height");           // 26
            addColumn(mainTable, "Supplier Pack Weight");           // 27
            addColumn(mainTable, "Supplier Min Order Qty");         // 28
            addColumn(mainTable, "Warehouse Pack UPC Number");      // 29
            addColumn(mainTable, "Whse Pack Qty");                  // 30
            addColumn(mainTable, "Whse Pack Length");               // 31
            addColumn(mainTable, "Whse Pack Width");                // 32
            addColumn(mainTable, "Whse Pack Height");               // 33
            addColumn(mainTable, "Whse Pack Weight");               // 34
            addColumn(mainTable, "Whse Max Order Qty");             // 35
            addColumn(mainTable, "Special Handling Instructions");  // 36
            addColumn(mainTable, "Pallet Ti");                      // 37
            addColumn(mainTable, "pallet Hi");                      // 38
            addColumn(mainTable, "Pallet Rount Pct");               // 39
            addColumn(mainTable, "Whse Area");                      // 40
            addColumn(mainTable, "Marshal ID");                     // 41
            addColumn(mainTable, "Conveyable");                     // 42
            addColumn(mainTable, "Master Carton Ind");              // 43
            addColumn(mainTable, "Crush Factor");                   // 44
            addColumn(mainTable, "Whse Rotation");                  // 45
            addColumn(mainTable, "unit Cost");                      // 46
            addColumn(mainTable, "Base Unit Retail");               // 47
            addColumn(mainTable, "Supplier Pack Cost");             // 48
            addColumn(mainTable, "Mfgr Pre Price");                 // 49
            addColumn(mainTable, "Mfgr Suggested Price");           // 50
            addColumn(mainTable, "Item Opp");                       // 51
            addColumn(mainTable, "Whse Pacck Calc Method");         // 52
            addColumn(mainTable, "Department");                     // 53
            addColumn(mainTable, "Supplier Number");                // 54
            addColumn(mainTable, "item Type");                      // 55
            addColumn(mainTable, "Sub type");                       // 56
            addColumn(mainTable, "Subclass");                       // 57
            addColumn(mainTable, "Fineline");                       // 58
            addColumn(mainTable, "Shelf Number");                   // 59
            addColumn(mainTable, "Product Number");                 // 60
            addColumn(mainTable, "Projected yearly Sales Qty");     // 61
            addColumn(mainTable, "Send to Store Date");             // 62
            addColumn(mainTable, "Item Effective Date");            // 63
            addColumn(mainTable, "Item Expiration Date");           // 64
            addColumn(mainTable, "Performance Rating");             // 65
            addColumn(mainTable, "Corporate Orderbook");            // 66
            addColumn(mainTable, "eCommerce Orderbook");            // 67
            addColumn(mainTable, "Variety Pack Ind");               // 68
            addColumn(mainTable, "intangible Ind");                 // 69
            addColumn(mainTable, "Country of Origin");              // 70
            addColumn(mainTable, "Place of Manufacture");           // 71
            addColumn(mainTable, "Factory ID");                     // 72
            addColumn(mainTable, "Whse Aligment");                  // 73
            addColumn(mainTable, "Warehouses Stocked");             // 74
            addColumn(mainTable, "Wal-Mart");                       // 75
            addColumn(mainTable, "Supercenter");                    // 76
            addColumn(mainTable, "Neighborhood Market/Amigo");      // 77
            addColumn(mainTable, "Online");                         // 78
            addColumn(mainTable, "Send Traits");                    // 79
            addColumn(mainTable, "Omit Traits");                    // 80
            addColumn(mainTable, "replaces Item");                  // 81
            addColumn(mainTable, "Change Reason Code");             // 82
            addColumn(mainTable, "Comment");                        // 83
            addColumn(mainTable, "Item Length");                    // 84
            addColumn(mainTable, "Item Width");                     // 85
            addColumn(mainTable, "Item Height");                    // 86
            addColumn(mainTable, "Item Weight");                    // 87
            addColumn(mainTable, "Guaranteed sales");               // 88
            addColumn(mainTable, "Eletronic Article Serveillance Ind"); // 89
            addColumn(mainTable, "Temp sensitive Ind");             // 90
            addColumn(mainTable, "Modular Batch Print");            // 91
            addColumn(mainTable, "Retail Unit Measurement");        // 92
            addColumn(mainTable, "Item Scannable Ind");             // 93
            addColumn(mainTable, "Scalable at Register Ind");       // 94
            addColumn(mainTable, "Backroom Scale Ind");             // 95
            addColumn(mainTable, "Sold by Weight/Repl by Unit");    // 96
            addColumn(mainTable, "Shelf Life Days");                // 97
            addColumn(mainTable, "Min Whse Life Qty");              // 98
            addColumn(mainTable, "Variance Days");                  // 99
            addColumn(mainTable, "Ideal Temp Lo");                  // 100
            addColumn(mainTable, "Ideal Temp Hi");                  // 101  
            addColumn(mainTable, "Acceptable Temp Lo");             // 102
            addColumn(mainTable, "Acceptable Temp hi");             // 103
            addColumn(mainTable, "Vnpk Netwgt");                    // 104
            addColumn(mainTable, "Acctg Dept Nbr");                 // 105
            addColumn(mainTable, "Supplier Pack Weight Format");    // 106
            addColumn(mainTable, "Variable Comp Ind");              // 107
            addColumn(mainTable, "Season Code");                    // 108
            addColumn(mainTable, "Season Year");                    // 109
            addColumn(mainTable, "Hazmat Ind");                     // 110
            addColumn(mainTable, "Consideration Code");             // 111

            // local field for inserting data to table
            double[] price = getPrice();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);

                var row = mainTable.NewRow();

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
                row[45] = Convert.ToDouble(list[1]) * price[0];   // unit cost
                row[46] = Convert.ToDouble(list[1]) * price[1];   // base unit retail
                row[83] = list[4];                                // item length
                row[84] = list[5];                                // item width
                row[85] = list[6];                                // item height
                row[86] = list[7];                                // item weight

                mainTable.Rows.Add(row);  
                progress++;
            }

            // finish loading data
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* method that get the data from given sku */
        protected override ArrayList getData(string sku)
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

        /* a method that return the discount matrix -> [0] wholesale, [1] multiplier*/
        private double[] getPrice()
        {
            double[] list = new double[2];

            // [0] wholesale
            SqlCommand command = new SqlCommand("SELECT [Wholesale_Net] FROM ref_discount_matrix", connection);  
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            list[0] = reader.GetDouble(0);
            reader.Close();

            // [1] multiplier
            command.CommandText = "SELECT [MSRP Multiplier] FROM ref_msrp_multiplier";     
            reader = command.ExecuteReader();
            reader.Read();
            list[1] = reader.GetDouble(0);
            connection.Close();
            
            return list;
        }
    }
}
