using BackEndProject.DAL;
using BackEndProject.Migrations;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseTagsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public CourseTagsController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Tags> tags= _appDbContext.Tags.ToList();
            return View(tags);
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Courses course = _appDbContext.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }
        public IActionResult Create()
        {
            ViewBag.Courses = _appDbContext.Courses.ToList();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CourseTagCreateVM tagCreateVM)
        {
            if (!ModelState.IsValid) return View();

            Tags newTag = new();

            newTag.Name = tagCreateVM.Name;
    


        
        

            
           

            _appDbContext.Tags.Add(newTag);

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Tags tag = _appDbContext.Tags.SingleOrDefault(c => c.Id == id);
            if (tag == null) return NotFound();
            return View(new CourseUpdateVM { Name = tag.Name });
        }
        [HttpPost]
        public IActionResult Edit(int id, CourseTagUpdateVM updateVM)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View();




            Tags existTag = _appDbContext.Tags.Find(id);
            if (existTag == null) return NotFound();
            existTag.Name = updateVM.Name;

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Tags tag = _appDbContext.Tags.SingleOrDefault(n => n.Id == id);
            if (tag == null) return NotFound();
            _appDbContext.Tags.Remove(tag);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
