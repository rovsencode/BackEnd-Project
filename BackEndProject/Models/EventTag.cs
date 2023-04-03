namespace BackEndProject.Models
{
    public class EventTag
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int TagId { get; set; }
        public Tags Tag { get; set; }
        public Event Event { get; set; }
    }
}
