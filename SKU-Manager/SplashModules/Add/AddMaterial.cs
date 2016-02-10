using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;

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

        /* constructor that initialize graphic component */
        public AddMaterial()
        {
            InitializeComponent();
        }

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

        /* the event for add material button */
        private void addMaterialButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerAddMaterial.IsBusy)
            {
                backgroundWorkerAddMaterial.RunWorkerAsync();
            }
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
    }
}
