using System;
using System.Collections.Generic;
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
            GetAccountBalance().Wait();
            Console.ReadLine();

        }

        static async Task GetAccountBalance()
        {
            var web3 = new Web3();
            var balance = await web3.Eth.GetBalance.SendRequestAsync("000");
            Console.WriteLine($"Balance in Wei: {balance.Value}");

            var etherAmount = Web3.Convert.FromWei(balance.Value);
            Console.WriteLine($"Balance in Ether: {etherAmount}");

            string toAddress = "";
            var transaction = web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, 1.11m, 2);

            var managedAccount = new ManagedAccount("", "");
            var web3ManagedAccount = new Web3(managedAccount);

            
        }
    }
}
