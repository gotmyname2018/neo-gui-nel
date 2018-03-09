using Neo.Core;
using Neo.Cryptography;
using Neo.Implementations.Wallets.NEP6;
using Neo.IO;
using Neo.IO.Json;
using Neo.SmartContract;
using Neo.Wallets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Neo.Network.RPC
{
    internal class RpcServerWithWallet : RpcServer
    {
        public RpcServerWithWallet(LocalNode localNode)
            : base(localNode)
        {
        }

        protected override JObject Process(string method, JArray _params)
        {
            switch (method)
            {
                case "getapplicationlog":
                    {
                        UInt256 hash = UInt256.Parse(_params[0].AsString());
                        string path = Path.Combine(Settings.Default.Paths.ApplicationLogs, $"{hash}.json");
                        return File.Exists(path)
                            ? JObject.Parse(File.ReadAllText(path))
                            : throw new RpcException(-100, "Unknown transaction");
                    }
                case "getbalance":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied.");
                    else
                    {
                        UInt256 assetId = UInt256.Parse(_params[0].AsString());
                        IEnumerable<Coin> coins = Program.Wallet.GetCoins().Where(p => !p.State.HasFlag(CoinState.Spent) && p.Output.AssetId.Equals(assetId));
                        JObject json = new JObject();
                        json["balance"] = coins.Sum(p => p.Output.Value).ToString();
                        json["confirmed"] = coins.Where(p => p.State.HasFlag(CoinState.Confirmed)).Sum(p => p.Output.Value).ToString();
                        return json;
                    }
                case "listaddress":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied.");
                    else
                        return Program.Wallet.GetAccounts().Select(p =>
                        {
                            JObject account = new JObject();
                            account["address"] = p.Address;
                            account["haskey"] = p.HasKey;
                            account["label"] = p.Label;
                            account["watchonly"] = p.WatchOnly;
                            return account;
                        }).ToArray();
                case "sendfrom":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        UIntBase assetId = UIntBase.Parse(_params[0].AsString());
                        AssetDescriptor descriptor = new AssetDescriptor(assetId);
                        UInt160 from = Wallet.ToScriptHash(_params[1].AsString());
                        UInt160 to = Wallet.ToScriptHash(_params[2].AsString());
                        BigDecimal value = BigDecimal.Parse(_params[3].AsString(), descriptor.Decimals);
                        if (value.Sign <= 0)
                            throw new RpcException(-32602, "Invalid params");
                        Fixed8 fee = _params.Count >= 5 ? Fixed8.Parse(_params[4].AsString()) : Fixed8.Zero;
                        if (fee < Fixed8.Zero)
                            throw new RpcException(-32602, "Invalid params");
                        UInt160 change_address = _params.Count >= 6 ? Wallet.ToScriptHash(_params[5].AsString()) : null;
                        Transaction tx = Program.Wallet.MakeTransaction(null, new[]
                        {
                            new TransferOutput
                            {
                                AssetId = assetId,
                                Value = value,
                                ScriptHash = to
                            }
                        }, from: from, change_address: change_address, fee: fee);
                        if (tx == null)
                            throw new RpcException(-300, "Insufficient funds");
                        ContractParametersContext context = new ContractParametersContext(tx);
                        Program.Wallet.Sign(context);
                        if (context.Completed)
                        {
                            tx.Scripts = context.GetScripts();
                            Program.Wallet.ApplyTransaction(tx);
                            LocalNode.Relay(tx);
                            return tx.ToJson();
                        }
                        else
                        {
                            return context.ToJson();
                        }
                    }
                case "sendtoaddress":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        UIntBase assetId = UIntBase.Parse(_params[0].AsString());
                        AssetDescriptor descriptor = new AssetDescriptor(assetId);
                        UInt160 scriptHash = Wallet.ToScriptHash(_params[1].AsString());
                        BigDecimal value = BigDecimal.Parse(_params[2].AsString(), descriptor.Decimals);
                        if (value.Sign <= 0)
                            throw new RpcException(-32602, "Invalid params");
                        Fixed8 fee = _params.Count >= 4 ? Fixed8.Parse(_params[3].AsString()) : Fixed8.Zero;
                        if (fee < Fixed8.Zero)
                            throw new RpcException(-32602, "Invalid params");
                        UInt160 change_address = _params.Count >= 5 ? Wallet.ToScriptHash(_params[4].AsString()) : null;
                        Transaction tx = Program.Wallet.MakeTransaction(null, new[]
                        {
                            new TransferOutput
                            {
                                AssetId = assetId,
                                Value = value,
                                ScriptHash = scriptHash
                            }
                        }, change_address: change_address, fee: fee);
                        if (tx == null)
                            throw new RpcException(-300, "Insufficient funds");
                        ContractParametersContext context = new ContractParametersContext(tx);
                        Program.Wallet.Sign(context);
                        if (context.Completed)
                        {
                            tx.Scripts = context.GetScripts();
                            Program.Wallet.ApplyTransaction(tx);
                            LocalNode.Relay(tx);
                            return tx.ToJson();
                        }
                        else
                        {
                            return context.ToJson();
                        }
                    }
                case "sendmany":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        JArray to = (JArray)_params[0];
                        if (to.Count == 0)
                            throw new RpcException(-32602, "Invalid params");
                        TransferOutput[] outputs = new TransferOutput[to.Count];
                        for (int i = 0; i < to.Count; i++)
                        {
                            UIntBase asset_id = UIntBase.Parse(to[i]["asset"].AsString());
                            AssetDescriptor descriptor = new AssetDescriptor(asset_id);
                            outputs[i] = new TransferOutput
                            {
                                AssetId = asset_id,
                                Value = BigDecimal.Parse(to[i]["value"].AsString(), descriptor.Decimals),
                                ScriptHash = Wallet.ToScriptHash(to[i]["address"].AsString())
                            };
                            if (outputs[i].Value.Sign <= 0)
                                throw new RpcException(-32602, "Invalid params");
                        }
                        Fixed8 fee = _params.Count >= 2 ? Fixed8.Parse(_params[1].AsString()) : Fixed8.Zero;
                        if (fee < Fixed8.Zero)
                            throw new RpcException(-32602, "Invalid params");
                        UInt160 change_address = _params.Count >= 3 ? Wallet.ToScriptHash(_params[2].AsString()) : null;
                        Transaction tx = Program.Wallet.MakeTransaction(null, outputs, change_address: change_address, fee: fee);
                        if (tx == null)
                            throw new RpcException(-300, "Insufficient funds");
                        ContractParametersContext context = new ContractParametersContext(tx);
                        Program.Wallet.Sign(context);
                        if (context.Completed)
                        {
                            tx.Scripts = context.GetScripts();
                            Program.Wallet.ApplyTransaction(tx);
                            LocalNode.Relay(tx);
                            return tx.ToJson();
                        }
                        else
                        {
                            return context.ToJson();
                        }
                    }
                case "getnewaddress":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        WalletAccount account = Program.Wallet.CreateAccount();
                        if (Program.Wallet is NEP6Wallet wallet)
                            wallet.Save();
                        return account.Address;
                    }
                case "dumpprivkey":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        UInt160 scriptHash = Wallet.ToScriptHash(_params[0].AsString());
                        WalletAccount account = Program.Wallet.GetAccount(scriptHash);
                        return account.GetKey().Export();
                    }
                case "signdata":
                    if (Program.Wallet == null)
                        throw new RpcException(-400, "Access denied");
                    else
                    {
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(_params[0].AsString());
                        KeyPair keys = Program.Wallet.GetAccounts().First().GetKey();
                        using (keys.Decrypt())
                        {
                            byte[] pubkey = keys.PublicKey.EncodePoint(false).Skip(1).ToArray();
                            return Convert.ToBase64String(Crypto.Default.Sign(data, keys.PrivateKey, pubkey));
                        }
                    }
                case "invoke":
                case "invokefunction":
                case "invokescript":
                    JObject result = base.Process(method, _params);
                    if (Program.Wallet != null)
                    {
                        InvocationTransaction tx = new InvocationTransaction
                        {
                            Version = 1,
                            Script = result["script"].AsString().HexToBytes(),
                            Gas = Fixed8.Parse(result["gas_consumed"].AsString())
                        };
                        tx.Gas -= Fixed8.FromDecimal(10);
                        if (tx.Gas < Fixed8.Zero) tx.Gas = Fixed8.Zero;
                        tx.Gas = tx.Gas.Ceiling();
                        tx = Program.Wallet.MakeTransaction(tx);
                        if (tx != null)
                        {
                            ContractParametersContext context = new ContractParametersContext(tx);
                            Program.Wallet.Sign(context);
                            if (context.Completed)
                                tx.Scripts = context.GetScripts();
                            else
                                tx = null;
                        }
                        result["tx"] = tx?.ToArray().ToHexString();
                    }
                    return result;
                case "executescript":
                    {
                        if (Program.Wallet == null)
                        {
                            return false;
                        }
                        byte[] script = _params[0].AsString().HexToBytes();
                        ApplicationEngine engine = ApplicationEngine.Run(script);
                        Fixed8 gas = engine.GasConsumed - Fixed8.FromDecimal(10);
                        if (gas < Fixed8.Zero) gas = Fixed8.Zero;
                        gas = gas.Ceiling();
                        Fixed8 fee = gas.Equals(Fixed8.Zero) ? Fixed8.FromDecimal(0.001m) : Fixed8.Zero;
                        InvocationTransaction tx = Program.Wallet.MakeTransaction(new InvocationTransaction
                        {
                            Version = 1,
                            Script = script,
                            Gas = gas,
                            Attributes = new TransactionAttribute[0],
                            Inputs = new CoinReference[0],
                            Outputs = new TransactionOutput[0]
                        }, fee: fee);
                        if (tx == null)
                        {
                            return false;
                        }
                        ContractParametersContext context;
                        try
                        {
                            context = new ContractParametersContext(tx);
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                        Program.Wallet.Sign(context);
                        if (!context.Completed)
                        {
                            return false;
                        }
                        context.Verifiable.Scripts = context.GetScripts();
                        Program.Wallet.ApplyTransaction(tx);
                        return LocalNode.Relay(tx);
                    }
                default:
                    return base.Process(method, _params);
            }
        }
    }
}
