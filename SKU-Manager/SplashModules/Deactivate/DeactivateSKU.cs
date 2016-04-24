using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;

namespace SKU_Manager.SplashModules.Deactivate
{
   /*
   * An application module that deactivate a sku
   */
    public partial class DeactivateSku : Form
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
        private readonly ArrayList skuList = new ArrayList();

        /* constructor that initialize graphic components */
        public DeactivateSku()
        {
            InitializeComponent();
            skuList.Add("");

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
                SqlCommand command = new SqlCommand("SELECT SKU_Ashlin FROM master_SKU_Attributes WHERE Active = 'True' ORDER BY SKU_Ashlin", connection);    // for selecting data
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();    // for reading data
                while (reader.Read())
                    skuList.Add(reader.GetString(0));
            }
        }
        private void backgroundWorkerCombobox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            skuCombobox.DataSource = skuList;
        }
        #endregion

        #region Info Generation
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
                    backgroundWorkerInfo.RunWorkerAsync();
            }
            else
            {
                // set the text to nothing
                designCodeTextbox.Text = string.Empty;
                productFamilyTextbox.Text = string.Empty;
                brandTextbox.Text = string.Empty;
                designServiceFlagTextbox.Text = string.Empty;
                internalNameTextbox.Text = string.Empty;
                designDescriptionTextbox.Text = string.Empty;
                materialCodeTextbox.Text = string.Empty;
                materialDescriptionTextbox.Text = string.Empty;
                colorCodeTextbox.Text = string.Empty;
                colorDescriptionTextbox.Text = string.Empty;

                deactivateSKUButton.Enabled = false;
            }
        }
        private void backgroundWorkerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // local fields for storing data
            DataTable table = new DataTable();

            // store data to the table
            using (SqlConnection connection = new SqlConnection(Credentials.DesignCon))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT sku.Design_Service_Code, sku.Material_Code, sku.Colour_Code, " +
                                                            "Design_Service_Family_Code, Design_Service_Flag, Design_Service_Fashion_Name_Ashlin, Short_Description, " +
                                                            "Material_Description_Short, Colour_Description_Short " +
                                                            "FROM master_SKU_Attributes sku " + 
                                                            "INNER JOIN master_Design_Attributes design ON (design.Design_Service_Code = sku.Design_Service_Code) " +
                                                            "INNER JOIN ref_Materials material ON (material.Material_Code = sku.Material_Code) " +
                                                            "INNER JOIN ref_Colours color ON (color.Colour_Code = sku.Colour_Code) " +
                                                            "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
                connection.Open();
                adapter.Fill(table);
            }

            // assign data
            designCode = table.Rows[0][0].ToString();
            materialCode = table.Rows[0][1].ToString();
            colorCode = table.Rows[0][2].ToString();
            productFamily = table.Rows[0][3].ToString();
            designServiceFlag = table.Rows[0][4].ToString();
            internalName = table.Rows[0][5].ToString();
            designDescription = table.Rows[0][6].ToString();
            materialDescription = table.Rows[0][7].ToString();
            colorDescription = table.Rows[0][8].ToString();
        }
        private void backgroundWorkerInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            designCodeTextbox.Text = designCode;
            productFamilyTextbox.Text = productFamily;
            brandTextbox.Text = @"Ashlin®";
            designServiceFlagTextbox.Text = designServiceFlag;
            internalNameTextbox.Text = internalName;
            designDescriptionTextbox.Text = designDescription;
            materialCodeTextbox.Text = materialCode;
            materialDescriptionTextbox.Text = materialDescription;
            colorCodeTextbox.Text = colorCode;
            colorDescriptionTextbox.Text = colorDescription;
        }
        #endregion

        #region Deactivate
        /* the event when deactivate sku button is clicked */
        private void deactivateSKUButton_Click(object sender, EventArgs e)
        {
            // initiliaze sku
            sku = skuCombobox.SelectedItem.ToString();

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
                    SqlCommand command = new SqlCommand("UPDATE master_SKU_Attributes SET Active = 'False', SKU_Website = 'False', Date_Deactivated = \'" + DateTime.Today.ToString("yyyy-MM-dd") + "\' "
                                                      + "WHERE SKU_Ashlin = \'" + sku + '\'', connection);
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
                backgroundWorkerDeactivate.ReportProgress(i);
            }
        }
        private void backgroundWorkerDeactivate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        #endregion

        #region Active and Inactive
        /* the event for active and inactive list button that open the table of active and inactive sku list */
        private void activeListButton_Click(object sender, EventArgs e)
        {
            new InactiveSkuList().ShowDialog(this);
        }
        private void inactiveListButton_Click(object sender, EventArgs e)
        {
            new ActiveSkuList().ShowDialog(this);
        }
        #endregion
    }
}
