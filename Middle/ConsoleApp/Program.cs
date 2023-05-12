using System;
using System.Threading.Tasks;
using iLib;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hallo DotNetSaturday 2023!");
            Console.WriteLine($"ConsoleApp - {typeof(System.Net.Http.HttpClient).Assembly.Location}");
            
            var loadContext = new IsolatedLoadContext("../pub/lib.dll", new[]{ typeof(IProcessor) });
            var d = loadContext.CreateInstance<IProcessor>();

            var result = await d.ProcessDocumentAsync("Docs/schedule.pdf","Output/schedule2023.pdf");
            //var result = await d.ProcessDocumentAsync("https://dotnedsaturday.nl/","Output/dotnetsaturday.html");
            
            Console.WriteLine("Done...");
        }
    }
}
