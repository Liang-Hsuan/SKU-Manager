using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SKU_Manager.SplashModules
{
    /*
     * A spalsh module that edit the bag and wallet detail
     */
    public partial class BagWalletDetail : Form
    {
        public double ShoulderDropLength { get; private set; }
        public double HandleStrapDropLength { get; private set; }
        public string NotableStrapGeneralFeatures { get; private set; }
        public bool ProtectiveFeet { get; private set; }
        public string Closure { get; private set; }
        public bool InnerPocket { get; private set; }
        public bool OutsidePocket { get; private set; }
        public string SizeDifferentiation { get; private set; }
        public bool DustBag { get; private set; }
        public bool AuthenticityCard { get; private set; }
        public int BillCompartment { get; private set; }
        public int CardSlot { get; private set; }

        /* first constructor that initialize the fields parameters */
        public BagWalletDetail(double shoulderDropLength, double handleStrapLength, string notableStrapGeneralFeatures, bool protectiveFeet, string closure, bool innerPocket, bool outsidePocket, string sizeDifferentiation,
                         bool dustBag, bool authenticityCard, int billCompartment, int cardSlot)
        {
            InitializeComponent();

            // declare fields
            shoulderDropLengthTextbox.Text = shoulderDropLength.ToString(CultureInfo.InvariantCulture);
            handleStrapDropLengthTextbox.Text = handleStrapLength.ToString(CultureInfo.InvariantCulture);
            notableStrapGeneralFeaturesCombobox.Text = notableStrapGeneralFeatures;
            protectiveFeetCombobox.SelectedIndex = protectiveFeet ? 0 : 1;
            closureCombobox.Text = closure;
            innerPocketCombobox.SelectedIndex = innerPocket ? 0 : 1;
            outsidePocketCombobox.SelectedIndex = outsidePocket ? 0 : 1;
            sizeDifferentiationCombobox.Text = sizeDifferentiation;
            if (dustBag) dustBagYesRadioButton.Checked = true; else dustBagNoRadioButton.Checked = true;
            if (authenticityCard) authenticityCardYesRadioButton.Checked = true; else authenticityCardNoRadioButton.Checked = true;
            switch (billCompartment)
            {
                case 1:
                    billCompartmentCombobox.SelectedIndex = 1;
                    break;
                case 2:
                    billCompartmentCombobox.SelectedIndex = 0;
                    break;
                default:
                    billCompartmentCombobox.SelectedIndex = 2;
                    break;
            }
            cardSlotUpdown.Value = cardSlot;
        }

        /* second constructor that initialize the fields parameters and set the color of the label and button */
        public BagWalletDetail(double shoulderDropLength, double handleStrapLength, string notableStrapGeneralFeatures, bool protectiveFeet, string closure, bool innerPocket, bool outsidePocket, string sizeDifferentiation,
                         bool dustBag, bool authenticityCard, int billCompartment, int cardSlot, Color backColor, Color foreColor)
        {
            InitializeComponent();

            // declare fields
            shoulderDropLengthTextbox.Text = shoulderDropLength.ToString(CultureInfo.InvariantCulture);
            handleStrapDropLengthTextbox.Text = handleStrapLength.ToString(CultureInfo.InvariantCulture);
            notableStrapGeneralFeaturesCombobox.Text = notableStrapGeneralFeatures;
            protectiveFeetCombobox.SelectedIndex = protectiveFeet ? 0 : 1;
            closureCombobox.Text = closure;
            innerPocketCombobox.SelectedIndex = innerPocket ? 0 : 1;
            outsidePocketCombobox.SelectedIndex = outsidePocket ? 0 : 1;
            sizeDifferentiationCombobox.Text = sizeDifferentiation;
            if (dustBag) dustBagYesRadioButton.Checked = true; else dustBagNoRadioButton.Checked = true;
            if (authenticityCard) authenticityCardYesRadioButton.Checked = true; else authenticityCardNoRadioButton.Checked = true;
            switch (billCompartment)
            {
                case 1:
                    billCompartmentCombobox.SelectedIndex = 1;
                    break;
                case 2:
                    billCompartmentCombobox.SelectedIndex = 0;
                    break;
                default:
                    billCompartmentCombobox.SelectedIndex = 2;
                    break;
            }
            cardSlotUpdown.Value = cardSlot;

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
            dustBagLabel.ForeColor = backColor;
            authenticityCardLabel.ForeColor = backColor;
            billCompartmentLabel.ForeColor = backColor;
            cardSlotLabel.ForeColor = backColor;

            // change fore color
            saveButton.ForeColor = foreColor;
        }

        /* edit button clicks that send the bag and wallet details for the client */
        private void saveButton_Click(object sender, System.EventArgs e)
        {
            ShoulderDropLength = shoulderDropLengthTextbox.Text != "" ? double.Parse(shoulderDropLengthTextbox.Text) : 0;
            HandleStrapDropLength = handleStrapDropLengthTextbox.Text != "" ? double.Parse(handleStrapDropLengthTextbox.Text) : 0;
            NotableStrapGeneralFeatures = notableStrapGeneralFeaturesCombobox.Text;
            ProtectiveFeet = bool.Parse(protectiveFeetCombobox.Text);
            Closure = closureCombobox.Text;
            InnerPocket = bool.Parse(innerPocketCombobox.Text);
            OutsidePocket = bool.Parse(outsidePocketCombobox.Text);
            SizeDifferentiation = sizeDifferentiationCombobox.Text;
            DustBag = dustBagYesRadioButton.Checked;
            AuthenticityCard = authenticityCardYesRadioButton.Checked;
            switch (billCompartmentCombobox.SelectedIndex)
            {
                case 0:
                    BillCompartment = 2;
                    break;
                case 1:
                    BillCompartment = 1;
                    break;
                default:
                    BillCompartment = 0;
                    break;
            }
            CardSlot = (int)cardSlotUpdown.Value;

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
