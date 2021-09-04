using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Controllers
{
    public class CategoryController:Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategoriesAsync());
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
            
        }
        public async Task< IActionResult> Edit(int id)
        {
            return View(await _categoryService.GetCategoryAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.EditCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _categoryService.GetCategoryAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
                await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction(nameof(Index));
        }
    }
}
