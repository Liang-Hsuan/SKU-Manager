using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;
using System.Collections.Generic;
using System.Drawing;

namespace SKU_Manager.SplashModules.Add
{
    /*
     * An application module to add new material to SKU database
     */
    public partial class AddMaterial : Form
    {
        // fields for storing adding material data
        private string materialCode;
        private string shortEnglishDescription;
        private string extendedEnglishDescription;
        private string shortFrenchDescription;
        private string extendedFrenchDescription;
        private bool active = true;    // default is set to true

        // field for duplicate checking
        HashSet<string> materialCodeList = new HashSet<string>();

        /* constructor that initialize graphic component */
        public AddMaterial()
        {
            InitializeComponent();

            // adding all the existing color code list
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs))
            {
                SqlCommand command = new SqlCommand("SELECT Colour_Code FROM ref_Colours;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    materialCodeList.Add(reader.GetString(0));
            }
        }

        /* the text change event that will check if there is already a duplicate material code */
        private void materialCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (materialCodeList.Contains(materialCodeTextbox.Text))
            {
                materialCodeTextbox.BackColor = Color.Red;
                duplicateLabel.Visible = true;
            }
            else
            {
                materialCodeTextbox.BackColor = SystemColors.Window;
                duplicateLabel.Visible = false;
            }
        }

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

        #region Add
        /* the event for add material button */
        private void addMaterialButton_Click(object sender, EventArgs e)
        {
            // check if the user has put the material code or not
            if (materialCodeTextbox.Text == "")
            {
                materialCodeTextbox.BackColor = Color.Red;
                return;
            }

            if (!backgroundWorkerAddMaterial.IsBusy)
                backgroundWorkerAddMaterial.RunWorkerAsync();
        }
        private void backgroundWorkerAddMaterial_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 30%
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddMaterial.ReportProgress(i);
            }

            // get data from user input
            materialCode = materialCodeTextbox.Text;
            shortEnglishDescription = shortEnglishDescriptionTextbox.Text.Replace("'", "''");
            extendedEnglishDescription = extendedEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            extendedFrenchDescription = extendedFrenchDescriptionTextbox.Text.Replace("'", "''");

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddMaterial.ReportProgress(i);
            }

            // connect to database and insert new row
            string connectionString = Properties.Settings.Default.Designcs;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO ref_Materials (Material_Code, Material_Description_Extended, Material_Description_Short, Material_Description_Extended_FR, Material_Description_Short_FR, Active, Date_Added) VALUES (\'" + materialCode + "\', \'" + extendedEnglishDescription + "\', \'" + shortEnglishDescription + "\', \'" + extendedFrenchDescription + "\', \'" + shortFrenchDescription + "\', \'" + active.ToString() + "\', \'" + DateTime.Now.ToString() + "\');", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            // simulate progress 60% ~ 100%
            for (int i = 60; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddMaterial.ReportProgress(i);
            }
        }
        private void backgroundWorkerAddMaterial_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive
        /* the event for active and inactive buttons click */
        private void activeMaterialButton_Click(object sender, EventArgs e)
        {
            active = true;    // make active true

            // set buttons enability
            activeMaterialButton.Enabled = false;
            inactiveMaterialButton.Enabled = true;
        }
        private void inactiveMaterialButton_Click(object sender, EventArgs e)
        {
            active = false;    // make active false

            // set buttons enability
            inactiveMaterialButton.Enabled = false;
            activeMaterialButton.Enabled = true;
        }
        #endregion
    }
}
