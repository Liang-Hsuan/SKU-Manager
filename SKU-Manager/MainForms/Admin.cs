using System;
using System.Windows.Forms;
using SKU_Manager.AdminModules;

namespace SKU_Manager.MainForms
{
    /*
     * An subpage that manage discount matrix and hts tables
     */
    public partial class Admin : Form
    {
        // field for getting the root form
        private IWin32Window parent;

        /* constructor that initialize all graphic components */
        public Admin(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        /* the event when modify discount matrix button is clicked */
        private void modifyDiscountButton_Click(object sender, EventArgs e)
        {
            ModifyDiscount modifyDiscount = new ModifyDiscount();
            modifyDiscount.ShowDialog(this);
        }

        /* the event when update hts button is clicked */
        private void modifyHtsButton_Click(object sender, EventArgs e)
        {
            UpdateHTS updateHTS = new UpdateHTS();
            updateHTS.ShowDialog(this);
        }

        /* the event when the top 1 button is clicked (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            Splash splash = new Splash(parent);
            splash.Show(parent);
        }

        /* the event when the top 2 button is clicked (view excel export) */
        private void topButton2_Click(object sender, EventArgs e)
        {   
            this.Close();

            ExcelExport excelExport = new ExcelExport(parent);
            excelExport.Show((parent));
        }

        /* the event when the top 3 button is clicked (view sku exports) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            this.Close();

            SKUExport skuExport = new SKUExport(parent);
            skuExport.Show(parent);
        }
    }
}
