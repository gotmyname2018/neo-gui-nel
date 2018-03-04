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
            string owner = textBoxAccount.Text;
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
        }
    }
}
