public class Content
{
    public string Site { get; set; }
    public int Len { get; set; }
}
internal class Program
{
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Main Thread:" + Thread.CurrentThread.ManagedThreadId);

        List<string> urls = new List<string>()
        {
            "https://www.google.com",
            "https://www.microsoft.com",
            "https://www.amazon.com",
            "https://www.n11.com",
            "https://www.haberturk.com"
        };
        List<Task<Content>> taskList = new List<Task<Content>>();

        urls.ToList().ForEach(x =>
        {
            taskList.Add(GetContentAsync(x));
        });
        #region WhenAny
        var FirstData =await Task.WhenAny(taskList);

        Console.WriteLine($"{FirstData.Result.Site} -  {FirstData.Result.Len}");
        #endregion
        #region WhenAll
        //var contents = Task.WhenAll(taskList.ToArray());

        ////İşlemler olurken arada başka kodlar çalıştırmak istiyorsak bu şekilde de çalışabiliriz.
        //Console.WriteLine("I did other something after WhenAll");

        //var data =await contents;

        //data.ToList().ForEach(x =>
        //{
        //    Console.WriteLine($"{x.Site} boyut: {x.Len}");
        //});
        #endregion
    }

    public static async Task<Content> GetContentAsync(string url)
    {
        Content c = new Content();
        var data = await new HttpClient().GetStringAsync(url);
        c.Site = url;
        c.Len = data.Length;
        Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
        return c;
    }
}
