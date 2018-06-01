namespace DefaultNamespace
{
    public class Slide
    {
        public Slide(string image, string description, int index)
        {
            Image = image;
            Description = description;
            Index = index;
        }

        public string Image { get; set; }
        
        public string Description { get; set; }
        
        public int Index { get; set; }
    }
}