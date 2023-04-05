using BackEndProject.DAL;
using BackEndProject.Migrations;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using FirelloProject.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Blogs.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            Blog blog = _appDbContext.Blogs.SingleOrDefault(n => n.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateVM  blogCreateVM)
        {
            if (!ModelState.IsValid) return View();
            if (blogCreateVM.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma ");
                return View();
            }
            if (!blogCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only image ");
                return View();
            }
            if (blogCreateVM.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur ");
                return View();

            }
            Blog blog = new()
            {
                Name = blogCreateVM.Name,
                AuthorName= blogCreateVM.AuthorName,
                DateTime= blogCreateVM.DateTime,
                Description= blogCreateVM.Description,
                ImageUrl = blogCreateVM.Photo.SaveImage(_env, "img/blog", blogCreateVM.Photo.FileName),
            };

            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Blog blog = _appDbContext.Blogs.SingleOrDefault(c => c.Id == id);
            if (blog == null) return NotFound();
            return View(new BlogUpdateVM { Name = blog.Name, AuthorName=blog.AuthorName,Description=blog.Description,DateTime=blog.DateTime,ImageUrl=blog.ImageUrl});
        }
        [HttpPost]
        public IActionResult Edit(int id, BlogUpdateVM  blogUpdateVM)
        {
            if (id == null) return NotFound();
            if (!ModelState.IsValid) return View();

            Blog existBlog = _appDbContext.Blogs.Find(id);
            if (blogUpdateVM.Photo!=null)
            {
                existBlog.ImageUrl = blogUpdateVM.Photo.SaveImage(_env, "img/blog", blogUpdateVM.Photo.FileName);
            }


            if (existBlog == null) return NotFound();
            existBlog.Name = blogUpdateVM.Name;
            existBlog.Description = blogUpdateVM.Description;
            existBlog.AuthorName = blogUpdateVM.AuthorName;
            existBlog.ImageUrl = blogUpdateVM.ImageUrl;
            existBlog.DateTime = blogUpdateVM.DateTime;
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            Blog blog = _appDbContext.Blogs.SingleOrDefault(n => n.Id == id);
            if (blog == null) return NotFound();
            _appDbContext.Blogs.Remove(blog);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
