using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;

namespace SKU_Manager.SplashModules.Deactivate
{
   /*
    * An application module that deactivate a color
    */
    public partial class DeactivateFamily : Form
    {
        // fields for storing adding color data
        private string familyCode;
        private string shortEnglishDescription;

        // fields for combobox
        private readonly ArrayList productFamilyList = new ArrayList();

        // field for database connection
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic components */
        public DeactivateFamily()
        {
            InitializeComponent();
            productFamilyList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBox */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Design_Service_Family_Code FROM ref_Families WHERE Active = \'True\' ORDER BY Design_Service_Family_Code;", connection);    // for selecting data
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();    // for reading data
                while (reader.Read())
                    productFamilyList.Add(reader.GetString(0));
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            productFamilyCombobox.DataSource = productFamilyList;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void productFamilyCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the information of the controls
            if (productFamilyCombobox.SelectedItem.ToString() != "")
            {
                deactivateFamilyButton.Enabled = true;

                // set colorCode field from the selected item 
                familyCode = productFamilyCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                shortEnglishDescriptionTextbox.Text = "";

                deactivateFamilyButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // store data and assign to the field
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Design_Service_family_Description FROM ref_Families WHERE Design_Service_Family_Code = \'" + familyCode + "\';", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                shortEnglishDescription = reader.GetString(0);
            }
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
        }
        #endregion

        #region Deactivate
        /* the event when deactivate family button is clicked */
        private void deactivateFamilyButton_Click(object sender, EventArgs e)
        {
            // initiliaze familyCode
            familyCode = productFamilyCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild family has been selected, so no need to check
            if (!backgroundWorkerDeactivate.IsBusy)
                backgroundWorkerDeactivate.RunWorkerAsync();
        }
        private void backgroundWorkerDeactivate_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 60%
            for (int i = 1; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerDeactivate.ReportProgress(i);
            }

            try
            {
                // connect to database and activate the family
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE ref_Families SET Active = 'False', Date_Deactivated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\' "
                                                      + "WHERE Design_Service_Family_Code = \'" + familyCode + "\'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();

                    // design deactivation
                    command.CommandText = "UPDATE master_Design_Attributes SET Active = 'False', Website_Flag = 'False' WHERE Design_Service_Family_Code = \'" + familyCode + "\'";
                    command.ExecuteNonQuery();

                    // sku deactivation
                    command.CommandText = "UPDATE master_SKU_Attributes SET Active = 'False', SKU_Website = 'False' WHERE Design_Service_Code IN (" +
                                          "SELECT Design_Service_Code FROM master_Design_Attributes WHERE Design_Service_Family_Code = \'" + familyCode + "\')";
                    command.ExecuteNonQuery();
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
                backgroundWorkerDeactivate.ReportProgress(i);
            }
        }
        private void backgroundWorkerDeactivate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive
        /* the event for active and inactive list button that open the table of active family list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new ActiveFamilyList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new InactiveFamilyList().ShowDialog(this);
        }
        #endregion
    }
}
