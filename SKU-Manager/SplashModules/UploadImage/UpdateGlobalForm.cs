using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses.Photo;

namespace SKU_Manager.SplashModules.UploadImage
{
    /*
     * an application module for update all image uri and upc code image
     */
    public partial class UpdateGlobalForm : Form
    {
        // field for couting time
        int timeLeft;

        /* constructor that initialize all the graphic components */
        public UpdateGlobalForm()
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

            // call background worker to add upc image
            if (!backgroundWorkerUpdate.IsBusy)
            {
                backgroundWorkerUpdate.RunWorkerAsync();
            }
        }

        /* the event for no button click */
        private void noButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /* background worker for updating image and add upc code image */
        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            // fields for updating existing image to database and adding upc code image to dropbox
            UpdatePhoto updatePhoto = new UpdatePhoto();
            ImageReplace imageReplace = new ImageReplace();

            // start doing work
            updatePhoto.startUpdate();
            imageReplace.addGlobalUPC();
        }

        /* after updating completed, close the form */
        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
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
            {
                promptLabel.Text += ".";
            }
        }
    }
}
