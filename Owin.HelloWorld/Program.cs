using System;
using Microsoft.Owin.Hosting;

namespace Owin.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new StartOptions
            {
                ServerFactory = "Nowin",
                Port = 1337
            };

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine("Running on http://localhost:1337");
                Console.ReadLine();
            }
        }
    }
}
