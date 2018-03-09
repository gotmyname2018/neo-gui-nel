using Neo;
using Neo.Wallets;
using Neo.IO.Json;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace plugin_profile
{
    public partial class MyProfileForm : Form
    {
        private bool editing = false;
        private string savedProfile;
        private string emailVerifyReqUrl;
        private Dictionary<string, string> emailVerifyReqParams;

        public MyProfileForm()
        {
            InitializeComponent();
        }

        private void ToggleEditMode()
        {
            editing = !editing;
            textBoxProfile.ReadOnly = !editing;
            buttonReset.Visible = editing;
            buttonEdit.Text = editing ? "Update" : "Edit";
            buttonQuery.Enabled = !editing;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ToggleEditMode();
            textBoxProfile.Text = savedProfile;
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            RefreshCurrentAccountProfile();
        }

        private byte[] GetCurrentAccountPublicKey()
        {
            Wallet wallet = plugin_profile.api.CurrentWallet;
            WalletAccount account = wallet.GetAccount(Wallet.ToScriptHash(comboBoxAccounts.Text));
            return account.GetKey().PublicKey.EncodePoint(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                try
                {
                    JObject j = JObject.Parse(textBoxProfile.Text);
                    if (j["email"] == null)
                    {
                        MessageBox.Show("The email address is missing in the profile", "Error!");
                        return;
                    }
                    j["pubkey"] = GetCurrentAccountPublicKey().ToHexString();
                    ProfileContractHelper.Register(j.ToString(), comboBoxAccounts.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("The profile should be a valid json object", "Error!");
                    return;
                }
            }
            else
            {
                savedProfile = textBoxProfile.Text;
            }
            ToggleEditMode();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (plugin_profile.api.CurrentWallet != null)
            {
                emailVerifyReqUrl = ProfileContractHelper.EmailVerifyRequestUrl();
                Wallet wallet = plugin_profile.api.CurrentWallet;
                foreach (var account in wallet.GetAccounts())
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

        private void RefreshCurrentAccountProfile()
        {
            string owner = comboBoxAccounts.Text;
            JObject j = ProfileContractHelper.QueryByAccount(owner);
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
            if (linkLabelVerifyLink.Visible)
            {
                emailVerifyReqParams = new Dictionary<string, string>() {
                    { "email", email },
                    { "owner", owner },
                };
            }
        }
        private void comboBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCurrentAccountProfile();
        }

        private void linkLabelVerifyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string resp = HttpHelper.Get(emailVerifyReqUrl, emailVerifyReqParams);
            if (resp == "")
            {
                MessageBox.Show("Failed to get response from verification server", "Error!");
                return;
            }
            try
            {
                JObject j = JObject.Parse(resp);
                if (j["result"].AsBoolean())
                {
                    MessageBox.Show("Verification request send to verification server successfully, a verfication challenge message will be send to your email address, check it");
                }
                else
                {
                    MessageBox.Show("Verification server failed to handle the request due to error: " + j["error"].AsString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Received invalid response from verification server", "Error!");
                return;
            }
        }
    }
}
