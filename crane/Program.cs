using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;

namespace crane
{
    class Apple
    {
        static string publicKey = "GCPNII6HN3AI7YSRJ2CRSPXJTNGODV5ZQP3AHUDCIOLBS4PSRA5DIAL2";
        string secretKey = "SC3FBQHSSVM7XSEILQIFIT3IA6OMFCASUTW347XNQ3ZP3IQUXDIBSMBX";

        public static void Main(string[] arg)
        {
            // GenerateAccountKeypair();
            execute();
        }

        public static async void execute()
        {
            var apple = new Apple();
            await apple.GetAccountBalance();
        }

        public async Task SendNativeAssets()
        {
            Network network = new Network("");
            Server server = new Server("");

            KeyPair keyPair = KeyPair.FromSecretSeed("");
            KeyPair destinationPair = KeyPair.FromAccountId("");

            AccountResponse accountResponse = await server.Accounts.Account(keyPair.AccountId);

            Account sourceAccount = new Account(keyPair.AccountId, accountResponse.SequenceNumber);

            Asset asset = new AssetTypeNative();

            string amount = "1";

            PaymentOperation paymentOperation = new PaymentOperation.Builder(destinationPair, asset, amount).SetSourceAccount(sourceAccount.KeyPair).Build();

            Transaction transaction = new TransactionBuilder(sourceAccount).AddOperation(paymentOperation).Build();

            transaction.Sign(keyPair);

            try
            {
                Console.WriteLine("sending transaction");
                await server.SubmitTransaction(transaction);
                Console.WriteLine("Seccess");
            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public async Task GetAccountBalance()
        {
            Console.WriteLine("GetAccountBalance is invoked");
            Network network = Network.Test();
            Network.Use(network);
            Server server = new Server("https://horizon-testnet.stellar.org");
            Console.WriteLine(server);

            KeyPair keyPair = KeyPair.FromSecretSeed("SC3FBQHSSVM7XSEILQIFIT3IA6OMFCASUTW347XNQ3ZP3IQUXDIBSMBX");
            Console.WriteLine(keyPair);

            AccountResponse sourceAccountResponse = await server.Accounts.Account(keyPair.AccountId);
            Console.WriteLine(sourceAccountResponse);
            Console.WriteLine("0000");

            //Get the balance
            Balance[] balances = sourceAccountResponse.Balances;

            //Show the balance
            for (int i = 0; i < balances.Length; i++)
            {
                Balance asset = balances[i];
                Console.WriteLine("Asset Code: " + asset.AssetCode);
                Console.WriteLine("Asset Amount: " + asset.BalanceString);
            }
        }

        public static void GenerateAccountKeypair()
        {
            KeyPair keyPair = KeyPair.Random();

            Console.WriteLine("Account ID: " + keyPair.AccountId);
            Console.WriteLine("Secret: " + keyPair.SecretSeed);
            
        }
    }

    public class Kimberly
    {
        public string url { get; set; }
        public HttpClient client { get; set; }
        public Kimberly(string url)
        {
            this.url = url;
            this.client = new HttpClient();
        }

        public void signature()
        {

        }
    }

    public class APIClient
    {
        
    }
    
    public class Slack : APIClient
    {
        public string channel { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public string icon_emoji { get; set; }
        public string icon_url { get; set; }

        Slack(string c, string u, string t, string i_e, string i_u)
        {
            this.channel = c;
            this.username = u;
            this.text = t;
            this.icon_emoji = i_e;
            this.icon_url = i_u;
        }

        public void Send(string uri)
        {
            var json = JsonSerializer.Serialize(this);
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(uri, content).Result;
            Console.WriteLine(response.StatusCode);
        }
    }



    public class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle draw");
            base.Draw();
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle draw");
            base.Draw();
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Triancle draw");
            base.Draw();
        }
    }

    public class WorkItem
    {
        private static int currentID;

        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }

        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description";
            jobLength = new TimeSpan();
        }

        public WorkItem(string title, string description, TimeSpan jobLen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = description;
            this.jobLength = jobLen;
        }

        static WorkItem() => currentID = 0;

        protected int GetNextID() => ++currentID;

        public void Update(string title, TimeSpan jobLen)
        {
            this.Title = title;
            this.jobLength = jobLen;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Title}";
        }
    }

    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }

        public ChangeRequest() { }

        public ChangeRequest(string title, string description, TimeSpan jobLen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = description;
            this.jobLength = jobLen;
            this.originalItemID = originalID;
        }
    }
}
