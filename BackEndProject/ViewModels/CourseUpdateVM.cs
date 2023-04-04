namespace BackEndProject.ViewModels
{
    public class CourseUpdateVM
    {
        public IFormFile? Photo { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string ApplyDescrip { get; set; }
        public string Certification { get; set; }
    }
}
