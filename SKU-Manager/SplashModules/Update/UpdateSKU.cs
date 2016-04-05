using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SupportingClasses;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.Update
{
    /*
     * An application module to update SKU to SKU database
     */
    public partial class UpdateSKU : Form
    {
        // fields for storing adding sku data
        private string designServiceCode;
        private string material;
        private string colorCode;
        private string basePrice;
        private string[] location = new string[4];    // [0] for warehouse, [1] for rack, [2] for shelf, [3] for columnIndex
        private string locationFull;
        private string caHts;
        private string usHts;
        private string caDuty;
        private string usDuty;
        private string sku;
        private string ashlin;
        private string magento;
        private string tsc;
        private string costco;
        private string bestbuy;
        private string shopCa;
        private string amazonCa;
        private string amazonCom;
        private string sears;
        private string staples;
        private string walmartCa;
        private string walmartCom;
        private string distributorCentral;
        private string promoMarketing;
        private string wmManufacturer;
        private string wmMerchant;
        private bool onWebsite;
        private bool active = true;    // default set to true
        private string upcCode9;
        private string upcCode10;

        // supporting fields
        private string[] htsList = new string[4];

        // fields for storing uri path and alt text of images
        private readonly ImageSearch imageSearch = new ImageSearch();
        private string[] image = new string[10];
        private string[] group = new string[5];
        private string[] model = new string[5];
        private string[] template = new string[2];
        private TextBox[] imageTextbox = new TextBox[10];
        private TextBox[] groupTextbox = new TextBox[5];
        private TextBox[] modelTextbox = new TextBox[5];
        private TextBox[] templateTextbox = new TextBox[2];
        private string[] imageAlt = new string[10];
        private string[] groupAlt = new string[5];
        private string[] modelAlt = new string[5];

        // fields for comboBoxes
        private readonly ArrayList skuCodeList = new ArrayList();
        private readonly ArrayList warehouseList = new ArrayList();
        private readonly ArrayList rackList = new ArrayList();
        private readonly ArrayList shelfList = new ArrayList();
        private readonly ArrayList columnIndexList = new ArrayList();
        private readonly ArrayList caHtsList = new ArrayList();
        private readonly ArrayList usHtsList = new ArrayList();

        // connection string to the database
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic component */
        public UpdateSKU()
        {
            InitializeComponent();
            skuCodeList.Add("");
            warehouseList.Add("");
            rackList.Add("");
            shelfList.Add("");
            columnIndexList.Add("");
            caHtsList.Add("");
            usHtsList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Comboboxes Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for comboBoxes

            // make combobox for Ashlin SKU
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE SKU_Ashlin is not NULL", connection);  
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                skuCodeList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Warehouse
            command.CommandText = "SELECT Warehouse FROM list_location_warehouses WHERE Warehouse is not NULL";
            reader = command.ExecuteReader();
            while (reader.Read())
                warehouseList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Rack
            command.CommandText = "SELECT Warehouse FROM list_location_racks WHERE Warehouse is not NULL";
            reader = command.ExecuteReader();
            while (reader.Read())
                rackList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Shelf
            command.CommandText = "SELECT Warehouse FROM list_location_shelves WHERE Warehouse is not NULL";
            reader = command.ExecuteReader();
            while (reader.Read())
                shelfList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Column index
            command.CommandText = "SELECT Warehouse FROM list_location_colindex WHERE Warehouse is not NULL";
            reader = command.ExecuteReader();
            while (reader.Read())
                columnIndexList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Canadian HTS
            command.CommandText = "SELECT HTS_CA FROM HTS_CA";
            reader = command.ExecuteReader();
            while (reader.Read())
                caHtsList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for US HTS
            command.CommandText = "SELECT HTS_US FROM HTS_US";
            reader = command.ExecuteReader();
            while (reader.Read())
                usHtsList.Add(reader.GetValue(0));
            reader.Close();
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ashlinSKUCombobox.DataSource = skuCodeList;
            warehouseCombobox.DataSource = warehouseList;
            rackCombobox.DataSource = rackList;
            shelfCombobox.DataSource = shelfList;
            columnIndexCombobox.DataSource = columnIndexList;
            canadianHtsCombobox.DataSource = caHtsList;
            usHtsCombobox.DataSource = usHtsList;

            // initialize some fields 
            designServiceCode = designCodeTextbox.Text;
            material = materialTextbox.Text;
            colorCode = colorCodeTextbox.Text;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void ashlinSKUCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the enability of the controls
            if (ashlinSKUCombobox.SelectedItem.ToString() != "")
            {
                basesPriceTextbox.Enabled = true;
                canadianHtsCombobox.Enabled = true;
                usHtsCombobox.Enabled = true;
                updateSkuDetailButton.Enabled = true;
                updateSkuButton.Enabled = true;
                manualRadioButton.Enabled = true;
                autoRadioButton.Enabled = true;
                autoRadioButton.Checked = true;
                activeCheckbox.Enabled = true;

                // set sku field from the selected item 
                sku = ashlinSKUCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set textboxes to nothing
                designCodeTextbox.Text = "";
                brandTextbox.Text = "";
                designShortDescriptionTextbox.Text = "";
                designServiceFlagTextbox.Text = "";
                materialTextbox.Text = "";
                materialShortDescriptionTextbox.Text = "";
                colorCodeTextbox.Text = "";
                colorShortDescriptionTextbox.Text = "";
                basesPriceTextbox.Text = "";
                caDutyTextbox.Text = "";
                usDutyTextbox.Text = "";
                skuCodeTextbox.Text = "";
                ashlinTextbox.Text = "";
                magentoTextbox.Text = "";
                tscTextbox.Text = "";
                costcoTextbox.Text = "";
                bestbuyTextbox.Text = "";
                shopCaTextbox.Text = "";
                amazonCaTextbox.Text = "";
                amazonComTextbox.Text = "";
                searsTextbox.Text = "";
                staplesTextbox.Text = "";
                walmartCaTextbox.Text = "";
                walmartComTextbox.Text = "";
                distributorCentralTextbox.Text = "";
                promoMarketingTextbox.Text = "";
                wmManufacturerTextbox.Text = "";
                wmMerchantTextbox.Text = "";
                image1Textbox.Text = "";
                image2Textbox.Text = "";
                image3Textbox.Text = "";
                image4Textbox.Text = "";
                image5Textbox.Text = "";
                image6Textbox.Text = "";
                image7Textbox.Text = "";
                image8Textbox.Text = "";
                image9Textbox.Text = "";
                image10Textbox.Text = "";
                group1Textbox.Text = "";
                group2Textbox.Text = "";
                group3Textbox.Text = "";
                group4Textbox.Text = "";
                group5Textbox.Text = "";
                model1Textbox.Text = "";
                model2Textbox.Text = "";
                model3Textbox.Text = "";
                model4Textbox.Text = "";
                model5Textbox.Text = "";

                // set the comboboxes' text to nothing
                warehouseCombobox.Text = "";
                rackCombobox.Text = "";
                shelfCombobox.Text = "";
                columnIndexCombobox.Text = "";
                canadianHtsCombobox.Text = "";
                usHtsCombobox.Text = "";

                basesPriceTextbox.Enabled = false;
                canadianHtsCombobox.Enabled = false;
                usHtsCombobox.Enabled = false;
                activeCheckbox.Checked = false;
                activeCheckbox.Enabled = false;
                onWebsiteCheckbox.Checked = false;
                onWebsiteCheckbox.Enabled = false;
                updateSkuDetailButton.Enabled = false;
                updateSkuButton.Enabled = false;
                manualRadioButton.Enabled = false;
                autoRadioButton.Enabled = false;
                autoRadioButton.Checked = true;
            }

            completeLabel.Visible = false;
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Code, Material_Code, Colour_Code, Base_Price, Location_WH, Location_Rack, Location_Shelf, Location_ColIndex, Active, Ashlin_URL, SKU_MAGENTO, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_SHOP_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_SEARS_CA, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_WALMART_COM, SKU_DistributorCentral, SKU_PromoMarketing, SKU_WALMART_MANUFACTURER, SKU_WALMART_MERCHANT, UPC_Code_9, UPC_Code_10, HTS_CDN, HTS_US, Duty_CDN, Duty_US, "
                                                          + "Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path,  Template_URL_1, Template_URL_2, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path, "
                                                          + "SKU_Website FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            designServiceCode = table.Rows[0][0].ToString();
            material = table.Rows[0][1].ToString();
            colorCode = table.Rows[0][2].ToString();
            basePrice = table.Rows[0][3].ToString();
            location[0] = table.Rows[0][4].ToString();
            location[1] = table.Rows[0][5].ToString();
            location[2] = table.Rows[0][6].ToString();
            location[3] = table.Rows[0][7].ToString();
            active = Convert.ToBoolean(table.Rows[0][8]);
            ashlin = table.Rows[0][9].ToString();
            magento = table.Rows[0][10].ToString();
            tsc = table.Rows[0][11].ToString();
            costco = table.Rows[0][12].ToString();
            bestbuy = table.Rows[0][13].ToString();
            shopCa = table.Rows[0][14].ToString();
            amazonCa = table.Rows[0][15].ToString();
            amazonCom = table.Rows[0][16].ToString();
            sears = table.Rows[0][17].ToString();
            staples = table.Rows[0][18].ToString();
            walmartCa = table.Rows[0][19].ToString();
            walmartCom = table.Rows[0][20].ToString();
            distributorCentral = table.Rows[0][21].ToString();
            promoMarketing = table.Rows[0][22].ToString();
            wmManufacturer = table.Rows[0][23].ToString();
            wmMerchant = table.Rows[0][24].ToString();
            upcCode9 = table.Rows[0][25].ToString();
            upcCode10 = table.Rows[0][26].ToString();
            caHts = table.Rows[0][27].ToString();
            usHts = table.Rows[0][28].ToString();
            caDuty = table.Rows[0][29].ToString();
            usDuty = table.Rows[0][30].ToString();
            image[0] = table.Rows[0][31].ToString();
            image[1] = table.Rows[0][32].ToString();
            image[2] = table.Rows[0][33].ToString();
            image[3] = table.Rows[0][34].ToString();
            image[4] = table.Rows[0][35].ToString();
            image[5] = table.Rows[0][36].ToString();
            image[6] = table.Rows[0][37].ToString();
            image[7] = table.Rows[0][38].ToString();
            image[8] = table.Rows[0][39].ToString();
            image[9] = table.Rows[0][40].ToString();
            group[0] = table.Rows[0][41].ToString();
            group[1] = table.Rows[0][42].ToString();
            group[2] = table.Rows[0][43].ToString();
            group[3] = table.Rows[0][44].ToString();
            group[4] = table.Rows[0][45].ToString();
            model[0] = table.Rows[0][46].ToString();
            model[1] = table.Rows[0][47].ToString();
            model[2] = table.Rows[0][48].ToString();
            model[3] = table.Rows[0][49].ToString();
            model[4] = table.Rows[0][50].ToString();
            template[0] = table.Rows[0][51].ToString();
            template[1] = table.Rows[0][52].ToString();
            imageAlt[0] = table.Rows[0][53].ToString();
            imageAlt[1] = table.Rows[0][54].ToString();
            imageAlt[2] = table.Rows[0][55].ToString();
            imageAlt[3] = table.Rows[0][56].ToString();
            imageAlt[4] = table.Rows[0][57].ToString();
            imageAlt[5] = table.Rows[0][58].ToString();
            imageAlt[6] = table.Rows[0][59].ToString();
            imageAlt[7] = table.Rows[0][60].ToString();
            imageAlt[8] = table.Rows[0][61].ToString();
            imageAlt[9] = table.Rows[0][62].ToString();
            groupAlt[0] = table.Rows[0][63].ToString();
            groupAlt[1] = table.Rows[0][64].ToString();
            groupAlt[2] = table.Rows[0][65].ToString();
            groupAlt[3] = table.Rows[0][66].ToString();
            groupAlt[4] = table.Rows[0][67].ToString();
            modelAlt[0] = table.Rows[0][68].ToString();
            modelAlt[1] = table.Rows[0][69].ToString();
            modelAlt[2] = table.Rows[0][70].ToString();
            modelAlt[3] = table.Rows[0][71].ToString();
            modelAlt[4] = table.Rows[0][72].ToString();
            onWebsite = Convert.ToBoolean(table.Rows[0][73]);
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            designCodeTextbox.Text = designServiceCode;
            upcLabel.Text = upcCode9;
            materialTextbox.Text = material;
            colorCodeTextbox.Text = colorCode;
            basesPriceTextbox.Text = basePrice;
            warehouseCombobox.Text = location[0];
            rackCombobox.Text = location[1];
            shelfCombobox.Text = location[2];
            columnIndexCombobox.Text = location[3];
            canadianHtsCombobox.Text = caHts;
            usHtsCombobox.Text = usHts;
            caDutyTextbox.Text = caDuty;
            usDutyTextbox.Text = usDuty;
            skuCodeTextbox.Text = ashlinSKUCombobox.SelectedItem.ToString();
            activeCheckbox.Checked = active;
            onWebsiteCheckbox.Checked = onWebsite;
            ashlinTextbox.Text = ashlin;
            magentoTextbox.Text = magento;
            tscTextbox.Text = tsc;
            costcoTextbox.Text = costco;
            bestbuyTextbox.Text = bestbuy;
            shopCaTextbox.Text = shopCa;
            amazonCaTextbox.Text = amazonCa;
            amazonComTextbox.Text = amazonCom;
            searsTextbox.Text = sears;
            staplesTextbox.Text = staples;
            walmartCaTextbox.Text = walmartCa;
            walmartComTextbox.Text = walmartCom;
            distributorCentralTextbox.Text = distributorCentral;
            promoMarketingTextbox.Text = promoMarketing;
            wmManufacturerTextbox.Text = wmManufacturer;
            wmMerchantTextbox.Text = wmMerchant;
            image1Textbox.Text = image[0];
            image2Textbox.Text = image[1];
            image3Textbox.Text = image[2];
            image4Textbox.Text = image[3];
            image5Textbox.Text = image[4];
            image6Textbox.Text = image[5];
            image7Textbox.Text = image[6];
            image8Textbox.Text = image[7];
            image9Textbox.Text = image[8];
            image10Textbox.Text = image[9];
            group1Textbox.Text = group[0];
            group2Textbox.Text = group[1];
            group3Textbox.Text = group[2];
            group4Textbox.Text = group[3];
            group5Textbox.Text = group[4];
            model1Textbox.Text = model[0];
            model2Textbox.Text = model[1];
            model3Textbox.Text = model[2];
            model4Textbox.Text = model[3];
            model5Textbox.Text = model[4];
            template1Textbox.Text = template[0];
            template2Textbox.Text = template[1];
        }
        #endregion

        #region Left and Right Buttons
        /* the event for left and right button click that change the index of comboboxes */
        private void leftButton_Click(object sender, EventArgs e)
        {
            int i = ashlinSKUCombobox.SelectedIndex;
            if (i > 0)
                i--;
            ashlinSKUCombobox.SelectedIndex = i;
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            int i = ashlinSKUCombobox.SelectedIndex;
            if (i < skuCodeList.Count - 1)
                i++;
            ashlinSKUCombobox.SelectedIndex = i;
        }
        #endregion

        /* the event for design service code textbox text changed that show information about the design and the change in skuCode textbox */
        private void designCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (designCodeTextbox.Text == "") return;

            designServiceCode = designCodeTextbox.Text;
        
            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentDesignCode = designCodeTextbox.Text;

            // connect to database to get the info about this design code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Brand, Short_Description, Design_Service_Flag, GiftBox FROM master_Design_Attributes WHERE Design_Service_Code = \'" + currentDesignCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            brandTextbox.Text = table.Rows[0][0].ToString();
            designShortDescriptionTextbox.Text = table.Rows[0][1].ToString();
            designServiceFlagTextbox.Text = table.Rows[0][2].ToString();
            giftCheckbox.Checked = table.Rows[0][3].ToString() == "True" ? true : false;
        }

        /* the event for material textbox text changed that show the information about the selected item */
        private void materialTextbox_TextChanged(object sender, EventArgs e)
        {
            if (materialTextbox.Text == "") return;

            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentMaterial = materialTextbox.Text;

            // connect to database to get the info about this material code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Description_Short FROM ref_Materials WHERE Material_Code = \'" + currentMaterial + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            materialShortDescriptionTextbox.Text = table.Rows[0][0].ToString();
        }

        /* the event for color textbox text changed that show the information about the selected item */
        private void colorCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (colorCodeTextbox.Text == "") return;

            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentColorCode = colorCodeTextbox.Text;

            // connect to database to get the info about this color code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + currentColorCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            colorShortDescriptionTextbox.Text = table.Rows[0][0].ToString();
        }

        /* the event for design service flag textbox text change that will determine some controls' enabilibty */
        private void designServiceFlagTextbox_TextChanged(object sender, EventArgs e)
        {
            if (designServiceFlagTextbox.Text == "Service")
            {
                warehouseCombobox.Enabled = false;
                rackCombobox.Enabled = false;
                shelfCombobox.Enabled = false;
                columnIndexCombobox.Enabled = false;
                ashlinTextbox.Enabled = false;
                magentoTextbox.Enabled = false;
                tscTextbox.Enabled = false;
                costcoTextbox.Enabled = false;
                bestbuyTextbox.Enabled = false;
                shopCaTextbox.Enabled = false;
                amazonCaTextbox.Enabled = false;
                amazonComTextbox.Enabled = false;
                searsTextbox.Enabled = false;
                staplesTextbox.Enabled = false;
                walmartCaTextbox.Enabled = false;
                walmartComTextbox.Enabled = false;
                distributorCentralTextbox.Enabled = false;
                promoMarketingTextbox.Enabled = false;
                wmManufacturerTextbox.Enabled = false;
                wmMerchantTextbox.Enabled = false;
            }
            else
            {
                warehouseCombobox.Enabled = true;
                rackCombobox.Enabled = true;
                shelfCombobox.Enabled = true;
                columnIndexCombobox.Enabled = true;
                ashlinTextbox.Enabled = true;
                magentoTextbox.Enabled = true;
                tscTextbox.Enabled = true;
                costcoTextbox.Enabled = true;
                bestbuyTextbox.Enabled = true;
                shopCaTextbox.Enabled = true;
                amazonCaTextbox.Enabled = true;
                amazonComTextbox.Enabled = true;
                searsTextbox.Enabled = true;
                staplesTextbox.Enabled = true;
                walmartCaTextbox.Enabled = true;
                walmartComTextbox.Enabled = true;
                distributorCentralTextbox.Enabled = true;
                promoMarketingTextbox.Enabled = true;
                wmManufacturerTextbox.Enabled = true;
                wmMerchantTextbox.Enabled = true;
            }
        }

        #region Taxes Comboboxes Event
        /* the event for canadian and us hts combobox selected item changed that show the information about the selected item */
        private void canadianHtsCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // down to business -> search for duty
            if (canadianHtsCombobox.SelectedItem.ToString() != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT CA_Duty FROM HTS_CA WHERE HTS_CA = \'" + canadianHtsCombobox.SelectedItem + "\';", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    caDutyTextbox.Text = reader.GetDecimal(0).ToString();
                }
            }
            else
                caDutyTextbox.Text = "";
        }
        private void usHtsCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usHtsCombobox.SelectedItem.ToString() != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand commmand = new SqlCommand("SELECT US_Duty FROM HTS_US WHERE HTS_US = \'" + usHtsCombobox.SelectedItem + "\';", connection);
                    connection.Open();
                    SqlDataReader reader = commmand.ExecuteReader();
                    reader.Read();
                    usDutyTextbox.Text = reader.GetDecimal(0).ToString();
                }
            }
            else
                usDutyTextbox.Text = "";
        }
        #endregion

        /* active checkbox checked changed event that determine if the product can be on website or not */
        private void activeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (activeCheckbox.Checked)
            {
                onWebsiteCheckbox.Checked = onWebsite;
                onWebsiteCheckbox.Enabled = true;
            }
            else
            {
                onWebsiteCheckbox.Checked = false;
                onWebsiteCheckbox.Enabled = false;
            }
        }

        /* the event for update sku details button click that only update the sku details */
        private void updateSkuDetailButton_Click(object sender, EventArgs e)
        {
            completeLabel.Visible = false;

            // get data from user input
            location[0] = warehouseCombobox.SelectedItem.ToString();
            location[1] = rackCombobox.SelectedItem.ToString();
            location[2] = shelfCombobox.SelectedItem.ToString();
            location[3] = columnIndexCombobox.SelectedItem.ToString();
            caHts = canadianHtsCombobox.SelectedItem.ToString();
            usHts = usHtsCombobox.SelectedItem.ToString();
            basePrice = basesPriceTextbox.Text;
            locationFull = "WH" + location[0] + "-R" + location[1] + "-S" + location[2] + "-C" + location[3];
            caDuty = caDutyTextbox.Text;
            usDuty = usDutyTextbox.Text;
            sku = skuCodeTextbox.Text;
            onWebsite = onWebsiteCheckbox.Checked;
            active = activeCheckbox.Checked;

            // connect to database and update the sku
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command;
                    if (!caHts.Equals("") && !usHts.Equals(""))
                    {

                        command = new SqlCommand("UPDATE master_SKU_Attributes SET Location_WH = \'" + location[0] + "\', Location_Rack = \'" + location[1] + "\', Location_Shelf = \'" + location[2] + "\', Location_ColIndex = \'" + location[3] + "\', Location_Full = \'" + locationFull + "\', Base_Price = \'" + basePrice + "\', HTS_CDN = \'" + caHts + "\', HTS_US = \'" + usHts + "\', Duty_CDN = " + caDuty + ", Duty_US = " + usDuty + ", Date_Updated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', "
                                               + "SKU_Website = \'" + onWebsite + "\', Active = \'" + active + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    }
                    else
                    {
                        command = new SqlCommand("UPDATE master_SKU_Attributes SET Location_WH = \'" + location[0] + "\', Location_Rack = \'" + location[1] + "\', Location_Shelf = \'" + location[2] + "\', Location_ColIndex = \'" + location[3] + "\', Location_Full = \'" + locationFull + "\', Base_Price = \'" + basePrice + "\', Date_Updated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', "
                                               + "SKU_Website = \'" + onWebsite + "\', Active = \'" + active + "\' WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happen during database updating: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            completeLabel.Visible = true;
        }

        #region Manual Auto Update
        /* the event for radio buttons checked change that determine if user update the image path manually or computer does it automatically */
        private void manualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!manualRadioButton.Checked) return;
            image1Textbox.Enabled = true;
            image2Textbox.Enabled = true;
            image3Textbox.Enabled = true;
            image4Textbox.Enabled = true;
            image5Textbox.Enabled = true;
            image6Textbox.Enabled = true;
            image7Textbox.Enabled = true;
            image8Textbox.Enabled = true;
            image9Textbox.Enabled = true;
            image10Textbox.Enabled = true;
            group1Textbox.Enabled = true;
            group2Textbox.Enabled = true;
            group3Textbox.Enabled = true;
            group4Textbox.Enabled = true;
            group5Textbox.Enabled = true;
            model1Textbox.Enabled = true;
            model2Textbox.Enabled = true;
            model3Textbox.Enabled = true;
            model4Textbox.Enabled = true;
            model5Textbox.Enabled = true;
            template1Textbox.Enabled = true;
            template2Textbox.Enabled = true;
            image1AltButton.Enabled = true;
            image2AltButton.Enabled = true;
            image3AltButton.Enabled = true;
            image4AltButton.Enabled = true;
            image5AltButton.Enabled = true;
            image6AltButton.Enabled = true;
            image7AltButton.Enabled = true;
            image8AltButton.Enabled = true;
            image9AltButton.Enabled = true;
            image10AltButton.Enabled = true;
            group1AltButton.Enabled = true;
            group2AltButton.Enabled = true;
            group3AltButton.Enabled = true;
            group4AltButton.Enabled = true;
            group5AltButton.Enabled = true;
            model1AltButton.Enabled = true;
            model2AltButton.Enabled = true;
            model3AltButton.Enabled = true;
            model4AltButton.Enabled = true;
            model5AltButton.Enabled = true;
        }
        private void autoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!autoRadioButton.Checked) return;
            image1Textbox.Enabled = false;
            image2Textbox.Enabled = false;
            image3Textbox.Enabled = false;
            image4Textbox.Enabled = false;
            image5Textbox.Enabled = false;
            image6Textbox.Enabled = false;
            image7Textbox.Enabled = false;
            image8Textbox.Enabled = false;
            image9Textbox.Enabled = false;
            image10Textbox.Enabled = false;
            group1Textbox.Enabled = false;
            group2Textbox.Enabled = false;
            group3Textbox.Enabled = false;
            group4Textbox.Enabled = false;
            group5Textbox.Enabled = false;
            model1Textbox.Enabled = false;
            model2Textbox.Enabled = false;
            model3Textbox.Enabled = false;
            model4Textbox.Enabled = false;
            model5Textbox.Enabled = false;
            template1Textbox.Enabled = false;
            template2Textbox.Enabled = false;
            image1AltButton.Enabled = false;
            image2AltButton.Enabled = false;
            image3AltButton.Enabled = false;
            image4AltButton.Enabled = false;
            image5AltButton.Enabled = false;
            image6AltButton.Enabled = false;
            image7AltButton.Enabled = false;
            image8AltButton.Enabled = false;
            image9AltButton.Enabled = false;
            image10AltButton.Enabled = false;
            group1AltButton.Enabled = false;
            group2AltButton.Enabled = false;
            group3AltButton.Enabled = false;
            group4AltButton.Enabled = false;
            group5AltButton.Enabled = false;
            model1AltButton.Enabled = false;
            model2AltButton.Enabled = false;
            model3AltButton.Enabled = false;
            model4AltButton.Enabled = false;
            model5AltButton.Enabled = false;
        }
        #endregion

        #region Update Button Click
        /* the event for update sku button click */
        private void updateSkuButton_Click(object sender, EventArgs e)
        {
            // disable radio buttons
            manualRadioButton.Enabled = false;
            autoRadioButton.Enabled = false;

            // initialize location field and HTS
            location[0] = warehouseCombobox.SelectedItem.ToString();
            location[1] = rackCombobox.SelectedItem.ToString();
            location[2] = shelfCombobox.SelectedItem.ToString();
            location[3] = columnIndexCombobox.SelectedItem.ToString();
            caHts = canadianHtsCombobox.SelectedItem.ToString();
            usHts = usHtsCombobox.SelectedItem.ToString();
            onWebsite = onWebsiteCheckbox.Checked;

            // call background worker
            if (autoRadioButton.Checked)     // case if auto image update
            {
                if (!backgroundWorkerImagePath.IsBusy)
                    backgroundWorkerImagePath.RunWorkerAsync();
            }
            else    // case if manual update
            {
                if (!backgroundWorkerUpdate.IsBusy)
                    backgroundWorkerUpdate.RunWorkerAsync();
            }
        }
        /* case 1 -> auto update */
        private void backgroundWorkerImagePath_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 10%
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerImagePath.ReportProgress(i);
            }

            // get the sku text and initilize sku field
            sku = skuCodeTextbox.Text;

            // search images and generate uri that assign to image fields
            int index = 0;
            string[] imageCopy = imageSearch.getImageUri(sku);
            foreach (string uri in imageCopy)    // get the value that exist
            {
                image[index] = uri;
                index++;
            }
            // add the missing value 
            for (int i = index; i < 10; i++)
                image[i] = "";

            index = 0;
            string[] groupCopy = imageSearch.getGroupUri(sku);
            foreach (string uri in groupCopy)    // get the value that exist
            {
                group[index] = uri;
                index++;
            }
            // add the missing value
            for (int i = index; i < 5; i++)
                group[i] = "";

            index = 0;
            string[] modelCopy = imageSearch.getModelUri(sku);
            foreach (string uri in modelCopy)    // get the value that exist
            {
                model[index] = uri;
                index++;
            }
            // add the missing value
            for (int i = index; i < 5; i++)
                model[i] = "";

            index = 0;
            string[] templateCopy = imageSearch.getTemplateUri(sku);
            foreach (string uri in templateCopy)    // get the value that exist
            {
                template[index] = uri;
                index++;
            }
            // add the missing value
            for (int i = index; i < 2; i++)
                template[i] = "";

            // simulate progress 10% ~ 20%
            for (int i = 10; i <= 20; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerImagePath.ReportProgress(i);
            }

            // assign textboxes to textbox holders
            imageTextbox[0] = image1Textbox;
            imageTextbox[1] = image2Textbox;
            imageTextbox[2] = image3Textbox;
            imageTextbox[3] = image4Textbox;
            imageTextbox[4] = image5Textbox;
            imageTextbox[5] = image6Textbox;
            imageTextbox[6] = image7Textbox;
            imageTextbox[7] = image8Textbox;
            imageTextbox[8] = image9Textbox;
            imageTextbox[9] = image10Textbox;
            groupTextbox[0] = group1Textbox;
            groupTextbox[1] = group2Textbox;
            groupTextbox[2] = group3Textbox;
            groupTextbox[3] = group4Textbox;
            groupTextbox[4] = group5Textbox;
            modelTextbox[0] = model1Textbox;
            modelTextbox[1] = model2Textbox;
            modelTextbox[2] = model3Textbox;
            modelTextbox[3] = model4Textbox;
            modelTextbox[4] = model5Textbox;
            templateTextbox[0] = template1Textbox;
            templateTextbox[1] = template2Textbox;

            // assgin alt text to image
            index = 0;
            for (; index < image.Length; index++)
            {
                if (image[index] == "")
                    imageAlt[index] = "";
                else
                    imageAlt[index] = AltText.getAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // assgin alt text to image
            index = 0;
            for (; index < group.Length; index++)
            {
                if (group[index] == "")
                    groupAlt[index] = "";
                else
                    groupAlt[index] = "Group " + AltText.getAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // assgin alt text to image
            index = 0;
            for (; index < model.Length; index++)
            {
                if (model[index] == "")
                    modelAlt[index] = "";
                else
                    modelAlt[index] = "Model " + AltText.getAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // simulate progress 20% ~ 30%
            for (int i = 20; i <= 30; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerImagePath.ReportProgress(i);
            }
        }
        private void backgroundWorkerImagePath_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void backgroundWorkerImagePath_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // assign image uri to image textboxes
            for (int i = 0; i < image.Length; i++)
                imageTextbox[i].Text = image[i];

            // assign image uri to group textboxes
            for (int i = 0; i < group.Length; i++)
                groupTextbox[i].Text = group[i];

            // assign image uri to model textboxes
            for (int i = 0; i < model.Length; i++)
                modelTextbox[i].Text = model[i];

            // assign image uri to template textboxes
            for (int i = 0; i < template.Length; i++)
                templateTextbox[i].Text = template[i];

            // call background worker
            if (!backgroundWorkerUpdate.IsBusy)
                backgroundWorkerUpdate.RunWorkerAsync();
        }
        /* always need to do this */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            bool auto = autoRadioButton.Checked;

            if (auto)
            {
                // simulate progress 30% ~ 50%
                for (int i = 30; i <= 50; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }
            }
            else
            {
                // simulate progress 1% ~ 30%
                for (int i = 1; i <= 30; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }
            }

            // get data from user input
            basePrice = basesPriceTextbox.Text;
            locationFull = "WH" + location[0] + "-R" + location[1] + "-S" + location[2] + "-C" + location[3];
            caDuty = caDutyTextbox.Text;
            usDuty = usDutyTextbox.Text;
            sku = skuCodeTextbox.Text;
            ashlin = ashlinTextbox.Text.Replace("'", "''");
            magento = magentoTextbox.Text.Replace("'", "''");
            tsc = tscTextbox.Text.Replace("'", "''");
            costco = costcoTextbox.Text.Replace("'", "''");
            bestbuy = bestbuyTextbox.Text.Replace("'", "''");
            shopCa = shopCaTextbox.Text.Replace("'", "''");
            amazonCa = amazonCaTextbox.Text.Replace("'", "''");
            amazonCom = amazonComTextbox.Text.Replace("'", "''");
            sears = searsTextbox.Text.Replace("'", "''");
            staples = staplesTextbox.Text.Replace("'", "''");
            walmartCa = walmartCaTextbox.Text.Replace("'", "''");
            walmartCom = walmartComTextbox.Text.Replace("'", "''");
            distributorCentral = distributorCentralTextbox.Text.Replace("'", "''");
            promoMarketing = promoMarketingTextbox.Text.Replace("'", "''");
            wmManufacturer = wmManufacturerTextbox.Text.Replace("'", "''");
            wmMerchant = wmMerchantTextbox.Text.Replace("'", "''");
            image[0] = image1Textbox.Text;
            image[1] = image2Textbox.Text;
            image[2] = image3Textbox.Text;
            image[3] = image4Textbox.Text;
            image[4] = image5Textbox.Text;
            image[5] = image6Textbox.Text;
            image[6] = image7Textbox.Text;
            image[7] = image8Textbox.Text;
            image[8] = image9Textbox.Text;
            image[9] = image10Textbox.Text;
            group[0] = group1Textbox.Text;
            group[1] = group2Textbox.Text;
            group[2] = group3Textbox.Text;
            group[3] = group4Textbox.Text;
            group[4] = group5Textbox.Text;
            model[0] = model1Textbox.Text;
            model[1] = model2Textbox.Text;
            model[2] = model3Textbox.Text;
            model[3] = model4Textbox.Text;
            model[4] = model5Textbox.Text;
            template[0] = template1Textbox.Text;
            template[1] = template2Textbox.Text;
            active = activeCheckbox.Checked;

            if (auto)
            {
                // simulate progress 50% ~ 70%
                for (int i = 50; i <= 70; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }
            }
            else
            {
                // simulate progress 30% ~ 60%
                for (int i = 30; i <= 70; i++)
                {
                    Thread.Sleep(25);
                    backgroundWorkerUpdate.ReportProgress(i);
                }
            }

            // adding upc image
            if (upcCode9.Length < 11 && upcCode10.Length < 12)
            {
                UPC upcCode = new UPC();
                upcCode9 = upcCode.getUPC();
                upcCode10 = upcCode.getUPC10(upcCode9);
            }
            ImageReplace imageReplace = new ImageReplace();
            imageReplace.addUPC(sku, upcCode9);
            imageReplace.addUPC(sku, upcCode10);

            try
            {
                // connect to database and update the sku
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command;
                    if (!caHts.Equals("") && !usHts.Equals(""))
                    {
                        command = new SqlCommand("UPDATE master_SKU_Attributes SET Ashlin_URL = \'" + ashlin + "\', SKU_MAGENTO = \'" + magento + "\', SKU_SEARS_CA = \'" + sears + "\', SKU_TSC_CA = \'" + tsc + "\', SKU_COSTCO_CA = \'" + costco + "\', SKU_BESTBUY_CA = \'" + bestbuy + "\', SKU_AMAZON_CA = \'" + amazonCa + "\', SKU_AMAZON_COM = \'" + amazonCom + "\', SKU_SHOP_CA = \'" + shopCa + "\', SKU_STAPLES_CA = \'" + staples + "\', SKU_WALMART_CA = \'" + walmartCa + "\', SKU_WALMART_COM = \'" + walmartCom + "\', SKU_DistributorCentral = \'" + distributorCentral + "\', SKU_PromoMarketing = \'" + promoMarketing + "\', SKU_WALMART_MANUFACTURER = \'" + wmManufacturer + "\', SKU_WALMART_MERCHANT = \'" + wmMerchant + "\', Location_WH = \'" + location[0] + "\', Location_Rack = \'" + location[1] + "\', Location_Shelf = \'" + location[2] + "\', Location_ColIndex = \'" + location[3] + "\', Location_Full = \'" + locationFull + "\', Base_Price = \'" + basePrice + "\', UPC_Code_9 = \'" + upcCode9 + "\', UPC_Code_10 = \'" + upcCode10 + "\', HTS_CDN = \'" + caHts + "\', HTS_US = \'" + usHts + "\', Duty_CDN = " + caDuty + ", Duty_US = " + usDuty + ", Date_Updated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', SKU_Website = \'" + onWebsite + "\', Active = \'" + active + "\', "
                                               + "Image_1_Path = \'" + image[0] + "\', Image_2_Path = \'" + image[1] + "\', Image_3_Path = \'" + image[2] + "\', Image_4_Path = \'" + image[3] + "\', Image_5_Path = \'" + image[4] + "\', Image_6_Path = \'" + image[5] + "\', Image_7_Path = \'" + image[6] + "\', Image_8_Path = \'" + image[7] + "\', Image_9_Path = \'" + image[8] + "\', Image_10_Path = \'" + image[9] + "\', Image_Group_1_Path = \'" + group[0] + "\', Image_Group_2_Path = \'" + group[1] + "\', Image_Group_3_Path = \'" + group[2] + "\', Image_Group_4_Path = \'" + group[3] + "\', Image_Group_5_Path = \'" + group[4] + "\', Image_Model_1_Path = \'" + model[0] + "\', Image_Model_2_Path = \'" + model[1] + "\', Image_Model_3_Path = \'" + model[2] + "\', Image_Model_4_Path = \'" + model[3] + "\', Image_Model_5_Path = \'" + model[4] + "\', Alt_Text_Image_1_Path = \'" + imageAlt[0].Replace("'", "''") + "\', Alt_Text_Image_2_Path = \'" + imageAlt[1].Replace("'", "''") + "\', Alt_Text_Image_3_Path = \'" + imageAlt[2].Replace("'", "''") + "\', Alt_Text_Image_4_Path = \'" + imageAlt[3].Replace("'", "''") + "\', Alt_Text_Image_5_Path = \'" + imageAlt[4].Replace("'", "''") + "\', Alt_Text_Image_6_Path = \'" + imageAlt[5].Replace("'", "''") + "\', Alt_Text_Image_7_Path = \'" + imageAlt[6].Replace("'", "''") + "\', Alt_Text_Image_8_Path = \'" + imageAlt[7].Replace("'", "''") + "\', Alt_Text_Image_9_Path = \'" + imageAlt[8].Replace("'", "''") + "\', Alt_Text_Image_10_Path = \'" + imageAlt[9].Replace("'", "''") + "\', Alt_Text_Image_Group_1_Path = \'" + groupAlt[0].Replace("'", "''") + "\', Alt_Text_Image_Group_2_Path = \'" + groupAlt[1].Replace("'", "''") + "\', Alt_Text_Image_Group_3_Path = \'" + groupAlt[2].Replace("'", "''") + "\', Alt_Text_Image_Group_4_Path = \'" + groupAlt[3].Replace("'", "''") + "\', Alt_Text_Image_Group_5_Path = \'" + groupAlt[4].Replace("'", "''") + "\', Alt_Text_Image_Model_1_Path = \'" + modelAlt[0].Replace("'", "''") + "\', Alt_Text_Image_Model_2_Path = \'" + modelAlt[1].Replace("'", "''") + "\', Alt_Text_Image_Model_3_Path = \'" + modelAlt[2].Replace("'", "''") + "\', Alt_Text_Image_Model_4_Path = \'" + modelAlt[3].Replace("'", "''") + "\', Alt_Text_Image_Model_5_Path = \'" + modelAlt[4].Replace("'", "''") + "\', Template_URL_1 = \'" + template[0] + "\', Template_URL_2 = \'" + template[1] + "\' "
                                               + "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    }
                    else
                    {
                        command = new SqlCommand("UPDATE master_SKU_Attributes SET Ashlin_URL = \'" + ashlin + "\', SKU_MAGENTO = \'" + magento + "\', SKU_SEARS_CA = \'" + sears + "\', SKU_TSC_CA = \'" + tsc + "\', SKU_COSTCO_CA = \'" + costco + "\', SKU_BESTBUY_CA = \'" + bestbuy + "\', SKU_AMAZON_CA = \'" + amazonCa + "\', SKU_AMAZON_COM = \'" + amazonCom + "\', SKU_SHOP_CA = \'" + shopCa + "\', SKU_STAPLES_CA = \'" + staples + "\', SKU_WALMART_CA = \'" + walmartCa + "\', SKU_WALMART_COM = \'" + walmartCom + "\', SKU_DistributorCentral = \'" + distributorCentral + "\', SKU_PromoMarketing = \'" + promoMarketing + "\', SKU_WALMART_MANUFACTURER = \'" + wmManufacturer + "\', SKU_WALMART_MERCHANT = \'" + wmMerchant + "\', Location_WH = \'" + location[0] + "\', Location_Rack = \'" + location[1] + "\', Location_Shelf = \'" + location[2] + "\', Location_ColIndex = \'" + location[3] + "\', Location_Full = \'" + locationFull + "\', Base_Price = \'" + basePrice + "\', UPC_Code_9 = \'" + upcCode9 + "\', UPC_Code_10 = \'" + upcCode10 + "\', Date_Updated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', SKU_Website = \'" + onWebsite + "\', Active = \'" + active + "\', "
                                              + "Image_1_Path = \'" + image[0] + "\', Image_2_Path = \'" + image[1] + "\', Image_3_Path = \'" + image[2] + "\', Image_4_Path = \'" + image[3] + "\', Image_5_Path = \'" + image[4] + "\', Image_6_Path = \'" + image[5] + "\', Image_7_Path = \'" + image[6] + "\', Image_8_Path = \'" + image[7] + "\', Image_9_Path = \'" + image[8] + "\', Image_10_Path = \'" + image[9] + "\', Image_Group_1_Path = \'" + group[0] + "\', Image_Group_2_Path = \'" + group[1] + "\', Image_Group_3_Path = \'" + group[2] + "\', Image_Group_4_Path = \'" + group[3] + "\', Image_Group_5_Path = \'" + group[4] + "\', Image_Model_1_Path = \'" + model[0] + "\', Image_Model_2_Path = \'" + model[1] + "\', Image_Model_3_Path = \'" + model[2] + "\', Image_Model_4_Path = \'" + model[3] + "\', Image_Model_5_Path = \'" + model[4] + "\', Alt_Text_Image_1_Path = \'" + imageAlt[0].Replace("'", "''") + "\', Alt_Text_Image_2_Path = \'" + imageAlt[1].Replace("'", "''") + "\', Alt_Text_Image_3_Path = \'" + imageAlt[2].Replace("'", "''") + "\', Alt_Text_Image_4_Path = \'" + imageAlt[3].Replace("'", "''") + "\', Alt_Text_Image_5_Path = \'" + imageAlt[4].Replace("'", "''") + "\', Alt_Text_Image_6_Path = \'" + imageAlt[5].Replace("'", "''") + "\', Alt_Text_Image_7_Path = \'" + imageAlt[6].Replace("'", "''") + "\', Alt_Text_Image_8_Path = \'" + imageAlt[7].Replace("'", "''") + "\', Alt_Text_Image_9_Path = \'" + imageAlt[8].Replace("'", "''") + "\', Alt_Text_Image_10_Path = \'" + imageAlt[9].Replace("'", "''") + "\', Alt_Text_Image_Group_1_Path = \'" + groupAlt[0].Replace("'", "''") + "\', Alt_Text_Image_Group_2_Path = \'" + groupAlt[1].Replace("'", "''") + "\', Alt_Text_Image_Group_3_Path = \'" + groupAlt[2].Replace("'", "''") + "\', Alt_Text_Image_Group_4_Path = \'" + groupAlt[3].Replace("'", "''") + "\', Alt_Text_Image_Group_5_Path = \'" + groupAlt[4].Replace("'", "''") + "\', Alt_Text_Image_Model_1_Path = \'" + modelAlt[0].Replace("'", "''") + "\', Alt_Text_Image_Model_2_Path = \'" + modelAlt[1].Replace("'", "''") + "\', Alt_Text_Image_Model_3_Path = \'" + modelAlt[2].Replace("'", "''") + "\', Alt_Text_Image_Model_4_Path = \'" + modelAlt[3].Replace("'", "''") + "\', Alt_Text_Image_Model_5_Path = \'" + modelAlt[4].Replace("'", "''") + "\', Template_URL_1 = \'" + template[0] + "\', Template_URL_2 = \'" + template[1] + "\' "
                                              + "WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happen during database updating: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // simulate progress 60% ~ 100%
            for (int i = 70; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }
        }
        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // enable radio buttons
            manualRadioButton.Enabled = true;
            autoRadioButton.Enabled = true;
        }
        private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active Inactive Button Click Event
        /* the event for active list button that open the table of active sku list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new ActiveSKUList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new InactiveSKUList().ShowDialog(this);
        }
        #endregion

        #region Image Alt
        /* the event when image alt button is clicked -> edit alt text and return it */
        private void image1AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[0]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[0] = newAlt.altText;
        }
        private void image2AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[1]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[1] = newAlt.altText;
        }
        private void image3AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[2]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[2] = newAlt.altText;
        }
        private void image4AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[3]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[3] = newAlt.altText;
        }
        private void image5AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[4]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[4] = newAlt.altText;
        }
        private void image6AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[5]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[5] = newAlt.altText;
        }
        private void image7AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[6]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[6] = newAlt.altText;
        }
        private void image8AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[7]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[7] = newAlt.altText;
        }
        private void image9AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[8]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[8] = newAlt.altText;
        }
        private void image10AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(imageAlt[9]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                imageAlt[9] = newAlt.altText;
        }
        #endregion

        #region Group Alt
        /* the event when group image alt button is clicked -> edit alt text and return it */
        private void group1AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(groupAlt[0]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                groupAlt[0] = newAlt.altText;
        }
        private void group2AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(groupAlt[1]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                groupAlt[1] = newAlt.altText;
        }
        private void group3AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(groupAlt[2]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                groupAlt[2] = newAlt.altText;
        }
        private void group4AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(groupAlt[3]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                groupAlt[3] = newAlt.altText;
        }
        private void group5AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(groupAlt[4]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                groupAlt[4] = newAlt.altText;
        }
        #endregion

        #region Model Alt
        /* the event when model image alt button is clicked -> edit alt text and return it */
        private void model1AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(modelAlt[0]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                modelAlt[0] = newAlt.altText;
        }
        private void model2AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(modelAlt[1]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                modelAlt[1] = newAlt.altText;
        }
        private void model3AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(modelAlt[2]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                modelAlt[2] = newAlt.altText;
        }
        private void model4AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(modelAlt[3]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                modelAlt[3] = newAlt.altText;
        }
        private void model5AltButton_Click(object sender, EventArgs e)
        {
            EditAlt newAlt = new EditAlt(modelAlt[4]);
            newAlt.ShowDialog(this);

            if (newAlt.DialogResult == DialogResult.OK)
                modelAlt[4] = newAlt.altText;
        }
        #endregion
    }
}
