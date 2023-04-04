using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class NoticeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public NoticeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Notices.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Notice notice = _appDbContext.Notices.SingleOrDefault(n => n.Id == id);
            if (notice == null) return NotFound();
            return View(notice);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(NoticeCreateVM notice)
        {
            if (!ModelState.IsValid) return View();

            Notice newNotice = new()
            {
                Title = notice.Title,
                Description = notice.Description,
            };

            _appDbContext.Notices.Add(newNotice);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Notice notice = _appDbContext.Notices.SingleOrDefault(n => n.Id == id);
            if (notice == null) return NotFound();
            return View(new NoticeUpdateVM { Title = notice.Title, Description = notice.Description });
        }
        [HttpPost]
        public IActionResult Edit(int id, NoticeUpdateVM updateVM)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View();


        

            Notice existNotice = _appDbContext.Notices.Find(id);
            if (existNotice == null) return NotFound();
            existNotice.Title = updateVM.Title;
            existNotice.Description = updateVM.Description;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Notice  notice = _appDbContext.Notices.SingleOrDefault(n => n.Id == id);
            if (notice == null) return NotFound();
            _appDbContext.Notices.Remove(notice);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
