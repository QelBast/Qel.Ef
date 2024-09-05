﻿using Microsoft.EntityFrameworkCore;

namespace Qel.Ef.Providers.Postgres;

using Qel.Ef.Providers.Common;

public class Configurator : IProviderConfigurator
{
    public DbContextOptionsBuilder GetOptionsBuilder(DbContextOptionsBuilder options)
    {
        return options.UseNpgsql();
    }
}