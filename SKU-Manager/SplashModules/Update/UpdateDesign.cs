using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SupportingClasses;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace SKU_Manager.SplashModules.Update
{
   /*
    * An application module to update design to SKU database
    */
    public partial class UpdateDesign : Form
    {
        // fields for storing adding design data
        private string designServiceCode;
        private string productFamily;
        private string designServiceFlag;
        private string internalName;
        private string shortEnglishDescription;
        private string shortFrenchDescription;
        private string extendedEnglishDescription;
        private string extendedFrenchDescription;
        private string trendShortEnglishDescription;
        private string trendShortFrenchDescription;
        private string trendExtendedEnglishDescription;
        private string trendExtendedFrenchDescription;
        private string designOnlineEnglish;
        private string designOnlineFrench;
        private string[] boolean = new string[9];    // [0] for monogrammed, [1] for imprinted, [2] for strap, [3] for detachable, [4] for zipped, [5] for shipped flat, [6] for shipped folded, [7] for displayed website, [8] for gift box
        private int[] integer = new int[10];         // corresponding to the field above
        private string imprintHeight;
        private string imprintWidth;
        private string productHeight;
        private string productWidth;
        private string productDepth;
        private string weight;
        private string country;
        private double shoulderDropLength;
        private double handleStrapDropLength;
        private string notableStrapGeneralFeatures = "1 long";
        private bool protectiveFeet;
        private string closure = "Zippered";
        private bool innerPocket;
        private bool outsidePocket;
        private string sizeDifferentiation = "Medium";
        private string numberComponents;
        private string shippableHeight;
        private string shippableWidth;
        private string shippableDepth;
        private string shippableWeight;
        private string tsc;
        private string theBay;
        private string bestbuy;
        private string shopca;
        private string amazon;
        private string sears;
        private string staples;
        private string walmart;
        private string[] englishOption = new string[5];
        private string[] frenchOption = new string[5];
        private bool active = true;    // default set to true

        // supporting boolean flag fields -> set to default
        private bool isFlat;
        private bool isFolded;

        // field for comboBox
        private readonly ArrayList designCodeList = new ArrayList();
        private readonly ArrayList productFamilyList = new ArrayList();
        private readonly HashSet<string> internalNameList = new HashSet<string>();

        /* constructor that initialize graphic component */
        public UpdateDesign()
        {
            InitializeComponent();
            designCodeList.Add(string.Empty);
            productFamilyList.Add(string.Empty);

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for Design Service Code
            SqlConnection connection = new SqlConnection(Credentials.DesignCon);
            SqlCommand command = new SqlCommand("SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Code is not NULL ORDER BY Design_Service_Code", connection);   
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                designCodeList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for Product Family
            command.CommandText = "SELECT Design_Service_Family_Description FROM ref_Families WHERE Design_Service_Family_Description is not NULL ORDER BY Design_Service_Family_Description";
            reader = command.ExecuteReader();
            while (reader.Read())
                productFamilyList.Add(reader.GetValue(0));
            reader.Close();

            // additional addition for ashlin internal name checking
            command.CommandText = "SELECT Design_Service_Fashion_Name_Ashlin FROM master_Design_Attributes";
            reader = command.ExecuteReader();
            while (reader.Read())
                internalNameList.Add(reader.GetString(0));
            connection.Close();
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            designCodeCombobox.DataSource = designCodeList;
            productFamilyCombobox.DataSource = productFamilyList;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void designCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the enability of the controls
            if (designCodeCombobox.SelectedItem.ToString() != "")
            {
                productFamilyCombobox.Enabled = true;
                designServiceFlagCombobox.Enabled = true;
                giftCheckbox.Enabled = true;
                internalNameTextbox.Enabled = true;
                translateButton1.Enabled = true;
                shortEnglishDescriptionTextbox.Enabled = true;
                shortFrenchDescriptionTextbox.Enabled = true;
                extendedEnglishDescriptionTextbox.Enabled = true;
                extendedFrenchDescriptionTextbox.Enabled = true;
                trendEnglishShortTextbox.Enabled = true;
                trendFrenchShortTextbox.Enabled = true;
                trendEnglishExtendedTextbox.Enabled = true;
                trendFrenchExtendedTextbox.Enabled = true;
                onlineButton.Enabled = true;
                translateButton2.Enabled = true;
                option1EnglishTextbox.Enabled = true;
                option2EnglishTextbox.Enabled = true;
                option3EnglishTextbox.Enabled = true;
                option4EnglishTextbox.Enabled = true;
                option5EnglishTextbox.Enabled = true;
                option1FrenchTextbox.Enabled = true;
                option2FrenchTextbox.Enabled = true;
                option3FrenchTextbox.Enabled = true;
                option4FrenchTextbox.Enabled = true;
                option5FrenchTextbox.Enabled = true;
                activeCheckbox.Enabled = true;
                updateDesignButton.Enabled = true;

                // set designServiceCode field from the selected item 
                designServiceCode = designCodeCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set textboxes to nothing
                brandTextbox.Text = string.Empty;
                internalNameTextbox.Text = string.Empty;
                shortEnglishDescriptionTextbox.Text = string.Empty;
                shortFrenchDescriptionTextbox.Text = string.Empty;
                extendedEnglishDescriptionTextbox.Text = string.Empty;
                extendedFrenchDescriptionTextbox.Text = string.Empty;
                trendEnglishShortTextbox.Text = string.Empty;
                trendFrenchShortTextbox.Text = string.Empty;
                trendEnglishExtendedTextbox.Text = string.Empty;
                trendFrenchExtendedTextbox.Text = string.Empty;
                imprintHeightTextbox.Text = string.Empty;
                imprintWidthTextbox.Text = string.Empty;
                productHeightTextbox.Text = string.Empty;
                productWidthTextbox.Text = string.Empty;
                productDepthTextbox.Text = string.Empty;
                weightTextBox.Text = string.Empty;
                numberComponentTextbox.Text = string.Empty;
                tscTextbox.Text = string.Empty;
                theBayTextbox.Text = string.Empty;
                bestbuyTextbox.Text = string.Empty;
                shopcaTextbox.Text = string.Empty;
                amazonTextbox.Text = string.Empty;
                searsTextbox.Text = string.Empty;
                staplesTextbox.Text = string.Empty;
                walmartTextbox.Text = string.Empty;
                option1EnglishTextbox.Text = string.Empty;
                option2EnglishTextbox.Text = string.Empty;
                option3EnglishTextbox.Text = string.Empty;
                option4EnglishTextbox.Text = string.Empty;
                option5EnglishTextbox.Text = string.Empty;
                option1FrenchTextbox.Text = string.Empty;
                option2FrenchTextbox.Text = string.Empty;
                option3FrenchTextbox.Text = string.Empty;
                option4FrenchTextbox.Text = string.Empty;
                option5FrenchTextbox.Text = string.Empty;

                // set the comboboxes' text to nothing
                productFamilyCombobox.Text = string.Empty;
                designServiceFlagCombobox.Text = string.Empty;
                monogrammedCombobox.Text = string.Empty;
                imprintedCombobox.Text = string.Empty;
                strapCombobox.Text = string.Empty;
                detachableCombobox.Text = string.Empty;
                zippedCombobox.Text = string.Empty;
                shippedFlatCombobox.Text = string.Empty;
                shippedFoldedCombobox.Text = string.Empty;
                displayedOnWebsiteCombobox.Text = string.Empty;
                countryCombobox.Text = string.Empty;
                displayedOnWebsiteCombobox.Text = string.Empty;

                productFamilyCombobox.Enabled = false;
                designServiceFlagCombobox.Enabled = false;
                giftCheckbox.Enabled = false;
                giftCheckbox.Checked = false;
                internalNameTextbox.Enabled = false;
                translateButton1.Enabled = false;
                shortEnglishDescriptionTextbox.Enabled = false;
                shortFrenchDescriptionTextbox.Enabled = false;
                extendedEnglishDescriptionTextbox.Enabled = false;
                extendedFrenchDescriptionTextbox.Enabled = false;
                trendEnglishShortTextbox.Enabled = false;
                trendFrenchShortTextbox.Enabled = false;
                trendEnglishExtendedTextbox.Enabled = false;
                trendFrenchExtendedTextbox.Enabled = false;
                onlineButton.Enabled = false;
                translateButton2.Enabled = false;
                option1EnglishTextbox.Enabled = false;
                option2EnglishTextbox.Enabled = false;
                option3EnglishTextbox.Enabled = false;
                option4EnglishTextbox.Enabled = false;
                option5EnglishTextbox.Enabled = false;
                option1FrenchTextbox.Enabled = false;
                option2FrenchTextbox.Enabled = false;
                option3FrenchTextbox.Enabled = false;
                option4FrenchTextbox.Enabled = false;
                option5FrenchTextbox.Enabled = false;
                displayedOnWebsiteCombobox.Enabled = false;
                updateDesignButton.Enabled = false;
                activeCheckbox.Checked = false;
                activeCheckbox.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Family_Code, Design_Service_Flag, Design_Service_Fashion_Name_Ashlin, Short_Description, Short_Description_FR, Extended_Description, Extended_Description_FR, Monogram, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Height_cm, Width_cm, Depth_cm, Weight_grams, Components, Strap, Detachable_Strap, Zippered_Enclosure, Flat_Shippable, Fold_Shippable, Shippable_Height_cm, Shippable_Width_cm, Shippable_Depth_cm, Shippable_Weight_grams, Design_Service_Fashion_Name_TSC_CA, Design_Service_Fashion_Name_THE_BAY, Design_Service_Fashion_Name_BESTBUY_CA, Design_Service_Fashion_Name_SHOP_CA, Design_Service_Fashion_Name_AMAZON_CA, Design_Service_Fashion_Name_SEARS_CA, Design_Service_Fashion_Name_STAPLES_CA, Design_Service_Fashion_Name_WALMART, "  
                                                          + "Option_1, Option_1_FR, Option_2, Option_2_FR, Option_3, Option_3_FR, Option_4, Option_4_FR, Option_5, Option_5_FR, Website_Flag, Active, Trend_Short_Description, Trend_Short_Description_FR, Trend_Extended_Description, Trend_Extended_Description_FR, Design_Online, Design_Online_FR, GiftBox, Country, ShoulderDropLength, HandleStrapDropLength, NotableStrapGeneralFeatures, ProtectiveFeet, Closure, InnerPocket, OutsidePocket, SizeDifferentiation FROM master_Design_Attributes WHERE Design_Service_Code = \'" + designServiceCode + '\'', connection);
                connection.Open();
                adapter.Fill(table);
            }

            // this is special case
            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                // this is for searching family description for product family code
                SqlCommand command = new SqlCommand("SELECT Design_service_Family_Description FROM ref_Families WHERE Design_Service_Family_Code = \'" + table.Rows[0][0] + '\'', connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    productFamily = reader.GetString(0);
            }

            designServiceFlag = table.Rows[0][1].ToString();
            internalName = table.Rows[0][2].ToString();
            shortEnglishDescription = table.Rows[0][3].ToString();
            shortFrenchDescription = table.Rows[0][4].ToString();
            extendedEnglishDescription = table.Rows[0][5].ToString();
            extendedFrenchDescription = table.Rows[0][6].ToString();
            trendShortEnglishDescription = table.Rows[0][45].ToString();
            trendShortFrenchDescription = table.Rows[0][46].ToString();
            trendExtendedEnglishDescription = table.Rows[0][47].ToString();
            trendExtendedFrenchDescription = table.Rows[0][48].ToString();
            designOnlineEnglish = table.Rows[0][49].ToString();
            designOnlineFrench = table.Rows[0][50].ToString();
            boolean[0] = table.Rows[0][7].ToString();
            boolean[1] = table.Rows[0][8].ToString();
            imprintHeight = table.Rows[0][9].ToString();
            imprintWidth = table.Rows[0][10].ToString();
            productHeight = table.Rows[0][11].ToString();
            productWidth = table.Rows[0][12].ToString();
            productDepth = table.Rows[0][13].ToString();
            weight = table.Rows[0][14].ToString();
            numberComponents = table.Rows[0][15].ToString();
            boolean[2] = table.Rows[0][16].ToString();
            boolean[3] = table.Rows[0][17].ToString();
            boolean[4] = table.Rows[0][18].ToString();
            boolean[5] = table.Rows[0][19].ToString();
            boolean[6] = table.Rows[0][20].ToString();
            shippableHeight = table.Rows[0][21].ToString();
            shippableWidth = table.Rows[0][22].ToString();
            shippableDepth = table.Rows[0][23].ToString();
            shippableWeight = table.Rows[0][24].ToString();
            tsc = table.Rows[0][25].ToString();
            theBay = table.Rows[0][26].ToString();
            bestbuy = table.Rows[0][27].ToString();
            shopca = table.Rows[0][28].ToString();
            amazon = table.Rows[0][29].ToString();
            sears = table.Rows[0][30].ToString();
            staples = table.Rows[0][31].ToString();
            walmart = table.Rows[0][32].ToString();
            englishOption[0] = table.Rows[0][33].ToString();
            frenchOption[0] = table.Rows[0][34].ToString();
            englishOption[1] = table.Rows[0][35].ToString();
            frenchOption[1] = table.Rows[0][36].ToString();
            englishOption[2] = table.Rows[0][37].ToString();
            frenchOption[2] = table.Rows[0][38].ToString();
            englishOption[3] = table.Rows[0][39].ToString();
            frenchOption[3] = table.Rows[0][40].ToString();
            englishOption[4] = table.Rows[0][41].ToString();
            frenchOption[4] = table.Rows[0][42].ToString();
            boolean[7] = table.Rows[0][43].ToString();
            active = table.Rows[0][44].ToString() != "False";
            boolean[8] = table.Rows[0][51].ToString();
            country = table.Rows[0][52].ToString();
            shoulderDropLength = Convert.ToDouble(table.Rows[0][53]);
            handleStrapDropLength = Convert.ToDouble(table.Rows[0][54]);
            notableStrapGeneralFeatures = table.Rows[0][55].ToString();
            protectiveFeet = Convert.ToBoolean(table.Rows[0][56]);
            closure = table.Rows[0][57].ToString();
            innerPocket = Convert.ToBoolean(table.Rows[0][58]);
            outsidePocket = Convert.ToBoolean(table.Rows[0][59]);
            sizeDifferentiation = table.Rows[0][60].ToString();
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            productFamilyCombobox.Text = productFamily;
            brandTextbox.Text = @"Ashlin®";
            giftCheckbox.Checked = boolean[8] == "True";
            internalNameTextbox.Text = internalName;
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            extendedEnglishDescriptionTextbox.Text = extendedEnglishDescription;
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
            trendEnglishShortTextbox.Text = trendShortEnglishDescription;
            trendFrenchShortTextbox.Text = trendShortFrenchDescription;
            trendEnglishExtendedTextbox.Text = trendExtendedEnglishDescription;
            trendFrenchExtendedTextbox.Text = trendExtendedFrenchDescription;
            monogrammedCombobox.Text = boolean[0];
            imprintedCombobox.Text = boolean[1];
            imprintHeightTextbox.Text = imprintHeight;
            imprintWidthTextbox.Text = imprintWidth;
            productHeightTextbox.Text = productHeight;
            productWidthTextbox.Text = productWidth;
            productDepthTextbox.Text = productDepth;
            weightTextBox.Text = weight;
            countryCombobox.Text = country;
            numberComponentTextbox.Text = numberComponents;
            strapCombobox.Text = boolean[2];
            detachableCombobox.Text = boolean[3];
            zippedCombobox.Text = boolean[4];
            shippedFlatCombobox.Text = boolean[5];
            shippedFoldedCombobox.Text = boolean[6];
            shippableHeightTextbox.Text = shippableHeight;
            shippableWidthTextbox.Text = shippableWidth;
            shippableDepthTextbox.Text = shippableDepth;
            shippableWeightTextbox.Text = shippableWeight;
            tscTextbox.Text = tsc;
            theBayTextbox.Text = theBay;
            bestbuyTextbox.Text = bestbuy;
            shopcaTextbox.Text = shopca;
            amazonTextbox.Text = amazon;
            searsTextbox.Text = sears;
            staplesTextbox.Text = staples;
            walmartTextbox.Text = walmart;
            option1EnglishTextbox.Text = englishOption[0];
            option2EnglishTextbox.Text = englishOption[1];
            option3EnglishTextbox.Text = englishOption[2];
            option4EnglishTextbox.Text = englishOption[3];
            option5EnglishTextbox.Text = englishOption[4];
            option1FrenchTextbox.Text = frenchOption[0];
            option2FrenchTextbox.Text = frenchOption[1];
            option3FrenchTextbox.Text = frenchOption[2];
            option4FrenchTextbox.Text = frenchOption[3];
            option5FrenchTextbox.Text = frenchOption[4];
            displayedOnWebsiteCombobox.Text = boolean[7];
            activeCheckbox.Checked = active;
            designServiceFlagCombobox.Text = designServiceFlag;
        }
        #endregion

        /* the event of design service flag combobox that set the enability of some controls */
        private void designServiceFlagCombobox_TextChanged(object sender, EventArgs e)
        {
            if (designServiceFlagCombobox.Text == "Design")
            {
                tscTextbox.Enabled = true;
                theBayTextbox.Enabled = true;
                bestbuyTextbox.Enabled = true;
                shopcaTextbox.Enabled = true;
                amazonTextbox.Enabled = true;
                searsTextbox.Enabled = true;
                staplesTextbox.Enabled = true;
                walmartTextbox.Enabled = true;
                monogrammedCombobox.Enabled = true;
                imprintedCombobox.Enabled = true;
                imprintHeightTextbox.Enabled = true;
                imprintWidthTextbox.Enabled = true;
                productHeightTextbox.Enabled = true;
                productWidthTextbox.Enabled = true;
                productDepthTextbox.Enabled = true;
                weightTextBox.Enabled = true;
                countryCombobox.Enabled = true;
                bagDetailButton.Enabled = true;
                numberComponentTextbox.Enabled = true;
                strapCombobox.Enabled = true;
                detachableCombobox.Enabled = true;
                zippedCombobox.Enabled = true;
                shippedFlatCombobox.Enabled = true;
                shippedFoldedCombobox.Enabled = true;
            }
            else
            {
                tscTextbox.Enabled = false;
                theBayTextbox.Enabled = false;
                bestbuyTextbox.Enabled = false;
                shopcaTextbox.Enabled = false;
                amazonTextbox.Enabled = false;
                searsTextbox.Enabled = false;
                staplesTextbox.Enabled = false;
                walmartTextbox.Enabled = false;
                monogrammedCombobox.Enabled = false;
                imprintedCombobox.Enabled = false;
                imprintHeightTextbox.Enabled = false;
                imprintWidthTextbox.Enabled = false;
                productHeightTextbox.Enabled = false;
                productWidthTextbox.Enabled = false;
                productDepthTextbox.Enabled = false;
                weightTextBox.Enabled = false;
                countryCombobox.Enabled = false;
                bagDetailButton.Enabled = false;
                numberComponentTextbox.Enabled = false;
                strapCombobox.Enabled = false;
                detachableCombobox.Enabled = false;
                zippedCombobox.Enabled = false;
                shippedFlatCombobox.Enabled = false;
                shippedFoldedCombobox.Enabled = false;
            }
        }

        #region Left and Right Buttons
        /* the event for left and right button click that change the index of comboboxes */
        private void leftButton_Click(object sender, EventArgs e)
        {
            int i = designCodeCombobox.SelectedIndex;
            if (i > 0)
                i--;
            designCodeCombobox.SelectedIndex = i;
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            int i = designCodeCombobox.SelectedIndex;
            if (i < designCodeList.Count - 1)
                i++;
            designCodeCombobox.SelectedIndex = i;
        }
        #endregion

        /* the event of internal ashlin name textbox that detect whether the user input has duplicate */
        private void internalNameTextbox_TextChanged(object sender, EventArgs e)
        {
            string name = internalNameTextbox.Text;

            if (name != "" && name != internalName && internalNameList.Contains(name))
            {
                    internalNameTextbox.BackColor = Color.Red;
                    duplicateWarningLabel.Visible = true;
            }
            else
            {
                internalNameTextbox.BackColor = SystemColors.Window;
                duplicateWarningLabel.Visible = false;
            }
        }

        /* the event for product family combobox change that determine the active and website flag for the design */
        private void productFamilyCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // the case if the selection is nothing
            if (productFamilyCombobox.SelectedIndex < 1) return; 

            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                SqlCommand command = new SqlCommand("SELECT Active FROM ref_Families WHERE Design_Service_Family_Description = \'" + productFamilyCombobox.SelectedItem.ToString().Replace("'", "''") + '\'', connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                // the case of inactive family -> set design to inactive and website to false
                if (!reader.GetBoolean(0))
                {
                    activeCheckbox.Enabled = false;
                    activeCheckbox.Checked = false;
                    displayedOnWebsiteCombobox.Enabled = false;
                    displayedOnWebsiteCombobox.SelectedIndex = 1;
                }
                else
                {
                    activeCheckbox.Enabled = true;
                    displayedOnWebsiteCombobox.Enabled = true;
                }
            }
        }

        #region Translate Button 1 Event
        /* the event for the first translate button that translate English to French */
        private void translateButton1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate1.IsBusy)
                backgroundWorkerTranslate1.RunWorkerAsync();
        }
        private void backgroundWorkerTranslate1_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (shortEnglishDescriptionTextbox.Text == "" && extendedEnglishDescriptionTextbox.Text == "" && trendEnglishExtendedTextbox.Text == "" && trendEnglishShortTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // down to business, this is for short description
            if (shortEnglishDescriptionTextbox.Text != "")
                shortFrenchDescription = Translate.NowTranslate(shortEnglishDescriptionTextbox.Text);

            // this is for extended description
            if (extendedEnglishDescriptionTextbox.Text != "")
                extendedFrenchDescription = Translate.NowTranslate(extendedEnglishDescriptionTextbox.Text);

            // this is for trend short description
            if (trendEnglishShortTextbox.Text != "")
                trendShortFrenchDescription = Translate.NowTranslate(trendEnglishShortTextbox.Text);

            // this is for trend extended description
            if (trendEnglishExtendedTextbox.Text != "")
                trendExtendedFrenchDescription = Translate.NowTranslate(trendEnglishExtendedTextbox.Text);
        }
        private void backgroundWorkerTranslate1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;

            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;

            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            trendFrenchShortTextbox.Text = trendShortFrenchDescription;

            if (Translate.Error)
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                trendFrenchExtendedTextbox.Text = trendExtendedFrenchDescription;
        }
        #endregion

        /* online button clicks that allow user to edit design online description */
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Online online = new Online("Design Online Description", designOnlineEnglish, designOnlineFrench, Color.Green);
            online.ShowDialog(this);

            // set color online 
            if (online.DialogResult != DialogResult.OK) return;

            designOnlineEnglish = online.English;
            designOnlineFrench = online.French;
        }

        /* bag detail button clicks that allow user to edit more fields for design */
        private void bagDetailButton_Click(object sender, EventArgs e)
        {
            BagDetail detail = new BagDetail(shoulderDropLength, handleStrapDropLength, notableStrapGeneralFeatures, protectiveFeet, closure, innerPocket, outsidePocket, sizeDifferentiation, Color.Green, Color.White);
            detail.ShowDialog(this);

            // set color online 
            if (detail.DialogResult != DialogResult.OK) return;

            // allocate data
            shoulderDropLength = detail.ShoulderDropLength;
            handleStrapDropLength = detail.HandleStrapDropLength;
            notableStrapGeneralFeatures = detail.NotableStrapGeneralFeatures;
            protectiveFeet = detail.ProtectiveFeet;
            closure = detail.Closure;
            innerPocket = detail.InnerPocket;
            outsidePocket = detail.OutsidePocket;
            sizeDifferentiation = detail.SizeDifferentiation;
        }

        #region Translate Button 2 Event
        /* the background worker for translate button 2 */
        private void translateButton2_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate2.IsBusy)
                backgroundWorkerTranslate2.RunWorkerAsync();
        }
        private void backgroundWorkerTranslate2_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (option1EnglishTextbox.Text == "" && option2EnglishTextbox.Text == "" && option3EnglishTextbox.Text == "" && option4EnglishTextbox.Text == "" && option5EnglishTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // down to business, this is for the first option
            if (option1EnglishTextbox.Text != "")
                frenchOption[0] = Translate.NowTranslate(option1EnglishTextbox.Text);

            // this is for the second option
            if (option2EnglishTextbox.Text != "")
                frenchOption[1] = Translate.NowTranslate(option2EnglishTextbox.Text);

            // this is for the third option
            if (option3EnglishTextbox.Text != "")
                frenchOption[2] = Translate.NowTranslate(option3EnglishTextbox.Text);

            // this is for the fourth option
            if (option4EnglishTextbox.Text != "")
                frenchOption[3] = Translate.NowTranslate(option4EnglishTextbox.Text);

            // this is for the fifth option
            if (option5EnglishTextbox.Text != "")
                frenchOption[4] = Translate.NowTranslate(option5EnglishTextbox.Text);
        }
        private void backgroundWorkerTranslate2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            option1FrenchTextbox.Text = frenchOption[0];

            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            option2FrenchTextbox.Text = frenchOption[1];

            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            option3FrenchTextbox.Text = frenchOption[2];

            if (Translate.Error)
            {
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            option4FrenchTextbox.Text = frenchOption[3];

            if (Translate.Error)
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                option5FrenchTextbox.Text = frenchOption[4];
        }
        #endregion

        /* a method that turn boolean from the user input to 1 or 0 */
        private void CalculateTrueAndFalse()
        {
            // get the selected true or false from comboboxes
            boolean[0] = monogrammedCombobox.SelectedItem.ToString();
            boolean[1] = imprintedCombobox.SelectedItem.ToString();
            boolean[2] = strapCombobox.SelectedItem.ToString();
            boolean[3] = detachableCombobox.SelectedItem.ToString();
            boolean[4] = zippedCombobox.SelectedItem.ToString();
            boolean[5] = shippedFlatCombobox.SelectedItem.ToString();
            boolean[6] = shippedFoldedCombobox.SelectedItem.ToString();
            boolean[7] = displayedOnWebsiteCombobox.SelectedItem.ToString();

            // loop through to determine 1 or 0
            for (int i = 0; i < 8; i++)
                integer[i] = boolean[i] == "True" ? 1 : 0;

            // special cases for active and gift box
            integer[8] = active ? 1 : 0;
            integer[9] = giftCheckbox.Checked ? 1 : 0;
        }

        /* the event for imprinted combobox selected item changed that change imprint dimensions enability*/
        private void imprintedCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (imprintedCombobox.SelectedItem.ToString() == "False")
            {
                imprintHeightTextbox.Enabled = false;
                imprintWidthTextbox.Enabled = false;
                imprintHeightTextbox.Text = string.Empty;
                imprintWidthTextbox.Text = string.Empty;
            }
            else
            {
                imprintHeightTextbox.Enabled = true;
                imprintWidthTextbox.Enabled = true;
            }
        }

        #region Shipped Flat and Shipped Folded Comboboxes Event
        /* the event for shipped property combobox selected item changed that change the other shipped property's combobox enability*/
        private void shippedFlatCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (shippedFlatCombobox.SelectedItem.ToString() == "True")
            {
                shippedFoldedCombobox.Enabled = false;
                isFlat = true;

                // calculate flat value for shippable width
                if (shippableWidthTextbox.Text != "")
                    shippableWidthTextbox.Text = (Convert.ToDouble(shippableWidthTextbox.Text) * 1.2).ToString(CultureInfo.InvariantCulture);

                // calculate flat value for shippable depth
                if (shippableWidthTextbox.Text != "")
                    shippableDepthTextbox.Text = (Convert.ToDouble(shippableDepthTextbox.Text) * 0.3).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                shippedFoldedCombobox.Enabled = true;
                isFlat = false;

                shippableWidthTextbox.Text = productWidthTextbox.Text;
                shippableDepthTextbox.Text = productDepthTextbox.Text;
            }
        }
        private void shippedFoldedCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (shippedFoldedCombobox.SelectedItem.ToString() == "True")
            {
                shippedFlatCombobox.Enabled = false;
                shippableHeightTextbox.Enabled = true;
                shippableWidthTextbox.Enabled = true;
                shippableDepthTextbox.Enabled = true;
                isFolded = true;

                shippableHeightTextbox.Text = string.Empty;
                shippableWidthTextbox.Text = string.Empty;
                shippableDepthTextbox.Text = string.Empty;
                shippableWeightTextbox.Text = string.Empty;
            }
            else
            {
                shippedFlatCombobox.Enabled = true;
                shippableHeightTextbox.Enabled = false;
                shippableWidthTextbox.Enabled = false;
                shippableDepthTextbox.Enabled = false;
                isFolded = false;

                shippableWeightTextbox.Text = string.Empty;
                shippableHeightTextbox.Text = productHeightTextbox.Text;
                shippableWidthTextbox.Text = productWidthTextbox.Text;
                shippableDepthTextbox.Text = productDepthTextbox.Text;
            }
        }
        #endregion

        #region Imprint Dimensions Textboxes Keypress Event 
        /* the keypress event for imprint dimensions textbox that only allow numbers */
        private void imprintHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void imprintWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        #endregion

        #region Product Dimensions Textboxes Event
        /* the event for product dimension textbox text changed that show the correspond value in shippable deimension textbox */
        private void productHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFolded) // normal situation
                shippableHeightTextbox.Text = productHeightTextbox.Text;
        }
        private void productWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFlat && !isFolded) // normal situation
                shippableWidthTextbox.Text = productWidthTextbox.Text;
            else if (isFlat && productWidthTextbox.Text != "") // is flat, calculate the flat value of width
                shippableWidthTextbox.Text = (Convert.ToDouble(productWidthTextbox.Text)*1.2).ToString(CultureInfo.InvariantCulture);
        }
        private void productDepthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFlat && !isFolded) // normal situation
                shippableDepthTextbox.Text = productDepthTextbox.Text;
            else if (isFlat && productDepthTextbox.Text != "") // is flat, calculate the flat value of depth
                shippableDepthTextbox.Text = (Convert.ToDouble(productDepthTextbox.Text)*0.3).ToString(CultureInfo.InvariantCulture);
        }
        #endregion

        #region Product Dimensions Textboxes Keypress Event
        /* the restriction on product dimension textboxes that only allow numbers */
        private void productHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void productWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void productDepthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        #endregion

        #region Shippable Dimensions Textboxes Event
        /* the event when shippable dimension textbox text change that calculate the shippable weight if all fields are filled */
        private void shippableHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
                shippableWeightTextbox.Text = (Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text) / 6).ToString(CultureInfo.InvariantCulture);
            else
                shippableWeightTextbox.Text = string.Empty;
        }
        private void shippableWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
                shippableWeightTextbox.Text = (Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text) / 6).ToString(CultureInfo.InvariantCulture);
            else
                shippableWeightTextbox.Text = string.Empty;
        }
        private void shippableDepthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
                shippableWeightTextbox.Text = (Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text) / 6).ToString(CultureInfo.InvariantCulture);
            else
                shippableWeightTextbox.Text = string.Empty;
        }
        #endregion

        #region Shippable Dimensions Textboxes Keypress Event
        /* the restriction on shippable dimension textboxes that only allow numbers */
        private void shippableHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void shippableWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void shippableDepthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        #endregion

        /* active checkbox checked change that determine if the design can be show on website */
        private void activeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (activeCheckbox.Checked)
            {
                displayedOnWebsiteCombobox.SelectedIndex = boolean[7].Equals("True") ? 0 : 1;
                displayedOnWebsiteCombobox.Enabled = true;
            }
            else
            {
                displayedOnWebsiteCombobox.SelectedIndex = 1;
                displayedOnWebsiteCombobox.Enabled = false;
            }
        }

        #region Update Button Click Event 
        /* the event for update design button */
        private void updateDesignButton_Click(object sender, EventArgs e)
        {
            // get data from user input
            designServiceCode = designCodeCombobox.SelectedItem.ToString();
            productFamily = productFamilyCombobox.SelectedItem.ToString();
            designServiceFlag = designServiceFlagCombobox.SelectedItem.ToString();
            country = countryCombobox.SelectedItem.ToString();
            CalculateTrueAndFalse();

            // call background worker, the update button will only be activated if vaild design service code has been selected, so no need to check
            if (!backgroundWorkerUpdate.IsBusy)
                backgroundWorkerUpdate.RunWorkerAsync();
        }
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 30%
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            // get data from user input
            internalName = internalNameTextbox.Text.Replace("'", "''");
            shortEnglishDescription = shortEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            extendedEnglishDescription = extendedEnglishDescriptionTextbox.Text.Replace("'", "''");
            extendedFrenchDescription = extendedFrenchDescriptionTextbox.Text.Replace("'", "''");
            trendShortEnglishDescription = trendEnglishShortTextbox.Text.Replace("'", "''");
            trendShortFrenchDescription = trendFrenchShortTextbox.Text.Replace("'", "''");
            trendExtendedEnglishDescription = trendEnglishExtendedTextbox.Text.Replace("'", "''");
            trendExtendedFrenchDescription = trendFrenchExtendedTextbox.Text.Replace("'", "''");
            imprintHeight = imprintHeightTextbox.Text;
            if (imprintHeight == "") imprintHeight = "NULL";
            imprintWidth = imprintWidthTextbox.Text;
            if (imprintWidth == "") imprintWidth = "NULL";
            productHeight = productHeightTextbox.Text;
            if (productHeight == "") productHeight = "NULL";
            productWidth = productWidthTextbox.Text;
            if (productWidth == "") productWidth = "NULL";
            productDepth = productDepthTextbox.Text;
            if (productDepth == "") productDepth = "NULL";
            weight = weightTextBox.Text;
            if (weight == "") weight = "NULL";
            numberComponents = numberComponentTextbox.Text;
            if (numberComponents == "") numberComponents = "NULL";
            shippableHeight = shippableHeightTextbox.Text;
            if (shippableHeight == "") shippableHeight = "NULL";
            shippableWidth = productWidthTextbox.Text;
            if (shippableWidth == "") shippableWidth = "NULL";
            shippableDepth = shippableDepthTextbox.Text;
            if (shippableDepth == "") shippableDepth = "NULL";
            shippableWeight = shippableWeightTextbox.Text;
            if (shippableWeight == "") shippableWeight = "NULL";
            tsc = tscTextbox.Text.Replace("'", "''");
            theBay = theBayTextbox.Text.Replace("'", "''");
            bestbuy = bestbuyTextbox.Text.Replace("'", "''");
            shopca = shopcaTextbox.Text.Replace("'", "''");
            amazon = amazonTextbox.Text.Replace("'", "''");
            sears = searsTextbox.Text.Replace("'", "''");
            staples = staplesTextbox.Text.Replace("'", "''");
            walmart = walmartTextbox.Text.Replace("'", "''");
            englishOption[0] = option1EnglishTextbox.Text.Replace("'", "''");
            englishOption[1] = option2EnglishTextbox.Text.Replace("'", "''");
            englishOption[2] = option3EnglishTextbox.Text.Replace("'", "''");
            englishOption[3] = option4EnglishTextbox.Text.Replace("'", "''");
            englishOption[4] = option5EnglishTextbox.Text.Replace("'", "''");
            frenchOption[0] = option1FrenchTextbox.Text.Replace("'", "''");
            frenchOption[1] = option2FrenchTextbox.Text.Replace("'", "''");
            frenchOption[2] = option3FrenchTextbox.Text.Replace("'", "''");
            frenchOption[3] = option4FrenchTextbox.Text.Replace("'", "''");
            frenchOption[4] = option5FrenchTextbox.Text.Replace("'", "''");
            productFamily = productFamily.Replace("'", "''");
            active = activeCheckbox.Checked;

            // addition field (I don't really know what this field is for ==! )
            string designUrl = "https://www.ashlinbpg.com/index.php/" + designServiceCode + "/html";

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            try
            {
                // connect to database and insert new row
                using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
                {
                    // this is for searching family code for product family
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_Service_Family_Description = \'" + productFamily + '\'', connection);
                    connection.Open();
                    adapter.Fill(table);

                    // this is the real thing
                    SqlCommand command = new SqlCommand("UPDATE master_Design_Attributes SET Brand='Ashlin®',GiftBox=" + integer[9] + ",Design_Service_Flag=\'" + designServiceFlag + "\',Design_Service_Family_Code =\'" + table.Rows[0][0].ToString() + "\', Design_Service_Fashion_Name_Ashlin = \'" + internalName + "\', Design_Service_Fashion_Name_TSC_CA = \'" + tsc + "\',Design_Service_Fashion_Name_THE_BAY=\'" + theBay + "\', Design_Service_Fashion_Name_BESTBUY_CA=\'" + bestbuy + "\',Design_Service_Fashion_Name_SHOP_CA=\'" + shopca + "\',Design_Service_Fashion_Name_AMAZON_CA=\'" + amazon + "\',Design_Service_Fashion_Name_AMAZON_COM=\'" + amazon + "\',Design_Service_Fashion_Name_SEARS_CA = \'" + sears + "\',Design_Service_Fashion_Name_STAPLES_CA = \'" + staples + "\',Design_Service_Fashion_Name_WALMART = \'" + walmart + "\', Short_Description = \'" + shortEnglishDescription + "\', Short_Description_FR = \'" + shortFrenchDescription + "\', Extended_Description = \'" + extendedEnglishDescription + "\', Extended_Description_FR = \'" + extendedFrenchDescription + "\', Imprintable = " + integer[1] + ", Imprint_Height_cm = " + imprintHeight + ", Imprint_Width_cm = " + imprintWidth + ", Width_cm = " + productWidth + ", Height_cm = " + productHeight + ", Depth_cm = " + productDepth + ", Weight_grams = " + weight + ", Active = \'" + active
                                                      + "\',Flat_Shippable=" + integer[5] + ",Fold_Shippable=" + integer[6] + ",Shippable_Width_cm=" + shippableWidth + ",Shippable_Height_cm=" + shippableHeight + ",Shippable_Depth_cm=" + shippableDepth + ", Shippable_Weight_grams = " + shippableWeight + ", Components = " + numberComponents + ", Strap = " + integer[2] + ",Detachable_Strap = " + integer[3] + ",Zippered_Enclosure=" + integer[4] + ",Option_1 =\'" + englishOption[0] + "\',Option_1_FR=\'" + frenchOption[0] + "\',Option_2 =\'" + englishOption[1] + "\',Option_2_FR=\'" + frenchOption[1] + "\',Option_3=\'" + englishOption[2] + "\',Option_3_FR=\'" + frenchOption[2] + "\',Option_4=\'" + englishOption[3] + "\',Option_4_FR = \'" + frenchOption[3] + "\',Option_5=\'" + englishOption[4] + "\',Option_5_FR = \'" + frenchOption[4] + "\', Website_Flag = " + integer[7] + ",Date_Updated =\'" + DateTime.Today.ToString("yyyy-MM-dd") + "\',Design_URL =\'" + designUrl + "\',Trend_Short_Description=\'" + trendShortEnglishDescription + "\',Trend_Short_Description_FR=\'" + trendShortFrenchDescription + "\',Trend_Extended_Description=\'" + trendExtendedEnglishDescription + "\',Trend_Extended_Description_FR=\'" + trendExtendedFrenchDescription + "\',Design_Online=\'" + designOnlineEnglish.Replace("'", "''") + "\',Design_Online_FR=\'" + designOnlineFrench.Replace("'", "''")
                                                      + "\',Country=\'" + country + "\',ShoulderDropLength=" + shoulderDropLength + ",HandleStrapDropLength=" + handleStrapDropLength + ",NotableStrapGeneralFeatures=\'" + notableStrapGeneralFeatures + "\',ProtectiveFeet=\'" + protectiveFeet + "\',Closure=\'" + closure + "\',InnerPocket=\'" + innerPocket + "\',OutsidePocket=\'" + outsidePocket + "\',SizeDifferentiation=\'" + sizeDifferentiation + "\' WHERE Design_Service_Code = \'" + designServiceCode + '\'', connection);
                    command.ExecuteNonQuery();

                    // the case if the design is not active or not on website -> set all the SKUs' website flag to false that associate with this design
                    if (!active)
                    {
                        command.CommandText = "UPDATE master_SKU_Attributes SET Active = 'False', SKU_Website = 'False' WHERE Design_Service_Code = \'" + designServiceCode + '\'';
                        command.ExecuteNonQuery();
                    }
                    else if (integer[7] == 0)
                    {
                        command.CommandText = "UPDATE master_SKU_Attributes SET SKU_Website = 'False' WHERE Design_Service_Code = \'" + designServiceCode + '\'';
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happen during database updating: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // simulate progress 60% ~ 100%
            for (int i = 60; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }
        }
        private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive List Buttons Event
        /* the event for active and inactive list button that open the table of active design list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new ActiveDesignList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new InactiveDesignList().ShowDialog(this);
        }
        #endregion
    }
}
