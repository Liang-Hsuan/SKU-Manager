using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;
using System.Collections.Generic;

namespace SKU_Manager.SplashModules.Add
{
    /*
     * An application module to add new design to SKU database
     */
    public partial class AddDesign : Form
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
        private string[] boolean = new string[8];    // [0] for monogrammed, [1] for imprinted, [2] for strap, [3] for detachable, [4] for zipped, [5] for shipped flat, [6] for shipped folded, [7] for displayed website
        private int[] integer = new int[9];    // corresponding to the field above
        private string imprintHeight;
        private string imprintWidth;
        private string productHeight;
        private string productWidth;
        private string productDepth;
        private string weight;
        private string numberComponents;
        private string shippableHeight;
        private string shippableWidth;
        private string shippableDepth;
        private string shippableWeight;
        private string tsc;
        private string costco;
        private string bestbuy;
        private string shopca;
        private string amazon;
        private string sears;
        private string staples;
        private string walmart;
        private string[] englishOption = new string[5];
        private string[] frenchOption = new string[5];
        private bool active = true;    // default set to true

        // supporting boolean flag -> set to default
        private bool isFlat = false;
        private bool isFolded = false;

        // field for comboBox
        private ArrayList productFamilyList = new ArrayList();
        private List<string> internalNameList = new List<string>();

        // connection string to the database
        private string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic component */
        public AddDesign()
        {
            InitializeComponent();

            // call background worker
            if (!backgroundWorkerCombobox.IsBusy)
            {
                backgroundWorkerCombobox.RunWorkerAsync();
            }
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for Product Family
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Design_Service_Family_Description FROM ref_Families WHERE Design_Service_Family_Description != \'\' ORDER BY Design_Service_Family_Description;", connection);   
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productFamilyList.Add(reader.GetString(0));
                }
                reader.Close();

