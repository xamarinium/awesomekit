using Prism.Navigation;

namespace Awesomekit.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public string WelcomeMessage { get; set; } = "Welcome to Xamarin Forms!";

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
