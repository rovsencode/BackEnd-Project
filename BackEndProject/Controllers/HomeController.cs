﻿using BackEndProject.DAL;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {

         
            HomeVM homeVM = new();
            homeVM.Sliders= _appDbContext.Sliders.ToList(); 
            homeVM.Notices= _appDbContext.Notices.ToList();
            homeVM.eduHomeInfo=_appDbContext.EduHomeInfos.FirstOrDefault();
            homeVM.BoardsInfos=_appDbContext.BoardInfos.ToList();
            homeVM.sliderComment = _appDbContext.SliderComments.FirstOrDefault(); 
            homeVM.Courses=_appDbContext.Courses.Take(3).ToList();
            homeVM.Events= _appDbContext.Events.ToList();
            homeVM.Blogs= _appDbContext.Blogs.Take(3).ToList();
            return View(homeVM);
           

       
        }
   

      
    }
}