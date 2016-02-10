using System;
using System.Windows.Forms;

namespace SKU_Manager.MainForms
{
    public partial class dashboard : Form
    {
        /* constructor that initialize graphic components */
        public dashboard()
        {
            InitializeComponent();
        }

        /* event for button1 (view sku management) click -> open Splash form */
        private void button1_Click(object sender, EventArgs e)
        {
            Splash splash = new Splash(this);
            splash.Show(this);
        }

        /* event for button2 (export sku to excel) click -> open Excel Export form */
        private void button2_Click(object sender, EventArgs e)
        {
            ExcelExport excelExport = new ExcelExport(this);
            excelExport.Show((this));
        }

        /* the event for button3 (view sku export) click -> open SKU Export form */
        private void button3_Click(object sender, EventArgs e)
        {
            SKUExport skuExport = new SKUExport(this);
            skuExport.Show(this);
        }

        /* event for button4 (admin table) click -> open Admin form */
        private void button4_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this);
            admin.Show(this);
        }
    }
}