                // additional addition for ashlin internal name checking
                command = new SqlCommand("SELECT Design_Service_Fashion_Name_Ashlin FROM master_Design_Attributes;", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    internalNameList.Add(reader.GetString(0));
                }
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            productFamilyCombobox.DataSource = productFamilyList;
        }
        #endregion

        /* the event for design service code textbox that will change the back color of the textbox */
        private void designServiceCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            designServiceCodeTextbox.BackColor = SystemColors.Window;
        }

        /* the event of internal ashlin name textbox that detect whether the user input has duplicate */
        private void internalNameTextbox_TextChanged(object sender, EventArgs e)
        {
            bool found = false;

            if (internalNameTextbox.Text != "")
            {
                foreach (string name in internalNameList)
                {
                    if (internalNameTextbox.Text == name)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
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
        }

        /* the event for design service flag combobox change that change the enability of some textboxes */
        private void designServiceFlagCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (designServiceFlagCombobox.SelectedIndex == 0)
            {
                tscTextbox.Enabled = true;
                costcoTextbox.Enabled = true;
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
                numberComponentTextbox.Enabled = true;
                strapCombobox.Enabled = true;
                detachableCombobox.Enabled = true;
                zippedCombobox.Enabled = true;
                shippedFlatCombobox.Enabled = true;
                shippedFoldedCombobox.Enabled = true;
                shippableHeightTextbox.Enabled = true;
                shippableWidthTextbox.Enabled = true;
                shippableDepthTextbox.Enabled = true;
            }
            else
            {
                tscTextbox.Enabled = false;
                costcoTextbox.Enabled = false;
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
                numberComponentTextbox.Enabled = false;
                strapCombobox.Enabled = false;
                detachableCombobox.Enabled = false;
                zippedCombobox.Enabled = false;
                shippedFlatCombobox.Enabled = false;
                shippedFoldedCombobox.Enabled = false;
                shippableHeightTextbox.Enabled = false;
                shippableWidthTextbox.Enabled = false;
                shippableDepthTextbox.Enabled = false;
            }
        }

        #region Translate Button 1 Event
        /* the event for the first translate button that translate English to French */
        private void translateButton1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate1.IsBusy)
            {
                backgroundWorkerTranslate1.RunWorkerAsync();
            }
        }
        private void backgroundWorkerTranslate1_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (shortEnglishDescriptionTextbox.Text == "" && extendedEnglishDescriptionTextbox.Text == "" && trendShortEnglishTextbox.Text == "" && trendExtendedEnglishTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // initialize a Translation class for translation
            Translate translate = new Translate();

            // down to business, this is for short description
            if (shortEnglishDescriptionTextbox.Text != "")
            {
                translate.nowTranslate(shortEnglishDescriptionTextbox.Text);
                shortFrenchDescription = translate.getFrench();
            }

            // this is for extended description
            if (extendedEnglishDescriptionTextbox.Text != "")
            {
                translate.nowTranslate(extendedEnglishDescriptionTextbox.Text);
                extendedFrenchDescription = translate.getFrench();
            }

            // this is for trend short description
            if (trendShortEnglishTextbox.Text != "")
            {
                translate.nowTranslate(trendShortEnglishTextbox.Text);
                trendShortFrenchDescription = translate.getFrench();
            }

            // this is for trend extended description
            if (trendExtendedEnglishTextbox.Text != "")
            {
                translate.nowTranslate(trendExtendedEnglishTextbox.Text);
                trendExtendedFrenchDescription = translate.getFrench();
            }
        }
        private void backgroundWorkerTranslate1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
            trendShortFrenchTextbox.Text = trendShortFrenchDescription;
            trendExtendedFrenchTextbox.Text = trendExtendedFrenchDescription;
        }
        #endregion

        #region Translate Button 2 Event
        /* the event for the second translate button that translate English to French */
        private void translateButton2_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate2.IsBusy)
            {
                backgroundWorkerTranslate2.RunWorkerAsync();
            }

        }
        private void backgroundWorkerTranslate2_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (option1EnglishTextbox.Text == "" && option2EnglishTextbox.Text == "" && option3EnglishTextbox.Text == "" && option4EnglishTextbox.Text == "" && option5EnglishTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // initialize a Translation class for translation
            Translate translate = new Translate();

            // down to business, this is for the first option
            if (option1EnglishTextbox.Text != "")
            {
                translate.nowTranslate(option1EnglishTextbox.Text);
                englishOption[0] = translate.getFrench();
            }

            // this is for the second option
            if (option2EnglishTextbox.Text != "")
            {
                translate.nowTranslate(option2EnglishTextbox.Text);
                englishOption[1] = translate.getFrench();
            }

            // this is for the third option
            if (option3EnglishTextbox.Text != "")
            {
                translate.nowTranslate(option3EnglishTextbox.Text);
                englishOption[2] = translate.getFrench();
            }

            // this is for the fourth option
            if (option4EnglishTextbox.Text != "")
            {
                translate.nowTranslate(option4EnglishTextbox.Text);
                englishOption[3] = translate.getFrench();
            }

            // this is for the fifth option
            if (option5EnglishTextbox.Text != "")
            {
                translate.nowTranslate(option5EnglishTextbox.Text);
                englishOption[4] = translate.getFrench();
            }
        }
        private void backgroundWorkerTranslate2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            option1FrenchTextbox.Text = englishOption[0];
            option2FrenchTextbox.Text = englishOption[1];
            option3FrenchTextbox.Text = englishOption[2];
            option4FrenchTextbox.Text = englishOption[3];
            option5FrenchTextbox.Text = englishOption[4];
        }
        #endregion

        /* a method that turn boolean from the user input to 1 or 0 */
        private void calculateTrueAndFalse()
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
            {
                if (boolean[i] == "True")
                {
                    integer[i] = 1;
                }
                else
                {
                    integer[i] = 0;
                }
            }

            // special case for active
            if (active)
            {
                integer[8] = 1;
            }
            else
            {
                integer[8] = 0;
            }
        }

        #region Add Design Button Event
        /* the event for add design button */
        private void addDesignButton_Click(object sender, EventArgs e)
        {
            if (designServiceCodeTextbox.Text == "")
            {
                designServiceCodeTextbox.BackColor = Color.Red;
                MessageBox.Show("Please provide the Design Service Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get data from user input
            productFamily = productFamilyCombobox.SelectedItem.ToString();
            designServiceFlag = designServiceFlagCombobox.SelectedItem.ToString();
            calculateTrueAndFalse();

            if (!backgroundWorkerAddDesign.IsBusy)
            {
                backgroundWorkerAddDesign.RunWorkerAsync();
            }
        }
        private void backgroundWorkerAddDesign_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 30%
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddDesign.ReportProgress(i);
            }

            // get data from user input
            designServiceCode = designServiceCodeTextbox.Text;
            internalName = internalNameTextbox.Text.Replace("'", "''");
            shortEnglishDescription = shortEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            extendedEnglishDescription = extendedEnglishDescriptionTextbox.Text.Replace("'", "''");
            extendedFrenchDescription = extendedFrenchDescriptionTextbox.Text.Replace("'", "''");
            trendShortEnglishDescription = trendShortEnglishTextbox.Text.Replace("'", "''");
            trendShortFrenchDescription = trendShortFrenchTextbox.Text.Replace("'", "''");
            trendExtendedEnglishDescription = trendExtendedEnglishTextbox.Text.Replace("'", "''");
            trendExtendedFrenchDescription = trendExtendedFrenchTextbox.Text.Replace("'", "''");
            imprintHeight = imprintHeightTextbox.Text;
            if (imprintHeight == "")
                imprintHeight = "NULL";
            imprintWidth = imprintWidthTextbox.Text;
            if (imprintWidth == "")
                imprintWidth = "NULL";
            productHeight = productHeightTextbox.Text;
            if (productHeight == "")
                productHeight = "NULL";
            productWidth = productWidthTextbox.Text;
            if (productWidth == "")
                productWidth = "NULL";
            productDepth = productDepthTextbox.Text;
            if (productDepth == "")
                productDepth = "NULL";
            weight = weightTextBox.Text;
            if (weight == "")
                weight = "NULL";
            numberComponents = numberComponentTextbox.Text;
            if (numberComponents == "")
                numberComponents = "NULL";
            shippableHeight = shippableHeightTextbox.Text;
            if (shippableHeight == "")
                shippableHeight = "NULL";
            shippableWidth = productWidthTextbox.Text;
            if (shippableWidth == "")
                shippableWidth = "NULL";
            shippableDepth = shippableDepthTextbox.Text;
            if (shippableDepth == "")
                shippableDepth = "NULL";
            shippableWeight = shippableWeightTextbox.Text;
            if (shippableWeight == "")
                shippableWeight = "NULL";
            tsc = tscTextbox.Text.Replace("'", "''");
            costco = costcoTextbox.Text.Replace("'", "''");
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
            if (productFamily.Contains("'"))
            {
                productFamily = productFamily.Replace("'", "''");
            }

            // addition field (I don't really know what this field is for ==! )
            string designUrl = "https://www.ashlinbpg.com/index.php/" + designServiceCode + "/html";

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddDesign.ReportProgress(i);
            }

            // connect to database and insert new row
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // this is for searching family code for product family
                SqlCommand command = new SqlCommand("SELECT Design_Service_Family_Code FROM ref_Families WHERE Design_service_Family_Description = \'" + productFamily + "\';", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                // this is the real thing
                command = new SqlCommand("INSERT INTO master_Design_Attributes (Design_Service_Code, Brand, Design_Service_Flag, Design_Service_Family_Code, Design_Service_Fashion_Name_Ashlin, Design_Service_Fashion_Name_TSC_CA, Design_Service_Fashion_Name_COSTCO_CA, Design_Service_Fashion_Name_BESTBUY_CA, Design_Service_Fashion_Name_SHOP_CA, Design_Service_Fashion_Name_AMAZON_CA, Design_Service_Fashion_Name_AMAZON_COM, Design_Service_Fashion_Name_SEARS_CA, Design_Service_Fashion_Name_STAPLES_CA, Design_Service_Fashion_Name_WALMART, Short_Description, Short_Description_FR, Extended_Description, Extended_Description_FR, Trend_Short_Description, Trend_Short_Description_FR, Trend_Extended_Description, Trend_Extended_Description_FR, Imprintable, Imprint_Height_cm, Imprint_Width_cm, Width_cm, Height_cm, Depth_cm, Weight_grams, Flat_Shippable, Fold_Shippable, Shippable_Width_cm, Shippable_Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Components, Strap, Detachable_Strap, Zippered_Enclosure, Option_1, Option_1_FR, Option_2, Option_2_FR, Option_3, Option_3_FR, Option_4, Option_4_FR, Option_5, Option_5_FR, Website_Flag, Active, Date_Added, Design_URL, Monogram) "
                                       + "VALUES (\'" + designServiceCode + "\', \'Ashlin®\', \'" + designServiceFlag + "\', \'" + reader.GetString(0) + "\', \'" + internalName + "\', \'" + tsc + "\', \'" + costco + "\', \'" + bestbuy + "\', \'" + shopca + "\', \'" + amazon + "\', \'" + amazon + "\', \'" + sears + "\', \'" + staples + "\', \'" + walmart + "\', \'" + shortEnglishDescription + "\', \'" + shortFrenchDescription + "\', \'" + extendedEnglishDescription + "\', \'" + extendedFrenchDescription + "\', \'" + trendShortEnglishDescription + "\', \'" + trendShortFrenchDescription + "\', \'" + trendExtendedEnglishDescription + "\', \'" + trendExtendedFrenchDescription + "\', " + integer[1] + ", " + imprintHeight + ", " + imprintWidth + ", " + productWidth + ", " + productHeight + ", " + productDepth + ", " + weight + ", " + integer[5] + ", " + integer[6] + ", " + shippableWidth + ", " + shippableHeight + ", " + shippableDepth + ", " + shippableWeight + ", " + numberComponents + ", " + integer[2] + ", " + integer[3] + ", " + integer[4] + ", \'" + englishOption[0] + "\', \'" + frenchOption[0] + "\', \'" + englishOption[1] + "\', \'" + frenchOption[1] + "\', \'" + englishOption[2] + "\', \'" + frenchOption[2] + "\', \'" + englishOption[3] + "\', \'" + frenchOption[3] + "\', \'" + englishOption[4] + "\', \'" + frenchOption[4] + "\', " + integer[7] + ", " + integer[8] + ", \'" + DateTime.Now.ToString() + "\', \'" + designUrl + "\', " + integer[0] + ");", connection);
                reader.Close();
                command.ExecuteNonQuery();
            }

            // simulate progress 60% ~ 100%
            for (int i = 60; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddDesign.ReportProgress(i);
            }
        }
        private void backgroundWorkerAddDesign_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive Buttons Event
        /* the event for active and inactive buttons click */
        private void activeDesignButton_Click(object sender, EventArgs e)
        {
            active = true;    // make active true

            // set buttons enability
            activeDesignButton.Enabled = false;
            inactiveDesignButton.Enabled = true;

            this.AutoScrollPosition = new Point(1434, 790);
        }
        private void inactiveDesignButton_Click(object sender, EventArgs e)
        {
            active = false;    // make active false

            // set buttons enability
            inactiveDesignButton.Enabled = false;
            activeDesignButton.Enabled = true;

            this.AutoScrollPosition = new Point(1434, 790);
        }
        #endregion

        /* the event for imprinted combobox selected item changed that change imprint dimensions enability*/
        private void imprintedCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (imprintedCombobox.SelectedItem.ToString() == "False")
            {
                imprintHeightTextbox.Enabled = false;
                imprintWidthTextbox.Enabled = false;
                imprintHeightTextbox.Text = "";
                imprintWidthTextbox.Text = "";
            }
            else
            {
                imprintHeightTextbox.Enabled = true;
                imprintWidthTextbox.Enabled = true;
            }
        }

        #region Imprint Dimensions Textboxes Keypress Event
        /* the key press event for imprint dimensions textbox that only allow number */
        private void imprintHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void imprintWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Shipped Falt and Shipped Folded Comboboxes Event
        /* the event for shipped properties comboboxes selected value changed */
        private void shippedFlatCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (shippedFlatCombobox.SelectedItem.ToString() == "True")
            {
                shippedFoldedCombobox.Enabled = false;
                isFlat = true;

                // calculate flat value for shippable width
                if (shippableWidthTextbox.Text != "")
                {
                    shippableWidthTextbox.Text = (Convert.ToDouble(shippableWidthTextbox.Text) * 1.2).ToString();
                }

                // calculate flat value for shippable depth
                if (shippableWidthTextbox.Text != "")
                {
                    shippableDepthTextbox.Text = (Convert.ToDouble(shippableDepthTextbox.Text) * 0.3).ToString();
                }
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

                shippableHeightTextbox.Text = "";
                shippableWidthTextbox.Text = "";
                shippableDepthTextbox.Text = "";
                shippableWeightTextbox.Text = "";
            }
            else
            {
                shippedFlatCombobox.Enabled = true;
                shippableHeightTextbox.Enabled = false;
                shippableWidthTextbox.Enabled = false;
                shippableDepthTextbox.Enabled = false;
                isFolded = false;

                shippableWeightTextbox.Text = "";
                shippableHeightTextbox.Text = productHeightTextbox.Text;
                shippableWidthTextbox.Text = productWidthTextbox.Text;
                shippableDepthTextbox.Text = productDepthTextbox.Text;
            }
        }
        #endregion

        #region Product Dimensions Textboxes Text Change Event 
        /* the event for product dimension textboxes' text changed that show the correspond value in shippable dimension textboxes */
        private void productHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFolded)    // normal situation
            {
                shippableHeightTextbox.Text = productHeightTextbox.Text;
            }
        }
        private void productWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFlat && !isFolded)    // normal situation
            {
                shippableWidthTextbox.Text = productWidthTextbox.Text;
            }
            else if (isFlat && productWidthTextbox.Text != "")    // is flat, calculate the flat value of width
            {
                shippableWidthTextbox.Text = (Convert.ToDouble(productWidthTextbox.Text) * 1.2).ToString();
            }
        }
        private void productDepthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!isFlat && !isFolded)    // normal situation
            {
                shippableDepthTextbox.Text = productDepthTextbox.Text;
            }
            else if (isFlat && productDepthTextbox.Text != "")    // is flat, calculate the flat value of depth
            {
                shippableDepthTextbox.Text = (Convert.ToDouble(productDepthTextbox.Text) * 0.3).ToString();
            }
        }
        #endregion

        #region Product Dimensions Textboxes Keypress Event 
        /* the restriction for dimension textboxes that only allow numbers */
        private void productHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void productWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void productDepthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Shippable Dimensions Textboxes Text Change Event 
        /* the event when shippable dimensions textboxes' text change that calculate the shippable weight if all fields are filled */
        private void shippableHeightTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
            {
                shippableWeightTextbox.Text = Math.Round(((Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text)) / 6), 2).ToString();
            } 
            else
            {
                shippableWeightTextbox.Text = "";
            }
        }
        private void shippableWidthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
            {
                shippableWeightTextbox.Text = Math.Round(((Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text)) / 6), 2).ToString();
            }
            else
            {
                shippableWeightTextbox.Text = "";
            }
        }
        private void shippableDepthTextbox_TextChanged(object sender, EventArgs e)
        {
            if (shippableHeightTextbox.Text != "" && shippableWidthTextbox.Text != "" && shippableDepthTextbox.Text != "")
            {
                shippableWeightTextbox.Text = Math.Round(((Convert.ToDouble(shippableHeightTextbox.Text) * Convert.ToDouble(shippableWidthTextbox.Text) * Convert.ToDouble(shippableDepthTextbox.Text)) / 6), 2).ToString();
            }
            else
            {
                shippableWeightTextbox.Text = "";
            }
        }
        #endregion

        #region Shippable Dimension Textboxes Keypress Event
        /* the restriction for shippable dimension textboxes that only allow numbers */
        private void shippableHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void shippableWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void shippableDepthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
