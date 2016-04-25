using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.AmazonTables
{
    /*
     * A class that return amazon ca export table
     */
    public class AmazonCaExportTable : AmazonExportTable
    {
        /* constructor that initialize fields */
        public AmazonCaExportTable()
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
            AddColumn(MainTable, "KeyWords_Amazon_1");                              // 41
            AddColumn(MainTable, "KeyWrods_Amazon_2");                              // 42
            AddColumn(MainTable, "KeyWrods_Amazon_3");                              // 43
            AddColumn(MainTable, "KeyWrods_Amazon_4");                              // 44
            AddColumn(MainTable, "KeyWrods_Amazon_5");                              // 45
            AddColumn(MainTable, "target_audience_base1");                          // 46
            AddColumn(MainTable, "target_audience_base2");                          // 47
            AddColumn(MainTable, "target_audience_base3");                          // 48
            AddColumn(MainTable, "target_audience_base4");                          // 49
            AddColumn(MainTable, "target_audience_base5");                          // 50
            AddColumn(MainTable, "platinum_keywords");                              // 51
            AddColumn(MainTable, "recommended_browse_nodes1");                      // 52
            AddColumn(MainTable, "recommended_browse_nodes2");                      // 53
            AddColumn(MainTable, "bullet_point_1");                                 // 54
            AddColumn(MainTable, "bullet_point_2");                                 // 55
            AddColumn(MainTable, "bullet_point_3");                                 // 56
            AddColumn(MainTable, "bullet_point_4");                                 // 57
            AddColumn(MainTable, "bullet_point_5");                                 // 58
            AddColumn(MainTable, "catalog_number");                                 // 59
            AddColumn(MainTable, "main_image_url");                                 // 60
            AddColumn(MainTable, "swatch_image_url");                               // 61
            AddColumn(MainTable, "other_iamge_url1");                               // 62
            AddColumn(MainTable, "other_image_url2");                               // 63
            AddColumn(MainTable, "other_image_url3");                               // 64
            AddColumn(MainTable, "other_image_url4");                               // 65
            AddColumn(MainTable, "other_image_url5");                               // 66
            AddColumn(MainTable, "other_image_url6");                               // 67
            AddColumn(MainTable, "other_image_url7");                               // 68
            AddColumn(MainTable, "other_image_url8");                               // 69
            AddColumn(MainTable, "fulfillment_center_id");                          // 70
            AddColumn(MainTable, "package_height");                                 // 71
            AddColumn(MainTable, "package_height_unit_of_measure");                 // 72
            AddColumn(MainTable, "package_length");                                 // 73
            AddColumn(MainTable, "package_length_unit_of_measure");                 // 74
            AddColumn(MainTable, "package_width");                                  // 75
            AddColumn(MainTable, "package_width_unit_of_measure");                  // 76
            AddColumn(MainTable, "package_weight");                                 // 77
            AddColumn(MainTable, "package_weight_unit_of_measure");                 // 78
            AddColumn(MainTable, "relation_type");                                  // 79
            AddColumn(MainTable, "variation_theme");                                // 80
            AddColumn(MainTable, "parent_sku");                                     // 81
            AddColumn(MainTable, "parent_child");                                   // 82
            AddColumn(MainTable, "safty_warning");                                  // 83
            AddColumn(MainTable, "country_of_origin");                              // 84
            AddColumn(MainTable, "legal_disclaimer-description");                   // 85
            AddColumn(MainTable, "size_name");                                      // 86
            AddColumn(MainTable, "color_name1");                                    // 87   
            AddColumn(MainTable, "color_name2");                                    // 88
            AddColumn(MainTable, "color_map");                                      // 89
            AddColumn(MainTable, "team_name");                                      // 90
            AddColumn(MainTable, "outer_material_type");                            // 91
            AddColumn(MainTable, "wheel_type");                                     // 92
            AddColumn(MainTable, "number_of_wheels");                               // 93
            AddColumn(MainTable, "material_type");                                  // 94
            AddColumn(MainTable, "leather_type");                                   // 95
            AddColumn(MainTable, "fabric_type");                                    // 96
            AddColumn(MainTable, "inner_material_type");                            // 97
            AddColumn(MainTable, "lining_description");                             // 98
            AddColumn(MainTable, "model_year");                                     // 99
            AddColumn(MainTable, "configuration");                                  // 100
            AddColumn(MainTable, "department_name");                                // 101
            AddColumn(MainTable, "shell_type");                                     // 102
            AddColumn(MainTable, "is_stain_resistant");                             // 103
            AddColumn(MainTable, "specification_met1");                             // 104
            AddColumn(MainTable, "specification_met2");                             // 105
            AddColumn(MainTable, "specification_met3");                             // 106
            AddColumn(MainTable, "specification_met4");                             // 107
            AddColumn(MainTable, "specification_met5");                             // 108
            AddColumn(MainTable, "pattern_name");                                   // 109
            AddColumn(MainTable, "strap_type");                                     // 110
            AddColumn(MainTable, "shoulder_strap_drop");                            // 111
            AddColumn(MainTable, "shoulder_strap_droup_unit_of_measure");           // 112
            AddColumn(MainTable, "closure_type");                                   // 113
            AddColumn(MainTable, "external_testing_certification1");                // 114  
            AddColumn(MainTable, "external_testgin_certification2");                // 115
            AddColumn(MainTable, "special_features1");                              // 116  
            AddColumn(MainTable, "special_features2");                              // 117
            AddColumn(MainTable, "special_features3");                              // 118
            AddColumn(MainTable, "special_features4");                              // 119
            AddColumn(MainTable, "special_features5");                              // 120
            AddColumn(MainTable, "style_name1");                                    // 121  
            AddColumn(MainTable, "style_name2");                                    // 122  
            AddColumn(MainTable, "style_name3");                                    // 123
            AddColumn(MainTable, "style_name4");                                    // 124  
            AddColumn(MainTable, "style_name5");                                    // 125
            AddColumn(MainTable, "seasons");                                        // 126
            AddColumn(MainTable, "lifestyle");                                      // 127
            AddColumn(MainTable, "collection_name");                                // 128
            AddColumn(MainTable, "are_batteries_included");                         // 129
            AddColumn(MainTable, "battery_description");                            // 130
            AddColumn(MainTable, "number_of_batteries");                            // 131
            AddColumn(MainTable, "batery_cell_composition");                        // 132
            AddColumn(MainTable, "lithium_battery_weight_unit_of_measure");         // 133
            AddColumn(MainTable, "lithium_battery_weight");                         // 134
            AddColumn(MainTable, "battery_form_factor");                            // 135
            AddColumn(MainTable, "battery_type");                                   // 136

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
                row[2] = "Ashlin®";                                // brand name
                row[3] = "Ashlin®";                                // manufacturer 
                row[4] = list[24];                                 // external product_id
                row[5] = "UPC";                                    // external product id type
                row[6] = sku;                                      // item sku
                row[7] = "Ashlin®";                                // part number
                row[8] = list[1];                                  // product description
                row[9] = "PartiaUpdate";                           // update delete
                row[10] = Math.Ceiling(Convert.ToDouble(list[25]) * price[0] * (1 - price[1] / 100) + price[3]) - (1 - price[2]);     // standard price
                row[11] = "CAD";                                   // currency
                row[12] = "NEW";                                   // condition type
                row[13] = "Brand New";                             // condition note
                row[16] = MinorTable.Select("SKU='"+sku+"'")[0][2];// quantity
                row[17] = 1;                                       // max aggregate ship quantity
                row[18] = 1;                                       // item package quantity
                row[19] = 1;                                       // number_of_items
                row[22] = "A_GEN_NOTAX";                           // product tax code
                row[28] = true;                                    // offering can be gift messaged
                row[29] = true;                                    // offering can be giftwrapped
                row[30] = list[2];                                 // item height
                row[31] = list[3];                                 // item length
                row[32] = list[4];                                 // item width
                row[33] = "CM";                                    // item dimention unit of measure
                row[34] = list[5];                                 // item weight
                row[35] = "GR";                                    // item weight unit of measure
                row[36] = list[6];                                 // website shipping weight
                row[37] = "GR";                                    // service outside mnf warranty
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
                row[70] = list[12];                                // package height
                row[71] = "CM";                                    // package height unit of measure
                row[72] = list[13];                                // package length
                row[73] = "CM";                                    // package length unit of measure
                row[74] = list[14];                                // package width
                row[75] = "CM";                                    // package width unit of measure
                row[76] = list[15];                                // package weight
                row[77] = "GR";                                    // package weight unit of measure
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

            // finish loading table
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
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' AND SKU_AMAZON_CA != '' ORDER BY SKU_Ashlin", Connection);
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            Connection.Close();

            return list.ToArray();
        }
    }
}
