namespace BackEndProject.Models
{
    public class CourseTags
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TagId { get; set; }
        public  Tags Tag { get; set; }
        public Courses Course { get; set; }

    }
}
