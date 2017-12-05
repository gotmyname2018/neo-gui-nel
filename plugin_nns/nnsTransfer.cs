using Neo;
using Neo.Core;
using Neo.SmartContract;
using Neo.VM;
using Neo.Wallets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace plugin_nns
{
    public partial class nnsTransfer : Form
    {
        //定义nns注册器合约hash
        private static readonly string NnsResolverAddrScripthash = "706c89208c5b6016a054a58cc83aeda0d70f0f95";

        Dictionary<string, string> dAsset = new Dictionary<string, string>();
        Dictionary<string, UInt160> dAddress = new Dictionary<string, UInt160>();

        public nnsTransfer()
        {
            InitializeComponent();

            dAsset.Add("NEO", "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
            dAsset.Add("GAS", "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7");
        }

        private void nnsTransfer_Load(object sender, EventArgs e)
        {
            if (plugin_nns.api.CurrentWallet != null)
            {
                var currWallet = plugin_nns.api.CurrentWallet;
                foreach (UInt160 addrOut in currWallet.GetAddresses())
                {
                    string addrStr = Wallet.ToAddress(addrOut);

                    dAddress.Add(addrStr, addrOut);

                    comAddrOut.Items.Add(addrStr);
                }
                comAddrOut.SelectedIndex = 0;
                comAddrOut.Refresh();

                comAsset.Enabled = true;
            }
        }

        private void linkTXID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited 
            // to true.
            linkTXID.LinkVisited = true;
            //Call the Process.Start method to open the default browser 
            //with a URL:
            string txid = linkTXID.Text;
            txid = txid.Substring(7, txid.Length-7);
            string url = "https://neoscan-testnet.io/transaction/" + txid;
            System.Diagnostics.Process.Start(url);
        }

        private void comAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currWallet = plugin_nns.api.CurrentWallet;
            labBalance.Text = currWallet.GetBalance(UInt256.Parse(dAsset[comAsset.Text])).ToString();
        }


        public static bool IsDomain(string str)
        {
            string pattern = @"^[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";
            return IsMatch(pattern, str);
        }
        public static bool IsMatch(string expression, string str)
        {
            Regex reg = new Regex(expression);
            if (string.IsNullOrEmpty(str))
                return false;
            return reg.IsMatch(str);
        }

        private static string[] splitNNS(string nns)
        {
            string[] nnsS = nns.Split('.');
            string domain = nnsS[nnsS.Length - 1];
            string name = nnsS[nnsS.Length - 2];
            string subname = string.Join(".", nnsS);
            if (subname.Length <= (domain.Length + name.Length + 1))
            {
                subname = "";
            }
            else
            {
                subname = subname.Substring(0, subname.Length - domain.Length - name.Length - 2);
            }

            return new string[] { domain, name, subname };
        }
        private static byte[] NameHash(string nns)
        {
            Neo.Cryptography.Crypto c = new Neo.Cryptography.Crypto();

            byte[] namehash = c.Hash256(Encoding.UTF8.GetBytes(string.Join("", splitNNS(nns))));

            return namehash;
        }

        private void txtNNSin_TextChanged(object sender, EventArgs e)
        {
            string nns = txtNNSin.Text;
            if (IsDomain(nns))
            {
                StorageKey sk = new StorageKey
                {
                    ScriptHash = UInt160.Parse(NnsResolverAddrScripthash),
                    Key = NameHash(nns)
                };
                var storageItem = Blockchain.Default.GetStorageItem(sk);
                string value = "null";
                if (storageItem != null)
                { value = Encoding.UTF8.GetString(storageItem.Value); }

                labAddrIn.Text = value;
            }
        }
        //private static readonly HttpClient client = new HttpClient();
        //private async Task<string> GetTransactionAsync()
        //{
        //    //post
        //    var values = new Dictionary<string, string>
        //    {
        //        { "source","AHZDq78w1ERcDYVBWjU5owWcbFZKLvhg7X" },
        //        { "dests","AJnNUn6HynVcco1p8LER72s4zXtNFYDnys,AXdwhdmRK1YPKvGpYKAd1ySHAvkcfJEgyp" },
        //        { "amounts","1,5" },
        //        { "assetId","c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"}
        //    };

        //    var content = new FormUrlEncodedContent(values);

        //    var response = await client.PostAsync("https://api.otcgo.cn/testnet/transfer", content);

        //    var responseString = await response.Content.ReadAsStringAsync();

        //    return responseString;
        //    //get
        //    //var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx");
        //}

        /// <summary>  
        /// 指定Post地址使用Get 方式获取全部字符串  
        /// </summary>  
        /// <param name="url">请求后台地址</param>  
        /// <returns></returns>  
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数  
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>  
        /// 指定Post地址使用Get 方式获取全部字符串  
        /// </summary>  
        /// <param name="url">请求后台地址</param>  
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>  
        /// <returns></returns>  
        public static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数  
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>  
        /// 发送Get请求  
        /// </summary>  
        /// <param name="url">地址</param>  
        /// <param name="dic">请求参数定义</param>  
        /// <returns></returns>  
        public static string Get(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数  
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容  
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }
        public static byte[] HexString2Bytes(string str)
        {
            byte[] outd = new byte[str.Length / 2];
            for (var i = 0; i < str.Length / 2; i++)
            {
                outd[i] = byte.Parse(str.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return outd;
        }

        private byte[] Sign(byte[] message, byte[] prikey)
        {
            var Secp256r1_G = HexString2Bytes("04" + "6B17D1F2E12C4247F8BCE6E563A440F277037D812DEB33A0F4A13945D898C296" + "4FE342E2FE1A7F9B8EE7EB4A7C0F9E162BCE33576B315ECECBB6406837BF51F5");

            var PublicKey = Neo.Cryptography.ECC.ECCurve.Secp256r1.G * prikey;
            var pubkey = PublicKey.EncodePoint(false).Skip(1).ToArray();
            //#if NET461
            const int ECDSA_PRIVATE_P256_MAGIC = 0x32534345;
            prikey = BitConverter.GetBytes(ECDSA_PRIVATE_P256_MAGIC).Concat(BitConverter.GetBytes(32)).Concat(pubkey).Concat(prikey).ToArray();
            using (System.Security.Cryptography.CngKey key = System.Security.Cryptography.CngKey.Import(prikey, System.Security.Cryptography.CngKeyBlobFormat.EccPrivateBlob))
            using (System.Security.Cryptography.ECDsaCng ecdsa = new System.Security.Cryptography.ECDsaCng(key))
            //#else
            //            using (var ecdsa = System.Security.Cryptography.ECDsa.Create(new System.Security.Cryptography.ECParameters
            //            {
            //                Curve = System.Security.Cryptography.ECCurve.NamedCurves.nistP256,
            //                D = prikey,
            //                Q = new System.Security.Cryptography.ECPoint
            //                {
            //                    X = pubkey.Take(32).ToArray(),
            //                    Y = pubkey.Skip(32).ToArray()
            //                }
            //            }))
            //#endif
            {
                return ecdsa.SignData(message, System.Security.Cryptography.HashAlgorithmName.SHA256);
            }
        }

        private void butTransfer_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> data = new Dictionary<string, string>() {
                { "source",comAddrOut.Text},
                { "dests",labAddrIn.Text },
                { "amounts",txtAmount.Text },
                { "assetId",dAsset[comAsset.Text]}
            };
            string resp = Post("https://api.otcgo.cn/testnet/transfer", data);
            JObject j = JObject.Parse(resp);
            string transactionScript = (string)j["transaction"];

            string publickey = plugin_nns.api.CurrentWallet.GetKeys().First().PublicKey.EncodePoint(true).ToHexString();
            //ContractParametersContext context = ContractParametersContext.Parse(transactionScript);
            //string signature = context.ToString();

            var Key = plugin_nns.api.CurrentWallet.GetKeys().First();
            Key.Decrypt();
            var pk = Key.PrivateKey;
            string signature = Sign(transactionScript.HexToBytes(), pk).ToHexString();         


            Dictionary<string, string> data2 = new Dictionary<string, string>() {
                { "publicKey",publickey},
                { "signature",signature },
                { "transaction",transactionScript },
            };
            string resp2 = Post("https://api.otcgo.cn/testnet/broadcast", data2);
            JObject j2 = JObject.Parse(resp2);
            string txid = (string)j2["txid"];

            linkTXID.Text = "TXID:0x" + txid;
            //InvocationTransaction tx = new InvocationTransaction();
            //tx.Version = 1;
            //tx.Script = script.HexToBytes();
            //plugin_nns.api.SignAndShowInformation(tx);
        }

    }
}
