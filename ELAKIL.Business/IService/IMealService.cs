using ELAKIL.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IMealService
    {
        Task<IEnumerable<Meal>> GetMealsAsync();

        Task<int> AddMealAsync(Meal meal);

        Task<int> EditMealAsync(Meal meal);

        Task DeleteMealAsync(int id);

        Task<Meal> GetMealAsync(int id);
        Task<IEnumerable<Meal>> ShowMealsAsync(int take, int skip=0,string search=null);
    }
}