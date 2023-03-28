﻿using BackEndProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.ViewComponents;
    public class HeaderViewComponent : ViewComponent
{
    private readonly AppDbContext _appDbContext;

    public HeaderViewComponent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var bio = _appDbContext.Bios.FirstOrDefault();


        return View(await Task.FromResult(bio));
    }
}

