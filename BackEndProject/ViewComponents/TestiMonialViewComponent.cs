using BackEndProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.ViewComponents
{
    public class TestiMonialViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public TestiMonialViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliderComment = _appDbContext.SliderComments.FirstOrDefault();
            return View(await Task.FromResult(sliderComment));
        }
    }
}
