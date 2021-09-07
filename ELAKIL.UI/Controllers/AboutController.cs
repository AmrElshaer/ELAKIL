using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELAKIL.Business.IService;
using ELAKIL.Business.Entities;
using Microsoft.AspNetCore.Authorization;
using ELAKIL.Business.Common;

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
        public async Task<IActionResult> Index()
        {
            About about = await aboutService.GetAboutAsync();
            return View(about);
        }

        // Show edit about page
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            if (User.IsInRole(ApplicationRoles.Admin.ToString()))
            {
                About about = await aboutService.GetAboutAsync();
                return View(about);
            }
            return RedirectToAction("Index");
        }

        // Edit about by id
        [HttpPost]
        public async Task<IActionResult> Edit(About about)
        {
            await aboutService.EditAddAboutAsync(about);
            return RedirectToAction("Index");
        }
    }
}
