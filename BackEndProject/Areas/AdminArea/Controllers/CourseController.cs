using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using FirelloProject.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Courses.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Courses course = _appDbContext.Courses.SingleOrDefault(n => n.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseCreateVM course)
        {
            if (!ModelState.IsValid) return View();
            if (course.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma ");
                return View();
            }
            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only image ");
                return View();
            }
            if (course.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur ");
                return View();

            }
            Courses newCourse = new()
            {
                Name= course.Name,
                Description = course.Description,
                About= course.About,
                ApplyDescrip= course.ApplyDescrip,
                Certification= course.Certification,
                ImageUrl = course.Photo.SaveImage(_env, "img/course", course.Photo.FileName),
                CategoriesId = course.CategoryId,

            };

            _appDbContext.Courses.Add(newCourse);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Courses course = _appDbContext.Courses.SingleOrDefault(c=> c.Id == id);
            if (course == null) return NotFound();
            return View(new CourseUpdateVM { Name = course.Name, Description = course.Description,About=course.About,ApplyDescrip=course.ApplyDescrip,Certification=course.Certification,ImageUrl=course.ImageUrl });
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
            existCourse.About= updateVM.About;
            existCourse.ApplyDescrip = updateVM.ApplyDescrip;
            existCourse.Certification = updateVM.Certification;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Courses course = _appDbContext.Courses.SingleOrDefault(n => n.Id == id);
            if (course == null) return NotFound();
            _appDbContext.Courses.Remove(course);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
