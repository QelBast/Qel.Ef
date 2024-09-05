using Microsoft.Extensions.Configuration;

namespace Qel.Common.Console.Hosting;

using Path = System.IO.Path;

public static class ConfigurationManagerExtensions
{
    const string confsPath = @"..\..\..\..\Confs\"; 
    public static ConfigurationManager AddMyStandartConfigureProviders(this ConfigurationManager manager, string? env = "Development", string[]? args = null)
    {
        var dir = Path.Join(
            Common.Path.PathUtils.GetExecutingAssemblyPath(), 
            confsPath);

        manager
            .AddJsonFile(
                path: Path.Combine(dir, $"commonsettings.json"), 
                optional: false, 
                reloadOnChange: false)
            .AddJsonFile(
                path: Path.Combine(dir, $"commonsettings.{env}.json"), 
                optional: true, 
                reloadOnChange: true)
            .AddEnvironmentVariables(o =>
            {
                o.Prefix = "DOTNET";
                o.Prefix = "ASPDOTNET";
            });

        if (args?.Length > 0)
        {
            manager.AddCommandLine(args);
        }

        return manager;
    }

    private static (Stream, Stream) OpenConfigStreams(string path, string? env) //TODO: Know about AddJsonStream()
    {
        try
        {
            Stream fsSettings = File.Open("commonsettings.json", FileMode.Open, FileAccess.Read);
            Stream fsEnvSettings = File.Open($"commonsettings.{env}.json", FileMode.Open, FileAccess.Read);
        }
        catch (Exception)
        {

            throw;
        }
        throw new NotImplementedException();
    }



    
}
