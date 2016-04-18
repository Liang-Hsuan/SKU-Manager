using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SKU_Manager.SupportingClasses;

namespace SKU_Manager.SplashModules
{
    /*
     * A spalsh add module that edit the online description
     */
    public partial class Online : Form
    {
        // fields for storing description
        public string English { get; private set; }
        public string French { get; private set; }

        /* first constructor that initialize graphic components and the title of the online description belongs to */
        public Online(string title, string english, string french, Color color)
        {
            InitializeComponent();

            // set the title and color
            Text = title;
            editButton.BackColor = color;

            // set fields
            englishTextbox.Text = english;
            frenchTextbox.Text = french;
        }

        /* second constructor that has tow more fields to determine if user can change text and the fore color of button */
        public Online(string title, string english, string french, Color color, Color foreColor, bool enable)
        {
            InitializeComponent();

            // set the title and color
            Text = title;
            editButton.BackColor = color;
            editButton.ForeColor = foreColor;

            // set fields
            englishTextbox.Text = english;
            frenchTextbox.Text = french;

            // the case is disable -> set controls to disabled
            if (enable) return;

            translateButton.Enabled = false;
            englishTextbox.Enabled = false;
            frenchTextbox.Enabled = false;
        }

        #region Translate
        /* translate button clicks that translate the given english text to french */
        private void translateButton_Click(object sender, EventArgs e)
        {
            // call background worker
            if (!backgroundWorkerTranslate.IsBusy)
                backgroundWorkerTranslate.RunWorkerAsync();
        }
        private void backgroundWorkerTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            // translate and get the french
            French = Translate.NowTranslate(englishTextbox.Text);
        }
        private void backgroundWorkerTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Translate.Error)
                MessageBox.Show("Error: " + Translate.ErrorMessage, "Translate Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                frenchTextbox.Text = French;
        }
        #endregion

        /* edit button clicks that set the online description for the client */
        private void editButton_Click(object sender, EventArgs e)
        {
            // get the online description
            English = englishTextbox.Text;
            French = frenchTextbox.Text;

            // set ok result
            DialogResult = DialogResult.OK;
        }
    }
}
