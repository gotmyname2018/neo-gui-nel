﻿using Neo.Core;
using Neo.Properties;
using Neo.SmartContract;
using Neo.VM;
using Neo.Wallets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neo.UI
{
    internal static class Helper
    {
        private static Dictionary<Type, Form> tool_forms = new Dictionary<Type, Form>();

        private static void Helper_FormClosing(object sender, FormClosingEventArgs e)
        {
            tool_forms.Remove(sender.GetType());
        }

        public static void Show<T>() where T : Form, new()
        {
            Type t = typeof(T);
            if (!tool_forms.ContainsKey(t))
            {
                tool_forms.Add(t, new T());
                tool_forms[t].FormClosing += Helper_FormClosing;
            }
            tool_forms[t].Show();
            tool_forms[t].Activate();
        }
        public static void SendRaw(Transaction tx)
        {
            if (tx == null)
            {
                MessageBox.Show(Strings.InsufficientFunds);
                return;
            }
            bool b=Program.LocalNode.Relay(tx);

            if (b)
            {
                Program.CurrentWallet.ApplyTransaction(tx);
                InformationBox.Show(tx.Hash.ToString(), Strings.SendTxSucceedMessage, Strings.SendTxSucceedTitle);
                return;
            }
            InformationBox.Show("sendRawError");
        }
        public static void SignAndShowInformation(Transaction tx)
        {
            if (tx == null)
            {
                MessageBox.Show(Strings.InsufficientFunds);
                return;
            }
            ContractParametersContext context;
            try
            {
                context = new ContractParametersContext(tx);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(Strings.UnsynchronizedBlock);
                return;
            }
            Program.CurrentWallet.Sign(context);
            if (context.Completed)
            {
                context.Verifiable.Scripts = context.GetScripts();
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var br = new System.IO.BinaryWriter(ms))
                    {
                        //tx.SerializeUnsigned(br);
                        IO.ISerializable s = tx;
                        s.Serialize(br);
                    }
                    var hex = ms.ToArray().ToHexString();
                    System.IO.File.WriteAllText("d:\\0x00.transhex.txt", hex);

                }

                Program.CurrentWallet.ApplyTransaction(tx);

                Program.LocalNode.Relay(tx);
                InformationBox.Show(tx.Hash.ToString(), Strings.SendTxSucceedMessage, Strings.SendTxSucceedTitle);
            }
            else
            {
                InformationBox.Show(context.ToString(), Strings.IncompletedSignatureMessage, Strings.IncompletedSignatureTitle);
            }
        }

        public static string QueryEmailAddressOwner(string email)
        {
            UInt160 scriptHash = UInt160.Parse("0xff9e21bf9d3bf84bb96be6d42ad0102af24e9289");
            byte[] script;
            using (ScriptBuilder sb = new ScriptBuilder())
            {
                script = sb.EmitAppCall(scriptHash, "queryOwner", email).ToArray();
            }
            ApplicationEngine engine = ApplicationEngine.Run(script);
            byte[] owner = engine.EvaluationStack.Peek().GetByteArray();
            try
            {
                UInt160 ownerScriptHash = new UInt160(owner);
                return Wallet.ToAddress(ownerScriptHash);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
