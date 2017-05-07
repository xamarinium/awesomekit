using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Prism.Autofac.Forms;
using Prism.Navigation;
using Xamarin.Forms;

namespace Awesomekit.Helpers.Extentions
{
    public static class CointanerExtentions
    {
        public static IContainer AutoRegisterMvvmComponents(this IContainer container, Assembly assembly)
        {
            var pageBaseTypeInfo = typeof(Page).GetTypeInfo();
            // get all pages
            var pageTypesInfos = assembly.DefinedTypes.Where(x => x.IsClass && pageBaseTypeInfo.IsAssignableFrom(x));

            foreach (var page in pageTypesInfos)
            {
                var pageName = page.Name;
                // the next two lines do what  RegisterTypeForNavigation
                container.RegisterTypeForNavigation(page.AsType(), pageName);
                PageNavigationRegistry.Register(pageName, page.AsType());
            }

            return container;
        }

        private static string GetPageName(Type pageType)
        {
            var attrs = pageType.
        }
    }
}
