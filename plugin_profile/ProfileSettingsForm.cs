using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin_profile
{
    public partial class ProfileSettingsForm : Form
    {
        private string savedContractScriptHash;

        public ProfileSettingsForm()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            plugin_profile.ContractScriptHash = textBoxContractHash.Text;
        }

        private void ProfileSettingsForm_Load(object sender, EventArgs e)
        {
            savedContractScriptHash = plugin_profile.ContractScriptHash;
            textBoxContractHash.Text = plugin_profile.ContractScriptHash;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            plugin_profile.ContractScriptHash = savedContractScriptHash;
            textBoxContractHash.Text = plugin_profile.ContractScriptHash;
        }
    }
}
