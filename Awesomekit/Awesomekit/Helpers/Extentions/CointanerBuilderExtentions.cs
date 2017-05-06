using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using XLabs.Forms.Mvvm;

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

        public static IContainer Finish(this ContainerBuilder builder)
        {
            var container = builder.Build();
            HackViewFactory(container);
            return container;
        }

        private static void HackViewFactory(IContainer container)
        {
            // Get all registered types
            var registeredTypes = container.ComponentRegistry.Registrations.SelectMany(x => x.Services)
                .OfType<IServiceWithType>()
                .Select(x => x.ServiceType).ToList();

            var typeDictionary = new Dictionary<Type, Type>();
            foreach (var viewModelType in registeredTypes.Where(x=>x.Name.EndsWith("ViewModel")))
            {
                // get name without ViewModel
                var viewModelName = viewModelType.Name.Replace("ViewModel", null);
                // get name of page for current view model
                var pageTypeName = $"{viewModelName}Page";
                // get type for current view model
                var pageType = registeredTypes.FirstOrDefault(x => x.Name.Equals(pageTypeName));
                if (pageType != null)
                    typeDictionary[viewModelType] = pageType;
            }

            // now we hack ViewFactory
            // get private field of ViewFactory
            var typeDictionaryField = typeof(ViewFactory).GetTypeInfo().GetDeclaredField("TypeDictionary");
            // Set new value
            typeDictionaryField?.SetValue(null, typeDictionary);
        }
    }
}
