using SKU_Manager.ActiveInactiveList.ActiveInactiveTables;
using SKU_Manager.ExcelExportModules;
using SKU_Manager.ExcelExportModules.BrightpearlExports;
using SKU_Manager.SKUExportModules.Tables;
using SKU_Manager.SKUExportModules.Tables.ActiveAttributeTables;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.AmazonTables;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ChannelListing;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.ShopCaTables;
using SKU_Manager.SKUExportModules.Tables.ChannelPartnerTables.WalmartTables;
using SKU_Manager.SKUExportModules.Tables.eCommerceTables;
using SKU_Manager.SKUExportModules.Tables.PromotionalAssociationTables;
using System;
using System.Data;
using System.Windows.Forms;

namespace SKU_Manager.MainForms
{
    /*
    * An subpage that manage various eCommerce exports
    */
    public partial class ExcelExport : Form
    {
        // field for storing the root form
        private readonly IWin32Window parent;

        // field for storing table 
        private DataSet ds = new DataSet();
        private ExportTable[] exportTables;

        /* constructor that initialize graphic components and get the perent form */
        public ExcelExport(IWin32Window parent)
        {
            InitializeComponent();

            // get the root form
            this.parent = parent;
        }

        #region Active List
        /* the event for active list buttons click */
        private void activeColorButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new ActiveColorTable().GetTable());
            string[] names = new string[1];
            names[0] = "Active Color Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void activeMaterialButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new ActiveMaterialTable().GetTable());
            string[] names = new string[1];
            names[0] = "Active Material Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void activeFamilyButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new ActiveFamilyTable().GetTable());
            string[] names = new string[1];
            names[0] = "Active Family Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void activeDesignButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active Design Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1};
            textIndex[0] = index;

            exportTables = new ExportTable[1];
            exportTables[0] = new ActiveDesignTable();
            ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
            form.ShowDialog(this);

            if (form.Complete) // the tables have complete
            {
                // get the data
                ds = form.Tables;

                try
                {
                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // user close the form early 
                return;

            showExportMessage(saveFileDialog.FileName);
        }
        private void activeSkuButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active SKU Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1, 2, 3, 4, 13, 14};
            textIndex[0] = index;

            exportTables = new ExportTable[1];
            exportTables[0] = new ActiveSkuTable();
            ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
            form.ShowDialog(this);

            if (form.Complete) // the tables have complete
            {
                // get the data
                ds = form.Tables;

                try
                {
                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // user close the form early 
                return;

            showExportMessage(saveFileDialog.FileName);
        }
        #endregion

        #region Inactive List
        /* the event for inactive list buttons click */
        private void inactiveColorButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new InactiveColorTable().GetTable());
            string[] names = new string[1];
            names[0] = "Inactive Color Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void inactiveMaterialButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new InactiveMaterialTable().GetTable());
            string[] names = new string[1];
            names[0] = "Inactive Material Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void inactiveFamilyButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            ds.Tables.Add(new InactiveFamilyTable().GetTable());
            string[] names = new string[1];
            names[0] = "Inactive Family Export Sheet";
            try
            {
                new XlExport().NowExport(saveFileDialog.FileName, ds, names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            showExportMessage(saveFileDialog.FileName);
        }
        private void inactiveDesignButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active Design Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1};
            textIndex[0] = index;

            exportTables = new ExportTable[1];
            exportTables[0] = new InactiveDesignTable();
            ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
            form.ShowDialog(this);

            if (form.Complete) // the tables have complete
            {
                // get the data
                ds = form.Tables;

                try
                {
                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // user close the form early 
                return;

            showExportMessage(saveFileDialog.FileName);
        }
        private void inactiveSkuButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active SKU Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1, 2, 3, 4, 13, 14};
            textIndex[0] = index;

            exportTables = new ExportTable[1];
            exportTables[0] = new InactiveSkuTable();
            ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
            form.ShowDialog(this);

