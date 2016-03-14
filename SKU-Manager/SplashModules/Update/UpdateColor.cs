﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SplashModules.Update
{
    /*
     * An application module to update color to SKU database
     */
    public partial class UpdateColor : Form
    {
        // fields for storing updating color data
        private string colorCode;
        private string shortEnglishDescription;
        private string extendedEnglishDescription;
        private string shortFrenchDescription;
        private string extendedFrenchDescription;
        private bool active = true;    // default is set to true

        // field for database connection
        private string connectionString = Properties.Settings.Default.Designcs;

        // fields for combobox
        ArrayList colorCodeList = new ArrayList();

        /* constructor that initialize graphic component */
        public UpdateColor()
        {
            InitializeComponent();
            colorCodeList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
            {
                backgroundWorkerCombobox.RunWorkerAsync();
            }
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            // make comboBox for Canadian HTS
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Colour_Code FROM ref_Colours WHERE Colour_Code is not NULL ORDER BY Colour_Code;", connection);   
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    colorCodeList.Add(reader.GetString(0));
                }
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            colorCodeCombobox.DataSource = colorCodeList;
        }
        #endregion

        #region Left and Right Buttons 
        /* the event for left and right button click that change the index of comboboxes */
        private void leftButton_Click(object sender, EventArgs e)
        {
            int i = colorCodeCombobox.SelectedIndex;
            if (i > 0)
            {
                i--;
            }
            colorCodeCombobox.SelectedIndex = i;
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            int i = colorCodeCombobox.SelectedIndex;
            if (i < colorCodeList.Count - 1)
            {
                i++;
            }
            colorCodeCombobox.SelectedIndex = i;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void colorCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the enability of the controls
            if (colorCodeCombobox.SelectedItem.ToString() != "")
            {
                translateButton.Enabled = true;
                shortEnglishDescriptionTextbox.Enabled = true;
                shortFrenchDescriptionTextbox.Enabled = true;
                extendedEnglishDescriptionTextbox.Enabled = true;
                extendedFrenchDescriptionTextbox.Enabled = true;
                updateColorButton.Enabled = true;

                // set colorCode field from the selected item 
                colorCode = colorCodeCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                {
                    backgroundWorkerInfo.RunWorkerAsync();
                }
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
                activeCheckbox.Checked = false;
                updateColorButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Description_Short, Colour_Description_Short_FR, Colour_Description_Extended, Colour_Description_Extended_FR, Active FROM ref_Colours WHERE Colour_Code = \'" + colorCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            shortEnglishDescription = table.Rows[0][0].ToString();
            shortFrenchDescription = table.Rows[0][1].ToString();
            extendedEnglishDescription = table.Rows[0][2].ToString();
            extendedFrenchDescription = table.Rows[0][3].ToString();
            if (table.Rows[0][4].ToString() != "True")
            {
                active = false;
            }
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            extendedEnglishDescriptionTextbox.Text = extendedEnglishDescription;
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
            if (active)
            {
                activeCheckbox.Checked = true;
            }
        }
        #endregion

        #region Translate
        /* the event for translate button that translate English to French */
        private void translateButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTranslate.IsBusy)
            {
                backgroundWorkerTranslate.RunWorkerAsync();
            }
        }
        private void backgroundWorkerTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            // if the user does not enter the description
            if (shortEnglishDescriptionTextbox.Text == "" && extendedEnglishDescriptionTextbox.Text == "")
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
        }
        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;
            extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;
        }
        #endregion

        #region Add Color
        /* the event when update color button is clicked */
        private void updateColorButton_Click(object sender, EventArgs e)
        {
            // initiliaze colorCode
            colorCode = colorCodeCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild color has been selected, so no need to check
            if (!backgroundWorkerUpdate.IsBusy)
            {
                backgroundWorkerUpdate.RunWorkerAsync();
            }
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

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerUpdate.ReportProgress(i);
            }

            try
            {
                // connect to database and update the color
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE ref_Colours SET Colour_Description_Extended = \'" + extendedEnglishDescription + "\', Colour_Description_Short = \'" + shortEnglishDescription + "\', Colour_Description_Extended_FR = \'" + extendedFrenchDescription + "\', Colour_Description_Short_FR = \'" + shortFrenchDescription + "\', Date_Updated = \'" + DateTime.Now.ToString() + "\' "
                                                      + "WHERE Colour_Code = \'" + colorCode + "\'", connection);
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
        /* the event for active and inactive list button that open the table of active color list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            ActiveColorList activeColorList = new ActiveColorList();
            activeColorList.ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            InactiveColorList inactiveColorList = new InactiveColorList();
            inactiveColorList.ShowDialog(this);
        }
        #endregion
    }
}
