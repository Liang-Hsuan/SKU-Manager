using System;
using System.Windows.Forms;

namespace SKU_Manager.MainForms
{
    public partial class dashboard : Form
    {
        // fields for children
        private Splash splash;
        private ExcelExport excelExport;
        private SkuExport skuExport;
        private Admin admin;

        // field for parent
        private readonly Form parent;

        /* constructor that initialize graphic components */
        public dashboard(Form parent)
        {
            InitializeComponent();

            splash = new Splash(this);
            excelExport = new ExcelExport(this);
            skuExport = new SkuExport(this);
            admin = new Admin(this);

            this.parent = parent;
        }

        /* event for button1 (view sku management) click -> open Splash form */
        private void button1_Click(object sender, EventArgs e)
        {
            if (splash.Visible) return;
            splash = new Splash(this);
            splash.Show(this);
        }

        /* event for button2 (export sku to excel) click -> open Excel Export form */
        private void button2_Click(object sender, EventArgs e)
        {
            if (excelExport.Visible) return;
            excelExport = new ExcelExport(this);
            excelExport.Show((this));
        }

        /* the event for button3 (view sku export) click -> open SKU Export form */
        private void button3_Click(object sender, EventArgs e)
        {
            if (skuExport.Visible) return;
            skuExport = new SkuExport(this);
            skuExport.Show(this);
        }

        /* event for button4 (admin table) click -> open Admin form */
        private void button4_Click(object sender, EventArgs e)
        {
            if (admin.Visible) return;
            admin = new Admin(this);
            admin.Show(this);
        }

        /* close dashboard will also close login board */
        private void dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            parent.Close();
        }
    }
}
