using Neo;
using Neo.Core;
using Neo.SmartContract;
using Neo.VM;
using Neo.Wallets;
using Neo.Network;
using System;
using System.Windows.Forms;

namespace plugin_profile
{
    class SmartContractHelper
    {
        private static byte[] MakeExecScript(UInt160 scriptHash, string operation, params object[] args)
        {
            byte[] script;
            using (ScriptBuilder sb = new ScriptBuilder())
            {
                script = sb.EmitAppCall(scriptHash, operation, args).ToArray();
            }
            return script;
        }

        private static bool SignAndShowInformation(Wallet wallet, LocalNode node, Transaction tx)
        {
            if (tx == null)
            {
                MessageBox.Show("Insufficient funds", "Error!");
                return false;
            }
            ContractParametersContext context;
            try
            {
                context = new ContractParametersContext(tx);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Unsynchronized block", "Error!");
                return false;
            }
            wallet.Sign(context);
            if (!context.Completed)
            {
                MessageBox.Show("Incompleted signature", "Error!");
                return false;
            }
            context.Verifiable.Scripts = context.GetScripts();
            wallet.ApplyTransaction(tx);
            node.Relay(tx);
            MessageBox.Show("Transaction send succeed with id: " + tx.Hash.ToString() + ", wait a few seconds for confirmation");
            return true;
        }

        public static ApplicationEngine LocalExec(UInt160 scriptHash, string operation, params object[] args)
        {
            byte[] script = MakeExecScript(scriptHash, operation, args);
            return ApplicationEngine.Run(script);
        }

        public static bool Exec(Wallet wallet, LocalNode node, UInt160 scriptHash, UInt160 changeAddress, string operation, params object[] args)
        {
            byte[] script = MakeExecScript(scriptHash, operation, args);
            ApplicationEngine engine = ApplicationEngine.Run(script);
            Fixed8 gas = engine.GasConsumed - Fixed8.FromDecimal(10);
            if (gas < Fixed8.Zero) gas = Fixed8.Zero;
            gas = gas.Ceiling();
            Fixed8 fee = gas.Equals(Fixed8.Zero) ? Fixed8.FromDecimal(0.001m) : Fixed8.Zero;
            InvocationTransaction it = wallet.MakeTransaction(new InvocationTransaction
            {
                Version = 1,
                Script = script,
                Gas = gas,
                Attributes = new TransactionAttribute[0],
                Inputs = new CoinReference[0],
                Outputs = new TransactionOutput[0]
            }, change_address: changeAddress, fee: fee);
            return SignAndShowInformation(wallet, node, it);
        }
    }
}
