using System;

namespace MyApp.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.StartServer("http://localhost:8081/");
            Console.ReadKey();
        }
    }
}
