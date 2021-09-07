using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELAKIL.Business.IService;
using ELAKIL.Business.Entities;

namespace ELAKIL.UI.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        // Show about page
        [HttpGet]
        public async Task<IActionResult> Index(int id = 1)
        {
            About about = await aboutService.GetAboutAsync(id);
            return View(about);
        }

        // Show edit about page
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 1)
        {
            About about = await aboutService.GetAboutAsync(id);
            return View(about);
        }

        // Edit about by id
        [HttpPost]
        public async Task<IActionResult> Edit(int id, About about)
        {
            id = await aboutService.EditAboutAsync(id, about);
            return RedirectToAction("Index", new { id });
        }
    }
}
