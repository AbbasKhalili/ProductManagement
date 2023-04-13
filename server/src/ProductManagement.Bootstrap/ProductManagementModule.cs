using System.Data;
using Autofac;
using Shared.Core;
using Shared.Domain;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Persistence;
using ProductManagement.Interface.Query;
using ProductManagement.Interface.Write;
using ProductManagement.Logger.NLog;

namespace ProductManagement.Bootstrap
{
    internal class ProductManagementModule : Module
    {
        private readonly string _connectionString;
        private readonly string _nlogConfigFile;

        public ProductManagementModule(string connectionString, string nlogConfigFile = "./nlog.config")
        {
            _connectionString = connectionString;
            _nlogConfigFile = nlogConfigFile;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemClock>().As<ISystemClock>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(a => typeof(IRepository).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProductWriteService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProductQueryService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(ReserveService).Assembly)
            //    .Where(a => typeof(IDomainService).IsAssignableFrom(a))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();


            builder.Register<ProductManagementContext>(s =>
            {
                var options = new DbContextOptionsBuilder<ProductManagementContext>()
                    .UseSqlServer(_connectionString)
                    .EnableSensitiveDataLogging(true);

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "development")
                    options.LogTo(Console.Write, Microsoft.Extensions.Logging.LogLevel.Information);

                var context = new ProductManagementContext(options.Options);
                return context;
            }).InstancePerLifetimeScope().OnRelease(a => a.Dispose());



            builder.RegisterType<NLoggerService>().As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(NLoggerService<>))
                .As(typeof(ILoggerService<>))
                .InstancePerLifetimeScope();

            NLogConfigure.Config(_nlogConfigFile);
        }
    }
}