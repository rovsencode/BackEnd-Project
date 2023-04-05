using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using FirelloProject.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
    {
     
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Teachers.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _appDbContext.Teachers.SingleOrDefault(n => n.Id == id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherCreateVM teacherCreateVM)
        {
            if (!ModelState.IsValid) return View();
            if (teacherCreateVM.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma ");
                return View();
            }
            if (!teacherCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only image ");
                return View();
            }
            if (teacherCreateVM.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur ");
                return View();

            }
            Teacher newTeacher = new()
            {
                FullName = teacherCreateVM.FullName,
                Degree=teacherCreateVM.Degree,
                Description=teacherCreateVM.Description,
                Email=teacherCreateVM.Email,
                Exprience=teacherCreateVM.Exprience,
                Faculty=teacherCreateVM.Faculty,
                PhoneNumber=teacherCreateVM.PhoneNumber,
                Position=teacherCreateVM.Position,
                Skype=teacherCreateVM.Skype,

          
                ImageUrl = teacherCreateVM.Photo.SaveImage(_env, "img/teacher", teacherCreateVM.Photo.FileName),
     

            };

            _appDbContext.Teachers.Add(newTeacher);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _appDbContext.Teachers.SingleOrDefault(c => c.Id == id);
            if (teacher == null) return NotFound();
            return View(new TeacherUpdateVM { FullName = teacher.FullName, Description = teacher.Description,Degree=teacher.Degree,Email=teacher.Email,Exprience=teacher.Exprience,Faculty=teacher.Faculty,PhoneNumber=teacher.PhoneNumber,Position=teacher.Position,Skype=teacher.Skype, ImageUrl = teacher.ImageUrl });
        }
        [HttpPost]
        public IActionResult Edit(int id, TeacherUpdateVM teacherUpdateVM)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View();

            Teacher existTeacher = _appDbContext.Teachers.Find(id);
            if(teacherUpdateVM.Photo!= null)
            {
                existTeacher.ImageUrl = teacherUpdateVM.Photo.SaveImage(_env, "img/teacher", teacherUpdateVM.Photo.FileName);

            }

            if (existTeacher == null) return NotFound();
            existTeacher.Email = teacherUpdateVM.Email;
            existTeacher.Exprience= teacherUpdateVM.Exprience;
            existTeacher.Position= teacherUpdateVM.Position;
            existTeacher.Degree= teacherUpdateVM.Degree;
            existTeacher.Description= teacherUpdateVM.Description;
            existTeacher.PhoneNumber= teacherUpdateVM.PhoneNumber;
            existTeacher.Faculty= teacherUpdateVM.Faculty;
            existTeacher.FullName= teacherUpdateVM.FullName;
            existTeacher.ImageUrl = teacherUpdateVM.ImageUrl;

           
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _appDbContext.Teachers.SingleOrDefault(n => n.Id == id);
            if (teacher == null) return NotFound();
            _appDbContext.Teachers.Remove(teacher);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
