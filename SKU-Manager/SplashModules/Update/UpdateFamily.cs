using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SplashModules.Update
{
   /*
    * An application module to update family to SKU database
    */
    public partial class UpdateFamily : Form
    {
        // fields for storing adding family data
        private string familyCode;
        private string shortEnglishDescription;
        private string shortFrenchDescription;
        private string generalKeywords;
        private string[] amazonKeywords = new string[5];
        private string[] amazonCaNode = new string[2];
        private string[] amazonComNode = new string[2];
        private string sageCategory;
        private string sageTheme;
        private string esp;
        private string promoMarketing;
        private string uducat;
        private string distributorCentral;
        private string caHts;
        private string usHts;
        private string caDuty;
        private string usDuty;
        private bool active = true;    // default is set to true

        // supporting boolean flag
        private bool firstTime = true;

        // fields for comboBoxes
        private readonly ArrayList familyCodeList = new ArrayList();
        private readonly ArrayList canadianHtsList = new ArrayList();
        private readonly ArrayList usHtsList = new ArrayList();
        private readonly ArrayList sageCategoryList = new ArrayList();
        private readonly ArrayList sageThemeList = new ArrayList();
        private readonly ArrayList espList = new ArrayList();
        private readonly ArrayList promoMarketingList = new ArrayList();
        private readonly ArrayList uducatList = new ArrayList();
        private readonly ArrayList distributorCentralList = new ArrayList();

        // connection string to the database
        private string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic component */
        public UpdateFamily()
        {
            InitializeComponent();
            familyCodeList.Add("");
            canadianHtsList.Add("");
            usHtsList.Add("");
            sageCategoryList.Add("");
            sageThemeList.Add("");
            espList.Add("");
            promoMarketingList.Add("");
            uducatList.Add("");
            distributorCentralList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for canadian HTS
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT HTS_CA FROM HTS_CA", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                canadianHtsList.Add(reader.GetValue(0));
            reader.Close();

            // make comboBox for us HTS
            command.CommandText = "SELECT HTS_US FROM HTS_US";
            reader = command.ExecuteReader();
            while (reader.Read())
                usHtsList.Add(reader.GetValue(0));
            reader.Close();

            // make lists for CATEGORY comboboxes
            command.CommandText = "SELECT Design_Service_Family_Category_Sage, Design_Service_Family_Themes_Sage, Design_Service_Family_Category_ESP, Design_Service_Family_Category_PromoMarketing, " +
                                  "Design_Service_Family_Category_UDUCAT, Design_Service_Family_Category_DistributorCentral " +
                                  "FROM list_online_product_categories";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    sageCategoryList.Add(reader.GetValue(0));
                if (!reader.IsDBNull(1))
                    sageThemeList.Add(reader.GetValue(1));
                if (!reader.IsDBNull(2))
                    espList.Add(reader.GetValue(2));
                if (!reader.IsDBNull(3))
                    promoMarketingList.Add(reader.GetValue(3));
                if (!reader.IsDBNull(4))
                    uducatList.Add(reader.GetValue(4));
                if (!reader.IsDBNull(5))
                    distributorCentralList.Add(reader.GetValue(5));
            }
            reader.Close();

            command.CommandText = "SELECT Design_Service_Family_Code FROM ref_Families";
            reader = command.ExecuteReader();
            while (reader.Read())
                familyCodeList.Add(reader.GetString(0));

            connection.Close();
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            productFamilyCombobox.DataSource = familyCodeList;
            canadianHtsCombobox.DataSource = canadianHtsList;
            usHtsCombobox.DataSource = usHtsList;
            sageCategoryCombobox.DataSource = sageCategoryList;
            sageThemeCombobox.DataSource = sageThemeList;
            espCombobox.DataSource = espList;
            promoMarketingCombobox.DataSource = promoMarketingList;
            uducatCombobox.DataSource = uducatList;
            distributorCentralCombobox.DataSource = distributorCentralList;
        }
        #endregion

        #region Info Generation
        /* the event for family product code combobox selected item changed that show the default tax price for this selected item */
        private void productFamilyCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the enability of the controls
            if (productFamilyCombobox.SelectedItem.ToString() != "")
            {
                familyCode = productFamilyCombobox.SelectedItem.ToString();

                translateButton.Enabled = true;
                shortEnglishDescriptionTextbox.Enabled = true;
                shortFrenchDescriptionTextbox.Enabled = true;
                generalKeywordsTextBox.Enabled = true;
                amazonKeywordsTextbox1.Enabled = true;
                amazonKeywordsTextbox2.Enabled = true;
                amazonKeywordsTextbox3.Enabled = true;
                amazonKeywordsTextbox4.Enabled = true;
                amazonKeywordsTextbox5.Enabled = true;
                amazonCaTextbox1.Enabled = true;
                amazonCaTextbox2.Enabled = true;
                amazonComTextbox1.Enabled = true;
                amazonComTextbox2.Enabled = true;
                canadianHtsCombobox.Enabled = true;
                usHtsCombobox.Enabled = true;
                sageCategoryCombobox.Enabled = true;
                addSageCategoryButton.Enabled = true;
                removeSageCategoryButton.Enabled = true;
                sageThemeCombobox.Enabled = true;
                addSageThemeButton.Enabled = true;
                removeSageThemeButton.Enabled = true;
                espCombobox.Enabled = true;
                addEspButton.Enabled = true;
                removeEspButton.Enabled = true;
                promoMarketingCombobox.Enabled = true;
                addPromoMarketingButton.Enabled = true;
                removePromoMarketingButton.Enabled = true;
                uducatCombobox.Enabled = true;
                addUducatButton.Enabled = true;
                removeUducatButton.Enabled = true;
                distributorCentralCombobox.Enabled = true;
                addDistributorCentralButton.Enabled = true;
                removeDistributorCentralButton.Enabled = true;
                updateFamilyButton.Enabled = true;
                activeCheckbox.Enabled = true;

                // set the comboboxes' text to first item
                sageCategoryCombobox.SelectedIndex = 1;
                sageThemeCombobox.SelectedIndex = 1;
                espCombobox.SelectedIndex = 1;
                promoMarketingCombobox.SelectedIndex = 1;
                uducatCombobox.SelectedIndex = 1;
                distributorCentralCombobox.SelectedIndex = 1;

                // set familyCode field from the selected item 
                familyCode = productFamilyCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                shortEnglishDescriptionTextbox.Text = "";
                shortFrenchDescriptionTextbox.Text = "";
                generalKeywordsTextBox.Text = "";
                amazonKeywordsTextbox1.Text = "";
                amazonKeywordsTextbox2.Text = "";
                amazonKeywordsTextbox3.Text = "";
                amazonKeywordsTextbox4.Text = "";
                amazonKeywordsTextbox5.Text = "";
                amazonCaTextbox1.Text = "";
                amazonCaTextbox2.Text = "";
                amazonCaTextbox1.Text = "";
                amazonCaTextbox2.Text = "";
                amazonComTextbox1.Text = "";
                amazonComTextbox2.Text = "";
                caDutyTextbox.Text = "";
                usDutyTextbox.Text = "";
                sageCategoryTextbox.Text = "";
                sageThemeTextbox.Text = "";
                espTextbox.Text = "";
                promoMarketingTextbox.Text = "";
                uducatTextbox.Text = "";
                distributorCentralTextbox.Text = "";

                // set the comboboxes' text to nothing
                canadianHtsCombobox.Text = "";
                usHtsCombobox.Text = "";
                sageCategoryCombobox.Text = "";
                sageThemeCombobox.Text = "";
                espCombobox.Text = "";
                promoMarketingCombobox.Text = "";
                uducatCombobox.Text = "";
                distributorCentralCombobox.Text = "";


                translateButton.Enabled = false;
                shortEnglishDescriptionTextbox.Enabled = false;
                shortFrenchDescriptionTextbox.Enabled = false;
                generalKeywordsTextBox.Enabled = false;
                amazonKeywordsTextbox1.Enabled = false;
                amazonKeywordsTextbox2.Enabled = false;
                amazonKeywordsTextbox3.Enabled = false;
                amazonKeywordsTextbox4.Enabled = false;
                amazonKeywordsTextbox5.Enabled = false;
                amazonCaTextbox1.Enabled = false;
                amazonCaTextbox2.Enabled = false;
                amazonComTextbox1.Enabled = false;
                amazonComTextbox2.Enabled = false;
                canadianHtsCombobox.Enabled = false;
                usHtsCombobox.Enabled = false;
                activeCheckbox.Enabled = false;
                sageCategoryCombobox.Enabled = false;
                addSageCategoryButton.Enabled = false;
                removeSageCategoryButton.Enabled = false;
                sageThemeCombobox.Enabled = false;
                addSageThemeButton.Enabled = false;
                removeSageThemeButton.Enabled = false;
                espCombobox.Enabled = false;
                addEspButton.Enabled = false;
                removeEspButton.Enabled = false;
                promoMarketingCombobox.Enabled = false;
                addPromoMarketingButton.Enabled = false;
                removePromoMarketingButton.Enabled = false;
                uducatCombobox.Enabled = false;
                addUducatButton.Enabled = false;
                removeUducatButton.Enabled = false;
                distributorCentralCombobox.Enabled = false;
                addDistributorCentralButton.Enabled = false;
                removeDistributorCentralButton.Enabled = false;
                updateFamilyButton.Enabled = false;
                activeCheckbox.Enabled = false;
            }

            if (firstTime)
            {
                AutoScrollPosition = new Point(0, 0);
                firstTime = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Family_Description, Design_Service_Family_Description_FR, Design_Service_Family_Keywords_General, KeyWords_Amazon_1, KeyWords_Amazon_2, KeyWords_Amazon_3, KeyWords_Amazon_4, KeyWords_Amazon_5, Amazon_Browse_Nodes_1_CDA, Amazon_Browse_Nodes_2_CDA, Amazon_Browse_Nodes_1_USA, Amazon_Browse_Nodes_2_USA, Active, Design_Service_Family_Category_Sage, Design_Service_Family_Themes_Sage, Design_Service_Family_Category_ESP, Design_Service_Family_Category_PromoMarketing, Design_Service_Family_Category_UDUCAT, Design_Service_Family_Category_DistributorCentral, HTS_CA, HTS_US "
                                                          + "FROM ref_Families WHERE Design_Service_Family_Code = \'" + familyCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            shortEnglishDescription = table.Rows[0][0].ToString();
            shortFrenchDescription = table.Rows[0][1].ToString();
            generalKeywords = table.Rows[0][2].ToString();
            amazonKeywords[0] = table.Rows[0][3].ToString();
            amazonKeywords[1] = table.Rows[0][4].ToString();
            amazonKeywords[2] = table.Rows[0][5].ToString();
            amazonKeywords[3] = table.Rows[0][6].ToString();
            amazonKeywords[4] = table.Rows[0][7].ToString();
            amazonCaNode[0] = table.Rows[0][8].ToString();
            amazonCaNode[1] = table.Rows[0][9].ToString();
            amazonComNode[0] = table.Rows[0][10].ToString();
            amazonComNode[1] = table.Rows[0][11].ToString();
            active = table.Rows[0][12].ToString() == "True";
            sageCategory = table.Rows[0][13].ToString();
            sageTheme = table.Rows[0][14].ToString();
            esp = table.Rows[0][15].ToString();
            promoMarketing = table.Rows[0][16].ToString();
            uducat = table.Rows[0][17].ToString();
            distributorCentral = table.Rows[0][18].ToString();
            caHts = table.Rows[0][19].ToString();
            usHts = table.Rows[0][20].ToString();

        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            generalKeywordsTextBox.Text = generalKeywords;
            amazonKeywordsTextbox1.Text = amazonKeywords[0];
            amazonKeywordsTextbox2.Text = amazonKeywords[1];
            amazonKeywordsTextbox3.Text = amazonKeywords[2];
            amazonKeywordsTextbox4.Text = amazonKeywords[3];
            amazonKeywordsTextbox5.Text = amazonKeywords[4];
            amazonCaTextbox1.Text = amazonCaNode[0];
            amazonCaTextbox2.Text = amazonCaNode[1];
            amazonComTextbox1.Text = amazonComNode[0];
            amazonComTextbox2.Text = amazonComNode[1];
            canadianHtsCombobox.Text = caHts;
            usHtsCombobox.Text = usHts;
            activeCheckbox.Checked = active;
            sageCategoryTextbox.Text = sageCategory;
            sageThemeTextbox.Text = sageTheme;
            espTextbox.Text = esp;
            promoMarketingTextbox.Text = promoMarketing;
            uducatTextbox.Text = uducat;
            distributorCentralTextbox.Text = distributorCentral;
        }
        #endregion

        #region Left and Right Buttons
        /* the event for left and right button click that change the index of comboboxes */
        private void leftButton_Click(object sender, EventArgs e)
        {
            int i = productFamilyCombobox.SelectedIndex;
            if (i > 0)
                i--;
            productFamilyCombobox.SelectedIndex = i;
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            int i = productFamilyCombobox.SelectedIndex;
            if (i < familyCodeList.Count - 1)
                i++;
            productFamilyCombobox.SelectedIndex = i;
        }
        #endregion

        #region Translate
        /* the event for translate button that translate English to French */
        private void translateButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate.IsBusy)
                backgroundWorkerTranslate.RunWorkerAsync();
        }
        private void backgroundWorkerTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (shortEnglishDescriptionTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // initialize a Translation class for translation and start translating
            shortFrenchDescription = Translate.nowTranslate(shortEnglishDescriptionTextbox.Text);
        }
        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            if (shortFrenchDescription.Contains("Error:"))
                MessageBox.Show(shortFrenchDescription, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
        }
        #endregion

        #region Taxes
        /* the event for showing the corresponding ca and us duty form the item selected in combobox */
        private void canadianHtsCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (canadianHtsCombobox.SelectedItem.ToString() != "")
            {
                // connect to database to get the info about this material code
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
                // connect to database to get the info about this material code
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

        #region Update
        /* the event when update family button is clicked */
        private void updateFamilyButton_Click(object sender, EventArgs e)
        {
            // initiliaze some of the fields
            familyCode = productFamilyCombobox.SelectedItem.ToString();
            caHts = canadianHtsCombobox.SelectedItem.ToString();
            usHts = usHtsCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild family code has been selected, so no need to check
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
            shortEnglishDescription = shortEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            generalKeywords = generalKeywordsTextBox.Text.Replace("'", "''");
            amazonKeywords[0] = amazonKeywordsTextbox1.Text;
            amazonKeywords[1] = amazonKeywordsTextbox2.Text;
            amazonKeywords[2] = amazonKeywordsTextbox3.Text;
            amazonKeywords[3] = amazonKeywordsTextbox4.Text;
            amazonKeywords[4] = amazonKeywordsTextbox5.Text;
            amazonCaNode[0] = amazonCaTextbox1.Text;
            amazonCaNode[1] = amazonCaTextbox2.Text;
            amazonComNode[0] = amazonComTextbox1.Text;
            amazonComNode[1] = amazonComTextbox2.Text;
            sageCategory = sageCategoryTextbox.Text.Replace("'", "''");
            sageTheme = sageThemeTextbox.Text.Replace("'", "''");
            esp = espTextbox.Text.Replace("'", "''");
            promoMarketing = promoMarketingTextbox.Text.Replace("'", "''");
            uducat = uducatTextbox.Text.Replace("'", "''");
            distributorCentral = distributorCentralTextbox.Text.Replace("'", "''");
            caDuty = caDutyTextbox.Text;
            usDuty = usDutyTextbox.Text;
            active = activeCheckbox.Checked;

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            try
            {
                // connect to database and update the family
                if (caHts != "" && usHts != "")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("UPDATE ref_Families SET Design_Service_Family_Description = \'" + shortEnglishDescription + "\', Design_Service_Family_Description_FR = \'" + shortFrenchDescription + "\', Design_Service_Family_KeyWords_General = \'" + generalKeywords + "\', Design_Service_Family_Category_Sage = \'" + sageCategory + "\', Design_Service_Family_Themes_Sage = \'" + sageTheme + "\', Design_Service_Family_Category_ESP = \'" + esp + "\', Design_Service_Family_Category_PromoMarketing = \'" + promoMarketing + "\', Design_Service_Family_Category_UDUCAT = \'" + uducat + "\', Design_Service_Family_Category_DistributorCentral = \'" + distributorCentral + "\', Date_Updated = \'" + DateTime.Now.ToString("yyyy-MM-dd") + "\', "
                                                          + "KeyWords_Amazon_1 = \'" + amazonKeywords[0] + "\', KeyWords_Amazon_2 = \'" + amazonKeywords[1] + "\', KeyWords_Amazon_3 = \'" + amazonKeywords[2] + "\', KeyWords_Amazon_4 = \'" + amazonKeywords[3] + "\', KeyWords_Amazon_5 = \'" + amazonKeywords[4] + "\', Amazon_Browse_Nodes_1_CDA = \'" + amazonCaNode[0] + "\', Amazon_Browse_Nodes_2_CDA = \'" + amazonCaNode[1] + "\', Amazon_Browse_Nodes_1_USA = \'" + amazonComNode[0] + "\', Amazon_Browse_Nodes_2_USA = \'" + amazonComNode[1] + "\', HTS_CA = \'" + caHts + "\', HTS_US = \'" + usHts + "\', CA_Duty = " + caDuty + ", US_Duty = " + usDuty + ", Active = \'" + active + "\' "
                                                          + "WHERE Design_Service_Family_Code = \'" + familyCode + "\'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("UPDATE ref_Families SET Design_Service_Family_Description = \'" + shortEnglishDescription + "\', Design_Service_Family_Description_FR = \'" + shortFrenchDescription + "\', Design_Service_Family_KeyWords_General = \'" + generalKeywords + "\', Design_Service_Family_Category_Sage = \'" + sageCategory + "\', Design_Service_Family_Themes_Sage = \'" + sageTheme + "\', Design_Service_Family_Category_ESP = \'" + esp + "\', Design_Service_Family_Category_PromoMarketing = \'" + promoMarketing + "\', Design_Service_Family_Category_UDUCAT = \'" + uducat + "\', Design_Service_Family_Category_DistributorCentral = \'" + distributorCentral + "\', Date_Updated = \'" + DateTime.Now.ToString("yyyy-MM-dd") + "\', "
                                                          + "KeyWords_Amazon_1 = \'" + amazonKeywords[0] + "\', KeyWords_Amazon_2 = \'" + amazonKeywords[1] + "\', KeyWords_Amazon_3 = \'" + amazonKeywords[2] + "\', KeyWords_Amazon_4 = \'" + amazonKeywords[3] + "\', KeyWords_Amazon_5 = \'" + amazonKeywords[4] + "\', Amazon_Browse_Nodes_1_CDA = \'" + amazonCaNode[0] + "\', Amazon_Browse_Nodes_2_CDA = \'" + amazonCaNode[1] + "\', Amazon_Browse_Nodes_1_USA = \'" + amazonComNode[0] + "\', Amazon_Browse_Nodes_2_USA = \'" + amazonComNode[1] + "\', Active = \'" + active + "\' "
                                                          + "WHERE Design_Service_Family_Code = \'" + familyCode + "\'", connection);
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

        #region Active and Inactive List
        /* the event for active and inactive list button that open the table of active family list */
        private void activeFamilyButton_Click(object sender, EventArgs e)
        {
            new ActiveFamilyList().ShowDialog(this); 
        }
        private void inactiveFamilyButton_Click(object sender, EventArgs e)
        {
            new InactiveFamilyList().ShowDialog(this);
        }
        #endregion

        #region Add and Remove
        /* the event for sage categroy add and remove button click */
        private void addSageCategoryButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (sageCategoryTextbox.Text == "")
                sageCategoryTextbox.Text = sageCategoryCombobox.SelectedItem.ToString();
            else if (!sageCategoryTextbox.Text.Contains(sageCategoryCombobox.SelectedItem.ToString()))
                sageCategoryTextbox.Text += "; " + sageCategoryCombobox.SelectedItem;
        }
        private void removeSageCategoryButton_Click(object sender, EventArgs e)
        {
            if (sageCategoryTextbox.Text.Contains(";"))
            {
                int index = sageCategoryTextbox.Text.LastIndexOf(';');
                sageCategoryTextbox.Text = sageCategoryTextbox.Text.Substring(0, index);
            }
            else
                sageCategoryTextbox.Text = "";
        }

        /* the event for sage theme add and remove button click */
        private void addSageThemeButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (sageThemeTextbox.Text == "")
                sageThemeTextbox.Text = sageThemeCombobox.SelectedItem.ToString();
            else if (!sageThemeTextbox.Text.Contains(sageThemeCombobox.SelectedItem.ToString()))
                sageThemeTextbox.Text += "; " + sageThemeCombobox.SelectedItem;
        }
        private void removeSageThemeButton_Click(object sender, EventArgs e)
        {
            if (sageThemeTextbox.Text.Contains(";"))
            {
                int index = sageThemeTextbox.Text.LastIndexOf(';');
                sageThemeTextbox.Text = sageThemeTextbox.Text.Substring(0, index);
            }
            else
                sageThemeTextbox.Text = "";
        }

        /* the event for ESP add and remove button click */
        private void addEspButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (espTextbox.Text == "")
                espTextbox.Text = espCombobox.SelectedItem.ToString();
            else if (!espTextbox.Text.Contains(espCombobox.SelectedItem.ToString()))
                espTextbox.Text += "; " + espCombobox.SelectedItem;
        }
        private void removeEspButton_Click(object sender, EventArgs e)
        {
            if (espTextbox.Text.Contains(";"))
            {
                int index = espTextbox.Text.LastIndexOf(';');
                espTextbox.Text = espTextbox.Text.Substring(0, index);
            }
            else
                espTextbox.Text = "";
        }

        /* the event for promo marketing add and remove button click */
        private void addPromoMarketingButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (promoMarketingTextbox.Text == "")
            {
                promoMarketingTextbox.Text = promoMarketingCombobox.SelectedItem.ToString();
            }
            else if (!promoMarketingTextbox.Text.Contains(promoMarketingCombobox.SelectedItem.ToString()))
                promoMarketingTextbox.Text += "; " + promoMarketingCombobox.SelectedItem;
        }
        private void removePromoMarketingButton_Click(object sender, EventArgs e)
        {
            if (promoMarketingTextbox.Text.Contains(";"))
            {
                int index = promoMarketingTextbox.Text.LastIndexOf(';');
                promoMarketingTextbox.Text = promoMarketingTextbox.Text.Substring(0, index);
            }
            else
                promoMarketingTextbox.Text = "";
        }

        /* the event for UDUCAT add and remove button click */
        private void addUducatButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (uducatTextbox.Text == "")
                uducatTextbox.Text = uducatCombobox.SelectedItem.ToString();
            else if (!uducatTextbox.Text.Contains(uducatCombobox.SelectedItem.ToString()))
                uducatTextbox.Text += "; " + uducatCombobox.SelectedItem;
        }
        private void removeUducatButton_Click(object sender, EventArgs e)
        {
            if (uducatTextbox.Text.Contains(";"))
            {
                int index = uducatTextbox.Text.LastIndexOf(';');
                uducatTextbox.Text = uducatTextbox.Text.Substring(0, index);
            }
            else
                uducatTextbox.Text = "";
        }

        /* the event for distributor central add and remove button click */
        private void addDistributorCentralButton_Click(object sender, EventArgs e)
        {
            // add selected item to the textbox
            if (distributorCentralTextbox.Text == "")
                distributorCentralTextbox.Text = distributorCentralCombobox.SelectedItem.ToString();
            else if (!distributorCentralTextbox.Text.Contains(distributorCentralCombobox.SelectedItem.ToString()))
                distributorCentralTextbox.Text += "; " + distributorCentralCombobox.SelectedItem;
        }
        private void removeDistributorCentralButton_Click(object sender, EventArgs e)
        {
            if (distributorCentralTextbox.Text.Contains(";"))
            {
                int index = distributorCentralTextbox.Text.LastIndexOf(';');
                distributorCentralTextbox.Text = distributorCentralTextbox.Text.Substring(0, index);
            }
            else
                distributorCentralTextbox.Text = "";
        }
        #endregion
    }
}
