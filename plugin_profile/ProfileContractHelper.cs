using Neo;
using Neo.SmartContract;
using Neo.IO.Json;
using System;

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

        public static JObject QueryByKey(byte[] owner)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            ApplicationEngine engine = SmartContractHelper.LocalExec(scriptHash, "queryByKey", owner);
            string result = System.Text.Encoding.UTF8.GetString(engine.EvaluationStack.Peek().GetByteArray());
            return ParseProfile(result);
        }

        public static bool Register(string profile, byte[] owner)
        {
            UInt160 scriptHash = UInt160.Parse(plugin_profile.ContractScriptHash);
            return SmartContractHelper.Exec(plugin_profile.api.CurrentWallet, plugin_profile.api.LocalNode, scriptHash, "register", profile, owner);
        }
    }
}
