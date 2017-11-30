using Neo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plugin_seestorage
{
    public partial class SeeStorage : Form
    {
        public SeeStorage()
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
        private void button1_Click(object sender, EventArgs e)
        {
            var script_hash = UInt160.Parse(textBox1.Text);
            var key = FromHexString(this.textBox2.Text);
            var bchain = Neo.Core.Blockchain.Default;

            var skey = new Neo.Core.StorageKey();
            skey.Key = key;
            skey.ScriptHash = script_hash;


            var item = bchain.GetStorageItem(skey);
            this.listBox1.Items.Clear();
            if (item==null)
            {
                
                this.listBox1.Items.Add("<nothing>");

            }
            else
            {
                this.listBox1.Items.Add("hexstr:" + item.Value.ToHexString());
                var text = "";
                try
                {
                    text= System.Text.Encoding.UTF8.GetString(item.Value);
                }
                catch
                {

                }
                this.listBox1.Items.Add("as str:" + text);
                try
                {
                    System.Numerics.BigInteger num = 0;
                    num = new System.Numerics.BigInteger(item.Value);
                    this.listBox1.Items.Add("as num:" + num);
                }
                catch
                {

                }

            }
        }
    }
}
