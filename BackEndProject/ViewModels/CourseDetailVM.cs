using BackEndProject.Models;

namespace BackEndProject.ViewModels
{
    public class CourseDetailVM
    {
        public Courses Course { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
