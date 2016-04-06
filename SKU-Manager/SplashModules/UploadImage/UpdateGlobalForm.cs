using System;
using System.ComponentModel;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.UploadImage
{
    /*
     * an application module for update all image uri and upc code image
     */
    public partial class UpdateGlobalForm : Form
    {
        // field for photo update
        private readonly UpdatePhoto photo = new UpdatePhoto();
        private readonly ImageReplace upc = new ImageReplace();

        /* constructor that initialize all the graphic components */
        public UpdateGlobalForm()
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
            promptLabel.Text = "Stage 1:\n" + 0 + " / " + photo.Total;
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
        /* background worker for updating image and add upc code image */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            // start doing work
            photo.StartUpdate();
            upc.AddGlobalUpc();
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
            if (photo.Progress <= photo.Total)
                promptLabel.Text = "Stage 1:\n" + photo.Progress + " / " + photo.Total;
            else
                promptLabel.Text = "Stage 2:\n" + upc.Progress + " / " + upc.Total;
        }
    }
}
