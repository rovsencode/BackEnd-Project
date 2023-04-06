namespace BackEndProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BlogTag> BlogTags { get; set;}
    }
}
