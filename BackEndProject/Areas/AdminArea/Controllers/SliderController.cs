using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using FirelloProject.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;



        public SliderController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Sliders.ToList());
        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(SliderCreateVM sliderCreateVM)
        {
            if (sliderCreateVM.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bosh qoyma ");
                return View();
            }
            if (!sliderCreateVM.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "only image ");
                return View();
            }
            if (sliderCreateVM.Photo.CheckImageSize(500))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur ");
                return View();

            }


            Slider newSlider = new();
            newSlider.ImageUrl = sliderCreateVM.Photo.SaveImage(_env, "img/slider", sliderCreateVM.Photo.FileName);
            newSlider.Title = sliderCreateVM.Title;
            newSlider.Description = sliderCreateVM.Description;

            _appDbContext.Sliders.Add(newSlider);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var slider = _appDbContext.Sliders.FirstOrDefault(c => c.Id == id);
            _appDbContext.Sliders.Remove(slider);
            if (slider == null) return NotFound();

            string fullPath = Path.Combine(_env.WebRootPath, "img", slider.ImageUrl);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Slider slider = _appDbContext.Sliders.SingleOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            return View(new SliderUpdateVM { ImageUrl = slider.ImageUrl, Title = slider.Title,Description=slider.Description }); ;


        }
        [HttpPost]
        public IActionResult Edit(int id, SliderUpdateVM sliderUpdateVM)
        {
            if (id == null) return NotFound();
            Slider slider = _appDbContext.Sliders.SingleOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();
            if (sliderUpdateVM.Photo != null)
            {

                if (!sliderUpdateVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "only image ");
                    return View();
                }
                if (sliderUpdateVM.Photo.CheckImageSize(500))
                {
                    ModelState.AddModelError("Photo", "olcu boyukdur ");
                    return View();

                }
                string fullPath = Path.Combine(_env.WebRootPath, "img", slider.ImageUrl);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                slider.ImageUrl = sliderUpdateVM.Photo.SaveImage(_env, "img", sliderUpdateVM.Photo.FileName);
                _appDbContext.SaveChanges();
            }
            if (sliderUpdateVM.Title != null)
            {
                slider.Title = sliderUpdateVM.Title;
                _appDbContext.SaveChanges();
            }
            if (sliderUpdateVM.Description!=null)
            {
                slider.Description = sliderUpdateVM.Description;
            }

            return RedirectToAction("Index");

        }
    }
}
