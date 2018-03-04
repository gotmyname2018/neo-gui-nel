using Neo;
using Neo.Wallets;
using Neo.IO.Json;
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
            Wallet currWallet = plugin_profile.api.CurrentWallet;
            WalletAccount account = currWallet.GetAccount(Wallet.ToScriptHash(comboBoxAccounts.Text));
            JObject j = ProfileContractHelper.QueryByKey(account.GetKey().PublicKey.EncodePoint(true));
            string profile = j.ToString();
            string email = j["email"].AsString();
            bool verified = false;
            if (email != "")
            {
                JObject j1 = ProfileContractHelper.Query(email);
                string email1 = j1["email"].AsString();
                verified = email1.Equals(email);
            }
            textBoxProfile.Text = profile;
            labelVerificationStatus.Text = verified ? "Yes" : "No";
            linkLabelVerifyLink.Visible = !verified && email != "";
        }
    }
}
