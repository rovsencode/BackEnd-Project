namespace BackEndProject.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public int CompanieId { get; set; } 
        public Companie Companie { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
