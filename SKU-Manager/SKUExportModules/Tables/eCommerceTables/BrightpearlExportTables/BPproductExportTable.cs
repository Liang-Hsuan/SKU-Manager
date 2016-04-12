using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKU_Manager.SKUExportModules.Tables.eCommerceTables.BrightpearlExportTables
{
    public class BPproductExportTable : BPexportTable
    {
        /* constructor that initialize fields */
        public BPproductExportTable()
        {
            mainTable = new DataTable();
            skuList = GetSku();
        }

        public override DataTable GetTable()
        {
            // reset table just in case
            mainTable.Reset();

            // add column to table
            AddColumn(mainTable, "SKU");          // 1
            AddColumn(mainTable, "Name");                 // 2
            AddColumn(mainTable, "Brand");          // 3
            AddColumn(mainTable, "Category");           // 4
            AddColumn(mainTable, "PRICE (COST)");         // 5
            AddColumn(mainTable, "PRICE (WHOLE)");
            AddColumn(mainTable, "PRICE (RETAIL)");
            AddColumn(mainTable, "Tax Class");
            AddColumn(mainTable, "Manage Stock");
            AddColumn(mainTable, "Supplier");
            AddColumn(mainTable, "Collection");
            AddColumn(mainTable, "Weight");
            AddColumn(mainTable, "Barcode");
            AddColumn(mainTable, "EAN");
            AddColumn(mainTable, "ISBN");
            AddColumn(mainTable, "UPC");
            AddColumn(mainTable, "Sell code");
            AddColumn(mainTable, "Buy code");
            AddColumn(mainTable, "Stock code");
            AddColumn(mainTable, "Aisle");
            AddColumn(mainTable, "Bay");
            AddColumn(mainTable, "Shelf");
            AddColumn(mainTable, "Bin");
            AddColumn(mainTable, "Reorder level");
            AddColumn(mainTable, "Reorder qty");
            AddColumn(mainTable, "Bundle (SKU)");
            AddColumn(mainTable, "Colour");
            AddColumn(mainTable, "Size");
            AddColumn(mainTable, "Short Description");
            AddColumn(mainTable, "Long Description");
            AddColumn(mainTable, "Image");
            AddColumn(mainTable, "OPTION 3");
            AddColumn(mainTable, "OPTION 4");

            return mainTable;
        }

        /* override get discount method */
        protected override double[][] GetDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
