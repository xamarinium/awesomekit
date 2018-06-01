using Awesomekit.Helpers;
using Xamarin.Forms;
using ScrolledEventArgs = CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs;

namespace Awesomekit.Views
{
    [Page("landing")]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
            
            CarouselView.Scrolled += CarouselViewOnScrolled;
            CarouselView.AnimateTransition = true;
        }

        private void CarouselViewOnScrolled(object sender, ScrolledEventArgs e)
        {
            CarouselView.AnimateTransition = true;
        }
    }
}