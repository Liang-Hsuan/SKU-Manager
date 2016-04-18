using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;
using System.Drawing;
using System.Collections.Generic;

namespace SKU_Manager.SplashModules.Add
{
    /*
     * An application module to add new color to SKU database
     */
    public partial class AddColor : Form
    {
        // fields for storing adding color data
        private string colorCode;
        private string shortEnglishDescription = "";
        private string extendedEnglishDescription = "";
        private string shortFrenchDescription = "";
        private string extendedFrenchDescription = "";
        private string colorOnlineEnglish = "";
        private string colorOnlineFrench = "";
        private bool active = true;    // default is set to true

        // field for duplicate checking
        private readonly HashSet<string> colorCodeList = new HashSet<string>();

        /* constructor that initialize graphic component */
        public AddColor()
        {
            InitializeComponent();

            // adding all the existing color code list
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs))
            {
                SqlCommand command = new SqlCommand("SELECT Colour_Code FROM ref_Colours;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    colorCodeList.Add(reader.GetString(0));
            }
        }

        /* the text change event that will check if there is already a duplicate color code */
        private void colorCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (colorCodeList.Contains(colorCodeTextbox.Text))
            {
                duplicateLabel.Visible = true;
                colorCodeTextbox.BackColor = Color.Red;
            }
            else
            {
                duplicateLabel.Visible = false;
                colorCodeTextbox.BackColor = SystemColors.Window;
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

            // down to business, this is for short description
            if (shortEnglishDescriptionTextbox.Text != "")
                shortFrenchDescription = Translate.NowTranslate(shortEnglishDescriptionTextbox.Text);

            // this is for extended description
            if (extendedEnglishDescriptionTextbox.Text != "")
                extendedFrenchDescription = Translate.NowTranslate(extendedEnglishDescriptionTextbox.Text);
        }
        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show result to textbox
            if (shortFrenchDescription.Contains("Error:"))
            {
                MessageBox.Show(shortFrenchDescription, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            shortFrenchDescriptionTextbox.Text = shortFrenchDescription;

            if (extendedFrenchDescription.Contains("Error:"))
                MessageBox.Show(extendedFrenchDescription, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                extendedFrenchDescriptionTextbox.Text = extendedFrenchDescription;   
        }
        #endregion

        /* online button clicks that allow user to edit color online description */
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Online online = new Online("Colour Online Description", colorOnlineEnglish, colorOnlineFrench, Color.FromArgb(78, 95, 190));
            online.ShowDialog(this);

            // set color online 
            if (online.DialogResult != DialogResult.OK) return;
            colorOnlineEnglish = online.English;
            colorOnlineFrench = online.French;
        }

        #region Add 
        /* the event for add color button */
        private void addColorButton_Click(object sender, EventArgs e)
        {
            // check if the user has put the color code or not
            if (colorCodeTextbox.Text == "")
            {
                colorCodeTextbox.BackColor = Color.Red;
                return;
            }

            if (!backgroundWorkerAddColor.IsBusy)
                backgroundWorkerAddColor.RunWorkerAsync();
        }
        private void backgroundWorkerAddColor_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 30%
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddColor.ReportProgress(i);
            }

            // get data from user input
            colorCode = colorCodeTextbox.Text;
            shortEnglishDescription = shortEnglishDescriptionTextbox.Text.Replace("'", "''");
            extendedEnglishDescription = extendedEnglishDescriptionTextbox.Text.Replace("'", "''");
            shortFrenchDescription = shortFrenchDescriptionTextbox.Text.Replace("'", "''");
            extendedFrenchDescription = extendedFrenchDescriptionTextbox.Text.Replace("'", "''");

            // simulate progress 30% ~ 60%
            for (int i = 30; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddColor.ReportProgress(i);
            }

            // connect to database and insert new row                    
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO ref_Colours (Colour_Code, Colour_Description_Extended, Colour_Description_Short, Colour_Description_Extended_FR, Colour_Description_Short_FR, Colour_Online, Colour_Online_FR, Active, Date_Added) " +
                                                        "VALUES (\'" + colorCode + "\',\'" + extendedEnglishDescription + "\',\'" + shortEnglishDescription + "\',\'" + extendedFrenchDescription + "\',\'" + shortFrenchDescription + "\',\'" + colorOnlineEnglish.Replace("'", "''") + "\',\'" + colorOnlineFrench.Replace("'", "''") + "\',\'" + active + "\',\'" + DateTime.Today.ToString("yyyy-MM-dd") + "\');", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happen during database updating:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // simulate progress 60% ~ 100%
            for (int i = 60; i <= 100; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerAddColor.ReportProgress(i);
            }
        }
        private void backgroundWorkerAddColor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive
        /* the event for active and inactive buttons click */
        private void activeColorButton_Click(object sender, EventArgs e)
        {
            active = true;    // make active true

            // set buttons enability
            activeColorButton.Enabled = false;
            inactiveColorButton.Enabled = true;
        }
        private void inactiveColorButton_Click(object sender, EventArgs e)
        {
            active = false;    // make active false

            // set buttons enability
            inactiveColorButton.Enabled = false;
            activeColorButton.Enabled = true;
        }
        #endregion
    }
}
