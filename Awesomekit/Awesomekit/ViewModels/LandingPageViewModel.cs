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
                new Slide("landing01.png", "Some description for slide one.", 0),
                new Slide("landing02.png", "Some description for slide two.", 1),
                new Slide("landing03.png", "Some description for slide three.", 2)
            });
        }
        
        public ObservableCollection<Slide> Slides { get; }
    }
}
