namespace BackEndProject.Models
{
    public class BlogTag
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public Tags Tag { get; set; }
        public Blog Blog { get; set; }
    }
}
