using System;

namespace MyApp.Api
{
    class Program
    {
        private const string serverUrl = "http://localhost:8081/";

        static void Main(string[] args)
        {
            Startup.StartServer(serverUrl);
            Console.WriteLine("Web server started on '{0}'", serverUrl);
            Console.ReadKey();
        }
    }
}
