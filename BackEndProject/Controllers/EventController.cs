using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Event> events = _appDbContext.Events.Include(e => e.Speakers).ToList();
            if (events == null) return NotFound(); 
            return View(events);
        }

        public IActionResult Detail(int id)
        {
            EventDetailVM eventDetailVM = new();
            eventDetailVM.even = _appDbContext.Events.Include(e => e.Speakers)
                 .ThenInclude(e => e.Companie).Include(e => e.EventTags).ThenInclude(e => e.Tag)
                .FirstOrDefault(e=>e.Id==id);
            eventDetailVM.Categories = _appDbContext.Categories.ToList();
            eventDetailVM.Blogs = _appDbContext.Blogs.Take(3).ToList();
           
            return View(eventDetailVM);
        }
    }
}
