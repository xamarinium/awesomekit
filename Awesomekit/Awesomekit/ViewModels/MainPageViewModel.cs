using Prism.Navigation;

namespace Awesomekit.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public string WelcomeMessage { get; set; } = "Welcome to Xamarin Forms with Prism!";

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
