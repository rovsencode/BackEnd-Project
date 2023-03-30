namespace BackEndProject.Models
{
    public class Socials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int TeacherId  { get; set; }
        public Teacher Teacher  { get; set; }

    }
}
