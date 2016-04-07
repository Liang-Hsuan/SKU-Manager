using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SKUExportModules.ActiveAttributeExports;
using SKU_Manager.SKUExportModules.ChannelPartnerExports;
using SKU_Manager.SKUExportModules.eCommerceExports;
using SKU_Manager.SKUExportModules.eCommerceExports.BrightpearlViews;
using SKU_Manager.SKUExportModules.PromotionalAssociationExports;

namespace SKU_Manager.MainForms
{
    public partial class SkuExport : Form
    {
        // field for getting the root form
        private readonly IWin32Window parent;

        /* constructor that initialize all graphic components and its root form */
        public SkuExport(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        #region Active List
        /* the event for active button click that show active list */
        private void activeColorButton1_Click(object sender, EventArgs e)
        {
            new ActiveColorList().ShowDialog(this);
        }
        private void activeMaterialButton_Click(object sender, EventArgs e)
        {
            new ActiveMaterialList().ShowDialog(this);
        }
        private void activeFamilyButton_Click(object sender, EventArgs e)
        {
            new ActiveFamilyList().ShowDialog(this);
        }
        private void activeDesignButton_Click(object sender, EventArgs e)
        {
            new ActiveDesignList().ShowDialog(this);
        }
        private void activeSkuButton_Click(object sender, EventArgs e)
        {
            new ActiveSKUList().ShowDialog(this);
        }
        #endregion

        #region Inactive List
        /* the event for inactive button click that show inactive list */
        private void inactiveColorButton_Click(object sender, EventArgs e)
        {
            new InactiveColorList().ShowDialog(this);
        }
        private void inactiveMaterialButton_Click(object sender, EventArgs e)
        {
            new InactiveMaterialList().ShowDialog(this);
        }
        private void inactiveFamilyButton_Click(object sender, EventArgs e)
        {
            new InactiveFamilyList().ShowDialog(this);
        }
        private void inactiveDesignButton_Click(object sender, EventArgs e)
        {
            new InactiveDesignList().ShowDialog(this);
        }
        private void inactiveSkuButton_Click(object sender, EventArgs e)
        {
            new InactiveSKUList().ShowDialog(this);
        }
        #endregion

        #region Active SKU List
        /* the event for active price list button click */
        private void activePriceListButton_Click(object sender, EventArgs e)
        {
            new ActivePriceView().ShowDialog(this);
        }

        /* the event for upc list button click */
        private void upcButton_Click(object sender, EventArgs e)
        {
            new UpcExportView().ShowDialog(this);
        }

        /* the event for stock quantity button click */
        private void stockButton_Click(object sender, EventArgs e)
        {
            new StockQuantityView().ShowDialog(this);
        }
        #endregion

        #region Channel Partners
        /* the event for multi channel listing button click */
        private void multichannelListingButton_Click(object sender, EventArgs e)
        {
            new ChannelListingView().ShowDialog(this);
        }

        /* the event for bestbest button click */
        private void bestbuyButton_Click(object sender, EventArgs e)
        {
            new BestbuyView().ShowDialog(this); 
        }

        /* the event for amazon.ca button click */
        private void amazonCaButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
                new AmazonCaView().ShowDialog(this);
            else
                MessageBox.Show("For performance purpose, please go to \n| Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }

        /* the event for amazon.com button click */
        private void amazonComButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
                new AmazonComView().ShowDialog(this);
            else
                MessageBox.Show("For performance purpose, please go to \n| Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }

        /* the event for staples.ca button click */
        private void staplesButton_Click(object sender, EventArgs e)
        {
            new StaplesView().ShowDialog(this);
        }

        /* the event for walmart.ca button click */
        private void walmartButton_Click(object sender, EventArgs e)
        {
            new WalmartView().ShowDialog(this);
        }

        /* the event for shop.ca button click */
        private void shopCaButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
                new ShopCaView().ShowDialog(this);
            else
                MessageBox.Show("For performance purpose, please go to \n| Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }

        /* the event for giant tiger button click */
        private void giantTigerButton_Click(object sender, EventArgs e)
        {
            new GiantTigerView().ShowDialog(this);
        }
        #endregion

        #region eCommerce ERP
        /* the event for magento button click */
        private void magentoButton_Click(object sender, EventArgs e)
        {
            new MagentoView().ShowDialog(this);
        }

        /* the event for brightpeal button click */
        private void brightPearlButton_Click(object sender, EventArgs e)
        {
            new SelectionViewTable(this).ShowDialog(this);
        }
        #endregion

        #region Promotional Association
        /* the event for uducat button click */
        private void uducatButton_Click(object sender, EventArgs e)
        {
            new UducatView().ShowDialog(this);
        }

        /* the event for distributor central button click */
        private void distributorCentralButton_Click(object sender, EventArgs e)
        {
            new DistributorCentralView().ShowDialog(this);
        }

        /* the event for sage button click */
        private void sageButton_Click(object sender, EventArgs e)
        {
            new SageView().ShowDialog(this);
        }
        #endregion

        #region Top Buttons
        /* the event for top 1 button click (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            Close();

            new Splash(parent).Show(parent);
        }

        /* the event for top 2 button click (export sku to excel) */
        private void topButton2_Click(object sender, EventArgs e)
        {
            Close();

            new ExcelExport(parent).Show(parent);
        }

        /* the event for top 3 button click (modify dicount) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            Close();

            new Admin(parent).Show(parent);
        }
        #endregion
    }
}
