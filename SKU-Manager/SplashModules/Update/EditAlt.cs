using System;
using System.Windows.Forms;

namespace SKU_Manager.SplashModules.Update
{
   /*
    * An application module for UpdateSKU that edit the text of alt
    */
    public partial class EditAlt : Form
    {
        public string altText;

        /* constructor that initilize graphic components and the alt text of the selected image */
        public EditAlt(string altText)
        {
            InitializeComponent();

            // set the textbox's text to alt text
            altTextbox.Text = altText;

            // initilize original alt text field
            this.altText = altText;
        }

        /* the event for edit button click that update the alt text for the image */
        private void editButton_Click(object sender, EventArgs e)
        {
            // update alt text field
            altText = altTextbox.Text;
            DialogResult = DialogResult.OK;
        }

        /* the event when cancel button is clicked */
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
