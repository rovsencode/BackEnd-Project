using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Blog> blogs=_appDbContext.Blogs.ToList();
            return View(blogs);
        }
        public async Task<IActionResult> Detail(int id)
        {

            ViewBag.UserId = null;

            if (User.Identity.IsAuthenticated)
            {
                AppUser user =await  _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            if (id == null) return NotFound();
            BlogDetailVM blogDetailVM = new();
            blogDetailVM.Blog= _appDbContext.Blogs.Include(b=>b.BlogTags).ThenInclude(b=>b.Tag).FirstOrDefault(b=>b.Id==id);
            blogDetailVM.Categories= _appDbContext.Categories.ToList();
            blogDetailVM.Blogs = _appDbContext.Blogs.Take(3).ToList();
            blogDetailVM.Comments = _appDbContext.Comments.ToList();
            if (blogDetailVM==null) return NotFound();
            return View(blogDetailVM);  

        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string message, int blogId, string subject)
        {
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            else
            {
                return RedirectToAction("login", "account");
            }
            Comment comment = new();
            comment.CreatedDate = DateTime.Now;
            comment.AppUserId = user.Id;
            comment.BlogId = blogId;
            comment.Message = message;
            comment.Subject = subject;
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
            return RedirectToAction("detail", new { id = blogId });
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            Comment comment = _appDbContext.Comments.FirstOrDefault(b => b.Id == id);
            if (comment == null) return NotFound();
            _appDbContext.Comments.Remove(comment);
            _appDbContext.SaveChanges();
            return RedirectToAction("detail", new { id = comment.BlogId });
        }
    }
}
