using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nethereum.Web3;

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
        }
    }
}
