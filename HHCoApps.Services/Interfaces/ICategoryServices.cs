using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel GetCategoryById(int categoryId);
        bool CheckDuplicateCategory(string categoryName);
        bool AddCategory(CategoryModel model);
        bool UpdateCategory(CategoryModel model);
    }
}
