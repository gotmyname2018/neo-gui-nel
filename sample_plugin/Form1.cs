using Neo;
using Neo.Core;
using Neo.GUIPlugin;
using Neo.SmartContract;
using Neo.VM;
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
    public partial class Form1 : Form
    {
        public IAPI api;
        public Form1()
        {
            InitializeComponent();
        }
        ulong amount = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (api.CurrentWallet == null)
            {
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                return;
            }
            this.label5.Text = api.CurrentWallet.GetAccounts().First().Address;
            this.label6.Text = api.CurrentWallet.GetAccounts().First().Address;
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
        public static byte[] MakeAppCallScript(string script_hash, params ContractParameter[] _params)
        {
            //拼合调用脚本
            byte[] script = null;
            using (ScriptBuilder sb = new ScriptBuilder())
            {
                var hash = Neo.UInt160.Parse(script_hash);
                Neo.VM.Helper.EmitAppCall(sb, hash, _params);
                script = sb.ToArray();
            }
            return script;

        }
        public static StackItem TestCallScript(byte[] script, bool bDebug = false)
        {
            ApplicationEngine engine = null;

            if (bDebug)
            {
                engine = ApplicationEngine.RunWithDebug(script);
            }
            else
            {
                engine = ApplicationEngine.Run(script);
            }

            if (!engine.State.HasFlag(VMState.FAULT))
            {
                return engine.EvaluationStack.Last();
            }
            else
            {
                return null;
            }
        }
        public ApplicationEngine CallScript(byte[] script, bool bDebug = false)
        {
            ApplicationEngine engine = null;
            Fixed8 net_fee = Fixed8.FromDecimal(0.001m);
            //生成交易
            InvocationTransaction tx = new InvocationTransaction();
            {
                tx.Version = 1;
                tx.Script = script;
                tx.Attributes = new TransactionAttribute[0];
                tx.Inputs = new CoinReference[0];
                tx.Outputs = new TransactionOutput[0];
                if (bDebug)
                {
                    engine = ApplicationEngine.RunWithDebug(tx.Script, tx);
                }
                else
                {
                    engine = ApplicationEngine.Run(tx.Script, tx);
                }

                if (!engine.State.HasFlag(VMState.FAULT))
                {
                    tx.Gas = engine.GasConsumed - Fixed8.FromDecimal(10);
                    if (tx.Gas < Fixed8.Zero) tx.Gas = Fixed8.Zero;
                    tx.Gas = tx.Gas.Ceiling();
                }
                else
                {
                    MessageBox.Show("脚本错误");
                    return null;
                }
            }
            InvocationTransaction stx = null;
            Fixed8 fee = tx.Gas.Equals(Fixed8.Zero) ? net_fee : Fixed8.Zero;
            {
                stx = api.CurrentWallet.MakeTransaction(new InvocationTransaction
                {
                    Version = tx.Version,
                    Script = tx.Script,
                    Gas = tx.Gas,
                    Attributes = tx.Attributes,
                    Inputs = tx.Inputs,
                    Outputs = tx.Outputs
                }, fee: fee);
            }

            //签名发送交易
            api.SignAndShowInformation(stx);
            return engine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var scripthash = textBox1.Text;

            amount = 1;
            //查询
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "decimals"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[0]
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                var ts = TestCallScript(script);
                var n = ts.GetBigInteger();
                listBox1.Items.Add("decimals=" + n);
                for (var i = 0; i < n; i++)
                {
                    amount *= 10;
                }
            }
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "name"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[0]
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                var ts = TestCallScript(script);
                var n = ts.GetString();
                listBox1.Items.Add("name=" + n);

            }
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "symbol"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[0]
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                var ts = TestCallScript(script);
                var n = ts.GetString();
                listBox1.Items.Add("symbol=" + n);

            }
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "totalSupply"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[0]
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                var ts = TestCallScript(script);
                var n = (double)ts.GetBigInteger() / (double)amount;
                listBox1.Items.Add("totalSupply=" + n);

            }
        }
        static byte[] GetScriptHashFromAddress(string add)
        {
            //后四个自己是hash
            //第一个是魔法数字
            var bts = Neo.Cryptography.Base58.Decode(add);
            return bts.Take(bts.Length - 4).Skip(1).ToArray();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var scripthash = textBox1.Text;
            var addrscripthash = GetScriptHashFromAddress(textBox2.Text);
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "balanceOf"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[]
                    {
                        new ContractParameter(Neo.SmartContract.ContractParameterType.ByteArray)
                        {
                            Value =addrscripthash
                        }
                    }
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                var ts = TestCallScript(script);
                var n = (double)ts.GetBigInteger() / (double)amount;
                label3.Text = "balance:" + n;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var scripthash = textBox1.Text;
            var addrscripthash = GetScriptHashFromAddress(label5.Text);
            {
                var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
                {
                    Value = "deploy"
                };
                var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
                {
                    Value = new ContractParameter[]
                    {
                        new ContractParameter(Neo.SmartContract.ContractParameterType.ByteArray)
                        {
                            Value =addrscripthash
                        }
                    }
                };
                var script = MakeAppCallScript(scripthash, p1, p2);
                CallScript(script);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var scripthash = textBox1.Text;

            var fromscripthash = GetScriptHashFromAddress(label5.Text);

            var toscripthash = GetScriptHashFromAddress(textBox3.Text);
            var num = (uint)(double.Parse(textBox4.Text) * (double)amount);
            var p1 = new Neo.SmartContract.ContractParameter(Neo.SmartContract.ContractParameterType.String)
            {
                Value = "transfer"
            };
            var p2 = new ContractParameter(Neo.SmartContract.ContractParameterType.Array)
            {
                Value = new ContractParameter[]
                {
                        new ContractParameter(Neo.SmartContract.ContractParameterType.ByteArray)
                        {
                            Value =fromscripthash
                        },
                         new ContractParameter(Neo.SmartContract.ContractParameterType.ByteArray)
                        {
                            Value =toscripthash
                        },
                         new ContractParameter(Neo.SmartContract.ContractParameterType.Integer)
                        {
                            Value =num
                        }
                }
            };
            var script = MakeAppCallScript(scripthash, p1, p2);
            CallScript(script);
        }
    }
}
