namespace BackEndProject.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Courses> courses { get; set; }
    }
}
