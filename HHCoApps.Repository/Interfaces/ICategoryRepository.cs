using System.Collections.Generic;
using HHCoApps.Core;

namespace HHCoApps.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        int AddNewCategory(Category entity);
        int UpdateCategoryById(Category entity);
    }
}