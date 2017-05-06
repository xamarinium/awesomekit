using Autofac;
using Autofac.Core;
using Awesomekit.Helpers.Extentions;
using Awesomekit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;

namespace Awesomekit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeServices();
            InitializeMvvm();

            MainPage = (Page)ViewFactory.CreatePage<MainViewModel, MainPage>();
        }

        private void InitializeMvvm()
        {
            ViewFactory.Register<MainPage, MainViewModel>();
        }

        public static event Action<IDependencyContainer> OnContainerSet;

        public static void HackViewFactory(IContainer container)
        {
            var registeredTypes =
                container.ComponentRegistry.Registrations.SelectMany(x => x.Services)
               .OfType<IServiceWithType>()
               .Select(x => x.ServiceType);

            var typeDictionary = new Dictionary<Type, Type>();
            foreach (var viewModelType in registeredTypes.Where(t => t.Name.EndsWith("ViewModel")))
            {
                var viewModelName = viewModelType.Name.Replace("ViewModel", null);
                var pageTypeName = $"{viewModelName}Page";
                var pageType = registeredTypes.FirstOrDefault(t => t.Name.Equals(pageTypeName));
                if (pageType != null)
                    typeDictionary[viewModelType] = pageType;
            }

            var TypeDictionaryField = typeof(ViewFactory).GetTypeInfo().GetDeclaredField("TypeDictionary");
            TypeDictionaryField?.SetValue(null, typeDictionary);
        }

        private void InitializeServices()
        {
            var builder = new ContainerBuilder();
            var assambly = typeof(App).GetTypeInfo().Assembly;

            // Auto registr all ViewModels, Pages and Services
            builder.AutoRegisterMvvmAndServices(assambly);

            var autofacContainer = builder.Build();
            HackViewFactory(autofacContainer);

            var container = new AutofacContainer(autofacContainer);

            // Allow to register native services
            OnContainerSet?.Invoke(container);

            // Register PCL Services
            container.Register<IDependencyContainer>(container);

            // Set global resolver
            if (!Resolver.IsSet)
                Resolver.SetResolver(container.GetResolver());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
