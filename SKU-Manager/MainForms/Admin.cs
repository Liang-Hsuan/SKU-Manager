using System;
using System.Windows.Forms;
using SKU_Manager.AdminModules.ImportUpdate;
using System.Threading;
using SKU_Manager.AdminModules.DirectUpdate;
using SKU_Manager.AdminModules.UpdateInventory;
using System.Data;
using SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables;

namespace SKU_Manager.MainForms
{
    /*
     * An subpage that manage discount matrix and hts tables
     */
    public partial class Admin : Form
    {
        // field for getting the root form
        private readonly IWin32Window parent;

        // field for channel new import 
        private Sears sears;
        private ShopCa shopCa;
        private Amazon amazon;
        private GiantTiger giantTiger;

        /* constructor that initialize all graphic components */
        public Admin(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        #region Modify 
        /* the event when modify discount matrix button is clicked */
        private void modifyDiscountButton_Click(object sender, EventArgs e)
        {
            new ModifyDiscount().ShowDialog(this);
        }

        /* the event when modify channel pricing button is clicked */
        private void modifyChannelPricingButton_Click(object sender, EventArgs e)
        {
            new ModifyChannelPricing().ShowDialog(this);
        }

        /* the event when modify channel listing button is clicked */
        private void modifyChannelListingButton_Click(object sender, EventArgs e)
        {
            new ModifyChannelListing().ShowDialog(this);
        }

        /* the event when update hts button is clicked */
        private void modifyHtsButton_Click(object sender, EventArgs e)
        {
            new UpdateHts().ShowDialog(this);
        }
        #endregion

        #region Amazon Event
        private void amazonButton_Click(object sender, EventArgs e)
        {
            excelButton.Visible = false;
            refreshButton.Visible = false;
            inventoryButton.Visible = false;
            loadingLabel.Visible = false;
        }

        private void amazonButton_MouseHover(object sender, EventArgs e)
        {
            loadingLabel.Text = @"Amazon";
            loadingLabel.Visible = true;
            excelButton.Visible = true;
            refreshButton.Visible = true;
            inventoryButton.Visible = true;
        }
        #endregion

        #region Sears Event
        /* sears button clicks that update the new import of inventory for sears */
        private void searsButton_Click(object sender, EventArgs e)
        {
            excelButton.Visible = false;
            refreshButton.Visible = false;
            inventoryButton.Visible = false;
            loadingLabel.Visible = false;
        }

        /* sears button hover that show sear's functions */
        private void searsButton_MouseHover(object sender, EventArgs e)
        {
            loadingLabel.Text = @"Sears";
            loadingLabel.Visible = true;
            excelButton.Visible = true;
            refreshButton.Visible = true;
            inventoryButton.Visible = true;
        }
        #endregion

        #region ShopCa Event
        /* shop.ca button clicks that update the new import of inventory for shop.ca */
        private void shopCaButton_Click(object sender, EventArgs e)
        {
            excelButton.Visible = false;
            refreshButton.Visible = false;
            inventoryButton.Visible = false;
            loadingLabel.Visible = false;
        }

        /* shop.ca button hover that show shop.ca's functions */
        private void shopCaButton_MouseHover(object sender, EventArgs e)
        {
            loadingLabel.Text = @"Shop.ca";
            loadingLabel.Visible = true;
            excelButton.Visible = true;
            refreshButton.Visible = true;
            inventoryButton.Visible = true;
        }
        #endregion

        #region Giant Tiger Event
        /* giant tiger button clicks that update the new import of inventory for giant tiger */
        private void giantTigerButton_Click(object sender, EventArgs e)
        {
            excelButton.Visible = false;
            refreshButton.Visible = false;
            inventoryButton.Visible = false;
            loadingLabel.Visible = false;
        }

        /* giant tiger button hover that show giant tiger's functions */
        private void giantTigerButton_MouseHover(object sender, EventArgs e)
        {
            loadingLabel.Text = @"Giant Tiger";
            loadingLabel.Visible = true;
            excelButton.Visible = true;
            refreshButton.Visible = true;
            inventoryButton.Visible = true;
        }
        #endregion

        #region Channel Mangement
        /* the event for excel button clicks that update the merchant sku */
        private void excelButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

            switch (loadingLabel.Text)
            {
                case "Sears":
                    {
                        // sears case
                        sears = new Sears();
                        Thread thread = new Thread(() => sears.Update(openFileDialog.FileName));
                        thread.Start();
                        thread.Join();

                        // error check
                        if (sears.Error)
                        {
                            MessageBox.Show("Error occurs during updating:\n" + sears.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        shopCa = null;
                        amazon = null;
                        giantTiger = null;
                    }
                    break;
                case "Shop.ca":
                    {
                        // shop.ca case
                        shopCa = new ShopCa();
                        Thread thread = new Thread(() => shopCa.Update(openFileDialog.FileName));
                        thread.Start();
                        thread.Join();

                        // error check
                        if (shopCa.Error)
                        {
                            MessageBox.Show("Error occurs during updating:\n" + shopCa.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        sears = null;
                        giantTiger = null;
                        amazon = null;
                    }
                    break;
                case "Amazon":
                    {
                        // amazon case
                        amazon = new Amazon();
                        Thread thread = new Thread(() => amazon.Update(openFileDialog.FileName));
                        thread.Start();
                        thread.Join();

                        // error check
                        if (amazon.Error)
                        {
                            MessageBox.Show("Error occurs during updating:\n" + amazon.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        sears = null;
                        shopCa = null;
                        giantTiger = null;
                    }
                    break;
                case "Giant Tiger":
                    {
                        // giant tiger case
                        giantTiger = new GiantTiger();
                        Thread thread = new Thread(() => giantTiger.Update(openFileDialog.FileName));
                        thread.Start();
                        thread.Join();

                        // error check
                        if (giantTiger.Error)
                        {
                            MessageBox.Show("Error occurs during updating:\n" + giantTiger.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        sears = null;
                        shopCa = null;
                        amazon = null;
                    }
                    break;
            }

            timer.Start();
        }

        #region Refresh Button
        /* refresh buuton mouse hover that show the tooltip */
        private void refreshButton_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(refreshButton, "Refresh Button");
        }

        /* refresh button clicks that load the stock quantity table */
        private void refreshButton_Click(object sender, EventArgs e)
        {
            // set wait cursor
            Cursor.Current = Cursors.WaitCursor;

            DataTable table = new StockExportTable().GetTable();
            Properties.Settings.Default.StockQuantityTable = table;

            // set default cursor after complete
            Cursor.Current = Cursors.Default;
        }
        #endregion

        /* the event for inventory button clicks that manage the inventory for eCommerce channel */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                switch (loadingLabel.Text)
                {
                    case "Sears":
                        new SearsInventory().ShowDialog(this);
                        break;
                    case "Shop.ca":
                        new ShopCaInventory().ShowDialog(this);
                        break;
                    case "Amazon":
                        break;
                    case "Giant Tiger":
                        new GiantTigerInventory().ShowDialog(this);
                        break;
                }
            }
            else
                MessageBox.Show("For performance purpose, please click refresh button first", "Sorry", MessageBoxButtons.OK);
        }
        #endregion

        #region Top Buttons
        /* the event when the top 1 button is clicked (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            Close();

            new Splash(parent).Show(parent);
        }

        /* the event when the top 2 button is clicked (view excel export) */
        private void topButton2_Click(object sender, EventArgs e)
        {   
            Close();

            new ExcelExport(parent).Show(parent);
        }

        /* the event when the top 3 button is clicked (view sku exports) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            Close();

            new SkuExport(parent).Show(parent);
        }
        #endregion

        /* timer event that show the progress of import update */
        private void timer_Tick(object sender, EventArgs e)
        {
            if (sears != null)
            {
                // sears case
                // check if updating is finish -> stop the timer and set text to nothing
                if (sears.Current >= sears.Total)
                {
                    timer.Stop();
                    loadingLabel.Text = @"Sears";
                }
                else
                    loadingLabel.Text = sears.Current + " / " + sears.Total;
            }
            else if (shopCa != null)
            {
                // shop.ca case
                // check if updating is finish -> stop the timer and set text to nothing
                if (shopCa.Current >= shopCa.Total)
                {
                    timer.Stop();
                    loadingLabel.Text = @"Shop.ca";
                }
                else
                    loadingLabel.Text = shopCa.Current + " / " + shopCa.Total;
            }
            else if (amazon != null)
            {
                // amazon case
                // check if updating is finish -> stop the timer and set text to nothing
                if (amazon.Current >= amazon.Total)
                {
                    timer.Stop();
                    loadingLabel.Text = @"Amazon";
                }
                else
                    loadingLabel.Text = amazon.Current + " / " + amazon.Total;
            }
            else if (giantTiger != null)
            {
                // giant tiger case
                // check if updating is finish -> stop the timer and set text to nothing
                if (giantTiger.Current >= giantTiger.Total)
                {
                    timer.Stop();
                    loadingLabel.Text = @"Giant Tiger";
                }
                else
                    loadingLabel.Text = giantTiger.Current + " / " + giantTiger.Total;
            }
        }
    }
}
