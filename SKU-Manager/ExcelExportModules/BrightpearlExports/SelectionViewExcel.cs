using SKU_Manager.SKUExportModules.Tables;
using System;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables;

namespace SKU_Manager.ExcelExportModules.BrightpearlExports
{
    public partial class SelectionViewExcel : Form
    {
        // field for storing tables
        private DataSet ds = new DataSet();
        private ExportTable[] exportTables;

        /* constructor that initialize graphic components */
        public SelectionViewExcel()
        {
            InitializeComponent();
        }

        /* the event for inventory button click */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            #region Error Check
            // the case if stock quantity table has not been loaded yet
            if (Properties.Settings.Default.StockQuantityTable == null)
            {
                MessageBox.Show("For performance purpose, please go to \n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.", "Sorry", MessageBoxButtons.OK);
                return;
            }

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
            #endregion

            // save the file
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // formatting fields
                ds.Reset();
                string[] names = new string[8];
                names[0] = "Coded Blank Price List";
                names[1] = "Coded Imprinted Price List";
                names[2] = "Rush Coded Blank Price List";
                names[3] = "Rush Coded Imprinted Price List";
                names[4] = "Net Blank Price List";
                names[5] = "Net Imprinted Price List";
                names[6] = "Rush Net Blank Price List";
                names[7] = "Rush Net Imprinted Price List";
                int[][] textIndex = new int[8][];
                int[] index = {2};
                for (int i = 0; i < 8; i++)
                    textIndex[i] = index;

                if (Properties.Settings.Default.BPcodedBlankTable != null &&
                    Properties.Settings.Default.BPcodedImprintTable != null &&
                    Properties.Settings.Default.BPrushCodedBlankTable != null &&
                    Properties.Settings.Default.BPrushCodedImprintTable != null
                    && Properties.Settings.Default.BPnetBlankTable != null &&
                    Properties.Settings.Default.BPnetImprintTable != null &&
                    Properties.Settings.Default.BPrushNetBlankTable != null &&
                    Properties.Settings.Default.BPrushNetImprintTable != null) // tables have already been saved
                {
                    ds.Tables.Add(Properties.Settings.Default.BPcodedBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPcodedImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushCodedBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushCodedImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPnetBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPnetImprintTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushNetBlankTable);
                    ds.Tables.Add(Properties.Settings.Default.BPrushNetImprintTable);

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
                else    // load the tables
                {
                    exportTables = new ExportTable[8];
                    exportTables[0] = new BPcodedBlankExportTable();
                    exportTables[1] = new BPcodedImprintExportTable();
                    exportTables[2] = new BPrushCodedBlankExportTable();
                    exportTables[3] = new BPrushCodedImprintExportTable();
                    exportTables[4] = new BPnetBlankExportTable();
                    exportTables[5] = new BPnetImprintExportTable();
                    exportTables[6] = new BPrushNetBlankExportTable();
                    exportTables[7] = new BPrushNetImprintExportTable();
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

                ShowExportMessage(saveFileDialog.FileName);
            }
        }

        /* the event for product button click */
        private void productButton_Click(object sender, EventArgs e)
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
            names[0] = "BP Product Export Sheet";
            int[][] textIndex = new int[1][];
            int[] index = { 1 };
            textIndex[0] = index;

            if (Properties.Settings.Default.BPproductTable != null)   // tables have already been saved
            {
                ds.Tables.Add(Properties.Settings.Default.BPproductTable);

                // export the excel files      
                export.NowExport(saveFileDialog.FileName, ds, names, textIndex);
            }
            else    // load the tables
            {
                exportTables = new ExportTable[1];
                exportTables[0] = new BPproductExportTable();
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

                Properties.Settings.Default.BPproductTable = ds.Tables[0];
            }

            ShowExportMessage(saveFileDialog.FileName);
        }

        /* method that showing messagebox for sucessfully export an Excel file */
        private static void ShowExportMessage(string filePath)
        {
            MessageBox.Show("Excel file has been successfully exported in \n" + filePath, "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
