using Microsoft.AspNetCore.Hosting;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:8888/", "http://localhost:9999/")
                .Build()
                .Run();
        }
    }

}
