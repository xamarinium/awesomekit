
using System.Linq;
using System.Reflection;
using Autofac;
using Awesomekit.Helpers.Extentions;
using Awesomekit.ViewModels;
using Awesomekit.Views;
using Prism.Autofac;
using Prism.Autofac.Forms;
using Prism.Navigation;
using Xamarin.Forms;

namespace Awesomekit
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("navigation/main");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>("navigation");
            Container.RegisterAllPages(typeof(App).GetTypeInfo().Assembly);
        }
    }
}
