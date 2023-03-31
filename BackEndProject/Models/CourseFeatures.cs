namespace BackEndProject.Models
{
    public class CourseFeatures
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public int ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public string Students { get; set; }
        public string Assesments { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
