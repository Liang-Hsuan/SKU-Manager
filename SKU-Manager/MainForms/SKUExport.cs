using System;
using System.Windows.Forms;
using SKU_Manager.ActiveInactiveList;
using SKU_Manager.SKUExportModules.ActiveAttributeExport;
using SKU_Manager.SKUExportModules.ActiveAttributeExports;
using SKU_Manager.SKUExportModules.ChannelPartnerExports;
using SKU_Manager.SKUExportModules.eCommerceExports;
using SKU_Manager.SKUExportModules.eCommerceExports.BrightpearlViews;
using SKU_Manager.SKUExportModules.PromotionalAssociationExports;

namespace SKU_Manager.MainForms
{
    public partial class SKUExport : Form
    {
        // field for getting the root form
        private IWin32Window parent;

        /* constructor that initialize all graphic components and its root form */
        public SKUExport(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        /* the event for active button click that show active list */
        private void activeColorButton1_Click(object sender, EventArgs e)
        {
            ActiveColorList activeColorList = new ActiveColorList();
            activeColorList.ShowDialog(this);
        }
        private void activeMaterialButton_Click(object sender, EventArgs e)
        {
            ActiveMaterialList activeMaterialList = new ActiveMaterialList();
            activeMaterialList.ShowDialog(this);
        }
        private void activeFamilyButton_Click(object sender, EventArgs e)
        {
            ActiveFamilyList activeFamilyList = new ActiveFamilyList();
            activeFamilyList.ShowDialog(this);
        }
        private void activeDesignButton_Click(object sender, EventArgs e)
        {
            ActiveDesignList activeDesignList = new ActiveDesignList();
            activeDesignList.ShowDialog(this);
        }
        private void activeSkuButton_Click(object sender, EventArgs e)
        {
            ActiveSKUList activeSKUList = new ActiveSKUList();
            activeSKUList.ShowDialog(this);
        }

        /* the event for inactive button click that show inactive list */
        private void inactiveColorButton_Click(object sender, EventArgs e)
        {
            InactiveColorList inactiveColorList = new InactiveColorList();
            inactiveColorList.ShowDialog(this);
        }
        private void inactiveMaterialButton_Click(object sender, EventArgs e)
        {
            InactiveMaterialList inactiveMaterialList = new InactiveMaterialList();
            inactiveMaterialList.ShowDialog(this);
        }
        private void inactiveFamilyButton_Click(object sender, EventArgs e)
        {
            InactiveFamilyList inactiveFamilyList = new InactiveFamilyList();
            inactiveFamilyList.ShowDialog(this);
        }
        private void inactiveDesignButton_Click(object sender, EventArgs e)
        {
            InactiveDesignList inactiveDesignList = new InactiveDesignList();
            inactiveDesignList.ShowDialog(this);
        }
        private void inactiveSkuButton_Click(object sender, EventArgs e)
        {
            InactiveSKUList inactiveSKUList = new InactiveSKUList();
            inactiveSKUList.ShowDialog(this);
        }

        /* the event for active price list button click */
        private void activePriceListButton_Click(object sender, EventArgs e)
        {
            ActivePriceView activePriceView = new ActivePriceView();
            activePriceView.ShowDialog(this);
        }

        /* the event for upc list button click */
        private void upcButton_Click(object sender, EventArgs e)
        {
            UpcExportView upcExportView = new UpcExportView();
            upcExportView.ShowDialog(this);
        }

        /* the event for stock quantity button click */
        private void stockButton_Click(object sender, EventArgs e)
        {
            StockQuantityView stockQuantityView = new StockQuantityView();
            stockQuantityView.ShowDialog(this);
        }

        /* the event for bestbest button click */
        private void bestbuyButton_Click(object sender, EventArgs e)
        {
            BestbuyView bestbuyView = new BestbuyView();
            bestbuyView.ShowDialog(this); 
        }

        /* the event for amazon.ca button click */
        private void amazonCaButton_Click(object sender, EventArgs e)
        {
            AmazonCaView amazonCaView = new AmazonCaView();
            amazonCaView.ShowDialog(this);
        }

        /* the event for amazon.com button click */
        private void amazonComButton_Click(object sender, EventArgs e)
        {
            AmazonComView amazonComView = new AmazonComView();
            amazonComView.ShowDialog(this);
        }

        /* the event for staples.ca button click */
        private void staplesButton_Click(object sender, EventArgs e)
        {
            StaplesView staplesView = new StaplesView();
            staplesView.ShowDialog(this);
        }

        /* the event for walmart.ca button click */
        private void walmartButton_Click(object sender, EventArgs e)
        {
            WalmartView walmartView = new WalmartView();
            walmartView.ShowDialog(this);
        }

        /* the event for shop.ca button click */
        private void shopCaButton_Click(object sender, EventArgs e)
        {
            ShopCaView shopCaView = new ShopCaView();
            shopCaView.ShowDialog(this);
        }

        /* the event for giant tiger button click */
        private void giantTigerButton_Click(object sender, EventArgs e)
        {
            GiantTigerView giantTigerView = new GiantTigerView();
            giantTigerView.ShowDialog(this);
        }

        /* the event for magento button click */
        private void magentoButton_Click(object sender, EventArgs e)
        {
            MagentoView magentoView = new MagentoView();
            magentoView.ShowDialog(this);
        }

        /* the event for brightpeal button click */
        private void brightPearlButton_Click(object sender, EventArgs e)
        {
            SelectionViewTable selectionView = new SelectionViewTable(this);
            selectionView.ShowDialog(this);
        }

        /* the event for uducat button click */
        private void uducatButton_Click(object sender, EventArgs e)
        {
            UducatView uducatView = new UducatView();
            uducatView.ShowDialog(this);
        }

        /* the event for distributor central button click */
        private void distributorCentralButton_Click(object sender, EventArgs e)
        {
            DistributorCentralView distributorCentralView = new DistributorCentralView();
            distributorCentralView.ShowDialog(this);
        }

        /* the event for top 1 button click (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            Splash splash = new Splash(parent);
            splash.Show(parent);
        }

        /* the event for top 2 button click (export sku to excel) */
        private void topButton2_Click(object sender, EventArgs e)
        {
            this.Close();

            ExcelExport excelExport = new ExcelExport(parent);
            excelExport.Show(parent);
        }

        /* the event for top 3 button click (modify dicount) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            this.Close();

            Admin admin = new Admin(parent);
            admin.Show(parent);
        }
    }
}
