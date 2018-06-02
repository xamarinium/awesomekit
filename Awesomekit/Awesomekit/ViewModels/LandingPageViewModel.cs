using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace;
using Prism.Navigation;

namespace Awesomekit.ViewModels
{
    public class LandingPageViewModel : BaseViewModel
    {
        public LandingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Slides = new ObservableCollection<Slide>(new []
            {
                new Slide("landing01.png", "Some description for slide one."),
                new Slide("landing02.png", "Some description for slide two."),
                new Slide("landing03.png", "Some description for slide three.")
            });
        }
        
        public ObservableCollection<Slide> Slides { get; }
    }
}
