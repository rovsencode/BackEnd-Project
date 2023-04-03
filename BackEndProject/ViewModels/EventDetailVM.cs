using BackEndProject.Models;

namespace BackEndProject.ViewModels
{
    public class EventDetailVM
    {
        public Event even{ get;set;}
        public List<Categories> Categories { get; set;}
        public List<Tags> Tags { get; set;}
        public List<Blog> Blogs { get; set; }
        
    }
}
