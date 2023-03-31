using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TeacherController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var teachers = _appDbContext.Teachers.Include(t => t.Socials).ToList();
            return View(teachers);
        }

        public  IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Teacher teacher=  _appDbContext.Teachers.Include(t=>t.Socials)
                .Include(t=>t.Skills).Include(t=>t.TeacherHobbies).FirstOrDefault(t=>t.Id==id);
            if (teacher == null) return NotFound();
           return View(teacher);
        }
    }
}
