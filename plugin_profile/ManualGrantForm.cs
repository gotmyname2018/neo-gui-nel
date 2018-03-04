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
    public partial class ManualGrantForm : Form
    {
        public ManualGrantForm()
        {
            InitializeComponent();
        }

        private void buttonGrant_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Length < 3 || textBoxAccount.Text.Length < 26)
            {
                MessageBox.Show("Invalid input", "Error!");
                return;
            }
            if (ProfileContractHelper.Grant(textBoxEmail.Text, textBoxAccount.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
