using Neo.IO.Json;
using System;
using System.Windows.Forms;

namespace plugin_profile
{
    public partial class QueryAccountForm : Form
    {
        public QueryAccountForm()
        {
            InitializeComponent();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string profile;
            JObject j;
            bool verified = false;
            string owner = textBoxAccount.Text;
            if (owner.Contains("@"))
            {
                owner = ProfileContractHelper.QueryOwner(owner);
                verified = true;
            }
            j = ProfileContractHelper.QueryByAccount(owner);
            profile = j.ToString();
            string email = j["email"].AsString();
            if (email != "" && !verified)
            {
                JObject j1 = ProfileContractHelper.Query(email);
                string email1 = j1["email"].AsString();
                verified = email1.Equals(email);
            }
            textBoxProfile.Text = profile;
            labelVerificationStatus.Text = verified ? "Yes" : "No";
            textBoxAddress.Text = owner;
        }
    }
}
