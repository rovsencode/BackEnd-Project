namespace BackEndProject.ViewModels
{
    public class EventUpdateVM
    {
        public IFormFile? Photo { get; set; }

        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Venue { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
