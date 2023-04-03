using BackEndProject.Models;

namespace BackEndProject.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Tags> Tags { get; set; }
    }
}
