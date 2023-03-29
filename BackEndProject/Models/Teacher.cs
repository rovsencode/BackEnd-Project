namespace BackEndProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Exprience { get; set; }
        public string Degree { get; set; }
        public string Faculty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Socials> Socials { get; set; }
        public List<Skills> Skills { get; set; }
        public List<TeacherHobbies> TeacherHobbies { get; set; }
   
       
    }
}
