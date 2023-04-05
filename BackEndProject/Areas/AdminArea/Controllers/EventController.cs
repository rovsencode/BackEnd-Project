using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using FirelloProject.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Events.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Event even = _appDbContext.Events.SingleOrDefault(n => n.Id == id);
            if (even == null) return NotFound();
            return View(even);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(EventCreateVM eventCreateVM)
        {
            if (!ModelState.IsValid) return View();
            if (eventCreateVM.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma ");
                return View();
            }
            if (!eventCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only image ");
                return View();
            }
            if (eventCreateVM.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur ");
                return View();

            }
            Event newEven = new()
            {
                Name = eventCreateVM.Name,
                Description = eventCreateVM.Description,
                ImageUrl = eventCreateVM.Photo.SaveImage(_env, "img/course", eventCreateVM.Photo.FileName),
                Date = eventCreateVM.Date,
                Deadline= eventCreateVM.Deadline,
                Venue= eventCreateVM.Venue,



            };

            _appDbContext.Events.Add(newEven);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Event even = _appDbContext.Events.SingleOrDefault(c => c.Id == id);
            if (even == null) return NotFound();
            EventUpdateVM eventt = new();
            return View(new EventUpdateVM { Name = even.Name, Date=even.Date,Deadline=even.Date,Description=even.Description,Venue=even.Venue, ImageUrl = even.ImageUrl });
        }
        [HttpPost]
        public IActionResult Edit(int id, CourseUpdateVM updateVM)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View();




            Courses existCourse = _appDbContext.Courses.Find(id);
            if (existCourse == null) return NotFound();
            existCourse.Name = updateVM.Name;
            existCourse.Description = updateVM.Description;
            existCourse.About = updateVM.About;
            existCourse.ApplyDescrip = updateVM.ApplyDescrip;
            existCourse.Certification = updateVM.Certification;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Event even = _appDbContext.Events.SingleOrDefault(n => n.Id == id);
            if (even == null) return NotFound();
            _appDbContext.Events.Remove(even);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
