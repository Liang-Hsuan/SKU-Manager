using SKU_Manager.SKUExportModules.Tables;
using System;
using System.Data;
using System.Windows.Forms;
using SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables;
using SKU_Manager.SupportingClasses;
using System.Data.SqlClient;

namespace SKU_Manager.ExcelExportModules.BrightpearlExports
{
    public partial class SelectionViewExcel : Form
    {
        // field for storing tables
        private DataSet ds = new DataSet();
        private ExportTable[] exportTables;

        // supporting field
        private readonly double usd;

        /* constructor that initialize graphic components */
        public SelectionViewExcel()
        {
            InitializeComponent();

            // get the rate for USD currency
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.Designcs))
            {
                SqlCommand command = new SqlCommand("SELECT Value FROM Currency WHERE Currency = 'USD'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                usd = reader.GetDouble(0);
            }
        }

        /* the event for inventory button click */
        private void inventoryButton_Click(object sender, EventArgs e)
        {
            #region Error Check
            // the case if stock quantity table has not been loaded yet
            if (Properties.Settings.Default.StockQuantityTable == null)
            {
                MessageBox.Show(
                    "For performance purpose, please go to\n| VIEW SKU EXPORTS -> Stock Quantity List | and load the table first.",
                    "Sorry", MessageBoxButtons.OK);
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
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return;

            // formatting fields
            ds.Reset();
            string[] names = new string[8];
            names[0] = "Coded Blank - CAD";
            names[1] = "Coded Imprinted - CAD";
            names[2] = "Rush Coded Blank - CAD";
            names[3] = "Rush Coded Imprinted- CAD";
            names[4] = "Net Blank - CAD";
            names[5] = "Net Imprinted - CAD";
            names[6] = "Rush Net Blank - CAD";
            names[7] = "Rush Net Imprinted - CAD";
            int[][] textIndex = new int[8][];
            int[] index = {2};
            for (int i = 0; i < 8; i++)
                textIndex[i] = index;

            // get the save path info
            string extension = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('.'));
            string path = saveFileDialog.FileName.Remove(saveFileDialog.FileName.LastIndexOf('.'));

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

                // the case if the save tables are in USD -> change sheets' names to USD
                if (Currency.CurrencyNow == "USD")
                {
                    names[0] = "Coded Blank - USD";
                    names[1] = "Coded Imprinted - USD";
                    names[2] = "Rush Coded Blank - USD";
                    names[3] = "Rush Coded Imprinted- USD";
                    names[4] = "Net Blank - USD";
                    names[5] = "Net Imprinted - USD";
                    names[6] = "Rush Net Blank - USD";
                    names[7] = "Rush Net Imprinted - USD";
                }

                try
                {
                    // export the excel files    
                    export.NowExport(path + '_' + Currency.CurrencyNow + extension, ds, names, textIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Currency.CurrencyNow == "USD")
                {
                    // change currency for each table -> to CAD
                    foreach (DataTable table in ds.Tables)
                    {
                        // change currency for each row in the table -> to CAD
                        foreach (DataRow row in table.Rows)
                        {
                            double[] costList = new double[9];
                            string cost = row[4].ToString();

                            costList[0] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[1] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[2] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[3] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[4] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[5] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[6] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[7] = double.Parse(cost.Remove(cost.IndexOf(';'))) / usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[8] = double.Parse(cost) / usd;

                            row[4] = costList[0] + "; " + costList[1] + "; " + costList[2] + "; " + costList[3] + "; " + costList[4] + "; " + costList[5] + "; " + costList[6] + "; " +
                                     costList[7] + "; " + costList[8];
                        }
                    }

                    // change sheets' names to CAD
                    names[0] = "Coded Blank - CAD";
                    names[1] = "Coded Imprinted - CAD";
                    names[2] = "Rush Coded Blank - CAD";
                    names[3] = "Rush Coded Imprinted- CAD";
                    names[4] = "Net Blank - CAD";
                    names[5] = "Net Imprinted - CAD";
                    names[6] = "Rush Net Blank - CAD";
                    names[7] = "Rush Net Imprinted - CAD";

                    try
                    {
                        // export the excel files   
                        export = new XlExport(); 
                        export.NowExport(path + "_CAD" + extension, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // change currency for each table -> to USD
                    foreach (DataTable table in ds.Tables)
                    {
                        // change currency for each row in the table -> to USD
                        foreach (DataRow row in table.Rows)
                        {
                            double[] costList = new double[9];
                            string cost = row[4].ToString();

                            costList[0] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[1] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[2] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[3] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[4] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[5] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[6] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[7] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[8] = double.Parse(cost) * usd;

                            row[4] = costList[0] + "; " + costList[1] + "; " + costList[2] + "; " + costList[3] + "; " + costList[4] + "; " + costList[5] + "; " + costList[6] + "; " +
                                     costList[7] + "; " + costList[8];
                        }
                    }

                    // change sheets' names to USD
                    names[0] = "Coded Blank - USD";
                    names[1] = "Coded Imprinted - USD";
                    names[2] = "Rush Coded Blank - USD";
                    names[3] = "Rush Coded Imprinted- USD";
                    names[4] = "Net Blank - USD";
                    names[5] = "Net Imprinted - USD";
                    names[6] = "Rush Net Blank - USD";
                    names[7] = "Rush Net Imprinted - USD";

                    try
                    {
                        // export the excel files  
                        export = new XlExport();  
                        export.NowExport(path + "_USD" + extension, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else // load the tables
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
                        export.NowExport(path + "_CAD" + extension, ds, names, textIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // change currency for each table -> to USD
                    foreach (DataTable table in ds.Tables)
                    {
                        // change currency for each row in the table -> to USD
                        foreach (DataRow row in table.Rows)
                        {
                            double[] costList = new double[9];
                            string cost = row[4].ToString();

                            costList[0] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[1] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[2] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[3] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[4] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[5] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[6] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[7] = double.Parse(cost.Remove(cost.IndexOf(';'))) * usd;
                            cost = cost.Substring(cost.IndexOf(';') + 2);

                            costList[8] = double.Parse(cost) * usd;

                            row[4] = costList[0] + "; " + costList[1] + "; " + costList[2] + "; " + costList[3] + "; " + costList[4] + "; " + costList[5] + "; " + costList[6] + "; " +
                                     costList[7] + "; " + costList[8];
                        }
                    }

                    // change sheets' names to USD
                    names[0] = "Coded Blank - USD";
                    names[1] = "Coded Imprinted - USD";
                    names[2] = "Rush Coded Blank - USD";
                    names[3] = "Rush Coded Imprinted- USD";
                    names[4] = "Net Blank - USD";
                    names[5] = "Net Imprinted - USD";
                    names[6] = "Rush Net Blank - USD";
                    names[7] = "Rush Net Imprinted - USD";

                    try
                    {
                        // export the excel files  
                        export = new XlExport();  
                        export.NowExport(path + "_USD" + extension, ds, names, textIndex);
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
            MessageBox.Show("Excel file has been successfully exported in\n" + filePath, "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
