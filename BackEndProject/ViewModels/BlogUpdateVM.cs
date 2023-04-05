namespace BackEndProject.ViewModels
{
    public class BlogUpdateVM
    {
        public IFormFile? Photo { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
