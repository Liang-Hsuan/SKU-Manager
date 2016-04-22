using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using System.Drawing;

namespace SKU_Manager.SplashModules.Deactivate
{
   /*
    * An application module that deactivate a color
    */
    public partial class DeactivateColor : Form
    {
        // field for storing deactivating color data
        private string colorCode;
        private string shortEnglishDescription;
        private string extendedEnglishDescription;
        private string colorOnlineEnglish;
        private string colorOnlineFrench;

        // fields for combobox
        private readonly ArrayList colorCodeList = new ArrayList();

        /* constructor that initialize graphic components */
        public DeactivateColor()
        {
            InitializeComponent();

            colorCodeList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                SqlCommand command = new SqlCommand("SELECT Colour_Code FROM ref_Colours WHERE Active = 'True' ORDER BY Colour_Code;", connection);    // for selecting data
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();    // for reading data
                while (reader.Read())
                    colorCodeList.Add(reader.GetString(0));
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            colorCodeCombobox.DataSource = colorCodeList;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void colorCodeCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the information on the controls
            if (colorCodeCombobox.SelectedItem.ToString() != "")
            {
                deactivateColorButton.Enabled = true;
                onlineButton.Enabled = true;

                // set colorCode field from the selected item 
                colorCode = colorCodeCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                shortEnglishDescriptionTextbox.Text = "";
                extendedEnglishDescriptionTextbox.Text = "";

                deactivateColorButton.Enabled = false;
                onlineButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Description_Short, Colour_Description_Extended, Colour_Online, Colour_Online_FR " 
                                                          + "FROM ref_Colours WHERE Colour_Code = \'" + colorCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            shortEnglishDescription = table.Rows[0][0].ToString();
            extendedEnglishDescription = table.Rows[0][1].ToString();
            colorOnlineEnglish = table.Rows[0][2].ToString();
            colorOnlineFrench = table.Rows[0][3].ToString();
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            extendedEnglishDescriptionTextbox.Text = extendedEnglishDescription;
        }
        #endregion

        #region Deactivate
        /* the event when deactivate color button is clicked */
        private void deactivateColorButton_Click(object sender, EventArgs e)
        {
            // initiliaze colorCode
            colorCode = colorCodeCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild color has been selected, so no need to check
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
                // connect to database and activate the color
                using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
                {
                    SqlCommand command = new SqlCommand("UPDATE ref_Colours SET Active =  'False', Date_Deactivated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\' "
                                                      + "WHERE Colour_Code = \'" + colorCode + "\'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE master_SKU_Attributes SET Active = 'False', SKU_Website = 'False' WHERE Colour_Code = \'" + colorCode + "\'";
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
        /* the event for active and inactive list button that open the table of active color list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new ActiveColorList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new InactiveColorList().ShowDialog(this);
        }
        #endregion

        /* online button clicks that show color online description */
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Online online = new Online("Colour Online Description", colorOnlineEnglish, colorOnlineFrench, Color.FromArgb(64,64,64), Color.White, false);
            online.ShowDialog(this);
        }
    }
}
