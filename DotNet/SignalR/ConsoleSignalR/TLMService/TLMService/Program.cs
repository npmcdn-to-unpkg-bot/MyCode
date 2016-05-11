﻿using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace TLMService
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://192.168.15.177:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
