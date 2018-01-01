using Neo.Core;
using Neo.GUIPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin_sample
{
    public partial class TestTran : Form
    {
        public IAPI2 api;

        public TestTran()
        {
            InitializeComponent();
        }

        private void TestTran_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var bts = Neo.Helper.HexToBytes(textBox1.Text);
                Transaction tx = CreateTransAction(bts[0]);

                using (var ms = new System.IO.MemoryStream(bts))
                {
                    using (var reader = new System.IO.BinaryReader(ms))
                    {
                        IVerifiable itx = tx;
                        itx.DeserializeUnsigned(reader);
                    }
                }
                api.SignAndShowInformation(tx);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        static Transaction CreateTransAction(byte b)
        {
            var type = (TransactionType)b;
            if (type == TransactionType.ContractTransaction)
            {
                return new ContractTransaction();
            }
            else if (type == TransactionType.InvocationTransaction)
            {
                return new InvocationTransaction();
            }
            return null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var bts = Neo.Helper.HexToBytes(textBox1.Text);
                Transaction tx = CreateTransAction(bts[0]);
                using (var ms = new System.IO.MemoryStream(bts))
                {
                    using (var reader = new System.IO.BinaryReader(ms))
                    {
                        IVerifiable itx = tx;
                        itx.Deserialize(reader);
                    }
                }
                api.SendRaw(tx);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
