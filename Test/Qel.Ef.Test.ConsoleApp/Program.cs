using Microsoft.Extensions.Hosting;

namespace Qel.Ef.Test.Console;
public class Program
{
    private static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
                         .ConfigureServices((hostingContext, services) =>
                         {
                             //services.Add
                         })
                         .Build();
    }
}