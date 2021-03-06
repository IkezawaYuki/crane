using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;

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

public class SimpleHttp
{
    public static readonly HttpClient _http_client;

    static SimpleHttp()
    {
        _http_client = new HttpClient();
    }

    public async Task<string> GetAsync(string uri)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri)
        };
        var response = await _http_client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}
