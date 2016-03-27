using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SupportingClasses;
using System.Drawing;

namespace SKU_Manager.SplashModules.Update
{
    /*
    * An application module to update a material to SKU database
    */
    public partial class UpdateMaterial : Form
    {
        // fields for storing updating material data
        private string materialCode;
        private string shortEnglishDescription;
        private string extendedEnglishDescription;
        private string shortFrenchDescription;
        private string extendedFrenchDescription;
        private string materialOnlineEnglish;
        private string materialOnlineFrench;
        private bool active = true;    // default is set to true

        // field for database connection
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        // fields for combobox
        private readonly ArrayList materialCodeList = new ArrayList();

        /* constructor that initialize graphic component */
        public UpdateMaterial()
        {
            InitializeComponent();
            materialCodeList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for Canadian HTS
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Material_Code FROM ref_Materials WHERE Material_Code is not NULL ORDER BY Material_Code;", connection);   
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    materialCodeList.Add(reader.GetString(0));
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            materialCodeCombobox.DataSource = materialCodeList;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void materialCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the enability of the controls
            if (materialCodeCombobox.SelectedItem.ToString() != "")
            {
                translateButton.Enabled = true;
                shortEnglishDescriptionTextbox.Enabled = true;
                shortFrenchDescriptionTextbox.Enabled = true;
                extendedEnglishDescriptionTextbox.Enabled = true;
                extendedFrenchDescriptionTextbox.Enabled = true;
                onlineButton.Enabled = true;
                updateMaterialButton.Enabled = true;
                activeCheckbox.Enabled = true;

                // set materialCode field from the selected item 
                materialCode = materialCodeCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                shortEnglishDescriptionTextbox.Text = "";
                shortFrenchDescriptionTextbox.Text = "";
                extendedEnglishDescriptionTextbox.Text = "";
                extendedFrenchDescriptionTextbox.Text = "";

                translateButton.Enabled = false;
                shortEnglishDescriptionTextbox.Enabled = false;
                shortFrenchDescriptionTextbox.Enabled = false;
                extendedEnglishDescriptionTextbox.Enabled = false;
                extendedFrenchDescriptionTextbox.Enabled = false;
                onlineButton.Enabled = false;
                activeCheckbox.Checked = false;
                updateMaterialButton.Enabled = false;
                activeCheckbox.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Description_Short, Material_Description_Short_FR, Material_Description_Extended, Material_Description_Extended_FR, Material_Online, Material_Online_FR, Active FROM ref_Materials WHERE Material_Code = \'" + materialCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            shortEnglishDescription = table.Rows[0][0].ToString();
            shortFrenchDescription = table.Rows[0][1].ToString();
            extendedEnglishDescription = table.Rows[0][2].ToString();
            extendedFrenchDescription = table.Rows[0][3].ToString();
            materialOnlineEnglish = table.Rows[0][4].ToString();
            materialOnlineFrench = table.Rows[0][5].ToString();
            if (table.Rows[0][6].ToString() != "True")
                active = false;
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            extendedEnglishDescriptionTextbox.Text = extendedEnglishDescription;
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
            activeCheckbox.Checked = active;
        }
        #endregion

        #region Left and Right Buttons
        /* the event for left and right button click that change the index of comboboxes */
        private void leftButton_Click(object sender, EventArgs e)
        {
            int i = materialCodeCombobox.SelectedIndex;
            if (i > 0)
                i--;
            materialCodeCombobox.SelectedIndex = i;
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            int i = materialCodeCombobox.SelectedIndex;
            if (i < materialCodeList.Count - 1)
                i++;
            materialCodeCombobox.SelectedIndex = i;
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
            if (shortEnglishDescriptionTextbox.Text == "" && extendedEnglishDescriptionTextbox.Text == "")
            {
                MessageBox.Show("You haven't put the description yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // down to business, this is for short description
            if (shortEnglishDescriptionTextbox.Text != "")
                shortFrenchDescription = Translate.nowTranslate(shortEnglishDescriptionTextbox.Text);

            // this is for extended description
            if (extendedEnglishDescriptionTextbox.Text != "")
                extendedFrenchDescription = Translate.nowTranslate(extendedEnglishDescriptionTextbox.Text);
        }
        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            if (shortFrenchDescription.Contains("Error:"))
            {
                MessageBox.Show(shortFrenchDescription, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            if (extendedFrenchDescription.Contains("Error:"))
                MessageBox.Show(extendedFrenchDescription, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
        }
        #endregion

        /* online button clicks that allow user to edit mateiral online description */
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Online online = new Online("Material Online Description", materialOnlineEnglish, materialOnlineFrench, Color.Green);
            online.ShowDialog(this);

            // set color online 
            if (online.DialogResult == DialogResult.OK)
            {
                materialOnlineEnglish = online.English;
                materialOnlineFrench = online.French;
            }
        }

        #region Update
        /* the event when update material button is clicked */
        private void updateMaterialButton_Click(object sender, EventArgs e)
        {
            // initiliaze materialCode
            materialCode = materialCodeCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild material has been selected, so no need to check
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
            extendedEnglishDescription = extendedEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            extendedFrenchDescription = extendedFrenchDescriptionTextbox.Text.Replace("'", "''");
            active = activeCheckbox.Checked;

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            try
            {
                // connect to database and insert new row
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE ref_Materials SET Material_Description_Extended = \'" + extendedEnglishDescription + "\', Material_Description_Short = \'" + shortEnglishDescription + "\', Material_Description_Extended_FR = \'" + extendedFrenchDescription + "\', Material_Description_Short_FR = \'" + shortFrenchDescription + "\', " + 
                                                        "Material_Online = \'" + materialOnlineEnglish.Replace("'", "''") + "\', Material_Online_FR = \'" + materialOnlineFrench.Replace("'", "''") + "\',Date_Updated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\', Active = \'" + active + "\' WHERE Material_Code = \'" + materialCode + "\'", connection);
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
        /* the event for active and inactive list button that open the table of active material list */
        private void activeMaterialButton_Click(object sender, EventArgs e)
        {
            new ActiveMaterialList().ShowDialog(this);
        }
        private void inactiveMaterialButton_Click(object sender, EventArgs e)
        {
            new InactiveMaterialList().ShowDialog(this);
        }
        #endregion
    }
}
