using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            if (category is null)
                throw new ArgumentNullException();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            _context.Categories.Remove(await GetCategoryAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditCategoryAsync(Category category)
        {
            if (category is null)
                throw new ArgumentNullException($"Entity Category {category.Id} Not Found");
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat is null)
                throw new ArgumentNullException($"Entity Category {id} Not Found");
            return cat;
        }
    }
}