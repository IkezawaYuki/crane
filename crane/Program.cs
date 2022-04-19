using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using Nethereum.RPC.Eth.DTOs;

namespace crane
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        public static void ShowEachDistinctString(IEnumerable<string> strings)
        {
            var shown = new HashSet<string>();
            foreach(string s in strings)
            {
                if (shown.Add(s))
                {
                    Console.WriteLine(s);
                }
            }
        }

        static async Task Execute()
        {
            //var uri = "http://testchain.nethereum.com:8545";
            //var privatekey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            //var account = new Account(privatekey);
            //var web3 = new Web3(account, uri);

            //var contractByteCode = "0x00099999992394349874538743287432832487";
            //var abi = @"[{ ""constant"":false,""inputs"":[{ ""name"":""_spender"",""type"":""address""},{ ""name"":""_value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{ ""name"":""success"",""type"":""bool""}],""type"":""function""},{ ""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{ ""name"":""supply"",""type"":""uint256""}],""type"":""function""},{ ""constant"":false,""inputs"":[{ ""name"":""_from"",""type"":""address""},{ ""name"":""_to"",""type"":""address""},{ ""name"":""_value"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{ ""name"":""success"",""type"":""bool""}],""type"":""function""},{ ""constant"":true,""inputs"":[{ ""name"":""_owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{ ""name"":""balance"",""type"":""uint256""}],""type"":""function""},{ ""constant"":false,""inputs"":[{ ""name"":""_to"",""type"":""address""},{ ""name"":""_value"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{ ""name"":""success"",""type"":""bool""}],""type"":""function""},{ ""constant"":true,""inputs"":[{ ""name"":""_owner"",""type"":""address""},{ ""name"":""_spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{ ""name"":""remaining"",""type"":""uint256""}],""type"":""function""},{ ""inputs"":[{ ""name"":""_initialAmount"",""type"":""uint256""}],""type"":""constructor""},{ ""anonymous"":false,""inputs"":[{ ""indexed"":true,""name"":""_from"",""type"":""address""},{ ""indexed"":true,""name"":""_to"",""type"":""address""},{ ""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_owner"",""type"":""address""},{""indexed"":true,""name"":""_spender"",""type"":""address""},{ ""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name "":""Approval "",""type "":""event""}]";

            //var totalSupply = BigInteger.Parse("1000000000000000000");
            //var senderAddress = account.Address;

            //var estimateGas = await web3.Eth.DeployContract.EstimateGasAsync(abi, contractByteCode, senderAddress, totalSupply);
            //var receipt = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(abi, contractByteCode, senderAddress, estimateGas, null, totalSupply);

            //Console.WriteLine("Contract deployed at address: ", receipt.ContractAddress);

            //var contract = web3.Eth.GetContract(abi, receipt.ContractAddress);

            //var transferFunction = contract.GetFunction("transfer");
            //var balanceFunction = contract.GetFunction("balanceOf");
            //var newAddress = "0xfewreawrawfwa";

            //var balance = await balanceFunction.CallAsync<int>(newAddress);
            //Console.WriteLine($"Account {newAddress} balance: {balance}");
            //Console.WriteLine("Transfering 1000 tokens");
            //var amountToSend = 1000;

            //var gas = await transferFunction.EstimateGasAsync(senderAddress, null, null, newAddress, amountToSend);
            //var receiptAmountSend = await transferFunction.SendTransactionAndWaitForReceiptAsync(senderAddress, gas, null, null, newAddress, amountToSend);

            //balance = await balanceFunction.CallAsync<int>(newAddress);
            //Console.WriteLine($"Account {newAddress} balance: {balance}");

            //var senderAddress = "0x12890d2cce102216644c59daE5baed380d84830c";
            //var password = "password";
            //var ABI = @"[{""constant"":false,""inputs"":[{""name"":""val"",""type"":""int256""}],""name"":""multiply"",""outputs"":[{""name"":""d"",""type"":""int256""}],""type"":""function""},{""inputs"":[{""name"":""multiplier"",""type"":""int256""}],""type"":""constructor""}]";
            //var byteCode = "0x60606040526040516020806052833950608060405251600081905550602b8060276000396000f3606060405260e060020a60003504631df4f1448114601a575b005b600054600435026060908152602090f3";
            //var multiplier = 7;
            //var web3 = new Web3();
            //var unlockAccountResult = await web3.Personal.UnlockAccount.SendRequestAsync(senderAddress, password, 120);

            //var transactionHash = await web3.Eth.DeployContract.SendRequestAsync(ABI, byteCode, senderAddress);

            //var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            //while (receipt == null)
            //{
            //    Thread.Sleep(5000);
            //    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            //}

            //var contractAddress = receipt.ContractAddress;
            //var contract = web3.Eth.GetContract(ABI, contractAddress);

            //var multiplyFunction = contract.GetFunction("multiply");
            //var result = await multiplyFunction.CallAsync<int>(5);

            var senderAddress = "0x12890d2cce102216644c59daE5baed380d84830c";
            var password = "password";
            var abi = @"[{'constant':false,'inputs':[{'name':'a','type':'int256'}],'name':'multiply','outputs':[{'name':'r','type':'int256'}],'type':'function'},{'inputs':[{'name':'multiplier','type':'int256'}],'type':'constructor'},{'anonymous':false,'inputs':[{'indexed':true,'name':'a','type':'int256'},{'indexed':true,'name':'sender','type':'address'},{'indexed':false,'name':'result','type':'int256'}],'name':'Multiplied','type':'event'}]";
            var byteCode = "0x6060604052604051602080610104833981016040528080519060200190919050505b806000600050819055505b5060ca8061003a6000396000f360606040526000357c0100000000000000000000000000000000000000000000000000000000900480631df4f144146037576035565b005b604b60048080359060200190919050506061565b6040518082815260200191505060405180910390f35b60006000600050548202905080503373ffffffffffffffffffffffffffffffffffffffff16827f841774c8b4d8511a3974d7040b5bc3c603d304c926ad25d168dacd04e25c4bed836040518082815260200191505060405180910390a380905060c5565b91905056";

            var multiplier = 8;
            var web3 = new Web3();
            var unlockResult = await web3.Personal.UnlockAccount.SendRequestAsync(senderAddress, password, new HexBigInteger(120));

            var transactionHash = await web3.Eth.DeployContract.SendRequestAsync(abi, byteCode, senderAddress, new HexBigInteger(9000), multiplier);

            //var receipt = await MineAndGetReceiptAsync(web3, transactionHash);
            TransactionReceipt receipt = null;
            var contractAddress = receipt.ContractAddress;
            var contract = web3.Eth.GetContract(abi, contractAddress);
            var multiplyFunction = contract.GetFunction("multiply");
            var multiplyEvent = contract.GetEvent("Multiplied");

            var filterAll = await multiplyEvent.CreateFilterAsync();
            var filter7 = await multiplyEvent.CreateFilterAsync(7);

            transactionHash = await multiplyFunction.SendTransactionAsync(senderAddress, 7);
            transactionHash = await multiplyFunction.SendTransactionAsync(senderAddress, 8);

            receipt = await MineAndGetReceiptAsync(web3, transactionHash);

            var log = await multiplyEvent.GetFilterChangesAsync<MultipliedEvent>(filterAll);
            var log7 = await multiplyEvent.GetFilterChangesAsync<MultipliedEvent>(filter7);



        }

        public class MultipliedEvent
        {
            [Parameter("int", "a", 1, true)]
            public int MultiplicationInput { get; set; }

            [Parameter("address", "sender", 2, true)]
            public string Sender { get; set; }

            [Parameter("int", "result", 3, false)]
            public int Result { get; set; }

        }

        public async Task<TransactionReceipt> MineAndGetReceiptAsync(Web3 web3, string transactionHash)
        {
            var miningResult = await web3.Miner.Start.SendRequestAsync(6);

            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            while (receipt == null)
            {
                Thread.Sleep(1000);
                receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            }

            miningResult = await web3.Miner.Stop.SendRequestAsync();
            return receipt;
        }
    }
}
