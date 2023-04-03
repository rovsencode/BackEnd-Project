using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CoursesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Courses> courses= _appDbContext.Courses.Include(c => c.CourseFeatures)
                .Include(c => c.Categories).Include(c => c.CourseTags).ToList();
            return View(courses);
        }
        public async Task<IActionResult> Detail(int? id)
        {

            if(id==null)return NotFound();
            CourseDetailVM courseDetailVM = new()
            {
                Blogs =  _appDbContext.Blogs.Take(3).ToList(),
                Categories =   _appDbContext.Categories.ToList(),
                Course = await _appDbContext.Courses.Include(c=>c.CourseFeatures).Include(c => c.CourseTags)
               .ThenInclude(c =>c.Tag).FirstOrDefaultAsync(c => c.Id == id)
        };
            if(courseDetailVM==null) return NotFound();
            return View(courseDetailVM);
            
        }
    }
}
