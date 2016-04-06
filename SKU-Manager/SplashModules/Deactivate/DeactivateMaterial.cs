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
    * An application module that deactivate a material
    */
    public partial class DeactivateMaterial : Form
    {
        // field for storing deactivating color data
        private string materialCode;
        private string shortEnglishDescription;
        private string extendedEnglishDescription;
        private string materialOnlineEnglish;
        private string materialOnlineFrench;

        // fields for combobox
        private readonly ArrayList materialList = new ArrayList();

        // field for database connection
        private readonly string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic components */
        public DeactivateMaterial()
        {
            InitializeComponent();
            materialList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
                backgroundWorkerCombobox.RunWorkerAsync();
        }

        #region Combobox Generation
        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Material_Code FROM ref_Materials WHERE Active = \'True\' ORDER BY Material_Code;", connection);    // for selecting data
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();    // for reading data
                while (reader.Read())
                    materialList.Add(reader.GetString(0));
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            materialCombobox.DataSource = materialList;
        }
        #endregion

        #region Info Generation
        /* the event when user change an item in combobox */
        private void materialCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the information on the controls
            if (materialCombobox.SelectedItem.ToString() != "")
            {
                deactivateMaterialButton.Enabled = true;
                onlineButton.Enabled = true;

                // set materialCode field from the selected item 
                materialCode = materialCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                shortEnglishDescriptionTextbox.Text = "";
                extendedEnglishDescriptionTextbox.Text = "";

                deactivateMaterialButton.Enabled = false;
                onlineButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Description_Short, Material_Description_Extended, Material_Online, Material_Online_FR " 
                                                          + "FROM ref_Materials WHERE Material_Code = \'" + materialCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to the fields
            shortEnglishDescription = table.Rows[0][0].ToString();
            extendedEnglishDescription = table.Rows[0][1].ToString();
            materialOnlineEnglish = table.Rows[0][2].ToString();
            materialOnlineFrench = table.Rows[0][3].ToString();
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            shortEnglishDescriptionTextbox.Text = shortEnglishDescription;
            extendedEnglishDescriptionTextbox.Text = extendedEnglishDescription;
        }
        #endregion

        #region Deactivate
        /* the event when deactivate material button is clicked */
        private void deactivateMaterialButton_Click(object sender, EventArgs e)
        {
            // initiliaze materialCode
            materialCode = materialCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild material has been selected, so no need to check
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

            // connect to database and activat the material
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE ref_Materials SET Active =  \'False\', Date_Deactivated = \'" + DateTime.Today.ToString("yyyy-MMMM-dd") + "\' "
                                                  + "WHERE Material_Code = \'" + materialCode + "\'", connection);
                connection.Open();
                command.ExecuteNonQuery();

                command.CommandText = "UPDATE master_SKU_Attributes SET Active = 'False', SKU_Website = 'False' WHERE Material_Code = \'" + materialCode + "\'";
                command.ExecuteNonQuery();
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
        /* the event for active and inactive list button that open the table of active and inactive material list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new ActiveMaterialList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new InactiveMaterialList().ShowDialog(this);
        }
        #endregion

        /* online button clicks that shows material online description */
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Online online = new Online("Material Online Description", materialOnlineEnglish, materialOnlineFrench, Color.FromArgb(94,94,94), Color.White, false);
            online.ShowDialog(this);
        }
    }
}
