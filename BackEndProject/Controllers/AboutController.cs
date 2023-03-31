using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {

            AboutVM aboutVM = new();
            aboutVM.Teachers=_appDbContext.Teachers.Include(t=>t.Socials).Take(4).ToList();
            aboutVM.Notices = _appDbContext.Notices.ToList();
            aboutVM.WelcomeEduHome = _appDbContext.WelcomeEduHomes.FirstOrDefault();
            
            return View(aboutVM);
        }
    }
}
