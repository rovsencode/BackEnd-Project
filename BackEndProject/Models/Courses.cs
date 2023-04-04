namespace BackEndProject.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public string ApplyDescrip { get; set; }
        public string Certification { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesId { get; set; }
        public List<CourseFeatures> CourseFeatures { get; set; }
        public List<CourseTags> CourseTags { get; set; }
    }
}
