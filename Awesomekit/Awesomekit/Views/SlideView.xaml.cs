using Awesomekit.ViewModels;
using CarouselView.FormsPlugin.Abstractions;
using DefaultNamespace;
using Xamarin.Forms;
using ScrolledEventArgs = CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs;

namespace Awesomekit.Views
{
    public partial class SlideView : Grid
    {
        private bool _isActive;

        private LandingPageViewModel _viewModel;
        
        public SlideView()
        {
            InitializeComponent();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent is CarouselViewControl carouselViewControl)
            {
                _viewModel = carouselViewControl.BindingContext as LandingPageViewModel;
                carouselViewControl.PositionSelected += CarouselViewControlOnPositionSelected;
                carouselViewControl.Scrolled += CarouselViewControlOnScrolled;
            }
        }

        private void CarouselViewControlOnScrolled(object sender, ScrolledEventArgs e)
        {
            if (_isActive)
            {
                // Hide active slide
                ImageSlide.FadeTo((100 - e.NewValue) / 100);
                ImageSlide.RotateTo((100 - e.NewValue) / 100 * 360);
                ImageSlide.ScaleTo((100 - e.NewValue) / 100);
            }
            else
            {
                // Show slide if it's not active
                ImageSlide.FadeTo(e.NewValue / 100);
                ImageSlide.RotateTo(e.NewValue / 100 * 360);
                ImageSlide.ScaleTo(e.NewValue / 100);
            }
        }

        private void CarouselViewControlOnPositionSelected(object sender, PositionSelectedEventArgs e)
        {
            _isActive = e.NewValue == _viewModel.Slides.IndexOf(BindingContext as Slide);
        }
    }
}
