namespace Awesomekit.Models
{
    public class LandingCarouselItem
    {
        public LandingCarouselItem(string image, string description)
        {
            Image = image;
            Description = description;
        }

        public string Image { get; set; }
        
        public string Description { get; set; }
    }
}