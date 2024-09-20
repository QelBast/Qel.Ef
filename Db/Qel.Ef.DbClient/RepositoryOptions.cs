namespace Qel.Ef.DbClient;

public class RepositoryOptions()
{
    public required string ContextDbProvider { get; set; }

    public bool DetailedErrors { get; set; } = false;
    public bool SensitiveDataLogging { get; set; } = false;
    public bool ServiceProviderCaching { get; set; } = false;
    public bool ThreadSafetyChecks { get; set; } = false;
}