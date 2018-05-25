using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Awesomekit.Models;
using Prism.Navigation;

namespace Awesomekit.ViewModels
{
    public class LandingPageViewModel : BaseViewModel
    {
        public LandingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ItemsSource = new ObservableCollection<LandingCarouselItem>(new List<LandingCarouselItem>
            {
                new LandingCarouselItem("landing01.png", $"Some description for first item.{Environment.NewLine}You can change it in view model"),
                new LandingCarouselItem("landing02.png", $"Some description for second item.{Environment.NewLine}You can change it in view model"),
                new LandingCarouselItem("landing03.png", $"Some description for third item.{Environment.NewLine}You can change it in view model")
            });
        }
        
        public ObservableCollection<LandingCarouselItem> ItemsSource { get; set; }
    }
}
