using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Blog> blogs=_appDbContext.Blogs.ToList();
            return View(blogs);
        }
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            BlogDetailVM blogDetailVM = new();
            blogDetailVM.Blog= _appDbContext.Blogs.Include(b=>b.BlogTags).ThenInclude(b=>b.Tag).FirstOrDefault(b=>b.Id==id);
            blogDetailVM.Categories= _appDbContext.Categories.ToList();
            blogDetailVM.Blogs = _appDbContext.Blogs.Take(3).ToList();
            if(blogDetailVM==null) return NotFound();
            return View(blogDetailVM);  

        }
    }
}
