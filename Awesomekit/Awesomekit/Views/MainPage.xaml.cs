using System.Threading.Tasks;
using Xamarin.Forms;

namespace Awesomekit.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Waiting some time
            await Task.Delay(2000);

            // Start animation
            await Task.WhenAll(
                SplashGrid.FadeTo(0, 2000),
                Logo.ScaleTo(10, 2000)
                );
        }
    }
}
