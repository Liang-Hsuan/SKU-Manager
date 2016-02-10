using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SplashModules.Update;

namespace SKU_Manager.SplashModules.Deactivate
{
   /*
   * An application module that deactivate a sku
   */
    public partial class DeactivateSKU : Form
    {
        // fields for storing design data
        private string sku;
        private string designCode;
        private string productFamily;
        private string designServiceFlag;
        private string internalName;
        private string designDescription;
        private string materialCode;
        private string materialDescription;
        private string colorCode;
        private string colorDescription;

        // fields for combobox
        ArrayList skuList = new ArrayList();

        // field for database connection
        private string connectionString = Properties.Settings.Default.Designcs;

        /* constructor that initialize graphic components */
        public DeactivateSKU()
        {
            InitializeComponent();
            skuList.Add("");

            // call background worker for adding items to combobox
            if (!backgroundWorkerCombobox.IsBusy)
            {
                backgroundWorkerCombobox.RunWorkerAsync();
            }
        }

        /* the backgound workder for adding items to comboBoxes */
        private void backgroundWorkerCombobox_DoWork(object sender, DoWorkEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = \'True\' ORDER BY SKU_Ashlin;", connection);    // for selecting data
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();    // for reading data
                while (reader.Read())
                {
                    skuList.Add(reader.GetString(0));
                }
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            skuCombobox.DataSource = skuList;
        }

        /* the event when user change an item in combobox */
        private void skuCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            // change the information on the controls
            if (skuCombobox.SelectedItem.ToString() != "")
            {
                deactivateSKUButton.Enabled = true;

                // set sku field from the selected item 
                sku = skuCombobox.SelectedItem.ToString();

                // call background worker for showing information of the selected item in combobox
                if (!backgroundWorkerInfo.IsBusy)
                {
                    backgroundWorkerInfo.RunWorkerAsync();
                }
            }
            else
            {
                // set the text to nothing
                designCodeTextbox.Text = "";
                productFamilyTextbox.Text = "";
                brandTextbox.Text = "";
                designServiceFlagTextbox.Text = "";
                internalNameTextbox.Text = "";
                designDescriptionTextbox.Text = "";
                materialCodeTextbox.Text = "";
                materialDescriptionTextbox.Text = "";
                colorCodeTextbox.Text = "";
                colorDescriptionTextbox.Text = "";

                deactivateSKUButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Code, Material_Code, Colour_Code FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // get the codes
            designCode = table.Rows[0][0].ToString();
            materialCode = table.Rows[0][1].ToString();
            colorCode = table.Rows[0][2].ToString();
            table.Reset();    // reset table for later use

            // seek information for design
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Design_Service_Family_Code, Design_Service_Flag, Design_Service_Fashion_Name_Ashlin, Short_Description FROM master_Design_Attributes WHERE Design_Service_Code = \'" + designCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to design fields
            productFamily = table.Rows[0][0].ToString();
            designServiceFlag = table.Rows[0][1].ToString();
            internalName = table.Rows[0][2].ToString();
            designDescription = table.Rows[0][3].ToString();
            table.Reset();    // reset the table for later use

            // seek information for material
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Material_Description_Short FROM ref_Materials WHERE Material_Code = \'" + materialCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to material fields
            materialDescription = table.Rows[0][0].ToString();
            table.Reset();    // reset the table for later use

            // seek information for material
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Colour_Description_Short FROM ref_Colours WHERE Colour_Code = \'" + colorCode + "\';", connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data to color fields
            colorDescription = table.Rows[0][0].ToString();
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            designCodeTextbox.Text = designCode;
            productFamilyTextbox.Text = productFamily;
            brandTextbox.Text = "Ashlin®";
            designServiceFlagTextbox.Text = designServiceFlag;
            internalNameTextbox.Text = internalName;
            designDescriptionTextbox.Text = designDescription;
            materialCodeTextbox.Text = materialCode;
            materialDescriptionTextbox.Text = materialDescription;
            colorCodeTextbox.Text = colorCode;
            colorDescriptionTextbox.Text = colorDescription;
        }

        /* the event when deactivate sku button is clicked */
        private void deactivateSKUButton_Click(object sender, EventArgs e)
        {
            // initiliaze sku
            sku = skuCombobox.SelectedItem.ToString();

            // call background worker, the update button will only be activated if vaild color has been selected, so no need to check
            if (!backgroundWorkerDeactivate.IsBusy)
            {
                backgroundWorkerDeactivate.RunWorkerAsync();
            }
        }
        private void backgroundWorkerDeactivate_DoWork(object sender, DoWorkEventArgs e)
        {
            // simulate progress 1% ~ 60%
            for (int i = 1; i <= 60; i++)
            {
                Thread.Sleep(25);
                backgroundWorkerDeactivate.ReportProgress(i);
            }

            // connect to database and activate the color
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Active =  \'False\', Date_Deactivated = \'" + DateTime.Now.ToString() + "\' "
                                                  + "WHERE SKU_Ashlin = \'" + sku + "\'", connection);
                connection.Open();
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

        /* the event for active and inactive list button that open the table of active and inactive sku list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            InactiveSKUList inactiveSKUList = new InactiveSKUList();
            inactiveSKUList.ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            ActiveSKUList activeSKUList = new ActiveSKUList();
            activeSKUList.ShowDialog(this);
        }
    }
}
