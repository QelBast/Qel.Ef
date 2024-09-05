using Qel.Common.Console.Hosting;

namespace Qel.Ef.Test.ConsoleApp;
public class Program
{
    public static void Main(string[] args)
    {
        HostUtils.RunQueueConsoleApplicationHost(args).Wait();
    }
}