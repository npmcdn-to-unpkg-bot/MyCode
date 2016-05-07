using System;
using Microsoft.Owin.Hosting;

namespace TLMService
{
    internal class Program
    {
        private static void Main()
        {
            const string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
