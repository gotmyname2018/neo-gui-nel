using Neo.Cryptography;
using Neo.IO.Json;
using Neo.Wallets;
using Neo.Cryptography.ECC;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace plugin_profile
{
    public partial class ManualVerifyForm : Form
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public ManualVerifyForm()
        {
            InitializeComponent();
        }

        private void ManualVerifyForm_Load(object sender, EventArgs e)
        {
            if (plugin_profile.api.CurrentWallet != null)
            {
                Wallet wallet = plugin_profile.api.CurrentWallet;
                foreach (var account in wallet.GetAccounts())
                {
                    var addrOut = account.ScriptHash;
                    string addrStr = Wallet.ToAddress(addrOut);
                    comboBoxAccounts.Items.Add(addrStr);
                }
                comboBoxAccounts.SelectedIndex = 0;
                comboBoxAccounts.Refresh();
            }

        }

        private bool CheckEmailAddressInput()
        {
            string email = textBoxPeerEmail.Text;
            int i = email.IndexOf("@");
            if (i <= 0 || i == email.Length - 1)
            {
                MessageBox.Show("Invalid email address provided", "Error!");
                return false;
            }
            return true;
        }

        private string CheckCurrentAccountProfile()
        {
            JObject profile = ProfileContractHelper.QueryByAccount(comboBoxAccounts.Text);
            string email = profile["email"].AsString();
            if (email == "")
            {
                MessageBox.Show("Your current account has no valid email binding yet, register one first", "Error!");
                return "";
            }
            return email;
        }

        private string ParseChallengeReceivedAndReturnResponseMessage(string myEmail)
        {
            string message = textBoxChallengeReceived.Text;
            string[] parts = message.Split('\n');
            if (parts.Length != 2)
            {
                MessageBox.Show("Received challenge message is invalid", "Error!");
                return "";
            }
            try
            {
                JObject j = JObject.Parse(parts[0]);
                string purpose = j["purpose"].AsString();
                string from = j["from"].AsString();
                string to = j["to"].AsString();
                string challenge = j["challenge"].AsString();
                if (purpose != "NEO email address verification challenge" || from.Length < 3 || challenge.Length != 16)
                {
                    MessageBox.Show("Received challenge message is invalid", "Error!");
                    return "";
                }
                if (to != myEmail)
                {
                    MessageBox.Show("Received challenge message is not send to current selected account", "Error!");
                    return "";
                }
                JObject j1 = new JObject();
                j1["purpose"] = "NEO email address verification response";
                j1["from"] = to;
                j1["to"] = from;
                j1["address"] = comboBoxAccounts.Text;
                j1["response"] = j["challenge"];
                return j1.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Received challenge message is invalid", "Error!");
                return "";
            }
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        private KeyPair GetAccountKeyPair(string accountAddr)
        {
            WalletAccount account = plugin_profile.api.CurrentWallet.GetAccount(Wallet.ToScriptHash(accountAddr));
            return account.GetKey();
        }

        private string Sign(string message, string accountAddr)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            KeyPair keys = GetAccountKeyPair(accountAddr);
            using (keys.Decrypt())
            {
                byte[] pubkey = keys.PublicKey.EncodePoint(false).Skip(1).ToArray();
                byte[] result = Crypto.Default.Sign(data, keys.PrivateKey, pubkey);
                return Convert.ToBase64String(result);
            }
        }

        private bool VerifySignature(string message, string signatureStr, string pubkeyStr)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            byte[] signature = Convert.FromBase64String(signatureStr);
            byte[] pubkey = ECPoint.Parse(pubkeyStr, ECCurve.Secp256r1).EncodePoint(false).Skip(1).ToArray();
            return Crypto.Default.VerifySignature(data, signature, pubkey);
        }

        private JObject ParseChallengeMessageSend(string message, string myEmail)
        {
            string[] parts = message.Split('\n');
            if (parts.Length != 2)
            {
                MessageBox.Show("Challenge message is invalid", "Error!");
                return null;
            }
            try
            {
                JObject j = JObject.Parse(parts[0]);
                string purpose = j["purpose"].AsString();
                string from = j["from"].AsString();
                string to = j["to"].AsString();
                string challenge = j["challenge"].AsString();
                if (purpose != "NEO email address verification challenge" || from.Length < 3 || challenge.Length != 16)
                {
                    MessageBox.Show("Challenge message is invalid", "Error!");
                    return null;
                }
                if (from != myEmail)
                {
                    MessageBox.Show("Challenge message is not send from current selected account", "Error!");
                    return null;
                }
                return j;
            }
            catch (Exception)
            {
                MessageBox.Show("Challenge message is invalid", "Error!");
                return null;
            }
        }

        private void buttonGenChallenge_Click(object sender, EventArgs e)
        {
            if (!CheckEmailAddressInput()) return;
            string email = CheckCurrentAccountProfile();
            if (email == "") return;
            string challenge = RandomString(16);
            string message = "{\"purpose\":\"NEO email address verification challenge\",\"from\":\""
                + email + "\",\"to\":\"" + textBoxPeerEmail.Text + "\",\"challenge\":\""+ challenge + "\"}";
            textBoxChallengeGenerated.Text = message + "\n" + Sign(message, comboBoxAccounts.Text);
        }

        private void buttonVerifyResponse_Click(object sender, EventArgs e)
        {
            if (!CheckEmailAddressInput()) return;
            string myEmail = CheckCurrentAccountProfile();
            JObject j = ParseChallengeMessageSend(textBoxChallengeSend.Text, myEmail);
            if (j == null) return;
            string challenge = j["challenge"].AsString();
            string message = textBoxResponseReceived.Text;
            string[] parts = message.Split('\n');
            if (parts.Length != 2)
            {
                MessageBox.Show("Received response message is invalid", "Error!");
                return;
            }
            try
            {
                JObject j1 = JObject.Parse(parts[0]);
                string purpose = j1["purpose"].AsString();
                string from = j1["from"].AsString();
                string to = j1["to"].AsString();
                string address = j1["address"].AsString();
                string response = j1["response"].AsString();
                if (purpose != "NEO email address verification response" || response.Length != 16)
                {
                    MessageBox.Show("Received response message is invalid", "Error!");
                    return;
                }
                if (from != textBoxPeerEmail.Text)
                {
                    MessageBox.Show("Received response message is not send from email addree to be verified", "Error!");
                    return;
                }
                if (to != myEmail)
                {
                    MessageBox.Show("Received response message is not send to current selected account", "Error!");
                    return;
                }
                JObject j2 = ProfileContractHelper.QueryByAccount(address);
                string peerEmail = j2["email"].AsString();
                if (peerEmail != from)
                {
                    MessageBox.Show("Received response message is send from email address different than its profile", "Error!");
                    return;
                }
                string pubkey = j2["pubkey"].AsString();
                if (!VerifySignature(parts[0], parts[1], pubkey))
                {
                    MessageBox.Show("Received response message has invalid signature!", "Error!");
                    return;
                }
                if (response != challenge)
                {
                    MessageBox.Show("Received response message has invalid response code than your original generated challenge code", "Error!");
                    return;
                }
                MessageBox.Show("The email address has pass all verication test successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Received challenge message is invalid", "Error!");
                return;
            }
        }

        private void buttonGenResponse_Click(object sender, EventArgs e)
        {
            string email = CheckCurrentAccountProfile();
            if (email == "") return;
            string responseMessage = ParseChallengeReceivedAndReturnResponseMessage(email);
            if (responseMessage == "") return;
            textBoxResponseGenerated.Text = responseMessage + "\n" + Sign(responseMessage, comboBoxAccounts.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                labelPeerEmail.Visible = false;
                textBoxPeerEmail.Visible = false;
            }
            else
            {
                labelPeerEmail.Visible = true;
                textBoxPeerEmail.Visible = true;
            }
        }
    }
}
