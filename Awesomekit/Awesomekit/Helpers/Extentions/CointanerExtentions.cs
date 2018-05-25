using System;
using System.Linq;
using System.Reflection;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;

namespace Awesomekit.Helpers.Extentions
{
    public static class CointanerExtentions
    {
        public static IContainerRegistry AutoRegisterMvvmComponents(this IContainerRegistry container, Assembly assembly)
        {
            var pageBaseTypeInfo = typeof(Page).GetTypeInfo();
            // get all pages
            var pageTypesInfos = assembly.DefinedTypes.Where(x => x.IsClass && pageBaseTypeInfo.IsAssignableFrom(x));

            foreach (var page in pageTypesInfos)
            {
                var pageName = GetPageName(page.AsType());
                // the next two lines do what  RegisterTypeForNavigation
                container.RegisterForNavigation(page.AsType(), pageName);
                PageNavigationRegistry.Register(pageName, page.AsType());
            }

            return container;
        }

        private static string GetPageName(Type pageType)
        {
            var attrs = pageType.GetTypeInfo().GetCustomAttributes();

            foreach (var attr in attrs)
            {
                var pageAttribute = attr as PageAttribute;
                if (pageAttribute != null)
                    return pageAttribute.Name;
            }

            return pageType.Name;
        }
    }
}
