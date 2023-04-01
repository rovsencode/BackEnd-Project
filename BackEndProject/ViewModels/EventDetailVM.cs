using BackEndProject.Models;

namespace BackEndProject.ViewModels
{
    public class EventDetailVM
    {
        public Event even{ get;set;}
        public List<Categories> Categories { get; set;}
    }
}
