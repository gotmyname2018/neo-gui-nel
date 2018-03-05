using Neo;
using Neo.SmartContract;
using Neo.IO.Json;
using System;
using Neo.Wallets;

namespace plugin_profile
{
    class ProfileContractHelper
    {
        public static byte[] ContractOwnerPublicKey()
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "contractOwner");
            return engine.EvaluationStack.Peek().GetByteArray();
        }

        public static string EmailVerifyUrl()
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "emailVerifyUrl");
            return System.Text.Encoding.UTF8.GetString(engine.EvaluationStack.Peek().GetByteArray());
        }

        private static JObject ParseProfile(string result)
        {
            try
            {
                JObject j = JObject.Parse(result);
                if (j["email"] == null)
                {
                    j["email"] = "";
                }
                return j;
            }
            catch (Exception)
            {
                JObject j = new JObject();
                j["email"] = "";
                return j;
            }
        }

        public static JObject Query(string email)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "query", email);
            string result = System.Text.Encoding.UTF8.GetString(engine.EvaluationStack.Peek().GetByteArray());
            return ParseProfile(result);
        }

        public static JObject QueryByAccount(string owner)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            byte[] ownerScriptHash = Wallet.ToScriptHash(owner).ToArray();
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "queryByAccount", ownerScriptHash);
            string result = System.Text.Encoding.UTF8.GetString(engine.EvaluationStack.Peek().GetByteArray());
            return ParseProfile(result);
        }

        public static string QueryOwner(string email)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "queryOwner", email);
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

        public static bool Register(string profile, string owner)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            UInt160 ownerAddress = Wallet.ToScriptHash(owner);
            byte[] ownerScriptHash = ownerAddress.ToArray();
            return SmartContractHelper.Exec(plugin_profile.api.CurrentWallet, plugin_profile.api.LocalNode, scriptHash, ownerAddress, "register", profile, ownerScriptHash);
        }

        public static bool Grant(string email, string owner)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            byte[] ownerScriptHash = Wallet.ToScriptHash(owner).ToArray();
            return SmartContractHelper.Exec(plugin_profile.api.CurrentWallet, plugin_profile.api.LocalNode, scriptHash, null, "grant", email, ownerScriptHash, new byte[0]);
        }
    }
}
