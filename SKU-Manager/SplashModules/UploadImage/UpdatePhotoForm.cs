using System;
using System.ComponentModel;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.UploadImage
{
    /* 
     * an application module for update all the sku photo
     */
    public partial class UpdatePhotoForm : Form
    {
        // field for photo update
        private UpdatePhoto photo = new UpdatePhoto();

        /* constructor that initialize all the graphic components */
        public UpdatePhotoForm()
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
            promptLabel.Text = 0 + " / " + photo.Total;
            timer.Start();

            // start background worker to update image uri
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
        /* background worker for updating image */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            photo.startUpdate();
        }

        /* after updating completed, close the form */
        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
        #endregion

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            // set progress
            promptLabel.Text = photo.Progress + " / " + photo.Total;
        }
    }
}
