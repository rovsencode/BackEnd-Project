namespace BackEndProject.Models
{
    public class Companie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Speaker> Speakers { get;set;}
    }
}
