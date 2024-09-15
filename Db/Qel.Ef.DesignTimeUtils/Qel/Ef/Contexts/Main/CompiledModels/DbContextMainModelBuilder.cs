﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Qel.Ef.DesignTimeUtils.Qel.Ef.Contexts.Main.CompiledModels
{
    public partial class DbContextMainModel
    {
        partial void Initialize()
        {
            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "8.0.8");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
            AddRuntimeAnnotation("Relational:RelationalModel", CreateRelationalModel());
        }

        private IRelationalModel CreateRelationalModel()
        {
            var relationalModel = new RelationalModel(this);
            return relationalModel.MakeReadOnly();
        }
    }
}
