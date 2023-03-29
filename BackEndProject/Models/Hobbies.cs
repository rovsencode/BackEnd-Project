namespace BackEndProject.Models
{
    public class Hobbies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherHobbies> TeacherHobbies { get; set; }
    }
}
