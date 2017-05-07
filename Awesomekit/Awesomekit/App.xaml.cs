
using Awesomekit.ViewModels;
using Prism.Autofac;
using Prism.Autofac.Forms;
using Xamarin.Forms;

namespace Awesomekit
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("Main");
        }

        protected override void RegisterTypes()
        {

            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<Views.MainPage>("Main");

            //var builder = new ContainerBuilder();
            //builder.Build().register.RegisterTypeForNavigation<MainPage>();
            //builder.RegisterType<MyService>().As<IMyService>();
            //builder.Update(Container);
        }
    }
}
