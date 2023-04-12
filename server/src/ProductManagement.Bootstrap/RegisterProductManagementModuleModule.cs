using Autofac;

namespace ProductManagement.Bootstrap
{
    public static class RegisterProductManagementModuleModule
    {
        public static void AddModule(this ContainerBuilder builder, string connectionString, string nlogConfigFile = "./nlog.config")
        {
            builder.RegisterModule(new ProductManagementModule(connectionString, nlogConfigFile));
        }
    }
}