using System;
using System.Windows.Forms;

namespace SKU_Manager.MainForms
{
    public partial class dashboard : Form
    {
        private Splash splash;
        private ExcelExport excelExport;
        private SKUExport skuExport;
        private Admin admin;

        /* constructor that initialize graphic components */
        public dashboard()
        {
            InitializeComponent();

            splash = new Splash(this);
            excelExport = new ExcelExport(this);
            skuExport = new SKUExport(this);
        }

        /* event for button1 (view sku management) click -> open Splash form */
        private void button1_Click(object sender, EventArgs e)
        {
            if (!splash.Visible)
            {
                splash.Show(this);
            }
        }

        /* event for button2 (export sku to excel) click -> open Excel Export form */
        private void button2_Click(object sender, EventArgs e)
        {
            if (!excelExport.Visible)
            {
                excelExport.Show((this));
            }
        }

        /* the event for button3 (view sku export) click -> open SKU Export form */
        private void button3_Click(object sender, EventArgs e)
        {
            if (!skuExport.Visible)
            {
                skuExport.Show(this);
            }
        }

        /* event for button4 (admin table) click -> open Admin form */
        private void button4_Click(object sender, EventArgs e)
        {
            if (!admin.Visible)
            {
                admin.Show(this);
            }
        }
    }
}
