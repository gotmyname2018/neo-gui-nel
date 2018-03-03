using Neo;
using Neo.Wallets;
using System;
using System.Windows.Forms;

namespace plugin_profile
{
    public partial class MyProfileForm : Form
    {
        private bool editing = false;
        private string savedProfile;

        public MyProfileForm()
        {
            InitializeComponent();
        }

        public static byte[] FromHexString(string str)
        {
            byte[] data = new byte[str.Length / 2];
            for (var i = 0; i < str.Length / 2; i++)
            {
                var hex = str.Substring(i * 2, 2);
                data[i] = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }
            return data;
        }

        private void toggleEditMode()
        {
            editing = !editing;
            textBoxProfile.ReadOnly = !editing;
            buttonReset.Visible = editing;
            buttonEdit.Text = editing ? "Update" : "Edit";
            buttonQuery.Enabled = !editing;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            toggleEditMode();
            textBoxProfile.Text = savedProfile;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            toggleEditMode();
            if (editing) savedProfile = textBoxProfile.Text;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (plugin_profile.api.CurrentWallet != null)
            {
                var currWallet = plugin_profile.api.CurrentWallet;
                foreach (var account in currWallet.GetAccounts())
                {
                    var addrOut = account.ScriptHash;
                    string addrStr = Wallet.ToAddress(addrOut);
                    comboBoxAccounts.Items.Add(addrStr);
                }
                comboBoxAccounts.SelectedIndex = 0;
                comboBoxAccounts.Refresh();

                buttonEdit.Enabled = true;
                buttonQuery.Enabled = true;
            }
        }

        private void comboBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProfile.Text = comboBoxAccounts.Text;
        }
    }
}
