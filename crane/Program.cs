using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;

namespace crane
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
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

            var senderAddress = "0x12890d2cce102216644c59daE5baed380d84830c";
            var password = "password";
            var ABI = @"[{""constant"":false,""inputs"":[{""name"":""val"",""type"":""int256""}],""name"":""multiply"",""outputs"":[{""name"":""d"",""type"":""int256""}],""type"":""function""},{""inputs"":[{""name"":""multiplier"",""type"":""int256""}],""type"":""constructor""}]";
            var byteCode = "0x60606040526040516020806052833950608060405251600081905550602b8060276000396000f3606060405260e060020a60003504631df4f1448114601a575b005b600054600435026060908152602090f3";
            var multiplier = 7;
            var web3 = new Web3();
            var unlockAccountResult = await web3.Personal.UnlockAccount.SendRequestAsync(senderAddress, password, 120);

            var transactionHash = await web3.Eth.DeployContract.SendRequestAsync(ABI, byteCode, senderAddress);

            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            while (receipt == null)
            {
                Thread.Sleep(5000);
                receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            }

            var contractAddress = receipt.ContractAddress;
            var contract = web3.Eth.GetContract(ABI, contractAddress);

            var multiplyFunction = contract.GetFunction("multiply");
            var result = await multiplyFunction.CallAsync<int>(5);
        }
    }
}
