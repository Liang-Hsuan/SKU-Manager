using System;
using System.Windows.Forms;
using SKU_Manager.SplashModules.Activate;
using SKU_Manager.SplashModules.Add;
using SKU_Manager.SplashModules.Deactivate;
using SKU_Manager.SplashModules.Update;
using SKU_Manager.SplashModules.UploadImage;

namespace SKU_Manager.MainForms
{
    public partial class Splash : Form
    {
        // field for getting the root form
        private IWin32Window parent;

        /* constructor that initializes the graphic component and work in background */
        public Splash(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        /* the event for clicking add buttons */
        private void addColorButton_Click(object sender, EventArgs e)
        {
            AddColor addColor = new AddColor();
            addColor.ShowDialog(this);
        }
        private void addMaterialButton_Click(object sender, EventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            addMaterial.ShowDialog(this);
        }
        private void addFamilyButton_Click(object sender, EventArgs e)
        {
            AddFamily addFamily = new AddFamily();
            addFamily.ShowDialog(this);
        }
        private void addDesignButton_Click(object sender, EventArgs e)
        {
            AddDesign addDesign = new AddDesign();
            addDesign.ShowDialog(this);
        }
        private void addSkuButton_Click(object sender, EventArgs e)
        {
            AddSKU addDesign = new AddSKU();
            addDesign.ShowDialog(this);
        }

        /* the event for clicking update buttons */
        private void updateColorButton_Click(object sender, EventArgs e)
        {
            UpdateColor updateColor = new UpdateColor();
            updateColor.ShowDialog(this);
        }
        private void updateMaterialButton_Click(object sender, EventArgs e)
        {
            UpdateMaterial updateMaterial = new UpdateMaterial();
            updateMaterial.ShowDialog(this);
        }
        private void updateFamilyButton_Click(object sender, EventArgs e)
        {
            UpdateFamily updateFamily = new UpdateFamily();
            updateFamily.ShowDialog(this);
        }
        private void updateDesignButton_Click(object sender, EventArgs e)
        {
            UpdateDesign updateDesign = new UpdateDesign();
            updateDesign.ShowDialog(this);
        }
        private void updateSkuButton_Click(object sender, EventArgs e)
        {
            UpdateSKU updateSKU = new UpdateSKU();
            updateSKU.ShowDialog(this);
        }

        /* the event for clicking activate buttons */
        private void activateColorButton_Click(object sender, EventArgs e)
        {
            ActivateColor activateColor = new ActivateColor();
            activateColor.ShowDialog(this);
        }
        private void activateMaterialButton_Click(object sender, EventArgs e)
        {
            ActivateMaterial activateMaterial = new ActivateMaterial();
            activateMaterial.ShowDialog(this);
        }
        private void activateFamilyButton_Click(object sender, EventArgs e)
        {
            ActivateFamily activateFamily = new ActivateFamily();
            activateFamily.ShowDialog(this);
        }
        private void activateDesignButton_Click(object sender, EventArgs e)
        {
            ActivateDesign activateDesign = new ActivateDesign();
            activateDesign.ShowDialog(this);
        }
        private void activateSkuButton_Click(object sender, EventArgs e)
        {
            ActivateSKU activateSKU = new ActivateSKU();
            activateSKU.ShowDialog(this);
        }

        /* the event for clicking deactivate buttons */
        private void deactivateColorButton_Click(object sender, EventArgs e)
        {
            DeactivateColor deactivateColor = new DeactivateColor();
            deactivateColor.ShowDialog(this);
        }
        private void deactivateMaterialButton_Click(object sender, EventArgs e)
        {
            DeactivateMaterial deactivateMaterial = new DeactivateMaterial();
            deactivateMaterial.ShowDialog(this);
        }
        private void deactivateFamilyButton_Click(object sender, EventArgs e)
        {
            DeactivateFamily deactivateFamily = new DeactivateFamily();
            deactivateFamily.ShowDialog(this);
        }
        private void deactivateDesignButton_Click(object sender, EventArgs e)
        {
            DeactivateDesign deactivateDesign = new DeactivateDesign();
            deactivateDesign.ShowDialog(this);
        }
        private void deactivateSkuButton_Click(object sender, EventArgs e)
        {
            DeactivateSKU deactivateSKU = new DeactivateSKU();
            deactivateSKU.ShowDialog(this);
        }

        /* the event for clicking update photo button */
        private void updateSkuImageButton_Click(object sender, EventArgs e)
        {
            UpdatePhotoForm updatePhotoForm = new UpdatePhotoForm();
            updatePhotoForm.ShowDialog();
        }

        /* the event for clicking update upc button */
        private void updateUpcImageButton_Click(object sender, EventArgs e)
        {
            UpdateUPCForm updateUPCForm = new UpdateUPCForm();
            updateUPCForm.ShowDialog(this);
        }

        /* the event for clicking update global button */
        private void updateGlobalImageButton_Click(object sender, EventArgs e)
        {
            UpdateGlobalForm updateGlobalForm = new UpdateGlobalForm();
            updateGlobalForm.ShowDialog(this);
        }

        /* the event for clicking top button 1 (SKU Export) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            SKUExport skuExport = new SKUExport(parent);
            skuExport.Show(parent);
        }

        /* the event for clicking top button 2 (export sku to excel) */
        private void topButton2_Click(object sender, EventArgs e)
        {
            this.Close();

            ExcelExport excelExport = new ExcelExport(parent);
            excelExport.Show(parent);
        }

        /* the event for clicking top button 3 (Admin) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            this.Close();

            Admin admin = new Admin(parent);
            admin.Show(parent);
        }
    }
}
