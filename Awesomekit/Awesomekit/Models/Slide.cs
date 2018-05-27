namespace DefaultNamespace
{
    public class Slide
    {
        public Slide(string image, string description)
        {
            Image = image;
            Description = description;
        }

        public string Image { get; set; }
        
        public string Description { get; set; }
    }
}