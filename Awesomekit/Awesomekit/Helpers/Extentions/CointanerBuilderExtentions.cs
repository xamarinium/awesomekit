using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace Awesomekit.Helpers.Extentions
{
    public static class CointanerBuilderExtentions
    {
        public static ContainerBuilder AutoRegisterMvvmComponents(this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            // Register all classes for view models
            builder.RegisterAssemblyTypes(assemblies).Where(
                x => x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("ViewModel"));

            // Register all pages
            builder.RegisterAssemblyTypes(assemblies).Where(
                x => x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("Page"));

            return builder;
        }
    }
}
