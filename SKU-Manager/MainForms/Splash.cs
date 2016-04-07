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
        private readonly IWin32Window parent;

        /* constructor that initializes the graphic component and work in background */
        public Splash(IWin32Window parent)
        {
            InitializeComponent();

            // set root form -> dashborad
            this.parent = parent;
        }

        #region Add
        /* the event for clicking add buttons */
        private void addColorButton_Click(object sender, EventArgs e)
        {
            new AddColor().ShowDialog(this);
        }
        private void addMaterialButton_Click(object sender, EventArgs e)
        {
            new AddMaterial().ShowDialog(this);
        }
        private void addFamilyButton_Click(object sender, EventArgs e)
        {
            new AddFamily().ShowDialog(this);
        }
        private void addDesignButton_Click(object sender, EventArgs e)
        {
            new AddDesign().ShowDialog(this);
        }
        private void addSkuButton_Click(object sender, EventArgs e)
        {
            new AddSKU().ShowDialog(this);
        }
        #endregion

        #region Update
        /* the event for clicking update buttons */
        private void updateColorButton_Click(object sender, EventArgs e)
        {
            new UpdateColor().ShowDialog(this);
        }
        private void updateMaterialButton_Click(object sender, EventArgs e)
        {
            new UpdateMaterial().ShowDialog(this);
        }
        private void updateFamilyButton_Click(object sender, EventArgs e)
        {
            new UpdateFamily().ShowDialog(this);
        }
        private void updateDesignButton_Click(object sender, EventArgs e)
        {
            new UpdateDesign().ShowDialog(this);
        }
        private void updateSkuButton_Click(object sender, EventArgs e)
        {
            new UpdateSKU().ShowDialog(this);
        }
        #endregion

        #region Activate
        /* the event for clicking activate buttons */
        private void activateColorButton_Click(object sender, EventArgs e)
        {
            new ActivateColor().ShowDialog(this);
        }
        private void activateMaterialButton_Click(object sender, EventArgs e)
        {
            new ActivateMaterial().ShowDialog(this);
        }
        private void activateFamilyButton_Click(object sender, EventArgs e)
        {
            new ActivateFamily().ShowDialog(this);
        }
        private void activateDesignButton_Click(object sender, EventArgs e)
        {
            new ActivateDesign().ShowDialog(this);
        }
        private void activateSkuButton_Click(object sender, EventArgs e)
        {
            new ActivateSKU().ShowDialog(this);
        }
        #endregion

        #region Deactivate
        /* the event for clicking deactivate buttons */
        private void deactivateColorButton_Click(object sender, EventArgs e)
        {
            new DeactivateColor().ShowDialog(this);
        }
        private void deactivateMaterialButton_Click(object sender, EventArgs e)
        {
            new DeactivateMaterial().ShowDialog(this);
        }
        private void deactivateFamilyButton_Click(object sender, EventArgs e)
        {
            new DeactivateFamily().ShowDialog(this);
        }
        private void deactivateDesignButton_Click(object sender, EventArgs e)
        {
            new DeactivateDesign().ShowDialog(this);
        }
        private void deactivateSkuButton_Click(object sender, EventArgs e)
        {
            new DeactivateSKU().ShowDialog(this);
        }
        #endregion

        #region Image Buttons
        /* the event for clicking update photo button */
        private void updateSkuImageButton_Click(object sender, EventArgs e)
        {
            new UpdatePhotoForm().ShowDialog();
        }

        /* the event for clicking update upc button */
        private void updateUpcImageButton_Click(object sender, EventArgs e)
        {
            new UpdateUPCForm().ShowDialog(this);
        }

        /* the event for clicking update global button */
        private void updateGlobalImageButton_Click(object sender, EventArgs e)
        {
            new UpdateGlobalForm().ShowDialog(this);
        }
        #endregion

        #region Top Buttons
        /* the event for clicking top button 1 (SKU Export) */
        private void topButton1_Click(object sender, EventArgs e)
        {
            Close();

            new SkuExport(parent).Show(parent);
        }

        /* the event for clicking top button 2 (export sku to excel) */
        private void topButton2_Click(object sender, EventArgs e)
        {
            Close();

            new ExcelExport(parent).Show(parent);
        }

        /* the event for clicking top button 3 (Admin) */
        private void topButton3_Click(object sender, EventArgs e)
        {
            Close();

            new Admin(parent).Show(parent);
        }
        #endregion
    }
}
