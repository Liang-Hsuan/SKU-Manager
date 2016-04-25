using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.AmazonTables
{
    /*
     * A class that return amazon com export table
     */
    public class AmazonComExportTable : AmazonExportTable
    {
        /* constructor that initialize fields */
        public AmazonComExportTable()
        {
            MainTable = new DataTable();
            SkuList = GetSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // add column to table
            AddColumn(MainTable, "item_name");                                      // 1
            AddColumn(MainTable, "feed_product_type");                              // 2
            AddColumn(MainTable, "brand_name");                                     // 3
            AddColumn(MainTable, "manufacturer");                                   // 4
            AddColumn(MainTable, "external_product_id");                            // 5
            AddColumn(MainTable, "external_product_id_type");                       // 6
            AddColumn(MainTable, "item_sku");                                       // 7
            AddColumn(MainTable, "part_number");                                    // 8
            AddColumn(MainTable, "product description");                            // 9
            AddColumn(MainTable, "update_delete");                                  // 10
            AddColumn(MainTable, "standard_price");                                 // 11
            AddColumn(MainTable, "currency");                                       // 12
            AddColumn(MainTable, "condition_type");                                 // 13
            AddColumn(MainTable, "condition_note");                                 // 14
            AddColumn(MainTable, "is_discountinued_by_manufacturer");               // 15
            AddColumn(MainTable, "restock_date");                                   // 16
            AddColumn(MainTable, "quantity");                                       // 17
            AddColumn(MainTable, "max_aggregate_ship_quantity");                    // 18
            AddColumn(MainTable, "item_package_quantity");                          // 19
            AddColumn(MainTable, "number_of_items");                                // 20
            AddColumn(MainTable, "missing_keyset_reason");                          // 21
            AddColumn(MainTable, "product_site_launch_date");                       // 22
            AddColumn(MainTable, "product_tax_code");                               // 23
            AddColumn(MainTable, "merchant_release_date");                          // 24
            AddColumn(MainTable, "sale_price");                                     // 25
            AddColumn(MainTable, "sale_end_date");                                  // 26
            AddColumn(MainTable, "sale_from_date");                                 // 27
            AddColumn(MainTable, "fulfillment_latency");                            // 28
            AddColumn(MainTable, "offering_can_be_gift_mes");                       // 29
            AddColumn(MainTable, "offering_can_be_giftwrapped");                    // 30
            AddColumn(MainTable, "item_height");                                    // 31
            AddColumn(MainTable, "item_length");                                    // 32
            AddColumn(MainTable, "item_width");                                     // 33
            AddColumn(MainTable, "item_dimensions_unit_of_measure");                // 34
            AddColumn(MainTable, "item_weight");                                    // 35
            AddColumn(MainTable, "item_weight_unit_of_measure");                    // 36
            AddColumn(MainTable, "website_shipping_weight");                        // 37 
            AddColumn(MainTable, "website_shipping_weight_unit_of_measure");        // 38
            AddColumn(MainTable, "volumn_capacity_name");                           // 39
            AddColumn(MainTable, "volumn_capacity_name_unit_of_measure");           // 40
            AddColumn(MainTable, "KeyWords_Amazon_1");                              // 32
            AddColumn(MainTable, "KeyWrods_Amazon_2");                              // 32
            AddColumn(MainTable, "KeyWrods_Amazon_3");                              // 34
            AddColumn(MainTable, "KeyWrods_Amazon_4");                              // 35
            AddColumn(MainTable, "KeyWrods_Amazon_5");                              // 36
            AddColumn(MainTable, "target_audience_base1");                          // 37
            AddColumn(MainTable, "target_audience_base2");                          // 38
            AddColumn(MainTable, "target_audience_base3");                          // 39
            AddColumn(MainTable, "target_audience_base4");                          // 40
            AddColumn(MainTable, "target_audience_base5");                          // 41
            AddColumn(MainTable, "platinum_keywords");                              // 42
            AddColumn(MainTable, "recommended_browse_nodes1");                      // 43
            AddColumn(MainTable, "recommended_browse_nodes2");                      // 44
            AddColumn(MainTable, "bullet_point_1");                                 // 45
            AddColumn(MainTable, "bullet_point_2");                                 // 46
            AddColumn(MainTable, "bullet_point_3");                                 // 47
            AddColumn(MainTable, "bullet_point_4");                                 // 48
            AddColumn(MainTable, "bullet_point_5");                                 // 49
            AddColumn(MainTable, "catalog_number");                                 // 50
            AddColumn(MainTable, "main_image_url");                                 // 51
            AddColumn(MainTable, "swatch_image_url");                               // 52
            AddColumn(MainTable, "other_iamge_url1");                               // 53
            AddColumn(MainTable, "other_image_url2");                               // 54
            AddColumn(MainTable, "other_image_url3");                               // 55
            AddColumn(MainTable, "other_image_url4");                               // 56
            AddColumn(MainTable, "other_image_url5");                               // 57
            AddColumn(MainTable, "other_image_url6");                               // 58
            AddColumn(MainTable, "other_image_url7");                               // 59
            AddColumn(MainTable, "other_image_url8");                               // 60
            AddColumn(MainTable, "fulfillment_center_id");                          // 61
            AddColumn(MainTable, "package_height");                                 // 62
            AddColumn(MainTable, "package_height_unit_of_measure");                 // 63
            AddColumn(MainTable, "package_length");                                 // 64
            AddColumn(MainTable, "package_length_unit_of_measure");                 // 65
            AddColumn(MainTable, "package_width");                                  // 66
            AddColumn(MainTable, "package_width_unit_of_measure");                  // 67
            AddColumn(MainTable, "package_weight");                                 // 68
            AddColumn(MainTable, "package_weight_unit_of_measure");                 // 69
            AddColumn(MainTable, "relation_type");                                  // 70
            AddColumn(MainTable, "variation_theme");                                // 71
            AddColumn(MainTable, "parent_sku");                                     // 72
            AddColumn(MainTable, "parent_child");                                   // 73
            AddColumn(MainTable, "safty_warning");                                  // 74
            AddColumn(MainTable, "country_of_origin");                              // 75
            AddColumn(MainTable, "legal_disclaimer-description");                   // 76
            AddColumn(MainTable, "size_name");                                      // 77
            AddColumn(MainTable, "color_name1");                                    // 78   
            AddColumn(MainTable, "color_name2");                                    // 79
            AddColumn(MainTable, "color_map");                                      // 80
            AddColumn(MainTable, "team_name");                                      // 81
            AddColumn(MainTable, "outer_material_type");                            // 82
            AddColumn(MainTable, "wheel_type");                                     // 83
            AddColumn(MainTable, "number_of_wheels");                               // 84
            AddColumn(MainTable, "material_type");                                  // 85
            AddColumn(MainTable, "leather_type");                                   // 86
            AddColumn(MainTable, "fabric_type");                                    // 87
            AddColumn(MainTable, "inner_material_type");                            // 88
            AddColumn(MainTable, "lining_description");                             // 89
            AddColumn(MainTable, "model_year");                                     // 90
            AddColumn(MainTable, "configuration");                                  // 91
            AddColumn(MainTable, "department_name");                                // 92
            AddColumn(MainTable, "shell_type");                                     // 93
            AddColumn(MainTable, "is_stain_resistant");                             // 94
            AddColumn(MainTable, "specification_met1");                             // 95
            AddColumn(MainTable, "specification_met2");                             // 96
            AddColumn(MainTable, "specification_met3");                             // 97
            AddColumn(MainTable, "specification_met4");                             // 98
            AddColumn(MainTable, "specification_met5");                             // 99
            AddColumn(MainTable, "pattern_name");                                   // 100
            AddColumn(MainTable, "strap_type");                                     // 101
            AddColumn(MainTable, "shoulder_strap_drop");                            // 102
            AddColumn(MainTable, "shoulder_strap_droup_unit_of_measure");           // 103
            AddColumn(MainTable, "closure_type");                                   // 104
            AddColumn(MainTable, "external_testing_certification1");                // 105  
            AddColumn(MainTable, "external_testgin_certification2");                // 106
            AddColumn(MainTable, "special_features1");                              // 107  
            AddColumn(MainTable, "special_features2");                              // 108
            AddColumn(MainTable, "special_features3");                              // 109
            AddColumn(MainTable, "special_features4");                              // 110
            AddColumn(MainTable, "special_features5");                              // 111
            AddColumn(MainTable, "style_name1");                                    // 112  
            AddColumn(MainTable, "style_name2");                                    // 113  
            AddColumn(MainTable, "style_name3");                                    // 114
            AddColumn(MainTable, "style_name4");                                    // 115  
            AddColumn(MainTable, "style_name5");                                    // 116
            AddColumn(MainTable, "seasons");                                        // 117
            AddColumn(MainTable, "lifestyle");                                      // 118
            AddColumn(MainTable, "collection_name");                                // 119
            AddColumn(MainTable, "are_batteries_included");                         // 120
            AddColumn(MainTable, "battery_description");                            // 121
            AddColumn(MainTable, "number_of_batteries");                            // 122
            AddColumn(MainTable, "batery_cell_composition");                        // 123
            AddColumn(MainTable, "lithium_battery_weight_unit_of_measure");         // 124
            AddColumn(MainTable, "lithium_battery_weight");                         // 125
            AddColumn(MainTable, "battery_form_factor");                            // 126
            AddColumn(MainTable, "battery_type");                                   // 127

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

                row[0] = list[0] + " " + list[37] + ' ' + list[36] + " [" + sku + ']';  // item name
                row[2] = @"Ashlin®";                               // brand name
                row[3] = @"Ashlin®";                               // manufacturer 
                row[4] = list[24];                                 // external product_id
                row[5] = "UPC";                                    // external product id type
                row[6] = sku;                                      // item sku
                row[7] = "Ashlin®";                                // part number
                row[8] = list[1];                                  // product description
                row[9] = "PartiaUpdate";                           // update delete
                row[10] = Math.Ceiling(Convert.ToDouble(list[25]) * price[0] * (1 - price[1] / 100) + price[3]) - (1 - price[2]);     // standard price
                row[11] = "USD";                                   // currency
                row[12] = "NEW";                                   // condition type
                row[13] = "Brand New";                             // condition note
                row[16] = MinorTable.Select("SKU='"+sku+"'")[0][2];// quantity
                row[17] = 1;                                       // max aggregate ship quantity
                row[18] = 1;                                       // item package quantity
                row[19] = 1;                                       // number_of_items
                row[22] = "A_GEN_NOTAX";                           // product tax code
                row[28] = true;                                    // offering can be gift messaged
                row[29] = true;                                    // offering can be giftwrapped
                row[30] = Convert.ToDouble(list[2]) / 2.54;        // item height
                row[31] = Convert.ToDouble(list[3]) / 2.54;        // item length
                row[32] = Convert.ToDouble(list[4]) / 2.54;        // item width
                row[33] = "IN";                                    // item dimention unit of measure
                row[34] = Convert.ToDouble(list[5]) / 453.592;     // item weight
                row[35] = "LB";                                    // item weight unit of measure
                row[36] = Convert.ToDouble(list[6]) / 453.592;     // website shipping weight
                row[37] = "LB";                                    // service outside mnf warranty
                row[40] = list[17];                                // keyword amazon 1
                row[41] = list[18];                                // keyword amazon 2
                row[42] = list[19];                                // keyword amazon 3
                row[43] = list[20];                                // keyword amazon 4
                row[44] = list[21];                                // keyword amazon 5
                row[45] = "man";                                   // target audience base 1
                row[46] = "wonmen";                                // target audience base 2
                row[47] = "boys";                                  // target audience base 3
                row[48] = "girls";                                 // target audience base 4
                row[49] = "unisex";                                // target audience base 5
                row[51] = list[22];                                // recommended browse nodes 1
                row[52] = list[23];                                // recommended browse nodes 2
                row[53] = list[7];                                 // bullet point 1
                row[54] = list[8];                                 // bullet point 2
                row[55] = list[9];                                 // bullet point 3
                row[56] = list[10];                                // bullet point 4
                row[57] = list[11];                                // bullet point 5
                row[59] = list[26];                                // main image url
                row[60] = GetSwatch(sku);                          // swatch image url
                row[61] = list[27];                                // other image url 1
                row[62] = list[28];                                // other image url 2
                row[63] = list[29];                                // other image url 3
                row[64] = list[30];                                // other image url 4
                row[65] = list[31];                                // other image url 5
                row[66] = list[32];                                // other image url 6
                row[67] = list[33];                                // other image url 7
                row[68] = list[34];                                // other image url 8
                row[70] = Convert.ToDouble(list[12]) / 2.54;       // package height
                row[71] = "IN";                                    // package height unit of measure
                row[72] = Convert.ToDouble(list[13]) / 2.54;       // package length
                row[73] = "IN";                                    // package length unit of measure
                row[74] = Convert.ToDouble(list[14]) / 2.54;       // package width
                row[75] = "IN";                                    // package width unit of measure
                row[76] = Convert.ToDouble(list[15]) / 453.592;    // package weight
                row[77] = "LB";                                    // package weight unit of measure
                row[83] = "IN";                                    // country of region
                row[86] = list[35];                                // color name 1
                row[88] = list[35];                                // color map
                row[90] = list[16];                                // outer material type   
                row[93] = list[16];                                // material type
                row[94] = list[16];                                // leather type      
                row[95] = "Leather";                               // fabric type
                row[125] = "All Seasons";                          // seasons
                row[126] = "Casual, Formal, Travel, Executive";    // lifestyle
                row[127] = "ASHLIN";                               // collection name 

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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' AND SKU_AMAZON_COM != '' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }
    }
}
