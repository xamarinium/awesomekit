using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Awesomekit.Helpers.Extentions;
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

            NavigationService.NavigateAsync("landing");
        }

        protected override void RegisterTypes()
        {
            Container.AutoRegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly);
        }
    }
}
