using Awesomekit.ViewModels;
using CarouselView.FormsPlugin.Abstractions;
using DefaultNamespace;
using Xamarin.Forms;
using ScrolledEventArgs = CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs;

namespace Awesomekit.Views
{
    public partial class CarouselCellView : Grid
    {
        private bool _isAcrtive;

        private Slide _slide;

        private LandingPageViewModel _viewModel;
        
        public CarouselCellView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _slide = BindingContext as Slide;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent is CarouselViewControl carouselViewControl)
            {
                _viewModel = Parent.BindingContext as LandingPageViewModel;
                carouselViewControl.Scrolled += CarouselViewControlOnScrolled;
                carouselViewControl.PositionSelected += (sender, args) =>
                    {
                        _isAcrtive = args.NewValue == _viewModel.Slides.IndexOf(_slide);
                    };
            }
        }
        
        private void CarouselViewControlOnScrolled(object sender, ScrolledEventArgs e)
        {
            
            
            //var x = (e.Direction == ScrollDirection.Left ? 1 : -1) * 
            //        (e.NewValue < 50 ? e.NewValue : 100 - e.NewValue) / 100 * Width;
            
            //LogoImage.TranslateTo(x, 0);

            if (_isAcrtive)
            {
                LogoImage.ScaleTo((100 - e.NewValue)/100);
                LogoImage.RotateTo((100 - e.NewValue) / 100 * 360);
            }
            else
            {
                LogoImage.ScaleTo(e.NewValue / 100);
                LogoImage.RotateTo(e.NewValue / 100 * 360);
            }
        }
    }
}