            if (form.Complete) // the tables have complete
            {
                // get the data
                ds = form.Tables;

                try
                {
                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // user close the form early 
                return;

            showExportMessage(saveFileDialog.FileName);
        }
        #endregion

        #region Active Attributes 
        /* the event for active price list button click that export active price list export table */
        private void activePriceListButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active Price List Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {3};
            textIndex[0] = index;

            if (Properties.Settings.Default.ActivePriceTable != null) // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.ActivePriceTable);

                try
                {
                    // export the excel files    
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new ActivePriceListTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete) // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    try
                    {
                        // export the excel files   
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // user close the form early 
                    return;

                Properties.Settings.Default.ActivePriceTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for upc button click that export upc export table */
        private void upcButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[1];
            names[0] = "UPC Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1, 2, 3};
            textIndex[0] = index;

            if (Properties.Settings.Default.UpcTable != null) // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.UpcTable);

                try
                {
                    // export the excel files    
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new UpcExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete) // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    try
                    {
                        // export the excel files 
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // user close the form early 

                    return;

                Properties.Settings.Default.UpcTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for stock quantity button click that export stock export table */
        private void stockButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            string[] names = new string[1];
            names[0] = "Active Price List Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = {1};
            textIndex[0] = index;

            if (Properties.Settings.Default.StockQuantityTable != null) // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.StockQuantityTable);

                try
                {
                    // export the excel files      
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new StockExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete) // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    try
                    {
                        // export the excel files   
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // user close the form early 

                    return;

                Properties.Settings.Default.StockQuantityTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }
        #endregion

        #region Channel Partners
        /* the event for multi channel listing button click that export multi channel listing export table */
        private void channelListingButton_Click(object sender, EventArgs e)
        {
            // local field for excel export and formatting
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] names = new string[3];
            names[0] = "All Channel Listing Sheet";
            names[1] = "Has Channel Listing Sheet";
            names[2] = "New Channel Listing Sheet";
            int[][] textIndex = new int[3][];
            int[] index = { 1, 2, 6, 8, 10, 12, 14, 16, 18};
            textIndex[0] = index;
            textIndex[1] = index;
            textIndex[2] = index;

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;
            ds.Reset();

            if (Properties.Settings.Default.ChannelListingTable != null && Properties.Settings.Default.ChannelHasListingTable != null && Properties.Settings.Default.ChannelNewListingTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.ChannelListingTable);
                ds.Tables.Add(Properties.Settings.Default.ChannelHasListingTable);
                ds.Tables.Add(Properties.Settings.Default.ChannelNewListingTable);

                // export the excel files               
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[3];
                exportTables[0] = new ChannelListingTable();
                exportTables[1] = new ChannelHasListingTable();
                exportTables[2] = new ChannelNewListingTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.ChannelListingTable = ds.Tables[0];
                Properties.Settings.Default.ChannelHasListingTable = ds.Tables[1];
                Properties.Settings.Default.ChannelNewListingTable = ds.Tables[2];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for bestbuy button click that export bestbuy export table */
        private void bestbuyButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            ds.Reset();
            string[] names = new string[1];
            names[0] = "Bestbuy Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1, 11 };
            textIndex[0] = index;

            if (Properties.Settings.Default.BestbuyTable1 != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.BestbuyTable1);

                // export the excel files         
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new BestbuyExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.BestbuyTable1 = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for amazon ca button click that export amazon ca export table */
        private void amazonCaButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                // local field for excel export
                XlExport export;
                try
                {
                    export = new XlExport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

                // fields for formatting
                ds.Reset();
                string[] names = new string[1];
                names[0] = "Amazon.ca Export Sheet";
                int[][] textIndex = new int[1][];
                int[] index = { 5, 7 };
                textIndex[0] = index;

                if (Properties.Settings.Default.AmazonCaTable != null)   // tables have already been saved
                {
                    ds.Tables.Add(Properties.Settings.Default.AmazonCaTable);

                    // export the excel files      
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // load the tables
                {
                    exportTables = new ExportTable[1];
                    exportTables[0] = new AmazonCaExportTable();
                    ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                    form.ShowDialog(this);

                    if (form.Complete)  // the tables have complete
                    {
                        // get the data
                        ds = form.Tables;

                        // export the excel files   
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    else    // user close the form early 
                        return;

                    Properties.Settings.Default.AmazonCaTable = ds.Tables[0];
                }

                showExportMessage(saveFileDialog.FileName);
            }
            else 
                MessageBox.Show("For performance purpose, please go to\n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }

        /* the event for amazon com button click that export amazon com export table */
        private void amazonComButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                // local field for excel export
                XlExport export;
                try
                {
                    export = new XlExport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

                // fields for formatting
                ds.Reset();
                string[] names = new string[1];
                names[0] = "Amazon.com Export Sheet";
                int[][] textIndex = new int[1][];
                int[] index = { 5, 7 };
                textIndex[0] = index;

                if (Properties.Settings.Default.AmazonComTable != null)   // tables have already been saved
                {
                    ds.Tables.Add(Properties.Settings.Default.AmazonComTable);

                    // export the excel files      
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // load the tables
                {
                    exportTables = new ExportTable[1];
                    exportTables[0] = new AmazonComExportTable();
                    ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                    form.ShowDialog(this);

                    if (form.Complete)  // the tables have complete
                    {
                        // get the data
                        ds = form.Tables;

                        // export the excel files   
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    else    // user close the form early 
                        return;

                    Properties.Settings.Default.AmazonComTable = ds.Tables[0];
                }

                showExportMessage(saveFileDialog.FileName);
            }
            else
                MessageBox.Show("For performance purpose, please go to\n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        }

        /* the event for staples button click that export staples export table */
        private void staplesButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Staples Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 6, 7 };
            textIndex[0] = index;

            if (Properties.Settings.Default.StaplesTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.StaplesTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new StaplesExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.StaplesTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for walamrt button click that export walmart export tables */
        private void walmartButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // fields for formatting
            ds.Reset();
            string[] names = new string[2];
            names[0] = "Walmart Item Export Sheet";
            names[1] = "Walmart Price Export Sheet";
            int[][] textIndex = new int[2][];
            int[] index1 = { 3 };
            textIndex[0] = index1;
            int[] index2 = { 1 };
            textIndex[1] = index2;

            if (Properties.Settings.Default.WalmartItemTable != null && Properties.Settings.Default.WalmartPriceTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.WalmartItemTable);
                ds.Tables.Add(Properties.Settings.Default.WalmartPriceTable);

                // export the excel files             
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[2];
                exportTables[0] = new WalmartItemExportTable();
                exportTables[1] = new WalmartPriceExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files               
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.WalmartItemTable = ds.Tables[0];
                Properties.Settings.Default.WalmartPriceTable = ds.Tables[1];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for shop ca button click that export shop ca export tables */
        private void shopCaButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StockQuantityTable != null)
            {
                // local field for excel export and formatting
                XlExport export;
                try
                {
                    export = new XlExport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] names = new string[4];
                names[0] = "Shop.ca Bag Attributes Sheet";
                names[1] = "Shop.ca Base Data Sheet";
                names[2] = "Shop.ca Inventory Sheet";
                names[3] = "Shop.ca Price List Sheet";
                int[][] textIndex = new int[4][];
                int[] index1 = { 3, 28 };
                textIndex[0] = index1;
                textIndex[1] = index1;
                int[] index2 = { 3 };
                textIndex[2] = index2;
                textIndex[3] = index2;

                if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;
                ds.Reset();

                if (Properties.Settings.Default.ShopCaBagTable != null && Properties.Settings.Default.ShopCaBaseDataTable != null && Properties.Settings.Default.ShopCaInventoryTable != null && Properties.Settings.Default.ShopCaPriceTable != null)   // tables have already been saved
                {
                    ds.Tables.Add(Properties.Settings.Default.ShopCaBagTable);
                    ds.Tables.Add(Properties.Settings.Default.ShopCaBaseDataTable);
                    ds.Tables.Add(Properties.Settings.Default.ShopCaInventoryTable);
                    ds.Tables.Add(Properties.Settings.Default.ShopCaPriceTable);

                    // export the excel files               
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // load the tables
                {
                    exportTables = new ExportTable[4];
                    exportTables[0] = new ShopCaBagExportTable();
                    exportTables[1] = new ShopCaBaseExportTable();
                    exportTables[2] = new ShopCaInventoryExportTable();
                    exportTables[3] = new ShopCaPriceExportTable();
                    ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                    form.ShowDialog(this);

                    if (form.Complete)  // the tables have complete
                    {
                        // get the data
                        ds = form.Tables;
                        export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                    }
                    else    // user close the form early 
                        return;

                    Properties.Settings.Default.ShopCaBagTable = ds.Tables[0];
                    Properties.Settings.Default.ShopCaBaseDataTable = ds.Tables[1];
                    Properties.Settings.Default.ShopCaInventoryTable = ds.Tables[2];
                    Properties.Settings.Default.ShopCaPriceTable = ds.Tables[3];
                }

                showExportMessage(saveFileDialog.FileName);
            }
            else
                MessageBox.Show("For performance purpose, please go to\n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
        } 

        /* the event for giant tiger button click that export ginat tiger export table */
        private void giantTigerButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Giant Tiger Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1 };
            textIndex[0] = index;

            if (Properties.Settings.Default.GiantTigerTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.GiantTigerTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new GiantTigerExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.GiantTigerTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }
        #endregion

        #region eCommerce
        /* the event for magento button click that export magento export table */
        private void magentoButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Magento Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1, 8 };
            textIndex[0] = index;

            if (Properties.Settings.Default.MagentoTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.MagentoTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new MagentoExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                    return;

                Properties.Settings.Default.MagentoTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for shop ca button click that will show the selection view for brightpearl */
        private void brightPearlButton_Click(object sender, EventArgs e)
        {
            new SelectionViewExcel().ShowDialog(this);
        }
        #endregion

        #region Promotional Association
        /* the event for uducat button click that export uducat export table */
        private void uducatButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "UDUCAT Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1 };
            textIndex[0] = index;

            if (Properties.Settings.Default.UducatTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.UducatTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new UducatExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                {
                    return;
                }

                Properties.Settings.Default.UducatTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for distributor central button click that export distributor central table */
        private void distributorCentralButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Distributor Central Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 3, 5, 12 };
            textIndex[0] = index;

            if (Properties.Settings.Default.DistributorCentralTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.DistributorCentralTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new DistributorCentralExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                {
                    return;
                }

                Properties.Settings.Default.DistributorCentralTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for asi button click that export asi table */
        private void aslEspButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "ASI Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 3 };
            textIndex[0] = index;

            if (Properties.Settings.Default.AsiTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.AsiTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new AsiExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                {
                    return;
                }

                Properties.Settings.Default.AsiTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }

        /* the event for sage button click that export sage table */
        private void sageButton_Click(object sender, EventArgs e)
        {
            // local field for excel export
            XlExport export;
            try
            {
                export = new XlExport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // local fields for formatting
            ds.Reset();
            string[] names = new string[1];
            names[0] = "Sage Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1, 7, 8 };
            textIndex[0] = index;

            if (Properties.Settings.Default.SageTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.SageTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new SageExportTable();
                ExportTableLoadingForm form = new ExportTableLoadingForm(exportTables);
                form.ShowDialog(this);

                if (form.Complete)  // the tables have complete
                {
                    // get the data
                    ds = form.Tables;

                    // export the excel files   
                    export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
                }
                else    // user close the form early 
                {
                    return;
                }

                Properties.Settings.Default.SageTable = ds.Tables[0];
            }

            showExportMessage(saveFileDialog.FileName);
        }
        #endregion

        #region Top Buttons
        /* the event when the top 1 button is clicked (view sku management) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            Close();

            new Splash(parent).Show(parent);
        }

        /* the event when the top 2 button is clicked (view sku export) */
        private void topButton2_Click(object sender, EventArgs e)
        {
            Close();

            new SkuExport(parent).Show(parent);
        }

        /* the event when the top 3 button is clicked (admin table) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            Close();

            new Admin(parent).Show(parent);
        }
        #endregion

        /* method that showing messagebox for sucessfully export an Excel file */
        private static void showExportMessage(string filePath)
        {
            MessageBox.Show("Excel file has been successfully exported in\n" + filePath, "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
