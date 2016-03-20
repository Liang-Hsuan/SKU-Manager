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
        // field for couting time
        private int timeLeft;

        /* constructor that initialize all the graphic components */
        public UpdatePhotoForm()
        {
            InitializeComponent();

            timeLeft = 4;
        }

        /* the event for yes button click */
        private void yesButton_Click(object sender, EventArgs e)
        {
            // set buttons invisible
            yesButton.Visible = false;
            noButton.Visible = false;

            // make the loading prompt
            promptLabel.Text = "Please wait";
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

        /* background worker for updating image */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdatePhoto updatePhoto = new UpdatePhoto();
            updatePhoto.startUpdate();
        }

        /* after updating completed, close the form */
        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        /* the event for timer that make the visual of loading promopt */
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            if (timeLeft <= 0)
            {
                promptLabel.Text = "Please wait";
                timeLeft = 4;
                timer.Start();
            }
            else
                promptLabel.Text += ".";
        }
    }
}
