using System;
using System.Linq;
using System.Reflection;
using DryIoc;
using Prism.Autofac.Forms;
using Prism.Navigation;
using Xamarin.Forms;
using IContainer = Autofac.IContainer;

namespace Awesomekit.Helpers.Extentions
{
    public static class ContainerExtentions
    {
        public static IContainer RegisterAllPages(this IContainer container, Assembly assembly)
        {
            var pageBaseTypeInfo = typeof(Page).GetTypeInfo();
            var pageTypeInfos = assembly.DefinedTypes
                .Where(x => x.IsClass && pageBaseTypeInfo.IsAssignableFrom(x));

            foreach (var page in pageTypeInfos)
            {
                var pageName = GetPageName(page.AsType());
                // the next two lines do what RegisterTypeForNavigation does
                container.RegisterTypeForNavigation(page.AsType(), pageName);
                PageNavigationRegistry.Register(pageName, page.AsType());
            }

            return container;
        }

        private static string GetPageName(Type pageType)
        {
            // Using reflection.
            var attrs = pageType.GetAttributes();

            // Displaying output.
            foreach (Attribute attr in attrs)
            {
                var pageAttribute = attr as PageAttribute;
                if (pageAttribute != null)
                {
                    return pageAttribute.Name;
                }
            }

            return pageType.Name;
        }
    }
}
