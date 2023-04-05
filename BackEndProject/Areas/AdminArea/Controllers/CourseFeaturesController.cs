using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    public class CourseFeaturesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
