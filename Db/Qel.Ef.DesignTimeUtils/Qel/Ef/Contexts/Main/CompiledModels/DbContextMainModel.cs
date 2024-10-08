﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Qel.Ef.Contexts.Main;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Qel.Ef.DesignTimeUtils.Qel.Ef.Contexts.Main.CompiledModels
{
    [DbContext(typeof(DbContextMain))]
    public partial class DbContextMainModel : RuntimeModel
    {
        private static readonly bool _useOldBehavior31751 =
            System.AppContext.TryGetSwitch("Microsoft.EntityFrameworkCore.Issue31751", out var enabled31751) && enabled31751;

        static DbContextMainModel()
        {
            var model = new DbContextMainModel();

            if (_useOldBehavior31751)
            {
                model.Initialize();
            }
            else
            {
                var thread = new System.Threading.Thread(RunInitialization, 10 * 1024 * 1024);
                thread.Start();
                thread.Join();

                void RunInitialization()
                {
                    model.Initialize();
                }
            }

            model.Customize();
            _instance = model;
        }

        private static DbContextMainModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
