using System.Reflection;
using Awesomekit.Helpers.Extentions;
using Prism.Autofac;
using Prism.Ioc;

namespace Awesomekit
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AutoRegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly);
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("landing");
        }
    }
}
