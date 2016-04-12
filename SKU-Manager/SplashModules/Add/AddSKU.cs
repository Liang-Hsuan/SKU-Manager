using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.Add
{
    /*
     * An application module to add new SKU to SKU database
     */
    public partial class AddSKU : Form
    {
        // fields for storing adding sku data
        private string designServiceCode = " ";
        private string material = " ";
        private string colorCode = " ";
        private string basePrice;
        private readonly string[] location = new string[4];    // [0] for warehouse, [1] for rack, [2] for shelf, [3] for columnIndex
        private string locationFull;
        private string caHts;
        private string usHts;
        private string caDuty;
        private string usDuty;
        private string sku;
        private bool[] onWebsite = new bool[2];
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
        private string giantTiger;
        private string asiXid;
        private bool active = true;    // default set to true
        private string upcCode9;
        private string upcCode10;
        private int pricingTier;
        private int reorderQty;
        private int reorderLevel;

        // supporting boolean flags and other
        private bool frontHasAdded = false;
        private bool middleHasAdded = false;
        private bool lastHasAdded = false;
        private bool[] activeList = new bool[3];
        private readonly string[] htsList = new string[4];

        // fields for storing uri path and alt text of images
        private readonly ImageSearch imageSearch = new ImageSearch();
        private readonly List<string> image = new List<string>();
        private readonly List<string> group = new List<string>();
        private readonly List<string> model = new List<string>();
        private readonly List<string> template = new List<string>();
        private readonly TextBox[] imageTextbox = new TextBox[10];
        private readonly TextBox[] groupTextbox = new TextBox[5];
        private readonly TextBox[] modelTextbox = new TextBox[5];
        private readonly TextBox[] templateTextbox = new TextBox[2];
        private readonly string[] imageAlt = new string[10];
        private readonly string[] groupAlt = new string[5];
        private readonly string[] modelAlt = new string[5];

        // fields for lists
        private readonly ArrayList designServiceCodeList = new ArrayList();
        private readonly ArrayList materialList = new ArrayList();
        private readonly ArrayList colorCodeList = new ArrayList();
        private readonly ArrayList warehouseList = new ArrayList();
        private readonly ArrayList rackList = new ArrayList();
        private readonly ArrayList shelfList = new ArrayList();
        private readonly ArrayList columnIndexList = new ArrayList();
        private readonly ArrayList caHtsList = new ArrayList();
        private readonly ArrayList usHtsList = new ArrayList();
        private readonly HashSet<string> skuList = new HashSet<string>();

        // connection string to the database
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic component */
        public AddSKU()
        {
            InitializeComponent();

            // initilize some fields first
            caHtsList.Add("");
            usHtsList.Add("");

            // call background worker
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Comboboxes Background Workers
        /* the backgound workder for adding items to comboBoxes*/
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for Design Service Code
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Code is not NULL ORDER BY Design_Service_Code", connection);    
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                designServiceCodeList.Add(reader.GetString(0));
            reader.Close();

            // make comboBox for Material
            command.CommandText = "SELECT Material_Code FROM ref_Materials WHERE Material_Code is not NULL ORDER BY Material_Code";
            reader = command.ExecuteReader();
            while (reader.Read())
                materialList.Add(reader.GetString(0));
            reader.Close();

            // make comboBox for Colour Code
            command.CommandText = "SELECT Colour_Code FROM ref_Colours WHERE Colour_Code is not NULL ORDER BY Colour_Code"; 
            reader = command.ExecuteReader();
            while (reader.Read())
                colorCodeList.Add(reader.GetString(0));
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
            reader.Close(); ;

            // make comboBox for Shelf
            command.CommandText = "SELECT Warehouse FROM list_location_shelves WHERE Warehouse is not NULL";  
            reader = command.ExecuteReader();
            while (reader.Read())
                shelfList.Add(reader.GetValue(0));
            reader.Close(); ;

            // make comboBox for Column index
            command.CommandText = "SELECT Warehouse FROM list_location_colindex WHERE Warehouse is not NULL"; 
            reader = command.ExecuteReader();
            while (reader.Read())
                columnIndexList.Add(reader.GetValue(0));
            reader.Close(); ;

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

            // add all sku list
            command.CommandText = "SELECT SKU_Ashlin FROM master_SKU_Attributes;";
            reader = command.ExecuteReader();
            while (reader.Read())
                skuList.Add(reader.GetString(0));
            connection.Close();
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            designServiceCodeCombobox.DataSource = designServiceCodeList;
            materialCombobox.DataSource = materialList;
            colorCodeCombobox.DataSource = colorCodeList;
            warehouseCombobox.DataSource = warehouseList;
            rackCombobox.DataSource = rackList;
            shelfCombobox.DataSource = shelfList;
            columnIndexCombobox.DataSource = columnIndexList;
            canadianHtsCombobox.DataSource = caHtsList;
            usHtsCombobox.DataSource = usHtsList;

            // initialize some fields 
            designServiceCode = designServiceCodeCombobox.Text;
            material = materialCombobox.Text;
            colorCode = colorCodeCombobox.Text;
        }
        #endregion

        #region All the Events Associated with Design Service Code Combobox 
        /* the event for design service code combobox selected item changed that show the information about the selected item */
        private void designServiceCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentDesignCode = designServiceCodeCombobox.SelectedItem.ToString();

            // connect to database to get the info about this design code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Brand, Short_Description, Design_Service_Flag, GiftBox, Website_Flag, Active FROM master_Design_Attributes WHERE Design_Service_Code = \'" + currentDesignCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            brandTextbox.Text = table.Rows[0][0].ToString();
            designShortDescriptionTextbox.Text = table.Rows[0][1].ToString();
            designServiceFlagTextbox.Text = table.Rows[0][2].ToString();
            giftCheckbox.Checked = Convert.ToBoolean(table.Rows[0][3]);
            onWebsite[0] = Convert.ToBoolean(table.Rows[0][4]);
            activeList[0] = Convert.ToBoolean(table.Rows[0][5]);   

            // show the sku code on the textbox
            if (skuCodeTextbox.Text == "")    // nothing, add directly
            {
                skuCodeTextbox.Text = currentDesignCode;
                frontHasAdded = true;
            }
            else if (frontHasAdded) // has it self, replace it 
                skuCodeTextbox.Text = skuCodeTextbox.Text.Replace(designServiceCode, currentDesignCode);
            else // has something behind
            {
                string orignal = skuCodeTextbox.Text;
                skuCodeTextbox.Text = currentDesignCode + "-" + orignal;
                frontHasAdded = true;
            }

            // update design service code
            designServiceCode = currentDesignCode;

            // active determination
            if (activeList[0] && activeList[1] && activeList[2])
            {
                activeSkuButton.Enabled = true;
                inactiveSkuButton.Enabled = true;
                onWebsiteCheckbox.Enabled = onWebsite[0];
            }
            else
            {
                activeSkuButton.Enabled = false;
                inactiveSkuButton.Enabled = false;
                onWebsiteCheckbox.Enabled = false;
                active = false;
            }

            // call background worker
            if (!backgroundWorkerHTS.IsBusy)
                backgroundWorkerHTS.RunWorkerAsync();
        }
        private void backgroundWorkerHTS_DoWork(object sender, DoWorkEventArgs e)
        {
            // connect to database to get hts
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT HTS_CA, CA_Duty, HTS_US, US_Duty, Pricing_Tier, Reorder_Quantity, Reorder_Level FROM ref_Families family JOIN master_Design_Attributes design " +
                                                "ON family.Design_Service_Family_Code = design.Design_Service_Family_Code " +
                                                "WHERE Design_Service_Code = \'" + designServiceCode + "\';", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            // put the found taxes to the list
            for (int i = 0; i < 4; i++)
              htsList[i] = reader.GetValue(i).ToString();
            pricingTier = reader.GetInt32(4);
            reorderQty = reader.GetInt32(5);
            reorderLevel = reader.GetInt32(6);
            connection.Close();
        }
        private void backgroundWorkerHTS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            canadianHtsCombobox.Text = htsList[0];
            caDutyTextbox.Text = htsList[1];
            usHtsCombobox.Text = htsList[2];
            usDutyTextbox.Text = htsList[3];
            pricingTierUpdown.Value = pricingTier;
            reorderQtyUpdown.Value = reorderQty;
            reorderLevelUpdown.Value = reorderLevel;
        }
        #endregion

        /* the text change event that will check if there is already a duplicate sku */
        private void skuCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (skuList.Contains(skuCodeTextbox.Text))
            {
                skuCodeTextbox.BackColor = Color.Red;
                duplicateLabel.Visible = true;
            }
            else
            {
                skuCodeTextbox.BackColor = Color.FromArgb(224, 224, 224);
                duplicateLabel.Visible = false;
            }
        }

        /* the event for design service flag textbox that determine the sku code */
        private void designServiceFlagTextbox_TextChanged(object sender, EventArgs e)
        {
            if (designServiceFlagTextbox.Text == "Service")
            {
                materialCombobox.Enabled = false;
                colorCodeCombobox.Enabled = false;
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
                giantTigerTextbox.Enabled = false;
                asiXidTextbox.Enabled = false;
                pricingTierUpdown.Enabled = false;
                reorderQtyUpdown.Enabled = false;
                reorderLevelUpdown.Enabled = false;

                materialCombobox.Text = "SVC";
                colorCodeCombobox.Text = "SVC";
                rackCombobox.Text = "";
                shelfCombobox.Text = "";
                columnIndexCombobox.Text = "";
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
                giantTigerTextbox.Text = "";
                asiXidTextbox.Text = "";
                onWebsiteCheckbox.Checked = false;
            }
            else
            {
                materialCombobox.Enabled = true;
                colorCodeCombobox.Enabled = true;
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
                giantTigerTextbox.Enabled = true;
                asiXidTextbox.Enabled = true;
                pricingTierUpdown.Enabled = true;
                reorderQtyUpdown.Enabled = true;
                reorderLevelUpdown.Enabled = true;
            }
        }

        /* the event for material combobox selected item changed that show the information about the selected item */
        private void materialCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentMaterial = materialCombobox.SelectedItem.ToString();

            // connect to database to get the info about this material code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Description_Short, Active FROM ref_Materials WHERE Material_Code = \'" + currentMaterial + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            materialShortDescriptionTextbox.Text = table.Rows[0][0].ToString();
            activeList[1] = Convert.ToBoolean(table.Rows[0][1]);

            // show the sku code on the textbox
            if (skuCodeTextbox.Text == "")    // nothing, add directly
            {
                skuCodeTextbox.Text = currentMaterial;
                middleHasAdded = true;
            }
            else if (middleHasAdded)    // has it self, replace it
            {
                string original = skuCodeTextbox.Text;
                if (original.Contains(designServiceCode) && !original.Contains(colorCode))
                    // has something in front but nothing behind
                    skuCodeTextbox.Text = designServiceCode + '-' + currentMaterial;
                else if (!original.Contains(designServiceCode) && original.Contains(colorCode))
                    // has something behind but nothing infront
                    skuCodeTextbox.Text = currentMaterial + '-' + colorCode;
                else if (original.Contains(designServiceCode) && original.Contains(colorCode))
                    // has both infront and behind
                    skuCodeTextbox.Text = designServiceCode + '-' + currentMaterial + '-' + colorCode;
                else // only it self
                    skuCodeTextbox.Text = skuCodeTextbox.Text.Replace(material, currentMaterial);
            }
            else if (skuCodeTextbox.Text.Contains(designServiceCode) && !skuCodeTextbox.Text.Contains(colorCode))    // has something in front but nothing behind, add behind it 
            {
                skuCodeTextbox.Text += '-' + currentMaterial;
                middleHasAdded = true;
            }
            else if (!skuCodeTextbox.Text.Contains(designServiceCode) && skuCodeTextbox.Text.Contains(colorCode))    // has something behind but nothing infront, add infront of it
            {
                skuCodeTextbox.Text = currentMaterial + '-' + colorCode;
                middleHasAdded = true;
            }
            else    // has both behind and front, add it to the middle
            {
                skuCodeTextbox.Text = designServiceCode + '-' + currentMaterial + '-' + colorCode;
                middleHasAdded = true;
            }

            // update material
            material = currentMaterial;

            // active determination
            if (activeList[0] && activeList[1] && activeList[2])
            {
                activeSkuButton.Enabled = true;
                inactiveSkuButton.Enabled = true;
                onWebsiteCheckbox.Enabled = onWebsite[0];
            }
            else
            {
                activeSkuButton.Enabled = false;
                inactiveSkuButton.Enabled = false;
                onWebsiteCheckbox.Enabled = false;
                active = false;
            }
        }

        /* the event for color combobox selected item changed that show the information about the selected item */
        private void colorCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // lacal fields for storing information
            DataTable table = new DataTable();
            string currentColorCode = colorCodeCombobox.SelectedItem.ToString();

            // connect to database to get the info about this color code
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Description_Short, Active FROM ref_Colours WHERE Colour_Code = \'" + currentColorCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // show the info on the textboxes
            colorShortDescriptionTextbox.Text = table.Rows[0][0].ToString();
            activeList[2] = Convert.ToBoolean(table.Rows[0][1]);

            // show the sku code on the textbox
            if (skuCodeTextbox.Text == "")    // nothing, add directly
            {
                skuCodeTextbox.Text = currentColorCode;
                lastHasAdded = true;
            }
            else if (lastHasAdded)    // has it self, simply replace it
            {
                string original = skuCodeTextbox.Text;
                if (original.Contains(designServiceCode) || original.Contains(material)) // somehing is in front
                    skuCodeTextbox.Text = original.Substring(0, original.LastIndexOf('-') + 1) + currentColorCode;
                else // only it self
                    skuCodeTextbox.Text = skuCodeTextbox.Text.Replace(colorCode, currentColorCode);
            }
            else    // has something in front
            {
                skuCodeTextbox.Text += '-' + currentColorCode;
                lastHasAdded = true;
            }

            // update color code
            colorCode = currentColorCode;

            // active determination
            if (activeList[0] && activeList[1] && activeList[2])
            {
                activeSkuButton.Enabled = true;
                inactiveSkuButton.Enabled = true;
                onWebsiteCheckbox.Enabled = onWebsite[0];
            }
            else
            {
                activeSkuButton.Enabled = false;
                inactiveSkuButton.Enabled = false;
                onWebsiteCheckbox.Enabled = false;
                active = false;
            }
        }

        #region Taxes Comboboxes
        /* the event for hts comboboxes selected item changed that show the information about the selected item */
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
                    SqlCommand command = new SqlCommand("SELECT US_Duty FROM HTS_US WHERE HTS_US = \'" + usHtsCombobox.SelectedItem + "\';", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    usDutyTextbox.Text = reader.GetDecimal(0).ToString();
                }
            }
            else
                usDutyTextbox.Text = "";
        }
        #endregion

        #region Add SKU
        /* the event for add sku button click */
        private void addSkuButton_Click(object sender, EventArgs e)
        {
            // first check if the user has put the sku or not
            if (skuCodeTextbox.Text == "")
            {
                skuCodeTextbox.BackColor = Color.Red;
                return;
            }

            // get on website flag and pricing tier
            onWebsite[1] = onWebsiteCheckbox.Checked;
            pricingTier = (int)pricingTierUpdown.Value;
            reorderQty = (int)reorderQtyUpdown.Value;
            reorderLevel = (int)reorderLevelUpdown.Value;

            // call background worker
            if (!backgroundWorkerImagePath.IsBusy)
                backgroundWorkerImagePath.RunWorkerAsync();
        }
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
            string[] imageCopy = imageSearch.GetImageUri(sku);
            foreach (string uri in imageCopy) // get the value that exist
                image.Add(uri);
            int j = 10 - imageCopy.Length;    // get the number of value missing, add them
            for (int i = 0; i < j; i++)
                image.Add("");

            string[] groupCopy = imageSearch.GetGroupUri(sku);
            foreach (string uri in groupCopy) // get the value that exist
                group.Add(uri);
            j = 5 - groupCopy.Length;        // get the number of value missing, add them
            for (int i = 0; i < j; i++)
                group.Add("");

            string[] modelCopy = imageSearch.GetModelUri(sku);
            foreach (string uri in modelCopy) // get the value that exist
                model.Add(uri);
            j = 5 - modelCopy.Length;         // get the number of value missing, add them
            for (int i = 0; i < j; i++)
                model.Add("");

            string[] templateCopy = imageSearch.GetTemplateUri(sku);
            foreach (string uri in templateCopy) // get the value that exist
                template.Add(uri);
            j = 2 - templateCopy.Length;         // get the number of value missing, add them
            for (int i = 0; i < j; i++)
                template.Add("");

            // simulate progress 10% ~ 20%
            for (int i = 10; i <= 20; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerImagePath.ReportProgress(i);
            }

            // addition fields for adding upc image
            Upc upc = new Upc();
            upcCode9 = upc.GetUpc();
            upcCode10 = upc.GetUpc10(upcCode9);

            // adding upc image
            ImageReplace imageReplace = new ImageReplace();
            imageReplace.AddUpc(sku, upcCode9);
            imageReplace.AddUpc(sku, upcCode10);

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
            for (int i = 0; i < image.Count; i++)
                imageTextbox[i].Text = image[i];

            // assign image uri to group textboxes
            for (int i = 0; i < group.Count; i++)
                groupTextbox[i].Text = group[i];

            // assign image uri to model textboxes
            for (int i = 0; i < model.Count; i++)
                modelTextbox[i].Text = model[i];

            // assign image uri to template textboxes
            for (int i = 0; i < template.Count; i++)
                templateTextbox[i].Text = template[i];

            // initialize location field and HTS
            location[0] = warehouseCombobox.SelectedItem.ToString();
            location[1] = rackCombobox.SelectedItem.ToString();
            location[2] = shelfCombobox.SelectedItem.ToString();
            location[3] = columnIndexCombobox.SelectedItem.ToString();
            caHts = canadianHtsCombobox.SelectedItem.ToString();
            usHts = usHtsCombobox.SelectedItem.ToString();

            // call background worker
            if (!backgroundWorkerAddSKU.IsBusy)
                backgroundWorkerAddSKU.RunWorkerAsync();
        }
        private void backgroundWorkerAddSKU_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 30% ~ 50%
            for (int j = 30; j <= 50; j++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddSKU.ReportProgress(j);
            }

            // get data from user input
            basePrice = basesPriceTextbox.Text;
            if (basePrice == "")
                basePrice = "0";
            locationFull = "WH" + location[0] + "-R" + location[1] + "-S" + location[2] + "-C" + location[3];
            caDuty = caDutyTextbox.Text;
            usDuty = usDutyTextbox.Text;
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
            giantTiger = giantTigerTextbox.Text.Replace("'", "''");
            asiXid = asiXidTextbox.Text.Replace("'", "''");

            // simulate progress 50% ~ 70%
            for (int j = 50; j <= 70; j++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddSKU.ReportProgress(j);
            }

            // assgin alt text to image
            int i = 0;
            for (; i < image.Count; i++)
            {
                if (image[i] == "")
                    imageAlt[i] = "";
                else
                    imageAlt[i] = AltText.GetAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // assgin alt text to image
            i = 0;
            for (; i < group.Count; i++)
            {
                if (group[i] == "")
                    groupAlt[i] = "";
                else
                    groupAlt[i] = "Group " + AltText.GetAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // assgin alt text to image
            i = 0;
            for (; i < model.Count; i++)
            {
                if (model[i] == "")
                    modelAlt[i] = "";
                else
                    modelAlt[i] = "Model " + AltText.GetAltWithSkuNotExist(sku).Replace("'", "''");
            }

            // simulate progress 70% ~ 90%
            for (int j = 70; j <= 90; j++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddSKU.ReportProgress(j);
            }

            // connect to database and insert new row
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (!caHts.Equals("") && !usHts.Equals(""))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO master_SKU_Attributes (SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, SKU_Website, SKU_MAGENTO, SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_SHOP_CA, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_WALMART_COM, SKU_DistributorCentral, SKU_PromoMarketing, SKU_GIANT_TIGER, ASI_XID, Location_WH, Location_Shelf, Location_ColIndex, Location_Rack, Location_Full, Base_Price, UPC_Code_9, UPC_Code_10, Ashlin_URL, HTS_CDN, HTS_US, Duty_CDN, Duty_US, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, Active, Date_Added, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path, Template_URL_1, Template_URL_2, Pricing_Tier, Reorder_Quantity, Reorder_Level) "
                                                          + "VALUES (\'" + sku + "\',\'" + designServiceCode + "\',\'" + material + "\',\'" + colorCode + "\',\'" + onWebsite[1] + "\',\'" + magento + "\',\'" + sears + "\',\'" + tsc + "\',\'" + costco + "\',\'" + bestbuy + "\', \'" + amazonCa + "\', \'" + amazonCom + "\', \'" + shopCa + "\', \'" + staples + "\', \'" + walmartCa + "\', \'" + walmartCom + "\', \'" + distributorCentral + "\', \'" + promoMarketing + "\', \'" + giantTiger + "\', \'" + asiXid + "\', \'" + location[0] + "\', \'" + location[2] + "\', \'" + location[3] + "\', \'" + location[1] + "\', \'" + locationFull + "\', " + basePrice + ", " + upcCode9 + ", " + upcCode10 + ", \'" + ashlin + "\', \'" + caHts + "\', \'" + usHts + "\', " + caDuty + ", " + usDuty + ", \'" + image[0] + "\', \'" + image[1] + "\', \'" + image[2] + "\', \'" + image[3] + "\', \'" + image[4] + "\', \'" + image[5] + "\', \'" + image[6] + "\', \'" + image[7] + "\', \'" + image[8] + "\', \'" + image[9] + "\', \'" + group[0] + "\', \'" + group[1] + "\', \'" + group[2] + "\', \'" + group[3] + "\', \'" + group[4] + "\', \'" + model[0] + "\', \'" + model[1] + "\', \'" + model[2] + "\', \'" + model[3] + "\', \'" + model[4] + "\', \'" + active.ToString() + "\', \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', \'" + imageAlt[0] + "\', \'" + imageAlt[1] + "\', \'" + imageAlt[2] + "\', \'" + imageAlt[3] + "\', \'" + imageAlt[4] + "\', \'" + imageAlt[5] + "\', \'" + imageAlt[6] + "\', \'" + imageAlt[7] + "\', \'" + imageAlt[8] + "\', \'" + imageAlt[9] + "\', \'" + groupAlt[0] + "\', \'" + groupAlt[1] + "\', \'" + groupAlt[2] + "\', \'" + groupAlt[3] + "\', \'" + groupAlt[4] + "\', \'" + modelAlt[0] + "\',\'" + modelAlt[1] + "\',\'" + modelAlt[2] + "\',\'" + modelAlt[3] + "\',\'" + modelAlt[4] + "\',\'" + template[0] + "\',\'" + template[1] + "\'," + pricingTier + ',' + reorderQty + ',' + reorderLevel + ')', connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO master_SKU_Attributes (SKU_Ashlin, Design_Service_Code, Material_Code, Colour_Code, SKU_Website, SKU_MAGENTO, SKU_SEARS_CA, SKU_TSC_CA, SKU_COSTCO_CA, SKU_BESTBUY_CA, SKU_AMAZON_CA, SKU_AMAZON_COM, SKU_SHOP_CA, SKU_STAPLES_CA, SKU_WALMART_CA, SKU_WALMART_COM, SKU_DistributorCentral, SKU_PromoMarketing, SKU_GIANT_TIGER, ASI_XID, Location_WH, Location_Shelf, Location_ColIndex, Location_Rack, Location_Full, Base_Price, UPC_Code_9, UPC_Code_10, Ashlin_URL, Image_1_Path, Image_2_Path, Image_3_Path, Image_4_Path, Image_5_Path, Image_6_Path, Image_7_Path, Image_8_Path, Image_9_Path, Image_10_Path, Image_Group_1_Path, Image_Group_2_Path, Image_Group_3_Path, Image_Group_4_Path, Image_Group_5_Path, Image_Model_1_Path, Image_Model_2_Path, Image_Model_3_Path, Image_Model_4_Path, Image_Model_5_Path, Active, Date_Added, Alt_Text_Image_1_Path, Alt_Text_Image_2_Path, Alt_Text_Image_3_Path, Alt_Text_Image_4_Path, Alt_Text_Image_5_Path, Alt_Text_Image_6_Path, Alt_Text_Image_7_Path, Alt_Text_Image_8_Path, Alt_Text_Image_9_Path, Alt_Text_Image_10_Path, Alt_Text_Image_Group_1_Path, Alt_Text_Image_Group_2_Path, Alt_Text_Image_Group_3_Path, Alt_Text_Image_Group_4_Path, Alt_Text_Image_Group_5_Path, Alt_Text_Image_Model_1_Path, Alt_Text_Image_Model_2_Path, Alt_Text_Image_Model_3_Path, Alt_Text_Image_Model_4_Path, Alt_Text_Image_Model_5_Path, Template_URL_1, Template_URL_2, Pricing_Tier, Reorder_Quantity, Reorder_Level) "
                                                          + "VALUES (\'" + sku + "\',\'" + designServiceCode + "\',\'" + material + "\',\'" + colorCode + "\',\'" + onWebsite[1] + "\',\'" + magento + "\',\'" + sears + "\',\'" + tsc + "\',\'" + costco + "\',\'" + bestbuy + "\',\'" + amazonCa + "\',\'" + amazonCom + "\', \'" + shopCa + "\', \'" + staples + "\', \'" + walmartCa + "\', \'" + walmartCom + "\', \'" + distributorCentral + "\', \'" + promoMarketing + "\', \'" + giantTiger + "\', \'" + asiXid + "\', \'" + location[0] + "\', \'" + location[2] + "\', \'" + location[3] + "\', \'" + location[1] + "\', \'" + locationFull + "\', " + basePrice + ", " + upcCode9 + ", " + upcCode10 + ", \'" + ashlin + "\', \'" + image[0] + "\', \'" + image[1] + "\', \'" + image[2] + "\', \'" + image[3] + "\', \'" + image[4] + "\', \'" + image[5] + "\', \'" + image[6] + "\', \'" + image[7] + "\', \'" + image[8] + "\', \'" + image[9] + "\', \'" + group[0] + "\', \'" + group[1] + "\', \'" + group[2] + "\', \'" + group[3] + "\', \'" + group[4] + "\', \'" + model[0] + "\', \'" + model[1] + "\', \'" + model[2] + "\', \'" + model[3] + "\', \'" + model[4] + "\', \'" + active.ToString() + "\', \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', \'" + imageAlt[0] + "\', \'" + imageAlt[1] + "\', \'" + imageAlt[2] + "\', \'" + imageAlt[3] + "\', \'" + imageAlt[4] + "\', \'" + imageAlt[5] + "\', \'" + imageAlt[6] + "\', \'" + imageAlt[7] + "\', \'" + imageAlt[8] + "\', \'" + imageAlt[9] + "\', \'" + groupAlt[0] + "\', \'" + groupAlt[1] + "\', \'" + groupAlt[2] + "\', \'" + groupAlt[3] + "\', \'" + groupAlt[4] + "\', \'" + modelAlt[0] + "\', \'" + modelAlt[1] + "\', \'" + modelAlt[2] + "\', \'" + modelAlt[3] + "\',\'" + modelAlt[4] + "\',\'" + template[0] + "\',\'" + template[1] + "\'," + pricingTier + ',' + reorderQty + ',' + reorderLevel + ')', connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happen during database updating: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // simulate progress 90% ~ 100%
            for (int j = 90; j <= 100; j++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddSKU.ReportProgress(j);
            }
        }
        private void backgroundWorkerAddSKU_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive Button Click Event
        /* the event for active and inactive sku button click */
        private void activeSkuButton_Click(object sender, EventArgs e)
        {
            active = true;  // make active true

            // set buttons enability
            activeSkuButton.Enabled = false;
            inactiveSkuButton.Enabled = true;

            // set checkbox enability
            if (onWebsite[0])
                 onWebsiteCheckbox.Enabled = true;

            AutoScrollPosition = new Point(HorizontalScroll.Value, VerticalScroll.Value);
        }
        private void inactiveSkuButton_Click(object sender, EventArgs e)
        {
            active = false;    // make active false

            // set buttons enability
            inactiveSkuButton.Enabled = false;
            activeSkuButton.Enabled = true;

            // set checkbox enability
            onWebsiteCheckbox.Checked = false;
            onWebsiteCheckbox.Enabled = false;

            AutoScrollPosition = new Point(HorizontalScroll.Value, VerticalScroll.Value);
        }
        #endregion
    }
}
