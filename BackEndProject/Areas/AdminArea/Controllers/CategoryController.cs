using BackEndProject.DAL;
using BackEndProject.Models;
using FirelloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminArea.Controllers
{
        [Area("AdminArea")]
    public class CategoryController : Controller
    {

            private readonly AppDbContext _appDbContext;

            public CategoryController(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            public IActionResult Index()
            {
                return View(_appDbContext.Categories.ToList());

            }

            public IActionResult Detail(int id)
            {
                if (id == null) return NotFound();
                Categories category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
                if (category == null) return NotFound();
                return View(category);
            }
            public IActionResult Create()
            {

                return View();
            }

            [HttpPost]
            public IActionResult Create(CategoryCreateVM category)
            {
                if (!ModelState.IsValid) return View();

                bool isExist = _appDbContext.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
                if (isExist)
                {
                    ModelState.AddModelError("Name", "Bu category  movcuddur");
                    return View();
                }


                Categories newCategory = new()
                {
                    Name = category.Name,
           
                };

                _appDbContext.Categories.Add(newCategory);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Edit(int id)
            {
                if (id == null) return NotFound();
                Categories category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
                if (category == null) return NotFound();
                return View(new CategoryUpdateVM { Name = category.Name });
            }
            [HttpPost]
            public IActionResult Edit(int id, CategoryUpdateVM updateVM)
            {
                if (id == null) return NotFound();
                if (!ModelState.IsValid) return View();


                bool isExist = _appDbContext.Categories.Any(c => c.Name.ToLower() == updateVM.Name.ToLower() && c.Id != id);
                if (isExist)
                {
                    ModelState.AddModelError("Name", "Bu category  movcuddur");
                    return View();
                }

                Categories existCategory = _appDbContext.Categories.Find(id);
                if (existCategory == null) return NotFound();
                existCategory.Name = updateVM.Name;
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                if (id == null) return NotFound();
                Categories category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
                if (category == null) return NotFound();
                _appDbContext.Categories.Remove(category);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
}
