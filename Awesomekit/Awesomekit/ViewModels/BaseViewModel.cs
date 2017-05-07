using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace Awesomekit.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        protected readonly INavigationService NavigationService;

        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
