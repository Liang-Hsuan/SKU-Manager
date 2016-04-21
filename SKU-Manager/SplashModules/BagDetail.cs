using System.Drawing;
using System.Windows.Forms;

namespace SKU_Manager.SplashModules
{
    /*
     * A spalsh module that edit the bag detail
     */
    public partial class BagDetail : Form
    {
        public double ShoulderDropLength { get; private set; }
        public double HandleStrapDropLength { get; private set; }
        public string NotableStrapGeneralFeatures { get; private set; }
        public bool ProtectiveFeet { get; private set; }
        public string Closure { get; private set; }
        public bool InnerPocket { get; private set; }
        public bool OutsidePocket { get; private set; }
        public string SizeDifferentiation { get; private set; }

        /* first constructor that initialize the fields parameters */
        public BagDetail(double shoulderDropLength, double handleStrapLength, string notableStrapGeneralFeatures, bool protectiveFeet, string closure, bool innerPocket, bool outsidePocket, string sizeDifferentiation)
        {
            InitializeComponent();

            // declare fields
            shoulderDropLengthTextbox.Text = shoulderDropLength.ToString();
            handleStrapDropLengthTextbox.Text = handleStrapLength.ToString();
            notableStrapGeneralFeaturesCombobox.Text = notableStrapGeneralFeatures;
            protectiveFeetCombobox.SelectedIndex = protectiveFeet ? 1 : 0;
            closureCombobox.Text = closure;
            innerPocketCombobox.SelectedIndex = innerPocket ? 1 : 0;
            outsidePocketCombobox.SelectedIndex = outsidePocket ? 1 : 0;
            sizeDifferentiationCombobox.Text = sizeDifferentiation;
        }

        /* second constructor that initialize the fields parameters and set the color of the label and button */
        public BagDetail(double shoulderDropLength, double handleStrapLength, string notableStrapGeneralFeatures, bool protectiveFeet, string closure, bool innerPocket, bool outsidePocket, string sizeDifferentiation,
                         Color backColor, Color foreColor)
        {
            InitializeComponent();

            // declare fields
            shoulderDropLengthTextbox.Text = shoulderDropLength.ToString();
            handleStrapDropLengthTextbox.Text = handleStrapLength.ToString();
            notableStrapGeneralFeaturesCombobox.Text = notableStrapGeneralFeatures;
            protectiveFeetCombobox.SelectedIndex = protectiveFeet ? 1 : 0;
            closureCombobox.Text = closure;
            innerPocketCombobox.SelectedIndex = innerPocket ? 1 : 0;
            outsidePocketCombobox.SelectedIndex = outsidePocket ? 1 : 0;
            sizeDifferentiationCombobox.Text = sizeDifferentiation;

            // change back color
            shoulderDropLengthLabel.ForeColor = backColor;
            handleStrapDropLengthLabel.ForeColor = backColor;
            notableStrapGeneralFeaturesLabel.ForeColor = backColor;
            protectiveFeetLabel.ForeColor = backColor;
            closureLabel.ForeColor = backColor;
            innerPocketLabel.ForeColor = backColor;
            outsidePocketLabel.ForeColor = backColor;
            sizeDifferentiationLabel.ForeColor = backColor;
            saveButton.BackColor = backColor;

            // change fore color
            saveButton.ForeColor = foreColor;
        }

        /* edit button clicks that send the bag details for the client */
        private void saveButton_Click(object sender, System.EventArgs e)
        {
            ShoulderDropLength = double.Parse(shoulderDropLengthTextbox.Text);
            HandleStrapDropLength = double.Parse(handleStrapDropLengthTextbox.Text);
            NotableStrapGeneralFeatures = notableStrapGeneralFeaturesCombobox.Text;
            ProtectiveFeet = bool.Parse(protectiveFeetCombobox.Text);
            Closure = closureCombobox.Text;
            InnerPocket = bool.Parse(innerPocketCombobox.Text);
            OutsidePocket = bool.Parse(outsidePocketCombobox.Text);
            SizeDifferentiation = sizeDifferentiationCombobox.Text;

            // set ok result
            DialogResult = DialogResult.OK;
        }

        #region Key Press Event
        /* key press event that only allow number be entered */
        private void shoulderDropLengthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        private void handleStrapDropLengthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
        #endregion
    }
}
