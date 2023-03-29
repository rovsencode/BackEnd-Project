namespace BackEndProject.Models
{
    public class TeacherHobbies
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int HobbieId { get; set; }

        public Hobbies Hobbie { get; set; }
        public Teacher Teacher { get; set; }

    }
}
