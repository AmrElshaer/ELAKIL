﻿using ELAKIL.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<int> AddCategoryAsync(Category category);

        Task<int> EditCategoryAsync(Category category);

        Task DeleteCategoryAsync(int id);

        Task<Category> GetCategoryAsync(int id);
    }
}