using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Qel.Ef.Providers.Common;

public class ProviderSelector(IEnumerable<IProviderConfigurator> configurators)
{
    public DbContextOptionsBuilder SelectProvider(string contextName, DbContextOptionsBuilder builder, IConfiguration config)
    {
        var providerName = config.GetRequiredSection("ContextProviders").GetRequiredSection(contextName).Value;

        foreach (var configurator in configurators)
        {
            if (configurator.Tag == providerName)
            {
                return configurator.ConfigureOptionsBuilder(builder, config);
            }
        }
        return builder;
    }
}
