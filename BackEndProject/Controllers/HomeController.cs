using BackEndProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {

            var sliders = _appDbContext.Sliders.ToList();
            if (sliders == null) return NotFound();
            return View(sliders);
           

       
        }
   

      
    }
}