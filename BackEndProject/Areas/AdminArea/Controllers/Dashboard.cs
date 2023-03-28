using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    public class Dashboard : Controller
    {
        [Area("AdminArea")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
