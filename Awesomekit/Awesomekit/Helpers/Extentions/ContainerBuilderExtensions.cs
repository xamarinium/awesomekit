using Autofac;
using System.Linq;
using System.Reflection;

namespace Awesomekit.Helpers.Extentions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AutoRegisterMvvmComponents(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
               .RegisterAssemblyTypes(assemblies)
               .Where(x => x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("ViewModel"));

            builder
               .RegisterAssemblyTypes(assemblies)
               .Where(x => x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("Page"));

            return builder;
        }

        public static ContainerBuilder AutoRegisterServices(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
              .RegisterAssemblyTypes(assemblies)
              .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces();

            return builder;
        }

        public static ContainerBuilder AutoRegisterMvvmAndServices(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.AutoRegisterMvvmComponents(assemblies)
                .AutoRegisterServices(assemblies);
        }
    }
}
