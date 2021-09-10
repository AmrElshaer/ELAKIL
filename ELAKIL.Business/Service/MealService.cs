using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Meal>> ShowMealsAsync(int take,int skip, string search)
        {
            return await _context.Meals.Where(a=> string.IsNullOrEmpty(search)
            ||a.Name.ToLower().Contains(search.ToLower())).OrderBy(a=>a.Id).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<int> AddMealAsync(Meal meal)
        {
            if (meal is null)
                throw new ArgumentNullException();
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task DeleteMealAsync(int id)
        {
            _context.Meals.Remove(await GetMealAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditMealAsync(Meal meal)
        {
            if (meal is null)
                throw new ArgumentNullException($"Entity Meal {meal.Id} Not Found");
            _context.Meals.Update(meal);
            await _context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<Meal> GetMealAsync(int id)
        {
            var mel = await _context.Meals.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id);
            if (mel is null)
                throw new ArgumentNullException($"Entity Meal {id} Not Found");
            return mel;
        }

        public async Task<IEnumerable<Meal>> GetMealsAsync()
        {
            return await _context.Meals.ToListAsync();
        }
    }
}