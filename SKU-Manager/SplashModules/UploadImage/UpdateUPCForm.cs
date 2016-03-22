using System;
using System.ComponentModel;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.UploadImage
{
    /*
     * an application module for update all the upc photo
     */
    public partial class UpdateUPCForm : Form
    {
        // field for updating
        private ImageReplace image = new ImageReplace();

        /* constructor that initialize all the graphic components */
        public UpdateUPCForm()
        {
            InitializeComponent();
        }

        #region Yes & No
        /* the event for yes button click */
        private void yesButton_Click(object sender, EventArgs e)
        {
            // set buttons invisible
            yesButton.Visible = false;
            noButton.Visible = false;

            // set progress
            promptLabel.Text = 0 + " / " + image.Total;
            timer.Start();

            // call background worker to add upc image
            if (!backgroundWorkerUpdate.IsBusy)
                backgroundWorkerUpdate.RunWorkerAsync();
        }

        /* the event for no button click */
        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Update Thread
        /* background worker for adding all upc photos */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            image.addGlobalUPC();
        }

        /* after adding completed, close the form */
        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
        #endregion

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            // set progress
            promptLabel.Text = image.Progress + " / " + image.Total;
        }
    }
}
