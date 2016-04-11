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
            mainTable = new DataTable();
            skuList = getSku();
        }

        /* the real thing -> return the table !!! */
        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            addColumn(mainTable, "item_name");                                      // 1
            addColumn(mainTable, "feed_product_type");                              // 2
            addColumn(mainTable, "brand_name");                                     // 3
            addColumn(mainTable, "manufacturer");                                   // 4
            addColumn(mainTable, "external_product_id");                            // 5
            addColumn(mainTable, "external_product_id_type");                       // 6
            addColumn(mainTable, "item_sku");                                       // 7
            addColumn(mainTable, "part_number");                                    // 8
            addColumn(mainTable, "product description");                            // 9
            addColumn(mainTable, "update_delete");                                  // 10
            addColumn(mainTable, "standard_price");                                 // 11
            addColumn(mainTable, "currency");                                       // 12
            addColumn(mainTable, "condition_type");                                 // 13
            addColumn(mainTable, "condition_note");                                 // 14
            addColumn(mainTable, "is_discountinued_by_manufacturer");               // 15
            addColumn(mainTable, "restock_date");                                   // 16
            addColumn(mainTable, "quantity");                                       // 17
            addColumn(mainTable, "max_aggregate_ship_quantity");                    // 18
            addColumn(mainTable, "item_package_quantity");                          // 19
            addColumn(mainTable, "number_of_items");                                // 20
            addColumn(mainTable, "missing_keyset_reason");                          // 21
            addColumn(mainTable, "product_site_launch_date");                       // 22
            addColumn(mainTable, "product_tax_code");                               // 23
            addColumn(mainTable, "merchant_release_date");                          // 24
            addColumn(mainTable, "sale_price");                                     // 25
            addColumn(mainTable, "sale_end_date");                                  // 26
            addColumn(mainTable, "sale_from_date");                                 // 27
            addColumn(mainTable, "fulfillment_latency");                            // 28
            addColumn(mainTable, "offering_can_be_gift_mes");                       // 29
            addColumn(mainTable, "offering_can_be_giftwrapped");                    // 30
            addColumn(mainTable, "item_height");                                    // 31
            addColumn(mainTable, "item_length");                                    // 32
            addColumn(mainTable, "item_width");                                     // 33
            addColumn(mainTable, "item_dimensions_unit_of_measure");                // 34
            addColumn(mainTable, "item_weight");                                    // 35
            addColumn(mainTable, "item_weight_unit_of_measure");                    // 36
            addColumn(mainTable, "website_shipping_weight");                        // 37 
            addColumn(mainTable, "website_shipping_weight_unit_of_measure");        // 38
            addColumn(mainTable, "volumn_capacity_name");                           // 39
            addColumn(mainTable, "volumn_capacity_name_unit_of_measure");           // 40
            addColumn(mainTable, "KeyWords_Amazon_1");                              // 41
            addColumn(mainTable, "KeyWrods_Amazon_2");                              // 42
            addColumn(mainTable, "KeyWrods_Amazon_3");                              // 43
            addColumn(mainTable, "KeyWrods_Amazon_4");                              // 44
            addColumn(mainTable, "KeyWrods_Amazon_5");                              // 45
            addColumn(mainTable, "target_audience_base1");                          // 46
            addColumn(mainTable, "target_audience_base2");                          // 47
            addColumn(mainTable, "target_audience_base3");                          // 48
            addColumn(mainTable, "target_audience_base4");                          // 49
            addColumn(mainTable, "target_audience_base5");                          // 50
            addColumn(mainTable, "platinum_keywords");                              // 51
            addColumn(mainTable, "recommended_browse_nodes1");                      // 52
            addColumn(mainTable, "recommended_browse_nodes2");                      // 53
            addColumn(mainTable, "bullet_point_1");                                 // 54
            addColumn(mainTable, "bullet_point_2");                                 // 55
            addColumn(mainTable, "bullet_point_3");                                 // 56
            addColumn(mainTable, "bullet_point_4");                                 // 57
            addColumn(mainTable, "bullet_point_5");                                 // 58
            addColumn(mainTable, "catalog_number");                                 // 59
            addColumn(mainTable, "main_image_url");                                 // 60
            addColumn(mainTable, "swatch_image_url");                               // 61
            addColumn(mainTable, "other_iamge_url1");                               // 62
            addColumn(mainTable, "other_image_url2");                               // 63
            addColumn(mainTable, "other_image_url3");                               // 64
            addColumn(mainTable, "other_image_url4");                               // 65
            addColumn(mainTable, "other_image_url5");                               // 66
            addColumn(mainTable, "other_image_url6");                               // 67
            addColumn(mainTable, "other_image_url7");                               // 68
            addColumn(mainTable, "other_image_url8");                               // 69
            addColumn(mainTable, "fulfillment_center_id");                          // 70
            addColumn(mainTable, "package_height");                                 // 71
            addColumn(mainTable, "package_height_unit_of_measure");                 // 72
            addColumn(mainTable, "package_length");                                 // 73
            addColumn(mainTable, "package_length_unit_of_measure");                 // 74
            addColumn(mainTable, "package_width");                                  // 75
            addColumn(mainTable, "package_width_unit_of_measure");                  // 76
            addColumn(mainTable, "package_weight");                                 // 77
            addColumn(mainTable, "package_weight_unit_of_measure");                 // 78
            addColumn(mainTable, "relation_type");                                  // 79
            addColumn(mainTable, "variation_theme");                                // 80
            addColumn(mainTable, "parent_sku");                                     // 81
            addColumn(mainTable, "parent_child");                                   // 82
            addColumn(mainTable, "safty_warning");                                  // 83
            addColumn(mainTable, "country_of_origin");                              // 84
            addColumn(mainTable, "legal_disclaimer-description");                   // 85
            addColumn(mainTable, "size_name");                                      // 86
            addColumn(mainTable, "color_name1");                                    // 87   
            addColumn(mainTable, "color_name2");                                    // 88
            addColumn(mainTable, "color_map");                                      // 89
            addColumn(mainTable, "team_name");                                      // 90
            addColumn(mainTable, "outer_material_type");                            // 91
            addColumn(mainTable, "wheel_type");                                     // 92
            addColumn(mainTable, "number_of_wheels");                               // 93
            addColumn(mainTable, "material_type");                                  // 94
            addColumn(mainTable, "leather_type");                                   // 95
            addColumn(mainTable, "fabric_type");                                    // 96
            addColumn(mainTable, "inner_material_type");                            // 97
            addColumn(mainTable, "lining_description");                             // 98
            addColumn(mainTable, "model_year");                                     // 99
            addColumn(mainTable, "configuration");                                  // 100
            addColumn(mainTable, "department_name");                                // 101
            addColumn(mainTable, "shell_type");                                     // 102
            addColumn(mainTable, "is_stain_resistant");                             // 103
            addColumn(mainTable, "specification_met1");                             // 104
            addColumn(mainTable, "specification_met2");                             // 105
            addColumn(mainTable, "specification_met3");                             // 106
            addColumn(mainTable, "specification_met4");                             // 107
            addColumn(mainTable, "specification_met5");                             // 108
            addColumn(mainTable, "pattern_name");                                   // 109
            addColumn(mainTable, "strap_type");                                     // 110
            addColumn(mainTable, "shoulder_strap_drop");                            // 111
            addColumn(mainTable, "shoulder_strap_droup_unit_of_measure");           // 112
            addColumn(mainTable, "closure_type");                                   // 113
            addColumn(mainTable, "external_testing_certification1");                // 114  
            addColumn(mainTable, "external_testgin_certification2");                // 115
            addColumn(mainTable, "special_features1");                              // 116  
            addColumn(mainTable, "special_features2");                              // 117
            addColumn(mainTable, "special_features3");                              // 118
            addColumn(mainTable, "special_features4");                              // 119
            addColumn(mainTable, "special_features5");                              // 120
            addColumn(mainTable, "style_name1");                                    // 121  
            addColumn(mainTable, "style_name2");                                    // 122  
            addColumn(mainTable, "style_name3");                                    // 123
            addColumn(mainTable, "style_name4");                                    // 124  
            addColumn(mainTable, "style_name5");                                    // 125
            addColumn(mainTable, "seasons");                                        // 126
            addColumn(mainTable, "lifestyle");                                      // 127
            addColumn(mainTable, "collection_name");                                // 128
            addColumn(mainTable, "are_batteries_included");                         // 129
            addColumn(mainTable, "battery_description");                            // 130
            addColumn(mainTable, "number_of_batteries");                            // 131
            addColumn(mainTable, "batery_cell_composition");                        // 132
            addColumn(mainTable, "lithium_battery_weight_unit_of_measure");         // 133
            addColumn(mainTable, "lithium_battery_weight");                         // 134
            addColumn(mainTable, "battery_form_factor");                            // 135
            addColumn(mainTable, "battery_type");                                   // 136

            // local field for inserting data to table
            double[] price = getPriceList();

            // start loading data
            mainTable.BeginLoadData();
            connection.Open();

            // add data to each row 
            foreach (string sku in skuList)
            {
                ArrayList list = getData(sku);
                DataRow row = mainTable.NewRow();

                row[0] = "Ashlin®" + list[0];                      // item name
                row[2] = "Ashlin®";                                // brand name
                row[3] = "Ashlin®";                                // manufacturer 
                row[4] = list[24];                                 // external product_id
                row[5] = "UPC";                                    // external product id type
                row[6] = sku;                                      // item sku
                row[7] = "Ashlin®";                                // part number
                row[8] = list[1];                                  // product description
                row[9] = "PartiaUpdate";                           // update delete
                double msrp = Convert.ToDouble(list[25]) * price[0];
                row[10] = Math.Ceiling(msrp * (1 - price[1] / 100)) - (1 - price[2]);     // standard price
                row[11] = "CAD";                                   // currency
                row[12] = "NEW";                                   // condition type
                row[13] = "Brand New";                             // condition note
                row[16] = minorTable.Select("SKU='"+sku+"'")[0][2];// quantity
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
                row[53] = list[8];                                 // bullet point 1
                row[54] = list[9];                                 // bullet point 2
                row[55] = list[10];                                // bullet point 3
                row[56] = list[11];                                // bullet point 4
                row[57] = list[12];                                // bullet point 5
                row[59] = list[26];                                // main image url
                row[60] = getSwatch(sku);                          // swatch image url
                row[61] = list[27];                                // other image url 1
                row[62] = list[28];                                // other image url 2
                row[63] = list[29];                                // other image url 3
                row[64] = list[30];                                // other image url 4
                row[65] = list[31];                                // other image url 5
                row[66] = list[32];                                // other image url 6
                row[67] = list[33];                                // other image url 7
                row[68] = list[34];                                // other image url 8
                row[70] = list[13];                                // package height
                row[71] = "CM";                                    // package height unit of measure
                row[72] = list[14];                                // package length
                row[73] = "CM";                                    // package length unit of measure
                row[74] = list[15];                                // package width
                row[75] = "CM";                                    // package width unit of measure
                row[76] = list[6];                                 // package weight
                row[77] = "GR";                                    // package weight unit of measure
                row[83] = "IN";                                    // country of region
                row[86] = list[35];                                // color name 1
                row[88] = list[35];                                // color map
                row[90] = list[15];                                // outer material type   
                row[93] = list[15];                                // material type
                row[94] = list[15];                                // leather type      
                row[95] = "Leather";                               // fabric type
                row[125] = "All Seasons";                          // seasons
                row[126] = "Casual, Formal, Travel, Executive";    // lifestyle
                row[127] = "ASHLIN";                               // collection name 

                mainTable.Rows.Add(row);
                Progress++;
            }

            // finish loading table
            mainTable.EndLoadData();
            connection.Close();

            return mainTable;
        }

        /* a method that get all the sku that is active */
        protected sealed override string[] getSku()
        {
            // local field for storing data
            List<string> list = new List<string>();

            // connect to database and grab data
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'TRUE' AND SKU_AMAZON_CA != '' ORDER BY SKU_Ashlin", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(reader.GetString(0));
            connection.Close();

            return list.ToArray();
        }
    }
}
